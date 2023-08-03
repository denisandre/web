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
   public class wwp_mailtemplate_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_mailtemplate_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate_bc( IGxContext context )
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
         ReadRow0E14( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0E14( ) ;
         standaloneModal( ) ;
         AddRow0E14( ) ;
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
            /* Execute user event: After Trn */
            E110E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z130WWPMailTemplateName = A130WWPMailTemplateName;
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

      protected void CONFIRM_0E0( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0E14( ) ;
            }
            else
            {
               CheckExtendedTable0E14( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0E14( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120E2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E110E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E14( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z131WWPMailTemplateDescription = A131WWPMailTemplateDescription;
            Z132WWPMailTemplateSubject = A132WWPMailTemplateSubject;
         }
         if ( GX_JID == -1 )
         {
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
            Z131WWPMailTemplateDescription = A131WWPMailTemplateDescription;
            Z132WWPMailTemplateSubject = A132WWPMailTemplateSubject;
            Z115WWPMailTemplateBody = A115WWPMailTemplateBody;
            Z116WWPMailTemplateSenderAddress = A116WWPMailTemplateSenderAddress;
            Z117WWPMailTemplateSenderName = A117WWPMailTemplateSenderName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0E14( )
      {
         /* Using cursor BC000E4 */
         pr_default.execute(2, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound14 = 1;
            A131WWPMailTemplateDescription = BC000E4_A131WWPMailTemplateDescription[0];
            A132WWPMailTemplateSubject = BC000E4_A132WWPMailTemplateSubject[0];
            A115WWPMailTemplateBody = BC000E4_A115WWPMailTemplateBody[0];
            A116WWPMailTemplateSenderAddress = BC000E4_A116WWPMailTemplateSenderAddress[0];
            A117WWPMailTemplateSenderName = BC000E4_A117WWPMailTemplateSenderName[0];
            ZM0E14( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0E14( ) ;
      }

      protected void OnLoadActions0E14( )
      {
      }

      protected void CheckExtendedTable0E14( )
      {
         nIsDirty_14 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0E14( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E14( )
      {
         /* Using cursor BC000E5 */
         pr_default.execute(3, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000E3 */
         pr_default.execute(1, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E14( 1) ;
            RcdFound14 = 1;
            A130WWPMailTemplateName = BC000E3_A130WWPMailTemplateName[0];
            A131WWPMailTemplateDescription = BC000E3_A131WWPMailTemplateDescription[0];
            A132WWPMailTemplateSubject = BC000E3_A132WWPMailTemplateSubject[0];
            A115WWPMailTemplateBody = BC000E3_A115WWPMailTemplateBody[0];
            A116WWPMailTemplateSenderAddress = BC000E3_A116WWPMailTemplateSenderAddress[0];
            A117WWPMailTemplateSenderName = BC000E3_A117WWPMailTemplateSenderName[0];
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0E14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0E14( ) ;
            }
            Gx_mode = sMode14;
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0E14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode14;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E14( ) ;
         if ( RcdFound14 == 0 )
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
         CONFIRM_0E0( ) ;
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

      protected void CheckOptimisticConcurrency0E14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000E2 */
            pr_default.execute(0, new Object[] {A130WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131WWPMailTemplateDescription, BC000E2_A131WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z132WWPMailTemplateSubject, BC000E2_A132WWPMailTemplateSubject[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E14( 0) ;
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E6 */
                     pr_default.execute(4, new Object[] {A130WWPMailTemplateName, A131WWPMailTemplateDescription, A132WWPMailTemplateSubject, A115WWPMailTemplateBody, A116WWPMailTemplateSenderAddress, A117WWPMailTemplateSenderName});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
               Load0E14( ) ;
            }
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void Update0E14( )
      {
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000E7 */
                     pr_default.execute(5, new Object[] {A131WWPMailTemplateDescription, A132WWPMailTemplateSubject, A115WWPMailTemplateBody, A116WWPMailTemplateSenderAddress, A117WWPMailTemplateSenderName, A130WWPMailTemplateName});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E14( ) ;
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
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void DeferredUpdate0E14( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E14( ) ;
            AfterConfirm0E14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000E8 */
                  pr_default.execute(6, new Object[] {A130WWPMailTemplateName});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0E14( ) ;
         Gx_mode = sMode14;
      }

      protected void OnDeleteControls0E14( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0E14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E14( ) ;
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

      public void ScanKeyStart0E14( )
      {
         /* Using cursor BC000E9 */
         pr_default.execute(7, new Object[] {A130WWPMailTemplateName});
         RcdFound14 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound14 = 1;
            A130WWPMailTemplateName = BC000E9_A130WWPMailTemplateName[0];
            A131WWPMailTemplateDescription = BC000E9_A131WWPMailTemplateDescription[0];
            A132WWPMailTemplateSubject = BC000E9_A132WWPMailTemplateSubject[0];
            A115WWPMailTemplateBody = BC000E9_A115WWPMailTemplateBody[0];
            A116WWPMailTemplateSenderAddress = BC000E9_A116WWPMailTemplateSenderAddress[0];
            A117WWPMailTemplateSenderName = BC000E9_A117WWPMailTemplateSenderName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0E14( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound14 = 0;
         ScanKeyLoad0E14( ) ;
      }

      protected void ScanKeyLoad0E14( )
      {
         sMode14 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound14 = 1;
            A130WWPMailTemplateName = BC000E9_A130WWPMailTemplateName[0];
            A131WWPMailTemplateDescription = BC000E9_A131WWPMailTemplateDescription[0];
            A132WWPMailTemplateSubject = BC000E9_A132WWPMailTemplateSubject[0];
            A115WWPMailTemplateBody = BC000E9_A115WWPMailTemplateBody[0];
            A116WWPMailTemplateSenderAddress = BC000E9_A116WWPMailTemplateSenderAddress[0];
            A117WWPMailTemplateSenderName = BC000E9_A117WWPMailTemplateSenderName[0];
         }
         Gx_mode = sMode14;
      }

      protected void ScanKeyEnd0E14( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0E14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E14( )
      {
      }

      protected void send_integrity_lvl_hashes0E14( )
      {
      }

      protected void AddRow0E14( )
      {
         VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
      }

      protected void ReadRow0E14( )
      {
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
      }

      protected void InitializeNonKey0E14( )
      {
         A131WWPMailTemplateDescription = "";
         A132WWPMailTemplateSubject = "";
         A115WWPMailTemplateBody = "";
         A116WWPMailTemplateSenderAddress = "";
         A117WWPMailTemplateSenderName = "";
         Z131WWPMailTemplateDescription = "";
         Z132WWPMailTemplateSubject = "";
      }

      protected void InitAll0E14( )
      {
         A130WWPMailTemplateName = "";
         InitializeNonKey0E14( ) ;
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

      public void VarsToRow14( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj14 )
      {
         obj14.gxTpr_Mode = Gx_mode;
         obj14.gxTpr_Wwpmailtemplatedescription = A131WWPMailTemplateDescription;
         obj14.gxTpr_Wwpmailtemplatesubject = A132WWPMailTemplateSubject;
         obj14.gxTpr_Wwpmailtemplatebody = A115WWPMailTemplateBody;
         obj14.gxTpr_Wwpmailtemplatesenderaddress = A116WWPMailTemplateSenderAddress;
         obj14.gxTpr_Wwpmailtemplatesendername = A117WWPMailTemplateSenderName;
         obj14.gxTpr_Wwpmailtemplatename = A130WWPMailTemplateName;
         obj14.gxTpr_Wwpmailtemplatename_Z = Z130WWPMailTemplateName;
         obj14.gxTpr_Wwpmailtemplatedescription_Z = Z131WWPMailTemplateDescription;
         obj14.gxTpr_Wwpmailtemplatesubject_Z = Z132WWPMailTemplateSubject;
         obj14.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow14( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj14 )
      {
         obj14.gxTpr_Wwpmailtemplatename = A130WWPMailTemplateName;
         return  ;
      }

      public void RowToVars14( GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate obj14 ,
                               int forceLoad )
      {
         Gx_mode = obj14.gxTpr_Mode;
         A131WWPMailTemplateDescription = obj14.gxTpr_Wwpmailtemplatedescription;
         A132WWPMailTemplateSubject = obj14.gxTpr_Wwpmailtemplatesubject;
         A115WWPMailTemplateBody = obj14.gxTpr_Wwpmailtemplatebody;
         A116WWPMailTemplateSenderAddress = obj14.gxTpr_Wwpmailtemplatesenderaddress;
         A117WWPMailTemplateSenderName = obj14.gxTpr_Wwpmailtemplatesendername;
         A130WWPMailTemplateName = obj14.gxTpr_Wwpmailtemplatename;
         Z130WWPMailTemplateName = obj14.gxTpr_Wwpmailtemplatename_Z;
         Z131WWPMailTemplateDescription = obj14.gxTpr_Wwpmailtemplatedescription_Z;
         Z132WWPMailTemplateSubject = obj14.gxTpr_Wwpmailtemplatesubject_Z;
         Gx_mode = obj14.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A130WWPMailTemplateName = (string)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0E14( ) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
         }
         ZM0E14( -1) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         ScanKeyStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
         }
         ZM0E14( -1) ;
         OnLoadActions0E14( ) ;
         AddRow0E14( ) ;
         ScanKeyEnd0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0E14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0E14( ) ;
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
               {
                  A130WWPMailTemplateName = Z130WWPMailTemplateName;
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
                  Update0E14( ) ;
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
                  if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
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
                        Insert0E14( ) ;
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
                        Insert0E14( ) ;
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         SaveImpl( ) ;
         VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
         AfterTrn( ) ;
         VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate auxBC = new GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A130WWPMailTemplateName);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_mail_WWP_MailTemplate);
               auxBC.Save();
               bcwwpbaseobjects_mail_WWP_MailTemplate.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0E14( ) ;
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
               VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0E14( ) ;
         if ( RcdFound14 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
            {
               A130WWPMailTemplateName = Z130WWPMailTemplateName;
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
            if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
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
         context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate_bc",pr_default);
         VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
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
         Gx_mode = bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_mail_WWP_MailTemplate )
         {
            bcwwpbaseobjects_mail_WWP_MailTemplate = (GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow14( bcwwpbaseobjects_mail_WWP_MailTemplate) ;
            }
            else
            {
               RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_mail_WWP_MailTemplate.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars14( bcwwpbaseobjects_mail_WWP_MailTemplate, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_MailTemplate WWP_MailTemplate_BC
      {
         get {
            return bcwwpbaseobjects_mail_WWP_MailTemplate ;
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
            return "wwpmailtemplate_Execute" ;
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
         Z130WWPMailTemplateName = "";
         A130WWPMailTemplateName = "";
         Z131WWPMailTemplateDescription = "";
         A131WWPMailTemplateDescription = "";
         Z132WWPMailTemplateSubject = "";
         A132WWPMailTemplateSubject = "";
         Z115WWPMailTemplateBody = "";
         A115WWPMailTemplateBody = "";
         Z116WWPMailTemplateSenderAddress = "";
         A116WWPMailTemplateSenderAddress = "";
         Z117WWPMailTemplateSenderName = "";
         A117WWPMailTemplateSenderName = "";
         BC000E4_A130WWPMailTemplateName = new string[] {""} ;
         BC000E4_A131WWPMailTemplateDescription = new string[] {""} ;
         BC000E4_A132WWPMailTemplateSubject = new string[] {""} ;
         BC000E4_A115WWPMailTemplateBody = new string[] {""} ;
         BC000E4_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000E4_A117WWPMailTemplateSenderName = new string[] {""} ;
         BC000E5_A130WWPMailTemplateName = new string[] {""} ;
         BC000E3_A130WWPMailTemplateName = new string[] {""} ;
         BC000E3_A131WWPMailTemplateDescription = new string[] {""} ;
         BC000E3_A132WWPMailTemplateSubject = new string[] {""} ;
         BC000E3_A115WWPMailTemplateBody = new string[] {""} ;
         BC000E3_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000E3_A117WWPMailTemplateSenderName = new string[] {""} ;
         sMode14 = "";
         BC000E2_A130WWPMailTemplateName = new string[] {""} ;
         BC000E2_A131WWPMailTemplateDescription = new string[] {""} ;
         BC000E2_A132WWPMailTemplateSubject = new string[] {""} ;
         BC000E2_A115WWPMailTemplateBody = new string[] {""} ;
         BC000E2_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000E2_A117WWPMailTemplateSenderName = new string[] {""} ;
         BC000E9_A130WWPMailTemplateName = new string[] {""} ;
         BC000E9_A131WWPMailTemplateDescription = new string[] {""} ;
         BC000E9_A132WWPMailTemplateSubject = new string[] {""} ;
         BC000E9_A115WWPMailTemplateBody = new string[] {""} ;
         BC000E9_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         BC000E9_A117WWPMailTemplateSenderName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate_bc__default(),
            new Object[][] {
                new Object[] {
               BC000E2_A130WWPMailTemplateName, BC000E2_A131WWPMailTemplateDescription, BC000E2_A132WWPMailTemplateSubject, BC000E2_A115WWPMailTemplateBody, BC000E2_A116WWPMailTemplateSenderAddress, BC000E2_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000E3_A130WWPMailTemplateName, BC000E3_A131WWPMailTemplateDescription, BC000E3_A132WWPMailTemplateSubject, BC000E3_A115WWPMailTemplateBody, BC000E3_A116WWPMailTemplateSenderAddress, BC000E3_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000E4_A130WWPMailTemplateName, BC000E4_A131WWPMailTemplateDescription, BC000E4_A132WWPMailTemplateSubject, BC000E4_A115WWPMailTemplateBody, BC000E4_A116WWPMailTemplateSenderAddress, BC000E4_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               BC000E5_A130WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000E9_A130WWPMailTemplateName, BC000E9_A131WWPMailTemplateDescription, BC000E9_A132WWPMailTemplateSubject, BC000E9_A115WWPMailTemplateBody, BC000E9_A116WWPMailTemplateSenderAddress, BC000E9_A117WWPMailTemplateSenderName
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120E2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound14 ;
      private short nIsDirty_14 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode14 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z115WWPMailTemplateBody ;
      private string A115WWPMailTemplateBody ;
      private string Z116WWPMailTemplateSenderAddress ;
      private string A116WWPMailTemplateSenderAddress ;
      private string Z117WWPMailTemplateSenderName ;
      private string A117WWPMailTemplateSenderName ;
      private string Z130WWPMailTemplateName ;
      private string A130WWPMailTemplateName ;
      private string Z131WWPMailTemplateDescription ;
      private string A131WWPMailTemplateDescription ;
      private string Z132WWPMailTemplateSubject ;
      private string A132WWPMailTemplateSubject ;
      private GeneXus.Programs.wwpbaseobjects.mail.SdtWWP_MailTemplate bcwwpbaseobjects_mail_WWP_MailTemplate ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000E4_A130WWPMailTemplateName ;
      private string[] BC000E4_A131WWPMailTemplateDescription ;
      private string[] BC000E4_A132WWPMailTemplateSubject ;
      private string[] BC000E4_A115WWPMailTemplateBody ;
      private string[] BC000E4_A116WWPMailTemplateSenderAddress ;
      private string[] BC000E4_A117WWPMailTemplateSenderName ;
      private string[] BC000E5_A130WWPMailTemplateName ;
      private string[] BC000E3_A130WWPMailTemplateName ;
      private string[] BC000E3_A131WWPMailTemplateDescription ;
      private string[] BC000E3_A132WWPMailTemplateSubject ;
      private string[] BC000E3_A115WWPMailTemplateBody ;
      private string[] BC000E3_A116WWPMailTemplateSenderAddress ;
      private string[] BC000E3_A117WWPMailTemplateSenderName ;
      private string[] BC000E2_A130WWPMailTemplateName ;
      private string[] BC000E2_A131WWPMailTemplateDescription ;
      private string[] BC000E2_A132WWPMailTemplateSubject ;
      private string[] BC000E2_A115WWPMailTemplateBody ;
      private string[] BC000E2_A116WWPMailTemplateSenderAddress ;
      private string[] BC000E2_A117WWPMailTemplateSenderName ;
      private string[] BC000E9_A130WWPMailTemplateName ;
      private string[] BC000E9_A131WWPMailTemplateDescription ;
      private string[] BC000E9_A132WWPMailTemplateSubject ;
      private string[] BC000E9_A115WWPMailTemplateBody ;
      private string[] BC000E9_A116WWPMailTemplateSenderAddress ;
      private string[] BC000E9_A117WWPMailTemplateSenderName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_mailtemplate_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000E4;
        prmBC000E4 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E5;
        prmBC000E5 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E3;
        prmBC000E3 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E2;
        prmBC000E2 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E6;
        prmBC000E6 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000E7;
        prmBC000E7 = new Object[] {
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E8;
        prmBC000E8 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmBC000E9;
        prmBC000E9 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000E2", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName  FOR UPDATE OF WWP_MailTemplate",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E3", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E4", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E5", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000E6", "SAVEPOINT gxupdate;INSERT INTO WWP_MailTemplate(WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName) VALUES(:WWPMailTemplateName, :WWPMailTemplateDescription, :WWPMailTemplateSubject, :WWPMailTemplateBody, :WWPMailTemplateSenderAddress, :WWPMailTemplateSenderName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000E6)
           ,new CursorDef("BC000E7", "SAVEPOINT gxupdate;UPDATE WWP_MailTemplate SET WWPMailTemplateDescription=:WWPMailTemplateDescription, WWPMailTemplateSubject=:WWPMailTemplateSubject, WWPMailTemplateBody=:WWPMailTemplateBody, WWPMailTemplateSenderAddress=:WWPMailTemplateSenderAddress, WWPMailTemplateSenderName=:WWPMailTemplateSenderName  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E7)
           ,new CursorDef("BC000E8", "SAVEPOINT gxupdate;DELETE FROM WWP_MailTemplate  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000E8)
           ,new CursorDef("BC000E9", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000E9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
     }
  }

}

}
