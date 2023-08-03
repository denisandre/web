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
   public class tabeladeprecoww : GXDataArea
   {
      public tabeladeprecoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladeprecoww( IGxContext context )
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
         chkavTppdel_filtro = new GXCheckbox();
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
         nRC_GXsfl_115 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_115"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_115_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_115_idx = GetPar( "sGXsfl_115_idx");
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
         AV20TppCodigo1 = GetPar( "TppCodigo1");
         cmbavDynamicfiltersselector2.FromJSonString( GetNextPar( ));
         AV22DynamicFiltersSelector2 = GetPar( "DynamicFiltersSelector2");
         cmbavDynamicfiltersoperator2.FromJSonString( GetNextPar( ));
         AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator2"), "."), 18, MidpointRounding.ToEven));
         AV24TppCodigo2 = GetPar( "TppCodigo2");
         cmbavDynamicfiltersselector3.FromJSonString( GetNextPar( ));
         AV26DynamicFiltersSelector3 = GetPar( "DynamicFiltersSelector3");
         cmbavDynamicfiltersoperator3.FromJSonString( GetNextPar( ));
         AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( GetPar( "DynamicFiltersOperator3"), "."), 18, MidpointRounding.ToEven));
         AV28TppCodigo3 = GetPar( "TppCodigo3");
         AV40ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV35ColumnsSelector);
         AV99Pgmname = GetPar( "Pgmname");
         AV97TppDel_Filtro = StringUtil.StrToBool( GetPar( "TppDel_Filtro"));
         AV21DynamicFiltersEnabled2 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled2"));
         AV25DynamicFiltersEnabled3 = StringUtil.StrToBool( GetPar( "DynamicFiltersEnabled3"));
         AV41TFTppCodigo = GetPar( "TFTppCodigo");
         AV42TFTppCodigo_Sel = GetPar( "TFTppCodigo_Sel");
         AV43TFTppNome = GetPar( "TFTppNome");
         AV44TFTppNome_Sel = GetPar( "TFTppNome_Sel");
         AV45TFTppInsData = context.localUtil.ParseDateParm( GetPar( "TFTppInsData"));
         AV46TFTppInsData_To = context.localUtil.ParseDateParm( GetPar( "TFTppInsData_To"));
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV11GridState);
         AV30DynamicFiltersIgnoreFirst = StringUtil.StrToBool( GetPar( "DynamicFiltersIgnoreFirst"));
         AV29DynamicFiltersRemoving = StringUtil.StrToBool( GetPar( "DynamicFiltersRemoving"));
         AV88IsAuthorized_Update = StringUtil.StrToBool( GetPar( "IsAuthorized_Update"));
         AV89IsAuthorized_Delete = StringUtil.StrToBool( GetPar( "IsAuthorized_Delete"));
         AV93IsAuthorized_TppCodigo = StringUtil.StrToBool( GetPar( "IsAuthorized_TppCodigo"));
         AV92IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
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
            return "tabeladeprecoww_Execute" ;
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
         PA3J2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START3J2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.tabeladeprecoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV88IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV88IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV89IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV89IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TPPCODIGO", AV93IsAuthorized_TppCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TPPCODIGO", GetSecureSignedToken( "", AV93IsAuthorized_TppCodigo, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR1", AV18DynamicFiltersSelector1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR1", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV19DynamicFiltersOperator1), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTPPCODIGO1", AV20TppCodigo1);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR2", AV22DynamicFiltersSelector2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR2", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23DynamicFiltersOperator2), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTPPCODIGO2", AV24TppCodigo2);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSSELECTOR3", AV26DynamicFiltersSelector3);
         GxWebStd.gx_hidden_field( context, "GXH_vDYNAMICFILTERSOPERATOR3", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27DynamicFiltersOperator3), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GXH_vTPPCODIGO3", AV28TppCodigo3);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_115", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_115), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV38ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV84GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV85GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV86GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV90AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV90AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV80DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV80DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV35ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vDDO_TPPINSDATAAUXDATE", context.localUtil.DToC( AV47DDO_TppInsDataAuxDate, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vDDO_TPPINSDATAAUXDATETO", context.localUtil.DToC( AV48DDO_TppInsDataAuxDateTo, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV40ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED2", AV21DynamicFiltersEnabled2);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSENABLED3", AV25DynamicFiltersEnabled3);
         GxWebStd.gx_hidden_field( context, "vTFTPPCODIGO", AV41TFTppCodigo);
         GxWebStd.gx_hidden_field( context, "vTFTPPCODIGO_SEL", AV42TFTppCodigo_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTPPNOME", AV43TFTppNome);
         GxWebStd.gx_hidden_field( context, "vTFTPPNOME_SEL", AV44TFTppNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFTPPINSDATA", context.localUtil.DToC( AV45TFTppInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "vTFTPPINSDATA_TO", context.localUtil.DToC( AV46TFTppInsData_To, 0, "/"));
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
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSIGNOREFIRST", AV30DynamicFiltersIgnoreFirst);
         GxWebStd.gx_boolean_hidden_field( context, "vDYNAMICFILTERSREMOVING", AV29DynamicFiltersRemoving);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV88IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV88IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV89IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV89IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TPPCODIGO", AV93IsAuthorized_TppCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TPPCODIGO", GetSecureSignedToken( "", AV93IsAuthorized_TppCodigo, context));
         GxWebStd.gx_hidden_field( context, "vTPPID_SELECTED", AV98TppID_Selected.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
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
            WE3J2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT3J2( ) ;
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
         return formatLink("core.tabeladeprecoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.TabelaDePrecoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Tabela de Preço do Produto ou Serviço" ;
      }

      protected void WB3J0( )
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
            GxWebStd.gx_label_element( context, chkavTppdel_filtro_Internalname, "Tpp Del_Filtro", "col-sm-3 AttributeLabel", 0, true, "");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 10,'',false,'" + sGXsfl_115_idx + "',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavTppdel_filtro_Internalname, StringUtil.BoolToStr( AV97TppDel_Filtro), "", "Tpp Del_Filtro", 1, chkavTppdel_filtro.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(10, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,10);\"");
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
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(115), 3, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_29_3J2( true) ;
         }
         else
         {
            wb_table1_29_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table1_29_3J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix1_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector1_Internalname, "Dynamic Filters Selector1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector1, cmbavDynamicfiltersselector1_Internalname, StringUtil.RTrim( AV18DynamicFiltersSelector1), 1, cmbavDynamicfiltersselector1_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR1.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
            AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", (string)(cmbavDynamicfiltersselector1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle1_Internalname, "valor", "", "", lblDynamicfiltersmiddle1_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_53_3J2( true) ;
         }
         else
         {
            wb_table2_53_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table2_53_3J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix2_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector2_Internalname, "Dynamic Filters Selector2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector2, cmbavDynamicfiltersselector2_Internalname, StringUtil.RTrim( AV22DynamicFiltersSelector2), 1, cmbavDynamicfiltersselector2_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR2.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", (string)(cmbavDynamicfiltersselector2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle2_Internalname, "valor", "", "", lblDynamicfiltersmiddle2_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_75_3J2( true) ;
         }
         else
         {
            wb_table3_75_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table3_75_3J2e( bool wbgen )
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
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersprefix3_Internalname, "Filtrar por", "", "", lblDynamicfiltersprefix3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescriptionPrefix", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDynamicfiltersselector3_Internalname, "Dynamic Filters Selector3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersselector3, cmbavDynamicfiltersselector3_Internalname, StringUtil.RTrim( AV26DynamicFiltersSelector3), 1, cmbavDynamicfiltersselector3_Jsonclick, 5, "'"+""+"'"+",false,"+"'"+"EVDYNAMICFILTERSSELECTOR3.CLICK."+"'", "svchar", "", 1, cmbavDynamicfiltersselector3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", (string)(cmbavDynamicfiltersselector3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblDynamicfiltersmiddle3_Internalname, "valor", "", "", lblDynamicfiltersmiddle3_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "DataFilterDescription", 0, "", 1, 1, 0, 0, "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "flex-grow:1;", "div");
            wb_table4_97_3J2( true) ;
         }
         else
         {
            wb_table4_97_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table4_97_3J2e( bool wbgen )
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
            StartGridControl115( ) ;
         }
         if ( wbEnd == 115 )
         {
            wbEnd = 0;
            nRC_GXsfl_115 = (int)(nGXsfl_115_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV84GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV85GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV86GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV90AGExportData);
            ucDdo_agexport.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_agexport_Internalname, "DDO_AGEXPORTContainer");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblJsdynamicfilters_Internalname, lblJsdynamicfilters_Caption, "", "", lblJsdynamicfilters_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 1, "HLP_core\\TabelaDePrecoWW.htm");
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
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV80DDO_TitleSettingsIcons);
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
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV80DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV35ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            wb_table5_133_3J2( true) ;
         }
         else
         {
            wb_table5_133_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table5_133_3J2e( bool wbgen )
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
               GxWebStd.gx_hidden_field( context, "W0140"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0140"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_115_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0140"+"");
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
            GxWebStd.gx_div_start( context, divDdo_tppinsdataauxdates_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 142,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDdo_tppinsdataauxdatetext_Internalname, AV49DDO_TppInsDataAuxDateText, StringUtil.RTrim( context.localUtil.Format( AV49DDO_TppInsDataAuxDateText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,142);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDdo_tppinsdataauxdatetext_Jsonclick, 0, "Attribute", "", "", "", "", 1, 1, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\TabelaDePrecoWW.htm");
            /* User Defined Control */
            ucTftppinsdata_rangepicker.SetProperty("Start Date", AV47DDO_TppInsDataAuxDate);
            ucTftppinsdata_rangepicker.SetProperty("End Date", AV48DDO_TppInsDataAuxDateTo);
            ucTftppinsdata_rangepicker.Render(context, "wwp.daterangepicker", Tftppinsdata_rangepicker_Internalname, "TFTPPINSDATA_RANGEPICKERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 115 )
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

      protected void START3J2( )
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
            Form.Meta.addItem("description", " Tabela de Preço do Produto ou Serviço", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP3J0( ) ;
      }

      protected void WS3J2( )
      {
         START3J2( ) ;
         EVT3J2( ) ;
      }

      protected void EVT3J2( )
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
                              E113J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E123J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E133J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E143J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E153J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E163J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E173J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DVELOP_CONFIRMPANEL_DELETE.CLOSE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E183J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters1' */
                              E193J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters2' */
                              E203J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'REMOVEDYNAMICFILTERS3'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'RemoveDynamicFilters3' */
                              E213J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E223J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS1'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters1' */
                              E233J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR1.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E243J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'ADDDYNAMICFILTERS2'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'AddDynamicFilters2' */
                              E253J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR2.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E263J2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VDYNAMICFILTERSSELECTOR3.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E273J2 ();
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
                              nGXsfl_115_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
                              SubsflControlProps_1152( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV87GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
                              A235TppID = StringUtil.StrToGuid( cgiGet( edtTppID_Internalname));
                              A236TppCodigo = cgiGet( edtTppCodigo_Internalname);
                              A237TppNome = StringUtil.Upper( cgiGet( edtTppNome_Internalname));
                              A238TppInsData = DateTimeUtil.ResetTime(context.localUtil.CToT( cgiGet( edtTppInsData_Internalname), 0));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E283J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E293J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E303J2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E313J2 ();
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
                                       /* Set Refresh If Tppcodigo1 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO1"), AV20TppCodigo1) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator2 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tppcodigo2 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO2"), AV24TppCodigo2) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersselector3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Dynamicfiltersoperator3 Changed */
                                       if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
                                       {
                                          Rfr0gs = true;
                                       }
                                       /* Set Refresh If Tppcodigo3 Changed */
                                       if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO3"), AV28TppCodigo3) != 0 )
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
                        if ( nCmpId == 140 )
                        {
                           OldWwpaux_wc = cgiGet( "W0140");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0140", "", sEvt);
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

      protected void WE3J2( )
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

      protected void PA3J2( )
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
               GX_FocusControl = chkavTppdel_filtro_Internalname;
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
         SubsflControlProps_1152( ) ;
         while ( nGXsfl_115_idx <= nRC_GXsfl_115 )
         {
            sendrow_1152( ) ;
            nGXsfl_115_idx = ((subGrid_Islastpage==1)&&(nGXsfl_115_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       string AV18DynamicFiltersSelector1 ,
                                       short AV19DynamicFiltersOperator1 ,
                                       string AV20TppCodigo1 ,
                                       string AV22DynamicFiltersSelector2 ,
                                       short AV23DynamicFiltersOperator2 ,
                                       string AV24TppCodigo2 ,
                                       string AV26DynamicFiltersSelector3 ,
                                       short AV27DynamicFiltersOperator3 ,
                                       string AV28TppCodigo3 ,
                                       short AV40ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ,
                                       string AV99Pgmname ,
                                       bool AV97TppDel_Filtro ,
                                       bool AV21DynamicFiltersEnabled2 ,
                                       bool AV25DynamicFiltersEnabled3 ,
                                       string AV41TFTppCodigo ,
                                       string AV42TFTppCodigo_Sel ,
                                       string AV43TFTppNome ,
                                       string AV44TFTppNome_Sel ,
                                       DateTime AV45TFTppInsData ,
                                       DateTime AV46TFTppInsData_To ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ,
                                       bool AV30DynamicFiltersIgnoreFirst ,
                                       bool AV29DynamicFiltersRemoving ,
                                       bool AV88IsAuthorized_Update ,
                                       bool AV89IsAuthorized_Delete ,
                                       bool AV93IsAuthorized_TppCodigo ,
                                       bool AV92IsAuthorized_Insert )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF3J2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_TPPID", GetSecureSignedToken( "", A235TppID, context));
         GxWebStd.gx_hidden_field( context, "TPPID", A235TppID.ToString());
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
         AV97TppDel_Filtro = StringUtil.StrToBool( StringUtil.BoolToStr( AV97TppDel_Filtro));
         AssignAttri("", false, "AV97TppDel_Filtro", AV97TppDel_Filtro);
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
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
            AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
            AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         }
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF3J2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV99Pgmname = "core.TabelaDePrecoWW";
      }

      protected void RF3J2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 115;
         /* Execute user event: Refresh */
         E293J2 ();
         nGXsfl_115_idx = 1;
         sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
         SubsflControlProps_1152( ) ;
         bGXsfl_115_Refreshing = true;
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
            SubsflControlProps_1152( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV101Core_tabeladeprecowwds_2_filterfulltext ,
                                                 AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                                 AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                                 AV104Core_tabeladeprecowwds_5_tppcodigo1 ,
                                                 AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                                 AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                                 AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                                 AV108Core_tabeladeprecowwds_9_tppcodigo2 ,
                                                 AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                                 AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                                 AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                                 AV112Core_tabeladeprecowwds_13_tppcodigo3 ,
                                                 AV114Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                                 AV113Core_tabeladeprecowwds_14_tftppcodigo ,
                                                 AV116Core_tabeladeprecowwds_17_tftppnome_sel ,
                                                 AV115Core_tabeladeprecowwds_16_tftppnome ,
                                                 AV117Core_tabeladeprecowwds_18_tftppinsdata ,
                                                 AV118Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                                 A236TppCodigo ,
                                                 A237TppNome ,
                                                 A238TppInsData ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc ,
                                                 A602TppDel } ,
                                                 new int[]{
                                                 TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                                 TypeConstants.BOOLEAN
                                                 }
            });
            lV101Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext), "%", "");
            lV101Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext), "%", "");
            lV104Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
            lV104Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
            lV108Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
            lV108Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
            lV112Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
            lV112Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
            lV113Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV113Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
            lV115Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV115Core_tabeladeprecowwds_16_tftppnome), "%", "");
            /* Using cursor H003J2 */
            pr_default.execute(0, new Object[] {lV101Core_tabeladeprecowwds_2_filterfulltext, lV101Core_tabeladeprecowwds_2_filterfulltext, lV104Core_tabeladeprecowwds_5_tppcodigo1, lV104Core_tabeladeprecowwds_5_tppcodigo1, lV108Core_tabeladeprecowwds_9_tppcodigo2, lV108Core_tabeladeprecowwds_9_tppcodigo2, lV112Core_tabeladeprecowwds_13_tppcodigo3, lV112Core_tabeladeprecowwds_13_tppcodigo3, lV113Core_tabeladeprecowwds_14_tftppcodigo, AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, lV115Core_tabeladeprecowwds_16_tftppnome, AV116Core_tabeladeprecowwds_17_tftppnome_sel, AV117Core_tabeladeprecowwds_18_tftppinsdata, AV118Core_tabeladeprecowwds_19_tftppinsdata_to, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_115_idx = 1;
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A602TppDel = H003J2_A602TppDel[0];
               A238TppInsData = H003J2_A238TppInsData[0];
               A237TppNome = H003J2_A237TppNome[0];
               A236TppCodigo = H003J2_A236TppCodigo[0];
               A235TppID = H003J2_A235TppID[0];
               E303J2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 115;
            WB3J0( ) ;
         }
         bGXsfl_115_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes3J2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV99Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV99Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_UPDATE", AV88IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV88IsAuthorized_Update, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_DELETE", AV89IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV89IsAuthorized_Delete, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_TPPCODIGO", AV93IsAuthorized_TppCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TPPCODIGO", GetSecureSignedToken( "", AV93IsAuthorized_TppCodigo, context));
         GxWebStd.gx_hidden_field( context, "gxhash_TPPID"+"_"+sGXsfl_115_idx, GetSecureSignedToken( sGXsfl_115_idx, A235TppID, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
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
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV101Core_tabeladeprecowwds_2_filterfulltext ,
                                              AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                              AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                              AV104Core_tabeladeprecowwds_5_tppcodigo1 ,
                                              AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                              AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                              AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                              AV108Core_tabeladeprecowwds_9_tppcodigo2 ,
                                              AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                              AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                              AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                              AV112Core_tabeladeprecowwds_13_tppcodigo3 ,
                                              AV114Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                              AV113Core_tabeladeprecowwds_14_tftppcodigo ,
                                              AV116Core_tabeladeprecowwds_17_tftppnome_sel ,
                                              AV115Core_tabeladeprecowwds_16_tftppnome ,
                                              AV117Core_tabeladeprecowwds_18_tftppinsdata ,
                                              AV118Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                              A236TppCodigo ,
                                              A237TppNome ,
                                              A238TppInsData ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc ,
                                              A602TppDel } ,
                                              new int[]{
                                              TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.DATE, TypeConstants.SHORT, TypeConstants.BOOLEAN,
                                              TypeConstants.BOOLEAN
                                              }
         });
         lV101Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV101Core_tabeladeprecowwds_2_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext), "%", "");
         lV104Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV104Core_tabeladeprecowwds_5_tppcodigo1 = StringUtil.Concat( StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1), "%", "");
         lV108Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV108Core_tabeladeprecowwds_9_tppcodigo2 = StringUtil.Concat( StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2), "%", "");
         lV112Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV112Core_tabeladeprecowwds_13_tppcodigo3 = StringUtil.Concat( StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3), "%", "");
         lV113Core_tabeladeprecowwds_14_tftppcodigo = StringUtil.Concat( StringUtil.RTrim( AV113Core_tabeladeprecowwds_14_tftppcodigo), "%", "");
         lV115Core_tabeladeprecowwds_16_tftppnome = StringUtil.Concat( StringUtil.RTrim( AV115Core_tabeladeprecowwds_16_tftppnome), "%", "");
         /* Using cursor H003J3 */
         pr_default.execute(1, new Object[] {lV101Core_tabeladeprecowwds_2_filterfulltext, lV101Core_tabeladeprecowwds_2_filterfulltext, lV104Core_tabeladeprecowwds_5_tppcodigo1, lV104Core_tabeladeprecowwds_5_tppcodigo1, lV108Core_tabeladeprecowwds_9_tppcodigo2, lV108Core_tabeladeprecowwds_9_tppcodigo2, lV112Core_tabeladeprecowwds_13_tppcodigo3, lV112Core_tabeladeprecowwds_13_tppcodigo3, lV113Core_tabeladeprecowwds_14_tftppcodigo, AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, lV115Core_tabeladeprecowwds_16_tftppnome, AV116Core_tabeladeprecowwds_17_tftppnome_sel, AV117Core_tabeladeprecowwds_18_tftppinsdata, AV118Core_tabeladeprecowwds_19_tftppinsdata_to});
         GRID_nRecordCount = H003J3_AGRID_nRecordCount[0];
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
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV99Pgmname = "core.TabelaDePrecoWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP3J0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E283J2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV38ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV90AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV80DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV35ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_115 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_115"), ",", "."), 18, MidpointRounding.ToEven));
            AV84GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV85GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV86GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            AV47DDO_TppInsDataAuxDate = context.localUtil.CToD( cgiGet( "vDDO_TPPINSDATAAUXDATE"), 0);
            AV48DDO_TppInsDataAuxDateTo = context.localUtil.CToD( cgiGet( "vDDO_TPPINSDATAAUXDATETO"), 0);
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
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Dvelop_confirmpanel_delete_Result = cgiGet( "DVELOP_CONFIRMPANEL_DELETE_Result");
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV97TppDel_Filtro = StringUtil.StrToBool( cgiGet( chkavTppdel_filtro_Internalname));
            AssignAttri("", false, "AV97TppDel_Filtro", AV97TppDel_Filtro);
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
            AV20TppCodigo1 = cgiGet( edtavTppcodigo1_Internalname);
            AssignAttri("", false, "AV20TppCodigo1", AV20TppCodigo1);
            cmbavDynamicfiltersselector2.Name = cmbavDynamicfiltersselector2_Internalname;
            cmbavDynamicfiltersselector2.CurrentValue = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AV22DynamicFiltersSelector2 = cgiGet( cmbavDynamicfiltersselector2_Internalname);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
            cmbavDynamicfiltersoperator2.Name = cmbavDynamicfiltersoperator2_Internalname;
            cmbavDynamicfiltersoperator2.CurrentValue = cgiGet( cmbavDynamicfiltersoperator2_Internalname);
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator2_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AV24TppCodigo2 = cgiGet( edtavTppcodigo2_Internalname);
            AssignAttri("", false, "AV24TppCodigo2", AV24TppCodigo2);
            cmbavDynamicfiltersselector3.Name = cmbavDynamicfiltersselector3_Internalname;
            cmbavDynamicfiltersselector3.CurrentValue = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AV26DynamicFiltersSelector3 = cgiGet( cmbavDynamicfiltersselector3_Internalname);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
            cmbavDynamicfiltersoperator3.Name = cmbavDynamicfiltersoperator3_Internalname;
            cmbavDynamicfiltersoperator3.CurrentValue = cgiGet( cmbavDynamicfiltersoperator3_Internalname);
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavDynamicfiltersoperator3_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AV28TppCodigo3 = cgiGet( edtavTppcodigo3_Internalname);
            AssignAttri("", false, "AV28TppCodigo3", AV28TppCodigo3);
            AV49DDO_TppInsDataAuxDateText = cgiGet( edtavDdo_tppinsdataauxdatetext_Internalname);
            AssignAttri("", false, "AV49DDO_TppInsDataAuxDateText", AV49DDO_TppInsDataAuxDateText);
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
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO1"), AV20TppCodigo1) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR2"), AV22DynamicFiltersSelector2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR2"), ",", ".") != Convert.ToDecimal( AV23DynamicFiltersOperator2 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO2"), AV24TppCodigo2) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vDYNAMICFILTERSSELECTOR3"), AV26DynamicFiltersSelector3) != 0 )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( ( context.localUtil.CToN( cgiGet( "GXH_vDYNAMICFILTERSOPERATOR3"), ",", ".") != Convert.ToDecimal( AV27DynamicFiltersOperator3 )) )
            {
               GRID_nFirstRecordOnPage = 0;
            }
            if ( StringUtil.StrCmp(cgiGet( "GXH_vTPPCODIGO3"), AV28TppCodigo3) != 0 )
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
         E283J2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E283J2( )
      {
         /* Start Routine */
         returnInSub = false;
         this.executeUsercontrolMethod("", false, "TFTPPINSDATA_RANGEPICKERContainer", "Attach", "", new Object[] {(string)edtavDdo_tppinsdataauxdatetext_Internalname});
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
         lblJsdynamicfilters_Caption = "";
         AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         AV18DynamicFiltersSelector1 = "TPPCODIGO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV22DynamicFiltersSelector2 = "TPPCODIGO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV26DynamicFiltersSelector3 = "TPPCODIGO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
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
         AV90AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV91AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV91AGExportDataItem.gxTpr_Title = "Excel";
         AV91AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV91AGExportDataItem.gxTpr_Eventkey = "Export";
         AV91AGExportDataItem.gxTpr_Isdivider = false;
         AV90AGExportData.Add(AV91AGExportDataItem, 0);
         AV91AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV91AGExportDataItem.gxTpr_Title = "PDF";
         AV91AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "776fb79c-a0a1-4302-b5e5-d773dbe1a297", "", context.GetTheme( ))));
         AV91AGExportDataItem.gxTpr_Eventkey = "ExportReport";
         AV91AGExportDataItem.gxTpr_Isdivider = false;
         AV90AGExportData.Add(AV91AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV93IsAuthorized_TppCodigo;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladeprecoview_Execute", out  GXt_boolean1) ;
         AV93IsAuthorized_TppCodigo = GXt_boolean1;
         AssignAttri("", false, "AV93IsAuthorized_TppCodigo", AV93IsAuthorized_TppCodigo);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_TPPCODIGO", GetSecureSignedToken( "", AV93IsAuthorized_TppCodigo, context));
         AV81GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV82GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV81GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Tabela de Preço do Produto ou Serviço";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV80DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV80DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E293J2( )
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
         S192 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         if ( StringUtil.StrCmp(AV37Session.Get("core.TabelaDePrecoWWColumnsSelector"), "") != 0 )
         {
            AV33ColumnsSelectorXML = AV37Session.Get("core.TabelaDePrecoWWColumnsSelector");
            AV35ColumnsSelector.FromXml(AV33ColumnsSelectorXML, null, "", "");
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
         edtTppCodigo_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTppCodigo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppCodigo_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtTppNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTppNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppNome_Visible), 5, 0), !bGXsfl_115_Refreshing);
         edtTppInsData_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV35ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtTppInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsData_Visible), 5, 0), !bGXsfl_115_Refreshing);
         AV84GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV84GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV84GridCurrentPage), 10, 0));
         AV85GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV85GridPageCount", StringUtil.LTrimStr( (decimal)(AV85GridPageCount), 10, 0));
         GXt_char3 = AV86GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV99Pgmname, out  GXt_char3) ;
         AV86GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV86GridAppliedFilters", AV86GridAppliedFilters);
         AV100Core_tabeladeprecowwds_1_tppdel_filtro = AV97TppDel_Filtro;
         AV101Core_tabeladeprecowwds_2_filterfulltext = AV17FilterFullText;
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = AV18DynamicFiltersSelector1;
         AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 = AV19DynamicFiltersOperator1;
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = AV20TppCodigo1;
         AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 = AV21DynamicFiltersEnabled2;
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = AV22DynamicFiltersSelector2;
         AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 = AV23DynamicFiltersOperator2;
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = AV24TppCodigo2;
         AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 = AV25DynamicFiltersEnabled3;
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = AV26DynamicFiltersSelector3;
         AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 = AV27DynamicFiltersOperator3;
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = AV28TppCodigo3;
         AV113Core_tabeladeprecowwds_14_tftppcodigo = AV41TFTppCodigo;
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = AV42TFTppCodigo_Sel;
         AV115Core_tabeladeprecowwds_16_tftppnome = AV43TFTppNome;
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = AV44TFTppNome_Sel;
         AV117Core_tabeladeprecowwds_18_tftppinsdata = AV45TFTppInsData;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = AV46TFTppInsData_To;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E123J2( )
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
            AV83PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV83PageToGo) ;
         }
      }

      protected void E133J2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E163J2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TppCodigo") == 0 )
            {
               AV41TFTppCodigo = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV41TFTppCodigo", AV41TFTppCodigo);
               AV42TFTppCodigo_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV42TFTppCodigo_Sel", AV42TFTppCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TppNome") == 0 )
            {
               AV43TFTppNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV43TFTppNome", AV43TFTppNome);
               AV44TFTppNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV44TFTppNome_Sel", AV44TFTppNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "TppInsData") == 0 )
            {
               AV45TFTppInsData = context.localUtil.CToD( Ddo_grid_Filteredtext_get, 2);
               AssignAttri("", false, "AV45TFTppInsData", context.localUtil.Format(AV45TFTppInsData, "99/99/99"));
               AV46TFTppInsData_To = context.localUtil.CToD( Ddo_grid_Filteredtextto_get, 2);
               AssignAttri("", false, "AV46TFTppInsData_To", context.localUtil.Format(AV46TFTppInsData_To, "99/99/99"));
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E303J2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         cmbavGridactions.removeAllItems();
         cmbavGridactions.addItem("0", ";fa fa-bars", 0);
         if ( AV88IsAuthorized_Update )
         {
            cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Alterar", "fa fa-pen", "", "", "", "", "", "", ""), 0);
         }
         if ( AV89IsAuthorized_Delete )
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
         if ( AV93IsAuthorized_TppCodigo )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.tabeladeprecoview.aspx"+UrlEncode(A235TppID.ToString()) + "," + UrlEncode(StringUtil.RTrim(""));
            edtTppCodigo_Link = formatLink("core.tabeladeprecoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 115;
         }
         sendrow_1152( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_115_Refreshing )
         {
            DoAjaxLoad(115, GridRow);
         }
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
      }

      protected void E173J2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV33ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV35ColumnsSelector.FromJSonString(AV33ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.TabelaDePrecoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV33ColumnsSelectorXML)) ? "" : AV35ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E233J2( )
      {
         /* 'AddDynamicFilters1' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = true;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         imgAdddynamicfilters1_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters1_Visible), 5, 0), true);
         imgRemovedynamicfilters1_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters1_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E193J2( )
      {
         /* 'RemoveDynamicFilters1' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = true;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV30DynamicFiltersIgnoreFirst = false;
         AssignAttri("", false, "AV30DynamicFiltersIgnoreFirst", AV30DynamicFiltersIgnoreFirst);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E243J2( )
      {
         /* Dynamicfiltersselector1_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS1' */
         S122 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E253J2( )
      {
         /* 'AddDynamicFilters2' Routine */
         returnInSub = false;
         AV25DynamicFiltersEnabled3 = true;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         imgAdddynamicfilters2_Visible = 0;
         AssignProp("", false, imgAdddynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgAdddynamicfilters2_Visible), 5, 0), true);
         imgRemovedynamicfilters2_Visible = 1;
         AssignProp("", false, imgRemovedynamicfilters2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(imgRemovedynamicfilters2_Visible), 5, 0), true);
         /*  Sending Event outputs  */
      }

      protected void E203J2( )
      {
         /* 'RemoveDynamicFilters2' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E263J2( )
      {
         /* Dynamicfiltersselector2_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E213J2( )
      {
         /* 'RemoveDynamicFilters3' Routine */
         returnInSub = false;
         AV29DynamicFiltersRemoving = true;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
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
         AV29DynamicFiltersRemoving = false;
         AssignAttri("", false, "AV29DynamicFiltersRemoving", AV29DynamicFiltersRemoving);
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector1.CurrentValue = StringUtil.RTrim( AV18DynamicFiltersSelector1);
         AssignProp("", false, cmbavDynamicfiltersselector1_Internalname, "Values", cmbavDynamicfiltersselector1.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", cmbavDynamicfiltersoperator1.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E273J2( )
      {
         /* Dynamicfiltersselector3_Click Routine */
         returnInSub = false;
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS3' */
         S142 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E113J2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.TabelaDePrecoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV99Pgmname+"GridState"));
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
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.TabelaDePrecoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV40ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV40ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV40ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV39ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.TabelaDePrecoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV39ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV39ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV39ManageFiltersXml) ;
               AV11GridState.FromXml(AV39ManageFiltersXml, null, "", "");
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
      }

      protected void E313J2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV87GridActions == 1 )
         {
            /* Execute user subroutine: 'DO UPDATE' */
            S262 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( AV87GridActions == 2 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S272 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV87GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV35ColumnsSelector", AV35ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ManageFiltersData", AV38ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E183J2( )
      {
         /* Dvelop_confirmpanel_delete_Close Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Dvelop_confirmpanel_delete_Result, "Yes") == 0 )
         {
            /* Execute user subroutine: 'DO ACTION DELETE' */
            S282 ();
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

      protected void E223J2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( AV92IsAuthorized_Insert )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim("INS")) + "," + UrlEncode(Guid.Empty.ToString());
            CallWebObject(formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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

      protected void E143J2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S292 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         else if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "ExportReport") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORTREPORT' */
            S302 ();
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
         cmbavDynamicfiltersselector2.CurrentValue = StringUtil.RTrim( AV22DynamicFiltersSelector2);
         AssignProp("", false, cmbavDynamicfiltersselector2_Internalname, "Values", cmbavDynamicfiltersselector2.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", cmbavDynamicfiltersoperator2.ToJavascriptSource(), true);
         cmbavDynamicfiltersselector3.CurrentValue = StringUtil.RTrim( AV26DynamicFiltersSelector3);
         AssignProp("", false, cmbavDynamicfiltersselector3_Internalname, "Values", cmbavDynamicfiltersselector3.ToJavascriptSource(), true);
         cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", cmbavDynamicfiltersoperator3.ToJavascriptSource(), true);
      }

      protected void E153J2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0140",(string)"",(string)"TabelaDePreco",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0140"+"");
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
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TppCodigo",  "",  "Código",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TppNome",  "",  "Descrição",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV35ColumnsSelector,  "TppInsData",  "",  "Incluído em",  true,  "") ;
         GXt_char3 = AV34UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.TabelaDePrecoWWColumnsSelector", out  GXt_char3) ;
         AV34UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV34UserCustomValue)) ) )
         {
            AV36ColumnsSelectorAux.FromXml(AV34UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV36ColumnsSelectorAux, ref  AV35ColumnsSelector) ;
         }
      }

      protected void S182( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean1 = AV88IsAuthorized_Update;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladepreco_Update", out  GXt_boolean1) ;
         AV88IsAuthorized_Update = GXt_boolean1;
         AssignAttri("", false, "AV88IsAuthorized_Update", AV88IsAuthorized_Update);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_UPDATE", GetSecureSignedToken( "", AV88IsAuthorized_Update, context));
         GXt_boolean1 = AV89IsAuthorized_Delete;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladepreco_Delete", out  GXt_boolean1) ;
         AV89IsAuthorized_Delete = GXt_boolean1;
         AssignAttri("", false, "AV89IsAuthorized_Delete", AV89IsAuthorized_Delete);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_DELETE", GetSecureSignedToken( "", AV89IsAuthorized_Delete, context));
         GXt_boolean1 = AV92IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "tabeladepreco_Insert", out  GXt_boolean1) ;
         AV92IsAuthorized_Insert = GXt_boolean1;
         AssignAttri("", false, "AV92IsAuthorized_Insert", AV92IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV92IsAuthorized_Insert, context));
         if ( ! ( AV92IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "TabelaDePreco",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S122( )
      {
         /* 'ENABLEDYNAMICFILTERS1' Routine */
         returnInSub = false;
         edtavTppcodigo1_Visible = 0;
         AssignProp("", false, edtavTppcodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo1_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator1.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TPPCODIGO") == 0 )
         {
            edtavTppcodigo1_Visible = 1;
            AssignProp("", false, edtavTppcodigo1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo1_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator1.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator1.Visible), 5, 0), true);
         }
      }

      protected void S132( )
      {
         /* 'ENABLEDYNAMICFILTERS2' Routine */
         returnInSub = false;
         edtavTppcodigo2_Visible = 0;
         AssignProp("", false, edtavTppcodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo2_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator2.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TPPCODIGO") == 0 )
         {
            edtavTppcodigo2_Visible = 1;
            AssignProp("", false, edtavTppcodigo2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo2_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator2.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator2.Visible), 5, 0), true);
         }
      }

      protected void S142( )
      {
         /* 'ENABLEDYNAMICFILTERS3' Routine */
         returnInSub = false;
         edtavTppcodigo3_Visible = 0;
         AssignProp("", false, edtavTppcodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo3_Visible), 5, 0), true);
         cmbavDynamicfiltersoperator3.Visible = 0;
         AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TPPCODIGO") == 0 )
         {
            edtavTppcodigo3_Visible = 1;
            AssignProp("", false, edtavTppcodigo3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavTppcodigo3_Visible), 5, 0), true);
            cmbavDynamicfiltersoperator3.Visible = 1;
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavDynamicfiltersoperator3.Visible), 5, 0), true);
         }
      }

      protected void S222( )
      {
         /* 'RESETDYNFILTERS' Routine */
         returnInSub = false;
         AV21DynamicFiltersEnabled2 = false;
         AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
         AV22DynamicFiltersSelector2 = "TPPCODIGO";
         AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         AV23DynamicFiltersOperator2 = 0;
         AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         AV24TppCodigo2 = "";
         AssignAttri("", false, "AV24TppCodigo2", AV24TppCodigo2);
         /* Execute user subroutine: 'ENABLEDYNAMICFILTERS2' */
         S132 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV25DynamicFiltersEnabled3 = false;
         AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
         AV26DynamicFiltersSelector3 = "TPPCODIGO";
         AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         AV27DynamicFiltersOperator3 = 0;
         AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         AV28TppCodigo3 = "";
         AssignAttri("", false, "AV28TppCodigo3", AV28TppCodigo3);
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
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV38ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.TabelaDePrecoWWFilters",  "WWPDynFilterHideAll_AL('%1', 3, 0)",  divTabledynamicfilters_Internalname,  true, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV38ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S242( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV97TppDel_Filtro = false;
         AssignAttri("", false, "AV97TppDel_Filtro", AV97TppDel_Filtro);
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV41TFTppCodigo = "";
         AssignAttri("", false, "AV41TFTppCodigo", AV41TFTppCodigo);
         AV42TFTppCodigo_Sel = "";
         AssignAttri("", false, "AV42TFTppCodigo_Sel", AV42TFTppCodigo_Sel);
         AV43TFTppNome = "";
         AssignAttri("", false, "AV43TFTppNome", AV43TFTppNome);
         AV44TFTppNome_Sel = "";
         AssignAttri("", false, "AV44TFTppNome_Sel", AV44TFTppNome_Sel);
         AV45TFTppInsData = DateTime.MinValue;
         AssignAttri("", false, "AV45TFTppInsData", context.localUtil.Format(AV45TFTppInsData, "99/99/99"));
         AV46TFTppInsData_To = DateTime.MinValue;
         AssignAttri("", false, "AV46TFTppInsData_To", context.localUtil.Format(AV46TFTppInsData_To, "99/99/99"));
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
         AV18DynamicFiltersSelector1 = "TPPCODIGO";
         AssignAttri("", false, "AV18DynamicFiltersSelector1", AV18DynamicFiltersSelector1);
         AV19DynamicFiltersOperator1 = 0;
         AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
         AV20TppCodigo1 = "";
         AssignAttri("", false, "AV20TppCodigo1", AV20TppCodigo1);
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
         if ( AV88IsAuthorized_Update )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim("UPD")) + "," + UrlEncode(A235TppID.ToString());
            CallWebObject(formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
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
         if ( AV89IsAuthorized_Delete )
         {
            AV98TppID_Selected = A235TppID;
            AssignAttri("", false, "AV98TppID_Selected", AV98TppID_Selected.ToString());
            this.executeUsercontrolMethod("", false, "DVELOP_CONFIRMPANEL_DELETEContainer", "Confirm", "", new Object[] {});
         }
         else
         {
            GX_msglist.addItem("A ação não encontra-se disponível");
            context.DoAjaxRefresh();
         }
      }

      protected void S282( )
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
            GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim("DLT")) + "," + UrlEncode(AV98TppID_Selected.ToString());
            CallWebObject(formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         AV96sdtTabelaDePreco = new GeneXus.Programs.core.SdtsdtTabelaDePreco(context);
         AV96sdtTabelaDePreco.gxTpr_Tppid = AV98TppID_Selected;
         new GeneXus.Programs.core.prctabeladeprecoobterdadosindividual(context ).execute( ref  AV96sdtTabelaDePreco) ;
         AV96sdtTabelaDePreco.gxTpr_Tppdel = true;
         AV96sdtTabelaDePreco.gxTpr_Tppativo = false;
         new GeneXus.Programs.core.prctabeladeprecomanterdados(context ).execute(  AV96sdtTabelaDePreco,  true, out  AV95Messages) ;
         AV119GXV1 = 1;
         while ( AV119GXV1 <= AV95Messages.Count )
         {
            AV94Message = ((GeneXus.Utils.SdtMessages_Message)AV95Messages.Item(AV119GXV1));
            GX_msglist.addItem(AV94Message.gxTpr_Description);
            AV119GXV1 = (int)(AV119GXV1+1);
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV18DynamicFiltersSelector1, AV19DynamicFiltersOperator1, AV20TppCodigo1, AV22DynamicFiltersSelector2, AV23DynamicFiltersOperator2, AV24TppCodigo2, AV26DynamicFiltersSelector3, AV27DynamicFiltersOperator3, AV28TppCodigo3, AV40ManageFiltersExecutionStep, AV35ColumnsSelector, AV99Pgmname, AV97TppDel_Filtro, AV21DynamicFiltersEnabled2, AV25DynamicFiltersEnabled3, AV41TFTppCodigo, AV42TFTppCodigo_Sel, AV43TFTppNome, AV44TFTppNome_Sel, AV45TFTppInsData, AV46TFTppInsData_To, AV14OrderedBy, AV15OrderedDsc, AV11GridState, AV30DynamicFiltersIgnoreFirst, AV29DynamicFiltersRemoving, AV88IsAuthorized_Update, AV89IsAuthorized_Delete, AV93IsAuthorized_TppCodigo, AV92IsAuthorized_Insert) ;
      }

      protected void S162( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV37Session.Get(AV99Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV99Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV37Session.Get(AV99Pgmname+"GridState"), null, "", "");
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
         AV120GXV2 = 1;
         while ( AV120GXV2 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV120GXV2));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TPPDEL_FILTRO") == 0 )
            {
               AV97TppDel_Filtro = BooleanUtil.Val( AV12GridStateFilterValue.gxTpr_Value);
               AssignAttri("", false, "AV97TppDel_Filtro", AV97TppDel_Filtro);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO") == 0 )
            {
               AV41TFTppCodigo = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV41TFTppCodigo", AV41TFTppCodigo);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTPPCODIGO_SEL") == 0 )
            {
               AV42TFTppCodigo_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV42TFTppCodigo_Sel", AV42TFTppCodigo_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTPPNOME") == 0 )
            {
               AV43TFTppNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV43TFTppNome", AV43TFTppNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTPPNOME_SEL") == 0 )
            {
               AV44TFTppNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFTppNome_Sel", AV44TFTppNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFTPPINSDATA") == 0 )
            {
               AV45TFTppInsData = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Value, 2);
               AssignAttri("", false, "AV45TFTppInsData", context.localUtil.Format(AV45TFTppInsData, "99/99/99"));
               AV46TFTppInsData_To = context.localUtil.CToD( AV12GridStateFilterValue.gxTpr_Valueto, 2);
               AssignAttri("", false, "AV46TFTppInsData_To", context.localUtil.Format(AV46TFTppInsData_To, "99/99/99"));
            }
            AV120GXV2 = (int)(AV120GXV2+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTppCodigo_Sel)),  AV42TFTppCodigo_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTppNome_Sel)),  AV44TFTppNome_Sel, out  GXt_char5) ;
         Ddo_grid_Selectedvalue_set = GXt_char3+"|"+GXt_char5+"|";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTppCodigo)),  AV41TFTppCodigo, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTppNome)),  AV43TFTppNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = GXt_char5+"|"+GXt_char3+"|"+((DateTime.MinValue==AV45TFTppInsData) ? "" : context.localUtil.DToC( AV45TFTppInsData, 2, "/"));
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "||"+((DateTime.MinValue==AV46TFTppInsData_To) ? "" : context.localUtil.DToC( AV46TFTppInsData_To, 2, "/"));
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
            if ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TPPCODIGO") == 0 )
            {
               AV19DynamicFiltersOperator1 = AV13GridStateDynamicFilter.gxTpr_Operator;
               AssignAttri("", false, "AV19DynamicFiltersOperator1", StringUtil.LTrimStr( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
               AV20TppCodigo1 = AV13GridStateDynamicFilter.gxTpr_Value;
               AssignAttri("", false, "AV20TppCodigo1", AV20TppCodigo1);
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
               AV21DynamicFiltersEnabled2 = true;
               AssignAttri("", false, "AV21DynamicFiltersEnabled2", AV21DynamicFiltersEnabled2);
               AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(2));
               AV22DynamicFiltersSelector2 = AV13GridStateDynamicFilter.gxTpr_Selected;
               AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
               if ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TPPCODIGO") == 0 )
               {
                  AV23DynamicFiltersOperator2 = AV13GridStateDynamicFilter.gxTpr_Operator;
                  AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
                  AV24TppCodigo2 = AV13GridStateDynamicFilter.gxTpr_Value;
                  AssignAttri("", false, "AV24TppCodigo2", AV24TppCodigo2);
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
                  AV25DynamicFiltersEnabled3 = true;
                  AssignAttri("", false, "AV25DynamicFiltersEnabled3", AV25DynamicFiltersEnabled3);
                  AV13GridStateDynamicFilter = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter)AV11GridState.gxTpr_Dynamicfilters.Item(3));
                  AV26DynamicFiltersSelector3 = AV13GridStateDynamicFilter.gxTpr_Selected;
                  AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
                  if ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TPPCODIGO") == 0 )
                  {
                     AV27DynamicFiltersOperator3 = AV13GridStateDynamicFilter.gxTpr_Operator;
                     AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
                     AV28TppCodigo3 = AV13GridStateDynamicFilter.gxTpr_Value;
                     AssignAttri("", false, "AV28TppCodigo3", AV28TppCodigo3);
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
         if ( AV29DynamicFiltersRemoving )
         {
            lblJsdynamicfilters_Caption = "";
            AssignProp("", false, lblJsdynamicfilters_Internalname, "Caption", lblJsdynamicfilters_Caption, true);
         }
      }

      protected void S192( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV37Session.Get(AV99Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TPPDEL_FILTRO",  "Excluído",  !(false==AV97TppDel_Filtro),  0,  StringUtil.Trim( StringUtil.BoolToStr( AV97TppDel_Filtro)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTPPCODIGO",  "Código",  !String.IsNullOrEmpty(StringUtil.RTrim( AV41TFTppCodigo)),  0,  AV41TFTppCodigo,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV42TFTppCodigo_Sel)),  AV42TFTppCodigo_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFTPPNOME",  "Descrição",  !String.IsNullOrEmpty(StringUtil.RTrim( AV43TFTppNome)),  0,  AV43TFTppNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFTppNome_Sel)),  AV44TFTppNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFTPPINSDATA",  "Incluído em",  !((DateTime.MinValue==AV45TFTppInsData)&&(DateTime.MinValue==AV46TFTppInsData_To)),  0,  StringUtil.Trim( context.localUtil.DToC( AV45TFTppInsData, 2, "/")),  StringUtil.Trim( context.localUtil.DToC( AV46TFTppInsData_To, 2, "/"))) ;
         /* Execute user subroutine: 'SAVEDYNFILTERSSTATE' */
         S212 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV99Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S212( )
      {
         /* 'SAVEDYNFILTERSSTATE' Routine */
         returnInSub = false;
         AV11GridState.gxTpr_Dynamicfilters.Clear();
         if ( ! AV30DynamicFiltersIgnoreFirst )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV18DynamicFiltersSelector1;
            if ( ( StringUtil.StrCmp(AV18DynamicFiltersSelector1, "TPPCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV20TppCodigo1)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Código";
               AV13GridStateDynamicFilter.gxTpr_Value = AV20TppCodigo1;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV19DynamicFiltersOperator1;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV21DynamicFiltersEnabled2 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV22DynamicFiltersSelector2;
            if ( ( StringUtil.StrCmp(AV22DynamicFiltersSelector2, "TPPCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV24TppCodigo2)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Código";
               AV13GridStateDynamicFilter.gxTpr_Value = AV24TppCodigo2;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV23DynamicFiltersOperator2;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
            {
               AV11GridState.gxTpr_Dynamicfilters.Add(AV13GridStateDynamicFilter, 0);
            }
         }
         if ( AV25DynamicFiltersEnabled3 )
         {
            AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
            AV13GridStateDynamicFilter.gxTpr_Selected = AV26DynamicFiltersSelector3;
            if ( ( StringUtil.StrCmp(AV26DynamicFiltersSelector3, "TPPCODIGO") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV28TppCodigo3)) )
            {
               AV13GridStateDynamicFilter.gxTpr_Dsc = "Código";
               AV13GridStateDynamicFilter.gxTpr_Value = AV28TppCodigo3;
               AV13GridStateDynamicFilter.gxTpr_Operator = AV27DynamicFiltersOperator3;
            }
            if ( AV29DynamicFiltersRemoving || ! String.IsNullOrEmpty(StringUtil.RTrim( AV13GridStateDynamicFilter.gxTpr_Value)) )
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
         AV9TrnContext.gxTpr_Callerobject = AV99Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.TabelaDePreco";
         AV37Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S292( )
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
         new GeneXus.Programs.core.tabeladeprecowwexport(context ).execute( out  AV31ExcelFilename, out  AV32ErrorMessage) ;
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

      protected void S302( )
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
         Innewwindow1_Target = formatLink("core.tabeladeprecowwexportreport.aspx") ;
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Target", Innewwindow1_Target);
         Innewwindow1_Height = "600";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Height", Innewwindow1_Height);
         Innewwindow1_Width = "800";
         ucInnewwindow1.SendProperty(context, "", false, Innewwindow1_Internalname, "Width", Innewwindow1_Width);
         this.executeUsercontrolMethod("", false, "INNEWWINDOW1Container", "OpenWindow", "", new Object[] {});
      }

      protected void wb_table5_133_3J2( bool wbgen )
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
            wb_table5_133_3J2e( true) ;
         }
         else
         {
            wb_table5_133_3J2e( false) ;
         }
      }

      protected void wb_table4_97_3J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 101,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator3, cmbavDynamicfiltersoperator3_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0)), 1, cmbavDynamicfiltersoperator3_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator3.Visible, cmbavDynamicfiltersoperator3.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,101);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersoperator3.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator3_Internalname, "Values", (string)(cmbavDynamicfiltersoperator3.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tppcodigo3_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTppcodigo3_Internalname, "Tpp Codigo3", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTppcodigo3_Internalname, AV28TppCodigo3, StringUtil.RTrim( context.localUtil.Format( AV28TppCodigo3, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTppcodigo3_Jsonclick, 0, "Attribute", "", "", "", "", edtavTppcodigo3_Visible, edtavTppcodigo3_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter3_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 106,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters3_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters3_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters3_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters3_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS3\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\TabelaDePrecoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table4_97_3J2e( true) ;
         }
         else
         {
            wb_table4_97_3J2e( false) ;
         }
      }

      protected void wb_table3_75_3J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator2, cmbavDynamicfiltersoperator2_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0)), 1, cmbavDynamicfiltersoperator2_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator2.Visible, cmbavDynamicfiltersoperator2.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersoperator2.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator2_Internalname, "Values", (string)(cmbavDynamicfiltersoperator2.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tppcodigo2_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTppcodigo2_Internalname, "Tpp Codigo2", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 82,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTppcodigo2_Internalname, AV24TppCodigo2, StringUtil.RTrim( context.localUtil.Format( AV24TppCodigo2, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,82);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTppcodigo2_Jsonclick, 0, "Attribute", "", "", "", "", edtavTppcodigo2_Visible, edtavTppcodigo2_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters2_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters2_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\TabelaDePrecoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter2_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters2_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters2_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters2_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters2_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters2_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS2\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\TabelaDePrecoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_75_3J2e( true) ;
         }
         else
         {
            wb_table3_75_3J2e( false) ;
         }
      }

      protected void wb_table2_53_3J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'" + sGXsfl_115_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDynamicfiltersoperator1, cmbavDynamicfiltersoperator1_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0)), 1, cmbavDynamicfiltersoperator1_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavDynamicfiltersoperator1.Visible, cmbavDynamicfiltersoperator1.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,57);\"", "", true, 0, "HLP_core\\TabelaDePrecoWW.htm");
            cmbavDynamicfiltersoperator1.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV19DynamicFiltersOperator1), 4, 0));
            AssignProp("", false, cmbavDynamicfiltersoperator1_Internalname, "Values", (string)(cmbavDynamicfiltersoperator1.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellFilter_tppcodigo1_cell_Internalname+"\"  class=''>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavTppcodigo1_Internalname, "Tpp Codigo1", "gx-form-item AttributeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavTppcodigo1_Internalname, AV20TppCodigo1, StringUtil.RTrim( context.localUtil.Format( AV20TppCodigo1, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavTppcodigo1_Jsonclick, 0, "Attribute", "", "", "", "", edtavTppcodigo1_Visible, edtavTppcodigo1_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_addfilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 62,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgAdddynamicfilters1_gximage, "")==0) ? "GX_Image_ActionNewDynamicFilter_Class" : "GX_Image_"+imgAdddynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "27283ea5-332f-423b-b880-64b762622df3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgAdddynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgAdddynamicfilters1_Visible, 1, "", "Adicionar filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgAdddynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'ADDDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\TabelaDePrecoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td id=\""+cellDynamicfilters_removefilter1_cell_Internalname+"\"  class=''>") ;
            /* Active images/pictures */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgRemovedynamicfilters1_gximage, "")==0) ? "GX_Image_ActionRemoveDynamicFilter_Class" : "GX_Image_"+imgRemovedynamicfilters1_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "11a6ef14-1a5a-4077-91a2-f41ed9a3a662", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgRemovedynamicfilters1_Internalname, sImgUrl, "", "", "", context.GetTheme( ), imgRemovedynamicfilters1_Visible, 1, "", "Remover filtro", 0, 0, 0, "px", 0, "px", 0, 0, 5, imgRemovedynamicfilters1_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'REMOVEDYNAMICFILTERS1\\'."+"'", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" "+TempTags, "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_core\\TabelaDePrecoWW.htm");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_53_3J2e( true) ;
         }
         else
         {
            wb_table2_53_3J2e( false) ;
         }
      }

      protected void wb_table1_29_3J2( bool wbgen )
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
            wb_table6_34_3J2( true) ;
         }
         else
         {
            wb_table6_34_3J2( false) ;
         }
         return  ;
      }

      protected void wb_table6_34_3J2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_29_3J2e( true) ;
         }
         else
         {
            wb_table1_29_3J2e( false) ;
         }
      }

      protected void wb_table6_34_3J2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'" + sGXsfl_115_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\TabelaDePrecoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table6_34_3J2e( true) ;
         }
         else
         {
            wb_table6_34_3J2e( false) ;
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
         PA3J2( ) ;
         WS3J2( ) ;
         WE3J2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828222089", true, true);
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
         context.AddJavascriptSource("core/tabeladeprecoww.js", "?2023828222092", false, true);
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/ConfirmPanel/BootstrapConfirmPanelRender.js", "", false, true);
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

      protected void SubsflControlProps_1152( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_115_idx;
         edtTppID_Internalname = "TPPID_"+sGXsfl_115_idx;
         edtTppCodigo_Internalname = "TPPCODIGO_"+sGXsfl_115_idx;
         edtTppNome_Internalname = "TPPNOME_"+sGXsfl_115_idx;
         edtTppInsData_Internalname = "TPPINSDATA_"+sGXsfl_115_idx;
      }

      protected void SubsflControlProps_fel_1152( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_115_fel_idx;
         edtTppID_Internalname = "TPPID_"+sGXsfl_115_fel_idx;
         edtTppCodigo_Internalname = "TPPCODIGO_"+sGXsfl_115_fel_idx;
         edtTppNome_Internalname = "TPPNOME_"+sGXsfl_115_fel_idx;
         edtTppInsData_Internalname = "TPPINSDATA_"+sGXsfl_115_fel_idx;
      }

      protected void sendrow_1152( )
      {
         SubsflControlProps_1152( ) ;
         WB3J0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_115_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_115_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_115_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 116,'',false,'"+sGXsfl_115_idx+"',115)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_115_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV87GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_115_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)cmbavGridactions_Class,(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,116);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_115_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTppID_Internalname,A235TppID.ToString(),A235TppID.ToString(),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTppID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)115,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtTppCodigo_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTppCodigo_Internalname,(string)A236TppCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtTppCodigo_Link,(string)"",(string)"",(string)"",(string)edtTppCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTppCodigo_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)20,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\TabelaDePrecoCodigo",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtTppNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTppNome_Internalname,(string)A237TppNome,StringUtil.RTrim( context.localUtil.Format( A237TppNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTppNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTppNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtTppInsData_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTppInsData_Internalname,context.localUtil.Format(A238TppInsData, "99/99/99"),context.localUtil.Format( A238TppInsData, "99/99/99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTppInsData_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtTppInsData_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)8,(short)0,(short)0,(short)115,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Data",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes3J2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_115_idx = ((subGrid_Islastpage==1)&&(nGXsfl_115_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_115_idx+1);
            sGXsfl_115_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_115_idx), 4, 0), 4, "0");
            SubsflControlProps_1152( ) ;
         }
         /* End function sendrow_1152 */
      }

      protected void init_web_controls( )
      {
         chkavTppdel_filtro.Name = "vTPPDEL_FILTRO";
         chkavTppdel_filtro.WebTags = "";
         chkavTppdel_filtro.Caption = "";
         AssignProp("", false, chkavTppdel_filtro_Internalname, "TitleCaption", chkavTppdel_filtro.Caption, true);
         chkavTppdel_filtro.CheckedValue = "false";
         AV97TppDel_Filtro = StringUtil.StrToBool( StringUtil.BoolToStr( AV97TppDel_Filtro));
         AssignAttri("", false, "AV97TppDel_Filtro", AV97TppDel_Filtro);
         cmbavDynamicfiltersselector1.Name = "vDYNAMICFILTERSSELECTOR1";
         cmbavDynamicfiltersselector1.WebTags = "";
         cmbavDynamicfiltersselector1.addItem("TPPCODIGO", "Código", 0);
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
         cmbavDynamicfiltersselector2.addItem("TPPCODIGO", "Código", 0);
         if ( cmbavDynamicfiltersselector2.ItemCount > 0 )
         {
            AV22DynamicFiltersSelector2 = cmbavDynamicfiltersselector2.getValidValue(AV22DynamicFiltersSelector2);
            AssignAttri("", false, "AV22DynamicFiltersSelector2", AV22DynamicFiltersSelector2);
         }
         cmbavDynamicfiltersoperator2.Name = "vDYNAMICFILTERSOPERATOR2";
         cmbavDynamicfiltersoperator2.WebTags = "";
         cmbavDynamicfiltersoperator2.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator2.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator2.ItemCount > 0 )
         {
            AV23DynamicFiltersOperator2 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator2.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV23DynamicFiltersOperator2), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV23DynamicFiltersOperator2", StringUtil.LTrimStr( (decimal)(AV23DynamicFiltersOperator2), 4, 0));
         }
         cmbavDynamicfiltersselector3.Name = "vDYNAMICFILTERSSELECTOR3";
         cmbavDynamicfiltersselector3.WebTags = "";
         cmbavDynamicfiltersselector3.addItem("TPPCODIGO", "Código", 0);
         if ( cmbavDynamicfiltersselector3.ItemCount > 0 )
         {
            AV26DynamicFiltersSelector3 = cmbavDynamicfiltersselector3.getValidValue(AV26DynamicFiltersSelector3);
            AssignAttri("", false, "AV26DynamicFiltersSelector3", AV26DynamicFiltersSelector3);
         }
         cmbavDynamicfiltersoperator3.Name = "vDYNAMICFILTERSOPERATOR3";
         cmbavDynamicfiltersoperator3.WebTags = "";
         cmbavDynamicfiltersoperator3.addItem("0", "Começa com", 0);
         cmbavDynamicfiltersoperator3.addItem("1", "Contém", 0);
         if ( cmbavDynamicfiltersoperator3.ItemCount > 0 )
         {
            AV27DynamicFiltersOperator3 = (short)(Math.Round(NumberUtil.Val( cmbavDynamicfiltersoperator3.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV27DynamicFiltersOperator3), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV27DynamicFiltersOperator3", StringUtil.LTrimStr( (decimal)(AV27DynamicFiltersOperator3), 4, 0));
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_115_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV87GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV87GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV87GridActions), 4, 0));
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl115( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"115\">") ;
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
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTppCodigo_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Código") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTppNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descrição") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtTppInsData_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Incluído em") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV87GridActions), 4, 0, ".", ""))));
            GridColumn.AddObjectProperty("Class", StringUtil.RTrim( cmbavGridactions_Class));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A235TppID.ToString()));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A236TppCodigo));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtTppCodigo_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTppCodigo_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A237TppNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTppNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( context.localUtil.Format(A238TppInsData, "99/99/99")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTppInsData_Visible), 5, 0, ".", "")));
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
         chkavTppdel_filtro_Internalname = "vTPPDEL_FILTRO";
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
         edtavTppcodigo1_Internalname = "vTPPCODIGO1";
         cellFilter_tppcodigo1_cell_Internalname = "FILTER_TPPCODIGO1_CELL";
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
         edtavTppcodigo2_Internalname = "vTPPCODIGO2";
         cellFilter_tppcodigo2_cell_Internalname = "FILTER_TPPCODIGO2_CELL";
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
         edtavTppcodigo3_Internalname = "vTPPCODIGO3";
         cellFilter_tppcodigo3_cell_Internalname = "FILTER_TPPCODIGO3_CELL";
         imgRemovedynamicfilters3_Internalname = "REMOVEDYNAMICFILTERS3";
         cellDynamicfilters_removefilter3_cell_Internalname = "DYNAMICFILTERS_REMOVEFILTER3_CELL";
         tblTablemergeddynamicfilters3_Internalname = "TABLEMERGEDDYNAMICFILTERS3";
         divTabledynamicfiltersrow3_Internalname = "TABLEDYNAMICFILTERSROW3";
         divTabledynamicfilters_Internalname = "TABLEDYNAMICFILTERS";
         divAdvancedfilterscontainer_Internalname = "ADVANCEDFILTERSCONTAINER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         edtTppID_Internalname = "TPPID";
         edtTppCodigo_Internalname = "TPPCODIGO";
         edtTppNome_Internalname = "TPPNOME";
         edtTppInsData_Internalname = "TPPINSDATA";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         lblJsdynamicfilters_Internalname = "JSDYNAMICFILTERS";
         Ddo_grid_Internalname = "DDO_GRID";
         Innewwindow1_Internalname = "INNEWWINDOW1";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Dvelop_confirmpanel_delete_Internalname = "DVELOP_CONFIRMPANEL_DELETE";
         tblTabledvelop_confirmpanel_delete_Internalname = "TABLEDVELOP_CONFIRMPANEL_DELETE";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         edtavDdo_tppinsdataauxdatetext_Internalname = "vDDO_TPPINSDATAAUXDATETEXT";
         Tftppinsdata_rangepicker_Internalname = "TFTPPINSDATA_RANGEPICKER";
         divDdo_tppinsdataauxdates_Internalname = "DDO_TPPINSDATAAUXDATES";
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
         chkavTppdel_filtro.Caption = "Tpp Del_Filtro";
         edtTppInsData_Jsonclick = "";
         edtTppNome_Jsonclick = "";
         edtTppCodigo_Jsonclick = "";
         edtTppCodigo_Link = "";
         edtTppID_Jsonclick = "";
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
         edtavTppcodigo1_Jsonclick = "";
         edtavTppcodigo1_Enabled = 1;
         cmbavDynamicfiltersoperator1_Jsonclick = "";
         cmbavDynamicfiltersoperator1.Enabled = 1;
         imgRemovedynamicfilters2_Visible = 1;
         imgAdddynamicfilters2_Visible = 1;
         edtavTppcodigo2_Jsonclick = "";
         edtavTppcodigo2_Enabled = 1;
         cmbavDynamicfiltersoperator2_Jsonclick = "";
         cmbavDynamicfiltersoperator2.Enabled = 1;
         edtavTppcodigo3_Jsonclick = "";
         edtavTppcodigo3_Enabled = 1;
         cmbavDynamicfiltersoperator3_Jsonclick = "";
         cmbavDynamicfiltersoperator3.Enabled = 1;
         cmbavDynamicfiltersoperator3.Visible = 1;
         edtavTppcodigo3_Visible = 1;
         cmbavDynamicfiltersoperator2.Visible = 1;
         edtavTppcodigo2_Visible = 1;
         cmbavDynamicfiltersoperator1.Visible = 1;
         edtavTppcodigo1_Visible = 1;
         edtTppInsData_Visible = -1;
         edtTppNome_Visible = -1;
         edtTppCodigo_Visible = -1;
         subGrid_Sortable = 0;
         edtavDdo_tppinsdataauxdatetext_Jsonclick = "";
         lblJsdynamicfilters_Caption = "JSDynamicFilters";
         cmbavDynamicfiltersselector3_Jsonclick = "";
         cmbavDynamicfiltersselector3.Enabled = 1;
         cmbavDynamicfiltersselector2_Jsonclick = "";
         cmbavDynamicfiltersselector2.Enabled = 1;
         cmbavDynamicfiltersselector1_Jsonclick = "";
         cmbavDynamicfiltersselector1.Enabled = 1;
         bttBtnsubscriptions_Visible = 1;
         bttBtninsert_Visible = 1;
         chkavTppdel_filtro.Enabled = 1;
         Grid_empowerer_Fixedcolumns = "L;;;;";
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Dvelop_confirmpanel_delete_Confirmtype = "1";
         Dvelop_confirmpanel_delete_Yesbuttonposition = "left";
         Dvelop_confirmpanel_delete_Cancelbuttoncaption = "WWP_ConfirmTextCancel";
         Dvelop_confirmpanel_delete_Nobuttoncaption = "WWP_ConfirmTextNo";
         Dvelop_confirmpanel_delete_Yesbuttoncaption = "WWP_ConfirmTextYes";
         Dvelop_confirmpanel_delete_Confirmationtext = "Deseja realmente EXCLUIR a TABELA DE PREÇO DO PRODUTO?";
         Dvelop_confirmpanel_delete_Title = "Decida";
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
         Ddo_grid_Datalistproc = "core.TabelaDePrecoWWGetFilterData";
         Ddo_grid_Datalisttype = "Dynamic|Dynamic|";
         Ddo_grid_Includedatalist = "T|T|";
         Ddo_grid_Filterisrange = "||P";
         Ddo_grid_Filtertype = "Character|Character|Date";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "1|2|3";
         Ddo_grid_Columnids = "2:TppCodigo|3:TppNome|4:TppInsData";
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
         Form.Caption = " Tabela de Preço do Produto ou Serviço";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E123J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E133J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E163J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E303J2',iparms:[{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'A235TppID',fld:'TPPID',pic:'',hsh:true}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'edtTppCodigo_Link',ctrl:'TPPCODIGO',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E173J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'ADDDYNAMICFILTERS1'","{handler:'E233J2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS1'",",oparms:[{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'","{handler:'E193J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS1'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'},{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK","{handler:'E243J2',iparms:[{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR1.CLICK",",oparms:[{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'cmbavDynamicfiltersoperator1'}]}");
         setEventMetadata("'ADDDYNAMICFILTERS2'","{handler:'E253J2',iparms:[]");
         setEventMetadata("'ADDDYNAMICFILTERS2'",",oparms:[{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'","{handler:'E203J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS2'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'},{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK","{handler:'E263J2',iparms:[{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR2.CLICK",",oparms:[{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'cmbavDynamicfiltersoperator2'}]}");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'","{handler:'E213J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true}]");
         setEventMetadata("'REMOVEDYNAMICFILTERS3'",",oparms:[{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'},{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK","{handler:'E273J2',iparms:[{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("VDYNAMICFILTERSSELECTOR3.CLICK",",oparms:[{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'},{av:'cmbavDynamicfiltersoperator3'}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E113J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E313J2',iparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A235TppID',fld:'TPPID',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV87GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV98TppID_Selected',fld:'vTPPID_SELECTED',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE","{handler:'E183J2',iparms:[{av:'Dvelop_confirmpanel_delete_Result',ctrl:'DVELOP_CONFIRMPANEL_DELETE',prop:'Result'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV98TppID_Selected',fld:'vTPPID_SELECTED',pic:''}]");
         setEventMetadata("DVELOP_CONFIRMPANEL_DELETE.CLOSE",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E223J2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'A235TppID',fld:'TPPID',pic:'',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtTppCodigo_Visible',ctrl:'TPPCODIGO',prop:'Visible'},{av:'edtTppNome_Visible',ctrl:'TPPNOME',prop:'Visible'},{av:'edtTppInsData_Visible',ctrl:'TPPINSDATA',prop:'Visible'},{av:'AV84GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV85GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV86GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV38ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E143J2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'Innewwindow1_Target',ctrl:'INNEWWINDOW1',prop:'Target'},{av:'Innewwindow1_Height',ctrl:'INNEWWINDOW1',prop:'Height'},{av:'Innewwindow1_Width',ctrl:'INNEWWINDOW1',prop:'Width'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'cmbavDynamicfiltersselector1'},{av:'AV18DynamicFiltersSelector1',fld:'vDYNAMICFILTERSSELECTOR1',pic:''},{av:'cmbavDynamicfiltersoperator1'},{av:'AV19DynamicFiltersOperator1',fld:'vDYNAMICFILTERSOPERATOR1',pic:'ZZZ9'},{av:'AV20TppCodigo1',fld:'vTPPCODIGO1',pic:''},{av:'cmbavDynamicfiltersselector2'},{av:'AV22DynamicFiltersSelector2',fld:'vDYNAMICFILTERSSELECTOR2',pic:''},{av:'cmbavDynamicfiltersoperator2'},{av:'AV23DynamicFiltersOperator2',fld:'vDYNAMICFILTERSOPERATOR2',pic:'ZZZ9'},{av:'AV24TppCodigo2',fld:'vTPPCODIGO2',pic:''},{av:'cmbavDynamicfiltersselector3'},{av:'AV26DynamicFiltersSelector3',fld:'vDYNAMICFILTERSSELECTOR3',pic:''},{av:'cmbavDynamicfiltersoperator3'},{av:'AV27DynamicFiltersOperator3',fld:'vDYNAMICFILTERSOPERATOR3',pic:'ZZZ9'},{av:'AV28TppCodigo3',fld:'vTPPCODIGO3',pic:''},{av:'AV40ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV35ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV99Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV97TppDel_Filtro',fld:'vTPPDEL_FILTRO',pic:''},{av:'AV21DynamicFiltersEnabled2',fld:'vDYNAMICFILTERSENABLED2',pic:''},{av:'AV25DynamicFiltersEnabled3',fld:'vDYNAMICFILTERSENABLED3',pic:''},{av:'AV41TFTppCodigo',fld:'vTFTPPCODIGO',pic:''},{av:'AV42TFTppCodigo_Sel',fld:'vTFTPPCODIGO_SEL',pic:''},{av:'AV43TFTppNome',fld:'vTFTPPNOME',pic:'@!'},{av:'AV44TFTppNome_Sel',fld:'vTFTPPNOME_SEL',pic:'@!'},{av:'AV45TFTppInsData',fld:'vTFTPPINSDATA',pic:''},{av:'AV46TFTppInsData_To',fld:'vTFTPPINSDATA_TO',pic:''},{av:'AV30DynamicFiltersIgnoreFirst',fld:'vDYNAMICFILTERSIGNOREFIRST',pic:''},{av:'AV29DynamicFiltersRemoving',fld:'vDYNAMICFILTERSREMOVING',pic:''},{av:'AV88IsAuthorized_Update',fld:'vISAUTHORIZED_UPDATE',pic:'',hsh:true},{av:'AV89IsAuthorized_Delete',fld:'vISAUTHORIZED_DELETE',pic:'',hsh:true},{av:'AV93IsAuthorized_TppCodigo',fld:'vISAUTHORIZED_TPPCODIGO',pic:'',hsh:true},{av:'AV92IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'imgAdddynamicfilters1_Visible',ctrl:'ADDDYNAMICFILTERS1',prop:'Visible'},{av:'imgRemovedynamicfilters1_Visible',ctrl:'REMOVEDYNAMICFILTERS1',prop:'Visible'},{av:'imgAdddynamicfilters2_Visible',ctrl:'ADDDYNAMICFILTERS2',prop:'Visible'},{av:'imgRemovedynamicfilters2_Visible',ctrl:'REMOVEDYNAMICFILTERS2',prop:'Visible'},{av:'lblJsdynamicfilters_Caption',ctrl:'JSDYNAMICFILTERS',prop:'Caption'},{av:'edtavTppcodigo1_Visible',ctrl:'vTPPCODIGO1',prop:'Visible'},{av:'edtavTppcodigo2_Visible',ctrl:'vTPPCODIGO2',prop:'Visible'},{av:'edtavTppcodigo3_Visible',ctrl:'vTPPCODIGO3',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E153J2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Tppinsdata',iparms:[]");
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
         Ddo_grid_Filteredtextto_get = "";
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         Dvelop_confirmpanel_delete_Result = "";
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV18DynamicFiltersSelector1 = "";
         AV20TppCodigo1 = "";
         AV22DynamicFiltersSelector2 = "";
         AV24TppCodigo2 = "";
         AV26DynamicFiltersSelector3 = "";
         AV28TppCodigo3 = "";
         AV35ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV99Pgmname = "";
         AV41TFTppCodigo = "";
         AV42TFTppCodigo_Sel = "";
         AV43TFTppNome = "";
         AV44TFTppNome_Sel = "";
         AV45TFTppInsData = DateTime.MinValue;
         AV46TFTppInsData_To = DateTime.MinValue;
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV38ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV86GridAppliedFilters = "";
         AV90AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV80DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV47DDO_TppInsDataAuxDate = DateTime.MinValue;
         AV48DDO_TppInsDataAuxDateTo = DateTime.MinValue;
         AV98TppID_Selected = Guid.Empty;
         Ddo_agexport_Caption = "";
         Ddo_grid_Caption = "";
         Ddo_grid_Filteredtext_set = "";
         Ddo_grid_Filteredtextto_set = "";
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
         ucGrid_empowerer = new GXUserControl();
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         AV49DDO_TppInsDataAuxDateText = "";
         ucTftppinsdata_rangepicker = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         A235TppID = Guid.Empty;
         A236TppCodigo = "";
         A237TppNome = "";
         A238TppInsData = DateTime.MinValue;
         scmdbuf = "";
         lV101Core_tabeladeprecowwds_2_filterfulltext = "";
         lV104Core_tabeladeprecowwds_5_tppcodigo1 = "";
         lV108Core_tabeladeprecowwds_9_tppcodigo2 = "";
         lV112Core_tabeladeprecowwds_13_tppcodigo3 = "";
         lV113Core_tabeladeprecowwds_14_tftppcodigo = "";
         lV115Core_tabeladeprecowwds_16_tftppnome = "";
         AV101Core_tabeladeprecowwds_2_filterfulltext = "";
         AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 = "";
         AV104Core_tabeladeprecowwds_5_tppcodigo1 = "";
         AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 = "";
         AV108Core_tabeladeprecowwds_9_tppcodigo2 = "";
         AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 = "";
         AV112Core_tabeladeprecowwds_13_tppcodigo3 = "";
         AV114Core_tabeladeprecowwds_15_tftppcodigo_sel = "";
         AV113Core_tabeladeprecowwds_14_tftppcodigo = "";
         AV116Core_tabeladeprecowwds_17_tftppnome_sel = "";
         AV115Core_tabeladeprecowwds_16_tftppnome = "";
         AV117Core_tabeladeprecowwds_18_tftppinsdata = DateTime.MinValue;
         AV118Core_tabeladeprecowwds_19_tftppinsdata_to = DateTime.MinValue;
         H003J2_A602TppDel = new bool[] {false} ;
         H003J2_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         H003J2_A237TppNome = new string[] {""} ;
         H003J2_A236TppCodigo = new string[] {""} ;
         H003J2_A235TppID = new Guid[] {Guid.Empty} ;
         H003J3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         imgAdddynamicfilters1_Jsonclick = "";
         imgRemovedynamicfilters1_Jsonclick = "";
         imgAdddynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters2_Jsonclick = "";
         imgRemovedynamicfilters3_Jsonclick = "";
         AV91AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV81GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV82GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV37Session = context.GetSession();
         AV33ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV39ManageFiltersXml = "";
         AV34UserCustomValue = "";
         AV36ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV96sdtTabelaDePreco = new GeneXus.Programs.core.SdtsdtTabelaDePreco(context);
         AV95Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         AV94Message = new GeneXus.Utils.SdtMessages_Message(context);
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char5 = "";
         GXt_char3 = "";
         AV13GridStateDynamicFilter = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter(context);
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV31ExcelFilename = "";
         AV32ErrorMessage = "";
         ucDvelop_confirmpanel_delete = new GXUserControl();
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
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladeprecoww__default(),
            new Object[][] {
                new Object[] {
               H003J2_A602TppDel, H003J2_A238TppInsData, H003J2_A237TppNome, H003J2_A236TppCodigo, H003J2_A235TppID
               }
               , new Object[] {
               H003J3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV99Pgmname = "core.TabelaDePrecoWW";
         /* GeneXus formulas. */
         AV99Pgmname = "core.TabelaDePrecoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV19DynamicFiltersOperator1 ;
      private short AV23DynamicFiltersOperator2 ;
      private short AV27DynamicFiltersOperator3 ;
      private short AV40ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV87GridActions ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ;
      private short AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ;
      private short AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_115 ;
      private int nGXsfl_115_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtninsert_Visible ;
      private int bttBtnsubscriptions_Visible ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int edtTppCodigo_Visible ;
      private int edtTppNome_Visible ;
      private int edtTppInsData_Visible ;
      private int AV83PageToGo ;
      private int imgAdddynamicfilters1_Visible ;
      private int imgRemovedynamicfilters1_Visible ;
      private int imgAdddynamicfilters2_Visible ;
      private int imgRemovedynamicfilters2_Visible ;
      private int edtavTppcodigo1_Visible ;
      private int edtavTppcodigo2_Visible ;
      private int edtavTppcodigo3_Visible ;
      private int AV119GXV1 ;
      private int AV120GXV2 ;
      private int edtavTppcodigo3_Enabled ;
      private int edtavTppcodigo2_Enabled ;
      private int edtavTppcodigo1_Enabled ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV84GridCurrentPage ;
      private long AV85GridPageCount ;
      private long GRID_nCurrentRecord ;
      private long GRID_nRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_grid_Activeeventkey ;
      private string Ddo_grid_Selectedvalue_get ;
      private string Ddo_grid_Selectedcolumn ;
      private string Ddo_grid_Filteredtext_get ;
      private string Ddo_grid_Filteredtextto_get ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string Dvelop_confirmpanel_delete_Result ;
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_115_idx="0001" ;
      private string AV99Pgmname ;
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
      private string chkavTppdel_filtro_Internalname ;
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
      private string Grid_empowerer_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string divDdo_tppinsdataauxdates_Internalname ;
      private string edtavDdo_tppinsdataauxdatetext_Internalname ;
      private string edtavDdo_tppinsdataauxdatetext_Jsonclick ;
      private string Tftppinsdata_rangepicker_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string edtTppID_Internalname ;
      private string edtTppCodigo_Internalname ;
      private string edtTppNome_Internalname ;
      private string edtTppInsData_Internalname ;
      private string cmbavDynamicfiltersoperator1_Internalname ;
      private string cmbavDynamicfiltersoperator2_Internalname ;
      private string cmbavDynamicfiltersoperator3_Internalname ;
      private string scmdbuf ;
      private string edtavFilterfulltext_Internalname ;
      private string edtavTppcodigo1_Internalname ;
      private string edtavTppcodigo2_Internalname ;
      private string edtavTppcodigo3_Internalname ;
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
      private string edtTppCodigo_Link ;
      private string GXEncryptionTmp ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTabledvelop_confirmpanel_delete_Internalname ;
      private string Dvelop_confirmpanel_delete_Internalname ;
      private string tblTablemergeddynamicfilters3_Internalname ;
      private string cmbavDynamicfiltersoperator3_Jsonclick ;
      private string cellFilter_tppcodigo3_cell_Internalname ;
      private string edtavTppcodigo3_Jsonclick ;
      private string cellDynamicfilters_removefilter3_cell_Internalname ;
      private string imgRemovedynamicfilters3_gximage ;
      private string sImgUrl ;
      private string tblTablemergeddynamicfilters2_Internalname ;
      private string cmbavDynamicfiltersoperator2_Jsonclick ;
      private string cellFilter_tppcodigo2_cell_Internalname ;
      private string edtavTppcodigo2_Jsonclick ;
      private string cellDynamicfilters_addfilter2_cell_Internalname ;
      private string imgAdddynamicfilters2_gximage ;
      private string cellDynamicfilters_removefilter2_cell_Internalname ;
      private string imgRemovedynamicfilters2_gximage ;
      private string tblTablemergeddynamicfilters1_Internalname ;
      private string cmbavDynamicfiltersoperator1_Jsonclick ;
      private string cellFilter_tppcodigo1_cell_Internalname ;
      private string edtavTppcodigo1_Jsonclick ;
      private string cellDynamicfilters_addfilter1_cell_Internalname ;
      private string imgAdddynamicfilters1_gximage ;
      private string cellDynamicfilters_removefilter1_cell_Internalname ;
      private string imgRemovedynamicfilters1_gximage ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_115_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string ROClassString ;
      private string edtTppID_Jsonclick ;
      private string edtTppCodigo_Jsonclick ;
      private string edtTppNome_Jsonclick ;
      private string edtTppInsData_Jsonclick ;
      private string subGrid_Header ;
      private DateTime AV45TFTppInsData ;
      private DateTime AV46TFTppInsData_To ;
      private DateTime AV47DDO_TppInsDataAuxDate ;
      private DateTime AV48DDO_TppInsDataAuxDateTo ;
      private DateTime A238TppInsData ;
      private DateTime AV117Core_tabeladeprecowwds_18_tftppinsdata ;
      private DateTime AV118Core_tabeladeprecowwds_19_tftppinsdata_to ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV97TppDel_Filtro ;
      private bool AV21DynamicFiltersEnabled2 ;
      private bool AV25DynamicFiltersEnabled3 ;
      private bool AV15OrderedDsc ;
      private bool AV30DynamicFiltersIgnoreFirst ;
      private bool AV29DynamicFiltersRemoving ;
      private bool AV88IsAuthorized_Update ;
      private bool AV89IsAuthorized_Delete ;
      private bool AV93IsAuthorized_TppCodigo ;
      private bool AV92IsAuthorized_Insert ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_115_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ;
      private bool AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ;
      private bool A602TppDel ;
      private bool AV100Core_tabeladeprecowwds_1_tppdel_filtro ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool GXt_boolean1 ;
      private string AV33ColumnsSelectorXML ;
      private string AV39ManageFiltersXml ;
      private string AV34UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV18DynamicFiltersSelector1 ;
      private string AV20TppCodigo1 ;
      private string AV22DynamicFiltersSelector2 ;
      private string AV24TppCodigo2 ;
      private string AV26DynamicFiltersSelector3 ;
      private string AV28TppCodigo3 ;
      private string AV41TFTppCodigo ;
      private string AV42TFTppCodigo_Sel ;
      private string AV43TFTppNome ;
      private string AV44TFTppNome_Sel ;
      private string AV86GridAppliedFilters ;
      private string AV49DDO_TppInsDataAuxDateText ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string lV101Core_tabeladeprecowwds_2_filterfulltext ;
      private string lV104Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string lV108Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string lV112Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string lV113Core_tabeladeprecowwds_14_tftppcodigo ;
      private string lV115Core_tabeladeprecowwds_16_tftppnome ;
      private string AV101Core_tabeladeprecowwds_2_filterfulltext ;
      private string AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 ;
      private string AV104Core_tabeladeprecowwds_5_tppcodigo1 ;
      private string AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 ;
      private string AV108Core_tabeladeprecowwds_9_tppcodigo2 ;
      private string AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 ;
      private string AV112Core_tabeladeprecowwds_13_tppcodigo3 ;
      private string AV114Core_tabeladeprecowwds_15_tftppcodigo_sel ;
      private string AV113Core_tabeladeprecowwds_14_tftppcodigo ;
      private string AV116Core_tabeladeprecowwds_17_tftppnome_sel ;
      private string AV115Core_tabeladeprecowwds_16_tftppnome ;
      private string AV31ExcelFilename ;
      private string AV32ErrorMessage ;
      private Guid AV98TppID_Selected ;
      private Guid A235TppID ;
      private IGxSession AV37Session ;
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
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucTftppinsdata_rangepicker ;
      private GXUserControl ucDvelop_confirmpanel_delete ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkavTppdel_filtro ;
      private GXCombobox cmbavDynamicfiltersselector1 ;
      private GXCombobox cmbavDynamicfiltersoperator1 ;
      private GXCombobox cmbavDynamicfiltersselector2 ;
      private GXCombobox cmbavDynamicfiltersoperator2 ;
      private GXCombobox cmbavDynamicfiltersselector3 ;
      private GXCombobox cmbavDynamicfiltersoperator3 ;
      private GXCombobox cmbavGridactions ;
      private IDataStoreProvider pr_default ;
      private bool[] H003J2_A602TppDel ;
      private DateTime[] H003J2_A238TppInsData ;
      private string[] H003J2_A237TppNome ;
      private string[] H003J2_A236TppCodigo ;
      private Guid[] H003J2_A235TppID ;
      private long[] H003J3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV38ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV90AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV82GAMErrors ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV95Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV91AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV35ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV36ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV80DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV81GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_DynamicFilter AV13GridStateDynamicFilter ;
      private GeneXus.Utils.SdtMessages_Message AV94Message ;
      private GeneXus.Programs.core.SdtsdtTabelaDePreco AV96sdtTabelaDePreco ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class tabeladeprecoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H003J2( IGxContext context ,
                                             string AV101Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV104Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV108Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV112Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV114Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV113Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV116Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV115Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV117Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV118Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int6 = new short[17];
         Object[] GXv_Object7 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " TppDel, TppInsData, TppNome, TppCodigo, TppID";
         sFromString = " FROM tb_tabeladepreco";
         sOrderString = "";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV101Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV101Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int6[0] = 1;
            GXv_int6[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV104Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int6[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV104Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int6[3] = 1;
         }
         if ( AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV108Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int6[4] = 1;
         }
         if ( AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV108Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int6[5] = 1;
         }
         if ( AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV112Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int6[6] = 1;
         }
         if ( AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV112Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int6[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV113Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int6[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV114Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int6[9] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV115Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int6[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV116Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV116Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int6[11] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV117Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV117Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int6[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV118Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int6[13] = 1;
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY TppCodigo";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY TppCodigo DESC";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY TppNome, TppID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY TppNome DESC, TppID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY TppInsData, TppID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY TppInsData DESC, TppID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY TppID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object7[0] = scmdbuf;
         GXv_Object7[1] = GXv_int6;
         return GXv_Object7 ;
      }

      protected Object[] conditional_H003J3( IGxContext context ,
                                             string AV101Core_tabeladeprecowwds_2_filterfulltext ,
                                             string AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1 ,
                                             short AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 ,
                                             string AV104Core_tabeladeprecowwds_5_tppcodigo1 ,
                                             bool AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 ,
                                             string AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2 ,
                                             short AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 ,
                                             string AV108Core_tabeladeprecowwds_9_tppcodigo2 ,
                                             bool AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 ,
                                             string AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3 ,
                                             short AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 ,
                                             string AV112Core_tabeladeprecowwds_13_tppcodigo3 ,
                                             string AV114Core_tabeladeprecowwds_15_tftppcodigo_sel ,
                                             string AV113Core_tabeladeprecowwds_14_tftppcodigo ,
                                             string AV116Core_tabeladeprecowwds_17_tftppnome_sel ,
                                             string AV115Core_tabeladeprecowwds_16_tftppnome ,
                                             DateTime AV117Core_tabeladeprecowwds_18_tftppinsdata ,
                                             DateTime AV118Core_tabeladeprecowwds_19_tftppinsdata_to ,
                                             string A236TppCodigo ,
                                             string A237TppNome ,
                                             DateTime A238TppInsData ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc ,
                                             bool A602TppDel )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int8 = new short[14];
         Object[] GXv_Object9 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tb_tabeladepreco";
         AddWhere(sWhereString, "(Not TppDel)");
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV101Core_tabeladeprecowwds_2_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( TppCodigo like '%' || :lV101Core_tabeladeprecowwds_2_filterfulltext) or ( TppNome like '%' || :lV101Core_tabeladeprecowwds_2_filterfulltext))");
         }
         else
         {
            GXv_int8[0] = 1;
            GXv_int8[1] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV104Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int8[2] = 1;
         }
         if ( ( StringUtil.StrCmp(AV102Core_tabeladeprecowwds_3_dynamicfiltersselector1, "TPPCODIGO") == 0 ) && ( AV103Core_tabeladeprecowwds_4_dynamicfiltersoperator1 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV104Core_tabeladeprecowwds_5_tppcodigo1)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV104Core_tabeladeprecowwds_5_tppcodigo1)");
         }
         else
         {
            GXv_int8[3] = 1;
         }
         if ( AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV108Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int8[4] = 1;
         }
         if ( AV105Core_tabeladeprecowwds_6_dynamicfiltersenabled2 && ( StringUtil.StrCmp(AV106Core_tabeladeprecowwds_7_dynamicfiltersselector2, "TPPCODIGO") == 0 ) && ( AV107Core_tabeladeprecowwds_8_dynamicfiltersoperator2 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV108Core_tabeladeprecowwds_9_tppcodigo2)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV108Core_tabeladeprecowwds_9_tppcodigo2)");
         }
         else
         {
            GXv_int8[5] = 1;
         }
         if ( AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 0 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV112Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int8[6] = 1;
         }
         if ( AV109Core_tabeladeprecowwds_10_dynamicfiltersenabled3 && ( StringUtil.StrCmp(AV110Core_tabeladeprecowwds_11_dynamicfiltersselector3, "TPPCODIGO") == 0 ) && ( AV111Core_tabeladeprecowwds_12_dynamicfiltersoperator3 == 1 ) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV112Core_tabeladeprecowwds_13_tppcodigo3)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like '%' || :lV112Core_tabeladeprecowwds_13_tppcodigo3)");
         }
         else
         {
            GXv_int8[7] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV113Core_tabeladeprecowwds_14_tftppcodigo)) ) )
         {
            AddWhere(sWhereString, "(TppCodigo like :lV113Core_tabeladeprecowwds_14_tftppcodigo)");
         }
         else
         {
            GXv_int8[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV114Core_tabeladeprecowwds_15_tftppcodigo_sel)) && ! ( StringUtil.StrCmp(AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppCodigo = ( :AV114Core_tabeladeprecowwds_15_tftppcodigo_sel))");
         }
         else
         {
            GXv_int8[9] = 1;
         }
         if ( StringUtil.StrCmp(AV114Core_tabeladeprecowwds_15_tftppcodigo_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppCodigo))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_tabeladeprecowwds_17_tftppnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV115Core_tabeladeprecowwds_16_tftppnome)) ) )
         {
            AddWhere(sWhereString, "(TppNome like :lV115Core_tabeladeprecowwds_16_tftppnome)");
         }
         else
         {
            GXv_int8[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV116Core_tabeladeprecowwds_17_tftppnome_sel)) && ! ( StringUtil.StrCmp(AV116Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(TppNome = ( :AV116Core_tabeladeprecowwds_17_tftppnome_sel))");
         }
         else
         {
            GXv_int8[11] = 1;
         }
         if ( StringUtil.StrCmp(AV116Core_tabeladeprecowwds_17_tftppnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from TppNome))=0))");
         }
         if ( ! (DateTime.MinValue==AV117Core_tabeladeprecowwds_18_tftppinsdata) )
         {
            AddWhere(sWhereString, "(TppInsData >= :AV117Core_tabeladeprecowwds_18_tftppinsdata)");
         }
         else
         {
            GXv_int8[12] = 1;
         }
         if ( ! (DateTime.MinValue==AV118Core_tabeladeprecowwds_19_tftppinsdata_to) )
         {
            AddWhere(sWhereString, "(TppInsData <= :AV118Core_tabeladeprecowwds_19_tftppinsdata_to)");
         }
         else
         {
            GXv_int8[13] = 1;
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
         GXv_Object9[0] = scmdbuf;
         GXv_Object9[1] = GXv_int8;
         return GXv_Object9 ;
      }

      public override Object [] getDynamicStatement( int cursor ,
                                                     IGxContext context ,
                                                     Object [] dynConstraints )
      {
         switch ( cursor )
         {
               case 0 :
                     return conditional_H003J2(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (bool)dynConstraints[23] );
               case 1 :
                     return conditional_H003J3(context, (string)dynConstraints[0] , (string)dynConstraints[1] , (short)dynConstraints[2] , (string)dynConstraints[3] , (bool)dynConstraints[4] , (string)dynConstraints[5] , (short)dynConstraints[6] , (string)dynConstraints[7] , (bool)dynConstraints[8] , (string)dynConstraints[9] , (short)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (string)dynConstraints[13] , (string)dynConstraints[14] , (string)dynConstraints[15] , (DateTime)dynConstraints[16] , (DateTime)dynConstraints[17] , (string)dynConstraints[18] , (string)dynConstraints[19] , (DateTime)dynConstraints[20] , (short)dynConstraints[21] , (bool)dynConstraints[22] , (bool)dynConstraints[23] );
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
          Object[] prmH003J2;
          prmH003J2 = new Object[] {
          new ParDef("lV101Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV104Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV104Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV108Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV108Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV112Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV112Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV113Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV114Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV115Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV117Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV118Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH003J3;
          prmH003J3 = new Object[] {
          new ParDef("lV101Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV101Core_tabeladeprecowwds_2_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV104Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV104Core_tabeladeprecowwds_5_tppcodigo1",GXType.VarChar,20,0) ,
          new ParDef("lV108Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV108Core_tabeladeprecowwds_9_tppcodigo2",GXType.VarChar,20,0) ,
          new ParDef("lV112Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV112Core_tabeladeprecowwds_13_tppcodigo3",GXType.VarChar,20,0) ,
          new ParDef("lV113Core_tabeladeprecowwds_14_tftppcodigo",GXType.VarChar,20,0) ,
          new ParDef("AV114Core_tabeladeprecowwds_15_tftppcodigo_sel",GXType.VarChar,20,0) ,
          new ParDef("lV115Core_tabeladeprecowwds_16_tftppnome",GXType.VarChar,80,0) ,
          new ParDef("AV116Core_tabeladeprecowwds_17_tftppnome_sel",GXType.VarChar,80,0) ,
          new ParDef("AV117Core_tabeladeprecowwds_18_tftppinsdata",GXType.Date,8,0) ,
          new ParDef("AV118Core_tabeladeprecowwds_19_tftppinsdata_to",GXType.Date,8,0)
          };
          def= new CursorDef[] {
              new CursorDef("H003J2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003J2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H003J3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH003J3,1, GxCacheFrequency.OFF ,true,false )
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
                ((DateTime[]) buf[1])[0] = rslt.getGXDate(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                ((Guid[]) buf[4])[0] = rslt.getGuid(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
