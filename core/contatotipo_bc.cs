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
   public class contatotipo_bc : GxSilentTrn, IGxSilentTrn
   {
      public contatotipo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contatotipo_bc( IGxContext context )
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
         ReadRow0L21( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0L21( ) ;
         standaloneModal( ) ;
         AddRow0L21( ) ;
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
            E110L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z149CotID = A149CotID;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L21( ) ;
            }
            else
            {
               CheckExtendedTable0L21( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0L21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
      }

      protected void ZM0L21( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z567CotDelDataHora = A567CotDelDataHora;
            Z568CotDelData = A568CotDelData;
            Z569CotDelHora = A569CotDelHora;
            Z570CotDelUsuId = A570CotDelUsuId;
            Z571CotDelUsuNome = A571CotDelUsuNome;
            Z150CotSigla = A150CotSigla;
            Z151CotNome = A151CotNome;
            Z216CotAtivo = A216CotAtivo;
            Z566CotDel = A566CotDel;
         }
         if ( GX_JID == -13 )
         {
            Z149CotID = A149CotID;
            Z567CotDelDataHora = A567CotDelDataHora;
            Z568CotDelData = A568CotDelData;
            Z569CotDelHora = A569CotDelHora;
            Z570CotDelUsuId = A570CotDelUsuId;
            Z571CotDelUsuNome = A571CotDelUsuNome;
            Z150CotSigla = A150CotSigla;
            Z151CotNome = A151CotNome;
            Z216CotAtivo = A216CotAtivo;
            Z566CotDel = A566CotDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV15Pgmname = "core.ContatoTipo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A216CotAtivo) && ( Gx_BScreen == 0 ) )
         {
            A216CotAtivo = true;
         }
      }

      protected void Load0L21( )
      {
         /* Using cursor BC000L4 */
         pr_default.execute(2, new Object[] {A149CotID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A567CotDelDataHora = BC000L4_A567CotDelDataHora[0];
            n567CotDelDataHora = BC000L4_n567CotDelDataHora[0];
            A568CotDelData = BC000L4_A568CotDelData[0];
            n568CotDelData = BC000L4_n568CotDelData[0];
            A569CotDelHora = BC000L4_A569CotDelHora[0];
            n569CotDelHora = BC000L4_n569CotDelHora[0];
            A570CotDelUsuId = BC000L4_A570CotDelUsuId[0];
            n570CotDelUsuId = BC000L4_n570CotDelUsuId[0];
            A571CotDelUsuNome = BC000L4_A571CotDelUsuNome[0];
            n571CotDelUsuNome = BC000L4_n571CotDelUsuNome[0];
            A150CotSigla = BC000L4_A150CotSigla[0];
            A151CotNome = BC000L4_A151CotNome[0];
            A216CotAtivo = BC000L4_A216CotAtivo[0];
            A566CotDel = BC000L4_A566CotDel[0];
            ZM0L21( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0L21( ) ;
      }

      protected void OnLoadActions0L21( )
      {
      }

      protected void CheckExtendedTable0L21( )
      {
         nIsDirty_21 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000L5 */
         pr_default.execute(3, new Object[] {A150CotSigla, A149CotID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A150CotSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A151CotNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0L21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L21( )
      {
         /* Using cursor BC000L6 */
         pr_default.execute(4, new Object[] {A149CotID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000L3 */
         pr_default.execute(1, new Object[] {A149CotID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L21( 13) ;
            RcdFound21 = 1;
            A149CotID = BC000L3_A149CotID[0];
            A567CotDelDataHora = BC000L3_A567CotDelDataHora[0];
            n567CotDelDataHora = BC000L3_n567CotDelDataHora[0];
            A568CotDelData = BC000L3_A568CotDelData[0];
            n568CotDelData = BC000L3_n568CotDelData[0];
            A569CotDelHora = BC000L3_A569CotDelHora[0];
            n569CotDelHora = BC000L3_n569CotDelHora[0];
            A570CotDelUsuId = BC000L3_A570CotDelUsuId[0];
            n570CotDelUsuId = BC000L3_n570CotDelUsuId[0];
            A571CotDelUsuNome = BC000L3_A571CotDelUsuNome[0];
            n571CotDelUsuNome = BC000L3_n571CotDelUsuNome[0];
            A150CotSigla = BC000L3_A150CotSigla[0];
            A151CotNome = BC000L3_A151CotNome[0];
            A216CotAtivo = BC000L3_A216CotAtivo[0];
            A566CotDel = BC000L3_A566CotDel[0];
            O566CotDel = A566CotDel;
            Z149CotID = A149CotID;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0L21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0L21( ) ;
            }
            Gx_mode = sMode21;
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0L21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode21;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L21( ) ;
         if ( RcdFound21 == 0 )
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
         CONFIRM_0L0( ) ;
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

      protected void CheckOptimisticConcurrency0L21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000L2 */
            pr_default.execute(0, new Object[] {A149CotID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_contatotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z567CotDelDataHora != BC000L2_A567CotDelDataHora[0] ) || ( Z568CotDelData != BC000L2_A568CotDelData[0] ) || ( Z569CotDelHora != BC000L2_A569CotDelHora[0] ) || ( StringUtil.StrCmp(Z570CotDelUsuId, BC000L2_A570CotDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z571CotDelUsuNome, BC000L2_A571CotDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z150CotSigla, BC000L2_A150CotSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z151CotNome, BC000L2_A151CotNome[0]) != 0 ) || ( Z216CotAtivo != BC000L2_A216CotAtivo[0] ) || ( Z566CotDel != BC000L2_A566CotDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_contatotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L21( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L21( 0) ;
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L7 */
                     pr_default.execute(5, new Object[] {n567CotDelDataHora, A567CotDelDataHora, n568CotDelData, A568CotDelData, n569CotDelHora, A569CotDelHora, n570CotDelUsuId, A570CotDelUsuId, n571CotDelUsuNome, A571CotDelUsuNome, A150CotSigla, A151CotNome, A216CotAtivo, A566CotDel});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000L8 */
                     pr_default.execute(6);
                     A149CotID = BC000L8_A149CotID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
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
               Load0L21( ) ;
            }
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void Update0L21( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000L9 */
                     pr_default.execute(7, new Object[] {n567CotDelDataHora, A567CotDelDataHora, n568CotDelData, A568CotDelData, n569CotDelHora, A569CotDelHora, n570CotDelUsuId, A570CotDelUsuId, n571CotDelUsuNome, A571CotDelUsuNome, A150CotSigla, A151CotNome, A216CotAtivo, A566CotDel, A149CotID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_contatotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L21( ) ;
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
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void DeferredUpdate0L21( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L21( ) ;
            AfterConfirm0L21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000L10 */
                  pr_default.execute(8, new Object[] {A149CotID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0L21( ) ;
         Gx_mode = sMode21;
      }

      protected void OnDeleteControls0L21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L21( ) ;
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

      public void ScanKeyStart0L21( )
      {
         /* Scan By routine */
         /* Using cursor BC000L11 */
         pr_default.execute(9, new Object[] {A149CotID});
         RcdFound21 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound21 = 1;
            A149CotID = BC000L11_A149CotID[0];
            A567CotDelDataHora = BC000L11_A567CotDelDataHora[0];
            n567CotDelDataHora = BC000L11_n567CotDelDataHora[0];
            A568CotDelData = BC000L11_A568CotDelData[0];
            n568CotDelData = BC000L11_n568CotDelData[0];
            A569CotDelHora = BC000L11_A569CotDelHora[0];
            n569CotDelHora = BC000L11_n569CotDelHora[0];
            A570CotDelUsuId = BC000L11_A570CotDelUsuId[0];
            n570CotDelUsuId = BC000L11_n570CotDelUsuId[0];
            A571CotDelUsuNome = BC000L11_A571CotDelUsuNome[0];
            n571CotDelUsuNome = BC000L11_n571CotDelUsuNome[0];
            A150CotSigla = BC000L11_A150CotSigla[0];
            A151CotNome = BC000L11_A151CotNome[0];
            A216CotAtivo = BC000L11_A216CotAtivo[0];
            A566CotDel = BC000L11_A566CotDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0L21( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound21 = 0;
         ScanKeyLoad0L21( ) ;
      }

      protected void ScanKeyLoad0L21( )
      {
         sMode21 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound21 = 1;
            A149CotID = BC000L11_A149CotID[0];
            A567CotDelDataHora = BC000L11_A567CotDelDataHora[0];
            n567CotDelDataHora = BC000L11_n567CotDelDataHora[0];
            A568CotDelData = BC000L11_A568CotDelData[0];
            n568CotDelData = BC000L11_n568CotDelData[0];
            A569CotDelHora = BC000L11_A569CotDelHora[0];
            n569CotDelHora = BC000L11_n569CotDelHora[0];
            A570CotDelUsuId = BC000L11_A570CotDelUsuId[0];
            n570CotDelUsuId = BC000L11_n570CotDelUsuId[0];
            A571CotDelUsuNome = BC000L11_A571CotDelUsuNome[0];
            n571CotDelUsuNome = BC000L11_n571CotDelUsuNome[0];
            A150CotSigla = BC000L11_A150CotSigla[0];
            A151CotNome = BC000L11_A151CotNome[0];
            A216CotAtivo = BC000L11_A216CotAtivo[0];
            A566CotDel = BC000L11_A566CotDel[0];
         }
         Gx_mode = sMode21;
      }

      protected void ScanKeyEnd0L21( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0L21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L21( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A567CotDelDataHora = DateTimeUtil.NowMS( context);
            n567CotDelDataHora = false;
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A570CotDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n570CotDelUsuId = false;
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A571CotDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n571CotDelUsuNome = false;
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A568CotDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A567CotDelDataHora) ) ;
            n568CotDelData = false;
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A569CotDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A567CotDelDataHora));
            n569CotDelHora = false;
         }
      }

      protected void BeforeDelete0L21( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
      }

      protected void BeforeComplete0L21( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0L21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L21( )
      {
      }

      protected void send_integrity_lvl_hashes0L21( )
      {
      }

      protected void AddRow0L21( )
      {
         VarsToRow21( bccore_ContatoTipo) ;
      }

      protected void ReadRow0L21( )
      {
         RowToVars21( bccore_ContatoTipo, 1) ;
      }

      protected void InitializeNonKey0L21( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A567CotDelDataHora = (DateTime)(DateTime.MinValue);
         n567CotDelDataHora = false;
         A568CotDelData = (DateTime)(DateTime.MinValue);
         n568CotDelData = false;
         A569CotDelHora = (DateTime)(DateTime.MinValue);
         n569CotDelHora = false;
         A570CotDelUsuId = "";
         n570CotDelUsuId = false;
         A571CotDelUsuNome = "";
         n571CotDelUsuNome = false;
         A150CotSigla = "";
         A151CotNome = "";
         A566CotDel = false;
         A216CotAtivo = true;
         O566CotDel = A566CotDel;
         Z567CotDelDataHora = (DateTime)(DateTime.MinValue);
         Z568CotDelData = (DateTime)(DateTime.MinValue);
         Z569CotDelHora = (DateTime)(DateTime.MinValue);
         Z570CotDelUsuId = "";
         Z571CotDelUsuNome = "";
         Z150CotSigla = "";
         Z151CotNome = "";
         Z216CotAtivo = false;
         Z566CotDel = false;
      }

      protected void InitAll0L21( )
      {
         A149CotID = 0;
         InitializeNonKey0L21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A216CotAtivo = i216CotAtivo;
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

      public void VarsToRow21( GeneXus.Programs.core.SdtContatoTipo obj21 )
      {
         obj21.gxTpr_Mode = Gx_mode;
         obj21.gxTpr_Cotdeldatahora = A567CotDelDataHora;
         obj21.gxTpr_Cotdeldata = A568CotDelData;
         obj21.gxTpr_Cotdelhora = A569CotDelHora;
         obj21.gxTpr_Cotdelusuid = A570CotDelUsuId;
         obj21.gxTpr_Cotdelusunome = A571CotDelUsuNome;
         obj21.gxTpr_Cotsigla = A150CotSigla;
         obj21.gxTpr_Cotnome = A151CotNome;
         obj21.gxTpr_Cotdel = A566CotDel;
         obj21.gxTpr_Cotativo = A216CotAtivo;
         obj21.gxTpr_Cotid = A149CotID;
         obj21.gxTpr_Cotid_Z = Z149CotID;
         obj21.gxTpr_Cotsigla_Z = Z150CotSigla;
         obj21.gxTpr_Cotnome_Z = Z151CotNome;
         obj21.gxTpr_Cotativo_Z = Z216CotAtivo;
         obj21.gxTpr_Cotdel_Z = Z566CotDel;
         obj21.gxTpr_Cotdeldatahora_Z = Z567CotDelDataHora;
         obj21.gxTpr_Cotdeldata_Z = Z568CotDelData;
         obj21.gxTpr_Cotdelhora_Z = Z569CotDelHora;
         obj21.gxTpr_Cotdelusuid_Z = Z570CotDelUsuId;
         obj21.gxTpr_Cotdelusunome_Z = Z571CotDelUsuNome;
         obj21.gxTpr_Cotdeldatahora_N = (short)(Convert.ToInt16(n567CotDelDataHora));
         obj21.gxTpr_Cotdeldata_N = (short)(Convert.ToInt16(n568CotDelData));
         obj21.gxTpr_Cotdelhora_N = (short)(Convert.ToInt16(n569CotDelHora));
         obj21.gxTpr_Cotdelusuid_N = (short)(Convert.ToInt16(n570CotDelUsuId));
         obj21.gxTpr_Cotdelusunome_N = (short)(Convert.ToInt16(n571CotDelUsuNome));
         obj21.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow21( GeneXus.Programs.core.SdtContatoTipo obj21 )
      {
         obj21.gxTpr_Cotid = A149CotID;
         return  ;
      }

      public void RowToVars21( GeneXus.Programs.core.SdtContatoTipo obj21 ,
                               int forceLoad )
      {
         Gx_mode = obj21.gxTpr_Mode;
         A567CotDelDataHora = obj21.gxTpr_Cotdeldatahora;
         n567CotDelDataHora = false;
         A568CotDelData = obj21.gxTpr_Cotdeldata;
         n568CotDelData = false;
         A569CotDelHora = obj21.gxTpr_Cotdelhora;
         n569CotDelHora = false;
         A570CotDelUsuId = obj21.gxTpr_Cotdelusuid;
         n570CotDelUsuId = false;
         A571CotDelUsuNome = obj21.gxTpr_Cotdelusunome;
         n571CotDelUsuNome = false;
         A150CotSigla = obj21.gxTpr_Cotsigla;
         A151CotNome = obj21.gxTpr_Cotnome;
         A566CotDel = obj21.gxTpr_Cotdel;
         A216CotAtivo = obj21.gxTpr_Cotativo;
         A149CotID = obj21.gxTpr_Cotid;
         Z149CotID = obj21.gxTpr_Cotid_Z;
         Z150CotSigla = obj21.gxTpr_Cotsigla_Z;
         Z151CotNome = obj21.gxTpr_Cotnome_Z;
         Z216CotAtivo = obj21.gxTpr_Cotativo_Z;
         Z566CotDel = obj21.gxTpr_Cotdel_Z;
         O566CotDel = obj21.gxTpr_Cotdel_Z;
         Z567CotDelDataHora = obj21.gxTpr_Cotdeldatahora_Z;
         Z568CotDelData = obj21.gxTpr_Cotdeldata_Z;
         Z569CotDelHora = obj21.gxTpr_Cotdelhora_Z;
         Z570CotDelUsuId = obj21.gxTpr_Cotdelusuid_Z;
         Z571CotDelUsuNome = obj21.gxTpr_Cotdelusunome_Z;
         n567CotDelDataHora = (bool)(Convert.ToBoolean(obj21.gxTpr_Cotdeldatahora_N));
         n568CotDelData = (bool)(Convert.ToBoolean(obj21.gxTpr_Cotdeldata_N));
         n569CotDelHora = (bool)(Convert.ToBoolean(obj21.gxTpr_Cotdelhora_N));
         n570CotDelUsuId = (bool)(Convert.ToBoolean(obj21.gxTpr_Cotdelusuid_N));
         n571CotDelUsuNome = (bool)(Convert.ToBoolean(obj21.gxTpr_Cotdelusunome_N));
         Gx_mode = obj21.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A149CotID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0L21( ) ;
         ScanKeyStart0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z149CotID = A149CotID;
            O566CotDel = A566CotDel;
         }
         ZM0L21( -13) ;
         OnLoadActions0L21( ) ;
         AddRow0L21( ) ;
         ScanKeyEnd0L21( ) ;
         if ( RcdFound21 == 0 )
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
         RowToVars21( bccore_ContatoTipo, 0) ;
         ScanKeyStart0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z149CotID = A149CotID;
            O566CotDel = A566CotDel;
         }
         ZM0L21( -13) ;
         OnLoadActions0L21( ) ;
         AddRow0L21( ) ;
         ScanKeyEnd0L21( ) ;
         if ( RcdFound21 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0L21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0L21( ) ;
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A149CotID != Z149CotID )
               {
                  A149CotID = Z149CotID;
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
                  Update0L21( ) ;
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
                  if ( A149CotID != Z149CotID )
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
                        Insert0L21( ) ;
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
                        Insert0L21( ) ;
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
         RowToVars21( bccore_ContatoTipo, 1) ;
         SaveImpl( ) ;
         VarsToRow21( bccore_ContatoTipo) ;
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
         RowToVars21( bccore_ContatoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L21( ) ;
         AfterTrn( ) ;
         VarsToRow21( bccore_ContatoTipo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow21( bccore_ContatoTipo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtContatoTipo auxBC = new GeneXus.Programs.core.SdtContatoTipo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A149CotID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_ContatoTipo);
               auxBC.Save();
               bccore_ContatoTipo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars21( bccore_ContatoTipo, 1) ;
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
         RowToVars21( bccore_ContatoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0L21( ) ;
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
               VarsToRow21( bccore_ContatoTipo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow21( bccore_ContatoTipo) ;
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
         RowToVars21( bccore_ContatoTipo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0L21( ) ;
         if ( RcdFound21 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A149CotID != Z149CotID )
            {
               A149CotID = Z149CotID;
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
            if ( A149CotID != Z149CotID )
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
         context.RollbackDataStores("core.contatotipo_bc",pr_default);
         VarsToRow21( bccore_ContatoTipo) ;
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
         Gx_mode = bccore_ContatoTipo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_ContatoTipo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_ContatoTipo )
         {
            bccore_ContatoTipo = (GeneXus.Programs.core.SdtContatoTipo)(sdt);
            if ( StringUtil.StrCmp(bccore_ContatoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ContatoTipo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow21( bccore_ContatoTipo) ;
            }
            else
            {
               RowToVars21( bccore_ContatoTipo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_ContatoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ContatoTipo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars21( bccore_ContatoTipo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtContatoTipo ContatoTipo_BC
      {
         get {
            return bccore_ContatoTipo ;
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
            return "contatotipo_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV15Pgmname = "";
         Z567CotDelDataHora = (DateTime)(DateTime.MinValue);
         A567CotDelDataHora = (DateTime)(DateTime.MinValue);
         Z568CotDelData = (DateTime)(DateTime.MinValue);
         A568CotDelData = (DateTime)(DateTime.MinValue);
         Z569CotDelHora = (DateTime)(DateTime.MinValue);
         A569CotDelHora = (DateTime)(DateTime.MinValue);
         Z570CotDelUsuId = "";
         A570CotDelUsuId = "";
         Z571CotDelUsuNome = "";
         A571CotDelUsuNome = "";
         Z150CotSigla = "";
         A150CotSigla = "";
         Z151CotNome = "";
         A151CotNome = "";
         BC000L4_A149CotID = new int[1] ;
         BC000L4_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000L4_n567CotDelDataHora = new bool[] {false} ;
         BC000L4_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         BC000L4_n568CotDelData = new bool[] {false} ;
         BC000L4_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000L4_n569CotDelHora = new bool[] {false} ;
         BC000L4_A570CotDelUsuId = new string[] {""} ;
         BC000L4_n570CotDelUsuId = new bool[] {false} ;
         BC000L4_A571CotDelUsuNome = new string[] {""} ;
         BC000L4_n571CotDelUsuNome = new bool[] {false} ;
         BC000L4_A150CotSigla = new string[] {""} ;
         BC000L4_A151CotNome = new string[] {""} ;
         BC000L4_A216CotAtivo = new bool[] {false} ;
         BC000L4_A566CotDel = new bool[] {false} ;
         BC000L5_A150CotSigla = new string[] {""} ;
         BC000L6_A149CotID = new int[1] ;
         BC000L3_A149CotID = new int[1] ;
         BC000L3_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000L3_n567CotDelDataHora = new bool[] {false} ;
         BC000L3_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         BC000L3_n568CotDelData = new bool[] {false} ;
         BC000L3_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000L3_n569CotDelHora = new bool[] {false} ;
         BC000L3_A570CotDelUsuId = new string[] {""} ;
         BC000L3_n570CotDelUsuId = new bool[] {false} ;
         BC000L3_A571CotDelUsuNome = new string[] {""} ;
         BC000L3_n571CotDelUsuNome = new bool[] {false} ;
         BC000L3_A150CotSigla = new string[] {""} ;
         BC000L3_A151CotNome = new string[] {""} ;
         BC000L3_A216CotAtivo = new bool[] {false} ;
         BC000L3_A566CotDel = new bool[] {false} ;
         sMode21 = "";
         BC000L2_A149CotID = new int[1] ;
         BC000L2_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000L2_n567CotDelDataHora = new bool[] {false} ;
         BC000L2_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         BC000L2_n568CotDelData = new bool[] {false} ;
         BC000L2_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000L2_n569CotDelHora = new bool[] {false} ;
         BC000L2_A570CotDelUsuId = new string[] {""} ;
         BC000L2_n570CotDelUsuId = new bool[] {false} ;
         BC000L2_A571CotDelUsuNome = new string[] {""} ;
         BC000L2_n571CotDelUsuNome = new bool[] {false} ;
         BC000L2_A150CotSigla = new string[] {""} ;
         BC000L2_A151CotNome = new string[] {""} ;
         BC000L2_A216CotAtivo = new bool[] {false} ;
         BC000L2_A566CotDel = new bool[] {false} ;
         BC000L8_A149CotID = new int[1] ;
         BC000L11_A149CotID = new int[1] ;
         BC000L11_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000L11_n567CotDelDataHora = new bool[] {false} ;
         BC000L11_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         BC000L11_n568CotDelData = new bool[] {false} ;
         BC000L11_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000L11_n569CotDelHora = new bool[] {false} ;
         BC000L11_A570CotDelUsuId = new string[] {""} ;
         BC000L11_n570CotDelUsuId = new bool[] {false} ;
         BC000L11_A571CotDelUsuNome = new string[] {""} ;
         BC000L11_n571CotDelUsuNome = new bool[] {false} ;
         BC000L11_A150CotSigla = new string[] {""} ;
         BC000L11_A151CotNome = new string[] {""} ;
         BC000L11_A216CotAtivo = new bool[] {false} ;
         BC000L11_A566CotDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000L2_A149CotID, BC000L2_A567CotDelDataHora, BC000L2_n567CotDelDataHora, BC000L2_A568CotDelData, BC000L2_n568CotDelData, BC000L2_A569CotDelHora, BC000L2_n569CotDelHora, BC000L2_A570CotDelUsuId, BC000L2_n570CotDelUsuId, BC000L2_A571CotDelUsuNome,
               BC000L2_n571CotDelUsuNome, BC000L2_A150CotSigla, BC000L2_A151CotNome, BC000L2_A216CotAtivo, BC000L2_A566CotDel
               }
               , new Object[] {
               BC000L3_A149CotID, BC000L3_A567CotDelDataHora, BC000L3_n567CotDelDataHora, BC000L3_A568CotDelData, BC000L3_n568CotDelData, BC000L3_A569CotDelHora, BC000L3_n569CotDelHora, BC000L3_A570CotDelUsuId, BC000L3_n570CotDelUsuId, BC000L3_A571CotDelUsuNome,
               BC000L3_n571CotDelUsuNome, BC000L3_A150CotSigla, BC000L3_A151CotNome, BC000L3_A216CotAtivo, BC000L3_A566CotDel
               }
               , new Object[] {
               BC000L4_A149CotID, BC000L4_A567CotDelDataHora, BC000L4_n567CotDelDataHora, BC000L4_A568CotDelData, BC000L4_n568CotDelData, BC000L4_A569CotDelHora, BC000L4_n569CotDelHora, BC000L4_A570CotDelUsuId, BC000L4_n570CotDelUsuId, BC000L4_A571CotDelUsuNome,
               BC000L4_n571CotDelUsuNome, BC000L4_A150CotSigla, BC000L4_A151CotNome, BC000L4_A216CotAtivo, BC000L4_A566CotDel
               }
               , new Object[] {
               BC000L5_A150CotSigla
               }
               , new Object[] {
               BC000L6_A149CotID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L8_A149CotID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000L11_A149CotID, BC000L11_A567CotDelDataHora, BC000L11_n567CotDelDataHora, BC000L11_A568CotDelData, BC000L11_n568CotDelData, BC000L11_A569CotDelHora, BC000L11_n569CotDelHora, BC000L11_A570CotDelUsuId, BC000L11_n570CotDelUsuId, BC000L11_A571CotDelUsuNome,
               BC000L11_n571CotDelUsuNome, BC000L11_A150CotSigla, BC000L11_A151CotNome, BC000L11_A216CotAtivo, BC000L11_A566CotDel
               }
            }
         );
         Z216CotAtivo = true;
         A216CotAtivo = true;
         i216CotAtivo = true;
         AV15Pgmname = "core.ContatoTipo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120L2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private short nIsDirty_21 ;
      private int trnEnded ;
      private int Z149CotID ;
      private int A149CotID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV15Pgmname ;
      private string Z570CotDelUsuId ;
      private string A570CotDelUsuId ;
      private string sMode21 ;
      private DateTime Z567CotDelDataHora ;
      private DateTime A567CotDelDataHora ;
      private DateTime Z568CotDelData ;
      private DateTime A568CotDelData ;
      private DateTime Z569CotDelHora ;
      private DateTime A569CotDelHora ;
      private bool returnInSub ;
      private bool Z216CotAtivo ;
      private bool A216CotAtivo ;
      private bool Z566CotDel ;
      private bool A566CotDel ;
      private bool n567CotDelDataHora ;
      private bool n568CotDelData ;
      private bool n569CotDelHora ;
      private bool n570CotDelUsuId ;
      private bool n571CotDelUsuNome ;
      private bool O566CotDel ;
      private bool Gx_longc ;
      private bool i216CotAtivo ;
      private bool mustCommit ;
      private string Z571CotDelUsuNome ;
      private string A571CotDelUsuNome ;
      private string Z150CotSigla ;
      private string A150CotSigla ;
      private string Z151CotNome ;
      private string A151CotNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtContatoTipo bccore_ContatoTipo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000L4_A149CotID ;
      private DateTime[] BC000L4_A567CotDelDataHora ;
      private bool[] BC000L4_n567CotDelDataHora ;
      private DateTime[] BC000L4_A568CotDelData ;
      private bool[] BC000L4_n568CotDelData ;
      private DateTime[] BC000L4_A569CotDelHora ;
      private bool[] BC000L4_n569CotDelHora ;
      private string[] BC000L4_A570CotDelUsuId ;
      private bool[] BC000L4_n570CotDelUsuId ;
      private string[] BC000L4_A571CotDelUsuNome ;
      private bool[] BC000L4_n571CotDelUsuNome ;
      private string[] BC000L4_A150CotSigla ;
      private string[] BC000L4_A151CotNome ;
      private bool[] BC000L4_A216CotAtivo ;
      private bool[] BC000L4_A566CotDel ;
      private string[] BC000L5_A150CotSigla ;
      private int[] BC000L6_A149CotID ;
      private int[] BC000L3_A149CotID ;
      private DateTime[] BC000L3_A567CotDelDataHora ;
      private bool[] BC000L3_n567CotDelDataHora ;
      private DateTime[] BC000L3_A568CotDelData ;
      private bool[] BC000L3_n568CotDelData ;
      private DateTime[] BC000L3_A569CotDelHora ;
      private bool[] BC000L3_n569CotDelHora ;
      private string[] BC000L3_A570CotDelUsuId ;
      private bool[] BC000L3_n570CotDelUsuId ;
      private string[] BC000L3_A571CotDelUsuNome ;
      private bool[] BC000L3_n571CotDelUsuNome ;
      private string[] BC000L3_A150CotSigla ;
      private string[] BC000L3_A151CotNome ;
      private bool[] BC000L3_A216CotAtivo ;
      private bool[] BC000L3_A566CotDel ;
      private int[] BC000L2_A149CotID ;
      private DateTime[] BC000L2_A567CotDelDataHora ;
      private bool[] BC000L2_n567CotDelDataHora ;
      private DateTime[] BC000L2_A568CotDelData ;
      private bool[] BC000L2_n568CotDelData ;
      private DateTime[] BC000L2_A569CotDelHora ;
      private bool[] BC000L2_n569CotDelHora ;
      private string[] BC000L2_A570CotDelUsuId ;
      private bool[] BC000L2_n570CotDelUsuId ;
      private string[] BC000L2_A571CotDelUsuNome ;
      private bool[] BC000L2_n571CotDelUsuNome ;
      private string[] BC000L2_A150CotSigla ;
      private string[] BC000L2_A151CotNome ;
      private bool[] BC000L2_A216CotAtivo ;
      private bool[] BC000L2_A566CotDel ;
      private int[] BC000L8_A149CotID ;
      private int[] BC000L11_A149CotID ;
      private DateTime[] BC000L11_A567CotDelDataHora ;
      private bool[] BC000L11_n567CotDelDataHora ;
      private DateTime[] BC000L11_A568CotDelData ;
      private bool[] BC000L11_n568CotDelData ;
      private DateTime[] BC000L11_A569CotDelHora ;
      private bool[] BC000L11_n569CotDelHora ;
      private string[] BC000L11_A570CotDelUsuId ;
      private bool[] BC000L11_n570CotDelUsuId ;
      private string[] BC000L11_A571CotDelUsuNome ;
      private bool[] BC000L11_n571CotDelUsuNome ;
      private string[] BC000L11_A150CotSigla ;
      private string[] BC000L11_A151CotNome ;
      private bool[] BC000L11_A216CotAtivo ;
      private bool[] BC000L11_A566CotDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class contatotipo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class contatotipo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000L4;
        prmBC000L4 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L5;
        prmBC000L5 = new Object[] {
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L6;
        prmBC000L6 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L3;
        prmBC000L3 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L2;
        prmBC000L2 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L7;
        prmBC000L7 = new Object[] {
        new ParDef("CotDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CotDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CotDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CotDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CotDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotNome",GXType.VarChar,80,0) ,
        new ParDef("CotAtivo",GXType.Boolean,4,0) ,
        new ParDef("CotDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000L8;
        prmBC000L8 = new Object[] {
        };
        Object[] prmBC000L9;
        prmBC000L9 = new Object[] {
        new ParDef("CotDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CotDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CotDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CotDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CotDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotNome",GXType.VarChar,80,0) ,
        new ParDef("CotAtivo",GXType.Boolean,4,0) ,
        new ParDef("CotDel",GXType.Boolean,4,0) ,
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L10;
        prmBC000L10 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmBC000L11;
        prmBC000L11 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000L2", "SELECT CotID, CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel FROM tb_contatotipo WHERE CotID = :CotID  FOR UPDATE OF tb_contatotipo",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L3", "SELECT CotID, CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel FROM tb_contatotipo WHERE CotID = :CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L4", "SELECT TM1.CotID, TM1.CotDelDataHora, TM1.CotDelData, TM1.CotDelHora, TM1.CotDelUsuId, TM1.CotDelUsuNome, TM1.CotSigla, TM1.CotNome, TM1.CotAtivo, TM1.CotDel FROM tb_contatotipo TM1 WHERE TM1.CotID = :CotID ORDER BY TM1.CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L5", "SELECT CotSigla FROM tb_contatotipo WHERE (CotSigla = :CotSigla) AND (Not ( CotID = :CotID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L6", "SELECT CotID FROM tb_contatotipo WHERE CotID = :CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L7", "SAVEPOINT gxupdate;INSERT INTO tb_contatotipo(CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel) VALUES(:CotDelDataHora, :CotDelData, :CotDelHora, :CotDelUsuId, :CotDelUsuNome, :CotSigla, :CotNome, :CotAtivo, :CotDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000L7)
           ,new CursorDef("BC000L8", "SELECT currval('CotID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000L9", "SAVEPOINT gxupdate;UPDATE tb_contatotipo SET CotDelDataHora=:CotDelDataHora, CotDelData=:CotDelData, CotDelHora=:CotDelHora, CotDelUsuId=:CotDelUsuId, CotDelUsuNome=:CotDelUsuNome, CotSigla=:CotSigla, CotNome=:CotNome, CotAtivo=:CotAtivo, CotDel=:CotDel  WHERE CotID = :CotID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L9)
           ,new CursorDef("BC000L10", "SAVEPOINT gxupdate;DELETE FROM tb_contatotipo  WHERE CotID = :CotID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000L10)
           ,new CursorDef("BC000L11", "SELECT TM1.CotID, TM1.CotDelDataHora, TM1.CotDelData, TM1.CotDelHora, TM1.CotDelUsuId, TM1.CotDelUsuNome, TM1.CotSigla, TM1.CotNome, TM1.CotAtivo, TM1.CotDel FROM tb_contatotipo TM1 WHERE TM1.CotID = :CotID ORDER BY TM1.CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000L11,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
     }
  }

}

}
