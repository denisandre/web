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
   public class produto_bc : GxSilentTrn, IGxSilentTrn
   {
      public produto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produto_bc( IGxContext context )
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
         ReadRow0S28( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0S28( ) ;
         standaloneModal( ) ;
         AddRow0S28( ) ;
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
            E110S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z220PrdID = A220PrdID;
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S28( ) ;
            }
            else
            {
               CheckExtendedTable0S28( ) ;
               if ( AnyError == 0 )
               {
                  ZM0S28( 17) ;
               }
               CloseExtendedTableCursors0S28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120S2( )
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
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "PrdTipoID") == 0 )
               {
                  AV13Insert_PrdTipoID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
               }
               AV26GXV1 = (int)(AV26GXV1+1);
            }
         }
      }

      protected void E110S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV24AuditingObject,  AV25Pgmname) ;
      }

      protected void ZM0S28( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z621PrdDelDataHora = A621PrdDelDataHora;
            Z622PrdDelData = A622PrdDelData;
            Z623PrdDelHora = A623PrdDelHora;
            Z624PrdDelUsuId = A624PrdDelUsuId;
            Z625PrdDelUsuNome = A625PrdDelUsuNome;
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z223PrdInsData = A223PrdInsData;
            Z224PrdInsHora = A224PrdInsHora;
            Z225PrdInsDataHora = A225PrdInsDataHora;
            Z226PrdInsUsuID = A226PrdInsUsuID;
            Z227PrdUpdData = A227PrdUpdData;
            Z228PrdUpdHora = A228PrdUpdHora;
            Z229PrdUpdDataHora = A229PrdUpdDataHora;
            Z230PrdUpdUsuID = A230PrdUpdUsuID;
            Z231PrdAtivo = A231PrdAtivo;
            Z620PrdDel = A620PrdDel;
            Z232PrdTipoID = A232PrdTipoID;
         }
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            Z233PrdTipoSigla = A233PrdTipoSigla;
            Z234PrdTipoNome = A234PrdTipoNome;
         }
         if ( GX_JID == -15 )
         {
            Z220PrdID = A220PrdID;
            Z621PrdDelDataHora = A621PrdDelDataHora;
            Z622PrdDelData = A622PrdDelData;
            Z623PrdDelHora = A623PrdDelHora;
            Z624PrdDelUsuId = A624PrdDelUsuId;
            Z625PrdDelUsuNome = A625PrdDelUsuNome;
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z223PrdInsData = A223PrdInsData;
            Z224PrdInsHora = A224PrdInsHora;
            Z225PrdInsDataHora = A225PrdInsDataHora;
            Z226PrdInsUsuID = A226PrdInsUsuID;
            Z227PrdUpdData = A227PrdUpdData;
            Z228PrdUpdHora = A228PrdUpdHora;
            Z229PrdUpdDataHora = A229PrdUpdDataHora;
            Z230PrdUpdUsuID = A230PrdUpdUsuID;
            Z231PrdAtivo = A231PrdAtivo;
            Z620PrdDel = A620PrdDel;
            Z232PrdTipoID = A232PrdTipoID;
            Z233PrdTipoSigla = A233PrdTipoSigla;
            Z234PrdTipoNome = A234PrdTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV25Pgmname = "core.Produto_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A220PrdID) )
         {
            A220PrdID = Guid.NewGuid( );
         }
         if ( IsIns( )  && (false==A231PrdAtivo) && ( Gx_BScreen == 0 ) )
         {
            A231PrdAtivo = true;
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0S28( )
      {
         /* Using cursor BC000S5 */
         pr_default.execute(3, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
            A621PrdDelDataHora = BC000S5_A621PrdDelDataHora[0];
            n621PrdDelDataHora = BC000S5_n621PrdDelDataHora[0];
            A622PrdDelData = BC000S5_A622PrdDelData[0];
            n622PrdDelData = BC000S5_n622PrdDelData[0];
            A623PrdDelHora = BC000S5_A623PrdDelHora[0];
            n623PrdDelHora = BC000S5_n623PrdDelHora[0];
            A624PrdDelUsuId = BC000S5_A624PrdDelUsuId[0];
            n624PrdDelUsuId = BC000S5_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = BC000S5_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = BC000S5_n625PrdDelUsuNome[0];
            A221PrdCodigo = BC000S5_A221PrdCodigo[0];
            A222PrdNome = BC000S5_A222PrdNome[0];
            A223PrdInsData = BC000S5_A223PrdInsData[0];
            A224PrdInsHora = BC000S5_A224PrdInsHora[0];
            A225PrdInsDataHora = BC000S5_A225PrdInsDataHora[0];
            A226PrdInsUsuID = BC000S5_A226PrdInsUsuID[0];
            n226PrdInsUsuID = BC000S5_n226PrdInsUsuID[0];
            A227PrdUpdData = BC000S5_A227PrdUpdData[0];
            n227PrdUpdData = BC000S5_n227PrdUpdData[0];
            A228PrdUpdHora = BC000S5_A228PrdUpdHora[0];
            n228PrdUpdHora = BC000S5_n228PrdUpdHora[0];
            A229PrdUpdDataHora = BC000S5_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = BC000S5_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = BC000S5_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = BC000S5_n230PrdUpdUsuID[0];
            A231PrdAtivo = BC000S5_A231PrdAtivo[0];
            A233PrdTipoSigla = BC000S5_A233PrdTipoSigla[0];
            A234PrdTipoNome = BC000S5_A234PrdTipoNome[0];
            A620PrdDel = BC000S5_A620PrdDel[0];
            A232PrdTipoID = BC000S5_A232PrdTipoID[0];
            ZM0S28( -15) ;
         }
         pr_default.close(3);
         OnLoadActions0S28( ) ;
      }

      protected void OnLoadActions0S28( )
      {
      }

      protected void CheckExtendedTable0S28( )
      {
         nIsDirty_28 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000S6 */
         pr_default.execute(4, new Object[] {A221PrdCodigo, A220PrdID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         /* Using cursor BC000S4 */
         pr_default.execute(2, new Object[] {A232PrdTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Produto -> Produto'.", "ForeignKeyNotFound", 1, "PRDTIPOID");
            AnyError = 1;
         }
         A233PrdTipoSigla = BC000S4_A233PrdTipoSigla[0];
         A234PrdTipoNome = BC000S4_A234PrdTipoNome[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0S28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0S28( )
      {
         /* Using cursor BC000S7 */
         pr_default.execute(5, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000S3 */
         pr_default.execute(1, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S28( 15) ;
            RcdFound28 = 1;
            A220PrdID = BC000S3_A220PrdID[0];
            A621PrdDelDataHora = BC000S3_A621PrdDelDataHora[0];
            n621PrdDelDataHora = BC000S3_n621PrdDelDataHora[0];
            A622PrdDelData = BC000S3_A622PrdDelData[0];
            n622PrdDelData = BC000S3_n622PrdDelData[0];
            A623PrdDelHora = BC000S3_A623PrdDelHora[0];
            n623PrdDelHora = BC000S3_n623PrdDelHora[0];
            A624PrdDelUsuId = BC000S3_A624PrdDelUsuId[0];
            n624PrdDelUsuId = BC000S3_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = BC000S3_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = BC000S3_n625PrdDelUsuNome[0];
            A221PrdCodigo = BC000S3_A221PrdCodigo[0];
            A222PrdNome = BC000S3_A222PrdNome[0];
            A223PrdInsData = BC000S3_A223PrdInsData[0];
            A224PrdInsHora = BC000S3_A224PrdInsHora[0];
            A225PrdInsDataHora = BC000S3_A225PrdInsDataHora[0];
            A226PrdInsUsuID = BC000S3_A226PrdInsUsuID[0];
            n226PrdInsUsuID = BC000S3_n226PrdInsUsuID[0];
            A227PrdUpdData = BC000S3_A227PrdUpdData[0];
            n227PrdUpdData = BC000S3_n227PrdUpdData[0];
            A228PrdUpdHora = BC000S3_A228PrdUpdHora[0];
            n228PrdUpdHora = BC000S3_n228PrdUpdHora[0];
            A229PrdUpdDataHora = BC000S3_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = BC000S3_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = BC000S3_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = BC000S3_n230PrdUpdUsuID[0];
            A231PrdAtivo = BC000S3_A231PrdAtivo[0];
            A620PrdDel = BC000S3_A620PrdDel[0];
            A232PrdTipoID = BC000S3_A232PrdTipoID[0];
            O620PrdDel = A620PrdDel;
            Z220PrdID = A220PrdID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0S28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0S28( ) ;
            }
            Gx_mode = sMode28;
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0S28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode28;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S28( ) ;
         if ( RcdFound28 == 0 )
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
         CONFIRM_0S0( ) ;
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

      protected void CheckOptimisticConcurrency0S28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000S2 */
            pr_default.execute(0, new Object[] {A220PrdID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z621PrdDelDataHora != BC000S2_A621PrdDelDataHora[0] ) || ( Z622PrdDelData != BC000S2_A622PrdDelData[0] ) || ( Z623PrdDelHora != BC000S2_A623PrdDelHora[0] ) || ( StringUtil.StrCmp(Z624PrdDelUsuId, BC000S2_A624PrdDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z625PrdDelUsuNome, BC000S2_A625PrdDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z221PrdCodigo, BC000S2_A221PrdCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z222PrdNome, BC000S2_A222PrdNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z223PrdInsData ) != DateTimeUtil.ResetTime ( BC000S2_A223PrdInsData[0] ) ) || ( Z224PrdInsHora != BC000S2_A224PrdInsHora[0] ) || ( Z225PrdInsDataHora != BC000S2_A225PrdInsDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z226PrdInsUsuID, BC000S2_A226PrdInsUsuID[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z227PrdUpdData ) != DateTimeUtil.ResetTime ( BC000S2_A227PrdUpdData[0] ) ) || ( Z228PrdUpdHora != BC000S2_A228PrdUpdHora[0] ) || ( Z229PrdUpdDataHora != BC000S2_A229PrdUpdDataHora[0] ) || ( StringUtil.StrCmp(Z230PrdUpdUsuID, BC000S2_A230PrdUpdUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z231PrdAtivo != BC000S2_A231PrdAtivo[0] ) || ( Z620PrdDel != BC000S2_A620PrdDel[0] ) || ( Z232PrdTipoID != BC000S2_A232PrdTipoID[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S28( )
      {
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S28( 0) ;
            CheckOptimisticConcurrency0S28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S8 */
                     pr_default.execute(6, new Object[] {A220PrdID, n621PrdDelDataHora, A621PrdDelDataHora, n622PrdDelData, A622PrdDelData, n623PrdDelHora, A623PrdDelHora, n624PrdDelUsuId, A624PrdDelUsuId, n625PrdDelUsuNome, A625PrdDelUsuNome, A221PrdCodigo, A222PrdNome, A223PrdInsData, A224PrdInsHora, A225PrdInsDataHora, n226PrdInsUsuID, A226PrdInsUsuID, n227PrdUpdData, A227PrdUpdData, n228PrdUpdHora, A228PrdUpdHora, n229PrdUpdDataHora, A229PrdUpdDataHora, n230PrdUpdUsuID, A230PrdUpdUsuID, A231PrdAtivo, A620PrdDel, A232PrdTipoID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produto");
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
               Load0S28( ) ;
            }
            EndLevel0S28( ) ;
         }
         CloseExtendedTableCursors0S28( ) ;
      }

      protected void Update0S28( )
      {
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000S9 */
                     pr_default.execute(7, new Object[] {n621PrdDelDataHora, A621PrdDelDataHora, n622PrdDelData, A622PrdDelData, n623PrdDelHora, A623PrdDelHora, n624PrdDelUsuId, A624PrdDelUsuId, n625PrdDelUsuNome, A625PrdDelUsuNome, A221PrdCodigo, A222PrdNome, A223PrdInsData, A224PrdInsHora, A225PrdInsDataHora, n226PrdInsUsuID, A226PrdInsUsuID, n227PrdUpdData, A227PrdUpdData, n228PrdUpdHora, A228PrdUpdHora, n229PrdUpdDataHora, A229PrdUpdDataHora, n230PrdUpdUsuID, A230PrdUpdUsuID, A231PrdAtivo, A620PrdDel, A232PrdTipoID, A220PrdID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produto");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_produtoupdateredundancy(context ).execute( ref  A220PrdID) ;
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
            EndLevel0S28( ) ;
         }
         CloseExtendedTableCursors0S28( ) ;
      }

      protected void DeferredUpdate0S28( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S28( ) ;
            AfterConfirm0S28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000S10 */
                  pr_default.execute(8, new Object[] {A220PrdID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_produto");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0S28( ) ;
         Gx_mode = sMode28;
      }

      protected void OnDeleteControls0S28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC000S11 */
            pr_default.execute(9, new Object[] {A232PrdTipoID});
            A233PrdTipoSigla = BC000S11_A233PrdTipoSigla[0];
            A234PrdTipoNome = BC000S11_A234PrdTipoNome[0];
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC000S12 */
            pr_default.execute(10, new Object[] {A220PrdID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0S28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S28( ) ;
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

      public void ScanKeyStart0S28( )
      {
         /* Scan By routine */
         /* Using cursor BC000S13 */
         pr_default.execute(11, new Object[] {A220PrdID});
         RcdFound28 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A220PrdID = BC000S13_A220PrdID[0];
            A621PrdDelDataHora = BC000S13_A621PrdDelDataHora[0];
            n621PrdDelDataHora = BC000S13_n621PrdDelDataHora[0];
            A622PrdDelData = BC000S13_A622PrdDelData[0];
            n622PrdDelData = BC000S13_n622PrdDelData[0];
            A623PrdDelHora = BC000S13_A623PrdDelHora[0];
            n623PrdDelHora = BC000S13_n623PrdDelHora[0];
            A624PrdDelUsuId = BC000S13_A624PrdDelUsuId[0];
            n624PrdDelUsuId = BC000S13_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = BC000S13_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = BC000S13_n625PrdDelUsuNome[0];
            A221PrdCodigo = BC000S13_A221PrdCodigo[0];
            A222PrdNome = BC000S13_A222PrdNome[0];
            A223PrdInsData = BC000S13_A223PrdInsData[0];
            A224PrdInsHora = BC000S13_A224PrdInsHora[0];
            A225PrdInsDataHora = BC000S13_A225PrdInsDataHora[0];
            A226PrdInsUsuID = BC000S13_A226PrdInsUsuID[0];
            n226PrdInsUsuID = BC000S13_n226PrdInsUsuID[0];
            A227PrdUpdData = BC000S13_A227PrdUpdData[0];
            n227PrdUpdData = BC000S13_n227PrdUpdData[0];
            A228PrdUpdHora = BC000S13_A228PrdUpdHora[0];
            n228PrdUpdHora = BC000S13_n228PrdUpdHora[0];
            A229PrdUpdDataHora = BC000S13_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = BC000S13_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = BC000S13_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = BC000S13_n230PrdUpdUsuID[0];
            A231PrdAtivo = BC000S13_A231PrdAtivo[0];
            A233PrdTipoSigla = BC000S13_A233PrdTipoSigla[0];
            A234PrdTipoNome = BC000S13_A234PrdTipoNome[0];
            A620PrdDel = BC000S13_A620PrdDel[0];
            A232PrdTipoID = BC000S13_A232PrdTipoID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0S28( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound28 = 0;
         ScanKeyLoad0S28( ) ;
      }

      protected void ScanKeyLoad0S28( )
      {
         sMode28 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound28 = 1;
            A220PrdID = BC000S13_A220PrdID[0];
            A621PrdDelDataHora = BC000S13_A621PrdDelDataHora[0];
            n621PrdDelDataHora = BC000S13_n621PrdDelDataHora[0];
            A622PrdDelData = BC000S13_A622PrdDelData[0];
            n622PrdDelData = BC000S13_n622PrdDelData[0];
            A623PrdDelHora = BC000S13_A623PrdDelHora[0];
            n623PrdDelHora = BC000S13_n623PrdDelHora[0];
            A624PrdDelUsuId = BC000S13_A624PrdDelUsuId[0];
            n624PrdDelUsuId = BC000S13_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = BC000S13_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = BC000S13_n625PrdDelUsuNome[0];
            A221PrdCodigo = BC000S13_A221PrdCodigo[0];
            A222PrdNome = BC000S13_A222PrdNome[0];
            A223PrdInsData = BC000S13_A223PrdInsData[0];
            A224PrdInsHora = BC000S13_A224PrdInsHora[0];
            A225PrdInsDataHora = BC000S13_A225PrdInsDataHora[0];
            A226PrdInsUsuID = BC000S13_A226PrdInsUsuID[0];
            n226PrdInsUsuID = BC000S13_n226PrdInsUsuID[0];
            A227PrdUpdData = BC000S13_A227PrdUpdData[0];
            n227PrdUpdData = BC000S13_n227PrdUpdData[0];
            A228PrdUpdHora = BC000S13_A228PrdUpdHora[0];
            n228PrdUpdHora = BC000S13_n228PrdUpdHora[0];
            A229PrdUpdDataHora = BC000S13_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = BC000S13_n229PrdUpdDataHora[0];
            A230PrdUpdUsuID = BC000S13_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = BC000S13_n230PrdUpdUsuID[0];
            A231PrdAtivo = BC000S13_A231PrdAtivo[0];
            A233PrdTipoSigla = BC000S13_A233PrdTipoSigla[0];
            A234PrdTipoNome = BC000S13_A234PrdTipoNome[0];
            A620PrdDel = BC000S13_A620PrdDel[0];
            A232PrdTipoID = BC000S13_A232PrdTipoID[0];
         }
         Gx_mode = sMode28;
      }

      protected void ScanKeyEnd0S28( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0S28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S28( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A621PrdDelDataHora = DateTimeUtil.NowMS( context);
            n621PrdDelDataHora = false;
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A624PrdDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n624PrdDelUsuId = false;
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A625PrdDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n625PrdDelUsuNome = false;
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A622PrdDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A621PrdDelDataHora) ) ;
            n622PrdDelData = false;
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A623PrdDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A621PrdDelDataHora));
            n623PrdDelHora = false;
         }
      }

      protected void BeforeDelete0S28( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
      }

      protected void BeforeComplete0S28( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0S28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S28( )
      {
      }

      protected void send_integrity_lvl_hashes0S28( )
      {
      }

      protected void AddRow0S28( )
      {
         VarsToRow28( bccore_Produto) ;
      }

      protected void ReadRow0S28( )
      {
         RowToVars28( bccore_Produto, 1) ;
      }

      protected void InitializeNonKey0S28( )
      {
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         n621PrdDelDataHora = false;
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         n622PrdDelData = false;
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         n623PrdDelHora = false;
         A624PrdDelUsuId = "";
         n624PrdDelUsuId = false;
         A625PrdDelUsuNome = "";
         n625PrdDelUsuNome = false;
         A221PrdCodigo = "";
         A222PrdNome = "";
         A223PrdInsData = DateTime.MinValue;
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A226PrdInsUsuID = "";
         n226PrdInsUsuID = false;
         A227PrdUpdData = DateTime.MinValue;
         n227PrdUpdData = false;
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         n228PrdUpdHora = false;
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         n229PrdUpdDataHora = false;
         A230PrdUpdUsuID = "";
         n230PrdUpdUsuID = false;
         A232PrdTipoID = 0;
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         A620PrdDel = false;
         A231PrdAtivo = true;
         O620PrdDel = A620PrdDel;
         Z621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         Z622PrdDelData = (DateTime)(DateTime.MinValue);
         Z623PrdDelHora = (DateTime)(DateTime.MinValue);
         Z624PrdDelUsuId = "";
         Z625PrdDelUsuNome = "";
         Z221PrdCodigo = "";
         Z222PrdNome = "";
         Z223PrdInsData = DateTime.MinValue;
         Z224PrdInsHora = (DateTime)(DateTime.MinValue);
         Z225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         Z226PrdInsUsuID = "";
         Z227PrdUpdData = DateTime.MinValue;
         Z228PrdUpdHora = (DateTime)(DateTime.MinValue);
         Z229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         Z230PrdUpdUsuID = "";
         Z231PrdAtivo = false;
         Z620PrdDel = false;
         Z232PrdTipoID = 0;
      }

      protected void InitAll0S28( )
      {
         A220PrdID = Guid.NewGuid( );
         InitializeNonKey0S28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A231PrdAtivo = i231PrdAtivo;
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

      public void VarsToRow28( GeneXus.Programs.core.SdtProduto obj28 )
      {
         obj28.gxTpr_Mode = Gx_mode;
         obj28.gxTpr_Prddeldatahora = A621PrdDelDataHora;
         obj28.gxTpr_Prddeldata = A622PrdDelData;
         obj28.gxTpr_Prddelhora = A623PrdDelHora;
         obj28.gxTpr_Prddelusuid = A624PrdDelUsuId;
         obj28.gxTpr_Prddelusunome = A625PrdDelUsuNome;
         obj28.gxTpr_Prdcodigo = A221PrdCodigo;
         obj28.gxTpr_Prdnome = A222PrdNome;
         obj28.gxTpr_Prdinsdata = A223PrdInsData;
         obj28.gxTpr_Prdinshora = A224PrdInsHora;
         obj28.gxTpr_Prdinsdatahora = A225PrdInsDataHora;
         obj28.gxTpr_Prdinsusuid = A226PrdInsUsuID;
         obj28.gxTpr_Prdupddata = A227PrdUpdData;
         obj28.gxTpr_Prdupdhora = A228PrdUpdHora;
         obj28.gxTpr_Prdupddatahora = A229PrdUpdDataHora;
         obj28.gxTpr_Prdupdusuid = A230PrdUpdUsuID;
         obj28.gxTpr_Prdtipoid = A232PrdTipoID;
         obj28.gxTpr_Prdtiposigla = A233PrdTipoSigla;
         obj28.gxTpr_Prdtiponome = A234PrdTipoNome;
         obj28.gxTpr_Prddel = A620PrdDel;
         obj28.gxTpr_Prdativo = A231PrdAtivo;
         obj28.gxTpr_Prdid = A220PrdID;
         obj28.gxTpr_Prdid_Z = Z220PrdID;
         obj28.gxTpr_Prdcodigo_Z = Z221PrdCodigo;
         obj28.gxTpr_Prdnome_Z = Z222PrdNome;
         obj28.gxTpr_Prdinsdata_Z = Z223PrdInsData;
         obj28.gxTpr_Prdinshora_Z = Z224PrdInsHora;
         obj28.gxTpr_Prdinsdatahora_Z = Z225PrdInsDataHora;
         obj28.gxTpr_Prdinsusuid_Z = Z226PrdInsUsuID;
         obj28.gxTpr_Prdupddata_Z = Z227PrdUpdData;
         obj28.gxTpr_Prdupdhora_Z = Z228PrdUpdHora;
         obj28.gxTpr_Prdupddatahora_Z = Z229PrdUpdDataHora;
         obj28.gxTpr_Prdupdusuid_Z = Z230PrdUpdUsuID;
         obj28.gxTpr_Prdativo_Z = Z231PrdAtivo;
         obj28.gxTpr_Prdtipoid_Z = Z232PrdTipoID;
         obj28.gxTpr_Prdtiposigla_Z = Z233PrdTipoSigla;
         obj28.gxTpr_Prdtiponome_Z = Z234PrdTipoNome;
         obj28.gxTpr_Prddel_Z = Z620PrdDel;
         obj28.gxTpr_Prddeldatahora_Z = Z621PrdDelDataHora;
         obj28.gxTpr_Prddeldata_Z = Z622PrdDelData;
         obj28.gxTpr_Prddelhora_Z = Z623PrdDelHora;
         obj28.gxTpr_Prddelusuid_Z = Z624PrdDelUsuId;
         obj28.gxTpr_Prddelusunome_Z = Z625PrdDelUsuNome;
         obj28.gxTpr_Prdinsusuid_N = (short)(Convert.ToInt16(n226PrdInsUsuID));
         obj28.gxTpr_Prdupddata_N = (short)(Convert.ToInt16(n227PrdUpdData));
         obj28.gxTpr_Prdupdhora_N = (short)(Convert.ToInt16(n228PrdUpdHora));
         obj28.gxTpr_Prdupddatahora_N = (short)(Convert.ToInt16(n229PrdUpdDataHora));
         obj28.gxTpr_Prdupdusuid_N = (short)(Convert.ToInt16(n230PrdUpdUsuID));
         obj28.gxTpr_Prddeldatahora_N = (short)(Convert.ToInt16(n621PrdDelDataHora));
         obj28.gxTpr_Prddeldata_N = (short)(Convert.ToInt16(n622PrdDelData));
         obj28.gxTpr_Prddelhora_N = (short)(Convert.ToInt16(n623PrdDelHora));
         obj28.gxTpr_Prddelusuid_N = (short)(Convert.ToInt16(n624PrdDelUsuId));
         obj28.gxTpr_Prddelusunome_N = (short)(Convert.ToInt16(n625PrdDelUsuNome));
         obj28.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow28( GeneXus.Programs.core.SdtProduto obj28 )
      {
         obj28.gxTpr_Prdid = A220PrdID;
         return  ;
      }

      public void RowToVars28( GeneXus.Programs.core.SdtProduto obj28 ,
                               int forceLoad )
      {
         Gx_mode = obj28.gxTpr_Mode;
         A621PrdDelDataHora = obj28.gxTpr_Prddeldatahora;
         n621PrdDelDataHora = false;
         A622PrdDelData = obj28.gxTpr_Prddeldata;
         n622PrdDelData = false;
         A623PrdDelHora = obj28.gxTpr_Prddelhora;
         n623PrdDelHora = false;
         A624PrdDelUsuId = obj28.gxTpr_Prddelusuid;
         n624PrdDelUsuId = false;
         A625PrdDelUsuNome = obj28.gxTpr_Prddelusunome;
         n625PrdDelUsuNome = false;
         A221PrdCodigo = obj28.gxTpr_Prdcodigo;
         A222PrdNome = obj28.gxTpr_Prdnome;
         A223PrdInsData = obj28.gxTpr_Prdinsdata;
         A224PrdInsHora = obj28.gxTpr_Prdinshora;
         A225PrdInsDataHora = obj28.gxTpr_Prdinsdatahora;
         A226PrdInsUsuID = obj28.gxTpr_Prdinsusuid;
         n226PrdInsUsuID = false;
         A227PrdUpdData = obj28.gxTpr_Prdupddata;
         n227PrdUpdData = false;
         A228PrdUpdHora = obj28.gxTpr_Prdupdhora;
         n228PrdUpdHora = false;
         A229PrdUpdDataHora = obj28.gxTpr_Prdupddatahora;
         n229PrdUpdDataHora = false;
         A230PrdUpdUsuID = obj28.gxTpr_Prdupdusuid;
         n230PrdUpdUsuID = false;
         A232PrdTipoID = obj28.gxTpr_Prdtipoid;
         A233PrdTipoSigla = obj28.gxTpr_Prdtiposigla;
         A234PrdTipoNome = obj28.gxTpr_Prdtiponome;
         A620PrdDel = obj28.gxTpr_Prddel;
         A231PrdAtivo = obj28.gxTpr_Prdativo;
         A220PrdID = obj28.gxTpr_Prdid;
         Z220PrdID = obj28.gxTpr_Prdid_Z;
         Z221PrdCodigo = obj28.gxTpr_Prdcodigo_Z;
         Z222PrdNome = obj28.gxTpr_Prdnome_Z;
         Z223PrdInsData = obj28.gxTpr_Prdinsdata_Z;
         Z224PrdInsHora = obj28.gxTpr_Prdinshora_Z;
         Z225PrdInsDataHora = obj28.gxTpr_Prdinsdatahora_Z;
         Z226PrdInsUsuID = obj28.gxTpr_Prdinsusuid_Z;
         Z227PrdUpdData = obj28.gxTpr_Prdupddata_Z;
         Z228PrdUpdHora = obj28.gxTpr_Prdupdhora_Z;
         Z229PrdUpdDataHora = obj28.gxTpr_Prdupddatahora_Z;
         Z230PrdUpdUsuID = obj28.gxTpr_Prdupdusuid_Z;
         Z231PrdAtivo = obj28.gxTpr_Prdativo_Z;
         Z232PrdTipoID = obj28.gxTpr_Prdtipoid_Z;
         Z233PrdTipoSigla = obj28.gxTpr_Prdtiposigla_Z;
         Z234PrdTipoNome = obj28.gxTpr_Prdtiponome_Z;
         Z620PrdDel = obj28.gxTpr_Prddel_Z;
         O620PrdDel = obj28.gxTpr_Prddel_Z;
         Z621PrdDelDataHora = obj28.gxTpr_Prddeldatahora_Z;
         Z622PrdDelData = obj28.gxTpr_Prddeldata_Z;
         Z623PrdDelHora = obj28.gxTpr_Prddelhora_Z;
         Z624PrdDelUsuId = obj28.gxTpr_Prddelusuid_Z;
         Z625PrdDelUsuNome = obj28.gxTpr_Prddelusunome_Z;
         n226PrdInsUsuID = (bool)(Convert.ToBoolean(obj28.gxTpr_Prdinsusuid_N));
         n227PrdUpdData = (bool)(Convert.ToBoolean(obj28.gxTpr_Prdupddata_N));
         n228PrdUpdHora = (bool)(Convert.ToBoolean(obj28.gxTpr_Prdupdhora_N));
         n229PrdUpdDataHora = (bool)(Convert.ToBoolean(obj28.gxTpr_Prdupddatahora_N));
         n230PrdUpdUsuID = (bool)(Convert.ToBoolean(obj28.gxTpr_Prdupdusuid_N));
         n621PrdDelDataHora = (bool)(Convert.ToBoolean(obj28.gxTpr_Prddeldatahora_N));
         n622PrdDelData = (bool)(Convert.ToBoolean(obj28.gxTpr_Prddeldata_N));
         n623PrdDelHora = (bool)(Convert.ToBoolean(obj28.gxTpr_Prddelhora_N));
         n624PrdDelUsuId = (bool)(Convert.ToBoolean(obj28.gxTpr_Prddelusuid_N));
         n625PrdDelUsuNome = (bool)(Convert.ToBoolean(obj28.gxTpr_Prddelusunome_N));
         Gx_mode = obj28.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A220PrdID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0S28( ) ;
         ScanKeyStart0S28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z220PrdID = A220PrdID;
            O620PrdDel = A620PrdDel;
         }
         ZM0S28( -15) ;
         OnLoadActions0S28( ) ;
         AddRow0S28( ) ;
         ScanKeyEnd0S28( ) ;
         if ( RcdFound28 == 0 )
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
         RowToVars28( bccore_Produto, 0) ;
         ScanKeyStart0S28( ) ;
         if ( RcdFound28 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z220PrdID = A220PrdID;
            O620PrdDel = A620PrdDel;
         }
         ZM0S28( -15) ;
         OnLoadActions0S28( ) ;
         AddRow0S28( ) ;
         ScanKeyEnd0S28( ) ;
         if ( RcdFound28 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0S28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0S28( ) ;
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A220PrdID != Z220PrdID )
               {
                  A220PrdID = Z220PrdID;
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
                  Update0S28( ) ;
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
                  if ( A220PrdID != Z220PrdID )
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
                        Insert0S28( ) ;
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
                        Insert0S28( ) ;
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
         RowToVars28( bccore_Produto, 1) ;
         SaveImpl( ) ;
         VarsToRow28( bccore_Produto) ;
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
         RowToVars28( bccore_Produto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S28( ) ;
         AfterTrn( ) ;
         VarsToRow28( bccore_Produto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow28( bccore_Produto) ;
         }
         else
         {
            GeneXus.Programs.core.SdtProduto auxBC = new GeneXus.Programs.core.SdtProduto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A220PrdID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Produto);
               auxBC.Save();
               bccore_Produto.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars28( bccore_Produto, 1) ;
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
         RowToVars28( bccore_Produto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0S28( ) ;
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
               VarsToRow28( bccore_Produto) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow28( bccore_Produto) ;
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
         RowToVars28( bccore_Produto, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0S28( ) ;
         if ( RcdFound28 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A220PrdID != Z220PrdID )
            {
               A220PrdID = Z220PrdID;
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
            if ( A220PrdID != Z220PrdID )
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
         context.RollbackDataStores("core.produto_bc",pr_default);
         VarsToRow28( bccore_Produto) ;
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
         Gx_mode = bccore_Produto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Produto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Produto )
         {
            bccore_Produto = (GeneXus.Programs.core.SdtProduto)(sdt);
            if ( StringUtil.StrCmp(bccore_Produto.gxTpr_Mode, "") == 0 )
            {
               bccore_Produto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow28( bccore_Produto) ;
            }
            else
            {
               RowToVars28( bccore_Produto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Produto.gxTpr_Mode, "") == 0 )
            {
               bccore_Produto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars28( bccore_Produto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtProduto Produto_BC
      {
         get {
            return bccore_Produto ;
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
            return "produto_Execute" ;
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
         Z220PrdID = Guid.Empty;
         A220PrdID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV25Pgmname = "";
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         Z621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         Z622PrdDelData = (DateTime)(DateTime.MinValue);
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         Z623PrdDelHora = (DateTime)(DateTime.MinValue);
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         Z624PrdDelUsuId = "";
         A624PrdDelUsuId = "";
         Z625PrdDelUsuNome = "";
         A625PrdDelUsuNome = "";
         Z221PrdCodigo = "";
         A221PrdCodigo = "";
         Z222PrdNome = "";
         A222PrdNome = "";
         Z223PrdInsData = DateTime.MinValue;
         A223PrdInsData = DateTime.MinValue;
         Z224PrdInsHora = (DateTime)(DateTime.MinValue);
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         Z225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         Z226PrdInsUsuID = "";
         A226PrdInsUsuID = "";
         Z227PrdUpdData = DateTime.MinValue;
         A227PrdUpdData = DateTime.MinValue;
         Z228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         Z229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         Z230PrdUpdUsuID = "";
         A230PrdUpdUsuID = "";
         Z233PrdTipoSigla = "";
         A233PrdTipoSigla = "";
         Z234PrdTipoNome = "";
         A234PrdTipoNome = "";
         BC000S5_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S5_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n621PrdDelDataHora = new bool[] {false} ;
         BC000S5_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n622PrdDelData = new bool[] {false} ;
         BC000S5_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n623PrdDelHora = new bool[] {false} ;
         BC000S5_A624PrdDelUsuId = new string[] {""} ;
         BC000S5_n624PrdDelUsuId = new bool[] {false} ;
         BC000S5_A625PrdDelUsuNome = new string[] {""} ;
         BC000S5_n625PrdDelUsuNome = new bool[] {false} ;
         BC000S5_A221PrdCodigo = new string[] {""} ;
         BC000S5_A222PrdNome = new string[] {""} ;
         BC000S5_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         BC000S5_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_A226PrdInsUsuID = new string[] {""} ;
         BC000S5_n226PrdInsUsuID = new bool[] {false} ;
         BC000S5_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n227PrdUpdData = new bool[] {false} ;
         BC000S5_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n228PrdUpdHora = new bool[] {false} ;
         BC000S5_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S5_n229PrdUpdDataHora = new bool[] {false} ;
         BC000S5_A230PrdUpdUsuID = new string[] {""} ;
         BC000S5_n230PrdUpdUsuID = new bool[] {false} ;
         BC000S5_A231PrdAtivo = new bool[] {false} ;
         BC000S5_A233PrdTipoSigla = new string[] {""} ;
         BC000S5_A234PrdTipoNome = new string[] {""} ;
         BC000S5_A620PrdDel = new bool[] {false} ;
         BC000S5_A232PrdTipoID = new int[1] ;
         BC000S6_A221PrdCodigo = new string[] {""} ;
         BC000S4_A233PrdTipoSigla = new string[] {""} ;
         BC000S4_A234PrdTipoNome = new string[] {""} ;
         BC000S7_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S3_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S3_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n621PrdDelDataHora = new bool[] {false} ;
         BC000S3_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n622PrdDelData = new bool[] {false} ;
         BC000S3_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n623PrdDelHora = new bool[] {false} ;
         BC000S3_A624PrdDelUsuId = new string[] {""} ;
         BC000S3_n624PrdDelUsuId = new bool[] {false} ;
         BC000S3_A625PrdDelUsuNome = new string[] {""} ;
         BC000S3_n625PrdDelUsuNome = new bool[] {false} ;
         BC000S3_A221PrdCodigo = new string[] {""} ;
         BC000S3_A222PrdNome = new string[] {""} ;
         BC000S3_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         BC000S3_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_A226PrdInsUsuID = new string[] {""} ;
         BC000S3_n226PrdInsUsuID = new bool[] {false} ;
         BC000S3_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n227PrdUpdData = new bool[] {false} ;
         BC000S3_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n228PrdUpdHora = new bool[] {false} ;
         BC000S3_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S3_n229PrdUpdDataHora = new bool[] {false} ;
         BC000S3_A230PrdUpdUsuID = new string[] {""} ;
         BC000S3_n230PrdUpdUsuID = new bool[] {false} ;
         BC000S3_A231PrdAtivo = new bool[] {false} ;
         BC000S3_A620PrdDel = new bool[] {false} ;
         BC000S3_A232PrdTipoID = new int[1] ;
         sMode28 = "";
         BC000S2_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S2_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n621PrdDelDataHora = new bool[] {false} ;
         BC000S2_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n622PrdDelData = new bool[] {false} ;
         BC000S2_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n623PrdDelHora = new bool[] {false} ;
         BC000S2_A624PrdDelUsuId = new string[] {""} ;
         BC000S2_n624PrdDelUsuId = new bool[] {false} ;
         BC000S2_A625PrdDelUsuNome = new string[] {""} ;
         BC000S2_n625PrdDelUsuNome = new bool[] {false} ;
         BC000S2_A221PrdCodigo = new string[] {""} ;
         BC000S2_A222PrdNome = new string[] {""} ;
         BC000S2_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         BC000S2_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_A226PrdInsUsuID = new string[] {""} ;
         BC000S2_n226PrdInsUsuID = new bool[] {false} ;
         BC000S2_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n227PrdUpdData = new bool[] {false} ;
         BC000S2_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n228PrdUpdHora = new bool[] {false} ;
         BC000S2_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S2_n229PrdUpdDataHora = new bool[] {false} ;
         BC000S2_A230PrdUpdUsuID = new string[] {""} ;
         BC000S2_n230PrdUpdUsuID = new bool[] {false} ;
         BC000S2_A231PrdAtivo = new bool[] {false} ;
         BC000S2_A620PrdDel = new bool[] {false} ;
         BC000S2_A232PrdTipoID = new int[1] ;
         BC000S11_A233PrdTipoSigla = new string[] {""} ;
         BC000S11_A234PrdTipoNome = new string[] {""} ;
         BC000S12_A235TppID = new Guid[] {Guid.Empty} ;
         BC000S12_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S13_A220PrdID = new Guid[] {Guid.Empty} ;
         BC000S13_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n621PrdDelDataHora = new bool[] {false} ;
         BC000S13_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n622PrdDelData = new bool[] {false} ;
         BC000S13_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n623PrdDelHora = new bool[] {false} ;
         BC000S13_A624PrdDelUsuId = new string[] {""} ;
         BC000S13_n624PrdDelUsuId = new bool[] {false} ;
         BC000S13_A625PrdDelUsuNome = new string[] {""} ;
         BC000S13_n625PrdDelUsuNome = new bool[] {false} ;
         BC000S13_A221PrdCodigo = new string[] {""} ;
         BC000S13_A222PrdNome = new string[] {""} ;
         BC000S13_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         BC000S13_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_A226PrdInsUsuID = new string[] {""} ;
         BC000S13_n226PrdInsUsuID = new bool[] {false} ;
         BC000S13_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n227PrdUpdData = new bool[] {false} ;
         BC000S13_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n228PrdUpdHora = new bool[] {false} ;
         BC000S13_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000S13_n229PrdUpdDataHora = new bool[] {false} ;
         BC000S13_A230PrdUpdUsuID = new string[] {""} ;
         BC000S13_n230PrdUpdUsuID = new bool[] {false} ;
         BC000S13_A231PrdAtivo = new bool[] {false} ;
         BC000S13_A233PrdTipoSigla = new string[] {""} ;
         BC000S13_A234PrdTipoNome = new string[] {""} ;
         BC000S13_A620PrdDel = new bool[] {false} ;
         BC000S13_A232PrdTipoID = new int[1] ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.produto_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produto_bc__default(),
            new Object[][] {
                new Object[] {
               BC000S2_A220PrdID, BC000S2_A621PrdDelDataHora, BC000S2_n621PrdDelDataHora, BC000S2_A622PrdDelData, BC000S2_n622PrdDelData, BC000S2_A623PrdDelHora, BC000S2_n623PrdDelHora, BC000S2_A624PrdDelUsuId, BC000S2_n624PrdDelUsuId, BC000S2_A625PrdDelUsuNome,
               BC000S2_n625PrdDelUsuNome, BC000S2_A221PrdCodigo, BC000S2_A222PrdNome, BC000S2_A223PrdInsData, BC000S2_A224PrdInsHora, BC000S2_A225PrdInsDataHora, BC000S2_A226PrdInsUsuID, BC000S2_n226PrdInsUsuID, BC000S2_A227PrdUpdData, BC000S2_n227PrdUpdData,
               BC000S2_A228PrdUpdHora, BC000S2_n228PrdUpdHora, BC000S2_A229PrdUpdDataHora, BC000S2_n229PrdUpdDataHora, BC000S2_A230PrdUpdUsuID, BC000S2_n230PrdUpdUsuID, BC000S2_A231PrdAtivo, BC000S2_A620PrdDel, BC000S2_A232PrdTipoID
               }
               , new Object[] {
               BC000S3_A220PrdID, BC000S3_A621PrdDelDataHora, BC000S3_n621PrdDelDataHora, BC000S3_A622PrdDelData, BC000S3_n622PrdDelData, BC000S3_A623PrdDelHora, BC000S3_n623PrdDelHora, BC000S3_A624PrdDelUsuId, BC000S3_n624PrdDelUsuId, BC000S3_A625PrdDelUsuNome,
               BC000S3_n625PrdDelUsuNome, BC000S3_A221PrdCodigo, BC000S3_A222PrdNome, BC000S3_A223PrdInsData, BC000S3_A224PrdInsHora, BC000S3_A225PrdInsDataHora, BC000S3_A226PrdInsUsuID, BC000S3_n226PrdInsUsuID, BC000S3_A227PrdUpdData, BC000S3_n227PrdUpdData,
               BC000S3_A228PrdUpdHora, BC000S3_n228PrdUpdHora, BC000S3_A229PrdUpdDataHora, BC000S3_n229PrdUpdDataHora, BC000S3_A230PrdUpdUsuID, BC000S3_n230PrdUpdUsuID, BC000S3_A231PrdAtivo, BC000S3_A620PrdDel, BC000S3_A232PrdTipoID
               }
               , new Object[] {
               BC000S4_A233PrdTipoSigla, BC000S4_A234PrdTipoNome
               }
               , new Object[] {
               BC000S5_A220PrdID, BC000S5_A621PrdDelDataHora, BC000S5_n621PrdDelDataHora, BC000S5_A622PrdDelData, BC000S5_n622PrdDelData, BC000S5_A623PrdDelHora, BC000S5_n623PrdDelHora, BC000S5_A624PrdDelUsuId, BC000S5_n624PrdDelUsuId, BC000S5_A625PrdDelUsuNome,
               BC000S5_n625PrdDelUsuNome, BC000S5_A221PrdCodigo, BC000S5_A222PrdNome, BC000S5_A223PrdInsData, BC000S5_A224PrdInsHora, BC000S5_A225PrdInsDataHora, BC000S5_A226PrdInsUsuID, BC000S5_n226PrdInsUsuID, BC000S5_A227PrdUpdData, BC000S5_n227PrdUpdData,
               BC000S5_A228PrdUpdHora, BC000S5_n228PrdUpdHora, BC000S5_A229PrdUpdDataHora, BC000S5_n229PrdUpdDataHora, BC000S5_A230PrdUpdUsuID, BC000S5_n230PrdUpdUsuID, BC000S5_A231PrdAtivo, BC000S5_A233PrdTipoSigla, BC000S5_A234PrdTipoNome, BC000S5_A620PrdDel,
               BC000S5_A232PrdTipoID
               }
               , new Object[] {
               BC000S6_A221PrdCodigo
               }
               , new Object[] {
               BC000S7_A220PrdID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000S11_A233PrdTipoSigla, BC000S11_A234PrdTipoNome
               }
               , new Object[] {
               BC000S12_A235TppID, BC000S12_A220PrdID
               }
               , new Object[] {
               BC000S13_A220PrdID, BC000S13_A621PrdDelDataHora, BC000S13_n621PrdDelDataHora, BC000S13_A622PrdDelData, BC000S13_n622PrdDelData, BC000S13_A623PrdDelHora, BC000S13_n623PrdDelHora, BC000S13_A624PrdDelUsuId, BC000S13_n624PrdDelUsuId, BC000S13_A625PrdDelUsuNome,
               BC000S13_n625PrdDelUsuNome, BC000S13_A221PrdCodigo, BC000S13_A222PrdNome, BC000S13_A223PrdInsData, BC000S13_A224PrdInsHora, BC000S13_A225PrdInsDataHora, BC000S13_A226PrdInsUsuID, BC000S13_n226PrdInsUsuID, BC000S13_A227PrdUpdData, BC000S13_n227PrdUpdData,
               BC000S13_A228PrdUpdHora, BC000S13_n228PrdUpdHora, BC000S13_A229PrdUpdDataHora, BC000S13_n229PrdUpdDataHora, BC000S13_A230PrdUpdUsuID, BC000S13_n230PrdUpdUsuID, BC000S13_A231PrdAtivo, BC000S13_A233PrdTipoSigla, BC000S13_A234PrdTipoNome, BC000S13_A620PrdDel,
               BC000S13_A232PrdTipoID
               }
            }
         );
         Z231PrdAtivo = true;
         A231PrdAtivo = true;
         i231PrdAtivo = true;
         Z220PrdID = Guid.NewGuid( );
         A220PrdID = Guid.NewGuid( );
         AV25Pgmname = "core.Produto_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120S2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private short nIsDirty_28 ;
      private int trnEnded ;
      private int AV26GXV1 ;
      private int AV13Insert_PrdTipoID ;
      private int Z232PrdTipoID ;
      private int A232PrdTipoID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV25Pgmname ;
      private string Z624PrdDelUsuId ;
      private string A624PrdDelUsuId ;
      private string Z226PrdInsUsuID ;
      private string A226PrdInsUsuID ;
      private string Z230PrdUpdUsuID ;
      private string A230PrdUpdUsuID ;
      private string sMode28 ;
      private DateTime Z621PrdDelDataHora ;
      private DateTime A621PrdDelDataHora ;
      private DateTime Z622PrdDelData ;
      private DateTime A622PrdDelData ;
      private DateTime Z623PrdDelHora ;
      private DateTime A623PrdDelHora ;
      private DateTime Z224PrdInsHora ;
      private DateTime A224PrdInsHora ;
      private DateTime Z225PrdInsDataHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime Z228PrdUpdHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime Z229PrdUpdDataHora ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime Z223PrdInsData ;
      private DateTime A223PrdInsData ;
      private DateTime Z227PrdUpdData ;
      private DateTime A227PrdUpdData ;
      private bool returnInSub ;
      private bool Z231PrdAtivo ;
      private bool A231PrdAtivo ;
      private bool Z620PrdDel ;
      private bool A620PrdDel ;
      private bool n621PrdDelDataHora ;
      private bool n622PrdDelData ;
      private bool n623PrdDelHora ;
      private bool n624PrdDelUsuId ;
      private bool n625PrdDelUsuNome ;
      private bool n226PrdInsUsuID ;
      private bool n227PrdUpdData ;
      private bool n228PrdUpdHora ;
      private bool n229PrdUpdDataHora ;
      private bool n230PrdUpdUsuID ;
      private bool O620PrdDel ;
      private bool Gx_longc ;
      private bool i231PrdAtivo ;
      private bool mustCommit ;
      private string Z625PrdDelUsuNome ;
      private string A625PrdDelUsuNome ;
      private string Z221PrdCodigo ;
      private string A221PrdCodigo ;
      private string Z222PrdNome ;
      private string A222PrdNome ;
      private string Z233PrdTipoSigla ;
      private string A233PrdTipoSigla ;
      private string Z234PrdTipoNome ;
      private string A234PrdTipoNome ;
      private Guid Z220PrdID ;
      private Guid A220PrdID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtProduto bccore_Produto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC000S5_A220PrdID ;
      private DateTime[] BC000S5_A621PrdDelDataHora ;
      private bool[] BC000S5_n621PrdDelDataHora ;
      private DateTime[] BC000S5_A622PrdDelData ;
      private bool[] BC000S5_n622PrdDelData ;
      private DateTime[] BC000S5_A623PrdDelHora ;
      private bool[] BC000S5_n623PrdDelHora ;
      private string[] BC000S5_A624PrdDelUsuId ;
      private bool[] BC000S5_n624PrdDelUsuId ;
      private string[] BC000S5_A625PrdDelUsuNome ;
      private bool[] BC000S5_n625PrdDelUsuNome ;
      private string[] BC000S5_A221PrdCodigo ;
      private string[] BC000S5_A222PrdNome ;
      private DateTime[] BC000S5_A223PrdInsData ;
      private DateTime[] BC000S5_A224PrdInsHora ;
      private DateTime[] BC000S5_A225PrdInsDataHora ;
      private string[] BC000S5_A226PrdInsUsuID ;
      private bool[] BC000S5_n226PrdInsUsuID ;
      private DateTime[] BC000S5_A227PrdUpdData ;
      private bool[] BC000S5_n227PrdUpdData ;
      private DateTime[] BC000S5_A228PrdUpdHora ;
      private bool[] BC000S5_n228PrdUpdHora ;
      private DateTime[] BC000S5_A229PrdUpdDataHora ;
      private bool[] BC000S5_n229PrdUpdDataHora ;
      private string[] BC000S5_A230PrdUpdUsuID ;
      private bool[] BC000S5_n230PrdUpdUsuID ;
      private bool[] BC000S5_A231PrdAtivo ;
      private string[] BC000S5_A233PrdTipoSigla ;
      private string[] BC000S5_A234PrdTipoNome ;
      private bool[] BC000S5_A620PrdDel ;
      private int[] BC000S5_A232PrdTipoID ;
      private string[] BC000S6_A221PrdCodigo ;
      private string[] BC000S4_A233PrdTipoSigla ;
      private string[] BC000S4_A234PrdTipoNome ;
      private Guid[] BC000S7_A220PrdID ;
      private Guid[] BC000S3_A220PrdID ;
      private DateTime[] BC000S3_A621PrdDelDataHora ;
      private bool[] BC000S3_n621PrdDelDataHora ;
      private DateTime[] BC000S3_A622PrdDelData ;
      private bool[] BC000S3_n622PrdDelData ;
      private DateTime[] BC000S3_A623PrdDelHora ;
      private bool[] BC000S3_n623PrdDelHora ;
      private string[] BC000S3_A624PrdDelUsuId ;
      private bool[] BC000S3_n624PrdDelUsuId ;
      private string[] BC000S3_A625PrdDelUsuNome ;
      private bool[] BC000S3_n625PrdDelUsuNome ;
      private string[] BC000S3_A221PrdCodigo ;
      private string[] BC000S3_A222PrdNome ;
      private DateTime[] BC000S3_A223PrdInsData ;
      private DateTime[] BC000S3_A224PrdInsHora ;
      private DateTime[] BC000S3_A225PrdInsDataHora ;
      private string[] BC000S3_A226PrdInsUsuID ;
      private bool[] BC000S3_n226PrdInsUsuID ;
      private DateTime[] BC000S3_A227PrdUpdData ;
      private bool[] BC000S3_n227PrdUpdData ;
      private DateTime[] BC000S3_A228PrdUpdHora ;
      private bool[] BC000S3_n228PrdUpdHora ;
      private DateTime[] BC000S3_A229PrdUpdDataHora ;
      private bool[] BC000S3_n229PrdUpdDataHora ;
      private string[] BC000S3_A230PrdUpdUsuID ;
      private bool[] BC000S3_n230PrdUpdUsuID ;
      private bool[] BC000S3_A231PrdAtivo ;
      private bool[] BC000S3_A620PrdDel ;
      private int[] BC000S3_A232PrdTipoID ;
      private Guid[] BC000S2_A220PrdID ;
      private DateTime[] BC000S2_A621PrdDelDataHora ;
      private bool[] BC000S2_n621PrdDelDataHora ;
      private DateTime[] BC000S2_A622PrdDelData ;
      private bool[] BC000S2_n622PrdDelData ;
      private DateTime[] BC000S2_A623PrdDelHora ;
      private bool[] BC000S2_n623PrdDelHora ;
      private string[] BC000S2_A624PrdDelUsuId ;
      private bool[] BC000S2_n624PrdDelUsuId ;
      private string[] BC000S2_A625PrdDelUsuNome ;
      private bool[] BC000S2_n625PrdDelUsuNome ;
      private string[] BC000S2_A221PrdCodigo ;
      private string[] BC000S2_A222PrdNome ;
      private DateTime[] BC000S2_A223PrdInsData ;
      private DateTime[] BC000S2_A224PrdInsHora ;
      private DateTime[] BC000S2_A225PrdInsDataHora ;
      private string[] BC000S2_A226PrdInsUsuID ;
      private bool[] BC000S2_n226PrdInsUsuID ;
      private DateTime[] BC000S2_A227PrdUpdData ;
      private bool[] BC000S2_n227PrdUpdData ;
      private DateTime[] BC000S2_A228PrdUpdHora ;
      private bool[] BC000S2_n228PrdUpdHora ;
      private DateTime[] BC000S2_A229PrdUpdDataHora ;
      private bool[] BC000S2_n229PrdUpdDataHora ;
      private string[] BC000S2_A230PrdUpdUsuID ;
      private bool[] BC000S2_n230PrdUpdUsuID ;
      private bool[] BC000S2_A231PrdAtivo ;
      private bool[] BC000S2_A620PrdDel ;
      private int[] BC000S2_A232PrdTipoID ;
      private string[] BC000S11_A233PrdTipoSigla ;
      private string[] BC000S11_A234PrdTipoNome ;
      private Guid[] BC000S12_A235TppID ;
      private Guid[] BC000S12_A220PrdID ;
      private Guid[] BC000S13_A220PrdID ;
      private DateTime[] BC000S13_A621PrdDelDataHora ;
      private bool[] BC000S13_n621PrdDelDataHora ;
      private DateTime[] BC000S13_A622PrdDelData ;
      private bool[] BC000S13_n622PrdDelData ;
      private DateTime[] BC000S13_A623PrdDelHora ;
      private bool[] BC000S13_n623PrdDelHora ;
      private string[] BC000S13_A624PrdDelUsuId ;
      private bool[] BC000S13_n624PrdDelUsuId ;
      private string[] BC000S13_A625PrdDelUsuNome ;
      private bool[] BC000S13_n625PrdDelUsuNome ;
      private string[] BC000S13_A221PrdCodigo ;
      private string[] BC000S13_A222PrdNome ;
      private DateTime[] BC000S13_A223PrdInsData ;
      private DateTime[] BC000S13_A224PrdInsHora ;
      private DateTime[] BC000S13_A225PrdInsDataHora ;
      private string[] BC000S13_A226PrdInsUsuID ;
      private bool[] BC000S13_n226PrdInsUsuID ;
      private DateTime[] BC000S13_A227PrdUpdData ;
      private bool[] BC000S13_n227PrdUpdData ;
      private DateTime[] BC000S13_A228PrdUpdHora ;
      private bool[] BC000S13_n228PrdUpdHora ;
      private DateTime[] BC000S13_A229PrdUpdDataHora ;
      private bool[] BC000S13_n229PrdUpdDataHora ;
      private string[] BC000S13_A230PrdUpdUsuID ;
      private bool[] BC000S13_n230PrdUpdUsuID ;
      private bool[] BC000S13_A231PrdAtivo ;
      private string[] BC000S13_A233PrdTipoSigla ;
      private string[] BC000S13_A234PrdTipoNome ;
      private bool[] BC000S13_A620PrdDel ;
      private int[] BC000S13_A232PrdTipoID ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ;
   }

   public class produto_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class produto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC000S5;
        prmBC000S5 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S6;
        prmBC000S6 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S4;
        prmBC000S4 = new Object[] {
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000S7;
        prmBC000S7 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S3;
        prmBC000S3 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S2;
        prmBC000S2 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S8;
        prmBC000S8 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrdDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdInsData",GXType.Date,8,0) ,
        new ParDef("PrdInsHora",GXType.DateTime,0,5) ,
        new ParDef("PrdInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("PrdInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("PrdUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrdDel",GXType.Boolean,4,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000S9;
        prmBC000S9 = new Object[] {
        new ParDef("PrdDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrdDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdInsData",GXType.Date,8,0) ,
        new ParDef("PrdInsHora",GXType.DateTime,0,5) ,
        new ParDef("PrdInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("PrdInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("PrdUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrdDel",GXType.Boolean,4,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S10;
        prmBC000S10 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S11;
        prmBC000S11 = new Object[] {
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmBC000S12;
        prmBC000S12 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC000S13;
        prmBC000S13 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000S2", "SELECT PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID FROM tb_produto WHERE PrdID = :PrdID  FOR UPDATE OF tb_produto",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S3", "SELECT PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S4", "SELECT PrtSigla AS PrdTipoSigla, PrtNome AS PrdTipoNome FROM tb_produtotipo WHERE PrtID = :PrdTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S5", "SELECT TM1.PrdID, TM1.PrdDelDataHora, TM1.PrdDelData, TM1.PrdDelHora, TM1.PrdDelUsuId, TM1.PrdDelUsuNome, TM1.PrdCodigo, TM1.PrdNome, TM1.PrdInsData, TM1.PrdInsHora, TM1.PrdInsDataHora, TM1.PrdInsUsuID, TM1.PrdUpdData, TM1.PrdUpdHora, TM1.PrdUpdDataHora, TM1.PrdUpdUsuID, TM1.PrdAtivo, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, TM1.PrdDel, TM1.PrdTipoID AS PrdTipoID FROM (tb_produto TM1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = TM1.PrdTipoID) WHERE TM1.PrdID = :PrdID ORDER BY TM1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S6", "SELECT PrdCodigo FROM tb_produto WHERE (PrdCodigo = :PrdCodigo) AND (Not ( PrdID = :PrdID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S7", "SELECT PrdID FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S8", "SAVEPOINT gxupdate;INSERT INTO tb_produto(PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID) VALUES(:PrdID, :PrdDelDataHora, :PrdDelData, :PrdDelHora, :PrdDelUsuId, :PrdDelUsuNome, :PrdCodigo, :PrdNome, :PrdInsData, :PrdInsHora, :PrdInsDataHora, :PrdInsUsuID, :PrdUpdData, :PrdUpdHora, :PrdUpdDataHora, :PrdUpdUsuID, :PrdAtivo, :PrdDel, :PrdTipoID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000S8)
           ,new CursorDef("BC000S9", "SAVEPOINT gxupdate;UPDATE tb_produto SET PrdDelDataHora=:PrdDelDataHora, PrdDelData=:PrdDelData, PrdDelHora=:PrdDelHora, PrdDelUsuId=:PrdDelUsuId, PrdDelUsuNome=:PrdDelUsuNome, PrdCodigo=:PrdCodigo, PrdNome=:PrdNome, PrdInsData=:PrdInsData, PrdInsHora=:PrdInsHora, PrdInsDataHora=:PrdInsDataHora, PrdInsUsuID=:PrdInsUsuID, PrdUpdData=:PrdUpdData, PrdUpdHora=:PrdUpdHora, PrdUpdDataHora=:PrdUpdDataHora, PrdUpdUsuID=:PrdUpdUsuID, PrdAtivo=:PrdAtivo, PrdDel=:PrdDel, PrdTipoID=:PrdTipoID  WHERE PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000S9)
           ,new CursorDef("BC000S10", "SAVEPOINT gxupdate;DELETE FROM tb_produto  WHERE PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000S10)
           ,new CursorDef("BC000S11", "SELECT PrtSigla AS PrdTipoSigla, PrtNome AS PrdTipoNome FROM tb_produtotipo WHERE PrtID = :PrdTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000S12", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000S13", "SELECT TM1.PrdID, TM1.PrdDelDataHora, TM1.PrdDelData, TM1.PrdDelHora, TM1.PrdDelUsuId, TM1.PrdDelUsuNome, TM1.PrdCodigo, TM1.PrdNome, TM1.PrdInsData, TM1.PrdInsHora, TM1.PrdInsDataHora, TM1.PrdInsUsuID, TM1.PrdUpdData, TM1.PrdUpdHora, TM1.PrdUpdDataHora, TM1.PrdUpdUsuID, TM1.PrdAtivo, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, TM1.PrdDel, TM1.PrdTipoID AS PrdTipoID FROM (tb_produto TM1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = TM1.PrdTipoID) WHERE TM1.PrdID = :PrdID ORDER BY TM1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000S13,100, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((bool[]) buf[27])[0] = rslt.getBool(18);
              ((int[]) buf[28])[0] = rslt.getInt(19);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((bool[]) buf[27])[0] = rslt.getBool(18);
              ((int[]) buf[28])[0] = rslt.getInt(19);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((int[]) buf[30])[0] = rslt.getInt(21);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((int[]) buf[30])[0] = rslt.getInt(21);
              return;
     }
  }

}

}
