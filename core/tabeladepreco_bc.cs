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
   public class tabeladepreco_bc : GxSilentTrn, IGxSilentTrn
   {
      public tabeladepreco_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladepreco_bc( IGxContext context )
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
         ReadRow0T29( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0T29( ) ;
         standaloneModal( ) ;
         AddRow0T29( ) ;
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
            E110T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z235TppID = A235TppID;
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T29( ) ;
            }
            else
            {
               CheckExtendedTable0T29( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0T29( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode29 = Gx_mode;
            CONFIRM_0T30( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode29;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode29;
         }
      }

      protected void CONFIRM_0T30( )
      {
         nGXsfl_30_idx = 0;
         while ( nGXsfl_30_idx < bccore_TabelaDePreco.gxTpr_Produto.Count )
         {
            ReadRow0T30( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound30 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_30 != 0 ) )
            {
               GetKey0T30( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound30 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0T30( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           ZM0T30( 32) ;
                        }
                        CloseExtendedTableCursors0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                        }
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
                  if ( RcdFound30 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0T30( ) ;
                        Load0T30( ) ;
                        BeforeValidate0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0T30( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_30 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0T30( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0T30( ) ;
                              if ( AnyError == 0 )
                              {
                                 ZM0T30( 32) ;
                              }
                              CloseExtendedTableCursors0T30( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                              }
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
               VarsToRow30( ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)bccore_TabelaDePreco.gxTpr_Produto.Item(nGXsfl_30_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void E120T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV16AuditingObject,  AV17Pgmname) ;
      }

      protected void ZM0T29( short GX_JID )
      {
         if ( ( GX_JID == 29 ) || ( GX_JID == 0 ) )
         {
            Z240TppInsDataHora = A240TppInsDataHora;
            Z238TppInsData = A238TppInsData;
            Z239TppInsHora = A239TppInsHora;
            Z241TppInsUsuID = A241TppInsUsuID;
            Z433TppInsUsuNome = A433TppInsUsuNome;
            Z603TppDelDataHora = A603TppDelDataHora;
            Z604TppDelData = A604TppDelData;
            Z605TppDelHora = A605TppDelHora;
            Z606TppDelUsuId = A606TppDelUsuId;
            Z607TppDelUsuNome = A607TppDelUsuNome;
            Z236TppCodigo = A236TppCodigo;
            Z237TppNome = A237TppNome;
            Z242TppUpdData = A242TppUpdData;
            Z243TppUpdHora = A243TppUpdHora;
            Z244TppUpdDataHora = A244TppUpdDataHora;
            Z245TppUpdUsuID = A245TppUpdUsuID;
            Z434TppUpdUsuNome = A434TppUpdUsuNome;
            Z246TppAtivo = A246TppAtivo;
            Z602TppDel = A602TppDel;
         }
         if ( GX_JID == -29 )
         {
            Z235TppID = A235TppID;
            Z240TppInsDataHora = A240TppInsDataHora;
            Z238TppInsData = A238TppInsData;
            Z239TppInsHora = A239TppInsHora;
            Z241TppInsUsuID = A241TppInsUsuID;
            Z433TppInsUsuNome = A433TppInsUsuNome;
            Z603TppDelDataHora = A603TppDelDataHora;
            Z604TppDelData = A604TppDelData;
            Z605TppDelHora = A605TppDelHora;
            Z606TppDelUsuId = A606TppDelUsuId;
            Z607TppDelUsuNome = A607TppDelUsuNome;
            Z236TppCodigo = A236TppCodigo;
            Z237TppNome = A237TppNome;
            Z242TppUpdData = A242TppUpdData;
            Z243TppUpdHora = A243TppUpdHora;
            Z244TppUpdDataHora = A244TppUpdDataHora;
            Z245TppUpdUsuID = A245TppUpdUsuID;
            Z434TppUpdUsuNome = A434TppUpdUsuNome;
            Z246TppAtivo = A246TppAtivo;
            Z602TppDel = A602TppDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV17Pgmname = "core.TabelaDePreco_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A235TppID) )
         {
            A235TppID = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A246TppAtivo) && ( Gx_BScreen == 0 ) )
         {
            A246TppAtivo = true;
            n246TppAtivo = false;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0T29( )
      {
         /* Using cursor BC000T7 */
         pr_default.execute(5, new Object[] {A235TppID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound29 = 1;
            A240TppInsDataHora = BC000T7_A240TppInsDataHora[0];
            A238TppInsData = BC000T7_A238TppInsData[0];
            A239TppInsHora = BC000T7_A239TppInsHora[0];
            A241TppInsUsuID = BC000T7_A241TppInsUsuID[0];
            n241TppInsUsuID = BC000T7_n241TppInsUsuID[0];
            A433TppInsUsuNome = BC000T7_A433TppInsUsuNome[0];
            n433TppInsUsuNome = BC000T7_n433TppInsUsuNome[0];
            A603TppDelDataHora = BC000T7_A603TppDelDataHora[0];
            n603TppDelDataHora = BC000T7_n603TppDelDataHora[0];
            A604TppDelData = BC000T7_A604TppDelData[0];
            n604TppDelData = BC000T7_n604TppDelData[0];
            A605TppDelHora = BC000T7_A605TppDelHora[0];
            n605TppDelHora = BC000T7_n605TppDelHora[0];
            A606TppDelUsuId = BC000T7_A606TppDelUsuId[0];
            n606TppDelUsuId = BC000T7_n606TppDelUsuId[0];
            A607TppDelUsuNome = BC000T7_A607TppDelUsuNome[0];
            n607TppDelUsuNome = BC000T7_n607TppDelUsuNome[0];
            A236TppCodigo = BC000T7_A236TppCodigo[0];
            A237TppNome = BC000T7_A237TppNome[0];
            A242TppUpdData = BC000T7_A242TppUpdData[0];
            n242TppUpdData = BC000T7_n242TppUpdData[0];
            A243TppUpdHora = BC000T7_A243TppUpdHora[0];
            n243TppUpdHora = BC000T7_n243TppUpdHora[0];
            A244TppUpdDataHora = BC000T7_A244TppUpdDataHora[0];
            n244TppUpdDataHora = BC000T7_n244TppUpdDataHora[0];
            A245TppUpdUsuID = BC000T7_A245TppUpdUsuID[0];
            n245TppUpdUsuID = BC000T7_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = BC000T7_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = BC000T7_n434TppUpdUsuNome[0];
            A246TppAtivo = BC000T7_A246TppAtivo[0];
            n246TppAtivo = BC000T7_n246TppAtivo[0];
            A602TppDel = BC000T7_A602TppDel[0];
            ZM0T29( -29) ;
         }
         pr_default.close(5);
         OnLoadActions0T29( ) ;
      }

      protected void OnLoadActions0T29( )
      {
      }

      protected void CheckExtendedTable0T29( )
      {
         nIsDirty_29 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000T8 */
         pr_default.execute(6, new Object[] {A236TppCodigo, A235TppID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A236TppCodigo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Código", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A237TppNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0T29( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T29( )
      {
         /* Using cursor BC000T9 */
         pr_default.execute(7, new Object[] {A235TppID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000T6 */
         pr_default.execute(4, new Object[] {A235TppID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0T29( 29) ;
            RcdFound29 = 1;
            A235TppID = BC000T6_A235TppID[0];
            A240TppInsDataHora = BC000T6_A240TppInsDataHora[0];
            A238TppInsData = BC000T6_A238TppInsData[0];
            A239TppInsHora = BC000T6_A239TppInsHora[0];
            A241TppInsUsuID = BC000T6_A241TppInsUsuID[0];
            n241TppInsUsuID = BC000T6_n241TppInsUsuID[0];
            A433TppInsUsuNome = BC000T6_A433TppInsUsuNome[0];
            n433TppInsUsuNome = BC000T6_n433TppInsUsuNome[0];
            A603TppDelDataHora = BC000T6_A603TppDelDataHora[0];
            n603TppDelDataHora = BC000T6_n603TppDelDataHora[0];
            A604TppDelData = BC000T6_A604TppDelData[0];
            n604TppDelData = BC000T6_n604TppDelData[0];
            A605TppDelHora = BC000T6_A605TppDelHora[0];
            n605TppDelHora = BC000T6_n605TppDelHora[0];
            A606TppDelUsuId = BC000T6_A606TppDelUsuId[0];
            n606TppDelUsuId = BC000T6_n606TppDelUsuId[0];
            A607TppDelUsuNome = BC000T6_A607TppDelUsuNome[0];
            n607TppDelUsuNome = BC000T6_n607TppDelUsuNome[0];
            A236TppCodigo = BC000T6_A236TppCodigo[0];
            A237TppNome = BC000T6_A237TppNome[0];
            A242TppUpdData = BC000T6_A242TppUpdData[0];
            n242TppUpdData = BC000T6_n242TppUpdData[0];
            A243TppUpdHora = BC000T6_A243TppUpdHora[0];
            n243TppUpdHora = BC000T6_n243TppUpdHora[0];
            A244TppUpdDataHora = BC000T6_A244TppUpdDataHora[0];
            n244TppUpdDataHora = BC000T6_n244TppUpdDataHora[0];
            A245TppUpdUsuID = BC000T6_A245TppUpdUsuID[0];
            n245TppUpdUsuID = BC000T6_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = BC000T6_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = BC000T6_n434TppUpdUsuNome[0];
            A246TppAtivo = BC000T6_A246TppAtivo[0];
            n246TppAtivo = BC000T6_n246TppAtivo[0];
            A602TppDel = BC000T6_A602TppDel[0];
            O602TppDel = A602TppDel;
            Z235TppID = A235TppID;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0T29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0T29( ) ;
            }
            Gx_mode = sMode29;
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0T29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode29;
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T29( ) ;
         if ( RcdFound29 == 0 )
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
         CONFIRM_0T0( ) ;
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

      protected void CheckOptimisticConcurrency0T29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000T5 */
            pr_default.execute(3, new Object[] {A235TppID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( Z240TppInsDataHora != BC000T5_A240TppInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z238TppInsData ) != DateTimeUtil.ResetTime ( BC000T5_A238TppInsData[0] ) ) || ( Z239TppInsHora != BC000T5_A239TppInsHora[0] ) || ( StringUtil.StrCmp(Z241TppInsUsuID, BC000T5_A241TppInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z433TppInsUsuNome, BC000T5_A433TppInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z603TppDelDataHora != BC000T5_A603TppDelDataHora[0] ) || ( Z604TppDelData != BC000T5_A604TppDelData[0] ) || ( Z605TppDelHora != BC000T5_A605TppDelHora[0] ) || ( StringUtil.StrCmp(Z606TppDelUsuId, BC000T5_A606TppDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z607TppDelUsuNome, BC000T5_A607TppDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z236TppCodigo, BC000T5_A236TppCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z237TppNome, BC000T5_A237TppNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z242TppUpdData ) != DateTimeUtil.ResetTime ( BC000T5_A242TppUpdData[0] ) ) || ( Z243TppUpdHora != BC000T5_A243TppUpdHora[0] ) || ( Z244TppUpdDataHora != BC000T5_A244TppUpdDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z245TppUpdUsuID, BC000T5_A245TppUpdUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z434TppUpdUsuNome, BC000T5_A434TppUpdUsuNome[0]) != 0 ) || ( Z246TppAtivo != BC000T5_A246TppAtivo[0] ) || ( Z602TppDel != BC000T5_A602TppDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_tabeladepreco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T29( )
      {
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T29( 0) ;
            CheckOptimisticConcurrency0T29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T10 */
                     pr_default.execute(8, new Object[] {A235TppID, A240TppInsDataHora, A238TppInsData, A239TppInsHora, n241TppInsUsuID, A241TppInsUsuID, n433TppInsUsuNome, A433TppInsUsuNome, n603TppDelDataHora, A603TppDelDataHora, n604TppDelData, A604TppDelData, n605TppDelHora, A605TppDelHora, n606TppDelUsuId, A606TppDelUsuId, n607TppDelUsuNome, A607TppDelUsuNome, A236TppCodigo, A237TppNome, n242TppUpdData, A242TppUpdData, n243TppUpdHora, A243TppUpdHora, n244TppUpdDataHora, A244TppUpdDataHora, n245TppUpdUsuID, A245TppUpdUsuID, n434TppUpdUsuNome, A434TppUpdUsuNome, n246TppAtivo, A246TppAtivo, A602TppDel});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ProcessLevel0T29( ) ;
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
               Load0T29( ) ;
            }
            EndLevel0T29( ) ;
         }
         CloseExtendedTableCursors0T29( ) ;
      }

      protected void Update0T29( )
      {
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T11 */
                     pr_default.execute(9, new Object[] {A240TppInsDataHora, A238TppInsData, A239TppInsHora, n241TppInsUsuID, A241TppInsUsuID, n433TppInsUsuNome, A433TppInsUsuNome, n603TppDelDataHora, A603TppDelDataHora, n604TppDelData, A604TppDelData, n605TppDelHora, A605TppDelHora, n606TppDelUsuId, A606TppDelUsuId, n607TppDelUsuNome, A607TppDelUsuNome, A236TppCodigo, A237TppNome, n242TppUpdData, A242TppUpdData, n243TppUpdHora, A243TppUpdHora, n244TppUpdDataHora, A244TppUpdDataHora, n245TppUpdUsuID, A245TppUpdUsuID, n434TppUpdUsuNome, A434TppUpdUsuNome, n246TppAtivo, A246TppAtivo, A602TppDel, A235TppID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0T29( ) ;
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
            EndLevel0T29( ) ;
         }
         CloseExtendedTableCursors0T29( ) ;
      }

      protected void DeferredUpdate0T29( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T29( ) ;
            AfterConfirm0T29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T29( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0T30( ) ;
                  while ( RcdFound30 != 0 )
                  {
                     getByPrimaryKey0T30( ) ;
                     Delete0T30( ) ;
                     ScanKeyNext0T30( ) ;
                  }
                  ScanKeyEnd0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T12 */
                     pr_default.execute(10, new Object[] {A235TppID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
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
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0T29( ) ;
         Gx_mode = sMode29;
      }

      protected void OnDeleteControls0T29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000T13 */
            pr_default.execute(11, new Object[] {A235TppID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000T14 */
            pr_default.execute(12, new Object[] {A235TppID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"+" ("+"Produto da Tabela de Preço"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void ProcessNestedLevel0T30( )
      {
         nGXsfl_30_idx = 0;
         while ( nGXsfl_30_idx < bccore_TabelaDePreco.gxTpr_Produto.Count )
         {
            ReadRow0T30( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound30 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_30 != 0 ) )
            {
               standaloneNotModal0T30( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0T30( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0T30( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0T30( ) ;
                  }
               }
            }
            KeyVarsToRow30( ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)bccore_TabelaDePreco.gxTpr_Produto.Item(nGXsfl_30_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_30_idx = 0;
            while ( nGXsfl_30_idx < bccore_TabelaDePreco.gxTpr_Produto.Count )
            {
               ReadRow0T30( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound30 == 0 )
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
                  bccore_TabelaDePreco.gxTpr_Produto.RemoveElement(nGXsfl_30_idx);
                  nGXsfl_30_idx = (int)(nGXsfl_30_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0T30( ) ;
                  VarsToRow30( ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)bccore_TabelaDePreco.gxTpr_Produto.Item(nGXsfl_30_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0T30( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_30 = 0;
         nIsMod_30 = 0;
         Gxremove30 = 0;
      }

      protected void ProcessLevel0T29( )
      {
         /* Save parent mode. */
         sMode29 = Gx_mode;
         ProcessNestedLevel0T30( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode29;
         /* ' Update level parameters */
      }

      protected void EndLevel0T29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T29( ) ;
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

      public void ScanKeyStart0T29( )
      {
         /* Scan By routine */
         /* Using cursor BC000T15 */
         pr_default.execute(13, new Object[] {A235TppID});
         RcdFound29 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound29 = 1;
            A235TppID = BC000T15_A235TppID[0];
            A240TppInsDataHora = BC000T15_A240TppInsDataHora[0];
            A238TppInsData = BC000T15_A238TppInsData[0];
            A239TppInsHora = BC000T15_A239TppInsHora[0];
            A241TppInsUsuID = BC000T15_A241TppInsUsuID[0];
            n241TppInsUsuID = BC000T15_n241TppInsUsuID[0];
            A433TppInsUsuNome = BC000T15_A433TppInsUsuNome[0];
            n433TppInsUsuNome = BC000T15_n433TppInsUsuNome[0];
            A603TppDelDataHora = BC000T15_A603TppDelDataHora[0];
            n603TppDelDataHora = BC000T15_n603TppDelDataHora[0];
            A604TppDelData = BC000T15_A604TppDelData[0];
            n604TppDelData = BC000T15_n604TppDelData[0];
            A605TppDelHora = BC000T15_A605TppDelHora[0];
            n605TppDelHora = BC000T15_n605TppDelHora[0];
            A606TppDelUsuId = BC000T15_A606TppDelUsuId[0];
            n606TppDelUsuId = BC000T15_n606TppDelUsuId[0];
            A607TppDelUsuNome = BC000T15_A607TppDelUsuNome[0];
            n607TppDelUsuNome = BC000T15_n607TppDelUsuNome[0];
            A236TppCodigo = BC000T15_A236TppCodigo[0];
            A237TppNome = BC000T15_A237TppNome[0];
            A242TppUpdData = BC000T15_A242TppUpdData[0];
            n242TppUpdData = BC000T15_n242TppUpdData[0];
            A243TppUpdHora = BC000T15_A243TppUpdHora[0];
            n243TppUpdHora = BC000T15_n243TppUpdHora[0];
            A244TppUpdDataHora = BC000T15_A244TppUpdDataHora[0];
            n244TppUpdDataHora = BC000T15_n244TppUpdDataHora[0];
            A245TppUpdUsuID = BC000T15_A245TppUpdUsuID[0];
            n245TppUpdUsuID = BC000T15_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = BC000T15_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = BC000T15_n434TppUpdUsuNome[0];
            A246TppAtivo = BC000T15_A246TppAtivo[0];
            n246TppAtivo = BC000T15_n246TppAtivo[0];
            A602TppDel = BC000T15_A602TppDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0T29( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound29 = 0;
         ScanKeyLoad0T29( ) ;
      }

      protected void ScanKeyLoad0T29( )
      {
         sMode29 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound29 = 1;
            A235TppID = BC000T15_A235TppID[0];
            A240TppInsDataHora = BC000T15_A240TppInsDataHora[0];
            A238TppInsData = BC000T15_A238TppInsData[0];
            A239TppInsHora = BC000T15_A239TppInsHora[0];
            A241TppInsUsuID = BC000T15_A241TppInsUsuID[0];
            n241TppInsUsuID = BC000T15_n241TppInsUsuID[0];
            A433TppInsUsuNome = BC000T15_A433TppInsUsuNome[0];
            n433TppInsUsuNome = BC000T15_n433TppInsUsuNome[0];
            A603TppDelDataHora = BC000T15_A603TppDelDataHora[0];
            n603TppDelDataHora = BC000T15_n603TppDelDataHora[0];
            A604TppDelData = BC000T15_A604TppDelData[0];
            n604TppDelData = BC000T15_n604TppDelData[0];
            A605TppDelHora = BC000T15_A605TppDelHora[0];
            n605TppDelHora = BC000T15_n605TppDelHora[0];
            A606TppDelUsuId = BC000T15_A606TppDelUsuId[0];
            n606TppDelUsuId = BC000T15_n606TppDelUsuId[0];
            A607TppDelUsuNome = BC000T15_A607TppDelUsuNome[0];
            n607TppDelUsuNome = BC000T15_n607TppDelUsuNome[0];
            A236TppCodigo = BC000T15_A236TppCodigo[0];
            A237TppNome = BC000T15_A237TppNome[0];
            A242TppUpdData = BC000T15_A242TppUpdData[0];
            n242TppUpdData = BC000T15_n242TppUpdData[0];
            A243TppUpdHora = BC000T15_A243TppUpdHora[0];
            n243TppUpdHora = BC000T15_n243TppUpdHora[0];
            A244TppUpdDataHora = BC000T15_A244TppUpdDataHora[0];
            n244TppUpdDataHora = BC000T15_n244TppUpdDataHora[0];
            A245TppUpdUsuID = BC000T15_A245TppUpdUsuID[0];
            n245TppUpdUsuID = BC000T15_n245TppUpdUsuID[0];
            A434TppUpdUsuNome = BC000T15_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = BC000T15_n434TppUpdUsuNome[0];
            A246TppAtivo = BC000T15_A246TppAtivo[0];
            n246TppAtivo = BC000T15_n246TppAtivo[0];
            A602TppDel = BC000T15_A602TppDel[0];
         }
         Gx_mode = sMode29;
      }

      protected void ScanKeyEnd0T29( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm0T29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T29( )
      {
         /* Before Insert Rules */
         A240TppInsDataHora = DateTimeUtil.Now( context);
         A241TppInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n241TppInsUsuID = false;
         A433TppInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n433TppInsUsuNome = false;
         A238TppInsData = DateTimeUtil.ResetTime( A240TppInsDataHora);
         A239TppInsHora = DateTimeUtil.ResetDate(A240TppInsDataHora);
      }

      protected void BeforeUpdate0T29( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A603TppDelDataHora = DateTimeUtil.NowMS( context);
            n603TppDelDataHora = false;
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A606TppDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n606TppDelUsuId = false;
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A607TppDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n607TppDelUsuNome = false;
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A604TppDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A603TppDelDataHora) ) ;
            n604TppDelData = false;
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A605TppDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A603TppDelDataHora));
            n605TppDelHora = false;
         }
      }

      protected void BeforeDelete0T29( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
      }

      protected void BeforeComplete0T29( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0T29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T29( )
      {
      }

      protected void ZM0T30( short GX_JID )
      {
         if ( ( GX_JID == 31 ) || ( GX_JID == 0 ) )
         {
            Z609Tpp1DelDataHora = A609Tpp1DelDataHora;
            Z610Tpp1DelData = A610Tpp1DelData;
            Z611Tpp1DelHora = A611Tpp1DelHora;
            Z612Tpp1DelUsuId = A612Tpp1DelUsuId;
            Z613Tpp1DelUsuNome = A613Tpp1DelUsuNome;
            Z247Tpp1Preco = A247Tpp1Preco;
            Z608Tpp1Del = A608Tpp1Del;
         }
         if ( ( GX_JID == 32 ) || ( GX_JID == 0 ) )
         {
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z232PrdTipoID = A232PrdTipoID;
            Z231PrdAtivo = A231PrdAtivo;
         }
         if ( GX_JID == -31 )
         {
            Z235TppID = A235TppID;
            Z609Tpp1DelDataHora = A609Tpp1DelDataHora;
            Z610Tpp1DelData = A610Tpp1DelData;
            Z611Tpp1DelHora = A611Tpp1DelHora;
            Z612Tpp1DelUsuId = A612Tpp1DelUsuId;
            Z613Tpp1DelUsuNome = A613Tpp1DelUsuNome;
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z232PrdTipoID = A232PrdTipoID;
            Z247Tpp1Preco = A247Tpp1Preco;
            Z608Tpp1Del = A608Tpp1Del;
            Z220PrdID = A220PrdID;
            Z231PrdAtivo = A231PrdAtivo;
         }
      }

      protected void standaloneNotModal0T30( )
      {
      }

      protected void standaloneModal0T30( )
      {
      }

      protected void Load0T30( )
      {
         /* Using cursor BC000T16 */
         pr_default.execute(14, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound30 = 1;
            A609Tpp1DelDataHora = BC000T16_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = BC000T16_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = BC000T16_A610Tpp1DelData[0];
            n610Tpp1DelData = BC000T16_n610Tpp1DelData[0];
            A611Tpp1DelHora = BC000T16_A611Tpp1DelHora[0];
            n611Tpp1DelHora = BC000T16_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = BC000T16_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = BC000T16_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = BC000T16_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = BC000T16_n613Tpp1DelUsuNome[0];
            A221PrdCodigo = BC000T16_A221PrdCodigo[0];
            A222PrdNome = BC000T16_A222PrdNome[0];
            A232PrdTipoID = BC000T16_A232PrdTipoID[0];
            A231PrdAtivo = BC000T16_A231PrdAtivo[0];
            A247Tpp1Preco = BC000T16_A247Tpp1Preco[0];
            A608Tpp1Del = BC000T16_A608Tpp1Del[0];
            ZM0T30( -31) ;
         }
         pr_default.close(14);
         OnLoadActions0T30( ) ;
      }

      protected void OnLoadActions0T30( )
      {
      }

      protected void CheckExtendedTable0T30( )
      {
         nIsDirty_30 = 0;
         Gx_BScreen = 1;
         standaloneModal0T30( ) ;
         Gx_BScreen = 0;
         /* Using cursor BC000T4 */
         pr_default.execute(2, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PRDID");
            AnyError = 1;
         }
         A221PrdCodigo = BC000T4_A221PrdCodigo[0];
         A222PrdNome = BC000T4_A222PrdNome[0];
         A232PrdTipoID = BC000T4_A232PrdTipoID[0];
         A231PrdAtivo = BC000T4_A231PrdAtivo[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A222PrdNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A220PrdID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (Convert.ToDecimal(0)==A247Tpp1Preco) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Preço", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0T30( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0T30( )
      {
      }

      protected void GetKey0T30( )
      {
         /* Using cursor BC000T17 */
         pr_default.execute(15, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(15);
      }

      protected void getByPrimaryKey0T30( )
      {
         /* Using cursor BC000T3 */
         pr_default.execute(1, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T30( 31) ;
            RcdFound30 = 1;
            InitializeNonKey0T30( ) ;
            A609Tpp1DelDataHora = BC000T3_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = BC000T3_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = BC000T3_A610Tpp1DelData[0];
            n610Tpp1DelData = BC000T3_n610Tpp1DelData[0];
            A611Tpp1DelHora = BC000T3_A611Tpp1DelHora[0];
            n611Tpp1DelHora = BC000T3_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = BC000T3_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = BC000T3_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = BC000T3_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = BC000T3_n613Tpp1DelUsuNome[0];
            A247Tpp1Preco = BC000T3_A247Tpp1Preco[0];
            A608Tpp1Del = BC000T3_A608Tpp1Del[0];
            A220PrdID = BC000T3_A220PrdID[0];
            O608Tpp1Del = A608Tpp1Del;
            Z235TppID = A235TppID;
            Z220PrdID = A220PrdID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0T30( ) ;
            Load0T30( ) ;
            Gx_mode = sMode30;
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0T30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0T30( ) ;
            Gx_mode = sMode30;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0T30( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0T30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000T2 */
            pr_default.execute(0, new Object[] {A235TppID, A220PrdID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco_produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z609Tpp1DelDataHora != BC000T2_A609Tpp1DelDataHora[0] ) || ( Z610Tpp1DelData != BC000T2_A610Tpp1DelData[0] ) || ( Z611Tpp1DelHora != BC000T2_A611Tpp1DelHora[0] ) || ( StringUtil.StrCmp(Z612Tpp1DelUsuId, BC000T2_A612Tpp1DelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z613Tpp1DelUsuNome, BC000T2_A613Tpp1DelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z247Tpp1Preco != BC000T2_A247Tpp1Preco[0] ) || ( Z608Tpp1Del != BC000T2_A608Tpp1Del[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_tabeladepreco_produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T30( )
      {
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T30( 0) ;
            CheckOptimisticConcurrency0T30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T18 */
                     pr_default.execute(16, new Object[] {A221PrdCodigo, A222PrdNome, A232PrdTipoID, A235TppID, n609Tpp1DelDataHora, A609Tpp1DelDataHora, n610Tpp1DelData, A610Tpp1DelData, n611Tpp1DelHora, A611Tpp1DelHora, n612Tpp1DelUsuId, A612Tpp1DelUsuId, n613Tpp1DelUsuNome, A613Tpp1DelUsuNome, A247Tpp1Preco, A608Tpp1Del, A220PrdID});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
                     if ( (pr_default.getStatus(16) == 1) )
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
               Load0T30( ) ;
            }
            EndLevel0T30( ) ;
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void Update0T30( )
      {
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000T19 */
                     pr_default.execute(17, new Object[] {A221PrdCodigo, A222PrdNome, A232PrdTipoID, n609Tpp1DelDataHora, A609Tpp1DelDataHora, n610Tpp1DelData, A610Tpp1DelData, n611Tpp1DelHora, A611Tpp1DelHora, n612Tpp1DelUsuId, A612Tpp1DelUsuId, n613Tpp1DelUsuNome, A613Tpp1DelUsuNome, A247Tpp1Preco, A608Tpp1Del, A235TppID, A220PrdID});
                     pr_default.close(17);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
                     if ( (pr_default.getStatus(17) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco_produto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0T30( ) ;
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
            EndLevel0T30( ) ;
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void DeferredUpdate0T30( )
      {
      }

      protected void Delete0T30( )
      {
         Gx_mode = "DLT";
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T30( ) ;
            AfterConfirm0T30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000T20 */
                  pr_default.execute(18, new Object[] {A235TppID, A220PrdID});
                  pr_default.close(18);
                  pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
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
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0T30( ) ;
         Gx_mode = sMode30;
      }

      protected void OnDeleteControls0T30( )
      {
         standaloneModal0T30( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000T21 */
            pr_default.execute(19, new Object[] {A220PrdID});
            A221PrdCodigo = BC000T21_A221PrdCodigo[0];
            A222PrdNome = BC000T21_A222PrdNome[0];
            A232PrdTipoID = BC000T21_A232PrdTipoID[0];
            A231PrdAtivo = BC000T21_A231PrdAtivo[0];
            pr_default.close(19);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000T22 */
            pr_default.execute(20, new Object[] {A235TppID, A220PrdID});
            if ( (pr_default.getStatus(20) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(20);
         }
      }

      protected void EndLevel0T30( )
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

      public void ScanKeyStart0T30( )
      {
         /* Scan By routine */
         /* Using cursor BC000T23 */
         pr_default.execute(21, new Object[] {A235TppID});
         RcdFound30 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound30 = 1;
            A609Tpp1DelDataHora = BC000T23_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = BC000T23_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = BC000T23_A610Tpp1DelData[0];
            n610Tpp1DelData = BC000T23_n610Tpp1DelData[0];
            A611Tpp1DelHora = BC000T23_A611Tpp1DelHora[0];
            n611Tpp1DelHora = BC000T23_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = BC000T23_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = BC000T23_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = BC000T23_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = BC000T23_n613Tpp1DelUsuNome[0];
            A221PrdCodigo = BC000T23_A221PrdCodigo[0];
            A222PrdNome = BC000T23_A222PrdNome[0];
            A232PrdTipoID = BC000T23_A232PrdTipoID[0];
            A231PrdAtivo = BC000T23_A231PrdAtivo[0];
            A247Tpp1Preco = BC000T23_A247Tpp1Preco[0];
            A608Tpp1Del = BC000T23_A608Tpp1Del[0];
            A220PrdID = BC000T23_A220PrdID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0T30( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound30 = 0;
         ScanKeyLoad0T30( ) ;
      }

      protected void ScanKeyLoad0T30( )
      {
         sMode30 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound30 = 1;
            A609Tpp1DelDataHora = BC000T23_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = BC000T23_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = BC000T23_A610Tpp1DelData[0];
            n610Tpp1DelData = BC000T23_n610Tpp1DelData[0];
            A611Tpp1DelHora = BC000T23_A611Tpp1DelHora[0];
            n611Tpp1DelHora = BC000T23_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = BC000T23_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = BC000T23_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = BC000T23_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = BC000T23_n613Tpp1DelUsuNome[0];
            A221PrdCodigo = BC000T23_A221PrdCodigo[0];
            A222PrdNome = BC000T23_A222PrdNome[0];
            A232PrdTipoID = BC000T23_A232PrdTipoID[0];
            A231PrdAtivo = BC000T23_A231PrdAtivo[0];
            A247Tpp1Preco = BC000T23_A247Tpp1Preco[0];
            A608Tpp1Del = BC000T23_A608Tpp1Del[0];
            A220PrdID = BC000T23_A220PrdID[0];
         }
         Gx_mode = sMode30;
      }

      protected void ScanKeyEnd0T30( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0T30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T30( )
      {
         /* Before Update Rules */
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A609Tpp1DelDataHora = DateTimeUtil.NowMS( context);
            n609Tpp1DelDataHora = false;
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A612Tpp1DelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n612Tpp1DelUsuId = false;
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A613Tpp1DelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n613Tpp1DelUsuNome = false;
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A610Tpp1DelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A609Tpp1DelDataHora) ) ;
            n610Tpp1DelData = false;
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A611Tpp1DelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A609Tpp1DelDataHora));
            n611Tpp1DelHora = false;
         }
      }

      protected void BeforeDelete0T30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T30( )
      {
      }

      protected void send_integrity_lvl_hashes0T30( )
      {
      }

      protected void send_integrity_lvl_hashes0T29( )
      {
      }

      protected void AddRow0T29( )
      {
         VarsToRow29( bccore_TabelaDePreco) ;
      }

      protected void ReadRow0T29( )
      {
         RowToVars29( bccore_TabelaDePreco, 1) ;
      }

      protected void AddRow0T30( )
      {
         GeneXus.Programs.core.SdtTabelaDePreco_Produto obj30;
         obj30 = new GeneXus.Programs.core.SdtTabelaDePreco_Produto(context);
         VarsToRow30( obj30) ;
         bccore_TabelaDePreco.gxTpr_Produto.Add(obj30, 0);
         obj30.gxTpr_Mode = "UPD";
         obj30.gxTpr_Modified = 0;
      }

      protected void ReadRow0T30( )
      {
         nGXsfl_30_idx = (int)(nGXsfl_30_idx+1);
         RowToVars30( ((GeneXus.Programs.core.SdtTabelaDePreco_Produto)bccore_TabelaDePreco.gxTpr_Produto.Item(nGXsfl_30_idx)), 1) ;
      }

      protected void InitializeNonKey0T29( )
      {
         AV16AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A238TppInsData = DateTime.MinValue;
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         A241TppInsUsuID = "";
         n241TppInsUsuID = false;
         A433TppInsUsuNome = "";
         n433TppInsUsuNome = false;
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         n603TppDelDataHora = false;
         A604TppDelData = (DateTime)(DateTime.MinValue);
         n604TppDelData = false;
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         n605TppDelHora = false;
         A606TppDelUsuId = "";
         n606TppDelUsuId = false;
         A607TppDelUsuNome = "";
         n607TppDelUsuNome = false;
         A236TppCodigo = "";
         A237TppNome = "";
         A242TppUpdData = DateTime.MinValue;
         n242TppUpdData = false;
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         n243TppUpdHora = false;
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         n244TppUpdDataHora = false;
         A245TppUpdUsuID = "";
         n245TppUpdUsuID = false;
         A434TppUpdUsuNome = "";
         n434TppUpdUsuNome = false;
         A602TppDel = false;
         A246TppAtivo = true;
         n246TppAtivo = false;
         O602TppDel = A602TppDel;
         Z240TppInsDataHora = (DateTime)(DateTime.MinValue);
         Z238TppInsData = DateTime.MinValue;
         Z239TppInsHora = (DateTime)(DateTime.MinValue);
         Z241TppInsUsuID = "";
         Z433TppInsUsuNome = "";
         Z603TppDelDataHora = (DateTime)(DateTime.MinValue);
         Z604TppDelData = (DateTime)(DateTime.MinValue);
         Z605TppDelHora = (DateTime)(DateTime.MinValue);
         Z606TppDelUsuId = "";
         Z607TppDelUsuNome = "";
         Z236TppCodigo = "";
         Z237TppNome = "";
         Z242TppUpdData = DateTime.MinValue;
         Z243TppUpdHora = (DateTime)(DateTime.MinValue);
         Z244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         Z245TppUpdUsuID = "";
         Z434TppUpdUsuNome = "";
         Z246TppAtivo = false;
         Z602TppDel = false;
      }

      protected void InitAll0T29( )
      {
         A235TppID = Guid.NewGuid( );
         InitializeNonKey0T29( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A246TppAtivo = i246TppAtivo;
         n246TppAtivo = false;
      }

      protected void InitializeNonKey0T30( )
      {
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         n609Tpp1DelDataHora = false;
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         n610Tpp1DelData = false;
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         n611Tpp1DelHora = false;
         A612Tpp1DelUsuId = "";
         n612Tpp1DelUsuId = false;
         A613Tpp1DelUsuNome = "";
         n613Tpp1DelUsuNome = false;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A232PrdTipoID = 0;
         A231PrdAtivo = false;
         A247Tpp1Preco = 0;
         A608Tpp1Del = false;
         O608Tpp1Del = A608Tpp1Del;
         Z609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         Z610Tpp1DelData = (DateTime)(DateTime.MinValue);
         Z611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         Z612Tpp1DelUsuId = "";
         Z613Tpp1DelUsuNome = "";
         Z247Tpp1Preco = 0;
         Z608Tpp1Del = false;
      }

      protected void InitAll0T30( )
      {
         A220PrdID = Guid.Empty;
         InitializeNonKey0T30( ) ;
      }

      protected void StandaloneModalInsert0T30( )
      {
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

      public void VarsToRow29( GeneXus.Programs.core.SdtTabelaDePreco obj29 )
      {
         obj29.gxTpr_Mode = Gx_mode;
         obj29.gxTpr_Tppinsdatahora = A240TppInsDataHora;
         obj29.gxTpr_Tppinsdata = A238TppInsData;
         obj29.gxTpr_Tppinshora = A239TppInsHora;
         obj29.gxTpr_Tppinsusuid = A241TppInsUsuID;
         obj29.gxTpr_Tppinsusunome = A433TppInsUsuNome;
         obj29.gxTpr_Tppdeldatahora = A603TppDelDataHora;
         obj29.gxTpr_Tppdeldata = A604TppDelData;
         obj29.gxTpr_Tppdelhora = A605TppDelHora;
         obj29.gxTpr_Tppdelusuid = A606TppDelUsuId;
         obj29.gxTpr_Tppdelusunome = A607TppDelUsuNome;
         obj29.gxTpr_Tppcodigo = A236TppCodigo;
         obj29.gxTpr_Tppnome = A237TppNome;
         obj29.gxTpr_Tppupddata = A242TppUpdData;
         obj29.gxTpr_Tppupdhora = A243TppUpdHora;
         obj29.gxTpr_Tppupddatahora = A244TppUpdDataHora;
         obj29.gxTpr_Tppupdusuid = A245TppUpdUsuID;
         obj29.gxTpr_Tppupdusunome = A434TppUpdUsuNome;
         obj29.gxTpr_Tppdel = A602TppDel;
         obj29.gxTpr_Tppativo = A246TppAtivo;
         obj29.gxTpr_Tppid = A235TppID;
         obj29.gxTpr_Tppid_Z = Z235TppID;
         obj29.gxTpr_Tppcodigo_Z = Z236TppCodigo;
         obj29.gxTpr_Tppnome_Z = Z237TppNome;
         obj29.gxTpr_Tppinsdata_Z = Z238TppInsData;
         obj29.gxTpr_Tppinshora_Z = Z239TppInsHora;
         obj29.gxTpr_Tppinsdatahora_Z = Z240TppInsDataHora;
         obj29.gxTpr_Tppinsusuid_Z = Z241TppInsUsuID;
         obj29.gxTpr_Tppinsusunome_Z = Z433TppInsUsuNome;
         obj29.gxTpr_Tppupddata_Z = Z242TppUpdData;
         obj29.gxTpr_Tppupdhora_Z = Z243TppUpdHora;
         obj29.gxTpr_Tppupddatahora_Z = Z244TppUpdDataHora;
         obj29.gxTpr_Tppupdusuid_Z = Z245TppUpdUsuID;
         obj29.gxTpr_Tppupdusunome_Z = Z434TppUpdUsuNome;
         obj29.gxTpr_Tppativo_Z = Z246TppAtivo;
         obj29.gxTpr_Tppdel_Z = Z602TppDel;
         obj29.gxTpr_Tppdeldatahora_Z = Z603TppDelDataHora;
         obj29.gxTpr_Tppdeldata_Z = Z604TppDelData;
         obj29.gxTpr_Tppdelhora_Z = Z605TppDelHora;
         obj29.gxTpr_Tppdelusuid_Z = Z606TppDelUsuId;
         obj29.gxTpr_Tppdelusunome_Z = Z607TppDelUsuNome;
         obj29.gxTpr_Tppinsusuid_N = (short)(Convert.ToInt16(n241TppInsUsuID));
         obj29.gxTpr_Tppinsusunome_N = (short)(Convert.ToInt16(n433TppInsUsuNome));
         obj29.gxTpr_Tppupddata_N = (short)(Convert.ToInt16(n242TppUpdData));
         obj29.gxTpr_Tppupdhora_N = (short)(Convert.ToInt16(n243TppUpdHora));
         obj29.gxTpr_Tppupddatahora_N = (short)(Convert.ToInt16(n244TppUpdDataHora));
         obj29.gxTpr_Tppupdusuid_N = (short)(Convert.ToInt16(n245TppUpdUsuID));
         obj29.gxTpr_Tppupdusunome_N = (short)(Convert.ToInt16(n434TppUpdUsuNome));
         obj29.gxTpr_Tppativo_N = (short)(Convert.ToInt16(n246TppAtivo));
         obj29.gxTpr_Tppdeldatahora_N = (short)(Convert.ToInt16(n603TppDelDataHora));
         obj29.gxTpr_Tppdeldata_N = (short)(Convert.ToInt16(n604TppDelData));
         obj29.gxTpr_Tppdelhora_N = (short)(Convert.ToInt16(n605TppDelHora));
         obj29.gxTpr_Tppdelusuid_N = (short)(Convert.ToInt16(n606TppDelUsuId));
         obj29.gxTpr_Tppdelusunome_N = (short)(Convert.ToInt16(n607TppDelUsuNome));
         obj29.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow29( GeneXus.Programs.core.SdtTabelaDePreco obj29 )
      {
         obj29.gxTpr_Tppid = A235TppID;
         return  ;
      }

      public void RowToVars29( GeneXus.Programs.core.SdtTabelaDePreco obj29 ,
                               int forceLoad )
      {
         Gx_mode = obj29.gxTpr_Mode;
         A240TppInsDataHora = obj29.gxTpr_Tppinsdatahora;
         A238TppInsData = obj29.gxTpr_Tppinsdata;
         A239TppInsHora = obj29.gxTpr_Tppinshora;
         A241TppInsUsuID = obj29.gxTpr_Tppinsusuid;
         n241TppInsUsuID = false;
         A433TppInsUsuNome = obj29.gxTpr_Tppinsusunome;
         n433TppInsUsuNome = false;
         A603TppDelDataHora = obj29.gxTpr_Tppdeldatahora;
         n603TppDelDataHora = false;
         A604TppDelData = obj29.gxTpr_Tppdeldata;
         n604TppDelData = false;
         A605TppDelHora = obj29.gxTpr_Tppdelhora;
         n605TppDelHora = false;
         A606TppDelUsuId = obj29.gxTpr_Tppdelusuid;
         n606TppDelUsuId = false;
         A607TppDelUsuNome = obj29.gxTpr_Tppdelusunome;
         n607TppDelUsuNome = false;
         A236TppCodigo = obj29.gxTpr_Tppcodigo;
         A237TppNome = obj29.gxTpr_Tppnome;
         A242TppUpdData = obj29.gxTpr_Tppupddata;
         n242TppUpdData = false;
         A243TppUpdHora = obj29.gxTpr_Tppupdhora;
         n243TppUpdHora = false;
         A244TppUpdDataHora = obj29.gxTpr_Tppupddatahora;
         n244TppUpdDataHora = false;
         A245TppUpdUsuID = obj29.gxTpr_Tppupdusuid;
         n245TppUpdUsuID = false;
         A434TppUpdUsuNome = obj29.gxTpr_Tppupdusunome;
         n434TppUpdUsuNome = false;
         A602TppDel = obj29.gxTpr_Tppdel;
         A246TppAtivo = obj29.gxTpr_Tppativo;
         n246TppAtivo = false;
         A235TppID = obj29.gxTpr_Tppid;
         Z235TppID = obj29.gxTpr_Tppid_Z;
         Z236TppCodigo = obj29.gxTpr_Tppcodigo_Z;
         Z237TppNome = obj29.gxTpr_Tppnome_Z;
         Z238TppInsData = obj29.gxTpr_Tppinsdata_Z;
         Z239TppInsHora = obj29.gxTpr_Tppinshora_Z;
         Z240TppInsDataHora = obj29.gxTpr_Tppinsdatahora_Z;
         Z241TppInsUsuID = obj29.gxTpr_Tppinsusuid_Z;
         Z433TppInsUsuNome = obj29.gxTpr_Tppinsusunome_Z;
         Z242TppUpdData = obj29.gxTpr_Tppupddata_Z;
         Z243TppUpdHora = obj29.gxTpr_Tppupdhora_Z;
         Z244TppUpdDataHora = obj29.gxTpr_Tppupddatahora_Z;
         Z245TppUpdUsuID = obj29.gxTpr_Tppupdusuid_Z;
         Z434TppUpdUsuNome = obj29.gxTpr_Tppupdusunome_Z;
         Z246TppAtivo = obj29.gxTpr_Tppativo_Z;
         Z602TppDel = obj29.gxTpr_Tppdel_Z;
         O602TppDel = obj29.gxTpr_Tppdel_Z;
         Z603TppDelDataHora = obj29.gxTpr_Tppdeldatahora_Z;
         Z604TppDelData = obj29.gxTpr_Tppdeldata_Z;
         Z605TppDelHora = obj29.gxTpr_Tppdelhora_Z;
         Z606TppDelUsuId = obj29.gxTpr_Tppdelusuid_Z;
         Z607TppDelUsuNome = obj29.gxTpr_Tppdelusunome_Z;
         n241TppInsUsuID = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppinsusuid_N));
         n433TppInsUsuNome = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppinsusunome_N));
         n242TppUpdData = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppupddata_N));
         n243TppUpdHora = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppupdhora_N));
         n244TppUpdDataHora = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppupddatahora_N));
         n245TppUpdUsuID = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppupdusuid_N));
         n434TppUpdUsuNome = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppupdusunome_N));
         n246TppAtivo = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppativo_N));
         n603TppDelDataHora = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppdeldatahora_N));
         n604TppDelData = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppdeldata_N));
         n605TppDelHora = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppdelhora_N));
         n606TppDelUsuId = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppdelusuid_N));
         n607TppDelUsuNome = (bool)(Convert.ToBoolean(obj29.gxTpr_Tppdelusunome_N));
         Gx_mode = obj29.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow30( GeneXus.Programs.core.SdtTabelaDePreco_Produto obj30 )
      {
         obj30.gxTpr_Mode = Gx_mode;
         obj30.gxTpr_Tpp1deldatahora = A609Tpp1DelDataHora;
         obj30.gxTpr_Tpp1deldata = A610Tpp1DelData;
         obj30.gxTpr_Tpp1delhora = A611Tpp1DelHora;
         obj30.gxTpr_Tpp1delusuid = A612Tpp1DelUsuId;
         obj30.gxTpr_Tpp1delusunome = A613Tpp1DelUsuNome;
         obj30.gxTpr_Prdcodigo = A221PrdCodigo;
         obj30.gxTpr_Prdnome = A222PrdNome;
         obj30.gxTpr_Prdtipoid = A232PrdTipoID;
         obj30.gxTpr_Prdativo = A231PrdAtivo;
         obj30.gxTpr_Tpp1preco = A247Tpp1Preco;
         obj30.gxTpr_Tpp1del = A608Tpp1Del;
         obj30.gxTpr_Prdid = A220PrdID;
         obj30.gxTpr_Prdid_Z = Z220PrdID;
         obj30.gxTpr_Prdcodigo_Z = Z221PrdCodigo;
         obj30.gxTpr_Prdnome_Z = Z222PrdNome;
         obj30.gxTpr_Prdtipoid_Z = Z232PrdTipoID;
         obj30.gxTpr_Prdativo_Z = Z231PrdAtivo;
         obj30.gxTpr_Tpp1preco_Z = Z247Tpp1Preco;
         obj30.gxTpr_Tpp1del_Z = Z608Tpp1Del;
         obj30.gxTpr_Tpp1deldatahora_Z = Z609Tpp1DelDataHora;
         obj30.gxTpr_Tpp1deldata_Z = Z610Tpp1DelData;
         obj30.gxTpr_Tpp1delhora_Z = Z611Tpp1DelHora;
         obj30.gxTpr_Tpp1delusuid_Z = Z612Tpp1DelUsuId;
         obj30.gxTpr_Tpp1delusunome_Z = Z613Tpp1DelUsuNome;
         obj30.gxTpr_Tpp1deldatahora_N = (short)(Convert.ToInt16(n609Tpp1DelDataHora));
         obj30.gxTpr_Tpp1deldata_N = (short)(Convert.ToInt16(n610Tpp1DelData));
         obj30.gxTpr_Tpp1delhora_N = (short)(Convert.ToInt16(n611Tpp1DelHora));
         obj30.gxTpr_Tpp1delusuid_N = (short)(Convert.ToInt16(n612Tpp1DelUsuId));
         obj30.gxTpr_Tpp1delusunome_N = (short)(Convert.ToInt16(n613Tpp1DelUsuNome));
         obj30.gxTpr_Modified = nIsMod_30;
         return  ;
      }

      public void KeyVarsToRow30( GeneXus.Programs.core.SdtTabelaDePreco_Produto obj30 )
      {
         obj30.gxTpr_Prdid = A220PrdID;
         return  ;
      }

      public void RowToVars30( GeneXus.Programs.core.SdtTabelaDePreco_Produto obj30 ,
                               int forceLoad )
      {
         Gx_mode = obj30.gxTpr_Mode;
         A609Tpp1DelDataHora = obj30.gxTpr_Tpp1deldatahora;
         n609Tpp1DelDataHora = false;
         A610Tpp1DelData = obj30.gxTpr_Tpp1deldata;
         n610Tpp1DelData = false;
         A611Tpp1DelHora = obj30.gxTpr_Tpp1delhora;
         n611Tpp1DelHora = false;
         A612Tpp1DelUsuId = obj30.gxTpr_Tpp1delusuid;
         n612Tpp1DelUsuId = false;
         A613Tpp1DelUsuNome = obj30.gxTpr_Tpp1delusunome;
         n613Tpp1DelUsuNome = false;
         A221PrdCodigo = obj30.gxTpr_Prdcodigo;
         A222PrdNome = obj30.gxTpr_Prdnome;
         A232PrdTipoID = obj30.gxTpr_Prdtipoid;
         A231PrdAtivo = obj30.gxTpr_Prdativo;
         A247Tpp1Preco = obj30.gxTpr_Tpp1preco;
         A608Tpp1Del = obj30.gxTpr_Tpp1del;
         A220PrdID = obj30.gxTpr_Prdid;
         Z220PrdID = obj30.gxTpr_Prdid_Z;
         Z221PrdCodigo = obj30.gxTpr_Prdcodigo_Z;
         Z222PrdNome = obj30.gxTpr_Prdnome_Z;
         Z232PrdTipoID = obj30.gxTpr_Prdtipoid_Z;
         Z231PrdAtivo = obj30.gxTpr_Prdativo_Z;
         Z247Tpp1Preco = obj30.gxTpr_Tpp1preco_Z;
         Z608Tpp1Del = obj30.gxTpr_Tpp1del_Z;
         O608Tpp1Del = obj30.gxTpr_Tpp1del_Z;
         Z609Tpp1DelDataHora = obj30.gxTpr_Tpp1deldatahora_Z;
         Z610Tpp1DelData = obj30.gxTpr_Tpp1deldata_Z;
         Z611Tpp1DelHora = obj30.gxTpr_Tpp1delhora_Z;
         Z612Tpp1DelUsuId = obj30.gxTpr_Tpp1delusuid_Z;
         Z613Tpp1DelUsuNome = obj30.gxTpr_Tpp1delusunome_Z;
         n609Tpp1DelDataHora = (bool)(Convert.ToBoolean(obj30.gxTpr_Tpp1deldatahora_N));
         n610Tpp1DelData = (bool)(Convert.ToBoolean(obj30.gxTpr_Tpp1deldata_N));
         n611Tpp1DelHora = (bool)(Convert.ToBoolean(obj30.gxTpr_Tpp1delhora_N));
         n612Tpp1DelUsuId = (bool)(Convert.ToBoolean(obj30.gxTpr_Tpp1delusuid_N));
         n613Tpp1DelUsuNome = (bool)(Convert.ToBoolean(obj30.gxTpr_Tpp1delusunome_N));
         nIsMod_30 = obj30.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A235TppID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0T29( ) ;
         ScanKeyStart0T29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z235TppID = A235TppID;
            O602TppDel = A602TppDel;
         }
         ZM0T29( -29) ;
         OnLoadActions0T29( ) ;
         AddRow0T29( ) ;
         bccore_TabelaDePreco.gxTpr_Produto.ClearCollection();
         if ( RcdFound29 == 1 )
         {
            ScanKeyStart0T30( ) ;
            nGXsfl_30_idx = 1;
            while ( RcdFound30 != 0 )
            {
               O608Tpp1Del = A608Tpp1Del;
               Z235TppID = A235TppID;
               Z220PrdID = A220PrdID;
               ZM0T30( -31) ;
               OnLoadActions0T30( ) ;
               nRcdExists_30 = 1;
               nIsMod_30 = 0;
               Z608Tpp1Del = A608Tpp1Del;
               AddRow0T30( ) ;
               nGXsfl_30_idx = (int)(nGXsfl_30_idx+1);
               ScanKeyNext0T30( ) ;
            }
            ScanKeyEnd0T30( ) ;
         }
         ScanKeyEnd0T29( ) ;
         if ( RcdFound29 == 0 )
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
         RowToVars29( bccore_TabelaDePreco, 0) ;
         ScanKeyStart0T29( ) ;
         if ( RcdFound29 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z235TppID = A235TppID;
            O602TppDel = A602TppDel;
         }
         ZM0T29( -29) ;
         OnLoadActions0T29( ) ;
         AddRow0T29( ) ;
         bccore_TabelaDePreco.gxTpr_Produto.ClearCollection();
         if ( RcdFound29 == 1 )
         {
            ScanKeyStart0T30( ) ;
            nGXsfl_30_idx = 1;
            while ( RcdFound30 != 0 )
            {
               O608Tpp1Del = A608Tpp1Del;
               Z235TppID = A235TppID;
               Z220PrdID = A220PrdID;
               ZM0T30( -31) ;
               OnLoadActions0T30( ) ;
               nRcdExists_30 = 1;
               nIsMod_30 = 0;
               Z608Tpp1Del = A608Tpp1Del;
               AddRow0T30( ) ;
               nGXsfl_30_idx = (int)(nGXsfl_30_idx+1);
               ScanKeyNext0T30( ) ;
            }
            ScanKeyEnd0T30( ) ;
         }
         ScanKeyEnd0T29( ) ;
         if ( RcdFound29 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0T29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0T29( ) ;
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A235TppID != Z235TppID )
               {
                  A235TppID = Z235TppID;
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
                  Update0T29( ) ;
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
                  if ( A235TppID != Z235TppID )
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
                        Insert0T29( ) ;
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
                        Insert0T29( ) ;
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
         RowToVars29( bccore_TabelaDePreco, 1) ;
         SaveImpl( ) ;
         VarsToRow29( bccore_TabelaDePreco) ;
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
         RowToVars29( bccore_TabelaDePreco, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T29( ) ;
         AfterTrn( ) ;
         VarsToRow29( bccore_TabelaDePreco) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow29( bccore_TabelaDePreco) ;
         }
         else
         {
            GeneXus.Programs.core.SdtTabelaDePreco auxBC = new GeneXus.Programs.core.SdtTabelaDePreco(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A235TppID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_TabelaDePreco);
               auxBC.Save();
               bccore_TabelaDePreco.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars29( bccore_TabelaDePreco, 1) ;
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
         RowToVars29( bccore_TabelaDePreco, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0T29( ) ;
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
               VarsToRow29( bccore_TabelaDePreco) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow29( bccore_TabelaDePreco) ;
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
         RowToVars29( bccore_TabelaDePreco, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0T29( ) ;
         if ( RcdFound29 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A235TppID != Z235TppID )
            {
               A235TppID = Z235TppID;
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
            if ( A235TppID != Z235TppID )
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
         context.RollbackDataStores("core.tabeladepreco_bc",pr_default);
         VarsToRow29( bccore_TabelaDePreco) ;
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
         Gx_mode = bccore_TabelaDePreco.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_TabelaDePreco.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_TabelaDePreco )
         {
            bccore_TabelaDePreco = (GeneXus.Programs.core.SdtTabelaDePreco)(sdt);
            if ( StringUtil.StrCmp(bccore_TabelaDePreco.gxTpr_Mode, "") == 0 )
            {
               bccore_TabelaDePreco.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow29( bccore_TabelaDePreco) ;
            }
            else
            {
               RowToVars29( bccore_TabelaDePreco, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_TabelaDePreco.gxTpr_Mode, "") == 0 )
            {
               bccore_TabelaDePreco.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars29( bccore_TabelaDePreco, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtTabelaDePreco TabelaDePreco_BC
      {
         get {
            return bccore_TabelaDePreco ;
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
            return "tabeladepreco_Execute" ;
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
         pr_default.close(19);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z235TppID = Guid.Empty;
         A235TppID = Guid.Empty;
         sMode29 = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV16AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV17Pgmname = "";
         Z240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         Z238TppInsData = DateTime.MinValue;
         A238TppInsData = DateTime.MinValue;
         Z239TppInsHora = (DateTime)(DateTime.MinValue);
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         Z241TppInsUsuID = "";
         A241TppInsUsuID = "";
         Z433TppInsUsuNome = "";
         A433TppInsUsuNome = "";
         Z603TppDelDataHora = (DateTime)(DateTime.MinValue);
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         Z604TppDelData = (DateTime)(DateTime.MinValue);
         A604TppDelData = (DateTime)(DateTime.MinValue);
         Z605TppDelHora = (DateTime)(DateTime.MinValue);
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         Z606TppDelUsuId = "";
         A606TppDelUsuId = "";
         Z607TppDelUsuNome = "";
         A607TppDelUsuNome = "";
         Z236TppCodigo = "";
         A236TppCodigo = "";
         Z237TppNome = "";
         A237TppNome = "";
         Z242TppUpdData = DateTime.MinValue;
         A242TppUpdData = DateTime.MinValue;
         Z243TppUpdHora = (DateTime)(DateTime.MinValue);
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         Z244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         Z245TppUpdUsuID = "";
         A245TppUpdUsuID = "";
         Z434TppUpdUsuNome = "";
         A434TppUpdUsuNome = "";
         BC000T7_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T7_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         BC000T7_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_A241TppInsUsuID = new string[] {""} ;
         BC000T7_n241TppInsUsuID = new bool[] {false} ;
         BC000T7_A433TppInsUsuNome = new string[] {""} ;
         BC000T7_n433TppInsUsuNome = new bool[] {false} ;
         BC000T7_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n603TppDelDataHora = new bool[] {false} ;
         BC000T7_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n604TppDelData = new bool[] {false} ;
         BC000T7_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n605TppDelHora = new bool[] {false} ;
         BC000T7_A606TppDelUsuId = new string[] {""} ;
         BC000T7_n606TppDelUsuId = new bool[] {false} ;
         BC000T7_A607TppDelUsuNome = new string[] {""} ;
         BC000T7_n607TppDelUsuNome = new bool[] {false} ;
         BC000T7_A236TppCodigo = new string[] {""} ;
         BC000T7_A237TppNome = new string[] {""} ;
         BC000T7_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n242TppUpdData = new bool[] {false} ;
         BC000T7_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n243TppUpdHora = new bool[] {false} ;
         BC000T7_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T7_n244TppUpdDataHora = new bool[] {false} ;
         BC000T7_A245TppUpdUsuID = new string[] {""} ;
         BC000T7_n245TppUpdUsuID = new bool[] {false} ;
         BC000T7_A434TppUpdUsuNome = new string[] {""} ;
         BC000T7_n434TppUpdUsuNome = new bool[] {false} ;
         BC000T7_A246TppAtivo = new bool[] {false} ;
         BC000T7_n246TppAtivo = new bool[] {false} ;
         BC000T7_A602TppDel = new bool[] {false} ;
         BC000T8_A236TppCodigo = new string[] {""} ;
         BC000T9_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T6_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T6_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         BC000T6_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_A241TppInsUsuID = new string[] {""} ;
         BC000T6_n241TppInsUsuID = new bool[] {false} ;
         BC000T6_A433TppInsUsuNome = new string[] {""} ;
         BC000T6_n433TppInsUsuNome = new bool[] {false} ;
         BC000T6_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n603TppDelDataHora = new bool[] {false} ;
         BC000T6_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n604TppDelData = new bool[] {false} ;
         BC000T6_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n605TppDelHora = new bool[] {false} ;
         BC000T6_A606TppDelUsuId = new string[] {""} ;
         BC000T6_n606TppDelUsuId = new bool[] {false} ;
         BC000T6_A607TppDelUsuNome = new string[] {""} ;
         BC000T6_n607TppDelUsuNome = new bool[] {false} ;
         BC000T6_A236TppCodigo = new string[] {""} ;
         BC000T6_A237TppNome = new string[] {""} ;
         BC000T6_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n242TppUpdData = new bool[] {false} ;
         BC000T6_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n243TppUpdHora = new bool[] {false} ;
         BC000T6_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T6_n244TppUpdDataHora = new bool[] {false} ;
         BC000T6_A245TppUpdUsuID = new string[] {""} ;
         BC000T6_n245TppUpdUsuID = new bool[] {false} ;
         BC000T6_A434TppUpdUsuNome = new string[] {""} ;
         BC000T6_n434TppUpdUsuNome = new bool[] {false} ;
         BC000T6_A246TppAtivo = new bool[] {false} ;
         BC000T6_n246TppAtivo = new bool[] {false} ;
         BC000T6_A602TppDel = new bool[] {false} ;
         BC000T5_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T5_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         BC000T5_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_A241TppInsUsuID = new string[] {""} ;
         BC000T5_n241TppInsUsuID = new bool[] {false} ;
         BC000T5_A433TppInsUsuNome = new string[] {""} ;
         BC000T5_n433TppInsUsuNome = new bool[] {false} ;
         BC000T5_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n603TppDelDataHora = new bool[] {false} ;
         BC000T5_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n604TppDelData = new bool[] {false} ;
         BC000T5_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n605TppDelHora = new bool[] {false} ;
         BC000T5_A606TppDelUsuId = new string[] {""} ;
         BC000T5_n606TppDelUsuId = new bool[] {false} ;
         BC000T5_A607TppDelUsuNome = new string[] {""} ;
         BC000T5_n607TppDelUsuNome = new bool[] {false} ;
         BC000T5_A236TppCodigo = new string[] {""} ;
         BC000T5_A237TppNome = new string[] {""} ;
         BC000T5_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n242TppUpdData = new bool[] {false} ;
         BC000T5_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n243TppUpdHora = new bool[] {false} ;
         BC000T5_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T5_n244TppUpdDataHora = new bool[] {false} ;
         BC000T5_A245TppUpdUsuID = new string[] {""} ;
         BC000T5_n245TppUpdUsuID = new bool[] {false} ;
         BC000T5_A434TppUpdUsuNome = new string[] {""} ;
         BC000T5_n434TppUpdUsuNome = new bool[] {false} ;
         BC000T5_A246TppAtivo = new bool[] {false} ;
         BC000T5_n246TppAtivo = new bool[] {false} ;
         BC000T5_A602TppDel = new bool[] {false} ;
         BC000T13_A345NegID = new Guid[] {Guid.Empty} ;
         BC000T13_A435NgpItem = new int[1] ;
         BC000T14_A345NegID = new Guid[] {Guid.Empty} ;
         BC000T14_A435NgpItem = new int[1] ;
         BC000T15_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T15_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         BC000T15_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_A241TppInsUsuID = new string[] {""} ;
         BC000T15_n241TppInsUsuID = new bool[] {false} ;
         BC000T15_A433TppInsUsuNome = new string[] {""} ;
         BC000T15_n433TppInsUsuNome = new bool[] {false} ;
         BC000T15_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n603TppDelDataHora = new bool[] {false} ;
         BC000T15_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n604TppDelData = new bool[] {false} ;
         BC000T15_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n605TppDelHora = new bool[] {false} ;
         BC000T15_A606TppDelUsuId = new string[] {""} ;
         BC000T15_n606TppDelUsuId = new bool[] {false} ;
         BC000T15_A607TppDelUsuNome = new string[] {""} ;
         BC000T15_n607TppDelUsuNome = new bool[] {false} ;
         BC000T15_A236TppCodigo = new string[] {""} ;
         BC000T15_A237TppNome = new string[] {""} ;
         BC000T15_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n242TppUpdData = new bool[] {false} ;
         BC000T15_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n243TppUpdHora = new bool[] {false} ;
         BC000T15_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T15_n244TppUpdDataHora = new bool[] {false} ;
         BC000T15_A245TppUpdUsuID = new string[] {""} ;
         BC000T15_n245TppUpdUsuID = new bool[] {false} ;
         BC000T15_A434TppUpdUsuNome = new string[] {""} ;
         BC000T15_n434TppUpdUsuNome = new bool[] {false} ;
         BC000T15_A246TppAtivo = new bool[] {false} ;
         BC000T15_n246TppAtivo = new bool[] {false} ;
         BC000T15_A602TppDel = new bool[] {false} ;
         Z609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         Z610Tpp1DelData = (DateTime)(DateTime.MinValue);
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         Z611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         Z612Tpp1DelUsuId = "";
         A612Tpp1DelUsuId = "";
         Z613Tpp1DelUsuNome = "";
         A613Tpp1DelUsuNome = "";
         Z221PrdCodigo = "";
         A221PrdCodigo = "";
         Z222PrdNome = "";
         A222PrdNome = "";
         Z220PrdID = Guid.Empty;
         A220PrdID = Guid.Empty;
         BC000T16_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T16_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T16_n609Tpp1DelDataHora = new bool[] {false} ;
         BC000T16_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         BC000T16_n610Tpp1DelData = new bool[] {false} ;
         BC000T16_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T16_n611Tpp1DelHora = new bool[] {false} ;
         BC000T16_A612Tpp1DelUsuId = new string[] {""} ;
         BC000T16_n612Tpp1DelUsuId = new bool[] {false} ;
         BC000T16_A613Tpp1DelUsuNome = new string[] {""} ;
         BC000T16_n613Tpp1DelUsuNome = new bool[] {false} ;
         BC000T16_A221PrdCodigo = new string[] {""} ;
         BC000T16_A222PrdNome = new string[] {""} ;
         BC000T16_A232PrdTipoID = new int[1] ;
         BC000T16_A231PrdAtivo = new bool[] {false} ;
         BC000T16_A247Tpp1Preco = new decimal[1] ;
         BC000T16_A608Tpp1Del = new bool[] {false} ;
         BC000T16_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000T4_A221PrdCodigo = new string[] {""} ;
         BC000T4_A222PrdNome = new string[] {""} ;
         BC000T4_A232PrdTipoID = new int[1] ;
         BC000T4_A231PrdAtivo = new bool[] {false} ;
         BC000T17_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T17_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000T3_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T3_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T3_n609Tpp1DelDataHora = new bool[] {false} ;
         BC000T3_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         BC000T3_n610Tpp1DelData = new bool[] {false} ;
         BC000T3_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T3_n611Tpp1DelHora = new bool[] {false} ;
         BC000T3_A612Tpp1DelUsuId = new string[] {""} ;
         BC000T3_n612Tpp1DelUsuId = new bool[] {false} ;
         BC000T3_A613Tpp1DelUsuNome = new string[] {""} ;
         BC000T3_n613Tpp1DelUsuNome = new bool[] {false} ;
         BC000T3_A247Tpp1Preco = new decimal[1] ;
         BC000T3_A608Tpp1Del = new bool[] {false} ;
         BC000T3_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000T3_A221PrdCodigo = new string[] {""} ;
         BC000T3_A222PrdNome = new string[] {""} ;
         BC000T3_A232PrdTipoID = new int[1] ;
         sMode30 = "";
         BC000T2_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T2_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T2_n609Tpp1DelDataHora = new bool[] {false} ;
         BC000T2_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         BC000T2_n610Tpp1DelData = new bool[] {false} ;
         BC000T2_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T2_n611Tpp1DelHora = new bool[] {false} ;
         BC000T2_A612Tpp1DelUsuId = new string[] {""} ;
         BC000T2_n612Tpp1DelUsuId = new bool[] {false} ;
         BC000T2_A613Tpp1DelUsuNome = new string[] {""} ;
         BC000T2_n613Tpp1DelUsuNome = new bool[] {false} ;
         BC000T2_A247Tpp1Preco = new decimal[1] ;
         BC000T2_A608Tpp1Del = new bool[] {false} ;
         BC000T2_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000T2_A221PrdCodigo = new string[] {""} ;
         BC000T2_A222PrdNome = new string[] {""} ;
         BC000T2_A232PrdTipoID = new int[1] ;
         BC000T21_A221PrdCodigo = new string[] {""} ;
         BC000T21_A222PrdNome = new string[] {""} ;
         BC000T21_A232PrdTipoID = new int[1] ;
         BC000T21_A231PrdAtivo = new bool[] {false} ;
         BC000T22_A345NegID = new Guid[] {Guid.Empty} ;
         BC000T22_A435NgpItem = new int[1] ;
         BC000T23_A235TppID = new Guid[] {Guid.Empty} ;
         BC000T23_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000T23_n609Tpp1DelDataHora = new bool[] {false} ;
         BC000T23_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         BC000T23_n610Tpp1DelData = new bool[] {false} ;
         BC000T23_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         BC000T23_n611Tpp1DelHora = new bool[] {false} ;
         BC000T23_A612Tpp1DelUsuId = new string[] {""} ;
         BC000T23_n612Tpp1DelUsuId = new bool[] {false} ;
         BC000T23_A613Tpp1DelUsuNome = new string[] {""} ;
         BC000T23_n613Tpp1DelUsuNome = new bool[] {false} ;
         BC000T23_A221PrdCodigo = new string[] {""} ;
         BC000T23_A222PrdNome = new string[] {""} ;
         BC000T23_A232PrdTipoID = new int[1] ;
         BC000T23_A231PrdAtivo = new bool[] {false} ;
         BC000T23_A247Tpp1Preco = new decimal[1] ;
         BC000T23_A608Tpp1Del = new bool[] {false} ;
         BC000T23_A220PrdID = new Guid[] {Guid.Empty} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladepreco_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladepreco_bc__default(),
            new Object[][] {
                new Object[] {
               BC000T2_A235TppID, BC000T2_A609Tpp1DelDataHora, BC000T2_n609Tpp1DelDataHora, BC000T2_A610Tpp1DelData, BC000T2_n610Tpp1DelData, BC000T2_A611Tpp1DelHora, BC000T2_n611Tpp1DelHora, BC000T2_A612Tpp1DelUsuId, BC000T2_n612Tpp1DelUsuId, BC000T2_A613Tpp1DelUsuNome,
               BC000T2_n613Tpp1DelUsuNome, BC000T2_A247Tpp1Preco, BC000T2_A608Tpp1Del, BC000T2_A220PrdID, BC000T2_A221PrdCodigo, BC000T2_A222PrdNome, BC000T2_A232PrdTipoID
               }
               , new Object[] {
               BC000T3_A235TppID, BC000T3_A609Tpp1DelDataHora, BC000T3_n609Tpp1DelDataHora, BC000T3_A610Tpp1DelData, BC000T3_n610Tpp1DelData, BC000T3_A611Tpp1DelHora, BC000T3_n611Tpp1DelHora, BC000T3_A612Tpp1DelUsuId, BC000T3_n612Tpp1DelUsuId, BC000T3_A613Tpp1DelUsuNome,
               BC000T3_n613Tpp1DelUsuNome, BC000T3_A247Tpp1Preco, BC000T3_A608Tpp1Del, BC000T3_A220PrdID, BC000T3_A221PrdCodigo, BC000T3_A222PrdNome, BC000T3_A232PrdTipoID
               }
               , new Object[] {
               BC000T4_A221PrdCodigo, BC000T4_A222PrdNome, BC000T4_A232PrdTipoID, BC000T4_A231PrdAtivo
               }
               , new Object[] {
               BC000T5_A235TppID, BC000T5_A240TppInsDataHora, BC000T5_A238TppInsData, BC000T5_A239TppInsHora, BC000T5_A241TppInsUsuID, BC000T5_n241TppInsUsuID, BC000T5_A433TppInsUsuNome, BC000T5_n433TppInsUsuNome, BC000T5_A603TppDelDataHora, BC000T5_n603TppDelDataHora,
               BC000T5_A604TppDelData, BC000T5_n604TppDelData, BC000T5_A605TppDelHora, BC000T5_n605TppDelHora, BC000T5_A606TppDelUsuId, BC000T5_n606TppDelUsuId, BC000T5_A607TppDelUsuNome, BC000T5_n607TppDelUsuNome, BC000T5_A236TppCodigo, BC000T5_A237TppNome,
               BC000T5_A242TppUpdData, BC000T5_n242TppUpdData, BC000T5_A243TppUpdHora, BC000T5_n243TppUpdHora, BC000T5_A244TppUpdDataHora, BC000T5_n244TppUpdDataHora, BC000T5_A245TppUpdUsuID, BC000T5_n245TppUpdUsuID, BC000T5_A434TppUpdUsuNome, BC000T5_n434TppUpdUsuNome,
               BC000T5_A246TppAtivo, BC000T5_n246TppAtivo, BC000T5_A602TppDel
               }
               , new Object[] {
               BC000T6_A235TppID, BC000T6_A240TppInsDataHora, BC000T6_A238TppInsData, BC000T6_A239TppInsHora, BC000T6_A241TppInsUsuID, BC000T6_n241TppInsUsuID, BC000T6_A433TppInsUsuNome, BC000T6_n433TppInsUsuNome, BC000T6_A603TppDelDataHora, BC000T6_n603TppDelDataHora,
               BC000T6_A604TppDelData, BC000T6_n604TppDelData, BC000T6_A605TppDelHora, BC000T6_n605TppDelHora, BC000T6_A606TppDelUsuId, BC000T6_n606TppDelUsuId, BC000T6_A607TppDelUsuNome, BC000T6_n607TppDelUsuNome, BC000T6_A236TppCodigo, BC000T6_A237TppNome,
               BC000T6_A242TppUpdData, BC000T6_n242TppUpdData, BC000T6_A243TppUpdHora, BC000T6_n243TppUpdHora, BC000T6_A244TppUpdDataHora, BC000T6_n244TppUpdDataHora, BC000T6_A245TppUpdUsuID, BC000T6_n245TppUpdUsuID, BC000T6_A434TppUpdUsuNome, BC000T6_n434TppUpdUsuNome,
               BC000T6_A246TppAtivo, BC000T6_n246TppAtivo, BC000T6_A602TppDel
               }
               , new Object[] {
               BC000T7_A235TppID, BC000T7_A240TppInsDataHora, BC000T7_A238TppInsData, BC000T7_A239TppInsHora, BC000T7_A241TppInsUsuID, BC000T7_n241TppInsUsuID, BC000T7_A433TppInsUsuNome, BC000T7_n433TppInsUsuNome, BC000T7_A603TppDelDataHora, BC000T7_n603TppDelDataHora,
               BC000T7_A604TppDelData, BC000T7_n604TppDelData, BC000T7_A605TppDelHora, BC000T7_n605TppDelHora, BC000T7_A606TppDelUsuId, BC000T7_n606TppDelUsuId, BC000T7_A607TppDelUsuNome, BC000T7_n607TppDelUsuNome, BC000T7_A236TppCodigo, BC000T7_A237TppNome,
               BC000T7_A242TppUpdData, BC000T7_n242TppUpdData, BC000T7_A243TppUpdHora, BC000T7_n243TppUpdHora, BC000T7_A244TppUpdDataHora, BC000T7_n244TppUpdDataHora, BC000T7_A245TppUpdUsuID, BC000T7_n245TppUpdUsuID, BC000T7_A434TppUpdUsuNome, BC000T7_n434TppUpdUsuNome,
               BC000T7_A246TppAtivo, BC000T7_n246TppAtivo, BC000T7_A602TppDel
               }
               , new Object[] {
               BC000T8_A236TppCodigo
               }
               , new Object[] {
               BC000T9_A235TppID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000T13_A345NegID, BC000T13_A435NgpItem
               }
               , new Object[] {
               BC000T14_A345NegID, BC000T14_A435NgpItem
               }
               , new Object[] {
               BC000T15_A235TppID, BC000T15_A240TppInsDataHora, BC000T15_A238TppInsData, BC000T15_A239TppInsHora, BC000T15_A241TppInsUsuID, BC000T15_n241TppInsUsuID, BC000T15_A433TppInsUsuNome, BC000T15_n433TppInsUsuNome, BC000T15_A603TppDelDataHora, BC000T15_n603TppDelDataHora,
               BC000T15_A604TppDelData, BC000T15_n604TppDelData, BC000T15_A605TppDelHora, BC000T15_n605TppDelHora, BC000T15_A606TppDelUsuId, BC000T15_n606TppDelUsuId, BC000T15_A607TppDelUsuNome, BC000T15_n607TppDelUsuNome, BC000T15_A236TppCodigo, BC000T15_A237TppNome,
               BC000T15_A242TppUpdData, BC000T15_n242TppUpdData, BC000T15_A243TppUpdHora, BC000T15_n243TppUpdHora, BC000T15_A244TppUpdDataHora, BC000T15_n244TppUpdDataHora, BC000T15_A245TppUpdUsuID, BC000T15_n245TppUpdUsuID, BC000T15_A434TppUpdUsuNome, BC000T15_n434TppUpdUsuNome,
               BC000T15_A246TppAtivo, BC000T15_n246TppAtivo, BC000T15_A602TppDel
               }
               , new Object[] {
               BC000T16_A235TppID, BC000T16_A609Tpp1DelDataHora, BC000T16_n609Tpp1DelDataHora, BC000T16_A610Tpp1DelData, BC000T16_n610Tpp1DelData, BC000T16_A611Tpp1DelHora, BC000T16_n611Tpp1DelHora, BC000T16_A612Tpp1DelUsuId, BC000T16_n612Tpp1DelUsuId, BC000T16_A613Tpp1DelUsuNome,
               BC000T16_n613Tpp1DelUsuNome, BC000T16_A221PrdCodigo, BC000T16_A222PrdNome, BC000T16_A232PrdTipoID, BC000T16_A231PrdAtivo, BC000T16_A247Tpp1Preco, BC000T16_A608Tpp1Del, BC000T16_A220PrdID
               }
               , new Object[] {
               BC000T17_A235TppID, BC000T17_A220PrdID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000T21_A221PrdCodigo, BC000T21_A222PrdNome, BC000T21_A232PrdTipoID, BC000T21_A231PrdAtivo
               }
               , new Object[] {
               BC000T22_A345NegID, BC000T22_A435NgpItem
               }
               , new Object[] {
               BC000T23_A235TppID, BC000T23_A609Tpp1DelDataHora, BC000T23_n609Tpp1DelDataHora, BC000T23_A610Tpp1DelData, BC000T23_n610Tpp1DelData, BC000T23_A611Tpp1DelHora, BC000T23_n611Tpp1DelHora, BC000T23_A612Tpp1DelUsuId, BC000T23_n612Tpp1DelUsuId, BC000T23_A613Tpp1DelUsuNome,
               BC000T23_n613Tpp1DelUsuNome, BC000T23_A221PrdCodigo, BC000T23_A222PrdNome, BC000T23_A232PrdTipoID, BC000T23_A231PrdAtivo, BC000T23_A247Tpp1Preco, BC000T23_A608Tpp1Del, BC000T23_A220PrdID
               }
            }
         );
         Z246TppAtivo = true;
         n246TppAtivo = false;
         A246TppAtivo = true;
         n246TppAtivo = false;
         i246TppAtivo = true;
         n246TppAtivo = false;
         Z235TppID = Guid.NewGuid( );
         A235TppID = Guid.NewGuid( );
         AV17Pgmname = "core.TabelaDePreco_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120T2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_30 ;
      private short RcdFound30 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound29 ;
      private short nIsDirty_29 ;
      private short nRcdExists_30 ;
      private short Gxremove30 ;
      private short nIsDirty_30 ;
      private int trnEnded ;
      private int nGXsfl_30_idx=1 ;
      private int Z232PrdTipoID ;
      private int A232PrdTipoID ;
      private decimal Z247Tpp1Preco ;
      private decimal A247Tpp1Preco ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode29 ;
      private string AV17Pgmname ;
      private string Z241TppInsUsuID ;
      private string A241TppInsUsuID ;
      private string Z606TppDelUsuId ;
      private string A606TppDelUsuId ;
      private string Z245TppUpdUsuID ;
      private string A245TppUpdUsuID ;
      private string Z612Tpp1DelUsuId ;
      private string A612Tpp1DelUsuId ;
      private string sMode30 ;
      private DateTime Z240TppInsDataHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime Z239TppInsHora ;
      private DateTime A239TppInsHora ;
      private DateTime Z603TppDelDataHora ;
      private DateTime A603TppDelDataHora ;
      private DateTime Z604TppDelData ;
      private DateTime A604TppDelData ;
      private DateTime Z605TppDelHora ;
      private DateTime A605TppDelHora ;
      private DateTime Z243TppUpdHora ;
      private DateTime A243TppUpdHora ;
      private DateTime Z244TppUpdDataHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime Z609Tpp1DelDataHora ;
      private DateTime A609Tpp1DelDataHora ;
      private DateTime Z610Tpp1DelData ;
      private DateTime A610Tpp1DelData ;
      private DateTime Z611Tpp1DelHora ;
      private DateTime A611Tpp1DelHora ;
      private DateTime Z238TppInsData ;
      private DateTime A238TppInsData ;
      private DateTime Z242TppUpdData ;
      private DateTime A242TppUpdData ;
      private bool returnInSub ;
      private bool Z246TppAtivo ;
      private bool A246TppAtivo ;
      private bool Z602TppDel ;
      private bool A602TppDel ;
      private bool n246TppAtivo ;
      private bool n241TppInsUsuID ;
      private bool n433TppInsUsuNome ;
      private bool n603TppDelDataHora ;
      private bool n604TppDelData ;
      private bool n605TppDelHora ;
      private bool n606TppDelUsuId ;
      private bool n607TppDelUsuNome ;
      private bool n242TppUpdData ;
      private bool n243TppUpdHora ;
      private bool n244TppUpdDataHora ;
      private bool n245TppUpdUsuID ;
      private bool n434TppUpdUsuNome ;
      private bool O602TppDel ;
      private bool Gx_longc ;
      private bool Z608Tpp1Del ;
      private bool A608Tpp1Del ;
      private bool Z231PrdAtivo ;
      private bool A231PrdAtivo ;
      private bool n609Tpp1DelDataHora ;
      private bool n610Tpp1DelData ;
      private bool n611Tpp1DelHora ;
      private bool n612Tpp1DelUsuId ;
      private bool n613Tpp1DelUsuNome ;
      private bool O608Tpp1Del ;
      private bool i246TppAtivo ;
      private bool mustCommit ;
      private string Z433TppInsUsuNome ;
      private string A433TppInsUsuNome ;
      private string Z607TppDelUsuNome ;
      private string A607TppDelUsuNome ;
      private string Z236TppCodigo ;
      private string A236TppCodigo ;
      private string Z237TppNome ;
      private string A237TppNome ;
      private string Z434TppUpdUsuNome ;
      private string A434TppUpdUsuNome ;
      private string Z613Tpp1DelUsuNome ;
      private string A613Tpp1DelUsuNome ;
      private string Z221PrdCodigo ;
      private string A221PrdCodigo ;
      private string Z222PrdNome ;
      private string A222PrdNome ;
      private Guid Z235TppID ;
      private Guid A235TppID ;
      private Guid Z220PrdID ;
      private Guid A220PrdID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtTabelaDePreco bccore_TabelaDePreco ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000T7_A235TppID ;
      private DateTime[] BC000T7_A240TppInsDataHora ;
      private DateTime[] BC000T7_A238TppInsData ;
      private DateTime[] BC000T7_A239TppInsHora ;
      private string[] BC000T7_A241TppInsUsuID ;
      private bool[] BC000T7_n241TppInsUsuID ;
      private string[] BC000T7_A433TppInsUsuNome ;
      private bool[] BC000T7_n433TppInsUsuNome ;
      private DateTime[] BC000T7_A603TppDelDataHora ;
      private bool[] BC000T7_n603TppDelDataHora ;
      private DateTime[] BC000T7_A604TppDelData ;
      private bool[] BC000T7_n604TppDelData ;
      private DateTime[] BC000T7_A605TppDelHora ;
      private bool[] BC000T7_n605TppDelHora ;
      private string[] BC000T7_A606TppDelUsuId ;
      private bool[] BC000T7_n606TppDelUsuId ;
      private string[] BC000T7_A607TppDelUsuNome ;
      private bool[] BC000T7_n607TppDelUsuNome ;
      private string[] BC000T7_A236TppCodigo ;
      private string[] BC000T7_A237TppNome ;
      private DateTime[] BC000T7_A242TppUpdData ;
      private bool[] BC000T7_n242TppUpdData ;
      private DateTime[] BC000T7_A243TppUpdHora ;
      private bool[] BC000T7_n243TppUpdHora ;
      private DateTime[] BC000T7_A244TppUpdDataHora ;
      private bool[] BC000T7_n244TppUpdDataHora ;
      private string[] BC000T7_A245TppUpdUsuID ;
      private bool[] BC000T7_n245TppUpdUsuID ;
      private string[] BC000T7_A434TppUpdUsuNome ;
      private bool[] BC000T7_n434TppUpdUsuNome ;
      private bool[] BC000T7_A246TppAtivo ;
      private bool[] BC000T7_n246TppAtivo ;
      private bool[] BC000T7_A602TppDel ;
      private string[] BC000T8_A236TppCodigo ;
      private Guid[] BC000T9_A235TppID ;
      private Guid[] BC000T6_A235TppID ;
      private DateTime[] BC000T6_A240TppInsDataHora ;
      private DateTime[] BC000T6_A238TppInsData ;
      private DateTime[] BC000T6_A239TppInsHora ;
      private string[] BC000T6_A241TppInsUsuID ;
      private bool[] BC000T6_n241TppInsUsuID ;
      private string[] BC000T6_A433TppInsUsuNome ;
      private bool[] BC000T6_n433TppInsUsuNome ;
      private DateTime[] BC000T6_A603TppDelDataHora ;
      private bool[] BC000T6_n603TppDelDataHora ;
      private DateTime[] BC000T6_A604TppDelData ;
      private bool[] BC000T6_n604TppDelData ;
      private DateTime[] BC000T6_A605TppDelHora ;
      private bool[] BC000T6_n605TppDelHora ;
      private string[] BC000T6_A606TppDelUsuId ;
      private bool[] BC000T6_n606TppDelUsuId ;
      private string[] BC000T6_A607TppDelUsuNome ;
      private bool[] BC000T6_n607TppDelUsuNome ;
      private string[] BC000T6_A236TppCodigo ;
      private string[] BC000T6_A237TppNome ;
      private DateTime[] BC000T6_A242TppUpdData ;
      private bool[] BC000T6_n242TppUpdData ;
      private DateTime[] BC000T6_A243TppUpdHora ;
      private bool[] BC000T6_n243TppUpdHora ;
      private DateTime[] BC000T6_A244TppUpdDataHora ;
      private bool[] BC000T6_n244TppUpdDataHora ;
      private string[] BC000T6_A245TppUpdUsuID ;
      private bool[] BC000T6_n245TppUpdUsuID ;
      private string[] BC000T6_A434TppUpdUsuNome ;
      private bool[] BC000T6_n434TppUpdUsuNome ;
      private bool[] BC000T6_A246TppAtivo ;
      private bool[] BC000T6_n246TppAtivo ;
      private bool[] BC000T6_A602TppDel ;
      private Guid[] BC000T5_A235TppID ;
      private DateTime[] BC000T5_A240TppInsDataHora ;
      private DateTime[] BC000T5_A238TppInsData ;
      private DateTime[] BC000T5_A239TppInsHora ;
      private string[] BC000T5_A241TppInsUsuID ;
      private bool[] BC000T5_n241TppInsUsuID ;
      private string[] BC000T5_A433TppInsUsuNome ;
      private bool[] BC000T5_n433TppInsUsuNome ;
      private DateTime[] BC000T5_A603TppDelDataHora ;
      private bool[] BC000T5_n603TppDelDataHora ;
      private DateTime[] BC000T5_A604TppDelData ;
      private bool[] BC000T5_n604TppDelData ;
      private DateTime[] BC000T5_A605TppDelHora ;
      private bool[] BC000T5_n605TppDelHora ;
      private string[] BC000T5_A606TppDelUsuId ;
      private bool[] BC000T5_n606TppDelUsuId ;
      private string[] BC000T5_A607TppDelUsuNome ;
      private bool[] BC000T5_n607TppDelUsuNome ;
      private string[] BC000T5_A236TppCodigo ;
      private string[] BC000T5_A237TppNome ;
      private DateTime[] BC000T5_A242TppUpdData ;
      private bool[] BC000T5_n242TppUpdData ;
      private DateTime[] BC000T5_A243TppUpdHora ;
      private bool[] BC000T5_n243TppUpdHora ;
      private DateTime[] BC000T5_A244TppUpdDataHora ;
      private bool[] BC000T5_n244TppUpdDataHora ;
      private string[] BC000T5_A245TppUpdUsuID ;
      private bool[] BC000T5_n245TppUpdUsuID ;
      private string[] BC000T5_A434TppUpdUsuNome ;
      private bool[] BC000T5_n434TppUpdUsuNome ;
      private bool[] BC000T5_A246TppAtivo ;
      private bool[] BC000T5_n246TppAtivo ;
      private bool[] BC000T5_A602TppDel ;
      private Guid[] BC000T13_A345NegID ;
      private int[] BC000T13_A435NgpItem ;
      private Guid[] BC000T14_A345NegID ;
      private int[] BC000T14_A435NgpItem ;
      private Guid[] BC000T15_A235TppID ;
      private DateTime[] BC000T15_A240TppInsDataHora ;
      private DateTime[] BC000T15_A238TppInsData ;
      private DateTime[] BC000T15_A239TppInsHora ;
      private string[] BC000T15_A241TppInsUsuID ;
      private bool[] BC000T15_n241TppInsUsuID ;
      private string[] BC000T15_A433TppInsUsuNome ;
      private bool[] BC000T15_n433TppInsUsuNome ;
      private DateTime[] BC000T15_A603TppDelDataHora ;
      private bool[] BC000T15_n603TppDelDataHora ;
      private DateTime[] BC000T15_A604TppDelData ;
      private bool[] BC000T15_n604TppDelData ;
      private DateTime[] BC000T15_A605TppDelHora ;
      private bool[] BC000T15_n605TppDelHora ;
      private string[] BC000T15_A606TppDelUsuId ;
      private bool[] BC000T15_n606TppDelUsuId ;
      private string[] BC000T15_A607TppDelUsuNome ;
      private bool[] BC000T15_n607TppDelUsuNome ;
      private string[] BC000T15_A236TppCodigo ;
      private string[] BC000T15_A237TppNome ;
      private DateTime[] BC000T15_A242TppUpdData ;
      private bool[] BC000T15_n242TppUpdData ;
      private DateTime[] BC000T15_A243TppUpdHora ;
      private bool[] BC000T15_n243TppUpdHora ;
      private DateTime[] BC000T15_A244TppUpdDataHora ;
      private bool[] BC000T15_n244TppUpdDataHora ;
      private string[] BC000T15_A245TppUpdUsuID ;
      private bool[] BC000T15_n245TppUpdUsuID ;
      private string[] BC000T15_A434TppUpdUsuNome ;
      private bool[] BC000T15_n434TppUpdUsuNome ;
      private bool[] BC000T15_A246TppAtivo ;
      private bool[] BC000T15_n246TppAtivo ;
      private bool[] BC000T15_A602TppDel ;
      private Guid[] BC000T16_A235TppID ;
      private DateTime[] BC000T16_A609Tpp1DelDataHora ;
      private bool[] BC000T16_n609Tpp1DelDataHora ;
      private DateTime[] BC000T16_A610Tpp1DelData ;
      private bool[] BC000T16_n610Tpp1DelData ;
      private DateTime[] BC000T16_A611Tpp1DelHora ;
      private bool[] BC000T16_n611Tpp1DelHora ;
      private string[] BC000T16_A612Tpp1DelUsuId ;
      private bool[] BC000T16_n612Tpp1DelUsuId ;
      private string[] BC000T16_A613Tpp1DelUsuNome ;
      private bool[] BC000T16_n613Tpp1DelUsuNome ;
      private string[] BC000T16_A221PrdCodigo ;
      private string[] BC000T16_A222PrdNome ;
      private int[] BC000T16_A232PrdTipoID ;
      private bool[] BC000T16_A231PrdAtivo ;
      private decimal[] BC000T16_A247Tpp1Preco ;
      private bool[] BC000T16_A608Tpp1Del ;
      private Guid[] BC000T16_A220PrdID ;
      private string[] BC000T4_A221PrdCodigo ;
      private string[] BC000T4_A222PrdNome ;
      private int[] BC000T4_A232PrdTipoID ;
      private bool[] BC000T4_A231PrdAtivo ;
      private Guid[] BC000T17_A235TppID ;
      private Guid[] BC000T17_A220PrdID ;
      private Guid[] BC000T3_A235TppID ;
      private DateTime[] BC000T3_A609Tpp1DelDataHora ;
      private bool[] BC000T3_n609Tpp1DelDataHora ;
      private DateTime[] BC000T3_A610Tpp1DelData ;
      private bool[] BC000T3_n610Tpp1DelData ;
      private DateTime[] BC000T3_A611Tpp1DelHora ;
      private bool[] BC000T3_n611Tpp1DelHora ;
      private string[] BC000T3_A612Tpp1DelUsuId ;
      private bool[] BC000T3_n612Tpp1DelUsuId ;
      private string[] BC000T3_A613Tpp1DelUsuNome ;
      private bool[] BC000T3_n613Tpp1DelUsuNome ;
      private decimal[] BC000T3_A247Tpp1Preco ;
      private bool[] BC000T3_A608Tpp1Del ;
      private Guid[] BC000T3_A220PrdID ;
      private string[] BC000T3_A221PrdCodigo ;
      private string[] BC000T3_A222PrdNome ;
      private int[] BC000T3_A232PrdTipoID ;
      private Guid[] BC000T2_A235TppID ;
      private DateTime[] BC000T2_A609Tpp1DelDataHora ;
      private bool[] BC000T2_n609Tpp1DelDataHora ;
      private DateTime[] BC000T2_A610Tpp1DelData ;
      private bool[] BC000T2_n610Tpp1DelData ;
      private DateTime[] BC000T2_A611Tpp1DelHora ;
      private bool[] BC000T2_n611Tpp1DelHora ;
      private string[] BC000T2_A612Tpp1DelUsuId ;
      private bool[] BC000T2_n612Tpp1DelUsuId ;
      private string[] BC000T2_A613Tpp1DelUsuNome ;
      private bool[] BC000T2_n613Tpp1DelUsuNome ;
      private decimal[] BC000T2_A247Tpp1Preco ;
      private bool[] BC000T2_A608Tpp1Del ;
      private Guid[] BC000T2_A220PrdID ;
      private string[] BC000T2_A221PrdCodigo ;
      private string[] BC000T2_A222PrdNome ;
      private int[] BC000T2_A232PrdTipoID ;
      private string[] BC000T21_A221PrdCodigo ;
      private string[] BC000T21_A222PrdNome ;
      private int[] BC000T21_A232PrdTipoID ;
      private bool[] BC000T21_A231PrdAtivo ;
      private Guid[] BC000T22_A345NegID ;
      private int[] BC000T22_A435NgpItem ;
      private Guid[] BC000T23_A235TppID ;
      private DateTime[] BC000T23_A609Tpp1DelDataHora ;
      private bool[] BC000T23_n609Tpp1DelDataHora ;
      private DateTime[] BC000T23_A610Tpp1DelData ;
      private bool[] BC000T23_n610Tpp1DelData ;
      private DateTime[] BC000T23_A611Tpp1DelHora ;
      private bool[] BC000T23_n611Tpp1DelHora ;
      private string[] BC000T23_A612Tpp1DelUsuId ;
      private bool[] BC000T23_n612Tpp1DelUsuId ;
      private string[] BC000T23_A613Tpp1DelUsuNome ;
      private bool[] BC000T23_n613Tpp1DelUsuNome ;
      private string[] BC000T23_A221PrdCodigo ;
      private string[] BC000T23_A222PrdNome ;
      private int[] BC000T23_A232PrdTipoID ;
      private bool[] BC000T23_A231PrdAtivo ;
      private decimal[] BC000T23_A247Tpp1Preco ;
      private bool[] BC000T23_A608Tpp1Del ;
      private Guid[] BC000T23_A220PrdID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ;
   }

   public class tabeladepreco_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tabeladepreco_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new UpdateCursor(def[18])
       ,new ForEachCursor(def[19])
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000T7;
        prmBC000T7 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T8;
        prmBC000T8 = new Object[] {
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T9;
        prmBC000T9 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T6;
        prmBC000T6 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T5;
        prmBC000T5 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T10;
        prmBC000T10 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TppInsDataHora",GXType.DateTime,10,8) ,
        new ParDef("TppInsData",GXType.Date,8,0) ,
        new ParDef("TppInsHora",GXType.DateTime,0,5) ,
        new ParDef("TppInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("TppDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppNome",GXType.VarChar,80,0) ,
        new ParDef("TppUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("TppUpdHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("TppDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000T11;
        prmBC000T11 = new Object[] {
        new ParDef("TppInsDataHora",GXType.DateTime,10,8) ,
        new ParDef("TppInsData",GXType.Date,8,0) ,
        new ParDef("TppInsHora",GXType.DateTime,0,5) ,
        new ParDef("TppInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("TppDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppNome",GXType.VarChar,80,0) ,
        new ParDef("TppUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("TppUpdHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("TppDel",GXType.Boolean,4,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T12;
        prmBC000T12 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T13;
        prmBC000T13 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T14;
        prmBC000T14 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T15;
        prmBC000T15 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T16;
        prmBC000T16 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T4;
        prmBC000T4 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T17;
        prmBC000T17 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T3;
        prmBC000T3 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T2;
        prmBC000T2 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T18;
        prmBC000T18 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Tpp1DelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("Tpp1DelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("Tpp1DelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("Tpp1DelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("Tpp1DelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("Tpp1Preco",GXType.Number,16,2) ,
        new ParDef("Tpp1Del",GXType.Boolean,4,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T19;
        prmBC000T19 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("Tpp1DelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("Tpp1DelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("Tpp1DelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("Tpp1DelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("Tpp1DelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("Tpp1Preco",GXType.Number,16,2) ,
        new ParDef("Tpp1Del",GXType.Boolean,4,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T20;
        prmBC000T20 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T21;
        prmBC000T21 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T22;
        prmBC000T22 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000T23;
        prmBC000T23 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000T2", "SELECT TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID, PrdCodigo, PrdNome, PrdTipoID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID  FOR UPDATE OF tb_tabeladepreco_produto",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T3", "SELECT TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID, PrdCodigo, PrdNome, PrdTipoID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T4", "SELECT PrdCodigo, PrdNome, PrdTipoID, PrdAtivo FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T5", "SELECT TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel FROM tb_tabeladepreco WHERE TppID = :TppID  FOR UPDATE OF tb_tabeladepreco",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T6", "SELECT TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel FROM tb_tabeladepreco WHERE TppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T7", "SELECT TM1.TppID, TM1.TppInsDataHora, TM1.TppInsData, TM1.TppInsHora, TM1.TppInsUsuID, TM1.TppInsUsuNome, TM1.TppDelDataHora, TM1.TppDelData, TM1.TppDelHora, TM1.TppDelUsuId, TM1.TppDelUsuNome, TM1.TppCodigo, TM1.TppNome, TM1.TppUpdData, TM1.TppUpdHora, TM1.TppUpdDataHora, TM1.TppUpdUsuID, TM1.TppUpdUsuNome, TM1.TppAtivo, TM1.TppDel FROM tb_tabeladepreco TM1 WHERE TM1.TppID = :TppID ORDER BY TM1.TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T8", "SELECT TppCodigo FROM tb_tabeladepreco WHERE (TppCodigo = :TppCodigo) AND (Not ( TppID = :TppID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T9", "SELECT TppID FROM tb_tabeladepreco WHERE TppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T10", "SAVEPOINT gxupdate;INSERT INTO tb_tabeladepreco(TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel) VALUES(:TppID, :TppInsDataHora, :TppInsData, :TppInsHora, :TppInsUsuID, :TppInsUsuNome, :TppDelDataHora, :TppDelData, :TppDelHora, :TppDelUsuId, :TppDelUsuNome, :TppCodigo, :TppNome, :TppUpdData, :TppUpdHora, :TppUpdDataHora, :TppUpdUsuID, :TppUpdUsuNome, :TppAtivo, :TppDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000T10)
           ,new CursorDef("BC000T11", "SAVEPOINT gxupdate;UPDATE tb_tabeladepreco SET TppInsDataHora=:TppInsDataHora, TppInsData=:TppInsData, TppInsHora=:TppInsHora, TppInsUsuID=:TppInsUsuID, TppInsUsuNome=:TppInsUsuNome, TppDelDataHora=:TppDelDataHora, TppDelData=:TppDelData, TppDelHora=:TppDelHora, TppDelUsuId=:TppDelUsuId, TppDelUsuNome=:TppDelUsuNome, TppCodigo=:TppCodigo, TppNome=:TppNome, TppUpdData=:TppUpdData, TppUpdHora=:TppUpdHora, TppUpdDataHora=:TppUpdDataHora, TppUpdUsuID=:TppUpdUsuID, TppUpdUsuNome=:TppUpdUsuNome, TppAtivo=:TppAtivo, TppDel=:TppDel  WHERE TppID = :TppID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T11)
           ,new CursorDef("BC000T12", "SAVEPOINT gxupdate;DELETE FROM tb_tabeladepreco  WHERE TppID = :TppID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T12)
           ,new CursorDef("BC000T13", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000T14", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000T15", "SELECT TM1.TppID, TM1.TppInsDataHora, TM1.TppInsData, TM1.TppInsHora, TM1.TppInsUsuID, TM1.TppInsUsuNome, TM1.TppDelDataHora, TM1.TppDelData, TM1.TppDelHora, TM1.TppDelUsuId, TM1.TppDelUsuNome, TM1.TppCodigo, TM1.TppNome, TM1.TppUpdData, TM1.TppUpdHora, TM1.TppUpdDataHora, TM1.TppUpdUsuID, TM1.TppUpdUsuNome, TM1.TppAtivo, TM1.TppDel FROM tb_tabeladepreco TM1 WHERE TM1.TppID = :TppID ORDER BY TM1.TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T15,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T16", "SELECT T1.TppID, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.PrdID FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID and T1.PrdID = :PrdID ORDER BY T1.TppID, T1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T16,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T17", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T18", "SAVEPOINT gxupdate;INSERT INTO tb_tabeladepreco_produto(PrdCodigo, PrdNome, PrdTipoID, TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID) VALUES(:PrdCodigo, :PrdNome, :PrdTipoID, :TppID, :Tpp1DelDataHora, :Tpp1DelData, :Tpp1DelHora, :Tpp1DelUsuId, :Tpp1DelUsuNome, :Tpp1Preco, :Tpp1Del, :PrdID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000T18)
           ,new CursorDef("BC000T19", "SAVEPOINT gxupdate;UPDATE tb_tabeladepreco_produto SET PrdCodigo=:PrdCodigo, PrdNome=:PrdNome, PrdTipoID=:PrdTipoID, Tpp1DelDataHora=:Tpp1DelDataHora, Tpp1DelData=:Tpp1DelData, Tpp1DelHora=:Tpp1DelHora, Tpp1DelUsuId=:Tpp1DelUsuId, Tpp1DelUsuNome=:Tpp1DelUsuNome, Tpp1Preco=:Tpp1Preco, Tpp1Del=:Tpp1Del  WHERE TppID = :TppID AND PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T19)
           ,new CursorDef("BC000T20", "SAVEPOINT gxupdate;DELETE FROM tb_tabeladepreco_produto  WHERE TppID = :TppID AND PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000T20)
           ,new CursorDef("BC000T21", "SELECT PrdCodigo, PrdNome, PrdTipoID, PrdAtivo FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T21,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000T22", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID AND NgpTppPrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T22,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000T23", "SELECT T1.TppID, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.PrdID FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID ORDER BY T1.TppID, T1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000T23,11, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.getBool(8);
              ((Guid[]) buf[13])[0] = rslt.getGuid(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((int[]) buf[16])[0] = rslt.getInt(12);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.getBool(8);
              ((Guid[]) buf[13])[0] = rslt.getGuid(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((int[]) buf[16])[0] = rslt.getInt(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
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
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((int[]) buf[13])[0] = rslt.getInt(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 19 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 20 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 21 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((int[]) buf[13])[0] = rslt.getInt(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              return;
     }
  }

}

}
