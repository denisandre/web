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
   public class loadauditparametros : GXProcedure
   {
      public loadauditparametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditparametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           string aP2_ParametroChave ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17ParametroChave = aP2_ParametroChave;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 string aP2_ParametroChave ,
                                 string aP3_ActualMode )
      {
         loadauditparametros objloadauditparametros;
         objloadauditparametros = new loadauditparametros();
         objloadauditparametros.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditparametros.AV11AuditingObject = aP1_AuditingObject;
         objloadauditparametros.AV17ParametroChave = aP2_ParametroChave;
         objloadauditparametros.AV15ActualMode = aP3_ActualMode;
         objloadauditparametros.context.SetSubmitInitialConfig(context);
         objloadauditparametros.initialize();
         Submit( executePrivateCatch,objloadauditparametros);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditparametros)stateInfo).executePrivate();
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
         /* Using cursor P00762 */
         pr_default.execute(0, new Object[] {AV17ParametroChave});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A342ParametroChave = P00762_A342ParametroChave[0];
            A344ParametroDescricao = P00762_A344ParametroDescricao[0];
            n344ParametroDescricao = P00762_n344ParametroDescricao[0];
            A343ParametroValor = P00762_A343ParametroValor[0];
            n343ParametroValor = P00762_n343ParametroValor[0];
            A518ParametroDel = P00762_A518ParametroDel[0];
            A519ParametroDelDataHora = P00762_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = P00762_n519ParametroDelDataHora[0];
            A520ParametroDelData = P00762_A520ParametroDelData[0];
            n520ParametroDelData = P00762_n520ParametroDelData[0];
            A521ParametroDelHora = P00762_A521ParametroDelHora[0];
            n521ParametroDelHora = P00762_n521ParametroDelHora[0];
            A522ParametroDelUsuId = P00762_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = P00762_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = P00762_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = P00762_n523ParametroDelUsuNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_parametro";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroChave";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Chave";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A342ParametroChave;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDescricao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A344ParametroDescricao;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroValor";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A343ParametroValor;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A518ParametroDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A520ParametroDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A521ParametroDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A522ParametroDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A523ParametroDelUsuNome;
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
         /* Using cursor P00763 */
         pr_default.execute(1, new Object[] {AV17ParametroChave});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A342ParametroChave = P00763_A342ParametroChave[0];
            A344ParametroDescricao = P00763_A344ParametroDescricao[0];
            n344ParametroDescricao = P00763_n344ParametroDescricao[0];
            A343ParametroValor = P00763_A343ParametroValor[0];
            n343ParametroValor = P00763_n343ParametroValor[0];
            A518ParametroDel = P00763_A518ParametroDel[0];
            A519ParametroDelDataHora = P00763_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = P00763_n519ParametroDelDataHora[0];
            A520ParametroDelData = P00763_A520ParametroDelData[0];
            n520ParametroDelData = P00763_n520ParametroDelData[0];
            A521ParametroDelHora = P00763_A521ParametroDelHora[0];
            n521ParametroDelHora = P00763_n521ParametroDelHora[0];
            A522ParametroDelUsuId = P00763_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = P00763_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = P00763_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = P00763_n523ParametroDelUsuNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_parametro";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroChave";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Chave";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A342ParametroChave;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDescricao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A344ParametroDescricao;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroValor";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Valor";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A343ParametroValor;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A518ParametroDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A520ParametroDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A521ParametroDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A522ParametroDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "ParametroDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A523ParametroDelUsuNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroChave") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A342ParametroChave;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDescricao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A344ParametroDescricao;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroValor") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A343ParametroValor;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A518ParametroDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A520ParametroDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A521ParametroDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A522ParametroDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "ParametroDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A523ParametroDelUsuNome;
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
         P00762_A342ParametroChave = new string[] {""} ;
         P00762_A344ParametroDescricao = new string[] {""} ;
         P00762_n344ParametroDescricao = new bool[] {false} ;
         P00762_A343ParametroValor = new string[] {""} ;
         P00762_n343ParametroValor = new bool[] {false} ;
         P00762_A518ParametroDel = new bool[] {false} ;
         P00762_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00762_n519ParametroDelDataHora = new bool[] {false} ;
         P00762_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         P00762_n520ParametroDelData = new bool[] {false} ;
         P00762_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         P00762_n521ParametroDelHora = new bool[] {false} ;
         P00762_A522ParametroDelUsuId = new string[] {""} ;
         P00762_n522ParametroDelUsuId = new bool[] {false} ;
         P00762_A523ParametroDelUsuNome = new string[] {""} ;
         P00762_n523ParametroDelUsuNome = new bool[] {false} ;
         A342ParametroChave = "";
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         A522ParametroDelUsuId = "";
         A523ParametroDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00763_A342ParametroChave = new string[] {""} ;
         P00763_A344ParametroDescricao = new string[] {""} ;
         P00763_n344ParametroDescricao = new bool[] {false} ;
         P00763_A343ParametroValor = new string[] {""} ;
         P00763_n343ParametroValor = new bool[] {false} ;
         P00763_A518ParametroDel = new bool[] {false} ;
         P00763_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00763_n519ParametroDelDataHora = new bool[] {false} ;
         P00763_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         P00763_n520ParametroDelData = new bool[] {false} ;
         P00763_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         P00763_n521ParametroDelHora = new bool[] {false} ;
         P00763_A522ParametroDelUsuId = new string[] {""} ;
         P00763_n522ParametroDelUsuId = new bool[] {false} ;
         P00763_A523ParametroDelUsuNome = new string[] {""} ;
         P00763_n523ParametroDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditparametros__default(),
            new Object[][] {
                new Object[] {
               P00762_A342ParametroChave, P00762_A344ParametroDescricao, P00762_n344ParametroDescricao, P00762_A343ParametroValor, P00762_n343ParametroValor, P00762_A518ParametroDel, P00762_A519ParametroDelDataHora, P00762_n519ParametroDelDataHora, P00762_A520ParametroDelData, P00762_n520ParametroDelData,
               P00762_A521ParametroDelHora, P00762_n521ParametroDelHora, P00762_A522ParametroDelUsuId, P00762_n522ParametroDelUsuId, P00762_A523ParametroDelUsuNome, P00762_n523ParametroDelUsuNome
               }
               , new Object[] {
               P00763_A342ParametroChave, P00763_A344ParametroDescricao, P00763_n344ParametroDescricao, P00763_A343ParametroValor, P00763_n343ParametroValor, P00763_A518ParametroDel, P00763_A519ParametroDelDataHora, P00763_n519ParametroDelDataHora, P00763_A520ParametroDelData, P00763_n520ParametroDelData,
               P00763_A521ParametroDelHora, P00763_n521ParametroDelHora, P00763_A522ParametroDelUsuId, P00763_n522ParametroDelUsuId, P00763_A523ParametroDelUsuNome, P00763_n523ParametroDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A522ParametroDelUsuId ;
      private DateTime A519ParametroDelDataHora ;
      private DateTime A520ParametroDelData ;
      private DateTime A521ParametroDelHora ;
      private bool returnInSub ;
      private bool n344ParametroDescricao ;
      private bool n343ParametroValor ;
      private bool A518ParametroDel ;
      private bool n519ParametroDelDataHora ;
      private bool n520ParametroDelData ;
      private bool n521ParametroDelHora ;
      private bool n522ParametroDelUsuId ;
      private bool n523ParametroDelUsuNome ;
      private string AV17ParametroChave ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private string A523ParametroDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private string[] P00762_A342ParametroChave ;
      private string[] P00762_A344ParametroDescricao ;
      private bool[] P00762_n344ParametroDescricao ;
      private string[] P00762_A343ParametroValor ;
      private bool[] P00762_n343ParametroValor ;
      private bool[] P00762_A518ParametroDel ;
      private DateTime[] P00762_A519ParametroDelDataHora ;
      private bool[] P00762_n519ParametroDelDataHora ;
      private DateTime[] P00762_A520ParametroDelData ;
      private bool[] P00762_n520ParametroDelData ;
      private DateTime[] P00762_A521ParametroDelHora ;
      private bool[] P00762_n521ParametroDelHora ;
      private string[] P00762_A522ParametroDelUsuId ;
      private bool[] P00762_n522ParametroDelUsuId ;
      private string[] P00762_A523ParametroDelUsuNome ;
      private bool[] P00762_n523ParametroDelUsuNome ;
      private string[] P00763_A342ParametroChave ;
      private string[] P00763_A344ParametroDescricao ;
      private bool[] P00763_n344ParametroDescricao ;
      private string[] P00763_A343ParametroValor ;
      private bool[] P00763_n343ParametroValor ;
      private bool[] P00763_A518ParametroDel ;
      private DateTime[] P00763_A519ParametroDelDataHora ;
      private bool[] P00763_n519ParametroDelDataHora ;
      private DateTime[] P00763_A520ParametroDelData ;
      private bool[] P00763_n520ParametroDelData ;
      private DateTime[] P00763_A521ParametroDelHora ;
      private bool[] P00763_n521ParametroDelHora ;
      private string[] P00763_A522ParametroDelUsuId ;
      private bool[] P00763_n522ParametroDelUsuId ;
      private string[] P00763_A523ParametroDelUsuNome ;
      private bool[] P00763_n523ParametroDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditparametros__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00762;
          prmP00762 = new Object[] {
          new ParDef("AV17ParametroChave",GXType.VarChar,100,0)
          };
          Object[] prmP00763;
          prmP00763 = new Object[] {
          new ParDef("AV17ParametroChave",GXType.VarChar,100,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00762", "SELECT ParametroChave, ParametroDescricao, ParametroValor, ParametroDel, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome FROM tb_parametro WHERE ParametroChave = ( :AV17ParametroChave) ORDER BY ParametroChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00762,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00763", "SELECT ParametroChave, ParametroDescricao, ParametroValor, ParametroDel, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome FROM tb_parametro WHERE ParametroChave = ( :AV17ParametroChave) ORDER BY ParametroChave ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00763,1, GxCacheFrequency.OFF ,false,true )
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
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 40);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
             case 1 :
                ((string[]) buf[0])[0] = rslt.getVarchar(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((bool[]) buf[5])[0] = rslt.getBool(4);
                ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(5, true);
                ((bool[]) buf[7])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[9])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[11])[0] = rslt.wasNull(7);
                ((string[]) buf[12])[0] = rslt.getString(8, 40);
                ((bool[]) buf[13])[0] = rslt.wasNull(8);
                ((string[]) buf[14])[0] = rslt.getVarchar(9);
                ((bool[]) buf[15])[0] = rslt.wasNull(9);
                return;
       }
    }

 }

}
