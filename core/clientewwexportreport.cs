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
   public class clientewwexportreport : GXWebProcedure
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

      public clientewwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientewwexportreport( IGxContext context )
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
         clientewwexportreport objclientewwexportreport;
         objclientewwexportreport = new clientewwexportreport();
         objclientewwexportreport.context.SetSubmitInitialConfig(context);
         objclientewwexportreport.initialize();
         Submit( executePrivateCatch,objclientewwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientewwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("ClienteWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clienteww_Execute", out  GXt_boolean1) ;
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
               AV58Title = "Lista de Cliente";
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
            H450( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CLIMATRICULA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16CliMatricula1 = (long)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV16CliMatricula1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                  }
                  AV18CliMatricula = AV16CliMatricula1;
                  H450( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCliMatriculaDescription, "")), 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "CLIMATRICULA") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22CliMatricula2 = (long)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV22CliMatricula2) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                     }
                     AV18CliMatricula = AV22CliMatricula2;
                     H450( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCliMatriculaDescription, "")), 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV31GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV31GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "CLIMATRICULA") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26CliMatricula3 = (long)(Math.Round(NumberUtil.Val( AV27GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV26CliMatricula3) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "<=", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterCliMatriculaDescription = StringUtil.Format( "%1 (%2)", "Matrícula", ">=", "", "", "", "", "", "", "");
                        }
                        AV18CliMatricula = AV26CliMatricula3;
                        H450( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCliMatriculaDescription, "")), 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFCliNomeFamiliar_Sel)) )
         {
            AV46TempBoolean = (bool)(((StringUtil.StrCmp(AV34TFCliNomeFamiliar_Sel, "<#Empty#>")==0)));
            AV34TFCliNomeFamiliar_Sel = (AV46TempBoolean ? "(Vazio)" : AV34TFCliNomeFamiliar_Sel);
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFCliNomeFamiliar_Sel, "@!")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV34TFCliNomeFamiliar_Sel = (AV46TempBoolean ? "<#Empty#>" : AV34TFCliNomeFamiliar_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFCliNomeFamiliar)) )
            {
               H450( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFCliNomeFamiliar, "@!")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV35TFCliMatricula) && (0==AV36TFCliMatricula_To) ) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Matrícula", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV35TFCliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFCliMatricula_To_Description = StringUtil.Format( "%1 (%2)", "Matrícula", "Até", "", "", "", "", "", "", "");
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFCliMatricula_To_Description, "")), 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV36TFCliMatricula_To), "ZZZ,ZZZ,ZZZ,ZZ9")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         AV39TFCliTipo_Sels.FromJSonString(AV37TFCliTipo_SelsJson, null);
         if ( ! ( AV39TFCliTipo_Sels.Count == 0 ) )
         {
            AV47i = 1;
            AV62GXV1 = 1;
            while ( AV62GXV1 <= AV39TFCliTipo_Sels.Count )
            {
               AV40TFCliTipo_Sel = (short)(AV39TFCliTipo_Sels.GetNumeric(AV62GXV1));
               if ( AV47i == 1 )
               {
                  AV38TFCliTipo_SelDscs = "";
               }
               else
               {
                  AV38TFCliTipo_SelDscs += ", ";
               }
               AV44FilterTFCliTipo_SelValueDescription = GeneXus.Programs.core.gxdomainpessoatipo.getDescription(context,AV40TFCliTipo_Sel);
               AV38TFCliTipo_SelDscs += AV44FilterTFCliTipo_SelValueDescription;
               AV47i = (long)(AV47i+1);
               AV62GXV1 = (int)(AV62GXV1+1);
            }
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFCliTipo_SelDscs, "")), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV41TFCliInsData) && (DateTime.MinValue==AV42TFCliInsData_To) ) )
         {
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído em", 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV41TFCliInsData, "99/99/99"), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV45TFCliInsData_To_Description = StringUtil.Format( "%1 (%2)", "Incluído em", "Até", "", "", "", "", "", "", "");
            H450( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFCliInsData_To_Description, "")), 25, Gx_line+0, 116, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV42TFCliInsData_To, "99/99/99"), 116, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H450( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H450( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Matrícula", 282, Gx_line+10, 406, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 410, Gx_line+10, 658, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído em", 662, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV64Core_clientewwds_1_filterfulltext = AV13FilterFullText;
         AV65Core_clientewwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV66Core_clientewwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV67Core_clientewwds_4_climatricula1 = AV16CliMatricula1;
         AV68Core_clientewwds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV69Core_clientewwds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV70Core_clientewwds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV71Core_clientewwds_8_climatricula2 = AV22CliMatricula2;
         AV72Core_clientewwds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV73Core_clientewwds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV74Core_clientewwds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV75Core_clientewwds_12_climatricula3 = AV26CliMatricula3;
         AV76Core_clientewwds_13_tfclinomefamiliar = AV33TFCliNomeFamiliar;
         AV77Core_clientewwds_14_tfclinomefamiliar_sel = AV34TFCliNomeFamiliar_Sel;
         AV78Core_clientewwds_15_tfclimatricula = AV35TFCliMatricula;
         AV79Core_clientewwds_16_tfclimatricula_to = AV36TFCliMatricula_To;
         AV80Core_clientewwds_17_tfclitipo_sels = AV39TFCliTipo_Sels;
         AV81Core_clientewwds_18_tfcliinsdata = AV41TFCliInsData;
         AV82Core_clientewwds_19_tfcliinsdata_to = AV42TFCliInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A165CliTipo ,
                                              AV80Core_clientewwds_17_tfclitipo_sels ,
                                              AV64Core_clientewwds_1_filterfulltext ,
                                              AV65Core_clientewwds_2_dynamicfiltersselector1 ,
                                              AV66Core_clientewwds_3_dynamicfiltersoperator1 ,
                                              AV67Core_clientewwds_4_climatricula1 ,
                                              AV68Core_clientewwds_5_dynamicfiltersenabled2 ,
                                              AV69Core_clientewwds_6_dynamicfiltersselector2 ,
                                              AV70Core_clientewwds_7_dynamicfiltersoperator2 ,
                                              AV71Core_clientewwds_8_climatricula2 ,
                                              AV72Core_clientewwds_9_dynamicfiltersenabled3 ,
                                              AV73Core_clientewwds_10_dynamicfiltersselector3 ,
                                              AV74Core_clientewwds_11_dynamicfiltersoperator3 ,
                                              AV75Core_clientewwds_12_climatricula3 ,
                                              AV77Core_clientewwds_14_tfclinomefamiliar_sel ,
                                              AV76Core_clientewwds_13_tfclinomefamiliar ,
                                              AV78Core_clientewwds_15_tfclimatricula ,
                                              AV79Core_clientewwds_16_tfclimatricula_to ,
                                              AV80Core_clientewwds_17_tfclitipo_sels.Count ,
                                              AV81Core_clientewwds_18_tfcliinsdata ,
                                              AV82Core_clientewwds_19_tfcliinsdata_to ,
                                              A160CliNomeFamiliar ,
                                              A159CliMatricula ,
                                              A161CliInsData ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.INT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_clientewwds_1_filterfulltext), "%", "");
         lV64Core_clientewwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_clientewwds_1_filterfulltext), "%", "");
         lV76Core_clientewwds_13_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV76Core_clientewwds_13_tfclinomefamiliar), "%", "");
         /* Using cursor P00452 */
         pr_default.execute(0, new Object[] {lV64Core_clientewwds_1_filterfulltext, lV64Core_clientewwds_1_filterfulltext, AV67Core_clientewwds_4_climatricula1, AV67Core_clientewwds_4_climatricula1, AV67Core_clientewwds_4_climatricula1, AV71Core_clientewwds_8_climatricula2, AV71Core_clientewwds_8_climatricula2, AV71Core_clientewwds_8_climatricula2, AV75Core_clientewwds_12_climatricula3, AV75Core_clientewwds_12_climatricula3, AV75Core_clientewwds_12_climatricula3, lV76Core_clientewwds_13_tfclinomefamiliar, AV77Core_clientewwds_14_tfclinomefamiliar_sel, AV78Core_clientewwds_15_tfclimatricula, AV79Core_clientewwds_16_tfclimatricula_to, AV81Core_clientewwds_18_tfcliinsdata, AV82Core_clientewwds_19_tfcliinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A161CliInsData = P00452_A161CliInsData[0];
            A165CliTipo = P00452_A165CliTipo[0];
            A159CliMatricula = P00452_A159CliMatricula[0];
            A160CliNomeFamiliar = P00452_A160CliNomeFamiliar[0];
            A158CliID = P00452_A158CliID[0];
            if ( ! (0==A165CliTipo) )
            {
               AV28CliTipoDescription = GeneXus.Programs.core.gxdomainpessoatipo.getDescription(context,A165CliTipo);
            }
            else
            {
               AV28CliTipoDescription = "";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H450( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")), 30, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 282, Gx_line+10, 406, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV28CliTipoDescription, "")), 410, Gx_line+10, 658, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A161CliInsData, "99/99/99"), 662, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV29Session.Get("core.ClienteWWGridState"), "") == 0 )
         {
            AV31GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClienteWWGridState"), null, "", "");
         }
         else
         {
            AV31GridState.FromXml(AV29Session.Get("core.ClienteWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV31GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV31GridState.gxTpr_Ordereddsc;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV31GridState.gxTpr_Filtervalues.Count )
         {
            AV32GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV31GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV33TFCliNomeFamiliar = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV34TFCliNomeFamiliar_Sel = AV32GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV35TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV36TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV32GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLITIPO_SEL") == 0 )
            {
               AV37TFCliTipo_SelsJson = AV32GridStateFilterValue.gxTpr_Value;
               AV39TFCliTipo_Sels.FromJSonString(AV37TFCliTipo_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV32GridStateFilterValue.gxTpr_Name, "TFCLIINSDATA") == 0 )
            {
               AV41TFCliInsData = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Value, 2);
               AV42TFCliInsData_To = context.localUtil.CToD( AV32GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
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

      protected void H450( bool bFoot ,
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
                  AV56PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV53DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV51AppName = "DVelop Software Solutions";
               AV57Phone = "+1 550 8923";
               AV55Mail = "info@mail.com";
               AV59Website = "http://www.web.com";
               AV48AddressLine1 = "French Boulevard 2859";
               AV49AddressLine2 = "Downtown";
               AV50AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV58Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV58Title = "";
         AV13FilterFullText = "";
         AV31GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV17FilterCliMatriculaDescription = "";
         AV20DynamicFiltersSelector2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV34TFCliNomeFamiliar_Sel = "";
         AV33TFCliNomeFamiliar = "";
         AV43TFCliMatricula_To_Description = "";
         AV39TFCliTipo_Sels = new GxSimpleCollection<short>();
         AV37TFCliTipo_SelsJson = "";
         AV38TFCliTipo_SelDscs = "";
         AV44FilterTFCliTipo_SelValueDescription = "";
         AV41TFCliInsData = DateTime.MinValue;
         AV42TFCliInsData_To = DateTime.MinValue;
         AV45TFCliInsData_To_Description = "";
         AV64Core_clientewwds_1_filterfulltext = "";
         AV65Core_clientewwds_2_dynamicfiltersselector1 = "";
         AV69Core_clientewwds_6_dynamicfiltersselector2 = "";
         AV73Core_clientewwds_10_dynamicfiltersselector3 = "";
         AV76Core_clientewwds_13_tfclinomefamiliar = "";
         AV77Core_clientewwds_14_tfclinomefamiliar_sel = "";
         AV80Core_clientewwds_17_tfclitipo_sels = new GxSimpleCollection<short>();
         AV81Core_clientewwds_18_tfcliinsdata = DateTime.MinValue;
         AV82Core_clientewwds_19_tfcliinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV64Core_clientewwds_1_filterfulltext = "";
         lV76Core_clientewwds_13_tfclinomefamiliar = "";
         A160CliNomeFamiliar = "";
         A161CliInsData = DateTime.MinValue;
         P00452_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         P00452_A165CliTipo = new short[1] ;
         P00452_A159CliMatricula = new long[1] ;
         P00452_A160CliNomeFamiliar = new string[] {""} ;
         P00452_A158CliID = new Guid[] {Guid.Empty} ;
         A158CliID = Guid.Empty;
         AV28CliTipoDescription = "";
         AV29Session = context.GetSession();
         AV32GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV56PageInfo = "";
         AV53DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV51AppName = "";
         AV57Phone = "";
         AV55Mail = "";
         AV59Website = "";
         AV48AddressLine1 = "";
         AV49AddressLine2 = "";
         AV50AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientewwexportreport__default(),
            new Object[][] {
                new Object[] {
               P00452_A161CliInsData, P00452_A165CliTipo, P00452_A159CliMatricula, P00452_A160CliNomeFamiliar, P00452_A158CliID
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
      private short AV40TFCliTipo_Sel ;
      private short AV66Core_clientewwds_3_dynamicfiltersoperator1 ;
      private short AV70Core_clientewwds_7_dynamicfiltersoperator2 ;
      private short AV74Core_clientewwds_11_dynamicfiltersoperator3 ;
      private short A165CliTipo ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV62GXV1 ;
      private int AV80Core_clientewwds_17_tfclitipo_sels_Count ;
      private int AV83GXV2 ;
      private long AV16CliMatricula1 ;
      private long AV18CliMatricula ;
      private long AV22CliMatricula2 ;
      private long AV26CliMatricula3 ;
      private long AV35TFCliMatricula ;
      private long AV36TFCliMatricula_To ;
      private long AV47i ;
      private long AV67Core_clientewwds_4_climatricula1 ;
      private long AV71Core_clientewwds_8_climatricula2 ;
      private long AV75Core_clientewwds_12_climatricula3 ;
      private long AV78Core_clientewwds_15_tfclimatricula ;
      private long AV79Core_clientewwds_16_tfclimatricula_to ;
      private long A159CliMatricula ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV41TFCliInsData ;
      private DateTime AV42TFCliInsData_To ;
      private DateTime AV81Core_clientewwds_18_tfcliinsdata ;
      private DateTime AV82Core_clientewwds_19_tfcliinsdata_to ;
      private DateTime A161CliInsData ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV46TempBoolean ;
      private bool AV68Core_clientewwds_5_dynamicfiltersenabled2 ;
      private bool AV72Core_clientewwds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV37TFCliTipo_SelsJson ;
      private string AV58Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterCliMatriculaDescription ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV34TFCliNomeFamiliar_Sel ;
      private string AV33TFCliNomeFamiliar ;
      private string AV43TFCliMatricula_To_Description ;
      private string AV38TFCliTipo_SelDscs ;
      private string AV44FilterTFCliTipo_SelValueDescription ;
      private string AV45TFCliInsData_To_Description ;
      private string AV64Core_clientewwds_1_filterfulltext ;
      private string AV65Core_clientewwds_2_dynamicfiltersselector1 ;
      private string AV69Core_clientewwds_6_dynamicfiltersselector2 ;
      private string AV73Core_clientewwds_10_dynamicfiltersselector3 ;
      private string AV76Core_clientewwds_13_tfclinomefamiliar ;
      private string AV77Core_clientewwds_14_tfclinomefamiliar_sel ;
      private string lV64Core_clientewwds_1_filterfulltext ;
      private string lV76Core_clientewwds_13_tfclinomefamiliar ;
      private string A160CliNomeFamiliar ;
      private string AV28CliTipoDescription ;
      private string AV56PageInfo ;
      private string AV53DateInfo ;
      private string AV51AppName ;
      private string AV57Phone ;
      private string AV55Mail ;
      private string AV59Website ;
      private string AV48AddressLine1 ;
      private string AV49AddressLine2 ;
      private string AV50AddressLine3 ;
      private Guid A158CliID ;
      private GxSimpleCollection<short> AV39TFCliTipo_Sels ;
      private GxSimpleCollection<short> AV80Core_clientewwds_17_tfclitipo_sels ;
      private IGxSession AV29Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P00452_A161CliInsData ;
      private short[] P00452_A165CliTipo ;
      private long[] P00452_A159CliMatricula ;
      private string[] P00452_A160CliNomeFamiliar ;
      private Guid[] P00452_A158CliID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV31GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV32GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class clientewwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00452( IGxContext context ,
                                             short A165CliTipo ,
                                             GxSimpleCollection<short> AV80Core_clientewwds_17_tfclitipo_sels ,
                                             string AV64Core_clientewwds_1_filterfulltext ,
                                             string AV65Core_clientewwds_2_dynamicfiltersselector1 ,
                                             short AV66Core_clientewwds_3_dynamicfiltersoperator1 ,
                                             long AV67Core_clientewwds_4_climatricula1 ,
                                             bool AV68Core_clientewwds_5_dynamicfiltersenabled2 ,
                                             string AV69Core_clientewwds_6_dynamicfiltersselector2 ,
                                             short AV70Core_clientewwds_7_dynamicfiltersoperator2 ,
                                             long AV71Core_clientewwds_8_climatricula2 ,
                                             bool AV72Core_clientewwds_9_dynamicfiltersenabled3 ,
                                             string AV73Core_clientewwds_10_dynamicfiltersselector3 ,
                                             short AV74Core_clientewwds_11_dynamicfiltersoperator3 ,
                                             long AV75Core_clientewwds_12_climatricula3 ,
                                             string AV77Core_clientewwds_14_tfclinomefamiliar_sel ,
                                             string AV76Core_clientewwds_13_tfclinomefamiliar ,
                                             long AV78Core_clientewwds_15_tfclimatricula ,
                                             long AV79Core_clientewwds_16_tfclimatricula_to ,
                                             int AV80Core_clientewwds_17_tfclitipo_sels_Count ,
                                             DateTime AV81Core_clientewwds_18_tfcliinsdata ,
                                             DateTime AV82Core_clientewwds_19_tfcliinsdata_to ,
                                             string A160CliNomeFamiliar ,
                                             long A159CliMatricula ,
                                             DateTime A161CliInsData ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[17];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT CliInsData, CliTipo, CliMatricula, CliNomeFamiliar, CliID FROM tb_cliente";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_clientewwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( CliNomeFamiliar like '%' || :lV64Core_clientewwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(CliMatricula,'999999999999'), 2) like '%' || :lV64Core_clientewwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV67Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV67Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV67Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV67Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV65Core_clientewwds_2_dynamicfiltersselector1, "CLIMATRICULA") == 0 ) && ( AV66Core_clientewwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV67Core_clientewwds_4_climatricula1) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV67Core_clientewwds_4_climatricula1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV68Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_7_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV71Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV71Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV68Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_7_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV71Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV71Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV68Core_clientewwds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV69Core_clientewwds_6_dynamicfiltersselector2, "CLIMATRICULA") == 0 ) && ( AV70Core_clientewwds_7_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV71Core_clientewwds_8_climatricula2) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV71Core_clientewwds_8_climatricula2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV72Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV74Core_clientewwds_11_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV75Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV75Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV72Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV74Core_clientewwds_11_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV75Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula = :AV75Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV72Core_clientewwds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV73Core_clientewwds_10_dynamicfiltersselector3, "CLIMATRICULA") == 0 ) && ( AV74Core_clientewwds_11_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV75Core_clientewwds_12_climatricula3) ) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV75Core_clientewwds_12_climatricula3)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_clientewwds_14_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_clientewwds_13_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar like :lV76Core_clientewwds_13_tfclinomefamiliar)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_clientewwds_14_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV77Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(CliNomeFamiliar = ( :AV77Core_clientewwds_14_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( StringUtil.StrCmp(AV77Core_clientewwds_14_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV78Core_clientewwds_15_tfclimatricula) )
         {
            AddWhere(sWhereString, "(CliMatricula >= :AV78Core_clientewwds_15_tfclimatricula)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (0==AV79Core_clientewwds_16_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(CliMatricula <= :AV79Core_clientewwds_16_tfclimatricula_to)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV80Core_clientewwds_17_tfclitipo_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV80Core_clientewwds_17_tfclitipo_sels, "CliTipo IN (", ")")+")");
         }
         if ( ! (DateTime.MinValue==AV81Core_clientewwds_18_tfcliinsdata) )
         {
            AddWhere(sWhereString, "(CliInsData >= :AV81Core_clientewwds_18_tfcliinsdata)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV82Core_clientewwds_19_tfcliinsdata_to) )
         {
            AddWhere(sWhereString, "(CliInsData <= :AV82Core_clientewwds_19_tfcliinsdata_to)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CliNomeFamiliar";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliNomeFamiliar DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CliMatricula";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliMatricula DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CliTipo";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliTipo DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY CliInsData";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY CliInsData DESC";
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
                     return conditional_P00452(context, (short)dynConstraints[0] , (GxSimpleCollection<short>)dynConstraints[1] , (string)dynConstraints[2] , (string)dynConstraints[3] , (short)dynConstraints[4] , (long)dynConstraints[5] , (bool)dynConstraints[6] , (string)dynConstraints[7] , (short)dynConstraints[8] , (long)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (long)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (long)dynConstraints[16] , (long)dynConstraints[17] , (int)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (long)dynConstraints[22] , (DateTime)dynConstraints[23] , (short)dynConstraints[24] , (bool)dynConstraints[25] );
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
          Object[] prmP00452;
          prmP00452 = new Object[] {
          new ParDef("lV64Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_clientewwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV67Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV67Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV67Core_clientewwds_4_climatricula1",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV71Core_clientewwds_8_climatricula2",GXType.Int64,12,0) ,
          new ParDef("AV75Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV75Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("AV75Core_clientewwds_12_climatricula3",GXType.Int64,12,0) ,
          new ParDef("lV76Core_clientewwds_13_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV77Core_clientewwds_14_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV78Core_clientewwds_15_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV79Core_clientewwds_16_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("AV81Core_clientewwds_18_tfcliinsdata",GXType.Date,8,0) ,
          new ParDef("AV82Core_clientewwds_19_tfcliinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00452", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00452,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDate(1);
                ((short[]) buf[1])[0] = rslt.getShort(2);
                ((long[]) buf[2])[0] = rslt.getLong(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
