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
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using GeneXus.Http.Server;
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs.core {
   public class clientepjcontatoww : GXDataArea
   {
      public clientepjcontatoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontatoww( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDynamicfiltersselector1 = new GXCombobox();
         cmbavDynamicfiltersoperator1 = new GXCombobox();
         cmbavDynamicfiltersselector2 = new GXCombobox();
         cmbavDynamicfiltersoperator2 = new GXCombobox();
         cmbavDynamicfiltersselector3 = new GXCombobox();
         cmbavDynamicfiltersoperator3 = new GXCombobox();
         cmbavGridactions = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetNextPar( );
            gxfirstwebparm_bkp = gxfirstwebparm;
            gxfirstwebparm = DecryptAjaxCall( gxfirstwebparm);
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( StringUtil.StrCmp(gxfirstwebparm, "dyncall") == 0 )
            {
               setAjaxCallMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               dyncall( GetNextPar( )) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxEvt") == 0 )
            {
               setAjaxEventMode();
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetNextPar( );
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Grid") == 0 )
            {
               gxnrGrid_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Grid") == 0 )
            {
               gxgrGrid_refresh_invoke( ) ;
               return  ;
            }
            else
            {
               if ( ! IsValidAjaxCall( false) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = gxfirstwebparm_bkp;
            }
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_138 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_138"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_138_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_138_idx = GetPar( "sGXsfl_138_idx");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGrid_newrow( ) ;
         /* End function gxnrGrid_newrow_invoke */
      }

      protected void gxgrGrid_refresh_invoke( )
      {
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         AV17FilterFullText = GetPar( "FilterFullText");
         cmbavDynamicfiltersselector1.FromJSonString( GetNextPar( ));
         AV18DynamicFiltersSelector1 = GetPar( "DynamicFiltersSelector1");
         cmbavDynamicfiltersoperator1.FromJSonString( GetNextPar( ));
         AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator1"), "."), 18, MidpointRounding.ToEven));
         AV20CpjConNome1 = GetPar( "CpjConNome1");
         AV21CpjTipoNome1 = GetPar( "CpjTipoNome1");
         AV22CpjConTipoNome1 = GetPar( "CpjConTipoNome1");
         AV23CpjConGenSigla1 = GetPar( "CpjConGenSigla1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV25DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV27CpjConNome2 = GetPar( "CpjConNome2");
         AV28CpjTipoNome2 = GetPar( "CpjTipoNome2");
         AV29CpjConTipoNome2 = GetPar( "CpjConTipoNome2");
         AV30CpjConGenSigla2 = GetPar( "CpjConGenSigla2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV32DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV34CpjConNome3 = GetPar( "CpjConNome3");
         AV35CpjTipoNome3 = GetPar( "CpjTipoNome3");
         AV36CpjConTipoNome3 = GetPar( "CpjConTipoNome3");
         AV37CpjConGenSigla3 = GetPar( "CpjConGenSigla3");
         AV49ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         AV24DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV31DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV44ColumnsSelector);
         AV125Pgmname = GetPar( "Pgmname");
         AV50TFCpjConNome = GetPar( "TFCpjConNome");
         AV51TFCpjConNome_Sel = GetPar( "TFCpjConNome_Sel");
         AV52TFCpjConNomePrim = GetPar( "TFCpjConNomePrim");
         AV53TFCpjConNomePrim_Sel = GetPar( "TFCpjConNomePrim_Sel");
         AV54TFCpjConSobrenome = GetPar( "TFCpjConSobrenome");
         AV55TFCpjConSobrenome_Sel = GetPar( "TFCpjConSobrenome_Sel");
         AV56TFCpjConTipoNome = GetPar( "TFCpjConTipoNome");
         AV57TFCpjConTipoNome_Sel = GetPar( "TFCpjConTipoNome_Sel");
         AV58TFCpjConCPFFormat = GetPar( "TFCpjConCPFFormat");
         AV59TFCpjConCPFFormat_Sel = GetPar( "TFCpjConCPFFormat_Sel");
         AV60TFCpjConNascimento = context.localUtil.ParseDateParm( GetPar( "TFCpjConNascimento"));
         AV61TFCpjConNascimento_To = context.localUtil.ParseDateParm( GetPar( "TFCpjConNascimento_To"));
         AV65TFCpjConGenNome = GetPar( "TFCpjConGenNome");
         AV66TFCpjConGenNome_Sel = GetPar( "TFCpjConGenNome_Sel");
         AV67TFCpjConCelNum = GetPar( "TFCpjConCelNum");
         AV68TFCpjConCelNum_Sel = GetPar( "TFCpjConCelNum_Sel");
         AV69TFCpjConTelNum = GetPar( "TFCpjConTelNum");
         AV70TFCpjConTelNum_Sel = GetPar( "TFCpjConTelNum_Sel");
         AV71TFCpjConTelRam = GetPar( "TFCpjConTelRam");
         AV72TFCpjConTelRam_Sel = GetPar( "TFCpjConTelRam_Sel");
         AV89TFCpjConWppNum = GetPar( "TFCpjConWppNum");
         AV90TFCpjConWppNum_Sel = GetPar( "TFCpjConWppNum_Sel");
         AV73TFCpjConEmail = GetPar( "TFCpjConEmail");
         AV74TFCpjConEmail_Sel = GetPar( "TFCpjConEmail_Sel");
         AV75TFCpjConLIn = GetPar( "TFCpjConLIn");
         AV76TFCpjConLIn_Sel = GetPar( "TFCpjConLIn_Sel");
         AV79TFCliNomeFamiliar = GetPar( "TFCliNomeFamiliar");
         AV80TFCliNomeFamiliar_Sel = GetPar( "TFCliNomeFamiliar_Sel");
         AV77TFCliMatricula = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCliMatricula"), "."), 18, MidpointRounding.ToEven));
         AV78TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCliMatricula_To"), "."), 18, MidpointRounding.ToEven));
         AV81TFCpjTipoNome = GetPar( "TFCpjTipoNome");
         AV82TFCpjTipoNome_Sel = GetPar( "TFCpjTipoNome_Sel");
         AV83TFCpjNomeFan = GetPar( "TFCpjNomeFan");
         AV84TFCpjNomeFan_Sel = GetPar( "TFCpjNomeFan_Sel");
         AV85TFCpjRazaoSoc = GetPar( "TFCpjRazaoSoc");
         AV86TFCpjRazaoSoc_Sel = GetPar( "TFCpjRazaoSoc_Sel");
         AV103TFCpjMatricula = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCpjMatricula"), "."), 18, MidpointRounding.ToEven));
         AV104TFCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( GetPar( "TFCpjMatricula_To"), "."), 18, MidpointRounding.ToEven));
         AV105TFCpjCNPJFormat = GetPar( "TFCpjCNPJFormat");
         AV106TFCpjCNPJFormat_Sel = GetPar( "TFCpjCNPJFormat_Sel");
         AV107TFCpjIE = GetPar( "TFCpjIE");
         AV108TFCpjIE_Sel = GetPar( "TFCpjIE_Sel");
         AV109TFCpjCelNum = GetPar( "TFCpjCelNum");
         AV110TFCpjCelNum_Sel = GetPar( "TFCpjCelNum_Sel");
         AV111TFCpjTelNum = GetPar( "TFCpjTelNum");
         AV112TFCpjTelNum_Sel = GetPar( "TFCpjTelNum_Sel");
         AV113TFCpjTelRam = GetPar( "TFCpjTelRam");
         AV114TFCpjTelRam_Sel = GetPar( "TFCpjTelRam_Sel");
         AV115TFCpjWppNum = GetPar( "TFCpjWppNum");
         AV116TFCpjWppNum_Sel = GetPar( "TFCpjWppNum_Sel");
         AV117TFCpjEmail = GetPar( "TFCpjEmail");
         AV118TFCpjEmail_Sel = GetPar( "TFCpjEmail_Sel");
         AV119TFCpjWebsite = GetPar( "TFCpjWebsite");
         AV120TFCpjWebsite_Sel = GetPar( "TFCpjWebsite_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV39DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV38DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV122IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV123IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV121IsAuthorized_CpjConNome = StringUtil.StrToBool( GetPar( "IsAuthorized_CpjConNome"));
         AV99IsAuthorized_CpjConTipoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_CpjConTipoNome"));
         AV100IsAuthorized_CliMatricula = StringUtil.StrToBool( GetPar( "IsAuthorized_CliMatricula"));
         AV124IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGrid_refresh_invoke */
      }

      protected override bool IntegratedSecurityEnabled
      {
         get {
            return true ;
         }

      }

      protected override GAMSecurityLevel IntegratedSecurityLevel
      {
         get {
            return GAMSecurityLevel.SecurityHigh ;
         }

      }

      protected override string ExecutePermissionPrefix
      {
         get {
            return "clientepjcontatoww_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
         {
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpage", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpage", new Object[] {context});
            MasterPageObj.setDataArea(this,false);
            ValidateSpaRequest();
            MasterPageObj.webExecute();
            if ( ( GxWebError == 0 ) && context.isAjaxRequest( ) )
            {
               enableOutput();
               if ( ! context.isAjaxRequest( ) )
               {
                  context.GX_webresponse.AppendHeader("Cache-Control", "no-store");
               }
               if ( ! context.WillRedirect( ) )
               {
                  AddString( context.getJSONResponse( )) ;
               }
               else
               {
                  if ( context.isAjaxRequest( ) )
                  {
                     disableOutput();
                  }
                  RenderHtmlHeaders( ) ;
                  context.Redirect( context.wjLoc );
                  context.DispatchAjaxCommands();
               }
            }
         }
         this.cleanup();
      }

      public override short ExecuteStartEvent( )
      {
         PA4S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4S2( ) ;
         }
         return gxajaxcallmode ;
      }

      public override void RenderHtmlHeaders( )
      {
         GxWebStd.gx_html_headers( context, 0, "", "", Form.Meta, Form.Metaequiv, true);
      }

      public override void RenderHtmlOpenForm( )
      {
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.WriteHtmlText( "<title>") ;
         context.SendWebValue( Form.Caption) ;
         context.WriteHtmlTextNl( "</title>") ;
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         if ( StringUtil.Len( sDynURL) > 0 )
         {
            context.WriteHtmlText( "<BASE href=\""+sDynURL+"\" />") ;
         }
         define_styles( ) ;
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
         CloseStyles();
         if ( ( ( context.GetBrowserType( ) == 1 ) || ( context.GetBrowserType( ) == 5 ) ) && ( StringUtil.StrCmp(context.GetBrowserVersion( ), "7.0") == 0 ) )
         {
            context.AddJavascriptSource("json2.js", "?"+context.GetBuildNumber( 211160), false, true);
         }
         context.AddJavascriptSource("jquery.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("gxgral.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("gxcfg.js", "?"+GetCacheInvalidationToken( ), false, true);
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"false\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjcontatoww.aspx") +"\">") ;
         GxWebStd.gx_hidden_field( context, "_EventName", "");
         GxWebStd.gx_hidden_field( context, "_EventGridId", "");
         GxWebStd.gx_hidden_field( context, "_EventRowId", "");
         context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
         AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV125Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV125Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV122IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV122IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV123IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV123IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONNOME", AV121IsAuthorized_CpjConNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONNOME", GetSecureSignedToken( "", AV121IsAuthorized_CpjConNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONTIPONOME", AV99IsAuthorized_CpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONTIPONOME", GetSecureSignedToken( "", AV99IsAuthorized_CpjConTipoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CLIMATRICULA", AV100IsAuthorized_CliMatricula);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CLIMATRICULA", GetSecureSignedToken( "", AV100IsAuthorized_CliMatricula, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV124IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV124IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONNOME1", AV20CpjConNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJTIPONOME1", AV21CpjTipoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONTIPONOME1", AV22CpjConTipoNome1);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONGENSIGLA1", AV23CpjConGenSigla1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV25DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONNOME2", AV27CpjConNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJTIPONOME2", AV28CpjTipoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONTIPONOME2", AV29CpjConTipoNome2);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONGENSIGLA2", AV30CpjConGenSigla2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV32DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV33DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONNOME3", AV34CpjConNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJTIPONOME3", AV35CpjTipoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONTIPONOME3", AV36CpjConTipoNome3);
         GxWebStd.gx_hidden_field( context, "GXH_vCPJCONGENSIGLA3", AV37CpjConGenSigla3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_138", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_138), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV47ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV47ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV95GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV96GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV97GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV101AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV101AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV91DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV91DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV44ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV44ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_CPJCONNASCIMENTOAUXDATE", context.localUtil.DToC( AV62DDO_CpjConNascimentoAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_CPJCONNASCIMENTOAUXDATETO", context.localUtil.DToC( AV63DDO_CpjConNascimentoAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV24DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV31DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV125Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV125Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNOME", AV50TFCpjConNome);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNOME_SEL", AV51TFCpjConNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNOMEPRIM", AV52TFCpjConNomePrim);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNOMEPRIM_SEL", AV53TFCpjConNomePrim_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONSOBRENOME", AV54TFCpjConSobrenome);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONSOBRENOME_SEL", AV55TFCpjConSobrenome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTIPONOME", AV56TFCpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTIPONOME_SEL", AV57TFCpjConTipoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONCPFFORMAT", AV58TFCpjConCPFFormat);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONCPFFORMAT_SEL", AV59TFCpjConCPFFormat_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNASCIMENTO", context.localUtil.DToC( AV60TFCpjConNascimento, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONNASCIMENTO_TO", context.localUtil.DToC( AV61TFCpjConNascimento_To, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONGENNOME", AV65TFCpjConGenNome);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONGENNOME_SEL", AV66TFCpjConGenNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONCELNUM", StringUtil.RTrim( AV67TFCpjConCelNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONCELNUM_SEL", StringUtil.RTrim( AV68TFCpjConCelNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTELNUM", StringUtil.RTrim( AV69TFCpjConTelNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTELNUM_SEL", StringUtil.RTrim( AV70TFCpjConTelNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTELRAM", AV71TFCpjConTelRam);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONTELRAM_SEL", AV72TFCpjConTelRam_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONWPPNUM", StringUtil.RTrim( AV89TFCpjConWppNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONWPPNUM_SEL", StringUtil.RTrim( AV90TFCpjConWppNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJCONEMAIL", AV73TFCpjConEmail);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONEMAIL_SEL", AV74TFCpjConEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONLIN", AV75TFCpjConLIn);
         GxWebStd.gx_hidden_field( context, "vTFCPJCONLIN_SEL", AV76TFCpjConLIn_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLINOMEFAMILIAR", AV79TFCliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "vTFCLINOMEFAMILIAR_SEL", AV80TFCliNomeFamiliar_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCLIMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV77TFCliMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCLIMATRICULA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV78TFCliMatricula_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCPJTIPONOME", AV81TFCpjTipoNome);
         GxWebStd.gx_hidden_field( context, "vTFCPJTIPONOME_SEL", AV82TFCpjTipoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJNOMEFAN", AV83TFCpjNomeFan);
         GxWebStd.gx_hidden_field( context, "vTFCPJNOMEFAN_SEL", AV84TFCpjNomeFan_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJRAZAOSOC", AV85TFCpjRazaoSoc);
         GxWebStd.gx_hidden_field( context, "vTFCPJRAZAOSOC_SEL", AV86TFCpjRazaoSoc_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJMATRICULA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV103TFCpjMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCPJMATRICULA_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV104TFCpjMatricula_To), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFCPJCNPJFORMAT", AV105TFCpjCNPJFormat);
         GxWebStd.gx_hidden_field( context, "vTFCPJCNPJFORMAT_SEL", AV106TFCpjCNPJFormat_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJIE", AV107TFCpjIE);
         GxWebStd.gx_hidden_field( context, "vTFCPJIE_SEL", AV108TFCpjIE_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJCELNUM", StringUtil.RTrim( AV109TFCpjCelNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJCELNUM_SEL", StringUtil.RTrim( AV110TFCpjCelNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJTELNUM", StringUtil.RTrim( AV111TFCpjTelNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJTELNUM_SEL", StringUtil.RTrim( AV112TFCpjTelNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJTELRAM", AV113TFCpjTelRam);
         GxWebStd.gx_hidden_field( context, "vTFCPJTELRAM_SEL", AV114TFCpjTelRam_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJWPPNUM", StringUtil.RTrim( AV115TFCpjWppNum));
         GxWebStd.gx_hidden_field( context, "vTFCPJWPPNUM_SEL", StringUtil.RTrim( AV116TFCpjWppNum_Sel));
         GxWebStd.gx_hidden_field( context, "vTFCPJEMAIL", AV117TFCpjEmail);
         GxWebStd.gx_hidden_field( context, "vTFCPJEMAIL_SEL", AV118TFCpjEmail_Sel);
         GxWebStd.gx_hidden_field( context, "vTFCPJWEBSITE", AV119TFCpjWebsite);
         GxWebStd.gx_hidden_field( context, "vTFCPJWEBSITE_SEL", AV120TFCpjWebsite_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV39DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV38DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV122IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV122IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV123IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV123IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONNOME", AV121IsAuthorized_CpjConNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONNOME", GetSecureSignedToken( "", AV121IsAuthorized_CpjConNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONTIPONOME", AV99IsAuthorized_CpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONTIPONOME", GetSecureSignedToken( "", AV99IsAuthorized_CpjConTipoNome, context));
         GxWebStd.gx_hidden_field( context, "CPJCONTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A270CpjConTipoID), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CLIMATRICULA", AV100IsAuthorized_CliMatricula);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CLIMATRICULA", GetSecureSignedToken( "", AV100IsAuthorized_CliMatricula, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV124IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV124IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icontype", StringUtil.RTrim( Ddo_managefilters_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Icon", StringUtil.RTrim( Ddo_managefilters_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Tooltip", StringUtil.RTrim( Ddo_managefilters_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Cls", StringUtil.RTrim( Ddo_managefilters_Cls));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Class", StringUtil.RTrim( Gridpaginationbar_Class));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showfirst", StringUtil.BoolToStr( Gridpaginationbar_Showfirst));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showprevious", StringUtil.BoolToStr( Gridpaginationbar_Showprevious));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Shownext", StringUtil.BoolToStr( Gridpaginationbar_Shownext));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Showlast", StringUtil.BoolToStr( Gridpaginationbar_Showlast));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagestoshow", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Pagestoshow), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingbuttonsposition", StringUtil.RTrim( Gridpaginationbar_Pagingbuttonsposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Pagingcaptionposition", StringUtil.RTrim( Gridpaginationbar_Pagingcaptionposition));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridclass", StringUtil.RTrim( Gridpaginationbar_Emptygridclass));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselector", StringUtil.BoolToStr( Gridpaginationbar_Rowsperpageselector));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageoptions", StringUtil.RTrim( Gridpaginationbar_Rowsperpageoptions));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_First", StringUtil.RTrim( Gridpaginationbar_First));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Previous", StringUtil.RTrim( Gridpaginationbar_Previous));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Next", StringUtil.RTrim( Gridpaginationbar_Next));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Last", StringUtil.RTrim( Gridpaginationbar_Last));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Caption", StringUtil.RTrim( Gridpaginationbar_Caption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Emptygridcaption", StringUtil.RTrim( Gridpaginationbar_Emptygridcaption));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpagecaption", StringUtil.RTrim( Gridpaginationbar_Rowsperpagecaption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icontype", StringUtil.RTrim( Ddo_agexport_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Icon", StringUtil.RTrim( Ddo_agexport_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Caption", StringUtil.RTrim( Ddo_agexport_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Cls", StringUtil.RTrim( Ddo_agexport_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_agexport_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Caption", StringUtil.RTrim( Ddc_subscriptions_Caption));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace", StringUtil.RTrim( Ddc_subscriptions_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_set", StringUtil.RTrim( Ddo_grid_Filteredtext_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_set", StringUtil.RTrim( Ddo_grid_Filteredtextto_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_set", StringUtil.RTrim( Ddo_grid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gamoauthtoken", StringUtil.RTrim( Ddo_grid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includesortasc", StringUtil.RTrim( Ddo_grid_Includesortasc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Sortedstatus", StringUtil.RTrim( Ddo_grid_Sortedstatus));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includefilter", StringUtil.RTrim( Ddo_grid_Includefilter));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filtertype", StringUtil.RTrim( Ddo_grid_Filtertype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filterisrange", StringUtil.RTrim( Ddo_grid_Filterisrange));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Format", StringUtil.RTrim( Ddo_grid_Format));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Width", StringUtil.RTrim( Innewwindow1_Width));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Height", StringUtil.RTrim( Innewwindow1_Height));
         GxWebStd.gx_hidden_field( context, "INNEWWINDOW1_Target", StringUtil.RTrim( Innewwindow1_Target));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridinternalname", StringUtil.RTrim( Grid_titlescategories_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_TITLESCATEGORIES_Gridtitlescategories", StringUtil.RTrim( Grid_titlescategories_Gridtitlescategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascategories", StringUtil.BoolToStr( Grid_empowerer_Hascategories));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
         SendComponentObjects();
         SendServerCommands();
         SendState();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         context.WriteHtmlTextNl( "</form>") ;
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         include_jscripts( ) ;
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            WebComp_Wwpaux_wc.componentjscripts();
         }
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE4S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4S2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return false ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         return formatLink("core.clientepjcontatoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJContatoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Contato" ;
      }

      protected void WB4S0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainWithShadow", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellPaddingBottom", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableheadercontent_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(138), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_25_4S2( true) ;
         }
         else
         {
            wb_table1_25_4S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_4S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellAdvancedFiltersHidden", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdvancedfilterscontainer_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfilters_Internalname, 1, 0, "px", 0, "px", "TableDynamicFiltersFlex", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_49_4S2( true) ;
         }
         else
         {
            wb_table2_49_4S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_49_4S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV25DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_80_4S2( true) ;
         }
         else
         {
            wb_table3_80_4S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_80_4S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrow3_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 107,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV32DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,107);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_111_4S2( true) ;
         }
         else
         {
            wb_table4_111_4S2( false) ;
         }
         return  ;
      }

      protected void wb_table4_111_4S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            ClassString = "ErrorViewer";
            StyleString = "";
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell HasGridEmpowerer", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGridtablewithpaginationbar_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl138( ) ;
         }
         if ( wbEnd == 138 )
         {
            wbEnd = 0;
            nRC_GXsfl_138 = (int)(nGXsfl_138_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGridpaginationbar.SetProperty("Class", Gridpaginationbar_Class);
            ucGridpaginationbar.SetProperty("ShowFirst", Gridpaginationbar_Showfirst);
            ucGridpaginationbar.SetProperty("ShowPrevious", Gridpaginationbar_Showprevious);
            ucGridpaginationbar.SetProperty("ShowNext", Gridpaginationbar_Shownext);
            ucGridpaginationbar.SetProperty("ShowLast", Gridpaginationbar_Showlast);
            ucGridpaginationbar.SetProperty("PagesToShow", Gridpaginationbar_Pagestoshow);
            ucGridpaginationbar.SetProperty("PagingButtonsPosition", Gridpaginationbar_Pagingbuttonsposition);
            ucGridpaginationbar.SetProperty("PagingCaptionPosition", Gridpaginationbar_Pagingcaptionposition);
            ucGridpaginationbar.SetProperty("EmptyGridClass", Gridpaginationbar_Emptygridclass);
            ucGridpaginationbar.SetProperty("RowsPerPageSelector", Gridpaginationbar_Rowsperpageselector);
            ucGridpaginationbar.SetProperty("RowsPerPageOptions", Gridpaginationbar_Rowsperpageoptions);
            ucGridpaginationbar.SetProperty("First", Gridpaginationbar_First);
            ucGridpaginationbar.SetProperty("Previous", Gridpaginationbar_Previous);
            ucGridpaginationbar.SetProperty("Next", Gridpaginationbar_Next);
            ucGridpaginationbar.SetProperty("Last", Gridpaginationbar_Last);
            ucGridpaginationbar.SetProperty("Caption", Gridpaginationbar_Caption);
            ucGridpaginationbar.SetProperty("EmptyGridCaption", Gridpaginationbar_Emptygridcaption);
            ucGridpaginationbar.SetProperty("RowsPerPageCaption", Gridpaginationbar_Rowsperpagecaption);
            ucGridpaginationbar.SetProperty("CurrentPage", AV95GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV96GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV97GridAppliedFilters);
            ucGridpaginationbar.Render(context, "dvelop.dvpaginationbar", Gridpaginationbar_Internalname, "GRIDPAGINATIONBARContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdo_agexport.SetProperty("IconType", Ddo_agexport_Icontype);
            ucDdo_agexport.SetProperty("Icon", Ddo_agexport_Icon);
            ucDdo_agexport.SetProperty("Caption", Ddo_agexport_Caption);
            ucDdo_agexport.SetProperty("Cls", Ddo_agexport_Cls);
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV101AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\ClientePJContatoWW.htm");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV91DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucInnewwindow1.Render(context, "innewwindow", Innewwindow1_Internalname, "INNEWWINDOW1Container");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV91DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV44ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_titlescategories.SetProperty("GridTitlesCategories", Grid_titlescategories_Gridtitlescategories);
            ucGrid_titlescategories.Render(context, "dvelop.gridtitlescategories", Grid_titlescategories_Internalname, "GRID_TITLESCATEGORIESContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasCategories", Grid_empowerer_Hascategories);
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0185"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0185"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_138_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0185"+"");
                     }
                     WebComp_Wwpaux_wc.componentdraw();
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspEndCmp();
                     }
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDdo_cpjconnascimentoauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 187,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_cpjconnascimentoauxdatetext_Internalname, AV64DDO_CpjConNascimentoAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV64DDO_CpjConNascimentoAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,187);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_cpjconnascimentoauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            /* User Defined Control */
            ucTfcpjconnascimento_rangepicker.SetProperty("Start Date", AV62DDO_CpjConNascimentoAuxDate);
            ucTfcpjconnascimento_rangepicker.SetProperty("End Date", AV63DDO_CpjConNascimentoAuxDateTo);
            ucTfcpjconnascimento_rangepicker.Render(context, "wwp.daterangepicker", Tfcpjconnascimento_rangepicker_Internalname, "TFCPJCONNASCIMENTO_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 138 )
         {
            wbEnd = 0;
            if ( isFullAjaxMode( ) )
            {
               if ( GridContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Grid", GridContainer, subGrid_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData", GridContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridContainerData"+"V", GridContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridContainerData"+"V"+"\" value='"+GridContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         wbLoad = true;
      }

      protected void START4S2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_4-173650", 0) ;
            }
            Form.Meta.addItem("description", " Contato", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4S0( ) ;
      }

      protected void WS4S2( )
      {
         START4S2( ) ;
         EVT4S2( ) ;
      }

      protected void EVT4S2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
               sEvt = cgiGet( "_EventName");
               EvtGridId = cgiGet( "_EventGridId");
               EvtRowId = cgiGet( "_EventRowId");
               if ( StringUtil.Len( sEvt) > 0 )
               {
                  sEvtType = StringUtil.Left( sEvt, 1);
                  sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-1));
                  if ( StringUtil.StrCmp(sEvtType, "M") != 0 )
                  {
                     if ( StringUtil.StrCmp(sEvtType, "E") == 0 )
                     {
                        sEvtType = StringUtil.Right( sEvt, 1);
                        if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                        {
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_MANAGEFILTERS.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E114S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E174S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E184S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E194S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E204S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E214S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E224S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E234S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E244S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E254S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E264S2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 18), "VGRIDACTIONS.CLICK") == 0 ) )
                           {
                              nGXsfl_138_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
                              SubsflControlProps_1382( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV98GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV98GridActions), 4, 0));
                              A275CpjConNome = StringUtil.Upper( cgiGet( edtCpjConNome_Internalname));
                              A276CpjConNomePrim = StringUtil.Upper( cgiGet( edtCpjConNomePrim_Internalname));
                              A277CpjConSobrenome = StringUtil.Upper( cgiGet( edtCpjConSobrenome_Internalname));
                              A272CpjConTipoNome = StringUtil.Upper( cgiGet( edtCpjConTipoNome_Internalname));
                              A274CpjConCPFFormat = cgiGet( edtCpjConCPFFormat_Internalname);
                              A282CpjConNascimento = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtCpjConNascimento_Internalname), 0));
                              A281CpjConGenNome = StringUtil.Upper( cgiGet( edtCpjConGenNome_Internalname));
                              A285CpjConCelNum = cgiGet( edtCpjConCelNum_Internalname);
                              n285CpjConCelNum = false;
                              A283CpjConTelNum = cgiGet( edtCpjConTelNum_Internalname);
                              n283CpjConTelNum = false;
                              A284CpjConTelRam = cgiGet( edtCpjConTelRam_Internalname);
                              n284CpjConTelRam = false;
                              A286CpjConWppNum = cgiGet( edtCpjConWppNum_Internalname);
                              n286CpjConWppNum = false;
                              A287CpjConEmail = cgiGet( edtCpjConEmail_Internalname);
                              n287CpjConEmail = false;
                              A288CpjConLIn = cgiGet( edtCpjConLIn_Internalname);
                              n288CpjConLIn = false;
                              A160CliNomeFamiliar = StringUtil.Upper( cgiGet( edtCliNomeFamiliar_Internalname));
                              A159CliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCliMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A367CpjTipoNome = StringUtil.Upper( cgiGet( edtCpjTipoNome_Internalname));
                              A170CpjNomeFan = StringUtil.Upper( cgiGet( edtCpjNomeFan_Internalname));
                              A171CpjRazaoSoc = StringUtil.Upper( cgiGet( edtCpjRazaoSoc_Internalname));
                              A176CpjMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A188CpjCNPJFormat = cgiGet( edtCpjCNPJFormat_Internalname);
                              A189CpjIE = StringUtil.Upper( cgiGet( edtCpjIE_Internalname));
                              A263CpjCelNum = cgiGet( edtCpjCelNum_Internalname);
                              n263CpjCelNum = false;
                              A261CpjTelNum = cgiGet( edtCpjTelNum_Internalname);
                              n261CpjTelNum = false;
                              A262CpjTelRam = cgiGet( edtCpjTelRam_Internalname);
                              n262CpjTelRam = false;
                              A264CpjWppNum = cgiGet( edtCpjWppNum_Internalname);
                              n264CpjWppNum = false;
                              A266CpjEmail = cgiGet( edtCpjEmail_Internalname);
                              n266CpjEmail = false;
                              A265CpjWebsite = cgiGet( edtCpjWebsite_Internalname);
                              n265CpjWebsite = false;
                              A158CliID = StringUtil.StrToGuid( cgiGet( edtCliID_Internalname));
                              A166CpjID = StringUtil.StrToGuid( cgiGet( edtCpjID_Internalname));
                              A269CpjConSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtCpjConSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E274S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E284S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E294S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E304S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
                                       /* Set Refresh If Filterfulltext Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator1 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjconnome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME1"), AV20CpjConNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjtiponome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME1"), AV21CpjTipoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcontiponome1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME1"), AV22CpjConTipoNome1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcongensigla1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA1"), AV23CpjConGenSigla1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV25DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjconnome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME2"), AV27CpjConNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjtiponome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME2"), AV28CpjTipoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcontiponome2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME2"), AV29CpjConTipoNome2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcongensigla2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA2"), AV30CpjConGenSigla2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV32DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV33DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjconnome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME3"), AV34CpjConNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjtiponome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME3"), AV35CpjTipoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcontiponome3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME3"), AV36CpjConTipoNome3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Cpjcongensigla3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA3"), AV37CpjConGenSigla3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       if ( ! Rfr0gs )
                                       {
                                       }
                                       dynload_actions( ) ;
                                    }
                                    /* No code required for Cancel button. It is implemented as the Reset button. */
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                 }
                              }
                              else
                              {
                              }
                           }
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 185 )
                        {
                           OldWwpaux_wc = cgiGet( "W0185");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0185", "", sEvt);
                           }
                           WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE4S2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA4S2( )
      {
         if ( nDonePA == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            init_web_controls( ) ;
            if ( toggleJsOutput )
            {
               if ( context.isSpaRequest( ) )
               {
                  enableJsOutput();
               }
            }
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavFilterfulltext_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_1382( ) ;
         while ( nGXsfl_138_idx <= nRC_GXsfl_138 )
         {
            sendrow_1382( ) ;
            nGXsfl_138_idx = ((subGrid_Islastpage==1)&&(nGXsfl_138_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20CpjConNome1 ,
                                       string AV21CpjTipoNome1 ,
                                       string AV22CpjConTipoNome1 ,
                                       string AV23CpjConGenSigla1 ,
                                       string AV25DynamicFiltersSelector2 ,
                                       short AV26DynamicFiltersOperator2 ,
                                       string AV27CpjConNome2 ,
                                       string AV28CpjTipoNome2 ,
                                       string AV29CpjConTipoNome2 ,
                                       string AV30CpjConGenSigla2 ,
                                       string AV32DynamicFiltersSelector3 ,
                                       short AV33DynamicFiltersOperator3 ,
                                       string AV34CpjConNome3 ,
                                       string AV35CpjTipoNome3 ,
                                       string AV36CpjConTipoNome3 ,
                                       string AV37CpjConGenSigla3 ,
                                       short AV49ManageFiltersExecutionStep ,
                                       bool AV24DynamicFiltersEnabled2 ,
                                       bool AV31DynamicFiltersEnabled3 ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV44ColumnsSelector ,
                                       string AV125Pgmname ,
                                       string AV50TFCpjConNome ,
                                       string AV51TFCpjConNome_Sel ,
                                       string AV52TFCpjConNomePrim ,
                                       string AV53TFCpjConNomePrim_Sel ,
                                       string AV54TFCpjConSobrenome ,
                                       string AV55TFCpjConSobrenome_Sel ,
                                       string AV56TFCpjConTipoNome ,
                                       string AV57TFCpjConTipoNome_Sel ,
                                       string AV58TFCpjConCPFFormat ,
                                       string AV59TFCpjConCPFFormat_Sel ,
                                       DateTime AV60TFCpjConNascimento ,
                                       DateTime AV61TFCpjConNascimento_To ,
                                       string AV65TFCpjConGenNome ,
                                       string AV66TFCpjConGenNome_Sel ,
                                       string AV67TFCpjConCelNum ,
                                       string AV68TFCpjConCelNum_Sel ,
                                       string AV69TFCpjConTelNum ,
                                       string AV70TFCpjConTelNum_Sel ,
                                       string AV71TFCpjConTelRam ,
                                       string AV72TFCpjConTelRam_Sel ,
                                       string AV89TFCpjConWppNum ,
                                       string AV90TFCpjConWppNum_Sel ,
                                       string AV73TFCpjConEmail ,
                                       string AV74TFCpjConEmail_Sel ,
                                       string AV75TFCpjConLIn ,
                                       string AV76TFCpjConLIn_Sel ,
                                       string AV79TFCliNomeFamiliar ,
                                       string AV80TFCliNomeFamiliar_Sel ,
                                       long AV77TFCliMatricula ,
                                       long AV78TFCliMatricula_To ,
                                       string AV81TFCpjTipoNome ,
                                       string AV82TFCpjTipoNome_Sel ,
                                       string AV83TFCpjNomeFan ,
                                       string AV84TFCpjNomeFan_Sel ,
                                       string AV85TFCpjRazaoSoc ,
                                       string AV86TFCpjRazaoSoc_Sel ,
                                       long AV103TFCpjMatricula ,
                                       long AV104TFCpjMatricula_To ,
                                       string AV105TFCpjCNPJFormat ,
                                       string AV106TFCpjCNPJFormat_Sel ,
                                       string AV107TFCpjIE ,
                                       string AV108TFCpjIE_Sel ,
                                       string AV109TFCpjCelNum ,
                                       string AV110TFCpjCelNum_Sel ,
                                       string AV111TFCpjTelNum ,
                                       string AV112TFCpjTelNum_Sel ,
                                       string AV113TFCpjTelRam ,
                                       string AV114TFCpjTelRam_Sel ,
                                       string AV115TFCpjWppNum ,
                                       string AV116TFCpjWppNum_Sel ,
                                       string AV117TFCpjEmail ,
                                       string AV118TFCpjEmail_Sel ,
                                       string AV119TFCpjWebsite ,
                                       string AV120TFCpjWebsite_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV39DynamicFiltersIgnoreFirst ,
                                       bool AV38DynamicFiltersRemoving ,
                                       bool AV122IsAuthorized_Update ,
                                       bool AV123IsAuthorized_Delete ,
                                       bool AV121IsAuthorized_CpjConNome ,
                                       bool AV99IsAuthorized_CpjConTipoNome ,
                                       bool AV100IsAuthorized_CliMatricula ,
                                       bool AV124IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIID", GetSecureSignedToken( "", A158CliID, context));
         GxWebStd.gx_hidden_field( context, "CLIID", A158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_CPJID", GetSecureSignedToken( "", A166CpjID, context));
         GxWebStd.gx_hidden_field( context, "CPJID", A166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_CPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A269CpjConSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "CPJCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ".", "")));
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV25DynamicFiltersSelector2);
            AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV32DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV32DynamicFiltersSelector3);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV125Pgmname = "core.ClientePJContatoWW";
      }

      protected void RF4S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 138;
         /* Execute user event: Refresh */
         E284S2 ();
         nGXsfl_138_idx = 1;
         sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
         SubsflControlProps_1382( ) ;
         bGXsfl_138_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  WebComp_Wwpaux_wc.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_1382( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV126Core_clientepjcontatowwds_1_filterfulltext ,
                                                 AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                                 AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                                 AV129Core_clientepjcontatowwds_4_cpjconnome1 ,
                                                 AV130Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                                 AV131Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                                 AV132Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                                 AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                                 AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                                 AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                                 AV136Core_clientepjcontatowwds_11_cpjconnome2 ,
                                                 AV137Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                                 AV138Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                                 AV139Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                                 AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                                 AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                                 AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                                 AV143Core_clientepjcontatowwds_18_cpjconnome3 ,
                                                 AV144Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                                 AV145Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                                 AV146Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                                 AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                                 AV147Core_clientepjcontatowwds_22_tfcpjconnome ,
                                                 AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                                 AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                                 AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                                 AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                                 AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                                 AV153Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                                 AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                                 AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                                 AV157Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                                 AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                                 AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                                 AV159Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                                 AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                                 AV161Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                                 AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                                 AV163Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                                 AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                                 AV165Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                                 AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                                 AV167Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                                 AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                                 AV169Core_clientepjcontatowwds_44_tfcpjconemail ,
                                                 AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                                 AV171Core_clientepjcontatowwds_46_tfcpjconlin ,
                                                 AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                                 AV173Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                                 AV175Core_clientepjcontatowwds_50_tfclimatricula ,
                                                 AV176Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                                 AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                                 AV177Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                                 AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                                 AV179Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                                 AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                                 AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                                 AV183Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                                 AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                                 AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                                 AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                                 AV188Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                                 AV187Core_clientepjcontatowwds_62_tfcpjie ,
                                                 AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                                 AV189Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                                 AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                                 AV191Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                                 AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                                 AV193Core_clientepjcontatowwds_68_tfcpjtelram ,
                                                 AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                                 AV195Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                                 AV198Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                                 AV197Core_clientepjcontatowwds_72_tfcpjemail ,
                                                 AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                                 AV199Core_clientepjcontatowwds_74_tfcpjwebsite ,
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
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                                 TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
            lV129Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
            lV129Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
            lV130Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
            lV130Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
            lV131Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
            lV131Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
            lV132Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
            lV132Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
            lV136Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
            lV136Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
            lV137Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
            lV137Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
            lV138Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
            lV138Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
            lV139Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
            lV139Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
            lV143Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
            lV143Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
            lV144Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
            lV144Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
            lV145Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
            lV145Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
            lV146Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
            lV146Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
            lV147Core_clientepjcontatowwds_22_tfcpjconnome = StringUtil.Concat( StringUtil.RTrim( AV147Core_clientepjcontatowwds_22_tfcpjconnome), "%", "");
            lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = StringUtil.Concat( StringUtil.RTrim( AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim), "%", "");
            lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = StringUtil.Concat( StringUtil.RTrim( AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome), "%", "");
            lV153Core_clientepjcontatowwds_28_tfcpjcontiponome = StringUtil.Concat( StringUtil.RTrim( AV153Core_clientepjcontatowwds_28_tfcpjcontiponome), "%", "");
            lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = StringUtil.Concat( StringUtil.RTrim( AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat), "%", "");
            lV159Core_clientepjcontatowwds_34_tfcpjcongennome = StringUtil.Concat( StringUtil.RTrim( AV159Core_clientepjcontatowwds_34_tfcpjcongennome), "%", "");
            lV161Core_clientepjcontatowwds_36_tfcpjconcelnum = StringUtil.PadR( StringUtil.RTrim( AV161Core_clientepjcontatowwds_36_tfcpjconcelnum), 20, "%");
            lV163Core_clientepjcontatowwds_38_tfcpjcontelnum = StringUtil.PadR( StringUtil.RTrim( AV163Core_clientepjcontatowwds_38_tfcpjcontelnum), 20, "%");
            lV165Core_clientepjcontatowwds_40_tfcpjcontelram = StringUtil.Concat( StringUtil.RTrim( AV165Core_clientepjcontatowwds_40_tfcpjcontelram), "%", "");
            lV167Core_clientepjcontatowwds_42_tfcpjconwppnum = StringUtil.PadR( StringUtil.RTrim( AV167Core_clientepjcontatowwds_42_tfcpjconwppnum), 20, "%");
            lV169Core_clientepjcontatowwds_44_tfcpjconemail = StringUtil.Concat( StringUtil.RTrim( AV169Core_clientepjcontatowwds_44_tfcpjconemail), "%", "");
            lV171Core_clientepjcontatowwds_46_tfcpjconlin = StringUtil.Concat( StringUtil.RTrim( AV171Core_clientepjcontatowwds_46_tfcpjconlin), "%", "");
            lV173Core_clientepjcontatowwds_48_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV173Core_clientepjcontatowwds_48_tfclinomefamiliar), "%", "");
            lV177Core_clientepjcontatowwds_52_tfcpjtiponome = StringUtil.Concat( StringUtil.RTrim( AV177Core_clientepjcontatowwds_52_tfcpjtiponome), "%", "");
            lV179Core_clientepjcontatowwds_54_tfcpjnomefan = StringUtil.Concat( StringUtil.RTrim( AV179Core_clientepjcontatowwds_54_tfcpjnomefan), "%", "");
            lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = StringUtil.Concat( StringUtil.RTrim( AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc), "%", "");
            lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = StringUtil.Concat( StringUtil.RTrim( AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat), "%", "");
            lV187Core_clientepjcontatowwds_62_tfcpjie = StringUtil.Concat( StringUtil.RTrim( AV187Core_clientepjcontatowwds_62_tfcpjie), "%", "");
            lV189Core_clientepjcontatowwds_64_tfcpjcelnum = StringUtil.PadR( StringUtil.RTrim( AV189Core_clientepjcontatowwds_64_tfcpjcelnum), 20, "%");
            lV191Core_clientepjcontatowwds_66_tfcpjtelnum = StringUtil.PadR( StringUtil.RTrim( AV191Core_clientepjcontatowwds_66_tfcpjtelnum), 20, "%");
            lV193Core_clientepjcontatowwds_68_tfcpjtelram = StringUtil.Concat( StringUtil.RTrim( AV193Core_clientepjcontatowwds_68_tfcpjtelram), "%", "");
            lV195Core_clientepjcontatowwds_70_tfcpjwppnum = StringUtil.PadR( StringUtil.RTrim( AV195Core_clientepjcontatowwds_70_tfcpjwppnum), 20, "%");
            lV197Core_clientepjcontatowwds_72_tfcpjemail = StringUtil.Concat( StringUtil.RTrim( AV197Core_clientepjcontatowwds_72_tfcpjemail), "%", "");
            lV199Core_clientepjcontatowwds_74_tfcpjwebsite = StringUtil.Concat( StringUtil.RTrim( AV199Core_clientepjcontatowwds_74_tfcpjwebsite), "%", "");
            /* Using cursor H004S2 */
            pr_default.execute(0, new Object[] {lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV129Core_clientepjcontatowwds_4_cpjconnome1, lV129Core_clientepjcontatowwds_4_cpjconnome1, lV130Core_clientepjcontatowwds_5_cpjtiponome1, lV130Core_clientepjcontatowwds_5_cpjtiponome1, lV131Core_clientepjcontatowwds_6_cpjcontiponome1, lV131Core_clientepjcontatowwds_6_cpjcontiponome1, lV132Core_clientepjcontatowwds_7_cpjcongensigla1, lV132Core_clientepjcontatowwds_7_cpjcongensigla1, lV136Core_clientepjcontatowwds_11_cpjconnome2, lV136Core_clientepjcontatowwds_11_cpjconnome2, lV137Core_clientepjcontatowwds_12_cpjtiponome2, lV137Core_clientepjcontatowwds_12_cpjtiponome2, lV138Core_clientepjcontatowwds_13_cpjcontiponome2, lV138Core_clientepjcontatowwds_13_cpjcontiponome2, lV139Core_clientepjcontatowwds_14_cpjcongensigla2, lV139Core_clientepjcontatowwds_14_cpjcongensigla2, lV143Core_clientepjcontatowwds_18_cpjconnome3, lV143Core_clientepjcontatowwds_18_cpjconnome3, lV144Core_clientepjcontatowwds_19_cpjtiponome3, lV144Core_clientepjcontatowwds_19_cpjtiponome3, lV145Core_clientepjcontatowwds_20_cpjcontiponome3, lV145Core_clientepjcontatowwds_20_cpjcontiponome3, lV146Core_clientepjcontatowwds_21_cpjcongensigla3, lV146Core_clientepjcontatowwds_21_cpjcongensigla3, lV147Core_clientepjcontatowwds_22_tfcpjconnome, AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim, AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome, AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, lV153Core_clientepjcontatowwds_28_tfcpjcontiponome, AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat, AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, AV157Core_clientepjcontatowwds_32_tfcpjconnascimento, AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to, lV159Core_clientepjcontatowwds_34_tfcpjcongennome, AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, lV161Core_clientepjcontatowwds_36_tfcpjconcelnum, AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, lV163Core_clientepjcontatowwds_38_tfcpjcontelnum, AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, lV165Core_clientepjcontatowwds_40_tfcpjcontelram, AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, lV167Core_clientepjcontatowwds_42_tfcpjconwppnum, AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, lV169Core_clientepjcontatowwds_44_tfcpjconemail, AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, lV171Core_clientepjcontatowwds_46_tfcpjconlin, AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, lV173Core_clientepjcontatowwds_48_tfclinomefamiliar, AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, AV175Core_clientepjcontatowwds_50_tfclimatricula, AV176Core_clientepjcontatowwds_51_tfclimatricula_to, lV177Core_clientepjcontatowwds_52_tfcpjtiponome, AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, lV179Core_clientepjcontatowwds_54_tfcpjnomefan, AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc, AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, AV183Core_clientepjcontatowwds_58_tfcpjmatricula, AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to, lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat, AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, lV187Core_clientepjcontatowwds_62_tfcpjie, AV188Core_clientepjcontatowwds_63_tfcpjie_sel, lV189Core_clientepjcontatowwds_64_tfcpjcelnum, AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, lV191Core_clientepjcontatowwds_66_tfcpjtelnum, AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, lV193Core_clientepjcontatowwds_68_tfcpjtelram, AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, lV195Core_clientepjcontatowwds_70_tfcpjwppnum, AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, lV197Core_clientepjcontatowwds_72_tfcpjemail, AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, lV199Core_clientepjcontatowwds_74_tfcpjwebsite, AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_138_idx = 1;
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A365CpjTipoId = H004S2_A365CpjTipoId[0];
               A280CpjConGenSigla = H004S2_A280CpjConGenSigla[0];
               A270CpjConTipoID = H004S2_A270CpjConTipoID[0];
               A269CpjConSeq = H004S2_A269CpjConSeq[0];
               A166CpjID = H004S2_A166CpjID[0];
               A158CliID = H004S2_A158CliID[0];
               A265CpjWebsite = H004S2_A265CpjWebsite[0];
               n265CpjWebsite = H004S2_n265CpjWebsite[0];
               A266CpjEmail = H004S2_A266CpjEmail[0];
               n266CpjEmail = H004S2_n266CpjEmail[0];
               A264CpjWppNum = H004S2_A264CpjWppNum[0];
               n264CpjWppNum = H004S2_n264CpjWppNum[0];
               A262CpjTelRam = H004S2_A262CpjTelRam[0];
               n262CpjTelRam = H004S2_n262CpjTelRam[0];
               A261CpjTelNum = H004S2_A261CpjTelNum[0];
               n261CpjTelNum = H004S2_n261CpjTelNum[0];
               A263CpjCelNum = H004S2_A263CpjCelNum[0];
               n263CpjCelNum = H004S2_n263CpjCelNum[0];
               A189CpjIE = H004S2_A189CpjIE[0];
               A188CpjCNPJFormat = H004S2_A188CpjCNPJFormat[0];
               A176CpjMatricula = H004S2_A176CpjMatricula[0];
               A171CpjRazaoSoc = H004S2_A171CpjRazaoSoc[0];
               A170CpjNomeFan = H004S2_A170CpjNomeFan[0];
               A367CpjTipoNome = H004S2_A367CpjTipoNome[0];
               A159CliMatricula = H004S2_A159CliMatricula[0];
               A160CliNomeFamiliar = H004S2_A160CliNomeFamiliar[0];
               A288CpjConLIn = H004S2_A288CpjConLIn[0];
               n288CpjConLIn = H004S2_n288CpjConLIn[0];
               A287CpjConEmail = H004S2_A287CpjConEmail[0];
               n287CpjConEmail = H004S2_n287CpjConEmail[0];
               A286CpjConWppNum = H004S2_A286CpjConWppNum[0];
               n286CpjConWppNum = H004S2_n286CpjConWppNum[0];
               A284CpjConTelRam = H004S2_A284CpjConTelRam[0];
               n284CpjConTelRam = H004S2_n284CpjConTelRam[0];
               A283CpjConTelNum = H004S2_A283CpjConTelNum[0];
               n283CpjConTelNum = H004S2_n283CpjConTelNum[0];
               A285CpjConCelNum = H004S2_A285CpjConCelNum[0];
               n285CpjConCelNum = H004S2_n285CpjConCelNum[0];
               A281CpjConGenNome = H004S2_A281CpjConGenNome[0];
               A282CpjConNascimento = H004S2_A282CpjConNascimento[0];
               A274CpjConCPFFormat = H004S2_A274CpjConCPFFormat[0];
               A272CpjConTipoNome = H004S2_A272CpjConTipoNome[0];
               A277CpjConSobrenome = H004S2_A277CpjConSobrenome[0];
               A276CpjConNomePrim = H004S2_A276CpjConNomePrim[0];
               A275CpjConNome = H004S2_A275CpjConNome[0];
               A159CliMatricula = H004S2_A159CliMatricula[0];
               A160CliNomeFamiliar = H004S2_A160CliNomeFamiliar[0];
               A365CpjTipoId = H004S2_A365CpjTipoId[0];
               A265CpjWebsite = H004S2_A265CpjWebsite[0];
               n265CpjWebsite = H004S2_n265CpjWebsite[0];
               A266CpjEmail = H004S2_A266CpjEmail[0];
               n266CpjEmail = H004S2_n266CpjEmail[0];
               A264CpjWppNum = H004S2_A264CpjWppNum[0];
               n264CpjWppNum = H004S2_n264CpjWppNum[0];
               A262CpjTelRam = H004S2_A262CpjTelRam[0];
               n262CpjTelRam = H004S2_n262CpjTelRam[0];
               A261CpjTelNum = H004S2_A261CpjTelNum[0];
               n261CpjTelNum = H004S2_n261CpjTelNum[0];
               A263CpjCelNum = H004S2_A263CpjCelNum[0];
               n263CpjCelNum = H004S2_n263CpjCelNum[0];
               A189CpjIE = H004S2_A189CpjIE[0];
               A188CpjCNPJFormat = H004S2_A188CpjCNPJFormat[0];
               A176CpjMatricula = H004S2_A176CpjMatricula[0];
               A171CpjRazaoSoc = H004S2_A171CpjRazaoSoc[0];
               A170CpjNomeFan = H004S2_A170CpjNomeFan[0];
               A367CpjTipoNome = H004S2_A367CpjTipoNome[0];
               E294S2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 138;
            WB4S0( ) ;
         }
         bGXsfl_138_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4S2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV125Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV125Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV122IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV122IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV123IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV123IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONNOME", AV121IsAuthorized_CpjConNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONNOME", GetSecureSignedToken( "", AV121IsAuthorized_CpjConNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CPJCONTIPONOME", AV99IsAuthorized_CpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONTIPONOME", GetSecureSignedToken( "", AV99IsAuthorized_CpjConTipoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_CLIMATRICULA", AV100IsAuthorized_CliMatricula);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CLIMATRICULA", GetSecureSignedToken( "", AV100IsAuthorized_CliMatricula, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, A158CliID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CPJID"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, A166CpjID, context));
         GxWebStd.gx_hidden_field( context, "gxhash_CPJCONSEQ"+"_"+sGXsfl_138_idx, GetSecureSignedToken( sGXsfl_138_idx, context.localUtil.Format( (decimal)(A269CpjConSeq), "ZZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV124IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV124IsAuthorized_Insert, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nRecordCount/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV126Core_clientepjcontatowwds_1_filterfulltext ,
                                              AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                              AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                              AV129Core_clientepjcontatowwds_4_cpjconnome1 ,
                                              AV130Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                              AV131Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                              AV132Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                              AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                              AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                              AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                              AV136Core_clientepjcontatowwds_11_cpjconnome2 ,
                                              AV137Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                              AV138Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                              AV139Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                              AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                              AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                              AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                              AV143Core_clientepjcontatowwds_18_cpjconnome3 ,
                                              AV144Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                              AV145Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                              AV146Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                              AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                              AV147Core_clientepjcontatowwds_22_tfcpjconnome ,
                                              AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                              AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                              AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                              AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                              AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                              AV153Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                              AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                              AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                              AV157Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                              AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                              AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                              AV159Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                              AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                              AV161Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                              AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                              AV163Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                              AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                              AV165Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                              AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                              AV167Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                              AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                              AV169Core_clientepjcontatowwds_44_tfcpjconemail ,
                                              AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                              AV171Core_clientepjcontatowwds_46_tfcpjconlin ,
                                              AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                              AV173Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                              AV175Core_clientepjcontatowwds_50_tfclimatricula ,
                                              AV176Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                              AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                              AV177Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                              AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                              AV179Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                              AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                              AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                              AV183Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                              AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                              AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                              AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                              AV188Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                              AV187Core_clientepjcontatowwds_62_tfcpjie ,
                                              AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                              AV189Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                              AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                              AV191Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                              AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                              AV193Core_clientepjcontatowwds_68_tfcpjtelram ,
                                              AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                              AV195Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                              AV198Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                              AV197Core_clientepjcontatowwds_72_tfcpjemail ,
                                              AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                              AV199Core_clientepjcontatowwds_74_tfcpjwebsite ,
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
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.LONG,
                                              TypeConstants.LONG, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.LONG, TypeConstants.LONG, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV126Core_clientepjcontatowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext), "%", "");
         lV129Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV129Core_clientepjcontatowwds_4_cpjconnome1 = StringUtil.Concat( StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1), "%", "");
         lV130Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV130Core_clientepjcontatowwds_5_cpjtiponome1 = StringUtil.Concat( StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1), "%", "");
         lV131Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV131Core_clientepjcontatowwds_6_cpjcontiponome1 = StringUtil.Concat( StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1), "%", "");
         lV132Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV132Core_clientepjcontatowwds_7_cpjcongensigla1 = StringUtil.Concat( StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1), "%", "");
         lV136Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV136Core_clientepjcontatowwds_11_cpjconnome2 = StringUtil.Concat( StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2), "%", "");
         lV137Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV137Core_clientepjcontatowwds_12_cpjtiponome2 = StringUtil.Concat( StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2), "%", "");
         lV138Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV138Core_clientepjcontatowwds_13_cpjcontiponome2 = StringUtil.Concat( StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2), "%", "");
         lV139Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV139Core_clientepjcontatowwds_14_cpjcongensigla2 = StringUtil.Concat( StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2), "%", "");
         lV143Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV143Core_clientepjcontatowwds_18_cpjconnome3 = StringUtil.Concat( StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3), "%", "");
         lV144Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV144Core_clientepjcontatowwds_19_cpjtiponome3 = StringUtil.Concat( StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3), "%", "");
         lV145Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV145Core_clientepjcontatowwds_20_cpjcontiponome3 = StringUtil.Concat( StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3), "%", "");
         lV146Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV146Core_clientepjcontatowwds_21_cpjcongensigla3 = StringUtil.Concat( StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3), "%", "");
         lV147Core_clientepjcontatowwds_22_tfcpjconnome = StringUtil.Concat( StringUtil.RTrim( AV147Core_clientepjcontatowwds_22_tfcpjconnome), "%", "");
         lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = StringUtil.Concat( StringUtil.RTrim( AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim), "%", "");
         lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = StringUtil.Concat( StringUtil.RTrim( AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome), "%", "");
         lV153Core_clientepjcontatowwds_28_tfcpjcontiponome = StringUtil.Concat( StringUtil.RTrim( AV153Core_clientepjcontatowwds_28_tfcpjcontiponome), "%", "");
         lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = StringUtil.Concat( StringUtil.RTrim( AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat), "%", "");
         lV159Core_clientepjcontatowwds_34_tfcpjcongennome = StringUtil.Concat( StringUtil.RTrim( AV159Core_clientepjcontatowwds_34_tfcpjcongennome), "%", "");
         lV161Core_clientepjcontatowwds_36_tfcpjconcelnum = StringUtil.PadR( StringUtil.RTrim( AV161Core_clientepjcontatowwds_36_tfcpjconcelnum), 20, "%");
         lV163Core_clientepjcontatowwds_38_tfcpjcontelnum = StringUtil.PadR( StringUtil.RTrim( AV163Core_clientepjcontatowwds_38_tfcpjcontelnum), 20, "%");
         lV165Core_clientepjcontatowwds_40_tfcpjcontelram = StringUtil.Concat( StringUtil.RTrim( AV165Core_clientepjcontatowwds_40_tfcpjcontelram), "%", "");
         lV167Core_clientepjcontatowwds_42_tfcpjconwppnum = StringUtil.PadR( StringUtil.RTrim( AV167Core_clientepjcontatowwds_42_tfcpjconwppnum), 20, "%");
         lV169Core_clientepjcontatowwds_44_tfcpjconemail = StringUtil.Concat( StringUtil.RTrim( AV169Core_clientepjcontatowwds_44_tfcpjconemail), "%", "");
         lV171Core_clientepjcontatowwds_46_tfcpjconlin = StringUtil.Concat( StringUtil.RTrim( AV171Core_clientepjcontatowwds_46_tfcpjconlin), "%", "");
         lV173Core_clientepjcontatowwds_48_tfclinomefamiliar = StringUtil.Concat( StringUtil.RTrim( AV173Core_clientepjcontatowwds_48_tfclinomefamiliar), "%", "");
         lV177Core_clientepjcontatowwds_52_tfcpjtiponome = StringUtil.Concat( StringUtil.RTrim( AV177Core_clientepjcontatowwds_52_tfcpjtiponome), "%", "");
         lV179Core_clientepjcontatowwds_54_tfcpjnomefan = StringUtil.Concat( StringUtil.RTrim( AV179Core_clientepjcontatowwds_54_tfcpjnomefan), "%", "");
         lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = StringUtil.Concat( StringUtil.RTrim( AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc), "%", "");
         lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = StringUtil.Concat( StringUtil.RTrim( AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat), "%", "");
         lV187Core_clientepjcontatowwds_62_tfcpjie = StringUtil.Concat( StringUtil.RTrim( AV187Core_clientepjcontatowwds_62_tfcpjie), "%", "");
         lV189Core_clientepjcontatowwds_64_tfcpjcelnum = StringUtil.PadR( StringUtil.RTrim( AV189Core_clientepjcontatowwds_64_tfcpjcelnum), 20, "%");
         lV191Core_clientepjcontatowwds_66_tfcpjtelnum = StringUtil.PadR( StringUtil.RTrim( AV191Core_clientepjcontatowwds_66_tfcpjtelnum), 20, "%");
         lV193Core_clientepjcontatowwds_68_tfcpjtelram = StringUtil.Concat( StringUtil.RTrim( AV193Core_clientepjcontatowwds_68_tfcpjtelram), "%", "");
         lV195Core_clientepjcontatowwds_70_tfcpjwppnum = StringUtil.PadR( StringUtil.RTrim( AV195Core_clientepjcontatowwds_70_tfcpjwppnum), 20, "%");
         lV197Core_clientepjcontatowwds_72_tfcpjemail = StringUtil.Concat( StringUtil.RTrim( AV197Core_clientepjcontatowwds_72_tfcpjemail), "%", "");
         lV199Core_clientepjcontatowwds_74_tfcpjwebsite = StringUtil.Concat( StringUtil.RTrim( AV199Core_clientepjcontatowwds_74_tfcpjwebsite), "%", "");
         /* Using cursor H004S3 */
         pr_default.execute(1, new Object[] {lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV126Core_clientepjcontatowwds_1_filterfulltext, lV129Core_clientepjcontatowwds_4_cpjconnome1, lV129Core_clientepjcontatowwds_4_cpjconnome1, lV130Core_clientepjcontatowwds_5_cpjtiponome1, lV130Core_clientepjcontatowwds_5_cpjtiponome1, lV131Core_clientepjcontatowwds_6_cpjcontiponome1, lV131Core_clientepjcontatowwds_6_cpjcontiponome1, lV132Core_clientepjcontatowwds_7_cpjcongensigla1, lV132Core_clientepjcontatowwds_7_cpjcongensigla1, lV136Core_clientepjcontatowwds_11_cpjconnome2, lV136Core_clientepjcontatowwds_11_cpjconnome2, lV137Core_clientepjcontatowwds_12_cpjtiponome2, lV137Core_clientepjcontatowwds_12_cpjtiponome2, lV138Core_clientepjcontatowwds_13_cpjcontiponome2, lV138Core_clientepjcontatowwds_13_cpjcontiponome2, lV139Core_clientepjcontatowwds_14_cpjcongensigla2, lV139Core_clientepjcontatowwds_14_cpjcongensigla2, lV143Core_clientepjcontatowwds_18_cpjconnome3, lV143Core_clientepjcontatowwds_18_cpjconnome3, lV144Core_clientepjcontatowwds_19_cpjtiponome3, lV144Core_clientepjcontatowwds_19_cpjtiponome3, lV145Core_clientepjcontatowwds_20_cpjcontiponome3, lV145Core_clientepjcontatowwds_20_cpjcontiponome3, lV146Core_clientepjcontatowwds_21_cpjcongensigla3, lV146Core_clientepjcontatowwds_21_cpjcongensigla3, lV147Core_clientepjcontatowwds_22_tfcpjconnome, AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim, AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome, AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, lV153Core_clientepjcontatowwds_28_tfcpjcontiponome, AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat, AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, AV157Core_clientepjcontatowwds_32_tfcpjconnascimento, AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to, lV159Core_clientepjcontatowwds_34_tfcpjcongennome, AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, lV161Core_clientepjcontatowwds_36_tfcpjconcelnum, AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, lV163Core_clientepjcontatowwds_38_tfcpjcontelnum, AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, lV165Core_clientepjcontatowwds_40_tfcpjcontelram, AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, lV167Core_clientepjcontatowwds_42_tfcpjconwppnum, AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, lV169Core_clientepjcontatowwds_44_tfcpjconemail, AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, lV171Core_clientepjcontatowwds_46_tfcpjconlin, AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, lV173Core_clientepjcontatowwds_48_tfclinomefamiliar, AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, AV175Core_clientepjcontatowwds_50_tfclimatricula, AV176Core_clientepjcontatowwds_51_tfclimatricula_to, lV177Core_clientepjcontatowwds_52_tfcpjtiponome, AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, lV179Core_clientepjcontatowwds_54_tfcpjnomefan, AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc, AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, AV183Core_clientepjcontatowwds_58_tfcpjmatricula, AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to, lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat, AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, lV187Core_clientepjcontatowwds_62_tfcpjie, AV188Core_clientepjcontatowwds_63_tfcpjie_sel, lV189Core_clientepjcontatowwds_64_tfcpjcelnum, AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, lV191Core_clientepjcontatowwds_66_tfcpjtelnum, AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, lV193Core_clientepjcontatowwds_68_tfcpjtelram, AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, lV195Core_clientepjcontatowwds_70_tfcpjwppnum, AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, lV197Core_clientepjcontatowwds_72_tfcpjemail, AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, lV199Core_clientepjcontatowwds_74_tfcpjwebsite, AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel});
         GRID_nRecordCount = H004S3_AGRID_nRecordCount[0];
         pr_default.close(1);
         return (int)(GRID_nRecordCount) ;
      }

      protected int subGrid_fnc_Recordsperpage( )
      {
         if ( subGrid_Rows > 0 )
         {
            return subGrid_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGrid_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgrid_firstpage( )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( ( GRID_nRecordCount >= subGrid_fnc_Recordsperpage( ) ) && ( GRID_nEOF == 0 ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         if ( GRID_nFirstRecordOnPage >= subGrid_fnc_Recordsperpage( ) )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage-subGrid_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         GRID_nRecordCount = subGrid_fnc_Recordcount( );
         if ( GRID_nRecordCount > subGrid_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))) == 0 )
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-subGrid_fnc_Recordsperpage( ));
            }
            else
            {
               GRID_nFirstRecordOnPage = (long)(GRID_nRecordCount-((int)((GRID_nRecordCount) % (subGrid_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         if ( nPageNo > 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRID_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV125Pgmname = "core.ClientePJContatoWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E274S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV47ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV101AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV91DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV44ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_138 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_138"), ",", "."), 18, MidpointRounding.ToEven));
            AV95GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV96GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV97GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV62DDO_CpjConNascimentoAuxDate = context.localUtil.CToD( cgiGet( "vDDO_CPJCONNASCIMENTOAUXDATE"), 0);
            AV63DDO_CpjConNascimentoAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_CPJCONNASCIMENTOAUXDATETO"), 0);
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_managefilters_Icontype = cgiGet( "DDO_MANAGEFILTERS_Icontype");
            Ddo_managefilters_Icon = cgiGet( "DDO_MANAGEFILTERS_Icon");
            Ddo_managefilters_Tooltip = cgiGet( "DDO_MANAGEFILTERS_Tooltip");
            Ddo_managefilters_Cls = cgiGet( "DDO_MANAGEFILTERS_Cls");
            Gridpaginationbar_Class = cgiGet( "GRIDPAGINATIONBAR_Class");
            Gridpaginationbar_Showfirst = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showfirst"));
            Gridpaginationbar_Showprevious = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showprevious"));
            Gridpaginationbar_Shownext = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Shownext"));
            Gridpaginationbar_Showlast = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Showlast"));
            Gridpaginationbar_Pagestoshow = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Pagestoshow"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Pagingbuttonsposition = cgiGet( "GRIDPAGINATIONBAR_Pagingbuttonsposition");
            Gridpaginationbar_Pagingcaptionposition = cgiGet( "GRIDPAGINATIONBAR_Pagingcaptionposition");
            Gridpaginationbar_Emptygridclass = cgiGet( "GRIDPAGINATIONBAR_Emptygridclass");
            Gridpaginationbar_Rowsperpageselector = StringUtil.StrToBool( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselector"));
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Gridpaginationbar_Rowsperpageoptions = cgiGet( "GRIDPAGINATIONBAR_Rowsperpageoptions");
            Gridpaginationbar_First = cgiGet( "GRIDPAGINATIONBAR_First");
            Gridpaginationbar_Previous = cgiGet( "GRIDPAGINATIONBAR_Previous");
            Gridpaginationbar_Next = cgiGet( "GRIDPAGINATIONBAR_Next");
            Gridpaginationbar_Last = cgiGet( "GRIDPAGINATIONBAR_Last");
            Gridpaginationbar_Caption = cgiGet( "GRIDPAGINATIONBAR_Caption");
            Gridpaginationbar_Emptygridcaption = cgiGet( "GRIDPAGINATIONBAR_Emptygridcaption");
            Gridpaginationbar_Rowsperpagecaption = cgiGet( "GRIDPAGINATIONBAR_Rowsperpagecaption");
            Ddo_agexport_Icontype = cgiGet( "DDO_AGEXPORT_Icontype");
            Ddo_agexport_Icon = cgiGet( "DDO_AGEXPORT_Icon");
            Ddo_agexport_Caption = cgiGet( "DDO_AGEXPORT_Caption");
            Ddo_agexport_Cls = cgiGet( "DDO_AGEXPORT_Cls");
            Ddo_agexport_Titlecontrolidtoreplace = cgiGet( "DDO_AGEXPORT_Titlecontrolidtoreplace");
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Caption = cgiGet( "DDC_SUBSCRIPTIONS_Caption");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Titlecontrolidtoreplace = cgiGet( "DDC_SUBSCRIPTIONS_Titlecontrolidtoreplace");
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Filteredtext_set = cgiGet( "DDO_GRID_Filteredtext_set");
            Ddo_grid_Filteredtextto_set = cgiGet( "DDO_GRID_Filteredtextto_set");
            Ddo_grid_Selectedvalue_set = cgiGet( "DDO_GRID_Selectedvalue_set");
            Ddo_grid_Gamoauthtoken = cgiGet( "DDO_GRID_Gamoauthtoken");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Includesortasc = cgiGet( "DDO_GRID_Includesortasc");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_grid_Sortedstatus = cgiGet( "DDO_GRID_Sortedstatus");
            Ddo_grid_Includefilter = cgiGet( "DDO_GRID_Includefilter");
            Ddo_grid_Filtertype = cgiGet( "DDO_GRID_Filtertype");
            Ddo_grid_Filterisrange = cgiGet( "DDO_GRID_Filterisrange");
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_grid_Format = cgiGet( "DDO_GRID_Format");
            Innewwindow1_Width = cgiGet( "INNEWWINDOW1_Width");
            Innewwindow1_Height = cgiGet( "INNEWWINDOW1_Height");
            Innewwindow1_Target = cgiGet( "INNEWWINDOW1_Target");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_titlescategories_Gridinternalname = cgiGet( "GRID_TITLESCATEGORIES_Gridinternalname");
            Grid_titlescategories_Gridtitlescategories = cgiGet( "GRID_TITLESCATEGORIES_Gridtitlescategories");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hascategories = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascategories"));
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersselector1.Name = cmbavDynamicfiltersselector1_Internalname;
            cmbavDynamicfiltersselector1.CurrentValue = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AV18DynamicFiltersSelector1 = cgiGet( cmbavDynamicfiltersselector1_Internalname);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            cmbavDynamicfiltersoperator1.Name = cmbavDynamicfiltersoperator1_Internalname;
            cmbavDynamicfiltersoperator1.CurrentValue = cgiGet( cmbavDynamicfiltersoperator1_Internalname);
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator1_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AV20CpjConNome1 = StringUtil.Upper( cgiGet( edtavCpjconnome1_Internalname));
            AssignAttri("", false, "AV20CpjConNome1", AV20CpjConNome1);
            AV21CpjTipoNome1 = StringUtil.Upper( cgiGet( edtavCpjtiponome1_Internalname));
            AssignAttri("", false, "AV21CpjTipoNome1", AV21CpjTipoNome1);
            AV22CpjConTipoNome1 = StringUtil.Upper( cgiGet( edtavCpjcontiponome1_Internalname));
            AssignAttri("", false, "AV22CpjConTipoNome1", AV22CpjConTipoNome1);
            AV23CpjConGenSigla1 = cgiGet( edtavCpjcongensigla1_Internalname);
            AssignAttri("", false, "AV23CpjConGenSigla1", AV23CpjConGenSigla1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV25DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV26DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
            AV27CpjConNome2 = StringUtil.Upper( cgiGet( edtavCpjconnome2_Internalname));
            AssignAttri("", false, "AV27CpjConNome2", AV27CpjConNome2);
            AV28CpjTipoNome2 = StringUtil.Upper( cgiGet( edtavCpjtiponome2_Internalname));
            AssignAttri("", false, "AV28CpjTipoNome2", AV28CpjTipoNome2);
            AV29CpjConTipoNome2 = StringUtil.Upper( cgiGet( edtavCpjcontiponome2_Internalname));
            AssignAttri("", false, "AV29CpjConTipoNome2", AV29CpjConTipoNome2);
            AV30CpjConGenSigla2 = cgiGet( edtavCpjcongensigla2_Internalname);
            AssignAttri("", false, "AV30CpjConGenSigla2", AV30CpjConGenSigla2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV32DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AV34CpjConNome3 = StringUtil.Upper( cgiGet( edtavCpjconnome3_Internalname));
            AssignAttri("", false, "AV34CpjConNome3", AV34CpjConNome3);
            AV35CpjTipoNome3 = StringUtil.Upper( cgiGet( edtavCpjtiponome3_Internalname));
            AssignAttri("", false, "AV35CpjTipoNome3", AV35CpjTipoNome3);
            AV36CpjConTipoNome3 = StringUtil.Upper( cgiGet( edtavCpjcontiponome3_Internalname));
            AssignAttri("", false, "AV36CpjConTipoNome3", AV36CpjConTipoNome3);
            AV37CpjConGenSigla3 = cgiGet( edtavCpjcongensigla3_Internalname);
            AssignAttri("", false, "AV37CpjConGenSigla3", AV37CpjConGenSigla3);
            AV64DDO_CpjConNascimentoAuxDateText = cgiGet( edtavDdo_cpjconnascimentoauxdatetext_Internalname);
            AssignAttri("", false, "AV64DDO_CpjConNascimentoAuxDateText", AV64DDO_CpjConNascimentoAuxDateText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR1"), AV18DynamicFiltersSelector1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR1"), ",", ".") != Convert.ToDecimal( AV19DynamicFiltersOperator1 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME1"), AV20CpjConNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME1"), AV21CpjTipoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME1"), AV22CpjConTipoNome1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA1"), AV23CpjConGenSigla1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV25DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV26DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME2"), AV27CpjConNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME2"), AV28CpjTipoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME2"), AV29CpjConTipoNome2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA2"), AV30CpjConGenSigla2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV32DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV33DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONNOME3"), AV34CpjConNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJTIPONOME3"), AV35CpjTipoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONTIPONOME3"), AV36CpjConTipoNome3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vCPJCONGENSIGLA3"), AV37CpjConGenSigla3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E274S2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E274S2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFCPJCONNASCIMENTO_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_cpjconnascimentoauxdatetext_Internalname});
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         Grid_titlescategories_Gridinternalname = subGrid_Internalname;
         ucGrid_titlescategories.SendProperty(context, "", false, Grid_titlescategories_Internalname, "GridInternalName", Grid_titlescategories_Gridinternalname);
         if ( StringUtil.StrCmp(AV8HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV18DynamicFiltersSelector1 = "CPJCONNOME";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersSelector2 = "CPJCONNOME";
         AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV32DynamicFiltersSelector3 = "CPJCONNOME";
         AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         imgAdddynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Jsonclick", imgAdddynamicfilters1_Jsonclick, true);
         imgRemovedynamicfilters1_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Jsonclick", imgRemovedynamicfilters1_Jsonclick, true);
         imgAdddynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Jsonclick", imgAdddynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters2_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Jsonclick", imgRemovedynamicfilters2_Jsonclick, true);
         imgRemovedynamicfilters3_Jsonclick = StringUtil.Format( "WWPDynFilterHideLast_AL('%1', 3, 0)", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
         AssignProp("", false, imgRemovedynamicfilters3_Internalname, "Jsonclick", imgRemovedynamicfilters3_Jsonclick, true);
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV101AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV102AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV102AGExportDataItem.gxTpr_Title = "Excel";
         AV102AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV102AGExportDataItem.gxTpr_Eventkey = "Export";
         AV102AGExportDataItem.gxTpr_Isdivider = false;
         AV101AGExportData.Add(AV102AGExportDataItem, 0);
         AV102AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV102AGExportDataItem.gxTpr_Title = "PDF";
         AV102AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV102AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV102AGExportDataItem.gxTpr_Isdivider = false;
         AV101AGExportData.Add(AV102AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV121IsAuthorized_CpjConNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontatoview_Execute", out  GXt_boolean1) ;
         AV121IsAuthorized_CpjConNome = GXt_boolean1;
         AssignAttri("", false, "AV121IsAuthorized_CpjConNome", AV121IsAuthorized_CpjConNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONNOME", GetSecureSignedToken( "", AV121IsAuthorized_CpjConNome, context));
         GXt_boolean1 = AV99IsAuthorized_CpjConTipoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjtipoview_Execute", out  GXt_boolean1) ;
         AV99IsAuthorized_CpjConTipoNome = GXt_boolean1;
         AssignAttri("", false, "AV99IsAuthorized_CpjConTipoNome", AV99IsAuthorized_CpjConTipoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CPJCONTIPONOME", GetSecureSignedToken( "", AV99IsAuthorized_CpjConTipoNome, context));
         GXt_boolean1 = AV100IsAuthorized_CliMatricula;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clienteview_Execute", out  GXt_boolean1) ;
         AV100IsAuthorized_CliMatricula = GXt_boolean1;
         AssignAttri("", false, "AV100IsAuthorized_CliMatricula", AV100IsAuthorized_CliMatricula);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_CLIMATRICULA", GetSecureSignedToken( "", AV100IsAuthorized_CliMatricula, context));
         AV92GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV93GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV92GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Contato";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV14OrderedBy < 1 )
         {
            AV14OrderedBy = 1;
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV91DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV91DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E284S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S182 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV49ManageFiltersExecutionStep == 1 )
         {
            AV49ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV49ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV49ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV49ManageFiltersExecutionStep == 2 )
         {
            AV49ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV49ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV49ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         cmbavDynamicfiltersoperator1.removeAllItems();
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONNOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJTIPONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 )
         {
            cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
            cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         }
         if ( AV24DynamicFiltersEnabled2 )
         {
            cmbavDynamicfiltersoperator2.removeAllItems();
            if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONNOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJTIPONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 )
            {
               cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
               cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
            }
            if ( AV31DynamicFiltersEnabled3 )
            {
               cmbavDynamicfiltersoperator3.removeAllItems();
               if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONNOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJTIPONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
               else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 )
               {
                  cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
                  cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
               }
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV46Session.Get("core.ClientePJContatoWWColumnsSelector"), "") != 0 )
         {
            AV42ColumnsSelectorXML = AV46Session.Get("core.ClientePJContatoWWColumnsSelector");
            AV44ColumnsSelector.FromXml(AV42ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtCpjConNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConNomePrim_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConNomePrim_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConNomePrim_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConSobrenome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConSobrenome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConSobrenome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConTipoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTipoNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConCPFFormat_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(5)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConCPFFormat_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConCPFFormat_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConNascimento_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(6)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConNascimento_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConNascimento_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConGenNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(7)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConGenNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConGenNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConCelNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(8)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConCelNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConCelNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConTelNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(9)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConTelNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTelNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConTelRam_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(10)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConTelRam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConTelRam_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConWppNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(11)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConWppNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConWppNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(12)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConEmail_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjConLIn_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(13)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjConLIn_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjConLIn_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCliNomeFamiliar_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(14)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCliMatricula_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(15)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCliMatricula_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjTipoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(16)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjTipoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTipoNome_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjNomeFan_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(17)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjNomeFan_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjNomeFan_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjRazaoSoc_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(18)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjRazaoSoc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjRazaoSoc_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjMatricula_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(19)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjMatricula_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjMatricula_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjCNPJFormat_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(20)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjCNPJFormat_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjCNPJFormat_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjIE_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(21)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjIE_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjIE_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjCelNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(22)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjCelNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjCelNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjTelNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(23)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjTelNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTelNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjTelRam_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(24)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjTelRam_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjTelRam_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjWppNum_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(25)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjWppNum_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjWppNum_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjEmail_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(26)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjEmail_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjEmail_Visible), 5, 0), !bGXsfl_138_Refreshing);
         edtCpjWebsite_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV44ColumnsSelector.gxTpr_Columns.Item(27)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtCpjWebsite_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCpjWebsite_Visible), 5, 0), !bGXsfl_138_Refreshing);
         AV95GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV95GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV95GridCurrentPage), 10, 0));
         AV96GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV96GridPageCount", StringUtil.LTrimStr( (decimal)(AV96GridPageCount), 10, 0));
         GXt_char3 = AV97GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV125Pgmname, out  GXt_char3) ;
         AV97GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV97GridAppliedFilters", AV97GridAppliedFilters);
         AV126Core_clientepjcontatowwds_1_filterfulltext = AV17FilterFullText;
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = AV20CpjConNome1;
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = AV21CpjTipoNome1;
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = AV22CpjConTipoNome1;
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = AV23CpjConGenSigla1;
         AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 = AV24DynamicFiltersEnabled2;
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = AV25DynamicFiltersSelector2;
         AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 = AV26DynamicFiltersOperator2;
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = AV27CpjConNome2;
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = AV28CpjTipoNome2;
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = AV29CpjConTipoNome2;
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = AV30CpjConGenSigla2;
         AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 = AV31DynamicFiltersEnabled3;
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = AV32DynamicFiltersSelector3;
         AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 = AV33DynamicFiltersOperator3;
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = AV34CpjConNome3;
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = AV35CpjTipoNome3;
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = AV36CpjConTipoNome3;
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = AV37CpjConGenSigla3;
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = AV50TFCpjConNome;
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = AV51TFCpjConNome_Sel;
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = AV52TFCpjConNomePrim;
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = AV53TFCpjConNomePrim_Sel;
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = AV54TFCpjConSobrenome;
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = AV55TFCpjConSobrenome_Sel;
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = AV56TFCpjConTipoNome;
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = AV57TFCpjConTipoNome_Sel;
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = AV58TFCpjConCPFFormat;
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = AV59TFCpjConCPFFormat_Sel;
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = AV60TFCpjConNascimento;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = AV61TFCpjConNascimento_To;
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = AV65TFCpjConGenNome;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = AV66TFCpjConGenNome_Sel;
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = AV67TFCpjConCelNum;
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = AV68TFCpjConCelNum_Sel;
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = AV69TFCpjConTelNum;
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = AV70TFCpjConTelNum_Sel;
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = AV71TFCpjConTelRam;
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = AV72TFCpjConTelRam_Sel;
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = AV89TFCpjConWppNum;
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = AV90TFCpjConWppNum_Sel;
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = AV73TFCpjConEmail;
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = AV74TFCpjConEmail_Sel;
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = AV75TFCpjConLIn;
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = AV76TFCpjConLIn_Sel;
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = AV79TFCliNomeFamiliar;
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = AV80TFCliNomeFamiliar_Sel;
         AV175Core_clientepjcontatowwds_50_tfclimatricula = AV77TFCliMatricula;
         AV176Core_clientepjcontatowwds_51_tfclimatricula_to = AV78TFCliMatricula_To;
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = AV81TFCpjTipoNome;
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = AV82TFCpjTipoNome_Sel;
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = AV83TFCpjNomeFan;
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = AV84TFCpjNomeFan_Sel;
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = AV85TFCpjRazaoSoc;
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = AV86TFCpjRazaoSoc_Sel;
         AV183Core_clientepjcontatowwds_58_tfcpjmatricula = AV103TFCpjMatricula;
         AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to = AV104TFCpjMatricula_To;
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = AV105TFCpjCNPJFormat;
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = AV106TFCpjCNPJFormat_Sel;
         AV187Core_clientepjcontatowwds_62_tfcpjie = AV107TFCpjIE;
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = AV108TFCpjIE_Sel;
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = AV109TFCpjCelNum;
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = AV110TFCpjCelNum_Sel;
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = AV111TFCpjTelNum;
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = AV112TFCpjTelNum_Sel;
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = AV113TFCpjTelRam;
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = AV114TFCpjTelRam_Sel;
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = AV115TFCpjWppNum;
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = AV116TFCpjWppNum_Sel;
         AV197Core_clientepjcontatowwds_72_tfcpjemail = AV117TFCpjEmail;
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = AV118TFCpjEmail_Sel;
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = AV119TFCpjWebsite;
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = AV120TFCpjWebsite_Sel;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124S2( )
      {
         /* Gridpaginationbar_Changepage Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Previous") == 0 )
         {
            subgrid_previouspage( ) ;
         }
         else if ( StringUtil.StrCmp(Gridpaginationbar_Selectedpage, "Next") == 0 )
         {
            subgrid_nextpage( ) ;
         }
         else
         {
            AV94PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV94PageToGo) ;
         }
      }

      protected void E134S2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E164S2( )
      {
         /* Ddo_grid_Onoptionclicked Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderASC#>") == 0 ) || ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>") == 0 ) )
         {
            AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( Ddo_grid_Selectedvalue_get, "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
            AV15OrderedDsc = ((StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#OrderDSC#>")==0) ? true : false);
            AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
            /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConNome") == 0 )
            {
               AV50TFCpjConNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFCpjConNome", AV50TFCpjConNome);
               AV51TFCpjConNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFCpjConNome_Sel", AV51TFCpjConNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConNomePrim") == 0 )
            {
               AV52TFCpjConNomePrim = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV52TFCpjConNomePrim", AV52TFCpjConNomePrim);
               AV53TFCpjConNomePrim_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV53TFCpjConNomePrim_Sel", AV53TFCpjConNomePrim_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConSobrenome") == 0 )
            {
               AV54TFCpjConSobrenome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV54TFCpjConSobrenome", AV54TFCpjConSobrenome);
               AV55TFCpjConSobrenome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV55TFCpjConSobrenome_Sel", AV55TFCpjConSobrenome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConTipoNome") == 0 )
            {
               AV56TFCpjConTipoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV56TFCpjConTipoNome", AV56TFCpjConTipoNome);
               AV57TFCpjConTipoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV57TFCpjConTipoNome_Sel", AV57TFCpjConTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConCPFFormat") == 0 )
            {
               AV58TFCpjConCPFFormat = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV58TFCpjConCPFFormat", AV58TFCpjConCPFFormat);
               AV59TFCpjConCPFFormat_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV59TFCpjConCPFFormat_Sel", AV59TFCpjConCPFFormat_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConNascimento") == 0 )
            {
               AV60TFCpjConNascimento = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV60TFCpjConNascimento", context.localUtil.Format(AV60TFCpjConNascimento, "99/99/99"));
               AV61TFCpjConNascimento_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV61TFCpjConNascimento_To", context.localUtil.Format(AV61TFCpjConNascimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConGenNome") == 0 )
            {
               AV65TFCpjConGenNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV65TFCpjConGenNome", AV65TFCpjConGenNome);
               AV66TFCpjConGenNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV66TFCpjConGenNome_Sel", AV66TFCpjConGenNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConCelNum") == 0 )
            {
               AV67TFCpjConCelNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV67TFCpjConCelNum", AV67TFCpjConCelNum);
               AV68TFCpjConCelNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV68TFCpjConCelNum_Sel", AV68TFCpjConCelNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConTelNum") == 0 )
            {
               AV69TFCpjConTelNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV69TFCpjConTelNum", AV69TFCpjConTelNum);
               AV70TFCpjConTelNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV70TFCpjConTelNum_Sel", AV70TFCpjConTelNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConTelRam") == 0 )
            {
               AV71TFCpjConTelRam = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV71TFCpjConTelRam", AV71TFCpjConTelRam);
               AV72TFCpjConTelRam_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV72TFCpjConTelRam_Sel", AV72TFCpjConTelRam_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConWppNum") == 0 )
            {
               AV89TFCpjConWppNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV89TFCpjConWppNum", AV89TFCpjConWppNum);
               AV90TFCpjConWppNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV90TFCpjConWppNum_Sel", AV90TFCpjConWppNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConEmail") == 0 )
            {
               AV73TFCpjConEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV73TFCpjConEmail", AV73TFCpjConEmail);
               AV74TFCpjConEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV74TFCpjConEmail_Sel", AV74TFCpjConEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjConLIn") == 0 )
            {
               AV75TFCpjConLIn = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV75TFCpjConLIn", AV75TFCpjConLIn);
               AV76TFCpjConLIn_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV76TFCpjConLIn_Sel", AV76TFCpjConLIn_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliNomeFamiliar") == 0 )
            {
               AV79TFCliNomeFamiliar = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV79TFCliNomeFamiliar", AV79TFCliNomeFamiliar);
               AV80TFCliNomeFamiliar_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV80TFCliNomeFamiliar_Sel", AV80TFCliNomeFamiliar_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CliMatricula") == 0 )
            {
               AV77TFCliMatricula = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV77TFCliMatricula", StringUtil.LTrimStr( (decimal)(AV77TFCliMatricula), 12, 0));
               AV78TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV78TFCliMatricula_To", StringUtil.LTrimStr( (decimal)(AV78TFCliMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjTipoNome") == 0 )
            {
               AV81TFCpjTipoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV81TFCpjTipoNome", AV81TFCpjTipoNome);
               AV82TFCpjTipoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV82TFCpjTipoNome_Sel", AV82TFCpjTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjNomeFan") == 0 )
            {
               AV83TFCpjNomeFan = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV83TFCpjNomeFan", AV83TFCpjNomeFan);
               AV84TFCpjNomeFan_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV84TFCpjNomeFan_Sel", AV84TFCpjNomeFan_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjRazaoSoc") == 0 )
            {
               AV85TFCpjRazaoSoc = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV85TFCpjRazaoSoc", AV85TFCpjRazaoSoc);
               AV86TFCpjRazaoSoc_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV86TFCpjRazaoSoc_Sel", AV86TFCpjRazaoSoc_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjMatricula") == 0 )
            {
               AV103TFCpjMatricula = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFCpjMatricula", StringUtil.LTrimStr( (decimal)(AV103TFCpjMatricula), 12, 0));
               AV104TFCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV104TFCpjMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjCNPJFormat") == 0 )
            {
               AV105TFCpjCNPJFormat = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV105TFCpjCNPJFormat", AV105TFCpjCNPJFormat);
               AV106TFCpjCNPJFormat_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV106TFCpjCNPJFormat_Sel", AV106TFCpjCNPJFormat_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjIE") == 0 )
            {
               AV107TFCpjIE = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV107TFCpjIE", AV107TFCpjIE);
               AV108TFCpjIE_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV108TFCpjIE_Sel", AV108TFCpjIE_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjCelNum") == 0 )
            {
               AV109TFCpjCelNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV109TFCpjCelNum", AV109TFCpjCelNum);
               AV110TFCpjCelNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV110TFCpjCelNum_Sel", AV110TFCpjCelNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjTelNum") == 0 )
            {
               AV111TFCpjTelNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV111TFCpjTelNum", AV111TFCpjTelNum);
               AV112TFCpjTelNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV112TFCpjTelNum_Sel", AV112TFCpjTelNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjTelRam") == 0 )
            {
               AV113TFCpjTelRam = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV113TFCpjTelRam", AV113TFCpjTelRam);
               AV114TFCpjTelRam_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV114TFCpjTelRam_Sel", AV114TFCpjTelRam_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjWppNum") == 0 )
            {
               AV115TFCpjWppNum = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV115TFCpjWppNum", AV115TFCpjWppNum);
               AV116TFCpjWppNum_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV116TFCpjWppNum_Sel", AV116TFCpjWppNum_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjEmail") == 0 )
            {
               AV117TFCpjEmail = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV117TFCpjEmail", AV117TFCpjEmail);
               AV118TFCpjEmail_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV118TFCpjEmail_Sel", AV118TFCpjEmail_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "CpjWebsite") == 0 )
            {
               AV119TFCpjWebsite = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV119TFCpjWebsite", AV119TFCpjWebsite);
               AV120TFCpjWebsite_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV120TFCpjWebsite_Sel", AV120TFCpjWebsite_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E294S2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV122IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV123IsAuthorized_Delete )
         {
            cmbavGridactions.addItem("2", StringUtil.Format( "%1;%2", "Excluir", "fa fa-times", "", "", "", "", "", "", ""), 0);
         }
         if ( cmbavGridactions.ItemCount == 1 )
         {
            cmbavGridactions_Class = "Invisible";
         }
         else
         {
            cmbavGridactions_Class = "ConvertToDDO";
         }
         if ( AV121IsAuthorized_CpjConNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontatoview.aspx"+UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCpjConNome_Link = formatLink("core.clientepjcontatoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV99IsAuthorized_CpjConTipoNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjtipoview.aspx"+UrlEncode(StringUtil.LTrimStr(A270CpjConTipoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCpjConTipoNome_Link = formatLink("core.clientepjtipoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         edtCpjConLIn_Linktarget = "_blank";
         edtCpjConLIn_Link = A288CpjConLIn;
         if ( AV100IsAuthorized_CliMatricula )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clienteview.aspx"+UrlEncode(A158CliID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtCliMatricula_Link = formatLink("core.clienteview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         edtCpjWebsite_Linktarget = "_blank";
         edtCpjWebsite_Link = A265CpjWebsite;
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 138;
         }
         sendrow_1382( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_138_Refreshing )
         {
            DoAjaxLoad(138, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0));
      }

      protected void E174S2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV42ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV44ColumnsSelector.FromJSonString(AV42ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.ClientePJContatoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV42ColumnsSelectorXML)) ? "" : AV44ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E224S2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV24DynamicFiltersEnabled2", AV24DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E184S2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV38DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         AV39DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV39DynamicFiltersIgnoreFirst", AV39DynamicFiltersIgnoreFirst);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         AV39DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV39DynamicFiltersIgnoreFirst", AV39DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
      }

      protected void E234S2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
      }

      protected void E244S2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV31DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E194S2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV38DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         AV24DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled2", AV24DynamicFiltersEnabled2);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
      }

      protected void E254S2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         AV26DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
      }

      protected void E204S2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV38DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         AV31DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV38DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV38DynamicFiltersRemoving", AV38DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20CpjConNome1, AV21CpjTipoNome1, AV22CpjConTipoNome1, AV23CpjConGenSigla1, AV25DynamicFiltersSelector2, AV26DynamicFiltersOperator2, AV27CpjConNome2, AV28CpjTipoNome2, AV29CpjConTipoNome2, AV30CpjConGenSigla2, AV32DynamicFiltersSelector3, AV33DynamicFiltersOperator3, AV34CpjConNome3, AV35CpjTipoNome3, AV36CpjConTipoNome3, AV37CpjConGenSigla3, AV49ManageFiltersExecutionStep, AV24DynamicFiltersEnabled2, AV31DynamicFiltersEnabled3, AV44ColumnsSelector, AV125Pgmname, AV50TFCpjConNome, AV51TFCpjConNome_Sel, AV52TFCpjConNomePrim, AV53TFCpjConNomePrim_Sel, AV54TFCpjConSobrenome, AV55TFCpjConSobrenome_Sel, AV56TFCpjConTipoNome, AV57TFCpjConTipoNome_Sel, AV58TFCpjConCPFFormat, AV59TFCpjConCPFFormat_Sel, AV60TFCpjConNascimento, AV61TFCpjConNascimento_To, AV65TFCpjConGenNome, AV66TFCpjConGenNome_Sel, AV67TFCpjConCelNum, AV68TFCpjConCelNum_Sel, AV69TFCpjConTelNum, AV70TFCpjConTelNum_Sel, AV71TFCpjConTelRam, AV72TFCpjConTelRam_Sel, AV89TFCpjConWppNum, AV90TFCpjConWppNum_Sel, AV73TFCpjConEmail, AV74TFCpjConEmail_Sel, AV75TFCpjConLIn, AV76TFCpjConLIn_Sel, AV79TFCliNomeFamiliar, AV80TFCliNomeFamiliar_Sel, AV77TFCliMatricula, AV78TFCliMatricula_To, AV81TFCpjTipoNome, AV82TFCpjTipoNome_Sel, AV83TFCpjNomeFan, AV84TFCpjNomeFan_Sel, AV85TFCpjRazaoSoc, AV86TFCpjRazaoSoc_Sel, AV103TFCpjMatricula, AV104TFCpjMatricula_To, AV105TFCpjCNPJFormat, AV106TFCpjCNPJFormat_Sel, AV107TFCpjIE, AV108TFCpjIE_Sel, AV109TFCpjCelNum, AV110TFCpjCelNum_Sel, AV111TFCpjTelNum, AV112TFCpjTelNum_Sel, AV113TFCpjTelRam, AV114TFCpjTelRam_Sel, AV115TFCpjWppNum, AV116TFCpjWppNum_Sel, AV117TFCpjEmail, AV118TFCpjEmail_Sel, AV119TFCpjWebsite, AV120TFCpjWebsite_Sel, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV39DynamicFiltersIgnoreFirst, AV38DynamicFiltersRemoving, AV122IsAuthorized_Update, AV123IsAuthorized_Delete, AV121IsAuthorized_CpjConNome, AV99IsAuthorized_CpjConTipoNome, AV100IsAuthorized_CliMatricula, AV124IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
      }

      protected void E264S2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         AV33DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E114S2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S242 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S192 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.ClientePJContatoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV125Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV49ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV49ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV49ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.ClientePJContatoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV49ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV49ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV49ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV48ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.ClientePJContatoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV48ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV48ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S242 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV125Pgmname+"GridState",  AV48ManageFiltersXml) ;
               AV11GridState.FromXml(AV48ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S172 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S252 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
               S232 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
      }

      protected void E304S2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV98GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV98GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV98GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV98GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E214S2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV124IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(Guid.Empty.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(0,1,0));
            CallWebObject(formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV44ColumnsSelector", AV44ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV47ManageFiltersData", AV47ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E144S2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S282 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV25DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV32DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E154S2( )
      {
         /* Ddc_subscriptions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.subscriptions.wwp_subscriptionspanel", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Subscriptions.WWP_SubscriptionsPanel";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0185",(string)"",(string)"ClientePJContato",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0185"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S172( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S202( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV44ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConNomePrim",  "",  "Primeiro Nome",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConSobrenome",  "",  "Sobrenome",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConTipoNome",  "",  "Tipo do Contato",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConCPFFormat",  "",  "CPF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConNascimento",  "",  "Dt. Nascimento",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConGenNome",  "",  "Gênero",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConCelNum",  "",  "Celular",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConTelNum",  "",  "Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConTelRam",  "",  "Ramal",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConWppNum",  "",  "WhatsApp",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConEmail",  "",  "E-mail",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjConLIn",  "",  "LinkedIn",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CliNomeFamiliar",  "Cliente",  "Nome Familiar",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CliMatricula",  "Cliente",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjTipoNome",  "Unidade",  "Tipo",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjNomeFan",  "Unidade",  "Nome Fantasia",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjRazaoSoc",  "Unidade",  "Razão Social",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjMatricula",  "Unidade",  "Matrícula",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjCNPJFormat",  "Unidade",  "CNPJ",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjIE",  "Unidade",  "IE",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjCelNum",  "Unidade",  "Celular",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjTelNum",  "Unidade",  "Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjTelRam",  "Unidade",  "Ramal do Telefone",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjWppNum",  "Unidade",  "WhatsApp",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjEmail",  "Unidade",  "E-mail",  false,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV44ColumnsSelector,  "CpjWebsite",  "Unidade",  "Website",  false,  "") ;
         GXt_char3 = AV43UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ClientePJContatoWWColumnsSelector", out  GXt_char3) ;
         AV43UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV43UserCustomValue)) ) )
         {
            AV45ColumnsSelectorAux.FromXml(AV43UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV45ColumnsSelectorAux, ref  AV44ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV122IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontato_Update", out  GXt_boolean1) ;
         AV122IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV122IsAuthorized_Update", AV122IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV122IsAuthorized_Update, context));
         GXt_boolean1 = AV123IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontato_Delete", out  GXt_boolean1) ;
         AV123IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV123IsAuthorized_Delete", AV123IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV123IsAuthorized_Delete, context));
         GXt_boolean1 = AV124IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "clientepjcontato_Insert", out  GXt_boolean1) ;
         AV124IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV124IsAuthorized_Insert", AV124IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV124IsAuthorized_Insert, context));
         if ( ! ( AV124IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ClientePJContato",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavCpjconnome1_Visible = 0;
         AssignProp("", false, edtavCpjconnome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome1_Visible), 5, 0), true);
         edtavCpjtiponome1_Visible = 0;
         AssignProp("", false, edtavCpjtiponome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome1_Visible), 5, 0), true);
         edtavCpjcontiponome1_Visible = 0;
         AssignProp("", false, edtavCpjcontiponome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome1_Visible), 5, 0), true);
         edtavCpjcongensigla1_Visible = 0;
         AssignProp("", false, edtavCpjcongensigla1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONNOME") == 0 )
         {
            edtavCpjconnome1_Visible = 1;
            AssignProp("", false, edtavCpjconnome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJTIPONOME") == 0 )
         {
            edtavCpjtiponome1_Visible = 1;
            AssignProp("", false, edtavCpjtiponome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 )
         {
            edtavCpjcontiponome1_Visible = 1;
            AssignProp("", false, edtavCpjcontiponome1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 )
         {
            edtavCpjcongensigla1_Visible = 1;
            AssignProp("", false, edtavCpjcongensigla1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavCpjconnome2_Visible = 0;
         AssignProp("", false, edtavCpjconnome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome2_Visible), 5, 0), true);
         edtavCpjtiponome2_Visible = 0;
         AssignProp("", false, edtavCpjtiponome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome2_Visible), 5, 0), true);
         edtavCpjcontiponome2_Visible = 0;
         AssignProp("", false, edtavCpjcontiponome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome2_Visible), 5, 0), true);
         edtavCpjcongensigla2_Visible = 0;
         AssignProp("", false, edtavCpjcongensigla2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONNOME") == 0 )
         {
            edtavCpjconnome2_Visible = 1;
            AssignProp("", false, edtavCpjconnome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJTIPONOME") == 0 )
         {
            edtavCpjtiponome2_Visible = 1;
            AssignProp("", false, edtavCpjtiponome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 )
         {
            edtavCpjcontiponome2_Visible = 1;
            AssignProp("", false, edtavCpjcontiponome2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 )
         {
            edtavCpjcongensigla2_Visible = 1;
            AssignProp("", false, edtavCpjcongensigla2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavCpjconnome3_Visible = 0;
         AssignProp("", false, edtavCpjconnome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome3_Visible), 5, 0), true);
         edtavCpjtiponome3_Visible = 0;
         AssignProp("", false, edtavCpjtiponome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome3_Visible), 5, 0), true);
         edtavCpjcontiponome3_Visible = 0;
         AssignProp("", false, edtavCpjcontiponome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome3_Visible), 5, 0), true);
         edtavCpjcongensigla3_Visible = 0;
         AssignProp("", false, edtavCpjcongensigla3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONNOME") == 0 )
         {
            edtavCpjconnome3_Visible = 1;
            AssignProp("", false, edtavCpjconnome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjconnome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJTIPONOME") == 0 )
         {
            edtavCpjtiponome3_Visible = 1;
            AssignProp("", false, edtavCpjtiponome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjtiponome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 )
         {
            edtavCpjcontiponome3_Visible = 1;
            AssignProp("", false, edtavCpjcontiponome3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcontiponome3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
         else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 )
         {
            edtavCpjcongensigla3_Visible = 1;
            AssignProp("", false, edtavCpjcongensigla3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCpjcongensigla3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV24DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV24DynamicFiltersEnabled2", AV24DynamicFiltersEnabled2);
         AV25DynamicFiltersSelector2 = "CPJCONNOME";
         AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
         AV26DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         AV27CpjConNome2 = "";
         AssignAttri("", false, "AV27CpjConNome2", AV27CpjConNome2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV31DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
         AV32DynamicFiltersSelector3 = "CPJCONNOME";
         AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         AV33DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         AV34CpjConNome3 = "";
         AssignAttri("", false, "AV34CpjConNome3", AV34CpjConNome3);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV47ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.ClientePJContatoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV47ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV50TFCpjConNome = "";
         AssignAttri("", false, "AV50TFCpjConNome", AV50TFCpjConNome);
         AV51TFCpjConNome_Sel = "";
         AssignAttri("", false, "AV51TFCpjConNome_Sel", AV51TFCpjConNome_Sel);
         AV52TFCpjConNomePrim = "";
         AssignAttri("", false, "AV52TFCpjConNomePrim", AV52TFCpjConNomePrim);
         AV53TFCpjConNomePrim_Sel = "";
         AssignAttri("", false, "AV53TFCpjConNomePrim_Sel", AV53TFCpjConNomePrim_Sel);
         AV54TFCpjConSobrenome = "";
         AssignAttri("", false, "AV54TFCpjConSobrenome", AV54TFCpjConSobrenome);
         AV55TFCpjConSobrenome_Sel = "";
         AssignAttri("", false, "AV55TFCpjConSobrenome_Sel", AV55TFCpjConSobrenome_Sel);
         AV56TFCpjConTipoNome = "";
         AssignAttri("", false, "AV56TFCpjConTipoNome", AV56TFCpjConTipoNome);
         AV57TFCpjConTipoNome_Sel = "";
         AssignAttri("", false, "AV57TFCpjConTipoNome_Sel", AV57TFCpjConTipoNome_Sel);
         AV58TFCpjConCPFFormat = "";
         AssignAttri("", false, "AV58TFCpjConCPFFormat", AV58TFCpjConCPFFormat);
         AV59TFCpjConCPFFormat_Sel = "";
         AssignAttri("", false, "AV59TFCpjConCPFFormat_Sel", AV59TFCpjConCPFFormat_Sel);
         AV60TFCpjConNascimento = DateTime.MinValue;
         AssignAttri("", false, "AV60TFCpjConNascimento", context.localUtil.Format(AV60TFCpjConNascimento, "99/99/99"));
         AV61TFCpjConNascimento_To = DateTime.MinValue;
         AssignAttri("", false, "AV61TFCpjConNascimento_To", context.localUtil.Format(AV61TFCpjConNascimento_To, "99/99/99"));
         AV65TFCpjConGenNome = "";
         AssignAttri("", false, "AV65TFCpjConGenNome", AV65TFCpjConGenNome);
         AV66TFCpjConGenNome_Sel = "";
         AssignAttri("", false, "AV66TFCpjConGenNome_Sel", AV66TFCpjConGenNome_Sel);
         AV67TFCpjConCelNum = "";
         AssignAttri("", false, "AV67TFCpjConCelNum", AV67TFCpjConCelNum);
         AV68TFCpjConCelNum_Sel = "";
         AssignAttri("", false, "AV68TFCpjConCelNum_Sel", AV68TFCpjConCelNum_Sel);
         AV69TFCpjConTelNum = "";
         AssignAttri("", false, "AV69TFCpjConTelNum", AV69TFCpjConTelNum);
         AV70TFCpjConTelNum_Sel = "";
         AssignAttri("", false, "AV70TFCpjConTelNum_Sel", AV70TFCpjConTelNum_Sel);
         AV71TFCpjConTelRam = "";
         AssignAttri("", false, "AV71TFCpjConTelRam", AV71TFCpjConTelRam);
         AV72TFCpjConTelRam_Sel = "";
         AssignAttri("", false, "AV72TFCpjConTelRam_Sel", AV72TFCpjConTelRam_Sel);
         AV89TFCpjConWppNum = "";
         AssignAttri("", false, "AV89TFCpjConWppNum", AV89TFCpjConWppNum);
         AV90TFCpjConWppNum_Sel = "";
         AssignAttri("", false, "AV90TFCpjConWppNum_Sel", AV90TFCpjConWppNum_Sel);
         AV73TFCpjConEmail = "";
         AssignAttri("", false, "AV73TFCpjConEmail", AV73TFCpjConEmail);
         AV74TFCpjConEmail_Sel = "";
         AssignAttri("", false, "AV74TFCpjConEmail_Sel", AV74TFCpjConEmail_Sel);
         AV75TFCpjConLIn = "";
         AssignAttri("", false, "AV75TFCpjConLIn", AV75TFCpjConLIn);
         AV76TFCpjConLIn_Sel = "";
         AssignAttri("", false, "AV76TFCpjConLIn_Sel", AV76TFCpjConLIn_Sel);
         AV79TFCliNomeFamiliar = "";
         AssignAttri("", false, "AV79TFCliNomeFamiliar", AV79TFCliNomeFamiliar);
         AV80TFCliNomeFamiliar_Sel = "";
         AssignAttri("", false, "AV80TFCliNomeFamiliar_Sel", AV80TFCliNomeFamiliar_Sel);
         AV77TFCliMatricula = 0;
         AssignAttri("", false, "AV77TFCliMatricula", StringUtil.LTrimStr( (decimal)(AV77TFCliMatricula), 12, 0));
         AV78TFCliMatricula_To = 0;
         AssignAttri("", false, "AV78TFCliMatricula_To", StringUtil.LTrimStr( (decimal)(AV78TFCliMatricula_To), 12, 0));
         AV81TFCpjTipoNome = "";
         AssignAttri("", false, "AV81TFCpjTipoNome", AV81TFCpjTipoNome);
         AV82TFCpjTipoNome_Sel = "";
         AssignAttri("", false, "AV82TFCpjTipoNome_Sel", AV82TFCpjTipoNome_Sel);
         AV83TFCpjNomeFan = "";
         AssignAttri("", false, "AV83TFCpjNomeFan", AV83TFCpjNomeFan);
         AV84TFCpjNomeFan_Sel = "";
         AssignAttri("", false, "AV84TFCpjNomeFan_Sel", AV84TFCpjNomeFan_Sel);
         AV85TFCpjRazaoSoc = "";
         AssignAttri("", false, "AV85TFCpjRazaoSoc", AV85TFCpjRazaoSoc);
         AV86TFCpjRazaoSoc_Sel = "";
         AssignAttri("", false, "AV86TFCpjRazaoSoc_Sel", AV86TFCpjRazaoSoc_Sel);
         AV103TFCpjMatricula = 0;
         AssignAttri("", false, "AV103TFCpjMatricula", StringUtil.LTrimStr( (decimal)(AV103TFCpjMatricula), 12, 0));
         AV104TFCpjMatricula_To = 0;
         AssignAttri("", false, "AV104TFCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV104TFCpjMatricula_To), 12, 0));
         AV105TFCpjCNPJFormat = "";
         AssignAttri("", false, "AV105TFCpjCNPJFormat", AV105TFCpjCNPJFormat);
         AV106TFCpjCNPJFormat_Sel = "";
         AssignAttri("", false, "AV106TFCpjCNPJFormat_Sel", AV106TFCpjCNPJFormat_Sel);
         AV107TFCpjIE = "";
         AssignAttri("", false, "AV107TFCpjIE", AV107TFCpjIE);
         AV108TFCpjIE_Sel = "";
         AssignAttri("", false, "AV108TFCpjIE_Sel", AV108TFCpjIE_Sel);
         AV109TFCpjCelNum = "";
         AssignAttri("", false, "AV109TFCpjCelNum", AV109TFCpjCelNum);
         AV110TFCpjCelNum_Sel = "";
         AssignAttri("", false, "AV110TFCpjCelNum_Sel", AV110TFCpjCelNum_Sel);
         AV111TFCpjTelNum = "";
         AssignAttri("", false, "AV111TFCpjTelNum", AV111TFCpjTelNum);
         AV112TFCpjTelNum_Sel = "";
         AssignAttri("", false, "AV112TFCpjTelNum_Sel", AV112TFCpjTelNum_Sel);
         AV113TFCpjTelRam = "";
         AssignAttri("", false, "AV113TFCpjTelRam", AV113TFCpjTelRam);
         AV114TFCpjTelRam_Sel = "";
         AssignAttri("", false, "AV114TFCpjTelRam_Sel", AV114TFCpjTelRam_Sel);
         AV115TFCpjWppNum = "";
         AssignAttri("", false, "AV115TFCpjWppNum", AV115TFCpjWppNum);
         AV116TFCpjWppNum_Sel = "";
         AssignAttri("", false, "AV116TFCpjWppNum_Sel", AV116TFCpjWppNum_Sel);
         AV117TFCpjEmail = "";
         AssignAttri("", false, "AV117TFCpjEmail", AV117TFCpjEmail);
         AV118TFCpjEmail_Sel = "";
         AssignAttri("", false, "AV118TFCpjEmail_Sel", AV118TFCpjEmail_Sel);
         AV119TFCpjWebsite = "";
         AssignAttri("", false, "AV119TFCpjWebsite", AV119TFCpjWebsite);
         AV120TFCpjWebsite_Sel = "";
         AssignAttri("", false, "AV120TFCpjWebsite_Sel", AV120TFCpjWebsite_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "CPJCONNOME";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20CpjConNome1 = "";
         AssignAttri("", false, "AV20CpjConNome1", AV20CpjConNome1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'RESETDYNFILTERS' */
         S222 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void S262( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV122IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0));
            CallWebObject(formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S272( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV123IsAuthorized_Delete )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontato.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0));
            CallWebObject(formatLink("core.clientepjcontato.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV46Session.Get(AV125Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV125Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV46Session.Get(AV125Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S172 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S252 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADDYNFILTERSSTATE' */
         S232 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV11GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV11GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV11GridState.gxTpr_Currentpage) ;
      }

      protected void S252( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV201GXV1 = 1;
         while ( AV201GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV201GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME") == 0 )
            {
               AV50TFCpjConNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFCpjConNome", AV50TFCpjConNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONNOME_SEL") == 0 )
            {
               AV51TFCpjConNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFCpjConNome_Sel", AV51TFCpjConNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM") == 0 )
            {
               AV52TFCpjConNomePrim = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV52TFCpjConNomePrim", AV52TFCpjConNomePrim);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONNOMEPRIM_SEL") == 0 )
            {
               AV53TFCpjConNomePrim_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV53TFCpjConNomePrim_Sel", AV53TFCpjConNomePrim_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME") == 0 )
            {
               AV54TFCpjConSobrenome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV54TFCpjConSobrenome", AV54TFCpjConSobrenome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONSOBRENOME_SEL") == 0 )
            {
               AV55TFCpjConSobrenome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV55TFCpjConSobrenome_Sel", AV55TFCpjConSobrenome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME") == 0 )
            {
               AV56TFCpjConTipoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV56TFCpjConTipoNome", AV56TFCpjConTipoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTIPONOME_SEL") == 0 )
            {
               AV57TFCpjConTipoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV57TFCpjConTipoNome_Sel", AV57TFCpjConTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT") == 0 )
            {
               AV58TFCpjConCPFFormat = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV58TFCpjConCPFFormat", AV58TFCpjConCPFFormat);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONCPFFORMAT_SEL") == 0 )
            {
               AV59TFCpjConCPFFormat_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59TFCpjConCPFFormat_Sel", AV59TFCpjConCPFFormat_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONNASCIMENTO") == 0 )
            {
               AV60TFCpjConNascimento = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV60TFCpjConNascimento", context.localUtil.Format(AV60TFCpjConNascimento, "99/99/99"));
               AV61TFCpjConNascimento_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV61TFCpjConNascimento_To", context.localUtil.Format(AV61TFCpjConNascimento_To, "99/99/99"));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME") == 0 )
            {
               AV65TFCpjConGenNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV65TFCpjConGenNome", AV65TFCpjConGenNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONGENNOME_SEL") == 0 )
            {
               AV66TFCpjConGenNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV66TFCpjConGenNome_Sel", AV66TFCpjConGenNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM") == 0 )
            {
               AV67TFCpjConCelNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV67TFCpjConCelNum", AV67TFCpjConCelNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONCELNUM_SEL") == 0 )
            {
               AV68TFCpjConCelNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV68TFCpjConCelNum_Sel", AV68TFCpjConCelNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM") == 0 )
            {
               AV69TFCpjConTelNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV69TFCpjConTelNum", AV69TFCpjConTelNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTELNUM_SEL") == 0 )
            {
               AV70TFCpjConTelNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV70TFCpjConTelNum_Sel", AV70TFCpjConTelNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM") == 0 )
            {
               AV71TFCpjConTelRam = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV71TFCpjConTelRam", AV71TFCpjConTelRam);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONTELRAM_SEL") == 0 )
            {
               AV72TFCpjConTelRam_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV72TFCpjConTelRam_Sel", AV72TFCpjConTelRam_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM") == 0 )
            {
               AV89TFCpjConWppNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV89TFCpjConWppNum", AV89TFCpjConWppNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONWPPNUM_SEL") == 0 )
            {
               AV90TFCpjConWppNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV90TFCpjConWppNum_Sel", AV90TFCpjConWppNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL") == 0 )
            {
               AV73TFCpjConEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV73TFCpjConEmail", AV73TFCpjConEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONEMAIL_SEL") == 0 )
            {
               AV74TFCpjConEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV74TFCpjConEmail_Sel", AV74TFCpjConEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN") == 0 )
            {
               AV75TFCpjConLIn = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV75TFCpjConLIn", AV75TFCpjConLIn);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCONLIN_SEL") == 0 )
            {
               AV76TFCpjConLIn_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV76TFCpjConLIn_Sel", AV76TFCpjConLIn_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR") == 0 )
            {
               AV79TFCliNomeFamiliar = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV79TFCliNomeFamiliar", AV79TFCliNomeFamiliar);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCLINOMEFAMILIAR_SEL") == 0 )
            {
               AV80TFCliNomeFamiliar_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV80TFCliNomeFamiliar_Sel", AV80TFCliNomeFamiliar_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCLIMATRICULA") == 0 )
            {
               AV77TFCliMatricula = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV77TFCliMatricula", StringUtil.LTrimStr( (decimal)(AV77TFCliMatricula), 12, 0));
               AV78TFCliMatricula_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV78TFCliMatricula_To", StringUtil.LTrimStr( (decimal)(AV78TFCliMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME") == 0 )
            {
               AV81TFCpjTipoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV81TFCpjTipoNome", AV81TFCpjTipoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTIPONOME_SEL") == 0 )
            {
               AV82TFCpjTipoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV82TFCpjTipoNome_Sel", AV82TFCpjTipoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN") == 0 )
            {
               AV83TFCpjNomeFan = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV83TFCpjNomeFan", AV83TFCpjNomeFan);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJNOMEFAN_SEL") == 0 )
            {
               AV84TFCpjNomeFan_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV84TFCpjNomeFan_Sel", AV84TFCpjNomeFan_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC") == 0 )
            {
               AV85TFCpjRazaoSoc = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV85TFCpjRazaoSoc", AV85TFCpjRazaoSoc);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJRAZAOSOC_SEL") == 0 )
            {
               AV86TFCpjRazaoSoc_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV86TFCpjRazaoSoc_Sel", AV86TFCpjRazaoSoc_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJMATRICULA") == 0 )
            {
               AV103TFCpjMatricula = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV103TFCpjMatricula", StringUtil.LTrimStr( (decimal)(AV103TFCpjMatricula), 12, 0));
               AV104TFCpjMatricula_To = (long)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV104TFCpjMatricula_To", StringUtil.LTrimStr( (decimal)(AV104TFCpjMatricula_To), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT") == 0 )
            {
               AV105TFCpjCNPJFormat = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV105TFCpjCNPJFormat", AV105TFCpjCNPJFormat);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCNPJFORMAT_SEL") == 0 )
            {
               AV106TFCpjCNPJFormat_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV106TFCpjCNPJFormat_Sel", AV106TFCpjCNPJFormat_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJIE") == 0 )
            {
               AV107TFCpjIE = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV107TFCpjIE", AV107TFCpjIE);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJIE_SEL") == 0 )
            {
               AV108TFCpjIE_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV108TFCpjIE_Sel", AV108TFCpjIE_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM") == 0 )
            {
               AV109TFCpjCelNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV109TFCpjCelNum", AV109TFCpjCelNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJCELNUM_SEL") == 0 )
            {
               AV110TFCpjCelNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV110TFCpjCelNum_Sel", AV110TFCpjCelNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM") == 0 )
            {
               AV111TFCpjTelNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV111TFCpjTelNum", AV111TFCpjTelNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTELNUM_SEL") == 0 )
            {
               AV112TFCpjTelNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV112TFCpjTelNum_Sel", AV112TFCpjTelNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM") == 0 )
            {
               AV113TFCpjTelRam = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV113TFCpjTelRam", AV113TFCpjTelRam);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJTELRAM_SEL") == 0 )
            {
               AV114TFCpjTelRam_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV114TFCpjTelRam_Sel", AV114TFCpjTelRam_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM") == 0 )
            {
               AV115TFCpjWppNum = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV115TFCpjWppNum", AV115TFCpjWppNum);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJWPPNUM_SEL") == 0 )
            {
               AV116TFCpjWppNum_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV116TFCpjWppNum_Sel", AV116TFCpjWppNum_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL") == 0 )
            {
               AV117TFCpjEmail = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV117TFCpjEmail", AV117TFCpjEmail);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJEMAIL_SEL") == 0 )
            {
               AV118TFCpjEmail_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV118TFCpjEmail_Sel", AV118TFCpjEmail_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE") == 0 )
            {
               AV119TFCpjWebsite = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV119TFCpjWebsite", AV119TFCpjWebsite);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFCPJWEBSITE_SEL") == 0 )
            {
               AV120TFCpjWebsite_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV120TFCpjWebsite_Sel", AV120TFCpjWebsite_Sel);
            }
            AV201GXV1 = (int)(AV201GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCpjConNome_Sel)),  AV51TFCpjConNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCpjConNomePrim_Sel)),  AV53TFCpjConNomePrim_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCpjConSobrenome_Sel)),  AV55TFCpjConSobrenome_Sel, out  GXt_char6) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCpjConTipoNome_Sel)),  AV57TFCpjConTipoNome_Sel, out  GXt_char7) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV59TFCpjConCPFFormat_Sel)),  AV59TFCpjConCPFFormat_Sel, out  GXt_char8) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCpjConGenNome_Sel)),  AV66TFCpjConGenNome_Sel, out  GXt_char9) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCpjConCelNum_Sel)),  AV68TFCpjConCelNum_Sel, out  GXt_char10) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCpjConTelNum_Sel)),  AV70TFCpjConTelNum_Sel, out  GXt_char11) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCpjConTelRam_Sel)),  AV72TFCpjConTelRam_Sel, out  GXt_char12) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV90TFCpjConWppNum_Sel)),  AV90TFCpjConWppNum_Sel, out  GXt_char13) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCpjConEmail_Sel)),  AV74TFCpjConEmail_Sel, out  GXt_char14) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCpjConLIn_Sel)),  AV76TFCpjConLIn_Sel, out  GXt_char15) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliNomeFamiliar_Sel)),  AV80TFCliNomeFamiliar_Sel, out  GXt_char16) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV82TFCpjTipoNome_Sel)),  AV82TFCpjTipoNome_Sel, out  GXt_char17) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV84TFCpjNomeFan_Sel)),  AV84TFCpjNomeFan_Sel, out  GXt_char18) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV86TFCpjRazaoSoc_Sel)),  AV86TFCpjRazaoSoc_Sel, out  GXt_char19) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV106TFCpjCNPJFormat_Sel)),  AV106TFCpjCNPJFormat_Sel, out  GXt_char20) ;
         GXt_char21 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV108TFCpjIE_Sel)),  AV108TFCpjIE_Sel, out  GXt_char21) ;
         GXt_char22 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV110TFCpjCelNum_Sel)),  AV110TFCpjCelNum_Sel, out  GXt_char22) ;
         GXt_char23 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV112TFCpjTelNum_Sel)),  AV112TFCpjTelNum_Sel, out  GXt_char23) ;
         GXt_char24 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV114TFCpjTelRam_Sel)),  AV114TFCpjTelRam_Sel, out  GXt_char24) ;
         GXt_char25 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV116TFCpjWppNum_Sel)),  AV116TFCpjWppNum_Sel, out  GXt_char25) ;
         GXt_char26 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV118TFCpjEmail_Sel)),  AV118TFCpjEmail_Sel, out  GXt_char26) ;
         GXt_char27 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV120TFCpjWebsite_Sel)),  AV120TFCpjWebsite_Sel, out  GXt_char27) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|"+GXt_char6+"|"+GXt_char7+"|"+GXt_char8+"||"+GXt_char9+"|"+GXt_char10+"|"+GXt_char11+"|"+GXt_char12+"|"+GXt_char13+"|"+GXt_char14+"|"+GXt_char15+"|"+GXt_char16+"||"+GXt_char17+"|"+GXt_char18+"|"+GXt_char19+"||"+GXt_char20+"|"+GXt_char21+"|"+GXt_char22+"|"+GXt_char23+"|"+GXt_char24+"|"+GXt_char25+"|"+GXt_char26+"|"+GXt_char27;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char27 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCpjConNome)),  AV50TFCpjConNome, out  GXt_char27) ;
         GXt_char26 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCpjConNomePrim)),  AV52TFCpjConNomePrim, out  GXt_char26) ;
         GXt_char25 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCpjConSobrenome)),  AV54TFCpjConSobrenome, out  GXt_char25) ;
         GXt_char24 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCpjConTipoNome)),  AV56TFCpjConTipoNome, out  GXt_char24) ;
         GXt_char23 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV58TFCpjConCPFFormat)),  AV58TFCpjConCPFFormat, out  GXt_char23) ;
         GXt_char22 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCpjConGenNome)),  AV65TFCpjConGenNome, out  GXt_char22) ;
         GXt_char21 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCpjConCelNum)),  AV67TFCpjConCelNum, out  GXt_char21) ;
         GXt_char20 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCpjConTelNum)),  AV69TFCpjConTelNum, out  GXt_char20) ;
         GXt_char19 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCpjConTelRam)),  AV71TFCpjConTelRam, out  GXt_char19) ;
         GXt_char18 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV89TFCpjConWppNum)),  AV89TFCpjConWppNum, out  GXt_char18) ;
         GXt_char17 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCpjConEmail)),  AV73TFCpjConEmail, out  GXt_char17) ;
         GXt_char16 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCpjConLIn)),  AV75TFCpjConLIn, out  GXt_char16) ;
         GXt_char15 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliNomeFamiliar)),  AV79TFCliNomeFamiliar, out  GXt_char15) ;
         GXt_char14 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCpjTipoNome)),  AV81TFCpjTipoNome, out  GXt_char14) ;
         GXt_char13 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCpjNomeFan)),  AV83TFCpjNomeFan, out  GXt_char13) ;
         GXt_char12 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV85TFCpjRazaoSoc)),  AV85TFCpjRazaoSoc, out  GXt_char12) ;
         GXt_char11 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV105TFCpjCNPJFormat)),  AV105TFCpjCNPJFormat, out  GXt_char11) ;
         GXt_char10 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV107TFCpjIE)),  AV107TFCpjIE, out  GXt_char10) ;
         GXt_char9 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV109TFCpjCelNum)),  AV109TFCpjCelNum, out  GXt_char9) ;
         GXt_char8 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV111TFCpjTelNum)),  AV111TFCpjTelNum, out  GXt_char8) ;
         GXt_char7 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV113TFCpjTelRam)),  AV113TFCpjTelRam, out  GXt_char7) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV115TFCpjWppNum)),  AV115TFCpjWppNum, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV117TFCpjEmail)),  AV117TFCpjEmail, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV119TFCpjWebsite)),  AV119TFCpjWebsite, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char27+"|"+GXt_char26+"|"+GXt_char25+"|"+GXt_char24+"|"+GXt_char23+"|"+((DateTime.MinValue==AV60TFCpjConNascimento) ? "" : context.localUtil.DToC( AV60TFCpjConNascimento, 2, "/"))+"|"+GXt_char22+"|"+GXt_char21+"|"+GXt_char20+"|"+GXt_char19+"|"+GXt_char18+"|"+GXt_char17+"|"+GXt_char16+"|"+GXt_char15+"|"+((0==AV77TFCliMatricula) ? "" : StringUtil.Str( (decimal)(AV77TFCliMatricula), 12, 0))+"|"+GXt_char14+"|"+GXt_char13+"|"+GXt_char12+"|"+((0==AV103TFCpjMatricula) ? "" : StringUtil.Str( (decimal)(AV103TFCpjMatricula), 12, 0))+"|"+GXt_char11+"|"+GXt_char10+"|"+GXt_char9+"|"+GXt_char8+"|"+GXt_char7+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "|||||"+((DateTime.MinValue==AV61TFCpjConNascimento_To) ? "" : context.localUtil.DToC( AV61TFCpjConNascimento_To, 2, "/"))+"|||||||||"+((0==AV78TFCliMatricula_To) ? "" : StringUtil.Str( (decimal)(AV78TFCliMatricula_To), 12, 0))+"||||"+((0==AV104TFCpjMatricula_To) ? "" : StringUtil.Str( (decimal)(AV104TFCpjMatricula_To), 12, 0))+"||||||||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S232( )
      {
         /* 'LOADDYNFILTERSSTATE' Routine */
         returnInSub = false;
         imgAdddynamicfilters1_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         imgAdddynamicfilters2_Visible = 1;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 0;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 1 )
         {
            AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(1));
            AV18DynamicFiltersSelector1 = AV13GridStateDynamicFilter.gxTpr_Selected;
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONNOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20CpjConNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20CpjConNome1", AV20CpjConNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJTIPONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV21CpjTipoNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV21CpjTipoNome1", AV21CpjTipoNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV22CpjConTipoNome1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV22CpjConTipoNome1", AV22CpjConTipoNome1);
            }
            else if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV23CpjConGenSigla1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV23CpjConGenSigla1", AV23CpjConGenSigla1);
            }
            /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
            S122 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 2 )
            {
               lblJsdynamicfilters_Caption = "<script type=\"text/javascript\">$(document).ready(function() {";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 2, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
               imgAdddynamicfilters1_Visible = 0;
               AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
               imgRemovedynamicfilters1_Visible = 1;
               AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
               AV24DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV24DynamicFiltersEnabled2", AV24DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV25DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONNOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
                  AV27CpjConNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV27CpjConNome2", AV27CpjConNome2);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJTIPONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
                  AV28CpjTipoNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV28CpjTipoNome2", AV28CpjTipoNome2);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
                  AV29CpjConTipoNome2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV29CpjConTipoNome2", AV29CpjConTipoNome2);
               }
               else if ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 )
               {
                  AV26DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
                  AV30CpjConGenSigla2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV30CpjConGenSigla2", AV30CpjConGenSigla2);
               }
               /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
               S132 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               if ( AV11GridState.gxTpr_Dynamicfilters.Count >= 3 )
               {
                  lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+StringUtil.Format( "WWPDynFilterShow_AL('%1', 3, 0);", divTabledynamicfilters_Internalname, "", "", "", "", "", "", "", "");
                  AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
                  imgAdddynamicfilters2_Visible = 0;
                  AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
                  imgRemovedynamicfilters2_Visible = 1;
                  AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
                  AV31DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV31DynamicFiltersEnabled3", AV31DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV32DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONNOME") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
                     AV34CpjConNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV34CpjConNome3", AV34CpjConNome3);
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJTIPONOME") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
                     AV35CpjTipoNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV35CpjTipoNome3", AV35CpjTipoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
                     AV36CpjConTipoNome3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV36CpjConTipoNome3", AV36CpjConTipoNome3);
                  }
                  else if ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 )
                  {
                     AV33DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
                     AV37CpjConGenSigla3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV37CpjConGenSigla3", AV37CpjConGenSigla3);
                  }
                  /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
                  S142 ();
                  if ( returnInSub )
                  {
                     returnInSub = true;
                     if (true) return;
                  }
               }
               lblJsdynamicfilters_Caption = lblJsdynamicfilters_Caption+"});</script>";
               AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
            }
         }
         if ( AV38DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV46Session.Get(AV125Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONNOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFCpjConNome)),  0,  AV50TFCpjConNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFCpjConNome_Sel)),  AV51TFCpjConNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONNOMEPRIM",  "Primeiro Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV52TFCpjConNomePrim)),  0,  AV52TFCpjConNomePrim,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV53TFCpjConNomePrim_Sel)),  AV53TFCpjConNomePrim_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONSOBRENOME",  "Sobrenome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV54TFCpjConSobrenome)),  0,  AV54TFCpjConSobrenome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV55TFCpjConSobrenome_Sel)),  AV55TFCpjConSobrenome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONTIPONOME",  "Tipo do Contato",  !String.IsNullOrEmpty(StringUtil.RTrim( AV56TFCpjConTipoNome)),  0,  AV56TFCpjConTipoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV57TFCpjConTipoNome_Sel)),  AV57TFCpjConTipoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONCPFFORMAT",  "CPF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV58TFCpjConCPFFormat)),  0,  AV58TFCpjConCPFFormat,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59TFCpjConCPFFormat_Sel)),  AV59TFCpjConCPFFormat_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCPJCONNASCIMENTO",  "Dt. Nascimento",  !((DateTime.MinValue==AV60TFCpjConNascimento)&&(DateTime.MinValue==AV61TFCpjConNascimento_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV60TFCpjConNascimento, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV61TFCpjConNascimento_To, 2, "/"))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONGENNOME",  "Gênero",  !String.IsNullOrEmpty(StringUtil.RTrim( AV65TFCpjConGenNome)),  0,  AV65TFCpjConGenNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV66TFCpjConGenNome_Sel)),  AV66TFCpjConGenNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONCELNUM",  "Celular",  !String.IsNullOrEmpty(StringUtil.RTrim( AV67TFCpjConCelNum)),  0,  AV67TFCpjConCelNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV68TFCpjConCelNum_Sel)),  AV68TFCpjConCelNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONTELNUM",  "Telefone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV69TFCpjConTelNum)),  0,  AV69TFCpjConTelNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV70TFCpjConTelNum_Sel)),  AV70TFCpjConTelNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONTELRAM",  "Ramal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV71TFCpjConTelRam)),  0,  AV71TFCpjConTelRam,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV72TFCpjConTelRam_Sel)),  AV72TFCpjConTelRam_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONWPPNUM",  "WhatsApp",  !String.IsNullOrEmpty(StringUtil.RTrim( AV89TFCpjConWppNum)),  0,  AV89TFCpjConWppNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV90TFCpjConWppNum_Sel)),  AV90TFCpjConWppNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONEMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV73TFCpjConEmail)),  0,  AV73TFCpjConEmail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV74TFCpjConEmail_Sel)),  AV74TFCpjConEmail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCONLIN",  "LinkedIn",  !String.IsNullOrEmpty(StringUtil.RTrim( AV75TFCpjConLIn)),  0,  AV75TFCpjConLIn,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV76TFCpjConLIn_Sel)),  AV76TFCpjConLIn_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCLINOMEFAMILIAR",  "Nome Familiar",  !String.IsNullOrEmpty(StringUtil.RTrim( AV79TFCliNomeFamiliar)),  0,  AV79TFCliNomeFamiliar,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV80TFCliNomeFamiliar_Sel)),  AV80TFCliNomeFamiliar_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCLIMATRICULA",  "Matrícula",  !((0==AV77TFCliMatricula)&&(0==AV78TFCliMatricula_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV77TFCliMatricula), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV78TFCliMatricula_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJTIPONOME",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV81TFCpjTipoNome)),  0,  AV81TFCpjTipoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV82TFCpjTipoNome_Sel)),  AV82TFCpjTipoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJNOMEFAN",  "Nome Fantasia",  !String.IsNullOrEmpty(StringUtil.RTrim( AV83TFCpjNomeFan)),  0,  AV83TFCpjNomeFan,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV84TFCpjNomeFan_Sel)),  AV84TFCpjNomeFan_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJRAZAOSOC",  "Razão Social",  !String.IsNullOrEmpty(StringUtil.RTrim( AV85TFCpjRazaoSoc)),  0,  AV85TFCpjRazaoSoc,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV86TFCpjRazaoSoc_Sel)),  AV86TFCpjRazaoSoc_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFCPJMATRICULA",  "Matrícula",  !((0==AV103TFCpjMatricula)&&(0==AV104TFCpjMatricula_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV103TFCpjMatricula), 12, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV104TFCpjMatricula_To), 12, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCNPJFORMAT",  "CNPJ",  !String.IsNullOrEmpty(StringUtil.RTrim( AV105TFCpjCNPJFormat)),  0,  AV105TFCpjCNPJFormat,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV106TFCpjCNPJFormat_Sel)),  AV106TFCpjCNPJFormat_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJIE",  "IE",  !String.IsNullOrEmpty(StringUtil.RTrim( AV107TFCpjIE)),  0,  AV107TFCpjIE,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV108TFCpjIE_Sel)),  AV108TFCpjIE_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJCELNUM",  "Celular",  !String.IsNullOrEmpty(StringUtil.RTrim( AV109TFCpjCelNum)),  0,  AV109TFCpjCelNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV110TFCpjCelNum_Sel)),  AV110TFCpjCelNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJTELNUM",  "Telefone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV111TFCpjTelNum)),  0,  AV111TFCpjTelNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV112TFCpjTelNum_Sel)),  AV112TFCpjTelNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJTELRAM",  "Ramal do Telefone",  !String.IsNullOrEmpty(StringUtil.RTrim( AV113TFCpjTelRam)),  0,  AV113TFCpjTelRam,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV114TFCpjTelRam_Sel)),  AV114TFCpjTelRam_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJWPPNUM",  "WhatsApp",  !String.IsNullOrEmpty(StringUtil.RTrim( AV115TFCpjWppNum)),  0,  AV115TFCpjWppNum,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV116TFCpjWppNum_Sel)),  AV116TFCpjWppNum_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJEMAIL",  "E-mail",  !String.IsNullOrEmpty(StringUtil.RTrim( AV117TFCpjEmail)),  0,  AV117TFCpjEmail,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV118TFCpjEmail_Sel)),  AV118TFCpjEmail_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFCPJWEBSITE",  "Website",  !String.IsNullOrEmpty(StringUtil.RTrim( AV119TFCpjWebsite)),  0,  AV119TFCpjWebsite,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV120TFCpjWebsite_Sel)),  AV120TFCpjWebsite_Sel,  "") ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV125Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV39DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20CpjConNome1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Nome do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV20CpjConNome1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV21CpjTipoNome1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo";
               AV13GridStateDynamicFilter.gxTpr_Value = AV21CpjTipoNome1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV22CpjConTipoNome1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV22CpjConTipoNome1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            else if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "CPJCONGENSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV23CpjConGenSigla1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Gênero";
               AV13GridStateDynamicFilter.gxTpr_Value = AV23CpjConGenSigla1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV38DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV24DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV25DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV27CpjConNome2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Nome do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV27CpjConNome2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28CpjTipoNome2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo";
               AV13GridStateDynamicFilter.gxTpr_Value = AV28CpjTipoNome2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV29CpjConTipoNome2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV29CpjConTipoNome2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator2;
            }
            else if ( ( StringUtil.StrCmp(AV25DynamicFiltersSelector2, "CPJCONGENSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV30CpjConGenSigla2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Gênero";
               AV13GridStateDynamicFilter.gxTpr_Value = AV30CpjConGenSigla2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV26DynamicFiltersOperator2;
            }
            if ( AV38DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV31DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV32DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONNOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV34CpjConNome3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Nome do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV34CpjConNome3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV33DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV35CpjTipoNome3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo";
               AV13GridStateDynamicFilter.gxTpr_Value = AV35CpjTipoNome3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV33DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONTIPONOME") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV36CpjConTipoNome3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Tipo do Contato";
               AV13GridStateDynamicFilter.gxTpr_Value = AV36CpjConTipoNome3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV33DynamicFiltersOperator3;
            }
            else if ( ( StringUtil.StrCmp(AV32DynamicFiltersSelector3, "CPJCONGENSIGLA") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV37CpjConGenSigla3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Gênero";
               AV13GridStateDynamicFilter.gxTpr_Value = AV37CpjConGenSigla3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV33DynamicFiltersOperator3;
            }
            if ( AV38DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
      }

      protected void S152( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV125Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.ClientePJContato";
         AV46Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S282( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.core.clientepjcontatowwexport(context ).execute( out  AV40ExcelFilename, out  AV41ErrorMessage) ;
         if ( StringUtil.StrCmp(AV40ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV40ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV41ErrorMessage);
         }
      }

      protected void S292( )
      {
         /* 'DOEXPORTREPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         Innewwindow1_Target = formatLink("core.clientepjcontatowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table4_111_4S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters3_Internalname, tblTablemergeddynamicfilters3_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator3_Internalname, "Dynamic Filters Operator3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjconnome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjconnome3_Internalname, "Cpj Con Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjconnome3_Internalname, AV34CpjConNome3, StringUtil.RTrim( context.localUtil.Format( AV34CpjConNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,118);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjconnome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjconnome3_Visible, edtavCpjconnome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjtiponome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjtiponome3_Internalname, "Cpj Tipo Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 121,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjtiponome3_Internalname, AV35CpjTipoNome3, StringUtil.RTrim( context.localUtil.Format( AV35CpjTipoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,121);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjtiponome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjtiponome3_Visible, edtavCpjtiponome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcontiponome3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcontiponome3_Internalname, "Cpj Con Tipo Nome3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcontiponome3_Internalname, AV36CpjConTipoNome3, StringUtil.RTrim( context.localUtil.Format( AV36CpjConTipoNome3, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,124);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcontiponome3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcontiponome3_Visible, edtavCpjcontiponome3_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcongensigla3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcongensigla3_Internalname, "Cpj Con Gen Sigla3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcongensigla3_Internalname, AV37CpjConGenSigla3, StringUtil.RTrim( context.localUtil.Format( AV37CpjConGenSigla3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,127);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcongensigla3_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcongensigla3_Visible, edtavCpjcongensigla3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\ClientePJContatoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_111_4S2e( true) ;
         }
         else
         {
            wb_table4_111_4S2e( false) ;
         }
      }

      protected void wb_table3_80_4S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters2_Internalname, tblTablemergeddynamicfilters2_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator2_Internalname, "Dynamic Filters Operator2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,84);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjconnome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjconnome2_Internalname, "Cpj Con Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjconnome2_Internalname, AV27CpjConNome2, StringUtil.RTrim( context.localUtil.Format( AV27CpjConNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,87);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjconnome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjconnome2_Visible, edtavCpjconnome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjtiponome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjtiponome2_Internalname, "Cpj Tipo Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 90,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjtiponome2_Internalname, AV28CpjTipoNome2, StringUtil.RTrim( context.localUtil.Format( AV28CpjTipoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,90);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjtiponome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjtiponome2_Visible, edtavCpjtiponome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcontiponome2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcontiponome2_Internalname, "Cpj Con Tipo Nome2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcontiponome2_Internalname, AV29CpjConTipoNome2, StringUtil.RTrim( context.localUtil.Format( AV29CpjConTipoNome2, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcontiponome2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcontiponome2_Visible, edtavCpjcontiponome2_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcongensigla2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcongensigla2_Internalname, "Cpj Con Gen Sigla2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcongensigla2_Internalname, AV30CpjConGenSigla2, StringUtil.RTrim( context.localUtil.Format( AV30CpjConGenSigla2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,96);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcongensigla2_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcongensigla2_Visible, edtavCpjcongensigla2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\ClientePJContatoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 100,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\ClientePJContatoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_80_4S2e( true) ;
         }
         else
         {
            wb_table3_80_4S2e( false) ;
         }
      }

      protected void wb_table2_49_4S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfilters1_Internalname, tblTablemergeddynamicfilters1_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperator1_Internalname, "Dynamic Filters Operator1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'" + sGXsfl_138_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,53);\"", "", true, 0, "HLP_core\\ClientePJContatoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjconnome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjconnome1_Internalname, "Cpj Con Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjconnome1_Internalname, AV20CpjConNome1, StringUtil.RTrim( context.localUtil.Format( AV20CpjConNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjconnome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjconnome1_Visible, edtavCpjconnome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjtiponome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjtiponome1_Internalname, "Cpj Tipo Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjtiponome1_Internalname, AV21CpjTipoNome1, StringUtil.RTrim( context.localUtil.Format( AV21CpjTipoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjtiponome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjtiponome1_Visible, edtavCpjtiponome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcontiponome1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcontiponome1_Internalname, "Cpj Con Tipo Nome1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcontiponome1_Internalname, AV22CpjConTipoNome1, StringUtil.RTrim( context.localUtil.Format( AV22CpjConTipoNome1, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,62);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcontiponome1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcontiponome1_Visible, edtavCpjcontiponome1_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_cpjcongensigla1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCpjcongensigla1_Internalname, "Cpj Con Gen Sigla1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCpjcongensigla1_Internalname, AV23CpjConGenSigla1, StringUtil.RTrim( context.localUtil.Format( AV23CpjConGenSigla1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,65);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCpjcongensigla1_Jsonclick, 0, "Attribute", "", "", "", "", edtavCpjcongensigla1_Visible, edtavCpjcongensigla1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 67,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\ClientePJContatoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\ClientePJContatoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_49_4S2e( true) ;
         }
         else
         {
            wb_table2_49_4S2e( false) ;
         }
      }

      protected void wb_table1_25_4S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV47ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_30_4S2( true) ;
         }
         else
         {
            wb_table5_30_4S2( false) ;
         }
         return  ;
      }

      protected void wb_table5_30_4S2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_4S2e( true) ;
         }
         else
         {
            wb_table1_25_4S2e( false) ;
         }
      }

      protected void wb_table5_30_4S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilterfulltext_Internalname, "Filter Full Text", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_138_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\ClientePJContatoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_30_4S2e( true) ;
         }
         else
         {
            wb_table5_30_4S2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA4S2( ) ;
         WS4S2( ) ;
         WE4S2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("DVelop/DVPaginationBar/DVPaginationBar.css", "");
         AddStyleSheetFile("DVelop/Shared/daterangepicker/daterangepicker.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Wwpaux_wc == null ) )
         {
            if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
            {
               WebComp_Wwpaux_wc.componentthemes();
            }
         }
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828235117", true, true);
            idxLst = (int)(idxLst+1);
         }
         if ( ! outputEnabled )
         {
            if ( context.isSpaRequest( ) )
            {
               disableOutput();
            }
         }
         /* End function define_styles */
      }

      protected void include_jscripts( )
      {
         context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
         context.AddJavascriptSource("core/clientepjcontatoww.js", "?2023828235118", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DVPaginationBar/DVPaginationBarRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Window/InNewWindowRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridTitlesCategories/GridTitlesCategoriesRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/locales.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/wwp-daterangepicker.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/moment.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/daterangepicker/daterangepicker.min.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/DateRangePicker/DateRangePickerRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_1382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_138_idx;
         edtCpjConNome_Internalname = "CPJCONNOME_"+sGXsfl_138_idx;
         edtCpjConNomePrim_Internalname = "CPJCONNOMEPRIM_"+sGXsfl_138_idx;
         edtCpjConSobrenome_Internalname = "CPJCONSOBRENOME_"+sGXsfl_138_idx;
         edtCpjConTipoNome_Internalname = "CPJCONTIPONOME_"+sGXsfl_138_idx;
         edtCpjConCPFFormat_Internalname = "CPJCONCPFFORMAT_"+sGXsfl_138_idx;
         edtCpjConNascimento_Internalname = "CPJCONNASCIMENTO_"+sGXsfl_138_idx;
         edtCpjConGenNome_Internalname = "CPJCONGENNOME_"+sGXsfl_138_idx;
         edtCpjConCelNum_Internalname = "CPJCONCELNUM_"+sGXsfl_138_idx;
         edtCpjConTelNum_Internalname = "CPJCONTELNUM_"+sGXsfl_138_idx;
         edtCpjConTelRam_Internalname = "CPJCONTELRAM_"+sGXsfl_138_idx;
         edtCpjConWppNum_Internalname = "CPJCONWPPNUM_"+sGXsfl_138_idx;
         edtCpjConEmail_Internalname = "CPJCONEMAIL_"+sGXsfl_138_idx;
         edtCpjConLIn_Internalname = "CPJCONLIN_"+sGXsfl_138_idx;
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR_"+sGXsfl_138_idx;
         edtCliMatricula_Internalname = "CLIMATRICULA_"+sGXsfl_138_idx;
         edtCpjTipoNome_Internalname = "CPJTIPONOME_"+sGXsfl_138_idx;
         edtCpjNomeFan_Internalname = "CPJNOMEFAN_"+sGXsfl_138_idx;
         edtCpjRazaoSoc_Internalname = "CPJRAZAOSOC_"+sGXsfl_138_idx;
         edtCpjMatricula_Internalname = "CPJMATRICULA_"+sGXsfl_138_idx;
         edtCpjCNPJFormat_Internalname = "CPJCNPJFORMAT_"+sGXsfl_138_idx;
         edtCpjIE_Internalname = "CPJIE_"+sGXsfl_138_idx;
         edtCpjCelNum_Internalname = "CPJCELNUM_"+sGXsfl_138_idx;
         edtCpjTelNum_Internalname = "CPJTELNUM_"+sGXsfl_138_idx;
         edtCpjTelRam_Internalname = "CPJTELRAM_"+sGXsfl_138_idx;
         edtCpjWppNum_Internalname = "CPJWPPNUM_"+sGXsfl_138_idx;
         edtCpjEmail_Internalname = "CPJEMAIL_"+sGXsfl_138_idx;
         edtCpjWebsite_Internalname = "CPJWEBSITE_"+sGXsfl_138_idx;
         edtCliID_Internalname = "CLIID_"+sGXsfl_138_idx;
         edtCpjID_Internalname = "CPJID_"+sGXsfl_138_idx;
         edtCpjConSeq_Internalname = "CPJCONSEQ_"+sGXsfl_138_idx;
      }

      protected void SubsflControlProps_fel_1382( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_138_fel_idx;
         edtCpjConNome_Internalname = "CPJCONNOME_"+sGXsfl_138_fel_idx;
         edtCpjConNomePrim_Internalname = "CPJCONNOMEPRIM_"+sGXsfl_138_fel_idx;
         edtCpjConSobrenome_Internalname = "CPJCONSOBRENOME_"+sGXsfl_138_fel_idx;
         edtCpjConTipoNome_Internalname = "CPJCONTIPONOME_"+sGXsfl_138_fel_idx;
         edtCpjConCPFFormat_Internalname = "CPJCONCPFFORMAT_"+sGXsfl_138_fel_idx;
         edtCpjConNascimento_Internalname = "CPJCONNASCIMENTO_"+sGXsfl_138_fel_idx;
         edtCpjConGenNome_Internalname = "CPJCONGENNOME_"+sGXsfl_138_fel_idx;
         edtCpjConCelNum_Internalname = "CPJCONCELNUM_"+sGXsfl_138_fel_idx;
         edtCpjConTelNum_Internalname = "CPJCONTELNUM_"+sGXsfl_138_fel_idx;
         edtCpjConTelRam_Internalname = "CPJCONTELRAM_"+sGXsfl_138_fel_idx;
         edtCpjConWppNum_Internalname = "CPJCONWPPNUM_"+sGXsfl_138_fel_idx;
         edtCpjConEmail_Internalname = "CPJCONEMAIL_"+sGXsfl_138_fel_idx;
         edtCpjConLIn_Internalname = "CPJCONLIN_"+sGXsfl_138_fel_idx;
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR_"+sGXsfl_138_fel_idx;
         edtCliMatricula_Internalname = "CLIMATRICULA_"+sGXsfl_138_fel_idx;
         edtCpjTipoNome_Internalname = "CPJTIPONOME_"+sGXsfl_138_fel_idx;
         edtCpjNomeFan_Internalname = "CPJNOMEFAN_"+sGXsfl_138_fel_idx;
         edtCpjRazaoSoc_Internalname = "CPJRAZAOSOC_"+sGXsfl_138_fel_idx;
         edtCpjMatricula_Internalname = "CPJMATRICULA_"+sGXsfl_138_fel_idx;
         edtCpjCNPJFormat_Internalname = "CPJCNPJFORMAT_"+sGXsfl_138_fel_idx;
         edtCpjIE_Internalname = "CPJIE_"+sGXsfl_138_fel_idx;
         edtCpjCelNum_Internalname = "CPJCELNUM_"+sGXsfl_138_fel_idx;
         edtCpjTelNum_Internalname = "CPJTELNUM_"+sGXsfl_138_fel_idx;
         edtCpjTelRam_Internalname = "CPJTELRAM_"+sGXsfl_138_fel_idx;
         edtCpjWppNum_Internalname = "CPJWPPNUM_"+sGXsfl_138_fel_idx;
         edtCpjEmail_Internalname = "CPJEMAIL_"+sGXsfl_138_fel_idx;
         edtCpjWebsite_Internalname = "CPJWEBSITE_"+sGXsfl_138_fel_idx;
         edtCliID_Internalname = "CLIID_"+sGXsfl_138_fel_idx;
         edtCpjID_Internalname = "CPJID_"+sGXsfl_138_fel_idx;
         edtCpjConSeq_Internalname = "CPJCONSEQ_"+sGXsfl_138_fel_idx;
      }

      protected void sendrow_1382( )
      {
         SubsflControlProps_1382( ) ;
         WB4S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_138_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
         {
            GridRow = GXWebRow.GetNew(context,GridContainer);
            if ( subGrid_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGrid_Backstyle = 0;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
            }
            else if ( subGrid_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGrid_Backstyle = 0;
               subGrid_Backcolor = subGrid_Allbackcolor;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Uniform";
               }
            }
            else if ( subGrid_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Odd";
               }
               subGrid_Backcolor = (int)(0x0);
            }
            else if ( subGrid_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGrid_Backstyle = 1;
               if ( ((int)((nGXsfl_138_idx) % (2))) == 0 )
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Even";
                  }
               }
               else
               {
                  subGrid_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGrid_Class, "") != 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Odd";
                  }
               }
            }
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"GridWithPaginationBar WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_138_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 139,'',false,'"+sGXsfl_138_idx+"',138)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_138_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV98GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV98GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_138_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,139);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_138_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConNome_Internalname,(string)A275CpjConNome,StringUtil.RTrim( context.localUtil.Format( A275CpjConNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCpjConNome_Link,(string)"",(string)"",(string)"",(string)edtCpjConNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConNomePrim_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConNomePrim_Internalname,(string)A276CpjConNomePrim,StringUtil.RTrim( context.localUtil.Format( A276CpjConNomePrim, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConNomePrim_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConNomePrim_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConSobrenome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConSobrenome_Internalname,(string)A277CpjConSobrenome,StringUtil.RTrim( context.localUtil.Format( A277CpjConSobrenome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConSobrenome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConSobrenome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConTipoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConTipoNome_Internalname,(string)A272CpjConTipoNome,StringUtil.RTrim( context.localUtil.Format( A272CpjConTipoNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCpjConTipoNome_Link,(string)"",(string)"",(string)"",(string)edtCpjConTipoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConTipoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConCPFFormat_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConCPFFormat_Internalname,(string)A274CpjConCPFFormat,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConCPFFormat_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConCPFFormat_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\CPFFormat",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCpjConNascimento_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConNascimento_Internalname,context.localUtil.Format(A282CpjConNascimento, "99/99/99"),context.localUtil.Format( A282CpjConNascimento, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConNascimento_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConNascimento_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConGenNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConGenNome_Internalname,(string)A281CpjConGenNome,StringUtil.RTrim( context.localUtil.Format( A281CpjConGenNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConGenNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConGenNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConCelNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A285CpjConCelNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConCelNum_Internalname,StringUtil.RTrim( A285CpjConCelNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjConCelNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConCelNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConTelNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A283CpjConTelNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConTelNum_Internalname,StringUtil.RTrim( A283CpjConTelNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjConTelNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConTelNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConTelRam_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConTelRam_Internalname,(string)A284CpjConTelRam,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConTelRam_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConTelRam_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConWppNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A286CpjConWppNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConWppNum_Internalname,StringUtil.RTrim( A286CpjConWppNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjConWppNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConWppNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConEmail_Internalname,(string)A287CpjConEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A287CpjConEmail,(string)"",(string)"",(string)"",(string)edtCpjConEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjConLIn_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConLIn_Internalname,(string)A288CpjConLIn,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCpjConLIn_Link,(string)edtCpjConLIn_Linktarget,(string)"",(string)"",(string)edtCpjConLIn_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjConLIn_Visible,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCliNomeFamiliar_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliNomeFamiliar_Internalname,(string)A160CliNomeFamiliar,StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliNomeFamiliar_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCliNomeFamiliar_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCliMatricula_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliMatricula_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 15, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCliMatricula_Link,(string)"",(string)"",(string)"",(string)edtCliMatricula_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCliMatricula_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Matricula",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjTipoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjTipoNome_Internalname,(string)A367CpjTipoNome,StringUtil.RTrim( context.localUtil.Format( A367CpjTipoNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjTipoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjTipoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjNomeFan_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjNomeFan_Internalname,(string)A170CpjNomeFan,StringUtil.RTrim( context.localUtil.Format( A170CpjNomeFan, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjNomeFan_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjNomeFan_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjRazaoSoc_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjRazaoSoc_Internalname,(string)A171CpjRazaoSoc,StringUtil.RTrim( context.localUtil.Format( A171CpjRazaoSoc, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjRazaoSoc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjRazaoSoc_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtCpjMatricula_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjMatricula_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 15, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A176CpjMatricula), "ZZZ,ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjMatricula_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjMatricula_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)15,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Matricula",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjCNPJFormat_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjCNPJFormat_Internalname,(string)A188CpjCNPJFormat,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjCNPJFormat_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjCNPJFormat_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)18,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\CNPJFormatado",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjIE_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjIE_Internalname,(string)A189CpjIE,StringUtil.RTrim( context.localUtil.Format( A189CpjIE, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjIE_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjIE_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\InscricaoEstadual",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjCelNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A263CpjCelNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjCelNum_Internalname,StringUtil.RTrim( A263CpjCelNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjCelNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjCelNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjTelNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A261CpjTelNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjTelNum_Internalname,StringUtil.RTrim( A261CpjTelNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjTelNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjTelNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjTelRam_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjTelRam_Internalname,(string)A262CpjTelRam,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjTelRam_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjTelRam_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)10,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjWppNum_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            if ( context.isSmartDevice( ) )
            {
               gxphoneLink = "tel:" + StringUtil.RTrim( A264CpjWppNum);
            }
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjWppNum_Internalname,StringUtil.RTrim( A264CpjWppNum),(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)gxphoneLink,(string)"",(string)"",(string)"",(string)edtCpjWppNum_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjWppNum_Visible,(short)0,(short)0,(string)"tel",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Phone",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjEmail_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjEmail_Internalname,(string)A266CpjEmail,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"mailto:"+A266CpjEmail,(string)"",(string)"",(string)"",(string)edtCpjEmail_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjEmail_Visible,(short)0,(short)0,(string)"email",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Email",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtCpjWebsite_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjWebsite_Internalname,(string)A265CpjWebsite,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtCpjWebsite_Link,(string)edtCpjWebsite_Linktarget,(string)"",(string)"",(string)edtCpjWebsite_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtCpjWebsite_Visible,(short)0,(short)0,(string)"url",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)1000,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXus\\Url",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCliID_Internalname,A158CliID.ToString(),A158CliID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCliID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)138,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjID_Internalname,A166CpjID.ToString(),A166CpjID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)138,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtCpjConSeq_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A269CpjConSeq), "ZZZ9")),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtCpjConSeq_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)4,(short)0,(short)0,(short)138,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes4S2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_138_idx = ((subGrid_Islastpage==1)&&(nGXsfl_138_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_138_idx+1);
            sGXsfl_138_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_138_idx), 4, 0), 4, "0");
            SubsflControlProps_1382( ) ;
         }
         /* End function sendrow_1382 */
      }

      protected void init_web_controls( )
      {
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("CPJCONNOME", "Nome do Contato", 0);
         cmbavDynamicfiltersselector1.addItem("CPJTIPONOME", "Tipo", 0);
         cmbavDynamicfiltersselector1.addItem("CPJCONTIPONOME", "Tipo do Contato", 0);
         cmbavDynamicfiltersselector1.addItem("CPJCONGENSIGLA", "Gênero", 0);
         if ( cmbavDynamicfiltersselector1.ItemCount > 0 )
         {
            AV18DynamicFiltersSelector1 = cmbavDynamicfiltersselector1.getValidValue(AV18DynamicFiltersSelector1);
            AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         }
         cmbavDynamicfiltersoperator1.Name = "vDYNAMICFILTERSOPERATOR1";
         cmbavDynamicfiltersoperator1.WebTags = "";
         cmbavDynamicfiltersoperator1.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator1.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator1.ItemCount > 0 )
         {
            AV19DynamicFiltersOperator1 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator1.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         }
         cmbavDynamicfiltersselector2.Name = "vDYNAMICFILTERSSELECTOR2";
         cmbavDynamicfiltersselector2.WebTags = "";
         cmbavDynamicfiltersselector2.addItem("CPJCONNOME", "Nome do Contato", 0);
         cmbavDynamicfiltersselector2.addItem("CPJTIPONOME", "Tipo", 0);
         cmbavDynamicfiltersselector2.addItem("CPJCONTIPONOME", "Tipo do Contato", 0);
         cmbavDynamicfiltersselector2.addItem("CPJCONGENSIGLA", "Gênero", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV25DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV25DynamicFiltersSelector2);
            AssignAttri("", false, "AV25DynamicFiltersSelector2", AV25DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV26DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV26DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV26DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV26DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("CPJCONNOME", "Nome do Contato", 0);
         cmbavDynamicfiltersselector3.addItem("CPJTIPONOME", "Tipo", 0);
         cmbavDynamicfiltersselector3.addItem("CPJCONTIPONOME", "Tipo do Contato", 0);
         cmbavDynamicfiltersselector3.addItem("CPJCONGENSIGLA", "Gênero", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV32DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV32DynamicFiltersSelector3);
            AssignAttri("", false, "AV32DynamicFiltersSelector3", AV32DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV33DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV33DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV33DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV33DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_138_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV98GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV98GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV98GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl138( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"138\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "GridWithPaginationBar WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGrid_Backcolorstyle == 0 )
            {
               subGrid_Titlebackstyle = 0;
               if ( StringUtil.Len( subGrid_Class) > 0 )
               {
                  subGrid_Linesclass = subGrid_Class+"Title";
               }
            }
            else
            {
               subGrid_Titlebackstyle = 1;
               if ( subGrid_Backcolorstyle == 1 )
               {
                  subGrid_Titlebackcolor = subGrid_Allbackcolor;
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGrid_Class) > 0 )
                  {
                     subGrid_Linesclass = subGrid_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+cmbavGridactions_Class+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConNomePrim_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Primeiro Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConSobrenome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Sobrenome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConTipoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo do Contato") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConCPFFormat_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "CPF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConNascimento_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Dt. Nascimento") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConGenNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Gênero") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConCelNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Celular") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConTelNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConTelRam_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Ramal") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConWppNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "WhatsApp") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjConLIn_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "LinkedIn") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCliNomeFamiliar_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome Familiar") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCliMatricula_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Matrícula") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjTipoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjNomeFan_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome Fantasia") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjRazaoSoc_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Razão Social") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjMatricula_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Matrícula") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjCNPJFormat_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "CNPJ") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjIE_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "IE") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjCelNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Celular") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjTelNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjTelRam_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Ramal do Telefone") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjWppNum_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "WhatsApp") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjEmail_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "E-mail") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtCpjWebsite_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Website") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            if ( isAjaxCallMode( ) )
            {
               GridContainer = new GXWebGrid( context);
            }
            else
            {
               GridContainer.Clear();
            }
            GridContainer.SetWrapped(nGXWrapped);
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV98GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A275CpjConNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCpjConNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A276CpjConNomePrim));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConNomePrim_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A277CpjConSobrenome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConSobrenome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A272CpjConTipoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCpjConTipoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConTipoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A274CpjConCPFFormat));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConCPFFormat_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A282CpjConNascimento, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConNascimento_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A281CpjConGenNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConGenNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A285CpjConCelNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConCelNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A283CpjConTelNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConTelNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A284CpjConTelRam));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConTelRam_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A286CpjConWppNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConWppNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A287CpjConEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A288CpjConLIn));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCpjConLIn_Link));
            GridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtCpjConLIn_Linktarget));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjConLIn_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A160CliNomeFamiliar));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliNomeFamiliar_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 15, 0, ".", ""))));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCliMatricula_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCliMatricula_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A367CpjTipoNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjTipoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A170CpjNomeFan));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjNomeFan_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A171CpjRazaoSoc));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjRazaoSoc_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A176CpjMatricula), 15, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjMatricula_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A188CpjCNPJFormat));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjCNPJFormat_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A189CpjIE));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjIE_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A263CpjCelNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjCelNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A261CpjTelNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjTelNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A262CpjTelRam));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjTelRam_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( A264CpjWppNum)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjWppNum_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A266CpjEmail));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjEmail_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A265CpjWebsite));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtCpjWebsite_Link));
            GridColumn.AddObjectProperty("Linktarget", StringUtil.RTrim( edtCpjWebsite_Linktarget));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtCpjWebsite_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A158CliID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A166CpjID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectedindex), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowselection), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Selectioncolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowhovering), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Hoveringcolor), 9, 0, ".", "")));
            GridContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Allowcollapsing), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void init_default_properties( )
      {
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         lblDynamicfiltersprefix1_Internalname = "DYNAMICFILTERSPREFIX1";
         cmbavDynamicfiltersselector1_Internalname = "vDYNAMICFILTERSSELECTOR1";
         lblDynamicfiltersmiddle1_Internalname = "DYNAMICFILTERSMIDDLE1";
         cmbavDynamicfiltersoperator1_Internalname = "vDYNAMICFILTERSOPERATOR1";
         edtavCpjconnome1_Internalname = "vCPJCONNOME1";
         cellFilter_cpjconnome1_cell_Internalname = "FILTER_CPJCONNOME1_CELL";
         edtavCpjtiponome1_Internalname = "vCPJTIPONOME1";
         cellFilter_cpjtiponome1_cell_Internalname = "FILTER_CPJTIPONOME1_CELL";
         edtavCpjcontiponome1_Internalname = "vCPJCONTIPONOME1";
         cellFilter_cpjcontiponome1_cell_Internalname = "FILTER_CPJCONTIPONOME1_CELL";
         edtavCpjcongensigla1_Internalname = "vCPJCONGENSIGLA1";
         cellFilter_cpjcongensigla1_cell_Internalname = "FILTER_CPJCONGENSIGLA1_CELL";
         imgAdddynamicfilters1_Internalname = "ADDDYNAMICFILTERS1";
         cellDynamicfilters_addfilter1_cell_Internalname = "DYNAMICFILTERS_ADDFILTER1_CELL";
         imgRemovedynamicfilters1_Internalname = "REMOVEDYNAMICFILTERS1";
         cellDynamicfilters_removefilter1_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER1_CELL";
         tblTablemergeddynamicfilters1_Internalname = "TABLEMERGEDDYNAMICFILTERS1";
         divTabledynamicfiltersrow1_Internalname = "TABLEDYNAMICFILTERSROW1";
         lblDynamicfiltersprefix2_Internalname = "DYNAMICFILTERSPREFIX2";
         cmbavDynamicfiltersselector2_Internalname = "vDYNAMICFILTERSSELECTOR2";
         lblDynamicfiltersmiddle2_Internalname = "DYNAMICFILTERSMIDDLE2";
         cmbavDynamicfiltersoperator2_Internalname = "vDYNAMICFILTERSOPERATOR2";
         edtavCpjconnome2_Internalname = "vCPJCONNOME2";
         cellFilter_cpjconnome2_cell_Internalname = "FILTER_CPJCONNOME2_CELL";
         edtavCpjtiponome2_Internalname = "vCPJTIPONOME2";
         cellFilter_cpjtiponome2_cell_Internalname = "FILTER_CPJTIPONOME2_CELL";
         edtavCpjcontiponome2_Internalname = "vCPJCONTIPONOME2";
         cellFilter_cpjcontiponome2_cell_Internalname = "FILTER_CPJCONTIPONOME2_CELL";
         edtavCpjcongensigla2_Internalname = "vCPJCONGENSIGLA2";
         cellFilter_cpjcongensigla2_cell_Internalname = "FILTER_CPJCONGENSIGLA2_CELL";
         imgAdddynamicfilters2_Internalname = "ADDDYNAMICFILTERS2";
         cellDynamicfilters_addfilter2_cell_Internalname = "DYNAMICFILTERS_ADDFILTER2_CELL";
         imgRemovedynamicfilters2_Internalname = "REMOVEDYNAMICFILTERS2";
         cellDynamicfilters_removefilter2_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER2_CELL";
         tblTablemergeddynamicfilters2_Internalname = "TABLEMERGEDDYNAMICFILTERS2";
         divTabledynamicfiltersrow2_Internalname = "TABLEDYNAMICFILTERSROW2";
         lblDynamicfiltersprefix3_Internalname = "DYNAMICFILTERSPREFIX3";
         cmbavDynamicfiltersselector3_Internalname = "vDYNAMICFILTERSSELECTOR3";
         lblDynamicfiltersmiddle3_Internalname = "DYNAMICFILTERSMIDDLE3";
         cmbavDynamicfiltersoperator3_Internalname = "vDYNAMICFILTERSOPERATOR3";
         edtavCpjconnome3_Internalname = "vCPJCONNOME3";
         cellFilter_cpjconnome3_cell_Internalname = "FILTER_CPJCONNOME3_CELL";
         edtavCpjtiponome3_Internalname = "vCPJTIPONOME3";
         cellFilter_cpjtiponome3_cell_Internalname = "FILTER_CPJTIPONOME3_CELL";
         edtavCpjcontiponome3_Internalname = "vCPJCONTIPONOME3";
         cellFilter_cpjcontiponome3_cell_Internalname = "FILTER_CPJCONTIPONOME3_CELL";
         edtavCpjcongensigla3_Internalname = "vCPJCONGENSIGLA3";
         cellFilter_cpjcongensigla3_cell_Internalname = "FILTER_CPJCONGENSIGLA3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtCpjConNome_Internalname = "CPJCONNOME";
         edtCpjConNomePrim_Internalname = "CPJCONNOMEPRIM";
         edtCpjConSobrenome_Internalname = "CPJCONSOBRENOME";
         edtCpjConTipoNome_Internalname = "CPJCONTIPONOME";
         edtCpjConCPFFormat_Internalname = "CPJCONCPFFORMAT";
         edtCpjConNascimento_Internalname = "CPJCONNASCIMENTO";
         edtCpjConGenNome_Internalname = "CPJCONGENNOME";
         edtCpjConCelNum_Internalname = "CPJCONCELNUM";
         edtCpjConTelNum_Internalname = "CPJCONTELNUM";
         edtCpjConTelRam_Internalname = "CPJCONTELRAM";
         edtCpjConWppNum_Internalname = "CPJCONWPPNUM";
         edtCpjConEmail_Internalname = "CPJCONEMAIL";
         edtCpjConLIn_Internalname = "CPJCONLIN";
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR";
         edtCliMatricula_Internalname = "CLIMATRICULA";
         edtCpjTipoNome_Internalname = "CPJTIPONOME";
         edtCpjNomeFan_Internalname = "CPJNOMEFAN";
         edtCpjRazaoSoc_Internalname = "CPJRAZAOSOC";
         edtCpjMatricula_Internalname = "CPJMATRICULA";
         edtCpjCNPJFormat_Internalname = "CPJCNPJFORMAT";
         edtCpjIE_Internalname = "CPJIE";
         edtCpjCelNum_Internalname = "CPJCELNUM";
         edtCpjTelNum_Internalname = "CPJTELNUM";
         edtCpjTelRam_Internalname = "CPJTELRAM";
         edtCpjWppNum_Internalname = "CPJWPPNUM";
         edtCpjEmail_Internalname = "CPJEMAIL";
         edtCpjWebsite_Internalname = "CPJWEBSITE";
         edtCliID_Internalname = "CLIID";
         edtCpjID_Internalname = "CPJID";
         edtCpjConSeq_Internalname = "CPJCONSEQ";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_titlescategories_Internalname = "GRID_TITLESCATEGORIES";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_cpjconnascimentoauxdatetext_Internalname = "vDDO_CPJCONNASCIMENTOAUXDATETEXT";
         Tfcpjconnascimento_rangepicker_Internalname = "TFCPJCONNASCIMENTO_RANGEPICKER";
         divDdo_cpjconnascimentoauxdates_Internalname = "DDO_CPJCONNASCIMENTOAUXDATES";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGrid_Internalname = "GRID";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGrid_Allowcollapsing = 0;
         subGrid_Allowselection = 0;
         subGrid_Header = "";
         edtCpjConSeq_Jsonclick = "";
         edtCpjID_Jsonclick = "";
         edtCliID_Jsonclick = "";
         edtCpjWebsite_Jsonclick = "";
         edtCpjWebsite_Linktarget = "";
         edtCpjWebsite_Link = "";
         edtCpjEmail_Jsonclick = "";
         edtCpjWppNum_Jsonclick = "";
         edtCpjTelRam_Jsonclick = "";
         edtCpjTelNum_Jsonclick = "";
         edtCpjCelNum_Jsonclick = "";
         edtCpjIE_Jsonclick = "";
         edtCpjCNPJFormat_Jsonclick = "";
         edtCpjMatricula_Jsonclick = "";
         edtCpjRazaoSoc_Jsonclick = "";
         edtCpjNomeFan_Jsonclick = "";
         edtCpjTipoNome_Jsonclick = "";
         edtCliMatricula_Jsonclick = "";
         edtCliMatricula_Link = "";
         edtCliNomeFamiliar_Jsonclick = "";
         edtCpjConLIn_Jsonclick = "";
         edtCpjConLIn_Linktarget = "";
         edtCpjConLIn_Link = "";
         edtCpjConEmail_Jsonclick = "";
         edtCpjConWppNum_Jsonclick = "";
         edtCpjConTelRam_Jsonclick = "";
         edtCpjConTelNum_Jsonclick = "";
         edtCpjConCelNum_Jsonclick = "";
         edtCpjConGenNome_Jsonclick = "";
         edtCpjConNascimento_Jsonclick = "";
         edtCpjConCPFFormat_Jsonclick = "";
         edtCpjConTipoNome_Jsonclick = "";
         edtCpjConTipoNome_Link = "";
         edtCpjConSobrenome_Jsonclick = "";
         edtCpjConNomePrim_Jsonclick = "";
         edtCpjConNome_Jsonclick = "";
         edtCpjConNome_Link = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         imgRemovedynamicfilters1_Visible = 1;
         imgAdddynamicfilters1_Visible = 1;
         edtavCpjcongensigla1_Jsonclick = "";
         edtavCpjcongensigla1_Enabled = 1;
         edtavCpjcontiponome1_Jsonclick = "";
         edtavCpjcontiponome1_Enabled = 1;
         edtavCpjtiponome1_Jsonclick = "";
         edtavCpjtiponome1_Enabled = 1;
         edtavCpjconnome1_Jsonclick = "";
         edtavCpjconnome1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavCpjcongensigla2_Jsonclick = "";
         edtavCpjcongensigla2_Enabled = 1;
         edtavCpjcontiponome2_Jsonclick = "";
         edtavCpjcontiponome2_Enabled = 1;
         edtavCpjtiponome2_Jsonclick = "";
         edtavCpjtiponome2_Enabled = 1;
         edtavCpjconnome2_Jsonclick = "";
         edtavCpjconnome2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavCpjcongensigla3_Jsonclick = "";
         edtavCpjcongensigla3_Enabled = 1;
         edtavCpjcontiponome3_Jsonclick = "";
         edtavCpjcontiponome3_Enabled = 1;
         edtavCpjtiponome3_Jsonclick = "";
         edtavCpjtiponome3_Enabled = 1;
         edtavCpjconnome3_Jsonclick = "";
         edtavCpjconnome3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavCpjcongensigla3_Visible = 1;
         edtavCpjcontiponome3_Visible = 1;
         edtavCpjtiponome3_Visible = 1;
         edtavCpjconnome3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavCpjcongensigla2_Visible = 1;
         edtavCpjcontiponome2_Visible = 1;
         edtavCpjtiponome2_Visible = 1;
         edtavCpjconnome2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavCpjcongensigla1_Visible = 1;
         edtavCpjcontiponome1_Visible = 1;
         edtavCpjtiponome1_Visible = 1;
         edtavCpjconnome1_Visible = 1;
         edtCpjWebsite_Visible = -1;
         edtCpjEmail_Visible = -1;
         edtCpjWppNum_Visible = -1;
         edtCpjTelRam_Visible = -1;
         edtCpjTelNum_Visible = -1;
         edtCpjCelNum_Visible = -1;
         edtCpjIE_Visible = -1;
         edtCpjCNPJFormat_Visible = -1;
         edtCpjMatricula_Visible = -1;
         edtCpjRazaoSoc_Visible = -1;
         edtCpjNomeFan_Visible = -1;
         edtCpjTipoNome_Visible = -1;
         edtCliMatricula_Visible = -1;
         edtCliNomeFamiliar_Visible = -1;
         edtCpjConLIn_Visible = -1;
         edtCpjConEmail_Visible = -1;
         edtCpjConWppNum_Visible = -1;
         edtCpjConTelRam_Visible = -1;
         edtCpjConTelNum_Visible = -1;
         edtCpjConCelNum_Visible = -1;
         edtCpjConGenNome_Visible = -1;
         edtCpjConNascimento_Visible = -1;
         edtCpjConCPFFormat_Visible = -1;
         edtCpjConTipoNome_Visible = -1;
         edtCpjConSobrenome_Visible = -1;
         edtCpjConNomePrim_Visible = -1;
         edtCpjConNome_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_cpjconnascimentoauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Grid_empowerer_Hascategories = Convert.ToBoolean( -1);
         Grid_titlescategories_Gridtitlescategories = ";;;;;;;;;;;;;;Cliente;Cliente;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;Unidade;;;";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Innewwindow1_Target = "";
         Innewwindow1_Height = "50";
         Innewwindow1_Width = "50";
         Ddo_grid_Format = "||||||||||||||12.0||||12.0||||||||";
         Ddo_grid_Datalistproc = "core.ClientePJContatoWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic||Dynamic|Dynamic|Dynamic||Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T|T|T|T|T||T|T|T|T|T|T|T|T||T|T|T||T|T|T|T|T|T|T|T";
         Ddo_grid_Filterisrange = "|||||P|||||||||T||||T||||||||";
         Ddo_grid_Filtertype = "Character|Character|Character|Character|Character|Date|Character|Character|Character|Character|Character|Character|Character|Character|Numeric|Character|Character|Character|Numeric|Character|Character|Character|Character|Character|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3|4|5|6|7|8|9|10|11|12|13|14|15|16|17|18|19|20|21|22|23|24|25|26|27";
         Ddo_grid_Columnids = "1:CpjConNome|2:CpjConNomePrim|3:CpjConSobrenome|4:CpjConTipoNome|5:CpjConCPFFormat|6:CpjConNascimento|7:CpjConGenNome|8:CpjConCelNum|9:CpjConTelNum|10:CpjConTelRam|11:CpjConWppNum|12:CpjConEmail|13:CpjConLIn|14:CliNomeFamiliar|15:CliMatricula|16:CpjTipoNome|17:CpjNomeFan|18:CpjRazaoSoc|19:CpjMatricula|20:CpjCNPJFormat|21:CpjIE|22:CpjCelNum|23:CpjTelNum|24:CpjTelRam|25:CpjWppNum|26:CpjEmail|27:CpjWebsite";
         Ddo_grid_Gridinternalname = "";
         Ddc_subscriptions_Titlecontrolidtoreplace = "";
         Ddc_subscriptions_Cls = "ColumnsSelector";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Caption = "";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Ddo_agexport_Titlecontrolidtoreplace = "";
         Ddo_agexport_Cls = "ColumnsSelector";
         Ddo_agexport_Icon = "fas fa-download";
         Ddo_agexport_Icontype = "FontIcon";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "Página <CURRENT_PAGE> de <TOTAL_PAGES>";
         Gridpaginationbar_Last = "WWP_PagingLastCaption";
         Gridpaginationbar_Next = "WWP_PagingNextCaption";
         Gridpaginationbar_Previous = "WWP_PagingPreviousCaption";
         Gridpaginationbar_First = "WWP_PagingFirstCaption";
         Gridpaginationbar_Rowsperpageoptions = "5:WWP_Rows5,10:WWP_Rows10,20:WWP_Rows20,50:WWP_Rows50";
         Gridpaginationbar_Rowsperpageselectedvalue = 10;
         Gridpaginationbar_Rowsperpageselector = Convert.ToBoolean( -1);
         Gridpaginationbar_Emptygridclass = "PaginationBarEmptyGrid";
         Gridpaginationbar_Pagingcaptionposition = "Left";
         Gridpaginationbar_Pagingbuttonsposition = "Left";
         Gridpaginationbar_Pagestoshow = 5;
         Gridpaginationbar_Showlast = Convert.ToBoolean( -1);
         Gridpaginationbar_Shownext = Convert.ToBoolean( -1);
         Gridpaginationbar_Showprevious = Convert.ToBoolean( -1);
         Gridpaginationbar_Showfirst = Convert.ToBoolean( -1);
         Gridpaginationbar_Class = "PaginationBar";
         Ddo_managefilters_Cls = "ManageFilters";
         Ddo_managefilters_Tooltip = "WWP_ManageFiltersTooltip";
         Ddo_managefilters_Icon = "fas fa-filter";
         Ddo_managefilters_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = " Contato";
         subGrid_Rows = 0;
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E124S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E134S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E164S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E294S2',iparms:[{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:'',hsh:true},{av:'A166CpjID',fld:'CPJID',pic:'',hsh:true},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'A270CpjConTipoID',fld:'CPJCONTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A288CpjConLIn',fld:'CPJCONLIN',pic:''},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'A265CpjWebsite',fld:'CPJWEBSITE',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV98GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtCpjConNome_Link',ctrl:'CPJCONNOME',prop:'Link'},{av:'edtCpjConTipoNome_Link',ctrl:'CPJCONTIPONOME',prop:'Link'},{av:'edtCpjConLIn_Linktarget',ctrl:'CPJCONLIN',prop:'Linktarget'},{av:'edtCpjConLIn_Link',ctrl:'CPJCONLIN',prop:'Link'},{av:'edtCliMatricula_Link',ctrl:'CLIMATRICULA',prop:'Link'},{av:'edtCpjWebsite_Linktarget',ctrl:'CPJWEBSITE',prop:'Linktarget'},{av:'edtCpjWebsite_Link',ctrl:'CPJWEBSITE',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E174S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E224S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E184S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E234S2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E244S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E194S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E254S2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E204S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E264S2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E304S2',iparms:[{av:'cmbavGridactions'},{av:'AV98GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:'',hsh:true},{av:'A166CpjID',fld:'CPJID',pic:'',hsh:true},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV98GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E214S2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:'',hsh:true},{av:'A166CpjID',fld:'CPJID',pic:'',hsh:true},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtCpjConNome_Visible',ctrl:'CPJCONNOME',prop:'Visible'},{av:'edtCpjConNomePrim_Visible',ctrl:'CPJCONNOMEPRIM',prop:'Visible'},{av:'edtCpjConSobrenome_Visible',ctrl:'CPJCONSOBRENOME',prop:'Visible'},{av:'edtCpjConTipoNome_Visible',ctrl:'CPJCONTIPONOME',prop:'Visible'},{av:'edtCpjConCPFFormat_Visible',ctrl:'CPJCONCPFFORMAT',prop:'Visible'},{av:'edtCpjConNascimento_Visible',ctrl:'CPJCONNASCIMENTO',prop:'Visible'},{av:'edtCpjConGenNome_Visible',ctrl:'CPJCONGENNOME',prop:'Visible'},{av:'edtCpjConCelNum_Visible',ctrl:'CPJCONCELNUM',prop:'Visible'},{av:'edtCpjConTelNum_Visible',ctrl:'CPJCONTELNUM',prop:'Visible'},{av:'edtCpjConTelRam_Visible',ctrl:'CPJCONTELRAM',prop:'Visible'},{av:'edtCpjConWppNum_Visible',ctrl:'CPJCONWPPNUM',prop:'Visible'},{av:'edtCpjConEmail_Visible',ctrl:'CPJCONEMAIL',prop:'Visible'},{av:'edtCpjConLIn_Visible',ctrl:'CPJCONLIN',prop:'Visible'},{av:'edtCliNomeFamiliar_Visible',ctrl:'CLINOMEFAMILIAR',prop:'Visible'},{av:'edtCliMatricula_Visible',ctrl:'CLIMATRICULA',prop:'Visible'},{av:'edtCpjTipoNome_Visible',ctrl:'CPJTIPONOME',prop:'Visible'},{av:'edtCpjNomeFan_Visible',ctrl:'CPJNOMEFAN',prop:'Visible'},{av:'edtCpjRazaoSoc_Visible',ctrl:'CPJRAZAOSOC',prop:'Visible'},{av:'edtCpjMatricula_Visible',ctrl:'CPJMATRICULA',prop:'Visible'},{av:'edtCpjCNPJFormat_Visible',ctrl:'CPJCNPJFORMAT',prop:'Visible'},{av:'edtCpjIE_Visible',ctrl:'CPJIE',prop:'Visible'},{av:'edtCpjCelNum_Visible',ctrl:'CPJCELNUM',prop:'Visible'},{av:'edtCpjTelNum_Visible',ctrl:'CPJTELNUM',prop:'Visible'},{av:'edtCpjTelRam_Visible',ctrl:'CPJTELRAM',prop:'Visible'},{av:'edtCpjWppNum_Visible',ctrl:'CPJWPPNUM',prop:'Visible'},{av:'edtCpjEmail_Visible',ctrl:'CPJEMAIL',prop:'Visible'},{av:'edtCpjWebsite_Visible',ctrl:'CPJWEBSITE',prop:'Visible'},{av:'AV95GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV96GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV97GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV47ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E144S2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20CpjConNome1',fld:'vCPJCONNOME1',pic:'@!'},{av:'AV21CpjTipoNome1',fld:'vCPJTIPONOME1',pic:'@!'},{av:'AV22CpjConTipoNome1',fld:'vCPJCONTIPONOME1',pic:'@!'},{av:'AV23CpjConGenSigla1',fld:'vCPJCONGENSIGLA1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV25DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV26DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV27CpjConNome2',fld:'vCPJCONNOME2',pic:'@!'},{av:'AV28CpjTipoNome2',fld:'vCPJTIPONOME2',pic:'@!'},{av:'AV29CpjConTipoNome2',fld:'vCPJCONTIPONOME2',pic:'@!'},{av:'AV30CpjConGenSigla2',fld:'vCPJCONGENSIGLA2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV32DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV33DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV34CpjConNome3',fld:'vCPJCONNOME3',pic:'@!'},{av:'AV35CpjTipoNome3',fld:'vCPJTIPONOME3',pic:'@!'},{av:'AV36CpjConTipoNome3',fld:'vCPJCONTIPONOME3',pic:'@!'},{av:'AV37CpjConGenSigla3',fld:'vCPJCONGENSIGLA3',pic:''},{av:'AV49ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV24DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV31DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV44ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV125Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV50TFCpjConNome',fld:'vTFCPJCONNOME',pic:'@!'},{av:'AV51TFCpjConNome_Sel',fld:'vTFCPJCONNOME_SEL',pic:'@!'},{av:'AV52TFCpjConNomePrim',fld:'vTFCPJCONNOMEPRIM',pic:'@!'},{av:'AV53TFCpjConNomePrim_Sel',fld:'vTFCPJCONNOMEPRIM_SEL',pic:'@!'},{av:'AV54TFCpjConSobrenome',fld:'vTFCPJCONSOBRENOME',pic:'@!'},{av:'AV55TFCpjConSobrenome_Sel',fld:'vTFCPJCONSOBRENOME_SEL',pic:'@!'},{av:'AV56TFCpjConTipoNome',fld:'vTFCPJCONTIPONOME',pic:'@!'},{av:'AV57TFCpjConTipoNome_Sel',fld:'vTFCPJCONTIPONOME_SEL',pic:'@!'},{av:'AV58TFCpjConCPFFormat',fld:'vTFCPJCONCPFFORMAT',pic:''},{av:'AV59TFCpjConCPFFormat_Sel',fld:'vTFCPJCONCPFFORMAT_SEL',pic:''},{av:'AV60TFCpjConNascimento',fld:'vTFCPJCONNASCIMENTO',pic:''},{av:'AV61TFCpjConNascimento_To',fld:'vTFCPJCONNASCIMENTO_TO',pic:''},{av:'AV65TFCpjConGenNome',fld:'vTFCPJCONGENNOME',pic:'@!'},{av:'AV66TFCpjConGenNome_Sel',fld:'vTFCPJCONGENNOME_SEL',pic:'@!'},{av:'AV67TFCpjConCelNum',fld:'vTFCPJCONCELNUM',pic:''},{av:'AV68TFCpjConCelNum_Sel',fld:'vTFCPJCONCELNUM_SEL',pic:''},{av:'AV69TFCpjConTelNum',fld:'vTFCPJCONTELNUM',pic:''},{av:'AV70TFCpjConTelNum_Sel',fld:'vTFCPJCONTELNUM_SEL',pic:''},{av:'AV71TFCpjConTelRam',fld:'vTFCPJCONTELRAM',pic:''},{av:'AV72TFCpjConTelRam_Sel',fld:'vTFCPJCONTELRAM_SEL',pic:''},{av:'AV89TFCpjConWppNum',fld:'vTFCPJCONWPPNUM',pic:''},{av:'AV90TFCpjConWppNum_Sel',fld:'vTFCPJCONWPPNUM_SEL',pic:''},{av:'AV73TFCpjConEmail',fld:'vTFCPJCONEMAIL',pic:''},{av:'AV74TFCpjConEmail_Sel',fld:'vTFCPJCONEMAIL_SEL',pic:''},{av:'AV75TFCpjConLIn',fld:'vTFCPJCONLIN',pic:''},{av:'AV76TFCpjConLIn_Sel',fld:'vTFCPJCONLIN_SEL',pic:''},{av:'AV79TFCliNomeFamiliar',fld:'vTFCLINOMEFAMILIAR',pic:'@!'},{av:'AV80TFCliNomeFamiliar_Sel',fld:'vTFCLINOMEFAMILIAR_SEL',pic:'@!'},{av:'AV77TFCliMatricula',fld:'vTFCLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV78TFCliMatricula_To',fld:'vTFCLIMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV81TFCpjTipoNome',fld:'vTFCPJTIPONOME',pic:'@!'},{av:'AV82TFCpjTipoNome_Sel',fld:'vTFCPJTIPONOME_SEL',pic:'@!'},{av:'AV83TFCpjNomeFan',fld:'vTFCPJNOMEFAN',pic:'@!'},{av:'AV84TFCpjNomeFan_Sel',fld:'vTFCPJNOMEFAN_SEL',pic:'@!'},{av:'AV85TFCpjRazaoSoc',fld:'vTFCPJRAZAOSOC',pic:'@!'},{av:'AV86TFCpjRazaoSoc_Sel',fld:'vTFCPJRAZAOSOC_SEL',pic:'@!'},{av:'AV103TFCpjMatricula',fld:'vTFCPJMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV104TFCpjMatricula_To',fld:'vTFCPJMATRICULA_TO',pic:'ZZZ,ZZZ,ZZZ,ZZ9'},{av:'AV105TFCpjCNPJFormat',fld:'vTFCPJCNPJFORMAT',pic:''},{av:'AV106TFCpjCNPJFormat_Sel',fld:'vTFCPJCNPJFORMAT_SEL',pic:''},{av:'AV107TFCpjIE',fld:'vTFCPJIE',pic:'@!'},{av:'AV108TFCpjIE_Sel',fld:'vTFCPJIE_SEL',pic:'@!'},{av:'AV109TFCpjCelNum',fld:'vTFCPJCELNUM',pic:''},{av:'AV110TFCpjCelNum_Sel',fld:'vTFCPJCELNUM_SEL',pic:''},{av:'AV111TFCpjTelNum',fld:'vTFCPJTELNUM',pic:''},{av:'AV112TFCpjTelNum_Sel',fld:'vTFCPJTELNUM_SEL',pic:''},{av:'AV113TFCpjTelRam',fld:'vTFCPJTELRAM',pic:''},{av:'AV114TFCpjTelRam_Sel',fld:'vTFCPJTELRAM_SEL',pic:''},{av:'AV115TFCpjWppNum',fld:'vTFCPJWPPNUM',pic:''},{av:'AV116TFCpjWppNum_Sel',fld:'vTFCPJWPPNUM_SEL',pic:''},{av:'AV117TFCpjEmail',fld:'vTFCPJEMAIL',pic:''},{av:'AV118TFCpjEmail_Sel',fld:'vTFCPJEMAIL_SEL',pic:''},{av:'AV119TFCpjWebsite',fld:'vTFCPJWEBSITE',pic:''},{av:'AV120TFCpjWebsite_Sel',fld:'vTFCPJWEBSITE_SEL',pic:''},{av:'AV39DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV38DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV122IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV123IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV121IsAuthorized_CpjConNome',fld:'vISAUTHORIZED_CPJCONNOME',pic:'',hsh:true},{av:'AV99IsAuthorized_CpjConTipoNome',fld:'vISAUTHORIZED_CPJCONTIPONOME',pic:'',hsh:true},{av:'AV100IsAuthorized_CliMatricula',fld:'vISAUTHORIZED_CLIMATRICULA',pic:'',hsh:true},{av:'AV124IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavCpjconnome1_Visible',ctrl:'vCPJCONNOME1',prop:'Visible'},{av:'edtavCpjtiponome1_Visible',ctrl:'vCPJTIPONOME1',prop:'Visible'},{av:'edtavCpjcontiponome1_Visible',ctrl:'vCPJCONTIPONOME1',prop:'Visible'},{av:'edtavCpjcongensigla1_Visible',ctrl:'vCPJCONGENSIGLA1',prop:'Visible'},{av:'edtavCpjconnome2_Visible',ctrl:'vCPJCONNOME2',prop:'Visible'},{av:'edtavCpjtiponome2_Visible',ctrl:'vCPJTIPONOME2',prop:'Visible'},{av:'edtavCpjcontiponome2_Visible',ctrl:'vCPJCONTIPONOME2',prop:'Visible'},{av:'edtavCpjcongensigla2_Visible',ctrl:'vCPJCONGENSIGLA2',prop:'Visible'},{av:'edtavCpjconnome3_Visible',ctrl:'vCPJCONNOME3',prop:'Visible'},{av:'edtavCpjtiponome3_Visible',ctrl:'vCPJTIPONOME3',prop:'Visible'},{av:'edtavCpjcontiponome3_Visible',ctrl:'vCPJCONTIPONOME3',prop:'Visible'},{av:'edtavCpjcongensigla3_Visible',ctrl:'vCPJCONGENSIGLA3',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E154S2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("VALID_CLIID","{handler:'Valid_Cliid',iparms:[]");
         setEventMetadata("VALID_CLIID",",oparms:[]}");
         setEventMetadata("VALID_CPJID","{handler:'Valid_Cpjid',iparms:[]");
         setEventMetadata("VALID_CPJID",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Cpjconseq',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         return  ;
      }

      public override void cleanup( )
      {
         flushBuffer();
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections();
         }
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         Gridpaginationbar_Selectedpage = "";
         Ddo_grid_Activeeventkey = "";
         Ddo_grid_Selectedvalue_get = "";
         Ddo_grid_Filteredtextto_get = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_grid_Selectedcolumn = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20CpjConNome1 = "";
         AV21CpjTipoNome1 = "";
         AV22CpjConTipoNome1 = "";
         AV23CpjConGenSigla1 = "";
         AV25DynamicFiltersSelector2 = "";
         AV27CpjConNome2 = "";
         AV28CpjTipoNome2 = "";
         AV29CpjConTipoNome2 = "";
         AV30CpjConGenSigla2 = "";
         AV32DynamicFiltersSelector3 = "";
         AV34CpjConNome3 = "";
         AV35CpjTipoNome3 = "";
         AV36CpjConTipoNome3 = "";
         AV37CpjConGenSigla3 = "";
         AV44ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV125Pgmname = "";
         AV50TFCpjConNome = "";
         AV51TFCpjConNome_Sel = "";
         AV52TFCpjConNomePrim = "";
         AV53TFCpjConNomePrim_Sel = "";
         AV54TFCpjConSobrenome = "";
         AV55TFCpjConSobrenome_Sel = "";
         AV56TFCpjConTipoNome = "";
         AV57TFCpjConTipoNome_Sel = "";
         AV58TFCpjConCPFFormat = "";
         AV59TFCpjConCPFFormat_Sel = "";
         AV60TFCpjConNascimento = DateTime.MinValue;
         AV61TFCpjConNascimento_To = DateTime.MinValue;
         AV65TFCpjConGenNome = "";
         AV66TFCpjConGenNome_Sel = "";
         AV67TFCpjConCelNum = "";
         AV68TFCpjConCelNum_Sel = "";
         AV69TFCpjConTelNum = "";
         AV70TFCpjConTelNum_Sel = "";
         AV71TFCpjConTelRam = "";
         AV72TFCpjConTelRam_Sel = "";
         AV89TFCpjConWppNum = "";
         AV90TFCpjConWppNum_Sel = "";
         AV73TFCpjConEmail = "";
         AV74TFCpjConEmail_Sel = "";
         AV75TFCpjConLIn = "";
         AV76TFCpjConLIn_Sel = "";
         AV79TFCliNomeFamiliar = "";
         AV80TFCliNomeFamiliar_Sel = "";
         AV81TFCpjTipoNome = "";
         AV82TFCpjTipoNome_Sel = "";
         AV83TFCpjNomeFan = "";
         AV84TFCpjNomeFan_Sel = "";
         AV85TFCpjRazaoSoc = "";
         AV86TFCpjRazaoSoc_Sel = "";
         AV105TFCpjCNPJFormat = "";
         AV106TFCpjCNPJFormat_Sel = "";
         AV107TFCpjIE = "";
         AV108TFCpjIE_Sel = "";
         AV109TFCpjCelNum = "";
         AV110TFCpjCelNum_Sel = "";
         AV111TFCpjTelNum = "";
         AV112TFCpjTelNum_Sel = "";
         AV113TFCpjTelRam = "";
         AV114TFCpjTelRam_Sel = "";
         AV115TFCpjWppNum = "";
         AV116TFCpjWppNum_Sel = "";
         AV117TFCpjEmail = "";
         AV118TFCpjEmail_Sel = "";
         AV119TFCpjWebsite = "";
         AV120TFCpjWebsite_Sel = "";
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV47ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV97GridAppliedFilters = "";
         AV101AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV91DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV62DDO_CpjConNascimentoAuxDate = DateTime.MinValue;
         AV63DDO_CpjConNascimentoAuxDateTo = DateTime.MinValue;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_titlescategories_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtninsert_Jsonclick = "";
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
         lblDynamicfiltersprefix1_Jsonclick = "";
         lblDynamicfiltersmiddle1_Jsonclick = "";
         lblDynamicfiltersprefix2_Jsonclick = "";
         lblDynamicfiltersmiddle2_Jsonclick = "";
         lblDynamicfiltersprefix3_Jsonclick = "";
         lblDynamicfiltersmiddle3_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         lblJsdynamicfilters_Jsonclick = "";
         ucDdo_grid = new GXUserControl();
         ucInnewwindow1 = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_titlescategories = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV64DDO_CpjConNascimentoAuxDateText = "";
         ucTfcpjconnascimento_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A275CpjConNome = "";
         A276CpjConNomePrim = "";
         A277CpjConSobrenome = "";
         A272CpjConTipoNome = "";
         A274CpjConCPFFormat = "";
         A282CpjConNascimento = DateTime.MinValue;
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
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         scmdbuf = "";
         lV126Core_clientepjcontatowwds_1_filterfulltext = "";
         lV129Core_clientepjcontatowwds_4_cpjconnome1 = "";
         lV130Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         lV131Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         lV132Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         lV136Core_clientepjcontatowwds_11_cpjconnome2 = "";
         lV137Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         lV138Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         lV139Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         lV143Core_clientepjcontatowwds_18_cpjconnome3 = "";
         lV144Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         lV145Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         lV146Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         lV147Core_clientepjcontatowwds_22_tfcpjconnome = "";
         lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         lV153Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         lV159Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         lV161Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         lV163Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         lV165Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         lV167Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         lV169Core_clientepjcontatowwds_44_tfcpjconemail = "";
         lV171Core_clientepjcontatowwds_46_tfcpjconlin = "";
         lV173Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         lV177Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         lV179Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         lV187Core_clientepjcontatowwds_62_tfcpjie = "";
         lV189Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         lV191Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         lV193Core_clientepjcontatowwds_68_tfcpjtelram = "";
         lV195Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         lV197Core_clientepjcontatowwds_72_tfcpjemail = "";
         lV199Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         AV126Core_clientepjcontatowwds_1_filterfulltext = "";
         AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 = "";
         AV129Core_clientepjcontatowwds_4_cpjconnome1 = "";
         AV130Core_clientepjcontatowwds_5_cpjtiponome1 = "";
         AV131Core_clientepjcontatowwds_6_cpjcontiponome1 = "";
         AV132Core_clientepjcontatowwds_7_cpjcongensigla1 = "";
         AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 = "";
         AV136Core_clientepjcontatowwds_11_cpjconnome2 = "";
         AV137Core_clientepjcontatowwds_12_cpjtiponome2 = "";
         AV138Core_clientepjcontatowwds_13_cpjcontiponome2 = "";
         AV139Core_clientepjcontatowwds_14_cpjcongensigla2 = "";
         AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 = "";
         AV143Core_clientepjcontatowwds_18_cpjconnome3 = "";
         AV144Core_clientepjcontatowwds_19_cpjtiponome3 = "";
         AV145Core_clientepjcontatowwds_20_cpjcontiponome3 = "";
         AV146Core_clientepjcontatowwds_21_cpjcongensigla3 = "";
         AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel = "";
         AV147Core_clientepjcontatowwds_22_tfcpjconnome = "";
         AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel = "";
         AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim = "";
         AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel = "";
         AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome = "";
         AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel = "";
         AV153Core_clientepjcontatowwds_28_tfcpjcontiponome = "";
         AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel = "";
         AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat = "";
         AV157Core_clientepjcontatowwds_32_tfcpjconnascimento = DateTime.MinValue;
         AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to = DateTime.MinValue;
         AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel = "";
         AV159Core_clientepjcontatowwds_34_tfcpjcongennome = "";
         AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel = "";
         AV161Core_clientepjcontatowwds_36_tfcpjconcelnum = "";
         AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel = "";
         AV163Core_clientepjcontatowwds_38_tfcpjcontelnum = "";
         AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel = "";
         AV165Core_clientepjcontatowwds_40_tfcpjcontelram = "";
         AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel = "";
         AV167Core_clientepjcontatowwds_42_tfcpjconwppnum = "";
         AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel = "";
         AV169Core_clientepjcontatowwds_44_tfcpjconemail = "";
         AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel = "";
         AV171Core_clientepjcontatowwds_46_tfcpjconlin = "";
         AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel = "";
         AV173Core_clientepjcontatowwds_48_tfclinomefamiliar = "";
         AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel = "";
         AV177Core_clientepjcontatowwds_52_tfcpjtiponome = "";
         AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel = "";
         AV179Core_clientepjcontatowwds_54_tfcpjnomefan = "";
         AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel = "";
         AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc = "";
         AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel = "";
         AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat = "";
         AV188Core_clientepjcontatowwds_63_tfcpjie_sel = "";
         AV187Core_clientepjcontatowwds_62_tfcpjie = "";
         AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel = "";
         AV189Core_clientepjcontatowwds_64_tfcpjcelnum = "";
         AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel = "";
         AV191Core_clientepjcontatowwds_66_tfcpjtelnum = "";
         AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel = "";
         AV193Core_clientepjcontatowwds_68_tfcpjtelram = "";
         AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel = "";
         AV195Core_clientepjcontatowwds_70_tfcpjwppnum = "";
         AV198Core_clientepjcontatowwds_73_tfcpjemail_sel = "";
         AV197Core_clientepjcontatowwds_72_tfcpjemail = "";
         AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel = "";
         AV199Core_clientepjcontatowwds_74_tfcpjwebsite = "";
         A280CpjConGenSigla = "";
         H004S2_A365CpjTipoId = new int[1] ;
         H004S2_A280CpjConGenSigla = new string[] {""} ;
         H004S2_A270CpjConTipoID = new int[1] ;
         H004S2_A269CpjConSeq = new short[1] ;
         H004S2_A166CpjID = new Guid[] {Guid.Empty} ;
         H004S2_A158CliID = new Guid[] {Guid.Empty} ;
         H004S2_A265CpjWebsite = new string[] {""} ;
         H004S2_n265CpjWebsite = new bool[] {false} ;
         H004S2_A266CpjEmail = new string[] {""} ;
         H004S2_n266CpjEmail = new bool[] {false} ;
         H004S2_A264CpjWppNum = new string[] {""} ;
         H004S2_n264CpjWppNum = new bool[] {false} ;
         H004S2_A262CpjTelRam = new string[] {""} ;
         H004S2_n262CpjTelRam = new bool[] {false} ;
         H004S2_A261CpjTelNum = new string[] {""} ;
         H004S2_n261CpjTelNum = new bool[] {false} ;
         H004S2_A263CpjCelNum = new string[] {""} ;
         H004S2_n263CpjCelNum = new bool[] {false} ;
         H004S2_A189CpjIE = new string[] {""} ;
         H004S2_A188CpjCNPJFormat = new string[] {""} ;
         H004S2_A176CpjMatricula = new long[1] ;
         H004S2_A171CpjRazaoSoc = new string[] {""} ;
         H004S2_A170CpjNomeFan = new string[] {""} ;
         H004S2_A367CpjTipoNome = new string[] {""} ;
         H004S2_A159CliMatricula = new long[1] ;
         H004S2_A160CliNomeFamiliar = new string[] {""} ;
         H004S2_A288CpjConLIn = new string[] {""} ;
         H004S2_n288CpjConLIn = new bool[] {false} ;
         H004S2_A287CpjConEmail = new string[] {""} ;
         H004S2_n287CpjConEmail = new bool[] {false} ;
         H004S2_A286CpjConWppNum = new string[] {""} ;
         H004S2_n286CpjConWppNum = new bool[] {false} ;
         H004S2_A284CpjConTelRam = new string[] {""} ;
         H004S2_n284CpjConTelRam = new bool[] {false} ;
         H004S2_A283CpjConTelNum = new string[] {""} ;
         H004S2_n283CpjConTelNum = new bool[] {false} ;
         H004S2_A285CpjConCelNum = new string[] {""} ;
         H004S2_n285CpjConCelNum = new bool[] {false} ;
         H004S2_A281CpjConGenNome = new string[] {""} ;
         H004S2_A282CpjConNascimento = new DateTime[] {DateTime.MinValue} ;
         H004S2_A274CpjConCPFFormat = new string[] {""} ;
         H004S2_A272CpjConTipoNome = new string[] {""} ;
         H004S2_A277CpjConSobrenome = new string[] {""} ;
         H004S2_A276CpjConNomePrim = new string[] {""} ;
         H004S2_A275CpjConNome = new string[] {""} ;
         H004S3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV102AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV92GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV93GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV46Session = context.GetSession();
         AV42ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV48ManageFiltersXml = "";
         AV43UserCustomValue = "";
         AV45ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char27 = "";
         GXt_char26 = "";
         GXt_char25 = "";
         GXt_char24 = "";
         GXt_char23 = "";
         GXt_char22 = "";
         GXt_char21 = "";
         GXt_char20 = "";
         GXt_char19 = "";
         GXt_char18 = "";
         GXt_char17 = "";
         GXt_char16 = "";
         GXt_char15 = "";
         GXt_char14 = "";
         GXt_char13 = "";
         GXt_char12 = "";
         GXt_char11 = "";
         GXt_char10 = "";
         GXt_char9 = "";
         GXt_char8 = "";
         GXt_char7 = "";
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV40ExcelFilename = "";
         AV41ErrorMessage = "";
         imgRemovedynamicfilters3_gximage = "";
         sImgUrl = "";
         imgAdddynamicfilters2_gximage = "";
         imgRemovedynamicfilters2_gximage = "";
         imgAdddynamicfilters1_gximage = "";
         imgRemovedynamicfilters1_gximage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         gxphoneLink = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatoww__default(),
            new Object[][] {
                new Object[] {
               H004S2_A365CpjTipoId, H004S2_A280CpjConGenSigla, H004S2_A270CpjConTipoID, H004S2_A269CpjConSeq, H004S2_A166CpjID, H004S2_A158CliID, H004S2_A265CpjWebsite, H004S2_n265CpjWebsite, H004S2_A266CpjEmail, H004S2_n266CpjEmail,
               H004S2_A264CpjWppNum, H004S2_n264CpjWppNum, H004S2_A262CpjTelRam, H004S2_n262CpjTelRam, H004S2_A261CpjTelNum, H004S2_n261CpjTelNum, H004S2_A263CpjCelNum, H004S2_n263CpjCelNum, H004S2_A189CpjIE, H004S2_A188CpjCNPJFormat,
               H004S2_A176CpjMatricula, H004S2_A171CpjRazaoSoc, H004S2_A170CpjNomeFan, H004S2_A367CpjTipoNome, H004S2_A159CliMatricula, H004S2_A160CliNomeFamiliar, H004S2_A288CpjConLIn, H004S2_n288CpjConLIn, H004S2_A287CpjConEmail, H004S2_n287CpjConEmail,
               H004S2_A286CpjConWppNum, H004S2_n286CpjConWppNum, H004S2_A284CpjConTelRam, H004S2_n284CpjConTelRam, H004S2_A283CpjConTelNum, H004S2_n283CpjConTelNum, H004S2_A285CpjConCelNum, H004S2_n285CpjConCelNum, H004S2_A281CpjConGenNome, H004S2_A282CpjConNascimento,
               H004S2_A274CpjConCPFFormat, H004S2_A272CpjConTipoNome, H004S2_A277CpjConSobrenome, H004S2_A276CpjConNomePrim, H004S2_A275CpjConNome
               }
               , new Object[] {
               H004S3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV125Pgmname = "core.ClientePJContatoWW";
         /* GeneXus formulas. */
         AV125Pgmname = "core.ClientePJContatoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV26DynamicFiltersOperator2 ;
      private short AV33DynamicFiltersOperator3 ;
      private short AV49ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV98GridActions ;
      private short A269CpjConSeq ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ;
      private short AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ;
      private short AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_138 ;
      private int nGXsfl_138_idx=1 ;
      private int A270CpjConTipoID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int A365CpjTipoId ;
      private int edtCpjConNome_Visible ;
      private int edtCpjConNomePrim_Visible ;
      private int edtCpjConSobrenome_Visible ;
      private int edtCpjConTipoNome_Visible ;
      private int edtCpjConCPFFormat_Visible ;
      private int edtCpjConNascimento_Visible ;
      private int edtCpjConGenNome_Visible ;
      private int edtCpjConCelNum_Visible ;
      private int edtCpjConTelNum_Visible ;
      private int edtCpjConTelRam_Visible ;
      private int edtCpjConWppNum_Visible ;
      private int edtCpjConEmail_Visible ;
      private int edtCpjConLIn_Visible ;
      private int edtCliNomeFamiliar_Visible ;
      private int edtCliMatricula_Visible ;
      private int edtCpjTipoNome_Visible ;
      private int edtCpjNomeFan_Visible ;
      private int edtCpjRazaoSoc_Visible ;
      private int edtCpjMatricula_Visible ;
      private int edtCpjCNPJFormat_Visible ;
      private int edtCpjIE_Visible ;
      private int edtCpjCelNum_Visible ;
      private int edtCpjTelNum_Visible ;
      private int edtCpjTelRam_Visible ;
      private int edtCpjWppNum_Visible ;
      private int edtCpjEmail_Visible ;
      private int edtCpjWebsite_Visible ;
      private int AV94PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavCpjconnome1_Visible ;
      private int edtavCpjtiponome1_Visible ;
      private int edtavCpjcontiponome1_Visible ;
      private int edtavCpjcongensigla1_Visible ;
      private int edtavCpjconnome2_Visible ;
      private int edtavCpjtiponome2_Visible ;
      private int edtavCpjcontiponome2_Visible ;
      private int edtavCpjcongensigla2_Visible ;
      private int edtavCpjconnome3_Visible ;
      private int edtavCpjtiponome3_Visible ;
      private int edtavCpjcontiponome3_Visible ;
      private int edtavCpjcongensigla3_Visible ;
      private int AV201GXV1 ;
      private int edtavCpjconnome3_Enabled ;
      private int edtavCpjtiponome3_Enabled ;
      private int edtavCpjcontiponome3_Enabled ;
      private int edtavCpjcongensigla3_Enabled ;
      private int edtavCpjconnome2_Enabled ;
      private int edtavCpjtiponome2_Enabled ;
      private int edtavCpjcontiponome2_Enabled ;
      private int edtavCpjcongensigla2_Enabled ;
      private int edtavCpjconnome1_Enabled ;
      private int edtavCpjtiponome1_Enabled ;
      private int edtavCpjcontiponome1_Enabled ;
      private int edtavCpjcongensigla1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV77TFCliMatricula ;
      private long AV78TFCliMatricula_To ;
      private long AV103TFCpjMatricula ;
      private long AV104TFCpjMatricula_To ;
      private long AV95GridCurrentPage ;
      private long AV96GridPageCount ;
      private long A159CliMatricula ;
      private long A176CpjMatricula ;
      private long GRID_nCurrentRecord ;
      private long AV175Core_clientepjcontatowwds_50_tfclimatricula ;
      private long AV176Core_clientepjcontatowwds_51_tfclimatricula_to ;
      private long AV183Core_clientepjcontatowwds_58_tfcpjmatricula ;
      private long AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_138_idx="0001" ;
      private string AV125Pgmname ;
      private string AV67TFCpjConCelNum ;
      private string AV68TFCpjConCelNum_Sel ;
      private string AV69TFCpjConTelNum ;
      private string AV70TFCpjConTelNum_Sel ;
      private string AV89TFCpjConWppNum ;
      private string AV90TFCpjConWppNum_Sel ;
      private string AV109TFCpjCelNum ;
      private string AV110TFCpjCelNum_Sel ;
      private string AV111TFCpjTelNum ;
      private string AV112TFCpjTelNum_Sel ;
      private string AV115TFCpjWppNum ;
      private string AV116TFCpjWppNum_Sel ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Ddo_managefilters_Icontype ;
      private string Ddo_managefilters_Icon ;
      private string Ddo_managefilters_Tooltip ;
      private string Ddo_managefilters_Cls ;
      private string Gridpaginationbar_Class ;
      private string Gridpaginationbar_Pagingbuttonsposition ;
      private string Gridpaginationbar_Pagingcaptionposition ;
      private string Gridpaginationbar_Emptygridclass ;
      private string Gridpaginationbar_Rowsperpageoptions ;
      private string Gridpaginationbar_First ;
      private string Gridpaginationbar_Previous ;
      private string Gridpaginationbar_Next ;
      private string Gridpaginationbar_Last ;
      private string Gridpaginationbar_Caption ;
      private string Gridpaginationbar_Emptygridcaption ;
      private string Gridpaginationbar_Rowsperpagecaption ;
      private string Ddo_agexport_Icontype ;
      private string Ddo_agexport_Icon ;
      private string Ddo_agexport_Caption ;
      private string Ddo_agexport_Cls ;
      private string Ddo_agexport_Titlecontrolidtoreplace ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_subscriptions_Titlecontrolidtoreplace ;
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Filteredtext_set ;
      private string Ddo_grid_Filteredtextto_set ;
      private string Ddo_grid_Selectedvalue_set ;
      private string Ddo_grid_Gamoauthtoken ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Includesortasc ;
      private string Ddo_grid_Fixable ;
      private string Ddo_grid_Sortedstatus ;
      private string Ddo_grid_Includefilter ;
      private string Ddo_grid_Filtertype ;
      private string Ddo_grid_Filterisrange ;
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_grid_Format ;
      private string Innewwindow1_Width ;
      private string Innewwindow1_Height ;
      private string Innewwindow1_Target ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_titlescategories_Gridinternalname ;
      private string Grid_titlescategories_Gridtitlescategories ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
      private string divAdvancedfilterscontainer_Internalname ;
      private string divTabledynamicfilters_Internalname ;
      private string divTabledynamicfiltersrow1_Internalname ;
      private string lblDynamicfiltersprefix1_Internalname ;
      private string lblDynamicfiltersprefix1_Jsonclick ;
      private string cmbavDynamicfiltersselector1_Internalname ;
      private string cmbavDynamicfiltersselector1_Jsonclick ;
      private string lblDynamicfiltersmiddle1_Internalname ;
      private string lblDynamicfiltersmiddle1_Jsonclick ;
      private string divTabledynamicfiltersrow2_Internalname ;
      private string lblDynamicfiltersprefix2_Internalname ;
      private string lblDynamicfiltersprefix2_Jsonclick ;
      private string cmbavDynamicfiltersselector2_Internalname ;
      private string cmbavDynamicfiltersselector2_Jsonclick ;
      private string lblDynamicfiltersmiddle2_Internalname ;
      private string lblDynamicfiltersmiddle2_Jsonclick ;
      private string divTabledynamicfiltersrow3_Internalname ;
      private string lblDynamicfiltersprefix3_Internalname ;
      private string lblDynamicfiltersprefix3_Jsonclick ;
      private string cmbavDynamicfiltersselector3_Internalname ;
      private string cmbavDynamicfiltersselector3_Jsonclick ;
      private string lblDynamicfiltersmiddle3_Internalname ;
      private string lblDynamicfiltersmiddle3_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string lblJsdynamicfilters_Internalname ;
      private string lblJsdynamicfilters_Caption ;
      private string lblJsdynamicfilters_Jsonclick ;
      private string Ddo_grid_Internalname ;
      private string Innewwindow1_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_titlescategories_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_cpjconnascimentoauxdates_Internalname ;
      private string edtavDdo_cpjconnascimentoauxdatetext_Internalname ;
      private string edtavDdo_cpjconnascimentoauxdatetext_Jsonclick ;
      private string Tfcpjconnascimento_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtCpjConNome_Internalname ;
      private string edtCpjConNomePrim_Internalname ;
      private string edtCpjConSobrenome_Internalname ;
      private string edtCpjConTipoNome_Internalname ;
      private string edtCpjConCPFFormat_Internalname ;
      private string edtCpjConNascimento_Internalname ;
      private string edtCpjConGenNome_Internalname ;
      private string A285CpjConCelNum ;
      private string edtCpjConCelNum_Internalname ;
      private string A283CpjConTelNum ;
      private string edtCpjConTelNum_Internalname ;
      private string edtCpjConTelRam_Internalname ;
      private string A286CpjConWppNum ;
      private string edtCpjConWppNum_Internalname ;
      private string edtCpjConEmail_Internalname ;
      private string edtCpjConLIn_Internalname ;
      private string edtCliNomeFamiliar_Internalname ;
      private string edtCliMatricula_Internalname ;
      private string edtCpjTipoNome_Internalname ;
      private string edtCpjNomeFan_Internalname ;
      private string edtCpjRazaoSoc_Internalname ;
      private string edtCpjMatricula_Internalname ;
      private string edtCpjCNPJFormat_Internalname ;
      private string edtCpjIE_Internalname ;
      private string A263CpjCelNum ;
      private string edtCpjCelNum_Internalname ;
      private string A261CpjTelNum ;
      private string edtCpjTelNum_Internalname ;
      private string edtCpjTelRam_Internalname ;
      private string A264CpjWppNum ;
      private string edtCpjWppNum_Internalname ;
      private string edtCpjEmail_Internalname ;
      private string edtCpjWebsite_Internalname ;
      private string edtCliID_Internalname ;
      private string edtCpjID_Internalname ;
      private string edtCpjConSeq_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string lV161Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string lV163Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string lV167Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string lV189Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string lV191Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string lV195Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ;
      private string AV161Core_clientepjcontatowwds_36_tfcpjconcelnum ;
      private string AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ;
      private string AV163Core_clientepjcontatowwds_38_tfcpjcontelnum ;
      private string AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ;
      private string AV167Core_clientepjcontatowwds_42_tfcpjconwppnum ;
      private string AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel ;
      private string AV189Core_clientepjcontatowwds_64_tfcpjcelnum ;
      private string AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel ;
      private string AV191Core_clientepjcontatowwds_66_tfcpjtelnum ;
      private string AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel ;
      private string AV195Core_clientepjcontatowwds_70_tfcpjwppnum ;
      private string edtavCpjconnome1_Internalname ;
      private string edtavCpjtiponome1_Internalname ;
      private string edtavCpjcontiponome1_Internalname ;
      private string edtavCpjcongensigla1_Internalname ;
      private string edtavCpjconnome2_Internalname ;
      private string edtavCpjtiponome2_Internalname ;
      private string edtavCpjcontiponome2_Internalname ;
      private string edtavCpjcongensigla2_Internalname ;
      private string edtavCpjconnome3_Internalname ;
      private string edtavCpjtiponome3_Internalname ;
      private string edtavCpjcontiponome3_Internalname ;
      private string edtavCpjcongensigla3_Internalname ;
      private string imgAdddynamicfilters1_Jsonclick ;
      private string imgAdddynamicfilters1_Internalname ;
      private string imgRemovedynamicfilters1_Jsonclick ;
      private string imgRemovedynamicfilters1_Internalname ;
      private string imgAdddynamicfilters2_Jsonclick ;
      private string imgAdddynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters2_Jsonclick ;
      private string imgRemovedynamicfilters2_Internalname ;
      private string imgRemovedynamicfilters3_Jsonclick ;
      private string imgRemovedynamicfilters3_Internalname ;
      private string cmbavGridactions_Class ;
      private string edtCpjConNome_Link ;
      private string GXEncryptionTmp ;
      private string edtCpjConTipoNome_Link ;
      private string edtCpjConLIn_Linktarget ;
      private string edtCpjConLIn_Link ;
      private string edtCliMatricula_Link ;
      private string edtCpjWebsite_Linktarget ;
      private string edtCpjWebsite_Link ;
      private string GXt_char27 ;
      private string GXt_char26 ;
      private string GXt_char25 ;
      private string GXt_char24 ;
      private string GXt_char23 ;
      private string GXt_char22 ;
      private string GXt_char21 ;
      private string GXt_char20 ;
      private string GXt_char19 ;
      private string GXt_char18 ;
      private string GXt_char17 ;
      private string GXt_char16 ;
      private string GXt_char15 ;
      private string GXt_char14 ;
      private string GXt_char13 ;
      private string GXt_char12 ;
      private string GXt_char11 ;
      private string GXt_char10 ;
      private string GXt_char9 ;
      private string GXt_char8 ;
      private string GXt_char7 ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_cpjconnome3_cell_Internalname ;
      private string edtavCpjconnome3_Jsonclick ;
      private string cellFilter_cpjtiponome3_cell_Internalname ;
      private string edtavCpjtiponome3_Jsonclick ;
      private string cellFilter_cpjcontiponome3_cell_Internalname ;
      private string edtavCpjcontiponome3_Jsonclick ;
      private string cellFilter_cpjcongensigla3_cell_Internalname ;
      private string edtavCpjcongensigla3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_cpjconnome2_cell_Internalname ;
      private string edtavCpjconnome2_Jsonclick ;
      private string cellFilter_cpjtiponome2_cell_Internalname ;
      private string edtavCpjtiponome2_Jsonclick ;
      private string cellFilter_cpjcontiponome2_cell_Internalname ;
      private string edtavCpjcontiponome2_Jsonclick ;
      private string cellFilter_cpjcongensigla2_cell_Internalname ;
      private string edtavCpjcongensigla2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_cpjconnome1_cell_Internalname ;
      private string edtavCpjconnome1_Jsonclick ;
      private string cellFilter_cpjtiponome1_cell_Internalname ;
      private string edtavCpjtiponome1_Jsonclick ;
      private string cellFilter_cpjcontiponome1_cell_Internalname ;
      private string edtavCpjcontiponome1_Jsonclick ;
      private string cellFilter_cpjcongensigla1_cell_Internalname ;
      private string edtavCpjcongensigla1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_138_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtCpjConNome_Jsonclick ;
      private string edtCpjConNomePrim_Jsonclick ;
      private string edtCpjConSobrenome_Jsonclick ;
      private string edtCpjConTipoNome_Jsonclick ;
      private string edtCpjConCPFFormat_Jsonclick ;
      private string edtCpjConNascimento_Jsonclick ;
      private string edtCpjConGenNome_Jsonclick ;
      private string gxphoneLink ;
      private string edtCpjConCelNum_Jsonclick ;
      private string edtCpjConTelNum_Jsonclick ;
      private string edtCpjConTelRam_Jsonclick ;
      private string edtCpjConWppNum_Jsonclick ;
      private string edtCpjConEmail_Jsonclick ;
      private string edtCpjConLIn_Jsonclick ;
      private string edtCliNomeFamiliar_Jsonclick ;
      private string edtCliMatricula_Jsonclick ;
      private string edtCpjTipoNome_Jsonclick ;
      private string edtCpjNomeFan_Jsonclick ;
      private string edtCpjRazaoSoc_Jsonclick ;
      private string edtCpjMatricula_Jsonclick ;
      private string edtCpjCNPJFormat_Jsonclick ;
      private string edtCpjIE_Jsonclick ;
      private string edtCpjCelNum_Jsonclick ;
      private string edtCpjTelNum_Jsonclick ;
      private string edtCpjTelRam_Jsonclick ;
      private string edtCpjWppNum_Jsonclick ;
      private string edtCpjEmail_Jsonclick ;
      private string edtCpjWebsite_Jsonclick ;
      private string edtCliID_Jsonclick ;
      private string edtCpjID_Jsonclick ;
      private string edtCpjConSeq_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV60TFCpjConNascimento ;
      private DateTime AV61TFCpjConNascimento_To ;
      private DateTime AV62DDO_CpjConNascimentoAuxDate ;
      private DateTime AV63DDO_CpjConNascimentoAuxDateTo ;
      private DateTime A282CpjConNascimento ;
      private DateTime AV157Core_clientepjcontatowwds_32_tfcpjconnascimento ;
      private DateTime AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV24DynamicFiltersEnabled2 ;
      private bool AV31DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV39DynamicFiltersIgnoreFirst ;
      private bool AV38DynamicFiltersRemoving ;
      private bool AV122IsAuthorized_Update ;
      private bool AV123IsAuthorized_Delete ;
      private bool AV121IsAuthorized_CpjConNome ;
      private bool AV99IsAuthorized_CpjConTipoNome ;
      private bool AV100IsAuthorized_CliMatricula ;
      private bool AV124IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hascategories ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_138_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n285CpjConCelNum ;
      private bool n283CpjConTelNum ;
      private bool n284CpjConTelRam ;
      private bool n286CpjConWppNum ;
      private bool n287CpjConEmail ;
      private bool n288CpjConLIn ;
      private bool n263CpjCelNum ;
      private bool n261CpjTelNum ;
      private bool n262CpjTelRam ;
      private bool n264CpjWppNum ;
      private bool n266CpjEmail ;
      private bool n265CpjWebsite ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ;
      private bool AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV42ColumnsSelectorXML ;
      private string AV48ManageFiltersXml ;
      private string AV43UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20CpjConNome1 ;
      private string AV21CpjTipoNome1 ;
      private string AV22CpjConTipoNome1 ;
      private string AV23CpjConGenSigla1 ;
      private string AV25DynamicFiltersSelector2 ;
      private string AV27CpjConNome2 ;
      private string AV28CpjTipoNome2 ;
      private string AV29CpjConTipoNome2 ;
      private string AV30CpjConGenSigla2 ;
      private string AV32DynamicFiltersSelector3 ;
      private string AV34CpjConNome3 ;
      private string AV35CpjTipoNome3 ;
      private string AV36CpjConTipoNome3 ;
      private string AV37CpjConGenSigla3 ;
      private string AV50TFCpjConNome ;
      private string AV51TFCpjConNome_Sel ;
      private string AV52TFCpjConNomePrim ;
      private string AV53TFCpjConNomePrim_Sel ;
      private string AV54TFCpjConSobrenome ;
      private string AV55TFCpjConSobrenome_Sel ;
      private string AV56TFCpjConTipoNome ;
      private string AV57TFCpjConTipoNome_Sel ;
      private string AV58TFCpjConCPFFormat ;
      private string AV59TFCpjConCPFFormat_Sel ;
      private string AV65TFCpjConGenNome ;
      private string AV66TFCpjConGenNome_Sel ;
      private string AV71TFCpjConTelRam ;
      private string AV72TFCpjConTelRam_Sel ;
      private string AV73TFCpjConEmail ;
      private string AV74TFCpjConEmail_Sel ;
      private string AV75TFCpjConLIn ;
      private string AV76TFCpjConLIn_Sel ;
      private string AV79TFCliNomeFamiliar ;
      private string AV80TFCliNomeFamiliar_Sel ;
      private string AV81TFCpjTipoNome ;
      private string AV82TFCpjTipoNome_Sel ;
      private string AV83TFCpjNomeFan ;
      private string AV84TFCpjNomeFan_Sel ;
      private string AV85TFCpjRazaoSoc ;
      private string AV86TFCpjRazaoSoc_Sel ;
      private string AV105TFCpjCNPJFormat ;
      private string AV106TFCpjCNPJFormat_Sel ;
      private string AV107TFCpjIE ;
      private string AV108TFCpjIE_Sel ;
      private string AV113TFCpjTelRam ;
      private string AV114TFCpjTelRam_Sel ;
      private string AV117TFCpjEmail ;
      private string AV118TFCpjEmail_Sel ;
      private string AV119TFCpjWebsite ;
      private string AV120TFCpjWebsite_Sel ;
      private string AV97GridAppliedFilters ;
      private string AV64DDO_CpjConNascimentoAuxDateText ;
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
      private string lV126Core_clientepjcontatowwds_1_filterfulltext ;
      private string lV129Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string lV130Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string lV131Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string lV132Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string lV136Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string lV137Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string lV138Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string lV139Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string lV143Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string lV144Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string lV145Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string lV146Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string lV147Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string lV153Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string lV159Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string lV165Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string lV169Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string lV171Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string lV173Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string lV177Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string lV179Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string lV187Core_clientepjcontatowwds_62_tfcpjie ;
      private string lV193Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string lV197Core_clientepjcontatowwds_72_tfcpjemail ;
      private string lV199Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string AV126Core_clientepjcontatowwds_1_filterfulltext ;
      private string AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 ;
      private string AV129Core_clientepjcontatowwds_4_cpjconnome1 ;
      private string AV130Core_clientepjcontatowwds_5_cpjtiponome1 ;
      private string AV131Core_clientepjcontatowwds_6_cpjcontiponome1 ;
      private string AV132Core_clientepjcontatowwds_7_cpjcongensigla1 ;
      private string AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 ;
      private string AV136Core_clientepjcontatowwds_11_cpjconnome2 ;
      private string AV137Core_clientepjcontatowwds_12_cpjtiponome2 ;
      private string AV138Core_clientepjcontatowwds_13_cpjcontiponome2 ;
      private string AV139Core_clientepjcontatowwds_14_cpjcongensigla2 ;
      private string AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 ;
      private string AV143Core_clientepjcontatowwds_18_cpjconnome3 ;
      private string AV144Core_clientepjcontatowwds_19_cpjtiponome3 ;
      private string AV145Core_clientepjcontatowwds_20_cpjcontiponome3 ;
      private string AV146Core_clientepjcontatowwds_21_cpjcongensigla3 ;
      private string AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel ;
      private string AV147Core_clientepjcontatowwds_22_tfcpjconnome ;
      private string AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ;
      private string AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ;
      private string AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ;
      private string AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ;
      private string AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ;
      private string AV153Core_clientepjcontatowwds_28_tfcpjcontiponome ;
      private string AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ;
      private string AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ;
      private string AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel ;
      private string AV159Core_clientepjcontatowwds_34_tfcpjcongennome ;
      private string AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel ;
      private string AV165Core_clientepjcontatowwds_40_tfcpjcontelram ;
      private string AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel ;
      private string AV169Core_clientepjcontatowwds_44_tfcpjconemail ;
      private string AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel ;
      private string AV171Core_clientepjcontatowwds_46_tfcpjconlin ;
      private string AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ;
      private string AV173Core_clientepjcontatowwds_48_tfclinomefamiliar ;
      private string AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel ;
      private string AV177Core_clientepjcontatowwds_52_tfcpjtiponome ;
      private string AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel ;
      private string AV179Core_clientepjcontatowwds_54_tfcpjnomefan ;
      private string AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ;
      private string AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ;
      private string AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ;
      private string AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ;
      private string AV188Core_clientepjcontatowwds_63_tfcpjie_sel ;
      private string AV187Core_clientepjcontatowwds_62_tfcpjie ;
      private string AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel ;
      private string AV193Core_clientepjcontatowwds_68_tfcpjtelram ;
      private string AV198Core_clientepjcontatowwds_73_tfcpjemail_sel ;
      private string AV197Core_clientepjcontatowwds_72_tfcpjemail ;
      private string AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel ;
      private string AV199Core_clientepjcontatowwds_74_tfcpjwebsite ;
      private string A280CpjConGenSigla ;
      private string AV40ExcelFilename ;
      private string AV41ErrorMessage ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private IGxSession AV46Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucInnewwindow1 ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_titlescategories ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTfcpjconnascimento_rangepicker ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private int[] H004S2_A365CpjTipoId ;
      private string[] H004S2_A280CpjConGenSigla ;
      private int[] H004S2_A270CpjConTipoID ;
      private short[] H004S2_A269CpjConSeq ;
      private Guid[] H004S2_A166CpjID ;
      private Guid[] H004S2_A158CliID ;
      private string[] H004S2_A265CpjWebsite ;
      private bool[] H004S2_n265CpjWebsite ;
      private string[] H004S2_A266CpjEmail ;
      private bool[] H004S2_n266CpjEmail ;
      private string[] H004S2_A264CpjWppNum ;
      private bool[] H004S2_n264CpjWppNum ;
      private string[] H004S2_A262CpjTelRam ;
      private bool[] H004S2_n262CpjTelRam ;
      private string[] H004S2_A261CpjTelNum ;
      private bool[] H004S2_n261CpjTelNum ;
      private string[] H004S2_A263CpjCelNum ;
      private bool[] H004S2_n263CpjCelNum ;
      private string[] H004S2_A189CpjIE ;
      private string[] H004S2_A188CpjCNPJFormat ;
      private long[] H004S2_A176CpjMatricula ;
      private string[] H004S2_A171CpjRazaoSoc ;
      private string[] H004S2_A170CpjNomeFan ;
      private string[] H004S2_A367CpjTipoNome ;
      private long[] H004S2_A159CliMatricula ;
      private string[] H004S2_A160CliNomeFamiliar ;
      private string[] H004S2_A288CpjConLIn ;
      private bool[] H004S2_n288CpjConLIn ;
      private string[] H004S2_A287CpjConEmail ;
      private bool[] H004S2_n287CpjConEmail ;
      private string[] H004S2_A286CpjConWppNum ;
      private bool[] H004S2_n286CpjConWppNum ;
      private string[] H004S2_A284CpjConTelRam ;
      private bool[] H004S2_n284CpjConTelRam ;
      private string[] H004S2_A283CpjConTelNum ;
      private bool[] H004S2_n283CpjConTelNum ;
      private string[] H004S2_A285CpjConCelNum ;
      private bool[] H004S2_n285CpjConCelNum ;
      private string[] H004S2_A281CpjConGenNome ;
      private DateTime[] H004S2_A282CpjConNascimento ;
      private string[] H004S2_A274CpjConCPFFormat ;
      private string[] H004S2_A272CpjConTipoNome ;
      private string[] H004S2_A277CpjConSobrenome ;
      private string[] H004S2_A276CpjConNomePrim ;
      private string[] H004S2_A275CpjConNome ;
      private long[] H004S3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV47ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV101AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV93GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV44ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV45ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV102AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV91DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV92GAMSession ;
   }

   public class clientepjcontatoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004S2( IGxContext context ,
                                             string AV126Core_clientepjcontatowwds_1_filterfulltext ,
                                             string AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                             short AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                             string AV129Core_clientepjcontatowwds_4_cpjconnome1 ,
                                             string AV130Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                             string AV131Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                             string AV132Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                             bool AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                             string AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                             short AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                             string AV136Core_clientepjcontatowwds_11_cpjconnome2 ,
                                             string AV137Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                             string AV138Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                             string AV139Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                             bool AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                             string AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                             short AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                             string AV143Core_clientepjcontatowwds_18_cpjconnome3 ,
                                             string AV144Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                             string AV145Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                             string AV146Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                             string AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                             string AV147Core_clientepjcontatowwds_22_tfcpjconnome ,
                                             string AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                             string AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                             string AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                             string AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                             string AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                             string AV153Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                             string AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                             string AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                             DateTime AV157Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                             DateTime AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                             string AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                             string AV159Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                             string AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                             string AV161Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                             string AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                             string AV163Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                             string AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                             string AV165Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                             string AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                             string AV167Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                             string AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                             string AV169Core_clientepjcontatowwds_44_tfcpjconemail ,
                                             string AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                             string AV171Core_clientepjcontatowwds_46_tfcpjconlin ,
                                             string AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                             string AV173Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                             long AV175Core_clientepjcontatowwds_50_tfclimatricula ,
                                             long AV176Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                             string AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                             string AV177Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                             string AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                             string AV179Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                             string AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                             string AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                             long AV183Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                             long AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                             string AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                             string AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                             string AV188Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                             string AV187Core_clientepjcontatowwds_62_tfcpjie ,
                                             string AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                             string AV189Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                             string AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                             string AV191Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                             string AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                             string AV193Core_clientepjcontatowwds_68_tfcpjtelram ,
                                             string AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                             string AV195Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                             string AV198Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                             string AV197Core_clientepjcontatowwds_72_tfcpjemail ,
                                             string AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                             string AV199Core_clientepjcontatowwds_74_tfcpjwebsite ,
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
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int28 = new short[107];
         Object[] GXv_Object29 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " T3.CpjTipoId AS CpjTipoId, T1.CpjConGenSigla, T1.CpjConTipoID, T1.CpjConSeq, T1.CpjID, T1.CliID, T3.CpjWebsite, T3.CpjEmail, T3.CpjWppNum, T3.CpjTelRam, T3.CpjTelNum, T3.CpjCelNum, T3.CpjIE, T3.CpjCNPJFormat, T3.CpjMatricula, T3.CpjRazaoSoc, T3.CpjNomeFan, T4.PjtNome AS CpjTipoNome, T2.CliMatricula, T2.CliNomeFamiliar, T1.CpjConLIn, T1.CpjConEmail, T1.CpjConWppNum, T1.CpjConTelRam, T1.CpjConTelNum, T1.CpjConCelNum, T1.CpjConGenNome, T1.CpjConNascimento, T1.CpjConCPFFormat, T1.CpjConTipoNome, T1.CpjConSobrenome, T1.CpjConNomePrim, T1.CpjConNome";
         sFromString = " FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId)";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CpjConNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConNomePrim like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConSobrenome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTipoNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCPFFormat like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConGenNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelRam like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConWppNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConEmail like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConLIn like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T2.CliNomeFamiliar like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CliMatricula,'999999999999'), 2) like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T4.PjtNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjNomeFan like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjRazaoSoc like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.CpjMatricula,'999999999999'), 2) like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCNPJFormat like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjIE like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelRam like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWppNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjEmail like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWebsite like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int28[0] = 1;
            GXv_int28[1] = 1;
            GXv_int28[2] = 1;
            GXv_int28[3] = 1;
            GXv_int28[4] = 1;
            GXv_int28[5] = 1;
            GXv_int28[6] = 1;
            GXv_int28[7] = 1;
            GXv_int28[8] = 1;
            GXv_int28[9] = 1;
            GXv_int28[10] = 1;
            GXv_int28[11] = 1;
            GXv_int28[12] = 1;
            GXv_int28[13] = 1;
            GXv_int28[14] = 1;
            GXv_int28[15] = 1;
            GXv_int28[16] = 1;
            GXv_int28[17] = 1;
            GXv_int28[18] = 1;
            GXv_int28[19] = 1;
            GXv_int28[20] = 1;
            GXv_int28[21] = 1;
            GXv_int28[22] = 1;
            GXv_int28[23] = 1;
            GXv_int28[24] = 1;
            GXv_int28[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV129Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int28[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV129Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int28[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV130Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int28[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV130Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int28[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV131Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int28[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV131Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int28[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV132Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int28[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV132Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int28[33] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV136Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int28[34] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV136Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int28[35] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV137Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int28[36] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV137Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int28[37] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV138Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int28[38] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV138Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int28[39] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV139Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int28[40] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV139Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int28[41] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV143Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int28[42] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV143Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int28[43] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV144Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int28[44] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV144Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int28[45] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV145Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int28[46] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV145Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int28[47] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV146Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int28[48] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV146Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int28[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Core_clientepjcontatowwds_22_tfcpjconnome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV147Core_clientepjcontatowwds_22_tfcpjconnome)");
         }
         else
         {
            GXv_int28[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ! ( StringUtil.StrCmp(AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome = ( :AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel))");
         }
         else
         {
            GXv_int28[51] = 1;
         }
         if ( StringUtil.StrCmp(AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim like :lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim)");
         }
         else
         {
            GXv_int28[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ! ( StringUtil.StrCmp(AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim = ( :AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel))");
         }
         else
         {
            GXv_int28[53] = 1;
         }
         if ( StringUtil.StrCmp(AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNomePrim))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome like :lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome)");
         }
         else
         {
            GXv_int28[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ! ( StringUtil.StrCmp(AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome = ( :AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel))");
         }
         else
         {
            GXv_int28[55] = 1;
         }
         if ( StringUtil.StrCmp(AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConSobrenome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_28_tfcpjcontiponome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV153Core_clientepjcontatowwds_28_tfcpjcontiponome)");
         }
         else
         {
            GXv_int28[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ! ( StringUtil.StrCmp(AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome = ( :AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel))");
         }
         else
         {
            GXv_int28[57] = 1;
         }
         if ( StringUtil.StrCmp(AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat like :lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat)");
         }
         else
         {
            GXv_int28[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ! ( StringUtil.StrCmp(AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat = ( :AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel))");
         }
         else
         {
            GXv_int28[59] = 1;
         }
         if ( StringUtil.StrCmp(AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConCPFFormat))=0))");
         }
         if ( ! (DateTime.MinValue==AV157Core_clientepjcontatowwds_32_tfcpjconnascimento) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento >= :AV157Core_clientepjcontatowwds_32_tfcpjconnascimento)");
         }
         else
         {
            GXv_int28[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento <= :AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to)");
         }
         else
         {
            GXv_int28[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_34_tfcpjcongennome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome like :lV159Core_clientepjcontatowwds_34_tfcpjcongennome)");
         }
         else
         {
            GXv_int28[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ! ( StringUtil.StrCmp(AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome = ( :AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel))");
         }
         else
         {
            GXv_int28[63] = 1;
         }
         if ( StringUtil.StrCmp(AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConGenNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_36_tfcpjconcelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum like :lV161Core_clientepjcontatowwds_36_tfcpjconcelnum)");
         }
         else
         {
            GXv_int28[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ! ( StringUtil.StrCmp(AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum = ( :AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel))");
         }
         else
         {
            GXv_int28[65] = 1;
         }
         if ( StringUtil.StrCmp(AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_38_tfcpjcontelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum like :lV163Core_clientepjcontatowwds_38_tfcpjcontelnum)");
         }
         else
         {
            GXv_int28[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ! ( StringUtil.StrCmp(AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum = ( :AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel))");
         }
         else
         {
            GXv_int28[67] = 1;
         }
         if ( StringUtil.StrCmp(AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Core_clientepjcontatowwds_40_tfcpjcontelram)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam like :lV165Core_clientepjcontatowwds_40_tfcpjcontelram)");
         }
         else
         {
            GXv_int28[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ! ( StringUtil.StrCmp(AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam = ( :AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel))");
         }
         else
         {
            GXv_int28[69] = 1;
         }
         if ( StringUtil.StrCmp(AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_42_tfcpjconwppnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum like :lV167Core_clientepjcontatowwds_42_tfcpjconwppnum)");
         }
         else
         {
            GXv_int28[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ! ( StringUtil.StrCmp(AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum = ( :AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel))");
         }
         else
         {
            GXv_int28[71] = 1;
         }
         if ( StringUtil.StrCmp(AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_44_tfcpjconemail)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail like :lV169Core_clientepjcontatowwds_44_tfcpjconemail)");
         }
         else
         {
            GXv_int28[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ! ( StringUtil.StrCmp(AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail = ( :AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel))");
         }
         else
         {
            GXv_int28[73] = 1;
         }
         if ( StringUtil.StrCmp(AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail IS NULL or (char_length(trim(trailing ' ' from T1.CpjConEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_46_tfcpjconlin)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn like :lV171Core_clientepjcontatowwds_46_tfcpjconlin)");
         }
         else
         {
            GXv_int28[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ! ( StringUtil.StrCmp(AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn = ( :AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel))");
         }
         else
         {
            GXv_int28[75] = 1;
         }
         if ( StringUtil.StrCmp(AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn IS NULL or (char_length(trim(trailing ' ' from T1.CpjConLIn))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Core_clientepjcontatowwds_48_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar like :lV173Core_clientepjcontatowwds_48_tfclinomefamiliar)");
         }
         else
         {
            GXv_int28[76] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar = ( :AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int28[77] = 1;
         }
         if ( StringUtil.StrCmp(AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV175Core_clientepjcontatowwds_50_tfclimatricula) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula >= :AV175Core_clientepjcontatowwds_50_tfclimatricula)");
         }
         else
         {
            GXv_int28[78] = 1;
         }
         if ( ! (0==AV176Core_clientepjcontatowwds_51_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula <= :AV176Core_clientepjcontatowwds_51_tfclimatricula_to)");
         }
         else
         {
            GXv_int28[79] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_52_tfcpjtiponome)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV177Core_clientepjcontatowwds_52_tfcpjtiponome)");
         }
         else
         {
            GXv_int28[80] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ! ( StringUtil.StrCmp(AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome = ( :AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel))");
         }
         else
         {
            GXv_int28[81] = 1;
         }
         if ( StringUtil.StrCmp(AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.PjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_54_tfcpjnomefan)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan like :lV179Core_clientepjcontatowwds_54_tfcpjnomefan)");
         }
         else
         {
            GXv_int28[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ! ( StringUtil.StrCmp(AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan = ( :AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel))");
         }
         else
         {
            GXv_int28[83] = 1;
         }
         if ( StringUtil.StrCmp(AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjNomeFan))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc like :lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc)");
         }
         else
         {
            GXv_int28[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ! ( StringUtil.StrCmp(AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc = ( :AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel))");
         }
         else
         {
            GXv_int28[85] = 1;
         }
         if ( StringUtil.StrCmp(AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjRazaoSoc))=0))");
         }
         if ( ! (0==AV183Core_clientepjcontatowwds_58_tfcpjmatricula) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula >= :AV183Core_clientepjcontatowwds_58_tfcpjmatricula)");
         }
         else
         {
            GXv_int28[86] = 1;
         }
         if ( ! (0==AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula <= :AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to)");
         }
         else
         {
            GXv_int28[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat like :lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat)");
         }
         else
         {
            GXv_int28[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ! ( StringUtil.StrCmp(AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat = ( :AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel))");
         }
         else
         {
            GXv_int28[89] = 1;
         }
         if ( StringUtil.StrCmp(AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjCNPJFormat))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_63_tfcpjie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_62_tfcpjie)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE like :lV187Core_clientepjcontatowwds_62_tfcpjie)");
         }
         else
         {
            GXv_int28[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_63_tfcpjie_sel)) && ! ( StringUtil.StrCmp(AV188Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE = ( :AV188Core_clientepjcontatowwds_63_tfcpjie_sel))");
         }
         else
         {
            GXv_int28[91] = 1;
         }
         if ( StringUtil.StrCmp(AV188Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjIE))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_64_tfcpjcelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum like :lV189Core_clientepjcontatowwds_64_tfcpjcelnum)");
         }
         else
         {
            GXv_int28[92] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ! ( StringUtil.StrCmp(AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum = ( :AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel))");
         }
         else
         {
            GXv_int28[93] = 1;
         }
         if ( StringUtil.StrCmp(AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV191Core_clientepjcontatowwds_66_tfcpjtelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum like :lV191Core_clientepjcontatowwds_66_tfcpjtelnum)");
         }
         else
         {
            GXv_int28[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ! ( StringUtil.StrCmp(AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum = ( :AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel))");
         }
         else
         {
            GXv_int28[95] = 1;
         }
         if ( StringUtil.StrCmp(AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Core_clientepjcontatowwds_68_tfcpjtelram)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam like :lV193Core_clientepjcontatowwds_68_tfcpjtelram)");
         }
         else
         {
            GXv_int28[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ! ( StringUtil.StrCmp(AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam = ( :AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel))");
         }
         else
         {
            GXv_int28[97] = 1;
         }
         if ( StringUtil.StrCmp(AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_clientepjcontatowwds_70_tfcpjwppnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum like :lV195Core_clientepjcontatowwds_70_tfcpjwppnum)");
         }
         else
         {
            GXv_int28[98] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ! ( StringUtil.StrCmp(AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum = ( :AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel))");
         }
         else
         {
            GXv_int28[99] = 1;
         }
         if ( StringUtil.StrCmp(AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_clientepjcontatowwds_72_tfcpjemail)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail like :lV197Core_clientepjcontatowwds_72_tfcpjemail)");
         }
         else
         {
            GXv_int28[100] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ! ( StringUtil.StrCmp(AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail = ( :AV198Core_clientepjcontatowwds_73_tfcpjemail_sel))");
         }
         else
         {
            GXv_int28[101] = 1;
         }
         if ( StringUtil.StrCmp(AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjEmail IS NULL or (char_length(trim(trailing ' ' from T3.CpjEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Core_clientepjcontatowwds_74_tfcpjwebsite)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite like :lV199Core_clientepjcontatowwds_74_tfcpjwebsite)");
         }
         else
         {
            GXv_int28[102] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ! ( StringUtil.StrCmp(AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite = ( :AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel))");
         }
         else
         {
            GXv_int28[103] = 1;
         }
         if ( StringUtil.StrCmp(AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite IS NULL or (char_length(trim(trailing ' ' from T3.CpjWebsite))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConNome, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConNome DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConNomePrim, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConNomePrim DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConSobrenome, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConSobrenome DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConTipoNome, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConTipoNome DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConCPFFormat, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConCPFFormat DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConNascimento, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConNascimento DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConGenNome, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConGenNome DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConCelNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConCelNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConTelNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConTelNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConTelRam, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConTelRam DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConWppNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConWppNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConEmail, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConEmail DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T1.CpjConLIn, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T1.CpjConLIn DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CliNomeFamiliar, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CliNomeFamiliar DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T2.CliMatricula, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T2.CliMatricula DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T4.PjtNome, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T4.PjtNome DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjNomeFan, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjNomeFan DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjRazaoSoc, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjRazaoSoc DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjMatricula, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjMatricula DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjCNPJFormat, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjCNPJFormat DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjIE, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjIE DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjCelNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjCelNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjTelNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjTelNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjTelRam, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjTelRam DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjWppNum, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjWppNum DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjEmail, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjEmail DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY T3.CpjWebsite, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY T3.CpjWebsite DESC, T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY T1.CliID, T1.CpjID, T1.CpjConSeq";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object29[0] = scmdbuf;
         GXv_Object29[1] = GXv_int28;
         return GXv_Object29 ;
      }

      protected Object[] conditional_H004S3( IGxContext context ,
                                             string AV126Core_clientepjcontatowwds_1_filterfulltext ,
                                             string AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1 ,
                                             short AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 ,
                                             string AV129Core_clientepjcontatowwds_4_cpjconnome1 ,
                                             string AV130Core_clientepjcontatowwds_5_cpjtiponome1 ,
                                             string AV131Core_clientepjcontatowwds_6_cpjcontiponome1 ,
                                             string AV132Core_clientepjcontatowwds_7_cpjcongensigla1 ,
                                             bool AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 ,
                                             string AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2 ,
                                             short AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 ,
                                             string AV136Core_clientepjcontatowwds_11_cpjconnome2 ,
                                             string AV137Core_clientepjcontatowwds_12_cpjtiponome2 ,
                                             string AV138Core_clientepjcontatowwds_13_cpjcontiponome2 ,
                                             string AV139Core_clientepjcontatowwds_14_cpjcongensigla2 ,
                                             bool AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 ,
                                             string AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3 ,
                                             short AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 ,
                                             string AV143Core_clientepjcontatowwds_18_cpjconnome3 ,
                                             string AV144Core_clientepjcontatowwds_19_cpjtiponome3 ,
                                             string AV145Core_clientepjcontatowwds_20_cpjcontiponome3 ,
                                             string AV146Core_clientepjcontatowwds_21_cpjcongensigla3 ,
                                             string AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel ,
                                             string AV147Core_clientepjcontatowwds_22_tfcpjconnome ,
                                             string AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel ,
                                             string AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim ,
                                             string AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel ,
                                             string AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome ,
                                             string AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel ,
                                             string AV153Core_clientepjcontatowwds_28_tfcpjcontiponome ,
                                             string AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel ,
                                             string AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat ,
                                             DateTime AV157Core_clientepjcontatowwds_32_tfcpjconnascimento ,
                                             DateTime AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to ,
                                             string AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel ,
                                             string AV159Core_clientepjcontatowwds_34_tfcpjcongennome ,
                                             string AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel ,
                                             string AV161Core_clientepjcontatowwds_36_tfcpjconcelnum ,
                                             string AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel ,
                                             string AV163Core_clientepjcontatowwds_38_tfcpjcontelnum ,
                                             string AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel ,
                                             string AV165Core_clientepjcontatowwds_40_tfcpjcontelram ,
                                             string AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel ,
                                             string AV167Core_clientepjcontatowwds_42_tfcpjconwppnum ,
                                             string AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel ,
                                             string AV169Core_clientepjcontatowwds_44_tfcpjconemail ,
                                             string AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel ,
                                             string AV171Core_clientepjcontatowwds_46_tfcpjconlin ,
                                             string AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel ,
                                             string AV173Core_clientepjcontatowwds_48_tfclinomefamiliar ,
                                             long AV175Core_clientepjcontatowwds_50_tfclimatricula ,
                                             long AV176Core_clientepjcontatowwds_51_tfclimatricula_to ,
                                             string AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel ,
                                             string AV177Core_clientepjcontatowwds_52_tfcpjtiponome ,
                                             string AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel ,
                                             string AV179Core_clientepjcontatowwds_54_tfcpjnomefan ,
                                             string AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel ,
                                             string AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc ,
                                             long AV183Core_clientepjcontatowwds_58_tfcpjmatricula ,
                                             long AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to ,
                                             string AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel ,
                                             string AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat ,
                                             string AV188Core_clientepjcontatowwds_63_tfcpjie_sel ,
                                             string AV187Core_clientepjcontatowwds_62_tfcpjie ,
                                             string AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel ,
                                             string AV189Core_clientepjcontatowwds_64_tfcpjcelnum ,
                                             string AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel ,
                                             string AV191Core_clientepjcontatowwds_66_tfcpjtelnum ,
                                             string AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel ,
                                             string AV193Core_clientepjcontatowwds_68_tfcpjtelram ,
                                             string AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel ,
                                             string AV195Core_clientepjcontatowwds_70_tfcpjwppnum ,
                                             string AV198Core_clientepjcontatowwds_73_tfcpjemail_sel ,
                                             string AV197Core_clientepjcontatowwds_72_tfcpjemail ,
                                             string AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel ,
                                             string AV199Core_clientepjcontatowwds_74_tfcpjwebsite ,
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
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int30 = new short[104];
         Object[] GXv_Object31 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM (((tb_clientepj_contato T1 INNER JOIN tb_cliente T2 ON T2.CliID = T1.CliID) INNER JOIN tb_clientepj T3 ON T3.CliID = T1.CliID AND T3.CpjID = T1.CpjID) INNER JOIN tb_clientepjtipo T4 ON T4.PjtID = T3.CpjTipoId)";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV126Core_clientepjcontatowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( T1.CpjConNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConNomePrim like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConSobrenome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTipoNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCPFFormat like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConGenNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConCelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConTelRam like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConWppNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConEmail like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T1.CpjConLIn like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T2.CliNomeFamiliar like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T2.CliMatricula,'999999999999'), 2) like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T4.PjtNome like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjNomeFan like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjRazaoSoc like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( SUBSTR(TO_CHAR(T3.CpjMatricula,'999999999999'), 2) like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCNPJFormat like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjIE like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjCelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjTelRam like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWppNum like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjEmail like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext) or ( T3.CpjWebsite like '%' || :lV126Core_clientepjcontatowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int30[0] = 1;
            GXv_int30[1] = 1;
            GXv_int30[2] = 1;
            GXv_int30[3] = 1;
            GXv_int30[4] = 1;
            GXv_int30[5] = 1;
            GXv_int30[6] = 1;
            GXv_int30[7] = 1;
            GXv_int30[8] = 1;
            GXv_int30[9] = 1;
            GXv_int30[10] = 1;
            GXv_int30[11] = 1;
            GXv_int30[12] = 1;
            GXv_int30[13] = 1;
            GXv_int30[14] = 1;
            GXv_int30[15] = 1;
            GXv_int30[16] = 1;
            GXv_int30[17] = 1;
            GXv_int30[18] = 1;
            GXv_int30[19] = 1;
            GXv_int30[20] = 1;
            GXv_int30[21] = 1;
            GXv_int30[22] = 1;
            GXv_int30[23] = 1;
            GXv_int30[24] = 1;
            GXv_int30[25] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV129Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int30[26] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONNOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV129Core_clientepjcontatowwds_4_cpjconnome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV129Core_clientepjcontatowwds_4_cpjconnome1)");
         }
         else
         {
            GXv_int30[27] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV130Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int30[28] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV130Core_clientepjcontatowwds_5_cpjtiponome1)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV130Core_clientepjcontatowwds_5_cpjtiponome1)");
         }
         else
         {
            GXv_int30[29] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV131Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int30[30] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONTIPONOME") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV131Core_clientepjcontatowwds_6_cpjcontiponome1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV131Core_clientepjcontatowwds_6_cpjcontiponome1)");
         }
         else
         {
            GXv_int30[31] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV132Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int30[32] = 1;
         }
         if ( ( StringUtil.StrCmp(AV127Core_clientepjcontatowwds_2_dynamicfiltersselector1, "CPJCONGENSIGLA") == 0 ) && ( AV128Core_clientepjcontatowwds_3_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV132Core_clientepjcontatowwds_7_cpjcongensigla1)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV132Core_clientepjcontatowwds_7_cpjcongensigla1)");
         }
         else
         {
            GXv_int30[33] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV136Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int30[34] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONNOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV136Core_clientepjcontatowwds_11_cpjconnome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV136Core_clientepjcontatowwds_11_cpjconnome2)");
         }
         else
         {
            GXv_int30[35] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV137Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int30[36] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV137Core_clientepjcontatowwds_12_cpjtiponome2)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV137Core_clientepjcontatowwds_12_cpjtiponome2)");
         }
         else
         {
            GXv_int30[37] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV138Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int30[38] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONTIPONOME") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV138Core_clientepjcontatowwds_13_cpjcontiponome2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV138Core_clientepjcontatowwds_13_cpjcontiponome2)");
         }
         else
         {
            GXv_int30[39] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV139Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int30[40] = 1;
         }
         if ( AV133Core_clientepjcontatowwds_8_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV134Core_clientepjcontatowwds_9_dynamicfiltersselector2, "CPJCONGENSIGLA") == 0 ) && ( AV135Core_clientepjcontatowwds_10_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV139Core_clientepjcontatowwds_14_cpjcongensigla2)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV139Core_clientepjcontatowwds_14_cpjcongensigla2)");
         }
         else
         {
            GXv_int30[41] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV143Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int30[42] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONNOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV143Core_clientepjcontatowwds_18_cpjconnome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like '%' || :lV143Core_clientepjcontatowwds_18_cpjconnome3)");
         }
         else
         {
            GXv_int30[43] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV144Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int30[44] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV144Core_clientepjcontatowwds_19_cpjtiponome3)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like '%' || :lV144Core_clientepjcontatowwds_19_cpjtiponome3)");
         }
         else
         {
            GXv_int30[45] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV145Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int30[46] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONTIPONOME") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV145Core_clientepjcontatowwds_20_cpjcontiponome3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like '%' || :lV145Core_clientepjcontatowwds_20_cpjcontiponome3)");
         }
         else
         {
            GXv_int30[47] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like :lV146Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int30[48] = 1;
         }
         if ( AV140Core_clientepjcontatowwds_15_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV141Core_clientepjcontatowwds_16_dynamicfiltersselector3, "CPJCONGENSIGLA") == 0 ) && ( AV142Core_clientepjcontatowwds_17_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV146Core_clientepjcontatowwds_21_cpjcongensigla3)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenSigla like '%' || :lV146Core_clientepjcontatowwds_21_cpjcongensigla3)");
         }
         else
         {
            GXv_int30[49] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV147Core_clientepjcontatowwds_22_tfcpjconnome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome like :lV147Core_clientepjcontatowwds_22_tfcpjconnome)");
         }
         else
         {
            GXv_int30[50] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel)) && ! ( StringUtil.StrCmp(AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNome = ( :AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel))");
         }
         else
         {
            GXv_int30[51] = 1;
         }
         if ( StringUtil.StrCmp(AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV149Core_clientepjcontatowwds_24_tfcpjconnomeprim)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim like :lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim)");
         }
         else
         {
            GXv_int30[52] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel)) && ! ( StringUtil.StrCmp(AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConNomePrim = ( :AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel))");
         }
         else
         {
            GXv_int30[53] = 1;
         }
         if ( StringUtil.StrCmp(AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConNomePrim))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV151Core_clientepjcontatowwds_26_tfcpjconsobrenome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome like :lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome)");
         }
         else
         {
            GXv_int30[54] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel)) && ! ( StringUtil.StrCmp(AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConSobrenome = ( :AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel))");
         }
         else
         {
            GXv_int30[55] = 1;
         }
         if ( StringUtil.StrCmp(AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConSobrenome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV153Core_clientepjcontatowwds_28_tfcpjcontiponome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome like :lV153Core_clientepjcontatowwds_28_tfcpjcontiponome)");
         }
         else
         {
            GXv_int30[56] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel)) && ! ( StringUtil.StrCmp(AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTipoNome = ( :AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel))");
         }
         else
         {
            GXv_int30[57] = 1;
         }
         if ( StringUtil.StrCmp(AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConTipoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV155Core_clientepjcontatowwds_30_tfcpjconcpfformat)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat like :lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat)");
         }
         else
         {
            GXv_int30[58] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel)) && ! ( StringUtil.StrCmp(AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCPFFormat = ( :AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel))");
         }
         else
         {
            GXv_int30[59] = 1;
         }
         if ( StringUtil.StrCmp(AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConCPFFormat))=0))");
         }
         if ( ! (DateTime.MinValue==AV157Core_clientepjcontatowwds_32_tfcpjconnascimento) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento >= :AV157Core_clientepjcontatowwds_32_tfcpjconnascimento)");
         }
         else
         {
            GXv_int30[60] = 1;
         }
         if ( ! (DateTime.MinValue==AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to) )
         {
            AddWhere(sWhereString, "(T1.CpjConNascimento <= :AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to)");
         }
         else
         {
            GXv_int30[61] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV159Core_clientepjcontatowwds_34_tfcpjcongennome)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome like :lV159Core_clientepjcontatowwds_34_tfcpjcongennome)");
         }
         else
         {
            GXv_int30[62] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel)) && ! ( StringUtil.StrCmp(AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConGenNome = ( :AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel))");
         }
         else
         {
            GXv_int30[63] = 1;
         }
         if ( StringUtil.StrCmp(AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T1.CpjConGenNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV161Core_clientepjcontatowwds_36_tfcpjconcelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum like :lV161Core_clientepjcontatowwds_36_tfcpjconcelnum)");
         }
         else
         {
            GXv_int30[64] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel)) && ! ( StringUtil.StrCmp(AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum = ( :AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel))");
         }
         else
         {
            GXv_int30[65] = 1;
         }
         if ( StringUtil.StrCmp(AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConCelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV163Core_clientepjcontatowwds_38_tfcpjcontelnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum like :lV163Core_clientepjcontatowwds_38_tfcpjcontelnum)");
         }
         else
         {
            GXv_int30[66] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel)) && ! ( StringUtil.StrCmp(AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum = ( :AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel))");
         }
         else
         {
            GXv_int30[67] = 1;
         }
         if ( StringUtil.StrCmp(AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV165Core_clientepjcontatowwds_40_tfcpjcontelram)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam like :lV165Core_clientepjcontatowwds_40_tfcpjcontelram)");
         }
         else
         {
            GXv_int30[68] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel)) && ! ( StringUtil.StrCmp(AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam = ( :AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel))");
         }
         else
         {
            GXv_int30[69] = 1;
         }
         if ( StringUtil.StrCmp(AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConTelRam IS NULL or (char_length(trim(trailing ' ' from T1.CpjConTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV167Core_clientepjcontatowwds_42_tfcpjconwppnum)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum like :lV167Core_clientepjcontatowwds_42_tfcpjconwppnum)");
         }
         else
         {
            GXv_int30[70] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel)) && ! ( StringUtil.StrCmp(AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum = ( :AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel))");
         }
         else
         {
            GXv_int30[71] = 1;
         }
         if ( StringUtil.StrCmp(AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConWppNum IS NULL or (char_length(trim(trailing ' ' from T1.CpjConWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV169Core_clientepjcontatowwds_44_tfcpjconemail)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail like :lV169Core_clientepjcontatowwds_44_tfcpjconemail)");
         }
         else
         {
            GXv_int30[72] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel)) && ! ( StringUtil.StrCmp(AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail = ( :AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel))");
         }
         else
         {
            GXv_int30[73] = 1;
         }
         if ( StringUtil.StrCmp(AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConEmail IS NULL or (char_length(trim(trailing ' ' from T1.CpjConEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV171Core_clientepjcontatowwds_46_tfcpjconlin)) ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn like :lV171Core_clientepjcontatowwds_46_tfcpjconlin)");
         }
         else
         {
            GXv_int30[74] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel)) && ! ( StringUtil.StrCmp(AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn = ( :AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel))");
         }
         else
         {
            GXv_int30[75] = 1;
         }
         if ( StringUtil.StrCmp(AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T1.CpjConLIn IS NULL or (char_length(trim(trailing ' ' from T1.CpjConLIn))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV173Core_clientepjcontatowwds_48_tfclinomefamiliar)) ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar like :lV173Core_clientepjcontatowwds_48_tfclinomefamiliar)");
         }
         else
         {
            GXv_int30[76] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel)) && ! ( StringUtil.StrCmp(AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T2.CliNomeFamiliar = ( :AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel))");
         }
         else
         {
            GXv_int30[77] = 1;
         }
         if ( StringUtil.StrCmp(AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T2.CliNomeFamiliar))=0))");
         }
         if ( ! (0==AV175Core_clientepjcontatowwds_50_tfclimatricula) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula >= :AV175Core_clientepjcontatowwds_50_tfclimatricula)");
         }
         else
         {
            GXv_int30[78] = 1;
         }
         if ( ! (0==AV176Core_clientepjcontatowwds_51_tfclimatricula_to) )
         {
            AddWhere(sWhereString, "(T2.CliMatricula <= :AV176Core_clientepjcontatowwds_51_tfclimatricula_to)");
         }
         else
         {
            GXv_int30[79] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV177Core_clientepjcontatowwds_52_tfcpjtiponome)) ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome like :lV177Core_clientepjcontatowwds_52_tfcpjtiponome)");
         }
         else
         {
            GXv_int30[80] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel)) && ! ( StringUtil.StrCmp(AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T4.PjtNome = ( :AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel))");
         }
         else
         {
            GXv_int30[81] = 1;
         }
         if ( StringUtil.StrCmp(AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T4.PjtNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV179Core_clientepjcontatowwds_54_tfcpjnomefan)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan like :lV179Core_clientepjcontatowwds_54_tfcpjnomefan)");
         }
         else
         {
            GXv_int30[82] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel)) && ! ( StringUtil.StrCmp(AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjNomeFan = ( :AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel))");
         }
         else
         {
            GXv_int30[83] = 1;
         }
         if ( StringUtil.StrCmp(AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjNomeFan))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV181Core_clientepjcontatowwds_56_tfcpjrazaosoc)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc like :lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc)");
         }
         else
         {
            GXv_int30[84] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel)) && ! ( StringUtil.StrCmp(AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjRazaoSoc = ( :AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel))");
         }
         else
         {
            GXv_int30[85] = 1;
         }
         if ( StringUtil.StrCmp(AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjRazaoSoc))=0))");
         }
         if ( ! (0==AV183Core_clientepjcontatowwds_58_tfcpjmatricula) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula >= :AV183Core_clientepjcontatowwds_58_tfcpjmatricula)");
         }
         else
         {
            GXv_int30[86] = 1;
         }
         if ( ! (0==AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to) )
         {
            AddWhere(sWhereString, "(T3.CpjMatricula <= :AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to)");
         }
         else
         {
            GXv_int30[87] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV185Core_clientepjcontatowwds_60_tfcpjcnpjformat)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat like :lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat)");
         }
         else
         {
            GXv_int30[88] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel)) && ! ( StringUtil.StrCmp(AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCNPJFormat = ( :AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel))");
         }
         else
         {
            GXv_int30[89] = 1;
         }
         if ( StringUtil.StrCmp(AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjCNPJFormat))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_63_tfcpjie_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV187Core_clientepjcontatowwds_62_tfcpjie)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE like :lV187Core_clientepjcontatowwds_62_tfcpjie)");
         }
         else
         {
            GXv_int30[90] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV188Core_clientepjcontatowwds_63_tfcpjie_sel)) && ! ( StringUtil.StrCmp(AV188Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjIE = ( :AV188Core_clientepjcontatowwds_63_tfcpjie_sel))");
         }
         else
         {
            GXv_int30[91] = 1;
         }
         if ( StringUtil.StrCmp(AV188Core_clientepjcontatowwds_63_tfcpjie_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from T3.CpjIE))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV189Core_clientepjcontatowwds_64_tfcpjcelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum like :lV189Core_clientepjcontatowwds_64_tfcpjcelnum)");
         }
         else
         {
            GXv_int30[92] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel)) && ! ( StringUtil.StrCmp(AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum = ( :AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel))");
         }
         else
         {
            GXv_int30[93] = 1;
         }
         if ( StringUtil.StrCmp(AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjCelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjCelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV191Core_clientepjcontatowwds_66_tfcpjtelnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum like :lV191Core_clientepjcontatowwds_66_tfcpjtelnum)");
         }
         else
         {
            GXv_int30[94] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel)) && ! ( StringUtil.StrCmp(AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum = ( :AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel))");
         }
         else
         {
            GXv_int30[95] = 1;
         }
         if ( StringUtil.StrCmp(AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV193Core_clientepjcontatowwds_68_tfcpjtelram)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam like :lV193Core_clientepjcontatowwds_68_tfcpjtelram)");
         }
         else
         {
            GXv_int30[96] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel)) && ! ( StringUtil.StrCmp(AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam = ( :AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel))");
         }
         else
         {
            GXv_int30[97] = 1;
         }
         if ( StringUtil.StrCmp(AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjTelRam IS NULL or (char_length(trim(trailing ' ' from T3.CpjTelRam))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV195Core_clientepjcontatowwds_70_tfcpjwppnum)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum like :lV195Core_clientepjcontatowwds_70_tfcpjwppnum)");
         }
         else
         {
            GXv_int30[98] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel)) && ! ( StringUtil.StrCmp(AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum = ( :AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel))");
         }
         else
         {
            GXv_int30[99] = 1;
         }
         if ( StringUtil.StrCmp(AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWppNum IS NULL or (char_length(trim(trailing ' ' from T3.CpjWppNum))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV197Core_clientepjcontatowwds_72_tfcpjemail)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail like :lV197Core_clientepjcontatowwds_72_tfcpjemail)");
         }
         else
         {
            GXv_int30[100] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV198Core_clientepjcontatowwds_73_tfcpjemail_sel)) && ! ( StringUtil.StrCmp(AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjEmail = ( :AV198Core_clientepjcontatowwds_73_tfcpjemail_sel))");
         }
         else
         {
            GXv_int30[101] = 1;
         }
         if ( StringUtil.StrCmp(AV198Core_clientepjcontatowwds_73_tfcpjemail_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjEmail IS NULL or (char_length(trim(trailing ' ' from T3.CpjEmail))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV199Core_clientepjcontatowwds_74_tfcpjwebsite)) ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite like :lV199Core_clientepjcontatowwds_74_tfcpjwebsite)");
         }
         else
         {
            GXv_int30[102] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel)) && ! ( StringUtil.StrCmp(AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite = ( :AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel))");
         }
         else
         {
            GXv_int30[103] = 1;
         }
         if ( StringUtil.StrCmp(AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(T3.CpjWebsite IS NULL or (char_length(trim(trailing ' ' from T3.CpjWebsite))=0))");
         }
         scmdbuf += sWhereString;
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 5 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 6 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 7 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 8 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 9 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 10 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 11 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 12 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 13 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 14 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 14 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 15 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 15 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 16 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 16 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 17 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 17 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 18 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 18 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 19 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 19 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 20 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 20 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 21 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 21 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 22 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 22 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 23 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 23 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 24 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 24 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 25 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 25 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 26 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 26 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 27 ) && ! AV15OrderedDsc )
         {
            scmdbuf += "";
         }
         else if ( ( AV14OrderedBy == 27 ) && ( AV15OrderedDsc ) )
         {
            scmdbuf += "";
         }
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object31[0] = scmdbuf;
         GXv_Object31[1] = GXv_int30;
         return GXv_Object31 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H004S2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (long)dynConstraints[49] , (long)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (long)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (long)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (string)dynConstraints[97] , (string)dynConstraints[98] , (string)dynConstraints[99] , (string)dynConstraints[100] , (string)dynConstraints[101] , (DateTime)dynConstraints[102] , (short)dynConstraints[103] , (bool)dynConstraints[104] );
               case 1 :
                     return conditional_H004S3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (bool)dynConstraints[7] , (string)dynConstraints[8] , (short)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (bool)dynConstraints[14] , (string)dynConstraints[15] , (short)dynConstraints[16] , (string)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (string)dynConstraints[20] , (string)dynConstraints[21] , (string)dynConstraints[22] , (string)dynConstraints[23] , (string)dynConstraints[24] , (string)dynConstraints[25] , (string)dynConstraints[26] , (string)dynConstraints[27] , (string)dynConstraints[28] , (string)dynConstraints[29] , (string)dynConstraints[30] , (DateTime)dynConstraints[31] , (DateTime)dynConstraints[32] , (string)dynConstraints[33] , (string)dynConstraints[34] , (string)dynConstraints[35] , (string)dynConstraints[36] , (string)dynConstraints[37] , (string)dynConstraints[38] , (string)dynConstraints[39] , (string)dynConstraints[40] , (string)dynConstraints[41] , (string)dynConstraints[42] , (string)dynConstraints[43] , (string)dynConstraints[44] , (string)dynConstraints[45] , (string)dynConstraints[46] , (string)dynConstraints[47] , (string)dynConstraints[48] , (long)dynConstraints[49] , (long)dynConstraints[50] , (string)dynConstraints[51] , (string)dynConstraints[52] , (string)dynConstraints[53] , (string)dynConstraints[54] , (string)dynConstraints[55] , (string)dynConstraints[56] , (long)dynConstraints[57] , (long)dynConstraints[58] , (string)dynConstraints[59] , (string)dynConstraints[60] , (string)dynConstraints[61] , (string)dynConstraints[62] , (string)dynConstraints[63] , (string)dynConstraints[64] , (string)dynConstraints[65] , (string)dynConstraints[66] , (string)dynConstraints[67] , (string)dynConstraints[68] , (string)dynConstraints[69] , (string)dynConstraints[70] , (string)dynConstraints[71] , (string)dynConstraints[72] , (string)dynConstraints[73] , (string)dynConstraints[74] , (string)dynConstraints[75] , (string)dynConstraints[76] , (string)dynConstraints[77] , (string)dynConstraints[78] , (string)dynConstraints[79] , (string)dynConstraints[80] , (string)dynConstraints[81] , (string)dynConstraints[82] , (string)dynConstraints[83] , (string)dynConstraints[84] , (string)dynConstraints[85] , (string)dynConstraints[86] , (string)dynConstraints[87] , (long)dynConstraints[88] , (string)dynConstraints[89] , (string)dynConstraints[90] , (string)dynConstraints[91] , (long)dynConstraints[92] , (string)dynConstraints[93] , (string)dynConstraints[94] , (string)dynConstraints[95] , (string)dynConstraints[96] , (string)dynConstraints[97] , (string)dynConstraints[98] , (string)dynConstraints[99] , (string)dynConstraints[100] , (string)dynConstraints[101] , (DateTime)dynConstraints[102] , (short)dynConstraints[103] , (bool)dynConstraints[104] );
         }
         return base.getDynamicStatement(cursor, context, dynConstraints);
      }

      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
          new ForEachCursor(def[0])
         ,new ForEachCursor(def[1])
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          Object[] prmH004S2;
          prmH004S2 = new Object[] {
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV130Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV130Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV131Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV131Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV137Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV137Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV139Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV139Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV145Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV145Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV146Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV146Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV147Core_clientepjcontatowwds_22_tfcpjconnome",GXType.VarChar,80,0) ,
          new ParDef("AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim",GXType.VarChar,80,0) ,
          new ParDef("AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel",GXType.VarChar,80,0) ,
          new ParDef("lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome",GXType.VarChar,80,0) ,
          new ParDef("AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV153Core_clientepjcontatowwds_28_tfcpjcontiponome",GXType.VarChar,80,0) ,
          new ParDef("AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat",GXType.VarChar,14,0) ,
          new ParDef("AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel",GXType.VarChar,14,0) ,
          new ParDef("AV157Core_clientepjcontatowwds_32_tfcpjconnascimento",GXType.Date,8,0) ,
          new ParDef("AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to",GXType.Date,8,0) ,
          new ParDef("lV159Core_clientepjcontatowwds_34_tfcpjcongennome",GXType.VarChar,80,0) ,
          new ParDef("AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV161Core_clientepjcontatowwds_36_tfcpjconcelnum",GXType.Char,20,0) ,
          new ParDef("AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV163Core_clientepjcontatowwds_38_tfcpjcontelnum",GXType.Char,20,0) ,
          new ParDef("AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV165Core_clientepjcontatowwds_40_tfcpjcontelram",GXType.VarChar,10,0) ,
          new ParDef("AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV167Core_clientepjcontatowwds_42_tfcpjconwppnum",GXType.Char,20,0) ,
          new ParDef("AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV169Core_clientepjcontatowwds_44_tfcpjconemail",GXType.VarChar,100,0) ,
          new ParDef("AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV171Core_clientepjcontatowwds_46_tfcpjconlin",GXType.VarChar,1000,0) ,
          new ParDef("AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV173Core_clientepjcontatowwds_48_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV175Core_clientepjcontatowwds_50_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV176Core_clientepjcontatowwds_51_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV177Core_clientepjcontatowwds_52_tfcpjtiponome",GXType.VarChar,80,0) ,
          new ParDef("AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV179Core_clientepjcontatowwds_54_tfcpjnomefan",GXType.VarChar,80,0) ,
          new ParDef("AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel",GXType.VarChar,80,0) ,
          new ParDef("lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc",GXType.VarChar,80,0) ,
          new ParDef("AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel",GXType.VarChar,80,0) ,
          new ParDef("AV183Core_clientepjcontatowwds_58_tfcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat",GXType.VarChar,18,0) ,
          new ParDef("AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel",GXType.VarChar,18,0) ,
          new ParDef("lV187Core_clientepjcontatowwds_62_tfcpjie",GXType.VarChar,20,0) ,
          new ParDef("AV188Core_clientepjcontatowwds_63_tfcpjie_sel",GXType.VarChar,20,0) ,
          new ParDef("lV189Core_clientepjcontatowwds_64_tfcpjcelnum",GXType.Char,20,0) ,
          new ParDef("AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV191Core_clientepjcontatowwds_66_tfcpjtelnum",GXType.Char,20,0) ,
          new ParDef("AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV193Core_clientepjcontatowwds_68_tfcpjtelram",GXType.VarChar,10,0) ,
          new ParDef("AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV195Core_clientepjcontatowwds_70_tfcpjwppnum",GXType.Char,20,0) ,
          new ParDef("AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV197Core_clientepjcontatowwds_72_tfcpjemail",GXType.VarChar,100,0) ,
          new ParDef("AV198Core_clientepjcontatowwds_73_tfcpjemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV199Core_clientepjcontatowwds_74_tfcpjwebsite",GXType.VarChar,1000,0) ,
          new ParDef("AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel",GXType.VarChar,1000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004S3;
          prmH004S3 = new Object[] {
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV126Core_clientepjcontatowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV129Core_clientepjcontatowwds_4_cpjconnome1",GXType.VarChar,80,0) ,
          new ParDef("lV130Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV130Core_clientepjcontatowwds_5_cpjtiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV131Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV131Core_clientepjcontatowwds_6_cpjcontiponome1",GXType.VarChar,80,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV132Core_clientepjcontatowwds_7_cpjcongensigla1",GXType.VarChar,20,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV136Core_clientepjcontatowwds_11_cpjconnome2",GXType.VarChar,80,0) ,
          new ParDef("lV137Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV137Core_clientepjcontatowwds_12_cpjtiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV138Core_clientepjcontatowwds_13_cpjcontiponome2",GXType.VarChar,80,0) ,
          new ParDef("lV139Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV139Core_clientepjcontatowwds_14_cpjcongensigla2",GXType.VarChar,20,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV143Core_clientepjcontatowwds_18_cpjconnome3",GXType.VarChar,80,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV144Core_clientepjcontatowwds_19_cpjtiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV145Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV145Core_clientepjcontatowwds_20_cpjcontiponome3",GXType.VarChar,80,0) ,
          new ParDef("lV146Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV146Core_clientepjcontatowwds_21_cpjcongensigla3",GXType.VarChar,20,0) ,
          new ParDef("lV147Core_clientepjcontatowwds_22_tfcpjconnome",GXType.VarChar,80,0) ,
          new ParDef("AV148Core_clientepjcontatowwds_23_tfcpjconnome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV149Core_clientepjcontatowwds_24_tfcpjconnomeprim",GXType.VarChar,80,0) ,
          new ParDef("AV150Core_clientepjcontatowwds_25_tfcpjconnomeprim_sel",GXType.VarChar,80,0) ,
          new ParDef("lV151Core_clientepjcontatowwds_26_tfcpjconsobrenome",GXType.VarChar,80,0) ,
          new ParDef("AV152Core_clientepjcontatowwds_27_tfcpjconsobrenome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV153Core_clientepjcontatowwds_28_tfcpjcontiponome",GXType.VarChar,80,0) ,
          new ParDef("AV154Core_clientepjcontatowwds_29_tfcpjcontiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV155Core_clientepjcontatowwds_30_tfcpjconcpfformat",GXType.VarChar,14,0) ,
          new ParDef("AV156Core_clientepjcontatowwds_31_tfcpjconcpfformat_sel",GXType.VarChar,14,0) ,
          new ParDef("AV157Core_clientepjcontatowwds_32_tfcpjconnascimento",GXType.Date,8,0) ,
          new ParDef("AV158Core_clientepjcontatowwds_33_tfcpjconnascimento_to",GXType.Date,8,0) ,
          new ParDef("lV159Core_clientepjcontatowwds_34_tfcpjcongennome",GXType.VarChar,80,0) ,
          new ParDef("AV160Core_clientepjcontatowwds_35_tfcpjcongennome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV161Core_clientepjcontatowwds_36_tfcpjconcelnum",GXType.Char,20,0) ,
          new ParDef("AV162Core_clientepjcontatowwds_37_tfcpjconcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV163Core_clientepjcontatowwds_38_tfcpjcontelnum",GXType.Char,20,0) ,
          new ParDef("AV164Core_clientepjcontatowwds_39_tfcpjcontelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV165Core_clientepjcontatowwds_40_tfcpjcontelram",GXType.VarChar,10,0) ,
          new ParDef("AV166Core_clientepjcontatowwds_41_tfcpjcontelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV167Core_clientepjcontatowwds_42_tfcpjconwppnum",GXType.Char,20,0) ,
          new ParDef("AV168Core_clientepjcontatowwds_43_tfcpjconwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV169Core_clientepjcontatowwds_44_tfcpjconemail",GXType.VarChar,100,0) ,
          new ParDef("AV170Core_clientepjcontatowwds_45_tfcpjconemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV171Core_clientepjcontatowwds_46_tfcpjconlin",GXType.VarChar,1000,0) ,
          new ParDef("AV172Core_clientepjcontatowwds_47_tfcpjconlin_sel",GXType.VarChar,1000,0) ,
          new ParDef("lV173Core_clientepjcontatowwds_48_tfclinomefamiliar",GXType.VarChar,80,0) ,
          new ParDef("AV174Core_clientepjcontatowwds_49_tfclinomefamiliar_sel",GXType.VarChar,80,0) ,
          new ParDef("AV175Core_clientepjcontatowwds_50_tfclimatricula",GXType.Int64,12,0) ,
          new ParDef("AV176Core_clientepjcontatowwds_51_tfclimatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV177Core_clientepjcontatowwds_52_tfcpjtiponome",GXType.VarChar,80,0) ,
          new ParDef("AV178Core_clientepjcontatowwds_53_tfcpjtiponome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV179Core_clientepjcontatowwds_54_tfcpjnomefan",GXType.VarChar,80,0) ,
          new ParDef("AV180Core_clientepjcontatowwds_55_tfcpjnomefan_sel",GXType.VarChar,80,0) ,
          new ParDef("lV181Core_clientepjcontatowwds_56_tfcpjrazaosoc",GXType.VarChar,80,0) ,
          new ParDef("AV182Core_clientepjcontatowwds_57_tfcpjrazaosoc_sel",GXType.VarChar,80,0) ,
          new ParDef("AV183Core_clientepjcontatowwds_58_tfcpjmatricula",GXType.Int64,12,0) ,
          new ParDef("AV184Core_clientepjcontatowwds_59_tfcpjmatricula_to",GXType.Int64,12,0) ,
          new ParDef("lV185Core_clientepjcontatowwds_60_tfcpjcnpjformat",GXType.VarChar,18,0) ,
          new ParDef("AV186Core_clientepjcontatowwds_61_tfcpjcnpjformat_sel",GXType.VarChar,18,0) ,
          new ParDef("lV187Core_clientepjcontatowwds_62_tfcpjie",GXType.VarChar,20,0) ,
          new ParDef("AV188Core_clientepjcontatowwds_63_tfcpjie_sel",GXType.VarChar,20,0) ,
          new ParDef("lV189Core_clientepjcontatowwds_64_tfcpjcelnum",GXType.Char,20,0) ,
          new ParDef("AV190Core_clientepjcontatowwds_65_tfcpjcelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV191Core_clientepjcontatowwds_66_tfcpjtelnum",GXType.Char,20,0) ,
          new ParDef("AV192Core_clientepjcontatowwds_67_tfcpjtelnum_sel",GXType.Char,20,0) ,
          new ParDef("lV193Core_clientepjcontatowwds_68_tfcpjtelram",GXType.VarChar,10,0) ,
          new ParDef("AV194Core_clientepjcontatowwds_69_tfcpjtelram_sel",GXType.VarChar,10,0) ,
          new ParDef("lV195Core_clientepjcontatowwds_70_tfcpjwppnum",GXType.Char,20,0) ,
          new ParDef("AV196Core_clientepjcontatowwds_71_tfcpjwppnum_sel",GXType.Char,20,0) ,
          new ParDef("lV197Core_clientepjcontatowwds_72_tfcpjemail",GXType.VarChar,100,0) ,
          new ParDef("AV198Core_clientepjcontatowwds_73_tfcpjemail_sel",GXType.VarChar,100,0) ,
          new ParDef("lV199Core_clientepjcontatowwds_74_tfcpjwebsite",GXType.VarChar,1000,0) ,
          new ParDef("AV200Core_clientepjcontatowwds_75_tfcpjwebsite_sel",GXType.VarChar,1000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004S2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004S2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004S3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004S3,1, GxCacheFrequency.OFF ,true,false )
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
                ((int[]) buf[2])[0] = rslt.getInt(3);
                ((short[]) buf[3])[0] = rslt.getShort(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                ((Guid[]) buf[5])[0] = rslt.getGuid(6);
                ((string[]) buf[6])[0] = rslt.getVarchar(7);
                ((bool[]) buf[7])[0] = rslt.wasNull(7);
                ((string[]) buf[8])[0] = rslt.getVarchar(8);
                ((bool[]) buf[9])[0] = rslt.wasNull(8);
                ((string[]) buf[10])[0] = rslt.getString(9, 20);
                ((bool[]) buf[11])[0] = rslt.wasNull(9);
                ((string[]) buf[12])[0] = rslt.getVarchar(10);
                ((bool[]) buf[13])[0] = rslt.wasNull(10);
                ((string[]) buf[14])[0] = rslt.getString(11, 20);
                ((bool[]) buf[15])[0] = rslt.wasNull(11);
                ((string[]) buf[16])[0] = rslt.getString(12, 20);
                ((bool[]) buf[17])[0] = rslt.wasNull(12);
                ((string[]) buf[18])[0] = rslt.getVarchar(13);
                ((string[]) buf[19])[0] = rslt.getVarchar(14);
                ((long[]) buf[20])[0] = rslt.getLong(15);
                ((string[]) buf[21])[0] = rslt.getVarchar(16);
                ((string[]) buf[22])[0] = rslt.getVarchar(17);
                ((string[]) buf[23])[0] = rslt.getVarchar(18);
                ((long[]) buf[24])[0] = rslt.getLong(19);
                ((string[]) buf[25])[0] = rslt.getVarchar(20);
                ((string[]) buf[26])[0] = rslt.getVarchar(21);
                ((bool[]) buf[27])[0] = rslt.wasNull(21);
                ((string[]) buf[28])[0] = rslt.getVarchar(22);
                ((bool[]) buf[29])[0] = rslt.wasNull(22);
                ((string[]) buf[30])[0] = rslt.getString(23, 20);
                ((bool[]) buf[31])[0] = rslt.wasNull(23);
                ((string[]) buf[32])[0] = rslt.getVarchar(24);
                ((bool[]) buf[33])[0] = rslt.wasNull(24);
                ((string[]) buf[34])[0] = rslt.getString(25, 20);
                ((bool[]) buf[35])[0] = rslt.wasNull(25);
                ((string[]) buf[36])[0] = rslt.getString(26, 20);
                ((bool[]) buf[37])[0] = rslt.wasNull(26);
                ((string[]) buf[38])[0] = rslt.getVarchar(27);
                ((DateTime[]) buf[39])[0] = rslt.getGXDate(28);
                ((string[]) buf[40])[0] = rslt.getVarchar(29);
                ((string[]) buf[41])[0] = rslt.getVarchar(30);
                ((string[]) buf[42])[0] = rslt.getVarchar(31);
                ((string[]) buf[43])[0] = rslt.getVarchar(32);
                ((string[]) buf[44])[0] = rslt.getVarchar(33);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
