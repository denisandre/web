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
   public class visitawwexportreport : GXWebProcedure
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

      public visitawwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitawwexportreport( IGxContext context )
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
         visitawwexportreport objvisitawwexportreport;
         objvisitawwexportreport = new visitawwexportreport();
         objvisitawwexportreport.context.SetSubmitInitialConfig(context);
         objvisitawwexportreport.initialize();
         Submit( executePrivateCatch,objvisitawwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((visitawwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("VisitaWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "visitaww_Execute", out  GXt_boolean1) ;
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
               AV91Title = "Lista de Visita";
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
            H6E0( true, 0) ;
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
         if ( ! (Guid.Empty==AV115VisNegID_Filtro) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(AV115VisNegID_Filtro.ToString(), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV116VisNgfSeq_Filtro) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV116VisNgfSeq_Filtro), "ZZ,ZZZ,ZZ9")), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (false==AV130VisDel_Filtro) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV130VisDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128VisSituacao)) )
         {
            if ( AV127DynamicFiltersOperatorVisSituacao == 0 )
            {
               AV126FilterVisSituacaoDescription = StringUtil.Format( "%1 (%2)", "Situação", "Igual", "", "", "", "", "", "", "");
            }
            else if ( AV127DynamicFiltersOperatorVisSituacao == 1 )
            {
               AV126FilterVisSituacaoDescription = StringUtil.Format( "%1 (%2)", "Situação", "Diferente", "", "", "", "", "", "", "");
            }
            AV129FilterVisSituacaoValueDescription = GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,AV128VisSituacao);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV126FilterVisSituacaoDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV129FilterVisSituacaoValueDescription, "")), 130, Gx_line+0, 814, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV46TFVisInsDataHora) && (DateTime.MinValue==AV47TFVisInsDataHora_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído em", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV46TFVisInsDataHora, "99/99/9999 99:99:99.999"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV74TFVisInsDataHora_To_Description = StringUtil.Format( "%1 (%2)", "Incluído em", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFVisInsDataHora_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV47TFVisInsDataHora_To, "99/99/9999 99:99:99.999"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFVisInsUsuNome_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV51TFVisInsUsuNome_Sel, "<#Empty#>")==0)));
            AV51TFVisInsUsuNome_Sel = (AV80TempBoolean ? "(Vazio)" : AV51TFVisInsUsuNome_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído por", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFVisInsUsuNome_Sel, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV51TFVisInsUsuNome_Sel = (AV80TempBoolean ? "<#Empty#>" : AV51TFVisInsUsuNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFVisInsUsuNome)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Incluído por", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFVisInsUsuNome, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV52TFVisData) && (DateTime.MinValue==AV53TFVisData_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV52TFVisData, "99/99/99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV75TFVisData_To_Description = StringUtil.Format( "%1 (%2)", "Data", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFVisData_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV53TFVisData_To, "99/99/99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV54TFVisHora) && (DateTime.MinValue==AV55TFVisHora_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Hora", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV54TFVisHora, "99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV76TFVisHora_To_Description = StringUtil.Format( "%1 (%2)", "Hora", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFVisHora_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV55TFVisHora_To, "99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV56TFVisDataHora) && (DateTime.MinValue==AV57TFVisDataHora_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data/Hora", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV56TFVisDataHora, "99/99/9999 99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV77TFVisDataHora_To_Description = StringUtil.Format( "%1 (%2)", "Data/Hora", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFVisDataHora_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV57TFVisDataHora_To, "99/99/9999 99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV117TFVisDataFim) && (DateTime.MinValue==AV118TFVisDataFim_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV117TFVisDataFim, "99/99/99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV123TFVisDataFim_To_Description = StringUtil.Format( "%1 (%2)", "Data", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV123TFVisDataFim_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV118TFVisDataFim_To, "99/99/99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV119TFVisHoraFim) && (DateTime.MinValue==AV120TFVisHoraFim_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Hora", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV119TFVisHoraFim, "99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV124TFVisHoraFim_To_Description = StringUtil.Format( "%1 (%2)", "Hora", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV124TFVisHoraFim_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV120TFVisHoraFim_To, "99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV121TFVisDataHoraFim) && (DateTime.MinValue==AV122TFVisDataHoraFim_To) ) )
         {
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Data/Hora", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV121TFVisDataHoraFim, "99/99/9999 99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV125TFVisDataHoraFim_To_Description = StringUtil.Format( "%1 (%2)", "Data/Hora", "Até", "", "", "", "", "", "", "");
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV125TFVisDataHoraFim_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV122TFVisDataHoraFim_To, "99/99/9999 99:99"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFVisTipoNome_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV63TFVisTipoNome_Sel, "<#Empty#>")==0)));
            AV63TFVisTipoNome_Sel = (AV80TempBoolean ? "(Vazio)" : AV63TFVisTipoNome_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFVisTipoNome_Sel, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV63TFVisTipoNome_Sel = (AV80TempBoolean ? "<#Empty#>" : AV63TFVisTipoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFVisTipoNome)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFVisTipoNome, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFVisAssunto_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV69TFVisAssunto_Sel, "<#Empty#>")==0)));
            AV69TFVisAssunto_Sel = (AV80TempBoolean ? "(Vazio)" : AV69TFVisAssunto_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Assunto", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFVisAssunto_Sel, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV69TFVisAssunto_Sel = (AV80TempBoolean ? "<#Empty#>" : AV69TFVisAssunto_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFVisAssunto)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Assunto", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFVisAssunto, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         AV111TFVisSituacao_Sels.FromJSonString(AV109TFVisSituacao_SelsJson, null);
         if ( ! ( AV111TFVisSituacao_Sels.Count == 0 ) )
         {
            AV114i = 1;
            AV133GXV1 = 1;
            while ( AV133GXV1 <= AV111TFVisSituacao_Sels.Count )
            {
               AV112TFVisSituacao_Sel = ((string)AV111TFVisSituacao_Sels.Item(AV133GXV1));
               if ( AV114i == 1 )
               {
                  AV110TFVisSituacao_SelDscs = "";
               }
               else
               {
                  AV110TFVisSituacao_SelDscs += ", ";
               }
               AV113FilterTFVisSituacao_SelValueDescription = GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,AV112TFVisSituacao_Sel);
               AV110TFVisSituacao_SelDscs += AV113FilterTFVisSituacao_SelValueDescription;
               AV114i = (long)(AV114i+1);
               AV133GXV1 = (int)(AV133GXV1+1);
            }
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Situação", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110TFVisSituacao_SelDscs, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71TFVisLink_Sel)) )
         {
            AV80TempBoolean = (bool)(((StringUtil.StrCmp(AV71TFVisLink_Sel, "<#Empty#>")==0)));
            AV71TFVisLink_Sel = (AV80TempBoolean ? "(Vazio)" : AV71TFVisLink_Sel);
            H6E0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Link de Acesso", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71TFVisLink_Sel, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV71TFVisLink_Sel = (AV80TempBoolean ? "<#Empty#>" : AV71TFVisLink_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFVisLink)) )
            {
               H6E0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Link de Acesso", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFVisLink, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6E0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6E0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Incluído em", 30, Gx_line+10, 89, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído por", 93, Gx_line+10, 152, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data", 156, Gx_line+10, 215, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Hora", 219, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data/Hora", 282, Gx_line+10, 341, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data", 345, Gx_line+10, 404, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Hora", 408, Gx_line+10, 467, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Data/Hora", 471, Gx_line+10, 530, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 534, Gx_line+10, 593, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Assunto", 597, Gx_line+10, 657, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Situação", 661, Gx_line+10, 722, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Link de Acesso", 726, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV135Core_visitawwds_1_visnegid_filtro = AV115VisNegID_Filtro;
         AV136Core_visitawwds_2_visngfseq_filtro = AV116VisNgfSeq_Filtro;
         AV137Core_visitawwds_3_visdel_filtro = AV130VisDel_Filtro;
         AV138Core_visitawwds_4_vissituacao = AV128VisSituacao;
         AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao = AV127DynamicFiltersOperatorVisSituacao;
         AV140Core_visitawwds_6_tfvisinsdatahora = AV46TFVisInsDataHora;
         AV141Core_visitawwds_7_tfvisinsdatahora_to = AV47TFVisInsDataHora_To;
         AV142Core_visitawwds_8_tfvisinsusunome = AV50TFVisInsUsuNome;
         AV143Core_visitawwds_9_tfvisinsusunome_sel = AV51TFVisInsUsuNome_Sel;
         AV144Core_visitawwds_10_tfvisdata = AV52TFVisData;
         AV145Core_visitawwds_11_tfvisdata_to = AV53TFVisData_To;
         AV146Core_visitawwds_12_tfvishora = AV54TFVisHora;
         AV147Core_visitawwds_13_tfvishora_to = AV55TFVisHora_To;
         AV148Core_visitawwds_14_tfvisdatahora = AV56TFVisDataHora;
         AV149Core_visitawwds_15_tfvisdatahora_to = AV57TFVisDataHora_To;
         AV150Core_visitawwds_16_tfvisdatafim = AV117TFVisDataFim;
         AV151Core_visitawwds_17_tfvisdatafim_to = AV118TFVisDataFim_To;
         AV152Core_visitawwds_18_tfvishorafim = AV119TFVisHoraFim;
         AV153Core_visitawwds_19_tfvishorafim_to = AV120TFVisHoraFim_To;
         AV154Core_visitawwds_20_tfvisdatahorafim = AV121TFVisDataHoraFim;
         AV155Core_visitawwds_21_tfvisdatahorafim_to = AV122TFVisDataHoraFim_To;
         AV156Core_visitawwds_22_tfvistiponome = AV62TFVisTipoNome;
         AV157Core_visitawwds_23_tfvistiponome_sel = AV63TFVisTipoNome_Sel;
         AV158Core_visitawwds_24_tfvisassunto = AV68TFVisAssunto;
         AV159Core_visitawwds_25_tfvisassunto_sel = AV69TFVisAssunto_Sel;
         AV160Core_visitawwds_26_tfvissituacao_sels = AV111TFVisSituacao_Sels;
         AV161Core_visitawwds_27_tfvislink = AV70TFVisLink;
         AV162Core_visitawwds_28_tfvislink_sel = AV71TFVisLink_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              A472VisSituacao ,
                                              AV160Core_visitawwds_26_tfvissituacao_sels ,
                                              AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                              AV138Core_visitawwds_4_vissituacao ,
                                              AV140Core_visitawwds_6_tfvisinsdatahora ,
                                              AV141Core_visitawwds_7_tfvisinsdatahora_to ,
                                              AV143Core_visitawwds_9_tfvisinsusunome_sel ,
                                              AV142Core_visitawwds_8_tfvisinsusunome ,
                                              AV144Core_visitawwds_10_tfvisdata ,
                                              AV145Core_visitawwds_11_tfvisdata_to ,
                                              AV146Core_visitawwds_12_tfvishora ,
                                              AV147Core_visitawwds_13_tfvishora_to ,
                                              AV148Core_visitawwds_14_tfvisdatahora ,
                                              AV149Core_visitawwds_15_tfvisdatahora_to ,
                                              AV150Core_visitawwds_16_tfvisdatafim ,
                                              AV151Core_visitawwds_17_tfvisdatafim_to ,
                                              AV152Core_visitawwds_18_tfvishorafim ,
                                              AV153Core_visitawwds_19_tfvishorafim_to ,
                                              AV154Core_visitawwds_20_tfvisdatahorafim ,
                                              AV155Core_visitawwds_21_tfvisdatahorafim_to ,
                                              AV157Core_visitawwds_23_tfvistiponome_sel ,
                                              AV156Core_visitawwds_22_tfvistiponome ,
                                              AV159Core_visitawwds_25_tfvisassunto_sel ,
                                              AV158Core_visitawwds_24_tfvisassunto ,
                                              AV160Core_visitawwds_26_tfvissituacao_sels.Count ,
                                              AV162Core_visitawwds_28_tfvislink_sel ,
                                              AV161Core_visitawwds_27_tfvislink ,
                                              A401VisInsDataHora ,
                                              A403VisInsUsuNome ,
                                              A404VisData ,
                                              A405VisHora ,
                                              A406VisDataHora ,
                                              A475VisDataFim ,
                                              A476VisHoraFim ,
                                              A477VisDataHoraFim ,
                                              A416VisTipoNome ,
                                              A409VisAssunto ,
                                              A417VisLink ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A487VisDel ,
                                              AV105VisNegID ,
                                              AV106VisNgfSeq ,
                                              A418VisNegID ,
                                              A422VisNgfSeq } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.INT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.DATE,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.INT, TypeConstants.BOOLEAN
                                              }
         });
         lV142Core_visitawwds_8_tfvisinsusunome = StringUtil.Concat( StringUtil.RTrim( AV142Core_visitawwds_8_tfvisinsusunome), "%", "");
         lV156Core_visitawwds_22_tfvistiponome = StringUtil.Concat( StringUtil.RTrim( AV156Core_visitawwds_22_tfvistiponome), "%", "");
         lV158Core_visitawwds_24_tfvisassunto = StringUtil.Concat( StringUtil.RTrim( AV158Core_visitawwds_24_tfvisassunto), "%", "");
         lV161Core_visitawwds_27_tfvislink = StringUtil.Concat( StringUtil.RTrim( AV161Core_visitawwds_27_tfvislink), "%", "");
         /* Using cursor P006E2 */
         pr_default.execute(0, new Object[] {AV105VisNegID, AV106VisNgfSeq, AV138Core_visitawwds_4_vissituacao, AV138Core_visitawwds_4_vissituacao, AV140Core_visitawwds_6_tfvisinsdatahora, AV141Core_visitawwds_7_tfvisinsdatahora_to, lV142Core_visitawwds_8_tfvisinsusunome, AV143Core_visitawwds_9_tfvisinsusunome_sel, AV144Core_visitawwds_10_tfvisdata, AV145Core_visitawwds_11_tfvisdata_to, AV146Core_visitawwds_12_tfvishora, AV147Core_visitawwds_13_tfvishora_to, AV148Core_visitawwds_14_tfvisdatahora, AV149Core_visitawwds_15_tfvisdatahora_to, AV150Core_visitawwds_16_tfvisdatafim, AV151Core_visitawwds_17_tfvisdatafim_to, AV152Core_visitawwds_18_tfvishorafim, AV153Core_visitawwds_19_tfvishorafim_to, AV154Core_visitawwds_20_tfvisdatahorafim, AV155Core_visitawwds_21_tfvisdatahorafim_to, lV156Core_visitawwds_22_tfvistiponome, AV157Core_visitawwds_23_tfvistiponome_sel, lV158Core_visitawwds_24_tfvisassunto, AV159Core_visitawwds_25_tfvisassunto_sel, lV161Core_visitawwds_27_tfvislink, AV162Core_visitawwds_28_tfvislink_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A414VisTipoID = P006E2_A414VisTipoID[0];
            A417VisLink = P006E2_A417VisLink[0];
            n417VisLink = P006E2_n417VisLink[0];
            A409VisAssunto = P006E2_A409VisAssunto[0];
            A416VisTipoNome = P006E2_A416VisTipoNome[0];
            A477VisDataHoraFim = P006E2_A477VisDataHoraFim[0];
            n477VisDataHoraFim = P006E2_n477VisDataHoraFim[0];
            A476VisHoraFim = P006E2_A476VisHoraFim[0];
            n476VisHoraFim = P006E2_n476VisHoraFim[0];
            A475VisDataFim = P006E2_A475VisDataFim[0];
            n475VisDataFim = P006E2_n475VisDataFim[0];
            A406VisDataHora = P006E2_A406VisDataHora[0];
            A405VisHora = P006E2_A405VisHora[0];
            A404VisData = P006E2_A404VisData[0];
            A403VisInsUsuNome = P006E2_A403VisInsUsuNome[0];
            n403VisInsUsuNome = P006E2_n403VisInsUsuNome[0];
            A401VisInsDataHora = P006E2_A401VisInsDataHora[0];
            A472VisSituacao = P006E2_A472VisSituacao[0];
            A487VisDel = P006E2_A487VisDel[0];
            A422VisNgfSeq = P006E2_A422VisNgfSeq[0];
            n422VisNgfSeq = P006E2_n422VisNgfSeq[0];
            A418VisNegID = P006E2_A418VisNegID[0];
            n418VisNegID = P006E2_n418VisNegID[0];
            A398VisID = P006E2_A398VisID[0];
            A416VisTipoNome = P006E2_A416VisTipoNome[0];
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A472VisSituacao)) )
            {
               AV108VisSituacaoDescription = GeneXus.Programs.core.gxdomainvisitastatus.getDescription(context,A472VisSituacao);
            }
            else
            {
               AV108VisSituacaoDescription = "";
            }
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6E0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( A401VisInsDataHora, "99/99/9999 99:99:99.999"), 30, Gx_line+10, 89, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A403VisInsUsuNome, "@!")), 93, Gx_line+10, 152, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A404VisData, "99/99/99"), 156, Gx_line+10, 215, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A405VisHora, "99:99"), 219, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A406VisDataHora, "99/99/9999 99:99"), 282, Gx_line+10, 341, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A475VisDataFim, "99/99/99"), 345, Gx_line+10, 404, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A476VisHoraFim, "99:99"), 408, Gx_line+10, 467, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A477VisDataHoraFim, "99/99/9999 99:99"), 471, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A416VisTipoNome, "@!")), 534, Gx_line+10, 593, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A409VisAssunto, "")), 597, Gx_line+10, 657, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108VisSituacaoDescription, "")), 661, Gx_line+10, 722, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A417VisLink, "")), 726, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV38Session.Get("core.VisitaWWGridState"), "") == 0 )
         {
            AV40GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.VisitaWWGridState"), null, "", "");
         }
         else
         {
            AV40GridState.FromXml(AV38Session.Get("core.VisitaWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV40GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV40GridState.gxTpr_Ordereddsc;
         AV163GXV2 = 1;
         while ( AV163GXV2 <= AV40GridState.gxTpr_Filtervalues.Count )
         {
            AV41GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV40GridState.gxTpr_Filtervalues.Item(AV163GXV2));
            if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "VISNEGID_FILTRO") == 0 )
            {
               AV115VisNegID_Filtro = StringUtil.StrToGuid( AV41GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "VISNGFSEQ_FILTRO") == 0 )
            {
               AV116VisNgfSeq_Filtro = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "VISDEL_FILTRO") == 0 )
            {
               AV130VisDel_Filtro = BooleanUtil.Val( AV41GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "VISSITUACAO") == 0 )
            {
               AV128VisSituacao = AV41GridStateFilterValue.gxTpr_Value;
               AV127DynamicFiltersOperatorVisSituacao = AV41GridStateFilterValue.gxTpr_Operator;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISINSDATAHORA") == 0 )
            {
               AV46TFVisInsDataHora = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV47TFVisInsDataHora_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME") == 0 )
            {
               AV50TFVisInsUsuNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISINSUSUNOME_SEL") == 0 )
            {
               AV51TFVisInsUsuNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISDATA") == 0 )
            {
               AV52TFVisData = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV53TFVisData_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISHORA") == 0 )
            {
               AV54TFVisHora = DateTimeUtil.ResetDate(context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2));
               AV55TFVisHora_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISDATAHORA") == 0 )
            {
               AV56TFVisDataHora = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV57TFVisDataHora_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISDATAFIM") == 0 )
            {
               AV117TFVisDataFim = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV118TFVisDataFim_To = context.localUtil.CToD( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISHORAFIM") == 0 )
            {
               AV119TFVisHoraFim = DateTimeUtil.ResetDate(context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2));
               AV120TFVisHoraFim_To = DateTimeUtil.ResetDate(context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2));
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISDATAHORAFIM") == 0 )
            {
               AV121TFVisDataHoraFim = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Value, 2);
               AV122TFVisDataHoraFim_To = context.localUtil.CToT( AV41GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME") == 0 )
            {
               AV62TFVisTipoNome = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISTIPONOME_SEL") == 0 )
            {
               AV63TFVisTipoNome_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO") == 0 )
            {
               AV68TFVisAssunto = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISASSUNTO_SEL") == 0 )
            {
               AV69TFVisAssunto_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISSITUACAO_SEL") == 0 )
            {
               AV109TFVisSituacao_SelsJson = AV41GridStateFilterValue.gxTpr_Value;
               AV111TFVisSituacao_Sels.FromJSonString(AV109TFVisSituacao_SelsJson, null);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISLINK") == 0 )
            {
               AV70TFVisLink = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "TFVISLINK_SEL") == 0 )
            {
               AV71TFVisLink_Sel = AV41GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&VISNEGID") == 0 )
            {
               AV105VisNegID = StringUtil.StrToGuid( AV41GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV41GridStateFilterValue.gxTpr_Name, "PARM_&VISNGFSEQ") == 0 )
            {
               AV106VisNgfSeq = (int)(Math.Round(NumberUtil.Val( AV41GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            AV163GXV2 = (int)(AV163GXV2+1);
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

      protected void H6E0( bool bFoot ,
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
                  AV89PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV86DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV84AppName = "DVelop Software Solutions";
               AV90Phone = "+1 550 8923";
               AV88Mail = "info@mail.com";
               AV92Website = "http://www.web.com";
               AV81AddressLine1 = "French Boulevard 2859";
               AV82AddressLine2 = "Downtown";
               AV83AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV88Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV81AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV82AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV91Title = "";
         AV115VisNegID_Filtro = Guid.Empty;
         AV128VisSituacao = "PEN";
         AV126FilterVisSituacaoDescription = "";
         AV129FilterVisSituacaoValueDescription = "";
         AV46TFVisInsDataHora = (DateTime)(DateTime.MinValue);
         AV47TFVisInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV74TFVisInsDataHora_To_Description = "";
         AV51TFVisInsUsuNome_Sel = "";
         AV50TFVisInsUsuNome = "";
         AV52TFVisData = DateTime.MinValue;
         AV53TFVisData_To = DateTime.MinValue;
         AV75TFVisData_To_Description = "";
         AV54TFVisHora = (DateTime)(DateTime.MinValue);
         AV55TFVisHora_To = (DateTime)(DateTime.MinValue);
         AV76TFVisHora_To_Description = "";
         AV56TFVisDataHora = (DateTime)(DateTime.MinValue);
         AV57TFVisDataHora_To = (DateTime)(DateTime.MinValue);
         AV77TFVisDataHora_To_Description = "";
         AV117TFVisDataFim = DateTime.MinValue;
         AV118TFVisDataFim_To = DateTime.MinValue;
         AV123TFVisDataFim_To_Description = "";
         AV119TFVisHoraFim = (DateTime)(DateTime.MinValue);
         AV120TFVisHoraFim_To = (DateTime)(DateTime.MinValue);
         AV124TFVisHoraFim_To_Description = "";
         AV121TFVisDataHoraFim = (DateTime)(DateTime.MinValue);
         AV122TFVisDataHoraFim_To = (DateTime)(DateTime.MinValue);
         AV125TFVisDataHoraFim_To_Description = "";
         AV63TFVisTipoNome_Sel = "";
         AV62TFVisTipoNome = "";
         AV69TFVisAssunto_Sel = "";
         AV68TFVisAssunto = "";
         AV111TFVisSituacao_Sels = new GxSimpleCollection<string>();
         AV109TFVisSituacao_SelsJson = "";
         AV112TFVisSituacao_Sel = "PEN";
         AV110TFVisSituacao_SelDscs = "";
         AV113FilterTFVisSituacao_SelValueDescription = "";
         AV71TFVisLink_Sel = "";
         AV70TFVisLink = "";
         AV135Core_visitawwds_1_visnegid_filtro = Guid.Empty;
         AV138Core_visitawwds_4_vissituacao = "";
         AV140Core_visitawwds_6_tfvisinsdatahora = (DateTime)(DateTime.MinValue);
         AV141Core_visitawwds_7_tfvisinsdatahora_to = (DateTime)(DateTime.MinValue);
         AV142Core_visitawwds_8_tfvisinsusunome = "";
         AV143Core_visitawwds_9_tfvisinsusunome_sel = "";
         AV144Core_visitawwds_10_tfvisdata = DateTime.MinValue;
         AV145Core_visitawwds_11_tfvisdata_to = DateTime.MinValue;
         AV146Core_visitawwds_12_tfvishora = (DateTime)(DateTime.MinValue);
         AV147Core_visitawwds_13_tfvishora_to = (DateTime)(DateTime.MinValue);
         AV148Core_visitawwds_14_tfvisdatahora = (DateTime)(DateTime.MinValue);
         AV149Core_visitawwds_15_tfvisdatahora_to = (DateTime)(DateTime.MinValue);
         AV150Core_visitawwds_16_tfvisdatafim = DateTime.MinValue;
         AV151Core_visitawwds_17_tfvisdatafim_to = DateTime.MinValue;
         AV152Core_visitawwds_18_tfvishorafim = (DateTime)(DateTime.MinValue);
         AV153Core_visitawwds_19_tfvishorafim_to = (DateTime)(DateTime.MinValue);
         AV154Core_visitawwds_20_tfvisdatahorafim = (DateTime)(DateTime.MinValue);
         AV155Core_visitawwds_21_tfvisdatahorafim_to = (DateTime)(DateTime.MinValue);
         AV156Core_visitawwds_22_tfvistiponome = "";
         AV157Core_visitawwds_23_tfvistiponome_sel = "";
         AV158Core_visitawwds_24_tfvisassunto = "";
         AV159Core_visitawwds_25_tfvisassunto_sel = "";
         AV160Core_visitawwds_26_tfvissituacao_sels = new GxSimpleCollection<string>();
         AV161Core_visitawwds_27_tfvislink = "";
         AV162Core_visitawwds_28_tfvislink_sel = "";
         scmdbuf = "";
         lV142Core_visitawwds_8_tfvisinsusunome = "";
         lV156Core_visitawwds_22_tfvistiponome = "";
         lV158Core_visitawwds_24_tfvisassunto = "";
         lV161Core_visitawwds_27_tfvislink = "";
         A472VisSituacao = "";
         A401VisInsDataHora = (DateTime)(DateTime.MinValue);
         A403VisInsUsuNome = "";
         A404VisData = DateTime.MinValue;
         A405VisHora = (DateTime)(DateTime.MinValue);
         A406VisDataHora = (DateTime)(DateTime.MinValue);
         A475VisDataFim = DateTime.MinValue;
         A476VisHoraFim = (DateTime)(DateTime.MinValue);
         A477VisDataHoraFim = (DateTime)(DateTime.MinValue);
         A416VisTipoNome = "";
         A409VisAssunto = "";
         A417VisLink = "";
         AV105VisNegID = Guid.Empty;
         A418VisNegID = Guid.Empty;
         P006E2_A414VisTipoID = new int[1] ;
         P006E2_A417VisLink = new string[] {""} ;
         P006E2_n417VisLink = new bool[] {false} ;
         P006E2_A409VisAssunto = new string[] {""} ;
         P006E2_A416VisTipoNome = new string[] {""} ;
         P006E2_A477VisDataHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006E2_n477VisDataHoraFim = new bool[] {false} ;
         P006E2_A476VisHoraFim = new DateTime[] {DateTime.MinValue} ;
         P006E2_n476VisHoraFim = new bool[] {false} ;
         P006E2_A475VisDataFim = new DateTime[] {DateTime.MinValue} ;
         P006E2_n475VisDataFim = new bool[] {false} ;
         P006E2_A406VisDataHora = new DateTime[] {DateTime.MinValue} ;
         P006E2_A405VisHora = new DateTime[] {DateTime.MinValue} ;
         P006E2_A404VisData = new DateTime[] {DateTime.MinValue} ;
         P006E2_A403VisInsUsuNome = new string[] {""} ;
         P006E2_n403VisInsUsuNome = new bool[] {false} ;
         P006E2_A401VisInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006E2_A472VisSituacao = new string[] {""} ;
         P006E2_A487VisDel = new bool[] {false} ;
         P006E2_A422VisNgfSeq = new int[1] ;
         P006E2_n422VisNgfSeq = new bool[] {false} ;
         P006E2_A418VisNegID = new Guid[] {Guid.Empty} ;
         P006E2_n418VisNegID = new bool[] {false} ;
         P006E2_A398VisID = new Guid[] {Guid.Empty} ;
         A398VisID = Guid.Empty;
         AV108VisSituacaoDescription = "";
         AV38Session = context.GetSession();
         AV40GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV41GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV89PageInfo = "";
         AV86DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV84AppName = "";
         AV90Phone = "";
         AV88Mail = "";
         AV92Website = "";
         AV81AddressLine1 = "";
         AV82AddressLine2 = "";
         AV83AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitawwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006E2_A414VisTipoID, P006E2_A417VisLink, P006E2_n417VisLink, P006E2_A409VisAssunto, P006E2_A416VisTipoNome, P006E2_A477VisDataHoraFim, P006E2_n477VisDataHoraFim, P006E2_A476VisHoraFim, P006E2_n476VisHoraFim, P006E2_A475VisDataFim,
               P006E2_n475VisDataFim, P006E2_A406VisDataHora, P006E2_A405VisHora, P006E2_A404VisData, P006E2_A403VisInsUsuNome, P006E2_n403VisInsUsuNome, P006E2_A401VisInsDataHora, P006E2_A472VisSituacao, P006E2_A487VisDel, P006E2_A422VisNgfSeq,
               P006E2_n422VisNgfSeq, P006E2_A418VisNegID, P006E2_n418VisNegID, P006E2_A398VisID
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
      private short AV127DynamicFiltersOperatorVisSituacao ;
      private short AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV116VisNgfSeq_Filtro ;
      private int AV133GXV1 ;
      private int AV136Core_visitawwds_2_visngfseq_filtro ;
      private int AV160Core_visitawwds_26_tfvissituacao_sels_Count ;
      private int AV106VisNgfSeq ;
      private int A422VisNgfSeq ;
      private int A414VisTipoID ;
      private int AV163GXV2 ;
      private long AV114i ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV46TFVisInsDataHora ;
      private DateTime AV47TFVisInsDataHora_To ;
      private DateTime AV54TFVisHora ;
      private DateTime AV55TFVisHora_To ;
      private DateTime AV56TFVisDataHora ;
      private DateTime AV57TFVisDataHora_To ;
      private DateTime AV119TFVisHoraFim ;
      private DateTime AV120TFVisHoraFim_To ;
      private DateTime AV121TFVisDataHoraFim ;
      private DateTime AV122TFVisDataHoraFim_To ;
      private DateTime AV140Core_visitawwds_6_tfvisinsdatahora ;
      private DateTime AV141Core_visitawwds_7_tfvisinsdatahora_to ;
      private DateTime AV146Core_visitawwds_12_tfvishora ;
      private DateTime AV147Core_visitawwds_13_tfvishora_to ;
      private DateTime AV148Core_visitawwds_14_tfvisdatahora ;
      private DateTime AV149Core_visitawwds_15_tfvisdatahora_to ;
      private DateTime AV152Core_visitawwds_18_tfvishorafim ;
      private DateTime AV153Core_visitawwds_19_tfvishorafim_to ;
      private DateTime AV154Core_visitawwds_20_tfvisdatahorafim ;
      private DateTime AV155Core_visitawwds_21_tfvisdatahorafim_to ;
      private DateTime A401VisInsDataHora ;
      private DateTime A405VisHora ;
      private DateTime A406VisDataHora ;
      private DateTime A476VisHoraFim ;
      private DateTime A477VisDataHoraFim ;
      private DateTime AV52TFVisData ;
      private DateTime AV53TFVisData_To ;
      private DateTime AV117TFVisDataFim ;
      private DateTime AV118TFVisDataFim_To ;
      private DateTime AV144Core_visitawwds_10_tfvisdata ;
      private DateTime AV145Core_visitawwds_11_tfvisdata_to ;
      private DateTime AV150Core_visitawwds_16_tfvisdatafim ;
      private DateTime AV151Core_visitawwds_17_tfvisdatafim_to ;
      private DateTime A404VisData ;
      private DateTime A475VisDataFim ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV130VisDel_Filtro ;
      private bool AV80TempBoolean ;
      private bool AV137Core_visitawwds_3_visdel_filtro ;
      private bool AV12OrderedDsc ;
      private bool A487VisDel ;
      private bool n417VisLink ;
      private bool n477VisDataHoraFim ;
      private bool n476VisHoraFim ;
      private bool n475VisDataFim ;
      private bool n403VisInsUsuNome ;
      private bool n422VisNgfSeq ;
      private bool n418VisNegID ;
      private string AV109TFVisSituacao_SelsJson ;
      private string AV91Title ;
      private string AV128VisSituacao ;
      private string AV126FilterVisSituacaoDescription ;
      private string AV129FilterVisSituacaoValueDescription ;
      private string AV74TFVisInsDataHora_To_Description ;
      private string AV51TFVisInsUsuNome_Sel ;
      private string AV50TFVisInsUsuNome ;
      private string AV75TFVisData_To_Description ;
      private string AV76TFVisHora_To_Description ;
      private string AV77TFVisDataHora_To_Description ;
      private string AV123TFVisDataFim_To_Description ;
      private string AV124TFVisHoraFim_To_Description ;
      private string AV125TFVisDataHoraFim_To_Description ;
      private string AV63TFVisTipoNome_Sel ;
      private string AV62TFVisTipoNome ;
      private string AV69TFVisAssunto_Sel ;
      private string AV68TFVisAssunto ;
      private string AV112TFVisSituacao_Sel ;
      private string AV110TFVisSituacao_SelDscs ;
      private string AV113FilterTFVisSituacao_SelValueDescription ;
      private string AV71TFVisLink_Sel ;
      private string AV70TFVisLink ;
      private string AV138Core_visitawwds_4_vissituacao ;
      private string AV142Core_visitawwds_8_tfvisinsusunome ;
      private string AV143Core_visitawwds_9_tfvisinsusunome_sel ;
      private string AV156Core_visitawwds_22_tfvistiponome ;
      private string AV157Core_visitawwds_23_tfvistiponome_sel ;
      private string AV158Core_visitawwds_24_tfvisassunto ;
      private string AV159Core_visitawwds_25_tfvisassunto_sel ;
      private string AV161Core_visitawwds_27_tfvislink ;
      private string AV162Core_visitawwds_28_tfvislink_sel ;
      private string lV142Core_visitawwds_8_tfvisinsusunome ;
      private string lV156Core_visitawwds_22_tfvistiponome ;
      private string lV158Core_visitawwds_24_tfvisassunto ;
      private string lV161Core_visitawwds_27_tfvislink ;
      private string A472VisSituacao ;
      private string A403VisInsUsuNome ;
      private string A416VisTipoNome ;
      private string A409VisAssunto ;
      private string A417VisLink ;
      private string AV108VisSituacaoDescription ;
      private string AV89PageInfo ;
      private string AV86DateInfo ;
      private string AV84AppName ;
      private string AV90Phone ;
      private string AV88Mail ;
      private string AV92Website ;
      private string AV81AddressLine1 ;
      private string AV82AddressLine2 ;
      private string AV83AddressLine3 ;
      private Guid AV115VisNegID_Filtro ;
      private Guid AV135Core_visitawwds_1_visnegid_filtro ;
      private Guid AV105VisNegID ;
      private Guid A418VisNegID ;
      private Guid A398VisID ;
      private IGxSession AV38Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006E2_A414VisTipoID ;
      private string[] P006E2_A417VisLink ;
      private bool[] P006E2_n417VisLink ;
      private string[] P006E2_A409VisAssunto ;
      private string[] P006E2_A416VisTipoNome ;
      private DateTime[] P006E2_A477VisDataHoraFim ;
      private bool[] P006E2_n477VisDataHoraFim ;
      private DateTime[] P006E2_A476VisHoraFim ;
      private bool[] P006E2_n476VisHoraFim ;
      private DateTime[] P006E2_A475VisDataFim ;
      private bool[] P006E2_n475VisDataFim ;
      private DateTime[] P006E2_A406VisDataHora ;
      private DateTime[] P006E2_A405VisHora ;
      private DateTime[] P006E2_A404VisData ;
      private string[] P006E2_A403VisInsUsuNome ;
      private bool[] P006E2_n403VisInsUsuNome ;
      private DateTime[] P006E2_A401VisInsDataHora ;
      private string[] P006E2_A472VisSituacao ;
      private bool[] P006E2_A487VisDel ;
      private int[] P006E2_A422VisNgfSeq ;
      private bool[] P006E2_n422VisNgfSeq ;
      private Guid[] P006E2_A418VisNegID ;
      private bool[] P006E2_n418VisNegID ;
      private Guid[] P006E2_A398VisID ;
      private GxSimpleCollection<string> AV111TFVisSituacao_Sels ;
      private GxSimpleCollection<string> AV160Core_visitawwds_26_tfvissituacao_sels ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV40GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV41GridStateFilterValue ;
   }

   public class visitawwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006E2( IGxContext context ,
                                             string A472VisSituacao ,
                                             GxSimpleCollection<string> AV160Core_visitawwds_26_tfvissituacao_sels ,
                                             short AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao ,
                                             string AV138Core_visitawwds_4_vissituacao ,
                                             DateTime AV140Core_visitawwds_6_tfvisinsdatahora ,
                                             DateTime AV141Core_visitawwds_7_tfvisinsdatahora_to ,
                                             string AV143Core_visitawwds_9_tfvisinsusunome_sel ,
                                             string AV142Core_visitawwds_8_tfvisinsusunome ,
                                             DateTime AV144Core_visitawwds_10_tfvisdata ,
                                             DateTime AV145Core_visitawwds_11_tfvisdata_to ,
                                             DateTime AV146Core_visitawwds_12_tfvishora ,
                                             DateTime AV147Core_visitawwds_13_tfvishora_to ,
                                             DateTime AV148Core_visitawwds_14_tfvisdatahora ,
                                             DateTime AV149Core_visitawwds_15_tfvisdatahora_to ,
                                             DateTime AV150Core_visitawwds_16_tfvisdatafim ,
                                             DateTime AV151Core_visitawwds_17_tfvisdatafim_to ,
                                             DateTime AV152Core_visitawwds_18_tfvishorafim ,
                                             DateTime AV153Core_visitawwds_19_tfvishorafim_to ,
                                             DateTime AV154Core_visitawwds_20_tfvisdatahorafim ,
                                             DateTime AV155Core_visitawwds_21_tfvisdatahorafim_to ,
                                             string AV157Core_visitawwds_23_tfvistiponome_sel ,
                                             string AV156Core_visitawwds_22_tfvistiponome ,
                                             string AV159Core_visitawwds_25_tfvisassunto_sel ,
                                             string AV158Core_visitawwds_24_tfvisassunto ,
                                             int AV160Core_visitawwds_26_tfvissituacao_sels_Count ,
                                             string AV162Core_visitawwds_28_tfvislink_sel ,
                                             string AV161Core_visitawwds_27_tfvislink ,
                                             DateTime A401VisInsDataHora ,
                                             string A403VisInsUsuNome ,
                                             DateTime A404VisData ,
                                             DateTime A405VisHora ,
                                             DateTime A406VisDataHora ,
                                             DateTime A475VisDataFim ,
                                             DateTime A476VisHoraFim ,
                                             DateTime A477VisDataHoraFim ,
                                             string A416VisTipoNome ,
                                             string A409VisAssunto ,
                                             string A417VisLink ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A487VisDel ,
                                             Guid AV105VisNegID ,
                                             int AV106VisNgfSeq ,
                                             Guid A418VisNegID ,
                                             int A422VisNgfSeq )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[26];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.VisTipoID AS VisTipoID, T1.VisLink, T1.VisAssunto, T2.VitNome AS VisTipoNome, T1.VisDataHoraFim, T1.VisHoraFim, T1.VisDataFim, T1.VisDataHora, T1.VisHora, T1.VisData, T1.VisInsUsuNome, T1.VisInsDataHora, T1.VisSituacao, T1.VisDel, T1.VisNgfSeq, T1.VisNegID, T1.VisID FROM (tb_visita T1 INNER JOIN tb_visitatipo T2 ON T2.VitID = T1.VisTipoID)";
         AddWhere(sWhereString, "(T1.VisNegID = :AV105VisNegID and T1.VisNgfSeq = :AV106VisNgfSeq)");
         AddWhere(sWhereString, "(Not T1.VisDel)");
         if ( ( AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao = ( :AV138Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( AV139Core_visitawwds_5_dynamicfiltersoperatorvissituacao == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_visitawwds_4_vissituacao)) ) )
         {
            AddWhere(sWhereString, "(T1.VisSituacao <> ( :AV138Core_visitawwds_4_vissituacao))");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ! (DateTime.MinValue==AV140Core_visitawwds_6_tfvisinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora >= :AV140Core_visitawwds_6_tfvisinsdatahora)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ! (DateTime.MinValue==AV141Core_visitawwds_7_tfvisinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisInsDataHora <= :AV141Core_visitawwds_7_tfvisinsdatahora_to)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_visitawwds_9_tfvisinsusunome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_visitawwds_8_tfvisinsusunome)) ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome like :lV142Core_visitawwds_8_tfvisinsusunome)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_visitawwds_9_tfvisinsusunome_sel)) && ! ( StringUtil.StrCmp(AV143Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome = ( :AV143Core_visitawwds_9_tfvisinsusunome_sel))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV143Core_visitawwds_9_tfvisinsusunome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisInsUsuNome IS NULL or (char_length(trim(trailing ' ' from T1.VisInsUsuNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV144Core_visitawwds_10_tfvisdata) )
         {
            AddWhere(sWhereString, "(T1.VisData >= :AV144Core_visitawwds_10_tfvisdata)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! (DateTime.MinValue==AV145Core_visitawwds_11_tfvisdata_to) )
         {
            AddWhere(sWhereString, "(T1.VisData <= :AV145Core_visitawwds_11_tfvisdata_to)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( ! (DateTime.MinValue==AV146Core_visitawwds_12_tfvishora) )
         {
            AddWhere(sWhereString, "(T1.VisHora >= :AV146Core_visitawwds_12_tfvishora)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! (DateTime.MinValue==AV147Core_visitawwds_13_tfvishora_to) )
         {
            AddWhere(sWhereString, "(T1.VisHora <= :AV147Core_visitawwds_13_tfvishora_to)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( ! (DateTime.MinValue==AV148Core_visitawwds_14_tfvisdatahora) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora >= :AV148Core_visitawwds_14_tfvisdatahora)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV149Core_visitawwds_15_tfvisdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHora <= :AV149Core_visitawwds_15_tfvisdatahora_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( ! (DateTime.MinValue==AV150Core_visitawwds_16_tfvisdatafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim >= :AV150Core_visitawwds_16_tfvisdatafim)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( ! (DateTime.MinValue==AV151Core_visitawwds_17_tfvisdatafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataFim <= :AV151Core_visitawwds_17_tfvisdatafim_to)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! (DateTime.MinValue==AV152Core_visitawwds_18_tfvishorafim) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim >= :AV152Core_visitawwds_18_tfvishorafim)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( ! (DateTime.MinValue==AV153Core_visitawwds_19_tfvishorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisHoraFim <= :AV153Core_visitawwds_19_tfvishorafim_to)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! (DateTime.MinValue==AV154Core_visitawwds_20_tfvisdatahorafim) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim >= :AV154Core_visitawwds_20_tfvisdatahorafim)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( ! (DateTime.MinValue==AV155Core_visitawwds_21_tfvisdatahorafim_to) )
         {
            AddWhere(sWhereString, "(T1.VisDataHoraFim <= :AV155Core_visitawwds_21_tfvisdatahorafim_to)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_visitawwds_23_tfvistiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_visitawwds_22_tfvistiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.VitNome like :lV156Core_visitawwds_22_tfvistiponome)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_visitawwds_23_tfvistiponome_sel)) && ! ( StringUtil.StrCmp(AV157Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.VitNome = ( :AV157Core_visitawwds_23_tfvistiponome_sel))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV157Core_visitawwds_23_tfvistiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.VitNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_visitawwds_25_tfvisassunto_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Core_visitawwds_24_tfvisassunto)) ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto like :lV158Core_visitawwds_24_tfvisassunto)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_visitawwds_25_tfvisassunto_sel)) && ! ( StringUtil.StrCmp(AV159Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisAssunto = ( :AV159Core_visitawwds_25_tfvisassunto_sel))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV159Core_visitawwds_25_tfvisassunto_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.VisAssunto))=0))");
         }
         if ( AV160Core_visitawwds_26_tfvissituacao_sels_Count > 0 )
         {
            AddWhere(sWhereString, "("+new GxDbmsUtils( new GxPostgreSql()).ValueList(AV160Core_visitawwds_26_tfvissituacao_sels, "T1.VisSituacao IN (", ")")+")");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_visitawwds_28_tfvislink_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_visitawwds_27_tfvislink)) ) )
         {
            AddWhere(sWhereString, "(T1.VisLink like :lV161Core_visitawwds_27_tfvislink)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_visitawwds_28_tfvislink_sel)) && ! ( StringUtil.StrCmp(AV162Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.VisLink = ( :AV162Core_visitawwds_28_tfvislink_sel))");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( StringUtil.StrCmp(AV162Core_visitawwds_28_tfvislink_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.VisLink IS NULL or (char_length(trim(trailing ' ' from T1.VisLink))=0))");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.VisNegID, T1.VisDataHora";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisInsDataHora";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisInsDataHora DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisInsUsuNome";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisInsUsuNome DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisData";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisData DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisHora";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisHora DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataHora";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataHora DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataFim";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataFim DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisHoraFim";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisHoraFim DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisDataHoraFim";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisDataHoraFim DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.VitNome";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.VitNome DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisAssunto";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisAssunto DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisSituacao";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisSituacao DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.VisLink";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.VisLink DESC";
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
                     return conditional_P006E2(context, (string)dynConstraints[0] , (GxSimpleCollection<string>)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (DateTime)dynConstraints[4] , (DateTime)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (DateTime)dynConstraints[8] , (DateTime)dynConstraints[9] , (DateTime)dynConstraints[10] , (DateTime)dynConstraints[11] , (DateTime)dynConstraints[12] , (DateTime)dynConstraints[13] , (DateTime)dynConstraints[14] , (DateTime)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (DateTime)dynConstraints[18] , (DateTime)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (int)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (DateTime)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (DateTime)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (DateTime)dynConstraints[33] , (DateTime)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (short)dynConstraints[38] , (bool)dynConstraints[39] , (bool)dynConstraints[40] , (Guid)dynConstraints[41] , (int)dynConstraints[42] , (Guid)dynConstraints[43] , (int)dynConstraints[44] );
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
          Object[] prmP006E2;
          prmP006E2 = new Object[] {
          new ParDef("AV105VisNegID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV106VisNgfSeq",GXType.Int32,8,0) ,
          new ParDef("AV138Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV138Core_visitawwds_4_vissituacao",GXType.VarChar,3,0) ,
          new ParDef("AV140Core_visitawwds_6_tfvisinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV141Core_visitawwds_7_tfvisinsdatahora_to",GXType.DateTime2,10,12) ,
          new ParDef("lV142Core_visitawwds_8_tfvisinsusunome",GXType.VarChar,80,0) ,
          new ParDef("AV143Core_visitawwds_9_tfvisinsusunome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV144Core_visitawwds_10_tfvisdata",GXType.Date,8,0) ,
          new ParDef("AV145Core_visitawwds_11_tfvisdata_to",GXType.Date,8,0) ,
          new ParDef("AV146Core_visitawwds_12_tfvishora",GXType.DateTime,0,5) ,
          new ParDef("AV147Core_visitawwds_13_tfvishora_to",GXType.DateTime,0,5) ,
          new ParDef("AV148Core_visitawwds_14_tfvisdatahora",GXType.DateTime,10,5) ,
          new ParDef("AV149Core_visitawwds_15_tfvisdatahora_to",GXType.DateTime,10,5) ,
          new ParDef("AV150Core_visitawwds_16_tfvisdatafim",GXType.Date,8,0) ,
          new ParDef("AV151Core_visitawwds_17_tfvisdatafim_to",GXType.Date,8,0) ,
          new ParDef("AV152Core_visitawwds_18_tfvishorafim",GXType.DateTime,0,5) ,
          new ParDef("AV153Core_visitawwds_19_tfvishorafim_to",GXType.DateTime,0,5) ,
          new ParDef("AV154Core_visitawwds_20_tfvisdatahorafim",GXType.DateTime,10,5) ,
          new ParDef("AV155Core_visitawwds_21_tfvisdatahorafim_to",GXType.DateTime,10,5) ,
          new ParDef("lV156Core_visitawwds_22_tfvistiponome",GXType.VarChar,80,0) ,
          new ParDef("AV157Core_visitawwds_23_tfvistiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV158Core_visitawwds_24_tfvisassunto",GXType.VarChar,80,0) ,
          new ParDef("AV159Core_visitawwds_25_tfvisassunto_sel",GXType.VarChar,80,0) ,
          new ParDef("lV161Core_visitawwds_27_tfvislink",GXType.VarChar,1000,0) ,
          new ParDef("AV162Core_visitawwds_28_tfvislink_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P006E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006E2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
                ((bool[]) buf[6])[0] = rslt.wasNull(5);
                ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(6);
                ((bool[]) buf[8])[0] = rslt.wasNull(6);
                ((DateTime[]) buf[9])[0] = rslt.getGXDate(7);
                ((bool[]) buf[10])[0] = rslt.wasNull(7);
                ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(8);
                ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
                ((DateTime[]) buf[13])[0] = rslt.getGXDate(10);
                ((string[]) buf[14])[0] = rslt.getVarchar(11);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
                ((string[]) buf[17])[0] = rslt.getVarchar(13);
                ((bool[]) buf[18])[0] = rslt.getBool(14);
                ((int[]) buf[19])[0] = rslt.getInt(15);
                ((bool[]) buf[20])[0] = rslt.wasNull(15);
                ((Guid[]) buf[21])[0] = rslt.getGuid(16);
                ((bool[]) buf[22])[0] = rslt.wasNull(16);
                ((Guid[]) buf[23])[0] = rslt.getGuid(17);
                return;
       }
    }

 }

}
