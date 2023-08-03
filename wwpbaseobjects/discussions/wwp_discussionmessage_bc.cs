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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_discussionmessage_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage_bc( IGxContext context )
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
         ReadRow0G17( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0G17( ) ;
         standaloneModal( ) ;
         AddRow0G17( ) ;
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
               Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
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

      protected void CONFIRM_0G0( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0G17( ) ;
            }
            else
            {
               CheckExtendedTable0G17( ) ;
               if ( AnyError == 0 )
               {
                  ZM0G17( 5) ;
                  ZM0G17( 6) ;
                  ZM0G17( 7) ;
               }
               CloseExtendedTableCursors0G17( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
            Z141WWPDiscussionMessageMessage = A141WWPDiscussionMessageMessage;
            Z142WWPDiscussionMessageEntityReco = A142WWPDiscussionMessageEntityReco;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z62WWPEntityId = A62WWPEntityId;
            Z136WWPDiscussionMessageThreadId = A136WWPDiscussionMessageThreadId;
         }
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z63WWPEntityName = A63WWPEntityName;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -4 )
         {
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
            Z141WWPDiscussionMessageMessage = A141WWPDiscussionMessageMessage;
            Z142WWPDiscussionMessageEntityReco = A142WWPDiscussionMessageEntityReco;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z62WWPEntityId = A62WWPEntityId;
            Z136WWPDiscussionMessageThreadId = A136WWPDiscussionMessageThreadId;
            Z52WWPUserExtendedPhoto = A52WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
            Z63WWPEntityName = A63WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A140WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         GXt_char1 = A49WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A49WWPUserExtendedId = GXt_char1;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor BC000G4 */
            pr_default.execute(2, new Object[] {A49WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000G4_A40000WWPUserExtendedPhoto_GXI[0];
            A50WWPUserExtendedFullName = BC000G4_A50WWPUserExtendedFullName[0];
            A52WWPUserExtendedPhoto = BC000G4_A52WWPUserExtendedPhoto[0];
            pr_default.close(2);
         }
      }

      protected void Load0G17( )
      {
         /* Using cursor BC000G7 */
         pr_default.execute(5, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A140WWPDiscussionMessageDate = BC000G7_A140WWPDiscussionMessageDate[0];
            A141WWPDiscussionMessageMessage = BC000G7_A141WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G7_A40000WWPUserExtendedPhoto_GXI[0];
            A50WWPUserExtendedFullName = BC000G7_A50WWPUserExtendedFullName[0];
            A63WWPEntityName = BC000G7_A63WWPEntityName[0];
            A142WWPDiscussionMessageEntityReco = BC000G7_A142WWPDiscussionMessageEntityReco[0];
            A49WWPUserExtendedId = BC000G7_A49WWPUserExtendedId[0];
            A62WWPEntityId = BC000G7_A62WWPEntityId[0];
            A136WWPDiscussionMessageThreadId = BC000G7_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = BC000G7_n136WWPDiscussionMessageThreadId[0];
            A52WWPUserExtendedPhoto = BC000G7_A52WWPUserExtendedPhoto[0];
            ZM0G17( -4) ;
         }
         pr_default.close(5);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000G6 */
         pr_default.execute(4, new Object[] {n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A136WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
            }
         }
         pr_default.close(4);
         /* Using cursor BC000G4 */
         pr_default.execute(2, new Object[] {A49WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
         }
         A40000WWPUserExtendedPhoto_GXI = BC000G4_A40000WWPUserExtendedPhoto_GXI[0];
         A50WWPUserExtendedFullName = BC000G4_A50WWPUserExtendedFullName[0];
         A52WWPUserExtendedPhoto = BC000G4_A52WWPUserExtendedPhoto[0];
         pr_default.close(2);
         /* Using cursor BC000G5 */
         pr_default.execute(3, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = BC000G5_A63WWPEntityName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0G17( )
      {
         /* Using cursor BC000G8 */
         pr_default.execute(6, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000G3 */
         pr_default.execute(1, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G17( 4) ;
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = BC000G3_A137WWPDiscussionMessageId[0];
            A140WWPDiscussionMessageDate = BC000G3_A140WWPDiscussionMessageDate[0];
            A141WWPDiscussionMessageMessage = BC000G3_A141WWPDiscussionMessageMessage[0];
            A142WWPDiscussionMessageEntityReco = BC000G3_A142WWPDiscussionMessageEntityReco[0];
            A49WWPUserExtendedId = BC000G3_A49WWPUserExtendedId[0];
            A62WWPEntityId = BC000G3_A62WWPEntityId[0];
            A136WWPDiscussionMessageThreadId = BC000G3_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = BC000G3_n136WWPDiscussionMessageThreadId[0];
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode17;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         CONFIRM_0G0( ) ;
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

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000G2 */
            pr_default.execute(0, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z140WWPDiscussionMessageDate != BC000G2_A140WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z141WWPDiscussionMessageMessage, BC000G2_A141WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z142WWPDiscussionMessageEntityReco, BC000G2_A142WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z49WWPUserExtendedId, BC000G2_A49WWPUserExtendedId[0]) != 0 ) || ( Z62WWPEntityId != BC000G2_A62WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z136WWPDiscussionMessageThreadId != BC000G2_A136WWPDiscussionMessageThreadId[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G9 */
                     pr_default.execute(7, new Object[] {A140WWPDiscussionMessageDate, A141WWPDiscussionMessageMessage, A142WWPDiscussionMessageEntityReco, A49WWPUserExtendedId, A62WWPEntityId, n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000G10 */
                     pr_default.execute(8);
                     A137WWPDiscussionMessageId = BC000G10_A137WWPDiscussionMessageId[0];
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000G11 */
                     pr_default.execute(9, new Object[] {A140WWPDiscussionMessageDate, A141WWPDiscussionMessageMessage, A142WWPDiscussionMessageEntityReco, A49WWPUserExtendedId, A62WWPEntityId, n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId, A137WWPDiscussionMessageId});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000G12 */
                  pr_default.execute(10, new Object[] {A137WWPDiscussionMessageId});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000G13 */
            pr_default.execute(11, new Object[] {A49WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = BC000G13_A40000WWPUserExtendedPhoto_GXI[0];
            A50WWPUserExtendedFullName = BC000G13_A50WWPUserExtendedFullName[0];
            A52WWPUserExtendedPhoto = BC000G13_A52WWPUserExtendedPhoto[0];
            pr_default.close(11);
            /* Using cursor BC000G14 */
            pr_default.execute(12, new Object[] {A62WWPEntityId});
            A63WWPEntityName = BC000G14_A63WWPEntityName[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000G15 */
            pr_default.execute(13, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessage"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor BC000G16 */
            pr_default.execute(14, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessageMention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
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

      public void ScanKeyStart0G17( )
      {
         /* Using cursor BC000G17 */
         pr_default.execute(15, new Object[] {A137WWPDiscussionMessageId});
         RcdFound17 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = BC000G17_A137WWPDiscussionMessageId[0];
            A140WWPDiscussionMessageDate = BC000G17_A140WWPDiscussionMessageDate[0];
            A141WWPDiscussionMessageMessage = BC000G17_A141WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G17_A40000WWPUserExtendedPhoto_GXI[0];
            A50WWPUserExtendedFullName = BC000G17_A50WWPUserExtendedFullName[0];
            A63WWPEntityName = BC000G17_A63WWPEntityName[0];
            A142WWPDiscussionMessageEntityReco = BC000G17_A142WWPDiscussionMessageEntityReco[0];
            A49WWPUserExtendedId = BC000G17_A49WWPUserExtendedId[0];
            A62WWPEntityId = BC000G17_A62WWPEntityId[0];
            A136WWPDiscussionMessageThreadId = BC000G17_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = BC000G17_n136WWPDiscussionMessageThreadId[0];
            A52WWPUserExtendedPhoto = BC000G17_A52WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound17 = 0;
         ScanKeyLoad0G17( ) ;
      }

      protected void ScanKeyLoad0G17( )
      {
         sMode17 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = BC000G17_A137WWPDiscussionMessageId[0];
            A140WWPDiscussionMessageDate = BC000G17_A140WWPDiscussionMessageDate[0];
            A141WWPDiscussionMessageMessage = BC000G17_A141WWPDiscussionMessageMessage[0];
            A40000WWPUserExtendedPhoto_GXI = BC000G17_A40000WWPUserExtendedPhoto_GXI[0];
            A50WWPUserExtendedFullName = BC000G17_A50WWPUserExtendedFullName[0];
            A63WWPEntityName = BC000G17_A63WWPEntityName[0];
            A142WWPDiscussionMessageEntityReco = BC000G17_A142WWPDiscussionMessageEntityReco[0];
            A49WWPUserExtendedId = BC000G17_A49WWPUserExtendedId[0];
            A62WWPEntityId = BC000G17_A62WWPEntityId[0];
            A136WWPDiscussionMessageThreadId = BC000G17_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = BC000G17_n136WWPDiscussionMessageThreadId[0];
            A52WWPUserExtendedPhoto = BC000G17_A52WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode17;
      }

      protected void ScanKeyEnd0G17( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
         if ( (0==A136WWPDiscussionMessageThreadId) )
         {
            A136WWPDiscussionMessageThreadId = 0;
            n136WWPDiscussionMessageThreadId = false;
            n136WWPDiscussionMessageThreadId = true;
         }
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void AddRow0G17( )
      {
         VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
      }

      protected void ReadRow0G17( )
      {
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
      }

      protected void InitializeNonKey0G17( )
      {
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A49WWPUserExtendedId = "";
         A136WWPDiscussionMessageThreadId = 0;
         n136WWPDiscussionMessageThreadId = false;
         A141WWPDiscussionMessageMessage = "";
         A52WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A50WWPUserExtendedFullName = "";
         A62WWPEntityId = 0;
         A63WWPEntityName = "";
         A142WWPDiscussionMessageEntityReco = "";
         Z140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z141WWPDiscussionMessageMessage = "";
         Z142WWPDiscussionMessageEntityReco = "";
         Z49WWPUserExtendedId = "";
         Z62WWPEntityId = 0;
         Z136WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0G17( )
      {
         A137WWPDiscussionMessageId = 0;
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A140WWPDiscussionMessageDate = i140WWPDiscussionMessageDate;
         A49WWPUserExtendedId = i49WWPUserExtendedId;
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

      public void VarsToRow17( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj17 )
      {
         obj17.gxTpr_Mode = Gx_mode;
         obj17.gxTpr_Wwpdiscussionmessagedate = A140WWPDiscussionMessageDate;
         obj17.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         obj17.gxTpr_Wwpdiscussionmessagethreadid = A136WWPDiscussionMessageThreadId;
         obj17.gxTpr_Wwpdiscussionmessagemessage = A141WWPDiscussionMessageMessage;
         obj17.gxTpr_Wwpuserextendedphoto = A52WWPUserExtendedPhoto;
         obj17.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj17.gxTpr_Wwpuserextendedfullname = A50WWPUserExtendedFullName;
         obj17.gxTpr_Wwpentityid = A62WWPEntityId;
         obj17.gxTpr_Wwpentityname = A63WWPEntityName;
         obj17.gxTpr_Wwpdiscussionmessageentityrecordid = A142WWPDiscussionMessageEntityReco;
         obj17.gxTpr_Wwpdiscussionmessageid = A137WWPDiscussionMessageId;
         obj17.gxTpr_Wwpdiscussionmessageid_Z = Z137WWPDiscussionMessageId;
         obj17.gxTpr_Wwpdiscussionmessagedate_Z = Z140WWPDiscussionMessageDate;
         obj17.gxTpr_Wwpdiscussionmessagethreadid_Z = Z136WWPDiscussionMessageThreadId;
         obj17.gxTpr_Wwpdiscussionmessagemessage_Z = Z141WWPDiscussionMessageMessage;
         obj17.gxTpr_Wwpuserextendedid_Z = Z49WWPUserExtendedId;
         obj17.gxTpr_Wwpuserextendedfullname_Z = Z50WWPUserExtendedFullName;
         obj17.gxTpr_Wwpentityid_Z = Z62WWPEntityId;
         obj17.gxTpr_Wwpentityname_Z = Z63WWPEntityName;
         obj17.gxTpr_Wwpdiscussionmessageentityrecordid_Z = Z142WWPDiscussionMessageEntityReco;
         obj17.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj17.gxTpr_Wwpdiscussionmessagethreadid_N = (short)(Convert.ToInt16(n136WWPDiscussionMessageThreadId));
         obj17.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow17( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj17 )
      {
         obj17.gxTpr_Wwpdiscussionmessageid = A137WWPDiscussionMessageId;
         return  ;
      }

      public void RowToVars17( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage obj17 ,
                               int forceLoad )
      {
         Gx_mode = obj17.gxTpr_Mode;
         A140WWPDiscussionMessageDate = obj17.gxTpr_Wwpdiscussionmessagedate;
         A49WWPUserExtendedId = obj17.gxTpr_Wwpuserextendedid;
         A136WWPDiscussionMessageThreadId = obj17.gxTpr_Wwpdiscussionmessagethreadid;
         n136WWPDiscussionMessageThreadId = false;
         A141WWPDiscussionMessageMessage = obj17.gxTpr_Wwpdiscussionmessagemessage;
         A52WWPUserExtendedPhoto = obj17.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj17.gxTpr_Wwpuserextendedphoto_gxi;
         A50WWPUserExtendedFullName = obj17.gxTpr_Wwpuserextendedfullname;
         A62WWPEntityId = obj17.gxTpr_Wwpentityid;
         A63WWPEntityName = obj17.gxTpr_Wwpentityname;
         A142WWPDiscussionMessageEntityReco = obj17.gxTpr_Wwpdiscussionmessageentityrecordid;
         A137WWPDiscussionMessageId = obj17.gxTpr_Wwpdiscussionmessageid;
         Z137WWPDiscussionMessageId = obj17.gxTpr_Wwpdiscussionmessageid_Z;
         Z140WWPDiscussionMessageDate = obj17.gxTpr_Wwpdiscussionmessagedate_Z;
         Z136WWPDiscussionMessageThreadId = obj17.gxTpr_Wwpdiscussionmessagethreadid_Z;
         Z141WWPDiscussionMessageMessage = obj17.gxTpr_Wwpdiscussionmessagemessage_Z;
         Z49WWPUserExtendedId = obj17.gxTpr_Wwpuserextendedid_Z;
         Z50WWPUserExtendedFullName = obj17.gxTpr_Wwpuserextendedfullname_Z;
         Z62WWPEntityId = obj17.gxTpr_Wwpentityid_Z;
         Z63WWPEntityName = obj17.gxTpr_Wwpentityname_Z;
         Z142WWPDiscussionMessageEntityReco = obj17.gxTpr_Wwpdiscussionmessageentityrecordid_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj17.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n136WWPDiscussionMessageThreadId = (bool)(Convert.ToBoolean(obj17.gxTpr_Wwpdiscussionmessagethreadid_N));
         Gx_mode = obj17.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A137WWPDiscussionMessageId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0G17( ) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
         }
         ZM0G17( -4) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         ScanKeyStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
         }
         ZM0G17( -4) ;
         OnLoadActions0G17( ) ;
         AddRow0G17( ) ;
         ScanKeyEnd0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0G17( ) ;
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
               {
                  A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
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
                  Update0G17( ) ;
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
                  if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
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
                        Insert0G17( ) ;
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
                        Insert0G17( ) ;
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         SaveImpl( ) ;
         VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
         AfterTrn( ) ;
         VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A137WWPDiscussionMessageId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessage);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0G17( ) ;
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
               VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0G17( ) ;
         if ( RcdFound17 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
            {
               A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
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
            if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
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
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage_bc",pr_default);
         VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessage )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessage = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage) ;
            }
            else
            {
               RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessage.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars17( bcwwpbaseobjects_discussions_WWP_DiscussionMessage, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_DiscussionMessage WWP_DiscussionMessage_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
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
            return "wwpdiscussionmessage_Execute" ;
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
         Z140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z141WWPDiscussionMessageMessage = "";
         A141WWPDiscussionMessageMessage = "";
         Z142WWPDiscussionMessageEntityReco = "";
         A142WWPDiscussionMessageEntityReco = "";
         Z49WWPUserExtendedId = "";
         A49WWPUserExtendedId = "";
         Z50WWPUserExtendedFullName = "";
         A50WWPUserExtendedFullName = "";
         Z63WWPEntityName = "";
         A63WWPEntityName = "";
         Z52WWPUserExtendedPhoto = "";
         A52WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         GXt_char1 = "";
         BC000G4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G4_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000G4_A52WWPUserExtendedPhoto = new string[] {""} ;
         BC000G7_A137WWPDiscussionMessageId = new long[1] ;
         BC000G7_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000G7_A141WWPDiscussionMessageMessage = new string[] {""} ;
         BC000G7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G7_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000G7_A63WWPEntityName = new string[] {""} ;
         BC000G7_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000G7_A49WWPUserExtendedId = new string[] {""} ;
         BC000G7_A62WWPEntityId = new long[1] ;
         BC000G7_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G7_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000G7_A52WWPUserExtendedPhoto = new string[] {""} ;
         BC000G6_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G6_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000G5_A63WWPEntityName = new string[] {""} ;
         BC000G8_A137WWPDiscussionMessageId = new long[1] ;
         BC000G3_A137WWPDiscussionMessageId = new long[1] ;
         BC000G3_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000G3_A141WWPDiscussionMessageMessage = new string[] {""} ;
         BC000G3_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000G3_A49WWPUserExtendedId = new string[] {""} ;
         BC000G3_A62WWPEntityId = new long[1] ;
         BC000G3_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G3_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode17 = "";
         BC000G2_A137WWPDiscussionMessageId = new long[1] ;
         BC000G2_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000G2_A141WWPDiscussionMessageMessage = new string[] {""} ;
         BC000G2_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000G2_A49WWPUserExtendedId = new string[] {""} ;
         BC000G2_A62WWPEntityId = new long[1] ;
         BC000G2_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G2_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000G10_A137WWPDiscussionMessageId = new long[1] ;
         BC000G13_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G13_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000G13_A52WWPUserExtendedPhoto = new string[] {""} ;
         BC000G14_A63WWPEntityName = new string[] {""} ;
         BC000G15_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G15_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000G16_A137WWPDiscussionMessageId = new long[1] ;
         BC000G16_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BC000G17_A137WWPDiscussionMessageId = new long[1] ;
         BC000G17_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000G17_A141WWPDiscussionMessageMessage = new string[] {""} ;
         BC000G17_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000G17_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000G17_A63WWPEntityName = new string[] {""} ;
         BC000G17_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         BC000G17_A49WWPUserExtendedId = new string[] {""} ;
         BC000G17_A62WWPEntityId = new long[1] ;
         BC000G17_A136WWPDiscussionMessageThreadId = new long[1] ;
         BC000G17_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         BC000G17_A52WWPUserExtendedPhoto = new string[] {""} ;
         i140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i49WWPUserExtendedId = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage_bc__default(),
            new Object[][] {
                new Object[] {
               BC000G2_A137WWPDiscussionMessageId, BC000G2_A140WWPDiscussionMessageDate, BC000G2_A141WWPDiscussionMessageMessage, BC000G2_A142WWPDiscussionMessageEntityReco, BC000G2_A49WWPUserExtendedId, BC000G2_A62WWPEntityId, BC000G2_A136WWPDiscussionMessageThreadId, BC000G2_n136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000G3_A137WWPDiscussionMessageId, BC000G3_A140WWPDiscussionMessageDate, BC000G3_A141WWPDiscussionMessageMessage, BC000G3_A142WWPDiscussionMessageEntityReco, BC000G3_A49WWPUserExtendedId, BC000G3_A62WWPEntityId, BC000G3_A136WWPDiscussionMessageThreadId, BC000G3_n136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000G4_A40000WWPUserExtendedPhoto_GXI, BC000G4_A50WWPUserExtendedFullName, BC000G4_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G5_A63WWPEntityName
               }
               , new Object[] {
               BC000G6_A136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000G7_A137WWPDiscussionMessageId, BC000G7_A140WWPDiscussionMessageDate, BC000G7_A141WWPDiscussionMessageMessage, BC000G7_A40000WWPUserExtendedPhoto_GXI, BC000G7_A50WWPUserExtendedFullName, BC000G7_A63WWPEntityName, BC000G7_A142WWPDiscussionMessageEntityReco, BC000G7_A49WWPUserExtendedId, BC000G7_A62WWPEntityId, BC000G7_A136WWPDiscussionMessageThreadId,
               BC000G7_n136WWPDiscussionMessageThreadId, BC000G7_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G8_A137WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G10_A137WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000G13_A40000WWPUserExtendedPhoto_GXI, BC000G13_A50WWPUserExtendedFullName, BC000G13_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC000G14_A63WWPEntityName
               }
               , new Object[] {
               BC000G15_A136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               BC000G16_A137WWPDiscussionMessageId, BC000G16_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000G17_A137WWPDiscussionMessageId, BC000G17_A140WWPDiscussionMessageDate, BC000G17_A141WWPDiscussionMessageMessage, BC000G17_A40000WWPUserExtendedPhoto_GXI, BC000G17_A50WWPUserExtendedFullName, BC000G17_A63WWPEntityName, BC000G17_A142WWPDiscussionMessageEntityReco, BC000G17_A49WWPUserExtendedId, BC000G17_A62WWPEntityId, BC000G17_A136WWPDiscussionMessageThreadId,
               BC000G17_n136WWPDiscussionMessageThreadId, BC000G17_A52WWPUserExtendedPhoto
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
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private int trnEnded ;
      private long Z137WWPDiscussionMessageId ;
      private long A137WWPDiscussionMessageId ;
      private long Z62WWPEntityId ;
      private long A62WWPEntityId ;
      private long Z136WWPDiscussionMessageThreadId ;
      private long A136WWPDiscussionMessageThreadId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z49WWPUserExtendedId ;
      private string A49WWPUserExtendedId ;
      private string GXt_char1 ;
      private string sMode17 ;
      private string i49WWPUserExtendedId ;
      private DateTime Z140WWPDiscussionMessageDate ;
      private DateTime A140WWPDiscussionMessageDate ;
      private DateTime i140WWPDiscussionMessageDate ;
      private bool n136WWPDiscussionMessageThreadId ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z141WWPDiscussionMessageMessage ;
      private string A141WWPDiscussionMessageMessage ;
      private string Z142WWPDiscussionMessageEntityReco ;
      private string A142WWPDiscussionMessageEntityReco ;
      private string Z50WWPUserExtendedFullName ;
      private string A50WWPUserExtendedFullName ;
      private string Z63WWPEntityName ;
      private string A63WWPEntityName ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z52WWPUserExtendedPhoto ;
      private string A52WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessage bcwwpbaseobjects_discussions_WWP_DiscussionMessage ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000G4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G4_A50WWPUserExtendedFullName ;
      private string[] BC000G4_A52WWPUserExtendedPhoto ;
      private long[] BC000G7_A137WWPDiscussionMessageId ;
      private DateTime[] BC000G7_A140WWPDiscussionMessageDate ;
      private string[] BC000G7_A141WWPDiscussionMessageMessage ;
      private string[] BC000G7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G7_A50WWPUserExtendedFullName ;
      private string[] BC000G7_A63WWPEntityName ;
      private string[] BC000G7_A142WWPDiscussionMessageEntityReco ;
      private string[] BC000G7_A49WWPUserExtendedId ;
      private long[] BC000G7_A62WWPEntityId ;
      private long[] BC000G7_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G7_n136WWPDiscussionMessageThreadId ;
      private string[] BC000G7_A52WWPUserExtendedPhoto ;
      private long[] BC000G6_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G6_n136WWPDiscussionMessageThreadId ;
      private string[] BC000G5_A63WWPEntityName ;
      private long[] BC000G8_A137WWPDiscussionMessageId ;
      private long[] BC000G3_A137WWPDiscussionMessageId ;
      private DateTime[] BC000G3_A140WWPDiscussionMessageDate ;
      private string[] BC000G3_A141WWPDiscussionMessageMessage ;
      private string[] BC000G3_A142WWPDiscussionMessageEntityReco ;
      private string[] BC000G3_A49WWPUserExtendedId ;
      private long[] BC000G3_A62WWPEntityId ;
      private long[] BC000G3_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G3_n136WWPDiscussionMessageThreadId ;
      private long[] BC000G2_A137WWPDiscussionMessageId ;
      private DateTime[] BC000G2_A140WWPDiscussionMessageDate ;
      private string[] BC000G2_A141WWPDiscussionMessageMessage ;
      private string[] BC000G2_A142WWPDiscussionMessageEntityReco ;
      private string[] BC000G2_A49WWPUserExtendedId ;
      private long[] BC000G2_A62WWPEntityId ;
      private long[] BC000G2_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G2_n136WWPDiscussionMessageThreadId ;
      private long[] BC000G10_A137WWPDiscussionMessageId ;
      private string[] BC000G13_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G13_A50WWPUserExtendedFullName ;
      private string[] BC000G13_A52WWPUserExtendedPhoto ;
      private string[] BC000G14_A63WWPEntityName ;
      private long[] BC000G15_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G15_n136WWPDiscussionMessageThreadId ;
      private long[] BC000G16_A137WWPDiscussionMessageId ;
      private string[] BC000G16_A138WWPDiscussionMentionUserId ;
      private long[] BC000G17_A137WWPDiscussionMessageId ;
      private DateTime[] BC000G17_A140WWPDiscussionMessageDate ;
      private string[] BC000G17_A141WWPDiscussionMessageMessage ;
      private string[] BC000G17_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000G17_A50WWPUserExtendedFullName ;
      private string[] BC000G17_A63WWPEntityName ;
      private string[] BC000G17_A142WWPDiscussionMessageEntityReco ;
      private string[] BC000G17_A49WWPUserExtendedId ;
      private long[] BC000G17_A62WWPEntityId ;
      private long[] BC000G17_A136WWPDiscussionMessageThreadId ;
      private bool[] BC000G17_n136WWPDiscussionMessageThreadId ;
      private string[] BC000G17_A52WWPUserExtendedPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessage_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000G7;
        prmBC000G7 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G6;
        prmBC000G6 = new Object[] {
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000G4;
        prmBC000G4 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmBC000G5;
        prmBC000G5 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000G8;
        prmBC000G8 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G3;
        prmBC000G3 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G2;
        prmBC000G2 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G9;
        prmBC000G9 = new Object[] {
        new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
        new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmBC000G10;
        prmBC000G10 = new Object[] {
        };
        Object[] prmBC000G11;
        prmBC000G11 = new Object[] {
        new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
        new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G12;
        prmBC000G12 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G13;
        prmBC000G13 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmBC000G14;
        prmBC000G14 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000G15;
        prmBC000G15 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G16;
        prmBC000G16 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000G17;
        prmBC000G17 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000G2", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId  FOR UPDATE OF WWP_DiscussionMessage",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G3", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G4", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G5", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G6", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G7", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G8", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G9", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessage(WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId) VALUES(:WWPDiscussionMessageDate, :WWPDiscussionMessageMessage, :WWPDiscussionMessageEntityReco, :WWPUserExtendedId, :WWPEntityId, :WWPDiscussionMessageThreadId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G9)
           ,new CursorDef("BC000G10", "SELECT currval('WWPDiscussionMessageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G11", "SAVEPOINT gxupdate;UPDATE WWP_DiscussionMessage SET WWPDiscussionMessageDate=:WWPDiscussionMessageDate, WWPDiscussionMessageMessage=:WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco=:WWPDiscussionMessageEntityReco, WWPUserExtendedId=:WWPUserExtendedId, WWPEntityId=:WWPEntityId, WWPDiscussionMessageThreadId=:WWPDiscussionMessageThreadId  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G11)
           ,new CursorDef("BC000G12", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessage  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000G12)
           ,new CursorDef("BC000G13", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G14", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000G15", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000G16", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000G17", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000G17,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
     }
  }

}

}
