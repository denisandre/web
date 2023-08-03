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
   public class documentoestrutura_bc : GxSilentTrn, IGxSilentTrn
   {
      public documentoestrutura_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoestrutura_bc( IGxContext context )
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
         ReadRow1633( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1633( ) ;
         standaloneModal( ) ;
         AddRow1633( ) ;
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
            E11162 ();
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

      protected void CONFIRM_160( )
      {
         BeforeValidate1633( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1633( ) ;
            }
            else
            {
               CheckExtendedTable1633( ) ;
               if ( AnyError == 0 )
               {
                  ZM1633( 31) ;
                  ZM1633( 32) ;
               }
               CloseExtendedTableCursors1633( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode33 = Gx_mode;
            CONFIRM_1634( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode33;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode33;
         }
      }

      protected void CONFIRM_1634( )
      {
         s306DocUltArqSeq = O306DocUltArqSeq;
         n306DocUltArqSeq = false;
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < bccore_DocumentoEstrutura.gxTpr_Arquivos.Count )
         {
            ReadRow1634( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound34 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_34 != 0 ) )
            {
               GetKey1634( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound34 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate1634( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable1634( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors1634( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
                        O306DocUltArqSeq = A306DocUltArqSeq;
                        n306DocUltArqSeq = false;
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                     AnyError = 1;
                  }
               }
               else
               {
                  if ( RcdFound34 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey1634( ) ;
                        Load1634( ) ;
                        BeforeValidate1634( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls1634( ) ;
                           O306DocUltArqSeq = A306DocUltArqSeq;
                           n306DocUltArqSeq = false;
                        }
                     }
                     else
                     {
                        if ( nIsMod_34 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate1634( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable1634( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors1634( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
                              O306DocUltArqSeq = A306DocUltArqSeq;
                              n306DocUltArqSeq = false;
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( ! IsDlt( ) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
               VarsToRow34( ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)bccore_DocumentoEstrutura.gxTpr_Arquivos.Item(nGXsfl_34_idx))) ;
            }
         }
         O306DocUltArqSeq = s306DocUltArqSeq;
         n306DocUltArqSeq = false;
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E12162( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV26Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV27GXV1 = 1;
            while ( AV27GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV27GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocVersaoIDPai") == 0 )
               {
                  AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocTipoID") == 0 )
               {
                  AV14Insert_DocTipoID = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV27GXV1 = (int)(AV27GXV1+1);
            }
         }
      }

      protected void E11162( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV24AuditingObject,  AV26Pgmname) ;
      }

      protected void ZM1633( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z294DocInsDataHora = A294DocInsDataHora;
            Z292DocInsData = A292DocInsData;
            Z293DocInsHora = A293DocInsHora;
            Z295DocInsUsuID = A295DocInsUsuID;
            Z325DocVersao = A325DocVersao;
            Z290DocOrigem = A290DocOrigem;
            Z291DocOrigemID = A291DocOrigemID;
            Z296DocUpdData = A296DocUpdData;
            Z297DocUpdHora = A297DocUpdHora;
            Z298DocUpdDataHora = A298DocUpdDataHora;
            Z299DocUpdUsuID = A299DocUpdUsuID;
            Z300DocDel = A300DocDel;
            Z301DocDelData = A301DocDelData;
            Z302DocDelHora = A302DocDelHora;
            Z303DocDelDataHora = A303DocDelDataHora;
            Z304DocDelUsuID = A304DocDelUsuID;
            Z305DocNome = A305DocNome;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z640DocAtivo = A640DocAtivo;
            Z481DocAssinado = A481DocAssinado;
            Z480DocContrato = A480DocContrato;
            Z146DocTipoID = A146DocTipoID;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
         }
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
         }
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z327DocVersaoNomePai = A327DocVersaoNomePai;
         }
         if ( GX_JID == -29 )
         {
            Z289DocID = A289DocID;
            Z294DocInsDataHora = A294DocInsDataHora;
            Z292DocInsData = A292DocInsData;
            Z293DocInsHora = A293DocInsHora;
            Z295DocInsUsuID = A295DocInsUsuID;
            Z325DocVersao = A325DocVersao;
            Z290DocOrigem = A290DocOrigem;
            Z291DocOrigemID = A291DocOrigemID;
            Z296DocUpdData = A296DocUpdData;
            Z297DocUpdHora = A297DocUpdHora;
            Z298DocUpdDataHora = A298DocUpdDataHora;
            Z299DocUpdUsuID = A299DocUpdUsuID;
            Z300DocDel = A300DocDel;
            Z301DocDelData = A301DocDelData;
            Z302DocDelHora = A302DocDelHora;
            Z303DocDelDataHora = A303DocDelDataHora;
            Z304DocDelUsuID = A304DocDelUsuID;
            Z305DocNome = A305DocNome;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z640DocAtivo = A640DocAtivo;
            Z481DocAssinado = A481DocAssinado;
            Z480DocContrato = A480DocContrato;
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
         AV26Pgmname = "core.DocumentoEstrutura_BC";
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A289DocID) )
         {
            A289DocID = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A640DocAtivo) && ( Gx_BScreen == 0 ) )
         {
            A640DocAtivo = true;
            n640DocAtivo = false;
         }
         if ( IsIns( )  && (false==A481DocAssinado) && ( Gx_BScreen == 0 ) )
         {
            A481DocAssinado = false;
         }
         if ( IsIns( )  && (false==A480DocContrato) && ( Gx_BScreen == 0 ) )
         {
            A480DocContrato = false;
         }
         if ( IsIns( )  && (false==A300DocDel) && ( Gx_BScreen == 0 ) )
         {
            A300DocDel = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1633( )
      {
         /* Using cursor BC00168 */
         pr_default.execute(6, new Object[] {A289DocID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound33 = 1;
            A294DocInsDataHora = BC00168_A294DocInsDataHora[0];
            A292DocInsData = BC00168_A292DocInsData[0];
            A293DocInsHora = BC00168_A293DocInsHora[0];
            A295DocInsUsuID = BC00168_A295DocInsUsuID[0];
            n295DocInsUsuID = BC00168_n295DocInsUsuID[0];
            A325DocVersao = BC00168_A325DocVersao[0];
            A327DocVersaoNomePai = BC00168_A327DocVersaoNomePai[0];
            A290DocOrigem = BC00168_A290DocOrigem[0];
            A291DocOrigemID = BC00168_A291DocOrigemID[0];
            A296DocUpdData = BC00168_A296DocUpdData[0];
            n296DocUpdData = BC00168_n296DocUpdData[0];
            A297DocUpdHora = BC00168_A297DocUpdHora[0];
            n297DocUpdHora = BC00168_n297DocUpdHora[0];
            A298DocUpdDataHora = BC00168_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC00168_n298DocUpdDataHora[0];
            A299DocUpdUsuID = BC00168_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC00168_n299DocUpdUsuID[0];
            A300DocDel = BC00168_A300DocDel[0];
            A301DocDelData = BC00168_A301DocDelData[0];
            n301DocDelData = BC00168_n301DocDelData[0];
            A302DocDelHora = BC00168_A302DocDelHora[0];
            n302DocDelHora = BC00168_n302DocDelHora[0];
            A303DocDelDataHora = BC00168_A303DocDelDataHora[0];
            n303DocDelDataHora = BC00168_n303DocDelDataHora[0];
            A304DocDelUsuID = BC00168_A304DocDelUsuID[0];
            n304DocDelUsuID = BC00168_n304DocDelUsuID[0];
            A305DocNome = BC00168_A305DocNome[0];
            A147DocTipoSigla = BC00168_A147DocTipoSigla[0];
            A148DocTipoNome = BC00168_A148DocTipoNome[0];
            A219DocTipoAtivo = BC00168_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC00168_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00168_n306DocUltArqSeq[0];
            A640DocAtivo = BC00168_A640DocAtivo[0];
            n640DocAtivo = BC00168_n640DocAtivo[0];
            A481DocAssinado = BC00168_A481DocAssinado[0];
            A480DocContrato = BC00168_A480DocContrato[0];
            A146DocTipoID = BC00168_A146DocTipoID[0];
            A326DocVersaoIDPai = BC00168_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00168_n326DocVersaoIDPai[0];
            ZM1633( -29) ;
         }
         pr_default.close(6);
         OnLoadActions1633( ) ;
      }

      protected void OnLoadActions1633( )
      {
      }

      protected void CheckExtendedTable1633( )
      {
         nIsDirty_33 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00169 */
         pr_default.execute(7, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai, A325DocVersao, A289DocID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Documento Original"+","+"Versão"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(7);
         /* Using cursor BC00167 */
         pr_default.execute(5, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (Guid.Empty==A326DocVersaoIDPai) ) )
            {
               GX_msglist.addItem("Não existe 'Documento -> Documento Pai'.", "ForeignKeyNotFound", 1, "DOCVERSAOIDPAI");
               AnyError = 1;
            }
         }
         A327DocVersaoNomePai = BC00167_A327DocVersaoNomePai[0];
         pr_default.close(5);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A305DocNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição do Documento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00166 */
         pr_default.execute(4, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCTIPOID");
            AnyError = 1;
         }
         A147DocTipoSigla = BC00166_A147DocTipoSigla[0];
         A148DocTipoNome = BC00166_A148DocTipoNome[0];
         A219DocTipoAtivo = BC00166_A219DocTipoAtivo[0];
         pr_default.close(4);
         if ( (0==A146DocTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Documento", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1633( )
      {
         pr_default.close(5);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1633( )
      {
         /* Using cursor BC001610 */
         pr_default.execute(8, new Object[] {A289DocID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00165 */
         pr_default.execute(3, new Object[] {A289DocID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM1633( 29) ;
            RcdFound33 = 1;
            A289DocID = BC00165_A289DocID[0];
            A294DocInsDataHora = BC00165_A294DocInsDataHora[0];
            A292DocInsData = BC00165_A292DocInsData[0];
            A293DocInsHora = BC00165_A293DocInsHora[0];
            A295DocInsUsuID = BC00165_A295DocInsUsuID[0];
            n295DocInsUsuID = BC00165_n295DocInsUsuID[0];
            A325DocVersao = BC00165_A325DocVersao[0];
            A290DocOrigem = BC00165_A290DocOrigem[0];
            A291DocOrigemID = BC00165_A291DocOrigemID[0];
            A296DocUpdData = BC00165_A296DocUpdData[0];
            n296DocUpdData = BC00165_n296DocUpdData[0];
            A297DocUpdHora = BC00165_A297DocUpdHora[0];
            n297DocUpdHora = BC00165_n297DocUpdHora[0];
            A298DocUpdDataHora = BC00165_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC00165_n298DocUpdDataHora[0];
            A299DocUpdUsuID = BC00165_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC00165_n299DocUpdUsuID[0];
            A300DocDel = BC00165_A300DocDel[0];
            A301DocDelData = BC00165_A301DocDelData[0];
            n301DocDelData = BC00165_n301DocDelData[0];
            A302DocDelHora = BC00165_A302DocDelHora[0];
            n302DocDelHora = BC00165_n302DocDelHora[0];
            A303DocDelDataHora = BC00165_A303DocDelDataHora[0];
            n303DocDelDataHora = BC00165_n303DocDelDataHora[0];
            A304DocDelUsuID = BC00165_A304DocDelUsuID[0];
            n304DocDelUsuID = BC00165_n304DocDelUsuID[0];
            A305DocNome = BC00165_A305DocNome[0];
            A306DocUltArqSeq = BC00165_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00165_n306DocUltArqSeq[0];
            A640DocAtivo = BC00165_A640DocAtivo[0];
            n640DocAtivo = BC00165_n640DocAtivo[0];
            A481DocAssinado = BC00165_A481DocAssinado[0];
            A480DocContrato = BC00165_A480DocContrato[0];
            A146DocTipoID = BC00165_A146DocTipoID[0];
            A326DocVersaoIDPai = BC00165_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00165_n326DocVersaoIDPai[0];
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
            Z289DocID = A289DocID;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1633( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey1633( ) ;
            }
            Gx_mode = sMode33;
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey1633( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode33;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey1633( ) ;
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
         CONFIRM_160( ) ;
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

      protected void CheckOptimisticConcurrency1633( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00164 */
            pr_default.execute(2, new Object[] {A289DocID});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( Z294DocInsDataHora != BC00164_A294DocInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z292DocInsData ) != DateTimeUtil.ResetTime ( BC00164_A292DocInsData[0] ) ) || ( Z293DocInsHora != BC00164_A293DocInsHora[0] ) || ( StringUtil.StrCmp(Z295DocInsUsuID, BC00164_A295DocInsUsuID[0]) != 0 ) || ( Z325DocVersao != BC00164_A325DocVersao[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z290DocOrigem, BC00164_A290DocOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z291DocOrigemID, BC00164_A291DocOrigemID[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z296DocUpdData ) != DateTimeUtil.ResetTime ( BC00164_A296DocUpdData[0] ) ) || ( Z297DocUpdHora != BC00164_A297DocUpdHora[0] ) || ( Z298DocUpdDataHora != BC00164_A298DocUpdDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z299DocUpdUsuID, BC00164_A299DocUpdUsuID[0]) != 0 ) || ( Z300DocDel != BC00164_A300DocDel[0] ) || ( Z301DocDelData != BC00164_A301DocDelData[0] ) || ( Z302DocDelHora != BC00164_A302DocDelHora[0] ) || ( Z303DocDelDataHora != BC00164_A303DocDelDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z304DocDelUsuID, BC00164_A304DocDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z305DocNome, BC00164_A305DocNome[0]) != 0 ) || ( Z306DocUltArqSeq != BC00164_A306DocUltArqSeq[0] ) || ( Z640DocAtivo != BC00164_A640DocAtivo[0] ) || ( Z481DocAssinado != BC00164_A481DocAssinado[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z480DocContrato != BC00164_A480DocContrato[0] ) || ( Z146DocTipoID != BC00164_A146DocTipoID[0] ) || ( Z326DocVersaoIDPai != BC00164_A326DocVersaoIDPai[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1633( )
      {
         BeforeValidate1633( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1633( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1633( 0) ;
            CheckOptimisticConcurrency1633( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1633( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1633( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001611 */
                     pr_default.execute(9, new Object[] {A289DocID, A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, A325DocVersao, A290DocOrigem, A291DocOrigemID, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n298DocUpdDataHora, A298DocUpdDataHora, n299DocUpdUsuID, A299DocUpdUsuID, A300DocDel, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n303DocDelDataHora, A303DocDelDataHora, n304DocDelUsuID, A304DocDelUsuID, A305DocNome, n306DocUltArqSeq, A306DocUltArqSeq, n640DocAtivo, A640DocAtivo, A481DocAssinado, A480DocContrato, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(9) == 1) )
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
                           ProcessLevel1633( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                           }
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
               Load1633( ) ;
            }
            EndLevel1633( ) ;
         }
         CloseExtendedTableCursors1633( ) ;
      }

      protected void Update1633( )
      {
         BeforeValidate1633( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1633( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1633( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1633( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1633( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001612 */
                     pr_default.execute(10, new Object[] {A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, A325DocVersao, A290DocOrigem, A291DocOrigemID, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n298DocUpdDataHora, A298DocUpdDataHora, n299DocUpdUsuID, A299DocUpdUsuID, A300DocDel, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n303DocDelDataHora, A303DocDelDataHora, n304DocDelUsuID, A304DocDelUsuID, A305DocNome, n306DocUltArqSeq, A306DocUltArqSeq, n640DocAtivo, A640DocAtivo, A481DocAssinado, A480DocContrato, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai, A289DocID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1633( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel1633( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
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
            }
            EndLevel1633( ) ;
         }
         CloseExtendedTableCursors1633( ) ;
      }

      protected void DeferredUpdate1633( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1633( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1633( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1633( ) ;
            AfterConfirm1633( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1633( ) ;
               if ( AnyError == 0 )
               {
                  A306DocUltArqSeq = O306DocUltArqSeq;
                  n306DocUltArqSeq = false;
                  ScanKeyStart1634( ) ;
                  while ( RcdFound34 != 0 )
                  {
                     getByPrimaryKey1634( ) ;
                     Delete1634( ) ;
                     ScanKeyNext1634( ) ;
                     O306DocUltArqSeq = A306DocUltArqSeq;
                     n306DocUltArqSeq = false;
                  }
                  ScanKeyEnd1634( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001613 */
                     pr_default.execute(11, new Object[] {A289DocID});
                     pr_default.close(11);
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
         }
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1633( ) ;
         Gx_mode = sMode33;
      }

      protected void OnDeleteControls1633( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001614 */
            pr_default.execute(12, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
            A327DocVersaoNomePai = BC001614_A327DocVersaoNomePai[0];
            pr_default.close(12);
            /* Using cursor BC001615 */
            pr_default.execute(13, new Object[] {A146DocTipoID});
            A147DocTipoSigla = BC001615_A147DocTipoSigla[0];
            A148DocTipoNome = BC001615_A148DocTipoNome[0];
            A219DocTipoAtivo = BC001615_A219DocTipoAtivo[0];
            pr_default.close(13);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001616 */
            pr_default.execute(14, new Object[] {A289DocID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel1634( )
      {
         s306DocUltArqSeq = O306DocUltArqSeq;
         n306DocUltArqSeq = false;
         nGXsfl_34_idx = 0;
         while ( nGXsfl_34_idx < bccore_DocumentoEstrutura.gxTpr_Arquivos.Count )
         {
            ReadRow1634( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound34 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_34 != 0 ) )
            {
               standaloneNotModal1634( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert1634( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete1634( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update1634( ) ;
                  }
               }
               O306DocUltArqSeq = A306DocUltArqSeq;
               n306DocUltArqSeq = false;
            }
            KeyVarsToRow34( ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)bccore_DocumentoEstrutura.gxTpr_Arquivos.Item(nGXsfl_34_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_34_idx = 0;
            while ( nGXsfl_34_idx < bccore_DocumentoEstrutura.gxTpr_Arquivos.Count )
            {
               ReadRow1634( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound34 == 0 )
                  {
                     Gx_mode = "INS";
                  }
                  else
                  {
                     Gx_mode = "UPD";
                  }
               }
               /* Update SDT row */
               if ( IsDlt( ) )
               {
                  bccore_DocumentoEstrutura.gxTpr_Arquivos.RemoveElement(nGXsfl_34_idx);
                  nGXsfl_34_idx = (int)(nGXsfl_34_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey1634( ) ;
                  VarsToRow34( ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)bccore_DocumentoEstrutura.gxTpr_Arquivos.Item(nGXsfl_34_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll1634( ) ;
         if ( AnyError != 0 )
         {
            O306DocUltArqSeq = s306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         nRcdExists_34 = 0;
         nIsMod_34 = 0;
         Gxremove34 = 0;
      }

      protected void ProcessLevel1633( )
      {
         /* Save parent mode. */
         sMode33 = Gx_mode;
         ProcessNestedLevel1634( ) ;
         if ( AnyError != 0 )
         {
            O306DocUltArqSeq = s306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         /* Restore parent mode. */
         Gx_mode = sMode33;
         /* ' Update level parameters */
         /* Using cursor BC001617 */
         pr_default.execute(15, new Object[] {n306DocUltArqSeq, A306DocUltArqSeq, A289DocID});
         pr_default.close(15);
         pr_default.SmartCacheProvider.SetUpdated("tb_documento");
      }

      protected void EndLevel1633( )
      {
         pr_default.close(2);
         if ( AnyError == 0 )
         {
            BeforeComplete1633( ) ;
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

      public void ScanKeyStart1633( )
      {
         /* Scan By routine */
         /* Using cursor BC001618 */
         pr_default.execute(16, new Object[] {A289DocID});
         RcdFound33 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = BC001618_A289DocID[0];
            A294DocInsDataHora = BC001618_A294DocInsDataHora[0];
            A292DocInsData = BC001618_A292DocInsData[0];
            A293DocInsHora = BC001618_A293DocInsHora[0];
            A295DocInsUsuID = BC001618_A295DocInsUsuID[0];
            n295DocInsUsuID = BC001618_n295DocInsUsuID[0];
            A325DocVersao = BC001618_A325DocVersao[0];
            A327DocVersaoNomePai = BC001618_A327DocVersaoNomePai[0];
            A290DocOrigem = BC001618_A290DocOrigem[0];
            A291DocOrigemID = BC001618_A291DocOrigemID[0];
            A296DocUpdData = BC001618_A296DocUpdData[0];
            n296DocUpdData = BC001618_n296DocUpdData[0];
            A297DocUpdHora = BC001618_A297DocUpdHora[0];
            n297DocUpdHora = BC001618_n297DocUpdHora[0];
            A298DocUpdDataHora = BC001618_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC001618_n298DocUpdDataHora[0];
            A299DocUpdUsuID = BC001618_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC001618_n299DocUpdUsuID[0];
            A300DocDel = BC001618_A300DocDel[0];
            A301DocDelData = BC001618_A301DocDelData[0];
            n301DocDelData = BC001618_n301DocDelData[0];
            A302DocDelHora = BC001618_A302DocDelHora[0];
            n302DocDelHora = BC001618_n302DocDelHora[0];
            A303DocDelDataHora = BC001618_A303DocDelDataHora[0];
            n303DocDelDataHora = BC001618_n303DocDelDataHora[0];
            A304DocDelUsuID = BC001618_A304DocDelUsuID[0];
            n304DocDelUsuID = BC001618_n304DocDelUsuID[0];
            A305DocNome = BC001618_A305DocNome[0];
            A147DocTipoSigla = BC001618_A147DocTipoSigla[0];
            A148DocTipoNome = BC001618_A148DocTipoNome[0];
            A219DocTipoAtivo = BC001618_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC001618_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC001618_n306DocUltArqSeq[0];
            A640DocAtivo = BC001618_A640DocAtivo[0];
            n640DocAtivo = BC001618_n640DocAtivo[0];
            A481DocAssinado = BC001618_A481DocAssinado[0];
            A480DocContrato = BC001618_A480DocContrato[0];
            A146DocTipoID = BC001618_A146DocTipoID[0];
            A326DocVersaoIDPai = BC001618_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC001618_n326DocVersaoIDPai[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1633( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound33 = 0;
         ScanKeyLoad1633( ) ;
      }

      protected void ScanKeyLoad1633( )
      {
         sMode33 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = BC001618_A289DocID[0];
            A294DocInsDataHora = BC001618_A294DocInsDataHora[0];
            A292DocInsData = BC001618_A292DocInsData[0];
            A293DocInsHora = BC001618_A293DocInsHora[0];
            A295DocInsUsuID = BC001618_A295DocInsUsuID[0];
            n295DocInsUsuID = BC001618_n295DocInsUsuID[0];
            A325DocVersao = BC001618_A325DocVersao[0];
            A327DocVersaoNomePai = BC001618_A327DocVersaoNomePai[0];
            A290DocOrigem = BC001618_A290DocOrigem[0];
            A291DocOrigemID = BC001618_A291DocOrigemID[0];
            A296DocUpdData = BC001618_A296DocUpdData[0];
            n296DocUpdData = BC001618_n296DocUpdData[0];
            A297DocUpdHora = BC001618_A297DocUpdHora[0];
            n297DocUpdHora = BC001618_n297DocUpdHora[0];
            A298DocUpdDataHora = BC001618_A298DocUpdDataHora[0];
            n298DocUpdDataHora = BC001618_n298DocUpdDataHora[0];
            A299DocUpdUsuID = BC001618_A299DocUpdUsuID[0];
            n299DocUpdUsuID = BC001618_n299DocUpdUsuID[0];
            A300DocDel = BC001618_A300DocDel[0];
            A301DocDelData = BC001618_A301DocDelData[0];
            n301DocDelData = BC001618_n301DocDelData[0];
            A302DocDelHora = BC001618_A302DocDelHora[0];
            n302DocDelHora = BC001618_n302DocDelHora[0];
            A303DocDelDataHora = BC001618_A303DocDelDataHora[0];
            n303DocDelDataHora = BC001618_n303DocDelDataHora[0];
            A304DocDelUsuID = BC001618_A304DocDelUsuID[0];
            n304DocDelUsuID = BC001618_n304DocDelUsuID[0];
            A305DocNome = BC001618_A305DocNome[0];
            A147DocTipoSigla = BC001618_A147DocTipoSigla[0];
            A148DocTipoNome = BC001618_A148DocTipoNome[0];
            A219DocTipoAtivo = BC001618_A219DocTipoAtivo[0];
            A306DocUltArqSeq = BC001618_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC001618_n306DocUltArqSeq[0];
            A640DocAtivo = BC001618_A640DocAtivo[0];
            n640DocAtivo = BC001618_n640DocAtivo[0];
            A481DocAssinado = BC001618_A481DocAssinado[0];
            A480DocContrato = BC001618_A480DocContrato[0];
            A146DocTipoID = BC001618_A146DocTipoID[0];
            A326DocVersaoIDPai = BC001618_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC001618_n326DocVersaoIDPai[0];
         }
         Gx_mode = sMode33;
      }

      protected void ScanKeyEnd1633( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm1633( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1633( )
      {
         /* Before Insert Rules */
         A294DocInsDataHora = DateTimeUtil.NowMS( context);
         A295DocInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n295DocInsUsuID = false;
         A292DocInsData = DateTimeUtil.ResetTime( A294DocInsDataHora);
         A293DocInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A294DocInsDataHora));
      }

      protected void BeforeUpdate1633( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditdocumentoestrutura(context ).execute(  "Y", ref  AV24AuditingObject,  A289DocID,  Gx_mode) ;
      }

      protected void BeforeDelete1633( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumentoestrutura(context ).execute(  "Y", ref  AV24AuditingObject,  A289DocID,  Gx_mode) ;
      }

      protected void BeforeComplete1633( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoestrutura(context ).execute(  "N", ref  AV24AuditingObject,  A289DocID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoestrutura(context ).execute(  "N", ref  AV24AuditingObject,  A289DocID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1633( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1633( )
      {
      }

      protected void ZM1634( short GX_JID )
      {
         if ( ( GX_JID == 33 ) || ( GX_JID == 0 ) )
         {
            Z644DocArqArmExterno = A644DocArqArmExterno;
            Z316DocArqDel = A316DocArqDel;
            Z310DocArqInsDataHora = A310DocArqInsDataHora;
            Z308DocArqInsData = A308DocArqInsData;
            Z309DocArqInsHora = A309DocArqInsHora;
            Z311DocArqInsUsuID = A311DocArqInsUsuID;
            Z312DocArqUpdData = A312DocArqUpdData;
            Z313DocArqUpdHora = A313DocArqUpdHora;
            Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
            Z315DocArqUsuID = A315DocArqUsuID;
            Z317DocArqDelData = A317DocArqDelData;
            Z319DocArqDelDataHora = A319DocArqDelDataHora;
            Z320DocArqDelUsuID = A320DocArqDelUsuID;
            Z324DocArqObservacao = A324DocArqObservacao;
            Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
         }
         if ( GX_JID == -33 )
         {
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            Z644DocArqArmExterno = A644DocArqArmExterno;
            Z316DocArqDel = A316DocArqDel;
            Z310DocArqInsDataHora = A310DocArqInsDataHora;
            Z308DocArqInsData = A308DocArqInsData;
            Z309DocArqInsHora = A309DocArqInsHora;
            Z311DocArqInsUsuID = A311DocArqInsUsuID;
            Z312DocArqUpdData = A312DocArqUpdData;
            Z313DocArqUpdHora = A313DocArqUpdHora;
            Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
            Z315DocArqUsuID = A315DocArqUsuID;
            Z317DocArqDelData = A317DocArqDelData;
            Z319DocArqDelDataHora = A319DocArqDelDataHora;
            Z320DocArqDelUsuID = A320DocArqDelUsuID;
            Z321DocArqConteudo = A321DocArqConteudo;
            Z324DocArqObservacao = A324DocArqObservacao;
            Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
            Z323DocArqConteudoExtensao = A323DocArqConteudoExtensao;
            Z322DocArqConteudoNome = A322DocArqConteudoNome;
         }
      }

      protected void standaloneNotModal1634( )
      {
      }

      protected void standaloneModal1634( )
      {
         if ( IsIns( )  )
         {
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
         }
         if ( IsIns( )  )
         {
            A307DocArqSeq = A306DocUltArqSeq;
         }
         if ( IsIns( )  && (false==A644DocArqArmExterno) && ( Gx_BScreen == 0 ) )
         {
            A644DocArqArmExterno = false;
         }
         if ( IsIns( )  && (false==A316DocArqDel) && ( Gx_BScreen == 0 ) )
         {
            A316DocArqDel = false;
         }
      }

      protected void Load1634( )
      {
         /* Using cursor BC001619 */
         pr_default.execute(17, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound34 = 1;
            A644DocArqArmExterno = BC001619_A644DocArqArmExterno[0];
            A316DocArqDel = BC001619_A316DocArqDel[0];
            A310DocArqInsDataHora = BC001619_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC001619_A308DocArqInsData[0];
            A309DocArqInsHora = BC001619_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC001619_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC001619_n311DocArqInsUsuID[0];
            A312DocArqUpdData = BC001619_A312DocArqUpdData[0];
            n312DocArqUpdData = BC001619_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC001619_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC001619_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC001619_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC001619_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC001619_A315DocArqUsuID[0];
            n315DocArqUsuID = BC001619_n315DocArqUsuID[0];
            A317DocArqDelData = BC001619_A317DocArqDelData[0];
            n317DocArqDelData = BC001619_n317DocArqDelData[0];
            A319DocArqDelDataHora = BC001619_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC001619_n319DocArqDelDataHora[0];
            A320DocArqDelUsuID = BC001619_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC001619_n320DocArqDelUsuID[0];
            A324DocArqObservacao = BC001619_A324DocArqObservacao[0];
            n324DocArqObservacao = BC001619_n324DocArqObservacao[0];
            A645DocArqArmExternoPath = BC001619_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC001619_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC001619_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC001619_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A321DocArqConteudo = BC001619_A321DocArqConteudo[0];
            n321DocArqConteudo = BC001619_n321DocArqConteudo[0];
            ZM1634( -33) ;
         }
         pr_default.close(17);
         OnLoadActions1634( ) ;
      }

      protected void OnLoadActions1634( )
      {
      }

      protected void CheckExtendedTable1634( )
      {
         nIsDirty_34 = 0;
         Gx_BScreen = 1;
         standaloneModal1634( ) ;
         Gx_BScreen = 0;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A321DocArqConteudo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Conteúdo do Arquivo", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1634( )
      {
      }

      protected void enableDisable1634( )
      {
      }

      protected void GetKey1634( )
      {
         /* Using cursor BC001620 */
         pr_default.execute(18, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey1634( )
      {
         /* Using cursor BC00163 */
         pr_default.execute(1, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1634( 33) ;
            RcdFound34 = 1;
            InitializeNonKey1634( ) ;
            A307DocArqSeq = BC00163_A307DocArqSeq[0];
            A644DocArqArmExterno = BC00163_A644DocArqArmExterno[0];
            A316DocArqDel = BC00163_A316DocArqDel[0];
            A310DocArqInsDataHora = BC00163_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC00163_A308DocArqInsData[0];
            A309DocArqInsHora = BC00163_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC00163_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC00163_n311DocArqInsUsuID[0];
            A312DocArqUpdData = BC00163_A312DocArqUpdData[0];
            n312DocArqUpdData = BC00163_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC00163_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC00163_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC00163_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC00163_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC00163_A315DocArqUsuID[0];
            n315DocArqUsuID = BC00163_n315DocArqUsuID[0];
            A317DocArqDelData = BC00163_A317DocArqDelData[0];
            n317DocArqDelData = BC00163_n317DocArqDelData[0];
            A319DocArqDelDataHora = BC00163_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC00163_n319DocArqDelDataHora[0];
            A320DocArqDelUsuID = BC00163_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC00163_n320DocArqDelUsuID[0];
            A324DocArqObservacao = BC00163_A324DocArqObservacao[0];
            n324DocArqObservacao = BC00163_n324DocArqObservacao[0];
            A645DocArqArmExternoPath = BC00163_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC00163_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC00163_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC00163_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A321DocArqConteudo = BC00163_A321DocArqConteudo[0];
            n321DocArqConteudo = BC00163_n321DocArqConteudo[0];
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1634( ) ;
            Load1634( ) ;
            Gx_mode = sMode34;
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey1634( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal1634( ) ;
            Gx_mode = sMode34;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes1634( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency1634( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00162 */
            pr_default.execute(0, new Object[] {A289DocID, A307DocArqSeq});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z644DocArqArmExterno != BC00162_A644DocArqArmExterno[0] ) || ( Z316DocArqDel != BC00162_A316DocArqDel[0] ) || ( Z310DocArqInsDataHora != BC00162_A310DocArqInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z308DocArqInsData ) != DateTimeUtil.ResetTime ( BC00162_A308DocArqInsData[0] ) ) || ( Z309DocArqInsHora != BC00162_A309DocArqInsHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z311DocArqInsUsuID, BC00162_A311DocArqInsUsuID[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z312DocArqUpdData ) != DateTimeUtil.ResetTime ( BC00162_A312DocArqUpdData[0] ) ) || ( Z313DocArqUpdHora != BC00162_A313DocArqUpdHora[0] ) || ( Z314DocArqUpdDataHora != BC00162_A314DocArqUpdDataHora[0] ) || ( StringUtil.StrCmp(Z315DocArqUsuID, BC00162_A315DocArqUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z317DocArqDelData != BC00162_A317DocArqDelData[0] ) || ( Z319DocArqDelDataHora != BC00162_A319DocArqDelDataHora[0] ) || ( StringUtil.StrCmp(Z320DocArqDelUsuID, BC00162_A320DocArqDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z324DocArqObservacao, BC00162_A324DocArqObservacao[0]) != 0 ) || ( StringUtil.StrCmp(Z645DocArqArmExternoPath, BC00162_A645DocArqArmExternoPath[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento_arquivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1634( )
      {
         BeforeValidate1634( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1634( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1634( 0) ;
            CheckOptimisticConcurrency1634( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1634( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1634( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001621 */
                     pr_default.execute(19, new Object[] {A289DocID, A307DocArqSeq, A644DocArqArmExterno, A316DocArqDel, A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, n317DocArqDelData, A317DocArqDelData, n319DocArqDelDataHora, A319DocArqDelDataHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n321DocArqConteudo, A321DocArqConteudo, n324DocArqObservacao, A324DocArqObservacao, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load1634( ) ;
            }
            EndLevel1634( ) ;
         }
         CloseExtendedTableCursors1634( ) ;
      }

      protected void Update1634( )
      {
         BeforeValidate1634( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1634( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1634( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1634( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1634( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001622 */
                     pr_default.execute(20, new Object[] {A644DocArqArmExterno, A316DocArqDel, A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, n317DocArqDelData, A317DocArqDelData, n319DocArqDelDataHora, A319DocArqDelDataHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n324DocArqObservacao, A324DocArqObservacao, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome, A289DocID, A307DocArqSeq});
                     pr_default.close(20);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(20) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1634( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey1634( ) ;
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
            EndLevel1634( ) ;
         }
         CloseExtendedTableCursors1634( ) ;
      }

      protected void DeferredUpdate1634( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001623 */
            pr_default.execute(21, new Object[] {n321DocArqConteudo, A321DocArqConteudo, A289DocID, A307DocArqSeq});
            pr_default.close(21);
            pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
         }
      }

      protected void Delete1634( )
      {
         Gx_mode = "DLT";
         BeforeValidate1634( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1634( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1634( ) ;
            AfterConfirm1634( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1634( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001624 */
                  pr_default.execute(22, new Object[] {A289DocID, A307DocArqSeq});
                  pr_default.close(22);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1634( ) ;
         Gx_mode = sMode34;
      }

      protected void OnDeleteControls1634( )
      {
         standaloneModal1634( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1634( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanKeyStart1634( )
      {
         /* Scan By routine */
         /* Using cursor BC001625 */
         pr_default.execute(23, new Object[] {A289DocID});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound34 = 1;
            A307DocArqSeq = BC001625_A307DocArqSeq[0];
            A644DocArqArmExterno = BC001625_A644DocArqArmExterno[0];
            A316DocArqDel = BC001625_A316DocArqDel[0];
            A310DocArqInsDataHora = BC001625_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC001625_A308DocArqInsData[0];
            A309DocArqInsHora = BC001625_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC001625_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC001625_n311DocArqInsUsuID[0];
            A312DocArqUpdData = BC001625_A312DocArqUpdData[0];
            n312DocArqUpdData = BC001625_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC001625_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC001625_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC001625_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC001625_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC001625_A315DocArqUsuID[0];
            n315DocArqUsuID = BC001625_n315DocArqUsuID[0];
            A317DocArqDelData = BC001625_A317DocArqDelData[0];
            n317DocArqDelData = BC001625_n317DocArqDelData[0];
            A319DocArqDelDataHora = BC001625_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC001625_n319DocArqDelDataHora[0];
            A320DocArqDelUsuID = BC001625_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC001625_n320DocArqDelUsuID[0];
            A324DocArqObservacao = BC001625_A324DocArqObservacao[0];
            n324DocArqObservacao = BC001625_n324DocArqObservacao[0];
            A645DocArqArmExternoPath = BC001625_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC001625_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC001625_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC001625_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A321DocArqConteudo = BC001625_A321DocArqConteudo[0];
            n321DocArqConteudo = BC001625_n321DocArqConteudo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1634( )
      {
         /* Scan next routine */
         pr_default.readNext(23);
         RcdFound34 = 0;
         ScanKeyLoad1634( ) ;
      }

      protected void ScanKeyLoad1634( )
      {
         sMode34 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(23) != 101) )
         {
            RcdFound34 = 1;
            A307DocArqSeq = BC001625_A307DocArqSeq[0];
            A644DocArqArmExterno = BC001625_A644DocArqArmExterno[0];
            A316DocArqDel = BC001625_A316DocArqDel[0];
            A310DocArqInsDataHora = BC001625_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC001625_A308DocArqInsData[0];
            A309DocArqInsHora = BC001625_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC001625_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC001625_n311DocArqInsUsuID[0];
            A312DocArqUpdData = BC001625_A312DocArqUpdData[0];
            n312DocArqUpdData = BC001625_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC001625_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC001625_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC001625_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC001625_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC001625_A315DocArqUsuID[0];
            n315DocArqUsuID = BC001625_n315DocArqUsuID[0];
            A317DocArqDelData = BC001625_A317DocArqDelData[0];
            n317DocArqDelData = BC001625_n317DocArqDelData[0];
            A319DocArqDelDataHora = BC001625_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC001625_n319DocArqDelDataHora[0];
            A320DocArqDelUsuID = BC001625_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC001625_n320DocArqDelUsuID[0];
            A324DocArqObservacao = BC001625_A324DocArqObservacao[0];
            n324DocArqObservacao = BC001625_n324DocArqObservacao[0];
            A645DocArqArmExternoPath = BC001625_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC001625_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC001625_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC001625_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A321DocArqConteudo = BC001625_A321DocArqConteudo[0];
            n321DocArqConteudo = BC001625_n321DocArqConteudo[0];
         }
         Gx_mode = sMode34;
      }

      protected void ScanKeyEnd1634( )
      {
         pr_default.close(23);
      }

      protected void AfterConfirm1634( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1634( )
      {
         /* Before Insert Rules */
         A310DocArqInsDataHora = DateTimeUtil.NowMS( context);
         A311DocArqInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n311DocArqInsUsuID = false;
         A308DocArqInsData = DateTimeUtil.ResetTime( A310DocArqInsDataHora);
         A309DocArqInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A310DocArqInsDataHora));
      }

      protected void BeforeUpdate1634( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1634( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1634( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1634( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1634( )
      {
      }

      protected void send_integrity_lvl_hashes1634( )
      {
      }

      protected void send_integrity_lvl_hashes1633( )
      {
      }

      protected void AddRow1633( )
      {
         VarsToRow33( bccore_DocumentoEstrutura) ;
      }

      protected void ReadRow1633( )
      {
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
      }

      protected void AddRow1634( )
      {
         GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos obj34;
         obj34 = new GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos(context);
         VarsToRow34( obj34) ;
         bccore_DocumentoEstrutura.gxTpr_Arquivos.Add(obj34, 0);
         obj34.gxTpr_Mode = "UPD";
         obj34.gxTpr_Modified = 0;
      }

      protected void ReadRow1634( )
      {
         nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
         RowToVars34( ((GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos)bccore_DocumentoEstrutura.gxTpr_Arquivos.Item(nGXsfl_34_idx)), 1) ;
      }

      protected void InitializeNonKey1633( )
      {
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A292DocInsData = DateTime.MinValue;
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A295DocInsUsuID = "";
         n295DocInsUsuID = false;
         A325DocVersao = 0;
         A326DocVersaoIDPai = Guid.Empty;
         n326DocVersaoIDPai = false;
         A327DocVersaoNomePai = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A296DocUpdData = DateTime.MinValue;
         n296DocUpdData = false;
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         n297DocUpdHora = false;
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         n298DocUpdDataHora = false;
         A299DocUpdUsuID = "";
         n299DocUpdUsuID = false;
         A301DocDelData = (DateTime)(DateTime.MinValue);
         n301DocDelData = false;
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         n302DocDelHora = false;
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         n303DocDelDataHora = false;
         A304DocDelUsuID = "";
         n304DocDelUsuID = false;
         A305DocNome = "";
         A146DocTipoID = 0;
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         A219DocTipoAtivo = false;
         A306DocUltArqSeq = 0;
         n306DocUltArqSeq = false;
         A300DocDel = false;
         A640DocAtivo = true;
         n640DocAtivo = false;
         A481DocAssinado = false;
         A480DocContrato = false;
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         Z325DocVersao = 0;
         Z290DocOrigem = "";
         Z291DocOrigemID = "";
         Z296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         Z300DocDel = false;
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         Z305DocNome = "";
         Z306DocUltArqSeq = 0;
         Z640DocAtivo = false;
         Z481DocAssinado = false;
         Z480DocContrato = false;
         Z146DocTipoID = 0;
         Z326DocVersaoIDPai = Guid.Empty;
      }

      protected void InitAll1633( )
      {
         A289DocID = Guid.NewGuid( );
         InitializeNonKey1633( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A640DocAtivo = i640DocAtivo;
         n640DocAtivo = false;
         A481DocAssinado = i481DocAssinado;
         A480DocContrato = i480DocContrato;
         A300DocDel = i300DocDel;
      }

      protected void InitializeNonKey1634( )
      {
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A308DocArqInsData = DateTime.MinValue;
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A311DocArqInsUsuID = "";
         n311DocArqInsUsuID = false;
         A312DocArqUpdData = DateTime.MinValue;
         n312DocArqUpdData = false;
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         n313DocArqUpdHora = false;
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         n314DocArqUpdDataHora = false;
         A315DocArqUsuID = "";
         n315DocArqUsuID = false;
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         n317DocArqDelData = false;
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         n319DocArqDelDataHora = false;
         A320DocArqDelUsuID = "";
         n320DocArqDelUsuID = false;
         A321DocArqConteudo = "";
         n321DocArqConteudo = false;
         A324DocArqObservacao = "";
         n324DocArqObservacao = false;
         A645DocArqArmExternoPath = "";
         n645DocArqArmExternoPath = false;
         A323DocArqConteudoExtensao = "";
         A322DocArqConteudoNome = "";
         A644DocArqArmExterno = false;
         A316DocArqDel = false;
         Z644DocArqArmExterno = false;
         Z316DocArqDel = false;
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         Z312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         Z324DocArqObservacao = "";
         Z645DocArqArmExternoPath = "";
      }

      protected void InitAll1634( )
      {
         A307DocArqSeq = 0;
         InitializeNonKey1634( ) ;
      }

      protected void StandaloneModalInsert1634( )
      {
         A306DocUltArqSeq = i306DocUltArqSeq;
         n306DocUltArqSeq = false;
         A644DocArqArmExterno = i644DocArqArmExterno;
         A316DocArqDel = i316DocArqDel;
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

      public void VarsToRow33( GeneXus.Programs.core.SdtDocumentoEstrutura obj33 )
      {
         obj33.gxTpr_Mode = Gx_mode;
         obj33.gxTpr_Docinsdatahora = A294DocInsDataHora;
         obj33.gxTpr_Docinsdata = A292DocInsData;
         obj33.gxTpr_Docinshora = A293DocInsHora;
         obj33.gxTpr_Docinsusuid = A295DocInsUsuID;
         obj33.gxTpr_Docversao = A325DocVersao;
         obj33.gxTpr_Docversaoidpai = A326DocVersaoIDPai;
         obj33.gxTpr_Docversaonomepai = A327DocVersaoNomePai;
         obj33.gxTpr_Docorigem = A290DocOrigem;
         obj33.gxTpr_Docorigemid = A291DocOrigemID;
         obj33.gxTpr_Docupddata = A296DocUpdData;
         obj33.gxTpr_Docupdhora = A297DocUpdHora;
         obj33.gxTpr_Docupddatahora = A298DocUpdDataHora;
         obj33.gxTpr_Docupdusuid = A299DocUpdUsuID;
         obj33.gxTpr_Docdeldata = A301DocDelData;
         obj33.gxTpr_Docdelhora = A302DocDelHora;
         obj33.gxTpr_Docdeldatahora = A303DocDelDataHora;
         obj33.gxTpr_Docdelusuid = A304DocDelUsuID;
         obj33.gxTpr_Docnome = A305DocNome;
         obj33.gxTpr_Doctipoid = A146DocTipoID;
         obj33.gxTpr_Doctiposigla = A147DocTipoSigla;
         obj33.gxTpr_Doctiponome = A148DocTipoNome;
         obj33.gxTpr_Doctipoativo = A219DocTipoAtivo;
         obj33.gxTpr_Docultarqseq = A306DocUltArqSeq;
         obj33.gxTpr_Docdel = A300DocDel;
         obj33.gxTpr_Docativo = A640DocAtivo;
         obj33.gxTpr_Docassinado = A481DocAssinado;
         obj33.gxTpr_Doccontrato = A480DocContrato;
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
         obj33.gxTpr_Docdeldata_Z = Z301DocDelData;
         obj33.gxTpr_Docdelhora_Z = Z302DocDelHora;
         obj33.gxTpr_Docdeldatahora_Z = Z303DocDelDataHora;
         obj33.gxTpr_Docdelusuid_Z = Z304DocDelUsuID;
         obj33.gxTpr_Docnome_Z = Z305DocNome;
         obj33.gxTpr_Doctipoid_Z = Z146DocTipoID;
         obj33.gxTpr_Doctiposigla_Z = Z147DocTipoSigla;
         obj33.gxTpr_Doctiponome_Z = Z148DocTipoNome;
         obj33.gxTpr_Doctipoativo_Z = Z219DocTipoAtivo;
         obj33.gxTpr_Docultarqseq_Z = Z306DocUltArqSeq;
         obj33.gxTpr_Docativo_Z = Z640DocAtivo;
         obj33.gxTpr_Docassinado_Z = Z481DocAssinado;
         obj33.gxTpr_Doccontrato_Z = Z480DocContrato;
         obj33.gxTpr_Docversaoidpai_N = (short)(Convert.ToInt16(n326DocVersaoIDPai));
         obj33.gxTpr_Docinsusuid_N = (short)(Convert.ToInt16(n295DocInsUsuID));
         obj33.gxTpr_Docupddata_N = (short)(Convert.ToInt16(n296DocUpdData));
         obj33.gxTpr_Docupdhora_N = (short)(Convert.ToInt16(n297DocUpdHora));
         obj33.gxTpr_Docupddatahora_N = (short)(Convert.ToInt16(n298DocUpdDataHora));
         obj33.gxTpr_Docupdusuid_N = (short)(Convert.ToInt16(n299DocUpdUsuID));
         obj33.gxTpr_Docdeldata_N = (short)(Convert.ToInt16(n301DocDelData));
         obj33.gxTpr_Docdelhora_N = (short)(Convert.ToInt16(n302DocDelHora));
         obj33.gxTpr_Docdeldatahora_N = (short)(Convert.ToInt16(n303DocDelDataHora));
         obj33.gxTpr_Docdelusuid_N = (short)(Convert.ToInt16(n304DocDelUsuID));
         obj33.gxTpr_Docultarqseq_N = (short)(Convert.ToInt16(n306DocUltArqSeq));
         obj33.gxTpr_Docativo_N = (short)(Convert.ToInt16(n640DocAtivo));
         obj33.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow33( GeneXus.Programs.core.SdtDocumentoEstrutura obj33 )
      {
         obj33.gxTpr_Docid = A289DocID;
         return  ;
      }

      public void RowToVars33( GeneXus.Programs.core.SdtDocumentoEstrutura obj33 ,
                               int forceLoad )
      {
         Gx_mode = obj33.gxTpr_Mode;
         A294DocInsDataHora = obj33.gxTpr_Docinsdatahora;
         A292DocInsData = obj33.gxTpr_Docinsdata;
         A293DocInsHora = obj33.gxTpr_Docinshora;
         A295DocInsUsuID = obj33.gxTpr_Docinsusuid;
         n295DocInsUsuID = false;
         A325DocVersao = obj33.gxTpr_Docversao;
         A326DocVersaoIDPai = obj33.gxTpr_Docversaoidpai;
         n326DocVersaoIDPai = false;
         A327DocVersaoNomePai = obj33.gxTpr_Docversaonomepai;
         A290DocOrigem = obj33.gxTpr_Docorigem;
         A291DocOrigemID = obj33.gxTpr_Docorigemid;
         A296DocUpdData = obj33.gxTpr_Docupddata;
         n296DocUpdData = false;
         A297DocUpdHora = obj33.gxTpr_Docupdhora;
         n297DocUpdHora = false;
         A298DocUpdDataHora = obj33.gxTpr_Docupddatahora;
         n298DocUpdDataHora = false;
         A299DocUpdUsuID = obj33.gxTpr_Docupdusuid;
         n299DocUpdUsuID = false;
         A301DocDelData = obj33.gxTpr_Docdeldata;
         n301DocDelData = false;
         A302DocDelHora = obj33.gxTpr_Docdelhora;
         n302DocDelHora = false;
         A303DocDelDataHora = obj33.gxTpr_Docdeldatahora;
         n303DocDelDataHora = false;
         A304DocDelUsuID = obj33.gxTpr_Docdelusuid;
         n304DocDelUsuID = false;
         A305DocNome = obj33.gxTpr_Docnome;
         A146DocTipoID = obj33.gxTpr_Doctipoid;
         A147DocTipoSigla = obj33.gxTpr_Doctiposigla;
         A148DocTipoNome = obj33.gxTpr_Doctiponome;
         A219DocTipoAtivo = obj33.gxTpr_Doctipoativo;
         if ( forceLoad == 1 )
         {
            A306DocUltArqSeq = obj33.gxTpr_Docultarqseq;
            n306DocUltArqSeq = false;
         }
         A300DocDel = obj33.gxTpr_Docdel;
         A640DocAtivo = obj33.gxTpr_Docativo;
         n640DocAtivo = false;
         A481DocAssinado = obj33.gxTpr_Docassinado;
         A480DocContrato = obj33.gxTpr_Doccontrato;
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
         Z301DocDelData = obj33.gxTpr_Docdeldata_Z;
         Z302DocDelHora = obj33.gxTpr_Docdelhora_Z;
         Z303DocDelDataHora = obj33.gxTpr_Docdeldatahora_Z;
         Z304DocDelUsuID = obj33.gxTpr_Docdelusuid_Z;
         Z305DocNome = obj33.gxTpr_Docnome_Z;
         Z146DocTipoID = obj33.gxTpr_Doctipoid_Z;
         Z147DocTipoSigla = obj33.gxTpr_Doctiposigla_Z;
         Z148DocTipoNome = obj33.gxTpr_Doctiponome_Z;
         Z219DocTipoAtivo = obj33.gxTpr_Doctipoativo_Z;
         Z306DocUltArqSeq = obj33.gxTpr_Docultarqseq_Z;
         O306DocUltArqSeq = obj33.gxTpr_Docultarqseq_Z;
         Z640DocAtivo = obj33.gxTpr_Docativo_Z;
         Z481DocAssinado = obj33.gxTpr_Docassinado_Z;
         Z480DocContrato = obj33.gxTpr_Doccontrato_Z;
         n326DocVersaoIDPai = (bool)(Convert.ToBoolean(obj33.gxTpr_Docversaoidpai_N));
         n295DocInsUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docinsusuid_N));
         n296DocUpdData = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupddata_N));
         n297DocUpdHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupdhora_N));
         n298DocUpdDataHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupddatahora_N));
         n299DocUpdUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docupdusuid_N));
         n301DocDelData = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdeldata_N));
         n302DocDelHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdelhora_N));
         n303DocDelDataHora = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdeldatahora_N));
         n304DocDelUsuID = (bool)(Convert.ToBoolean(obj33.gxTpr_Docdelusuid_N));
         n306DocUltArqSeq = (bool)(Convert.ToBoolean(obj33.gxTpr_Docultarqseq_N));
         n640DocAtivo = (bool)(Convert.ToBoolean(obj33.gxTpr_Docativo_N));
         Gx_mode = obj33.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow34( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos obj34 )
      {
         obj34.gxTpr_Mode = Gx_mode;
         obj34.gxTpr_Docarqinsdatahora = A310DocArqInsDataHora;
         obj34.gxTpr_Docarqinsdata = A308DocArqInsData;
         obj34.gxTpr_Docarqinshora = A309DocArqInsHora;
         obj34.gxTpr_Docarqinsusuid = A311DocArqInsUsuID;
         obj34.gxTpr_Docarqupddata = A312DocArqUpdData;
         obj34.gxTpr_Docarqupdhora = A313DocArqUpdHora;
         obj34.gxTpr_Docarqupddatahora = A314DocArqUpdDataHora;
         obj34.gxTpr_Docarqusuid = A315DocArqUsuID;
         obj34.gxTpr_Docarqdeldata = A317DocArqDelData;
         obj34.gxTpr_Docarqdeldatahora = A319DocArqDelDataHora;
         obj34.gxTpr_Docarqdelusuid = A320DocArqDelUsuID;
         obj34.gxTpr_Docarqconteudo = A321DocArqConteudo;
         obj34.gxTpr_Docarqobservacao = A324DocArqObservacao;
         obj34.gxTpr_Docarqarmexternopath = A645DocArqArmExternoPath;
         obj34.gxTpr_Docarqconteudoextensao = A323DocArqConteudoExtensao;
         obj34.gxTpr_Docarqconteudonome = A322DocArqConteudoNome;
         obj34.gxTpr_Docarqarmexterno = A644DocArqArmExterno;
         obj34.gxTpr_Docarqdel = A316DocArqDel;
         obj34.gxTpr_Docarqseq = A307DocArqSeq;
         obj34.gxTpr_Docarqseq_Z = Z307DocArqSeq;
         obj34.gxTpr_Docarqinsdata_Z = Z308DocArqInsData;
         obj34.gxTpr_Docarqinshora_Z = Z309DocArqInsHora;
         obj34.gxTpr_Docarqinsdatahora_Z = Z310DocArqInsDataHora;
         obj34.gxTpr_Docarqinsusuid_Z = Z311DocArqInsUsuID;
         obj34.gxTpr_Docarqupddata_Z = Z312DocArqUpdData;
         obj34.gxTpr_Docarqupdhora_Z = Z313DocArqUpdHora;
         obj34.gxTpr_Docarqupddatahora_Z = Z314DocArqUpdDataHora;
         obj34.gxTpr_Docarqusuid_Z = Z315DocArqUsuID;
         obj34.gxTpr_Docarqdel_Z = Z316DocArqDel;
         obj34.gxTpr_Docarqdeldata_Z = Z317DocArqDelData;
         obj34.gxTpr_Docarqdeldatahora_Z = Z319DocArqDelDataHora;
         obj34.gxTpr_Docarqdelusuid_Z = Z320DocArqDelUsuID;
         obj34.gxTpr_Docarqconteudonome_Z = Z322DocArqConteudoNome;
         obj34.gxTpr_Docarqconteudoextensao_Z = Z323DocArqConteudoExtensao;
         obj34.gxTpr_Docarqobservacao_Z = Z324DocArqObservacao;
         obj34.gxTpr_Docarqarmexterno_Z = Z644DocArqArmExterno;
         obj34.gxTpr_Docarqarmexternopath_Z = Z645DocArqArmExternoPath;
         obj34.gxTpr_Docarqinsusuid_N = (short)(Convert.ToInt16(n311DocArqInsUsuID));
         obj34.gxTpr_Docarqupddata_N = (short)(Convert.ToInt16(n312DocArqUpdData));
         obj34.gxTpr_Docarqupdhora_N = (short)(Convert.ToInt16(n313DocArqUpdHora));
         obj34.gxTpr_Docarqupddatahora_N = (short)(Convert.ToInt16(n314DocArqUpdDataHora));
         obj34.gxTpr_Docarqusuid_N = (short)(Convert.ToInt16(n315DocArqUsuID));
         obj34.gxTpr_Docarqdeldata_N = (short)(Convert.ToInt16(n317DocArqDelData));
         obj34.gxTpr_Docarqdeldatahora_N = (short)(Convert.ToInt16(n319DocArqDelDataHora));
         obj34.gxTpr_Docarqdelusuid_N = (short)(Convert.ToInt16(n320DocArqDelUsuID));
         obj34.gxTpr_Docarqconteudo_N = (short)(Convert.ToInt16(n321DocArqConteudo));
         obj34.gxTpr_Docarqobservacao_N = (short)(Convert.ToInt16(n324DocArqObservacao));
         obj34.gxTpr_Docarqarmexternopath_N = (short)(Convert.ToInt16(n645DocArqArmExternoPath));
         obj34.gxTpr_Modified = nIsMod_34;
         return  ;
      }

      public void KeyVarsToRow34( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos obj34 )
      {
         obj34.gxTpr_Docarqseq = A307DocArqSeq;
         return  ;
      }

      public void RowToVars34( GeneXus.Programs.core.SdtDocumentoEstrutura_Arquivos obj34 ,
                               int forceLoad )
      {
         Gx_mode = obj34.gxTpr_Mode;
         A310DocArqInsDataHora = obj34.gxTpr_Docarqinsdatahora;
         A308DocArqInsData = obj34.gxTpr_Docarqinsdata;
         A309DocArqInsHora = obj34.gxTpr_Docarqinshora;
         A311DocArqInsUsuID = obj34.gxTpr_Docarqinsusuid;
         n311DocArqInsUsuID = false;
         A312DocArqUpdData = obj34.gxTpr_Docarqupddata;
         n312DocArqUpdData = false;
         A313DocArqUpdHora = obj34.gxTpr_Docarqupdhora;
         n313DocArqUpdHora = false;
         A314DocArqUpdDataHora = obj34.gxTpr_Docarqupddatahora;
         n314DocArqUpdDataHora = false;
         A315DocArqUsuID = obj34.gxTpr_Docarqusuid;
         n315DocArqUsuID = false;
         A317DocArqDelData = obj34.gxTpr_Docarqdeldata;
         n317DocArqDelData = false;
         A319DocArqDelDataHora = obj34.gxTpr_Docarqdeldatahora;
         n319DocArqDelDataHora = false;
         A320DocArqDelUsuID = obj34.gxTpr_Docarqdelusuid;
         n320DocArqDelUsuID = false;
         A321DocArqConteudo = obj34.gxTpr_Docarqconteudo;
         n321DocArqConteudo = false;
         A324DocArqObservacao = obj34.gxTpr_Docarqobservacao;
         n324DocArqObservacao = false;
         A645DocArqArmExternoPath = obj34.gxTpr_Docarqarmexternopath;
         n645DocArqArmExternoPath = false;
         A323DocArqConteudoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( obj34.gxTpr_Docarqconteudoextensao)) ? FileUtil.GetFileType( A321DocArqConteudo) : obj34.gxTpr_Docarqconteudoextensao);
         A322DocArqConteudoNome = (String.IsNullOrEmpty(StringUtil.RTrim( obj34.gxTpr_Docarqconteudonome)) ? FileUtil.GetFileName( A321DocArqConteudo) : obj34.gxTpr_Docarqconteudonome);
         A644DocArqArmExterno = obj34.gxTpr_Docarqarmexterno;
         A316DocArqDel = obj34.gxTpr_Docarqdel;
         A307DocArqSeq = obj34.gxTpr_Docarqseq;
         Z307DocArqSeq = obj34.gxTpr_Docarqseq_Z;
         Z308DocArqInsData = obj34.gxTpr_Docarqinsdata_Z;
         Z309DocArqInsHora = obj34.gxTpr_Docarqinshora_Z;
         Z310DocArqInsDataHora = obj34.gxTpr_Docarqinsdatahora_Z;
         Z311DocArqInsUsuID = obj34.gxTpr_Docarqinsusuid_Z;
         Z312DocArqUpdData = obj34.gxTpr_Docarqupddata_Z;
         Z313DocArqUpdHora = obj34.gxTpr_Docarqupdhora_Z;
         Z314DocArqUpdDataHora = obj34.gxTpr_Docarqupddatahora_Z;
         Z315DocArqUsuID = obj34.gxTpr_Docarqusuid_Z;
         Z316DocArqDel = obj34.gxTpr_Docarqdel_Z;
         Z317DocArqDelData = obj34.gxTpr_Docarqdeldata_Z;
         Z319DocArqDelDataHora = obj34.gxTpr_Docarqdeldatahora_Z;
         Z320DocArqDelUsuID = obj34.gxTpr_Docarqdelusuid_Z;
         Z322DocArqConteudoNome = obj34.gxTpr_Docarqconteudonome_Z;
         Z323DocArqConteudoExtensao = obj34.gxTpr_Docarqconteudoextensao_Z;
         Z324DocArqObservacao = obj34.gxTpr_Docarqobservacao_Z;
         Z644DocArqArmExterno = obj34.gxTpr_Docarqarmexterno_Z;
         Z645DocArqArmExternoPath = obj34.gxTpr_Docarqarmexternopath_Z;
         n311DocArqInsUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqinsusuid_N));
         n312DocArqUpdData = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupddata_N));
         n313DocArqUpdHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupdhora_N));
         n314DocArqUpdDataHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupddatahora_N));
         n315DocArqUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqusuid_N));
         n317DocArqDelData = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdeldata_N));
         n319DocArqDelDataHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdeldatahora_N));
         n320DocArqDelUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdelusuid_N));
         n321DocArqConteudo = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqconteudo_N));
         n324DocArqObservacao = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqobservacao_N));
         n645DocArqArmExternoPath = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqarmexternopath_N));
         nIsMod_34 = obj34.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A289DocID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1633( ) ;
         ScanKeyStart1633( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         ZM1633( -29) ;
         OnLoadActions1633( ) ;
         AddRow1633( ) ;
         bccore_DocumentoEstrutura.gxTpr_Arquivos.ClearCollection();
         if ( RcdFound33 == 1 )
         {
            ScanKeyStart1634( ) ;
            nGXsfl_34_idx = 1;
            while ( RcdFound34 != 0 )
            {
               Z289DocID = A289DocID;
               Z307DocArqSeq = A307DocArqSeq;
               ZM1634( -33) ;
               OnLoadActions1634( ) ;
               nRcdExists_34 = 1;
               nIsMod_34 = 0;
               AddRow1634( ) ;
               nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
               ScanKeyNext1634( ) ;
            }
            ScanKeyEnd1634( ) ;
         }
         ScanKeyEnd1633( ) ;
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
         RowToVars33( bccore_DocumentoEstrutura, 0) ;
         ScanKeyStart1633( ) ;
         if ( RcdFound33 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         ZM1633( -29) ;
         OnLoadActions1633( ) ;
         AddRow1633( ) ;
         bccore_DocumentoEstrutura.gxTpr_Arquivos.ClearCollection();
         if ( RcdFound33 == 1 )
         {
            ScanKeyStart1634( ) ;
            nGXsfl_34_idx = 1;
            while ( RcdFound34 != 0 )
            {
               Z289DocID = A289DocID;
               Z307DocArqSeq = A307DocArqSeq;
               ZM1634( -33) ;
               OnLoadActions1634( ) ;
               nRcdExists_34 = 1;
               nIsMod_34 = 0;
               AddRow1634( ) ;
               nGXsfl_34_idx = (int)(nGXsfl_34_idx+1);
               ScanKeyNext1634( ) ;
            }
            ScanKeyEnd1634( ) ;
         }
         ScanKeyEnd1633( ) ;
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
         GetKey1633( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            A306DocUltArqSeq = O306DocUltArqSeq;
            n306DocUltArqSeq = false;
            Insert1633( ) ;
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
                  A306DocUltArqSeq = O306DocUltArqSeq;
                  n306DocUltArqSeq = false;
                  delete( ) ;
                  AfterTrn( ) ;
               }
               else
               {
                  Gx_mode = "UPD";
                  /* Update record */
                  A306DocUltArqSeq = O306DocUltArqSeq;
                  n306DocUltArqSeq = false;
                  Update1633( ) ;
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
                        A306DocUltArqSeq = O306DocUltArqSeq;
                        n306DocUltArqSeq = false;
                        Insert1633( ) ;
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
                        A306DocUltArqSeq = O306DocUltArqSeq;
                        n306DocUltArqSeq = false;
                        Insert1633( ) ;
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
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
         SaveImpl( ) ;
         VarsToRow33( bccore_DocumentoEstrutura) ;
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
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         A306DocUltArqSeq = O306DocUltArqSeq;
         n306DocUltArqSeq = false;
         Insert1633( ) ;
         AfterTrn( ) ;
         VarsToRow33( bccore_DocumentoEstrutura) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow33( bccore_DocumentoEstrutura) ;
         }
         else
         {
            GeneXus.Programs.core.SdtDocumentoEstrutura auxBC = new GeneXus.Programs.core.SdtDocumentoEstrutura(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A289DocID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_DocumentoEstrutura);
               auxBC.Save();
               bccore_DocumentoEstrutura.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
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
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1633( ) ;
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
               VarsToRow33( bccore_DocumentoEstrutura) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow33( bccore_DocumentoEstrutura) ;
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
         RowToVars33( bccore_DocumentoEstrutura, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1633( ) ;
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
         context.RollbackDataStores("core.documentoestrutura_bc",pr_default);
         VarsToRow33( bccore_DocumentoEstrutura) ;
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
         Gx_mode = bccore_DocumentoEstrutura.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_DocumentoEstrutura.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_DocumentoEstrutura )
         {
            bccore_DocumentoEstrutura = (GeneXus.Programs.core.SdtDocumentoEstrutura)(sdt);
            if ( StringUtil.StrCmp(bccore_DocumentoEstrutura.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoEstrutura.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow33( bccore_DocumentoEstrutura) ;
            }
            else
            {
               RowToVars33( bccore_DocumentoEstrutura, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_DocumentoEstrutura.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoEstrutura.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars33( bccore_DocumentoEstrutura, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocumentoEstrutura DocumentoEstrutura_BC
      {
         get {
            return bccore_DocumentoEstrutura ;
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
         pr_default.close(3);
         pr_default.close(13);
         pr_default.close(12);
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
         sMode33 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV26Pgmname = "";
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV13Insert_DocVersaoIDPai = Guid.Empty;
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         A292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         A295DocInsUsuID = "";
         Z290DocOrigem = "";
         A290DocOrigem = "";
         Z291DocOrigemID = "";
         A291DocOrigemID = "";
         Z296DocUpdData = DateTime.MinValue;
         A296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         A299DocUpdUsuID = "";
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         A301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         A304DocDelUsuID = "";
         Z305DocNome = "";
         A305DocNome = "";
         Z326DocVersaoIDPai = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         Z147DocTipoSigla = "";
         A147DocTipoSigla = "";
         Z148DocTipoNome = "";
         A148DocTipoNome = "";
         Z327DocVersaoNomePai = "";
         A327DocVersaoNomePai = "";
         BC00168_A289DocID = new Guid[] {Guid.Empty} ;
         BC00168_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC00168_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_A295DocInsUsuID = new string[] {""} ;
         BC00168_n295DocInsUsuID = new bool[] {false} ;
         BC00168_A325DocVersao = new short[1] ;
         BC00168_A327DocVersaoNomePai = new string[] {""} ;
         BC00168_A290DocOrigem = new string[] {""} ;
         BC00168_A291DocOrigemID = new string[] {""} ;
         BC00168_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00168_n296DocUpdData = new bool[] {false} ;
         BC00168_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_n297DocUpdHora = new bool[] {false} ;
         BC00168_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_n298DocUpdDataHora = new bool[] {false} ;
         BC00168_A299DocUpdUsuID = new string[] {""} ;
         BC00168_n299DocUpdUsuID = new bool[] {false} ;
         BC00168_A300DocDel = new bool[] {false} ;
         BC00168_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC00168_n301DocDelData = new bool[] {false} ;
         BC00168_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_n302DocDelHora = new bool[] {false} ;
         BC00168_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00168_n303DocDelDataHora = new bool[] {false} ;
         BC00168_A304DocDelUsuID = new string[] {""} ;
         BC00168_n304DocDelUsuID = new bool[] {false} ;
         BC00168_A305DocNome = new string[] {""} ;
         BC00168_A147DocTipoSigla = new string[] {""} ;
         BC00168_A148DocTipoNome = new string[] {""} ;
         BC00168_A219DocTipoAtivo = new bool[] {false} ;
         BC00168_A306DocUltArqSeq = new short[1] ;
         BC00168_n306DocUltArqSeq = new bool[] {false} ;
         BC00168_A640DocAtivo = new bool[] {false} ;
         BC00168_n640DocAtivo = new bool[] {false} ;
         BC00168_A481DocAssinado = new bool[] {false} ;
         BC00168_A480DocContrato = new bool[] {false} ;
         BC00168_A146DocTipoID = new int[1] ;
         BC00168_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00168_n326DocVersaoIDPai = new bool[] {false} ;
         BC00169_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00169_n326DocVersaoIDPai = new bool[] {false} ;
         BC00167_A327DocVersaoNomePai = new string[] {""} ;
         BC00166_A147DocTipoSigla = new string[] {""} ;
         BC00166_A148DocTipoNome = new string[] {""} ;
         BC00166_A219DocTipoAtivo = new bool[] {false} ;
         BC001610_A289DocID = new Guid[] {Guid.Empty} ;
         BC00165_A289DocID = new Guid[] {Guid.Empty} ;
         BC00165_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC00165_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_A295DocInsUsuID = new string[] {""} ;
         BC00165_n295DocInsUsuID = new bool[] {false} ;
         BC00165_A325DocVersao = new short[1] ;
         BC00165_A290DocOrigem = new string[] {""} ;
         BC00165_A291DocOrigemID = new string[] {""} ;
         BC00165_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00165_n296DocUpdData = new bool[] {false} ;
         BC00165_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_n297DocUpdHora = new bool[] {false} ;
         BC00165_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_n298DocUpdDataHora = new bool[] {false} ;
         BC00165_A299DocUpdUsuID = new string[] {""} ;
         BC00165_n299DocUpdUsuID = new bool[] {false} ;
         BC00165_A300DocDel = new bool[] {false} ;
         BC00165_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC00165_n301DocDelData = new bool[] {false} ;
         BC00165_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_n302DocDelHora = new bool[] {false} ;
         BC00165_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00165_n303DocDelDataHora = new bool[] {false} ;
         BC00165_A304DocDelUsuID = new string[] {""} ;
         BC00165_n304DocDelUsuID = new bool[] {false} ;
         BC00165_A305DocNome = new string[] {""} ;
         BC00165_A306DocUltArqSeq = new short[1] ;
         BC00165_n306DocUltArqSeq = new bool[] {false} ;
         BC00165_A640DocAtivo = new bool[] {false} ;
         BC00165_n640DocAtivo = new bool[] {false} ;
         BC00165_A481DocAssinado = new bool[] {false} ;
         BC00165_A480DocContrato = new bool[] {false} ;
         BC00165_A146DocTipoID = new int[1] ;
         BC00165_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00165_n326DocVersaoIDPai = new bool[] {false} ;
         BC00164_A289DocID = new Guid[] {Guid.Empty} ;
         BC00164_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC00164_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_A295DocInsUsuID = new string[] {""} ;
         BC00164_n295DocInsUsuID = new bool[] {false} ;
         BC00164_A325DocVersao = new short[1] ;
         BC00164_A290DocOrigem = new string[] {""} ;
         BC00164_A291DocOrigemID = new string[] {""} ;
         BC00164_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00164_n296DocUpdData = new bool[] {false} ;
         BC00164_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_n297DocUpdHora = new bool[] {false} ;
         BC00164_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_n298DocUpdDataHora = new bool[] {false} ;
         BC00164_A299DocUpdUsuID = new string[] {""} ;
         BC00164_n299DocUpdUsuID = new bool[] {false} ;
         BC00164_A300DocDel = new bool[] {false} ;
         BC00164_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC00164_n301DocDelData = new bool[] {false} ;
         BC00164_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_n302DocDelHora = new bool[] {false} ;
         BC00164_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00164_n303DocDelDataHora = new bool[] {false} ;
         BC00164_A304DocDelUsuID = new string[] {""} ;
         BC00164_n304DocDelUsuID = new bool[] {false} ;
         BC00164_A305DocNome = new string[] {""} ;
         BC00164_A306DocUltArqSeq = new short[1] ;
         BC00164_n306DocUltArqSeq = new bool[] {false} ;
         BC00164_A640DocAtivo = new bool[] {false} ;
         BC00164_n640DocAtivo = new bool[] {false} ;
         BC00164_A481DocAssinado = new bool[] {false} ;
         BC00164_A480DocContrato = new bool[] {false} ;
         BC00164_A146DocTipoID = new int[1] ;
         BC00164_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00164_n326DocVersaoIDPai = new bool[] {false} ;
         BC001614_A327DocVersaoNomePai = new string[] {""} ;
         BC001615_A147DocTipoSigla = new string[] {""} ;
         BC001615_A148DocTipoNome = new string[] {""} ;
         BC001615_A219DocTipoAtivo = new bool[] {false} ;
         BC001616_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC001616_n326DocVersaoIDPai = new bool[] {false} ;
         BC001618_A289DocID = new Guid[] {Guid.Empty} ;
         BC001618_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         BC001618_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_A295DocInsUsuID = new string[] {""} ;
         BC001618_n295DocInsUsuID = new bool[] {false} ;
         BC001618_A325DocVersao = new short[1] ;
         BC001618_A327DocVersaoNomePai = new string[] {""} ;
         BC001618_A290DocOrigem = new string[] {""} ;
         BC001618_A291DocOrigemID = new string[] {""} ;
         BC001618_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001618_n296DocUpdData = new bool[] {false} ;
         BC001618_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_n297DocUpdHora = new bool[] {false} ;
         BC001618_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_n298DocUpdDataHora = new bool[] {false} ;
         BC001618_A299DocUpdUsuID = new string[] {""} ;
         BC001618_n299DocUpdUsuID = new bool[] {false} ;
         BC001618_A300DocDel = new bool[] {false} ;
         BC001618_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         BC001618_n301DocDelData = new bool[] {false} ;
         BC001618_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_n302DocDelHora = new bool[] {false} ;
         BC001618_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001618_n303DocDelDataHora = new bool[] {false} ;
         BC001618_A304DocDelUsuID = new string[] {""} ;
         BC001618_n304DocDelUsuID = new bool[] {false} ;
         BC001618_A305DocNome = new string[] {""} ;
         BC001618_A147DocTipoSigla = new string[] {""} ;
         BC001618_A148DocTipoNome = new string[] {""} ;
         BC001618_A219DocTipoAtivo = new bool[] {false} ;
         BC001618_A306DocUltArqSeq = new short[1] ;
         BC001618_n306DocUltArqSeq = new bool[] {false} ;
         BC001618_A640DocAtivo = new bool[] {false} ;
         BC001618_n640DocAtivo = new bool[] {false} ;
         BC001618_A481DocAssinado = new bool[] {false} ;
         BC001618_A480DocContrato = new bool[] {false} ;
         BC001618_A146DocTipoID = new int[1] ;
         BC001618_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC001618_n326DocVersaoIDPai = new bool[] {false} ;
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         A308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         A311DocArqInsUsuID = "";
         Z312DocArqUpdData = DateTime.MinValue;
         A312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         A315DocArqUsuID = "";
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         A320DocArqDelUsuID = "";
         Z324DocArqObservacao = "";
         A324DocArqObservacao = "";
         Z645DocArqArmExternoPath = "";
         A645DocArqArmExternoPath = "";
         Z321DocArqConteudo = "";
         A321DocArqConteudo = "";
         Z323DocArqConteudoExtensao = "";
         A323DocArqConteudoExtensao = "";
         Z322DocArqConteudoNome = "";
         A322DocArqConteudoNome = "";
         BC001619_A289DocID = new Guid[] {Guid.Empty} ;
         BC001619_A307DocArqSeq = new short[1] ;
         BC001619_A644DocArqArmExterno = new bool[] {false} ;
         BC001619_A316DocArqDel = new bool[] {false} ;
         BC001619_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001619_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC001619_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001619_A311DocArqInsUsuID = new string[] {""} ;
         BC001619_n311DocArqInsUsuID = new bool[] {false} ;
         BC001619_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001619_n312DocArqUpdData = new bool[] {false} ;
         BC001619_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001619_n313DocArqUpdHora = new bool[] {false} ;
         BC001619_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001619_n314DocArqUpdDataHora = new bool[] {false} ;
         BC001619_A315DocArqUsuID = new string[] {""} ;
         BC001619_n315DocArqUsuID = new bool[] {false} ;
         BC001619_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC001619_n317DocArqDelData = new bool[] {false} ;
         BC001619_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001619_n319DocArqDelDataHora = new bool[] {false} ;
         BC001619_A320DocArqDelUsuID = new string[] {""} ;
         BC001619_n320DocArqDelUsuID = new bool[] {false} ;
         BC001619_A324DocArqObservacao = new string[] {""} ;
         BC001619_n324DocArqObservacao = new bool[] {false} ;
         BC001619_A645DocArqArmExternoPath = new string[] {""} ;
         BC001619_n645DocArqArmExternoPath = new bool[] {false} ;
         BC001619_A323DocArqConteudoExtensao = new string[] {""} ;
         BC001619_A322DocArqConteudoNome = new string[] {""} ;
         BC001619_A321DocArqConteudo = new string[] {""} ;
         BC001619_n321DocArqConteudo = new bool[] {false} ;
         A321DocArqConteudo_Filetype = "";
         A321DocArqConteudo_Filename = "";
         BC001620_A289DocID = new Guid[] {Guid.Empty} ;
         BC001620_A307DocArqSeq = new short[1] ;
         BC00163_A289DocID = new Guid[] {Guid.Empty} ;
         BC00163_A307DocArqSeq = new short[1] ;
         BC00163_A644DocArqArmExterno = new bool[] {false} ;
         BC00163_A316DocArqDel = new bool[] {false} ;
         BC00163_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00163_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC00163_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00163_A311DocArqInsUsuID = new string[] {""} ;
         BC00163_n311DocArqInsUsuID = new bool[] {false} ;
         BC00163_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00163_n312DocArqUpdData = new bool[] {false} ;
         BC00163_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00163_n313DocArqUpdHora = new bool[] {false} ;
         BC00163_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00163_n314DocArqUpdDataHora = new bool[] {false} ;
         BC00163_A315DocArqUsuID = new string[] {""} ;
         BC00163_n315DocArqUsuID = new bool[] {false} ;
         BC00163_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC00163_n317DocArqDelData = new bool[] {false} ;
         BC00163_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00163_n319DocArqDelDataHora = new bool[] {false} ;
         BC00163_A320DocArqDelUsuID = new string[] {""} ;
         BC00163_n320DocArqDelUsuID = new bool[] {false} ;
         BC00163_A324DocArqObservacao = new string[] {""} ;
         BC00163_n324DocArqObservacao = new bool[] {false} ;
         BC00163_A645DocArqArmExternoPath = new string[] {""} ;
         BC00163_n645DocArqArmExternoPath = new bool[] {false} ;
         BC00163_A323DocArqConteudoExtensao = new string[] {""} ;
         BC00163_A322DocArqConteudoNome = new string[] {""} ;
         BC00163_A321DocArqConteudo = new string[] {""} ;
         BC00163_n321DocArqConteudo = new bool[] {false} ;
         sMode34 = "";
         BC00162_A289DocID = new Guid[] {Guid.Empty} ;
         BC00162_A307DocArqSeq = new short[1] ;
         BC00162_A644DocArqArmExterno = new bool[] {false} ;
         BC00162_A316DocArqDel = new bool[] {false} ;
         BC00162_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00162_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC00162_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00162_A311DocArqInsUsuID = new string[] {""} ;
         BC00162_n311DocArqInsUsuID = new bool[] {false} ;
         BC00162_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00162_n312DocArqUpdData = new bool[] {false} ;
         BC00162_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00162_n313DocArqUpdHora = new bool[] {false} ;
         BC00162_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00162_n314DocArqUpdDataHora = new bool[] {false} ;
         BC00162_A315DocArqUsuID = new string[] {""} ;
         BC00162_n315DocArqUsuID = new bool[] {false} ;
         BC00162_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC00162_n317DocArqDelData = new bool[] {false} ;
         BC00162_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00162_n319DocArqDelDataHora = new bool[] {false} ;
         BC00162_A320DocArqDelUsuID = new string[] {""} ;
         BC00162_n320DocArqDelUsuID = new bool[] {false} ;
         BC00162_A324DocArqObservacao = new string[] {""} ;
         BC00162_n324DocArqObservacao = new bool[] {false} ;
         BC00162_A645DocArqArmExternoPath = new string[] {""} ;
         BC00162_n645DocArqArmExternoPath = new bool[] {false} ;
         BC00162_A323DocArqConteudoExtensao = new string[] {""} ;
         BC00162_A322DocArqConteudoNome = new string[] {""} ;
         BC00162_A321DocArqConteudo = new string[] {""} ;
         BC00162_n321DocArqConteudo = new bool[] {false} ;
         BC001625_A289DocID = new Guid[] {Guid.Empty} ;
         BC001625_A307DocArqSeq = new short[1] ;
         BC001625_A644DocArqArmExterno = new bool[] {false} ;
         BC001625_A316DocArqDel = new bool[] {false} ;
         BC001625_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001625_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC001625_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001625_A311DocArqInsUsuID = new string[] {""} ;
         BC001625_n311DocArqInsUsuID = new bool[] {false} ;
         BC001625_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001625_n312DocArqUpdData = new bool[] {false} ;
         BC001625_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001625_n313DocArqUpdHora = new bool[] {false} ;
         BC001625_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001625_n314DocArqUpdDataHora = new bool[] {false} ;
         BC001625_A315DocArqUsuID = new string[] {""} ;
         BC001625_n315DocArqUsuID = new bool[] {false} ;
         BC001625_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC001625_n317DocArqDelData = new bool[] {false} ;
         BC001625_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001625_n319DocArqDelDataHora = new bool[] {false} ;
         BC001625_A320DocArqDelUsuID = new string[] {""} ;
         BC001625_n320DocArqDelUsuID = new bool[] {false} ;
         BC001625_A324DocArqObservacao = new string[] {""} ;
         BC001625_n324DocArqObservacao = new bool[] {false} ;
         BC001625_A645DocArqArmExternoPath = new string[] {""} ;
         BC001625_n645DocArqArmExternoPath = new bool[] {false} ;
         BC001625_A323DocArqConteudoExtensao = new string[] {""} ;
         BC001625_A322DocArqConteudoNome = new string[] {""} ;
         BC001625_A321DocArqConteudo = new string[] {""} ;
         BC001625_n321DocArqConteudo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documentoestrutura_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoestrutura_bc__default(),
            new Object[][] {
                new Object[] {
               BC00162_A289DocID, BC00162_A307DocArqSeq, BC00162_A644DocArqArmExterno, BC00162_A316DocArqDel, BC00162_A310DocArqInsDataHora, BC00162_A308DocArqInsData, BC00162_A309DocArqInsHora, BC00162_A311DocArqInsUsuID, BC00162_n311DocArqInsUsuID, BC00162_A312DocArqUpdData,
               BC00162_n312DocArqUpdData, BC00162_A313DocArqUpdHora, BC00162_n313DocArqUpdHora, BC00162_A314DocArqUpdDataHora, BC00162_n314DocArqUpdDataHora, BC00162_A315DocArqUsuID, BC00162_n315DocArqUsuID, BC00162_A317DocArqDelData, BC00162_n317DocArqDelData, BC00162_A319DocArqDelDataHora,
               BC00162_n319DocArqDelDataHora, BC00162_A320DocArqDelUsuID, BC00162_n320DocArqDelUsuID, BC00162_A324DocArqObservacao, BC00162_n324DocArqObservacao, BC00162_A645DocArqArmExternoPath, BC00162_n645DocArqArmExternoPath, BC00162_A323DocArqConteudoExtensao, BC00162_A322DocArqConteudoNome, BC00162_A321DocArqConteudo,
               BC00162_n321DocArqConteudo
               }
               , new Object[] {
               BC00163_A289DocID, BC00163_A307DocArqSeq, BC00163_A644DocArqArmExterno, BC00163_A316DocArqDel, BC00163_A310DocArqInsDataHora, BC00163_A308DocArqInsData, BC00163_A309DocArqInsHora, BC00163_A311DocArqInsUsuID, BC00163_n311DocArqInsUsuID, BC00163_A312DocArqUpdData,
               BC00163_n312DocArqUpdData, BC00163_A313DocArqUpdHora, BC00163_n313DocArqUpdHora, BC00163_A314DocArqUpdDataHora, BC00163_n314DocArqUpdDataHora, BC00163_A315DocArqUsuID, BC00163_n315DocArqUsuID, BC00163_A317DocArqDelData, BC00163_n317DocArqDelData, BC00163_A319DocArqDelDataHora,
               BC00163_n319DocArqDelDataHora, BC00163_A320DocArqDelUsuID, BC00163_n320DocArqDelUsuID, BC00163_A324DocArqObservacao, BC00163_n324DocArqObservacao, BC00163_A645DocArqArmExternoPath, BC00163_n645DocArqArmExternoPath, BC00163_A323DocArqConteudoExtensao, BC00163_A322DocArqConteudoNome, BC00163_A321DocArqConteudo,
               BC00163_n321DocArqConteudo
               }
               , new Object[] {
               BC00164_A289DocID, BC00164_A294DocInsDataHora, BC00164_A292DocInsData, BC00164_A293DocInsHora, BC00164_A295DocInsUsuID, BC00164_n295DocInsUsuID, BC00164_A325DocVersao, BC00164_A290DocOrigem, BC00164_A291DocOrigemID, BC00164_A296DocUpdData,
               BC00164_n296DocUpdData, BC00164_A297DocUpdHora, BC00164_n297DocUpdHora, BC00164_A298DocUpdDataHora, BC00164_n298DocUpdDataHora, BC00164_A299DocUpdUsuID, BC00164_n299DocUpdUsuID, BC00164_A300DocDel, BC00164_A301DocDelData, BC00164_n301DocDelData,
               BC00164_A302DocDelHora, BC00164_n302DocDelHora, BC00164_A303DocDelDataHora, BC00164_n303DocDelDataHora, BC00164_A304DocDelUsuID, BC00164_n304DocDelUsuID, BC00164_A305DocNome, BC00164_A306DocUltArqSeq, BC00164_n306DocUltArqSeq, BC00164_A640DocAtivo,
               BC00164_n640DocAtivo, BC00164_A481DocAssinado, BC00164_A480DocContrato, BC00164_A146DocTipoID, BC00164_A326DocVersaoIDPai, BC00164_n326DocVersaoIDPai
               }
               , new Object[] {
               BC00165_A289DocID, BC00165_A294DocInsDataHora, BC00165_A292DocInsData, BC00165_A293DocInsHora, BC00165_A295DocInsUsuID, BC00165_n295DocInsUsuID, BC00165_A325DocVersao, BC00165_A290DocOrigem, BC00165_A291DocOrigemID, BC00165_A296DocUpdData,
               BC00165_n296DocUpdData, BC00165_A297DocUpdHora, BC00165_n297DocUpdHora, BC00165_A298DocUpdDataHora, BC00165_n298DocUpdDataHora, BC00165_A299DocUpdUsuID, BC00165_n299DocUpdUsuID, BC00165_A300DocDel, BC00165_A301DocDelData, BC00165_n301DocDelData,
               BC00165_A302DocDelHora, BC00165_n302DocDelHora, BC00165_A303DocDelDataHora, BC00165_n303DocDelDataHora, BC00165_A304DocDelUsuID, BC00165_n304DocDelUsuID, BC00165_A305DocNome, BC00165_A306DocUltArqSeq, BC00165_n306DocUltArqSeq, BC00165_A640DocAtivo,
               BC00165_n640DocAtivo, BC00165_A481DocAssinado, BC00165_A480DocContrato, BC00165_A146DocTipoID, BC00165_A326DocVersaoIDPai, BC00165_n326DocVersaoIDPai
               }
               , new Object[] {
               BC00166_A147DocTipoSigla, BC00166_A148DocTipoNome, BC00166_A219DocTipoAtivo
               }
               , new Object[] {
               BC00167_A327DocVersaoNomePai
               }
               , new Object[] {
               BC00168_A289DocID, BC00168_A294DocInsDataHora, BC00168_A292DocInsData, BC00168_A293DocInsHora, BC00168_A295DocInsUsuID, BC00168_n295DocInsUsuID, BC00168_A325DocVersao, BC00168_A327DocVersaoNomePai, BC00168_A290DocOrigem, BC00168_A291DocOrigemID,
               BC00168_A296DocUpdData, BC00168_n296DocUpdData, BC00168_A297DocUpdHora, BC00168_n297DocUpdHora, BC00168_A298DocUpdDataHora, BC00168_n298DocUpdDataHora, BC00168_A299DocUpdUsuID, BC00168_n299DocUpdUsuID, BC00168_A300DocDel, BC00168_A301DocDelData,
               BC00168_n301DocDelData, BC00168_A302DocDelHora, BC00168_n302DocDelHora, BC00168_A303DocDelDataHora, BC00168_n303DocDelDataHora, BC00168_A304DocDelUsuID, BC00168_n304DocDelUsuID, BC00168_A305DocNome, BC00168_A147DocTipoSigla, BC00168_A148DocTipoNome,
               BC00168_A219DocTipoAtivo, BC00168_A306DocUltArqSeq, BC00168_n306DocUltArqSeq, BC00168_A640DocAtivo, BC00168_n640DocAtivo, BC00168_A481DocAssinado, BC00168_A480DocContrato, BC00168_A146DocTipoID, BC00168_A326DocVersaoIDPai, BC00168_n326DocVersaoIDPai
               }
               , new Object[] {
               BC00169_A326DocVersaoIDPai, BC00169_n326DocVersaoIDPai
               }
               , new Object[] {
               BC001610_A289DocID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001614_A327DocVersaoNomePai
               }
               , new Object[] {
               BC001615_A147DocTipoSigla, BC001615_A148DocTipoNome, BC001615_A219DocTipoAtivo
               }
               , new Object[] {
               BC001616_A326DocVersaoIDPai
               }
               , new Object[] {
               }
               , new Object[] {
               BC001618_A289DocID, BC001618_A294DocInsDataHora, BC001618_A292DocInsData, BC001618_A293DocInsHora, BC001618_A295DocInsUsuID, BC001618_n295DocInsUsuID, BC001618_A325DocVersao, BC001618_A327DocVersaoNomePai, BC001618_A290DocOrigem, BC001618_A291DocOrigemID,
               BC001618_A296DocUpdData, BC001618_n296DocUpdData, BC001618_A297DocUpdHora, BC001618_n297DocUpdHora, BC001618_A298DocUpdDataHora, BC001618_n298DocUpdDataHora, BC001618_A299DocUpdUsuID, BC001618_n299DocUpdUsuID, BC001618_A300DocDel, BC001618_A301DocDelData,
               BC001618_n301DocDelData, BC001618_A302DocDelHora, BC001618_n302DocDelHora, BC001618_A303DocDelDataHora, BC001618_n303DocDelDataHora, BC001618_A304DocDelUsuID, BC001618_n304DocDelUsuID, BC001618_A305DocNome, BC001618_A147DocTipoSigla, BC001618_A148DocTipoNome,
               BC001618_A219DocTipoAtivo, BC001618_A306DocUltArqSeq, BC001618_n306DocUltArqSeq, BC001618_A640DocAtivo, BC001618_n640DocAtivo, BC001618_A481DocAssinado, BC001618_A480DocContrato, BC001618_A146DocTipoID, BC001618_A326DocVersaoIDPai, BC001618_n326DocVersaoIDPai
               }
               , new Object[] {
               BC001619_A289DocID, BC001619_A307DocArqSeq, BC001619_A644DocArqArmExterno, BC001619_A316DocArqDel, BC001619_A310DocArqInsDataHora, BC001619_A308DocArqInsData, BC001619_A309DocArqInsHora, BC001619_A311DocArqInsUsuID, BC001619_n311DocArqInsUsuID, BC001619_A312DocArqUpdData,
               BC001619_n312DocArqUpdData, BC001619_A313DocArqUpdHora, BC001619_n313DocArqUpdHora, BC001619_A314DocArqUpdDataHora, BC001619_n314DocArqUpdDataHora, BC001619_A315DocArqUsuID, BC001619_n315DocArqUsuID, BC001619_A317DocArqDelData, BC001619_n317DocArqDelData, BC001619_A319DocArqDelDataHora,
               BC001619_n319DocArqDelDataHora, BC001619_A320DocArqDelUsuID, BC001619_n320DocArqDelUsuID, BC001619_A324DocArqObservacao, BC001619_n324DocArqObservacao, BC001619_A645DocArqArmExternoPath, BC001619_n645DocArqArmExternoPath, BC001619_A323DocArqConteudoExtensao, BC001619_A322DocArqConteudoNome, BC001619_A321DocArqConteudo,
               BC001619_n321DocArqConteudo
               }
               , new Object[] {
               BC001620_A289DocID, BC001620_A307DocArqSeq
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001625_A289DocID, BC001625_A307DocArqSeq, BC001625_A644DocArqArmExterno, BC001625_A316DocArqDel, BC001625_A310DocArqInsDataHora, BC001625_A308DocArqInsData, BC001625_A309DocArqInsHora, BC001625_A311DocArqInsUsuID, BC001625_n311DocArqInsUsuID, BC001625_A312DocArqUpdData,
               BC001625_n312DocArqUpdData, BC001625_A313DocArqUpdHora, BC001625_n313DocArqUpdHora, BC001625_A314DocArqUpdDataHora, BC001625_n314DocArqUpdDataHora, BC001625_A315DocArqUsuID, BC001625_n315DocArqUsuID, BC001625_A317DocArqDelData, BC001625_n317DocArqDelData, BC001625_A319DocArqDelDataHora,
               BC001625_n319DocArqDelDataHora, BC001625_A320DocArqDelUsuID, BC001625_n320DocArqDelUsuID, BC001625_A324DocArqObservacao, BC001625_n324DocArqObservacao, BC001625_A645DocArqArmExternoPath, BC001625_n645DocArqArmExternoPath, BC001625_A323DocArqConteudoExtensao, BC001625_A322DocArqConteudoNome, BC001625_A321DocArqConteudo,
               BC001625_n321DocArqConteudo
               }
            }
         );
         Z644DocArqArmExterno = false;
         A644DocArqArmExterno = false;
         i644DocArqArmExterno = false;
         Z316DocArqDel = false;
         A316DocArqDel = false;
         i316DocArqDel = false;
         Z640DocAtivo = true;
         n640DocAtivo = false;
         A640DocAtivo = true;
         n640DocAtivo = false;
         i640DocAtivo = true;
         n640DocAtivo = false;
         Z481DocAssinado = false;
         A481DocAssinado = false;
         i481DocAssinado = false;
         Z480DocContrato = false;
         A480DocContrato = false;
         i480DocContrato = false;
         Z289DocID = Guid.NewGuid( );
         A289DocID = Guid.NewGuid( );
         AV26Pgmname = "core.DocumentoEstrutura_BC";
         Z300DocDel = false;
         A300DocDel = false;
         i300DocDel = false;
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12162 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short s306DocUltArqSeq ;
      private short O306DocUltArqSeq ;
      private short A306DocUltArqSeq ;
      private short nIsMod_34 ;
      private short RcdFound34 ;
      private short GX_JID ;
      private short Z325DocVersao ;
      private short A325DocVersao ;
      private short Z306DocUltArqSeq ;
      private short Gx_BScreen ;
      private short RcdFound33 ;
      private short nIsDirty_33 ;
      private short nRcdExists_34 ;
      private short Gxremove34 ;
      private short Z307DocArqSeq ;
      private short A307DocArqSeq ;
      private short nIsDirty_34 ;
      private short i306DocUltArqSeq ;
      private int trnEnded ;
      private int nGXsfl_34_idx=1 ;
      private int AV27GXV1 ;
      private int AV14Insert_DocTipoID ;
      private int Z146DocTipoID ;
      private int A146DocTipoID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode33 ;
      private string AV26Pgmname ;
      private string Z295DocInsUsuID ;
      private string A295DocInsUsuID ;
      private string Z299DocUpdUsuID ;
      private string A299DocUpdUsuID ;
      private string Z304DocDelUsuID ;
      private string A304DocDelUsuID ;
      private string Z311DocArqInsUsuID ;
      private string A311DocArqInsUsuID ;
      private string Z315DocArqUsuID ;
      private string A315DocArqUsuID ;
      private string Z320DocArqDelUsuID ;
      private string A320DocArqDelUsuID ;
      private string A321DocArqConteudo_Filetype ;
      private string A321DocArqConteudo_Filename ;
      private string sMode34 ;
      private DateTime Z294DocInsDataHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime Z293DocInsHora ;
      private DateTime A293DocInsHora ;
      private DateTime Z297DocUpdHora ;
      private DateTime A297DocUpdHora ;
      private DateTime Z298DocUpdDataHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime Z301DocDelData ;
      private DateTime A301DocDelData ;
      private DateTime Z302DocDelHora ;
      private DateTime A302DocDelHora ;
      private DateTime Z303DocDelDataHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime Z310DocArqInsDataHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime Z309DocArqInsHora ;
      private DateTime A309DocArqInsHora ;
      private DateTime Z313DocArqUpdHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime Z314DocArqUpdDataHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime Z317DocArqDelData ;
      private DateTime A317DocArqDelData ;
      private DateTime Z319DocArqDelDataHora ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime Z292DocInsData ;
      private DateTime A292DocInsData ;
      private DateTime Z296DocUpdData ;
      private DateTime A296DocUpdData ;
      private DateTime Z308DocArqInsData ;
      private DateTime A308DocArqInsData ;
      private DateTime Z312DocArqUpdData ;
      private DateTime A312DocArqUpdData ;
      private bool n306DocUltArqSeq ;
      private bool returnInSub ;
      private bool Z300DocDel ;
      private bool A300DocDel ;
      private bool Z640DocAtivo ;
      private bool A640DocAtivo ;
      private bool Z481DocAssinado ;
      private bool A481DocAssinado ;
      private bool Z480DocContrato ;
      private bool A480DocContrato ;
      private bool Z219DocTipoAtivo ;
      private bool A219DocTipoAtivo ;
      private bool n640DocAtivo ;
      private bool n295DocInsUsuID ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n298DocUpdDataHora ;
      private bool n299DocUpdUsuID ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n303DocDelDataHora ;
      private bool n304DocDelUsuID ;
      private bool n326DocVersaoIDPai ;
      private bool Gx_longc ;
      private bool Z644DocArqArmExterno ;
      private bool A644DocArqArmExterno ;
      private bool Z316DocArqDel ;
      private bool A316DocArqDel ;
      private bool n311DocArqInsUsuID ;
      private bool n312DocArqUpdData ;
      private bool n313DocArqUpdHora ;
      private bool n314DocArqUpdDataHora ;
      private bool n315DocArqUsuID ;
      private bool n317DocArqDelData ;
      private bool n319DocArqDelDataHora ;
      private bool n320DocArqDelUsuID ;
      private bool n324DocArqObservacao ;
      private bool n645DocArqArmExternoPath ;
      private bool n321DocArqConteudo ;
      private bool i640DocAtivo ;
      private bool i481DocAssinado ;
      private bool i480DocContrato ;
      private bool i300DocDel ;
      private bool i644DocArqArmExterno ;
      private bool i316DocArqDel ;
      private bool mustCommit ;
      private string Z290DocOrigem ;
      private string A290DocOrigem ;
      private string Z291DocOrigemID ;
      private string A291DocOrigemID ;
      private string Z305DocNome ;
      private string A305DocNome ;
      private string Z147DocTipoSigla ;
      private string A147DocTipoSigla ;
      private string Z148DocTipoNome ;
      private string A148DocTipoNome ;
      private string Z327DocVersaoNomePai ;
      private string A327DocVersaoNomePai ;
      private string Z324DocArqObservacao ;
      private string A324DocArqObservacao ;
      private string Z645DocArqArmExternoPath ;
      private string A645DocArqArmExternoPath ;
      private string Z323DocArqConteudoExtensao ;
      private string A323DocArqConteudoExtensao ;
      private string Z322DocArqConteudoNome ;
      private string A322DocArqConteudoNome ;
      private Guid Z289DocID ;
      private Guid A289DocID ;
      private Guid AV13Insert_DocVersaoIDPai ;
      private Guid Z326DocVersaoIDPai ;
      private Guid A326DocVersaoIDPai ;
      private string Z321DocArqConteudo ;
      private string A321DocArqConteudo ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtDocumentoEstrutura bccore_DocumentoEstrutura ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00168_A289DocID ;
      private DateTime[] BC00168_A294DocInsDataHora ;
      private DateTime[] BC00168_A292DocInsData ;
      private DateTime[] BC00168_A293DocInsHora ;
      private string[] BC00168_A295DocInsUsuID ;
      private bool[] BC00168_n295DocInsUsuID ;
      private short[] BC00168_A325DocVersao ;
      private string[] BC00168_A327DocVersaoNomePai ;
      private string[] BC00168_A290DocOrigem ;
      private string[] BC00168_A291DocOrigemID ;
      private DateTime[] BC00168_A296DocUpdData ;
      private bool[] BC00168_n296DocUpdData ;
      private DateTime[] BC00168_A297DocUpdHora ;
      private bool[] BC00168_n297DocUpdHora ;
      private DateTime[] BC00168_A298DocUpdDataHora ;
      private bool[] BC00168_n298DocUpdDataHora ;
      private string[] BC00168_A299DocUpdUsuID ;
      private bool[] BC00168_n299DocUpdUsuID ;
      private bool[] BC00168_A300DocDel ;
      private DateTime[] BC00168_A301DocDelData ;
      private bool[] BC00168_n301DocDelData ;
      private DateTime[] BC00168_A302DocDelHora ;
      private bool[] BC00168_n302DocDelHora ;
      private DateTime[] BC00168_A303DocDelDataHora ;
      private bool[] BC00168_n303DocDelDataHora ;
      private string[] BC00168_A304DocDelUsuID ;
      private bool[] BC00168_n304DocDelUsuID ;
      private string[] BC00168_A305DocNome ;
      private string[] BC00168_A147DocTipoSigla ;
      private string[] BC00168_A148DocTipoNome ;
      private bool[] BC00168_A219DocTipoAtivo ;
      private short[] BC00168_A306DocUltArqSeq ;
      private bool[] BC00168_n306DocUltArqSeq ;
      private bool[] BC00168_A640DocAtivo ;
      private bool[] BC00168_n640DocAtivo ;
      private bool[] BC00168_A481DocAssinado ;
      private bool[] BC00168_A480DocContrato ;
      private int[] BC00168_A146DocTipoID ;
      private Guid[] BC00168_A326DocVersaoIDPai ;
      private bool[] BC00168_n326DocVersaoIDPai ;
      private Guid[] BC00169_A326DocVersaoIDPai ;
      private bool[] BC00169_n326DocVersaoIDPai ;
      private string[] BC00167_A327DocVersaoNomePai ;
      private string[] BC00166_A147DocTipoSigla ;
      private string[] BC00166_A148DocTipoNome ;
      private bool[] BC00166_A219DocTipoAtivo ;
      private Guid[] BC001610_A289DocID ;
      private Guid[] BC00165_A289DocID ;
      private DateTime[] BC00165_A294DocInsDataHora ;
      private DateTime[] BC00165_A292DocInsData ;
      private DateTime[] BC00165_A293DocInsHora ;
      private string[] BC00165_A295DocInsUsuID ;
      private bool[] BC00165_n295DocInsUsuID ;
      private short[] BC00165_A325DocVersao ;
      private string[] BC00165_A290DocOrigem ;
      private string[] BC00165_A291DocOrigemID ;
      private DateTime[] BC00165_A296DocUpdData ;
      private bool[] BC00165_n296DocUpdData ;
      private DateTime[] BC00165_A297DocUpdHora ;
      private bool[] BC00165_n297DocUpdHora ;
      private DateTime[] BC00165_A298DocUpdDataHora ;
      private bool[] BC00165_n298DocUpdDataHora ;
      private string[] BC00165_A299DocUpdUsuID ;
      private bool[] BC00165_n299DocUpdUsuID ;
      private bool[] BC00165_A300DocDel ;
      private DateTime[] BC00165_A301DocDelData ;
      private bool[] BC00165_n301DocDelData ;
      private DateTime[] BC00165_A302DocDelHora ;
      private bool[] BC00165_n302DocDelHora ;
      private DateTime[] BC00165_A303DocDelDataHora ;
      private bool[] BC00165_n303DocDelDataHora ;
      private string[] BC00165_A304DocDelUsuID ;
      private bool[] BC00165_n304DocDelUsuID ;
      private string[] BC00165_A305DocNome ;
      private short[] BC00165_A306DocUltArqSeq ;
      private bool[] BC00165_n306DocUltArqSeq ;
      private bool[] BC00165_A640DocAtivo ;
      private bool[] BC00165_n640DocAtivo ;
      private bool[] BC00165_A481DocAssinado ;
      private bool[] BC00165_A480DocContrato ;
      private int[] BC00165_A146DocTipoID ;
      private Guid[] BC00165_A326DocVersaoIDPai ;
      private bool[] BC00165_n326DocVersaoIDPai ;
      private Guid[] BC00164_A289DocID ;
      private DateTime[] BC00164_A294DocInsDataHora ;
      private DateTime[] BC00164_A292DocInsData ;
      private DateTime[] BC00164_A293DocInsHora ;
      private string[] BC00164_A295DocInsUsuID ;
      private bool[] BC00164_n295DocInsUsuID ;
      private short[] BC00164_A325DocVersao ;
      private string[] BC00164_A290DocOrigem ;
      private string[] BC00164_A291DocOrigemID ;
      private DateTime[] BC00164_A296DocUpdData ;
      private bool[] BC00164_n296DocUpdData ;
      private DateTime[] BC00164_A297DocUpdHora ;
      private bool[] BC00164_n297DocUpdHora ;
      private DateTime[] BC00164_A298DocUpdDataHora ;
      private bool[] BC00164_n298DocUpdDataHora ;
      private string[] BC00164_A299DocUpdUsuID ;
      private bool[] BC00164_n299DocUpdUsuID ;
      private bool[] BC00164_A300DocDel ;
      private DateTime[] BC00164_A301DocDelData ;
      private bool[] BC00164_n301DocDelData ;
      private DateTime[] BC00164_A302DocDelHora ;
      private bool[] BC00164_n302DocDelHora ;
      private DateTime[] BC00164_A303DocDelDataHora ;
      private bool[] BC00164_n303DocDelDataHora ;
      private string[] BC00164_A304DocDelUsuID ;
      private bool[] BC00164_n304DocDelUsuID ;
      private string[] BC00164_A305DocNome ;
      private short[] BC00164_A306DocUltArqSeq ;
      private bool[] BC00164_n306DocUltArqSeq ;
      private bool[] BC00164_A640DocAtivo ;
      private bool[] BC00164_n640DocAtivo ;
      private bool[] BC00164_A481DocAssinado ;
      private bool[] BC00164_A480DocContrato ;
      private int[] BC00164_A146DocTipoID ;
      private Guid[] BC00164_A326DocVersaoIDPai ;
      private bool[] BC00164_n326DocVersaoIDPai ;
      private string[] BC001614_A327DocVersaoNomePai ;
      private string[] BC001615_A147DocTipoSigla ;
      private string[] BC001615_A148DocTipoNome ;
      private bool[] BC001615_A219DocTipoAtivo ;
      private Guid[] BC001616_A326DocVersaoIDPai ;
      private bool[] BC001616_n326DocVersaoIDPai ;
      private Guid[] BC001618_A289DocID ;
      private DateTime[] BC001618_A294DocInsDataHora ;
      private DateTime[] BC001618_A292DocInsData ;
      private DateTime[] BC001618_A293DocInsHora ;
      private string[] BC001618_A295DocInsUsuID ;
      private bool[] BC001618_n295DocInsUsuID ;
      private short[] BC001618_A325DocVersao ;
      private string[] BC001618_A327DocVersaoNomePai ;
      private string[] BC001618_A290DocOrigem ;
      private string[] BC001618_A291DocOrigemID ;
      private DateTime[] BC001618_A296DocUpdData ;
      private bool[] BC001618_n296DocUpdData ;
      private DateTime[] BC001618_A297DocUpdHora ;
      private bool[] BC001618_n297DocUpdHora ;
      private DateTime[] BC001618_A298DocUpdDataHora ;
      private bool[] BC001618_n298DocUpdDataHora ;
      private string[] BC001618_A299DocUpdUsuID ;
      private bool[] BC001618_n299DocUpdUsuID ;
      private bool[] BC001618_A300DocDel ;
      private DateTime[] BC001618_A301DocDelData ;
      private bool[] BC001618_n301DocDelData ;
      private DateTime[] BC001618_A302DocDelHora ;
      private bool[] BC001618_n302DocDelHora ;
      private DateTime[] BC001618_A303DocDelDataHora ;
      private bool[] BC001618_n303DocDelDataHora ;
      private string[] BC001618_A304DocDelUsuID ;
      private bool[] BC001618_n304DocDelUsuID ;
      private string[] BC001618_A305DocNome ;
      private string[] BC001618_A147DocTipoSigla ;
      private string[] BC001618_A148DocTipoNome ;
      private bool[] BC001618_A219DocTipoAtivo ;
      private short[] BC001618_A306DocUltArqSeq ;
      private bool[] BC001618_n306DocUltArqSeq ;
      private bool[] BC001618_A640DocAtivo ;
      private bool[] BC001618_n640DocAtivo ;
      private bool[] BC001618_A481DocAssinado ;
      private bool[] BC001618_A480DocContrato ;
      private int[] BC001618_A146DocTipoID ;
      private Guid[] BC001618_A326DocVersaoIDPai ;
      private bool[] BC001618_n326DocVersaoIDPai ;
      private Guid[] BC001619_A289DocID ;
      private short[] BC001619_A307DocArqSeq ;
      private bool[] BC001619_A644DocArqArmExterno ;
      private bool[] BC001619_A316DocArqDel ;
      private DateTime[] BC001619_A310DocArqInsDataHora ;
      private DateTime[] BC001619_A308DocArqInsData ;
      private DateTime[] BC001619_A309DocArqInsHora ;
      private string[] BC001619_A311DocArqInsUsuID ;
      private bool[] BC001619_n311DocArqInsUsuID ;
      private DateTime[] BC001619_A312DocArqUpdData ;
      private bool[] BC001619_n312DocArqUpdData ;
      private DateTime[] BC001619_A313DocArqUpdHora ;
      private bool[] BC001619_n313DocArqUpdHora ;
      private DateTime[] BC001619_A314DocArqUpdDataHora ;
      private bool[] BC001619_n314DocArqUpdDataHora ;
      private string[] BC001619_A315DocArqUsuID ;
      private bool[] BC001619_n315DocArqUsuID ;
      private DateTime[] BC001619_A317DocArqDelData ;
      private bool[] BC001619_n317DocArqDelData ;
      private DateTime[] BC001619_A319DocArqDelDataHora ;
      private bool[] BC001619_n319DocArqDelDataHora ;
      private string[] BC001619_A320DocArqDelUsuID ;
      private bool[] BC001619_n320DocArqDelUsuID ;
      private string[] BC001619_A324DocArqObservacao ;
      private bool[] BC001619_n324DocArqObservacao ;
      private string[] BC001619_A645DocArqArmExternoPath ;
      private bool[] BC001619_n645DocArqArmExternoPath ;
      private string[] BC001619_A323DocArqConteudoExtensao ;
      private string[] BC001619_A322DocArqConteudoNome ;
      private string[] BC001619_A321DocArqConteudo ;
      private bool[] BC001619_n321DocArqConteudo ;
      private Guid[] BC001620_A289DocID ;
      private short[] BC001620_A307DocArqSeq ;
      private Guid[] BC00163_A289DocID ;
      private short[] BC00163_A307DocArqSeq ;
      private bool[] BC00163_A644DocArqArmExterno ;
      private bool[] BC00163_A316DocArqDel ;
      private DateTime[] BC00163_A310DocArqInsDataHora ;
      private DateTime[] BC00163_A308DocArqInsData ;
      private DateTime[] BC00163_A309DocArqInsHora ;
      private string[] BC00163_A311DocArqInsUsuID ;
      private bool[] BC00163_n311DocArqInsUsuID ;
      private DateTime[] BC00163_A312DocArqUpdData ;
      private bool[] BC00163_n312DocArqUpdData ;
      private DateTime[] BC00163_A313DocArqUpdHora ;
      private bool[] BC00163_n313DocArqUpdHora ;
      private DateTime[] BC00163_A314DocArqUpdDataHora ;
      private bool[] BC00163_n314DocArqUpdDataHora ;
      private string[] BC00163_A315DocArqUsuID ;
      private bool[] BC00163_n315DocArqUsuID ;
      private DateTime[] BC00163_A317DocArqDelData ;
      private bool[] BC00163_n317DocArqDelData ;
      private DateTime[] BC00163_A319DocArqDelDataHora ;
      private bool[] BC00163_n319DocArqDelDataHora ;
      private string[] BC00163_A320DocArqDelUsuID ;
      private bool[] BC00163_n320DocArqDelUsuID ;
      private string[] BC00163_A324DocArqObservacao ;
      private bool[] BC00163_n324DocArqObservacao ;
      private string[] BC00163_A645DocArqArmExternoPath ;
      private bool[] BC00163_n645DocArqArmExternoPath ;
      private string[] BC00163_A323DocArqConteudoExtensao ;
      private string[] BC00163_A322DocArqConteudoNome ;
      private string[] BC00163_A321DocArqConteudo ;
      private bool[] BC00163_n321DocArqConteudo ;
      private Guid[] BC00162_A289DocID ;
      private short[] BC00162_A307DocArqSeq ;
      private bool[] BC00162_A644DocArqArmExterno ;
      private bool[] BC00162_A316DocArqDel ;
      private DateTime[] BC00162_A310DocArqInsDataHora ;
      private DateTime[] BC00162_A308DocArqInsData ;
      private DateTime[] BC00162_A309DocArqInsHora ;
      private string[] BC00162_A311DocArqInsUsuID ;
      private bool[] BC00162_n311DocArqInsUsuID ;
      private DateTime[] BC00162_A312DocArqUpdData ;
      private bool[] BC00162_n312DocArqUpdData ;
      private DateTime[] BC00162_A313DocArqUpdHora ;
      private bool[] BC00162_n313DocArqUpdHora ;
      private DateTime[] BC00162_A314DocArqUpdDataHora ;
      private bool[] BC00162_n314DocArqUpdDataHora ;
      private string[] BC00162_A315DocArqUsuID ;
      private bool[] BC00162_n315DocArqUsuID ;
      private DateTime[] BC00162_A317DocArqDelData ;
      private bool[] BC00162_n317DocArqDelData ;
      private DateTime[] BC00162_A319DocArqDelDataHora ;
      private bool[] BC00162_n319DocArqDelDataHora ;
      private string[] BC00162_A320DocArqDelUsuID ;
      private bool[] BC00162_n320DocArqDelUsuID ;
      private string[] BC00162_A324DocArqObservacao ;
      private bool[] BC00162_n324DocArqObservacao ;
      private string[] BC00162_A645DocArqArmExternoPath ;
      private bool[] BC00162_n645DocArqArmExternoPath ;
      private string[] BC00162_A323DocArqConteudoExtensao ;
      private string[] BC00162_A322DocArqConteudoNome ;
      private string[] BC00162_A321DocArqConteudo ;
      private bool[] BC00162_n321DocArqConteudo ;
      private Guid[] BC001625_A289DocID ;
      private short[] BC001625_A307DocArqSeq ;
      private bool[] BC001625_A644DocArqArmExterno ;
      private bool[] BC001625_A316DocArqDel ;
      private DateTime[] BC001625_A310DocArqInsDataHora ;
      private DateTime[] BC001625_A308DocArqInsData ;
      private DateTime[] BC001625_A309DocArqInsHora ;
      private string[] BC001625_A311DocArqInsUsuID ;
      private bool[] BC001625_n311DocArqInsUsuID ;
      private DateTime[] BC001625_A312DocArqUpdData ;
      private bool[] BC001625_n312DocArqUpdData ;
      private DateTime[] BC001625_A313DocArqUpdHora ;
      private bool[] BC001625_n313DocArqUpdHora ;
      private DateTime[] BC001625_A314DocArqUpdDataHora ;
      private bool[] BC001625_n314DocArqUpdDataHora ;
      private string[] BC001625_A315DocArqUsuID ;
      private bool[] BC001625_n315DocArqUsuID ;
      private DateTime[] BC001625_A317DocArqDelData ;
      private bool[] BC001625_n317DocArqDelData ;
      private DateTime[] BC001625_A319DocArqDelDataHora ;
      private bool[] BC001625_n319DocArqDelDataHora ;
      private string[] BC001625_A320DocArqDelUsuID ;
      private bool[] BC001625_n320DocArqDelUsuID ;
      private string[] BC001625_A324DocArqObservacao ;
      private bool[] BC001625_n324DocArqObservacao ;
      private string[] BC001625_A645DocArqArmExternoPath ;
      private bool[] BC001625_n645DocArqArmExternoPath ;
      private string[] BC001625_A323DocArqConteudoExtensao ;
      private string[] BC001625_A322DocArqConteudoNome ;
      private string[] BC001625_A321DocArqConteudo ;
      private bool[] BC001625_n321DocArqConteudo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ;
   }

   public class documentoestrutura_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentoestrutura_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new UpdateCursor(def[22])
       ,new ForEachCursor(def[23])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00168;
        prmBC00168 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00169;
        prmBC00169 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00167;
        prmBC00167 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC00166;
        prmBC00166 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC001610;
        prmBC001610 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00165;
        prmBC00165 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00164;
        prmBC00164 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001611;
        prmBC001611 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC001612;
        prmBC001612 = new Object[] {
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001613;
        prmBC001613 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001614;
        prmBC001614 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmBC001615;
        prmBC001615 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC001616;
        prmBC001616 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001617;
        prmBC001617 = new Object[] {
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001618;
        prmBC001618 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001619;
        prmBC001619 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001620;
        prmBC001620 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00163;
        prmBC00163 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00162;
        prmBC00162 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001621;
        prmBC001621 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0) ,
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0)
        };
        Object[] prmBC001622;
        prmBC001622 = new Object[] {
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001623;
        prmBC001623 = new Object[] {
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001624;
        prmBC001624 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001625;
        prmBC001625 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00162", "SELECT DocID, DocArqSeq, DocArqArmExterno, DocArqDel, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqObservacao, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq  FOR UPDATE OF tb_documento_arquivo",true, GxErrorMask.GX_NOMASK, false, this,prmBC00162,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00163", "SELECT DocID, DocArqSeq, DocArqArmExterno, DocArqDel, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqObservacao, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00163,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00164", "SELECT DocID, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocVersao, DocOrigem, DocOrigemID, DocUpdData, DocUpdHora, DocUpdDataHora, DocUpdUsuID, DocDel, DocDelData, DocDelHora, DocDelDataHora, DocDelUsuID, DocNome, DocUltArqSeq, DocAtivo, DocAssinado, DocContrato, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00164,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00165", "SELECT DocID, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocVersao, DocOrigem, DocOrigemID, DocUpdData, DocUpdHora, DocUpdDataHora, DocUpdUsuID, DocDel, DocDelData, DocDelHora, DocDelDataHora, DocDelUsuID, DocNome, DocUltArqSeq, DocAtivo, DocAssinado, DocContrato, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00165,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00166", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00166,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00167", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00167,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00168", "SELECT TM1.DocID, TM1.DocInsDataHora, TM1.DocInsData, TM1.DocInsHora, TM1.DocInsUsuID, TM1.DocVersao, T2.DocNome AS DocVersaoNomePai, TM1.DocOrigem, TM1.DocOrigemID, TM1.DocUpdData, TM1.DocUpdHora, TM1.DocUpdDataHora, TM1.DocUpdUsuID, TM1.DocDel, TM1.DocDelData, TM1.DocDelHora, TM1.DocDelDataHora, TM1.DocDelUsuID, TM1.DocNome, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, TM1.DocUltArqSeq, TM1.DocAtivo, TM1.DocAssinado, TM1.DocContrato, TM1.DocTipoID, TM1.DocVersaoIDPai AS DocVersaoIDPai FROM ((tb_documento TM1 LEFT JOIN tb_documento T2 ON T2.DocID = TM1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = TM1.DocTipoID) WHERE TM1.DocID = :DocID ORDER BY TM1.DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00168,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00169", "SELECT DocVersaoIDPai FROM tb_documento WHERE (DocVersaoIDPai = :DocVersaoIDPai AND DocVersao = :DocVersao) AND (Not ( DocID = :DocID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00169,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001610", "SELECT DocID FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001610,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001611", "SAVEPOINT gxupdate;INSERT INTO tb_documento(DocID, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocVersao, DocOrigem, DocOrigemID, DocUpdData, DocUpdHora, DocUpdDataHora, DocUpdUsuID, DocDel, DocDelData, DocDelHora, DocDelDataHora, DocDelUsuID, DocNome, DocUltArqSeq, DocAtivo, DocAssinado, DocContrato, DocTipoID, DocVersaoIDPai, DocDelUsuNome) VALUES(:DocID, :DocInsDataHora, :DocInsData, :DocInsHora, :DocInsUsuID, :DocVersao, :DocOrigem, :DocOrigemID, :DocUpdData, :DocUpdHora, :DocUpdDataHora, :DocUpdUsuID, :DocDel, :DocDelData, :DocDelHora, :DocDelDataHora, :DocDelUsuID, :DocNome, :DocUltArqSeq, :DocAtivo, :DocAssinado, :DocContrato, :DocTipoID, :DocVersaoIDPai, '');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001611)
           ,new CursorDef("BC001612", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocInsDataHora=:DocInsDataHora, DocInsData=:DocInsData, DocInsHora=:DocInsHora, DocInsUsuID=:DocInsUsuID, DocVersao=:DocVersao, DocOrigem=:DocOrigem, DocOrigemID=:DocOrigemID, DocUpdData=:DocUpdData, DocUpdHora=:DocUpdHora, DocUpdDataHora=:DocUpdDataHora, DocUpdUsuID=:DocUpdUsuID, DocDel=:DocDel, DocDelData=:DocDelData, DocDelHora=:DocDelHora, DocDelDataHora=:DocDelDataHora, DocDelUsuID=:DocDelUsuID, DocNome=:DocNome, DocUltArqSeq=:DocUltArqSeq, DocAtivo=:DocAtivo, DocAssinado=:DocAssinado, DocContrato=:DocContrato, DocTipoID=:DocTipoID, DocVersaoIDPai=:DocVersaoIDPai  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001612)
           ,new CursorDef("BC001613", "SAVEPOINT gxupdate;DELETE FROM tb_documento  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001613)
           ,new CursorDef("BC001614", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001614,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001615", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001615,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001616", "SELECT DocID AS DocVersaoIDPai FROM tb_documento WHERE DocVersaoIDPai = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001616,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001617", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocUltArqSeq=:DocUltArqSeq  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001617)
           ,new CursorDef("BC001618", "SELECT TM1.DocID, TM1.DocInsDataHora, TM1.DocInsData, TM1.DocInsHora, TM1.DocInsUsuID, TM1.DocVersao, T2.DocNome AS DocVersaoNomePai, TM1.DocOrigem, TM1.DocOrigemID, TM1.DocUpdData, TM1.DocUpdHora, TM1.DocUpdDataHora, TM1.DocUpdUsuID, TM1.DocDel, TM1.DocDelData, TM1.DocDelHora, TM1.DocDelDataHora, TM1.DocDelUsuID, TM1.DocNome, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, TM1.DocUltArqSeq, TM1.DocAtivo, TM1.DocAssinado, TM1.DocContrato, TM1.DocTipoID, TM1.DocVersaoIDPai AS DocVersaoIDPai FROM ((tb_documento TM1 LEFT JOIN tb_documento T2 ON T2.DocID = TM1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = TM1.DocTipoID) WHERE TM1.DocID = :DocID ORDER BY TM1.DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001618,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001619", "SELECT DocID, DocArqSeq, DocArqArmExterno, DocArqDel, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqObservacao, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID and DocArqSeq = :DocArqSeq ORDER BY DocID, DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001619,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001620", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001620,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001621", "SAVEPOINT gxupdate;INSERT INTO tb_documento_arquivo(DocID, DocArqSeq, DocArqArmExterno, DocArqDel, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqConteudo, DocArqObservacao, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocArqDelUsuNome, DocArqDelHora) VALUES(:DocID, :DocArqSeq, :DocArqArmExterno, :DocArqDel, :DocArqInsDataHora, :DocArqInsData, :DocArqInsHora, :DocArqInsUsuID, :DocArqUpdData, :DocArqUpdHora, :DocArqUpdDataHora, :DocArqUsuID, :DocArqDelData, :DocArqDelDataHora, :DocArqDelUsuID, :DocArqConteudo, :DocArqObservacao, :DocArqArmExternoPath, :DocArqConteudoExtensao, :DocArqConteudoNome, '', DATE '00010101');RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC001621)
           ,new CursorDef("BC001622", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqArmExterno=:DocArqArmExterno, DocArqDel=:DocArqDel, DocArqInsDataHora=:DocArqInsDataHora, DocArqInsData=:DocArqInsData, DocArqInsHora=:DocArqInsHora, DocArqInsUsuID=:DocArqInsUsuID, DocArqUpdData=:DocArqUpdData, DocArqUpdHora=:DocArqUpdHora, DocArqUpdDataHora=:DocArqUpdDataHora, DocArqUsuID=:DocArqUsuID, DocArqDelData=:DocArqDelData, DocArqDelDataHora=:DocArqDelDataHora, DocArqDelUsuID=:DocArqDelUsuID, DocArqObservacao=:DocArqObservacao, DocArqArmExternoPath=:DocArqArmExternoPath, DocArqConteudoExtensao=:DocArqConteudoExtensao, DocArqConteudoNome=:DocArqConteudoNome  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001622)
           ,new CursorDef("BC001623", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqConteudo=:DocArqConteudo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001623)
           ,new CursorDef("BC001624", "SAVEPOINT gxupdate;DELETE FROM tb_documento_arquivo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001624)
           ,new CursorDef("BC001625", "SELECT DocID, DocArqSeq, DocArqArmExterno, DocArqDel, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDelData, DocArqDelDataHora, DocArqDelUsuID, DocArqObservacao, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID ORDER BY DocID, DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001625,11, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((string[]) buf[29])[0] = rslt.getBLOBFile(20, rslt.getVarchar(18), rslt.getVarchar(19));
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((string[]) buf[29])[0] = rslt.getBLOBFile(20, rslt.getVarchar(18), rslt.getVarchar(19));
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((bool[]) buf[17])[0] = rslt.getBool(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((string[]) buf[24])[0] = rslt.getString(17, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getVarchar(18);
              ((short[]) buf[27])[0] = rslt.getShort(19);
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((int[]) buf[33])[0] = rslt.getInt(23);
              ((Guid[]) buf[34])[0] = rslt.getGuid(24);
              ((bool[]) buf[35])[0] = rslt.wasNull(24);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((bool[]) buf[17])[0] = rslt.getBool(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[21])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(16);
              ((string[]) buf[24])[0] = rslt.getString(17, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(17);
              ((string[]) buf[26])[0] = rslt.getVarchar(18);
              ((short[]) buf[27])[0] = rslt.getShort(19);
              ((bool[]) buf[28])[0] = rslt.wasNull(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((int[]) buf[33])[0] = rslt.getInt(23);
              ((Guid[]) buf[34])[0] = rslt.getGuid(24);
              ((bool[]) buf[35])[0] = rslt.wasNull(24);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((bool[]) buf[18])[0] = rslt.getBool(14);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[22])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(17);
              ((string[]) buf[25])[0] = rslt.getString(18, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(18);
              ((string[]) buf[27])[0] = rslt.getVarchar(19);
              ((string[]) buf[28])[0] = rslt.getVarchar(20);
              ((string[]) buf[29])[0] = rslt.getVarchar(21);
              ((bool[]) buf[30])[0] = rslt.getBool(22);
              ((short[]) buf[31])[0] = rslt.getShort(23);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((bool[]) buf[33])[0] = rslt.getBool(24);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((bool[]) buf[35])[0] = rslt.getBool(25);
              ((bool[]) buf[36])[0] = rslt.getBool(26);
              ((int[]) buf[37])[0] = rslt.getInt(27);
              ((Guid[]) buf[38])[0] = rslt.getGuid(28);
              ((bool[]) buf[39])[0] = rslt.wasNull(28);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((short[]) buf[6])[0] = rslt.getShort(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getVarchar(9);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(10);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getString(13, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((bool[]) buf[18])[0] = rslt.getBool(14);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[22])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(17);
              ((string[]) buf[25])[0] = rslt.getString(18, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(18);
              ((string[]) buf[27])[0] = rslt.getVarchar(19);
              ((string[]) buf[28])[0] = rslt.getVarchar(20);
              ((string[]) buf[29])[0] = rslt.getVarchar(21);
              ((bool[]) buf[30])[0] = rslt.getBool(22);
              ((short[]) buf[31])[0] = rslt.getShort(23);
              ((bool[]) buf[32])[0] = rslt.wasNull(23);
              ((bool[]) buf[33])[0] = rslt.getBool(24);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((bool[]) buf[35])[0] = rslt.getBool(25);
              ((bool[]) buf[36])[0] = rslt.getBool(26);
              ((int[]) buf[37])[0] = rslt.getInt(27);
              ((Guid[]) buf[38])[0] = rslt.getGuid(28);
              ((bool[]) buf[39])[0] = rslt.wasNull(28);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((string[]) buf[29])[0] = rslt.getBLOBFile(20, rslt.getVarchar(18), rslt.getVarchar(19));
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[9])[0] = rslt.getGXDate(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((bool[]) buf[14])[0] = rslt.wasNull(11);
              ((string[]) buf[15])[0] = rslt.getString(12, 40);
              ((bool[]) buf[16])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[17])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[19])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((string[]) buf[21])[0] = rslt.getString(15, 40);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((string[]) buf[23])[0] = rslt.getVarchar(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((string[]) buf[25])[0] = rslt.getVarchar(17);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((string[]) buf[29])[0] = rslt.getBLOBFile(20, rslt.getVarchar(18), rslt.getVarchar(19));
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              return;
     }
  }

}

}
