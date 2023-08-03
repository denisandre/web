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
   public class loadauditclientepjtipo : GXProcedure
   {
      public loadauditclientepjtipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditclientepjtipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           int aP2_PjtID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17PjtID = aP2_PjtID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 int aP2_PjtID ,
                                 string aP3_ActualMode )
      {
         loadauditclientepjtipo objloadauditclientepjtipo;
         objloadauditclientepjtipo = new loadauditclientepjtipo();
         objloadauditclientepjtipo.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditclientepjtipo.AV11AuditingObject = aP1_AuditingObject;
         objloadauditclientepjtipo.AV17PjtID = aP2_PjtID;
         objloadauditclientepjtipo.AV15ActualMode = aP3_ActualMode;
         objloadauditclientepjtipo.context.SetSubmitInitialConfig(context);
         objloadauditclientepjtipo.initialize();
         Submit( executePrivateCatch,objloadauditclientepjtipo);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditclientepjtipo)stateInfo).executePrivate();
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
         /* Using cursor P006Z2 */
         pr_default.execute(0, new Object[] {AV17PjtID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A155PjtID = P006Z2_A155PjtID[0];
            A156PjtSigla = P006Z2_A156PjtSigla[0];
            A157PjtNome = P006Z2_A157PjtNome[0];
            A217PjtAtivo = P006Z2_A217PjtAtivo[0];
            A530PjtDel = P006Z2_A530PjtDel[0];
            A531PjtDelDataHora = P006Z2_A531PjtDelDataHora[0];
            n531PjtDelDataHora = P006Z2_n531PjtDelDataHora[0];
            A532PjtDelData = P006Z2_A532PjtDelData[0];
            n532PjtDelData = P006Z2_n532PjtDelData[0];
            A533PjtDelHora = P006Z2_A533PjtDelHora[0];
            n533PjtDelHora = P006Z2_n533PjtDelHora[0];
            A534PjtDelUsuId = P006Z2_A534PjtDelUsuId[0];
            n534PjtDelUsuId = P006Z2_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = P006Z2_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = P006Z2_n535PjtDelUsuNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepjtipo";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A155PjtID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A156PjtSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A157PjtNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A217PjtAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A530PjtDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A532PjtDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A533PjtDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A534PjtDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A535PjtDelUsuNome;
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
         /* Using cursor P006Z3 */
         pr_default.execute(1, new Object[] {AV17PjtID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A155PjtID = P006Z3_A155PjtID[0];
            A156PjtSigla = P006Z3_A156PjtSigla[0];
            A157PjtNome = P006Z3_A157PjtNome[0];
            A217PjtAtivo = P006Z3_A217PjtAtivo[0];
            A530PjtDel = P006Z3_A530PjtDel[0];
            A531PjtDelDataHora = P006Z3_A531PjtDelDataHora[0];
            n531PjtDelDataHora = P006Z3_n531PjtDelDataHora[0];
            A532PjtDelData = P006Z3_A532PjtDelData[0];
            n532PjtDelData = P006Z3_n532PjtDelData[0];
            A533PjtDelHora = P006Z3_A533PjtDelHora[0];
            n533PjtDelHora = P006Z3_n533PjtDelHora[0];
            A534PjtDelUsuId = P006Z3_A534PjtDelUsuId[0];
            n534PjtDelUsuId = P006Z3_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = P006Z3_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = P006Z3_n535PjtDelUsuNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepjtipo";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A155PjtID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A156PjtSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A157PjtNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A217PjtAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A530PjtDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A532PjtDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A533PjtDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A534PjtDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "PjtDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A535PjtDelUsuNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A155PjtID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A156PjtSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A157PjtNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A217PjtAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A530PjtDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A532PjtDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A533PjtDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A534PjtDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "PjtDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A535PjtDelUsuNome;
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
         P006Z2_A155PjtID = new int[1] ;
         P006Z2_A156PjtSigla = new string[] {""} ;
         P006Z2_A157PjtNome = new string[] {""} ;
         P006Z2_A217PjtAtivo = new bool[] {false} ;
         P006Z2_A530PjtDel = new bool[] {false} ;
         P006Z2_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P006Z2_n531PjtDelDataHora = new bool[] {false} ;
         P006Z2_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         P006Z2_n532PjtDelData = new bool[] {false} ;
         P006Z2_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         P006Z2_n533PjtDelHora = new bool[] {false} ;
         P006Z2_A534PjtDelUsuId = new string[] {""} ;
         P006Z2_n534PjtDelUsuId = new bool[] {false} ;
         P006Z2_A535PjtDelUsuNome = new string[] {""} ;
         P006Z2_n535PjtDelUsuNome = new bool[] {false} ;
         A156PjtSigla = "";
         A157PjtNome = "";
         A531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         A532PjtDelData = (DateTime)(DateTime.MinValue);
         A533PjtDelHora = (DateTime)(DateTime.MinValue);
         A534PjtDelUsuId = "";
         A535PjtDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P006Z3_A155PjtID = new int[1] ;
         P006Z3_A156PjtSigla = new string[] {""} ;
         P006Z3_A157PjtNome = new string[] {""} ;
         P006Z3_A217PjtAtivo = new bool[] {false} ;
         P006Z3_A530PjtDel = new bool[] {false} ;
         P006Z3_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P006Z3_n531PjtDelDataHora = new bool[] {false} ;
         P006Z3_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         P006Z3_n532PjtDelData = new bool[] {false} ;
         P006Z3_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         P006Z3_n533PjtDelHora = new bool[] {false} ;
         P006Z3_A534PjtDelUsuId = new string[] {""} ;
         P006Z3_n534PjtDelUsuId = new bool[] {false} ;
         P006Z3_A535PjtDelUsuNome = new string[] {""} ;
         P006Z3_n535PjtDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditclientepjtipo__default(),
            new Object[][] {
                new Object[] {
               P006Z2_A155PjtID, P006Z2_A156PjtSigla, P006Z2_A157PjtNome, P006Z2_A217PjtAtivo, P006Z2_A530PjtDel, P006Z2_A531PjtDelDataHora, P006Z2_n531PjtDelDataHora, P006Z2_A532PjtDelData, P006Z2_n532PjtDelData, P006Z2_A533PjtDelHora,
               P006Z2_n533PjtDelHora, P006Z2_A534PjtDelUsuId, P006Z2_n534PjtDelUsuId, P006Z2_A535PjtDelUsuNome, P006Z2_n535PjtDelUsuNome
               }
               , new Object[] {
               P006Z3_A155PjtID, P006Z3_A156PjtSigla, P006Z3_A157PjtNome, P006Z3_A217PjtAtivo, P006Z3_A530PjtDel, P006Z3_A531PjtDelDataHora, P006Z3_n531PjtDelDataHora, P006Z3_A532PjtDelData, P006Z3_n532PjtDelData, P006Z3_A533PjtDelHora,
               P006Z3_n533PjtDelHora, P006Z3_A534PjtDelUsuId, P006Z3_n534PjtDelUsuId, P006Z3_A535PjtDelUsuNome, P006Z3_n535PjtDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17PjtID ;
      private int A155PjtID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A534PjtDelUsuId ;
      private DateTime A531PjtDelDataHora ;
      private DateTime A532PjtDelData ;
      private DateTime A533PjtDelHora ;
      private bool returnInSub ;
      private bool A217PjtAtivo ;
      private bool A530PjtDel ;
      private bool n531PjtDelDataHora ;
      private bool n532PjtDelData ;
      private bool n533PjtDelHora ;
      private bool n534PjtDelUsuId ;
      private bool n535PjtDelUsuNome ;
      private string A156PjtSigla ;
      private string A157PjtNome ;
      private string A535PjtDelUsuNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P006Z2_A155PjtID ;
      private string[] P006Z2_A156PjtSigla ;
      private string[] P006Z2_A157PjtNome ;
      private bool[] P006Z2_A217PjtAtivo ;
      private bool[] P006Z2_A530PjtDel ;
      private DateTime[] P006Z2_A531PjtDelDataHora ;
      private bool[] P006Z2_n531PjtDelDataHora ;
      private DateTime[] P006Z2_A532PjtDelData ;
      private bool[] P006Z2_n532PjtDelData ;
      private DateTime[] P006Z2_A533PjtDelHora ;
      private bool[] P006Z2_n533PjtDelHora ;
      private string[] P006Z2_A534PjtDelUsuId ;
      private bool[] P006Z2_n534PjtDelUsuId ;
      private string[] P006Z2_A535PjtDelUsuNome ;
      private bool[] P006Z2_n535PjtDelUsuNome ;
      private int[] P006Z3_A155PjtID ;
      private string[] P006Z3_A156PjtSigla ;
      private string[] P006Z3_A157PjtNome ;
      private bool[] P006Z3_A217PjtAtivo ;
      private bool[] P006Z3_A530PjtDel ;
      private DateTime[] P006Z3_A531PjtDelDataHora ;
      private bool[] P006Z3_n531PjtDelDataHora ;
      private DateTime[] P006Z3_A532PjtDelData ;
      private bool[] P006Z3_n532PjtDelData ;
      private DateTime[] P006Z3_A533PjtDelHora ;
      private bool[] P006Z3_n533PjtDelHora ;
      private string[] P006Z3_A534PjtDelUsuId ;
      private bool[] P006Z3_n534PjtDelUsuId ;
      private string[] P006Z3_A535PjtDelUsuNome ;
      private bool[] P006Z3_n535PjtDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditclientepjtipo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP006Z2;
          prmP006Z2 = new Object[] {
          new ParDef("AV17PjtID",GXType.Int32,9,0)
          };
          Object[] prmP006Z3;
          prmP006Z3 = new Object[] {
          new ParDef("AV17PjtID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006Z2", "SELECT PjtID, PjtSigla, PjtNome, PjtAtivo, PjtDel, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome FROM tb_clientepjtipo WHERE PjtID = :AV17PjtID ORDER BY PjtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P006Z3", "SELECT PjtID, PjtSigla, PjtNome, PjtAtivo, PjtDel, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome FROM tb_clientepjtipo WHERE PjtID = :AV17PjtID ORDER BY PjtID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006Z3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((bool[]) buf[4])[0] = rslt.getBool(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getString(9, 40);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
