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
   public class parametrosww : GXDataArea
   {
      public parametrosww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametrosww( IGxContext context )
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
         chkavParametrodel_filtro = new GXCheckbox();
         cmbavDynamicfiltersoperatorparametrochave = new GXCombobox();
         cmbavDynamicfiltersoperatorparametrovalor = new GXCombobox();
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
         nRC_GXsfl_85 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_85"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_85_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_85_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_85_idx = GetPar( "sGXsfl_85_idx");
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
         cmbavDynamicfiltersoperatorparametrochave.FromJSonString( GetNextPar( ));
         AV58DynamicFiltersOperatorParametroChave = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperatorParametroChave"), "."), 18, MidpointRounding.ToEven));
         AV59ParametroChave = GetPar( "ParametroChave");
         cmbavDynamicfiltersoperatorparametrovalor.FromJSonString( GetNextPar( ));
         AV60DynamicFiltersOperatorParametroValor = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperatorParametroValor"), "."), 18, MidpointRounding.ToEven));
         AV61ParametroValor = GetPar( "ParametroValor");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV69Pgmname = GetPar( "Pgmname");
         AV67ParametroDel_Filtro = StringUtil.StrToBool( GetPar( "ParametroDel_Filtro"));
         AV41TFParametroChave = GetPar( "TFParametroChave");
         AV42TFParametroChave_Sel = GetPar( "TFParametroChave_Sel");
         AV62TFParametroDescricao = GetPar( "TFParametroDescricao");
         AV63TFParametroDescricao_Sel = GetPar( "TFParametroDescricao_Sel");
         AV43TFParametroValor = GetPar( "TFParametroValor");
         AV44TFParametroValor_Sel = GetPar( "TFParametroValor_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV53IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV54IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV57IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
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
            return "parametrosww_Execute" ;
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
         PA3R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3R2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.parametrosww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV54IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV54IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATORPARAMETROCHAVE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPARAMETROCHAVE", AV59ParametroChave);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATORPARAMETROVALOR", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vPARAMETROVALOR", AV61ParametroValor);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_85", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_85), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV49GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV50GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV51GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV55AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV55AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV45DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCHAVE", AV41TFParametroChave);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROCHAVE_SEL", AV42TFParametroChave_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETRODESCRICAO", AV62TFParametroDescricao);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETRODESCRICAO_SEL", AV63TFParametroDescricao_Sel);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROVALOR", AV43TFParametroValor);
         GxWebStd.gx_hidden_field( context, "vTFPARAMETROVALOR_SEL", AV44TFParametroValor_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV54IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV54IsAuthorized_Delete, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
         GxWebStd.gx_hidden_field( context, "vPARAMETROCHAVE_SELECTED", AV66ParametroChave_Selected);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Includedatalist", StringUtil.RTrim( Ddo_grid_Includedatalist));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalisttype", StringUtil.RTrim( Ddo_grid_Datalisttype));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Datalistproc", StringUtil.RTrim( Ddo_grid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Title", StringUtil.RTrim( Dvelop_confirmpanel_delete_Title));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmationtext));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Nobuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption", StringUtil.RTrim( Dvelop_confirmpanel_delete_Cancelbuttoncaption));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition", StringUtil.RTrim( Dvelop_confirmpanel_delete_Yesbuttonposition));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Confirmtype", StringUtil.RTrim( Dvelop_confirmpanel_delete_Confirmtype));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Fixedcolumns", StringUtil.RTrim( Grid_empowerer_Fixedcolumns));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_delete_Result));
         GxWebStd.gx_hidden_field( context, "DDO_AGEXPORT_Activeeventkey", StringUtil.RTrim( Ddo_agexport_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DVELOP_CONFIRMPANEL_DELETE_Result", StringUtil.RTrim( Dvelop_confirmpanel_delete_Result));
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
            WE3R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3R2( ) ;
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
         return formatLink("core.parametrosww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.ParametrosWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Parâmetros" ;
      }

      protected void WB3R0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs hidden-sm hidden-md hidden-lg Invisible", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavParametrodel_filtro_Internalname, "Parametro Del_Filtro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_85_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavParametrodel_filtro_Internalname, StringUtil.BoolToStr( AV67ParametroDel_Filtro), "", "Parametro Del_Filtro", 1, chkavParametrodel_filtro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(10, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,10);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(85), 2, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(85), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(85), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(85), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_29_3R2( true) ;
         }
         else
         {
            wb_table1_29_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_29_3R2e( bool wbgen )
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
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrowparametrochave_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefixparametrochave_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefixparametrochave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersfixedfiltercaptionparametrochave_Internalname, "Chave", "", "", lblDynamicfiltersfixedfiltercaptionparametrochave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFixedFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddleparametrochave_Internalname, "valor", "", "", lblDynamicfiltersmiddleparametrochave_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_52_3R2( true) ;
         }
         else
         {
            wb_table2_52_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_52_3R2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "DynRowVisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTabledynamicfiltersrowparametrovalor_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefixparametrovalor_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefixparametrovalor_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersfixedfiltercaptionparametrovalor_Internalname, "Valor", "", "", lblDynamicfiltersfixedfiltercaptionparametrovalor_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFixedFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddleparametrovalor_Internalname, "valor", "", "", lblDynamicfiltersmiddleparametrovalor_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_69_3R2( true) ;
         }
         else
         {
            wb_table3_69_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table3_69_3R2e( bool wbgen )
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
            StartGridControl85( ) ;
         }
         if ( wbEnd == 85 )
         {
            wbEnd = 0;
            nRC_GXsfl_85 = (int)(nGXsfl_85_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV49GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV50GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV51GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV55AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* User Defined Control */
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("IncludeSortASC", Ddo_grid_Includesortasc);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("IncludeFilter", Ddo_grid_Includefilter);
            ucDdo_grid.SetProperty("FilterType", Ddo_grid_Filtertype);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV45DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table4_100_3R2( true) ;
         }
         else
         {
            wb_table4_100_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table4_100_3R2e( bool wbgen )
      {
         if ( wbgen )
         {
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.SetProperty("FixedColumns", Grid_empowerer_Fixedcolumns);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0107"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0107"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_85_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0107"+"");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 85 )
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

      protected void START3R2( )
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
            Form.Meta.addItem("description", " Parâmetros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3R0( ) ;
      }

      protected void WS3R2( )
      {
         START3R2( ) ;
         EVT3R2( ) ;
      }

      protected void EVT3R2( )
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
                              E113R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E143R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E153R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E163R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E173R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E183R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E193R2 ();
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
                              nGXsfl_85_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_85_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_85_idx), 4, 0), 4, "0");
                              SubsflControlProps_852( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV52GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
                              A342ParametroChave = cgiGet( edtParametroChave_Internalname);
                              A344ParametroDescricao = cgiGet( edtParametroDescricao_Internalname);
                              n344ParametroDescricao = false;
                              A343ParametroValor = cgiGet( edtParametroValor_Internalname);
                              n343ParametroValor = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E203R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E213R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E223R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E233R2 ();
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
                                       /* Set Refresh If Dynamicfiltersoperatorparametrochave Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORPARAMETROCHAVE"), ",", ".") != Convert.ToDecimal( AV58DynamicFiltersOperatorParametroChave )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Parametrochave Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROCHAVE"), AV59ParametroChave) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperatorparametrovalor Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORPARAMETROVALOR"), ",", ".") != Convert.ToDecimal( AV60DynamicFiltersOperatorParametroValor )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Parametrovalor Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROVALOR"), AV61ParametroValor) != 0 )
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
                        if ( nCmpId == 107 )
                        {
                           OldWwpaux_wc = cgiGet( "W0107");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0107", "", sEvt);
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

      protected void WE3R2( )
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

      protected void PA3R2( )
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
               GX_FocusControl = chkavParametrodel_filtro_Internalname;
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
         SubsflControlProps_852( ) ;
         while ( nGXsfl_85_idx <= nRC_GXsfl_85 )
         {
            sendrow_852( ) ;
            nGXsfl_85_idx = ((subGrid_Islastpage==1)&&(nGXsfl_85_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_85_idx+1);
            sGXsfl_85_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_85_idx), 4, 0), 4, "0");
            SubsflControlProps_852( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       short AV58DynamicFiltersOperatorParametroChave ,
                                       string AV59ParametroChave ,
                                       short AV60DynamicFiltersOperatorParametroValor ,
                                       string AV61ParametroValor ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV69Pgmname ,
                                       bool AV67ParametroDel_Filtro ,
                                       string AV41TFParametroChave ,
                                       string AV42TFParametroChave_Sel ,
                                       string AV62TFParametroDescricao ,
                                       string AV63TFParametroDescricao_Sel ,
                                       string AV43TFParametroValor ,
                                       string AV44TFParametroValor_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       bool AV53IsAuthorized_Update ,
                                       bool AV54IsAuthorized_Delete ,
                                       bool AV57IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROCHAVE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( A342ParametroChave, "")), context));
         GxWebStd.gx_hidden_field( context, "PARAMETROCHAVE", A342ParametroChave);
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
         AV67ParametroDel_Filtro = StringUtil.StrToBool( StringUtil.BoolToStr( AV67ParametroDel_Filtro));
         AssignAttri("", false, "AV67ParametroDel_Filtro", AV67ParametroDel_Filtro);
         if ( cmbavDynamicfiltersoperatorparametrochave.ItemCount > 0 )
         {
            AV58DynamicFiltersOperatorParametroChave = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorparametrochave.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58DynamicFiltersOperatorParametroChave", StringUtil.LTrimStr( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperatorparametrochave.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorparametrochave_Internalname, "Values", cmbavDynamicfiltersoperatorparametrochave.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperatorparametrovalor.ItemCount > 0 )
         {
            AV60DynamicFiltersOperatorParametroValor = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorparametrovalor.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV60DynamicFiltersOperatorParametroValor", StringUtil.LTrimStr( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperatorparametrovalor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorparametrovalor_Internalname, "Values", cmbavDynamicfiltersoperatorparametrovalor.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV69Pgmname = "core.ParametrosWW";
      }

      protected void RF3R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 85;
         /* Execute user event: Refresh */
         E213R2 ();
         nGXsfl_85_idx = 1;
         sGXsfl_85_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_85_idx), 4, 0), 4, "0");
         SubsflControlProps_852( ) ;
         bGXsfl_85_Refreshing = true;
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
            SubsflControlProps_852( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV71Core_parametroswwds_2_filterfulltext ,
                                                 AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                                 AV72Core_parametroswwds_3_parametrochave ,
                                                 AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                                 AV74Core_parametroswwds_5_parametrovalor ,
                                                 AV77Core_parametroswwds_8_tfparametrochave_sel ,
                                                 AV76Core_parametroswwds_7_tfparametrochave ,
                                                 AV79Core_parametroswwds_10_tfparametrodescricao_sel ,
                                                 AV78Core_parametroswwds_9_tfparametrodescricao ,
                                                 AV81Core_parametroswwds_12_tfparametrovalor_sel ,
                                                 AV80Core_parametroswwds_11_tfparametrovalor ,
                                                 A342ParametroChave ,
                                                 A344ParametroDescricao ,
                                                 A343ParametroValor ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A518ParametroDel } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                                 }
            });
            lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
            lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
            lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
            lV72Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave), "%", "");
            lV72Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave), "%", "");
            lV74Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor), "%", "");
            lV74Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor), "%", "");
            lV76Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV76Core_parametroswwds_7_tfparametrochave), "%", "");
            lV78Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV78Core_parametroswwds_9_tfparametrodescricao), "%", "");
            lV80Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV80Core_parametroswwds_11_tfparametrovalor), "%", "");
            /* Using cursor H003R2 */
            pr_default.execute(0, new Object[] {lV71Core_parametroswwds_2_filterfulltext, lV71Core_parametroswwds_2_filterfulltext, lV71Core_parametroswwds_2_filterfulltext, lV72Core_parametroswwds_3_parametrochave, lV72Core_parametroswwds_3_parametrochave, lV74Core_parametroswwds_5_parametrovalor, lV74Core_parametroswwds_5_parametrovalor, lV76Core_parametroswwds_7_tfparametrochave, AV77Core_parametroswwds_8_tfparametrochave_sel, lV78Core_parametroswwds_9_tfparametrodescricao, AV79Core_parametroswwds_10_tfparametrodescricao_sel, lV80Core_parametroswwds_11_tfparametrovalor, AV81Core_parametroswwds_12_tfparametrovalor_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_85_idx = 1;
            sGXsfl_85_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_85_idx), 4, 0), 4, "0");
            SubsflControlProps_852( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A518ParametroDel = H003R2_A518ParametroDel[0];
               A343ParametroValor = H003R2_A343ParametroValor[0];
               n343ParametroValor = H003R2_n343ParametroValor[0];
               A344ParametroDescricao = H003R2_A344ParametroDescricao[0];
               n344ParametroDescricao = H003R2_n344ParametroDescricao[0];
               A342ParametroChave = H003R2_A342ParametroChave[0];
               E223R2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 85;
            WB3R0( ) ;
         }
         bGXsfl_85_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV69Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV69Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV54IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV54IsAuthorized_Delete, context));
         GxWebStd.gx_hidden_field( context, "gxhash_PARAMETROCHAVE"+"_"+sGXsfl_85_idx, GetSecureSignedToken( sGXsfl_85_idx, StringUtil.RTrim( context.localUtil.Format( A342ParametroChave, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
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
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV71Core_parametroswwds_2_filterfulltext ,
                                              AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                              AV72Core_parametroswwds_3_parametrochave ,
                                              AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                              AV74Core_parametroswwds_5_parametrovalor ,
                                              AV77Core_parametroswwds_8_tfparametrochave_sel ,
                                              AV76Core_parametroswwds_7_tfparametrochave ,
                                              AV79Core_parametroswwds_10_tfparametrodescricao_sel ,
                                              AV78Core_parametroswwds_9_tfparametrodescricao ,
                                              AV81Core_parametroswwds_12_tfparametrovalor_sel ,
                                              AV80Core_parametroswwds_11_tfparametrovalor ,
                                              A342ParametroChave ,
                                              A344ParametroDescricao ,
                                              A343ParametroValor ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A518ParametroDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.BOOLEAN
                                              }
         });
         lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
         lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
         lV71Core_parametroswwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext), "%", "");
         lV72Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave), "%", "");
         lV72Core_parametroswwds_3_parametrochave = StringUtil.Concat( StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave), "%", "");
         lV74Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor), "%", "");
         lV74Core_parametroswwds_5_parametrovalor = StringUtil.Concat( StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor), "%", "");
         lV76Core_parametroswwds_7_tfparametrochave = StringUtil.Concat( StringUtil.RTrim( AV76Core_parametroswwds_7_tfparametrochave), "%", "");
         lV78Core_parametroswwds_9_tfparametrodescricao = StringUtil.Concat( StringUtil.RTrim( AV78Core_parametroswwds_9_tfparametrodescricao), "%", "");
         lV80Core_parametroswwds_11_tfparametrovalor = StringUtil.Concat( StringUtil.RTrim( AV80Core_parametroswwds_11_tfparametrovalor), "%", "");
         /* Using cursor H003R3 */
         pr_default.execute(1, new Object[] {lV71Core_parametroswwds_2_filterfulltext, lV71Core_parametroswwds_2_filterfulltext, lV71Core_parametroswwds_2_filterfulltext, lV72Core_parametroswwds_3_parametrochave, lV72Core_parametroswwds_3_parametrochave, lV74Core_parametroswwds_5_parametrovalor, lV74Core_parametroswwds_5_parametrovalor, lV76Core_parametroswwds_7_tfparametrochave, AV77Core_parametroswwds_8_tfparametrochave_sel, lV78Core_parametroswwds_9_tfparametrodescricao, AV79Core_parametroswwds_10_tfparametrodescricao_sel, lV80Core_parametroswwds_11_tfparametrovalor, AV81Core_parametroswwds_12_tfparametrovalor_sel});
         GRID_nRecordCount = H003R3_AGRID_nRecordCount[0];
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
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV69Pgmname = "core.ParametrosWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E203R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV55AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV45DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_85 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_85"), ",", "."), 18, MidpointRounding.ToEven));
            AV49GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV50GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV51GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Includedatalist = cgiGet( "DDO_GRID_Includedatalist");
            Ddo_grid_Datalisttype = cgiGet( "DDO_GRID_Datalisttype");
            Ddo_grid_Datalistproc = cgiGet( "DDO_GRID_Datalistproc");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Dvelop_confirmpanel_delete_Title = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Title");
            Dvelop_confirmpanel_delete_Confirmationtext = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmationtext");
            Dvelop_confirmpanel_delete_Yesbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttoncaption");
            Dvelop_confirmpanel_delete_Nobuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Nobuttoncaption");
            Dvelop_confirmpanel_delete_Cancelbuttoncaption = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Cancelbuttoncaption");
            Dvelop_confirmpanel_delete_Yesbuttonposition = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Yesbuttonposition");
            Dvelop_confirmpanel_delete_Confirmtype = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Confirmtype");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            Grid_empowerer_Fixedcolumns = cgiGet( "GRID_EMPOWERER_Fixedcolumns");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_delete_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Result");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV67ParametroDel_Filtro = StringUtil.StrToBool( cgiGet( chkavParametrodel_filtro_Internalname));
            AssignAttri("", false, "AV67ParametroDel_Filtro", AV67ParametroDel_Filtro);
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            cmbavDynamicfiltersoperatorparametrochave.Name = cmbavDynamicfiltersoperatorparametrochave_Internalname;
            cmbavDynamicfiltersoperatorparametrochave.CurrentValue = cgiGet( cmbavDynamicfiltersoperatorparametrochave_Internalname);
            AV58DynamicFiltersOperatorParametroChave = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperatorparametrochave_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58DynamicFiltersOperatorParametroChave", StringUtil.LTrimStr( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
            AV59ParametroChave = cgiGet( edtavParametrochave_Internalname);
            AssignAttri("", false, "AV59ParametroChave", AV59ParametroChave);
            cmbavDynamicfiltersoperatorparametrovalor.Name = cmbavDynamicfiltersoperatorparametrovalor_Internalname;
            cmbavDynamicfiltersoperatorparametrovalor.CurrentValue = cgiGet( cmbavDynamicfiltersoperatorparametrovalor_Internalname);
            AV60DynamicFiltersOperatorParametroValor = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperatorparametrovalor_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV60DynamicFiltersOperatorParametroValor", StringUtil.LTrimStr( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
            AV61ParametroValor = cgiGet( edtavParametrovalor_Internalname);
            AssignAttri("", false, "AV61ParametroValor", AV61ParametroValor);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORPARAMETROCHAVE"), ",", ".") != Convert.ToDecimal( AV58DynamicFiltersOperatorParametroChave )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROCHAVE"), AV59ParametroChave) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATORPARAMETROVALOR"), ",", ".") != Convert.ToDecimal( AV60DynamicFiltersOperatorParametroValor )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vPARAMETROVALOR"), AV61ParametroValor) != 0 )
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
         E203R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E203R2( )
      {
         /* Start Routine */
         returnInSub = false;
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
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
         Ddo_agexport_Titlecontrolidtoreplace = bttBtnagexport_Internalname;
         ucDdo_agexport.SendProperty(context, "", false, Ddo_agexport_Internalname, "TitleControlIdToReplace", Ddo_agexport_Titlecontrolidtoreplace);
         AV55AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV56AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV56AGExportDataItem.gxTpr_Title = "Excel";
         AV56AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV56AGExportDataItem.gxTpr_Eventkey = "Export";
         AV56AGExportDataItem.gxTpr_Isdivider = false;
         AV55AGExportData.Add(AV56AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV47GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV46GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Parâmetros";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'PREPARETRANSACTION' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV45DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV45DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E213R2( )
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
         S152 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( AV40ManageFiltersExecutionStep == 1 )
         {
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV40ManageFiltersExecutionStep == 2 )
         {
            AV40ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S162 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV37Session.Get("core.ParametrosWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("core.ParametrosWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S172 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         edtParametroChave_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroChave_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroChave_Visible), 5, 0), !bGXsfl_85_Refreshing);
         edtParametroDescricao_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroDescricao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroDescricao_Visible), 5, 0), !bGXsfl_85_Refreshing);
         edtParametroValor_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtParametroValor_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtParametroValor_Visible), 5, 0), !bGXsfl_85_Refreshing);
         AV49GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV49GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV49GridCurrentPage), 10, 0));
         AV50GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV50GridPageCount", StringUtil.LTrimStr( (decimal)(AV50GridPageCount), 10, 0));
         GXt_char2 = AV51GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV69Pgmname, out  GXt_char2) ;
         AV51GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV51GridAppliedFilters", AV51GridAppliedFilters);
         AV70Core_parametroswwds_1_parametrodel_filtro = AV67ParametroDel_Filtro;
         AV71Core_parametroswwds_2_filterfulltext = AV17FilterFullText;
         AV72Core_parametroswwds_3_parametrochave = AV59ParametroChave;
         AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave = AV58DynamicFiltersOperatorParametroChave;
         AV74Core_parametroswwds_5_parametrovalor = AV61ParametroValor;
         AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor = AV60DynamicFiltersOperatorParametroValor;
         AV76Core_parametroswwds_7_tfparametrochave = AV41TFParametroChave;
         AV77Core_parametroswwds_8_tfparametrochave_sel = AV42TFParametroChave_Sel;
         AV78Core_parametroswwds_9_tfparametrodescricao = AV62TFParametroDescricao;
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = AV63TFParametroDescricao_Sel;
         AV80Core_parametroswwds_11_tfparametrovalor = AV43TFParametroValor;
         AV81Core_parametroswwds_12_tfparametrovalor_sel = AV44TFParametroValor_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123R2( )
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
            AV48PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV48PageToGo) ;
         }
      }

      protected void E133R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E163R2( )
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
            S142 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_grid_Activeeventkey, "<#Filter#>") == 0 )
         {
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroChave") == 0 )
            {
               AV41TFParametroChave = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFParametroChave", AV41TFParametroChave);
               AV42TFParametroChave_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFParametroChave_Sel", AV42TFParametroChave_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroDescricao") == 0 )
            {
               AV62TFParametroDescricao = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV62TFParametroDescricao", AV62TFParametroDescricao);
               AV63TFParametroDescricao_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV63TFParametroDescricao_Sel", AV63TFParametroDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "ParametroValor") == 0 )
            {
               AV43TFParametroValor = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFParametroValor", AV43TFParametroValor);
               AV44TFParametroValor_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFParametroValor_Sel", AV44TFParametroValor_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E223R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV53IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV54IsAuthorized_Delete )
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
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 85;
         }
         sendrow_852( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_85_Refreshing )
         {
            DoAjaxLoad(85, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
      }

      protected void E173R2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.ParametrosWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E113R2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S182 ();
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
            S162 ();
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.ParametrosWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV69Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.ParametrosWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.ParametrosWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV39ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado não existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S182 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
               AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
               AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
               AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
               AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
               /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
               S142 ();
               if ( returnInSub )
               {
                  returnInSub = true;
                  if (true) return;
               }
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S192 ();
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
         cmbavDynamicfiltersoperatorparametrochave.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperatorparametrochave_Internalname, "Values", cmbavDynamicfiltersoperatorparametrochave.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperatorparametrovalor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperatorparametrovalor_Internalname, "Values", cmbavDynamicfiltersoperatorparametrovalor.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E233R2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV52GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV52GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S212 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV52GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E183R2( )
      {
         /* Dvelop_confirmpanel_delete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_delete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETE' */
            S222 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E193R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV57IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.parametros.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(StringUtil.RTrim(""));
            CallWebObject(formatLink("core.parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E143R2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S232 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersoperatorparametrovalor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperatorparametrovalor_Internalname, "Values", cmbavDynamicfiltersoperatorparametrovalor.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperatorparametrochave.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperatorparametrochave_Internalname, "Values", cmbavDynamicfiltersoperatorparametrochave.ToJavascriptSource(), true);
      }

      protected void E153R2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0107",(string)"",(string)"Parametros",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0107"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void S142( )
      {
         /* 'SETDDOSORTEDSTATUS' Routine */
         returnInSub = false;
         Ddo_grid_Sortedstatus = StringUtil.Trim( StringUtil.Str( (decimal)(AV14OrderedBy), 4, 0))+":"+(AV15OrderedDsc ? "DSC" : "ASC");
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SortedStatus", Ddo_grid_Sortedstatus);
      }

      protected void S172( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ParametroChave",  "",  "Chave",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ParametroDescricao",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "ParametroValor",  "",  "Valor",  true,  "") ;
         GXt_char2 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.ParametrosWWColumnsSelector", out  GXt_char2) ;
         AV34UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV53IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametros_Update", out  GXt_boolean3) ;
         AV53IsAuthorized_Update = GXt_boolean3;
         AssignAttri("", false, "AV53IsAuthorized_Update", AV53IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV53IsAuthorized_Update, context));
         GXt_boolean3 = AV54IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametros_Delete", out  GXt_boolean3) ;
         AV54IsAuthorized_Delete = GXt_boolean3;
         AssignAttri("", false, "AV54IsAuthorized_Delete", AV54IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV54IsAuthorized_Delete, context));
         GXt_boolean3 = AV57IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "parametros_Insert", out  GXt_boolean3) ;
         AV57IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV57IsAuthorized_Insert", AV57IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV57IsAuthorized_Insert, context));
         if ( ! ( AV57IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "Parametros",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.ParametrosWWFilters",  "",  "",  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV67ParametroDel_Filtro = false;
         AssignAttri("", false, "AV67ParametroDel_Filtro", AV67ParametroDel_Filtro);
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV58DynamicFiltersOperatorParametroChave = 0;
         AssignAttri("", false, "AV58DynamicFiltersOperatorParametroChave", StringUtil.LTrimStr( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
         AV59ParametroChave = "";
         AssignAttri("", false, "AV59ParametroChave", AV59ParametroChave);
         AV60DynamicFiltersOperatorParametroValor = 0;
         AssignAttri("", false, "AV60DynamicFiltersOperatorParametroValor", StringUtil.LTrimStr( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
         AV61ParametroValor = "";
         AssignAttri("", false, "AV61ParametroValor", AV61ParametroValor);
         AV41TFParametroChave = "";
         AssignAttri("", false, "AV41TFParametroChave", AV41TFParametroChave);
         AV42TFParametroChave_Sel = "";
         AssignAttri("", false, "AV42TFParametroChave_Sel", AV42TFParametroChave_Sel);
         AV62TFParametroDescricao = "";
         AssignAttri("", false, "AV62TFParametroDescricao", AV62TFParametroDescricao);
         AV63TFParametroDescricao_Sel = "";
         AssignAttri("", false, "AV63TFParametroDescricao_Sel", AV63TFParametroDescricao_Sel);
         AV43TFParametroValor = "";
         AssignAttri("", false, "AV43TFParametroValor", AV43TFParametroValor);
         AV44TFParametroValor_Sel = "";
         AssignAttri("", false, "AV44TFParametroValor_Sel", AV44TFParametroValor_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S202( )
      {
         /* 'DO UPDATE' Routine */
         returnInSub = false;
         if ( AV53IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.parametros.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(StringUtil.RTrim(A342ParametroChave));
            CallWebObject(formatLink("core.parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S212( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         if ( AV54IsAuthorized_Delete )
         {
            AV66ParametroChave_Selected = A342ParametroChave;
            AssignAttri("", false, "AV66ParametroChave_Selected", AV66ParametroChave_Selected);
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_DELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S222( )
      {
         /* 'DO ACTION DELETE' Routine */
         returnInSub = false;
         if ( 1 == 2 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.parametros.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(StringUtil.RTrim(AV66ParametroChave_Selected));
            CallWebObject(formatLink("core.parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV68sdtParametros = new GeneXus.Programs.core.SdtsdtParametros(context);
         AV68sdtParametros.gxTpr_Parametrochave = AV66ParametroChave_Selected;
         new GeneXus.Programs.core.prcparametrosobterdadosindividual(context ).execute( ref  AV68sdtParametros) ;
         AV68sdtParametros.gxTpr_Parametrodel = true;
         new GeneXus.Programs.core.prcparametrosmanterdados(context ).execute(  AV68sdtParametros,  true, out  AV65Messages) ;
         AV82GXV1 = 1;
         while ( AV82GXV1 <= AV65Messages.Count )
         {
            AV64Message = ((GeneXus.Utils.SdtMessages_Message)AV65Messages.Item(AV82GXV1));
            GX_msglist.addItem(AV64Message.gxTpr_Description);
            AV82GXV1 = (int)(AV82GXV1+1);
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV58DynamicFiltersOperatorParametroChave, AV59ParametroChave, AV60DynamicFiltersOperatorParametroValor, AV61ParametroValor, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV69Pgmname, AV67ParametroDel_Filtro, AV41TFParametroChave, AV42TFParametroChave_Sel, AV62TFParametroDescricao, AV63TFParametroDescricao_Sel, AV43TFParametroValor, AV44TFParametroValor_Sel, AV14OrderedBy, AV15OrderedDsc, AV53IsAuthorized_Update, AV54IsAuthorized_Delete, AV57IsAuthorized_Insert) ;
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV69Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV69Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV69Pgmname+"GridState"), null, "", "");
         }
         AV14OrderedBy = AV11GridState.gxTpr_Orderedby;
         AssignAttri("", false, "AV14OrderedBy", StringUtil.LTrimStr( (decimal)(AV14OrderedBy), 4, 0));
         AV15OrderedDsc = AV11GridState.gxTpr_Ordereddsc;
         AssignAttri("", false, "AV15OrderedDsc", AV15OrderedDsc);
         /* Execute user subroutine: 'SETDDOSORTEDSTATUS' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S192 ();
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

      protected void S192( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV83GXV2 = 1;
         while ( AV83GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV83GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "PARAMETRODEL_FILTRO") == 0 )
            {
               AV67ParametroDel_Filtro = BooleanUtil.Val( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV67ParametroDel_Filtro", AV67ParametroDel_Filtro);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "PARAMETROCHAVE") == 0 )
            {
               AV59ParametroChave = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV59ParametroChave", AV59ParametroChave);
               AV58DynamicFiltersOperatorParametroChave = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV58DynamicFiltersOperatorParametroChave", StringUtil.LTrimStr( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "PARAMETROVALOR") == 0 )
            {
               AV61ParametroValor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV61ParametroValor", AV61ParametroValor);
               AV60DynamicFiltersOperatorParametroValor = AV12GridStateFilterValue.gxTpr_Operator;
               AssignAttri("", false, "AV60DynamicFiltersOperatorParametroValor", StringUtil.LTrimStr( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE") == 0 )
            {
               AV41TFParametroChave = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFParametroChave", AV41TFParametroChave);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROCHAVE_SEL") == 0 )
            {
               AV42TFParametroChave_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFParametroChave_Sel", AV42TFParametroChave_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO") == 0 )
            {
               AV62TFParametroDescricao = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV62TFParametroDescricao", AV62TFParametroDescricao);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETRODESCRICAO_SEL") == 0 )
            {
               AV63TFParametroDescricao_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV63TFParametroDescricao_Sel", AV63TFParametroDescricao_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR") == 0 )
            {
               AV43TFParametroValor = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFParametroValor", AV43TFParametroValor);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFPARAMETROVALOR_SEL") == 0 )
            {
               AV44TFParametroValor_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFParametroValor_Sel", AV44TFParametroValor_Sel);
            }
            AV83GXV2 = (int)(AV83GXV2+1);
         }
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroChave_Sel)),  AV42TFParametroChave_Sel, out  GXt_char2) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV63TFParametroDescricao_Sel)),  AV63TFParametroDescricao_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFParametroValor_Sel)),  AV44TFParametroValor_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = GXt_char2+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParametroChave)),  AV41TFParametroChave, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroDescricao)),  AV62TFParametroDescricao, out  GXt_char5) ;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParametroValor)),  AV43TFParametroValor, out  GXt_char2) ;
         Ddo_grid_Filteredtext_set = GXt_char6+"|"+GXt_char5+"|"+GXt_char2;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV69Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "PARAMETRODEL_FILTRO",  "Excluído",  !(false==AV67ParametroDel_Filtro),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV67ParametroDel_Filtro)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "PARAMETROCHAVE",  "Chave",  !String.IsNullOrEmpty(StringUtil.RTrim( AV59ParametroChave)),  AV58DynamicFiltersOperatorParametroChave,  AV59ParametroChave,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "PARAMETROVALOR",  "Valor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV61ParametroValor)),  AV60DynamicFiltersOperatorParametroValor,  AV61ParametroValor,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROCHAVE",  "Chave",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFParametroChave)),  0,  AV41TFParametroChave,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFParametroChave_Sel)),  AV42TFParametroChave_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETRODESCRICAO",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV62TFParametroDescricao)),  0,  AV62TFParametroDescricao,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV63TFParametroDescricao_Sel)),  AV63TFParametroDescricao_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFPARAMETROVALOR",  "Valor",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFParametroValor)),  0,  AV43TFParametroValor,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFParametroValor_Sel)),  AV44TFParametroValor_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV69Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV69Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.Parametros";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S232( )
      {
         /* 'DOEXPORT' Routine */
         returnInSub = false;
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         new GeneXus.Programs.core.parametroswwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
         if ( StringUtil.StrCmp(AV31ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV31ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV32ErrorMessage);
         }
      }

      protected void wb_table4_100_3R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTabledvelop_confirmpanel_delete_Internalname, tblTabledvelop_confirmpanel_delete_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tbody>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td data-align=\"center\"  style=\""+CSSHelper.Prettify( "text-align:-khtml-center;text-align:-moz-center;text-align:-webkit-center")+"\">") ;
            /* User Defined Control */
            ucDvelop_confirmpanel_delete.SetProperty("Title", Dvelop_confirmpanel_delete_Title);
            ucDvelop_confirmpanel_delete.SetProperty("ConfirmationText", Dvelop_confirmpanel_delete_Confirmationtext);
            ucDvelop_confirmpanel_delete.SetProperty("YesButtonCaption", Dvelop_confirmpanel_delete_Yesbuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("NoButtonCaption", Dvelop_confirmpanel_delete_Nobuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("CancelButtonCaption", Dvelop_confirmpanel_delete_Cancelbuttoncaption);
            ucDvelop_confirmpanel_delete.SetProperty("YesButtonPosition", Dvelop_confirmpanel_delete_Yesbuttonposition);
            ucDvelop_confirmpanel_delete.SetProperty("ConfirmType", Dvelop_confirmpanel_delete_Confirmtype);
            ucDvelop_confirmpanel_delete.Render(context, "dvelop.gxbootstrap.confirmpanel", Dvelop_confirmpanel_delete_Internalname, "DVELOP_CONFIRMPANEL_DELETEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVELOP_CONFIRMPANEL_DELETEContainer"+"Body"+"\" style=\"display:none;\">") ;
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "</tbody>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_100_3R2e( true) ;
         }
         else
         {
            wb_table4_100_3R2e( false) ;
         }
      }

      protected void wb_table3_69_3R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersparametrovalor_Internalname, tblTablemergeddynamicfiltersparametrovalor_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperatorparametrovalor_Internalname, "Dynamic Filters Operator Parametro Valor", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'" + sGXsfl_85_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperatorparametrovalor, cmbavDynamicfiltersoperatorparametrovalor_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0)), 1, cmbavDynamicfiltersoperatorparametrovalor_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDynamicfiltersoperatorparametrovalor.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "", true, 0, "HLP_core\\ParametrosWW.htm");
            cmbavDynamicfiltersoperatorparametrovalor.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorparametrovalor_Internalname, "Values", (string)(cmbavDynamicfiltersoperatorparametrovalor.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParametrovalor_Internalname, "Parametro Valor", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'" + sGXsfl_85_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavParametrovalor_Internalname, AV61ParametroValor, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,76);\"", 0, 1, edtavParametrovalor_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_69_3R2e( true) ;
         }
         else
         {
            wb_table3_69_3R2e( false) ;
         }
      }

      protected void wb_table2_52_3R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablemergeddynamicfiltersparametrochave_Internalname, tblTablemergeddynamicfiltersparametrochave_Internalname, "", "Table", 0, "", "", 0, 0, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersoperatorparametrochave_Internalname, "Dynamic Filters Operator Parametro Chave", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'" + sGXsfl_85_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperatorparametrochave, cmbavDynamicfiltersoperatorparametrochave_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0)), 1, cmbavDynamicfiltersoperatorparametrochave_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavDynamicfiltersoperatorparametrochave.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,56);\"", "", true, 0, "HLP_core\\ParametrosWW.htm");
            cmbavDynamicfiltersoperatorparametrochave.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperatorparametrochave_Internalname, "Values", (string)(cmbavDynamicfiltersoperatorparametrochave.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavParametrochave_Internalname, "Parametro Chave", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'" + sGXsfl_85_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavParametrochave_Internalname, AV59ParametroChave, StringUtil.RTrim( context.localUtil.Format( AV59ParametroChave, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavParametrochave_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavParametrochave_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_52_3R2e( true) ;
         }
         else
         {
            wb_table2_52_3R2e( false) ;
         }
      }

      protected void wb_table1_29_3R2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV38ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table5_34_3R2( true) ;
         }
         else
         {
            wb_table5_34_3R2( false) ;
         }
         return  ;
      }

      protected void wb_table5_34_3R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_29_3R2e( true) ;
         }
         else
         {
            wb_table1_29_3R2e( false) ;
         }
      }

      protected void wb_table5_34_3R2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_85_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\ParametrosWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table5_34_3R2e( true) ;
         }
         else
         {
            wb_table5_34_3R2e( false) ;
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
         PA3R2( ) ;
         WS3R2( ) ;
         WE3R2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828222169", true, true);
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
         context.AddJavascriptSource("core/parametrosww.js", "?2023828222171", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_852( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_85_idx;
         edtParametroChave_Internalname = "PARAMETROCHAVE_"+sGXsfl_85_idx;
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO_"+sGXsfl_85_idx;
         edtParametroValor_Internalname = "PARAMETROVALOR_"+sGXsfl_85_idx;
      }

      protected void SubsflControlProps_fel_852( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_85_fel_idx;
         edtParametroChave_Internalname = "PARAMETROCHAVE_"+sGXsfl_85_fel_idx;
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO_"+sGXsfl_85_fel_idx;
         edtParametroValor_Internalname = "PARAMETROVALOR_"+sGXsfl_85_fel_idx;
      }

      protected void sendrow_852( )
      {
         SubsflControlProps_852( ) ;
         WB3R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_85_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_85_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_85_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 86,'',false,'"+sGXsfl_85_idx+"',85)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_85_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV52GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_85_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,86);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_85_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroChave_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroChave_Internalname,(string)A342ParametroChave,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroChave_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroChave_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)100,(short)0,(short)0,(short)85,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroDescricao_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroDescricao_Internalname,(string)A344ParametroDescricao,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroDescricao_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroDescricao_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)500,(short)0,(short)0,(short)85,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtParametroValor_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtParametroValor_Internalname,(string)A343ParametroValor,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtParametroValor_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtParametroValor_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2000,(short)0,(short)0,(short)85,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes3R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_85_idx = ((subGrid_Islastpage==1)&&(nGXsfl_85_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_85_idx+1);
            sGXsfl_85_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_85_idx), 4, 0), 4, "0");
            SubsflControlProps_852( ) ;
         }
         /* End function sendrow_852 */
      }

      protected void init_web_controls( )
      {
         chkavParametrodel_filtro.Name = "vPARAMETRODEL_FILTRO";
         chkavParametrodel_filtro.WebTags = "";
         chkavParametrodel_filtro.Caption = "";
         AssignProp("", false, chkavParametrodel_filtro_Internalname, "TitleCaption", chkavParametrodel_filtro.Caption, true);
         chkavParametrodel_filtro.CheckedValue = "false";
         AV67ParametroDel_Filtro = StringUtil.StrToBool( StringUtil.BoolToStr( AV67ParametroDel_Filtro));
         AssignAttri("", false, "AV67ParametroDel_Filtro", AV67ParametroDel_Filtro);
         cmbavDynamicfiltersoperatorparametrochave.Name = "vDYNAMICFILTERSOPERATORPARAMETROCHAVE";
         cmbavDynamicfiltersoperatorparametrochave.WebTags = "";
         cmbavDynamicfiltersoperatorparametrochave.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperatorparametrochave.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperatorparametrochave.ItemCount > 0 )
         {
            AV58DynamicFiltersOperatorParametroChave = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorparametrochave.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV58DynamicFiltersOperatorParametroChave", StringUtil.LTrimStr( (decimal)(AV58DynamicFiltersOperatorParametroChave), 4, 0));
         }
         cmbavDynamicfiltersoperatorparametrovalor.Name = "vDYNAMICFILTERSOPERATORPARAMETROVALOR";
         cmbavDynamicfiltersoperatorparametrovalor.WebTags = "";
         cmbavDynamicfiltersoperatorparametrovalor.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperatorparametrovalor.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperatorparametrovalor.ItemCount > 0 )
         {
            AV60DynamicFiltersOperatorParametroValor = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperatorparametrovalor.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV60DynamicFiltersOperatorParametroValor", StringUtil.LTrimStr( (decimal)(AV60DynamicFiltersOperatorParametroValor), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_85_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV52GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV52GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV52GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl85( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"85\">") ;
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroChave_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Chave") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroDescricao_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtParametroValor_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Valor") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV52GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A342ParametroChave));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroChave_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A344ParametroDescricao));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroDescricao_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A343ParametroValor));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtParametroValor_Visible), 5, 0, ".", "")));
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
         chkavParametrodel_filtro_Internalname = "vPARAMETRODEL_FILTRO";
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
         lblDynamicfiltersprefixparametrochave_Internalname = "DYNAMICFILTERSPREFIXPARAMETROCHAVE";
         lblDynamicfiltersfixedfiltercaptionparametrochave_Internalname = "DYNAMICFILTERSFIXEDFILTERCAPTIONPARAMETROCHAVE";
         lblDynamicfiltersmiddleparametrochave_Internalname = "DYNAMICFILTERSMIDDLEPARAMETROCHAVE";
         cmbavDynamicfiltersoperatorparametrochave_Internalname = "vDYNAMICFILTERSOPERATORPARAMETROCHAVE";
         edtavParametrochave_Internalname = "vPARAMETROCHAVE";
         tblTablemergeddynamicfiltersparametrochave_Internalname = "TABLEMERGEDDYNAMICFILTERSPARAMETROCHAVE";
         divTabledynamicfiltersrowparametrochave_Internalname = "TABLEDYNAMICFILTERSROWPARAMETROCHAVE";
         lblDynamicfiltersprefixparametrovalor_Internalname = "DYNAMICFILTERSPREFIXPARAMETROVALOR";
         lblDynamicfiltersfixedfiltercaptionparametrovalor_Internalname = "DYNAMICFILTERSFIXEDFILTERCAPTIONPARAMETROVALOR";
         lblDynamicfiltersmiddleparametrovalor_Internalname = "DYNAMICFILTERSMIDDLEPARAMETROVALOR";
         cmbavDynamicfiltersoperatorparametrovalor_Internalname = "vDYNAMICFILTERSOPERATORPARAMETROVALOR";
         edtavParametrovalor_Internalname = "vPARAMETROVALOR";
         tblTablemergeddynamicfiltersparametrovalor_Internalname = "TABLEMERGEDDYNAMICFILTERSPARAMETROVALOR";
         divTabledynamicfiltersrowparametrovalor_Internalname = "TABLEDYNAMICFILTERSROWPARAMETROVALOR";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtParametroChave_Internalname = "PARAMETROCHAVE";
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO";
         edtParametroValor_Internalname = "PARAMETROVALOR";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_delete_Internalname = "DVELOP_CONFIRMPANEL_DELETE";
         tblTabledvelop_confirmpanel_delete_Internalname = "TABLEDVELOP_CONFIRMPANEL_DELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
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
         chkavParametrodel_filtro.Caption = "Parametro Del_Filtro";
         edtParametroValor_Jsonclick = "";
         edtParametroDescricao_Jsonclick = "";
         edtParametroChave_Jsonclick = "";
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         cmbavGridactions_Class = "ConvertToDDO";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtavParametrochave_Jsonclick = "";
         edtavParametrochave_Enabled = 1;
         cmbavDynamicfiltersoperatorparametrochave_Jsonclick = "";
         cmbavDynamicfiltersoperatorparametrochave.Enabled = 1;
         edtavParametrovalor_Enabled = 1;
         cmbavDynamicfiltersoperatorparametrovalor_Jsonclick = "";
         cmbavDynamicfiltersoperatorparametrovalor.Enabled = 1;
         edtParametroValor_Visible = -1;
         edtParametroDescricao_Visible = -1;
         edtParametroChave_Visible = -1;
         subGrid_Sortable = 0;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         chkavParametrodel_filtro.Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_delete_Confirmtype = "1";
         Dvelop_confirmpanel_delete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_delete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_delete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_delete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_delete_Confirmationtext = "Deseja realmente EXCLUIR o PARÂMETRO?";
         Dvelop_confirmpanel_delete_Title = "Decida";
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Datalistproc = "core.ParametrosWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "T";
         Ddo_grid_Filtertype = "Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "1:ParametroChave|2:ParametroDescricao|3:ParametroValor";
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
         Form.Caption = " Parâmetros";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E163R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E223R2',iparms:[{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E173R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E233R2',iparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A342ParametroChave',fld:'PARAMETROCHAVE',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV52GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV66ParametroChave_Selected',fld:'vPARAMETROCHAVE_SELECTED',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE","{handler:'E183R2',iparms:[{av:'Dvelop_confirmpanel_delete_Result',ctrl:'DVELOP_CONFIRMPANEL_DELETE',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV66ParametroChave_Selected',fld:'vPARAMETROCHAVE_SELECTED',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E193R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A342ParametroChave',fld:'PARAMETROCHAVE',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtParametroChave_Visible',ctrl:'PARAMETROCHAVE',prop:'Visible'},{av:'edtParametroDescricao_Visible',ctrl:'PARAMETRODESCRICAO',prop:'Visible'},{av:'edtParametroValor_Visible',ctrl:'PARAMETROVALOR',prop:'Visible'},{av:'AV49GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV50GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV51GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E143R2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersoperatorparametrochave'},{av:'AV58DynamicFiltersOperatorParametroChave',fld:'vDYNAMICFILTERSOPERATORPARAMETROCHAVE',pic:'ZZZ9'},{av:'AV59ParametroChave',fld:'vPARAMETROCHAVE',pic:''},{av:'cmbavDynamicfiltersoperatorparametrovalor'},{av:'AV60DynamicFiltersOperatorParametroValor',fld:'vDYNAMICFILTERSOPERATORPARAMETROVALOR',pic:'ZZZ9'},{av:'AV61ParametroValor',fld:'vPARAMETROVALOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV69Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV67ParametroDel_Filtro',fld:'vPARAMETRODEL_FILTRO',pic:''},{av:'AV41TFParametroChave',fld:'vTFPARAMETROCHAVE',pic:''},{av:'AV42TFParametroChave_Sel',fld:'vTFPARAMETROCHAVE_SEL',pic:''},{av:'AV62TFParametroDescricao',fld:'vTFPARAMETRODESCRICAO',pic:''},{av:'AV63TFParametroDescricao_Sel',fld:'vTFPARAMETRODESCRICAO_SEL',pic:''},{av:'AV43TFParametroValor',fld:'vTFPARAMETROVALOR',pic:''},{av:'AV44TFParametroValor_Sel',fld:'vTFPARAMETROVALOR_SEL',pic:''},{av:'AV53IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV54IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV57IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E153R2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Parametrovalor',iparms:[]");
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
         Ddo_grid_Selectedcolumn = "";
         Ddo_grid_Filteredtext_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_delete_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV59ParametroChave = "";
         AV61ParametroValor = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV69Pgmname = "";
         AV41TFParametroChave = "";
         AV42TFParametroChave_Sel = "";
         AV62TFParametroDescricao = "";
         AV63TFParametroDescricao_Sel = "";
         AV43TFParametroValor = "";
         AV44TFParametroValor_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV51GridAppliedFilters = "";
         AV55AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV45DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         AV66ParametroChave_Selected = "";
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Selectedvalue_set = "";
         Ddo_grid_Gamoauthtoken = "";
         Ddo_grid_Sortedstatus = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
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
         lblDynamicfiltersprefixparametrochave_Jsonclick = "";
         lblDynamicfiltersfixedfiltercaptionparametrochave_Jsonclick = "";
         lblDynamicfiltersmiddleparametrochave_Jsonclick = "";
         lblDynamicfiltersprefixparametrovalor_Jsonclick = "";
         lblDynamicfiltersfixedfiltercaptionparametrovalor_Jsonclick = "";
         lblDynamicfiltersmiddleparametrovalor_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_agexport = new GXUserControl();
         ucDdc_subscriptions = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A342ParametroChave = "";
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         scmdbuf = "";
         lV71Core_parametroswwds_2_filterfulltext = "";
         lV72Core_parametroswwds_3_parametrochave = "";
         lV74Core_parametroswwds_5_parametrovalor = "";
         lV76Core_parametroswwds_7_tfparametrochave = "";
         lV78Core_parametroswwds_9_tfparametrodescricao = "";
         lV80Core_parametroswwds_11_tfparametrovalor = "";
         AV71Core_parametroswwds_2_filterfulltext = "";
         AV72Core_parametroswwds_3_parametrochave = "";
         AV74Core_parametroswwds_5_parametrovalor = "";
         AV77Core_parametroswwds_8_tfparametrochave_sel = "";
         AV76Core_parametroswwds_7_tfparametrochave = "";
         AV79Core_parametroswwds_10_tfparametrodescricao_sel = "";
         AV78Core_parametroswwds_9_tfparametrodescricao = "";
         AV81Core_parametroswwds_12_tfparametrovalor_sel = "";
         AV80Core_parametroswwds_11_tfparametrovalor = "";
         H003R2_A518ParametroDel = new bool[] {false} ;
         H003R2_A343ParametroValor = new string[] {""} ;
         H003R2_n343ParametroValor = new bool[] {false} ;
         H003R2_A344ParametroDescricao = new string[] {""} ;
         H003R2_n344ParametroDescricao = new bool[] {false} ;
         H003R2_A342ParametroChave = new string[] {""} ;
         H003R3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV56AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV46GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV47GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GridRow = new GXWebRow();
         GXEncryptionTmp = "";
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV68sdtParametros = new GeneXus.Programs.core.SdtsdtParametros(context);
         AV65Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV64Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char2 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         ucDvelop_confirmpanel_delete = new GXUserControl();
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametrosww__default(),
            new Object[][] {
                new Object[] {
               H003R2_A518ParametroDel, H003R2_A343ParametroValor, H003R2_n343ParametroValor, H003R2_A344ParametroDescricao, H003R2_n344ParametroDescricao, H003R2_A342ParametroChave
               }
               , new Object[] {
               H003R3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV69Pgmname = "core.ParametrosWW";
         /* GeneXus formulas. */
         AV69Pgmname = "core.ParametrosWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV58DynamicFiltersOperatorParametroChave ;
      private short AV60DynamicFiltersOperatorParametroValor ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV52GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ;
      private short AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_85 ;
      private int nGXsfl_85_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtParametroChave_Visible ;
      private int edtParametroDescricao_Visible ;
      private int edtParametroValor_Visible ;
      private int AV48PageToGo ;
      private int AV82GXV1 ;
      private int AV83GXV2 ;
      private int edtavParametrovalor_Enabled ;
      private int edtavParametrochave_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV49GridCurrentPage ;
      private long AV50GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_delete_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_85_idx="0001" ;
      private string AV69Pgmname ;
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
      private string Ddo_grid_Includedatalist ;
      private string Ddo_grid_Datalisttype ;
      private string Ddo_grid_Datalistproc ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Dvelop_confirmpanel_delete_Title ;
      private string Dvelop_confirmpanel_delete_Confirmationtext ;
      private string Dvelop_confirmpanel_delete_Yesbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Nobuttoncaption ;
      private string Dvelop_confirmpanel_delete_Cancelbuttoncaption ;
      private string Dvelop_confirmpanel_delete_Yesbuttonposition ;
      private string Dvelop_confirmpanel_delete_Confirmtype ;
      private string Grid_empowerer_Gridinternalname ;
      private string Grid_empowerer_Fixedcolumns ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string chkavParametrodel_filtro_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
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
      private string divTabledynamicfiltersrowparametrochave_Internalname ;
      private string lblDynamicfiltersprefixparametrochave_Internalname ;
      private string lblDynamicfiltersprefixparametrochave_Jsonclick ;
      private string lblDynamicfiltersfixedfiltercaptionparametrochave_Internalname ;
      private string lblDynamicfiltersfixedfiltercaptionparametrochave_Jsonclick ;
      private string lblDynamicfiltersmiddleparametrochave_Internalname ;
      private string lblDynamicfiltersmiddleparametrochave_Jsonclick ;
      private string divTabledynamicfiltersrowparametrovalor_Internalname ;
      private string lblDynamicfiltersprefixparametrovalor_Internalname ;
      private string lblDynamicfiltersprefixparametrovalor_Jsonclick ;
      private string lblDynamicfiltersfixedfiltercaptionparametrovalor_Internalname ;
      private string lblDynamicfiltersfixedfiltercaptionparametrovalor_Jsonclick ;
      private string lblDynamicfiltersmiddleparametrovalor_Internalname ;
      private string lblDynamicfiltersmiddleparametrovalor_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_agexport_Internalname ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtParametroChave_Internalname ;
      private string edtParametroDescricao_Internalname ;
      private string edtParametroValor_Internalname ;
      private string cmbavDynamicfiltersoperatorparametrochave_Internalname ;
      private string cmbavDynamicfiltersoperatorparametrovalor_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavParametrochave_Internalname ;
      private string edtavParametrovalor_Internalname ;
      private string cmbavGridactions_Class ;
      private string GXEncryptionTmp ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char2 ;
      private string tblTabledvelop_confirmpanel_delete_Internalname ;
      private string Dvelop_confirmpanel_delete_Internalname ;
      private string tblTablemergeddynamicfiltersparametrovalor_Internalname ;
      private string cmbavDynamicfiltersoperatorparametrovalor_Jsonclick ;
      private string tblTablemergeddynamicfiltersparametrochave_Internalname ;
      private string cmbavDynamicfiltersoperatorparametrochave_Jsonclick ;
      private string edtavParametrochave_Jsonclick ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_85_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtParametroChave_Jsonclick ;
      private string edtParametroDescricao_Jsonclick ;
      private string edtParametroValor_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV67ParametroDel_Filtro ;
      private bool AV15OrderedDsc ;
      private bool AV53IsAuthorized_Update ;
      private bool AV54IsAuthorized_Delete ;
      private bool AV57IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_85_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n344ParametroDescricao ;
      private bool n343ParametroValor ;
      private bool gxdyncontrolsrefreshing ;
      private bool A518ParametroDel ;
      private bool AV70Core_parametroswwds_1_parametrodel_filtro ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean3 ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV59ParametroChave ;
      private string AV61ParametroValor ;
      private string AV41TFParametroChave ;
      private string AV42TFParametroChave_Sel ;
      private string AV62TFParametroDescricao ;
      private string AV63TFParametroDescricao_Sel ;
      private string AV43TFParametroValor ;
      private string AV44TFParametroValor_Sel ;
      private string AV51GridAppliedFilters ;
      private string AV66ParametroChave_Selected ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private string lV71Core_parametroswwds_2_filterfulltext ;
      private string lV72Core_parametroswwds_3_parametrochave ;
      private string lV74Core_parametroswwds_5_parametrovalor ;
      private string lV76Core_parametroswwds_7_tfparametrochave ;
      private string lV78Core_parametroswwds_9_tfparametrodescricao ;
      private string lV80Core_parametroswwds_11_tfparametrovalor ;
      private string AV71Core_parametroswwds_2_filterfulltext ;
      private string AV72Core_parametroswwds_3_parametrochave ;
      private string AV74Core_parametroswwds_5_parametrovalor ;
      private string AV77Core_parametroswwds_8_tfparametrochave_sel ;
      private string AV76Core_parametroswwds_7_tfparametrochave ;
      private string AV79Core_parametroswwds_10_tfparametrodescricao_sel ;
      private string AV78Core_parametroswwds_9_tfparametrodescricao ;
      private string AV81Core_parametroswwds_12_tfparametrovalor_sel ;
      private string AV80Core_parametroswwds_11_tfparametrovalor ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private IGxSession AV37Session ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_agexport ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDvelop_confirmpanel_delete ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavParametrodel_filtro ;
      private GXCombobox cmbavDynamicfiltersoperatorparametrochave ;
      private GXCombobox cmbavDynamicfiltersoperatorparametrovalor ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private bool[] H003R2_A518ParametroDel ;
      private string[] H003R2_A343ParametroValor ;
      private bool[] H003R2_n343ParametroValor ;
      private string[] H003R2_A344ParametroDescricao ;
      private bool[] H003R2_n344ParametroDescricao ;
      private string[] H003R2_A342ParametroChave ;
      private long[] H003R3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV55AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV47GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV65Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV56AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV45DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV46GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Utils.SdtMessages_Message AV64Message ;
      private GeneXus.Programs.core.SdtsdtParametros AV68sdtParametros ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class parametrosww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003R2( IGxContext context ,
                                             string AV71Core_parametroswwds_2_filterfulltext ,
                                             short AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV72Core_parametroswwds_3_parametrochave ,
                                             short AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV74Core_parametroswwds_5_parametrovalor ,
                                             string AV77Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV76Core_parametroswwds_7_tfparametrochave ,
                                             string AV79Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV78Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV81Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV80Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[16];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " ParametroDel, ParametroValor, ParametroDescricao, ParametroChave";
         sFromString = " FROM tb_parametro";
         sOrderString = "";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV71Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV71Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV71Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
         }
         if ( ( AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV72Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int7[3] = 1;
         }
         if ( ( AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV72Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ( AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV74Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( ( AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV74Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV76Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV77Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV77Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV78Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV79Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV79Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV80Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV81Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV81Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int7[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY ParametroChave";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY ParametroChave DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY ParametroDescricao, ParametroChave";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY ParametroDescricao DESC, ParametroChave";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY ParametroValor, ParametroChave";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY ParametroValor DESC, ParametroChave";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY ParametroChave";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H003R3( IGxContext context ,
                                             string AV71Core_parametroswwds_2_filterfulltext ,
                                             short AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave ,
                                             string AV72Core_parametroswwds_3_parametrochave ,
                                             short AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor ,
                                             string AV74Core_parametroswwds_5_parametrovalor ,
                                             string AV77Core_parametroswwds_8_tfparametrochave_sel ,
                                             string AV76Core_parametroswwds_7_tfparametrochave ,
                                             string AV79Core_parametroswwds_10_tfparametrodescricao_sel ,
                                             string AV78Core_parametroswwds_9_tfparametrodescricao ,
                                             string AV81Core_parametroswwds_12_tfparametrovalor_sel ,
                                             string AV80Core_parametroswwds_11_tfparametrovalor ,
                                             string A342ParametroChave ,
                                             string A344ParametroDescricao ,
                                             string A343ParametroValor ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A518ParametroDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[13];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tb_parametro";
         AddWhere(sWhereString, "(Not ParametroDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_parametroswwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( ParametroChave like '%' || :lV71Core_parametroswwds_2_filterfulltext) or ( ParametroDescricao like '%' || :lV71Core_parametroswwds_2_filterfulltext) or ( ParametroValor like '%' || :lV71Core_parametroswwds_2_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
         }
         if ( ( AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV72Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int9[3] = 1;
         }
         if ( ( AV73Core_parametroswwds_4_dynamicfiltersoperatorparametrochave == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_parametroswwds_3_parametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like '%' || :lV72Core_parametroswwds_3_parametrochave)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ( AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV74Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( ( AV75Core_parametroswwds_6_dynamicfiltersoperatorparametrovalor == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV74Core_parametroswwds_5_parametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like '%' || :lV74Core_parametroswwds_5_parametrovalor)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_parametroswwds_8_tfparametrochave_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV76Core_parametroswwds_7_tfparametrochave)) ) )
         {
            AddWhere(sWhereString, "(ParametroChave like :lV76Core_parametroswwds_7_tfparametrochave)");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV77Core_parametroswwds_8_tfparametrochave_sel)) && ! ( StringUtil.StrCmp(AV77Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroChave = ( :AV77Core_parametroswwds_8_tfparametrochave_sel))");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( StringUtil.StrCmp(AV77Core_parametroswwds_8_tfparametrochave_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from ParametroChave))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_parametroswwds_10_tfparametrodescricao_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV78Core_parametroswwds_9_tfparametrodescricao)) ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao like :lV78Core_parametroswwds_9_tfparametrodescricao)");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV79Core_parametroswwds_10_tfparametrodescricao_sel)) && ! ( StringUtil.StrCmp(AV79Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroDescricao = ( :AV79Core_parametroswwds_10_tfparametrodescricao_sel))");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( StringUtil.StrCmp(AV79Core_parametroswwds_10_tfparametrodescricao_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroDescricao IS NULL or (char_length(trim(trailing ' ' from ParametroDescricao))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_parametroswwds_12_tfparametrovalor_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV80Core_parametroswwds_11_tfparametrovalor)) ) )
         {
            AddWhere(sWhereString, "(ParametroValor like :lV80Core_parametroswwds_11_tfparametrovalor)");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV81Core_parametroswwds_12_tfparametrovalor_sel)) && ! ( StringUtil.StrCmp(AV81Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(ParametroValor = ( :AV81Core_parametroswwds_12_tfparametrovalor_sel))");
         }
         else
         {
            GXv_int9[12] = 1;
         }
         if ( StringUtil.StrCmp(AV81Core_parametroswwds_12_tfparametrovalor_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "(ParametroValor IS NULL or (char_length(trim(trailing ' ' from ParametroValor))=0))");
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
         else if ( true )
         {
            scmdbuf += "";
         }
         GXv_Object10[0] = scmdbuf;
         GXv_Object10[1] = GXv_int9;
         return GXv_Object10 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003R2(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
               case 1 :
                     return conditional_H003R3(context, (string)dynConstraints[0] , (short)dynConstraints[1] , (string)dynConstraints[2] , (short)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (string)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (short)dynConstraints[14] , (bool)dynConstraints[15] , (bool)dynConstraints[16] );
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
          Object[] prmH003R2;
          prmH003R2 = new Object[] {
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV74Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV74Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV76Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV77Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV78Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV79Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV80Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV81Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003R3;
          prmH003R3 = new Object[] {
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV71Core_parametroswwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV72Core_parametroswwds_3_parametrochave",GXType.VarChar,100,0) ,
          new ParDef("lV74Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV74Core_parametroswwds_5_parametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("lV76Core_parametroswwds_7_tfparametrochave",GXType.VarChar,100,0) ,
          new ParDef("AV77Core_parametroswwds_8_tfparametrochave_sel",GXType.VarChar,100,0) ,
          new ParDef("lV78Core_parametroswwds_9_tfparametrodescricao",GXType.VarChar,500,0) ,
          new ParDef("AV79Core_parametroswwds_10_tfparametrodescricao_sel",GXType.VarChar,500,0) ,
          new ParDef("lV80Core_parametroswwds_11_tfparametrovalor",GXType.VarChar,2000,0) ,
          new ParDef("AV81Core_parametroswwds_12_tfparametrovalor_sel",GXType.VarChar,2000,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003R2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003R2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003R3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003R3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[0])[0] = rslt.getBool(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((bool[]) buf[4])[0] = rslt.wasNull(3);
                ((string[]) buf[5])[0] = rslt.getVarchar(4);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
