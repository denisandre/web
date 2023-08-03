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
   public class loadauditmunicipio : GXProcedure
   {
      public loadauditmunicipio( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditmunicipio( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           int aP2_MunicipioID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17MunicipioID = aP2_MunicipioID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 int aP2_MunicipioID ,
                                 string aP3_ActualMode )
      {
         loadauditmunicipio objloadauditmunicipio;
         objloadauditmunicipio = new loadauditmunicipio();
         objloadauditmunicipio.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditmunicipio.AV11AuditingObject = aP1_AuditingObject;
         objloadauditmunicipio.AV17MunicipioID = aP2_MunicipioID;
         objloadauditmunicipio.AV15ActualMode = aP3_ActualMode;
         objloadauditmunicipio.context.SetSubmitInitialConfig(context);
         objloadauditmunicipio.initialize();
         Submit( executePrivateCatch,objloadauditmunicipio);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditmunicipio)stateInfo).executePrivate();
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
         /* Using cursor P007D2 */
         pr_default.execute(0, new Object[] {AV17MunicipioID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A35MunicipioID = P007D2_A35MunicipioID[0];
            A36MunicipioNome = P007D2_A36MunicipioNome[0];
            A37MunicipioMicroID = P007D2_A37MunicipioMicroID[0];
            A38MunicipioMicroNome = P007D2_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = P007D2_A39MunicipioMicroMesoID[0];
            A40MunicipioMicroMesoNome = P007D2_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P007D2_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = P007D2_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = P007D2_n41MunicipioMicroMesoUFID[0];
            A42MunicipioMicroMesoUFSigla = P007D2_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P007D2_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = P007D2_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = P007D2_n43MunicipioMicroMesoUFNome[0];
            A44MunicipioMicroMesoUFSiglaNome = P007D2_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = P007D2_n44MunicipioMicroMesoUFSiglaNome[0];
            A45MunicipioMicroMesoUFRegID = P007D2_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = P007D2_n45MunicipioMicroMesoUFRegID[0];
            A46MunicipioMicroMesoUFRegSigla = P007D2_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = P007D2_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = P007D2_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P007D2_n47MunicipioMicroMesoUFRegNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = P007D2_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = P007D2_n48MunicipioMicroMesoUFRegSiglaNo[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_municipio";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A35MunicipioID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A36MunicipioNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Microrregião";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A37MunicipioMicroID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Microrregião Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A38MunicipioMicroNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A39MunicipioMicroMesoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A40MunicipioMicroMesoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A41MunicipioMicroMesoUFID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A42MunicipioMicroMesoUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A43MunicipioMicroMesoUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A44MunicipioMicroMesoUFSiglaNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A46MunicipioMicroMesoUFRegSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A47MunicipioMicroMesoUFRegNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegSiglaNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A48MunicipioMicroMesoUFRegSiglaNo;
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
         /* Using cursor P007D3 */
         pr_default.execute(1, new Object[] {AV17MunicipioID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A35MunicipioID = P007D3_A35MunicipioID[0];
            A36MunicipioNome = P007D3_A36MunicipioNome[0];
            A37MunicipioMicroID = P007D3_A37MunicipioMicroID[0];
            A38MunicipioMicroNome = P007D3_A38MunicipioMicroNome[0];
            A39MunicipioMicroMesoID = P007D3_A39MunicipioMicroMesoID[0];
            A40MunicipioMicroMesoNome = P007D3_A40MunicipioMicroMesoNome[0];
            n40MunicipioMicroMesoNome = P007D3_n40MunicipioMicroMesoNome[0];
            A41MunicipioMicroMesoUFID = P007D3_A41MunicipioMicroMesoUFID[0];
            n41MunicipioMicroMesoUFID = P007D3_n41MunicipioMicroMesoUFID[0];
            A42MunicipioMicroMesoUFSigla = P007D3_A42MunicipioMicroMesoUFSigla[0];
            n42MunicipioMicroMesoUFSigla = P007D3_n42MunicipioMicroMesoUFSigla[0];
            A43MunicipioMicroMesoUFNome = P007D3_A43MunicipioMicroMesoUFNome[0];
            n43MunicipioMicroMesoUFNome = P007D3_n43MunicipioMicroMesoUFNome[0];
            A44MunicipioMicroMesoUFSiglaNome = P007D3_A44MunicipioMicroMesoUFSiglaNome[0];
            n44MunicipioMicroMesoUFSiglaNome = P007D3_n44MunicipioMicroMesoUFSiglaNome[0];
            A45MunicipioMicroMesoUFRegID = P007D3_A45MunicipioMicroMesoUFRegID[0];
            n45MunicipioMicroMesoUFRegID = P007D3_n45MunicipioMicroMesoUFRegID[0];
            A46MunicipioMicroMesoUFRegSigla = P007D3_A46MunicipioMicroMesoUFRegSigla[0];
            n46MunicipioMicroMesoUFRegSigla = P007D3_n46MunicipioMicroMesoUFRegSigla[0];
            A47MunicipioMicroMesoUFRegNome = P007D3_A47MunicipioMicroMesoUFRegNome[0];
            n47MunicipioMicroMesoUFRegNome = P007D3_n47MunicipioMicroMesoUFRegNome[0];
            A48MunicipioMicroMesoUFRegSiglaNo = P007D3_A48MunicipioMicroMesoUFRegSiglaNo[0];
            n48MunicipioMicroMesoUFRegSiglaNo = P007D3_n48MunicipioMicroMesoUFRegSiglaNo[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tbibge_municipio";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A35MunicipioID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A36MunicipioNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Microrregião";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A37MunicipioMicroID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Microrregião Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A38MunicipioMicroNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A39MunicipioMicroMesoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Mesorregião";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A40MunicipioMicroMesoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A41MunicipioMicroMesoUFID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A42MunicipioMicroMesoUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A43MunicipioMicroMesoUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A44MunicipioMicroMesoUFSiglaNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A46MunicipioMicroMesoUFRegSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A47MunicipioMicroMesoUFRegNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "MunicipioMicroMesoUFRegSiglaNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Região";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A48MunicipioMicroMesoUFRegSiglaNo;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A35MunicipioID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A36MunicipioNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A37MunicipioMicroID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A38MunicipioMicroNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A39MunicipioMicroMesoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A40MunicipioMicroMesoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A41MunicipioMicroMesoUFID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A42MunicipioMicroMesoUFSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A43MunicipioMicroMesoUFNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A44MunicipioMicroMesoUFSiglaNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFRegID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A45MunicipioMicroMesoUFRegID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFRegSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A46MunicipioMicroMesoUFRegSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFRegNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A47MunicipioMicroMesoUFRegNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "MunicipioMicroMesoUFRegSiglaNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A48MunicipioMicroMesoUFRegSiglaNo;
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
         P007D2_A35MunicipioID = new int[1] ;
         P007D2_A36MunicipioNome = new string[] {""} ;
         P007D2_A37MunicipioMicroID = new int[1] ;
         P007D2_A38MunicipioMicroNome = new string[] {""} ;
         P007D2_A39MunicipioMicroMesoID = new int[1] ;
         P007D2_A40MunicipioMicroMesoNome = new string[] {""} ;
         P007D2_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P007D2_A41MunicipioMicroMesoUFID = new int[1] ;
         P007D2_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         P007D2_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P007D2_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P007D2_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         P007D2_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         P007D2_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         P007D2_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         P007D2_A45MunicipioMicroMesoUFRegID = new int[1] ;
         P007D2_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         P007D2_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         P007D2_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         P007D2_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P007D2_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P007D2_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         P007D2_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         A36MunicipioNome = "";
         A38MunicipioMicroNome = "";
         A40MunicipioMicroMesoNome = "";
         A42MunicipioMicroMesoUFSigla = "";
         A43MunicipioMicroMesoUFNome = "";
         A44MunicipioMicroMesoUFSiglaNome = "";
         A46MunicipioMicroMesoUFRegSigla = "";
         A47MunicipioMicroMesoUFRegNome = "";
         A48MunicipioMicroMesoUFRegSiglaNo = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007D3_A35MunicipioID = new int[1] ;
         P007D3_A36MunicipioNome = new string[] {""} ;
         P007D3_A37MunicipioMicroID = new int[1] ;
         P007D3_A38MunicipioMicroNome = new string[] {""} ;
         P007D3_A39MunicipioMicroMesoID = new int[1] ;
         P007D3_A40MunicipioMicroMesoNome = new string[] {""} ;
         P007D3_n40MunicipioMicroMesoNome = new bool[] {false} ;
         P007D3_A41MunicipioMicroMesoUFID = new int[1] ;
         P007D3_n41MunicipioMicroMesoUFID = new bool[] {false} ;
         P007D3_A42MunicipioMicroMesoUFSigla = new string[] {""} ;
         P007D3_n42MunicipioMicroMesoUFSigla = new bool[] {false} ;
         P007D3_A43MunicipioMicroMesoUFNome = new string[] {""} ;
         P007D3_n43MunicipioMicroMesoUFNome = new bool[] {false} ;
         P007D3_A44MunicipioMicroMesoUFSiglaNome = new string[] {""} ;
         P007D3_n44MunicipioMicroMesoUFSiglaNome = new bool[] {false} ;
         P007D3_A45MunicipioMicroMesoUFRegID = new int[1] ;
         P007D3_n45MunicipioMicroMesoUFRegID = new bool[] {false} ;
         P007D3_A46MunicipioMicroMesoUFRegSigla = new string[] {""} ;
         P007D3_n46MunicipioMicroMesoUFRegSigla = new bool[] {false} ;
         P007D3_A47MunicipioMicroMesoUFRegNome = new string[] {""} ;
         P007D3_n47MunicipioMicroMesoUFRegNome = new bool[] {false} ;
         P007D3_A48MunicipioMicroMesoUFRegSiglaNo = new string[] {""} ;
         P007D3_n48MunicipioMicroMesoUFRegSiglaNo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditmunicipio__default(),
            new Object[][] {
                new Object[] {
               P007D2_A35MunicipioID, P007D2_A36MunicipioNome, P007D2_A37MunicipioMicroID, P007D2_A38MunicipioMicroNome, P007D2_A39MunicipioMicroMesoID, P007D2_A40MunicipioMicroMesoNome, P007D2_n40MunicipioMicroMesoNome, P007D2_A41MunicipioMicroMesoUFID, P007D2_n41MunicipioMicroMesoUFID, P007D2_A42MunicipioMicroMesoUFSigla,
               P007D2_n42MunicipioMicroMesoUFSigla, P007D2_A43MunicipioMicroMesoUFNome, P007D2_n43MunicipioMicroMesoUFNome, P007D2_A44MunicipioMicroMesoUFSiglaNome, P007D2_n44MunicipioMicroMesoUFSiglaNome, P007D2_A45MunicipioMicroMesoUFRegID, P007D2_n45MunicipioMicroMesoUFRegID, P007D2_A46MunicipioMicroMesoUFRegSigla, P007D2_n46MunicipioMicroMesoUFRegSigla, P007D2_A47MunicipioMicroMesoUFRegNome,
               P007D2_n47MunicipioMicroMesoUFRegNome, P007D2_A48MunicipioMicroMesoUFRegSiglaNo, P007D2_n48MunicipioMicroMesoUFRegSiglaNo
               }
               , new Object[] {
               P007D3_A35MunicipioID, P007D3_A36MunicipioNome, P007D3_A37MunicipioMicroID, P007D3_A38MunicipioMicroNome, P007D3_A39MunicipioMicroMesoID, P007D3_A40MunicipioMicroMesoNome, P007D3_n40MunicipioMicroMesoNome, P007D3_A41MunicipioMicroMesoUFID, P007D3_n41MunicipioMicroMesoUFID, P007D3_A42MunicipioMicroMesoUFSigla,
               P007D3_n42MunicipioMicroMesoUFSigla, P007D3_A43MunicipioMicroMesoUFNome, P007D3_n43MunicipioMicroMesoUFNome, P007D3_A44MunicipioMicroMesoUFSiglaNome, P007D3_n44MunicipioMicroMesoUFSiglaNome, P007D3_A45MunicipioMicroMesoUFRegID, P007D3_n45MunicipioMicroMesoUFRegID, P007D3_A46MunicipioMicroMesoUFRegSigla, P007D3_n46MunicipioMicroMesoUFRegSigla, P007D3_A47MunicipioMicroMesoUFRegNome,
               P007D3_n47MunicipioMicroMesoUFRegNome, P007D3_A48MunicipioMicroMesoUFRegSiglaNo, P007D3_n48MunicipioMicroMesoUFRegSiglaNo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private int AV17MunicipioID ;
      private int A35MunicipioID ;
      private int A37MunicipioMicroID ;
      private int A39MunicipioMicroMesoID ;
      private int A41MunicipioMicroMesoUFID ;
      private int A45MunicipioMicroMesoUFRegID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private bool returnInSub ;
      private bool n40MunicipioMicroMesoNome ;
      private bool n41MunicipioMicroMesoUFID ;
      private bool n42MunicipioMicroMesoUFSigla ;
      private bool n43MunicipioMicroMesoUFNome ;
      private bool n44MunicipioMicroMesoUFSiglaNome ;
      private bool n45MunicipioMicroMesoUFRegID ;
      private bool n46MunicipioMicroMesoUFRegSigla ;
      private bool n47MunicipioMicroMesoUFRegNome ;
      private bool n48MunicipioMicroMesoUFRegSiglaNo ;
      private string A36MunicipioNome ;
      private string A38MunicipioMicroNome ;
      private string A40MunicipioMicroMesoNome ;
      private string A42MunicipioMicroMesoUFSigla ;
      private string A43MunicipioMicroMesoUFNome ;
      private string A44MunicipioMicroMesoUFSiglaNome ;
      private string A46MunicipioMicroMesoUFRegSigla ;
      private string A47MunicipioMicroMesoUFRegNome ;
      private string A48MunicipioMicroMesoUFRegSiglaNo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private int[] P007D2_A35MunicipioID ;
      private string[] P007D2_A36MunicipioNome ;
      private int[] P007D2_A37MunicipioMicroID ;
      private string[] P007D2_A38MunicipioMicroNome ;
      private int[] P007D2_A39MunicipioMicroMesoID ;
      private string[] P007D2_A40MunicipioMicroMesoNome ;
      private bool[] P007D2_n40MunicipioMicroMesoNome ;
      private int[] P007D2_A41MunicipioMicroMesoUFID ;
      private bool[] P007D2_n41MunicipioMicroMesoUFID ;
      private string[] P007D2_A42MunicipioMicroMesoUFSigla ;
      private bool[] P007D2_n42MunicipioMicroMesoUFSigla ;
      private string[] P007D2_A43MunicipioMicroMesoUFNome ;
      private bool[] P007D2_n43MunicipioMicroMesoUFNome ;
      private string[] P007D2_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] P007D2_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] P007D2_A45MunicipioMicroMesoUFRegID ;
      private bool[] P007D2_n45MunicipioMicroMesoUFRegID ;
      private string[] P007D2_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] P007D2_n46MunicipioMicroMesoUFRegSigla ;
      private string[] P007D2_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P007D2_n47MunicipioMicroMesoUFRegNome ;
      private string[] P007D2_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] P007D2_n48MunicipioMicroMesoUFRegSiglaNo ;
      private int[] P007D3_A35MunicipioID ;
      private string[] P007D3_A36MunicipioNome ;
      private int[] P007D3_A37MunicipioMicroID ;
      private string[] P007D3_A38MunicipioMicroNome ;
      private int[] P007D3_A39MunicipioMicroMesoID ;
      private string[] P007D3_A40MunicipioMicroMesoNome ;
      private bool[] P007D3_n40MunicipioMicroMesoNome ;
      private int[] P007D3_A41MunicipioMicroMesoUFID ;
      private bool[] P007D3_n41MunicipioMicroMesoUFID ;
      private string[] P007D3_A42MunicipioMicroMesoUFSigla ;
      private bool[] P007D3_n42MunicipioMicroMesoUFSigla ;
      private string[] P007D3_A43MunicipioMicroMesoUFNome ;
      private bool[] P007D3_n43MunicipioMicroMesoUFNome ;
      private string[] P007D3_A44MunicipioMicroMesoUFSiglaNome ;
      private bool[] P007D3_n44MunicipioMicroMesoUFSiglaNome ;
      private int[] P007D3_A45MunicipioMicroMesoUFRegID ;
      private bool[] P007D3_n45MunicipioMicroMesoUFRegID ;
      private string[] P007D3_A46MunicipioMicroMesoUFRegSigla ;
      private bool[] P007D3_n46MunicipioMicroMesoUFRegSigla ;
      private string[] P007D3_A47MunicipioMicroMesoUFRegNome ;
      private bool[] P007D3_n47MunicipioMicroMesoUFRegNome ;
      private string[] P007D3_A48MunicipioMicroMesoUFRegSiglaNo ;
      private bool[] P007D3_n48MunicipioMicroMesoUFRegSiglaNo ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditmunicipio__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007D2;
          prmP007D2 = new Object[] {
          new ParDef("AV17MunicipioID",GXType.Int32,9,0)
          };
          Object[] prmP007D3;
          prmP007D3 = new Object[] {
          new ParDef("AV17MunicipioID",GXType.Int32,9,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007D2", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :AV17MunicipioID ORDER BY MunicipioID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007D3", "SELECT MunicipioID, MunicipioNome, MunicipioMicroID, MunicipioMicroNome, MunicipioMicroMesoID, MunicipioMicroMesoNome, MunicipioMicroMesoUFID, MunicipioMicroMesoUFSigla, MunicipioMicroMesoUFNome, MunicipioMicroMesoUFSiglaNome, MunicipioMicroMesoUFRegID, MunicipioMicroMesoUFRegSigla, MunicipioMicroMesoUFRegNome, MunicipioMicroMesoUFRegSiglaNo FROM tbibge_municipio WHERE MunicipioID = :AV17MunicipioID ORDER BY MunicipioID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007D3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((int[]) buf[15])[0] = rslt.getInt(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((string[]) buf[21])[0] = rslt.getVarchar(14);
                ((bool[]) buf[22])[0] = rslt.wasNull(14);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((int[]) buf[4])[0] = rslt.getInt(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((int[]) buf[7])[0] = rslt.getInt(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((string[]) buf[9])[0] = rslt.getVarchar(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((string[]) buf[11])[0] = rslt.getVarchar(9);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getVarchar(10);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((int[]) buf[15])[0] = rslt.getInt(11);
                ((bool[]) buf[16])[0] = rslt.wasNull(11);
                ((string[]) buf[17])[0] = rslt.getVarchar(12);
                ((bool[]) buf[18])[0] = rslt.wasNull(12);
                ((string[]) buf[19])[0] = rslt.getVarchar(13);
                ((bool[]) buf[20])[0] = rslt.wasNull(13);
                ((string[]) buf[21])[0] = rslt.getVarchar(14);
                ((bool[]) buf[22])[0] = rslt.wasNull(14);
                return;
       }
    }

 }

}
