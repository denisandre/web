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
   public class clientepjcontatowwexportreport : GXWebProcedure
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

      public clientepjcontatowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontatowwexportreport( IGxContext context )
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
         clientepjcontatowwexportreport objclientepjcontatowwexportreport;
         objclientepjcontatowwexportreport = new clientepjcontatowwexportreport();
         objclientepjcontatowwexportreport.context.SetSubmitInitialConfig(context);
         objclientepjcontatowwexportreport.initialize();
         Submit( executePrivateCatch,objclientepjcontatowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((clientepjcontatowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("ClientePJContatoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontatoww_Execute", out  GXt_boolean1) ;
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
               AV99Title = "Lista de Contato";
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
            H5X0( true, 0) ;
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
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV42GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CPJCONNOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV16CpjConNome1 = AV42GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16CpjConNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18CpjConNome = AV16CpjConNome1;
                  H5X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCpjConNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CpjConNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CPJTIPONOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV19CpjTipoNome1 = AV42GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19CpjTipoNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                  }
                  AV21CpjTipoNome = AV19CpjTipoNome1;
                  H5X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCpjTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CpjTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV22CpjConTipoNome1 = AV42GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CpjConTipoNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                  }
                  AV24CpjConTipoNome = AV22CpjConTipoNome1;
                  H5X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterCpjConTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24CpjConTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV42GridStateDynamicFilter.gxTpr_Operator;
               AV25CpjConGenSigla1 = AV42GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25CpjConGenSigla1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                  }
                  AV27CpjConGenSigla = AV25CpjConGenSigla1;
                  H5X0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterCpjConGenSiglaDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27CpjConGenSigla, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV28DynamicFiltersEnabled2 = true;
               AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(2));
               AV29DynamicFiltersSelector2 = AV42GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CPJCONNOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV31CpjConNome2 = AV42GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31CpjConNome2)) )
                  {
                     if ( AV30DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV30DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18CpjConNome = AV31CpjConNome2;
                     H5X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCpjConNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CpjConNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CPJTIPONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV32CpjTipoNome2 = AV42GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32CpjTipoNome2)) )
                  {
                     if ( AV30DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV30DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                     }
                     AV21CpjTipoNome = AV32CpjTipoNome2;
                     H5X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCpjTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CpjTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV33CpjConTipoNome2 = AV42GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33CpjConTipoNome2)) )
                  {
                     if ( AV30DynamicFiltersOperator2 == 0 )
                     {
                        AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV30DynamicFiltersOperator2 == 1 )
                     {
                        AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                     }
                     AV24CpjConTipoNome = AV33CpjConTipoNome2;
                     H5X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterCpjConTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24CpjConTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV29DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 )
               {
                  AV30DynamicFiltersOperator2 = AV42GridStateDynamicFilter.gxTpr_Operator;
                  AV34CpjConGenSigla2 = AV42GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34CpjConGenSigla2)) )
                  {
                     if ( AV30DynamicFiltersOperator2 == 0 )
                     {
                        AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV30DynamicFiltersOperator2 == 1 )
                     {
                        AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                     }
                     AV27CpjConGenSigla = AV34CpjConGenSigla2;
                     H5X0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterCpjConGenSiglaDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27CpjConGenSigla, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV45GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV35DynamicFiltersEnabled3 = true;
                  AV42GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV45GridState.gxTpr_Dynamicfilters.Item(3));
                  AV36DynamicFiltersSelector3 = AV42GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV36DynamicFiltersSelector3, "CPJCONNOME") == 0 )
                  {
                     AV37DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV38CpjConNome3 = AV42GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38CpjConNome3)) )
                     {
                        if ( AV37DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV37DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterCpjConNomeDescription = StringUtil.Format( "%1 (%2)", "Nome do Contato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18CpjConNome = AV38CpjConNome3;
                        H5X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterCpjConNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18CpjConNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector3, "CPJTIPONOME") == 0 )
                  {
                     AV37DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV39CpjTipoNome3 = AV42GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39CpjTipoNome3)) )
                     {
                        if ( AV37DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV37DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterCpjTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo", "Contém", "", "", "", "", "", "", "");
                        }
                        AV21CpjTipoNome = AV39CpjTipoNome3;
                        H5X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterCpjTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21CpjTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 )
                  {
                     AV37DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV40CpjConTipoNome3 = AV42GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40CpjConTipoNome3)) )
                     {
                        if ( AV37DynamicFiltersOperator3 == 0 )
                        {
                           AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV37DynamicFiltersOperator3 == 1 )
                        {
                           AV23FilterCpjConTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Contato", "Contém", "", "", "", "", "", "", "");
                        }
                        AV24CpjConTipoNome = AV40CpjConTipoNome3;
                        H5X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV23FilterCpjConTipoNomeDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV24CpjConTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV36DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 )
                  {
                     AV37DynamicFiltersOperator3 = AV42GridStateDynamicFilter.gxTpr_Operator;
                     AV41CpjConGenSigla3 = AV42GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41CpjConGenSigla3)) )
                     {
                        if ( AV37DynamicFiltersOperator3 == 0 )
                        {
                           AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV37DynamicFiltersOperator3 == 1 )
                        {
                           AV26FilterCpjConGenSiglaDescription = StringUtil.Format( "%1 (%2)", "Gênero", "Contém", "", "", "", "", "", "", "");
                        }
                        AV27CpjConGenSigla = AV41CpjConGenSigla3;
                        H5X0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV26FilterCpjConGenSiglaDescription, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV27CpjConGenSigla, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV48TFCpjConNome_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV48TFCpjConNome_Sel, "<#Empty#>")==0)));
            AV48TFCpjConNome_Sel = (AV88TempBoolean ? "(Vazio)" : AV48TFCpjConNome_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48TFCpjConNome_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV48TFCpjConNome_Sel = (AV88TempBoolean ? "<#Empty#>" : AV48TFCpjConNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV47TFCpjConNome)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47TFCpjConNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCpjConNomePrim_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV50TFCpjConNomePrim_Sel, "<#Empty#>")==0)));
            AV50TFCpjConNomePrim_Sel = (AV88TempBoolean ? "(Vazio)" : AV50TFCpjConNomePrim_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Primeiro Nome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50TFCpjConNomePrim_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV50TFCpjConNomePrim_Sel = (AV88TempBoolean ? "<#Empty#>" : AV50TFCpjConNomePrim_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV49TFCpjConNomePrim)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Primeiro Nome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49TFCpjConNomePrim, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCpjConSobrenome_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV52TFCpjConSobrenome_Sel, "<#Empty#>")==0)));
            AV52TFCpjConSobrenome_Sel = (AV88TempBoolean ? "(Vazio)" : AV52TFCpjConSobrenome_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sobrenome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52TFCpjConSobrenome_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV52TFCpjConSobrenome_Sel = (AV88TempBoolean ? "<#Empty#>" : AV52TFCpjConSobrenome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCpjConSobrenome)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sobrenome", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51TFCpjConSobrenome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCpjConTipoNome_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV54TFCpjConTipoNome_Sel, "<#Empty#>")==0)));
            AV54TFCpjConTipoNome_Sel = (AV88TempBoolean ? "(Vazio)" : AV54TFCpjConTipoNome_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo do Contato", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54TFCpjConTipoNome_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV54TFCpjConTipoNome_Sel = (AV88TempBoolean ? "<#Empty#>" : AV54TFCpjConTipoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCpjConTipoNome)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo do Contato", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFCpjConTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCpjConCPFFormat_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV56TFCpjConCPFFormat_Sel, "<#Empty#>")==0)));
            AV56TFCpjConCPFFormat_Sel = (AV88TempBoolean ? "(Vazio)" : AV56TFCpjConCPFFormat_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CPF", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56TFCpjConCPFFormat_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV56TFCpjConCPFFormat_Sel = (AV88TempBoolean ? "<#Empty#>" : AV56TFCpjConCPFFormat_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCpjConCPFFormat)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CPF", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55TFCpjConCPFFormat, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV57TFCpjConNascimento) && (DateTime.MinValue==AV58TFCpjConNascimento_To) ) )
         {
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Dt. Nascimento", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV57TFCpjConNascimento, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV85TFCpjConNascimento_To_Description = StringUtil.Format( "%1 (%2)", "Dt. Nascimento", "Até", "", "", "", "", "", "", "");
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV85TFCpjConNascimento_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV58TFCpjConNascimento_To, "99/99/99"), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60TFCpjConGenNome_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV60TFCpjConGenNome_Sel, "<#Empty#>")==0)));
            AV60TFCpjConGenNome_Sel = (AV88TempBoolean ? "(Vazio)" : AV60TFCpjConGenNome_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Gênero", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60TFCpjConGenNome_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV60TFCpjConGenNome_Sel = (AV88TempBoolean ? "<#Empty#>" : AV60TFCpjConGenNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59TFCpjConGenNome)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Gênero", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59TFCpjConGenNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV62TFCpjConCelNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV62TFCpjConCelNum_Sel, "<#Empty#>")==0)));
            AV62TFCpjConCelNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV62TFCpjConCelNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Celular", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62TFCpjConCelNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV62TFCpjConCelNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV62TFCpjConCelNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61TFCpjConCelNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Celular", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61TFCpjConCelNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64TFCpjConTelNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV64TFCpjConTelNum_Sel, "<#Empty#>")==0)));
            AV64TFCpjConTelNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV64TFCpjConTelNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64TFCpjConTelNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV64TFCpjConTelNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV64TFCpjConTelNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV63TFCpjConTelNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63TFCpjConTelNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCpjConTelRam_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV66TFCpjConTelRam_Sel, "<#Empty#>")==0)));
            AV66TFCpjConTelRam_Sel = (AV88TempBoolean ? "(Vazio)" : AV66TFCpjConTelRam_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ramal", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66TFCpjConTelRam_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV66TFCpjConTelRam_Sel = (AV88TempBoolean ? "<#Empty#>" : AV66TFCpjConTelRam_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCpjConTelRam)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ramal", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV65TFCpjConTelRam, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV84TFCpjConWppNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV84TFCpjConWppNum_Sel, "<#Empty#>")==0)));
            AV84TFCpjConWppNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV84TFCpjConWppNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("WhatsApp", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV84TFCpjConWppNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV84TFCpjConWppNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV84TFCpjConWppNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCpjConWppNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("WhatsApp", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV83TFCpjConWppNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCpjConEmail_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV68TFCpjConEmail_Sel, "<#Empty#>")==0)));
            AV68TFCpjConEmail_Sel = (AV88TempBoolean ? "(Vazio)" : AV68TFCpjConEmail_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68TFCpjConEmail_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV68TFCpjConEmail_Sel = (AV88TempBoolean ? "<#Empty#>" : AV68TFCpjConEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCpjConEmail)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFCpjConEmail, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCpjConLIn_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV70TFCpjConLIn_Sel, "<#Empty#>")==0)));
            AV70TFCpjConLIn_Sel = (AV88TempBoolean ? "(Vazio)" : AV70TFCpjConLIn_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("LinkedIn", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70TFCpjConLIn_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV70TFCpjConLIn_Sel = (AV88TempBoolean ? "<#Empty#>" : AV70TFCpjConLIn_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCpjConLIn)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("LinkedIn", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69TFCpjConLIn, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCliNomeFamiliar_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV74TFCliNomeFamiliar_Sel, "<#Empty#>")==0)));
            AV74TFCliNomeFamiliar_Sel = (AV88TempBoolean ? "(Vazio)" : AV74TFCliNomeFamiliar_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome Familiar", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV74TFCliNomeFamiliar_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV74TFCliNomeFamiliar_Sel = (AV88TempBoolean ? "<#Empty#>" : AV74TFCliNomeFamiliar_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCliNomeFamiliar)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome Familiar", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV73TFCliNomeFamiliar, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV71TFCliMatricula) && (0==AV72TFCliMatricula_To) ) )
         {
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Matrícula", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV71TFCliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV86TFCliMatricula_To_Description = StringUtil.Format( "%1 (%2)", "Matrícula", "Até", "", "", "", "", "", "", "");
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV86TFCliMatricula_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV72TFCliMatricula_To), "ZZZ,ZZZ,ZZZ,ZZ9")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCpjTipoNome_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV76TFCpjTipoNome_Sel, "<#Empty#>")==0)));
            AV76TFCpjTipoNome_Sel = (AV88TempBoolean ? "(Vazio)" : AV76TFCpjTipoNome_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV76TFCpjTipoNome_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV76TFCpjTipoNome_Sel = (AV88TempBoolean ? "<#Empty#>" : AV76TFCpjTipoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCpjTipoNome)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV75TFCpjTipoNome, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78TFCpjNomeFan_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV78TFCpjNomeFan_Sel, "<#Empty#>")==0)));
            AV78TFCpjNomeFan_Sel = (AV88TempBoolean ? "(Vazio)" : AV78TFCpjNomeFan_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Nome Fantasia", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV78TFCpjNomeFan_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV78TFCpjNomeFan_Sel = (AV88TempBoolean ? "<#Empty#>" : AV78TFCpjNomeFan_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77TFCpjNomeFan)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Nome Fantasia", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV77TFCpjNomeFan, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCpjRazaoSoc_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV80TFCpjRazaoSoc_Sel, "<#Empty#>")==0)));
            AV80TFCpjRazaoSoc_Sel = (AV88TempBoolean ? "(Vazio)" : AV80TFCpjRazaoSoc_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Razão Social", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV80TFCpjRazaoSoc_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV80TFCpjRazaoSoc_Sel = (AV88TempBoolean ? "<#Empty#>" : AV80TFCpjRazaoSoc_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCpjRazaoSoc)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Razão Social", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV79TFCpjRazaoSoc, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV101TFCpjMatricula) && (0==AV102TFCpjMatricula_To) ) )
         {
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Matrícula", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV101TFCpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV119TFCpjMatricula_To_Description = StringUtil.Format( "%1 (%2)", "Matrícula", "Até", "", "", "", "", "", "", "");
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV119TFCpjMatricula_To_Description, "")), 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV102TFCpjMatricula_To), "ZZZ,ZZZ,ZZZ,ZZ9")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104TFCpjCNPJFormat_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV104TFCpjCNPJFormat_Sel, "<#Empty#>")==0)));
            AV104TFCpjCNPJFormat_Sel = (AV88TempBoolean ? "(Vazio)" : AV104TFCpjCNPJFormat_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV104TFCpjCNPJFormat_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV104TFCpjCNPJFormat_Sel = (AV88TempBoolean ? "<#Empty#>" : AV104TFCpjCNPJFormat_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV103TFCpjCNPJFormat)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("CNPJ", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV103TFCpjCNPJFormat, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV106TFCpjIE_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV106TFCpjIE_Sel, "<#Empty#>")==0)));
            AV106TFCpjIE_Sel = (AV88TempBoolean ? "(Vazio)" : AV106TFCpjIE_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("IE", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV106TFCpjIE_Sel, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV106TFCpjIE_Sel = (AV88TempBoolean ? "<#Empty#>" : AV106TFCpjIE_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV105TFCpjIE)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("IE", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV105TFCpjIE, "@!")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108TFCpjCelNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV108TFCpjCelNum_Sel, "<#Empty#>")==0)));
            AV108TFCpjCelNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV108TFCpjCelNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Celular", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV108TFCpjCelNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV108TFCpjCelNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV108TFCpjCelNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV107TFCpjCelNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Celular", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV107TFCpjCelNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV110TFCpjTelNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV110TFCpjTelNum_Sel, "<#Empty#>")==0)));
            AV110TFCpjTelNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV110TFCpjTelNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV110TFCpjTelNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV110TFCpjTelNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV110TFCpjTelNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV109TFCpjTelNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV109TFCpjTelNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112TFCpjTelRam_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV112TFCpjTelRam_Sel, "<#Empty#>")==0)));
            AV112TFCpjTelRam_Sel = (AV88TempBoolean ? "(Vazio)" : AV112TFCpjTelRam_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Ramal do Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV112TFCpjTelRam_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV112TFCpjTelRam_Sel = (AV88TempBoolean ? "<#Empty#>" : AV112TFCpjTelRam_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV111TFCpjTelRam)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Ramal do Telefone", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV111TFCpjTelRam, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114TFCpjWppNum_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV114TFCpjWppNum_Sel, "<#Empty#>")==0)));
            AV114TFCpjWppNum_Sel = (AV88TempBoolean ? "(Vazio)" : AV114TFCpjWppNum_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("WhatsApp", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV114TFCpjWppNum_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV114TFCpjWppNum_Sel = (AV88TempBoolean ? "<#Empty#>" : AV114TFCpjWppNum_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113TFCpjWppNum)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("WhatsApp", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV113TFCpjWppNum, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116TFCpjEmail_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV116TFCpjEmail_Sel, "<#Empty#>")==0)));
            AV116TFCpjEmail_Sel = (AV88TempBoolean ? "(Vazio)" : AV116TFCpjEmail_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV116TFCpjEmail_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV116TFCpjEmail_Sel = (AV88TempBoolean ? "<#Empty#>" : AV116TFCpjEmail_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115TFCpjEmail)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("E-mail", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV115TFCpjEmail, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV118TFCpjWebsite_Sel)) )
         {
            AV88TempBoolean = (bool)(((StringUtil.StrCmp(AV118TFCpjWebsite_Sel, "<#Empty#>")==0)));
            AV118TFCpjWebsite_Sel = (AV88TempBoolean ? "(Vazio)" : AV118TFCpjWebsite_Sel);
            H5X0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Website", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV118TFCpjWebsite_Sel, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV118TFCpjWebsite_Sel = (AV88TempBoolean ? "<#Empty#>" : AV118TFCpjWebsite_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV117TFCpjWebsite)) )
            {
               H5X0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Website", 25, Gx_line+0, 192, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV117TFCpjWebsite, "")), 192, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H5X0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H5X0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Nome", 30, Gx_line+10, 54, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Primeiro Nome", 58, Gx_line+10, 82, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Sobrenome", 86, Gx_line+10, 110, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo do Contato", 114, Gx_line+10, 138, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("CPF", 142, Gx_line+10, 166, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Dt. Nascimento", 170, Gx_line+10, 194, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Gênero", 198, Gx_line+10, 222, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Celular", 226, Gx_line+10, 250, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Telefone", 254, Gx_line+10, 278, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ramal", 282, Gx_line+10, 306, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("WhatsApp", 310, Gx_line+10, 334, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-mail", 338, Gx_line+10, 362, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("LinkedIn", 366, Gx_line+10, 390, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome Familiar", 394, Gx_line+10, 418, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Matrícula", 422, Gx_line+10, 446, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo", 450, Gx_line+10, 474, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Nome Fantasia", 478, Gx_line+10, 502, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Razão Social", 506, Gx_line+10, 530, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Matrícula", 534, Gx_line+10, 558, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("CNPJ", 562, Gx_line+10, 586, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("IE", 590, Gx_line+10, 614, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Celular", 618, Gx_line+10, 642, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Telefone", 646, Gx_line+10, 670, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Ramal do Telefone", 674, Gx_line+10, 698, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("WhatsApp", 702, Gx_line+10, 727, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("E-mail", 731, Gx_line+10, 757, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Website", 761, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV123Core_clientepjcontatowwds_1_filterfulltext = AV13FilterFullText;
         AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV126Core_clientepjcontatowwds_4_cpjconnome1 = AV16CpjConNome1;
         AV127Core_clientepjcontatowwds_5_cpjtiponome1 = AV19CpjTipoNome1;
         AV128Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV129Core_clientepjcontatowwds_7_cpjcongensigla1 = AV25CpjConGenSigla1;
         AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV28DynamicFiltersEnabled2;
         AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV29DynamicFiltersSelector2;
         AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV30DynamicFiltersOperator2;
         AV133Core_clientepjcontatowwds_11_cpjconnome2 = AV31CpjConNome2;
         AV134Core_clientepjcontatowwds_12_cpjtiponome2 = AV32CpjTipoNome2;
         AV135Core_clientepjcontatowwds_13_cpjcontiponome2 = AV33CpjConTipoNome2;
         AV136Core_clientepjcontatowwds_14_cpjcongensigla2 = AV34CpjConGenSigla2;
         AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV35DynamicFiltersEnabled3;
         AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV36DynamicFiltersSelector3;
         AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV37DynamicFiltersOperator3;
         AV140Core_clientepjcontatowwds_18_cpjconnome3 = AV38CpjConNome3;
         AV141Core_clientepjcontatowwds_19_cpjtiponome3 = AV39CpjTipoNome3;
         AV142Core_clientepjcontatowwds_20_cpjcontiponome3 = AV40CpjConTipoNome3;
         AV143Core_clientepjcontatowwds_21_cpjcongensigla3 = AV41CpjConGenSigla3;
         AV144Core_clientepjcontatowwds_22_tfcpjconnome = AV47TFCpjConNome;
         AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV48TFCpjConNome_Sel;
         AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV49TFCpjConNomePrim;
         AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV50TFCpjConNomePrim_Sel;
         AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV51TFCpjConSobrenome;
         AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV52TFCpjConSobrenome_Sel;
         AV150Core_clientepjcontatowwds_28_tfcpjcontiponome = AV53TFCpjConTipoNome;
         AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV54TFCpjConTipoNome_Sel;
         AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV55TFCpjConCPFFormat;
         AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV56TFCpjConCPFFormat_Sel;
         AV154Core_clientepjcontatowwds_32_tfcpjconnascimento = AV57TFCpjConNascimento;
         AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV58TFCpjConNascimento_To;
         AV156Core_clientepjcontatowwds_34_tfcpjcongennome = AV59TFCpjConGenNome;
         AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV60TFCpjConGenNome_Sel;
         AV158Core_clientepjcontatowwds_36_tfcpjconcelnum = AV61TFCpjConCelNum;
         AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV62TFCpjConCelNum_Sel;
         AV160Core_clientepjcontatowwds_38_tfcpjcontelnum = AV63TFCpjConTelNum;
         AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV64TFCpjConTelNum_Sel;
         AV162Core_clientepjcontatowwds_40_tfcpjcontelram = AV65TFCpjConTelRam;
         AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV66TFCpjConTelRam_Sel;
         AV164Core_clientepjcontatowwds_42_tfcpjconwppnum = AV83TFCpjConWppNum;
         AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV84TFCpjConWppNum_Sel;
         AV166Core_clientepjcontatowwds_44_tfcpjconemail = AV67TFCpjConEmail;
         AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV68TFCpjConEmail_Sel;
         AV168Core_clientepjcontatowwds_46_tfcpjconlin = AV69TFCpjConLIn;
         AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV70TFCpjConLIn_Sel;
         AV170Core_clientepjcontatowwds_48_tfclinomefamiliar = AV73TFCliNomeFamiliar;
         AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV74TFCliNomeFamiliar_Sel;
         AV172Core_clientepjcontatowwds_50_tfclimatricula = AV71TFCliMatricula;
         AV173Core_clientepjcontatowwds_51_tfclimatricula_to = AV72TFCliMatricula_To;
         AV174Core_clientepjcontatowwds_52_tfcpjtiponome = AV75TFCpjTipoNome;
         AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV76TFCpjTipoNome_Sel;
         AV176Core_clientepjcontatowwds_54_tfcpjnomefan = AV77TFCpjNomeFan;
         AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV78TFCpjNomeFan_Sel;
         AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV79TFCpjRazaoSoc;
         AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV80TFCpjRazaoSoc_Sel;
         AV180Core_clientepjcontatowwds_58_tfcpjmatricula = AV101TFCpjMatricula;
         AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV102TFCpjMatricula_To;
         AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV103TFCpjCNPJFormat;
         AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV104TFCpjCNPJFormat_Sel;
         AV184Core_clientepjcontatowwds_62_tfcpjie = AV105TFCpjIE;
         AV185Core_clientepjcontatowwds_63_tfcpjie_sel = AV106TFCpjIE_Sel;
         AV186Core_clientepjcontatowwds_64_tfcpjcelnum = AV107TFCpjCelNum;
         AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV108TFCpjCelNum_Sel;
         AV188Core_clientepjcontatowwds_66_tfcpjtelnum = AV109TFCpjTelNum;
         AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV110TFCpjTelNum_Sel;
         AV190Core_clientepjcontatowwds_68_tfcpjtelram = AV111TFCpjTelRam;
         AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV112TFCpjTelRam_Sel;
         AV192Core_clientepjcontatowwds_70_tfcpjwppnum = AV113TFCpjWppNum;
         AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV114TFCpjWppNum_Sel;
         AV194Core_clientepjcontatowwds_72_tfcpjemail = AV115TFCpjEmail;
         AV195Core_clientepjcontatowwds_73_tfcpjemail_sel = AV116TFCpjEmail_Sel;
         AV196Core_clientepjcontatowwds_74_tfcpjwebsite = AV117TFCpjWebsite;
         AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV118TFCpjWebsite_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV123Core_clientepjcontatowwds_1_filterfulltext ,
                                              AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                              AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                              AV126Core_clientepjcontatowwds_4_cpjconnome1 ,
                                              AV127Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                              AV128Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                              AV129Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                              AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                              AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                              AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                              AV133Core_clientepjcontatowwds_11_cpjconnome2 ,
                                              AV134Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                              AV135Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                              AV136Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                              AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                              AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                              AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                              AV140Core_clientepjcontatowwds_18_cpjconnome3 ,
                                              AV141Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                              AV142Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                              AV143Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                              AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                              AV144Core_clientepjcontatowwds_22_tfcpjconnome ,
                                              AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                              AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                              AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                              AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                              AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                              AV150Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                              AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                              AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                              AV154Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                              AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                              AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                              AV156Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                              AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                              AV158Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                              AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                              AV160Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                              AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                              AV162Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                              AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                              AV164Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                              AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                              AV166Core_clientepjcontatowwds_44_tfcpjconemail ,
                                              AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                              AV168Core_clientepjcontatowwds_46_tfcpjconlin ,
                                              AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                              AV170Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                              AV172Core_clientepjcontatowwds_50_tfclimatricula ,
                                              AV173Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                              AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                              AV174Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                              AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                              AV176Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                              AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                              AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                              AV180Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                              AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                              AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                              AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                              AV185Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                              AV184Core_clientepjcontatowwds_62_tfcpjie ,
                                              AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                              AV186Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                              AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                              AV188Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                              AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                              AV190Core_clientepjcontatowwds_68_tfcpjtelram ,
                                              AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                              AV192Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                              AV195Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                              AV194Core_clientepjcontatowwds_72_tfcpjemail ,
                                              AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                              AV196Core_clientepjcontatowwds_74_tfcpjwebsite ,
                                              A275CpjConNome ,
                                              A276CpjConNomePrim ,
                                              A277CpjConSobrenome ,
                                              A272CpjConTipoNome ,
                                              A274CpjConCPFFormat ,
                                              A281CpjConGenNome ,
                                              A285CpjConCelNum ,
                                              A283CpjConTelNum ,
                                              A284CpjConTelRam ,
                                              A286CpjConWppNum ,
                                              A287CpjConEmail ,
                                              A288CpjConLIn ,
                                              A160CliNomeFamiliar ,
                                              A159CliMatricula ,
                                              A367CpjTipoNome ,
                                              A170CpjNomeFan ,
                                              A171CpjRazaoSoc ,
                                              A176CpjMatricula ,
                                              A188CpjCNPJFormat ,
                                              A189CpjIE ,
                                              A263CpjCelNum ,
                                              A261CpjTelNum ,
                                              A262CpjTelRam ,
                                              A264CpjWppNum ,
                                              A266CpjEmail ,
                                              A265CpjWebsite ,
                                              A280CpjConGenSigla ,
                                              A282CpjConNascimento ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV123Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV126Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV127Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV127Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV127Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV127Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV128Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV128Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV128Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV128Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV129Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV129Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV133Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV133Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV133Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV133Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV134Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV134Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV134Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV134Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV135Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV135Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV135Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV135Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV136Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV136Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV140Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV140Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV140Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV140Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV141Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV141Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV141Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV141Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV142Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV142Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV142Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV142Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV143Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV143Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV144Core_clientepjcontatowwds_22_tfcpjconnome = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_22_tfcpjconnome), "%", "");
         lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim = StringUtil.Concat( StringUtil.RTrim( AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim), "%", "");
         lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome = StringUtil.Concat( StringUtil.RTrim( AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome), "%", "");
         lV150Core_clientepjcontatowwds_28_tfcpjcontiponome = StringUtil.Concat( StringUtil.RTrim( AV150Core_clientepjcontatowwds_28_tfcpjcontiponome), "%", "");
         lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat = StringUtil.Concat( StringUtil.RTrim( AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat), "%", "");
         lV156Core_clientepjcontatowwds_34_tfcpjcongennome = StringUtil.Concat( StringUtil.RTrim( AV156Core_clientepjcontatowwds_34_tfcpjcongennome), "%", "");
         lV158Core_clientepjcontatowwds_36_tfcpjconcelnum = StringUtil.PadR( StringUtil.RTrim( AV158Core_clientepjcontatowwds_36_tfcpjconcelnum), 20, "%");
         lV160Core_clientepjcontatowwds_38_tfcpjcontelnum = StringUtil.PadR( StringUtil.RTrim( AV160Core_clientepjcontatowwds_38_tfcpjcontelnum), 20, "%");
         lV162Core_clientepjcontatowwds_40_tfcpjcontelram = StringUtil.Concat( StringUtil.RTrim( AV162Core_clientepjcontatowwds_40_tfcpjcontelram), "%", "");
         lV164Core_clientepjcontatowwds_42_tfcpjconwppnum = StringUtil.PadR( StringUtil.RTrim( AV164Core_clientepjcontatowwds_42_tfcpjconwppnum), 20, "%");
         lV166Core_clientepjcontatowwds_44_tfcpjconemail = StringUtil.Concat( StringUtil.RTrim( AV166Core_clientepjcontatowwds_44_tfcpjconemail), "%", "");
         lV168Core_clientepjcontatowwds_46_tfcpjconlin = StringUtil.Concat( StringUtil.RTrim( AV168Core_clientepjcontatowwds_46_tfcpjconlin), "%", "");
         lV170Core_clientepjcontatowwds_48_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV170Core_clientepjcontatowwds_48_tfclinomefamiliar), "%", "");
         lV174Core_clientepjcontatowwds_52_tfcpjtiponome = StringUtil.Concat( StringUtil.RTrim( AV174Core_clientepjcontatowwds_52_tfcpjtiponome), "%", "");
         lV176Core_clientepjcontatowwds_54_tfcpjnomefan = StringUtil.Concat( StringUtil.RTrim( AV176Core_clientepjcontatowwds_54_tfcpjnomefan), "%", "");
         lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc = StringUtil.Concat( StringUtil.RTrim( AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc), "%", "");
         lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat = StringUtil.Concat( StringUtil.RTrim( AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat), "%", "");
         lV184Core_clientepjcontatowwds_62_tfcpjie = StringUtil.Concat( StringUtil.RTrim( AV184Core_clientepjcontatowwds_62_tfcpjie), "%", "");
         lV186Core_clientepjcontatowwds_64_tfcpjcelnum = StringUtil.PadR( StringUtil.RTrim( AV186Core_clientepjcontatowwds_64_tfcpjcelnum), 20, "%");
         lV188Core_clientepjcontatowwds_66_tfcpjtelnum = StringUtil.PadR( StringUtil.RTrim( AV188Core_clientepjcontatowwds_66_tfcpjtelnum), 20, "%");
         lV190Core_clientepjcontatowwds_68_tfcpjtelram = StringUtil.Concat( StringUtil.RTrim( AV190Core_clientepjcontatowwds_68_tfcpjtelram), "%", "");
         lV192Core_clientepjcontatowwds_70_tfcpjwppnum = StringUtil.PadR( StringUtil.RTrim( AV192Core_clientepjcontatowwds_70_tfcpjwppnum), 20, "%");
         lV194Core_clientepjcontatowwds_72_tfcpjemail = StringUtil.Concat( StringUtil.RTrim( AV194Core_clientepjcontatowwds_72_tfcpjemail), "%", "");
         lV196Core_clientepjcontatowwds_74_tfcpjwebsite = StringUtil.Concat( StringUtil.RTrim( AV196Core_clientepjcontatowwds_74_tfcpjwebsite), "%", "");
         /* Using cursor P005X2 */
         pr_default.execute(0, new Object[] {lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV123Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_4_cpjconnome1, lV126Core_clientepjcontatowwds_4_cpjconnome1, lV127Core_clientepjcontatowwds_5_cpjtiponome1, lV127Core_clientepjcontatowwds_5_cpjtiponome1, lV128Core_clientepjcontatowwds_6_cpjcontiponome1, lV128Core_clientepjcontatowwds_6_cpjcontiponome1, lV129Core_clientepjcontatowwds_7_cpjcongensigla1, lV129Core_clientepjcontatowwds_7_cpjcongensigla1, lV133Core_clientepjcontatowwds_11_cpjconnome2, lV133Core_clientepjcontatowwds_11_cpjconnome2, lV134Core_clientepjcontatowwds_12_cpjtiponome2, lV134Core_clientepjcontatowwds_12_cpjtiponome2, lV135Core_clientepjcontatowwds_13_cpjcontiponome2, lV135Core_clientepjcontatowwds_13_cpjcontiponome2, lV136Core_clientepjcontatowwds_14_cpjcongensigla2, lV136Core_clientepjcontatowwds_14_cpjcongensigla2, lV140Core_clientepjcontatowwds_18_cpjconnome3, lV140Core_clientepjcontatowwds_18_cpjconnome3, lV141Core_clientepjcontatowwds_19_cpjtiponome3, lV141Core_clientepjcontatowwds_19_cpjtiponome3, lV142Core_clientepjcontatowwds_20_cpjcontiponome3, lV142Core_clientepjcontatowwds_20_cpjcontiponome3, lV143Core_clientepjcontatowwds_21_cpjcongensigla3, lV143Core_clientepjcontatowwds_21_cpjcongensigla3, lV144Core_clientepjcontatowwds_22_tfcpjconnome, AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel, lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim, AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome, AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, lV150Core_clientepjcontatowwds_28_tfcpjcontiponome, AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat, AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, AV154Core_clientepjcontatowwds_32_tfcpjconnascimento, AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to, lV156Core_clientepjcontatowwds_34_tfcpjcongennome, AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel, lV158Core_clientepjcontatowwds_36_tfcpjconcelnum, AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, lV160Core_clientepjcontatowwds_38_tfcpjcontelnum, AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, lV162Core_clientepjcontatowwds_40_tfcpjcontelram, AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel, lV164Core_clientepjcontatowwds_42_tfcpjconwppnum, AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, lV166Core_clientepjcontatowwds_44_tfcpjconemail, AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel, lV168Core_clientepjcontatowwds_46_tfcpjconlin, AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel, lV170Core_clientepjcontatowwds_48_tfclinomefamiliar, AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, AV172Core_clientepjcontatowwds_50_tfclimatricula, AV173Core_clientepjcontatowwds_51_tfclimatricula_to, lV174Core_clientepjcontatowwds_52_tfcpjtiponome, AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel, lV176Core_clientepjcontatowwds_54_tfcpjnomefan, AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel, lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc, AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, AV180Core_clientepjcontatowwds_58_tfcpjmatricula, AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to, lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat, AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, lV184Core_clientepjcontatowwds_62_tfcpjie, AV185Core_clientepjcontatowwds_63_tfcpjie_sel, lV186Core_clientepjcontatowwds_64_tfcpjcelnum, AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel, lV188Core_clientepjcontatowwds_66_tfcpjtelnum, AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel, lV190Core_clientepjcontatowwds_68_tfcpjtelram, AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel, lV192Core_clientepjcontatowwds_70_tfcpjwppnum, AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel, lV194Core_clientepjcontatowwds_72_tfcpjemail, AV195Core_clientepjcontatowwds_73_tfcpjemail_sel, lV196Core_clientepjcontatowwds_74_tfcpjwebsite, AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A158CliID = P005X2_A158CliID[0];
            A166CpjID = P005X2_A166CpjID[0];
            A365CpjTipoId = P005X2_A365CpjTipoId[0];
            A176CpjMatricula = P005X2_A176CpjMatricula[0];
            A159CliMatricula = P005X2_A159CliMatricula[0];
            A282CpjConNascimento = P005X2_A282CpjConNascimento[0];
            A280CpjConGenSigla = P005X2_A280CpjConGenSigla[0];
            A265CpjWebsite = P005X2_A265CpjWebsite[0];
            n265CpjWebsite = P005X2_n265CpjWebsite[0];
            A266CpjEmail = P005X2_A266CpjEmail[0];
            n266CpjEmail = P005X2_n266CpjEmail[0];
            A264CpjWppNum = P005X2_A264CpjWppNum[0];
            n264CpjWppNum = P005X2_n264CpjWppNum[0];
            A262CpjTelRam = P005X2_A262CpjTelRam[0];
            n262CpjTelRam = P005X2_n262CpjTelRam[0];
            A261CpjTelNum = P005X2_A261CpjTelNum[0];
            n261CpjTelNum = P005X2_n261CpjTelNum[0];
            A263CpjCelNum = P005X2_A263CpjCelNum[0];
            n263CpjCelNum = P005X2_n263CpjCelNum[0];
            A189CpjIE = P005X2_A189CpjIE[0];
            A188CpjCNPJFormat = P005X2_A188CpjCNPJFormat[0];
            A171CpjRazaoSoc = P005X2_A171CpjRazaoSoc[0];
            A170CpjNomeFan = P005X2_A170CpjNomeFan[0];
            A367CpjTipoNome = P005X2_A367CpjTipoNome[0];
            A160CliNomeFamiliar = P005X2_A160CliNomeFamiliar[0];
            A288CpjConLIn = P005X2_A288CpjConLIn[0];
            n288CpjConLIn = P005X2_n288CpjConLIn[0];
            A287CpjConEmail = P005X2_A287CpjConEmail[0];
            n287CpjConEmail = P005X2_n287CpjConEmail[0];
            A286CpjConWppNum = P005X2_A286CpjConWppNum[0];
            n286CpjConWppNum = P005X2_n286CpjConWppNum[0];
            A284CpjConTelRam = P005X2_A284CpjConTelRam[0];
            n284CpjConTelRam = P005X2_n284CpjConTelRam[0];
            A283CpjConTelNum = P005X2_A283CpjConTelNum[0];
            n283CpjConTelNum = P005X2_n283CpjConTelNum[0];
            A285CpjConCelNum = P005X2_A285CpjConCelNum[0];
            n285CpjConCelNum = P005X2_n285CpjConCelNum[0];
            A281CpjConGenNome = P005X2_A281CpjConGenNome[0];
            A274CpjConCPFFormat = P005X2_A274CpjConCPFFormat[0];
            A272CpjConTipoNome = P005X2_A272CpjConTipoNome[0];
            A277CpjConSobrenome = P005X2_A277CpjConSobrenome[0];
            A276CpjConNomePrim = P005X2_A276CpjConNomePrim[0];
            A275CpjConNome = P005X2_A275CpjConNome[0];
            A269CpjConSeq = P005X2_A269CpjConSeq[0];
            A159CliMatricula = P005X2_A159CliMatricula[0];
            A160CliNomeFamiliar = P005X2_A160CliNomeFamiliar[0];
            A365CpjTipoId = P005X2_A365CpjTipoId[0];
            A176CpjMatricula = P005X2_A176CpjMatricula[0];
            A265CpjWebsite = P005X2_A265CpjWebsite[0];
            n265CpjWebsite = P005X2_n265CpjWebsite[0];
            A266CpjEmail = P005X2_A266CpjEmail[0];
            n266CpjEmail = P005X2_n266CpjEmail[0];
            A264CpjWppNum = P005X2_A264CpjWppNum[0];
            n264CpjWppNum = P005X2_n264CpjWppNum[0];
            A262CpjTelRam = P005X2_A262CpjTelRam[0];
            n262CpjTelRam = P005X2_n262CpjTelRam[0];
            A261CpjTelNum = P005X2_A261CpjTelNum[0];
            n261CpjTelNum = P005X2_n261CpjTelNum[0];
            A263CpjCelNum = P005X2_A263CpjCelNum[0];
            n263CpjCelNum = P005X2_n263CpjCelNum[0];
            A189CpjIE = P005X2_A189CpjIE[0];
            A188CpjCNPJFormat = P005X2_A188CpjCNPJFormat[0];
            A171CpjRazaoSoc = P005X2_A171CpjRazaoSoc[0];
            A170CpjNomeFan = P005X2_A170CpjNomeFan[0];
            A367CpjTipoNome = P005X2_A367CpjTipoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H5X0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A275CpjConNome, "@!")), 30, Gx_line+10, 54, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A276CpjConNomePrim, "@!")), 58, Gx_line+10, 82, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A277CpjConSobrenome, "@!")), 86, Gx_line+10, 110, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A272CpjConTipoNome, "@!")), 114, Gx_line+10, 138, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A274CpjConCPFFormat, "")), 142, Gx_line+10, 166, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A282CpjConNascimento, "99/99/99"), 170, Gx_line+10, 194, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A281CpjConGenNome, "@!")), 198, Gx_line+10, 222, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A285CpjConCelNum, "")), 226, Gx_line+10, 250, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A283CpjConTelNum, "")), 254, Gx_line+10, 278, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A284CpjConTelRam, "")), 282, Gx_line+10, 306, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A286CpjConWppNum, "")), 310, Gx_line+10, 334, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A287CpjConEmail, "")), 338, Gx_line+10, 362, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A288CpjConLIn, "")), 366, Gx_line+10, 390, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")), 394, Gx_line+10, 418, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 422, Gx_line+10, 446, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A367CpjTipoNome, "@!")), 450, Gx_line+10, 474, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A170CpjNomeFan, "@!")), 478, Gx_line+10, 502, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A171CpjRazaoSoc, "@!")), 506, Gx_line+10, 530, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")), 534, Gx_line+10, 558, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A188CpjCNPJFormat, "")), 562, Gx_line+10, 586, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A189CpjIE, "@!")), 590, Gx_line+10, 614, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A263CpjCelNum, "")), 618, Gx_line+10, 642, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A261CpjTelNum, "")), 646, Gx_line+10, 670, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A262CpjTelRam, "")), 674, Gx_line+10, 698, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A264CpjWppNum, "")), 702, Gx_line+10, 727, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A266CpjEmail, "")), 731, Gx_line+10, 757, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A265CpjWebsite, "")), 761, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV43Session.Get("core.ClientePJContatoWWGridState"), "") == 0 )
         {
            AV45GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ClientePJContatoWWGridState"), null, "", "");
         }
         else
         {
            AV45GridState.FromXml(AV43Session.Get("core.ClientePJContatoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV45GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV45GridState.gxTpr_Ordereddsc;
         AV198GXV1 = 1;
         while ( AV198GXV1 <= AV45GridState.gxTpr_Filtervalues.Count )
         {
            AV46GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV45GridState.gxTpr_Filtervalues.Item(AV198GXV1));
            if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME") == 0 )
            {
               AV47TFCpjConNome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME_SEL") == 0 )
            {
               AV48TFCpjConNome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM") == 0 )
            {
               AV49TFCpjConNomePrim = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM_SEL") == 0 )
            {
               AV50TFCpjConNomePrim_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME") == 0 )
            {
               AV51TFCpjConSobrenome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME_SEL") == 0 )
            {
               AV52TFCpjConSobrenome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME") == 0 )
            {
               AV53TFCpjConTipoNome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME_SEL") == 0 )
            {
               AV54TFCpjConTipoNome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT") == 0 )
            {
               AV55TFCpjConCPFFormat = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT_SEL") == 0 )
            {
               AV56TFCpjConCPFFormat_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONNASCIMENTO") == 0 )
            {
               AV57TFCpjConNascimento = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Value, 2);
               AV58TFCpjConNascimento_To = context.localUtil.CToD( AV46GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME") == 0 )
            {
               AV59TFCpjConGenNome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME_SEL") == 0 )
            {
               AV60TFCpjConGenNome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM") == 0 )
            {
               AV61TFCpjConCelNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM_SEL") == 0 )
            {
               AV62TFCpjConCelNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM") == 0 )
            {
               AV63TFCpjConTelNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM_SEL") == 0 )
            {
               AV64TFCpjConTelNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM") == 0 )
            {
               AV65TFCpjConTelRam = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM_SEL") == 0 )
            {
               AV66TFCpjConTelRam_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM") == 0 )
            {
               AV83TFCpjConWppNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM_SEL") == 0 )
            {
               AV84TFCpjConWppNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL") == 0 )
            {
               AV67TFCpjConEmail = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL_SEL") == 0 )
            {
               AV68TFCpjConEmail_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN") == 0 )
            {
               AV69TFCpjConLIn = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN_SEL") == 0 )
            {
               AV70TFCpjConLIn_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV73TFCliNomeFamiliar = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV74TFCliNomeFamiliar_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV71TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV72TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME") == 0 )
            {
               AV75TFCpjTipoNome = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME_SEL") == 0 )
            {
               AV76TFCpjTipoNome_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN") == 0 )
            {
               AV77TFCpjNomeFan = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN_SEL") == 0 )
            {
               AV78TFCpjNomeFan_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC") == 0 )
            {
               AV79TFCpjRazaoSoc = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC_SEL") == 0 )
            {
               AV80TFCpjRazaoSoc_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJMATRICULA") == 0 )
            {
               AV101TFCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV102TFCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV46GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT") == 0 )
            {
               AV103TFCpjCNPJFormat = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT_SEL") == 0 )
            {
               AV104TFCpjCNPJFormat_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJIE") == 0 )
            {
               AV105TFCpjIE = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJIE_SEL") == 0 )
            {
               AV106TFCpjIE_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM") == 0 )
            {
               AV107TFCpjCelNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM_SEL") == 0 )
            {
               AV108TFCpjCelNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM") == 0 )
            {
               AV109TFCpjTelNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM_SEL") == 0 )
            {
               AV110TFCpjTelNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM") == 0 )
            {
               AV111TFCpjTelRam = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM_SEL") == 0 )
            {
               AV112TFCpjTelRam_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM") == 0 )
            {
               AV113TFCpjWppNum = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM_SEL") == 0 )
            {
               AV114TFCpjWppNum_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL") == 0 )
            {
               AV115TFCpjEmail = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL_SEL") == 0 )
            {
               AV116TFCpjEmail_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE") == 0 )
            {
               AV117TFCpjWebsite = AV46GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV46GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE_SEL") == 0 )
            {
               AV118TFCpjWebsite_Sel = AV46GridStateFilterValue.gxTpr_Value;
            }
            AV198GXV1 = (int)(AV198GXV1+1);
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

      protected void H5X0( bool bFoot ,
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
                  AV97PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV94DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV97PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV94DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV92AppName = "DVelop Software Solutions";
               AV98Phone = "+1 550 8923";
               AV96Mail = "info@mail.com";
               AV100Website = "http://www.web.com";
               AV89AddressLine1 = "French Boulevard 2859";
               AV90AddressLine2 = "Downtown";
               AV91AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV92AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV99Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV98Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV96Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV100Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV89AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV90AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV91AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV99Title = "";
         AV13FilterFullText = "";
         AV45GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV42GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16CpjConNome1 = "";
         AV17FilterCpjConNomeDescription = "";
         AV18CpjConNome = "";
         AV19CpjTipoNome1 = "";
         AV20FilterCpjTipoNomeDescription = "";
         AV21CpjTipoNome = "";
         AV22CpjConTipoNome1 = "";
         AV23FilterCpjConTipoNomeDescription = "";
         AV24CpjConTipoNome = "";
         AV25CpjConGenSigla1 = "";
         AV26FilterCpjConGenSiglaDescription = "";
         AV27CpjConGenSigla = "";
         AV29DynamicFiltersSelector2 = "";
         AV31CpjConNome2 = "";
         AV32CpjTipoNome2 = "";
         AV33CpjConTipoNome2 = "";
         AV34CpjConGenSigla2 = "";
         AV36DynamicFiltersSelector3 = "";
         AV38CpjConNome3 = "";
         AV39CpjTipoNome3 = "";
         AV40CpjConTipoNome3 = "";
         AV41CpjConGenSigla3 = "";
         AV48TFCpjConNome_Sel = "";
         AV47TFCpjConNome = "";
         AV50TFCpjConNomePrim_Sel = "";
         AV49TFCpjConNomePrim = "";
         AV52TFCpjConSobrenome_Sel = "";
         AV51TFCpjConSobrenome = "";
         AV54TFCpjConTipoNome_Sel = "";
         AV53TFCpjConTipoNome = "";
         AV56TFCpjConCPFFormat_Sel = "";
         AV55TFCpjConCPFFormat = "";
         AV57TFCpjConNascimento = DateTime.MinValue;
         AV58TFCpjConNascimento_To = DateTime.MinValue;
         AV85TFCpjConNascimento_To_Description = "";
         AV60TFCpjConGenNome_Sel = "";
         AV59TFCpjConGenNome = "";
         AV62TFCpjConCelNum_Sel = "";
         AV61TFCpjConCelNum = "";
         AV64TFCpjConTelNum_Sel = "";
         AV63TFCpjConTelNum = "";
         AV66TFCpjConTelRam_Sel = "";
         AV65TFCpjConTelRam = "";
         AV84TFCpjConWppNum_Sel = "";
         AV83TFCpjConWppNum = "";
         AV68TFCpjConEmail_Sel = "";
         AV67TFCpjConEmail = "";
         AV70TFCpjConLIn_Sel = "";
         AV69TFCpjConLIn = "";
         AV74TFCliNomeFamiliar_Sel = "";
         AV73TFCliNomeFamiliar = "";
         AV86TFCliMatricula_To_Description = "";
         AV76TFCpjTipoNome_Sel = "";
         AV75TFCpjTipoNome = "";
         AV78TFCpjNomeFan_Sel = "";
         AV77TFCpjNomeFan = "";
         AV80TFCpjRazaoSoc_Sel = "";
         AV79TFCpjRazaoSoc = "";
         AV119TFCpjMatricula_To_Description = "";
         AV104TFCpjCNPJFormat_Sel = "";
         AV103TFCpjCNPJFormat = "";
         AV106TFCpjIE_Sel = "";
         AV105TFCpjIE = "";
         AV108TFCpjCelNum_Sel = "";
         AV107TFCpjCelNum = "";
         AV110TFCpjTelNum_Sel = "";
         AV109TFCpjTelNum = "";
         AV112TFCpjTelRam_Sel = "";
         AV111TFCpjTelRam = "";
         AV114TFCpjWppNum_Sel = "";
         AV113TFCpjWppNum = "";
         AV116TFCpjEmail_Sel = "";
         AV115TFCpjEmail = "";
         AV118TFCpjWebsite_Sel = "";
         AV117TFCpjWebsite = "";
         AV123Core_clientepjcontatowwds_1_filterfulltext = "";
         AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1 = "";
         AV126Core_clientepjcontatowwds_4_cpjconnome1 = "";
         AV127Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         AV128Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         AV129Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2 = "";
         AV133Core_clientepjcontatowwds_11_cpjconnome2 = "";
         AV134Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         AV135Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         AV136Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3 = "";
         AV140Core_clientepjcontatowwds_18_cpjconnome3 = "";
         AV141Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         AV142Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         AV143Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         AV144Core_clientepjcontatowwds_22_tfcpjconnome = "";
         AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel = "";
         AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = "";
         AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = "";
         AV150Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = "";
         AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = "";
         AV154Core_clientepjcontatowwds_32_tfcpjconnascimento = DateTime.MinValue;
         AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to = DateTime.MinValue;
         AV156Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel = "";
         AV158Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = "";
         AV160Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = "";
         AV162Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel = "";
         AV164Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = "";
         AV166Core_clientepjcontatowwds_44_tfcpjconemail = "";
         AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel = "";
         AV168Core_clientepjcontatowwds_46_tfcpjconlin = "";
         AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel = "";
         AV170Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = "";
         AV174Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel = "";
         AV176Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel = "";
         AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = "";
         AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = "";
         AV184Core_clientepjcontatowwds_62_tfcpjie = "";
         AV185Core_clientepjcontatowwds_63_tfcpjie_sel = "";
         AV186Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel = "";
         AV188Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel = "";
         AV190Core_clientepjcontatowwds_68_tfcpjtelram = "";
         AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel = "";
         AV192Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel = "";
         AV194Core_clientepjcontatowwds_72_tfcpjemail = "";
         AV195Core_clientepjcontatowwds_73_tfcpjemail_sel = "";
         AV196Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel = "";
         scmdbuf = "";
         lV123Core_clientepjcontatowwds_1_filterfulltext = "";
         lV126Core_clientepjcontatowwds_4_cpjconnome1 = "";
         lV127Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         lV128Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         lV129Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         lV133Core_clientepjcontatowwds_11_cpjconnome2 = "";
         lV134Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         lV135Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         lV136Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         lV140Core_clientepjcontatowwds_18_cpjconnome3 = "";
         lV141Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         lV142Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         lV143Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         lV144Core_clientepjcontatowwds_22_tfcpjconnome = "";
         lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         lV150Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         lV156Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         lV158Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         lV160Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         lV162Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         lV164Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         lV166Core_clientepjcontatowwds_44_tfcpjconemail = "";
         lV168Core_clientepjcontatowwds_46_tfcpjconlin = "";
         lV170Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         lV174Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         lV176Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         lV184Core_clientepjcontatowwds_62_tfcpjie = "";
         lV186Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         lV188Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         lV190Core_clientepjcontatowwds_68_tfcpjtelram = "";
         lV192Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         lV194Core_clientepjcontatowwds_72_tfcpjemail = "";
         lV196Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         A275CpjConNome = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         A272CpjConTipoNome = "";
         A274CpjConCPFFormat = "";
         A281CpjConGenNome = "";
         A285CpjConCelNum = "";
         A283CpjConTelNum = "";
         A284CpjConTelRam = "";
         A286CpjConWppNum = "";
         A287CpjConEmail = "";
         A288CpjConLIn = "";
         A160CliNomeFamiliar = "";
         A367CpjTipoNome = "";
         A170CpjNomeFan = "";
         A171CpjRazaoSoc = "";
         A188CpjCNPJFormat = "";
         A189CpjIE = "";
         A263CpjCelNum = "";
         A261CpjTelNum = "";
         A262CpjTelRam = "";
         A264CpjWppNum = "";
         A266CpjEmail = "";
         A265CpjWebsite = "";
         A280CpjConGenSigla = "";
         A282CpjConNascimento = DateTime.MinValue;
         P005X2_A158CliID = new Guid[] {Guid.Empty} ;
         P005X2_A166CpjID = new Guid[] {Guid.Empty} ;
         P005X2_A365CpjTipoId = new int[1] ;
         P005X2_A176CpjMatricula = new long[1] ;
         P005X2_A159CliMatricula = new long[1] ;
         P005X2_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         P005X2_A280CpjConGenSigla = new string[] {""} ;
         P005X2_A265CpjWebsite = new string[] {""} ;
         P005X2_n265CpjWebsite = new bool[] {false} ;
         P005X2_A266CpjEmail = new string[] {""} ;
         P005X2_n266CpjEmail = new bool[] {false} ;
         P005X2_A264CpjWppNum = new string[] {""} ;
         P005X2_n264CpjWppNum = new bool[] {false} ;
         P005X2_A262CpjTelRam = new string[] {""} ;
         P005X2_n262CpjTelRam = new bool[] {false} ;
         P005X2_A261CpjTelNum = new string[] {""} ;
         P005X2_n261CpjTelNum = new bool[] {false} ;
         P005X2_A263CpjCelNum = new string[] {""} ;
         P005X2_n263CpjCelNum = new bool[] {false} ;
         P005X2_A189CpjIE = new string[] {""} ;
         P005X2_A188CpjCNPJFormat = new string[] {""} ;
         P005X2_A171CpjRazaoSoc = new string[] {""} ;
         P005X2_A170CpjNomeFan = new string[] {""} ;
         P005X2_A367CpjTipoNome = new string[] {""} ;
         P005X2_A160CliNomeFamiliar = new string[] {""} ;
         P005X2_A288CpjConLIn = new string[] {""} ;
         P005X2_n288CpjConLIn = new bool[] {false} ;
         P005X2_A287CpjConEmail = new string[] {""} ;
         P005X2_n287CpjConEmail = new bool[] {false} ;
         P005X2_A286CpjConWppNum = new string[] {""} ;
         P005X2_n286CpjConWppNum = new bool[] {false} ;
         P005X2_A284CpjConTelRam = new string[] {""} ;
         P005X2_n284CpjConTelRam = new bool[] {false} ;
         P005X2_A283CpjConTelNum = new string[] {""} ;
         P005X2_n283CpjConTelNum = new bool[] {false} ;
         P005X2_A285CpjConCelNum = new string[] {""} ;
         P005X2_n285CpjConCelNum = new bool[] {false} ;
         P005X2_A281CpjConGenNome = new string[] {""} ;
         P005X2_A274CpjConCPFFormat = new string[] {""} ;
         P005X2_A272CpjConTipoNome = new string[] {""} ;
         P005X2_A277CpjConSobrenome = new string[] {""} ;
         P005X2_A276CpjConNomePrim = new string[] {""} ;
         P005X2_A275CpjConNome = new string[] {""} ;
         P005X2_A269CpjConSeq = new short[1] ;
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         AV43Session = context.GetSession();
         AV46GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV97PageInfo = "";
         AV94DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV92AppName = "";
         AV98Phone = "";
         AV96Mail = "";
         AV100Website = "";
         AV89AddressLine1 = "";
         AV90AddressLine2 = "";
         AV91AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P005X2_A158CliID, P005X2_A166CpjID, P005X2_A365CpjTipoId, P005X2_A176CpjMatricula, P005X2_A159CliMatricula, P005X2_A282CpjConNascimento, P005X2_A280CpjConGenSigla, P005X2_A265CpjWebsite, P005X2_n265CpjWebsite, P005X2_A266CpjEmail,
               P005X2_n266CpjEmail, P005X2_A264CpjWppNum, P005X2_n264CpjWppNum, P005X2_A262CpjTelRam, P005X2_n262CpjTelRam, P005X2_A261CpjTelNum, P005X2_n261CpjTelNum, P005X2_A263CpjCelNum, P005X2_n263CpjCelNum, P005X2_A189CpjIE,
               P005X2_A188CpjCNPJFormat, P005X2_A171CpjRazaoSoc, P005X2_A170CpjNomeFan, P005X2_A367CpjTipoNome, P005X2_A160CliNomeFamiliar, P005X2_A288CpjConLIn, P005X2_n288CpjConLIn, P005X2_A287CpjConEmail, P005X2_n287CpjConEmail, P005X2_A286CpjConWppNum,
               P005X2_n286CpjConWppNum, P005X2_A284CpjConTelRam, P005X2_n284CpjConTelRam, P005X2_A283CpjConTelNum, P005X2_n283CpjConTelNum, P005X2_A285CpjConCelNum, P005X2_n285CpjConCelNum, P005X2_A281CpjConGenNome, P005X2_A274CpjConCPFFormat, P005X2_A272CpjConTipoNome,
               P005X2_A277CpjConSobrenome, P005X2_A276CpjConNomePrim, P005X2_A275CpjConNome, P005X2_A269CpjConSeq
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
      private short AV30DynamicFiltersOperator2 ;
      private short AV37DynamicFiltersOperator3 ;
      private short AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ;
      private short AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ;
      private short AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private short A269CpjConSeq ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A365CpjTipoId ;
      private int AV198GXV1 ;
      private long AV71TFCliMatricula ;
      private long AV72TFCliMatricula_To ;
      private long AV101TFCpjMatricula ;
      private long AV102TFCpjMatricula_To ;
      private long AV172Core_clientepjcontatowwds_50_tfclimatricula ;
      private long AV173Core_clientepjcontatowwds_51_tfclimatricula_to ;
      private long AV180Core_clientepjcontatowwds_58_tfcpjmatricula ;
      private long AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string AV62TFCpjConCelNum_Sel ;
      private string AV61TFCpjConCelNum ;
      private string AV64TFCpjConTelNum_Sel ;
      private string AV63TFCpjConTelNum ;
      private string AV84TFCpjConWppNum_Sel ;
      private string AV83TFCpjConWppNum ;
      private string AV108TFCpjCelNum_Sel ;
      private string AV107TFCpjCelNum ;
      private string AV110TFCpjTelNum_Sel ;
      private string AV109TFCpjTelNum ;
      private string AV114TFCpjWppNum_Sel ;
      private string AV113TFCpjWppNum ;
      private string AV158Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ;
      private string AV160Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ;
      private string AV164Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ;
      private string AV186Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel ;
      private string AV188Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel ;
      private string AV192Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel ;
      private string scmdbuf ;
      private string lV158Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string lV160Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string lV164Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string lV186Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string lV188Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string lV192Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string A285CpjConCelNum ;
      private string A283CpjConTelNum ;
      private string A286CpjConWppNum ;
      private string A263CpjCelNum ;
      private string A261CpjTelNum ;
      private string A264CpjWppNum ;
      private DateTime AV57TFCpjConNascimento ;
      private DateTime AV58TFCpjConNascimento_To ;
      private DateTime AV154Core_clientepjcontatowwds_32_tfcpjconnascimento ;
      private DateTime AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to ;
      private DateTime A282CpjConNascimento ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV28DynamicFiltersEnabled2 ;
      private bool AV35DynamicFiltersEnabled3 ;
      private bool AV88TempBoolean ;
      private bool AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ;
      private bool AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool n265CpjWebsite ;
      private bool n266CpjEmail ;
      private bool n264CpjWppNum ;
      private bool n262CpjTelRam ;
      private bool n261CpjTelNum ;
      private bool n263CpjCelNum ;
      private bool n288CpjConLIn ;
      private bool n287CpjConEmail ;
      private bool n286CpjConWppNum ;
      private bool n284CpjConTelRam ;
      private bool n283CpjConTelNum ;
      private bool n285CpjConCelNum ;
      private string AV99Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16CpjConNome1 ;
      private string AV17FilterCpjConNomeDescription ;
      private string AV18CpjConNome ;
      private string AV19CpjTipoNome1 ;
      private string AV20FilterCpjTipoNomeDescription ;
      private string AV21CpjTipoNome ;
      private string AV22CpjConTipoNome1 ;
      private string AV23FilterCpjConTipoNomeDescription ;
      private string AV24CpjConTipoNome ;
      private string AV25CpjConGenSigla1 ;
      private string AV26FilterCpjConGenSiglaDescription ;
      private string AV27CpjConGenSigla ;
      private string AV29DynamicFiltersSelector2 ;
      private string AV31CpjConNome2 ;
      private string AV32CpjTipoNome2 ;
      private string AV33CpjConTipoNome2 ;
      private string AV34CpjConGenSigla2 ;
      private string AV36DynamicFiltersSelector3 ;
      private string AV38CpjConNome3 ;
      private string AV39CpjTipoNome3 ;
      private string AV40CpjConTipoNome3 ;
      private string AV41CpjConGenSigla3 ;
      private string AV48TFCpjConNome_Sel ;
      private string AV47TFCpjConNome ;
      private string AV50TFCpjConNomePrim_Sel ;
      private string AV49TFCpjConNomePrim ;
      private string AV52TFCpjConSobrenome_Sel ;
      private string AV51TFCpjConSobrenome ;
      private string AV54TFCpjConTipoNome_Sel ;
      private string AV53TFCpjConTipoNome ;
      private string AV56TFCpjConCPFFormat_Sel ;
      private string AV55TFCpjConCPFFormat ;
      private string AV85TFCpjConNascimento_To_Description ;
      private string AV60TFCpjConGenNome_Sel ;
      private string AV59TFCpjConGenNome ;
      private string AV66TFCpjConTelRam_Sel ;
      private string AV65TFCpjConTelRam ;
      private string AV68TFCpjConEmail_Sel ;
      private string AV67TFCpjConEmail ;
      private string AV70TFCpjConLIn_Sel ;
      private string AV69TFCpjConLIn ;
      private string AV74TFCliNomeFamiliar_Sel ;
      private string AV73TFCliNomeFamiliar ;
      private string AV86TFCliMatricula_To_Description ;
      private string AV76TFCpjTipoNome_Sel ;
      private string AV75TFCpjTipoNome ;
      private string AV78TFCpjNomeFan_Sel ;
      private string AV77TFCpjNomeFan ;
      private string AV80TFCpjRazaoSoc_Sel ;
      private string AV79TFCpjRazaoSoc ;
      private string AV119TFCpjMatricula_To_Description ;
      private string AV104TFCpjCNPJFormat_Sel ;
      private string AV103TFCpjCNPJFormat ;
      private string AV106TFCpjIE_Sel ;
      private string AV105TFCpjIE ;
      private string AV112TFCpjTelRam_Sel ;
      private string AV111TFCpjTelRam ;
      private string AV116TFCpjEmail_Sel ;
      private string AV115TFCpjEmail ;
      private string AV118TFCpjWebsite_Sel ;
      private string AV117TFCpjWebsite ;
      private string AV123Core_clientepjcontatowwds_1_filterfulltext ;
      private string AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1 ;
      private string AV126Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string AV127Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string AV128Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string AV129Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2 ;
      private string AV133Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string AV134Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string AV135Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string AV136Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3 ;
      private string AV140Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string AV141Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string AV142Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string AV143Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string AV144Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel ;
      private string AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ;
      private string AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ;
      private string AV150Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ;
      private string AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ;
      private string AV156Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel ;
      private string AV162Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel ;
      private string AV166Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel ;
      private string AV168Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel ;
      private string AV170Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ;
      private string AV174Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel ;
      private string AV176Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel ;
      private string AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ;
      private string AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ;
      private string AV184Core_clientepjcontatowwds_62_tfcpjie ;
      private string AV185Core_clientepjcontatowwds_63_tfcpjie_sel ;
      private string AV190Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel ;
      private string AV194Core_clientepjcontatowwds_72_tfcpjemail ;
      private string AV195Core_clientepjcontatowwds_73_tfcpjemail_sel ;
      private string AV196Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel ;
      private string lV123Core_clientepjcontatowwds_1_filterfulltext ;
      private string lV126Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string lV127Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string lV128Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string lV129Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string lV133Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string lV134Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string lV135Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string lV136Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string lV140Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string lV141Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string lV142Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string lV143Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string lV144Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string lV150Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string lV156Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string lV162Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string lV166Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string lV168Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string lV170Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string lV174Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string lV176Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string lV184Core_clientepjcontatowwds_62_tfcpjie ;
      private string lV190Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string lV194Core_clientepjcontatowwds_72_tfcpjemail ;
      private string lV196Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string A275CpjConNome ;
      private string A276CpjConNomePrim ;
      private string A277CpjConSobrenome ;
      private string A272CpjConTipoNome ;
      private string A274CpjConCPFFormat ;
      private string A281CpjConGenNome ;
      private string A284CpjConTelRam ;
      private string A287CpjConEmail ;
      private string A288CpjConLIn ;
      private string A160CliNomeFamiliar ;
      private string A367CpjTipoNome ;
      private string A170CpjNomeFan ;
      private string A171CpjRazaoSoc ;
      private string A188CpjCNPJFormat ;
      private string A189CpjIE ;
      private string A262CpjTelRam ;
      private string A266CpjEmail ;
      private string A265CpjWebsite ;
      private string A280CpjConGenSigla ;
      private string AV97PageInfo ;
      private string AV94DateInfo ;
      private string AV92AppName ;
      private string AV98Phone ;
      private string AV96Mail ;
      private string AV100Website ;
      private string AV89AddressLine1 ;
      private string AV90AddressLine2 ;
      private string AV91AddressLine3 ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private IGxSession AV43Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] P005X2_A158CliID ;
      private Guid[] P005X2_A166CpjID ;
      private int[] P005X2_A365CpjTipoId ;
      private long[] P005X2_A176CpjMatricula ;
      private long[] P005X2_A159CliMatricula ;
      private DateTime[] P005X2_A282CpjConNascimento ;
      private string[] P005X2_A280CpjConGenSigla ;
      private string[] P005X2_A265CpjWebsite ;
      private bool[] P005X2_n265CpjWebsite ;
      private string[] P005X2_A266CpjEmail ;
      private bool[] P005X2_n266CpjEmail ;
      private string[] P005X2_A264CpjWppNum ;
      private bool[] P005X2_n264CpjWppNum ;
      private string[] P005X2_A262CpjTelRam ;
      private bool[] P005X2_n262CpjTelRam ;
      private string[] P005X2_A261CpjTelNum ;
      private bool[] P005X2_n261CpjTelNum ;
      private string[] P005X2_A263CpjCelNum ;
      private bool[] P005X2_n263CpjCelNum ;
      private string[] P005X2_A189CpjIE ;
      private string[] P005X2_A188CpjCNPJFormat ;
      private string[] P005X2_A171CpjRazaoSoc ;
      private string[] P005X2_A170CpjNomeFan ;
      private string[] P005X2_A367CpjTipoNome ;
      private string[] P005X2_A160CliNomeFamiliar ;
      private string[] P005X2_A288CpjConLIn ;
      private bool[] P005X2_n288CpjConLIn ;
      private string[] P005X2_A287CpjConEmail ;
      private bool[] P005X2_n287CpjConEmail ;
      private string[] P005X2_A286CpjConWppNum ;
      private bool[] P005X2_n286CpjConWppNum ;
      private string[] P005X2_A284CpjConTelRam ;
      private bool[] P005X2_n284CpjConTelRam ;
      private string[] P005X2_A283CpjConTelNum ;
      private bool[] P005X2_n283CpjConTelNum ;
      private string[] P005X2_A285CpjConCelNum ;
      private bool[] P005X2_n285CpjConCelNum ;
      private string[] P005X2_A281CpjConGenNome ;
      private string[] P005X2_A274CpjConCPFFormat ;
      private string[] P005X2_A272CpjConTipoNome ;
      private string[] P005X2_A277CpjConSobrenome ;
      private string[] P005X2_A276CpjConNomePrim ;
      private string[] P005X2_A275CpjConNome ;
      private short[] P005X2_A269CpjConSeq ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV45GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV46GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV42GridStateDynamicFilter ;
   }

   public class clientepjcontatowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P005X2( IGxContext context ,
                                             string AV123Core_clientepjcontatowwds_1_filterfulltext ,
                                             string AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                             short AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                             string AV126Core_clientepjcontatowwds_4_cpjconnome1 ,
                                             string AV127Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                             string AV128Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                             string AV129Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                             bool AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                             string AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                             short AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                             string AV133Core_clientepjcontatowwds_11_cpjconnome2 ,
                                             string AV134Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                             string AV135Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                             string AV136Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                             bool AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                             string AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                             short AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                             string AV140Core_clientepjcontatowwds_18_cpjconnome3 ,
                                             string AV141Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                             string AV142Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                             string AV143Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                             string AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                             string AV144Core_clientepjcontatowwds_22_tfcpjconnome ,
                                             string AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                             string AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                             string AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                             string AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                             string AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                             string AV150Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                             string AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                             string AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                             DateTime AV154Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                             DateTime AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                             string AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                             string AV156Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                             string AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                             string AV158Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                             string AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                             string AV160Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                             string AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                             string AV162Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                             string AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                             string AV164Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                             string AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                             string AV166Core_clientepjcontatowwds_44_tfcpjconemail ,
                                             string AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                             string AV168Core_clientepjcontatowwds_46_tfcpjconlin ,
                                             string AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                             string AV170Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                             long AV172Core_clientepjcontatowwds_50_tfclimatricula ,
                                             long AV173Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                             string AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                             string AV174Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                             string AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                             string AV176Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                             string AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                             string AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                             long AV180Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                             long AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                             string AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                             string AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                             string AV185Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                             string AV184Core_clientepjcontatowwds_62_tfcpjie ,
                                             string AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                             string AV186Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                             string AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                             string AV188Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                             string AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                             string AV190Core_clientepjcontatowwds_68_tfcpjtelram ,
                                             string AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                             string AV192Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                             string AV195Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                             string AV194Core_clientepjcontatowwds_72_tfcpjemail ,
                                             string AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                             string AV196Core_clientepjcontatowwds_74_tfcpjwebsite ,
                                             string A275CpjConNome ,
                                             string A276CpjConNomePrim ,
                                             string A277CpjConSobrenome ,
                                             string A272CpjConTipoNome ,
                                             string A274CpjConCPFFormat ,
                                             string A281CpjConGenNome ,
                                             string A285CpjConCelNum ,
                                             string A283CpjConTelNum ,
                                             string A284CpjConTelRam ,
                                             string A286CpjConWppNum ,
                                             string A287CpjConEmail ,
                                             string A288CpjConLIn ,
                                             string A160CliNomeFamiliar ,
                                             long A159CliMatricula ,
                                             string A367CpjTipoNome ,
                                             string A170CpjNomeFan ,
                                             string A171CpjRazaoSoc ,
                                             long A176CpjMatricula ,
                                             string A188CpjCNPJFormat ,
                                             string A189CpjIE ,
                                             string A263CpjCelNum ,
                                             string A261CpjTelNum ,
                                             string A262CpjTelRam ,
                                             string A264CpjWppNum ,
                                             string A266CpjEmail ,
                                             string A265CpjWebsite ,
                                             string A280CpjConGenSigla ,
                                             DateTime A282CpjConNascimento ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[104];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.CliID, T1.CpjID, T3.CpjTipoId AS CpjTipoId, T3.CpjMatricula, T2.CliMatricula, T1.CpjConNascimento, T1.CpjConGenSigla, T3.CpjWebsite, T3.CpjEmail, T3.CpjWppNum, T3.CpjTelRam, T3.CpjTelNum, T3.CpjCelNum, T3.CpjIE, T3.CpjCNPJFormat, T3.CpjRazaoSoc, T3.CpjNomeFan, T4.PjtNome AS CpjTipoNome, T2.CliNomeFamiliar, T1.CpjConLIn, T1.CpjConEmail, T1.CpjConWppNum, T1.CpjConTelRam, T1.CpjConTelNum, T1.CpjConCelNum, T1.CpjConGenNome, T1.CpjConCPFFormat, T1.CpjConTipoNome, T1.CpjConSobrenome, T1.CpjConNomePrim, T1.CpjConNome, T1.CpjConSeq FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV123Core_clientepjcontatowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CpjConNome like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConNomePrim like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConSobrenome like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTipoNome like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCPFFormat like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConGenNome like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCelNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelRam like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConWppNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConEmail like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConLIn like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T2.CliNomeFamiliar like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CliMatricula,'999999999999'), 2) like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T4.PjtNome like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjNomeFan like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjRazaoSoc like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.CpjMatricula,'999999999999'), 2) like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCNPJFormat like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjIE like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCelNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelRam like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWppNum like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjEmail like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWebsite like '%' || :lV123Core_clientepjcontatowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
            GXv_int2[5] = 1;
            GXv_int2[6] = 1;
            GXv_int2[7] = 1;
            GXv_int2[8] = 1;
            GXv_int2[9] = 1;
            GXv_int2[10] = 1;
            GXv_int2[11] = 1;
            GXv_int2[12] = 1;
            GXv_int2[13] = 1;
            GXv_int2[14] = 1;
            GXv_int2[15] = 1;
            GXv_int2[16] = 1;
            GXv_int2[17] = 1;
            GXv_int2[18] = 1;
            GXv_int2[19] = 1;
            GXv_int2[20] = 1;
            GXv_int2[21] = 1;
            GXv_int2[22] = 1;
            GXv_int2[23] = 1;
            GXv_int2[24] = 1;
            GXv_int2[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV126Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV126Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV127Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int2[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV127Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV127Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int2[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV128Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int2[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV128Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV128Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int2[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV129Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int2[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV124Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV125Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV129Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int2[33] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV133Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int2[34] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV133Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV133Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int2[35] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV134Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int2[36] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV134Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV134Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int2[37] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV135Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int2[38] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV135Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV135Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int2[39] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV136Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int2[40] = 1;
         }
         if ( AV130Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV131Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV132Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV136Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int2[41] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV140Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int2[42] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV140Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV140Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int2[43] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV141Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int2[44] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV141Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV141Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int2[45] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV142Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int2[46] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV142Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV142Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int2[47] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV143Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int2[48] = 1;
         }
         if ( AV137Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV138Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV139Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV143Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int2[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_22_tfcpjconnome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV144Core_clientepjcontatowwds_22_tfcpjconnome)");
         }
         else
         {
            GXv_int2[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ! ( StringUtil.StrCmp(AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome = ( :AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel))");
         }
         else
         {
            GXv_int2[51] = 1;
         }
         if ( StringUtil.StrCmp(AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Core_clientepjcontatowwds_24_tfcpjconnomeprim)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim like :lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim)");
         }
         else
         {
            GXv_int2[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ! ( StringUtil.StrCmp(AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim = ( :AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel))");
         }
         else
         {
            GXv_int2[53] = 1;
         }
         if ( StringUtil.StrCmp(AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNomePrim))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_26_tfcpjconsobrenome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome like :lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome)");
         }
         else
         {
            GXv_int2[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ! ( StringUtil.StrCmp(AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome = ( :AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel))");
         }
         else
         {
            GXv_int2[55] = 1;
         }
         if ( StringUtil.StrCmp(AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConSobrenome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_28_tfcpjcontiponome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV150Core_clientepjcontatowwds_28_tfcpjcontiponome)");
         }
         else
         {
            GXv_int2[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ! ( StringUtil.StrCmp(AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome = ( :AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel))");
         }
         else
         {
            GXv_int2[57] = 1;
         }
         if ( StringUtil.StrCmp(AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_30_tfcpjconcpfformat)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat like :lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat)");
         }
         else
         {
            GXv_int2[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ! ( StringUtil.StrCmp(AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat = ( :AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel))");
         }
         else
         {
            GXv_int2[59] = 1;
         }
         if ( StringUtil.StrCmp(AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConCPFFormat))=0))");
         }
         if ( ! (DateTime.MinValue==AV154Core_clientepjcontatowwds_32_tfcpjconnascimento) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento >= :AV154Core_clientepjcontatowwds_32_tfcpjconnascimento)");
         }
         else
         {
            GXv_int2[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento <= :AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to)");
         }
         else
         {
            GXv_int2[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_34_tfcpjcongennome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome like :lV156Core_clientepjcontatowwds_34_tfcpjcongennome)");
         }
         else
         {
            GXv_int2[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ! ( StringUtil.StrCmp(AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome = ( :AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel))");
         }
         else
         {
            GXv_int2[63] = 1;
         }
         if ( StringUtil.StrCmp(AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConGenNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV158Core_clientepjcontatowwds_36_tfcpjconcelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum like :lV158Core_clientepjcontatowwds_36_tfcpjconcelnum)");
         }
         else
         {
            GXv_int2[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ! ( StringUtil.StrCmp(AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum = ( :AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel))");
         }
         else
         {
            GXv_int2[65] = 1;
         }
         if ( StringUtil.StrCmp(AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_38_tfcpjcontelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum like :lV160Core_clientepjcontatowwds_38_tfcpjcontelnum)");
         }
         else
         {
            GXv_int2[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ! ( StringUtil.StrCmp(AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum = ( :AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel))");
         }
         else
         {
            GXv_int2[67] = 1;
         }
         if ( StringUtil.StrCmp(AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_40_tfcpjcontelram)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam like :lV162Core_clientepjcontatowwds_40_tfcpjcontelram)");
         }
         else
         {
            GXv_int2[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ! ( StringUtil.StrCmp(AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam = ( :AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel))");
         }
         else
         {
            GXv_int2[69] = 1;
         }
         if ( StringUtil.StrCmp(AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Core_clientepjcontatowwds_42_tfcpjconwppnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum like :lV164Core_clientepjcontatowwds_42_tfcpjconwppnum)");
         }
         else
         {
            GXv_int2[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ! ( StringUtil.StrCmp(AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum = ( :AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel))");
         }
         else
         {
            GXv_int2[71] = 1;
         }
         if ( StringUtil.StrCmp(AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_44_tfcpjconemail)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail like :lV166Core_clientepjcontatowwds_44_tfcpjconemail)");
         }
         else
         {
            GXv_int2[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ! ( StringUtil.StrCmp(AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail = ( :AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel))");
         }
         else
         {
            GXv_int2[73] = 1;
         }
         if ( StringUtil.StrCmp(AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail IS NULL or (char_length(trim(trailing ' ' from T1.CpjConEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_46_tfcpjconlin)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn like :lV168Core_clientepjcontatowwds_46_tfcpjconlin)");
         }
         else
         {
            GXv_int2[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ! ( StringUtil.StrCmp(AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn = ( :AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel))");
         }
         else
         {
            GXv_int2[75] = 1;
         }
         if ( StringUtil.StrCmp(AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn IS NULL or (char_length(trim(trailing ' ' from T1.CpjConLIn))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_48_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar like :lV170Core_clientepjcontatowwds_48_tfclinomefamiliar)");
         }
         else
         {
            GXv_int2[76] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar = ( :AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int2[77] = 1;
         }
         if ( StringUtil.StrCmp(AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV172Core_clientepjcontatowwds_50_tfclimatricula) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula >= :AV172Core_clientepjcontatowwds_50_tfclimatricula)");
         }
         else
         {
            GXv_int2[78] = 1;
         }
         if ( ! (0==AV173Core_clientepjcontatowwds_51_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula <= :AV173Core_clientepjcontatowwds_51_tfclimatricula_to)");
         }
         else
         {
            GXv_int2[79] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_52_tfcpjtiponome)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV174Core_clientepjcontatowwds_52_tfcpjtiponome)");
         }
         else
         {
            GXv_int2[80] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ! ( StringUtil.StrCmp(AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome = ( :AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel))");
         }
         else
         {
            GXv_int2[81] = 1;
         }
         if ( StringUtil.StrCmp(AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.PjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV176Core_clientepjcontatowwds_54_tfcpjnomefan)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan like :lV176Core_clientepjcontatowwds_54_tfcpjnomefan)");
         }
         else
         {
            GXv_int2[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ! ( StringUtil.StrCmp(AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan = ( :AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel))");
         }
         else
         {
            GXv_int2[83] = 1;
         }
         if ( StringUtil.StrCmp(AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjNomeFan))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_56_tfcpjrazaosoc)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc like :lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc)");
         }
         else
         {
            GXv_int2[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ! ( StringUtil.StrCmp(AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc = ( :AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel))");
         }
         else
         {
            GXv_int2[85] = 1;
         }
         if ( StringUtil.StrCmp(AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjRazaoSoc))=0))");
         }
         if ( ! (0==AV180Core_clientepjcontatowwds_58_tfcpjmatricula) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula >= :AV180Core_clientepjcontatowwds_58_tfcpjmatricula)");
         }
         else
         {
            GXv_int2[86] = 1;
         }
         if ( ! (0==AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula <= :AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to)");
         }
         else
         {
            GXv_int2[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_60_tfcpjcnpjformat)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat like :lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat)");
         }
         else
         {
            GXv_int2[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ! ( StringUtil.StrCmp(AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat = ( :AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel))");
         }
         else
         {
            GXv_int2[89] = 1;
         }
         if ( StringUtil.StrCmp(AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjCNPJFormat))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_63_tfcpjie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV184Core_clientepjcontatowwds_62_tfcpjie)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE like :lV184Core_clientepjcontatowwds_62_tfcpjie)");
         }
         else
         {
            GXv_int2[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_63_tfcpjie_sel)) && ! ( StringUtil.StrCmp(AV185Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE = ( :AV185Core_clientepjcontatowwds_63_tfcpjie_sel))");
         }
         else
         {
            GXv_int2[91] = 1;
         }
         if ( StringUtil.StrCmp(AV185Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjIE))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_64_tfcpjcelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum like :lV186Core_clientepjcontatowwds_64_tfcpjcelnum)");
         }
         else
         {
            GXv_int2[92] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ! ( StringUtil.StrCmp(AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum = ( :AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel))");
         }
         else
         {
            GXv_int2[93] = 1;
         }
         if ( StringUtil.StrCmp(AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_66_tfcpjtelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum like :lV188Core_clientepjcontatowwds_66_tfcpjtelnum)");
         }
         else
         {
            GXv_int2[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ! ( StringUtil.StrCmp(AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum = ( :AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel))");
         }
         else
         {
            GXv_int2[95] = 1;
         }
         if ( StringUtil.StrCmp(AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV190Core_clientepjcontatowwds_68_tfcpjtelram)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam like :lV190Core_clientepjcontatowwds_68_tfcpjtelram)");
         }
         else
         {
            GXv_int2[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ! ( StringUtil.StrCmp(AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam = ( :AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel))");
         }
         else
         {
            GXv_int2[97] = 1;
         }
         if ( StringUtil.StrCmp(AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV192Core_clientepjcontatowwds_70_tfcpjwppnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum like :lV192Core_clientepjcontatowwds_70_tfcpjwppnum)");
         }
         else
         {
            GXv_int2[98] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ! ( StringUtil.StrCmp(AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum = ( :AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel))");
         }
         else
         {
            GXv_int2[99] = 1;
         }
         if ( StringUtil.StrCmp(AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Core_clientepjcontatowwds_72_tfcpjemail)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail like :lV194Core_clientepjcontatowwds_72_tfcpjemail)");
         }
         else
         {
            GXv_int2[100] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ! ( StringUtil.StrCmp(AV195Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail = ( :AV195Core_clientepjcontatowwds_73_tfcpjemail_sel))");
         }
         else
         {
            GXv_int2[101] = 1;
         }
         if ( StringUtil.StrCmp(AV195Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjEmail IS NULL or (char_length(trim(trailing ' ' from T3.CpjEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_clientepjcontatowwds_74_tfcpjwebsite)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite like :lV196Core_clientepjcontatowwds_74_tfcpjwebsite)");
         }
         else
         {
            GXv_int2[102] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ! ( StringUtil.StrCmp(AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite = ( :AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel))");
         }
         else
         {
            GXv_int2[103] = 1;
         }
         if ( StringUtil.StrCmp(AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite IS NULL or (char_length(trim(trailing ' ' from T3.CpjWebsite))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNome";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNome DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNomePrim";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNomePrim DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConSobrenome";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConSobrenome DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTipoNome";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTipoNome DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConCPFFormat";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConCPFFormat DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConNascimento";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConNascimento DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConGenNome";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConGenNome DESC";
         }
         else if ( ( AV11OrderedBy == 8 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConCelNum";
         }
         else if ( ( AV11OrderedBy == 8 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConCelNum DESC";
         }
         else if ( ( AV11OrderedBy == 9 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTelNum";
         }
         else if ( ( AV11OrderedBy == 9 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTelNum DESC";
         }
         else if ( ( AV11OrderedBy == 10 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConTelRam";
         }
         else if ( ( AV11OrderedBy == 10 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConTelRam DESC";
         }
         else if ( ( AV11OrderedBy == 11 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConWppNum";
         }
         else if ( ( AV11OrderedBy == 11 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConWppNum DESC";
         }
         else if ( ( AV11OrderedBy == 12 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConEmail";
         }
         else if ( ( AV11OrderedBy == 12 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConEmail DESC";
         }
         else if ( ( AV11OrderedBy == 13 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.CpjConLIn";
         }
         else if ( ( AV11OrderedBy == 13 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.CpjConLIn DESC";
         }
         else if ( ( AV11OrderedBy == 14 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CliNomeFamiliar";
         }
         else if ( ( AV11OrderedBy == 14 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CliNomeFamiliar DESC";
         }
         else if ( ( AV11OrderedBy == 15 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.CliMatricula";
         }
         else if ( ( AV11OrderedBy == 15 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.CliMatricula DESC";
         }
         else if ( ( AV11OrderedBy == 16 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T4.PjtNome";
         }
         else if ( ( AV11OrderedBy == 16 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T4.PjtNome DESC";
         }
         else if ( ( AV11OrderedBy == 17 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjNomeFan";
         }
         else if ( ( AV11OrderedBy == 17 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjNomeFan DESC";
         }
         else if ( ( AV11OrderedBy == 18 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjRazaoSoc";
         }
         else if ( ( AV11OrderedBy == 18 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjRazaoSoc DESC";
         }
         else if ( ( AV11OrderedBy == 19 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjMatricula";
         }
         else if ( ( AV11OrderedBy == 19 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjMatricula DESC";
         }
         else if ( ( AV11OrderedBy == 20 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjCNPJFormat";
         }
         else if ( ( AV11OrderedBy == 20 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjCNPJFormat DESC";
         }
         else if ( ( AV11OrderedBy == 21 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjIE";
         }
         else if ( ( AV11OrderedBy == 21 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjIE DESC";
         }
         else if ( ( AV11OrderedBy == 22 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjCelNum";
         }
         else if ( ( AV11OrderedBy == 22 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjCelNum DESC";
         }
         else if ( ( AV11OrderedBy == 23 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjTelNum";
         }
         else if ( ( AV11OrderedBy == 23 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjTelNum DESC";
         }
         else if ( ( AV11OrderedBy == 24 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjTelRam";
         }
         else if ( ( AV11OrderedBy == 24 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjTelRam DESC";
         }
         else if ( ( AV11OrderedBy == 25 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjWppNum";
         }
         else if ( ( AV11OrderedBy == 25 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjWppNum DESC";
         }
         else if ( ( AV11OrderedBy == 26 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjEmail";
         }
         else if ( ( AV11OrderedBy == 26 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjEmail DESC";
         }
         else if ( ( AV11OrderedBy == 27 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T3.CpjWebsite";
         }
         else if ( ( AV11OrderedBy == 27 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T3.CpjWebsite DESC";
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
                     return conditional_P005X2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (long)dynConstraints[49] , (long)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (long)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (long)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (string)dynConstraints[97] , (string)dynConstraints[98] , (string)dynConstraints[99] , (string)dynConstraints[100] , (string)dynConstraints[101] , (DateTime)dynConstraints[102] , (short)dynConstraints[103] , (bool)dynConstraints[104] );
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
          Object[] prmP005X2;
          prmP005X2 = new Object[] {
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV123Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV127Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV127Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV128Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV128Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV133Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV133Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV134Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV134Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV135Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV135Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV140Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV140Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV141Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV141Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV142Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV142Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_22_tfcpjconnome",GXType.VarChar,80,0) ,
          new ParDef("AV145Core_clientepjcontatowwds_23_tfcpjconnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV146Core_clientepjcontatowwds_24_tfcpjconnomeprim",GXType.VarChar,80,0) ,
          new ParDef("AV147Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel",GXType.VarChar,80,0) ,
          new ParDef("lV148Core_clientepjcontatowwds_26_tfcpjconsobrenome",GXType.VarChar,80,0) ,
          new ParDef("AV149Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV150Core_clientepjcontatowwds_28_tfcpjcontiponome",GXType.VarChar,80,0) ,
          new ParDef("AV151Core_clientepjcontatowwds_29_tfcpjcontiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV152Core_clientepjcontatowwds_30_tfcpjconcpfformat",GXType.VarChar,14,0) ,
          new ParDef("AV153Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel",GXType.VarChar,14,0) ,
          new ParDef("AV154Core_clientepjcontatowwds_32_tfcpjconnascimento",GXType.Date,8,0) ,
          new ParDef("AV155Core_clientepjcontatowwds_33_tfcpjconnascimento_to",GXType.Date,8,0) ,
          new ParDef("lV156Core_clientepjcontatowwds_34_tfcpjcongennome",GXType.VarChar,80,0) ,
          new ParDef("AV157Core_clientepjcontatowwds_35_tfcpjcongennome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV158Core_clientepjcontatowwds_36_tfcpjconcelnum",GXType.Char,20,0) ,
          new ParDef("AV159Core_clientepjcontatowwds_37_tfcpjconcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV160Core_clientepjcontatowwds_38_tfcpjcontelnum",GXType.Char,20,0) ,
          new ParDef("AV161Core_clientepjcontatowwds_39_tfcpjcontelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV162Core_clientepjcontatowwds_40_tfcpjcontelram",GXType.VarChar,10,0) ,
          new ParDef("AV163Core_clientepjcontatowwds_41_tfcpjcontelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV164Core_clientepjcontatowwds_42_tfcpjconwppnum",GXType.Char,20,0) ,
          new ParDef("AV165Core_clientepjcontatowwds_43_tfcpjconwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV166Core_clientepjcontatowwds_44_tfcpjconemail",GXType.VarChar,100,0) ,
          new ParDef("AV167Core_clientepjcontatowwds_45_tfcpjconemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV168Core_clientepjcontatowwds_46_tfcpjconlin",GXType.VarChar,1000,0) ,
          new ParDef("AV169Core_clientepjcontatowwds_47_tfcpjconlin_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV170Core_clientepjcontatowwds_48_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV171Core_clientepjcontatowwds_49_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV172Core_clientepjcontatowwds_50_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV173Core_clientepjcontatowwds_51_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV174Core_clientepjcontatowwds_52_tfcpjtiponome",GXType.VarChar,80,0) ,
          new ParDef("AV175Core_clientepjcontatowwds_53_tfcpjtiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV176Core_clientepjcontatowwds_54_tfcpjnomefan",GXType.VarChar,80,0) ,
          new ParDef("AV177Core_clientepjcontatowwds_55_tfcpjnomefan_sel",GXType.VarChar,80,0) ,
          new ParDef("lV178Core_clientepjcontatowwds_56_tfcpjrazaosoc",GXType.VarChar,80,0) ,
          new ParDef("AV179Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel",GXType.VarChar,80,0) ,
          new ParDef("AV180Core_clientepjcontatowwds_58_tfcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV181Core_clientepjcontatowwds_59_tfcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV182Core_clientepjcontatowwds_60_tfcpjcnpjformat",GXType.VarChar,18,0) ,
          new ParDef("AV183Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel",GXType.VarChar,18,0) ,
          new ParDef("lV184Core_clientepjcontatowwds_62_tfcpjie",GXType.VarChar,20,0) ,
          new ParDef("AV185Core_clientepjcontatowwds_63_tfcpjie_sel",GXType.VarChar,20,0) ,
          new ParDef("lV186Core_clientepjcontatowwds_64_tfcpjcelnum",GXType.Char,20,0) ,
          new ParDef("AV187Core_clientepjcontatowwds_65_tfcpjcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV188Core_clientepjcontatowwds_66_tfcpjtelnum",GXType.Char,20,0) ,
          new ParDef("AV189Core_clientepjcontatowwds_67_tfcpjtelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV190Core_clientepjcontatowwds_68_tfcpjtelram",GXType.VarChar,10,0) ,
          new ParDef("AV191Core_clientepjcontatowwds_69_tfcpjtelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV192Core_clientepjcontatowwds_70_tfcpjwppnum",GXType.Char,20,0) ,
          new ParDef("AV193Core_clientepjcontatowwds_71_tfcpjwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV194Core_clientepjcontatowwds_72_tfcpjemail",GXType.VarChar,100,0) ,
          new ParDef("AV195Core_clientepjcontatowwds_73_tfcpjemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV196Core_clientepjcontatowwds_74_tfcpjwebsite",GXType.VarChar,1000,0) ,
          new ParDef("AV197Core_clientepjcontatowwds_75_tfcpjwebsite_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("P005X2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP005X2,100, GxCacheFrequency.OFF ,true,false )
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
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((long[]) buf[3])[0] = rslt.getLong(4);
                ((long[]) buf[4])[0] = rslt.getLong(5);
                ((DateTime[]) buf[5])[0] = rslt.getGXDate(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((string[]) buf[7])[0] = rslt.getVarchar(8);
                ((bool[]) buf[8])[0] = rslt.wasNull(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((bool[]) buf[10])[0] = rslt.wasNull(9);
                ((string[]) buf[11])[0] = rslt.getString(10, 20);
                ((bool[]) buf[12])[0] = rslt.wasNull(10);
                ((string[]) buf[13])[0] = rslt.getVarchar(11);
                ((bool[]) buf[14])[0] = rslt.wasNull(11);
                ((string[]) buf[15])[0] = rslt.getString(12, 20);
                ((bool[]) buf[16])[0] = rslt.wasNull(12);
                ((string[]) buf[17])[0] = rslt.getString(13, 20);
                ((bool[]) buf[18])[0] = rslt.wasNull(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((string[]) buf[20])[0] = rslt.getVarchar(15);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getVarchar(17);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((string[]) buf[24])[0] = rslt.getVarchar(19);
                ((string[]) buf[25])[0] = rslt.getVarchar(20);
                ((bool[]) buf[26])[0] = rslt.wasNull(20);
                ((string[]) buf[27])[0] = rslt.getVarchar(21);
                ((bool[]) buf[28])[0] = rslt.wasNull(21);
                ((string[]) buf[29])[0] = rslt.getString(22, 20);
                ((bool[]) buf[30])[0] = rslt.wasNull(22);
                ((string[]) buf[31])[0] = rslt.getVarchar(23);
                ((bool[]) buf[32])[0] = rslt.wasNull(23);
                ((string[]) buf[33])[0] = rslt.getString(24, 20);
                ((bool[]) buf[34])[0] = rslt.wasNull(24);
                ((string[]) buf[35])[0] = rslt.getString(25, 20);
                ((bool[]) buf[36])[0] = rslt.wasNull(25);
                ((string[]) buf[37])[0] = rslt.getVarchar(26);
                ((string[]) buf[38])[0] = rslt.getVarchar(27);
                ((string[]) buf[39])[0] = rslt.getVarchar(28);
                ((string[]) buf[40])[0] = rslt.getVarchar(29);
                ((string[]) buf[41])[0] = rslt.getVarchar(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((short[]) buf[43])[0] = rslt.getShort(32);
                return;
       }
    }

 }

}
