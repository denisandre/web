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
   public class tabeladeprecowwexportreport : GXWebProcedure
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

      public tabeladeprecowwexportreport( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladeprecowwexportreport( IGxContext context )
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
         tabeladeprecowwexportreport objtabeladeprecowwexportreport;
         objtabeladeprecowwexportreport = new tabeladeprecowwexportreport();
         objtabeladeprecowwexportreport.context.SetSubmitInitialConfig(context);
         objtabeladeprecowwexportreport.initialize();
         Submit( executePrivateCatch,objtabeladeprecowwexportreport);
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            ((tabeladeprecowwexportreport)stateInfo).executePrivate();
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
         setOutputFileName("TabelaDePrecoWWExportReport");
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
            new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladeprecoww_Execute", out  GXt_boolean1) ;
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
               AV71Title = "Lista de Tabela de Preço do Produto ou Serviço";
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
            H4H0( true, 0) ;
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
         if ( ! (false==AV73TppDel_Filtro) )
         {
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.BoolToStr( AV73TppDel_Filtro), 25, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV13FilterFullText)) )
         {
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Filtro principal", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV13FilterFullText, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
         if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(1));
            AV14DynamicFiltersSelector1 = AV27GridStateDynamicFilter.gxTpr_Selected;
            if ( StringUtil.StrCmp(AV14DynamicFiltersSelector1, "TPPCODIGO") == 0 )
            {
               AV15DynamicFiltersOperator1 = AV27GridStateDynamicFilter.gxTpr_Operator;
               AV16TppCodigo1 = AV27GridStateDynamicFilter.gxTpr_Value;
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV16TppCodigo1)) )
               {
                  if ( AV15DynamicFiltersOperator1 == 0 )
                  {
                     AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                  }
                  else if ( AV15DynamicFiltersOperator1 == 1 )
                  {
                     AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                  }
                  AV18TppCodigo = AV16TppCodigo1;
                  H4H0( false, 20) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTppCodigoDescription, "")), 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TppCodigo, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                  Gx_OldLine = Gx_line;
                  Gx_line = (int)(Gx_line+20);
               }
            }
            if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               AV19DynamicFiltersEnabled2 = true;
               AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(2));
               AV20DynamicFiltersSelector2 = AV27GridStateDynamicFilter.gxTpr_Selected;
               if ( StringUtil.StrCmp(AV20DynamicFiltersSelector2, "TPPCODIGO") == 0 )
               {
                  AV21DynamicFiltersOperator2 = AV27GridStateDynamicFilter.gxTpr_Operator;
                  AV22TppCodigo2 = AV27GridStateDynamicFilter.gxTpr_Value;
                  if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV22TppCodigo2)) )
                  {
                     if ( AV21DynamicFiltersOperator2 == 0 )
                     {
                        AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                     }
                     else if ( AV21DynamicFiltersOperator2 == 1 )
                     {
                        AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                     }
                     AV18TppCodigo = AV22TppCodigo2;
                     H4H0( false, 20) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTppCodigoDescription, "")), 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
                     getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                     getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TppCodigo, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                     Gx_OldLine = Gx_line;
                     Gx_line = (int)(Gx_line+20);
                  }
               }
               if ( AV30GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  AV23DynamicFiltersEnabled3 = true;
                  AV27GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV30GridState.gxTpr_Dynamicfilters.Item(3));
                  AV24DynamicFiltersSelector3 = AV27GridStateDynamicFilter.gxTpr_Selected;
                  if ( StringUtil.StrCmp(AV24DynamicFiltersSelector3, "TPPCODIGO") == 0 )
                  {
                     AV25DynamicFiltersOperator3 = AV27GridStateDynamicFilter.gxTpr_Operator;
                     AV26TppCodigo3 = AV27GridStateDynamicFilter.gxTpr_Value;
                     if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV26TppCodigo3)) )
                     {
                        if ( AV25DynamicFiltersOperator3 == 0 )
                        {
                           AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Começa com", "", "", "", "", "", "", "");
                        }
                        else if ( AV25DynamicFiltersOperator3 == 1 )
                        {
                           AV17FilterTppCodigoDescription = StringUtil.Format( "%1 (%2)", "Código", "Contém", "", "", "", "", "", "", "");
                        }
                        AV18TppCodigo = AV26TppCodigo3;
                        H4H0( false, 20) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV17FilterTppCodigoDescription, "")), 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
                        getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
                        getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV18TppCodigo, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
                        Gx_OldLine = Gx_line;
                        Gx_line = (int)(Gx_line+20);
                     }
                  }
               }
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV33TFTppCodigo_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV33TFTppCodigo_Sel, "<#Empty#>")==0)));
            AV33TFTppCodigo_Sel = (AV60TempBoolean ? "(Vazio)" : AV33TFTppCodigo_Sel);
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Código", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV33TFTppCodigo_Sel, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV33TFTppCodigo_Sel = (AV60TempBoolean ? "<#Empty#>" : AV33TFTppCodigo_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32TFTppCodigo)) )
            {
               H4H0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Código", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV32TFTppCodigo, "")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV35TFTppNome_Sel)) )
         {
            AV60TempBoolean = (bool)(((StringUtil.StrCmp(AV35TFTppNome_Sel, "<#Empty#>")==0)));
            AV35TFTppNome_Sel = (AV60TempBoolean ? "(Vazio)" : AV35TFTppNome_Sel);
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV35TFTppNome_Sel, "@!")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV35TFTppNome_Sel = (AV60TempBoolean ? "<#Empty#>" : AV35TFTppNome_Sel);
         }
         else
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV34TFTppNome)) )
            {
               H4H0( false, 20) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
               getPrinter().GxDrawText("Descrição", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV34TFTppNome, "@!")), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
               Gx_OldLine = Gx_line;
               Gx_line = (int)(Gx_line+20);
            }
         }
         if ( ! ( (DateTime.MinValue==AV36TFTppInsData) && (DateTime.MinValue==AV37TFTppInsData_To) ) )
         {
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText("Incluído em", 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV36TFTppInsData, "99/99/99"), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
            AV53TFTppInsData_To_Description = StringUtil.Format( "%1 (%2)", "Incluído em", "Até", "", "", "", "", "", "", "");
            H4H0( false, 20) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 169, 169, 169, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV53TFTppInsData_To_Description, "")), 25, Gx_line+0, 140, Gx_line+15, 0, 0, 0, 0) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(context.localUtil.Format( AV37TFTppInsData_To, "99/99/99"), 140, Gx_line+0, 789, Gx_line+15, 0, 0, 0, 0) ;
            Gx_OldLine = Gx_line;
            Gx_line = (int)(Gx_line+20);
         }
      }

      protected void S121( )
      {
         /* 'PRINTCOLUMNTITLES' Routine */
         returnInSub = false;
         H4H0( false, 22) ;
         getPrinter().GxDrawLine(25, Gx_line+21, 789, Gx_line+21, 2, 176, 99, 63, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+22);
         H4H0( false, 37) ;
         getPrinter().GxAttris("Microsoft Sans Serif", 9, false, false, false, false, 0, 176, 99, 63, 0, 255, 255, 255) ;
         getPrinter().GxDrawText("Código", 30, Gx_line+10, 329, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Descrição", 333, Gx_line+10, 633, Gx_line+27, 0, 0, 0, 0) ;
         getPrinter().GxDrawText("Incluído em", 637, Gx_line+10, 787, Gx_line+27, 0, 0, 0, 0) ;
         Gx_OldLine = Gx_line;
         Gx_line = (int)(Gx_line+37);
      }

      protected void S131( )
      {
         /* 'PRINTDATA' Routine */
         returnInSub = false;
         AV77Core_tabeladeprecowwds_1_tppdel_filtro = AV73TppDel_Filtro;
         AV78Core_tabeladeprecowwds_2_filterfulltext = AV13FilterFullText;
         AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV14DynamicFiltersSelector1;
         AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV15DynamicFiltersOperator1;
         AV81Core_tabeladeprecowwds_5_tppcodigo1 = AV16TppCodigo1;
         AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV19DynamicFiltersEnabled2;
         AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV20DynamicFiltersSelector2;
         AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV21DynamicFiltersOperator2;
         AV85Core_tabeladeprecowwds_9_tppcodigo2 = AV22TppCodigo2;
         AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV23DynamicFiltersEnabled3;
         AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV24DynamicFiltersSelector3;
         AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV25DynamicFiltersOperator3;
         AV89Core_tabeladeprecowwds_13_tppcodigo3 = AV26TppCodigo3;
         AV90Core_tabeladeprecowwds_14_tftppcodigo = AV32TFTppCodigo;
         AV91Core_tabeladeprecowwds_15_tftppcodigo_sel = AV33TFTppCodigo_Sel;
         AV92Core_tabeladeprecowwds_16_tftppnome = AV34TFTppNome;
         AV93Core_tabeladeprecowwds_17_tftppnome_sel = AV35TFTppNome_Sel;
         AV94Core_tabeladeprecowwds_18_tftppinsdata = AV36TFTppInsData;
         AV95Core_tabeladeprecowwds_19_tftppinsdata_to = AV37TFTppInsData_To;
         pr_default.dynParam(0, new Object[]{ new Object[]{
                                              AV78Core_tabeladeprecowwds_2_filterfulltext ,
                                              AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                              AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                              AV81Core_tabeladeprecowwds_5_tppcodigo1 ,
                                              AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                              AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                              AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                              AV85Core_tabeladeprecowwds_9_tppcodigo2 ,
                                              AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                              AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                              AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                              AV89Core_tabeladeprecowwds_13_tppcodigo3 ,
                                              AV91Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                              AV90Core_tabeladeprecowwds_14_tftppcodigo ,
                                              AV93Core_tabeladeprecowwds_17_tftppnome_sel ,
                                              AV92Core_tabeladeprecowwds_16_tftppnome ,
                                              AV94Core_tabeladeprecowwds_18_tftppinsdata ,
                                              AV95Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                              A236TppCodigo ,
                                              A237TppNome ,
                                              A238TppInsData ,
                                              AV11OrderedBy ,
                                              AV12OrderedDsc ,
                                              A602TppDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV78Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV78Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV78Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV81Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV81Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV81Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV85Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV85Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV85Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV85Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV89Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV89Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV89Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV89Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV90Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV90Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
         lV92Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV92Core_tabeladeprecowwds_16_tftppnome), "%", "");
         /* Using cursor P004H2 */
         pr_default.execute(0, new Object[] {lV78Core_tabeladeprecowwds_2_filterfulltext, lV78Core_tabeladeprecowwds_2_filterfulltext, lV81Core_tabeladeprecowwds_5_tppcodigo1, lV81Core_tabeladeprecowwds_5_tppcodigo1, lV85Core_tabeladeprecowwds_9_tppcodigo2, lV85Core_tabeladeprecowwds_9_tppcodigo2, lV89Core_tabeladeprecowwds_13_tppcodigo3, lV89Core_tabeladeprecowwds_13_tppcodigo3, lV90Core_tabeladeprecowwds_14_tftppcodigo, AV91Core_tabeladeprecowwds_15_tftppcodigo_sel, lV92Core_tabeladeprecowwds_16_tftppnome, AV93Core_tabeladeprecowwds_17_tftppnome_sel, AV94Core_tabeladeprecowwds_18_tftppinsdata, AV95Core_tabeladeprecowwds_19_tftppinsdata_to});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A238TppInsData = P004H2_A238TppInsData[0];
            A237TppNome = P004H2_A237TppNome[0];
            A236TppCodigo = P004H2_A236TppCodigo[0];
            A602TppDel = P004H2_A602TppDel[0];
            A235TppID = P004H2_A235TppID[0];
            /* Execute user subroutine: 'BEFOREPRINTLINE' */
            S144 ();
            if ( returnInSub )
            {
               pr_default.close(0);
               returnInSub = true;
               if (true) return;
            }
            H4H0( false, 36) ;
            getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 0, 0, 0, 0, 255, 255, 255) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A236TppCodigo, "")), 30, Gx_line+10, 329, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( A237TppNome, "@!")), 333, Gx_line+10, 633, Gx_line+25, 0+16, 0, 0, 0) ;
            getPrinter().GxDrawText(context.localUtil.Format( A238TppInsData, "99/99/99"), 637, Gx_line+10, 787, Gx_line+25, 0+16, 0, 0, 0) ;
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
         if ( StringUtil.StrCmp(AV28Session.Get("core.TabelaDePrecoWWGridState"), "") == 0 )
         {
            AV30GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  "core.TabelaDePrecoWWGridState"), null, "", "");
         }
         else
         {
            AV30GridState.FromXml(AV28Session.Get("core.TabelaDePrecoWWGridState"), null, "", "");
         }
         AV11OrderedBy = AV30GridState.gxTpr_Orderedby;
         AV12OrderedDsc = AV30GridState.gxTpr_Ordereddsc;
         AV96GXV1 = 1;
         while ( AV96GXV1 <= AV30GridState.gxTpr_Filtervalues.Count )
         {
            AV31GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV30GridState.gxTpr_Filtervalues.Item(AV96GXV1));
            if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TPPDEL_FILTRO") == 0 )
            {
               AV73TppDel_Filtro = BooleanUtil.Val( AV31GridStateFilterValue.gxTpr_Value);
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV13FilterFullText = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO") == 0 )
            {
               AV32TFTppCodigo = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO_SEL") == 0 )
            {
               AV33TFTppCodigo_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTPPNOME") == 0 )
            {
               AV34TFTppNome = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTPPNOME_SEL") == 0 )
            {
               AV35TFTppNome_Sel = AV31GridStateFilterValue.gxTpr_Value;
            }
            else if ( StringUtil.StrCmp(AV31GridStateFilterValue.gxTpr_Name, "TFTPPINSDATA") == 0 )
            {
               AV36TFTppInsData = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Value, 2);
               AV37TFTppInsData_To = context.localUtil.CToD( AV31GridStateFilterValue.gxTpr_Valueto, 2);
            }
            AV96GXV1 = (int)(AV96GXV1+1);
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

      protected void H4H0( bool bFoot ,
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
                  AV69PageInfo = "Page: " + StringUtil.Trim( StringUtil.Str( (decimal)(Gx_page), 6, 0));
                  AV66DateInfo = "Date: " + context.localUtil.Format( Gx_date, "99/99/99");
                  getPrinter().GxDrawRect(0, Gx_line+5, 819, Gx_line+40, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
                  getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV69PageInfo, "")), 30, Gx_line+15, 409, Gx_line+30, 0, 0, 0, 0) ;
                  getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV66DateInfo, "")), 409, Gx_line+15, 789, Gx_line+30, 2, 0, 0, 0) ;
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
               AV64AppName = "DVelop Software Solutions";
               AV70Phone = "+1 550 8923";
               AV68Mail = "info@mail.com";
               AV72Website = "http://www.web.com";
               AV61AddressLine1 = "French Boulevard 2859";
               AV62AddressLine2 = "Downtown";
               AV63AddressLine3 = "Paris, France";
               getPrinter().GxDrawRect(0, Gx_line+0, 819, Gx_line+108, 1, 0, 0, 0, 1, 176, 99, 63, 1, 1, 1, 1, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV64AppName, "")), 30, Gx_line+30, 283, Gx_line+45, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 20, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV71Title, "")), 30, Gx_line+45, 283, Gx_line+78, 0, 0, 0, 0) ;
               getPrinter().GxAttris("Microsoft Sans Serif", 8, false, false, false, false, 0, 255, 255, 255, 0, 255, 255, 255) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV70Phone, "")), 283, Gx_line+30, 536, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV68Mail, "")), 283, Gx_line+46, 536, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV72Website, "")), 283, Gx_line+62, 536, Gx_line+78, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV61AddressLine1, "")), 536, Gx_line+30, 789, Gx_line+46, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV62AddressLine2, "")), 536, Gx_line+46, 789, Gx_line+62, 2, 0, 0, 0) ;
               getPrinter().GxDrawText(StringUtil.RTrim( context.localUtil.Format( AV63AddressLine3, "")), 536, Gx_line+62, 789, Gx_line+78, 2, 0, 0, 0) ;
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
         AV71Title = "";
         AV13FilterFullText = "";
         AV30GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV27GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV14DynamicFiltersSelector1 = "";
         AV16TppCodigo1 = "";
         AV17FilterTppCodigoDescription = "";
         AV18TppCodigo = "";
         AV20DynamicFiltersSelector2 = "";
         AV22TppCodigo2 = "";
         AV24DynamicFiltersSelector3 = "";
         AV26TppCodigo3 = "";
         AV33TFTppCodigo_Sel = "";
         AV32TFTppCodigo = "";
         AV35TFTppNome_Sel = "";
         AV34TFTppNome = "";
         AV36TFTppInsData = DateTime.MinValue;
         AV37TFTppInsData_To = DateTime.MinValue;
         AV53TFTppInsData_To_Description = "";
         AV78Core_tabeladeprecowwds_2_filterfulltext = "";
         AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1 = "";
         AV81Core_tabeladeprecowwds_5_tppcodigo1 = "";
         AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2 = "";
         AV85Core_tabeladeprecowwds_9_tppcodigo2 = "";
         AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3 = "";
         AV89Core_tabeladeprecowwds_13_tppcodigo3 = "";
         AV90Core_tabeladeprecowwds_14_tftppcodigo = "";
         AV91Core_tabeladeprecowwds_15_tftppcodigo_sel = "";
         AV92Core_tabeladeprecowwds_16_tftppnome = "";
         AV93Core_tabeladeprecowwds_17_tftppnome_sel = "";
         AV94Core_tabeladeprecowwds_18_tftppinsdata = DateTime.MinValue;
         AV95Core_tabeladeprecowwds_19_tftppinsdata_to = DateTime.MinValue;
         scmdbuf = "";
         lV78Core_tabeladeprecowwds_2_filterfulltext = "";
         lV81Core_tabeladeprecowwds_5_tppcodigo1 = "";
         lV85Core_tabeladeprecowwds_9_tppcodigo2 = "";
         lV89Core_tabeladeprecowwds_13_tppcodigo3 = "";
         lV90Core_tabeladeprecowwds_14_tftppcodigo = "";
         lV92Core_tabeladeprecowwds_16_tftppnome = "";
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         P004H2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         P004H2_A237TppNome = new string[] {""} ;
         P004H2_A236TppCodigo = new string[] {""} ;
         P004H2_A602TppDel = new bool[] {false} ;
         P004H2_A235TppID = new Guid[] {Guid.Empty} ;
         A235TppID = Guid.Empty;
         AV28Session = context.GetSession();
         AV31GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         AV69PageInfo = "";
         AV66DateInfo = "";
         Gx_date = DateTime.MinValue;
         AV64AppName = "";
         AV70Phone = "";
         AV68Mail = "";
         AV72Website = "";
         AV61AddressLine1 = "";
         AV62AddressLine2 = "";
         AV63AddressLine3 = "";
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecowwexportreport__default(),
            new Object[][] {
                new Object[] {
               P004H2_A238TppInsData, P004H2_A237TppNome, P004H2_A236TppCodigo, P004H2_A602TppDel, P004H2_A235TppID
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
      private short AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ;
      private short AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ;
      private short AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ;
      private short AV11OrderedBy ;
      private int M_top ;
      private int M_bot ;
      private int Line ;
      private int ToSkip ;
      private int PrtOffset ;
      private int Gx_OldLine ;
      private int AV96GXV1 ;
      private string GXKey ;
      private string gxfirstwebparm ;
      private string scmdbuf ;
      private DateTime AV36TFTppInsData ;
      private DateTime AV37TFTppInsData_To ;
      private DateTime AV94Core_tabeladeprecowwds_18_tftppinsdata ;
      private DateTime AV95Core_tabeladeprecowwds_19_tftppinsdata_to ;
      private DateTime A238TppInsData ;
      private DateTime Gx_date ;
      private bool entryPointCalled ;
      private bool AV8IsAuthorized ;
      private bool GXt_boolean1 ;
      private bool returnInSub ;
      private bool AV73TppDel_Filtro ;
      private bool AV19DynamicFiltersEnabled2 ;
      private bool AV23DynamicFiltersEnabled3 ;
      private bool AV60TempBoolean ;
      private bool AV77Core_tabeladeprecowwds_1_tppdel_filtro ;
      private bool AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ;
      private bool AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ;
      private bool AV12OrderedDsc ;
      private bool A602TppDel ;
      private string AV71Title ;
      private string AV13FilterFullText ;
      private string AV14DynamicFiltersSelector1 ;
      private string AV16TppCodigo1 ;
      private string AV17FilterTppCodigoDescription ;
      private string AV18TppCodigo ;
      private string AV20DynamicFiltersSelector2 ;
      private string AV22TppCodigo2 ;
      private string AV24DynamicFiltersSelector3 ;
      private string AV26TppCodigo3 ;
      private string AV33TFTppCodigo_Sel ;
      private string AV32TFTppCodigo ;
      private string AV35TFTppNome_Sel ;
      private string AV34TFTppNome ;
      private string AV53TFTppInsData_To_Description ;
      private string AV78Core_tabeladeprecowwds_2_filterfulltext ;
      private string AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1 ;
      private string AV81Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2 ;
      private string AV85Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3 ;
      private string AV89Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string AV90Core_tabeladeprecowwds_14_tftppcodigo ;
      private string AV91Core_tabeladeprecowwds_15_tftppcodigo_sel ;
      private string AV92Core_tabeladeprecowwds_16_tftppnome ;
      private string AV93Core_tabeladeprecowwds_17_tftppnome_sel ;
      private string lV78Core_tabeladeprecowwds_2_filterfulltext ;
      private string lV81Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string lV85Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string lV89Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string lV90Core_tabeladeprecowwds_14_tftppcodigo ;
      private string lV92Core_tabeladeprecowwds_16_tftppnome ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string AV69PageInfo ;
      private string AV66DateInfo ;
      private string AV64AppName ;
      private string AV70Phone ;
      private string AV68Mail ;
      private string AV72Website ;
      private string AV61AddressLine1 ;
      private string AV62AddressLine2 ;
      private string AV63AddressLine3 ;
      private Guid A235TppID ;
      private IGxSession AV28Session ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private DateTime[] P004H2_A238TppInsData ;
      private string[] P004H2_A237TppNome ;
      private string[] P004H2_A236TppCodigo ;
      private bool[] P004H2_A602TppDel ;
      private Guid[] P004H2_A235TppID ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV30GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV31GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV27GridStateDynamicFilter ;
   }

   public class tabeladeprecowwexportreport__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_P004H2( IGxContext context ,
                                             string AV78Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV81Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV85Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV89Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV91Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV90Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV93Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV92Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV94Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV95Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             short AV11OrderedBy ,
                                             bool AV12OrderedDsc ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int2 = new short[14];
         Object[] GXv_Object3 = new Object[2];
         scmdbuf = "SELECT TppInsData, TppNome, TppCodigo, TppDel, TppID FROM tb_tabeladepreco";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV78Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV78Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int2[0] = 1;
            GXv_int2[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV81Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int2[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV79Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV80Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV81Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int2[3] = 1;
         }
         if ( AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV85Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int2[4] = 1;
         }
         if ( AV82Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV83Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV84Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV85Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV85Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int2[5] = 1;
         }
         if ( AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV89Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int2[6] = 1;
         }
         if ( AV86Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV87Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV88Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV89Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV89Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int2[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV90Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV90Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int2[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV91Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV91Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV91Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int2[9] = 1;
         }
         if ( StringUtil.StrCmp(AV91Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV92Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV92Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int2[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV93Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV93Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV93Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int2[11] = 1;
         }
         if ( StringUtil.StrCmp(AV93Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV94Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV94Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int2[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV95Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV95Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int2[13] = 1;
         }
         scmdbuf += sWhereString;
         if ( ( AV11OrderedBy == 1 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY TppCodigo";
         }
         else if ( ( AV11OrderedBy == 1 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppCodigo DESC";
         }
         else if ( ( AV11OrderedBy == 2 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY TppNome";
         }
         else if ( ( AV11OrderedBy == 2 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppNome DESC";
         }
         else if ( ( AV11OrderedBy == 3 ) && ! AV12OrderedDsc )
         {
            scmdbuf += " ORDER BY TppInsData";
         }
         else if ( ( AV11OrderedBy == 3 ) && ( AV12OrderedDsc ) )
         {
            scmdbuf += " ORDER BY TppInsData DESC";
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
                     return conditional_P004H2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (bool)dynConstraints[23] );
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
          Object[] prmP004H2;
          prmP004H2 = new Object[] {
          new ParDef("lV78Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV78Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV81Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV85Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV85Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV89Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV89Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV90Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV91Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV92Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV93Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV94Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV95Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("P004H2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmP004H2,100, GxCacheFrequency.OFF ,true,false )
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
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((bool[]) buf[3])[0] = rslt.getBool(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
       }
    }

 }

}
