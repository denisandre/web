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
   public class documentotipo_bc : GxSilentTrn, IGxSilentTrn
   {
      public documentotipo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentotipo_bc( IGxContext context )
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
         ReadRow0K20( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0K20( ) ;
         standaloneModal( ) ;
         AddRow0K20( ) ;
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
            E110K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z146DocTipoID = A146DocTipoID;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K20( ) ;
            }
            else
            {
               CheckExtendedTable0K20( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0K20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM0K20( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z504DocTipoDelDataHora = A504DocTipoDelDataHora;
            Z505DocTipoDelData = A505DocTipoDelData;
            Z506DocTipoDelHora = A506DocTipoDelHora;
            Z507DocTipoDelUsuID = A507DocTipoDelUsuID;
            Z508DocTipoDelUsuNome = A508DocTipoDelUsuNome;
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
            Z503DocTipoDel = A503DocTipoDel;
         }
         if ( GX_JID == -13 )
         {
            Z146DocTipoID = A146DocTipoID;
            Z504DocTipoDelDataHora = A504DocTipoDelDataHora;
            Z505DocTipoDelData = A505DocTipoDelData;
            Z506DocTipoDelHora = A506DocTipoDelHora;
            Z507DocTipoDelUsuID = A507DocTipoDelUsuID;
            Z508DocTipoDelUsuNome = A508DocTipoDelUsuNome;
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
            Z503DocTipoDel = A503DocTipoDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV14Pgmname = "core.DocumentoTipo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A219DocTipoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A219DocTipoAtivo = true;
         }
      }

      protected void Load0K20( )
      {
         /* Using cursor BC000K4 */
         pr_default.execute(2, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A504DocTipoDelDataHora = BC000K4_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = BC000K4_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = BC000K4_A505DocTipoDelData[0];
            n505DocTipoDelData = BC000K4_n505DocTipoDelData[0];
            A506DocTipoDelHora = BC000K4_A506DocTipoDelHora[0];
            n506DocTipoDelHora = BC000K4_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = BC000K4_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = BC000K4_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = BC000K4_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = BC000K4_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = BC000K4_A147DocTipoSigla[0];
            A148DocTipoNome = BC000K4_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000K4_A219DocTipoAtivo[0];
            A503DocTipoDel = BC000K4_A503DocTipoDel[0];
            ZM0K20( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0K20( ) ;
      }

      protected void OnLoadActions0K20( )
      {
      }

      protected void CheckExtendedTable0K20( )
      {
         nIsDirty_20 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000K5 */
         pr_default.execute(3, new Object[] {A147DocTipoSigla, A146DocTipoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A147DocTipoSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A148DocTipoNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0K20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K20( )
      {
         /* Using cursor BC000K6 */
         pr_default.execute(4, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000K3 */
         pr_default.execute(1, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K20( 13) ;
            RcdFound20 = 1;
            A146DocTipoID = BC000K3_A146DocTipoID[0];
            A504DocTipoDelDataHora = BC000K3_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = BC000K3_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = BC000K3_A505DocTipoDelData[0];
            n505DocTipoDelData = BC000K3_n505DocTipoDelData[0];
            A506DocTipoDelHora = BC000K3_A506DocTipoDelHora[0];
            n506DocTipoDelHora = BC000K3_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = BC000K3_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = BC000K3_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = BC000K3_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = BC000K3_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = BC000K3_A147DocTipoSigla[0];
            A148DocTipoNome = BC000K3_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000K3_A219DocTipoAtivo[0];
            A503DocTipoDel = BC000K3_A503DocTipoDel[0];
            O503DocTipoDel = A503DocTipoDel;
            Z146DocTipoID = A146DocTipoID;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0K20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0K20( ) ;
            }
            Gx_mode = sMode20;
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0K20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode20;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K20( ) ;
         if ( RcdFound20 == 0 )
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
         CONFIRM_0K0( ) ;
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

      protected void CheckOptimisticConcurrency0K20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000K2 */
            pr_default.execute(0, new Object[] {A146DocTipoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documentotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z504DocTipoDelDataHora != BC000K2_A504DocTipoDelDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z505DocTipoDelData ) != DateTimeUtil.ResetTime ( BC000K2_A505DocTipoDelData[0] ) ) || ( Z506DocTipoDelHora != BC000K2_A506DocTipoDelHora[0] ) || ( StringUtil.StrCmp(Z507DocTipoDelUsuID, BC000K2_A507DocTipoDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z508DocTipoDelUsuNome, BC000K2_A508DocTipoDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z147DocTipoSigla, BC000K2_A147DocTipoSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z148DocTipoNome, BC000K2_A148DocTipoNome[0]) != 0 ) || ( Z219DocTipoAtivo != BC000K2_A219DocTipoAtivo[0] ) || ( Z503DocTipoDel != BC000K2_A503DocTipoDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documentotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K20( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K20( 0) ;
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K7 */
                     pr_default.execute(5, new Object[] {n504DocTipoDelDataHora, A504DocTipoDelDataHora, n505DocTipoDelData, A505DocTipoDelData, n506DocTipoDelHora, A506DocTipoDelHora, n507DocTipoDelUsuID, A507DocTipoDelUsuID, n508DocTipoDelUsuNome, A508DocTipoDelUsuNome, A147DocTipoSigla, A148DocTipoNome, A219DocTipoAtivo, A503DocTipoDel});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000K8 */
                     pr_default.execute(6);
                     A146DocTipoID = BC000K8_A146DocTipoID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
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
               Load0K20( ) ;
            }
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void Update0K20( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000K9 */
                     pr_default.execute(7, new Object[] {n504DocTipoDelDataHora, A504DocTipoDelDataHora, n505DocTipoDelData, A505DocTipoDelData, n506DocTipoDelHora, A506DocTipoDelHora, n507DocTipoDelUsuID, A507DocTipoDelUsuID, n508DocTipoDelUsuNome, A508DocTipoDelUsuNome, A147DocTipoSigla, A148DocTipoNome, A219DocTipoAtivo, A503DocTipoDel, A146DocTipoID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documentotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K20( ) ;
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
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void DeferredUpdate0K20( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K20( ) ;
            AfterConfirm0K20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000K10 */
                  pr_default.execute(8, new Object[] {A146DocTipoID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0K20( ) ;
         Gx_mode = sMode20;
      }

      protected void OnDeleteControls0K20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000K11 */
            pr_default.execute(9, new Object[] {A146DocTipoID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0K20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K20( ) ;
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

      public void ScanKeyStart0K20( )
      {
         /* Scan By routine */
         /* Using cursor BC000K12 */
         pr_default.execute(10, new Object[] {A146DocTipoID});
         RcdFound20 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A146DocTipoID = BC000K12_A146DocTipoID[0];
            A504DocTipoDelDataHora = BC000K12_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = BC000K12_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = BC000K12_A505DocTipoDelData[0];
            n505DocTipoDelData = BC000K12_n505DocTipoDelData[0];
            A506DocTipoDelHora = BC000K12_A506DocTipoDelHora[0];
            n506DocTipoDelHora = BC000K12_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = BC000K12_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = BC000K12_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = BC000K12_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = BC000K12_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = BC000K12_A147DocTipoSigla[0];
            A148DocTipoNome = BC000K12_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000K12_A219DocTipoAtivo[0];
            A503DocTipoDel = BC000K12_A503DocTipoDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0K20( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound20 = 0;
         ScanKeyLoad0K20( ) ;
      }

      protected void ScanKeyLoad0K20( )
      {
         sMode20 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound20 = 1;
            A146DocTipoID = BC000K12_A146DocTipoID[0];
            A504DocTipoDelDataHora = BC000K12_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = BC000K12_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = BC000K12_A505DocTipoDelData[0];
            n505DocTipoDelData = BC000K12_n505DocTipoDelData[0];
            A506DocTipoDelHora = BC000K12_A506DocTipoDelHora[0];
            n506DocTipoDelHora = BC000K12_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = BC000K12_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = BC000K12_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = BC000K12_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = BC000K12_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = BC000K12_A147DocTipoSigla[0];
            A148DocTipoNome = BC000K12_A148DocTipoNome[0];
            A219DocTipoAtivo = BC000K12_A219DocTipoAtivo[0];
            A503DocTipoDel = BC000K12_A503DocTipoDel[0];
         }
         Gx_mode = sMode20;
      }

      protected void ScanKeyEnd0K20( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0K20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K20( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A504DocTipoDelDataHora = DateTimeUtil.Now( context);
            n504DocTipoDelDataHora = false;
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A507DocTipoDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n507DocTipoDelUsuID = false;
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A508DocTipoDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n508DocTipoDelUsuNome = false;
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A505DocTipoDelData = DateTimeUtil.ResetTime( A504DocTipoDelDataHora);
            n505DocTipoDelData = false;
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A506DocTipoDelHora = DateTimeUtil.ResetDate(A504DocTipoDelDataHora);
            n506DocTipoDelHora = false;
         }
      }

      protected void BeforeDelete0K20( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
      }

      protected void BeforeComplete0K20( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0K20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K20( )
      {
      }

      protected void send_integrity_lvl_hashes0K20( )
      {
      }

      protected void AddRow0K20( )
      {
         VarsToRow20( bccore_DocumentoTipo) ;
      }

      protected void ReadRow0K20( )
      {
         RowToVars20( bccore_DocumentoTipo, 1) ;
      }

      protected void InitializeNonKey0K20( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         n504DocTipoDelDataHora = false;
         A505DocTipoDelData = DateTime.MinValue;
         n505DocTipoDelData = false;
         A506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         n506DocTipoDelHora = false;
         A507DocTipoDelUsuID = "";
         n507DocTipoDelUsuID = false;
         A508DocTipoDelUsuNome = "";
         n508DocTipoDelUsuNome = false;
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         A503DocTipoDel = false;
         A219DocTipoAtivo = true;
         O503DocTipoDel = A503DocTipoDel;
         Z504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         Z505DocTipoDelData = DateTime.MinValue;
         Z506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         Z507DocTipoDelUsuID = "";
         Z508DocTipoDelUsuNome = "";
         Z147DocTipoSigla = "";
         Z148DocTipoNome = "";
         Z219DocTipoAtivo = false;
         Z503DocTipoDel = false;
      }

      protected void InitAll0K20( )
      {
         A146DocTipoID = 0;
         InitializeNonKey0K20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A219DocTipoAtivo = i219DocTipoAtivo;
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

      public void VarsToRow20( GeneXus.Programs.core.SdtDocumentoTipo obj20 )
      {
         obj20.gxTpr_Mode = Gx_mode;
         obj20.gxTpr_Doctipodeldatahora = A504DocTipoDelDataHora;
         obj20.gxTpr_Doctipodeldata = A505DocTipoDelData;
         obj20.gxTpr_Doctipodelhora = A506DocTipoDelHora;
         obj20.gxTpr_Doctipodelusuid = A507DocTipoDelUsuID;
         obj20.gxTpr_Doctipodelusunome = A508DocTipoDelUsuNome;
         obj20.gxTpr_Doctiposigla = A147DocTipoSigla;
         obj20.gxTpr_Doctiponome = A148DocTipoNome;
         obj20.gxTpr_Doctipodel = A503DocTipoDel;
         obj20.gxTpr_Doctipoativo = A219DocTipoAtivo;
         obj20.gxTpr_Doctipoid = A146DocTipoID;
         obj20.gxTpr_Doctipoid_Z = Z146DocTipoID;
         obj20.gxTpr_Doctiposigla_Z = Z147DocTipoSigla;
         obj20.gxTpr_Doctiponome_Z = Z148DocTipoNome;
         obj20.gxTpr_Doctipoativo_Z = Z219DocTipoAtivo;
         obj20.gxTpr_Doctipodel_Z = Z503DocTipoDel;
         obj20.gxTpr_Doctipodeldatahora_Z = Z504DocTipoDelDataHora;
         obj20.gxTpr_Doctipodeldata_Z = Z505DocTipoDelData;
         obj20.gxTpr_Doctipodelhora_Z = Z506DocTipoDelHora;
         obj20.gxTpr_Doctipodelusuid_Z = Z507DocTipoDelUsuID;
         obj20.gxTpr_Doctipodelusunome_Z = Z508DocTipoDelUsuNome;
         obj20.gxTpr_Doctipodeldatahora_N = (short)(Convert.ToInt16(n504DocTipoDelDataHora));
         obj20.gxTpr_Doctipodeldata_N = (short)(Convert.ToInt16(n505DocTipoDelData));
         obj20.gxTpr_Doctipodelhora_N = (short)(Convert.ToInt16(n506DocTipoDelHora));
         obj20.gxTpr_Doctipodelusuid_N = (short)(Convert.ToInt16(n507DocTipoDelUsuID));
         obj20.gxTpr_Doctipodelusunome_N = (short)(Convert.ToInt16(n508DocTipoDelUsuNome));
         obj20.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow20( GeneXus.Programs.core.SdtDocumentoTipo obj20 )
      {
         obj20.gxTpr_Doctipoid = A146DocTipoID;
         return  ;
      }

      public void RowToVars20( GeneXus.Programs.core.SdtDocumentoTipo obj20 ,
                               int forceLoad )
      {
         Gx_mode = obj20.gxTpr_Mode;
         A504DocTipoDelDataHora = obj20.gxTpr_Doctipodeldatahora;
         n504DocTipoDelDataHora = false;
         A505DocTipoDelData = obj20.gxTpr_Doctipodeldata;
         n505DocTipoDelData = false;
         A506DocTipoDelHora = obj20.gxTpr_Doctipodelhora;
         n506DocTipoDelHora = false;
         A507DocTipoDelUsuID = obj20.gxTpr_Doctipodelusuid;
         n507DocTipoDelUsuID = false;
         A508DocTipoDelUsuNome = obj20.gxTpr_Doctipodelusunome;
         n508DocTipoDelUsuNome = false;
         A147DocTipoSigla = obj20.gxTpr_Doctiposigla;
         A148DocTipoNome = obj20.gxTpr_Doctiponome;
         A503DocTipoDel = obj20.gxTpr_Doctipodel;
         A219DocTipoAtivo = obj20.gxTpr_Doctipoativo;
         A146DocTipoID = obj20.gxTpr_Doctipoid;
         Z146DocTipoID = obj20.gxTpr_Doctipoid_Z;
         Z147DocTipoSigla = obj20.gxTpr_Doctiposigla_Z;
         Z148DocTipoNome = obj20.gxTpr_Doctiponome_Z;
         Z219DocTipoAtivo = obj20.gxTpr_Doctipoativo_Z;
         Z503DocTipoDel = obj20.gxTpr_Doctipodel_Z;
         O503DocTipoDel = obj20.gxTpr_Doctipodel_Z;
         Z504DocTipoDelDataHora = obj20.gxTpr_Doctipodeldatahora_Z;
         Z505DocTipoDelData = obj20.gxTpr_Doctipodeldata_Z;
         Z506DocTipoDelHora = obj20.gxTpr_Doctipodelhora_Z;
         Z507DocTipoDelUsuID = obj20.gxTpr_Doctipodelusuid_Z;
         Z508DocTipoDelUsuNome = obj20.gxTpr_Doctipodelusunome_Z;
         n504DocTipoDelDataHora = (bool)(Convert.ToBoolean(obj20.gxTpr_Doctipodeldatahora_N));
         n505DocTipoDelData = (bool)(Convert.ToBoolean(obj20.gxTpr_Doctipodeldata_N));
         n506DocTipoDelHora = (bool)(Convert.ToBoolean(obj20.gxTpr_Doctipodelhora_N));
         n507DocTipoDelUsuID = (bool)(Convert.ToBoolean(obj20.gxTpr_Doctipodelusuid_N));
         n508DocTipoDelUsuNome = (bool)(Convert.ToBoolean(obj20.gxTpr_Doctipodelusunome_N));
         Gx_mode = obj20.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A146DocTipoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0K20( ) ;
         ScanKeyStart0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z146DocTipoID = A146DocTipoID;
            O503DocTipoDel = A503DocTipoDel;
         }
         ZM0K20( -13) ;
         OnLoadActions0K20( ) ;
         AddRow0K20( ) ;
         ScanKeyEnd0K20( ) ;
         if ( RcdFound20 == 0 )
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
         RowToVars20( bccore_DocumentoTipo, 0) ;
         ScanKeyStart0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z146DocTipoID = A146DocTipoID;
            O503DocTipoDel = A503DocTipoDel;
         }
         ZM0K20( -13) ;
         OnLoadActions0K20( ) ;
         AddRow0K20( ) ;
         ScanKeyEnd0K20( ) ;
         if ( RcdFound20 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0K20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0K20( ) ;
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A146DocTipoID != Z146DocTipoID )
               {
                  A146DocTipoID = Z146DocTipoID;
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
                  Update0K20( ) ;
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
                  if ( A146DocTipoID != Z146DocTipoID )
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
                        Insert0K20( ) ;
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
                        Insert0K20( ) ;
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
         RowToVars20( bccore_DocumentoTipo, 1) ;
         SaveImpl( ) ;
         VarsToRow20( bccore_DocumentoTipo) ;
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
         RowToVars20( bccore_DocumentoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K20( ) ;
         AfterTrn( ) ;
         VarsToRow20( bccore_DocumentoTipo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow20( bccore_DocumentoTipo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtDocumentoTipo auxBC = new GeneXus.Programs.core.SdtDocumentoTipo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A146DocTipoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_DocumentoTipo);
               auxBC.Save();
               bccore_DocumentoTipo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars20( bccore_DocumentoTipo, 1) ;
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
         RowToVars20( bccore_DocumentoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0K20( ) ;
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
               VarsToRow20( bccore_DocumentoTipo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow20( bccore_DocumentoTipo) ;
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
         RowToVars20( bccore_DocumentoTipo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0K20( ) ;
         if ( RcdFound20 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A146DocTipoID != Z146DocTipoID )
            {
               A146DocTipoID = Z146DocTipoID;
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
            if ( A146DocTipoID != Z146DocTipoID )
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
         context.RollbackDataStores("core.documentotipo_bc",pr_default);
         VarsToRow20( bccore_DocumentoTipo) ;
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
         Gx_mode = bccore_DocumentoTipo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_DocumentoTipo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_DocumentoTipo )
         {
            bccore_DocumentoTipo = (GeneXus.Programs.core.SdtDocumentoTipo)(sdt);
            if ( StringUtil.StrCmp(bccore_DocumentoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoTipo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow20( bccore_DocumentoTipo) ;
            }
            else
            {
               RowToVars20( bccore_DocumentoTipo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_DocumentoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_DocumentoTipo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars20( bccore_DocumentoTipo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtDocumentoTipo DocumentoTipo_BC
      {
         get {
            return bccore_DocumentoTipo ;
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
            return "documentotipo_Execute" ;
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
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Z504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         A504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         Z505DocTipoDelData = DateTime.MinValue;
         A505DocTipoDelData = DateTime.MinValue;
         Z506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         A506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         Z507DocTipoDelUsuID = "";
         A507DocTipoDelUsuID = "";
         Z508DocTipoDelUsuNome = "";
         A508DocTipoDelUsuNome = "";
         Z147DocTipoSigla = "";
         A147DocTipoSigla = "";
         Z148DocTipoNome = "";
         A148DocTipoNome = "";
         BC000K4_A146DocTipoID = new int[1] ;
         BC000K4_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000K4_n504DocTipoDelDataHora = new bool[] {false} ;
         BC000K4_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         BC000K4_n505DocTipoDelData = new bool[] {false} ;
         BC000K4_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000K4_n506DocTipoDelHora = new bool[] {false} ;
         BC000K4_A507DocTipoDelUsuID = new string[] {""} ;
         BC000K4_n507DocTipoDelUsuID = new bool[] {false} ;
         BC000K4_A508DocTipoDelUsuNome = new string[] {""} ;
         BC000K4_n508DocTipoDelUsuNome = new bool[] {false} ;
         BC000K4_A147DocTipoSigla = new string[] {""} ;
         BC000K4_A148DocTipoNome = new string[] {""} ;
         BC000K4_A219DocTipoAtivo = new bool[] {false} ;
         BC000K4_A503DocTipoDel = new bool[] {false} ;
         BC000K5_A147DocTipoSigla = new string[] {""} ;
         BC000K6_A146DocTipoID = new int[1] ;
         BC000K3_A146DocTipoID = new int[1] ;
         BC000K3_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000K3_n504DocTipoDelDataHora = new bool[] {false} ;
         BC000K3_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         BC000K3_n505DocTipoDelData = new bool[] {false} ;
         BC000K3_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000K3_n506DocTipoDelHora = new bool[] {false} ;
         BC000K3_A507DocTipoDelUsuID = new string[] {""} ;
         BC000K3_n507DocTipoDelUsuID = new bool[] {false} ;
         BC000K3_A508DocTipoDelUsuNome = new string[] {""} ;
         BC000K3_n508DocTipoDelUsuNome = new bool[] {false} ;
         BC000K3_A147DocTipoSigla = new string[] {""} ;
         BC000K3_A148DocTipoNome = new string[] {""} ;
         BC000K3_A219DocTipoAtivo = new bool[] {false} ;
         BC000K3_A503DocTipoDel = new bool[] {false} ;
         sMode20 = "";
         BC000K2_A146DocTipoID = new int[1] ;
         BC000K2_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000K2_n504DocTipoDelDataHora = new bool[] {false} ;
         BC000K2_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         BC000K2_n505DocTipoDelData = new bool[] {false} ;
         BC000K2_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000K2_n506DocTipoDelHora = new bool[] {false} ;
         BC000K2_A507DocTipoDelUsuID = new string[] {""} ;
         BC000K2_n507DocTipoDelUsuID = new bool[] {false} ;
         BC000K2_A508DocTipoDelUsuNome = new string[] {""} ;
         BC000K2_n508DocTipoDelUsuNome = new bool[] {false} ;
         BC000K2_A147DocTipoSigla = new string[] {""} ;
         BC000K2_A148DocTipoNome = new string[] {""} ;
         BC000K2_A219DocTipoAtivo = new bool[] {false} ;
         BC000K2_A503DocTipoDel = new bool[] {false} ;
         BC000K8_A146DocTipoID = new int[1] ;
         BC000K11_A289DocID = new Guid[] {Guid.Empty} ;
         BC000K12_A146DocTipoID = new int[1] ;
         BC000K12_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000K12_n504DocTipoDelDataHora = new bool[] {false} ;
         BC000K12_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         BC000K12_n505DocTipoDelData = new bool[] {false} ;
         BC000K12_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000K12_n506DocTipoDelHora = new bool[] {false} ;
         BC000K12_A507DocTipoDelUsuID = new string[] {""} ;
         BC000K12_n507DocTipoDelUsuID = new bool[] {false} ;
         BC000K12_A508DocTipoDelUsuNome = new string[] {""} ;
         BC000K12_n508DocTipoDelUsuNome = new bool[] {false} ;
         BC000K12_A147DocTipoSigla = new string[] {""} ;
         BC000K12_A148DocTipoNome = new string[] {""} ;
         BC000K12_A219DocTipoAtivo = new bool[] {false} ;
         BC000K12_A503DocTipoDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000K2_A146DocTipoID, BC000K2_A504DocTipoDelDataHora, BC000K2_n504DocTipoDelDataHora, BC000K2_A505DocTipoDelData, BC000K2_n505DocTipoDelData, BC000K2_A506DocTipoDelHora, BC000K2_n506DocTipoDelHora, BC000K2_A507DocTipoDelUsuID, BC000K2_n507DocTipoDelUsuID, BC000K2_A508DocTipoDelUsuNome,
               BC000K2_n508DocTipoDelUsuNome, BC000K2_A147DocTipoSigla, BC000K2_A148DocTipoNome, BC000K2_A219DocTipoAtivo, BC000K2_A503DocTipoDel
               }
               , new Object[] {
               BC000K3_A146DocTipoID, BC000K3_A504DocTipoDelDataHora, BC000K3_n504DocTipoDelDataHora, BC000K3_A505DocTipoDelData, BC000K3_n505DocTipoDelData, BC000K3_A506DocTipoDelHora, BC000K3_n506DocTipoDelHora, BC000K3_A507DocTipoDelUsuID, BC000K3_n507DocTipoDelUsuID, BC000K3_A508DocTipoDelUsuNome,
               BC000K3_n508DocTipoDelUsuNome, BC000K3_A147DocTipoSigla, BC000K3_A148DocTipoNome, BC000K3_A219DocTipoAtivo, BC000K3_A503DocTipoDel
               }
               , new Object[] {
               BC000K4_A146DocTipoID, BC000K4_A504DocTipoDelDataHora, BC000K4_n504DocTipoDelDataHora, BC000K4_A505DocTipoDelData, BC000K4_n505DocTipoDelData, BC000K4_A506DocTipoDelHora, BC000K4_n506DocTipoDelHora, BC000K4_A507DocTipoDelUsuID, BC000K4_n507DocTipoDelUsuID, BC000K4_A508DocTipoDelUsuNome,
               BC000K4_n508DocTipoDelUsuNome, BC000K4_A147DocTipoSigla, BC000K4_A148DocTipoNome, BC000K4_A219DocTipoAtivo, BC000K4_A503DocTipoDel
               }
               , new Object[] {
               BC000K5_A147DocTipoSigla
               }
               , new Object[] {
               BC000K6_A146DocTipoID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K8_A146DocTipoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000K11_A289DocID
               }
               , new Object[] {
               BC000K12_A146DocTipoID, BC000K12_A504DocTipoDelDataHora, BC000K12_n504DocTipoDelDataHora, BC000K12_A505DocTipoDelData, BC000K12_n505DocTipoDelData, BC000K12_A506DocTipoDelHora, BC000K12_n506DocTipoDelHora, BC000K12_A507DocTipoDelUsuID, BC000K12_n507DocTipoDelUsuID, BC000K12_A508DocTipoDelUsuNome,
               BC000K12_n508DocTipoDelUsuNome, BC000K12_A147DocTipoSigla, BC000K12_A148DocTipoNome, BC000K12_A219DocTipoAtivo, BC000K12_A503DocTipoDel
               }
            }
         );
         Z219DocTipoAtivo = true;
         A219DocTipoAtivo = true;
         i219DocTipoAtivo = true;
         AV14Pgmname = "core.DocumentoTipo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120K2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short nIsDirty_20 ;
      private int trnEnded ;
      private int Z146DocTipoID ;
      private int A146DocTipoID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z507DocTipoDelUsuID ;
      private string A507DocTipoDelUsuID ;
      private string sMode20 ;
      private DateTime Z504DocTipoDelDataHora ;
      private DateTime A504DocTipoDelDataHora ;
      private DateTime Z506DocTipoDelHora ;
      private DateTime A506DocTipoDelHora ;
      private DateTime Z505DocTipoDelData ;
      private DateTime A505DocTipoDelData ;
      private bool returnInSub ;
      private bool Z219DocTipoAtivo ;
      private bool A219DocTipoAtivo ;
      private bool Z503DocTipoDel ;
      private bool A503DocTipoDel ;
      private bool n504DocTipoDelDataHora ;
      private bool n505DocTipoDelData ;
      private bool n506DocTipoDelHora ;
      private bool n507DocTipoDelUsuID ;
      private bool n508DocTipoDelUsuNome ;
      private bool O503DocTipoDel ;
      private bool Gx_longc ;
      private bool i219DocTipoAtivo ;
      private bool mustCommit ;
      private string Z508DocTipoDelUsuNome ;
      private string A508DocTipoDelUsuNome ;
      private string Z147DocTipoSigla ;
      private string A147DocTipoSigla ;
      private string Z148DocTipoNome ;
      private string A148DocTipoNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtDocumentoTipo bccore_DocumentoTipo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000K4_A146DocTipoID ;
      private DateTime[] BC000K4_A504DocTipoDelDataHora ;
      private bool[] BC000K4_n504DocTipoDelDataHora ;
      private DateTime[] BC000K4_A505DocTipoDelData ;
      private bool[] BC000K4_n505DocTipoDelData ;
      private DateTime[] BC000K4_A506DocTipoDelHora ;
      private bool[] BC000K4_n506DocTipoDelHora ;
      private string[] BC000K4_A507DocTipoDelUsuID ;
      private bool[] BC000K4_n507DocTipoDelUsuID ;
      private string[] BC000K4_A508DocTipoDelUsuNome ;
      private bool[] BC000K4_n508DocTipoDelUsuNome ;
      private string[] BC000K4_A147DocTipoSigla ;
      private string[] BC000K4_A148DocTipoNome ;
      private bool[] BC000K4_A219DocTipoAtivo ;
      private bool[] BC000K4_A503DocTipoDel ;
      private string[] BC000K5_A147DocTipoSigla ;
      private int[] BC000K6_A146DocTipoID ;
      private int[] BC000K3_A146DocTipoID ;
      private DateTime[] BC000K3_A504DocTipoDelDataHora ;
      private bool[] BC000K3_n504DocTipoDelDataHora ;
      private DateTime[] BC000K3_A505DocTipoDelData ;
      private bool[] BC000K3_n505DocTipoDelData ;
      private DateTime[] BC000K3_A506DocTipoDelHora ;
      private bool[] BC000K3_n506DocTipoDelHora ;
      private string[] BC000K3_A507DocTipoDelUsuID ;
      private bool[] BC000K3_n507DocTipoDelUsuID ;
      private string[] BC000K3_A508DocTipoDelUsuNome ;
      private bool[] BC000K3_n508DocTipoDelUsuNome ;
      private string[] BC000K3_A147DocTipoSigla ;
      private string[] BC000K3_A148DocTipoNome ;
      private bool[] BC000K3_A219DocTipoAtivo ;
      private bool[] BC000K3_A503DocTipoDel ;
      private int[] BC000K2_A146DocTipoID ;
      private DateTime[] BC000K2_A504DocTipoDelDataHora ;
      private bool[] BC000K2_n504DocTipoDelDataHora ;
      private DateTime[] BC000K2_A505DocTipoDelData ;
      private bool[] BC000K2_n505DocTipoDelData ;
      private DateTime[] BC000K2_A506DocTipoDelHora ;
      private bool[] BC000K2_n506DocTipoDelHora ;
      private string[] BC000K2_A507DocTipoDelUsuID ;
      private bool[] BC000K2_n507DocTipoDelUsuID ;
      private string[] BC000K2_A508DocTipoDelUsuNome ;
      private bool[] BC000K2_n508DocTipoDelUsuNome ;
      private string[] BC000K2_A147DocTipoSigla ;
      private string[] BC000K2_A148DocTipoNome ;
      private bool[] BC000K2_A219DocTipoAtivo ;
      private bool[] BC000K2_A503DocTipoDel ;
      private int[] BC000K8_A146DocTipoID ;
      private Guid[] BC000K11_A289DocID ;
      private int[] BC000K12_A146DocTipoID ;
      private DateTime[] BC000K12_A504DocTipoDelDataHora ;
      private bool[] BC000K12_n504DocTipoDelDataHora ;
      private DateTime[] BC000K12_A505DocTipoDelData ;
      private bool[] BC000K12_n505DocTipoDelData ;
      private DateTime[] BC000K12_A506DocTipoDelHora ;
      private bool[] BC000K12_n506DocTipoDelHora ;
      private string[] BC000K12_A507DocTipoDelUsuID ;
      private bool[] BC000K12_n507DocTipoDelUsuID ;
      private string[] BC000K12_A508DocTipoDelUsuNome ;
      private bool[] BC000K12_n508DocTipoDelUsuNome ;
      private string[] BC000K12_A147DocTipoSigla ;
      private string[] BC000K12_A148DocTipoNome ;
      private bool[] BC000K12_A219DocTipoAtivo ;
      private bool[] BC000K12_A503DocTipoDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class documentotipo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentotipo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000K4;
        prmBC000K4 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K5;
        prmBC000K5 = new Object[] {
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K6;
        prmBC000K6 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K3;
        prmBC000K3 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K2;
        prmBC000K2 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K7;
        prmBC000K7 = new Object[] {
        new ParDef("DocTipoDelDataHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocTipoDelData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocTipoDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocTipoDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocTipoDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoNome",GXType.VarChar,80,0) ,
        new ParDef("DocTipoAtivo",GXType.Boolean,4,0) ,
        new ParDef("DocTipoDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000K8;
        prmBC000K8 = new Object[] {
        };
        Object[] prmBC000K9;
        prmBC000K9 = new Object[] {
        new ParDef("DocTipoDelDataHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocTipoDelData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocTipoDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocTipoDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocTipoDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoNome",GXType.VarChar,80,0) ,
        new ParDef("DocTipoAtivo",GXType.Boolean,4,0) ,
        new ParDef("DocTipoDel",GXType.Boolean,4,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K10;
        prmBC000K10 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K11;
        prmBC000K11 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000K12;
        prmBC000K12 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000K2", "SELECT DocTipoID, DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel FROM tb_documentotipo WHERE DocTipoID = :DocTipoID  FOR UPDATE OF tb_documentotipo",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K3", "SELECT DocTipoID, DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K4", "SELECT TM1.DocTipoID, TM1.DocTipoDelDataHora, TM1.DocTipoDelData, TM1.DocTipoDelHora, TM1.DocTipoDelUsuID, TM1.DocTipoDelUsuNome, TM1.DocTipoSigla, TM1.DocTipoNome, TM1.DocTipoAtivo, TM1.DocTipoDel FROM tb_documentotipo TM1 WHERE TM1.DocTipoID = :DocTipoID ORDER BY TM1.DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K5", "SELECT DocTipoSigla FROM tb_documentotipo WHERE (DocTipoSigla = :DocTipoSigla) AND (Not ( DocTipoID = :DocTipoID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K6", "SELECT DocTipoID FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K7", "SAVEPOINT gxupdate;INSERT INTO tb_documentotipo(DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel) VALUES(:DocTipoDelDataHora, :DocTipoDelData, :DocTipoDelHora, :DocTipoDelUsuID, :DocTipoDelUsuNome, :DocTipoSigla, :DocTipoNome, :DocTipoAtivo, :DocTipoDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000K7)
           ,new CursorDef("BC000K8", "SELECT currval('DocTipoID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000K9", "SAVEPOINT gxupdate;UPDATE tb_documentotipo SET DocTipoDelDataHora=:DocTipoDelDataHora, DocTipoDelData=:DocTipoDelData, DocTipoDelHora=:DocTipoDelHora, DocTipoDelUsuID=:DocTipoDelUsuID, DocTipoDelUsuNome=:DocTipoDelUsuNome, DocTipoSigla=:DocTipoSigla, DocTipoNome=:DocTipoNome, DocTipoAtivo=:DocTipoAtivo, DocTipoDel=:DocTipoDel  WHERE DocTipoID = :DocTipoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000K9)
           ,new CursorDef("BC000K10", "SAVEPOINT gxupdate;DELETE FROM tb_documentotipo  WHERE DocTipoID = :DocTipoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000K10)
           ,new CursorDef("BC000K11", "SELECT DocID FROM tb_documento WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000K12", "SELECT TM1.DocTipoID, TM1.DocTipoDelDataHora, TM1.DocTipoDelData, TM1.DocTipoDelHora, TM1.DocTipoDelUsuID, TM1.DocTipoDelUsuNome, TM1.DocTipoSigla, TM1.DocTipoNome, TM1.DocTipoAtivo, TM1.DocTipoDel FROM tb_documentotipo TM1 WHERE TM1.DocTipoID = :DocTipoID ORDER BY TM1.DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000K12,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
