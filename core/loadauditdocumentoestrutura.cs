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
   public class loadauditdocumentoestrutura : GXProcedure
   {
      public loadauditdocumentoestrutura( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditdocumentoestrutura( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_SaveOldValues ,
                           ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                           Guid aP2_DocID ,
                           string aP3_ActualMode )
      {
         this.AV14SaveOldValues = aP0_SaveOldValues;
         this.AV11AuditingObject = aP1_AuditingObject;
         this.AV17DocID = aP2_DocID;
         this.AV15ActualMode = aP3_ActualMode;
         initialize();
         executePrivate();
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      public void executeSubmit( string aP0_SaveOldValues ,
                                 ref GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ,
                                 Guid aP2_DocID ,
                                 string aP3_ActualMode )
      {
         loadauditdocumentoestrutura objloadauditdocumentoestrutura;
         objloadauditdocumentoestrutura = new loadauditdocumentoestrutura();
         objloadauditdocumentoestrutura.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditdocumentoestrutura.AV11AuditingObject = aP1_AuditingObject;
         objloadauditdocumentoestrutura.AV17DocID = aP2_DocID;
         objloadauditdocumentoestrutura.AV15ActualMode = aP3_ActualMode;
         objloadauditdocumentoestrutura.context.SetSubmitInitialConfig(context);
         objloadauditdocumentoestrutura.initialize();
         Submit( executePrivateCatch,objloadauditdocumentoestrutura);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditdocumentoestrutura)stateInfo).executePrivate();
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
         /* Using cursor P007H2 */
         pr_default.execute(0, new Object[] {AV17DocID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A289DocID = P007H2_A289DocID[0];
            A325DocVersao = P007H2_A325DocVersao[0];
            A326DocVersaoIDPai = P007H2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007H2_n326DocVersaoIDPai[0];
            A327DocVersaoNomePai = P007H2_A327DocVersaoNomePai[0];
            A290DocOrigem = P007H2_A290DocOrigem[0];
            A291DocOrigemID = P007H2_A291DocOrigemID[0];
            A292DocInsData = P007H2_A292DocInsData[0];
            A293DocInsHora = P007H2_A293DocInsHora[0];
            A294DocInsDataHora = P007H2_A294DocInsDataHora[0];
            A295DocInsUsuID = P007H2_A295DocInsUsuID[0];
            n295DocInsUsuID = P007H2_n295DocInsUsuID[0];
            A296DocUpdData = P007H2_A296DocUpdData[0];
            n296DocUpdData = P007H2_n296DocUpdData[0];
            A297DocUpdHora = P007H2_A297DocUpdHora[0];
            n297DocUpdHora = P007H2_n297DocUpdHora[0];
            A298DocUpdDataHora = P007H2_A298DocUpdDataHora[0];
            n298DocUpdDataHora = P007H2_n298DocUpdDataHora[0];
            A299DocUpdUsuID = P007H2_A299DocUpdUsuID[0];
            n299DocUpdUsuID = P007H2_n299DocUpdUsuID[0];
            A300DocDel = P007H2_A300DocDel[0];
            A301DocDelData = P007H2_A301DocDelData[0];
            n301DocDelData = P007H2_n301DocDelData[0];
            A302DocDelHora = P007H2_A302DocDelHora[0];
            n302DocDelHora = P007H2_n302DocDelHora[0];
            A303DocDelDataHora = P007H2_A303DocDelDataHora[0];
            n303DocDelDataHora = P007H2_n303DocDelDataHora[0];
            A304DocDelUsuID = P007H2_A304DocDelUsuID[0];
            n304DocDelUsuID = P007H2_n304DocDelUsuID[0];
            A305DocNome = P007H2_A305DocNome[0];
            A146DocTipoID = P007H2_A146DocTipoID[0];
            A147DocTipoSigla = P007H2_A147DocTipoSigla[0];
            A148DocTipoNome = P007H2_A148DocTipoNome[0];
            A219DocTipoAtivo = P007H2_A219DocTipoAtivo[0];
            A306DocUltArqSeq = P007H2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007H2_n306DocUltArqSeq[0];
            A327DocVersaoNomePai = P007H2_A327DocVersaoNomePai[0];
            A147DocTipoSigla = P007H2_A147DocTipoSigla[0];
            A148DocTipoNome = P007H2_A148DocTipoNome[0];
            A219DocTipoAtivo = P007H2_A219DocTipoAtivo[0];
            AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
            AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
            AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
            AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento";
            AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
            AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A289DocID.ToString();
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersao";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersaoNomePai";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento Original";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A327DocVersaoNomePai;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocOrigem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A290DocOrigem;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocOrigemID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Origem";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A291DocOrigemID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A292DocInsData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A293DocInsHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de inclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A295DocInsUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.DToC( A296DocUpdData, 2, "/");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A297DocUpdHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Última Alteração";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A299DocUpdUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDel";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A300DocDel);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelData";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A304DocDelUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A305DocNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo de Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A146DocTipoID), 9, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoSigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A147DocTipoSigla;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A148DocTipoNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A219DocTipoAtivo);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUltArqSeq";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            /* Using cursor P007H3 */
            pr_default.execute(1, new Object[] {A289DocID});
            while ( (pr_default.getStatus(1) != 101) )
            {
               A307DocArqSeq = P007H3_A307DocArqSeq[0];
               A308DocArqInsData = P007H3_A308DocArqInsData[0];
               A309DocArqInsHora = P007H3_A309DocArqInsHora[0];
               A310DocArqInsDataHora = P007H3_A310DocArqInsDataHora[0];
               A311DocArqInsUsuID = P007H3_A311DocArqInsUsuID[0];
               n311DocArqInsUsuID = P007H3_n311DocArqInsUsuID[0];
               A312DocArqUpdData = P007H3_A312DocArqUpdData[0];
               n312DocArqUpdData = P007H3_n312DocArqUpdData[0];
               A313DocArqUpdHora = P007H3_A313DocArqUpdHora[0];
               n313DocArqUpdHora = P007H3_n313DocArqUpdHora[0];
               A314DocArqUpdDataHora = P007H3_A314DocArqUpdDataHora[0];
               n314DocArqUpdDataHora = P007H3_n314DocArqUpdDataHora[0];
               A315DocArqUsuID = P007H3_A315DocArqUsuID[0];
               n315DocArqUsuID = P007H3_n315DocArqUsuID[0];
               A316DocArqDel = P007H3_A316DocArqDel[0];
               A317DocArqDelData = P007H3_A317DocArqDelData[0];
               n317DocArqDelData = P007H3_n317DocArqDelData[0];
               A319DocArqDelDataHora = P007H3_A319DocArqDelDataHora[0];
               n319DocArqDelDataHora = P007H3_n319DocArqDelDataHora[0];
               A320DocArqDelUsuID = P007H3_A320DocArqDelUsuID[0];
               n320DocArqDelUsuID = P007H3_n320DocArqDelUsuID[0];
               A322DocArqConteudoNome = P007H3_A322DocArqConteudoNome[0];
               A323DocArqConteudoExtensao = P007H3_A323DocArqConteudoExtensao[0];
               A324DocArqObservacao = P007H3_A324DocArqObservacao[0];
               n324DocArqObservacao = P007H3_n324DocArqObservacao[0];
               A645DocArqArmExternoPath = P007H3_A645DocArqArmExternoPath[0];
               n645DocArqArmExternoPath = P007H3_n645DocArqArmExternoPath[0];
               A644DocArqArmExterno = P007H3_A644DocArqArmExterno[0];
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento_arquivo";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A320DocArqDelUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Arquivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExternoPath";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Local do Arquivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A645DocArqArmExternoPath;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExterno";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Armazenamento Externo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               pr_default.readNext(1);
            }
            pr_default.close(1);
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
      }

      protected void S121( )
      {
         /* 'LOADNEWVALUES' Routine */
         returnInSub = false;
         /* Using cursor P007H5 */
         pr_default.execute(2, new Object[] {AV17DocID});
         while ( (pr_default.getStatus(2) != 101) )
         {
            A289DocID = P007H5_A289DocID[0];
            A325DocVersao = P007H5_A325DocVersao[0];
            A326DocVersaoIDPai = P007H5_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007H5_n326DocVersaoIDPai[0];
            A327DocVersaoNomePai = P007H5_A327DocVersaoNomePai[0];
            A290DocOrigem = P007H5_A290DocOrigem[0];
            A291DocOrigemID = P007H5_A291DocOrigemID[0];
            A292DocInsData = P007H5_A292DocInsData[0];
            A293DocInsHora = P007H5_A293DocInsHora[0];
            A294DocInsDataHora = P007H5_A294DocInsDataHora[0];
            A295DocInsUsuID = P007H5_A295DocInsUsuID[0];
            n295DocInsUsuID = P007H5_n295DocInsUsuID[0];
            A296DocUpdData = P007H5_A296DocUpdData[0];
            n296DocUpdData = P007H5_n296DocUpdData[0];
            A297DocUpdHora = P007H5_A297DocUpdHora[0];
            n297DocUpdHora = P007H5_n297DocUpdHora[0];
            A298DocUpdDataHora = P007H5_A298DocUpdDataHora[0];
            n298DocUpdDataHora = P007H5_n298DocUpdDataHora[0];
            A299DocUpdUsuID = P007H5_A299DocUpdUsuID[0];
            n299DocUpdUsuID = P007H5_n299DocUpdUsuID[0];
            A300DocDel = P007H5_A300DocDel[0];
            A301DocDelData = P007H5_A301DocDelData[0];
            n301DocDelData = P007H5_n301DocDelData[0];
            A302DocDelHora = P007H5_A302DocDelHora[0];
            n302DocDelHora = P007H5_n302DocDelHora[0];
            A303DocDelDataHora = P007H5_A303DocDelDataHora[0];
            n303DocDelDataHora = P007H5_n303DocDelDataHora[0];
            A304DocDelUsuID = P007H5_A304DocDelUsuID[0];
            n304DocDelUsuID = P007H5_n304DocDelUsuID[0];
            A305DocNome = P007H5_A305DocNome[0];
            A146DocTipoID = P007H5_A146DocTipoID[0];
            A147DocTipoSigla = P007H5_A147DocTipoSigla[0];
            A148DocTipoNome = P007H5_A148DocTipoNome[0];
            A219DocTipoAtivo = P007H5_A219DocTipoAtivo[0];
            A306DocUltArqSeq = P007H5_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007H5_n306DocUltArqSeq[0];
            A40000GXC1 = P007H5_A40000GXC1[0];
            n40000GXC1 = P007H5_n40000GXC1[0];
            A327DocVersaoNomePai = P007H5_A327DocVersaoNomePai[0];
            A147DocTipoSigla = P007H5_A147DocTipoSigla[0];
            A148DocTipoNome = P007H5_A148DocTipoNome[0];
            A219DocTipoAtivo = P007H5_A219DocTipoAtivo[0];
            A40000GXC1 = P007H5_A40000GXC1[0];
            n40000GXC1 = P007H5_n40000GXC1[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento";
               AV12AuditingObjectRecordItem.gxTpr_Mode = AV15ActualMode;
               AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A289DocID.ToString();
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersao";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão do Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocVersaoNomePai";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento Original";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A327DocVersaoNomePai;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocOrigem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A290DocOrigem;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocOrigemID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "ID da Origem";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A291DocOrigemID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A292DocInsData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A293DocInsHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocInsUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário de inclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A295DocInsUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A296DocUpdData, 2, "/");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A297DocUpdHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUpdUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário da Última Alteração";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A299DocUpdUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDel";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Registro Excluído";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A300DocDel);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelData";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A304DocDelUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A305DocNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo de Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A146DocTipoID), 9, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoSigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Sigla";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A147DocTipoSigla;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A148DocTipoNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A219DocTipoAtivo);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocUltArqSeq";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Último Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               /* Using cursor P007H6 */
               pr_default.execute(3, new Object[] {A289DocID});
               while ( (pr_default.getStatus(3) != 101) )
               {
                  A307DocArqSeq = P007H6_A307DocArqSeq[0];
                  A308DocArqInsData = P007H6_A308DocArqInsData[0];
                  A309DocArqInsHora = P007H6_A309DocArqInsHora[0];
                  A310DocArqInsDataHora = P007H6_A310DocArqInsDataHora[0];
                  A311DocArqInsUsuID = P007H6_A311DocArqInsUsuID[0];
                  n311DocArqInsUsuID = P007H6_n311DocArqInsUsuID[0];
                  A312DocArqUpdData = P007H6_A312DocArqUpdData[0];
                  n312DocArqUpdData = P007H6_n312DocArqUpdData[0];
                  A313DocArqUpdHora = P007H6_A313DocArqUpdHora[0];
                  n313DocArqUpdHora = P007H6_n313DocArqUpdHora[0];
                  A314DocArqUpdDataHora = P007H6_A314DocArqUpdDataHora[0];
                  n314DocArqUpdDataHora = P007H6_n314DocArqUpdDataHora[0];
                  A315DocArqUsuID = P007H6_A315DocArqUsuID[0];
                  n315DocArqUsuID = P007H6_n315DocArqUsuID[0];
                  A316DocArqDel = P007H6_A316DocArqDel[0];
                  A317DocArqDelData = P007H6_A317DocArqDelData[0];
                  n317DocArqDelData = P007H6_n317DocArqDelData[0];
                  A319DocArqDelDataHora = P007H6_A319DocArqDelDataHora[0];
                  n319DocArqDelDataHora = P007H6_n319DocArqDelDataHora[0];
                  A320DocArqDelUsuID = P007H6_A320DocArqDelUsuID[0];
                  n320DocArqDelUsuID = P007H6_n320DocArqDelUsuID[0];
                  A322DocArqConteudoNome = P007H6_A322DocArqConteudoNome[0];
                  A323DocArqConteudoExtensao = P007H6_A323DocArqConteudoExtensao[0];
                  A324DocArqObservacao = P007H6_A324DocArqObservacao[0];
                  n324DocArqObservacao = P007H6_n324DocArqObservacao[0];
                  A645DocArqArmExternoPath = P007H6_A645DocArqArmExternoPath[0];
                  n645DocArqArmExternoPath = P007H6_n645DocArqArmExternoPath[0];
                  A644DocArqArmExterno = P007H6_A644DocArqArmExterno[0];
                  AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                  AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento_arquivo";
                  AV12AuditingObjectRecordItem.gxTpr_Mode = "INS";
                  AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelData";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelDataHora";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora da Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqDelUsuID";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A320DocArqDelUsuID;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqConteudoNome";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Arquivo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
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
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExternoPath";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Local do Arquivo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A645DocArqArmExternoPath;
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocArqArmExterno";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Armazenamento Externo";
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
                  AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
                  AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
                  pr_default.readNext(3);
               }
               pr_default.close(3);
            }
            if ( StringUtil.StrCmp(AV15ActualMode, "UPD") == 0 )
            {
               AV22CountUpdatedDocArqSeq = 0;
               AV29GXV1 = 1;
               while ( AV29GXV1 <= AV11AuditingObject.gxTpr_Record.Count )
               {
                  AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV29GXV1));
                  if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_documento") == 0 )
                  {
                     AV30GXV2 = 1;
                     while ( AV30GXV2 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV30GXV2));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A289DocID.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocVersao") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A325DocVersao), 4, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocVersaoIDPai") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A326DocVersaoIDPai.ToString();
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocVersaoNomePai") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A327DocVersaoNomePai;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocOrigem") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A290DocOrigem;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocOrigemID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A291DocOrigemID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocInsData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A292DocInsData, 2, "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocInsHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A293DocInsHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocInsDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocInsUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A295DocInsUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUpdData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.DToC( A296DocUpdData, 2, "/");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUpdHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A297DocUpdHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUpdDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUpdUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A299DocUpdUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDel") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A300DocDel);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelData") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelDataHora") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelUsuID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A304DocDelUsuID;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A305DocNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocTipoID") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A146DocTipoID), 9, 0);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocTipoSigla") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A147DocTipoSigla;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocTipoNome") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A148DocTipoNome;
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocTipoAtivo") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A219DocTipoAtivo);
                        }
                        else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocUltArqSeq") == 0 )
                        {
                           AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.Str( (decimal)(A306DocUltArqSeq), 4, 0);
                        }
                        AV30GXV2 = (int)(AV30GXV2+1);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_documento_arquivo") == 0 )
                  {
                     AV21CountKeyAttributes = 0;
                     AV31GXV3 = 1;
                     while ( AV31GXV3 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                     {
                        AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV31GXV3));
                        if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqSeq") == 0 )
                        {
                           AV23KeyDocArqSeq = (short)(Math.Round(NumberUtil.Val( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue, "."), 18, MidpointRounding.ToEven));
                           AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                           if ( AV21CountKeyAttributes == 1 )
                           {
                              if (true) break;
                           }
                        }
                        AV31GXV3 = (int)(AV31GXV3+1);
                     }
                     AV32GXLvl854 = 0;
                     /* Using cursor P007H7 */
                     pr_default.execute(4, new Object[] {A289DocID, AV23KeyDocArqSeq});
                     while ( (pr_default.getStatus(4) != 101) )
                     {
                        A307DocArqSeq = P007H7_A307DocArqSeq[0];
                        A308DocArqInsData = P007H7_A308DocArqInsData[0];
                        A309DocArqInsHora = P007H7_A309DocArqInsHora[0];
                        A310DocArqInsDataHora = P007H7_A310DocArqInsDataHora[0];
                        A311DocArqInsUsuID = P007H7_A311DocArqInsUsuID[0];
                        n311DocArqInsUsuID = P007H7_n311DocArqInsUsuID[0];
                        A312DocArqUpdData = P007H7_A312DocArqUpdData[0];
                        n312DocArqUpdData = P007H7_n312DocArqUpdData[0];
                        A313DocArqUpdHora = P007H7_A313DocArqUpdHora[0];
                        n313DocArqUpdHora = P007H7_n313DocArqUpdHora[0];
                        A314DocArqUpdDataHora = P007H7_A314DocArqUpdDataHora[0];
                        n314DocArqUpdDataHora = P007H7_n314DocArqUpdDataHora[0];
                        A315DocArqUsuID = P007H7_A315DocArqUsuID[0];
                        n315DocArqUsuID = P007H7_n315DocArqUsuID[0];
                        A316DocArqDel = P007H7_A316DocArqDel[0];
                        A317DocArqDelData = P007H7_A317DocArqDelData[0];
                        n317DocArqDelData = P007H7_n317DocArqDelData[0];
                        A319DocArqDelDataHora = P007H7_A319DocArqDelDataHora[0];
                        n319DocArqDelDataHora = P007H7_n319DocArqDelDataHora[0];
                        A320DocArqDelUsuID = P007H7_A320DocArqDelUsuID[0];
                        n320DocArqDelUsuID = P007H7_n320DocArqDelUsuID[0];
                        A322DocArqConteudoNome = P007H7_A322DocArqConteudoNome[0];
                        A323DocArqConteudoExtensao = P007H7_A323DocArqConteudoExtensao[0];
                        A324DocArqObservacao = P007H7_A324DocArqObservacao[0];
                        n324DocArqObservacao = P007H7_n324DocArqObservacao[0];
                        A645DocArqArmExternoPath = P007H7_A645DocArqArmExternoPath[0];
                        n645DocArqArmExternoPath = P007H7_n645DocArqArmExternoPath[0];
                        A644DocArqArmExterno = P007H7_A644DocArqArmExterno[0];
                        AV32GXLvl854 = 1;
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "UPD";
                        AV22CountUpdatedDocArqSeq = (short)(AV22CountUpdatedDocArqSeq+1);
                        AV33GXV4 = 1;
                        while ( AV33GXV4 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                        {
                           AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV33GXV4));
                           if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqSeq") == 0 )
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
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelData") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelDataHora") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqDelUsuID") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A320DocArqDelUsuID;
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
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqArmExternoPath") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A645DocArqArmExternoPath;
                           }
                           else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqArmExterno") == 0 )
                           {
                              AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
                           }
                           AV33GXV4 = (int)(AV33GXV4+1);
                        }
                        /* Exiting from a For First loop. */
                        if (true) break;
                     }
                     pr_default.close(4);
                     if ( AV32GXLvl854 == 0 )
                     {
                        AV12AuditingObjectRecordItem.gxTpr_Mode = "DLT";
                     }
                  }
                  AV29GXV1 = (int)(AV29GXV1+1);
               }
               if ( AV22CountUpdatedDocArqSeq < A40000GXC1 )
               {
                  AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
                  /* Using cursor P007H8 */
                  pr_default.execute(5, new Object[] {AV17DocID});
                  while ( (pr_default.getStatus(5) != 101) )
                  {
                     A289DocID = P007H8_A289DocID[0];
                     A307DocArqSeq = P007H8_A307DocArqSeq[0];
                     A308DocArqInsData = P007H8_A308DocArqInsData[0];
                     A309DocArqInsHora = P007H8_A309DocArqInsHora[0];
                     A310DocArqInsDataHora = P007H8_A310DocArqInsDataHora[0];
                     A311DocArqInsUsuID = P007H8_A311DocArqInsUsuID[0];
                     n311DocArqInsUsuID = P007H8_n311DocArqInsUsuID[0];
                     A312DocArqUpdData = P007H8_A312DocArqUpdData[0];
                     n312DocArqUpdData = P007H8_n312DocArqUpdData[0];
                     A313DocArqUpdHora = P007H8_A313DocArqUpdHora[0];
                     n313DocArqUpdHora = P007H8_n313DocArqUpdHora[0];
                     A314DocArqUpdDataHora = P007H8_A314DocArqUpdDataHora[0];
                     n314DocArqUpdDataHora = P007H8_n314DocArqUpdDataHora[0];
                     A315DocArqUsuID = P007H8_A315DocArqUsuID[0];
                     n315DocArqUsuID = P007H8_n315DocArqUsuID[0];
                     A316DocArqDel = P007H8_A316DocArqDel[0];
                     A317DocArqDelData = P007H8_A317DocArqDelData[0];
                     n317DocArqDelData = P007H8_n317DocArqDelData[0];
                     A319DocArqDelDataHora = P007H8_A319DocArqDelDataHora[0];
                     n319DocArqDelDataHora = P007H8_n319DocArqDelDataHora[0];
                     A320DocArqDelUsuID = P007H8_A320DocArqDelUsuID[0];
                     n320DocArqDelUsuID = P007H8_n320DocArqDelUsuID[0];
                     A322DocArqConteudoNome = P007H8_A322DocArqConteudoNome[0];
                     A323DocArqConteudoExtensao = P007H8_A323DocArqConteudoExtensao[0];
                     A324DocArqObservacao = P007H8_A324DocArqObservacao[0];
                     n324DocArqObservacao = P007H8_n324DocArqObservacao[0];
                     A645DocArqArmExternoPath = P007H8_A645DocArqArmExternoPath[0];
                     n645DocArqArmExternoPath = P007H8_n645DocArqArmExternoPath[0];
                     A644DocArqArmExterno = P007H8_A644DocArqArmExterno[0];
                     AV23KeyDocArqSeq = A307DocArqSeq;
                     AV24RecordExistsDocArqSeq = false;
                     AV35GXV5 = 1;
                     while ( AV35GXV5 <= AV11AuditingObject.gxTpr_Record.Count )
                     {
                        AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV11AuditingObject.gxTpr_Record.Item(AV35GXV5));
                        if ( StringUtil.StrCmp(AV12AuditingObjectRecordItem.gxTpr_Tablename, "tb_documento_arquivo") == 0 )
                        {
                           AV21CountKeyAttributes = 0;
                           AV36GXV6 = 1;
                           while ( AV36GXV6 <= AV12AuditingObjectRecordItem.gxTpr_Attribute.Count )
                           {
                              AV13AuditingObjectRecordItemAttributeItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem)AV12AuditingObjectRecordItem.gxTpr_Attribute.Item(AV36GXV6));
                              if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocArqSeq") == 0 )
                              {
                                 if ( StringUtil.StrCmp(StringUtil.Trim( AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue), StringUtil.Trim( StringUtil.Str( (decimal)(AV23KeyDocArqSeq), 4, 0))) == 0 )
                                 {
                                    AV24RecordExistsDocArqSeq = true;
                                    AV21CountKeyAttributes = (short)(AV21CountKeyAttributes+1);
                                    if ( AV21CountKeyAttributes == 1 )
                                    {
                                       if (true) break;
                                    }
                                 }
                              }
                              AV36GXV6 = (int)(AV36GXV6+1);
                           }
                        }
                        AV35GXV5 = (int)(AV35GXV5+1);
                     }
                     if ( ! ( AV24RecordExistsDocArqSeq ) )
                     {
                        AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
                        AV19AuditingObjectRecordItemNew.gxTpr_Tablename = "tb_documento_arquivo";
                        AV19AuditingObjectRecordItemNew.gxTpr_Mode = "INS";
                        AV18AuditingObjectNewRecords.gxTpr_Record.Add(AV19AuditingObjectRecordItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqSeq";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Sequência";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.Str( (decimal)(A307DocArqSeq), 4, 0);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqInsData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.DToC( A308DocArqInsData, 2, "/");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqInsHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqInsDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqInsUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário de Inclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A311DocArqInsUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqUpdData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data da Última Alteração";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.DToC( A312DocArqUpdData, 2, "/");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqUpdHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Hora da Última Alteração";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A313DocArqUpdHora, 0, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqUpdDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora da Última Alteração";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário da Ultima Alteração";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A315DocArqUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqDel";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Registro Excluído";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A316DocArqDel);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqDelData";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqDelDataHora";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Data/Hora da Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqDelUsuID";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Usuário ID de Exclusão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A320DocArqDelUsuID;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqConteudoNome";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Nome do Arquivo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = true;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A322DocArqConteudoNome;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqConteudoExtensao";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Extensão";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A323DocArqConteudoExtensao;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqObservacao";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Observações";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A324DocArqObservacao;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqArmExternoPath";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Local do Arquivo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = A645DocArqArmExternoPath;
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                        AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Name = "DocArqArmExterno";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Description = "Armazenamento Externo";
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Ispartofkey = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Isdescriptionattribute = false;
                        AV20AuditingObjectRecordItemAttributeItemNew.gxTpr_Newvalue = StringUtil.BoolToStr( A644DocArqArmExterno);
                        AV19AuditingObjectRecordItemNew.gxTpr_Attribute.Add(AV20AuditingObjectRecordItemAttributeItemNew, 0);
                     }
                     pr_default.readNext(5);
                  }
                  pr_default.close(5);
                  AV37GXV7 = 1;
                  while ( AV37GXV7 <= AV18AuditingObjectNewRecords.gxTpr_Record.Count )
                  {
                     AV12AuditingObjectRecordItem = ((GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem)AV18AuditingObjectNewRecords.gxTpr_Record.Item(AV37GXV7));
                     AV11AuditingObject.gxTpr_Record.Add(AV12AuditingObjectRecordItem, 0);
                     AV37GXV7 = (int)(AV37GXV7+1);
                  }
               }
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(2);
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
         P007H2_A289DocID = new Guid[] {Guid.Empty} ;
         P007H2_A325DocVersao = new short[1] ;
         P007H2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007H2_n326DocVersaoIDPai = new bool[] {false} ;
         P007H2_A327DocVersaoNomePai = new string[] {""} ;
         P007H2_A290DocOrigem = new string[] {""} ;
         P007H2_A291DocOrigemID = new string[] {""} ;
         P007H2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         P007H2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_A295DocInsUsuID = new string[] {""} ;
         P007H2_n295DocInsUsuID = new bool[] {false} ;
         P007H2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H2_n296DocUpdData = new bool[] {false} ;
         P007H2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_n297DocUpdHora = new bool[] {false} ;
         P007H2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_n298DocUpdDataHora = new bool[] {false} ;
         P007H2_A299DocUpdUsuID = new string[] {""} ;
         P007H2_n299DocUpdUsuID = new bool[] {false} ;
         P007H2_A300DocDel = new bool[] {false} ;
         P007H2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         P007H2_n301DocDelData = new bool[] {false} ;
         P007H2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_n302DocDelHora = new bool[] {false} ;
         P007H2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H2_n303DocDelDataHora = new bool[] {false} ;
         P007H2_A304DocDelUsuID = new string[] {""} ;
         P007H2_n304DocDelUsuID = new bool[] {false} ;
         P007H2_A305DocNome = new string[] {""} ;
         P007H2_A146DocTipoID = new int[1] ;
         P007H2_A147DocTipoSigla = new string[] {""} ;
         P007H2_A148DocTipoNome = new string[] {""} ;
         P007H2_A219DocTipoAtivo = new bool[] {false} ;
         P007H2_A306DocUltArqSeq = new short[1] ;
         P007H2_n306DocUltArqSeq = new bool[] {false} ;
         A289DocID = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         A327DocVersaoNomePai = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A292DocInsData = DateTime.MinValue;
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A295DocInsUsuID = "";
         A296DocUpdData = DateTime.MinValue;
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A299DocUpdUsuID = "";
         A301DocDelData = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A304DocDelUsuID = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007H3_A289DocID = new Guid[] {Guid.Empty} ;
         P007H3_A307DocArqSeq = new short[1] ;
         P007H3_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007H3_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H3_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H3_A311DocArqInsUsuID = new string[] {""} ;
         P007H3_n311DocArqInsUsuID = new bool[] {false} ;
         P007H3_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H3_n312DocArqUpdData = new bool[] {false} ;
         P007H3_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H3_n313DocArqUpdHora = new bool[] {false} ;
         P007H3_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H3_n314DocArqUpdDataHora = new bool[] {false} ;
         P007H3_A315DocArqUsuID = new string[] {""} ;
         P007H3_n315DocArqUsuID = new bool[] {false} ;
         P007H3_A316DocArqDel = new bool[] {false} ;
         P007H3_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007H3_n317DocArqDelData = new bool[] {false} ;
         P007H3_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H3_n319DocArqDelDataHora = new bool[] {false} ;
         P007H3_A320DocArqDelUsuID = new string[] {""} ;
         P007H3_n320DocArqDelUsuID = new bool[] {false} ;
         P007H3_A322DocArqConteudoNome = new string[] {""} ;
         P007H3_A323DocArqConteudoExtensao = new string[] {""} ;
         P007H3_A324DocArqObservacao = new string[] {""} ;
         P007H3_n324DocArqObservacao = new bool[] {false} ;
         P007H3_A645DocArqArmExternoPath = new string[] {""} ;
         P007H3_n645DocArqArmExternoPath = new bool[] {false} ;
         P007H3_A644DocArqArmExterno = new bool[] {false} ;
         A308DocArqInsData = DateTime.MinValue;
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A311DocArqInsUsuID = "";
         A312DocArqUpdData = DateTime.MinValue;
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A315DocArqUsuID = "";
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A320DocArqDelUsuID = "";
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         A324DocArqObservacao = "";
         A645DocArqArmExternoPath = "";
         P007H5_A289DocID = new Guid[] {Guid.Empty} ;
         P007H5_A325DocVersao = new short[1] ;
         P007H5_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007H5_n326DocVersaoIDPai = new bool[] {false} ;
         P007H5_A327DocVersaoNomePai = new string[] {""} ;
         P007H5_A290DocOrigem = new string[] {""} ;
         P007H5_A291DocOrigemID = new string[] {""} ;
         P007H5_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         P007H5_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_A295DocInsUsuID = new string[] {""} ;
         P007H5_n295DocInsUsuID = new bool[] {false} ;
         P007H5_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H5_n296DocUpdData = new bool[] {false} ;
         P007H5_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_n297DocUpdHora = new bool[] {false} ;
         P007H5_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_n298DocUpdDataHora = new bool[] {false} ;
         P007H5_A299DocUpdUsuID = new string[] {""} ;
         P007H5_n299DocUpdUsuID = new bool[] {false} ;
         P007H5_A300DocDel = new bool[] {false} ;
         P007H5_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         P007H5_n301DocDelData = new bool[] {false} ;
         P007H5_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_n302DocDelHora = new bool[] {false} ;
         P007H5_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H5_n303DocDelDataHora = new bool[] {false} ;
         P007H5_A304DocDelUsuID = new string[] {""} ;
         P007H5_n304DocDelUsuID = new bool[] {false} ;
         P007H5_A305DocNome = new string[] {""} ;
         P007H5_A146DocTipoID = new int[1] ;
         P007H5_A147DocTipoSigla = new string[] {""} ;
         P007H5_A148DocTipoNome = new string[] {""} ;
         P007H5_A219DocTipoAtivo = new bool[] {false} ;
         P007H5_A306DocUltArqSeq = new short[1] ;
         P007H5_n306DocUltArqSeq = new bool[] {false} ;
         P007H5_A40000GXC1 = new int[1] ;
         P007H5_n40000GXC1 = new bool[] {false} ;
         P007H6_A289DocID = new Guid[] {Guid.Empty} ;
         P007H6_A307DocArqSeq = new short[1] ;
         P007H6_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007H6_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H6_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H6_A311DocArqInsUsuID = new string[] {""} ;
         P007H6_n311DocArqInsUsuID = new bool[] {false} ;
         P007H6_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H6_n312DocArqUpdData = new bool[] {false} ;
         P007H6_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H6_n313DocArqUpdHora = new bool[] {false} ;
         P007H6_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H6_n314DocArqUpdDataHora = new bool[] {false} ;
         P007H6_A315DocArqUsuID = new string[] {""} ;
         P007H6_n315DocArqUsuID = new bool[] {false} ;
         P007H6_A316DocArqDel = new bool[] {false} ;
         P007H6_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007H6_n317DocArqDelData = new bool[] {false} ;
         P007H6_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H6_n319DocArqDelDataHora = new bool[] {false} ;
         P007H6_A320DocArqDelUsuID = new string[] {""} ;
         P007H6_n320DocArqDelUsuID = new bool[] {false} ;
         P007H6_A322DocArqConteudoNome = new string[] {""} ;
         P007H6_A323DocArqConteudoExtensao = new string[] {""} ;
         P007H6_A324DocArqObservacao = new string[] {""} ;
         P007H6_n324DocArqObservacao = new bool[] {false} ;
         P007H6_A645DocArqArmExternoPath = new string[] {""} ;
         P007H6_n645DocArqArmExternoPath = new bool[] {false} ;
         P007H6_A644DocArqArmExterno = new bool[] {false} ;
         P007H7_A289DocID = new Guid[] {Guid.Empty} ;
         P007H7_A307DocArqSeq = new short[1] ;
         P007H7_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007H7_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H7_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H7_A311DocArqInsUsuID = new string[] {""} ;
         P007H7_n311DocArqInsUsuID = new bool[] {false} ;
         P007H7_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H7_n312DocArqUpdData = new bool[] {false} ;
         P007H7_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H7_n313DocArqUpdHora = new bool[] {false} ;
         P007H7_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H7_n314DocArqUpdDataHora = new bool[] {false} ;
         P007H7_A315DocArqUsuID = new string[] {""} ;
         P007H7_n315DocArqUsuID = new bool[] {false} ;
         P007H7_A316DocArqDel = new bool[] {false} ;
         P007H7_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007H7_n317DocArqDelData = new bool[] {false} ;
         P007H7_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H7_n319DocArqDelDataHora = new bool[] {false} ;
         P007H7_A320DocArqDelUsuID = new string[] {""} ;
         P007H7_n320DocArqDelUsuID = new bool[] {false} ;
         P007H7_A322DocArqConteudoNome = new string[] {""} ;
         P007H7_A323DocArqConteudoExtensao = new string[] {""} ;
         P007H7_A324DocArqObservacao = new string[] {""} ;
         P007H7_n324DocArqObservacao = new bool[] {false} ;
         P007H7_A645DocArqArmExternoPath = new string[] {""} ;
         P007H7_n645DocArqArmExternoPath = new bool[] {false} ;
         P007H7_A644DocArqArmExterno = new bool[] {false} ;
         AV18AuditingObjectNewRecords = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         P007H8_A289DocID = new Guid[] {Guid.Empty} ;
         P007H8_A307DocArqSeq = new short[1] ;
         P007H8_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         P007H8_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         P007H8_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H8_A311DocArqInsUsuID = new string[] {""} ;
         P007H8_n311DocArqInsUsuID = new bool[] {false} ;
         P007H8_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         P007H8_n312DocArqUpdData = new bool[] {false} ;
         P007H8_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007H8_n313DocArqUpdHora = new bool[] {false} ;
         P007H8_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H8_n314DocArqUpdDataHora = new bool[] {false} ;
         P007H8_A315DocArqUsuID = new string[] {""} ;
         P007H8_n315DocArqUsuID = new bool[] {false} ;
         P007H8_A316DocArqDel = new bool[] {false} ;
         P007H8_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         P007H8_n317DocArqDelData = new bool[] {false} ;
         P007H8_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007H8_n319DocArqDelDataHora = new bool[] {false} ;
         P007H8_A320DocArqDelUsuID = new string[] {""} ;
         P007H8_n320DocArqDelUsuID = new bool[] {false} ;
         P007H8_A322DocArqConteudoNome = new string[] {""} ;
         P007H8_A323DocArqConteudoExtensao = new string[] {""} ;
         P007H8_A324DocArqObservacao = new string[] {""} ;
         P007H8_n324DocArqObservacao = new bool[] {false} ;
         P007H8_A645DocArqArmExternoPath = new string[] {""} ;
         P007H8_n645DocArqArmExternoPath = new bool[] {false} ;
         P007H8_A644DocArqArmExterno = new bool[] {false} ;
         AV19AuditingObjectRecordItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV20AuditingObjectRecordItemAttributeItemNew = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditdocumentoestrutura__default(),
            new Object[][] {
                new Object[] {
               P007H2_A289DocID, P007H2_A325DocVersao, P007H2_A326DocVersaoIDPai, P007H2_n326DocVersaoIDPai, P007H2_A327DocVersaoNomePai, P007H2_A290DocOrigem, P007H2_A291DocOrigemID, P007H2_A292DocInsData, P007H2_A293DocInsHora, P007H2_A294DocInsDataHora,
               P007H2_A295DocInsUsuID, P007H2_n295DocInsUsuID, P007H2_A296DocUpdData, P007H2_n296DocUpdData, P007H2_A297DocUpdHora, P007H2_n297DocUpdHora, P007H2_A298DocUpdDataHora, P007H2_n298DocUpdDataHora, P007H2_A299DocUpdUsuID, P007H2_n299DocUpdUsuID,
               P007H2_A300DocDel, P007H2_A301DocDelData, P007H2_n301DocDelData, P007H2_A302DocDelHora, P007H2_n302DocDelHora, P007H2_A303DocDelDataHora, P007H2_n303DocDelDataHora, P007H2_A304DocDelUsuID, P007H2_n304DocDelUsuID, P007H2_A305DocNome,
               P007H2_A146DocTipoID, P007H2_A147DocTipoSigla, P007H2_A148DocTipoNome, P007H2_A219DocTipoAtivo, P007H2_A306DocUltArqSeq, P007H2_n306DocUltArqSeq
               }
               , new Object[] {
               P007H3_A289DocID, P007H3_A307DocArqSeq, P007H3_A308DocArqInsData, P007H3_A309DocArqInsHora, P007H3_A310DocArqInsDataHora, P007H3_A311DocArqInsUsuID, P007H3_n311DocArqInsUsuID, P007H3_A312DocArqUpdData, P007H3_n312DocArqUpdData, P007H3_A313DocArqUpdHora,
               P007H3_n313DocArqUpdHora, P007H3_A314DocArqUpdDataHora, P007H3_n314DocArqUpdDataHora, P007H3_A315DocArqUsuID, P007H3_n315DocArqUsuID, P007H3_A316DocArqDel, P007H3_A317DocArqDelData, P007H3_n317DocArqDelData, P007H3_A319DocArqDelDataHora, P007H3_n319DocArqDelDataHora,
               P007H3_A320DocArqDelUsuID, P007H3_n320DocArqDelUsuID, P007H3_A322DocArqConteudoNome, P007H3_A323DocArqConteudoExtensao, P007H3_A324DocArqObservacao, P007H3_n324DocArqObservacao, P007H3_A645DocArqArmExternoPath, P007H3_n645DocArqArmExternoPath, P007H3_A644DocArqArmExterno
               }
               , new Object[] {
               P007H5_A289DocID, P007H5_A325DocVersao, P007H5_A326DocVersaoIDPai, P007H5_n326DocVersaoIDPai, P007H5_A327DocVersaoNomePai, P007H5_A290DocOrigem, P007H5_A291DocOrigemID, P007H5_A292DocInsData, P007H5_A293DocInsHora, P007H5_A294DocInsDataHora,
               P007H5_A295DocInsUsuID, P007H5_n295DocInsUsuID, P007H5_A296DocUpdData, P007H5_n296DocUpdData, P007H5_A297DocUpdHora, P007H5_n297DocUpdHora, P007H5_A298DocUpdDataHora, P007H5_n298DocUpdDataHora, P007H5_A299DocUpdUsuID, P007H5_n299DocUpdUsuID,
               P007H5_A300DocDel, P007H5_A301DocDelData, P007H5_n301DocDelData, P007H5_A302DocDelHora, P007H5_n302DocDelHora, P007H5_A303DocDelDataHora, P007H5_n303DocDelDataHora, P007H5_A304DocDelUsuID, P007H5_n304DocDelUsuID, P007H5_A305DocNome,
               P007H5_A146DocTipoID, P007H5_A147DocTipoSigla, P007H5_A148DocTipoNome, P007H5_A219DocTipoAtivo, P007H5_A306DocUltArqSeq, P007H5_n306DocUltArqSeq, P007H5_A40000GXC1, P007H5_n40000GXC1
               }
               , new Object[] {
               P007H6_A289DocID, P007H6_A307DocArqSeq, P007H6_A308DocArqInsData, P007H6_A309DocArqInsHora, P007H6_A310DocArqInsDataHora, P007H6_A311DocArqInsUsuID, P007H6_n311DocArqInsUsuID, P007H6_A312DocArqUpdData, P007H6_n312DocArqUpdData, P007H6_A313DocArqUpdHora,
               P007H6_n313DocArqUpdHora, P007H6_A314DocArqUpdDataHora, P007H6_n314DocArqUpdDataHora, P007H6_A315DocArqUsuID, P007H6_n315DocArqUsuID, P007H6_A316DocArqDel, P007H6_A317DocArqDelData, P007H6_n317DocArqDelData, P007H6_A319DocArqDelDataHora, P007H6_n319DocArqDelDataHora,
               P007H6_A320DocArqDelUsuID, P007H6_n320DocArqDelUsuID, P007H6_A322DocArqConteudoNome, P007H6_A323DocArqConteudoExtensao, P007H6_A324DocArqObservacao, P007H6_n324DocArqObservacao, P007H6_A645DocArqArmExternoPath, P007H6_n645DocArqArmExternoPath, P007H6_A644DocArqArmExterno
               }
               , new Object[] {
               P007H7_A289DocID, P007H7_A307DocArqSeq, P007H7_A308DocArqInsData, P007H7_A309DocArqInsHora, P007H7_A310DocArqInsDataHora, P007H7_A311DocArqInsUsuID, P007H7_n311DocArqInsUsuID, P007H7_A312DocArqUpdData, P007H7_n312DocArqUpdData, P007H7_A313DocArqUpdHora,
               P007H7_n313DocArqUpdHora, P007H7_A314DocArqUpdDataHora, P007H7_n314DocArqUpdDataHora, P007H7_A315DocArqUsuID, P007H7_n315DocArqUsuID, P007H7_A316DocArqDel, P007H7_A317DocArqDelData, P007H7_n317DocArqDelData, P007H7_A319DocArqDelDataHora, P007H7_n319DocArqDelDataHora,
               P007H7_A320DocArqDelUsuID, P007H7_n320DocArqDelUsuID, P007H7_A322DocArqConteudoNome, P007H7_A323DocArqConteudoExtensao, P007H7_A324DocArqObservacao, P007H7_n324DocArqObservacao, P007H7_A645DocArqArmExternoPath, P007H7_n645DocArqArmExternoPath, P007H7_A644DocArqArmExterno
               }
               , new Object[] {
               P007H8_A289DocID, P007H8_A307DocArqSeq, P007H8_A308DocArqInsData, P007H8_A309DocArqInsHora, P007H8_A310DocArqInsDataHora, P007H8_A311DocArqInsUsuID, P007H8_n311DocArqInsUsuID, P007H8_A312DocArqUpdData, P007H8_n312DocArqUpdData, P007H8_A313DocArqUpdHora,
               P007H8_n313DocArqUpdHora, P007H8_A314DocArqUpdDataHora, P007H8_n314DocArqUpdDataHora, P007H8_A315DocArqUsuID, P007H8_n315DocArqUsuID, P007H8_A316DocArqDel, P007H8_A317DocArqDelData, P007H8_n317DocArqDelData, P007H8_A319DocArqDelDataHora, P007H8_n319DocArqDelDataHora,
               P007H8_A320DocArqDelUsuID, P007H8_n320DocArqDelUsuID, P007H8_A322DocArqConteudoNome, P007H8_A323DocArqConteudoExtensao, P007H8_A324DocArqObservacao, P007H8_n324DocArqObservacao, P007H8_A645DocArqArmExternoPath, P007H8_n645DocArqArmExternoPath, P007H8_A644DocArqArmExterno
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private short A307DocArqSeq ;
      private short AV22CountUpdatedDocArqSeq ;
      private short AV21CountKeyAttributes ;
      private short AV23KeyDocArqSeq ;
      private short AV32GXLvl854 ;
      private int A146DocTipoID ;
      private int A40000GXC1 ;
      private int AV29GXV1 ;
      private int AV30GXV2 ;
      private int AV31GXV3 ;
      private int AV33GXV4 ;
      private int AV35GXV5 ;
      private int AV36GXV6 ;
      private int AV37GXV7 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A295DocInsUsuID ;
      private string A299DocUpdUsuID ;
      private string A304DocDelUsuID ;
      private string A311DocArqInsUsuID ;
      private string A315DocArqUsuID ;
      private string A320DocArqDelUsuID ;
      private DateTime A293DocInsHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime A297DocUpdHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime A301DocDelData ;
      private DateTime A302DocDelHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime A309DocArqInsHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime A317DocArqDelData ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime A292DocInsData ;
      private DateTime A296DocUpdData ;
      private DateTime A308DocArqInsData ;
      private DateTime A312DocArqUpdData ;
      private bool returnInSub ;
      private bool n326DocVersaoIDPai ;
      private bool n295DocInsUsuID ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n298DocUpdDataHora ;
      private bool n299DocUpdUsuID ;
      private bool A300DocDel ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n303DocDelDataHora ;
      private bool n304DocDelUsuID ;
      private bool A219DocTipoAtivo ;
      private bool n306DocUltArqSeq ;
      private bool n311DocArqInsUsuID ;
      private bool n312DocArqUpdData ;
      private bool n313DocArqUpdHora ;
      private bool n314DocArqUpdDataHora ;
      private bool n315DocArqUsuID ;
      private bool A316DocArqDel ;
      private bool n317DocArqDelData ;
      private bool n319DocArqDelDataHora ;
      private bool n320DocArqDelUsuID ;
      private bool n324DocArqObservacao ;
      private bool n645DocArqArmExternoPath ;
      private bool A644DocArqArmExterno ;
      private bool n40000GXC1 ;
      private bool AV24RecordExistsDocArqSeq ;
      private string A327DocVersaoNomePai ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
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
      private Guid[] P007H2_A289DocID ;
      private short[] P007H2_A325DocVersao ;
      private Guid[] P007H2_A326DocVersaoIDPai ;
      private bool[] P007H2_n326DocVersaoIDPai ;
      private string[] P007H2_A327DocVersaoNomePai ;
      private string[] P007H2_A290DocOrigem ;
      private string[] P007H2_A291DocOrigemID ;
      private DateTime[] P007H2_A292DocInsData ;
      private DateTime[] P007H2_A293DocInsHora ;
      private DateTime[] P007H2_A294DocInsDataHora ;
      private string[] P007H2_A295DocInsUsuID ;
      private bool[] P007H2_n295DocInsUsuID ;
      private DateTime[] P007H2_A296DocUpdData ;
      private bool[] P007H2_n296DocUpdData ;
      private DateTime[] P007H2_A297DocUpdHora ;
      private bool[] P007H2_n297DocUpdHora ;
      private DateTime[] P007H2_A298DocUpdDataHora ;
      private bool[] P007H2_n298DocUpdDataHora ;
      private string[] P007H2_A299DocUpdUsuID ;
      private bool[] P007H2_n299DocUpdUsuID ;
      private bool[] P007H2_A300DocDel ;
      private DateTime[] P007H2_A301DocDelData ;
      private bool[] P007H2_n301DocDelData ;
      private DateTime[] P007H2_A302DocDelHora ;
      private bool[] P007H2_n302DocDelHora ;
      private DateTime[] P007H2_A303DocDelDataHora ;
      private bool[] P007H2_n303DocDelDataHora ;
      private string[] P007H2_A304DocDelUsuID ;
      private bool[] P007H2_n304DocDelUsuID ;
      private string[] P007H2_A305DocNome ;
      private int[] P007H2_A146DocTipoID ;
      private string[] P007H2_A147DocTipoSigla ;
      private string[] P007H2_A148DocTipoNome ;
      private bool[] P007H2_A219DocTipoAtivo ;
      private short[] P007H2_A306DocUltArqSeq ;
      private bool[] P007H2_n306DocUltArqSeq ;
      private Guid[] P007H3_A289DocID ;
      private short[] P007H3_A307DocArqSeq ;
      private DateTime[] P007H3_A308DocArqInsData ;
      private DateTime[] P007H3_A309DocArqInsHora ;
      private DateTime[] P007H3_A310DocArqInsDataHora ;
      private string[] P007H3_A311DocArqInsUsuID ;
      private bool[] P007H3_n311DocArqInsUsuID ;
      private DateTime[] P007H3_A312DocArqUpdData ;
      private bool[] P007H3_n312DocArqUpdData ;
      private DateTime[] P007H3_A313DocArqUpdHora ;
      private bool[] P007H3_n313DocArqUpdHora ;
      private DateTime[] P007H3_A314DocArqUpdDataHora ;
      private bool[] P007H3_n314DocArqUpdDataHora ;
      private string[] P007H3_A315DocArqUsuID ;
      private bool[] P007H3_n315DocArqUsuID ;
      private bool[] P007H3_A316DocArqDel ;
      private DateTime[] P007H3_A317DocArqDelData ;
      private bool[] P007H3_n317DocArqDelData ;
      private DateTime[] P007H3_A319DocArqDelDataHora ;
      private bool[] P007H3_n319DocArqDelDataHora ;
      private string[] P007H3_A320DocArqDelUsuID ;
      private bool[] P007H3_n320DocArqDelUsuID ;
      private string[] P007H3_A322DocArqConteudoNome ;
      private string[] P007H3_A323DocArqConteudoExtensao ;
      private string[] P007H3_A324DocArqObservacao ;
      private bool[] P007H3_n324DocArqObservacao ;
      private string[] P007H3_A645DocArqArmExternoPath ;
      private bool[] P007H3_n645DocArqArmExternoPath ;
      private bool[] P007H3_A644DocArqArmExterno ;
      private Guid[] P007H5_A289DocID ;
      private short[] P007H5_A325DocVersao ;
      private Guid[] P007H5_A326DocVersaoIDPai ;
      private bool[] P007H5_n326DocVersaoIDPai ;
      private string[] P007H5_A327DocVersaoNomePai ;
      private string[] P007H5_A290DocOrigem ;
      private string[] P007H5_A291DocOrigemID ;
      private DateTime[] P007H5_A292DocInsData ;
      private DateTime[] P007H5_A293DocInsHora ;
      private DateTime[] P007H5_A294DocInsDataHora ;
      private string[] P007H5_A295DocInsUsuID ;
      private bool[] P007H5_n295DocInsUsuID ;
      private DateTime[] P007H5_A296DocUpdData ;
      private bool[] P007H5_n296DocUpdData ;
      private DateTime[] P007H5_A297DocUpdHora ;
      private bool[] P007H5_n297DocUpdHora ;
      private DateTime[] P007H5_A298DocUpdDataHora ;
      private bool[] P007H5_n298DocUpdDataHora ;
      private string[] P007H5_A299DocUpdUsuID ;
      private bool[] P007H5_n299DocUpdUsuID ;
      private bool[] P007H5_A300DocDel ;
      private DateTime[] P007H5_A301DocDelData ;
      private bool[] P007H5_n301DocDelData ;
      private DateTime[] P007H5_A302DocDelHora ;
      private bool[] P007H5_n302DocDelHora ;
      private DateTime[] P007H5_A303DocDelDataHora ;
      private bool[] P007H5_n303DocDelDataHora ;
      private string[] P007H5_A304DocDelUsuID ;
      private bool[] P007H5_n304DocDelUsuID ;
      private string[] P007H5_A305DocNome ;
      private int[] P007H5_A146DocTipoID ;
      private string[] P007H5_A147DocTipoSigla ;
      private string[] P007H5_A148DocTipoNome ;
      private bool[] P007H5_A219DocTipoAtivo ;
      private short[] P007H5_A306DocUltArqSeq ;
      private bool[] P007H5_n306DocUltArqSeq ;
      private int[] P007H5_A40000GXC1 ;
      private bool[] P007H5_n40000GXC1 ;
      private Guid[] P007H6_A289DocID ;
      private short[] P007H6_A307DocArqSeq ;
      private DateTime[] P007H6_A308DocArqInsData ;
      private DateTime[] P007H6_A309DocArqInsHora ;
      private DateTime[] P007H6_A310DocArqInsDataHora ;
      private string[] P007H6_A311DocArqInsUsuID ;
      private bool[] P007H6_n311DocArqInsUsuID ;
      private DateTime[] P007H6_A312DocArqUpdData ;
      private bool[] P007H6_n312DocArqUpdData ;
      private DateTime[] P007H6_A313DocArqUpdHora ;
      private bool[] P007H6_n313DocArqUpdHora ;
      private DateTime[] P007H6_A314DocArqUpdDataHora ;
      private bool[] P007H6_n314DocArqUpdDataHora ;
      private string[] P007H6_A315DocArqUsuID ;
      private bool[] P007H6_n315DocArqUsuID ;
      private bool[] P007H6_A316DocArqDel ;
      private DateTime[] P007H6_A317DocArqDelData ;
      private bool[] P007H6_n317DocArqDelData ;
      private DateTime[] P007H6_A319DocArqDelDataHora ;
      private bool[] P007H6_n319DocArqDelDataHora ;
      private string[] P007H6_A320DocArqDelUsuID ;
      private bool[] P007H6_n320DocArqDelUsuID ;
      private string[] P007H6_A322DocArqConteudoNome ;
      private string[] P007H6_A323DocArqConteudoExtensao ;
      private string[] P007H6_A324DocArqObservacao ;
      private bool[] P007H6_n324DocArqObservacao ;
      private string[] P007H6_A645DocArqArmExternoPath ;
      private bool[] P007H6_n645DocArqArmExternoPath ;
      private bool[] P007H6_A644DocArqArmExterno ;
      private Guid[] P007H7_A289DocID ;
      private short[] P007H7_A307DocArqSeq ;
      private DateTime[] P007H7_A308DocArqInsData ;
      private DateTime[] P007H7_A309DocArqInsHora ;
      private DateTime[] P007H7_A310DocArqInsDataHora ;
      private string[] P007H7_A311DocArqInsUsuID ;
      private bool[] P007H7_n311DocArqInsUsuID ;
      private DateTime[] P007H7_A312DocArqUpdData ;
      private bool[] P007H7_n312DocArqUpdData ;
      private DateTime[] P007H7_A313DocArqUpdHora ;
      private bool[] P007H7_n313DocArqUpdHora ;
      private DateTime[] P007H7_A314DocArqUpdDataHora ;
      private bool[] P007H7_n314DocArqUpdDataHora ;
      private string[] P007H7_A315DocArqUsuID ;
      private bool[] P007H7_n315DocArqUsuID ;
      private bool[] P007H7_A316DocArqDel ;
      private DateTime[] P007H7_A317DocArqDelData ;
      private bool[] P007H7_n317DocArqDelData ;
      private DateTime[] P007H7_A319DocArqDelDataHora ;
      private bool[] P007H7_n319DocArqDelDataHora ;
      private string[] P007H7_A320DocArqDelUsuID ;
      private bool[] P007H7_n320DocArqDelUsuID ;
      private string[] P007H7_A322DocArqConteudoNome ;
      private string[] P007H7_A323DocArqConteudoExtensao ;
      private string[] P007H7_A324DocArqObservacao ;
      private bool[] P007H7_n324DocArqObservacao ;
      private string[] P007H7_A645DocArqArmExternoPath ;
      private bool[] P007H7_n645DocArqArmExternoPath ;
      private bool[] P007H7_A644DocArqArmExterno ;
      private Guid[] P007H8_A289DocID ;
      private short[] P007H8_A307DocArqSeq ;
      private DateTime[] P007H8_A308DocArqInsData ;
      private DateTime[] P007H8_A309DocArqInsHora ;
      private DateTime[] P007H8_A310DocArqInsDataHora ;
      private string[] P007H8_A311DocArqInsUsuID ;
      private bool[] P007H8_n311DocArqInsUsuID ;
      private DateTime[] P007H8_A312DocArqUpdData ;
      private bool[] P007H8_n312DocArqUpdData ;
      private DateTime[] P007H8_A313DocArqUpdHora ;
      private bool[] P007H8_n313DocArqUpdHora ;
      private DateTime[] P007H8_A314DocArqUpdDataHora ;
      private bool[] P007H8_n314DocArqUpdDataHora ;
      private string[] P007H8_A315DocArqUsuID ;
      private bool[] P007H8_n315DocArqUsuID ;
      private bool[] P007H8_A316DocArqDel ;
      private DateTime[] P007H8_A317DocArqDelData ;
      private bool[] P007H8_n317DocArqDelData ;
      private DateTime[] P007H8_A319DocArqDelDataHora ;
      private bool[] P007H8_n319DocArqDelDataHora ;
      private string[] P007H8_A320DocArqDelUsuID ;
      private bool[] P007H8_n320DocArqDelUsuID ;
      private string[] P007H8_A322DocArqConteudoNome ;
      private string[] P007H8_A323DocArqConteudoExtensao ;
      private string[] P007H8_A324DocArqObservacao ;
      private bool[] P007H8_n324DocArqObservacao ;
      private string[] P007H8_A645DocArqArmExternoPath ;
      private bool[] P007H8_n645DocArqArmExternoPath ;
      private bool[] P007H8_A644DocArqArmExterno ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV18AuditingObjectNewRecords ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV19AuditingObjectRecordItemNew ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV20AuditingObjectRecordItemAttributeItemNew ;
   }

   public class loadauditdocumentoestrutura__default : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
         ,new ForEachCursor(def[3])
         ,new ForEachCursor(def[4])
         ,new ForEachCursor(def[5])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP007H2;
          prmP007H2 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007H3;
          prmP007H3 = new Object[] {
          new ParDef("DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007H5;
          prmP007H5 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007H6;
          prmP007H6 = new Object[] {
          new ParDef("DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007H7;
          prmP007H7 = new Object[] {
          new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV23KeyDocArqSeq",GXType.Int16,4,0)
          };
          Object[] prmP007H8;
          prmP007H8 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007H2", "SELECT T1.DocID, T1.DocVersao, T1.DocVersaoIDPai AS DocVersaoIDPai, T2.DocNome AS DocVersaoNomePai, T1.DocOrigem, T1.DocOrigemID, T1.DocInsData, T1.DocInsHora, T1.DocInsDataHora, T1.DocInsUsuID, T1.DocUpdData, T1.DocUpdHora, T1.DocUpdDataHora, T1.DocUpdUsuID, T1.DocDel, T1.DocDelData, T1.DocDelHora, T1.DocDelDataHora, T1.DocDelUsuID, T1.DocNome, T1.DocTipoID, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, T1.DocUltArqSeq FROM ((tb_documento T1 LEFT JOIN tb_documento T2 ON T2.DocID = T1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = T1.DocTipoID) WHERE T1.DocID = :AV17DocID ORDER BY T1.DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007H3", "SELECT DocID, DocArqSeq, DocArqInsData, DocArqInsHora, DocArqInsDataHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudoNome, DocArqConteudoExtensao, DocArqObservacao, DocArqArmExternoPath, DocArqArmExterno FROM tb_documento_arquivo WHERE DocID = :DocID ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H3,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007H5", "SELECT T1.DocID, T1.DocVersao, T1.DocVersaoIDPai AS DocVersaoIDPai, T2.DocNome AS DocVersaoNomePai, T1.DocOrigem, T1.DocOrigemID, T1.DocInsData, T1.DocInsHora, T1.DocInsDataHora, T1.DocInsUsuID, T1.DocUpdData, T1.DocUpdHora, T1.DocUpdDataHora, T1.DocUpdUsuID, T1.DocDel, T1.DocDelData, T1.DocDelHora, T1.DocDelDataHora, T1.DocDelUsuID, T1.DocNome, T1.DocTipoID, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, T1.DocUltArqSeq, COALESCE( T4.GXC1, 0) AS GXC1 FROM ((tb_documento T1 LEFT JOIN tb_documento T2 ON T2.DocID = T1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = T1.DocTipoID),  (SELECT COUNT(*) AS GXC1 FROM tb_documento_arquivo WHERE DocID = :AV17DocID ) T4 WHERE T1.DocID = :AV17DocID ORDER BY T1.DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H5,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P007H6", "SELECT DocID, DocArqSeq, DocArqInsData, DocArqInsHora, DocArqInsDataHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudoNome, DocArqConteudoExtensao, DocArqObservacao, DocArqArmExternoPath, DocArqArmExterno FROM tb_documento_arquivo WHERE DocID = :DocID ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H6,100, GxCacheFrequency.OFF ,false,false )
             ,new CursorDef("P007H7", "SELECT DocID, DocArqSeq, DocArqInsData, DocArqInsHora, DocArqInsDataHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudoNome, DocArqConteudoExtensao, DocArqObservacao, DocArqArmExternoPath, DocArqArmExterno FROM tb_documento_arquivo WHERE DocID = :DocID and DocArqSeq = :AV23KeyDocArqSeq ORDER BY DocID, DocArqSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H7,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007H8", "SELECT DocID, DocArqSeq, DocArqInsData, DocArqInsHora, DocArqInsDataHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudoNome, DocArqConteudoExtensao, DocArqObservacao, DocArqArmExternoPath, DocArqArmExterno FROM tb_documento_arquivo WHERE DocID = :AV17DocID ORDER BY DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007H8,100, GxCacheFrequency.OFF ,false,false )
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
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((bool[]) buf[20])[0] = rslt.getBool(15);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((int[]) buf[30])[0] = rslt.getInt(21);
                ((string[]) buf[31])[0] = rslt.getVarchar(22);
                ((string[]) buf[32])[0] = rslt.getVarchar(23);
                ((bool[]) buf[33])[0] = rslt.getBool(24);
                ((short[]) buf[34])[0] = rslt.getShort(25);
                ((bool[]) buf[35])[0] = rslt.wasNull(25);
                return;
             case 1 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 40);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((string[]) buf[24])[0] = rslt.getVarchar(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getVarchar(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((bool[]) buf[28])[0] = rslt.getBool(19);
                return;
             case 2 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((bool[]) buf[3])[0] = rslt.wasNull(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((string[]) buf[5])[0] = rslt.getVarchar(5);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(9, true);
                ((string[]) buf[10])[0] = rslt.getString(10, 40);
                ((bool[]) buf[11])[0] = rslt.wasNull(10);
                ((DateTime[]) buf[12])[0] = rslt.getGXDate(11);
                ((bool[]) buf[13])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[15])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[17])[0] = rslt.wasNull(13);
                ((string[]) buf[18])[0] = rslt.getString(14, 40);
                ((bool[]) buf[19])[0] = rslt.wasNull(14);
                ((bool[]) buf[20])[0] = rslt.getBool(15);
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18, true);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((int[]) buf[30])[0] = rslt.getInt(21);
                ((string[]) buf[31])[0] = rslt.getVarchar(22);
                ((string[]) buf[32])[0] = rslt.getVarchar(23);
                ((bool[]) buf[33])[0] = rslt.getBool(24);
                ((short[]) buf[34])[0] = rslt.getShort(25);
                ((bool[]) buf[35])[0] = rslt.wasNull(25);
                ((int[]) buf[36])[0] = rslt.getInt(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                return;
             case 3 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 40);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((string[]) buf[24])[0] = rslt.getVarchar(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getVarchar(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((bool[]) buf[28])[0] = rslt.getBool(19);
                return;
             case 4 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 40);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((string[]) buf[24])[0] = rslt.getVarchar(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getVarchar(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((bool[]) buf[28])[0] = rslt.getBool(19);
                return;
             case 5 :
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
                ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[5])[0] = rslt.getString(6, 40);
                ((bool[]) buf[6])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[7])[0] = rslt.getGXDate(7);
                ((bool[]) buf[8])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(8);
                ((bool[]) buf[10])[0] = rslt.wasNull(8);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(9, true);
                ((bool[]) buf[12])[0] = rslt.wasNull(9);
                ((string[]) buf[13])[0] = rslt.getString(10, 40);
                ((bool[]) buf[14])[0] = rslt.wasNull(10);
                ((bool[]) buf[15])[0] = rslt.getBool(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13, true);
                ((bool[]) buf[19])[0] = rslt.wasNull(13);
                ((string[]) buf[20])[0] = rslt.getString(14, 40);
                ((bool[]) buf[21])[0] = rslt.wasNull(14);
                ((string[]) buf[22])[0] = rslt.getVarchar(15);
                ((string[]) buf[23])[0] = rslt.getVarchar(16);
                ((string[]) buf[24])[0] = rslt.getVarchar(17);
                ((bool[]) buf[25])[0] = rslt.wasNull(17);
                ((string[]) buf[26])[0] = rslt.getVarchar(18);
                ((bool[]) buf[27])[0] = rslt.wasNull(18);
                ((bool[]) buf[28])[0] = rslt.getBool(19);
                return;
       }
    }

 }

}
