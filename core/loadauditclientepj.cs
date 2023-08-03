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
   public class loadauditclientepj : GXProcedure
   {
      public loadauditclientepj( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditclientepj( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_CliID ,
                           Guid aP3_CpjID ,
                           string aP4_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17CliID = aP2_CliID;
         this.AV18CpjID = aP3_CpjID;
         this.AV15ActualMode = aP4_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_CliID ,
                                 Guid aP3_CpjID ,
                                 string aP4_ActualMode )
      {
         loadauditclientepj objloadauditclientepj;
         objloadauditclientepj = new loadauditclientepj();
         objloadauditclientepj.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditclientepj.AV11AuditingObject = aP1_AuditingObject;
         objloadauditclientepj.AV17CliID = aP2_CliID;
         objloadauditclientepj.AV18CpjID = aP3_CpjID;
         objloadauditclientepj.AV15ActualMode = aP4_ActualMode;
         objloadauditclientepj.context.SetSubmitInitialConfig(context);
         objloadauditclientepj.initialize();
         Submit( executePrivateCatch,objloadauditclientepj);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditclientepj)stateInfo).executePrivate();
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
         /* Using cursor P00712 */
         pr_default.execute(0, new Object[] {AV17CliID, AV18CpjID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A166CpjID = P00712_A166CpjID[0];
            A158CliID = P00712_A158CliID[0];
            A159CliMatricula = P00712_A159CliMatricula[0];
            A160CliNomeFamiliar = P00712_A160CliNomeFamiliar[0];
            A181CpjHolID = P00712_A181CpjHolID[0];
            n181CpjHolID = P00712_n181CpjHolID[0];
            A182CpjHolNomeFan = P00712_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = P00712_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = P00712_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = P00712_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = P00712_A193CpjHolCNPJFormat[0];
            A169CpjPaiID = P00712_A169CpjPaiID[0];
            n169CpjPaiID = P00712_n169CpjPaiID[0];
            A172CpjPaiNomeFan = P00712_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = P00712_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = P00712_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = P00712_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = P00712_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = P00712_A184CpjPaiTipoID[0];
            A185CpjPaiTipoSigla = P00712_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = P00712_A186CpjPaiTipoNome[0];
            A365CpjTipoId = P00712_A365CpjTipoId[0];
            A366CpjTipoSigla = P00712_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00712_A367CpjTipoNome[0];
            A170CpjNomeFan = P00712_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00712_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00712_A176CpjMatricula[0];
            A187CpjCNPJ = P00712_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00712_A188CpjCNPJFormat[0];
            A189CpjIE = P00712_A189CpjIE[0];
            A190CpjCapitalSoc = P00712_A190CpjCapitalSoc[0];
            A198CpjInsData = P00712_A198CpjInsData[0];
            A199CpjInsHora = P00712_A199CpjInsHora[0];
            A200CpjInsDataHora = P00712_A200CpjInsDataHora[0];
            A201CpjInsUserID = P00712_A201CpjInsUserID[0];
            n201CpjInsUserID = P00712_n201CpjInsUserID[0];
            A202CpjUpdData = P00712_A202CpjUpdData[0];
            n202CpjUpdData = P00712_n202CpjUpdData[0];
            A203CpjUpdHora = P00712_A203CpjUpdHora[0];
            n203CpjUpdHora = P00712_n203CpjUpdHora[0];
            A204CpjUpdDataHora = P00712_A204CpjUpdDataHora[0];
            n204CpjUpdDataHora = P00712_n204CpjUpdDataHora[0];
            A205CpjUpdUserID = P00712_A205CpjUpdUserID[0];
            n205CpjUpdUserID = P00712_n205CpjUpdUserID[0];
            A206CpjVersao = P00712_A206CpjVersao[0];
            A207CpjAtivo = P00712_A207CpjAtivo[0];
            A261CpjTelNum = P00712_A261CpjTelNum[0];
            n261CpjTelNum = P00712_n261CpjTelNum[0];
            A262CpjTelRam = P00712_A262CpjTelRam[0];
            n262CpjTelRam = P00712_n262CpjTelRam[0];
            A263CpjCelNum = P00712_A263CpjCelNum[0];
            n263CpjCelNum = P00712_n263CpjCelNum[0];
            A264CpjWppNum = P00712_A264CpjWppNum[0];
            n264CpjWppNum = P00712_n264CpjWppNum[0];
            A265CpjWebsite = P00712_A265CpjWebsite[0];
            n265CpjWebsite = P00712_n265CpjWebsite[0];
            A266CpjEmail = P00712_A266CpjEmail[0];
            n266CpjEmail = P00712_n266CpjEmail[0];
            A542CpjDel = P00712_A542CpjDel[0];
            A543CpjDelDataHora = P00712_A543CpjDelDataHora[0];
            n543CpjDelDataHora = P00712_n543CpjDelDataHora[0];
            A544CpjDelData = P00712_A544CpjDelData[0];
            n544CpjDelData = P00712_n544CpjDelData[0];
            A545CpjDelHora = P00712_A545CpjDelHora[0];
            n545CpjDelHora = P00712_n545CpjDelHora[0];
            A546CpjDelUsuId = P00712_A546CpjDelUsuId[0];
            n546CpjDelUsuId = P00712_n546CpjDelUsuId[0];
            A547CpjDelUsuNome = P00712_A547CpjDelUsuNome[0];
            n547CpjDelUsuNome = P00712_n547CpjDelUsuNome[0];
            A159CliMatricula = P00712_A159CliMatricula[0];
            A160CliNomeFamiliar = P00712_A160CliNomeFamiliar[0];
            A182CpjHolNomeFan = P00712_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = P00712_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = P00712_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = P00712_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = P00712_A193CpjHolCNPJFormat[0];
            A172CpjPaiNomeFan = P00712_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = P00712_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = P00712_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = P00712_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = P00712_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = P00712_A184CpjPaiTipoID[0];
            A185CpjPaiTipoSigla = P00712_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = P00712_A186CpjPaiTipoNome[0];
            A366CpjTipoSigla = P00712_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00712_A367CpjTipoNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A158CliID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliNomeFamiliar";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A160CliNomeFamiliar;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A166CpjID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A181CpjHolID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolNomeFan";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding Nome Fantasia";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A182CpjHolNomeFan;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolRazaoSoc";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding Razão Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A183CpjHolRazaoSoc;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding  Matricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A191CpjHolMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolCNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding CNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A192CpjHolCNPJ), 14, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolCNPJFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding CNPJ Formatado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A193CpjHolCNPJFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente Pai";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A169CpjPaiID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiNomeFan";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Nome Fantasia";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A172CpjPaiNomeFan;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiRazaoSoc";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Razão Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A173CpjPaiRazaoSoc;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Matricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A175CpjPaiMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiCNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai CNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A194CpjPaiCNPJ), 14, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiCNPJFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai CNPJ Formatado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A195CpjPaiCNPJFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A184CpjPaiTipoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A185CpjPaiTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A186CpjPaiTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A365CpjTipoId), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A366CpjTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A367CpjTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjNomeFan";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Fantasia";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A170CpjNomeFan;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjRazaoSoc";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A171CpjRazaoSoc;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjMatricula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A176CpjMatricula), 12, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A187CpjCNPJ), 14, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCNPJFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A188CpjCNPJFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjIE";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Inscrição Estadual";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A189CpjIE;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCapitalSoc";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Capital Social";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( A190CpjCapitalSoc, 16, 2);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A198CpjInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A199CpjInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsUserID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Usuário de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A201CpjInsUserID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A202CpjUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A203CpjUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Ultima Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A204CpjUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdUserID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A205CpjUpdUserID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjVersao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Cadastro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A206CpjVersao), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A207CpjAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTelNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Telefone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A261CpjTelNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTelRam";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A262CpjTelRam;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCelNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Celular";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A263CpjCelNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjWppNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "WhatsApp";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A264CpjWppNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjWebsite";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Website";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A265CpjWebsite;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEmail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "E-mail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A266CpjEmail;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A542CpjDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A544CpjDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A545CpjDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A546CpjDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A547CpjDelUsuNome;
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
         /* Using cursor P00713 */
         pr_default.execute(1, new Object[] {AV17CliID, AV18CpjID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A166CpjID = P00713_A166CpjID[0];
            A158CliID = P00713_A158CliID[0];
            A159CliMatricula = P00713_A159CliMatricula[0];
            A160CliNomeFamiliar = P00713_A160CliNomeFamiliar[0];
            A181CpjHolID = P00713_A181CpjHolID[0];
            n181CpjHolID = P00713_n181CpjHolID[0];
            A182CpjHolNomeFan = P00713_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = P00713_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = P00713_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = P00713_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = P00713_A193CpjHolCNPJFormat[0];
            A169CpjPaiID = P00713_A169CpjPaiID[0];
            n169CpjPaiID = P00713_n169CpjPaiID[0];
            A172CpjPaiNomeFan = P00713_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = P00713_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = P00713_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = P00713_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = P00713_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = P00713_A184CpjPaiTipoID[0];
            A185CpjPaiTipoSigla = P00713_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = P00713_A186CpjPaiTipoNome[0];
            A365CpjTipoId = P00713_A365CpjTipoId[0];
            A366CpjTipoSigla = P00713_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00713_A367CpjTipoNome[0];
            A170CpjNomeFan = P00713_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00713_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00713_A176CpjMatricula[0];
            A187CpjCNPJ = P00713_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00713_A188CpjCNPJFormat[0];
            A189CpjIE = P00713_A189CpjIE[0];
            A190CpjCapitalSoc = P00713_A190CpjCapitalSoc[0];
            A198CpjInsData = P00713_A198CpjInsData[0];
            A199CpjInsHora = P00713_A199CpjInsHora[0];
            A200CpjInsDataHora = P00713_A200CpjInsDataHora[0];
            A201CpjInsUserID = P00713_A201CpjInsUserID[0];
            n201CpjInsUserID = P00713_n201CpjInsUserID[0];
            A202CpjUpdData = P00713_A202CpjUpdData[0];
            n202CpjUpdData = P00713_n202CpjUpdData[0];
            A203CpjUpdHora = P00713_A203CpjUpdHora[0];
            n203CpjUpdHora = P00713_n203CpjUpdHora[0];
            A204CpjUpdDataHora = P00713_A204CpjUpdDataHora[0];
            n204CpjUpdDataHora = P00713_n204CpjUpdDataHora[0];
            A205CpjUpdUserID = P00713_A205CpjUpdUserID[0];
            n205CpjUpdUserID = P00713_n205CpjUpdUserID[0];
            A206CpjVersao = P00713_A206CpjVersao[0];
            A207CpjAtivo = P00713_A207CpjAtivo[0];
            A261CpjTelNum = P00713_A261CpjTelNum[0];
            n261CpjTelNum = P00713_n261CpjTelNum[0];
            A262CpjTelRam = P00713_A262CpjTelRam[0];
            n262CpjTelRam = P00713_n262CpjTelRam[0];
            A263CpjCelNum = P00713_A263CpjCelNum[0];
            n263CpjCelNum = P00713_n263CpjCelNum[0];
            A264CpjWppNum = P00713_A264CpjWppNum[0];
            n264CpjWppNum = P00713_n264CpjWppNum[0];
            A265CpjWebsite = P00713_A265CpjWebsite[0];
            n265CpjWebsite = P00713_n265CpjWebsite[0];
            A266CpjEmail = P00713_A266CpjEmail[0];
            n266CpjEmail = P00713_n266CpjEmail[0];
            A542CpjDel = P00713_A542CpjDel[0];
            A543CpjDelDataHora = P00713_A543CpjDelDataHora[0];
            n543CpjDelDataHora = P00713_n543CpjDelDataHora[0];
            A544CpjDelData = P00713_A544CpjDelData[0];
            n544CpjDelData = P00713_n544CpjDelData[0];
            A545CpjDelHora = P00713_A545CpjDelHora[0];
            n545CpjDelHora = P00713_n545CpjDelHora[0];
            A546CpjDelUsuId = P00713_A546CpjDelUsuId[0];
            n546CpjDelUsuId = P00713_n546CpjDelUsuId[0];
            A547CpjDelUsuNome = P00713_A547CpjDelUsuNome[0];
            n547CpjDelUsuNome = P00713_n547CpjDelUsuNome[0];
            A159CliMatricula = P00713_A159CliMatricula[0];
            A160CliNomeFamiliar = P00713_A160CliNomeFamiliar[0];
            A182CpjHolNomeFan = P00713_A182CpjHolNomeFan[0];
            A183CpjHolRazaoSoc = P00713_A183CpjHolRazaoSoc[0];
            A191CpjHolMatricula = P00713_A191CpjHolMatricula[0];
            A192CpjHolCNPJ = P00713_A192CpjHolCNPJ[0];
            A193CpjHolCNPJFormat = P00713_A193CpjHolCNPJFormat[0];
            A172CpjPaiNomeFan = P00713_A172CpjPaiNomeFan[0];
            A173CpjPaiRazaoSoc = P00713_A173CpjPaiRazaoSoc[0];
            A175CpjPaiMatricula = P00713_A175CpjPaiMatricula[0];
            A194CpjPaiCNPJ = P00713_A194CpjPaiCNPJ[0];
            A195CpjPaiCNPJFormat = P00713_A195CpjPaiCNPJFormat[0];
            A184CpjPaiTipoID = P00713_A184CpjPaiTipoID[0];
            A185CpjPaiTipoSigla = P00713_A185CpjPaiTipoSigla[0];
            A186CpjPaiTipoNome = P00713_A186CpjPaiTipoNome[0];
            A366CpjTipoSigla = P00713_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00713_A367CpjTipoNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A158CliID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliNomeFamiliar";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A160CliNomeFamiliar;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A166CpjID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A181CpjHolID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolNomeFan";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding Nome Fantasia";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A182CpjHolNomeFan;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolRazaoSoc";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding Razão Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A183CpjHolRazaoSoc;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding  Matricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A191CpjHolMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolCNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding CNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A192CpjHolCNPJ), 14, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjHolCNPJFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Holding CNPJ Formatado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A193CpjHolCNPJFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente Pai";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A169CpjPaiID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiNomeFan";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Nome Fantasia";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A172CpjPaiNomeFan;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiRazaoSoc";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Razão Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A173CpjPaiRazaoSoc;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Matricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A175CpjPaiMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiCNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai CNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A194CpjPaiCNPJ), 14, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiCNPJFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai CNPJ Formatado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A195CpjPaiCNPJFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A184CpjPaiTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A185CpjPaiTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjPaiTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente PJ Pai Tipo Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A186CpjPaiTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A365CpjTipoId), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A366CpjTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A367CpjTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjNomeFan";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome Fantasia";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A170CpjNomeFan;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjRazaoSoc";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Razão Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A171CpjRazaoSoc;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjMatricula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Matrícula";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A176CpjMatricula), 12, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A187CpjCNPJ), 14, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCNPJFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A188CpjCNPJFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjIE";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Inscrição Estadual";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A189CpjIE;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCapitalSoc";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Capital Social";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A190CpjCapitalSoc, 16, 2);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A198CpjInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A199CpjInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjInsUserID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID do Usuário de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A201CpjInsUserID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A202CpjUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A203CpjUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Ultima Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A204CpjUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUpdUserID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário Responsável pela Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A205CpjUpdUserID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjVersao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Cadastro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A206CpjVersao), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A207CpjAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTelNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Telefone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A261CpjTelNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTelRam";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A262CpjTelRam;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjCelNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Celular";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A263CpjCelNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjWppNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "WhatsApp";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A264CpjWppNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjWebsite";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Website";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A265CpjWebsite;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "E-mail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A266CpjEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A542CpjDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A544CpjDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A545CpjDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A546CpjDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A547CpjDelUsuNome;
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
                     if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A158CliID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliMatricula") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A159CliMatricula), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CliNomeFamiliar") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A160CliNomeFamiliar;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A166CpjID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A181CpjHolID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolNomeFan") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A182CpjHolNomeFan;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolRazaoSoc") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A183CpjHolRazaoSoc;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolMatricula") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A191CpjHolMatricula), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolCNPJ") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A192CpjHolCNPJ), 14, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjHolCNPJFormat") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A193CpjHolCNPJFormat;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A169CpjPaiID.ToString();
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiNomeFan") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A172CpjPaiNomeFan;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiRazaoSoc") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A173CpjPaiRazaoSoc;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiMatricula") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A175CpjPaiMatricula), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiCNPJ") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A194CpjPaiCNPJ), 14, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiCNPJFormat") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A195CpjPaiCNPJFormat;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiTipoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A184CpjPaiTipoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiTipoSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A185CpjPaiTipoSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjPaiTipoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A186CpjPaiTipoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjTipoId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A365CpjTipoId), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjTipoSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A366CpjTipoSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjTipoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A367CpjTipoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjNomeFan") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A170CpjNomeFan;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjRazaoSoc") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A171CpjRazaoSoc;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjMatricula") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A176CpjMatricula), 12, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjCNPJ") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A187CpjCNPJ), 14, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjCNPJFormat") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A188CpjCNPJFormat;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjIE") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A189CpjIE;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjCapitalSoc") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( A190CpjCapitalSoc, 16, 2);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjInsData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A198CpjInsData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjInsHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A199CpjInsHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjInsDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A200CpjInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjInsUserID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A201CpjInsUserID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUpdData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A202CpjUpdData, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUpdHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A203CpjUpdHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUpdDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A204CpjUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUpdUserID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A205CpjUpdUserID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjVersao") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A206CpjVersao), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A207CpjAtivo);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjTelNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A261CpjTelNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjTelRam") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A262CpjTelRam;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjCelNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A263CpjCelNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjWppNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A264CpjWppNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjWebsite") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A265CpjWebsite;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEmail") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A266CpjEmail;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A542CpjDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A543CpjDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A544CpjDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A545CpjDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A546CpjDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A547CpjDelUsuNome;
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
         P00712_A166CpjID = new Guid[] {Guid.Empty} ;
         P00712_A158CliID = new Guid[] {Guid.Empty} ;
         P00712_A159CliMatricula = new long[1] ;
         P00712_A160CliNomeFamiliar = new string[] {""} ;
         P00712_A181CpjHolID = new Guid[] {Guid.Empty} ;
         P00712_n181CpjHolID = new bool[] {false} ;
         P00712_A182CpjHolNomeFan = new string[] {""} ;
         P00712_A183CpjHolRazaoSoc = new string[] {""} ;
         P00712_A191CpjHolMatricula = new long[1] ;
         P00712_A192CpjHolCNPJ = new long[1] ;
         P00712_A193CpjHolCNPJFormat = new string[] {""} ;
         P00712_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         P00712_n169CpjPaiID = new bool[] {false} ;
         P00712_A172CpjPaiNomeFan = new string[] {""} ;
         P00712_A173CpjPaiRazaoSoc = new string[] {""} ;
         P00712_A175CpjPaiMatricula = new long[1] ;
         P00712_A194CpjPaiCNPJ = new long[1] ;
         P00712_A195CpjPaiCNPJFormat = new string[] {""} ;
         P00712_A184CpjPaiTipoID = new int[1] ;
         P00712_A185CpjPaiTipoSigla = new string[] {""} ;
         P00712_A186CpjPaiTipoNome = new string[] {""} ;
         P00712_A365CpjTipoId = new int[1] ;
         P00712_A366CpjTipoSigla = new string[] {""} ;
         P00712_A367CpjTipoNome = new string[] {""} ;
         P00712_A170CpjNomeFan = new string[] {""} ;
         P00712_A171CpjRazaoSoc = new string[] {""} ;
         P00712_A176CpjMatricula = new long[1] ;
         P00712_A187CpjCNPJ = new long[1] ;
         P00712_A188CpjCNPJFormat = new string[] {""} ;
         P00712_A189CpjIE = new string[] {""} ;
         P00712_A190CpjCapitalSoc = new decimal[1] ;
         P00712_A198CpjInsData = new DateTime[] {DateTime.MinValue} ;
         P00712_A199CpjInsHora = new DateTime[] {DateTime.MinValue} ;
         P00712_A200CpjInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00712_A201CpjInsUserID = new string[] {""} ;
         P00712_n201CpjInsUserID = new bool[] {false} ;
         P00712_A202CpjUpdData = new DateTime[] {DateTime.MinValue} ;
         P00712_n202CpjUpdData = new bool[] {false} ;
         P00712_A203CpjUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00712_n203CpjUpdHora = new bool[] {false} ;
         P00712_A204CpjUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00712_n204CpjUpdDataHora = new bool[] {false} ;
         P00712_A205CpjUpdUserID = new string[] {""} ;
         P00712_n205CpjUpdUserID = new bool[] {false} ;
         P00712_A206CpjVersao = new short[1] ;
         P00712_A207CpjAtivo = new bool[] {false} ;
         P00712_A261CpjTelNum = new string[] {""} ;
         P00712_n261CpjTelNum = new bool[] {false} ;
         P00712_A262CpjTelRam = new string[] {""} ;
         P00712_n262CpjTelRam = new bool[] {false} ;
         P00712_A263CpjCelNum = new string[] {""} ;
         P00712_n263CpjCelNum = new bool[] {false} ;
         P00712_A264CpjWppNum = new string[] {""} ;
         P00712_n264CpjWppNum = new bool[] {false} ;
         P00712_A265CpjWebsite = new string[] {""} ;
         P00712_n265CpjWebsite = new bool[] {false} ;
         P00712_A266CpjEmail = new string[] {""} ;
         P00712_n266CpjEmail = new bool[] {false} ;
         P00712_A542CpjDel = new bool[] {false} ;
         P00712_A543CpjDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00712_n543CpjDelDataHora = new bool[] {false} ;
         P00712_A544CpjDelData = new DateTime[] {DateTime.MinValue} ;
         P00712_n544CpjDelData = new bool[] {false} ;
         P00712_A545CpjDelHora = new DateTime[] {DateTime.MinValue} ;
         P00712_n545CpjDelHora = new bool[] {false} ;
         P00712_A546CpjDelUsuId = new string[] {""} ;
         P00712_n546CpjDelUsuId = new bool[] {false} ;
         P00712_A547CpjDelUsuNome = new string[] {""} ;
         P00712_n547CpjDelUsuNome = new bool[] {false} ;
         A166CpjID = Guid.Empty;
         A158CliID = Guid.Empty;
         A160CliNomeFamiliar = "";
         A181CpjHolID = Guid.Empty;
         A182CpjHolNomeFan = "";
         A183CpjHolRazaoSoc = "";
         A193CpjHolCNPJFormat = "";
         A169CpjPaiID = Guid.Empty;
         A172CpjPaiNomeFan = "";
         A173CpjPaiRazaoSoc = "";
         A195CpjPaiCNPJFormat = "";
         A185CpjPaiTipoSigla = "";
         A186CpjPaiTipoNome = "";
         A366CpjTipoSigla = "";
         A367CpjTipoNome = "";
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         A198CpjInsData = DateTime.MinValue;
         A199CpjInsHora = (DateTime)(DateTime.MinValue);
         A200CpjInsDataHora = (DateTime)(DateTime.MinValue);
         A201CpjInsUserID = "";
         A202CpjUpdData = DateTime.MinValue;
         A203CpjUpdHora = (DateTime)(DateTime.MinValue);
         A204CpjUpdDataHora = (DateTime)(DateTime.MinValue);
         A205CpjUpdUserID = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A263CpjCelNum = "";
         A264CpjWppNum = "";
         A265CpjWebsite = "";
         A266CpjEmail = "";
         A543CpjDelDataHora = (DateTime)(DateTime.MinValue);
         A544CpjDelData = (DateTime)(DateTime.MinValue);
         A545CpjDelHora = (DateTime)(DateTime.MinValue);
         A546CpjDelUsuId = "";
         A547CpjDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00713_A166CpjID = new Guid[] {Guid.Empty} ;
         P00713_A158CliID = new Guid[] {Guid.Empty} ;
         P00713_A159CliMatricula = new long[1] ;
         P00713_A160CliNomeFamiliar = new string[] {""} ;
         P00713_A181CpjHolID = new Guid[] {Guid.Empty} ;
         P00713_n181CpjHolID = new bool[] {false} ;
         P00713_A182CpjHolNomeFan = new string[] {""} ;
         P00713_A183CpjHolRazaoSoc = new string[] {""} ;
         P00713_A191CpjHolMatricula = new long[1] ;
         P00713_A192CpjHolCNPJ = new long[1] ;
         P00713_A193CpjHolCNPJFormat = new string[] {""} ;
         P00713_A169CpjPaiID = new Guid[] {Guid.Empty} ;
         P00713_n169CpjPaiID = new bool[] {false} ;
         P00713_A172CpjPaiNomeFan = new string[] {""} ;
         P00713_A173CpjPaiRazaoSoc = new string[] {""} ;
         P00713_A175CpjPaiMatricula = new long[1] ;
         P00713_A194CpjPaiCNPJ = new long[1] ;
         P00713_A195CpjPaiCNPJFormat = new string[] {""} ;
         P00713_A184CpjPaiTipoID = new int[1] ;
         P00713_A185CpjPaiTipoSigla = new string[] {""} ;
         P00713_A186CpjPaiTipoNome = new string[] {""} ;
         P00713_A365CpjTipoId = new int[1] ;
         P00713_A366CpjTipoSigla = new string[] {""} ;
         P00713_A367CpjTipoNome = new string[] {""} ;
         P00713_A170CpjNomeFan = new string[] {""} ;
         P00713_A171CpjRazaoSoc = new string[] {""} ;
         P00713_A176CpjMatricula = new long[1] ;
         P00713_A187CpjCNPJ = new long[1] ;
         P00713_A188CpjCNPJFormat = new string[] {""} ;
         P00713_A189CpjIE = new string[] {""} ;
         P00713_A190CpjCapitalSoc = new decimal[1] ;
         P00713_A198CpjInsData = new DateTime[] {DateTime.MinValue} ;
         P00713_A199CpjInsHora = new DateTime[] {DateTime.MinValue} ;
         P00713_A200CpjInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P00713_A201CpjInsUserID = new string[] {""} ;
         P00713_n201CpjInsUserID = new bool[] {false} ;
         P00713_A202CpjUpdData = new DateTime[] {DateTime.MinValue} ;
         P00713_n202CpjUpdData = new bool[] {false} ;
         P00713_A203CpjUpdHora = new DateTime[] {DateTime.MinValue} ;
         P00713_n203CpjUpdHora = new bool[] {false} ;
         P00713_A204CpjUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P00713_n204CpjUpdDataHora = new bool[] {false} ;
         P00713_A205CpjUpdUserID = new string[] {""} ;
         P00713_n205CpjUpdUserID = new bool[] {false} ;
         P00713_A206CpjVersao = new short[1] ;
         P00713_A207CpjAtivo = new bool[] {false} ;
         P00713_A261CpjTelNum = new string[] {""} ;
         P00713_n261CpjTelNum = new bool[] {false} ;
         P00713_A262CpjTelRam = new string[] {""} ;
         P00713_n262CpjTelRam = new bool[] {false} ;
         P00713_A263CpjCelNum = new string[] {""} ;
         P00713_n263CpjCelNum = new bool[] {false} ;
         P00713_A264CpjWppNum = new string[] {""} ;
         P00713_n264CpjWppNum = new bool[] {false} ;
         P00713_A265CpjWebsite = new string[] {""} ;
         P00713_n265CpjWebsite = new bool[] {false} ;
         P00713_A266CpjEmail = new string[] {""} ;
         P00713_n266CpjEmail = new bool[] {false} ;
         P00713_A542CpjDel = new bool[] {false} ;
         P00713_A543CpjDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00713_n543CpjDelDataHora = new bool[] {false} ;
         P00713_A544CpjDelData = new DateTime[] {DateTime.MinValue} ;
         P00713_n544CpjDelData = new bool[] {false} ;
         P00713_A545CpjDelHora = new DateTime[] {DateTime.MinValue} ;
         P00713_n545CpjDelHora = new bool[] {false} ;
         P00713_A546CpjDelUsuId = new string[] {""} ;
         P00713_n546CpjDelUsuId = new bool[] {false} ;
         P00713_A547CpjDelUsuNome = new string[] {""} ;
         P00713_n547CpjDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditclientepj__default(),
            new Object[][] {
                new Object[] {
               P00712_A166CpjID, P00712_A158CliID, P00712_A159CliMatricula, P00712_A160CliNomeFamiliar, P00712_A181CpjHolID, P00712_n181CpjHolID, P00712_A182CpjHolNomeFan, P00712_A183CpjHolRazaoSoc, P00712_A191CpjHolMatricula, P00712_A192CpjHolCNPJ,
               P00712_A193CpjHolCNPJFormat, P00712_A169CpjPaiID, P00712_n169CpjPaiID, P00712_A172CpjPaiNomeFan, P00712_A173CpjPaiRazaoSoc, P00712_A175CpjPaiMatricula, P00712_A194CpjPaiCNPJ, P00712_A195CpjPaiCNPJFormat, P00712_A184CpjPaiTipoID, P00712_A185CpjPaiTipoSigla,
               P00712_A186CpjPaiTipoNome, P00712_A365CpjTipoId, P00712_A366CpjTipoSigla, P00712_A367CpjTipoNome, P00712_A170CpjNomeFan, P00712_A171CpjRazaoSoc, P00712_A176CpjMatricula, P00712_A187CpjCNPJ, P00712_A188CpjCNPJFormat, P00712_A189CpjIE,
               P00712_A190CpjCapitalSoc, P00712_A198CpjInsData, P00712_A199CpjInsHora, P00712_A200CpjInsDataHora, P00712_A201CpjInsUserID, P00712_n201CpjInsUserID, P00712_A202CpjUpdData, P00712_n202CpjUpdData, P00712_A203CpjUpdHora, P00712_n203CpjUpdHora,
               P00712_A204CpjUpdDataHora, P00712_n204CpjUpdDataHora, P00712_A205CpjUpdUserID, P00712_n205CpjUpdUserID, P00712_A206CpjVersao, P00712_A207CpjAtivo, P00712_A261CpjTelNum, P00712_n261CpjTelNum, P00712_A262CpjTelRam, P00712_n262CpjTelRam,
               P00712_A263CpjCelNum, P00712_n263CpjCelNum, P00712_A264CpjWppNum, P00712_n264CpjWppNum, P00712_A265CpjWebsite, P00712_n265CpjWebsite, P00712_A266CpjEmail, P00712_n266CpjEmail, P00712_A542CpjDel, P00712_A543CpjDelDataHora,
               P00712_n543CpjDelDataHora, P00712_A544CpjDelData, P00712_n544CpjDelData, P00712_A545CpjDelHora, P00712_n545CpjDelHora, P00712_A546CpjDelUsuId, P00712_n546CpjDelUsuId, P00712_A547CpjDelUsuNome, P00712_n547CpjDelUsuNome
               }
               , new Object[] {
               P00713_A166CpjID, P00713_A158CliID, P00713_A159CliMatricula, P00713_A160CliNomeFamiliar, P00713_A181CpjHolID, P00713_n181CpjHolID, P00713_A182CpjHolNomeFan, P00713_A183CpjHolRazaoSoc, P00713_A191CpjHolMatricula, P00713_A192CpjHolCNPJ,
               P00713_A193CpjHolCNPJFormat, P00713_A169CpjPaiID, P00713_n169CpjPaiID, P00713_A172CpjPaiNomeFan, P00713_A173CpjPaiRazaoSoc, P00713_A175CpjPaiMatricula, P00713_A194CpjPaiCNPJ, P00713_A195CpjPaiCNPJFormat, P00713_A184CpjPaiTipoID, P00713_A185CpjPaiTipoSigla,
               P00713_A186CpjPaiTipoNome, P00713_A365CpjTipoId, P00713_A366CpjTipoSigla, P00713_A367CpjTipoNome, P00713_A170CpjNomeFan, P00713_A171CpjRazaoSoc, P00713_A176CpjMatricula, P00713_A187CpjCNPJ, P00713_A188CpjCNPJFormat, P00713_A189CpjIE,
               P00713_A190CpjCapitalSoc, P00713_A198CpjInsData, P00713_A199CpjInsHora, P00713_A200CpjInsDataHora, P00713_A201CpjInsUserID, P00713_n201CpjInsUserID, P00713_A202CpjUpdData, P00713_n202CpjUpdData, P00713_A203CpjUpdHora, P00713_n203CpjUpdHora,
               P00713_A204CpjUpdDataHora, P00713_n204CpjUpdDataHora, P00713_A205CpjUpdUserID, P00713_n205CpjUpdUserID, P00713_A206CpjVersao, P00713_A207CpjAtivo, P00713_A261CpjTelNum, P00713_n261CpjTelNum, P00713_A262CpjTelRam, P00713_n262CpjTelRam,
               P00713_A263CpjCelNum, P00713_n263CpjCelNum, P00713_A264CpjWppNum, P00713_n264CpjWppNum, P00713_A265CpjWebsite, P00713_n265CpjWebsite, P00713_A266CpjEmail, P00713_n266CpjEmail, P00713_A542CpjDel, P00713_A543CpjDelDataHora,
               P00713_n543CpjDelDataHora, P00713_A544CpjDelData, P00713_n544CpjDelData, P00713_A545CpjDelHora, P00713_n545CpjDelHora, P00713_A546CpjDelUsuId, P00713_n546CpjDelUsuId, P00713_A547CpjDelUsuNome, P00713_n547CpjDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A206CpjVersao ;
      private int A184CpjPaiTipoID ;
      private int A365CpjTipoId ;
      private int AV21GXV1 ;
      private int AV22GXV2 ;
      private long A159CliMatricula ;
      private long A191CpjHolMatricula ;
      private long A192CpjHolCNPJ ;
      private long A175CpjPaiMatricula ;
      private long A194CpjPaiCNPJ ;
      private long A176CpjMatricula ;
      private long A187CpjCNPJ ;
      private decimal A190CpjCapitalSoc ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A201CpjInsUserID ;
      private string A205CpjUpdUserID ;
      private string A261CpjTelNum ;
      private string A263CpjCelNum ;
      private string A264CpjWppNum ;
      private string A546CpjDelUsuId ;
      private DateTime A199CpjInsHora ;
      private DateTime A200CpjInsDataHora ;
      private DateTime A203CpjUpdHora ;
      private DateTime A204CpjUpdDataHora ;
      private DateTime A543CpjDelDataHora ;
      private DateTime A544CpjDelData ;
      private DateTime A545CpjDelHora ;
      private DateTime A198CpjInsData ;
      private DateTime A202CpjUpdData ;
      private bool returnInSub ;
      private bool n181CpjHolID ;
      private bool n169CpjPaiID ;
      private bool n201CpjInsUserID ;
      private bool n202CpjUpdData ;
      private bool n203CpjUpdHora ;
      private bool n204CpjUpdDataHora ;
      private bool n205CpjUpdUserID ;
      private bool A207CpjAtivo ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool A542CpjDel ;
      private bool n543CpjDelDataHora ;
      private bool n544CpjDelData ;
      private bool n545CpjDelHora ;
      private bool n546CpjDelUsuId ;
      private bool n547CpjDelUsuNome ;
      private string A160CliNomeFamiliar ;
      private string A182CpjHolNomeFan ;
      private string A183CpjHolRazaoSoc ;
      private string A193CpjHolCNPJFormat ;
      private string A172CpjPaiNomeFan ;
      private string A173CpjPaiRazaoSoc ;
      private string A195CpjPaiCNPJFormat ;
      private string A185CpjPaiTipoSigla ;
      private string A186CpjPaiTipoNome ;
      private string A366CpjTipoSigla ;
      private string A367CpjTipoNome ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A265CpjWebsite ;
      private string A266CpjEmail ;
      private string A547CpjDelUsuNome ;
      private Guid AV17CliID ;
      private Guid AV18CpjID ;
      private Guid A166CpjID ;
      private Guid A158CliID ;
      private Guid A181CpjHolID ;
      private Guid A169CpjPaiID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P00712_A166CpjID ;
      private Guid[] P00712_A158CliID ;
      private long[] P00712_A159CliMatricula ;
      private string[] P00712_A160CliNomeFamiliar ;
      private Guid[] P00712_A181CpjHolID ;
      private bool[] P00712_n181CpjHolID ;
      private string[] P00712_A182CpjHolNomeFan ;
      private string[] P00712_A183CpjHolRazaoSoc ;
      private long[] P00712_A191CpjHolMatricula ;
      private long[] P00712_A192CpjHolCNPJ ;
      private string[] P00712_A193CpjHolCNPJFormat ;
      private Guid[] P00712_A169CpjPaiID ;
      private bool[] P00712_n169CpjPaiID ;
      private string[] P00712_A172CpjPaiNomeFan ;
      private string[] P00712_A173CpjPaiRazaoSoc ;
      private long[] P00712_A175CpjPaiMatricula ;
      private long[] P00712_A194CpjPaiCNPJ ;
      private string[] P00712_A195CpjPaiCNPJFormat ;
      private int[] P00712_A184CpjPaiTipoID ;
      private string[] P00712_A185CpjPaiTipoSigla ;
      private string[] P00712_A186CpjPaiTipoNome ;
      private int[] P00712_A365CpjTipoId ;
      private string[] P00712_A366CpjTipoSigla ;
      private string[] P00712_A367CpjTipoNome ;
      private string[] P00712_A170CpjNomeFan ;
      private string[] P00712_A171CpjRazaoSoc ;
      private long[] P00712_A176CpjMatricula ;
      private long[] P00712_A187CpjCNPJ ;
      private string[] P00712_A188CpjCNPJFormat ;
      private string[] P00712_A189CpjIE ;
      private decimal[] P00712_A190CpjCapitalSoc ;
      private DateTime[] P00712_A198CpjInsData ;
      private DateTime[] P00712_A199CpjInsHora ;
      private DateTime[] P00712_A200CpjInsDataHora ;
      private string[] P00712_A201CpjInsUserID ;
      private bool[] P00712_n201CpjInsUserID ;
      private DateTime[] P00712_A202CpjUpdData ;
      private bool[] P00712_n202CpjUpdData ;
      private DateTime[] P00712_A203CpjUpdHora ;
      private bool[] P00712_n203CpjUpdHora ;
      private DateTime[] P00712_A204CpjUpdDataHora ;
      private bool[] P00712_n204CpjUpdDataHora ;
      private string[] P00712_A205CpjUpdUserID ;
      private bool[] P00712_n205CpjUpdUserID ;
      private short[] P00712_A206CpjVersao ;
      private bool[] P00712_A207CpjAtivo ;
      private string[] P00712_A261CpjTelNum ;
      private bool[] P00712_n261CpjTelNum ;
      private string[] P00712_A262CpjTelRam ;
      private bool[] P00712_n262CpjTelRam ;
      private string[] P00712_A263CpjCelNum ;
      private bool[] P00712_n263CpjCelNum ;
      private string[] P00712_A264CpjWppNum ;
      private bool[] P00712_n264CpjWppNum ;
      private string[] P00712_A265CpjWebsite ;
      private bool[] P00712_n265CpjWebsite ;
      private string[] P00712_A266CpjEmail ;
      private bool[] P00712_n266CpjEmail ;
      private bool[] P00712_A542CpjDel ;
      private DateTime[] P00712_A543CpjDelDataHora ;
      private bool[] P00712_n543CpjDelDataHora ;
      private DateTime[] P00712_A544CpjDelData ;
      private bool[] P00712_n544CpjDelData ;
      private DateTime[] P00712_A545CpjDelHora ;
      private bool[] P00712_n545CpjDelHora ;
      private string[] P00712_A546CpjDelUsuId ;
      private bool[] P00712_n546CpjDelUsuId ;
      private string[] P00712_A547CpjDelUsuNome ;
      private bool[] P00712_n547CpjDelUsuNome ;
      private Guid[] P00713_A166CpjID ;
      private Guid[] P00713_A158CliID ;
      private long[] P00713_A159CliMatricula ;
      private string[] P00713_A160CliNomeFamiliar ;
      private Guid[] P00713_A181CpjHolID ;
      private bool[] P00713_n181CpjHolID ;
      private string[] P00713_A182CpjHolNomeFan ;
      private string[] P00713_A183CpjHolRazaoSoc ;
      private long[] P00713_A191CpjHolMatricula ;
      private long[] P00713_A192CpjHolCNPJ ;
      private string[] P00713_A193CpjHolCNPJFormat ;
      private Guid[] P00713_A169CpjPaiID ;
      private bool[] P00713_n169CpjPaiID ;
      private string[] P00713_A172CpjPaiNomeFan ;
      private string[] P00713_A173CpjPaiRazaoSoc ;
      private long[] P00713_A175CpjPaiMatricula ;
      private long[] P00713_A194CpjPaiCNPJ ;
      private string[] P00713_A195CpjPaiCNPJFormat ;
      private int[] P00713_A184CpjPaiTipoID ;
      private string[] P00713_A185CpjPaiTipoSigla ;
      private string[] P00713_A186CpjPaiTipoNome ;
      private int[] P00713_A365CpjTipoId ;
      private string[] P00713_A366CpjTipoSigla ;
      private string[] P00713_A367CpjTipoNome ;
      private string[] P00713_A170CpjNomeFan ;
      private string[] P00713_A171CpjRazaoSoc ;
      private long[] P00713_A176CpjMatricula ;
      private long[] P00713_A187CpjCNPJ ;
      private string[] P00713_A188CpjCNPJFormat ;
      private string[] P00713_A189CpjIE ;
      private decimal[] P00713_A190CpjCapitalSoc ;
      private DateTime[] P00713_A198CpjInsData ;
      private DateTime[] P00713_A199CpjInsHora ;
      private DateTime[] P00713_A200CpjInsDataHora ;
      private string[] P00713_A201CpjInsUserID ;
      private bool[] P00713_n201CpjInsUserID ;
      private DateTime[] P00713_A202CpjUpdData ;
      private bool[] P00713_n202CpjUpdData ;
      private DateTime[] P00713_A203CpjUpdHora ;
      private bool[] P00713_n203CpjUpdHora ;
      private DateTime[] P00713_A204CpjUpdDataHora ;
      private bool[] P00713_n204CpjUpdDataHora ;
      private string[] P00713_A205CpjUpdUserID ;
      private bool[] P00713_n205CpjUpdUserID ;
      private short[] P00713_A206CpjVersao ;
      private bool[] P00713_A207CpjAtivo ;
      private string[] P00713_A261CpjTelNum ;
      private bool[] P00713_n261CpjTelNum ;
      private string[] P00713_A262CpjTelRam ;
      private bool[] P00713_n262CpjTelRam ;
      private string[] P00713_A263CpjCelNum ;
      private bool[] P00713_n263CpjCelNum ;
      private string[] P00713_A264CpjWppNum ;
      private bool[] P00713_n264CpjWppNum ;
      private string[] P00713_A265CpjWebsite ;
      private bool[] P00713_n265CpjWebsite ;
      private string[] P00713_A266CpjEmail ;
      private bool[] P00713_n266CpjEmail ;
      private bool[] P00713_A542CpjDel ;
      private DateTime[] P00713_A543CpjDelDataHora ;
      private bool[] P00713_n543CpjDelDataHora ;
      private DateTime[] P00713_A544CpjDelData ;
      private bool[] P00713_n544CpjDelData ;
      private DateTime[] P00713_A545CpjDelHora ;
      private bool[] P00713_n545CpjDelHora ;
      private string[] P00713_A546CpjDelUsuId ;
      private bool[] P00713_n546CpjDelUsuId ;
      private string[] P00713_A547CpjDelUsuNome ;
      private bool[] P00713_n547CpjDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditclientepj__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00712;
          prmP00712 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00713;
          prmP00713 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00712", "SELECT T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T1.CpjHolID AS CpjHolID, T3.CpjNomeFan AS CpjHolNomeFan, T3.CpjRazaoSoc AS CpjHolRazaoSoc, T3.CpjMatricula AS CpjHolMatricula, T3.CpjCNPJ AS CpjHolCNPJ, T3.CpjCNPJFormat AS CpjHolCNPJFormat, T1.CpjPaiID AS CpjPaiID, T4.CpjNomeFan AS CpjPaiNomeFan, T4.CpjRazaoSoc AS CpjPaiRazaoSoc, T4.CpjMatricula AS CpjPaiMatricula, T4.CpjCNPJ AS CpjPaiCNPJ, T4.CpjCNPJFormat AS CpjPaiCNPJFormat, T4.CpjTipoId AS CpjPaiTipoID, T5.PjtSigla AS CpjPaiTipoSigla, T5.PjtNome AS CpjPaiTipoNome, T1.CpjTipoId AS CpjTipoId, T6.PjtSigla AS CpjTipoSigla, T6.PjtNome AS CpjTipoNome, T1.CpjNomeFan, T1.CpjRazaoSoc, T1.CpjMatricula, T1.CpjCNPJ, T1.CpjCNPJFormat, T1.CpjIE, T1.CpjCapitalSoc, T1.CpjInsData, T1.CpjInsHora, T1.CpjInsDataHora, T1.CpjInsUserID, T1.CpjUpdData, T1.CpjUpdHora, T1.CpjUpdDataHora, T1.CpjUpdUserID, T1.CpjVersao, T1.CpjAtivo, T1.CpjTelNum, T1.CpjTelRam, T1.CpjCelNum, T1.CpjWppNum, T1.CpjWebsite, T1.CpjEmail, T1.CpjDel, T1.CpjDelDataHora, T1.CpjDelData, T1.CpjDelHora, T1.CpjDelUsuId, T1.CpjDelUsuNome FROM (((((tb_clientepj T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) LEFT JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjHolID) LEFT JOIN tb_clientepj T4 ON T4.CliID = T1.CliID AND T4.CpjID = T1.CpjPaiID) LEFT JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepjtipo T6 ON T6.PjtID = T1.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID ORDER BY T1.CliID, T1.CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00712,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00713", "SELECT T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T1.CpjHolID AS CpjHolID, T3.CpjNomeFan AS CpjHolNomeFan, T3.CpjRazaoSoc AS CpjHolRazaoSoc, T3.CpjMatricula AS CpjHolMatricula, T3.CpjCNPJ AS CpjHolCNPJ, T3.CpjCNPJFormat AS CpjHolCNPJFormat, T1.CpjPaiID AS CpjPaiID, T4.CpjNomeFan AS CpjPaiNomeFan, T4.CpjRazaoSoc AS CpjPaiRazaoSoc, T4.CpjMatricula AS CpjPaiMatricula, T4.CpjCNPJ AS CpjPaiCNPJ, T4.CpjCNPJFormat AS CpjPaiCNPJFormat, T4.CpjTipoId AS CpjPaiTipoID, T5.PjtSigla AS CpjPaiTipoSigla, T5.PjtNome AS CpjPaiTipoNome, T1.CpjTipoId AS CpjTipoId, T6.PjtSigla AS CpjTipoSigla, T6.PjtNome AS CpjTipoNome, T1.CpjNomeFan, T1.CpjRazaoSoc, T1.CpjMatricula, T1.CpjCNPJ, T1.CpjCNPJFormat, T1.CpjIE, T1.CpjCapitalSoc, T1.CpjInsData, T1.CpjInsHora, T1.CpjInsDataHora, T1.CpjInsUserID, T1.CpjUpdData, T1.CpjUpdHora, T1.CpjUpdDataHora, T1.CpjUpdUserID, T1.CpjVersao, T1.CpjAtivo, T1.CpjTelNum, T1.CpjTelRam, T1.CpjCelNum, T1.CpjWppNum, T1.CpjWebsite, T1.CpjEmail, T1.CpjDel, T1.CpjDelDataHora, T1.CpjDelData, T1.CpjDelHora, T1.CpjDelUsuId, T1.CpjDelUsuNome FROM (((((tb_clientepj T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) LEFT JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjHolID) LEFT JOIN tb_clientepj T4 ON T4.CliID = T1.CliID AND T4.CpjID = T1.CpjPaiID) LEFT JOIN tb_clientepjtipo T5 ON T5.PjtID = T4.CpjTipoId) INNER JOIN tb_clientepjtipo T6 ON T6.PjtID = T1.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID ORDER BY T1.CliID, T1.CpjID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00713,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((int[]) buf[21])[0] = rslt.getInt(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((long[]) buf[26])[0] = rslt.getLong(25);
                ((long[]) buf[27])[0] = rslt.getLong(26);
                ((string[]) buf[28])[0] = rslt.getVarchar(27);
                ((string[]) buf[29])[0] = rslt.getVarchar(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((DateTime[]) buf[31])[0] = rslt.getGXDate(30);
                ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(31);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(32, true);
                ((string[]) buf[34])[0] = rslt.getString(33, 40);
                ((bool[]) buf[35])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(34);
                ((bool[]) buf[37])[0] = rslt.wasNull(34);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(35);
                ((bool[]) buf[39])[0] = rslt.wasNull(35);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(36, true);
                ((bool[]) buf[41])[0] = rslt.wasNull(36);
                ((string[]) buf[42])[0] = rslt.getString(37, 40);
                ((bool[]) buf[43])[0] = rslt.wasNull(37);
                ((short[]) buf[44])[0] = rslt.getShort(38);
                ((bool[]) buf[45])[0] = rslt.getBool(39);
                ((string[]) buf[46])[0] = rslt.getString(40, 20);
                ((bool[]) buf[47])[0] = rslt.wasNull(40);
                ((string[]) buf[48])[0] = rslt.getVarchar(41);
                ((bool[]) buf[49])[0] = rslt.wasNull(41);
                ((string[]) buf[50])[0] = rslt.getString(42, 20);
                ((bool[]) buf[51])[0] = rslt.wasNull(42);
                ((string[]) buf[52])[0] = rslt.getString(43, 20);
                ((bool[]) buf[53])[0] = rslt.wasNull(43);
                ((string[]) buf[54])[0] = rslt.getVarchar(44);
                ((bool[]) buf[55])[0] = rslt.wasNull(44);
                ((string[]) buf[56])[0] = rslt.getVarchar(45);
                ((bool[]) buf[57])[0] = rslt.wasNull(45);
                ((bool[]) buf[58])[0] = rslt.getBool(46);
                ((DateTime[]) buf[59])[0] = rslt.getGXDateTime(47, true);
                ((bool[]) buf[60])[0] = rslt.wasNull(47);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(48);
                ((bool[]) buf[62])[0] = rslt.wasNull(48);
                ((DateTime[]) buf[63])[0] = rslt.getGXDateTime(49);
                ((bool[]) buf[64])[0] = rslt.wasNull(49);
                ((string[]) buf[65])[0] = rslt.getString(50, 40);
                ((bool[]) buf[66])[0] = rslt.wasNull(50);
                ((string[]) buf[67])[0] = rslt.getVarchar(51);
                ((bool[]) buf[68])[0] = rslt.wasNull(51);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((bool[]) buf[5])[0] = rslt.wasNull(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((string[]) buf[7])[0] = rslt.getVarchar(7);
                ((long[]) buf[8])[0] = rslt.getLong(8);
                ((long[]) buf[9])[0] = rslt.getLong(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((Guid[]) buf[11])[0] = rslt.getGuid(11);
                ((bool[]) buf[12])[0] = rslt.wasNull(11);
                ((string[]) buf[13])[0] = rslt.getVarchar(12);
                ((string[]) buf[14])[0] = rslt.getVarchar(13);
                ((long[]) buf[15])[0] = rslt.getLong(14);
                ((long[]) buf[16])[0] = rslt.getLong(15);
                ((string[]) buf[17])[0] = rslt.getVarchar(16);
                ((int[]) buf[18])[0] = rslt.getInt(17);
                ((string[]) buf[19])[0] = rslt.getVarchar(18);
                ((string[]) buf[20])[0] = rslt.getVarchar(19);
                ((int[]) buf[21])[0] = rslt.getInt(20);
                ((string[]) buf[22])[0] = rslt.getVarchar(21);
                ((string[]) buf[23])[0] = rslt.getVarchar(22);
                ((string[]) buf[24])[0] = rslt.getVarchar(23);
                ((string[]) buf[25])[0] = rslt.getVarchar(24);
                ((long[]) buf[26])[0] = rslt.getLong(25);
                ((long[]) buf[27])[0] = rslt.getLong(26);
                ((string[]) buf[28])[0] = rslt.getVarchar(27);
                ((string[]) buf[29])[0] = rslt.getVarchar(28);
                ((decimal[]) buf[30])[0] = rslt.getDecimal(29);
                ((DateTime[]) buf[31])[0] = rslt.getGXDate(30);
                ((DateTime[]) buf[32])[0] = rslt.getGXDateTime(31);
                ((DateTime[]) buf[33])[0] = rslt.getGXDateTime(32, true);
                ((string[]) buf[34])[0] = rslt.getString(33, 40);
                ((bool[]) buf[35])[0] = rslt.wasNull(33);
                ((DateTime[]) buf[36])[0] = rslt.getGXDate(34);
                ((bool[]) buf[37])[0] = rslt.wasNull(34);
                ((DateTime[]) buf[38])[0] = rslt.getGXDateTime(35);
                ((bool[]) buf[39])[0] = rslt.wasNull(35);
                ((DateTime[]) buf[40])[0] = rslt.getGXDateTime(36, true);
                ((bool[]) buf[41])[0] = rslt.wasNull(36);
                ((string[]) buf[42])[0] = rslt.getString(37, 40);
                ((bool[]) buf[43])[0] = rslt.wasNull(37);
                ((short[]) buf[44])[0] = rslt.getShort(38);
                ((bool[]) buf[45])[0] = rslt.getBool(39);
                ((string[]) buf[46])[0] = rslt.getString(40, 20);
                ((bool[]) buf[47])[0] = rslt.wasNull(40);
                ((string[]) buf[48])[0] = rslt.getVarchar(41);
                ((bool[]) buf[49])[0] = rslt.wasNull(41);
                ((string[]) buf[50])[0] = rslt.getString(42, 20);
                ((bool[]) buf[51])[0] = rslt.wasNull(42);
                ((string[]) buf[52])[0] = rslt.getString(43, 20);
                ((bool[]) buf[53])[0] = rslt.wasNull(43);
                ((string[]) buf[54])[0] = rslt.getVarchar(44);
                ((bool[]) buf[55])[0] = rslt.wasNull(44);
                ((string[]) buf[56])[0] = rslt.getVarchar(45);
                ((bool[]) buf[57])[0] = rslt.wasNull(45);
                ((bool[]) buf[58])[0] = rslt.getBool(46);
                ((DateTime[]) buf[59])[0] = rslt.getGXDateTime(47, true);
                ((bool[]) buf[60])[0] = rslt.wasNull(47);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(48);
                ((bool[]) buf[62])[0] = rslt.wasNull(48);
                ((DateTime[]) buf[63])[0] = rslt.getGXDateTime(49);
                ((bool[]) buf[64])[0] = rslt.wasNull(49);
                ((string[]) buf[65])[0] = rslt.getString(50, 40);
                ((bool[]) buf[66])[0] = rslt.wasNull(50);
                ((string[]) buf[67])[0] = rslt.getVarchar(51);
                ((bool[]) buf[68])[0] = rslt.wasNull(51);
                return;
       }
    }

 }

}
