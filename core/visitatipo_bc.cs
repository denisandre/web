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
   public class visitatipo_bc : GxSilentTrn, IGxSilentTrn
   {
      public visitatipo_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitatipo_bc( IGxContext context )
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
         ReadRow1541( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1541( ) ;
         standaloneModal( ) ;
         AddRow1541( ) ;
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
            E11152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z411VitID = A411VitID;
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1541( ) ;
            }
            else
            {
               CheckExtendedTable1541( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1541( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11152( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM1541( short GX_JID )
      {
         if ( ( GX_JID == 10 ) || ( GX_JID == 0 ) )
         {
            Z597VitDelDataHora = A597VitDelDataHora;
            Z598VitDelData = A598VitDelData;
            Z599VitDelHora = A599VitDelHora;
            Z600VitDelUsuId = A600VitDelUsuId;
            Z601VitDelUsuNome = A601VitDelUsuNome;
            Z412VitSigla = A412VitSigla;
            Z413VitNome = A413VitNome;
            Z596VitDel = A596VitDel;
         }
         if ( GX_JID == -10 )
         {
            Z411VitID = A411VitID;
            Z597VitDelDataHora = A597VitDelDataHora;
            Z598VitDelData = A598VitDelData;
            Z599VitDelHora = A599VitDelHora;
            Z600VitDelUsuId = A600VitDelUsuId;
            Z601VitDelUsuNome = A601VitDelUsuNome;
            Z412VitSigla = A412VitSigla;
            Z413VitNome = A413VitNome;
            Z596VitDel = A596VitDel;
         }
      }

      protected void standaloneNotModal( )
      {
         AV14Pgmname = "core.VisitaTipo_BC";
      }

      protected void standaloneModal( )
      {
      }

      protected void Load1541( )
      {
         /* Using cursor BC00154 */
         pr_default.execute(2, new Object[] {A411VitID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound41 = 1;
            A597VitDelDataHora = BC00154_A597VitDelDataHora[0];
            n597VitDelDataHora = BC00154_n597VitDelDataHora[0];
            A598VitDelData = BC00154_A598VitDelData[0];
            n598VitDelData = BC00154_n598VitDelData[0];
            A599VitDelHora = BC00154_A599VitDelHora[0];
            n599VitDelHora = BC00154_n599VitDelHora[0];
            A600VitDelUsuId = BC00154_A600VitDelUsuId[0];
            n600VitDelUsuId = BC00154_n600VitDelUsuId[0];
            A601VitDelUsuNome = BC00154_A601VitDelUsuNome[0];
            n601VitDelUsuNome = BC00154_n601VitDelUsuNome[0];
            A412VitSigla = BC00154_A412VitSigla[0];
            A413VitNome = BC00154_A413VitNome[0];
            A596VitDel = BC00154_A596VitDel[0];
            ZM1541( -10) ;
         }
         pr_default.close(2);
         OnLoadActions1541( ) ;
      }

      protected void OnLoadActions1541( )
      {
      }

      protected void CheckExtendedTable1541( )
      {
         nIsDirty_41 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00155 */
         pr_default.execute(3, new Object[] {A412VitSigla, A411VitID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1541( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1541( )
      {
         /* Using cursor BC00156 */
         pr_default.execute(4, new Object[] {A411VitID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00153 */
         pr_default.execute(1, new Object[] {A411VitID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1541( 10) ;
            RcdFound41 = 1;
            A411VitID = BC00153_A411VitID[0];
            A597VitDelDataHora = BC00153_A597VitDelDataHora[0];
            n597VitDelDataHora = BC00153_n597VitDelDataHora[0];
            A598VitDelData = BC00153_A598VitDelData[0];
            n598VitDelData = BC00153_n598VitDelData[0];
            A599VitDelHora = BC00153_A599VitDelHora[0];
            n599VitDelHora = BC00153_n599VitDelHora[0];
            A600VitDelUsuId = BC00153_A600VitDelUsuId[0];
            n600VitDelUsuId = BC00153_n600VitDelUsuId[0];
            A601VitDelUsuNome = BC00153_A601VitDelUsuNome[0];
            n601VitDelUsuNome = BC00153_n601VitDelUsuNome[0];
            A412VitSigla = BC00153_A412VitSigla[0];
            A413VitNome = BC00153_A413VitNome[0];
            A596VitDel = BC00153_A596VitDel[0];
            O596VitDel = A596VitDel;
            Z411VitID = A411VitID;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1541( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1541( ) ;
            }
            Gx_mode = sMode41;
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1541( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode41;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1541( ) ;
         if ( RcdFound41 == 0 )
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
         CONFIRM_150( ) ;
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

      protected void CheckOptimisticConcurrency1541( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00152 */
            pr_default.execute(0, new Object[] {A411VitID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visitatipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z597VitDelDataHora != BC00152_A597VitDelDataHora[0] ) || ( Z598VitDelData != BC00152_A598VitDelData[0] ) || ( Z599VitDelHora != BC00152_A599VitDelHora[0] ) || ( StringUtil.StrCmp(Z600VitDelUsuId, BC00152_A600VitDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z601VitDelUsuNome, BC00152_A601VitDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z412VitSigla, BC00152_A412VitSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z413VitNome, BC00152_A413VitNome[0]) != 0 ) || ( Z596VitDel != BC00152_A596VitDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_visitatipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1541( )
      {
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1541( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1541( 0) ;
            CheckOptimisticConcurrency1541( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1541( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1541( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00157 */
                     pr_default.execute(5, new Object[] {n597VitDelDataHora, A597VitDelDataHora, n598VitDelData, A598VitDelData, n599VitDelHora, A599VitDelHora, n600VitDelUsuId, A600VitDelUsuId, n601VitDelUsuNome, A601VitDelUsuNome, A412VitSigla, A413VitNome, A596VitDel});
                     pr_default.close(5);
                     /* Retrieving last key number assigned */
                     /* Using cursor BC00158 */
                     pr_default.execute(6);
                     A411VitID = BC00158_A411VitID[0];
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
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
               Load1541( ) ;
            }
            EndLevel1541( ) ;
         }
         CloseExtendedTableCursors1541( ) ;
      }

      protected void Update1541( )
      {
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1541( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1541( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1541( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1541( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00159 */
                     pr_default.execute(7, new Object[] {n597VitDelDataHora, A597VitDelDataHora, n598VitDelData, A598VitDelData, n599VitDelHora, A599VitDelHora, n600VitDelUsuId, A600VitDelUsuId, n601VitDelUsuNome, A601VitDelUsuNome, A412VitSigla, A413VitNome, A596VitDel, A411VitID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visitatipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1541( ) ;
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
            EndLevel1541( ) ;
         }
         CloseExtendedTableCursors1541( ) ;
      }

      protected void DeferredUpdate1541( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1541( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1541( ) ;
            AfterConfirm1541( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1541( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001510 */
                  pr_default.execute(8, new Object[] {A411VitID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1541( ) ;
         Gx_mode = sMode41;
      }

      protected void OnDeleteControls1541( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor BC001511 */
            pr_default.execute(9, new Object[] {A411VitID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(9);
         }
      }

      protected void EndLevel1541( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1541( ) ;
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

      public void ScanKeyStart1541( )
      {
         /* Scan By routine */
         /* Using cursor BC001512 */
         pr_default.execute(10, new Object[] {A411VitID});
         RcdFound41 = 0;
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound41 = 1;
            A411VitID = BC001512_A411VitID[0];
            A597VitDelDataHora = BC001512_A597VitDelDataHora[0];
            n597VitDelDataHora = BC001512_n597VitDelDataHora[0];
            A598VitDelData = BC001512_A598VitDelData[0];
            n598VitDelData = BC001512_n598VitDelData[0];
            A599VitDelHora = BC001512_A599VitDelHora[0];
            n599VitDelHora = BC001512_n599VitDelHora[0];
            A600VitDelUsuId = BC001512_A600VitDelUsuId[0];
            n600VitDelUsuId = BC001512_n600VitDelUsuId[0];
            A601VitDelUsuNome = BC001512_A601VitDelUsuNome[0];
            n601VitDelUsuNome = BC001512_n601VitDelUsuNome[0];
            A412VitSigla = BC001512_A412VitSigla[0];
            A413VitNome = BC001512_A413VitNome[0];
            A596VitDel = BC001512_A596VitDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1541( )
      {
         /* Scan next routine */
         pr_default.readNext(10);
         RcdFound41 = 0;
         ScanKeyLoad1541( ) ;
      }

      protected void ScanKeyLoad1541( )
      {
         sMode41 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(10) != 101) )
         {
            RcdFound41 = 1;
            A411VitID = BC001512_A411VitID[0];
            A597VitDelDataHora = BC001512_A597VitDelDataHora[0];
            n597VitDelDataHora = BC001512_n597VitDelDataHora[0];
            A598VitDelData = BC001512_A598VitDelData[0];
            n598VitDelData = BC001512_n598VitDelData[0];
            A599VitDelHora = BC001512_A599VitDelHora[0];
            n599VitDelHora = BC001512_n599VitDelHora[0];
            A600VitDelUsuId = BC001512_A600VitDelUsuId[0];
            n600VitDelUsuId = BC001512_n600VitDelUsuId[0];
            A601VitDelUsuNome = BC001512_A601VitDelUsuNome[0];
            n601VitDelUsuNome = BC001512_n601VitDelUsuNome[0];
            A412VitSigla = BC001512_A412VitSigla[0];
            A413VitNome = BC001512_A413VitNome[0];
            A596VitDel = BC001512_A596VitDel[0];
         }
         Gx_mode = sMode41;
      }

      protected void ScanKeyEnd1541( )
      {
         pr_default.close(10);
      }

      protected void AfterConfirm1541( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1541( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1541( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A597VitDelDataHora = DateTimeUtil.NowMS( context);
            n597VitDelDataHora = false;
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A600VitDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n600VitDelUsuId = false;
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A601VitDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n601VitDelUsuNome = false;
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A598VitDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A597VitDelDataHora) ) ;
            n598VitDelData = false;
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A599VitDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A597VitDelDataHora));
            n599VitDelHora = false;
         }
      }

      protected void BeforeDelete1541( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
      }

      protected void BeforeComplete1541( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1541( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1541( )
      {
      }

      protected void send_integrity_lvl_hashes1541( )
      {
      }

      protected void AddRow1541( )
      {
         VarsToRow41( bccore_VisitaTipo) ;
      }

      protected void ReadRow1541( )
      {
         RowToVars41( bccore_VisitaTipo, 1) ;
      }

      protected void InitializeNonKey1541( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A597VitDelDataHora = (DateTime)(DateTime.MinValue);
         n597VitDelDataHora = false;
         A598VitDelData = (DateTime)(DateTime.MinValue);
         n598VitDelData = false;
         A599VitDelHora = (DateTime)(DateTime.MinValue);
         n599VitDelHora = false;
         A600VitDelUsuId = "";
         n600VitDelUsuId = false;
         A601VitDelUsuNome = "";
         n601VitDelUsuNome = false;
         A412VitSigla = "";
         A413VitNome = "";
         A596VitDel = false;
         O596VitDel = A596VitDel;
         Z597VitDelDataHora = (DateTime)(DateTime.MinValue);
         Z598VitDelData = (DateTime)(DateTime.MinValue);
         Z599VitDelHora = (DateTime)(DateTime.MinValue);
         Z600VitDelUsuId = "";
         Z601VitDelUsuNome = "";
         Z412VitSigla = "";
         Z413VitNome = "";
         Z596VitDel = false;
      }

      protected void InitAll1541( )
      {
         A411VitID = 0;
         InitializeNonKey1541( ) ;
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

      public void VarsToRow41( GeneXus.Programs.core.SdtVisitaTipo obj41 )
      {
         obj41.gxTpr_Mode = Gx_mode;
         obj41.gxTpr_Vitdeldatahora = A597VitDelDataHora;
         obj41.gxTpr_Vitdeldata = A598VitDelData;
         obj41.gxTpr_Vitdelhora = A599VitDelHora;
         obj41.gxTpr_Vitdelusuid = A600VitDelUsuId;
         obj41.gxTpr_Vitdelusunome = A601VitDelUsuNome;
         obj41.gxTpr_Vitsigla = A412VitSigla;
         obj41.gxTpr_Vitnome = A413VitNome;
         obj41.gxTpr_Vitdel = A596VitDel;
         obj41.gxTpr_Vitid = A411VitID;
         obj41.gxTpr_Vitid_Z = Z411VitID;
         obj41.gxTpr_Vitsigla_Z = Z412VitSigla;
         obj41.gxTpr_Vitnome_Z = Z413VitNome;
         obj41.gxTpr_Vitdel_Z = Z596VitDel;
         obj41.gxTpr_Vitdeldatahora_Z = Z597VitDelDataHora;
         obj41.gxTpr_Vitdeldata_Z = Z598VitDelData;
         obj41.gxTpr_Vitdelhora_Z = Z599VitDelHora;
         obj41.gxTpr_Vitdelusuid_Z = Z600VitDelUsuId;
         obj41.gxTpr_Vitdelusunome_Z = Z601VitDelUsuNome;
         obj41.gxTpr_Vitdeldatahora_N = (short)(Convert.ToInt16(n597VitDelDataHora));
         obj41.gxTpr_Vitdeldata_N = (short)(Convert.ToInt16(n598VitDelData));
         obj41.gxTpr_Vitdelhora_N = (short)(Convert.ToInt16(n599VitDelHora));
         obj41.gxTpr_Vitdelusuid_N = (short)(Convert.ToInt16(n600VitDelUsuId));
         obj41.gxTpr_Vitdelusunome_N = (short)(Convert.ToInt16(n601VitDelUsuNome));
         obj41.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow41( GeneXus.Programs.core.SdtVisitaTipo obj41 )
      {
         obj41.gxTpr_Vitid = A411VitID;
         return  ;
      }

      public void RowToVars41( GeneXus.Programs.core.SdtVisitaTipo obj41 ,
                               int forceLoad )
      {
         Gx_mode = obj41.gxTpr_Mode;
         A597VitDelDataHora = obj41.gxTpr_Vitdeldatahora;
         n597VitDelDataHora = false;
         A598VitDelData = obj41.gxTpr_Vitdeldata;
         n598VitDelData = false;
         A599VitDelHora = obj41.gxTpr_Vitdelhora;
         n599VitDelHora = false;
         A600VitDelUsuId = obj41.gxTpr_Vitdelusuid;
         n600VitDelUsuId = false;
         A601VitDelUsuNome = obj41.gxTpr_Vitdelusunome;
         n601VitDelUsuNome = false;
         A412VitSigla = obj41.gxTpr_Vitsigla;
         A413VitNome = obj41.gxTpr_Vitnome;
         A596VitDel = obj41.gxTpr_Vitdel;
         A411VitID = obj41.gxTpr_Vitid;
         Z411VitID = obj41.gxTpr_Vitid_Z;
         Z412VitSigla = obj41.gxTpr_Vitsigla_Z;
         Z413VitNome = obj41.gxTpr_Vitnome_Z;
         Z596VitDel = obj41.gxTpr_Vitdel_Z;
         O596VitDel = obj41.gxTpr_Vitdel_Z;
         Z597VitDelDataHora = obj41.gxTpr_Vitdeldatahora_Z;
         Z598VitDelData = obj41.gxTpr_Vitdeldata_Z;
         Z599VitDelHora = obj41.gxTpr_Vitdelhora_Z;
         Z600VitDelUsuId = obj41.gxTpr_Vitdelusuid_Z;
         Z601VitDelUsuNome = obj41.gxTpr_Vitdelusunome_Z;
         n597VitDelDataHora = (bool)(Convert.ToBoolean(obj41.gxTpr_Vitdeldatahora_N));
         n598VitDelData = (bool)(Convert.ToBoolean(obj41.gxTpr_Vitdeldata_N));
         n599VitDelHora = (bool)(Convert.ToBoolean(obj41.gxTpr_Vitdelhora_N));
         n600VitDelUsuId = (bool)(Convert.ToBoolean(obj41.gxTpr_Vitdelusuid_N));
         n601VitDelUsuNome = (bool)(Convert.ToBoolean(obj41.gxTpr_Vitdelusunome_N));
         Gx_mode = obj41.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A411VitID = (int)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1541( ) ;
         ScanKeyStart1541( ) ;
         if ( RcdFound41 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z411VitID = A411VitID;
            O596VitDel = A596VitDel;
         }
         ZM1541( -10) ;
         OnLoadActions1541( ) ;
         AddRow1541( ) ;
         ScanKeyEnd1541( ) ;
         if ( RcdFound41 == 0 )
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
         RowToVars41( bccore_VisitaTipo, 0) ;
         ScanKeyStart1541( ) ;
         if ( RcdFound41 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z411VitID = A411VitID;
            O596VitDel = A596VitDel;
         }
         ZM1541( -10) ;
         OnLoadActions1541( ) ;
         AddRow1541( ) ;
         ScanKeyEnd1541( ) ;
         if ( RcdFound41 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1541( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1541( ) ;
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( A411VitID != Z411VitID )
               {
                  A411VitID = Z411VitID;
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
                  Update1541( ) ;
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
                  if ( A411VitID != Z411VitID )
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
                        Insert1541( ) ;
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
                        Insert1541( ) ;
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
         RowToVars41( bccore_VisitaTipo, 1) ;
         SaveImpl( ) ;
         VarsToRow41( bccore_VisitaTipo) ;
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
         RowToVars41( bccore_VisitaTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1541( ) ;
         AfterTrn( ) ;
         VarsToRow41( bccore_VisitaTipo) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow41( bccore_VisitaTipo) ;
         }
         else
         {
            GeneXus.Programs.core.SdtVisitaTipo auxBC = new GeneXus.Programs.core.SdtVisitaTipo(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A411VitID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_VisitaTipo);
               auxBC.Save();
               bccore_VisitaTipo.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars41( bccore_VisitaTipo, 1) ;
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
         RowToVars41( bccore_VisitaTipo, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1541( ) ;
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
               VarsToRow41( bccore_VisitaTipo) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow41( bccore_VisitaTipo) ;
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
         RowToVars41( bccore_VisitaTipo, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1541( ) ;
         if ( RcdFound41 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A411VitID != Z411VitID )
            {
               A411VitID = Z411VitID;
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
            if ( A411VitID != Z411VitID )
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
         context.RollbackDataStores("core.visitatipo_bc",pr_default);
         VarsToRow41( bccore_VisitaTipo) ;
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
         Gx_mode = bccore_VisitaTipo.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_VisitaTipo.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_VisitaTipo )
         {
            bccore_VisitaTipo = (GeneXus.Programs.core.SdtVisitaTipo)(sdt);
            if ( StringUtil.StrCmp(bccore_VisitaTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_VisitaTipo.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow41( bccore_VisitaTipo) ;
            }
            else
            {
               RowToVars41( bccore_VisitaTipo, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_VisitaTipo.gxTpr_Mode, "") == 0 )
            {
               bccore_VisitaTipo.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars41( bccore_VisitaTipo, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtVisitaTipo VisitaTipo_BC
      {
         get {
            return bccore_VisitaTipo ;
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
            return "visitatipo_Execute" ;
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
         Z597VitDelDataHora = (DateTime)(DateTime.MinValue);
         A597VitDelDataHora = (DateTime)(DateTime.MinValue);
         Z598VitDelData = (DateTime)(DateTime.MinValue);
         A598VitDelData = (DateTime)(DateTime.MinValue);
         Z599VitDelHora = (DateTime)(DateTime.MinValue);
         A599VitDelHora = (DateTime)(DateTime.MinValue);
         Z600VitDelUsuId = "";
         A600VitDelUsuId = "";
         Z601VitDelUsuNome = "";
         A601VitDelUsuNome = "";
         Z412VitSigla = "";
         A412VitSigla = "";
         Z413VitNome = "";
         A413VitNome = "";
         BC00154_A411VitID = new int[1] ;
         BC00154_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00154_n597VitDelDataHora = new bool[] {false} ;
         BC00154_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         BC00154_n598VitDelData = new bool[] {false} ;
         BC00154_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00154_n599VitDelHora = new bool[] {false} ;
         BC00154_A600VitDelUsuId = new string[] {""} ;
         BC00154_n600VitDelUsuId = new bool[] {false} ;
         BC00154_A601VitDelUsuNome = new string[] {""} ;
         BC00154_n601VitDelUsuNome = new bool[] {false} ;
         BC00154_A412VitSigla = new string[] {""} ;
         BC00154_A413VitNome = new string[] {""} ;
         BC00154_A596VitDel = new bool[] {false} ;
         BC00155_A412VitSigla = new string[] {""} ;
         BC00156_A411VitID = new int[1] ;
         BC00153_A411VitID = new int[1] ;
         BC00153_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00153_n597VitDelDataHora = new bool[] {false} ;
         BC00153_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         BC00153_n598VitDelData = new bool[] {false} ;
         BC00153_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00153_n599VitDelHora = new bool[] {false} ;
         BC00153_A600VitDelUsuId = new string[] {""} ;
         BC00153_n600VitDelUsuId = new bool[] {false} ;
         BC00153_A601VitDelUsuNome = new string[] {""} ;
         BC00153_n601VitDelUsuNome = new bool[] {false} ;
         BC00153_A412VitSigla = new string[] {""} ;
         BC00153_A413VitNome = new string[] {""} ;
         BC00153_A596VitDel = new bool[] {false} ;
         sMode41 = "";
         BC00152_A411VitID = new int[1] ;
         BC00152_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00152_n597VitDelDataHora = new bool[] {false} ;
         BC00152_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         BC00152_n598VitDelData = new bool[] {false} ;
         BC00152_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00152_n599VitDelHora = new bool[] {false} ;
         BC00152_A600VitDelUsuId = new string[] {""} ;
         BC00152_n600VitDelUsuId = new bool[] {false} ;
         BC00152_A601VitDelUsuNome = new string[] {""} ;
         BC00152_n601VitDelUsuNome = new bool[] {false} ;
         BC00152_A412VitSigla = new string[] {""} ;
         BC00152_A413VitNome = new string[] {""} ;
         BC00152_A596VitDel = new bool[] {false} ;
         BC00158_A411VitID = new int[1] ;
         BC001511_A398VisID = new Guid[] {Guid.Empty} ;
         BC001512_A411VitID = new int[1] ;
         BC001512_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001512_n597VitDelDataHora = new bool[] {false} ;
         BC001512_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         BC001512_n598VitDelData = new bool[] {false} ;
         BC001512_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001512_n599VitDelHora = new bool[] {false} ;
         BC001512_A600VitDelUsuId = new string[] {""} ;
         BC001512_n600VitDelUsuId = new bool[] {false} ;
         BC001512_A601VitDelUsuNome = new string[] {""} ;
         BC001512_n601VitDelUsuNome = new bool[] {false} ;
         BC001512_A412VitSigla = new string[] {""} ;
         BC001512_A413VitNome = new string[] {""} ;
         BC001512_A596VitDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipo_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipo_bc__default(),
            new Object[][] {
                new Object[] {
               BC00152_A411VitID, BC00152_A597VitDelDataHora, BC00152_n597VitDelDataHora, BC00152_A598VitDelData, BC00152_n598VitDelData, BC00152_A599VitDelHora, BC00152_n599VitDelHora, BC00152_A600VitDelUsuId, BC00152_n600VitDelUsuId, BC00152_A601VitDelUsuNome,
               BC00152_n601VitDelUsuNome, BC00152_A412VitSigla, BC00152_A413VitNome, BC00152_A596VitDel
               }
               , new Object[] {
               BC00153_A411VitID, BC00153_A597VitDelDataHora, BC00153_n597VitDelDataHora, BC00153_A598VitDelData, BC00153_n598VitDelData, BC00153_A599VitDelHora, BC00153_n599VitDelHora, BC00153_A600VitDelUsuId, BC00153_n600VitDelUsuId, BC00153_A601VitDelUsuNome,
               BC00153_n601VitDelUsuNome, BC00153_A412VitSigla, BC00153_A413VitNome, BC00153_A596VitDel
               }
               , new Object[] {
               BC00154_A411VitID, BC00154_A597VitDelDataHora, BC00154_n597VitDelDataHora, BC00154_A598VitDelData, BC00154_n598VitDelData, BC00154_A599VitDelHora, BC00154_n599VitDelHora, BC00154_A600VitDelUsuId, BC00154_n600VitDelUsuId, BC00154_A601VitDelUsuNome,
               BC00154_n601VitDelUsuNome, BC00154_A412VitSigla, BC00154_A413VitNome, BC00154_A596VitDel
               }
               , new Object[] {
               BC00155_A412VitSigla
               }
               , new Object[] {
               BC00156_A411VitID
               }
               , new Object[] {
               }
               , new Object[] {
               BC00158_A411VitID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001511_A398VisID
               }
               , new Object[] {
               BC001512_A411VitID, BC001512_A597VitDelDataHora, BC001512_n597VitDelDataHora, BC001512_A598VitDelData, BC001512_n598VitDelData, BC001512_A599VitDelHora, BC001512_n599VitDelHora, BC001512_A600VitDelUsuId, BC001512_n600VitDelUsuId, BC001512_A601VitDelUsuNome,
               BC001512_n601VitDelUsuNome, BC001512_A412VitSigla, BC001512_A413VitNome, BC001512_A596VitDel
               }
            }
         );
         AV14Pgmname = "core.VisitaTipo_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12152 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short RcdFound41 ;
      private short nIsDirty_41 ;
      private int trnEnded ;
      private int Z411VitID ;
      private int A411VitID ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z600VitDelUsuId ;
      private string A600VitDelUsuId ;
      private string sMode41 ;
      private DateTime Z597VitDelDataHora ;
      private DateTime A597VitDelDataHora ;
      private DateTime Z598VitDelData ;
      private DateTime A598VitDelData ;
      private DateTime Z599VitDelHora ;
      private DateTime A599VitDelHora ;
      private bool returnInSub ;
      private bool Z596VitDel ;
      private bool A596VitDel ;
      private bool n597VitDelDataHora ;
      private bool n598VitDelData ;
      private bool n599VitDelHora ;
      private bool n600VitDelUsuId ;
      private bool n601VitDelUsuNome ;
      private bool O596VitDel ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z601VitDelUsuNome ;
      private string A601VitDelUsuNome ;
      private string Z412VitSigla ;
      private string A412VitSigla ;
      private string Z413VitNome ;
      private string A413VitNome ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtVisitaTipo bccore_VisitaTipo ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] BC00154_A411VitID ;
      private DateTime[] BC00154_A597VitDelDataHora ;
      private bool[] BC00154_n597VitDelDataHora ;
      private DateTime[] BC00154_A598VitDelData ;
      private bool[] BC00154_n598VitDelData ;
      private DateTime[] BC00154_A599VitDelHora ;
      private bool[] BC00154_n599VitDelHora ;
      private string[] BC00154_A600VitDelUsuId ;
      private bool[] BC00154_n600VitDelUsuId ;
      private string[] BC00154_A601VitDelUsuNome ;
      private bool[] BC00154_n601VitDelUsuNome ;
      private string[] BC00154_A412VitSigla ;
      private string[] BC00154_A413VitNome ;
      private bool[] BC00154_A596VitDel ;
      private string[] BC00155_A412VitSigla ;
      private int[] BC00156_A411VitID ;
      private int[] BC00153_A411VitID ;
      private DateTime[] BC00153_A597VitDelDataHora ;
      private bool[] BC00153_n597VitDelDataHora ;
      private DateTime[] BC00153_A598VitDelData ;
      private bool[] BC00153_n598VitDelData ;
      private DateTime[] BC00153_A599VitDelHora ;
      private bool[] BC00153_n599VitDelHora ;
      private string[] BC00153_A600VitDelUsuId ;
      private bool[] BC00153_n600VitDelUsuId ;
      private string[] BC00153_A601VitDelUsuNome ;
      private bool[] BC00153_n601VitDelUsuNome ;
      private string[] BC00153_A412VitSigla ;
      private string[] BC00153_A413VitNome ;
      private bool[] BC00153_A596VitDel ;
      private int[] BC00152_A411VitID ;
      private DateTime[] BC00152_A597VitDelDataHora ;
      private bool[] BC00152_n597VitDelDataHora ;
      private DateTime[] BC00152_A598VitDelData ;
      private bool[] BC00152_n598VitDelData ;
      private DateTime[] BC00152_A599VitDelHora ;
      private bool[] BC00152_n599VitDelHora ;
      private string[] BC00152_A600VitDelUsuId ;
      private bool[] BC00152_n600VitDelUsuId ;
      private string[] BC00152_A601VitDelUsuNome ;
      private bool[] BC00152_n601VitDelUsuNome ;
      private string[] BC00152_A412VitSigla ;
      private string[] BC00152_A413VitNome ;
      private bool[] BC00152_A596VitDel ;
      private int[] BC00158_A411VitID ;
      private Guid[] BC001511_A398VisID ;
      private int[] BC001512_A411VitID ;
      private DateTime[] BC001512_A597VitDelDataHora ;
      private bool[] BC001512_n597VitDelDataHora ;
      private DateTime[] BC001512_A598VitDelData ;
      private bool[] BC001512_n598VitDelData ;
      private DateTime[] BC001512_A599VitDelHora ;
      private bool[] BC001512_n599VitDelHora ;
      private string[] BC001512_A600VitDelUsuId ;
      private bool[] BC001512_n600VitDelUsuId ;
      private string[] BC001512_A601VitDelUsuNome ;
      private bool[] BC001512_n601VitDelUsuNome ;
      private string[] BC001512_A412VitSigla ;
      private string[] BC001512_A413VitNome ;
      private bool[] BC001512_A596VitDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class visitatipo_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class visitatipo_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00154;
        prmBC00154 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC00155;
        prmBC00155 = new Object[] {
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC00156;
        prmBC00156 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC00153;
        prmBC00153 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC00152;
        prmBC00152 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC00157;
        prmBC00157 = new Object[] {
        new ParDef("VitDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VitDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VitDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VitDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VitDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitNome",GXType.VarChar,80,0) ,
        new ParDef("VitDel",GXType.Boolean,4,0)
        };
        Object[] prmBC00158;
        prmBC00158 = new Object[] {
        };
        Object[] prmBC00159;
        prmBC00159 = new Object[] {
        new ParDef("VitDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VitDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VitDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VitDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VitDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitNome",GXType.VarChar,80,0) ,
        new ParDef("VitDel",GXType.Boolean,4,0) ,
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC001510;
        prmBC001510 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC001511;
        prmBC001511 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmBC001512;
        prmBC001512 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00152", "SELECT VitID, VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel FROM tb_visitatipo WHERE VitID = :VitID  FOR UPDATE OF tb_visitatipo",true, GxErrorMask.GX_NOMASK, false, this,prmBC00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00153", "SELECT VitID, VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel FROM tb_visitatipo WHERE VitID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00154", "SELECT TM1.VitID, TM1.VitDelDataHora, TM1.VitDelData, TM1.VitDelHora, TM1.VitDelUsuId, TM1.VitDelUsuNome, TM1.VitSigla, TM1.VitNome, TM1.VitDel FROM tb_visitatipo TM1 WHERE TM1.VitID = :VitID ORDER BY TM1.VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00154,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00155", "SELECT VitSigla FROM tb_visitatipo WHERE (VitSigla = :VitSigla) AND (Not ( VitID = :VitID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00156", "SELECT VitID FROM tb_visitatipo WHERE VitID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00156,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00157", "SAVEPOINT gxupdate;INSERT INTO tb_visitatipo(VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel) VALUES(:VitDelDataHora, :VitDelData, :VitDelHora, :VitDelUsuId, :VitDelUsuNome, :VitSigla, :VitNome, :VitDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00157)
           ,new CursorDef("BC00158", "SELECT currval('VitID') ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00158,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00159", "SAVEPOINT gxupdate;UPDATE tb_visitatipo SET VitDelDataHora=:VitDelDataHora, VitDelData=:VitDelData, VitDelHora=:VitDelHora, VitDelUsuId=:VitDelUsuId, VitDelUsuNome=:VitDelUsuNome, VitSigla=:VitSigla, VitNome=:VitNome, VitDel=:VitDel  WHERE VitID = :VitID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00159)
           ,new CursorDef("BC001510", "SAVEPOINT gxupdate;DELETE FROM tb_visitatipo  WHERE VitID = :VitID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001510)
           ,new CursorDef("BC001511", "SELECT VisID FROM tb_visita WHERE VisTipoID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001511,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001512", "SELECT TM1.VitID, TM1.VitDelDataHora, TM1.VitDelData, TM1.VitDelHora, TM1.VitDelUsuId, TM1.VitDelUsuNome, TM1.VitSigla, TM1.VitNome, TM1.VitDel FROM tb_visitatipo TM1 WHERE TM1.VitID = :VitID ORDER BY TM1.VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001512,100, GxCacheFrequency.OFF ,true,false )
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
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
              return;
     }
  }

}

}
