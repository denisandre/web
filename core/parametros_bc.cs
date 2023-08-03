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
   public class parametros_bc : GxSilentTrn, IGxSilentTrn
   {
      public parametros_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametros_bc( IGxContext context )
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
         ReadRow0X36( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0X36( ) ;
         standaloneModal( ) ;
         AddRow0X36( ) ;
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
            E110X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z342ParametroChave = A342ParametroChave;
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

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X36( ) ;
            }
            else
            {
               CheckExtendedTable0X36( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0X36( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM0X36( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z519ParametroDelDataHora = A519ParametroDelDataHora;
            Z520ParametroDelData = A520ParametroDelData;
            Z521ParametroDelHora = A521ParametroDelHora;
            Z522ParametroDelUsuId = A522ParametroDelUsuId;
            Z523ParametroDelUsuNome = A523ParametroDelUsuNome;
            Z344ParametroDescricao = A344ParametroDescricao;
            Z343ParametroValor = A343ParametroValor;
            Z518ParametroDel = A518ParametroDel;
         }
         if ( GX_JID == -10 )
         {
            Z342ParametroChave = A342ParametroChave;
            Z519ParametroDelDataHora = A519ParametroDelDataHora;
            Z520ParametroDelData = A520ParametroDelData;
            Z521ParametroDelHora = A521ParametroDelHora;
            Z522ParametroDelUsuId = A522ParametroDelUsuId;
            Z523ParametroDelUsuNome = A523ParametroDelUsuNome;
            Z344ParametroDescricao = A344ParametroDescricao;
            Z343ParametroValor = A343ParametroValor;
            Z518ParametroDel = A518ParametroDel;
         }
      }

      protected void standaloneNotModal( )
      {
         AV14Pgmname = "core.Parametros_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0X36( )
      {
         /* Using cursor BC000X4 */
         pr_default.execute(2, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound36 = 1;
            A519ParametroDelDataHora = BC000X4_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = BC000X4_n519ParametroDelDataHora[0];
            A520ParametroDelData = BC000X4_A520ParametroDelData[0];
            n520ParametroDelData = BC000X4_n520ParametroDelData[0];
            A521ParametroDelHora = BC000X4_A521ParametroDelHora[0];
            n521ParametroDelHora = BC000X4_n521ParametroDelHora[0];
            A522ParametroDelUsuId = BC000X4_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = BC000X4_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = BC000X4_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = BC000X4_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = BC000X4_A344ParametroDescricao[0];
            n344ParametroDescricao = BC000X4_n344ParametroDescricao[0];
            A343ParametroValor = BC000X4_A343ParametroValor[0];
            n343ParametroValor = BC000X4_n343ParametroValor[0];
            A518ParametroDel = BC000X4_A518ParametroDel[0];
            ZM0X36( -10) ;
         }
         pr_default.close(2);
         OnLoadActions0X36( ) ;
      }

      protected void OnLoadActions0X36( )
      {
      }

      protected void CheckExtendedTable0X36( )
      {
         nIsDirty_36 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0X36( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X36( )
      {
         /* Using cursor BC000X5 */
         pr_default.execute(3, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000X3 */
         pr_default.execute(1, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X36( 10) ;
            RcdFound36 = 1;
            A342ParametroChave = BC000X3_A342ParametroChave[0];
            A519ParametroDelDataHora = BC000X3_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = BC000X3_n519ParametroDelDataHora[0];
            A520ParametroDelData = BC000X3_A520ParametroDelData[0];
            n520ParametroDelData = BC000X3_n520ParametroDelData[0];
            A521ParametroDelHora = BC000X3_A521ParametroDelHora[0];
            n521ParametroDelHora = BC000X3_n521ParametroDelHora[0];
            A522ParametroDelUsuId = BC000X3_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = BC000X3_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = BC000X3_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = BC000X3_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = BC000X3_A344ParametroDescricao[0];
            n344ParametroDescricao = BC000X3_n344ParametroDescricao[0];
            A343ParametroValor = BC000X3_A343ParametroValor[0];
            n343ParametroValor = BC000X3_n343ParametroValor[0];
            A518ParametroDel = BC000X3_A518ParametroDel[0];
            O518ParametroDel = A518ParametroDel;
            Z342ParametroChave = A342ParametroChave;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0X36( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey0X36( ) ;
            }
            Gx_mode = sMode36;
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0X36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode36;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X36( ) ;
         if ( RcdFound36 == 0 )
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
         CONFIRM_0X0( ) ;
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

      protected void CheckOptimisticConcurrency0X36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000X2 */
            pr_default.execute(0, new Object[] {A342ParametroChave});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_parametro"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z519ParametroDelDataHora != BC000X2_A519ParametroDelDataHora[0] ) || ( Z520ParametroDelData != BC000X2_A520ParametroDelData[0] ) || ( Z521ParametroDelHora != BC000X2_A521ParametroDelHora[0] ) || ( StringUtil.StrCmp(Z522ParametroDelUsuId, BC000X2_A522ParametroDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z523ParametroDelUsuNome, BC000X2_A523ParametroDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z344ParametroDescricao, BC000X2_A344ParametroDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z343ParametroValor, BC000X2_A343ParametroValor[0]) != 0 ) || ( Z518ParametroDel != BC000X2_A518ParametroDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_parametro"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X36( 0) ;
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X6 */
                     pr_default.execute(4, new Object[] {A342ParametroChave, n519ParametroDelDataHora, A519ParametroDelDataHora, n520ParametroDelData, A520ParametroDelData, n521ParametroDelHora, A521ParametroDelHora, n522ParametroDelUsuId, A522ParametroDelUsuId, n523ParametroDelUsuNome, A523ParametroDelUsuNome, n344ParametroDescricao, A344ParametroDescricao, n343ParametroValor, A343ParametroValor, A518ParametroDel});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load0X36( ) ;
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void Update0X36( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000X7 */
                     pr_default.execute(5, new Object[] {n519ParametroDelDataHora, A519ParametroDelDataHora, n520ParametroDelData, A520ParametroDelData, n521ParametroDelHora, A521ParametroDelHora, n522ParametroDelUsuId, A522ParametroDelUsuId, n523ParametroDelUsuNome, A523ParametroDelUsuNome, n344ParametroDescricao, A344ParametroDescricao, n343ParametroValor, A343ParametroValor, A518ParametroDel, A342ParametroChave});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_parametro"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X36( ) ;
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
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void DeferredUpdate0X36( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X36( ) ;
            AfterConfirm0X36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000X8 */
                  pr_default.execute(6, new Object[] {A342ParametroChave});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
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
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0X36( ) ;
         Gx_mode = sMode36;
      }

      protected void OnDeleteControls0X36( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0X36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X36( ) ;
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

      public void ScanKeyStart0X36( )
      {
         /* Scan By routine */
         /* Using cursor BC000X9 */
         pr_default.execute(7, new Object[] {A342ParametroChave});
         RcdFound36 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound36 = 1;
            A342ParametroChave = BC000X9_A342ParametroChave[0];
            A519ParametroDelDataHora = BC000X9_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = BC000X9_n519ParametroDelDataHora[0];
            A520ParametroDelData = BC000X9_A520ParametroDelData[0];
            n520ParametroDelData = BC000X9_n520ParametroDelData[0];
            A521ParametroDelHora = BC000X9_A521ParametroDelHora[0];
            n521ParametroDelHora = BC000X9_n521ParametroDelHora[0];
            A522ParametroDelUsuId = BC000X9_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = BC000X9_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = BC000X9_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = BC000X9_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = BC000X9_A344ParametroDescricao[0];
            n344ParametroDescricao = BC000X9_n344ParametroDescricao[0];
            A343ParametroValor = BC000X9_A343ParametroValor[0];
            n343ParametroValor = BC000X9_n343ParametroValor[0];
            A518ParametroDel = BC000X9_A518ParametroDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0X36( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound36 = 0;
         ScanKeyLoad0X36( ) ;
      }

      protected void ScanKeyLoad0X36( )
      {
         sMode36 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound36 = 1;
            A342ParametroChave = BC000X9_A342ParametroChave[0];
            A519ParametroDelDataHora = BC000X9_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = BC000X9_n519ParametroDelDataHora[0];
            A520ParametroDelData = BC000X9_A520ParametroDelData[0];
            n520ParametroDelData = BC000X9_n520ParametroDelData[0];
            A521ParametroDelHora = BC000X9_A521ParametroDelHora[0];
            n521ParametroDelHora = BC000X9_n521ParametroDelHora[0];
            A522ParametroDelUsuId = BC000X9_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = BC000X9_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = BC000X9_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = BC000X9_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = BC000X9_A344ParametroDescricao[0];
            n344ParametroDescricao = BC000X9_n344ParametroDescricao[0];
            A343ParametroValor = BC000X9_A343ParametroValor[0];
            n343ParametroValor = BC000X9_n343ParametroValor[0];
            A518ParametroDel = BC000X9_A518ParametroDel[0];
         }
         Gx_mode = sMode36;
      }

      protected void ScanKeyEnd0X36( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0X36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X36( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A519ParametroDelDataHora = DateTimeUtil.NowMS( context);
            n519ParametroDelDataHora = false;
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A522ParametroDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n522ParametroDelUsuId = false;
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A523ParametroDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n523ParametroDelUsuNome = false;
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A520ParametroDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A519ParametroDelDataHora) ) ;
            n520ParametroDelData = false;
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A521ParametroDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A519ParametroDelDataHora));
            n521ParametroDelHora = false;
         }
      }

      protected void BeforeDelete0X36( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
      }

      protected void BeforeComplete0X36( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0X36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X36( )
      {
      }

      protected void send_integrity_lvl_hashes0X36( )
      {
      }

      protected void AddRow0X36( )
      {
         VarsToRow36( bccore_Parametros) ;
      }

      protected void ReadRow0X36( )
      {
         RowToVars36( bccore_Parametros, 1) ;
      }

      protected void InitializeNonKey0X36( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         n519ParametroDelDataHora = false;
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         n520ParametroDelData = false;
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         n521ParametroDelHora = false;
         A522ParametroDelUsuId = "";
         n522ParametroDelUsuId = false;
         A523ParametroDelUsuNome = "";
         n523ParametroDelUsuNome = false;
         A344ParametroDescricao = "";
         n344ParametroDescricao = false;
         A343ParametroValor = "";
         n343ParametroValor = false;
         A518ParametroDel = false;
         O518ParametroDel = A518ParametroDel;
         Z519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         Z520ParametroDelData = (DateTime)(DateTime.MinValue);
         Z521ParametroDelHora = (DateTime)(DateTime.MinValue);
         Z522ParametroDelUsuId = "";
         Z523ParametroDelUsuNome = "";
         Z344ParametroDescricao = "";
         Z343ParametroValor = "";
         Z518ParametroDel = false;
      }

      protected void InitAll0X36( )
      {
         A342ParametroChave = "";
         InitializeNonKey0X36( ) ;
      }

      protected void StandaloneModalInsert( )
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

      public void VarsToRow36( GeneXus.Programs.core.SdtParametros obj36 )
      {
         obj36.gxTpr_Mode = Gx_mode;
         obj36.gxTpr_Parametrodeldatahora = A519ParametroDelDataHora;
         obj36.gxTpr_Parametrodeldata = A520ParametroDelData;
         obj36.gxTpr_Parametrodelhora = A521ParametroDelHora;
         obj36.gxTpr_Parametrodelusuid = A522ParametroDelUsuId;
         obj36.gxTpr_Parametrodelusunome = A523ParametroDelUsuNome;
         obj36.gxTpr_Parametrodescricao = A344ParametroDescricao;
         obj36.gxTpr_Parametrovalor = A343ParametroValor;
         obj36.gxTpr_Parametrodel = A518ParametroDel;
         obj36.gxTpr_Parametrochave = A342ParametroChave;
         obj36.gxTpr_Parametrochave_Z = Z342ParametroChave;
         obj36.gxTpr_Parametrodescricao_Z = Z344ParametroDescricao;
         obj36.gxTpr_Parametrovalor_Z = Z343ParametroValor;
         obj36.gxTpr_Parametrodel_Z = Z518ParametroDel;
         obj36.gxTpr_Parametrodeldatahora_Z = Z519ParametroDelDataHora;
         obj36.gxTpr_Parametrodeldata_Z = Z520ParametroDelData;
         obj36.gxTpr_Parametrodelhora_Z = Z521ParametroDelHora;
         obj36.gxTpr_Parametrodelusuid_Z = Z522ParametroDelUsuId;
         obj36.gxTpr_Parametrodelusunome_Z = Z523ParametroDelUsuNome;
         obj36.gxTpr_Parametrodescricao_N = (short)(Convert.ToInt16(n344ParametroDescricao));
         obj36.gxTpr_Parametrovalor_N = (short)(Convert.ToInt16(n343ParametroValor));
         obj36.gxTpr_Parametrodeldatahora_N = (short)(Convert.ToInt16(n519ParametroDelDataHora));
         obj36.gxTpr_Parametrodeldata_N = (short)(Convert.ToInt16(n520ParametroDelData));
         obj36.gxTpr_Parametrodelhora_N = (short)(Convert.ToInt16(n521ParametroDelHora));
         obj36.gxTpr_Parametrodelusuid_N = (short)(Convert.ToInt16(n522ParametroDelUsuId));
         obj36.gxTpr_Parametrodelusunome_N = (short)(Convert.ToInt16(n523ParametroDelUsuNome));
         obj36.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow36( GeneXus.Programs.core.SdtParametros obj36 )
      {
         obj36.gxTpr_Parametrochave = A342ParametroChave;
         return  ;
      }

      public void RowToVars36( GeneXus.Programs.core.SdtParametros obj36 ,
                               int forceLoad )
      {
         Gx_mode = obj36.gxTpr_Mode;
         A519ParametroDelDataHora = obj36.gxTpr_Parametrodeldatahora;
         n519ParametroDelDataHora = false;
         A520ParametroDelData = obj36.gxTpr_Parametrodeldata;
         n520ParametroDelData = false;
         A521ParametroDelHora = obj36.gxTpr_Parametrodelhora;
         n521ParametroDelHora = false;
         A522ParametroDelUsuId = obj36.gxTpr_Parametrodelusuid;
         n522ParametroDelUsuId = false;
         A523ParametroDelUsuNome = obj36.gxTpr_Parametrodelusunome;
         n523ParametroDelUsuNome = false;
         A344ParametroDescricao = obj36.gxTpr_Parametrodescricao;
         n344ParametroDescricao = false;
         A343ParametroValor = obj36.gxTpr_Parametrovalor;
         n343ParametroValor = false;
         A518ParametroDel = obj36.gxTpr_Parametrodel;
         A342ParametroChave = obj36.gxTpr_Parametrochave;
         Z342ParametroChave = obj36.gxTpr_Parametrochave_Z;
         Z344ParametroDescricao = obj36.gxTpr_Parametrodescricao_Z;
         Z343ParametroValor = obj36.gxTpr_Parametrovalor_Z;
         Z518ParametroDel = obj36.gxTpr_Parametrodel_Z;
         O518ParametroDel = obj36.gxTpr_Parametrodel_Z;
         Z519ParametroDelDataHora = obj36.gxTpr_Parametrodeldatahora_Z;
         Z520ParametroDelData = obj36.gxTpr_Parametrodeldata_Z;
         Z521ParametroDelHora = obj36.gxTpr_Parametrodelhora_Z;
         Z522ParametroDelUsuId = obj36.gxTpr_Parametrodelusuid_Z;
         Z523ParametroDelUsuNome = obj36.gxTpr_Parametrodelusunome_Z;
         n344ParametroDescricao = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodescricao_N));
         n343ParametroValor = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrovalor_N));
         n519ParametroDelDataHora = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodeldatahora_N));
         n520ParametroDelData = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodeldata_N));
         n521ParametroDelHora = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodelhora_N));
         n522ParametroDelUsuId = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodelusuid_N));
         n523ParametroDelUsuNome = (bool)(Convert.ToBoolean(obj36.gxTpr_Parametrodelusunome_N));
         Gx_mode = obj36.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A342ParametroChave = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0X36( ) ;
         ScanKeyStart0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z342ParametroChave = A342ParametroChave;
            O518ParametroDel = A518ParametroDel;
         }
         ZM0X36( -10) ;
         OnLoadActions0X36( ) ;
         AddRow0X36( ) ;
         ScanKeyEnd0X36( ) ;
         if ( RcdFound36 == 0 )
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
         RowToVars36( bccore_Parametros, 0) ;
         ScanKeyStart0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z342ParametroChave = A342ParametroChave;
            O518ParametroDel = A518ParametroDel;
         }
         ZM0X36( -10) ;
         OnLoadActions0X36( ) ;
         AddRow0X36( ) ;
         ScanKeyEnd0X36( ) ;
         if ( RcdFound36 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0X36( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0X36( ) ;
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
               {
                  A342ParametroChave = Z342ParametroChave;
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
                  Update0X36( ) ;
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
                  if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
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
                        Insert0X36( ) ;
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
                        Insert0X36( ) ;
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
         RowToVars36( bccore_Parametros, 1) ;
         SaveImpl( ) ;
         VarsToRow36( bccore_Parametros) ;
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
         RowToVars36( bccore_Parametros, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X36( ) ;
         AfterTrn( ) ;
         VarsToRow36( bccore_Parametros) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow36( bccore_Parametros) ;
         }
         else
         {
            GeneXus.Programs.core.SdtParametros auxBC = new GeneXus.Programs.core.SdtParametros(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A342ParametroChave);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Parametros);
               auxBC.Save();
               bccore_Parametros.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars36( bccore_Parametros, 1) ;
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
         RowToVars36( bccore_Parametros, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0X36( ) ;
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
               VarsToRow36( bccore_Parametros) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow36( bccore_Parametros) ;
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
         RowToVars36( bccore_Parametros, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0X36( ) ;
         if ( RcdFound36 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
            {
               A342ParametroChave = Z342ParametroChave;
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
            if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
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
         context.RollbackDataStores("core.parametros_bc",pr_default);
         VarsToRow36( bccore_Parametros) ;
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
         Gx_mode = bccore_Parametros.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Parametros.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Parametros )
         {
            bccore_Parametros = (GeneXus.Programs.core.SdtParametros)(sdt);
            if ( StringUtil.StrCmp(bccore_Parametros.gxTpr_Mode, "") == 0 )
            {
               bccore_Parametros.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow36( bccore_Parametros) ;
            }
            else
            {
               RowToVars36( bccore_Parametros, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Parametros.gxTpr_Mode, "") == 0 )
            {
               bccore_Parametros.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars36( bccore_Parametros, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtParametros Parametros_BC
      {
         get {
            return bccore_Parametros ;
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
            return "parametros_Execute" ;
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
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z342ParametroChave = "";
         A342ParametroChave = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Z519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         Z520ParametroDelData = (DateTime)(DateTime.MinValue);
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         Z521ParametroDelHora = (DateTime)(DateTime.MinValue);
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         Z522ParametroDelUsuId = "";
         A522ParametroDelUsuId = "";
         Z523ParametroDelUsuNome = "";
         A523ParametroDelUsuNome = "";
         Z344ParametroDescricao = "";
         A344ParametroDescricao = "";
         Z343ParametroValor = "";
         A343ParametroValor = "";
         BC000X4_A342ParametroChave = new string[] {""} ;
         BC000X4_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000X4_n519ParametroDelDataHora = new bool[] {false} ;
         BC000X4_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         BC000X4_n520ParametroDelData = new bool[] {false} ;
         BC000X4_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000X4_n521ParametroDelHora = new bool[] {false} ;
         BC000X4_A522ParametroDelUsuId = new string[] {""} ;
         BC000X4_n522ParametroDelUsuId = new bool[] {false} ;
         BC000X4_A523ParametroDelUsuNome = new string[] {""} ;
         BC000X4_n523ParametroDelUsuNome = new bool[] {false} ;
         BC000X4_A344ParametroDescricao = new string[] {""} ;
         BC000X4_n344ParametroDescricao = new bool[] {false} ;
         BC000X4_A343ParametroValor = new string[] {""} ;
         BC000X4_n343ParametroValor = new bool[] {false} ;
         BC000X4_A518ParametroDel = new bool[] {false} ;
         BC000X5_A342ParametroChave = new string[] {""} ;
         BC000X3_A342ParametroChave = new string[] {""} ;
         BC000X3_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000X3_n519ParametroDelDataHora = new bool[] {false} ;
         BC000X3_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         BC000X3_n520ParametroDelData = new bool[] {false} ;
         BC000X3_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000X3_n521ParametroDelHora = new bool[] {false} ;
         BC000X3_A522ParametroDelUsuId = new string[] {""} ;
         BC000X3_n522ParametroDelUsuId = new bool[] {false} ;
         BC000X3_A523ParametroDelUsuNome = new string[] {""} ;
         BC000X3_n523ParametroDelUsuNome = new bool[] {false} ;
         BC000X3_A344ParametroDescricao = new string[] {""} ;
         BC000X3_n344ParametroDescricao = new bool[] {false} ;
         BC000X3_A343ParametroValor = new string[] {""} ;
         BC000X3_n343ParametroValor = new bool[] {false} ;
         BC000X3_A518ParametroDel = new bool[] {false} ;
         sMode36 = "";
         BC000X2_A342ParametroChave = new string[] {""} ;
         BC000X2_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000X2_n519ParametroDelDataHora = new bool[] {false} ;
         BC000X2_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         BC000X2_n520ParametroDelData = new bool[] {false} ;
         BC000X2_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000X2_n521ParametroDelHora = new bool[] {false} ;
         BC000X2_A522ParametroDelUsuId = new string[] {""} ;
         BC000X2_n522ParametroDelUsuId = new bool[] {false} ;
         BC000X2_A523ParametroDelUsuNome = new string[] {""} ;
         BC000X2_n523ParametroDelUsuNome = new bool[] {false} ;
         BC000X2_A344ParametroDescricao = new string[] {""} ;
         BC000X2_n344ParametroDescricao = new bool[] {false} ;
         BC000X2_A343ParametroValor = new string[] {""} ;
         BC000X2_n343ParametroValor = new bool[] {false} ;
         BC000X2_A518ParametroDel = new bool[] {false} ;
         BC000X9_A342ParametroChave = new string[] {""} ;
         BC000X9_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000X9_n519ParametroDelDataHora = new bool[] {false} ;
         BC000X9_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         BC000X9_n520ParametroDelData = new bool[] {false} ;
         BC000X9_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000X9_n521ParametroDelHora = new bool[] {false} ;
         BC000X9_A522ParametroDelUsuId = new string[] {""} ;
         BC000X9_n522ParametroDelUsuId = new bool[] {false} ;
         BC000X9_A523ParametroDelUsuNome = new string[] {""} ;
         BC000X9_n523ParametroDelUsuNome = new bool[] {false} ;
         BC000X9_A344ParametroDescricao = new string[] {""} ;
         BC000X9_n344ParametroDescricao = new bool[] {false} ;
         BC000X9_A343ParametroValor = new string[] {""} ;
         BC000X9_n343ParametroValor = new bool[] {false} ;
         BC000X9_A518ParametroDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.parametros_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametros_bc__default(),
            new Object[][] {
                new Object[] {
               BC000X2_A342ParametroChave, BC000X2_A519ParametroDelDataHora, BC000X2_n519ParametroDelDataHora, BC000X2_A520ParametroDelData, BC000X2_n520ParametroDelData, BC000X2_A521ParametroDelHora, BC000X2_n521ParametroDelHora, BC000X2_A522ParametroDelUsuId, BC000X2_n522ParametroDelUsuId, BC000X2_A523ParametroDelUsuNome,
               BC000X2_n523ParametroDelUsuNome, BC000X2_A344ParametroDescricao, BC000X2_n344ParametroDescricao, BC000X2_A343ParametroValor, BC000X2_n343ParametroValor, BC000X2_A518ParametroDel
               }
               , new Object[] {
               BC000X3_A342ParametroChave, BC000X3_A519ParametroDelDataHora, BC000X3_n519ParametroDelDataHora, BC000X3_A520ParametroDelData, BC000X3_n520ParametroDelData, BC000X3_A521ParametroDelHora, BC000X3_n521ParametroDelHora, BC000X3_A522ParametroDelUsuId, BC000X3_n522ParametroDelUsuId, BC000X3_A523ParametroDelUsuNome,
               BC000X3_n523ParametroDelUsuNome, BC000X3_A344ParametroDescricao, BC000X3_n344ParametroDescricao, BC000X3_A343ParametroValor, BC000X3_n343ParametroValor, BC000X3_A518ParametroDel
               }
               , new Object[] {
               BC000X4_A342ParametroChave, BC000X4_A519ParametroDelDataHora, BC000X4_n519ParametroDelDataHora, BC000X4_A520ParametroDelData, BC000X4_n520ParametroDelData, BC000X4_A521ParametroDelHora, BC000X4_n521ParametroDelHora, BC000X4_A522ParametroDelUsuId, BC000X4_n522ParametroDelUsuId, BC000X4_A523ParametroDelUsuNome,
               BC000X4_n523ParametroDelUsuNome, BC000X4_A344ParametroDescricao, BC000X4_n344ParametroDescricao, BC000X4_A343ParametroValor, BC000X4_n343ParametroValor, BC000X4_A518ParametroDel
               }
               , new Object[] {
               BC000X5_A342ParametroChave
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000X9_A342ParametroChave, BC000X9_A519ParametroDelDataHora, BC000X9_n519ParametroDelDataHora, BC000X9_A520ParametroDelData, BC000X9_n520ParametroDelData, BC000X9_A521ParametroDelHora, BC000X9_n521ParametroDelHora, BC000X9_A522ParametroDelUsuId, BC000X9_n522ParametroDelUsuId, BC000X9_A523ParametroDelUsuNome,
               BC000X9_n523ParametroDelUsuNome, BC000X9_A344ParametroDescricao, BC000X9_n344ParametroDescricao, BC000X9_A343ParametroValor, BC000X9_n343ParametroValor, BC000X9_A518ParametroDel
               }
            }
         );
         AV14Pgmname = "core.Parametros_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120X2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound36 ;
      private short nIsDirty_36 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z522ParametroDelUsuId ;
      private string A522ParametroDelUsuId ;
      private string sMode36 ;
      private DateTime Z519ParametroDelDataHora ;
      private DateTime A519ParametroDelDataHora ;
      private DateTime Z520ParametroDelData ;
      private DateTime A520ParametroDelData ;
      private DateTime Z521ParametroDelHora ;
      private DateTime A521ParametroDelHora ;
      private bool returnInSub ;
      private bool Z518ParametroDel ;
      private bool A518ParametroDel ;
      private bool n519ParametroDelDataHora ;
      private bool n520ParametroDelData ;
      private bool n521ParametroDelHora ;
      private bool n522ParametroDelUsuId ;
      private bool n523ParametroDelUsuNome ;
      private bool n344ParametroDescricao ;
      private bool n343ParametroValor ;
      private bool O518ParametroDel ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z342ParametroChave ;
      private string A342ParametroChave ;
      private string Z523ParametroDelUsuNome ;
      private string A523ParametroDelUsuNome ;
      private string Z344ParametroDescricao ;
      private string A344ParametroDescricao ;
      private string Z343ParametroValor ;
      private string A343ParametroValor ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtParametros bccore_Parametros ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000X4_A342ParametroChave ;
      private DateTime[] BC000X4_A519ParametroDelDataHora ;
      private bool[] BC000X4_n519ParametroDelDataHora ;
      private DateTime[] BC000X4_A520ParametroDelData ;
      private bool[] BC000X4_n520ParametroDelData ;
      private DateTime[] BC000X4_A521ParametroDelHora ;
      private bool[] BC000X4_n521ParametroDelHora ;
      private string[] BC000X4_A522ParametroDelUsuId ;
      private bool[] BC000X4_n522ParametroDelUsuId ;
      private string[] BC000X4_A523ParametroDelUsuNome ;
      private bool[] BC000X4_n523ParametroDelUsuNome ;
      private string[] BC000X4_A344ParametroDescricao ;
      private bool[] BC000X4_n344ParametroDescricao ;
      private string[] BC000X4_A343ParametroValor ;
      private bool[] BC000X4_n343ParametroValor ;
      private bool[] BC000X4_A518ParametroDel ;
      private string[] BC000X5_A342ParametroChave ;
      private string[] BC000X3_A342ParametroChave ;
      private DateTime[] BC000X3_A519ParametroDelDataHora ;
      private bool[] BC000X3_n519ParametroDelDataHora ;
      private DateTime[] BC000X3_A520ParametroDelData ;
      private bool[] BC000X3_n520ParametroDelData ;
      private DateTime[] BC000X3_A521ParametroDelHora ;
      private bool[] BC000X3_n521ParametroDelHora ;
      private string[] BC000X3_A522ParametroDelUsuId ;
      private bool[] BC000X3_n522ParametroDelUsuId ;
      private string[] BC000X3_A523ParametroDelUsuNome ;
      private bool[] BC000X3_n523ParametroDelUsuNome ;
      private string[] BC000X3_A344ParametroDescricao ;
      private bool[] BC000X3_n344ParametroDescricao ;
      private string[] BC000X3_A343ParametroValor ;
      private bool[] BC000X3_n343ParametroValor ;
      private bool[] BC000X3_A518ParametroDel ;
      private string[] BC000X2_A342ParametroChave ;
      private DateTime[] BC000X2_A519ParametroDelDataHora ;
      private bool[] BC000X2_n519ParametroDelDataHora ;
      private DateTime[] BC000X2_A520ParametroDelData ;
      private bool[] BC000X2_n520ParametroDelData ;
      private DateTime[] BC000X2_A521ParametroDelHora ;
      private bool[] BC000X2_n521ParametroDelHora ;
      private string[] BC000X2_A522ParametroDelUsuId ;
      private bool[] BC000X2_n522ParametroDelUsuId ;
      private string[] BC000X2_A523ParametroDelUsuNome ;
      private bool[] BC000X2_n523ParametroDelUsuNome ;
      private string[] BC000X2_A344ParametroDescricao ;
      private bool[] BC000X2_n344ParametroDescricao ;
      private string[] BC000X2_A343ParametroValor ;
      private bool[] BC000X2_n343ParametroValor ;
      private bool[] BC000X2_A518ParametroDel ;
      private string[] BC000X9_A342ParametroChave ;
      private DateTime[] BC000X9_A519ParametroDelDataHora ;
      private bool[] BC000X9_n519ParametroDelDataHora ;
      private DateTime[] BC000X9_A520ParametroDelData ;
      private bool[] BC000X9_n520ParametroDelData ;
      private DateTime[] BC000X9_A521ParametroDelHora ;
      private bool[] BC000X9_n521ParametroDelHora ;
      private string[] BC000X9_A522ParametroDelUsuId ;
      private bool[] BC000X9_n522ParametroDelUsuId ;
      private string[] BC000X9_A523ParametroDelUsuNome ;
      private bool[] BC000X9_n523ParametroDelUsuNome ;
      private string[] BC000X9_A344ParametroDescricao ;
      private bool[] BC000X9_n344ParametroDescricao ;
      private string[] BC000X9_A343ParametroValor ;
      private bool[] BC000X9_n343ParametroValor ;
      private bool[] BC000X9_A518ParametroDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class parametros_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class parametros_bc__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new UpdateCursor(def[4])
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000X4;
        prmBC000X4 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X5;
        prmBC000X5 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X3;
        prmBC000X3 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X2;
        prmBC000X2 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X6;
        prmBC000X6 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0) ,
        new ParDef("ParametroDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("ParametroDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("ParametroDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("ParametroDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("ParametroDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true} ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000X7;
        prmBC000X7 = new Object[] {
        new ParDef("ParametroDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("ParametroDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("ParametroDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("ParametroDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("ParametroDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true} ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroDel",GXType.Boolean,4,0) ,
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X8;
        prmBC000X8 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmBC000X9;
        prmBC000X9 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000X2", "SELECT ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel FROM tb_parametro WHERE ParametroChave = :ParametroChave  FOR UPDATE OF tb_parametro",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X3", "SELECT ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel FROM tb_parametro WHERE ParametroChave = :ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X4", "SELECT TM1.ParametroChave, TM1.ParametroDelDataHora, TM1.ParametroDelData, TM1.ParametroDelHora, TM1.ParametroDelUsuId, TM1.ParametroDelUsuNome, TM1.ParametroDescricao, TM1.ParametroValor, TM1.ParametroDel FROM tb_parametro TM1 WHERE TM1.ParametroChave = ( :ParametroChave) ORDER BY TM1.ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X5", "SELECT ParametroChave FROM tb_parametro WHERE ParametroChave = :ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000X6", "SAVEPOINT gxupdate;INSERT INTO tb_parametro(ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel) VALUES(:ParametroChave, :ParametroDelDataHora, :ParametroDelData, :ParametroDelHora, :ParametroDelUsuId, :ParametroDelUsuNome, :ParametroDescricao, :ParametroValor, :ParametroDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000X6)
           ,new CursorDef("BC000X7", "SAVEPOINT gxupdate;UPDATE tb_parametro SET ParametroDelDataHora=:ParametroDelDataHora, ParametroDelData=:ParametroDelData, ParametroDelHora=:ParametroDelHora, ParametroDelUsuId=:ParametroDelUsuId, ParametroDelUsuNome=:ParametroDelUsuNome, ParametroDescricao=:ParametroDescricao, ParametroValor=:ParametroValor, ParametroDel=:ParametroDel  WHERE ParametroChave = :ParametroChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X7)
           ,new CursorDef("BC000X8", "SAVEPOINT gxupdate;DELETE FROM tb_parametro  WHERE ParametroChave = :ParametroChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000X8)
           ,new CursorDef("BC000X9", "SELECT TM1.ParametroChave, TM1.ParametroDelDataHora, TM1.ParametroDelData, TM1.ParametroDelHora, TM1.ParametroDelUsuId, TM1.ParametroDelUsuNome, TM1.ParametroDescricao, TM1.ParametroValor, TM1.ParametroDel FROM tb_parametro TM1 WHERE TM1.ParametroChave = ( :ParametroChave) ORDER BY TM1.ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000X9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
     }
  }

}

}
