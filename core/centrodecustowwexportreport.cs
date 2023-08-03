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
using GeneXus.Procedure;
using GeneXus.Printer;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class centrodecustowwexportreport : GXWebProcedure
   {
      public override void webExecute( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         initialize();
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
         }
         if ( GxWebError == 0 )
         {
            executePrivate();
         }
         cleanup();
      }

      public centrodecustowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrodecustowwexportreport( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         initialize();
         executePrivate();
      }

      public void executeSubmit( )
      {
         centrodecustowwexportreport objcentrodecustowwexportreport;
         objcentrodecustowwexportreport = new centrodecustowwexportreport();
         objcentrodecustowwexportreport.context.SetSubmitInitialConfig(context);
         objcentrodecustowwexportreport.initialize();
         Submit( executePrivateCatch,objcentrodecustowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((centrodecustowwexportreport)stateInfo).executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         M_top = 0;
         M_bot = 6;
         P_lines = (int)(66-M_bot);
         getPrinter().GxClearAttris() ;
         add_metrics( ) ;
         lineHeight = 15;
         PrtOffset = 0;
         gxXPage = 100;
         gxYPage = 100;
         setOutputFileName("CentroDeCustoWWExportReport");
         setOutputType("PDF");
         try
         {
            Gx_out = "FIL" ;
            if (!initPrinter (Gx_out, gxXPage, gxYPage, "GXPRN.INI", "", "", 2, 1, 1, 15840, 12240, 0, 1, 1, 0, 1, 1) )
            {
               cleanup();
               return;
            }
            getPrinter().setModal(false) ;
            P_lines = (int)(gxYPage-(lineHeight*6));
            Gx_line = (int)(P_lines+1);
            getPrinter().setPageLines(P_lines);
            getPrinter().setLineHeight(lineHeight);
            getPrinter().setM_top(M_top);
            getPrinter().setM_bot(M_bot);
            GXt_boolean1 = AV8IsAuthorized;
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "centrodecustoww_Execute", out  GXt_boolean1) ;
            AV8IsAuthorized = GXt_boolean1;
            if ( AV8IsAuthorized )
            {
               new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
               /* Execute user subroutine: 'LOADGRIDSTATE' */
               S151 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               AV47Title = "Lista de Centro De Custo";
               /* Execute user subroutine: 'PRINTFILTERS' */
               S111 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTCOLUMNTITLES' */
               S121 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTDATA' */
               S131 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
               /* Execute user subroutine: 'PRINTFOOTER' */
               S171 ();
               if ( returnInSub )
               {
                  this.cleanup();
                  if (true) return;
               }
            }
            /* Print footer for last page */
            ToSkip = (int)(P_lines+1);
            H4A0( true, 0) ;
         }
         catch ( GeneXus.Printer.ProcessInterruptedException  )
         {
         }
         finally
         {
            /* Close printer file */
            try
            {
               getPrinter().GxEndPage() ;
               getPrinter().GxEndDocument() ;
            }
            catch ( GeneXus.Printer.ProcessInterruptedException  )
            {
            }
            endPrinter();
         }
         if ( context.WillRedirect( ) )
         {
            context.Redirect( context.wjLoc );
            context.wjLoc = "";
         }
         this.cleanup();
      }

      protected void S111( )
      {
         /* 'PRINTFILTERS' Routine */
         returnInSub = false;
         if ( ! (false==AV49CcuDel_Filtro) )
         {
            H4A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV49CcuDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H4A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CCUNOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16CcuNome1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16CcuNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18CcuNome = AV16CcuNome1;
                  H4A0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCcuNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CcuNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CCUNOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22CcuNome2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CcuNome2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18CcuNome = AV22CcuNome2;
                     H4A0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCcuNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CcuNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CCUNOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26CcuNome3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26CcuNome3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterCcuNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18CcuNome = AV26CcuNome3;
                        H4A0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCcuNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CcuNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCcuSigla_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFCcuSigla_Sel, "<#Empty#>")==0)));
            AV33TFCcuSigla_Sel = (AV36TempBoolean ? "(Vazio)" : AV33TFCcuSigla_Sel);
            H4A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFCcuSigla_Sel, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFCcuSigla_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFCcuSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFCcuSigla)) )
            {
               H4A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFCcuSigla, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFCcuNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFCcuNome_Sel, "<#Empty#>")==0)));
            AV35TFCcuNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV35TFCcuNome_Sel);
            H4A0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFCcuNome_Sel, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFCcuNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV35TFCcuNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCcuNome)) )
            {
               H4A0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFCcuNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4A0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4A0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Sigla", 30, Gx_line+10, 406, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 410, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV53Core_centrodecustowwds_1_ccudel_filtro = AV49CcuDel_Filtro;
         AV54Core_centrodecustowwds_2_filterfulltext = AV13FilterFullText;
         AV55Core_centrodecustowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV57Core_centrodecustowwds_5_ccunome1 = AV16CcuNome1;
         AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV59Core_centrodecustowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV61Core_centrodecustowwds_9_ccunome2 = AV22CcuNome2;
         AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV63Core_centrodecustowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV65Core_centrodecustowwds_13_ccunome3 = AV26CcuNome3;
         AV66Core_centrodecustowwds_14_tfccusigla = AV32TFCcuSigla;
         AV67Core_centrodecustowwds_15_tfccusigla_sel = AV33TFCcuSigla_Sel;
         AV68Core_centrodecustowwds_16_tfccunome = AV34TFCcuNome;
         AV69Core_centrodecustowwds_17_tfccunome_sel = AV35TFCcuNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Core_centrodecustowwds_2_filterfulltext ,
                                              AV55Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                              AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                              AV57Core_centrodecustowwds_5_ccunome1 ,
                                              AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                              AV59Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                              AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                              AV61Core_centrodecustowwds_9_ccunome2 ,
                                              AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                              AV63Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                              AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                              AV65Core_centrodecustowwds_13_ccunome3 ,
                                              AV67Core_centrodecustowwds_15_tfccusigla_sel ,
                                              AV66Core_centrodecustowwds_14_tfccusigla ,
                                              AV69Core_centrodecustowwds_17_tfccunome_sel ,
                                              AV68Core_centrodecustowwds_16_tfccunome ,
                                              A209CcuSigla ,
                                              A210CcuNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A512CcuDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV54Core_centrodecustowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_centrodecustowwds_2_filterfulltext), "%", "");
         lV57Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_centrodecustowwds_5_ccunome1), "%", "");
         lV57Core_centrodecustowwds_5_ccunome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_centrodecustowwds_5_ccunome1), "%", "");
         lV61Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_centrodecustowwds_9_ccunome2), "%", "");
         lV61Core_centrodecustowwds_9_ccunome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_centrodecustowwds_9_ccunome2), "%", "");
         lV65Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_centrodecustowwds_13_ccunome3), "%", "");
         lV65Core_centrodecustowwds_13_ccunome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_centrodecustowwds_13_ccunome3), "%", "");
         lV66Core_centrodecustowwds_14_tfccusigla = StringUtil.Concat( StringUtil.RTrim( AV66Core_centrodecustowwds_14_tfccusigla), "%", "");
         lV68Core_centrodecustowwds_16_tfccunome = StringUtil.Concat( StringUtil.RTrim( AV68Core_centrodecustowwds_16_tfccunome), "%", "");
         /* Using cursor P004A2 */
         pr_default.execute(0, new Object[] {lV54Core_centrodecustowwds_2_filterfulltext, lV54Core_centrodecustowwds_2_filterfulltext, lV57Core_centrodecustowwds_5_ccunome1, lV57Core_centrodecustowwds_5_ccunome1, lV61Core_centrodecustowwds_9_ccunome2, lV61Core_centrodecustowwds_9_ccunome2, lV65Core_centrodecustowwds_13_ccunome3, lV65Core_centrodecustowwds_13_ccunome3, lV66Core_centrodecustowwds_14_tfccusigla, AV67Core_centrodecustowwds_15_tfccusigla_sel, lV68Core_centrodecustowwds_16_tfccunome, AV69Core_centrodecustowwds_17_tfccunome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A210CcuNome = P004A2_A210CcuNome[0];
            A209CcuSigla = P004A2_A209CcuSigla[0];
            A512CcuDel = P004A2_A512CcuDel[0];
            A208CcuID = P004A2_A208CcuID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4A0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A209CcuSigla, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A210CcuNome, "@!")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+35, 789, Gx_line+35, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+36);
            /* Execute user subroutine: 'AFTERPRINTLINE' */
            S161 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("core.CentroDeCustoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.CentroDeCustoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.CentroDeCustoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "CCUDEL_FILTRO") == 0 )
            {
               AV49CcuDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCCUSIGLA") == 0 )
            {
               AV32TFCcuSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCCUSIGLA_SEL") == 0 )
            {
               AV33TFCcuSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCCUNOME") == 0 )
            {
               AV34TFCcuNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCCUNOME_SEL") == 0 )
            {
               AV35TFCcuNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV70GXV1 = (int)(AV70GXV1+1);
         }
      }

      protected void S144( )
      {
         /* 'BEFOREPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S161( )
      {
         /* 'AFTERPRINTLINE' Routine */
         returnInSub = false;
      }

      protected void S171( )
      {
         /* 'PRINTFOOTER' Routine */
         returnInSub = false;
      }

      protected void H4A0( bool bFoot ,
                           int Inc )
      {
         /* Skip the required number of lines */
         while ( ( ToSkip > 0 ) || ( Gx_line + Inc > P_lines ) )
         {
            if ( Gx_line + Inc >= P_lines )
            {
               if ( Gx_page > 0 )
               {
                  /* Print footers */
                  Gx_line = P_lines;
                  AV45PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV42DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+40);
                  getPrinter().GxEndPage() ;
                  if ( bFoot )
                  {
                     return  ;
                  }
               }
               ToSkip = 0;
               Gx_line = 0;
               Gx_page = (int)(Gx_page+1);
               /* Skip Margin Top Lines */
               Gx_line = (int)(Gx_line+(M_top*lineHeight));
               /* Print headers */
               getPrinter().GxStartPage() ;
               AV40AppName = "DVelop Software Solutions";
               AV46Phone = "+1 550 8923";
               AV44Mail = "info@mail.com";
               AV48Website = "http://www.web.com";
               AV37AddressLine1 = "French Boulevard 2859";
               AV38AddressLine2 = "Downtown";
               AV39AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+128);
               if (true) break;
            }
            else
            {
               PrtOffset = 0;
               Gx_line = (int)(Gx_line+1);
            }
            ToSkip = (int)(ToSkip-1);
         }
         getPrinter().setPage(Gx_page);
      }

      protected void add_metrics( )
      {
         add_metrics0( ) ;
      }

      protected void add_metrics0( )
      {
         getPrinter().setMetrics("Microsoft Sans Serif", false, false, 58, 14, 72, 171,  new int[] {48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 23, 36, 36, 57, 43, 12, 21, 21, 25, 37, 18, 21, 18, 18, 36, 36, 36, 36, 36, 36, 36, 36, 36, 36, 18, 18, 37, 37, 37, 36, 65, 43, 43, 46, 46, 43, 39, 50, 46, 18, 32, 43, 36, 53, 46, 50, 43, 50, 46, 43, 40, 46, 43, 64, 41, 42, 39, 18, 18, 18, 27, 36, 21, 36, 36, 32, 36, 36, 18, 36, 36, 14, 15, 33, 14, 55, 36, 36, 36, 36, 21, 32, 18, 36, 33, 47, 31, 31, 31, 21, 17, 21, 37, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 48, 18, 20, 36, 36, 36, 36, 17, 36, 21, 47, 24, 36, 37, 21, 47, 35, 26, 35, 21, 21, 21, 37, 34, 21, 21, 21, 23, 36, 53, 53, 53, 39, 43, 43, 43, 43, 43, 43, 64, 46, 43, 43, 43, 43, 18, 18, 18, 18, 46, 46, 50, 50, 50, 50, 50, 37, 50, 46, 46, 46, 46, 43, 43, 39, 36, 36, 36, 36, 36, 36, 57, 32, 36, 36, 36, 36, 18, 18, 18, 18, 36, 36, 36, 36, 36, 36, 36, 35, 39, 36, 36, 36, 36, 32, 36, 32}) ;
      }

      public override int getOutputType( )
      {
         return GxReportUtils.OUTPUT_PDF ;
      }

      public override void cleanup( )
      {
         CloseOpenCursors();
         base.cleanup();
         if ( IsMain )
         {
            context.CloseConnections();
         }
         ExitApp();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         GXKey = "";
         gxfirstwebparm = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV47Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16CcuNome1 = "";
         AV17FilterCcuNomeDescription = "";
         AV18CcuNome = "";
         AV20DynamicFiltersSelector2 = "";
         AV22CcuNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26CcuNome3 = "";
         AV33TFCcuSigla_Sel = "";
         AV32TFCcuSigla = "";
         AV35TFCcuNome_Sel = "";
         AV34TFCcuNome = "";
         AV54Core_centrodecustowwds_2_filterfulltext = "";
         AV55Core_centrodecustowwds_3_dynamicfiltersselector1 = "";
         AV57Core_centrodecustowwds_5_ccunome1 = "";
         AV59Core_centrodecustowwds_7_dynamicfiltersselector2 = "";
         AV61Core_centrodecustowwds_9_ccunome2 = "";
         AV63Core_centrodecustowwds_11_dynamicfiltersselector3 = "";
         AV65Core_centrodecustowwds_13_ccunome3 = "";
         AV66Core_centrodecustowwds_14_tfccusigla = "";
         AV67Core_centrodecustowwds_15_tfccusigla_sel = "";
         AV68Core_centrodecustowwds_16_tfccunome = "";
         AV69Core_centrodecustowwds_17_tfccunome_sel = "";
         scmdbuf = "";
         lV54Core_centrodecustowwds_2_filterfulltext = "";
         lV57Core_centrodecustowwds_5_ccunome1 = "";
         lV61Core_centrodecustowwds_9_ccunome2 = "";
         lV65Core_centrodecustowwds_13_ccunome3 = "";
         lV66Core_centrodecustowwds_14_tfccusigla = "";
         lV68Core_centrodecustowwds_16_tfccunome = "";
         A209CcuSigla = "";
         A210CcuNome = "";
         P004A2_A210CcuNome = new string[] {""} ;
         P004A2_A209CcuSigla = new string[] {""} ;
         P004A2_A512CcuDel = new bool[] {false} ;
         P004A2_A208CcuID = new int[1] ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV45PageInfo = "";
         AV42DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV40AppName = "";
         AV46Phone = "";
         AV44Mail = "";
         AV48Website = "";
         AV37AddressLine1 = "";
         AV38AddressLine2 = "";
         AV39AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecustowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004A2_A210CcuNome, P004A2_A209CcuSigla, P004A2_A512CcuDel, P004A2_A208CcuID
               }
            }
         );
         Gx_date = DateTimeUtil.Today( context);
         /* GeneXus formulas. */
         Gx_line = 0;
         Gx_date = DateTimeUtil.Today( context);
      }

      private short gxcookieaux ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV15DynamicFiltersOperator1 ;
      private short AV21DynamicFiltersOperator2 ;
      private short AV25DynamicFiltersOperator3 ;
      private short AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 ;
      private short AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 ;
      private short AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A208CcuID ;
      private int AV70GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV49CcuDel_Filtro ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV53Core_centrodecustowwds_1_ccudel_filtro ;
      private bool AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 ;
      private bool AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A512CcuDel ;
      private string AV47Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16CcuNome1 ;
      private string AV17FilterCcuNomeDescription ;
      private string AV18CcuNome ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22CcuNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26CcuNome3 ;
      private string AV33TFCcuSigla_Sel ;
      private string AV32TFCcuSigla ;
      private string AV35TFCcuNome_Sel ;
      private string AV34TFCcuNome ;
      private string AV54Core_centrodecustowwds_2_filterfulltext ;
      private string AV55Core_centrodecustowwds_3_dynamicfiltersselector1 ;
      private string AV57Core_centrodecustowwds_5_ccunome1 ;
      private string AV59Core_centrodecustowwds_7_dynamicfiltersselector2 ;
      private string AV61Core_centrodecustowwds_9_ccunome2 ;
      private string AV63Core_centrodecustowwds_11_dynamicfiltersselector3 ;
      private string AV65Core_centrodecustowwds_13_ccunome3 ;
      private string AV66Core_centrodecustowwds_14_tfccusigla ;
      private string AV67Core_centrodecustowwds_15_tfccusigla_sel ;
      private string AV68Core_centrodecustowwds_16_tfccunome ;
      private string AV69Core_centrodecustowwds_17_tfccunome_sel ;
      private string lV54Core_centrodecustowwds_2_filterfulltext ;
      private string lV57Core_centrodecustowwds_5_ccunome1 ;
      private string lV61Core_centrodecustowwds_9_ccunome2 ;
      private string lV65Core_centrodecustowwds_13_ccunome3 ;
      private string lV66Core_centrodecustowwds_14_tfccusigla ;
      private string lV68Core_centrodecustowwds_16_tfccunome ;
      private string A209CcuSigla ;
      private string A210CcuNome ;
      private string AV45PageInfo ;
      private string AV42DateInfo ;
      private string AV40AppName ;
      private string AV46Phone ;
      private string AV44Mail ;
      private string AV48Website ;
      private string AV37AddressLine1 ;
      private string AV38AddressLine2 ;
      private string AV39AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P004A2_A210CcuNome ;
      private string[] P004A2_A209CcuSigla ;
      private bool[] P004A2_A512CcuDel ;
      private int[] P004A2_A208CcuID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class centrodecustowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004A2( IGxContext context ,
                                             string AV54Core_centrodecustowwds_2_filterfulltext ,
                                             string AV55Core_centrodecustowwds_3_dynamicfiltersselector1 ,
                                             short AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 ,
                                             string AV57Core_centrodecustowwds_5_ccunome1 ,
                                             bool AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 ,
                                             string AV59Core_centrodecustowwds_7_dynamicfiltersselector2 ,
                                             short AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 ,
                                             string AV61Core_centrodecustowwds_9_ccunome2 ,
                                             bool AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 ,
                                             string AV63Core_centrodecustowwds_11_dynamicfiltersselector3 ,
                                             short AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 ,
                                             string AV65Core_centrodecustowwds_13_ccunome3 ,
                                             string AV67Core_centrodecustowwds_15_tfccusigla_sel ,
                                             string AV66Core_centrodecustowwds_14_tfccusigla ,
                                             string AV69Core_centrodecustowwds_17_tfccunome_sel ,
                                             string AV68Core_centrodecustowwds_16_tfccunome ,
                                             string A209CcuSigla ,
                                             string A210CcuNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A512CcuDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT CcuNome, CcuSigla, CcuDel, CcuID FROM tb_centrodecusto";
         AddWhere(sWhereString, "(Not CcuDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_centrodecustowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CcuSigla like '%' || :lV54Core_centrodecustowwds_2_filterfulltext) or ( CcuNome like '%' || :lV54Core_centrodecustowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV57Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_centrodecustowwds_3_dynamicfiltersselector1, "CCUNOME") == 0 ) && ( AV56Core_centrodecustowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_centrodecustowwds_5_ccunome1)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV57Core_centrodecustowwds_5_ccunome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV61Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV58Core_centrodecustowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_centrodecustowwds_7_dynamicfiltersselector2, "CCUNOME") == 0 ) && ( AV60Core_centrodecustowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_centrodecustowwds_9_ccunome2)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV61Core_centrodecustowwds_9_ccunome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV65Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV62Core_centrodecustowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_centrodecustowwds_11_dynamicfiltersselector3, "CCUNOME") == 0 ) && ( AV64Core_centrodecustowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_centrodecustowwds_13_ccunome3)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like '%' || :lV65Core_centrodecustowwds_13_ccunome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_centrodecustowwds_15_tfccusigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_centrodecustowwds_14_tfccusigla)) ) )
         {
            AddWhere(sWhereString, "(CcuSigla like :lV66Core_centrodecustowwds_14_tfccusigla)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_centrodecustowwds_15_tfccusigla_sel)) && ! ( StringUtil.StrCmp(AV67Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuSigla = ( :AV67Core_centrodecustowwds_15_tfccusigla_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_centrodecustowwds_15_tfccusigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_centrodecustowwds_17_tfccunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_centrodecustowwds_16_tfccunome)) ) )
         {
            AddWhere(sWhereString, "(CcuNome like :lV68Core_centrodecustowwds_16_tfccunome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_centrodecustowwds_17_tfccunome_sel)) && ! ( StringUtil.StrCmp(AV69Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CcuNome = ( :AV69Core_centrodecustowwds_17_tfccunome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_centrodecustowwds_17_tfccunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CcuNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CcuNome";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CcuNome DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CcuSigla";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CcuSigla DESC";
         }
         GXv_Object3[0] = scmdbuf;
         GXv_Object3[1] = GXv_int2;
         return GXv_Object3 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_P004A2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP004A2;
          prmP004A2 = new Object[] {
          new ParDef("lV54Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Core_centrodecustowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_centrodecustowwds_5_ccunome1",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_centrodecustowwds_9_ccunome2",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_centrodecustowwds_13_ccunome3",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_centrodecustowwds_14_tfccusigla",GXType.VarChar,20,0) ,
          new ParDef("AV67Core_centrodecustowwds_15_tfccusigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_centrodecustowwds_16_tfccunome",GXType.VarChar,80,0) ,
          new ParDef("AV69Core_centrodecustowwds_17_tfccunome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004A2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004A2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.getBool(3);
                ((int[]) buf[3])[0] = rslt.getInt(4);
                return;
       }
    }

 }

}
