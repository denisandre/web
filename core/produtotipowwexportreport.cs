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
   public class produtotipowwexportreport : GXWebProcedure
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

      public produtotipowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtotipowwexportreport( IGxContext context )
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
         produtotipowwexportreport objprodutotipowwexportreport;
         objprodutotipowwexportreport = new produtotipowwexportreport();
         objprodutotipowwexportreport.context.SetSubmitInitialConfig(context);
         objprodutotipowwexportreport.initialize();
         Submit( executePrivateCatch,objprodutotipowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((produtotipowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("ProdutoTipoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "produtotipoww_Execute", out  GXt_boolean1) ;
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
               AV47Title = "Lista de Tipo de Produto";
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
            H4M0( true, 0) ;
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
         if ( ! (false==AV49PrtDel_Filtro) )
         {
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV49PrtDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H4M0( false, 20) ;
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
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "PRTNOME") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16PrtNome1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16PrtNome1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18PrtNome = AV16PrtNome1;
                  H4M0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrtNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrtNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "PRTNOME") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22PrtNome2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22PrtNome2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18PrtNome = AV22PrtNome2;
                     H4M0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrtNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrtNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "PRTNOME") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26PrtNome3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26PrtNome3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterPrtNomeDescription = StringUtil.Format( "%1 (%2)", "Descrição", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18PrtNome = AV26PrtNome3;
                        H4M0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterPrtNomeDescription, "")), 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18PrtNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFPrtSigla_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFPrtSigla_Sel, "<#Empty#>")==0)));
            AV33TFPrtSigla_Sel = (AV36TempBoolean ? "(Vazio)" : AV33TFPrtSigla_Sel);
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFPrtSigla_Sel, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFPrtSigla_Sel = (AV36TempBoolean ? "<#Empty#>" : AV33TFPrtSigla_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFPrtSigla)) )
            {
               H4M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Sigla", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFPrtSigla, "")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFPrtNome_Sel)) )
         {
            AV36TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFPrtNome_Sel, "<#Empty#>")==0)));
            AV35TFPrtNome_Sel = (AV36TempBoolean ? "(Vazio)" : AV35TFPrtNome_Sel);
            H4M0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFPrtNome_Sel, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFPrtNome_Sel = (AV36TempBoolean ? "<#Empty#>" : AV35TFPrtNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFPrtNome)) )
            {
               H4M0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 156, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFPrtNome, "@!")), 156, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4M0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4M0( false, 37) ;
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
         AV53Core_produtotipowwds_1_prtdel_filtro = AV49PrtDel_Filtro;
         AV54Core_produtotipowwds_2_filterfulltext = AV13FilterFullText;
         AV55Core_produtotipowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV56Core_produtotipowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV57Core_produtotipowwds_5_prtnome1 = AV16PrtNome1;
         AV58Core_produtotipowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV59Core_produtotipowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV60Core_produtotipowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV61Core_produtotipowwds_9_prtnome2 = AV22PrtNome2;
         AV62Core_produtotipowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV63Core_produtotipowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV64Core_produtotipowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV65Core_produtotipowwds_13_prtnome3 = AV26PrtNome3;
         AV66Core_produtotipowwds_14_tfprtsigla = AV32TFPrtSigla;
         AV67Core_produtotipowwds_15_tfprtsigla_sel = AV33TFPrtSigla_Sel;
         AV68Core_produtotipowwds_16_tfprtnome = AV34TFPrtNome;
         AV69Core_produtotipowwds_17_tfprtnome_sel = AV35TFPrtNome_Sel;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV54Core_produtotipowwds_2_filterfulltext ,
                                              AV55Core_produtotipowwds_3_dynamicfiltersselector1 ,
                                              AV56Core_produtotipowwds_4_dynamicfiltersoperator1 ,
                                              AV57Core_produtotipowwds_5_prtnome1 ,
                                              AV58Core_produtotipowwds_6_dynamicfiltersenabled2 ,
                                              AV59Core_produtotipowwds_7_dynamicfiltersselector2 ,
                                              AV60Core_produtotipowwds_8_dynamicfiltersoperator2 ,
                                              AV61Core_produtotipowwds_9_prtnome2 ,
                                              AV62Core_produtotipowwds_10_dynamicfiltersenabled3 ,
                                              AV63Core_produtotipowwds_11_dynamicfiltersselector3 ,
                                              AV64Core_produtotipowwds_12_dynamicfiltersoperator3 ,
                                              AV65Core_produtotipowwds_13_prtnome3 ,
                                              AV67Core_produtotipowwds_15_tfprtsigla_sel ,
                                              AV66Core_produtotipowwds_14_tfprtsigla ,
                                              AV69Core_produtotipowwds_17_tfprtnome_sel ,
                                              AV68Core_produtotipowwds_16_tfprtnome ,
                                              A212PrtSigla ,
                                              A213PrtNome ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A614PrtDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV54Core_produtotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_produtotipowwds_2_filterfulltext), "%", "");
         lV54Core_produtotipowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV54Core_produtotipowwds_2_filterfulltext), "%", "");
         lV57Core_produtotipowwds_5_prtnome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_produtotipowwds_5_prtnome1), "%", "");
         lV57Core_produtotipowwds_5_prtnome1 = StringUtil.Concat( StringUtil.RTrim( AV57Core_produtotipowwds_5_prtnome1), "%", "");
         lV61Core_produtotipowwds_9_prtnome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtotipowwds_9_prtnome2), "%", "");
         lV61Core_produtotipowwds_9_prtnome2 = StringUtil.Concat( StringUtil.RTrim( AV61Core_produtotipowwds_9_prtnome2), "%", "");
         lV65Core_produtotipowwds_13_prtnome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtotipowwds_13_prtnome3), "%", "");
         lV65Core_produtotipowwds_13_prtnome3 = StringUtil.Concat( StringUtil.RTrim( AV65Core_produtotipowwds_13_prtnome3), "%", "");
         lV66Core_produtotipowwds_14_tfprtsigla = StringUtil.Concat( StringUtil.RTrim( AV66Core_produtotipowwds_14_tfprtsigla), "%", "");
         lV68Core_produtotipowwds_16_tfprtnome = StringUtil.Concat( StringUtil.RTrim( AV68Core_produtotipowwds_16_tfprtnome), "%", "");
         /* Using cursor P004M2 */
         pr_default.execute(0, new Object[] {lV54Core_produtotipowwds_2_filterfulltext, lV54Core_produtotipowwds_2_filterfulltext, lV57Core_produtotipowwds_5_prtnome1, lV57Core_produtotipowwds_5_prtnome1, lV61Core_produtotipowwds_9_prtnome2, lV61Core_produtotipowwds_9_prtnome2, lV65Core_produtotipowwds_13_prtnome3, lV65Core_produtotipowwds_13_prtnome3, lV66Core_produtotipowwds_14_tfprtsigla, AV67Core_produtotipowwds_15_tfprtsigla_sel, lV68Core_produtotipowwds_16_tfprtnome, AV69Core_produtotipowwds_17_tfprtnome_sel});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A213PrtNome = P004M2_A213PrtNome[0];
            A212PrtSigla = P004M2_A212PrtSigla[0];
            A614PrtDel = P004M2_A614PrtDel[0];
            A211PrtID = P004M2_A211PrtID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4M0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A212PrtSigla, "")), 30, Gx_line+10, 406, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A213PrtNome, "@!")), 410, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.ProdutoTipoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.ProdutoTipoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.ProdutoTipoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV70GXV1 = 1;
         while ( AV70GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV70GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "PRTDEL_FILTRO") == 0 )
            {
               AV49PrtDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRTSIGLA") == 0 )
            {
               AV32TFPrtSigla = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRTSIGLA_SEL") == 0 )
            {
               AV33TFPrtSigla_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRTNOME") == 0 )
            {
               AV34TFPrtNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFPRTNOME_SEL") == 0 )
            {
               AV35TFPrtNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
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

      protected void H4M0( bool bFoot ,
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
         AV16PrtNome1 = "";
         AV17FilterPrtNomeDescription = "";
         AV18PrtNome = "";
         AV20DynamicFiltersSelector2 = "";
         AV22PrtNome2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26PrtNome3 = "";
         AV33TFPrtSigla_Sel = "";
         AV32TFPrtSigla = "";
         AV35TFPrtNome_Sel = "";
         AV34TFPrtNome = "";
         AV54Core_produtotipowwds_2_filterfulltext = "";
         AV55Core_produtotipowwds_3_dynamicfiltersselector1 = "";
         AV57Core_produtotipowwds_5_prtnome1 = "";
         AV59Core_produtotipowwds_7_dynamicfiltersselector2 = "";
         AV61Core_produtotipowwds_9_prtnome2 = "";
         AV63Core_produtotipowwds_11_dynamicfiltersselector3 = "";
         AV65Core_produtotipowwds_13_prtnome3 = "";
         AV66Core_produtotipowwds_14_tfprtsigla = "";
         AV67Core_produtotipowwds_15_tfprtsigla_sel = "";
         AV68Core_produtotipowwds_16_tfprtnome = "";
         AV69Core_produtotipowwds_17_tfprtnome_sel = "";
         scmdbuf = "";
         lV54Core_produtotipowwds_2_filterfulltext = "";
         lV57Core_produtotipowwds_5_prtnome1 = "";
         lV61Core_produtotipowwds_9_prtnome2 = "";
         lV65Core_produtotipowwds_13_prtnome3 = "";
         lV66Core_produtotipowwds_14_tfprtsigla = "";
         lV68Core_produtotipowwds_16_tfprtnome = "";
         A212PrtSigla = "";
         A213PrtNome = "";
         P004M2_A213PrtNome = new string[] {""} ;
         P004M2_A212PrtSigla = new string[] {""} ;
         P004M2_A614PrtDel = new bool[] {false} ;
         P004M2_A211PrtID = new int[1] ;
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
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004M2_A213PrtNome, P004M2_A212PrtSigla, P004M2_A614PrtDel, P004M2_A211PrtID
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
      private short AV56Core_produtotipowwds_4_dynamicfiltersoperator1 ;
      private short AV60Core_produtotipowwds_8_dynamicfiltersoperator2 ;
      private short AV64Core_produtotipowwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int A211PrtID ;
      private int AV70GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV49PrtDel_Filtro ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV36TempBoolean ;
      private bool AV53Core_produtotipowwds_1_prtdel_filtro ;
      private bool AV58Core_produtotipowwds_6_dynamicfiltersenabled2 ;
      private bool AV62Core_produtotipowwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A614PrtDel ;
      private string AV47Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16PrtNome1 ;
      private string AV17FilterPrtNomeDescription ;
      private string AV18PrtNome ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22PrtNome2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26PrtNome3 ;
      private string AV33TFPrtSigla_Sel ;
      private string AV32TFPrtSigla ;
      private string AV35TFPrtNome_Sel ;
      private string AV34TFPrtNome ;
      private string AV54Core_produtotipowwds_2_filterfulltext ;
      private string AV55Core_produtotipowwds_3_dynamicfiltersselector1 ;
      private string AV57Core_produtotipowwds_5_prtnome1 ;
      private string AV59Core_produtotipowwds_7_dynamicfiltersselector2 ;
      private string AV61Core_produtotipowwds_9_prtnome2 ;
      private string AV63Core_produtotipowwds_11_dynamicfiltersselector3 ;
      private string AV65Core_produtotipowwds_13_prtnome3 ;
      private string AV66Core_produtotipowwds_14_tfprtsigla ;
      private string AV67Core_produtotipowwds_15_tfprtsigla_sel ;
      private string AV68Core_produtotipowwds_16_tfprtnome ;
      private string AV69Core_produtotipowwds_17_tfprtnome_sel ;
      private string lV54Core_produtotipowwds_2_filterfulltext ;
      private string lV57Core_produtotipowwds_5_prtnome1 ;
      private string lV61Core_produtotipowwds_9_prtnome2 ;
      private string lV65Core_produtotipowwds_13_prtnome3 ;
      private string lV66Core_produtotipowwds_14_tfprtsigla ;
      private string lV68Core_produtotipowwds_16_tfprtnome ;
      private string A212PrtSigla ;
      private string A213PrtNome ;
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
      private string[] P004M2_A213PrtNome ;
      private string[] P004M2_A212PrtSigla ;
      private bool[] P004M2_A614PrtDel ;
      private int[] P004M2_A211PrtID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class produtotipowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004M2( IGxContext context ,
                                             string AV54Core_produtotipowwds_2_filterfulltext ,
                                             string AV55Core_produtotipowwds_3_dynamicfiltersselector1 ,
                                             short AV56Core_produtotipowwds_4_dynamicfiltersoperator1 ,
                                             string AV57Core_produtotipowwds_5_prtnome1 ,
                                             bool AV58Core_produtotipowwds_6_dynamicfiltersenabled2 ,
                                             string AV59Core_produtotipowwds_7_dynamicfiltersselector2 ,
                                             short AV60Core_produtotipowwds_8_dynamicfiltersoperator2 ,
                                             string AV61Core_produtotipowwds_9_prtnome2 ,
                                             bool AV62Core_produtotipowwds_10_dynamicfiltersenabled3 ,
                                             string AV63Core_produtotipowwds_11_dynamicfiltersselector3 ,
                                             short AV64Core_produtotipowwds_12_dynamicfiltersoperator3 ,
                                             string AV65Core_produtotipowwds_13_prtnome3 ,
                                             string AV67Core_produtotipowwds_15_tfprtsigla_sel ,
                                             string AV66Core_produtotipowwds_14_tfprtsigla ,
                                             string AV69Core_produtotipowwds_17_tfprtnome_sel ,
                                             string AV68Core_produtotipowwds_16_tfprtnome ,
                                             string A212PrtSigla ,
                                             string A213PrtNome ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A614PrtDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[12];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT PrtNome, PrtSigla, PrtDel, PrtID FROM tb_produtotipo";
         AddWhere(sWhereString, "(Not PrtDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV54Core_produtotipowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( PrtSigla like '%' || :lV54Core_produtotipowwds_2_filterfulltext) or ( PrtNome like '%' || :lV54Core_produtotipowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_produtotipowwds_3_dynamicfiltersselector1, "PRTNOME") == 0 ) && ( AV56Core_produtotipowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_produtotipowwds_5_prtnome1)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV57Core_produtotipowwds_5_prtnome1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV55Core_produtotipowwds_3_dynamicfiltersselector1, "PRTNOME") == 0 ) && ( AV56Core_produtotipowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV57Core_produtotipowwds_5_prtnome1)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV57Core_produtotipowwds_5_prtnome1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV58Core_produtotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_produtotipowwds_7_dynamicfiltersselector2, "PRTNOME") == 0 ) && ( AV60Core_produtotipowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtotipowwds_9_prtnome2)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV61Core_produtotipowwds_9_prtnome2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV58Core_produtotipowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV59Core_produtotipowwds_7_dynamicfiltersselector2, "PRTNOME") == 0 ) && ( AV60Core_produtotipowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV61Core_produtotipowwds_9_prtnome2)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV61Core_produtotipowwds_9_prtnome2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV62Core_produtotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_produtotipowwds_11_dynamicfiltersselector3, "PRTNOME") == 0 ) && ( AV64Core_produtotipowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtotipowwds_13_prtnome3)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV65Core_produtotipowwds_13_prtnome3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV62Core_produtotipowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV63Core_produtotipowwds_11_dynamicfiltersselector3, "PRTNOME") == 0 ) && ( AV64Core_produtotipowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV65Core_produtotipowwds_13_prtnome3)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like '%' || :lV65Core_produtotipowwds_13_prtnome3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtotipowwds_15_tfprtsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV66Core_produtotipowwds_14_tfprtsigla)) ) )
         {
            AddWhere(sWhereString, "(PrtSigla like :lV66Core_produtotipowwds_14_tfprtsigla)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_produtotipowwds_15_tfprtsigla_sel)) && ! ( StringUtil.StrCmp(AV67Core_produtotipowwds_15_tfprtsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PrtSigla = ( :AV67Core_produtotipowwds_15_tfprtsigla_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV67Core_produtotipowwds_15_tfprtsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PrtSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtotipowwds_17_tfprtnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_produtotipowwds_16_tfprtnome)) ) )
         {
            AddWhere(sWhereString, "(PrtNome like :lV68Core_produtotipowwds_16_tfprtnome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_produtotipowwds_17_tfprtnome_sel)) && ! ( StringUtil.StrCmp(AV69Core_produtotipowwds_17_tfprtnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(PrtNome = ( :AV69Core_produtotipowwds_17_tfprtnome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV69Core_produtotipowwds_17_tfprtnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from PrtNome))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY PrtNome";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PrtNome DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY PrtSigla";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY PrtSigla DESC";
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
                     return conditional_P004M2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (string)dynConstraints[16] , (string)dynConstraints[17] , (short)dynConstraints[18] , (bool)dynConstraints[19] , (bool)dynConstraints[20] );
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
          Object[] prmP004M2;
          prmP004M2 = new Object[] {
          new ParDef("lV54Core_produtotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV54Core_produtotipowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV57Core_produtotipowwds_5_prtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV57Core_produtotipowwds_5_prtnome1",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_produtotipowwds_9_prtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV61Core_produtotipowwds_9_prtnome2",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_produtotipowwds_13_prtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV65Core_produtotipowwds_13_prtnome3",GXType.VarChar,80,0) ,
          new ParDef("lV66Core_produtotipowwds_14_tfprtsigla",GXType.VarChar,20,0) ,
          new ParDef("AV67Core_produtotipowwds_15_tfprtsigla_sel",GXType.VarChar,20,0) ,
          new ParDef("lV68Core_produtotipowwds_16_tfprtnome",GXType.VarChar,80,0) ,
          new ParDef("AV69Core_produtotipowwds_17_tfprtnome_sel",GXType.VarChar,80,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004M2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004M2,100, GxCacheFrequency.OFF ,true,false )
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
