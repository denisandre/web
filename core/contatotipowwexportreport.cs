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
   public class contatotipowwexportreport : GXWebProcedure
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

      public contatotipowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contatotipowwexportreport( IGxContext context )
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
         contatotipowwexportreport objcontatotipowwexportreport;
         objcontatotipowwexportreport = new contatotipowwexportreport();
         objcontatotipowwexportreport.context.SetSubmitInitialConfig(context);
         objcontatotipowwexportreport.initialize();
         Submit( executePrivateCatch,objcontatotipowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((contatotipowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("ContatoTipoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "contatotipoww_Execute", out  GXt_boolean1) ;
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
               AV50Title = "Lista de Tipo de Contato";
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
            H3W0( true, 0) ;
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
         if ( ! (false==AV66CotDel_Filtro) )
         {
            H3W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV66CotDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H3W0( false, 20) ;
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
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "COTNOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV57CotNome1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57CotNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV59CotNome = AV57CotNome1;
                  H3W0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FilterCotNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59CotNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "COTNOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV60CotNome2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60CotNome2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV59CotNome = AV60CotNome2;
                     H3W0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FilterCotNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59CotNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "COTNOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV61CotNome3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61CotNome3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV58FilterCotNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV59CotNome = AV61CotNome3;
                        H3W0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58FilterCotNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59CotNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCotSigla_Sel)) )
         {
            AV39TempBoolean = (bool)(((StringUtil.StrCmp(AV63TFCotSigla_Sel, "<#Empty#>")==0)));
            AV63TFCotSigla_Sel = (AV39TempBoolean ? "(Vazio)" : AV63TFCotSigla_Sel);
            H3W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFCotSigla_Sel, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV63TFCotSigla_Sel = (AV39TempBoolean ? "<#Empty#>" : AV63TFCotSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFCotSigla)) )
            {
               H3W0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFCotSigla, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCotNome_Sel)) )
         {
            AV39TempBoolean = (bool)(((StringUtil.StrCmp(AV65TFCotNome_Sel, "<#Empty#>")==0)));
            AV65TFCotNome_Sel = (AV39TempBoolean ? "(Vazio)" : AV65TFCotNome_Sel);
            H3W0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFCotNome_Sel, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV65TFCotNome_Sel = (AV39TempBoolean ? "<#Empty#>" : AV65TFCotNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCotNome)) )
            {
               H3W0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFCotNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3W0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3W0( false, 37) ;
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
         AV70Core_contatotipowwds_1_cotdel_filtro = AV66CotDel_Filtro;
         AV71Core_contatotipowwds_2_filterfulltext = AV13FilterFullText;
         AV72Core_contatotipowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV73Core_contatotipowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV74Core_contatotipowwds_5_cotnome1 = AV57CotNome1;
         AV75Core_contatotipowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV76Core_contatotipowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV77Core_contatotipowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV78Core_contatotipowwds_9_cotnome2 = AV60CotNome2;
         AV79Core_contatotipowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV80Core_contatotipowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV81Core_contatotipowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV82Core_contatotipowwds_13_cotnome3 = AV61CotNome3;
         AV83Core_contatotipowwds_14_tfcotsigla = AV62TFCotSigla;
         AV84Core_contatotipowwds_15_tfcotsigla_sel = AV63TFCotSigla_Sel;
         AV85Core_contatotipowwds_16_tfcotnome = AV64TFCotNome;
         AV86Core_contatotipowwds_17_tfcotnome_sel = AV65TFCotNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV71Core_contatotipowwds_2_filterfulltext ,
                                              AV72Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                              AV73Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                              AV74Core_contatotipowwds_5_cotnome1 ,
                                              AV75Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                              AV76Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                              AV77Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                              AV78Core_contatotipowwds_9_cotnome2 ,
                                              AV79Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                              AV80Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                              AV81Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                              AV82Core_contatotipowwds_13_cotnome3 ,
                                              AV84Core_contatotipowwds_15_tfcotsigla_sel ,
                                              AV83Core_contatotipowwds_14_tfcotsigla ,
                                              AV86Core_contatotipowwds_17_tfcotnome_sel ,
                                              AV85Core_contatotipowwds_16_tfcotnome ,
                                              A150CotSigla ,
                                              A151CotNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A566CotDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV71Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_contatotipowwds_2_filterfulltext), "%", "");
         lV71Core_contatotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_contatotipowwds_2_filterfulltext), "%", "");
         lV74Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV74Core_contatotipowwds_5_cotnome1), "%", "");
         lV74Core_contatotipowwds_5_cotnome1 = StringUtil.Concat( StringUtil.RTrim( AV74Core_contatotipowwds_5_cotnome1), "%", "");
         lV78Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV78Core_contatotipowwds_9_cotnome2), "%", "");
         lV78Core_contatotipowwds_9_cotnome2 = StringUtil.Concat( StringUtil.RTrim( AV78Core_contatotipowwds_9_cotnome2), "%", "");
         lV82Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV82Core_contatotipowwds_13_cotnome3), "%", "");
         lV82Core_contatotipowwds_13_cotnome3 = StringUtil.Concat( StringUtil.RTrim( AV82Core_contatotipowwds_13_cotnome3), "%", "");
         lV83Core_contatotipowwds_14_tfcotsigla = StringUtil.Concat( StringUtil.RTrim( AV83Core_contatotipowwds_14_tfcotsigla), "%", "");
         lV85Core_contatotipowwds_16_tfcotnome = StringUtil.Concat( StringUtil.RTrim( AV85Core_contatotipowwds_16_tfcotnome), "%", "");
         /* Using cursor P003W2 */
         pr_default.execute(0, new Object[] {lV71Core_contatotipowwds_2_filterfulltext, lV71Core_contatotipowwds_2_filterfulltext, lV74Core_contatotipowwds_5_cotnome1, lV74Core_contatotipowwds_5_cotnome1, lV78Core_contatotipowwds_9_cotnome2, lV78Core_contatotipowwds_9_cotnome2, lV82Core_contatotipowwds_13_cotnome3, lV82Core_contatotipowwds_13_cotnome3, lV83Core_contatotipowwds_14_tfcotsigla, AV84Core_contatotipowwds_15_tfcotsigla_sel, lV85Core_contatotipowwds_16_tfcotnome, AV86Core_contatotipowwds_17_tfcotnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A151CotNome = P003W2_A151CotNome[0];
            A150CotSigla = P003W2_A150CotSigla[0];
            A566CotDel = P003W2_A566CotDel[0];
            A149CotID = P003W2_A149CotID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3W0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A150CotSigla, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A151CotNome, "@!")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.ContatoTipoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ContatoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.ContatoTipoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV87GXV1 = 1;
         while ( AV87GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV87GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "COTDEL_FILTRO") == 0 )
            {
               AV66CotDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTSIGLA") == 0 )
            {
               AV62TFCotSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTSIGLA_SEL") == 0 )
            {
               AV63TFCotSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTNOME") == 0 )
            {
               AV64TFCotNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFCOTNOME_SEL") == 0 )
            {
               AV65TFCotNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV87GXV1 = (int)(AV87GXV1+1);
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

      protected void H3W0( bool bFoot ,
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
                  AV48PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV45DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV43AppName = "DVelop Software Solutions";
               AV49Phone = "+1 550 8923";
               AV47Mail = "info@mail.com";
               AV51Website = "http://www.web.com";
               AV40AddressLine1 = "French Boulevard 2859";
               AV41AddressLine2 = "Downtown";
               AV42AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV50Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV57CotNome1 = "";
         AV58FilterCotNomeDescription = "";
         AV59CotNome = "";
         AV20DynamicFiltersSelector2 = "";
         AV60CotNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV61CotNome3 = "";
         AV63TFCotSigla_Sel = "";
         AV62TFCotSigla = "";
         AV65TFCotNome_Sel = "";
         AV64TFCotNome = "";
         AV71Core_contatotipowwds_2_filterfulltext = "";
         AV72Core_contatotipowwds_3_dynamicfiltersselector1 = "";
         AV74Core_contatotipowwds_5_cotnome1 = "";
         AV76Core_contatotipowwds_7_dynamicfiltersselector2 = "";
         AV78Core_contatotipowwds_9_cotnome2 = "";
         AV80Core_contatotipowwds_11_dynamicfiltersselector3 = "";
         AV82Core_contatotipowwds_13_cotnome3 = "";
         AV83Core_contatotipowwds_14_tfcotsigla = "";
         AV84Core_contatotipowwds_15_tfcotsigla_sel = "";
         AV85Core_contatotipowwds_16_tfcotnome = "";
         AV86Core_contatotipowwds_17_tfcotnome_sel = "";
         scmdbuf = "";
         lV71Core_contatotipowwds_2_filterfulltext = "";
         lV74Core_contatotipowwds_5_cotnome1 = "";
         lV78Core_contatotipowwds_9_cotnome2 = "";
         lV82Core_contatotipowwds_13_cotnome3 = "";
         lV83Core_contatotipowwds_14_tfcotsigla = "";
         lV85Core_contatotipowwds_16_tfcotnome = "";
         A150CotSigla = "";
         A151CotNome = "";
         P003W2_A151CotNome = new string[] {""} ;
         P003W2_A150CotSigla = new string[] {""} ;
         P003W2_A566CotDel = new bool[] {false} ;
         P003W2_A149CotID = new int[1] ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV48PageInfo = "";
         AV45DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV43AppName = "";
         AV49Phone = "";
         AV47Mail = "";
         AV51Website = "";
         AV40AddressLine1 = "";
         AV41AddressLine2 = "";
         AV42AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003W2_A151CotNome, P003W2_A150CotSigla, P003W2_A566CotDel, P003W2_A149CotID
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
      private short AV73Core_contatotipowwds_4_dynamicfiltersoperator1 ;
      private short AV77Core_contatotipowwds_8_dynamicfiltersoperator2 ;
      private short AV81Core_contatotipowwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A149CotID ;
      private int AV87GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV66CotDel_Filtro ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV39TempBoolean ;
      private bool AV70Core_contatotipowwds_1_cotdel_filtro ;
      private bool AV75Core_contatotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV79Core_contatotipowwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A566CotDel ;
      private string AV50Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV57CotNome1 ;
      private string AV58FilterCotNomeDescription ;
      private string AV59CotNome ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV60CotNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV61CotNome3 ;
      private string AV63TFCotSigla_Sel ;
      private string AV62TFCotSigla ;
      private string AV65TFCotNome_Sel ;
      private string AV64TFCotNome ;
      private string AV71Core_contatotipowwds_2_filterfulltext ;
      private string AV72Core_contatotipowwds_3_dynamicfiltersselector1 ;
      private string AV74Core_contatotipowwds_5_cotnome1 ;
      private string AV76Core_contatotipowwds_7_dynamicfiltersselector2 ;
      private string AV78Core_contatotipowwds_9_cotnome2 ;
      private string AV80Core_contatotipowwds_11_dynamicfiltersselector3 ;
      private string AV82Core_contatotipowwds_13_cotnome3 ;
      private string AV83Core_contatotipowwds_14_tfcotsigla ;
      private string AV84Core_contatotipowwds_15_tfcotsigla_sel ;
      private string AV85Core_contatotipowwds_16_tfcotnome ;
      private string AV86Core_contatotipowwds_17_tfcotnome_sel ;
      private string lV71Core_contatotipowwds_2_filterfulltext ;
      private string lV74Core_contatotipowwds_5_cotnome1 ;
      private string lV78Core_contatotipowwds_9_cotnome2 ;
      private string lV82Core_contatotipowwds_13_cotnome3 ;
      private string lV83Core_contatotipowwds_14_tfcotsigla ;
      private string lV85Core_contatotipowwds_16_tfcotnome ;
      private string A150CotSigla ;
      private string A151CotNome ;
      private string AV48PageInfo ;
      private string AV45DateInfo ;
      private string AV43AppName ;
      private string AV49Phone ;
      private string AV47Mail ;
      private string AV51Website ;
      private string AV40AddressLine1 ;
      private string AV41AddressLine2 ;
      private string AV42AddressLine3 ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P003W2_A151CotNome ;
      private string[] P003W2_A150CotSigla ;
      private bool[] P003W2_A566CotDel ;
      private int[] P003W2_A149CotID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class contatotipowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003W2( IGxContext context ,
                                             string AV71Core_contatotipowwds_2_filterfulltext ,
                                             string AV72Core_contatotipowwds_3_dynamicfiltersselector1 ,
                                             short AV73Core_contatotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV74Core_contatotipowwds_5_cotnome1 ,
                                             bool AV75Core_contatotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV76Core_contatotipowwds_7_dynamicfiltersselector2 ,
                                             short AV77Core_contatotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV78Core_contatotipowwds_9_cotnome2 ,
                                             bool AV79Core_contatotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV80Core_contatotipowwds_11_dynamicfiltersselector3 ,
                                             short AV81Core_contatotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV82Core_contatotipowwds_13_cotnome3 ,
                                             string AV84Core_contatotipowwds_15_tfcotsigla_sel ,
                                             string AV83Core_contatotipowwds_14_tfcotsigla ,
                                             string AV86Core_contatotipowwds_17_tfcotnome_sel ,
                                             string AV85Core_contatotipowwds_16_tfcotnome ,
                                             string A150CotSigla ,
                                             string A151CotNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A566CotDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT CotNome, CotSigla, CotDel, CotID FROM tb_contatotipo";
         AddWhere(sWhereString, "(Not CotDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_contatotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CotSigla like '%' || :lV71Core_contatotipowwds_2_filterfulltext) or ( CotNome like '%' || :lV71Core_contatotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV73Core_contatotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV74Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV72Core_contatotipowwds_3_dynamicfiltersselector1, "COTNOME") == 0 ) && ( AV73Core_contatotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_contatotipowwds_5_cotnome1)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV74Core_contatotipowwds_5_cotnome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV75Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV77Core_contatotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV78Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV75Core_contatotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV76Core_contatotipowwds_7_dynamicfiltersselector2, "COTNOME") == 0 ) && ( AV77Core_contatotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_contatotipowwds_9_cotnome2)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV78Core_contatotipowwds_9_cotnome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV79Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV81Core_contatotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV82Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV79Core_contatotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV80Core_contatotipowwds_11_dynamicfiltersselector3, "COTNOME") == 0 ) && ( AV81Core_contatotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_contatotipowwds_13_cotnome3)) ) )
         {
            AddWhere(sWhereString, "(CotNome like '%' || :lV82Core_contatotipowwds_13_cotnome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_contatotipowwds_15_tfcotsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83Core_contatotipowwds_14_tfcotsigla)) ) )
         {
            AddWhere(sWhereString, "(CotSigla like :lV83Core_contatotipowwds_14_tfcotsigla)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84Core_contatotipowwds_15_tfcotsigla_sel)) && ! ( StringUtil.StrCmp(AV84Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotSigla = ( :AV84Core_contatotipowwds_15_tfcotsigla_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV84Core_contatotipowwds_15_tfcotsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV86Core_contatotipowwds_17_tfcotnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_contatotipowwds_16_tfcotnome)) ) )
         {
            AddWhere(sWhereString, "(CotNome like :lV85Core_contatotipowwds_16_tfcotnome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV86Core_contatotipowwds_17_tfcotnome_sel)) && ! ( StringUtil.StrCmp(AV86Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CotNome = ( :AV86Core_contatotipowwds_17_tfcotnome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV86Core_contatotipowwds_17_tfcotnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CotNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CotNome";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CotNome DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CotSigla";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CotSigla DESC";
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
                     return conditional_P003W2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP003W2;
          prmP003W2 = new Object[] {
          new ParDef("lV71Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_contatotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV74Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV74Core_contatotipowwds_5_cotnome1",GXType.VarChar,80,0) ,
          new ParDef("lV78Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV78Core_contatotipowwds_9_cotnome2",GXType.VarChar,80,0) ,
          new ParDef("lV82Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV82Core_contatotipowwds_13_cotnome3",GXType.VarChar,80,0) ,
          new ParDef("lV83Core_contatotipowwds_14_tfcotsigla",GXType.VarChar,20,0) ,
          new ParDef("AV84Core_contatotipowwds_15_tfcotsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV85Core_contatotipowwds_16_tfcotnome",GXType.VarChar,80,0) ,
          new ParDef("AV86Core_contatotipowwds_17_tfcotnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003W2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003W2,100, GxCacheFrequency.OFF ,true,false )
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
