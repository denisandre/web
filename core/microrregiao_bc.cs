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
   public class microrregiao_bc : GxSilentTrn, IGxSilentTrn
   {
      public microrregiao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public microrregiao_bc( IGxContext context )
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
         ReadRow044( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey044( ) ;
         standaloneModal( ) ;
         AddRow044( ) ;
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
            E11042 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z23MicrorregiaoID = A23MicrorregiaoID;
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

      protected void CONFIRM_040( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls044( ) ;
            }
            else
            {
               CheckExtendedTable044( ) ;
               if ( AnyError == 0 )
               {
                  ZM044( 6) ;
                  ZM044( 7) ;
                  ZM044( 8) ;
               }
               CloseExtendedTableCursors044( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12042( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "MicrorregiaoMesoID") == 0 )
               {
                  AV13Insert_MicrorregiaoMesoID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E11042( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM044( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            Z30MicrorregiaoMesoUFSiglaNome = A30MicrorregiaoMesoUFSiglaNome;
            Z34MicrorregiaoMesoUFRegSiglaNome = A34MicrorregiaoMesoUFRegSiglaNome;
            Z24MicrorregiaoNome = A24MicrorregiaoNome;
            Z25MicrorregiaoMesoID = A25MicrorregiaoMesoID;
         }
         if ( ( GX_JID == 6 ) || ( GX_JID == 0 ) )
         {
            Z26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            Z27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
         }
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            Z28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            Z29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            Z31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
         }
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            Z33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
         }
         if ( GX_JID == -5 )
         {
            Z30MicrorregiaoMesoUFSiglaNome = A30MicrorregiaoMesoUFSiglaNome;
            Z34MicrorregiaoMesoUFRegSiglaNome = A34MicrorregiaoMesoUFRegSiglaNome;
            Z23MicrorregiaoID = A23MicrorregiaoID;
            Z24MicrorregiaoNome = A24MicrorregiaoNome;
            Z26MicrorregiaoMesoNome = A26MicrorregiaoMesoNome;
            Z27MicrorregiaoMesoUFID = A27MicrorregiaoMesoUFID;
            Z28MicrorregiaoMesoUFSigla = A28MicrorregiaoMesoUFSigla;
            Z29MicrorregiaoMesoUFNome = A29MicrorregiaoMesoUFNome;
            Z31MicrorregiaoMesoUFRegID = A31MicrorregiaoMesoUFRegID;
            Z32MicrorregiaoMesoUFRegSigla = A32MicrorregiaoMesoUFRegSigla;
            Z33MicrorregiaoMesoUFRegNome = A33MicrorregiaoMesoUFRegNome;
            Z25MicrorregiaoMesoID = A25MicrorregiaoMesoID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV25Pgmname = "core.microrregiao_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load044( )
      {
         /* Using cursor BC00047 */
         pr_default.execute(5, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound4 = 1;
            A30MicrorregiaoMesoUFSiglaNome = BC00047_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = BC00047_n30MicrorregiaoMesoUFSiglaNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = BC00047_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = BC00047_n34MicrorregiaoMesoUFRegSiglaNome[0];
            A24MicrorregiaoNome = BC00047_A24MicrorregiaoNome[0];
            A26MicrorregiaoMesoNome = BC00047_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = BC00047_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = BC00047_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = BC00047_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = BC00047_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = BC00047_n29MicrorregiaoMesoUFNome[0];
            A31MicrorregiaoMesoUFRegID = BC00047_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = BC00047_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = BC00047_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = BC00047_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = BC00047_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = BC00047_n33MicrorregiaoMesoUFRegNome[0];
            A25MicrorregiaoMesoID = BC00047_A25MicrorregiaoMesoID[0];
            ZM044( -5) ;
         }
         pr_default.close(5);
         OnLoadActions044( ) ;
      }

      protected void OnLoadActions044( )
      {
         A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
         n30MicrorregiaoMesoUFSiglaNome = false;
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         A32MicrorregiaoMesoUFRegSigla = BC00046_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = BC00046_n32MicrorregiaoMesoUFRegSigla[0];
         A33MicrorregiaoMesoUFRegNome = BC00046_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = BC00046_n33MicrorregiaoMesoUFRegNome[0];
         pr_default.close(4);
         A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
         n34MicrorregiaoMesoUFRegSiglaNome = false;
      }

      protected void CheckExtendedTable044( )
      {
         nIsDirty_4 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00044 */
         pr_default.execute(2, new Object[] {A25MicrorregiaoMesoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Group Mesoregião -> Microregião'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOID");
            AnyError = 1;
         }
         A26MicrorregiaoMesoNome = BC00044_A26MicrorregiaoMesoNome[0];
         A27MicrorregiaoMesoUFID = BC00044_A27MicrorregiaoMesoUFID[0];
         pr_default.close(2);
         /* Using cursor BC00045 */
         pr_default.execute(3, new Object[] {A27MicrorregiaoMesoUFID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'Unidade Federativa (Estado)'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFID");
            AnyError = 1;
         }
         A28MicrorregiaoMesoUFSigla = BC00045_A28MicrorregiaoMesoUFSigla[0];
         n28MicrorregiaoMesoUFSigla = BC00045_n28MicrorregiaoMesoUFSigla[0];
         A29MicrorregiaoMesoUFNome = BC00045_A29MicrorregiaoMesoUFNome[0];
         n29MicrorregiaoMesoUFNome = BC00045_n29MicrorregiaoMesoUFNome[0];
         A31MicrorregiaoMesoUFRegID = BC00045_A31MicrorregiaoMesoUFRegID[0];
         n31MicrorregiaoMesoUFRegID = BC00045_n31MicrorregiaoMesoUFRegID[0];
         pr_default.close(3);
         nIsDirty_4 = 1;
         A30MicrorregiaoMesoUFSiglaNome = StringUtil.Trim( A28MicrorregiaoMesoUFSigla) + " - " + StringUtil.Trim( A29MicrorregiaoMesoUFNome);
         n30MicrorregiaoMesoUFSiglaNome = false;
         /* Using cursor BC00046 */
         pr_default.execute(4, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Região'.", "ForeignKeyNotFound", 1, "MICRORREGIAOMESOUFREGID");
            AnyError = 1;
         }
         A32MicrorregiaoMesoUFRegSigla = BC00046_A32MicrorregiaoMesoUFRegSigla[0];
         n32MicrorregiaoMesoUFRegSigla = BC00046_n32MicrorregiaoMesoUFRegSigla[0];
         A33MicrorregiaoMesoUFRegNome = BC00046_A33MicrorregiaoMesoUFRegNome[0];
         n33MicrorregiaoMesoUFRegNome = BC00046_n33MicrorregiaoMesoUFRegNome[0];
         pr_default.close(4);
         nIsDirty_4 = 1;
         A34MicrorregiaoMesoUFRegSiglaNome = StringUtil.Trim( A32MicrorregiaoMesoUFRegSigla) + " - " + StringUtil.Trim( A33MicrorregiaoMesoUFRegNome);
         n34MicrorregiaoMesoUFRegSiglaNome = false;
      }

      protected void CloseExtendedTableCursors044( )
      {
         pr_default.close(2);
         pr_default.close(3);
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey044( )
      {
         /* Using cursor BC00048 */
         pr_default.execute(6, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound4 = 1;
         }
         else
         {
            RcdFound4 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00043 */
         pr_default.execute(1, new Object[] {A23MicrorregiaoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM044( 5) ;
            RcdFound4 = 1;
            A23MicrorregiaoID = BC00043_A23MicrorregiaoID[0];
            A24MicrorregiaoNome = BC00043_A24MicrorregiaoNome[0];
            A25MicrorregiaoMesoID = BC00043_A25MicrorregiaoMesoID[0];
            A30MicrorregiaoMesoUFSiglaNome = BC00043_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = BC00043_n30MicrorregiaoMesoUFSiglaNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = BC00043_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = BC00043_n34MicrorregiaoMesoUFRegSiglaNome[0];
            Z23MicrorregiaoID = A23MicrorregiaoID;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load044( ) ;
            if ( AnyError == 1 )
            {
               RcdFound4 = 0;
               InitializeNonKey044( ) ;
            }
            Gx_mode = sMode4;
         }
         else
         {
            RcdFound4 = 0;
            InitializeNonKey044( ) ;
            sMode4 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode4;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey044( ) ;
         if ( RcdFound4 == 0 )
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
         CONFIRM_040( ) ;
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

      protected void CheckOptimisticConcurrency044( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00042 */
            pr_default.execute(0, new Object[] {A23MicrorregiaoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_microrregiao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z30MicrorregiaoMesoUFSiglaNome, BC00042_A30MicrorregiaoMesoUFSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z34MicrorregiaoMesoUFRegSiglaNome, BC00042_A34MicrorregiaoMesoUFRegSiglaNome[0]) != 0 ) || ( StringUtil.StrCmp(Z24MicrorregiaoNome, BC00042_A24MicrorregiaoNome[0]) != 0 ) || ( Z25MicrorregiaoMesoID != BC00042_A25MicrorregiaoMesoID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tbibge_microrregiao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM044( 0) ;
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00049 */
                     pr_default.execute(7, new Object[] {A26MicrorregiaoMesoNome, A27MicrorregiaoMesoUFID, n28MicrorregiaoMesoUFSigla, A28MicrorregiaoMesoUFSigla, n29MicrorregiaoMesoUFNome, A29MicrorregiaoMesoUFNome, n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID, n32MicrorregiaoMesoUFRegSigla, A32MicrorregiaoMesoUFRegSigla, n33MicrorregiaoMesoUFRegNome, A33MicrorregiaoMesoUFRegNome, n30MicrorregiaoMesoUFSiglaNome, A30MicrorregiaoMesoUFSiglaNome, n34MicrorregiaoMesoUFRegSiglaNome, A34MicrorregiaoMesoUFRegSiglaNome, A23MicrorregiaoID, A24MicrorregiaoNome, A25MicrorregiaoMesoID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
                     if ( (pr_default.getStatus(7) == 1) )
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
               Load044( ) ;
            }
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void Update044( )
      {
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable044( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm044( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate044( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000410 */
                     pr_default.execute(8, new Object[] {A26MicrorregiaoMesoNome, A27MicrorregiaoMesoUFID, n28MicrorregiaoMesoUFSigla, A28MicrorregiaoMesoUFSigla, n29MicrorregiaoMesoUFNome, A29MicrorregiaoMesoUFNome, n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID, n32MicrorregiaoMesoUFRegSigla, A32MicrorregiaoMesoUFRegSigla, n33MicrorregiaoMesoUFRegNome, A33MicrorregiaoMesoUFRegNome, n30MicrorregiaoMesoUFSiglaNome, A30MicrorregiaoMesoUFSiglaNome, n34MicrorregiaoMesoUFRegSiglaNome, A34MicrorregiaoMesoUFRegSiglaNome, A24MicrorregiaoNome, A25MicrorregiaoMesoID, A23MicrorregiaoID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tbibge_microrregiao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate044( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tbibge_microrregiaoupdateredundancy(context ).execute( ref  A23MicrorregiaoID) ;
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
            EndLevel044( ) ;
         }
         CloseExtendedTableCursors044( ) ;
      }

      protected void DeferredUpdate044( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate044( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency044( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls044( ) ;
            AfterConfirm044( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete044( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000411 */
                  pr_default.execute(9, new Object[] {A23MicrorregiaoID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("tbibge_microrregiao");
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
         sMode4 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel044( ) ;
         Gx_mode = sMode4;
      }

      protected void OnDeleteControls044( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000412 */
            pr_default.execute(10, new Object[] {A25MicrorregiaoMesoID});
            A26MicrorregiaoMesoNome = BC000412_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = BC000412_A27MicrorregiaoMesoUFID[0];
            pr_default.close(10);
            /* Using cursor BC000413 */
            pr_default.execute(11, new Object[] {A27MicrorregiaoMesoUFID});
            A28MicrorregiaoMesoUFSigla = BC000413_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = BC000413_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = BC000413_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = BC000413_n29MicrorregiaoMesoUFNome[0];
            A31MicrorregiaoMesoUFRegID = BC000413_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = BC000413_n31MicrorregiaoMesoUFRegID[0];
            pr_default.close(11);
            /* Using cursor BC000414 */
            pr_default.execute(12, new Object[] {n31MicrorregiaoMesoUFRegID, A31MicrorregiaoMesoUFRegID});
            A32MicrorregiaoMesoUFRegSigla = BC000414_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = BC000414_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = BC000414_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = BC000414_n33MicrorregiaoMesoUFRegNome[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000415 */
            pr_default.execute(13, new Object[] {A23MicrorregiaoID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Município"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel044( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete044( ) ;
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

      public void ScanKeyStart044( )
      {
         /* Scan By routine */
         /* Using cursor BC000416 */
         pr_default.execute(14, new Object[] {A23MicrorregiaoID});
         RcdFound4 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A30MicrorregiaoMesoUFSiglaNome = BC000416_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = BC000416_n30MicrorregiaoMesoUFSiglaNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = BC000416_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = BC000416_n34MicrorregiaoMesoUFRegSiglaNome[0];
            A23MicrorregiaoID = BC000416_A23MicrorregiaoID[0];
            A24MicrorregiaoNome = BC000416_A24MicrorregiaoNome[0];
            A26MicrorregiaoMesoNome = BC000416_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = BC000416_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = BC000416_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = BC000416_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = BC000416_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = BC000416_n29MicrorregiaoMesoUFNome[0];
            A31MicrorregiaoMesoUFRegID = BC000416_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = BC000416_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = BC000416_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = BC000416_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = BC000416_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = BC000416_n33MicrorregiaoMesoUFRegNome[0];
            A25MicrorregiaoMesoID = BC000416_A25MicrorregiaoMesoID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext044( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound4 = 0;
         ScanKeyLoad044( ) ;
      }

      protected void ScanKeyLoad044( )
      {
         sMode4 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound4 = 1;
            A30MicrorregiaoMesoUFSiglaNome = BC000416_A30MicrorregiaoMesoUFSiglaNome[0];
            n30MicrorregiaoMesoUFSiglaNome = BC000416_n30MicrorregiaoMesoUFSiglaNome[0];
            A34MicrorregiaoMesoUFRegSiglaNome = BC000416_A34MicrorregiaoMesoUFRegSiglaNome[0];
            n34MicrorregiaoMesoUFRegSiglaNome = BC000416_n34MicrorregiaoMesoUFRegSiglaNome[0];
            A23MicrorregiaoID = BC000416_A23MicrorregiaoID[0];
            A24MicrorregiaoNome = BC000416_A24MicrorregiaoNome[0];
            A26MicrorregiaoMesoNome = BC000416_A26MicrorregiaoMesoNome[0];
            A27MicrorregiaoMesoUFID = BC000416_A27MicrorregiaoMesoUFID[0];
            A28MicrorregiaoMesoUFSigla = BC000416_A28MicrorregiaoMesoUFSigla[0];
            n28MicrorregiaoMesoUFSigla = BC000416_n28MicrorregiaoMesoUFSigla[0];
            A29MicrorregiaoMesoUFNome = BC000416_A29MicrorregiaoMesoUFNome[0];
            n29MicrorregiaoMesoUFNome = BC000416_n29MicrorregiaoMesoUFNome[0];
            A31MicrorregiaoMesoUFRegID = BC000416_A31MicrorregiaoMesoUFRegID[0];
            n31MicrorregiaoMesoUFRegID = BC000416_n31MicrorregiaoMesoUFRegID[0];
            A32MicrorregiaoMesoUFRegSigla = BC000416_A32MicrorregiaoMesoUFRegSigla[0];
            n32MicrorregiaoMesoUFRegSigla = BC000416_n32MicrorregiaoMesoUFRegSigla[0];
            A33MicrorregiaoMesoUFRegNome = BC000416_A33MicrorregiaoMesoUFRegNome[0];
            n33MicrorregiaoMesoUFRegNome = BC000416_n33MicrorregiaoMesoUFRegNome[0];
            A25MicrorregiaoMesoID = BC000416_A25MicrorregiaoMesoID[0];
         }
         Gx_mode = sMode4;
      }

      protected void ScanKeyEnd044( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm044( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert044( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate044( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete044( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete044( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate044( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes044( )
      {
      }

      protected void send_integrity_lvl_hashes044( )
      {
      }

      protected void AddRow044( )
      {
         VarsToRow4( bccore_microrregiao) ;
      }

      protected void ReadRow044( )
      {
         RowToVars4( bccore_microrregiao, 1) ;
      }

      protected void InitializeNonKey044( )
      {
         A24MicrorregiaoNome = "";
         A25MicrorregiaoMesoID = 0;
         A26MicrorregiaoMesoNome = "";
         A27MicrorregiaoMesoUFID = 0;
         A28MicrorregiaoMesoUFSigla = "";
         n28MicrorregiaoMesoUFSigla = false;
         A29MicrorregiaoMesoUFNome = "";
         n29MicrorregiaoMesoUFNome = false;
         A30MicrorregiaoMesoUFSiglaNome = "";
         n30MicrorregiaoMesoUFSiglaNome = false;
         A31MicrorregiaoMesoUFRegID = 0;
         n31MicrorregiaoMesoUFRegID = false;
         A32MicrorregiaoMesoUFRegSigla = "";
         n32MicrorregiaoMesoUFRegSigla = false;
         A33MicrorregiaoMesoUFRegNome = "";
         n33MicrorregiaoMesoUFRegNome = false;
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         Z30MicrorregiaoMesoUFSiglaNome = "";
         Z34MicrorregiaoMesoUFRegSiglaNome = "";
         Z24MicrorregiaoNome = "";
         Z25MicrorregiaoMesoID = 0;
      }

      protected void InitAll044( )
      {
         A23MicrorregiaoID = 0;
         InitializeNonKey044( ) ;
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

      public void VarsToRow4( GeneXus.Programs.core.Sdtmicrorregiao obj4 )
      {
         obj4.gxTpr_Mode = Gx_mode;
         obj4.gxTpr_Microrregiaonome = A24MicrorregiaoNome;
         obj4.gxTpr_Microrregiaomesoid = A25MicrorregiaoMesoID;
         obj4.gxTpr_Microrregiaomesonome = A26MicrorregiaoMesoNome;
         obj4.gxTpr_Microrregiaomesoufid = A27MicrorregiaoMesoUFID;
         obj4.gxTpr_Microrregiaomesoufsigla = A28MicrorregiaoMesoUFSigla;
         obj4.gxTpr_Microrregiaomesoufnome = A29MicrorregiaoMesoUFNome;
         obj4.gxTpr_Microrregiaomesoufsiglanome = A30MicrorregiaoMesoUFSiglaNome;
         obj4.gxTpr_Microrregiaomesoufregid = A31MicrorregiaoMesoUFRegID;
         obj4.gxTpr_Microrregiaomesoufregsigla = A32MicrorregiaoMesoUFRegSigla;
         obj4.gxTpr_Microrregiaomesoufregnome = A33MicrorregiaoMesoUFRegNome;
         obj4.gxTpr_Microrregiaomesoufregsiglanome = A34MicrorregiaoMesoUFRegSiglaNome;
         obj4.gxTpr_Microrregiaoid = A23MicrorregiaoID;
         obj4.gxTpr_Microrregiaoid_Z = Z23MicrorregiaoID;
         obj4.gxTpr_Microrregiaonome_Z = Z24MicrorregiaoNome;
         obj4.gxTpr_Microrregiaomesoid_Z = Z25MicrorregiaoMesoID;
         obj4.gxTpr_Microrregiaomesonome_Z = Z26MicrorregiaoMesoNome;
         obj4.gxTpr_Microrregiaomesoufid_Z = Z27MicrorregiaoMesoUFID;
         obj4.gxTpr_Microrregiaomesoufsigla_Z = Z28MicrorregiaoMesoUFSigla;
         obj4.gxTpr_Microrregiaomesoufnome_Z = Z29MicrorregiaoMesoUFNome;
         obj4.gxTpr_Microrregiaomesoufsiglanome_Z = Z30MicrorregiaoMesoUFSiglaNome;
         obj4.gxTpr_Microrregiaomesoufregid_Z = Z31MicrorregiaoMesoUFRegID;
         obj4.gxTpr_Microrregiaomesoufregsigla_Z = Z32MicrorregiaoMesoUFRegSigla;
         obj4.gxTpr_Microrregiaomesoufregnome_Z = Z33MicrorregiaoMesoUFRegNome;
         obj4.gxTpr_Microrregiaomesoufregsiglanome_Z = Z34MicrorregiaoMesoUFRegSiglaNome;
         obj4.gxTpr_Microrregiaomesoufsigla_N = (short)(Convert.ToInt16(n28MicrorregiaoMesoUFSigla));
         obj4.gxTpr_Microrregiaomesoufnome_N = (short)(Convert.ToInt16(n29MicrorregiaoMesoUFNome));
         obj4.gxTpr_Microrregiaomesoufsiglanome_N = (short)(Convert.ToInt16(n30MicrorregiaoMesoUFSiglaNome));
         obj4.gxTpr_Microrregiaomesoufregid_N = (short)(Convert.ToInt16(n31MicrorregiaoMesoUFRegID));
         obj4.gxTpr_Microrregiaomesoufregsigla_N = (short)(Convert.ToInt16(n32MicrorregiaoMesoUFRegSigla));
         obj4.gxTpr_Microrregiaomesoufregnome_N = (short)(Convert.ToInt16(n33MicrorregiaoMesoUFRegNome));
         obj4.gxTpr_Microrregiaomesoufregsiglanome_N = (short)(Convert.ToInt16(n34MicrorregiaoMesoUFRegSiglaNome));
         obj4.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow4( GeneXus.Programs.core.Sdtmicrorregiao obj4 )
      {
         obj4.gxTpr_Microrregiaoid = A23MicrorregiaoID;
         return  ;
      }

      public void RowToVars4( GeneXus.Programs.core.Sdtmicrorregiao obj4 ,
                              int forceLoad )
      {
         Gx_mode = obj4.gxTpr_Mode;
         A24MicrorregiaoNome = obj4.gxTpr_Microrregiaonome;
         A25MicrorregiaoMesoID = obj4.gxTpr_Microrregiaomesoid;
         A26MicrorregiaoMesoNome = obj4.gxTpr_Microrregiaomesonome;
         A27MicrorregiaoMesoUFID = obj4.gxTpr_Microrregiaomesoufid;
         A28MicrorregiaoMesoUFSigla = obj4.gxTpr_Microrregiaomesoufsigla;
         n28MicrorregiaoMesoUFSigla = false;
         A29MicrorregiaoMesoUFNome = obj4.gxTpr_Microrregiaomesoufnome;
         n29MicrorregiaoMesoUFNome = false;
         A30MicrorregiaoMesoUFSiglaNome = obj4.gxTpr_Microrregiaomesoufsiglanome;
         n30MicrorregiaoMesoUFSiglaNome = false;
         A31MicrorregiaoMesoUFRegID = obj4.gxTpr_Microrregiaomesoufregid;
         n31MicrorregiaoMesoUFRegID = false;
         A32MicrorregiaoMesoUFRegSigla = obj4.gxTpr_Microrregiaomesoufregsigla;
         n32MicrorregiaoMesoUFRegSigla = false;
         A33MicrorregiaoMesoUFRegNome = obj4.gxTpr_Microrregiaomesoufregnome;
         n33MicrorregiaoMesoUFRegNome = false;
         A34MicrorregiaoMesoUFRegSiglaNome = obj4.gxTpr_Microrregiaomesoufregsiglanome;
         n34MicrorregiaoMesoUFRegSiglaNome = false;
         A23MicrorregiaoID = obj4.gxTpr_Microrregiaoid;
         Z23MicrorregiaoID = obj4.gxTpr_Microrregiaoid_Z;
         Z24MicrorregiaoNome = obj4.gxTpr_Microrregiaonome_Z;
         Z25MicrorregiaoMesoID = obj4.gxTpr_Microrregiaomesoid_Z;
         Z26MicrorregiaoMesoNome = obj4.gxTpr_Microrregiaomesonome_Z;
         Z27MicrorregiaoMesoUFID = obj4.gxTpr_Microrregiaomesoufid_Z;
         Z28MicrorregiaoMesoUFSigla = obj4.gxTpr_Microrregiaomesoufsigla_Z;
         Z29MicrorregiaoMesoUFNome = obj4.gxTpr_Microrregiaomesoufnome_Z;
         Z30MicrorregiaoMesoUFSiglaNome = obj4.gxTpr_Microrregiaomesoufsiglanome_Z;
         Z31MicrorregiaoMesoUFRegID = obj4.gxTpr_Microrregiaomesoufregid_Z;
         Z32MicrorregiaoMesoUFRegSigla = obj4.gxTpr_Microrregiaomesoufregsigla_Z;
         Z33MicrorregiaoMesoUFRegNome = obj4.gxTpr_Microrregiaomesoufregnome_Z;
         Z34MicrorregiaoMesoUFRegSiglaNome = obj4.gxTpr_Microrregiaomesoufregsiglanome_Z;
         n28MicrorregiaoMesoUFSigla = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufsigla_N));
         n29MicrorregiaoMesoUFNome = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufnome_N));
         n30MicrorregiaoMesoUFSiglaNome = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufsiglanome_N));
         n31MicrorregiaoMesoUFRegID = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufregid_N));
         n32MicrorregiaoMesoUFRegSigla = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufregsigla_N));
         n33MicrorregiaoMesoUFRegNome = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufregnome_N));
         n34MicrorregiaoMesoUFRegSiglaNome = (bool)(Convert.ToBoolean(obj4.gxTpr_Microrregiaomesoufregsiglanome_N));
         Gx_mode = obj4.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A23MicrorregiaoID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey044( ) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23MicrorregiaoID = A23MicrorregiaoID;
         }
         ZM044( -5) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
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
         RowToVars4( bccore_microrregiao, 0) ;
         ScanKeyStart044( ) ;
         if ( RcdFound4 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z23MicrorregiaoID = A23MicrorregiaoID;
         }
         ZM044( -5) ;
         OnLoadActions044( ) ;
         AddRow044( ) ;
         ScanKeyEnd044( ) ;
         if ( RcdFound4 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey044( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert044( ) ;
         }
         else
         {
            if ( RcdFound4 == 1 )
            {
               if ( A23MicrorregiaoID != Z23MicrorregiaoID )
               {
                  A23MicrorregiaoID = Z23MicrorregiaoID;
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
                  Update044( ) ;
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
                  if ( A23MicrorregiaoID != Z23MicrorregiaoID )
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
                        Insert044( ) ;
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
                        Insert044( ) ;
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
         RowToVars4( bccore_microrregiao, 1) ;
         SaveImpl( ) ;
         VarsToRow4( bccore_microrregiao) ;
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
         RowToVars4( bccore_microrregiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
         AfterTrn( ) ;
         VarsToRow4( bccore_microrregiao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow4( bccore_microrregiao) ;
         }
         else
         {
            GeneXus.Programs.core.Sdtmicrorregiao auxBC = new GeneXus.Programs.core.Sdtmicrorregiao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A23MicrorregiaoID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_microrregiao);
               auxBC.Save();
               bccore_microrregiao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars4( bccore_microrregiao, 1) ;
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
         RowToVars4( bccore_microrregiao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert044( ) ;
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
               VarsToRow4( bccore_microrregiao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow4( bccore_microrregiao) ;
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
         RowToVars4( bccore_microrregiao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey044( ) ;
         if ( RcdFound4 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A23MicrorregiaoID != Z23MicrorregiaoID )
            {
               A23MicrorregiaoID = Z23MicrorregiaoID;
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
            if ( A23MicrorregiaoID != Z23MicrorregiaoID )
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
         context.RollbackDataStores("core.microrregiao_bc",pr_default);
         VarsToRow4( bccore_microrregiao) ;
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
         Gx_mode = bccore_microrregiao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_microrregiao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_microrregiao )
         {
            bccore_microrregiao = (GeneXus.Programs.core.Sdtmicrorregiao)(sdt);
            if ( StringUtil.StrCmp(bccore_microrregiao.gxTpr_Mode, "") == 0 )
            {
               bccore_microrregiao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow4( bccore_microrregiao) ;
            }
            else
            {
               RowToVars4( bccore_microrregiao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_microrregiao.gxTpr_Mode, "") == 0 )
            {
               bccore_microrregiao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars4( bccore_microrregiao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public Sdtmicrorregiao microrregiao_BC
      {
         get {
            return bccore_microrregiao ;
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
            return "microrregiao_Execute" ;
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
         pr_default.close(10);
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
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV25Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         Z30MicrorregiaoMesoUFSiglaNome = "";
         A30MicrorregiaoMesoUFSiglaNome = "";
         Z34MicrorregiaoMesoUFRegSiglaNome = "";
         A34MicrorregiaoMesoUFRegSiglaNome = "";
         Z24MicrorregiaoNome = "";
         A24MicrorregiaoNome = "";
         Z26MicrorregiaoMesoNome = "";
         A26MicrorregiaoMesoNome = "";
         Z28MicrorregiaoMesoUFSigla = "";
         A28MicrorregiaoMesoUFSigla = "";
         Z29MicrorregiaoMesoUFNome = "";
         A29MicrorregiaoMesoUFNome = "";
         Z32MicrorregiaoMesoUFRegSigla = "";
         A32MicrorregiaoMesoUFRegSigla = "";
         Z33MicrorregiaoMesoUFRegNome = "";
         A33MicrorregiaoMesoUFRegNome = "";
         BC00047_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         BC00047_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         BC00047_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         BC00047_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         BC00047_A23MicrorregiaoID = new int[1] ;
         BC00047_A24MicrorregiaoNome = new string[] {""} ;
         BC00047_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC00047_A27MicrorregiaoMesoUFID = new int[1] ;
         BC00047_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC00047_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC00047_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC00047_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC00047_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC00047_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC00047_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC00047_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC00047_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC00047_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC00047_A25MicrorregiaoMesoID = new int[1] ;
         BC00046_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC00046_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC00046_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC00046_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC00044_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC00044_A27MicrorregiaoMesoUFID = new int[1] ;
         BC00045_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC00045_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC00045_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC00045_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC00045_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC00045_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC00048_A23MicrorregiaoID = new int[1] ;
         BC00043_A23MicrorregiaoID = new int[1] ;
         BC00043_A24MicrorregiaoNome = new string[] {""} ;
         BC00043_A25MicrorregiaoMesoID = new int[1] ;
         BC00043_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC00043_A27MicrorregiaoMesoUFID = new int[1] ;
         BC00043_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC00043_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC00043_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC00043_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC00043_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         BC00043_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         BC00043_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC00043_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC00043_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC00043_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC00043_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC00043_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC00043_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         BC00043_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         sMode4 = "";
         BC00042_A23MicrorregiaoID = new int[1] ;
         BC00042_A24MicrorregiaoNome = new string[] {""} ;
         BC00042_A25MicrorregiaoMesoID = new int[1] ;
         BC00042_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC00042_A27MicrorregiaoMesoUFID = new int[1] ;
         BC00042_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC00042_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC00042_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC00042_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC00042_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         BC00042_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         BC00042_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC00042_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC00042_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC00042_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC00042_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC00042_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC00042_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         BC00042_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         BC000412_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC000412_A27MicrorregiaoMesoUFID = new int[1] ;
         BC000413_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC000413_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC000413_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC000413_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC000413_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC000413_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC000414_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC000414_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC000414_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC000414_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC000415_A35MunicipioID = new int[1] ;
         BC000416_A30MicrorregiaoMesoUFSiglaNome = new string[] {""} ;
         BC000416_n30MicrorregiaoMesoUFSiglaNome = new bool[] {false} ;
         BC000416_A34MicrorregiaoMesoUFRegSiglaNome = new string[] {""} ;
         BC000416_n34MicrorregiaoMesoUFRegSiglaNome = new bool[] {false} ;
         BC000416_A23MicrorregiaoID = new int[1] ;
         BC000416_A24MicrorregiaoNome = new string[] {""} ;
         BC000416_A26MicrorregiaoMesoNome = new string[] {""} ;
         BC000416_A27MicrorregiaoMesoUFID = new int[1] ;
         BC000416_A28MicrorregiaoMesoUFSigla = new string[] {""} ;
         BC000416_n28MicrorregiaoMesoUFSigla = new bool[] {false} ;
         BC000416_A29MicrorregiaoMesoUFNome = new string[] {""} ;
         BC000416_n29MicrorregiaoMesoUFNome = new bool[] {false} ;
         BC000416_A31MicrorregiaoMesoUFRegID = new int[1] ;
         BC000416_n31MicrorregiaoMesoUFRegID = new bool[] {false} ;
         BC000416_A32MicrorregiaoMesoUFRegSigla = new string[] {""} ;
         BC000416_n32MicrorregiaoMesoUFRegSigla = new bool[] {false} ;
         BC000416_A33MicrorregiaoMesoUFRegNome = new string[] {""} ;
         BC000416_n33MicrorregiaoMesoUFRegNome = new bool[] {false} ;
         BC000416_A25MicrorregiaoMesoID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.microrregiao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00042_A23MicrorregiaoID, BC00042_A24MicrorregiaoNome, BC00042_A25MicrorregiaoMesoID, BC00042_A26MicrorregiaoMesoNome, BC00042_A27MicrorregiaoMesoUFID, BC00042_A28MicrorregiaoMesoUFSigla, BC00042_n28MicrorregiaoMesoUFSigla, BC00042_A29MicrorregiaoMesoUFNome, BC00042_n29MicrorregiaoMesoUFNome, BC00042_A30MicrorregiaoMesoUFSiglaNome,
               BC00042_n30MicrorregiaoMesoUFSiglaNome, BC00042_A31MicrorregiaoMesoUFRegID, BC00042_n31MicrorregiaoMesoUFRegID, BC00042_A32MicrorregiaoMesoUFRegSigla, BC00042_n32MicrorregiaoMesoUFRegSigla, BC00042_A33MicrorregiaoMesoUFRegNome, BC00042_n33MicrorregiaoMesoUFRegNome, BC00042_A34MicrorregiaoMesoUFRegSiglaNome, BC00042_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               BC00043_A23MicrorregiaoID, BC00043_A24MicrorregiaoNome, BC00043_A25MicrorregiaoMesoID, BC00043_A26MicrorregiaoMesoNome, BC00043_A27MicrorregiaoMesoUFID, BC00043_A28MicrorregiaoMesoUFSigla, BC00043_n28MicrorregiaoMesoUFSigla, BC00043_A29MicrorregiaoMesoUFNome, BC00043_n29MicrorregiaoMesoUFNome, BC00043_A30MicrorregiaoMesoUFSiglaNome,
               BC00043_n30MicrorregiaoMesoUFSiglaNome, BC00043_A31MicrorregiaoMesoUFRegID, BC00043_n31MicrorregiaoMesoUFRegID, BC00043_A32MicrorregiaoMesoUFRegSigla, BC00043_n32MicrorregiaoMesoUFRegSigla, BC00043_A33MicrorregiaoMesoUFRegNome, BC00043_n33MicrorregiaoMesoUFRegNome, BC00043_A34MicrorregiaoMesoUFRegSiglaNome, BC00043_n34MicrorregiaoMesoUFRegSiglaNome
               }
               , new Object[] {
               BC00044_A26MicrorregiaoMesoNome, BC00044_A27MicrorregiaoMesoUFID
               }
               , new Object[] {
               BC00045_A28MicrorregiaoMesoUFSigla, BC00045_A29MicrorregiaoMesoUFNome, BC00045_A31MicrorregiaoMesoUFRegID
               }
               , new Object[] {
               BC00046_A32MicrorregiaoMesoUFRegSigla, BC00046_A33MicrorregiaoMesoUFRegNome
               }
               , new Object[] {
               BC00047_A30MicrorregiaoMesoUFSiglaNome, BC00047_n30MicrorregiaoMesoUFSiglaNome, BC00047_A34MicrorregiaoMesoUFRegSiglaNome, BC00047_n34MicrorregiaoMesoUFRegSiglaNome, BC00047_A23MicrorregiaoID, BC00047_A24MicrorregiaoNome, BC00047_A26MicrorregiaoMesoNome, BC00047_A27MicrorregiaoMesoUFID, BC00047_A28MicrorregiaoMesoUFSigla, BC00047_n28MicrorregiaoMesoUFSigla,
               BC00047_A29MicrorregiaoMesoUFNome, BC00047_n29MicrorregiaoMesoUFNome, BC00047_A31MicrorregiaoMesoUFRegID, BC00047_n31MicrorregiaoMesoUFRegID, BC00047_A32MicrorregiaoMesoUFRegSigla, BC00047_n32MicrorregiaoMesoUFRegSigla, BC00047_A33MicrorregiaoMesoUFRegNome, BC00047_n33MicrorregiaoMesoUFRegNome, BC00047_A25MicrorregiaoMesoID
               }
               , new Object[] {
               BC00048_A23MicrorregiaoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000412_A26MicrorregiaoMesoNome, BC000412_A27MicrorregiaoMesoUFID
               }
               , new Object[] {
               BC000413_A28MicrorregiaoMesoUFSigla, BC000413_A29MicrorregiaoMesoUFNome, BC000413_A31MicrorregiaoMesoUFRegID
               }
               , new Object[] {
               BC000414_A32MicrorregiaoMesoUFRegSigla, BC000414_A33MicrorregiaoMesoUFRegNome
               }
               , new Object[] {
               BC000415_A35MunicipioID
               }
               , new Object[] {
               BC000416_A30MicrorregiaoMesoUFSiglaNome, BC000416_n30MicrorregiaoMesoUFSiglaNome, BC000416_A34MicrorregiaoMesoUFRegSiglaNome, BC000416_n34MicrorregiaoMesoUFRegSiglaNome, BC000416_A23MicrorregiaoID, BC000416_A24MicrorregiaoNome, BC000416_A26MicrorregiaoMesoNome, BC000416_A27MicrorregiaoMesoUFID, BC000416_A28MicrorregiaoMesoUFSigla, BC000416_n28MicrorregiaoMesoUFSigla,
               BC000416_A29MicrorregiaoMesoUFNome, BC000416_n29MicrorregiaoMesoUFNome, BC000416_A31MicrorregiaoMesoUFRegID, BC000416_n31MicrorregiaoMesoUFRegID, BC000416_A32MicrorregiaoMesoUFRegSigla, BC000416_n32MicrorregiaoMesoUFRegSigla, BC000416_A33MicrorregiaoMesoUFRegNome, BC000416_n33MicrorregiaoMesoUFRegNome, BC000416_A25MicrorregiaoMesoID
               }
            }
         );
         AV25Pgmname = "core.microrregiao_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12042 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound4 ;
      private short nIsDirty_4 ;
      private int trnEnded ;
      private int Z23MicrorregiaoID ;
      private int A23MicrorregiaoID ;
      private int AV26GXV1 ;
      private int AV13Insert_MicrorregiaoMesoID ;
      private int Z25MicrorregiaoMesoID ;
      private int A25MicrorregiaoMesoID ;
      private int Z27MicrorregiaoMesoUFID ;
      private int A27MicrorregiaoMesoUFID ;
      private int Z31MicrorregiaoMesoUFRegID ;
      private int A31MicrorregiaoMesoUFRegID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string sMode4 ;
      private bool returnInSub ;
      private bool n30MicrorregiaoMesoUFSiglaNome ;
      private bool n34MicrorregiaoMesoUFRegSiglaNome ;
      private bool n28MicrorregiaoMesoUFSigla ;
      private bool n29MicrorregiaoMesoUFNome ;
      private bool n31MicrorregiaoMesoUFRegID ;
      private bool n32MicrorregiaoMesoUFRegSigla ;
      private bool n33MicrorregiaoMesoUFRegNome ;
      private bool mustCommit ;
      private string Z30MicrorregiaoMesoUFSiglaNome ;
      private string A30MicrorregiaoMesoUFSiglaNome ;
      private string Z34MicrorregiaoMesoUFRegSiglaNome ;
      private string A34MicrorregiaoMesoUFRegSiglaNome ;
      private string Z24MicrorregiaoNome ;
      private string A24MicrorregiaoNome ;
      private string Z26MicrorregiaoMesoNome ;
      private string A26MicrorregiaoMesoNome ;
      private string Z28MicrorregiaoMesoUFSigla ;
      private string A28MicrorregiaoMesoUFSigla ;
      private string Z29MicrorregiaoMesoUFNome ;
      private string A29MicrorregiaoMesoUFNome ;
      private string Z32MicrorregiaoMesoUFRegSigla ;
      private string A32MicrorregiaoMesoUFRegSigla ;
      private string Z33MicrorregiaoMesoUFRegNome ;
      private string A33MicrorregiaoMesoUFRegNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.Sdtmicrorregiao bccore_microrregiao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00047_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] BC00047_n30MicrorregiaoMesoUFSiglaNome ;
      private string[] BC00047_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] BC00047_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] BC00047_A23MicrorregiaoID ;
      private string[] BC00047_A24MicrorregiaoNome ;
      private string[] BC00047_A26MicrorregiaoMesoNome ;
      private int[] BC00047_A27MicrorregiaoMesoUFID ;
      private string[] BC00047_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC00047_n28MicrorregiaoMesoUFSigla ;
      private string[] BC00047_A29MicrorregiaoMesoUFNome ;
      private bool[] BC00047_n29MicrorregiaoMesoUFNome ;
      private int[] BC00047_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC00047_n31MicrorregiaoMesoUFRegID ;
      private string[] BC00047_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC00047_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC00047_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC00047_n33MicrorregiaoMesoUFRegNome ;
      private int[] BC00047_A25MicrorregiaoMesoID ;
      private string[] BC00046_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC00046_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC00046_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC00046_n33MicrorregiaoMesoUFRegNome ;
      private string[] BC00044_A26MicrorregiaoMesoNome ;
      private int[] BC00044_A27MicrorregiaoMesoUFID ;
      private string[] BC00045_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC00045_n28MicrorregiaoMesoUFSigla ;
      private string[] BC00045_A29MicrorregiaoMesoUFNome ;
      private bool[] BC00045_n29MicrorregiaoMesoUFNome ;
      private int[] BC00045_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC00045_n31MicrorregiaoMesoUFRegID ;
      private int[] BC00048_A23MicrorregiaoID ;
      private int[] BC00043_A23MicrorregiaoID ;
      private string[] BC00043_A24MicrorregiaoNome ;
      private int[] BC00043_A25MicrorregiaoMesoID ;
      private string[] BC00043_A26MicrorregiaoMesoNome ;
      private int[] BC00043_A27MicrorregiaoMesoUFID ;
      private string[] BC00043_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC00043_n28MicrorregiaoMesoUFSigla ;
      private string[] BC00043_A29MicrorregiaoMesoUFNome ;
      private bool[] BC00043_n29MicrorregiaoMesoUFNome ;
      private string[] BC00043_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] BC00043_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] BC00043_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC00043_n31MicrorregiaoMesoUFRegID ;
      private string[] BC00043_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC00043_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC00043_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC00043_n33MicrorregiaoMesoUFRegNome ;
      private string[] BC00043_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] BC00043_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] BC00042_A23MicrorregiaoID ;
      private string[] BC00042_A24MicrorregiaoNome ;
      private int[] BC00042_A25MicrorregiaoMesoID ;
      private string[] BC00042_A26MicrorregiaoMesoNome ;
      private int[] BC00042_A27MicrorregiaoMesoUFID ;
      private string[] BC00042_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC00042_n28MicrorregiaoMesoUFSigla ;
      private string[] BC00042_A29MicrorregiaoMesoUFNome ;
      private bool[] BC00042_n29MicrorregiaoMesoUFNome ;
      private string[] BC00042_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] BC00042_n30MicrorregiaoMesoUFSiglaNome ;
      private int[] BC00042_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC00042_n31MicrorregiaoMesoUFRegID ;
      private string[] BC00042_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC00042_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC00042_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC00042_n33MicrorregiaoMesoUFRegNome ;
      private string[] BC00042_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] BC00042_n34MicrorregiaoMesoUFRegSiglaNome ;
      private string[] BC000412_A26MicrorregiaoMesoNome ;
      private int[] BC000412_A27MicrorregiaoMesoUFID ;
      private string[] BC000413_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC000413_n28MicrorregiaoMesoUFSigla ;
      private string[] BC000413_A29MicrorregiaoMesoUFNome ;
      private bool[] BC000413_n29MicrorregiaoMesoUFNome ;
      private int[] BC000413_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC000413_n31MicrorregiaoMesoUFRegID ;
      private string[] BC000414_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC000414_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC000414_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC000414_n33MicrorregiaoMesoUFRegNome ;
      private int[] BC000415_A35MunicipioID ;
      private string[] BC000416_A30MicrorregiaoMesoUFSiglaNome ;
      private bool[] BC000416_n30MicrorregiaoMesoUFSiglaNome ;
      private string[] BC000416_A34MicrorregiaoMesoUFRegSiglaNome ;
      private bool[] BC000416_n34MicrorregiaoMesoUFRegSiglaNome ;
      private int[] BC000416_A23MicrorregiaoID ;
      private string[] BC000416_A24MicrorregiaoNome ;
      private string[] BC000416_A26MicrorregiaoMesoNome ;
      private int[] BC000416_A27MicrorregiaoMesoUFID ;
      private string[] BC000416_A28MicrorregiaoMesoUFSigla ;
      private bool[] BC000416_n28MicrorregiaoMesoUFSigla ;
      private string[] BC000416_A29MicrorregiaoMesoUFNome ;
      private bool[] BC000416_n29MicrorregiaoMesoUFNome ;
      private int[] BC000416_A31MicrorregiaoMesoUFRegID ;
      private bool[] BC000416_n31MicrorregiaoMesoUFRegID ;
      private string[] BC000416_A32MicrorregiaoMesoUFRegSigla ;
      private bool[] BC000416_n32MicrorregiaoMesoUFRegSigla ;
      private string[] BC000416_A33MicrorregiaoMesoUFRegNome ;
      private bool[] BC000416_n33MicrorregiaoMesoUFRegNome ;
      private int[] BC000416_A25MicrorregiaoMesoID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
   }

   public class microrregiao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class microrregiao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
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
        Object[] prmBC00047;
        prmBC00047 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00044;
        prmBC00044 = new Object[] {
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmBC00045;
        prmBC00045 = new Object[] {
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0)
        };
        Object[] prmBC00046;
        prmBC00046 = new Object[] {
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC00048;
        prmBC00048 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00043;
        prmBC00043 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00042;
        prmBC00042 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC00049;
        prmBC00049 = new Object[] {
        new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmBC000410;
        prmBC000410 = new Object[] {
        new ParDef("MicrorregiaoMesoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoMesoUFSigla",GXType.VarChar,2,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSigla",GXType.VarChar,10,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegNome",GXType.VarChar,50,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoMesoUFRegSiglaNome",GXType.VarChar,70,0){Nullable=true} ,
        new ParDef("MicrorregiaoNome",GXType.VarChar,80,0) ,
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0) ,
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000411;
        prmBC000411 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000412;
        prmBC000412 = new Object[] {
        new ParDef("MicrorregiaoMesoID",GXType.Int32,9,0)
        };
        Object[] prmBC000413;
        prmBC000413 = new Object[] {
        new ParDef("MicrorregiaoMesoUFID",GXType.Int32,9,0)
        };
        Object[] prmBC000414;
        prmBC000414 = new Object[] {
        new ParDef("MicrorregiaoMesoUFRegID",GXType.Int32,9,0){Nullable=true}
        };
        Object[] prmBC000415;
        prmBC000415 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        Object[] prmBC000416;
        prmBC000416 = new Object[] {
        new ParDef("MicrorregiaoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00042", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID  FOR UPDATE OF tbibge_microrregiao",true, GxErrorMask.GX_NOMASK, false, this,prmBC00042,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00043", "SELECT MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID, MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFRegSiglaNome FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00043,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00044", "SELECT MesorregiaoNome AS MicrorregiaoMesoNome, MesorregiaoUFID AS MicrorregiaoMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MicrorregiaoMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00044,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00045", "SELECT UFSigla AS MicrorregiaoMesoUFSigla, UFNome AS MicrorregiaoMesoUFNome, UFRegID AS MicrorregiaoMesoUFRegID FROM tbibge_uf WHERE UFID = :MicrorregiaoMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00045,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00046", "SELECT RegiaoSigla AS MicrorregiaoMesoUFRegSigla, RegiaoNome AS MicrorregiaoMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MicrorregiaoMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00046,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00047", "SELECT TM1.MicrorregiaoMesoUFSiglaNome AS MicrorregiaoMesoUFSiglaNome, TM1.MicrorregiaoMesoUFRegSiglaNome AS MicrorregiaoMesoUFRegSiglaNome, TM1.MicrorregiaoID, TM1.MicrorregiaoNome, TM1.MicrorregiaoMesoNome AS MicrorregiaoMesoNome, TM1.MicrorregiaoMesoUFID AS MicrorregiaoMesoUFID, TM1.MicrorregiaoMesoUFSigla AS MicrorregiaoMesoUFSigla, TM1.MicrorregiaoMesoUFNome AS MicrorregiaoMesoUFNome, TM1.MicrorregiaoMesoUFRegID AS MicrorregiaoMesoUFRegID, TM1.MicrorregiaoMesoUFRegSigla AS MicrorregiaoMesoUFRegSigla, TM1.MicrorregiaoMesoUFRegNome AS MicrorregiaoMesoUFRegNome, TM1.MicrorregiaoMesoID AS MicrorregiaoMesoID FROM ((tbibge_microrregiao TM1 INNER JOIN tbibge_mesorregiao T2 ON T2.MesorregiaoID = TM1.MicrorregiaoMesoID) INNER JOIN tbibge_uf T3 ON T3.UFID = T2.MesorregiaoUFID) WHERE TM1.MicrorregiaoID = :MicrorregiaoID ORDER BY TM1.MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00047,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00048", "SELECT MicrorregiaoID FROM tbibge_microrregiao WHERE MicrorregiaoID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00048,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00049", "SAVEPOINT gxupdate;INSERT INTO tbibge_microrregiao(MicrorregiaoMesoNome, MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome, MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoID, MicrorregiaoNome, MicrorregiaoMesoID) VALUES(:MicrorregiaoMesoNome, :MicrorregiaoMesoUFID, :MicrorregiaoMesoUFSigla, :MicrorregiaoMesoUFNome, :MicrorregiaoMesoUFRegID, :MicrorregiaoMesoUFRegSigla, :MicrorregiaoMesoUFRegNome, :MicrorregiaoMesoUFSiglaNome, :MicrorregiaoMesoUFRegSiglaNome, :MicrorregiaoID, :MicrorregiaoNome, :MicrorregiaoMesoID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00049)
           ,new CursorDef("BC000410", "SAVEPOINT gxupdate;UPDATE tbibge_microrregiao SET MicrorregiaoMesoNome=:MicrorregiaoMesoNome, MicrorregiaoMesoUFID=:MicrorregiaoMesoUFID, MicrorregiaoMesoUFSigla=:MicrorregiaoMesoUFSigla, MicrorregiaoMesoUFNome=:MicrorregiaoMesoUFNome, MicrorregiaoMesoUFRegID=:MicrorregiaoMesoUFRegID, MicrorregiaoMesoUFRegSigla=:MicrorregiaoMesoUFRegSigla, MicrorregiaoMesoUFRegNome=:MicrorregiaoMesoUFRegNome, MicrorregiaoMesoUFSiglaNome=:MicrorregiaoMesoUFSiglaNome, MicrorregiaoMesoUFRegSiglaNome=:MicrorregiaoMesoUFRegSiglaNome, MicrorregiaoNome=:MicrorregiaoNome, MicrorregiaoMesoID=:MicrorregiaoMesoID  WHERE MicrorregiaoID = :MicrorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000410)
           ,new CursorDef("BC000411", "SAVEPOINT gxupdate;DELETE FROM tbibge_microrregiao  WHERE MicrorregiaoID = :MicrorregiaoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000411)
           ,new CursorDef("BC000412", "SELECT MesorregiaoNome AS MicrorregiaoMesoNome, MesorregiaoUFID AS MicrorregiaoMesoUFID FROM tbibge_mesorregiao WHERE MesorregiaoID = :MicrorregiaoMesoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000412,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000413", "SELECT UFSigla AS MicrorregiaoMesoUFSigla, UFNome AS MicrorregiaoMesoUFNome, UFRegID AS MicrorregiaoMesoUFRegID FROM tbibge_uf WHERE UFID = :MicrorregiaoMesoUFID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000413,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000414", "SELECT RegiaoSigla AS MicrorregiaoMesoUFRegSigla, RegiaoNome AS MicrorregiaoMesoUFRegNome FROM tbibge_regiao WHERE RegiaoID = :MicrorregiaoMesoUFRegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000414,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000415", "SELECT MunicipioID FROM tbibge_municipio WHERE MunicipioMicroID = :MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000415,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000416", "SELECT TM1.MicrorregiaoMesoUFSiglaNome AS MicrorregiaoMesoUFSiglaNome, TM1.MicrorregiaoMesoUFRegSiglaNome AS MicrorregiaoMesoUFRegSiglaNome, TM1.MicrorregiaoID, TM1.MicrorregiaoNome, TM1.MicrorregiaoMesoNome AS MicrorregiaoMesoNome, TM1.MicrorregiaoMesoUFID AS MicrorregiaoMesoUFID, TM1.MicrorregiaoMesoUFSigla AS MicrorregiaoMesoUFSigla, TM1.MicrorregiaoMesoUFNome AS MicrorregiaoMesoUFNome, TM1.MicrorregiaoMesoUFRegID AS MicrorregiaoMesoUFRegID, TM1.MicrorregiaoMesoUFRegSigla AS MicrorregiaoMesoUFRegSigla, TM1.MicrorregiaoMesoUFRegNome AS MicrorregiaoMesoUFRegNome, TM1.MicrorregiaoMesoID AS MicrorregiaoMesoID FROM ((tbibge_microrregiao TM1 INNER JOIN tbibge_mesorregiao T2 ON T2.MesorregiaoID = TM1.MicrorregiaoMesoID) INNER JOIN tbibge_uf T3 ON T3.UFID = T2.MesorregiaoUFID) WHERE TM1.MicrorregiaoID = :MicrorregiaoID ORDER BY TM1.MicrorregiaoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000416,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((int[]) buf[11])[0] = rslt.getInt(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((int[]) buf[4])[0] = rslt.getInt(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.wasNull(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              ((string[]) buf[9])[0] = rslt.getVarchar(8);
              ((bool[]) buf[10])[0] = rslt.wasNull(8);
              ((int[]) buf[11])[0] = rslt.getInt(9);
              ((bool[]) buf[12])[0] = rslt.wasNull(9);
              ((string[]) buf[13])[0] = rslt.getVarchar(10);
              ((bool[]) buf[14])[0] = rslt.wasNull(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((bool[]) buf[16])[0] = rslt.wasNull(11);
              ((string[]) buf[17])[0] = rslt.getVarchar(12);
              ((bool[]) buf[18])[0] = rslt.wasNull(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((int[]) buf[7])[0] = rslt.getInt(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((int[]) buf[12])[0] = rslt.getInt(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((int[]) buf[18])[0] = rslt.getInt(12);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 11 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((string[]) buf[2])[0] = rslt.getVarchar(2);
              ((bool[]) buf[3])[0] = rslt.wasNull(2);
              ((int[]) buf[4])[0] = rslt.getInt(3);
              ((string[]) buf[5])[0] = rslt.getVarchar(4);
              ((string[]) buf[6])[0] = rslt.getVarchar(5);
              ((int[]) buf[7])[0] = rslt.getInt(6);
              ((string[]) buf[8])[0] = rslt.getVarchar(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((string[]) buf[10])[0] = rslt.getVarchar(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((int[]) buf[12])[0] = rslt.getInt(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((int[]) buf[18])[0] = rslt.getInt(12);
              return;
     }
  }

}

}
