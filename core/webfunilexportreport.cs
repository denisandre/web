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
   public class webfunilexportreport : GXWebProcedure
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

      public webfunilexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public webfunilexportreport( IGxContext context )
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
         webfunilexportreport objwebfunilexportreport;
         objwebfunilexportreport = new webfunilexportreport();
         objwebfunilexportreport.context.SetSubmitInitialConfig(context);
         objwebfunilexportreport.initialize();
         Submit( executePrivateCatch,objwebfunilexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((webfunilexportreport)stateInfo).executePrivate();
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
         setOutputFileName("webfunilExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "webfunil_Execute", out  GXt_boolean1) ;
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
               AV53Title = "Lista de Iteração";
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
            H610( true, 0) ;
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
            H610( false, 20) ;
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
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "ITENOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16IteNome1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16IteNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18IteNome = AV16IteNome1;
                  H610( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterIteNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18IteNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "ITENOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22IteNome2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22IteNome2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18IteNome = AV22IteNome2;
                     H610( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterIteNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18IteNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "ITENOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26IteNome3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26IteNome3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterIteNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18IteNome = AV26IteNome3;
                        H610( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterIteNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18IteNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFIteNome_Sel)) )
         {
            AV42TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFIteNome_Sel, "<#Empty#>")==0)));
            AV33TFIteNome_Sel = (AV42TempBoolean ? "(Vazio)" : AV33TFIteNome_Sel);
            H610( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Iteração", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFIteNome_Sel, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFIteNome_Sel = (AV42TempBoolean ? "<#Empty#>" : AV33TFIteNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFIteNome)) )
            {
               H610( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Iteração", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFIteNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H610( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H610( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Iteração", 30, Gx_line+10, 404, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Quantidade de Oportunidades", 408, Gx_line+10, 595, Gx_line+27, 2, 0, 0, 0) ;
         getPrinter().GxDrawText("Total em Oportunidades", 599, Gx_line+10, 787, Gx_line+27, 2, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV58Core_webfunilds_1_filterfulltext = AV13FilterFullText;
         AV59Core_webfunilds_2_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV60Core_webfunilds_3_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV61Core_webfunilds_4_itenome1 = AV16IteNome1;
         AV62Core_webfunilds_5_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV63Core_webfunilds_6_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV64Core_webfunilds_7_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV65Core_webfunilds_8_itenome2 = AV22IteNome2;
         AV66Core_webfunilds_9_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV67Core_webfunilds_10_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV68Core_webfunilds_11_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV69Core_webfunilds_12_itenome3 = AV26IteNome3;
         AV70Core_webfunilds_13_tfitenome = AV32TFIteNome;
         AV71Core_webfunilds_14_tfitenome_sel = AV33TFIteNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV59Core_webfunilds_2_dynamicfiltersselector1 ,
                                              AV60Core_webfunilds_3_dynamicfiltersoperator1 ,
                                              AV61Core_webfunilds_4_itenome1 ,
                                              AV62Core_webfunilds_5_dynamicfiltersenabled2 ,
                                              AV63Core_webfunilds_6_dynamicfiltersselector2 ,
                                              AV64Core_webfunilds_7_dynamicfiltersoperator2 ,
                                              AV65Core_webfunilds_8_itenome2 ,
                                              AV66Core_webfunilds_9_dynamicfiltersenabled3 ,
                                              AV67Core_webfunilds_10_dynamicfiltersselector3 ,
                                              AV68Core_webfunilds_11_dynamicfiltersoperator3 ,
                                              AV69Core_webfunilds_12_itenome3 ,
                                              AV71Core_webfunilds_14_tfitenome_sel ,
                                              AV70Core_webfunilds_13_tfitenome ,
                                              A383IteNome ,
                                              AV12OrderedDsc ,
                                              AV58Core_webfunilds_1_filterfulltext ,
                                              A431IteTotalOportunidades ,
                                              A432IteQtdeOportunidades ,
                                              A381IteID ,
                                              A420NegUltIteID } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.DECIMAL, TypeConstants.INT
                                              }
         });
         lV61Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_webfunilds_4_itenome1), "%", "");
         lV61Core_webfunilds_4_itenome1 = StringUtil.Concat( StringUtil.RTrim( AV61Core_webfunilds_4_itenome1), "%", "");
         lV65Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV65Core_webfunilds_8_itenome2), "%", "");
         lV65Core_webfunilds_8_itenome2 = StringUtil.Concat( StringUtil.RTrim( AV65Core_webfunilds_8_itenome2), "%", "");
         lV69Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV69Core_webfunilds_12_itenome3), "%", "");
         lV69Core_webfunilds_12_itenome3 = StringUtil.Concat( StringUtil.RTrim( AV69Core_webfunilds_12_itenome3), "%", "");
         lV70Core_webfunilds_13_tfitenome = StringUtil.Concat( StringUtil.RTrim( AV70Core_webfunilds_13_tfitenome), "%", "");
         /* Using cursor P00612 */
         pr_default.execute(0, new Object[] {lV61Core_webfunilds_4_itenome1, lV61Core_webfunilds_4_itenome1, lV65Core_webfunilds_8_itenome2, lV65Core_webfunilds_8_itenome2, lV69Core_webfunilds_12_itenome3, lV69Core_webfunilds_12_itenome3, lV70Core_webfunilds_13_tfitenome, AV71Core_webfunilds_14_tfitenome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A383IteNome = P00612_A383IteNome[0];
            A382IteOrdem = P00612_A382IteOrdem[0];
            A381IteID = P00612_A381IteID[0];
            A431IteTotalOportunidades = GetIteTotalOportunidades0( A381IteID);
            A432IteQtdeOportunidades = GetIteQtdeOportunidades0( A381IteID);
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV58Core_webfunilds_1_filterfulltext)) || ( ( StringUtil.Like( StringUtil.Lower( A383IteNome) , StringUtil.PadR( "%" + StringUtil.Lower( AV58Core_webfunilds_1_filterfulltext) , 255 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( A431IteTotalOportunidades, 16, 2) , StringUtil.PadR( "%" + AV58Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) || ( StringUtil.Like( StringUtil.Str( (decimal)(A432IteQtdeOportunidades), 8, 0) , StringUtil.PadR( "%" + AV58Core_webfunilds_1_filterfulltext , 254 , "%"),  ' ' ) ) ) )
            {
               /* Execute user subroutine: 'BEFOREPRINTLINE' */
               S144 ();
               if ( returnInSub )
               {
                  pr_default.close(0);
                  returnInSub = true;
                  if (true) return;
               }
               H610( false, 36) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A383IteNome, "@!")), 30, Gx_line+10, 404, Gx_line+25, 0+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( (decimal)(A432IteQtdeOportunidades), "ZZZZZZZ9")), 408, Gx_line+10, 595, Gx_line+25, 2+16, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.LTrim( context.localUtil.Format( A431IteTotalOportunidades, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99")), 599, Gx_line+10, 787, Gx_line+25, 2+16, 0, 0, 0) ;
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
            }
            pr_default.readNext(0);
         }
         pr_default.close(0);
      }

      protected void S151( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV28Session.Get("core.webfunilGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.webfunilGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.webfunilGridState"), null, "", "");
         }
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV72GXV1 = 1;
         while ( AV72GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV72GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFITENOME") == 0 )
            {
               AV32TFIteNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFITENOME_SEL") == 0 )
            {
               AV33TFIteNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            AV72GXV1 = (int)(AV72GXV1+1);
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

      protected void H610( bool bFoot ,
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
                  AV51PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV48DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV51PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV48DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV46AppName = "DVelop Software Solutions";
               AV52Phone = "+1 550 8923";
               AV50Mail = "info@mail.com";
               AV54Website = "http://www.web.com";
               AV43AddressLine1 = "French Boulevard 2859";
               AV44AddressLine2 = "Downtown";
               AV45AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV46AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV52Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV50Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV54Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV43AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV44AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV45AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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

      protected int GetIteQtdeOportunidades0( Guid E381IteID )
      {
         Gx_cnt = 0;
         /* Using cursor P00613 */
         pr_default.execute(1, new Object[] {E381IteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            Gx_cnt = P00613_Gx_cnt[0];
         }
         pr_default.close(1);
         return Gx_cnt ;
      }

      protected decimal GetIteTotalOportunidades0( Guid E381IteID )
      {
         X385NegValorAtualizado = 0;
         /* Using cursor P00614 */
         pr_default.execute(2, new Object[] {E381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            X385NegValorAtualizado = P00614_A385NegValorAtualizado[0];
         }
         pr_default.close(2);
         return X385NegValorAtualizado ;
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
         AV53Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16IteNome1 = "";
         AV17FilterIteNomeDescription = "";
         AV18IteNome = "";
         AV20DynamicFiltersSelector2 = "";
         AV22IteNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26IteNome3 = "";
         AV33TFIteNome_Sel = "";
         AV32TFIteNome = "";
         AV58Core_webfunilds_1_filterfulltext = "";
         AV59Core_webfunilds_2_dynamicfiltersselector1 = "";
         AV61Core_webfunilds_4_itenome1 = "";
         AV63Core_webfunilds_6_dynamicfiltersselector2 = "";
         AV65Core_webfunilds_8_itenome2 = "";
         AV67Core_webfunilds_10_dynamicfiltersselector3 = "";
         AV69Core_webfunilds_12_itenome3 = "";
         AV70Core_webfunilds_13_tfitenome = "";
         AV71Core_webfunilds_14_tfitenome_sel = "";
         scmdbuf = "";
         lV61Core_webfunilds_4_itenome1 = "";
         lV65Core_webfunilds_8_itenome2 = "";
         lV69Core_webfunilds_12_itenome3 = "";
         lV70Core_webfunilds_13_tfitenome = "";
         A383IteNome = "";
         A381IteID = Guid.Empty;
         A420NegUltIteID = Guid.Empty;
         P00612_A383IteNome = new string[] {""} ;
         P00612_A382IteOrdem = new int[1] ;
         P00612_A381IteID = new Guid[] {Guid.Empty} ;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV51PageInfo = "";
         AV48DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV46AppName = "";
         AV52Phone = "";
         AV50Mail = "";
         AV54Website = "";
         AV43AddressLine1 = "";
         AV44AddressLine2 = "";
         AV45AddressLine3 = "";
         E381IteID = Guid.Empty;
         P00613_Gx_cnt = new int[1] ;
         P00614_A385NegValorAtualizado = new decimal[1] ;
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.webfunilexportreport__default(),
            new Object[][] {
                new Object[] {
               P00612_A383IteNome, P00612_A382IteOrdem, P00612_A381IteID
               }
               , new Object[] {
               P00613_Gx_cnt
               }
               , new Object[] {
               P00614_A385NegValorAtualizado
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
      private short AV60Core_webfunilds_3_dynamicfiltersoperator1 ;
      private short AV64Core_webfunilds_7_dynamicfiltersoperator2 ;
      private short AV68Core_webfunilds_11_dynamicfiltersoperator3 ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A432IteQtdeOportunidades ;
      private int A382IteOrdem ;
      private int AV72GXV1 ;
      private int Gx_cnt ;
      private decimal A431IteTotalOportunidades ;
      private decimal X385NegValorAtualizado ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV42TempBoolean ;
      private bool AV62Core_webfunilds_5_dynamicfiltersenabled2 ;
      private bool AV66Core_webfunilds_9_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private string AV53Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16IteNome1 ;
      private string AV17FilterIteNomeDescription ;
      private string AV18IteNome ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22IteNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26IteNome3 ;
      private string AV33TFIteNome_Sel ;
      private string AV32TFIteNome ;
      private string AV58Core_webfunilds_1_filterfulltext ;
      private string AV59Core_webfunilds_2_dynamicfiltersselector1 ;
      private string AV61Core_webfunilds_4_itenome1 ;
      private string AV63Core_webfunilds_6_dynamicfiltersselector2 ;
      private string AV65Core_webfunilds_8_itenome2 ;
      private string AV67Core_webfunilds_10_dynamicfiltersselector3 ;
      private string AV69Core_webfunilds_12_itenome3 ;
      private string AV70Core_webfunilds_13_tfitenome ;
      private string AV71Core_webfunilds_14_tfitenome_sel ;
      private string lV61Core_webfunilds_4_itenome1 ;
      private string lV65Core_webfunilds_8_itenome2 ;
      private string lV69Core_webfunilds_12_itenome3 ;
      private string lV70Core_webfunilds_13_tfitenome ;
      private string A383IteNome ;
      private string AV51PageInfo ;
      private string AV48DateInfo ;
      private string AV46AppName ;
      private string AV52Phone ;
      private string AV50Mail ;
      private string AV54Website ;
      private string AV43AddressLine1 ;
      private string AV44AddressLine2 ;
      private string AV45AddressLine3 ;
      private Guid A381IteID ;
      private Guid A420NegUltIteID ;
      private Guid E381IteID ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] P00612_A383IteNome ;
      private int[] P00612_A382IteOrdem ;
      private Guid[] P00612_A381IteID ;
      private int[] P00613_Gx_cnt ;
      private decimal[] P00614_A385NegValorAtualizado ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class webfunilexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P00612( IGxContext context ,
                                             string AV59Core_webfunilds_2_dynamicfiltersselector1 ,
                                             short AV60Core_webfunilds_3_dynamicfiltersoperator1 ,
                                             string AV61Core_webfunilds_4_itenome1 ,
                                             bool AV62Core_webfunilds_5_dynamicfiltersenabled2 ,
                                             string AV63Core_webfunilds_6_dynamicfiltersselector2 ,
                                             short AV64Core_webfunilds_7_dynamicfiltersoperator2 ,
                                             string AV65Core_webfunilds_8_itenome2 ,
                                             bool AV66Core_webfunilds_9_dynamicfiltersenabled3 ,
                                             string AV67Core_webfunilds_10_dynamicfiltersselector3 ,
                                             short AV68Core_webfunilds_11_dynamicfiltersoperator3 ,
                                             string AV69Core_webfunilds_12_itenome3 ,
                                             string AV71Core_webfunilds_14_tfitenome_sel ,
                                             string AV70Core_webfunilds_13_tfitenome ,
                                             string A383IteNome ,
                                             bool AV12OrderedDsc ,
                                             string AV58Core_webfunilds_1_filterfulltext ,
                                             decimal A431IteTotalOportunidades ,
                                             int A432IteQtdeOportunidades ,
                                             Guid A381IteID ,
                                             Guid A420NegUltIteID )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[8];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT IteNome, IteOrdem, IteID FROM tb_Iteracao";
         if ( ( StringUtil.StrCmp(AV59Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV60Core_webfunilds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV61Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int2[0] = 1;
         }
         if ( ( StringUtil.StrCmp(AV59Core_webfunilds_2_dynamicfiltersselector1, "ITENOME") == 0 ) && ( AV60Core_webfunilds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_webfunilds_4_itenome1)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV61Core_webfunilds_4_itenome1)");
         }
         else
         {
            GXv_int2[1] = 1;
         }
         if ( AV62Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV64Core_webfunilds_7_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV65Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( AV62Core_webfunilds_5_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV63Core_webfunilds_6_dynamicfiltersselector2, "ITENOME") == 0 ) && ( AV64Core_webfunilds_7_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_webfunilds_8_itenome2)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV65Core_webfunilds_8_itenome2)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV66Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV68Core_webfunilds_11_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV69Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV66Core_webfunilds_9_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV67Core_webfunilds_10_dynamicfiltersselector3, "ITENOME") == 0 ) && ( AV68Core_webfunilds_11_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_webfunilds_12_itenome3)) ) )
         {
            AddWhere(sWhereString, "(IteNome like '%' || :lV69Core_webfunilds_12_itenome3)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_webfunilds_14_tfitenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_webfunilds_13_tfitenome)) ) )
         {
            AddWhere(sWhereString, "(IteNome like :lV70Core_webfunilds_13_tfitenome)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_webfunilds_14_tfitenome_sel)) && ! ( StringUtil.StrCmp(AV71Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(IteNome = ( :AV71Core_webfunilds_14_tfitenome_sel))");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( StringUtil.StrCmp(AV71Core_webfunilds_14_tfitenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from IteNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem";
         }
         else if ( AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY IteOrdem DESC";
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
                     return conditional_P00612(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (bool)dynConstraints[3] , (string)dynConstraints[4] , (short)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (decimal)dynConstraints[16] , (int)dynConstraints[17] , (Guid)dynConstraints[18] , (Guid)dynConstraints[19] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
         ,new ForEachCursor(def[2])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmP00613;
          prmP00613 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00614;
          prmP00614 = new Object[] {
          new ParDef("IteID",GXType.UniqueIdentifier,36,0)
          };
          Object[] prmP00612;
          prmP00612 = new Object[] {
          new ParDef("lV61Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_webfunilds_4_itenome1",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_webfunilds_8_itenome2",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_webfunilds_12_itenome3",GXType.VarChar,80,0) ,
          new ParDef("lV70Core_webfunilds_13_tfitenome",GXType.VarChar,80,0) ,
          new ParDef("AV71Core_webfunilds_14_tfitenome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P00612", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00612,100, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("P00613", "SELECT COUNT(*) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00613,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("P00614", "SELECT SUM(NegValorAtualizado) FROM tb_negociopj WHERE NegUltIteID = :IteID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP00614,1, GxCacheFrequency.OFF ,true,true )
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
                ((int[]) buf[1])[0] = rslt.getInt(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((int[]) buf[0])[0] = rslt.getInt(1);
                return;
             case 2 :
                ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
                return;
       }
    }

 }

}
