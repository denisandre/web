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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification_bc( IGxContext context )
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
         ReadRow0D13( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0D13( ) ;
         standaloneModal( ) ;
         AddRow0D13( ) ;
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
               Z64WWPNotificationId = A64WWPNotificationId;
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

      protected void CONFIRM_0D0( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0D13( ) ;
            }
            else
            {
               CheckExtendedTable0D13( ) ;
               if ( AnyError == 0 )
               {
                  ZM0D13( 5) ;
                  ZM0D13( 6) ;
               }
               CloseExtendedTableCursors0D13( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
            Z118WWPNotificationIcon = A118WWPNotificationIcon;
            Z119WWPNotificationTitle = A119WWPNotificationTitle;
            Z120WWPNotificationShortDescriptio = A120WWPNotificationShortDescriptio;
            Z121WWPNotificationLink = A121WWPNotificationLink;
            Z124WWPNotificationIsRead = A124WWPNotificationIsRead;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
         if ( GX_JID == -4 )
         {
            Z64WWPNotificationId = A64WWPNotificationId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
            Z118WWPNotificationIcon = A118WWPNotificationIcon;
            Z119WWPNotificationTitle = A119WWPNotificationTitle;
            Z120WWPNotificationShortDescriptio = A120WWPNotificationShortDescriptio;
            Z121WWPNotificationLink = A121WWPNotificationLink;
            Z124WWPNotificationIsRead = A124WWPNotificationIsRead;
            Z102WWPNotificationMetadata = A102WWPNotificationMetadata;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A66WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
      }

      protected void Load0D13( )
      {
         /* Using cursor BC000D6 */
         pr_default.execute(4, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A101WWPNotificationDefinitionName = BC000D6_A101WWPNotificationDefinitionName[0];
            A66WWPNotificationCreated = BC000D6_A66WWPNotificationCreated[0];
            A118WWPNotificationIcon = BC000D6_A118WWPNotificationIcon[0];
            A119WWPNotificationTitle = BC000D6_A119WWPNotificationTitle[0];
            A120WWPNotificationShortDescriptio = BC000D6_A120WWPNotificationShortDescriptio[0];
            A121WWPNotificationLink = BC000D6_A121WWPNotificationLink[0];
            A124WWPNotificationIsRead = BC000D6_A124WWPNotificationIsRead[0];
            A50WWPUserExtendedFullName = BC000D6_A50WWPUserExtendedFullName[0];
            A102WWPNotificationMetadata = BC000D6_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000D6_n102WWPNotificationMetadata[0];
            A65WWPNotificationDefinitionId = BC000D6_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000D6_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000D6_n49WWPUserExtendedId[0];
            ZM0D13( -4) ;
         }
         pr_default.close(4);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000D4 */
         pr_default.execute(2, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A101WWPNotificationDefinitionName = BC000D4_A101WWPNotificationDefinitionName[0];
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A121WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000D5 */
         pr_default.execute(3, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A50WWPUserExtendedFullName = BC000D5_A50WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0D13( )
      {
         /* Using cursor BC000D7 */
         pr_default.execute(5, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000D3 */
         pr_default.execute(1, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 4) ;
            RcdFound13 = 1;
            A64WWPNotificationId = BC000D3_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000D3_n64WWPNotificationId[0];
            A66WWPNotificationCreated = BC000D3_A66WWPNotificationCreated[0];
            A118WWPNotificationIcon = BC000D3_A118WWPNotificationIcon[0];
            A119WWPNotificationTitle = BC000D3_A119WWPNotificationTitle[0];
            A120WWPNotificationShortDescriptio = BC000D3_A120WWPNotificationShortDescriptio[0];
            A121WWPNotificationLink = BC000D3_A121WWPNotificationLink[0];
            A124WWPNotificationIsRead = BC000D3_A124WWPNotificationIsRead[0];
            A102WWPNotificationMetadata = BC000D3_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000D3_n102WWPNotificationMetadata[0];
            A65WWPNotificationDefinitionId = BC000D3_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000D3_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000D3_n49WWPUserExtendedId[0];
            Z64WWPNotificationId = A64WWPNotificationId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode13;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
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
         CONFIRM_0D0( ) ;
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

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000D2 */
            pr_default.execute(0, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z66WWPNotificationCreated != BC000D2_A66WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z118WWPNotificationIcon, BC000D2_A118WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z119WWPNotificationTitle, BC000D2_A119WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z120WWPNotificationShortDescriptio, BC000D2_A120WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z121WWPNotificationLink, BC000D2_A121WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z124WWPNotificationIsRead != BC000D2_A124WWPNotificationIsRead[0] ) || ( Z65WWPNotificationDefinitionId != BC000D2_A65WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z49WWPUserExtendedId, BC000D2_A49WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D8 */
                     pr_default.execute(6, new Object[] {A66WWPNotificationCreated, A118WWPNotificationIcon, A119WWPNotificationTitle, A120WWPNotificationShortDescriptio, A121WWPNotificationLink, A124WWPNotificationIsRead, n102WWPNotificationMetadata, A102WWPNotificationMetadata, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000D9 */
                     pr_default.execute(7);
                     A64WWPNotificationId = BC000D9_A64WWPNotificationId[0];
                     n64WWPNotificationId = BC000D9_n64WWPNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000D10 */
                     pr_default.execute(8, new Object[] {A66WWPNotificationCreated, A118WWPNotificationIcon, A119WWPNotificationTitle, A120WWPNotificationShortDescriptio, A121WWPNotificationLink, A124WWPNotificationIsRead, n102WWPNotificationMetadata, A102WWPNotificationMetadata, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000D11 */
                  pr_default.execute(9, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000D12 */
            pr_default.execute(10, new Object[] {A65WWPNotificationDefinitionId});
            A101WWPNotificationDefinitionName = BC000D12_A101WWPNotificationDefinitionName[0];
            pr_default.close(10);
            /* Using cursor BC000D13 */
            pr_default.execute(11, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            A50WWPUserExtendedFullName = BC000D13_A50WWPUserExtendedFullName[0];
            pr_default.close(11);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000D14 */
            pr_default.execute(12, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor BC000D15 */
            pr_default.execute(13, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000D16 */
            pr_default.execute(14, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
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

      public void ScanKeyStart0D13( )
      {
         /* Using cursor BC000D17 */
         pr_default.execute(15, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         RcdFound13 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound13 = 1;
            A64WWPNotificationId = BC000D17_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000D17_n64WWPNotificationId[0];
            A101WWPNotificationDefinitionName = BC000D17_A101WWPNotificationDefinitionName[0];
            A66WWPNotificationCreated = BC000D17_A66WWPNotificationCreated[0];
            A118WWPNotificationIcon = BC000D17_A118WWPNotificationIcon[0];
            A119WWPNotificationTitle = BC000D17_A119WWPNotificationTitle[0];
            A120WWPNotificationShortDescriptio = BC000D17_A120WWPNotificationShortDescriptio[0];
            A121WWPNotificationLink = BC000D17_A121WWPNotificationLink[0];
            A124WWPNotificationIsRead = BC000D17_A124WWPNotificationIsRead[0];
            A50WWPUserExtendedFullName = BC000D17_A50WWPUserExtendedFullName[0];
            A102WWPNotificationMetadata = BC000D17_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000D17_n102WWPNotificationMetadata[0];
            A65WWPNotificationDefinitionId = BC000D17_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000D17_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000D17_n49WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound13 = 0;
         ScanKeyLoad0D13( ) ;
      }

      protected void ScanKeyLoad0D13( )
      {
         sMode13 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound13 = 1;
            A64WWPNotificationId = BC000D17_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000D17_n64WWPNotificationId[0];
            A101WWPNotificationDefinitionName = BC000D17_A101WWPNotificationDefinitionName[0];
            A66WWPNotificationCreated = BC000D17_A66WWPNotificationCreated[0];
            A118WWPNotificationIcon = BC000D17_A118WWPNotificationIcon[0];
            A119WWPNotificationTitle = BC000D17_A119WWPNotificationTitle[0];
            A120WWPNotificationShortDescriptio = BC000D17_A120WWPNotificationShortDescriptio[0];
            A121WWPNotificationLink = BC000D17_A121WWPNotificationLink[0];
            A124WWPNotificationIsRead = BC000D17_A124WWPNotificationIsRead[0];
            A50WWPUserExtendedFullName = BC000D17_A50WWPUserExtendedFullName[0];
            A102WWPNotificationMetadata = BC000D17_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000D17_n102WWPNotificationMetadata[0];
            A65WWPNotificationDefinitionId = BC000D17_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000D17_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000D17_n49WWPUserExtendedId[0];
         }
         Gx_mode = sMode13;
      }

      protected void ScanKeyEnd0D13( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0D13( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) )
         {
            A49WWPUserExtendedId = "";
            n49WWPUserExtendedId = false;
            n49WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void AddRow0D13( )
      {
         VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
      }

      protected void ReadRow0D13( )
      {
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
      }

      protected void InitializeNonKey0D13( )
      {
         A65WWPNotificationDefinitionId = 0;
         A101WWPNotificationDefinitionName = "";
         A118WWPNotificationIcon = "";
         A119WWPNotificationTitle = "";
         A120WWPNotificationShortDescriptio = "";
         A121WWPNotificationLink = "";
         A124WWPNotificationIsRead = false;
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         A50WWPUserExtendedFullName = "";
         A102WWPNotificationMetadata = "";
         n102WWPNotificationMetadata = false;
         A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z118WWPNotificationIcon = "";
         Z119WWPNotificationTitle = "";
         Z120WWPNotificationShortDescriptio = "";
         Z121WWPNotificationLink = "";
         Z124WWPNotificationIsRead = false;
         Z65WWPNotificationDefinitionId = 0;
         Z49WWPUserExtendedId = "";
      }

      protected void InitAll0D13( )
      {
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A66WWPNotificationCreated = i66WWPNotificationCreated;
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

      public void VarsToRow13( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj13 )
      {
         obj13.gxTpr_Mode = Gx_mode;
         obj13.gxTpr_Wwpnotificationdefinitionid = A65WWPNotificationDefinitionId;
         obj13.gxTpr_Wwpnotificationdefinitionname = A101WWPNotificationDefinitionName;
         obj13.gxTpr_Wwpnotificationicon = A118WWPNotificationIcon;
         obj13.gxTpr_Wwpnotificationtitle = A119WWPNotificationTitle;
         obj13.gxTpr_Wwpnotificationshortdescription = A120WWPNotificationShortDescriptio;
         obj13.gxTpr_Wwpnotificationlink = A121WWPNotificationLink;
         obj13.gxTpr_Wwpnotificationisread = A124WWPNotificationIsRead;
         obj13.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         obj13.gxTpr_Wwpuserextendedfullname = A50WWPUserExtendedFullName;
         obj13.gxTpr_Wwpnotificationmetadata = A102WWPNotificationMetadata;
         obj13.gxTpr_Wwpnotificationcreated = A66WWPNotificationCreated;
         obj13.gxTpr_Wwpnotificationid = A64WWPNotificationId;
         obj13.gxTpr_Wwpnotificationid_Z = Z64WWPNotificationId;
         obj13.gxTpr_Wwpnotificationdefinitionid_Z = Z65WWPNotificationDefinitionId;
         obj13.gxTpr_Wwpnotificationdefinitionname_Z = Z101WWPNotificationDefinitionName;
         obj13.gxTpr_Wwpnotificationcreated_Z = Z66WWPNotificationCreated;
         obj13.gxTpr_Wwpnotificationicon_Z = Z118WWPNotificationIcon;
         obj13.gxTpr_Wwpnotificationtitle_Z = Z119WWPNotificationTitle;
         obj13.gxTpr_Wwpnotificationshortdescription_Z = Z120WWPNotificationShortDescriptio;
         obj13.gxTpr_Wwpnotificationlink_Z = Z121WWPNotificationLink;
         obj13.gxTpr_Wwpnotificationisread_Z = Z124WWPNotificationIsRead;
         obj13.gxTpr_Wwpuserextendedid_Z = Z49WWPUserExtendedId;
         obj13.gxTpr_Wwpuserextendedfullname_Z = Z50WWPUserExtendedFullName;
         obj13.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n64WWPNotificationId));
         obj13.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n49WWPUserExtendedId));
         obj13.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n102WWPNotificationMetadata));
         obj13.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow13( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj13 )
      {
         obj13.gxTpr_Wwpnotificationid = A64WWPNotificationId;
         return  ;
      }

      public void RowToVars13( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification obj13 ,
                               int forceLoad )
      {
         Gx_mode = obj13.gxTpr_Mode;
         A65WWPNotificationDefinitionId = obj13.gxTpr_Wwpnotificationdefinitionid;
         A101WWPNotificationDefinitionName = obj13.gxTpr_Wwpnotificationdefinitionname;
         A118WWPNotificationIcon = obj13.gxTpr_Wwpnotificationicon;
         A119WWPNotificationTitle = obj13.gxTpr_Wwpnotificationtitle;
         A120WWPNotificationShortDescriptio = obj13.gxTpr_Wwpnotificationshortdescription;
         A121WWPNotificationLink = obj13.gxTpr_Wwpnotificationlink;
         A124WWPNotificationIsRead = obj13.gxTpr_Wwpnotificationisread;
         A49WWPUserExtendedId = obj13.gxTpr_Wwpuserextendedid;
         n49WWPUserExtendedId = false;
         A50WWPUserExtendedFullName = obj13.gxTpr_Wwpuserextendedfullname;
         A102WWPNotificationMetadata = obj13.gxTpr_Wwpnotificationmetadata;
         n102WWPNotificationMetadata = false;
         A66WWPNotificationCreated = obj13.gxTpr_Wwpnotificationcreated;
         A64WWPNotificationId = obj13.gxTpr_Wwpnotificationid;
         n64WWPNotificationId = false;
         Z64WWPNotificationId = obj13.gxTpr_Wwpnotificationid_Z;
         Z65WWPNotificationDefinitionId = obj13.gxTpr_Wwpnotificationdefinitionid_Z;
         Z101WWPNotificationDefinitionName = obj13.gxTpr_Wwpnotificationdefinitionname_Z;
         Z66WWPNotificationCreated = obj13.gxTpr_Wwpnotificationcreated_Z;
         Z118WWPNotificationIcon = obj13.gxTpr_Wwpnotificationicon_Z;
         Z119WWPNotificationTitle = obj13.gxTpr_Wwpnotificationtitle_Z;
         Z120WWPNotificationShortDescriptio = obj13.gxTpr_Wwpnotificationshortdescription_Z;
         Z121WWPNotificationLink = obj13.gxTpr_Wwpnotificationlink_Z;
         Z124WWPNotificationIsRead = obj13.gxTpr_Wwpnotificationisread_Z;
         Z49WWPUserExtendedId = obj13.gxTpr_Wwpuserextendedid_Z;
         Z50WWPUserExtendedFullName = obj13.gxTpr_Wwpuserextendedfullname_Z;
         n64WWPNotificationId = (bool)(Convert.ToBoolean(obj13.gxTpr_Wwpnotificationid_N));
         n49WWPUserExtendedId = (bool)(Convert.ToBoolean(obj13.gxTpr_Wwpuserextendedid_N));
         n102WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj13.gxTpr_Wwpnotificationmetadata_N));
         Gx_mode = obj13.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A64WWPNotificationId = (long)getParm(obj,0);
         n64WWPNotificationId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0D13( ) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z64WWPNotificationId = A64WWPNotificationId;
         }
         ZM0D13( -4) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         ScanKeyStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z64WWPNotificationId = A64WWPNotificationId;
         }
         ZM0D13( -4) ;
         OnLoadActions0D13( ) ;
         AddRow0D13( ) ;
         ScanKeyEnd0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0D13( ) ;
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A64WWPNotificationId != Z64WWPNotificationId )
               {
                  A64WWPNotificationId = Z64WWPNotificationId;
                  n64WWPNotificationId = false;
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
                  Update0D13( ) ;
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
                  if ( A64WWPNotificationId != Z64WWPNotificationId )
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
                        Insert0D13( ) ;
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
                        Insert0D13( ) ;
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         SaveImpl( ) ;
         VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
         AfterTrn( ) ;
         VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A64WWPNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_Notification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_Notification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0D13( ) ;
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
               VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0D13( ) ;
         if ( RcdFound13 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A64WWPNotificationId != Z64WWPNotificationId )
            {
               A64WWPNotificationId = Z64WWPNotificationId;
               n64WWPNotificationId = false;
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
            if ( A64WWPNotificationId != Z64WWPNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification_bc",pr_default);
         VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_Notification )
         {
            bcwwpbaseobjects_notifications_common_WWP_Notification = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow13( bcwwpbaseobjects_notifications_common_WWP_Notification) ;
            }
            else
            {
               RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_Notification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars13( bcwwpbaseobjects_notifications_common_WWP_Notification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Notification WWP_Notification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_Notification ;
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
            return "wwp_notification_Execute" ;
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
         pr_default.close(10);
         pr_default.close(11);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z118WWPNotificationIcon = "";
         A118WWPNotificationIcon = "";
         Z119WWPNotificationTitle = "";
         A119WWPNotificationTitle = "";
         Z120WWPNotificationShortDescriptio = "";
         A120WWPNotificationShortDescriptio = "";
         Z121WWPNotificationLink = "";
         A121WWPNotificationLink = "";
         Z49WWPUserExtendedId = "";
         A49WWPUserExtendedId = "";
         Z101WWPNotificationDefinitionName = "";
         A101WWPNotificationDefinitionName = "";
         Z50WWPUserExtendedFullName = "";
         A50WWPUserExtendedFullName = "";
         Z102WWPNotificationMetadata = "";
         A102WWPNotificationMetadata = "";
         BC000D6_A64WWPNotificationId = new long[1] ;
         BC000D6_n64WWPNotificationId = new bool[] {false} ;
         BC000D6_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000D6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000D6_A118WWPNotificationIcon = new string[] {""} ;
         BC000D6_A119WWPNotificationTitle = new string[] {""} ;
         BC000D6_A120WWPNotificationShortDescriptio = new string[] {""} ;
         BC000D6_A121WWPNotificationLink = new string[] {""} ;
         BC000D6_A124WWPNotificationIsRead = new bool[] {false} ;
         BC000D6_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000D6_A102WWPNotificationMetadata = new string[] {""} ;
         BC000D6_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000D6_A65WWPNotificationDefinitionId = new long[1] ;
         BC000D6_A49WWPUserExtendedId = new string[] {""} ;
         BC000D6_n49WWPUserExtendedId = new bool[] {false} ;
         BC000D4_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000D5_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000D7_A64WWPNotificationId = new long[1] ;
         BC000D7_n64WWPNotificationId = new bool[] {false} ;
         BC000D3_A64WWPNotificationId = new long[1] ;
         BC000D3_n64WWPNotificationId = new bool[] {false} ;
         BC000D3_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000D3_A118WWPNotificationIcon = new string[] {""} ;
         BC000D3_A119WWPNotificationTitle = new string[] {""} ;
         BC000D3_A120WWPNotificationShortDescriptio = new string[] {""} ;
         BC000D3_A121WWPNotificationLink = new string[] {""} ;
         BC000D3_A124WWPNotificationIsRead = new bool[] {false} ;
         BC000D3_A102WWPNotificationMetadata = new string[] {""} ;
         BC000D3_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000D3_A65WWPNotificationDefinitionId = new long[1] ;
         BC000D3_A49WWPUserExtendedId = new string[] {""} ;
         BC000D3_n49WWPUserExtendedId = new bool[] {false} ;
         sMode13 = "";
         BC000D2_A64WWPNotificationId = new long[1] ;
         BC000D2_n64WWPNotificationId = new bool[] {false} ;
         BC000D2_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000D2_A118WWPNotificationIcon = new string[] {""} ;
         BC000D2_A119WWPNotificationTitle = new string[] {""} ;
         BC000D2_A120WWPNotificationShortDescriptio = new string[] {""} ;
         BC000D2_A121WWPNotificationLink = new string[] {""} ;
         BC000D2_A124WWPNotificationIsRead = new bool[] {false} ;
         BC000D2_A102WWPNotificationMetadata = new string[] {""} ;
         BC000D2_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000D2_A65WWPNotificationDefinitionId = new long[1] ;
         BC000D2_A49WWPUserExtendedId = new string[] {""} ;
         BC000D2_n49WWPUserExtendedId = new bool[] {false} ;
         BC000D9_A64WWPNotificationId = new long[1] ;
         BC000D9_n64WWPNotificationId = new bool[] {false} ;
         BC000D12_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000D13_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000D14_A122WWPMailId = new long[1] ;
         BC000D15_A89WWPWebNotificationId = new long[1] ;
         BC000D16_A75WWPSMSId = new long[1] ;
         BC000D17_A64WWPNotificationId = new long[1] ;
         BC000D17_n64WWPNotificationId = new bool[] {false} ;
         BC000D17_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000D17_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000D17_A118WWPNotificationIcon = new string[] {""} ;
         BC000D17_A119WWPNotificationTitle = new string[] {""} ;
         BC000D17_A120WWPNotificationShortDescriptio = new string[] {""} ;
         BC000D17_A121WWPNotificationLink = new string[] {""} ;
         BC000D17_A124WWPNotificationIsRead = new bool[] {false} ;
         BC000D17_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000D17_A102WWPNotificationMetadata = new string[] {""} ;
         BC000D17_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000D17_A65WWPNotificationDefinitionId = new long[1] ;
         BC000D17_A49WWPUserExtendedId = new string[] {""} ;
         BC000D17_n49WWPUserExtendedId = new bool[] {false} ;
         i66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000D2_A64WWPNotificationId, BC000D2_A66WWPNotificationCreated, BC000D2_A118WWPNotificationIcon, BC000D2_A119WWPNotificationTitle, BC000D2_A120WWPNotificationShortDescriptio, BC000D2_A121WWPNotificationLink, BC000D2_A124WWPNotificationIsRead, BC000D2_A102WWPNotificationMetadata, BC000D2_n102WWPNotificationMetadata, BC000D2_A65WWPNotificationDefinitionId,
               BC000D2_A49WWPUserExtendedId, BC000D2_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000D3_A64WWPNotificationId, BC000D3_A66WWPNotificationCreated, BC000D3_A118WWPNotificationIcon, BC000D3_A119WWPNotificationTitle, BC000D3_A120WWPNotificationShortDescriptio, BC000D3_A121WWPNotificationLink, BC000D3_A124WWPNotificationIsRead, BC000D3_A102WWPNotificationMetadata, BC000D3_n102WWPNotificationMetadata, BC000D3_A65WWPNotificationDefinitionId,
               BC000D3_A49WWPUserExtendedId, BC000D3_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000D4_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000D5_A50WWPUserExtendedFullName
               }
               , new Object[] {
               BC000D6_A64WWPNotificationId, BC000D6_A101WWPNotificationDefinitionName, BC000D6_A66WWPNotificationCreated, BC000D6_A118WWPNotificationIcon, BC000D6_A119WWPNotificationTitle, BC000D6_A120WWPNotificationShortDescriptio, BC000D6_A121WWPNotificationLink, BC000D6_A124WWPNotificationIsRead, BC000D6_A50WWPUserExtendedFullName, BC000D6_A102WWPNotificationMetadata,
               BC000D6_n102WWPNotificationMetadata, BC000D6_A65WWPNotificationDefinitionId, BC000D6_A49WWPUserExtendedId, BC000D6_n49WWPUserExtendedId
               }
               , new Object[] {
               BC000D7_A64WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D9_A64WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000D12_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000D13_A50WWPUserExtendedFullName
               }
               , new Object[] {
               BC000D14_A122WWPMailId
               }
               , new Object[] {
               BC000D15_A89WWPWebNotificationId
               }
               , new Object[] {
               BC000D16_A75WWPSMSId
               }
               , new Object[] {
               BC000D17_A64WWPNotificationId, BC000D17_A101WWPNotificationDefinitionName, BC000D17_A66WWPNotificationCreated, BC000D17_A118WWPNotificationIcon, BC000D17_A119WWPNotificationTitle, BC000D17_A120WWPNotificationShortDescriptio, BC000D17_A121WWPNotificationLink, BC000D17_A124WWPNotificationIsRead, BC000D17_A50WWPUserExtendedFullName, BC000D17_A102WWPNotificationMetadata,
               BC000D17_n102WWPNotificationMetadata, BC000D17_A65WWPNotificationDefinitionId, BC000D17_A49WWPUserExtendedId, BC000D17_n49WWPUserExtendedId
               }
            }
         );
         Z66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private int trnEnded ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private long Z65WWPNotificationDefinitionId ;
      private long A65WWPNotificationDefinitionId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z49WWPUserExtendedId ;
      private string A49WWPUserExtendedId ;
      private string sMode13 ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime i66WWPNotificationCreated ;
      private bool Z124WWPNotificationIsRead ;
      private bool A124WWPNotificationIsRead ;
      private bool n64WWPNotificationId ;
      private bool n102WWPNotificationMetadata ;
      private bool n49WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z102WWPNotificationMetadata ;
      private string A102WWPNotificationMetadata ;
      private string Z118WWPNotificationIcon ;
      private string A118WWPNotificationIcon ;
      private string Z119WWPNotificationTitle ;
      private string A119WWPNotificationTitle ;
      private string Z120WWPNotificationShortDescriptio ;
      private string A120WWPNotificationShortDescriptio ;
      private string Z121WWPNotificationLink ;
      private string A121WWPNotificationLink ;
      private string Z101WWPNotificationDefinitionName ;
      private string A101WWPNotificationDefinitionName ;
      private string Z50WWPUserExtendedFullName ;
      private string A50WWPUserExtendedFullName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_Notification bcwwpbaseobjects_notifications_common_WWP_Notification ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000D6_A64WWPNotificationId ;
      private bool[] BC000D6_n64WWPNotificationId ;
      private string[] BC000D6_A101WWPNotificationDefinitionName ;
      private DateTime[] BC000D6_A66WWPNotificationCreated ;
      private string[] BC000D6_A118WWPNotificationIcon ;
      private string[] BC000D6_A119WWPNotificationTitle ;
      private string[] BC000D6_A120WWPNotificationShortDescriptio ;
      private string[] BC000D6_A121WWPNotificationLink ;
      private bool[] BC000D6_A124WWPNotificationIsRead ;
      private string[] BC000D6_A50WWPUserExtendedFullName ;
      private string[] BC000D6_A102WWPNotificationMetadata ;
      private bool[] BC000D6_n102WWPNotificationMetadata ;
      private long[] BC000D6_A65WWPNotificationDefinitionId ;
      private string[] BC000D6_A49WWPUserExtendedId ;
      private bool[] BC000D6_n49WWPUserExtendedId ;
      private string[] BC000D4_A101WWPNotificationDefinitionName ;
      private string[] BC000D5_A50WWPUserExtendedFullName ;
      private long[] BC000D7_A64WWPNotificationId ;
      private bool[] BC000D7_n64WWPNotificationId ;
      private long[] BC000D3_A64WWPNotificationId ;
      private bool[] BC000D3_n64WWPNotificationId ;
      private DateTime[] BC000D3_A66WWPNotificationCreated ;
      private string[] BC000D3_A118WWPNotificationIcon ;
      private string[] BC000D3_A119WWPNotificationTitle ;
      private string[] BC000D3_A120WWPNotificationShortDescriptio ;
      private string[] BC000D3_A121WWPNotificationLink ;
      private bool[] BC000D3_A124WWPNotificationIsRead ;
      private string[] BC000D3_A102WWPNotificationMetadata ;
      private bool[] BC000D3_n102WWPNotificationMetadata ;
      private long[] BC000D3_A65WWPNotificationDefinitionId ;
      private string[] BC000D3_A49WWPUserExtendedId ;
      private bool[] BC000D3_n49WWPUserExtendedId ;
      private long[] BC000D2_A64WWPNotificationId ;
      private bool[] BC000D2_n64WWPNotificationId ;
      private DateTime[] BC000D2_A66WWPNotificationCreated ;
      private string[] BC000D2_A118WWPNotificationIcon ;
      private string[] BC000D2_A119WWPNotificationTitle ;
      private string[] BC000D2_A120WWPNotificationShortDescriptio ;
      private string[] BC000D2_A121WWPNotificationLink ;
      private bool[] BC000D2_A124WWPNotificationIsRead ;
      private string[] BC000D2_A102WWPNotificationMetadata ;
      private bool[] BC000D2_n102WWPNotificationMetadata ;
      private long[] BC000D2_A65WWPNotificationDefinitionId ;
      private string[] BC000D2_A49WWPUserExtendedId ;
      private bool[] BC000D2_n49WWPUserExtendedId ;
      private long[] BC000D9_A64WWPNotificationId ;
      private bool[] BC000D9_n64WWPNotificationId ;
      private string[] BC000D12_A101WWPNotificationDefinitionName ;
      private string[] BC000D13_A50WWPUserExtendedFullName ;
      private long[] BC000D14_A122WWPMailId ;
      private long[] BC000D15_A89WWPWebNotificationId ;
      private long[] BC000D16_A75WWPSMSId ;
      private long[] BC000D17_A64WWPNotificationId ;
      private bool[] BC000D17_n64WWPNotificationId ;
      private string[] BC000D17_A101WWPNotificationDefinitionName ;
      private DateTime[] BC000D17_A66WWPNotificationCreated ;
      private string[] BC000D17_A118WWPNotificationIcon ;
      private string[] BC000D17_A119WWPNotificationTitle ;
      private string[] BC000D17_A120WWPNotificationShortDescriptio ;
      private string[] BC000D17_A121WWPNotificationLink ;
      private bool[] BC000D17_A124WWPNotificationIsRead ;
      private string[] BC000D17_A50WWPUserExtendedFullName ;
      private string[] BC000D17_A102WWPNotificationMetadata ;
      private bool[] BC000D17_n102WWPNotificationMetadata ;
      private long[] BC000D17_A65WWPNotificationDefinitionId ;
      private string[] BC000D17_A49WWPUserExtendedId ;
      private bool[] BC000D17_n49WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000D6;
        prmBC000D6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D4;
        prmBC000D4 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000D5;
        prmBC000D5 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000D7;
        prmBC000D7 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D3;
        prmBC000D3 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D2;
        prmBC000D2 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D8;
        prmBC000D8 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000D9;
        prmBC000D9 = new Object[] {
        };
        Object[] prmBC000D10;
        prmBC000D10 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D11;
        prmBC000D11 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D12;
        prmBC000D12 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000D13;
        prmBC000D13 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000D14;
        prmBC000D14 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D15;
        prmBC000D15 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D16;
        prmBC000D16 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000D17;
        prmBC000D17 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC000D2", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D3", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D4", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D6", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D7", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D8", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000D8)
           ,new CursorDef("BC000D9", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D10", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D10)
           ,new CursorDef("BC000D11", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000D11)
           ,new CursorDef("BC000D12", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D13", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000D14", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D14,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D15", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D16", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000D17", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000D17,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
     }
  }

}

}
