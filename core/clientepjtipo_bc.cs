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
   public class clientepjtipo_bc : GxSilentTrn, IGxSilentTrn
   {
      public clientepjtipo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjtipo_bc( IGxContext context )
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
         ReadRow0N23( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey0N23( ) ;
         standaloneModal( ) ;
         AddRow0N23( ) ;
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
            E110N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z155PjtID = A155PjtID;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N23( ) ;
            }
            else
            {
               CheckExtendedTable0N23( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors0N23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E120N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E110N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
      }

      protected void ZM0N23( short GX_JID )
      {
         if ( ( GX_JID == 14 ) || ( GX_JID == 0 ) )
         {
            Z531PjtDelDataHora = A531PjtDelDataHora;
            Z532PjtDelData = A532PjtDelData;
            Z533PjtDelHora = A533PjtDelHora;
            Z534PjtDelUsuId = A534PjtDelUsuId;
            Z535PjtDelUsuNome = A535PjtDelUsuNome;
            Z156PjtSigla = A156PjtSigla;
            Z157PjtNome = A157PjtNome;
            Z217PjtAtivo = A217PjtAtivo;
            Z530PjtDel = A530PjtDel;
         }
         if ( GX_JID == -14 )
         {
            Z155PjtID = A155PjtID;
            Z531PjtDelDataHora = A531PjtDelDataHora;
            Z532PjtDelData = A532PjtDelData;
            Z533PjtDelHora = A533PjtDelHora;
            Z534PjtDelUsuId = A534PjtDelUsuId;
            Z535PjtDelUsuNome = A535PjtDelUsuNome;
            Z156PjtSigla = A156PjtSigla;
            Z157PjtNome = A157PjtNome;
            Z217PjtAtivo = A217PjtAtivo;
            Z530PjtDel = A530PjtDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV15Pgmname = "core.ClientePJTipo_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A217PjtAtivo) && ( Gx_BScreen == 0 ) )
         {
            A217PjtAtivo = true;
         }
      }

      protected void Load0N23( )
      {
         /* Using cursor BC000N4 */
         pr_default.execute(2, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A531PjtDelDataHora = BC000N4_A531PjtDelDataHora[0];
            n531PjtDelDataHora = BC000N4_n531PjtDelDataHora[0];
            A532PjtDelData = BC000N4_A532PjtDelData[0];
            n532PjtDelData = BC000N4_n532PjtDelData[0];
            A533PjtDelHora = BC000N4_A533PjtDelHora[0];
            n533PjtDelHora = BC000N4_n533PjtDelHora[0];
            A534PjtDelUsuId = BC000N4_A534PjtDelUsuId[0];
            n534PjtDelUsuId = BC000N4_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = BC000N4_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = BC000N4_n535PjtDelUsuNome[0];
            A156PjtSigla = BC000N4_A156PjtSigla[0];
            A157PjtNome = BC000N4_A157PjtNome[0];
            A217PjtAtivo = BC000N4_A217PjtAtivo[0];
            A530PjtDel = BC000N4_A530PjtDel[0];
            ZM0N23( -14) ;
         }
         pr_default.close(2);
         OnLoadActions0N23( ) ;
      }

      protected void OnLoadActions0N23( )
      {
      }

      protected void CheckExtendedTable0N23( )
      {
         nIsDirty_23 = 0;
         standaloneModal( ) ;
         /* Using cursor BC000N5 */
         pr_default.execute(3, new Object[] {A156PjtSigla, A155PjtID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
         if ( (0==A155PjtID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A156PjtSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A157PjtNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors0N23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N23( )
      {
         /* Using cursor BC000N6 */
         pr_default.execute(4, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC000N3 */
         pr_default.execute(1, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N23( 14) ;
            RcdFound23 = 1;
            A155PjtID = BC000N3_A155PjtID[0];
            A531PjtDelDataHora = BC000N3_A531PjtDelDataHora[0];
            n531PjtDelDataHora = BC000N3_n531PjtDelDataHora[0];
            A532PjtDelData = BC000N3_A532PjtDelData[0];
            n532PjtDelData = BC000N3_n532PjtDelData[0];
            A533PjtDelHora = BC000N3_A533PjtDelHora[0];
            n533PjtDelHora = BC000N3_n533PjtDelHora[0];
            A534PjtDelUsuId = BC000N3_A534PjtDelUsuId[0];
            n534PjtDelUsuId = BC000N3_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = BC000N3_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = BC000N3_n535PjtDelUsuNome[0];
            A156PjtSigla = BC000N3_A156PjtSigla[0];
            A157PjtNome = BC000N3_A157PjtNome[0];
            A217PjtAtivo = BC000N3_A217PjtAtivo[0];
            A530PjtDel = BC000N3_A530PjtDel[0];
            O530PjtDel = A530PjtDel;
            Z155PjtID = A155PjtID;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load0N23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0N23( ) ;
            }
            Gx_mode = sMode23;
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0N23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode23;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N23( ) ;
         if ( RcdFound23 == 0 )
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
         CONFIRM_0N0( ) ;
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

      protected void CheckOptimisticConcurrency0N23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC000N2 */
            pr_default.execute(0, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepjtipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z531PjtDelDataHora != BC000N2_A531PjtDelDataHora[0] ) || ( Z532PjtDelData != BC000N2_A532PjtDelData[0] ) || ( Z533PjtDelHora != BC000N2_A533PjtDelHora[0] ) || ( StringUtil.StrCmp(Z534PjtDelUsuId, BC000N2_A534PjtDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z535PjtDelUsuNome, BC000N2_A535PjtDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z156PjtSigla, BC000N2_A156PjtSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z157PjtNome, BC000N2_A157PjtNome[0]) != 0 ) || ( Z217PjtAtivo != BC000N2_A217PjtAtivo[0] ) || ( Z530PjtDel != BC000N2_A530PjtDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepjtipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N23( 0) ;
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N7 */
                     pr_default.execute(5, new Object[] {A155PjtID, n531PjtDelDataHora, A531PjtDelDataHora, n532PjtDelData, A532PjtDelData, n533PjtDelHora, A533PjtDelHora, n534PjtDelUsuId, A534PjtDelUsuId, n535PjtDelUsuNome, A535PjtDelUsuNome, A156PjtSigla, A157PjtNome, A217PjtAtivo, A530PjtDel});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
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
               Load0N23( ) ;
            }
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void Update0N23( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC000N8 */
                     pr_default.execute(6, new Object[] {n531PjtDelDataHora, A531PjtDelDataHora, n532PjtDelData, A532PjtDelData, n533PjtDelHora, A533PjtDelHora, n534PjtDelUsuId, A534PjtDelUsuId, n535PjtDelUsuNome, A535PjtDelUsuNome, A156PjtSigla, A157PjtNome, A217PjtAtivo, A530PjtDel, A155PjtID});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
                     if ( (pr_default.getStatus(6) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepjtipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N23( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_clientepjtipoupdateredundancy(context ).execute( ref  A155PjtID) ;
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
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void DeferredUpdate0N23( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N23( ) ;
            AfterConfirm0N23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC000N9 */
                  pr_default.execute(7, new Object[] {A155PjtID});
                  pr_default.close(7);
                  pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel0N23( ) ;
         Gx_mode = sMode23;
      }

      protected void OnDeleteControls0N23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC000N10 */
            pr_default.execute(8, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(8) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(8);
            /* Using cursor BC000N11 */
            pr_default.execute(9, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel0N23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N23( ) ;
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

      public void ScanKeyStart0N23( )
      {
         /* Scan By routine */
         /* Using cursor BC000N12 */
         pr_default.execute(10, new Object[] {A155PjtID});
         RcdFound23 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound23 = 1;
            A155PjtID = BC000N12_A155PjtID[0];
            A531PjtDelDataHora = BC000N12_A531PjtDelDataHora[0];
            n531PjtDelDataHora = BC000N12_n531PjtDelDataHora[0];
            A532PjtDelData = BC000N12_A532PjtDelData[0];
            n532PjtDelData = BC000N12_n532PjtDelData[0];
            A533PjtDelHora = BC000N12_A533PjtDelHora[0];
            n533PjtDelHora = BC000N12_n533PjtDelHora[0];
            A534PjtDelUsuId = BC000N12_A534PjtDelUsuId[0];
            n534PjtDelUsuId = BC000N12_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = BC000N12_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = BC000N12_n535PjtDelUsuNome[0];
            A156PjtSigla = BC000N12_A156PjtSigla[0];
            A157PjtNome = BC000N12_A157PjtNome[0];
            A217PjtAtivo = BC000N12_A217PjtAtivo[0];
            A530PjtDel = BC000N12_A530PjtDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext0N23( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound23 = 0;
         ScanKeyLoad0N23( ) ;
      }

      protected void ScanKeyLoad0N23( )
      {
         sMode23 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound23 = 1;
            A155PjtID = BC000N12_A155PjtID[0];
            A531PjtDelDataHora = BC000N12_A531PjtDelDataHora[0];
            n531PjtDelDataHora = BC000N12_n531PjtDelDataHora[0];
            A532PjtDelData = BC000N12_A532PjtDelData[0];
            n532PjtDelData = BC000N12_n532PjtDelData[0];
            A533PjtDelHora = BC000N12_A533PjtDelHora[0];
            n533PjtDelHora = BC000N12_n533PjtDelHora[0];
            A534PjtDelUsuId = BC000N12_A534PjtDelUsuId[0];
            n534PjtDelUsuId = BC000N12_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = BC000N12_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = BC000N12_n535PjtDelUsuNome[0];
            A156PjtSigla = BC000N12_A156PjtSigla[0];
            A157PjtNome = BC000N12_A157PjtNome[0];
            A217PjtAtivo = BC000N12_A217PjtAtivo[0];
            A530PjtDel = BC000N12_A530PjtDel[0];
         }
         Gx_mode = sMode23;
      }

      protected void ScanKeyEnd0N23( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm0N23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N23( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A531PjtDelDataHora = DateTimeUtil.NowMS( context);
            n531PjtDelDataHora = false;
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A534PjtDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n534PjtDelUsuId = false;
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A535PjtDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n535PjtDelUsuNome = false;
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A532PjtDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A531PjtDelDataHora) ) ;
            n532PjtDelData = false;
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A533PjtDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A531PjtDelDataHora));
            n533PjtDelHora = false;
         }
      }

      protected void BeforeDelete0N23( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
      }

      protected void BeforeComplete0N23( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0N23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N23( )
      {
      }

      protected void send_integrity_lvl_hashes0N23( )
      {
      }

      protected void AddRow0N23( )
      {
         VarsToRow23( bccore_ClientePJTipo) ;
      }

      protected void ReadRow0N23( )
      {
         RowToVars23( bccore_ClientePJTipo, 1) ;
      }

      protected void InitializeNonKey0N23( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         n531PjtDelDataHora = false;
         A532PjtDelData = (DateTime)(DateTime.MinValue);
         n532PjtDelData = false;
         A533PjtDelHora = (DateTime)(DateTime.MinValue);
         n533PjtDelHora = false;
         A534PjtDelUsuId = "";
         n534PjtDelUsuId = false;
         A535PjtDelUsuNome = "";
         n535PjtDelUsuNome = false;
         A156PjtSigla = "";
         A157PjtNome = "";
         A530PjtDel = false;
         A217PjtAtivo = true;
         O530PjtDel = A530PjtDel;
         Z531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         Z532PjtDelData = (DateTime)(DateTime.MinValue);
         Z533PjtDelHora = (DateTime)(DateTime.MinValue);
         Z534PjtDelUsuId = "";
         Z535PjtDelUsuNome = "";
         Z156PjtSigla = "";
         Z157PjtNome = "";
         Z217PjtAtivo = false;
         Z530PjtDel = false;
      }

      protected void InitAll0N23( )
      {
         A155PjtID = 0;
         InitializeNonKey0N23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A217PjtAtivo = i217PjtAtivo;
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

      public void VarsToRow23( GeneXus.Programs.core.SdtClientePJTipo obj23 )
      {
         obj23.gxTpr_Mode = Gx_mode;
         obj23.gxTpr_Pjtdeldatahora = A531PjtDelDataHora;
         obj23.gxTpr_Pjtdeldata = A532PjtDelData;
         obj23.gxTpr_Pjtdelhora = A533PjtDelHora;
         obj23.gxTpr_Pjtdelusuid = A534PjtDelUsuId;
         obj23.gxTpr_Pjtdelusunome = A535PjtDelUsuNome;
         obj23.gxTpr_Pjtsigla = A156PjtSigla;
         obj23.gxTpr_Pjtnome = A157PjtNome;
         obj23.gxTpr_Pjtdel = A530PjtDel;
         obj23.gxTpr_Pjtativo = A217PjtAtivo;
         obj23.gxTpr_Pjtid = A155PjtID;
         obj23.gxTpr_Pjtid_Z = Z155PjtID;
         obj23.gxTpr_Pjtsigla_Z = Z156PjtSigla;
         obj23.gxTpr_Pjtnome_Z = Z157PjtNome;
         obj23.gxTpr_Pjtativo_Z = Z217PjtAtivo;
         obj23.gxTpr_Pjtdel_Z = Z530PjtDel;
         obj23.gxTpr_Pjtdeldatahora_Z = Z531PjtDelDataHora;
         obj23.gxTpr_Pjtdeldata_Z = Z532PjtDelData;
         obj23.gxTpr_Pjtdelhora_Z = Z533PjtDelHora;
         obj23.gxTpr_Pjtdelusuid_Z = Z534PjtDelUsuId;
         obj23.gxTpr_Pjtdelusunome_Z = Z535PjtDelUsuNome;
         obj23.gxTpr_Pjtdeldatahora_N = (short)(Convert.ToInt16(n531PjtDelDataHora));
         obj23.gxTpr_Pjtdeldata_N = (short)(Convert.ToInt16(n532PjtDelData));
         obj23.gxTpr_Pjtdelhora_N = (short)(Convert.ToInt16(n533PjtDelHora));
         obj23.gxTpr_Pjtdelusuid_N = (short)(Convert.ToInt16(n534PjtDelUsuId));
         obj23.gxTpr_Pjtdelusunome_N = (short)(Convert.ToInt16(n535PjtDelUsuNome));
         obj23.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow23( GeneXus.Programs.core.SdtClientePJTipo obj23 )
      {
         obj23.gxTpr_Pjtid = A155PjtID;
         return  ;
      }

      public void RowToVars23( GeneXus.Programs.core.SdtClientePJTipo obj23 ,
                               int forceLoad )
      {
         Gx_mode = obj23.gxTpr_Mode;
         A531PjtDelDataHora = obj23.gxTpr_Pjtdeldatahora;
         n531PjtDelDataHora = false;
         A532PjtDelData = obj23.gxTpr_Pjtdeldata;
         n532PjtDelData = false;
         A533PjtDelHora = obj23.gxTpr_Pjtdelhora;
         n533PjtDelHora = false;
         A534PjtDelUsuId = obj23.gxTpr_Pjtdelusuid;
         n534PjtDelUsuId = false;
         A535PjtDelUsuNome = obj23.gxTpr_Pjtdelusunome;
         n535PjtDelUsuNome = false;
         A156PjtSigla = obj23.gxTpr_Pjtsigla;
         A157PjtNome = obj23.gxTpr_Pjtnome;
         A530PjtDel = obj23.gxTpr_Pjtdel;
         A217PjtAtivo = obj23.gxTpr_Pjtativo;
         A155PjtID = obj23.gxTpr_Pjtid;
         Z155PjtID = obj23.gxTpr_Pjtid_Z;
         Z156PjtSigla = obj23.gxTpr_Pjtsigla_Z;
         Z157PjtNome = obj23.gxTpr_Pjtnome_Z;
         Z217PjtAtivo = obj23.gxTpr_Pjtativo_Z;
         Z530PjtDel = obj23.gxTpr_Pjtdel_Z;
         O530PjtDel = obj23.gxTpr_Pjtdel_Z;
         Z531PjtDelDataHora = obj23.gxTpr_Pjtdeldatahora_Z;
         Z532PjtDelData = obj23.gxTpr_Pjtdeldata_Z;
         Z533PjtDelHora = obj23.gxTpr_Pjtdelhora_Z;
         Z534PjtDelUsuId = obj23.gxTpr_Pjtdelusuid_Z;
         Z535PjtDelUsuNome = obj23.gxTpr_Pjtdelusunome_Z;
         n531PjtDelDataHora = (bool)(Convert.ToBoolean(obj23.gxTpr_Pjtdeldatahora_N));
         n532PjtDelData = (bool)(Convert.ToBoolean(obj23.gxTpr_Pjtdeldata_N));
         n533PjtDelHora = (bool)(Convert.ToBoolean(obj23.gxTpr_Pjtdelhora_N));
         n534PjtDelUsuId = (bool)(Convert.ToBoolean(obj23.gxTpr_Pjtdelusuid_N));
         n535PjtDelUsuNome = (bool)(Convert.ToBoolean(obj23.gxTpr_Pjtdelusunome_N));
         Gx_mode = obj23.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A155PjtID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey0N23( ) ;
         ScanKeyStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z155PjtID = A155PjtID;
            O530PjtDel = A530PjtDel;
         }
         ZM0N23( -14) ;
         OnLoadActions0N23( ) ;
         AddRow0N23( ) ;
         ScanKeyEnd0N23( ) ;
         if ( RcdFound23 == 0 )
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
         RowToVars23( bccore_ClientePJTipo, 0) ;
         ScanKeyStart0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z155PjtID = A155PjtID;
            O530PjtDel = A530PjtDel;
         }
         ZM0N23( -14) ;
         OnLoadActions0N23( ) ;
         AddRow0N23( ) ;
         ScanKeyEnd0N23( ) ;
         if ( RcdFound23 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey0N23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert0N23( ) ;
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A155PjtID != Z155PjtID )
               {
                  A155PjtID = Z155PjtID;
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
                  Update0N23( ) ;
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
                  if ( A155PjtID != Z155PjtID )
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
                        Insert0N23( ) ;
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
                        Insert0N23( ) ;
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
         RowToVars23( bccore_ClientePJTipo, 1) ;
         SaveImpl( ) ;
         VarsToRow23( bccore_ClientePJTipo) ;
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
         RowToVars23( bccore_ClientePJTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N23( ) ;
         AfterTrn( ) ;
         VarsToRow23( bccore_ClientePJTipo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow23( bccore_ClientePJTipo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtClientePJTipo auxBC = new GeneXus.Programs.core.SdtClientePJTipo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A155PjtID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_ClientePJTipo);
               auxBC.Save();
               bccore_ClientePJTipo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars23( bccore_ClientePJTipo, 1) ;
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
         RowToVars23( bccore_ClientePJTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert0N23( ) ;
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
               VarsToRow23( bccore_ClientePJTipo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow23( bccore_ClientePJTipo) ;
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
         RowToVars23( bccore_ClientePJTipo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey0N23( ) ;
         if ( RcdFound23 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A155PjtID != Z155PjtID )
            {
               A155PjtID = Z155PjtID;
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
            if ( A155PjtID != Z155PjtID )
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
         context.RollbackDataStores("core.clientepjtipo_bc",pr_default);
         VarsToRow23( bccore_ClientePJTipo) ;
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
         Gx_mode = bccore_ClientePJTipo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_ClientePJTipo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_ClientePJTipo )
         {
            bccore_ClientePJTipo = (GeneXus.Programs.core.SdtClientePJTipo)(sdt);
            if ( StringUtil.StrCmp(bccore_ClientePJTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ClientePJTipo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow23( bccore_ClientePJTipo) ;
            }
            else
            {
               RowToVars23( bccore_ClientePJTipo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_ClientePJTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_ClientePJTipo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars23( bccore_ClientePJTipo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtClientePJTipo ClientePJTipo_BC
      {
         get {
            return bccore_ClientePJTipo ;
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
            return "clientepjtipo_Execute" ;
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
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV15Pgmname = "";
         Z531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         A531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         Z532PjtDelData = (DateTime)(DateTime.MinValue);
         A532PjtDelData = (DateTime)(DateTime.MinValue);
         Z533PjtDelHora = (DateTime)(DateTime.MinValue);
         A533PjtDelHora = (DateTime)(DateTime.MinValue);
         Z534PjtDelUsuId = "";
         A534PjtDelUsuId = "";
         Z535PjtDelUsuNome = "";
         A535PjtDelUsuNome = "";
         Z156PjtSigla = "";
         A156PjtSigla = "";
         Z157PjtNome = "";
         A157PjtNome = "";
         BC000N4_A155PjtID = new int[1] ;
         BC000N4_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N4_n531PjtDelDataHora = new bool[] {false} ;
         BC000N4_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000N4_n532PjtDelData = new bool[] {false} ;
         BC000N4_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000N4_n533PjtDelHora = new bool[] {false} ;
         BC000N4_A534PjtDelUsuId = new string[] {""} ;
         BC000N4_n534PjtDelUsuId = new bool[] {false} ;
         BC000N4_A535PjtDelUsuNome = new string[] {""} ;
         BC000N4_n535PjtDelUsuNome = new bool[] {false} ;
         BC000N4_A156PjtSigla = new string[] {""} ;
         BC000N4_A157PjtNome = new string[] {""} ;
         BC000N4_A217PjtAtivo = new bool[] {false} ;
         BC000N4_A530PjtDel = new bool[] {false} ;
         BC000N5_A156PjtSigla = new string[] {""} ;
         BC000N6_A155PjtID = new int[1] ;
         BC000N3_A155PjtID = new int[1] ;
         BC000N3_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N3_n531PjtDelDataHora = new bool[] {false} ;
         BC000N3_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000N3_n532PjtDelData = new bool[] {false} ;
         BC000N3_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000N3_n533PjtDelHora = new bool[] {false} ;
         BC000N3_A534PjtDelUsuId = new string[] {""} ;
         BC000N3_n534PjtDelUsuId = new bool[] {false} ;
         BC000N3_A535PjtDelUsuNome = new string[] {""} ;
         BC000N3_n535PjtDelUsuNome = new bool[] {false} ;
         BC000N3_A156PjtSigla = new string[] {""} ;
         BC000N3_A157PjtNome = new string[] {""} ;
         BC000N3_A217PjtAtivo = new bool[] {false} ;
         BC000N3_A530PjtDel = new bool[] {false} ;
         sMode23 = "";
         BC000N2_A155PjtID = new int[1] ;
         BC000N2_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N2_n531PjtDelDataHora = new bool[] {false} ;
         BC000N2_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000N2_n532PjtDelData = new bool[] {false} ;
         BC000N2_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000N2_n533PjtDelHora = new bool[] {false} ;
         BC000N2_A534PjtDelUsuId = new string[] {""} ;
         BC000N2_n534PjtDelUsuId = new bool[] {false} ;
         BC000N2_A535PjtDelUsuNome = new string[] {""} ;
         BC000N2_n535PjtDelUsuNome = new bool[] {false} ;
         BC000N2_A156PjtSigla = new string[] {""} ;
         BC000N2_A157PjtNome = new string[] {""} ;
         BC000N2_A217PjtAtivo = new bool[] {false} ;
         BC000N2_A530PjtDel = new bool[] {false} ;
         BC000N10_A158CliID = new Guid[] {Guid.Empty} ;
         BC000N10_A166CpjID = new Guid[] {Guid.Empty} ;
         BC000N11_A158CliID = new Guid[] {Guid.Empty} ;
         BC000N11_A166CpjID = new Guid[] {Guid.Empty} ;
         BC000N11_A269CpjConSeq = new short[1] ;
         BC000N12_A155PjtID = new int[1] ;
         BC000N12_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC000N12_n531PjtDelDataHora = new bool[] {false} ;
         BC000N12_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         BC000N12_n532PjtDelData = new bool[] {false} ;
         BC000N12_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         BC000N12_n533PjtDelHora = new bool[] {false} ;
         BC000N12_A534PjtDelUsuId = new string[] {""} ;
         BC000N12_n534PjtDelUsuId = new bool[] {false} ;
         BC000N12_A535PjtDelUsuNome = new string[] {""} ;
         BC000N12_n535PjtDelUsuNome = new bool[] {false} ;
         BC000N12_A156PjtSigla = new string[] {""} ;
         BC000N12_A157PjtNome = new string[] {""} ;
         BC000N12_A217PjtAtivo = new bool[] {false} ;
         BC000N12_A530PjtDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipo_bc__default(),
            new Object[][] {
                new Object[] {
               BC000N2_A155PjtID, BC000N2_A531PjtDelDataHora, BC000N2_n531PjtDelDataHora, BC000N2_A532PjtDelData, BC000N2_n532PjtDelData, BC000N2_A533PjtDelHora, BC000N2_n533PjtDelHora, BC000N2_A534PjtDelUsuId, BC000N2_n534PjtDelUsuId, BC000N2_A535PjtDelUsuNome,
               BC000N2_n535PjtDelUsuNome, BC000N2_A156PjtSigla, BC000N2_A157PjtNome, BC000N2_A217PjtAtivo, BC000N2_A530PjtDel
               }
               , new Object[] {
               BC000N3_A155PjtID, BC000N3_A531PjtDelDataHora, BC000N3_n531PjtDelDataHora, BC000N3_A532PjtDelData, BC000N3_n532PjtDelData, BC000N3_A533PjtDelHora, BC000N3_n533PjtDelHora, BC000N3_A534PjtDelUsuId, BC000N3_n534PjtDelUsuId, BC000N3_A535PjtDelUsuNome,
               BC000N3_n535PjtDelUsuNome, BC000N3_A156PjtSigla, BC000N3_A157PjtNome, BC000N3_A217PjtAtivo, BC000N3_A530PjtDel
               }
               , new Object[] {
               BC000N4_A155PjtID, BC000N4_A531PjtDelDataHora, BC000N4_n531PjtDelDataHora, BC000N4_A532PjtDelData, BC000N4_n532PjtDelData, BC000N4_A533PjtDelHora, BC000N4_n533PjtDelHora, BC000N4_A534PjtDelUsuId, BC000N4_n534PjtDelUsuId, BC000N4_A535PjtDelUsuNome,
               BC000N4_n535PjtDelUsuNome, BC000N4_A156PjtSigla, BC000N4_A157PjtNome, BC000N4_A217PjtAtivo, BC000N4_A530PjtDel
               }
               , new Object[] {
               BC000N5_A156PjtSigla
               }
               , new Object[] {
               BC000N6_A155PjtID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC000N10_A158CliID, BC000N10_A166CpjID
               }
               , new Object[] {
               BC000N11_A158CliID, BC000N11_A166CpjID, BC000N11_A269CpjConSeq
               }
               , new Object[] {
               BC000N12_A155PjtID, BC000N12_A531PjtDelDataHora, BC000N12_n531PjtDelDataHora, BC000N12_A532PjtDelData, BC000N12_n532PjtDelData, BC000N12_A533PjtDelHora, BC000N12_n533PjtDelHora, BC000N12_A534PjtDelUsuId, BC000N12_n534PjtDelUsuId, BC000N12_A535PjtDelUsuNome,
               BC000N12_n535PjtDelUsuNome, BC000N12_A156PjtSigla, BC000N12_A157PjtNome, BC000N12_A217PjtAtivo, BC000N12_A530PjtDel
               }
            }
         );
         Z217PjtAtivo = true;
         A217PjtAtivo = true;
         i217PjtAtivo = true;
         AV15Pgmname = "core.ClientePJTipo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E120N2 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound23 ;
      private short nIsDirty_23 ;
      private int trnEnded ;
      private int Z155PjtID ;
      private int A155PjtID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV15Pgmname ;
      private string Z534PjtDelUsuId ;
      private string A534PjtDelUsuId ;
      private string sMode23 ;
      private DateTime Z531PjtDelDataHora ;
      private DateTime A531PjtDelDataHora ;
      private DateTime Z532PjtDelData ;
      private DateTime A532PjtDelData ;
      private DateTime Z533PjtDelHora ;
      private DateTime A533PjtDelHora ;
      private bool returnInSub ;
      private bool Z217PjtAtivo ;
      private bool A217PjtAtivo ;
      private bool Z530PjtDel ;
      private bool A530PjtDel ;
      private bool n531PjtDelDataHora ;
      private bool n532PjtDelData ;
      private bool n533PjtDelHora ;
      private bool n534PjtDelUsuId ;
      private bool n535PjtDelUsuNome ;
      private bool O530PjtDel ;
      private bool Gx_longc ;
      private bool i217PjtAtivo ;
      private bool mustCommit ;
      private string Z535PjtDelUsuNome ;
      private string A535PjtDelUsuNome ;
      private string Z156PjtSigla ;
      private string A156PjtSigla ;
      private string Z157PjtNome ;
      private string A157PjtNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtClientePJTipo bccore_ClientePJTipo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC000N4_A155PjtID ;
      private DateTime[] BC000N4_A531PjtDelDataHora ;
      private bool[] BC000N4_n531PjtDelDataHora ;
      private DateTime[] BC000N4_A532PjtDelData ;
      private bool[] BC000N4_n532PjtDelData ;
      private DateTime[] BC000N4_A533PjtDelHora ;
      private bool[] BC000N4_n533PjtDelHora ;
      private string[] BC000N4_A534PjtDelUsuId ;
      private bool[] BC000N4_n534PjtDelUsuId ;
      private string[] BC000N4_A535PjtDelUsuNome ;
      private bool[] BC000N4_n535PjtDelUsuNome ;
      private string[] BC000N4_A156PjtSigla ;
      private string[] BC000N4_A157PjtNome ;
      private bool[] BC000N4_A217PjtAtivo ;
      private bool[] BC000N4_A530PjtDel ;
      private string[] BC000N5_A156PjtSigla ;
      private int[] BC000N6_A155PjtID ;
      private int[] BC000N3_A155PjtID ;
      private DateTime[] BC000N3_A531PjtDelDataHora ;
      private bool[] BC000N3_n531PjtDelDataHora ;
      private DateTime[] BC000N3_A532PjtDelData ;
      private bool[] BC000N3_n532PjtDelData ;
      private DateTime[] BC000N3_A533PjtDelHora ;
      private bool[] BC000N3_n533PjtDelHora ;
      private string[] BC000N3_A534PjtDelUsuId ;
      private bool[] BC000N3_n534PjtDelUsuId ;
      private string[] BC000N3_A535PjtDelUsuNome ;
      private bool[] BC000N3_n535PjtDelUsuNome ;
      private string[] BC000N3_A156PjtSigla ;
      private string[] BC000N3_A157PjtNome ;
      private bool[] BC000N3_A217PjtAtivo ;
      private bool[] BC000N3_A530PjtDel ;
      private int[] BC000N2_A155PjtID ;
      private DateTime[] BC000N2_A531PjtDelDataHora ;
      private bool[] BC000N2_n531PjtDelDataHora ;
      private DateTime[] BC000N2_A532PjtDelData ;
      private bool[] BC000N2_n532PjtDelData ;
      private DateTime[] BC000N2_A533PjtDelHora ;
      private bool[] BC000N2_n533PjtDelHora ;
      private string[] BC000N2_A534PjtDelUsuId ;
      private bool[] BC000N2_n534PjtDelUsuId ;
      private string[] BC000N2_A535PjtDelUsuNome ;
      private bool[] BC000N2_n535PjtDelUsuNome ;
      private string[] BC000N2_A156PjtSigla ;
      private string[] BC000N2_A157PjtNome ;
      private bool[] BC000N2_A217PjtAtivo ;
      private bool[] BC000N2_A530PjtDel ;
      private Guid[] BC000N10_A158CliID ;
      private Guid[] BC000N10_A166CpjID ;
      private Guid[] BC000N11_A158CliID ;
      private Guid[] BC000N11_A166CpjID ;
      private short[] BC000N11_A269CpjConSeq ;
      private int[] BC000N12_A155PjtID ;
      private DateTime[] BC000N12_A531PjtDelDataHora ;
      private bool[] BC000N12_n531PjtDelDataHora ;
      private DateTime[] BC000N12_A532PjtDelData ;
      private bool[] BC000N12_n532PjtDelData ;
      private DateTime[] BC000N12_A533PjtDelHora ;
      private bool[] BC000N12_n533PjtDelHora ;
      private string[] BC000N12_A534PjtDelUsuId ;
      private bool[] BC000N12_n534PjtDelUsuId ;
      private string[] BC000N12_A535PjtDelUsuNome ;
      private bool[] BC000N12_n535PjtDelUsuNome ;
      private string[] BC000N12_A156PjtSigla ;
      private string[] BC000N12_A157PjtNome ;
      private bool[] BC000N12_A217PjtAtivo ;
      private bool[] BC000N12_A530PjtDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class clientepjtipo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class clientepjtipo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC000N4;
        prmBC000N4 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N5;
        prmBC000N5 = new Object[] {
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N6;
        prmBC000N6 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N3;
        prmBC000N3 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N2;
        prmBC000N2 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N7;
        prmBC000N7 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0) ,
        new ParDef("PjtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PjtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PjtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PjtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PjtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtNome",GXType.VarChar,80,0) ,
        new ParDef("PjtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PjtDel",GXType.Boolean,4,0)
        };
        Object[] prmBC000N8;
        prmBC000N8 = new Object[] {
        new ParDef("PjtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PjtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PjtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PjtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PjtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtNome",GXType.VarChar,80,0) ,
        new ParDef("PjtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PjtDel",GXType.Boolean,4,0) ,
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N9;
        prmBC000N9 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N10;
        prmBC000N10 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N11;
        prmBC000N11 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmBC000N12;
        prmBC000N12 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC000N2", "SELECT PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel FROM tb_clientepjtipo WHERE PjtID = :PjtID  FOR UPDATE OF tb_clientepjtipo",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N3", "SELECT PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel FROM tb_clientepjtipo WHERE PjtID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N4", "SELECT TM1.PjtID, TM1.PjtDelDataHora, TM1.PjtDelData, TM1.PjtDelHora, TM1.PjtDelUsuId, TM1.PjtDelUsuNome, TM1.PjtSigla, TM1.PjtNome, TM1.PjtAtivo, TM1.PjtDel FROM tb_clientepjtipo TM1 WHERE TM1.PjtID = :PjtID ORDER BY TM1.PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N5", "SELECT PjtSigla FROM tb_clientepjtipo WHERE (PjtSigla = :PjtSigla) AND (Not ( PjtID = :PjtID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N6", "SELECT PjtID FROM tb_clientepjtipo WHERE PjtID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC000N7", "SAVEPOINT gxupdate;INSERT INTO tb_clientepjtipo(PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel) VALUES(:PjtID, :PjtDelDataHora, :PjtDelData, :PjtDelHora, :PjtDelUsuId, :PjtDelUsuNome, :PjtSigla, :PjtNome, :PjtAtivo, :PjtDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC000N7)
           ,new CursorDef("BC000N8", "SAVEPOINT gxupdate;UPDATE tb_clientepjtipo SET PjtDelDataHora=:PjtDelDataHora, PjtDelData=:PjtDelData, PjtDelHora=:PjtDelHora, PjtDelUsuId=:PjtDelUsuId, PjtDelUsuNome=:PjtDelUsuNome, PjtSigla=:PjtSigla, PjtNome=:PjtNome, PjtAtivo=:PjtAtivo, PjtDel=:PjtDel  WHERE PjtID = :PjtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N8)
           ,new CursorDef("BC000N9", "SAVEPOINT gxupdate;DELETE FROM tb_clientepjtipo  WHERE PjtID = :PjtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC000N9)
           ,new CursorDef("BC000N10", "SELECT CliID, CpjID FROM tb_clientepj WHERE CpjTipoId = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N11", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CpjConTipoID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC000N12", "SELECT TM1.PjtID, TM1.PjtDelDataHora, TM1.PjtDelData, TM1.PjtDelHora, TM1.PjtDelUsuId, TM1.PjtDelUsuNome, TM1.PjtSigla, TM1.PjtNome, TM1.PjtAtivo, TM1.PjtDel FROM tb_clientepjtipo TM1 WHERE TM1.PjtID = :PjtID ORDER BY TM1.PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC000N12,100, GxCacheFrequency.OFF ,true,false )
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
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 10 :
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
