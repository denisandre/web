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
   public class documentoarquivo_bc : GxSilentTrn, IGxSilentTrn
   {
      public documentoarquivo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoarquivo_bc( IGxContext context )
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
         ReadRow1734( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1734( ) ;
         standaloneModal( ) ;
         AddRow1734( ) ;
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
            E11172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z289DocID = A289DocID;
               Z307DocArqSeq = A307DocArqSeq;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1734( ) ;
            }
            else
            {
               CheckExtendedTable1734( ) ;
               if ( AnyError == 0 )
               {
                  ZM1734( 20) ;
               }
               CloseExtendedTableCursors1734( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12172( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11172( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV25AuditingObject,  AV26Pgmname) ;
      }

      protected void ZM1734( short GX_JID )
      {
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
            Z310DocArqInsDataHora = A310DocArqInsDataHora;
            Z308DocArqInsData = A308DocArqInsData;
            Z309DocArqInsHora = A309DocArqInsHora;
            Z311DocArqInsUsuID = A311DocArqInsUsuID;
            Z319DocArqDelDataHora = A319DocArqDelDataHora;
            Z317DocArqDelData = A317DocArqDelData;
            Z511DocArqDelHora = A511DocArqDelHora;
            Z320DocArqDelUsuID = A320DocArqDelUsuID;
            Z509DocArqDelUsuNome = A509DocArqDelUsuNome;
            Z312DocArqUpdData = A312DocArqUpdData;
            Z313DocArqUpdHora = A313DocArqUpdHora;
            Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
            Z315DocArqUsuID = A315DocArqUsuID;
            Z316DocArqDel = A316DocArqDel;
            Z324DocArqObservacao = A324DocArqObservacao;
            Z644DocArqArmExterno = A644DocArqArmExterno;
            Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
         }
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            Z325DocVersao = A325DocVersao;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
         }
         if ( GX_JID == -19 )
         {
            Z307DocArqSeq = A307DocArqSeq;
            Z310DocArqInsDataHora = A310DocArqInsDataHora;
            Z308DocArqInsData = A308DocArqInsData;
            Z309DocArqInsHora = A309DocArqInsHora;
            Z311DocArqInsUsuID = A311DocArqInsUsuID;
            Z319DocArqDelDataHora = A319DocArqDelDataHora;
            Z317DocArqDelData = A317DocArqDelData;
            Z511DocArqDelHora = A511DocArqDelHora;
            Z320DocArqDelUsuID = A320DocArqDelUsuID;
            Z509DocArqDelUsuNome = A509DocArqDelUsuNome;
            Z312DocArqUpdData = A312DocArqUpdData;
            Z313DocArqUpdHora = A313DocArqUpdHora;
            Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
            Z315DocArqUsuID = A315DocArqUsuID;
            Z316DocArqDel = A316DocArqDel;
            Z321DocArqConteudo = A321DocArqConteudo;
            Z324DocArqObservacao = A324DocArqObservacao;
            Z644DocArqArmExterno = A644DocArqArmExterno;
            Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
            Z323DocArqConteudoExtensao = A323DocArqConteudoExtensao;
            Z322DocArqConteudoNome = A322DocArqConteudoNome;
            Z289DocID = A289DocID;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z325DocVersao = A325DocVersao;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV26Pgmname = "core.DocumentoArquivo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A644DocArqArmExterno) && ( Gx_BScreen == 0 ) )
         {
            A644DocArqArmExterno = false;
         }
         if ( IsIns( )  && (false==A316DocArqDel) && ( Gx_BScreen == 0 ) )
         {
            A316DocArqDel = false;
         }
      }

      protected void Load1734( )
      {
         /* Using cursor BC00176 */
         pr_default.execute(4, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound34 = 1;
            A306DocUltArqSeq = BC00176_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00176_n306DocUltArqSeq[0];
            A310DocArqInsDataHora = BC00176_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC00176_A308DocArqInsData[0];
            A309DocArqInsHora = BC00176_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC00176_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC00176_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = BC00176_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC00176_n319DocArqDelDataHora[0];
            A317DocArqDelData = BC00176_A317DocArqDelData[0];
            n317DocArqDelData = BC00176_n317DocArqDelData[0];
            A511DocArqDelHora = BC00176_A511DocArqDelHora[0];
            n511DocArqDelHora = BC00176_n511DocArqDelHora[0];
            A320DocArqDelUsuID = BC00176_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC00176_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = BC00176_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = BC00176_n509DocArqDelUsuNome[0];
            A325DocVersao = BC00176_A325DocVersao[0];
            A312DocArqUpdData = BC00176_A312DocArqUpdData[0];
            n312DocArqUpdData = BC00176_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC00176_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC00176_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC00176_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC00176_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC00176_A315DocArqUsuID[0];
            n315DocArqUsuID = BC00176_n315DocArqUsuID[0];
            A316DocArqDel = BC00176_A316DocArqDel[0];
            A324DocArqObservacao = BC00176_A324DocArqObservacao[0];
            n324DocArqObservacao = BC00176_n324DocArqObservacao[0];
            A644DocArqArmExterno = BC00176_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = BC00176_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC00176_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC00176_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC00176_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A326DocVersaoIDPai = BC00176_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00176_n326DocVersaoIDPai[0];
            A321DocArqConteudo = BC00176_A321DocArqConteudo[0];
            n321DocArqConteudo = BC00176_n321DocArqConteudo[0];
            ZM1734( -19) ;
         }
         pr_default.close(4);
         OnLoadActions1734( ) ;
      }

      protected void OnLoadActions1734( )
      {
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         if ( IsIns( )  )
         {
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
         }
         if ( IsIns( )  )
         {
            A307DocArqSeq = A306DocUltArqSeq;
         }
      }

      protected void CheckExtendedTable1734( )
      {
         nIsDirty_34 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00175 */
         pr_default.execute(3, new Object[] {A289DocID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
            AnyError = 1;
         }
         A306DocUltArqSeq = BC00175_A306DocUltArqSeq[0];
         n306DocUltArqSeq = BC00175_n306DocUltArqSeq[0];
         A325DocVersao = BC00175_A325DocVersao[0];
         A326DocVersaoIDPai = BC00175_A326DocVersaoIDPai[0];
         n326DocVersaoIDPai = BC00175_n326DocVersaoIDPai[0];
         nIsDirty_34 = 1;
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_34 = 1;
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
         }
         if ( IsIns( )  )
         {
            nIsDirty_34 = 1;
            A307DocArqSeq = A306DocUltArqSeq;
         }
      }

      protected void CloseExtendedTableCursors1734( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1734( )
      {
         /* Using cursor BC00177 */
         pr_default.execute(5, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00173 */
         pr_default.execute(1, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1734( 19) ;
            RcdFound34 = 1;
            A307DocArqSeq = BC00173_A307DocArqSeq[0];
            A310DocArqInsDataHora = BC00173_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC00173_A308DocArqInsData[0];
            A309DocArqInsHora = BC00173_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC00173_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC00173_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = BC00173_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC00173_n319DocArqDelDataHora[0];
            A317DocArqDelData = BC00173_A317DocArqDelData[0];
            n317DocArqDelData = BC00173_n317DocArqDelData[0];
            A511DocArqDelHora = BC00173_A511DocArqDelHora[0];
            n511DocArqDelHora = BC00173_n511DocArqDelHora[0];
            A320DocArqDelUsuID = BC00173_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC00173_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = BC00173_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = BC00173_n509DocArqDelUsuNome[0];
            A312DocArqUpdData = BC00173_A312DocArqUpdData[0];
            n312DocArqUpdData = BC00173_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC00173_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC00173_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC00173_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC00173_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC00173_A315DocArqUsuID[0];
            n315DocArqUsuID = BC00173_n315DocArqUsuID[0];
            A316DocArqDel = BC00173_A316DocArqDel[0];
            A324DocArqObservacao = BC00173_A324DocArqObservacao[0];
            n324DocArqObservacao = BC00173_n324DocArqObservacao[0];
            A644DocArqArmExterno = BC00173_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = BC00173_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC00173_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC00173_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC00173_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A289DocID = BC00173_A289DocID[0];
            A321DocArqConteudo = BC00173_A321DocArqConteudo[0];
            n321DocArqConteudo = BC00173_n321DocArqConteudo[0];
            O316DocArqDel = A316DocArqDel;
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1734( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey1734( ) ;
            }
            Gx_mode = sMode34;
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey1734( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode34;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1734( ) ;
         if ( RcdFound34 == 0 )
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
         CONFIRM_170( ) ;
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

      protected void CheckOptimisticConcurrency1734( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00172 */
            pr_default.execute(0, new Object[] {A289DocID, A307DocArqSeq});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z310DocArqInsDataHora != BC00172_A310DocArqInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z308DocArqInsData ) != DateTimeUtil.ResetTime ( BC00172_A308DocArqInsData[0] ) ) || ( Z309DocArqInsHora != BC00172_A309DocArqInsHora[0] ) || ( StringUtil.StrCmp(Z311DocArqInsUsuID, BC00172_A311DocArqInsUsuID[0]) != 0 ) || ( Z319DocArqDelDataHora != BC00172_A319DocArqDelDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z317DocArqDelData != BC00172_A317DocArqDelData[0] ) || ( Z511DocArqDelHora != BC00172_A511DocArqDelHora[0] ) || ( StringUtil.StrCmp(Z320DocArqDelUsuID, BC00172_A320DocArqDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z509DocArqDelUsuNome, BC00172_A509DocArqDelUsuNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z312DocArqUpdData ) != DateTimeUtil.ResetTime ( BC00172_A312DocArqUpdData[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z313DocArqUpdHora != BC00172_A313DocArqUpdHora[0] ) || ( Z314DocArqUpdDataHora != BC00172_A314DocArqUpdDataHora[0] ) || ( StringUtil.StrCmp(Z315DocArqUsuID, BC00172_A315DocArqUsuID[0]) != 0 ) || ( Z316DocArqDel != BC00172_A316DocArqDel[0] ) || ( StringUtil.StrCmp(Z324DocArqObservacao, BC00172_A324DocArqObservacao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z644DocArqArmExterno != BC00172_A644DocArqArmExterno[0] ) || ( StringUtil.StrCmp(Z645DocArqArmExternoPath, BC00172_A645DocArqArmExternoPath[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento_arquivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor BC00178 */
         pr_default.execute(6, new Object[] {A289DocID});
         if ( (pr_default.getStatus(6) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( Z325DocVersao != BC00178_A325DocVersao[0] ) || ( Z326DocVersaoIDPai != BC00178_A326DocVersaoIDPai[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1734( )
      {
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1734( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1734( 0) ;
            CheckOptimisticConcurrency1734( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1734( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1734( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00179 */
                     pr_default.execute(7, new Object[] {A307DocArqSeq, A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n319DocArqDelDataHora, A319DocArqDelDataHora, n317DocArqDelData, A317DocArqDelData, n511DocArqDelHora, A511DocArqDelHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n509DocArqDelUsuNome, A509DocArqDelUsuNome, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, A316DocArqDel, n321DocArqConteudo, A321DocArqConteudo, n324DocArqObservacao, A324DocArqObservacao, A644DocArqArmExterno, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome, A289DocID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(7) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11734( ) ;
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
               Load1734( ) ;
            }
            EndLevel1734( ) ;
         }
         CloseExtendedTableCursors1734( ) ;
      }

      protected void Update1734( )
      {
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1734( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1734( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1734( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1734( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001710 */
                     pr_default.execute(8, new Object[] {A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n319DocArqDelDataHora, A319DocArqDelDataHora, n317DocArqDelData, A317DocArqDelData, n511DocArqDelHora, A511DocArqDelHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n509DocArqDelUsuNome, A509DocArqDelUsuNome, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, A316DocArqDel, n324DocArqObservacao, A324DocArqObservacao, A644DocArqArmExterno, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome, A289DocID, A307DocArqSeq});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1734( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11734( ) ;
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
            EndLevel1734( ) ;
         }
         CloseExtendedTableCursors1734( ) ;
      }

      protected void DeferredUpdate1734( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC001711 */
            pr_default.execute(9, new Object[] {n321DocArqConteudo, A321DocArqConteudo, A289DocID, A307DocArqSeq});
            pr_default.close(9);
            pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1734( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1734( ) ;
            AfterConfirm1734( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1734( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001712 */
                  pr_default.execute(10, new Object[] {A289DocID, A307DocArqSeq});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN11734( ) ;
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1734( ) ;
         Gx_mode = sMode34;
      }

      protected void OnDeleteControls1734( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC00175 */
            pr_default.execute(3, new Object[] {A289DocID});
            ZM1734( 20) ;
            A306DocUltArqSeq = BC00175_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00175_n306DocUltArqSeq[0];
            A325DocVersao = BC00175_A325DocVersao[0];
            A326DocVersaoIDPai = BC00175_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00175_n326DocVersaoIDPai[0];
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
            pr_default.close(6);
            if ( IsIns( )  )
            {
               A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
               n306DocUltArqSeq = false;
            }
         }
      }

      protected void UpdateTablesN11734( )
      {
         /* Using cursor BC001713 */
         pr_default.execute(11, new Object[] {n306DocUltArqSeq, A306DocUltArqSeq, A289DocID});
         pr_default.close(11);
         pr_default.SmartCacheProvider.SetUpdated("tb_documento");
      }

      protected void EndLevel1734( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(6);
         if ( AnyError == 0 )
         {
            BeforeComplete1734( ) ;
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

      public void ScanKeyStart1734( )
      {
         /* Scan By routine */
         /* Using cursor BC001714 */
         pr_default.execute(12, new Object[] {A289DocID, A307DocArqSeq});
         RcdFound34 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound34 = 1;
            A307DocArqSeq = BC001714_A307DocArqSeq[0];
            A306DocUltArqSeq = BC001714_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC001714_n306DocUltArqSeq[0];
            A310DocArqInsDataHora = BC001714_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC001714_A308DocArqInsData[0];
            A309DocArqInsHora = BC001714_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC001714_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC001714_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = BC001714_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC001714_n319DocArqDelDataHora[0];
            A317DocArqDelData = BC001714_A317DocArqDelData[0];
            n317DocArqDelData = BC001714_n317DocArqDelData[0];
            A511DocArqDelHora = BC001714_A511DocArqDelHora[0];
            n511DocArqDelHora = BC001714_n511DocArqDelHora[0];
            A320DocArqDelUsuID = BC001714_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC001714_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = BC001714_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = BC001714_n509DocArqDelUsuNome[0];
            A325DocVersao = BC001714_A325DocVersao[0];
            A312DocArqUpdData = BC001714_A312DocArqUpdData[0];
            n312DocArqUpdData = BC001714_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC001714_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC001714_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC001714_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC001714_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC001714_A315DocArqUsuID[0];
            n315DocArqUsuID = BC001714_n315DocArqUsuID[0];
            A316DocArqDel = BC001714_A316DocArqDel[0];
            A324DocArqObservacao = BC001714_A324DocArqObservacao[0];
            n324DocArqObservacao = BC001714_n324DocArqObservacao[0];
            A644DocArqArmExterno = BC001714_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = BC001714_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC001714_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC001714_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC001714_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A289DocID = BC001714_A289DocID[0];
            A326DocVersaoIDPai = BC001714_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC001714_n326DocVersaoIDPai[0];
            A321DocArqConteudo = BC001714_A321DocArqConteudo[0];
            n321DocArqConteudo = BC001714_n321DocArqConteudo[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1734( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound34 = 0;
         ScanKeyLoad1734( ) ;
      }

      protected void ScanKeyLoad1734( )
      {
         sMode34 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound34 = 1;
            A307DocArqSeq = BC001714_A307DocArqSeq[0];
            A306DocUltArqSeq = BC001714_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC001714_n306DocUltArqSeq[0];
            A310DocArqInsDataHora = BC001714_A310DocArqInsDataHora[0];
            A308DocArqInsData = BC001714_A308DocArqInsData[0];
            A309DocArqInsHora = BC001714_A309DocArqInsHora[0];
            A311DocArqInsUsuID = BC001714_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = BC001714_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = BC001714_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = BC001714_n319DocArqDelDataHora[0];
            A317DocArqDelData = BC001714_A317DocArqDelData[0];
            n317DocArqDelData = BC001714_n317DocArqDelData[0];
            A511DocArqDelHora = BC001714_A511DocArqDelHora[0];
            n511DocArqDelHora = BC001714_n511DocArqDelHora[0];
            A320DocArqDelUsuID = BC001714_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = BC001714_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = BC001714_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = BC001714_n509DocArqDelUsuNome[0];
            A325DocVersao = BC001714_A325DocVersao[0];
            A312DocArqUpdData = BC001714_A312DocArqUpdData[0];
            n312DocArqUpdData = BC001714_n312DocArqUpdData[0];
            A313DocArqUpdHora = BC001714_A313DocArqUpdHora[0];
            n313DocArqUpdHora = BC001714_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = BC001714_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = BC001714_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = BC001714_A315DocArqUsuID[0];
            n315DocArqUsuID = BC001714_n315DocArqUsuID[0];
            A316DocArqDel = BC001714_A316DocArqDel[0];
            A324DocArqObservacao = BC001714_A324DocArqObservacao[0];
            n324DocArqObservacao = BC001714_n324DocArqObservacao[0];
            A644DocArqArmExterno = BC001714_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = BC001714_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = BC001714_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = BC001714_A323DocArqConteudoExtensao[0];
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = BC001714_A322DocArqConteudoNome[0];
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A289DocID = BC001714_A289DocID[0];
            A326DocVersaoIDPai = BC001714_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC001714_n326DocVersaoIDPai[0];
            A321DocArqConteudo = BC001714_A321DocArqConteudo[0];
            n321DocArqConteudo = BC001714_n321DocArqConteudo[0];
         }
         Gx_mode = sMode34;
      }

      protected void ScanKeyEnd1734( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1734( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1734( )
      {
         /* Before Insert Rules */
         A310DocArqInsDataHora = DateTimeUtil.NowMS( context);
         A311DocArqInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n311DocArqInsUsuID = false;
         A308DocArqInsData = DateTimeUtil.ResetTime( A310DocArqInsDataHora);
         A309DocArqInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A310DocArqInsDataHora));
      }

      protected void BeforeUpdate1734( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A319DocArqDelDataHora = DateTimeUtil.NowMS( context);
            n319DocArqDelDataHora = false;
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A320DocArqDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n320DocArqDelUsuID = false;
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A509DocArqDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n509DocArqDelUsuNome = false;
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A317DocArqDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A319DocArqDelDataHora) ) ;
            n317DocArqDelData = false;
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A511DocArqDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A319DocArqDelDataHora));
            n511DocArqDelHora = false;
         }
      }

      protected void BeforeDelete1734( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
      }

      protected void BeforeComplete1734( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1734( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1734( )
      {
      }

      protected void send_integrity_lvl_hashes1734( )
      {
      }

      protected void AddRow1734( )
      {
         VarsToRow34( bccore_DocumentoArquivo) ;
      }

      protected void ReadRow1734( )
      {
         RowToVars34( bccore_DocumentoArquivo, 1) ;
      }

      protected void InitializeNonKey1734( )
      {
         AV25AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A306DocUltArqSeq = 0;
         n306DocUltArqSeq = false;
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A308DocArqInsData = DateTime.MinValue;
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A311DocArqInsUsuID = "";
         n311DocArqInsUsuID = false;
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         n319DocArqDelDataHora = false;
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         n317DocArqDelData = false;
         A511DocArqDelHora = (DateTime)(DateTime.MinValue);
         n511DocArqDelHora = false;
         A320DocArqDelUsuID = "";
         n320DocArqDelUsuID = false;
         A509DocArqDelUsuNome = "";
         n509DocArqDelUsuNome = false;
         A325DocVersao = 0;
         A326DocVersaoIDPai = Guid.Empty;
         n326DocVersaoIDPai = false;
         A312DocArqUpdData = DateTime.MinValue;
         n312DocArqUpdData = false;
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         n313DocArqUpdHora = false;
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         n314DocArqUpdDataHora = false;
         A315DocArqUsuID = "";
         n315DocArqUsuID = false;
         A321DocArqConteudo = "";
         n321DocArqConteudo = false;
         A324DocArqObservacao = "";
         n324DocArqObservacao = false;
         A645DocArqArmExternoPath = "";
         n645DocArqArmExternoPath = false;
         A323DocArqConteudoExtensao = "";
         A322DocArqConteudoNome = "";
         A316DocArqDel = false;
         A644DocArqArmExterno = false;
         O316DocArqDel = A316DocArqDel;
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z511DocArqDelHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         Z509DocArqDelUsuNome = "";
         Z312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         Z316DocArqDel = false;
         Z324DocArqObservacao = "";
         Z644DocArqArmExterno = false;
         Z645DocArqArmExternoPath = "";
         Z325DocVersao = 0;
         Z326DocVersaoIDPai = Guid.Empty;
      }

      protected void InitAll1734( )
      {
         A289DocID = Guid.Empty;
         A307DocArqSeq = 0;
         InitializeNonKey1734( ) ;
      }

      protected void StandaloneModalInsert( )
      {
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

      public void VarsToRow34( GeneXus.Programs.core.SdtDocumentoArquivo obj34 )
      {
         obj34.gxTpr_Mode = Gx_mode;
         obj34.gxTpr_Docultarqseq = A306DocUltArqSeq;
         obj34.gxTpr_Docarqinsdatahora = A310DocArqInsDataHora;
         obj34.gxTpr_Docarqinsdata = A308DocArqInsData;
         obj34.gxTpr_Docarqinshora = A309DocArqInsHora;
         obj34.gxTpr_Docarqinsusuid = A311DocArqInsUsuID;
         obj34.gxTpr_Docarqdeldatahora = A319DocArqDelDataHora;
         obj34.gxTpr_Docarqdeldata = A317DocArqDelData;
         obj34.gxTpr_Docarqdelhora = A511DocArqDelHora;
         obj34.gxTpr_Docarqdelusuid = A320DocArqDelUsuID;
         obj34.gxTpr_Docarqdelusunome = A509DocArqDelUsuNome;
         obj34.gxTpr_Docversao = A325DocVersao;
         obj34.gxTpr_Docversaoidpai = A326DocVersaoIDPai;
         obj34.gxTpr_Docarqupddata = A312DocArqUpdData;
         obj34.gxTpr_Docarqupdhora = A313DocArqUpdHora;
         obj34.gxTpr_Docarqupddatahora = A314DocArqUpdDataHora;
         obj34.gxTpr_Docarqusuid = A315DocArqUsuID;
         obj34.gxTpr_Docarqconteudo = A321DocArqConteudo;
         obj34.gxTpr_Docarqobservacao = A324DocArqObservacao;
         obj34.gxTpr_Docarqarmexternopath = A645DocArqArmExternoPath;
         obj34.gxTpr_Docarqconteudoextensao = A323DocArqConteudoExtensao;
         obj34.gxTpr_Docarqconteudonome = A322DocArqConteudoNome;
         obj34.gxTpr_Docarqdel = A316DocArqDel;
         obj34.gxTpr_Docarqarmexterno = A644DocArqArmExterno;
         obj34.gxTpr_Docid = A289DocID;
         obj34.gxTpr_Docarqseq = A307DocArqSeq;
         obj34.gxTpr_Docid_Z = Z289DocID;
         obj34.gxTpr_Docultarqseq_Z = Z306DocUltArqSeq;
         obj34.gxTpr_Docversao_Z = Z325DocVersao;
         obj34.gxTpr_Docversaoidpai_Z = Z326DocVersaoIDPai;
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
         obj34.gxTpr_Docarqdeldatahora_Z = Z319DocArqDelDataHora;
         obj34.gxTpr_Docarqdeldata_Z = Z317DocArqDelData;
         obj34.gxTpr_Docarqdelhora_Z = Z511DocArqDelHora;
         obj34.gxTpr_Docarqdelusuid_Z = Z320DocArqDelUsuID;
         obj34.gxTpr_Docarqdelusunome_Z = Z509DocArqDelUsuNome;
         obj34.gxTpr_Docarqconteudonome_Z = Z322DocArqConteudoNome;
         obj34.gxTpr_Docarqconteudoextensao_Z = Z323DocArqConteudoExtensao;
         obj34.gxTpr_Docarqobservacao_Z = Z324DocArqObservacao;
         obj34.gxTpr_Docarqarmexterno_Z = Z644DocArqArmExterno;
         obj34.gxTpr_Docarqarmexternopath_Z = Z645DocArqArmExternoPath;
         obj34.gxTpr_Docultarqseq_N = (short)(Convert.ToInt16(n306DocUltArqSeq));
         obj34.gxTpr_Docversaoidpai_N = (short)(Convert.ToInt16(n326DocVersaoIDPai));
         obj34.gxTpr_Docarqinsusuid_N = (short)(Convert.ToInt16(n311DocArqInsUsuID));
         obj34.gxTpr_Docarqupddata_N = (short)(Convert.ToInt16(n312DocArqUpdData));
         obj34.gxTpr_Docarqupdhora_N = (short)(Convert.ToInt16(n313DocArqUpdHora));
         obj34.gxTpr_Docarqupddatahora_N = (short)(Convert.ToInt16(n314DocArqUpdDataHora));
         obj34.gxTpr_Docarqusuid_N = (short)(Convert.ToInt16(n315DocArqUsuID));
         obj34.gxTpr_Docarqdeldatahora_N = (short)(Convert.ToInt16(n319DocArqDelDataHora));
         obj34.gxTpr_Docarqdeldata_N = (short)(Convert.ToInt16(n317DocArqDelData));
         obj34.gxTpr_Docarqdelhora_N = (short)(Convert.ToInt16(n511DocArqDelHora));
         obj34.gxTpr_Docarqdelusuid_N = (short)(Convert.ToInt16(n320DocArqDelUsuID));
         obj34.gxTpr_Docarqdelusunome_N = (short)(Convert.ToInt16(n509DocArqDelUsuNome));
         obj34.gxTpr_Docarqconteudo_N = (short)(Convert.ToInt16(n321DocArqConteudo));
         obj34.gxTpr_Docarqobservacao_N = (short)(Convert.ToInt16(n324DocArqObservacao));
         obj34.gxTpr_Docarqarmexternopath_N = (short)(Convert.ToInt16(n645DocArqArmExternoPath));
         obj34.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow34( GeneXus.Programs.core.SdtDocumentoArquivo obj34 )
      {
         obj34.gxTpr_Docid = A289DocID;
         obj34.gxTpr_Docarqseq = A307DocArqSeq;
         return  ;
      }

      public void RowToVars34( GeneXus.Programs.core.SdtDocumentoArquivo obj34 ,
                               int forceLoad )
      {
         Gx_mode = obj34.gxTpr_Mode;
         if ( forceLoad == 1 )
         {
            A306DocUltArqSeq = obj34.gxTpr_Docultarqseq;
            n306DocUltArqSeq = false;
         }
         A310DocArqInsDataHora = obj34.gxTpr_Docarqinsdatahora;
         A308DocArqInsData = obj34.gxTpr_Docarqinsdata;
         A309DocArqInsHora = obj34.gxTpr_Docarqinshora;
         A311DocArqInsUsuID = obj34.gxTpr_Docarqinsusuid;
         n311DocArqInsUsuID = false;
         A319DocArqDelDataHora = obj34.gxTpr_Docarqdeldatahora;
         n319DocArqDelDataHora = false;
         A317DocArqDelData = obj34.gxTpr_Docarqdeldata;
         n317DocArqDelData = false;
         A511DocArqDelHora = obj34.gxTpr_Docarqdelhora;
         n511DocArqDelHora = false;
         A320DocArqDelUsuID = obj34.gxTpr_Docarqdelusuid;
         n320DocArqDelUsuID = false;
         A509DocArqDelUsuNome = obj34.gxTpr_Docarqdelusunome;
         n509DocArqDelUsuNome = false;
         A325DocVersao = obj34.gxTpr_Docversao;
         A326DocVersaoIDPai = obj34.gxTpr_Docversaoidpai;
         n326DocVersaoIDPai = false;
         A312DocArqUpdData = obj34.gxTpr_Docarqupddata;
         n312DocArqUpdData = false;
         A313DocArqUpdHora = obj34.gxTpr_Docarqupdhora;
         n313DocArqUpdHora = false;
         A314DocArqUpdDataHora = obj34.gxTpr_Docarqupddatahora;
         n314DocArqUpdDataHora = false;
         A315DocArqUsuID = obj34.gxTpr_Docarqusuid;
         n315DocArqUsuID = false;
         A321DocArqConteudo = obj34.gxTpr_Docarqconteudo;
         n321DocArqConteudo = false;
         A324DocArqObservacao = obj34.gxTpr_Docarqobservacao;
         n324DocArqObservacao = false;
         A645DocArqArmExternoPath = obj34.gxTpr_Docarqarmexternopath;
         n645DocArqArmExternoPath = false;
         A323DocArqConteudoExtensao = (String.IsNullOrEmpty(StringUtil.RTrim( obj34.gxTpr_Docarqconteudoextensao)) ? FileUtil.GetFileType( A321DocArqConteudo) : obj34.gxTpr_Docarqconteudoextensao);
         A322DocArqConteudoNome = (String.IsNullOrEmpty(StringUtil.RTrim( obj34.gxTpr_Docarqconteudonome)) ? FileUtil.GetFileName( A321DocArqConteudo) : obj34.gxTpr_Docarqconteudonome);
         A316DocArqDel = obj34.gxTpr_Docarqdel;
         A644DocArqArmExterno = obj34.gxTpr_Docarqarmexterno;
         A289DocID = obj34.gxTpr_Docid;
         A307DocArqSeq = obj34.gxTpr_Docarqseq;
         Z289DocID = obj34.gxTpr_Docid_Z;
         Z306DocUltArqSeq = obj34.gxTpr_Docultarqseq_Z;
         O306DocUltArqSeq = obj34.gxTpr_Docultarqseq_Z;
         Z325DocVersao = obj34.gxTpr_Docversao_Z;
         Z326DocVersaoIDPai = obj34.gxTpr_Docversaoidpai_Z;
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
         O316DocArqDel = obj34.gxTpr_Docarqdel_Z;
         Z319DocArqDelDataHora = obj34.gxTpr_Docarqdeldatahora_Z;
         Z317DocArqDelData = obj34.gxTpr_Docarqdeldata_Z;
         Z511DocArqDelHora = obj34.gxTpr_Docarqdelhora_Z;
         Z320DocArqDelUsuID = obj34.gxTpr_Docarqdelusuid_Z;
         Z509DocArqDelUsuNome = obj34.gxTpr_Docarqdelusunome_Z;
         Z322DocArqConteudoNome = obj34.gxTpr_Docarqconteudonome_Z;
         Z323DocArqConteudoExtensao = obj34.gxTpr_Docarqconteudoextensao_Z;
         Z324DocArqObservacao = obj34.gxTpr_Docarqobservacao_Z;
         Z644DocArqArmExterno = obj34.gxTpr_Docarqarmexterno_Z;
         Z645DocArqArmExternoPath = obj34.gxTpr_Docarqarmexternopath_Z;
         n306DocUltArqSeq = (bool)(Convert.ToBoolean(obj34.gxTpr_Docultarqseq_N));
         n326DocVersaoIDPai = (bool)(Convert.ToBoolean(obj34.gxTpr_Docversaoidpai_N));
         n311DocArqInsUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqinsusuid_N));
         n312DocArqUpdData = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupddata_N));
         n313DocArqUpdHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupdhora_N));
         n314DocArqUpdDataHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqupddatahora_N));
         n315DocArqUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqusuid_N));
         n319DocArqDelDataHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdeldatahora_N));
         n317DocArqDelData = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdeldata_N));
         n511DocArqDelHora = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdelhora_N));
         n320DocArqDelUsuID = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdelusuid_N));
         n509DocArqDelUsuNome = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqdelusunome_N));
         n321DocArqConteudo = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqconteudo_N));
         n324DocArqObservacao = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqobservacao_N));
         n645DocArqArmExternoPath = (bool)(Convert.ToBoolean(obj34.gxTpr_Docarqarmexternopath_N));
         Gx_mode = obj34.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A289DocID = (Guid)getParm(obj,0);
         A307DocArqSeq = (short)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1734( ) ;
         ScanKeyStart1734( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC00175 */
            pr_default.execute(3, new Object[] {A289DocID});
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
               AnyError = 1;
            }
            A306DocUltArqSeq = BC00175_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00175_n306DocUltArqSeq[0];
            A325DocVersao = BC00175_A325DocVersao[0];
            A326DocVersaoIDPai = BC00175_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00175_n326DocVersaoIDPai[0];
            pr_default.close(3);
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            O316DocArqDel = A316DocArqDel;
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         ZM1734( -19) ;
         OnLoadActions1734( ) ;
         AddRow1734( ) ;
         ScanKeyEnd1734( ) ;
         if ( RcdFound34 == 0 )
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
         RowToVars34( bccore_DocumentoArquivo, 0) ;
         ScanKeyStart1734( ) ;
         if ( RcdFound34 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC00175 */
            pr_default.execute(3, new Object[] {A289DocID});
            if ( (pr_default.getStatus(3) == 101) )
            {
               GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
               AnyError = 1;
            }
            A306DocUltArqSeq = BC00175_A306DocUltArqSeq[0];
            n306DocUltArqSeq = BC00175_n306DocUltArqSeq[0];
            A325DocVersao = BC00175_A325DocVersao[0];
            A326DocVersaoIDPai = BC00175_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = BC00175_n326DocVersaoIDPai[0];
            pr_default.close(3);
         }
         else
         {
            Gx_mode = "UPD";
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            O316DocArqDel = A316DocArqDel;
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
         }
         ZM1734( -19) ;
         OnLoadActions1734( ) ;
         AddRow1734( ) ;
         ScanKeyEnd1734( ) ;
         if ( RcdFound34 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1734( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1734( ) ;
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
               {
                  A289DocID = Z289DocID;
                  A307DocArqSeq = Z307DocArqSeq;
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
                  Update1734( ) ;
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
                  if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
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
                        Insert1734( ) ;
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
                        Insert1734( ) ;
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
         RowToVars34( bccore_DocumentoArquivo, 1) ;
         SaveImpl( ) ;
         VarsToRow34( bccore_DocumentoArquivo) ;
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
         RowToVars34( bccore_DocumentoArquivo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1734( ) ;
         AfterTrn( ) ;
         VarsToRow34( bccore_DocumentoArquivo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow34( bccore_DocumentoArquivo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtDocumentoArquivo auxBC = new GeneXus.Programs.core.SdtDocumentoArquivo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A289DocID, A307DocArqSeq);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_DocumentoArquivo);
               auxBC.Save();
               bccore_DocumentoArquivo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars34( bccore_DocumentoArquivo, 1) ;
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
         RowToVars34( bccore_DocumentoArquivo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1734( ) ;
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
               VarsToRow34( bccore_DocumentoArquivo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow34( bccore_DocumentoArquivo) ;
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
         RowToVars34( bccore_DocumentoArquivo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1734( ) ;
         if ( RcdFound34 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
            {
               A289DocID = Z289DocID;
               A307DocArqSeq = Z307DocArqSeq;
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
            if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
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
         context.RollbackDataStores("core.documentoarquivo_bc",pr_default);
         VarsToRow34( bccore_DocumentoArquivo) ;
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
         Gx_mode = bccore_DocumentoArquivo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_DocumentoArquivo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_DocumentoArquivo )
         {
            bccore_DocumentoArquivo = (GeneXus.Programs.core.SdtDocumentoArquivo)(sdt);
            if ( StringUtil.StrCmp(bccore_DocumentoArquivo.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoArquivo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow34( bccore_DocumentoArquivo) ;
            }
            else
            {
               RowToVars34( bccore_DocumentoArquivo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_DocumentoArquivo.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoArquivo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars34( bccore_DocumentoArquivo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocumentoArquivo DocumentoArquivo_BC
      {
         get {
            return bccore_DocumentoArquivo ;
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
         AV25AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV26Pgmname = "";
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         A308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         A311DocArqInsUsuID = "";
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z511DocArqDelHora = (DateTime)(DateTime.MinValue);
         A511DocArqDelHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         A320DocArqDelUsuID = "";
         Z509DocArqDelUsuNome = "";
         A509DocArqDelUsuNome = "";
         Z312DocArqUpdData = DateTime.MinValue;
         A312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         A315DocArqUsuID = "";
         Z324DocArqObservacao = "";
         A324DocArqObservacao = "";
         Z645DocArqArmExternoPath = "";
         A645DocArqArmExternoPath = "";
         Z326DocVersaoIDPai = Guid.Empty;
         A326DocVersaoIDPai = Guid.Empty;
         Z321DocArqConteudo = "";
         A321DocArqConteudo = "";
         Z323DocArqConteudoExtensao = "";
         A323DocArqConteudoExtensao = "";
         Z322DocArqConteudoNome = "";
         A322DocArqConteudoNome = "";
         BC00176_A307DocArqSeq = new short[1] ;
         BC00176_A306DocUltArqSeq = new short[1] ;
         BC00176_n306DocUltArqSeq = new bool[] {false} ;
         BC00176_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC00176_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_A311DocArqInsUsuID = new string[] {""} ;
         BC00176_n311DocArqInsUsuID = new bool[] {false} ;
         BC00176_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_n319DocArqDelDataHora = new bool[] {false} ;
         BC00176_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC00176_n317DocArqDelData = new bool[] {false} ;
         BC00176_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_n511DocArqDelHora = new bool[] {false} ;
         BC00176_A320DocArqDelUsuID = new string[] {""} ;
         BC00176_n320DocArqDelUsuID = new bool[] {false} ;
         BC00176_A509DocArqDelUsuNome = new string[] {""} ;
         BC00176_n509DocArqDelUsuNome = new bool[] {false} ;
         BC00176_A325DocVersao = new short[1] ;
         BC00176_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00176_n312DocArqUpdData = new bool[] {false} ;
         BC00176_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_n313DocArqUpdHora = new bool[] {false} ;
         BC00176_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00176_n314DocArqUpdDataHora = new bool[] {false} ;
         BC00176_A315DocArqUsuID = new string[] {""} ;
         BC00176_n315DocArqUsuID = new bool[] {false} ;
         BC00176_A316DocArqDel = new bool[] {false} ;
         BC00176_A324DocArqObservacao = new string[] {""} ;
         BC00176_n324DocArqObservacao = new bool[] {false} ;
         BC00176_A644DocArqArmExterno = new bool[] {false} ;
         BC00176_A645DocArqArmExternoPath = new string[] {""} ;
         BC00176_n645DocArqArmExternoPath = new bool[] {false} ;
         BC00176_A323DocArqConteudoExtensao = new string[] {""} ;
         BC00176_A322DocArqConteudoNome = new string[] {""} ;
         BC00176_A289DocID = new Guid[] {Guid.Empty} ;
         BC00176_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00176_n326DocVersaoIDPai = new bool[] {false} ;
         BC00176_A321DocArqConteudo = new string[] {""} ;
         BC00176_n321DocArqConteudo = new bool[] {false} ;
         A321DocArqConteudo_Filetype = "";
         A321DocArqConteudo_Filename = "";
         BC00175_A306DocUltArqSeq = new short[1] ;
         BC00175_n306DocUltArqSeq = new bool[] {false} ;
         BC00175_A325DocVersao = new short[1] ;
         BC00175_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00175_n326DocVersaoIDPai = new bool[] {false} ;
         BC00177_A289DocID = new Guid[] {Guid.Empty} ;
         BC00177_A307DocArqSeq = new short[1] ;
         BC00173_A307DocArqSeq = new short[1] ;
         BC00173_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC00173_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_A311DocArqInsUsuID = new string[] {""} ;
         BC00173_n311DocArqInsUsuID = new bool[] {false} ;
         BC00173_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_n319DocArqDelDataHora = new bool[] {false} ;
         BC00173_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC00173_n317DocArqDelData = new bool[] {false} ;
         BC00173_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_n511DocArqDelHora = new bool[] {false} ;
         BC00173_A320DocArqDelUsuID = new string[] {""} ;
         BC00173_n320DocArqDelUsuID = new bool[] {false} ;
         BC00173_A509DocArqDelUsuNome = new string[] {""} ;
         BC00173_n509DocArqDelUsuNome = new bool[] {false} ;
         BC00173_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00173_n312DocArqUpdData = new bool[] {false} ;
         BC00173_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_n313DocArqUpdHora = new bool[] {false} ;
         BC00173_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00173_n314DocArqUpdDataHora = new bool[] {false} ;
         BC00173_A315DocArqUsuID = new string[] {""} ;
         BC00173_n315DocArqUsuID = new bool[] {false} ;
         BC00173_A316DocArqDel = new bool[] {false} ;
         BC00173_A324DocArqObservacao = new string[] {""} ;
         BC00173_n324DocArqObservacao = new bool[] {false} ;
         BC00173_A644DocArqArmExterno = new bool[] {false} ;
         BC00173_A645DocArqArmExternoPath = new string[] {""} ;
         BC00173_n645DocArqArmExternoPath = new bool[] {false} ;
         BC00173_A323DocArqConteudoExtensao = new string[] {""} ;
         BC00173_A322DocArqConteudoNome = new string[] {""} ;
         BC00173_A289DocID = new Guid[] {Guid.Empty} ;
         BC00173_A321DocArqConteudo = new string[] {""} ;
         BC00173_n321DocArqConteudo = new bool[] {false} ;
         sMode34 = "";
         BC00172_A307DocArqSeq = new short[1] ;
         BC00172_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC00172_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_A311DocArqInsUsuID = new string[] {""} ;
         BC00172_n311DocArqInsUsuID = new bool[] {false} ;
         BC00172_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_n319DocArqDelDataHora = new bool[] {false} ;
         BC00172_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC00172_n317DocArqDelData = new bool[] {false} ;
         BC00172_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_n511DocArqDelHora = new bool[] {false} ;
         BC00172_A320DocArqDelUsuID = new string[] {""} ;
         BC00172_n320DocArqDelUsuID = new bool[] {false} ;
         BC00172_A509DocArqDelUsuNome = new string[] {""} ;
         BC00172_n509DocArqDelUsuNome = new bool[] {false} ;
         BC00172_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00172_n312DocArqUpdData = new bool[] {false} ;
         BC00172_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_n313DocArqUpdHora = new bool[] {false} ;
         BC00172_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00172_n314DocArqUpdDataHora = new bool[] {false} ;
         BC00172_A315DocArqUsuID = new string[] {""} ;
         BC00172_n315DocArqUsuID = new bool[] {false} ;
         BC00172_A316DocArqDel = new bool[] {false} ;
         BC00172_A324DocArqObservacao = new string[] {""} ;
         BC00172_n324DocArqObservacao = new bool[] {false} ;
         BC00172_A644DocArqArmExterno = new bool[] {false} ;
         BC00172_A645DocArqArmExternoPath = new string[] {""} ;
         BC00172_n645DocArqArmExternoPath = new bool[] {false} ;
         BC00172_A323DocArqConteudoExtensao = new string[] {""} ;
         BC00172_A322DocArqConteudoNome = new string[] {""} ;
         BC00172_A289DocID = new Guid[] {Guid.Empty} ;
         BC00172_A321DocArqConteudo = new string[] {""} ;
         BC00172_n321DocArqConteudo = new bool[] {false} ;
         BC00178_A306DocUltArqSeq = new short[1] ;
         BC00178_n306DocUltArqSeq = new bool[] {false} ;
         BC00178_A325DocVersao = new short[1] ;
         BC00178_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC00178_n326DocVersaoIDPai = new bool[] {false} ;
         BC001714_A307DocArqSeq = new short[1] ;
         BC001714_A306DocUltArqSeq = new short[1] ;
         BC001714_n306DocUltArqSeq = new bool[] {false} ;
         BC001714_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         BC001714_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_A311DocArqInsUsuID = new string[] {""} ;
         BC001714_n311DocArqInsUsuID = new bool[] {false} ;
         BC001714_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_n319DocArqDelDataHora = new bool[] {false} ;
         BC001714_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         BC001714_n317DocArqDelData = new bool[] {false} ;
         BC001714_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_n511DocArqDelHora = new bool[] {false} ;
         BC001714_A320DocArqDelUsuID = new string[] {""} ;
         BC001714_n320DocArqDelUsuID = new bool[] {false} ;
         BC001714_A509DocArqDelUsuNome = new string[] {""} ;
         BC001714_n509DocArqDelUsuNome = new bool[] {false} ;
         BC001714_A325DocVersao = new short[1] ;
         BC001714_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001714_n312DocArqUpdData = new bool[] {false} ;
         BC001714_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_n313DocArqUpdHora = new bool[] {false} ;
         BC001714_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001714_n314DocArqUpdDataHora = new bool[] {false} ;
         BC001714_A315DocArqUsuID = new string[] {""} ;
         BC001714_n315DocArqUsuID = new bool[] {false} ;
         BC001714_A316DocArqDel = new bool[] {false} ;
         BC001714_A324DocArqObservacao = new string[] {""} ;
         BC001714_n324DocArqObservacao = new bool[] {false} ;
         BC001714_A644DocArqArmExterno = new bool[] {false} ;
         BC001714_A645DocArqArmExternoPath = new string[] {""} ;
         BC001714_n645DocArqArmExternoPath = new bool[] {false} ;
         BC001714_A323DocArqConteudoExtensao = new string[] {""} ;
         BC001714_A322DocArqConteudoNome = new string[] {""} ;
         BC001714_A289DocID = new Guid[] {Guid.Empty} ;
         BC001714_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         BC001714_n326DocVersaoIDPai = new bool[] {false} ;
         BC001714_A321DocArqConteudo = new string[] {""} ;
         BC001714_n321DocArqConteudo = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00172_A307DocArqSeq, BC00172_A310DocArqInsDataHora, BC00172_A308DocArqInsData, BC00172_A309DocArqInsHora, BC00172_A311DocArqInsUsuID, BC00172_n311DocArqInsUsuID, BC00172_A319DocArqDelDataHora, BC00172_n319DocArqDelDataHora, BC00172_A317DocArqDelData, BC00172_n317DocArqDelData,
               BC00172_A511DocArqDelHora, BC00172_n511DocArqDelHora, BC00172_A320DocArqDelUsuID, BC00172_n320DocArqDelUsuID, BC00172_A509DocArqDelUsuNome, BC00172_n509DocArqDelUsuNome, BC00172_A312DocArqUpdData, BC00172_n312DocArqUpdData, BC00172_A313DocArqUpdHora, BC00172_n313DocArqUpdHora,
               BC00172_A314DocArqUpdDataHora, BC00172_n314DocArqUpdDataHora, BC00172_A315DocArqUsuID, BC00172_n315DocArqUsuID, BC00172_A316DocArqDel, BC00172_A324DocArqObservacao, BC00172_n324DocArqObservacao, BC00172_A644DocArqArmExterno, BC00172_A645DocArqArmExternoPath, BC00172_n645DocArqArmExternoPath,
               BC00172_A323DocArqConteudoExtensao, BC00172_A322DocArqConteudoNome, BC00172_A289DocID, BC00172_A321DocArqConteudo, BC00172_n321DocArqConteudo
               }
               , new Object[] {
               BC00173_A307DocArqSeq, BC00173_A310DocArqInsDataHora, BC00173_A308DocArqInsData, BC00173_A309DocArqInsHora, BC00173_A311DocArqInsUsuID, BC00173_n311DocArqInsUsuID, BC00173_A319DocArqDelDataHora, BC00173_n319DocArqDelDataHora, BC00173_A317DocArqDelData, BC00173_n317DocArqDelData,
               BC00173_A511DocArqDelHora, BC00173_n511DocArqDelHora, BC00173_A320DocArqDelUsuID, BC00173_n320DocArqDelUsuID, BC00173_A509DocArqDelUsuNome, BC00173_n509DocArqDelUsuNome, BC00173_A312DocArqUpdData, BC00173_n312DocArqUpdData, BC00173_A313DocArqUpdHora, BC00173_n313DocArqUpdHora,
               BC00173_A314DocArqUpdDataHora, BC00173_n314DocArqUpdDataHora, BC00173_A315DocArqUsuID, BC00173_n315DocArqUsuID, BC00173_A316DocArqDel, BC00173_A324DocArqObservacao, BC00173_n324DocArqObservacao, BC00173_A644DocArqArmExterno, BC00173_A645DocArqArmExternoPath, BC00173_n645DocArqArmExternoPath,
               BC00173_A323DocArqConteudoExtensao, BC00173_A322DocArqConteudoNome, BC00173_A289DocID, BC00173_A321DocArqConteudo, BC00173_n321DocArqConteudo
               }
               , new Object[] {
               BC00174_A306DocUltArqSeq, BC00174_n306DocUltArqSeq, BC00174_A325DocVersao, BC00174_A326DocVersaoIDPai, BC00174_n326DocVersaoIDPai
               }
               , new Object[] {
               BC00175_A306DocUltArqSeq, BC00175_n306DocUltArqSeq, BC00175_A325DocVersao, BC00175_A326DocVersaoIDPai, BC00175_n326DocVersaoIDPai
               }
               , new Object[] {
               BC00176_A307DocArqSeq, BC00176_A306DocUltArqSeq, BC00176_n306DocUltArqSeq, BC00176_A310DocArqInsDataHora, BC00176_A308DocArqInsData, BC00176_A309DocArqInsHora, BC00176_A311DocArqInsUsuID, BC00176_n311DocArqInsUsuID, BC00176_A319DocArqDelDataHora, BC00176_n319DocArqDelDataHora,
               BC00176_A317DocArqDelData, BC00176_n317DocArqDelData, BC00176_A511DocArqDelHora, BC00176_n511DocArqDelHora, BC00176_A320DocArqDelUsuID, BC00176_n320DocArqDelUsuID, BC00176_A509DocArqDelUsuNome, BC00176_n509DocArqDelUsuNome, BC00176_A325DocVersao, BC00176_A312DocArqUpdData,
               BC00176_n312DocArqUpdData, BC00176_A313DocArqUpdHora, BC00176_n313DocArqUpdHora, BC00176_A314DocArqUpdDataHora, BC00176_n314DocArqUpdDataHora, BC00176_A315DocArqUsuID, BC00176_n315DocArqUsuID, BC00176_A316DocArqDel, BC00176_A324DocArqObservacao, BC00176_n324DocArqObservacao,
               BC00176_A644DocArqArmExterno, BC00176_A645DocArqArmExternoPath, BC00176_n645DocArqArmExternoPath, BC00176_A323DocArqConteudoExtensao, BC00176_A322DocArqConteudoNome, BC00176_A289DocID, BC00176_A326DocVersaoIDPai, BC00176_n326DocVersaoIDPai, BC00176_A321DocArqConteudo, BC00176_n321DocArqConteudo
               }
               , new Object[] {
               BC00177_A289DocID, BC00177_A307DocArqSeq
               }
               , new Object[] {
               BC00178_A306DocUltArqSeq, BC00178_n306DocUltArqSeq, BC00178_A325DocVersao, BC00178_A326DocVersaoIDPai, BC00178_n326DocVersaoIDPai
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
               }
               , new Object[] {
               BC001714_A307DocArqSeq, BC001714_A306DocUltArqSeq, BC001714_n306DocUltArqSeq, BC001714_A310DocArqInsDataHora, BC001714_A308DocArqInsData, BC001714_A309DocArqInsHora, BC001714_A311DocArqInsUsuID, BC001714_n311DocArqInsUsuID, BC001714_A319DocArqDelDataHora, BC001714_n319DocArqDelDataHora,
               BC001714_A317DocArqDelData, BC001714_n317DocArqDelData, BC001714_A511DocArqDelHora, BC001714_n511DocArqDelHora, BC001714_A320DocArqDelUsuID, BC001714_n320DocArqDelUsuID, BC001714_A509DocArqDelUsuNome, BC001714_n509DocArqDelUsuNome, BC001714_A325DocVersao, BC001714_A312DocArqUpdData,
               BC001714_n312DocArqUpdData, BC001714_A313DocArqUpdHora, BC001714_n313DocArqUpdHora, BC001714_A314DocArqUpdDataHora, BC001714_n314DocArqUpdDataHora, BC001714_A315DocArqUsuID, BC001714_n315DocArqUsuID, BC001714_A316DocArqDel, BC001714_A324DocArqObservacao, BC001714_n324DocArqObservacao,
               BC001714_A644DocArqArmExterno, BC001714_A645DocArqArmExternoPath, BC001714_n645DocArqArmExternoPath, BC001714_A323DocArqConteudoExtensao, BC001714_A322DocArqConteudoNome, BC001714_A289DocID, BC001714_A326DocVersaoIDPai, BC001714_n326DocVersaoIDPai, BC001714_A321DocArqConteudo, BC001714_n321DocArqConteudo
               }
            }
         );
         Z644DocArqArmExterno = false;
         A644DocArqArmExterno = false;
         i644DocArqArmExterno = false;
         Z316DocArqDel = false;
         A316DocArqDel = false;
         i316DocArqDel = false;
         AV26Pgmname = "core.DocumentoArquivo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12172 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short Z307DocArqSeq ;
      private short A307DocArqSeq ;
      private short GX_JID ;
      private short Z325DocVersao ;
      private short A325DocVersao ;
      private short Z306DocUltArqSeq ;
      private short A306DocUltArqSeq ;
      private short Gx_BScreen ;
      private short RcdFound34 ;
      private short O306DocUltArqSeq ;
      private short nIsDirty_34 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV26Pgmname ;
      private string Z311DocArqInsUsuID ;
      private string A311DocArqInsUsuID ;
      private string Z320DocArqDelUsuID ;
      private string A320DocArqDelUsuID ;
      private string Z315DocArqUsuID ;
      private string A315DocArqUsuID ;
      private string A321DocArqConteudo_Filetype ;
      private string A321DocArqConteudo_Filename ;
      private string sMode34 ;
      private DateTime Z310DocArqInsDataHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime Z309DocArqInsHora ;
      private DateTime A309DocArqInsHora ;
      private DateTime Z319DocArqDelDataHora ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime Z317DocArqDelData ;
      private DateTime A317DocArqDelData ;
      private DateTime Z511DocArqDelHora ;
      private DateTime A511DocArqDelHora ;
      private DateTime Z313DocArqUpdHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime Z314DocArqUpdDataHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime Z308DocArqInsData ;
      private DateTime A308DocArqInsData ;
      private DateTime Z312DocArqUpdData ;
      private DateTime A312DocArqUpdData ;
      private bool returnInSub ;
      private bool Z316DocArqDel ;
      private bool A316DocArqDel ;
      private bool Z644DocArqArmExterno ;
      private bool A644DocArqArmExterno ;
      private bool n306DocUltArqSeq ;
      private bool n311DocArqInsUsuID ;
      private bool n319DocArqDelDataHora ;
      private bool n317DocArqDelData ;
      private bool n511DocArqDelHora ;
      private bool n320DocArqDelUsuID ;
      private bool n509DocArqDelUsuNome ;
      private bool n312DocArqUpdData ;
      private bool n313DocArqUpdHora ;
      private bool n314DocArqUpdDataHora ;
      private bool n315DocArqUsuID ;
      private bool n324DocArqObservacao ;
      private bool n645DocArqArmExternoPath ;
      private bool n326DocVersaoIDPai ;
      private bool n321DocArqConteudo ;
      private bool O316DocArqDel ;
      private bool Gx_longc ;
      private bool i644DocArqArmExterno ;
      private bool i316DocArqDel ;
      private bool mustCommit ;
      private string Z509DocArqDelUsuNome ;
      private string A509DocArqDelUsuNome ;
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
      private Guid Z326DocVersaoIDPai ;
      private Guid A326DocVersaoIDPai ;
      private string Z321DocArqConteudo ;
      private string A321DocArqConteudo ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtDocumentoArquivo bccore_DocumentoArquivo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] BC00176_A307DocArqSeq ;
      private short[] BC00176_A306DocUltArqSeq ;
      private bool[] BC00176_n306DocUltArqSeq ;
      private DateTime[] BC00176_A310DocArqInsDataHora ;
      private DateTime[] BC00176_A308DocArqInsData ;
      private DateTime[] BC00176_A309DocArqInsHora ;
      private string[] BC00176_A311DocArqInsUsuID ;
      private bool[] BC00176_n311DocArqInsUsuID ;
      private DateTime[] BC00176_A319DocArqDelDataHora ;
      private bool[] BC00176_n319DocArqDelDataHora ;
      private DateTime[] BC00176_A317DocArqDelData ;
      private bool[] BC00176_n317DocArqDelData ;
      private DateTime[] BC00176_A511DocArqDelHora ;
      private bool[] BC00176_n511DocArqDelHora ;
      private string[] BC00176_A320DocArqDelUsuID ;
      private bool[] BC00176_n320DocArqDelUsuID ;
      private string[] BC00176_A509DocArqDelUsuNome ;
      private bool[] BC00176_n509DocArqDelUsuNome ;
      private short[] BC00176_A325DocVersao ;
      private DateTime[] BC00176_A312DocArqUpdData ;
      private bool[] BC00176_n312DocArqUpdData ;
      private DateTime[] BC00176_A313DocArqUpdHora ;
      private bool[] BC00176_n313DocArqUpdHora ;
      private DateTime[] BC00176_A314DocArqUpdDataHora ;
      private bool[] BC00176_n314DocArqUpdDataHora ;
      private string[] BC00176_A315DocArqUsuID ;
      private bool[] BC00176_n315DocArqUsuID ;
      private bool[] BC00176_A316DocArqDel ;
      private string[] BC00176_A324DocArqObservacao ;
      private bool[] BC00176_n324DocArqObservacao ;
      private bool[] BC00176_A644DocArqArmExterno ;
      private string[] BC00176_A645DocArqArmExternoPath ;
      private bool[] BC00176_n645DocArqArmExternoPath ;
      private string[] BC00176_A323DocArqConteudoExtensao ;
      private string[] BC00176_A322DocArqConteudoNome ;
      private Guid[] BC00176_A289DocID ;
      private Guid[] BC00176_A326DocVersaoIDPai ;
      private bool[] BC00176_n326DocVersaoIDPai ;
      private string[] BC00176_A321DocArqConteudo ;
      private bool[] BC00176_n321DocArqConteudo ;
      private short[] BC00175_A306DocUltArqSeq ;
      private bool[] BC00175_n306DocUltArqSeq ;
      private short[] BC00175_A325DocVersao ;
      private Guid[] BC00175_A326DocVersaoIDPai ;
      private bool[] BC00175_n326DocVersaoIDPai ;
      private Guid[] BC00177_A289DocID ;
      private short[] BC00177_A307DocArqSeq ;
      private short[] BC00173_A307DocArqSeq ;
      private DateTime[] BC00173_A310DocArqInsDataHora ;
      private DateTime[] BC00173_A308DocArqInsData ;
      private DateTime[] BC00173_A309DocArqInsHora ;
      private string[] BC00173_A311DocArqInsUsuID ;
      private bool[] BC00173_n311DocArqInsUsuID ;
      private DateTime[] BC00173_A319DocArqDelDataHora ;
      private bool[] BC00173_n319DocArqDelDataHora ;
      private DateTime[] BC00173_A317DocArqDelData ;
      private bool[] BC00173_n317DocArqDelData ;
      private DateTime[] BC00173_A511DocArqDelHora ;
      private bool[] BC00173_n511DocArqDelHora ;
      private string[] BC00173_A320DocArqDelUsuID ;
      private bool[] BC00173_n320DocArqDelUsuID ;
      private string[] BC00173_A509DocArqDelUsuNome ;
      private bool[] BC00173_n509DocArqDelUsuNome ;
      private DateTime[] BC00173_A312DocArqUpdData ;
      private bool[] BC00173_n312DocArqUpdData ;
      private DateTime[] BC00173_A313DocArqUpdHora ;
      private bool[] BC00173_n313DocArqUpdHora ;
      private DateTime[] BC00173_A314DocArqUpdDataHora ;
      private bool[] BC00173_n314DocArqUpdDataHora ;
      private string[] BC00173_A315DocArqUsuID ;
      private bool[] BC00173_n315DocArqUsuID ;
      private bool[] BC00173_A316DocArqDel ;
      private string[] BC00173_A324DocArqObservacao ;
      private bool[] BC00173_n324DocArqObservacao ;
      private bool[] BC00173_A644DocArqArmExterno ;
      private string[] BC00173_A645DocArqArmExternoPath ;
      private bool[] BC00173_n645DocArqArmExternoPath ;
      private string[] BC00173_A323DocArqConteudoExtensao ;
      private string[] BC00173_A322DocArqConteudoNome ;
      private Guid[] BC00173_A289DocID ;
      private string[] BC00173_A321DocArqConteudo ;
      private bool[] BC00173_n321DocArqConteudo ;
      private short[] BC00172_A307DocArqSeq ;
      private DateTime[] BC00172_A310DocArqInsDataHora ;
      private DateTime[] BC00172_A308DocArqInsData ;
      private DateTime[] BC00172_A309DocArqInsHora ;
      private string[] BC00172_A311DocArqInsUsuID ;
      private bool[] BC00172_n311DocArqInsUsuID ;
      private DateTime[] BC00172_A319DocArqDelDataHora ;
      private bool[] BC00172_n319DocArqDelDataHora ;
      private DateTime[] BC00172_A317DocArqDelData ;
      private bool[] BC00172_n317DocArqDelData ;
      private DateTime[] BC00172_A511DocArqDelHora ;
      private bool[] BC00172_n511DocArqDelHora ;
      private string[] BC00172_A320DocArqDelUsuID ;
      private bool[] BC00172_n320DocArqDelUsuID ;
      private string[] BC00172_A509DocArqDelUsuNome ;
      private bool[] BC00172_n509DocArqDelUsuNome ;
      private DateTime[] BC00172_A312DocArqUpdData ;
      private bool[] BC00172_n312DocArqUpdData ;
      private DateTime[] BC00172_A313DocArqUpdHora ;
      private bool[] BC00172_n313DocArqUpdHora ;
      private DateTime[] BC00172_A314DocArqUpdDataHora ;
      private bool[] BC00172_n314DocArqUpdDataHora ;
      private string[] BC00172_A315DocArqUsuID ;
      private bool[] BC00172_n315DocArqUsuID ;
      private bool[] BC00172_A316DocArqDel ;
      private string[] BC00172_A324DocArqObservacao ;
      private bool[] BC00172_n324DocArqObservacao ;
      private bool[] BC00172_A644DocArqArmExterno ;
      private string[] BC00172_A645DocArqArmExternoPath ;
      private bool[] BC00172_n645DocArqArmExternoPath ;
      private string[] BC00172_A323DocArqConteudoExtensao ;
      private string[] BC00172_A322DocArqConteudoNome ;
      private Guid[] BC00172_A289DocID ;
      private string[] BC00172_A321DocArqConteudo ;
      private bool[] BC00172_n321DocArqConteudo ;
      private short[] BC00178_A306DocUltArqSeq ;
      private bool[] BC00178_n306DocUltArqSeq ;
      private short[] BC00178_A325DocVersao ;
      private Guid[] BC00178_A326DocVersaoIDPai ;
      private bool[] BC00178_n326DocVersaoIDPai ;
      private short[] BC001714_A307DocArqSeq ;
      private short[] BC001714_A306DocUltArqSeq ;
      private bool[] BC001714_n306DocUltArqSeq ;
      private DateTime[] BC001714_A310DocArqInsDataHora ;
      private DateTime[] BC001714_A308DocArqInsData ;
      private DateTime[] BC001714_A309DocArqInsHora ;
      private string[] BC001714_A311DocArqInsUsuID ;
      private bool[] BC001714_n311DocArqInsUsuID ;
      private DateTime[] BC001714_A319DocArqDelDataHora ;
      private bool[] BC001714_n319DocArqDelDataHora ;
      private DateTime[] BC001714_A317DocArqDelData ;
      private bool[] BC001714_n317DocArqDelData ;
      private DateTime[] BC001714_A511DocArqDelHora ;
      private bool[] BC001714_n511DocArqDelHora ;
      private string[] BC001714_A320DocArqDelUsuID ;
      private bool[] BC001714_n320DocArqDelUsuID ;
      private string[] BC001714_A509DocArqDelUsuNome ;
      private bool[] BC001714_n509DocArqDelUsuNome ;
      private short[] BC001714_A325DocVersao ;
      private DateTime[] BC001714_A312DocArqUpdData ;
      private bool[] BC001714_n312DocArqUpdData ;
      private DateTime[] BC001714_A313DocArqUpdHora ;
      private bool[] BC001714_n313DocArqUpdHora ;
      private DateTime[] BC001714_A314DocArqUpdDataHora ;
      private bool[] BC001714_n314DocArqUpdDataHora ;
      private string[] BC001714_A315DocArqUsuID ;
      private bool[] BC001714_n315DocArqUsuID ;
      private bool[] BC001714_A316DocArqDel ;
      private string[] BC001714_A324DocArqObservacao ;
      private bool[] BC001714_n324DocArqObservacao ;
      private bool[] BC001714_A644DocArqArmExterno ;
      private string[] BC001714_A645DocArqArmExternoPath ;
      private bool[] BC001714_n645DocArqArmExternoPath ;
      private string[] BC001714_A323DocArqConteudoExtensao ;
      private string[] BC001714_A322DocArqConteudoNome ;
      private Guid[] BC001714_A289DocID ;
      private Guid[] BC001714_A326DocVersaoIDPai ;
      private bool[] BC001714_n326DocVersaoIDPai ;
      private string[] BC001714_A321DocArqConteudo ;
      private bool[] BC001714_n321DocArqConteudo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private short[] BC00174_A306DocUltArqSeq ;
      private short[] BC00174_A325DocVersao ;
      private Guid[] BC00174_A326DocVersaoIDPai ;
      private bool[] BC00174_n306DocUltArqSeq ;
      private bool[] BC00174_n326DocVersaoIDPai ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ;
   }

   public class documentoarquivo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentoarquivo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00174;
        prmBC00174 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00176;
        prmBC00176 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00177;
        prmBC00177 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00173;
        prmBC00173 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00172;
        prmBC00172 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00178;
        prmBC00178 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00179;
        prmBC00179 = new Object[] {
        new ParDef("DocArqSeq",GXType.Int16,4,0) ,
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001710;
        prmBC001710 = new Object[] {
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001711;
        prmBC001711 = new Object[] {
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001712;
        prmBC001712 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC001713;
        prmBC001713 = new Object[] {
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001714;
        prmBC001714 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmBC00175;
        prmBC00175 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00172", "SELECT DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq  FOR UPDATE OF tb_documento_arquivo",true, GxErrorMask.GX_NOMASK, false, this,prmBC00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00173", "SELECT DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00174", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00175", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00176", "SELECT TM1.DocArqSeq, T2.DocUltArqSeq, TM1.DocArqInsDataHora, TM1.DocArqInsData, TM1.DocArqInsHora, TM1.DocArqInsUsuID, TM1.DocArqDelDataHora, TM1.DocArqDelData, TM1.DocArqDelHora, TM1.DocArqDelUsuID, TM1.DocArqDelUsuNome, T2.DocVersao, TM1.DocArqUpdData, TM1.DocArqUpdHora, TM1.DocArqUpdDataHora, TM1.DocArqUsuID, TM1.DocArqDel, TM1.DocArqObservacao, TM1.DocArqArmExterno, TM1.DocArqArmExternoPath, TM1.DocArqConteudoExtensao, TM1.DocArqConteudoNome, TM1.DocID, T2.DocVersaoIDPai, TM1.DocArqConteudo FROM (tb_documento_arquivo TM1 INNER JOIN tb_documento T2 ON T2.DocID = TM1.DocID) WHERE TM1.DocID = :DocID and TM1.DocArqSeq = :DocArqSeq ORDER BY TM1.DocID, TM1.DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00176,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00177", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00178", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento",true, GxErrorMask.GX_NOMASK, false, this,prmBC00178,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00179", "SAVEPOINT gxupdate;INSERT INTO tb_documento_arquivo(DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqConteudo, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID) VALUES(:DocArqSeq, :DocArqInsDataHora, :DocArqInsData, :DocArqInsHora, :DocArqInsUsuID, :DocArqDelDataHora, :DocArqDelData, :DocArqDelHora, :DocArqDelUsuID, :DocArqDelUsuNome, :DocArqUpdData, :DocArqUpdHora, :DocArqUpdDataHora, :DocArqUsuID, :DocArqDel, :DocArqConteudo, :DocArqObservacao, :DocArqArmExterno, :DocArqArmExternoPath, :DocArqConteudoExtensao, :DocArqConteudoNome, :DocID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00179)
           ,new CursorDef("BC001710", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqInsDataHora=:DocArqInsDataHora, DocArqInsData=:DocArqInsData, DocArqInsHora=:DocArqInsHora, DocArqInsUsuID=:DocArqInsUsuID, DocArqDelDataHora=:DocArqDelDataHora, DocArqDelData=:DocArqDelData, DocArqDelHora=:DocArqDelHora, DocArqDelUsuID=:DocArqDelUsuID, DocArqDelUsuNome=:DocArqDelUsuNome, DocArqUpdData=:DocArqUpdData, DocArqUpdHora=:DocArqUpdHora, DocArqUpdDataHora=:DocArqUpdDataHora, DocArqUsuID=:DocArqUsuID, DocArqDel=:DocArqDel, DocArqObservacao=:DocArqObservacao, DocArqArmExterno=:DocArqArmExterno, DocArqArmExternoPath=:DocArqArmExternoPath, DocArqConteudoExtensao=:DocArqConteudoExtensao, DocArqConteudoNome=:DocArqConteudoNome  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001710)
           ,new CursorDef("BC001711", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqConteudo=:DocArqConteudo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001711)
           ,new CursorDef("BC001712", "SAVEPOINT gxupdate;DELETE FROM tb_documento_arquivo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001712)
           ,new CursorDef("BC001713", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocUltArqSeq=:DocUltArqSeq  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001713)
           ,new CursorDef("BC001714", "SELECT TM1.DocArqSeq, T2.DocUltArqSeq, TM1.DocArqInsDataHora, TM1.DocArqInsData, TM1.DocArqInsHora, TM1.DocArqInsUsuID, TM1.DocArqDelDataHora, TM1.DocArqDelData, TM1.DocArqDelHora, TM1.DocArqDelUsuID, TM1.DocArqDelUsuNome, T2.DocVersao, TM1.DocArqUpdData, TM1.DocArqUpdHora, TM1.DocArqUpdDataHora, TM1.DocArqUsuID, TM1.DocArqDel, TM1.DocArqObservacao, TM1.DocArqArmExterno, TM1.DocArqArmExternoPath, TM1.DocArqConteudoExtensao, TM1.DocArqConteudoNome, TM1.DocID, T2.DocVersaoIDPai, TM1.DocArqConteudo FROM (tb_documento_arquivo TM1 INNER JOIN tb_documento T2 ON T2.DocID = TM1.DocID) WHERE TM1.DocID = :DocID and TM1.DocArqSeq = :DocArqSeq ORDER BY TM1.DocID, TM1.DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001714,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13, true);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getString(14, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((bool[]) buf[24])[0] = rslt.getBool(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((string[]) buf[30])[0] = rslt.getVarchar(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((Guid[]) buf[32])[0] = rslt.getGuid(21);
              ((string[]) buf[33])[0] = rslt.getBLOBFile(22, rslt.getVarchar(19), rslt.getVarchar(20));
              ((bool[]) buf[34])[0] = rslt.wasNull(22);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13, true);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getString(14, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((bool[]) buf[24])[0] = rslt.getBool(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((string[]) buf[30])[0] = rslt.getVarchar(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((Guid[]) buf[32])[0] = rslt.getGuid(21);
              ((string[]) buf[33])[0] = rslt.getBLOBFile(22, rslt.getVarchar(19), rslt.getVarchar(20));
              ((bool[]) buf[34])[0] = rslt.wasNull(22);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((short[]) buf[18])[0] = rslt.getShort(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getString(16, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((string[]) buf[33])[0] = rslt.getVarchar(21);
              ((string[]) buf[34])[0] = rslt.getVarchar(22);
              ((Guid[]) buf[35])[0] = rslt.getGuid(23);
              ((Guid[]) buf[36])[0] = rslt.getGuid(24);
              ((bool[]) buf[37])[0] = rslt.wasNull(24);
              ((string[]) buf[38])[0] = rslt.getBLOBFile(25, rslt.getVarchar(21), rslt.getVarchar(22));
              ((bool[]) buf[39])[0] = rslt.wasNull(25);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 6 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 12 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((short[]) buf[18])[0] = rslt.getShort(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getString(16, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((string[]) buf[33])[0] = rslt.getVarchar(21);
              ((string[]) buf[34])[0] = rslt.getVarchar(22);
              ((Guid[]) buf[35])[0] = rslt.getGuid(23);
              ((Guid[]) buf[36])[0] = rslt.getGuid(24);
              ((bool[]) buf[37])[0] = rslt.wasNull(24);
              ((string[]) buf[38])[0] = rslt.getBLOBFile(25, rslt.getVarchar(21), rslt.getVarchar(22));
              ((bool[]) buf[39])[0] = rslt.wasNull(25);
              return;
     }
  }

}

}
