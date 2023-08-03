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
   public class uf_bc : GxSilentTrn, IGxSilentTrn
   {
      public uf_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public uf_bc( IGxContext context )
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
         ReadRow022( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey022( ) ;
         standaloneModal( ) ;
         AddRow022( ) ;
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
            E11022 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z4UFID = A4UFID;
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

      protected void CONFIRM_020( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls022( ) ;
            }
            else
            {
               CheckExtendedTable022( ) ;
               if ( AnyError == 0 )
               {
                  ZM022( 7) ;
               }
               CloseExtendedTableCursors022( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12022( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "UFRegID") == 0 )
               {
                  AV13Insert_UFRegID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E11022( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM022( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z12UFSiglaNome = A12UFSiglaNome;
            Z11UFRegSiglaNome = A11UFRegSiglaNome;
            Z5UFSigla = A5UFSigla;
            Z6UFNome = A6UFNome;
            Z8UFRegID = A8UFRegID;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z9UFRegSigla = A9UFRegSigla;
            Z10UFRegNome = A10UFRegNome;
         }
         if ( GX_JID == -5 )
         {
            Z12UFSiglaNome = A12UFSiglaNome;
            Z11UFRegSiglaNome = A11UFRegSiglaNome;
            Z4UFID = A4UFID;
            Z5UFSigla = A5UFSigla;
            Z6UFNome = A6UFNome;
            Z9UFRegSigla = A9UFRegSigla;
            Z10UFRegNome = A10UFRegNome;
            Z8UFRegID = A8UFRegID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.uf_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load022( )
      {
         /* Using cursor BC00025 */
         pr_default.execute(3, new Object[] {A4UFID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound2 = 1;
            A12UFSiglaNome = BC00025_A12UFSiglaNome[0];
            A11UFRegSiglaNome = BC00025_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = BC00025_n11UFRegSiglaNome[0];
            A5UFSigla = BC00025_A5UFSigla[0];
            A6UFNome = BC00025_A6UFNome[0];
            A9UFRegSigla = BC00025_A9UFRegSigla[0];
            A10UFRegNome = BC00025_A10UFRegNome[0];
            A8UFRegID = BC00025_A8UFRegID[0];
            ZM022( -5) ;
         }
         pr_default.close(3);
         OnLoadActions022( ) ;
      }

      protected void OnLoadActions022( )
      {
         A12UFSiglaNome = StringUtil.Trim( A5UFSigla) + " - " + StringUtil.Trim( A6UFNome);
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A8UFRegID});
         A9UFRegSigla = BC00024_A9UFRegSigla[0];
         A10UFRegNome = BC00024_A10UFRegNome[0];
         pr_default.close(2);
         A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
         n11UFRegSiglaNome = false;
      }

      protected void CheckExtendedTable022( )
      {
         nIsDirty_2 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00026 */
         pr_default.execute(4, new Object[] {A5UFSigla, A4UFID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         nIsDirty_2 = 1;
         A12UFSiglaNome = StringUtil.Trim( A5UFSigla) + " - " + StringUtil.Trim( A6UFNome);
         /* Using cursor BC00024 */
         pr_default.execute(2, new Object[] {A8UFRegID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Regiao -> UF'.", "ForeignKeyNotFound", 1, "UFREGID");
            AnyError = 1;
         }
         A9UFRegSigla = BC00024_A9UFRegSigla[0];
         A10UFRegNome = BC00024_A10UFRegNome[0];
         pr_default.close(2);
         nIsDirty_2 = 1;
         A11UFRegSiglaNome = StringUtil.Trim( A9UFRegSigla) + " - " + StringUtil.Trim( A10UFRegNome);
         n11UFRegSiglaNome = false;
      }

      protected void CloseExtendedTableCursors022( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey022( )
      {
         /* Using cursor BC00027 */
         pr_default.execute(5, new Object[] {A4UFID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound2 = 1;
         }
         else
         {
            RcdFound2 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00023 */
         pr_default.execute(1, new Object[] {A4UFID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM022( 5) ;
            RcdFound2 = 1;
            A12UFSiglaNome = BC00023_A12UFSiglaNome[0];
            A4UFID = BC00023_A4UFID[0];
            A5UFSigla = BC00023_A5UFSigla[0];
            A6UFNome = BC00023_A6UFNome[0];
            A8UFRegID = BC00023_A8UFRegID[0];
            A11UFRegSiglaNome = BC00023_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = BC00023_n11UFRegSiglaNome[0];
            Z4UFID = A4UFID;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load022( ) ;
            if ( AnyError == 1 )
            {
               RcdFound2 = 0;
               InitializeNonKey022( ) ;
            }
            Gx_mode = sMode2;
         }
         else
         {
            RcdFound2 = 0;
            InitializeNonKey022( ) ;
            sMode2 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode2;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey022( ) ;
         if ( RcdFound2 == 0 )
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
         CONFIRM_020( ) ;
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

      protected void CheckOptimisticConcurrency022( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00022 */
            pr_default.execute(0, new Object[] {A4UFID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_uf"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z12UFSiglaNome, BC00022_A12UFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z11UFRegSiglaNome, BC00022_A11UFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z5UFSigla, BC00022_A5UFSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z6UFNome, BC00022_A6UFNome[0]) != 0 ) || ( Z8UFRegID != BC00022_A8UFRegID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_uf"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM022( 0) ;
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00028 */
                     pr_default.execute(6, new Object[] {A9UFRegSigla, A10UFRegNome, A12UFSiglaNome, n11UFRegSiglaNome, A11UFRegSiglaNome, A4UFID, A5UFSigla, A6UFNome, A8UFRegID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
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
               Load022( ) ;
            }
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void Update022( )
      {
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable022( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm022( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate022( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00029 */
                     pr_default.execute(7, new Object[] {A9UFRegSigla, A10UFRegNome, A12UFSiglaNome, n11UFRegSiglaNome, A11UFRegSiglaNome, A5UFSigla, A6UFNome, A8UFRegID, A4UFID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_uf"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate022( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_ufupdateredundancy(context ).execute( ref  A4UFID) ;
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
            EndLevel022( ) ;
         }
         CloseExtendedTableCursors022( ) ;
      }

      protected void DeferredUpdate022( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate022( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency022( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls022( ) ;
            AfterConfirm022( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete022( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000210 */
                  pr_default.execute(8, new Object[] {A4UFID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_uf");
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
         sMode2 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel022( ) ;
         Gx_mode = sMode2;
      }

      protected void OnDeleteControls022( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000211 */
            pr_default.execute(9, new Object[] {A8UFRegID});
            A9UFRegSigla = BC000211_A9UFRegSigla[0];
            A10UFRegNome = BC000211_A10UFRegNome[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000212 */
            pr_default.execute(10, new Object[] {A4UFID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"tbibge_mesorregiao"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel022( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete022( ) ;
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

      public void ScanKeyStart022( )
      {
         /* Scan By routine */
         /* Using cursor BC000213 */
         pr_default.execute(11, new Object[] {A4UFID});
         RcdFound2 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A12UFSiglaNome = BC000213_A12UFSiglaNome[0];
            A11UFRegSiglaNome = BC000213_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = BC000213_n11UFRegSiglaNome[0];
            A4UFID = BC000213_A4UFID[0];
            A5UFSigla = BC000213_A5UFSigla[0];
            A6UFNome = BC000213_A6UFNome[0];
            A9UFRegSigla = BC000213_A9UFRegSigla[0];
            A10UFRegNome = BC000213_A10UFRegNome[0];
            A8UFRegID = BC000213_A8UFRegID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext022( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound2 = 0;
         ScanKeyLoad022( ) ;
      }

      protected void ScanKeyLoad022( )
      {
         sMode2 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound2 = 1;
            A12UFSiglaNome = BC000213_A12UFSiglaNome[0];
            A11UFRegSiglaNome = BC000213_A11UFRegSiglaNome[0];
            n11UFRegSiglaNome = BC000213_n11UFRegSiglaNome[0];
            A4UFID = BC000213_A4UFID[0];
            A5UFSigla = BC000213_A5UFSigla[0];
            A6UFNome = BC000213_A6UFNome[0];
            A9UFRegSigla = BC000213_A9UFRegSigla[0];
            A10UFRegNome = BC000213_A10UFRegNome[0];
            A8UFRegID = BC000213_A8UFRegID[0];
         }
         Gx_mode = sMode2;
      }

      protected void ScanKeyEnd022( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm022( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert022( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate022( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete022( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete022( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate022( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes022( )
      {
      }

      protected void send_integrity_lvl_hashes022( )
      {
      }

      protected void AddRow022( )
      {
         VarsToRow2( bccore_uf) ;
      }

      protected void ReadRow022( )
      {
         RowToVars2( bccore_uf, 1) ;
      }

      protected void InitializeNonKey022( )
      {
         A12UFSiglaNome = "";
         A5UFSigla = "";
         A6UFNome = "";
         A8UFRegID = 0;
         A9UFRegSigla = "";
         A10UFRegNome = "";
         A11UFRegSiglaNome = "";
         n11UFRegSiglaNome = false;
         Z12UFSiglaNome = "";
         Z11UFRegSiglaNome = "";
         Z5UFSigla = "";
         Z6UFNome = "";
         Z8UFRegID = 0;
      }

      protected void InitAll022( )
      {
         A4UFID = 0;
         InitializeNonKey022( ) ;
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

      public void VarsToRow2( GeneXus.Programs.core.Sdtuf obj2 )
      {
         obj2.gxTpr_Mode = Gx_mode;
         obj2.gxTpr_Ufsiglanome = A12UFSiglaNome;
         obj2.gxTpr_Ufsigla = A5UFSigla;
         obj2.gxTpr_Ufnome = A6UFNome;
         obj2.gxTpr_Ufregid = A8UFRegID;
         obj2.gxTpr_Ufregsigla = A9UFRegSigla;
         obj2.gxTpr_Ufregnome = A10UFRegNome;
         obj2.gxTpr_Ufregsiglanome = A11UFRegSiglaNome;
         obj2.gxTpr_Ufid = A4UFID;
         obj2.gxTpr_Ufid_Z = Z4UFID;
         obj2.gxTpr_Ufsigla_Z = Z5UFSigla;
         obj2.gxTpr_Ufnome_Z = Z6UFNome;
         obj2.gxTpr_Ufsiglanome_Z = Z12UFSiglaNome;
         obj2.gxTpr_Ufregid_Z = Z8UFRegID;
         obj2.gxTpr_Ufregsigla_Z = Z9UFRegSigla;
         obj2.gxTpr_Ufregnome_Z = Z10UFRegNome;
         obj2.gxTpr_Ufregsiglanome_Z = Z11UFRegSiglaNome;
         obj2.gxTpr_Ufregsiglanome_N = (short)(Convert.ToInt16(n11UFRegSiglaNome));
         obj2.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow2( GeneXus.Programs.core.Sdtuf obj2 )
      {
         obj2.gxTpr_Ufid = A4UFID;
         return  ;
      }

      public void RowToVars2( GeneXus.Programs.core.Sdtuf obj2 ,
                              int forceLoad )
      {
         Gx_mode = obj2.gxTpr_Mode;
         A12UFSiglaNome = obj2.gxTpr_Ufsiglanome;
         A5UFSigla = obj2.gxTpr_Ufsigla;
         A6UFNome = obj2.gxTpr_Ufnome;
         A8UFRegID = obj2.gxTpr_Ufregid;
         A9UFRegSigla = obj2.gxTpr_Ufregsigla;
         A10UFRegNome = obj2.gxTpr_Ufregnome;
         A11UFRegSiglaNome = obj2.gxTpr_Ufregsiglanome;
         n11UFRegSiglaNome = false;
         A4UFID = obj2.gxTpr_Ufid;
         Z4UFID = obj2.gxTpr_Ufid_Z;
         Z5UFSigla = obj2.gxTpr_Ufsigla_Z;
         Z6UFNome = obj2.gxTpr_Ufnome_Z;
         Z12UFSiglaNome = obj2.gxTpr_Ufsiglanome_Z;
         Z8UFRegID = obj2.gxTpr_Ufregid_Z;
         Z9UFRegSigla = obj2.gxTpr_Ufregsigla_Z;
         Z10UFRegNome = obj2.gxTpr_Ufregnome_Z;
         Z11UFRegSiglaNome = obj2.gxTpr_Ufregsiglanome_Z;
         n11UFRegSiglaNome = (bool)(Convert.ToBoolean(obj2.gxTpr_Ufregsiglanome_N));
         Gx_mode = obj2.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A4UFID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey022( ) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4UFID = A4UFID;
         }
         ZM022( -5) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
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
         RowToVars2( bccore_uf, 0) ;
         ScanKeyStart022( ) ;
         if ( RcdFound2 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z4UFID = A4UFID;
         }
         ZM022( -5) ;
         OnLoadActions022( ) ;
         AddRow022( ) ;
         ScanKeyEnd022( ) ;
         if ( RcdFound2 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey022( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert022( ) ;
         }
         else
         {
            if ( RcdFound2 == 1 )
            {
               if ( A4UFID != Z4UFID )
               {
                  A4UFID = Z4UFID;
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
                  Update022( ) ;
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
                  if ( A4UFID != Z4UFID )
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
                        Insert022( ) ;
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
                        Insert022( ) ;
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
         RowToVars2( bccore_uf, 1) ;
         SaveImpl( ) ;
         VarsToRow2( bccore_uf) ;
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
         RowToVars2( bccore_uf, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
         AfterTrn( ) ;
         VarsToRow2( bccore_uf) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow2( bccore_uf) ;
         }
         else
         {
            GeneXus.Programs.core.Sdtuf auxBC = new GeneXus.Programs.core.Sdtuf(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A4UFID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_uf);
               auxBC.Save();
               bccore_uf.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars2( bccore_uf, 1) ;
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
         RowToVars2( bccore_uf, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert022( ) ;
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
               VarsToRow2( bccore_uf) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow2( bccore_uf) ;
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
         RowToVars2( bccore_uf, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey022( ) ;
         if ( RcdFound2 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A4UFID != Z4UFID )
            {
               A4UFID = Z4UFID;
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
            if ( A4UFID != Z4UFID )
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
         context.RollbackDataStores("core.uf_bc",pr_default);
         VarsToRow2( bccore_uf) ;
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
         Gx_mode = bccore_uf.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_uf.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_uf )
         {
            bccore_uf = (GeneXus.Programs.core.Sdtuf)(sdt);
            if ( StringUtil.StrCmp(bccore_uf.gxTpr_Mode, "") == 0 )
            {
               bccore_uf.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow2( bccore_uf) ;
            }
            else
            {
               RowToVars2( bccore_uf, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_uf.gxTpr_Mode, "") == 0 )
            {
               bccore_uf.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars2( bccore_uf, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtuf uf_BC
      {
         get {
            return bccore_uf ;
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
            return "uf_Execute" ;
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV25Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z12UFSiglaNome = "";
         A12UFSiglaNome = "";
         Z11UFRegSiglaNome = "";
         A11UFRegSiglaNome = "";
         Z5UFSigla = "";
         A5UFSigla = "";
         Z6UFNome = "";
         A6UFNome = "";
         Z9UFRegSigla = "";
         A9UFRegSigla = "";
         Z10UFRegNome = "";
         A10UFRegNome = "";
         BC00025_A12UFSiglaNome = new string[] {""} ;
         BC00025_A11UFRegSiglaNome = new string[] {""} ;
         BC00025_n11UFRegSiglaNome = new bool[] {false} ;
         BC00025_A4UFID = new int[1] ;
         BC00025_A5UFSigla = new string[] {""} ;
         BC00025_A6UFNome = new string[] {""} ;
         BC00025_A9UFRegSigla = new string[] {""} ;
         BC00025_A10UFRegNome = new string[] {""} ;
         BC00025_A8UFRegID = new int[1] ;
         BC00024_A9UFRegSigla = new string[] {""} ;
         BC00024_A10UFRegNome = new string[] {""} ;
         BC00026_A5UFSigla = new string[] {""} ;
         BC00027_A4UFID = new int[1] ;
         BC00023_A12UFSiglaNome = new string[] {""} ;
         BC00023_A4UFID = new int[1] ;
         BC00023_A5UFSigla = new string[] {""} ;
         BC00023_A6UFNome = new string[] {""} ;
         BC00023_A8UFRegID = new int[1] ;
         BC00023_A9UFRegSigla = new string[] {""} ;
         BC00023_A10UFRegNome = new string[] {""} ;
         BC00023_A11UFRegSiglaNome = new string[] {""} ;
         BC00023_n11UFRegSiglaNome = new bool[] {false} ;
         sMode2 = "";
         BC00022_A12UFSiglaNome = new string[] {""} ;
         BC00022_A4UFID = new int[1] ;
         BC00022_A5UFSigla = new string[] {""} ;
         BC00022_A6UFNome = new string[] {""} ;
         BC00022_A8UFRegID = new int[1] ;
         BC00022_A9UFRegSigla = new string[] {""} ;
         BC00022_A10UFRegNome = new string[] {""} ;
         BC00022_A11UFRegSiglaNome = new string[] {""} ;
         BC00022_n11UFRegSiglaNome = new bool[] {false} ;
         BC000211_A9UFRegSigla = new string[] {""} ;
         BC000211_A10UFRegNome = new string[] {""} ;
         BC000212_A13MesorregiaoID = new int[1] ;
         BC000213_A12UFSiglaNome = new string[] {""} ;
         BC000213_A11UFRegSiglaNome = new string[] {""} ;
         BC000213_n11UFRegSiglaNome = new bool[] {false} ;
         BC000213_A4UFID = new int[1] ;
         BC000213_A5UFSigla = new string[] {""} ;
         BC000213_A6UFNome = new string[] {""} ;
         BC000213_A9UFRegSigla = new string[] {""} ;
         BC000213_A10UFRegNome = new string[] {""} ;
         BC000213_A8UFRegID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.uf_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.uf_bc__default(),
            new Object[][] {
                new Object[] {
               BC00022_A12UFSiglaNome, BC00022_A4UFID, BC00022_A5UFSigla, BC00022_A6UFNome, BC00022_A8UFRegID, BC00022_A9UFRegSigla, BC00022_A10UFRegNome, BC00022_A11UFRegSiglaNome, BC00022_n11UFRegSiglaNome
               }
               , new Object[] {
               BC00023_A12UFSiglaNome, BC00023_A4UFID, BC00023_A5UFSigla, BC00023_A6UFNome, BC00023_A8UFRegID, BC00023_A9UFRegSigla, BC00023_A10UFRegNome, BC00023_A11UFRegSiglaNome, BC00023_n11UFRegSiglaNome
               }
               , new Object[] {
               BC00024_A9UFRegSigla, BC00024_A10UFRegNome
               }
               , new Object[] {
               BC00025_A12UFSiglaNome, BC00025_A11UFRegSiglaNome, BC00025_n11UFRegSiglaNome, BC00025_A4UFID, BC00025_A5UFSigla, BC00025_A6UFNome, BC00025_A9UFRegSigla, BC00025_A10UFRegNome, BC00025_A8UFRegID
               }
               , new Object[] {
               BC00026_A5UFSigla
               }
               , new Object[] {
               BC00027_A4UFID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000211_A9UFRegSigla, BC000211_A10UFRegNome
               }
               , new Object[] {
               BC000212_A13MesorregiaoID
               }
               , new Object[] {
               BC000213_A12UFSiglaNome, BC000213_A11UFRegSiglaNome, BC000213_n11UFRegSiglaNome, BC000213_A4UFID, BC000213_A5UFSigla, BC000213_A6UFNome, BC000213_A9UFRegSigla, BC000213_A10UFRegNome, BC000213_A8UFRegID
               }
            }
         );
         AV25Pgmname = "core.uf_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12022 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound2 ;
      private short nIsDirty_2 ;
      private int trnEnded ;
      private int Z4UFID ;
      private int A4UFID ;
      private int AV26GXV1 ;
      private int AV13Insert_UFRegID ;
      private int Z8UFRegID ;
      private int A8UFRegID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode2 ;
      private bool returnInSub ;
      private bool n11UFRegSiglaNome ;
      private bool mustCommit ;
      private string Z12UFSiglaNome ;
      private string A12UFSiglaNome ;
      private string Z11UFRegSiglaNome ;
      private string A11UFRegSiglaNome ;
      private string Z5UFSigla ;
      private string A5UFSigla ;
      private string Z6UFNome ;
      private string A6UFNome ;
      private string Z9UFRegSigla ;
      private string A9UFRegSigla ;
      private string Z10UFRegNome ;
      private string A10UFRegNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.Sdtuf bccore_uf ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00025_A12UFSiglaNome ;
      private string[] BC00025_A11UFRegSiglaNome ;
      private bool[] BC00025_n11UFRegSiglaNome ;
      private int[] BC00025_A4UFID ;
      private string[] BC00025_A5UFSigla ;
      private string[] BC00025_A6UFNome ;
      private string[] BC00025_A9UFRegSigla ;
      private string[] BC00025_A10UFRegNome ;
      private int[] BC00025_A8UFRegID ;
      private string[] BC00024_A9UFRegSigla ;
      private string[] BC00024_A10UFRegNome ;
      private string[] BC00026_A5UFSigla ;
      private int[] BC00027_A4UFID ;
      private string[] BC00023_A12UFSiglaNome ;
      private int[] BC00023_A4UFID ;
      private string[] BC00023_A5UFSigla ;
      private string[] BC00023_A6UFNome ;
      private int[] BC00023_A8UFRegID ;
      private string[] BC00023_A9UFRegSigla ;
      private string[] BC00023_A10UFRegNome ;
      private string[] BC00023_A11UFRegSiglaNome ;
      private bool[] BC00023_n11UFRegSiglaNome ;
      private string[] BC00022_A12UFSiglaNome ;
      private int[] BC00022_A4UFID ;
      private string[] BC00022_A5UFSigla ;
      private string[] BC00022_A6UFNome ;
      private int[] BC00022_A8UFRegID ;
      private string[] BC00022_A9UFRegSigla ;
      private string[] BC00022_A10UFRegNome ;
      private string[] BC00022_A11UFRegSiglaNome ;
      private bool[] BC00022_n11UFRegSiglaNome ;
      private string[] BC000211_A9UFRegSigla ;
      private string[] BC000211_A10UFRegNome ;
      private int[] BC000212_A13MesorregiaoID ;
      private string[] BC000213_A12UFSiglaNome ;
      private string[] BC000213_A11UFRegSiglaNome ;
      private bool[] BC000213_n11UFRegSiglaNome ;
      private int[] BC000213_A4UFID ;
      private string[] BC000213_A5UFSigla ;
      private string[] BC000213_A6UFNome ;
      private string[] BC000213_A9UFRegSigla ;
      private string[] BC000213_A10UFRegNome ;
      private int[] BC000213_A8UFRegID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class uf_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class uf_bc__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00025;
        prmBC00025 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC00026;
        prmBC00026 = new Object[] {
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC00024;
        prmBC00024 = new Object[] {
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmBC00027;
        prmBC00027 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC00023;
        prmBC00023 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC00022;
        prmBC00022 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC00028;
        prmBC00028 = new Object[] {
        new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
        new ParDef("UFRegNome",GXType.VarChar,50,0) ,
        new ParDef("UFSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("UFID",GXType.Int32,9,0) ,
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFNome",GXType.VarChar,50,0) ,
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmBC00029;
        prmBC00029 = new Object[] {
        new ParDef("UFRegSigla",GXType.VarChar,10,0) ,
        new ParDef("UFRegNome",GXType.VarChar,50,0) ,
        new ParDef("UFSiglaNome",GXType.VarChar,70,0) ,
        new ParDef("UFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("UFSigla",GXType.VarChar,2,0) ,
        new ParDef("UFNome",GXType.VarChar,50,0) ,
        new ParDef("UFRegID",GXType.Int32,9,0) ,
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC000210;
        prmBC000210 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC000211;
        prmBC000211 = new Object[] {
        new ParDef("UFRegID",GXType.Int32,9,0)
        };
        Object[] prmBC000212;
        prmBC000212 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        Object[] prmBC000213;
        prmBC000213 = new Object[] {
        new ParDef("UFID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00022", "SELECT UFSiglaNome, UFID, UFSigla, UFNome, UFRegID, UFRegSigla, UFRegNome, UFRegSiglaNome FROM tbibge_uf WHERE UFID = :UFID  FOR UPDATE OF tbibge_uf",true, GxErrorMask.GX_NOMASK, false, this,prmBC00022,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00023", "SELECT UFSiglaNome, UFID, UFSigla, UFNome, UFRegID, UFRegSigla, UFRegNome, UFRegSiglaNome FROM tbibge_uf WHERE UFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00023,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00024", "SELECT RegiaoSigla AS UFRegSigla, RegiaoNome AS UFRegNome FROM tbibge_regiao WHERE RegiaoID = :UFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00024,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00025", "SELECT TM1.UFSiglaNome, TM1.UFRegSiglaNome AS UFRegSiglaNome, TM1.UFID, TM1.UFSigla, TM1.UFNome, TM1.UFRegSigla AS UFRegSigla, TM1.UFRegNome AS UFRegNome, TM1.UFRegID AS UFRegID FROM tbibge_uf TM1 WHERE TM1.UFID = :UFID ORDER BY TM1.UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00025,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00026", "SELECT UFSigla FROM tbibge_uf WHERE (UFSigla = :UFSigla) AND (Not ( UFID = :UFID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00026,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00027", "SELECT UFID FROM tbibge_uf WHERE UFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00027,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00028", "SAVEPOINT gxupdate;INSERT INTO tbibge_uf(UFRegSigla, UFRegNome, UFSiglaNome, UFRegSiglaNome, UFID, UFSigla, UFNome, UFRegID) VALUES(:UFRegSigla, :UFRegNome, :UFSiglaNome, :UFRegSiglaNome, :UFID, :UFSigla, :UFNome, :UFRegID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00028)
           ,new CursorDef("BC00029", "SAVEPOINT gxupdate;UPDATE tbibge_uf SET UFRegSigla=:UFRegSigla, UFRegNome=:UFRegNome, UFSiglaNome=:UFSiglaNome, UFRegSiglaNome=:UFRegSiglaNome, UFSigla=:UFSigla, UFNome=:UFNome, UFRegID=:UFRegID  WHERE UFID = :UFID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00029)
           ,new CursorDef("BC000210", "SAVEPOINT gxupdate;DELETE FROM tbibge_uf  WHERE UFID = :UFID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000210)
           ,new CursorDef("BC000211", "SELECT RegiaoSigla AS UFRegSigla, RegiaoNome AS UFRegNome FROM tbibge_regiao WHERE RegiaoID = :UFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000211,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000212", "SELECT MesorregiaoID FROM tbibge_mesorregiao WHERE MesorregiaoUFID = :UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000212,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000213", "SELECT TM1.UFSiglaNome, TM1.UFRegSiglaNome AS UFRegSiglaNome, TM1.UFID, TM1.UFSigla, TM1.UFNome, TM1.UFRegSigla AS UFRegSigla, TM1.UFRegNome AS UFRegNome, TM1.UFRegID AS UFRegID FROM tbibge_uf TM1 WHERE TM1.UFID = :UFID ORDER BY TM1.UFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000213,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 10 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((int[]) buf[3])[0] = rslt.getInt(3);
              ((string[]) buf[4])[0] = rslt.getVarchar(4);
              ((string[]) buf[5])[0] = rslt.getVarchar(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((int[]) buf[8])[0] = rslt.getInt(8);
              return;
     }
  }

}

}
