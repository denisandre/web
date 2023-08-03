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
   public class loadauditclientepjendereco : GXProcedure
   {
      public loadauditclientepjendereco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditclientepjendereco( IGxContext context )
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
                           short aP4_CpjEndSeq ,
                           string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17CliID = aP2_CliID;
         this.AV18CpjID = aP3_CpjID;
         this.AV19CpjEndSeq = aP4_CpjEndSeq;
         this.AV15ActualMode = aP5_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_CliID ,
                                 Guid aP3_CpjID ,
                                 short aP4_CpjEndSeq ,
                                 string aP5_ActualMode )
      {
         loadauditclientepjendereco objloadauditclientepjendereco;
         objloadauditclientepjendereco = new loadauditclientepjendereco();
         objloadauditclientepjendereco.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditclientepjendereco.AV11AuditingObject = aP1_AuditingObject;
         objloadauditclientepjendereco.AV17CliID = aP2_CliID;
         objloadauditclientepjendereco.AV18CpjID = aP3_CpjID;
         objloadauditclientepjendereco.AV19CpjEndSeq = aP4_CpjEndSeq;
         objloadauditclientepjendereco.AV15ActualMode = aP5_ActualMode;
         objloadauditclientepjendereco.context.SetSubmitInitialConfig(context);
         objloadauditclientepjendereco.initialize();
         Submit( executePrivateCatch,objloadauditclientepjendereco);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditclientepjendereco)stateInfo).executePrivate();
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
         /* Using cursor P00772 */
         pr_default.execute(0, new Object[] {AV17CliID, AV18CpjID, AV19CpjEndSeq});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A248CpjEndSeq = P00772_A248CpjEndSeq[0];
            A166CpjID = P00772_A166CpjID[0];
            A158CliID = P00772_A158CliID[0];
            A159CliMatricula = P00772_A159CliMatricula[0];
            A160CliNomeFamiliar = P00772_A160CliNomeFamiliar[0];
            A365CpjTipoId = P00772_A365CpjTipoId[0];
            A366CpjTipoSigla = P00772_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00772_A367CpjTipoNome[0];
            A170CpjNomeFan = P00772_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00772_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00772_A176CpjMatricula[0];
            A187CpjCNPJ = P00772_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00772_A188CpjCNPJFormat[0];
            A189CpjIE = P00772_A189CpjIE[0];
            A207CpjAtivo = P00772_A207CpjAtivo[0];
            A261CpjTelNum = P00772_A261CpjTelNum[0];
            n261CpjTelNum = P00772_n261CpjTelNum[0];
            A262CpjTelRam = P00772_A262CpjTelRam[0];
            n262CpjTelRam = P00772_n262CpjTelRam[0];
            A263CpjCelNum = P00772_A263CpjCelNum[0];
            n263CpjCelNum = P00772_n263CpjCelNum[0];
            A264CpjWppNum = P00772_A264CpjWppNum[0];
            n264CpjWppNum = P00772_n264CpjWppNum[0];
            A265CpjWebsite = P00772_A265CpjWebsite[0];
            n265CpjWebsite = P00772_n265CpjWebsite[0];
            A266CpjEmail = P00772_A266CpjEmail[0];
            n266CpjEmail = P00772_n266CpjEmail[0];
            A267CpjUltEndSeq = P00772_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = P00772_n267CpjUltEndSeq[0];
            A249CpjEndNome = P00772_A249CpjEndNome[0];
            A250CpjEndCep = P00772_A250CpjEndCep[0];
            A256CpjEndMunID = P00772_A256CpjEndMunID[0];
            A258CpjEndUFId = P00772_A258CpjEndUFId[0];
            A260CpjEndUFNome = P00772_A260CpjEndUFNome[0];
            A554CpjEndDel = P00772_A554CpjEndDel[0];
            A555CpjEndDelDataHora = P00772_A555CpjEndDelDataHora[0];
            n555CpjEndDelDataHora = P00772_n555CpjEndDelDataHora[0];
            A556CpjEndDelData = P00772_A556CpjEndDelData[0];
            n556CpjEndDelData = P00772_n556CpjEndDelData[0];
            A557CpjEndDelHora = P00772_A557CpjEndDelHora[0];
            n557CpjEndDelHora = P00772_n557CpjEndDelHora[0];
            A558CpjEndDelUsuId = P00772_A558CpjEndDelUsuId[0];
            n558CpjEndDelUsuId = P00772_n558CpjEndDelUsuId[0];
            A559CpjEndDelUsuNome = P00772_A559CpjEndDelUsuNome[0];
            n559CpjEndDelUsuNome = P00772_n559CpjEndDelUsuNome[0];
            A254CpjEndComplem = P00772_A254CpjEndComplem[0];
            n254CpjEndComplem = P00772_n254CpjEndComplem[0];
            A253CpjEndNumero = P00772_A253CpjEndNumero[0];
            A259CpjEndUFSigla = P00772_A259CpjEndUFSigla[0];
            A257CpjEndMunNome = P00772_A257CpjEndMunNome[0];
            A251CpjEndCepFormat = P00772_A251CpjEndCepFormat[0];
            A255CpjEndBairro = P00772_A255CpjEndBairro[0];
            A252CpjEndEndereco = P00772_A252CpjEndEndereco[0];
            A159CliMatricula = P00772_A159CliMatricula[0];
            A160CliNomeFamiliar = P00772_A160CliNomeFamiliar[0];
            A365CpjTipoId = P00772_A365CpjTipoId[0];
            A170CpjNomeFan = P00772_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00772_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00772_A176CpjMatricula[0];
            A187CpjCNPJ = P00772_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00772_A188CpjCNPJFormat[0];
            A189CpjIE = P00772_A189CpjIE[0];
            A207CpjAtivo = P00772_A207CpjAtivo[0];
            A261CpjTelNum = P00772_A261CpjTelNum[0];
            n261CpjTelNum = P00772_n261CpjTelNum[0];
            A262CpjTelRam = P00772_A262CpjTelRam[0];
            n262CpjTelRam = P00772_n262CpjTelRam[0];
            A263CpjCelNum = P00772_A263CpjCelNum[0];
            n263CpjCelNum = P00772_n263CpjCelNum[0];
            A264CpjWppNum = P00772_A264CpjWppNum[0];
            n264CpjWppNum = P00772_n264CpjWppNum[0];
            A265CpjWebsite = P00772_A265CpjWebsite[0];
            n265CpjWebsite = P00772_n265CpjWebsite[0];
            A266CpjEmail = P00772_A266CpjEmail[0];
            n266CpjEmail = P00772_n266CpjEmail[0];
            A267CpjUltEndSeq = P00772_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = P00772_n267CpjUltEndSeq[0];
            A366CpjTipoSigla = P00772_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00772_A367CpjTipoNome[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
            {
               A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
                  else
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
               }
            }
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj_endereco";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUltEndSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Endereço Cadastrado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A267CpjUltEndSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A248CpjEndSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A249CpjEndNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCep";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A250CpjEndCep), 8, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCepFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A251CpjEndCepFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndEndereco";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A252CpjEndEndereco;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndNumero";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Número";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A253CpjEndNumero;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndComplem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Complemento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A254CpjEndComplem;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndBairro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Bairro";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A255CpjEndBairro;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndMunID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A256CpjEndMunID), 7, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndMunNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A257CpjEndMunNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A258CpjEndUFId), 2, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A259CpjEndUFSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Estado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A260CpjEndUFNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCompleto";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço Completo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A368CpjEndCompleto;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A554CpjEndDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A556CpjEndDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A557CpjEndDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A558CpjEndDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A559CpjEndDelUsuNome;
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
         /* Using cursor P00773 */
         pr_default.execute(1, new Object[] {AV17CliID, AV18CpjID, AV19CpjEndSeq});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A248CpjEndSeq = P00773_A248CpjEndSeq[0];
            A166CpjID = P00773_A166CpjID[0];
            A158CliID = P00773_A158CliID[0];
            A159CliMatricula = P00773_A159CliMatricula[0];
            A160CliNomeFamiliar = P00773_A160CliNomeFamiliar[0];
            A365CpjTipoId = P00773_A365CpjTipoId[0];
            A366CpjTipoSigla = P00773_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00773_A367CpjTipoNome[0];
            A170CpjNomeFan = P00773_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00773_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00773_A176CpjMatricula[0];
            A187CpjCNPJ = P00773_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00773_A188CpjCNPJFormat[0];
            A189CpjIE = P00773_A189CpjIE[0];
            A207CpjAtivo = P00773_A207CpjAtivo[0];
            A261CpjTelNum = P00773_A261CpjTelNum[0];
            n261CpjTelNum = P00773_n261CpjTelNum[0];
            A262CpjTelRam = P00773_A262CpjTelRam[0];
            n262CpjTelRam = P00773_n262CpjTelRam[0];
            A263CpjCelNum = P00773_A263CpjCelNum[0];
            n263CpjCelNum = P00773_n263CpjCelNum[0];
            A264CpjWppNum = P00773_A264CpjWppNum[0];
            n264CpjWppNum = P00773_n264CpjWppNum[0];
            A265CpjWebsite = P00773_A265CpjWebsite[0];
            n265CpjWebsite = P00773_n265CpjWebsite[0];
            A266CpjEmail = P00773_A266CpjEmail[0];
            n266CpjEmail = P00773_n266CpjEmail[0];
            A267CpjUltEndSeq = P00773_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = P00773_n267CpjUltEndSeq[0];
            A249CpjEndNome = P00773_A249CpjEndNome[0];
            A250CpjEndCep = P00773_A250CpjEndCep[0];
            A256CpjEndMunID = P00773_A256CpjEndMunID[0];
            A258CpjEndUFId = P00773_A258CpjEndUFId[0];
            A260CpjEndUFNome = P00773_A260CpjEndUFNome[0];
            A554CpjEndDel = P00773_A554CpjEndDel[0];
            A555CpjEndDelDataHora = P00773_A555CpjEndDelDataHora[0];
            n555CpjEndDelDataHora = P00773_n555CpjEndDelDataHora[0];
            A556CpjEndDelData = P00773_A556CpjEndDelData[0];
            n556CpjEndDelData = P00773_n556CpjEndDelData[0];
            A557CpjEndDelHora = P00773_A557CpjEndDelHora[0];
            n557CpjEndDelHora = P00773_n557CpjEndDelHora[0];
            A558CpjEndDelUsuId = P00773_A558CpjEndDelUsuId[0];
            n558CpjEndDelUsuId = P00773_n558CpjEndDelUsuId[0];
            A559CpjEndDelUsuNome = P00773_A559CpjEndDelUsuNome[0];
            n559CpjEndDelUsuNome = P00773_n559CpjEndDelUsuNome[0];
            A254CpjEndComplem = P00773_A254CpjEndComplem[0];
            n254CpjEndComplem = P00773_n254CpjEndComplem[0];
            A253CpjEndNumero = P00773_A253CpjEndNumero[0];
            A259CpjEndUFSigla = P00773_A259CpjEndUFSigla[0];
            A257CpjEndMunNome = P00773_A257CpjEndMunNome[0];
            A251CpjEndCepFormat = P00773_A251CpjEndCepFormat[0];
            A255CpjEndBairro = P00773_A255CpjEndBairro[0];
            A252CpjEndEndereco = P00773_A252CpjEndEndereco[0];
            A159CliMatricula = P00773_A159CliMatricula[0];
            A160CliNomeFamiliar = P00773_A160CliNomeFamiliar[0];
            A365CpjTipoId = P00773_A365CpjTipoId[0];
            A170CpjNomeFan = P00773_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P00773_A171CpjRazaoSoc[0];
            A176CpjMatricula = P00773_A176CpjMatricula[0];
            A187CpjCNPJ = P00773_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P00773_A188CpjCNPJFormat[0];
            A189CpjIE = P00773_A189CpjIE[0];
            A207CpjAtivo = P00773_A207CpjAtivo[0];
            A261CpjTelNum = P00773_A261CpjTelNum[0];
            n261CpjTelNum = P00773_n261CpjTelNum[0];
            A262CpjTelRam = P00773_A262CpjTelRam[0];
            n262CpjTelRam = P00773_n262CpjTelRam[0];
            A263CpjCelNum = P00773_A263CpjCelNum[0];
            n263CpjCelNum = P00773_n263CpjCelNum[0];
            A264CpjWppNum = P00773_A264CpjWppNum[0];
            n264CpjWppNum = P00773_n264CpjWppNum[0];
            A265CpjWebsite = P00773_A265CpjWebsite[0];
            n265CpjWebsite = P00773_n265CpjWebsite[0];
            A266CpjEmail = P00773_A266CpjEmail[0];
            n266CpjEmail = P00773_n266CpjEmail[0];
            A267CpjUltEndSeq = P00773_A267CpjUltEndSeq[0];
            n267CpjUltEndSeq = P00773_n267CpjUltEndSeq[0];
            A366CpjTipoSigla = P00773_A366CpjTipoSigla[0];
            A367CpjTipoNome = P00773_A367CpjTipoNome[0];
            if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
            {
               A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
            }
            else
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
               {
                  A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
               }
               else
               {
                  if ( String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A253CpjEndNumero))) && ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( A254CpjEndComplem))) )
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
                  else
                  {
                     A368CpjEndCompleto = StringUtil.Trim( A252CpjEndEndereco) + ", " + StringUtil.Trim( A253CpjEndNumero) + " " + StringUtil.Trim( A254CpjEndComplem) + " - " + StringUtil.Trim( A255CpjEndBairro) + " - " + StringUtil.Trim( A251CpjEndCepFormat) + " - " + StringUtil.Trim( A257CpjEndMunNome) + " - " + StringUtil.Trim( A259CpjEndUFSigla);
                  }
               }
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj_endereco";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUltEndSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Endereço Cadastrado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A267CpjUltEndSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A248CpjEndSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A249CpjEndNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCep";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A250CpjEndCep), 8, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCepFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CEP";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A251CpjEndCepFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndEndereco";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A252CpjEndEndereco;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndNumero";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Número";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A253CpjEndNumero;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndComplem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Complemento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A254CpjEndComplem;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndBairro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Bairro";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A255CpjEndBairro;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndMunID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A256CpjEndMunID), 7, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndMunNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Município";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A257CpjEndMunNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A258CpjEndUFId), 2, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "UF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A259CpjEndUFSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndUFNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Estado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A260CpjEndUFNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndCompleto";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Endereço Completo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A368CpjEndCompleto;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A554CpjEndDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A556CpjEndDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A557CpjEndDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A558CpjEndDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjEndDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A559CpjEndDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22GXV1 = 1;
               while ( AV22GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV22GXV1));
                  AV23GXV2 = 1;
                  while ( AV23GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                  {
                     AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV23GXV2));
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUltEndSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A267CpjUltEndSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A248CpjEndSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A249CpjEndNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndCep") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A250CpjEndCep), 8, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndCepFormat") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A251CpjEndCepFormat;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndEndereco") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A252CpjEndEndereco;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndNumero") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A253CpjEndNumero;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndComplem") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A254CpjEndComplem;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndBairro") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A255CpjEndBairro;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndMunID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A256CpjEndMunID), 7, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndMunNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A257CpjEndMunNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndUFId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A258CpjEndUFId), 2, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndUFSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A259CpjEndUFSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndUFNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A260CpjEndUFNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndCompleto") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A368CpjEndCompleto;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A554CpjEndDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A555CpjEndDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A556CpjEndDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A557CpjEndDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A558CpjEndDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjEndDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A559CpjEndDelUsuNome;
                     }
                     AV23GXV2 = (int)(AV23GXV2+1);
                  }
                  AV22GXV1 = (int)(AV22GXV1+1);
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
         P00772_A248CpjEndSeq = new short[1] ;
         P00772_A166CpjID = new Guid[] {Guid.Empty} ;
         P00772_A158CliID = new Guid[] {Guid.Empty} ;
         P00772_A159CliMatricula = new long[1] ;
         P00772_A160CliNomeFamiliar = new string[] {""} ;
         P00772_A365CpjTipoId = new int[1] ;
         P00772_A366CpjTipoSigla = new string[] {""} ;
         P00772_A367CpjTipoNome = new string[] {""} ;
         P00772_A170CpjNomeFan = new string[] {""} ;
         P00772_A171CpjRazaoSoc = new string[] {""} ;
         P00772_A176CpjMatricula = new long[1] ;
         P00772_A187CpjCNPJ = new long[1] ;
         P00772_A188CpjCNPJFormat = new string[] {""} ;
         P00772_A189CpjIE = new string[] {""} ;
         P00772_A207CpjAtivo = new bool[] {false} ;
         P00772_A261CpjTelNum = new string[] {""} ;
         P00772_n261CpjTelNum = new bool[] {false} ;
         P00772_A262CpjTelRam = new string[] {""} ;
         P00772_n262CpjTelRam = new bool[] {false} ;
         P00772_A263CpjCelNum = new string[] {""} ;
         P00772_n263CpjCelNum = new bool[] {false} ;
         P00772_A264CpjWppNum = new string[] {""} ;
         P00772_n264CpjWppNum = new bool[] {false} ;
         P00772_A265CpjWebsite = new string[] {""} ;
         P00772_n265CpjWebsite = new bool[] {false} ;
         P00772_A266CpjEmail = new string[] {""} ;
         P00772_n266CpjEmail = new bool[] {false} ;
         P00772_A267CpjUltEndSeq = new short[1] ;
         P00772_n267CpjUltEndSeq = new bool[] {false} ;
         P00772_A249CpjEndNome = new string[] {""} ;
         P00772_A250CpjEndCep = new int[1] ;
         P00772_A256CpjEndMunID = new int[1] ;
         P00772_A258CpjEndUFId = new short[1] ;
         P00772_A260CpjEndUFNome = new string[] {""} ;
         P00772_A554CpjEndDel = new bool[] {false} ;
         P00772_A555CpjEndDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00772_n555CpjEndDelDataHora = new bool[] {false} ;
         P00772_A556CpjEndDelData = new DateTime[] {DateTime.MinValue} ;
         P00772_n556CpjEndDelData = new bool[] {false} ;
         P00772_A557CpjEndDelHora = new DateTime[] {DateTime.MinValue} ;
         P00772_n557CpjEndDelHora = new bool[] {false} ;
         P00772_A558CpjEndDelUsuId = new string[] {""} ;
         P00772_n558CpjEndDelUsuId = new bool[] {false} ;
         P00772_A559CpjEndDelUsuNome = new string[] {""} ;
         P00772_n559CpjEndDelUsuNome = new bool[] {false} ;
         P00772_A254CpjEndComplem = new string[] {""} ;
         P00772_n254CpjEndComplem = new bool[] {false} ;
         P00772_A253CpjEndNumero = new string[] {""} ;
         P00772_A259CpjEndUFSigla = new string[] {""} ;
         P00772_A257CpjEndMunNome = new string[] {""} ;
         P00772_A251CpjEndCepFormat = new string[] {""} ;
         P00772_A255CpjEndBairro = new string[] {""} ;
         P00772_A252CpjEndEndereco = new string[] {""} ;
         A166CpjID = Guid.Empty;
         A158CliID = Guid.Empty;
         A160CliNomeFamiliar = "";
         A366CpjTipoSigla = "";
         A367CpjTipoNome = "";
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A263CpjCelNum = "";
         A264CpjWppNum = "";
         A265CpjWebsite = "";
         A266CpjEmail = "";
         A249CpjEndNome = "";
         A260CpjEndUFNome = "";
         A555CpjEndDelDataHora = (DateTime)(DateTime.MinValue);
         A556CpjEndDelData = (DateTime)(DateTime.MinValue);
         A557CpjEndDelHora = (DateTime)(DateTime.MinValue);
         A558CpjEndDelUsuId = "";
         A559CpjEndDelUsuNome = "";
         A254CpjEndComplem = "";
         A253CpjEndNumero = "";
         A259CpjEndUFSigla = "";
         A257CpjEndMunNome = "";
         A251CpjEndCepFormat = "";
         A255CpjEndBairro = "";
         A252CpjEndEndereco = "";
         A368CpjEndCompleto = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P00773_A248CpjEndSeq = new short[1] ;
         P00773_A166CpjID = new Guid[] {Guid.Empty} ;
         P00773_A158CliID = new Guid[] {Guid.Empty} ;
         P00773_A159CliMatricula = new long[1] ;
         P00773_A160CliNomeFamiliar = new string[] {""} ;
         P00773_A365CpjTipoId = new int[1] ;
         P00773_A366CpjTipoSigla = new string[] {""} ;
         P00773_A367CpjTipoNome = new string[] {""} ;
         P00773_A170CpjNomeFan = new string[] {""} ;
         P00773_A171CpjRazaoSoc = new string[] {""} ;
         P00773_A176CpjMatricula = new long[1] ;
         P00773_A187CpjCNPJ = new long[1] ;
         P00773_A188CpjCNPJFormat = new string[] {""} ;
         P00773_A189CpjIE = new string[] {""} ;
         P00773_A207CpjAtivo = new bool[] {false} ;
         P00773_A261CpjTelNum = new string[] {""} ;
         P00773_n261CpjTelNum = new bool[] {false} ;
         P00773_A262CpjTelRam = new string[] {""} ;
         P00773_n262CpjTelRam = new bool[] {false} ;
         P00773_A263CpjCelNum = new string[] {""} ;
         P00773_n263CpjCelNum = new bool[] {false} ;
         P00773_A264CpjWppNum = new string[] {""} ;
         P00773_n264CpjWppNum = new bool[] {false} ;
         P00773_A265CpjWebsite = new string[] {""} ;
         P00773_n265CpjWebsite = new bool[] {false} ;
         P00773_A266CpjEmail = new string[] {""} ;
         P00773_n266CpjEmail = new bool[] {false} ;
         P00773_A267CpjUltEndSeq = new short[1] ;
         P00773_n267CpjUltEndSeq = new bool[] {false} ;
         P00773_A249CpjEndNome = new string[] {""} ;
         P00773_A250CpjEndCep = new int[1] ;
         P00773_A256CpjEndMunID = new int[1] ;
         P00773_A258CpjEndUFId = new short[1] ;
         P00773_A260CpjEndUFNome = new string[] {""} ;
         P00773_A554CpjEndDel = new bool[] {false} ;
         P00773_A555CpjEndDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P00773_n555CpjEndDelDataHora = new bool[] {false} ;
         P00773_A556CpjEndDelData = new DateTime[] {DateTime.MinValue} ;
         P00773_n556CpjEndDelData = new bool[] {false} ;
         P00773_A557CpjEndDelHora = new DateTime[] {DateTime.MinValue} ;
         P00773_n557CpjEndDelHora = new bool[] {false} ;
         P00773_A558CpjEndDelUsuId = new string[] {""} ;
         P00773_n558CpjEndDelUsuId = new bool[] {false} ;
         P00773_A559CpjEndDelUsuNome = new string[] {""} ;
         P00773_n559CpjEndDelUsuNome = new bool[] {false} ;
         P00773_A254CpjEndComplem = new string[] {""} ;
         P00773_n254CpjEndComplem = new bool[] {false} ;
         P00773_A253CpjEndNumero = new string[] {""} ;
         P00773_A259CpjEndUFSigla = new string[] {""} ;
         P00773_A257CpjEndMunNome = new string[] {""} ;
         P00773_A251CpjEndCepFormat = new string[] {""} ;
         P00773_A255CpjEndBairro = new string[] {""} ;
         P00773_A252CpjEndEndereco = new string[] {""} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditclientepjendereco__default(),
            new Object[][] {
                new Object[] {
               P00772_A248CpjEndSeq, P00772_A166CpjID, P00772_A158CliID, P00772_A159CliMatricula, P00772_A160CliNomeFamiliar, P00772_A365CpjTipoId, P00772_A366CpjTipoSigla, P00772_A367CpjTipoNome, P00772_A170CpjNomeFan, P00772_A171CpjRazaoSoc,
               P00772_A176CpjMatricula, P00772_A187CpjCNPJ, P00772_A188CpjCNPJFormat, P00772_A189CpjIE, P00772_A207CpjAtivo, P00772_A261CpjTelNum, P00772_n261CpjTelNum, P00772_A262CpjTelRam, P00772_n262CpjTelRam, P00772_A263CpjCelNum,
               P00772_n263CpjCelNum, P00772_A264CpjWppNum, P00772_n264CpjWppNum, P00772_A265CpjWebsite, P00772_n265CpjWebsite, P00772_A266CpjEmail, P00772_n266CpjEmail, P00772_A267CpjUltEndSeq, P00772_n267CpjUltEndSeq, P00772_A249CpjEndNome,
               P00772_A250CpjEndCep, P00772_A256CpjEndMunID, P00772_A258CpjEndUFId, P00772_A260CpjEndUFNome, P00772_A554CpjEndDel, P00772_A555CpjEndDelDataHora, P00772_n555CpjEndDelDataHora, P00772_A556CpjEndDelData, P00772_n556CpjEndDelData, P00772_A557CpjEndDelHora,
               P00772_n557CpjEndDelHora, P00772_A558CpjEndDelUsuId, P00772_n558CpjEndDelUsuId, P00772_A559CpjEndDelUsuNome, P00772_n559CpjEndDelUsuNome, P00772_A254CpjEndComplem, P00772_n254CpjEndComplem, P00772_A253CpjEndNumero, P00772_A259CpjEndUFSigla, P00772_A257CpjEndMunNome,
               P00772_A251CpjEndCepFormat, P00772_A255CpjEndBairro, P00772_A252CpjEndEndereco
               }
               , new Object[] {
               P00773_A248CpjEndSeq, P00773_A166CpjID, P00773_A158CliID, P00773_A159CliMatricula, P00773_A160CliNomeFamiliar, P00773_A365CpjTipoId, P00773_A366CpjTipoSigla, P00773_A367CpjTipoNome, P00773_A170CpjNomeFan, P00773_A171CpjRazaoSoc,
               P00773_A176CpjMatricula, P00773_A187CpjCNPJ, P00773_A188CpjCNPJFormat, P00773_A189CpjIE, P00773_A207CpjAtivo, P00773_A261CpjTelNum, P00773_n261CpjTelNum, P00773_A262CpjTelRam, P00773_n262CpjTelRam, P00773_A263CpjCelNum,
               P00773_n263CpjCelNum, P00773_A264CpjWppNum, P00773_n264CpjWppNum, P00773_A265CpjWebsite, P00773_n265CpjWebsite, P00773_A266CpjEmail, P00773_n266CpjEmail, P00773_A267CpjUltEndSeq, P00773_n267CpjUltEndSeq, P00773_A249CpjEndNome,
               P00773_A250CpjEndCep, P00773_A256CpjEndMunID, P00773_A258CpjEndUFId, P00773_A260CpjEndUFNome, P00773_A554CpjEndDel, P00773_A555CpjEndDelDataHora, P00773_n555CpjEndDelDataHora, P00773_A556CpjEndDelData, P00773_n556CpjEndDelData, P00773_A557CpjEndDelHora,
               P00773_n557CpjEndDelHora, P00773_A558CpjEndDelUsuId, P00773_n558CpjEndDelUsuId, P00773_A559CpjEndDelUsuNome, P00773_n559CpjEndDelUsuNome, P00773_A254CpjEndComplem, P00773_n254CpjEndComplem, P00773_A253CpjEndNumero, P00773_A259CpjEndUFSigla, P00773_A257CpjEndMunNome,
               P00773_A251CpjEndCepFormat, P00773_A255CpjEndBairro, P00773_A252CpjEndEndereco
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19CpjEndSeq ;
      private short A248CpjEndSeq ;
      private short A267CpjUltEndSeq ;
      private short A258CpjEndUFId ;
      private int A365CpjTipoId ;
      private int A250CpjEndCep ;
      private int A256CpjEndMunID ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private long A187CpjCNPJ ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A261CpjTelNum ;
      private string A263CpjCelNum ;
      private string A264CpjWppNum ;
      private string A558CpjEndDelUsuId ;
      private DateTime A555CpjEndDelDataHora ;
      private DateTime A556CpjEndDelData ;
      private DateTime A557CpjEndDelHora ;
      private bool returnInSub ;
      private bool A207CpjAtivo ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool n267CpjUltEndSeq ;
      private bool A554CpjEndDel ;
      private bool n555CpjEndDelDataHora ;
      private bool n556CpjEndDelData ;
      private bool n557CpjEndDelHora ;
      private bool n558CpjEndDelUsuId ;
      private bool n559CpjEndDelUsuNome ;
      private bool n254CpjEndComplem ;
      private string A160CliNomeFamiliar ;
      private string A366CpjTipoSigla ;
      private string A367CpjTipoNome ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A265CpjWebsite ;
      private string A266CpjEmail ;
      private string A249CpjEndNome ;
      private string A260CpjEndUFNome ;
      private string A559CpjEndDelUsuNome ;
      private string A254CpjEndComplem ;
      private string A253CpjEndNumero ;
      private string A259CpjEndUFSigla ;
      private string A257CpjEndMunNome ;
      private string A251CpjEndCepFormat ;
      private string A255CpjEndBairro ;
      private string A252CpjEndEndereco ;
      private string A368CpjEndCompleto ;
      private Guid AV17CliID ;
      private Guid AV18CpjID ;
      private Guid A166CpjID ;
      private Guid A158CliID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private short[] P00772_A248CpjEndSeq ;
      private Guid[] P00772_A166CpjID ;
      private Guid[] P00772_A158CliID ;
      private long[] P00772_A159CliMatricula ;
      private string[] P00772_A160CliNomeFamiliar ;
      private int[] P00772_A365CpjTipoId ;
      private string[] P00772_A366CpjTipoSigla ;
      private string[] P00772_A367CpjTipoNome ;
      private string[] P00772_A170CpjNomeFan ;
      private string[] P00772_A171CpjRazaoSoc ;
      private long[] P00772_A176CpjMatricula ;
      private long[] P00772_A187CpjCNPJ ;
      private string[] P00772_A188CpjCNPJFormat ;
      private string[] P00772_A189CpjIE ;
      private bool[] P00772_A207CpjAtivo ;
      private string[] P00772_A261CpjTelNum ;
      private bool[] P00772_n261CpjTelNum ;
      private string[] P00772_A262CpjTelRam ;
      private bool[] P00772_n262CpjTelRam ;
      private string[] P00772_A263CpjCelNum ;
      private bool[] P00772_n263CpjCelNum ;
      private string[] P00772_A264CpjWppNum ;
      private bool[] P00772_n264CpjWppNum ;
      private string[] P00772_A265CpjWebsite ;
      private bool[] P00772_n265CpjWebsite ;
      private string[] P00772_A266CpjEmail ;
      private bool[] P00772_n266CpjEmail ;
      private short[] P00772_A267CpjUltEndSeq ;
      private bool[] P00772_n267CpjUltEndSeq ;
      private string[] P00772_A249CpjEndNome ;
      private int[] P00772_A250CpjEndCep ;
      private int[] P00772_A256CpjEndMunID ;
      private short[] P00772_A258CpjEndUFId ;
      private string[] P00772_A260CpjEndUFNome ;
      private bool[] P00772_A554CpjEndDel ;
      private DateTime[] P00772_A555CpjEndDelDataHora ;
      private bool[] P00772_n555CpjEndDelDataHora ;
      private DateTime[] P00772_A556CpjEndDelData ;
      private bool[] P00772_n556CpjEndDelData ;
      private DateTime[] P00772_A557CpjEndDelHora ;
      private bool[] P00772_n557CpjEndDelHora ;
      private string[] P00772_A558CpjEndDelUsuId ;
      private bool[] P00772_n558CpjEndDelUsuId ;
      private string[] P00772_A559CpjEndDelUsuNome ;
      private bool[] P00772_n559CpjEndDelUsuNome ;
      private string[] P00772_A254CpjEndComplem ;
      private bool[] P00772_n254CpjEndComplem ;
      private string[] P00772_A253CpjEndNumero ;
      private string[] P00772_A259CpjEndUFSigla ;
      private string[] P00772_A257CpjEndMunNome ;
      private string[] P00772_A251CpjEndCepFormat ;
      private string[] P00772_A255CpjEndBairro ;
      private string[] P00772_A252CpjEndEndereco ;
      private short[] P00773_A248CpjEndSeq ;
      private Guid[] P00773_A166CpjID ;
      private Guid[] P00773_A158CliID ;
      private long[] P00773_A159CliMatricula ;
      private string[] P00773_A160CliNomeFamiliar ;
      private int[] P00773_A365CpjTipoId ;
      private string[] P00773_A366CpjTipoSigla ;
      private string[] P00773_A367CpjTipoNome ;
      private string[] P00773_A170CpjNomeFan ;
      private string[] P00773_A171CpjRazaoSoc ;
      private long[] P00773_A176CpjMatricula ;
      private long[] P00773_A187CpjCNPJ ;
      private string[] P00773_A188CpjCNPJFormat ;
      private string[] P00773_A189CpjIE ;
      private bool[] P00773_A207CpjAtivo ;
      private string[] P00773_A261CpjTelNum ;
      private bool[] P00773_n261CpjTelNum ;
      private string[] P00773_A262CpjTelRam ;
      private bool[] P00773_n262CpjTelRam ;
      private string[] P00773_A263CpjCelNum ;
      private bool[] P00773_n263CpjCelNum ;
      private string[] P00773_A264CpjWppNum ;
      private bool[] P00773_n264CpjWppNum ;
      private string[] P00773_A265CpjWebsite ;
      private bool[] P00773_n265CpjWebsite ;
      private string[] P00773_A266CpjEmail ;
      private bool[] P00773_n266CpjEmail ;
      private short[] P00773_A267CpjUltEndSeq ;
      private bool[] P00773_n267CpjUltEndSeq ;
      private string[] P00773_A249CpjEndNome ;
      private int[] P00773_A250CpjEndCep ;
      private int[] P00773_A256CpjEndMunID ;
      private short[] P00773_A258CpjEndUFId ;
      private string[] P00773_A260CpjEndUFNome ;
      private bool[] P00773_A554CpjEndDel ;
      private DateTime[] P00773_A555CpjEndDelDataHora ;
      private bool[] P00773_n555CpjEndDelDataHora ;
      private DateTime[] P00773_A556CpjEndDelData ;
      private bool[] P00773_n556CpjEndDelData ;
      private DateTime[] P00773_A557CpjEndDelHora ;
      private bool[] P00773_n557CpjEndDelHora ;
      private string[] P00773_A558CpjEndDelUsuId ;
      private bool[] P00773_n558CpjEndDelUsuId ;
      private string[] P00773_A559CpjEndDelUsuNome ;
      private bool[] P00773_n559CpjEndDelUsuNome ;
      private string[] P00773_A254CpjEndComplem ;
      private bool[] P00773_n254CpjEndComplem ;
      private string[] P00773_A253CpjEndNumero ;
      private string[] P00773_A259CpjEndUFSigla ;
      private string[] P00773_A257CpjEndMunNome ;
      private string[] P00773_A251CpjEndCepFormat ;
      private string[] P00773_A255CpjEndBairro ;
      private string[] P00773_A252CpjEndEndereco ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditclientepjendereco__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP00772;
          prmP00772 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19CpjEndSeq",GXType.Int16,4,0)
          };
          Object[] prmP00773;
          prmP00773 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19CpjEndSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00772", "SELECT T1.CpjEndSeq, T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T3.CpjTipoId AS CpjTipoId, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, T3.CpjUltEndSeq, T1.CpjEndNome, T1.CpjEndCep, T1.CpjEndMunID, T1.CpjEndUFId, T1.CpjEndUFNome, T1.CpjEndDel, T1.CpjEndDelDataHora, T1.CpjEndDelData, T1.CpjEndDelHora, T1.CpjEndDelUsuId, T1.CpjEndDelUsuNome, T1.CpjEndComplem, T1.CpjEndNumero, T1.CpjEndUFSigla, T1.CpjEndMunNome, T1.CpjEndCepFormat, T1.CpjEndBairro, T1.CpjEndEndereco FROM (((tb_clientepj_endereco T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID and T1.CpjEndSeq = :AV19CpjEndSeq ORDER BY T1.CliID, T1.CpjID, T1.CpjEndSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00772,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P00773", "SELECT T1.CpjEndSeq, T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T3.CpjTipoId AS CpjTipoId, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, T3.CpjUltEndSeq, T1.CpjEndNome, T1.CpjEndCep, T1.CpjEndMunID, T1.CpjEndUFId, T1.CpjEndUFNome, T1.CpjEndDel, T1.CpjEndDelDataHora, T1.CpjEndDelData, T1.CpjEndDelHora, T1.CpjEndDelUsuId, T1.CpjEndDelUsuNome, T1.CpjEndComplem, T1.CpjEndNumero, T1.CpjEndUFSigla, T1.CpjEndMunNome, T1.CpjEndCepFormat, T1.CpjEndBairro, T1.CpjEndEndereco FROM (((tb_clientepj_endereco T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID and T1.CpjEndSeq = :AV19CpjEndSeq ORDER BY T1.CliID, T1.CpjID, T1.CpjEndSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00773,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((bool[]) buf[18])[0] = rslt.wasNull(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((bool[]) buf[20])[0] = rslt.wasNull(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(19);
                ((string[]) buf[23])[0] = rslt.getVarchar(20);
                ((bool[]) buf[24])[0] = rslt.wasNull(20);
                ((string[]) buf[25])[0] = rslt.getVarchar(21);
                ((bool[]) buf[26])[0] = rslt.wasNull(21);
                ((short[]) buf[27])[0] = rslt.getShort(22);
                ((bool[]) buf[28])[0] = rslt.wasNull(22);
                ((string[]) buf[29])[0] = rslt.getVarchar(23);
                ((int[]) buf[30])[0] = rslt.getInt(24);
                ((int[]) buf[31])[0] = rslt.getInt(25);
                ((short[]) buf[32])[0] = rslt.getShort(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((bool[]) buf[34])[0] = rslt.getBool(28);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(29, true);
                ((bool[]) buf[36])[0] = rslt.wasNull(29);
                ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(30);
                ((bool[]) buf[38])[0] = rslt.wasNull(30);
                ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(31);
                ((bool[]) buf[40])[0] = rslt.wasNull(31);
                ((string[]) buf[41])[0] = rslt.getString(32, 40);
                ((bool[]) buf[42])[0] = rslt.wasNull(32);
                ((string[]) buf[43])[0] = rslt.getVarchar(33);
                ((bool[]) buf[44])[0] = rslt.wasNull(33);
                ((string[]) buf[45])[0] = rslt.getVarchar(34);
                ((bool[]) buf[46])[0] = rslt.wasNull(34);
                ((string[]) buf[47])[0] = rslt.getVarchar(35);
                ((string[]) buf[48])[0] = rslt.getVarchar(36);
                ((string[]) buf[49])[0] = rslt.getVarchar(37);
                ((string[]) buf[50])[0] = rslt.getVarchar(38);
                ((string[]) buf[51])[0] = rslt.getVarchar(39);
                ((string[]) buf[52])[0] = rslt.getVarchar(40);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((int[]) buf[5])[0] = rslt.getInt(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((string[]) buf[8])[0] = rslt.getVarchar(9);
                ((string[]) buf[9])[0] = rslt.getVarchar(10);
                ((long[]) buf[10])[0] = rslt.getLong(11);
                ((long[]) buf[11])[0] = rslt.getLong(12);
                ((string[]) buf[12])[0] = rslt.getVarchar(13);
                ((string[]) buf[13])[0] = rslt.getVarchar(14);
                ((bool[]) buf[14])[0] = rslt.getBool(15);
                ((string[]) buf[15])[0] = rslt.getString(16, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(16);
                ((string[]) buf[17])[0] = rslt.getVarchar(17);
                ((bool[]) buf[18])[0] = rslt.wasNull(17);
                ((string[]) buf[19])[0] = rslt.getString(18, 20);
                ((bool[]) buf[20])[0] = rslt.wasNull(18);
                ((string[]) buf[21])[0] = rslt.getString(19, 20);
                ((bool[]) buf[22])[0] = rslt.wasNull(19);
                ((string[]) buf[23])[0] = rslt.getVarchar(20);
                ((bool[]) buf[24])[0] = rslt.wasNull(20);
                ((string[]) buf[25])[0] = rslt.getVarchar(21);
                ((bool[]) buf[26])[0] = rslt.wasNull(21);
                ((short[]) buf[27])[0] = rslt.getShort(22);
                ((bool[]) buf[28])[0] = rslt.wasNull(22);
                ((string[]) buf[29])[0] = rslt.getVarchar(23);
                ((int[]) buf[30])[0] = rslt.getInt(24);
                ((int[]) buf[31])[0] = rslt.getInt(25);
                ((short[]) buf[32])[0] = rslt.getShort(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((bool[]) buf[34])[0] = rslt.getBool(28);
                ((DateTime[]) buf[35])[0] = rslt.getGXDateTime(29, true);
                ((bool[]) buf[36])[0] = rslt.wasNull(29);
                ((DateTime[]) buf[37])[0] = rslt.getGXDateTime(30);
                ((bool[]) buf[38])[0] = rslt.wasNull(30);
                ((DateTime[]) buf[39])[0] = rslt.getGXDateTime(31);
                ((bool[]) buf[40])[0] = rslt.wasNull(31);
                ((string[]) buf[41])[0] = rslt.getString(32, 40);
                ((bool[]) buf[42])[0] = rslt.wasNull(32);
                ((string[]) buf[43])[0] = rslt.getVarchar(33);
                ((bool[]) buf[44])[0] = rslt.wasNull(33);
                ((string[]) buf[45])[0] = rslt.getVarchar(34);
                ((bool[]) buf[46])[0] = rslt.wasNull(34);
                ((string[]) buf[47])[0] = rslt.getVarchar(35);
                ((string[]) buf[48])[0] = rslt.getVarchar(36);
                ((string[]) buf[49])[0] = rslt.getVarchar(37);
                ((string[]) buf[50])[0] = rslt.getVarchar(38);
                ((string[]) buf[51])[0] = rslt.getVarchar(39);
                ((string[]) buf[52])[0] = rslt.getVarchar(40);
                return;
       }
    }

 }

}
