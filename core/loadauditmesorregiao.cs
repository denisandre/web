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
   public class loadauditmesorregiao : GXProcedure
   {
      public loadauditmesorregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditmesorregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           int aP2_MesorregiaoID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17MesorregiaoID = aP2_MesorregiaoID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 int aP2_MesorregiaoID ,
                                 string aP3_ActualMode )
      {
         loadauditmesorregiao objloadauditmesorregiao;
         objloadauditmesorregiao = new loadauditmesorregiao();
         objloadauditmesorregiao.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditmesorregiao.AV11AuditingObject = aP1_AuditingObject;
         objloadauditmesorregiao.AV17MesorregiaoID = aP2_MesorregiaoID;
         objloadauditmesorregiao.AV15ActualMode = aP3_ActualMode;
         objloadauditmesorregiao.context.SetSubmitInitialConfig(context);
         objloadauditmesorregiao.initialize();
         Submit( executePrivateCatch,objloadauditmesorregiao);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditmesorregiao)stateInfo).executePrivate();
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
         /* Using cursor P007B2 */
         pr_default.execute(0, new Object[] {AV17MesorregiaoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A13MesorregiaoID = P007B2_A13MesorregiaoID[0];
            A14MesorregiaoNome = P007B2_A14MesorregiaoNome[0];
            A15MesorregiaoUFID = P007B2_A15MesorregiaoUFID[0];
            A16MesorregiaoUFSigla = P007B2_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = P007B2_A17MesorregiaoUFNome[0];
            A18MesorregiaoUFSiglaNome = P007B2_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = P007B2_n18MesorregiaoUFSiglaNome[0];
            A19MesorregiaoUFRegID = P007B2_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = P007B2_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = P007B2_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = P007B2_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P007B2_n21MesorregiaoUFRegNome[0];
            A22MesorregiaoUFRegSiglaNome = P007B2_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = P007B2_n22MesorregiaoUFRegSiglaNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_mesorregiao";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A13MesorregiaoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A14MesorregiaoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade Federativa (Estado)";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A15MesorregiaoUFID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A16MesorregiaoUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A17MesorregiaoUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A18MesorregiaoUFSiglaNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A19MesorregiaoUFRegID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A20MesorregiaoUFRegSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A21MesorregiaoUFRegNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A22MesorregiaoUFRegSiglaNome;
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
         /* Using cursor P007B3 */
         pr_default.execute(1, new Object[] {AV17MesorregiaoID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A13MesorregiaoID = P007B3_A13MesorregiaoID[0];
            A14MesorregiaoNome = P007B3_A14MesorregiaoNome[0];
            A15MesorregiaoUFID = P007B3_A15MesorregiaoUFID[0];
            A16MesorregiaoUFSigla = P007B3_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = P007B3_A17MesorregiaoUFNome[0];
            A18MesorregiaoUFSiglaNome = P007B3_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = P007B3_n18MesorregiaoUFSiglaNome[0];
            A19MesorregiaoUFRegID = P007B3_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = P007B3_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = P007B3_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = P007B3_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = P007B3_n21MesorregiaoUFRegNome[0];
            A22MesorregiaoUFRegSiglaNome = P007B3_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = P007B3_n22MesorregiaoUFRegSiglaNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_mesorregiao";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A13MesorregiaoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A14MesorregiaoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade Federativa (Estado)";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A15MesorregiaoUFID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A16MesorregiaoUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A17MesorregiaoUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A18MesorregiaoUFSiglaNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A19MesorregiaoUFRegID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A20MesorregiaoUFRegSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A21MesorregiaoUFRegNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MesorregiaoUFRegSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A22MesorregiaoUFRegSiglaNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A13MesorregiaoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A14MesorregiaoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A15MesorregiaoUFID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A16MesorregiaoUFSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A17MesorregiaoUFNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A18MesorregiaoUFSiglaNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFRegID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A19MesorregiaoUFRegID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFRegSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A20MesorregiaoUFRegSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFRegNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A21MesorregiaoUFRegNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MesorregiaoUFRegSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A22MesorregiaoUFRegSiglaNome;
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
         P007B2_A13MesorregiaoID = new int[1] ;
         P007B2_A14MesorregiaoNome = new string[] {""} ;
         P007B2_A15MesorregiaoUFID = new int[1] ;
         P007B2_A16MesorregiaoUFSigla = new string[] {""} ;
         P007B2_A17MesorregiaoUFNome = new string[] {""} ;
         P007B2_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         P007B2_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         P007B2_A19MesorregiaoUFRegID = new int[1] ;
         P007B2_A20MesorregiaoUFRegSigla = new string[] {""} ;
         P007B2_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         P007B2_A21MesorregiaoUFRegNome = new string[] {""} ;
         P007B2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P007B2_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         P007B2_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A17MesorregiaoUFNome = "";
         A18MesorregiaoUFSiglaNome = "";
         A20MesorregiaoUFRegSigla = "";
         A21MesorregiaoUFRegNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007B3_A13MesorregiaoID = new int[1] ;
         P007B3_A14MesorregiaoNome = new string[] {""} ;
         P007B3_A15MesorregiaoUFID = new int[1] ;
         P007B3_A16MesorregiaoUFSigla = new string[] {""} ;
         P007B3_A17MesorregiaoUFNome = new string[] {""} ;
         P007B3_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         P007B3_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         P007B3_A19MesorregiaoUFRegID = new int[1] ;
         P007B3_A20MesorregiaoUFRegSigla = new string[] {""} ;
         P007B3_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         P007B3_A21MesorregiaoUFRegNome = new string[] {""} ;
         P007B3_n21MesorregiaoUFRegNome = new bool[] {false} ;
         P007B3_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         P007B3_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditmesorregiao__default(),
            new Object[][] {
                new Object[] {
               P007B2_A13MesorregiaoID, P007B2_A14MesorregiaoNome, P007B2_A15MesorregiaoUFID, P007B2_A16MesorregiaoUFSigla, P007B2_A17MesorregiaoUFNome, P007B2_A18MesorregiaoUFSiglaNome, P007B2_n18MesorregiaoUFSiglaNome, P007B2_A19MesorregiaoUFRegID, P007B2_A20MesorregiaoUFRegSigla, P007B2_n20MesorregiaoUFRegSigla,
               P007B2_A21MesorregiaoUFRegNome, P007B2_n21MesorregiaoUFRegNome, P007B2_A22MesorregiaoUFRegSiglaNome, P007B2_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               P007B3_A13MesorregiaoID, P007B3_A14MesorregiaoNome, P007B3_A15MesorregiaoUFID, P007B3_A16MesorregiaoUFSigla, P007B3_A17MesorregiaoUFNome, P007B3_A18MesorregiaoUFSiglaNome, P007B3_n18MesorregiaoUFSiglaNome, P007B3_A19MesorregiaoUFRegID, P007B3_A20MesorregiaoUFRegSigla, P007B3_n20MesorregiaoUFRegSigla,
               P007B3_A21MesorregiaoUFRegNome, P007B3_n21MesorregiaoUFRegNome, P007B3_A22MesorregiaoUFRegSiglaNome, P007B3_n22MesorregiaoUFRegSiglaNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17MesorregiaoID ;
      private int A13MesorregiaoID ;
      private int A15MesorregiaoUFID ;
      private int A19MesorregiaoUFRegID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n21MesorregiaoUFRegNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A17MesorregiaoUFNome ;
      private string A18MesorregiaoUFSiglaNome ;
      private string A20MesorregiaoUFRegSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P007B2_A13MesorregiaoID ;
      private string[] P007B2_A14MesorregiaoNome ;
      private int[] P007B2_A15MesorregiaoUFID ;
      private string[] P007B2_A16MesorregiaoUFSigla ;
      private string[] P007B2_A17MesorregiaoUFNome ;
      private string[] P007B2_A18MesorregiaoUFSiglaNome ;
      private bool[] P007B2_n18MesorregiaoUFSiglaNome ;
      private int[] P007B2_A19MesorregiaoUFRegID ;
      private string[] P007B2_A20MesorregiaoUFRegSigla ;
      private bool[] P007B2_n20MesorregiaoUFRegSigla ;
      private string[] P007B2_A21MesorregiaoUFRegNome ;
      private bool[] P007B2_n21MesorregiaoUFRegNome ;
      private string[] P007B2_A22MesorregiaoUFRegSiglaNome ;
      private bool[] P007B2_n22MesorregiaoUFRegSiglaNome ;
      private int[] P007B3_A13MesorregiaoID ;
      private string[] P007B3_A14MesorregiaoNome ;
      private int[] P007B3_A15MesorregiaoUFID ;
      private string[] P007B3_A16MesorregiaoUFSigla ;
      private string[] P007B3_A17MesorregiaoUFNome ;
      private string[] P007B3_A18MesorregiaoUFSiglaNome ;
      private bool[] P007B3_n18MesorregiaoUFSiglaNome ;
      private int[] P007B3_A19MesorregiaoUFRegID ;
      private string[] P007B3_A20MesorregiaoUFRegSigla ;
      private bool[] P007B3_n20MesorregiaoUFRegSigla ;
      private string[] P007B3_A21MesorregiaoUFRegNome ;
      private bool[] P007B3_n21MesorregiaoUFRegNome ;
      private string[] P007B3_A22MesorregiaoUFRegSiglaNome ;
      private bool[] P007B3_n22MesorregiaoUFRegSiglaNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditmesorregiao__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007B2;
          prmP007B2 = new Object[] {
          new ParDef("AV17MesorregiaoID",GXType.Int32,9,0)
          };
          Object[] prmP007B3;
          prmP007B3 = new Object[] {
          new ParDef("AV17MesorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007B2", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :AV17MesorregiaoID ORDER BY MesorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007B3", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :AV17MesorregiaoID ORDER BY MesorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007B3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getVarchar(9);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                return;
       }
    }

 }

}
