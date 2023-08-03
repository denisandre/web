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
   public class loadauditdocumento : GXProcedure
   {
      public loadauditdocumento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public loadauditdocumento( IGxContext context )
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
         loadauditdocumento objloadauditdocumento;
         objloadauditdocumento = new loadauditdocumento();
         objloadauditdocumento.AV14SaveOldValues = aP0_SaveOldValues;
         objloadauditdocumento.AV11AuditingObject = aP1_AuditingObject;
         objloadauditdocumento.AV17DocID = aP2_DocID;
         objloadauditdocumento.AV15ActualMode = aP3_ActualMode;
         objloadauditdocumento.context.SetSubmitInitialConfig(context);
         objloadauditdocumento.initialize();
         Submit( executePrivateCatch,objloadauditdocumento);
         aP1_AuditingObject=this.AV11AuditingObject;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((loadauditdocumento)stateInfo).executePrivate();
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
         /* Using cursor P007I2 */
         pr_default.execute(0, new Object[] {AV17DocID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A289DocID = P007I2_A289DocID[0];
            A325DocVersao = P007I2_A325DocVersao[0];
            A326DocVersaoIDPai = P007I2_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007I2_n326DocVersaoIDPai[0];
            A327DocVersaoNomePai = P007I2_A327DocVersaoNomePai[0];
            A290DocOrigem = P007I2_A290DocOrigem[0];
            A291DocOrigemID = P007I2_A291DocOrigemID[0];
            A292DocInsData = P007I2_A292DocInsData[0];
            A293DocInsHora = P007I2_A293DocInsHora[0];
            A294DocInsDataHora = P007I2_A294DocInsDataHora[0];
            A295DocInsUsuID = P007I2_A295DocInsUsuID[0];
            n295DocInsUsuID = P007I2_n295DocInsUsuID[0];
            A296DocUpdData = P007I2_A296DocUpdData[0];
            n296DocUpdData = P007I2_n296DocUpdData[0];
            A297DocUpdHora = P007I2_A297DocUpdHora[0];
            n297DocUpdHora = P007I2_n297DocUpdHora[0];
            A298DocUpdDataHora = P007I2_A298DocUpdDataHora[0];
            n298DocUpdDataHora = P007I2_n298DocUpdDataHora[0];
            A299DocUpdUsuID = P007I2_A299DocUpdUsuID[0];
            n299DocUpdUsuID = P007I2_n299DocUpdUsuID[0];
            A300DocDel = P007I2_A300DocDel[0];
            A303DocDelDataHora = P007I2_A303DocDelDataHora[0];
            n303DocDelDataHora = P007I2_n303DocDelDataHora[0];
            A301DocDelData = P007I2_A301DocDelData[0];
            n301DocDelData = P007I2_n301DocDelData[0];
            A302DocDelHora = P007I2_A302DocDelHora[0];
            n302DocDelHora = P007I2_n302DocDelHora[0];
            A304DocDelUsuID = P007I2_A304DocDelUsuID[0];
            n304DocDelUsuID = P007I2_n304DocDelUsuID[0];
            A510DocDelUsuNome = P007I2_A510DocDelUsuNome[0];
            n510DocDelUsuNome = P007I2_n510DocDelUsuNome[0];
            A305DocNome = P007I2_A305DocNome[0];
            A146DocTipoID = P007I2_A146DocTipoID[0];
            A147DocTipoSigla = P007I2_A147DocTipoSigla[0];
            A148DocTipoNome = P007I2_A148DocTipoNome[0];
            A219DocTipoAtivo = P007I2_A219DocTipoAtivo[0];
            A306DocUltArqSeq = P007I2_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007I2_n306DocUltArqSeq[0];
            A480DocContrato = P007I2_A480DocContrato[0];
            A481DocAssinado = P007I2_A481DocAssinado[0];
            A640DocAtivo = P007I2_A640DocAtivo[0];
            n640DocAtivo = P007I2_n640DocAtivo[0];
            A327DocVersaoNomePai = P007I2_A327DocVersaoNomePai[0];
            A147DocTipoSigla = P007I2_A147DocTipoSigla[0];
            A148DocTipoNome = P007I2_A148DocTipoNome[0];
            A219DocTipoAtivo = P007I2_A219DocTipoAtivo[0];
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão";
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelDataHora";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
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
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A304DocDelUsuID;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A510DocDelUsuNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocNome";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = A305DocNome;
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoID";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
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
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocContrato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "É um contrato";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A480DocContrato);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocAssinado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assinado";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A481DocAssinado);
            AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
            AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocAtivo";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo?";
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
            AV13AuditingObjectRecordItemAttributeItem.gxTpr_Oldvalue = StringUtil.BoolToStr( A640DocAtivo);
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
         /* Using cursor P007I3 */
         pr_default.execute(1, new Object[] {AV17DocID});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A289DocID = P007I3_A289DocID[0];
            A325DocVersao = P007I3_A325DocVersao[0];
            A326DocVersaoIDPai = P007I3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = P007I3_n326DocVersaoIDPai[0];
            A327DocVersaoNomePai = P007I3_A327DocVersaoNomePai[0];
            A290DocOrigem = P007I3_A290DocOrigem[0];
            A291DocOrigemID = P007I3_A291DocOrigemID[0];
            A292DocInsData = P007I3_A292DocInsData[0];
            A293DocInsHora = P007I3_A293DocInsHora[0];
            A294DocInsDataHora = P007I3_A294DocInsDataHora[0];
            A295DocInsUsuID = P007I3_A295DocInsUsuID[0];
            n295DocInsUsuID = P007I3_n295DocInsUsuID[0];
            A296DocUpdData = P007I3_A296DocUpdData[0];
            n296DocUpdData = P007I3_n296DocUpdData[0];
            A297DocUpdHora = P007I3_A297DocUpdHora[0];
            n297DocUpdHora = P007I3_n297DocUpdHora[0];
            A298DocUpdDataHora = P007I3_A298DocUpdDataHora[0];
            n298DocUpdDataHora = P007I3_n298DocUpdDataHora[0];
            A299DocUpdUsuID = P007I3_A299DocUpdUsuID[0];
            n299DocUpdUsuID = P007I3_n299DocUpdUsuID[0];
            A300DocDel = P007I3_A300DocDel[0];
            A303DocDelDataHora = P007I3_A303DocDelDataHora[0];
            n303DocDelDataHora = P007I3_n303DocDelDataHora[0];
            A301DocDelData = P007I3_A301DocDelData[0];
            n301DocDelData = P007I3_n301DocDelData[0];
            A302DocDelHora = P007I3_A302DocDelHora[0];
            n302DocDelHora = P007I3_n302DocDelHora[0];
            A304DocDelUsuID = P007I3_A304DocDelUsuID[0];
            n304DocDelUsuID = P007I3_n304DocDelUsuID[0];
            A510DocDelUsuNome = P007I3_A510DocDelUsuNome[0];
            n510DocDelUsuNome = P007I3_n510DocDelUsuNome[0];
            A305DocNome = P007I3_A305DocNome[0];
            A146DocTipoID = P007I3_A146DocTipoID[0];
            A147DocTipoSigla = P007I3_A147DocTipoSigla[0];
            A148DocTipoNome = P007I3_A148DocTipoNome[0];
            A219DocTipoAtivo = P007I3_A219DocTipoAtivo[0];
            A306DocUltArqSeq = P007I3_A306DocUltArqSeq[0];
            n306DocUltArqSeq = P007I3_n306DocUltArqSeq[0];
            A480DocContrato = P007I3_A480DocContrato[0];
            A481DocAssinado = P007I3_A481DocAssinado[0];
            A640DocAtivo = P007I3_A640DocAtivo[0];
            n640DocAtivo = P007I3_n640DocAtivo[0];
            A327DocVersaoNomePai = P007I3_A327DocVersaoNomePai[0];
            A147DocTipoSigla = P007I3_A147DocTipoSigla[0];
            A148DocTipoNome = P007I3_A148DocTipoNome[0];
            A219DocTipoAtivo = P007I3_A219DocTipoAtivo[0];
            if ( StringUtil.StrCmp(AV15ActualMode, "INS") == 0 )
            {
               AV11AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
               AV11AuditingObject.gxTpr_Mode = AV15ActualMode;
               AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
               AV12AuditingObjectRecordItem.gxTpr_Tablename = "tb_documento";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Versão";
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelDataHora";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Data/Hora de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
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
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Usuário ID de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A304DocDelUsuID;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocDelUsuNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Nome do Usuário de Exclusão";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A510DocDelUsuNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocNome";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Descrição do Documento";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = true;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A305DocNome;
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocTipoID";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Tipo";
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
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocContrato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "É um contrato";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A480DocContrato);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocAssinado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Assinado";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A481DocAssinado);
               AV12AuditingObjectRecordItem.gxTpr_Attribute.Add(AV13AuditingObjectRecordItemAttributeItem, 0);
               AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name = "DocAtivo";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Description = "Ativo?";
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Ispartofkey = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Isdescriptionattribute = false;
               AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A640DocAtivo);
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelDataHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelData") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelHora") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " ");
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelUsuID") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A304DocDelUsuID;
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocDelUsuNome") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = A510DocDelUsuNome;
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
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocContrato") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A480DocContrato);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocAssinado") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A481DocAssinado);
                     }
                     else if ( StringUtil.StrCmp(AV13AuditingObjectRecordItemAttributeItem.gxTpr_Name, "DocAtivo") == 0 )
                     {
                        AV13AuditingObjectRecordItemAttributeItem.gxTpr_Newvalue = StringUtil.BoolToStr( A640DocAtivo);
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
         P007I2_A289DocID = new Guid[] {Guid.Empty} ;
         P007I2_A325DocVersao = new short[1] ;
         P007I2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007I2_n326DocVersaoIDPai = new bool[] {false} ;
         P007I2_A327DocVersaoNomePai = new string[] {""} ;
         P007I2_A290DocOrigem = new string[] {""} ;
         P007I2_A291DocOrigemID = new string[] {""} ;
         P007I2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         P007I2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_A295DocInsUsuID = new string[] {""} ;
         P007I2_n295DocInsUsuID = new bool[] {false} ;
         P007I2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         P007I2_n296DocUpdData = new bool[] {false} ;
         P007I2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_n297DocUpdHora = new bool[] {false} ;
         P007I2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_n298DocUpdDataHora = new bool[] {false} ;
         P007I2_A299DocUpdUsuID = new string[] {""} ;
         P007I2_n299DocUpdUsuID = new bool[] {false} ;
         P007I2_A300DocDel = new bool[] {false} ;
         P007I2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_n303DocDelDataHora = new bool[] {false} ;
         P007I2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         P007I2_n301DocDelData = new bool[] {false} ;
         P007I2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         P007I2_n302DocDelHora = new bool[] {false} ;
         P007I2_A304DocDelUsuID = new string[] {""} ;
         P007I2_n304DocDelUsuID = new bool[] {false} ;
         P007I2_A510DocDelUsuNome = new string[] {""} ;
         P007I2_n510DocDelUsuNome = new bool[] {false} ;
         P007I2_A305DocNome = new string[] {""} ;
         P007I2_A146DocTipoID = new int[1] ;
         P007I2_A147DocTipoSigla = new string[] {""} ;
         P007I2_A148DocTipoNome = new string[] {""} ;
         P007I2_A219DocTipoAtivo = new bool[] {false} ;
         P007I2_A306DocUltArqSeq = new short[1] ;
         P007I2_n306DocUltArqSeq = new bool[] {false} ;
         P007I2_A480DocContrato = new bool[] {false} ;
         P007I2_A481DocAssinado = new bool[] {false} ;
         P007I2_A640DocAtivo = new bool[] {false} ;
         P007I2_n640DocAtivo = new bool[] {false} ;
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
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A301DocDelData = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         A304DocDelUsuID = "";
         A510DocDelUsuNome = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         AV12AuditingObjectRecordItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem(context);
         AV13AuditingObjectRecordItemAttributeItem = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem(context);
         P007I3_A289DocID = new Guid[] {Guid.Empty} ;
         P007I3_A325DocVersao = new short[1] ;
         P007I3_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         P007I3_n326DocVersaoIDPai = new bool[] {false} ;
         P007I3_A327DocVersaoNomePai = new string[] {""} ;
         P007I3_A290DocOrigem = new string[] {""} ;
         P007I3_A291DocOrigemID = new string[] {""} ;
         P007I3_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         P007I3_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_A295DocInsUsuID = new string[] {""} ;
         P007I3_n295DocInsUsuID = new bool[] {false} ;
         P007I3_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         P007I3_n296DocUpdData = new bool[] {false} ;
         P007I3_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_n297DocUpdHora = new bool[] {false} ;
         P007I3_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_n298DocUpdDataHora = new bool[] {false} ;
         P007I3_A299DocUpdUsuID = new string[] {""} ;
         P007I3_n299DocUpdUsuID = new bool[] {false} ;
         P007I3_A300DocDel = new bool[] {false} ;
         P007I3_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_n303DocDelDataHora = new bool[] {false} ;
         P007I3_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         P007I3_n301DocDelData = new bool[] {false} ;
         P007I3_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         P007I3_n302DocDelHora = new bool[] {false} ;
         P007I3_A304DocDelUsuID = new string[] {""} ;
         P007I3_n304DocDelUsuID = new bool[] {false} ;
         P007I3_A510DocDelUsuNome = new string[] {""} ;
         P007I3_n510DocDelUsuNome = new bool[] {false} ;
         P007I3_A305DocNome = new string[] {""} ;
         P007I3_A146DocTipoID = new int[1] ;
         P007I3_A147DocTipoSigla = new string[] {""} ;
         P007I3_A148DocTipoNome = new string[] {""} ;
         P007I3_A219DocTipoAtivo = new bool[] {false} ;
         P007I3_A306DocUltArqSeq = new short[1] ;
         P007I3_n306DocUltArqSeq = new bool[] {false} ;
         P007I3_A480DocContrato = new bool[] {false} ;
         P007I3_A481DocAssinado = new bool[] {false} ;
         P007I3_A640DocAtivo = new bool[] {false} ;
         P007I3_n640DocAtivo = new bool[] {false} ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.loadauditdocumento__default(),
            new Object[][] {
                new Object[] {
               P007I2_A289DocID, P007I2_A325DocVersao, P007I2_A326DocVersaoIDPai, P007I2_n326DocVersaoIDPai, P007I2_A327DocVersaoNomePai, P007I2_A290DocOrigem, P007I2_A291DocOrigemID, P007I2_A292DocInsData, P007I2_A293DocInsHora, P007I2_A294DocInsDataHora,
               P007I2_A295DocInsUsuID, P007I2_n295DocInsUsuID, P007I2_A296DocUpdData, P007I2_n296DocUpdData, P007I2_A297DocUpdHora, P007I2_n297DocUpdHora, P007I2_A298DocUpdDataHora, P007I2_n298DocUpdDataHora, P007I2_A299DocUpdUsuID, P007I2_n299DocUpdUsuID,
               P007I2_A300DocDel, P007I2_A303DocDelDataHora, P007I2_n303DocDelDataHora, P007I2_A301DocDelData, P007I2_n301DocDelData, P007I2_A302DocDelHora, P007I2_n302DocDelHora, P007I2_A304DocDelUsuID, P007I2_n304DocDelUsuID, P007I2_A510DocDelUsuNome,
               P007I2_n510DocDelUsuNome, P007I2_A305DocNome, P007I2_A146DocTipoID, P007I2_A147DocTipoSigla, P007I2_A148DocTipoNome, P007I2_A219DocTipoAtivo, P007I2_A306DocUltArqSeq, P007I2_n306DocUltArqSeq, P007I2_A480DocContrato, P007I2_A481DocAssinado,
               P007I2_A640DocAtivo, P007I2_n640DocAtivo
               }
               , new Object[] {
               P007I3_A289DocID, P007I3_A325DocVersao, P007I3_A326DocVersaoIDPai, P007I3_n326DocVersaoIDPai, P007I3_A327DocVersaoNomePai, P007I3_A290DocOrigem, P007I3_A291DocOrigemID, P007I3_A292DocInsData, P007I3_A293DocInsHora, P007I3_A294DocInsDataHora,
               P007I3_A295DocInsUsuID, P007I3_n295DocInsUsuID, P007I3_A296DocUpdData, P007I3_n296DocUpdData, P007I3_A297DocUpdHora, P007I3_n297DocUpdHora, P007I3_A298DocUpdDataHora, P007I3_n298DocUpdDataHora, P007I3_A299DocUpdUsuID, P007I3_n299DocUpdUsuID,
               P007I3_A300DocDel, P007I3_A303DocDelDataHora, P007I3_n303DocDelDataHora, P007I3_A301DocDelData, P007I3_n301DocDelData, P007I3_A302DocDelHora, P007I3_n302DocDelHora, P007I3_A304DocDelUsuID, P007I3_n304DocDelUsuID, P007I3_A510DocDelUsuNome,
               P007I3_n510DocDelUsuNome, P007I3_A305DocNome, P007I3_A146DocTipoID, P007I3_A147DocTipoSigla, P007I3_A148DocTipoNome, P007I3_A219DocTipoAtivo, P007I3_A306DocUltArqSeq, P007I3_n306DocUltArqSeq, P007I3_A480DocContrato, P007I3_A481DocAssinado,
               P007I3_A640DocAtivo, P007I3_n640DocAtivo
               }
            }
         );
         /* GeneXus formulas. */
      }

      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private int A146DocTipoID ;
      private int AV20GXV1 ;
      private int AV21GXV2 ;
      private string AV14SaveOldValues ;
      private string AV15ActualMode ;
      private string scmdbuf ;
      private string A295DocInsUsuID ;
      private string A299DocUpdUsuID ;
      private string A304DocDelUsuID ;
      private DateTime A293DocInsHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime A297DocUpdHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime A301DocDelData ;
      private DateTime A302DocDelHora ;
      private DateTime A292DocInsData ;
      private DateTime A296DocUpdData ;
      private bool returnInSub ;
      private bool n326DocVersaoIDPai ;
      private bool n295DocInsUsuID ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n298DocUpdDataHora ;
      private bool n299DocUpdUsuID ;
      private bool A300DocDel ;
      private bool n303DocDelDataHora ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n304DocDelUsuID ;
      private bool n510DocDelUsuNome ;
      private bool A219DocTipoAtivo ;
      private bool n306DocUltArqSeq ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private string A327DocVersaoNomePai ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string A510DocDelUsuNome ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private Guid AV17DocID ;
      private Guid A289DocID ;
      private Guid A326DocVersaoIDPai ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject aP1_AuditingObject ;
      private IDataStoreProvider pr_default ;
      private Guid[] P007I2_A289DocID ;
      private short[] P007I2_A325DocVersao ;
      private Guid[] P007I2_A326DocVersaoIDPai ;
      private bool[] P007I2_n326DocVersaoIDPai ;
      private string[] P007I2_A327DocVersaoNomePai ;
      private string[] P007I2_A290DocOrigem ;
      private string[] P007I2_A291DocOrigemID ;
      private DateTime[] P007I2_A292DocInsData ;
      private DateTime[] P007I2_A293DocInsHora ;
      private DateTime[] P007I2_A294DocInsDataHora ;
      private string[] P007I2_A295DocInsUsuID ;
      private bool[] P007I2_n295DocInsUsuID ;
      private DateTime[] P007I2_A296DocUpdData ;
      private bool[] P007I2_n296DocUpdData ;
      private DateTime[] P007I2_A297DocUpdHora ;
      private bool[] P007I2_n297DocUpdHora ;
      private DateTime[] P007I2_A298DocUpdDataHora ;
      private bool[] P007I2_n298DocUpdDataHora ;
      private string[] P007I2_A299DocUpdUsuID ;
      private bool[] P007I2_n299DocUpdUsuID ;
      private bool[] P007I2_A300DocDel ;
      private DateTime[] P007I2_A303DocDelDataHora ;
      private bool[] P007I2_n303DocDelDataHora ;
      private DateTime[] P007I2_A301DocDelData ;
      private bool[] P007I2_n301DocDelData ;
      private DateTime[] P007I2_A302DocDelHora ;
      private bool[] P007I2_n302DocDelHora ;
      private string[] P007I2_A304DocDelUsuID ;
      private bool[] P007I2_n304DocDelUsuID ;
      private string[] P007I2_A510DocDelUsuNome ;
      private bool[] P007I2_n510DocDelUsuNome ;
      private string[] P007I2_A305DocNome ;
      private int[] P007I2_A146DocTipoID ;
      private string[] P007I2_A147DocTipoSigla ;
      private string[] P007I2_A148DocTipoNome ;
      private bool[] P007I2_A219DocTipoAtivo ;
      private short[] P007I2_A306DocUltArqSeq ;
      private bool[] P007I2_n306DocUltArqSeq ;
      private bool[] P007I2_A480DocContrato ;
      private bool[] P007I2_A481DocAssinado ;
      private bool[] P007I2_A640DocAtivo ;
      private bool[] P007I2_n640DocAtivo ;
      private Guid[] P007I3_A289DocID ;
      private short[] P007I3_A325DocVersao ;
      private Guid[] P007I3_A326DocVersaoIDPai ;
      private bool[] P007I3_n326DocVersaoIDPai ;
      private string[] P007I3_A327DocVersaoNomePai ;
      private string[] P007I3_A290DocOrigem ;
      private string[] P007I3_A291DocOrigemID ;
      private DateTime[] P007I3_A292DocInsData ;
      private DateTime[] P007I3_A293DocInsHora ;
      private DateTime[] P007I3_A294DocInsDataHora ;
      private string[] P007I3_A295DocInsUsuID ;
      private bool[] P007I3_n295DocInsUsuID ;
      private DateTime[] P007I3_A296DocUpdData ;
      private bool[] P007I3_n296DocUpdData ;
      private DateTime[] P007I3_A297DocUpdHora ;
      private bool[] P007I3_n297DocUpdHora ;
      private DateTime[] P007I3_A298DocUpdDataHora ;
      private bool[] P007I3_n298DocUpdDataHora ;
      private string[] P007I3_A299DocUpdUsuID ;
      private bool[] P007I3_n299DocUpdUsuID ;
      private bool[] P007I3_A300DocDel ;
      private DateTime[] P007I3_A303DocDelDataHora ;
      private bool[] P007I3_n303DocDelDataHora ;
      private DateTime[] P007I3_A301DocDelData ;
      private bool[] P007I3_n301DocDelData ;
      private DateTime[] P007I3_A302DocDelHora ;
      private bool[] P007I3_n302DocDelHora ;
      private string[] P007I3_A304DocDelUsuID ;
      private bool[] P007I3_n304DocDelUsuID ;
      private string[] P007I3_A510DocDelUsuNome ;
      private bool[] P007I3_n510DocDelUsuNome ;
      private string[] P007I3_A305DocNome ;
      private int[] P007I3_A146DocTipoID ;
      private string[] P007I3_A147DocTipoSigla ;
      private string[] P007I3_A148DocTipoNome ;
      private bool[] P007I3_A219DocTipoAtivo ;
      private short[] P007I3_A306DocUltArqSeq ;
      private bool[] P007I3_n306DocUltArqSeq ;
      private bool[] P007I3_A480DocContrato ;
      private bool[] P007I3_A481DocAssinado ;
      private bool[] P007I3_A640DocAtivo ;
      private bool[] P007I3_n640DocAtivo ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV11AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem AV12AuditingObjectRecordItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject_RecordItem_AttributeItem AV13AuditingObjectRecordItemAttributeItem ;
   }

   public class loadauditdocumento__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmP007I2;
          prmP007I2 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP007I3;
          prmP007I3 = new Object[] {
          new ParDef("AV17DocID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007I2", "SELECT T1.DocID, T1.DocVersao, T1.DocVersaoIDPai AS DocVersaoIDPai, T2.DocNome AS DocVersaoNomePai, T1.DocOrigem, T1.DocOrigemID, T1.DocInsData, T1.DocInsHora, T1.DocInsDataHora, T1.DocInsUsuID, T1.DocUpdData, T1.DocUpdHora, T1.DocUpdDataHora, T1.DocUpdUsuID, T1.DocDel, T1.DocDelDataHora, T1.DocDelData, T1.DocDelHora, T1.DocDelUsuID, T1.DocDelUsuNome, T1.DocNome, T1.DocTipoID, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, T1.DocUltArqSeq, T1.DocContrato, T1.DocAssinado, T1.DocAtivo FROM ((tb_documento T1 LEFT JOIN tb_documento T2 ON T2.DocID = T1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = T1.DocTipoID) WHERE T1.DocID = :AV17DocID ORDER BY T1.DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("P007I3", "SELECT T1.DocID, T1.DocVersao, T1.DocVersaoIDPai AS DocVersaoIDPai, T2.DocNome AS DocVersaoNomePai, T1.DocOrigem, T1.DocOrigemID, T1.DocInsData, T1.DocInsHora, T1.DocInsDataHora, T1.DocInsUsuID, T1.DocUpdData, T1.DocUpdHora, T1.DocUpdDataHora, T1.DocUpdUsuID, T1.DocDel, T1.DocDelDataHora, T1.DocDelData, T1.DocDelHora, T1.DocDelUsuID, T1.DocDelUsuNome, T1.DocNome, T1.DocTipoID, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, T1.DocUltArqSeq, T1.DocContrato, T1.DocAssinado, T1.DocAtivo FROM ((tb_documento T1 LEFT JOIN tb_documento T2 ON T2.DocID = T1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = T1.DocTipoID) WHERE T1.DocID = :AV17DocID ORDER BY T1.DocID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007I3,1, GxCacheFrequency.OFF ,false,true )
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
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getVarchar(21);
                ((int[]) buf[32])[0] = rslt.getInt(22);
                ((string[]) buf[33])[0] = rslt.getVarchar(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((bool[]) buf[35])[0] = rslt.getBool(25);
                ((short[]) buf[36])[0] = rslt.getShort(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((bool[]) buf[38])[0] = rslt.getBool(27);
                ((bool[]) buf[39])[0] = rslt.getBool(28);
                ((bool[]) buf[40])[0] = rslt.getBool(29);
                ((bool[]) buf[41])[0] = rslt.wasNull(29);
                return;
             case 1 :
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
                ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16, true);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17);
                ((bool[]) buf[24])[0] = rslt.wasNull(17);
                ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(18);
                ((bool[]) buf[26])[0] = rslt.wasNull(18);
                ((string[]) buf[27])[0] = rslt.getString(19, 40);
                ((bool[]) buf[28])[0] = rslt.wasNull(19);
                ((string[]) buf[29])[0] = rslt.getVarchar(20);
                ((bool[]) buf[30])[0] = rslt.wasNull(20);
                ((string[]) buf[31])[0] = rslt.getVarchar(21);
                ((int[]) buf[32])[0] = rslt.getInt(22);
                ((string[]) buf[33])[0] = rslt.getVarchar(23);
                ((string[]) buf[34])[0] = rslt.getVarchar(24);
                ((bool[]) buf[35])[0] = rslt.getBool(25);
                ((short[]) buf[36])[0] = rslt.getShort(26);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((bool[]) buf[38])[0] = rslt.getBool(27);
                ((bool[]) buf[39])[0] = rslt.getBool(28);
                ((bool[]) buf[40])[0] = rslt.getBool(29);
                ((bool[]) buf[41])[0] = rslt.wasNull(29);
                return;
       }
    }

 }

}
