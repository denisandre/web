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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class documento_bc : GxSilentTrn, IGxSilentTrn
   {
      public documento_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documento_bc( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      protected void INITTRN( )
      {
      }

      public void GetInsDefault( )
      {
         ReadRow0U33( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0U33( ) ;
         standaloneModal( ) ;
         AddRow0U33( ) ;
         Gx_mode = "INS";
         return  ;
      }

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E110U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z289DocID = A289DocID;
               SetMode( "UPD") ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      public bool Reindex( )
      {
         return true ;
      }

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U33( ) ;
            }
            else
            {
               CheckExtendedTable0U33( ) ;
               if ( AnyError == 0 )
               {
                  ZM0U33( 36) ;
                  ZM0U33( 37) ;
               }
               CloseExtendedTableCursors0U33( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV36Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV37GXV1 = 1;
            while ( AV37GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV37GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocVersaoIDPai") == 0 )
               {
                  AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocTipoID") == 0 )
               {
                  AV14Insert_DocTipoID = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV37GXV1 = (int)(AV37GXV1+1);
            }
         }
         if ( ! (Guid.Empty==AV13Insert_DocVersaoIDPai) )
         {
            AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( new GeneXus.Programs.core.prcdocumentoverificaridversaoprincipal(context).executeUdp(  AV13Insert_DocVersaoIDPai.ToString()));
         }
         AV34webSessionParm = "sdtDocumento_" + StringUtil.Trim( AV29DocOrigem) + "_" + StringUtil.Trim( AV30DocOrigemID);
         AV32sdtDocumento.FromJSonString(AV12WebSession.Get(AV34webSessionParm), null);
      }

      protected void E110U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) )
               {
                  AV32sdtDocumento.gxTpr_Docativo = false;
                  new GeneXus.Programs.core.prcdocumentomanterdados(context ).execute(  AV32sdtDocumento,  true, out  AV27Messages) ;
               }
            }
         }
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV31AuditingObject,  AV36Pgmname) ;
      }

      protected void ZM0U33( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            Z305DocNome = A305DocNome;
            Z325DocVersao = A325DocVersao;
            Z294DocInsDataHora = A294DocInsDataHora;
            Z292DocInsData = A292DocInsData;
            Z293DocInsHora = A293DocInsHora;
            Z295DocInsUsuID = A295DocInsUsuID;
            Z298DocUpdDataHora = A298DocUpdDataHora;
            Z296DocUpdData = A296DocUpdData;
            Z297DocUpdHora = A297DocUpdHora;
            Z299DocUpdUsuID = A299DocUpdUsuID;
            Z303DocDelDataHora = A303DocDelDataHora;
            Z301DocDelData = A301DocDelData;
            Z302DocDelHora = A302DocDelHora;
            Z304DocDelUsuID = A304DocDelUsuID;
            Z510DocDelUsuNome = A510DocDelUsuNome;
            Z290DocOrigem = A290DocOrigem;
            Z291DocOrigemID = A291DocOrigemID;
            Z300DocDel = A300DocDel;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z480DocContrato = A480DocContrato;
            Z481DocAssinado = A481DocAssinado;
            Z640DocAtivo = A640DocAtivo;
            Z146DocTipoID = A146DocTipoID;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
         }
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
         }
         if ( ( GX_JID == 37 ) || ( GX_JID == 0 ) )
         {
            Z327DocVersaoNomePai = A327DocVersaoNomePai;
         }
         if ( GX_JID == -34 )
         {
            Z289DocID = A289DocID;
            Z305DocNome = A305DocNome;
            Z325DocVersao = A325DocVersao;
            Z294DocInsDataHora = A294DocInsDataHora;
            Z292DocInsData = A292DocInsData;
            Z293DocInsHora = A293DocInsHora;
            Z295DocInsUsuID = A295DocInsUsuID;
            Z298DocUpdDataHora = A298DocUpdDataHora;
            Z296DocUpdData = A296DocUpdData;
            Z297DocUpdHora = A297DocUpdHora;
            Z299DocUpdUsuID = A299DocUpdUsuID;
            Z303DocDelDataHora = A303DocDelDataHora;
            Z301DocDelData = A301DocDelData;
            Z302DocDelHora = A302DocDelHora;
            Z304DocDelUsuID = A304DocDelUsuID;
            Z510DocDelUsuNome = A510DocDelUsuNome;
            Z290DocOrigem = A290DocOrigem;
            Z291DocOrigemID = A291DocOrigemID;
            Z300DocDel = A300DocDel;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z480DocContrato = A480DocContrato;
            Z481DocAssinado = A481DocAssinado;
            Z640DocAtivo = A640DocAtivo;
            Z146DocTipoID = A146DocTipoID;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
            Z327DocVersaoNomePai = A327DocVersaoNomePai;
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         AV36Pgmname = "core.Documento_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A289DocID) )
         {
            A289DocID = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            A305DocNome = AV32sdtDocumento.gxTpr_Docnome;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            A325DocVersao = (short)(AV32sdtDocumento.gxTpr_Docversao+1);
         }
         if ( IsIns( )  && (false==A481DocAssinado) && ( Gx_BScreen == 0 ) )
         {
            A481DocAssinado = false;
         }
         if ( IsIns( )  && (false==A480DocContrato) && ( Gx_BScreen == 0 ) )
         {
            A480DocContrato = false;
         }
         if ( IsIns( )  && (false==A640DocAtivo) && ( Gx_BScreen == 0 ) )
         {
            A640DocAtivo = true;
            n640DocAtivo = false;
         }
         if ( IsIns( )  && (false==A300DocDel) && ( Gx_BScreen == 0 ) )
         {
            A300DocDel = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0U33( )
      {
         /* Using cursor BC000U6 */
         pr_default.execute(4, new Object[] {A289DocID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound33 = 1;
            A305DocNome = BC000U6_A305DocNome[0];
            A325DocVersao = BC000U6_A325DocVersao[0];
            A294DocInsDataHora = BC000U6_A294DocInsDataHora[0];
            A292DocInsData = BC000U6_A292DocInsData[0];
            A293DocInsHora = BC000U6_A293DocInsHora[0];
            A295DocInsUsuID = BC000U6_A295DocInsUsuID[0];
            n295DocInsUsuID = BC000U6_n295DocInsUsuID[0];
            A298DocUpdDataHora = BC000U6_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC000U6_n298DocUpdDataHora[0];
            A296DocUpdData = BC000U6_A296DocUpdData[0];
            n296DocUpdData = BC000U6_n296DocUpdData[0];
            A297DocUpdHora = BC000U6_A297DocUpdHora[0];
            n297DocUpdHora = BC000U6_n297DocUpdHora[0];
            A299DocUpdUsuID = BC000U6_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC000U6_n299DocUpdUsuID[0];
            A303DocDelDataHora = BC000U6_A303DocDelDataHora[0];
            n303DocDelDataHora = BC000U6_n303DocDelDataHora[0];
            A301DocDelData = BC000U6_A301DocDelData[0];
            n301DocDelData = BC000U6_n301DocDelData[0];
            A302DocDelHora = BC000U6_A302DocDelHora[0];
            n302DocDelHora = BC000U6_n302DocDelHora[0];
            A304DocDelUsuID = BC000U6_A304DocDelUsuID[0];
            n304DocDelUsuID = BC000U6_n304DocDelUsuID[0];
            A510DocDelUsuNome = BC000U6_A510DocDelUsuNome[0];
            n510DocDelUsuNome = BC000U6_n510DocDelUsuNome[0];
            A327DocVersaoNomePai = BC000U6_A327DocVersaoNomePai[0];
            A290DocOrigem = BC000U6_A290DocOrigem[0];
            A291DocOrigemID = BC000U6_A291DocOrigemID[0];
            A300DocDel = BC000U6_A300DocDel[0];
            A147DocTipoSigla = BC000U6_A147DocTipoSigla[0];
            A148DocTipoNome = BC000U6_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000U6_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC000U6_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC000U6_n306DocUltArqSeq[0];
            A480DocContrato = BC000U6_A480DocContrato[0];
            A481DocAssinado = BC000U6_A481DocAssinado[0];
            A640DocAtivo = BC000U6_A640DocAtivo[0];
            n640DocAtivo = BC000U6_n640DocAtivo[0];
            A146DocTipoID = BC000U6_A146DocTipoID[0];
            A326DocVersaoIDPai = BC000U6_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC000U6_n326DocVersaoIDPai[0];
            ZM0U33( -34) ;
         }
         pr_default.close(4);
         OnLoadActions0U33( ) ;
      }

      protected void OnLoadActions0U33( )
      {
      }

      protected void CheckExtendedTable0U33( )
      {
         nIsDirty_33 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000U7 */
         pr_default.execute(5, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai, A325DocVersao, A289DocID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Documento Original"+","+"Versão"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(5);
         /* Using cursor BC000U5 */
         pr_default.execute(3, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A326DocVersaoIDPai) ) )
            {
               GX_msglist.addItem("Não existe 'Documento -> Documento Pai'.", "ForeignKeyNotFound", 1, "DOCVERSAOIDPAI");
               AnyError = 1;
            }
         }
         A327DocVersaoNomePai = BC000U5_A327DocVersaoNomePai[0];
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A305DocNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição do Documento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000U4 */
         pr_default.execute(2, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCTIPOID");
            AnyError = 1;
         }
         A147DocTipoSigla = BC000U4_A147DocTipoSigla[0];
         A148DocTipoNome = BC000U4_A148DocTipoNome[0];
         A219DocTipoAtivo = BC000U4_A219DocTipoAtivo[0];
         pr_default.close(2);
         if ( (0==A146DocTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Documento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0U33( )
      {
         pr_default.close(3);
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0U33( )
      {
         /* Using cursor BC000U8 */
         pr_default.execute(6, new Object[] {A289DocID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000U3 */
         pr_default.execute(1, new Object[] {A289DocID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U33( 34) ;
            RcdFound33 = 1;
            A289DocID = BC000U3_A289DocID[0];
            A305DocNome = BC000U3_A305DocNome[0];
            A325DocVersao = BC000U3_A325DocVersao[0];
            A294DocInsDataHora = BC000U3_A294DocInsDataHora[0];
            A292DocInsData = BC000U3_A292DocInsData[0];
            A293DocInsHora = BC000U3_A293DocInsHora[0];
            A295DocInsUsuID = BC000U3_A295DocInsUsuID[0];
            n295DocInsUsuID = BC000U3_n295DocInsUsuID[0];
            A298DocUpdDataHora = BC000U3_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC000U3_n298DocUpdDataHora[0];
            A296DocUpdData = BC000U3_A296DocUpdData[0];
            n296DocUpdData = BC000U3_n296DocUpdData[0];
            A297DocUpdHora = BC000U3_A297DocUpdHora[0];
            n297DocUpdHora = BC000U3_n297DocUpdHora[0];
            A299DocUpdUsuID = BC000U3_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC000U3_n299DocUpdUsuID[0];
            A303DocDelDataHora = BC000U3_A303DocDelDataHora[0];
            n303DocDelDataHora = BC000U3_n303DocDelDataHora[0];
            A301DocDelData = BC000U3_A301DocDelData[0];
            n301DocDelData = BC000U3_n301DocDelData[0];
            A302DocDelHora = BC000U3_A302DocDelHora[0];
            n302DocDelHora = BC000U3_n302DocDelHora[0];
            A304DocDelUsuID = BC000U3_A304DocDelUsuID[0];
            n304DocDelUsuID = BC000U3_n304DocDelUsuID[0];
            A510DocDelUsuNome = BC000U3_A510DocDelUsuNome[0];
            n510DocDelUsuNome = BC000U3_n510DocDelUsuNome[0];
            A290DocOrigem = BC000U3_A290DocOrigem[0];
            A291DocOrigemID = BC000U3_A291DocOrigemID[0];
            A300DocDel = BC000U3_A300DocDel[0];
            A306DocUltArqSeq = BC000U3_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC000U3_n306DocUltArqSeq[0];
            A480DocContrato = BC000U3_A480DocContrato[0];
            A481DocAssinado = BC000U3_A481DocAssinado[0];
            A640DocAtivo = BC000U3_A640DocAtivo[0];
            n640DocAtivo = BC000U3_n640DocAtivo[0];
            A146DocTipoID = BC000U3_A146DocTipoID[0];
            A326DocVersaoIDPai = BC000U3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC000U3_n326DocVersaoIDPai[0];
            O300DocDel = A300DocDel;
            Z289DocID = A289DocID;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0U33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0U33( ) ;
            }
            Gx_mode = sMode33;
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0U33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode33;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U33( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
         }
         getByPrimaryKey( ) ;
      }

      protected void insert_Check( )
      {
         CONFIRM_0U0( ) ;
         IsConfirmed = 0;
      }

      protected void update_Check( )
      {
         insert_Check( ) ;
      }

      protected void delete_Check( )
      {
         insert_Check( ) ;
      }

      protected void CheckOptimisticConcurrency0U33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000U2 */
            pr_default.execute(0, new Object[] {A289DocID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z305DocNome, BC000U2_A305DocNome[0]) != 0 ) || ( Z325DocVersao != BC000U2_A325DocVersao[0] ) || ( Z294DocInsDataHora != BC000U2_A294DocInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z292DocInsData ) != DateTimeUtil.ResetTime ( BC000U2_A292DocInsData[0] ) ) || ( Z293DocInsHora != BC000U2_A293DocInsHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z295DocInsUsuID, BC000U2_A295DocInsUsuID[0]) != 0 ) || ( Z298DocUpdDataHora != BC000U2_A298DocUpdDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z296DocUpdData ) != DateTimeUtil.ResetTime ( BC000U2_A296DocUpdData[0] ) ) || ( Z297DocUpdHora != BC000U2_A297DocUpdHora[0] ) || ( StringUtil.StrCmp(Z299DocUpdUsuID, BC000U2_A299DocUpdUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z303DocDelDataHora != BC000U2_A303DocDelDataHora[0] ) || ( Z301DocDelData != BC000U2_A301DocDelData[0] ) || ( Z302DocDelHora != BC000U2_A302DocDelHora[0] ) || ( StringUtil.StrCmp(Z304DocDelUsuID, BC000U2_A304DocDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z510DocDelUsuNome, BC000U2_A510DocDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z290DocOrigem, BC000U2_A290DocOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z291DocOrigemID, BC000U2_A291DocOrigemID[0]) != 0 ) || ( Z300DocDel != BC000U2_A300DocDel[0] ) || ( Z306DocUltArqSeq != BC000U2_A306DocUltArqSeq[0] ) || ( Z480DocContrato != BC000U2_A480DocContrato[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z481DocAssinado != BC000U2_A481DocAssinado[0] ) || ( Z640DocAtivo != BC000U2_A640DocAtivo[0] ) || ( Z146DocTipoID != BC000U2_A146DocTipoID[0] ) || ( Z326DocVersaoIDPai != BC000U2_A326DocVersaoIDPai[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U33( )
      {
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U33( 0) ;
            CheckOptimisticConcurrency0U33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U9 */
                     pr_default.execute(7, new Object[] {A289DocID, A305DocNome, A325DocVersao, A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, n298DocUpdDataHora, A298DocUpdDataHora, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n299DocUpdUsuID, A299DocUpdUsuID, n303DocDelDataHora, A303DocDelDataHora, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n304DocDelUsuID, A304DocDelUsuID, n510DocDelUsuNome, A510DocDelUsuNome, A290DocOrigem, A291DocOrigemID, A300DocDel, n306DocUltArqSeq, A306DocUltArqSeq, A480DocContrato, A481DocAssinado, n640DocAtivo, A640DocAtivo, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0U33( ) ;
            }
            EndLevel0U33( ) ;
         }
         CloseExtendedTableCursors0U33( ) ;
      }

      protected void Update0U33( )
      {
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000U10 */
                     pr_default.execute(8, new Object[] {A305DocNome, A325DocVersao, A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, n298DocUpdDataHora, A298DocUpdDataHora, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n299DocUpdUsuID, A299DocUpdUsuID, n303DocDelDataHora, A303DocDelDataHora, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n304DocDelUsuID, A304DocDelUsuID, n510DocDelUsuNome, A510DocDelUsuNome, A290DocOrigem, A291DocOrigemID, A300DocDel, n306DocUltArqSeq, A306DocUltArqSeq, A480DocContrato, A481DocAssinado, n640DocAtivo, A640DocAtivo, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai, A289DocID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U33( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0U33( ) ;
         }
         CloseExtendedTableCursors0U33( ) ;
      }

      protected void DeferredUpdate0U33( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U33( ) ;
            AfterConfirm0U33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000U11 */
                  pr_default.execute(9, new Object[] {A289DocID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0U33( ) ;
         Gx_mode = sMode33;
      }

      protected void OnDeleteControls0U33( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000U12 */
            pr_default.execute(10, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
            A327DocVersaoNomePai = BC000U12_A327DocVersaoNomePai[0];
            pr_default.close(10);
            /* Using cursor BC000U13 */
            pr_default.execute(11, new Object[] {A146DocTipoID});
            A147DocTipoSigla = BC000U13_A147DocTipoSigla[0];
            A148DocTipoNome = BC000U13_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000U13_A219DocTipoAtivo[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000U14 */
            pr_default.execute(12, new Object[] {A289DocID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000U15 */
            pr_default.execute(13, new Object[] {A289DocID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0U33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart0U33( )
      {
         /* Scan By routine */
         /* Using cursor BC000U16 */
         pr_default.execute(14, new Object[] {A289DocID});
         RcdFound33 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = BC000U16_A289DocID[0];
            A305DocNome = BC000U16_A305DocNome[0];
            A325DocVersao = BC000U16_A325DocVersao[0];
            A294DocInsDataHora = BC000U16_A294DocInsDataHora[0];
            A292DocInsData = BC000U16_A292DocInsData[0];
            A293DocInsHora = BC000U16_A293DocInsHora[0];
            A295DocInsUsuID = BC000U16_A295DocInsUsuID[0];
            n295DocInsUsuID = BC000U16_n295DocInsUsuID[0];
            A298DocUpdDataHora = BC000U16_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC000U16_n298DocUpdDataHora[0];
            A296DocUpdData = BC000U16_A296DocUpdData[0];
            n296DocUpdData = BC000U16_n296DocUpdData[0];
            A297DocUpdHora = BC000U16_A297DocUpdHora[0];
            n297DocUpdHora = BC000U16_n297DocUpdHora[0];
            A299DocUpdUsuID = BC000U16_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC000U16_n299DocUpdUsuID[0];
            A303DocDelDataHora = BC000U16_A303DocDelDataHora[0];
            n303DocDelDataHora = BC000U16_n303DocDelDataHora[0];
            A301DocDelData = BC000U16_A301DocDelData[0];
            n301DocDelData = BC000U16_n301DocDelData[0];
            A302DocDelHora = BC000U16_A302DocDelHora[0];
            n302DocDelHora = BC000U16_n302DocDelHora[0];
            A304DocDelUsuID = BC000U16_A304DocDelUsuID[0];
            n304DocDelUsuID = BC000U16_n304DocDelUsuID[0];
            A510DocDelUsuNome = BC000U16_A510DocDelUsuNome[0];
            n510DocDelUsuNome = BC000U16_n510DocDelUsuNome[0];
            A327DocVersaoNomePai = BC000U16_A327DocVersaoNomePai[0];
            A290DocOrigem = BC000U16_A290DocOrigem[0];
            A291DocOrigemID = BC000U16_A291DocOrigemID[0];
            A300DocDel = BC000U16_A300DocDel[0];
            A147DocTipoSigla = BC000U16_A147DocTipoSigla[0];
            A148DocTipoNome = BC000U16_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000U16_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC000U16_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC000U16_n306DocUltArqSeq[0];
            A480DocContrato = BC000U16_A480DocContrato[0];
            A481DocAssinado = BC000U16_A481DocAssinado[0];
            A640DocAtivo = BC000U16_A640DocAtivo[0];
            n640DocAtivo = BC000U16_n640DocAtivo[0];
            A146DocTipoID = BC000U16_A146DocTipoID[0];
            A326DocVersaoIDPai = BC000U16_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC000U16_n326DocVersaoIDPai[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0U33( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound33 = 0;
         ScanKeyLoad0U33( ) ;
      }

      protected void ScanKeyLoad0U33( )
      {
         sMode33 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = BC000U16_A289DocID[0];
            A305DocNome = BC000U16_A305DocNome[0];
            A325DocVersao = BC000U16_A325DocVersao[0];
            A294DocInsDataHora = BC000U16_A294DocInsDataHora[0];
            A292DocInsData = BC000U16_A292DocInsData[0];
            A293DocInsHora = BC000U16_A293DocInsHora[0];
            A295DocInsUsuID = BC000U16_A295DocInsUsuID[0];
            n295DocInsUsuID = BC000U16_n295DocInsUsuID[0];
            A298DocUpdDataHora = BC000U16_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC000U16_n298DocUpdDataHora[0];
            A296DocUpdData = BC000U16_A296DocUpdData[0];
            n296DocUpdData = BC000U16_n296DocUpdData[0];
            A297DocUpdHora = BC000U16_A297DocUpdHora[0];
            n297DocUpdHora = BC000U16_n297DocUpdHora[0];
            A299DocUpdUsuID = BC000U16_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC000U16_n299DocUpdUsuID[0];
            A303DocDelDataHora = BC000U16_A303DocDelDataHora[0];
            n303DocDelDataHora = BC000U16_n303DocDelDataHora[0];
            A301DocDelData = BC000U16_A301DocDelData[0];
            n301DocDelData = BC000U16_n301DocDelData[0];
            A302DocDelHora = BC000U16_A302DocDelHora[0];
            n302DocDelHora = BC000U16_n302DocDelHora[0];
            A304DocDelUsuID = BC000U16_A304DocDelUsuID[0];
            n304DocDelUsuID = BC000U16_n304DocDelUsuID[0];
            A510DocDelUsuNome = BC000U16_A510DocDelUsuNome[0];
            n510DocDelUsuNome = BC000U16_n510DocDelUsuNome[0];
            A327DocVersaoNomePai = BC000U16_A327DocVersaoNomePai[0];
            A290DocOrigem = BC000U16_A290DocOrigem[0];
            A291DocOrigemID = BC000U16_A291DocOrigemID[0];
            A300DocDel = BC000U16_A300DocDel[0];
            A147DocTipoSigla = BC000U16_A147DocTipoSigla[0];
            A148DocTipoNome = BC000U16_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000U16_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC000U16_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC000U16_n306DocUltArqSeq[0];
            A480DocContrato = BC000U16_A480DocContrato[0];
            A481DocAssinado = BC000U16_A481DocAssinado[0];
            A640DocAtivo = BC000U16_A640DocAtivo[0];
            n640DocAtivo = BC000U16_n640DocAtivo[0];
            A146DocTipoID = BC000U16_A146DocTipoID[0];
            A326DocVersaoIDPai = BC000U16_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC000U16_n326DocVersaoIDPai[0];
         }
         Gx_mode = sMode33;
      }

      protected void ScanKeyEnd0U33( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0U33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U33( )
      {
         /* Before Insert Rules */
         A294DocInsDataHora = DateTimeUtil.NowMS( context);
         A295DocInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n295DocInsUsuID = false;
         A292DocInsData = DateTimeUtil.ResetTime( A294DocInsDataHora);
         A293DocInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A294DocInsDataHora));
         if ( (Guid.Empty==A326DocVersaoIDPai) || BC000U3_n326DocVersaoIDPai[0] )
         {
            A325DocVersao = 1;
         }
         if ( A325DocVersao == 1 )
         {
            A326DocVersaoIDPai = Guid.Empty;
            n326DocVersaoIDPai = false;
            n326DocVersaoIDPai = true;
         }
      }

      protected void BeforeUpdate0U33( )
      {
         /* Before Update Rules */
         A298DocUpdDataHora = DateTimeUtil.NowMS( context);
         n298DocUpdDataHora = false;
         A299DocUpdUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n299DocUpdUsuID = false;
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         if ( A325DocVersao == 1 )
         {
            A326DocVersaoIDPai = Guid.Empty;
            n326DocVersaoIDPai = false;
            n326DocVersaoIDPai = true;
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A303DocDelDataHora = DateTimeUtil.NowMS( context);
            n303DocDelDataHora = false;
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A304DocDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n304DocDelUsuID = false;
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A510DocDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n510DocDelUsuNome = false;
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A301DocDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A303DocDelDataHora) ) ;
            n301DocDelData = false;
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A302DocDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A303DocDelDataHora));
            n302DocDelHora = false;
         }
         A296DocUpdData = DateTimeUtil.ResetTime( A298DocUpdDataHora);
         n296DocUpdData = false;
         A297DocUpdHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A298DocUpdDataHora));
         n297DocUpdHora = false;
      }

      protected void BeforeDelete0U33( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
      }

      protected void BeforeComplete0U33( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0U33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U33( )
      {
      }

      protected void send_integrity_lvl_hashes0U33( )
      {
      }

      protected void AddRow0U33( )
      {
         VarsToRow33( bccore_Documento) ;
      }

      protected void ReadRow0U33( )
      {
         RowToVars33( bccore_Documento, 1) ;
      }

      protected void InitializeNonKey0U33( )
      {
         AV31AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A305DocNome = "";
         A325DocVersao = 0;
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A292DocInsData = DateTime.MinValue;
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A295DocInsUsuID = "";
         n295DocInsUsuID = false;
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         n298DocUpdDataHora = false;
         A296DocUpdData = DateTime.MinValue;
         n296DocUpdData = false;
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         n297DocUpdHora = false;
         A299DocUpdUsuID = "";
         n299DocUpdUsuID = false;
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         n303DocDelDataHora = false;
         A301DocDelData = (DateTime)(DateTime.MinValue);
         n301DocDelData = false;
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         n302DocDelHora = false;
         A304DocDelUsuID = "";
         n304DocDelUsuID = false;
         A510DocDelUsuNome = "";
         n510DocDelUsuNome = false;
         A326DocVersaoIDPai = Guid.Empty;
         n326DocVersaoIDPai = false;
         A327DocVersaoNomePai = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A146DocTipoID = 0;
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         A219DocTipoAtivo = false;
         A306DocUltArqSeq = 0;
         n306DocUltArqSeq = false;
         A300DocDel = false;
         A480DocContrato = false;
         A481DocAssinado = false;
         A640DocAtivo = true;
         n640DocAtivo = false;
         O300DocDel = A300DocDel;
         Z305DocNome = "";
         Z325DocVersao = 0;
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         Z510DocDelUsuNome = "";
         Z290DocOrigem = "";
         Z291DocOrigemID = "";
         Z300DocDel = false;
         Z306DocUltArqSeq = 0;
         Z480DocContrato = false;
         Z481DocAssinado = false;
         Z640DocAtivo = false;
         Z146DocTipoID = 0;
         Z326DocVersaoIDPai = Guid.Empty;
      }

      protected void InitAll0U33( )
      {
         A289DocID = Guid.NewGuid( );
         InitializeNonKey0U33( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A481DocAssinado = i481DocAssinado;
         A480DocContrato = i480DocContrato;
         A640DocAtivo = i640DocAtivo;
         n640DocAtivo = false;
         A300DocDel = i300DocDel;
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public void VarsToRow33( GeneXus.Programs.core.SdtDocumento obj33 )
      {
         obj33.gxTpr_Mode = Gx_mode;
         obj33.gxTpr_Docnome = A305DocNome;
         obj33.gxTpr_Docversao = A325DocVersao;
         obj33.gxTpr_Docinsdatahora = A294DocInsDataHora;
         obj33.gxTpr_Docinsdata = A292DocInsData;
         obj33.gxTpr_Docinshora = A293DocInsHora;
         obj33.gxTpr_Docinsusuid = A295DocInsUsuID;
         obj33.gxTpr_Docupddatahora = A298DocUpdDataHora;
         obj33.gxTpr_Docupddata = A296DocUpdData;
         obj33.gxTpr_Docupdhora = A297DocUpdHora;
         obj33.gxTpr_Docupdusuid = A299DocUpdUsuID;
         obj33.gxTpr_Docdeldatahora = A303DocDelDataHora;
         obj33.gxTpr_Docdeldata = A301DocDelData;
         obj33.gxTpr_Docdelhora = A302DocDelHora;
         obj33.gxTpr_Docdelusuid = A304DocDelUsuID;
         obj33.gxTpr_Docdelusunome = A510DocDelUsuNome;
         obj33.gxTpr_Docversaoidpai = A326DocVersaoIDPai;
         obj33.gxTpr_Docversaonomepai = A327DocVersaoNomePai;
         obj33.gxTpr_Docorigem = A290DocOrigem;
         obj33.gxTpr_Docorigemid = A291DocOrigemID;
         obj33.gxTpr_Doctipoid = A146DocTipoID;
         obj33.gxTpr_Doctiposigla = A147DocTipoSigla;
         obj33.gxTpr_Doctiponome = A148DocTipoNome;
         obj33.gxTpr_Doctipoativo = A219DocTipoAtivo;
         obj33.gxTpr_Docultarqseq = A306DocUltArqSeq;
         obj33.gxTpr_Docdel = A300DocDel;
         obj33.gxTpr_Doccontrato = A480DocContrato;
         obj33.gxTpr_Docassinado = A481DocAssinado;
         obj33.gxTpr_Docativo = A640DocAtivo;
         obj33.gxTpr_Docid = A289DocID;
         obj33.gxTpr_Docid_Z = Z289DocID;
         obj33.gxTpr_Docversao_Z = Z325DocVersao;
         obj33.gxTpr_Docversaoidpai_Z = Z326DocVersaoIDPai;
         obj33.gxTpr_Docversaonomepai_Z = Z327DocVersaoNomePai;
         obj33.gxTpr_Docorigem_Z = Z290DocOrigem;
         obj33.gxTpr_Docorigemid_Z = Z291DocOrigemID;
         obj33.gxTpr_Docinsdata_Z = Z292DocInsData;
         obj33.gxTpr_Docinshora_Z = Z293DocInsHora;
         obj33.gxTpr_Docinsdatahora_Z = Z294DocInsDataHora;
         obj33.gxTpr_Docinsusuid_Z = Z295DocInsUsuID;
         obj33.gxTpr_Docupddata_Z = Z296DocUpdData;
         obj33.gxTpr_Docupdhora_Z = Z297DocUpdHora;
         obj33.gxTpr_Docupddatahora_Z = Z298DocUpdDataHora;
         obj33.gxTpr_Docupdusuid_Z = Z299DocUpdUsuID;
         obj33.gxTpr_Docdel_Z = Z300DocDel;
         obj33.gxTpr_Docdeldatahora_Z = Z303DocDelDataHora;
         obj33.gxTpr_Docdeldata_Z = Z301DocDelData;
         obj33.gxTpr_Docdelhora_Z = Z302DocDelHora;
         obj33.gxTpr_Docdelusuid_Z = Z304DocDelUsuID;
         obj33.gxTpr_Docdelusunome_Z = Z510DocDelUsuNome;
         obj33.gxTpr_Docnome_Z = Z305DocNome;
         obj33.gxTpr_Doctipoid_Z = Z146DocTipoID;
         obj33.gxTpr_Doctiposigla_Z = Z147DocTipoSigla;
         obj33.gxTpr_Doctiponome_Z = Z148DocTipoNome;
         obj33.gxTpr_Doctipoativo_Z = Z219DocTipoAtivo;
         obj33.gxTpr_Docultarqseq_Z = Z306DocUltArqSeq;
         obj33.gxTpr_Doccontrato_Z = Z480DocContrato;
         obj33.gxTpr_Docassinado_Z = Z481DocAssinado;
         obj33.gxTpr_Docativo_Z = Z640DocAtivo;
         obj33.gxTpr_Docversaoidpai_N = (short)(Convert.ToInt16(n326DocVersaoIDPai));
         obj33.gxTpr_Docinsusuid_N = (short)(Convert.ToInt16(n295DocInsUsuID));
         obj33.gxTpr_Docupddata_N = (short)(Convert.ToInt16(n296DocUpdData));
         obj33.gxTpr_Docupdhora_N = (short)(Convert.ToInt16(n297DocUpdHora));
         obj33.gxTpr_Docupddatahora_N = (short)(Convert.ToInt16(n298DocUpdDataHora));
         obj33.gxTpr_Docupdusuid_N = (short)(Convert.ToInt16(n299DocUpdUsuID));
         obj33.gxTpr_Docdeldatahora_N = (short)(Convert.ToInt16(n303DocDelDataHora));
         obj33.gxTpr_Docdeldata_N = (short)(Convert.ToInt16(n301DocDelData));
         obj33.gxTpr_Docdelhora_N = (short)(Convert.ToInt16(n302DocDelHora));
         obj33.gxTpr_Docdelusuid_N = (short)(Convert.ToInt16(n304DocDelUsuID));
         obj33.gxTpr_Docdelusunome_N = (short)(Convert.ToInt16(n510DocDelUsuNome));
         obj33.gxTpr_Docultarqseq_N = (short)(Convert.ToInt16(n306DocUltArqSeq));
         obj33.gxTpr_Docativo_N = (short)(Convert.ToInt16(n640DocAtivo));
         obj33.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow33( GeneXus.Programs.core.SdtDocumento obj33 )
      {
         obj33.gxTpr_Docid = A289DocID;
         return  ;
      }

      public void RowToVars33( GeneXus.Programs.core.SdtDocumento obj33 ,
                               int forceLoad )
      {
         Gx_mode = obj33.gxTpr_Mode;
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) ) || ( forceLoad == 1 ) )
         {
            A305DocNome = obj33.gxTpr_Docnome;
         }
         A325DocVersao = obj33.gxTpr_Docversao;
         A294DocInsDataHora = obj33.gxTpr_Docinsdatahora;
         A292DocInsData = obj33.gxTpr_Docinsdata;
         A293DocInsHora = obj33.gxTpr_Docinshora;
         A295DocInsUsuID = obj33.gxTpr_Docinsusuid;
         n295DocInsUsuID = false;
         A298DocUpdDataHora = obj33.gxTpr_Docupddatahora;
         n298DocUpdDataHora = false;
         A296DocUpdData = obj33.gxTpr_Docupddata;
         n296DocUpdData = false;
         A297DocUpdHora = obj33.gxTpr_Docupdhora;
         n297DocUpdHora = false;
         A299DocUpdUsuID = obj33.gxTpr_Docupdusuid;
         n299DocUpdUsuID = false;
         A303DocDelDataHora = obj33.gxTpr_Docdeldatahora;
         n303DocDelDataHora = false;
         A301DocDelData = obj33.gxTpr_Docdeldata;
         n301DocDelData = false;
         A302DocDelHora = obj33.gxTpr_Docdelhora;
         n302DocDelHora = false;
         A304DocDelUsuID = obj33.gxTpr_Docdelusuid;
         n304DocDelUsuID = false;
         A510DocDelUsuNome = obj33.gxTpr_Docdelusunome;
         n510DocDelUsuNome = false;
         A326DocVersaoIDPai = obj33.gxTpr_Docversaoidpai;
         n326DocVersaoIDPai = false;
         A327DocVersaoNomePai = obj33.gxTpr_Docversaonomepai;
         A290DocOrigem = obj33.gxTpr_Docorigem;
         A291DocOrigemID = obj33.gxTpr_Docorigemid;
         A146DocTipoID = obj33.gxTpr_Doctipoid;
         A147DocTipoSigla = obj33.gxTpr_Doctiposigla;
         A148DocTipoNome = obj33.gxTpr_Doctiponome;
         A219DocTipoAtivo = obj33.gxTpr_Doctipoativo;
         A306DocUltArqSeq = obj33.gxTpr_Docultarqseq;
         n306DocUltArqSeq = false;
         A300DocDel = obj33.gxTpr_Docdel;
         A480DocContrato = obj33.gxTpr_Doccontrato;
         A481DocAssinado = obj33.gxTpr_Docassinado;
         A640DocAtivo = obj33.gxTpr_Docativo;
         n640DocAtivo = false;
         A289DocID = obj33.gxTpr_Docid;
         Z289DocID = obj33.gxTpr_Docid_Z;
         Z325DocVersao = obj33.gxTpr_Docversao_Z;
         Z326DocVersaoIDPai = obj33.gxTpr_Docversaoidpai_Z;
         Z327DocVersaoNomePai = obj33.gxTpr_Docversaonomepai_Z;
         Z290DocOrigem = obj33.gxTpr_Docorigem_Z;
         Z291DocOrigemID = obj33.gxTpr_Docorigemid_Z;
         Z292DocInsData = obj33.gxTpr_Docinsdata_Z;
         Z293DocInsHora = obj33.gxTpr_Docinshora_Z;
         Z294DocInsDataHora = obj33.gxTpr_Docinsdatahora_Z;
         Z295DocInsUsuID = obj33.gxTpr_Docinsusuid_Z;
         Z296DocUpdData = obj33.gxTpr_Docupddata_Z;
         Z297DocUpdHora = obj33.gxTpr_Docupdhora_Z;
         Z298DocUpdDataHora = obj33.gxTpr_Docupddatahora_Z;
         Z299DocUpdUsuID = obj33.gxTpr_Docupdusuid_Z;
         Z300DocDel = obj33.gxTpr_Docdel_Z;
         O300DocDel = obj33.gxTpr_Docdel_Z;
         Z303DocDelDataHora = obj33.gxTpr_Docdeldatahora_Z;
         Z301DocDelData = obj33.gxTpr_Docdeldata_Z;
         Z302DocDelHora = obj33.gxTpr_Docdelhora_Z;
         Z304DocDelUsuID = obj33.gxTpr_Docdelusuid_Z;
         Z510DocDelUsuNome = obj33.gxTpr_Docdelusunome_Z;
         Z305DocNome = obj33.gxTpr_Docnome_Z;
         Z146DocTipoID = obj33.gxTpr_Doctipoid_Z;
         Z147DocTipoSigla = obj33.gxTpr_Doctiposigla_Z;
         Z148DocTipoNome = obj33.gxTpr_Doctiponome_Z;
         Z219DocTipoAtivo = obj33.gxTpr_Doctipoativo_Z;
         Z306DocUltArqSeq = obj33.gxTpr_Docultarqseq_Z;
         Z480DocContrato = obj33.gxTpr_Doccontrato_Z;
         Z481DocAssinado = obj33.gxTpr_Docassinado_Z;
         Z640DocAtivo = obj33.gxTpr_Docativo_Z;
         n326DocVersaoIDPai = (bool)(Convert.ToBoolean(obj33.gxTpr_Docversaoidpai_N));
         n295DocInsUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docinsusuid_N));
         n296DocUpdData = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupddata_N));
         n297DocUpdHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupdhora_N));
         n298DocUpdDataHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupddatahora_N));
         n299DocUpdUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupdusuid_N));
         n303DocDelDataHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdeldatahora_N));
         n301DocDelData = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdeldata_N));
         n302DocDelHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdelhora_N));
         n304DocDelUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdelusuid_N));
         n510DocDelUsuNome = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdelusunome_N));
         n306DocUltArqSeq = (bool)(Convert.ToBoolean(obj33.gxTpr_Docultarqseq_N));
         n640DocAtivo = (bool)(Convert.ToBoolean(obj33.gxTpr_Docativo_N));
         Gx_mode = obj33.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A289DocID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0U33( ) ;
         ScanKeyStart0U33( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            O300DocDel = A300DocDel;
         }
         ZM0U33( -34) ;
         OnLoadActions0U33( ) ;
         AddRow0U33( ) ;
         ScanKeyEnd0U33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      public void Load( )
      {
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         RowToVars33( bccore_Documento, 0) ;
         ScanKeyStart0U33( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            O300DocDel = A300DocDel;
         }
         ZM0U33( -34) ;
         OnLoadActions0U33( ) ;
         AddRow0U33( ) ;
         ScanKeyEnd0U33( ) ;
         if ( RcdFound33 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0U33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0U33( ) ;
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( A289DocID != Z289DocID )
               {
                  A289DocID = Z289DocID;
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  Update0U33( ) ;
               }
            }
            else
            {
               if ( IsDlt( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else
               {
                  if ( A289DocID != Z289DocID )
                  {
                     if ( IsUpd( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0U33( ) ;
                     }
                  }
                  else
                  {
                     if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                     else
                     {
                        Gx_mode = "INS";
                        /* Insert record */
                        Insert0U33( ) ;
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
      }

      public void Save( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars33( bccore_Documento, 1) ;
         SaveImpl( ) ;
         VarsToRow33( bccore_Documento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public bool Insert( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars33( bccore_Documento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U33( ) ;
         AfterTrn( ) ;
         VarsToRow33( bccore_Documento) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow33( bccore_Documento) ;
         }
         else
         {
            GeneXus.Programs.core.SdtDocumento auxBC = new GeneXus.Programs.core.SdtDocumento(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A289DocID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Documento);
               auxBC.Save();
               bccore_Documento.Copy((GxSilentTrnSdt)(auxBC));
            }
            LclMsgLst = (msglist)(auxTrn.GetMessages());
            AnyError = (short)(auxTrn.Errors());
            context.GX_msglist = LclMsgLst;
            if ( auxTrn.Errors() == 0 )
            {
               Gx_mode = auxTrn.GetMode();
               AfterTrn( ) ;
            }
         }
      }

      public bool Update( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars33( bccore_Documento, 1) ;
         UpdateImpl( ) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public bool InsertOrUpdate( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         IsConfirmed = 1;
         RowToVars33( bccore_Documento, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0U33( ) ;
         if ( AnyError == 1 )
         {
            if ( StringUtil.StrCmp(context.GX_msglist.getItemValue(1), "DuplicatePrimaryKey") == 0 )
            {
               AnyError = 0;
               context.GX_msglist.removeAllItems();
               UpdateImpl( ) ;
            }
            else
            {
               VarsToRow33( bccore_Documento) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow33( bccore_Documento) ;
         }
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      public void Check( )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         RowToVars33( bccore_Documento, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0U33( ) ;
         if ( RcdFound33 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A289DocID != Z289DocID )
            {
               A289DocID = Z289DocID;
               GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( IsDlt( ) )
            {
               delete_Check( ) ;
            }
            else
            {
               Gx_mode = "UPD";
               update_Check( ) ;
            }
         }
         else
         {
            if ( A289DocID != Z289DocID )
            {
               Gx_mode = "INS";
               insert_Check( ) ;
            }
            else
            {
               if ( IsUpd( ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                  AnyError = 1;
               }
               else
               {
                  Gx_mode = "INS";
                  insert_Check( ) ;
               }
            }
         }
         context.RollbackDataStores("core.documento_bc",pr_default);
         VarsToRow33( bccore_Documento) ;
         context.GX_msglist = BackMsgLst;
         return  ;
      }

      public int Errors( )
      {
         if ( AnyError == 0 )
         {
            return (int)(0) ;
         }
         return (int)(1) ;
      }

      public msglist GetMessages( )
      {
         return LclMsgLst ;
      }

      public string GetMode( )
      {
         Gx_mode = bccore_Documento.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Documento.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Documento )
         {
            bccore_Documento = (GeneXus.Programs.core.SdtDocumento)(sdt);
            if ( StringUtil.StrCmp(bccore_Documento.gxTpr_Mode, "") == 0 )
            {
               bccore_Documento.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow33( bccore_Documento) ;
            }
            else
            {
               RowToVars33( bccore_Documento, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Documento.gxTpr_Mode, "") == 0 )
            {
               bccore_Documento.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars33( bccore_Documento, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocumento Documento_BC
      {
         get {
            return bccore_Documento ;
         }

      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "documento_Execute" ;
         }

      }

      public void webExecute( )
      {
         createObjects();
         initialize();
      }

      public bool isMasterPage( )
      {
         return false;
      }

      protected void createObjects( )
      {
      }

      protected void Process( )
      {
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
         pr_default.close(1);
         pr_default.close(11);
         pr_default.close(10);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z289DocID = Guid.Empty;
         A289DocID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV36Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_DocVersaoIDPai = Guid.Empty;
         AV34webSessionParm = "";
         AV29DocOrigem = "";
         AV30DocOrigemID = "";
         AV32sdtDocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV31AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z305DocNome = "";
         A305DocNome = "";
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         A292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         A295DocInsUsuID = "";
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z296DocUpdData = DateTime.MinValue;
         A296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         A299DocUpdUsuID = "";
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         A301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         A304DocDelUsuID = "";
         Z510DocDelUsuNome = "";
         A510DocDelUsuNome = "";
         Z290DocOrigem = "";
         A290DocOrigem = "";
         Z291DocOrigemID = "";
         A291DocOrigemID = "";
         Z326DocVersaoIDPai = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         Z147DocTipoSigla = "";
         A147DocTipoSigla = "";
         Z148DocTipoNome = "";
         A148DocTipoNome = "";
         Z327DocVersaoNomePai = "";
         A327DocVersaoNomePai = "";
         BC000U6_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U6_A305DocNome = new string[] {""} ;
         BC000U6_A325DocVersao = new short[1] ;
         BC000U6_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC000U6_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_A295DocInsUsuID = new string[] {""} ;
         BC000U6_n295DocInsUsuID = new bool[] {false} ;
         BC000U6_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n298DocUpdDataHora = new bool[] {false} ;
         BC000U6_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n296DocUpdData = new bool[] {false} ;
         BC000U6_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n297DocUpdHora = new bool[] {false} ;
         BC000U6_A299DocUpdUsuID = new string[] {""} ;
         BC000U6_n299DocUpdUsuID = new bool[] {false} ;
         BC000U6_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n303DocDelDataHora = new bool[] {false} ;
         BC000U6_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n301DocDelData = new bool[] {false} ;
         BC000U6_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000U6_n302DocDelHora = new bool[] {false} ;
         BC000U6_A304DocDelUsuID = new string[] {""} ;
         BC000U6_n304DocDelUsuID = new bool[] {false} ;
         BC000U6_A510DocDelUsuNome = new string[] {""} ;
         BC000U6_n510DocDelUsuNome = new bool[] {false} ;
         BC000U6_A327DocVersaoNomePai = new string[] {""} ;
         BC000U6_A290DocOrigem = new string[] {""} ;
         BC000U6_A291DocOrigemID = new string[] {""} ;
         BC000U6_A300DocDel = new bool[] {false} ;
         BC000U6_A147DocTipoSigla = new string[] {""} ;
         BC000U6_A148DocTipoNome = new string[] {""} ;
         BC000U6_A219DocTipoAtivo = new bool[] {false} ;
         BC000U6_A306DocUltArqSeq = new short[1] ;
         BC000U6_n306DocUltArqSeq = new bool[] {false} ;
         BC000U6_A480DocContrato = new bool[] {false} ;
         BC000U6_A481DocAssinado = new bool[] {false} ;
         BC000U6_A640DocAtivo = new bool[] {false} ;
         BC000U6_n640DocAtivo = new bool[] {false} ;
         BC000U6_A146DocTipoID = new int[1] ;
         BC000U6_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U6_n326DocVersaoIDPai = new bool[] {false} ;
         BC000U7_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U7_n326DocVersaoIDPai = new bool[] {false} ;
         BC000U5_A327DocVersaoNomePai = new string[] {""} ;
         BC000U4_A147DocTipoSigla = new string[] {""} ;
         BC000U4_A148DocTipoNome = new string[] {""} ;
         BC000U4_A219DocTipoAtivo = new bool[] {false} ;
         BC000U8_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U3_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U3_A305DocNome = new string[] {""} ;
         BC000U3_A325DocVersao = new short[1] ;
         BC000U3_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC000U3_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_A295DocInsUsuID = new string[] {""} ;
         BC000U3_n295DocInsUsuID = new bool[] {false} ;
         BC000U3_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n298DocUpdDataHora = new bool[] {false} ;
         BC000U3_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n296DocUpdData = new bool[] {false} ;
         BC000U3_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n297DocUpdHora = new bool[] {false} ;
         BC000U3_A299DocUpdUsuID = new string[] {""} ;
         BC000U3_n299DocUpdUsuID = new bool[] {false} ;
         BC000U3_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n303DocDelDataHora = new bool[] {false} ;
         BC000U3_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n301DocDelData = new bool[] {false} ;
         BC000U3_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000U3_n302DocDelHora = new bool[] {false} ;
         BC000U3_A304DocDelUsuID = new string[] {""} ;
         BC000U3_n304DocDelUsuID = new bool[] {false} ;
         BC000U3_A510DocDelUsuNome = new string[] {""} ;
         BC000U3_n510DocDelUsuNome = new bool[] {false} ;
         BC000U3_A290DocOrigem = new string[] {""} ;
         BC000U3_A291DocOrigemID = new string[] {""} ;
         BC000U3_A300DocDel = new bool[] {false} ;
         BC000U3_A306DocUltArqSeq = new short[1] ;
         BC000U3_n306DocUltArqSeq = new bool[] {false} ;
         BC000U3_A480DocContrato = new bool[] {false} ;
         BC000U3_A481DocAssinado = new bool[] {false} ;
         BC000U3_A640DocAtivo = new bool[] {false} ;
         BC000U3_n640DocAtivo = new bool[] {false} ;
         BC000U3_A146DocTipoID = new int[1] ;
         BC000U3_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U3_n326DocVersaoIDPai = new bool[] {false} ;
         sMode33 = "";
         BC000U2_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U2_A305DocNome = new string[] {""} ;
         BC000U2_A325DocVersao = new short[1] ;
         BC000U2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC000U2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_A295DocInsUsuID = new string[] {""} ;
         BC000U2_n295DocInsUsuID = new bool[] {false} ;
         BC000U2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n298DocUpdDataHora = new bool[] {false} ;
         BC000U2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n296DocUpdData = new bool[] {false} ;
         BC000U2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n297DocUpdHora = new bool[] {false} ;
         BC000U2_A299DocUpdUsuID = new string[] {""} ;
         BC000U2_n299DocUpdUsuID = new bool[] {false} ;
         BC000U2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n303DocDelDataHora = new bool[] {false} ;
         BC000U2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n301DocDelData = new bool[] {false} ;
         BC000U2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000U2_n302DocDelHora = new bool[] {false} ;
         BC000U2_A304DocDelUsuID = new string[] {""} ;
         BC000U2_n304DocDelUsuID = new bool[] {false} ;
         BC000U2_A510DocDelUsuNome = new string[] {""} ;
         BC000U2_n510DocDelUsuNome = new bool[] {false} ;
         BC000U2_A290DocOrigem = new string[] {""} ;
         BC000U2_A291DocOrigemID = new string[] {""} ;
         BC000U2_A300DocDel = new bool[] {false} ;
         BC000U2_A306DocUltArqSeq = new short[1] ;
         BC000U2_n306DocUltArqSeq = new bool[] {false} ;
         BC000U2_A480DocContrato = new bool[] {false} ;
         BC000U2_A481DocAssinado = new bool[] {false} ;
         BC000U2_A640DocAtivo = new bool[] {false} ;
         BC000U2_n640DocAtivo = new bool[] {false} ;
         BC000U2_A146DocTipoID = new int[1] ;
         BC000U2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U2_n326DocVersaoIDPai = new bool[] {false} ;
         BC000U12_A327DocVersaoNomePai = new string[] {""} ;
         BC000U13_A147DocTipoSigla = new string[] {""} ;
         BC000U13_A148DocTipoNome = new string[] {""} ;
         BC000U13_A219DocTipoAtivo = new bool[] {false} ;
         BC000U14_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U14_n326DocVersaoIDPai = new bool[] {false} ;
         BC000U15_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U15_A307DocArqSeq = new short[1] ;
         BC000U16_A289DocID = new Guid[] {Guid.Empty} ;
         BC000U16_A305DocNome = new string[] {""} ;
         BC000U16_A325DocVersao = new short[1] ;
         BC000U16_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC000U16_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_A295DocInsUsuID = new string[] {""} ;
         BC000U16_n295DocInsUsuID = new bool[] {false} ;
         BC000U16_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n298DocUpdDataHora = new bool[] {false} ;
         BC000U16_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n296DocUpdData = new bool[] {false} ;
         BC000U16_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n297DocUpdHora = new bool[] {false} ;
         BC000U16_A299DocUpdUsuID = new string[] {""} ;
         BC000U16_n299DocUpdUsuID = new bool[] {false} ;
         BC000U16_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n303DocDelDataHora = new bool[] {false} ;
         BC000U16_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n301DocDelData = new bool[] {false} ;
         BC000U16_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000U16_n302DocDelHora = new bool[] {false} ;
         BC000U16_A304DocDelUsuID = new string[] {""} ;
         BC000U16_n304DocDelUsuID = new bool[] {false} ;
         BC000U16_A510DocDelUsuNome = new string[] {""} ;
         BC000U16_n510DocDelUsuNome = new bool[] {false} ;
         BC000U16_A327DocVersaoNomePai = new string[] {""} ;
         BC000U16_A290DocOrigem = new string[] {""} ;
         BC000U16_A291DocOrigemID = new string[] {""} ;
         BC000U16_A300DocDel = new bool[] {false} ;
         BC000U16_A147DocTipoSigla = new string[] {""} ;
         BC000U16_A148DocTipoNome = new string[] {""} ;
         BC000U16_A219DocTipoAtivo = new bool[] {false} ;
         BC000U16_A306DocUltArqSeq = new short[1] ;
         BC000U16_n306DocUltArqSeq = new bool[] {false} ;
         BC000U16_A480DocContrato = new bool[] {false} ;
         BC000U16_A481DocAssinado = new bool[] {false} ;
         BC000U16_A640DocAtivo = new bool[] {false} ;
         BC000U16_n640DocAtivo = new bool[] {false} ;
         BC000U16_A146DocTipoID = new int[1] ;
         BC000U16_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC000U16_n326DocVersaoIDPai = new bool[] {false} ;
         N305DocNome = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documento_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documento_bc__default(),
            new Object[][] {
                new Object[] {
               BC000U2_A289DocID, BC000U2_A305DocNome, BC000U2_A325DocVersao, BC000U2_A294DocInsDataHora, BC000U2_A292DocInsData, BC000U2_A293DocInsHora, BC000U2_A295DocInsUsuID, BC000U2_n295DocInsUsuID, BC000U2_A298DocUpdDataHora, BC000U2_n298DocUpdDataHora,
               BC000U2_A296DocUpdData, BC000U2_n296DocUpdData, BC000U2_A297DocUpdHora, BC000U2_n297DocUpdHora, BC000U2_A299DocUpdUsuID, BC000U2_n299DocUpdUsuID, BC000U2_A303DocDelDataHora, BC000U2_n303DocDelDataHora, BC000U2_A301DocDelData, BC000U2_n301DocDelData,
               BC000U2_A302DocDelHora, BC000U2_n302DocDelHora, BC000U2_A304DocDelUsuID, BC000U2_n304DocDelUsuID, BC000U2_A510DocDelUsuNome, BC000U2_n510DocDelUsuNome, BC000U2_A290DocOrigem, BC000U2_A291DocOrigemID, BC000U2_A300DocDel, BC000U2_A306DocUltArqSeq,
               BC000U2_n306DocUltArqSeq, BC000U2_A480DocContrato, BC000U2_A481DocAssinado, BC000U2_A640DocAtivo, BC000U2_n640DocAtivo, BC000U2_A146DocTipoID, BC000U2_A326DocVersaoIDPai, BC000U2_n326DocVersaoIDPai
               }
               , new Object[] {
               BC000U3_A289DocID, BC000U3_A305DocNome, BC000U3_A325DocVersao, BC000U3_A294DocInsDataHora, BC000U3_A292DocInsData, BC000U3_A293DocInsHora, BC000U3_A295DocInsUsuID, BC000U3_n295DocInsUsuID, BC000U3_A298DocUpdDataHora, BC000U3_n298DocUpdDataHora,
               BC000U3_A296DocUpdData, BC000U3_n296DocUpdData, BC000U3_A297DocUpdHora, BC000U3_n297DocUpdHora, BC000U3_A299DocUpdUsuID, BC000U3_n299DocUpdUsuID, BC000U3_A303DocDelDataHora, BC000U3_n303DocDelDataHora, BC000U3_A301DocDelData, BC000U3_n301DocDelData,
               BC000U3_A302DocDelHora, BC000U3_n302DocDelHora, BC000U3_A304DocDelUsuID, BC000U3_n304DocDelUsuID, BC000U3_A510DocDelUsuNome, BC000U3_n510DocDelUsuNome, BC000U3_A290DocOrigem, BC000U3_A291DocOrigemID, BC000U3_A300DocDel, BC000U3_A306DocUltArqSeq,
               BC000U3_n306DocUltArqSeq, BC000U3_A480DocContrato, BC000U3_A481DocAssinado, BC000U3_A640DocAtivo, BC000U3_n640DocAtivo, BC000U3_A146DocTipoID, BC000U3_A326DocVersaoIDPai, BC000U3_n326DocVersaoIDPai
               }
               , new Object[] {
               BC000U4_A147DocTipoSigla, BC000U4_A148DocTipoNome, BC000U4_A219DocTipoAtivo
               }
               , new Object[] {
               BC000U5_A327DocVersaoNomePai
               }
               , new Object[] {
               BC000U6_A289DocID, BC000U6_A305DocNome, BC000U6_A325DocVersao, BC000U6_A294DocInsDataHora, BC000U6_A292DocInsData, BC000U6_A293DocInsHora, BC000U6_A295DocInsUsuID, BC000U6_n295DocInsUsuID, BC000U6_A298DocUpdDataHora, BC000U6_n298DocUpdDataHora,
               BC000U6_A296DocUpdData, BC000U6_n296DocUpdData, BC000U6_A297DocUpdHora, BC000U6_n297DocUpdHora, BC000U6_A299DocUpdUsuID, BC000U6_n299DocUpdUsuID, BC000U6_A303DocDelDataHora, BC000U6_n303DocDelDataHora, BC000U6_A301DocDelData, BC000U6_n301DocDelData,
               BC000U6_A302DocDelHora, BC000U6_n302DocDelHora, BC000U6_A304DocDelUsuID, BC000U6_n304DocDelUsuID, BC000U6_A510DocDelUsuNome, BC000U6_n510DocDelUsuNome, BC000U6_A327DocVersaoNomePai, BC000U6_A290DocOrigem, BC000U6_A291DocOrigemID, BC000U6_A300DocDel,
               BC000U6_A147DocTipoSigla, BC000U6_A148DocTipoNome, BC000U6_A219DocTipoAtivo, BC000U6_A306DocUltArqSeq, BC000U6_n306DocUltArqSeq, BC000U6_A480DocContrato, BC000U6_A481DocAssinado, BC000U6_A640DocAtivo, BC000U6_n640DocAtivo, BC000U6_A146DocTipoID,
               BC000U6_A326DocVersaoIDPai, BC000U6_n326DocVersaoIDPai
               }
               , new Object[] {
               BC000U7_A326DocVersaoIDPai, BC000U7_n326DocVersaoIDPai
               }
               , new Object[] {
               BC000U8_A289DocID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000U12_A327DocVersaoNomePai
               }
               , new Object[] {
               BC000U13_A147DocTipoSigla, BC000U13_A148DocTipoNome, BC000U13_A219DocTipoAtivo
               }
               , new Object[] {
               BC000U14_A326DocVersaoIDPai
               }
               , new Object[] {
               BC000U15_A289DocID, BC000U15_A307DocArqSeq
               }
               , new Object[] {
               BC000U16_A289DocID, BC000U16_A305DocNome, BC000U16_A325DocVersao, BC000U16_A294DocInsDataHora, BC000U16_A292DocInsData, BC000U16_A293DocInsHora, BC000U16_A295DocInsUsuID, BC000U16_n295DocInsUsuID, BC000U16_A298DocUpdDataHora, BC000U16_n298DocUpdDataHora,
               BC000U16_A296DocUpdData, BC000U16_n296DocUpdData, BC000U16_A297DocUpdHora, BC000U16_n297DocUpdHora, BC000U16_A299DocUpdUsuID, BC000U16_n299DocUpdUsuID, BC000U16_A303DocDelDataHora, BC000U16_n303DocDelDataHora, BC000U16_A301DocDelData, BC000U16_n301DocDelData,
               BC000U16_A302DocDelHora, BC000U16_n302DocDelHora, BC000U16_A304DocDelUsuID, BC000U16_n304DocDelUsuID, BC000U16_A510DocDelUsuNome, BC000U16_n510DocDelUsuNome, BC000U16_A327DocVersaoNomePai, BC000U16_A290DocOrigem, BC000U16_A291DocOrigemID, BC000U16_A300DocDel,
               BC000U16_A147DocTipoSigla, BC000U16_A148DocTipoNome, BC000U16_A219DocTipoAtivo, BC000U16_A306DocUltArqSeq, BC000U16_n306DocUltArqSeq, BC000U16_A480DocContrato, BC000U16_A481DocAssinado, BC000U16_A640DocAtivo, BC000U16_n640DocAtivo, BC000U16_A146DocTipoID,
               BC000U16_A326DocVersaoIDPai, BC000U16_n326DocVersaoIDPai
               }
            }
         );
         Z481DocAssinado = false;
         A481DocAssinado = false;
         i481DocAssinado = false;
         Z480DocContrato = false;
         A480DocContrato = false;
         i480DocContrato = false;
         Z289DocID = Guid.NewGuid( );
         A289DocID = Guid.NewGuid( );
         AV36Pgmname = "core.Documento_BC";
         Z300DocDel = false;
         A300DocDel = false;
         i300DocDel = false;
         Z640DocAtivo = true;
         n640DocAtivo = false;
         A640DocAtivo = true;
         n640DocAtivo = false;
         i640DocAtivo = true;
         n640DocAtivo = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120U2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z325DocVersao ;
      private short A325DocVersao ;
      private short Z306DocUltArqSeq ;
      private short A306DocUltArqSeq ;
      private short Gx_BScreen ;
      private short RcdFound33 ;
      private short nIsDirty_33 ;
      private int trnEnded ;
      private int AV37GXV1 ;
      private int AV14Insert_DocTipoID ;
      private int Z146DocTipoID ;
      private int A146DocTipoID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV36Pgmname ;
      private string Z295DocInsUsuID ;
      private string A295DocInsUsuID ;
      private string Z299DocUpdUsuID ;
      private string A299DocUpdUsuID ;
      private string Z304DocDelUsuID ;
      private string A304DocDelUsuID ;
      private string sMode33 ;
      private DateTime Z294DocInsDataHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime Z293DocInsHora ;
      private DateTime A293DocInsHora ;
      private DateTime Z298DocUpdDataHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime Z297DocUpdHora ;
      private DateTime A297DocUpdHora ;
      private DateTime Z303DocDelDataHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime Z301DocDelData ;
      private DateTime A301DocDelData ;
      private DateTime Z302DocDelHora ;
      private DateTime A302DocDelHora ;
      private DateTime Z292DocInsData ;
      private DateTime A292DocInsData ;
      private DateTime Z296DocUpdData ;
      private DateTime A296DocUpdData ;
      private bool returnInSub ;
      private bool Z300DocDel ;
      private bool A300DocDel ;
      private bool Z480DocContrato ;
      private bool A480DocContrato ;
      private bool Z481DocAssinado ;
      private bool A481DocAssinado ;
      private bool Z640DocAtivo ;
      private bool A640DocAtivo ;
      private bool Z219DocTipoAtivo ;
      private bool A219DocTipoAtivo ;
      private bool n640DocAtivo ;
      private bool n295DocInsUsuID ;
      private bool n298DocUpdDataHora ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n299DocUpdUsuID ;
      private bool n303DocDelDataHora ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n304DocDelUsuID ;
      private bool n510DocDelUsuNome ;
      private bool n306DocUltArqSeq ;
      private bool n326DocVersaoIDPai ;
      private bool O300DocDel ;
      private bool Gx_longc ;
      private bool i481DocAssinado ;
      private bool i480DocContrato ;
      private bool i640DocAtivo ;
      private bool i300DocDel ;
      private bool mustCommit ;
      private string AV34webSessionParm ;
      private string AV29DocOrigem ;
      private string AV30DocOrigemID ;
      private string Z305DocNome ;
      private string A305DocNome ;
      private string Z510DocDelUsuNome ;
      private string A510DocDelUsuNome ;
      private string Z290DocOrigem ;
      private string A290DocOrigem ;
      private string Z291DocOrigemID ;
      private string A291DocOrigemID ;
      private string Z147DocTipoSigla ;
      private string A147DocTipoSigla ;
      private string Z148DocTipoNome ;
      private string A148DocTipoNome ;
      private string Z327DocVersaoNomePai ;
      private string A327DocVersaoNomePai ;
      private string N305DocNome ;
      private Guid Z289DocID ;
      private Guid A289DocID ;
      private Guid AV13Insert_DocVersaoIDPai ;
      private Guid Z326DocVersaoIDPai ;
      private Guid A326DocVersaoIDPai ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtDocumento bccore_Documento ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000U6_A289DocID ;
      private string[] BC000U6_A305DocNome ;
      private short[] BC000U6_A325DocVersao ;
      private DateTime[] BC000U6_A294DocInsDataHora ;
      private DateTime[] BC000U6_A292DocInsData ;
      private DateTime[] BC000U6_A293DocInsHora ;
      private string[] BC000U6_A295DocInsUsuID ;
      private bool[] BC000U6_n295DocInsUsuID ;
      private DateTime[] BC000U6_A298DocUpdDataHora ;
      private bool[] BC000U6_n298DocUpdDataHora ;
      private DateTime[] BC000U6_A296DocUpdData ;
      private bool[] BC000U6_n296DocUpdData ;
      private DateTime[] BC000U6_A297DocUpdHora ;
      private bool[] BC000U6_n297DocUpdHora ;
      private string[] BC000U6_A299DocUpdUsuID ;
      private bool[] BC000U6_n299DocUpdUsuID ;
      private DateTime[] BC000U6_A303DocDelDataHora ;
      private bool[] BC000U6_n303DocDelDataHora ;
      private DateTime[] BC000U6_A301DocDelData ;
      private bool[] BC000U6_n301DocDelData ;
      private DateTime[] BC000U6_A302DocDelHora ;
      private bool[] BC000U6_n302DocDelHora ;
      private string[] BC000U6_A304DocDelUsuID ;
      private bool[] BC000U6_n304DocDelUsuID ;
      private string[] BC000U6_A510DocDelUsuNome ;
      private bool[] BC000U6_n510DocDelUsuNome ;
      private string[] BC000U6_A327DocVersaoNomePai ;
      private string[] BC000U6_A290DocOrigem ;
      private string[] BC000U6_A291DocOrigemID ;
      private bool[] BC000U6_A300DocDel ;
      private string[] BC000U6_A147DocTipoSigla ;
      private string[] BC000U6_A148DocTipoNome ;
      private bool[] BC000U6_A219DocTipoAtivo ;
      private short[] BC000U6_A306DocUltArqSeq ;
      private bool[] BC000U6_n306DocUltArqSeq ;
      private bool[] BC000U6_A480DocContrato ;
      private bool[] BC000U6_A481DocAssinado ;
      private bool[] BC000U6_A640DocAtivo ;
      private bool[] BC000U6_n640DocAtivo ;
      private int[] BC000U6_A146DocTipoID ;
      private Guid[] BC000U6_A326DocVersaoIDPai ;
      private bool[] BC000U6_n326DocVersaoIDPai ;
      private Guid[] BC000U7_A326DocVersaoIDPai ;
      private bool[] BC000U7_n326DocVersaoIDPai ;
      private string[] BC000U5_A327DocVersaoNomePai ;
      private string[] BC000U4_A147DocTipoSigla ;
      private string[] BC000U4_A148DocTipoNome ;
      private bool[] BC000U4_A219DocTipoAtivo ;
      private Guid[] BC000U8_A289DocID ;
      private Guid[] BC000U3_A289DocID ;
      private string[] BC000U3_A305DocNome ;
      private short[] BC000U3_A325DocVersao ;
      private DateTime[] BC000U3_A294DocInsDataHora ;
      private DateTime[] BC000U3_A292DocInsData ;
      private DateTime[] BC000U3_A293DocInsHora ;
      private string[] BC000U3_A295DocInsUsuID ;
      private bool[] BC000U3_n295DocInsUsuID ;
      private DateTime[] BC000U3_A298DocUpdDataHora ;
      private bool[] BC000U3_n298DocUpdDataHora ;
      private DateTime[] BC000U3_A296DocUpdData ;
      private bool[] BC000U3_n296DocUpdData ;
      private DateTime[] BC000U3_A297DocUpdHora ;
      private bool[] BC000U3_n297DocUpdHora ;
      private string[] BC000U3_A299DocUpdUsuID ;
      private bool[] BC000U3_n299DocUpdUsuID ;
      private DateTime[] BC000U3_A303DocDelDataHora ;
      private bool[] BC000U3_n303DocDelDataHora ;
      private DateTime[] BC000U3_A301DocDelData ;
      private bool[] BC000U3_n301DocDelData ;
      private DateTime[] BC000U3_A302DocDelHora ;
      private bool[] BC000U3_n302DocDelHora ;
      private string[] BC000U3_A304DocDelUsuID ;
      private bool[] BC000U3_n304DocDelUsuID ;
      private string[] BC000U3_A510DocDelUsuNome ;
      private bool[] BC000U3_n510DocDelUsuNome ;
      private string[] BC000U3_A290DocOrigem ;
      private string[] BC000U3_A291DocOrigemID ;
      private bool[] BC000U3_A300DocDel ;
      private short[] BC000U3_A306DocUltArqSeq ;
      private bool[] BC000U3_n306DocUltArqSeq ;
      private bool[] BC000U3_A480DocContrato ;
      private bool[] BC000U3_A481DocAssinado ;
      private bool[] BC000U3_A640DocAtivo ;
      private bool[] BC000U3_n640DocAtivo ;
      private int[] BC000U3_A146DocTipoID ;
      private Guid[] BC000U3_A326DocVersaoIDPai ;
      private bool[] BC000U3_n326DocVersaoIDPai ;
      private Guid[] BC000U2_A289DocID ;
      private string[] BC000U2_A305DocNome ;
      private short[] BC000U2_A325DocVersao ;
      private DateTime[] BC000U2_A294DocInsDataHora ;
      private DateTime[] BC000U2_A292DocInsData ;
      private DateTime[] BC000U2_A293DocInsHora ;
      private string[] BC000U2_A295DocInsUsuID ;
      private bool[] BC000U2_n295DocInsUsuID ;
      private DateTime[] BC000U2_A298DocUpdDataHora ;
      private bool[] BC000U2_n298DocUpdDataHora ;
      private DateTime[] BC000U2_A296DocUpdData ;
      private bool[] BC000U2_n296DocUpdData ;
      private DateTime[] BC000U2_A297DocUpdHora ;
      private bool[] BC000U2_n297DocUpdHora ;
      private string[] BC000U2_A299DocUpdUsuID ;
      private bool[] BC000U2_n299DocUpdUsuID ;
      private DateTime[] BC000U2_A303DocDelDataHora ;
      private bool[] BC000U2_n303DocDelDataHora ;
      private DateTime[] BC000U2_A301DocDelData ;
      private bool[] BC000U2_n301DocDelData ;
      private DateTime[] BC000U2_A302DocDelHora ;
      private bool[] BC000U2_n302DocDelHora ;
      private string[] BC000U2_A304DocDelUsuID ;
      private bool[] BC000U2_n304DocDelUsuID ;
      private string[] BC000U2_A510DocDelUsuNome ;
      private bool[] BC000U2_n510DocDelUsuNome ;
      private string[] BC000U2_A290DocOrigem ;
      private string[] BC000U2_A291DocOrigemID ;
      private bool[] BC000U2_A300DocDel ;
      private short[] BC000U2_A306DocUltArqSeq ;
      private bool[] BC000U2_n306DocUltArqSeq ;
      private bool[] BC000U2_A480DocContrato ;
      private bool[] BC000U2_A481DocAssinado ;
      private bool[] BC000U2_A640DocAtivo ;
      private bool[] BC000U2_n640DocAtivo ;
      private int[] BC000U2_A146DocTipoID ;
      private Guid[] BC000U2_A326DocVersaoIDPai ;
      private bool[] BC000U2_n326DocVersaoIDPai ;
      private string[] BC000U12_A327DocVersaoNomePai ;
      private string[] BC000U13_A147DocTipoSigla ;
      private string[] BC000U13_A148DocTipoNome ;
      private bool[] BC000U13_A219DocTipoAtivo ;
      private Guid[] BC000U14_A326DocVersaoIDPai ;
      private bool[] BC000U14_n326DocVersaoIDPai ;
      private Guid[] BC000U15_A289DocID ;
      private short[] BC000U15_A307DocArqSeq ;
      private Guid[] BC000U16_A289DocID ;
      private string[] BC000U16_A305DocNome ;
      private short[] BC000U16_A325DocVersao ;
      private DateTime[] BC000U16_A294DocInsDataHora ;
      private DateTime[] BC000U16_A292DocInsData ;
      private DateTime[] BC000U16_A293DocInsHora ;
      private string[] BC000U16_A295DocInsUsuID ;
      private bool[] BC000U16_n295DocInsUsuID ;
      private DateTime[] BC000U16_A298DocUpdDataHora ;
      private bool[] BC000U16_n298DocUpdDataHora ;
      private DateTime[] BC000U16_A296DocUpdData ;
      private bool[] BC000U16_n296DocUpdData ;
      private DateTime[] BC000U16_A297DocUpdHora ;
      private bool[] BC000U16_n297DocUpdHora ;
      private string[] BC000U16_A299DocUpdUsuID ;
      private bool[] BC000U16_n299DocUpdUsuID ;
      private DateTime[] BC000U16_A303DocDelDataHora ;
      private bool[] BC000U16_n303DocDelDataHora ;
      private DateTime[] BC000U16_A301DocDelData ;
      private bool[] BC000U16_n301DocDelData ;
      private DateTime[] BC000U16_A302DocDelHora ;
      private bool[] BC000U16_n302DocDelHora ;
      private string[] BC000U16_A304DocDelUsuID ;
      private bool[] BC000U16_n304DocDelUsuID ;
      private string[] BC000U16_A510DocDelUsuNome ;
      private bool[] BC000U16_n510DocDelUsuNome ;
      private string[] BC000U16_A327DocVersaoNomePai ;
      private string[] BC000U16_A290DocOrigem ;
      private string[] BC000U16_A291DocOrigemID ;
      private bool[] BC000U16_A300DocDel ;
      private string[] BC000U16_A147DocTipoSigla ;
      private string[] BC000U16_A148DocTipoNome ;
      private bool[] BC000U16_A219DocTipoAtivo ;
      private short[] BC000U16_A306DocUltArqSeq ;
      private bool[] BC000U16_n306DocUltArqSeq ;
      private bool[] BC000U16_A480DocContrato ;
      private bool[] BC000U16_A481DocAssinado ;
      private bool[] BC000U16_A640DocAtivo ;
      private bool[] BC000U16_n640DocAtivo ;
      private int[] BC000U16_A146DocTipoID ;
      private Guid[] BC000U16_A326DocVersaoIDPai ;
      private bool[] BC000U16_n326DocVersaoIDPai ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ;
      private GeneXus.Programs.core.SdtsdtDocumento AV32sdtDocumento ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class documento_bc__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class documento_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000U6;
        prmBC000U6 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U7;
        prmBC000U7 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U5;
        prmBC000U5 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000U4;
        prmBC000U4 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000U8;
        prmBC000U8 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U3;
        prmBC000U3 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U2;
        prmBC000U2 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U9;
        prmBC000U9 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000U10;
        prmBC000U10 = new Object[] {
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U11;
        prmBC000U11 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U12;
        prmBC000U12 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC000U13;
        prmBC000U13 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000U14;
        prmBC000U14 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U15;
        prmBC000U15 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000U16;
        prmBC000U16 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000U2", "SELECT DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U3", "SELECT DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U4", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U5", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U6", "SELECT TM1.DocID, TM1.DocNome, TM1.DocVersao, TM1.DocInsDataHora, TM1.DocInsData, TM1.DocInsHora, TM1.DocInsUsuID, TM1.DocUpdDataHora, TM1.DocUpdData, TM1.DocUpdHora, TM1.DocUpdUsuID, TM1.DocDelDataHora, TM1.DocDelData, TM1.DocDelHora, TM1.DocDelUsuID, TM1.DocDelUsuNome, T2.DocNome AS DocVersaoNomePai, TM1.DocOrigem, TM1.DocOrigemID, TM1.DocDel, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, TM1.DocUltArqSeq, TM1.DocContrato, TM1.DocAssinado, TM1.DocAtivo, TM1.DocTipoID, TM1.DocVersaoIDPai AS DocVersaoIDPai FROM ((tb_documento TM1 LEFT JOIN tb_documento T2 ON T2.DocID = TM1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = TM1.DocTipoID) WHERE TM1.DocID = :DocID ORDER BY TM1.DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U7", "SELECT DocVersaoIDPai FROM tb_documento WHERE (DocVersaoIDPai = :DocVersaoIDPai AND DocVersao = :DocVersao) AND (Not ( DocID = :DocID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U8", "SELECT DocID FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U9", "SAVEPOINT gxupdate;INSERT INTO tb_documento(DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai) VALUES(:DocID, :DocNome, :DocVersao, :DocInsDataHora, :DocInsData, :DocInsHora, :DocInsUsuID, :DocUpdDataHora, :DocUpdData, :DocUpdHora, :DocUpdUsuID, :DocDelDataHora, :DocDelData, :DocDelHora, :DocDelUsuID, :DocDelUsuNome, :DocOrigem, :DocOrigemID, :DocDel, :DocUltArqSeq, :DocContrato, :DocAssinado, :DocAtivo, :DocTipoID, :DocVersaoIDPai);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000U9)
           ,new CursorDef("BC000U10", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocNome=:DocNome, DocVersao=:DocVersao, DocInsDataHora=:DocInsDataHora, DocInsData=:DocInsData, DocInsHora=:DocInsHora, DocInsUsuID=:DocInsUsuID, DocUpdDataHora=:DocUpdDataHora, DocUpdData=:DocUpdData, DocUpdHora=:DocUpdHora, DocUpdUsuID=:DocUpdUsuID, DocDelDataHora=:DocDelDataHora, DocDelData=:DocDelData, DocDelHora=:DocDelHora, DocDelUsuID=:DocDelUsuID, DocDelUsuNome=:DocDelUsuNome, DocOrigem=:DocOrigem, DocOrigemID=:DocOrigemID, DocDel=:DocDel, DocUltArqSeq=:DocUltArqSeq, DocContrato=:DocContrato, DocAssinado=:DocAssinado, DocAtivo=:DocAtivo, DocTipoID=:DocTipoID, DocVersaoIDPai=:DocVersaoIDPai  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U10)
           ,new CursorDef("BC000U11", "SAVEPOINT gxupdate;DELETE FROM tb_documento  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000U11)
           ,new CursorDef("BC000U12", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U13", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000U14", "SELECT DocID AS DocVersaoIDPai FROM tb_documento WHERE DocVersaoIDPai = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U15", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000U16", "SELECT TM1.DocID, TM1.DocNome, TM1.DocVersao, TM1.DocInsDataHora, TM1.DocInsData, TM1.DocInsHora, TM1.DocInsUsuID, TM1.DocUpdDataHora, TM1.DocUpdData, TM1.DocUpdHora, TM1.DocUpdUsuID, TM1.DocDelDataHora, TM1.DocDelData, TM1.DocDelHora, TM1.DocDelUsuID, TM1.DocDelUsuNome, T2.DocNome AS DocVersaoNomePai, TM1.DocOrigem, TM1.DocOrigemID, TM1.DocDel, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, TM1.DocUltArqSeq, TM1.DocContrato, TM1.DocAssinado, TM1.DocAtivo, TM1.DocTipoID, TM1.DocVersaoIDPai AS DocVersaoIDPai FROM ((tb_documento TM1 LEFT JOIN tb_documento T2 ON T2.DocID = TM1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = TM1.DocTipoID) WHERE TM1.DocID = :DocID ORDER BY TM1.DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000U16,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((bool[]) buf[28])[0] = rslt.getBool(19);
              ((short[]) buf[29])[0] = rslt.getShort(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((bool[]) buf[33])[0] = rslt.getBool(23);
              ((bool[]) buf[34])[0] = rslt.wasNull(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((Guid[]) buf[36])[0] = rslt.getGuid(25);
              ((bool[]) buf[37])[0] = rslt.wasNull(25);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((bool[]) buf[28])[0] = rslt.getBool(19);
              ((short[]) buf[29])[0] = rslt.getShort(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((bool[]) buf[33])[0] = rslt.getBool(23);
              ((bool[]) buf[34])[0] = rslt.wasNull(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((Guid[]) buf[36])[0] = rslt.getGuid(25);
              ((bool[]) buf[37])[0] = rslt.wasNull(25);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((string[]) buf[30])[0] = rslt.getVarchar(21);
              ((string[]) buf[31])[0] = rslt.getVarchar(22);
              ((bool[]) buf[32])[0] = rslt.getBool(23);
              ((short[]) buf[33])[0] = rslt.getShort(24);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((bool[]) buf[35])[0] = rslt.getBool(25);
              ((bool[]) buf[36])[0] = rslt.getBool(26);
              ((bool[]) buf[37])[0] = rslt.getBool(27);
              ((bool[]) buf[38])[0] = rslt.wasNull(27);
              ((int[]) buf[39])[0] = rslt.getInt(28);
              ((Guid[]) buf[40])[0] = rslt.getGuid(29);
              ((bool[]) buf[41])[0] = rslt.wasNull(29);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((string[]) buf[30])[0] = rslt.getVarchar(21);
              ((string[]) buf[31])[0] = rslt.getVarchar(22);
              ((bool[]) buf[32])[0] = rslt.getBool(23);
              ((short[]) buf[33])[0] = rslt.getShort(24);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((bool[]) buf[35])[0] = rslt.getBool(25);
              ((bool[]) buf[36])[0] = rslt.getBool(26);
              ((bool[]) buf[37])[0] = rslt.getBool(27);
              ((bool[]) buf[38])[0] = rslt.wasNull(27);
              ((int[]) buf[39])[0] = rslt.getInt(28);
              ((Guid[]) buf[40])[0] = rslt.getGuid(29);
              ((bool[]) buf[41])[0] = rslt.wasNull(29);
              return;
     }
  }

}

}
