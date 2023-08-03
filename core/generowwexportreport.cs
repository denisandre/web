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
   public class generowwexportreport : GXWebProcedure
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

      public generowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public generowwexportreport( IGxContext context )
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
         generowwexportreport objgenerowwexportreport;
         objgenerowwexportreport = new generowwexportreport();
         objgenerowwexportreport.context.SetSubmitInitialConfig(context);
         objgenerowwexportreport.initialize();
         Submit( executePrivateCatch,objgenerowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((generowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("GeneroWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "generoww_Execute", out  GXt_boolean1) ;
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
               AV47Title = "Lista de Genero da Pessoa";
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
            H3Z0( true, 0) ;
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
         if ( ! (false==AV58GenDel_Filtro) )
         {
            H3Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV58GenDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H3Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "GENSIGLA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV49GenSigla1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49GenSigla1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                  }
                  AV51GenSigla = AV49GenSigla1;
                  H3Z0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterGenSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51GenSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "GENSIGLA") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV52GenSigla2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52GenSigla2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                     }
                     AV51GenSigla = AV52GenSigla2;
                     H3Z0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterGenSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51GenSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "GENSIGLA") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV53GenSigla3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53GenSigla3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV50FilterGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                        }
                        AV51GenSigla = AV53GenSigla3;
                        H3Z0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50FilterGenSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51GenSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFGenSigla_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV55TFGenSigla_Sel, "<#Empty#>")==0)));
            AV55TFGenSigla_Sel = (AV36TempBoolean ? "(Vazio)" : AV55TFGenSigla_Sel);
            H3Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFGenSigla_Sel, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV55TFGenSigla_Sel = (AV36TempBoolean ? "<#Empty#>" : AV55TFGenSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFGenSigla)) )
            {
               H3Z0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFGenSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57TFGenNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV57TFGenNome_Sel, "<#Empty#>")==0)));
            AV57TFGenNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV57TFGenNome_Sel);
            H3Z0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57TFGenNome_Sel, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV57TFGenNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV57TFGenNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFGenNome)) )
            {
               H3Z0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFGenNome, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H3Z0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H3Z0( false, 37) ;
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
         AV62Core_generowwds_1_gendel_filtro = AV58GenDel_Filtro;
         AV63Core_generowwds_2_filterfulltext = AV13FilterFullText;
         AV64Core_generowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV65Core_generowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV66Core_generowwds_5_gensigla1 = AV49GenSigla1;
         AV67Core_generowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV68Core_generowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV69Core_generowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV70Core_generowwds_9_gensigla2 = AV52GenSigla2;
         AV71Core_generowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV72Core_generowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV73Core_generowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV74Core_generowwds_13_gensigla3 = AV53GenSigla3;
         AV75Core_generowwds_14_tfgensigla = AV54TFGenSigla;
         AV76Core_generowwds_15_tfgensigla_sel = AV55TFGenSigla_Sel;
         AV77Core_generowwds_16_tfgennome = AV56TFGenNome;
         AV78Core_generowwds_17_tfgennome_sel = AV57TFGenNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV63Core_generowwds_2_filterfulltext ,
                                              AV64Core_generowwds_3_dynamicfiltersselector1 ,
                                              AV65Core_generowwds_4_dynamicfiltersoperator1 ,
                                              AV66Core_generowwds_5_gensigla1 ,
                                              AV67Core_generowwds_6_dynamicfiltersenabled2 ,
                                              AV68Core_generowwds_7_dynamicfiltersselector2 ,
                                              AV69Core_generowwds_8_dynamicfiltersoperator2 ,
                                              AV70Core_generowwds_9_gensigla2 ,
                                              AV71Core_generowwds_10_dynamicfiltersenabled3 ,
                                              AV72Core_generowwds_11_dynamicfiltersselector3 ,
                                              AV73Core_generowwds_12_dynamicfiltersoperator3 ,
                                              AV74Core_generowwds_13_gensigla3 ,
                                              AV76Core_generowwds_15_tfgensigla_sel ,
                                              AV75Core_generowwds_14_tfgensigla ,
                                              AV78Core_generowwds_17_tfgennome_sel ,
                                              AV77Core_generowwds_16_tfgennome ,
                                              A153GenSigla ,
                                              A154GenNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A536GenDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV63Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext), "%", "");
         lV63Core_generowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext), "%", "");
         lV66Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV66Core_generowwds_5_gensigla1), "%", "");
         lV66Core_generowwds_5_gensigla1 = StringUtil.Concat( StringUtil.RTrim( AV66Core_generowwds_5_gensigla1), "%", "");
         lV70Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_generowwds_9_gensigla2), "%", "");
         lV70Core_generowwds_9_gensigla2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_generowwds_9_gensigla2), "%", "");
         lV74Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_13_gensigla3), "%", "");
         lV74Core_generowwds_13_gensigla3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_generowwds_13_gensigla3), "%", "");
         lV75Core_generowwds_14_tfgensigla = StringUtil.Concat( StringUtil.RTrim( AV75Core_generowwds_14_tfgensigla), "%", "");
         lV77Core_generowwds_16_tfgennome = StringUtil.Concat( StringUtil.RTrim( AV77Core_generowwds_16_tfgennome), "%", "");
         /* Using cursor P003Z2 */
         pr_default.execute(0, new Object[] {lV63Core_generowwds_2_filterfulltext, lV63Core_generowwds_2_filterfulltext, lV66Core_generowwds_5_gensigla1, lV66Core_generowwds_5_gensigla1, lV70Core_generowwds_9_gensigla2, lV70Core_generowwds_9_gensigla2, lV74Core_generowwds_13_gensigla3, lV74Core_generowwds_13_gensigla3, lV75Core_generowwds_14_tfgensigla, AV76Core_generowwds_15_tfgensigla_sel, lV77Core_generowwds_16_tfgennome, AV78Core_generowwds_17_tfgennome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A154GenNome = P003Z2_A154GenNome[0];
            A153GenSigla = P003Z2_A153GenSigla[0];
            A536GenDel = P003Z2_A536GenDel[0];
            A152GenID = P003Z2_A152GenID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H3Z0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A153GenSigla, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A154GenNome, "@!")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.GeneroWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.GeneroWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.GeneroWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV79GXV1 = 1;
         while ( AV79GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV79GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "GENDEL_FILTRO") == 0 )
            {
               AV58GenDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFGENSIGLA") == 0 )
            {
               AV54TFGenSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFGENSIGLA_SEL") == 0 )
            {
               AV55TFGenSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFGENNOME") == 0 )
            {
               AV56TFGenNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFGENNOME_SEL") == 0 )
            {
               AV57TFGenNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV79GXV1 = (int)(AV79GXV1+1);
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

      protected void H3Z0( bool bFoot ,
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
         AV49GenSigla1 = "";
         AV50FilterGenSiglaDescription = "";
         AV51GenSigla = "";
         AV20DynamicFiltersSelector2 = "";
         AV52GenSigla2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV53GenSigla3 = "";
         AV55TFGenSigla_Sel = "";
         AV54TFGenSigla = "";
         AV57TFGenNome_Sel = "";
         AV56TFGenNome = "";
         AV63Core_generowwds_2_filterfulltext = "";
         AV64Core_generowwds_3_dynamicfiltersselector1 = "";
         AV66Core_generowwds_5_gensigla1 = "";
         AV68Core_generowwds_7_dynamicfiltersselector2 = "";
         AV70Core_generowwds_9_gensigla2 = "";
         AV72Core_generowwds_11_dynamicfiltersselector3 = "";
         AV74Core_generowwds_13_gensigla3 = "";
         AV75Core_generowwds_14_tfgensigla = "";
         AV76Core_generowwds_15_tfgensigla_sel = "";
         AV77Core_generowwds_16_tfgennome = "";
         AV78Core_generowwds_17_tfgennome_sel = "";
         scmdbuf = "";
         lV63Core_generowwds_2_filterfulltext = "";
         lV66Core_generowwds_5_gensigla1 = "";
         lV70Core_generowwds_9_gensigla2 = "";
         lV74Core_generowwds_13_gensigla3 = "";
         lV75Core_generowwds_14_tfgensigla = "";
         lV77Core_generowwds_16_tfgennome = "";
         A153GenSigla = "";
         A154GenNome = "";
         P003Z2_A154GenNome = new string[] {""} ;
         P003Z2_A153GenSigla = new string[] {""} ;
         P003Z2_A536GenDel = new bool[] {false} ;
         P003Z2_A152GenID = new int[1] ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.generowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P003Z2_A154GenNome, P003Z2_A153GenSigla, P003Z2_A536GenDel, P003Z2_A152GenID
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
      private short AV65Core_generowwds_4_dynamicfiltersoperator1 ;
      private short AV69Core_generowwds_8_dynamicfiltersoperator2 ;
      private short AV73Core_generowwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A152GenID ;
      private int AV79GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV58GenDel_Filtro ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV62Core_generowwds_1_gendel_filtro ;
      private bool AV67Core_generowwds_6_dynamicfiltersenabled2 ;
      private bool AV71Core_generowwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A536GenDel ;
      private string AV47Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV49GenSigla1 ;
      private string AV50FilterGenSiglaDescription ;
      private string AV51GenSigla ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV52GenSigla2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV53GenSigla3 ;
      private string AV55TFGenSigla_Sel ;
      private string AV54TFGenSigla ;
      private string AV57TFGenNome_Sel ;
      private string AV56TFGenNome ;
      private string AV63Core_generowwds_2_filterfulltext ;
      private string AV64Core_generowwds_3_dynamicfiltersselector1 ;
      private string AV66Core_generowwds_5_gensigla1 ;
      private string AV68Core_generowwds_7_dynamicfiltersselector2 ;
      private string AV70Core_generowwds_9_gensigla2 ;
      private string AV72Core_generowwds_11_dynamicfiltersselector3 ;
      private string AV74Core_generowwds_13_gensigla3 ;
      private string AV75Core_generowwds_14_tfgensigla ;
      private string AV76Core_generowwds_15_tfgensigla_sel ;
      private string AV77Core_generowwds_16_tfgennome ;
      private string AV78Core_generowwds_17_tfgennome_sel ;
      private string lV63Core_generowwds_2_filterfulltext ;
      private string lV66Core_generowwds_5_gensigla1 ;
      private string lV70Core_generowwds_9_gensigla2 ;
      private string lV74Core_generowwds_13_gensigla3 ;
      private string lV75Core_generowwds_14_tfgensigla ;
      private string lV77Core_generowwds_16_tfgennome ;
      private string A153GenSigla ;
      private string A154GenNome ;
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
      private string[] P003Z2_A154GenNome ;
      private string[] P003Z2_A153GenSigla ;
      private bool[] P003Z2_A536GenDel ;
      private int[] P003Z2_A152GenID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class generowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P003Z2( IGxContext context ,
                                             string AV63Core_generowwds_2_filterfulltext ,
                                             string AV64Core_generowwds_3_dynamicfiltersselector1 ,
                                             short AV65Core_generowwds_4_dynamicfiltersoperator1 ,
                                             string AV66Core_generowwds_5_gensigla1 ,
                                             bool AV67Core_generowwds_6_dynamicfiltersenabled2 ,
                                             string AV68Core_generowwds_7_dynamicfiltersselector2 ,
                                             short AV69Core_generowwds_8_dynamicfiltersoperator2 ,
                                             string AV70Core_generowwds_9_gensigla2 ,
                                             bool AV71Core_generowwds_10_dynamicfiltersenabled3 ,
                                             string AV72Core_generowwds_11_dynamicfiltersselector3 ,
                                             short AV73Core_generowwds_12_dynamicfiltersoperator3 ,
                                             string AV74Core_generowwds_13_gensigla3 ,
                                             string AV76Core_generowwds_15_tfgensigla_sel ,
                                             string AV75Core_generowwds_14_tfgensigla ,
                                             string AV78Core_generowwds_17_tfgennome_sel ,
                                             string AV77Core_generowwds_16_tfgennome ,
                                             string A153GenSigla ,
                                             string A154GenNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A536GenDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT GenNome, GenSigla, GenDel, GenID FROM tb_genero";
         AddWhere(sWhereString, "(Not GenDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63Core_generowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( GenSigla like '%' || :lV63Core_generowwds_2_filterfulltext) or ( GenNome like '%' || :lV63Core_generowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV65Core_generowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV66Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV64Core_generowwds_3_dynamicfiltersselector1, "GENSIGLA") == 0 ) && ( AV65Core_generowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_generowwds_5_gensigla1)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV66Core_generowwds_5_gensigla1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV67Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV69Core_generowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV70Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV67Core_generowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV68Core_generowwds_7_dynamicfiltersselector2, "GENSIGLA") == 0 ) && ( AV69Core_generowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_generowwds_9_gensigla2)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV70Core_generowwds_9_gensigla2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV71Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV73Core_generowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV74Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV71Core_generowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_generowwds_11_dynamicfiltersselector3, "GENSIGLA") == 0 ) && ( AV73Core_generowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_generowwds_13_gensigla3)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like '%' || :lV74Core_generowwds_13_gensigla3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_generowwds_15_tfgensigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_generowwds_14_tfgensigla)) ) )
         {
            AddWhere(sWhereString, "(GenSigla like :lV75Core_generowwds_14_tfgensigla)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_generowwds_15_tfgensigla_sel)) && ! ( StringUtil.StrCmp(AV76Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenSigla = ( :AV76Core_generowwds_15_tfgensigla_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV76Core_generowwds_15_tfgensigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_generowwds_17_tfgennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_generowwds_16_tfgennome)) ) )
         {
            AddWhere(sWhereString, "(GenNome like :lV77Core_generowwds_16_tfgennome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_generowwds_17_tfgennome_sel)) && ! ( StringUtil.StrCmp(AV78Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(GenNome = ( :AV78Core_generowwds_17_tfgennome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV78Core_generowwds_17_tfgennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from GenNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY GenSigla";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY GenSigla DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY GenNome";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY GenNome DESC";
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
                     return conditional_P003Z2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP003Z2;
          prmP003Z2 = new Object[] {
          new ParDef("lV63Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV63Core_generowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV66Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV66Core_generowwds_5_gensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV70Core_generowwds_9_gensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV74Core_generowwds_13_gensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV75Core_generowwds_14_tfgensigla",GXType.VarChar,20,0) ,
          new ParDef("AV76Core_generowwds_15_tfgensigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_generowwds_16_tfgennome",GXType.VarChar,80,0) ,
          new ParDef("AV78Core_generowwds_17_tfgennome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P003Z2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP003Z2,100, GxCacheFrequency.OFF ,true,false )
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
