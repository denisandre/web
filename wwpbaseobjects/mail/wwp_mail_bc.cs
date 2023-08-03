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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mail_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail_bc( IGxContext context )
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
         ReadRow0F15( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0F15( ) ;
         standaloneModal( ) ;
         AddRow0F15( ) ;
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
               Z122WWPMailId = A122WWPMailId;
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

      protected void CONFIRM_0F0( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0F15( ) ;
            }
            else
            {
               CheckExtendedTable0F15( ) ;
               if ( AnyError == 0 )
               {
                  ZM0F15( 6) ;
               }
               CloseExtendedTableCursors0F15( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode15 = Gx_mode;
            CONFIRM_0F16( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode15;
               IsConfirmed = 1;
            }
            /* Restore parent mode. */
            Gx_mode = sMode15;
         }
      }

      protected void CONFIRM_0F16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0F16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0F16( ) ;
               if ( IsIns( ) && ! IsDlt( ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     BeforeValidate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F16( ) ;
                        if ( AnyError == 0 )
                        {
                        }
                        CloseExtendedTableCursors0F16( ) ;
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
                  if ( RcdFound16 != 0 )
                  {
                     if ( IsDlt( ) )
                     {
                        Gx_mode = "DLT";
                        getByPrimaryKey0F16( ) ;
                        Load0F16( ) ;
                        BeforeValidate0F16( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F16( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           BeforeValidate0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F16( ) ;
                              if ( AnyError == 0 )
                              {
                              }
                              CloseExtendedTableCursors0F16( ) ;
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
               VarsToRow16( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_16_idx))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z111WWPMailSubject = A111WWPMailSubject;
            Z123WWPMailStatus = A123WWPMailStatus;
            Z133WWPMailCreated = A133WWPMailCreated;
            Z134WWPMailScheduled = A134WWPMailScheduled;
            Z128WWPMailProcessed = A128WWPMailProcessed;
            Z64WWPNotificationId = A64WWPNotificationId;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
         }
         if ( GX_JID == -5 )
         {
            Z122WWPMailId = A122WWPMailId;
            Z111WWPMailSubject = A111WWPMailSubject;
            Z103WWPMailBody = A103WWPMailBody;
            Z112WWPMailTo = A112WWPMailTo;
            Z125WWPMailCC = A125WWPMailCC;
            Z126WWPMailBCC = A126WWPMailBCC;
            Z113WWPMailSenderAddress = A113WWPMailSenderAddress;
            Z114WWPMailSenderName = A114WWPMailSenderName;
            Z123WWPMailStatus = A123WWPMailStatus;
            Z133WWPMailCreated = A133WWPMailCreated;
            Z134WWPMailScheduled = A134WWPMailScheduled;
            Z128WWPMailProcessed = A128WWPMailProcessed;
            Z129WWPMailDetail = A129WWPMailDetail;
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
         if ( IsIns( )  && (0==A123WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A123WWPMailStatus = 1;
         }
         if ( IsIns( )  && (DateTime.MinValue==A133WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( IsIns( )  && (DateTime.MinValue==A134WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0F15( )
      {
         /* Using cursor BC000F7 */
         pr_default.execute(5, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound15 = 1;
            A111WWPMailSubject = BC000F7_A111WWPMailSubject[0];
            A103WWPMailBody = BC000F7_A103WWPMailBody[0];
            A112WWPMailTo = BC000F7_A112WWPMailTo[0];
            n112WWPMailTo = BC000F7_n112WWPMailTo[0];
            A125WWPMailCC = BC000F7_A125WWPMailCC[0];
            n125WWPMailCC = BC000F7_n125WWPMailCC[0];
            A126WWPMailBCC = BC000F7_A126WWPMailBCC[0];
            n126WWPMailBCC = BC000F7_n126WWPMailBCC[0];
            A113WWPMailSenderAddress = BC000F7_A113WWPMailSenderAddress[0];
            A114WWPMailSenderName = BC000F7_A114WWPMailSenderName[0];
            A123WWPMailStatus = BC000F7_A123WWPMailStatus[0];
            A133WWPMailCreated = BC000F7_A133WWPMailCreated[0];
            A134WWPMailScheduled = BC000F7_A134WWPMailScheduled[0];
            A128WWPMailProcessed = BC000F7_A128WWPMailProcessed[0];
            n128WWPMailProcessed = BC000F7_n128WWPMailProcessed[0];
            A129WWPMailDetail = BC000F7_A129WWPMailDetail[0];
            n129WWPMailDetail = BC000F7_n129WWPMailDetail[0];
            A66WWPNotificationCreated = BC000F7_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC000F7_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000F7_n64WWPNotificationId[0];
            ZM0F15( -5) ;
         }
         pr_default.close(5);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
      }

      protected void CheckExtendedTable0F15( )
      {
         nIsDirty_15 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A123WWPMailStatus == 1 ) || ( A123WWPMailStatus == 2 ) || ( A123WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Mail Status fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000F6 */
         pr_default.execute(4, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
            }
         }
         A66WWPNotificationCreated = BC000F6_A66WWPNotificationCreated[0];
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0F15( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0F15( )
      {
         /* Using cursor BC000F8 */
         pr_default.execute(6, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000F5 */
         pr_default.execute(3, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0F15( 5) ;
            RcdFound15 = 1;
            A122WWPMailId = BC000F5_A122WWPMailId[0];
            A111WWPMailSubject = BC000F5_A111WWPMailSubject[0];
            A103WWPMailBody = BC000F5_A103WWPMailBody[0];
            A112WWPMailTo = BC000F5_A112WWPMailTo[0];
            n112WWPMailTo = BC000F5_n112WWPMailTo[0];
            A125WWPMailCC = BC000F5_A125WWPMailCC[0];
            n125WWPMailCC = BC000F5_n125WWPMailCC[0];
            A126WWPMailBCC = BC000F5_A126WWPMailBCC[0];
            n126WWPMailBCC = BC000F5_n126WWPMailBCC[0];
            A113WWPMailSenderAddress = BC000F5_A113WWPMailSenderAddress[0];
            A114WWPMailSenderName = BC000F5_A114WWPMailSenderName[0];
            A123WWPMailStatus = BC000F5_A123WWPMailStatus[0];
            A133WWPMailCreated = BC000F5_A133WWPMailCreated[0];
            A134WWPMailScheduled = BC000F5_A134WWPMailScheduled[0];
            A128WWPMailProcessed = BC000F5_A128WWPMailProcessed[0];
            n128WWPMailProcessed = BC000F5_n128WWPMailProcessed[0];
            A129WWPMailDetail = BC000F5_A129WWPMailDetail[0];
            n129WWPMailDetail = BC000F5_n129WWPMailDetail[0];
            A64WWPNotificationId = BC000F5_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000F5_n64WWPNotificationId[0];
            Z122WWPMailId = A122WWPMailId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode15;
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
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
         CONFIRM_0F0( ) ;
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

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F4 */
            pr_default.execute(2, new Object[] {A122WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z111WWPMailSubject, BC000F4_A111WWPMailSubject[0]) != 0 ) || ( Z123WWPMailStatus != BC000F4_A123WWPMailStatus[0] ) || ( Z133WWPMailCreated != BC000F4_A133WWPMailCreated[0] ) || ( Z134WWPMailScheduled != BC000F4_A134WWPMailScheduled[0] ) || ( Z128WWPMailProcessed != BC000F4_A128WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z64WWPNotificationId != BC000F4_A64WWPNotificationId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F9 */
                     pr_default.execute(7, new Object[] {A111WWPMailSubject, A103WWPMailBody, n112WWPMailTo, A112WWPMailTo, n125WWPMailCC, A125WWPMailCC, n126WWPMailBCC, A126WWPMailBCC, A113WWPMailSenderAddress, A114WWPMailSenderName, A123WWPMailStatus, A133WWPMailCreated, A134WWPMailScheduled, n128WWPMailProcessed, A128WWPMailProcessed, n129WWPMailDetail, A129WWPMailDetail, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000F10 */
                     pr_default.execute(8);
                     A122WWPMailId = BC000F10_A122WWPMailId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F15( ) ;
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F11 */
                     pr_default.execute(9, new Object[] {A111WWPMailSubject, A103WWPMailBody, n112WWPMailTo, A112WWPMailTo, n125WWPMailCC, A125WWPMailCC, n126WWPMailBCC, A126WWPMailBCC, A113WWPMailSenderAddress, A114WWPMailSenderName, A123WWPMailStatus, A133WWPMailCreated, A134WWPMailScheduled, n128WWPMailProcessed, A128WWPMailProcessed, n129WWPMailDetail, A129WWPMailDetail, n64WWPNotificationId, A64WWPNotificationId, A122WWPMailId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F15( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  ScanKeyStart0F16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0F16( ) ;
                     Delete0F16( ) ;
                     ScanKeyNext0F16( ) ;
                  }
                  ScanKeyEnd0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F12 */
                     pr_default.execute(10, new Object[] {A122WWPMailId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
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
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000F13 */
            pr_default.execute(11, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A66WWPNotificationCreated = BC000F13_A66WWPNotificationCreated[0];
            pr_default.close(11);
         }
      }

      protected void ProcessNestedLevel0F16( )
      {
         nGXsfl_16_idx = 0;
         while ( nGXsfl_16_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
         {
            ReadRow0F16( ) ;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
            {
               if ( RcdFound16 == 0 )
               {
                  Gx_mode = "INS";
               }
               else
               {
                  Gx_mode = "UPD";
               }
            }
            if ( ! IsIns( ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0F16( ) ;
               if ( IsIns( ) )
               {
                  Gx_mode = "INS";
                  Insert0F16( ) ;
               }
               else
               {
                  if ( IsDlt( ) )
                  {
                     Gx_mode = "DLT";
                     Delete0F16( ) ;
                  }
                  else
                  {
                     Gx_mode = "UPD";
                     Update0F16( ) ;
                  }
               }
            }
            KeyVarsToRow16( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_16_idx))) ;
         }
         if ( AnyError == 0 )
         {
            /* Batch update SDT rows */
            nGXsfl_16_idx = 0;
            while ( nGXsfl_16_idx < bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Count )
            {
               ReadRow0F16( ) ;
               if ( String.IsNullOrEmpty(StringUtil.RTrim( Gx_mode)) )
               {
                  if ( RcdFound16 == 0 )
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
                  bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.RemoveElement(nGXsfl_16_idx);
                  nGXsfl_16_idx = (int)(nGXsfl_16_idx-1);
               }
               else
               {
                  Gx_mode = "UPD";
                  getByPrimaryKey0F16( ) ;
                  VarsToRow16( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_16_idx))) ;
               }
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F16( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         Gxremove16 = 0;
      }

      protected void ProcessLevel0F15( )
      {
         /* Save parent mode. */
         sMode15 = Gx_mode;
         ProcessNestedLevel0F16( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode15;
         /* ' Update level parameters */
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
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

      public void ScanKeyStart0F15( )
      {
         /* Using cursor BC000F14 */
         pr_default.execute(12, new Object[] {A122WWPMailId});
         RcdFound15 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound15 = 1;
            A122WWPMailId = BC000F14_A122WWPMailId[0];
            A111WWPMailSubject = BC000F14_A111WWPMailSubject[0];
            A103WWPMailBody = BC000F14_A103WWPMailBody[0];
            A112WWPMailTo = BC000F14_A112WWPMailTo[0];
            n112WWPMailTo = BC000F14_n112WWPMailTo[0];
            A125WWPMailCC = BC000F14_A125WWPMailCC[0];
            n125WWPMailCC = BC000F14_n125WWPMailCC[0];
            A126WWPMailBCC = BC000F14_A126WWPMailBCC[0];
            n126WWPMailBCC = BC000F14_n126WWPMailBCC[0];
            A113WWPMailSenderAddress = BC000F14_A113WWPMailSenderAddress[0];
            A114WWPMailSenderName = BC000F14_A114WWPMailSenderName[0];
            A123WWPMailStatus = BC000F14_A123WWPMailStatus[0];
            A133WWPMailCreated = BC000F14_A133WWPMailCreated[0];
            A134WWPMailScheduled = BC000F14_A134WWPMailScheduled[0];
            A128WWPMailProcessed = BC000F14_A128WWPMailProcessed[0];
            n128WWPMailProcessed = BC000F14_n128WWPMailProcessed[0];
            A129WWPMailDetail = BC000F14_A129WWPMailDetail[0];
            n129WWPMailDetail = BC000F14_n129WWPMailDetail[0];
            A66WWPNotificationCreated = BC000F14_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC000F14_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000F14_n64WWPNotificationId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound15 = 0;
         ScanKeyLoad0F15( ) ;
      }

      protected void ScanKeyLoad0F15( )
      {
         sMode15 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound15 = 1;
            A122WWPMailId = BC000F14_A122WWPMailId[0];
            A111WWPMailSubject = BC000F14_A111WWPMailSubject[0];
            A103WWPMailBody = BC000F14_A103WWPMailBody[0];
            A112WWPMailTo = BC000F14_A112WWPMailTo[0];
            n112WWPMailTo = BC000F14_n112WWPMailTo[0];
            A125WWPMailCC = BC000F14_A125WWPMailCC[0];
            n125WWPMailCC = BC000F14_n125WWPMailCC[0];
            A126WWPMailBCC = BC000F14_A126WWPMailBCC[0];
            n126WWPMailBCC = BC000F14_n126WWPMailBCC[0];
            A113WWPMailSenderAddress = BC000F14_A113WWPMailSenderAddress[0];
            A114WWPMailSenderName = BC000F14_A114WWPMailSenderName[0];
            A123WWPMailStatus = BC000F14_A123WWPMailStatus[0];
            A133WWPMailCreated = BC000F14_A133WWPMailCreated[0];
            A134WWPMailScheduled = BC000F14_A134WWPMailScheduled[0];
            A128WWPMailProcessed = BC000F14_A128WWPMailProcessed[0];
            n128WWPMailProcessed = BC000F14_n128WWPMailProcessed[0];
            A129WWPMailDetail = BC000F14_A129WWPMailDetail[0];
            n129WWPMailDetail = BC000F14_n129WWPMailDetail[0];
            A66WWPNotificationCreated = BC000F14_A66WWPNotificationCreated[0];
            A64WWPNotificationId = BC000F14_A64WWPNotificationId[0];
            n64WWPNotificationId = BC000F14_n64WWPNotificationId[0];
         }
         Gx_mode = sMode15;
      }

      protected void ScanKeyEnd0F15( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -7 )
         {
            Z122WWPMailId = A122WWPMailId;
            Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
            Z127WWPMailAttachmentFile = A127WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0F16( )
      {
      }

      protected void standaloneModal0F16( )
      {
      }

      protected void Load0F16( )
      {
         /* Using cursor BC000F15 */
         pr_default.execute(13, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound16 = 1;
            A127WWPMailAttachmentFile = BC000F15_A127WWPMailAttachmentFile[0];
            ZM0F16( -7) ;
         }
         pr_default.close(13);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         standaloneModal0F16( ) ;
         Gx_BScreen = 0;
      }

      protected void CloseExtendedTableCursors0F16( )
      {
      }

      protected void enableDisable0F16( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor BC000F16 */
         pr_default.execute(14, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(14);
      }

      protected void getByPrimaryKey0F16( )
      {
         /* Using cursor BC000F3 */
         pr_default.execute(1, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 7) ;
            RcdFound16 = 1;
            InitializeNonKey0F16( ) ;
            A135WWPMailAttachmentName = BC000F3_A135WWPMailAttachmentName[0];
            A127WWPMailAttachmentFile = BC000F3_A127WWPMailAttachmentFile[0];
            Z122WWPMailId = A122WWPMailId;
            Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F16( ) ;
            Load0F16( ) ;
            Gx_mode = sMode16;
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal0F16( ) ;
            Gx_mode = sMode16;
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F16( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000F2 */
            pr_default.execute(0, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F17 */
                     pr_default.execute(15, new Object[] {A122WWPMailId, A135WWPMailAttachmentName, A127WWPMailAttachmentFile});
                     pr_default.close(15);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(15) == 1) )
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000F18 */
                     pr_default.execute(16, new Object[] {A127WWPMailAttachmentFile, A122WWPMailId, A135WWPMailAttachmentName});
                     pr_default.close(16);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(16) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey0F16( ) ;
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
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void Delete0F16( )
      {
         Gx_mode = "DLT";
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000F19 */
                  pr_default.execute(17, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
                  pr_default.close(17);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
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
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal0F16( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F16( )
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

      public void ScanKeyStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor BC000F20 */
         pr_default.execute(18, new Object[] {A122WWPMailId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A135WWPMailAttachmentName = BC000F20_A135WWPMailAttachmentName[0];
            A127WWPMailAttachmentFile = BC000F20_A127WWPMailAttachmentFile[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound16 = 0;
         ScanKeyLoad0F16( ) ;
      }

      protected void ScanKeyLoad0F16( )
      {
         sMode16 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound16 = 1;
            A135WWPMailAttachmentName = BC000F20_A135WWPMailAttachmentName[0];
            A127WWPMailAttachmentFile = BC000F20_A127WWPMailAttachmentFile[0];
         }
         Gx_mode = sMode16;
      }

      protected void ScanKeyEnd0F16( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void AddRow0F15( )
      {
         VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
      }

      protected void ReadRow0F15( )
      {
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
      }

      protected void AddRow0F16( )
      {
         GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj16;
         obj16 = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments(context);
         VarsToRow16( obj16) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Add(obj16, 0);
         obj16.gxTpr_Mode = "UPD";
         obj16.gxTpr_Modified = 0;
      }

      protected void ReadRow0F16( )
      {
         nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
         RowToVars16( ((GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments)bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.Item(nGXsfl_16_idx)), 1) ;
      }

      protected void InitializeNonKey0F15( )
      {
         A111WWPMailSubject = "";
         A103WWPMailBody = "";
         A112WWPMailTo = "";
         n112WWPMailTo = false;
         A125WWPMailCC = "";
         n125WWPMailCC = false;
         A126WWPMailBCC = "";
         n126WWPMailBCC = false;
         A113WWPMailSenderAddress = "";
         A114WWPMailSenderName = "";
         A128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n128WWPMailProcessed = false;
         A129WWPMailDetail = "";
         n129WWPMailDetail = false;
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A123WWPMailStatus = 1;
         A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z111WWPMailSubject = "";
         Z123WWPMailStatus = 0;
         Z133WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z64WWPNotificationId = 0;
      }

      protected void InitAll0F15( )
      {
         A122WWPMailId = 0;
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A123WWPMailStatus = i123WWPMailStatus;
         A133WWPMailCreated = i133WWPMailCreated;
         A134WWPMailScheduled = i134WWPMailScheduled;
      }

      protected void InitializeNonKey0F16( )
      {
         A127WWPMailAttachmentFile = "";
      }

      protected void InitAll0F16( )
      {
         A135WWPMailAttachmentName = "";
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert0F16( )
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

      public void VarsToRow15( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj15 )
      {
         obj15.gxTpr_Mode = Gx_mode;
         obj15.gxTpr_Wwpmailsubject = A111WWPMailSubject;
         obj15.gxTpr_Wwpmailbody = A103WWPMailBody;
         obj15.gxTpr_Wwpmailto = A112WWPMailTo;
         obj15.gxTpr_Wwpmailcc = A125WWPMailCC;
         obj15.gxTpr_Wwpmailbcc = A126WWPMailBCC;
         obj15.gxTpr_Wwpmailsenderaddress = A113WWPMailSenderAddress;
         obj15.gxTpr_Wwpmailsendername = A114WWPMailSenderName;
         obj15.gxTpr_Wwpmailprocessed = A128WWPMailProcessed;
         obj15.gxTpr_Wwpmaildetail = A129WWPMailDetail;
         obj15.gxTpr_Wwpnotificationid = A64WWPNotificationId;
         obj15.gxTpr_Wwpnotificationcreated = A66WWPNotificationCreated;
         obj15.gxTpr_Wwpmailstatus = A123WWPMailStatus;
         obj15.gxTpr_Wwpmailcreated = A133WWPMailCreated;
         obj15.gxTpr_Wwpmailscheduled = A134WWPMailScheduled;
         obj15.gxTpr_Wwpmailid = A122WWPMailId;
         obj15.gxTpr_Wwpmailid_Z = Z122WWPMailId;
         obj15.gxTpr_Wwpmailsubject_Z = Z111WWPMailSubject;
         obj15.gxTpr_Wwpmailstatus_Z = Z123WWPMailStatus;
         obj15.gxTpr_Wwpmailcreated_Z = Z133WWPMailCreated;
         obj15.gxTpr_Wwpmailscheduled_Z = Z134WWPMailScheduled;
         obj15.gxTpr_Wwpmailprocessed_Z = Z128WWPMailProcessed;
         obj15.gxTpr_Wwpnotificationid_Z = Z64WWPNotificationId;
         obj15.gxTpr_Wwpnotificationcreated_Z = Z66WWPNotificationCreated;
         obj15.gxTpr_Wwpmailto_N = (short)(Convert.ToInt16(n112WWPMailTo));
         obj15.gxTpr_Wwpmailcc_N = (short)(Convert.ToInt16(n125WWPMailCC));
         obj15.gxTpr_Wwpmailbcc_N = (short)(Convert.ToInt16(n126WWPMailBCC));
         obj15.gxTpr_Wwpmailprocessed_N = (short)(Convert.ToInt16(n128WWPMailProcessed));
         obj15.gxTpr_Wwpmaildetail_N = (short)(Convert.ToInt16(n129WWPMailDetail));
         obj15.gxTpr_Wwpnotificationid_N = (short)(Convert.ToInt16(n64WWPNotificationId));
         obj15.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow15( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj15 )
      {
         obj15.gxTpr_Wwpmailid = A122WWPMailId;
         return  ;
      }

      public void RowToVars15( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail obj15 ,
                               int forceLoad )
      {
         Gx_mode = obj15.gxTpr_Mode;
         A111WWPMailSubject = obj15.gxTpr_Wwpmailsubject;
         A103WWPMailBody = obj15.gxTpr_Wwpmailbody;
         A112WWPMailTo = obj15.gxTpr_Wwpmailto;
         n112WWPMailTo = false;
         A125WWPMailCC = obj15.gxTpr_Wwpmailcc;
         n125WWPMailCC = false;
         A126WWPMailBCC = obj15.gxTpr_Wwpmailbcc;
         n126WWPMailBCC = false;
         A113WWPMailSenderAddress = obj15.gxTpr_Wwpmailsenderaddress;
         A114WWPMailSenderName = obj15.gxTpr_Wwpmailsendername;
         A128WWPMailProcessed = obj15.gxTpr_Wwpmailprocessed;
         n128WWPMailProcessed = false;
         A129WWPMailDetail = obj15.gxTpr_Wwpmaildetail;
         n129WWPMailDetail = false;
         A64WWPNotificationId = obj15.gxTpr_Wwpnotificationid;
         n64WWPNotificationId = false;
         A66WWPNotificationCreated = obj15.gxTpr_Wwpnotificationcreated;
         A123WWPMailStatus = obj15.gxTpr_Wwpmailstatus;
         A133WWPMailCreated = obj15.gxTpr_Wwpmailcreated;
         A134WWPMailScheduled = obj15.gxTpr_Wwpmailscheduled;
         A122WWPMailId = obj15.gxTpr_Wwpmailid;
         Z122WWPMailId = obj15.gxTpr_Wwpmailid_Z;
         Z111WWPMailSubject = obj15.gxTpr_Wwpmailsubject_Z;
         Z123WWPMailStatus = obj15.gxTpr_Wwpmailstatus_Z;
         Z133WWPMailCreated = obj15.gxTpr_Wwpmailcreated_Z;
         Z134WWPMailScheduled = obj15.gxTpr_Wwpmailscheduled_Z;
         Z128WWPMailProcessed = obj15.gxTpr_Wwpmailprocessed_Z;
         Z64WWPNotificationId = obj15.gxTpr_Wwpnotificationid_Z;
         Z66WWPNotificationCreated = obj15.gxTpr_Wwpnotificationcreated_Z;
         n112WWPMailTo = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpmailto_N));
         n125WWPMailCC = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpmailcc_N));
         n126WWPMailBCC = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpmailbcc_N));
         n128WWPMailProcessed = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpmailprocessed_N));
         n129WWPMailDetail = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpmaildetail_N));
         n64WWPNotificationId = (bool)(Convert.ToBoolean(obj15.gxTpr_Wwpnotificationid_N));
         Gx_mode = obj15.gxTpr_Mode;
         return  ;
      }

      public void VarsToRow16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj16 )
      {
         obj16.gxTpr_Mode = Gx_mode;
         obj16.gxTpr_Wwpmailattachmentfile = A127WWPMailAttachmentFile;
         obj16.gxTpr_Wwpmailattachmentname = A135WWPMailAttachmentName;
         obj16.gxTpr_Wwpmailattachmentname_Z = Z135WWPMailAttachmentName;
         obj16.gxTpr_Modified = nIsMod_16;
         return  ;
      }

      public void KeyVarsToRow16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj16 )
      {
         obj16.gxTpr_Wwpmailattachmentname = A135WWPMailAttachmentName;
         return  ;
      }

      public void RowToVars16( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail_Attachments obj16 ,
                               int forceLoad )
      {
         Gx_mode = obj16.gxTpr_Mode;
         A127WWPMailAttachmentFile = obj16.gxTpr_Wwpmailattachmentfile;
         A135WWPMailAttachmentName = obj16.gxTpr_Wwpmailattachmentname;
         Z135WWPMailAttachmentName = obj16.gxTpr_Wwpmailattachmentname_Z;
         nIsMod_16 = obj16.gxTpr_Modified;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A122WWPMailId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0F15( ) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z122WWPMailId = A122WWPMailId;
         }
         ZM0F15( -5) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0F16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z122WWPMailId = A122WWPMailId;
               Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
               ZM0F16( -7) ;
               OnLoadActions0F16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0F16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0F16( ) ;
            }
            ScanKeyEnd0F16( ) ;
         }
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         ScanKeyStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z122WWPMailId = A122WWPMailId;
         }
         ZM0F15( -5) ;
         OnLoadActions0F15( ) ;
         AddRow0F15( ) ;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Attachments.ClearCollection();
         if ( RcdFound15 == 1 )
         {
            ScanKeyStart0F16( ) ;
            nGXsfl_16_idx = 1;
            while ( RcdFound16 != 0 )
            {
               Z122WWPMailId = A122WWPMailId;
               Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
               ZM0F16( -7) ;
               OnLoadActions0F16( ) ;
               nRcdExists_16 = 1;
               nIsMod_16 = 0;
               AddRow0F16( ) ;
               nGXsfl_16_idx = (int)(nGXsfl_16_idx+1);
               ScanKeyNext0F16( ) ;
            }
            ScanKeyEnd0F16( ) ;
         }
         ScanKeyEnd0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0F15( ) ;
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A122WWPMailId != Z122WWPMailId )
               {
                  A122WWPMailId = Z122WWPMailId;
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
                  Update0F15( ) ;
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
                  if ( A122WWPMailId != Z122WWPMailId )
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
                        Insert0F15( ) ;
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
                        Insert0F15( ) ;
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         SaveImpl( ) ;
         VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
         AfterTrn( ) ;
         VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A122WWPMailId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_Mail);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_Mail.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0F15( ) ;
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
               VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0F15( ) ;
         if ( RcdFound15 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A122WWPMailId != Z122WWPMailId )
            {
               A122WWPMailId = Z122WWPMailId;
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
            if ( A122WWPMailId != Z122WWPMailId )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail_bc",pr_default);
         VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_Mail )
         {
            bcwwpbaseobjects_mail_WWP_Mail = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow15( bcwwpbaseobjects_mail_WWP_Mail) ;
            }
            else
            {
               RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_Mail.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars15( bcwwpbaseobjects_mail_WWP_Mail, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Mail WWP_Mail_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_Mail ;
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
            return "wwpmail_Execute" ;
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
         pr_default.close(3);
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
         sMode15 = "";
         Z111WWPMailSubject = "";
         A111WWPMailSubject = "";
         Z133WWPMailCreated = (DateTime)(DateTime.MinValue);
         A133WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z103WWPMailBody = "";
         A103WWPMailBody = "";
         Z112WWPMailTo = "";
         A112WWPMailTo = "";
         Z125WWPMailCC = "";
         A125WWPMailCC = "";
         Z126WWPMailBCC = "";
         A126WWPMailBCC = "";
         Z113WWPMailSenderAddress = "";
         A113WWPMailSenderAddress = "";
         Z114WWPMailSenderName = "";
         A114WWPMailSenderName = "";
         Z129WWPMailDetail = "";
         A129WWPMailDetail = "";
         BC000F7_A122WWPMailId = new long[1] ;
         BC000F7_A111WWPMailSubject = new string[] {""} ;
         BC000F7_A103WWPMailBody = new string[] {""} ;
         BC000F7_A112WWPMailTo = new string[] {""} ;
         BC000F7_n112WWPMailTo = new bool[] {false} ;
         BC000F7_A125WWPMailCC = new string[] {""} ;
         BC000F7_n125WWPMailCC = new bool[] {false} ;
         BC000F7_A126WWPMailBCC = new string[] {""} ;
         BC000F7_n126WWPMailBCC = new bool[] {false} ;
         BC000F7_A113WWPMailSenderAddress = new string[] {""} ;
         BC000F7_A114WWPMailSenderName = new string[] {""} ;
         BC000F7_A123WWPMailStatus = new short[1] ;
         BC000F7_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F7_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000F7_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000F7_n128WWPMailProcessed = new bool[] {false} ;
         BC000F7_A129WWPMailDetail = new string[] {""} ;
         BC000F7_n129WWPMailDetail = new bool[] {false} ;
         BC000F7_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F7_A64WWPNotificationId = new long[1] ;
         BC000F7_n64WWPNotificationId = new bool[] {false} ;
         BC000F6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F8_A122WWPMailId = new long[1] ;
         BC000F5_A122WWPMailId = new long[1] ;
         BC000F5_A111WWPMailSubject = new string[] {""} ;
         BC000F5_A103WWPMailBody = new string[] {""} ;
         BC000F5_A112WWPMailTo = new string[] {""} ;
         BC000F5_n112WWPMailTo = new bool[] {false} ;
         BC000F5_A125WWPMailCC = new string[] {""} ;
         BC000F5_n125WWPMailCC = new bool[] {false} ;
         BC000F5_A126WWPMailBCC = new string[] {""} ;
         BC000F5_n126WWPMailBCC = new bool[] {false} ;
         BC000F5_A113WWPMailSenderAddress = new string[] {""} ;
         BC000F5_A114WWPMailSenderName = new string[] {""} ;
         BC000F5_A123WWPMailStatus = new short[1] ;
         BC000F5_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F5_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000F5_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000F5_n128WWPMailProcessed = new bool[] {false} ;
         BC000F5_A129WWPMailDetail = new string[] {""} ;
         BC000F5_n129WWPMailDetail = new bool[] {false} ;
         BC000F5_A64WWPNotificationId = new long[1] ;
         BC000F5_n64WWPNotificationId = new bool[] {false} ;
         BC000F4_A122WWPMailId = new long[1] ;
         BC000F4_A111WWPMailSubject = new string[] {""} ;
         BC000F4_A103WWPMailBody = new string[] {""} ;
         BC000F4_A112WWPMailTo = new string[] {""} ;
         BC000F4_n112WWPMailTo = new bool[] {false} ;
         BC000F4_A125WWPMailCC = new string[] {""} ;
         BC000F4_n125WWPMailCC = new bool[] {false} ;
         BC000F4_A126WWPMailBCC = new string[] {""} ;
         BC000F4_n126WWPMailBCC = new bool[] {false} ;
         BC000F4_A113WWPMailSenderAddress = new string[] {""} ;
         BC000F4_A114WWPMailSenderName = new string[] {""} ;
         BC000F4_A123WWPMailStatus = new short[1] ;
         BC000F4_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000F4_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000F4_n128WWPMailProcessed = new bool[] {false} ;
         BC000F4_A129WWPMailDetail = new string[] {""} ;
         BC000F4_n129WWPMailDetail = new bool[] {false} ;
         BC000F4_A64WWPNotificationId = new long[1] ;
         BC000F4_n64WWPNotificationId = new bool[] {false} ;
         BC000F10_A122WWPMailId = new long[1] ;
         BC000F13_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F14_A122WWPMailId = new long[1] ;
         BC000F14_A111WWPMailSubject = new string[] {""} ;
         BC000F14_A103WWPMailBody = new string[] {""} ;
         BC000F14_A112WWPMailTo = new string[] {""} ;
         BC000F14_n112WWPMailTo = new bool[] {false} ;
         BC000F14_A125WWPMailCC = new string[] {""} ;
         BC000F14_n125WWPMailCC = new bool[] {false} ;
         BC000F14_A126WWPMailBCC = new string[] {""} ;
         BC000F14_n126WWPMailBCC = new bool[] {false} ;
         BC000F14_A113WWPMailSenderAddress = new string[] {""} ;
         BC000F14_A114WWPMailSenderName = new string[] {""} ;
         BC000F14_A123WWPMailStatus = new short[1] ;
         BC000F14_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F14_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         BC000F14_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         BC000F14_n128WWPMailProcessed = new bool[] {false} ;
         BC000F14_A129WWPMailDetail = new string[] {""} ;
         BC000F14_n129WWPMailDetail = new bool[] {false} ;
         BC000F14_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         BC000F14_A64WWPNotificationId = new long[1] ;
         BC000F14_n64WWPNotificationId = new bool[] {false} ;
         Z135WWPMailAttachmentName = "";
         A135WWPMailAttachmentName = "";
         Z127WWPMailAttachmentFile = "";
         A127WWPMailAttachmentFile = "";
         BC000F15_A122WWPMailId = new long[1] ;
         BC000F15_A135WWPMailAttachmentName = new string[] {""} ;
         BC000F15_A127WWPMailAttachmentFile = new string[] {""} ;
         BC000F16_A122WWPMailId = new long[1] ;
         BC000F16_A135WWPMailAttachmentName = new string[] {""} ;
         BC000F3_A122WWPMailId = new long[1] ;
         BC000F3_A135WWPMailAttachmentName = new string[] {""} ;
         BC000F3_A127WWPMailAttachmentFile = new string[] {""} ;
         sMode16 = "";
         BC000F2_A122WWPMailId = new long[1] ;
         BC000F2_A135WWPMailAttachmentName = new string[] {""} ;
         BC000F2_A127WWPMailAttachmentFile = new string[] {""} ;
         BC000F20_A122WWPMailId = new long[1] ;
         BC000F20_A135WWPMailAttachmentName = new string[] {""} ;
         BC000F20_A127WWPMailAttachmentFile = new string[] {""} ;
         i133WWPMailCreated = (DateTime)(DateTime.MinValue);
         i134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail_bc__default(),
            new Object[][] {
                new Object[] {
               BC000F2_A122WWPMailId, BC000F2_A135WWPMailAttachmentName, BC000F2_A127WWPMailAttachmentFile
               }
               , new Object[] {
               BC000F3_A122WWPMailId, BC000F3_A135WWPMailAttachmentName, BC000F3_A127WWPMailAttachmentFile
               }
               , new Object[] {
               BC000F4_A122WWPMailId, BC000F4_A111WWPMailSubject, BC000F4_A103WWPMailBody, BC000F4_A112WWPMailTo, BC000F4_n112WWPMailTo, BC000F4_A125WWPMailCC, BC000F4_n125WWPMailCC, BC000F4_A126WWPMailBCC, BC000F4_n126WWPMailBCC, BC000F4_A113WWPMailSenderAddress,
               BC000F4_A114WWPMailSenderName, BC000F4_A123WWPMailStatus, BC000F4_A133WWPMailCreated, BC000F4_A134WWPMailScheduled, BC000F4_A128WWPMailProcessed, BC000F4_n128WWPMailProcessed, BC000F4_A129WWPMailDetail, BC000F4_n129WWPMailDetail, BC000F4_A64WWPNotificationId, BC000F4_n64WWPNotificationId
               }
               , new Object[] {
               BC000F5_A122WWPMailId, BC000F5_A111WWPMailSubject, BC000F5_A103WWPMailBody, BC000F5_A112WWPMailTo, BC000F5_n112WWPMailTo, BC000F5_A125WWPMailCC, BC000F5_n125WWPMailCC, BC000F5_A126WWPMailBCC, BC000F5_n126WWPMailBCC, BC000F5_A113WWPMailSenderAddress,
               BC000F5_A114WWPMailSenderName, BC000F5_A123WWPMailStatus, BC000F5_A133WWPMailCreated, BC000F5_A134WWPMailScheduled, BC000F5_A128WWPMailProcessed, BC000F5_n128WWPMailProcessed, BC000F5_A129WWPMailDetail, BC000F5_n129WWPMailDetail, BC000F5_A64WWPNotificationId, BC000F5_n64WWPNotificationId
               }
               , new Object[] {
               BC000F6_A66WWPNotificationCreated
               }
               , new Object[] {
               BC000F7_A122WWPMailId, BC000F7_A111WWPMailSubject, BC000F7_A103WWPMailBody, BC000F7_A112WWPMailTo, BC000F7_n112WWPMailTo, BC000F7_A125WWPMailCC, BC000F7_n125WWPMailCC, BC000F7_A126WWPMailBCC, BC000F7_n126WWPMailBCC, BC000F7_A113WWPMailSenderAddress,
               BC000F7_A114WWPMailSenderName, BC000F7_A123WWPMailStatus, BC000F7_A133WWPMailCreated, BC000F7_A134WWPMailScheduled, BC000F7_A128WWPMailProcessed, BC000F7_n128WWPMailProcessed, BC000F7_A129WWPMailDetail, BC000F7_n129WWPMailDetail, BC000F7_A66WWPNotificationCreated, BC000F7_A64WWPNotificationId,
               BC000F7_n64WWPNotificationId
               }
               , new Object[] {
               BC000F8_A122WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F10_A122WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F13_A66WWPNotificationCreated
               }
               , new Object[] {
               BC000F14_A122WWPMailId, BC000F14_A111WWPMailSubject, BC000F14_A103WWPMailBody, BC000F14_A112WWPMailTo, BC000F14_n112WWPMailTo, BC000F14_A125WWPMailCC, BC000F14_n125WWPMailCC, BC000F14_A126WWPMailBCC, BC000F14_n126WWPMailBCC, BC000F14_A113WWPMailSenderAddress,
               BC000F14_A114WWPMailSenderName, BC000F14_A123WWPMailStatus, BC000F14_A133WWPMailCreated, BC000F14_A134WWPMailScheduled, BC000F14_A128WWPMailProcessed, BC000F14_n128WWPMailProcessed, BC000F14_A129WWPMailDetail, BC000F14_n129WWPMailDetail, BC000F14_A66WWPNotificationCreated, BC000F14_A64WWPNotificationId,
               BC000F14_n64WWPNotificationId
               }
               , new Object[] {
               BC000F15_A122WWPMailId, BC000F15_A135WWPMailAttachmentName, BC000F15_A127WWPMailAttachmentFile
               }
               , new Object[] {
               BC000F16_A122WWPMailId, BC000F16_A135WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000F20_A122WWPMailId, BC000F20_A135WWPMailAttachmentName, BC000F20_A127WWPMailAttachmentFile
               }
            }
         );
         Z134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z123WWPMailStatus = 1;
         A123WWPMailStatus = 1;
         i123WWPMailStatus = 1;
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short nIsMod_16 ;
      private short RcdFound16 ;
      private short GX_JID ;
      private short Z123WWPMailStatus ;
      private short A123WWPMailStatus ;
      private short Gx_BScreen ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private short nRcdExists_16 ;
      private short Gxremove16 ;
      private short nIsDirty_16 ;
      private short i123WWPMailStatus ;
      private int trnEnded ;
      private int nGXsfl_16_idx=1 ;
      private long Z122WWPMailId ;
      private long A122WWPMailId ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode15 ;
      private string sMode16 ;
      private DateTime Z133WWPMailCreated ;
      private DateTime A133WWPMailCreated ;
      private DateTime Z134WWPMailScheduled ;
      private DateTime A134WWPMailScheduled ;
      private DateTime Z128WWPMailProcessed ;
      private DateTime A128WWPMailProcessed ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime i133WWPMailCreated ;
      private DateTime i134WWPMailScheduled ;
      private bool n112WWPMailTo ;
      private bool n125WWPMailCC ;
      private bool n126WWPMailBCC ;
      private bool n128WWPMailProcessed ;
      private bool n129WWPMailDetail ;
      private bool n64WWPNotificationId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z103WWPMailBody ;
      private string A103WWPMailBody ;
      private string Z112WWPMailTo ;
      private string A112WWPMailTo ;
      private string Z125WWPMailCC ;
      private string A125WWPMailCC ;
      private string Z126WWPMailBCC ;
      private string A126WWPMailBCC ;
      private string Z113WWPMailSenderAddress ;
      private string A113WWPMailSenderAddress ;
      private string Z114WWPMailSenderName ;
      private string A114WWPMailSenderName ;
      private string Z129WWPMailDetail ;
      private string A129WWPMailDetail ;
      private string Z127WWPMailAttachmentFile ;
      private string A127WWPMailAttachmentFile ;
      private string Z111WWPMailSubject ;
      private string A111WWPMailSubject ;
      private string Z135WWPMailAttachmentName ;
      private string A135WWPMailAttachmentName ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_Mail bcwwpbaseobjects_mail_WWP_Mail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000F7_A122WWPMailId ;
      private string[] BC000F7_A111WWPMailSubject ;
      private string[] BC000F7_A103WWPMailBody ;
      private string[] BC000F7_A112WWPMailTo ;
      private bool[] BC000F7_n112WWPMailTo ;
      private string[] BC000F7_A125WWPMailCC ;
      private bool[] BC000F7_n125WWPMailCC ;
      private string[] BC000F7_A126WWPMailBCC ;
      private bool[] BC000F7_n126WWPMailBCC ;
      private string[] BC000F7_A113WWPMailSenderAddress ;
      private string[] BC000F7_A114WWPMailSenderName ;
      private short[] BC000F7_A123WWPMailStatus ;
      private DateTime[] BC000F7_A133WWPMailCreated ;
      private DateTime[] BC000F7_A134WWPMailScheduled ;
      private DateTime[] BC000F7_A128WWPMailProcessed ;
      private bool[] BC000F7_n128WWPMailProcessed ;
      private string[] BC000F7_A129WWPMailDetail ;
      private bool[] BC000F7_n129WWPMailDetail ;
      private DateTime[] BC000F7_A66WWPNotificationCreated ;
      private long[] BC000F7_A64WWPNotificationId ;
      private bool[] BC000F7_n64WWPNotificationId ;
      private DateTime[] BC000F6_A66WWPNotificationCreated ;
      private long[] BC000F8_A122WWPMailId ;
      private long[] BC000F5_A122WWPMailId ;
      private string[] BC000F5_A111WWPMailSubject ;
      private string[] BC000F5_A103WWPMailBody ;
      private string[] BC000F5_A112WWPMailTo ;
      private bool[] BC000F5_n112WWPMailTo ;
      private string[] BC000F5_A125WWPMailCC ;
      private bool[] BC000F5_n125WWPMailCC ;
      private string[] BC000F5_A126WWPMailBCC ;
      private bool[] BC000F5_n126WWPMailBCC ;
      private string[] BC000F5_A113WWPMailSenderAddress ;
      private string[] BC000F5_A114WWPMailSenderName ;
      private short[] BC000F5_A123WWPMailStatus ;
      private DateTime[] BC000F5_A133WWPMailCreated ;
      private DateTime[] BC000F5_A134WWPMailScheduled ;
      private DateTime[] BC000F5_A128WWPMailProcessed ;
      private bool[] BC000F5_n128WWPMailProcessed ;
      private string[] BC000F5_A129WWPMailDetail ;
      private bool[] BC000F5_n129WWPMailDetail ;
      private long[] BC000F5_A64WWPNotificationId ;
      private bool[] BC000F5_n64WWPNotificationId ;
      private long[] BC000F4_A122WWPMailId ;
      private string[] BC000F4_A111WWPMailSubject ;
      private string[] BC000F4_A103WWPMailBody ;
      private string[] BC000F4_A112WWPMailTo ;
      private bool[] BC000F4_n112WWPMailTo ;
      private string[] BC000F4_A125WWPMailCC ;
      private bool[] BC000F4_n125WWPMailCC ;
      private string[] BC000F4_A126WWPMailBCC ;
      private bool[] BC000F4_n126WWPMailBCC ;
      private string[] BC000F4_A113WWPMailSenderAddress ;
      private string[] BC000F4_A114WWPMailSenderName ;
      private short[] BC000F4_A123WWPMailStatus ;
      private DateTime[] BC000F4_A133WWPMailCreated ;
      private DateTime[] BC000F4_A134WWPMailScheduled ;
      private DateTime[] BC000F4_A128WWPMailProcessed ;
      private bool[] BC000F4_n128WWPMailProcessed ;
      private string[] BC000F4_A129WWPMailDetail ;
      private bool[] BC000F4_n129WWPMailDetail ;
      private long[] BC000F4_A64WWPNotificationId ;
      private bool[] BC000F4_n64WWPNotificationId ;
      private long[] BC000F10_A122WWPMailId ;
      private DateTime[] BC000F13_A66WWPNotificationCreated ;
      private long[] BC000F14_A122WWPMailId ;
      private string[] BC000F14_A111WWPMailSubject ;
      private string[] BC000F14_A103WWPMailBody ;
      private string[] BC000F14_A112WWPMailTo ;
      private bool[] BC000F14_n112WWPMailTo ;
      private string[] BC000F14_A125WWPMailCC ;
      private bool[] BC000F14_n125WWPMailCC ;
      private string[] BC000F14_A126WWPMailBCC ;
      private bool[] BC000F14_n126WWPMailBCC ;
      private string[] BC000F14_A113WWPMailSenderAddress ;
      private string[] BC000F14_A114WWPMailSenderName ;
      private short[] BC000F14_A123WWPMailStatus ;
      private DateTime[] BC000F14_A133WWPMailCreated ;
      private DateTime[] BC000F14_A134WWPMailScheduled ;
      private DateTime[] BC000F14_A128WWPMailProcessed ;
      private bool[] BC000F14_n128WWPMailProcessed ;
      private string[] BC000F14_A129WWPMailDetail ;
      private bool[] BC000F14_n129WWPMailDetail ;
      private DateTime[] BC000F14_A66WWPNotificationCreated ;
      private long[] BC000F14_A64WWPNotificationId ;
      private bool[] BC000F14_n64WWPNotificationId ;
      private long[] BC000F15_A122WWPMailId ;
      private string[] BC000F15_A135WWPMailAttachmentName ;
      private string[] BC000F15_A127WWPMailAttachmentFile ;
      private long[] BC000F16_A122WWPMailId ;
      private string[] BC000F16_A135WWPMailAttachmentName ;
      private long[] BC000F3_A122WWPMailId ;
      private string[] BC000F3_A135WWPMailAttachmentName ;
      private string[] BC000F3_A127WWPMailAttachmentFile ;
      private long[] BC000F2_A122WWPMailId ;
      private string[] BC000F2_A135WWPMailAttachmentName ;
      private string[] BC000F2_A127WWPMailAttachmentFile ;
      private long[] BC000F20_A122WWPMailId ;
      private string[] BC000F20_A135WWPMailAttachmentName ;
      private string[] BC000F20_A127WWPMailAttachmentFile ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mail_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new UpdateCursor(def[16])
       ,new UpdateCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000F7;
        prmBC000F7 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F6;
        prmBC000F6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000F8;
        prmBC000F8 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F5;
        prmBC000F5 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F4;
        prmBC000F4 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F9;
        prmBC000F9 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000F10;
        prmBC000F10 = new Object[] {
        };
        Object[] prmBC000F11;
        prmBC000F11 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F12;
        prmBC000F12 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F13;
        prmBC000F13 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000F14;
        prmBC000F14 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmBC000F15;
        prmBC000F15 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F16;
        prmBC000F16 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F3;
        prmBC000F3 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F2;
        prmBC000F2 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F17;
        prmBC000F17 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000F18;
        prmBC000F18 = new Object[] {
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F19;
        prmBC000F19 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmBC000F20;
        prmBC000F20 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000F2", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName  FOR UPDATE OF WWP_MailAttachments",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F3", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F4", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId  FOR UPDATE OF WWP_Mail",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F5", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F7", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F8", "SELECT WWPMailId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F9", "SAVEPOINT gxupdate;INSERT INTO WWP_Mail(WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId) VALUES(:WWPMailSubject, :WWPMailBody, :WWPMailTo, :WWPMailCC, :WWPMailBCC, :WWPMailSenderAddress, :WWPMailSenderName, :WWPMailStatus, :WWPMailCreated, :WWPMailScheduled, :WWPMailProcessed, :WWPMailDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F9)
           ,new CursorDef("BC000F10", "SELECT currval('WWPMailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F11", "SAVEPOINT gxupdate;UPDATE WWP_Mail SET WWPMailSubject=:WWPMailSubject, WWPMailBody=:WWPMailBody, WWPMailTo=:WWPMailTo, WWPMailCC=:WWPMailCC, WWPMailBCC=:WWPMailBCC, WWPMailSenderAddress=:WWPMailSenderAddress, WWPMailSenderName=:WWPMailSenderName, WWPMailStatus=:WWPMailStatus, WWPMailCreated=:WWPMailCreated, WWPMailScheduled=:WWPMailScheduled, WWPMailProcessed=:WWPMailProcessed, WWPMailDetail=:WWPMailDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F11)
           ,new CursorDef("BC000F12", "SAVEPOINT gxupdate;DELETE FROM WWP_Mail  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F12)
           ,new CursorDef("BC000F13", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F14", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F15", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId and WWPMailAttachmentName = ( :WWPMailAttachmentName) ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F15,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F16", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000F17", "SAVEPOINT gxupdate;INSERT INTO WWP_MailAttachments(WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile) VALUES(:WWPMailId, :WWPMailAttachmentName, :WWPMailAttachmentFile);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000F17)
           ,new CursorDef("BC000F18", "SAVEPOINT gxupdate;UPDATE WWP_MailAttachments SET WWPMailAttachmentFile=:WWPMailAttachmentFile  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F18)
           ,new CursorDef("BC000F19", "SAVEPOINT gxupdate;DELETE FROM WWP_MailAttachments  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000F19)
           ,new CursorDef("BC000F20", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000F20,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
