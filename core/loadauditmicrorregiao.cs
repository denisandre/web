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
   public class loadauditmicrorregiao : GXProcedure
   {
      public loadauditmicrorregiao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditmicrorregiao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           int aP2_MicrorregiaoID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17MicrorregiaoID = aP2_MicrorregiaoID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 int aP2_MicrorregiaoID ,
                                 string aP3_ActualMode )
      {
         loadauditmicrorregiao objloadauditmicrorregiao;
         objloadauditmicrorregiao = new loadauditmicrorregiao();
         objloadauditmicrorregiao.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditmicrorregiao.AV11AuditingObject = aP1_AuditingObject;
         objloadauditmicrorregiao.AV17MicrorregiaoID = aP2_MicrorregiaoID;
         objloadauditmicrorregiao.AV15ActualMode = aP3_ActualMode;
         objloadauditmicrorregiao.context.SetSubmitInitialConfig(context);
         objloadauditmicrorregiao.initialize();
         Submit( executePrivateCatch,objloadauditmicrorregiao);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditmicrorregiao)stateInfo).executePrivate();
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
         /* Using cursor P007C2 */
         pr_default.execute(0, new Object[] {AV17MicrorregiaoID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A23MicrorregiaoID = P007C2_A23MicrorregiaoID[0];
            A24MicrorregiaoNome = P007C2_A24MicrorregiaoNome[0];
            A25MicrorregiaoMesoID = P007C2_A25MicrorregiaoMesoID[0];
            A26MicrorregiaoMesoNome = P007C2_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = P007C2_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = P007C2_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P007C2_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = P007C2_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = P007C2_n29MicrorregiaoMesoUFNome[0];
            A30MicrorregiaoMesoUFSiglaNome = P007C2_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = P007C2_n30MicrorregiaoMesoUFSiglaNome[0];
            A31MicrorregiaoMesoUFRegID = P007C2_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = P007C2_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = P007C2_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = P007C2_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = P007C2_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P007C2_n33MicrorregiaoMesoUFRegNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = P007C2_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = P007C2_n34MicrorregiaoMesoUFRegSiglaNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_microrregiao";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A23MicrorregiaoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A24MicrorregiaoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A25MicrorregiaoMesoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "MesoRegião Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A26MicrorregiaoMesoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A27MicrorregiaoMesoUFID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A28MicrorregiaoMesoUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A29MicrorregiaoMesoUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A30MicrorregiaoMesoUFSiglaNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A32MicrorregiaoMesoUFRegSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A33MicrorregiaoMesoUFRegNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A34MicrorregiaoMesoUFRegSiglaNome;
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
         /* Using cursor P007C3 */
         pr_default.execute(1, new Object[] {AV17MicrorregiaoID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A23MicrorregiaoID = P007C3_A23MicrorregiaoID[0];
            A24MicrorregiaoNome = P007C3_A24MicrorregiaoNome[0];
            A25MicrorregiaoMesoID = P007C3_A25MicrorregiaoMesoID[0];
            A26MicrorregiaoMesoNome = P007C3_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = P007C3_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = P007C3_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = P007C3_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = P007C3_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = P007C3_n29MicrorregiaoMesoUFNome[0];
            A30MicrorregiaoMesoUFSiglaNome = P007C3_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = P007C3_n30MicrorregiaoMesoUFSiglaNome[0];
            A31MicrorregiaoMesoUFRegID = P007C3_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = P007C3_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = P007C3_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = P007C3_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = P007C3_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = P007C3_n33MicrorregiaoMesoUFRegNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = P007C3_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = P007C3_n34MicrorregiaoMesoUFRegSiglaNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_microrregiao";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A23MicrorregiaoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A24MicrorregiaoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A25MicrorregiaoMesoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "MesoRegião Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A26MicrorregiaoMesoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A27MicrorregiaoMesoUFID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A28MicrorregiaoMesoUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29MicrorregiaoMesoUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A30MicrorregiaoMesoUFSiglaNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A32MicrorregiaoMesoUFRegSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A33MicrorregiaoMesoUFRegNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MicrorregiaoMesoUFRegSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A34MicrorregiaoMesoUFRegSiglaNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A23MicrorregiaoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A24MicrorregiaoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A25MicrorregiaoMesoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A26MicrorregiaoMesoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A27MicrorregiaoMesoUFID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A28MicrorregiaoMesoUFSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A29MicrorregiaoMesoUFNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A30MicrorregiaoMesoUFSiglaNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFRegID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A31MicrorregiaoMesoUFRegID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFRegSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A32MicrorregiaoMesoUFRegSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFRegNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A33MicrorregiaoMesoUFRegNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MicrorregiaoMesoUFRegSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A34MicrorregiaoMesoUFRegSiglaNome;
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
         P007C2_A23MicrorregiaoID = new int[1] ;
         P007C2_A24MicrorregiaoNome = new string[] {""} ;
         P007C2_A25MicrorregiaoMesoID = new int[1] ;
         P007C2_A26MicrorregiaoMesoNome = new string[] {""} ;
         P007C2_A27MicrorregiaoMesoUFID = new int[1] ;
         P007C2_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P007C2_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P007C2_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         P007C2_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         P007C2_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         P007C2_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         P007C2_A31MicrorregiaoMesoUFRegID = new int[1] ;
         P007C2_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         P007C2_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         P007C2_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         P007C2_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P007C2_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P007C2_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         P007C2_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         A24MicrorregiaoNome = "";
         A26MicrorregiaoMesoNome = "";
         A28MicrorregiaoMesoUFSigla = "";
         A29MicrorregiaoMesoUFNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         A33MicrorregiaoMesoUFRegNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007C3_A23MicrorregiaoID = new int[1] ;
         P007C3_A24MicrorregiaoNome = new string[] {""} ;
         P007C3_A25MicrorregiaoMesoID = new int[1] ;
         P007C3_A26MicrorregiaoMesoNome = new string[] {""} ;
         P007C3_A27MicrorregiaoMesoUFID = new int[1] ;
         P007C3_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         P007C3_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         P007C3_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         P007C3_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         P007C3_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         P007C3_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         P007C3_A31MicrorregiaoMesoUFRegID = new int[1] ;
         P007C3_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         P007C3_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         P007C3_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         P007C3_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         P007C3_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         P007C3_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         P007C3_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditmicrorregiao__default(),
            new Object[][] {
                new Object[] {
               P007C2_A23MicrorregiaoID, P007C2_A24MicrorregiaoNome, P007C2_A25MicrorregiaoMesoID, P007C2_A26MicrorregiaoMesoNome, P007C2_A27MicrorregiaoMesoUFID, P007C2_A28MicrorregiaoMesoUFSigla, P007C2_n28MicrorregiaoMesoUFSigla, P007C2_A29MicrorregiaoMesoUFNome, P007C2_n29MicrorregiaoMesoUFNome, P007C2_A30MicrorregiaoMesoUFSiglaNome,
               P007C2_n30MicrorregiaoMesoUFSiglaNome, P007C2_A31MicrorregiaoMesoUFRegID, P007C2_n31MicrorregiaoMesoUFRegID, P007C2_A32MicrorregiaoMesoUFRegSigla, P007C2_n32MicrorregiaoMesoUFRegSigla, P007C2_A33MicrorregiaoMesoUFRegNome, P007C2_n33MicrorregiaoMesoUFRegNome, P007C2_A34MicrorregiaoMesoUFRegSiglaNome, P007C2_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               P007C3_A23MicrorregiaoID, P007C3_A24MicrorregiaoNome, P007C3_A25MicrorregiaoMesoID, P007C3_A26MicrorregiaoMesoNome, P007C3_A27MicrorregiaoMesoUFID, P007C3_A28MicrorregiaoMesoUFSigla, P007C3_n28MicrorregiaoMesoUFSigla, P007C3_A29MicrorregiaoMesoUFNome, P007C3_n29MicrorregiaoMesoUFNome, P007C3_A30MicrorregiaoMesoUFSiglaNome,
               P007C3_n30MicrorregiaoMesoUFSiglaNome, P007C3_A31MicrorregiaoMesoUFRegID, P007C3_n31MicrorregiaoMesoUFRegID, P007C3_A32MicrorregiaoMesoUFRegSigla, P007C3_n32MicrorregiaoMesoUFRegSigla, P007C3_A33MicrorregiaoMesoUFRegNome, P007C3_n33MicrorregiaoMesoUFRegNome, P007C3_A34MicrorregiaoMesoUFRegSiglaNome, P007C3_n34MicrorregiaoMesoUFRegSiglaNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17MicrorregiaoID ;
      private int A23MicrorregiaoID ;
      private int A25MicrorregiaoMesoID ;
      private int A27MicrorregiaoMesoUFID ;
      private int A31MicrorregiaoMesoUFRegID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private string A24MicrorregiaoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string A29MicrorregiaoMesoUFNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P007C2_A23MicrorregiaoID ;
      private string[] P007C2_A24MicrorregiaoNome ;
      private int[] P007C2_A25MicrorregiaoMesoID ;
      private string[] P007C2_A26MicrorregiaoMesoNome ;
      private int[] P007C2_A27MicrorregiaoMesoUFID ;
      private string[] P007C2_A28MicrorregiaoMesoUFSigla ;
      private bool[] P007C2_n28MicrorregiaoMesoUFSigla ;
      private string[] P007C2_A29MicrorregiaoMesoUFNome ;
      private bool[] P007C2_n29MicrorregiaoMesoUFNome ;
      private string[] P007C2_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] P007C2_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] P007C2_A31MicrorregiaoMesoUFRegID ;
      private bool[] P007C2_n31MicrorregiaoMesoUFRegID ;
      private string[] P007C2_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] P007C2_n32MicrorregiaoMesoUFRegSigla ;
      private string[] P007C2_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P007C2_n33MicrorregiaoMesoUFRegNome ;
      private string[] P007C2_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] P007C2_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] P007C3_A23MicrorregiaoID ;
      private string[] P007C3_A24MicrorregiaoNome ;
      private int[] P007C3_A25MicrorregiaoMesoID ;
      private string[] P007C3_A26MicrorregiaoMesoNome ;
      private int[] P007C3_A27MicrorregiaoMesoUFID ;
      private string[] P007C3_A28MicrorregiaoMesoUFSigla ;
      private bool[] P007C3_n28MicrorregiaoMesoUFSigla ;
      private string[] P007C3_A29MicrorregiaoMesoUFNome ;
      private bool[] P007C3_n29MicrorregiaoMesoUFNome ;
      private string[] P007C3_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] P007C3_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] P007C3_A31MicrorregiaoMesoUFRegID ;
      private bool[] P007C3_n31MicrorregiaoMesoUFRegID ;
      private string[] P007C3_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] P007C3_n32MicrorregiaoMesoUFRegSigla ;
      private string[] P007C3_A33MicrorregiaoMesoUFRegNome ;
      private bool[] P007C3_n33MicrorregiaoMesoUFRegNome ;
      private string[] P007C3_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] P007C3_n34MicrorregiaoMesoUFRegSiglaNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditmicrorregiao__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007C2;
          prmP007C2 = new Object[] {
          new ParDef("AV17MicrorregiaoID",GXType.Int32,9,0)
          };
          Object[] prmP007C3;
          prmP007C3 = new Object[] {
          new ParDef("AV17MicrorregiaoID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007C2", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :AV17MicrorregiaoID ORDER BY MicrorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007C3", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :AV17MicrorregiaoID ORDER BY MicrorregiaoID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007C3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((int[]) buf[11])[0] = rslt.getInt(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((string[]) buf[15])[0] = rslt.getVarchar(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                return;
       }
    }

 }

}
