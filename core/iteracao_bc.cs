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
   public class iteracao_bc : GxSilentTrn, IGxSilentTrn
   {
      public iteracao_bc( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public iteracao_bc( IGxContext context )
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
         ReadRow1238( ) ;
         standaloneNotModal( ) ;
         InitializeNonKey1238( ) ;
         standaloneModal( ) ;
         AddRow1238( ) ;
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
            E11122 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               Z381IteID = A381IteID;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1238( ) ;
            }
            else
            {
               CheckExtendedTable1238( ) ;
               if ( AnyError == 0 )
               {
                  ZM1238( 15) ;
               }
               CloseExtendedTableCursors1238( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
         }
      }

      protected void E12122( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E11122( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
      }

      protected void ZM1238( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            Z591IteDelDataHora = A591IteDelDataHora;
            Z592IteDelData = A592IteDelData;
            Z593IteDelHora = A593IteDelHora;
            Z594IteDelUsuId = A594IteDelUsuId;
            Z595IteDelUsuNome = A595IteDelUsuNome;
            Z382IteOrdem = A382IteOrdem;
            Z383IteNome = A383IteNome;
            Z384IteAtivo = A384IteAtivo;
            Z590IteDel = A590IteDel;
            Z431IteTotalOportunidades = A431IteTotalOportunidades;
            Z432IteQtdeOportunidades = A432IteQtdeOportunidades;
         }
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            Z431IteTotalOportunidades = A431IteTotalOportunidades;
            Z432IteQtdeOportunidades = A432IteQtdeOportunidades;
         }
         if ( GX_JID == -13 )
         {
            Z381IteID = A381IteID;
            Z591IteDelDataHora = A591IteDelDataHora;
            Z592IteDelData = A592IteDelData;
            Z593IteDelHora = A593IteDelHora;
            Z594IteDelUsuId = A594IteDelUsuId;
            Z595IteDelUsuNome = A595IteDelUsuNome;
            Z382IteOrdem = A382IteOrdem;
            Z383IteNome = A383IteNome;
            Z384IteAtivo = A384IteAtivo;
            Z590IteDel = A590IteDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AV14Pgmname = "core.Iteracao_BC";
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (false==A384IteAtivo) && ( Gx_BScreen == 0 ) )
         {
            A384IteAtivo = true;
         }
      }

      protected void Load1238( )
      {
         /* Using cursor BC00126 */
         pr_default.execute(3, new Object[] {A381IteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound38 = 1;
            A591IteDelDataHora = BC00126_A591IteDelDataHora[0];
            n591IteDelDataHora = BC00126_n591IteDelDataHora[0];
            A592IteDelData = BC00126_A592IteDelData[0];
            n592IteDelData = BC00126_n592IteDelData[0];
            A593IteDelHora = BC00126_A593IteDelHora[0];
            n593IteDelHora = BC00126_n593IteDelHora[0];
            A594IteDelUsuId = BC00126_A594IteDelUsuId[0];
            n594IteDelUsuId = BC00126_n594IteDelUsuId[0];
            A595IteDelUsuNome = BC00126_A595IteDelUsuNome[0];
            n595IteDelUsuNome = BC00126_n595IteDelUsuNome[0];
            A382IteOrdem = BC00126_A382IteOrdem[0];
            A383IteNome = BC00126_A383IteNome[0];
            A384IteAtivo = BC00126_A384IteAtivo[0];
            A590IteDel = BC00126_A590IteDel[0];
            ZM1238( -13) ;
         }
         pr_default.close(3);
         OnLoadActions1238( ) ;
      }

      protected void OnLoadActions1238( )
      {
         /* Using cursor BC00125 */
         pr_default.execute(2, new Object[] {A381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A431IteTotalOportunidades = BC00125_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = BC00125_A432IteQtdeOportunidades[0];
         }
         else
         {
            A431IteTotalOportunidades = 0;
            A432IteQtdeOportunidades = 0;
         }
         pr_default.close(2);
      }

      protected void CheckExtendedTable1238( )
      {
         nIsDirty_38 = 0;
         standaloneModal( ) ;
         /* Using cursor BC00125 */
         pr_default.execute(2, new Object[] {A381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A431IteTotalOportunidades = BC00125_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = BC00125_A432IteQtdeOportunidades[0];
         }
         else
         {
            nIsDirty_38 = 1;
            A431IteTotalOportunidades = 0;
            nIsDirty_38 = 1;
            A432IteQtdeOportunidades = 0;
         }
         pr_default.close(2);
         /* Using cursor BC00127 */
         pr_default.execute(4, new Object[] {A382IteOrdem, A381IteID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Ordem"}), 1, "");
            AnyError = 1;
         }
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A383IteNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição da Iteração", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
      }

      protected void CloseExtendedTableCursors1238( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1238( )
      {
         /* Using cursor BC00128 */
         pr_default.execute(5, new Object[] {A381IteID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor BC00123 */
         pr_default.execute(1, new Object[] {A381IteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1238( 13) ;
            RcdFound38 = 1;
            A381IteID = BC00123_A381IteID[0];
            A591IteDelDataHora = BC00123_A591IteDelDataHora[0];
            n591IteDelDataHora = BC00123_n591IteDelDataHora[0];
            A592IteDelData = BC00123_A592IteDelData[0];
            n592IteDelData = BC00123_n592IteDelData[0];
            A593IteDelHora = BC00123_A593IteDelHora[0];
            n593IteDelHora = BC00123_n593IteDelHora[0];
            A594IteDelUsuId = BC00123_A594IteDelUsuId[0];
            n594IteDelUsuId = BC00123_n594IteDelUsuId[0];
            A595IteDelUsuNome = BC00123_A595IteDelUsuNome[0];
            n595IteDelUsuNome = BC00123_n595IteDelUsuNome[0];
            A382IteOrdem = BC00123_A382IteOrdem[0];
            A383IteNome = BC00123_A383IteNome[0];
            A384IteAtivo = BC00123_A384IteAtivo[0];
            A590IteDel = BC00123_A590IteDel[0];
            O590IteDel = A590IteDel;
            Z381IteID = A381IteID;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Load1238( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey1238( ) ;
            }
            Gx_mode = sMode38;
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey1238( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            standaloneModal( ) ;
            Gx_mode = sMode38;
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1238( ) ;
         if ( RcdFound38 == 0 )
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
         CONFIRM_120( ) ;
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

      protected void CheckOptimisticConcurrency1238( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor BC00122 */
            pr_default.execute(0, new Object[] {A381IteID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_Iteracao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z591IteDelDataHora != BC00122_A591IteDelDataHora[0] ) || ( Z592IteDelData != BC00122_A592IteDelData[0] ) || ( Z593IteDelHora != BC00122_A593IteDelHora[0] ) || ( StringUtil.StrCmp(Z594IteDelUsuId, BC00122_A594IteDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z595IteDelUsuNome, BC00122_A595IteDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z382IteOrdem != BC00122_A382IteOrdem[0] ) || ( StringUtil.StrCmp(Z383IteNome, BC00122_A383IteNome[0]) != 0 ) || ( Z384IteAtivo != BC00122_A384IteAtivo[0] ) || ( Z590IteDel != BC00122_A590IteDel[0] ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_Iteracao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1238( )
      {
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1238( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1238( 0) ;
            CheckOptimisticConcurrency1238( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1238( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1238( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC00129 */
                     pr_default.execute(6, new Object[] {A381IteID, n591IteDelDataHora, A591IteDelDataHora, n592IteDelData, A592IteDelData, n593IteDelHora, A593IteDelHora, n594IteDelUsuId, A594IteDelUsuId, n595IteDelUsuNome, A595IteDelUsuNome, A382IteOrdem, A383IteNome, A384IteAtivo, A590IteDel});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
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
               Load1238( ) ;
            }
            EndLevel1238( ) ;
         }
         CloseExtendedTableCursors1238( ) ;
      }

      protected void Update1238( )
      {
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1238( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1238( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1238( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1238( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor BC001210 */
                     pr_default.execute(7, new Object[] {n591IteDelDataHora, A591IteDelDataHora, n592IteDelData, A592IteDelData, n593IteDelHora, A593IteDelHora, n594IteDelUsuId, A594IteDelUsuId, n595IteDelUsuNome, A595IteDelUsuNome, A382IteOrdem, A383IteNome, A384IteAtivo, A590IteDel, A381IteID});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_Iteracao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1238( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_iteracaoupdateredundancy(context ).execute( ref  A381IteID) ;
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
            EndLevel1238( ) ;
         }
         CloseExtendedTableCursors1238( ) ;
      }

      protected void DeferredUpdate1238( )
      {
      }

      protected void delete( )
      {
         Gx_mode = "DLT";
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1238( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1238( ) ;
            AfterConfirm1238( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1238( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor BC001211 */
                  pr_default.execute(8, new Object[] {A381IteID});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         EndLevel1238( ) ;
         Gx_mode = sMode38;
      }

      protected void OnDeleteControls1238( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor BC001213 */
            pr_default.execute(9, new Object[] {A381IteID});
            if ( (pr_default.getStatus(9) != 101) )
            {
               A431IteTotalOportunidades = BC001213_A431IteTotalOportunidades[0];
               A432IteQtdeOportunidades = BC001213_A432IteQtdeOportunidades[0];
            }
            else
            {
               A431IteTotalOportunidades = 0;
               A432IteQtdeOportunidades = 0;
            }
            pr_default.close(9);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor BC001214 */
            pr_default.execute(10, new Object[] {A381IteID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel1238( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1238( ) ;
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

      public void ScanKeyStart1238( )
      {
         /* Scan By routine */
         /* Using cursor BC001215 */
         pr_default.execute(11, new Object[] {A381IteID});
         RcdFound38 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound38 = 1;
            A381IteID = BC001215_A381IteID[0];
            A591IteDelDataHora = BC001215_A591IteDelDataHora[0];
            n591IteDelDataHora = BC001215_n591IteDelDataHora[0];
            A592IteDelData = BC001215_A592IteDelData[0];
            n592IteDelData = BC001215_n592IteDelData[0];
            A593IteDelHora = BC001215_A593IteDelHora[0];
            n593IteDelHora = BC001215_n593IteDelHora[0];
            A594IteDelUsuId = BC001215_A594IteDelUsuId[0];
            n594IteDelUsuId = BC001215_n594IteDelUsuId[0];
            A595IteDelUsuNome = BC001215_A595IteDelUsuNome[0];
            n595IteDelUsuNome = BC001215_n595IteDelUsuNome[0];
            A382IteOrdem = BC001215_A382IteOrdem[0];
            A383IteNome = BC001215_A383IteNome[0];
            A384IteAtivo = BC001215_A384IteAtivo[0];
            A590IteDel = BC001215_A590IteDel[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanKeyNext1238( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound38 = 0;
         ScanKeyLoad1238( ) ;
      }

      protected void ScanKeyLoad1238( )
      {
         sMode38 = Gx_mode;
         Gx_mode = "DSP";
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound38 = 1;
            A381IteID = BC001215_A381IteID[0];
            A591IteDelDataHora = BC001215_A591IteDelDataHora[0];
            n591IteDelDataHora = BC001215_n591IteDelDataHora[0];
            A592IteDelData = BC001215_A592IteDelData[0];
            n592IteDelData = BC001215_n592IteDelData[0];
            A593IteDelHora = BC001215_A593IteDelHora[0];
            n593IteDelHora = BC001215_n593IteDelHora[0];
            A594IteDelUsuId = BC001215_A594IteDelUsuId[0];
            n594IteDelUsuId = BC001215_n594IteDelUsuId[0];
            A595IteDelUsuNome = BC001215_A595IteDelUsuNome[0];
            n595IteDelUsuNome = BC001215_n595IteDelUsuNome[0];
            A382IteOrdem = BC001215_A382IteOrdem[0];
            A383IteNome = BC001215_A383IteNome[0];
            A384IteAtivo = BC001215_A384IteAtivo[0];
            A590IteDel = BC001215_A590IteDel[0];
         }
         Gx_mode = sMode38;
      }

      protected void ScanKeyEnd1238( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1238( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1238( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1238( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A591IteDelDataHora = DateTimeUtil.NowMS( context);
            n591IteDelDataHora = false;
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A594IteDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n594IteDelUsuId = false;
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A595IteDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n595IteDelUsuNome = false;
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A592IteDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A591IteDelDataHora) ) ;
            n592IteDelData = false;
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A593IteDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A591IteDelDataHora));
            n593IteDelHora = false;
         }
      }

      protected void BeforeDelete1238( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
      }

      protected void BeforeComplete1238( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1238( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1238( )
      {
      }

      protected void send_integrity_lvl_hashes1238( )
      {
      }

      protected void AddRow1238( )
      {
         VarsToRow38( bccore_Iteracao) ;
      }

      protected void ReadRow1238( )
      {
         RowToVars38( bccore_Iteracao, 1) ;
      }

      protected void InitializeNonKey1238( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A591IteDelDataHora = (DateTime)(DateTime.MinValue);
         n591IteDelDataHora = false;
         A592IteDelData = (DateTime)(DateTime.MinValue);
         n592IteDelData = false;
         A593IteDelHora = (DateTime)(DateTime.MinValue);
         n593IteDelHora = false;
         A594IteDelUsuId = "";
         n594IteDelUsuId = false;
         A595IteDelUsuNome = "";
         n595IteDelUsuNome = false;
         A431IteTotalOportunidades = 0;
         A432IteQtdeOportunidades = 0;
         A382IteOrdem = 0;
         A383IteNome = "";
         A590IteDel = false;
         A384IteAtivo = true;
         O590IteDel = A590IteDel;
         Z591IteDelDataHora = (DateTime)(DateTime.MinValue);
         Z592IteDelData = (DateTime)(DateTime.MinValue);
         Z593IteDelHora = (DateTime)(DateTime.MinValue);
         Z594IteDelUsuId = "";
         Z595IteDelUsuNome = "";
         Z382IteOrdem = 0;
         Z383IteNome = "";
         Z384IteAtivo = false;
         Z590IteDel = false;
      }

      protected void InitAll1238( )
      {
         A381IteID = Guid.Empty;
         InitializeNonKey1238( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A384IteAtivo = i384IteAtivo;
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

      public void VarsToRow38( GeneXus.Programs.core.SdtIteracao obj38 )
      {
         obj38.gxTpr_Mode = Gx_mode;
         obj38.gxTpr_Itedeldatahora = A591IteDelDataHora;
         obj38.gxTpr_Itedeldata = A592IteDelData;
         obj38.gxTpr_Itedelhora = A593IteDelHora;
         obj38.gxTpr_Itedelusuid = A594IteDelUsuId;
         obj38.gxTpr_Itedelusunome = A595IteDelUsuNome;
         obj38.gxTpr_Itetotaloportunidades = A431IteTotalOportunidades;
         obj38.gxTpr_Iteqtdeoportunidades = A432IteQtdeOportunidades;
         obj38.gxTpr_Iteordem = A382IteOrdem;
         obj38.gxTpr_Itenome = A383IteNome;
         obj38.gxTpr_Itedel = A590IteDel;
         obj38.gxTpr_Iteativo = A384IteAtivo;
         obj38.gxTpr_Iteid = A381IteID;
         obj38.gxTpr_Iteid_Z = Z381IteID;
         obj38.gxTpr_Iteordem_Z = Z382IteOrdem;
         obj38.gxTpr_Itenome_Z = Z383IteNome;
         obj38.gxTpr_Iteativo_Z = Z384IteAtivo;
         obj38.gxTpr_Itetotaloportunidades_Z = Z431IteTotalOportunidades;
         obj38.gxTpr_Iteqtdeoportunidades_Z = Z432IteQtdeOportunidades;
         obj38.gxTpr_Itedel_Z = Z590IteDel;
         obj38.gxTpr_Itedeldatahora_Z = Z591IteDelDataHora;
         obj38.gxTpr_Itedeldata_Z = Z592IteDelData;
         obj38.gxTpr_Itedelhora_Z = Z593IteDelHora;
         obj38.gxTpr_Itedelusuid_Z = Z594IteDelUsuId;
         obj38.gxTpr_Itedelusunome_Z = Z595IteDelUsuNome;
         obj38.gxTpr_Itedeldatahora_N = (short)(Convert.ToInt16(n591IteDelDataHora));
         obj38.gxTpr_Itedeldata_N = (short)(Convert.ToInt16(n592IteDelData));
         obj38.gxTpr_Itedelhora_N = (short)(Convert.ToInt16(n593IteDelHora));
         obj38.gxTpr_Itedelusuid_N = (short)(Convert.ToInt16(n594IteDelUsuId));
         obj38.gxTpr_Itedelusunome_N = (short)(Convert.ToInt16(n595IteDelUsuNome));
         obj38.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void KeyVarsToRow38( GeneXus.Programs.core.SdtIteracao obj38 )
      {
         obj38.gxTpr_Iteid = A381IteID;
         return  ;
      }

      public void RowToVars38( GeneXus.Programs.core.SdtIteracao obj38 ,
                               int forceLoad )
      {
         Gx_mode = obj38.gxTpr_Mode;
         A591IteDelDataHora = obj38.gxTpr_Itedeldatahora;
         n591IteDelDataHora = false;
         A592IteDelData = obj38.gxTpr_Itedeldata;
         n592IteDelData = false;
         A593IteDelHora = obj38.gxTpr_Itedelhora;
         n593IteDelHora = false;
         A594IteDelUsuId = obj38.gxTpr_Itedelusuid;
         n594IteDelUsuId = false;
         A595IteDelUsuNome = obj38.gxTpr_Itedelusunome;
         n595IteDelUsuNome = false;
         A431IteTotalOportunidades = obj38.gxTpr_Itetotaloportunidades;
         A432IteQtdeOportunidades = obj38.gxTpr_Iteqtdeoportunidades;
         A382IteOrdem = obj38.gxTpr_Iteordem;
         A383IteNome = obj38.gxTpr_Itenome;
         A590IteDel = obj38.gxTpr_Itedel;
         A384IteAtivo = obj38.gxTpr_Iteativo;
         A381IteID = obj38.gxTpr_Iteid;
         Z381IteID = obj38.gxTpr_Iteid_Z;
         Z382IteOrdem = obj38.gxTpr_Iteordem_Z;
         Z383IteNome = obj38.gxTpr_Itenome_Z;
         Z384IteAtivo = obj38.gxTpr_Iteativo_Z;
         Z431IteTotalOportunidades = obj38.gxTpr_Itetotaloportunidades_Z;
         Z432IteQtdeOportunidades = obj38.gxTpr_Iteqtdeoportunidades_Z;
         Z590IteDel = obj38.gxTpr_Itedel_Z;
         O590IteDel = obj38.gxTpr_Itedel_Z;
         Z591IteDelDataHora = obj38.gxTpr_Itedeldatahora_Z;
         Z592IteDelData = obj38.gxTpr_Itedeldata_Z;
         Z593IteDelHora = obj38.gxTpr_Itedelhora_Z;
         Z594IteDelUsuId = obj38.gxTpr_Itedelusuid_Z;
         Z595IteDelUsuNome = obj38.gxTpr_Itedelusunome_Z;
         n591IteDelDataHora = (bool)(Convert.ToBoolean(obj38.gxTpr_Itedeldatahora_N));
         n592IteDelData = (bool)(Convert.ToBoolean(obj38.gxTpr_Itedeldata_N));
         n593IteDelHora = (bool)(Convert.ToBoolean(obj38.gxTpr_Itedelhora_N));
         n594IteDelUsuId = (bool)(Convert.ToBoolean(obj38.gxTpr_Itedelusuid_N));
         n595IteDelUsuNome = (bool)(Convert.ToBoolean(obj38.gxTpr_Itedelusunome_N));
         Gx_mode = obj38.gxTpr_Mode;
         return  ;
      }

      public void LoadKey( Object[] obj )
      {
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         A381IteID = (Guid)getParm(obj,0);
         AnyError = 0;
         context.GX_msglist.removeAllItems();
         InitializeNonKey1238( ) ;
         ScanKeyStart1238( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381IteID = A381IteID;
            O590IteDel = A590IteDel;
         }
         ZM1238( -13) ;
         OnLoadActions1238( ) ;
         AddRow1238( ) ;
         ScanKeyEnd1238( ) ;
         if ( RcdFound38 == 0 )
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
         RowToVars38( bccore_Iteracao, 0) ;
         ScanKeyStart1238( ) ;
         if ( RcdFound38 == 0 )
         {
            Gx_mode = "INS";
         }
         else
         {
            Gx_mode = "UPD";
            Z381IteID = A381IteID;
            O590IteDel = A590IteDel;
         }
         ZM1238( -13) ;
         OnLoadActions1238( ) ;
         AddRow1238( ) ;
         ScanKeyEnd1238( ) ;
         if ( RcdFound38 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "");
            AnyError = 1;
         }
         context.GX_msglist = BackMsgLst;
      }

      protected void SaveImpl( )
      {
         nKeyPressed = 1;
         GetKey1238( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            Insert1238( ) ;
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A381IteID != Z381IteID )
               {
                  A381IteID = Z381IteID;
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
                  Update1238( ) ;
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
                  if ( A381IteID != Z381IteID )
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
                        Insert1238( ) ;
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
                        Insert1238( ) ;
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
         RowToVars38( bccore_Iteracao, 1) ;
         SaveImpl( ) ;
         VarsToRow38( bccore_Iteracao) ;
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
         RowToVars38( bccore_Iteracao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1238( ) ;
         AfterTrn( ) ;
         VarsToRow38( bccore_Iteracao) ;
         context.GX_msglist = BackMsgLst;
         return (AnyError==0) ;
      }

      protected void UpdateImpl( )
      {
         if ( IsUpd( ) )
         {
            SaveImpl( ) ;
            VarsToRow38( bccore_Iteracao) ;
         }
         else
         {
            GeneXus.Programs.core.SdtIteracao auxBC = new GeneXus.Programs.core.SdtIteracao(context);
            IGxSilentTrn auxTrn = auxBC.getTransaction();
            auxBC.Load(A381IteID);
            if ( auxTrn.Errors() == 0 )
            {
               auxBC.UpdateDirties(bccore_Iteracao);
               auxBC.Save();
               bccore_Iteracao.Copy((GxSilentTrnSdt)(auxBC));
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
         RowToVars38( bccore_Iteracao, 1) ;
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
         RowToVars38( bccore_Iteracao, 1) ;
         Gx_mode = "INS";
         /* Insert record */
         Insert1238( ) ;
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
               VarsToRow38( bccore_Iteracao) ;
            }
         }
         else
         {
            AfterTrn( ) ;
            VarsToRow38( bccore_Iteracao) ;
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
         RowToVars38( bccore_Iteracao, 0) ;
         nKeyPressed = 3;
         IsConfirmed = 0;
         GetKey1238( ) ;
         if ( RcdFound38 == 1 )
         {
            if ( IsIns( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
               AnyError = 1;
            }
            else if ( A381IteID != Z381IteID )
            {
               A381IteID = Z381IteID;
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
            if ( A381IteID != Z381IteID )
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
         context.RollbackDataStores("core.iteracao_bc",pr_default);
         VarsToRow38( bccore_Iteracao) ;
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
         Gx_mode = bccore_Iteracao.gxTpr_Mode;
         return Gx_mode ;
      }

      public void SetMode( string lMode )
      {
         Gx_mode = lMode;
         bccore_Iteracao.gxTpr_Mode = Gx_mode;
         return  ;
      }

      public void SetSDT( GxSilentTrnSdt sdt ,
                          short sdtToBc )
      {
         if ( sdt != bccore_Iteracao )
         {
            bccore_Iteracao = (GeneXus.Programs.core.SdtIteracao)(sdt);
            if ( StringUtil.StrCmp(bccore_Iteracao.gxTpr_Mode, "") == 0 )
            {
               bccore_Iteracao.gxTpr_Mode = "INS";
            }
            if ( sdtToBc == 1 )
            {
               VarsToRow38( bccore_Iteracao) ;
            }
            else
            {
               RowToVars38( bccore_Iteracao, 1) ;
            }
         }
         else
         {
            if ( StringUtil.StrCmp(bccore_Iteracao.gxTpr_Mode, "") == 0 )
            {
               bccore_Iteracao.gxTpr_Mode = "INS";
            }
         }
         return  ;
      }

      public void ReloadFromSDT( )
      {
         RowToVars38( bccore_Iteracao, 1) ;
         return  ;
      }

      public void ForceCommitOnExit( )
      {
         mustCommit = true;
         return  ;
      }

      public SdtIteracao Iteracao_BC
      {
         get {
            return bccore_Iteracao ;
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
            return "iteracao_Execute" ;
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
         Z381IteID = Guid.Empty;
         A381IteID = Guid.Empty;
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Z591IteDelDataHora = (DateTime)(DateTime.MinValue);
         A591IteDelDataHora = (DateTime)(DateTime.MinValue);
         Z592IteDelData = (DateTime)(DateTime.MinValue);
         A592IteDelData = (DateTime)(DateTime.MinValue);
         Z593IteDelHora = (DateTime)(DateTime.MinValue);
         A593IteDelHora = (DateTime)(DateTime.MinValue);
         Z594IteDelUsuId = "";
         A594IteDelUsuId = "";
         Z595IteDelUsuNome = "";
         A595IteDelUsuNome = "";
         Z383IteNome = "";
         A383IteNome = "";
         BC00126_A381IteID = new Guid[] {Guid.Empty} ;
         BC00126_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00126_n591IteDelDataHora = new bool[] {false} ;
         BC00126_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         BC00126_n592IteDelData = new bool[] {false} ;
         BC00126_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00126_n593IteDelHora = new bool[] {false} ;
         BC00126_A594IteDelUsuId = new string[] {""} ;
         BC00126_n594IteDelUsuId = new bool[] {false} ;
         BC00126_A595IteDelUsuNome = new string[] {""} ;
         BC00126_n595IteDelUsuNome = new bool[] {false} ;
         BC00126_A382IteOrdem = new int[1] ;
         BC00126_A383IteNome = new string[] {""} ;
         BC00126_A384IteAtivo = new bool[] {false} ;
         BC00126_A590IteDel = new bool[] {false} ;
         BC00125_A431IteTotalOportunidades = new decimal[1] ;
         BC00125_A432IteQtdeOportunidades = new int[1] ;
         BC00127_A382IteOrdem = new int[1] ;
         BC00128_A381IteID = new Guid[] {Guid.Empty} ;
         BC00123_A381IteID = new Guid[] {Guid.Empty} ;
         BC00123_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00123_n591IteDelDataHora = new bool[] {false} ;
         BC00123_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         BC00123_n592IteDelData = new bool[] {false} ;
         BC00123_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00123_n593IteDelHora = new bool[] {false} ;
         BC00123_A594IteDelUsuId = new string[] {""} ;
         BC00123_n594IteDelUsuId = new bool[] {false} ;
         BC00123_A595IteDelUsuNome = new string[] {""} ;
         BC00123_n595IteDelUsuNome = new bool[] {false} ;
         BC00123_A382IteOrdem = new int[1] ;
         BC00123_A383IteNome = new string[] {""} ;
         BC00123_A384IteAtivo = new bool[] {false} ;
         BC00123_A590IteDel = new bool[] {false} ;
         sMode38 = "";
         BC00122_A381IteID = new Guid[] {Guid.Empty} ;
         BC00122_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC00122_n591IteDelDataHora = new bool[] {false} ;
         BC00122_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         BC00122_n592IteDelData = new bool[] {false} ;
         BC00122_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         BC00122_n593IteDelHora = new bool[] {false} ;
         BC00122_A594IteDelUsuId = new string[] {""} ;
         BC00122_n594IteDelUsuId = new bool[] {false} ;
         BC00122_A595IteDelUsuNome = new string[] {""} ;
         BC00122_n595IteDelUsuNome = new bool[] {false} ;
         BC00122_A382IteOrdem = new int[1] ;
         BC00122_A383IteNome = new string[] {""} ;
         BC00122_A384IteAtivo = new bool[] {false} ;
         BC00122_A590IteDel = new bool[] {false} ;
         BC001213_A431IteTotalOportunidades = new decimal[1] ;
         BC001213_A432IteQtdeOportunidades = new int[1] ;
         BC001214_A345NegID = new Guid[] {Guid.Empty} ;
         BC001214_A387NgfSeq = new int[1] ;
         BC001215_A381IteID = new Guid[] {Guid.Empty} ;
         BC001215_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         BC001215_n591IteDelDataHora = new bool[] {false} ;
         BC001215_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         BC001215_n592IteDelData = new bool[] {false} ;
         BC001215_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         BC001215_n593IteDelHora = new bool[] {false} ;
         BC001215_A594IteDelUsuId = new string[] {""} ;
         BC001215_n594IteDelUsuId = new bool[] {false} ;
         BC001215_A595IteDelUsuNome = new string[] {""} ;
         BC001215_n595IteDelUsuNome = new bool[] {false} ;
         BC001215_A382IteOrdem = new int[1] ;
         BC001215_A383IteNome = new string[] {""} ;
         BC001215_A384IteAtivo = new bool[] {false} ;
         BC001215_A590IteDel = new bool[] {false} ;
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.iteracao_bc__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.iteracao_bc__default(),
            new Object[][] {
                new Object[] {
               BC00122_A381IteID, BC00122_A591IteDelDataHora, BC00122_n591IteDelDataHora, BC00122_A592IteDelData, BC00122_n592IteDelData, BC00122_A593IteDelHora, BC00122_n593IteDelHora, BC00122_A594IteDelUsuId, BC00122_n594IteDelUsuId, BC00122_A595IteDelUsuNome,
               BC00122_n595IteDelUsuNome, BC00122_A382IteOrdem, BC00122_A383IteNome, BC00122_A384IteAtivo, BC00122_A590IteDel
               }
               , new Object[] {
               BC00123_A381IteID, BC00123_A591IteDelDataHora, BC00123_n591IteDelDataHora, BC00123_A592IteDelData, BC00123_n592IteDelData, BC00123_A593IteDelHora, BC00123_n593IteDelHora, BC00123_A594IteDelUsuId, BC00123_n594IteDelUsuId, BC00123_A595IteDelUsuNome,
               BC00123_n595IteDelUsuNome, BC00123_A382IteOrdem, BC00123_A383IteNome, BC00123_A384IteAtivo, BC00123_A590IteDel
               }
               , new Object[] {
               BC00125_A431IteTotalOportunidades, BC00125_A432IteQtdeOportunidades
               }
               , new Object[] {
               BC00126_A381IteID, BC00126_A591IteDelDataHora, BC00126_n591IteDelDataHora, BC00126_A592IteDelData, BC00126_n592IteDelData, BC00126_A593IteDelHora, BC00126_n593IteDelHora, BC00126_A594IteDelUsuId, BC00126_n594IteDelUsuId, BC00126_A595IteDelUsuNome,
               BC00126_n595IteDelUsuNome, BC00126_A382IteOrdem, BC00126_A383IteNome, BC00126_A384IteAtivo, BC00126_A590IteDel
               }
               , new Object[] {
               BC00127_A382IteOrdem
               }
               , new Object[] {
               BC00128_A381IteID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               BC001213_A431IteTotalOportunidades, BC001213_A432IteQtdeOportunidades
               }
               , new Object[] {
               BC001214_A345NegID, BC001214_A387NgfSeq
               }
               , new Object[] {
               BC001215_A381IteID, BC001215_A591IteDelDataHora, BC001215_n591IteDelDataHora, BC001215_A592IteDelData, BC001215_n592IteDelData, BC001215_A593IteDelHora, BC001215_n593IteDelHora, BC001215_A594IteDelUsuId, BC001215_n594IteDelUsuId, BC001215_A595IteDelUsuNome,
               BC001215_n595IteDelUsuNome, BC001215_A382IteOrdem, BC001215_A383IteNome, BC001215_A384IteAtivo, BC001215_A590IteDel
               }
            }
         );
         Z384IteAtivo = true;
         A384IteAtivo = true;
         i384IteAtivo = true;
         AV14Pgmname = "core.Iteracao_BC";
         INITTRN();
         /* Execute Start event if defined. */
         /* Execute user event: Start */
         E12122 ();
         standaloneNotModal( ) ;
      }

      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short RcdFound38 ;
      private short nIsDirty_38 ;
      private int trnEnded ;
      private int Z382IteOrdem ;
      private int A382IteOrdem ;
      private int Z432IteQtdeOportunidades ;
      private int A432IteQtdeOportunidades ;
      private decimal Z431IteTotalOportunidades ;
      private decimal A431IteTotalOportunidades ;
      private string scmdbuf ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string Gx_mode ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string AV14Pgmname ;
      private string Z594IteDelUsuId ;
      private string A594IteDelUsuId ;
      private string sMode38 ;
      private DateTime Z591IteDelDataHora ;
      private DateTime A591IteDelDataHora ;
      private DateTime Z592IteDelData ;
      private DateTime A592IteDelData ;
      private DateTime Z593IteDelHora ;
      private DateTime A593IteDelHora ;
      private bool returnInSub ;
      private bool Z384IteAtivo ;
      private bool A384IteAtivo ;
      private bool Z590IteDel ;
      private bool A590IteDel ;
      private bool n591IteDelDataHora ;
      private bool n592IteDelData ;
      private bool n593IteDelHora ;
      private bool n594IteDelUsuId ;
      private bool n595IteDelUsuNome ;
      private bool O590IteDel ;
      private bool Gx_longc ;
      private bool i384IteAtivo ;
      private bool mustCommit ;
      private string Z595IteDelUsuNome ;
      private string A595IteDelUsuNome ;
      private string Z383IteNome ;
      private string A383IteNome ;
      private Guid Z381IteID ;
      private Guid A381IteID ;
      private IGxSession AV12WebSession ;
      private GeneXus.Programs.core.SdtIteracao bccore_Iteracao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] BC00126_A381IteID ;
      private DateTime[] BC00126_A591IteDelDataHora ;
      private bool[] BC00126_n591IteDelDataHora ;
      private DateTime[] BC00126_A592IteDelData ;
      private bool[] BC00126_n592IteDelData ;
      private DateTime[] BC00126_A593IteDelHora ;
      private bool[] BC00126_n593IteDelHora ;
      private string[] BC00126_A594IteDelUsuId ;
      private bool[] BC00126_n594IteDelUsuId ;
      private string[] BC00126_A595IteDelUsuNome ;
      private bool[] BC00126_n595IteDelUsuNome ;
      private int[] BC00126_A382IteOrdem ;
      private string[] BC00126_A383IteNome ;
      private bool[] BC00126_A384IteAtivo ;
      private bool[] BC00126_A590IteDel ;
      private decimal[] BC00125_A431IteTotalOportunidades ;
      private int[] BC00125_A432IteQtdeOportunidades ;
      private int[] BC00127_A382IteOrdem ;
      private Guid[] BC00128_A381IteID ;
      private Guid[] BC00123_A381IteID ;
      private DateTime[] BC00123_A591IteDelDataHora ;
      private bool[] BC00123_n591IteDelDataHora ;
      private DateTime[] BC00123_A592IteDelData ;
      private bool[] BC00123_n592IteDelData ;
      private DateTime[] BC00123_A593IteDelHora ;
      private bool[] BC00123_n593IteDelHora ;
      private string[] BC00123_A594IteDelUsuId ;
      private bool[] BC00123_n594IteDelUsuId ;
      private string[] BC00123_A595IteDelUsuNome ;
      private bool[] BC00123_n595IteDelUsuNome ;
      private int[] BC00123_A382IteOrdem ;
      private string[] BC00123_A383IteNome ;
      private bool[] BC00123_A384IteAtivo ;
      private bool[] BC00123_A590IteDel ;
      private Guid[] BC00122_A381IteID ;
      private DateTime[] BC00122_A591IteDelDataHora ;
      private bool[] BC00122_n591IteDelDataHora ;
      private DateTime[] BC00122_A592IteDelData ;
      private bool[] BC00122_n592IteDelData ;
      private DateTime[] BC00122_A593IteDelHora ;
      private bool[] BC00122_n593IteDelHora ;
      private string[] BC00122_A594IteDelUsuId ;
      private bool[] BC00122_n594IteDelUsuId ;
      private string[] BC00122_A595IteDelUsuNome ;
      private bool[] BC00122_n595IteDelUsuNome ;
      private int[] BC00122_A382IteOrdem ;
      private string[] BC00122_A383IteNome ;
      private bool[] BC00122_A384IteAtivo ;
      private bool[] BC00122_A590IteDel ;
      private decimal[] BC001213_A431IteTotalOportunidades ;
      private int[] BC001213_A432IteQtdeOportunidades ;
      private Guid[] BC001214_A345NegID ;
      private int[] BC001214_A387NgfSeq ;
      private Guid[] BC001215_A381IteID ;
      private DateTime[] BC001215_A591IteDelDataHora ;
      private bool[] BC001215_n591IteDelDataHora ;
      private DateTime[] BC001215_A592IteDelData ;
      private bool[] BC001215_n592IteDelData ;
      private DateTime[] BC001215_A593IteDelHora ;
      private bool[] BC001215_n593IteDelHora ;
      private string[] BC001215_A594IteDelUsuId ;
      private bool[] BC001215_n594IteDelUsuId ;
      private string[] BC001215_A595IteDelUsuNome ;
      private bool[] BC001215_n595IteDelUsuNome ;
      private int[] BC001215_A382IteOrdem ;
      private string[] BC001215_A383IteNome ;
      private bool[] BC001215_A384IteAtivo ;
      private bool[] BC001215_A590IteDel ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class iteracao_bc__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class iteracao_bc__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmBC00126;
        prmBC00126 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00125;
        prmBC00125 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00127;
        prmBC00127 = new Object[] {
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00128;
        prmBC00128 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00123;
        prmBC00123 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00122;
        prmBC00122 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC00129;
        prmBC00129 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IteDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("IteDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("IteDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("IteDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("IteDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteNome",GXType.VarChar,80,0) ,
        new ParDef("IteAtivo",GXType.Boolean,4,0) ,
        new ParDef("IteDel",GXType.Boolean,4,0)
        };
        Object[] prmBC001210;
        prmBC001210 = new Object[] {
        new ParDef("IteDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("IteDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("IteDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("IteDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("IteDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteNome",GXType.VarChar,80,0) ,
        new ParDef("IteAtivo",GXType.Boolean,4,0) ,
        new ParDef("IteDel",GXType.Boolean,4,0) ,
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001211;
        prmBC001211 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001213;
        prmBC001213 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001214;
        prmBC001214 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmBC001215;
        prmBC001215 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("BC00122", "SELECT IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel FROM tb_Iteracao WHERE IteID = :IteID  FOR UPDATE OF tb_Iteracao",true, GxErrorMask.GX_NOMASK, false, this,prmBC00122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00123", "SELECT IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel FROM tb_Iteracao WHERE IteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00123,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00125", "SELECT COALESCE( T1.IteTotalOportunidades, 0) AS IteTotalOportunidades, COALESCE( T1.IteQtdeOportunidades, 0) AS IteQtdeOportunidades FROM (SELECT SUM(NegValorAtualizado) AS IteTotalOportunidades, COUNT(*) AS IteQtdeOportunidades FROM tb_negociopj WHERE NegUltIteID = :IteID ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00125,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00126", "SELECT TM1.IteID, TM1.IteDelDataHora, TM1.IteDelData, TM1.IteDelHora, TM1.IteDelUsuId, TM1.IteDelUsuNome, TM1.IteOrdem, TM1.IteNome, TM1.IteAtivo, TM1.IteDel FROM tb_Iteracao TM1 WHERE TM1.IteID = :IteID ORDER BY TM1.IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00126,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00127", "SELECT IteOrdem FROM tb_Iteracao WHERE (IteOrdem = :IteOrdem) AND (Not ( IteID = :IteID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00127,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00128", "SELECT IteID FROM tb_Iteracao WHERE IteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC00128,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC00129", "SAVEPOINT gxupdate;INSERT INTO tb_Iteracao(IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel) VALUES(:IteID, :IteDelDataHora, :IteDelData, :IteDelHora, :IteDelUsuId, :IteDelUsuNome, :IteOrdem, :IteNome, :IteAtivo, :IteDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmBC00129)
           ,new CursorDef("BC001210", "SAVEPOINT gxupdate;UPDATE tb_Iteracao SET IteDelDataHora=:IteDelDataHora, IteDelData=:IteDelData, IteDelHora=:IteDelHora, IteDelUsuId=:IteDelUsuId, IteDelUsuNome=:IteDelUsuNome, IteOrdem=:IteOrdem, IteNome=:IteNome, IteAtivo=:IteAtivo, IteDel=:IteDel  WHERE IteID = :IteID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001210)
           ,new CursorDef("BC001211", "SAVEPOINT gxupdate;DELETE FROM tb_Iteracao  WHERE IteID = :IteID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmBC001211)
           ,new CursorDef("BC001213", "SELECT COALESCE( T1.IteTotalOportunidades, 0) AS IteTotalOportunidades, COALESCE( T1.IteQtdeOportunidades, 0) AS IteQtdeOportunidades FROM (SELECT SUM(NegValorAtualizado) AS IteTotalOportunidades, COUNT(*) AS IteQtdeOportunidades FROM tb_negociopj WHERE NegUltIteID = :IteID ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001213,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("BC001214", "SELECT NegID, NgfSeq FROM tb_negociopj_fase WHERE NgfIteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001214,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("BC001215", "SELECT TM1.IteID, TM1.IteDelDataHora, TM1.IteDelData, TM1.IteDelHora, TM1.IteDelUsuId, TM1.IteDelUsuNome, TM1.IteOrdem, TM1.IteNome, TM1.IteAtivo, TM1.IteDel FROM tb_Iteracao TM1 WHERE TM1.IteID = :IteID ORDER BY TM1.IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmBC001215,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
     }
  }

}

}
