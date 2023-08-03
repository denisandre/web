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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webclient_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webclient_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webclient_bc( IGxContext context )
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
         ReadRow0B11( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0B11( ) ;
         standaloneModal( ) ;
         AddRow0B11( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z90WWPWebClientId = A90WWPWebClientId;
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

      protected void CONFIRM_0B0( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0B11( ) ;
            }
            else
            {
               CheckExtendedTable0B11( ) ;
               if ( AnyError == 0 )
               {
                  ZM0B11( 5) ;
               }
               CloseExtendedTableCursors0B11( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0B11( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z91WWPWebClientBrowserId = A91WWPWebClientBrowserId;
            Z93WWPWebClientFirstRegistered = A93WWPWebClientFirstRegistered;
            Z94WWPWebClientLastRegistered = A94WWPWebClientLastRegistered;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z90WWPWebClientId = A90WWPWebClientId;
            Z91WWPWebClientBrowserId = A91WWPWebClientBrowserId;
            Z92WWPWebClientBrowserVersion = A92WWPWebClientBrowserVersion;
            Z93WWPWebClientFirstRegistered = A93WWPWebClientFirstRegistered;
            Z94WWPWebClientLastRegistered = A94WWPWebClientLastRegistered;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A93WWPWebClientFirstRegistered) && ( Gx_BScreen == 0 ) )
         {
            A93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A94WWPWebClientLastRegistered) && ( Gx_BScreen == 0 ) )
         {
            A94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load0B11( )
      {
         /* Using cursor BC000B5 */
         pr_default.execute(3, new Object[] {A90WWPWebClientId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound11 = 1;
            A91WWPWebClientBrowserId = BC000B5_A91WWPWebClientBrowserId[0];
            A92WWPWebClientBrowserVersion = BC000B5_A92WWPWebClientBrowserVersion[0];
            A93WWPWebClientFirstRegistered = BC000B5_A93WWPWebClientFirstRegistered[0];
            A94WWPWebClientLastRegistered = BC000B5_A94WWPWebClientLastRegistered[0];
            A49WWPUserExtendedId = BC000B5_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000B5_n49WWPUserExtendedId[0];
            ZM0B11( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0B11( ) ;
      }

      protected void OnLoadActions0B11( )
      {
      }

      protected void CheckExtendedTable0B11( )
      {
         nIsDirty_11 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A91WWPWebClientBrowserId == 0 ) || ( A91WWPWebClientBrowserId == 1 ) || ( A91WWPWebClientBrowserId == 2 ) || ( A91WWPWebClientBrowserId == 3 ) || ( A91WWPWebClientBrowserId == 5 ) || ( A91WWPWebClientBrowserId == 6 ) || ( A91WWPWebClientBrowserId == 7 ) || ( A91WWPWebClientBrowserId == 8 ) || ( A91WWPWebClientBrowserId == 9 ) ) )
         {
            GX_msglist.addItem("Campo Web Client Browser Id fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000B4 */
         pr_default.execute(2, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0B11( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0B11( )
      {
         /* Using cursor BC000B6 */
         pr_default.execute(4, new Object[] {A90WWPWebClientId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound11 = 1;
         }
         else
         {
            RcdFound11 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000B3 */
         pr_default.execute(1, new Object[] {A90WWPWebClientId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0B11( 4) ;
            RcdFound11 = 1;
            A90WWPWebClientId = BC000B3_A90WWPWebClientId[0];
            A91WWPWebClientBrowserId = BC000B3_A91WWPWebClientBrowserId[0];
            A92WWPWebClientBrowserVersion = BC000B3_A92WWPWebClientBrowserVersion[0];
            A93WWPWebClientFirstRegistered = BC000B3_A93WWPWebClientFirstRegistered[0];
            A94WWPWebClientLastRegistered = BC000B3_A94WWPWebClientLastRegistered[0];
            A49WWPUserExtendedId = BC000B3_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000B3_n49WWPUserExtendedId[0];
            Z90WWPWebClientId = A90WWPWebClientId;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0B11( ) ;
            if ( AnyError == 1 )
            {
               RcdFound11 = 0;
               InitializeNonKey0B11( ) ;
            }
            Gx_mode = sMode11;
         }
         else
         {
            RcdFound11 = 0;
            InitializeNonKey0B11( ) ;
            sMode11 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode11;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0B11( ) ;
         if ( RcdFound11 == 0 )
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
         CONFIRM_0B0( ) ;
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

      protected void CheckOptimisticConcurrency0B11( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000B2 */
            pr_default.execute(0, new Object[] {A90WWPWebClientId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z91WWPWebClientBrowserId != BC000B2_A91WWPWebClientBrowserId[0] ) || ( Z93WWPWebClientFirstRegistered != BC000B2_A93WWPWebClientFirstRegistered[0] ) || ( Z94WWPWebClientLastRegistered != BC000B2_A94WWPWebClientLastRegistered[0] ) || ( StringUtil.StrCmp(Z49WWPUserExtendedId, BC000B2_A49WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebClient"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0B11( 0) ;
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B7 */
                     pr_default.execute(5, new Object[] {A90WWPWebClientId, A91WWPWebClientBrowserId, A92WWPWebClientBrowserVersion, A93WWPWebClientFirstRegistered, A94WWPWebClientLastRegistered, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load0B11( ) ;
            }
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void Update0B11( )
      {
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0B11( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0B11( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000B8 */
                     pr_default.execute(6, new Object[] {A91WWPWebClientBrowserId, A92WWPWebClientBrowserVersion, A93WWPWebClientFirstRegistered, A94WWPWebClientLastRegistered, n49WWPUserExtendedId, A49WWPUserExtendedId, A90WWPWebClientId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebClient"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0B11( ) ;
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
            EndLevel0B11( ) ;
         }
         CloseExtendedTableCursors0B11( ) ;
      }

      protected void DeferredUpdate0B11( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0B11( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0B11( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0B11( ) ;
            AfterConfirm0B11( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0B11( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000B9 */
                  pr_default.execute(7, new Object[] {A90WWPWebClientId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebClient");
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
         sMode11 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0B11( ) ;
         Gx_mode = sMode11;
      }

      protected void OnDeleteControls0B11( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0B11( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0B11( ) ;
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

      public void ScanKeyStart0B11( )
      {
         /* Using cursor BC000B10 */
         pr_default.execute(8, new Object[] {A90WWPWebClientId});
         RcdFound11 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound11 = 1;
            A90WWPWebClientId = BC000B10_A90WWPWebClientId[0];
            A91WWPWebClientBrowserId = BC000B10_A91WWPWebClientBrowserId[0];
            A92WWPWebClientBrowserVersion = BC000B10_A92WWPWebClientBrowserVersion[0];
            A93WWPWebClientFirstRegistered = BC000B10_A93WWPWebClientFirstRegistered[0];
            A94WWPWebClientLastRegistered = BC000B10_A94WWPWebClientLastRegistered[0];
            A49WWPUserExtendedId = BC000B10_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000B10_n49WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0B11( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound11 = 0;
         ScanKeyLoad0B11( ) ;
      }

      protected void ScanKeyLoad0B11( )
      {
         sMode11 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound11 = 1;
            A90WWPWebClientId = BC000B10_A90WWPWebClientId[0];
            A91WWPWebClientBrowserId = BC000B10_A91WWPWebClientBrowserId[0];
            A92WWPWebClientBrowserVersion = BC000B10_A92WWPWebClientBrowserVersion[0];
            A93WWPWebClientFirstRegistered = BC000B10_A93WWPWebClientFirstRegistered[0];
            A94WWPWebClientLastRegistered = BC000B10_A94WWPWebClientLastRegistered[0];
            A49WWPUserExtendedId = BC000B10_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000B10_n49WWPUserExtendedId[0];
         }
         Gx_mode = sMode11;
      }

      protected void ScanKeyEnd0B11( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm0B11( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0B11( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0B11( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0B11( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0B11( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0B11( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0B11( )
      {
      }

      protected void send_integrity_lvl_hashes0B11( )
      {
      }

      protected void AddRow0B11( )
      {
         VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
      }

      protected void ReadRow0B11( )
      {
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
      }

      protected void InitializeNonKey0B11( )
      {
         A91WWPWebClientBrowserId = 0;
         A92WWPWebClientBrowserVersion = "";
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         A93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z91WWPWebClientBrowserId = 0;
         Z93WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z94WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z49WWPUserExtendedId = "";
      }

      protected void InitAll0B11( )
      {
         A90WWPWebClientId = "";
         InitializeNonKey0B11( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A93WWPWebClientFirstRegistered = i93WWPWebClientFirstRegistered;
         A94WWPWebClientLastRegistered = i94WWPWebClientLastRegistered;
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

      public void VarsToRow11( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj11 )
      {
         obj11.gxTpr_Mode = Gx_mode;
         obj11.gxTpr_Wwpwebclientbrowserid = A91WWPWebClientBrowserId;
         obj11.gxTpr_Wwpwebclientbrowserversion = A92WWPWebClientBrowserVersion;
         obj11.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         obj11.gxTpr_Wwpwebclientfirstregistered = A93WWPWebClientFirstRegistered;
         obj11.gxTpr_Wwpwebclientlastregistered = A94WWPWebClientLastRegistered;
         obj11.gxTpr_Wwpwebclientid = A90WWPWebClientId;
         obj11.gxTpr_Wwpwebclientid_Z = Z90WWPWebClientId;
         obj11.gxTpr_Wwpwebclientbrowserid_Z = Z91WWPWebClientBrowserId;
         obj11.gxTpr_Wwpwebclientfirstregistered_Z = Z93WWPWebClientFirstRegistered;
         obj11.gxTpr_Wwpwebclientlastregistered_Z = Z94WWPWebClientLastRegistered;
         obj11.gxTpr_Wwpuserextendedid_Z = Z49WWPUserExtendedId;
         obj11.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n49WWPUserExtendedId));
         obj11.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow11( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj11 )
      {
         obj11.gxTpr_Wwpwebclientid = A90WWPWebClientId;
         return  ;
      }

      public void RowToVars11( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient obj11 ,
                               int forceLoad )
      {
         Gx_mode = obj11.gxTpr_Mode;
         A91WWPWebClientBrowserId = obj11.gxTpr_Wwpwebclientbrowserid;
         A92WWPWebClientBrowserVersion = obj11.gxTpr_Wwpwebclientbrowserversion;
         A49WWPUserExtendedId = obj11.gxTpr_Wwpuserextendedid;
         n49WWPUserExtendedId = false;
         A93WWPWebClientFirstRegistered = obj11.gxTpr_Wwpwebclientfirstregistered;
         A94WWPWebClientLastRegistered = obj11.gxTpr_Wwpwebclientlastregistered;
         A90WWPWebClientId = obj11.gxTpr_Wwpwebclientid;
         Z90WWPWebClientId = obj11.gxTpr_Wwpwebclientid_Z;
         Z91WWPWebClientBrowserId = obj11.gxTpr_Wwpwebclientbrowserid_Z;
         Z93WWPWebClientFirstRegistered = obj11.gxTpr_Wwpwebclientfirstregistered_Z;
         Z94WWPWebClientLastRegistered = obj11.gxTpr_Wwpwebclientlastregistered_Z;
         Z49WWPUserExtendedId = obj11.gxTpr_Wwpuserextendedid_Z;
         n49WWPUserExtendedId = (bool)(Convert.ToBoolean(obj11.gxTpr_Wwpuserextendedid_N));
         Gx_mode = obj11.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A90WWPWebClientId = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0B11( ) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z90WWPWebClientId = A90WWPWebClientId;
         }
         ZM0B11( -4) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         ScanKeyStart0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z90WWPWebClientId = A90WWPWebClientId;
         }
         ZM0B11( -4) ;
         OnLoadActions0B11( ) ;
         AddRow0B11( ) ;
         ScanKeyEnd0B11( ) ;
         if ( RcdFound11 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0B11( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0B11( ) ;
         }
         else
         {
            if ( RcdFound11 == 1 )
            {
               if ( StringUtil.StrCmp(A90WWPWebClientId, Z90WWPWebClientId) != 0 )
               {
                  A90WWPWebClientId = Z90WWPWebClientId;
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
                  Update0B11( ) ;
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
                  if ( StringUtil.StrCmp(A90WWPWebClientId, Z90WWPWebClientId) != 0 )
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
                        Insert0B11( ) ;
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
                        Insert0B11( ) ;
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         SaveImpl( ) ;
         VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
         AfterTrn( ) ;
         VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A90WWPWebClientId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebClient);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebClient.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0B11( ) ;
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
               VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0B11( ) ;
         if ( RcdFound11 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A90WWPWebClientId, Z90WWPWebClientId) != 0 )
            {
               A90WWPWebClientId = Z90WWPWebClientId;
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
            if ( StringUtil.StrCmp(A90WWPWebClientId, Z90WWPWebClientId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webclient_bc",pr_default);
         VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebClient )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebClient = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow11( bcwwpbaseobjects_notifications_web_WWP_WebClient) ;
            }
            else
            {
               RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebClient.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars11( bcwwpbaseobjects_notifications_web_WWP_WebClient, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_WebClient WWP_WebClient_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebClient ;
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
            return "webclient_Execute" ;
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
         Z90WWPWebClientId = "";
         A90WWPWebClientId = "";
         Z93WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         A93WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         Z94WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         A94WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         Z49WWPUserExtendedId = "";
         A49WWPUserExtendedId = "";
         Z92WWPWebClientBrowserVersion = "";
         A92WWPWebClientBrowserVersion = "";
         BC000B5_A90WWPWebClientId = new string[] {""} ;
         BC000B5_A91WWPWebClientBrowserId = new short[1] ;
         BC000B5_A92WWPWebClientBrowserVersion = new string[] {""} ;
         BC000B5_A93WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B5_A94WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B5_A49WWPUserExtendedId = new string[] {""} ;
         BC000B5_n49WWPUserExtendedId = new bool[] {false} ;
         BC000B4_A49WWPUserExtendedId = new string[] {""} ;
         BC000B4_n49WWPUserExtendedId = new bool[] {false} ;
         BC000B6_A90WWPWebClientId = new string[] {""} ;
         BC000B3_A90WWPWebClientId = new string[] {""} ;
         BC000B3_A91WWPWebClientBrowserId = new short[1] ;
         BC000B3_A92WWPWebClientBrowserVersion = new string[] {""} ;
         BC000B3_A93WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A94WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B3_A49WWPUserExtendedId = new string[] {""} ;
         BC000B3_n49WWPUserExtendedId = new bool[] {false} ;
         sMode11 = "";
         BC000B2_A90WWPWebClientId = new string[] {""} ;
         BC000B2_A91WWPWebClientBrowserId = new short[1] ;
         BC000B2_A92WWPWebClientBrowserVersion = new string[] {""} ;
         BC000B2_A93WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A94WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B2_A49WWPUserExtendedId = new string[] {""} ;
         BC000B2_n49WWPUserExtendedId = new bool[] {false} ;
         BC000B10_A90WWPWebClientId = new string[] {""} ;
         BC000B10_A91WWPWebClientBrowserId = new short[1] ;
         BC000B10_A92WWPWebClientBrowserVersion = new string[] {""} ;
         BC000B10_A93WWPWebClientFirstRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B10_A94WWPWebClientLastRegistered = new DateTime[] {DateTime.MinValue} ;
         BC000B10_A49WWPUserExtendedId = new string[] {""} ;
         BC000B10_n49WWPUserExtendedId = new bool[] {false} ;
         i93WWPWebClientFirstRegistered = (DateTime)(DateTime.MinValue);
         i94WWPWebClientLastRegistered = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webclient_bc__default(),
            new Object[][] {
                new Object[] {
               BC000B2_A90WWPWebClientId, BC000B2_A91WWPWebClientBrowserId, BC000B2_A92WWPWebClientBrowserVersion, BC000B2_A93WWPWebClientFirstRegistered, BC000B2_A94WWPWebClientLastRegistered, BC000B2_A49WWPUserExtendedId, BC000B2_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000B3_A90WWPWebClientId, BC000B3_A91WWPWebClientBrowserId, BC000B3_A92WWPWebClientBrowserVersion, BC000B3_A93WWPWebClientFirstRegistered, BC000B3_A94WWPWebClientLastRegistered, BC000B3_A49WWPUserExtendedId, BC000B3_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000B4_A49WWPUserExtendedId
               }
               , new Object[] {
               BC000B5_A90WWPWebClientId, BC000B5_A91WWPWebClientBrowserId, BC000B5_A92WWPWebClientBrowserVersion, BC000B5_A93WWPWebClientFirstRegistered, BC000B5_A94WWPWebClientLastRegistered, BC000B5_A49WWPUserExtendedId, BC000B5_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000B6_A90WWPWebClientId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000B10_A90WWPWebClientId, BC000B10_A91WWPWebClientBrowserId, BC000B10_A92WWPWebClientBrowserVersion, BC000B10_A93WWPWebClientFirstRegistered, BC000B10_A94WWPWebClientLastRegistered, BC000B10_A49WWPUserExtendedId, BC000B10_n49WWPUserExtendedId
               }
            }
         );
         Z94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i94WWPWebClientLastRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         Z93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         A93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         i93WWPWebClientFirstRegistered = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z91WWPWebClientBrowserId ;
      private short A91WWPWebClientBrowserId ;
      private short Gx_BScreen ;
      private short RcdFound11 ;
      private short nIsDirty_11 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z90WWPWebClientId ;
      private string A90WWPWebClientId ;
      private string Z49WWPUserExtendedId ;
      private string A49WWPUserExtendedId ;
      private string sMode11 ;
      private DateTime Z93WWPWebClientFirstRegistered ;
      private DateTime A93WWPWebClientFirstRegistered ;
      private DateTime Z94WWPWebClientLastRegistered ;
      private DateTime A94WWPWebClientLastRegistered ;
      private DateTime i93WWPWebClientFirstRegistered ;
      private DateTime i94WWPWebClientLastRegistered ;
      private bool n49WWPUserExtendedId ;
      private bool mustCommit ;
      private string Z92WWPWebClientBrowserVersion ;
      private string A92WWPWebClientBrowserVersion ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebClient bcwwpbaseobjects_notifications_web_WWP_WebClient ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000B5_A90WWPWebClientId ;
      private short[] BC000B5_A91WWPWebClientBrowserId ;
      private string[] BC000B5_A92WWPWebClientBrowserVersion ;
      private DateTime[] BC000B5_A93WWPWebClientFirstRegistered ;
      private DateTime[] BC000B5_A94WWPWebClientLastRegistered ;
      private string[] BC000B5_A49WWPUserExtendedId ;
      private bool[] BC000B5_n49WWPUserExtendedId ;
      private string[] BC000B4_A49WWPUserExtendedId ;
      private bool[] BC000B4_n49WWPUserExtendedId ;
      private string[] BC000B6_A90WWPWebClientId ;
      private string[] BC000B3_A90WWPWebClientId ;
      private short[] BC000B3_A91WWPWebClientBrowserId ;
      private string[] BC000B3_A92WWPWebClientBrowserVersion ;
      private DateTime[] BC000B3_A93WWPWebClientFirstRegistered ;
      private DateTime[] BC000B3_A94WWPWebClientLastRegistered ;
      private string[] BC000B3_A49WWPUserExtendedId ;
      private bool[] BC000B3_n49WWPUserExtendedId ;
      private string[] BC000B2_A90WWPWebClientId ;
      private short[] BC000B2_A91WWPWebClientBrowserId ;
      private string[] BC000B2_A92WWPWebClientBrowserVersion ;
      private DateTime[] BC000B2_A93WWPWebClientFirstRegistered ;
      private DateTime[] BC000B2_A94WWPWebClientLastRegistered ;
      private string[] BC000B2_A49WWPUserExtendedId ;
      private bool[] BC000B2_n49WWPUserExtendedId ;
      private string[] BC000B10_A90WWPWebClientId ;
      private short[] BC000B10_A91WWPWebClientBrowserId ;
      private string[] BC000B10_A92WWPWebClientBrowserVersion ;
      private DateTime[] BC000B10_A93WWPWebClientFirstRegistered ;
      private DateTime[] BC000B10_A94WWPWebClientLastRegistered ;
      private string[] BC000B10_A49WWPUserExtendedId ;
      private bool[] BC000B10_n49WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webclient_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webclient_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000B5;
        prmBC000B5 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B4;
        prmBC000B4 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000B6;
        prmBC000B6 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B3;
        prmBC000B3 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B2;
        prmBC000B2 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B7;
        prmBC000B7 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0) ,
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000B8;
        prmBC000B8 = new Object[] {
        new ParDef("WWPWebClientBrowserId",GXType.Int16,4,0) ,
        new ParDef("WWPWebClientBrowserVersion",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebClientFirstRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebClientLastRegistered",GXType.DateTime2,10,12) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B9;
        prmBC000B9 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        Object[] prmBC000B10;
        prmBC000B10 = new Object[] {
        new ParDef("WWPWebClientId",GXType.Char,100,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000B2", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId  FOR UPDATE OF WWP_WebClient",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B3", "SELECT WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B4", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B5", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B6", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPWebClientId = :WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000B7", "SAVEPOINT gxupdate;INSERT INTO WWP_WebClient(WWPWebClientId, WWPWebClientBrowserId, WWPWebClientBrowserVersion, WWPWebClientFirstRegistered, WWPWebClientLastRegistered, WWPUserExtendedId) VALUES(:WWPWebClientId, :WWPWebClientBrowserId, :WWPWebClientBrowserVersion, :WWPWebClientFirstRegistered, :WWPWebClientLastRegistered, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B7)
           ,new CursorDef("BC000B8", "SAVEPOINT gxupdate;UPDATE WWP_WebClient SET WWPWebClientBrowserId=:WWPWebClientBrowserId, WWPWebClientBrowserVersion=:WWPWebClientBrowserVersion, WWPWebClientFirstRegistered=:WWPWebClientFirstRegistered, WWPWebClientLastRegistered=:WWPWebClientLastRegistered, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B8)
           ,new CursorDef("BC000B9", "SAVEPOINT gxupdate;DELETE FROM WWP_WebClient  WHERE WWPWebClientId = :WWPWebClientId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000B9)
           ,new CursorDef("BC000B10", "SELECT TM1.WWPWebClientId, TM1.WWPWebClientBrowserId, TM1.WWPWebClientBrowserVersion, TM1.WWPWebClientFirstRegistered, TM1.WWPWebClientLastRegistered, TM1.WWPUserExtendedId FROM WWP_WebClient TM1 WHERE TM1.WWPWebClientId = ( :WWPWebClientId) ORDER BY TM1.WWPWebClientId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000B10,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDateTime(5, true);
              ((string[]) buf[5])[0] = rslt.getString(6, 40);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              return;
     }
  }

}

}
