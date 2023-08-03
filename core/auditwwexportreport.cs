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
   public class auditwwexportreport : GXWebProcedure
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

      public auditwwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public auditwwexportreport( IGxContext context )
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
         auditwwexportreport objauditwwexportreport;
         objauditwwexportreport = new auditwwexportreport();
         objauditwwexportreport.context.SetSubmitInitialConfig(context);
         objauditwwexportreport.initialize();
         Submit( executePrivateCatch,objauditwwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((auditwwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("AuditWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "auditww_Execute", out  GXt_boolean1) ;
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
               AV64Title = "Lista de Auditoria dos Dados";
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
            H7M0( true, 0) ;
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
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "AUDITDATE") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV18AuditDate1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, 2);
               AV19AuditDate_To1 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, 2);
               if ( ! (DateTime.MinValue==AV18AuditDate1) || ! (DateTime.MinValue==AV19AuditDate_To1) )
               {
                  AV16FixedValueOperatorDsc = "Data";
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                     AV21AuditDate = AV18AuditDate1;
                     H7M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                     AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2) %3", "Data", "Período", "", "", "", "", "", "", "");
                     AV21AuditDate = AV19AuditDate_To1;
                     H7M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FixedValueOperatorValue = "Passado";
                     H7M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FixedValueOperatorValue = "Hoje";
                     H7M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
                  else if ( AV15DynamicFiltersOperator1 == 3 )
                  {
                     AV17FixedValueOperatorValue = "No futuro";
                     H7M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "AUDITDATE") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25AuditDate2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, 2);
                  AV26AuditDate_To2 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, 2);
                  if ( ! (DateTime.MinValue==AV25AuditDate2) || ! (DateTime.MinValue==AV26AuditDate_To2) )
                  {
                     AV16FixedValueOperatorDsc = "Data";
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                        AV21AuditDate = AV25AuditDate2;
                        H7M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                        AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2) %3", "Data", "Período", "", "", "", "", "", "", "");
                        AV21AuditDate = AV26AuditDate_To2;
                        H7M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FixedValueOperatorValue = "Passado";
                        H7M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FixedValueOperatorValue = "Hoje";
                        H7M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                     else if ( AV24DynamicFiltersOperator2 == 3 )
                     {
                        AV17FixedValueOperatorValue = "No futuro";
                        H7M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "AUDITDATE") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30AuditDate3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Value, 2);
                     AV31AuditDate_To3 = context.localUtil.CToD( AV32GridStateDynamicFilter.gxTpr_Valueto, 2);
                     if ( ! (DateTime.MinValue==AV30AuditDate3) || ! (DateTime.MinValue==AV31AuditDate_To3) )
                     {
                        AV16FixedValueOperatorDsc = "Data";
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2)", "Data", "Período", "", "", "", "", "", "", "");
                           AV21AuditDate = AV30AuditDate3;
                           H7M0( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                           AV20FilterAuditDateDescription = StringUtil.Format( "%1 (%2) %3", "Data", "Período", "", "", "", "", "", "", "");
                           AV21AuditDate = AV31AuditDate_To3;
                           H7M0( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterAuditDateDescription, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(context.localUtil.Format( AV21AuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FixedValueOperatorValue = "Passado";
                           H7M0( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FixedValueOperatorValue = "Hoje";
                           H7M0( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                        else if ( AV29DynamicFiltersOperator3 == 3 )
                        {
                           AV17FixedValueOperatorValue = "No futuro";
                           H7M0( false, 20) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV16FixedValueOperatorDsc, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
                           getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                           getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FixedValueOperatorValue, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                           Gx_OldLine = Gx_line;
                           Gx_line = (int)(Gx_line+20);
                        }
                     }
                  }
               }
            }
         }
         if ( ! ( (DateTime.MinValue==AV66TFAuditDateTime) && (DateTime.MinValue==AV67TFAuditDateTime_To) ) )
         {
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data/Hora", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV66TFAuditDateTime, "99/99/9999 99:99:99.999"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFAuditDateTime_To_Description = StringUtil.Format( "%1 (%2)", "Data/Hora", "Até", "", "", "", "", "", "", "");
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFAuditDateTime_To_Description, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV67TFAuditDateTime_To, "99/99/9999 99:99:99.999"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV37TFAuditDate) && (DateTime.MinValue==AV38TFAuditDate_To) ) )
         {
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV37TFAuditDate, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFAuditDate_To_Description = StringUtil.Format( "%1 (%2)", "Data", "Até", "", "", "", "", "", "", "");
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFAuditDate_To_Description, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV38TFAuditDate_To, "99/99/99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV39TFAuditTime) && (DateTime.MinValue==AV40TFAuditTime_To) ) )
         {
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Hora", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV39TFAuditTime, "99:99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFAuditTime_To_Description = StringUtil.Format( "%1 (%2)", "Hora", "Até", "", "", "", "", "", "", "");
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFAuditTime_To_Description, "")), 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV40TFAuditTime_To, "99:99"), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFAuditTableName_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFAuditTableName_Sel, "<#Empty#>")==0)));
            AV42TFAuditTableName_Sel = (AV53TempBoolean ? "(Vazio)" : AV42TFAuditTableName_Sel);
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tabela", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFAuditTableName_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFAuditTableName_Sel = (AV53TempBoolean ? "<#Empty#>" : AV42TFAuditTableName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFAuditTableName)) )
            {
               H7M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tabela", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFAuditTableName, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFAuditAction_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFAuditAction_Sel, "<#Empty#>")==0)));
            AV50TFAuditAction_Sel = (AV53TempBoolean ? "(Vazio)" : AV50TFAuditAction_Sel);
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ação", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFAuditAction_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFAuditAction_Sel = (AV53TempBoolean ? "<#Empty#>" : AV50TFAuditAction_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFAuditAction)) )
            {
               H7M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ação", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFAuditAction, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV44TFAuditShortDescription_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV44TFAuditShortDescription_Sel, "<#Empty#>")==0)));
            AV44TFAuditShortDescription_Sel = (AV53TempBoolean ? "(Vazio)" : AV44TFAuditShortDescription_Sel);
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44TFAuditShortDescription_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV44TFAuditShortDescription_Sel = (AV53TempBoolean ? "<#Empty#>" : AV44TFAuditShortDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV43TFAuditShortDescription)) )
            {
               H7M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFAuditShortDescription, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV46TFAuditDescription_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV46TFAuditDescription_Sel, "<#Empty#>")==0)));
            AV46TFAuditDescription_Sel = (AV53TempBoolean ? "(Vazio)" : AV46TFAuditDescription_Sel);
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Detalhes", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46TFAuditDescription_Sel, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV46TFAuditDescription_Sel = (AV53TempBoolean ? "<#Empty#>" : AV46TFAuditDescription_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV45TFAuditDescription)) )
            {
               H7M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Detalhes", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45TFAuditDescription, "")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFAuditGAMUserName_Sel)) )
         {
            AV53TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFAuditGAMUserName_Sel, "<#Empty#>")==0)));
            AV48TFAuditGAMUserName_Sel = (AV53TempBoolean ? "(Vazio)" : AV48TFAuditGAMUserName_Sel);
            H7M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFAuditGAMUserName_Sel, "@!")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFAuditGAMUserName_Sel = (AV53TempBoolean ? "<#Empty#>" : AV48TFAuditGAMUserName_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFAuditGAMUserName)) )
            {
               H7M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Usuário", 25, Gx_line+0, 111, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFAuditGAMUserName, "@!")), 111, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H7M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H7M0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Data/Hora", 30, Gx_line+10, 86, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data", 90, Gx_line+10, 146, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Hora", 150, Gx_line+10, 206, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tabela", 210, Gx_line+10, 322, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ação", 326, Gx_line+10, 438, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 442, Gx_line+10, 554, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Detalhes", 558, Gx_line+10, 670, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Usuário", 674, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV72Core_auditwwds_1_filterfulltext = AV13FilterFullText;
         AV73Core_auditwwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV74Core_auditwwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV75Core_auditwwds_4_auditdate1 = AV18AuditDate1;
         AV76Core_auditwwds_5_auditdate_to1 = AV19AuditDate_To1;
         AV77Core_auditwwds_6_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV78Core_auditwwds_7_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV79Core_auditwwds_8_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV80Core_auditwwds_9_auditdate2 = AV25AuditDate2;
         AV81Core_auditwwds_10_auditdate_to2 = AV26AuditDate_To2;
         AV82Core_auditwwds_11_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV83Core_auditwwds_12_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV84Core_auditwwds_13_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV85Core_auditwwds_14_auditdate3 = AV30AuditDate3;
         AV86Core_auditwwds_15_auditdate_to3 = AV31AuditDate_To3;
         AV87Core_auditwwds_16_tfauditdatetime = AV66TFAuditDateTime;
         AV88Core_auditwwds_17_tfauditdatetime_to = AV67TFAuditDateTime_To;
         AV89Core_auditwwds_18_tfauditdate = AV37TFAuditDate;
         AV90Core_auditwwds_19_tfauditdate_to = AV38TFAuditDate_To;
         AV91Core_auditwwds_20_tfaudittime = AV39TFAuditTime;
         AV92Core_auditwwds_21_tfaudittime_to = AV40TFAuditTime_To;
         AV93Core_auditwwds_22_tfaudittablename = AV41TFAuditTableName;
         AV94Core_auditwwds_23_tfaudittablename_sel = AV42TFAuditTableName_Sel;
         AV95Core_auditwwds_24_tfauditaction = AV49TFAuditAction;
         AV96Core_auditwwds_25_tfauditaction_sel = AV50TFAuditAction_Sel;
         AV97Core_auditwwds_26_tfauditshortdescription = AV43TFAuditShortDescription;
         AV98Core_auditwwds_27_tfauditshortdescription_sel = AV44TFAuditShortDescription_Sel;
         AV99Core_auditwwds_28_tfauditdescription = AV45TFAuditDescription;
         AV100Core_auditwwds_29_tfauditdescription_sel = AV46TFAuditDescription_Sel;
         AV101Core_auditwwds_30_tfauditgamusername = AV47TFAuditGAMUserName;
         AV102Core_auditwwds_31_tfauditgamusername_sel = AV48TFAuditGAMUserName_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV72Core_auditwwds_1_filterfulltext ,
                                              AV73Core_auditwwds_2_dynamicfiltersselector1 ,
                                              AV74Core_auditwwds_3_dynamicfiltersoperator1 ,
                                              AV75Core_auditwwds_4_auditdate1 ,
                                              AV76Core_auditwwds_5_auditdate_to1 ,
                                              AV77Core_auditwwds_6_dynamicfiltersenabled2 ,
                                              AV78Core_auditwwds_7_dynamicfiltersselector2 ,
                                              AV79Core_auditwwds_8_dynamicfiltersoperator2 ,
                                              AV80Core_auditwwds_9_auditdate2 ,
                                              AV81Core_auditwwds_10_auditdate_to2 ,
                                              AV82Core_auditwwds_11_dynamicfiltersenabled3 ,
                                              AV83Core_auditwwds_12_dynamicfiltersselector3 ,
                                              AV84Core_auditwwds_13_dynamicfiltersoperator3 ,
                                              AV85Core_auditwwds_14_auditdate3 ,
                                              AV86Core_auditwwds_15_auditdate_to3 ,
                                              AV87Core_auditwwds_16_tfauditdatetime ,
                                              AV88Core_auditwwds_17_tfauditdatetime_to ,
                                              AV89Core_auditwwds_18_tfauditdate ,
                                              AV90Core_auditwwds_19_tfauditdate_to ,
                                              AV91Core_auditwwds_20_tfaudittime ,
                                              AV92Core_auditwwds_21_tfaudittime_to ,
                                              AV94Core_auditwwds_23_tfaudittablename_sel ,
                                              AV93Core_auditwwds_22_tfaudittablename ,
                                              AV96Core_auditwwds_25_tfauditaction_sel ,
                                              AV95Core_auditwwds_24_tfauditaction ,
                                              AV98Core_auditwwds_27_tfauditshortdescription_sel ,
                                              AV97Core_auditwwds_26_tfauditshortdescription ,
                                              AV100Core_auditwwds_29_tfauditdescription_sel ,
                                              AV99Core_auditwwds_28_tfauditdescription ,
                                              AV102Core_auditwwds_31_tfauditgamusername_sel ,
                                              AV101Core_auditwwds_30_tfauditgamusername ,
                                              A497AuditTableName ,
                                              A502AuditAction ,
                                              A499AuditShortDescription ,
                                              A498AuditDescription ,
                                              A501AuditGAMUserName ,
                                              A494AuditDate ,
                                              A496AuditDateTime ,
                                              A495AuditTime ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV72Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext), "%", "");
         lV72Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext), "%", "");
         lV72Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext), "%", "");
         lV72Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext), "%", "");
         lV72Core_auditwwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext), "%", "");
         lV93Core_auditwwds_22_tfaudittablename = StringUtil.Concat( StringUtil.RTrim( AV93Core_auditwwds_22_tfaudittablename), "%", "");
         lV95Core_auditwwds_24_tfauditaction = StringUtil.Concat( StringUtil.RTrim( AV95Core_auditwwds_24_tfauditaction), "%", "");
         lV97Core_auditwwds_26_tfauditshortdescription = StringUtil.Concat( StringUtil.RTrim( AV97Core_auditwwds_26_tfauditshortdescription), "%", "");
         lV99Core_auditwwds_28_tfauditdescription = StringUtil.Concat( StringUtil.RTrim( AV99Core_auditwwds_28_tfauditdescription), "%", "");
         lV101Core_auditwwds_30_tfauditgamusername = StringUtil.Concat( StringUtil.RTrim( AV101Core_auditwwds_30_tfauditgamusername), "%", "");
         /* Using cursor P007M2 */
         pr_default.execute(0, new Object[] {lV72Core_auditwwds_1_filterfulltext, lV72Core_auditwwds_1_filterfulltext, lV72Core_auditwwds_1_filterfulltext, lV72Core_auditwwds_1_filterfulltext, lV72Core_auditwwds_1_filterfulltext, AV75Core_auditwwds_4_auditdate1, AV76Core_auditwwds_5_auditdate_to1, AV75Core_auditwwds_4_auditdate1, AV75Core_auditwwds_4_auditdate1, AV75Core_auditwwds_4_auditdate1, AV80Core_auditwwds_9_auditdate2, AV81Core_auditwwds_10_auditdate_to2, AV80Core_auditwwds_9_auditdate2, AV80Core_auditwwds_9_auditdate2, AV80Core_auditwwds_9_auditdate2, AV85Core_auditwwds_14_auditdate3, AV86Core_auditwwds_15_auditdate_to3, AV85Core_auditwwds_14_auditdate3, AV85Core_auditwwds_14_auditdate3, AV85Core_auditwwds_14_auditdate3, AV87Core_auditwwds_16_tfauditdatetime, AV88Core_auditwwds_17_tfauditdatetime_to, AV89Core_auditwwds_18_tfauditdate, AV90Core_auditwwds_19_tfauditdate_to, AV91Core_auditwwds_20_tfaudittime, AV92Core_auditwwds_21_tfaudittime_to, lV93Core_auditwwds_22_tfaudittablename, AV94Core_auditwwds_23_tfaudittablename_sel, lV95Core_auditwwds_24_tfauditaction, AV96Core_auditwwds_25_tfauditaction_sel, lV97Core_auditwwds_26_tfauditshortdescription, AV98Core_auditwwds_27_tfauditshortdescription_sel, lV99Core_auditwwds_28_tfauditdescription, AV100Core_auditwwds_29_tfauditdescription_sel, lV101Core_auditwwds_30_tfauditgamusername, AV102Core_auditwwds_31_tfauditgamusername_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A495AuditTime = P007M2_A495AuditTime[0];
            A496AuditDateTime = P007M2_A496AuditDateTime[0];
            A494AuditDate = P007M2_A494AuditDate[0];
            A501AuditGAMUserName = P007M2_A501AuditGAMUserName[0];
            A498AuditDescription = P007M2_A498AuditDescription[0];
            A499AuditShortDescription = P007M2_A499AuditShortDescription[0];
            A502AuditAction = P007M2_A502AuditAction[0];
            A497AuditTableName = P007M2_A497AuditTableName[0];
            A493AuditID = P007M2_A493AuditID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H7M0( false, 66) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A496AuditDateTime, "99/99/9999 99:99:99.999"), 30, Gx_line+10, 86, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A494AuditDate, "99/99/99"), 90, Gx_line+10, 146, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A495AuditTime, "99:99"), 150, Gx_line+10, 206, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A497AuditTableName, "")), 210, Gx_line+10, 322, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A502AuditAction, "")), 326, Gx_line+10, 438, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A499AuditShortDescription, "")), 442, Gx_line+10, 554, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(A498AuditDescription, 558, Gx_line+10, 670, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A501AuditGAMUserName, "@!")), 674, Gx_line+10, 787, Gx_line+55, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawLine(28, Gx_line+65, 789, Gx_line+65, 1, 220, 220, 220, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+66);
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
         if ( StringUtil.StrCmp(AV33Session.Get("core.AuditWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.AuditWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("core.AuditWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV103GXV1 = 1;
         while ( AV103GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV103GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITDATETIME") == 0 )
            {
               AV66TFAuditDateTime = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 2);
               AV67TFAuditDateTime_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITDATE") == 0 )
            {
               AV37TFAuditDate = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Value, 2);
               AV38TFAuditDate_To = context.localUtil.CToD( AV36GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITTIME") == 0 )
            {
               AV39TFAuditTime = DateTimeUtil.ResetDate(context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 2));
               AV40TFAuditTime_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME") == 0 )
            {
               AV41TFAuditTableName = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITTABLENAME_SEL") == 0 )
            {
               AV42TFAuditTableName_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITACTION") == 0 )
            {
               AV49TFAuditAction = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITACTION_SEL") == 0 )
            {
               AV50TFAuditAction_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION") == 0 )
            {
               AV43TFAuditShortDescription = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITSHORTDESCRIPTION_SEL") == 0 )
            {
               AV44TFAuditShortDescription_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION") == 0 )
            {
               AV45TFAuditDescription = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITDESCRIPTION_SEL") == 0 )
            {
               AV46TFAuditDescription_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME") == 0 )
            {
               AV47TFAuditGAMUserName = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFAUDITGAMUSERNAME_SEL") == 0 )
            {
               AV48TFAuditGAMUserName_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV103GXV1 = (int)(AV103GXV1+1);
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

      protected void H7M0( bool bFoot ,
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
                  AV62PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV59DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV57AppName = "DVelop Software Solutions";
               AV63Phone = "+1 550 8923";
               AV61Mail = "info@mail.com";
               AV65Website = "http://www.web.com";
               AV54AddressLine1 = "French Boulevard 2859";
               AV55AddressLine2 = "Downtown";
               AV56AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV57AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV64Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV18AuditDate1 = DateTime.MinValue;
         AV19AuditDate_To1 = DateTime.MinValue;
         AV16FixedValueOperatorDsc = "";
         AV20FilterAuditDateDescription = "";
         AV21AuditDate = DateTime.MinValue;
         AV17FixedValueOperatorValue = "";
         AV23DynamicFiltersSelector2 = "";
         AV25AuditDate2 = DateTime.MinValue;
         AV26AuditDate_To2 = DateTime.MinValue;
         AV28DynamicFiltersSelector3 = "";
         AV30AuditDate3 = DateTime.MinValue;
         AV31AuditDate_To3 = DateTime.MinValue;
         AV66TFAuditDateTime = (DateTime)(DateTime.MinValue);
         AV67TFAuditDateTime_To = (DateTime)(DateTime.MinValue);
         AV68TFAuditDateTime_To_Description = "";
         AV37TFAuditDate = DateTime.MinValue;
         AV38TFAuditDate_To = DateTime.MinValue;
         AV51TFAuditDate_To_Description = "";
         AV39TFAuditTime = (DateTime)(DateTime.MinValue);
         AV40TFAuditTime_To = (DateTime)(DateTime.MinValue);
         AV52TFAuditTime_To_Description = "";
         AV42TFAuditTableName_Sel = "";
         AV41TFAuditTableName = "";
         AV50TFAuditAction_Sel = "";
         AV49TFAuditAction = "";
         AV44TFAuditShortDescription_Sel = "";
         AV43TFAuditShortDescription = "";
         AV46TFAuditDescription_Sel = "";
         AV45TFAuditDescription = "";
         AV48TFAuditGAMUserName_Sel = "";
         AV47TFAuditGAMUserName = "";
         AV72Core_auditwwds_1_filterfulltext = "";
         AV73Core_auditwwds_2_dynamicfiltersselector1 = "";
         AV75Core_auditwwds_4_auditdate1 = DateTime.MinValue;
         AV76Core_auditwwds_5_auditdate_to1 = DateTime.MinValue;
         AV78Core_auditwwds_7_dynamicfiltersselector2 = "";
         AV80Core_auditwwds_9_auditdate2 = DateTime.MinValue;
         AV81Core_auditwwds_10_auditdate_to2 = DateTime.MinValue;
         AV83Core_auditwwds_12_dynamicfiltersselector3 = "";
         AV85Core_auditwwds_14_auditdate3 = DateTime.MinValue;
         AV86Core_auditwwds_15_auditdate_to3 = DateTime.MinValue;
         AV87Core_auditwwds_16_tfauditdatetime = (DateTime)(DateTime.MinValue);
         AV88Core_auditwwds_17_tfauditdatetime_to = (DateTime)(DateTime.MinValue);
         AV89Core_auditwwds_18_tfauditdate = DateTime.MinValue;
         AV90Core_auditwwds_19_tfauditdate_to = DateTime.MinValue;
         AV91Core_auditwwds_20_tfaudittime = (DateTime)(DateTime.MinValue);
         AV92Core_auditwwds_21_tfaudittime_to = (DateTime)(DateTime.MinValue);
         AV93Core_auditwwds_22_tfaudittablename = "";
         AV94Core_auditwwds_23_tfaudittablename_sel = "";
         AV95Core_auditwwds_24_tfauditaction = "";
         AV96Core_auditwwds_25_tfauditaction_sel = "";
         AV97Core_auditwwds_26_tfauditshortdescription = "";
         AV98Core_auditwwds_27_tfauditshortdescription_sel = "";
         AV99Core_auditwwds_28_tfauditdescription = "";
         AV100Core_auditwwds_29_tfauditdescription_sel = "";
         AV101Core_auditwwds_30_tfauditgamusername = "";
         AV102Core_auditwwds_31_tfauditgamusername_sel = "";
         scmdbuf = "";
         lV72Core_auditwwds_1_filterfulltext = "";
         lV93Core_auditwwds_22_tfaudittablename = "";
         lV95Core_auditwwds_24_tfauditaction = "";
         lV97Core_auditwwds_26_tfauditshortdescription = "";
         lV99Core_auditwwds_28_tfauditdescription = "";
         lV101Core_auditwwds_30_tfauditgamusername = "";
         A497AuditTableName = "";
         A502AuditAction = "";
         A499AuditShortDescription = "";
         A498AuditDescription = "";
         A501AuditGAMUserName = "";
         A494AuditDate = DateTime.MinValue;
         A496AuditDateTime = (DateTime)(DateTime.MinValue);
         A495AuditTime = (DateTime)(DateTime.MinValue);
         P007M2_A495AuditTime = new DateTime[] {DateTime.MinValue} ;
         P007M2_A496AuditDateTime = new DateTime[] {DateTime.MinValue} ;
         P007M2_A494AuditDate = new DateTime[] {DateTime.MinValue} ;
         P007M2_A501AuditGAMUserName = new string[] {""} ;
         P007M2_A498AuditDescription = new string[] {""} ;
         P007M2_A499AuditShortDescription = new string[] {""} ;
         P007M2_A502AuditAction = new string[] {""} ;
         P007M2_A497AuditTableName = new string[] {""} ;
         P007M2_A493AuditID = new Guid[] {Guid.Empty} ;
         A493AuditID = Guid.Empty;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV62PageInfo = "";
         AV59DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV57AppName = "";
         AV63Phone = "";
         AV61Mail = "";
         AV65Website = "";
         AV54AddressLine1 = "";
         AV55AddressLine2 = "";
         AV56AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.auditwwexportreport__default(),
            new Object[][] {
                new Object[] {
               P007M2_A495AuditTime, P007M2_A496AuditDateTime, P007M2_A494AuditDate, P007M2_A501AuditGAMUserName, P007M2_A498AuditDescription, P007M2_A499AuditShortDescription, P007M2_A502AuditAction, P007M2_A497AuditTableName, P007M2_A493AuditID
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
      private short AV24DynamicFiltersOperator2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV74Core_auditwwds_3_dynamicfiltersoperator1 ;
      private short AV79Core_auditwwds_8_dynamicfiltersoperator2 ;
      private short AV84Core_auditwwds_13_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV103GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV66TFAuditDateTime ;
      private DateTime AV67TFAuditDateTime_To ;
      private DateTime AV39TFAuditTime ;
      private DateTime AV40TFAuditTime_To ;
      private DateTime AV87Core_auditwwds_16_tfauditdatetime ;
      private DateTime AV88Core_auditwwds_17_tfauditdatetime_to ;
      private DateTime AV91Core_auditwwds_20_tfaudittime ;
      private DateTime AV92Core_auditwwds_21_tfaudittime_to ;
      private DateTime A496AuditDateTime ;
      private DateTime A495AuditTime ;
      private DateTime AV18AuditDate1 ;
      private DateTime AV19AuditDate_To1 ;
      private DateTime AV21AuditDate ;
      private DateTime AV25AuditDate2 ;
      private DateTime AV26AuditDate_To2 ;
      private DateTime AV30AuditDate3 ;
      private DateTime AV31AuditDate_To3 ;
      private DateTime AV37TFAuditDate ;
      private DateTime AV38TFAuditDate_To ;
      private DateTime AV75Core_auditwwds_4_auditdate1 ;
      private DateTime AV76Core_auditwwds_5_auditdate_to1 ;
      private DateTime AV80Core_auditwwds_9_auditdate2 ;
      private DateTime AV81Core_auditwwds_10_auditdate_to2 ;
      private DateTime AV85Core_auditwwds_14_auditdate3 ;
      private DateTime AV86Core_auditwwds_15_auditdate_to3 ;
      private DateTime AV89Core_auditwwds_18_tfauditdate ;
      private DateTime AV90Core_auditwwds_19_tfauditdate_to ;
      private DateTime A494AuditDate ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV53TempBoolean ;
      private bool AV77Core_auditwwds_6_dynamicfiltersenabled2 ;
      private bool AV82Core_auditwwds_11_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string A498AuditDescription ;
      private string AV64Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16FixedValueOperatorDsc ;
      private string AV20FilterAuditDateDescription ;
      private string AV17FixedValueOperatorValue ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV68TFAuditDateTime_To_Description ;
      private string AV51TFAuditDate_To_Description ;
      private string AV52TFAuditTime_To_Description ;
      private string AV42TFAuditTableName_Sel ;
      private string AV41TFAuditTableName ;
      private string AV50TFAuditAction_Sel ;
      private string AV49TFAuditAction ;
      private string AV44TFAuditShortDescription_Sel ;
      private string AV43TFAuditShortDescription ;
      private string AV46TFAuditDescription_Sel ;
      private string AV45TFAuditDescription ;
      private string AV48TFAuditGAMUserName_Sel ;
      private string AV47TFAuditGAMUserName ;
      private string AV72Core_auditwwds_1_filterfulltext ;
      private string AV73Core_auditwwds_2_dynamicfiltersselector1 ;
      private string AV78Core_auditwwds_7_dynamicfiltersselector2 ;
      private string AV83Core_auditwwds_12_dynamicfiltersselector3 ;
      private string AV93Core_auditwwds_22_tfaudittablename ;
      private string AV94Core_auditwwds_23_tfaudittablename_sel ;
      private string AV95Core_auditwwds_24_tfauditaction ;
      private string AV96Core_auditwwds_25_tfauditaction_sel ;
      private string AV97Core_auditwwds_26_tfauditshortdescription ;
      private string AV98Core_auditwwds_27_tfauditshortdescription_sel ;
      private string AV99Core_auditwwds_28_tfauditdescription ;
      private string AV100Core_auditwwds_29_tfauditdescription_sel ;
      private string AV101Core_auditwwds_30_tfauditgamusername ;
      private string AV102Core_auditwwds_31_tfauditgamusername_sel ;
      private string lV72Core_auditwwds_1_filterfulltext ;
      private string lV93Core_auditwwds_22_tfaudittablename ;
      private string lV95Core_auditwwds_24_tfauditaction ;
      private string lV97Core_auditwwds_26_tfauditshortdescription ;
      private string lV99Core_auditwwds_28_tfauditdescription ;
      private string lV101Core_auditwwds_30_tfauditgamusername ;
      private string A497AuditTableName ;
      private string A502AuditAction ;
      private string A499AuditShortDescription ;
      private string A501AuditGAMUserName ;
      private string AV62PageInfo ;
      private string AV59DateInfo ;
      private string AV57AppName ;
      private string AV63Phone ;
      private string AV61Mail ;
      private string AV65Website ;
      private string AV54AddressLine1 ;
      private string AV55AddressLine2 ;
      private string AV56AddressLine3 ;
      private Guid A493AuditID ;
      private IGxSession AV33Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P007M2_A495AuditTime ;
      private DateTime[] P007M2_A496AuditDateTime ;
      private DateTime[] P007M2_A494AuditDate ;
      private string[] P007M2_A501AuditGAMUserName ;
      private string[] P007M2_A498AuditDescription ;
      private string[] P007M2_A499AuditShortDescription ;
      private string[] P007M2_A502AuditAction ;
      private string[] P007M2_A497AuditTableName ;
      private Guid[] P007M2_A493AuditID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class auditwwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P007M2( IGxContext context ,
                                             string AV72Core_auditwwds_1_filterfulltext ,
                                             string AV73Core_auditwwds_2_dynamicfiltersselector1 ,
                                             short AV74Core_auditwwds_3_dynamicfiltersoperator1 ,
                                             DateTime AV75Core_auditwwds_4_auditdate1 ,
                                             DateTime AV76Core_auditwwds_5_auditdate_to1 ,
                                             bool AV77Core_auditwwds_6_dynamicfiltersenabled2 ,
                                             string AV78Core_auditwwds_7_dynamicfiltersselector2 ,
                                             short AV79Core_auditwwds_8_dynamicfiltersoperator2 ,
                                             DateTime AV80Core_auditwwds_9_auditdate2 ,
                                             DateTime AV81Core_auditwwds_10_auditdate_to2 ,
                                             bool AV82Core_auditwwds_11_dynamicfiltersenabled3 ,
                                             string AV83Core_auditwwds_12_dynamicfiltersselector3 ,
                                             short AV84Core_auditwwds_13_dynamicfiltersoperator3 ,
                                             DateTime AV85Core_auditwwds_14_auditdate3 ,
                                             DateTime AV86Core_auditwwds_15_auditdate_to3 ,
                                             DateTime AV87Core_auditwwds_16_tfauditdatetime ,
                                             DateTime AV88Core_auditwwds_17_tfauditdatetime_to ,
                                             DateTime AV89Core_auditwwds_18_tfauditdate ,
                                             DateTime AV90Core_auditwwds_19_tfauditdate_to ,
                                             DateTime AV91Core_auditwwds_20_tfaudittime ,
                                             DateTime AV92Core_auditwwds_21_tfaudittime_to ,
                                             string AV94Core_auditwwds_23_tfaudittablename_sel ,
                                             string AV93Core_auditwwds_22_tfaudittablename ,
                                             string AV96Core_auditwwds_25_tfauditaction_sel ,
                                             string AV95Core_auditwwds_24_tfauditaction ,
                                             string AV98Core_auditwwds_27_tfauditshortdescription_sel ,
                                             string AV97Core_auditwwds_26_tfauditshortdescription ,
                                             string AV100Core_auditwwds_29_tfauditdescription_sel ,
                                             string AV99Core_auditwwds_28_tfauditdescription ,
                                             string AV102Core_auditwwds_31_tfauditgamusername_sel ,
                                             string AV101Core_auditwwds_30_tfauditgamusername ,
                                             string A497AuditTableName ,
                                             string A502AuditAction ,
                                             string A499AuditShortDescription ,
                                             string A498AuditDescription ,
                                             string A501AuditGAMUserName ,
                                             DateTime A494AuditDate ,
                                             DateTime A496AuditDateTime ,
                                             DateTime A495AuditTime ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[36];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT AuditTime, AuditDateTime, AuditDate, AuditGAMUserName, AuditDescription, AuditShortDescription, AuditAction, AuditTableName, AuditID FROM tb_audit";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_auditwwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( AuditTableName like '%' || :lV72Core_auditwwds_1_filterfulltext) or ( AuditAction like '%' || :lV72Core_auditwwds_1_filterfulltext) or ( AuditShortDescription like '%' || :lV72Core_auditwwds_1_filterfulltext) or ( AuditDescription like '%' || :lV72Core_auditwwds_1_filterfulltext) or ( AuditGAMUserName like '%' || :lV72Core_auditwwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV74Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV75Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV74Core_auditwwds_3_dynamicfiltersoperator1 == 0 ) && ( ! (DateTime.MinValue==AV76Core_auditwwds_5_auditdate_to1) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV76Core_auditwwds_5_auditdate_to1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV74Core_auditwwds_3_dynamicfiltersoperator1 == 1 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV75Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV74Core_auditwwds_3_dynamicfiltersoperator1 == 2 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV75Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV73Core_auditwwds_2_dynamicfiltersselector1, "AUDITDATE") == 0 ) && ( AV74Core_auditwwds_3_dynamicfiltersoperator1 == 3 ) && ( ! (DateTime.MinValue==AV75Core_auditwwds_4_auditdate1) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV75Core_auditwwds_4_auditdate1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV77Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV79Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV80Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV77Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV79Core_auditwwds_8_dynamicfiltersoperator2 == 0 ) && ( ! (DateTime.MinValue==AV81Core_auditwwds_10_auditdate_to2) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV81Core_auditwwds_10_auditdate_to2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV77Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV79Core_auditwwds_8_dynamicfiltersoperator2 == 1 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV80Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV77Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV79Core_auditwwds_8_dynamicfiltersoperator2 == 2 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV80Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV77Core_auditwwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV78Core_auditwwds_7_dynamicfiltersselector2, "AUDITDATE") == 0 ) && ( AV79Core_auditwwds_8_dynamicfiltersoperator2 == 3 ) && ( ! (DateTime.MinValue==AV80Core_auditwwds_9_auditdate2) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV80Core_auditwwds_9_auditdate2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV82Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV84Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV85Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV85Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV82Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV84Core_auditwwds_13_dynamicfiltersoperator3 == 0 ) && ( ! (DateTime.MinValue==AV86Core_auditwwds_15_auditdate_to3) ) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV86Core_auditwwds_15_auditdate_to3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV82Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV84Core_auditwwds_13_dynamicfiltersoperator3 == 1 ) && ( ! (DateTime.MinValue==AV85Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate < :AV85Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV82Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV84Core_auditwwds_13_dynamicfiltersoperator3 == 2 ) && ( ! (DateTime.MinValue==AV85Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate = :AV85Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV82Core_auditwwds_11_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV83Core_auditwwds_12_dynamicfiltersselector3, "AUDITDATE") == 0 ) && ( AV84Core_auditwwds_13_dynamicfiltersoperator3 == 3 ) && ( ! (DateTime.MinValue==AV85Core_auditwwds_14_auditdate3) ) )
         {
            AddWhere(sWhereString, "(AuditDate > :AV85Core_auditwwds_14_auditdate3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! (DateTime.MinValue==AV87Core_auditwwds_16_tfauditdatetime) )
         {
            AddWhere(sWhereString, "(AuditDateTime >= :AV87Core_auditwwds_16_tfauditdatetime)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! (DateTime.MinValue==AV88Core_auditwwds_17_tfauditdatetime_to) )
         {
            AddWhere(sWhereString, "(AuditDateTime <= :AV88Core_auditwwds_17_tfauditdatetime_to)");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( ! (DateTime.MinValue==AV89Core_auditwwds_18_tfauditdate) )
         {
            AddWhere(sWhereString, "(AuditDate >= :AV89Core_auditwwds_18_tfauditdate)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! (DateTime.MinValue==AV90Core_auditwwds_19_tfauditdate_to) )
         {
            AddWhere(sWhereString, "(AuditDate <= :AV90Core_auditwwds_19_tfauditdate_to)");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( ! (DateTime.MinValue==AV91Core_auditwwds_20_tfaudittime) )
         {
            AddWhere(sWhereString, "(AuditTime >= :AV91Core_auditwwds_20_tfaudittime)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (DateTime.MinValue==AV92Core_auditwwds_21_tfaudittime_to) )
         {
            AddWhere(sWhereString, "(AuditTime <= :AV92Core_auditwwds_21_tfaudittime_to)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_23_tfaudittablename_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_auditwwds_22_tfaudittablename)) ) )
         {
            AddWhere(sWhereString, "(AuditTableName like :lV93Core_auditwwds_22_tfaudittablename)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV94Core_auditwwds_23_tfaudittablename_sel)) && ! ( StringUtil.StrCmp(AV94Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditTableName = ( :AV94Core_auditwwds_23_tfaudittablename_sel))");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( StringUtil.StrCmp(AV94Core_auditwwds_23_tfaudittablename_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditTableName))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_25_tfauditaction_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV95Core_auditwwds_24_tfauditaction)) ) )
         {
            AddWhere(sWhereString, "(AuditAction like :lV95Core_auditwwds_24_tfauditaction)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV96Core_auditwwds_25_tfauditaction_sel)) && ! ( StringUtil.StrCmp(AV96Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditAction = ( :AV96Core_auditwwds_25_tfauditaction_sel))");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( StringUtil.StrCmp(AV96Core_auditwwds_25_tfauditaction_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditAction))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_auditwwds_27_tfauditshortdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV97Core_auditwwds_26_tfauditshortdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription like :lV97Core_auditwwds_26_tfauditshortdescription)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV98Core_auditwwds_27_tfauditshortdescription_sel)) && ! ( StringUtil.StrCmp(AV98Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditShortDescription = ( :AV98Core_auditwwds_27_tfauditshortdescription_sel))");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( StringUtil.StrCmp(AV98Core_auditwwds_27_tfauditshortdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditShortDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_auditwwds_29_tfauditdescription_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV99Core_auditwwds_28_tfauditdescription)) ) )
         {
            AddWhere(sWhereString, "(AuditDescription like :lV99Core_auditwwds_28_tfauditdescription)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV100Core_auditwwds_29_tfauditdescription_sel)) && ! ( StringUtil.StrCmp(AV100Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditDescription = ( :AV100Core_auditwwds_29_tfauditdescription_sel))");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( StringUtil.StrCmp(AV100Core_auditwwds_29_tfauditdescription_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditDescription))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_auditwwds_31_tfauditgamusername_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_auditwwds_30_tfauditgamusername)) ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName like :lV101Core_auditwwds_30_tfauditgamusername)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV102Core_auditwwds_31_tfauditgamusername_sel)) && ! ( StringUtil.StrCmp(AV102Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(AuditGAMUserName = ( :AV102Core_auditwwds_31_tfauditgamusername_sel))");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( StringUtil.StrCmp(AV102Core_auditwwds_31_tfauditgamusername_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from AuditGAMUserName))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDateTime";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDateTime DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDate";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDate DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditTime";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditTime DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditTableName";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditTableName DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditAction";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditAction DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditShortDescription";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditShortDescription DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditDescription";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditDescription DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY AuditGAMUserName";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY AuditGAMUserName DESC";
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
                     return conditional_P007M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (DateTime)dynConstraints[3] , (DateTime)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (DateTime)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (string)dynConstraints[31] , (string)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (DateTime)dynConstraints[36] , (DateTime)dynConstraints[37] , (DateTime)dynConstraints[38] , (short)dynConstraints[39] , (bool)dynConstraints[40] );
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
          Object[] prmP007M2;
          prmP007M2 = new Object[] {
          new ParDef("lV72Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_auditwwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV75Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV76Core_auditwwds_5_auditdate_to1",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV75Core_auditwwds_4_auditdate1",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV81Core_auditwwds_10_auditdate_to2",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV80Core_auditwwds_9_auditdate2",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV86Core_auditwwds_15_auditdate_to3",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV85Core_auditwwds_14_auditdate3",GXType.Date,8,0) ,
          new ParDef("AV87Core_auditwwds_16_tfauditdatetime",GXType.DateTime2,10,12) ,
          new ParDef("AV88Core_auditwwds_17_tfauditdatetime_to",GXType.DateTime2,10,12) ,
          new ParDef("AV89Core_auditwwds_18_tfauditdate",GXType.Date,8,0) ,
          new ParDef("AV90Core_auditwwds_19_tfauditdate_to",GXType.Date,8,0) ,
          new ParDef("AV91Core_auditwwds_20_tfaudittime",GXType.DateTime,0,5) ,
          new ParDef("AV92Core_auditwwds_21_tfaudittime_to",GXType.DateTime,0,5) ,
          new ParDef("lV93Core_auditwwds_22_tfaudittablename",GXType.VarChar,80,0) ,
          new ParDef("AV94Core_auditwwds_23_tfaudittablename_sel",GXType.VarChar,80,0) ,
          new ParDef("lV95Core_auditwwds_24_tfauditaction",GXType.VarChar,40,0) ,
          new ParDef("AV96Core_auditwwds_25_tfauditaction_sel",GXType.VarChar,40,0) ,
          new ParDef("lV97Core_auditwwds_26_tfauditshortdescription",GXType.VarChar,400,0) ,
          new ParDef("AV98Core_auditwwds_27_tfauditshortdescription_sel",GXType.VarChar,400,0) ,
          new ParDef("lV99Core_auditwwds_28_tfauditdescription",GXType.VarChar,200,0) ,
          new ParDef("AV100Core_auditwwds_29_tfauditdescription_sel",GXType.VarChar,200,0) ,
          new ParDef("lV101Core_auditwwds_30_tfauditgamusername",GXType.VarChar,80,0) ,
          new ParDef("AV102Core_auditwwds_31_tfauditgamusername_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P007M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP007M2,100, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1);
                ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
                ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
                ((string[]) buf[5])[0] = rslt.getVarchar(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((Guid[]) buf[8])[0] = rslt.getGuid(9);
                return;
       }
    }

 }

}
