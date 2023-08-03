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
   public class wwp_entity_bc : GxSilentTrn, IGxSilentTrn
   {
      public wwp_entity_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_entity_bc( IGxContext context )
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
         ReadRow077( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey077( ) ;
         standaloneModal( ) ;
         AddRow077( ) ;
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
               Z62WWPEntityId = A62WWPEntityId;
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

      protected void CONFIRM_070( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls077( ) ;
            }
            else
            {
               CheckExtendedTable077( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors077( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void ZM077( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            Z63WWPEntityName = A63WWPEntityName;
         }
         if ( GX_JID == -1 )
         {
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

      protected void Load077( )
      {
         /* Using cursor BC00074 */
         pr_default.execute(2, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound7 = 1;
            A63WWPEntityName = BC00074_A63WWPEntityName[0];
            ZM077( -1) ;
         }
         pr_default.close(2);
         OnLoadActions077( ) ;
      }

      protected void OnLoadActions077( )
      {
      }

      protected void CheckExtendedTable077( )
      {
         nIsDirty_7 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors077( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey077( )
      {
         /* Using cursor BC00075 */
         pr_default.execute(3, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound7 = 1;
         }
         else
         {
            RcdFound7 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00073 */
         pr_default.execute(1, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM077( 1) ;
            RcdFound7 = 1;
            A62WWPEntityId = BC00073_A62WWPEntityId[0];
            A63WWPEntityName = BC00073_A63WWPEntityName[0];
            Z62WWPEntityId = A62WWPEntityId;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load077( ) ;
            if ( AnyError == 1 )
            {
               RcdFound7 = 0;
               InitializeNonKey077( ) ;
            }
            Gx_mode = sMode7;
         }
         else
         {
            RcdFound7 = 0;
            InitializeNonKey077( ) ;
            sMode7 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode7;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey077( ) ;
         if ( RcdFound7 == 0 )
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
         CONFIRM_070( ) ;
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

      protected void CheckOptimisticConcurrency077( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00072 */
            pr_default.execute(0, new Object[] {A62WWPEntityId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z63WWPEntityName, BC00072_A63WWPEntityName[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Entity"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM077( 0) ;
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00076 */
                     pr_default.execute(4, new Object[] {A63WWPEntityName});
                     pr_default.close(4);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00077 */
                     pr_default.execute(5);
                     A62WWPEntityId = BC00077_A62WWPEntityId[0];
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
               Load077( ) ;
            }
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void Update077( )
      {
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable077( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm077( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate077( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00078 */
                     pr_default.execute(6, new Object[] {A63WWPEntityName, A62WWPEntityId});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Entity"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate077( ) ;
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
            EndLevel077( ) ;
         }
         CloseExtendedTableCursors077( ) ;
      }

      protected void DeferredUpdate077( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate077( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency077( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls077( ) ;
            AfterConfirm077( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete077( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00079 */
                  pr_default.execute(7, new Object[] {A62WWPEntityId});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Entity");
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
         sMode7 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel077( ) ;
         Gx_mode = sMode7;
      }

      protected void OnDeleteControls077( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000710 */
            pr_default.execute(8, new Object[] {A62WWPEntityId});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessage"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000711 */
            pr_default.execute(9, new Object[] {A62WWPEntityId});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_NotificationDefinition"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel077( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete077( ) ;
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

      public void ScanKeyStart077( )
      {
         /* Using cursor BC000712 */
         pr_default.execute(10, new Object[] {A62WWPEntityId});
         RcdFound7 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A62WWPEntityId = BC000712_A62WWPEntityId[0];
            A63WWPEntityName = BC000712_A63WWPEntityName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext077( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound7 = 0;
         ScanKeyLoad077( ) ;
      }

      protected void ScanKeyLoad077( )
      {
         sMode7 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound7 = 1;
            A62WWPEntityId = BC000712_A62WWPEntityId[0];
            A63WWPEntityName = BC000712_A63WWPEntityName[0];
         }
         Gx_mode = sMode7;
      }

      protected void ScanKeyEnd077( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm077( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert077( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate077( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete077( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete077( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate077( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes077( )
      {
      }

      protected void send_integrity_lvl_hashes077( )
      {
      }

      protected void AddRow077( )
      {
         VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
      }

      protected void ReadRow077( )
      {
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
      }

      protected void InitializeNonKey077( )
      {
         A63WWPEntityName = "";
         Z63WWPEntityName = "";
      }

      protected void InitAll077( )
      {
         A62WWPEntityId = 0;
         InitializeNonKey077( ) ;
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

      public void VarsToRow7( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj7 )
      {
         obj7.gxTpr_Mode = Gx_mode;
         obj7.gxTpr_Wwpentityname = A63WWPEntityName;
         obj7.gxTpr_Wwpentityid = A62WWPEntityId;
         obj7.gxTpr_Wwpentityid_Z = Z62WWPEntityId;
         obj7.gxTpr_Wwpentityname_Z = Z63WWPEntityName;
         obj7.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow7( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj7 )
      {
         obj7.gxTpr_Wwpentityid = A62WWPEntityId;
         return  ;
      }

      public void RowToVars7( GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity obj7 ,
                              int forceLoad )
      {
         Gx_mode = obj7.gxTpr_Mode;
         A63WWPEntityName = obj7.gxTpr_Wwpentityname;
         A62WWPEntityId = obj7.gxTpr_Wwpentityid;
         Z62WWPEntityId = obj7.gxTpr_Wwpentityid_Z;
         Z63WWPEntityName = obj7.gxTpr_Wwpentityname_Z;
         Gx_mode = obj7.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A62WWPEntityId = (long)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey077( ) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z62WWPEntityId = A62WWPEntityId;
         }
         ZM077( -1) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 0) ;
         ScanKeyStart077( ) ;
         if ( RcdFound7 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z62WWPEntityId = A62WWPEntityId;
         }
         ZM077( -1) ;
         OnLoadActions077( ) ;
         AddRow077( ) ;
         ScanKeyEnd077( ) ;
         if ( RcdFound7 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey077( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert077( ) ;
         }
         else
         {
            if ( RcdFound7 == 1 )
            {
               if ( A62WWPEntityId != Z62WWPEntityId )
               {
                  A62WWPEntityId = Z62WWPEntityId;
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
                  Update077( ) ;
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
                  if ( A62WWPEntityId != Z62WWPEntityId )
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
                        Insert077( ) ;
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
                        Insert077( ) ;
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
         SaveImpl( ) ;
         VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
         AfterTrn( ) ;
         VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
         }
         else
         {
            GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity auxBC = new GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A62WWPEntityId);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bcwwpbaseobjects_WWP_Entity);
               auxBC.Save();
               bcwwpbaseobjects_WWP_Entity.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert077( ) ;
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
               VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
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
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey077( ) ;
         if ( RcdFound7 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A62WWPEntityId != Z62WWPEntityId )
            {
               A62WWPEntityId = Z62WWPEntityId;
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
            if ( A62WWPEntityId != Z62WWPEntityId )
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
         context.RollbackDataStores("wwpbaseobjects.wwp_entity_bc",pr_default);
         VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
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
         Gx_mode = bcwwpbaseobjects_WWP_Entity.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bcwwpbaseobjects_WWP_Entity )
         {
            bcwwpbaseobjects_WWP_Entity = (GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity)(sdt);
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow7( bcwwpbaseobjects_WWP_Entity) ;
            }
            else
            {
               RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bcwwpbaseobjects_WWP_Entity.gxTpr_Mode, "") == 0 )
            {
               bcwwpbaseobjects_WWP_Entity.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars7( bcwwpbaseobjects_WWP_Entity, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtWWP_Entity WWP_Entity_BC
      {
         get {
            return bcwwpbaseobjects_WWP_Entity ;
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
            return "wwpentity_Execute" ;
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
         Z63WWPEntityName = "";
         A63WWPEntityName = "";
         BC00074_A62WWPEntityId = new long[1] ;
         BC00074_A63WWPEntityName = new string[] {""} ;
         BC00075_A62WWPEntityId = new long[1] ;
         BC00073_A62WWPEntityId = new long[1] ;
         BC00073_A63WWPEntityName = new string[] {""} ;
         sMode7 = "";
         BC00072_A62WWPEntityId = new long[1] ;
         BC00072_A63WWPEntityName = new string[] {""} ;
         BC00077_A62WWPEntityId = new long[1] ;
         BC000710_A137WWPDiscussionMessageId = new long[1] ;
         BC000711_A65WWPNotificationDefinitionId = new long[1] ;
         BC000712_A62WWPEntityId = new long[1] ;
         BC000712_A63WWPEntityName = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_entity_bc__default(),
            new Object[][] {
                new Object[] {
               BC00072_A62WWPEntityId, BC00072_A63WWPEntityName
               }
               , new Object[] {
               BC00073_A62WWPEntityId, BC00073_A63WWPEntityName
               }
               , new Object[] {
               BC00074_A62WWPEntityId, BC00074_A63WWPEntityName
               }
               , new Object[] {
               BC00075_A62WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               BC00077_A62WWPEntityId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000710_A137WWPDiscussionMessageId
               }
               , new Object[] {
               BC000711_A65WWPNotificationDefinitionId
               }
               , new Object[] {
               BC000712_A62WWPEntityId, BC000712_A63WWPEntityName
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
      private short RcdFound7 ;
      private short nIsDirty_7 ;
      private int trnEnded ;
      private long Z62WWPEntityId ;
      private long A62WWPEntityId ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode7 ;
      private bool mustCommit ;
      private string Z63WWPEntityName ;
      private string A63WWPEntityName ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWP_Entity bcwwpbaseobjects_WWP_Entity ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private long[] BC00074_A62WWPEntityId ;
      private string[] BC00074_A63WWPEntityName ;
      private long[] BC00075_A62WWPEntityId ;
      private long[] BC00073_A62WWPEntityId ;
      private string[] BC00073_A63WWPEntityName ;
      private long[] BC00072_A62WWPEntityId ;
      private string[] BC00072_A63WWPEntityName ;
      private long[] BC00077_A62WWPEntityId ;
      private long[] BC000710_A137WWPDiscussionMessageId ;
      private long[] BC000711_A65WWPNotificationDefinitionId ;
      private long[] BC000712_A62WWPEntityId ;
      private string[] BC000712_A63WWPEntityName ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
   }

   public class wwp_entity_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_entity_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00074;
        prmBC00074 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00075;
        prmBC00075 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00073;
        prmBC00073 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00072;
        prmBC00072 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00076;
        prmBC00076 = new Object[] {
        new ParDef("WWPEntityName",GXType.VarChar,100,0)
        };
        Object[] prmBC00077;
        prmBC00077 = new Object[] {
        };
        Object[] prmBC00078;
        prmBC00078 = new Object[] {
        new ParDef("WWPEntityName",GXType.VarChar,100,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC00079;
        prmBC00079 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000710;
        prmBC000710 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000711;
        prmBC000711 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmBC000712;
        prmBC000712 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00072", "SELECT WWPEntityId, WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId  FOR UPDATE OF WWP_Entity",true, GxErrorMask.GX_NOMASK, false, this,prmBC00072,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00073", "SELECT WWPEntityId, WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00073,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00074", "SELECT TM1.WWPEntityId, TM1.WWPEntityName FROM WWP_Entity TM1 WHERE TM1.WWPEntityId = :WWPEntityId ORDER BY TM1.WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00074,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00075", "SELECT WWPEntityId FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00075,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00076", "SAVEPOINT gxupdate;INSERT INTO WWP_Entity(WWPEntityName) VALUES(:WWPEntityName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00076)
           ,new CursorDef("BC00077", "SELECT currval('WWPEntityId') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00077,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00078", "SAVEPOINT gxupdate;UPDATE WWP_Entity SET WWPEntityName=:WWPEntityName  WHERE WWPEntityId = :WWPEntityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00078)
           ,new CursorDef("BC00079", "SAVEPOINT gxupdate;DELETE FROM WWP_Entity  WHERE WWPEntityId = :WWPEntityId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00079)
           ,new CursorDef("BC000710", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000710,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000711", "SELECT WWPNotificationDefinitionId FROM WWP_NotificationDefinition WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000711,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000712", "SELECT TM1.WWPEntityId, TM1.WWPEntityName FROM WWP_Entity TM1 WHERE TM1.WWPEntityId = :WWPEntityId ORDER BY TM1.WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000712,100, GxCacheFrequency.OFF ,true,false )
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
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
