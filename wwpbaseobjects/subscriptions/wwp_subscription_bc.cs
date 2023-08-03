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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_subscription_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription_bc( IGxContext context )
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
         ReadRow088( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey088( ) ;
         standaloneModal( ) ;
         AddRow088( ) ;
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
               Z67WWPSubscriptionId = A67WWPSubscriptionId;
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

      protected void CONFIRM_080( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls088( ) ;
            }
            else
            {
               CheckExtendedTable088( ) ;
               if ( AnyError == 0 )
               {
                  ZM088( 3) ;
                  ZM088( 4) ;
                  ZM088( 5) ;
               }
               CloseExtendedTableCursors088( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z68WWPSubscriptionEntityRecordId = A68WWPSubscriptionEntityRecordId;
            Z70WWPSubscriptionEntityRecordDes = A70WWPSubscriptionEntityRecordDes;
            Z61WWPSubscriptionRoleId = A61WWPSubscriptionRoleId;
            Z69WWPSubscriptionSubscribed = A69WWPSubscriptionSubscribed;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z62WWPEntityId = A62WWPEntityId;
            Z71WWPNotificationDefinitionDescr = A71WWPNotificationDefinitionDescr;
         }
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z63WWPEntityName = A63WWPEntityName;
         }
         if ( GX_JID == -2 )
         {
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
            Z68WWPSubscriptionEntityRecordId = A68WWPSubscriptionEntityRecordId;
            Z70WWPSubscriptionEntityRecordDes = A70WWPSubscriptionEntityRecordDes;
            Z61WWPSubscriptionRoleId = A61WWPSubscriptionRoleId;
            Z69WWPSubscriptionSubscribed = A69WWPSubscriptionSubscribed;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z62WWPEntityId = A62WWPEntityId;
            Z71WWPNotificationDefinitionDescr = A71WWPNotificationDefinitionDescr;
            Z63WWPEntityName = A63WWPEntityName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load088( )
      {
         /* Using cursor BC00087 */
         pr_default.execute(5, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
            A62WWPEntityId = BC00087_A62WWPEntityId[0];
            A71WWPNotificationDefinitionDescr = BC00087_A71WWPNotificationDefinitionDescr[0];
            A63WWPEntityName = BC00087_A63WWPEntityName[0];
            A50WWPUserExtendedFullName = BC00087_A50WWPUserExtendedFullName[0];
            A68WWPSubscriptionEntityRecordId = BC00087_A68WWPSubscriptionEntityRecordId[0];
            A70WWPSubscriptionEntityRecordDes = BC00087_A70WWPSubscriptionEntityRecordDes[0];
            A61WWPSubscriptionRoleId = BC00087_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = BC00087_n61WWPSubscriptionRoleId[0];
            A69WWPSubscriptionSubscribed = BC00087_A69WWPSubscriptionSubscribed[0];
            A65WWPNotificationDefinitionId = BC00087_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC00087_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC00087_n49WWPUserExtendedId[0];
            ZM088( -2) ;
         }
         pr_default.close(5);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00084 */
         pr_default.execute(2, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
         }
         A62WWPEntityId = BC00084_A62WWPEntityId[0];
         A71WWPNotificationDefinitionDescr = BC00084_A71WWPNotificationDefinitionDescr[0];
         pr_default.close(2);
         /* Using cursor BC00086 */
         pr_default.execute(4, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = BC00086_A63WWPEntityName[0];
         pr_default.close(4);
         /* Using cursor BC00085 */
         pr_default.execute(3, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
            }
         }
         A50WWPUserExtendedFullName = BC00085_A50WWPUserExtendedFullName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey088( )
      {
         /* Using cursor BC00088 */
         pr_default.execute(6, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00083 */
         pr_default.execute(1, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 2) ;
            RcdFound8 = 1;
            A67WWPSubscriptionId = BC00083_A67WWPSubscriptionId[0];
            A68WWPSubscriptionEntityRecordId = BC00083_A68WWPSubscriptionEntityRecordId[0];
            A70WWPSubscriptionEntityRecordDes = BC00083_A70WWPSubscriptionEntityRecordDes[0];
            A61WWPSubscriptionRoleId = BC00083_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = BC00083_n61WWPSubscriptionRoleId[0];
            A69WWPSubscriptionSubscribed = BC00083_A69WWPSubscriptionSubscribed[0];
            A65WWPNotificationDefinitionId = BC00083_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC00083_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC00083_n49WWPUserExtendedId[0];
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode8;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         CONFIRM_080( ) ;
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

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00082 */
            pr_default.execute(0, new Object[] {A67WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z68WWPSubscriptionEntityRecordId, BC00082_A68WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z70WWPSubscriptionEntityRecordDes, BC00082_A70WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z61WWPSubscriptionRoleId, BC00082_A61WWPSubscriptionRoleId[0]) != 0 ) || ( Z69WWPSubscriptionSubscribed != BC00082_A69WWPSubscriptionSubscribed[0] ) || ( Z65WWPNotificationDefinitionId != BC00082_A65WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z49WWPUserExtendedId, BC00082_A49WWPUserExtendedId[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00089 */
                     pr_default.execute(7, new Object[] {A68WWPSubscriptionEntityRecordId, A70WWPSubscriptionEntityRecordDes, n61WWPSubscriptionRoleId, A61WWPSubscriptionRoleId, A69WWPSubscriptionSubscribed, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000810 */
                     pr_default.execute(8);
                     A67WWPSubscriptionId = BC000810_A67WWPSubscriptionId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000811 */
                     pr_default.execute(9, new Object[] {A68WWPSubscriptionEntityRecordId, A70WWPSubscriptionEntityRecordDes, n61WWPSubscriptionRoleId, A61WWPSubscriptionRoleId, A69WWPSubscriptionSubscribed, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId, A67WWPSubscriptionId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000812 */
                  pr_default.execute(10, new Object[] {A67WWPSubscriptionId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel088( ) ;
         Gx_mode = sMode8;
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000813 */
            pr_default.execute(11, new Object[] {A65WWPNotificationDefinitionId});
            A62WWPEntityId = BC000813_A62WWPEntityId[0];
            A71WWPNotificationDefinitionDescr = BC000813_A71WWPNotificationDefinitionDescr[0];
            pr_default.close(11);
            /* Using cursor BC000814 */
            pr_default.execute(12, new Object[] {A62WWPEntityId});
            A63WWPEntityName = BC000814_A63WWPEntityName[0];
            pr_default.close(12);
            /* Using cursor BC000815 */
            pr_default.execute(13, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            A50WWPUserExtendedFullName = BC000815_A50WWPUserExtendedFullName[0];
            pr_default.close(13);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
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

      public void ScanKeyStart088( )
      {
         /* Using cursor BC000816 */
         pr_default.execute(14, new Object[] {A67WWPSubscriptionId});
         RcdFound8 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A62WWPEntityId = BC000816_A62WWPEntityId[0];
            A67WWPSubscriptionId = BC000816_A67WWPSubscriptionId[0];
            A71WWPNotificationDefinitionDescr = BC000816_A71WWPNotificationDefinitionDescr[0];
            A63WWPEntityName = BC000816_A63WWPEntityName[0];
            A50WWPUserExtendedFullName = BC000816_A50WWPUserExtendedFullName[0];
            A68WWPSubscriptionEntityRecordId = BC000816_A68WWPSubscriptionEntityRecordId[0];
            A70WWPSubscriptionEntityRecordDes = BC000816_A70WWPSubscriptionEntityRecordDes[0];
            A61WWPSubscriptionRoleId = BC000816_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = BC000816_n61WWPSubscriptionRoleId[0];
            A69WWPSubscriptionSubscribed = BC000816_A69WWPSubscriptionSubscribed[0];
            A65WWPNotificationDefinitionId = BC000816_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000816_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000816_n49WWPUserExtendedId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound8 = 0;
         ScanKeyLoad088( ) ;
      }

      protected void ScanKeyLoad088( )
      {
         sMode8 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound8 = 1;
            A62WWPEntityId = BC000816_A62WWPEntityId[0];
            A67WWPSubscriptionId = BC000816_A67WWPSubscriptionId[0];
            A71WWPNotificationDefinitionDescr = BC000816_A71WWPNotificationDefinitionDescr[0];
            A63WWPEntityName = BC000816_A63WWPEntityName[0];
            A50WWPUserExtendedFullName = BC000816_A50WWPUserExtendedFullName[0];
            A68WWPSubscriptionEntityRecordId = BC000816_A68WWPSubscriptionEntityRecordId[0];
            A70WWPSubscriptionEntityRecordDes = BC000816_A70WWPSubscriptionEntityRecordDes[0];
            A61WWPSubscriptionRoleId = BC000816_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = BC000816_n61WWPSubscriptionRoleId[0];
            A69WWPSubscriptionSubscribed = BC000816_A69WWPSubscriptionSubscribed[0];
            A65WWPNotificationDefinitionId = BC000816_A65WWPNotificationDefinitionId[0];
            A49WWPUserExtendedId = BC000816_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000816_n49WWPUserExtendedId[0];
         }
         Gx_mode = sMode8;
      }

      protected void ScanKeyEnd088( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) )
         {
            A49WWPUserExtendedId = "";
            n49WWPUserExtendedId = false;
            n49WWPUserExtendedId = true;
         }
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void AddRow088( )
      {
         VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
      }

      protected void ReadRow088( )
      {
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
      }

      protected void InitializeNonKey088( )
      {
         A62WWPEntityId = 0;
         A65WWPNotificationDefinitionId = 0;
         A71WWPNotificationDefinitionDescr = "";
         A63WWPEntityName = "";
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         A50WWPUserExtendedFullName = "";
         A68WWPSubscriptionEntityRecordId = "";
         A70WWPSubscriptionEntityRecordDes = "";
         A61WWPSubscriptionRoleId = "";
         n61WWPSubscriptionRoleId = false;
         A69WWPSubscriptionSubscribed = false;
         Z68WWPSubscriptionEntityRecordId = "";
         Z70WWPSubscriptionEntityRecordDes = "";
         Z61WWPSubscriptionRoleId = "";
         Z69WWPSubscriptionSubscribed = false;
         Z65WWPNotificationDefinitionId = 0;
         Z49WWPUserExtendedId = "";
      }

      protected void InitAll088( )
      {
         A67WWPSubscriptionId = 0;
         InitializeNonKey088( ) ;
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

      public void VarsToRow8( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj8 )
      {
         obj8.gxTpr_Mode = Gx_mode;
         obj8.gxTpr_Wwpnotificationdefinitionid = A65WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitiondescription = A71WWPNotificationDefinitionDescr;
         obj8.gxTpr_Wwpentityname = A63WWPEntityName;
         obj8.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         obj8.gxTpr_Wwpuserextendedfullname = A50WWPUserExtendedFullName;
         obj8.gxTpr_Wwpsubscriptionentityrecordid = A68WWPSubscriptionEntityRecordId;
         obj8.gxTpr_Wwpsubscriptionentityrecorddescription = A70WWPSubscriptionEntityRecordDes;
         obj8.gxTpr_Wwpsubscriptionroleid = A61WWPSubscriptionRoleId;
         obj8.gxTpr_Wwpsubscriptionsubscribed = A69WWPSubscriptionSubscribed;
         obj8.gxTpr_Wwpsubscriptionid = A67WWPSubscriptionId;
         obj8.gxTpr_Wwpsubscriptionid_Z = Z67WWPSubscriptionId;
         obj8.gxTpr_Wwpnotificationdefinitionid_Z = Z65WWPNotificationDefinitionId;
         obj8.gxTpr_Wwpnotificationdefinitiondescription_Z = Z71WWPNotificationDefinitionDescr;
         obj8.gxTpr_Wwpentityname_Z = Z63WWPEntityName;
         obj8.gxTpr_Wwpuserextendedid_Z = Z49WWPUserExtendedId;
         obj8.gxTpr_Wwpuserextendedfullname_Z = Z50WWPUserExtendedFullName;
         obj8.gxTpr_Wwpsubscriptionentityrecordid_Z = Z68WWPSubscriptionEntityRecordId;
         obj8.gxTpr_Wwpsubscriptionentityrecorddescription_Z = Z70WWPSubscriptionEntityRecordDes;
         obj8.gxTpr_Wwpsubscriptionroleid_Z = Z61WWPSubscriptionRoleId;
         obj8.gxTpr_Wwpsubscriptionsubscribed_Z = Z69WWPSubscriptionSubscribed;
         obj8.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n49WWPUserExtendedId));
         obj8.gxTpr_Wwpsubscriptionroleid_N = (short)(Convert.ToInt16(n61WWPSubscriptionRoleId));
         obj8.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow8( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj8 )
      {
         obj8.gxTpr_Wwpsubscriptionid = A67WWPSubscriptionId;
         return  ;
      }

      public void RowToVars8( GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription obj8 ,
                              int forceLoad )
      {
         Gx_mode = obj8.gxTpr_Mode;
         A65WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid;
         A71WWPNotificationDefinitionDescr = obj8.gxTpr_Wwpnotificationdefinitiondescription;
         A63WWPEntityName = obj8.gxTpr_Wwpentityname;
         A49WWPUserExtendedId = obj8.gxTpr_Wwpuserextendedid;
         n49WWPUserExtendedId = false;
         A50WWPUserExtendedFullName = obj8.gxTpr_Wwpuserextendedfullname;
         A68WWPSubscriptionEntityRecordId = obj8.gxTpr_Wwpsubscriptionentityrecordid;
         A70WWPSubscriptionEntityRecordDes = obj8.gxTpr_Wwpsubscriptionentityrecorddescription;
         A61WWPSubscriptionRoleId = obj8.gxTpr_Wwpsubscriptionroleid;
         n61WWPSubscriptionRoleId = false;
         A69WWPSubscriptionSubscribed = obj8.gxTpr_Wwpsubscriptionsubscribed;
         A67WWPSubscriptionId = obj8.gxTpr_Wwpsubscriptionid;
         Z67WWPSubscriptionId = obj8.gxTpr_Wwpsubscriptionid_Z;
         Z65WWPNotificationDefinitionId = obj8.gxTpr_Wwpnotificationdefinitionid_Z;
         Z71WWPNotificationDefinitionDescr = obj8.gxTpr_Wwpnotificationdefinitiondescription_Z;
         Z63WWPEntityName = obj8.gxTpr_Wwpentityname_Z;
         Z49WWPUserExtendedId = obj8.gxTpr_Wwpuserextendedid_Z;
         Z50WWPUserExtendedFullName = obj8.gxTpr_Wwpuserextendedfullname_Z;
         Z68WWPSubscriptionEntityRecordId = obj8.gxTpr_Wwpsubscriptionentityrecordid_Z;
         Z70WWPSubscriptionEntityRecordDes = obj8.gxTpr_Wwpsubscriptionentityrecorddescription_Z;
         Z61WWPSubscriptionRoleId = obj8.gxTpr_Wwpsubscriptionroleid_Z;
         Z69WWPSubscriptionSubscribed = obj8.gxTpr_Wwpsubscriptionsubscribed_Z;
         n49WWPUserExtendedId = (bool)(Convert.ToBoolean(obj8.gxTpr_Wwpuserextendedid_N));
         n61WWPSubscriptionRoleId = (bool)(Convert.ToBoolean(obj8.gxTpr_Wwpsubscriptionroleid_N));
         Gx_mode = obj8.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A67WWPSubscriptionId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey088( ) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         ScanKeyStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
         }
         ZM088( -2) ;
         OnLoadActions088( ) ;
         AddRow088( ) ;
         ScanKeyEnd088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert088( ) ;
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
               {
                  A67WWPSubscriptionId = Z67WWPSubscriptionId;
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
                  Update088( ) ;
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
                  if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
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
                        Insert088( ) ;
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
                        Insert088( ) ;
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         SaveImpl( ) ;
         VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
         AfterTrn( ) ;
         VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription auxBC = new GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A67WWPSubscriptionId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_subscriptions_WWP_Subscription);
               auxBC.Save();
               bcwwpbaseobjects_subscriptions_WWP_Subscription.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert088( ) ;
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
               VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey088( ) ;
         if ( RcdFound8 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
            {
               A67WWPSubscriptionId = Z67WWPSubscriptionId;
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
            if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
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
         context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription_bc",pr_default);
         VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
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
         Gx_mode = bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_subscriptions_WWP_Subscription )
         {
            bcwwpbaseobjects_subscriptions_WWP_Subscription = (GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow8( bcwwpbaseobjects_subscriptions_WWP_Subscription) ;
            }
            else
            {
               RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_subscriptions_WWP_Subscription.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars8( bcwwpbaseobjects_subscriptions_WWP_Subscription, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Subscription WWP_Subscription_BC
      {
         get {
            return bcwwpbaseobjects_subscriptions_WWP_Subscription ;
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
            return "wwpsubscription_Execute" ;
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
         pr_default.close(11);
         pr_default.close(13);
         pr_default.close(12);
      }

      public override void initialize( )
      {
         scmdbuf = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Gx_mode = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z68WWPSubscriptionEntityRecordId = "";
         A68WWPSubscriptionEntityRecordId = "";
         Z70WWPSubscriptionEntityRecordDes = "";
         A70WWPSubscriptionEntityRecordDes = "";
         Z61WWPSubscriptionRoleId = "";
         A61WWPSubscriptionRoleId = "";
         Z49WWPUserExtendedId = "";
         A49WWPUserExtendedId = "";
         Z71WWPNotificationDefinitionDescr = "";
         A71WWPNotificationDefinitionDescr = "";
         Z50WWPUserExtendedFullName = "";
         A50WWPUserExtendedFullName = "";
         Z63WWPEntityName = "";
         A63WWPEntityName = "";
         BC00087_A62WWPEntityId = new long[1] ;
         BC00087_A67WWPSubscriptionId = new long[1] ;
         BC00087_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00087_A63WWPEntityName = new string[] {""} ;
         BC00087_A50WWPUserExtendedFullName = new string[] {""} ;
         BC00087_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00087_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00087_A61WWPSubscriptionRoleId = new string[] {""} ;
         BC00087_n61WWPSubscriptionRoleId = new bool[] {false} ;
         BC00087_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00087_A65WWPNotificationDefinitionId = new long[1] ;
         BC00087_A49WWPUserExtendedId = new string[] {""} ;
         BC00087_n49WWPUserExtendedId = new bool[] {false} ;
         BC00084_A62WWPEntityId = new long[1] ;
         BC00084_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC00086_A63WWPEntityName = new string[] {""} ;
         BC00085_A50WWPUserExtendedFullName = new string[] {""} ;
         BC00088_A67WWPSubscriptionId = new long[1] ;
         BC00083_A67WWPSubscriptionId = new long[1] ;
         BC00083_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00083_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00083_A61WWPSubscriptionRoleId = new string[] {""} ;
         BC00083_n61WWPSubscriptionRoleId = new bool[] {false} ;
         BC00083_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00083_A65WWPNotificationDefinitionId = new long[1] ;
         BC00083_A49WWPUserExtendedId = new string[] {""} ;
         BC00083_n49WWPUserExtendedId = new bool[] {false} ;
         sMode8 = "";
         BC00082_A67WWPSubscriptionId = new long[1] ;
         BC00082_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC00082_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC00082_A61WWPSubscriptionRoleId = new string[] {""} ;
         BC00082_n61WWPSubscriptionRoleId = new bool[] {false} ;
         BC00082_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         BC00082_A65WWPNotificationDefinitionId = new long[1] ;
         BC00082_A49WWPUserExtendedId = new string[] {""} ;
         BC00082_n49WWPUserExtendedId = new bool[] {false} ;
         BC000810_A67WWPSubscriptionId = new long[1] ;
         BC000813_A62WWPEntityId = new long[1] ;
         BC000813_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000814_A63WWPEntityName = new string[] {""} ;
         BC000815_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000816_A62WWPEntityId = new long[1] ;
         BC000816_A67WWPSubscriptionId = new long[1] ;
         BC000816_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         BC000816_A63WWPEntityName = new string[] {""} ;
         BC000816_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000816_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         BC000816_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         BC000816_A61WWPSubscriptionRoleId = new string[] {""} ;
         BC000816_n61WWPSubscriptionRoleId = new bool[] {false} ;
         BC000816_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         BC000816_A65WWPNotificationDefinitionId = new long[1] ;
         BC000816_A49WWPUserExtendedId = new string[] {""} ;
         BC000816_n49WWPUserExtendedId = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription_bc__default(),
            new Object[][] {
                new Object[] {
               BC00082_A67WWPSubscriptionId, BC00082_A68WWPSubscriptionEntityRecordId, BC00082_A70WWPSubscriptionEntityRecordDes, BC00082_A61WWPSubscriptionRoleId, BC00082_n61WWPSubscriptionRoleId, BC00082_A69WWPSubscriptionSubscribed, BC00082_A65WWPNotificationDefinitionId, BC00082_A49WWPUserExtendedId, BC00082_n49WWPUserExtendedId
               }
               , new Object[] {
               BC00083_A67WWPSubscriptionId, BC00083_A68WWPSubscriptionEntityRecordId, BC00083_A70WWPSubscriptionEntityRecordDes, BC00083_A61WWPSubscriptionRoleId, BC00083_n61WWPSubscriptionRoleId, BC00083_A69WWPSubscriptionSubscribed, BC00083_A65WWPNotificationDefinitionId, BC00083_A49WWPUserExtendedId, BC00083_n49WWPUserExtendedId
               }
               , new Object[] {
               BC00084_A62WWPEntityId, BC00084_A71WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC00085_A50WWPUserExtendedFullName
               }
               , new Object[] {
               BC00086_A63WWPEntityName
               }
               , new Object[] {
               BC00087_A62WWPEntityId, BC00087_A67WWPSubscriptionId, BC00087_A71WWPNotificationDefinitionDescr, BC00087_A63WWPEntityName, BC00087_A50WWPUserExtendedFullName, BC00087_A68WWPSubscriptionEntityRecordId, BC00087_A70WWPSubscriptionEntityRecordDes, BC00087_A61WWPSubscriptionRoleId, BC00087_n61WWPSubscriptionRoleId, BC00087_A69WWPSubscriptionSubscribed,
               BC00087_A65WWPNotificationDefinitionId, BC00087_A49WWPUserExtendedId, BC00087_n49WWPUserExtendedId
               }
               , new Object[] {
               BC00088_A67WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000810_A67WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000813_A62WWPEntityId, BC000813_A71WWPNotificationDefinitionDescr
               }
               , new Object[] {
               BC000814_A63WWPEntityName
               }
               , new Object[] {
               BC000815_A50WWPUserExtendedFullName
               }
               , new Object[] {
               BC000816_A62WWPEntityId, BC000816_A67WWPSubscriptionId, BC000816_A71WWPNotificationDefinitionDescr, BC000816_A63WWPEntityName, BC000816_A50WWPUserExtendedFullName, BC000816_A68WWPSubscriptionEntityRecordId, BC000816_A70WWPSubscriptionEntityRecordDes, BC000816_A61WWPSubscriptionRoleId, BC000816_n61WWPSubscriptionRoleId, BC000816_A69WWPSubscriptionSubscribed,
               BC000816_A65WWPNotificationDefinitionId, BC000816_A49WWPUserExtendedId, BC000816_n49WWPUserExtendedId
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
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private int trnEnded ;
      private long Z67WWPSubscriptionId ;
      private long A67WWPSubscriptionId ;
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
      private string Z61WWPSubscriptionRoleId ;
      private string A61WWPSubscriptionRoleId ;
      private string Z49WWPUserExtendedId ;
      private string A49WWPUserExtendedId ;
      private string sMode8 ;
      private bool Z69WWPSubscriptionSubscribed ;
      private bool A69WWPSubscriptionSubscribed ;
      private bool n61WWPSubscriptionRoleId ;
      private bool n49WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z68WWPSubscriptionEntityRecordId ;
      private string A68WWPSubscriptionEntityRecordId ;
      private string Z70WWPSubscriptionEntityRecordDes ;
      private string A70WWPSubscriptionEntityRecordDes ;
      private string Z71WWPNotificationDefinitionDescr ;
      private string A71WWPNotificationDefinitionDescr ;
      private string Z50WWPUserExtendedFullName ;
      private string A50WWPUserExtendedFullName ;
      private string Z63WWPEntityName ;
      private string A63WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.subscriptions.SdtWWP_Subscription bcwwpbaseobjects_subscriptions_WWP_Subscription ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00087_A62WWPEntityId ;
      private long[] BC00087_A67WWPSubscriptionId ;
      private string[] BC00087_A71WWPNotificationDefinitionDescr ;
      private string[] BC00087_A63WWPEntityName ;
      private string[] BC00087_A50WWPUserExtendedFullName ;
      private string[] BC00087_A68WWPSubscriptionEntityRecordId ;
      private string[] BC00087_A70WWPSubscriptionEntityRecordDes ;
      private string[] BC00087_A61WWPSubscriptionRoleId ;
      private bool[] BC00087_n61WWPSubscriptionRoleId ;
      private bool[] BC00087_A69WWPSubscriptionSubscribed ;
      private long[] BC00087_A65WWPNotificationDefinitionId ;
      private string[] BC00087_A49WWPUserExtendedId ;
      private bool[] BC00087_n49WWPUserExtendedId ;
      private long[] BC00084_A62WWPEntityId ;
      private string[] BC00084_A71WWPNotificationDefinitionDescr ;
      private string[] BC00086_A63WWPEntityName ;
      private string[] BC00085_A50WWPUserExtendedFullName ;
      private long[] BC00088_A67WWPSubscriptionId ;
      private long[] BC00083_A67WWPSubscriptionId ;
      private string[] BC00083_A68WWPSubscriptionEntityRecordId ;
      private string[] BC00083_A70WWPSubscriptionEntityRecordDes ;
      private string[] BC00083_A61WWPSubscriptionRoleId ;
      private bool[] BC00083_n61WWPSubscriptionRoleId ;
      private bool[] BC00083_A69WWPSubscriptionSubscribed ;
      private long[] BC00083_A65WWPNotificationDefinitionId ;
      private string[] BC00083_A49WWPUserExtendedId ;
      private bool[] BC00083_n49WWPUserExtendedId ;
      private long[] BC00082_A67WWPSubscriptionId ;
      private string[] BC00082_A68WWPSubscriptionEntityRecordId ;
      private string[] BC00082_A70WWPSubscriptionEntityRecordDes ;
      private string[] BC00082_A61WWPSubscriptionRoleId ;
      private bool[] BC00082_n61WWPSubscriptionRoleId ;
      private bool[] BC00082_A69WWPSubscriptionSubscribed ;
      private long[] BC00082_A65WWPNotificationDefinitionId ;
      private string[] BC00082_A49WWPUserExtendedId ;
      private bool[] BC00082_n49WWPUserExtendedId ;
      private long[] BC000810_A67WWPSubscriptionId ;
      private long[] BC000813_A62WWPEntityId ;
      private string[] BC000813_A71WWPNotificationDefinitionDescr ;
      private string[] BC000814_A63WWPEntityName ;
      private string[] BC000815_A50WWPUserExtendedFullName ;
      private long[] BC000816_A62WWPEntityId ;
      private long[] BC000816_A67WWPSubscriptionId ;
      private string[] BC000816_A71WWPNotificationDefinitionDescr ;
      private string[] BC000816_A63WWPEntityName ;
      private string[] BC000816_A50WWPUserExtendedFullName ;
      private string[] BC000816_A68WWPSubscriptionEntityRecordId ;
      private string[] BC000816_A70WWPSubscriptionEntityRecordDes ;
      private string[] BC000816_A61WWPSubscriptionRoleId ;
      private bool[] BC000816_n61WWPSubscriptionRoleId ;
      private bool[] BC000816_A69WWPSubscriptionSubscribed ;
      private long[] BC000816_A65WWPNotificationDefinitionId ;
      private string[] BC000816_A49WWPUserExtendedId ;
      private bool[] BC000816_n49WWPUserExtendedId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_subscription_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00087;
        prmBC00087 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00084;
        prmBC00084 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC00086;
        prmBC00086 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00085;
        prmBC00085 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00088;
        prmBC00088 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00083;
        prmBC00083 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00082;
        prmBC00082 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC00089;
        prmBC00089 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000810;
        prmBC000810 = new Object[] {
        };
        Object[] prmBC000811;
        prmBC000811 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC000812;
        prmBC000812 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmBC000813;
        prmBC000813 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmBC000814;
        prmBC000814 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000815;
        prmBC000815 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000816;
        prmBC000816 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00082", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription",true, GxErrorMask.GX_NOMASK, false, this,prmBC00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00083", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00084", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00085", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00086", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00086,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00087", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00087,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00088", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00089", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00089)
           ,new CursorDef("BC000810", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000810,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000811", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000811)
           ,new CursorDef("BC000812", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000812)
           ,new CursorDef("BC000813", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000813,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000814", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000814,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000815", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000816", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000816,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
     }
  }

}

}
