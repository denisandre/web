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
   public class produtowwexportreport : GXWebProcedure
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

      public produtowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtowwexportreport( IGxContext context )
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
         produtowwexportreport objprodutowwexportreport;
         objprodutowwexportreport = new produtowwexportreport();
         objprodutowwexportreport.context.SetSubmitInitialConfig(context);
         objprodutowwexportreport.initialize();
         Submit( executePrivateCatch,objprodutowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("ProdutoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "produtoww_Execute", out  GXt_boolean1) ;
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
               AV54Title = "Lista de Produto ou Serviço";
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
            H4D0( true, 0) ;
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
         if ( ! (false==AV56PrdDel_Filtro) )
         {
            H4D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV56PrdDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H4D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV32GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PRDCODIGO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV16PrdCodigo1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16PrdCodigo1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18PrdCodigo = AV16PrdCodigo1;
                  H4D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrdCodigoDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrdCodigo, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            else if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PRDTIPONOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV32GridStateDynamicFilter.gxTpr_Operator;
               AV19PrdTipoNome1 = AV32GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV19PrdTipoNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                  }
                  AV21PrdTipoNome = AV19PrdTipoNome1;
                  H4D0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPrdTipoNomeDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PrdTipoNome, "@!")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV22DynamicFiltersEnabled2 = true;
               AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(2));
               AV23DynamicFiltersSelector2 = AV32GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PRDCODIGO") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV25PrdCodigo2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV25PrdCodigo2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18PrdCodigo = AV25PrdCodigo2;
                     H4D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrdCodigoDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrdCodigo, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               else if ( StringUtil.StrCmp(AV23DynamicFiltersSelector2, "PRDTIPONOME") == 0 )
               {
                  AV24DynamicFiltersOperator2 = AV32GridStateDynamicFilter.gxTpr_Operator;
                  AV26PrdTipoNome2 = AV32GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PrdTipoNome2)) )
                  {
                     if ( AV24DynamicFiltersOperator2 == 0 )
                     {
                        AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV24DynamicFiltersOperator2 == 1 )
                     {
                        AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                     }
                     AV21PrdTipoNome = AV26PrdTipoNome2;
                     H4D0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPrdTipoNomeDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PrdTipoNome, "@!")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV35GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV27DynamicFiltersEnabled3 = true;
                  AV32GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV35GridState.gxTpr_Dynamicfilters.Item(3));
                  AV28DynamicFiltersSelector3 = AV32GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PRDCODIGO") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV30PrdCodigo3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV30PrdCodigo3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterPrdCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18PrdCodigo = AV30PrdCodigo3;
                        H4D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrdCodigoDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrdCodigo, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
                  else if ( StringUtil.StrCmp(AV28DynamicFiltersSelector3, "PRDTIPONOME") == 0 )
                  {
                     AV29DynamicFiltersOperator3 = AV32GridStateDynamicFilter.gxTpr_Operator;
                     AV31PrdTipoNome3 = AV32GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV31PrdTipoNome3)) )
                     {
                        if ( AV29DynamicFiltersOperator3 == 0 )
                        {
                           AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV29DynamicFiltersOperator3 == 1 )
                        {
                           AV20FilterPrdTipoNomeDescription = StringUtil.Format( "%1 (%2)", "Tipo do Produto", "Contém", "", "", "", "", "", "", "");
                        }
                        AV21PrdTipoNome = AV31PrdTipoNome3;
                        H4D0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV20FilterPrdTipoNomeDescription, "")), 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV21PrdTipoNome, "@!")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV38TFPrdCodigo_Sel)) )
         {
            AV43TempBoolean = (bool)(((StringUtil.StrCmp(AV38TFPrdCodigo_Sel, "<#Empty#>")==0)));
            AV38TFPrdCodigo_Sel = (AV43TempBoolean ? "(Vazio)" : AV38TFPrdCodigo_Sel);
            H4D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Código", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV38TFPrdCodigo_Sel, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV38TFPrdCodigo_Sel = (AV43TempBoolean ? "<#Empty#>" : AV38TFPrdCodigo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV37TFPrdCodigo)) )
            {
               H4D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Código", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV37TFPrdCodigo, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV40TFPrdNome_Sel)) )
         {
            AV43TempBoolean = (bool)(((StringUtil.StrCmp(AV40TFPrdNome_Sel, "<#Empty#>")==0)));
            AV40TFPrdNome_Sel = (AV43TempBoolean ? "(Vazio)" : AV40TFPrdNome_Sel);
            H4D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV40TFPrdNome_Sel, "@!")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV40TFPrdNome_Sel = (AV43TempBoolean ? "<#Empty#>" : AV40TFPrdNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV39TFPrdNome)) )
            {
               H4D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV39TFPrdNome, "@!")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV42TFPrdTipoSigla_Sel)) )
         {
            AV43TempBoolean = (bool)(((StringUtil.StrCmp(AV42TFPrdTipoSigla_Sel, "<#Empty#>")==0)));
            AV42TFPrdTipoSigla_Sel = (AV43TempBoolean ? "(Vazio)" : AV42TFPrdTipoSigla_Sel);
            H4D0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Tipo do Produto", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV42TFPrdTipoSigla_Sel, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV42TFPrdTipoSigla_Sel = (AV43TempBoolean ? "<#Empty#>" : AV42TFPrdTipoSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV41TFPrdTipoSigla)) )
            {
               H4D0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Tipo do Produto", 25, Gx_line+0, 185, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV41TFPrdTipoSigla, "")), 185, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4D0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4D0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Código", 30, Gx_line+10, 279, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 283, Gx_line+10, 533, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Tipo do Produto", 537, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV60Core_produtowwds_1_prddel_filtro = AV56PrdDel_Filtro;
         AV61Core_produtowwds_2_filterfulltext = AV13FilterFullText;
         AV62Core_produtowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV63Core_produtowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV64Core_produtowwds_5_prdcodigo1 = AV16PrdCodigo1;
         AV65Core_produtowwds_6_prdtiponome1 = AV19PrdTipoNome1;
         AV66Core_produtowwds_7_dynamicfiltersenabled2 = AV22DynamicFiltersEnabled2;
         AV67Core_produtowwds_8_dynamicfiltersselector2 = AV23DynamicFiltersSelector2;
         AV68Core_produtowwds_9_dynamicfiltersoperator2 = AV24DynamicFiltersOperator2;
         AV69Core_produtowwds_10_prdcodigo2 = AV25PrdCodigo2;
         AV70Core_produtowwds_11_prdtiponome2 = AV26PrdTipoNome2;
         AV71Core_produtowwds_12_dynamicfiltersenabled3 = AV27DynamicFiltersEnabled3;
         AV72Core_produtowwds_13_dynamicfiltersselector3 = AV28DynamicFiltersSelector3;
         AV73Core_produtowwds_14_dynamicfiltersoperator3 = AV29DynamicFiltersOperator3;
         AV74Core_produtowwds_15_prdcodigo3 = AV30PrdCodigo3;
         AV75Core_produtowwds_16_prdtiponome3 = AV31PrdTipoNome3;
         AV76Core_produtowwds_17_tfprdcodigo = AV37TFPrdCodigo;
         AV77Core_produtowwds_18_tfprdcodigo_sel = AV38TFPrdCodigo_Sel;
         AV78Core_produtowwds_19_tfprdnome = AV39TFPrdNome;
         AV79Core_produtowwds_20_tfprdnome_sel = AV40TFPrdNome_Sel;
         AV80Core_produtowwds_21_tfprdtiposigla = AV41TFPrdTipoSigla;
         AV81Core_produtowwds_22_tfprdtiposigla_sel = AV42TFPrdTipoSigla_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV61Core_produtowwds_2_filterfulltext ,
                                              AV62Core_produtowwds_3_dynamicfiltersselector1 ,
                                              AV63Core_produtowwds_4_dynamicfiltersoperator1 ,
                                              AV64Core_produtowwds_5_prdcodigo1 ,
                                              AV65Core_produtowwds_6_prdtiponome1 ,
                                              AV66Core_produtowwds_7_dynamicfiltersenabled2 ,
                                              AV67Core_produtowwds_8_dynamicfiltersselector2 ,
                                              AV68Core_produtowwds_9_dynamicfiltersoperator2 ,
                                              AV69Core_produtowwds_10_prdcodigo2 ,
                                              AV70Core_produtowwds_11_prdtiponome2 ,
                                              AV71Core_produtowwds_12_dynamicfiltersenabled3 ,
                                              AV72Core_produtowwds_13_dynamicfiltersselector3 ,
                                              AV73Core_produtowwds_14_dynamicfiltersoperator3 ,
                                              AV74Core_produtowwds_15_prdcodigo3 ,
                                              AV75Core_produtowwds_16_prdtiponome3 ,
                                              AV77Core_produtowwds_18_tfprdcodigo_sel ,
                                              AV76Core_produtowwds_17_tfprdcodigo ,
                                              AV79Core_produtowwds_20_tfprdnome_sel ,
                                              AV78Core_produtowwds_19_tfprdnome ,
                                              AV81Core_produtowwds_22_tfprdtiposigla_sel ,
                                              AV80Core_produtowwds_21_tfprdtiposigla ,
                                              A221PrdCodigo ,
                                              A222PrdNome ,
                                              A233PrdTipoSigla ,
                                              A234PrdTipoNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A620PrdDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV61Core_produtowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext), "%", "");
         lV64Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1), "%", "");
         lV64Core_produtowwds_5_prdcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1), "%", "");
         lV65Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1), "%", "");
         lV65Core_produtowwds_6_prdtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1), "%", "");
         lV69Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2), "%", "");
         lV69Core_produtowwds_10_prdcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2), "%", "");
         lV70Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2), "%", "");
         lV70Core_produtowwds_11_prdtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2), "%", "");
         lV74Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3), "%", "");
         lV74Core_produtowwds_15_prdcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3), "%", "");
         lV75Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3), "%", "");
         lV75Core_produtowwds_16_prdtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3), "%", "");
         lV76Core_produtowwds_17_tfprdcodigo = StringUtil.Concat( StringUtil.RTrim( AV76Core_produtowwds_17_tfprdcodigo), "%", "");
         lV78Core_produtowwds_19_tfprdnome = StringUtil.Concat( StringUtil.RTrim( AV78Core_produtowwds_19_tfprdnome), "%", "");
         lV80Core_produtowwds_21_tfprdtiposigla = StringUtil.Concat( StringUtil.RTrim( AV80Core_produtowwds_21_tfprdtiposigla), "%", "");
         /* Using cursor P004D2 */
         pr_default.execute(0, new Object[] {lV61Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_2_filterfulltext, lV61Core_produtowwds_2_filterfulltext, lV64Core_produtowwds_5_prdcodigo1, lV64Core_produtowwds_5_prdcodigo1, lV65Core_produtowwds_6_prdtiponome1, lV65Core_produtowwds_6_prdtiponome1, lV69Core_produtowwds_10_prdcodigo2, lV69Core_produtowwds_10_prdcodigo2, lV70Core_produtowwds_11_prdtiponome2, lV70Core_produtowwds_11_prdtiponome2, lV74Core_produtowwds_15_prdcodigo3, lV74Core_produtowwds_15_prdcodigo3, lV75Core_produtowwds_16_prdtiponome3, lV75Core_produtowwds_16_prdtiponome3, lV76Core_produtowwds_17_tfprdcodigo, AV77Core_produtowwds_18_tfprdcodigo_sel, lV78Core_produtowwds_19_tfprdnome, AV79Core_produtowwds_20_tfprdnome_sel, lV80Core_produtowwds_21_tfprdtiposigla, AV81Core_produtowwds_22_tfprdtiposigla_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A232PrdTipoID = P004D2_A232PrdTipoID[0];
            A234PrdTipoNome = P004D2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004D2_A233PrdTipoSigla[0];
            A222PrdNome = P004D2_A222PrdNome[0];
            A221PrdCodigo = P004D2_A221PrdCodigo[0];
            A620PrdDel = P004D2_A620PrdDel[0];
            A220PrdID = P004D2_A220PrdID[0];
            A234PrdTipoNome = P004D2_A234PrdTipoNome[0];
            A233PrdTipoSigla = P004D2_A233PrdTipoSigla[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4D0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A221PrdCodigo, "")), 30, Gx_line+10, 279, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A222PrdNome, "@!")), 283, Gx_line+10, 533, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A233PrdTipoSigla, "")), 537, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV33Session.Get("core.ProdutoWWGridState"), "") == 0 )
         {
            AV35GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ProdutoWWGridState"), null, "", "");
         }
         else
         {
            AV35GridState.FromXml(AV33Session.Get("core.ProdutoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV35GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV35GridState.gxTpr_Ordereddsc;
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV35GridState.gxTpr_Filtervalues.Count )
         {
            AV36GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV35GridState.gxTpr_Filtervalues.Item(AV82GXV1));
            if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "PRDDEL_FILTRO") == 0 )
            {
               AV56PrdDel_Filtro = BooleanUtil.Val( AV36GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO") == 0 )
            {
               AV37TFPrdCodigo = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDCODIGO_SEL") == 0 )
            {
               AV38TFPrdCodigo_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDNOME") == 0 )
            {
               AV39TFPrdNome = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDNOME_SEL") == 0 )
            {
               AV40TFPrdNome_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA") == 0 )
            {
               AV41TFPrdTipoSigla = AV36GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV36GridStateFilterValue.gxTpr_Name, "TFPRDTIPOSIGLA_SEL") == 0 )
            {
               AV42TFPrdTipoSigla_Sel = AV36GridStateFilterValue.gxTpr_Value;
            }
            AV82GXV1 = (int)(AV82GXV1+1);
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

      protected void H4D0( bool bFoot ,
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
                  AV52PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV49DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV49DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV47AppName = "DVelop Software Solutions";
               AV53Phone = "+1 550 8923";
               AV51Mail = "info@mail.com";
               AV55Website = "http://www.web.com";
               AV44AddressLine1 = "French Boulevard 2859";
               AV45AddressLine2 = "Downtown";
               AV46AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV47AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV55Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV54Title = "";
         AV13FilterFullText = "";
         AV35GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV32GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16PrdCodigo1 = "";
         AV17FilterPrdCodigoDescription = "";
         AV18PrdCodigo = "";
         AV19PrdTipoNome1 = "";
         AV20FilterPrdTipoNomeDescription = "";
         AV21PrdTipoNome = "";
         AV23DynamicFiltersSelector2 = "";
         AV25PrdCodigo2 = "";
         AV26PrdTipoNome2 = "";
         AV28DynamicFiltersSelector3 = "";
         AV30PrdCodigo3 = "";
         AV31PrdTipoNome3 = "";
         AV38TFPrdCodigo_Sel = "";
         AV37TFPrdCodigo = "";
         AV40TFPrdNome_Sel = "";
         AV39TFPrdNome = "";
         AV42TFPrdTipoSigla_Sel = "";
         AV41TFPrdTipoSigla = "";
         AV61Core_produtowwds_2_filterfulltext = "";
         AV62Core_produtowwds_3_dynamicfiltersselector1 = "";
         AV64Core_produtowwds_5_prdcodigo1 = "";
         AV65Core_produtowwds_6_prdtiponome1 = "";
         AV67Core_produtowwds_8_dynamicfiltersselector2 = "";
         AV69Core_produtowwds_10_prdcodigo2 = "";
         AV70Core_produtowwds_11_prdtiponome2 = "";
         AV72Core_produtowwds_13_dynamicfiltersselector3 = "";
         AV74Core_produtowwds_15_prdcodigo3 = "";
         AV75Core_produtowwds_16_prdtiponome3 = "";
         AV76Core_produtowwds_17_tfprdcodigo = "";
         AV77Core_produtowwds_18_tfprdcodigo_sel = "";
         AV78Core_produtowwds_19_tfprdnome = "";
         AV79Core_produtowwds_20_tfprdnome_sel = "";
         AV80Core_produtowwds_21_tfprdtiposigla = "";
         AV81Core_produtowwds_22_tfprdtiposigla_sel = "";
         scmdbuf = "";
         lV61Core_produtowwds_2_filterfulltext = "";
         lV64Core_produtowwds_5_prdcodigo1 = "";
         lV65Core_produtowwds_6_prdtiponome1 = "";
         lV69Core_produtowwds_10_prdcodigo2 = "";
         lV70Core_produtowwds_11_prdtiponome2 = "";
         lV74Core_produtowwds_15_prdcodigo3 = "";
         lV75Core_produtowwds_16_prdtiponome3 = "";
         lV76Core_produtowwds_17_tfprdcodigo = "";
         lV78Core_produtowwds_19_tfprdnome = "";
         lV80Core_produtowwds_21_tfprdtiposigla = "";
         A221PrdCodigo = "";
         A222PrdNome = "";
         A233PrdTipoSigla = "";
         A234PrdTipoNome = "";
         P004D2_A232PrdTipoID = new int[1] ;
         P004D2_A234PrdTipoNome = new string[] {""} ;
         P004D2_A233PrdTipoSigla = new string[] {""} ;
         P004D2_A222PrdNome = new string[] {""} ;
         P004D2_A221PrdCodigo = new string[] {""} ;
         P004D2_A620PrdDel = new bool[] {false} ;
         P004D2_A220PrdID = new Guid[] {Guid.Empty} ;
         A220PrdID = Guid.Empty;
         AV33Session = context.GetSession();
         AV36GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV52PageInfo = "";
         AV49DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV47AppName = "";
         AV53Phone = "";
         AV51Mail = "";
         AV55Website = "";
         AV44AddressLine1 = "";
         AV45AddressLine2 = "";
         AV46AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004D2_A232PrdTipoID, P004D2_A234PrdTipoNome, P004D2_A233PrdTipoSigla, P004D2_A222PrdNome, P004D2_A221PrdCodigo, P004D2_A620PrdDel, P004D2_A220PrdID
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
      private short AV63Core_produtowwds_4_dynamicfiltersoperator1 ;
      private short AV68Core_produtowwds_9_dynamicfiltersoperator2 ;
      private short AV73Core_produtowwds_14_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A232PrdTipoID ;
      private int AV82GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV56PrdDel_Filtro ;
      private bool AV22DynamicFiltersEnabled2 ;
      private bool AV27DynamicFiltersEnabled3 ;
      private bool AV43TempBoolean ;
      private bool AV60Core_produtowwds_1_prddel_filtro ;
      private bool AV66Core_produtowwds_7_dynamicfiltersenabled2 ;
      private bool AV71Core_produtowwds_12_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A620PrdDel ;
      private string AV54Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16PrdCodigo1 ;
      private string AV17FilterPrdCodigoDescription ;
      private string AV18PrdCodigo ;
      private string AV19PrdTipoNome1 ;
      private string AV20FilterPrdTipoNomeDescription ;
      private string AV21PrdTipoNome ;
      private string AV23DynamicFiltersSelector2 ;
      private string AV25PrdCodigo2 ;
      private string AV26PrdTipoNome2 ;
      private string AV28DynamicFiltersSelector3 ;
      private string AV30PrdCodigo3 ;
      private string AV31PrdTipoNome3 ;
      private string AV38TFPrdCodigo_Sel ;
      private string AV37TFPrdCodigo ;
      private string AV40TFPrdNome_Sel ;
      private string AV39TFPrdNome ;
      private string AV42TFPrdTipoSigla_Sel ;
      private string AV41TFPrdTipoSigla ;
      private string AV61Core_produtowwds_2_filterfulltext ;
      private string AV62Core_produtowwds_3_dynamicfiltersselector1 ;
      private string AV64Core_produtowwds_5_prdcodigo1 ;
      private string AV65Core_produtowwds_6_prdtiponome1 ;
      private string AV67Core_produtowwds_8_dynamicfiltersselector2 ;
      private string AV69Core_produtowwds_10_prdcodigo2 ;
      private string AV70Core_produtowwds_11_prdtiponome2 ;
      private string AV72Core_produtowwds_13_dynamicfiltersselector3 ;
      private string AV74Core_produtowwds_15_prdcodigo3 ;
      private string AV75Core_produtowwds_16_prdtiponome3 ;
      private string AV76Core_produtowwds_17_tfprdcodigo ;
      private string AV77Core_produtowwds_18_tfprdcodigo_sel ;
      private string AV78Core_produtowwds_19_tfprdnome ;
      private string AV79Core_produtowwds_20_tfprdnome_sel ;
      private string AV80Core_produtowwds_21_tfprdtiposigla ;
      private string AV81Core_produtowwds_22_tfprdtiposigla_sel ;
      private string lV61Core_produtowwds_2_filterfulltext ;
      private string lV64Core_produtowwds_5_prdcodigo1 ;
      private string lV65Core_produtowwds_6_prdtiponome1 ;
      private string lV69Core_produtowwds_10_prdcodigo2 ;
      private string lV70Core_produtowwds_11_prdtiponome2 ;
      private string lV74Core_produtowwds_15_prdcodigo3 ;
      private string lV75Core_produtowwds_16_prdtiponome3 ;
      private string lV76Core_produtowwds_17_tfprdcodigo ;
      private string lV78Core_produtowwds_19_tfprdnome ;
      private string lV80Core_produtowwds_21_tfprdtiposigla ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A234PrdTipoNome ;
      private string AV52PageInfo ;
      private string AV49DateInfo ;
      private string AV47AppName ;
      private string AV53Phone ;
      private string AV51Mail ;
      private string AV55Website ;
      private string AV44AddressLine1 ;
      private string AV45AddressLine2 ;
      private string AV46AddressLine3 ;
      private Guid A220PrdID ;
      private IGxSession AV33Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] P004D2_A232PrdTipoID ;
      private string[] P004D2_A234PrdTipoNome ;
      private string[] P004D2_A233PrdTipoSigla ;
      private string[] P004D2_A222PrdNome ;
      private string[] P004D2_A221PrdCodigo ;
      private bool[] P004D2_A620PrdDel ;
      private Guid[] P004D2_A220PrdID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV35GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV36GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV32GridStateDynamicFilter ;
   }

   public class produtowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004D2( IGxContext context ,
                                             string AV61Core_produtowwds_2_filterfulltext ,
                                             string AV62Core_produtowwds_3_dynamicfiltersselector1 ,
                                             short AV63Core_produtowwds_4_dynamicfiltersoperator1 ,
                                             string AV64Core_produtowwds_5_prdcodigo1 ,
                                             string AV65Core_produtowwds_6_prdtiponome1 ,
                                             bool AV66Core_produtowwds_7_dynamicfiltersenabled2 ,
                                             string AV67Core_produtowwds_8_dynamicfiltersselector2 ,
                                             short AV68Core_produtowwds_9_dynamicfiltersoperator2 ,
                                             string AV69Core_produtowwds_10_prdcodigo2 ,
                                             string AV70Core_produtowwds_11_prdtiponome2 ,
                                             bool AV71Core_produtowwds_12_dynamicfiltersenabled3 ,
                                             string AV72Core_produtowwds_13_dynamicfiltersselector3 ,
                                             short AV73Core_produtowwds_14_dynamicfiltersoperator3 ,
                                             string AV74Core_produtowwds_15_prdcodigo3 ,
                                             string AV75Core_produtowwds_16_prdtiponome3 ,
                                             string AV77Core_produtowwds_18_tfprdcodigo_sel ,
                                             string AV76Core_produtowwds_17_tfprdcodigo ,
                                             string AV79Core_produtowwds_20_tfprdnome_sel ,
                                             string AV78Core_produtowwds_19_tfprdnome ,
                                             string AV81Core_produtowwds_22_tfprdtiposigla_sel ,
                                             string AV80Core_produtowwds_21_tfprdtiposigla ,
                                             string A221PrdCodigo ,
                                             string A222PrdNome ,
                                             string A233PrdTipoSigla ,
                                             string A234PrdTipoNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A620PrdDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[21];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT T1.PrdTipoID AS PrdTipoID, T2.PrtNome AS PrdTipoNome, T2.PrtSigla AS PrdTipoSigla, T1.PrdNome, T1.PrdCodigo, T1.PrdDel, T1.PrdID FROM (tb_produto T1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = T1.PrdTipoID)";
         AddWhere(sWhereString, "(Not T1.PrdDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.PrdCodigo like '%' || :lV61Core_produtowwds_2_filterfulltext) or ( T1.PrdNome like '%' || :lV61Core_produtowwds_2_filterfulltext) or ( T2.PrtSigla like '%' || :lV61Core_produtowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV64Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDCODIGO") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_produtowwds_5_prdcodigo1)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV64Core_produtowwds_5_prdcodigo1)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV65Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( ( StringUtil.StrCmp(AV62Core_produtowwds_3_dynamicfiltersselector1, "PRDTIPONOME") == 0 ) && ( AV63Core_produtowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtowwds_6_prdtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV65Core_produtowwds_6_prdtiponome1)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV69Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDCODIGO") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtowwds_10_prdcodigo2)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV69Core_produtowwds_10_prdcodigo2)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV70Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( AV66Core_produtowwds_7_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV67Core_produtowwds_8_dynamicfiltersselector2, "PRDTIPONOME") == 0 ) && ( AV68Core_produtowwds_9_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_produtowwds_11_prdtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV70Core_produtowwds_11_prdtiponome2)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV74Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDCODIGO") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_produtowwds_15_prdcodigo3)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like '%' || :lV74Core_produtowwds_15_prdcodigo3)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like :lV75Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         if ( AV71Core_produtowwds_12_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV72Core_produtowwds_13_dynamicfiltersselector3, "PRDTIPONOME") == 0 ) && ( AV73Core_produtowwds_14_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV75Core_produtowwds_16_prdtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtNome like '%' || :lV75Core_produtowwds_16_prdtiponome3)");
         }
         else
         {
            GXv_int2[14] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_18_tfprdcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_produtowwds_17_tfprdcodigo)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo like :lV76Core_produtowwds_17_tfprdcodigo)");
         }
         else
         {
            GXv_int2[15] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_produtowwds_18_tfprdcodigo_sel)) && ! ( StringUtil.StrCmp(AV77Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdCodigo = ( :AV77Core_produtowwds_18_tfprdcodigo_sel))");
         }
         else
         {
            GXv_int2[16] = 1;
         }
         if ( StringUtil.StrCmp(AV77Core_produtowwds_18_tfprdcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_produtowwds_20_tfprdnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_produtowwds_19_tfprdnome)) ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome like :lV78Core_produtowwds_19_tfprdnome)");
         }
         else
         {
            GXv_int2[17] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_produtowwds_20_tfprdnome_sel)) && ! ( StringUtil.StrCmp(AV79Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.PrdNome = ( :AV79Core_produtowwds_20_tfprdnome_sel))");
         }
         else
         {
            GXv_int2[18] = 1;
         }
         if ( StringUtil.StrCmp(AV79Core_produtowwds_20_tfprdnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.PrdNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_produtowwds_22_tfprdtiposigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_produtowwds_21_tfprdtiposigla)) ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla like :lV80Core_produtowwds_21_tfprdtiposigla)");
         }
         else
         {
            GXv_int2[19] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_produtowwds_22_tfprdtiposigla_sel)) && ! ( StringUtil.StrCmp(AV81Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.PrtSigla = ( :AV81Core_produtowwds_22_tfprdtiposigla_sel))");
         }
         else
         {
            GXv_int2[20] = 1;
         }
         if ( StringUtil.StrCmp(AV81Core_produtowwds_22_tfprdtiposigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.PrtSigla))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PrdCodigo";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PrdCodigo DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T1.PrdNome";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T1.PrdNome DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY T2.PrtSigla";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY T2.PrtSigla DESC";
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
                     return conditional_P004D2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (bool)dynConstraints[5] , (string)dynConstraints[6] , (short)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (bool)dynConstraints[10] , (string)dynConstraints[11] , (short)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (short)dynConstraints[25] , (bool)dynConstraints[26] , (bool)dynConstraints[27] );
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
          Object[] prmP004D2;
          prmP004D2 = new Object[] {
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV61Core_produtowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV64Core_produtowwds_5_prdcodigo1",GXType.VarChar,30,0) ,
          new ParDef("lV65Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_produtowwds_6_prdtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV69Core_produtowwds_10_prdcodigo2",GXType.VarChar,30,0) ,
          new ParDef("lV70Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV70Core_produtowwds_11_prdtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV74Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV74Core_produtowwds_15_prdcodigo3",GXType.VarChar,30,0) ,
          new ParDef("lV75Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV75Core_produtowwds_16_prdtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV76Core_produtowwds_17_tfprdcodigo",GXType.VarChar,30,0) ,
          new ParDef("AV77Core_produtowwds_18_tfprdcodigo_sel",GXType.VarChar,30,0) ,
          new ParDef("lV78Core_produtowwds_19_tfprdnome",GXType.VarChar,80,0) ,
          new ParDef("AV79Core_produtowwds_20_tfprdnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV80Core_produtowwds_21_tfprdtiposigla",GXType.VarChar,20,0) ,
          new ParDef("AV81Core_produtowwds_22_tfprdtiposigla_sel",GXType.VarChar,20,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004D2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004D2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                ((bool[]) buf[5])[0] = rslt.getBool(6);
                ((Guid[]) buf[6])[0] = rslt.getGuid(7);
                return;
       }
    }

 }

}
