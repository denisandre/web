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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_sms_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms_bc( IGxContext context )
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
         ReadRow099( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey099( ) ;
         standaloneModal( ) ;
         AddRow099( ) ;
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
               Z75WWPSMSId = A75WWPSMSId;
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

      protected void CONFIRM_090( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls099( ) ;
            }
            else
            {
               CheckExtendedTable099( ) ;
               if ( AnyError == 0 )
               {
                  ZM099( 6) ;
               }
               CloseExtendedTableCursors099( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z76WWPSMSStatus = A76WWPSMSStatus;
            Z82WWPSMSCreated = A82WWPSMSCreated;
            Z83WWPSMSScheduled = A83WWPSMSScheduled;
            Z77WWPSMSProcessed = A77WWPSMSProcessed;
            Z64WWPNotificationId = A64WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z75WWPSMSId = A75WWPSMSId;
            Z79WWPSMSMessage = A79WWPSMSMessage;
            Z80WWPSMSSenderNumber = A80WWPSMSSenderNumber;
            Z81WWPSMSRecipientNumbers = A81WWPSMSRecipientNumbers;
            Z76WWPSMSStatus = A76WWPSMSStatus;
            Z82WWPSMSCreated = A82WWPSMSCreated;
            Z83WWPSMSScheduled = A83WWPSMSScheduled;
            Z77WWPSMSProcessed = A77WWPSMSProcessed;
            Z78WWPSMSDetail = A78WWPSMSDetail;
            Z64WWPNotificationId = A64WWPNotificationId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A76WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A76WWPSMSStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A82WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A83WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load099( )
      {
         /* Using cursor BC00095 */
         pr_default.execute(3, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A79WWPSMSMessage = BC00095_A79WWPSMSMessage[0];
            A80WWPSMSSenderNumber = BC00095_A80WWPSMSSenderNumber[0];
            A81WWPSMSRecipientNumbers = BC00095_A81WWPSMSRecipientNumbers[0];
            A76WWPSMSStatus = BC00095_A76WWPSMSStatus[0];
            A82WWPSMSCreated = BC00095_A82WWPSMSCreated[0];
            A83WWPSMSScheduled = BC00095_A83WWPSMSScheduled[0];
            A77WWPSMSProcessed = BC00095_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = BC00095_n77WWPSMSProcessed[0];
            A78WWPSMSDetail = BC00095_A78WWPSMSDetail[0];
            n78WWPSMSDetail = BC00095_n78WWPSMSDetail[0];
            A66WWPNotificationCreated = BC00095_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC00095_A64WWPNotificationId[0];
            n64WWPNotificationId = BC00095_n64WWPNotificationId[0];
            ZM099( -5) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A76WWPSMSStatus == 1 ) || ( A76WWPSMSStatus == 2 ) || ( A76WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo SMS Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC00094 */
         pr_default.execute(2, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A66WWPNotificationCreated = BC00094_A66WWPNotificationCreated[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey099( )
      {
         /* Using cursor BC00096 */
         pr_default.execute(4, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00093 */
         pr_default.execute(1, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 5) ;
            RcdFound9 = 1;
            A75WWPSMSId = BC00093_A75WWPSMSId[0];
            A79WWPSMSMessage = BC00093_A79WWPSMSMessage[0];
            A80WWPSMSSenderNumber = BC00093_A80WWPSMSSenderNumber[0];
            A81WWPSMSRecipientNumbers = BC00093_A81WWPSMSRecipientNumbers[0];
            A76WWPSMSStatus = BC00093_A76WWPSMSStatus[0];
            A82WWPSMSCreated = BC00093_A82WWPSMSCreated[0];
            A83WWPSMSScheduled = BC00093_A83WWPSMSScheduled[0];
            A77WWPSMSProcessed = BC00093_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = BC00093_n77WWPSMSProcessed[0];
            A78WWPSMSDetail = BC00093_A78WWPSMSDetail[0];
            n78WWPSMSDetail = BC00093_n78WWPSMSDetail[0];
            A64WWPNotificationId = BC00093_A64WWPNotificationId[0];
            n64WWPNotificationId = BC00093_n64WWPNotificationId[0];
            Z75WWPSMSId = A75WWPSMSId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode9;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         CONFIRM_090( ) ;
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

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00092 */
            pr_default.execute(0, new Object[] {A75WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z76WWPSMSStatus != BC00092_A76WWPSMSStatus[0] ) || ( Z82WWPSMSCreated != BC00092_A82WWPSMSCreated[0] ) || ( Z83WWPSMSScheduled != BC00092_A83WWPSMSScheduled[0] ) || ( Z77WWPSMSProcessed != BC00092_A77WWPSMSProcessed[0] ) || ( Z64WWPNotificationId != BC00092_A64WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00097 */
                     pr_default.execute(5, new Object[] {A79WWPSMSMessage, A80WWPSMSSenderNumber, A81WWPSMSRecipientNumbers, A76WWPSMSStatus, A82WWPSMSCreated, A83WWPSMSScheduled, n77WWPSMSProcessed, A77WWPSMSProcessed, n78WWPSMSDetail, A78WWPSMSDetail, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00098 */
                     pr_default.execute(6);
                     A75WWPSMSId = BC00098_A75WWPSMSId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00099 */
                     pr_default.execute(7, new Object[] {A79WWPSMSMessage, A80WWPSMSSenderNumber, A81WWPSMSRecipientNumbers, A76WWPSMSStatus, A82WWPSMSCreated, A83WWPSMSScheduled, n77WWPSMSProcessed, A77WWPSMSProcessed, n78WWPSMSDetail, A78WWPSMSDetail, n64WWPNotificationId, A64WWPNotificationId, A75WWPSMSId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000910 */
                  pr_default.execute(8, new Object[] {A75WWPSMSId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel099( ) ;
         Gx_mode = sMode9;
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000911 */
            pr_default.execute(9, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A66WWPNotificationCreated = BC000911_A66WWPNotificationCreated[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
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

      public void ScanKeyStart099( )
      {
         /* Using cursor BC000912 */
         pr_default.execute(10, new Object[] {A75WWPSMSId});
         RcdFound9 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
            A75WWPSMSId = BC000912_A75WWPSMSId[0];
            A79WWPSMSMessage = BC000912_A79WWPSMSMessage[0];
            A80WWPSMSSenderNumber = BC000912_A80WWPSMSSenderNumber[0];
            A81WWPSMSRecipientNumbers = BC000912_A81WWPSMSRecipientNumbers[0];
            A76WWPSMSStatus = BC000912_A76WWPSMSStatus[0];
            A82WWPSMSCreated = BC000912_A82WWPSMSCreated[0];
            A83WWPSMSScheduled = BC000912_A83WWPSMSScheduled[0];
            A77WWPSMSProcessed = BC000912_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = BC000912_n77WWPSMSProcessed[0];
            A78WWPSMSDetail = BC000912_A78WWPSMSDetail[0];
            n78WWPSMSDetail = BC000912_n78WWPSMSDetail[0];
            A66WWPNotificationCreated = BC000912_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC000912_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000912_n64WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound9 = 0;
         ScanKeyLoad099( ) ;
      }

      protected void ScanKeyLoad099( )
      {
         sMode9 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound9 = 1;
            A75WWPSMSId = BC000912_A75WWPSMSId[0];
            A79WWPSMSMessage = BC000912_A79WWPSMSMessage[0];
            A80WWPSMSSenderNumber = BC000912_A80WWPSMSSenderNumber[0];
            A81WWPSMSRecipientNumbers = BC000912_A81WWPSMSRecipientNumbers[0];
            A76WWPSMSStatus = BC000912_A76WWPSMSStatus[0];
            A82WWPSMSCreated = BC000912_A82WWPSMSCreated[0];
            A83WWPSMSScheduled = BC000912_A83WWPSMSScheduled[0];
            A77WWPSMSProcessed = BC000912_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = BC000912_n77WWPSMSProcessed[0];
            A78WWPSMSDetail = BC000912_A78WWPSMSDetail[0];
            n78WWPSMSDetail = BC000912_n78WWPSMSDetail[0];
            A66WWPNotificationCreated = BC000912_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC000912_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000912_n64WWPNotificationId[0];
         }
         Gx_mode = sMode9;
      }

      protected void ScanKeyEnd099( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void AddRow099( )
      {
         VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
      }

      protected void ReadRow099( )
      {
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
      }

      protected void InitializeNonKey099( )
      {
         A79WWPSMSMessage = "";
         A80WWPSMSSenderNumber = "";
         A81WWPSMSRecipientNumbers = "";
         A77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n77WWPSMSProcessed = false;
         A78WWPSMSDetail = "";
         n78WWPSMSDetail = false;
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A76WWPSMSStatus = 1;
         A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z76WWPSMSStatus = 0;
         Z82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z64WWPNotificationId = 0;
      }

      protected void InitAll099( )
      {
         A75WWPSMSId = 0;
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A76WWPSMSStatus = i76WWPSMSStatus;
         A82WWPSMSCreated = i82WWPSMSCreated;
         A83WWPSMSScheduled = i83WWPSMSScheduled;
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

      public void VarsToRow9( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj9 )
      {
         obj9.gxTpr_Mode = Gx_mode;
         obj9.gxTpr_Wwpsmsmessage = A79WWPSMSMessage;
         obj9.gxTpr_Wwpsmssendernumber = A80WWPSMSSenderNumber;
         obj9.gxTpr_Wwpsmsrecipientnumbers = A81WWPSMSRecipientNumbers;
         obj9.gxTpr_Wwpsmsprocessed = A77WWPSMSProcessed;
         obj9.gxTpr_Wwpsmsdetail = A78WWPSMSDetail;
         obj9.gxTpr_Wwpnotificationid = A64WWPNotificationId;
         obj9.gxTpr_Wwpnotificationcreated = A66WWPNotificationCreated;
         obj9.gxTpr_Wwpsmsstatus = A76WWPSMSStatus;
         obj9.gxTpr_Wwpsmscreated = A82WWPSMSCreated;
         obj9.gxTpr_Wwpsmsscheduled = A83WWPSMSScheduled;
         obj9.gxTpr_Wwpsmsid = A75WWPSMSId;
         obj9.gxTpr_Wwpsmsid_Z = Z75WWPSMSId;
         obj9.gxTpr_Wwpsmsstatus_Z = Z76WWPSMSStatus;
         obj9.gxTpr_Wwpsmscreated_Z = Z82WWPSMSCreated;
         obj9.gxTpr_Wwpsmsscheduled_Z = Z83WWPSMSScheduled;
         obj9.gxTpr_Wwpsmsprocessed_Z = Z77WWPSMSProcessed;
         obj9.gxTpr_Wwpnotificationid_Z = Z64WWPNotificationId;
         obj9.gxTpr_Wwpnotificationcreated_Z = Z66WWPNotificationCreated;
         obj9.gxTpr_Wwpsmsprocessed_N = (short)(Convert.ToInt16(n77WWPSMSProcessed));
         obj9.gxTpr_Wwpsmsdetail_N = (short)(Convert.ToInt16(n78WWPSMSDetail));
         obj9.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n64WWPNotificationId));
         obj9.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow9( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj9 )
      {
         obj9.gxTpr_Wwpsmsid = A75WWPSMSId;
         return  ;
      }

      public void RowToVars9( GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS obj9 ,
                              int forceLoad )
      {
         Gx_mode = obj9.gxTpr_Mode;
         A79WWPSMSMessage = obj9.gxTpr_Wwpsmsmessage;
         A80WWPSMSSenderNumber = obj9.gxTpr_Wwpsmssendernumber;
         A81WWPSMSRecipientNumbers = obj9.gxTpr_Wwpsmsrecipientnumbers;
         A77WWPSMSProcessed = obj9.gxTpr_Wwpsmsprocessed;
         n77WWPSMSProcessed = false;
         A78WWPSMSDetail = obj9.gxTpr_Wwpsmsdetail;
         n78WWPSMSDetail = false;
         A64WWPNotificationId = obj9.gxTpr_Wwpnotificationid;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = obj9.gxTpr_Wwpnotificationcreated;
         A76WWPSMSStatus = obj9.gxTpr_Wwpsmsstatus;
         A82WWPSMSCreated = obj9.gxTpr_Wwpsmscreated;
         A83WWPSMSScheduled = obj9.gxTpr_Wwpsmsscheduled;
         A75WWPSMSId = obj9.gxTpr_Wwpsmsid;
         Z75WWPSMSId = obj9.gxTpr_Wwpsmsid_Z;
         Z76WWPSMSStatus = obj9.gxTpr_Wwpsmsstatus_Z;
         Z82WWPSMSCreated = obj9.gxTpr_Wwpsmscreated_Z;
         Z83WWPSMSScheduled = obj9.gxTpr_Wwpsmsscheduled_Z;
         Z77WWPSMSProcessed = obj9.gxTpr_Wwpsmsprocessed_Z;
         Z64WWPNotificationId = obj9.gxTpr_Wwpnotificationid_Z;
         Z66WWPNotificationCreated = obj9.gxTpr_Wwpnotificationcreated_Z;
         n77WWPSMSProcessed = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpsmsprocessed_N));
         n78WWPSMSDetail = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpsmsdetail_N));
         n64WWPNotificationId = (bool)(Convert.ToBoolean(obj9.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj9.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A75WWPSMSId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey099( ) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z75WWPSMSId = A75WWPSMSId;
         }
         ZM099( -5) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         ScanKeyStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z75WWPSMSId = A75WWPSMSId;
         }
         ZM099( -5) ;
         OnLoadActions099( ) ;
         AddRow099( ) ;
         ScanKeyEnd099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert099( ) ;
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A75WWPSMSId != Z75WWPSMSId )
               {
                  A75WWPSMSId = Z75WWPSMSId;
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
                  Update099( ) ;
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
                  if ( A75WWPSMSId != Z75WWPSMSId )
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
                        Insert099( ) ;
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
                        Insert099( ) ;
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         SaveImpl( ) ;
         VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
         AfterTrn( ) ;
         VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS auxBC = new GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A75WWPSMSId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_sms_WWP_SMS);
               auxBC.Save();
               bcwwpbaseobjects_sms_WWP_SMS.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert099( ) ;
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
               VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey099( ) ;
         if ( RcdFound9 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A75WWPSMSId != Z75WWPSMSId )
            {
               A75WWPSMSId = Z75WWPSMSId;
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
            if ( A75WWPSMSId != Z75WWPSMSId )
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
         context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms_bc",pr_default);
         VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
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
         Gx_mode = bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_sms_WWP_SMS )
         {
            bcwwpbaseobjects_sms_WWP_SMS = (GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow9( bcwwpbaseobjects_sms_WWP_SMS) ;
            }
            else
            {
               RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_sms_WWP_SMS.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars9( bcwwpbaseobjects_sms_WWP_SMS, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_SMS WWP_SMS_BC
      {
         get {
            return bcwwpbaseobjects_sms_WWP_SMS ;
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
            return "sms_Execute" ;
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
         pr_default.close(9);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z79WWPSMSMessage = "";
         A79WWPSMSMessage = "";
         Z80WWPSMSSenderNumber = "";
         A80WWPSMSSenderNumber = "";
         Z81WWPSMSRecipientNumbers = "";
         A81WWPSMSRecipientNumbers = "";
         Z78WWPSMSDetail = "";
         A78WWPSMSDetail = "";
         BC00095_A75WWPSMSId = new long[1] ;
         BC00095_A79WWPSMSMessage = new string[] {""} ;
         BC00095_A80WWPSMSSenderNumber = new string[] {""} ;
         BC00095_A81WWPSMSRecipientNumbers = new string[] {""} ;
         BC00095_A76WWPSMSStatus = new short[1] ;
         BC00095_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00095_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00095_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00095_n77WWPSMSProcessed = new bool[] {false} ;
         BC00095_A78WWPSMSDetail = new string[] {""} ;
         BC00095_n78WWPSMSDetail = new bool[] {false} ;
         BC00095_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00095_A64WWPNotificationId = new long[1] ;
         BC00095_n64WWPNotificationId = new bool[] {false} ;
         BC00094_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC00096_A75WWPSMSId = new long[1] ;
         BC00093_A75WWPSMSId = new long[1] ;
         BC00093_A79WWPSMSMessage = new string[] {""} ;
         BC00093_A80WWPSMSSenderNumber = new string[] {""} ;
         BC00093_A81WWPSMSRecipientNumbers = new string[] {""} ;
         BC00093_A76WWPSMSStatus = new short[1] ;
         BC00093_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00093_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00093_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00093_n77WWPSMSProcessed = new bool[] {false} ;
         BC00093_A78WWPSMSDetail = new string[] {""} ;
         BC00093_n78WWPSMSDetail = new bool[] {false} ;
         BC00093_A64WWPNotificationId = new long[1] ;
         BC00093_n64WWPNotificationId = new bool[] {false} ;
         sMode9 = "";
         BC00092_A75WWPSMSId = new long[1] ;
         BC00092_A79WWPSMSMessage = new string[] {""} ;
         BC00092_A80WWPSMSSenderNumber = new string[] {""} ;
         BC00092_A81WWPSMSRecipientNumbers = new string[] {""} ;
         BC00092_A76WWPSMSStatus = new short[1] ;
         BC00092_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC00092_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC00092_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC00092_n77WWPSMSProcessed = new bool[] {false} ;
         BC00092_A78WWPSMSDetail = new string[] {""} ;
         BC00092_n78WWPSMSDetail = new bool[] {false} ;
         BC00092_A64WWPNotificationId = new long[1] ;
         BC00092_n64WWPNotificationId = new bool[] {false} ;
         BC00098_A75WWPSMSId = new long[1] ;
         BC000911_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000912_A75WWPSMSId = new long[1] ;
         BC000912_A79WWPSMSMessage = new string[] {""} ;
         BC000912_A80WWPSMSSenderNumber = new string[] {""} ;
         BC000912_A81WWPSMSRecipientNumbers = new string[] {""} ;
         BC000912_A76WWPSMSStatus = new short[1] ;
         BC000912_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         BC000912_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000912_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000912_n77WWPSMSProcessed = new bool[] {false} ;
         BC000912_A78WWPSMSDetail = new string[] {""} ;
         BC000912_n78WWPSMSDetail = new bool[] {false} ;
         BC000912_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000912_A64WWPNotificationId = new long[1] ;
         BC000912_n64WWPNotificationId = new bool[] {false} ;
         i82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms_bc__default(),
            new Object[][] {
                new Object[] {
               BC00092_A75WWPSMSId, BC00092_A79WWPSMSMessage, BC00092_A80WWPSMSSenderNumber, BC00092_A81WWPSMSRecipientNumbers, BC00092_A76WWPSMSStatus, BC00092_A82WWPSMSCreated, BC00092_A83WWPSMSScheduled, BC00092_A77WWPSMSProcessed, BC00092_n77WWPSMSProcessed, BC00092_A78WWPSMSDetail,
               BC00092_n78WWPSMSDetail, BC00092_A64WWPNotificationId, BC00092_n64WWPNotificationId
               }
               , new Object[] {
               BC00093_A75WWPSMSId, BC00093_A79WWPSMSMessage, BC00093_A80WWPSMSSenderNumber, BC00093_A81WWPSMSRecipientNumbers, BC00093_A76WWPSMSStatus, BC00093_A82WWPSMSCreated, BC00093_A83WWPSMSScheduled, BC00093_A77WWPSMSProcessed, BC00093_n77WWPSMSProcessed, BC00093_A78WWPSMSDetail,
               BC00093_n78WWPSMSDetail, BC00093_A64WWPNotificationId, BC00093_n64WWPNotificationId
               }
               , new Object[] {
               BC00094_A66WWPNotificationCreated
               }
               , new Object[] {
               BC00095_A75WWPSMSId, BC00095_A79WWPSMSMessage, BC00095_A80WWPSMSSenderNumber, BC00095_A81WWPSMSRecipientNumbers, BC00095_A76WWPSMSStatus, BC00095_A82WWPSMSCreated, BC00095_A83WWPSMSScheduled, BC00095_A77WWPSMSProcessed, BC00095_n77WWPSMSProcessed, BC00095_A78WWPSMSDetail,
               BC00095_n78WWPSMSDetail, BC00095_A66WWPNotificationCreated, BC00095_A64WWPNotificationId, BC00095_n64WWPNotificationId
               }
               , new Object[] {
               BC00096_A75WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00098_A75WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000911_A66WWPNotificationCreated
               }
               , new Object[] {
               BC000912_A75WWPSMSId, BC000912_A79WWPSMSMessage, BC000912_A80WWPSMSSenderNumber, BC000912_A81WWPSMSRecipientNumbers, BC000912_A76WWPSMSStatus, BC000912_A82WWPSMSCreated, BC000912_A83WWPSMSScheduled, BC000912_A77WWPSMSProcessed, BC000912_n77WWPSMSProcessed, BC000912_A78WWPSMSDetail,
               BC000912_n78WWPSMSDetail, BC000912_A66WWPNotificationCreated, BC000912_A64WWPNotificationId, BC000912_n64WWPNotificationId
               }
            }
         );
         Z83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z76WWPSMSStatus = 1;
         A76WWPSMSStatus = 1;
         i76WWPSMSStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z76WWPSMSStatus ;
      private short A76WWPSMSStatus ;
      private short Gx_BScreen ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short i76WWPSMSStatus ;
      private int trnEnded ;
      private long Z75WWPSMSId ;
      private long A75WWPSMSId ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode9 ;
      private DateTime Z82WWPSMSCreated ;
      private DateTime A82WWPSMSCreated ;
      private DateTime Z83WWPSMSScheduled ;
      private DateTime A83WWPSMSScheduled ;
      private DateTime Z77WWPSMSProcessed ;
      private DateTime A77WWPSMSProcessed ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime i82WWPSMSCreated ;
      private DateTime i83WWPSMSScheduled ;
      private bool n77WWPSMSProcessed ;
      private bool n78WWPSMSDetail ;
      private bool n64WWPNotificationId ;
      private bool mustCommit ;
      private string Z79WWPSMSMessage ;
      private string A79WWPSMSMessage ;
      private string Z80WWPSMSSenderNumber ;
      private string A80WWPSMSSenderNumber ;
      private string Z81WWPSMSRecipientNumbers ;
      private string A81WWPSMSRecipientNumbers ;
      private string Z78WWPSMSDetail ;
      private string A78WWPSMSDetail ;
      private GeneXus.Programs.wwpbaseobjects.sms.SdtWWP_SMS bcwwpbaseobjects_sms_WWP_SMS ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00095_A75WWPSMSId ;
      private string[] BC00095_A79WWPSMSMessage ;
      private string[] BC00095_A80WWPSMSSenderNumber ;
      private string[] BC00095_A81WWPSMSRecipientNumbers ;
      private short[] BC00095_A76WWPSMSStatus ;
      private DateTime[] BC00095_A82WWPSMSCreated ;
      private DateTime[] BC00095_A83WWPSMSScheduled ;
      private DateTime[] BC00095_A77WWPSMSProcessed ;
      private bool[] BC00095_n77WWPSMSProcessed ;
      private string[] BC00095_A78WWPSMSDetail ;
      private bool[] BC00095_n78WWPSMSDetail ;
      private DateTime[] BC00095_A66WWPNotificationCreated ;
      private long[] BC00095_A64WWPNotificationId ;
      private bool[] BC00095_n64WWPNotificationId ;
      private DateTime[] BC00094_A66WWPNotificationCreated ;
      private long[] BC00096_A75WWPSMSId ;
      private long[] BC00093_A75WWPSMSId ;
      private string[] BC00093_A79WWPSMSMessage ;
      private string[] BC00093_A80WWPSMSSenderNumber ;
      private string[] BC00093_A81WWPSMSRecipientNumbers ;
      private short[] BC00093_A76WWPSMSStatus ;
      private DateTime[] BC00093_A82WWPSMSCreated ;
      private DateTime[] BC00093_A83WWPSMSScheduled ;
      private DateTime[] BC00093_A77WWPSMSProcessed ;
      private bool[] BC00093_n77WWPSMSProcessed ;
      private string[] BC00093_A78WWPSMSDetail ;
      private bool[] BC00093_n78WWPSMSDetail ;
      private long[] BC00093_A64WWPNotificationId ;
      private bool[] BC00093_n64WWPNotificationId ;
      private long[] BC00092_A75WWPSMSId ;
      private string[] BC00092_A79WWPSMSMessage ;
      private string[] BC00092_A80WWPSMSSenderNumber ;
      private string[] BC00092_A81WWPSMSRecipientNumbers ;
      private short[] BC00092_A76WWPSMSStatus ;
      private DateTime[] BC00092_A82WWPSMSCreated ;
      private DateTime[] BC00092_A83WWPSMSScheduled ;
      private DateTime[] BC00092_A77WWPSMSProcessed ;
      private bool[] BC00092_n77WWPSMSProcessed ;
      private string[] BC00092_A78WWPSMSDetail ;
      private bool[] BC00092_n78WWPSMSDetail ;
      private long[] BC00092_A64WWPNotificationId ;
      private bool[] BC00092_n64WWPNotificationId ;
      private long[] BC00098_A75WWPSMSId ;
      private DateTime[] BC000911_A66WWPNotificationCreated ;
      private long[] BC000912_A75WWPSMSId ;
      private string[] BC000912_A79WWPSMSMessage ;
      private string[] BC000912_A80WWPSMSSenderNumber ;
      private string[] BC000912_A81WWPSMSRecipientNumbers ;
      private short[] BC000912_A76WWPSMSStatus ;
      private DateTime[] BC000912_A82WWPSMSCreated ;
      private DateTime[] BC000912_A83WWPSMSScheduled ;
      private DateTime[] BC000912_A77WWPSMSProcessed ;
      private bool[] BC000912_n77WWPSMSProcessed ;
      private string[] BC000912_A78WWPSMSDetail ;
      private bool[] BC000912_n78WWPSMSDetail ;
      private DateTime[] BC000912_A66WWPNotificationCreated ;
      private long[] BC000912_A64WWPNotificationId ;
      private bool[] BC000912_n64WWPNotificationId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_sms_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00095;
        prmBC00095 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00094;
        prmBC00094 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00096;
        prmBC00096 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00093;
        prmBC00093 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00092;
        prmBC00092 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC00097;
        prmBC00097 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC00098;
        prmBC00098 = new Object[] {
        };
        Object[] prmBC00099;
        prmBC00099 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC000910;
        prmBC000910 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmBC000911;
        prmBC000911 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000912;
        prmBC000912 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00092", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS",true, GxErrorMask.GX_NOMASK, false, this,prmBC00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00093", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00094", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00095", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00095,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00096", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00096,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00097", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00097)
           ,new CursorDef("BC00098", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00098,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00099", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00099)
           ,new CursorDef("BC000910", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000910)
           ,new CursorDef("BC000911", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000912", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000912,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
