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
namespace GeneXus.Programs.core {
   public class regiao_bc : GxSilentTrn, IGxSilentTrn
   {
      public regiao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public regiao_bc( IGxContext context )
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
         ReadRow011( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey011( ) ;
         standaloneModal( ) ;
         AddRow011( ) ;
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
            E11012 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z1RegiaoID = A1RegiaoID;
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

      protected void CONFIRM_010( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls011( ) ;
            }
            else
            {
               CheckExtendedTable011( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors011( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12012( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11012( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM011( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            Z7RegiaoSiglaNome = A7RegiaoSiglaNome;
            Z2RegiaoSigla = A2RegiaoSigla;
            Z3RegiaoNome = A3RegiaoNome;
         }
         if ( GX_JID == -2 )
         {
            Z7RegiaoSiglaNome = A7RegiaoSiglaNome;
            Z1RegiaoID = A1RegiaoID;
            Z2RegiaoSigla = A2RegiaoSigla;
            Z3RegiaoNome = A3RegiaoNome;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
      }

      protected void Load011( )
      {
         /* Using cursor BC00014 */
         pr_default.execute(2, new Object[] {A1RegiaoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound1 = 1;
            A7RegiaoSiglaNome = BC00014_A7RegiaoSiglaNome[0];
            A2RegiaoSigla = BC00014_A2RegiaoSigla[0];
            A3RegiaoNome = BC00014_A3RegiaoNome[0];
            ZM011( -2) ;
         }
         pr_default.close(2);
         OnLoadActions011( ) ;
      }

      protected void OnLoadActions011( )
      {
         A7RegiaoSiglaNome = StringUtil.Trim( A2RegiaoSigla) + " - " + StringUtil.Trim( A3RegiaoNome);
      }

      protected void CheckExtendedTable011( )
      {
         nIsDirty_1 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00015 */
         pr_default.execute(3, new Object[] {A2RegiaoSigla, A1RegiaoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         nIsDirty_1 = 1;
         A7RegiaoSiglaNome = StringUtil.Trim( A2RegiaoSigla) + " - " + StringUtil.Trim( A3RegiaoNome);
      }

      protected void CloseExtendedTableCursors011( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey011( )
      {
         /* Using cursor BC00016 */
         pr_default.execute(4, new Object[] {A1RegiaoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound1 = 1;
         }
         else
         {
            RcdFound1 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00013 */
         pr_default.execute(1, new Object[] {A1RegiaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM011( 2) ;
            RcdFound1 = 1;
            A7RegiaoSiglaNome = BC00013_A7RegiaoSiglaNome[0];
            A1RegiaoID = BC00013_A1RegiaoID[0];
            A2RegiaoSigla = BC00013_A2RegiaoSigla[0];
            A3RegiaoNome = BC00013_A3RegiaoNome[0];
            Z1RegiaoID = A1RegiaoID;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load011( ) ;
            if ( AnyError == 1 )
            {
               RcdFound1 = 0;
               InitializeNonKey011( ) ;
            }
            Gx_mode = sMode1;
         }
         else
         {
            RcdFound1 = 0;
            InitializeNonKey011( ) ;
            sMode1 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode1;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey011( ) ;
         if ( RcdFound1 == 0 )
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
         CONFIRM_010( ) ;
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

      protected void CheckOptimisticConcurrency011( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00012 */
            pr_default.execute(0, new Object[] {A1RegiaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_regiao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z7RegiaoSiglaNome, BC00012_A7RegiaoSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z2RegiaoSigla, BC00012_A2RegiaoSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z3RegiaoNome, BC00012_A3RegiaoNome[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_regiao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM011( 0) ;
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00017 */
                     pr_default.execute(5, new Object[] {A7RegiaoSiglaNome, A1RegiaoID, A2RegiaoSigla, A3RegiaoNome});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_regiao");
                     if ( (pr_default.getStatus(5) == 1) )
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
               Load011( ) ;
            }
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void Update011( )
      {
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable011( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm011( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate011( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00018 */
                     pr_default.execute(6, new Object[] {A7RegiaoSiglaNome, A2RegiaoSigla, A3RegiaoNome, A1RegiaoID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_regiao");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_regiao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate011( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_regiaoupdateredundancy(context ).execute( ref  A1RegiaoID) ;
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
            EndLevel011( ) ;
         }
         CloseExtendedTableCursors011( ) ;
      }

      protected void DeferredUpdate011( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate011( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency011( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls011( ) ;
            AfterConfirm011( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete011( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00019 */
                  pr_default.execute(7, new Object[] {A1RegiaoID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_regiao");
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
         sMode1 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel011( ) ;
         Gx_mode = sMode1;
      }

      protected void OnDeleteControls011( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000110 */
            pr_default.execute(8, new Object[] {A1RegiaoID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Unidade Federativa (Estado)"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
         }
      }

      protected void EndLevel011( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete011( ) ;
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

      public void ScanKeyStart011( )
      {
         /* Scan By routine */
         /* Using cursor BC000111 */
         pr_default.execute(9, new Object[] {A1RegiaoID});
         RcdFound1 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A7RegiaoSiglaNome = BC000111_A7RegiaoSiglaNome[0];
            A1RegiaoID = BC000111_A1RegiaoID[0];
            A2RegiaoSigla = BC000111_A2RegiaoSigla[0];
            A3RegiaoNome = BC000111_A3RegiaoNome[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext011( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound1 = 0;
         ScanKeyLoad011( ) ;
      }

      protected void ScanKeyLoad011( )
      {
         sMode1 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound1 = 1;
            A7RegiaoSiglaNome = BC000111_A7RegiaoSiglaNome[0];
            A1RegiaoID = BC000111_A1RegiaoID[0];
            A2RegiaoSigla = BC000111_A2RegiaoSigla[0];
            A3RegiaoNome = BC000111_A3RegiaoNome[0];
         }
         Gx_mode = sMode1;
      }

      protected void ScanKeyEnd011( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm011( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert011( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate011( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete011( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete011( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate011( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes011( )
      {
      }

      protected void send_integrity_lvl_hashes011( )
      {
      }

      protected void AddRow011( )
      {
         VarsToRow1( bccore_regiao) ;
      }

      protected void ReadRow011( )
      {
         RowToVars1( bccore_regiao, 1) ;
      }

      protected void InitializeNonKey011( )
      {
         A7RegiaoSiglaNome = "";
         A2RegiaoSigla = "";
         A3RegiaoNome = "";
         Z7RegiaoSiglaNome = "";
         Z2RegiaoSigla = "";
         Z3RegiaoNome = "";
      }

      protected void InitAll011( )
      {
         A1RegiaoID = 0;
         InitializeNonKey011( ) ;
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

      public void VarsToRow1( GeneXus.Programs.core.Sdtregiao obj1 )
      {
         obj1.gxTpr_Mode = Gx_mode;
         obj1.gxTpr_Regiaosiglanome = A7RegiaoSiglaNome;
         obj1.gxTpr_Regiaosigla = A2RegiaoSigla;
         obj1.gxTpr_Regiaonome = A3RegiaoNome;
         obj1.gxTpr_Regiaoid = A1RegiaoID;
         obj1.gxTpr_Regiaoid_Z = Z1RegiaoID;
         obj1.gxTpr_Regiaosigla_Z = Z2RegiaoSigla;
         obj1.gxTpr_Regiaonome_Z = Z3RegiaoNome;
         obj1.gxTpr_Regiaosiglanome_Z = Z7RegiaoSiglaNome;
         obj1.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow1( GeneXus.Programs.core.Sdtregiao obj1 )
      {
         obj1.gxTpr_Regiaoid = A1RegiaoID;
         return  ;
      }

      public void RowToVars1( GeneXus.Programs.core.Sdtregiao obj1 ,
                              int forceLoad )
      {
         Gx_mode = obj1.gxTpr_Mode;
         A7RegiaoSiglaNome = obj1.gxTpr_Regiaosiglanome;
         A2RegiaoSigla = obj1.gxTpr_Regiaosigla;
         A3RegiaoNome = obj1.gxTpr_Regiaonome;
         A1RegiaoID = obj1.gxTpr_Regiaoid;
         Z1RegiaoID = obj1.gxTpr_Regiaoid_Z;
         Z2RegiaoSigla = obj1.gxTpr_Regiaosigla_Z;
         Z3RegiaoNome = obj1.gxTpr_Regiaonome_Z;
         Z7RegiaoSiglaNome = obj1.gxTpr_Regiaosiglanome_Z;
         Gx_mode = obj1.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A1RegiaoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey011( ) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1RegiaoID = A1RegiaoID;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
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
         RowToVars1( bccore_regiao, 0) ;
         ScanKeyStart011( ) ;
         if ( RcdFound1 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z1RegiaoID = A1RegiaoID;
         }
         ZM011( -2) ;
         OnLoadActions011( ) ;
         AddRow011( ) ;
         ScanKeyEnd011( ) ;
         if ( RcdFound1 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey011( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert011( ) ;
         }
         else
         {
            if ( RcdFound1 == 1 )
            {
               if ( A1RegiaoID != Z1RegiaoID )
               {
                  A1RegiaoID = Z1RegiaoID;
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
                  Update011( ) ;
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
                  if ( A1RegiaoID != Z1RegiaoID )
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
                        Insert011( ) ;
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
                        Insert011( ) ;
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
         RowToVars1( bccore_regiao, 1) ;
         SaveImpl( ) ;
         VarsToRow1( bccore_regiao) ;
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
         RowToVars1( bccore_regiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
         AfterTrn( ) ;
         VarsToRow1( bccore_regiao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow1( bccore_regiao) ;
         }
         else
         {
            GeneXus.Programs.core.Sdtregiao auxBC = new GeneXus.Programs.core.Sdtregiao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A1RegiaoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_regiao);
               auxBC.Save();
               bccore_regiao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars1( bccore_regiao, 1) ;
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
         RowToVars1( bccore_regiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert011( ) ;
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
               VarsToRow1( bccore_regiao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow1( bccore_regiao) ;
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
         RowToVars1( bccore_regiao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey011( ) ;
         if ( RcdFound1 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A1RegiaoID != Z1RegiaoID )
            {
               A1RegiaoID = Z1RegiaoID;
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
            if ( A1RegiaoID != Z1RegiaoID )
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
         context.RollbackDataStores("core.regiao_bc",pr_default);
         VarsToRow1( bccore_regiao) ;
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
         Gx_mode = bccore_regiao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_regiao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_regiao )
         {
            bccore_regiao = (GeneXus.Programs.core.Sdtregiao)(sdt);
            if ( StringUtil.StrCmp(bccore_regiao.gxTpr_Mode, "") == 0 )
            {
               bccore_regiao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow1( bccore_regiao) ;
            }
            else
            {
               RowToVars1( bccore_regiao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_regiao.gxTpr_Mode, "") == 0 )
            {
               bccore_regiao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars1( bccore_regiao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtregiao regiao_BC
      {
         get {
            return bccore_regiao ;
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
            return "regiao_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z7RegiaoSiglaNome = "";
         A7RegiaoSiglaNome = "";
         Z2RegiaoSigla = "";
         A2RegiaoSigla = "";
         Z3RegiaoNome = "";
         A3RegiaoNome = "";
         BC00014_A7RegiaoSiglaNome = new string[] {""} ;
         BC00014_A1RegiaoID = new int[1] ;
         BC00014_A2RegiaoSigla = new string[] {""} ;
         BC00014_A3RegiaoNome = new string[] {""} ;
         BC00015_A2RegiaoSigla = new string[] {""} ;
         BC00016_A1RegiaoID = new int[1] ;
         BC00013_A7RegiaoSiglaNome = new string[] {""} ;
         BC00013_A1RegiaoID = new int[1] ;
         BC00013_A2RegiaoSigla = new string[] {""} ;
         BC00013_A3RegiaoNome = new string[] {""} ;
         sMode1 = "";
         BC00012_A7RegiaoSiglaNome = new string[] {""} ;
         BC00012_A1RegiaoID = new int[1] ;
         BC00012_A2RegiaoSigla = new string[] {""} ;
         BC00012_A3RegiaoNome = new string[] {""} ;
         BC000110_A4UFID = new int[1] ;
         BC000111_A7RegiaoSiglaNome = new string[] {""} ;
         BC000111_A1RegiaoID = new int[1] ;
         BC000111_A2RegiaoSigla = new string[] {""} ;
         BC000111_A3RegiaoNome = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.regiao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.regiao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00012_A7RegiaoSiglaNome, BC00012_A1RegiaoID, BC00012_A2RegiaoSigla, BC00012_A3RegiaoNome
               }
               , new Object[] {
               BC00013_A7RegiaoSiglaNome, BC00013_A1RegiaoID, BC00013_A2RegiaoSigla, BC00013_A3RegiaoNome
               }
               , new Object[] {
               BC00014_A7RegiaoSiglaNome, BC00014_A1RegiaoID, BC00014_A2RegiaoSigla, BC00014_A3RegiaoNome
               }
               , new Object[] {
               BC00015_A2RegiaoSigla
               }
               , new Object[] {
               BC00016_A1RegiaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000110_A4UFID
               }
               , new Object[] {
               BC000111_A7RegiaoSiglaNome, BC000111_A1RegiaoID, BC000111_A2RegiaoSigla, BC000111_A3RegiaoNome
               }
            }
         );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12012 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound1 ;
      private short nIsDirty_1 ;
      private int trnEnded ;
      private int Z1RegiaoID ;
      private int A1RegiaoID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode1 ;
      private bool returnInSub ;
      private bool mustCommit ;
      private string Z7RegiaoSiglaNome ;
      private string A7RegiaoSiglaNome ;
      private string Z2RegiaoSigla ;
      private string A2RegiaoSigla ;
      private string Z3RegiaoNome ;
      private string A3RegiaoNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.Sdtregiao bccore_regiao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00014_A7RegiaoSiglaNome ;
      private int[] BC00014_A1RegiaoID ;
      private string[] BC00014_A2RegiaoSigla ;
      private string[] BC00014_A3RegiaoNome ;
      private string[] BC00015_A2RegiaoSigla ;
      private int[] BC00016_A1RegiaoID ;
      private string[] BC00013_A7RegiaoSiglaNome ;
      private int[] BC00013_A1RegiaoID ;
      private string[] BC00013_A2RegiaoSigla ;
      private string[] BC00013_A3RegiaoNome ;
      private string[] BC00012_A7RegiaoSiglaNome ;
      private int[] BC00012_A1RegiaoID ;
      private string[] BC00012_A2RegiaoSigla ;
      private string[] BC00012_A3RegiaoNome ;
      private int[] BC000110_A4UFID ;
      private string[] BC000111_A7RegiaoSiglaNome ;
      private int[] BC000111_A1RegiaoID ;
      private string[] BC000111_A2RegiaoSigla ;
      private string[] BC000111_A3RegiaoNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
   }

   public class regiao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class regiao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00014;
        prmBC00014 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00015;
        prmBC00015 = new Object[] {
        new ParDef("RegiaoSigla",GXType.VarChar,10,0) ,
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00016;
        prmBC00016 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00013;
        prmBC00013 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00012;
        prmBC00012 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00017;
        prmBC00017 = new Object[] {
        new ParDef("RegiaoSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("RegiaoID",GXType.Int32,9,0) ,
        new ParDef("RegiaoSigla",GXType.VarChar,10,0) ,
        new ParDef("RegiaoNome",GXType.VarChar,50,0)
        };
        Object[] prmBC00018;
        prmBC00018 = new Object[] {
        new ParDef("RegiaoSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("RegiaoSigla",GXType.VarChar,10,0) ,
        new ParDef("RegiaoNome",GXType.VarChar,50,0) ,
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00019;
        prmBC00019 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000110;
        prmBC000110 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000111;
        prmBC000111 = new Object[] {
        new ParDef("RegiaoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00012", "SELECT RegiaoSiglaNome, RegiaoID, RegiaoSigla, RegiaoNome FROM tbibge_regiao WHERE RegiaoID = :RegiaoID  FOR UPDATE OF tbibge_regiao",true, GxErrorMask.GX_NOMASK, false, this,prmBC00012,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00013", "SELECT RegiaoSiglaNome, RegiaoID, RegiaoSigla, RegiaoNome FROM tbibge_regiao WHERE RegiaoID = :RegiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00013,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00014", "SELECT TM1.RegiaoSiglaNome, TM1.RegiaoID, TM1.RegiaoSigla, TM1.RegiaoNome FROM tbibge_regiao TM1 WHERE TM1.RegiaoID = :RegiaoID ORDER BY TM1.RegiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00014,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00015", "SELECT RegiaoSigla FROM tbibge_regiao WHERE (RegiaoSigla = :RegiaoSigla) AND (Not ( RegiaoID = :RegiaoID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00015,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00016", "SELECT RegiaoID FROM tbibge_regiao WHERE RegiaoID = :RegiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00016,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00017", "SAVEPOINT gxupdate;INSERT INTO tbibge_regiao(RegiaoSiglaNome, RegiaoID, RegiaoSigla, RegiaoNome) VALUES(:RegiaoSiglaNome, :RegiaoID, :RegiaoSigla, :RegiaoNome);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00017)
           ,new CursorDef("BC00018", "SAVEPOINT gxupdate;UPDATE tbibge_regiao SET RegiaoSiglaNome=:RegiaoSiglaNome, RegiaoSigla=:RegiaoSigla, RegiaoNome=:RegiaoNome  WHERE RegiaoID = :RegiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00018)
           ,new CursorDef("BC00019", "SAVEPOINT gxupdate;DELETE FROM tbibge_regiao  WHERE RegiaoID = :RegiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00019)
           ,new CursorDef("BC000110", "SELECT UFID FROM tbibge_uf WHERE UFRegID = :RegiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000110,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000111", "SELECT TM1.RegiaoSiglaNome, TM1.RegiaoID, TM1.RegiaoSigla, TM1.RegiaoNome FROM tbibge_regiao TM1 WHERE TM1.RegiaoID = :RegiaoID ORDER BY TM1.RegiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000111,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              return;
     }
  }

}

}
