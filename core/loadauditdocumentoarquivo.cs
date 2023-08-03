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
   public class loadauditdocumentoarquivo : GXProcedure
   {
      public loadauditdocumentoarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditdocumentoarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_DocID ,
                           short aP3_DocArqSeq ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17DocID = aP2_DocID;
         this.AV18DocArqSeq = aP3_DocArqSeq;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_DocID ,
                                 short aP3_DocArqSeq ,
                                 string aP4_ActualMode )
      {
         loadauditdocumentoarquivo objloadauditdocumentoarquivo;
         objloadauditdocumentoarquivo = new loadauditdocumentoarquivo();
         objloadauditdocumentoarquivo.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditdocumentoarquivo.AV11AuditingObject = aP1_AuditingObject;
         objloadauditdocumentoarquivo.AV17DocID = aP2_DocID;
         objloadauditdocumentoarquivo.AV18DocArqSeq = aP3_DocArqSeq;
         objloadauditdocumentoarquivo.AV15ActualMode = aP4_ActualMode;
         objloadauditdocumentoarquivo.context.SetSubmitInitialConfig(context);
         objloadauditdocumentoarquivo.initialize();
         Submit( executePrivateCatch,objloadauditdocumentoarquivo);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditdocumentoarquivo)stateInfo).executePrivate();
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
         /* Using cursor P007J2 */
         pr_default.execute(0, new Object[] {AV17DocID, AV18DocArqSeq});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A307DocArqSeq = P007J2_A307DocArqSeq[0];
            A289DocID = P007J2_A289DocID[0];
            A306DocUltArqSeq = P007J2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007J2_n306DocUltArqSeq[0];
            A325DocVersao = P007J2_A325DocVersao[0];
            A326DocVersaoIDPai = P007J2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007J2_n326DocVersaoIDPai[0];
            A308DocArqInsData = P007J2_A308DocArqInsData[0];
            A309DocArqInsHora = P007J2_A309DocArqInsHora[0];
            A310DocArqInsDataHora = P007J2_A310DocArqInsDataHora[0];
            A311DocArqInsUsuID = P007J2_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = P007J2_n311DocArqInsUsuID[0];
            A312DocArqUpdData = P007J2_A312DocArqUpdData[0];
            n312DocArqUpdData = P007J2_n312DocArqUpdData[0];
            A313DocArqUpdHora = P007J2_A313DocArqUpdHora[0];
            n313DocArqUpdHora = P007J2_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = P007J2_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = P007J2_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = P007J2_A315DocArqUsuID[0];
            n315DocArqUsuID = P007J2_n315DocArqUsuID[0];
            A316DocArqDel = P007J2_A316DocArqDel[0];
            A319DocArqDelDataHora = P007J2_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = P007J2_n319DocArqDelDataHora[0];
            A317DocArqDelData = P007J2_A317DocArqDelData[0];
            n317DocArqDelData = P007J2_n317DocArqDelData[0];
            A511DocArqDelHora = P007J2_A511DocArqDelHora[0];
            n511DocArqDelHora = P007J2_n511DocArqDelHora[0];
            A320DocArqDelUsuID = P007J2_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = P007J2_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = P007J2_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = P007J2_n509DocArqDelUsuNome[0];
            A322DocArqConteudoNome = P007J2_A322DocArqConteudoNome[0];
            A323DocArqConteudoExtensao = P007J2_A323DocArqConteudoExtensao[0];
            A324DocArqObservacao = P007J2_A324DocArqObservacao[0];
            n324DocArqObservacao = P007J2_n324DocArqObservacao[0];
            A644DocArqArmExterno = P007J2_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = P007J2_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = P007J2_n645DocArqArmExternoPath[0];
            A306DocUltArqSeq = P007J2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007J2_n306DocUltArqSeq[0];
            A325DocVersao = P007J2_A325DocVersao[0];
            A326DocVersaoIDPai = P007J2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007J2_n326DocVersaoIDPai[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento_arquivo";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A289DocID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUltArqSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A325DocVersao), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersaoIDPai";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Documento Original";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A326DocVersaoIDPai.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A307DocArqSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A308DocArqInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A311DocArqInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A312DocArqUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A313DocArqUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Ultima Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A315DocArqUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A316DocArqDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A511DocArqDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A320DocArqDelUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A509DocArqDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Arquivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A322DocArqConteudoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoExtensao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Extensão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A323DocArqConteudoExtensao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqObservacao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Observações";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A324DocArqObservacao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExterno";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Armazenamento Externo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExternoPath";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Local do Arquivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A645DocArqArmExternoPath;
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
         /* Using cursor P007J3 */
         pr_default.execute(1, new Object[] {AV17DocID, AV18DocArqSeq});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A307DocArqSeq = P007J3_A307DocArqSeq[0];
            A289DocID = P007J3_A289DocID[0];
            A306DocUltArqSeq = P007J3_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007J3_n306DocUltArqSeq[0];
            A325DocVersao = P007J3_A325DocVersao[0];
            A326DocVersaoIDPai = P007J3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007J3_n326DocVersaoIDPai[0];
            A308DocArqInsData = P007J3_A308DocArqInsData[0];
            A309DocArqInsHora = P007J3_A309DocArqInsHora[0];
            A310DocArqInsDataHora = P007J3_A310DocArqInsDataHora[0];
            A311DocArqInsUsuID = P007J3_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = P007J3_n311DocArqInsUsuID[0];
            A312DocArqUpdData = P007J3_A312DocArqUpdData[0];
            n312DocArqUpdData = P007J3_n312DocArqUpdData[0];
            A313DocArqUpdHora = P007J3_A313DocArqUpdHora[0];
            n313DocArqUpdHora = P007J3_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = P007J3_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = P007J3_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = P007J3_A315DocArqUsuID[0];
            n315DocArqUsuID = P007J3_n315DocArqUsuID[0];
            A316DocArqDel = P007J3_A316DocArqDel[0];
            A319DocArqDelDataHora = P007J3_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = P007J3_n319DocArqDelDataHora[0];
            A317DocArqDelData = P007J3_A317DocArqDelData[0];
            n317DocArqDelData = P007J3_n317DocArqDelData[0];
            A511DocArqDelHora = P007J3_A511DocArqDelHora[0];
            n511DocArqDelHora = P007J3_n511DocArqDelHora[0];
            A320DocArqDelUsuID = P007J3_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = P007J3_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = P007J3_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = P007J3_n509DocArqDelUsuNome[0];
            A322DocArqConteudoNome = P007J3_A322DocArqConteudoNome[0];
            A323DocArqConteudoExtensao = P007J3_A323DocArqConteudoExtensao[0];
            A324DocArqObservacao = P007J3_A324DocArqObservacao[0];
            n324DocArqObservacao = P007J3_n324DocArqObservacao[0];
            A644DocArqArmExterno = P007J3_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = P007J3_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = P007J3_n645DocArqArmExternoPath[0];
            A306DocUltArqSeq = P007J3_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007J3_n306DocUltArqSeq[0];
            A325DocVersao = P007J3_A325DocVersao[0];
            A326DocVersaoIDPai = P007J3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007J3_n326DocVersaoIDPai[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento_arquivo";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A289DocID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUltArqSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A325DocVersao), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersaoIDPai";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Documento Original";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A326DocVersaoIDPai.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A307DocArqSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A308DocArqInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A311DocArqInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A312DocArqUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A313DocArqUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Ultima Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A315DocArqUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A316DocArqDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A511DocArqDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A320DocArqDelUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A509DocArqDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Arquivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A322DocArqConteudoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoExtensao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Extensão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A323DocArqConteudoExtensao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqObservacao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Observações";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A324DocArqObservacao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExterno";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Armazenamento Externo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExternoPath";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Local do Arquivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A645DocArqArmExternoPath;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV21GXV1 = 1;
               while ( AV21GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV21GXV1));
                  AV22GXV2 = 1;
                  while ( AV22GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV22GXV2));
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A289DocID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUltArqSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocVersao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A325DocVersao), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocVersaoIDPai") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A326DocVersaoIDPai.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A307DocArqSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A308DocArqInsData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqInsUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A311DocArqInsUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A312DocArqUpdData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A313DocArqUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A315DocArqUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A316DocArqDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A511DocArqDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A320DocArqDelUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A509DocArqDelUsuNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqConteudoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A322DocArqConteudoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqConteudoExtensao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A323DocArqConteudoExtensao;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqObservacao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A324DocArqObservacao;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqArmExterno") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqArmExternoPath") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A645DocArqArmExternoPath;
                     }
                     AV22GXV2 = (int)(AV22GXV2+1);
                  }
                  AV21GXV1 = (int)(AV21GXV1+1);
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
         P007J2_A307DocArqSeq = new short[1] ;
         P007J2_A289DocID = new Guid[] {Guid.Empty} ;
         P007J2_A306DocUltArqSeq = new short[1] ;
         P007J2_n306DocUltArqSeq = new bool[] {false} ;
         P007J2_A325DocVersao = new short[1] ;
         P007J2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007J2_n326DocVersaoIDPai = new bool[] {false} ;
         P007J2_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007J2_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_A311DocArqInsUsuID = new string[] {""} ;
         P007J2_n311DocArqInsUsuID = new bool[] {false} ;
         P007J2_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007J2_n312DocArqUpdData = new bool[] {false} ;
         P007J2_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_n313DocArqUpdHora = new bool[] {false} ;
         P007J2_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_n314DocArqUpdDataHora = new bool[] {false} ;
         P007J2_A315DocArqUsuID = new string[] {""} ;
         P007J2_n315DocArqUsuID = new bool[] {false} ;
         P007J2_A316DocArqDel = new bool[] {false} ;
         P007J2_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_n319DocArqDelDataHora = new bool[] {false} ;
         P007J2_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007J2_n317DocArqDelData = new bool[] {false} ;
         P007J2_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         P007J2_n511DocArqDelHora = new bool[] {false} ;
         P007J2_A320DocArqDelUsuID = new string[] {""} ;
         P007J2_n320DocArqDelUsuID = new bool[] {false} ;
         P007J2_A509DocArqDelUsuNome = new string[] {""} ;
         P007J2_n509DocArqDelUsuNome = new bool[] {false} ;
         P007J2_A322DocArqConteudoNome = new string[] {""} ;
         P007J2_A323DocArqConteudoExtensao = new string[] {""} ;
         P007J2_A324DocArqObservacao = new string[] {""} ;
         P007J2_n324DocArqObservacao = new bool[] {false} ;
         P007J2_A644DocArqArmExterno = new bool[] {false} ;
         P007J2_A645DocArqArmExternoPath = new string[] {""} ;
         P007J2_n645DocArqArmExternoPath = new bool[] {false} ;
         A289DocID = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         A308DocArqInsData = DateTime.MinValue;
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A311DocArqInsUsuID = "";
         A312DocArqUpdData = DateTime.MinValue;
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A315DocArqUsuID = "";
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         A511DocArqDelHora = (DateTime)(DateTime.MinValue);
         A320DocArqDelUsuID = "";
         A509DocArqDelUsuNome = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A645DocArqArmExternoPath = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007J3_A307DocArqSeq = new short[1] ;
         P007J3_A289DocID = new Guid[] {Guid.Empty} ;
         P007J3_A306DocUltArqSeq = new short[1] ;
         P007J3_n306DocUltArqSeq = new bool[] {false} ;
         P007J3_A325DocVersao = new short[1] ;
         P007J3_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007J3_n326DocVersaoIDPai = new bool[] {false} ;
         P007J3_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007J3_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_A311DocArqInsUsuID = new string[] {""} ;
         P007J3_n311DocArqInsUsuID = new bool[] {false} ;
         P007J3_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007J3_n312DocArqUpdData = new bool[] {false} ;
         P007J3_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_n313DocArqUpdHora = new bool[] {false} ;
         P007J3_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_n314DocArqUpdDataHora = new bool[] {false} ;
         P007J3_A315DocArqUsuID = new string[] {""} ;
         P007J3_n315DocArqUsuID = new bool[] {false} ;
         P007J3_A316DocArqDel = new bool[] {false} ;
         P007J3_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_n319DocArqDelDataHora = new bool[] {false} ;
         P007J3_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007J3_n317DocArqDelData = new bool[] {false} ;
         P007J3_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         P007J3_n511DocArqDelHora = new bool[] {false} ;
         P007J3_A320DocArqDelUsuID = new string[] {""} ;
         P007J3_n320DocArqDelUsuID = new bool[] {false} ;
         P007J3_A509DocArqDelUsuNome = new string[] {""} ;
         P007J3_n509DocArqDelUsuNome = new bool[] {false} ;
         P007J3_A322DocArqConteudoNome = new string[] {""} ;
         P007J3_A323DocArqConteudoExtensao = new string[] {""} ;
         P007J3_A324DocArqObservacao = new string[] {""} ;
         P007J3_n324DocArqObservacao = new bool[] {false} ;
         P007J3_A644DocArqArmExterno = new bool[] {false} ;
         P007J3_A645DocArqArmExternoPath = new string[] {""} ;
         P007J3_n645DocArqArmExternoPath = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditdocumentoarquivo__default(),
            new Object[][] {
                new Object[] {
               P007J2_A307DocArqSeq, P007J2_A289DocID, P007J2_A306DocUltArqSeq, P007J2_n306DocUltArqSeq, P007J2_A325DocVersao, P007J2_A326DocVersaoIDPai, P007J2_n326DocVersaoIDPai, P007J2_A308DocArqInsData, P007J2_A309DocArqInsHora, P007J2_A310DocArqInsDataHora,
               P007J2_A311DocArqInsUsuID, P007J2_n311DocArqInsUsuID, P007J2_A312DocArqUpdData, P007J2_n312DocArqUpdData, P007J2_A313DocArqUpdHora, P007J2_n313DocArqUpdHora, P007J2_A314DocArqUpdDataHora, P007J2_n314DocArqUpdDataHora, P007J2_A315DocArqUsuID, P007J2_n315DocArqUsuID,
               P007J2_A316DocArqDel, P007J2_A319DocArqDelDataHora, P007J2_n319DocArqDelDataHora, P007J2_A317DocArqDelData, P007J2_n317DocArqDelData, P007J2_A511DocArqDelHora, P007J2_n511DocArqDelHora, P007J2_A320DocArqDelUsuID, P007J2_n320DocArqDelUsuID, P007J2_A509DocArqDelUsuNome,
               P007J2_n509DocArqDelUsuNome, P007J2_A322DocArqConteudoNome, P007J2_A323DocArqConteudoExtensao, P007J2_A324DocArqObservacao, P007J2_n324DocArqObservacao, P007J2_A644DocArqArmExterno, P007J2_A645DocArqArmExternoPath, P007J2_n645DocArqArmExternoPath
               }
               , new Object[] {
               P007J3_A307DocArqSeq, P007J3_A289DocID, P007J3_A306DocUltArqSeq, P007J3_n306DocUltArqSeq, P007J3_A325DocVersao, P007J3_A326DocVersaoIDPai, P007J3_n326DocVersaoIDPai, P007J3_A308DocArqInsData, P007J3_A309DocArqInsHora, P007J3_A310DocArqInsDataHora,
               P007J3_A311DocArqInsUsuID, P007J3_n311DocArqInsUsuID, P007J3_A312DocArqUpdData, P007J3_n312DocArqUpdData, P007J3_A313DocArqUpdHora, P007J3_n313DocArqUpdHora, P007J3_A314DocArqUpdDataHora, P007J3_n314DocArqUpdDataHora, P007J3_A315DocArqUsuID, P007J3_n315DocArqUsuID,
               P007J3_A316DocArqDel, P007J3_A319DocArqDelDataHora, P007J3_n319DocArqDelDataHora, P007J3_A317DocArqDelData, P007J3_n317DocArqDelData, P007J3_A511DocArqDelHora, P007J3_n511DocArqDelHora, P007J3_A320DocArqDelUsuID, P007J3_n320DocArqDelUsuID, P007J3_A509DocArqDelUsuNome,
               P007J3_n509DocArqDelUsuNome, P007J3_A322DocArqConteudoNome, P007J3_A323DocArqConteudoExtensao, P007J3_A324DocArqObservacao, P007J3_n324DocArqObservacao, P007J3_A644DocArqArmExterno, P007J3_A645DocArqArmExternoPath, P007J3_n645DocArqArmExternoPath
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV18DocArqSeq ;
      private short A307DocArqSeq ;
      private short A306DocUltArqSeq ;
      private short A325DocVersao ;
      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A311DocArqInsUsuID ;
      private string A315DocArqUsuID ;
      private string A320DocArqDelUsuID ;
      private DateTime A309DocArqInsHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime A317DocArqDelData ;
      private DateTime A511DocArqDelHora ;
      private DateTime A308DocArqInsData ;
      private DateTime A312DocArqUpdData ;
      private bool returnInSub ;
      private bool n306DocUltArqSeq ;
      private bool n326DocVersaoIDPai ;
      private bool n311DocArqInsUsuID ;
      private bool n312DocArqUpdData ;
      private bool n313DocArqUpdHora ;
      private bool n314DocArqUpdDataHora ;
      private bool n315DocArqUsuID ;
      private bool A316DocArqDel ;
      private bool n319DocArqDelDataHora ;
      private bool n317DocArqDelData ;
      private bool n511DocArqDelHora ;
      private bool n320DocArqDelUsuID ;
      private bool n509DocArqDelUsuNome ;
      private bool n324DocArqObservacao ;
      private bool A644DocArqArmExterno ;
      private bool n645DocArqArmExternoPath ;
      private string A509DocArqDelUsuNome ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string A645DocArqArmExternoPath ;
      private Guid AV17DocID ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private short[] P007J2_A307DocArqSeq ;
      private Guid[] P007J2_A289DocID ;
      private short[] P007J2_A306DocUltArqSeq ;
      private bool[] P007J2_n306DocUltArqSeq ;
      private short[] P007J2_A325DocVersao ;
      private Guid[] P007J2_A326DocVersaoIDPai ;
      private bool[] P007J2_n326DocVersaoIDPai ;
      private DateTime[] P007J2_A308DocArqInsData ;
      private DateTime[] P007J2_A309DocArqInsHora ;
      private DateTime[] P007J2_A310DocArqInsDataHora ;
      private string[] P007J2_A311DocArqInsUsuID ;
      private bool[] P007J2_n311DocArqInsUsuID ;
      private DateTime[] P007J2_A312DocArqUpdData ;
      private bool[] P007J2_n312DocArqUpdData ;
      private DateTime[] P007J2_A313DocArqUpdHora ;
      private bool[] P007J2_n313DocArqUpdHora ;
      private DateTime[] P007J2_A314DocArqUpdDataHora ;
      private bool[] P007J2_n314DocArqUpdDataHora ;
      private string[] P007J2_A315DocArqUsuID ;
      private bool[] P007J2_n315DocArqUsuID ;
      private bool[] P007J2_A316DocArqDel ;
      private DateTime[] P007J2_A319DocArqDelDataHora ;
      private bool[] P007J2_n319DocArqDelDataHora ;
      private DateTime[] P007J2_A317DocArqDelData ;
      private bool[] P007J2_n317DocArqDelData ;
      private DateTime[] P007J2_A511DocArqDelHora ;
      private bool[] P007J2_n511DocArqDelHora ;
      private string[] P007J2_A320DocArqDelUsuID ;
      private bool[] P007J2_n320DocArqDelUsuID ;
      private string[] P007J2_A509DocArqDelUsuNome ;
      private bool[] P007J2_n509DocArqDelUsuNome ;
      private string[] P007J2_A322DocArqConteudoNome ;
      private string[] P007J2_A323DocArqConteudoExtensao ;
      private string[] P007J2_A324DocArqObservacao ;
      private bool[] P007J2_n324DocArqObservacao ;
      private bool[] P007J2_A644DocArqArmExterno ;
      private string[] P007J2_A645DocArqArmExternoPath ;
      private bool[] P007J2_n645DocArqArmExternoPath ;
      private short[] P007J3_A307DocArqSeq ;
      private Guid[] P007J3_A289DocID ;
      private short[] P007J3_A306DocUltArqSeq ;
      private bool[] P007J3_n306DocUltArqSeq ;
      private short[] P007J3_A325DocVersao ;
      private Guid[] P007J3_A326DocVersaoIDPai ;
      private bool[] P007J3_n326DocVersaoIDPai ;
      private DateTime[] P007J3_A308DocArqInsData ;
      private DateTime[] P007J3_A309DocArqInsHora ;
      private DateTime[] P007J3_A310DocArqInsDataHora ;
      private string[] P007J3_A311DocArqInsUsuID ;
      private bool[] P007J3_n311DocArqInsUsuID ;
      private DateTime[] P007J3_A312DocArqUpdData ;
      private bool[] P007J3_n312DocArqUpdData ;
      private DateTime[] P007J3_A313DocArqUpdHora ;
      private bool[] P007J3_n313DocArqUpdHora ;
      private DateTime[] P007J3_A314DocArqUpdDataHora ;
      private bool[] P007J3_n314DocArqUpdDataHora ;
      private string[] P007J3_A315DocArqUsuID ;
      private bool[] P007J3_n315DocArqUsuID ;
      private bool[] P007J3_A316DocArqDel ;
      private DateTime[] P007J3_A319DocArqDelDataHora ;
      private bool[] P007J3_n319DocArqDelDataHora ;
      private DateTime[] P007J3_A317DocArqDelData ;
      private bool[] P007J3_n317DocArqDelData ;
      private DateTime[] P007J3_A511DocArqDelHora ;
      private bool[] P007J3_n511DocArqDelHora ;
      private string[] P007J3_A320DocArqDelUsuID ;
      private bool[] P007J3_n320DocArqDelUsuID ;
      private string[] P007J3_A509DocArqDelUsuNome ;
      private bool[] P007J3_n509DocArqDelUsuNome ;
      private string[] P007J3_A322DocArqConteudoNome ;
      private string[] P007J3_A323DocArqConteudoExtensao ;
      private string[] P007J3_A324DocArqObservacao ;
      private bool[] P007J3_n324DocArqObservacao ;
      private bool[] P007J3_A644DocArqArmExterno ;
      private string[] P007J3_A645DocArqArmExternoPath ;
      private bool[] P007J3_n645DocArqArmExternoPath ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditdocumentoarquivo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007J2;
          prmP007J2 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18DocArqSeq",GXType.Int16,4,0)
          };
          Object[] prmP007J3;
          prmP007J3 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18DocArqSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007J2", "SELECT T1.DocArqSeq, T1.DocID, T2.DocUltArqSeq, T2.DocVersao, T2.DocVersaoIDPai, T1.DocArqInsData, T1.DocArqInsHora, T1.DocArqInsDataHora, T1.DocArqInsUsuID, T1.DocArqUpdData, T1.DocArqUpdHora, T1.DocArqUpdDataHora, T1.DocArqUsuID, T1.DocArqDel, T1.DocArqDelDataHora, T1.DocArqDelData, T1.DocArqDelHora, T1.DocArqDelUsuID, T1.DocArqDelUsuNome, T1.DocArqConteudoNome, T1.DocArqConteudoExtensao, T1.DocArqObservacao, T1.DocArqArmExterno, T1.DocArqArmExternoPath FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID) WHERE T1.DocID = :AV17DocID and T1.DocArqSeq = :AV18DocArqSeq ORDER BY T1.DocID, T1.DocArqSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007J3", "SELECT T1.DocArqSeq, T1.DocID, T2.DocUltArqSeq, T2.DocVersao, T2.DocVersaoIDPai, T1.DocArqInsData, T1.DocArqInsHora, T1.DocArqInsDataHora, T1.DocArqInsUsuID, T1.DocArqUpdData, T1.DocArqUpdHora, T1.DocArqUpdDataHora, T1.DocArqUsuID, T1.DocArqDel, T1.DocArqDelDataHora, T1.DocArqDelData, T1.DocArqDelHora, T1.DocArqDelUsuID, T1.DocArqDelUsuNome, T1.DocArqConteudoNome, T1.DocArqConteudoExtensao, T1.DocArqObservacao, T1.DocArqArmExterno, T1.DocArqArmExternoPath FROM (tb_documento_arquivo T1 INNER JOIN tb_documento T2 ON T2.DocID = T1.DocID) WHERE T1.DocID = :AV17DocID and T1.DocArqSeq = :AV18DocArqSeq ORDER BY T1.DocID, T1.DocArqSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007J3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
                ((string[]) buf[10])[0] = rslt.getString(9, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((bool[]) buf[20])[0] = rslt.getBool(14);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(15, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((string[]) buf[27])[0] = rslt.getString(18, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((string[]) buf[29])[0] = rslt.getVarchar(19);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((string[]) buf[31])[0] = rslt.getVarchar(20);
                ((string[]) buf[32])[0] = rslt.getVarchar(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
                ((bool[]) buf[35])[0] = rslt.getBool(23);
                ((string[]) buf[36])[0] = rslt.getVarchar(24);
                ((bool[]) buf[37])[0] = rslt.wasNull(24);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((short[]) buf[2])[0] = rslt.getShort(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((short[]) buf[4])[0] = rslt.getShort(4);
                ((Guid[]) buf[5])[0] = rslt.getGuid(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(6);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8, true);
                ((string[]) buf[10])[0] = rslt.getString(9, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getString(13, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((bool[]) buf[20])[0] = rslt.getBool(14);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(15, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(15);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[24])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[26])[0] = rslt.wasNull(17);
                ((string[]) buf[27])[0] = rslt.getString(18, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(18);
                ((string[]) buf[29])[0] = rslt.getVarchar(19);
                ((bool[]) buf[30])[0] = rslt.wasNull(19);
                ((string[]) buf[31])[0] = rslt.getVarchar(20);
                ((string[]) buf[32])[0] = rslt.getVarchar(21);
                ((string[]) buf[33])[0] = rslt.getVarchar(22);
                ((bool[]) buf[34])[0] = rslt.wasNull(22);
                ((bool[]) buf[35])[0] = rslt.getBool(23);
                ((string[]) buf[36])[0] = rslt.getVarchar(24);
                ((bool[]) buf[37])[0] = rslt.wasNull(24);
                return;
       }
    }

 }

}
