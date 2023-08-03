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
   public class genero_bc : GxSilentTrn, IGxSilentTrn
   {
      public genero_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public genero_bc( IGxContext context )
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
         ReadRow0M22( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0M22( ) ;
         standaloneModal( ) ;
         AddRow0M22( ) ;
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
            E110M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z152GenID = A152GenID;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M22( ) ;
            }
            else
            {
               CheckExtendedTable0M22( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0M22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
      }

      protected void ZM0M22( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z537GenDelDataHora = A537GenDelDataHora;
            Z538GenDelData = A538GenDelData;
            Z539GenDelHora = A539GenDelHora;
            Z540GenDelUsuId = A540GenDelUsuId;
            Z541GenDelUsuNome = A541GenDelUsuNome;
            Z153GenSigla = A153GenSigla;
            Z154GenNome = A154GenNome;
            Z215GenAtivo = A215GenAtivo;
            Z536GenDel = A536GenDel;
         }
         if ( GX_JID == -13 )
         {
            Z152GenID = A152GenID;
            Z537GenDelDataHora = A537GenDelDataHora;
            Z538GenDelData = A538GenDelData;
            Z539GenDelHora = A539GenDelHora;
            Z540GenDelUsuId = A540GenDelUsuId;
            Z541GenDelUsuNome = A541GenDelUsuNome;
            Z153GenSigla = A153GenSigla;
            Z154GenNome = A154GenNome;
            Z215GenAtivo = A215GenAtivo;
            Z536GenDel = A536GenDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV15Pgmname = "core.Genero_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A215GenAtivo) && ( Gx_BScreen == 0 ) )
         {
            A215GenAtivo = true;
         }
      }

      protected void Load0M22( )
      {
         /* Using cursor BC000M4 */
         pr_default.execute(2, new Object[] {A152GenID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A537GenDelDataHora = BC000M4_A537GenDelDataHora[0];
            n537GenDelDataHora = BC000M4_n537GenDelDataHora[0];
            A538GenDelData = BC000M4_A538GenDelData[0];
            n538GenDelData = BC000M4_n538GenDelData[0];
            A539GenDelHora = BC000M4_A539GenDelHora[0];
            n539GenDelHora = BC000M4_n539GenDelHora[0];
            A540GenDelUsuId = BC000M4_A540GenDelUsuId[0];
            n540GenDelUsuId = BC000M4_n540GenDelUsuId[0];
            A541GenDelUsuNome = BC000M4_A541GenDelUsuNome[0];
            n541GenDelUsuNome = BC000M4_n541GenDelUsuNome[0];
            A153GenSigla = BC000M4_A153GenSigla[0];
            A154GenNome = BC000M4_A154GenNome[0];
            A215GenAtivo = BC000M4_A215GenAtivo[0];
            A536GenDel = BC000M4_A536GenDel[0];
            ZM0M22( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0M22( ) ;
      }

      protected void OnLoadActions0M22( )
      {
      }

      protected void CheckExtendedTable0M22( )
      {
         nIsDirty_22 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000M5 */
         pr_default.execute(3, new Object[] {A153GenSigla, A152GenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A153GenSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A154GenNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0M22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M22( )
      {
         /* Using cursor BC000M6 */
         pr_default.execute(4, new Object[] {A152GenID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000M3 */
         pr_default.execute(1, new Object[] {A152GenID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M22( 13) ;
            RcdFound22 = 1;
            A152GenID = BC000M3_A152GenID[0];
            A537GenDelDataHora = BC000M3_A537GenDelDataHora[0];
            n537GenDelDataHora = BC000M3_n537GenDelDataHora[0];
            A538GenDelData = BC000M3_A538GenDelData[0];
            n538GenDelData = BC000M3_n538GenDelData[0];
            A539GenDelHora = BC000M3_A539GenDelHora[0];
            n539GenDelHora = BC000M3_n539GenDelHora[0];
            A540GenDelUsuId = BC000M3_A540GenDelUsuId[0];
            n540GenDelUsuId = BC000M3_n540GenDelUsuId[0];
            A541GenDelUsuNome = BC000M3_A541GenDelUsuNome[0];
            n541GenDelUsuNome = BC000M3_n541GenDelUsuNome[0];
            A153GenSigla = BC000M3_A153GenSigla[0];
            A154GenNome = BC000M3_A154GenNome[0];
            A215GenAtivo = BC000M3_A215GenAtivo[0];
            A536GenDel = BC000M3_A536GenDel[0];
            O536GenDel = A536GenDel;
            Z152GenID = A152GenID;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0M22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0M22( ) ;
            }
            Gx_mode = sMode22;
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0M22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode22;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M22( ) ;
         if ( RcdFound22 == 0 )
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
         CONFIRM_0M0( ) ;
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

      protected void CheckOptimisticConcurrency0M22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000M2 */
            pr_default.execute(0, new Object[] {A152GenID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_genero"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z537GenDelDataHora != BC000M2_A537GenDelDataHora[0] ) || ( Z538GenDelData != BC000M2_A538GenDelData[0] ) || ( Z539GenDelHora != BC000M2_A539GenDelHora[0] ) || ( StringUtil.StrCmp(Z540GenDelUsuId, BC000M2_A540GenDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z541GenDelUsuNome, BC000M2_A541GenDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z153GenSigla, BC000M2_A153GenSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z154GenNome, BC000M2_A154GenNome[0]) != 0 ) || ( Z215GenAtivo != BC000M2_A215GenAtivo[0] ) || ( Z536GenDel != BC000M2_A536GenDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_genero"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M22( 0) ;
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M7 */
                     pr_default.execute(5, new Object[] {n537GenDelDataHora, A537GenDelDataHora, n538GenDelData, A538GenDelData, n539GenDelHora, A539GenDelHora, n540GenDelUsuId, A540GenDelUsuId, n541GenDelUsuNome, A541GenDelUsuNome, A153GenSigla, A154GenNome, A215GenAtivo, A536GenDel});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000M8 */
                     pr_default.execute(6);
                     A152GenID = BC000M8_A152GenID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_genero");
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
               Load0M22( ) ;
            }
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void Update0M22( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000M9 */
                     pr_default.execute(7, new Object[] {n537GenDelDataHora, A537GenDelDataHora, n538GenDelData, A538GenDelData, n539GenDelHora, A539GenDelHora, n540GenDelUsuId, A540GenDelUsuId, n541GenDelUsuNome, A541GenDelUsuNome, A153GenSigla, A154GenNome, A215GenAtivo, A536GenDel, A152GenID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_genero");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_genero"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_generoupdateredundancy(context ).execute( ref  A152GenID) ;
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
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void DeferredUpdate0M22( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M22( ) ;
            AfterConfirm0M22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000M10 */
                  pr_default.execute(8, new Object[] {A152GenID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_genero");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0M22( ) ;
         Gx_mode = sMode22;
      }

      protected void OnDeleteControls0M22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000M11 */
            pr_default.execute(9, new Object[] {A152GenID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0M22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M22( ) ;
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

      public void ScanKeyStart0M22( )
      {
         /* Scan By routine */
         /* Using cursor BC000M12 */
         pr_default.execute(10, new Object[] {A152GenID});
         RcdFound22 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound22 = 1;
            A152GenID = BC000M12_A152GenID[0];
            A537GenDelDataHora = BC000M12_A537GenDelDataHora[0];
            n537GenDelDataHora = BC000M12_n537GenDelDataHora[0];
            A538GenDelData = BC000M12_A538GenDelData[0];
            n538GenDelData = BC000M12_n538GenDelData[0];
            A539GenDelHora = BC000M12_A539GenDelHora[0];
            n539GenDelHora = BC000M12_n539GenDelHora[0];
            A540GenDelUsuId = BC000M12_A540GenDelUsuId[0];
            n540GenDelUsuId = BC000M12_n540GenDelUsuId[0];
            A541GenDelUsuNome = BC000M12_A541GenDelUsuNome[0];
            n541GenDelUsuNome = BC000M12_n541GenDelUsuNome[0];
            A153GenSigla = BC000M12_A153GenSigla[0];
            A154GenNome = BC000M12_A154GenNome[0];
            A215GenAtivo = BC000M12_A215GenAtivo[0];
            A536GenDel = BC000M12_A536GenDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0M22( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound22 = 0;
         ScanKeyLoad0M22( ) ;
      }

      protected void ScanKeyLoad0M22( )
      {
         sMode22 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound22 = 1;
            A152GenID = BC000M12_A152GenID[0];
            A537GenDelDataHora = BC000M12_A537GenDelDataHora[0];
            n537GenDelDataHora = BC000M12_n537GenDelDataHora[0];
            A538GenDelData = BC000M12_A538GenDelData[0];
            n538GenDelData = BC000M12_n538GenDelData[0];
            A539GenDelHora = BC000M12_A539GenDelHora[0];
            n539GenDelHora = BC000M12_n539GenDelHora[0];
            A540GenDelUsuId = BC000M12_A540GenDelUsuId[0];
            n540GenDelUsuId = BC000M12_n540GenDelUsuId[0];
            A541GenDelUsuNome = BC000M12_A541GenDelUsuNome[0];
            n541GenDelUsuNome = BC000M12_n541GenDelUsuNome[0];
            A153GenSigla = BC000M12_A153GenSigla[0];
            A154GenNome = BC000M12_A154GenNome[0];
            A215GenAtivo = BC000M12_A215GenAtivo[0];
            A536GenDel = BC000M12_A536GenDel[0];
         }
         Gx_mode = sMode22;
      }

      protected void ScanKeyEnd0M22( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0M22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M22( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A537GenDelDataHora = DateTimeUtil.NowMS( context);
            n537GenDelDataHora = false;
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A540GenDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n540GenDelUsuId = false;
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A541GenDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n541GenDelUsuNome = false;
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A538GenDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A537GenDelDataHora) ) ;
            n538GenDelData = false;
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A539GenDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A537GenDelDataHora));
            n539GenDelHora = false;
         }
      }

      protected void BeforeDelete0M22( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
      }

      protected void BeforeComplete0M22( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0M22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M22( )
      {
      }

      protected void send_integrity_lvl_hashes0M22( )
      {
      }

      protected void AddRow0M22( )
      {
         VarsToRow22( bccore_Genero) ;
      }

      protected void ReadRow0M22( )
      {
         RowToVars22( bccore_Genero, 1) ;
      }

      protected void InitializeNonKey0M22( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A537GenDelDataHora = (DateTime)(DateTime.MinValue);
         n537GenDelDataHora = false;
         A538GenDelData = (DateTime)(DateTime.MinValue);
         n538GenDelData = false;
         A539GenDelHora = (DateTime)(DateTime.MinValue);
         n539GenDelHora = false;
         A540GenDelUsuId = "";
         n540GenDelUsuId = false;
         A541GenDelUsuNome = "";
         n541GenDelUsuNome = false;
         A153GenSigla = "";
         A154GenNome = "";
         A536GenDel = false;
         A215GenAtivo = true;
         O536GenDel = A536GenDel;
         Z537GenDelDataHora = (DateTime)(DateTime.MinValue);
         Z538GenDelData = (DateTime)(DateTime.MinValue);
         Z539GenDelHora = (DateTime)(DateTime.MinValue);
         Z540GenDelUsuId = "";
         Z541GenDelUsuNome = "";
         Z153GenSigla = "";
         Z154GenNome = "";
         Z215GenAtivo = false;
         Z536GenDel = false;
      }

      protected void InitAll0M22( )
      {
         A152GenID = 0;
         InitializeNonKey0M22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A215GenAtivo = i215GenAtivo;
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

      public void VarsToRow22( GeneXus.Programs.core.SdtGenero obj22 )
      {
         obj22.gxTpr_Mode = Gx_mode;
         obj22.gxTpr_Gendeldatahora = A537GenDelDataHora;
         obj22.gxTpr_Gendeldata = A538GenDelData;
         obj22.gxTpr_Gendelhora = A539GenDelHora;
         obj22.gxTpr_Gendelusuid = A540GenDelUsuId;
         obj22.gxTpr_Gendelusunome = A541GenDelUsuNome;
         obj22.gxTpr_Gensigla = A153GenSigla;
         obj22.gxTpr_Gennome = A154GenNome;
         obj22.gxTpr_Gendel = A536GenDel;
         obj22.gxTpr_Genativo = A215GenAtivo;
         obj22.gxTpr_Genid = A152GenID;
         obj22.gxTpr_Genid_Z = Z152GenID;
         obj22.gxTpr_Gensigla_Z = Z153GenSigla;
         obj22.gxTpr_Gennome_Z = Z154GenNome;
         obj22.gxTpr_Genativo_Z = Z215GenAtivo;
         obj22.gxTpr_Gendel_Z = Z536GenDel;
         obj22.gxTpr_Gendeldatahora_Z = Z537GenDelDataHora;
         obj22.gxTpr_Gendeldata_Z = Z538GenDelData;
         obj22.gxTpr_Gendelhora_Z = Z539GenDelHora;
         obj22.gxTpr_Gendelusuid_Z = Z540GenDelUsuId;
         obj22.gxTpr_Gendelusunome_Z = Z541GenDelUsuNome;
         obj22.gxTpr_Gendeldatahora_N = (short)(Convert.ToInt16(n537GenDelDataHora));
         obj22.gxTpr_Gendeldata_N = (short)(Convert.ToInt16(n538GenDelData));
         obj22.gxTpr_Gendelhora_N = (short)(Convert.ToInt16(n539GenDelHora));
         obj22.gxTpr_Gendelusuid_N = (short)(Convert.ToInt16(n540GenDelUsuId));
         obj22.gxTpr_Gendelusunome_N = (short)(Convert.ToInt16(n541GenDelUsuNome));
         obj22.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow22( GeneXus.Programs.core.SdtGenero obj22 )
      {
         obj22.gxTpr_Genid = A152GenID;
         return  ;
      }

      public void RowToVars22( GeneXus.Programs.core.SdtGenero obj22 ,
                               int forceLoad )
      {
         Gx_mode = obj22.gxTpr_Mode;
         A537GenDelDataHora = obj22.gxTpr_Gendeldatahora;
         n537GenDelDataHora = false;
         A538GenDelData = obj22.gxTpr_Gendeldata;
         n538GenDelData = false;
         A539GenDelHora = obj22.gxTpr_Gendelhora;
         n539GenDelHora = false;
         A540GenDelUsuId = obj22.gxTpr_Gendelusuid;
         n540GenDelUsuId = false;
         A541GenDelUsuNome = obj22.gxTpr_Gendelusunome;
         n541GenDelUsuNome = false;
         A153GenSigla = obj22.gxTpr_Gensigla;
         A154GenNome = obj22.gxTpr_Gennome;
         A536GenDel = obj22.gxTpr_Gendel;
         A215GenAtivo = obj22.gxTpr_Genativo;
         A152GenID = obj22.gxTpr_Genid;
         Z152GenID = obj22.gxTpr_Genid_Z;
         Z153GenSigla = obj22.gxTpr_Gensigla_Z;
         Z154GenNome = obj22.gxTpr_Gennome_Z;
         Z215GenAtivo = obj22.gxTpr_Genativo_Z;
         Z536GenDel = obj22.gxTpr_Gendel_Z;
         O536GenDel = obj22.gxTpr_Gendel_Z;
         Z537GenDelDataHora = obj22.gxTpr_Gendeldatahora_Z;
         Z538GenDelData = obj22.gxTpr_Gendeldata_Z;
         Z539GenDelHora = obj22.gxTpr_Gendelhora_Z;
         Z540GenDelUsuId = obj22.gxTpr_Gendelusuid_Z;
         Z541GenDelUsuNome = obj22.gxTpr_Gendelusunome_Z;
         n537GenDelDataHora = (bool)(Convert.ToBoolean(obj22.gxTpr_Gendeldatahora_N));
         n538GenDelData = (bool)(Convert.ToBoolean(obj22.gxTpr_Gendeldata_N));
         n539GenDelHora = (bool)(Convert.ToBoolean(obj22.gxTpr_Gendelhora_N));
         n540GenDelUsuId = (bool)(Convert.ToBoolean(obj22.gxTpr_Gendelusuid_N));
         n541GenDelUsuNome = (bool)(Convert.ToBoolean(obj22.gxTpr_Gendelusunome_N));
         Gx_mode = obj22.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A152GenID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0M22( ) ;
         ScanKeyStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z152GenID = A152GenID;
            O536GenDel = A536GenDel;
         }
         ZM0M22( -13) ;
         OnLoadActions0M22( ) ;
         AddRow0M22( ) ;
         ScanKeyEnd0M22( ) ;
         if ( RcdFound22 == 0 )
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
         RowToVars22( bccore_Genero, 0) ;
         ScanKeyStart0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z152GenID = A152GenID;
            O536GenDel = A536GenDel;
         }
         ZM0M22( -13) ;
         OnLoadActions0M22( ) ;
         AddRow0M22( ) ;
         ScanKeyEnd0M22( ) ;
         if ( RcdFound22 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0M22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0M22( ) ;
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A152GenID != Z152GenID )
               {
                  A152GenID = Z152GenID;
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
                  Update0M22( ) ;
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
                  if ( A152GenID != Z152GenID )
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
                        Insert0M22( ) ;
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
                        Insert0M22( ) ;
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
         RowToVars22( bccore_Genero, 1) ;
         SaveImpl( ) ;
         VarsToRow22( bccore_Genero) ;
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
         RowToVars22( bccore_Genero, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M22( ) ;
         AfterTrn( ) ;
         VarsToRow22( bccore_Genero) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow22( bccore_Genero) ;
         }
         else
         {
            GeneXus.Programs.core.SdtGenero auxBC = new GeneXus.Programs.core.SdtGenero(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A152GenID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Genero);
               auxBC.Save();
               bccore_Genero.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars22( bccore_Genero, 1) ;
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
         RowToVars22( bccore_Genero, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0M22( ) ;
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
               VarsToRow22( bccore_Genero) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow22( bccore_Genero) ;
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
         RowToVars22( bccore_Genero, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0M22( ) ;
         if ( RcdFound22 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A152GenID != Z152GenID )
            {
               A152GenID = Z152GenID;
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
            if ( A152GenID != Z152GenID )
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
         context.RollbackDataStores("core.genero_bc",pr_default);
         VarsToRow22( bccore_Genero) ;
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
         Gx_mode = bccore_Genero.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Genero.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Genero )
         {
            bccore_Genero = (GeneXus.Programs.core.SdtGenero)(sdt);
            if ( StringUtil.StrCmp(bccore_Genero.gxTpr_Mode, "") == 0 )
            {
               bccore_Genero.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow22( bccore_Genero) ;
            }
            else
            {
               RowToVars22( bccore_Genero, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Genero.gxTpr_Mode, "") == 0 )
            {
               bccore_Genero.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars22( bccore_Genero, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtGenero Genero_BC
      {
         get {
            return bccore_Genero ;
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
            return "genero_Execute" ;
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
         Z537GenDelDataHora = (DateTime)(DateTime.MinValue);
         A537GenDelDataHora = (DateTime)(DateTime.MinValue);
         Z538GenDelData = (DateTime)(DateTime.MinValue);
         A538GenDelData = (DateTime)(DateTime.MinValue);
         Z539GenDelHora = (DateTime)(DateTime.MinValue);
         A539GenDelHora = (DateTime)(DateTime.MinValue);
         Z540GenDelUsuId = "";
         A540GenDelUsuId = "";
         Z541GenDelUsuNome = "";
         A541GenDelUsuNome = "";
         Z153GenSigla = "";
         A153GenSigla = "";
         Z154GenNome = "";
         A154GenNome = "";
         BC000M4_A152GenID = new int[1] ;
         BC000M4_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000M4_n537GenDelDataHora = new bool[] {false} ;
         BC000M4_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         BC000M4_n538GenDelData = new bool[] {false} ;
         BC000M4_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000M4_n539GenDelHora = new bool[] {false} ;
         BC000M4_A540GenDelUsuId = new string[] {""} ;
         BC000M4_n540GenDelUsuId = new bool[] {false} ;
         BC000M4_A541GenDelUsuNome = new string[] {""} ;
         BC000M4_n541GenDelUsuNome = new bool[] {false} ;
         BC000M4_A153GenSigla = new string[] {""} ;
         BC000M4_A154GenNome = new string[] {""} ;
         BC000M4_A215GenAtivo = new bool[] {false} ;
         BC000M4_A536GenDel = new bool[] {false} ;
         BC000M5_A153GenSigla = new string[] {""} ;
         BC000M6_A152GenID = new int[1] ;
         BC000M3_A152GenID = new int[1] ;
         BC000M3_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000M3_n537GenDelDataHora = new bool[] {false} ;
         BC000M3_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         BC000M3_n538GenDelData = new bool[] {false} ;
         BC000M3_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000M3_n539GenDelHora = new bool[] {false} ;
         BC000M3_A540GenDelUsuId = new string[] {""} ;
         BC000M3_n540GenDelUsuId = new bool[] {false} ;
         BC000M3_A541GenDelUsuNome = new string[] {""} ;
         BC000M3_n541GenDelUsuNome = new bool[] {false} ;
         BC000M3_A153GenSigla = new string[] {""} ;
         BC000M3_A154GenNome = new string[] {""} ;
         BC000M3_A215GenAtivo = new bool[] {false} ;
         BC000M3_A536GenDel = new bool[] {false} ;
         sMode22 = "";
         BC000M2_A152GenID = new int[1] ;
         BC000M2_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000M2_n537GenDelDataHora = new bool[] {false} ;
         BC000M2_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         BC000M2_n538GenDelData = new bool[] {false} ;
         BC000M2_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000M2_n539GenDelHora = new bool[] {false} ;
         BC000M2_A540GenDelUsuId = new string[] {""} ;
         BC000M2_n540GenDelUsuId = new bool[] {false} ;
         BC000M2_A541GenDelUsuNome = new string[] {""} ;
         BC000M2_n541GenDelUsuNome = new bool[] {false} ;
         BC000M2_A153GenSigla = new string[] {""} ;
         BC000M2_A154GenNome = new string[] {""} ;
         BC000M2_A215GenAtivo = new bool[] {false} ;
         BC000M2_A536GenDel = new bool[] {false} ;
         BC000M8_A152GenID = new int[1] ;
         BC000M11_A158CliID = new Guid[] {Guid.Empty} ;
         BC000M11_A166CpjID = new Guid[] {Guid.Empty} ;
         BC000M11_A269CpjConSeq = new short[1] ;
         BC000M12_A152GenID = new int[1] ;
         BC000M12_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000M12_n537GenDelDataHora = new bool[] {false} ;
         BC000M12_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         BC000M12_n538GenDelData = new bool[] {false} ;
         BC000M12_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000M12_n539GenDelHora = new bool[] {false} ;
         BC000M12_A540GenDelUsuId = new string[] {""} ;
         BC000M12_n540GenDelUsuId = new bool[] {false} ;
         BC000M12_A541GenDelUsuNome = new string[] {""} ;
         BC000M12_n541GenDelUsuNome = new bool[] {false} ;
         BC000M12_A153GenSigla = new string[] {""} ;
         BC000M12_A154GenNome = new string[] {""} ;
         BC000M12_A215GenAtivo = new bool[] {false} ;
         BC000M12_A536GenDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.genero_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.genero_bc__default(),
            new Object[][] {
                new Object[] {
               BC000M2_A152GenID, BC000M2_A537GenDelDataHora, BC000M2_n537GenDelDataHora, BC000M2_A538GenDelData, BC000M2_n538GenDelData, BC000M2_A539GenDelHora, BC000M2_n539GenDelHora, BC000M2_A540GenDelUsuId, BC000M2_n540GenDelUsuId, BC000M2_A541GenDelUsuNome,
               BC000M2_n541GenDelUsuNome, BC000M2_A153GenSigla, BC000M2_A154GenNome, BC000M2_A215GenAtivo, BC000M2_A536GenDel
               }
               , new Object[] {
               BC000M3_A152GenID, BC000M3_A537GenDelDataHora, BC000M3_n537GenDelDataHora, BC000M3_A538GenDelData, BC000M3_n538GenDelData, BC000M3_A539GenDelHora, BC000M3_n539GenDelHora, BC000M3_A540GenDelUsuId, BC000M3_n540GenDelUsuId, BC000M3_A541GenDelUsuNome,
               BC000M3_n541GenDelUsuNome, BC000M3_A153GenSigla, BC000M3_A154GenNome, BC000M3_A215GenAtivo, BC000M3_A536GenDel
               }
               , new Object[] {
               BC000M4_A152GenID, BC000M4_A537GenDelDataHora, BC000M4_n537GenDelDataHora, BC000M4_A538GenDelData, BC000M4_n538GenDelData, BC000M4_A539GenDelHora, BC000M4_n539GenDelHora, BC000M4_A540GenDelUsuId, BC000M4_n540GenDelUsuId, BC000M4_A541GenDelUsuNome,
               BC000M4_n541GenDelUsuNome, BC000M4_A153GenSigla, BC000M4_A154GenNome, BC000M4_A215GenAtivo, BC000M4_A536GenDel
               }
               , new Object[] {
               BC000M5_A153GenSigla
               }
               , new Object[] {
               BC000M6_A152GenID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M8_A152GenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000M11_A158CliID, BC000M11_A166CpjID, BC000M11_A269CpjConSeq
               }
               , new Object[] {
               BC000M12_A152GenID, BC000M12_A537GenDelDataHora, BC000M12_n537GenDelDataHora, BC000M12_A538GenDelData, BC000M12_n538GenDelData, BC000M12_A539GenDelHora, BC000M12_n539GenDelHora, BC000M12_A540GenDelUsuId, BC000M12_n540GenDelUsuId, BC000M12_A541GenDelUsuNome,
               BC000M12_n541GenDelUsuNome, BC000M12_A153GenSigla, BC000M12_A154GenNome, BC000M12_A215GenAtivo, BC000M12_A536GenDel
               }
            }
         );
         Z215GenAtivo = true;
         A215GenAtivo = true;
         i215GenAtivo = true;
         AV15Pgmname = "core.Genero_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120M2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short nIsDirty_22 ;
      private int trnEnded ;
      private int Z152GenID ;
      private int A152GenID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV15Pgmname ;
      private string Z540GenDelUsuId ;
      private string A540GenDelUsuId ;
      private string sMode22 ;
      private DateTime Z537GenDelDataHora ;
      private DateTime A537GenDelDataHora ;
      private DateTime Z538GenDelData ;
      private DateTime A538GenDelData ;
      private DateTime Z539GenDelHora ;
      private DateTime A539GenDelHora ;
      private bool returnInSub ;
      private bool Z215GenAtivo ;
      private bool A215GenAtivo ;
      private bool Z536GenDel ;
      private bool A536GenDel ;
      private bool n537GenDelDataHora ;
      private bool n538GenDelData ;
      private bool n539GenDelHora ;
      private bool n540GenDelUsuId ;
      private bool n541GenDelUsuNome ;
      private bool O536GenDel ;
      private bool Gx_longc ;
      private bool i215GenAtivo ;
      private bool mustCommit ;
      private string Z541GenDelUsuNome ;
      private string A541GenDelUsuNome ;
      private string Z153GenSigla ;
      private string A153GenSigla ;
      private string Z154GenNome ;
      private string A154GenNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtGenero bccore_Genero ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000M4_A152GenID ;
      private DateTime[] BC000M4_A537GenDelDataHora ;
      private bool[] BC000M4_n537GenDelDataHora ;
      private DateTime[] BC000M4_A538GenDelData ;
      private bool[] BC000M4_n538GenDelData ;
      private DateTime[] BC000M4_A539GenDelHora ;
      private bool[] BC000M4_n539GenDelHora ;
      private string[] BC000M4_A540GenDelUsuId ;
      private bool[] BC000M4_n540GenDelUsuId ;
      private string[] BC000M4_A541GenDelUsuNome ;
      private bool[] BC000M4_n541GenDelUsuNome ;
      private string[] BC000M4_A153GenSigla ;
      private string[] BC000M4_A154GenNome ;
      private bool[] BC000M4_A215GenAtivo ;
      private bool[] BC000M4_A536GenDel ;
      private string[] BC000M5_A153GenSigla ;
      private int[] BC000M6_A152GenID ;
      private int[] BC000M3_A152GenID ;
      private DateTime[] BC000M3_A537GenDelDataHora ;
      private bool[] BC000M3_n537GenDelDataHora ;
      private DateTime[] BC000M3_A538GenDelData ;
      private bool[] BC000M3_n538GenDelData ;
      private DateTime[] BC000M3_A539GenDelHora ;
      private bool[] BC000M3_n539GenDelHora ;
      private string[] BC000M3_A540GenDelUsuId ;
      private bool[] BC000M3_n540GenDelUsuId ;
      private string[] BC000M3_A541GenDelUsuNome ;
      private bool[] BC000M3_n541GenDelUsuNome ;
      private string[] BC000M3_A153GenSigla ;
      private string[] BC000M3_A154GenNome ;
      private bool[] BC000M3_A215GenAtivo ;
      private bool[] BC000M3_A536GenDel ;
      private int[] BC000M2_A152GenID ;
      private DateTime[] BC000M2_A537GenDelDataHora ;
      private bool[] BC000M2_n537GenDelDataHora ;
      private DateTime[] BC000M2_A538GenDelData ;
      private bool[] BC000M2_n538GenDelData ;
      private DateTime[] BC000M2_A539GenDelHora ;
      private bool[] BC000M2_n539GenDelHora ;
      private string[] BC000M2_A540GenDelUsuId ;
      private bool[] BC000M2_n540GenDelUsuId ;
      private string[] BC000M2_A541GenDelUsuNome ;
      private bool[] BC000M2_n541GenDelUsuNome ;
      private string[] BC000M2_A153GenSigla ;
      private string[] BC000M2_A154GenNome ;
      private bool[] BC000M2_A215GenAtivo ;
      private bool[] BC000M2_A536GenDel ;
      private int[] BC000M8_A152GenID ;
      private Guid[] BC000M11_A158CliID ;
      private Guid[] BC000M11_A166CpjID ;
      private short[] BC000M11_A269CpjConSeq ;
      private int[] BC000M12_A152GenID ;
      private DateTime[] BC000M12_A537GenDelDataHora ;
      private bool[] BC000M12_n537GenDelDataHora ;
      private DateTime[] BC000M12_A538GenDelData ;
      private bool[] BC000M12_n538GenDelData ;
      private DateTime[] BC000M12_A539GenDelHora ;
      private bool[] BC000M12_n539GenDelHora ;
      private string[] BC000M12_A540GenDelUsuId ;
      private bool[] BC000M12_n540GenDelUsuId ;
      private string[] BC000M12_A541GenDelUsuNome ;
      private bool[] BC000M12_n541GenDelUsuNome ;
      private string[] BC000M12_A153GenSigla ;
      private string[] BC000M12_A154GenNome ;
      private bool[] BC000M12_A215GenAtivo ;
      private bool[] BC000M12_A536GenDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class genero_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class genero_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000M4;
        prmBC000M4 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M5;
        prmBC000M5 = new Object[] {
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M6;
        prmBC000M6 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M3;
        prmBC000M3 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M2;
        prmBC000M2 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M7;
        prmBC000M7 = new Object[] {
        new ParDef("GenDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("GenDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("GenDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("GenDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("GenDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenNome",GXType.VarChar,80,0) ,
        new ParDef("GenAtivo",GXType.Boolean,4,0) ,
        new ParDef("GenDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000M8;
        prmBC000M8 = new Object[] {
        };
        Object[] prmBC000M9;
        prmBC000M9 = new Object[] {
        new ParDef("GenDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("GenDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("GenDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("GenDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("GenDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenNome",GXType.VarChar,80,0) ,
        new ParDef("GenAtivo",GXType.Boolean,4,0) ,
        new ParDef("GenDel",GXType.Boolean,4,0) ,
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M10;
        prmBC000M10 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M11;
        prmBC000M11 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmBC000M12;
        prmBC000M12 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000M2", "SELECT GenID, GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel FROM tb_genero WHERE GenID = :GenID  FOR UPDATE OF tb_genero",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M3", "SELECT GenID, GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel FROM tb_genero WHERE GenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M4", "SELECT TM1.GenID, TM1.GenDelDataHora, TM1.GenDelData, TM1.GenDelHora, TM1.GenDelUsuId, TM1.GenDelUsuNome, TM1.GenSigla, TM1.GenNome, TM1.GenAtivo, TM1.GenDel FROM tb_genero TM1 WHERE TM1.GenID = :GenID ORDER BY TM1.GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M5", "SELECT GenSigla FROM tb_genero WHERE (GenSigla = :GenSigla) AND (Not ( GenID = :GenID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M6", "SELECT GenID FROM tb_genero WHERE GenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M7", "SAVEPOINT gxupdate;INSERT INTO tb_genero(GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel) VALUES(:GenDelDataHora, :GenDelData, :GenDelHora, :GenDelUsuId, :GenDelUsuNome, :GenSigla, :GenNome, :GenAtivo, :GenDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000M7)
           ,new CursorDef("BC000M8", "SELECT currval('GenID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000M9", "SAVEPOINT gxupdate;UPDATE tb_genero SET GenDelDataHora=:GenDelDataHora, GenDelData=:GenDelData, GenDelHora=:GenDelHora, GenDelUsuId=:GenDelUsuId, GenDelUsuNome=:GenDelUsuNome, GenSigla=:GenSigla, GenNome=:GenNome, GenAtivo=:GenAtivo, GenDel=:GenDel  WHERE GenID = :GenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M9)
           ,new CursorDef("BC000M10", "SAVEPOINT gxupdate;DELETE FROM tb_genero  WHERE GenID = :GenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000M10)
           ,new CursorDef("BC000M11", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CpjConGenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000M12", "SELECT TM1.GenID, TM1.GenDelDataHora, TM1.GenDelData, TM1.GenDelHora, TM1.GenDelUsuId, TM1.GenDelUsuNome, TM1.GenSigla, TM1.GenNome, TM1.GenAtivo, TM1.GenDel FROM tb_genero TM1 WHERE TM1.GenID = :GenID ORDER BY TM1.GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000M12,100, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 10 :
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
