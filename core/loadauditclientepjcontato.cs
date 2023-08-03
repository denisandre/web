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
   public class loadauditclientepjcontato : GXProcedure
   {
      public loadauditclientepjcontato( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditclientepjcontato( IGxContext context )
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
                           short aP4_CpjConSeq ,
                           string aP5_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17CliID = aP2_CliID;
         this.AV18CpjID = aP3_CpjID;
         this.AV19CpjConSeq = aP4_CpjConSeq;
         this.AV15ActualMode = aP5_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_CliID ,
                                 Guid aP3_CpjID ,
                                 short aP4_CpjConSeq ,
                                 string aP5_ActualMode )
      {
         loadauditclientepjcontato objloadauditclientepjcontato;
         objloadauditclientepjcontato = new loadauditclientepjcontato();
         objloadauditclientepjcontato.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditclientepjcontato.AV11AuditingObject = aP1_AuditingObject;
         objloadauditclientepjcontato.AV17CliID = aP2_CliID;
         objloadauditclientepjcontato.AV18CpjID = aP3_CpjID;
         objloadauditclientepjcontato.AV19CpjConSeq = aP4_CpjConSeq;
         objloadauditclientepjcontato.AV15ActualMode = aP5_ActualMode;
         objloadauditclientepjcontato.context.SetSubmitInitialConfig(context);
         objloadauditclientepjcontato.initialize();
         Submit( executePrivateCatch,objloadauditclientepjcontato);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditclientepjcontato)stateInfo).executePrivate();
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
         /* Using cursor P007F2 */
         pr_default.execute(0, new Object[] {AV17CliID, AV18CpjID, AV19CpjConSeq});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A269CpjConSeq = P007F2_A269CpjConSeq[0];
            A166CpjID = P007F2_A166CpjID[0];
            A158CliID = P007F2_A158CliID[0];
            A159CliMatricula = P007F2_A159CliMatricula[0];
            A160CliNomeFamiliar = P007F2_A160CliNomeFamiliar[0];
            A365CpjTipoId = P007F2_A365CpjTipoId[0];
            A366CpjTipoSigla = P007F2_A366CpjTipoSigla[0];
            A367CpjTipoNome = P007F2_A367CpjTipoNome[0];
            A170CpjNomeFan = P007F2_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P007F2_A171CpjRazaoSoc[0];
            A176CpjMatricula = P007F2_A176CpjMatricula[0];
            A187CpjCNPJ = P007F2_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P007F2_A188CpjCNPJFormat[0];
            A189CpjIE = P007F2_A189CpjIE[0];
            A207CpjAtivo = P007F2_A207CpjAtivo[0];
            A261CpjTelNum = P007F2_A261CpjTelNum[0];
            n261CpjTelNum = P007F2_n261CpjTelNum[0];
            A262CpjTelRam = P007F2_A262CpjTelRam[0];
            n262CpjTelRam = P007F2_n262CpjTelRam[0];
            A263CpjCelNum = P007F2_A263CpjCelNum[0];
            n263CpjCelNum = P007F2_n263CpjCelNum[0];
            A264CpjWppNum = P007F2_A264CpjWppNum[0];
            n264CpjWppNum = P007F2_n264CpjWppNum[0];
            A265CpjWebsite = P007F2_A265CpjWebsite[0];
            n265CpjWebsite = P007F2_n265CpjWebsite[0];
            A266CpjEmail = P007F2_A266CpjEmail[0];
            n266CpjEmail = P007F2_n266CpjEmail[0];
            A268CpjUltConSeq = P007F2_A268CpjUltConSeq[0];
            n268CpjUltConSeq = P007F2_n268CpjUltConSeq[0];
            A270CpjConTipoID = P007F2_A270CpjConTipoID[0];
            A271CpjConTipoSigla = P007F2_A271CpjConTipoSigla[0];
            A272CpjConTipoNome = P007F2_A272CpjConTipoNome[0];
            A273CpjConCPF = P007F2_A273CpjConCPF[0];
            A274CpjConCPFFormat = P007F2_A274CpjConCPFFormat[0];
            A275CpjConNome = P007F2_A275CpjConNome[0];
            A276CpjConNomePrim = P007F2_A276CpjConNomePrim[0];
            A277CpjConSobrenome = P007F2_A277CpjConSobrenome[0];
            A278CpjNomeSocial = P007F2_A278CpjNomeSocial[0];
            A279CpjConGenID = P007F2_A279CpjConGenID[0];
            A280CpjConGenSigla = P007F2_A280CpjConGenSigla[0];
            A281CpjConGenNome = P007F2_A281CpjConGenNome[0];
            A282CpjConNascimento = P007F2_A282CpjConNascimento[0];
            A283CpjConTelNum = P007F2_A283CpjConTelNum[0];
            n283CpjConTelNum = P007F2_n283CpjConTelNum[0];
            A284CpjConTelRam = P007F2_A284CpjConTelRam[0];
            n284CpjConTelRam = P007F2_n284CpjConTelRam[0];
            A285CpjConCelNum = P007F2_A285CpjConCelNum[0];
            n285CpjConCelNum = P007F2_n285CpjConCelNum[0];
            A286CpjConWppNum = P007F2_A286CpjConWppNum[0];
            n286CpjConWppNum = P007F2_n286CpjConWppNum[0];
            A287CpjConEmail = P007F2_A287CpjConEmail[0];
            n287CpjConEmail = P007F2_n287CpjConEmail[0];
            A288CpjConLIn = P007F2_A288CpjConLIn[0];
            n288CpjConLIn = P007F2_n288CpjConLIn[0];
            A328CpjConUltEnd = P007F2_A328CpjConUltEnd[0];
            n328CpjConUltEnd = P007F2_n328CpjConUltEnd[0];
            A548CpjConDel = P007F2_A548CpjConDel[0];
            A549CpjConDelDataHora = P007F2_A549CpjConDelDataHora[0];
            n549CpjConDelDataHora = P007F2_n549CpjConDelDataHora[0];
            A550CpjConDelData = P007F2_A550CpjConDelData[0];
            n550CpjConDelData = P007F2_n550CpjConDelData[0];
            A551CpjConDelHora = P007F2_A551CpjConDelHora[0];
            n551CpjConDelHora = P007F2_n551CpjConDelHora[0];
            A552CpjConDelUsuId = P007F2_A552CpjConDelUsuId[0];
            n552CpjConDelUsuId = P007F2_n552CpjConDelUsuId[0];
            A553CpjConDelUsuNome = P007F2_A553CpjConDelUsuNome[0];
            n553CpjConDelUsuNome = P007F2_n553CpjConDelUsuNome[0];
            A159CliMatricula = P007F2_A159CliMatricula[0];
            A160CliNomeFamiliar = P007F2_A160CliNomeFamiliar[0];
            A365CpjTipoId = P007F2_A365CpjTipoId[0];
            A170CpjNomeFan = P007F2_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P007F2_A171CpjRazaoSoc[0];
            A176CpjMatricula = P007F2_A176CpjMatricula[0];
            A187CpjCNPJ = P007F2_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P007F2_A188CpjCNPJFormat[0];
            A189CpjIE = P007F2_A189CpjIE[0];
            A207CpjAtivo = P007F2_A207CpjAtivo[0];
            A261CpjTelNum = P007F2_A261CpjTelNum[0];
            n261CpjTelNum = P007F2_n261CpjTelNum[0];
            A262CpjTelRam = P007F2_A262CpjTelRam[0];
            n262CpjTelRam = P007F2_n262CpjTelRam[0];
            A263CpjCelNum = P007F2_A263CpjCelNum[0];
            n263CpjCelNum = P007F2_n263CpjCelNum[0];
            A264CpjWppNum = P007F2_A264CpjWppNum[0];
            n264CpjWppNum = P007F2_n264CpjWppNum[0];
            A265CpjWebsite = P007F2_A265CpjWebsite[0];
            n265CpjWebsite = P007F2_n265CpjWebsite[0];
            A266CpjEmail = P007F2_A266CpjEmail[0];
            n266CpjEmail = P007F2_n266CpjEmail[0];
            A268CpjUltConSeq = P007F2_A268CpjUltConSeq[0];
            n268CpjUltConSeq = P007F2_n268CpjUltConSeq[0];
            A366CpjTipoSigla = P007F2_A366CpjTipoSigla[0];
            A367CpjTipoNome = P007F2_A367CpjTipoNome[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj_contato";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A366CpjTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Descrição";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ Formatado";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal do Telefone";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUltConSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Contato Cadastrado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A268CpjUltConSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo de Contato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A270CpjConTipoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Contato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A271CpjConTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Tipo do Contato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A272CpjConTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCPF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CPF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A273CpjConCPF), 11, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCPFFormat";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CPF";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A274CpjConCPFFormat;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Contato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A275CpjConNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNomePrim";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A276CpjConNomePrim;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConSobrenome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sobrenome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A277CpjConSobrenome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjNomeSocial";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Como deseja ser chamado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A278CpjNomeSocial;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Gênero";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A279CpjConGenID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Genero Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A280CpjConGenSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Genero Nome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A281CpjConGenNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNascimento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Nascimento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A282CpjConNascimento, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTelNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Telefone";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A283CpjConTelNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTelRam";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A284CpjConTelRam;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCelNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Celular";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A285CpjConCelNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConWppNum";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "WhatsApp";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A286CpjConWppNum;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConEmail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "E-mail";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A287CpjConEmail;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConLIn";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "LinkedIn";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A288CpjConLIn;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConUltEnd";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Endereço";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A328CpjConUltEnd), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A548CpjConDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A550CpjConDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A551CpjConDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelUsuId";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A552CpjConDelUsuId;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A553CpjConDelUsuNome;
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
         /* Using cursor P007F3 */
         pr_default.execute(1, new Object[] {AV17CliID, AV18CpjID, AV19CpjConSeq});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A269CpjConSeq = P007F3_A269CpjConSeq[0];
            A166CpjID = P007F3_A166CpjID[0];
            A158CliID = P007F3_A158CliID[0];
            A159CliMatricula = P007F3_A159CliMatricula[0];
            A160CliNomeFamiliar = P007F3_A160CliNomeFamiliar[0];
            A365CpjTipoId = P007F3_A365CpjTipoId[0];
            A366CpjTipoSigla = P007F3_A366CpjTipoSigla[0];
            A367CpjTipoNome = P007F3_A367CpjTipoNome[0];
            A170CpjNomeFan = P007F3_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P007F3_A171CpjRazaoSoc[0];
            A176CpjMatricula = P007F3_A176CpjMatricula[0];
            A187CpjCNPJ = P007F3_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P007F3_A188CpjCNPJFormat[0];
            A189CpjIE = P007F3_A189CpjIE[0];
            A207CpjAtivo = P007F3_A207CpjAtivo[0];
            A261CpjTelNum = P007F3_A261CpjTelNum[0];
            n261CpjTelNum = P007F3_n261CpjTelNum[0];
            A262CpjTelRam = P007F3_A262CpjTelRam[0];
            n262CpjTelRam = P007F3_n262CpjTelRam[0];
            A263CpjCelNum = P007F3_A263CpjCelNum[0];
            n263CpjCelNum = P007F3_n263CpjCelNum[0];
            A264CpjWppNum = P007F3_A264CpjWppNum[0];
            n264CpjWppNum = P007F3_n264CpjWppNum[0];
            A265CpjWebsite = P007F3_A265CpjWebsite[0];
            n265CpjWebsite = P007F3_n265CpjWebsite[0];
            A266CpjEmail = P007F3_A266CpjEmail[0];
            n266CpjEmail = P007F3_n266CpjEmail[0];
            A268CpjUltConSeq = P007F3_A268CpjUltConSeq[0];
            n268CpjUltConSeq = P007F3_n268CpjUltConSeq[0];
            A270CpjConTipoID = P007F3_A270CpjConTipoID[0];
            A271CpjConTipoSigla = P007F3_A271CpjConTipoSigla[0];
            A272CpjConTipoNome = P007F3_A272CpjConTipoNome[0];
            A273CpjConCPF = P007F3_A273CpjConCPF[0];
            A274CpjConCPFFormat = P007F3_A274CpjConCPFFormat[0];
            A275CpjConNome = P007F3_A275CpjConNome[0];
            A276CpjConNomePrim = P007F3_A276CpjConNomePrim[0];
            A277CpjConSobrenome = P007F3_A277CpjConSobrenome[0];
            A278CpjNomeSocial = P007F3_A278CpjNomeSocial[0];
            A279CpjConGenID = P007F3_A279CpjConGenID[0];
            A280CpjConGenSigla = P007F3_A280CpjConGenSigla[0];
            A281CpjConGenNome = P007F3_A281CpjConGenNome[0];
            A282CpjConNascimento = P007F3_A282CpjConNascimento[0];
            A283CpjConTelNum = P007F3_A283CpjConTelNum[0];
            n283CpjConTelNum = P007F3_n283CpjConTelNum[0];
            A284CpjConTelRam = P007F3_A284CpjConTelRam[0];
            n284CpjConTelRam = P007F3_n284CpjConTelRam[0];
            A285CpjConCelNum = P007F3_A285CpjConCelNum[0];
            n285CpjConCelNum = P007F3_n285CpjConCelNum[0];
            A286CpjConWppNum = P007F3_A286CpjConWppNum[0];
            n286CpjConWppNum = P007F3_n286CpjConWppNum[0];
            A287CpjConEmail = P007F3_A287CpjConEmail[0];
            n287CpjConEmail = P007F3_n287CpjConEmail[0];
            A288CpjConLIn = P007F3_A288CpjConLIn[0];
            n288CpjConLIn = P007F3_n288CpjConLIn[0];
            A328CpjConUltEnd = P007F3_A328CpjConUltEnd[0];
            n328CpjConUltEnd = P007F3_n328CpjConUltEnd[0];
            A548CpjConDel = P007F3_A548CpjConDel[0];
            A549CpjConDelDataHora = P007F3_A549CpjConDelDataHora[0];
            n549CpjConDelDataHora = P007F3_n549CpjConDelDataHora[0];
            A550CpjConDelData = P007F3_A550CpjConDelData[0];
            n550CpjConDelData = P007F3_n550CpjConDelData[0];
            A551CpjConDelHora = P007F3_A551CpjConDelHora[0];
            n551CpjConDelHora = P007F3_n551CpjConDelHora[0];
            A552CpjConDelUsuId = P007F3_A552CpjConDelUsuId[0];
            n552CpjConDelUsuId = P007F3_n552CpjConDelUsuId[0];
            A553CpjConDelUsuNome = P007F3_A553CpjConDelUsuNome[0];
            n553CpjConDelUsuNome = P007F3_n553CpjConDelUsuNome[0];
            A159CliMatricula = P007F3_A159CliMatricula[0];
            A160CliNomeFamiliar = P007F3_A160CliNomeFamiliar[0];
            A365CpjTipoId = P007F3_A365CpjTipoId[0];
            A170CpjNomeFan = P007F3_A170CpjNomeFan[0];
            A171CpjRazaoSoc = P007F3_A171CpjRazaoSoc[0];
            A176CpjMatricula = P007F3_A176CpjMatricula[0];
            A187CpjCNPJ = P007F3_A187CpjCNPJ[0];
            A188CpjCNPJFormat = P007F3_A188CpjCNPJFormat[0];
            A189CpjIE = P007F3_A189CpjIE[0];
            A207CpjAtivo = P007F3_A207CpjAtivo[0];
            A261CpjTelNum = P007F3_A261CpjTelNum[0];
            n261CpjTelNum = P007F3_n261CpjTelNum[0];
            A262CpjTelRam = P007F3_A262CpjTelRam[0];
            n262CpjTelRam = P007F3_n262CpjTelRam[0];
            A263CpjCelNum = P007F3_A263CpjCelNum[0];
            n263CpjCelNum = P007F3_n263CpjCelNum[0];
            A264CpjWppNum = P007F3_A264CpjWppNum[0];
            n264CpjWppNum = P007F3_n264CpjWppNum[0];
            A265CpjWebsite = P007F3_A265CpjWebsite[0];
            n265CpjWebsite = P007F3_n265CpjWebsite[0];
            A266CpjEmail = P007F3_A266CpjEmail[0];
            n266CpjEmail = P007F3_n266CpjEmail[0];
            A268CpjUltConSeq = P007F3_A268CpjUltConSeq[0];
            n268CpjUltConSeq = P007F3_n268CpjUltConSeq[0];
            A366CpjTipoSigla = P007F3_A366CpjTipoSigla[0];
            A367CpjTipoNome = P007F3_A367CpjTipoNome[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_clientepj_contato";
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CliID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Cliente";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Unidade";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A366CpjTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo Descrição";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CNPJ Formatado";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal do Telefone";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjUltConSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Contato Cadastrado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A268CpjUltConSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sequência";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo de Contato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A270CpjConTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo do Contato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A271CpjConTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Tipo do Contato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A272CpjConTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCPF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CPF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A273CpjConCPF), 11, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCPFFormat";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "CPF";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A274CpjConCPFFormat;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Contato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A275CpjConNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNomePrim";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A276CpjConNomePrim;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConSobrenome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sobrenome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A277CpjConSobrenome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjNomeSocial";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Como deseja ser chamado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A278CpjNomeSocial;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Gênero";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A279CpjConGenID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Genero Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A280CpjConGenSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConGenNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Genero Nome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A281CpjConGenNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConNascimento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Nascimento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A282CpjConNascimento, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTelNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Telefone";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A283CpjConTelNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConTelRam";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ramal";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A284CpjConTelRam;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConCelNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Celular";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A285CpjConCelNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConWppNum";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "WhatsApp";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A286CpjConWppNum;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConEmail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "E-mail";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A287CpjConEmail;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConLIn";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "LinkedIn";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A288CpjConLIn;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConUltEnd";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Endereço";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A328CpjConUltEnd), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A548CpjConDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A550CpjConDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A551CpjConDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelUsuId";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A552CpjConDelUsuId;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "CpjConDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A553CpjConDelUsuNome;
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjUltConSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A268CpjUltConSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConSeq") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConTipoID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A270CpjConTipoID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConTipoSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A271CpjConTipoSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConTipoNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A272CpjConTipoNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConCPF") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A273CpjConCPF), 11, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConCPFFormat") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A274CpjConCPFFormat;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A275CpjConNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConNomePrim") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A276CpjConNomePrim;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConSobrenome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A277CpjConSobrenome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjNomeSocial") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A278CpjNomeSocial;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConGenID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A279CpjConGenID), 9, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConGenSigla") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A280CpjConGenSigla;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConGenNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A281CpjConGenNome;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConNascimento") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A282CpjConNascimento, 2, "/");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConTelNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A283CpjConTelNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConTelRam") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A284CpjConTelRam;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConCelNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A285CpjConCelNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConWppNum") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A286CpjConWppNum;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConEmail") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A287CpjConEmail;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConLIn") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A288CpjConLIn;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConUltEnd") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A328CpjConUltEnd), 4, 0);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDel") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A548CpjConDel);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A549CpjConDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A550CpjConDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A551CpjConDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDelUsuId") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A552CpjConDelUsuId;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "CpjConDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A553CpjConDelUsuNome;
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
         P007F2_A269CpjConSeq = new short[1] ;
         P007F2_A166CpjID = new Guid[] {Guid.Empty} ;
         P007F2_A158CliID = new Guid[] {Guid.Empty} ;
         P007F2_A159CliMatricula = new long[1] ;
         P007F2_A160CliNomeFamiliar = new string[] {""} ;
         P007F2_A365CpjTipoId = new int[1] ;
         P007F2_A366CpjTipoSigla = new string[] {""} ;
         P007F2_A367CpjTipoNome = new string[] {""} ;
         P007F2_A170CpjNomeFan = new string[] {""} ;
         P007F2_A171CpjRazaoSoc = new string[] {""} ;
         P007F2_A176CpjMatricula = new long[1] ;
         P007F2_A187CpjCNPJ = new long[1] ;
         P007F2_A188CpjCNPJFormat = new string[] {""} ;
         P007F2_A189CpjIE = new string[] {""} ;
         P007F2_A207CpjAtivo = new bool[] {false} ;
         P007F2_A261CpjTelNum = new string[] {""} ;
         P007F2_n261CpjTelNum = new bool[] {false} ;
         P007F2_A262CpjTelRam = new string[] {""} ;
         P007F2_n262CpjTelRam = new bool[] {false} ;
         P007F2_A263CpjCelNum = new string[] {""} ;
         P007F2_n263CpjCelNum = new bool[] {false} ;
         P007F2_A264CpjWppNum = new string[] {""} ;
         P007F2_n264CpjWppNum = new bool[] {false} ;
         P007F2_A265CpjWebsite = new string[] {""} ;
         P007F2_n265CpjWebsite = new bool[] {false} ;
         P007F2_A266CpjEmail = new string[] {""} ;
         P007F2_n266CpjEmail = new bool[] {false} ;
         P007F2_A268CpjUltConSeq = new short[1] ;
         P007F2_n268CpjUltConSeq = new bool[] {false} ;
         P007F2_A270CpjConTipoID = new int[1] ;
         P007F2_A271CpjConTipoSigla = new string[] {""} ;
         P007F2_A272CpjConTipoNome = new string[] {""} ;
         P007F2_A273CpjConCPF = new long[1] ;
         P007F2_A274CpjConCPFFormat = new string[] {""} ;
         P007F2_A275CpjConNome = new string[] {""} ;
         P007F2_A276CpjConNomePrim = new string[] {""} ;
         P007F2_A277CpjConSobrenome = new string[] {""} ;
         P007F2_A278CpjNomeSocial = new string[] {""} ;
         P007F2_A279CpjConGenID = new int[1] ;
         P007F2_A280CpjConGenSigla = new string[] {""} ;
         P007F2_A281CpjConGenNome = new string[] {""} ;
         P007F2_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         P007F2_A283CpjConTelNum = new string[] {""} ;
         P007F2_n283CpjConTelNum = new bool[] {false} ;
         P007F2_A284CpjConTelRam = new string[] {""} ;
         P007F2_n284CpjConTelRam = new bool[] {false} ;
         P007F2_A285CpjConCelNum = new string[] {""} ;
         P007F2_n285CpjConCelNum = new bool[] {false} ;
         P007F2_A286CpjConWppNum = new string[] {""} ;
         P007F2_n286CpjConWppNum = new bool[] {false} ;
         P007F2_A287CpjConEmail = new string[] {""} ;
         P007F2_n287CpjConEmail = new bool[] {false} ;
         P007F2_A288CpjConLIn = new string[] {""} ;
         P007F2_n288CpjConLIn = new bool[] {false} ;
         P007F2_A328CpjConUltEnd = new short[1] ;
         P007F2_n328CpjConUltEnd = new bool[] {false} ;
         P007F2_A548CpjConDel = new bool[] {false} ;
         P007F2_A549CpjConDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007F2_n549CpjConDelDataHora = new bool[] {false} ;
         P007F2_A550CpjConDelData = new DateTime[] {DateTime.MinValue} ;
         P007F2_n550CpjConDelData = new bool[] {false} ;
         P007F2_A551CpjConDelHora = new DateTime[] {DateTime.MinValue} ;
         P007F2_n551CpjConDelHora = new bool[] {false} ;
         P007F2_A552CpjConDelUsuId = new string[] {""} ;
         P007F2_n552CpjConDelUsuId = new bool[] {false} ;
         P007F2_A553CpjConDelUsuNome = new string[] {""} ;
         P007F2_n553CpjConDelUsuNome = new bool[] {false} ;
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
         A271CpjConTipoSigla = "";
         A272CpjConTipoNome = "";
         A274CpjConCPFFormat = "";
         A275CpjConNome = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         A278CpjNomeSocial = "";
         A280CpjConGenSigla = "";
         A281CpjConGenNome = "";
         A282CpjConNascimento = DateTime.MinValue;
         A283CpjConTelNum = "";
         A284CpjConTelRam = "";
         A285CpjConCelNum = "";
         A286CpjConWppNum = "";
         A287CpjConEmail = "";
         A288CpjConLIn = "";
         A549CpjConDelDataHora = (DateTime)(DateTime.MinValue);
         A550CpjConDelData = (DateTime)(DateTime.MinValue);
         A551CpjConDelHora = (DateTime)(DateTime.MinValue);
         A552CpjConDelUsuId = "";
         A553CpjConDelUsuNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007F3_A269CpjConSeq = new short[1] ;
         P007F3_A166CpjID = new Guid[] {Guid.Empty} ;
         P007F3_A158CliID = new Guid[] {Guid.Empty} ;
         P007F3_A159CliMatricula = new long[1] ;
         P007F3_A160CliNomeFamiliar = new string[] {""} ;
         P007F3_A365CpjTipoId = new int[1] ;
         P007F3_A366CpjTipoSigla = new string[] {""} ;
         P007F3_A367CpjTipoNome = new string[] {""} ;
         P007F3_A170CpjNomeFan = new string[] {""} ;
         P007F3_A171CpjRazaoSoc = new string[] {""} ;
         P007F3_A176CpjMatricula = new long[1] ;
         P007F3_A187CpjCNPJ = new long[1] ;
         P007F3_A188CpjCNPJFormat = new string[] {""} ;
         P007F3_A189CpjIE = new string[] {""} ;
         P007F3_A207CpjAtivo = new bool[] {false} ;
         P007F3_A261CpjTelNum = new string[] {""} ;
         P007F3_n261CpjTelNum = new bool[] {false} ;
         P007F3_A262CpjTelRam = new string[] {""} ;
         P007F3_n262CpjTelRam = new bool[] {false} ;
         P007F3_A263CpjCelNum = new string[] {""} ;
         P007F3_n263CpjCelNum = new bool[] {false} ;
         P007F3_A264CpjWppNum = new string[] {""} ;
         P007F3_n264CpjWppNum = new bool[] {false} ;
         P007F3_A265CpjWebsite = new string[] {""} ;
         P007F3_n265CpjWebsite = new bool[] {false} ;
         P007F3_A266CpjEmail = new string[] {""} ;
         P007F3_n266CpjEmail = new bool[] {false} ;
         P007F3_A268CpjUltConSeq = new short[1] ;
         P007F3_n268CpjUltConSeq = new bool[] {false} ;
         P007F3_A270CpjConTipoID = new int[1] ;
         P007F3_A271CpjConTipoSigla = new string[] {""} ;
         P007F3_A272CpjConTipoNome = new string[] {""} ;
         P007F3_A273CpjConCPF = new long[1] ;
         P007F3_A274CpjConCPFFormat = new string[] {""} ;
         P007F3_A275CpjConNome = new string[] {""} ;
         P007F3_A276CpjConNomePrim = new string[] {""} ;
         P007F3_A277CpjConSobrenome = new string[] {""} ;
         P007F3_A278CpjNomeSocial = new string[] {""} ;
         P007F3_A279CpjConGenID = new int[1] ;
         P007F3_A280CpjConGenSigla = new string[] {""} ;
         P007F3_A281CpjConGenNome = new string[] {""} ;
         P007F3_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         P007F3_A283CpjConTelNum = new string[] {""} ;
         P007F3_n283CpjConTelNum = new bool[] {false} ;
         P007F3_A284CpjConTelRam = new string[] {""} ;
         P007F3_n284CpjConTelRam = new bool[] {false} ;
         P007F3_A285CpjConCelNum = new string[] {""} ;
         P007F3_n285CpjConCelNum = new bool[] {false} ;
         P007F3_A286CpjConWppNum = new string[] {""} ;
         P007F3_n286CpjConWppNum = new bool[] {false} ;
         P007F3_A287CpjConEmail = new string[] {""} ;
         P007F3_n287CpjConEmail = new bool[] {false} ;
         P007F3_A288CpjConLIn = new string[] {""} ;
         P007F3_n288CpjConLIn = new bool[] {false} ;
         P007F3_A328CpjConUltEnd = new short[1] ;
         P007F3_n328CpjConUltEnd = new bool[] {false} ;
         P007F3_A548CpjConDel = new bool[] {false} ;
         P007F3_A549CpjConDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007F3_n549CpjConDelDataHora = new bool[] {false} ;
         P007F3_A550CpjConDelData = new DateTime[] {DateTime.MinValue} ;
         P007F3_n550CpjConDelData = new bool[] {false} ;
         P007F3_A551CpjConDelHora = new DateTime[] {DateTime.MinValue} ;
         P007F3_n551CpjConDelHora = new bool[] {false} ;
         P007F3_A552CpjConDelUsuId = new string[] {""} ;
         P007F3_n552CpjConDelUsuId = new bool[] {false} ;
         P007F3_A553CpjConDelUsuNome = new string[] {""} ;
         P007F3_n553CpjConDelUsuNome = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditclientepjcontato__default(),
            new Object[][] {
                new Object[] {
               P007F2_A269CpjConSeq, P007F2_A166CpjID, P007F2_A158CliID, P007F2_A159CliMatricula, P007F2_A160CliNomeFamiliar, P007F2_A365CpjTipoId, P007F2_A366CpjTipoSigla, P007F2_A367CpjTipoNome, P007F2_A170CpjNomeFan, P007F2_A171CpjRazaoSoc,
               P007F2_A176CpjMatricula, P007F2_A187CpjCNPJ, P007F2_A188CpjCNPJFormat, P007F2_A189CpjIE, P007F2_A207CpjAtivo, P007F2_A261CpjTelNum, P007F2_n261CpjTelNum, P007F2_A262CpjTelRam, P007F2_n262CpjTelRam, P007F2_A263CpjCelNum,
               P007F2_n263CpjCelNum, P007F2_A264CpjWppNum, P007F2_n264CpjWppNum, P007F2_A265CpjWebsite, P007F2_n265CpjWebsite, P007F2_A266CpjEmail, P007F2_n266CpjEmail, P007F2_A268CpjUltConSeq, P007F2_n268CpjUltConSeq, P007F2_A270CpjConTipoID,
               P007F2_A271CpjConTipoSigla, P007F2_A272CpjConTipoNome, P007F2_A273CpjConCPF, P007F2_A274CpjConCPFFormat, P007F2_A275CpjConNome, P007F2_A276CpjConNomePrim, P007F2_A277CpjConSobrenome, P007F2_A278CpjNomeSocial, P007F2_A279CpjConGenID, P007F2_A280CpjConGenSigla,
               P007F2_A281CpjConGenNome, P007F2_A282CpjConNascimento, P007F2_A283CpjConTelNum, P007F2_n283CpjConTelNum, P007F2_A284CpjConTelRam, P007F2_n284CpjConTelRam, P007F2_A285CpjConCelNum, P007F2_n285CpjConCelNum, P007F2_A286CpjConWppNum, P007F2_n286CpjConWppNum,
               P007F2_A287CpjConEmail, P007F2_n287CpjConEmail, P007F2_A288CpjConLIn, P007F2_n288CpjConLIn, P007F2_A328CpjConUltEnd, P007F2_n328CpjConUltEnd, P007F2_A548CpjConDel, P007F2_A549CpjConDelDataHora, P007F2_n549CpjConDelDataHora, P007F2_A550CpjConDelData,
               P007F2_n550CpjConDelData, P007F2_A551CpjConDelHora, P007F2_n551CpjConDelHora, P007F2_A552CpjConDelUsuId, P007F2_n552CpjConDelUsuId, P007F2_A553CpjConDelUsuNome, P007F2_n553CpjConDelUsuNome
               }
               , new Object[] {
               P007F3_A269CpjConSeq, P007F3_A166CpjID, P007F3_A158CliID, P007F3_A159CliMatricula, P007F3_A160CliNomeFamiliar, P007F3_A365CpjTipoId, P007F3_A366CpjTipoSigla, P007F3_A367CpjTipoNome, P007F3_A170CpjNomeFan, P007F3_A171CpjRazaoSoc,
               P007F3_A176CpjMatricula, P007F3_A187CpjCNPJ, P007F3_A188CpjCNPJFormat, P007F3_A189CpjIE, P007F3_A207CpjAtivo, P007F3_A261CpjTelNum, P007F3_n261CpjTelNum, P007F3_A262CpjTelRam, P007F3_n262CpjTelRam, P007F3_A263CpjCelNum,
               P007F3_n263CpjCelNum, P007F3_A264CpjWppNum, P007F3_n264CpjWppNum, P007F3_A265CpjWebsite, P007F3_n265CpjWebsite, P007F3_A266CpjEmail, P007F3_n266CpjEmail, P007F3_A268CpjUltConSeq, P007F3_n268CpjUltConSeq, P007F3_A270CpjConTipoID,
               P007F3_A271CpjConTipoSigla, P007F3_A272CpjConTipoNome, P007F3_A273CpjConCPF, P007F3_A274CpjConCPFFormat, P007F3_A275CpjConNome, P007F3_A276CpjConNomePrim, P007F3_A277CpjConSobrenome, P007F3_A278CpjNomeSocial, P007F3_A279CpjConGenID, P007F3_A280CpjConGenSigla,
               P007F3_A281CpjConGenNome, P007F3_A282CpjConNascimento, P007F3_A283CpjConTelNum, P007F3_n283CpjConTelNum, P007F3_A284CpjConTelRam, P007F3_n284CpjConTelRam, P007F3_A285CpjConCelNum, P007F3_n285CpjConCelNum, P007F3_A286CpjConWppNum, P007F3_n286CpjConWppNum,
               P007F3_A287CpjConEmail, P007F3_n287CpjConEmail, P007F3_A288CpjConLIn, P007F3_n288CpjConLIn, P007F3_A328CpjConUltEnd, P007F3_n328CpjConUltEnd, P007F3_A548CpjConDel, P007F3_A549CpjConDelDataHora, P007F3_n549CpjConDelDataHora, P007F3_A550CpjConDelData,
               P007F3_n550CpjConDelData, P007F3_A551CpjConDelHora, P007F3_n551CpjConDelHora, P007F3_A552CpjConDelUsuId, P007F3_n552CpjConDelUsuId, P007F3_A553CpjConDelUsuNome, P007F3_n553CpjConDelUsuNome
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short AV19CpjConSeq ;
      private short A269CpjConSeq ;
      private short A268CpjUltConSeq ;
      private short A328CpjConUltEnd ;
      private int A365CpjTipoId ;
      private int A270CpjConTipoID ;
      private int A279CpjConGenID ;
      private int AV22GXV1 ;
      private int AV23GXV2 ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private long A187CpjCNPJ ;
      private long A273CpjConCPF ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A261CpjTelNum ;
      private string A263CpjCelNum ;
      private string A264CpjWppNum ;
      private string A283CpjConTelNum ;
      private string A285CpjConCelNum ;
      private string A286CpjConWppNum ;
      private string A552CpjConDelUsuId ;
      private DateTime A549CpjConDelDataHora ;
      private DateTime A550CpjConDelData ;
      private DateTime A551CpjConDelHora ;
      private DateTime A282CpjConNascimento ;
      private bool returnInSub ;
      private bool A207CpjAtivo ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n263CpjCelNum ;
      private bool n264CpjWppNum ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool n268CpjUltConSeq ;
      private bool n283CpjConTelNum ;
      private bool n284CpjConTelRam ;
      private bool n285CpjConCelNum ;
      private bool n286CpjConWppNum ;
      private bool n287CpjConEmail ;
      private bool n288CpjConLIn ;
      private bool n328CpjConUltEnd ;
      private bool A548CpjConDel ;
      private bool n549CpjConDelDataHora ;
      private bool n550CpjConDelData ;
      private bool n551CpjConDelHora ;
      private bool n552CpjConDelUsuId ;
      private bool n553CpjConDelUsuNome ;
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
      private string A271CpjConTipoSigla ;
      private string A272CpjConTipoNome ;
      private string A274CpjConCPFFormat ;
      private string A275CpjConNome ;
      private string A276CpjConNomePrim ;
      private string A277CpjConSobrenome ;
      private string A278CpjNomeSocial ;
      private string A280CpjConGenSigla ;
      private string A281CpjConGenNome ;
      private string A284CpjConTelRam ;
      private string A287CpjConEmail ;
      private string A288CpjConLIn ;
      private string A553CpjConDelUsuNome ;
      private Guid AV17CliID ;
      private Guid AV18CpjID ;
      private Guid A166CpjID ;
      private Guid A158CliID ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private short[] P007F2_A269CpjConSeq ;
      private Guid[] P007F2_A166CpjID ;
      private Guid[] P007F2_A158CliID ;
      private long[] P007F2_A159CliMatricula ;
      private string[] P007F2_A160CliNomeFamiliar ;
      private int[] P007F2_A365CpjTipoId ;
      private string[] P007F2_A366CpjTipoSigla ;
      private string[] P007F2_A367CpjTipoNome ;
      private string[] P007F2_A170CpjNomeFan ;
      private string[] P007F2_A171CpjRazaoSoc ;
      private long[] P007F2_A176CpjMatricula ;
      private long[] P007F2_A187CpjCNPJ ;
      private string[] P007F2_A188CpjCNPJFormat ;
      private string[] P007F2_A189CpjIE ;
      private bool[] P007F2_A207CpjAtivo ;
      private string[] P007F2_A261CpjTelNum ;
      private bool[] P007F2_n261CpjTelNum ;
      private string[] P007F2_A262CpjTelRam ;
      private bool[] P007F2_n262CpjTelRam ;
      private string[] P007F2_A263CpjCelNum ;
      private bool[] P007F2_n263CpjCelNum ;
      private string[] P007F2_A264CpjWppNum ;
      private bool[] P007F2_n264CpjWppNum ;
      private string[] P007F2_A265CpjWebsite ;
      private bool[] P007F2_n265CpjWebsite ;
      private string[] P007F2_A266CpjEmail ;
      private bool[] P007F2_n266CpjEmail ;
      private short[] P007F2_A268CpjUltConSeq ;
      private bool[] P007F2_n268CpjUltConSeq ;
      private int[] P007F2_A270CpjConTipoID ;
      private string[] P007F2_A271CpjConTipoSigla ;
      private string[] P007F2_A272CpjConTipoNome ;
      private long[] P007F2_A273CpjConCPF ;
      private string[] P007F2_A274CpjConCPFFormat ;
      private string[] P007F2_A275CpjConNome ;
      private string[] P007F2_A276CpjConNomePrim ;
      private string[] P007F2_A277CpjConSobrenome ;
      private string[] P007F2_A278CpjNomeSocial ;
      private int[] P007F2_A279CpjConGenID ;
      private string[] P007F2_A280CpjConGenSigla ;
      private string[] P007F2_A281CpjConGenNome ;
      private DateTime[] P007F2_A282CpjConNascimento ;
      private string[] P007F2_A283CpjConTelNum ;
      private bool[] P007F2_n283CpjConTelNum ;
      private string[] P007F2_A284CpjConTelRam ;
      private bool[] P007F2_n284CpjConTelRam ;
      private string[] P007F2_A285CpjConCelNum ;
      private bool[] P007F2_n285CpjConCelNum ;
      private string[] P007F2_A286CpjConWppNum ;
      private bool[] P007F2_n286CpjConWppNum ;
      private string[] P007F2_A287CpjConEmail ;
      private bool[] P007F2_n287CpjConEmail ;
      private string[] P007F2_A288CpjConLIn ;
      private bool[] P007F2_n288CpjConLIn ;
      private short[] P007F2_A328CpjConUltEnd ;
      private bool[] P007F2_n328CpjConUltEnd ;
      private bool[] P007F2_A548CpjConDel ;
      private DateTime[] P007F2_A549CpjConDelDataHora ;
      private bool[] P007F2_n549CpjConDelDataHora ;
      private DateTime[] P007F2_A550CpjConDelData ;
      private bool[] P007F2_n550CpjConDelData ;
      private DateTime[] P007F2_A551CpjConDelHora ;
      private bool[] P007F2_n551CpjConDelHora ;
      private string[] P007F2_A552CpjConDelUsuId ;
      private bool[] P007F2_n552CpjConDelUsuId ;
      private string[] P007F2_A553CpjConDelUsuNome ;
      private bool[] P007F2_n553CpjConDelUsuNome ;
      private short[] P007F3_A269CpjConSeq ;
      private Guid[] P007F3_A166CpjID ;
      private Guid[] P007F3_A158CliID ;
      private long[] P007F3_A159CliMatricula ;
      private string[] P007F3_A160CliNomeFamiliar ;
      private int[] P007F3_A365CpjTipoId ;
      private string[] P007F3_A366CpjTipoSigla ;
      private string[] P007F3_A367CpjTipoNome ;
      private string[] P007F3_A170CpjNomeFan ;
      private string[] P007F3_A171CpjRazaoSoc ;
      private long[] P007F3_A176CpjMatricula ;
      private long[] P007F3_A187CpjCNPJ ;
      private string[] P007F3_A188CpjCNPJFormat ;
      private string[] P007F3_A189CpjIE ;
      private bool[] P007F3_A207CpjAtivo ;
      private string[] P007F3_A261CpjTelNum ;
      private bool[] P007F3_n261CpjTelNum ;
      private string[] P007F3_A262CpjTelRam ;
      private bool[] P007F3_n262CpjTelRam ;
      private string[] P007F3_A263CpjCelNum ;
      private bool[] P007F3_n263CpjCelNum ;
      private string[] P007F3_A264CpjWppNum ;
      private bool[] P007F3_n264CpjWppNum ;
      private string[] P007F3_A265CpjWebsite ;
      private bool[] P007F3_n265CpjWebsite ;
      private string[] P007F3_A266CpjEmail ;
      private bool[] P007F3_n266CpjEmail ;
      private short[] P007F3_A268CpjUltConSeq ;
      private bool[] P007F3_n268CpjUltConSeq ;
      private int[] P007F3_A270CpjConTipoID ;
      private string[] P007F3_A271CpjConTipoSigla ;
      private string[] P007F3_A272CpjConTipoNome ;
      private long[] P007F3_A273CpjConCPF ;
      private string[] P007F3_A274CpjConCPFFormat ;
      private string[] P007F3_A275CpjConNome ;
      private string[] P007F3_A276CpjConNomePrim ;
      private string[] P007F3_A277CpjConSobrenome ;
      private string[] P007F3_A278CpjNomeSocial ;
      private int[] P007F3_A279CpjConGenID ;
      private string[] P007F3_A280CpjConGenSigla ;
      private string[] P007F3_A281CpjConGenNome ;
      private DateTime[] P007F3_A282CpjConNascimento ;
      private string[] P007F3_A283CpjConTelNum ;
      private bool[] P007F3_n283CpjConTelNum ;
      private string[] P007F3_A284CpjConTelRam ;
      private bool[] P007F3_n284CpjConTelRam ;
      private string[] P007F3_A285CpjConCelNum ;
      private bool[] P007F3_n285CpjConCelNum ;
      private string[] P007F3_A286CpjConWppNum ;
      private bool[] P007F3_n286CpjConWppNum ;
      private string[] P007F3_A287CpjConEmail ;
      private bool[] P007F3_n287CpjConEmail ;
      private string[] P007F3_A288CpjConLIn ;
      private bool[] P007F3_n288CpjConLIn ;
      private short[] P007F3_A328CpjConUltEnd ;
      private bool[] P007F3_n328CpjConUltEnd ;
      private bool[] P007F3_A548CpjConDel ;
      private DateTime[] P007F3_A549CpjConDelDataHora ;
      private bool[] P007F3_n549CpjConDelDataHora ;
      private DateTime[] P007F3_A550CpjConDelData ;
      private bool[] P007F3_n550CpjConDelData ;
      private DateTime[] P007F3_A551CpjConDelHora ;
      private bool[] P007F3_n551CpjConDelHora ;
      private string[] P007F3_A552CpjConDelUsuId ;
      private bool[] P007F3_n552CpjConDelUsuId ;
      private string[] P007F3_A553CpjConDelUsuNome ;
      private bool[] P007F3_n553CpjConDelUsuNome ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditclientepjcontato__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007F2;
          prmP007F2 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmP007F3;
          prmP007F3 = new Object[] {
          new ParDef("AV17CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV18CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV19CpjConSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007F2", "SELECT T1.CpjConSeq, T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T3.CpjTipoId AS CpjTipoId, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, T3.CpjUltConSeq, T1.CpjConTipoID, T1.CpjConTipoSigla, T1.CpjConTipoNome, T1.CpjConCPF, T1.CpjConCPFFormat, T1.CpjConNome, T1.CpjConNomePrim, T1.CpjConSobrenome, T1.CpjNomeSocial, T1.CpjConGenID, T1.CpjConGenSigla, T1.CpjConGenNome, T1.CpjConNascimento, T1.CpjConTelNum, T1.CpjConTelRam, T1.CpjConCelNum, T1.CpjConWppNum, T1.CpjConEmail, T1.CpjConLIn, T1.CpjConUltEnd, T1.CpjConDel, T1.CpjConDelDataHora, T1.CpjConDelData, T1.CpjConDelHora, T1.CpjConDelUsuId, T1.CpjConDelUsuNome FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID and T1.CpjConSeq = :AV19CpjConSeq ORDER BY T1.CliID, T1.CpjID, T1.CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007F2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007F3", "SELECT T1.CpjConSeq, T1.CpjID, T1.CliID, T2.CliMatricula, T2.CliNomeFamiliar, T3.CpjTipoId AS CpjTipoId, T4.PjtSigla AS CpjTipoSigla, T4.PjtNome AS CpjTipoNome, T3.CpjNomeFan, T3.CpjRazaoSoc, T3.CpjMatricula, T3.CpjCNPJ, T3.CpjCNPJFormat, T3.CpjIE, T3.CpjAtivo, T3.CpjTelNum, T3.CpjTelRam, T3.CpjCelNum, T3.CpjWppNum, T3.CpjWebsite, T3.CpjEmail, T3.CpjUltConSeq, T1.CpjConTipoID, T1.CpjConTipoSigla, T1.CpjConTipoNome, T1.CpjConCPF, T1.CpjConCPFFormat, T1.CpjConNome, T1.CpjConNomePrim, T1.CpjConSobrenome, T1.CpjNomeSocial, T1.CpjConGenID, T1.CpjConGenSigla, T1.CpjConGenNome, T1.CpjConNascimento, T1.CpjConTelNum, T1.CpjConTelRam, T1.CpjConCelNum, T1.CpjConWppNum, T1.CpjConEmail, T1.CpjConLIn, T1.CpjConUltEnd, T1.CpjConDel, T1.CpjConDelDataHora, T1.CpjConDelData, T1.CpjConDelHora, T1.CpjConDelUsuId, T1.CpjConDelUsuNome FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId) WHERE T1.CliID = :AV17CliID and T1.CpjID = :AV18CpjID and T1.CpjConSeq = :AV19CpjConSeq ORDER BY T1.CliID, T1.CpjID, T1.CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007F3,1, GxCacheFrequency.OFF ,false,true )
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
                ((int[]) buf[29])[0] = rslt.getInt(23);
                ((string[]) buf[30])[0] = rslt.getVarchar(24);
                ((string[]) buf[31])[0] = rslt.getVarchar(25);
                ((long[]) buf[32])[0] = rslt.getLong(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((string[]) buf[34])[0] = rslt.getVarchar(28);
                ((string[]) buf[35])[0] = rslt.getVarchar(29);
                ((string[]) buf[36])[0] = rslt.getVarchar(30);
                ((string[]) buf[37])[0] = rslt.getVarchar(31);
                ((int[]) buf[38])[0] = rslt.getInt(32);
                ((string[]) buf[39])[0] = rslt.getVarchar(33);
                ((string[]) buf[40])[0] = rslt.getVarchar(34);
                ((DateTime[]) buf[41])[0] = rslt.getGXDate(35);
                ((string[]) buf[42])[0] = rslt.getString(36, 20);
                ((bool[]) buf[43])[0] = rslt.wasNull(36);
                ((string[]) buf[44])[0] = rslt.getVarchar(37);
                ((bool[]) buf[45])[0] = rslt.wasNull(37);
                ((string[]) buf[46])[0] = rslt.getString(38, 20);
                ((bool[]) buf[47])[0] = rslt.wasNull(38);
                ((string[]) buf[48])[0] = rslt.getString(39, 20);
                ((bool[]) buf[49])[0] = rslt.wasNull(39);
                ((string[]) buf[50])[0] = rslt.getVarchar(40);
                ((bool[]) buf[51])[0] = rslt.wasNull(40);
                ((string[]) buf[52])[0] = rslt.getVarchar(41);
                ((bool[]) buf[53])[0] = rslt.wasNull(41);
                ((short[]) buf[54])[0] = rslt.getShort(42);
                ((bool[]) buf[55])[0] = rslt.wasNull(42);
                ((bool[]) buf[56])[0] = rslt.getBool(43);
                ((DateTime[]) buf[57])[0] = rslt.getGXDateTime(44, true);
                ((bool[]) buf[58])[0] = rslt.wasNull(44);
                ((DateTime[]) buf[59])[0] = rslt.getGXDateTime(45);
                ((bool[]) buf[60])[0] = rslt.wasNull(45);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(46);
                ((bool[]) buf[62])[0] = rslt.wasNull(46);
                ((string[]) buf[63])[0] = rslt.getString(47, 40);
                ((bool[]) buf[64])[0] = rslt.wasNull(47);
                ((string[]) buf[65])[0] = rslt.getVarchar(48);
                ((bool[]) buf[66])[0] = rslt.wasNull(48);
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
                ((int[]) buf[29])[0] = rslt.getInt(23);
                ((string[]) buf[30])[0] = rslt.getVarchar(24);
                ((string[]) buf[31])[0] = rslt.getVarchar(25);
                ((long[]) buf[32])[0] = rslt.getLong(26);
                ((string[]) buf[33])[0] = rslt.getVarchar(27);
                ((string[]) buf[34])[0] = rslt.getVarchar(28);
                ((string[]) buf[35])[0] = rslt.getVarchar(29);
                ((string[]) buf[36])[0] = rslt.getVarchar(30);
                ((string[]) buf[37])[0] = rslt.getVarchar(31);
                ((int[]) buf[38])[0] = rslt.getInt(32);
                ((string[]) buf[39])[0] = rslt.getVarchar(33);
                ((string[]) buf[40])[0] = rslt.getVarchar(34);
                ((DateTime[]) buf[41])[0] = rslt.getGXDate(35);
                ((string[]) buf[42])[0] = rslt.getString(36, 20);
                ((bool[]) buf[43])[0] = rslt.wasNull(36);
                ((string[]) buf[44])[0] = rslt.getVarchar(37);
                ((bool[]) buf[45])[0] = rslt.wasNull(37);
                ((string[]) buf[46])[0] = rslt.getString(38, 20);
                ((bool[]) buf[47])[0] = rslt.wasNull(38);
                ((string[]) buf[48])[0] = rslt.getString(39, 20);
                ((bool[]) buf[49])[0] = rslt.wasNull(39);
                ((string[]) buf[50])[0] = rslt.getVarchar(40);
                ((bool[]) buf[51])[0] = rslt.wasNull(40);
                ((string[]) buf[52])[0] = rslt.getVarchar(41);
                ((bool[]) buf[53])[0] = rslt.wasNull(41);
                ((short[]) buf[54])[0] = rslt.getShort(42);
                ((bool[]) buf[55])[0] = rslt.wasNull(42);
                ((bool[]) buf[56])[0] = rslt.getBool(43);
                ((DateTime[]) buf[57])[0] = rslt.getGXDateTime(44, true);
                ((bool[]) buf[58])[0] = rslt.wasNull(44);
                ((DateTime[]) buf[59])[0] = rslt.getGXDateTime(45);
                ((bool[]) buf[60])[0] = rslt.wasNull(45);
                ((DateTime[]) buf[61])[0] = rslt.getGXDateTime(46);
                ((bool[]) buf[62])[0] = rslt.wasNull(46);
                ((string[]) buf[63])[0] = rslt.getString(47, 40);
                ((bool[]) buf[64])[0] = rslt.wasNull(47);
                ((string[]) buf[65])[0] = rslt.getVarchar(48);
                ((bool[]) buf[66])[0] = rslt.wasNull(48);
                return;
       }
    }

 }

}
