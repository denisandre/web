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
   public class wwp_webnotification_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_webnotification_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification_bc( IGxContext context )
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
         ReadRow0A10( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0A10( ) ;
         standaloneModal( ) ;
         AddRow0A10( ) ;
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
               Z89WWPWebNotificationId = A89WWPWebNotificationId;
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

      protected void CONFIRM_0A0( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0A10( ) ;
            }
            else
            {
               CheckExtendedTable0A10( ) ;
               if ( AnyError == 0 )
               {
                  ZM0A10( 6) ;
                  ZM0A10( 7) ;
               }
               CloseExtendedTableCursors0A10( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z84WWPWebNotificationTitle = A84WWPWebNotificationTitle;
            Z85WWPWebNotificationText = A85WWPWebNotificationText;
            Z86WWPWebNotificationIcon = A86WWPWebNotificationIcon;
            Z96WWPWebNotificationStatus = A96WWPWebNotificationStatus;
            Z87WWPWebNotificationCreated = A87WWPWebNotificationCreated;
            Z100WWPWebNotificationScheduled = A100WWPWebNotificationScheduled;
            Z97WWPWebNotificationProcessed = A97WWPWebNotificationProcessed;
            Z88WWPWebNotificationRead = A88WWPWebNotificationRead;
            Z99WWPWebNotificationReceived = A99WWPWebNotificationReceived;
            Z64WWPNotificationId = A64WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
         }
         if ( GX_JID == -5 )
         {
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
            Z84WWPWebNotificationTitle = A84WWPWebNotificationTitle;
            Z85WWPWebNotificationText = A85WWPWebNotificationText;
            Z86WWPWebNotificationIcon = A86WWPWebNotificationIcon;
            Z95WWPWebNotificationClientId = A95WWPWebNotificationClientId;
            Z96WWPWebNotificationStatus = A96WWPWebNotificationStatus;
            Z87WWPWebNotificationCreated = A87WWPWebNotificationCreated;
            Z100WWPWebNotificationScheduled = A100WWPWebNotificationScheduled;
            Z97WWPWebNotificationProcessed = A97WWPWebNotificationProcessed;
            Z88WWPWebNotificationRead = A88WWPWebNotificationRead;
            Z98WWPWebNotificationDetail = A98WWPWebNotificationDetail;
            Z99WWPWebNotificationReceived = A99WWPWebNotificationReceived;
            Z64WWPNotificationId = A64WWPNotificationId;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
            Z102WWPNotificationMetadata = A102WWPNotificationMetadata;
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A96WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A96WWPWebNotificationStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A87WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A100WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A10( )
      {
         /* Using cursor BC000A6 */
         pr_default.execute(4, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
            A65WWPNotificationDefinitionId = BC000A6_A65WWPNotificationDefinitionId[0];
            A84WWPWebNotificationTitle = BC000A6_A84WWPWebNotificationTitle[0];
            A66WWPNotificationCreated = BC000A6_A66WWPNotificationCreated[0];
            A102WWPNotificationMetadata = BC000A6_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000A6_n102WWPNotificationMetadata[0];
            A101WWPNotificationDefinitionName = BC000A6_A101WWPNotificationDefinitionName[0];
            A85WWPWebNotificationText = BC000A6_A85WWPWebNotificationText[0];
            A86WWPWebNotificationIcon = BC000A6_A86WWPWebNotificationIcon[0];
            A95WWPWebNotificationClientId = BC000A6_A95WWPWebNotificationClientId[0];
            A96WWPWebNotificationStatus = BC000A6_A96WWPWebNotificationStatus[0];
            A87WWPWebNotificationCreated = BC000A6_A87WWPWebNotificationCreated[0];
            A100WWPWebNotificationScheduled = BC000A6_A100WWPWebNotificationScheduled[0];
            A97WWPWebNotificationProcessed = BC000A6_A97WWPWebNotificationProcessed[0];
            A88WWPWebNotificationRead = BC000A6_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = BC000A6_n88WWPWebNotificationRead[0];
            A98WWPWebNotificationDetail = BC000A6_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = BC000A6_n98WWPWebNotificationDetail[0];
            A99WWPWebNotificationReceived = BC000A6_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = BC000A6_n99WWPWebNotificationReceived[0];
            A64WWPNotificationId = BC000A6_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000A6_n64WWPNotificationId[0];
            ZM0A10( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000A4 */
         pr_default.execute(2, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A65WWPNotificationDefinitionId = BC000A4_A65WWPNotificationDefinitionId[0];
         A66WWPNotificationCreated = BC000A4_A66WWPNotificationCreated[0];
         A102WWPNotificationMetadata = BC000A4_A102WWPNotificationMetadata[0];
         n102WWPNotificationMetadata = BC000A4_n102WWPNotificationMetadata[0];
         pr_default.close(2);
         /* Using cursor BC000A5 */
         pr_default.execute(3, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A65WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A101WWPNotificationDefinitionName = BC000A5_A101WWPNotificationDefinitionName[0];
         pr_default.close(3);
         if ( ! ( ( A96WWPWebNotificationStatus == 1 ) || ( A96WWPWebNotificationStatus == 2 ) || ( A96WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0A10( )
      {
         /* Using cursor BC000A7 */
         pr_default.execute(5, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000A3 */
         pr_default.execute(1, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 5) ;
            RcdFound10 = 1;
            A89WWPWebNotificationId = BC000A3_A89WWPWebNotificationId[0];
            A84WWPWebNotificationTitle = BC000A3_A84WWPWebNotificationTitle[0];
            A85WWPWebNotificationText = BC000A3_A85WWPWebNotificationText[0];
            A86WWPWebNotificationIcon = BC000A3_A86WWPWebNotificationIcon[0];
            A95WWPWebNotificationClientId = BC000A3_A95WWPWebNotificationClientId[0];
            A96WWPWebNotificationStatus = BC000A3_A96WWPWebNotificationStatus[0];
            A87WWPWebNotificationCreated = BC000A3_A87WWPWebNotificationCreated[0];
            A100WWPWebNotificationScheduled = BC000A3_A100WWPWebNotificationScheduled[0];
            A97WWPWebNotificationProcessed = BC000A3_A97WWPWebNotificationProcessed[0];
            A88WWPWebNotificationRead = BC000A3_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = BC000A3_n88WWPWebNotificationRead[0];
            A98WWPWebNotificationDetail = BC000A3_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = BC000A3_n98WWPWebNotificationDetail[0];
            A99WWPWebNotificationReceived = BC000A3_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = BC000A3_n99WWPWebNotificationReceived[0];
            A64WWPNotificationId = BC000A3_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000A3_n64WWPNotificationId[0];
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode10;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
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
         CONFIRM_0A0( ) ;
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

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000A2 */
            pr_default.execute(0, new Object[] {A89WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z84WWPWebNotificationTitle, BC000A2_A84WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z85WWPWebNotificationText, BC000A2_A85WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z86WWPWebNotificationIcon, BC000A2_A86WWPWebNotificationIcon[0]) != 0 ) || ( Z96WWPWebNotificationStatus != BC000A2_A96WWPWebNotificationStatus[0] ) || ( Z87WWPWebNotificationCreated != BC000A2_A87WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z100WWPWebNotificationScheduled != BC000A2_A100WWPWebNotificationScheduled[0] ) || ( Z97WWPWebNotificationProcessed != BC000A2_A97WWPWebNotificationProcessed[0] ) || ( Z88WWPWebNotificationRead != BC000A2_A88WWPWebNotificationRead[0] ) || ( Z99WWPWebNotificationReceived != BC000A2_A99WWPWebNotificationReceived[0] ) || ( Z64WWPNotificationId != BC000A2_A64WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A8 */
                     pr_default.execute(6, new Object[] {A84WWPWebNotificationTitle, A85WWPWebNotificationText, A86WWPWebNotificationIcon, A95WWPWebNotificationClientId, A96WWPWebNotificationStatus, A87WWPWebNotificationCreated, A100WWPWebNotificationScheduled, A97WWPWebNotificationProcessed, n88WWPWebNotificationRead, A88WWPWebNotificationRead, n98WWPWebNotificationDetail, A98WWPWebNotificationDetail, n99WWPWebNotificationReceived, A99WWPWebNotificationReceived, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000A9 */
                     pr_default.execute(7);
                     A89WWPWebNotificationId = BC000A9_A89WWPWebNotificationId[0];
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000A10 */
                     pr_default.execute(8, new Object[] {A84WWPWebNotificationTitle, A85WWPWebNotificationText, A86WWPWebNotificationIcon, A95WWPWebNotificationClientId, A96WWPWebNotificationStatus, A87WWPWebNotificationCreated, A100WWPWebNotificationScheduled, A97WWPWebNotificationProcessed, n88WWPWebNotificationRead, A88WWPWebNotificationRead, n98WWPWebNotificationDetail, A98WWPWebNotificationDetail, n99WWPWebNotificationReceived, A99WWPWebNotificationReceived, n64WWPNotificationId, A64WWPNotificationId, A89WWPWebNotificationId});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000A11 */
                  pr_default.execute(9, new Object[] {A89WWPWebNotificationId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000A12 */
            pr_default.execute(10, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A65WWPNotificationDefinitionId = BC000A12_A65WWPNotificationDefinitionId[0];
            A66WWPNotificationCreated = BC000A12_A66WWPNotificationCreated[0];
            A102WWPNotificationMetadata = BC000A12_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000A12_n102WWPNotificationMetadata[0];
            pr_default.close(10);
            /* Using cursor BC000A13 */
            pr_default.execute(11, new Object[] {A65WWPNotificationDefinitionId});
            A101WWPNotificationDefinitionName = BC000A13_A101WWPNotificationDefinitionName[0];
            pr_default.close(11);
         }
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
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

      public void ScanKeyStart0A10( )
      {
         /* Using cursor BC000A14 */
         pr_default.execute(12, new Object[] {A89WWPWebNotificationId});
         RcdFound10 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound10 = 1;
            A65WWPNotificationDefinitionId = BC000A14_A65WWPNotificationDefinitionId[0];
            A89WWPWebNotificationId = BC000A14_A89WWPWebNotificationId[0];
            A84WWPWebNotificationTitle = BC000A14_A84WWPWebNotificationTitle[0];
            A66WWPNotificationCreated = BC000A14_A66WWPNotificationCreated[0];
            A102WWPNotificationMetadata = BC000A14_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000A14_n102WWPNotificationMetadata[0];
            A101WWPNotificationDefinitionName = BC000A14_A101WWPNotificationDefinitionName[0];
            A85WWPWebNotificationText = BC000A14_A85WWPWebNotificationText[0];
            A86WWPWebNotificationIcon = BC000A14_A86WWPWebNotificationIcon[0];
            A95WWPWebNotificationClientId = BC000A14_A95WWPWebNotificationClientId[0];
            A96WWPWebNotificationStatus = BC000A14_A96WWPWebNotificationStatus[0];
            A87WWPWebNotificationCreated = BC000A14_A87WWPWebNotificationCreated[0];
            A100WWPWebNotificationScheduled = BC000A14_A100WWPWebNotificationScheduled[0];
            A97WWPWebNotificationProcessed = BC000A14_A97WWPWebNotificationProcessed[0];
            A88WWPWebNotificationRead = BC000A14_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = BC000A14_n88WWPWebNotificationRead[0];
            A98WWPWebNotificationDetail = BC000A14_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = BC000A14_n98WWPWebNotificationDetail[0];
            A99WWPWebNotificationReceived = BC000A14_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = BC000A14_n99WWPWebNotificationReceived[0];
            A64WWPNotificationId = BC000A14_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000A14_n64WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound10 = 0;
         ScanKeyLoad0A10( ) ;
      }

      protected void ScanKeyLoad0A10( )
      {
         sMode10 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound10 = 1;
            A65WWPNotificationDefinitionId = BC000A14_A65WWPNotificationDefinitionId[0];
            A89WWPWebNotificationId = BC000A14_A89WWPWebNotificationId[0];
            A84WWPWebNotificationTitle = BC000A14_A84WWPWebNotificationTitle[0];
            A66WWPNotificationCreated = BC000A14_A66WWPNotificationCreated[0];
            A102WWPNotificationMetadata = BC000A14_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = BC000A14_n102WWPNotificationMetadata[0];
            A101WWPNotificationDefinitionName = BC000A14_A101WWPNotificationDefinitionName[0];
            A85WWPWebNotificationText = BC000A14_A85WWPWebNotificationText[0];
            A86WWPWebNotificationIcon = BC000A14_A86WWPWebNotificationIcon[0];
            A95WWPWebNotificationClientId = BC000A14_A95WWPWebNotificationClientId[0];
            A96WWPWebNotificationStatus = BC000A14_A96WWPWebNotificationStatus[0];
            A87WWPWebNotificationCreated = BC000A14_A87WWPWebNotificationCreated[0];
            A100WWPWebNotificationScheduled = BC000A14_A100WWPWebNotificationScheduled[0];
            A97WWPWebNotificationProcessed = BC000A14_A97WWPWebNotificationProcessed[0];
            A88WWPWebNotificationRead = BC000A14_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = BC000A14_n88WWPWebNotificationRead[0];
            A98WWPWebNotificationDetail = BC000A14_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = BC000A14_n98WWPWebNotificationDetail[0];
            A99WWPWebNotificationReceived = BC000A14_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = BC000A14_n99WWPWebNotificationReceived[0];
            A64WWPNotificationId = BC000A14_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000A14_n64WWPNotificationId[0];
         }
         Gx_mode = sMode10;
      }

      protected void ScanKeyEnd0A10( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void AddRow0A10( )
      {
         VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
      }

      protected void ReadRow0A10( )
      {
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
      }

      protected void InitializeNonKey0A10( )
      {
         A65WWPNotificationDefinitionId = 0;
         A84WWPWebNotificationTitle = "";
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A102WWPNotificationMetadata = "";
         n102WWPNotificationMetadata = false;
         A101WWPNotificationDefinitionName = "";
         A85WWPWebNotificationText = "";
         A86WWPWebNotificationIcon = "";
         A95WWPWebNotificationClientId = "";
         A97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n88WWPWebNotificationRead = false;
         A98WWPWebNotificationDetail = "";
         n98WWPWebNotificationDetail = false;
         A99WWPWebNotificationReceived = false;
         n99WWPWebNotificationReceived = false;
         A96WWPWebNotificationStatus = 1;
         A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z84WWPWebNotificationTitle = "";
         Z85WWPWebNotificationText = "";
         Z86WWPWebNotificationIcon = "";
         Z96WWPWebNotificationStatus = 0;
         Z87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z99WWPWebNotificationReceived = false;
         Z64WWPNotificationId = 0;
      }

      protected void InitAll0A10( )
      {
         A89WWPWebNotificationId = 0;
         InitializeNonKey0A10( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A96WWPWebNotificationStatus = i96WWPWebNotificationStatus;
         A87WWPWebNotificationCreated = i87WWPWebNotificationCreated;
         A100WWPWebNotificationScheduled = i100WWPWebNotificationScheduled;
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

      public void VarsToRow10( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj10 )
      {
         obj10.gxTpr_Mode = Gx_mode;
         obj10.gxTpr_Wwpwebnotificationtitle = A84WWPWebNotificationTitle;
         obj10.gxTpr_Wwpnotificationid = A64WWPNotificationId;
         obj10.gxTpr_Wwpnotificationcreated = A66WWPNotificationCreated;
         obj10.gxTpr_Wwpnotificationmetadata = A102WWPNotificationMetadata;
         obj10.gxTpr_Wwpnotificationdefinitionname = A101WWPNotificationDefinitionName;
         obj10.gxTpr_Wwpwebnotificationtext = A85WWPWebNotificationText;
         obj10.gxTpr_Wwpwebnotificationicon = A86WWPWebNotificationIcon;
         obj10.gxTpr_Wwpwebnotificationclientid = A95WWPWebNotificationClientId;
         obj10.gxTpr_Wwpwebnotificationprocessed = A97WWPWebNotificationProcessed;
         obj10.gxTpr_Wwpwebnotificationread = A88WWPWebNotificationRead;
         obj10.gxTpr_Wwpwebnotificationdetail = A98WWPWebNotificationDetail;
         obj10.gxTpr_Wwpwebnotificationreceived = A99WWPWebNotificationReceived;
         obj10.gxTpr_Wwpwebnotificationstatus = A96WWPWebNotificationStatus;
         obj10.gxTpr_Wwpwebnotificationcreated = A87WWPWebNotificationCreated;
         obj10.gxTpr_Wwpwebnotificationscheduled = A100WWPWebNotificationScheduled;
         obj10.gxTpr_Wwpwebnotificationid = A89WWPWebNotificationId;
         obj10.gxTpr_Wwpwebnotificationid_Z = Z89WWPWebNotificationId;
         obj10.gxTpr_Wwpwebnotificationtitle_Z = Z84WWPWebNotificationTitle;
         obj10.gxTpr_Wwpnotificationid_Z = Z64WWPNotificationId;
         obj10.gxTpr_Wwpnotificationcreated_Z = Z66WWPNotificationCreated;
         obj10.gxTpr_Wwpnotificationdefinitionname_Z = Z101WWPNotificationDefinitionName;
         obj10.gxTpr_Wwpwebnotificationtext_Z = Z85WWPWebNotificationText;
         obj10.gxTpr_Wwpwebnotificationicon_Z = Z86WWPWebNotificationIcon;
         obj10.gxTpr_Wwpwebnotificationstatus_Z = Z96WWPWebNotificationStatus;
         obj10.gxTpr_Wwpwebnotificationcreated_Z = Z87WWPWebNotificationCreated;
         obj10.gxTpr_Wwpwebnotificationscheduled_Z = Z100WWPWebNotificationScheduled;
         obj10.gxTpr_Wwpwebnotificationprocessed_Z = Z97WWPWebNotificationProcessed;
         obj10.gxTpr_Wwpwebnotificationread_Z = Z88WWPWebNotificationRead;
         obj10.gxTpr_Wwpwebnotificationreceived_Z = Z99WWPWebNotificationReceived;
         obj10.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n64WWPNotificationId));
         obj10.gxTpr_Wwpnotificationmetadata_N = (short)(Convert.ToInt16(n102WWPNotificationMetadata));
         obj10.gxTpr_Wwpwebnotificationread_N = (short)(Convert.ToInt16(n88WWPWebNotificationRead));
         obj10.gxTpr_Wwpwebnotificationdetail_N = (short)(Convert.ToInt16(n98WWPWebNotificationDetail));
         obj10.gxTpr_Wwpwebnotificationreceived_N = (short)(Convert.ToInt16(n99WWPWebNotificationReceived));
         obj10.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow10( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj10 )
      {
         obj10.gxTpr_Wwpwebnotificationid = A89WWPWebNotificationId;
         return  ;
      }

      public void RowToVars10( GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification obj10 ,
                               int forceLoad )
      {
         Gx_mode = obj10.gxTpr_Mode;
         A84WWPWebNotificationTitle = obj10.gxTpr_Wwpwebnotificationtitle;
         A64WWPNotificationId = obj10.gxTpr_Wwpnotificationid;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = obj10.gxTpr_Wwpnotificationcreated;
         A102WWPNotificationMetadata = obj10.gxTpr_Wwpnotificationmetadata;
         n102WWPNotificationMetadata = false;
         A101WWPNotificationDefinitionName = obj10.gxTpr_Wwpnotificationdefinitionname;
         A85WWPWebNotificationText = obj10.gxTpr_Wwpwebnotificationtext;
         A86WWPWebNotificationIcon = obj10.gxTpr_Wwpwebnotificationicon;
         A95WWPWebNotificationClientId = obj10.gxTpr_Wwpwebnotificationclientid;
         A97WWPWebNotificationProcessed = obj10.gxTpr_Wwpwebnotificationprocessed;
         A88WWPWebNotificationRead = obj10.gxTpr_Wwpwebnotificationread;
         n88WWPWebNotificationRead = false;
         A98WWPWebNotificationDetail = obj10.gxTpr_Wwpwebnotificationdetail;
         n98WWPWebNotificationDetail = false;
         A99WWPWebNotificationReceived = obj10.gxTpr_Wwpwebnotificationreceived;
         n99WWPWebNotificationReceived = false;
         A96WWPWebNotificationStatus = obj10.gxTpr_Wwpwebnotificationstatus;
         A87WWPWebNotificationCreated = obj10.gxTpr_Wwpwebnotificationcreated;
         A100WWPWebNotificationScheduled = obj10.gxTpr_Wwpwebnotificationscheduled;
         A89WWPWebNotificationId = obj10.gxTpr_Wwpwebnotificationid;
         Z89WWPWebNotificationId = obj10.gxTpr_Wwpwebnotificationid_Z;
         Z84WWPWebNotificationTitle = obj10.gxTpr_Wwpwebnotificationtitle_Z;
         Z64WWPNotificationId = obj10.gxTpr_Wwpnotificationid_Z;
         Z66WWPNotificationCreated = obj10.gxTpr_Wwpnotificationcreated_Z;
         Z101WWPNotificationDefinitionName = obj10.gxTpr_Wwpnotificationdefinitionname_Z;
         Z85WWPWebNotificationText = obj10.gxTpr_Wwpwebnotificationtext_Z;
         Z86WWPWebNotificationIcon = obj10.gxTpr_Wwpwebnotificationicon_Z;
         Z96WWPWebNotificationStatus = obj10.gxTpr_Wwpwebnotificationstatus_Z;
         Z87WWPWebNotificationCreated = obj10.gxTpr_Wwpwebnotificationcreated_Z;
         Z100WWPWebNotificationScheduled = obj10.gxTpr_Wwpwebnotificationscheduled_Z;
         Z97WWPWebNotificationProcessed = obj10.gxTpr_Wwpwebnotificationprocessed_Z;
         Z88WWPWebNotificationRead = obj10.gxTpr_Wwpwebnotificationread_Z;
         Z99WWPWebNotificationReceived = obj10.gxTpr_Wwpwebnotificationreceived_Z;
         n64WWPNotificationId = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpnotificationid_N));
         n102WWPNotificationMetadata = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpnotificationmetadata_N));
         n88WWPWebNotificationRead = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpwebnotificationread_N));
         n98WWPWebNotificationDetail = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpwebnotificationdetail_N));
         n99WWPWebNotificationReceived = (bool)(Convert.ToBoolean(obj10.gxTpr_Wwpwebnotificationreceived_N));
         Gx_mode = obj10.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A89WWPWebNotificationId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0A10( ) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
         }
         ZM0A10( -5) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         ScanKeyStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
         }
         ZM0A10( -5) ;
         OnLoadActions0A10( ) ;
         AddRow0A10( ) ;
         ScanKeyEnd0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0A10( ) ;
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
               {
                  A89WWPWebNotificationId = Z89WWPWebNotificationId;
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
                  Update0A10( ) ;
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
                  if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
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
                        Insert0A10( ) ;
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
                        Insert0A10( ) ;
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         SaveImpl( ) ;
         VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
         AfterTrn( ) ;
         VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A89WWPWebNotificationId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_web_WWP_WebNotification);
               auxBC.Save();
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0A10( ) ;
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
               VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0A10( ) ;
         if ( RcdFound10 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
            {
               A89WWPWebNotificationId = Z89WWPWebNotificationId;
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
            if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification_bc",pr_default);
         VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_web_WWP_WebNotification )
         {
            bcwwpbaseobjects_notifications_web_WWP_WebNotification = (GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow10( bcwwpbaseobjects_notifications_web_WWP_WebNotification) ;
            }
            else
            {
               RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_web_WWP_WebNotification.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars10( bcwwpbaseobjects_notifications_web_WWP_WebNotification, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_WebNotification WWP_WebNotification_BC
      {
         get {
            return bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
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
            return "webnotification_Execute" ;
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
         Z84WWPWebNotificationTitle = "";
         A84WWPWebNotificationTitle = "";
         Z85WWPWebNotificationText = "";
         A85WWPWebNotificationText = "";
         Z86WWPWebNotificationIcon = "";
         A86WWPWebNotificationIcon = "";
         Z87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z101WWPNotificationDefinitionName = "";
         A101WWPNotificationDefinitionName = "";
         Z95WWPWebNotificationClientId = "";
         A95WWPWebNotificationClientId = "";
         Z98WWPWebNotificationDetail = "";
         A98WWPWebNotificationDetail = "";
         Z102WWPNotificationMetadata = "";
         A102WWPNotificationMetadata = "";
         BC000A6_A65WWPNotificationDefinitionId = new long[1] ;
         BC000A6_A89WWPWebNotificationId = new long[1] ;
         BC000A6_A84WWPWebNotificationTitle = new string[] {""} ;
         BC000A6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A6_A102WWPNotificationMetadata = new string[] {""} ;
         BC000A6_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000A6_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000A6_A85WWPWebNotificationText = new string[] {""} ;
         BC000A6_A86WWPWebNotificationIcon = new string[] {""} ;
         BC000A6_A95WWPWebNotificationClientId = new string[] {""} ;
         BC000A6_A96WWPWebNotificationStatus = new short[1] ;
         BC000A6_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A6_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A6_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A6_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000A6_n88WWPWebNotificationRead = new bool[] {false} ;
         BC000A6_A98WWPWebNotificationDetail = new string[] {""} ;
         BC000A6_n98WWPWebNotificationDetail = new bool[] {false} ;
         BC000A6_A99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A6_n99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A6_A64WWPNotificationId = new long[1] ;
         BC000A6_n64WWPNotificationId = new bool[] {false} ;
         BC000A4_A65WWPNotificationDefinitionId = new long[1] ;
         BC000A4_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A4_A102WWPNotificationMetadata = new string[] {""} ;
         BC000A4_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000A5_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000A7_A89WWPWebNotificationId = new long[1] ;
         BC000A3_A89WWPWebNotificationId = new long[1] ;
         BC000A3_A84WWPWebNotificationTitle = new string[] {""} ;
         BC000A3_A85WWPWebNotificationText = new string[] {""} ;
         BC000A3_A86WWPWebNotificationIcon = new string[] {""} ;
         BC000A3_A95WWPWebNotificationClientId = new string[] {""} ;
         BC000A3_A96WWPWebNotificationStatus = new short[1] ;
         BC000A3_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A3_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A3_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A3_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000A3_n88WWPWebNotificationRead = new bool[] {false} ;
         BC000A3_A98WWPWebNotificationDetail = new string[] {""} ;
         BC000A3_n98WWPWebNotificationDetail = new bool[] {false} ;
         BC000A3_A99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A3_n99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A3_A64WWPNotificationId = new long[1] ;
         BC000A3_n64WWPNotificationId = new bool[] {false} ;
         sMode10 = "";
         BC000A2_A89WWPWebNotificationId = new long[1] ;
         BC000A2_A84WWPWebNotificationTitle = new string[] {""} ;
         BC000A2_A85WWPWebNotificationText = new string[] {""} ;
         BC000A2_A86WWPWebNotificationIcon = new string[] {""} ;
         BC000A2_A95WWPWebNotificationClientId = new string[] {""} ;
         BC000A2_A96WWPWebNotificationStatus = new short[1] ;
         BC000A2_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A2_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A2_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A2_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000A2_n88WWPWebNotificationRead = new bool[] {false} ;
         BC000A2_A98WWPWebNotificationDetail = new string[] {""} ;
         BC000A2_n98WWPWebNotificationDetail = new bool[] {false} ;
         BC000A2_A99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A2_n99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A2_A64WWPNotificationId = new long[1] ;
         BC000A2_n64WWPNotificationId = new bool[] {false} ;
         BC000A9_A89WWPWebNotificationId = new long[1] ;
         BC000A12_A65WWPNotificationDefinitionId = new long[1] ;
         BC000A12_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A12_A102WWPNotificationMetadata = new string[] {""} ;
         BC000A12_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000A13_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000A14_A65WWPNotificationDefinitionId = new long[1] ;
         BC000A14_A89WWPWebNotificationId = new long[1] ;
         BC000A14_A84WWPWebNotificationTitle = new string[] {""} ;
         BC000A14_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A14_A102WWPNotificationMetadata = new string[] {""} ;
         BC000A14_n102WWPNotificationMetadata = new bool[] {false} ;
         BC000A14_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000A14_A85WWPWebNotificationText = new string[] {""} ;
         BC000A14_A86WWPWebNotificationIcon = new string[] {""} ;
         BC000A14_A95WWPWebNotificationClientId = new string[] {""} ;
         BC000A14_A96WWPWebNotificationStatus = new short[1] ;
         BC000A14_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000A14_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000A14_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000A14_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         BC000A14_n88WWPWebNotificationRead = new bool[] {false} ;
         BC000A14_A98WWPWebNotificationDetail = new string[] {""} ;
         BC000A14_n98WWPWebNotificationDetail = new bool[] {false} ;
         BC000A14_A99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A14_n99WWPWebNotificationReceived = new bool[] {false} ;
         BC000A14_A64WWPNotificationId = new long[1] ;
         BC000A14_n64WWPNotificationId = new bool[] {false} ;
         i87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification_bc__default(),
            new Object[][] {
                new Object[] {
               BC000A2_A89WWPWebNotificationId, BC000A2_A84WWPWebNotificationTitle, BC000A2_A85WWPWebNotificationText, BC000A2_A86WWPWebNotificationIcon, BC000A2_A95WWPWebNotificationClientId, BC000A2_A96WWPWebNotificationStatus, BC000A2_A87WWPWebNotificationCreated, BC000A2_A100WWPWebNotificationScheduled, BC000A2_A97WWPWebNotificationProcessed, BC000A2_A88WWPWebNotificationRead,
               BC000A2_n88WWPWebNotificationRead, BC000A2_A98WWPWebNotificationDetail, BC000A2_n98WWPWebNotificationDetail, BC000A2_A99WWPWebNotificationReceived, BC000A2_n99WWPWebNotificationReceived, BC000A2_A64WWPNotificationId, BC000A2_n64WWPNotificationId
               }
               , new Object[] {
               BC000A3_A89WWPWebNotificationId, BC000A3_A84WWPWebNotificationTitle, BC000A3_A85WWPWebNotificationText, BC000A3_A86WWPWebNotificationIcon, BC000A3_A95WWPWebNotificationClientId, BC000A3_A96WWPWebNotificationStatus, BC000A3_A87WWPWebNotificationCreated, BC000A3_A100WWPWebNotificationScheduled, BC000A3_A97WWPWebNotificationProcessed, BC000A3_A88WWPWebNotificationRead,
               BC000A3_n88WWPWebNotificationRead, BC000A3_A98WWPWebNotificationDetail, BC000A3_n98WWPWebNotificationDetail, BC000A3_A99WWPWebNotificationReceived, BC000A3_n99WWPWebNotificationReceived, BC000A3_A64WWPNotificationId, BC000A3_n64WWPNotificationId
               }
               , new Object[] {
               BC000A4_A65WWPNotificationDefinitionId, BC000A4_A66WWPNotificationCreated, BC000A4_A102WWPNotificationMetadata, BC000A4_n102WWPNotificationMetadata
               }
               , new Object[] {
               BC000A5_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000A6_A65WWPNotificationDefinitionId, BC000A6_A89WWPWebNotificationId, BC000A6_A84WWPWebNotificationTitle, BC000A6_A66WWPNotificationCreated, BC000A6_A102WWPNotificationMetadata, BC000A6_n102WWPNotificationMetadata, BC000A6_A101WWPNotificationDefinitionName, BC000A6_A85WWPWebNotificationText, BC000A6_A86WWPWebNotificationIcon, BC000A6_A95WWPWebNotificationClientId,
               BC000A6_A96WWPWebNotificationStatus, BC000A6_A87WWPWebNotificationCreated, BC000A6_A100WWPWebNotificationScheduled, BC000A6_A97WWPWebNotificationProcessed, BC000A6_A88WWPWebNotificationRead, BC000A6_n88WWPWebNotificationRead, BC000A6_A98WWPWebNotificationDetail, BC000A6_n98WWPWebNotificationDetail, BC000A6_A99WWPWebNotificationReceived, BC000A6_n99WWPWebNotificationReceived,
               BC000A6_A64WWPNotificationId, BC000A6_n64WWPNotificationId
               }
               , new Object[] {
               BC000A7_A89WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A9_A89WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000A12_A65WWPNotificationDefinitionId, BC000A12_A66WWPNotificationCreated, BC000A12_A102WWPNotificationMetadata, BC000A12_n102WWPNotificationMetadata
               }
               , new Object[] {
               BC000A13_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               BC000A14_A65WWPNotificationDefinitionId, BC000A14_A89WWPWebNotificationId, BC000A14_A84WWPWebNotificationTitle, BC000A14_A66WWPNotificationCreated, BC000A14_A102WWPNotificationMetadata, BC000A14_n102WWPNotificationMetadata, BC000A14_A101WWPNotificationDefinitionName, BC000A14_A85WWPWebNotificationText, BC000A14_A86WWPWebNotificationIcon, BC000A14_A95WWPWebNotificationClientId,
               BC000A14_A96WWPWebNotificationStatus, BC000A14_A87WWPWebNotificationCreated, BC000A14_A100WWPWebNotificationScheduled, BC000A14_A97WWPWebNotificationProcessed, BC000A14_A88WWPWebNotificationRead, BC000A14_n88WWPWebNotificationRead, BC000A14_A98WWPWebNotificationDetail, BC000A14_n98WWPWebNotificationDetail, BC000A14_A99WWPWebNotificationReceived, BC000A14_n99WWPWebNotificationReceived,
               BC000A14_A64WWPNotificationId, BC000A14_n64WWPNotificationId
               }
            }
         );
         Z100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z96WWPWebNotificationStatus = 1;
         A96WWPWebNotificationStatus = 1;
         i96WWPWebNotificationStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z96WWPWebNotificationStatus ;
      private short A96WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short i96WWPWebNotificationStatus ;
      private int trnEnded ;
      private long Z89WWPWebNotificationId ;
      private long A89WWPWebNotificationId ;
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
      private string sMode10 ;
      private DateTime Z87WWPWebNotificationCreated ;
      private DateTime A87WWPWebNotificationCreated ;
      private DateTime Z100WWPWebNotificationScheduled ;
      private DateTime A100WWPWebNotificationScheduled ;
      private DateTime Z97WWPWebNotificationProcessed ;
      private DateTime A97WWPWebNotificationProcessed ;
      private DateTime Z88WWPWebNotificationRead ;
      private DateTime A88WWPWebNotificationRead ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime i87WWPWebNotificationCreated ;
      private DateTime i100WWPWebNotificationScheduled ;
      private bool Z99WWPWebNotificationReceived ;
      private bool A99WWPWebNotificationReceived ;
      private bool n102WWPNotificationMetadata ;
      private bool n88WWPWebNotificationRead ;
      private bool n98WWPWebNotificationDetail ;
      private bool n99WWPWebNotificationReceived ;
      private bool n64WWPNotificationId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z95WWPWebNotificationClientId ;
      private string A95WWPWebNotificationClientId ;
      private string Z98WWPWebNotificationDetail ;
      private string A98WWPWebNotificationDetail ;
      private string Z102WWPNotificationMetadata ;
      private string A102WWPNotificationMetadata ;
      private string Z84WWPWebNotificationTitle ;
      private string A84WWPWebNotificationTitle ;
      private string Z85WWPWebNotificationText ;
      private string A85WWPWebNotificationText ;
      private string Z86WWPWebNotificationIcon ;
      private string A86WWPWebNotificationIcon ;
      private string Z101WWPNotificationDefinitionName ;
      private string A101WWPNotificationDefinitionName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.web.SdtWWP_WebNotification bcwwpbaseobjects_notifications_web_WWP_WebNotification ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000A6_A65WWPNotificationDefinitionId ;
      private long[] BC000A6_A89WWPWebNotificationId ;
      private string[] BC000A6_A84WWPWebNotificationTitle ;
      private DateTime[] BC000A6_A66WWPNotificationCreated ;
      private string[] BC000A6_A102WWPNotificationMetadata ;
      private bool[] BC000A6_n102WWPNotificationMetadata ;
      private string[] BC000A6_A101WWPNotificationDefinitionName ;
      private string[] BC000A6_A85WWPWebNotificationText ;
      private string[] BC000A6_A86WWPWebNotificationIcon ;
      private string[] BC000A6_A95WWPWebNotificationClientId ;
      private short[] BC000A6_A96WWPWebNotificationStatus ;
      private DateTime[] BC000A6_A87WWPWebNotificationCreated ;
      private DateTime[] BC000A6_A100WWPWebNotificationScheduled ;
      private DateTime[] BC000A6_A97WWPWebNotificationProcessed ;
      private DateTime[] BC000A6_A88WWPWebNotificationRead ;
      private bool[] BC000A6_n88WWPWebNotificationRead ;
      private string[] BC000A6_A98WWPWebNotificationDetail ;
      private bool[] BC000A6_n98WWPWebNotificationDetail ;
      private bool[] BC000A6_A99WWPWebNotificationReceived ;
      private bool[] BC000A6_n99WWPWebNotificationReceived ;
      private long[] BC000A6_A64WWPNotificationId ;
      private bool[] BC000A6_n64WWPNotificationId ;
      private long[] BC000A4_A65WWPNotificationDefinitionId ;
      private DateTime[] BC000A4_A66WWPNotificationCreated ;
      private string[] BC000A4_A102WWPNotificationMetadata ;
      private bool[] BC000A4_n102WWPNotificationMetadata ;
      private string[] BC000A5_A101WWPNotificationDefinitionName ;
      private long[] BC000A7_A89WWPWebNotificationId ;
      private long[] BC000A3_A89WWPWebNotificationId ;
      private string[] BC000A3_A84WWPWebNotificationTitle ;
      private string[] BC000A3_A85WWPWebNotificationText ;
      private string[] BC000A3_A86WWPWebNotificationIcon ;
      private string[] BC000A3_A95WWPWebNotificationClientId ;
      private short[] BC000A3_A96WWPWebNotificationStatus ;
      private DateTime[] BC000A3_A87WWPWebNotificationCreated ;
      private DateTime[] BC000A3_A100WWPWebNotificationScheduled ;
      private DateTime[] BC000A3_A97WWPWebNotificationProcessed ;
      private DateTime[] BC000A3_A88WWPWebNotificationRead ;
      private bool[] BC000A3_n88WWPWebNotificationRead ;
      private string[] BC000A3_A98WWPWebNotificationDetail ;
      private bool[] BC000A3_n98WWPWebNotificationDetail ;
      private bool[] BC000A3_A99WWPWebNotificationReceived ;
      private bool[] BC000A3_n99WWPWebNotificationReceived ;
      private long[] BC000A3_A64WWPNotificationId ;
      private bool[] BC000A3_n64WWPNotificationId ;
      private long[] BC000A2_A89WWPWebNotificationId ;
      private string[] BC000A2_A84WWPWebNotificationTitle ;
      private string[] BC000A2_A85WWPWebNotificationText ;
      private string[] BC000A2_A86WWPWebNotificationIcon ;
      private string[] BC000A2_A95WWPWebNotificationClientId ;
      private short[] BC000A2_A96WWPWebNotificationStatus ;
      private DateTime[] BC000A2_A87WWPWebNotificationCreated ;
      private DateTime[] BC000A2_A100WWPWebNotificationScheduled ;
      private DateTime[] BC000A2_A97WWPWebNotificationProcessed ;
      private DateTime[] BC000A2_A88WWPWebNotificationRead ;
      private bool[] BC000A2_n88WWPWebNotificationRead ;
      private string[] BC000A2_A98WWPWebNotificationDetail ;
      private bool[] BC000A2_n98WWPWebNotificationDetail ;
      private bool[] BC000A2_A99WWPWebNotificationReceived ;
      private bool[] BC000A2_n99WWPWebNotificationReceived ;
      private long[] BC000A2_A64WWPNotificationId ;
      private bool[] BC000A2_n64WWPNotificationId ;
      private long[] BC000A9_A89WWPWebNotificationId ;
      private long[] BC000A12_A65WWPNotificationDefinitionId ;
      private DateTime[] BC000A12_A66WWPNotificationCreated ;
      private string[] BC000A12_A102WWPNotificationMetadata ;
      private bool[] BC000A12_n102WWPNotificationMetadata ;
      private string[] BC000A13_A101WWPNotificationDefinitionName ;
      private long[] BC000A14_A65WWPNotificationDefinitionId ;
      private long[] BC000A14_A89WWPWebNotificationId ;
      private string[] BC000A14_A84WWPWebNotificationTitle ;
      private DateTime[] BC000A14_A66WWPNotificationCreated ;
      private string[] BC000A14_A102WWPNotificationMetadata ;
      private bool[] BC000A14_n102WWPNotificationMetadata ;
      private string[] BC000A14_A101WWPNotificationDefinitionName ;
      private string[] BC000A14_A85WWPWebNotificationText ;
      private string[] BC000A14_A86WWPWebNotificationIcon ;
      private string[] BC000A14_A95WWPWebNotificationClientId ;
      private short[] BC000A14_A96WWPWebNotificationStatus ;
      private DateTime[] BC000A14_A87WWPWebNotificationCreated ;
      private DateTime[] BC000A14_A100WWPWebNotificationScheduled ;
      private DateTime[] BC000A14_A97WWPWebNotificationProcessed ;
      private DateTime[] BC000A14_A88WWPWebNotificationRead ;
      private bool[] BC000A14_n88WWPWebNotificationRead ;
      private string[] BC000A14_A98WWPWebNotificationDetail ;
      private bool[] BC000A14_n98WWPWebNotificationDetail ;
      private bool[] BC000A14_A99WWPWebNotificationReceived ;
      private bool[] BC000A14_n99WWPWebNotificationReceived ;
      private long[] BC000A14_A64WWPNotificationId ;
      private bool[] BC000A14_n64WWPNotificationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_webnotification_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000A6;
        prmBC000A6 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A4;
        prmBC000A4 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000A5;
        prmBC000A5 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000A7;
        prmBC000A7 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A3;
        prmBC000A3 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A2;
        prmBC000A2 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A8;
        prmBC000A8 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000A9;
        prmBC000A9 = new Object[] {
        };
        Object[] prmBC000A10;
        prmBC000A10 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A11;
        prmBC000A11 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmBC000A12;
        prmBC000A12 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000A13;
        prmBC000A13 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000A14;
        prmBC000A14 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000A2", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A3", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A4", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A5", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A6", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A7", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A8", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000A8)
           ,new CursorDef("BC000A9", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A10", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A10)
           ,new CursorDef("BC000A11", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000A11)
           ,new CursorDef("BC000A12", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A12,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A13", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000A14", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000A14,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
     }
  }

}

}
