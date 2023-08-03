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
   public class wwp_notificationdefinition_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_notificationdefinition_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notificationdefinition_bc( IGxContext context )
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
         ReadRow0C12( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0C12( ) ;
         standaloneModal( ) ;
         AddRow0C12( ) ;
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
               Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
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

      protected void CONFIRM_0C0( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0C12( ) ;
            }
            else
            {
               CheckExtendedTable0C12( ) ;
               if ( AnyError == 0 )
               {
                  ZM0C12( 5) ;
               }
               CloseExtendedTableCursors0C12( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0C12( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
            Z72WWPNotificationDefinitionAppli = A72WWPNotificationDefinitionAppli;
            Z73WWPNotificationDefinitionAllow = A73WWPNotificationDefinitionAllow;
            Z71WWPNotificationDefinitionDescr = A71WWPNotificationDefinitionDescr;
            Z104WWPNotificationDefinitionIcon = A104WWPNotificationDefinitionIcon;
            Z105WWPNotificationDefinitionTitle = A105WWPNotificationDefinitionTitle;
            Z106WWPNotificationDefinitionShort = A106WWPNotificationDefinitionShort;
            Z107WWPNotificationDefinitionLongD = A107WWPNotificationDefinitionLongD;
            Z108WWPNotificationDefinitionLink = A108WWPNotificationDefinitionLink;
            Z109WWPNotificationDefinitionSecFu = A109WWPNotificationDefinitionSecFu;
            Z62WWPEntityId = A62WWPEntityId;
            Z110WWPNotificationDefinitionIsAut = A110WWPNotificationDefinitionIsAut;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z63WWPEntityName = A63WWPEntityName;
            Z110WWPNotificationDefinitionIsAut = A110WWPNotificationDefinitionIsAut;
         }
         if ( GX_JID == -4 )
         {
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
            Z72WWPNotificationDefinitionAppli = A72WWPNotificationDefinitionAppli;
            Z73WWPNotificationDefinitionAllow = A73WWPNotificationDefinitionAllow;
            Z71WWPNotificationDefinitionDescr = A71WWPNotificationDefinitionDescr;
            Z104WWPNotificationDefinitionIcon = A104WWPNotificationDefinitionIcon;
            Z105WWPNotificationDefinitionTitle = A105WWPNotificationDefinitionTitle;
            Z106WWPNotificationDefinitionShort = A106WWPNotificationDefinitionShort;
            Z107WWPNotificationDefinitionLongD = A107WWPNotificationDefinitionLongD;
            Z108WWPNotificationDefinitionLink = A108WWPNotificationDefinitionLink;
            Z109WWPNotificationDefinitionSecFu = A109WWPNotificationDefinitionSecFu;
            Z62WWPEntityId = A62WWPEntityId;
            Z63WWPEntityName = A63WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0C12( )
      {
         /* Using cursor BC000C5 */
         pr_default.execute(3, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound12 = 1;
            A101WWPNotificationDefinitionName = BC000C5_A101WWPNotificationDefinitionName[0];
            A72WWPNotificationDefinitionAppli = BC000C5_A72WWPNotificationDefinitionAppli[0];
            A73WWPNotificationDefinitionAllow = BC000C5_A73WWPNotificationDefinitionAllow[0];
            A71WWPNotificationDefinitionDescr = BC000C5_A71WWPNotificationDefinitionDescr[0];
            A104WWPNotificationDefinitionIcon = BC000C5_A104WWPNotificationDefinitionIcon[0];
            A105WWPNotificationDefinitionTitle = BC000C5_A105WWPNotificationDefinitionTitle[0];
            A106WWPNotificationDefinitionShort = BC000C5_A106WWPNotificationDefinitionShort[0];
            A107WWPNotificationDefinitionLongD = BC000C5_A107WWPNotificationDefinitionLongD[0];
            A108WWPNotificationDefinitionLink = BC000C5_A108WWPNotificationDefinitionLink[0];
            A63WWPEntityName = BC000C5_A63WWPEntityName[0];
            A109WWPNotificationDefinitionSecFu = BC000C5_A109WWPNotificationDefinitionSecFu[0];
            A62WWPEntityId = BC000C5_A62WWPEntityId[0];
            ZM0C12( -4) ;
         }
         pr_default.close(3);
         OnLoadActions0C12( ) ;
      }

      protected void OnLoadActions0C12( )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109WWPNotificationDefinitionSecFu)) )
         {
            A110WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            GXt_boolean1 = A110WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  A109WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A110WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CheckExtendedTable0C12( )
      {
         nIsDirty_12 = 0;
         standaloneModal( ) ;
         if ( ! ( ( A72WWPNotificationDefinitionAppli == 1 ) || ( A72WWPNotificationDefinitionAppli == 2 ) ) )
         {
            GX_msglist.addItem("Campo Notification Definition Applies To fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
         if ( ! ( GxRegex.IsMatch(A108WWPNotificationDefinitionLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Definition Default Link não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
         /* Using cursor BC000C4 */
         pr_default.execute(2, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = BC000C4_A63WWPEntityName[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A109WWPNotificationDefinitionSecFu)) )
         {
            nIsDirty_12 = 1;
            A110WWPNotificationDefinitionIsAut = true;
         }
         else
         {
            nIsDirty_12 = 1;
            GXt_boolean1 = A110WWPNotificationDefinitionIsAut;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  A109WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
            A110WWPNotificationDefinitionIsAut = GXt_boolean1;
         }
      }

      protected void CloseExtendedTableCursors0C12( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0C12( )
      {
         /* Using cursor BC000C6 */
         pr_default.execute(4, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound12 = 1;
         }
         else
         {
            RcdFound12 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000C3 */
         pr_default.execute(1, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0C12( 4) ;
            RcdFound12 = 1;
            A65WWPNotificationDefinitionId = BC000C3_A65WWPNotificationDefinitionId[0];
            A101WWPNotificationDefinitionName = BC000C3_A101WWPNotificationDefinitionName[0];
            A72WWPNotificationDefinitionAppli = BC000C3_A72WWPNotificationDefinitionAppli[0];
            A73WWPNotificationDefinitionAllow = BC000C3_A73WWPNotificationDefinitionAllow[0];
            A71WWPNotificationDefinitionDescr = BC000C3_A71WWPNotificationDefinitionDescr[0];
            A104WWPNotificationDefinitionIcon = BC000C3_A104WWPNotificationDefinitionIcon[0];
            A105WWPNotificationDefinitionTitle = BC000C3_A105WWPNotificationDefinitionTitle[0];
            A106WWPNotificationDefinitionShort = BC000C3_A106WWPNotificationDefinitionShort[0];
            A107WWPNotificationDefinitionLongD = BC000C3_A107WWPNotificationDefinitionLongD[0];
            A108WWPNotificationDefinitionLink = BC000C3_A108WWPNotificationDefinitionLink[0];
            A109WWPNotificationDefinitionSecFu = BC000C3_A109WWPNotificationDefinitionSecFu[0];
            A62WWPEntityId = BC000C3_A62WWPEntityId[0];
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0C12( ) ;
            if ( AnyError == 1 )
            {
               RcdFound12 = 0;
               InitializeNonKey0C12( ) ;
            }
            Gx_mode = sMode12;
         }
         else
         {
            RcdFound12 = 0;
            InitializeNonKey0C12( ) ;
            sMode12 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode12;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0C12( ) ;
         if ( RcdFound12 == 0 )
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
         CONFIRM_0C0( ) ;
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

      protected void CheckOptimisticConcurrency0C12( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000C2 */
            pr_default.execute(0, new Object[] {A65WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z101WWPNotificationDefinitionName, BC000C2_A101WWPNotificationDefinitionName[0]) != 0 ) || ( Z72WWPNotificationDefinitionAppli != BC000C2_A72WWPNotificationDefinitionAppli[0] ) || ( Z73WWPNotificationDefinitionAllow != BC000C2_A73WWPNotificationDefinitionAllow[0] ) || ( StringUtil.StrCmp(Z71WWPNotificationDefinitionDescr, BC000C2_A71WWPNotificationDefinitionDescr[0]) != 0 ) || ( StringUtil.StrCmp(Z104WWPNotificationDefinitionIcon, BC000C2_A104WWPNotificationDefinitionIcon[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z105WWPNotificationDefinitionTitle, BC000C2_A105WWPNotificationDefinitionTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z106WWPNotificationDefinitionShort, BC000C2_A106WWPNotificationDefinitionShort[0]) != 0 ) || ( StringUtil.StrCmp(Z107WWPNotificationDefinitionLongD, BC000C2_A107WWPNotificationDefinitionLongD[0]) != 0 ) || ( StringUtil.StrCmp(Z108WWPNotificationDefinitionLink, BC000C2_A108WWPNotificationDefinitionLink[0]) != 0 ) || ( StringUtil.StrCmp(Z109WWPNotificationDefinitionSecFu, BC000C2_A109WWPNotificationDefinitionSecFu[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z62WWPEntityId != BC000C2_A62WWPEntityId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_NotificationDefinition"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0C12( 0) ;
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C7 */
                     pr_default.execute(5, new Object[] {A101WWPNotificationDefinitionName, A72WWPNotificationDefinitionAppli, A73WWPNotificationDefinitionAllow, A71WWPNotificationDefinitionDescr, A104WWPNotificationDefinitionIcon, A105WWPNotificationDefinitionTitle, A106WWPNotificationDefinitionShort, A107WWPNotificationDefinitionLongD, A108WWPNotificationDefinitionLink, A109WWPNotificationDefinitionSecFu, A62WWPEntityId});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000C8 */
                     pr_default.execute(6);
                     A65WWPNotificationDefinitionId = BC000C8_A65WWPNotificationDefinitionId[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
               Load0C12( ) ;
            }
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void Update0C12( )
      {
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0C12( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0C12( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000C9 */
                     pr_default.execute(7, new Object[] {A101WWPNotificationDefinitionName, A72WWPNotificationDefinitionAppli, A73WWPNotificationDefinitionAllow, A71WWPNotificationDefinitionDescr, A104WWPNotificationDefinitionIcon, A105WWPNotificationDefinitionTitle, A106WWPNotificationDefinitionShort, A107WWPNotificationDefinitionLongD, A108WWPNotificationDefinitionLink, A109WWPNotificationDefinitionSecFu, A62WWPEntityId, A65WWPNotificationDefinitionId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_NotificationDefinition"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0C12( ) ;
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
            EndLevel0C12( ) ;
         }
         CloseExtendedTableCursors0C12( ) ;
      }

      protected void DeferredUpdate0C12( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0C12( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0C12( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0C12( ) ;
            AfterConfirm0C12( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0C12( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000C10 */
                  pr_default.execute(8, new Object[] {A65WWPNotificationDefinitionId});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_NotificationDefinition");
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
         sMode12 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0C12( ) ;
         Gx_mode = sMode12;
      }

      protected void OnDeleteControls0C12( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000C11 */
            pr_default.execute(9, new Object[] {A62WWPEntityId});
            A63WWPEntityName = BC000C11_A63WWPEntityName[0];
            pr_default.close(9);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( A109WWPNotificationDefinitionSecFu)) )
            {
               A110WWPNotificationDefinitionIsAut = true;
            }
            else
            {
               GXt_boolean1 = A110WWPNotificationDefinitionIsAut;
               new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  A109WWPNotificationDefinitionSecFu, out  GXt_boolean1) ;
               A110WWPNotificationDefinitionIsAut = GXt_boolean1;
            }
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000C12 */
            pr_default.execute(10, new Object[] {A65WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000C13 */
            pr_default.execute(11, new Object[] {A65WWPNotificationDefinitionId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0C12( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0C12( ) ;
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

      public void ScanKeyStart0C12( )
      {
         /* Using cursor BC000C14 */
         pr_default.execute(12, new Object[] {A65WWPNotificationDefinitionId});
         RcdFound12 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound12 = 1;
            A65WWPNotificationDefinitionId = BC000C14_A65WWPNotificationDefinitionId[0];
            A101WWPNotificationDefinitionName = BC000C14_A101WWPNotificationDefinitionName[0];
            A72WWPNotificationDefinitionAppli = BC000C14_A72WWPNotificationDefinitionAppli[0];
            A73WWPNotificationDefinitionAllow = BC000C14_A73WWPNotificationDefinitionAllow[0];
            A71WWPNotificationDefinitionDescr = BC000C14_A71WWPNotificationDefinitionDescr[0];
            A104WWPNotificationDefinitionIcon = BC000C14_A104WWPNotificationDefinitionIcon[0];
            A105WWPNotificationDefinitionTitle = BC000C14_A105WWPNotificationDefinitionTitle[0];
            A106WWPNotificationDefinitionShort = BC000C14_A106WWPNotificationDefinitionShort[0];
            A107WWPNotificationDefinitionLongD = BC000C14_A107WWPNotificationDefinitionLongD[0];
            A108WWPNotificationDefinitionLink = BC000C14_A108WWPNotificationDefinitionLink[0];
            A63WWPEntityName = BC000C14_A63WWPEntityName[0];
            A109WWPNotificationDefinitionSecFu = BC000C14_A109WWPNotificationDefinitionSecFu[0];
            A62WWPEntityId = BC000C14_A62WWPEntityId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0C12( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound12 = 0;
         ScanKeyLoad0C12( ) ;
      }

      protected void ScanKeyLoad0C12( )
      {
         sMode12 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound12 = 1;
            A65WWPNotificationDefinitionId = BC000C14_A65WWPNotificationDefinitionId[0];
            A101WWPNotificationDefinitionName = BC000C14_A101WWPNotificationDefinitionName[0];
            A72WWPNotificationDefinitionAppli = BC000C14_A72WWPNotificationDefinitionAppli[0];
            A73WWPNotificationDefinitionAllow = BC000C14_A73WWPNotificationDefinitionAllow[0];
            A71WWPNotificationDefinitionDescr = BC000C14_A71WWPNotificationDefinitionDescr[0];
            A104WWPNotificationDefinitionIcon = BC000C14_A104WWPNotificationDefinitionIcon[0];
            A105WWPNotificationDefinitionTitle = BC000C14_A105WWPNotificationDefinitionTitle[0];
            A106WWPNotificationDefinitionShort = BC000C14_A106WWPNotificationDefinitionShort[0];
            A107WWPNotificationDefinitionLongD = BC000C14_A107WWPNotificationDefinitionLongD[0];
            A108WWPNotificationDefinitionLink = BC000C14_A108WWPNotificationDefinitionLink[0];
            A63WWPEntityName = BC000C14_A63WWPEntityName[0];
            A109WWPNotificationDefinitionSecFu = BC000C14_A109WWPNotificationDefinitionSecFu[0];
            A62WWPEntityId = BC000C14_A62WWPEntityId[0];
         }
         Gx_mode = sMode12;
      }

      protected void ScanKeyEnd0C12( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0C12( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0C12( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0C12( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0C12( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0C12( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0C12( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0C12( )
      {
      }

      protected void send_integrity_lvl_hashes0C12( )
      {
      }

      protected void AddRow0C12( )
      {
         VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
      }

      protected void ReadRow0C12( )
      {
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
      }

      protected void InitializeNonKey0C12( )
      {
         A110WWPNotificationDefinitionIsAut = false;
         A101WWPNotificationDefinitionName = "";
         A72WWPNotificationDefinitionAppli = 0;
         A73WWPNotificationDefinitionAllow = false;
         A71WWPNotificationDefinitionDescr = "";
         A104WWPNotificationDefinitionIcon = "";
         A105WWPNotificationDefinitionTitle = "";
         A106WWPNotificationDefinitionShort = "";
         A107WWPNotificationDefinitionLongD = "";
         A108WWPNotificationDefinitionLink = "";
         A62WWPEntityId = 0;
         A63WWPEntityName = "";
         A109WWPNotificationDefinitionSecFu = "";
         Z101WWPNotificationDefinitionName = "";
         Z72WWPNotificationDefinitionAppli = 0;
         Z73WWPNotificationDefinitionAllow = false;
         Z71WWPNotificationDefinitionDescr = "";
         Z104WWPNotificationDefinitionIcon = "";
         Z105WWPNotificationDefinitionTitle = "";
         Z106WWPNotificationDefinitionShort = "";
         Z107WWPNotificationDefinitionLongD = "";
         Z108WWPNotificationDefinitionLink = "";
         Z109WWPNotificationDefinitionSecFu = "";
         Z62WWPEntityId = 0;
      }

      protected void InitAll0C12( )
      {
         A65WWPNotificationDefinitionId = 0;
         InitializeNonKey0C12( ) ;
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

      public void VarsToRow12( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj12 )
      {
         obj12.gxTpr_Mode = Gx_mode;
         obj12.gxTpr_Wwpnotificationdefinitionisauthorized = A110WWPNotificationDefinitionIsAut;
         obj12.gxTpr_Wwpnotificationdefinitionname = A101WWPNotificationDefinitionName;
         obj12.gxTpr_Wwpnotificationdefinitionappliesto = A72WWPNotificationDefinitionAppli;
         obj12.gxTpr_Wwpnotificationdefinitionallowusersubscription = A73WWPNotificationDefinitionAllow;
         obj12.gxTpr_Wwpnotificationdefinitiondescription = A71WWPNotificationDefinitionDescr;
         obj12.gxTpr_Wwpnotificationdefinitionicon = A104WWPNotificationDefinitionIcon;
         obj12.gxTpr_Wwpnotificationdefinitiontitle = A105WWPNotificationDefinitionTitle;
         obj12.gxTpr_Wwpnotificationdefinitionshortdescription = A106WWPNotificationDefinitionShort;
         obj12.gxTpr_Wwpnotificationdefinitionlongdescription = A107WWPNotificationDefinitionLongD;
         obj12.gxTpr_Wwpnotificationdefinitionlink = A108WWPNotificationDefinitionLink;
         obj12.gxTpr_Wwpentityid = A62WWPEntityId;
         obj12.gxTpr_Wwpentityname = A63WWPEntityName;
         obj12.gxTpr_Wwpnotificationdefinitionsecfuncionality = A109WWPNotificationDefinitionSecFu;
         obj12.gxTpr_Wwpnotificationdefinitionid = A65WWPNotificationDefinitionId;
         obj12.gxTpr_Wwpnotificationdefinitionid_Z = Z65WWPNotificationDefinitionId;
         obj12.gxTpr_Wwpnotificationdefinitionname_Z = Z101WWPNotificationDefinitionName;
         obj12.gxTpr_Wwpnotificationdefinitionappliesto_Z = Z72WWPNotificationDefinitionAppli;
         obj12.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z = Z73WWPNotificationDefinitionAllow;
         obj12.gxTpr_Wwpnotificationdefinitiondescription_Z = Z71WWPNotificationDefinitionDescr;
         obj12.gxTpr_Wwpnotificationdefinitionicon_Z = Z104WWPNotificationDefinitionIcon;
         obj12.gxTpr_Wwpnotificationdefinitiontitle_Z = Z105WWPNotificationDefinitionTitle;
         obj12.gxTpr_Wwpnotificationdefinitionshortdescription_Z = Z106WWPNotificationDefinitionShort;
         obj12.gxTpr_Wwpnotificationdefinitionlongdescription_Z = Z107WWPNotificationDefinitionLongD;
         obj12.gxTpr_Wwpnotificationdefinitionlink_Z = Z108WWPNotificationDefinitionLink;
         obj12.gxTpr_Wwpentityid_Z = Z62WWPEntityId;
         obj12.gxTpr_Wwpentityname_Z = Z63WWPEntityName;
         obj12.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z = Z109WWPNotificationDefinitionSecFu;
         obj12.gxTpr_Wwpnotificationdefinitionisauthorized_Z = Z110WWPNotificationDefinitionIsAut;
         obj12.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow12( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj12 )
      {
         obj12.gxTpr_Wwpnotificationdefinitionid = A65WWPNotificationDefinitionId;
         return  ;
      }

      public void RowToVars12( GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition obj12 ,
                               int forceLoad )
      {
         Gx_mode = obj12.gxTpr_Mode;
         A110WWPNotificationDefinitionIsAut = obj12.gxTpr_Wwpnotificationdefinitionisauthorized;
         A101WWPNotificationDefinitionName = obj12.gxTpr_Wwpnotificationdefinitionname;
         A72WWPNotificationDefinitionAppli = obj12.gxTpr_Wwpnotificationdefinitionappliesto;
         A73WWPNotificationDefinitionAllow = obj12.gxTpr_Wwpnotificationdefinitionallowusersubscription;
         A71WWPNotificationDefinitionDescr = obj12.gxTpr_Wwpnotificationdefinitiondescription;
         A104WWPNotificationDefinitionIcon = obj12.gxTpr_Wwpnotificationdefinitionicon;
         A105WWPNotificationDefinitionTitle = obj12.gxTpr_Wwpnotificationdefinitiontitle;
         A106WWPNotificationDefinitionShort = obj12.gxTpr_Wwpnotificationdefinitionshortdescription;
         A107WWPNotificationDefinitionLongD = obj12.gxTpr_Wwpnotificationdefinitionlongdescription;
         A108WWPNotificationDefinitionLink = obj12.gxTpr_Wwpnotificationdefinitionlink;
         A62WWPEntityId = obj12.gxTpr_Wwpentityid;
         A63WWPEntityName = obj12.gxTpr_Wwpentityname;
         A109WWPNotificationDefinitionSecFu = obj12.gxTpr_Wwpnotificationdefinitionsecfuncionality;
         A65WWPNotificationDefinitionId = obj12.gxTpr_Wwpnotificationdefinitionid;
         Z65WWPNotificationDefinitionId = obj12.gxTpr_Wwpnotificationdefinitionid_Z;
         Z101WWPNotificationDefinitionName = obj12.gxTpr_Wwpnotificationdefinitionname_Z;
         Z72WWPNotificationDefinitionAppli = obj12.gxTpr_Wwpnotificationdefinitionappliesto_Z;
         Z73WWPNotificationDefinitionAllow = obj12.gxTpr_Wwpnotificationdefinitionallowusersubscription_Z;
         Z71WWPNotificationDefinitionDescr = obj12.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z104WWPNotificationDefinitionIcon = obj12.gxTpr_Wwpnotificationdefinitionicon_Z;
         Z105WWPNotificationDefinitionTitle = obj12.gxTpr_Wwpnotificationdefinitiontitle_Z;
         Z106WWPNotificationDefinitionShort = obj12.gxTpr_Wwpnotificationdefinitionshortdescription_Z;
         Z107WWPNotificationDefinitionLongD = obj12.gxTpr_Wwpnotificationdefinitionlongdescription_Z;
         Z108WWPNotificationDefinitionLink = obj12.gxTpr_Wwpnotificationdefinitionlink_Z;
         Z62WWPEntityId = obj12.gxTpr_Wwpentityid_Z;
         Z63WWPEntityName = obj12.gxTpr_Wwpentityname_Z;
         Z109WWPNotificationDefinitionSecFu = obj12.gxTpr_Wwpnotificationdefinitionsecfuncionality_Z;
         Z110WWPNotificationDefinitionIsAut = obj12.gxTpr_Wwpnotificationdefinitionisauthorized_Z;
         Gx_mode = obj12.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A65WWPNotificationDefinitionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0C12( ) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
         }
         ZM0C12( -4) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         ScanKeyStart0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
         }
         ZM0C12( -4) ;
         OnLoadActions0C12( ) ;
         AddRow0C12( ) ;
         ScanKeyEnd0C12( ) ;
         if ( RcdFound12 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0C12( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0C12( ) ;
         }
         else
         {
            if ( RcdFound12 == 1 )
            {
               if ( A65WWPNotificationDefinitionId != Z65WWPNotificationDefinitionId )
               {
                  A65WWPNotificationDefinitionId = Z65WWPNotificationDefinitionId;
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
                  Update0C12( ) ;
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
                  if ( A65WWPNotificationDefinitionId != Z65WWPNotificationDefinitionId )
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
                        Insert0C12( ) ;
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
                        Insert0C12( ) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         SaveImpl( ) ;
         VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
         AfterTrn( ) ;
         VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition auxBC = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A65WWPNotificationDefinitionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition);
               auxBC.Save();
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0C12( ) ;
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
               VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0C12( ) ;
         if ( RcdFound12 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A65WWPNotificationDefinitionId != Z65WWPNotificationDefinitionId )
            {
               A65WWPNotificationDefinitionId = Z65WWPNotificationDefinitionId;
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
            if ( A65WWPNotificationDefinitionId != Z65WWPNotificationDefinitionId )
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
         context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc",pr_default);
         VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
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
         Gx_mode = bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition )
         {
            bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition = (GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition) ;
            }
            else
            {
               RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars12( bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_NotificationDefinition WWP_NotificationDefinition_BC
      {
         get {
            return bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
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
            return "wwpnotificationdefinition_Execute" ;
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
         Z101WWPNotificationDefinitionName = "";
         A101WWPNotificationDefinitionName = "";
         Z71WWPNotificationDefinitionDescr = "";
         A71WWPNotificationDefinitionDescr = "";
         Z104WWPNotificationDefinitionIcon = "";
         A104WWPNotificationDefinitionIcon = "";
         Z105WWPNotificationDefinitionTitle = "";
         A105WWPNotificationDefinitionTitle = "";
         Z106WWPNotificationDefinitionShort = "";
         A106WWPNotificationDefinitionShort = "";
         Z107WWPNotificationDefinitionLongD = "";
         A107WWPNotificationDefinitionLongD = "";
         Z108WWPNotificationDefinitionLink = "";
         A108WWPNotificationDefinitionLink = "";
         Z109WWPNotificationDefinitionSecFu = "";
         A109WWPNotificationDefinitionSecFu = "";
         Z63WWPEntityName = "";
         A63WWPEntityName = "";
         BC000C5_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C5_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000C5_A72WWPNotificationDefinitionAppli = new short[1] ;
         BC000C5_A73WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000C5_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000C5_A104WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000C5_A105WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000C5_A106WWPNotificationDefinitionShort = new string[] {""} ;
         BC000C5_A107WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000C5_A108WWPNotificationDefinitionLink = new string[] {""} ;
         BC000C5_A63WWPEntityName = new string[] {""} ;
         BC000C5_A109WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000C5_A62WWPEntityId = new long[1] ;
         BC000C4_A63WWPEntityName = new string[] {""} ;
         BC000C6_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C3_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C3_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000C3_A72WWPNotificationDefinitionAppli = new short[1] ;
         BC000C3_A73WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000C3_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000C3_A104WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000C3_A105WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000C3_A106WWPNotificationDefinitionShort = new string[] {""} ;
         BC000C3_A107WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000C3_A108WWPNotificationDefinitionLink = new string[] {""} ;
         BC000C3_A109WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000C3_A62WWPEntityId = new long[1] ;
         sMode12 = "";
         BC000C2_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C2_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000C2_A72WWPNotificationDefinitionAppli = new short[1] ;
         BC000C2_A73WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000C2_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000C2_A104WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000C2_A105WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000C2_A106WWPNotificationDefinitionShort = new string[] {""} ;
         BC000C2_A107WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000C2_A108WWPNotificationDefinitionLink = new string[] {""} ;
         BC000C2_A109WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000C2_A62WWPEntityId = new long[1] ;
         BC000C8_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C11_A63WWPEntityName = new string[] {""} ;
         BC000C12_A64WWPNotificationId = new long[1] ;
         BC000C13_A67WWPSubscriptionId = new long[1] ;
         BC000C14_A65WWPNotificationDefinitionId = new long[1] ;
         BC000C14_A101WWPNotificationDefinitionName = new string[] {""} ;
         BC000C14_A72WWPNotificationDefinitionAppli = new short[1] ;
         BC000C14_A73WWPNotificationDefinitionAllow = new bool[] {false} ;
         BC000C14_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000C14_A104WWPNotificationDefinitionIcon = new string[] {""} ;
         BC000C14_A105WWPNotificationDefinitionTitle = new string[] {""} ;
         BC000C14_A106WWPNotificationDefinitionShort = new string[] {""} ;
         BC000C14_A107WWPNotificationDefinitionLongD = new string[] {""} ;
         BC000C14_A108WWPNotificationDefinitionLink = new string[] {""} ;
         BC000C14_A63WWPEntityName = new string[] {""} ;
         BC000C14_A109WWPNotificationDefinitionSecFu = new string[] {""} ;
         BC000C14_A62WWPEntityId = new long[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notificationdefinition_bc__default(),
            new Object[][] {
                new Object[] {
               BC000C2_A65WWPNotificationDefinitionId, BC000C2_A101WWPNotificationDefinitionName, BC000C2_A72WWPNotificationDefinitionAppli, BC000C2_A73WWPNotificationDefinitionAllow, BC000C2_A71WWPNotificationDefinitionDescr, BC000C2_A104WWPNotificationDefinitionIcon, BC000C2_A105WWPNotificationDefinitionTitle, BC000C2_A106WWPNotificationDefinitionShort, BC000C2_A107WWPNotificationDefinitionLongD, BC000C2_A108WWPNotificationDefinitionLink,
               BC000C2_A109WWPNotificationDefinitionSecFu, BC000C2_A62WWPEntityId
               }
               , new Object[] {
               BC000C3_A65WWPNotificationDefinitionId, BC000C3_A101WWPNotificationDefinitionName, BC000C3_A72WWPNotificationDefinitionAppli, BC000C3_A73WWPNotificationDefinitionAllow, BC000C3_A71WWPNotificationDefinitionDescr, BC000C3_A104WWPNotificationDefinitionIcon, BC000C3_A105WWPNotificationDefinitionTitle, BC000C3_A106WWPNotificationDefinitionShort, BC000C3_A107WWPNotificationDefinitionLongD, BC000C3_A108WWPNotificationDefinitionLink,
               BC000C3_A109WWPNotificationDefinitionSecFu, BC000C3_A62WWPEntityId
               }
               , new Object[] {
               BC000C4_A63WWPEntityName
               }
               , new Object[] {
               BC000C5_A65WWPNotificationDefinitionId, BC000C5_A101WWPNotificationDefinitionName, BC000C5_A72WWPNotificationDefinitionAppli, BC000C5_A73WWPNotificationDefinitionAllow, BC000C5_A71WWPNotificationDefinitionDescr, BC000C5_A104WWPNotificationDefinitionIcon, BC000C5_A105WWPNotificationDefinitionTitle, BC000C5_A106WWPNotificationDefinitionShort, BC000C5_A107WWPNotificationDefinitionLongD, BC000C5_A108WWPNotificationDefinitionLink,
               BC000C5_A63WWPEntityName, BC000C5_A109WWPNotificationDefinitionSecFu, BC000C5_A62WWPEntityId
               }
               , new Object[] {
               BC000C6_A65WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C8_A65WWPNotificationDefinitionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000C11_A63WWPEntityName
               }
               , new Object[] {
               BC000C12_A64WWPNotificationId
               }
               , new Object[] {
               BC000C13_A67WWPSubscriptionId
               }
               , new Object[] {
               BC000C14_A65WWPNotificationDefinitionId, BC000C14_A101WWPNotificationDefinitionName, BC000C14_A72WWPNotificationDefinitionAppli, BC000C14_A73WWPNotificationDefinitionAllow, BC000C14_A71WWPNotificationDefinitionDescr, BC000C14_A104WWPNotificationDefinitionIcon, BC000C14_A105WWPNotificationDefinitionTitle, BC000C14_A106WWPNotificationDefinitionShort, BC000C14_A107WWPNotificationDefinitionLongD, BC000C14_A108WWPNotificationDefinitionLink,
               BC000C14_A63WWPEntityName, BC000C14_A109WWPNotificationDefinitionSecFu, BC000C14_A62WWPEntityId
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z72WWPNotificationDefinitionAppli ;
      private short A72WWPNotificationDefinitionAppli ;
      private short RcdFound12 ;
      private short nIsDirty_12 ;
      private int trnEnded ;
      private long Z65WWPNotificationDefinitionId ;
      private long A65WWPNotificationDefinitionId ;
      private long Z62WWPEntityId ;
      private long A62WWPEntityId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode12 ;
      private bool Z73WWPNotificationDefinitionAllow ;
      private bool A73WWPNotificationDefinitionAllow ;
      private bool Z110WWPNotificationDefinitionIsAut ;
      private bool A110WWPNotificationDefinitionIsAut ;
      private bool Gx_longc ;
      private bool GXt_boolean1 ;
      private bool mustCommit ;
      private string Z101WWPNotificationDefinitionName ;
      private string A101WWPNotificationDefinitionName ;
      private string Z71WWPNotificationDefinitionDescr ;
      private string A71WWPNotificationDefinitionDescr ;
      private string Z104WWPNotificationDefinitionIcon ;
      private string A104WWPNotificationDefinitionIcon ;
      private string Z105WWPNotificationDefinitionTitle ;
      private string A105WWPNotificationDefinitionTitle ;
      private string Z106WWPNotificationDefinitionShort ;
      private string A106WWPNotificationDefinitionShort ;
      private string Z107WWPNotificationDefinitionLongD ;
      private string A107WWPNotificationDefinitionLongD ;
      private string Z108WWPNotificationDefinitionLink ;
      private string A108WWPNotificationDefinitionLink ;
      private string Z109WWPNotificationDefinitionSecFu ;
      private string A109WWPNotificationDefinitionSecFu ;
      private string Z63WWPEntityName ;
      private string A63WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_NotificationDefinition bcwwpbaseobjects_notifications_common_WWP_NotificationDefinition ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC000C5_A65WWPNotificationDefinitionId ;
      private string[] BC000C5_A101WWPNotificationDefinitionName ;
      private short[] BC000C5_A72WWPNotificationDefinitionAppli ;
      private bool[] BC000C5_A73WWPNotificationDefinitionAllow ;
      private string[] BC000C5_A71WWPNotificationDefinitionDescr ;
      private string[] BC000C5_A104WWPNotificationDefinitionIcon ;
      private string[] BC000C5_A105WWPNotificationDefinitionTitle ;
      private string[] BC000C5_A106WWPNotificationDefinitionShort ;
      private string[] BC000C5_A107WWPNotificationDefinitionLongD ;
      private string[] BC000C5_A108WWPNotificationDefinitionLink ;
      private string[] BC000C5_A63WWPEntityName ;
      private string[] BC000C5_A109WWPNotificationDefinitionSecFu ;
      private long[] BC000C5_A62WWPEntityId ;
      private string[] BC000C4_A63WWPEntityName ;
      private long[] BC000C6_A65WWPNotificationDefinitionId ;
      private long[] BC000C3_A65WWPNotificationDefinitionId ;
      private string[] BC000C3_A101WWPNotificationDefinitionName ;
      private short[] BC000C3_A72WWPNotificationDefinitionAppli ;
      private bool[] BC000C3_A73WWPNotificationDefinitionAllow ;
      private string[] BC000C3_A71WWPNotificationDefinitionDescr ;
      private string[] BC000C3_A104WWPNotificationDefinitionIcon ;
      private string[] BC000C3_A105WWPNotificationDefinitionTitle ;
      private string[] BC000C3_A106WWPNotificationDefinitionShort ;
      private string[] BC000C3_A107WWPNotificationDefinitionLongD ;
      private string[] BC000C3_A108WWPNotificationDefinitionLink ;
      private string[] BC000C3_A109WWPNotificationDefinitionSecFu ;
      private long[] BC000C3_A62WWPEntityId ;
      private long[] BC000C2_A65WWPNotificationDefinitionId ;
      private string[] BC000C2_A101WWPNotificationDefinitionName ;
      private short[] BC000C2_A72WWPNotificationDefinitionAppli ;
      private bool[] BC000C2_A73WWPNotificationDefinitionAllow ;
      private string[] BC000C2_A71WWPNotificationDefinitionDescr ;
      private string[] BC000C2_A104WWPNotificationDefinitionIcon ;
      private string[] BC000C2_A105WWPNotificationDefinitionTitle ;
      private string[] BC000C2_A106WWPNotificationDefinitionShort ;
      private string[] BC000C2_A107WWPNotificationDefinitionLongD ;
      private string[] BC000C2_A108WWPNotificationDefinitionLink ;
      private string[] BC000C2_A109WWPNotificationDefinitionSecFu ;
      private long[] BC000C2_A62WWPEntityId ;
      private long[] BC000C8_A65WWPNotificationDefinitionId ;
      private string[] BC000C11_A63WWPEntityName ;
      private long[] BC000C12_A64WWPNotificationId ;
      private long[] BC000C13_A67WWPSubscriptionId ;
      private long[] BC000C14_A65WWPNotificationDefinitionId ;
      private string[] BC000C14_A101WWPNotificationDefinitionName ;
      private short[] BC000C14_A72WWPNotificationDefinitionAppli ;
      private bool[] BC000C14_A73WWPNotificationDefinitionAllow ;
      private string[] BC000C14_A71WWPNotificationDefinitionDescr ;
      private string[] BC000C14_A104WWPNotificationDefinitionIcon ;
      private string[] BC000C14_A105WWPNotificationDefinitionTitle ;
      private string[] BC000C14_A106WWPNotificationDefinitionShort ;
      private string[] BC000C14_A107WWPNotificationDefinitionLongD ;
      private string[] BC000C14_A108WWPNotificationDefinitionLink ;
      private string[] BC000C14_A63WWPEntityName ;
      private string[] BC000C14_A109WWPNotificationDefinitionSecFu ;
      private long[] BC000C14_A62WWPEntityId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_notificationdefinition_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notificationdefinition_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000C5;
        prmBC000C5 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C4;
        prmBC000C4 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000C6;
        prmBC000C6 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C3;
        prmBC000C3 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C2;
        prmBC000C2 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C7;
        prmBC000C7 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000C8;
        prmBC000C8 = new Object[] {
        };
        Object[] prmBC000C9;
        prmBC000C9 = new Object[] {
        new ParDef("WWPNotificationDefinitionName",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationDefinitionAppli",GXType.Int16,1,0) ,
        new ParDef("WWPNotificationDefinitionAllow",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionDescr",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionIcon",GXType.VarChar,40,0) ,
        new ParDef("WWPNotificationDefinitionTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionShort",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationDefinitionLongD",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationDefinitionSecFu",GXType.VarChar,200,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C10;
        prmBC000C10 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C11;
        prmBC000C11 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000C12;
        prmBC000C12 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C13;
        prmBC000C13 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000C14;
        prmBC000C14 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000C2", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId  FOR UPDATE OF WWP_NotificationDefinition",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C3", "SELECT WWPNotificationDefinitionId, WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C4", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C5", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C6", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C7", "SAVEPOINT gxupdate;INSERT INTO WWP_NotificationDefinition(WWPNotificationDefinitionName, WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu, WWPEntityId) VALUES(:WWPNotificationDefinitionName, :WWPNotificationDefinitionAppli, :WWPNotificationDefinitionAllow, :WWPNotificationDefinitionDescr, :WWPNotificationDefinitionIcon, :WWPNotificationDefinitionTitle, :WWPNotificationDefinitionShort, :WWPNotificationDefinitionLongD, :WWPNotificationDefinitionLink, :WWPNotificationDefinitionSecFu, :WWPEntityId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000C7)
           ,new CursorDef("BC000C8", "SELECT currval('WWPNotificationDefinitionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C9", "SAVEPOINT gxupdate;UPDATE WWP_NotificationDefinition SET WWPNotificationDefinitionName=:WWPNotificationDefinitionName, WWPNotificationDefinitionAppli=:WWPNotificationDefinitionAppli, WWPNotificationDefinitionAllow=:WWPNotificationDefinitionAllow, WWPNotificationDefinitionDescr=:WWPNotificationDefinitionDescr, WWPNotificationDefinitionIcon=:WWPNotificationDefinitionIcon, WWPNotificationDefinitionTitle=:WWPNotificationDefinitionTitle, WWPNotificationDefinitionShort=:WWPNotificationDefinitionShort, WWPNotificationDefinitionLongD=:WWPNotificationDefinitionLongD, WWPNotificationDefinitionLink=:WWPNotificationDefinitionLink, WWPNotificationDefinitionSecFu=:WWPNotificationDefinitionSecFu, WWPEntityId=:WWPEntityId  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C9)
           ,new CursorDef("BC000C10", "SAVEPOINT gxupdate;DELETE FROM WWP_NotificationDefinition  WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000C10)
           ,new CursorDef("BC000C11", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000C12", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000C13", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000C14", "SELECT TM1.WWPNotificationDefinitionId, TM1.WWPNotificationDefinitionName, TM1.WWPNotificationDefinitionAppli, TM1.WWPNotificationDefinitionAllow, TM1.WWPNotificationDefinitionDescr, TM1.WWPNotificationDefinitionIcon, TM1.WWPNotificationDefinitionTitle, TM1.WWPNotificationDefinitionShort, TM1.WWPNotificationDefinitionLongD, TM1.WWPNotificationDefinitionLink, T2.WWPEntityName, TM1.WWPNotificationDefinitionSecFu, TM1.WWPEntityId FROM (WWP_NotificationDefinition TM1 INNER JOIN WWP_Entity T2 ON T2.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPNotificationDefinitionId = :WWPNotificationDefinitionId ORDER BY TM1.WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000C14,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((long[]) buf[11])[0] = rslt.getLong(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              ((string[]) buf[10])[0] = rslt.getVarchar(11);
              ((string[]) buf[11])[0] = rslt.getVarchar(12);
              ((long[]) buf[12])[0] = rslt.getLong(13);
              return;
     }
  }

}

}
