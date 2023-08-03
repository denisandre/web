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
   public class produtotipo_bc : GxSilentTrn, IGxSilentTrn
   {
      public produtotipo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtotipo_bc( IGxContext context )
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
         ReadRow0R27( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0R27( ) ;
         standaloneModal( ) ;
         AddRow0R27( ) ;
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
            E110R2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z211PrtID = A211PrtID;
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

      protected void CONFIRM_0R0( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0R27( ) ;
            }
            else
            {
               CheckExtendedTable0R27( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0R27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120R2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110R2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM0R27( short GX_JID )
      {
         if ( ( GX_JID == 11 ) || ( GX_JID == 0 ) )
         {
            Z615PrtDelDataHora = A615PrtDelDataHora;
            Z616PrtDelData = A616PrtDelData;
            Z617PrtDelHora = A617PrtDelHora;
            Z618PrtDelUsuId = A618PrtDelUsuId;
            Z619PrtDelUsuNome = A619PrtDelUsuNome;
            Z212PrtSigla = A212PrtSigla;
            Z213PrtNome = A213PrtNome;
            Z214PrtAtivo = A214PrtAtivo;
            Z614PrtDel = A614PrtDel;
         }
         if ( GX_JID == -11 )
         {
            Z211PrtID = A211PrtID;
            Z615PrtDelDataHora = A615PrtDelDataHora;
            Z616PrtDelData = A616PrtDelData;
            Z617PrtDelHora = A617PrtDelHora;
            Z618PrtDelUsuId = A618PrtDelUsuId;
            Z619PrtDelUsuNome = A619PrtDelUsuNome;
            Z212PrtSigla = A212PrtSigla;
            Z213PrtNome = A213PrtNome;
            Z214PrtAtivo = A214PrtAtivo;
            Z614PrtDel = A614PrtDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV14Pgmname = "core.ProdutoTipo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A214PrtAtivo) && ( Gx_BScreen == 0 ) )
         {
            A214PrtAtivo = true;
         }
      }

      protected void Load0R27( )
      {
         /* Using cursor BC000R4 */
         pr_default.execute(2, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound27 = 1;
            A615PrtDelDataHora = BC000R4_A615PrtDelDataHora[0];
            n615PrtDelDataHora = BC000R4_n615PrtDelDataHora[0];
            A616PrtDelData = BC000R4_A616PrtDelData[0];
            n616PrtDelData = BC000R4_n616PrtDelData[0];
            A617PrtDelHora = BC000R4_A617PrtDelHora[0];
            n617PrtDelHora = BC000R4_n617PrtDelHora[0];
            A618PrtDelUsuId = BC000R4_A618PrtDelUsuId[0];
            n618PrtDelUsuId = BC000R4_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = BC000R4_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = BC000R4_n619PrtDelUsuNome[0];
            A212PrtSigla = BC000R4_A212PrtSigla[0];
            A213PrtNome = BC000R4_A213PrtNome[0];
            A214PrtAtivo = BC000R4_A214PrtAtivo[0];
            A614PrtDel = BC000R4_A614PrtDel[0];
            ZM0R27( -11) ;
         }
         pr_default.close(2);
         OnLoadActions0R27( ) ;
      }

      protected void OnLoadActions0R27( )
      {
      }

      protected void CheckExtendedTable0R27( )
      {
         nIsDirty_27 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R27( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R27( )
      {
         /* Using cursor BC000R5 */
         pr_default.execute(3, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000R3 */
         pr_default.execute(1, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R27( 11) ;
            RcdFound27 = 1;
            A211PrtID = BC000R3_A211PrtID[0];
            A615PrtDelDataHora = BC000R3_A615PrtDelDataHora[0];
            n615PrtDelDataHora = BC000R3_n615PrtDelDataHora[0];
            A616PrtDelData = BC000R3_A616PrtDelData[0];
            n616PrtDelData = BC000R3_n616PrtDelData[0];
            A617PrtDelHora = BC000R3_A617PrtDelHora[0];
            n617PrtDelHora = BC000R3_n617PrtDelHora[0];
            A618PrtDelUsuId = BC000R3_A618PrtDelUsuId[0];
            n618PrtDelUsuId = BC000R3_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = BC000R3_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = BC000R3_n619PrtDelUsuNome[0];
            A212PrtSigla = BC000R3_A212PrtSigla[0];
            A213PrtNome = BC000R3_A213PrtNome[0];
            A214PrtAtivo = BC000R3_A214PrtAtivo[0];
            A614PrtDel = BC000R3_A614PrtDel[0];
            O614PrtDel = A614PrtDel;
            Z211PrtID = A211PrtID;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0R27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0R27( ) ;
            }
            Gx_mode = sMode27;
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0R27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode27;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R27( ) ;
         if ( RcdFound27 == 0 )
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
         CONFIRM_0R0( ) ;
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

      protected void CheckOptimisticConcurrency0R27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000R2 */
            pr_default.execute(0, new Object[] {A211PrtID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produtotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z615PrtDelDataHora != BC000R2_A615PrtDelDataHora[0] ) || ( Z616PrtDelData != BC000R2_A616PrtDelData[0] ) || ( Z617PrtDelHora != BC000R2_A617PrtDelHora[0] ) || ( StringUtil.StrCmp(Z618PrtDelUsuId, BC000R2_A618PrtDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z619PrtDelUsuNome, BC000R2_A619PrtDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z212PrtSigla, BC000R2_A212PrtSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z213PrtNome, BC000R2_A213PrtNome[0]) != 0 ) || ( Z214PrtAtivo != BC000R2_A214PrtAtivo[0] ) || ( Z614PrtDel != BC000R2_A614PrtDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_produtotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R27( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R27( 0) ;
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R6 */
                     pr_default.execute(4, new Object[] {n615PrtDelDataHora, A615PrtDelDataHora, n616PrtDelData, A616PrtDelData, n617PrtDelHora, A617PrtDelHora, n618PrtDelUsuId, A618PrtDelUsuId, n619PrtDelUsuNome, A619PrtDelUsuNome, A212PrtSigla, A213PrtNome, A214PrtAtivo, A614PrtDel});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000R7 */
                     pr_default.execute(5);
                     A211PrtID = BC000R7_A211PrtID[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
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
               Load0R27( ) ;
            }
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void Update0R27( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000R8 */
                     pr_default.execute(6, new Object[] {n615PrtDelDataHora, A615PrtDelDataHora, n616PrtDelData, A616PrtDelData, n617PrtDelHora, A617PrtDelHora, n618PrtDelUsuId, A618PrtDelUsuId, n619PrtDelUsuNome, A619PrtDelUsuNome, A212PrtSigla, A213PrtNome, A214PrtAtivo, A614PrtDel, A211PrtID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produtotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R27( ) ;
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
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void DeferredUpdate0R27( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R27( ) ;
            AfterConfirm0R27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000R9 */
                  pr_default.execute(7, new Object[] {A211PrtID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0R27( ) ;
         Gx_mode = sMode27;
      }

      protected void OnDeleteControls0R27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000R10 */
            pr_default.execute(8, new Object[] {A211PrtID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel0R27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R27( ) ;
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

      public void ScanKeyStart0R27( )
      {
         /* Scan By routine */
         /* Using cursor BC000R11 */
         pr_default.execute(9, new Object[] {A211PrtID});
         RcdFound27 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A211PrtID = BC000R11_A211PrtID[0];
            A615PrtDelDataHora = BC000R11_A615PrtDelDataHora[0];
            n615PrtDelDataHora = BC000R11_n615PrtDelDataHora[0];
            A616PrtDelData = BC000R11_A616PrtDelData[0];
            n616PrtDelData = BC000R11_n616PrtDelData[0];
            A617PrtDelHora = BC000R11_A617PrtDelHora[0];
            n617PrtDelHora = BC000R11_n617PrtDelHora[0];
            A618PrtDelUsuId = BC000R11_A618PrtDelUsuId[0];
            n618PrtDelUsuId = BC000R11_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = BC000R11_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = BC000R11_n619PrtDelUsuNome[0];
            A212PrtSigla = BC000R11_A212PrtSigla[0];
            A213PrtNome = BC000R11_A213PrtNome[0];
            A214PrtAtivo = BC000R11_A214PrtAtivo[0];
            A614PrtDel = BC000R11_A614PrtDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0R27( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound27 = 0;
         ScanKeyLoad0R27( ) ;
      }

      protected void ScanKeyLoad0R27( )
      {
         sMode27 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound27 = 1;
            A211PrtID = BC000R11_A211PrtID[0];
            A615PrtDelDataHora = BC000R11_A615PrtDelDataHora[0];
            n615PrtDelDataHora = BC000R11_n615PrtDelDataHora[0];
            A616PrtDelData = BC000R11_A616PrtDelData[0];
            n616PrtDelData = BC000R11_n616PrtDelData[0];
            A617PrtDelHora = BC000R11_A617PrtDelHora[0];
            n617PrtDelHora = BC000R11_n617PrtDelHora[0];
            A618PrtDelUsuId = BC000R11_A618PrtDelUsuId[0];
            n618PrtDelUsuId = BC000R11_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = BC000R11_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = BC000R11_n619PrtDelUsuNome[0];
            A212PrtSigla = BC000R11_A212PrtSigla[0];
            A213PrtNome = BC000R11_A213PrtNome[0];
            A214PrtAtivo = BC000R11_A214PrtAtivo[0];
            A614PrtDel = BC000R11_A614PrtDel[0];
         }
         Gx_mode = sMode27;
      }

      protected void ScanKeyEnd0R27( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0R27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R27( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A615PrtDelDataHora = DateTimeUtil.NowMS( context);
            n615PrtDelDataHora = false;
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A618PrtDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n618PrtDelUsuId = false;
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A619PrtDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n619PrtDelUsuNome = false;
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A616PrtDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A615PrtDelDataHora) ) ;
            n616PrtDelData = false;
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A617PrtDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A615PrtDelDataHora));
            n617PrtDelHora = false;
         }
      }

      protected void BeforeDelete0R27( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
      }

      protected void BeforeComplete0R27( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0R27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R27( )
      {
      }

      protected void send_integrity_lvl_hashes0R27( )
      {
      }

      protected void AddRow0R27( )
      {
         VarsToRow27( bccore_ProdutoTipo) ;
      }

      protected void ReadRow0R27( )
      {
         RowToVars27( bccore_ProdutoTipo, 1) ;
      }

      protected void InitializeNonKey0R27( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         n615PrtDelDataHora = false;
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         n616PrtDelData = false;
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         n617PrtDelHora = false;
         A618PrtDelUsuId = "";
         n618PrtDelUsuId = false;
         A619PrtDelUsuNome = "";
         n619PrtDelUsuNome = false;
         A212PrtSigla = "";
         A213PrtNome = "";
         A614PrtDel = false;
         A214PrtAtivo = true;
         O614PrtDel = A614PrtDel;
         Z615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         Z616PrtDelData = (DateTime)(DateTime.MinValue);
         Z617PrtDelHora = (DateTime)(DateTime.MinValue);
         Z618PrtDelUsuId = "";
         Z619PrtDelUsuNome = "";
         Z212PrtSigla = "";
         Z213PrtNome = "";
         Z214PrtAtivo = false;
         Z614PrtDel = false;
      }

      protected void InitAll0R27( )
      {
         A211PrtID = 0;
         InitializeNonKey0R27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A214PrtAtivo = i214PrtAtivo;
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

      public void VarsToRow27( GeneXus.Programs.core.SdtProdutoTipo obj27 )
      {
         obj27.gxTpr_Mode = Gx_mode;
         obj27.gxTpr_Prtdeldatahora = A615PrtDelDataHora;
         obj27.gxTpr_Prtdeldata = A616PrtDelData;
         obj27.gxTpr_Prtdelhora = A617PrtDelHora;
         obj27.gxTpr_Prtdelusuid = A618PrtDelUsuId;
         obj27.gxTpr_Prtdelusunome = A619PrtDelUsuNome;
         obj27.gxTpr_Prtsigla = A212PrtSigla;
         obj27.gxTpr_Prtnome = A213PrtNome;
         obj27.gxTpr_Prtdel = A614PrtDel;
         obj27.gxTpr_Prtativo = A214PrtAtivo;
         obj27.gxTpr_Prtid = A211PrtID;
         obj27.gxTpr_Prtid_Z = Z211PrtID;
         obj27.gxTpr_Prtsigla_Z = Z212PrtSigla;
         obj27.gxTpr_Prtnome_Z = Z213PrtNome;
         obj27.gxTpr_Prtativo_Z = Z214PrtAtivo;
         obj27.gxTpr_Prtdel_Z = Z614PrtDel;
         obj27.gxTpr_Prtdeldatahora_Z = Z615PrtDelDataHora;
         obj27.gxTpr_Prtdeldata_Z = Z616PrtDelData;
         obj27.gxTpr_Prtdelhora_Z = Z617PrtDelHora;
         obj27.gxTpr_Prtdelusuid_Z = Z618PrtDelUsuId;
         obj27.gxTpr_Prtdelusunome_Z = Z619PrtDelUsuNome;
         obj27.gxTpr_Prtdeldatahora_N = (short)(Convert.ToInt16(n615PrtDelDataHora));
         obj27.gxTpr_Prtdeldata_N = (short)(Convert.ToInt16(n616PrtDelData));
         obj27.gxTpr_Prtdelhora_N = (short)(Convert.ToInt16(n617PrtDelHora));
         obj27.gxTpr_Prtdelusuid_N = (short)(Convert.ToInt16(n618PrtDelUsuId));
         obj27.gxTpr_Prtdelusunome_N = (short)(Convert.ToInt16(n619PrtDelUsuNome));
         obj27.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow27( GeneXus.Programs.core.SdtProdutoTipo obj27 )
      {
         obj27.gxTpr_Prtid = A211PrtID;
         return  ;
      }

      public void RowToVars27( GeneXus.Programs.core.SdtProdutoTipo obj27 ,
                               int forceLoad )
      {
         Gx_mode = obj27.gxTpr_Mode;
         A615PrtDelDataHora = obj27.gxTpr_Prtdeldatahora;
         n615PrtDelDataHora = false;
         A616PrtDelData = obj27.gxTpr_Prtdeldata;
         n616PrtDelData = false;
         A617PrtDelHora = obj27.gxTpr_Prtdelhora;
         n617PrtDelHora = false;
         A618PrtDelUsuId = obj27.gxTpr_Prtdelusuid;
         n618PrtDelUsuId = false;
         A619PrtDelUsuNome = obj27.gxTpr_Prtdelusunome;
         n619PrtDelUsuNome = false;
         A212PrtSigla = obj27.gxTpr_Prtsigla;
         A213PrtNome = obj27.gxTpr_Prtnome;
         A614PrtDel = obj27.gxTpr_Prtdel;
         A214PrtAtivo = obj27.gxTpr_Prtativo;
         A211PrtID = obj27.gxTpr_Prtid;
         Z211PrtID = obj27.gxTpr_Prtid_Z;
         Z212PrtSigla = obj27.gxTpr_Prtsigla_Z;
         Z213PrtNome = obj27.gxTpr_Prtnome_Z;
         Z214PrtAtivo = obj27.gxTpr_Prtativo_Z;
         Z614PrtDel = obj27.gxTpr_Prtdel_Z;
         O614PrtDel = obj27.gxTpr_Prtdel_Z;
         Z615PrtDelDataHora = obj27.gxTpr_Prtdeldatahora_Z;
         Z616PrtDelData = obj27.gxTpr_Prtdeldata_Z;
         Z617PrtDelHora = obj27.gxTpr_Prtdelhora_Z;
         Z618PrtDelUsuId = obj27.gxTpr_Prtdelusuid_Z;
         Z619PrtDelUsuNome = obj27.gxTpr_Prtdelusunome_Z;
         n615PrtDelDataHora = (bool)(Convert.ToBoolean(obj27.gxTpr_Prtdeldatahora_N));
         n616PrtDelData = (bool)(Convert.ToBoolean(obj27.gxTpr_Prtdeldata_N));
         n617PrtDelHora = (bool)(Convert.ToBoolean(obj27.gxTpr_Prtdelhora_N));
         n618PrtDelUsuId = (bool)(Convert.ToBoolean(obj27.gxTpr_Prtdelusuid_N));
         n619PrtDelUsuNome = (bool)(Convert.ToBoolean(obj27.gxTpr_Prtdelusunome_N));
         Gx_mode = obj27.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A211PrtID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0R27( ) ;
         ScanKeyStart0R27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z211PrtID = A211PrtID;
            O614PrtDel = A614PrtDel;
         }
         ZM0R27( -11) ;
         OnLoadActions0R27( ) ;
         AddRow0R27( ) ;
         ScanKeyEnd0R27( ) ;
         if ( RcdFound27 == 0 )
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
         RowToVars27( bccore_ProdutoTipo, 0) ;
         ScanKeyStart0R27( ) ;
         if ( RcdFound27 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z211PrtID = A211PrtID;
            O614PrtDel = A614PrtDel;
         }
         ZM0R27( -11) ;
         OnLoadActions0R27( ) ;
         AddRow0R27( ) ;
         ScanKeyEnd0R27( ) ;
         if ( RcdFound27 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0R27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0R27( ) ;
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A211PrtID != Z211PrtID )
               {
                  A211PrtID = Z211PrtID;
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
                  Update0R27( ) ;
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
                  if ( A211PrtID != Z211PrtID )
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
                        Insert0R27( ) ;
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
                        Insert0R27( ) ;
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
         RowToVars27( bccore_ProdutoTipo, 1) ;
         SaveImpl( ) ;
         VarsToRow27( bccore_ProdutoTipo) ;
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
         RowToVars27( bccore_ProdutoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R27( ) ;
         AfterTrn( ) ;
         VarsToRow27( bccore_ProdutoTipo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow27( bccore_ProdutoTipo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtProdutoTipo auxBC = new GeneXus.Programs.core.SdtProdutoTipo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A211PrtID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_ProdutoTipo);
               auxBC.Save();
               bccore_ProdutoTipo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars27( bccore_ProdutoTipo, 1) ;
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
         RowToVars27( bccore_ProdutoTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0R27( ) ;
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
               VarsToRow27( bccore_ProdutoTipo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow27( bccore_ProdutoTipo) ;
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
         RowToVars27( bccore_ProdutoTipo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0R27( ) ;
         if ( RcdFound27 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A211PrtID != Z211PrtID )
            {
               A211PrtID = Z211PrtID;
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
            if ( A211PrtID != Z211PrtID )
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
         context.RollbackDataStores("core.produtotipo_bc",pr_default);
         VarsToRow27( bccore_ProdutoTipo) ;
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
         Gx_mode = bccore_ProdutoTipo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_ProdutoTipo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_ProdutoTipo )
         {
            bccore_ProdutoTipo = (GeneXus.Programs.core.SdtProdutoTipo)(sdt);
            if ( StringUtil.StrCmp(bccore_ProdutoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ProdutoTipo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow27( bccore_ProdutoTipo) ;
            }
            else
            {
               RowToVars27( bccore_ProdutoTipo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_ProdutoTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ProdutoTipo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars27( bccore_ProdutoTipo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProdutoTipo ProdutoTipo_BC
      {
         get {
            return bccore_ProdutoTipo ;
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
            return "produtotipo_Execute" ;
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
         Z615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         Z616PrtDelData = (DateTime)(DateTime.MinValue);
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         Z617PrtDelHora = (DateTime)(DateTime.MinValue);
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         Z618PrtDelUsuId = "";
         A618PrtDelUsuId = "";
         Z619PrtDelUsuNome = "";
         A619PrtDelUsuNome = "";
         Z212PrtSigla = "";
         A212PrtSigla = "";
         Z213PrtNome = "";
         A213PrtNome = "";
         BC000R4_A211PrtID = new int[1] ;
         BC000R4_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000R4_n615PrtDelDataHora = new bool[] {false} ;
         BC000R4_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000R4_n616PrtDelData = new bool[] {false} ;
         BC000R4_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000R4_n617PrtDelHora = new bool[] {false} ;
         BC000R4_A618PrtDelUsuId = new string[] {""} ;
         BC000R4_n618PrtDelUsuId = new bool[] {false} ;
         BC000R4_A619PrtDelUsuNome = new string[] {""} ;
         BC000R4_n619PrtDelUsuNome = new bool[] {false} ;
         BC000R4_A212PrtSigla = new string[] {""} ;
         BC000R4_A213PrtNome = new string[] {""} ;
         BC000R4_A214PrtAtivo = new bool[] {false} ;
         BC000R4_A614PrtDel = new bool[] {false} ;
         BC000R5_A211PrtID = new int[1] ;
         BC000R3_A211PrtID = new int[1] ;
         BC000R3_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000R3_n615PrtDelDataHora = new bool[] {false} ;
         BC000R3_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000R3_n616PrtDelData = new bool[] {false} ;
         BC000R3_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000R3_n617PrtDelHora = new bool[] {false} ;
         BC000R3_A618PrtDelUsuId = new string[] {""} ;
         BC000R3_n618PrtDelUsuId = new bool[] {false} ;
         BC000R3_A619PrtDelUsuNome = new string[] {""} ;
         BC000R3_n619PrtDelUsuNome = new bool[] {false} ;
         BC000R3_A212PrtSigla = new string[] {""} ;
         BC000R3_A213PrtNome = new string[] {""} ;
         BC000R3_A214PrtAtivo = new bool[] {false} ;
         BC000R3_A614PrtDel = new bool[] {false} ;
         sMode27 = "";
         BC000R2_A211PrtID = new int[1] ;
         BC000R2_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000R2_n615PrtDelDataHora = new bool[] {false} ;
         BC000R2_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000R2_n616PrtDelData = new bool[] {false} ;
         BC000R2_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000R2_n617PrtDelHora = new bool[] {false} ;
         BC000R2_A618PrtDelUsuId = new string[] {""} ;
         BC000R2_n618PrtDelUsuId = new bool[] {false} ;
         BC000R2_A619PrtDelUsuNome = new string[] {""} ;
         BC000R2_n619PrtDelUsuNome = new bool[] {false} ;
         BC000R2_A212PrtSigla = new string[] {""} ;
         BC000R2_A213PrtNome = new string[] {""} ;
         BC000R2_A214PrtAtivo = new bool[] {false} ;
         BC000R2_A614PrtDel = new bool[] {false} ;
         BC000R7_A211PrtID = new int[1] ;
         BC000R10_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000R11_A211PrtID = new int[1] ;
         BC000R11_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000R11_n615PrtDelDataHora = new bool[] {false} ;
         BC000R11_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000R11_n616PrtDelData = new bool[] {false} ;
         BC000R11_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000R11_n617PrtDelHora = new bool[] {false} ;
         BC000R11_A618PrtDelUsuId = new string[] {""} ;
         BC000R11_n618PrtDelUsuId = new bool[] {false} ;
         BC000R11_A619PrtDelUsuNome = new string[] {""} ;
         BC000R11_n619PrtDelUsuNome = new bool[] {false} ;
         BC000R11_A212PrtSigla = new string[] {""} ;
         BC000R11_A213PrtNome = new string[] {""} ;
         BC000R11_A214PrtAtivo = new bool[] {false} ;
         BC000R11_A614PrtDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000R2_A211PrtID, BC000R2_A615PrtDelDataHora, BC000R2_n615PrtDelDataHora, BC000R2_A616PrtDelData, BC000R2_n616PrtDelData, BC000R2_A617PrtDelHora, BC000R2_n617PrtDelHora, BC000R2_A618PrtDelUsuId, BC000R2_n618PrtDelUsuId, BC000R2_A619PrtDelUsuNome,
               BC000R2_n619PrtDelUsuNome, BC000R2_A212PrtSigla, BC000R2_A213PrtNome, BC000R2_A214PrtAtivo, BC000R2_A614PrtDel
               }
               , new Object[] {
               BC000R3_A211PrtID, BC000R3_A615PrtDelDataHora, BC000R3_n615PrtDelDataHora, BC000R3_A616PrtDelData, BC000R3_n616PrtDelData, BC000R3_A617PrtDelHora, BC000R3_n617PrtDelHora, BC000R3_A618PrtDelUsuId, BC000R3_n618PrtDelUsuId, BC000R3_A619PrtDelUsuNome,
               BC000R3_n619PrtDelUsuNome, BC000R3_A212PrtSigla, BC000R3_A213PrtNome, BC000R3_A214PrtAtivo, BC000R3_A614PrtDel
               }
               , new Object[] {
               BC000R4_A211PrtID, BC000R4_A615PrtDelDataHora, BC000R4_n615PrtDelDataHora, BC000R4_A616PrtDelData, BC000R4_n616PrtDelData, BC000R4_A617PrtDelHora, BC000R4_n617PrtDelHora, BC000R4_A618PrtDelUsuId, BC000R4_n618PrtDelUsuId, BC000R4_A619PrtDelUsuNome,
               BC000R4_n619PrtDelUsuNome, BC000R4_A212PrtSigla, BC000R4_A213PrtNome, BC000R4_A214PrtAtivo, BC000R4_A614PrtDel
               }
               , new Object[] {
               BC000R5_A211PrtID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000R7_A211PrtID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000R10_A220PrdID
               }
               , new Object[] {
               BC000R11_A211PrtID, BC000R11_A615PrtDelDataHora, BC000R11_n615PrtDelDataHora, BC000R11_A616PrtDelData, BC000R11_n616PrtDelData, BC000R11_A617PrtDelHora, BC000R11_n617PrtDelHora, BC000R11_A618PrtDelUsuId, BC000R11_n618PrtDelUsuId, BC000R11_A619PrtDelUsuNome,
               BC000R11_n619PrtDelUsuNome, BC000R11_A212PrtSigla, BC000R11_A213PrtNome, BC000R11_A214PrtAtivo, BC000R11_A614PrtDel
               }
            }
         );
         Z214PrtAtivo = true;
         A214PrtAtivo = true;
         i214PrtAtivo = true;
         AV14Pgmname = "core.ProdutoTipo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120R2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound27 ;
      private short nIsDirty_27 ;
      private int trnEnded ;
      private int Z211PrtID ;
      private int A211PrtID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z618PrtDelUsuId ;
      private string A618PrtDelUsuId ;
      private string sMode27 ;
      private DateTime Z615PrtDelDataHora ;
      private DateTime A615PrtDelDataHora ;
      private DateTime Z616PrtDelData ;
      private DateTime A616PrtDelData ;
      private DateTime Z617PrtDelHora ;
      private DateTime A617PrtDelHora ;
      private bool returnInSub ;
      private bool Z214PrtAtivo ;
      private bool A214PrtAtivo ;
      private bool Z614PrtDel ;
      private bool A614PrtDel ;
      private bool n615PrtDelDataHora ;
      private bool n616PrtDelData ;
      private bool n617PrtDelHora ;
      private bool n618PrtDelUsuId ;
      private bool n619PrtDelUsuNome ;
      private bool O614PrtDel ;
      private bool Gx_longc ;
      private bool i214PrtAtivo ;
      private bool mustCommit ;
      private string Z619PrtDelUsuNome ;
      private string A619PrtDelUsuNome ;
      private string Z212PrtSigla ;
      private string A212PrtSigla ;
      private string Z213PrtNome ;
      private string A213PrtNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtProdutoTipo bccore_ProdutoTipo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000R4_A211PrtID ;
      private DateTime[] BC000R4_A615PrtDelDataHora ;
      private bool[] BC000R4_n615PrtDelDataHora ;
      private DateTime[] BC000R4_A616PrtDelData ;
      private bool[] BC000R4_n616PrtDelData ;
      private DateTime[] BC000R4_A617PrtDelHora ;
      private bool[] BC000R4_n617PrtDelHora ;
      private string[] BC000R4_A618PrtDelUsuId ;
      private bool[] BC000R4_n618PrtDelUsuId ;
      private string[] BC000R4_A619PrtDelUsuNome ;
      private bool[] BC000R4_n619PrtDelUsuNome ;
      private string[] BC000R4_A212PrtSigla ;
      private string[] BC000R4_A213PrtNome ;
      private bool[] BC000R4_A214PrtAtivo ;
      private bool[] BC000R4_A614PrtDel ;
      private int[] BC000R5_A211PrtID ;
      private int[] BC000R3_A211PrtID ;
      private DateTime[] BC000R3_A615PrtDelDataHora ;
      private bool[] BC000R3_n615PrtDelDataHora ;
      private DateTime[] BC000R3_A616PrtDelData ;
      private bool[] BC000R3_n616PrtDelData ;
      private DateTime[] BC000R3_A617PrtDelHora ;
      private bool[] BC000R3_n617PrtDelHora ;
      private string[] BC000R3_A618PrtDelUsuId ;
      private bool[] BC000R3_n618PrtDelUsuId ;
      private string[] BC000R3_A619PrtDelUsuNome ;
      private bool[] BC000R3_n619PrtDelUsuNome ;
      private string[] BC000R3_A212PrtSigla ;
      private string[] BC000R3_A213PrtNome ;
      private bool[] BC000R3_A214PrtAtivo ;
      private bool[] BC000R3_A614PrtDel ;
      private int[] BC000R2_A211PrtID ;
      private DateTime[] BC000R2_A615PrtDelDataHora ;
      private bool[] BC000R2_n615PrtDelDataHora ;
      private DateTime[] BC000R2_A616PrtDelData ;
      private bool[] BC000R2_n616PrtDelData ;
      private DateTime[] BC000R2_A617PrtDelHora ;
      private bool[] BC000R2_n617PrtDelHora ;
      private string[] BC000R2_A618PrtDelUsuId ;
      private bool[] BC000R2_n618PrtDelUsuId ;
      private string[] BC000R2_A619PrtDelUsuNome ;
      private bool[] BC000R2_n619PrtDelUsuNome ;
      private string[] BC000R2_A212PrtSigla ;
      private string[] BC000R2_A213PrtNome ;
      private bool[] BC000R2_A214PrtAtivo ;
      private bool[] BC000R2_A614PrtDel ;
      private int[] BC000R7_A211PrtID ;
      private Guid[] BC000R10_A220PrdID ;
      private int[] BC000R11_A211PrtID ;
      private DateTime[] BC000R11_A615PrtDelDataHora ;
      private bool[] BC000R11_n615PrtDelDataHora ;
      private DateTime[] BC000R11_A616PrtDelData ;
      private bool[] BC000R11_n616PrtDelData ;
      private DateTime[] BC000R11_A617PrtDelHora ;
      private bool[] BC000R11_n617PrtDelHora ;
      private string[] BC000R11_A618PrtDelUsuId ;
      private bool[] BC000R11_n618PrtDelUsuId ;
      private string[] BC000R11_A619PrtDelUsuNome ;
      private bool[] BC000R11_n619PrtDelUsuNome ;
      private string[] BC000R11_A212PrtSigla ;
      private string[] BC000R11_A213PrtNome ;
      private bool[] BC000R11_A214PrtAtivo ;
      private bool[] BC000R11_A614PrtDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class produtotipo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class produtotipo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000R4;
        prmBC000R4 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R5;
        prmBC000R5 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R3;
        prmBC000R3 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R2;
        prmBC000R2 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R6;
        prmBC000R6 = new Object[] {
        new ParDef("PrtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrtSigla",GXType.VarChar,20,0) ,
        new ParDef("PrtNome",GXType.VarChar,80,0) ,
        new ParDef("PrtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrtDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000R7;
        prmBC000R7 = new Object[] {
        };
        Object[] prmBC000R8;
        prmBC000R8 = new Object[] {
        new ParDef("PrtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrtSigla",GXType.VarChar,20,0) ,
        new ParDef("PrtNome",GXType.VarChar,80,0) ,
        new ParDef("PrtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrtDel",GXType.Boolean,4,0) ,
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R9;
        prmBC000R9 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R10;
        prmBC000R10 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmBC000R11;
        prmBC000R11 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000R2", "SELECT PrtID, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel FROM tb_produtotipo WHERE PrtID = :PrtID  FOR UPDATE OF tb_produtotipo",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000R3", "SELECT PrtID, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel FROM tb_produtotipo WHERE PrtID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000R4", "SELECT TM1.PrtID, TM1.PrtDelDataHora, TM1.PrtDelData, TM1.PrtDelHora, TM1.PrtDelUsuId, TM1.PrtDelUsuNome, TM1.PrtSigla, TM1.PrtNome, TM1.PrtAtivo, TM1.PrtDel FROM tb_produtotipo TM1 WHERE TM1.PrtID = :PrtID ORDER BY TM1.PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000R5", "SELECT PrtID FROM tb_produtotipo WHERE PrtID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000R6", "SAVEPOINT gxupdate;INSERT INTO tb_produtotipo(PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel) VALUES(:PrtDelDataHora, :PrtDelData, :PrtDelHora, :PrtDelUsuId, :PrtDelUsuNome, :PrtSigla, :PrtNome, :PrtAtivo, :PrtDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000R6)
           ,new CursorDef("BC000R7", "SELECT currval('PrtID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000R8", "SAVEPOINT gxupdate;UPDATE tb_produtotipo SET PrtDelDataHora=:PrtDelDataHora, PrtDelData=:PrtDelData, PrtDelHora=:PrtDelHora, PrtDelUsuId=:PrtDelUsuId, PrtDelUsuNome=:PrtDelUsuNome, PrtSigla=:PrtSigla, PrtNome=:PrtNome, PrtAtivo=:PrtAtivo, PrtDel=:PrtDel  WHERE PrtID = :PrtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R8)
           ,new CursorDef("BC000R9", "SAVEPOINT gxupdate;DELETE FROM tb_produtotipo  WHERE PrtID = :PrtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000R9)
           ,new CursorDef("BC000R10", "SELECT PrdID FROM tb_produto WHERE PrdTipoID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000R11", "SELECT TM1.PrtID, TM1.PrtDelDataHora, TM1.PrtDelData, TM1.PrtDelHora, TM1.PrtDelUsuId, TM1.PrtDelUsuNome, TM1.PrtSigla, TM1.PrtNome, TM1.PrtAtivo, TM1.PrtDel FROM tb_produtotipo TM1 WHERE TM1.PrtID = :PrtID ORDER BY TM1.PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000R11,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
