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
   public class mesorregiao_bc : GxSilentTrn, IGxSilentTrn
   {
      public mesorregiao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mesorregiao_bc( IGxContext context )
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
         ReadRow033( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey033( ) ;
         standaloneModal( ) ;
         AddRow033( ) ;
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
            E11032 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z13MesorregiaoID = A13MesorregiaoID;
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

      protected void CONFIRM_030( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls033( ) ;
            }
            else
            {
               CheckExtendedTable033( ) ;
               if ( AnyError == 0 )
               {
                  ZM033( 6) ;
                  ZM033( 7) ;
               }
               CloseExtendedTableCursors033( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12032( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MesorregiaoUFID") == 0 )
               {
                  AV13Insert_MesorregiaoUFID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E11032( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM033( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z18MesorregiaoUFSiglaNome = A18MesorregiaoUFSiglaNome;
            Z22MesorregiaoUFRegSiglaNome = A22MesorregiaoUFRegSiglaNome;
            Z14MesorregiaoNome = A14MesorregiaoNome;
            Z15MesorregiaoUFID = A15MesorregiaoUFID;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            Z17MesorregiaoUFNome = A17MesorregiaoUFNome;
            Z19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            Z21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
         }
         if ( GX_JID == -5 )
         {
            Z18MesorregiaoUFSiglaNome = A18MesorregiaoUFSiglaNome;
            Z22MesorregiaoUFRegSiglaNome = A22MesorregiaoUFRegSiglaNome;
            Z13MesorregiaoID = A13MesorregiaoID;
            Z14MesorregiaoNome = A14MesorregiaoNome;
            Z16MesorregiaoUFSigla = A16MesorregiaoUFSigla;
            Z17MesorregiaoUFNome = A17MesorregiaoUFNome;
            Z19MesorregiaoUFRegID = A19MesorregiaoUFRegID;
            Z20MesorregiaoUFRegSigla = A20MesorregiaoUFRegSigla;
            Z21MesorregiaoUFRegNome = A21MesorregiaoUFRegNome;
            Z15MesorregiaoUFID = A15MesorregiaoUFID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.mesorregiao_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load033( )
      {
         /* Using cursor BC00036 */
         pr_default.execute(4, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound3 = 1;
            A18MesorregiaoUFSiglaNome = BC00036_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = BC00036_n18MesorregiaoUFSiglaNome[0];
            A22MesorregiaoUFRegSiglaNome = BC00036_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = BC00036_n22MesorregiaoUFRegSiglaNome[0];
            A14MesorregiaoNome = BC00036_A14MesorregiaoNome[0];
            A16MesorregiaoUFSigla = BC00036_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = BC00036_A17MesorregiaoUFNome[0];
            A19MesorregiaoUFRegID = BC00036_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = BC00036_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = BC00036_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = BC00036_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = BC00036_n21MesorregiaoUFRegNome[0];
            A15MesorregiaoUFID = BC00036_A15MesorregiaoUFID[0];
            ZM033( -5) ;
         }
         pr_default.close(4);
         OnLoadActions033( ) ;
      }

      protected void OnLoadActions033( )
      {
         A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
         n18MesorregiaoUFSiglaNome = false;
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A19MesorregiaoUFRegID});
         A20MesorregiaoUFRegSigla = BC00035_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = BC00035_n20MesorregiaoUFRegSigla[0];
         A21MesorregiaoUFRegNome = BC00035_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = BC00035_n21MesorregiaoUFRegNome[0];
         pr_default.close(3);
         A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
         n22MesorregiaoUFRegSiglaNome = false;
      }

      protected void CheckExtendedTable033( )
      {
         nIsDirty_3 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00034 */
         pr_default.execute(2, new Object[] {A15MesorregiaoUFID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group UF -> Mesoregião'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFID");
            AnyError = 1;
         }
         A16MesorregiaoUFSigla = BC00034_A16MesorregiaoUFSigla[0];
         A17MesorregiaoUFNome = BC00034_A17MesorregiaoUFNome[0];
         A19MesorregiaoUFRegID = BC00034_A19MesorregiaoUFRegID[0];
         pr_default.close(2);
         nIsDirty_3 = 1;
         A18MesorregiaoUFSiglaNome = StringUtil.Trim( A16MesorregiaoUFSigla) + " - " + StringUtil.Trim( A17MesorregiaoUFNome);
         n18MesorregiaoUFSiglaNome = false;
         /* Using cursor BC00035 */
         pr_default.execute(3, new Object[] {A19MesorregiaoUFRegID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MESORREGIAOUFREGID");
            AnyError = 1;
         }
         A20MesorregiaoUFRegSigla = BC00035_A20MesorregiaoUFRegSigla[0];
         n20MesorregiaoUFRegSigla = BC00035_n20MesorregiaoUFRegSigla[0];
         A21MesorregiaoUFRegNome = BC00035_A21MesorregiaoUFRegNome[0];
         n21MesorregiaoUFRegNome = BC00035_n21MesorregiaoUFRegNome[0];
         pr_default.close(3);
         nIsDirty_3 = 1;
         A22MesorregiaoUFRegSiglaNome = StringUtil.Trim( A20MesorregiaoUFRegSigla) + " - " + StringUtil.Trim( A21MesorregiaoUFRegNome);
         n22MesorregiaoUFRegSiglaNome = false;
      }

      protected void CloseExtendedTableCursors033( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey033( )
      {
         /* Using cursor BC00037 */
         pr_default.execute(5, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound3 = 1;
         }
         else
         {
            RcdFound3 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00033 */
         pr_default.execute(1, new Object[] {A13MesorregiaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM033( 5) ;
            RcdFound3 = 1;
            A13MesorregiaoID = BC00033_A13MesorregiaoID[0];
            A14MesorregiaoNome = BC00033_A14MesorregiaoNome[0];
            A15MesorregiaoUFID = BC00033_A15MesorregiaoUFID[0];
            A18MesorregiaoUFSiglaNome = BC00033_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = BC00033_n18MesorregiaoUFSiglaNome[0];
            A22MesorregiaoUFRegSiglaNome = BC00033_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = BC00033_n22MesorregiaoUFRegSiglaNome[0];
            Z13MesorregiaoID = A13MesorregiaoID;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load033( ) ;
            if ( AnyError == 1 )
            {
               RcdFound3 = 0;
               InitializeNonKey033( ) ;
            }
            Gx_mode = sMode3;
         }
         else
         {
            RcdFound3 = 0;
            InitializeNonKey033( ) ;
            sMode3 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode3;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey033( ) ;
         if ( RcdFound3 == 0 )
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
         CONFIRM_030( ) ;
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

      protected void CheckOptimisticConcurrency033( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00032 */
            pr_default.execute(0, new Object[] {A13MesorregiaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_mesorregiao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z18MesorregiaoUFSiglaNome, BC00032_A18MesorregiaoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z22MesorregiaoUFRegSiglaNome, BC00032_A22MesorregiaoUFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z14MesorregiaoNome, BC00032_A14MesorregiaoNome[0]) != 0 ) || ( Z15MesorregiaoUFID != BC00032_A15MesorregiaoUFID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_mesorregiao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM033( 0) ;
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00038 */
                     pr_default.execute(6, new Object[] {A16MesorregiaoUFSigla, A17MesorregiaoUFNome, A19MesorregiaoUFRegID, n20MesorregiaoUFRegSigla, A20MesorregiaoUFRegSigla, n21MesorregiaoUFRegNome, A21MesorregiaoUFRegNome, n18MesorregiaoUFSiglaNome, A18MesorregiaoUFSiglaNome, n22MesorregiaoUFRegSiglaNome, A22MesorregiaoUFRegSiglaNome, A13MesorregiaoID, A14MesorregiaoNome, A15MesorregiaoUFID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
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
               Load033( ) ;
            }
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void Update033( )
      {
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable033( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm033( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate033( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00039 */
                     pr_default.execute(7, new Object[] {A16MesorregiaoUFSigla, A17MesorregiaoUFNome, A19MesorregiaoUFRegID, n20MesorregiaoUFRegSigla, A20MesorregiaoUFRegSigla, n21MesorregiaoUFRegNome, A21MesorregiaoUFRegNome, n18MesorregiaoUFSiglaNome, A18MesorregiaoUFSiglaNome, n22MesorregiaoUFRegSiglaNome, A22MesorregiaoUFRegSiglaNome, A14MesorregiaoNome, A15MesorregiaoUFID, A13MesorregiaoID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_mesorregiao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate033( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_mesorregiaoupdateredundancy(context ).execute( ref  A13MesorregiaoID) ;
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
            EndLevel033( ) ;
         }
         CloseExtendedTableCursors033( ) ;
      }

      protected void DeferredUpdate033( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate033( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency033( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls033( ) ;
            AfterConfirm033( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete033( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000310 */
                  pr_default.execute(8, new Object[] {A13MesorregiaoID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_mesorregiao");
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
         sMode3 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel033( ) ;
         Gx_mode = sMode3;
      }

      protected void OnDeleteControls033( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000311 */
            pr_default.execute(9, new Object[] {A15MesorregiaoUFID});
            A16MesorregiaoUFSigla = BC000311_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = BC000311_A17MesorregiaoUFNome[0];
            A19MesorregiaoUFRegID = BC000311_A19MesorregiaoUFRegID[0];
            pr_default.close(9);
            /* Using cursor BC000312 */
            pr_default.execute(10, new Object[] {A19MesorregiaoUFRegID});
            A20MesorregiaoUFRegSigla = BC000312_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = BC000312_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = BC000312_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = BC000312_n21MesorregiaoUFRegNome[0];
            pr_default.close(10);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000313 */
            pr_default.execute(11, new Object[] {A13MesorregiaoID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Microrregião"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel033( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete033( ) ;
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

      public void ScanKeyStart033( )
      {
         /* Scan By routine */
         /* Using cursor BC000314 */
         pr_default.execute(12, new Object[] {A13MesorregiaoID});
         RcdFound3 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A18MesorregiaoUFSiglaNome = BC000314_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = BC000314_n18MesorregiaoUFSiglaNome[0];
            A22MesorregiaoUFRegSiglaNome = BC000314_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = BC000314_n22MesorregiaoUFRegSiglaNome[0];
            A13MesorregiaoID = BC000314_A13MesorregiaoID[0];
            A14MesorregiaoNome = BC000314_A14MesorregiaoNome[0];
            A16MesorregiaoUFSigla = BC000314_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = BC000314_A17MesorregiaoUFNome[0];
            A19MesorregiaoUFRegID = BC000314_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = BC000314_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = BC000314_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = BC000314_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = BC000314_n21MesorregiaoUFRegNome[0];
            A15MesorregiaoUFID = BC000314_A15MesorregiaoUFID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext033( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound3 = 0;
         ScanKeyLoad033( ) ;
      }

      protected void ScanKeyLoad033( )
      {
         sMode3 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound3 = 1;
            A18MesorregiaoUFSiglaNome = BC000314_A18MesorregiaoUFSiglaNome[0];
            n18MesorregiaoUFSiglaNome = BC000314_n18MesorregiaoUFSiglaNome[0];
            A22MesorregiaoUFRegSiglaNome = BC000314_A22MesorregiaoUFRegSiglaNome[0];
            n22MesorregiaoUFRegSiglaNome = BC000314_n22MesorregiaoUFRegSiglaNome[0];
            A13MesorregiaoID = BC000314_A13MesorregiaoID[0];
            A14MesorregiaoNome = BC000314_A14MesorregiaoNome[0];
            A16MesorregiaoUFSigla = BC000314_A16MesorregiaoUFSigla[0];
            A17MesorregiaoUFNome = BC000314_A17MesorregiaoUFNome[0];
            A19MesorregiaoUFRegID = BC000314_A19MesorregiaoUFRegID[0];
            A20MesorregiaoUFRegSigla = BC000314_A20MesorregiaoUFRegSigla[0];
            n20MesorregiaoUFRegSigla = BC000314_n20MesorregiaoUFRegSigla[0];
            A21MesorregiaoUFRegNome = BC000314_A21MesorregiaoUFRegNome[0];
            n21MesorregiaoUFRegNome = BC000314_n21MesorregiaoUFRegNome[0];
            A15MesorregiaoUFID = BC000314_A15MesorregiaoUFID[0];
         }
         Gx_mode = sMode3;
      }

      protected void ScanKeyEnd033( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm033( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert033( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate033( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete033( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete033( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate033( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes033( )
      {
      }

      protected void send_integrity_lvl_hashes033( )
      {
      }

      protected void AddRow033( )
      {
         VarsToRow3( bccore_mesorregiao) ;
      }

      protected void ReadRow033( )
      {
         RowToVars3( bccore_mesorregiao, 1) ;
      }

      protected void InitializeNonKey033( )
      {
         A14MesorregiaoNome = "";
         A15MesorregiaoUFID = 0;
         A16MesorregiaoUFSigla = "";
         A17MesorregiaoUFNome = "";
         A18MesorregiaoUFSiglaNome = "";
         n18MesorregiaoUFSiglaNome = false;
         A19MesorregiaoUFRegID = 0;
         A20MesorregiaoUFRegSigla = "";
         n20MesorregiaoUFRegSigla = false;
         A21MesorregiaoUFRegNome = "";
         n21MesorregiaoUFRegNome = false;
         A22MesorregiaoUFRegSiglaNome = "";
         n22MesorregiaoUFRegSiglaNome = false;
         Z18MesorregiaoUFSiglaNome = "";
         Z22MesorregiaoUFRegSiglaNome = "";
         Z14MesorregiaoNome = "";
         Z15MesorregiaoUFID = 0;
      }

      protected void InitAll033( )
      {
         A13MesorregiaoID = 0;
         InitializeNonKey033( ) ;
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

      public void VarsToRow3( GeneXus.Programs.core.Sdtmesorregiao obj3 )
      {
         obj3.gxTpr_Mode = Gx_mode;
         obj3.gxTpr_Mesorregiaonome = A14MesorregiaoNome;
         obj3.gxTpr_Mesorregiaoufid = A15MesorregiaoUFID;
         obj3.gxTpr_Mesorregiaoufsigla = A16MesorregiaoUFSigla;
         obj3.gxTpr_Mesorregiaoufnome = A17MesorregiaoUFNome;
         obj3.gxTpr_Mesorregiaoufsiglanome = A18MesorregiaoUFSiglaNome;
         obj3.gxTpr_Mesorregiaoufregid = A19MesorregiaoUFRegID;
         obj3.gxTpr_Mesorregiaoufregsigla = A20MesorregiaoUFRegSigla;
         obj3.gxTpr_Mesorregiaoufregnome = A21MesorregiaoUFRegNome;
         obj3.gxTpr_Mesorregiaoufregsiglanome = A22MesorregiaoUFRegSiglaNome;
         obj3.gxTpr_Mesorregiaoid = A13MesorregiaoID;
         obj3.gxTpr_Mesorregiaoid_Z = Z13MesorregiaoID;
         obj3.gxTpr_Mesorregiaonome_Z = Z14MesorregiaoNome;
         obj3.gxTpr_Mesorregiaoufid_Z = Z15MesorregiaoUFID;
         obj3.gxTpr_Mesorregiaoufsigla_Z = Z16MesorregiaoUFSigla;
         obj3.gxTpr_Mesorregiaoufnome_Z = Z17MesorregiaoUFNome;
         obj3.gxTpr_Mesorregiaoufsiglanome_Z = Z18MesorregiaoUFSiglaNome;
         obj3.gxTpr_Mesorregiaoufregid_Z = Z19MesorregiaoUFRegID;
         obj3.gxTpr_Mesorregiaoufregsigla_Z = Z20MesorregiaoUFRegSigla;
         obj3.gxTpr_Mesorregiaoufregnome_Z = Z21MesorregiaoUFRegNome;
         obj3.gxTpr_Mesorregiaoufregsiglanome_Z = Z22MesorregiaoUFRegSiglaNome;
         obj3.gxTpr_Mesorregiaoufsiglanome_N = (short)(Convert.ToInt16(n18MesorregiaoUFSiglaNome));
         obj3.gxTpr_Mesorregiaoufregsigla_N = (short)(Convert.ToInt16(n20MesorregiaoUFRegSigla));
         obj3.gxTpr_Mesorregiaoufregnome_N = (short)(Convert.ToInt16(n21MesorregiaoUFRegNome));
         obj3.gxTpr_Mesorregiaoufregsiglanome_N = (short)(Convert.ToInt16(n22MesorregiaoUFRegSiglaNome));
         obj3.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow3( GeneXus.Programs.core.Sdtmesorregiao obj3 )
      {
         obj3.gxTpr_Mesorregiaoid = A13MesorregiaoID;
         return  ;
      }

      public void RowToVars3( GeneXus.Programs.core.Sdtmesorregiao obj3 ,
                              int forceLoad )
      {
         Gx_mode = obj3.gxTpr_Mode;
         A14MesorregiaoNome = obj3.gxTpr_Mesorregiaonome;
         A15MesorregiaoUFID = obj3.gxTpr_Mesorregiaoufid;
         A16MesorregiaoUFSigla = obj3.gxTpr_Mesorregiaoufsigla;
         A17MesorregiaoUFNome = obj3.gxTpr_Mesorregiaoufnome;
         A18MesorregiaoUFSiglaNome = obj3.gxTpr_Mesorregiaoufsiglanome;
         n18MesorregiaoUFSiglaNome = false;
         A19MesorregiaoUFRegID = obj3.gxTpr_Mesorregiaoufregid;
         A20MesorregiaoUFRegSigla = obj3.gxTpr_Mesorregiaoufregsigla;
         n20MesorregiaoUFRegSigla = false;
         A21MesorregiaoUFRegNome = obj3.gxTpr_Mesorregiaoufregnome;
         n21MesorregiaoUFRegNome = false;
         A22MesorregiaoUFRegSiglaNome = obj3.gxTpr_Mesorregiaoufregsiglanome;
         n22MesorregiaoUFRegSiglaNome = false;
         A13MesorregiaoID = obj3.gxTpr_Mesorregiaoid;
         Z13MesorregiaoID = obj3.gxTpr_Mesorregiaoid_Z;
         Z14MesorregiaoNome = obj3.gxTpr_Mesorregiaonome_Z;
         Z15MesorregiaoUFID = obj3.gxTpr_Mesorregiaoufid_Z;
         Z16MesorregiaoUFSigla = obj3.gxTpr_Mesorregiaoufsigla_Z;
         Z17MesorregiaoUFNome = obj3.gxTpr_Mesorregiaoufnome_Z;
         Z18MesorregiaoUFSiglaNome = obj3.gxTpr_Mesorregiaoufsiglanome_Z;
         Z19MesorregiaoUFRegID = obj3.gxTpr_Mesorregiaoufregid_Z;
         Z20MesorregiaoUFRegSigla = obj3.gxTpr_Mesorregiaoufregsigla_Z;
         Z21MesorregiaoUFRegNome = obj3.gxTpr_Mesorregiaoufregnome_Z;
         Z22MesorregiaoUFRegSiglaNome = obj3.gxTpr_Mesorregiaoufregsiglanome_Z;
         n18MesorregiaoUFSiglaNome = (bool)(Convert.ToBoolean(obj3.gxTpr_Mesorregiaoufsiglanome_N));
         n20MesorregiaoUFRegSigla = (bool)(Convert.ToBoolean(obj3.gxTpr_Mesorregiaoufregsigla_N));
         n21MesorregiaoUFRegNome = (bool)(Convert.ToBoolean(obj3.gxTpr_Mesorregiaoufregnome_N));
         n22MesorregiaoUFRegSiglaNome = (bool)(Convert.ToBoolean(obj3.gxTpr_Mesorregiaoufregsiglanome_N));
         Gx_mode = obj3.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A13MesorregiaoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey033( ) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13MesorregiaoID = A13MesorregiaoID;
         }
         ZM033( -5) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
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
         RowToVars3( bccore_mesorregiao, 0) ;
         ScanKeyStart033( ) ;
         if ( RcdFound3 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z13MesorregiaoID = A13MesorregiaoID;
         }
         ZM033( -5) ;
         OnLoadActions033( ) ;
         AddRow033( ) ;
         ScanKeyEnd033( ) ;
         if ( RcdFound3 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey033( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert033( ) ;
         }
         else
         {
            if ( RcdFound3 == 1 )
            {
               if ( A13MesorregiaoID != Z13MesorregiaoID )
               {
                  A13MesorregiaoID = Z13MesorregiaoID;
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
                  Update033( ) ;
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
                  if ( A13MesorregiaoID != Z13MesorregiaoID )
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
                        Insert033( ) ;
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
                        Insert033( ) ;
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
         RowToVars3( bccore_mesorregiao, 1) ;
         SaveImpl( ) ;
         VarsToRow3( bccore_mesorregiao) ;
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
         RowToVars3( bccore_mesorregiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
         AfterTrn( ) ;
         VarsToRow3( bccore_mesorregiao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow3( bccore_mesorregiao) ;
         }
         else
         {
            GeneXus.Programs.core.Sdtmesorregiao auxBC = new GeneXus.Programs.core.Sdtmesorregiao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A13MesorregiaoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_mesorregiao);
               auxBC.Save();
               bccore_mesorregiao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars3( bccore_mesorregiao, 1) ;
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
         RowToVars3( bccore_mesorregiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert033( ) ;
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
               VarsToRow3( bccore_mesorregiao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow3( bccore_mesorregiao) ;
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
         RowToVars3( bccore_mesorregiao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey033( ) ;
         if ( RcdFound3 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A13MesorregiaoID != Z13MesorregiaoID )
            {
               A13MesorregiaoID = Z13MesorregiaoID;
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
            if ( A13MesorregiaoID != Z13MesorregiaoID )
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
         context.RollbackDataStores("core.mesorregiao_bc",pr_default);
         VarsToRow3( bccore_mesorregiao) ;
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
         Gx_mode = bccore_mesorregiao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_mesorregiao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_mesorregiao )
         {
            bccore_mesorregiao = (GeneXus.Programs.core.Sdtmesorregiao)(sdt);
            if ( StringUtil.StrCmp(bccore_mesorregiao.gxTpr_Mode, "") == 0 )
            {
               bccore_mesorregiao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow3( bccore_mesorregiao) ;
            }
            else
            {
               RowToVars3( bccore_mesorregiao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_mesorregiao.gxTpr_Mode, "") == 0 )
            {
               bccore_mesorregiao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars3( bccore_mesorregiao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtmesorregiao mesorregiao_BC
      {
         get {
            return bccore_mesorregiao ;
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
            return "mesorregiao_Execute" ;
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
         pr_default.close(10);
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
         AV25Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z18MesorregiaoUFSiglaNome = "";
         A18MesorregiaoUFSiglaNome = "";
         Z22MesorregiaoUFRegSiglaNome = "";
         A22MesorregiaoUFRegSiglaNome = "";
         Z14MesorregiaoNome = "";
         A14MesorregiaoNome = "";
         Z16MesorregiaoUFSigla = "";
         A16MesorregiaoUFSigla = "";
         Z17MesorregiaoUFNome = "";
         A17MesorregiaoUFNome = "";
         Z20MesorregiaoUFRegSigla = "";
         A20MesorregiaoUFRegSigla = "";
         Z21MesorregiaoUFRegNome = "";
         A21MesorregiaoUFRegNome = "";
         BC00036_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         BC00036_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         BC00036_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         BC00036_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         BC00036_A13MesorregiaoID = new int[1] ;
         BC00036_A14MesorregiaoNome = new string[] {""} ;
         BC00036_A16MesorregiaoUFSigla = new string[] {""} ;
         BC00036_A17MesorregiaoUFNome = new string[] {""} ;
         BC00036_A19MesorregiaoUFRegID = new int[1] ;
         BC00036_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC00036_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC00036_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC00036_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC00036_A15MesorregiaoUFID = new int[1] ;
         BC00035_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC00035_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC00035_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC00035_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC00034_A16MesorregiaoUFSigla = new string[] {""} ;
         BC00034_A17MesorregiaoUFNome = new string[] {""} ;
         BC00034_A19MesorregiaoUFRegID = new int[1] ;
         BC00037_A13MesorregiaoID = new int[1] ;
         BC00033_A13MesorregiaoID = new int[1] ;
         BC00033_A14MesorregiaoNome = new string[] {""} ;
         BC00033_A15MesorregiaoUFID = new int[1] ;
         BC00033_A16MesorregiaoUFSigla = new string[] {""} ;
         BC00033_A17MesorregiaoUFNome = new string[] {""} ;
         BC00033_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         BC00033_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         BC00033_A19MesorregiaoUFRegID = new int[1] ;
         BC00033_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC00033_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC00033_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC00033_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC00033_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         BC00033_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         sMode3 = "";
         BC00032_A13MesorregiaoID = new int[1] ;
         BC00032_A14MesorregiaoNome = new string[] {""} ;
         BC00032_A15MesorregiaoUFID = new int[1] ;
         BC00032_A16MesorregiaoUFSigla = new string[] {""} ;
         BC00032_A17MesorregiaoUFNome = new string[] {""} ;
         BC00032_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         BC00032_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         BC00032_A19MesorregiaoUFRegID = new int[1] ;
         BC00032_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC00032_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC00032_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC00032_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC00032_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         BC00032_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         BC000311_A16MesorregiaoUFSigla = new string[] {""} ;
         BC000311_A17MesorregiaoUFNome = new string[] {""} ;
         BC000311_A19MesorregiaoUFRegID = new int[1] ;
         BC000312_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC000312_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC000312_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC000312_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC000313_A23MicrorregiaoID = new int[1] ;
         BC000314_A18MesorregiaoUFSiglaNome = new string[] {""} ;
         BC000314_n18MesorregiaoUFSiglaNome = new bool[] {false} ;
         BC000314_A22MesorregiaoUFRegSiglaNome = new string[] {""} ;
         BC000314_n22MesorregiaoUFRegSiglaNome = new bool[] {false} ;
         BC000314_A13MesorregiaoID = new int[1] ;
         BC000314_A14MesorregiaoNome = new string[] {""} ;
         BC000314_A16MesorregiaoUFSigla = new string[] {""} ;
         BC000314_A17MesorregiaoUFNome = new string[] {""} ;
         BC000314_A19MesorregiaoUFRegID = new int[1] ;
         BC000314_A20MesorregiaoUFRegSigla = new string[] {""} ;
         BC000314_n20MesorregiaoUFRegSigla = new bool[] {false} ;
         BC000314_A21MesorregiaoUFRegNome = new string[] {""} ;
         BC000314_n21MesorregiaoUFRegNome = new bool[] {false} ;
         BC000314_A15MesorregiaoUFID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00032_A13MesorregiaoID, BC00032_A14MesorregiaoNome, BC00032_A15MesorregiaoUFID, BC00032_A16MesorregiaoUFSigla, BC00032_A17MesorregiaoUFNome, BC00032_A18MesorregiaoUFSiglaNome, BC00032_n18MesorregiaoUFSiglaNome, BC00032_A19MesorregiaoUFRegID, BC00032_A20MesorregiaoUFRegSigla, BC00032_n20MesorregiaoUFRegSigla,
               BC00032_A21MesorregiaoUFRegNome, BC00032_n21MesorregiaoUFRegNome, BC00032_A22MesorregiaoUFRegSiglaNome, BC00032_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               BC00033_A13MesorregiaoID, BC00033_A14MesorregiaoNome, BC00033_A15MesorregiaoUFID, BC00033_A16MesorregiaoUFSigla, BC00033_A17MesorregiaoUFNome, BC00033_A18MesorregiaoUFSiglaNome, BC00033_n18MesorregiaoUFSiglaNome, BC00033_A19MesorregiaoUFRegID, BC00033_A20MesorregiaoUFRegSigla, BC00033_n20MesorregiaoUFRegSigla,
               BC00033_A21MesorregiaoUFRegNome, BC00033_n21MesorregiaoUFRegNome, BC00033_A22MesorregiaoUFRegSiglaNome, BC00033_n22MesorregiaoUFRegSiglaNome
               }
               , new Object[] {
               BC00034_A16MesorregiaoUFSigla, BC00034_A17MesorregiaoUFNome, BC00034_A19MesorregiaoUFRegID
               }
               , new Object[] {
               BC00035_A20MesorregiaoUFRegSigla, BC00035_A21MesorregiaoUFRegNome
               }
               , new Object[] {
               BC00036_A18MesorregiaoUFSiglaNome, BC00036_n18MesorregiaoUFSiglaNome, BC00036_A22MesorregiaoUFRegSiglaNome, BC00036_n22MesorregiaoUFRegSiglaNome, BC00036_A13MesorregiaoID, BC00036_A14MesorregiaoNome, BC00036_A16MesorregiaoUFSigla, BC00036_A17MesorregiaoUFNome, BC00036_A19MesorregiaoUFRegID, BC00036_A20MesorregiaoUFRegSigla,
               BC00036_n20MesorregiaoUFRegSigla, BC00036_A21MesorregiaoUFRegNome, BC00036_n21MesorregiaoUFRegNome, BC00036_A15MesorregiaoUFID
               }
               , new Object[] {
               BC00037_A13MesorregiaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000311_A16MesorregiaoUFSigla, BC000311_A17MesorregiaoUFNome, BC000311_A19MesorregiaoUFRegID
               }
               , new Object[] {
               BC000312_A20MesorregiaoUFRegSigla, BC000312_A21MesorregiaoUFRegNome
               }
               , new Object[] {
               BC000313_A23MicrorregiaoID
               }
               , new Object[] {
               BC000314_A18MesorregiaoUFSiglaNome, BC000314_n18MesorregiaoUFSiglaNome, BC000314_A22MesorregiaoUFRegSiglaNome, BC000314_n22MesorregiaoUFRegSiglaNome, BC000314_A13MesorregiaoID, BC000314_A14MesorregiaoNome, BC000314_A16MesorregiaoUFSigla, BC000314_A17MesorregiaoUFNome, BC000314_A19MesorregiaoUFRegID, BC000314_A20MesorregiaoUFRegSigla,
               BC000314_n20MesorregiaoUFRegSigla, BC000314_A21MesorregiaoUFRegNome, BC000314_n21MesorregiaoUFRegNome, BC000314_A15MesorregiaoUFID
               }
            }
         );
         AV25Pgmname = "core.mesorregiao_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12032 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound3 ;
      private short nIsDirty_3 ;
      private int trnEnded ;
      private int Z13MesorregiaoID ;
      private int A13MesorregiaoID ;
      private int AV26GXV1 ;
      private int AV13Insert_MesorregiaoUFID ;
      private int Z15MesorregiaoUFID ;
      private int A15MesorregiaoUFID ;
      private int Z19MesorregiaoUFRegID ;
      private int A19MesorregiaoUFRegID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode3 ;
      private bool returnInSub ;
      private bool n18MesorregiaoUFSiglaNome ;
      private bool n22MesorregiaoUFRegSiglaNome ;
      private bool n20MesorregiaoUFRegSigla ;
      private bool n21MesorregiaoUFRegNome ;
      private bool mustCommit ;
      private string Z18MesorregiaoUFSiglaNome ;
      private string A18MesorregiaoUFSiglaNome ;
      private string Z22MesorregiaoUFRegSiglaNome ;
      private string A22MesorregiaoUFRegSiglaNome ;
      private string Z14MesorregiaoNome ;
      private string A14MesorregiaoNome ;
      private string Z16MesorregiaoUFSigla ;
      private string A16MesorregiaoUFSigla ;
      private string Z17MesorregiaoUFNome ;
      private string A17MesorregiaoUFNome ;
      private string Z20MesorregiaoUFRegSigla ;
      private string A20MesorregiaoUFRegSigla ;
      private string Z21MesorregiaoUFRegNome ;
      private string A21MesorregiaoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.Sdtmesorregiao bccore_mesorregiao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00036_A18MesorregiaoUFSiglaNome ;
      private bool[] BC00036_n18MesorregiaoUFSiglaNome ;
      private string[] BC00036_A22MesorregiaoUFRegSiglaNome ;
      private bool[] BC00036_n22MesorregiaoUFRegSiglaNome ;
      private int[] BC00036_A13MesorregiaoID ;
      private string[] BC00036_A14MesorregiaoNome ;
      private string[] BC00036_A16MesorregiaoUFSigla ;
      private string[] BC00036_A17MesorregiaoUFNome ;
      private int[] BC00036_A19MesorregiaoUFRegID ;
      private string[] BC00036_A20MesorregiaoUFRegSigla ;
      private bool[] BC00036_n20MesorregiaoUFRegSigla ;
      private string[] BC00036_A21MesorregiaoUFRegNome ;
      private bool[] BC00036_n21MesorregiaoUFRegNome ;
      private int[] BC00036_A15MesorregiaoUFID ;
      private string[] BC00035_A20MesorregiaoUFRegSigla ;
      private bool[] BC00035_n20MesorregiaoUFRegSigla ;
      private string[] BC00035_A21MesorregiaoUFRegNome ;
      private bool[] BC00035_n21MesorregiaoUFRegNome ;
      private string[] BC00034_A16MesorregiaoUFSigla ;
      private string[] BC00034_A17MesorregiaoUFNome ;
      private int[] BC00034_A19MesorregiaoUFRegID ;
      private int[] BC00037_A13MesorregiaoID ;
      private int[] BC00033_A13MesorregiaoID ;
      private string[] BC00033_A14MesorregiaoNome ;
      private int[] BC00033_A15MesorregiaoUFID ;
      private string[] BC00033_A16MesorregiaoUFSigla ;
      private string[] BC00033_A17MesorregiaoUFNome ;
      private string[] BC00033_A18MesorregiaoUFSiglaNome ;
      private bool[] BC00033_n18MesorregiaoUFSiglaNome ;
      private int[] BC00033_A19MesorregiaoUFRegID ;
      private string[] BC00033_A20MesorregiaoUFRegSigla ;
      private bool[] BC00033_n20MesorregiaoUFRegSigla ;
      private string[] BC00033_A21MesorregiaoUFRegNome ;
      private bool[] BC00033_n21MesorregiaoUFRegNome ;
      private string[] BC00033_A22MesorregiaoUFRegSiglaNome ;
      private bool[] BC00033_n22MesorregiaoUFRegSiglaNome ;
      private int[] BC00032_A13MesorregiaoID ;
      private string[] BC00032_A14MesorregiaoNome ;
      private int[] BC00032_A15MesorregiaoUFID ;
      private string[] BC00032_A16MesorregiaoUFSigla ;
      private string[] BC00032_A17MesorregiaoUFNome ;
      private string[] BC00032_A18MesorregiaoUFSiglaNome ;
      private bool[] BC00032_n18MesorregiaoUFSiglaNome ;
      private int[] BC00032_A19MesorregiaoUFRegID ;
      private string[] BC00032_A20MesorregiaoUFRegSigla ;
      private bool[] BC00032_n20MesorregiaoUFRegSigla ;
      private string[] BC00032_A21MesorregiaoUFRegNome ;
      private bool[] BC00032_n21MesorregiaoUFRegNome ;
      private string[] BC00032_A22MesorregiaoUFRegSiglaNome ;
      private bool[] BC00032_n22MesorregiaoUFRegSiglaNome ;
      private string[] BC000311_A16MesorregiaoUFSigla ;
      private string[] BC000311_A17MesorregiaoUFNome ;
      private int[] BC000311_A19MesorregiaoUFRegID ;
      private string[] BC000312_A20MesorregiaoUFRegSigla ;
      private bool[] BC000312_n20MesorregiaoUFRegSigla ;
      private string[] BC000312_A21MesorregiaoUFRegNome ;
      private bool[] BC000312_n21MesorregiaoUFRegNome ;
      private int[] BC000313_A23MicrorregiaoID ;
      private string[] BC000314_A18MesorregiaoUFSiglaNome ;
      private bool[] BC000314_n18MesorregiaoUFSiglaNome ;
      private string[] BC000314_A22MesorregiaoUFRegSiglaNome ;
      private bool[] BC000314_n22MesorregiaoUFRegSiglaNome ;
      private int[] BC000314_A13MesorregiaoID ;
      private string[] BC000314_A14MesorregiaoNome ;
      private string[] BC000314_A16MesorregiaoUFSigla ;
      private string[] BC000314_A17MesorregiaoUFNome ;
      private int[] BC000314_A19MesorregiaoUFRegID ;
      private string[] BC000314_A20MesorregiaoUFRegSigla ;
      private bool[] BC000314_n20MesorregiaoUFRegSigla ;
      private string[] BC000314_A21MesorregiaoUFRegNome ;
      private bool[] BC000314_n21MesorregiaoUFRegNome ;
      private int[] BC000314_A15MesorregiaoUFID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class mesorregiao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class mesorregiao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00036;
        prmBC00036 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00034;
        prmBC00034 = new Object[] {
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmBC00035;
        prmBC00035 = new Object[] {
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0)
        };
        Object[] prmBC00037;
        prmBC00037 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00033;
        prmBC00033 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00032;
        prmBC00032 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00038;
        prmBC00038 = new Object[] {
        new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
        new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmBC00039;
        prmBC00039 = new Object[] {
        new ParDef("MesorregiaoUFSigla",GXType.VarChar,2,0) ,
        new ParDef("MesorregiaoUFNome",GXType.VarChar,50,0) ,
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MesorregiaoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MesorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0) ,
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000310;
        prmBC000310 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000311;
        prmBC000311 = new Object[] {
        new ParDef("MesorregiaoUFID",GXType.Int32,9,0)
        };
        Object[] prmBC000312;
        prmBC000312 = new Object[] {
        new ParDef("MesorregiaoUFRegID",GXType.Int32,9,0)
        };
        Object[] prmBC000313;
        prmBC000313 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000314;
        prmBC000314 = new Object[] {
        new ParDef("MesorregiaoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00032", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID  FOR UPDATE OF tbibge_mesorregiao",true, GxErrorMask.GX_NOMASK, false, this,prmBC00032,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00033", "SELECT MesorregiaoID, MesorregiaoNome, MesorregiaoUFID, MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFRegSiglaNome FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00033,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00034", "SELECT UFSigla AS MesorregiaoUFSigla, UFNome AS MesorregiaoUFNome, UFRegID AS MesorregiaoUFRegID FROM tbibge_uf WHERE UFID = :MesorregiaoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00034,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00035", "SELECT RegiaoSigla AS MesorregiaoUFRegSigla, RegiaoNome AS MesorregiaoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MesorregiaoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00035,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00036", "SELECT TM1.MesorregiaoUFSiglaNome AS MesorregiaoUFSiglaNome, TM1.MesorregiaoUFRegSiglaNome AS MesorregiaoUFRegSiglaNome, TM1.MesorregiaoID, TM1.MesorregiaoNome, TM1.MesorregiaoUFSigla AS MesorregiaoUFSigla, TM1.MesorregiaoUFNome AS MesorregiaoUFNome, TM1.MesorregiaoUFRegID AS MesorregiaoUFRegID, TM1.MesorregiaoUFRegSigla AS MesorregiaoUFRegSigla, TM1.MesorregiaoUFRegNome AS MesorregiaoUFRegNome, TM1.MesorregiaoUFID AS MesorregiaoUFID FROM (tbibge_mesorregiao TM1 INNER JOIN tbibge_uf T2 ON T2.UFID = TM1.MesorregiaoUFID) WHERE TM1.MesorregiaoID = :MesorregiaoID ORDER BY TM1.MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00036,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00037", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00037,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00038", "SAVEPOINT gxupdate;INSERT INTO tbibge_mesorregiao(MesorregiaoUFSigla, MesorregiaoUFNome, MesorregiaoUFRegID, MesorregiaoUFRegSigla, MesorregiaoUFRegNome, MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome, MesorregiaoID, MesorregiaoNome, MesorregiaoUFID) VALUES(:MesorregiaoUFSigla, :MesorregiaoUFNome, :MesorregiaoUFRegID, :MesorregiaoUFRegSigla, :MesorregiaoUFRegNome, :MesorregiaoUFSiglaNome, :MesorregiaoUFRegSiglaNome, :MesorregiaoID, :MesorregiaoNome, :MesorregiaoUFID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00038)
           ,new CursorDef("BC00039", "SAVEPOINT gxupdate;UPDATE tbibge_mesorregiao SET MesorregiaoUFSigla=:MesorregiaoUFSigla, MesorregiaoUFNome=:MesorregiaoUFNome, MesorregiaoUFRegID=:MesorregiaoUFRegID, MesorregiaoUFRegSigla=:MesorregiaoUFRegSigla, MesorregiaoUFRegNome=:MesorregiaoUFRegNome, MesorregiaoUFSiglaNome=:MesorregiaoUFSiglaNome, MesorregiaoUFRegSiglaNome=:MesorregiaoUFRegSiglaNome, MesorregiaoNome=:MesorregiaoNome, MesorregiaoUFID=:MesorregiaoUFID  WHERE MesorregiaoID = :MesorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00039)
           ,new CursorDef("BC000310", "SAVEPOINT gxupdate;DELETE FROM tbibge_mesorregiao  WHERE MesorregiaoID = :MesorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000310)
           ,new CursorDef("BC000311", "SELECT UFSigla AS MesorregiaoUFSigla, UFNome AS MesorregiaoUFNome, UFRegID AS MesorregiaoUFRegID FROM tbibge_uf WHERE UFID = :MesorregiaoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000311,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000312", "SELECT RegiaoSigla AS MesorregiaoUFRegSigla, RegiaoNome AS MesorregiaoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MesorregiaoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000312,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000313", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE MicrorregiaoMesoID = :MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000313,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000314", "SELECT TM1.MesorregiaoUFSiglaNome AS MesorregiaoUFSiglaNome, TM1.MesorregiaoUFRegSiglaNome AS MesorregiaoUFRegSiglaNome, TM1.MesorregiaoID, TM1.MesorregiaoNome, TM1.MesorregiaoUFSigla AS MesorregiaoUFSigla, TM1.MesorregiaoUFNome AS MesorregiaoUFNome, TM1.MesorregiaoUFRegID AS MesorregiaoUFRegID, TM1.MesorregiaoUFRegSigla AS MesorregiaoUFRegSigla, TM1.MesorregiaoUFRegNome AS MesorregiaoUFRegNome, TM1.MesorregiaoUFID AS MesorregiaoUFID FROM (tbibge_mesorregiao TM1 INNER JOIN tbibge_uf T2 ON T2.UFID = TM1.MesorregiaoUFID) WHERE TM1.MesorregiaoID = :MesorregiaoID ORDER BY TM1.MesorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000314,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((int[]) buf[7])[0] = rslt.getInt(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((string[]) buf[10])[0] = rslt.getVarchar(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getVarchar(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((int[]) buf[8])[0] = rslt.getInt(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((int[]) buf[13])[0] = rslt.getInt(10);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((string[]) buf[7])[0] = rslt.getVarchar(6);
              ((int[]) buf[8])[0] = rslt.getInt(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((string[]) buf[11])[0] = rslt.getVarchar(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((int[]) buf[13])[0] = rslt.getInt(10);
              return;
     }
  }

}

}
