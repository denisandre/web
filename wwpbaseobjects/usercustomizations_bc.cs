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
   public class usercustomizations_bc : GxSilentTrn, IGxSilentTrn
   {
      public usercustomizations_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public usercustomizations_bc( IGxContext context )
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
         ReadRow0I19( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0I19( ) ;
         standaloneModal( ) ;
         AddRow0I19( ) ;
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
               Z143UserCustomizationsId = A143UserCustomizationsId;
               Z144UserCustomizationsKey = A144UserCustomizationsKey;
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

      protected void CONFIRM_0I0( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0I19( ) ;
            }
            else
            {
               CheckExtendedTable0I19( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0I19( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM0I19( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -1 )
         {
            Z143UserCustomizationsId = A143UserCustomizationsId;
            Z144UserCustomizationsKey = A144UserCustomizationsKey;
            Z145UserCustomizationsValue = A145UserCustomizationsValue;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load0I19( )
      {
         /* Using cursor BC000I4 */
         pr_default.execute(2, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound19 = 1;
            A145UserCustomizationsValue = BC000I4_A145UserCustomizationsValue[0];
            ZM0I19( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0I19( ) ;
      }

      protected void OnLoadActions0I19( )
      {
      }

      protected void CheckExtendedTable0I19( )
      {
         nIsDirty_19 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0I19( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0I19( )
      {
         /* Using cursor BC000I5 */
         pr_default.execute(3, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound19 = 1;
         }
         else
         {
            RcdFound19 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000I3 */
         pr_default.execute(1, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0I19( 1) ;
            RcdFound19 = 1;
            A143UserCustomizationsId = BC000I3_A143UserCustomizationsId[0];
            A144UserCustomizationsKey = BC000I3_A144UserCustomizationsKey[0];
            A145UserCustomizationsValue = BC000I3_A145UserCustomizationsValue[0];
            Z143UserCustomizationsId = A143UserCustomizationsId;
            Z144UserCustomizationsKey = A144UserCustomizationsKey;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0I19( ) ;
            if ( AnyError == 1 )
            {
               RcdFound19 = 0;
               InitializeNonKey0I19( ) ;
            }
            Gx_mode = sMode19;
         }
         else
         {
            RcdFound19 = 0;
            InitializeNonKey0I19( ) ;
            sMode19 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode19;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0I19( ) ;
         if ( RcdFound19 == 0 )
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
         CONFIRM_0I0( ) ;
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

      protected void CheckOptimisticConcurrency0I19( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000I2 */
            pr_default.execute(0, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"UserCustomizations"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0I19( 0) ;
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I6 */
                     pr_default.execute(4, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey, A145UserCustomizationsValue});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
               Load0I19( ) ;
            }
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void Update0I19( )
      {
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0I19( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0I19( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000I7 */
                     pr_default.execute(5, new Object[] {A145UserCustomizationsValue, A143UserCustomizationsId, A144UserCustomizationsKey});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"UserCustomizations"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0I19( ) ;
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
            EndLevel0I19( ) ;
         }
         CloseExtendedTableCursors0I19( ) ;
      }

      protected void DeferredUpdate0I19( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0I19( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0I19( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0I19( ) ;
            AfterConfirm0I19( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0I19( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000I8 */
                  pr_default.execute(6, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("UserCustomizations");
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
         sMode19 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0I19( ) ;
         Gx_mode = sMode19;
      }

      protected void OnDeleteControls0I19( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0I19( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0I19( ) ;
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

      public void ScanKeyStart0I19( )
      {
         /* Using cursor BC000I9 */
         pr_default.execute(7, new Object[] {A143UserCustomizationsId, A144UserCustomizationsKey});
         RcdFound19 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A143UserCustomizationsId = BC000I9_A143UserCustomizationsId[0];
            A144UserCustomizationsKey = BC000I9_A144UserCustomizationsKey[0];
            A145UserCustomizationsValue = BC000I9_A145UserCustomizationsValue[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0I19( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound19 = 0;
         ScanKeyLoad0I19( ) ;
      }

      protected void ScanKeyLoad0I19( )
      {
         sMode19 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound19 = 1;
            A143UserCustomizationsId = BC000I9_A143UserCustomizationsId[0];
            A144UserCustomizationsKey = BC000I9_A144UserCustomizationsKey[0];
            A145UserCustomizationsValue = BC000I9_A145UserCustomizationsValue[0];
         }
         Gx_mode = sMode19;
      }

      protected void ScanKeyEnd0I19( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm0I19( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0I19( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0I19( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0I19( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0I19( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0I19( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0I19( )
      {
      }

      protected void send_integrity_lvl_hashes0I19( )
      {
      }

      protected void AddRow0I19( )
      {
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
      }

      protected void ReadRow0I19( )
      {
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
      }

      protected void InitializeNonKey0I19( )
      {
         A145UserCustomizationsValue = "";
      }

      protected void InitAll0I19( )
      {
         A143UserCustomizationsId = "";
         A144UserCustomizationsKey = "";
         InitializeNonKey0I19( ) ;
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

      public void VarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 )
      {
         obj19.gxTpr_Mode = Gx_mode;
         obj19.gxTpr_Usercustomizationsvalue = A145UserCustomizationsValue;
         obj19.gxTpr_Usercustomizationsid = A143UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey = A144UserCustomizationsKey;
         obj19.gxTpr_Usercustomizationsid_Z = Z143UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey_Z = Z144UserCustomizationsKey;
         obj19.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 )
      {
         obj19.gxTpr_Usercustomizationsid = A143UserCustomizationsId;
         obj19.gxTpr_Usercustomizationskey = A144UserCustomizationsKey;
         return  ;
      }

      public void RowToVars19( GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations obj19 ,
                               int forceLoad )
      {
         Gx_mode = obj19.gxTpr_Mode;
         A145UserCustomizationsValue = obj19.gxTpr_Usercustomizationsvalue;
         A143UserCustomizationsId = obj19.gxTpr_Usercustomizationsid;
         A144UserCustomizationsKey = obj19.gxTpr_Usercustomizationskey;
         Z143UserCustomizationsId = obj19.gxTpr_Usercustomizationsid_Z;
         Z144UserCustomizationsKey = obj19.gxTpr_Usercustomizationskey_Z;
         Gx_mode = obj19.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A143UserCustomizationsId = (string)getParm(obj,0);
         A144UserCustomizationsKey = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0I19( ) ;
         ScanKeyStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z143UserCustomizationsId = A143UserCustomizationsId;
            Z144UserCustomizationsKey = A144UserCustomizationsKey;
         }
         ZM0I19( -1) ;
         OnLoadActions0I19( ) ;
         AddRow0I19( ) ;
         ScanKeyEnd0I19( ) ;
         if ( RcdFound19 == 0 )
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 0) ;
         ScanKeyStart0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z143UserCustomizationsId = A143UserCustomizationsId;
            Z144UserCustomizationsKey = A144UserCustomizationsKey;
         }
         ZM0I19( -1) ;
         OnLoadActions0I19( ) ;
         AddRow0I19( ) ;
         ScanKeyEnd0I19( ) ;
         if ( RcdFound19 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0I19( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0I19( ) ;
         }
         else
         {
            if ( RcdFound19 == 1 )
            {
               if ( ( StringUtil.StrCmp(A143UserCustomizationsId, Z143UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A144UserCustomizationsKey, Z144UserCustomizationsKey) != 0 ) )
               {
                  A143UserCustomizationsId = Z143UserCustomizationsId;
                  A144UserCustomizationsKey = Z144UserCustomizationsKey;
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
                  Update0I19( ) ;
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
                  if ( ( StringUtil.StrCmp(A143UserCustomizationsId, Z143UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A144UserCustomizationsKey, Z144UserCustomizationsKey) != 0 ) )
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
                        Insert0I19( ) ;
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
                        Insert0I19( ) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         SaveImpl( ) ;
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I19( ) ;
         AfterTrn( ) ;
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations auxBC = new GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A143UserCustomizationsId, A144UserCustomizationsKey);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_UserCustomizations);
               auxBC.Save();
               bcwwpbaseobjects_UserCustomizations.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0I19( ) ;
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
               VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
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
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0I19( ) ;
         if ( RcdFound19 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( StringUtil.StrCmp(A143UserCustomizationsId, Z143UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A144UserCustomizationsKey, Z144UserCustomizationsKey) != 0 ) )
            {
               A143UserCustomizationsId = Z143UserCustomizationsId;
               A144UserCustomizationsKey = Z144UserCustomizationsKey;
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
            if ( ( StringUtil.StrCmp(A143UserCustomizationsId, Z143UserCustomizationsId) != 0 ) || ( StringUtil.StrCmp(A144UserCustomizationsKey, Z144UserCustomizationsKey) != 0 ) )
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
         context.RollbackDataStores("wwpbaseobjects.usercustomizations_bc",pr_default);
         VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
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
         Gx_mode = bcwwpbaseobjects_UserCustomizations.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_UserCustomizations )
         {
            bcwwpbaseobjects_UserCustomizations = (GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow19( bcwwpbaseobjects_UserCustomizations) ;
            }
            else
            {
               RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_UserCustomizations.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_UserCustomizations.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars19( bcwwpbaseobjects_UserCustomizations, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtUserCustomizations UserCustomizations_BC
      {
         get {
            return bcwwpbaseobjects_UserCustomizations ;
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
            return "usercustomizations_Execute" ;
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
         Z143UserCustomizationsId = "";
         A143UserCustomizationsId = "";
         Z144UserCustomizationsKey = "";
         A144UserCustomizationsKey = "";
         Z145UserCustomizationsValue = "";
         A145UserCustomizationsValue = "";
         BC000I4_A143UserCustomizationsId = new string[] {""} ;
         BC000I4_A144UserCustomizationsKey = new string[] {""} ;
         BC000I4_A145UserCustomizationsValue = new string[] {""} ;
         BC000I5_A143UserCustomizationsId = new string[] {""} ;
         BC000I5_A144UserCustomizationsKey = new string[] {""} ;
         BC000I3_A143UserCustomizationsId = new string[] {""} ;
         BC000I3_A144UserCustomizationsKey = new string[] {""} ;
         BC000I3_A145UserCustomizationsValue = new string[] {""} ;
         sMode19 = "";
         BC000I2_A143UserCustomizationsId = new string[] {""} ;
         BC000I2_A144UserCustomizationsKey = new string[] {""} ;
         BC000I2_A145UserCustomizationsValue = new string[] {""} ;
         BC000I9_A143UserCustomizationsId = new string[] {""} ;
         BC000I9_A144UserCustomizationsKey = new string[] {""} ;
         BC000I9_A145UserCustomizationsValue = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.usercustomizations_bc__default(),
            new Object[][] {
                new Object[] {
               BC000I2_A143UserCustomizationsId, BC000I2_A144UserCustomizationsKey, BC000I2_A145UserCustomizationsValue
               }
               , new Object[] {
               BC000I3_A143UserCustomizationsId, BC000I3_A144UserCustomizationsKey, BC000I3_A145UserCustomizationsValue
               }
               , new Object[] {
               BC000I4_A143UserCustomizationsId, BC000I4_A144UserCustomizationsKey, BC000I4_A145UserCustomizationsValue
               }
               , new Object[] {
               BC000I5_A143UserCustomizationsId, BC000I5_A144UserCustomizationsKey
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000I9_A143UserCustomizationsId, BC000I9_A144UserCustomizationsKey, BC000I9_A145UserCustomizationsValue
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
      private short RcdFound19 ;
      private short nIsDirty_19 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z143UserCustomizationsId ;
      private string A143UserCustomizationsId ;
      private string sMode19 ;
      private bool mustCommit ;
      private string Z145UserCustomizationsValue ;
      private string A145UserCustomizationsValue ;
      private string Z144UserCustomizationsKey ;
      private string A144UserCustomizationsKey ;
      private GeneXus.Programs.wwpbaseobjects.SdtUserCustomizations bcwwpbaseobjects_UserCustomizations ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC000I4_A143UserCustomizationsId ;
      private string[] BC000I4_A144UserCustomizationsKey ;
      private string[] BC000I4_A145UserCustomizationsValue ;
      private string[] BC000I5_A143UserCustomizationsId ;
      private string[] BC000I5_A144UserCustomizationsKey ;
      private string[] BC000I3_A143UserCustomizationsId ;
      private string[] BC000I3_A144UserCustomizationsKey ;
      private string[] BC000I3_A145UserCustomizationsValue ;
      private string[] BC000I2_A143UserCustomizationsId ;
      private string[] BC000I2_A144UserCustomizationsKey ;
      private string[] BC000I2_A145UserCustomizationsValue ;
      private string[] BC000I9_A143UserCustomizationsId ;
      private string[] BC000I9_A144UserCustomizationsKey ;
      private string[] BC000I9_A145UserCustomizationsValue ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class usercustomizations_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class usercustomizations_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000I4;
        prmBC000I4 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I5;
        prmBC000I5 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I3;
        prmBC000I3 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I2;
        prmBC000I2 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I6;
        prmBC000I6 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0) ,
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0)
        };
        Object[] prmBC000I7;
        prmBC000I7 = new Object[] {
        new ParDef("UserCustomizationsValue",GXType.LongVarChar,2097152,0) ,
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I8;
        prmBC000I8 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        Object[] prmBC000I9;
        prmBC000I9 = new Object[] {
        new ParDef("UserCustomizationsId",GXType.Char,40,0) ,
        new ParDef("UserCustomizationsKey",GXType.VarChar,200,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000I2", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey  FOR UPDATE OF UserCustomizations",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I3", "SELECT UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I4", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I5", "SELECT UserCustomizationsId, UserCustomizationsKey FROM UserCustomizations WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000I6", "SAVEPOINT gxupdate;INSERT INTO UserCustomizations(UserCustomizationsId, UserCustomizationsKey, UserCustomizationsValue) VALUES(:UserCustomizationsId, :UserCustomizationsKey, :UserCustomizationsValue);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000I6)
           ,new CursorDef("BC000I7", "SAVEPOINT gxupdate;UPDATE UserCustomizations SET UserCustomizationsValue=:UserCustomizationsValue  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I7)
           ,new CursorDef("BC000I8", "SAVEPOINT gxupdate;DELETE FROM UserCustomizations  WHERE UserCustomizationsId = :UserCustomizationsId AND UserCustomizationsKey = :UserCustomizationsKey;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000I8)
           ,new CursorDef("BC000I9", "SELECT TM1.UserCustomizationsId, TM1.UserCustomizationsKey, TM1.UserCustomizationsValue FROM UserCustomizations TM1 WHERE TM1.UserCustomizationsId = ( :UserCustomizationsId) and TM1.UserCustomizationsKey = ( :UserCustomizationsKey) ORDER BY TM1.UserCustomizationsId, TM1.UserCustomizationsKey ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000I9,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
     }
  }

}

}
