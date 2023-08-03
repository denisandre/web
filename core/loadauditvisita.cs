using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Cryptography;
using System.Data;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class loadauditvisita : GXProcedure
   {
      public loadauditvisita( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditvisita( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_VisID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17VisID = aP2_VisID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_VisID ,
                                 string aP3_ActualMode )
      {
         loadauditvisita objloadauditvisita;
         objloadauditvisita = new loadauditvisita();
         objloadauditvisita.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditvisita.AV11AuditingObject = aP1_AuditingObject;
         objloadauditvisita.AV17VisID = aP2_VisID;
         objloadauditvisita.AV15ActualMode = aP3_ActualMode;
         objloadauditvisita.context.SetSubmitInitialConfig(context);
         objloadauditvisita.initialize();
         Submit( executePrivateCatch,objloadauditvisita);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditvisita)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( StringUtil.StrCmp(AV14SaveOldValues, "Y") == 0 )
         {
            if ( ( StringUtil.StrCmp(AV15ActualMode, "DLT") == 0 ) || ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 ) )
            {
               /* Execute user subroutine: 'LOADOLDVALUES' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
         }
         else
         {
            /* Execute user subroutine: 'LOADNEWVALUES' */
            S121 ();
            if ( returnInSub )
            {
               this.cleanup();
               if (true) return;
            }
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'LOADOLDVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007G2 */
         pr_default.execute(0, new Object[] {AV17VisID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A398VisID = P007G2_A398VisID[0];
            A419VisPaiID = P007G2_A419VisPaiID[0];
            n419VisPaiID = P007G2_n419VisPaiID[0];
            A460VisPaiData = P007G2_A460VisPaiData[0];
            A461VisPaiHora = P007G2_A461VisPaiHora[0];
            A462VisPaiDataHora = P007G2_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P007G2_A465VisPaiAssunto[0];
            A399VisInsData = P007G2_A399VisInsData[0];
            A400VisInsHora = P007G2_A400VisInsHora[0];
            A401VisInsDataHora = P007G2_A401VisInsDataHora[0];
            A402VisInsUsuID = P007G2_A402VisInsUsuID[0];
            n402VisInsUsuID = P007G2_n402VisInsUsuID[0];
            A403VisInsUsuNome = P007G2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P007G2_n403VisInsUsuNome[0];
            A482VisUpdData = P007G2_A482VisUpdData[0];
            n482VisUpdData = P007G2_n482VisUpdData[0];
            A483VisUpdHora = P007G2_A483VisUpdHora[0];
            n483VisUpdHora = P007G2_n483VisUpdHora[0];
            A484VisUpdDataHora = P007G2_A484VisUpdDataHora[0];
            n484VisUpdDataHora = P007G2_n484VisUpdDataHora[0];
            A485VisUpdUsuID = P007G2_A485VisUpdUsuID[0];
            n485VisUpdUsuID = P007G2_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = P007G2_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = P007G2_n486VisUpdUsuNome[0];
            A404VisData = P007G2_A404VisData[0];
            A405VisHora = P007G2_A405VisHora[0];
            A406VisDataHora = P007G2_A406VisDataHora[0];
            A475VisDataFim = P007G2_A475VisDataFim[0];
            n475VisDataFim = P007G2_n475VisDataFim[0];
            A476VisHoraFim = P007G2_A476VisHoraFim[0];
            n476VisHoraFim = P007G2_n476VisHoraFim[0];
            A477VisDataHoraFim = P007G2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P007G2_n477VisDataHoraFim[0];
            A414VisTipoID = P007G2_A414VisTipoID[0];
            A415VisTipoSigla = P007G2_A415VisTipoSigla[0];
            A416VisTipoNome = P007G2_A416VisTipoNome[0];
            A418VisNegID = P007G2_A418VisNegID[0];
            n418VisNegID = P007G2_n418VisNegID[0];
            A466VisNegCodigo = P007G2_A466VisNegCodigo[0];
            A467VisNegAssunto = P007G2_A467VisNegAssunto[0];
            A468VisNegValor = P007G2_A468VisNegValor[0];
            A407VisNegCliID = P007G2_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P007G2_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P007G2_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P007G2_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P007G2_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P007G2_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P007G2_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P007G2_n471VisNegCpjRazSocial[0];
            A422VisNgfSeq = P007G2_A422VisNgfSeq[0];
            n422VisNgfSeq = P007G2_n422VisNgfSeq[0];
            A423VisNgfIteID = P007G2_A423VisNgfIteID[0];
            A424VisNgfIteNome = P007G2_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P007G2_n424VisNgfIteNome[0];
            A409VisAssunto = P007G2_A409VisAssunto[0];
            A410VisDescricao = P007G2_A410VisDescricao[0];
            n410VisDescricao = P007G2_n410VisDescricao[0];
            A417VisLink = P007G2_A417VisLink[0];
            n417VisLink = P007G2_n417VisLink[0];
            A472VisSituacao = P007G2_A472VisSituacao[0];
            A487VisDel = P007G2_A487VisDel[0];
            A490VisDelDataHora = P007G2_A490VisDelDataHora[0];
            n490VisDelDataHora = P007G2_n490VisDelDataHora[0];
            A488VisDelData = P007G2_A488VisDelData[0];
            n488VisDelData = P007G2_n488VisDelData[0];
            A489VisDelHora = P007G2_A489VisDelHora[0];
            n489VisDelHora = P007G2_n489VisDelHora[0];
            A491VisDelUsuID = P007G2_A491VisDelUsuID[0];
            n491VisDelUsuID = P007G2_n491VisDelUsuID[0];
            A492VisDelUsuNome = P007G2_A492VisDelUsuNome[0];
            n492VisDelUsuNome = P007G2_n492VisDelUsuNome[0];
            A460VisPaiData = P007G2_A460VisPaiData[0];
            A461VisPaiHora = P007G2_A461VisPaiHora[0];
            A462VisPaiDataHora = P007G2_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P007G2_A465VisPaiAssunto[0];
            A415VisTipoSigla = P007G2_A415VisTipoSigla[0];
            A416VisTipoNome = P007G2_A416VisTipoNome[0];
            A466VisNegCodigo = P007G2_A466VisNegCodigo[0];
            A467VisNegAssunto = P007G2_A467VisNegAssunto[0];
            A468VisNegValor = P007G2_A468VisNegValor[0];
            A407VisNegCliID = P007G2_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P007G2_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P007G2_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P007G2_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P007G2_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P007G2_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P007G2_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P007G2_n471VisNegCpjRazSocial[0];
            A423VisNgfIteID = P007G2_A423VisNgfIteID[0];
            A424VisNgfIteNome = P007G2_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P007G2_n424VisNgfIteNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_visita";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A398VisID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Visita Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A419VisPaiID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Visita Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A460VisPaiData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Visita Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A461VisPaiHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agendada/Realizada em";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiAssunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Visita Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A465VisPaiAssunto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A399VisInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A400VisInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário responsável pela inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A402VisInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A403VisInsUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Atualização";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A482VisUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Atualização";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A483VisUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Atualização";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A484VisUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Atualização";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A485VisUpdUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Última Atualização";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A486VisUpdUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A404VisData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataFim";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A475VisDataFim, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisHoraFim";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataHoraFim";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A414VisTipoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla do Tipo da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A415VisTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Tipo da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A416VisTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Negociação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A418VisNegID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCodigo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Negociação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A466VisNegCodigo), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegAssunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto da Negociação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A467VisNegAssunto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegValor";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor em Negócios";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A468VisNegValor, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Id do Cliente";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A407VisNegCliID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCliNomeFamiliar";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A469VisNegCliNomeFamiliar;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Cliente PJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A408VisNegCpjID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjNomFan";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A470VisNegCpjNomFan;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjRazSocial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A471VisNegCpjRazSocial;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase da Negociação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A422VisNgfSeq), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfIteID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Iteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A423VisNgfIteID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfIteNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A424VisNgfIteNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisAssunto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A409VisAssunto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDescricao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição da Visita";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A410VisDescricao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisLink";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Link Externo (Ms Teams, Google Meet, Zoom, etc.)";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A417VisLink;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisSituacao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Situação";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A472VisSituacao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A487VisDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A488VisDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A489VisDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A491VisDelUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A492VisDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007G3 */
         pr_default.execute(1, new Object[] {AV17VisID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A398VisID = P007G3_A398VisID[0];
            A419VisPaiID = P007G3_A419VisPaiID[0];
            n419VisPaiID = P007G3_n419VisPaiID[0];
            A460VisPaiData = P007G3_A460VisPaiData[0];
            A461VisPaiHora = P007G3_A461VisPaiHora[0];
            A462VisPaiDataHora = P007G3_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P007G3_A465VisPaiAssunto[0];
            A399VisInsData = P007G3_A399VisInsData[0];
            A400VisInsHora = P007G3_A400VisInsHora[0];
            A401VisInsDataHora = P007G3_A401VisInsDataHora[0];
            A402VisInsUsuID = P007G3_A402VisInsUsuID[0];
            n402VisInsUsuID = P007G3_n402VisInsUsuID[0];
            A403VisInsUsuNome = P007G3_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P007G3_n403VisInsUsuNome[0];
            A482VisUpdData = P007G3_A482VisUpdData[0];
            n482VisUpdData = P007G3_n482VisUpdData[0];
            A483VisUpdHora = P007G3_A483VisUpdHora[0];
            n483VisUpdHora = P007G3_n483VisUpdHora[0];
            A484VisUpdDataHora = P007G3_A484VisUpdDataHora[0];
            n484VisUpdDataHora = P007G3_n484VisUpdDataHora[0];
            A485VisUpdUsuID = P007G3_A485VisUpdUsuID[0];
            n485VisUpdUsuID = P007G3_n485VisUpdUsuID[0];
            A486VisUpdUsuNome = P007G3_A486VisUpdUsuNome[0];
            n486VisUpdUsuNome = P007G3_n486VisUpdUsuNome[0];
            A404VisData = P007G3_A404VisData[0];
            A405VisHora = P007G3_A405VisHora[0];
            A406VisDataHora = P007G3_A406VisDataHora[0];
            A475VisDataFim = P007G3_A475VisDataFim[0];
            n475VisDataFim = P007G3_n475VisDataFim[0];
            A476VisHoraFim = P007G3_A476VisHoraFim[0];
            n476VisHoraFim = P007G3_n476VisHoraFim[0];
            A477VisDataHoraFim = P007G3_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P007G3_n477VisDataHoraFim[0];
            A414VisTipoID = P007G3_A414VisTipoID[0];
            A415VisTipoSigla = P007G3_A415VisTipoSigla[0];
            A416VisTipoNome = P007G3_A416VisTipoNome[0];
            A418VisNegID = P007G3_A418VisNegID[0];
            n418VisNegID = P007G3_n418VisNegID[0];
            A466VisNegCodigo = P007G3_A466VisNegCodigo[0];
            A467VisNegAssunto = P007G3_A467VisNegAssunto[0];
            A468VisNegValor = P007G3_A468VisNegValor[0];
            A407VisNegCliID = P007G3_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P007G3_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P007G3_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P007G3_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P007G3_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P007G3_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P007G3_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P007G3_n471VisNegCpjRazSocial[0];
            A422VisNgfSeq = P007G3_A422VisNgfSeq[0];
            n422VisNgfSeq = P007G3_n422VisNgfSeq[0];
            A423VisNgfIteID = P007G3_A423VisNgfIteID[0];
            A424VisNgfIteNome = P007G3_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P007G3_n424VisNgfIteNome[0];
            A409VisAssunto = P007G3_A409VisAssunto[0];
            A410VisDescricao = P007G3_A410VisDescricao[0];
            n410VisDescricao = P007G3_n410VisDescricao[0];
            A417VisLink = P007G3_A417VisLink[0];
            n417VisLink = P007G3_n417VisLink[0];
            A472VisSituacao = P007G3_A472VisSituacao[0];
            A487VisDel = P007G3_A487VisDel[0];
            A490VisDelDataHora = P007G3_A490VisDelDataHora[0];
            n490VisDelDataHora = P007G3_n490VisDelDataHora[0];
            A488VisDelData = P007G3_A488VisDelData[0];
            n488VisDelData = P007G3_n488VisDelData[0];
            A489VisDelHora = P007G3_A489VisDelHora[0];
            n489VisDelHora = P007G3_n489VisDelHora[0];
            A491VisDelUsuID = P007G3_A491VisDelUsuID[0];
            n491VisDelUsuID = P007G3_n491VisDelUsuID[0];
            A492VisDelUsuNome = P007G3_A492VisDelUsuNome[0];
            n492VisDelUsuNome = P007G3_n492VisDelUsuNome[0];
            A460VisPaiData = P007G3_A460VisPaiData[0];
            A461VisPaiHora = P007G3_A461VisPaiHora[0];
            A462VisPaiDataHora = P007G3_A462VisPaiDataHora[0];
            A465VisPaiAssunto = P007G3_A465VisPaiAssunto[0];
            A415VisTipoSigla = P007G3_A415VisTipoSigla[0];
            A416VisTipoNome = P007G3_A416VisTipoNome[0];
            A466VisNegCodigo = P007G3_A466VisNegCodigo[0];
            A467VisNegAssunto = P007G3_A467VisNegAssunto[0];
            A468VisNegValor = P007G3_A468VisNegValor[0];
            A407VisNegCliID = P007G3_A407VisNegCliID[0];
            A469VisNegCliNomeFamiliar = P007G3_A469VisNegCliNomeFamiliar[0];
            n469VisNegCliNomeFamiliar = P007G3_n469VisNegCliNomeFamiliar[0];
            A408VisNegCpjID = P007G3_A408VisNegCpjID[0];
            A470VisNegCpjNomFan = P007G3_A470VisNegCpjNomFan[0];
            n470VisNegCpjNomFan = P007G3_n470VisNegCpjNomFan[0];
            A471VisNegCpjRazSocial = P007G3_A471VisNegCpjRazSocial[0];
            n471VisNegCpjRazSocial = P007G3_n471VisNegCpjRazSocial[0];
            A423VisNgfIteID = P007G3_A423VisNgfIteID[0];
            A424VisNgfIteNome = P007G3_A424VisNgfIteNome[0];
            n424VisNgfIteNome = P007G3_n424VisNgfIteNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_visita";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A398VisID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Visita Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A419VisPaiID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Visita Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A460VisPaiData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Visita Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A461VisPaiHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Agendada/Realizada em";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisPaiAssunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Visita Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A465VisPaiAssunto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A399VisInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A400VisInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário responsável pela inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A402VisInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisInsUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A403VisInsUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Atualização";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A482VisUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Atualização";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A483VisUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Atualização";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A484VisUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Atualização";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A485VisUpdUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisUpdUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Última Atualização";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A486VisUpdUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A404VisData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataFim";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A475VisDataFim, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisHoraFim";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDataHoraFim";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A414VisTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla do Tipo da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A415VisTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Tipo da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A416VisTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Negociação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A418VisNegID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCodigo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Negociação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A466VisNegCodigo), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegAssunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto da Negociação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A467VisNegAssunto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegValor";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor em Negócios";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A468VisNegValor, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Id do Cliente";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A407VisNegCliID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCliNomeFamiliar";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A469VisNegCliNomeFamiliar;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Cliente PJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A408VisNegCpjID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjNomFan";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A470VisNegCpjNomFan;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNegCpjRazSocial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A471VisNegCpjRazSocial;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase da Negociação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A422VisNgfSeq), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfIteID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Iteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A423VisNgfIteID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisNgfIteNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Fase";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A424VisNgfIteNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisAssunto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assunto da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A409VisAssunto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDescricao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição da Visita";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A410VisDescricao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisLink";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Link Externo (Ms Teams, Google Meet, Zoom, etc.)";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A417VisLink;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisSituacao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Situação";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A472VisSituacao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A487VisDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A488VisDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A489VisDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A491VisDelUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "VisDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário Responsável pela Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A492VisDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV20GXV1 = 1;
               while ( AV20GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV20GXV1));
                  AV21GXV2 = 1;
                  while ( AV21GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV21GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A398VisID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisPaiID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A419VisPaiID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisPaiData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A460VisPaiData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisPaiHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A461VisPaiHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisPaiDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A462VisPaiDataHora, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisPaiAssunto") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A465VisPaiAssunto;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A399VisInsData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A400VisInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A401VisInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisInsUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A402VisInsUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisInsUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A403VisInsUsuNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A482VisUpdData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A483VisUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A484VisUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisUpdUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A485VisUpdUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisUpdUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A486VisUpdUsuNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A404VisData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A405VisHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A406VisDataHora, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDataFim") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A475VisDataFim, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisHoraFim") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A476VisHoraFim, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDataHoraFim") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A477VisDataHoraFim, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisTipoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A414VisTipoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisTipoSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A415VisTipoSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisTipoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A416VisTipoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A418VisNegID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCodigo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A466VisNegCodigo), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegAssunto") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A467VisNegAssunto;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegValor") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A468VisNegValor, 16, 2);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCliID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A407VisNegCliID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCliNomeFamiliar") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A469VisNegCliNomeFamiliar;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCpjID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A408VisNegCpjID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCpjNomFan") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A470VisNegCpjNomFan;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNegCpjRazSocial") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A471VisNegCpjRazSocial;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNgfSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A422VisNgfSeq), 8, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNgfIteID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A423VisNgfIteID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisNgfIteNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A424VisNgfIteNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisAssunto") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A409VisAssunto;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDescricao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A410VisDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisLink") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A417VisLink;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisSituacao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A472VisSituacao;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A487VisDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A490VisDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A488VisDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A489VisDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDelUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A491VisDelUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "VisDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A492VisDelUsuNome;
                     }
                     AV21GXV2 = (int)(AV21GXV2+1);
                  }
                  AV20GXV1 = (int)(AV20GXV1+1);
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         scmdbuf = "";
         P007G2_A398VisID = new Guid[] {Guid.Empty} ;
         P007G2_A419VisPaiID = new Guid[] {Guid.Empty} ;
         P007G2_n419VisPaiID = new bool[] {false} ;
         P007G2_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         P007G2_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A465VisPaiAssunto = new string[] {""} ;
         P007G2_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         P007G2_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A402VisInsUsuID = new string[] {""} ;
         P007G2_n402VisInsUsuID = new bool[] {false} ;
         P007G2_A403VisInsUsuNome = new string[] {""} ;
         P007G2_n403VisInsUsuNome = new bool[] {false} ;
         P007G2_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         P007G2_n482VisUpdData = new bool[] {false} ;
         P007G2_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_n483VisUpdHora = new bool[] {false} ;
         P007G2_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_n484VisUpdDataHora = new bool[] {false} ;
         P007G2_A485VisUpdUsuID = new string[] {""} ;
         P007G2_n485VisUpdUsuID = new bool[] {false} ;
         P007G2_A486VisUpdUsuNome = new string[] {""} ;
         P007G2_n486VisUpdUsuNome = new bool[] {false} ;
         P007G2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P007G2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P007G2_n475VisDataFim = new bool[] {false} ;
         P007G2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P007G2_n476VisHoraFim = new bool[] {false} ;
         P007G2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P007G2_n477VisDataHoraFim = new bool[] {false} ;
         P007G2_A414VisTipoID = new int[1] ;
         P007G2_A415VisTipoSigla = new string[] {""} ;
         P007G2_A416VisTipoNome = new string[] {""} ;
         P007G2_A418VisNegID = new Guid[] {Guid.Empty} ;
         P007G2_n418VisNegID = new bool[] {false} ;
         P007G2_A466VisNegCodigo = new long[1] ;
         P007G2_A467VisNegAssunto = new string[] {""} ;
         P007G2_A468VisNegValor = new decimal[1] ;
         P007G2_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         P007G2_A469VisNegCliNomeFamiliar = new string[] {""} ;
         P007G2_n469VisNegCliNomeFamiliar = new bool[] {false} ;
         P007G2_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         P007G2_A470VisNegCpjNomFan = new string[] {""} ;
         P007G2_n470VisNegCpjNomFan = new bool[] {false} ;
         P007G2_A471VisNegCpjRazSocial = new string[] {""} ;
         P007G2_n471VisNegCpjRazSocial = new bool[] {false} ;
         P007G2_A422VisNgfSeq = new int[1] ;
         P007G2_n422VisNgfSeq = new bool[] {false} ;
         P007G2_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         P007G2_A424VisNgfIteNome = new string[] {""} ;
         P007G2_n424VisNgfIteNome = new bool[] {false} ;
         P007G2_A409VisAssunto = new string[] {""} ;
         P007G2_A410VisDescricao = new string[] {""} ;
         P007G2_n410VisDescricao = new bool[] {false} ;
         P007G2_A417VisLink = new string[] {""} ;
         P007G2_n417VisLink = new bool[] {false} ;
         P007G2_A472VisSituacao = new string[] {""} ;
         P007G2_A487VisDel = new bool[] {false} ;
         P007G2_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_n490VisDelDataHora = new bool[] {false} ;
         P007G2_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         P007G2_n488VisDelData = new bool[] {false} ;
         P007G2_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         P007G2_n489VisDelHora = new bool[] {false} ;
         P007G2_A491VisDelUsuID = new string[] {""} ;
         P007G2_n491VisDelUsuID = new bool[] {false} ;
         P007G2_A492VisDelUsuNome = new string[] {""} ;
         P007G2_n492VisDelUsuNome = new bool[] {false} ;
         A398VisID = Guid.Empty;
         A419VisPaiID = Guid.Empty;
         A460VisPaiData = DateTime.MinValue;
         A461VisPaiHora = (DateTime)(DateTime.MinValue);
         A462VisPaiDataHora = (DateTime)(DateTime.MinValue);
         A465VisPaiAssunto = "";
         A399VisInsData = DateTime.MinValue;
         A400VisInsHora = (DateTime)(DateTime.MinValue);
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A402VisInsUsuID = "";
         A403VisInsUsuNome = "";
         A482VisUpdData = DateTime.MinValue;
         A483VisUpdHora = (DateTime)(DateTime.MinValue);
         A484VisUpdDataHora = (DateTime)(DateTime.MinValue);
         A485VisUpdUsuID = "";
         A486VisUpdUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A415VisTipoSigla = "";
         A416VisTipoNome = "";
         A418VisNegID = Guid.Empty;
         A467VisNegAssunto = "";
         A407VisNegCliID = Guid.Empty;
         A469VisNegCliNomeFamiliar = "";
         A408VisNegCpjID = Guid.Empty;
         A470VisNegCpjNomFan = "";
         A471VisNegCpjRazSocial = "";
         A423VisNgfIteID = Guid.Empty;
         A424VisNgfIteNome = "";
         A409VisAssunto = "";
         A410VisDescricao = "";
         A417VisLink = "";
         A472VisSituacao = "";
         A490VisDelDataHora = (DateTime)(DateTime.MinValue);
         A488VisDelData = (DateTime)(DateTime.MinValue);
         A489VisDelHora = (DateTime)(DateTime.MinValue);
         A491VisDelUsuID = "";
         A492VisDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007G3_A398VisID = new Guid[] {Guid.Empty} ;
         P007G3_A419VisPaiID = new Guid[] {Guid.Empty} ;
         P007G3_n419VisPaiID = new bool[] {false} ;
         P007G3_A460VisPaiData = new DateTime[] {DateTime.MinValue} ;
         P007G3_A461VisPaiHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A462VisPaiDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A465VisPaiAssunto = new string[] {""} ;
         P007G3_A399VisInsData = new DateTime[] {DateTime.MinValue} ;
         P007G3_A400VisInsHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A402VisInsUsuID = new string[] {""} ;
         P007G3_n402VisInsUsuID = new bool[] {false} ;
         P007G3_A403VisInsUsuNome = new string[] {""} ;
         P007G3_n403VisInsUsuNome = new bool[] {false} ;
         P007G3_A482VisUpdData = new DateTime[] {DateTime.MinValue} ;
         P007G3_n482VisUpdData = new bool[] {false} ;
         P007G3_A483VisUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_n483VisUpdHora = new bool[] {false} ;
         P007G3_A484VisUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_n484VisUpdDataHora = new bool[] {false} ;
         P007G3_A485VisUpdUsuID = new string[] {""} ;
         P007G3_n485VisUpdUsuID = new bool[] {false} ;
         P007G3_A486VisUpdUsuNome = new string[] {""} ;
         P007G3_n486VisUpdUsuNome = new bool[] {false} ;
         P007G3_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P007G3_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P007G3_n475VisDataFim = new bool[] {false} ;
         P007G3_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P007G3_n476VisHoraFim = new bool[] {false} ;
         P007G3_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P007G3_n477VisDataHoraFim = new bool[] {false} ;
         P007G3_A414VisTipoID = new int[1] ;
         P007G3_A415VisTipoSigla = new string[] {""} ;
         P007G3_A416VisTipoNome = new string[] {""} ;
         P007G3_A418VisNegID = new Guid[] {Guid.Empty} ;
         P007G3_n418VisNegID = new bool[] {false} ;
         P007G3_A466VisNegCodigo = new long[1] ;
         P007G3_A467VisNegAssunto = new string[] {""} ;
         P007G3_A468VisNegValor = new decimal[1] ;
         P007G3_A407VisNegCliID = new Guid[] {Guid.Empty} ;
         P007G3_A469VisNegCliNomeFamiliar = new string[] {""} ;
         P007G3_n469VisNegCliNomeFamiliar = new bool[] {false} ;
         P007G3_A408VisNegCpjID = new Guid[] {Guid.Empty} ;
         P007G3_A470VisNegCpjNomFan = new string[] {""} ;
         P007G3_n470VisNegCpjNomFan = new bool[] {false} ;
         P007G3_A471VisNegCpjRazSocial = new string[] {""} ;
         P007G3_n471VisNegCpjRazSocial = new bool[] {false} ;
         P007G3_A422VisNgfSeq = new int[1] ;
         P007G3_n422VisNgfSeq = new bool[] {false} ;
         P007G3_A423VisNgfIteID = new Guid[] {Guid.Empty} ;
         P007G3_A424VisNgfIteNome = new string[] {""} ;
         P007G3_n424VisNgfIteNome = new bool[] {false} ;
         P007G3_A409VisAssunto = new string[] {""} ;
         P007G3_A410VisDescricao = new string[] {""} ;
         P007G3_n410VisDescricao = new bool[] {false} ;
         P007G3_A417VisLink = new string[] {""} ;
         P007G3_n417VisLink = new bool[] {false} ;
         P007G3_A472VisSituacao = new string[] {""} ;
         P007G3_A487VisDel = new bool[] {false} ;
         P007G3_A490VisDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_n490VisDelDataHora = new bool[] {false} ;
         P007G3_A488VisDelData = new DateTime[] {DateTime.MinValue} ;
         P007G3_n488VisDelData = new bool[] {false} ;
         P007G3_A489VisDelHora = new DateTime[] {DateTime.MinValue} ;
         P007G3_n489VisDelHora = new bool[] {false} ;
         P007G3_A491VisDelUsuID = new string[] {""} ;
         P007G3_n491VisDelUsuID = new bool[] {false} ;
         P007G3_A492VisDelUsuNome = new string[] {""} ;
         P007G3_n492VisDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditvisita__default(),
            new Object[][] {
                new Object[] {
               P007G2_A398VisID, P007G2_A419VisPaiID, P007G2_n419VisPaiID, P007G2_A460VisPaiData, P007G2_A461VisPaiHora, P007G2_A462VisPaiDataHora, P007G2_A465VisPaiAssunto, P007G2_A399VisInsData, P007G2_A400VisInsHora, P007G2_A401VisInsDataHora,
               P007G2_A402VisInsUsuID, P007G2_n402VisInsUsuID, P007G2_A403VisInsUsuNome, P007G2_n403VisInsUsuNome, P007G2_A482VisUpdData, P007G2_n482VisUpdData, P007G2_A483VisUpdHora, P007G2_n483VisUpdHora, P007G2_A484VisUpdDataHora, P007G2_n484VisUpdDataHora,
               P007G2_A485VisUpdUsuID, P007G2_n485VisUpdUsuID, P007G2_A486VisUpdUsuNome, P007G2_n486VisUpdUsuNome, P007G2_A404VisData, P007G2_A405VisHora, P007G2_A406VisDataHora, P007G2_A475VisDataFim, P007G2_n475VisDataFim, P007G2_A476VisHoraFim,
               P007G2_n476VisHoraFim, P007G2_A477VisDataHoraFim, P007G2_n477VisDataHoraFim, P007G2_A414VisTipoID, P007G2_A415VisTipoSigla, P007G2_A416VisTipoNome, P007G2_A418VisNegID, P007G2_n418VisNegID, P007G2_A466VisNegCodigo, P007G2_A467VisNegAssunto,
               P007G2_A468VisNegValor, P007G2_A407VisNegCliID, P007G2_A469VisNegCliNomeFamiliar, P007G2_n469VisNegCliNomeFamiliar, P007G2_A408VisNegCpjID, P007G2_A470VisNegCpjNomFan, P007G2_n470VisNegCpjNomFan, P007G2_A471VisNegCpjRazSocial, P007G2_n471VisNegCpjRazSocial, P007G2_A422VisNgfSeq,
               P007G2_n422VisNgfSeq, P007G2_A423VisNgfIteID, P007G2_A424VisNgfIteNome, P007G2_n424VisNgfIteNome, P007G2_A409VisAssunto, P007G2_A410VisDescricao, P007G2_n410VisDescricao, P007G2_A417VisLink, P007G2_n417VisLink, P007G2_A472VisSituacao,
               P007G2_A487VisDel, P007G2_A490VisDelDataHora, P007G2_n490VisDelDataHora, P007G2_A488VisDelData, P007G2_n488VisDelData, P007G2_A489VisDelHora, P007G2_n489VisDelHora, P007G2_A491VisDelUsuID, P007G2_n491VisDelUsuID, P007G2_A492VisDelUsuNome,
               P007G2_n492VisDelUsuNome
               }
               , new Object[] {
               P007G3_A398VisID, P007G3_A419VisPaiID, P007G3_n419VisPaiID, P007G3_A460VisPaiData, P007G3_A461VisPaiHora, P007G3_A462VisPaiDataHora, P007G3_A465VisPaiAssunto, P007G3_A399VisInsData, P007G3_A400VisInsHora, P007G3_A401VisInsDataHora,
               P007G3_A402VisInsUsuID, P007G3_n402VisInsUsuID, P007G3_A403VisInsUsuNome, P007G3_n403VisInsUsuNome, P007G3_A482VisUpdData, P007G3_n482VisUpdData, P007G3_A483VisUpdHora, P007G3_n483VisUpdHora, P007G3_A484VisUpdDataHora, P007G3_n484VisUpdDataHora,
               P007G3_A485VisUpdUsuID, P007G3_n485VisUpdUsuID, P007G3_A486VisUpdUsuNome, P007G3_n486VisUpdUsuNome, P007G3_A404VisData, P007G3_A405VisHora, P007G3_A406VisDataHora, P007G3_A475VisDataFim, P007G3_n475VisDataFim, P007G3_A476VisHoraFim,
               P007G3_n476VisHoraFim, P007G3_A477VisDataHoraFim, P007G3_n477VisDataHoraFim, P007G3_A414VisTipoID, P007G3_A415VisTipoSigla, P007G3_A416VisTipoNome, P007G3_A418VisNegID, P007G3_n418VisNegID, P007G3_A466VisNegCodigo, P007G3_A467VisNegAssunto,
               P007G3_A468VisNegValor, P007G3_A407VisNegCliID, P007G3_A469VisNegCliNomeFamiliar, P007G3_n469VisNegCliNomeFamiliar, P007G3_A408VisNegCpjID, P007G3_A470VisNegCpjNomFan, P007G3_n470VisNegCpjNomFan, P007G3_A471VisNegCpjRazSocial, P007G3_n471VisNegCpjRazSocial, P007G3_A422VisNgfSeq,
               P007G3_n422VisNgfSeq, P007G3_A423VisNgfIteID, P007G3_A424VisNgfIteNome, P007G3_n424VisNgfIteNome, P007G3_A409VisAssunto, P007G3_A410VisDescricao, P007G3_n410VisDescricao, P007G3_A417VisLink, P007G3_n417VisLink, P007G3_A472VisSituacao,
               P007G3_A487VisDel, P007G3_A490VisDelDataHora, P007G3_n490VisDelDataHora, P007G3_A488VisDelData, P007G3_n488VisDelData, P007G3_A489VisDelHora, P007G3_n489VisDelHora, P007G3_A491VisDelUsuID, P007G3_n491VisDelUsuID, P007G3_A492VisDelUsuNome,
               P007G3_n492VisDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int A414VisTipoID ;
      private int A422VisNgfSeq ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private long A466VisNegCodigo ;
      private decimal A468VisNegValor ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A402VisInsUsuID ;
      private string A485VisUpdUsuID ;
      private string A491VisDelUsuID ;
      private DateTime A461VisPaiHora ;
      private DateTime A462VisPaiDataHora ;
      private DateTime A400VisInsHora ;
      private DateTime A401VisInsDataHora ;
      private DateTime A483VisUpdHora ;
      private DateTime A484VisUpdDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime A490VisDelDataHora ;
      private DateTime A488VisDelData ;
      private DateTime A489VisDelHora ;
      private DateTime A460VisPaiData ;
      private DateTime A399VisInsData ;
      private DateTime A482VisUpdData ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private bool returnInSub ;
      private bool n419VisPaiID ;
      private bool n402VisInsUsuID ;
      private bool n403VisInsUsuNome ;
      private bool n482VisUpdData ;
      private bool n483VisUpdHora ;
      private bool n484VisUpdDataHora ;
      private bool n485VisUpdUsuID ;
      private bool n486VisUpdUsuNome ;
      private bool n475VisDataFim ;
      private bool n476VisHoraFim ;
      private bool n477VisDataHoraFim ;
      private bool n418VisNegID ;
      private bool n469VisNegCliNomeFamiliar ;
      private bool n470VisNegCpjNomFan ;
      private bool n471VisNegCpjRazSocial ;
      private bool n422VisNgfSeq ;
      private bool n424VisNgfIteNome ;
      private bool n410VisDescricao ;
      private bool n417VisLink ;
      private bool A487VisDel ;
      private bool n490VisDelDataHora ;
      private bool n488VisDelData ;
      private bool n489VisDelHora ;
      private bool n491VisDelUsuID ;
      private bool n492VisDelUsuNome ;
      private string A410VisDescricao ;
      private string A465VisPaiAssunto ;
      private string A403VisInsUsuNome ;
      private string A486VisUpdUsuNome ;
      private string A415VisTipoSigla ;
      private string A416VisTipoNome ;
      private string A467VisNegAssunto ;
      private string A469VisNegCliNomeFamiliar ;
      private string A470VisNegCpjNomFan ;
      private string A471VisNegCpjRazSocial ;
      private string A424VisNgfIteNome ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private string A472VisSituacao ;
      private string A492VisDelUsuNome ;
      private Guid AV17VisID ;
      private Guid A398VisID ;
      private Guid A419VisPaiID ;
      private Guid A418VisNegID ;
      private Guid A407VisNegCliID ;
      private Guid A408VisNegCpjID ;
      private Guid A423VisNgfIteID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007G2_A398VisID ;
      private Guid[] P007G2_A419VisPaiID ;
      private bool[] P007G2_n419VisPaiID ;
      private DateTime[] P007G2_A460VisPaiData ;
      private DateTime[] P007G2_A461VisPaiHora ;
      private DateTime[] P007G2_A462VisPaiDataHora ;
      private string[] P007G2_A465VisPaiAssunto ;
      private DateTime[] P007G2_A399VisInsData ;
      private DateTime[] P007G2_A400VisInsHora ;
      private DateTime[] P007G2_A401VisInsDataHora ;
      private string[] P007G2_A402VisInsUsuID ;
      private bool[] P007G2_n402VisInsUsuID ;
      private string[] P007G2_A403VisInsUsuNome ;
      private bool[] P007G2_n403VisInsUsuNome ;
      private DateTime[] P007G2_A482VisUpdData ;
      private bool[] P007G2_n482VisUpdData ;
      private DateTime[] P007G2_A483VisUpdHora ;
      private bool[] P007G2_n483VisUpdHora ;
      private DateTime[] P007G2_A484VisUpdDataHora ;
      private bool[] P007G2_n484VisUpdDataHora ;
      private string[] P007G2_A485VisUpdUsuID ;
      private bool[] P007G2_n485VisUpdUsuID ;
      private string[] P007G2_A486VisUpdUsuNome ;
      private bool[] P007G2_n486VisUpdUsuNome ;
      private DateTime[] P007G2_A404VisData ;
      private DateTime[] P007G2_A405VisHora ;
      private DateTime[] P007G2_A406VisDataHora ;
      private DateTime[] P007G2_A475VisDataFim ;
      private bool[] P007G2_n475VisDataFim ;
      private DateTime[] P007G2_A476VisHoraFim ;
      private bool[] P007G2_n476VisHoraFim ;
      private DateTime[] P007G2_A477VisDataHoraFim ;
      private bool[] P007G2_n477VisDataHoraFim ;
      private int[] P007G2_A414VisTipoID ;
      private string[] P007G2_A415VisTipoSigla ;
      private string[] P007G2_A416VisTipoNome ;
      private Guid[] P007G2_A418VisNegID ;
      private bool[] P007G2_n418VisNegID ;
      private long[] P007G2_A466VisNegCodigo ;
      private string[] P007G2_A467VisNegAssunto ;
      private decimal[] P007G2_A468VisNegValor ;
      private Guid[] P007G2_A407VisNegCliID ;
      private string[] P007G2_A469VisNegCliNomeFamiliar ;
      private bool[] P007G2_n469VisNegCliNomeFamiliar ;
      private Guid[] P007G2_A408VisNegCpjID ;
      private string[] P007G2_A470VisNegCpjNomFan ;
      private bool[] P007G2_n470VisNegCpjNomFan ;
      private string[] P007G2_A471VisNegCpjRazSocial ;
      private bool[] P007G2_n471VisNegCpjRazSocial ;
      private int[] P007G2_A422VisNgfSeq ;
      private bool[] P007G2_n422VisNgfSeq ;
      private Guid[] P007G2_A423VisNgfIteID ;
      private string[] P007G2_A424VisNgfIteNome ;
      private bool[] P007G2_n424VisNgfIteNome ;
      private string[] P007G2_A409VisAssunto ;
      private string[] P007G2_A410VisDescricao ;
      private bool[] P007G2_n410VisDescricao ;
      private string[] P007G2_A417VisLink ;
      private bool[] P007G2_n417VisLink ;
      private string[] P007G2_A472VisSituacao ;
      private bool[] P007G2_A487VisDel ;
      private DateTime[] P007G2_A490VisDelDataHora ;
      private bool[] P007G2_n490VisDelDataHora ;
      private DateTime[] P007G2_A488VisDelData ;
      private bool[] P007G2_n488VisDelData ;
      private DateTime[] P007G2_A489VisDelHora ;
      private bool[] P007G2_n489VisDelHora ;
      private string[] P007G2_A491VisDelUsuID ;
      private bool[] P007G2_n491VisDelUsuID ;
      private string[] P007G2_A492VisDelUsuNome ;
      private bool[] P007G2_n492VisDelUsuNome ;
      private Guid[] P007G3_A398VisID ;
      private Guid[] P007G3_A419VisPaiID ;
      private bool[] P007G3_n419VisPaiID ;
      private DateTime[] P007G3_A460VisPaiData ;
      private DateTime[] P007G3_A461VisPaiHora ;
      private DateTime[] P007G3_A462VisPaiDataHora ;
      private string[] P007G3_A465VisPaiAssunto ;
      private DateTime[] P007G3_A399VisInsData ;
      private DateTime[] P007G3_A400VisInsHora ;
      private DateTime[] P007G3_A401VisInsDataHora ;
      private string[] P007G3_A402VisInsUsuID ;
      private bool[] P007G3_n402VisInsUsuID ;
      private string[] P007G3_A403VisInsUsuNome ;
      private bool[] P007G3_n403VisInsUsuNome ;
      private DateTime[] P007G3_A482VisUpdData ;
      private bool[] P007G3_n482VisUpdData ;
      private DateTime[] P007G3_A483VisUpdHora ;
      private bool[] P007G3_n483VisUpdHora ;
      private DateTime[] P007G3_A484VisUpdDataHora ;
      private bool[] P007G3_n484VisUpdDataHora ;
      private string[] P007G3_A485VisUpdUsuID ;
      private bool[] P007G3_n485VisUpdUsuID ;
      private string[] P007G3_A486VisUpdUsuNome ;
      private bool[] P007G3_n486VisUpdUsuNome ;
      private DateTime[] P007G3_A404VisData ;
      private DateTime[] P007G3_A405VisHora ;
      private DateTime[] P007G3_A406VisDataHora ;
      private DateTime[] P007G3_A475VisDataFim ;
      private bool[] P007G3_n475VisDataFim ;
      private DateTime[] P007G3_A476VisHoraFim ;
      private bool[] P007G3_n476VisHoraFim ;
      private DateTime[] P007G3_A477VisDataHoraFim ;
      private bool[] P007G3_n477VisDataHoraFim ;
      private int[] P007G3_A414VisTipoID ;
      private string[] P007G3_A415VisTipoSigla ;
      private string[] P007G3_A416VisTipoNome ;
      private Guid[] P007G3_A418VisNegID ;
      private bool[] P007G3_n418VisNegID ;
      private long[] P007G3_A466VisNegCodigo ;
      private string[] P007G3_A467VisNegAssunto ;
      private decimal[] P007G3_A468VisNegValor ;
      private Guid[] P007G3_A407VisNegCliID ;
      private string[] P007G3_A469VisNegCliNomeFamiliar ;
      private bool[] P007G3_n469VisNegCliNomeFamiliar ;
      private Guid[] P007G3_A408VisNegCpjID ;
      private string[] P007G3_A470VisNegCpjNomFan ;
      private bool[] P007G3_n470VisNegCpjNomFan ;
      private string[] P007G3_A471VisNegCpjRazSocial ;
      private bool[] P007G3_n471VisNegCpjRazSocial ;
      private int[] P007G3_A422VisNgfSeq ;
      private bool[] P007G3_n422VisNgfSeq ;
      private Guid[] P007G3_A423VisNgfIteID ;
      private string[] P007G3_A424VisNgfIteNome ;
      private bool[] P007G3_n424VisNgfIteNome ;
      private string[] P007G3_A409VisAssunto ;
      private string[] P007G3_A410VisDescricao ;
      private bool[] P007G3_n410VisDescricao ;
      private string[] P007G3_A417VisLink ;
      private bool[] P007G3_n417VisLink ;
      private string[] P007G3_A472VisSituacao ;
      private bool[] P007G3_A487VisDel ;
      private DateTime[] P007G3_A490VisDelDataHora ;
      private bool[] P007G3_n490VisDelDataHora ;
      private DateTime[] P007G3_A488VisDelData ;
      private bool[] P007G3_n488VisDelData ;
      private DateTime[] P007G3_A489VisDelHora ;
      private bool[] P007G3_n489VisDelHora ;
      private string[] P007G3_A491VisDelUsuID ;
      private bool[] P007G3_n491VisDelUsuID ;
      private string[] P007G3_A492VisDelUsuNome ;
      private bool[] P007G3_n492VisDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditvisita__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007G2;
          prmP007G2 = new Object[] {
          new ParDef("AV17VisID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007G3;
          prmP007G3 = new Object[] {
          new ParDef("AV17VisID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007G2", "SELECT T1.VisID, T1.VisPaiID AS VisPaiID, T2.VisData AS VisPaiData, T2.VisHora AS VisPaiHora, T2.VisDataHora AS VisPaiDataHora, T2.VisAssunto AS VisPaiAssunto, T1.VisInsData, T1.VisInsHora, T1.VisInsDataHora, T1.VisInsUsuID, T1.VisInsUsuNome, T1.VisUpdData, T1.VisUpdHora, T1.VisUpdDataHora, T1.VisUpdUsuID, T1.VisUpdUsuNome, T1.VisData, T1.VisHora, T1.VisDataHora, T1.VisDataFim, T1.VisHoraFim, T1.VisDataHoraFim, T1.VisTipoID AS VisTipoID, T3.VitSigla AS VisTipoSigla, T3.VitNome AS VisTipoNome, T1.VisNegID AS VisNegID, T4.NegCodigo AS VisNegCodigo, T4.NegAssunto AS VisNegAssunto, T4.NegValorAtualizado AS VisNegValor, T4.NegCliID AS VisNegCliID, T4.NegCliNomeFamiliar AS VisNegCliNomeFamiliar, T4.NegCpjID AS VisNegCpjID, T4.NegCpjNomFan AS VisNegCpjNomFan, T4.NegCpjRazSocial AS VisNegCpjRazSocial, T1.VisNgfSeq AS VisNgfSeq, T5.NgfIteID AS VisNgfIteID, T5.NgfIteNome AS VisNgfIteNome, T1.VisAssunto, T1.VisDescricao, T1.VisLink, T1.VisSituacao, T1.VisDel, T1.VisDelDataHora, T1.VisDelData, T1.VisDelHora, T1.VisDelUsuID, T1.VisDelUsuNome FROM ((((tb_visita T1 LEFT JOIN tb_visita T2 ON T2.VisID = T1.VisPaiID) INNER JOIN tb_visitatipo T3 ON T3.VitID = T1.VisTipoID) LEFT JOIN tb_negociopj T4 ON T4.NegID = T1.VisNegID) LEFT JOIN tb_negociopj_fase T5 ON T5.NegID = T1.VisNegID AND T5.NgfSeq = T1.VisNgfSeq) WHERE T1.VisID = :AV17VisID ORDER BY T1.VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007G2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007G3", "SELECT T1.VisID, T1.VisPaiID AS VisPaiID, T2.VisData AS VisPaiData, T2.VisHora AS VisPaiHora, T2.VisDataHora AS VisPaiDataHora, T2.VisAssunto AS VisPaiAssunto, T1.VisInsData, T1.VisInsHora, T1.VisInsDataHora, T1.VisInsUsuID, T1.VisInsUsuNome, T1.VisUpdData, T1.VisUpdHora, T1.VisUpdDataHora, T1.VisUpdUsuID, T1.VisUpdUsuNome, T1.VisData, T1.VisHora, T1.VisDataHora, T1.VisDataFim, T1.VisHoraFim, T1.VisDataHoraFim, T1.VisTipoID AS VisTipoID, T3.VitSigla AS VisTipoSigla, T3.VitNome AS VisTipoNome, T1.VisNegID AS VisNegID, T4.NegCodigo AS VisNegCodigo, T4.NegAssunto AS VisNegAssunto, T4.NegValorAtualizado AS VisNegValor, T4.NegCliID AS VisNegCliID, T4.NegCliNomeFamiliar AS VisNegCliNomeFamiliar, T4.NegCpjID AS VisNegCpjID, T4.NegCpjNomFan AS VisNegCpjNomFan, T4.NegCpjRazSocial AS VisNegCpjRazSocial, T1.VisNgfSeq AS VisNgfSeq, T5.NgfIteID AS VisNgfIteID, T5.NgfIteNome AS VisNgfIteNome, T1.VisAssunto, T1.VisDescricao, T1.VisLink, T1.VisSituacao, T1.VisDel, T1.VisDelDataHora, T1.VisDelData, T1.VisDelHora, T1.VisDelUsuID, T1.VisDelUsuNome FROM ((((tb_visita T1 LEFT JOIN tb_visita T2 ON T2.VisID = T1.VisPaiID) INNER JOIN tb_visitatipo T3 ON T3.VitID = T1.VisTipoID) LEFT JOIN tb_negociopj T4 ON T4.NegID = T1.VisNegID) LEFT JOIN tb_negociopj_fase T5 ON T5.NegID = T1.VisNegID AND T5.NgfSeq = T1.VisNgfSeq) WHERE T1.VisID = :AV17VisID ORDER BY T1.VisID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007G3,1, GxCacheFrequency.OFF ,false,true )
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
       switch ( cursor )
       {
             case 0 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(19);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(20);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[31])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[32])[0] = rslt.wasNull(22);
                ((int[]) buf[33])[0] = rslt.getInt(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((string[]) buf[35])[0] = rslt.getVarchar(25);
                ((Guid[]) buf[36])[0] = rslt.getGuid(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((string[]) buf[39])[0] = rslt.getVarchar(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((Guid[]) buf[41])[0] = rslt.getGuid(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((Guid[]) buf[44])[0] = rslt.getGuid(32);
                ((string[]) buf[45])[0] = rslt.getVarchar(33);
                ((bool[]) buf[46])[0] = rslt.wasNull(33);
                ((string[]) buf[47])[0] = rslt.getVarchar(34);
                ((bool[]) buf[48])[0] = rslt.wasNull(34);
                ((int[]) buf[49])[0] = rslt.getInt(35);
                ((bool[]) buf[50])[0] = rslt.wasNull(35);
                ((Guid[]) buf[51])[0] = rslt.getGuid(36);
                ((string[]) buf[52])[0] = rslt.getVarchar(37);
                ((bool[]) buf[53])[0] = rslt.wasNull(37);
                ((string[]) buf[54])[0] = rslt.getVarchar(38);
                ((string[]) buf[55])[0] = rslt.getLongVarchar(39);
                ((bool[]) buf[56])[0] = rslt.wasNull(39);
                ((string[]) buf[57])[0] = rslt.getVarchar(40);
                ((bool[]) buf[58])[0] = rslt.wasNull(40);
                ((string[]) buf[59])[0] = rslt.getVarchar(41);
                ((bool[]) buf[60])[0] = rslt.getBool(42);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(43, true);
                ((bool[]) buf[62])[0] = rslt.wasNull(43);
                ((DateTime[]) buf[63])[0] = rslt.getGXDateTime(44);
                ((bool[]) buf[64])[0] = rslt.wasNull(44);
                ((DateTime[]) buf[65])[0] = rslt.getGXDateTime(45);
                ((bool[]) buf[66])[0] = rslt.wasNull(45);
                ((string[]) buf[67])[0] = rslt.getString(46, 40);
                ((bool[]) buf[68])[0] = rslt.wasNull(46);
                ((string[]) buf[69])[0] = rslt.getVarchar(47);
                ((bool[]) buf[70])[0] = rslt.wasNull(47);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((string[]) buf[12])[0] = rslt.getVarchar(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDate(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((string[]) buf[20])[0] = rslt.getString(15, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(15);
                ((string[]) buf[22])[0] = rslt.getVarchar(16);
                ((bool[]) buf[23])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[24])[0] = rslt.getGXDate(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((DateTime[]) buf[26])[0] = rslt.getGXDateTime(19);
                ((DateTime[]) buf[27])[0] = rslt.getGXDate(20);
                ((bool[]) buf[28])[0] = rslt.wasNull(20);
                ((DateTime[]) buf[29])[0] = rslt.getGXDateTime(21);
                ((bool[]) buf[30])[0] = rslt.wasNull(21);
                ((DateTime[]) buf[31])[0] = rslt.getGXDateTime(22);
                ((bool[]) buf[32])[0] = rslt.wasNull(22);
                ((int[]) buf[33])[0] = rslt.getInt(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((string[]) buf[35])[0] = rslt.getVarchar(25);
                ((Guid[]) buf[36])[0] = rslt.getGuid(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((long[]) buf[38])[0] = rslt.getLong(27);
                ((string[]) buf[39])[0] = rslt.getVarchar(28);
                ((decimal[]) buf[40])[0] = rslt.getDecimal(29);
                ((Guid[]) buf[41])[0] = rslt.getGuid(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((bool[]) buf[43])[0] = rslt.wasNull(31);
                ((Guid[]) buf[44])[0] = rslt.getGuid(32);
                ((string[]) buf[45])[0] = rslt.getVarchar(33);
                ((bool[]) buf[46])[0] = rslt.wasNull(33);
                ((string[]) buf[47])[0] = rslt.getVarchar(34);
                ((bool[]) buf[48])[0] = rslt.wasNull(34);
                ((int[]) buf[49])[0] = rslt.getInt(35);
                ((bool[]) buf[50])[0] = rslt.wasNull(35);
                ((Guid[]) buf[51])[0] = rslt.getGuid(36);
                ((string[]) buf[52])[0] = rslt.getVarchar(37);
                ((bool[]) buf[53])[0] = rslt.wasNull(37);
                ((string[]) buf[54])[0] = rslt.getVarchar(38);
                ((string[]) buf[55])[0] = rslt.getLongVarchar(39);
                ((bool[]) buf[56])[0] = rslt.wasNull(39);
                ((string[]) buf[57])[0] = rslt.getVarchar(40);
                ((bool[]) buf[58])[0] = rslt.wasNull(40);
                ((string[]) buf[59])[0] = rslt.getVarchar(41);
                ((bool[]) buf[60])[0] = rslt.getBool(42);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(43, true);
                ((bool[]) buf[62])[0] = rslt.wasNull(43);
                ((DateTime[]) buf[63])[0] = rslt.getGXDateTime(44);
                ((bool[]) buf[64])[0] = rslt.wasNull(44);
                ((DateTime[]) buf[65])[0] = rslt.getGXDateTime(45);
                ((bool[]) buf[66])[0] = rslt.wasNull(45);
                ((string[]) buf[67])[0] = rslt.getString(46, 40);
                ((bool[]) buf[68])[0] = rslt.wasNull(46);
                ((string[]) buf[69])[0] = rslt.getVarchar(47);
                ((bool[]) buf[70])[0] = rslt.wasNull(47);
                return;
       }
    }

 }

}
