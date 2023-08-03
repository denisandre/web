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
namespace GeneXus.Programs {
   public class gamwwrolepermissions : GXDataArea
   {
      public gamwwrolepermissions( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamwwrolepermissions( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( long aP0_RoleId ,
                           long aP1_pApplicationId )
      {
         this.AV30RoleId = aP0_RoleId;
         this.AV26pApplicationId = aP1_pApplicationId;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavApplicationid = new GXCombobox();
         cmbavPermissionaccesstype = new GXCombobox();
         cmbavIsinherited = new GXCombobox();
         cmbavGridactions = new GXCombobox();
         cmbavOld_accesstype = new GXCombobox();
         chkavOld_inherited = new GXCheckbox();
         cmbavAccesstype = new GXCombobox();
         chkavInherited = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "RoleId");
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
               gxfirstwebparm = GetFirstPar( "RoleId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "RoleId");
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
         nRC_GXsfl_59 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_59"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_59_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_59_idx = GetPar( "sGXsfl_59_idx");
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
         AV62ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV57ColumnsSelector);
         AV77Pgmname = GetPar( "Pgmname");
         cmbavApplicationid.FromJSonString( GetNextPar( ));
         AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "ApplicationId"), "."), 18, MidpointRounding.ToEven));
         AV15FilName = GetPar( "FilName");
         cmbavPermissionaccesstype.FromJSonString( GetNextPar( ));
         AV28PermissionAccessType = GetPar( "PermissionAccessType");
         cmbavIsinherited.FromJSonString( GetNextPar( ));
         AV20IsInherited = GetPar( "IsInherited");
         AV30RoleId = (long)(Math.Round(NumberUtil.Val( GetPar( "RoleId"), "."), 18, MidpointRounding.ToEven));
         AV73IsAuthorized_Back = StringUtil.StrToBool( GetPar( "IsAuthorized_Back"));
         AV74IsAuthorized_Insert = StringUtil.StrToBool( GetPar( "IsAuthorized_Insert"));
         AV26pApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "pApplicationId"), "."), 18, MidpointRounding.ToEven));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
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
            return "gamwwrolepermissions_Execute" ;
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
         PA1R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1R2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "gamwwrolepermissions.aspx"+UrlEncode(StringUtil.LTrimStr(AV30RoleId,12,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26pApplicationId,12,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamwwrolepermissions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV73IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV73IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV74IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV74IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "vPAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26pApplicationId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26pApplicationId), "ZZZZZZZZZZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_59", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_59), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV66ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV66ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV69GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV72GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV68DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV57ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV57ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV62ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV43GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV43GridState);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV73IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV73IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV74IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV74IsAuthorized_Insert, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISOK", AV21isOK);
         GxWebStd.gx_hidden_field( context, "vPAPPLICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26pApplicationId), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26pApplicationId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "subGrid_Recordcount", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Recordcount), 5, 0, ",", "")));
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Caption", StringUtil.RTrim( Ddo_grid_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Gridinternalname", StringUtil.RTrim( Ddo_grid_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnids", StringUtil.RTrim( Ddo_grid_Columnids));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Columnssortvalues", StringUtil.RTrim( Ddo_grid_Columnssortvalues));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Fixable", StringUtil.RTrim( Ddo_grid_Fixable));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icontype", StringUtil.RTrim( Ddo_gridcolumnsselector_Icontype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Icon", StringUtil.RTrim( Ddo_gridcolumnsselector_Icon));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Caption", StringUtil.RTrim( Ddo_gridcolumnsselector_Caption));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Tooltip", StringUtil.RTrim( Ddo_gridcolumnsselector_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Cls", StringUtil.RTrim( Ddo_gridcolumnsselector_Cls));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype", StringUtil.RTrim( Ddo_gridcolumnsselector_Dropdownoptionstype));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname", StringUtil.RTrim( Ddo_gridcolumnsselector_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace", StringUtil.RTrim( Ddo_gridcolumnsselector_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hastitlesettings", StringUtil.BoolToStr( Grid_empowerer_Hastitlesettings));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Hascolumnsselector", StringUtil.BoolToStr( Grid_empowerer_Hascolumnsselector));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Selectedpage", StringUtil.RTrim( Gridpaginationbar_Selectedpage));
         GxWebStd.gx_hidden_field( context, "GRIDPAGINATIONBAR_Rowsperpageselectedvalue", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
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
      }

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1R2( ) ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "gamwwrolepermissions.aspx"+UrlEncode(StringUtil.LTrimStr(AV30RoleId,12,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV26pApplicationId,12,0));
         return formatLink("gamwwrolepermissions.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMWWRolePermissions" ;
      }

      public override string GetPgmdesc( )
      {
         return "Permiss�es do perfil" ;
      }

      protected void WB1R0( )
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
            GxWebStd.gx_div_start( context, divTableheader_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableactions_Internalname, 1, 0, "px", 0, "px", "TableCellsWidthAuto", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroupColorFilledActions", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 17,'',false,'',0)\"";
            ClassString = "ButtonColorFilled";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnback_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Voltar", bttBtnback_Jsonclick, 5, "Voltar", "", StyleString, ClassString, bttBtnback_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOBACK\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWRolePermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtninsert_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Incluir", bttBtninsert_Jsonclick, 5, "Incluir", "", StyleString, ClassString, bttBtninsert_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOINSERT\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWRolePermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWRolePermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsave_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(59), 2, 0)+","+"null"+");", "Guardar mudan�as", bttBtnsave_Jsonclick, 5, "Guardar mudan�as", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"E\\'DOSAVE\\'."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMWWRolePermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 hidden-xs col-sm-6 CellFloatRight CellWidthAuto", "start", "top", "", "", "div");
            wb_table1_25_1R2( true) ;
         }
         else
         {
            wb_table1_25_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table1_25_1R2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            StartGridControl59( ) ;
         }
         if ( wbEnd == 59 )
         {
            wbEnd = 0;
            nRC_GXsfl_59 = (int)(nGXsfl_59_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV69GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV17GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV72GridAppliedFilters);
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
            ucDdo_grid.SetProperty("Caption", Ddo_grid_Caption);
            ucDdo_grid.SetProperty("ColumnIds", Ddo_grid_Columnids);
            ucDdo_grid.SetProperty("ColumnsSortValues", Ddo_grid_Columnssortvalues);
            ucDdo_grid.SetProperty("Fixable", Ddo_grid_Fixable);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV68DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV57ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         if ( wbEnd == 59 )
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

      protected void START1R2( )
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
            Form.Meta.addItem("description", "Permiss�es do perfil", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1R0( ) ;
      }

      protected void WS1R2( )
      {
         START1R2( ) ;
         EVT1R2( ) ;
      }

      protected void EVT1R2( )
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
                              E111R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E121R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E141R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOBACK'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoBack' */
                              E151R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOINSERT'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoInsert' */
                              E161R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOSAVE'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoSave' */
                              E171R2 ();
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
                              nGXsfl_59_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
                              SubsflControlProps_592( ) ;
                              cmbavGridactions.Name = cmbavGridactions_Internalname;
                              cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
                              AV70GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
                              cmbavOld_accesstype.Name = cmbavOld_accesstype_Internalname;
                              cmbavOld_accesstype.CurrentValue = cgiGet( cmbavOld_accesstype_Internalname);
                              AV23old_AccessType = cgiGet( cmbavOld_accesstype_Internalname);
                              AssignAttri("", false, cmbavOld_accesstype_Internalname, AV23old_AccessType);
                              GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
                              AV24Old_Inherited = StringUtil.StrToBool( cgiGet( chkavOld_inherited_Internalname));
                              AssignAttri("", false, chkavOld_inherited_Internalname, AV24Old_Inherited);
                              GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, AV24Old_Inherited, context));
                              AV30RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavRoleid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              AssignAttri("", false, edtavRoleid_Internalname, StringUtil.LTrimStr( (decimal)(AV30RoleId), 12, 0));
                              GxWebStd.gx_hidden_field( context, "gxhash_vROLEID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9"), context));
                              if ( ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
                              {
                                 GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPPID");
                                 GX_FocusControl = edtavAppid_Internalname;
                                 AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                                 wbErr = true;
                                 AV7AppId = 0;
                                 AssignAttri("", false, edtavAppid_Internalname, StringUtil.LTrimStr( (decimal)(AV7AppId), 12, 0));
                              }
                              else
                              {
                                 AV7AppId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                                 AssignAttri("", false, edtavAppid_Internalname, StringUtil.LTrimStr( (decimal)(AV7AppId), 12, 0));
                              }
                              AV22Name = cgiGet( edtavName_Internalname);
                              AssignAttri("", false, edtavName_Internalname, AV22Name);
                              AV12Dsc = cgiGet( edtavDsc_Internalname);
                              AssignAttri("", false, edtavDsc_Internalname, AV12Dsc);
                              cmbavAccesstype.Name = cmbavAccesstype_Internalname;
                              cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
                              AV6AccessType = cgiGet( cmbavAccesstype_Internalname);
                              AssignAttri("", false, cmbavAccesstype_Internalname, AV6AccessType);
                              AV19Inherited = StringUtil.StrToBool( cgiGet( chkavInherited_Internalname));
                              AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
                              AV18Id = cgiGet( edtavId_Internalname);
                              AssignAttri("", false, edtavId_Internalname, AV18Id);
                              GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E181R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E191R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E201R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "VGRIDACTIONS.CLICK") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E211R2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    if ( ! wbErr )
                                    {
                                       Rfr0gs = false;
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE1R2( )
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

      protected void PA1R2( )
      {
         if ( nDonePA == 0 )
         {
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               GxWebError = 1;
               context.HttpContext.Response.StatusCode = 403;
               context.WriteHtmlText( "<title>403 Forbidden</title>") ;
               context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
               context.WriteHtmlText( "<p /><hr />") ;
               GXUtil.WriteLog("send_http_error_code " + 403.ToString());
            }
            if ( ( StringUtil.StrCmp(context.GetRequestQueryString( ), "") != 0 ) && ( GxWebError == 0 ) && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               GXDecQS = UriDecrypt64( context.GetRequestQueryString( ), GXKey);
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamwwrolepermissions.aspx")), "gamwwrolepermissions.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamwwrolepermissions.aspx")))) ;
               }
               else
               {
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
               }
            }
            if ( ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               if ( nGotPars == 0 )
               {
                  entryPointCalled = false;
                  gxfirstwebparm = GetFirstPar( "RoleId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV30RoleId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, edtavRoleid_Internalname, StringUtil.LTrimStr( (decimal)(AV30RoleId), 12, 0));
                     GxWebStd.gx_hidden_field( context, "gxhash_vROLEID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9"), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV26pApplicationId = (long)(Math.Round(NumberUtil.Val( GetPar( "pApplicationId"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV26pApplicationId", StringUtil.LTrimStr( (decimal)(AV26pApplicationId), 12, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26pApplicationId), "ZZZZZZZZZZZ9"), context));
                     }
                  }
                  if ( toggleJsOutput )
                  {
                     if ( context.isSpaRequest( ) )
                     {
                        enableJsOutput();
                     }
                  }
               }
            }
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
               GX_FocusControl = cmbavApplicationid_Internalname;
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
         SubsflControlProps_592( ) ;
         while ( nGXsfl_59_idx <= nRC_GXsfl_59 )
         {
            sendrow_592( ) ;
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       short AV62ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV57ColumnsSelector ,
                                       string AV77Pgmname ,
                                       long AV10ApplicationId ,
                                       string AV15FilName ,
                                       string AV28PermissionAccessType ,
                                       string AV20IsInherited ,
                                       long AV30RoleId ,
                                       bool AV73IsAuthorized_Back ,
                                       bool AV74IsAuthorized_Insert ,
                                       long AV26pApplicationId )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF1R2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vROLEID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30RoleId), 12, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.RTrim( AV18Id));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "vOLD_ACCESSTYPE", StringUtil.RTrim( AV23old_AccessType));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED", GetSecureSignedToken( "", AV24Old_Inherited, context));
         GxWebStd.gx_hidden_field( context, "vOLD_INHERITED", StringUtil.BoolToStr( AV24Old_Inherited));
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
         if ( cmbavApplicationid.ItemCount > 0 )
         {
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
            AssignProp("", false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         }
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV28PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV28PermissionAccessType);
            AssignAttri("", false, "AV28PermissionAccessType", AV28PermissionAccessType);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV28PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", cmbavPermissionaccesstype.ToJavascriptSource(), true);
         }
         if ( cmbavIsinherited.ItemCount > 0 )
         {
            AV20IsInherited = cmbavIsinherited.getValidValue(AV20IsInherited);
            AssignAttri("", false, "AV20IsInherited", AV20IsInherited);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavIsinherited.CurrentValue = StringUtil.RTrim( AV20IsInherited);
            AssignProp("", false, cmbavIsinherited_Internalname, "Values", cmbavIsinherited.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV77Pgmname = "GAMWWRolePermissions";
         cmbavOld_accesstype.Enabled = 0;
         AssignProp("", false, cmbavOld_accesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOld_accesstype.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         chkavOld_inherited.Enabled = 0;
         AssignProp("", false, chkavOld_inherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOld_inherited.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavRoleid_Enabled = 0;
         AssignProp("", false, edtavRoleid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRoleid_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavAppid_Enabled = 0;
         AssignProp("", false, edtavAppid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAppid_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_59_Refreshing);
      }

      protected void RF1R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 59;
         /* Execute user event: Refresh */
         E191R2 ();
         nGXsfl_59_idx = 1;
         sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
         SubsflControlProps_592( ) ;
         bGXsfl_59_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "GridWithPaginationBar WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.AddObjectProperty("Sortable", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Sortable), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         if ( subGrid_Islastpage != 0 )
         {
            GRID_nFirstRecordOnPage = (long)(subGrid_fnc_Recordcount( )-subGrid_fnc_Recordsperpage( ));
            GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
            GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_592( ) ;
            E201R2 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_59_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E201R2 ();
            }
            wbEnd = 59;
            WB1R0( ) ;
         }
         bGXsfl_59_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes1R2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV77Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV77Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_BACK", AV73IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV73IsAuthorized_Back, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_INSERT", AV74IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV74IsAuthorized_Insert, context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, AV24Old_Inherited, context));
      }

      protected int subGrid_fnc_Pagecount( )
      {
         return (int)(-1) ;
      }

      protected int subGrid_fnc_Recordcount( )
      {
         return (int)(((subGrid_Recordcount==0) ? GRID_nFirstRecordOnPage+1 : subGrid_Recordcount)) ;
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
         return (int)(((subGrid_Islastpage==1) ? NumberUtil.Int( (long)(Math.Round(subGrid_fnc_Recordcount( )/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+((((int)((subGrid_fnc_Recordcount( )) % (subGrid_fnc_Recordsperpage( ))))==0) ? 0 : 1) : NumberUtil.Int( (long)(Math.Round(GRID_nFirstRecordOnPage/ (decimal)(subGrid_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1)) ;
      }

      protected short subgrid_firstpage( )
      {
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         if ( GRID_nEOF == 0 )
         {
            GRID_nFirstRecordOnPage = (long)(GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( ));
         }
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         subGrid_Islastpage = 1;
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
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
            gxgrGrid_refresh( subGrid_Rows, AV62ManageFiltersExecutionStep, AV57ColumnsSelector, AV77Pgmname, AV10ApplicationId, AV15FilName, AV28PermissionAccessType, AV20IsInherited, AV30RoleId, AV73IsAuthorized_Back, AV74IsAuthorized_Insert, AV26pApplicationId) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV77Pgmname = "GAMWWRolePermissions";
         cmbavOld_accesstype.Enabled = 0;
         AssignProp("", false, cmbavOld_accesstype_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavOld_accesstype.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         chkavOld_inherited.Enabled = 0;
         AssignProp("", false, chkavOld_inherited_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkavOld_inherited.Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavRoleid_Enabled = 0;
         AssignProp("", false, edtavRoleid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavRoleid_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavAppid_Enabled = 0;
         AssignProp("", false, edtavAppid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAppid_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavName_Enabled = 0;
         AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavDsc_Enabled = 0;
         AssignProp("", false, edtavDsc_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDsc_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         edtavId_Enabled = 0;
         AssignProp("", false, edtavId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavId_Enabled), 5, 0), !bGXsfl_59_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E181R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV66ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV68DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV57ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_59 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), ",", "."), 18, MidpointRounding.ToEven));
            AV69GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV17GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV72GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGrid_Recordcount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "subGrid_Recordcount"), ",", "."), 18, MidpointRounding.ToEven));
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
            Ddo_grid_Caption = cgiGet( "DDO_GRID_Caption");
            Ddo_grid_Gridinternalname = cgiGet( "DDO_GRID_Gridinternalname");
            Ddo_grid_Columnids = cgiGet( "DDO_GRID_Columnids");
            Ddo_grid_Columnssortvalues = cgiGet( "DDO_GRID_Columnssortvalues");
            Ddo_grid_Fixable = cgiGet( "DDO_GRID_Fixable");
            Ddo_gridcolumnsselector_Icontype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icontype");
            Ddo_gridcolumnsselector_Icon = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Icon");
            Ddo_gridcolumnsselector_Caption = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Caption");
            Ddo_gridcolumnsselector_Tooltip = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Tooltip");
            Ddo_gridcolumnsselector_Cls = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Cls");
            Ddo_gridcolumnsselector_Dropdownoptionstype = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Dropdownoptionstype");
            Ddo_gridcolumnsselector_Gridinternalname = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Gridinternalname");
            Ddo_gridcolumnsselector_Titlecontrolidtoreplace = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Titlecontrolidtoreplace");
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Grid_empowerer_Hastitlesettings = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hastitlesettings"));
            Grid_empowerer_Hascolumnsselector = StringUtil.StrToBool( cgiGet( "GRID_EMPOWERER_Hascolumnsselector"));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Gridpaginationbar_Selectedpage = cgiGet( "GRIDPAGINATIONBAR_Selectedpage");
            Gridpaginationbar_Rowsperpageselectedvalue = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDPAGINATIONBAR_Rowsperpageselectedvalue"), ",", "."), 18, MidpointRounding.ToEven));
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            /* Read variables values. */
            cmbavApplicationid.Name = cmbavApplicationid_Internalname;
            cmbavApplicationid.CurrentValue = cgiGet( cmbavApplicationid_Internalname);
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cgiGet( cmbavApplicationid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
            AV15FilName = cgiGet( edtavFilname_Internalname);
            AssignAttri("", false, "AV15FilName", AV15FilName);
            cmbavPermissionaccesstype.Name = cmbavPermissionaccesstype_Internalname;
            cmbavPermissionaccesstype.CurrentValue = cgiGet( cmbavPermissionaccesstype_Internalname);
            AV28PermissionAccessType = cgiGet( cmbavPermissionaccesstype_Internalname);
            AssignAttri("", false, "AV28PermissionAccessType", AV28PermissionAccessType);
            cmbavIsinherited.Name = cmbavIsinherited_Internalname;
            cmbavIsinherited.CurrentValue = cgiGet( cmbavIsinherited_Internalname);
            AV20IsInherited = cgiGet( cmbavIsinherited_Internalname);
            AssignAttri("", false, "AV20IsInherited", AV20IsInherited);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E181R2 ();
         if (returnInSub) return;
      }

      protected void E181R2( )
      {
         /* Start Routine */
         returnInSub = false;
         cmbavApplicationid.removeAllItems();
         cmbavApplicationid.addItem("0", "(Select)", 0);
         AV76GXV2 = 1;
         AV75GXV1 = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getapplications(AV9ApplicationFilter, out  AV14Errors);
         while ( AV76GXV2 <= AV75GXV1.Count )
         {
            AV8Application = ((GeneXus.Programs.genexussecurity.SdtGAMApplication)AV75GXV1.Item(AV76GXV2));
            cmbavApplicationid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV8Application.gxTpr_Id), 12, 0)), AV8Application.gxTpr_Name, 0);
            AV76GXV2 = (int)(AV76GXV2+1);
         }
         if ( cmbavApplicationid.ItemCount == 2 )
         {
            AV10ApplicationId = AV8Application.gxTpr_Id;
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         else
         {
            AV10ApplicationId = AV26pApplicationId;
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         subGrid_Rows = 10;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         Ddo_gridcolumnsselector_Gridinternalname = subGrid_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "GridInternalName", Ddo_gridcolumnsselector_Gridinternalname);
         if ( StringUtil.StrCmp(AV39HTTPRequest.Method, "GET") == 0 )
         {
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Form.Caption = "Permiss�es do perfil";
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
         /* Execute user subroutine: 'LOADGRIDSTATE' */
         S122 ();
         if (returnInSub) return;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV68DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV68DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
         AV16GAMRole.load( AV30RoleId);
         Form.Caption = StringUtil.Format( "Permiss�es de perfil:%1"+AV16GAMRole.gxTpr_Name, "", "", "", "", "", "", "", "", "");
         AssignProp("", false, "FORM", "Caption", Form.Caption, true);
      }

      protected void E191R2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV40WWPContext) ;
         /* Execute user subroutine: 'CHECKSECURITYFORACTIONS' */
         S132 ();
         if (returnInSub) return;
         if ( AV62ManageFiltersExecutionStep == 1 )
         {
            AV62ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV62ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV62ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV62ManageFiltersExecutionStep == 2 )
         {
            AV62ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV62ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV62ManageFiltersExecutionStep), 1, 0));
            /* Execute user subroutine: 'LOADSAVEDFILTERS' */
            S112 ();
            if (returnInSub) return;
         }
         /* Execute user subroutine: 'SAVEGRIDSTATE' */
         S142 ();
         if (returnInSub) return;
         if ( StringUtil.StrCmp(AV61Session.Get("GAMWWRolePermissionsColumnsSelector"), "") != 0 )
         {
            AV45ColumnsSelectorXML = AV61Session.Get("GAMWWRolePermissionsColumnsSelector");
            AV57ColumnsSelector.FromXml(AV45ColumnsSelectorXML, null, "", "");
         }
         else
         {
            /* Execute user subroutine: 'INITIALIZECOLUMNSSELECTOR' */
            S152 ();
            if (returnInSub) return;
         }
         edtavName_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV57ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavName_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavName_Visible), 5, 0), !bGXsfl_59_Refreshing);
         edtavDsc_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV57ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtavDsc_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDsc_Visible), 5, 0), !bGXsfl_59_Refreshing);
         cmbavAccesstype.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV57ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, cmbavAccesstype_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavAccesstype.Visible), 5, 0), !bGXsfl_59_Refreshing);
         chkavInherited.Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV57ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, chkavInherited_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavInherited.Visible), 5, 0), !bGXsfl_59_Refreshing);
         AV69GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV69GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV69GridCurrentPage), 10, 0));
         GXt_char2 = AV72GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV77Pgmname, out  GXt_char2) ;
         AV72GridAppliedFilters = GXt_char2;
         AssignAttri("", false, "AV72GridAppliedFilters", AV72GridAppliedFilters);
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
      }

      protected void E121R2( )
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
            AV25PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV25PageToGo) ;
         }
      }

      protected void E131R2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      private void E201R2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV34GridPageSize = subGrid_Rows;
         AV16GAMRole.load( AV30RoleId);
         AV31RolePermissionFilter.gxTpr_Applicationid = AV10ApplicationId;
         AV31RolePermissionFilter.gxTpr_Name = "%"+AV15FilName;
         AV31RolePermissionFilter.gxTpr_Accesstype = AV28PermissionAccessType;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV20IsInherited)) )
         {
            AV31RolePermissionFilter.gxTpr_Inherited = "A";
         }
         else
         {
            AV31RolePermissionFilter.gxTpr_Inherited = AV20IsInherited;
         }
         AV17GridPageCount = 0;
         AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
         AV35GridRecordCount = 0;
         if ( ! (0==AV10ApplicationId) )
         {
            AV33Permissions = AV16GAMRole.getpermissions(AV31RolePermissionFilter, out  AV14Errors);
            if ( AV33Permissions.Count > 0 )
            {
               AV17GridPageCount = (long)((AV33Permissions.Count/ (decimal)(AV34GridPageSize))+((((int)((AV33Permissions.Count) % (AV34GridPageSize)))>0) ? 1 : 0));
               AssignAttri("", false, "AV17GridPageCount", StringUtil.LTrimStr( (decimal)(AV17GridPageCount), 10, 0));
            }
            AV35GridRecordCount = AV33Permissions.Count;
            AV78GXV3 = 1;
            while ( AV78GXV3 <= AV33Permissions.Count )
            {
               AV27Permission = ((GeneXus.Programs.genexussecurity.SdtGAMPermission)AV33Permissions.Item(AV78GXV3));
               imgBtndlt_gximage = "ActionDelete";
               AssignProp("", false, imgBtndlt_Internalname, "gximage", imgBtndlt_gximage, true);
               AV11BtnDlt = context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( ));
               AV79Btndlt_GXI = GXDbFile.PathToUrl( context.GetImagePath( "7695fe89-52c9-4b7e-871e-0e11548f823e", "", context.GetTheme( )));
               AV18Id = AV27Permission.gxTpr_Guid;
               AssignAttri("", false, edtavId_Internalname, AV18Id);
               GxWebStd.gx_hidden_field( context, "gxhash_vID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV18Id, "")), context));
               AV22Name = AV27Permission.gxTpr_Name;
               AssignAttri("", false, edtavName_Internalname, AV22Name);
               AV12Dsc = context.GetMessage( AV27Permission.gxTpr_Description, "");
               AssignAttri("", false, edtavDsc_Internalname, AV12Dsc);
               AV6AccessType = AV27Permission.gxTpr_Type;
               AssignAttri("", false, cmbavAccesstype_Internalname, AV6AccessType);
               AV19Inherited = AV27Permission.gxTpr_Inherited;
               AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
               AV23old_AccessType = AV27Permission.gxTpr_Type;
               AssignAttri("", false, cmbavOld_accesstype_Internalname, AV23old_AccessType);
               GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
               AV24Old_Inherited = AV27Permission.gxTpr_Inherited;
               AssignAttri("", false, chkavOld_inherited_Internalname, AV24Old_Inherited);
               GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, AV24Old_Inherited, context));
               cmbavGridactions.removeAllItems();
               cmbavGridactions.addItem("0", ";fa fa-bars", 0);
               cmbavGridactions.addItem("1", StringUtil.Format( "%1;%2", "Excluir", "fa fa-times", "", "", "", "", "", "", ""), 0);
               /* Load Method */
               if ( wbStart != -1 )
               {
                  wbStart = 59;
               }
               if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
               {
                  sendrow_592( ) ;
               }
               GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
               GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
               GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
               subGrid_Recordcount = (int)(GRID_nCurrentRecord);
               if ( isFullAjaxMode( ) && ! bGXsfl_59_Refreshing )
               {
                  DoAjaxLoad(59, GridRow);
               }
               AV78GXV3 = (int)(AV78GXV3+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV31RolePermissionFilter", AV31RolePermissionFilter);
         cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV6AccessType);
         cmbavOld_accesstype.CurrentValue = StringUtil.RTrim( AV23old_AccessType);
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
      }

      protected void E141R2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV45ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV57ColumnsSelector.FromJSonString(AV45ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "GAMWWRolePermissionsColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV45ColumnsSelectorXML)) ? "" : AV57ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
      }

      protected void E111R2( )
      {
         /* Ddo_managefilters_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Clean#>") == 0 )
         {
            /* Execute user subroutine: 'CLEANFILTERS' */
            S162 ();
            if (returnInSub) return;
            subgrid_firstpage( ) ;
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Save#>") == 0 )
         {
            /* Execute user subroutine: 'SAVEGRIDSTATE' */
            S142 ();
            if (returnInSub) return;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("GAMWWRolePermissionsFilters")) + "," + UrlEncode(StringUtil.RTrim(AV77Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV62ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV62ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV62ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("GAMWWRolePermissionsFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV62ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV62ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV62ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char2 = AV63ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "GAMWWRolePermissionsFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char2) ;
            AV63ManageFiltersXml = GXt_char2;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV63ManageFiltersXml)) )
            {
               GX_msglist.addItem("O filtro selecionado n�o existe mais.");
            }
            else
            {
               /* Execute user subroutine: 'CLEANFILTERS' */
               S162 ();
               if (returnInSub) return;
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV77Pgmname+"GridState",  AV63ManageFiltersXml) ;
               AV43GridState.FromXml(AV63ManageFiltersXml, null, "", "");
               /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
               S172 ();
               if (returnInSub) return;
               subgrid_firstpage( ) ;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
         cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
         AssignProp("", false, cmbavApplicationid_Internalname, "Values", cmbavApplicationid.ToJavascriptSource(), true);
         cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV28PermissionAccessType);
         AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", cmbavPermissionaccesstype.ToJavascriptSource(), true);
         cmbavIsinherited.CurrentValue = StringUtil.RTrim( AV20IsInherited);
         AssignProp("", false, cmbavIsinherited_Internalname, "Values", cmbavIsinherited.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
      }

      protected void E211R2( )
      {
         /* Gridactions_Click Routine */
         returnInSub = false;
         if ( AV70GridActions == 1 )
         {
            /* Execute user subroutine: 'DO DELETE' */
            S182 ();
            if (returnInSub) return;
         }
         AV70GridActions = 0;
         AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
         /*  Sending Event outputs  */
         cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
         AssignProp("", false, cmbavGridactions_Internalname, "Values", cmbavGridactions.ToJavascriptSource(), true);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
      }

      protected void E151R2( )
      {
         /* 'DoBack' Routine */
         returnInSub = false;
         if ( AV73IsAuthorized_Back )
         {
            CallWebObject(formatLink("gamwwroles.aspx") );
            context.wjLocDisableFrm = 1;
         }
         else
         {
            GX_msglist.addItem("A a��o n�o encontra-se dispon�vel");
            context.DoAjaxRefresh();
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
      }

      protected void E161R2( )
      {
         /* 'DoInsert' Routine */
         returnInSub = false;
         if ( ! (0==AV10ApplicationId) )
         {
            if ( AV74IsAuthorized_Insert )
            {
               if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
               {
                  gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
               }
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               GXEncryptionTmp = "gamrolepermissionselect.aspx"+UrlEncode(StringUtil.LTrimStr(AV30RoleId,12,0)) + "," + UrlEncode(StringUtil.LTrimStr(AV10ApplicationId,12,0));
               CallWebObject(formatLink("gamrolepermissionselect.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
               context.wjLocDisableFrm = 1;
            }
            else
            {
               GX_msglist.addItem("A a��o n�o encontra-se dispon�vel");
               context.DoAjaxRefresh();
            }
         }
         else
         {
            GX_msglist.addItem("Voc� deve selecionar o aplicativo.");
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV57ColumnsSelector", AV57ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV66ManageFiltersData", AV66ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV43GridState", AV43GridState);
      }

      protected void E171R2( )
      {
         /* 'DoSave' Routine */
         returnInSub = false;
         AV16GAMRole.load( AV30RoleId);
         /* Start For Each Line */
         nRC_GXsfl_59 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_59"), ",", "."), 18, MidpointRounding.ToEven));
         nGXsfl_59_fel_idx = 0;
         while ( nGXsfl_59_fel_idx < nRC_GXsfl_59 )
         {
            nGXsfl_59_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_fel_idx+1);
            sGXsfl_59_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_fel_idx), 4, 0), 4, "0");
            SubsflControlProps_fel_592( ) ;
            cmbavGridactions.Name = cmbavGridactions_Internalname;
            cmbavGridactions.CurrentValue = cgiGet( cmbavGridactions_Internalname);
            AV70GridActions = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavGridactions_Internalname), "."), 18, MidpointRounding.ToEven));
            cmbavOld_accesstype.Name = cmbavOld_accesstype_Internalname;
            cmbavOld_accesstype.CurrentValue = cgiGet( cmbavOld_accesstype_Internalname);
            AV23old_AccessType = cgiGet( cmbavOld_accesstype_Internalname);
            AV24Old_Inherited = StringUtil.StrToBool( cgiGet( chkavOld_inherited_Internalname));
            AV30RoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavRoleid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vAPPID");
               GX_FocusControl = edtavAppid_Internalname;
               wbErr = true;
               AV7AppId = 0;
            }
            else
            {
               AV7AppId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAppid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
            AV22Name = cgiGet( edtavName_Internalname);
            AV12Dsc = cgiGet( edtavDsc_Internalname);
            cmbavAccesstype.Name = cmbavAccesstype_Internalname;
            cmbavAccesstype.CurrentValue = cgiGet( cmbavAccesstype_Internalname);
            AV6AccessType = cgiGet( cmbavAccesstype_Internalname);
            AV19Inherited = StringUtil.StrToBool( cgiGet( chkavInherited_Internalname));
            AV18Id = cgiGet( edtavId_Internalname);
            if ( ( StringUtil.StrCmp(AV6AccessType, AV23old_AccessType) != 0 ) || ( AV19Inherited != AV24Old_Inherited ) )
            {
               AV29PermissionUpd.gxTpr_Applicationid = AV10ApplicationId;
               AV29PermissionUpd.gxTpr_Guid = AV18Id;
               AV29PermissionUpd.gxTpr_Type = AV6AccessType;
               AV29PermissionUpd.gxTpr_Inherited = AV19Inherited;
               AV21isOK = AV16GAMRole.updatepermission(AV29PermissionUpd, out  AV14Errors);
               AssignAttri("", false, "AV21isOK", AV21isOK);
               if ( ! AV21isOK )
               {
                  AV81GXV4 = 1;
                  while ( AV81GXV4 <= AV14Errors.Count )
                  {
                     AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV81GXV4));
                     GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
                     AV81GXV4 = (int)(AV81GXV4+1);
                  }
                  /* Exit For each command. Update data (if necessary), close cursors & exit. */
                  if (true) break;
               }
            }
            /* End For Each Line */
         }
         if ( nGXsfl_59_fel_idx == 0 )
         {
            nGXsfl_59_idx = 1;
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         nGXsfl_59_fel_idx = 1;
         if ( AV21isOK )
         {
            context.CommitDataStores("gamwwrolepermissions",pr_default);
            GX_msglist.addItem("Changes saved successfully.");
         }
         else
         {
            AV82GXV5 = 1;
            while ( AV82GXV5 <= AV14Errors.Count )
            {
               AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV82GXV5));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV82GXV5 = (int)(AV82GXV5+1);
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV29PermissionUpd", AV29PermissionUpd);
      }

      protected void S152( )
      {
         /* 'INITIALIZECOLUMNSSELECTOR' Routine */
         returnInSub = false;
         AV57ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV57ColumnsSelector,  "&Name",  "",  "WWP_GAM_PermissionName",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV57ColumnsSelector,  "&Dsc",  "",  "WWP_GAM_Description",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV57ColumnsSelector,  "&AccessType",  "",  "WWP_GAM_AccessType",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV57ColumnsSelector,  "&Inherited",  "",  "WWP_GAM_Inherited",  true,  "") ;
         GXt_char2 = AV52UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "GAMWWRolePermissionsColumnsSelector", out  GXt_char2) ;
         AV52UserCustomValue = GXt_char2;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV52UserCustomValue)) ) )
         {
            AV71ColumnsSelectorAux.FromXml(AV52UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV71ColumnsSelectorAux, ref  AV57ColumnsSelector) ;
         }
      }

      protected void S132( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         GXt_boolean3 = AV73IsAuthorized_Back;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamwwroles_Execute", out  GXt_boolean3) ;
         AV73IsAuthorized_Back = GXt_boolean3;
         AssignAttri("", false, "AV73IsAuthorized_Back", AV73IsAuthorized_Back);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_BACK", GetSecureSignedToken( "", AV73IsAuthorized_Back, context));
         if ( ! ( AV73IsAuthorized_Back ) )
         {
            bttBtnback_Visible = 0;
            AssignProp("", false, bttBtnback_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnback_Visible), 5, 0), true);
         }
         GXt_boolean3 = AV74IsAuthorized_Insert;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "gamrolepermissionselect_Execute", out  GXt_boolean3) ;
         AV74IsAuthorized_Insert = GXt_boolean3;
         AssignAttri("", false, "AV74IsAuthorized_Insert", AV74IsAuthorized_Insert);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_INSERT", GetSecureSignedToken( "", AV74IsAuthorized_Insert, context));
         if ( ! ( AV74IsAuthorized_Insert ) )
         {
            bttBtninsert_Visible = 0;
            AssignProp("", false, bttBtninsert_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtninsert_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV66ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "GAMWWRolePermissionsFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV66ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S162( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV10ApplicationId = 0;
         AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         AV15FilName = "";
         AssignAttri("", false, "AV15FilName", AV15FilName);
         AV28PermissionAccessType = "";
         AssignAttri("", false, "AV28PermissionAccessType", AV28PermissionAccessType);
         AV20IsInherited = "";
         AssignAttri("", false, "AV20IsInherited", AV20IsInherited);
      }

      protected void S182( )
      {
         /* 'DO DELETE' Routine */
         returnInSub = false;
         AV16GAMRole.load( AV30RoleId);
         AV21isOK = AV16GAMRole.deletepermissionbyid(AV10ApplicationId, AV18Id, out  AV14Errors);
         AssignAttri("", false, "AV21isOK", AV21isOK);
         if ( AV21isOK )
         {
            context.CommitDataStores("gamwwrolepermissions",pr_default);
            context.DoAjaxRefresh();
         }
         else
         {
            AV83GXV6 = 1;
            while ( AV83GXV6 <= AV14Errors.Count )
            {
               AV13Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV14Errors.Item(AV83GXV6));
               GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV13Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV13Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
               AV83GXV6 = (int)(AV83GXV6+1);
            }
         }
      }

      protected void S122( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV61Session.Get(AV77Pgmname+"GridState"), "") == 0 )
         {
            AV43GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV77Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV43GridState.FromXml(AV61Session.Get(AV77Pgmname+"GridState"), null, "", "");
         }
         /* Execute user subroutine: 'LOADREGFILTERSSTATE' */
         S172 ();
         if (returnInSub) return;
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( StringUtil.Trim( AV43GridState.gxTpr_Pagesize))) )
         {
            subGrid_Rows = (int)(Math.Round(NumberUtil.Val( AV43GridState.gxTpr_Pagesize, "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         }
         subgrid_gotopage( AV43GridState.gxTpr_Currentpage) ;
      }

      protected void S172( )
      {
         /* 'LOADREGFILTERSSTATE' Routine */
         returnInSub = false;
         AV84GXV7 = 1;
         while ( AV84GXV7 <= AV43GridState.gxTpr_Filtervalues.Count )
         {
            AV44GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV43GridState.gxTpr_Filtervalues.Item(AV84GXV7));
            if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "APPLICATIONID") == 0 )
            {
               AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( AV44GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "FILNAME") == 0 )
            {
               AV15FilName = AV44GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV15FilName", AV15FilName);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "PERMISSIONACCESSTYPE") == 0 )
            {
               AV28PermissionAccessType = AV44GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV28PermissionAccessType", AV28PermissionAccessType);
            }
            else if ( StringUtil.StrCmp(AV44GridStateFilterValue.gxTpr_Name, "ISINHERITED") == 0 )
            {
               AV20IsInherited = AV44GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV20IsInherited", AV20IsInherited);
            }
            AV84GXV7 = (int)(AV84GXV7+1);
         }
      }

      protected void S142( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV43GridState.FromXml(AV61Session.Get(AV77Pgmname+"GridState"), null, "", "");
         AV43GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV43GridState,  "APPLICATIONID",  "Aplica��o",  !(0==AV10ApplicationId),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0)),  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV43GridState,  "FILNAME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV15FilName)),  0,  AV15FilName,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV43GridState,  "PERMISSIONACCESSTYPE",  "Tipo",  !String.IsNullOrEmpty(StringUtil.RTrim( AV28PermissionAccessType)),  0,  AV28PermissionAccessType,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV43GridState,  "ISINHERITED",  "� heredit�ria?",  !String.IsNullOrEmpty(StringUtil.RTrim( AV20IsInherited)),  0,  AV20IsInherited,  "") ;
         AV43GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV43GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV77Pgmname+"GridState",  AV43GridState.ToXml(false, true, "", "")) ;
      }

      protected void wb_table1_25_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablerightheader_Internalname, tblTablerightheader_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellAlignTopPaddingTop2'>") ;
            /* User Defined Control */
            ucDdo_managefilters.SetProperty("IconType", Ddo_managefilters_Icontype);
            ucDdo_managefilters.SetProperty("Icon", Ddo_managefilters_Icon);
            ucDdo_managefilters.SetProperty("Caption", Ddo_managefilters_Caption);
            ucDdo_managefilters.SetProperty("Tooltip", Ddo_managefilters_Tooltip);
            ucDdo_managefilters.SetProperty("Cls", Ddo_managefilters_Cls);
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV66ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_30_1R2( true) ;
         }
         else
         {
            wb_table2_30_1R2( false) ;
         }
         return  ;
      }

      protected void wb_table2_30_1R2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_25_1R2e( true) ;
         }
         else
         {
            wb_table1_25_1R2e( false) ;
         }
      }

      protected void wb_table2_30_1R2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblTablefilters_Internalname, tblTablefilters_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavApplicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavApplicationid_Internalname, "Aplica��o", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavApplicationid, cmbavApplicationid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0)), 1, cmbavApplicationid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavApplicationid.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "", true, 0, "HLP_GAMWWRolePermissions.htm");
            cmbavApplicationid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0));
            AssignProp("", false, cmbavApplicationid_Internalname, "Values", (string)(cmbavApplicationid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavFilname_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavFilname_Internalname, "Nome", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'" + sGXsfl_59_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilname_Internalname, StringUtil.RTrim( AV15FilName), StringUtil.RTrim( context.localUtil.Format( AV15FilName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,40);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavFilname_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilname_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMWWRolePermissions.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPermissionaccesstype_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPermissionaccesstype_Internalname, "Tipo", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPermissionaccesstype, cmbavPermissionaccesstype_Internalname, StringUtil.RTrim( AV28PermissionAccessType), 1, cmbavPermissionaccesstype_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavPermissionaccesstype.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "", true, 0, "HLP_GAMWWRolePermissions.htm");
            cmbavPermissionaccesstype.CurrentValue = StringUtil.RTrim( AV28PermissionAccessType);
            AssignProp("", false, cmbavPermissionaccesstype_Internalname, "Values", (string)(cmbavPermissionaccesstype.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellFormGroupMarginBottom5'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+cmbavIsinherited_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavIsinherited_Internalname, "� heredit�ria?", "gx-form-item AttributeLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'" + sGXsfl_59_idx + "',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavIsinherited, cmbavIsinherited_Internalname, StringUtil.RTrim( AV20IsInherited), 1, cmbavIsinherited_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavIsinherited.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_GAMWWRolePermissions.htm");
            cmbavIsinherited.CurrentValue = StringUtil.RTrim( AV20IsInherited);
            AssignProp("", false, cmbavIsinherited_Internalname, "Values", (string)(cmbavIsinherited.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_30_1R2e( true) ;
         }
         else
         {
            wb_table2_30_1R2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV30RoleId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, edtavRoleid_Internalname, StringUtil.LTrimStr( (decimal)(AV30RoleId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vROLEID"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9"), context));
         AV26pApplicationId = Convert.ToInt64(getParm(obj,1));
         AssignAttri("", false, "AV26pApplicationId", StringUtil.LTrimStr( (decimal)(AV26pApplicationId), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vPAPPLICATIONID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV26pApplicationId), "ZZZZZZZZZZZ9"), context));
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
         PA1R2( ) ;
         WS1R2( ) ;
         WE1R2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828201151", true, true);
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
         context.AddJavascriptSource("gamwwrolepermissions.js", "?2023828201156", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_592( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_59_idx;
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE_"+sGXsfl_59_idx;
         chkavOld_inherited_Internalname = "vOLD_INHERITED_"+sGXsfl_59_idx;
         edtavRoleid_Internalname = "vROLEID_"+sGXsfl_59_idx;
         edtavAppid_Internalname = "vAPPID_"+sGXsfl_59_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_59_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_59_idx;
         cmbavAccesstype_Internalname = "vACCESSTYPE_"+sGXsfl_59_idx;
         chkavInherited_Internalname = "vINHERITED_"+sGXsfl_59_idx;
         edtavId_Internalname = "vID_"+sGXsfl_59_idx;
      }

      protected void SubsflControlProps_fel_592( )
      {
         cmbavGridactions_Internalname = "vGRIDACTIONS_"+sGXsfl_59_fel_idx;
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE_"+sGXsfl_59_fel_idx;
         chkavOld_inherited_Internalname = "vOLD_INHERITED_"+sGXsfl_59_fel_idx;
         edtavRoleid_Internalname = "vROLEID_"+sGXsfl_59_fel_idx;
         edtavAppid_Internalname = "vAPPID_"+sGXsfl_59_fel_idx;
         edtavName_Internalname = "vNAME_"+sGXsfl_59_fel_idx;
         edtavDsc_Internalname = "vDSC_"+sGXsfl_59_fel_idx;
         cmbavAccesstype_Internalname = "vACCESSTYPE_"+sGXsfl_59_fel_idx;
         chkavInherited_Internalname = "vINHERITED_"+sGXsfl_59_fel_idx;
         edtavId_Internalname = "vID_"+sGXsfl_59_fel_idx;
      }

      protected void sendrow_592( )
      {
         SubsflControlProps_592( ) ;
         WB1R0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_59_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_59_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_59_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            TempTags = " " + ((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 60,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            if ( ( cmbavGridactions.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vGRIDACTIONS_" + sGXsfl_59_idx;
               cmbavGridactions.Name = GXCCtl;
               cmbavGridactions.WebTags = "";
               if ( cmbavGridactions.ItemCount > 0 )
               {
                  AV70GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavGridactions,(string)cmbavGridactions_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0)),(short)1,(string)cmbavGridactions_Jsonclick,(short)5,"'"+""+"'"+",false,"+"'"+"EVGRIDACTIONS.CLICK."+sGXsfl_59_idx+"'",(string)"int",(string)"",(short)-1,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"ConvertToDDO",(string)"WWActionGroupColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavGridactions.Enabled!=0)&&(cmbavGridactions.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,60);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavGridactions.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0));
            AssignProp("", false, cmbavGridactions_Internalname, "Values", (string)(cmbavGridactions.ToJavascriptSource()), !bGXsfl_59_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            TempTags = " " + ((cmbavOld_accesstype.Enabled!=0)&&(cmbavOld_accesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 61,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            if ( ( cmbavOld_accesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vOLD_ACCESSTYPE_" + sGXsfl_59_idx;
               cmbavOld_accesstype.Name = GXCCtl;
               cmbavOld_accesstype.WebTags = "";
               cmbavOld_accesstype.addItem("A", "Permitir", 0);
               cmbavOld_accesstype.addItem("D", "Recusar", 0);
               cmbavOld_accesstype.addItem("R", "Restrito", 0);
               if ( cmbavOld_accesstype.ItemCount > 0 )
               {
                  AV23old_AccessType = cmbavOld_accesstype.getValidValue(AV23old_AccessType);
                  AssignAttri("", false, cmbavOld_accesstype_Internalname, AV23old_AccessType);
                  GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavOld_accesstype,(string)cmbavOld_accesstype_Internalname,StringUtil.RTrim( AV23old_AccessType),(short)1,(string)cmbavOld_accesstype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",(short)0,cmbavOld_accesstype.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavOld_accesstype.Enabled!=0)&&(cmbavOld_accesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,61);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavOld_accesstype.CurrentValue = StringUtil.RTrim( AV23old_AccessType);
            AssignProp("", false, cmbavOld_accesstype_Internalname, "Values", (string)(cmbavOld_accesstype.ToJavascriptSource()), !bGXsfl_59_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavOld_inherited.Enabled!=0)&&(chkavOld_inherited.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 62,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vOLD_INHERITED_" + sGXsfl_59_idx;
            chkavOld_inherited.Name = GXCCtl;
            chkavOld_inherited.WebTags = "";
            chkavOld_inherited.Caption = "";
            AssignProp("", false, chkavOld_inherited_Internalname, "TitleCaption", chkavOld_inherited.Caption, !bGXsfl_59_Refreshing);
            chkavOld_inherited.CheckedValue = "false";
            AV24Old_Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Old_Inherited));
            AssignAttri("", false, chkavOld_inherited_Internalname, AV24Old_Inherited);
            GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, AV24Old_Inherited, context));
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavOld_inherited_Internalname,StringUtil.BoolToStr( AV24Old_Inherited),(string)"",(string)"",(short)0,chkavOld_inherited.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(62, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavOld_inherited.Enabled!=0)&&(chkavOld_inherited.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,62);\"" : " ")});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavRoleid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30RoleId), 12, 0, ",", "")),StringUtil.LTrim( ((edtavRoleid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV30RoleId), "ZZZZZZZZZZZ9"))),(string)" dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavRoleid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavRoleid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavAppid_Enabled!=0)&&(edtavAppid_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 64,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavAppid_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AppId), 12, 0, ",", "")),StringUtil.LTrim( ((edtavAppid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV7AppId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV7AppId), "ZZZZZZZZZZZ9")))," dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+((edtavAppid_Enabled!=0)&&(edtavAppid_Visible!=0) ? " onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,64);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavAppid_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavAppid_Enabled,(short)0,(string)"text",(string)"1",(short)0,(string)"px",(short)17,(string)"px",(short)12,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMKeyNumLong",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 65,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavName_Internalname,StringUtil.RTrim( AV22Name),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavName_Enabled!=0)&&(edtavName_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,65);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavName_Visible,(int)edtavName_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)120,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionMedium",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtavDsc_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 66,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavDsc_Internalname,StringUtil.RTrim( AV12Dsc),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavDsc_Enabled!=0)&&(edtavDsc_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,66);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavDsc_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtavDsc_Visible,(int)edtavDsc_Enabled,(short)0,(string)"text",(string)"",(short)570,(string)"px",(short)17,(string)"px",(short)254,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)-1,(bool)true,(string)"GeneXusSecurityCommon\\GAMDescriptionLong",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((cmbavAccesstype.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            TempTags = " " + ((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 67,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            if ( ( cmbavAccesstype.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "vACCESSTYPE_" + sGXsfl_59_idx;
               cmbavAccesstype.Name = GXCCtl;
               cmbavAccesstype.WebTags = "";
               cmbavAccesstype.addItem("A", "Permitir", 0);
               cmbavAccesstype.addItem("D", "Recusar", 0);
               cmbavAccesstype.addItem("R", "Restrito", 0);
               if ( cmbavAccesstype.ItemCount > 0 )
               {
                  AV6AccessType = cmbavAccesstype.getValidValue(AV6AccessType);
                  AssignAttri("", false, cmbavAccesstype_Internalname, AV6AccessType);
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavAccesstype,(string)cmbavAccesstype_Internalname,StringUtil.RTrim( AV6AccessType),(short)1,(string)cmbavAccesstype_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"char",(string)"",cmbavAccesstype.Visible,(short)1,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)"WWColumn",(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((cmbavAccesstype.Enabled!=0)&&(cmbavAccesstype.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,67);\"" : " "),(string)"",(bool)true,(short)0});
            cmbavAccesstype.CurrentValue = StringUtil.RTrim( AV6AccessType);
            AssignProp("", false, cmbavAccesstype_Internalname, "Values", (string)(cmbavAccesstype.ToJavascriptSource()), !bGXsfl_59_Refreshing);
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+""+"\""+" style=\""+((chkavInherited.Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Check box */
            TempTags = " " + ((chkavInherited.Enabled!=0)&&(chkavInherited.Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 68,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ClassString = "Attribute";
            StyleString = "";
            GXCCtl = "vINHERITED_" + sGXsfl_59_idx;
            chkavInherited.Name = GXCCtl;
            chkavInherited.WebTags = "";
            chkavInherited.Caption = "";
            AssignProp("", false, chkavInherited_Internalname, "TitleCaption", chkavInherited.Caption, !bGXsfl_59_Refreshing);
            chkavInherited.CheckedValue = "false";
            AV19Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Inherited));
            AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
            GridRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkavInherited_Internalname,StringUtil.BoolToStr( AV19Inherited),(string)"",(string)"",chkavInherited.Visible,(short)1,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"WWColumn",(string)"",TempTags+" onclick="+"\"gx.fn.checkboxClick(68, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+((chkavInherited.Enabled!=0)&&(chkavInherited.Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,68);\"" : " ")});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            TempTags = " " + ((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onfocus=\"gx.evt.onfocus(this, 69,'',false,'"+sGXsfl_59_idx+"',59)\"" : " ");
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavId_Internalname,StringUtil.RTrim( AV18Id),(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+((edtavId_Enabled!=0)&&(edtavId_Visible!=0) ? " onblur=\""+""+";gx.evt.onblur(this,69);\"" : " "),(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavId_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavId_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)59,(short)0,(short)-1,(short)0,(bool)true,(string)"GeneXusSecurityCommon\\GAMGUID",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes1R2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_59_idx = ((subGrid_Islastpage==1)&&(nGXsfl_59_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_59_idx+1);
            sGXsfl_59_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_59_idx), 4, 0), 4, "0");
            SubsflControlProps_592( ) ;
         }
         /* End function sendrow_592 */
      }

      protected void init_web_controls( )
      {
         cmbavApplicationid.Name = "vAPPLICATIONID";
         cmbavApplicationid.WebTags = "";
         if ( cmbavApplicationid.ItemCount > 0 )
         {
            AV10ApplicationId = (long)(Math.Round(NumberUtil.Val( cmbavApplicationid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV10ApplicationId), 12, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV10ApplicationId", StringUtil.LTrimStr( (decimal)(AV10ApplicationId), 12, 0));
         }
         cmbavPermissionaccesstype.Name = "vPERMISSIONACCESSTYPE";
         cmbavPermissionaccesstype.WebTags = "";
         cmbavPermissionaccesstype.addItem("", "(Nenhum)", 0);
         cmbavPermissionaccesstype.addItem("A", "Permitir", 0);
         cmbavPermissionaccesstype.addItem("D", "Recusar", 0);
         cmbavPermissionaccesstype.addItem("R", "Restrito", 0);
         if ( cmbavPermissionaccesstype.ItemCount > 0 )
         {
            AV28PermissionAccessType = cmbavPermissionaccesstype.getValidValue(AV28PermissionAccessType);
            AssignAttri("", false, "AV28PermissionAccessType", AV28PermissionAccessType);
         }
         cmbavIsinherited.Name = "vISINHERITED";
         cmbavIsinherited.WebTags = "";
         cmbavIsinherited.addItem("", "Todos", 0);
         cmbavIsinherited.addItem("T", "Sim", 0);
         cmbavIsinherited.addItem("F", "N�o", 0);
         if ( cmbavIsinherited.ItemCount > 0 )
         {
            AV20IsInherited = cmbavIsinherited.getValidValue(AV20IsInherited);
            AssignAttri("", false, "AV20IsInherited", AV20IsInherited);
         }
         GXCCtl = "vGRIDACTIONS_" + sGXsfl_59_idx;
         cmbavGridactions.Name = GXCCtl;
         cmbavGridactions.WebTags = "";
         if ( cmbavGridactions.ItemCount > 0 )
         {
            AV70GridActions = (short)(Math.Round(NumberUtil.Val( cmbavGridactions.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV70GridActions), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, cmbavGridactions_Internalname, StringUtil.LTrimStr( (decimal)(AV70GridActions), 4, 0));
         }
         GXCCtl = "vOLD_ACCESSTYPE_" + sGXsfl_59_idx;
         cmbavOld_accesstype.Name = GXCCtl;
         cmbavOld_accesstype.WebTags = "";
         cmbavOld_accesstype.addItem("A", "Permitir", 0);
         cmbavOld_accesstype.addItem("D", "Recusar", 0);
         cmbavOld_accesstype.addItem("R", "Restrito", 0);
         if ( cmbavOld_accesstype.ItemCount > 0 )
         {
            AV23old_AccessType = cmbavOld_accesstype.getValidValue(AV23old_AccessType);
            AssignAttri("", false, cmbavOld_accesstype_Internalname, AV23old_AccessType);
            GxWebStd.gx_hidden_field( context, "gxhash_vOLD_ACCESSTYPE"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, StringUtil.RTrim( context.localUtil.Format( AV23old_AccessType, "")), context));
         }
         GXCCtl = "vOLD_INHERITED_" + sGXsfl_59_idx;
         chkavOld_inherited.Name = GXCCtl;
         chkavOld_inherited.WebTags = "";
         chkavOld_inherited.Caption = "";
         AssignProp("", false, chkavOld_inherited_Internalname, "TitleCaption", chkavOld_inherited.Caption, !bGXsfl_59_Refreshing);
         chkavOld_inherited.CheckedValue = "false";
         AV24Old_Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV24Old_Inherited));
         AssignAttri("", false, chkavOld_inherited_Internalname, AV24Old_Inherited);
         GxWebStd.gx_hidden_field( context, "gxhash_vOLD_INHERITED"+"_"+sGXsfl_59_idx, GetSecureSignedToken( sGXsfl_59_idx, AV24Old_Inherited, context));
         GXCCtl = "vACCESSTYPE_" + sGXsfl_59_idx;
         cmbavAccesstype.Name = GXCCtl;
         cmbavAccesstype.WebTags = "";
         cmbavAccesstype.addItem("A", "Permitir", 0);
         cmbavAccesstype.addItem("D", "Recusar", 0);
         cmbavAccesstype.addItem("R", "Restrito", 0);
         if ( cmbavAccesstype.ItemCount > 0 )
         {
            AV6AccessType = cmbavAccesstype.getValidValue(AV6AccessType);
            AssignAttri("", false, cmbavAccesstype_Internalname, AV6AccessType);
         }
         GXCCtl = "vINHERITED_" + sGXsfl_59_idx;
         chkavInherited.Name = GXCCtl;
         chkavInherited.WebTags = "";
         chkavInherited.Caption = "";
         AssignProp("", false, chkavInherited_Internalname, "TitleCaption", chkavInherited.Caption, !bGXsfl_59_Refreshing);
         chkavInherited.CheckedValue = "false";
         AV19Inherited = StringUtil.StrToBool( StringUtil.BoolToStr( AV19Inherited));
         AssignAttri("", false, chkavInherited_Internalname, AV19Inherited);
         /* End function init_web_controls */
      }

      protected void StartGridControl59( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"59\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"ConvertToDDO"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtavName_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome da permiss�o") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" width="+StringUtil.LTrimStr( (decimal)(570), 4, 0)+"px"+" class=\""+"Attribute"+"\" "+" style=\""+((edtavDsc_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Descri��o") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((cmbavAccesstype.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Tipo de acesso") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+""+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((chkavInherited.Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Herdado") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV70GridActions), 4, 0, ".", ""))));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV23old_AccessType)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavOld_accesstype.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV24Old_Inherited)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavOld_inherited.Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30RoleId), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavRoleid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7AppId), 12, 0, ".", ""))));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavAppid_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV22Name)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavName_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV12Dsc)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Enabled), 5, 0, ".", "")));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavDsc_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV6AccessType)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavAccesstype.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( AV19Inherited)));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkavInherited.Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.RTrim( AV18Id)));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavId_Enabled), 5, 0, ".", "")));
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
         bttBtnback_Internalname = "BTNBACK";
         bttBtninsert_Internalname = "BTNINSERT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsave_Internalname = "BTNSAVE";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         cmbavApplicationid_Internalname = "vAPPLICATIONID";
         edtavFilname_Internalname = "vFILNAME";
         cmbavPermissionaccesstype_Internalname = "vPERMISSIONACCESSTYPE";
         cmbavIsinherited_Internalname = "vISINHERITED";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheader_Internalname = "TABLEHEADER";
         cmbavGridactions_Internalname = "vGRIDACTIONS";
         cmbavOld_accesstype_Internalname = "vOLD_ACCESSTYPE";
         chkavOld_inherited_Internalname = "vOLD_INHERITED";
         edtavRoleid_Internalname = "vROLEID";
         edtavAppid_Internalname = "vAPPID";
         edtavName_Internalname = "vNAME";
         edtavDsc_Internalname = "vDSC";
         cmbavAccesstype_Internalname = "vACCESSTYPE";
         chkavInherited_Internalname = "vINHERITED";
         edtavId_Internalname = "vID";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
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
         edtavId_Jsonclick = "";
         edtavId_Visible = 0;
         edtavId_Enabled = 1;
         chkavInherited.Caption = "";
         chkavInherited.Enabled = 1;
         cmbavAccesstype_Jsonclick = "";
         cmbavAccesstype.Enabled = 1;
         edtavDsc_Jsonclick = "";
         edtavDsc_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavAppid_Jsonclick = "";
         edtavAppid_Visible = 0;
         edtavAppid_Enabled = 1;
         edtavRoleid_Jsonclick = "";
         edtavRoleid_Enabled = 0;
         chkavOld_inherited.Caption = "";
         chkavOld_inherited.Visible = 0;
         chkavOld_inherited.Enabled = 1;
         cmbavOld_accesstype_Jsonclick = "";
         cmbavOld_accesstype.Visible = 0;
         cmbavOld_accesstype.Enabled = 1;
         cmbavGridactions_Jsonclick = "";
         cmbavGridactions.Visible = -1;
         cmbavGridactions.Enabled = 1;
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         cmbavIsinherited_Jsonclick = "";
         cmbavIsinherited.Enabled = 1;
         cmbavPermissionaccesstype_Jsonclick = "";
         cmbavPermissionaccesstype.Enabled = 1;
         edtavFilname_Jsonclick = "";
         edtavFilname_Enabled = 1;
         cmbavApplicationid_Jsonclick = "";
         cmbavApplicationid.Enabled = 1;
         chkavInherited.Visible = -1;
         cmbavAccesstype.Visible = -1;
         edtavDsc_Visible = -1;
         edtavName_Visible = -1;
         subGrid_Sortable = 0;
         bttBtninsert_Visible = 1;
         bttBtnback_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Columnssortvalues = "|||";
         Ddo_grid_Columnids = "5:Name|6:Dsc|7:AccessType|8:Inherited";
         Ddo_grid_Gridinternalname = "";
         Gridpaginationbar_Rowsperpagecaption = "WWP_PagingRowsPerPage";
         Gridpaginationbar_Emptygridcaption = "WWP_PagingEmptyGridCaption";
         Gridpaginationbar_Caption = "P�gina <CURRENT_PAGE> de <TOTAL_PAGES>";
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
         Form.Caption = "Permiss�es do perfil";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E121R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E131R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E201R2',iparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'AV17GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV18Id',fld:'vID',pic:'',hsh:true},{av:'AV22Name',fld:'vNAME',pic:''},{av:'AV12Dsc',fld:'vDSC',pic:''},{av:'cmbavAccesstype'},{av:'AV6AccessType',fld:'vACCESSTYPE',pic:''},{av:'AV19Inherited',fld:'vINHERITED',pic:''},{av:'cmbavOld_accesstype'},{av:'AV23old_AccessType',fld:'vOLD_ACCESSTYPE',pic:'',hsh:true},{av:'AV24Old_Inherited',fld:'vOLD_INHERITED',pic:'',hsh:true},{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E141R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E111R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("VGRIDACTIONS.CLICK","{handler:'E211R2',iparms:[{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV18Id',fld:'vID',pic:'',hsh:true}]");
         setEventMetadata("VGRIDACTIONS.CLICK",",oparms:[{av:'cmbavGridactions'},{av:'AV70GridActions',fld:'vGRIDACTIONS',pic:'ZZZ9'},{av:'AV21isOK',fld:'vISOK',pic:''},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOBACK'","{handler:'E151R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOBACK'",",oparms:[{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOINSERT'","{handler:'E161R2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV77Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15FilName',fld:'vFILNAME',pic:''},{av:'cmbavPermissionaccesstype'},{av:'AV28PermissionAccessType',fld:'vPERMISSIONACCESSTYPE',pic:''},{av:'cmbavIsinherited'},{av:'AV20IsInherited',fld:'vISINHERITED',pic:''},{av:'AV30RoleId',fld:'vROLEID',pic:'ZZZZZZZZZZZ9',hsh:true},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{av:'AV26pApplicationId',fld:'vPAPPLICATIONID',pic:'ZZZZZZZZZZZ9',hsh:true}]");
         setEventMetadata("'DOINSERT'",",oparms:[{av:'AV62ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV57ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtavName_Visible',ctrl:'vNAME',prop:'Visible'},{av:'edtavDsc_Visible',ctrl:'vDSC',prop:'Visible'},{av:'cmbavAccesstype'},{av:'chkavInherited.Visible',ctrl:'vINHERITED',prop:'Visible'},{av:'AV69GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV72GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{av:'AV73IsAuthorized_Back',fld:'vISAUTHORIZED_BACK',pic:'',hsh:true},{ctrl:'BTNBACK',prop:'Visible'},{av:'AV74IsAuthorized_Insert',fld:'vISAUTHORIZED_INSERT',pic:'',hsh:true},{ctrl:'BTNINSERT',prop:'Visible'},{av:'AV66ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV43GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("'DOSAVE'","{handler:'E171R2',iparms:[{av:'AV30RoleId',fld:'vROLEID',grid:59,pic:'ZZZZZZZZZZZ9',hsh:true},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_59',ctrl:'GRID',grid:59,prop:'GridRC',grid:59},{av:'AV6AccessType',fld:'vACCESSTYPE',grid:59,pic:''},{av:'AV23old_AccessType',fld:'vOLD_ACCESSTYPE',grid:59,pic:'',hsh:true},{av:'AV19Inherited',fld:'vINHERITED',grid:59,pic:''},{av:'AV24Old_Inherited',fld:'vOLD_INHERITED',grid:59,pic:'',hsh:true},{av:'cmbavApplicationid'},{av:'AV10ApplicationId',fld:'vAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV18Id',fld:'vID',grid:59,pic:'',hsh:true},{av:'AV21isOK',fld:'vISOK',pic:''}]");
         setEventMetadata("'DOSAVE'",",oparms:[{av:'AV21isOK',fld:'vISOK',pic:''}]}");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPE","{handler:'Validv_Permissionaccesstype',iparms:[]");
         setEventMetadata("VALIDV_PERMISSIONACCESSTYPE",",oparms:[]}");
         setEventMetadata("VALIDV_OLD_ACCESSTYPE","{handler:'Validv_Old_accesstype',iparms:[]");
         setEventMetadata("VALIDV_OLD_ACCESSTYPE",",oparms:[]}");
         setEventMetadata("VALIDV_ACCESSTYPE","{handler:'Validv_Accesstype',iparms:[]");
         setEventMetadata("VALIDV_ACCESSTYPE",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Validv_Id',iparms:[]");
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
         Ddo_gridcolumnsselector_Columnsselectorvalues = "";
         Ddo_managefilters_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV57ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV77Pgmname = "";
         AV15FilName = "";
         AV28PermissionAccessType = "";
         AV20IsInherited = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV66ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV72GridAppliedFilters = "";
         AV68DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV43GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
         Ddo_grid_Caption = "";
         Ddo_gridcolumnsselector_Gridinternalname = "";
         Grid_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         TempTags = "";
         ClassString = "";
         StyleString = "";
         bttBtnback_Jsonclick = "";
         bttBtninsert_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsave_Jsonclick = "";
         GridContainer = new GXWebGrid( context);
         sStyleString = "";
         ucGridpaginationbar = new GXUserControl();
         ucDdo_grid = new GXUserControl();
         ucDdo_gridcolumnsselector = new GXUserControl();
         ucGrid_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV23old_AccessType = "";
         AV22Name = "";
         AV12Dsc = "";
         AV6AccessType = "";
         AV18Id = "";
         GXDecQS = "";
         AV75GXV1 = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication>( context, "GeneXus.Programs.genexussecurity.SdtGAMApplication", "GeneXus.Programs");
         AV9ApplicationFilter = new GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter(context);
         AV14Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV8Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV39HTTPRequest = new GxHttpRequest( context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV16GAMRole = new GeneXus.Programs.genexussecurity.SdtGAMRole(context);
         AV40WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV61Session = context.GetSession();
         AV45ColumnsSelectorXML = "";
         AV31RolePermissionFilter = new GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter(context);
         AV33Permissions = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission>( context, "GeneXus.Programs.genexussecurity.SdtGAMPermission", "GeneXus.Programs");
         AV27Permission = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV11BtnDlt = "";
         imgBtndlt_gximage = "";
         imgBtndlt_Internalname = "";
         AV79Btndlt_GXI = "";
         GridRow = new GXWebRow();
         AV63ManageFiltersXml = "";
         AV29PermissionUpd = new GeneXus.Programs.genexussecurity.SdtGAMPermission(context);
         AV13Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         AV52UserCustomValue = "";
         GXt_char2 = "";
         AV71ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV44GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         GXCCtl = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamwwrolepermissions__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamwwrolepermissions__default(),
            new Object[][] {
            }
         );
         AV77Pgmname = "GAMWWRolePermissions";
         /* GeneXus formulas. */
         AV77Pgmname = "GAMWWRolePermissions";
         cmbavOld_accesstype.Enabled = 0;
         chkavOld_inherited.Enabled = 0;
         edtavRoleid_Enabled = 0;
         edtavAppid_Enabled = 0;
         edtavName_Enabled = 0;
         edtavDsc_Enabled = 0;
         edtavId_Enabled = 0;
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV62ManageFiltersExecutionStep ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short AV70GridActions ;
      private short nDonePA ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_59 ;
      private int subGrid_Recordcount ;
      private int nGXsfl_59_idx=1 ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnback_Visible ;
      private int bttBtninsert_Visible ;
      private int subGrid_Islastpage ;
      private int edtavRoleid_Enabled ;
      private int edtavAppid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDsc_Enabled ;
      private int edtavId_Enabled ;
      private int GRID_nGridOutOfScope ;
      private int AV76GXV2 ;
      private int edtavName_Visible ;
      private int edtavDsc_Visible ;
      private int AV25PageToGo ;
      private int AV78GXV3 ;
      private int nGXsfl_59_fel_idx=1 ;
      private int AV81GXV4 ;
      private int AV82GXV5 ;
      private int AV83GXV6 ;
      private int AV84GXV7 ;
      private int edtavFilname_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int edtavAppid_Visible ;
      private int edtavId_Visible ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long AV30RoleId ;
      private long AV26pApplicationId ;
      private long wcpOAV30RoleId ;
      private long wcpOAV26pApplicationId ;
      private long GRID_nFirstRecordOnPage ;
      private long AV10ApplicationId ;
      private long AV69GridCurrentPage ;
      private long AV17GridPageCount ;
      private long AV7AppId ;
      private long GRID_nCurrentRecord ;
      private long AV34GridPageSize ;
      private long AV35GridRecordCount ;
      private string Gridpaginationbar_Selectedpage ;
      private string Ddo_gridcolumnsselector_Columnsselectorvalues ;
      private string Ddo_managefilters_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_59_idx="0001" ;
      private string AV77Pgmname ;
      private string AV15FilName ;
      private string AV28PermissionAccessType ;
      private string AV20IsInherited ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
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
      private string Ddo_grid_Caption ;
      private string Ddo_grid_Gridinternalname ;
      private string Ddo_grid_Columnids ;
      private string Ddo_grid_Columnssortvalues ;
      private string Ddo_grid_Fixable ;
      private string Ddo_gridcolumnsselector_Icontype ;
      private string Ddo_gridcolumnsselector_Icon ;
      private string Ddo_gridcolumnsselector_Caption ;
      private string Ddo_gridcolumnsselector_Tooltip ;
      private string Ddo_gridcolumnsselector_Cls ;
      private string Ddo_gridcolumnsselector_Dropdownoptionstype ;
      private string Ddo_gridcolumnsselector_Gridinternalname ;
      private string Ddo_gridcolumnsselector_Titlecontrolidtoreplace ;
      private string Grid_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableheader_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnback_Internalname ;
      private string bttBtnback_Jsonclick ;
      private string bttBtninsert_Internalname ;
      private string bttBtninsert_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsave_Internalname ;
      private string bttBtnsave_Jsonclick ;
      private string divGridtablewithpaginationbar_Internalname ;
      private string sStyleString ;
      private string subGrid_Internalname ;
      private string Gridpaginationbar_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Ddo_grid_Internalname ;
      private string Ddo_gridcolumnsselector_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string cmbavGridactions_Internalname ;
      private string cmbavOld_accesstype_Internalname ;
      private string AV23old_AccessType ;
      private string chkavOld_inherited_Internalname ;
      private string edtavRoleid_Internalname ;
      private string edtavAppid_Internalname ;
      private string AV22Name ;
      private string edtavName_Internalname ;
      private string AV12Dsc ;
      private string edtavDsc_Internalname ;
      private string cmbavAccesstype_Internalname ;
      private string AV6AccessType ;
      private string chkavInherited_Internalname ;
      private string AV18Id ;
      private string edtavId_Internalname ;
      private string GXDecQS ;
      private string cmbavApplicationid_Internalname ;
      private string cmbavPermissionaccesstype_Internalname ;
      private string cmbavIsinherited_Internalname ;
      private string edtavFilname_Internalname ;
      private string imgBtndlt_gximage ;
      private string imgBtndlt_Internalname ;
      private string sGXsfl_59_fel_idx="0001" ;
      private string GXt_char2 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string cmbavApplicationid_Jsonclick ;
      private string edtavFilname_Jsonclick ;
      private string cmbavPermissionaccesstype_Jsonclick ;
      private string cmbavIsinherited_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string GXCCtl ;
      private string cmbavGridactions_Jsonclick ;
      private string cmbavOld_accesstype_Jsonclick ;
      private string ROClassString ;
      private string edtavRoleid_Jsonclick ;
      private string edtavAppid_Jsonclick ;
      private string edtavName_Jsonclick ;
      private string edtavDsc_Jsonclick ;
      private string cmbavAccesstype_Jsonclick ;
      private string edtavId_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV73IsAuthorized_Back ;
      private bool AV74IsAuthorized_Insert ;
      private bool AV21isOK ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool AV24Old_Inherited ;
      private bool AV19Inherited ;
      private bool bGXsfl_59_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_refresh_fired ;
      private bool GXt_boolean3 ;
      private string AV45ColumnsSelectorXML ;
      private string AV63ManageFiltersXml ;
      private string AV52UserCustomValue ;
      private string AV72GridAppliedFilters ;
      private string AV79Btndlt_GXI ;
      private string AV11BtnDlt ;
      private IGxSession AV61Session ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridRow ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucGridpaginationbar ;
      private GXUserControl ucDdo_grid ;
      private GXUserControl ucDdo_gridcolumnsselector ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavApplicationid ;
      private GXCombobox cmbavPermissionaccesstype ;
      private GXCombobox cmbavIsinherited ;
      private GXCombobox cmbavGridactions ;
      private GXCombobox cmbavOld_accesstype ;
      private GXCheckbox chkavOld_inherited ;
      private GXCombobox cmbavAccesstype ;
      private GXCheckbox chkavInherited ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GxHttpRequest AV39HTTPRequest ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMApplication> AV75GXV1 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV14Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMPermission> AV33Permissions ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV66ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV8Application ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV13Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRole AV16GAMRole ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV27Permission ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermission AV29PermissionUpd ;
      private GeneXus.Programs.genexussecurity.SdtGAMPermissionFilter AV31RolePermissionFilter ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplicationFilter AV9ApplicationFilter ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV40WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV43GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV44GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV57ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV71ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV68DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
   }

   public class gamwwrolepermissions__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class gamwwrolepermissions__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        def= new CursorDef[] {
        };
     }
  }

  public void getResults( int cursor ,
                          IFieldGetter rslt ,
                          Object[] buf )
  {
  }

}

}
