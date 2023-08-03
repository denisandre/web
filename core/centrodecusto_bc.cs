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
   public class centrodecusto_bc : GxSilentTrn, IGxSilentTrn
   {
      public centrodecusto_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrodecusto_bc( IGxContext context )
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
         ReadRow0Q26( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0Q26( ) ;
         standaloneModal( ) ;
         AddRow0Q26( ) ;
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
            E110Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z208CcuID = A208CcuID;
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

      protected void CONFIRM_0Q0( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Q26( ) ;
            }
            else
            {
               CheckExtendedTable0Q26( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0Q26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM0Q26( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z513CcuDelDataHora = A513CcuDelDataHora;
            Z514CcuDelData = A514CcuDelData;
            Z515CcuDelHora = A515CcuDelHora;
            Z516CcuDelUsuId = A516CcuDelUsuId;
            Z517CcuDelUsuNome = A517CcuDelUsuNome;
            Z209CcuSigla = A209CcuSigla;
            Z210CcuNome = A210CcuNome;
            Z218CcuAtivo = A218CcuAtivo;
            Z512CcuDel = A512CcuDel;
         }
         if ( GX_JID == -13 )
         {
            Z208CcuID = A208CcuID;
            Z513CcuDelDataHora = A513CcuDelDataHora;
            Z514CcuDelData = A514CcuDelData;
            Z515CcuDelHora = A515CcuDelHora;
            Z516CcuDelUsuId = A516CcuDelUsuId;
            Z517CcuDelUsuNome = A517CcuDelUsuNome;
            Z209CcuSigla = A209CcuSigla;
            Z210CcuNome = A210CcuNome;
            Z218CcuAtivo = A218CcuAtivo;
            Z512CcuDel = A512CcuDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV14Pgmname = "core.CentroDeCusto_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A218CcuAtivo) && ( Gx_BScreen == 0 ) )
         {
            A218CcuAtivo = true;
         }
      }

      protected void Load0Q26( )
      {
         /* Using cursor BC000Q4 */
         pr_default.execute(2, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A513CcuDelDataHora = BC000Q4_A513CcuDelDataHora[0];
            n513CcuDelDataHora = BC000Q4_n513CcuDelDataHora[0];
            A514CcuDelData = BC000Q4_A514CcuDelData[0];
            n514CcuDelData = BC000Q4_n514CcuDelData[0];
            A515CcuDelHora = BC000Q4_A515CcuDelHora[0];
            n515CcuDelHora = BC000Q4_n515CcuDelHora[0];
            A516CcuDelUsuId = BC000Q4_A516CcuDelUsuId[0];
            n516CcuDelUsuId = BC000Q4_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = BC000Q4_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = BC000Q4_n517CcuDelUsuNome[0];
            A209CcuSigla = BC000Q4_A209CcuSigla[0];
            A210CcuNome = BC000Q4_A210CcuNome[0];
            A218CcuAtivo = BC000Q4_A218CcuAtivo[0];
            A512CcuDel = BC000Q4_A512CcuDel[0];
            ZM0Q26( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0Q26( ) ;
      }

      protected void OnLoadActions0Q26( )
      {
      }

      protected void CheckExtendedTable0Q26( )
      {
         nIsDirty_26 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000Q5 */
         pr_default.execute(3, new Object[] {A209CcuSigla, A208CcuID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A209CcuSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A210CcuNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0Q26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Q26( )
      {
         /* Using cursor BC000Q6 */
         pr_default.execute(4, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000Q3 */
         pr_default.execute(1, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q26( 13) ;
            RcdFound26 = 1;
            A208CcuID = BC000Q3_A208CcuID[0];
            A513CcuDelDataHora = BC000Q3_A513CcuDelDataHora[0];
            n513CcuDelDataHora = BC000Q3_n513CcuDelDataHora[0];
            A514CcuDelData = BC000Q3_A514CcuDelData[0];
            n514CcuDelData = BC000Q3_n514CcuDelData[0];
            A515CcuDelHora = BC000Q3_A515CcuDelHora[0];
            n515CcuDelHora = BC000Q3_n515CcuDelHora[0];
            A516CcuDelUsuId = BC000Q3_A516CcuDelUsuId[0];
            n516CcuDelUsuId = BC000Q3_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = BC000Q3_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = BC000Q3_n517CcuDelUsuNome[0];
            A209CcuSigla = BC000Q3_A209CcuSigla[0];
            A210CcuNome = BC000Q3_A210CcuNome[0];
            A218CcuAtivo = BC000Q3_A218CcuAtivo[0];
            A512CcuDel = BC000Q3_A512CcuDel[0];
            O512CcuDel = A512CcuDel;
            Z208CcuID = A208CcuID;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0Q26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0Q26( ) ;
            }
            Gx_mode = sMode26;
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0Q26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode26;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q26( ) ;
         if ( RcdFound26 == 0 )
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
         CONFIRM_0Q0( ) ;
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

      protected void CheckOptimisticConcurrency0Q26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000Q2 */
            pr_default.execute(0, new Object[] {A208CcuID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_centrodecusto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z513CcuDelDataHora != BC000Q2_A513CcuDelDataHora[0] ) || ( Z514CcuDelData != BC000Q2_A514CcuDelData[0] ) || ( Z515CcuDelHora != BC000Q2_A515CcuDelHora[0] ) || ( StringUtil.StrCmp(Z516CcuDelUsuId, BC000Q2_A516CcuDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z517CcuDelUsuNome, BC000Q2_A517CcuDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z209CcuSigla, BC000Q2_A209CcuSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z210CcuNome, BC000Q2_A210CcuNome[0]) != 0 ) || ( Z218CcuAtivo != BC000Q2_A218CcuAtivo[0] ) || ( Z512CcuDel != BC000Q2_A512CcuDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_centrodecusto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q26( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q26( 0) ;
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q7 */
                     pr_default.execute(5, new Object[] {n513CcuDelDataHora, A513CcuDelDataHora, n514CcuDelData, A514CcuDelData, n515CcuDelHora, A515CcuDelHora, n516CcuDelUsuId, A516CcuDelUsuId, n517CcuDelUsuNome, A517CcuDelUsuNome, A209CcuSigla, A210CcuNome, A218CcuAtivo, A512CcuDel});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC000Q8 */
                     pr_default.execute(6);
                     A208CcuID = BC000Q8_A208CcuID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
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
               Load0Q26( ) ;
            }
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void Update0Q26( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000Q9 */
                     pr_default.execute(7, new Object[] {n513CcuDelDataHora, A513CcuDelDataHora, n514CcuDelData, A514CcuDelData, n515CcuDelHora, A515CcuDelHora, n516CcuDelUsuId, A516CcuDelUsuId, n517CcuDelUsuNome, A517CcuDelUsuNome, A209CcuSigla, A210CcuNome, A218CcuAtivo, A512CcuDel, A208CcuID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_centrodecusto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q26( ) ;
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
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void DeferredUpdate0Q26( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q26( ) ;
            AfterConfirm0Q26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000Q10 */
                  pr_default.execute(8, new Object[] {A208CcuID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0Q26( ) ;
         Gx_mode = sMode26;
      }

      protected void OnDeleteControls0Q26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Q26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q26( ) ;
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

      public void ScanKeyStart0Q26( )
      {
         /* Scan By routine */
         /* Using cursor BC000Q11 */
         pr_default.execute(9, new Object[] {A208CcuID});
         RcdFound26 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound26 = 1;
            A208CcuID = BC000Q11_A208CcuID[0];
            A513CcuDelDataHora = BC000Q11_A513CcuDelDataHora[0];
            n513CcuDelDataHora = BC000Q11_n513CcuDelDataHora[0];
            A514CcuDelData = BC000Q11_A514CcuDelData[0];
            n514CcuDelData = BC000Q11_n514CcuDelData[0];
            A515CcuDelHora = BC000Q11_A515CcuDelHora[0];
            n515CcuDelHora = BC000Q11_n515CcuDelHora[0];
            A516CcuDelUsuId = BC000Q11_A516CcuDelUsuId[0];
            n516CcuDelUsuId = BC000Q11_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = BC000Q11_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = BC000Q11_n517CcuDelUsuNome[0];
            A209CcuSigla = BC000Q11_A209CcuSigla[0];
            A210CcuNome = BC000Q11_A210CcuNome[0];
            A218CcuAtivo = BC000Q11_A218CcuAtivo[0];
            A512CcuDel = BC000Q11_A512CcuDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0Q26( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound26 = 0;
         ScanKeyLoad0Q26( ) ;
      }

      protected void ScanKeyLoad0Q26( )
      {
         sMode26 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound26 = 1;
            A208CcuID = BC000Q11_A208CcuID[0];
            A513CcuDelDataHora = BC000Q11_A513CcuDelDataHora[0];
            n513CcuDelDataHora = BC000Q11_n513CcuDelDataHora[0];
            A514CcuDelData = BC000Q11_A514CcuDelData[0];
            n514CcuDelData = BC000Q11_n514CcuDelData[0];
            A515CcuDelHora = BC000Q11_A515CcuDelHora[0];
            n515CcuDelHora = BC000Q11_n515CcuDelHora[0];
            A516CcuDelUsuId = BC000Q11_A516CcuDelUsuId[0];
            n516CcuDelUsuId = BC000Q11_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = BC000Q11_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = BC000Q11_n517CcuDelUsuNome[0];
            A209CcuSigla = BC000Q11_A209CcuSigla[0];
            A210CcuNome = BC000Q11_A210CcuNome[0];
            A218CcuAtivo = BC000Q11_A218CcuAtivo[0];
            A512CcuDel = BC000Q11_A512CcuDel[0];
         }
         Gx_mode = sMode26;
      }

      protected void ScanKeyEnd0Q26( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0Q26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q26( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A513CcuDelDataHora = DateTimeUtil.NowMS( context);
            n513CcuDelDataHora = false;
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A516CcuDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n516CcuDelUsuId = false;
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A517CcuDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n517CcuDelUsuNome = false;
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A514CcuDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A513CcuDelDataHora) ) ;
            n514CcuDelData = false;
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A515CcuDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A513CcuDelDataHora));
            n515CcuDelHora = false;
         }
      }

      protected void BeforeDelete0Q26( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
      }

      protected void BeforeComplete0Q26( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0Q26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q26( )
      {
      }

      protected void send_integrity_lvl_hashes0Q26( )
      {
      }

      protected void AddRow0Q26( )
      {
         VarsToRow26( bccore_CentroDeCusto) ;
      }

      protected void ReadRow0Q26( )
      {
         RowToVars26( bccore_CentroDeCusto, 1) ;
      }

      protected void InitializeNonKey0Q26( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         n513CcuDelDataHora = false;
         A514CcuDelData = (DateTime)(DateTime.MinValue);
         n514CcuDelData = false;
         A515CcuDelHora = (DateTime)(DateTime.MinValue);
         n515CcuDelHora = false;
         A516CcuDelUsuId = "";
         n516CcuDelUsuId = false;
         A517CcuDelUsuNome = "";
         n517CcuDelUsuNome = false;
         A209CcuSigla = "";
         A210CcuNome = "";
         A512CcuDel = false;
         A218CcuAtivo = true;
         O512CcuDel = A512CcuDel;
         Z513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         Z514CcuDelData = (DateTime)(DateTime.MinValue);
         Z515CcuDelHora = (DateTime)(DateTime.MinValue);
         Z516CcuDelUsuId = "";
         Z517CcuDelUsuNome = "";
         Z209CcuSigla = "";
         Z210CcuNome = "";
         Z218CcuAtivo = false;
         Z512CcuDel = false;
      }

      protected void InitAll0Q26( )
      {
         A208CcuID = 0;
         InitializeNonKey0Q26( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A218CcuAtivo = i218CcuAtivo;
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

      public void VarsToRow26( GeneXus.Programs.core.SdtCentroDeCusto obj26 )
      {
         obj26.gxTpr_Mode = Gx_mode;
         obj26.gxTpr_Ccudeldatahora = A513CcuDelDataHora;
         obj26.gxTpr_Ccudeldata = A514CcuDelData;
         obj26.gxTpr_Ccudelhora = A515CcuDelHora;
         obj26.gxTpr_Ccudelusuid = A516CcuDelUsuId;
         obj26.gxTpr_Ccudelusunome = A517CcuDelUsuNome;
         obj26.gxTpr_Ccusigla = A209CcuSigla;
         obj26.gxTpr_Ccunome = A210CcuNome;
         obj26.gxTpr_Ccudel = A512CcuDel;
         obj26.gxTpr_Ccuativo = A218CcuAtivo;
         obj26.gxTpr_Ccuid = A208CcuID;
         obj26.gxTpr_Ccuid_Z = Z208CcuID;
         obj26.gxTpr_Ccusigla_Z = Z209CcuSigla;
         obj26.gxTpr_Ccunome_Z = Z210CcuNome;
         obj26.gxTpr_Ccuativo_Z = Z218CcuAtivo;
         obj26.gxTpr_Ccudel_Z = Z512CcuDel;
         obj26.gxTpr_Ccudeldatahora_Z = Z513CcuDelDataHora;
         obj26.gxTpr_Ccudeldata_Z = Z514CcuDelData;
         obj26.gxTpr_Ccudelhora_Z = Z515CcuDelHora;
         obj26.gxTpr_Ccudelusuid_Z = Z516CcuDelUsuId;
         obj26.gxTpr_Ccudelusunome_Z = Z517CcuDelUsuNome;
         obj26.gxTpr_Ccudeldatahora_N = (short)(Convert.ToInt16(n513CcuDelDataHora));
         obj26.gxTpr_Ccudeldata_N = (short)(Convert.ToInt16(n514CcuDelData));
         obj26.gxTpr_Ccudelhora_N = (short)(Convert.ToInt16(n515CcuDelHora));
         obj26.gxTpr_Ccudelusuid_N = (short)(Convert.ToInt16(n516CcuDelUsuId));
         obj26.gxTpr_Ccudelusunome_N = (short)(Convert.ToInt16(n517CcuDelUsuNome));
         obj26.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow26( GeneXus.Programs.core.SdtCentroDeCusto obj26 )
      {
         obj26.gxTpr_Ccuid = A208CcuID;
         return  ;
      }

      public void RowToVars26( GeneXus.Programs.core.SdtCentroDeCusto obj26 ,
                               int forceLoad )
      {
         Gx_mode = obj26.gxTpr_Mode;
         A513CcuDelDataHora = obj26.gxTpr_Ccudeldatahora;
         n513CcuDelDataHora = false;
         A514CcuDelData = obj26.gxTpr_Ccudeldata;
         n514CcuDelData = false;
         A515CcuDelHora = obj26.gxTpr_Ccudelhora;
         n515CcuDelHora = false;
         A516CcuDelUsuId = obj26.gxTpr_Ccudelusuid;
         n516CcuDelUsuId = false;
         A517CcuDelUsuNome = obj26.gxTpr_Ccudelusunome;
         n517CcuDelUsuNome = false;
         A209CcuSigla = obj26.gxTpr_Ccusigla;
         A210CcuNome = obj26.gxTpr_Ccunome;
         A512CcuDel = obj26.gxTpr_Ccudel;
         A218CcuAtivo = obj26.gxTpr_Ccuativo;
         A208CcuID = obj26.gxTpr_Ccuid;
         Z208CcuID = obj26.gxTpr_Ccuid_Z;
         Z209CcuSigla = obj26.gxTpr_Ccusigla_Z;
         Z210CcuNome = obj26.gxTpr_Ccunome_Z;
         Z218CcuAtivo = obj26.gxTpr_Ccuativo_Z;
         Z512CcuDel = obj26.gxTpr_Ccudel_Z;
         O512CcuDel = obj26.gxTpr_Ccudel_Z;
         Z513CcuDelDataHora = obj26.gxTpr_Ccudeldatahora_Z;
         Z514CcuDelData = obj26.gxTpr_Ccudeldata_Z;
         Z515CcuDelHora = obj26.gxTpr_Ccudelhora_Z;
         Z516CcuDelUsuId = obj26.gxTpr_Ccudelusuid_Z;
         Z517CcuDelUsuNome = obj26.gxTpr_Ccudelusunome_Z;
         n513CcuDelDataHora = (bool)(Convert.ToBoolean(obj26.gxTpr_Ccudeldatahora_N));
         n514CcuDelData = (bool)(Convert.ToBoolean(obj26.gxTpr_Ccudeldata_N));
         n515CcuDelHora = (bool)(Convert.ToBoolean(obj26.gxTpr_Ccudelhora_N));
         n516CcuDelUsuId = (bool)(Convert.ToBoolean(obj26.gxTpr_Ccudelusuid_N));
         n517CcuDelUsuNome = (bool)(Convert.ToBoolean(obj26.gxTpr_Ccudelusunome_N));
         Gx_mode = obj26.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A208CcuID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0Q26( ) ;
         ScanKeyStart0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z208CcuID = A208CcuID;
            O512CcuDel = A512CcuDel;
         }
         ZM0Q26( -13) ;
         OnLoadActions0Q26( ) ;
         AddRow0Q26( ) ;
         ScanKeyEnd0Q26( ) ;
         if ( RcdFound26 == 0 )
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
         RowToVars26( bccore_CentroDeCusto, 0) ;
         ScanKeyStart0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z208CcuID = A208CcuID;
            O512CcuDel = A512CcuDel;
         }
         ZM0Q26( -13) ;
         OnLoadActions0Q26( ) ;
         AddRow0Q26( ) ;
         ScanKeyEnd0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0Q26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0Q26( ) ;
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A208CcuID != Z208CcuID )
               {
                  A208CcuID = Z208CcuID;
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
                  Update0Q26( ) ;
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
                  if ( A208CcuID != Z208CcuID )
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
                        Insert0Q26( ) ;
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
                        Insert0Q26( ) ;
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
         RowToVars26( bccore_CentroDeCusto, 1) ;
         SaveImpl( ) ;
         VarsToRow26( bccore_CentroDeCusto) ;
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
         RowToVars26( bccore_CentroDeCusto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q26( ) ;
         AfterTrn( ) ;
         VarsToRow26( bccore_CentroDeCusto) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow26( bccore_CentroDeCusto) ;
         }
         else
         {
            GeneXus.Programs.core.SdtCentroDeCusto auxBC = new GeneXus.Programs.core.SdtCentroDeCusto(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A208CcuID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_CentroDeCusto);
               auxBC.Save();
               bccore_CentroDeCusto.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars26( bccore_CentroDeCusto, 1) ;
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
         RowToVars26( bccore_CentroDeCusto, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0Q26( ) ;
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
               VarsToRow26( bccore_CentroDeCusto) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow26( bccore_CentroDeCusto) ;
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
         RowToVars26( bccore_CentroDeCusto, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0Q26( ) ;
         if ( RcdFound26 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A208CcuID != Z208CcuID )
            {
               A208CcuID = Z208CcuID;
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
            if ( A208CcuID != Z208CcuID )
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
         context.RollbackDataStores("core.centrodecusto_bc",pr_default);
         VarsToRow26( bccore_CentroDeCusto) ;
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
         Gx_mode = bccore_CentroDeCusto.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_CentroDeCusto.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_CentroDeCusto )
         {
            bccore_CentroDeCusto = (GeneXus.Programs.core.SdtCentroDeCusto)(sdt);
            if ( StringUtil.StrCmp(bccore_CentroDeCusto.gxTpr_Mode, "") == 0 )
            {
               bccore_CentroDeCusto.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow26( bccore_CentroDeCusto) ;
            }
            else
            {
               RowToVars26( bccore_CentroDeCusto, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_CentroDeCusto.gxTpr_Mode, "") == 0 )
            {
               bccore_CentroDeCusto.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars26( bccore_CentroDeCusto, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtCentroDeCusto CentroDeCusto_BC
      {
         get {
            return bccore_CentroDeCusto ;
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
            return "centrodecusto_Execute" ;
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
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Z513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         A513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         Z514CcuDelData = (DateTime)(DateTime.MinValue);
         A514CcuDelData = (DateTime)(DateTime.MinValue);
         Z515CcuDelHora = (DateTime)(DateTime.MinValue);
         A515CcuDelHora = (DateTime)(DateTime.MinValue);
         Z516CcuDelUsuId = "";
         A516CcuDelUsuId = "";
         Z517CcuDelUsuNome = "";
         A517CcuDelUsuNome = "";
         Z209CcuSigla = "";
         A209CcuSigla = "";
         Z210CcuNome = "";
         A210CcuNome = "";
         BC000Q4_A208CcuID = new int[1] ;
         BC000Q4_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_n513CcuDelDataHora = new bool[] {false} ;
         BC000Q4_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_n514CcuDelData = new bool[] {false} ;
         BC000Q4_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q4_n515CcuDelHora = new bool[] {false} ;
         BC000Q4_A516CcuDelUsuId = new string[] {""} ;
         BC000Q4_n516CcuDelUsuId = new bool[] {false} ;
         BC000Q4_A517CcuDelUsuNome = new string[] {""} ;
         BC000Q4_n517CcuDelUsuNome = new bool[] {false} ;
         BC000Q4_A209CcuSigla = new string[] {""} ;
         BC000Q4_A210CcuNome = new string[] {""} ;
         BC000Q4_A218CcuAtivo = new bool[] {false} ;
         BC000Q4_A512CcuDel = new bool[] {false} ;
         BC000Q5_A209CcuSigla = new string[] {""} ;
         BC000Q6_A208CcuID = new int[1] ;
         BC000Q3_A208CcuID = new int[1] ;
         BC000Q3_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q3_n513CcuDelDataHora = new bool[] {false} ;
         BC000Q3_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Q3_n514CcuDelData = new bool[] {false} ;
         BC000Q3_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q3_n515CcuDelHora = new bool[] {false} ;
         BC000Q3_A516CcuDelUsuId = new string[] {""} ;
         BC000Q3_n516CcuDelUsuId = new bool[] {false} ;
         BC000Q3_A517CcuDelUsuNome = new string[] {""} ;
         BC000Q3_n517CcuDelUsuNome = new bool[] {false} ;
         BC000Q3_A209CcuSigla = new string[] {""} ;
         BC000Q3_A210CcuNome = new string[] {""} ;
         BC000Q3_A218CcuAtivo = new bool[] {false} ;
         BC000Q3_A512CcuDel = new bool[] {false} ;
         sMode26 = "";
         BC000Q2_A208CcuID = new int[1] ;
         BC000Q2_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q2_n513CcuDelDataHora = new bool[] {false} ;
         BC000Q2_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Q2_n514CcuDelData = new bool[] {false} ;
         BC000Q2_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q2_n515CcuDelHora = new bool[] {false} ;
         BC000Q2_A516CcuDelUsuId = new string[] {""} ;
         BC000Q2_n516CcuDelUsuId = new bool[] {false} ;
         BC000Q2_A517CcuDelUsuNome = new string[] {""} ;
         BC000Q2_n517CcuDelUsuNome = new bool[] {false} ;
         BC000Q2_A209CcuSigla = new string[] {""} ;
         BC000Q2_A210CcuNome = new string[] {""} ;
         BC000Q2_A218CcuAtivo = new bool[] {false} ;
         BC000Q2_A512CcuDel = new bool[] {false} ;
         BC000Q8_A208CcuID = new int[1] ;
         BC000Q11_A208CcuID = new int[1] ;
         BC000Q11_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q11_n513CcuDelDataHora = new bool[] {false} ;
         BC000Q11_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         BC000Q11_n514CcuDelData = new bool[] {false} ;
         BC000Q11_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000Q11_n515CcuDelHora = new bool[] {false} ;
         BC000Q11_A516CcuDelUsuId = new string[] {""} ;
         BC000Q11_n516CcuDelUsuId = new bool[] {false} ;
         BC000Q11_A517CcuDelUsuNome = new string[] {""} ;
         BC000Q11_n517CcuDelUsuNome = new bool[] {false} ;
         BC000Q11_A209CcuSigla = new string[] {""} ;
         BC000Q11_A210CcuNome = new string[] {""} ;
         BC000Q11_A218CcuAtivo = new bool[] {false} ;
         BC000Q11_A512CcuDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecusto_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecusto_bc__default(),
            new Object[][] {
                new Object[] {
               BC000Q2_A208CcuID, BC000Q2_A513CcuDelDataHora, BC000Q2_n513CcuDelDataHora, BC000Q2_A514CcuDelData, BC000Q2_n514CcuDelData, BC000Q2_A515CcuDelHora, BC000Q2_n515CcuDelHora, BC000Q2_A516CcuDelUsuId, BC000Q2_n516CcuDelUsuId, BC000Q2_A517CcuDelUsuNome,
               BC000Q2_n517CcuDelUsuNome, BC000Q2_A209CcuSigla, BC000Q2_A210CcuNome, BC000Q2_A218CcuAtivo, BC000Q2_A512CcuDel
               }
               , new Object[] {
               BC000Q3_A208CcuID, BC000Q3_A513CcuDelDataHora, BC000Q3_n513CcuDelDataHora, BC000Q3_A514CcuDelData, BC000Q3_n514CcuDelData, BC000Q3_A515CcuDelHora, BC000Q3_n515CcuDelHora, BC000Q3_A516CcuDelUsuId, BC000Q3_n516CcuDelUsuId, BC000Q3_A517CcuDelUsuNome,
               BC000Q3_n517CcuDelUsuNome, BC000Q3_A209CcuSigla, BC000Q3_A210CcuNome, BC000Q3_A218CcuAtivo, BC000Q3_A512CcuDel
               }
               , new Object[] {
               BC000Q4_A208CcuID, BC000Q4_A513CcuDelDataHora, BC000Q4_n513CcuDelDataHora, BC000Q4_A514CcuDelData, BC000Q4_n514CcuDelData, BC000Q4_A515CcuDelHora, BC000Q4_n515CcuDelHora, BC000Q4_A516CcuDelUsuId, BC000Q4_n516CcuDelUsuId, BC000Q4_A517CcuDelUsuNome,
               BC000Q4_n517CcuDelUsuNome, BC000Q4_A209CcuSigla, BC000Q4_A210CcuNome, BC000Q4_A218CcuAtivo, BC000Q4_A512CcuDel
               }
               , new Object[] {
               BC000Q5_A209CcuSigla
               }
               , new Object[] {
               BC000Q6_A208CcuID
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q8_A208CcuID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000Q11_A208CcuID, BC000Q11_A513CcuDelDataHora, BC000Q11_n513CcuDelDataHora, BC000Q11_A514CcuDelData, BC000Q11_n514CcuDelData, BC000Q11_A515CcuDelHora, BC000Q11_n515CcuDelHora, BC000Q11_A516CcuDelUsuId, BC000Q11_n516CcuDelUsuId, BC000Q11_A517CcuDelUsuNome,
               BC000Q11_n517CcuDelUsuNome, BC000Q11_A209CcuSigla, BC000Q11_A210CcuNome, BC000Q11_A218CcuAtivo, BC000Q11_A512CcuDel
               }
            }
         );
         Z218CcuAtivo = true;
         A218CcuAtivo = true;
         i218CcuAtivo = true;
         AV14Pgmname = "core.CentroDeCusto_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120Q2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound26 ;
      private short nIsDirty_26 ;
      private int trnEnded ;
      private int Z208CcuID ;
      private int A208CcuID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z516CcuDelUsuId ;
      private string A516CcuDelUsuId ;
      private string sMode26 ;
      private DateTime Z513CcuDelDataHora ;
      private DateTime A513CcuDelDataHora ;
      private DateTime Z514CcuDelData ;
      private DateTime A514CcuDelData ;
      private DateTime Z515CcuDelHora ;
      private DateTime A515CcuDelHora ;
      private bool returnInSub ;
      private bool Z218CcuAtivo ;
      private bool A218CcuAtivo ;
      private bool Z512CcuDel ;
      private bool A512CcuDel ;
      private bool n513CcuDelDataHora ;
      private bool n514CcuDelData ;
      private bool n515CcuDelHora ;
      private bool n516CcuDelUsuId ;
      private bool n517CcuDelUsuNome ;
      private bool O512CcuDel ;
      private bool Gx_longc ;
      private bool i218CcuAtivo ;
      private bool mustCommit ;
      private string Z517CcuDelUsuNome ;
      private string A517CcuDelUsuNome ;
      private string Z209CcuSigla ;
      private string A209CcuSigla ;
      private string Z210CcuNome ;
      private string A210CcuNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtCentroDeCusto bccore_CentroDeCusto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000Q4_A208CcuID ;
      private DateTime[] BC000Q4_A513CcuDelDataHora ;
      private bool[] BC000Q4_n513CcuDelDataHora ;
      private DateTime[] BC000Q4_A514CcuDelData ;
      private bool[] BC000Q4_n514CcuDelData ;
      private DateTime[] BC000Q4_A515CcuDelHora ;
      private bool[] BC000Q4_n515CcuDelHora ;
      private string[] BC000Q4_A516CcuDelUsuId ;
      private bool[] BC000Q4_n516CcuDelUsuId ;
      private string[] BC000Q4_A517CcuDelUsuNome ;
      private bool[] BC000Q4_n517CcuDelUsuNome ;
      private string[] BC000Q4_A209CcuSigla ;
      private string[] BC000Q4_A210CcuNome ;
      private bool[] BC000Q4_A218CcuAtivo ;
      private bool[] BC000Q4_A512CcuDel ;
      private string[] BC000Q5_A209CcuSigla ;
      private int[] BC000Q6_A208CcuID ;
      private int[] BC000Q3_A208CcuID ;
      private DateTime[] BC000Q3_A513CcuDelDataHora ;
      private bool[] BC000Q3_n513CcuDelDataHora ;
      private DateTime[] BC000Q3_A514CcuDelData ;
      private bool[] BC000Q3_n514CcuDelData ;
      private DateTime[] BC000Q3_A515CcuDelHora ;
      private bool[] BC000Q3_n515CcuDelHora ;
      private string[] BC000Q3_A516CcuDelUsuId ;
      private bool[] BC000Q3_n516CcuDelUsuId ;
      private string[] BC000Q3_A517CcuDelUsuNome ;
      private bool[] BC000Q3_n517CcuDelUsuNome ;
      private string[] BC000Q3_A209CcuSigla ;
      private string[] BC000Q3_A210CcuNome ;
      private bool[] BC000Q3_A218CcuAtivo ;
      private bool[] BC000Q3_A512CcuDel ;
      private int[] BC000Q2_A208CcuID ;
      private DateTime[] BC000Q2_A513CcuDelDataHora ;
      private bool[] BC000Q2_n513CcuDelDataHora ;
      private DateTime[] BC000Q2_A514CcuDelData ;
      private bool[] BC000Q2_n514CcuDelData ;
      private DateTime[] BC000Q2_A515CcuDelHora ;
      private bool[] BC000Q2_n515CcuDelHora ;
      private string[] BC000Q2_A516CcuDelUsuId ;
      private bool[] BC000Q2_n516CcuDelUsuId ;
      private string[] BC000Q2_A517CcuDelUsuNome ;
      private bool[] BC000Q2_n517CcuDelUsuNome ;
      private string[] BC000Q2_A209CcuSigla ;
      private string[] BC000Q2_A210CcuNome ;
      private bool[] BC000Q2_A218CcuAtivo ;
      private bool[] BC000Q2_A512CcuDel ;
      private int[] BC000Q8_A208CcuID ;
      private int[] BC000Q11_A208CcuID ;
      private DateTime[] BC000Q11_A513CcuDelDataHora ;
      private bool[] BC000Q11_n513CcuDelDataHora ;
      private DateTime[] BC000Q11_A514CcuDelData ;
      private bool[] BC000Q11_n514CcuDelData ;
      private DateTime[] BC000Q11_A515CcuDelHora ;
      private bool[] BC000Q11_n515CcuDelHora ;
      private string[] BC000Q11_A516CcuDelUsuId ;
      private bool[] BC000Q11_n516CcuDelUsuId ;
      private string[] BC000Q11_A517CcuDelUsuNome ;
      private bool[] BC000Q11_n517CcuDelUsuNome ;
      private string[] BC000Q11_A209CcuSigla ;
      private string[] BC000Q11_A210CcuNome ;
      private bool[] BC000Q11_A218CcuAtivo ;
      private bool[] BC000Q11_A512CcuDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class centrodecusto_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class centrodecusto_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000Q4;
        prmBC000Q4 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q5;
        prmBC000Q5 = new Object[] {
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q6;
        prmBC000Q6 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q3;
        prmBC000Q3 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q2;
        prmBC000Q2 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q7;
        prmBC000Q7 = new Object[] {
        new ParDef("CcuDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CcuDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CcuDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CcuDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CcuDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuNome",GXType.VarChar,80,0) ,
        new ParDef("CcuAtivo",GXType.Boolean,4,0) ,
        new ParDef("CcuDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000Q8;
        prmBC000Q8 = new Object[] {
        };
        Object[] prmBC000Q9;
        prmBC000Q9 = new Object[] {
        new ParDef("CcuDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CcuDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CcuDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CcuDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CcuDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuNome",GXType.VarChar,80,0) ,
        new ParDef("CcuAtivo",GXType.Boolean,4,0) ,
        new ParDef("CcuDel",GXType.Boolean,4,0) ,
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q10;
        prmBC000Q10 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmBC000Q11;
        prmBC000Q11 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000Q2", "SELECT CcuID, CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel FROM tb_centrodecusto WHERE CcuID = :CcuID  FOR UPDATE OF tb_centrodecusto",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q3", "SELECT CcuID, CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel FROM tb_centrodecusto WHERE CcuID = :CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q4", "SELECT TM1.CcuID, TM1.CcuDelDataHora, TM1.CcuDelData, TM1.CcuDelHora, TM1.CcuDelUsuId, TM1.CcuDelUsuNome, TM1.CcuSigla, TM1.CcuNome, TM1.CcuAtivo, TM1.CcuDel FROM tb_centrodecusto TM1 WHERE TM1.CcuID = :CcuID ORDER BY TM1.CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q5", "SELECT CcuSigla FROM tb_centrodecusto WHERE (CcuSigla = :CcuSigla) AND (Not ( CcuID = :CcuID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q6", "SELECT CcuID FROM tb_centrodecusto WHERE CcuID = :CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q7", "SAVEPOINT gxupdate;INSERT INTO tb_centrodecusto(CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel) VALUES(:CcuDelDataHora, :CcuDelData, :CcuDelHora, :CcuDelUsuId, :CcuDelUsuNome, :CcuSigla, :CcuNome, :CcuAtivo, :CcuDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000Q7)
           ,new CursorDef("BC000Q8", "SELECT currval('CcuID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000Q9", "SAVEPOINT gxupdate;UPDATE tb_centrodecusto SET CcuDelDataHora=:CcuDelDataHora, CcuDelData=:CcuDelData, CcuDelHora=:CcuDelHora, CcuDelUsuId=:CcuDelUsuId, CcuDelUsuNome=:CcuDelUsuNome, CcuSigla=:CcuSigla, CcuNome=:CcuNome, CcuAtivo=:CcuAtivo, CcuDel=:CcuDel  WHERE CcuID = :CcuID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q9)
           ,new CursorDef("BC000Q10", "SAVEPOINT gxupdate;DELETE FROM tb_centrodecusto  WHERE CcuID = :CcuID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000Q10)
           ,new CursorDef("BC000Q11", "SELECT TM1.CcuID, TM1.CcuDelDataHora, TM1.CcuDelData, TM1.CcuDelHora, TM1.CcuDelUsuId, TM1.CcuDelUsuNome, TM1.CcuSigla, TM1.CcuNome, TM1.CcuAtivo, TM1.CcuDel FROM tb_centrodecusto TM1 WHERE TM1.CcuID = :CcuID ORDER BY TM1.CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000Q11,100, GxCacheFrequency.OFF ,true,false )
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 9 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
     }
  }

}

}
