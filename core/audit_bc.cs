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
   public class audit_bc : GxSilentTrn, IGxSilentTrn
   {
      public audit_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public audit_bc( IGxContext context )
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
         ReadRow1843( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1843( ) ;
         standaloneModal( ) ;
         AddRow1843( ) ;
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
            E11182 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z493AuditID = A493AuditID;
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

      protected void CONFIRM_180( )
      {
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1843( ) ;
            }
            else
            {
               CheckExtendedTable1843( ) ;
               if ( AnyError == 0 )
               {
               }
               CloseExtendedTableCursors1843( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12182( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12TrnContext.FromXml(AV13WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11182( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM1843( short GX_JID )
      {
         if ( ( GX_JID == 8 ) || ( GX_JID == 0 ) )
         {
            Z496AuditDateTime = A496AuditDateTime;
            Z494AuditDate = A494AuditDate;
            Z495AuditTime = A495AuditTime;
            Z500AuditGAMUserID = A500AuditGAMUserID;
            Z501AuditGAMUserName = A501AuditGAMUserName;
            Z497AuditTableName = A497AuditTableName;
            Z499AuditShortDescription = A499AuditShortDescription;
            Z502AuditAction = A502AuditAction;
         }
         if ( GX_JID == -8 )
         {
            Z493AuditID = A493AuditID;
            Z496AuditDateTime = A496AuditDateTime;
            Z494AuditDate = A494AuditDate;
            Z495AuditTime = A495AuditTime;
            Z500AuditGAMUserID = A500AuditGAMUserID;
            Z501AuditGAMUserName = A501AuditGAMUserName;
            Z497AuditTableName = A497AuditTableName;
            Z498AuditDescription = A498AuditDescription;
            Z499AuditShortDescription = A499AuditShortDescription;
            Z502AuditAction = A502AuditAction;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (Guid.Empty==A493AuditID) )
         {
            A493AuditID = Guid.NewGuid( );
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1843( )
      {
         /* Using cursor BC00184 */
         pr_default.execute(2, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound43 = 1;
            A496AuditDateTime = BC00184_A496AuditDateTime[0];
            A494AuditDate = BC00184_A494AuditDate[0];
            A495AuditTime = BC00184_A495AuditTime[0];
            A500AuditGAMUserID = BC00184_A500AuditGAMUserID[0];
            A501AuditGAMUserName = BC00184_A501AuditGAMUserName[0];
            A497AuditTableName = BC00184_A497AuditTableName[0];
            A498AuditDescription = BC00184_A498AuditDescription[0];
            A499AuditShortDescription = BC00184_A499AuditShortDescription[0];
            A502AuditAction = BC00184_A502AuditAction[0];
            ZM1843( -8) ;
         }
         pr_default.close(2);
         OnLoadActions1843( ) ;
      }

      protected void OnLoadActions1843( )
      {
      }

      protected void CheckExtendedTable1843( )
      {
         nIsDirty_43 = 0;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors1843( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1843( )
      {
         /* Using cursor BC00185 */
         pr_default.execute(3, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound43 = 1;
         }
         else
         {
            RcdFound43 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00183 */
         pr_default.execute(1, new Object[] {A493AuditID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1843( 8) ;
            RcdFound43 = 1;
            A493AuditID = BC00183_A493AuditID[0];
            A496AuditDateTime = BC00183_A496AuditDateTime[0];
            A494AuditDate = BC00183_A494AuditDate[0];
            A495AuditTime = BC00183_A495AuditTime[0];
            A500AuditGAMUserID = BC00183_A500AuditGAMUserID[0];
            A501AuditGAMUserName = BC00183_A501AuditGAMUserName[0];
            A497AuditTableName = BC00183_A497AuditTableName[0];
            A498AuditDescription = BC00183_A498AuditDescription[0];
            A499AuditShortDescription = BC00183_A499AuditShortDescription[0];
            A502AuditAction = BC00183_A502AuditAction[0];
            Z493AuditID = A493AuditID;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1843( ) ;
            if ( AnyError == 1 )
            {
               RcdFound43 = 0;
               InitializeNonKey1843( ) ;
            }
            Gx_mode = sMode43;
         }
         else
         {
            RcdFound43 = 0;
            InitializeNonKey1843( ) ;
            sMode43 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode43;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1843( ) ;
         if ( RcdFound43 == 0 )
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
         CONFIRM_180( ) ;
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

      protected void CheckOptimisticConcurrency1843( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00182 */
            pr_default.execute(0, new Object[] {A493AuditID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_audit"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z496AuditDateTime != BC00182_A496AuditDateTime[0] ) || ( DateTimeUtil.ResetTime ( Z494AuditDate ) != DateTimeUtil.ResetTime ( BC00182_A494AuditDate[0] ) ) || ( Z495AuditTime != BC00182_A495AuditTime[0] ) || ( StringUtil.StrCmp(Z500AuditGAMUserID, BC00182_A500AuditGAMUserID[0]) != 0 ) || ( StringUtil.StrCmp(Z501AuditGAMUserName, BC00182_A501AuditGAMUserName[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z497AuditTableName, BC00182_A497AuditTableName[0]) != 0 ) || ( StringUtil.StrCmp(Z499AuditShortDescription, BC00182_A499AuditShortDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z502AuditAction, BC00182_A502AuditAction[0]) != 0 ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_audit"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1843( )
      {
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1843( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1843( 0) ;
            CheckOptimisticConcurrency1843( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1843( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1843( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00186 */
                     pr_default.execute(4, new Object[] {A493AuditID, A496AuditDateTime, A494AuditDate, A495AuditTime, A500AuditGAMUserID, A501AuditGAMUserName, A497AuditTableName, A498AuditDescription, A499AuditShortDescription, A502AuditAction});
                     pr_default.close(4);
                     pr_default.SmartCacheProvider.SetUpdated("tb_audit");
                     if ( (pr_default.getStatus(4) == 1) )
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
               Load1843( ) ;
            }
            EndLevel1843( ) ;
         }
         CloseExtendedTableCursors1843( ) ;
      }

      protected void Update1843( )
      {
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1843( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1843( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1843( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1843( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00187 */
                     pr_default.execute(5, new Object[] {A496AuditDateTime, A494AuditDate, A495AuditTime, A500AuditGAMUserID, A501AuditGAMUserName, A497AuditTableName, A498AuditDescription, A499AuditShortDescription, A502AuditAction, A493AuditID});
                     pr_default.close(5);
                     pr_default.SmartCacheProvider.SetUpdated("tb_audit");
                     if ( (pr_default.getStatus(5) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_audit"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1843( ) ;
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
            EndLevel1843( ) ;
         }
         CloseExtendedTableCursors1843( ) ;
      }

      protected void DeferredUpdate1843( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1843( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1843( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1843( ) ;
            AfterConfirm1843( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1843( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC00188 */
                  pr_default.execute(6, new Object[] {A493AuditID});
                  pr_default.close(6);
                  pr_default.SmartCacheProvider.SetUpdated("tb_audit");
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
         sMode43 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1843( ) ;
         Gx_mode = sMode43;
      }

      protected void OnDeleteControls1843( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1843( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1843( ) ;
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

      public void ScanKeyStart1843( )
      {
         /* Scan By routine */
         /* Using cursor BC00189 */
         pr_default.execute(7, new Object[] {A493AuditID});
         RcdFound43 = 0;
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound43 = 1;
            A493AuditID = BC00189_A493AuditID[0];
            A496AuditDateTime = BC00189_A496AuditDateTime[0];
            A494AuditDate = BC00189_A494AuditDate[0];
            A495AuditTime = BC00189_A495AuditTime[0];
            A500AuditGAMUserID = BC00189_A500AuditGAMUserID[0];
            A501AuditGAMUserName = BC00189_A501AuditGAMUserName[0];
            A497AuditTableName = BC00189_A497AuditTableName[0];
            A498AuditDescription = BC00189_A498AuditDescription[0];
            A499AuditShortDescription = BC00189_A499AuditShortDescription[0];
            A502AuditAction = BC00189_A502AuditAction[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1843( )
      {
         /* Scan next routine */
         pr_default.readNext(7);
         RcdFound43 = 0;
         ScanKeyLoad1843( ) ;
      }

      protected void ScanKeyLoad1843( )
      {
         sMode43 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound43 = 1;
            A493AuditID = BC00189_A493AuditID[0];
            A496AuditDateTime = BC00189_A496AuditDateTime[0];
            A494AuditDate = BC00189_A494AuditDate[0];
            A495AuditTime = BC00189_A495AuditTime[0];
            A500AuditGAMUserID = BC00189_A500AuditGAMUserID[0];
            A501AuditGAMUserName = BC00189_A501AuditGAMUserName[0];
            A497AuditTableName = BC00189_A497AuditTableName[0];
            A498AuditDescription = BC00189_A498AuditDescription[0];
            A499AuditShortDescription = BC00189_A499AuditShortDescription[0];
            A502AuditAction = BC00189_A502AuditAction[0];
         }
         Gx_mode = sMode43;
      }

      protected void ScanKeyEnd1843( )
      {
         pr_default.close(7);
      }

      protected void AfterConfirm1843( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1843( )
      {
         /* Before Insert Rules */
         A496AuditDateTime = DateTimeUtil.NowMS( context);
         A500AuditGAMUserID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         A501AuditGAMUserName = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         A494AuditDate = DateTimeUtil.ResetTime( A496AuditDateTime);
         A495AuditTime = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A496AuditDateTime));
      }

      protected void BeforeUpdate1843( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete1843( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete1843( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate1843( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1843( )
      {
      }

      protected void send_integrity_lvl_hashes1843( )
      {
      }

      protected void AddRow1843( )
      {
         VarsToRow43( bccore_Audit) ;
      }

      protected void ReadRow1843( )
      {
         RowToVars43( bccore_Audit, 1) ;
      }

      protected void InitializeNonKey1843( )
      {
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A494AuditDate = DateTime.MinValue;
         A495AuditTime = (DateTime)(DateTime.MinValue);
         A500AuditGAMUserID = "";
         A501AuditGAMUserName = "";
         A497AuditTableName = "";
         A498AuditDescription = "";
         A499AuditShortDescription = "";
         A502AuditAction = "";
         Z496AuditDateTime = (DateTime)(DateTime.MinValue);
         Z494AuditDate = DateTime.MinValue;
         Z495AuditTime = (DateTime)(DateTime.MinValue);
         Z500AuditGAMUserID = "";
         Z501AuditGAMUserName = "";
         Z497AuditTableName = "";
         Z499AuditShortDescription = "";
         Z502AuditAction = "";
      }

      protected void InitAll1843( )
      {
         A493AuditID = Guid.NewGuid( );
         InitializeNonKey1843( ) ;
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

      public void VarsToRow43( GeneXus.Programs.core.SdtAudit obj43 )
      {
         obj43.gxTpr_Mode = Gx_mode;
         obj43.gxTpr_Auditdatetime = A496AuditDateTime;
         obj43.gxTpr_Auditdate = A494AuditDate;
         obj43.gxTpr_Audittime = A495AuditTime;
         obj43.gxTpr_Auditgamuserid = A500AuditGAMUserID;
         obj43.gxTpr_Auditgamusername = A501AuditGAMUserName;
         obj43.gxTpr_Audittablename = A497AuditTableName;
         obj43.gxTpr_Auditdescription = A498AuditDescription;
         obj43.gxTpr_Auditshortdescription = A499AuditShortDescription;
         obj43.gxTpr_Auditaction = A502AuditAction;
         obj43.gxTpr_Auditid = A493AuditID;
         obj43.gxTpr_Auditid_Z = Z493AuditID;
         obj43.gxTpr_Auditdate_Z = Z494AuditDate;
         obj43.gxTpr_Audittime_Z = Z495AuditTime;
         obj43.gxTpr_Auditdatetime_Z = Z496AuditDateTime;
         obj43.gxTpr_Audittablename_Z = Z497AuditTableName;
         obj43.gxTpr_Auditshortdescription_Z = Z499AuditShortDescription;
         obj43.gxTpr_Auditgamuserid_Z = Z500AuditGAMUserID;
         obj43.gxTpr_Auditgamusername_Z = Z501AuditGAMUserName;
         obj43.gxTpr_Auditaction_Z = Z502AuditAction;
         obj43.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow43( GeneXus.Programs.core.SdtAudit obj43 )
      {
         obj43.gxTpr_Auditid = A493AuditID;
         return  ;
      }

      public void RowToVars43( GeneXus.Programs.core.SdtAudit obj43 ,
                               int forceLoad )
      {
         Gx_mode = obj43.gxTpr_Mode;
         A496AuditDateTime = obj43.gxTpr_Auditdatetime;
         A494AuditDate = obj43.gxTpr_Auditdate;
         A495AuditTime = obj43.gxTpr_Audittime;
         A500AuditGAMUserID = obj43.gxTpr_Auditgamuserid;
         A501AuditGAMUserName = obj43.gxTpr_Auditgamusername;
         A497AuditTableName = obj43.gxTpr_Audittablename;
         A498AuditDescription = obj43.gxTpr_Auditdescription;
         A499AuditShortDescription = obj43.gxTpr_Auditshortdescription;
         A502AuditAction = obj43.gxTpr_Auditaction;
         A493AuditID = obj43.gxTpr_Auditid;
         Z493AuditID = obj43.gxTpr_Auditid_Z;
         Z494AuditDate = obj43.gxTpr_Auditdate_Z;
         Z495AuditTime = obj43.gxTpr_Audittime_Z;
         Z496AuditDateTime = obj43.gxTpr_Auditdatetime_Z;
         Z497AuditTableName = obj43.gxTpr_Audittablename_Z;
         Z499AuditShortDescription = obj43.gxTpr_Auditshortdescription_Z;
         Z500AuditGAMUserID = obj43.gxTpr_Auditgamuserid_Z;
         Z501AuditGAMUserName = obj43.gxTpr_Auditgamusername_Z;
         Z502AuditAction = obj43.gxTpr_Auditaction_Z;
         Gx_mode = obj43.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A493AuditID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1843( ) ;
         ScanKeyStart1843( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z493AuditID = A493AuditID;
         }
         ZM1843( -8) ;
         OnLoadActions1843( ) ;
         AddRow1843( ) ;
         ScanKeyEnd1843( ) ;
         if ( RcdFound43 == 0 )
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
         RowToVars43( bccore_Audit, 0) ;
         ScanKeyStart1843( ) ;
         if ( RcdFound43 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z493AuditID = A493AuditID;
         }
         ZM1843( -8) ;
         OnLoadActions1843( ) ;
         AddRow1843( ) ;
         ScanKeyEnd1843( ) ;
         if ( RcdFound43 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1843( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1843( ) ;
         }
         else
         {
            if ( RcdFound43 == 1 )
            {
               if ( A493AuditID != Z493AuditID )
               {
                  A493AuditID = Z493AuditID;
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
                  Update1843( ) ;
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
                  if ( A493AuditID != Z493AuditID )
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
                        Insert1843( ) ;
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
                        Insert1843( ) ;
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
         RowToVars43( bccore_Audit, 1) ;
         SaveImpl( ) ;
         VarsToRow43( bccore_Audit) ;
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
         RowToVars43( bccore_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1843( ) ;
         AfterTrn( ) ;
         VarsToRow43( bccore_Audit) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow43( bccore_Audit) ;
         }
         else
         {
            GeneXus.Programs.core.SdtAudit auxBC = new GeneXus.Programs.core.SdtAudit(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A493AuditID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Audit);
               auxBC.Save();
               bccore_Audit.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars43( bccore_Audit, 1) ;
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
         RowToVars43( bccore_Audit, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1843( ) ;
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
               VarsToRow43( bccore_Audit) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow43( bccore_Audit) ;
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
         RowToVars43( bccore_Audit, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1843( ) ;
         if ( RcdFound43 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A493AuditID != Z493AuditID )
            {
               A493AuditID = Z493AuditID;
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
            if ( A493AuditID != Z493AuditID )
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
         context.RollbackDataStores("core.audit_bc",pr_default);
         VarsToRow43( bccore_Audit) ;
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
         Gx_mode = bccore_Audit.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Audit.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Audit )
         {
            bccore_Audit = (GeneXus.Programs.core.SdtAudit)(sdt);
            if ( StringUtil.StrCmp(bccore_Audit.gxTpr_Mode, "") == 0 )
            {
               bccore_Audit.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow43( bccore_Audit) ;
            }
            else
            {
               RowToVars43( bccore_Audit, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Audit.gxTpr_Mode, "") == 0 )
            {
               bccore_Audit.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars43( bccore_Audit, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtAudit Audit_BC
      {
         get {
            return bccore_Audit ;
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
            return "audit_Execute" ;
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
         Z493AuditID = Guid.Empty;
         A493AuditID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV13WebSession = context.GetSession();
         Z496AuditDateTime = (DateTime)(DateTime.MinValue);
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         Z494AuditDate = DateTime.MinValue;
         A494AuditDate = DateTime.MinValue;
         Z495AuditTime = (DateTime)(DateTime.MinValue);
         A495AuditTime = (DateTime)(DateTime.MinValue);
         Z500AuditGAMUserID = "";
         A500AuditGAMUserID = "";
         Z501AuditGAMUserName = "";
         A501AuditGAMUserName = "";
         Z497AuditTableName = "";
         A497AuditTableName = "";
         Z499AuditShortDescription = "";
         A499AuditShortDescription = "";
         Z502AuditAction = "";
         A502AuditAction = "";
         Z498AuditDescription = "";
         A498AuditDescription = "";
         BC00184_A493AuditID = new Guid[] {Guid.Empty} ;
         BC00184_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00184_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00184_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         BC00184_A500AuditGAMUserID = new string[] {""} ;
         BC00184_A501AuditGAMUserName = new string[] {""} ;
         BC00184_A497AuditTableName = new string[] {""} ;
         BC00184_A498AuditDescription = new string[] {""} ;
         BC00184_A499AuditShortDescription = new string[] {""} ;
         BC00184_A502AuditAction = new string[] {""} ;
         BC00185_A493AuditID = new Guid[] {Guid.Empty} ;
         BC00183_A493AuditID = new Guid[] {Guid.Empty} ;
         BC00183_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00183_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00183_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         BC00183_A500AuditGAMUserID = new string[] {""} ;
         BC00183_A501AuditGAMUserName = new string[] {""} ;
         BC00183_A497AuditTableName = new string[] {""} ;
         BC00183_A498AuditDescription = new string[] {""} ;
         BC00183_A499AuditShortDescription = new string[] {""} ;
         BC00183_A502AuditAction = new string[] {""} ;
         sMode43 = "";
         BC00182_A493AuditID = new Guid[] {Guid.Empty} ;
         BC00182_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00182_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00182_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         BC00182_A500AuditGAMUserID = new string[] {""} ;
         BC00182_A501AuditGAMUserName = new string[] {""} ;
         BC00182_A497AuditTableName = new string[] {""} ;
         BC00182_A498AuditDescription = new string[] {""} ;
         BC00182_A499AuditShortDescription = new string[] {""} ;
         BC00182_A502AuditAction = new string[] {""} ;
         BC00189_A493AuditID = new Guid[] {Guid.Empty} ;
         BC00189_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         BC00189_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         BC00189_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         BC00189_A500AuditGAMUserID = new string[] {""} ;
         BC00189_A501AuditGAMUserName = new string[] {""} ;
         BC00189_A497AuditTableName = new string[] {""} ;
         BC00189_A498AuditDescription = new string[] {""} ;
         BC00189_A499AuditShortDescription = new string[] {""} ;
         BC00189_A502AuditAction = new string[] {""} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.audit_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.audit_bc__default(),
            new Object[][] {
                new Object[] {
               BC00182_A493AuditID, BC00182_A496AuditDateTime, BC00182_A494AuditDate, BC00182_A495AuditTime, BC00182_A500AuditGAMUserID, BC00182_A501AuditGAMUserName, BC00182_A497AuditTableName, BC00182_A498AuditDescription, BC00182_A499AuditShortDescription, BC00182_A502AuditAction
               }
               , new Object[] {
               BC00183_A493AuditID, BC00183_A496AuditDateTime, BC00183_A494AuditDate, BC00183_A495AuditTime, BC00183_A500AuditGAMUserID, BC00183_A501AuditGAMUserName, BC00183_A497AuditTableName, BC00183_A498AuditDescription, BC00183_A499AuditShortDescription, BC00183_A502AuditAction
               }
               , new Object[] {
               BC00184_A493AuditID, BC00184_A496AuditDateTime, BC00184_A494AuditDate, BC00184_A495AuditTime, BC00184_A500AuditGAMUserID, BC00184_A501AuditGAMUserName, BC00184_A497AuditTableName, BC00184_A498AuditDescription, BC00184_A499AuditShortDescription, BC00184_A502AuditAction
               }
               , new Object[] {
               BC00185_A493AuditID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC00189_A493AuditID, BC00189_A496AuditDateTime, BC00189_A494AuditDate, BC00189_A495AuditTime, BC00189_A500AuditGAMUserID, BC00189_A501AuditGAMUserName, BC00189_A497AuditTableName, BC00189_A498AuditDescription, BC00189_A499AuditShortDescription, BC00189_A502AuditAction
               }
            }
         );
         Z493AuditID = Guid.NewGuid( );
         A493AuditID = Guid.NewGuid( );
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12182 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound43 ;
      private short nIsDirty_43 ;
      private int trnEnded ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string Z500AuditGAMUserID ;
      private string A500AuditGAMUserID ;
      private string sMode43 ;
      private DateTime Z496AuditDateTime ;
      private DateTime A496AuditDateTime ;
      private DateTime Z495AuditTime ;
      private DateTime A495AuditTime ;
      private DateTime Z494AuditDate ;
      private DateTime A494AuditDate ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool mustCommit ;
      private string Z498AuditDescription ;
      private string A498AuditDescription ;
      private string Z501AuditGAMUserName ;
      private string A501AuditGAMUserName ;
      private string Z497AuditTableName ;
      private string A497AuditTableName ;
      private string Z499AuditShortDescription ;
      private string A499AuditShortDescription ;
      private string Z502AuditAction ;
      private string A502AuditAction ;
      private Guid Z493AuditID ;
      private Guid A493AuditID ;
      private IGxSession AV13WebSession ;
      private GeneXus.Programs.core.SdtAudit bccore_Audit ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00184_A493AuditID ;
      private DateTime[] BC00184_A496AuditDateTime ;
      private DateTime[] BC00184_A494AuditDate ;
      private DateTime[] BC00184_A495AuditTime ;
      private string[] BC00184_A500AuditGAMUserID ;
      private string[] BC00184_A501AuditGAMUserName ;
      private string[] BC00184_A497AuditTableName ;
      private string[] BC00184_A498AuditDescription ;
      private string[] BC00184_A499AuditShortDescription ;
      private string[] BC00184_A502AuditAction ;
      private Guid[] BC00185_A493AuditID ;
      private Guid[] BC00183_A493AuditID ;
      private DateTime[] BC00183_A496AuditDateTime ;
      private DateTime[] BC00183_A494AuditDate ;
      private DateTime[] BC00183_A495AuditTime ;
      private string[] BC00183_A500AuditGAMUserID ;
      private string[] BC00183_A501AuditGAMUserName ;
      private string[] BC00183_A497AuditTableName ;
      private string[] BC00183_A498AuditDescription ;
      private string[] BC00183_A499AuditShortDescription ;
      private string[] BC00183_A502AuditAction ;
      private Guid[] BC00182_A493AuditID ;
      private DateTime[] BC00182_A496AuditDateTime ;
      private DateTime[] BC00182_A494AuditDate ;
      private DateTime[] BC00182_A495AuditTime ;
      private string[] BC00182_A500AuditGAMUserID ;
      private string[] BC00182_A501AuditGAMUserName ;
      private string[] BC00182_A497AuditTableName ;
      private string[] BC00182_A498AuditDescription ;
      private string[] BC00182_A499AuditShortDescription ;
      private string[] BC00182_A502AuditAction ;
      private Guid[] BC00189_A493AuditID ;
      private DateTime[] BC00189_A496AuditDateTime ;
      private DateTime[] BC00189_A494AuditDate ;
      private DateTime[] BC00189_A495AuditTime ;
      private string[] BC00189_A500AuditGAMUserID ;
      private string[] BC00189_A501AuditGAMUserName ;
      private string[] BC00189_A497AuditTableName ;
      private string[] BC00189_A498AuditDescription ;
      private string[] BC00189_A499AuditShortDescription ;
      private string[] BC00189_A502AuditAction ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV12TrnContext ;
   }

   public class audit_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class audit_bc__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new ForEachCursor(def[7])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmBC00184;
        prmBC00184 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00185;
        prmBC00185 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00183;
        prmBC00183 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00182;
        prmBC00182 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00186;
        prmBC00186 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("AuditDateTime",GXType.DateTime2,10,12) ,
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTime",GXType.DateTime,0,5) ,
        new ParDef("AuditGAMUserID",GXType.Char,40,0) ,
        new ParDef("AuditGAMUserName",GXType.VarChar,80,0) ,
        new ParDef("AuditTableName",GXType.VarChar,80,0) ,
        new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
        new ParDef("AuditAction",GXType.VarChar,40,0)
        };
        Object[] prmBC00187;
        prmBC00187 = new Object[] {
        new ParDef("AuditDateTime",GXType.DateTime2,10,12) ,
        new ParDef("AuditDate",GXType.Date,8,0) ,
        new ParDef("AuditTime",GXType.DateTime,0,5) ,
        new ParDef("AuditGAMUserID",GXType.Char,40,0) ,
        new ParDef("AuditGAMUserName",GXType.VarChar,80,0) ,
        new ParDef("AuditTableName",GXType.VarChar,80,0) ,
        new ParDef("AuditDescription",GXType.LongVarChar,2097152,0) ,
        new ParDef("AuditShortDescription",GXType.VarChar,400,0) ,
        new ParDef("AuditAction",GXType.VarChar,40,0) ,
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00188;
        prmBC00188 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00189;
        prmBC00189 = new Object[] {
        new ParDef("AuditID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00182", "SELECT AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction FROM tb_audit WHERE AuditID = :AuditID  FOR UPDATE OF tb_audit",true, GxErrorMask.GX_NOMASK, false, this,prmBC00182,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00183", "SELECT AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction FROM tb_audit WHERE AuditID = :AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00183,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00184", "SELECT TM1.AuditID, TM1.AuditDateTime, TM1.AuditDate, TM1.AuditTime, TM1.AuditGAMUserID, TM1.AuditGAMUserName, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction FROM tb_audit TM1 WHERE TM1.AuditID = :AuditID ORDER BY TM1.AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00184,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00185", "SELECT AuditID FROM tb_audit WHERE AuditID = :AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00185,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00186", "SAVEPOINT gxupdate;INSERT INTO tb_audit(AuditID, AuditDateTime, AuditDate, AuditTime, AuditGAMUserID, AuditGAMUserName, AuditTableName, AuditDescription, AuditShortDescription, AuditAction) VALUES(:AuditID, :AuditDateTime, :AuditDate, :AuditTime, :AuditGAMUserID, :AuditGAMUserName, :AuditTableName, :AuditDescription, :AuditShortDescription, :AuditAction);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00186)
           ,new CursorDef("BC00187", "SAVEPOINT gxupdate;UPDATE tb_audit SET AuditDateTime=:AuditDateTime, AuditDate=:AuditDate, AuditTime=:AuditTime, AuditGAMUserID=:AuditGAMUserID, AuditGAMUserName=:AuditGAMUserName, AuditTableName=:AuditTableName, AuditDescription=:AuditDescription, AuditShortDescription=:AuditShortDescription, AuditAction=:AuditAction  WHERE AuditID = :AuditID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00187)
           ,new CursorDef("BC00188", "SAVEPOINT gxupdate;DELETE FROM tb_audit  WHERE AuditID = :AuditID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC00188)
           ,new CursorDef("BC00189", "SELECT TM1.AuditID, TM1.AuditDateTime, TM1.AuditDate, TM1.AuditTime, TM1.AuditGAMUserID, TM1.AuditGAMUserName, TM1.AuditTableName, TM1.AuditDescription, TM1.AuditShortDescription, TM1.AuditAction FROM tb_audit TM1 WHERE TM1.AuditID = :AuditID ORDER BY TM1.AuditID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00189,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getVarchar(10);
              return;
     }
  }

}

}
