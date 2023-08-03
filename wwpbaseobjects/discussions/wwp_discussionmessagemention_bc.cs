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
   public class wwp_discussionmessagemention_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_discussionmessagemention_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessagemention_bc( IGxContext context )
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
         ReadRow0H18( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0H18( ) ;
         standaloneModal( ) ;
         AddRow0H18( ) ;
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
               Z138WWPDiscussionMentionUserId = A138WWPDiscussionMentionUserId;
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

      protected void CONFIRM_0H0( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0H18( ) ;
            }
            else
            {
               CheckExtendedTable0H18( ) ;
               if ( AnyError == 0 )
               {
                  ZM0H18( 2) ;
                  ZM0H18( 3) ;
               }
               CloseExtendedTableCursors0H18( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0H18( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
         }
         if ( ( GX_JID == 3 ) || ( GX_JID == 0 ) )
         {
            Z139WWPDiscussionMentionUserName = A139WWPDiscussionMentionUserName;
         }
         if ( GX_JID == -1 )
         {
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z138WWPDiscussionMentionUserId = A138WWPDiscussionMentionUserId;
            Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
            Z139WWPDiscussionMentionUserName = A139WWPDiscussionMentionUserName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0H18( )
      {
         /* Using cursor BC000H6 */
         pr_default.execute(4, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound18 = 1;
            A140WWPDiscussionMessageDate = BC000H6_A140WWPDiscussionMessageDate[0];
            A139WWPDiscussionMentionUserName = BC000H6_A139WWPDiscussionMentionUserName[0];
            ZM0H18( -1) ;
         }
         pr_default.close(4);
         OnLoadActions0H18( ) ;
      }

      protected void OnLoadActions0H18( )
      {
      }

      protected void CheckExtendedTable0H18( )
      {
         nIsDirty_18 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000H4 */
         pr_default.execute(2, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_DiscussionMessage'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
         }
         A140WWPDiscussionMessageDate = BC000H4_A140WWPDiscussionMessageDate[0];
         pr_default.close(2);
         /* Using cursor BC000H5 */
         pr_default.execute(3, new Object[] {A138WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
            AnyError = 1;
         }
         A139WWPDiscussionMentionUserName = BC000H5_A139WWPDiscussionMentionUserName[0];
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0H18( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0H18( )
      {
         /* Using cursor BC000H7 */
         pr_default.execute(5, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound18 = 1;
         }
         else
         {
            RcdFound18 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000H3 */
         pr_default.execute(1, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0H18( 1) ;
            RcdFound18 = 1;
            A137WWPDiscussionMessageId = BC000H3_A137WWPDiscussionMessageId[0];
            A138WWPDiscussionMentionUserId = BC000H3_A138WWPDiscussionMentionUserId[0];
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z138WWPDiscussionMentionUserId = A138WWPDiscussionMentionUserId;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0H18( ) ;
            if ( AnyError == 1 )
            {
               RcdFound18 = 0;
               InitializeNonKey0H18( ) ;
            }
            Gx_mode = sMode18;
         }
         else
         {
            RcdFound18 = 0;
            InitializeNonKey0H18( ) ;
            sMode18 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode18;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0H18( ) ;
         if ( RcdFound18 == 0 )
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
         CONFIRM_0H0( ) ;
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

      protected void CheckOptimisticConcurrency0H18( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000H2 */
            pr_default.execute(0, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessageMention"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0H18( 0) ;
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000H8 */
                     pr_default.execute(6, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
                     if ( (pr_default.getStatus(6) == 1) )
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
               Load0H18( ) ;
            }
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void Update0H18( )
      {
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0H18( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0H18( ) ;
                  if ( AnyError == 0 )
                  {
                     /* No attributes to update on table WWP_DiscussionMessageMention */
                     DeferredUpdate0H18( ) ;
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
            EndLevel0H18( ) ;
         }
         CloseExtendedTableCursors0H18( ) ;
      }

      protected void DeferredUpdate0H18( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0H18( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0H18( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0H18( ) ;
            AfterConfirm0H18( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0H18( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000H9 */
                  pr_default.execute(7, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessageMention");
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
         sMode18 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0H18( ) ;
         Gx_mode = sMode18;
      }

      protected void OnDeleteControls0H18( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A137WWPDiscussionMessageId});
            A140WWPDiscussionMessageDate = BC000H10_A140WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A138WWPDiscussionMentionUserId});
            A139WWPDiscussionMentionUserName = BC000H11_A139WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
      }

      protected void EndLevel0H18( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0H18( ) ;
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

      public void ScanKeyStart0H18( )
      {
         /* Using cursor BC000H12 */
         pr_default.execute(10, new Object[] {A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId});
         RcdFound18 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound18 = 1;
            A140WWPDiscussionMessageDate = BC000H12_A140WWPDiscussionMessageDate[0];
            A139WWPDiscussionMentionUserName = BC000H12_A139WWPDiscussionMentionUserName[0];
            A137WWPDiscussionMessageId = BC000H12_A137WWPDiscussionMessageId[0];
            A138WWPDiscussionMentionUserId = BC000H12_A138WWPDiscussionMentionUserId[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0H18( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound18 = 0;
         ScanKeyLoad0H18( ) ;
      }

      protected void ScanKeyLoad0H18( )
      {
         sMode18 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound18 = 1;
            A140WWPDiscussionMessageDate = BC000H12_A140WWPDiscussionMessageDate[0];
            A139WWPDiscussionMentionUserName = BC000H12_A139WWPDiscussionMentionUserName[0];
            A137WWPDiscussionMessageId = BC000H12_A137WWPDiscussionMessageId[0];
            A138WWPDiscussionMentionUserId = BC000H12_A138WWPDiscussionMentionUserId[0];
         }
         Gx_mode = sMode18;
      }

      protected void ScanKeyEnd0H18( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0H18( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0H18( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0H18( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0H18( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0H18( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0H18( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0H18( )
      {
      }

      protected void send_integrity_lvl_hashes0H18( )
      {
      }

      protected void AddRow0H18( )
      {
         VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
      }

      protected void ReadRow0H18( )
      {
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
      }

      protected void InitializeNonKey0H18( )
      {
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A139WWPDiscussionMentionUserName = "";
      }

      protected void InitAll0H18( )
      {
         A137WWPDiscussionMessageId = 0;
         A138WWPDiscussionMentionUserId = "";
         InitializeNonKey0H18( ) ;
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

      public void VarsToRow18( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj18 )
      {
         obj18.gxTpr_Mode = Gx_mode;
         obj18.gxTpr_Wwpdiscussionmessagedate = A140WWPDiscussionMessageDate;
         obj18.gxTpr_Wwpdiscussionmentionusername = A139WWPDiscussionMentionUserName;
         obj18.gxTpr_Wwpdiscussionmessageid = A137WWPDiscussionMessageId;
         obj18.gxTpr_Wwpdiscussionmentionuserid = A138WWPDiscussionMentionUserId;
         obj18.gxTpr_Wwpdiscussionmessageid_Z = Z137WWPDiscussionMessageId;
         obj18.gxTpr_Wwpdiscussionmessagedate_Z = Z140WWPDiscussionMessageDate;
         obj18.gxTpr_Wwpdiscussionmentionuserid_Z = Z138WWPDiscussionMentionUserId;
         obj18.gxTpr_Wwpdiscussionmentionusername_Z = Z139WWPDiscussionMentionUserName;
         obj18.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow18( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj18 )
      {
         obj18.gxTpr_Wwpdiscussionmessageid = A137WWPDiscussionMessageId;
         obj18.gxTpr_Wwpdiscussionmentionuserid = A138WWPDiscussionMentionUserId;
         return  ;
      }

      public void RowToVars18( GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention obj18 ,
                               int forceLoad )
      {
         Gx_mode = obj18.gxTpr_Mode;
         A140WWPDiscussionMessageDate = obj18.gxTpr_Wwpdiscussionmessagedate;
         A139WWPDiscussionMentionUserName = obj18.gxTpr_Wwpdiscussionmentionusername;
         A137WWPDiscussionMessageId = obj18.gxTpr_Wwpdiscussionmessageid;
         A138WWPDiscussionMentionUserId = obj18.gxTpr_Wwpdiscussionmentionuserid;
         Z137WWPDiscussionMessageId = obj18.gxTpr_Wwpdiscussionmessageid_Z;
         Z140WWPDiscussionMessageDate = obj18.gxTpr_Wwpdiscussionmessagedate_Z;
         Z138WWPDiscussionMentionUserId = obj18.gxTpr_Wwpdiscussionmentionuserid_Z;
         Z139WWPDiscussionMentionUserName = obj18.gxTpr_Wwpdiscussionmentionusername_Z;
         Gx_mode = obj18.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A137WWPDiscussionMessageId = (long)getParm(obj,0);
         A138WWPDiscussionMentionUserId = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0H18( ) ;
         ScanKeyStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem("Não existe 'WWP_DiscussionMessage'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A140WWPDiscussionMessageDate = BC000H10_A140WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A138WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A139WWPDiscussionMentionUserName = BC000H11_A139WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z138WWPDiscussionMentionUserId = A138WWPDiscussionMentionUserId;
         }
         ZM0H18( -1) ;
         OnLoadActions0H18( ) ;
         AddRow0H18( ) ;
         ScanKeyEnd0H18( ) ;
         if ( RcdFound18 == 0 )
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         ScanKeyStart0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC000H10 */
            pr_default.execute(8, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(8) == 101) )
            {
               GX_msglist.addItem("Não existe 'WWP_DiscussionMessage'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
            }
            A140WWPDiscussionMessageDate = BC000H10_A140WWPDiscussionMessageDate[0];
            pr_default.close(8);
            /* Using cursor BC000H11 */
            pr_default.execute(9, new Object[] {A138WWPDiscussionMentionUserId});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Mention User'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMENTIONUSERID");
               AnyError = 1;
            }
            A139WWPDiscussionMentionUserName = BC000H11_A139WWPDiscussionMentionUserName[0];
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z138WWPDiscussionMentionUserId = A138WWPDiscussionMentionUserId;
         }
         ZM0H18( -1) ;
         OnLoadActions0H18( ) ;
         AddRow0H18( ) ;
         ScanKeyEnd0H18( ) ;
         if ( RcdFound18 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0H18( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0H18( ) ;
         }
         else
         {
            if ( RcdFound18 == 1 )
            {
               if ( ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A138WWPDiscussionMentionUserId, Z138WWPDiscussionMentionUserId) != 0 ) )
               {
                  A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
                  A138WWPDiscussionMentionUserId = Z138WWPDiscussionMentionUserId;
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
                  Update0H18( ) ;
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
                  if ( ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A138WWPDiscussionMentionUserId, Z138WWPDiscussionMentionUserId) != 0 ) )
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
                        Insert0H18( ) ;
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
                        Insert0H18( ) ;
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         SaveImpl( ) ;
         VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H18( ) ;
         AfterTrn( ) ;
         VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention auxBC = new GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A137WWPDiscussionMessageId, A138WWPDiscussionMentionUserId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention);
               auxBC.Save();
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0H18( ) ;
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
               VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0H18( ) ;
         if ( RcdFound18 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A138WWPDiscussionMentionUserId, Z138WWPDiscussionMentionUserId) != 0 ) )
            {
               A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
               A138WWPDiscussionMentionUserId = Z138WWPDiscussionMentionUserId;
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
            if ( ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId ) || ( StringUtil.StrCmp(A138WWPDiscussionMentionUserId, Z138WWPDiscussionMentionUserId) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessagemention_bc",pr_default);
         VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
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
         Gx_mode = bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention )
         {
            bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention = (GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention) ;
            }
            else
            {
               RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars18( bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_DiscussionMessageMention WWP_DiscussionMessageMention_BC
      {
         get {
            return bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
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
            return "wwpdiscussionmessagemention_Execute" ;
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
         pr_default.close(8);
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
         Z138WWPDiscussionMentionUserId = "";
         A138WWPDiscussionMentionUserId = "";
         Z140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z139WWPDiscussionMentionUserName = "";
         A139WWPDiscussionMentionUserName = "";
         BC000H6_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000H6_A139WWPDiscussionMentionUserName = new string[] {""} ;
         BC000H6_A137WWPDiscussionMessageId = new long[1] ;
         BC000H6_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BC000H4_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000H5_A139WWPDiscussionMentionUserName = new string[] {""} ;
         BC000H7_A137WWPDiscussionMessageId = new long[1] ;
         BC000H7_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BC000H3_A137WWPDiscussionMessageId = new long[1] ;
         BC000H3_A138WWPDiscussionMentionUserId = new string[] {""} ;
         sMode18 = "";
         BC000H2_A137WWPDiscussionMessageId = new long[1] ;
         BC000H2_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BC000H10_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000H11_A139WWPDiscussionMentionUserName = new string[] {""} ;
         BC000H12_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         BC000H12_A139WWPDiscussionMentionUserName = new string[] {""} ;
         BC000H12_A137WWPDiscussionMessageId = new long[1] ;
         BC000H12_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessagemention_bc__default(),
            new Object[][] {
                new Object[] {
               BC000H2_A137WWPDiscussionMessageId, BC000H2_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000H3_A137WWPDiscussionMessageId, BC000H3_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000H4_A140WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000H5_A139WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC000H6_A140WWPDiscussionMessageDate, BC000H6_A139WWPDiscussionMentionUserName, BC000H6_A137WWPDiscussionMessageId, BC000H6_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000H7_A137WWPDiscussionMessageId, BC000H7_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000H10_A140WWPDiscussionMessageDate
               }
               , new Object[] {
               BC000H11_A139WWPDiscussionMentionUserName
               }
               , new Object[] {
               BC000H12_A140WWPDiscussionMessageDate, BC000H12_A139WWPDiscussionMentionUserName, BC000H12_A137WWPDiscussionMessageId, BC000H12_A138WWPDiscussionMentionUserId
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
      private short RcdFound18 ;
      private short nIsDirty_18 ;
      private int trnEnded ;
      private long Z137WWPDiscussionMessageId ;
      private long A137WWPDiscussionMessageId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z138WWPDiscussionMentionUserId ;
      private string A138WWPDiscussionMentionUserId ;
      private string sMode18 ;
      private DateTime Z140WWPDiscussionMessageDate ;
      private DateTime A140WWPDiscussionMessageDate ;
      private bool mustCommit ;
      private string Z139WWPDiscussionMentionUserName ;
      private string A139WWPDiscussionMentionUserName ;
      private GeneXus.Programs.wwpbaseobjects.discussions.SdtWWP_DiscussionMessageMention bcwwpbaseobjects_discussions_WWP_DiscussionMessageMention ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] BC000H6_A140WWPDiscussionMessageDate ;
      private string[] BC000H6_A139WWPDiscussionMentionUserName ;
      private long[] BC000H6_A137WWPDiscussionMessageId ;
      private string[] BC000H6_A138WWPDiscussionMentionUserId ;
      private DateTime[] BC000H4_A140WWPDiscussionMessageDate ;
      private string[] BC000H5_A139WWPDiscussionMentionUserName ;
      private long[] BC000H7_A137WWPDiscussionMessageId ;
      private string[] BC000H7_A138WWPDiscussionMentionUserId ;
      private long[] BC000H3_A137WWPDiscussionMessageId ;
      private string[] BC000H3_A138WWPDiscussionMentionUserId ;
      private long[] BC000H2_A137WWPDiscussionMessageId ;
      private string[] BC000H2_A138WWPDiscussionMentionUserId ;
      private DateTime[] BC000H10_A140WWPDiscussionMessageDate ;
      private string[] BC000H11_A139WWPDiscussionMentionUserName ;
      private DateTime[] BC000H12_A140WWPDiscussionMessageDate ;
      private string[] BC000H12_A139WWPDiscussionMentionUserName ;
      private long[] BC000H12_A137WWPDiscussionMessageId ;
      private string[] BC000H12_A138WWPDiscussionMentionUserId ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_discussionmessagemention_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessagemention_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000H6;
        prmBC000H6 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H4;
        prmBC000H4 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000H5;
        prmBC000H5 = new Object[] {
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H7;
        prmBC000H7 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H3;
        prmBC000H3 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H2;
        prmBC000H2 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H8;
        prmBC000H8 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H9;
        prmBC000H9 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H12;
        prmBC000H12 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        Object[] prmBC000H10;
        prmBC000H10 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmBC000H11;
        prmBC000H11 = new Object[] {
        new ParDef("WWPDiscussionMentionUserId",GXType.Char,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000H2", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId  FOR UPDATE OF WWP_DiscussionMessageMention",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H3", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H4", "SELECT WWPDiscussionMessageDate FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H5", "SELECT WWPUserExtendedFullName AS WWPDiscussionMentionUserName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H6", "SELECT T2.WWPDiscussionMessageDate, T3.WWPUserExtendedFullName AS WWPDiscussionMentionUserName, TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId AS WWPDiscussionMentionUserId FROM ((WWP_DiscussionMessageMention TM1 INNER JOIN WWP_DiscussionMessage T2 ON T2.WWPDiscussionMessageId = TM1.WWPDiscussionMessageId) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPDiscussionMentionUserId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId and TM1.WWPDiscussionMentionUserId = ( :WWPDiscussionMentionUserId) ORDER BY TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H7", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H8", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessageMention(WWPDiscussionMessageId, WWPDiscussionMentionUserId) VALUES(:WWPDiscussionMessageId, :WWPDiscussionMentionUserId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000H8)
           ,new CursorDef("BC000H9", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessageMention  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId AND WWPDiscussionMentionUserId = :WWPDiscussionMentionUserId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000H9)
           ,new CursorDef("BC000H10", "SELECT WWPDiscussionMessageDate FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H11", "SELECT WWPUserExtendedFullName AS WWPDiscussionMentionUserName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000H12", "SELECT T2.WWPDiscussionMessageDate, T3.WWPUserExtendedFullName AS WWPDiscussionMentionUserName, TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId AS WWPDiscussionMentionUserId FROM ((WWP_DiscussionMessageMention TM1 INNER JOIN WWP_DiscussionMessage T2 ON T2.WWPDiscussionMessageId = TM1.WWPDiscussionMessageId) INNER JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPDiscussionMentionUserId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId and TM1.WWPDiscussionMentionUserId = ( :WWPDiscussionMentionUserId) ORDER BY TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMentionUserId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000H12,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 8 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 10 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              return;
     }
  }

}

}
