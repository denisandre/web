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
   public class negociopjfluxo_bc : GxSilentTrn, IGxSilentTrn
   {
      public negociopjfluxo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjfluxo_bc( IGxContext context )
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
         ReadRow1944( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1944( ) ;
         standaloneModal( ) ;
         AddRow1944( ) ;
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
            E11192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z345NegID = A345NegID;
               Z626NefChave = A626NefChave;
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1944( ) ;
            }
            else
            {
               CheckExtendedTable1944( ) ;
               if ( AnyError == 0 )
               {
                  ZM1944( 19) ;
               }
               CloseExtendedTableCursors1944( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12192( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11192( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV12AuditingObject,  AV23Pgmname) ;
      }

      protected void ZM1944( short GX_JID )
      {
         if ( ( GX_JID == 18 ) || ( GX_JID == 0 ) )
         {
            Z629NefInsDataHora = A629NefInsDataHora;
            Z630NefInsData = A630NefInsData;
            Z631NefInsHora = A631NefInsHora;
            Z632NefInsUsuId = A632NefInsUsuId;
            Z633NefInsUsuNome = A633NefInsUsuNome;
            Z634NefUpdDataHora = A634NefUpdDataHora;
            Z635NefUpdData = A635NefUpdData;
            Z636NefUpdHora = A636NefUpdHora;
            Z637NefUpdUsuId = A637NefUpdUsuId;
            Z638NefUpdUsuNome = A638NefUpdUsuNome;
            Z627NefConfirmado = A627NefConfirmado;
            Z628NefTexto = A628NefTexto;
            Z639NefValor = A639NefValor;
         }
         if ( ( GX_JID == 19 ) || ( GX_JID == 0 ) )
         {
         }
         if ( GX_JID == -18 )
         {
            Z626NefChave = A626NefChave;
            Z629NefInsDataHora = A629NefInsDataHora;
            Z630NefInsData = A630NefInsData;
            Z631NefInsHora = A631NefInsHora;
            Z632NefInsUsuId = A632NefInsUsuId;
            Z633NefInsUsuNome = A633NefInsUsuNome;
            Z634NefUpdDataHora = A634NefUpdDataHora;
            Z635NefUpdData = A635NefUpdData;
            Z636NefUpdHora = A636NefUpdHora;
            Z637NefUpdUsuId = A637NefUpdUsuId;
            Z638NefUpdUsuNome = A638NefUpdUsuNome;
            Z627NefConfirmado = A627NefConfirmado;
            Z628NefTexto = A628NefTexto;
            Z639NefValor = A639NefValor;
            Z345NegID = A345NegID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "core.NegocioPJFluxo_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1944( )
      {
         /* Using cursor BC00195 */
         pr_default.execute(3, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound44 = 1;
            A629NefInsDataHora = BC00195_A629NefInsDataHora[0];
            A630NefInsData = BC00195_A630NefInsData[0];
            A631NefInsHora = BC00195_A631NefInsHora[0];
            A632NefInsUsuId = BC00195_A632NefInsUsuId[0];
            A633NefInsUsuNome = BC00195_A633NefInsUsuNome[0];
            A634NefUpdDataHora = BC00195_A634NefUpdDataHora[0];
            n634NefUpdDataHora = BC00195_n634NefUpdDataHora[0];
            A635NefUpdData = BC00195_A635NefUpdData[0];
            n635NefUpdData = BC00195_n635NefUpdData[0];
            A636NefUpdHora = BC00195_A636NefUpdHora[0];
            n636NefUpdHora = BC00195_n636NefUpdHora[0];
            A637NefUpdUsuId = BC00195_A637NefUpdUsuId[0];
            n637NefUpdUsuId = BC00195_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = BC00195_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = BC00195_n638NefUpdUsuNome[0];
            A627NefConfirmado = BC00195_A627NefConfirmado[0];
            A628NefTexto = BC00195_A628NefTexto[0];
            n628NefTexto = BC00195_n628NefTexto[0];
            A639NefValor = BC00195_A639NefValor[0];
            n639NefValor = BC00195_n639NefValor[0];
            ZM1944( -18) ;
         }
         pr_default.close(3);
         OnLoadActions1944( ) ;
      }

      protected void OnLoadActions1944( )
      {
      }

      protected void CheckExtendedTable1944( )
      {
         nIsDirty_44 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00194 */
         pr_default.execute(2, new Object[] {A345NegID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
            AnyError = 1;
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A626NefChave, "DOCANALISE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCREGISTRARENVIOCAF") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCREGISTRARRETORNOCAF") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCANALISECREDITO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPCONFECCIONAR") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPREGENVIOCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPREGRESPCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONENTREGAGARANTIA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCOMPORGARANTIA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONVERIFICACONTAATIVA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCONTRATARPRODUTO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCONFECCONTRATO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONREGENVCONTCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONREGRESCONTCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONRECOLHERASSINATURA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ENCREALIZADOONBOARD") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ENCPESQUISAAVALIACAO") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Chave do Fluxo fora do intervalo", "OutOfRange", 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1944( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1944( )
      {
         /* Using cursor BC00196 */
         pr_default.execute(4, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00193 */
         pr_default.execute(1, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1944( 18) ;
            RcdFound44 = 1;
            A626NefChave = BC00193_A626NefChave[0];
            A629NefInsDataHora = BC00193_A629NefInsDataHora[0];
            A630NefInsData = BC00193_A630NefInsData[0];
            A631NefInsHora = BC00193_A631NefInsHora[0];
            A632NefInsUsuId = BC00193_A632NefInsUsuId[0];
            A633NefInsUsuNome = BC00193_A633NefInsUsuNome[0];
            A634NefUpdDataHora = BC00193_A634NefUpdDataHora[0];
            n634NefUpdDataHora = BC00193_n634NefUpdDataHora[0];
            A635NefUpdData = BC00193_A635NefUpdData[0];
            n635NefUpdData = BC00193_n635NefUpdData[0];
            A636NefUpdHora = BC00193_A636NefUpdHora[0];
            n636NefUpdHora = BC00193_n636NefUpdHora[0];
            A637NefUpdUsuId = BC00193_A637NefUpdUsuId[0];
            n637NefUpdUsuId = BC00193_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = BC00193_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = BC00193_n638NefUpdUsuNome[0];
            A627NefConfirmado = BC00193_A627NefConfirmado[0];
            A628NefTexto = BC00193_A628NefTexto[0];
            n628NefTexto = BC00193_n628NefTexto[0];
            A639NefValor = BC00193_A639NefValor[0];
            n639NefValor = BC00193_n639NefValor[0];
            A345NegID = BC00193_A345NegID[0];
            Z345NegID = A345NegID;
            Z626NefChave = A626NefChave;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1944( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1944( ) ;
            }
            Gx_mode = sMode44;
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1944( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode44;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1944( ) ;
         if ( RcdFound44 == 0 )
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
         CONFIRM_190( ) ;
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

      protected void CheckOptimisticConcurrency1944( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00192 */
            pr_default.execute(0, new Object[] {A345NegID, A626NefChave});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fluxo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z629NefInsDataHora != BC00192_A629NefInsDataHora[0] ) || ( Z630NefInsData != BC00192_A630NefInsData[0] ) || ( Z631NefInsHora != BC00192_A631NefInsHora[0] ) || ( StringUtil.StrCmp(Z632NefInsUsuId, BC00192_A632NefInsUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z633NefInsUsuNome, BC00192_A633NefInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z634NefUpdDataHora != BC00192_A634NefUpdDataHora[0] ) || ( Z635NefUpdData != BC00192_A635NefUpdData[0] ) || ( Z636NefUpdHora != BC00192_A636NefUpdHora[0] ) || ( StringUtil.StrCmp(Z637NefUpdUsuId, BC00192_A637NefUpdUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z638NefUpdUsuNome, BC00192_A638NefUpdUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z627NefConfirmado != BC00192_A627NefConfirmado[0] ) || ( StringUtil.StrCmp(Z628NefTexto, BC00192_A628NefTexto[0]) != 0 ) || ( Z639NefValor != BC00192_A639NefValor[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_fluxo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1944( )
      {
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1944( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1944( 0) ;
            CheckOptimisticConcurrency1944( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1944( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1944( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00197 */
                     pr_default.execute(5, new Object[] {A626NefChave, A629NefInsDataHora, A630NefInsData, A631NefInsHora, A632NefInsUsuId, A633NefInsUsuNome, n634NefUpdDataHora, A634NefUpdDataHora, n635NefUpdData, A635NefUpdData, n636NefUpdHora, A636NefUpdHora, n637NefUpdUsuId, A637NefUpdUsuId, n638NefUpdUsuNome, A638NefUpdUsuNome, A627NefConfirmado, n628NefTexto, A628NefTexto, n639NefValor, A639NefValor, A345NegID});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
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
               Load1944( ) ;
            }
            EndLevel1944( ) ;
         }
         CloseExtendedTableCursors1944( ) ;
      }

      protected void Update1944( )
      {
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1944( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1944( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1944( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1944( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00198 */
                     pr_default.execute(6, new Object[] {A629NefInsDataHora, A630NefInsData, A631NefInsHora, A632NefInsUsuId, A633NefInsUsuNome, n634NefUpdDataHora, A634NefUpdDataHora, n635NefUpdData, A635NefUpdData, n636NefUpdHora, A636NefUpdHora, n637NefUpdUsuId, A637NefUpdUsuId, n638NefUpdUsuNome, A638NefUpdUsuNome, A627NefConfirmado, n628NefTexto, A628NefTexto, n639NefValor, A639NefValor, A345NegID, A626NefChave});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fluxo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1944( ) ;
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
            EndLevel1944( ) ;
         }
         CloseExtendedTableCursors1944( ) ;
      }

      protected void DeferredUpdate1944( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1944( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1944( ) ;
            AfterConfirm1944( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1944( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00199 */
                  pr_default.execute(7, new Object[] {A345NegID, A626NefChave});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1944( ) ;
         Gx_mode = sMode44;
      }

      protected void OnDeleteControls1944( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1944( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1944( ) ;
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

      public void ScanKeyStart1944( )
      {
         /* Scan By routine */
         /* Using cursor BC001910 */
         pr_default.execute(8, new Object[] {A345NegID, A626NefChave});
         RcdFound44 = 0;
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound44 = 1;
            A626NefChave = BC001910_A626NefChave[0];
            A629NefInsDataHora = BC001910_A629NefInsDataHora[0];
            A630NefInsData = BC001910_A630NefInsData[0];
            A631NefInsHora = BC001910_A631NefInsHora[0];
            A632NefInsUsuId = BC001910_A632NefInsUsuId[0];
            A633NefInsUsuNome = BC001910_A633NefInsUsuNome[0];
            A634NefUpdDataHora = BC001910_A634NefUpdDataHora[0];
            n634NefUpdDataHora = BC001910_n634NefUpdDataHora[0];
            A635NefUpdData = BC001910_A635NefUpdData[0];
            n635NefUpdData = BC001910_n635NefUpdData[0];
            A636NefUpdHora = BC001910_A636NefUpdHora[0];
            n636NefUpdHora = BC001910_n636NefUpdHora[0];
            A637NefUpdUsuId = BC001910_A637NefUpdUsuId[0];
            n637NefUpdUsuId = BC001910_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = BC001910_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = BC001910_n638NefUpdUsuNome[0];
            A627NefConfirmado = BC001910_A627NefConfirmado[0];
            A628NefTexto = BC001910_A628NefTexto[0];
            n628NefTexto = BC001910_n628NefTexto[0];
            A639NefValor = BC001910_A639NefValor[0];
            n639NefValor = BC001910_n639NefValor[0];
            A345NegID = BC001910_A345NegID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1944( )
      {
         /* Scan next routine */
         pr_default.readNext(8);
         RcdFound44 = 0;
         ScanKeyLoad1944( ) ;
      }

      protected void ScanKeyLoad1944( )
      {
         sMode44 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound44 = 1;
            A626NefChave = BC001910_A626NefChave[0];
            A629NefInsDataHora = BC001910_A629NefInsDataHora[0];
            A630NefInsData = BC001910_A630NefInsData[0];
            A631NefInsHora = BC001910_A631NefInsHora[0];
            A632NefInsUsuId = BC001910_A632NefInsUsuId[0];
            A633NefInsUsuNome = BC001910_A633NefInsUsuNome[0];
            A634NefUpdDataHora = BC001910_A634NefUpdDataHora[0];
            n634NefUpdDataHora = BC001910_n634NefUpdDataHora[0];
            A635NefUpdData = BC001910_A635NefUpdData[0];
            n635NefUpdData = BC001910_n635NefUpdData[0];
            A636NefUpdHora = BC001910_A636NefUpdHora[0];
            n636NefUpdHora = BC001910_n636NefUpdHora[0];
            A637NefUpdUsuId = BC001910_A637NefUpdUsuId[0];
            n637NefUpdUsuId = BC001910_n637NefUpdUsuId[0];
            A638NefUpdUsuNome = BC001910_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = BC001910_n638NefUpdUsuNome[0];
            A627NefConfirmado = BC001910_A627NefConfirmado[0];
            A628NefTexto = BC001910_A628NefTexto[0];
            n628NefTexto = BC001910_n628NefTexto[0];
            A639NefValor = BC001910_A639NefValor[0];
            n639NefValor = BC001910_n639NefValor[0];
            A345NegID = BC001910_A345NegID[0];
         }
         Gx_mode = sMode44;
      }

      protected void ScanKeyEnd1944( )
      {
         pr_default.close(8);
      }

      protected void AfterConfirm1944( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1944( )
      {
         /* Before Insert Rules */
         A629NefInsDataHora = DateTimeUtil.NowMS( context);
         A632NefInsUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         A633NefInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A626NefChave)) || BC00193_n626NefChave[0] )
         {
            GX_msglist.addItem("Não identificado a Chave do Fluxo do Negócio!", 1, "");
            AnyError = 1;
         }
         A630NefInsData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A629NefInsDataHora) ) ;
         A631NefInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A629NefInsDataHora));
      }

      protected void BeforeUpdate1944( )
      {
         /* Before Update Rules */
         A634NefUpdDataHora = DateTimeUtil.NowMS( context);
         n634NefUpdDataHora = false;
         A637NefUpdUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n637NefUpdUsuId = false;
         A638NefUpdUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n638NefUpdUsuNome = false;
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         A635NefUpdData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A634NefUpdDataHora) ) ;
         n635NefUpdData = false;
         A636NefUpdHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A634NefUpdDataHora));
         n636NefUpdHora = false;
      }

      protected void BeforeDelete1944( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
      }

      protected void BeforeComplete1944( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1944( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1944( )
      {
      }

      protected void send_integrity_lvl_hashes1944( )
      {
      }

      protected void AddRow1944( )
      {
         VarsToRow44( bccore_NegocioPJFluxo) ;
      }

      protected void ReadRow1944( )
      {
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
      }

      protected void InitializeNonKey1944( )
      {
         AV12AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         A630NefInsData = (DateTime)(DateTime.MinValue);
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         A632NefInsUsuId = "";
         A633NefInsUsuNome = "";
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         n634NefUpdDataHora = false;
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         n635NefUpdData = false;
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         n636NefUpdHora = false;
         A637NefUpdUsuId = "";
         n637NefUpdUsuId = false;
         A638NefUpdUsuNome = "";
         n638NefUpdUsuNome = false;
         A627NefConfirmado = false;
         A628NefTexto = "";
         n628NefTexto = false;
         A639NefValor = 0;
         n639NefValor = false;
         Z629NefInsDataHora = (DateTime)(DateTime.MinValue);
         Z630NefInsData = (DateTime)(DateTime.MinValue);
         Z631NefInsHora = (DateTime)(DateTime.MinValue);
         Z632NefInsUsuId = "";
         Z633NefInsUsuNome = "";
         Z634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         Z635NefUpdData = (DateTime)(DateTime.MinValue);
         Z636NefUpdHora = (DateTime)(DateTime.MinValue);
         Z637NefUpdUsuId = "";
         Z638NefUpdUsuNome = "";
         Z627NefConfirmado = false;
         Z628NefTexto = "";
         Z639NefValor = 0;
      }

      protected void InitAll1944( )
      {
         A345NegID = Guid.Empty;
         A626NefChave = "";
         InitializeNonKey1944( ) ;
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

      public void VarsToRow44( GeneXus.Programs.core.SdtNegocioPJFluxo obj44 )
      {
         obj44.gxTpr_Mode = Gx_mode;
         obj44.gxTpr_Nefinsdatahora = A629NefInsDataHora;
         obj44.gxTpr_Nefinsdata = A630NefInsData;
         obj44.gxTpr_Nefinshora = A631NefInsHora;
         obj44.gxTpr_Nefinsusuid = A632NefInsUsuId;
         obj44.gxTpr_Nefinsusunome = A633NefInsUsuNome;
         obj44.gxTpr_Nefupddatahora = A634NefUpdDataHora;
         obj44.gxTpr_Nefupddata = A635NefUpdData;
         obj44.gxTpr_Nefupdhora = A636NefUpdHora;
         obj44.gxTpr_Nefupdusuid = A637NefUpdUsuId;
         obj44.gxTpr_Nefupdusunome = A638NefUpdUsuNome;
         obj44.gxTpr_Nefconfirmado = A627NefConfirmado;
         obj44.gxTpr_Neftexto = A628NefTexto;
         obj44.gxTpr_Nefvalor = A639NefValor;
         obj44.gxTpr_Negid = A345NegID;
         obj44.gxTpr_Nefchave = A626NefChave;
         obj44.gxTpr_Negid_Z = Z345NegID;
         obj44.gxTpr_Nefchave_Z = Z626NefChave;
         obj44.gxTpr_Nefconfirmado_Z = Z627NefConfirmado;
         obj44.gxTpr_Neftexto_Z = Z628NefTexto;
         obj44.gxTpr_Nefinsdatahora_Z = Z629NefInsDataHora;
         obj44.gxTpr_Nefinsdata_Z = Z630NefInsData;
         obj44.gxTpr_Nefinshora_Z = Z631NefInsHora;
         obj44.gxTpr_Nefinsusuid_Z = Z632NefInsUsuId;
         obj44.gxTpr_Nefinsusunome_Z = Z633NefInsUsuNome;
         obj44.gxTpr_Nefupddatahora_Z = Z634NefUpdDataHora;
         obj44.gxTpr_Nefupddata_Z = Z635NefUpdData;
         obj44.gxTpr_Nefupdhora_Z = Z636NefUpdHora;
         obj44.gxTpr_Nefupdusuid_Z = Z637NefUpdUsuId;
         obj44.gxTpr_Nefupdusunome_Z = Z638NefUpdUsuNome;
         obj44.gxTpr_Nefvalor_Z = Z639NefValor;
         obj44.gxTpr_Neftexto_N = (short)(Convert.ToInt16(n628NefTexto));
         obj44.gxTpr_Nefupddatahora_N = (short)(Convert.ToInt16(n634NefUpdDataHora));
         obj44.gxTpr_Nefupddata_N = (short)(Convert.ToInt16(n635NefUpdData));
         obj44.gxTpr_Nefupdhora_N = (short)(Convert.ToInt16(n636NefUpdHora));
         obj44.gxTpr_Nefupdusuid_N = (short)(Convert.ToInt16(n637NefUpdUsuId));
         obj44.gxTpr_Nefupdusunome_N = (short)(Convert.ToInt16(n638NefUpdUsuNome));
         obj44.gxTpr_Nefvalor_N = (short)(Convert.ToInt16(n639NefValor));
         obj44.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow44( GeneXus.Programs.core.SdtNegocioPJFluxo obj44 )
      {
         obj44.gxTpr_Negid = A345NegID;
         obj44.gxTpr_Nefchave = A626NefChave;
         return  ;
      }

      public void RowToVars44( GeneXus.Programs.core.SdtNegocioPJFluxo obj44 ,
                               int forceLoad )
      {
         Gx_mode = obj44.gxTpr_Mode;
         A629NefInsDataHora = obj44.gxTpr_Nefinsdatahora;
         A630NefInsData = obj44.gxTpr_Nefinsdata;
         A631NefInsHora = obj44.gxTpr_Nefinshora;
         A632NefInsUsuId = obj44.gxTpr_Nefinsusuid;
         A633NefInsUsuNome = obj44.gxTpr_Nefinsusunome;
         A634NefUpdDataHora = obj44.gxTpr_Nefupddatahora;
         n634NefUpdDataHora = false;
         A635NefUpdData = obj44.gxTpr_Nefupddata;
         n635NefUpdData = false;
         A636NefUpdHora = obj44.gxTpr_Nefupdhora;
         n636NefUpdHora = false;
         A637NefUpdUsuId = obj44.gxTpr_Nefupdusuid;
         n637NefUpdUsuId = false;
         A638NefUpdUsuNome = obj44.gxTpr_Nefupdusunome;
         n638NefUpdUsuNome = false;
         A627NefConfirmado = obj44.gxTpr_Nefconfirmado;
         A628NefTexto = obj44.gxTpr_Neftexto;
         n628NefTexto = false;
         A639NefValor = obj44.gxTpr_Nefvalor;
         n639NefValor = false;
         A345NegID = obj44.gxTpr_Negid;
         A626NefChave = obj44.gxTpr_Nefchave;
         Z345NegID = obj44.gxTpr_Negid_Z;
         Z626NefChave = obj44.gxTpr_Nefchave_Z;
         Z627NefConfirmado = obj44.gxTpr_Nefconfirmado_Z;
         Z628NefTexto = obj44.gxTpr_Neftexto_Z;
         Z629NefInsDataHora = obj44.gxTpr_Nefinsdatahora_Z;
         Z630NefInsData = obj44.gxTpr_Nefinsdata_Z;
         Z631NefInsHora = obj44.gxTpr_Nefinshora_Z;
         Z632NefInsUsuId = obj44.gxTpr_Nefinsusuid_Z;
         Z633NefInsUsuNome = obj44.gxTpr_Nefinsusunome_Z;
         Z634NefUpdDataHora = obj44.gxTpr_Nefupddatahora_Z;
         Z635NefUpdData = obj44.gxTpr_Nefupddata_Z;
         Z636NefUpdHora = obj44.gxTpr_Nefupdhora_Z;
         Z637NefUpdUsuId = obj44.gxTpr_Nefupdusuid_Z;
         Z638NefUpdUsuNome = obj44.gxTpr_Nefupdusunome_Z;
         Z639NefValor = obj44.gxTpr_Nefvalor_Z;
         n628NefTexto = (bool)(Convert.ToBoolean(obj44.gxTpr_Neftexto_N));
         n634NefUpdDataHora = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefupddatahora_N));
         n635NefUpdData = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefupddata_N));
         n636NefUpdHora = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefupdhora_N));
         n637NefUpdUsuId = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefupdusuid_N));
         n638NefUpdUsuNome = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefupdusunome_N));
         n639NefValor = (bool)(Convert.ToBoolean(obj44.gxTpr_Nefvalor_N));
         Gx_mode = obj44.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A345NegID = (Guid)getParm(obj,0);
         A626NefChave = (string)getParm(obj,1);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1944( ) ;
         ScanKeyStart1944( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001911 */
            pr_default.execute(9, new Object[] {A345NegID});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z345NegID = A345NegID;
            Z626NefChave = A626NefChave;
         }
         ZM1944( -18) ;
         OnLoadActions1944( ) ;
         AddRow1944( ) ;
         ScanKeyEnd1944( ) ;
         if ( RcdFound44 == 0 )
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
         RowToVars44( bccore_NegocioPJFluxo, 0) ;
         ScanKeyStart1944( ) ;
         if ( RcdFound44 == 0 )
         {
            Gx_mode = "INS";
            /* Using cursor BC001911 */
            pr_default.execute(9, new Object[] {A345NegID});
            if ( (pr_default.getStatus(9) == 101) )
            {
               GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
               AnyError = 1;
            }
            pr_default.close(9);
         }
         else
         {
            Gx_mode = "UPD";
            Z345NegID = A345NegID;
            Z626NefChave = A626NefChave;
         }
         ZM1944( -18) ;
         OnLoadActions1944( ) ;
         AddRow1944( ) ;
         ScanKeyEnd1944( ) ;
         if ( RcdFound44 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1944( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1944( ) ;
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
               {
                  A345NegID = Z345NegID;
                  A626NefChave = Z626NefChave;
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
                  Update1944( ) ;
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
                  if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
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
                        Insert1944( ) ;
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
                        Insert1944( ) ;
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
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
         SaveImpl( ) ;
         VarsToRow44( bccore_NegocioPJFluxo) ;
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
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1944( ) ;
         AfterTrn( ) ;
         VarsToRow44( bccore_NegocioPJFluxo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow44( bccore_NegocioPJFluxo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtNegocioPJFluxo auxBC = new GeneXus.Programs.core.SdtNegocioPJFluxo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A345NegID, A626NefChave);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_NegocioPJFluxo);
               auxBC.Save();
               bccore_NegocioPJFluxo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
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
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1944( ) ;
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
               VarsToRow44( bccore_NegocioPJFluxo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow44( bccore_NegocioPJFluxo) ;
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
         RowToVars44( bccore_NegocioPJFluxo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1944( ) ;
         if ( RcdFound44 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
            {
               A345NegID = Z345NegID;
               A626NefChave = Z626NefChave;
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
            if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
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
         context.RollbackDataStores("core.negociopjfluxo_bc",pr_default);
         VarsToRow44( bccore_NegocioPJFluxo) ;
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
         Gx_mode = bccore_NegocioPJFluxo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_NegocioPJFluxo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_NegocioPJFluxo )
         {
            bccore_NegocioPJFluxo = (GeneXus.Programs.core.SdtNegocioPJFluxo)(sdt);
            if ( StringUtil.StrCmp(bccore_NegocioPJFluxo.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJFluxo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow44( bccore_NegocioPJFluxo) ;
            }
            else
            {
               RowToVars44( bccore_NegocioPJFluxo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_NegocioPJFluxo.gxTpr_Mode, "") == 0 )
            {
               bccore_NegocioPJFluxo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars44( bccore_NegocioPJFluxo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtNegocioPJFluxo NegocioPJFluxo_BC
      {
         get {
            return bccore_NegocioPJFluxo ;
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
            return "negociopjfluxo_Execute" ;
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
         Z345NegID = Guid.Empty;
         A345NegID = Guid.Empty;
         Z626NefChave = "";
         A626NefChave = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV12AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV23Pgmname = "";
         Z629NefInsDataHora = (DateTime)(DateTime.MinValue);
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         Z630NefInsData = (DateTime)(DateTime.MinValue);
         A630NefInsData = (DateTime)(DateTime.MinValue);
         Z631NefInsHora = (DateTime)(DateTime.MinValue);
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         Z632NefInsUsuId = "";
         A632NefInsUsuId = "";
         Z633NefInsUsuNome = "";
         A633NefInsUsuNome = "";
         Z634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         Z635NefUpdData = (DateTime)(DateTime.MinValue);
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         Z636NefUpdHora = (DateTime)(DateTime.MinValue);
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         Z637NefUpdUsuId = "";
         A637NefUpdUsuId = "";
         Z638NefUpdUsuNome = "";
         A638NefUpdUsuNome = "";
         Z628NefTexto = "";
         A628NefTexto = "";
         BC00195_A626NefChave = new string[] {""} ;
         BC00195_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00195_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         BC00195_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00195_A632NefInsUsuId = new string[] {""} ;
         BC00195_A633NefInsUsuNome = new string[] {""} ;
         BC00195_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00195_n634NefUpdDataHora = new bool[] {false} ;
         BC00195_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00195_n635NefUpdData = new bool[] {false} ;
         BC00195_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00195_n636NefUpdHora = new bool[] {false} ;
         BC00195_A637NefUpdUsuId = new string[] {""} ;
         BC00195_n637NefUpdUsuId = new bool[] {false} ;
         BC00195_A638NefUpdUsuNome = new string[] {""} ;
         BC00195_n638NefUpdUsuNome = new bool[] {false} ;
         BC00195_A627NefConfirmado = new bool[] {false} ;
         BC00195_A628NefTexto = new string[] {""} ;
         BC00195_n628NefTexto = new bool[] {false} ;
         BC00195_A639NefValor = new short[1] ;
         BC00195_n639NefValor = new bool[] {false} ;
         BC00195_A345NegID = new Guid[] {Guid.Empty} ;
         BC00194_A345NegID = new Guid[] {Guid.Empty} ;
         BC00196_A345NegID = new Guid[] {Guid.Empty} ;
         BC00196_A626NefChave = new string[] {""} ;
         BC00193_A626NefChave = new string[] {""} ;
         BC00193_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00193_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         BC00193_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00193_A632NefInsUsuId = new string[] {""} ;
         BC00193_A633NefInsUsuNome = new string[] {""} ;
         BC00193_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00193_n634NefUpdDataHora = new bool[] {false} ;
         BC00193_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00193_n635NefUpdData = new bool[] {false} ;
         BC00193_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00193_n636NefUpdHora = new bool[] {false} ;
         BC00193_A637NefUpdUsuId = new string[] {""} ;
         BC00193_n637NefUpdUsuId = new bool[] {false} ;
         BC00193_A638NefUpdUsuNome = new string[] {""} ;
         BC00193_n638NefUpdUsuNome = new bool[] {false} ;
         BC00193_A627NefConfirmado = new bool[] {false} ;
         BC00193_A628NefTexto = new string[] {""} ;
         BC00193_n628NefTexto = new bool[] {false} ;
         BC00193_A639NefValor = new short[1] ;
         BC00193_n639NefValor = new bool[] {false} ;
         BC00193_A345NegID = new Guid[] {Guid.Empty} ;
         sMode44 = "";
         BC00192_A626NefChave = new string[] {""} ;
         BC00192_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00192_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         BC00192_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         BC00192_A632NefInsUsuId = new string[] {""} ;
         BC00192_A633NefInsUsuNome = new string[] {""} ;
         BC00192_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00192_n634NefUpdDataHora = new bool[] {false} ;
         BC00192_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         BC00192_n635NefUpdData = new bool[] {false} ;
         BC00192_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC00192_n636NefUpdHora = new bool[] {false} ;
         BC00192_A637NefUpdUsuId = new string[] {""} ;
         BC00192_n637NefUpdUsuId = new bool[] {false} ;
         BC00192_A638NefUpdUsuNome = new string[] {""} ;
         BC00192_n638NefUpdUsuNome = new bool[] {false} ;
         BC00192_A627NefConfirmado = new bool[] {false} ;
         BC00192_A628NefTexto = new string[] {""} ;
         BC00192_n628NefTexto = new bool[] {false} ;
         BC00192_A639NefValor = new short[1] ;
         BC00192_n639NefValor = new bool[] {false} ;
         BC00192_A345NegID = new Guid[] {Guid.Empty} ;
         BC001910_A626NefChave = new string[] {""} ;
         BC001910_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001910_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         BC001910_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         BC001910_A632NefInsUsuId = new string[] {""} ;
         BC001910_A633NefInsUsuNome = new string[] {""} ;
         BC001910_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001910_n634NefUpdDataHora = new bool[] {false} ;
         BC001910_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         BC001910_n635NefUpdData = new bool[] {false} ;
         BC001910_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         BC001910_n636NefUpdHora = new bool[] {false} ;
         BC001910_A637NefUpdUsuId = new string[] {""} ;
         BC001910_n637NefUpdUsuId = new bool[] {false} ;
         BC001910_A638NefUpdUsuNome = new string[] {""} ;
         BC001910_n638NefUpdUsuNome = new bool[] {false} ;
         BC001910_A627NefConfirmado = new bool[] {false} ;
         BC001910_A628NefTexto = new string[] {""} ;
         BC001910_n628NefTexto = new bool[] {false} ;
         BC001910_A639NefValor = new short[1] ;
         BC001910_n639NefValor = new bool[] {false} ;
         BC001910_A345NegID = new Guid[] {Guid.Empty} ;
         BC00193_n626NefChave = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         BC001911_A345NegID = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjfluxo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjfluxo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00192_A626NefChave, BC00192_A629NefInsDataHora, BC00192_A630NefInsData, BC00192_A631NefInsHora, BC00192_A632NefInsUsuId, BC00192_A633NefInsUsuNome, BC00192_A634NefUpdDataHora, BC00192_n634NefUpdDataHora, BC00192_A635NefUpdData, BC00192_n635NefUpdData,
               BC00192_A636NefUpdHora, BC00192_n636NefUpdHora, BC00192_A637NefUpdUsuId, BC00192_n637NefUpdUsuId, BC00192_A638NefUpdUsuNome, BC00192_n638NefUpdUsuNome, BC00192_A627NefConfirmado, BC00192_A628NefTexto, BC00192_n628NefTexto, BC00192_A639NefValor,
               BC00192_n639NefValor, BC00192_A345NegID
               }
               , new Object[] {
               BC00193_A626NefChave, BC00193_A629NefInsDataHora, BC00193_A630NefInsData, BC00193_A631NefInsHora, BC00193_A632NefInsUsuId, BC00193_A633NefInsUsuNome, BC00193_A634NefUpdDataHora, BC00193_n634NefUpdDataHora, BC00193_A635NefUpdData, BC00193_n635NefUpdData,
               BC00193_A636NefUpdHora, BC00193_n636NefUpdHora, BC00193_A637NefUpdUsuId, BC00193_n637NefUpdUsuId, BC00193_A638NefUpdUsuNome, BC00193_n638NefUpdUsuNome, BC00193_A627NefConfirmado, BC00193_A628NefTexto, BC00193_n628NefTexto, BC00193_A639NefValor,
               BC00193_n639NefValor, BC00193_A345NegID
               }
               , new Object[] {
               BC00194_A345NegID
               }
               , new Object[] {
               BC00195_A626NefChave, BC00195_A629NefInsDataHora, BC00195_A630NefInsData, BC00195_A631NefInsHora, BC00195_A632NefInsUsuId, BC00195_A633NefInsUsuNome, BC00195_A634NefUpdDataHora, BC00195_n634NefUpdDataHora, BC00195_A635NefUpdData, BC00195_n635NefUpdData,
               BC00195_A636NefUpdHora, BC00195_n636NefUpdHora, BC00195_A637NefUpdUsuId, BC00195_n637NefUpdUsuId, BC00195_A638NefUpdUsuNome, BC00195_n638NefUpdUsuNome, BC00195_A627NefConfirmado, BC00195_A628NefTexto, BC00195_n628NefTexto, BC00195_A639NefValor,
               BC00195_n639NefValor, BC00195_A345NegID
               }
               , new Object[] {
               BC00196_A345NegID, BC00196_A626NefChave
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001910_A626NefChave, BC001910_A629NefInsDataHora, BC001910_A630NefInsData, BC001910_A631NefInsHora, BC001910_A632NefInsUsuId, BC001910_A633NefInsUsuNome, BC001910_A634NefUpdDataHora, BC001910_n634NefUpdDataHora, BC001910_A635NefUpdData, BC001910_n635NefUpdData,
               BC001910_A636NefUpdHora, BC001910_n636NefUpdHora, BC001910_A637NefUpdUsuId, BC001910_n637NefUpdUsuId, BC001910_A638NefUpdUsuNome, BC001910_n638NefUpdUsuNome, BC001910_A627NefConfirmado, BC001910_A628NefTexto, BC001910_n628NefTexto, BC001910_A639NefValor,
               BC001910_n639NefValor, BC001910_A345NegID
               }
               , new Object[] {
               BC001911_A345NegID
               }
            }
         );
         AV23Pgmname = "core.NegocioPJFluxo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12192 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Z639NefValor ;
      private short A639NefValor ;
      private short RcdFound44 ;
      private short nIsDirty_44 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV23Pgmname ;
      private string Z632NefInsUsuId ;
      private string A632NefInsUsuId ;
      private string Z637NefUpdUsuId ;
      private string A637NefUpdUsuId ;
      private string sMode44 ;
      private DateTime Z629NefInsDataHora ;
      private DateTime A629NefInsDataHora ;
      private DateTime Z630NefInsData ;
      private DateTime A630NefInsData ;
      private DateTime Z631NefInsHora ;
      private DateTime A631NefInsHora ;
      private DateTime Z634NefUpdDataHora ;
      private DateTime A634NefUpdDataHora ;
      private DateTime Z635NefUpdData ;
      private DateTime A635NefUpdData ;
      private DateTime Z636NefUpdHora ;
      private DateTime A636NefUpdHora ;
      private bool returnInSub ;
      private bool Z627NefConfirmado ;
      private bool A627NefConfirmado ;
      private bool n634NefUpdDataHora ;
      private bool n635NefUpdData ;
      private bool n636NefUpdHora ;
      private bool n637NefUpdUsuId ;
      private bool n638NefUpdUsuNome ;
      private bool n628NefTexto ;
      private bool n639NefValor ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z626NefChave ;
      private string A626NefChave ;
      private string Z633NefInsUsuNome ;
      private string A633NefInsUsuNome ;
      private string Z638NefUpdUsuNome ;
      private string A638NefUpdUsuNome ;
      private string Z628NefTexto ;
      private string A628NefTexto ;
      private Guid Z345NegID ;
      private Guid A345NegID ;
      private IGxSession AV14WebSession ;
      private GeneXus.Programs.core.SdtNegocioPJFluxo bccore_NegocioPJFluxo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] BC00195_A626NefChave ;
      private DateTime[] BC00195_A629NefInsDataHora ;
      private DateTime[] BC00195_A630NefInsData ;
      private DateTime[] BC00195_A631NefInsHora ;
      private string[] BC00195_A632NefInsUsuId ;
      private string[] BC00195_A633NefInsUsuNome ;
      private DateTime[] BC00195_A634NefUpdDataHora ;
      private bool[] BC00195_n634NefUpdDataHora ;
      private DateTime[] BC00195_A635NefUpdData ;
      private bool[] BC00195_n635NefUpdData ;
      private DateTime[] BC00195_A636NefUpdHora ;
      private bool[] BC00195_n636NefUpdHora ;
      private string[] BC00195_A637NefUpdUsuId ;
      private bool[] BC00195_n637NefUpdUsuId ;
      private string[] BC00195_A638NefUpdUsuNome ;
      private bool[] BC00195_n638NefUpdUsuNome ;
      private bool[] BC00195_A627NefConfirmado ;
      private string[] BC00195_A628NefTexto ;
      private bool[] BC00195_n628NefTexto ;
      private short[] BC00195_A639NefValor ;
      private bool[] BC00195_n639NefValor ;
      private Guid[] BC00195_A345NegID ;
      private Guid[] BC00194_A345NegID ;
      private Guid[] BC00196_A345NegID ;
      private string[] BC00196_A626NefChave ;
      private string[] BC00193_A626NefChave ;
      private DateTime[] BC00193_A629NefInsDataHora ;
      private DateTime[] BC00193_A630NefInsData ;
      private DateTime[] BC00193_A631NefInsHora ;
      private string[] BC00193_A632NefInsUsuId ;
      private string[] BC00193_A633NefInsUsuNome ;
      private DateTime[] BC00193_A634NefUpdDataHora ;
      private bool[] BC00193_n634NefUpdDataHora ;
      private DateTime[] BC00193_A635NefUpdData ;
      private bool[] BC00193_n635NefUpdData ;
      private DateTime[] BC00193_A636NefUpdHora ;
      private bool[] BC00193_n636NefUpdHora ;
      private string[] BC00193_A637NefUpdUsuId ;
      private bool[] BC00193_n637NefUpdUsuId ;
      private string[] BC00193_A638NefUpdUsuNome ;
      private bool[] BC00193_n638NefUpdUsuNome ;
      private bool[] BC00193_A627NefConfirmado ;
      private string[] BC00193_A628NefTexto ;
      private bool[] BC00193_n628NefTexto ;
      private short[] BC00193_A639NefValor ;
      private bool[] BC00193_n639NefValor ;
      private Guid[] BC00193_A345NegID ;
      private string[] BC00192_A626NefChave ;
      private DateTime[] BC00192_A629NefInsDataHora ;
      private DateTime[] BC00192_A630NefInsData ;
      private DateTime[] BC00192_A631NefInsHora ;
      private string[] BC00192_A632NefInsUsuId ;
      private string[] BC00192_A633NefInsUsuNome ;
      private DateTime[] BC00192_A634NefUpdDataHora ;
      private bool[] BC00192_n634NefUpdDataHora ;
      private DateTime[] BC00192_A635NefUpdData ;
      private bool[] BC00192_n635NefUpdData ;
      private DateTime[] BC00192_A636NefUpdHora ;
      private bool[] BC00192_n636NefUpdHora ;
      private string[] BC00192_A637NefUpdUsuId ;
      private bool[] BC00192_n637NefUpdUsuId ;
      private string[] BC00192_A638NefUpdUsuNome ;
      private bool[] BC00192_n638NefUpdUsuNome ;
      private bool[] BC00192_A627NefConfirmado ;
      private string[] BC00192_A628NefTexto ;
      private bool[] BC00192_n628NefTexto ;
      private short[] BC00192_A639NefValor ;
      private bool[] BC00192_n639NefValor ;
      private Guid[] BC00192_A345NegID ;
      private string[] BC001910_A626NefChave ;
      private DateTime[] BC001910_A629NefInsDataHora ;
      private DateTime[] BC001910_A630NefInsData ;
      private DateTime[] BC001910_A631NefInsHora ;
      private string[] BC001910_A632NefInsUsuId ;
      private string[] BC001910_A633NefInsUsuNome ;
      private DateTime[] BC001910_A634NefUpdDataHora ;
      private bool[] BC001910_n634NefUpdDataHora ;
      private DateTime[] BC001910_A635NefUpdData ;
      private bool[] BC001910_n635NefUpdData ;
      private DateTime[] BC001910_A636NefUpdHora ;
      private bool[] BC001910_n636NefUpdHora ;
      private string[] BC001910_A637NefUpdUsuId ;
      private bool[] BC001910_n637NefUpdUsuId ;
      private string[] BC001910_A638NefUpdUsuNome ;
      private bool[] BC001910_n638NefUpdUsuNome ;
      private bool[] BC001910_A627NefConfirmado ;
      private string[] BC001910_A628NefTexto ;
      private bool[] BC001910_n628NefTexto ;
      private short[] BC001910_A639NefValor ;
      private bool[] BC001910_n639NefValor ;
      private Guid[] BC001910_A345NegID ;
      private bool[] BC00193_n626NefChave ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private Guid[] BC001911_A345NegID ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
   }

   public class negociopjfluxo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class negociopjfluxo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00195;
        prmBC00195 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC00194;
        prmBC00194 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00196;
        prmBC00196 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC00193;
        prmBC00193 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC00192;
        prmBC00192 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC00197;
        prmBC00197 = new Object[] {
        new ParDef("NefChave",GXType.VarChar,100,0) ,
        new ParDef("NefInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NefInsData",GXType.DateTime,10,5) ,
        new ParDef("NefInsHora",GXType.DateTime,0,5) ,
        new ParDef("NefInsUsuId",GXType.Char,40,0) ,
        new ParDef("NefInsUsuNome",GXType.VarChar,80,0) ,
        new ParDef("NefUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NefUpdData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NefUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NefUpdUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NefUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NefConfirmado",GXType.Boolean,4,0) ,
        new ParDef("NefTexto",GXType.VarChar,250,0){Nullable=true} ,
        new ParDef("NefValor",GXType.Int16,3,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00198;
        prmBC00198 = new Object[] {
        new ParDef("NefInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NefInsData",GXType.DateTime,10,5) ,
        new ParDef("NefInsHora",GXType.DateTime,0,5) ,
        new ParDef("NefInsUsuId",GXType.Char,40,0) ,
        new ParDef("NefInsUsuNome",GXType.VarChar,80,0) ,
        new ParDef("NefUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NefUpdData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NefUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NefUpdUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NefUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NefConfirmado",GXType.Boolean,4,0) ,
        new ParDef("NefTexto",GXType.VarChar,250,0){Nullable=true} ,
        new ParDef("NefValor",GXType.Int16,3,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC00199;
        prmBC00199 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC001910;
        prmBC001910 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmBC001911;
        prmBC001911 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00192", "SELECT NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave  FOR UPDATE OF tb_negociopj_fluxo",true, GxErrorMask.GX_NOMASK, false, this,prmBC00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00193", "SELECT NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00194", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00195", "SELECT TM1.NefChave, TM1.NefInsDataHora, TM1.NefInsData, TM1.NefInsHora, TM1.NefInsUsuId, TM1.NefInsUsuNome, TM1.NefUpdDataHora, TM1.NefUpdData, TM1.NefUpdHora, TM1.NefUpdUsuId, TM1.NefUpdUsuNome, TM1.NefConfirmado, TM1.NefTexto, TM1.NefValor, TM1.NegID FROM tb_negociopj_fluxo TM1 WHERE TM1.NegID = :NegID and TM1.NefChave = ( :NefChave) ORDER BY TM1.NegID, TM1.NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00195,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00196", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00196,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00197", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_fluxo(NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID) VALUES(:NefChave, :NefInsDataHora, :NefInsData, :NefInsHora, :NefInsUsuId, :NefInsUsuNome, :NefUpdDataHora, :NefUpdData, :NefUpdHora, :NefUpdUsuId, :NefUpdUsuNome, :NefConfirmado, :NefTexto, :NefValor, :NegID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00197)
           ,new CursorDef("BC00198", "SAVEPOINT gxupdate;UPDATE tb_negociopj_fluxo SET NefInsDataHora=:NefInsDataHora, NefInsData=:NefInsData, NefInsHora=:NefInsHora, NefInsUsuId=:NefInsUsuId, NefInsUsuNome=:NefInsUsuNome, NefUpdDataHora=:NefUpdDataHora, NefUpdData=:NefUpdData, NefUpdHora=:NefUpdHora, NefUpdUsuId=:NefUpdUsuId, NefUpdUsuNome=:NefUpdUsuNome, NefConfirmado=:NefConfirmado, NefTexto=:NefTexto, NefValor=:NefValor  WHERE NegID = :NegID AND NefChave = :NefChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00198)
           ,new CursorDef("BC00199", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_fluxo  WHERE NegID = :NegID AND NefChave = :NefChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00199)
           ,new CursorDef("BC001910", "SELECT TM1.NefChave, TM1.NefInsDataHora, TM1.NefInsData, TM1.NefInsHora, TM1.NefInsUsuId, TM1.NefInsUsuNome, TM1.NefUpdDataHora, TM1.NefUpdData, TM1.NefUpdHora, TM1.NefUpdUsuId, TM1.NefUpdUsuNome, TM1.NefConfirmado, TM1.NefTexto, TM1.NefValor, TM1.NegID FROM tb_negociopj_fluxo TM1 WHERE TM1.NegID = :NegID and TM1.NefChave = ( :NefChave) ORDER BY TM1.NegID, TM1.NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001910,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001911", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001911,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
