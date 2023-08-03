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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_userextended_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended_bc( IGxContext context )
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
         ReadRow066( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey066( ) ;
         standaloneModal( ) ;
         AddRow066( ) ;
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
               Z49WWPUserExtendedId = A49WWPUserExtendedId;
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

      protected void CONFIRM_060( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls066( ) ;
            }
            else
            {
               CheckExtendedTable066( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors066( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z58WWPUserExtendedName = A58WWPUserExtendedName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
            Z57WWPUserExtendedPhone = A57WWPUserExtendedPhone;
            Z51WWPUserExtendedEmail = A51WWPUserExtendedEmail;
            Z53WWPUserExtendedEmaiNotif = A53WWPUserExtendedEmaiNotif;
            Z54WWPUserExtendedSMSNotif = A54WWPUserExtendedSMSNotif;
            Z55WWPUserExtendedMobileNotif = A55WWPUserExtendedMobileNotif;
            Z56WWPUserExtendedDesktopNotif = A56WWPUserExtendedDesktopNotif;
            Z59WWPUserExtendedDeleted = A59WWPUserExtendedDeleted;
            Z60WWPUserExtendedDeletedIn = A60WWPUserExtendedDeletedIn;
         }
         if ( GX_JID == -2 )
         {
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z52WWPUserExtendedPhoto = A52WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z58WWPUserExtendedName = A58WWPUserExtendedName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
            Z57WWPUserExtendedPhone = A57WWPUserExtendedPhone;
            Z51WWPUserExtendedEmail = A51WWPUserExtendedEmail;
            Z53WWPUserExtendedEmaiNotif = A53WWPUserExtendedEmaiNotif;
            Z54WWPUserExtendedSMSNotif = A54WWPUserExtendedSMSNotif;
            Z55WWPUserExtendedMobileNotif = A55WWPUserExtendedMobileNotif;
            Z56WWPUserExtendedDesktopNotif = A56WWPUserExtendedDesktopNotif;
            Z59WWPUserExtendedDeleted = A59WWPUserExtendedDeleted;
            Z60WWPUserExtendedDeletedIn = A60WWPUserExtendedDeletedIn;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load066( )
      {
         /* Using cursor BC00064 */
         pr_default.execute(2, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound6 = 1;
            A40000WWPUserExtendedPhoto_GXI = BC00064_A40000WWPUserExtendedPhoto_GXI[0];
            A58WWPUserExtendedName = BC00064_A58WWPUserExtendedName[0];
            A50WWPUserExtendedFullName = BC00064_A50WWPUserExtendedFullName[0];
            A57WWPUserExtendedPhone = BC00064_A57WWPUserExtendedPhone[0];
            A51WWPUserExtendedEmail = BC00064_A51WWPUserExtendedEmail[0];
            A53WWPUserExtendedEmaiNotif = BC00064_A53WWPUserExtendedEmaiNotif[0];
            A54WWPUserExtendedSMSNotif = BC00064_A54WWPUserExtendedSMSNotif[0];
            A55WWPUserExtendedMobileNotif = BC00064_A55WWPUserExtendedMobileNotif[0];
            A56WWPUserExtendedDesktopNotif = BC00064_A56WWPUserExtendedDesktopNotif[0];
            A59WWPUserExtendedDeleted = BC00064_A59WWPUserExtendedDeleted[0];
            A60WWPUserExtendedDeletedIn = BC00064_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = BC00064_n60WWPUserExtendedDeletedIn[0];
            A52WWPUserExtendedPhoto = BC00064_A52WWPUserExtendedPhoto[0];
            ZM066( -2) ;
         }
         pr_default.close(2);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A51WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("O valor de User Email não coincide com o padrão especificado", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor BC00065 */
         pr_default.execute(3, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00063 */
         pr_default.execute(1, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 2) ;
            RcdFound6 = 1;
            A49WWPUserExtendedId = BC00063_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC00063_n49WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC00063_A40000WWPUserExtendedPhoto_GXI[0];
            A58WWPUserExtendedName = BC00063_A58WWPUserExtendedName[0];
            A50WWPUserExtendedFullName = BC00063_A50WWPUserExtendedFullName[0];
            A57WWPUserExtendedPhone = BC00063_A57WWPUserExtendedPhone[0];
            A51WWPUserExtendedEmail = BC00063_A51WWPUserExtendedEmail[0];
            A53WWPUserExtendedEmaiNotif = BC00063_A53WWPUserExtendedEmaiNotif[0];
            A54WWPUserExtendedSMSNotif = BC00063_A54WWPUserExtendedSMSNotif[0];
            A55WWPUserExtendedMobileNotif = BC00063_A55WWPUserExtendedMobileNotif[0];
            A56WWPUserExtendedDesktopNotif = BC00063_A56WWPUserExtendedDesktopNotif[0];
            A59WWPUserExtendedDeleted = BC00063_A59WWPUserExtendedDeleted[0];
            A60WWPUserExtendedDeletedIn = BC00063_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = BC00063_n60WWPUserExtendedDeletedIn[0];
            A52WWPUserExtendedPhoto = BC00063_A52WWPUserExtendedPhoto[0];
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode6;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         CONFIRM_060( ) ;
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

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00062 */
            pr_default.execute(0, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z58WWPUserExtendedName, BC00062_A58WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z50WWPUserExtendedFullName, BC00062_A50WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z57WWPUserExtendedPhone, BC00062_A57WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z51WWPUserExtendedEmail, BC00062_A51WWPUserExtendedEmail[0]) != 0 ) || ( Z53WWPUserExtendedEmaiNotif != BC00062_A53WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z54WWPUserExtendedSMSNotif != BC00062_A54WWPUserExtendedSMSNotif[0] ) || ( Z55WWPUserExtendedMobileNotif != BC00062_A55WWPUserExtendedMobileNotif[0] ) || ( Z56WWPUserExtendedDesktopNotif != BC00062_A56WWPUserExtendedDesktopNotif[0] ) || ( Z59WWPUserExtendedDeleted != BC00062_A59WWPUserExtendedDeleted[0] ) || ( Z60WWPUserExtendedDeletedIn != BC00062_A60WWPUserExtendedDeletedIn[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00066 */
                     pr_default.execute(4, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId, A52WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A58WWPUserExtendedName, A50WWPUserExtendedFullName, A57WWPUserExtendedPhone, A51WWPUserExtendedEmail, A53WWPUserExtendedEmaiNotif, A54WWPUserExtendedSMSNotif, A55WWPUserExtendedMobileNotif, A56WWPUserExtendedDesktopNotif, A59WWPUserExtendedDeleted, n60WWPUserExtendedDeletedIn, A60WWPUserExtendedDeletedIn});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00067 */
                     pr_default.execute(5, new Object[] {A58WWPUserExtendedName, A50WWPUserExtendedFullName, A57WWPUserExtendedPhone, A51WWPUserExtendedEmail, A53WWPUserExtendedEmaiNotif, A54WWPUserExtendedSMSNotif, A55WWPUserExtendedMobileNotif, A56WWPUserExtendedDesktopNotif, A59WWPUserExtendedDeleted, n60WWPUserExtendedDeletedIn, A60WWPUserExtendedDeletedIn, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor BC00068 */
            pr_default.execute(6, new Object[] {A52WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n49WWPUserExtendedId, A49WWPUserExtendedId});
            pr_default.close(6);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00069 */
                  pr_default.execute(7, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel066( ) ;
         Gx_mode = sMode6;
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000610 */
            pr_default.execute(8, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessageMention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000611 */
            pr_default.execute(9, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessage"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
            /* Using cursor BC000612 */
            pr_default.execute(10, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor BC000613 */
            pr_default.execute(11, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebClient"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor BC000614 */
            pr_default.execute(12, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
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

      public void ScanKeyStart066( )
      {
         /* Using cursor BC000615 */
         pr_default.execute(13, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         RcdFound6 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A49WWPUserExtendedId = BC000615_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000615_n49WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000615_A40000WWPUserExtendedPhoto_GXI[0];
            A58WWPUserExtendedName = BC000615_A58WWPUserExtendedName[0];
            A50WWPUserExtendedFullName = BC000615_A50WWPUserExtendedFullName[0];
            A57WWPUserExtendedPhone = BC000615_A57WWPUserExtendedPhone[0];
            A51WWPUserExtendedEmail = BC000615_A51WWPUserExtendedEmail[0];
            A53WWPUserExtendedEmaiNotif = BC000615_A53WWPUserExtendedEmaiNotif[0];
            A54WWPUserExtendedSMSNotif = BC000615_A54WWPUserExtendedSMSNotif[0];
            A55WWPUserExtendedMobileNotif = BC000615_A55WWPUserExtendedMobileNotif[0];
            A56WWPUserExtendedDesktopNotif = BC000615_A56WWPUserExtendedDesktopNotif[0];
            A59WWPUserExtendedDeleted = BC000615_A59WWPUserExtendedDeleted[0];
            A60WWPUserExtendedDeletedIn = BC000615_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = BC000615_n60WWPUserExtendedDeletedIn[0];
            A52WWPUserExtendedPhoto = BC000615_A52WWPUserExtendedPhoto[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound6 = 0;
         ScanKeyLoad066( ) ;
      }

      protected void ScanKeyLoad066( )
      {
         sMode6 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound6 = 1;
            A49WWPUserExtendedId = BC000615_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = BC000615_n49WWPUserExtendedId[0];
            A40000WWPUserExtendedPhoto_GXI = BC000615_A40000WWPUserExtendedPhoto_GXI[0];
            A58WWPUserExtendedName = BC000615_A58WWPUserExtendedName[0];
            A50WWPUserExtendedFullName = BC000615_A50WWPUserExtendedFullName[0];
            A57WWPUserExtendedPhone = BC000615_A57WWPUserExtendedPhone[0];
            A51WWPUserExtendedEmail = BC000615_A51WWPUserExtendedEmail[0];
            A53WWPUserExtendedEmaiNotif = BC000615_A53WWPUserExtendedEmaiNotif[0];
            A54WWPUserExtendedSMSNotif = BC000615_A54WWPUserExtendedSMSNotif[0];
            A55WWPUserExtendedMobileNotif = BC000615_A55WWPUserExtendedMobileNotif[0];
            A56WWPUserExtendedDesktopNotif = BC000615_A56WWPUserExtendedDesktopNotif[0];
            A59WWPUserExtendedDeleted = BC000615_A59WWPUserExtendedDeleted[0];
            A60WWPUserExtendedDeletedIn = BC000615_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = BC000615_n60WWPUserExtendedDeletedIn[0];
            A52WWPUserExtendedPhoto = BC000615_A52WWPUserExtendedPhoto[0];
         }
         Gx_mode = sMode6;
      }

      protected void ScanKeyEnd066( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void AddRow066( )
      {
         VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
      }

      protected void ReadRow066( )
      {
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
      }

      protected void InitializeNonKey066( )
      {
         A52WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         A58WWPUserExtendedName = "";
         A50WWPUserExtendedFullName = "";
         A57WWPUserExtendedPhone = "";
         A51WWPUserExtendedEmail = "";
         A53WWPUserExtendedEmaiNotif = false;
         A54WWPUserExtendedSMSNotif = false;
         A55WWPUserExtendedMobileNotif = false;
         A56WWPUserExtendedDesktopNotif = false;
         A59WWPUserExtendedDeleted = false;
         A60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n60WWPUserExtendedDeletedIn = false;
         Z58WWPUserExtendedName = "";
         Z50WWPUserExtendedFullName = "";
         Z57WWPUserExtendedPhone = "";
         Z51WWPUserExtendedEmail = "";
         Z53WWPUserExtendedEmaiNotif = false;
         Z54WWPUserExtendedSMSNotif = false;
         Z55WWPUserExtendedMobileNotif = false;
         Z56WWPUserExtendedDesktopNotif = false;
         Z59WWPUserExtendedDeleted = false;
         Z60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll066( )
      {
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         InitializeNonKey066( ) ;
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

      public void VarsToRow6( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj6 )
      {
         obj6.gxTpr_Mode = Gx_mode;
         obj6.gxTpr_Wwpuserextendedphoto = A52WWPUserExtendedPhoto;
         obj6.gxTpr_Wwpuserextendedphoto_gxi = A40000WWPUserExtendedPhoto_GXI;
         obj6.gxTpr_Wwpuserextendedname = A58WWPUserExtendedName;
         obj6.gxTpr_Wwpuserextendedfullname = A50WWPUserExtendedFullName;
         obj6.gxTpr_Wwpuserextendedphone = A57WWPUserExtendedPhone;
         obj6.gxTpr_Wwpuserextendedemail = A51WWPUserExtendedEmail;
         obj6.gxTpr_Wwpuserextendedemainotif = A53WWPUserExtendedEmaiNotif;
         obj6.gxTpr_Wwpuserextendedsmsnotif = A54WWPUserExtendedSMSNotif;
         obj6.gxTpr_Wwpuserextendedmobilenotif = A55WWPUserExtendedMobileNotif;
         obj6.gxTpr_Wwpuserextendeddesktopnotif = A56WWPUserExtendedDesktopNotif;
         obj6.gxTpr_Wwpuserextendeddeleted = A59WWPUserExtendedDeleted;
         obj6.gxTpr_Wwpuserextendeddeletedin = A60WWPUserExtendedDeletedIn;
         obj6.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         obj6.gxTpr_Wwpuserextendedid_Z = Z49WWPUserExtendedId;
         obj6.gxTpr_Wwpuserextendedname_Z = Z58WWPUserExtendedName;
         obj6.gxTpr_Wwpuserextendedfullname_Z = Z50WWPUserExtendedFullName;
         obj6.gxTpr_Wwpuserextendedphone_Z = Z57WWPUserExtendedPhone;
         obj6.gxTpr_Wwpuserextendedemail_Z = Z51WWPUserExtendedEmail;
         obj6.gxTpr_Wwpuserextendedemainotif_Z = Z53WWPUserExtendedEmaiNotif;
         obj6.gxTpr_Wwpuserextendedsmsnotif_Z = Z54WWPUserExtendedSMSNotif;
         obj6.gxTpr_Wwpuserextendedmobilenotif_Z = Z55WWPUserExtendedMobileNotif;
         obj6.gxTpr_Wwpuserextendeddesktopnotif_Z = Z56WWPUserExtendedDesktopNotif;
         obj6.gxTpr_Wwpuserextendeddeleted_Z = Z59WWPUserExtendedDeleted;
         obj6.gxTpr_Wwpuserextendeddeletedin_Z = Z60WWPUserExtendedDeletedIn;
         obj6.gxTpr_Wwpuserextendedphoto_gxi_Z = Z40000WWPUserExtendedPhoto_GXI;
         obj6.gxTpr_Wwpuserextendedid_N = (short)(Convert.ToInt16(n49WWPUserExtendedId));
         obj6.gxTpr_Wwpuserextendeddeletedin_N = (short)(Convert.ToInt16(n60WWPUserExtendedDeletedIn));
         obj6.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow6( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj6 )
      {
         obj6.gxTpr_Wwpuserextendedid = A49WWPUserExtendedId;
         return  ;
      }

      public void RowToVars6( GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended obj6 ,
                              int forceLoad )
      {
         Gx_mode = obj6.gxTpr_Mode;
         A52WWPUserExtendedPhoto = obj6.gxTpr_Wwpuserextendedphoto;
         A40000WWPUserExtendedPhoto_GXI = obj6.gxTpr_Wwpuserextendedphoto_gxi;
         A58WWPUserExtendedName = obj6.gxTpr_Wwpuserextendedname;
         A50WWPUserExtendedFullName = obj6.gxTpr_Wwpuserextendedfullname;
         A57WWPUserExtendedPhone = obj6.gxTpr_Wwpuserextendedphone;
         A51WWPUserExtendedEmail = obj6.gxTpr_Wwpuserextendedemail;
         A53WWPUserExtendedEmaiNotif = obj6.gxTpr_Wwpuserextendedemainotif;
         A54WWPUserExtendedSMSNotif = obj6.gxTpr_Wwpuserextendedsmsnotif;
         A55WWPUserExtendedMobileNotif = obj6.gxTpr_Wwpuserextendedmobilenotif;
         A56WWPUserExtendedDesktopNotif = obj6.gxTpr_Wwpuserextendeddesktopnotif;
         A59WWPUserExtendedDeleted = obj6.gxTpr_Wwpuserextendeddeleted;
         A60WWPUserExtendedDeletedIn = obj6.gxTpr_Wwpuserextendeddeletedin;
         n60WWPUserExtendedDeletedIn = false;
         A49WWPUserExtendedId = obj6.gxTpr_Wwpuserextendedid;
         n49WWPUserExtendedId = false;
         Z49WWPUserExtendedId = obj6.gxTpr_Wwpuserextendedid_Z;
         Z58WWPUserExtendedName = obj6.gxTpr_Wwpuserextendedname_Z;
         Z50WWPUserExtendedFullName = obj6.gxTpr_Wwpuserextendedfullname_Z;
         Z57WWPUserExtendedPhone = obj6.gxTpr_Wwpuserextendedphone_Z;
         Z51WWPUserExtendedEmail = obj6.gxTpr_Wwpuserextendedemail_Z;
         Z53WWPUserExtendedEmaiNotif = obj6.gxTpr_Wwpuserextendedemainotif_Z;
         Z54WWPUserExtendedSMSNotif = obj6.gxTpr_Wwpuserextendedsmsnotif_Z;
         Z55WWPUserExtendedMobileNotif = obj6.gxTpr_Wwpuserextendedmobilenotif_Z;
         Z56WWPUserExtendedDesktopNotif = obj6.gxTpr_Wwpuserextendeddesktopnotif_Z;
         Z59WWPUserExtendedDeleted = obj6.gxTpr_Wwpuserextendeddeleted_Z;
         Z60WWPUserExtendedDeletedIn = obj6.gxTpr_Wwpuserextendeddeletedin_Z;
         Z40000WWPUserExtendedPhoto_GXI = obj6.gxTpr_Wwpuserextendedphoto_gxi_Z;
         n49WWPUserExtendedId = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpuserextendedid_N));
         n60WWPUserExtendedDeletedIn = (bool)(Convert.ToBoolean(obj6.gxTpr_Wwpuserextendeddeletedin_N));
         Gx_mode = obj6.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A49WWPUserExtendedId = (string)getParm(obj,0);
         n49WWPUserExtendedId = false;
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey066( ) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
         ZM066( -2) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         ScanKeyStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
         }
         ZM066( -2) ;
         OnLoadActions066( ) ;
         AddRow066( ) ;
         ScanKeyEnd066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert066( ) ;
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
               {
                  A49WWPUserExtendedId = Z49WWPUserExtendedId;
                  n49WWPUserExtendedId = false;
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
                  Update066( ) ;
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
                  if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
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
                        Insert066( ) ;
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
                        Insert066( ) ;
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         SaveImpl( ) ;
         VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
         AfterTrn( ) ;
         VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A49WWPUserExtendedId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_UserExtended);
               auxBC.Save();
               bcwwpbaseobjects_WWP_UserExtended.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert066( ) ;
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
               VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
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
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey066( ) ;
         if ( RcdFound6 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
            {
               A49WWPUserExtendedId = Z49WWPUserExtendedId;
               n49WWPUserExtendedId = false;
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
            if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_userextended_bc",pr_default);
         VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_UserExtended )
         {
            bcwwpbaseobjects_WWP_UserExtended = (GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow6( bcwwpbaseobjects_WWP_UserExtended) ;
            }
            else
            {
               RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_UserExtended.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars6( bcwwpbaseobjects_WWP_UserExtended, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_UserExtended WWP_UserExtended_BC
      {
         get {
            return bcwwpbaseobjects_WWP_UserExtended ;
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
            return "wwpuserextended_Execute" ;
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
         Z49WWPUserExtendedId = "";
         A49WWPUserExtendedId = "";
         Z58WWPUserExtendedName = "";
         A58WWPUserExtendedName = "";
         Z50WWPUserExtendedFullName = "";
         A50WWPUserExtendedFullName = "";
         Z57WWPUserExtendedPhone = "";
         A57WWPUserExtendedPhone = "";
         Z51WWPUserExtendedEmail = "";
         A51WWPUserExtendedEmail = "";
         Z60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         A60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         Z52WWPUserExtendedPhoto = "";
         A52WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         BC00064_A49WWPUserExtendedId = new string[] {""} ;
         BC00064_n49WWPUserExtendedId = new bool[] {false} ;
         BC00064_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00064_A58WWPUserExtendedName = new string[] {""} ;
         BC00064_A50WWPUserExtendedFullName = new string[] {""} ;
         BC00064_A57WWPUserExtendedPhone = new string[] {""} ;
         BC00064_A51WWPUserExtendedEmail = new string[] {""} ;
         BC00064_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00064_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00064_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00064_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00064_A59WWPUserExtendedDeleted = new bool[] {false} ;
         BC00064_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00064_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00064_A52WWPUserExtendedPhoto = new string[] {""} ;
         BC00065_A49WWPUserExtendedId = new string[] {""} ;
         BC00065_n49WWPUserExtendedId = new bool[] {false} ;
         BC00063_A49WWPUserExtendedId = new string[] {""} ;
         BC00063_n49WWPUserExtendedId = new bool[] {false} ;
         BC00063_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00063_A58WWPUserExtendedName = new string[] {""} ;
         BC00063_A50WWPUserExtendedFullName = new string[] {""} ;
         BC00063_A57WWPUserExtendedPhone = new string[] {""} ;
         BC00063_A51WWPUserExtendedEmail = new string[] {""} ;
         BC00063_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00063_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00063_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00063_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00063_A59WWPUserExtendedDeleted = new bool[] {false} ;
         BC00063_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00063_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00063_A52WWPUserExtendedPhoto = new string[] {""} ;
         sMode6 = "";
         BC00062_A49WWPUserExtendedId = new string[] {""} ;
         BC00062_n49WWPUserExtendedId = new bool[] {false} ;
         BC00062_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC00062_A58WWPUserExtendedName = new string[] {""} ;
         BC00062_A50WWPUserExtendedFullName = new string[] {""} ;
         BC00062_A57WWPUserExtendedPhone = new string[] {""} ;
         BC00062_A51WWPUserExtendedEmail = new string[] {""} ;
         BC00062_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC00062_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC00062_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC00062_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC00062_A59WWPUserExtendedDeleted = new bool[] {false} ;
         BC00062_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC00062_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC00062_A52WWPUserExtendedPhoto = new string[] {""} ;
         BC000610_A137WWPDiscussionMessageId = new long[1] ;
         BC000610_A138WWPDiscussionMentionUserId = new string[] {""} ;
         BC000611_A137WWPDiscussionMessageId = new long[1] ;
         BC000612_A64WWPNotificationId = new long[1] ;
         BC000613_A90WWPWebClientId = new string[] {""} ;
         BC000614_A67WWPSubscriptionId = new long[1] ;
         BC000615_A49WWPUserExtendedId = new string[] {""} ;
         BC000615_n49WWPUserExtendedId = new bool[] {false} ;
         BC000615_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         BC000615_A58WWPUserExtendedName = new string[] {""} ;
         BC000615_A50WWPUserExtendedFullName = new string[] {""} ;
         BC000615_A57WWPUserExtendedPhone = new string[] {""} ;
         BC000615_A51WWPUserExtendedEmail = new string[] {""} ;
         BC000615_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         BC000615_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         BC000615_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         BC000615_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         BC000615_A59WWPUserExtendedDeleted = new bool[] {false} ;
         BC000615_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         BC000615_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         BC000615_A52WWPUserExtendedPhoto = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended_bc__default(),
            new Object[][] {
                new Object[] {
               BC00062_A49WWPUserExtendedId, BC00062_A40000WWPUserExtendedPhoto_GXI, BC00062_A58WWPUserExtendedName, BC00062_A50WWPUserExtendedFullName, BC00062_A57WWPUserExtendedPhone, BC00062_A51WWPUserExtendedEmail, BC00062_A53WWPUserExtendedEmaiNotif, BC00062_A54WWPUserExtendedSMSNotif, BC00062_A55WWPUserExtendedMobileNotif, BC00062_A56WWPUserExtendedDesktopNotif,
               BC00062_A59WWPUserExtendedDeleted, BC00062_A60WWPUserExtendedDeletedIn, BC00062_n60WWPUserExtendedDeletedIn, BC00062_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00063_A49WWPUserExtendedId, BC00063_A40000WWPUserExtendedPhoto_GXI, BC00063_A58WWPUserExtendedName, BC00063_A50WWPUserExtendedFullName, BC00063_A57WWPUserExtendedPhone, BC00063_A51WWPUserExtendedEmail, BC00063_A53WWPUserExtendedEmaiNotif, BC00063_A54WWPUserExtendedSMSNotif, BC00063_A55WWPUserExtendedMobileNotif, BC00063_A56WWPUserExtendedDesktopNotif,
               BC00063_A59WWPUserExtendedDeleted, BC00063_A60WWPUserExtendedDeletedIn, BC00063_n60WWPUserExtendedDeletedIn, BC00063_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00064_A49WWPUserExtendedId, BC00064_A40000WWPUserExtendedPhoto_GXI, BC00064_A58WWPUserExtendedName, BC00064_A50WWPUserExtendedFullName, BC00064_A57WWPUserExtendedPhone, BC00064_A51WWPUserExtendedEmail, BC00064_A53WWPUserExtendedEmaiNotif, BC00064_A54WWPUserExtendedSMSNotif, BC00064_A55WWPUserExtendedMobileNotif, BC00064_A56WWPUserExtendedDesktopNotif,
               BC00064_A59WWPUserExtendedDeleted, BC00064_A60WWPUserExtendedDeletedIn, BC00064_n60WWPUserExtendedDeletedIn, BC00064_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               BC00065_A49WWPUserExtendedId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000610_A137WWPDiscussionMessageId, BC000610_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               BC000611_A137WWPDiscussionMessageId
               }
               , new Object[] {
               BC000612_A64WWPNotificationId
               }
               , new Object[] {
               BC000613_A90WWPWebClientId
               }
               , new Object[] {
               BC000614_A67WWPSubscriptionId
               }
               , new Object[] {
               BC000615_A49WWPUserExtendedId, BC000615_A40000WWPUserExtendedPhoto_GXI, BC000615_A58WWPUserExtendedName, BC000615_A50WWPUserExtendedFullName, BC000615_A57WWPUserExtendedPhone, BC000615_A51WWPUserExtendedEmail, BC000615_A53WWPUserExtendedEmaiNotif, BC000615_A54WWPUserExtendedSMSNotif, BC000615_A55WWPUserExtendedMobileNotif, BC000615_A56WWPUserExtendedDesktopNotif,
               BC000615_A59WWPUserExtendedDeleted, BC000615_A60WWPUserExtendedDeletedIn, BC000615_n60WWPUserExtendedDeletedIn, BC000615_A52WWPUserExtendedPhoto
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
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z49WWPUserExtendedId ;
      private string A49WWPUserExtendedId ;
      private string Z57WWPUserExtendedPhone ;
      private string A57WWPUserExtendedPhone ;
      private string sMode6 ;
      private DateTime Z60WWPUserExtendedDeletedIn ;
      private DateTime A60WWPUserExtendedDeletedIn ;
      private bool Z53WWPUserExtendedEmaiNotif ;
      private bool A53WWPUserExtendedEmaiNotif ;
      private bool Z54WWPUserExtendedSMSNotif ;
      private bool A54WWPUserExtendedSMSNotif ;
      private bool Z55WWPUserExtendedMobileNotif ;
      private bool A55WWPUserExtendedMobileNotif ;
      private bool Z56WWPUserExtendedDesktopNotif ;
      private bool A56WWPUserExtendedDesktopNotif ;
      private bool Z59WWPUserExtendedDeleted ;
      private bool A59WWPUserExtendedDeleted ;
      private bool n49WWPUserExtendedId ;
      private bool n60WWPUserExtendedDeletedIn ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z58WWPUserExtendedName ;
      private string A58WWPUserExtendedName ;
      private string Z50WWPUserExtendedFullName ;
      private string A50WWPUserExtendedFullName ;
      private string Z51WWPUserExtendedEmail ;
      private string A51WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string Z52WWPUserExtendedPhoto ;
      private string A52WWPUserExtendedPhoto ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_UserExtended bcwwpbaseobjects_WWP_UserExtended ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00064_A49WWPUserExtendedId ;
      private bool[] BC00064_n49WWPUserExtendedId ;
      private string[] BC00064_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00064_A58WWPUserExtendedName ;
      private string[] BC00064_A50WWPUserExtendedFullName ;
      private string[] BC00064_A57WWPUserExtendedPhone ;
      private string[] BC00064_A51WWPUserExtendedEmail ;
      private bool[] BC00064_A53WWPUserExtendedEmaiNotif ;
      private bool[] BC00064_A54WWPUserExtendedSMSNotif ;
      private bool[] BC00064_A55WWPUserExtendedMobileNotif ;
      private bool[] BC00064_A56WWPUserExtendedDesktopNotif ;
      private bool[] BC00064_A59WWPUserExtendedDeleted ;
      private DateTime[] BC00064_A60WWPUserExtendedDeletedIn ;
      private bool[] BC00064_n60WWPUserExtendedDeletedIn ;
      private string[] BC00064_A52WWPUserExtendedPhoto ;
      private string[] BC00065_A49WWPUserExtendedId ;
      private bool[] BC00065_n49WWPUserExtendedId ;
      private string[] BC00063_A49WWPUserExtendedId ;
      private bool[] BC00063_n49WWPUserExtendedId ;
      private string[] BC00063_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00063_A58WWPUserExtendedName ;
      private string[] BC00063_A50WWPUserExtendedFullName ;
      private string[] BC00063_A57WWPUserExtendedPhone ;
      private string[] BC00063_A51WWPUserExtendedEmail ;
      private bool[] BC00063_A53WWPUserExtendedEmaiNotif ;
      private bool[] BC00063_A54WWPUserExtendedSMSNotif ;
      private bool[] BC00063_A55WWPUserExtendedMobileNotif ;
      private bool[] BC00063_A56WWPUserExtendedDesktopNotif ;
      private bool[] BC00063_A59WWPUserExtendedDeleted ;
      private DateTime[] BC00063_A60WWPUserExtendedDeletedIn ;
      private bool[] BC00063_n60WWPUserExtendedDeletedIn ;
      private string[] BC00063_A52WWPUserExtendedPhoto ;
      private string[] BC00062_A49WWPUserExtendedId ;
      private bool[] BC00062_n49WWPUserExtendedId ;
      private string[] BC00062_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC00062_A58WWPUserExtendedName ;
      private string[] BC00062_A50WWPUserExtendedFullName ;
      private string[] BC00062_A57WWPUserExtendedPhone ;
      private string[] BC00062_A51WWPUserExtendedEmail ;
      private bool[] BC00062_A53WWPUserExtendedEmaiNotif ;
      private bool[] BC00062_A54WWPUserExtendedSMSNotif ;
      private bool[] BC00062_A55WWPUserExtendedMobileNotif ;
      private bool[] BC00062_A56WWPUserExtendedDesktopNotif ;
      private bool[] BC00062_A59WWPUserExtendedDeleted ;
      private DateTime[] BC00062_A60WWPUserExtendedDeletedIn ;
      private bool[] BC00062_n60WWPUserExtendedDeletedIn ;
      private string[] BC00062_A52WWPUserExtendedPhoto ;
      private long[] BC000610_A137WWPDiscussionMessageId ;
      private string[] BC000610_A138WWPDiscussionMentionUserId ;
      private long[] BC000611_A137WWPDiscussionMessageId ;
      private long[] BC000612_A64WWPNotificationId ;
      private string[] BC000613_A90WWPWebClientId ;
      private long[] BC000614_A67WWPSubscriptionId ;
      private string[] BC000615_A49WWPUserExtendedId ;
      private bool[] BC000615_n49WWPUserExtendedId ;
      private string[] BC000615_A40000WWPUserExtendedPhoto_GXI ;
      private string[] BC000615_A58WWPUserExtendedName ;
      private string[] BC000615_A50WWPUserExtendedFullName ;
      private string[] BC000615_A57WWPUserExtendedPhone ;
      private string[] BC000615_A51WWPUserExtendedEmail ;
      private bool[] BC000615_A53WWPUserExtendedEmaiNotif ;
      private bool[] BC000615_A54WWPUserExtendedSMSNotif ;
      private bool[] BC000615_A55WWPUserExtendedMobileNotif ;
      private bool[] BC000615_A56WWPUserExtendedDesktopNotif ;
      private bool[] BC000615_A59WWPUserExtendedDeleted ;
      private DateTime[] BC000615_A60WWPUserExtendedDeletedIn ;
      private bool[] BC000615_n60WWPUserExtendedDeletedIn ;
      private string[] BC000615_A52WWPUserExtendedPhoto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_userextended_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00064;
        prmBC00064 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00065;
        prmBC00065 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00063;
        prmBC00063 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00062;
        prmBC00062 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00066;
        prmBC00066 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
        };
        Object[] prmBC00067;
        prmBC00067 = new Object[] {
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00068;
        prmBC00068 = new Object[] {
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC00069;
        prmBC00069 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000610;
        prmBC000610 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000611;
        prmBC000611 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000612;
        prmBC000612 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000613;
        prmBC000613 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000614;
        prmBC000614 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmBC000615;
        prmBC000615 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("BC00062", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended",true, GxErrorMask.GX_NOMASK, false, this,prmBC00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00063", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00064", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00064,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00065", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00065,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00066", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00066)
           ,new CursorDef("BC00067", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00067)
           ,new CursorDef("BC00068", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00068)
           ,new CursorDef("BC00069", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00069)
           ,new CursorDef("BC000610", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMentionUserId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000610,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000611", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000611,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000612", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000613", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000614", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000614,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000615", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000615,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
     }
  }

}

}
