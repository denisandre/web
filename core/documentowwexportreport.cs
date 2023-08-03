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
   public class documentowwexportreport : GXWebProcedure
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

      public documentowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentowwexportreport( IGxContext context )
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
         documentowwexportreport objdocumentowwexportreport;
         objdocumentowwexportreport = new documentowwexportreport();
         objdocumentowwexportreport.context.SetSubmitInitialConfig(context);
         objdocumentowwexportreport.initialize();
         Submit( executePrivateCatch,objdocumentowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((documentowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("DocumentoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "documentoww_Execute", out  GXt_boolean1) ;
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
               AV55Title = "Lista de Documento";
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
            H6K0( true, 0) ;
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
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV59DocOrigem_Filtro)) )
         {
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV59DocOrigem_Filtro, "")), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV60DocOrigemID_Filtro)) )
         {
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV60DocOrigemID_Filtro, "")), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "DOCVERSAO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16DocVersao1 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               if ( ! (0==AV16DocVersao1) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 2 )
                  {
                     AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                  }
                  AV18DocVersao = AV16DocVersao1;
                  H6K0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDocVersaoDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18DocVersao), "ZZZ9")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "DOCTIPOSIGLA") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19DocTipoSigla1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19DocTipoSigla1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                  }
                  AV21DocTipoSigla = AV19DocTipoSigla1;
                  H6K0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterDocTipoSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocTipoSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCVERSAO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25DocVersao2 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                  if ( ! (0==AV25DocVersao2) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 2 )
                     {
                        AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                     }
                     AV18DocVersao = AV25DocVersao2;
                     H6K0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDocVersaoDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18DocVersao), "ZZZ9")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "DOCTIPOSIGLA") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26DocTipoSigla2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26DocTipoSigla2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                     }
                     AV21DocTipoSigla = AV26DocTipoSigla2;
                     H6K0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterDocTipoSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocTipoSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCVERSAO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30DocVersao3 = (short)(Math.Round(NumberUtil.Val( AV32GridStateDynamicFilter.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
                     if ( ! (0==AV30DocVersao3) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", ">=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "=", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 2 )
                        {
                           AV17FilterDocVersaoDescription = StringUtil.Format( "%1 (%2)", "Versão", "<=", "", "", "", "", "", "", "");
                        }
                        AV18DocVersao = AV30DocVersao3;
                        H6K0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterDocVersaoDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV18DocVersao), "ZZZ9")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "DOCTIPOSIGLA") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31DocTipoSigla3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31DocTipoSigla3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterDocTipoSiglaDescription = StringUtil.Format( "%1 (%2)", "Sigla", "Contém", "", "", "", "", "", "", "");
                        }
                        AV21DocTipoSigla = AV31DocTipoSigla3;
                        H6K0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterDocTipoSiglaDescription, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21DocTipoSigla, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFDocTipoNome_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFDocTipoNome_Sel, "<#Empty#>")==0)));
            AV40TFDocTipoNome_Sel = (AV44TempBoolean ? "(Vazio)" : AV40TFDocTipoNome_Sel);
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFDocTipoNome_Sel, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFDocTipoNome_Sel = (AV44TempBoolean ? "<#Empty#>" : AV40TFDocTipoNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFDocTipoNome)) )
            {
               H6K0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFDocTipoNome, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFDocNome_Sel)) )
         {
            AV44TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFDocNome_Sel, "<#Empty#>")==0)));
            AV38TFDocNome_Sel = (AV44TempBoolean ? "(Vazio)" : AV38TFDocNome_Sel);
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFDocNome_Sel, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFDocNome_Sel = (AV44TempBoolean ? "<#Empty#>" : AV38TFDocNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFDocNome)) )
            {
               H6K0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFDocNome, "@!")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (0==AV65TFDocVersao) && (0==AV66TFDocVersao_To) ) )
         {
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Versão", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV65TFDocVersao), "ZZZ9")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV67TFDocVersao_To_Description = StringUtil.Format( "%1 (%2)", "Versão", "Até", "", "", "", "", "", "", "");
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV67TFDocVersao_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(AV66TFDocVersao_To), "ZZZ9")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! ( (DateTime.MinValue==AV41TFDocInsDataHora) && (DateTime.MinValue==AV42TFDocInsDataHora_To) ) )
         {
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído em", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV41TFDocInsDataHora, "99/99/9999 99:99:99.999"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV43TFDocInsDataHora_To_Description = StringUtil.Format( "%1 (%2)", "Incluído em", "Até", "", "", "", "", "", "", "");
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43TFDocInsDataHora_To_Description, "")), 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV42TFDocInsDataHora_To, "99/99/9999 99:99:99.999"), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV61TFDocContrato_Sel) )
         {
            if ( AV61TFDocContrato_Sel == 1 )
            {
               AV63FilterTFDocContrato_SelValueDescription = "Marcado";
            }
            else if ( AV61TFDocContrato_Sel == 2 )
            {
               AV63FilterTFDocContrato_SelValueDescription = "Desmarcado";
            }
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Contrato", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63FilterTFDocContrato_SelValueDescription, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! (0==AV62TFDocAssinado_Sel) )
         {
            if ( AV62TFDocAssinado_Sel == 1 )
            {
               AV64FilterTFDocAssinado_SelValueDescription = "Marcado";
            }
            else if ( AV62TFDocAssinado_Sel == 2 )
            {
               AV64FilterTFDocAssinado_SelValueDescription = "Desmarcado";
            }
            H6K0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Assinado", 25, Gx_line+0, 130, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64FilterTFDocAssinado_SelValueDescription, "")), 130, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H6K0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H6K0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Tipo", 30, Gx_line+10, 214, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 218, Gx_line+10, 402, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Versão", 406, Gx_line+10, 498, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído em", 502, Gx_line+10, 594, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Contrato", 598, Gx_line+10, 690, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Assinado", 694, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV71Core_documentowwds_1_docorigem_filtro = AV59DocOrigem_Filtro;
         AV72Core_documentowwds_2_docorigemid_filtro = AV60DocOrigemID_Filtro;
         AV73Core_documentowwds_3_filterfulltext = AV13FilterFullText;
         AV74Core_documentowwds_4_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV75Core_documentowwds_5_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV76Core_documentowwds_6_docversao1 = AV16DocVersao1;
         AV77Core_documentowwds_7_doctiposigla1 = AV19DocTipoSigla1;
         AV78Core_documentowwds_8_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV79Core_documentowwds_9_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV80Core_documentowwds_10_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV81Core_documentowwds_11_docversao2 = AV25DocVersao2;
         AV82Core_documentowwds_12_doctiposigla2 = AV26DocTipoSigla2;
         AV83Core_documentowwds_13_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV84Core_documentowwds_14_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV85Core_documentowwds_15_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV86Core_documentowwds_16_docversao3 = AV30DocVersao3;
         AV87Core_documentowwds_17_doctiposigla3 = AV31DocTipoSigla3;
         AV88Core_documentowwds_18_tfdoctiponome = AV39TFDocTipoNome;
         AV89Core_documentowwds_19_tfdoctiponome_sel = AV40TFDocTipoNome_Sel;
         AV90Core_documentowwds_20_tfdocnome = AV37TFDocNome;
         AV91Core_documentowwds_21_tfdocnome_sel = AV38TFDocNome_Sel;
         AV92Core_documentowwds_22_tfdocversao = AV65TFDocVersao;
         AV93Core_documentowwds_23_tfdocversao_to = AV66TFDocVersao_To;
         AV94Core_documentowwds_24_tfdocinsdatahora = AV41TFDocInsDataHora;
         AV95Core_documentowwds_25_tfdocinsdatahora_to = AV42TFDocInsDataHora_To;
         AV96Core_documentowwds_26_tfdoccontrato_sel = AV61TFDocContrato_Sel;
         AV97Core_documentowwds_27_tfdocassinado_sel = AV62TFDocAssinado_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV73Core_documentowwds_3_filterfulltext ,
                                              AV74Core_documentowwds_4_dynamicfiltersselector1 ,
                                              AV75Core_documentowwds_5_dynamicfiltersoperator1 ,
                                              AV76Core_documentowwds_6_docversao1 ,
                                              AV77Core_documentowwds_7_doctiposigla1 ,
                                              AV78Core_documentowwds_8_dynamicfiltersenabled2 ,
                                              AV79Core_documentowwds_9_dynamicfiltersselector2 ,
                                              AV80Core_documentowwds_10_dynamicfiltersoperator2 ,
                                              AV81Core_documentowwds_11_docversao2 ,
                                              AV82Core_documentowwds_12_doctiposigla2 ,
                                              AV83Core_documentowwds_13_dynamicfiltersenabled3 ,
                                              AV84Core_documentowwds_14_dynamicfiltersselector3 ,
                                              AV85Core_documentowwds_15_dynamicfiltersoperator3 ,
                                              AV86Core_documentowwds_16_docversao3 ,
                                              AV87Core_documentowwds_17_doctiposigla3 ,
                                              AV89Core_documentowwds_19_tfdoctiponome_sel ,
                                              AV88Core_documentowwds_18_tfdoctiponome ,
                                              AV91Core_documentowwds_21_tfdocnome_sel ,
                                              AV90Core_documentowwds_20_tfdocnome ,
                                              AV92Core_documentowwds_22_tfdocversao ,
                                              AV93Core_documentowwds_23_tfdocversao_to ,
                                              AV94Core_documentowwds_24_tfdocinsdatahora ,
                                              AV95Core_documentowwds_25_tfdocinsdatahora_to ,
                                              AV96Core_documentowwds_26_tfdoccontrato_sel ,
                                              AV97Core_documentowwds_27_tfdocassinado_sel ,
                                              A148DocTipoNome ,
                                              A305DocNome ,
                                              A325DocVersao ,
                                              A147DocTipoSigla ,
                                              A294DocInsDataHora ,
                                              A480DocContrato ,
                                              A481DocAssinado ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A640DocAtivo ,
                                              AV57DocOrigem ,
                                              AV58DocOrigemID ,
                                              A290DocOrigem ,
                                              A291DocOrigemID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT,
                                              TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV73Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Core_documentowwds_3_filterfulltext), "%", "");
         lV73Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Core_documentowwds_3_filterfulltext), "%", "");
         lV73Core_documentowwds_3_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV73Core_documentowwds_3_filterfulltext), "%", "");
         lV77Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV77Core_documentowwds_7_doctiposigla1), "%", "");
         lV77Core_documentowwds_7_doctiposigla1 = StringUtil.Concat( StringUtil.RTrim( AV77Core_documentowwds_7_doctiposigla1), "%", "");
         lV82Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV82Core_documentowwds_12_doctiposigla2), "%", "");
         lV82Core_documentowwds_12_doctiposigla2 = StringUtil.Concat( StringUtil.RTrim( AV82Core_documentowwds_12_doctiposigla2), "%", "");
         lV87Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_17_doctiposigla3), "%", "");
         lV87Core_documentowwds_17_doctiposigla3 = StringUtil.Concat( StringUtil.RTrim( AV87Core_documentowwds_17_doctiposigla3), "%", "");
         lV88Core_documentowwds_18_tfdoctiponome = StringUtil.Concat( StringUtil.RTrim( AV88Core_documentowwds_18_tfdoctiponome), "%", "");
         lV90Core_documentowwds_20_tfdocnome = StringUtil.Concat( StringUtil.RTrim( AV90Core_documentowwds_20_tfdocnome), "%", "");
         /* Using cursor P006K2 */
         pr_default.execute(0, new Object[] {AV57DocOrigem, AV58DocOrigemID, lV73Core_documentowwds_3_filterfulltext, lV73Core_documentowwds_3_filterfulltext, lV73Core_documentowwds_3_filterfulltext, AV76Core_documentowwds_6_docversao1, AV76Core_documentowwds_6_docversao1, AV76Core_documentowwds_6_docversao1, lV77Core_documentowwds_7_doctiposigla1, lV77Core_documentowwds_7_doctiposigla1, AV81Core_documentowwds_11_docversao2, AV81Core_documentowwds_11_docversao2, AV81Core_documentowwds_11_docversao2, lV82Core_documentowwds_12_doctiposigla2, lV82Core_documentowwds_12_doctiposigla2, AV86Core_documentowwds_16_docversao3, AV86Core_documentowwds_16_docversao3, AV86Core_documentowwds_16_docversao3, lV87Core_documentowwds_17_doctiposigla3, lV87Core_documentowwds_17_doctiposigla3, lV88Core_documentowwds_18_tfdoctiponome, AV89Core_documentowwds_19_tfdoctiponome_sel, lV90Core_documentowwds_20_tfdocnome, AV91Core_documentowwds_21_tfdocnome_sel, AV92Core_documentowwds_22_tfdocversao, AV93Core_documentowwds_23_tfdocversao_to, AV94Core_documentowwds_24_tfdocinsdatahora, AV95Core_documentowwds_25_tfdocinsdatahora_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A146DocTipoID = P006K2_A146DocTipoID[0];
            A640DocAtivo = P006K2_A640DocAtivo[0];
            n640DocAtivo = P006K2_n640DocAtivo[0];
            A481DocAssinado = P006K2_A481DocAssinado[0];
            A480DocContrato = P006K2_A480DocContrato[0];
            A294DocInsDataHora = P006K2_A294DocInsDataHora[0];
            A147DocTipoSigla = P006K2_A147DocTipoSigla[0];
            A325DocVersao = P006K2_A325DocVersao[0];
            A305DocNome = P006K2_A305DocNome[0];
            A148DocTipoNome = P006K2_A148DocTipoNome[0];
            A291DocOrigemID = P006K2_A291DocOrigemID[0];
            A290DocOrigem = P006K2_A290DocOrigem[0];
            A289DocID = P006K2_A289DocID[0];
            A147DocTipoSigla = P006K2_A147DocTipoSigla[0];
            A148DocTipoNome = P006K2_A148DocTipoNome[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H6K0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A148DocTipoNome, "@!")), 30, Gx_line+10, 214, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A305DocNome, "@!")), 218, Gx_line+10, 402, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A325DocVersao), "ZZZ9")), 406, Gx_line+10, 498, Gx_line+25, 2+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A294DocInsDataHora, "99/99/9999 99:99:99.999"), 502, Gx_line+10, 594, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A480DocContrato), 598, Gx_line+10, 690, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( A481DocAssinado), 694, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("core.DocumentoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.DocumentoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("core.DocumentoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV98GXV1 = 1;
         while ( AV98GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV98GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "DOCORIGEM_FILTRO") == 0 )
            {
               AV59DocOrigem_Filtro = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "DOCORIGEMID_FILTRO") == 0 )
            {
               AV60DocOrigemID_Filtro = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME") == 0 )
            {
               AV39TFDocTipoNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCTIPONOME_SEL") == 0 )
            {
               AV40TFDocTipoNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCNOME") == 0 )
            {
               AV37TFDocNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCNOME_SEL") == 0 )
            {
               AV38TFDocNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCVERSAO") == 0 )
            {
               AV65TFDocVersao = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AV66TFDocVersao_To = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCINSDATAHORA") == 0 )
            {
               AV41TFDocInsDataHora = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Value, 2);
               AV42TFDocInsDataHora_To = context.localUtil.CToT( AV36GridStateFilterValue.gxTpr_Valueto, 2);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCCONTRATO_SEL") == 0 )
            {
               AV61TFDocContrato_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFDOCASSINADO_SEL") == 0 )
            {
               AV62TFDocAssinado_Sel = (short)(Math.Round(NumberUtil.Val( AV36GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEM") == 0 )
            {
               AV57DocOrigem = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PARM_&DOCORIGEMID") == 0 )
            {
               AV58DocOrigemID = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV98GXV1 = (int)(AV98GXV1+1);
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

      protected void H6K0( bool bFoot ,
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
                  AV53PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV50DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV48AppName = "DVelop Software Solutions";
               AV54Phone = "+1 550 8923";
               AV52Mail = "info@mail.com";
               AV56Website = "http://www.web.com";
               AV45AddressLine1 = "French Boulevard 2859";
               AV46AddressLine2 = "Downtown";
               AV47AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV56Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV55Title = "";
         AV59DocOrigem_Filtro = "";
         AV60DocOrigemID_Filtro = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV17FilterDocVersaoDescription = "";
         AV19DocTipoSigla1 = "";
         AV20FilterDocTipoSiglaDescription = "";
         AV21DocTipoSigla = "";
         AV23DynamicFiltersSelector2 = "";
         AV26DocTipoSigla2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV31DocTipoSigla3 = "";
         AV40TFDocTipoNome_Sel = "";
         AV39TFDocTipoNome = "";
         AV38TFDocNome_Sel = "";
         AV37TFDocNome = "";
         AV67TFDocVersao_To_Description = "";
         AV41TFDocInsDataHora = (DateTime)(DateTime.MinValue);
         AV42TFDocInsDataHora_To = (DateTime)(DateTime.MinValue);
         AV43TFDocInsDataHora_To_Description = "";
         AV63FilterTFDocContrato_SelValueDescription = "";
         AV64FilterTFDocAssinado_SelValueDescription = "";
         AV71Core_documentowwds_1_docorigem_filtro = "";
         AV72Core_documentowwds_2_docorigemid_filtro = "";
         AV73Core_documentowwds_3_filterfulltext = "";
         AV74Core_documentowwds_4_dynamicfiltersselector1 = "";
         AV77Core_documentowwds_7_doctiposigla1 = "";
         AV79Core_documentowwds_9_dynamicfiltersselector2 = "";
         AV82Core_documentowwds_12_doctiposigla2 = "";
         AV84Core_documentowwds_14_dynamicfiltersselector3 = "";
         AV87Core_documentowwds_17_doctiposigla3 = "";
         AV88Core_documentowwds_18_tfdoctiponome = "";
         AV89Core_documentowwds_19_tfdoctiponome_sel = "";
         AV90Core_documentowwds_20_tfdocnome = "";
         AV91Core_documentowwds_21_tfdocnome_sel = "";
         AV94Core_documentowwds_24_tfdocinsdatahora = (DateTime)(DateTime.MinValue);
         AV95Core_documentowwds_25_tfdocinsdatahora_to = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         lV73Core_documentowwds_3_filterfulltext = "";
         lV77Core_documentowwds_7_doctiposigla1 = "";
         lV82Core_documentowwds_12_doctiposigla2 = "";
         lV87Core_documentowwds_17_doctiposigla3 = "";
         lV88Core_documentowwds_18_tfdoctiponome = "";
         lV90Core_documentowwds_20_tfdocnome = "";
         A148DocTipoNome = "";
         A305DocNome = "";
         A147DocTipoSigla = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         AV57DocOrigem = "";
         AV58DocOrigemID = "";
         A290DocOrigem = "";
         A291DocOrigemID = "";
         P006K2_A146DocTipoID = new int[1] ;
         P006K2_A640DocAtivo = new bool[] {false} ;
         P006K2_n640DocAtivo = new bool[] {false} ;
         P006K2_A481DocAssinado = new bool[] {false} ;
         P006K2_A480DocContrato = new bool[] {false} ;
         P006K2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         P006K2_A147DocTipoSigla = new string[] {""} ;
         P006K2_A325DocVersao = new short[1] ;
         P006K2_A305DocNome = new string[] {""} ;
         P006K2_A148DocTipoNome = new string[] {""} ;
         P006K2_A291DocOrigemID = new string[] {""} ;
         P006K2_A290DocOrigem = new string[] {""} ;
         P006K2_A289DocID = new Guid[] {Guid.Empty} ;
         A289DocID = Guid.Empty;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV53PageInfo = "";
         AV50DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV48AppName = "";
         AV54Phone = "";
         AV52Mail = "";
         AV56Website = "";
         AV45AddressLine1 = "";
         AV46AddressLine2 = "";
         AV47AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P006K2_A146DocTipoID, P006K2_A640DocAtivo, P006K2_n640DocAtivo, P006K2_A481DocAssinado, P006K2_A480DocContrato, P006K2_A294DocInsDataHora, P006K2_A147DocTipoSigla, P006K2_A325DocVersao, P006K2_A305DocNome, P006K2_A148DocTipoNome,
               P006K2_A291DocOrigemID, P006K2_A290DocOrigem, P006K2_A289DocID
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
      private short AV16DocVersao1 ;
      private short AV18DocVersao ;
      private short AV24DynamicFiltersOperator2 ;
      private short AV25DocVersao2 ;
      private short AV29DynamicFiltersOperator3 ;
      private short AV30DocVersao3 ;
      private short AV65TFDocVersao ;
      private short AV66TFDocVersao_To ;
      private short AV61TFDocContrato_Sel ;
      private short AV62TFDocAssinado_Sel ;
      private short AV75Core_documentowwds_5_dynamicfiltersoperator1 ;
      private short AV76Core_documentowwds_6_docversao1 ;
      private short AV80Core_documentowwds_10_dynamicfiltersoperator2 ;
      private short AV81Core_documentowwds_11_docversao2 ;
      private short AV85Core_documentowwds_15_dynamicfiltersoperator3 ;
      private short AV86Core_documentowwds_16_docversao3 ;
      private short AV92Core_documentowwds_22_tfdocversao ;
      private short AV93Core_documentowwds_23_tfdocversao_to ;
      private short AV96Core_documentowwds_26_tfdoccontrato_sel ;
      private short AV97Core_documentowwds_27_tfdocassinado_sel ;
      private short A325DocVersao ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A146DocTipoID ;
      private int AV98GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV41TFDocInsDataHora ;
      private DateTime AV42TFDocInsDataHora_To ;
      private DateTime AV94Core_documentowwds_24_tfdocinsdatahora ;
      private DateTime AV95Core_documentowwds_25_tfdocinsdatahora_to ;
      private DateTime A294DocInsDataHora ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV44TempBoolean ;
      private bool AV78Core_documentowwds_8_dynamicfiltersenabled2 ;
      private bool AV83Core_documentowwds_13_dynamicfiltersenabled3 ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool AV12OrderedDsc ;
      private bool A640DocAtivo ;
      private bool n640DocAtivo ;
      private string AV55Title ;
      private string AV59DocOrigem_Filtro ;
      private string AV60DocOrigemID_Filtro ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV17FilterDocVersaoDescription ;
      private string AV19DocTipoSigla1 ;
      private string AV20FilterDocTipoSiglaDescription ;
      private string AV21DocTipoSigla ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV26DocTipoSigla2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV31DocTipoSigla3 ;
      private string AV40TFDocTipoNome_Sel ;
      private string AV39TFDocTipoNome ;
      private string AV38TFDocNome_Sel ;
      private string AV37TFDocNome ;
      private string AV67TFDocVersao_To_Description ;
      private string AV43TFDocInsDataHora_To_Description ;
      private string AV63FilterTFDocContrato_SelValueDescription ;
      private string AV64FilterTFDocAssinado_SelValueDescription ;
      private string AV71Core_documentowwds_1_docorigem_filtro ;
      private string AV72Core_documentowwds_2_docorigemid_filtro ;
      private string AV73Core_documentowwds_3_filterfulltext ;
      private string AV74Core_documentowwds_4_dynamicfiltersselector1 ;
      private string AV77Core_documentowwds_7_doctiposigla1 ;
      private string AV79Core_documentowwds_9_dynamicfiltersselector2 ;
      private string AV82Core_documentowwds_12_doctiposigla2 ;
      private string AV84Core_documentowwds_14_dynamicfiltersselector3 ;
      private string AV87Core_documentowwds_17_doctiposigla3 ;
      private string AV88Core_documentowwds_18_tfdoctiponome ;
      private string AV89Core_documentowwds_19_tfdoctiponome_sel ;
      private string AV90Core_documentowwds_20_tfdocnome ;
      private string AV91Core_documentowwds_21_tfdocnome_sel ;
      private string lV73Core_documentowwds_3_filterfulltext ;
      private string lV77Core_documentowwds_7_doctiposigla1 ;
      private string lV82Core_documentowwds_12_doctiposigla2 ;
      private string lV87Core_documentowwds_17_doctiposigla3 ;
      private string lV88Core_documentowwds_18_tfdoctiponome ;
      private string lV90Core_documentowwds_20_tfdocnome ;
      private string A148DocTipoNome ;
      private string A305DocNome ;
      private string A147DocTipoSigla ;
      private string AV57DocOrigem ;
      private string AV58DocOrigemID ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string AV53PageInfo ;
      private string AV50DateInfo ;
      private string AV48AppName ;
      private string AV54Phone ;
      private string AV52Mail ;
      private string AV56Website ;
      private string AV45AddressLine1 ;
      private string AV46AddressLine2 ;
      private string AV47AddressLine3 ;
      private Guid A289DocID ;
      private IGxSession AV33Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P006K2_A146DocTipoID ;
      private bool[] P006K2_A640DocAtivo ;
      private bool[] P006K2_n640DocAtivo ;
      private bool[] P006K2_A481DocAssinado ;
      private bool[] P006K2_A480DocContrato ;
      private DateTime[] P006K2_A294DocInsDataHora ;
      private string[] P006K2_A147DocTipoSigla ;
      private short[] P006K2_A325DocVersao ;
      private string[] P006K2_A305DocNome ;
      private string[] P006K2_A148DocTipoNome ;
      private string[] P006K2_A291DocOrigemID ;
      private string[] P006K2_A290DocOrigem ;
      private Guid[] P006K2_A289DocID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class documentowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P006K2( IGxContext context ,
                                             string AV73Core_documentowwds_3_filterfulltext ,
                                             string AV74Core_documentowwds_4_dynamicfiltersselector1 ,
                                             short AV75Core_documentowwds_5_dynamicfiltersoperator1 ,
                                             short AV76Core_documentowwds_6_docversao1 ,
                                             string AV77Core_documentowwds_7_doctiposigla1 ,
                                             bool AV78Core_documentowwds_8_dynamicfiltersenabled2 ,
                                             string AV79Core_documentowwds_9_dynamicfiltersselector2 ,
                                             short AV80Core_documentowwds_10_dynamicfiltersoperator2 ,
                                             short AV81Core_documentowwds_11_docversao2 ,
                                             string AV82Core_documentowwds_12_doctiposigla2 ,
                                             bool AV83Core_documentowwds_13_dynamicfiltersenabled3 ,
                                             string AV84Core_documentowwds_14_dynamicfiltersselector3 ,
                                             short AV85Core_documentowwds_15_dynamicfiltersoperator3 ,
                                             short AV86Core_documentowwds_16_docversao3 ,
                                             string AV87Core_documentowwds_17_doctiposigla3 ,
                                             string AV89Core_documentowwds_19_tfdoctiponome_sel ,
                                             string AV88Core_documentowwds_18_tfdoctiponome ,
                                             string AV91Core_documentowwds_21_tfdocnome_sel ,
                                             string AV90Core_documentowwds_20_tfdocnome ,
                                             short AV92Core_documentowwds_22_tfdocversao ,
                                             short AV93Core_documentowwds_23_tfdocversao_to ,
                                             DateTime AV94Core_documentowwds_24_tfdocinsdatahora ,
                                             DateTime AV95Core_documentowwds_25_tfdocinsdatahora_to ,
                                             short AV96Core_documentowwds_26_tfdoccontrato_sel ,
                                             short AV97Core_documentowwds_27_tfdocassinado_sel ,
                                             string A148DocTipoNome ,
                                             string A305DocNome ,
                                             short A325DocVersao ,
                                             string A147DocTipoSigla ,
                                             DateTime A294DocInsDataHora ,
                                             bool A480DocContrato ,
                                             bool A481DocAssinado ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A640DocAtivo ,
                                             string AV57DocOrigem ,
                                             string AV58DocOrigemID ,
                                             string A290DocOrigem ,
                                             string A291DocOrigemID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[28];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.DocTipoID, T1.DocAtivo, T1.DocAssinado, T1.DocContrato, T1.DocInsDataHora, T2.DocTipoSigla, T1.DocVersao, T1.DocNome, T2.DocTipoNome, T1.DocOrigemID, T1.DocOrigem, T1.DocID FROM (tb_documento T1 INNER JOIN tb_documentotipo T2 ON T2.DocTipoID = T1.DocTipoID)";
         AddWhere(sWhereString, "(T1.DocOrigem = ( :AV57DocOrigem) and T1.DocOrigemID = ( :AV58DocOrigemID))");
         AddWhere(sWhereString, "(T1.DocAtivo = TRUE)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV73Core_documentowwds_3_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T2.DocTipoNome like '%' || :lV73Core_documentowwds_3_filterfulltext) or ( T1.DocNome like '%' || :lV73Core_documentowwds_3_filterfulltext) or ( SUBSTR(TO_CHAR(T1.DocVersao,'9999'), 2) like '%' || :lV73Core_documentowwds_3_filterfulltext))");
         }
         else
         {
            GXv_int2[2] = 1;
            GXv_int2[3] = 1;
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV75Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! (0==AV76Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV76Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV75Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! (0==AV76Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV76Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_documentowwds_4_dynamicfiltersselector1, "DOCVERSAO") == 0 ) && ( AV75Core_documentowwds_5_dynamicfiltersoperator1 == 2 ) && ( ! (0==AV76Core_documentowwds_6_docversao1) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV76Core_documentowwds_6_docversao1)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV75Core_documentowwds_5_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV77Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ( StringUtil.StrCmp(AV74Core_documentowwds_4_dynamicfiltersselector1, "DOCTIPOSIGLA") == 0 ) && ( AV75Core_documentowwds_5_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_documentowwds_7_doctiposigla1)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV77Core_documentowwds_7_doctiposigla1)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV78Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV80Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! (0==AV81Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV81Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV78Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV80Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! (0==AV81Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV81Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV78Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Core_documentowwds_9_dynamicfiltersselector2, "DOCVERSAO") == 0 ) && ( AV80Core_documentowwds_10_dynamicfiltersoperator2 == 2 ) && ( ! (0==AV81Core_documentowwds_11_docversao2) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV81Core_documentowwds_11_docversao2)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV78Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV80Core_documentowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV82Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV78Core_documentowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV79Core_documentowwds_9_dynamicfiltersselector2, "DOCTIPOSIGLA") == 0 ) && ( AV80Core_documentowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV82Core_documentowwds_12_doctiposigla2)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV82Core_documentowwds_12_doctiposigla2)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( AV83Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! (0==AV86Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV86Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( AV83Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! (0==AV86Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao = :AV86Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( AV83Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Core_documentowwds_14_dynamicfiltersselector3, "DOCVERSAO") == 0 ) && ( AV85Core_documentowwds_15_dynamicfiltersoperator3 == 2 ) && ( ! (0==AV86Core_documentowwds_16_docversao3) ) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV86Core_documentowwds_16_docversao3)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( AV83Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_15_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like :lV87Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( AV83Core_documentowwds_13_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV84Core_documentowwds_14_dynamicfiltersselector3, "DOCTIPOSIGLA") == 0 ) && ( AV85Core_documentowwds_15_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV87Core_documentowwds_17_doctiposigla3)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoSigla like '%' || :lV87Core_documentowwds_17_doctiposigla3)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_documentowwds_19_tfdoctiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV88Core_documentowwds_18_tfdoctiponome)) ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome like :lV88Core_documentowwds_18_tfdoctiponome)");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_documentowwds_19_tfdoctiponome_sel)) && ! ( StringUtil.StrCmp(AV89Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.DocTipoNome = ( :AV89Core_documentowwds_19_tfdoctiponome_sel))");
         }
         else
         {
            GXv_int2[21] = 1;
         }
         if ( StringUtil.StrCmp(AV89Core_documentowwds_19_tfdoctiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.DocTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_documentowwds_21_tfdocnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_documentowwds_20_tfdocnome)) ) )
         {
            AddWhere(sWhereString, "(T1.DocNome like :lV90Core_documentowwds_20_tfdocnome)");
         }
         else
         {
            GXv_int2[22] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_documentowwds_21_tfdocnome_sel)) && ! ( StringUtil.StrCmp(AV91Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.DocNome = ( :AV91Core_documentowwds_21_tfdocnome_sel))");
         }
         else
         {
            GXv_int2[23] = 1;
         }
         if ( StringUtil.StrCmp(AV91Core_documentowwds_21_tfdocnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.DocNome))=0))");
         }
         if ( ! (0==AV92Core_documentowwds_22_tfdocversao) )
         {
            AddWhere(sWhereString, "(T1.DocVersao >= :AV92Core_documentowwds_22_tfdocversao)");
         }
         else
         {
            GXv_int2[24] = 1;
         }
         if ( ! (0==AV93Core_documentowwds_23_tfdocversao_to) )
         {
            AddWhere(sWhereString, "(T1.DocVersao <= :AV93Core_documentowwds_23_tfdocversao_to)");
         }
         else
         {
            GXv_int2[25] = 1;
         }
         if ( ! (DateTime.MinValue==AV94Core_documentowwds_24_tfdocinsdatahora) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora >= :AV94Core_documentowwds_24_tfdocinsdatahora)");
         }
         else
         {
            GXv_int2[26] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Core_documentowwds_25_tfdocinsdatahora_to) )
         {
            AddWhere(sWhereString, "(T1.DocInsDataHora <= :AV95Core_documentowwds_25_tfdocinsdatahora_to)");
         }
         else
         {
            GXv_int2[27] = 1;
         }
         if ( AV96Core_documentowwds_26_tfdoccontrato_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = TRUE)");
         }
         if ( AV96Core_documentowwds_26_tfdoccontrato_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocContrato = FALSE)");
         }
         if ( AV97Core_documentowwds_27_tfdocassinado_sel == 1 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = TRUE)");
         }
         if ( AV97Core_documentowwds_27_tfdocassinado_sel == 2 )
         {
            AddWhere(sWhereString, "(T1.DocAssinado = FALSE)");
         }
         scmdbuf += sWhereString;
         if ( AV11OrderedBy == 1 )
         {
            scmdbuf += " ORDER BY T1.DocOrigem, T1.DocOrigemID, T1.DocInsDataHora DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.DocTipoNome";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.DocTipoNome DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocNome";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocNome DESC";
         }
         else if ( ( AV11OrderedBy == 4 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocVersao";
         }
         else if ( ( AV11OrderedBy == 4 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocVersao DESC";
         }
         else if ( ( AV11OrderedBy == 5 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocInsDataHora";
         }
         else if ( ( AV11OrderedBy == 5 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocInsDataHora DESC";
         }
         else if ( ( AV11OrderedBy == 6 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocContrato";
         }
         else if ( ( AV11OrderedBy == 6 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocContrato DESC";
         }
         else if ( ( AV11OrderedBy == 7 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.DocAssinado";
         }
         else if ( ( AV11OrderedBy == 7 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.DocAssinado DESC";
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
                     return conditional_P006K2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (short)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (short)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (short)dynConstraints[19] , (short)dynConstraints[20] , (DateTime)dynConstraints[21] , (DateTime)dynConstraints[22] , (short)dynConstraints[23] , (short)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (short)dynConstraints[27] , (string)dynConstraints[28] , (DateTime)dynConstraints[29] , (bool)dynConstraints[30] , (bool)dynConstraints[31] , (short)dynConstraints[32] , (bool)dynConstraints[33] , (bool)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] );
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
          Object[] prmP006K2;
          prmP006K2 = new Object[] {
          new ParDef("AV57DocOrigem",GXType.VarChar,30,0) ,
          new ParDef("AV58DocOrigemID",GXType.VarChar,50,0) ,
          new ParDef("lV73Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV73Core_documentowwds_3_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV76Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV76Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("AV76Core_documentowwds_6_docversao1",GXType.Int16,4,0) ,
          new ParDef("lV77Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("lV77Core_documentowwds_7_doctiposigla1",GXType.VarChar,20,0) ,
          new ParDef("AV81Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV81Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("AV81Core_documentowwds_11_docversao2",GXType.Int16,4,0) ,
          new ParDef("lV82Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("lV82Core_documentowwds_12_doctiposigla2",GXType.VarChar,20,0) ,
          new ParDef("AV86Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("AV86Core_documentowwds_16_docversao3",GXType.Int16,4,0) ,
          new ParDef("lV87Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV87Core_documentowwds_17_doctiposigla3",GXType.VarChar,20,0) ,
          new ParDef("lV88Core_documentowwds_18_tfdoctiponome",GXType.VarChar,80,0) ,
          new ParDef("AV89Core_documentowwds_19_tfdoctiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV90Core_documentowwds_20_tfdocnome",GXType.VarChar,80,0) ,
          new ParDef("AV91Core_documentowwds_21_tfdocnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV92Core_documentowwds_22_tfdocversao",GXType.Int16,4,0) ,
          new ParDef("AV93Core_documentowwds_23_tfdocversao_to",GXType.Int16,4,0) ,
          new ParDef("AV94Core_documentowwds_24_tfdocinsdatahora",GXType.DateTime2,10,12) ,
          new ParDef("AV95Core_documentowwds_25_tfdocinsdatahora_to",GXType.DateTime2,10,12)
          };
          def= new CursorDef[] {
              new CursorDef("P006K2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP006K2,100, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((bool[]) buf[3])[0] = rslt.getBool(3);
                ((bool[]) buf[4])[0] = rslt.getBool(4);
                ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5, true);
                ((string[]) buf[6])[0] = rslt.getVarchar(6);
                ((short[]) buf[7])[0] = rslt.getShort(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((string[]) buf[9])[0] = rslt.getVarchar(9);
                ((string[]) buf[10])[0] = rslt.getVarchar(10);
                ((string[]) buf[11])[0] = rslt.getVarchar(11);
                ((Guid[]) buf[12])[0] = rslt.getGuid(12);
                return;
       }
    }

 }

}
