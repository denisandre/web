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
   public class mesorregiaoww : GXDataArea
   {
      public mesorregiaoww( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public mesorregiaoww( IGxContext context )
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
         nRC_GXsfl_41 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_41"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_41_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_41_idx = GetPar( "sGXsfl_41_idx");
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
         AV43ManageFiltersExecutionStep = (short)(Math.Round(NumberUtil.Val( GetPar( "ManageFiltersExecutionStep"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV38ColumnsSelector);
         AV63Pgmname = GetPar( "Pgmname");
         AV46TFMesorregiaoID = (int)(Math.Round(NumberUtil.Val( GetPar( "TFMesorregiaoID"), "."), 18, MidpointRounding.ToEven));
         AV47TFMesorregiaoID_To = (int)(Math.Round(NumberUtil.Val( GetPar( "TFMesorregiaoID_To"), "."), 18, MidpointRounding.ToEven));
         AV44TFMesorregiaoNome = GetPar( "TFMesorregiaoNome");
         AV45TFMesorregiaoNome_Sel = GetPar( "TFMesorregiaoNome_Sel");
         AV48TFMesorregiaoUFSigla = GetPar( "TFMesorregiaoUFSigla");
         AV49TFMesorregiaoUFSigla_Sel = GetPar( "TFMesorregiaoUFSigla_Sel");
         AV50TFMesorregiaoUFRegNome = GetPar( "TFMesorregiaoUFRegNome");
         AV51TFMesorregiaoUFRegNome_Sel = GetPar( "TFMesorregiaoUFRegNome_Sel");
         AV14OrderedBy = (short)(Math.Round(NumberUtil.Val( GetPar( "OrderedBy"), "."), 18, MidpointRounding.ToEven));
         AV15OrderedDsc = StringUtil.StrToBool( GetPar( "OrderedDsc"));
         AV62IsAuthorized_MesorregiaoNome = StringUtil.StrToBool( GetPar( "IsAuthorized_MesorregiaoNome"));
         AV59IsAuthorized_MesorregiaoUFSigla = StringUtil.StrToBool( GetPar( "IsAuthorized_MesorregiaoUFSigla"));
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
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
            return "mesorregiaoww_Execute" ;
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
         PA4E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4E2( ) ;
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.mesorregiaoww.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAONOME", AV62IsAuthorized_MesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAONOME", GetSecureSignedToken( "", AV62IsAuthorized_MesorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAOUFSIGLA", AV59IsAuthorized_MesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAOUFSIGLA", GetSecureSignedToken( "", AV59IsAuthorized_MesorregiaoUFSigla, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         GxWebStd.gx_hidden_field( context, "GXH_vFILTERFULLTEXT", AV17FilterFullText);
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMANAGEFILTERSDATA", AV41ManageFiltersData);
         }
         GxWebStd.gx_hidden_field( context, "vGRIDCURRENTPAGE", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV56GridCurrentPage), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDPAGECOUNT", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV57GridPageCount), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGRIDAPPLIEDFILTERS", AV58GridAppliedFilters);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAGEXPORTDATA", AV60AGExportData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAGEXPORTDATA", AV60AGExportData);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV52DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vCOLUMNSSELECTOR", AV38ColumnsSelector);
         }
         GxWebStd.gx_hidden_field( context, "vMANAGEFILTERSEXECUTIONSTEP", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV43ManageFiltersExecutionStep), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV46TFMesorregiaoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOID_TO", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV47TFMesorregiaoID_To), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAONOME", AV44TFMesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAONOME_SEL", AV45TFMesorregiaoNome_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOUFSIGLA", AV48TFMesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOUFSIGLA_SEL", AV49TFMesorregiaoUFSigla_Sel);
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOUFREGNOME", AV50TFMesorregiaoUFRegNome);
         GxWebStd.gx_hidden_field( context, "vTFMESORREGIAOUFREGNOME_SEL", AV51TFMesorregiaoUFRegNome_Sel);
         GxWebStd.gx_hidden_field( context, "vORDEREDBY", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14OrderedBy), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "vORDEREDDSC", AV15OrderedDsc);
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAONOME", AV62IsAuthorized_MesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAONOME", GetSecureSignedToken( "", AV62IsAuthorized_MesorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAOUFSIGLA", AV59IsAuthorized_MesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAOUFSIGLA", GetSecureSignedToken( "", AV59IsAuthorized_MesorregiaoUFSigla, context));
         GxWebStd.gx_hidden_field( context, "MESORREGIAOUFID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A15MesorregiaoUFID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vGRIDSTATE", AV11GridState);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vGRIDSTATE", AV11GridState);
         }
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
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Activeeventkey", StringUtil.RTrim( Ddo_grid_Activeeventkey));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedvalue_get", StringUtil.RTrim( Ddo_grid_Selectedvalue_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Selectedcolumn", StringUtil.RTrim( Ddo_grid_Selectedcolumn));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtext_get", StringUtil.RTrim( Ddo_grid_Filteredtext_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRID_Filteredtextto_get", StringUtil.RTrim( Ddo_grid_Filteredtextto_get));
         GxWebStd.gx_hidden_field( context, "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues", StringUtil.RTrim( Ddo_gridcolumnsselector_Columnsselectorvalues));
         GxWebStd.gx_hidden_field( context, "DDO_MANAGEFILTERS_Activeeventkey", StringUtil.RTrim( Ddo_managefilters_Activeeventkey));
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
            WE4E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4E2( ) ;
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
         return formatLink("core.mesorregiaoww.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "core.mesorregiaoWW" ;
      }

      public override string GetPgmdesc( )
      {
         return " Mesorregiões" ;
      }

      protected void WB4E0( )
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
            ClassString = "ColumnsSelector";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnagexport_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Exportar", bttBtnagexport_Jsonclick, 0, "Exportar", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\mesorregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 19,'',false,'',0)\"";
            ClassString = "hidden-xs";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtneditcolumns_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "Selecionar colunas", bttBtneditcolumns_Jsonclick, 0, "Selecionar colunas", "", StyleString, ClassString, 1, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\mesorregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
            ClassString = "Button";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnsubscriptions_Internalname, "gx.evt.setGridEvt("+StringUtil.Str( (decimal)(41), 2, 0)+","+"null"+");", "", bttBtnsubscriptions_Jsonclick, 0, "Assinaturas", "", StyleString, ClassString, bttBtnsubscriptions_Visible, 0, "standard", "'"+""+"'"+",false,"+"'"+""+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\mesorregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            wb_table1_23_4E2( true) ;
         }
         else
         {
            wb_table1_23_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_4E2e( bool wbgen )
      {
         if ( wbgen )
         {
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
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
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
            ucGridpaginationbar.SetProperty("CurrentPage", AV56GridCurrentPage);
            ucGridpaginationbar.SetProperty("PageCount", AV57GridPageCount);
            ucGridpaginationbar.SetProperty("AppliedFilters", AV58GridAppliedFilters);
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
            ucDdo_agexport.SetProperty("DropDownOptionsData", AV60AGExportData);
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
            ucDdo_grid.SetProperty("FilterIsRange", Ddo_grid_Filterisrange);
            ucDdo_grid.SetProperty("IncludeDataList", Ddo_grid_Includedatalist);
            ucDdo_grid.SetProperty("DataListType", Ddo_grid_Datalisttype);
            ucDdo_grid.SetProperty("DataListProc", Ddo_grid_Datalistproc);
            ucDdo_grid.SetProperty("Format", Ddo_grid_Format);
            ucDdo_grid.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_grid.Render(context, "dvelop.gxbootstrap.ddogridtitlesettingsm", Ddo_grid_Internalname, "DDO_GRIDContainer");
            /* User Defined Control */
            ucDdo_gridcolumnsselector.SetProperty("IconType", Ddo_gridcolumnsselector_Icontype);
            ucDdo_gridcolumnsselector.SetProperty("Icon", Ddo_gridcolumnsselector_Icon);
            ucDdo_gridcolumnsselector.SetProperty("Caption", Ddo_gridcolumnsselector_Caption);
            ucDdo_gridcolumnsselector.SetProperty("Tooltip", Ddo_gridcolumnsselector_Tooltip);
            ucDdo_gridcolumnsselector.SetProperty("Cls", Ddo_gridcolumnsselector_Cls);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsType", Ddo_gridcolumnsselector_Dropdownoptionstype);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsTitleSettingsIcons", AV52DDO_TitleSettingsIcons);
            ucDdo_gridcolumnsselector.SetProperty("DropDownOptionsData", AV38ColumnsSelector);
            ucDdo_gridcolumnsselector.Render(context, "dvelop.gxbootstrap.ddogridcolumnsselector", Ddo_gridcolumnsselector_Internalname, "DDO_GRIDCOLUMNSSELECTORContainer");
            /* User Defined Control */
            ucGrid_empowerer.SetProperty("HasTitleSettings", Grid_empowerer_Hastitlesettings);
            ucGrid_empowerer.SetProperty("HasColumnsSelector", Grid_empowerer_Hascolumnsselector);
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0058"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0058"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( bGXsfl_41_Refreshing )
               {
                  if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                  {
                     if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                     {
                        context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0058"+"");
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
         if ( wbEnd == 41 )
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

      protected void START4E2( )
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
            Form.Meta.addItem("description", " Mesorregiões", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4E0( ) ;
      }

      protected void WS4E2( )
      {
         START4E2( ) ;
         EVT4E2( ) ;
      }

      protected void EVT4E2( )
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
                              E114E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGINATIONBAR.CHANGEROWSPERPAGE") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_AGEXPORT.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E144E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E154E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRID.ONOPTIONCLICKED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E164E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E174E2 ();
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
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              A13MesorregiaoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtMesorregiaoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                              A14MesorregiaoNome = cgiGet( edtMesorregiaoNome_Internalname);
                              A16MesorregiaoUFSigla = StringUtil.Upper( cgiGet( edtMesorregiaoUFSigla_Internalname));
                              A21MesorregiaoUFRegNome = cgiGet( edtMesorregiaoUFRegNome_Internalname);
                              n21MesorregiaoUFRegNome = false;
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E184E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E194E2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E204E2 ();
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
                        if ( nCmpId == 58 )
                        {
                           OldWwpaux_wc = cgiGet( "W0058");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0058", "", sEvt);
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

      protected void WE4E2( )
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

      protected void PA4E2( )
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
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGrid_refresh( int subGrid_Rows ,
                                       string AV17FilterFullText ,
                                       short AV43ManageFiltersExecutionStep ,
                                       GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ,
                                       string AV63Pgmname ,
                                       int AV46TFMesorregiaoID ,
                                       int AV47TFMesorregiaoID_To ,
                                       string AV44TFMesorregiaoNome ,
                                       string AV45TFMesorregiaoNome_Sel ,
                                       string AV48TFMesorregiaoUFSigla ,
                                       string AV49TFMesorregiaoUFSigla_Sel ,
                                       string AV50TFMesorregiaoUFRegNome ,
                                       string AV51TFMesorregiaoUFRegNome_Sel ,
                                       short AV14OrderedBy ,
                                       bool AV15OrderedDsc ,
                                       bool AV62IsAuthorized_MesorregiaoNome ,
                                       bool AV59IsAuthorized_MesorregiaoUFSigla )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF4E2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGrid_refresh */
      }

      protected void send_integrity_hashes( )
      {
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
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF4E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV63Pgmname = "core.mesorregiaoWW";
      }

      protected void RF4E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E194E2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
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
            SubsflControlProps_412( ) ;
            GXPagingFrom2 = (int)(((subGrid_Rows==0) ? 0 : GRID_nFirstRecordOnPage));
            GXPagingTo2 = ((subGrid_Rows==0) ? 10000 : subGrid_fnc_Recordsperpage( )+1);
            pr_default.dynParam(0, new Object[]{ new Object[]{
                                                 AV64Core_mesorregiaowwds_1_filterfulltext ,
                                                 AV65Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                                 AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                                 AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                                 AV67Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                                 AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                                 AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                                 AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                                 AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                                 A13MesorregiaoID ,
                                                 A14MesorregiaoNome ,
                                                 A16MesorregiaoUFSigla ,
                                                 A21MesorregiaoUFRegNome ,
                                                 AV14OrderedBy ,
                                                 AV15OrderedDsc } ,
                                                 new int[]{
                                                 TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                                 }
            });
            lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
            lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
            lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
            lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
            lV67Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV67Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
            lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
            lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
            /* Using cursor H004E2 */
            pr_default.execute(0, new Object[] {lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, AV65Core_mesorregiaowwds_2_tfmesorregiaoid, AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV67Core_mesorregiaowwds_4_tfmesorregiaonome, AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, GXPagingFrom2, GXPagingTo2, GXPagingTo2});
            nGXsfl_41_idx = 1;
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
            while ( ( (pr_default.getStatus(0) != 101) ) && ( ( ( subGrid_Rows == 0 ) || ( GRID_nCurrentRecord < subGrid_fnc_Recordsperpage( ) ) ) ) )
            {
               A15MesorregiaoUFID = H004E2_A15MesorregiaoUFID[0];
               A21MesorregiaoUFRegNome = H004E2_A21MesorregiaoUFRegNome[0];
               n21MesorregiaoUFRegNome = H004E2_n21MesorregiaoUFRegNome[0];
               A16MesorregiaoUFSigla = H004E2_A16MesorregiaoUFSigla[0];
               A14MesorregiaoNome = H004E2_A14MesorregiaoNome[0];
               A13MesorregiaoID = H004E2_A13MesorregiaoID[0];
               E204E2 ();
               pr_default.readNext(0);
            }
            GRID_nEOF = (short)(((pr_default.getStatus(0) == 101) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            pr_default.close(0);
            wbEnd = 41;
            WB4E0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes4E2( )
      {
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV63Pgmname));
         GxWebStd.gx_hidden_field( context, "gxhash_vPGMNAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV63Pgmname, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAONOME", AV62IsAuthorized_MesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAONOME", GetSecureSignedToken( "", AV62IsAuthorized_MesorregiaoNome, context));
         GxWebStd.gx_boolean_hidden_field( context, "vISAUTHORIZED_MESORREGIAOUFSIGLA", AV59IsAuthorized_MesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAOUFSIGLA", GetSecureSignedToken( "", AV59IsAuthorized_MesorregiaoUFSigla, context));
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
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
         pr_default.dynParam(1, new Object[]{ new Object[]{
                                              AV64Core_mesorregiaowwds_1_filterfulltext ,
                                              AV65Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                              AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                              AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                              AV67Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                              AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                              AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                              AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                              AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                              A13MesorregiaoID ,
                                              A14MesorregiaoNome ,
                                              A16MesorregiaoUFSigla ,
                                              A21MesorregiaoUFRegNome ,
                                              AV14OrderedBy ,
                                              AV15OrderedDsc } ,
                                              new int[]{
                                              TypeConstants.INT, TypeConstants.INT, TypeConstants.INT, TypeConstants.BOOLEAN, TypeConstants.SHORT, TypeConstants.BOOLEAN
                                              }
         });
         lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV64Core_mesorregiaowwds_1_filterfulltext = StringUtil.Concat( StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext), "%", "");
         lV67Core_mesorregiaowwds_4_tfmesorregiaonome = StringUtil.Concat( StringUtil.RTrim( AV67Core_mesorregiaowwds_4_tfmesorregiaonome), "%", "");
         lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = StringUtil.Concat( StringUtil.RTrim( AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla), "%", "");
         lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = StringUtil.Concat( StringUtil.RTrim( AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome), "%", "");
         /* Using cursor H004E3 */
         pr_default.execute(1, new Object[] {lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, lV64Core_mesorregiaowwds_1_filterfulltext, AV65Core_mesorregiaowwds_2_tfmesorregiaoid, AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to, lV67Core_mesorregiaowwds_4_tfmesorregiaonome, AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla, AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome, AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel});
         GRID_nRecordCount = H004E3_AGRID_nRecordCount[0];
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
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRID_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgrid_previouspage( )
      {
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgrid_gotopage( int nPageNo )
      {
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
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
            gxgrGrid_refresh( subGrid_Rows, AV17FilterFullText, AV43ManageFiltersExecutionStep, AV38ColumnsSelector, AV63Pgmname, AV46TFMesorregiaoID, AV47TFMesorregiaoID_To, AV44TFMesorregiaoNome, AV45TFMesorregiaoNome_Sel, AV48TFMesorregiaoUFSigla, AV49TFMesorregiaoUFSigla_Sel, AV50TFMesorregiaoUFRegNome, AV51TFMesorregiaoUFRegNome_Sel, AV14OrderedBy, AV15OrderedDsc, AV62IsAuthorized_MesorregiaoNome, AV59IsAuthorized_MesorregiaoUFSigla) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV63Pgmname = "core.mesorregiaoWW";
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E184E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vMANAGEFILTERSDATA"), AV41ManageFiltersData);
            ajax_req_read_hidden_sdt(cgiGet( "vAGEXPORTDATA"), AV60AGExportData);
            ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV52DDO_TitleSettingsIcons);
            ajax_req_read_hidden_sdt(cgiGet( "vCOLUMNSSELECTOR"), AV38ColumnsSelector);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            AV56GridCurrentPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDCURRENTPAGE"), ",", "."), 18, MidpointRounding.ToEven));
            AV57GridPageCount = (long)(Math.Round(context.localUtil.CToN( cgiGet( "vGRIDPAGECOUNT"), ",", "."), 18, MidpointRounding.ToEven));
            AV58GridAppliedFilters = cgiGet( "vGRIDAPPLIEDFILTERS");
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
            Ddo_grid_Activeeventkey = cgiGet( "DDO_GRID_Activeeventkey");
            Ddo_grid_Selectedvalue_get = cgiGet( "DDO_GRID_Selectedvalue_get");
            Ddo_grid_Selectedcolumn = cgiGet( "DDO_GRID_Selectedcolumn");
            Ddo_grid_Filteredtext_get = cgiGet( "DDO_GRID_Filteredtext_get");
            Ddo_grid_Filteredtextto_get = cgiGet( "DDO_GRID_Filteredtextto_get");
            Ddo_gridcolumnsselector_Columnsselectorvalues = cgiGet( "DDO_GRIDCOLUMNSSELECTOR_Columnsselectorvalues");
            Ddo_managefilters_Activeeventkey = cgiGet( "DDO_MANAGEFILTERS_Activeeventkey");
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Ddo_agexport_Activeeventkey = cgiGet( "DDO_AGEXPORT_Activeeventkey");
            /* Read variables values. */
            AV17FilterFullText = cgiGet( edtavFilterfulltext_Internalname);
            AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
            if ( StringUtil.StrCmp(cgiGet( "GXH_vFILTERFULLTEXT"), AV17FilterFullText) != 0 )
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
         E184E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E184E2( )
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
         AV60AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV61AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV61AGExportDataItem.gxTpr_Title = "Excel";
         AV61AGExportDataItem.gxTpr_Icon = context.convertURL( (string)(context.GetImagePath( "da69a816-fd11-445b-8aaf-1a2f7f1acc93", "", context.GetTheme( ))));
         AV61AGExportDataItem.gxTpr_Eventkey = "Export";
         AV61AGExportDataItem.gxTpr_Isdivider = false;
         AV60AGExportData.Add(AV61AGExportDataItem, 0);
         Ddc_subscriptions_Titlecontrolidtoreplace = bttBtnsubscriptions_Internalname;
         ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "TitleControlIdToReplace", Ddc_subscriptions_Titlecontrolidtoreplace);
         GXt_boolean1 = AV62IsAuthorized_MesorregiaoNome;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "mesorregiaoview_Execute", out  GXt_boolean1) ;
         AV62IsAuthorized_MesorregiaoNome = GXt_boolean1;
         AssignAttri("", false, "AV62IsAuthorized_MesorregiaoNome", AV62IsAuthorized_MesorregiaoNome);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAONOME", GetSecureSignedToken( "", AV62IsAuthorized_MesorregiaoNome, context));
         GXt_boolean1 = AV59IsAuthorized_MesorregiaoUFSigla;
         new GeneXus.Programs.wwpbaseobjects.secgamisauthbyfunctionalitykey(context ).execute(  "ufview_Execute", out  GXt_boolean1) ;
         AV59IsAuthorized_MesorregiaoUFSigla = GXt_boolean1;
         AssignAttri("", false, "AV59IsAuthorized_MesorregiaoUFSigla", AV59IsAuthorized_MesorregiaoUFSigla);
         GxWebStd.gx_hidden_field( context, "gxhash_vISAUTHORIZED_MESORREGIAOUFSIGLA", GetSecureSignedToken( "", AV59IsAuthorized_MesorregiaoUFSigla, context));
         AV53GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV54GAMErrors);
         Ddo_grid_Gridinternalname = subGrid_Internalname;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GridInternalName", Ddo_grid_Gridinternalname);
         Ddo_grid_Gamoauthtoken = AV53GAMSession.gxTpr_Token;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "GAMOAuthToken", Ddo_grid_Gamoauthtoken);
         Form.Caption = " Mesorregiões";
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
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = AV52DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2) ;
         AV52DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2;
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = bttBtneditcolumns_Internalname;
         ucDdo_gridcolumnsselector.SendProperty(context, "", false, Ddo_gridcolumnsselector_Internalname, "TitleControlIdToReplace", Ddo_gridcolumnsselector_Titlecontrolidtoreplace);
         Gridpaginationbar_Rowsperpageselectedvalue = subGrid_Rows;
         ucGridpaginationbar.SendProperty(context, "", false, Gridpaginationbar_Internalname, "RowsPerPageSelectedValue", StringUtil.LTrimStr( (decimal)(Gridpaginationbar_Rowsperpageselectedvalue), 9, 0));
      }

      protected void E194E2( )
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
         if ( AV43ManageFiltersExecutionStep == 1 )
         {
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
         }
         else if ( AV43ManageFiltersExecutionStep == 2 )
         {
            AV43ManageFiltersExecutionStep = 0;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
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
         if ( StringUtil.StrCmp(AV40Session.Get("core.mesorregiaoWWColumnsSelector"), "") != 0 )
         {
            AV36ColumnsSelectorXML = AV40Session.Get("core.mesorregiaoWWColumnsSelector");
            AV38ColumnsSelector.FromXml(AV36ColumnsSelectorXML, null, "", "");
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
         edtMesorregiaoID_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(1)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMesorregiaoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoID_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMesorregiaoNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(2)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMesorregiaoNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoNome_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMesorregiaoUFSigla_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(3)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMesorregiaoUFSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFSigla_Visible), 5, 0), !bGXsfl_41_Refreshing);
         edtMesorregiaoUFRegNome_Visible = (((GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector_Column)AV38ColumnsSelector.gxTpr_Columns.Item(4)).gxTpr_Isvisible ? 1 : 0);
         AssignProp("", false, edtMesorregiaoUFRegNome_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtMesorregiaoUFRegNome_Visible), 5, 0), !bGXsfl_41_Refreshing);
         AV56GridCurrentPage = subGrid_fnc_Currentpage( );
         AssignAttri("", false, "AV56GridCurrentPage", StringUtil.LTrimStr( (decimal)(AV56GridCurrentPage), 10, 0));
         AV57GridPageCount = subGrid_fnc_Pagecount( );
         AssignAttri("", false, "AV57GridPageCount", StringUtil.LTrimStr( (decimal)(AV57GridPageCount), 10, 0));
         GXt_char3 = AV58GridAppliedFilters;
         new GeneXus.Programs.wwpbaseobjects.wwp_getappliedfiltersdescription(context ).execute(  AV63Pgmname, out  GXt_char3) ;
         AV58GridAppliedFilters = GXt_char3;
         AssignAttri("", false, "AV58GridAppliedFilters", AV58GridAppliedFilters);
         AV64Core_mesorregiaowwds_1_filterfulltext = AV17FilterFullText;
         AV65Core_mesorregiaowwds_2_tfmesorregiaoid = AV46TFMesorregiaoID;
         AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to = AV47TFMesorregiaoID_To;
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = AV44TFMesorregiaoNome;
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = AV45TFMesorregiaoNome_Sel;
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = AV48TFMesorregiaoUFSigla;
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = AV49TFMesorregiaoUFSigla_Sel;
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = AV50TFMesorregiaoUFRegNome;
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = AV51TFMesorregiaoUFRegNome_Sel;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E124E2( )
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
            AV55PageToGo = (int)(Math.Round(NumberUtil.Val( Gridpaginationbar_Selectedpage, "."), 18, MidpointRounding.ToEven));
            subgrid_gotopage( AV55PageToGo) ;
         }
      }

      protected void E134E2( )
      {
         /* Gridpaginationbar_Changerowsperpage Routine */
         returnInSub = false;
         subGrid_Rows = Gridpaginationbar_Rowsperpageselectedvalue;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         subgrid_firstpage( ) ;
         /*  Sending Event outputs  */
      }

      protected void E164E2( )
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
            if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MesorregiaoID") == 0 )
            {
               AV46TFMesorregiaoID = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtext_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFMesorregiaoID", StringUtil.LTrimStr( (decimal)(AV46TFMesorregiaoID), 9, 0));
               AV47TFMesorregiaoID_To = (int)(Math.Round(NumberUtil.Val( Ddo_grid_Filteredtextto_get, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFMesorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV47TFMesorregiaoID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MesorregiaoNome") == 0 )
            {
               AV44TFMesorregiaoNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV44TFMesorregiaoNome", AV44TFMesorregiaoNome);
               AV45TFMesorregiaoNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV45TFMesorregiaoNome_Sel", AV45TFMesorregiaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MesorregiaoUFSigla") == 0 )
            {
               AV48TFMesorregiaoUFSigla = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV48TFMesorregiaoUFSigla", AV48TFMesorregiaoUFSigla);
               AV49TFMesorregiaoUFSigla_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV49TFMesorregiaoUFSigla_Sel", AV49TFMesorregiaoUFSigla_Sel);
            }
            else if ( StringUtil.StrCmp(Ddo_grid_Selectedcolumn, "MesorregiaoUFRegNome") == 0 )
            {
               AV50TFMesorregiaoUFRegNome = Ddo_grid_Filteredtext_get;
               AssignAttri("", false, "AV50TFMesorregiaoUFRegNome", AV50TFMesorregiaoUFRegNome);
               AV51TFMesorregiaoUFRegNome_Sel = Ddo_grid_Selectedvalue_get;
               AssignAttri("", false, "AV51TFMesorregiaoUFRegNome_Sel", AV51TFMesorregiaoUFRegNome_Sel);
            }
            subgrid_firstpage( ) ;
         }
         /*  Sending Event outputs  */
      }

      private void E204E2( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         if ( AV62IsAuthorized_MesorregiaoNome )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.mesorregiaoview.aspx"+UrlEncode(StringUtil.LTrimStr(A13MesorregiaoID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMesorregiaoNome_Link = formatLink("core.mesorregiaoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         if ( AV59IsAuthorized_MesorregiaoUFSigla )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.ufview.aspx"+UrlEncode(StringUtil.LTrimStr(A15MesorregiaoUFID,9,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            edtMesorregiaoUFSigla_Link = formatLink("core.ufview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
         }
         /* Load Method */
         if ( wbStart != -1 )
         {
            wbStart = 41;
         }
         sendrow_412( ) ;
         GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
         if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
         {
            DoAjaxLoad(41, GridRow);
         }
         /*  Sending Event outputs  */
      }

      protected void E174E2( )
      {
         /* Ddo_gridcolumnsselector_Oncolumnschanged Routine */
         returnInSub = false;
         AV36ColumnsSelectorXML = Ddo_gridcolumnsselector_Columnsselectorvalues;
         AV38ColumnsSelector.FromJSonString(AV36ColumnsSelectorXML, null);
         new GeneXus.Programs.wwpbaseobjects.savecolumnsselectorstate(context ).execute(  "core.mesorregiaoWWColumnsSelector",  (String.IsNullOrEmpty(StringUtil.RTrim( AV36ColumnsSelectorXML)) ? "" : AV38ColumnsSelector.ToXml(false, true, "", ""))) ;
         context.DoAjaxRefresh();
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E114E2( )
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
            GXEncryptionTmp = "wwpbaseobjects.savefilteras.aspx"+UrlEncode(StringUtil.RTrim("core.mesorregiaoWWFilters")) + "," + UrlEncode(StringUtil.RTrim(AV63Pgmname+"GridState"));
            context.PopUp(formatLink("wwpbaseobjects.savefilteras.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else if ( StringUtil.StrCmp(Ddo_managefilters_Activeeventkey, "<#Manage#>") == 0 )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "wwpbaseobjects.managefilters.aspx"+UrlEncode(StringUtil.RTrim("core.mesorregiaoWWFilters"));
            context.PopUp(formatLink("wwpbaseobjects.managefilters.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey), new Object[] {});
            AV43ManageFiltersExecutionStep = 2;
            AssignAttri("", false, "AV43ManageFiltersExecutionStep", StringUtil.Str( (decimal)(AV43ManageFiltersExecutionStep), 1, 0));
            context.DoAjaxRefresh();
         }
         else
         {
            GXt_char3 = AV42ManageFiltersXml;
            new GeneXus.Programs.wwpbaseobjects.getfilterbyname(context ).execute(  "core.mesorregiaoWWFilters",  Ddo_managefilters_Activeeventkey, out  GXt_char3) ;
            AV42ManageFiltersXml = GXt_char3;
            if ( String.IsNullOrEmpty(StringUtil.RTrim( AV42ManageFiltersXml)) )
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
               new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV42ManageFiltersXml) ;
               AV11GridState.FromXml(AV42ManageFiltersXml, null, "", "");
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
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38ColumnsSelector", AV38ColumnsSelector);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV41ManageFiltersData", AV41ManageFiltersData);
      }

      protected void E144E2( )
      {
         /* Ddo_agexport_Onoptionclicked Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Ddo_agexport_Activeeventkey, "Export") == 0 )
         {
            /* Execute user subroutine: 'DOEXPORT' */
            S202 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11GridState", AV11GridState);
      }

      protected void E154E2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0058",(string)"",(string)"mesorregiao",(short)1,(string)"",(string)""});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0058"+"");
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
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MesorregiaoID",  "",  "ID",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MesorregiaoNome",  "",  "Nome",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MesorregiaoUFSigla",  "",  "UF",  true,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_columnsselector_add(context ).execute( ref  AV38ColumnsSelector,  "MesorregiaoUFRegNome",  "",  "Região",  true,  "") ;
         GXt_char3 = AV37UserCustomValue;
         new GeneXus.Programs.wwpbaseobjects.loadcolumnsselectorstate(context ).execute(  "core.mesorregiaoWWColumnsSelector", out  GXt_char3) ;
         AV37UserCustomValue = GXt_char3;
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( AV37UserCustomValue)) ) )
         {
            AV39ColumnsSelectorAux.FromXml(AV37UserCustomValue, null, "", "");
            new GeneXus.Programs.wwpbaseobjects.wwp_columnselector_updatecolumns(context ).execute( ref  AV39ColumnsSelectorAux, ref  AV38ColumnsSelector) ;
         }
      }

      protected void S152( )
      {
         /* 'CHECKSECURITYFORACTIONS' Routine */
         returnInSub = false;
         if ( ! ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "mesorregiao",  1) ) )
         {
            bttBtnsubscriptions_Visible = 0;
            AssignProp("", false, bttBtnsubscriptions_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtnsubscriptions_Visible), 5, 0), true);
         }
      }

      protected void S112( )
      {
         /* 'LOADSAVEDFILTERS' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = AV41ManageFiltersData;
         new GeneXus.Programs.wwpbaseobjects.wwp_managefiltersloadsavedfilters(context ).execute(  "core.mesorregiaoWWFilters",  "",  "",  false, out  GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4) ;
         AV41ManageFiltersData = GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4;
      }

      protected void S182( )
      {
         /* 'CLEANFILTERS' Routine */
         returnInSub = false;
         AV17FilterFullText = "";
         AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
         AV46TFMesorregiaoID = 0;
         AssignAttri("", false, "AV46TFMesorregiaoID", StringUtil.LTrimStr( (decimal)(AV46TFMesorregiaoID), 9, 0));
         AV47TFMesorregiaoID_To = 0;
         AssignAttri("", false, "AV47TFMesorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV47TFMesorregiaoID_To), 9, 0));
         AV44TFMesorregiaoNome = "";
         AssignAttri("", false, "AV44TFMesorregiaoNome", AV44TFMesorregiaoNome);
         AV45TFMesorregiaoNome_Sel = "";
         AssignAttri("", false, "AV45TFMesorregiaoNome_Sel", AV45TFMesorregiaoNome_Sel);
         AV48TFMesorregiaoUFSigla = "";
         AssignAttri("", false, "AV48TFMesorregiaoUFSigla", AV48TFMesorregiaoUFSigla);
         AV49TFMesorregiaoUFSigla_Sel = "";
         AssignAttri("", false, "AV49TFMesorregiaoUFSigla_Sel", AV49TFMesorregiaoUFSigla_Sel);
         AV50TFMesorregiaoUFRegNome = "";
         AssignAttri("", false, "AV50TFMesorregiaoUFRegNome", AV50TFMesorregiaoUFRegNome);
         AV51TFMesorregiaoUFRegNome_Sel = "";
         AssignAttri("", false, "AV51TFMesorregiaoUFRegNome_Sel", AV51TFMesorregiaoUFRegNome_Sel);
         Ddo_grid_Selectedvalue_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         Ddo_grid_Filteredtext_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = "";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S132( )
      {
         /* 'LOADGRIDSTATE' Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(AV40Session.Get(AV63Pgmname+"GridState"), "") == 0 )
         {
            AV11GridState.FromXml(new GeneXus.Programs.wwpbaseobjects.loadgridstate(context).executeUdp(  AV63Pgmname+"GridState"), null, "", "");
         }
         else
         {
            AV11GridState.FromXml(AV40Session.Get(AV63Pgmname+"GridState"), null, "", "");
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
         AV73GXV1 = 1;
         while ( AV73GXV1 <= AV11GridState.gxTpr_Filtervalues.Count )
         {
            AV12GridStateFilterValue = ((GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue)AV11GridState.gxTpr_Filtervalues.Item(AV73GXV1));
            if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "FILTERFULLTEXT") == 0 )
            {
               AV17FilterFullText = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV17FilterFullText", AV17FilterFullText);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOID") == 0 )
            {
               AV46TFMesorregiaoID = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Value, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV46TFMesorregiaoID", StringUtil.LTrimStr( (decimal)(AV46TFMesorregiaoID), 9, 0));
               AV47TFMesorregiaoID_To = (int)(Math.Round(NumberUtil.Val( AV12GridStateFilterValue.gxTpr_Valueto, "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV47TFMesorregiaoID_To", StringUtil.LTrimStr( (decimal)(AV47TFMesorregiaoID_To), 9, 0));
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME") == 0 )
            {
               AV44TFMesorregiaoNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV44TFMesorregiaoNome", AV44TFMesorregiaoNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAONOME_SEL") == 0 )
            {
               AV45TFMesorregiaoNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV45TFMesorregiaoNome_Sel", AV45TFMesorregiaoNome_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA") == 0 )
            {
               AV48TFMesorregiaoUFSigla = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV48TFMesorregiaoUFSigla", AV48TFMesorregiaoUFSigla);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFSIGLA_SEL") == 0 )
            {
               AV49TFMesorregiaoUFSigla_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV49TFMesorregiaoUFSigla_Sel", AV49TFMesorregiaoUFSigla_Sel);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME") == 0 )
            {
               AV50TFMesorregiaoUFRegNome = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV50TFMesorregiaoUFRegNome", AV50TFMesorregiaoUFRegNome);
            }
            else if ( StringUtil.StrCmp(AV12GridStateFilterValue.gxTpr_Name, "TFMESORREGIAOUFREGNOME_SEL") == 0 )
            {
               AV51TFMesorregiaoUFRegNome_Sel = AV12GridStateFilterValue.gxTpr_Value;
               AssignAttri("", false, "AV51TFMesorregiaoUFRegNome_Sel", AV51TFMesorregiaoUFRegNome_Sel);
            }
            AV73GXV1 = (int)(AV73GXV1+1);
         }
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV45TFMesorregiaoNome_Sel)),  AV45TFMesorregiaoNome_Sel, out  GXt_char3) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMesorregiaoUFSigla_Sel)),  AV49TFMesorregiaoUFSigla_Sel, out  GXt_char5) ;
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMesorregiaoUFRegNome_Sel)),  AV51TFMesorregiaoUFRegNome_Sel, out  GXt_char6) ;
         Ddo_grid_Selectedvalue_set = "|"+GXt_char3+"|"+GXt_char5+"|"+GXt_char6;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "SelectedValue_set", Ddo_grid_Selectedvalue_set);
         GXt_char6 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMesorregiaoNome)),  AV44TFMesorregiaoNome, out  GXt_char6) ;
         GXt_char5 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV48TFMesorregiaoUFSigla)),  AV48TFMesorregiaoUFSigla, out  GXt_char5) ;
         GXt_char3 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getfilterval(context ).execute(  String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMesorregiaoUFRegNome)),  AV50TFMesorregiaoUFRegNome, out  GXt_char3) ;
         Ddo_grid_Filteredtext_set = ((0==AV46TFMesorregiaoID) ? "" : StringUtil.Str( (decimal)(AV46TFMesorregiaoID), 9, 0))+"|"+GXt_char6+"|"+GXt_char5+"|"+GXt_char3;
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredText_set", Ddo_grid_Filteredtext_set);
         Ddo_grid_Filteredtextto_set = ((0==AV47TFMesorregiaoID_To) ? "" : StringUtil.Str( (decimal)(AV47TFMesorregiaoID_To), 9, 0))+"|||";
         ucDdo_grid.SendProperty(context, "", false, Ddo_grid_Internalname, "FilteredTextTo_set", Ddo_grid_Filteredtextto_set);
      }

      protected void S162( )
      {
         /* 'SAVEGRIDSTATE' Routine */
         returnInSub = false;
         AV11GridState.FromXml(AV40Session.Get(AV63Pgmname+"GridState"), null, "", "");
         AV11GridState.gxTpr_Orderedby = AV14OrderedBy;
         AV11GridState.gxTpr_Ordereddsc = AV15OrderedDsc;
         AV11GridState.gxTpr_Filtervalues.Clear();
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "FILTERFULLTEXT",  "Filtro principal",  !String.IsNullOrEmpty(StringUtil.RTrim( AV17FilterFullText)),  0,  AV17FilterFullText,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalue(context ).execute( ref  AV11GridState,  "TFMESORREGIAOID",  "ID",  !((0==AV46TFMesorregiaoID)&&(0==AV47TFMesorregiaoID_To)),  0,  StringUtil.Trim( StringUtil.Str( (decimal)(AV46TFMesorregiaoID), 9, 0)),  StringUtil.Trim( StringUtil.Str( (decimal)(AV47TFMesorregiaoID_To), 9, 0))) ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMESORREGIAONOME",  "Nome",  !String.IsNullOrEmpty(StringUtil.RTrim( AV44TFMesorregiaoNome)),  0,  AV44TFMesorregiaoNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV45TFMesorregiaoNome_Sel)),  AV45TFMesorregiaoNome_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMESORREGIAOUFSIGLA",  "UF",  !String.IsNullOrEmpty(StringUtil.RTrim( AV48TFMesorregiaoUFSigla)),  0,  AV48TFMesorregiaoUFSigla,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV49TFMesorregiaoUFSigla_Sel)),  AV49TFMesorregiaoUFSigla_Sel,  "") ;
         new GeneXus.Programs.wwpbaseobjects.wwp_gridstateaddfiltervalueandsel(context ).execute( ref  AV11GridState,  "TFMESORREGIAOUFREGNOME",  "Região",  !String.IsNullOrEmpty(StringUtil.RTrim( AV50TFMesorregiaoUFRegNome)),  0,  AV50TFMesorregiaoUFRegNome,  "",  !String.IsNullOrEmpty(StringUtil.RTrim( AV51TFMesorregiaoUFRegNome_Sel)),  AV51TFMesorregiaoUFRegNome_Sel,  "") ;
         AV11GridState.gxTpr_Pagesize = StringUtil.Str( (decimal)(subGrid_Rows), 10, 0);
         AV11GridState.gxTpr_Currentpage = (short)(subGrid_fnc_Currentpage( ));
         new GeneXus.Programs.wwpbaseobjects.savegridstate(context ).execute(  AV63Pgmname+"GridState",  AV11GridState.ToXml(false, true, "", "")) ;
      }

      protected void S122( )
      {
         /* 'PREPARETRANSACTION' Routine */
         returnInSub = false;
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV9TrnContext.gxTpr_Callerobject = AV63Pgmname;
         AV9TrnContext.gxTpr_Callerondelete = true;
         AV9TrnContext.gxTpr_Callerurl = AV8HTTPRequest.ScriptName+"?"+AV8HTTPRequest.QueryString;
         AV9TrnContext.gxTpr_Transactionname = "core.mesorregiao";
         AV40Session.Set("TrnContext", AV9TrnContext.ToXml(false, true, "", ""));
      }

      protected void S202( )
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
         new GeneXus.Programs.core.mesorregiaowwexport(context ).execute( out  AV34ExcelFilename, out  AV35ErrorMessage) ;
         if ( StringUtil.StrCmp(AV34ExcelFilename, "") != 0 )
         {
            CallWebObject(formatLink(AV34ExcelFilename) );
            context.wjLocDisableFrm = 0;
         }
         else
         {
            GX_msglist.addItem(AV35ErrorMessage);
         }
      }

      protected void wb_table1_23_4E2( bool wbgen )
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
            ucDdo_managefilters.SetProperty("DropDownOptionsData", AV41ManageFiltersData);
            ucDdo_managefilters.Render(context, "dvelop.gxbootstrap.ddoregular", Ddo_managefilters_Internalname, "DDO_MANAGEFILTERSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "<td>") ;
            wb_table2_28_4E2( true) ;
         }
         else
         {
            wb_table2_28_4E2( false) ;
         }
         return  ;
      }

      protected void wb_table2_28_4E2e( bool wbgen )
      {
         if ( wbgen )
         {
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_4E2e( true) ;
         }
         else
         {
            wb_table1_23_4E2e( false) ;
         }
      }

      protected void wb_table2_28_4E2( bool wbgen )
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'" + sGXsfl_41_idx + "',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavFilterfulltext_Internalname, AV17FilterFullText, StringUtil.RTrim( context.localUtil.Format( AV17FilterFullText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "Pesquisar", edtavFilterfulltext_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtavFilterfulltext_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPFullTextFilter", "start", true, "", "HLP_core\\mesorregiaoWW.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_28_4E2e( true) ;
         }
         else
         {
            wb_table2_28_4E2e( false) ;
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
         PA4E2( ) ;
         WS4E2( ) ;
         WE4E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828224322", true, true);
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
         context.AddJavascriptSource("core/mesorregiaoww.js", "?2023828224324", false, true);
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtMesorregiaoID_Internalname = "MESORREGIAOID_"+sGXsfl_41_idx;
         edtMesorregiaoNome_Internalname = "MESORREGIAONOME_"+sGXsfl_41_idx;
         edtMesorregiaoUFSigla_Internalname = "MESORREGIAOUFSIGLA_"+sGXsfl_41_idx;
         edtMesorregiaoUFRegNome_Internalname = "MESORREGIAOUFREGNOME_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtMesorregiaoID_Internalname = "MESORREGIAOID_"+sGXsfl_41_fel_idx;
         edtMesorregiaoNome_Internalname = "MESORREGIAONOME_"+sGXsfl_41_fel_idx;
         edtMesorregiaoUFSigla_Internalname = "MESORREGIAOUFSIGLA_"+sGXsfl_41_fel_idx;
         edtMesorregiaoUFRegNome_Internalname = "MESORREGIAOUFREGNOME_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB4E0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+((edtMesorregiaoID_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMesorregiaoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MesorregiaoID), 11, 0, ",", "")),StringUtil.LTrim( context.localUtil.Format( (decimal)(A13MesorregiaoID), "ZZZ,ZZZ,ZZ9")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMesorregiaoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMesorregiaoID_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMesorregiaoNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMesorregiaoNome_Internalname,(string)A14MesorregiaoNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMesorregiaoNome_Link,(string)"",(string)"",(string)"",(string)edtMesorregiaoNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMesorregiaoNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMesorregiaoUFSigla_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMesorregiaoUFSigla_Internalname,(string)A16MesorregiaoUFSigla,StringUtil.RTrim( context.localUtil.Format( A16MesorregiaoUFSigla, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)edtMesorregiaoUFSigla_Link,(string)"",(string)"",(string)"",(string)edtMesorregiaoUFSigla_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMesorregiaoUFSigla_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)2,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+((edtMesorregiaoUFRegNome_Visible==0) ? "display:none;" : "")+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtMesorregiaoUFRegNome_Internalname,(string)A21MesorregiaoUFRegNome,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtMesorregiaoUFRegNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(int)edtMesorregiaoUFRegNome_Visible,(short)0,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)50,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            send_integrity_lvl_hashes4E2( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_41_idx = ((subGrid_Islastpage==1)&&(nGXsfl_41_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"41\">") ;
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
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMesorregiaoID_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "ID") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMesorregiaoNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Nome") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMesorregiaoUFSigla_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "UF") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+((edtMesorregiaoUFRegNome_Visible==0) ? "display:none;" : "")+""+"\" "+">") ;
            context.SendWebValue( "Região") ;
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
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A13MesorregiaoID), 11, 0, ".", ""))));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMesorregiaoID_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A14MesorregiaoNome));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMesorregiaoNome_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMesorregiaoNome_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A16MesorregiaoUFSigla));
            GridColumn.AddObjectProperty("Link", StringUtil.RTrim( edtMesorregiaoUFSigla_Link));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMesorregiaoUFSigla_Visible), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A21MesorregiaoUFRegNome));
            GridColumn.AddObjectProperty("Visible", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtMesorregiaoUFRegNome_Visible), 5, 0, ".", "")));
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
         bttBtnagexport_Internalname = "BTNAGEXPORT";
         bttBtneditcolumns_Internalname = "BTNEDITCOLUMNS";
         bttBtnsubscriptions_Internalname = "BTNSUBSCRIPTIONS";
         divTableactions_Internalname = "TABLEACTIONS";
         Ddo_managefilters_Internalname = "DDO_MANAGEFILTERS";
         edtavFilterfulltext_Internalname = "vFILTERFULLTEXT";
         tblTablefilters_Internalname = "TABLEFILTERS";
         tblTablerightheader_Internalname = "TABLERIGHTHEADER";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         edtMesorregiaoID_Internalname = "MESORREGIAOID";
         edtMesorregiaoNome_Internalname = "MESORREGIAONOME";
         edtMesorregiaoUFSigla_Internalname = "MESORREGIAOUFSIGLA";
         edtMesorregiaoUFRegNome_Internalname = "MESORREGIAOUFREGNOME";
         Gridpaginationbar_Internalname = "GRIDPAGINATIONBAR";
         divGridtablewithpaginationbar_Internalname = "GRIDTABLEWITHPAGINATIONBAR";
         divTablemain_Internalname = "TABLEMAIN";
         Ddo_agexport_Internalname = "DDO_AGEXPORT";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddo_grid_Internalname = "DDO_GRID";
         Ddo_gridcolumnsselector_Internalname = "DDO_GRIDCOLUMNSSELECTOR";
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
         edtMesorregiaoUFRegNome_Jsonclick = "";
         edtMesorregiaoUFSigla_Jsonclick = "";
         edtMesorregiaoUFSigla_Link = "";
         edtMesorregiaoNome_Jsonclick = "";
         edtMesorregiaoNome_Link = "";
         edtMesorregiaoID_Jsonclick = "";
         subGrid_Class = "GridWithPaginationBar WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavFilterfulltext_Jsonclick = "";
         edtavFilterfulltext_Enabled = 1;
         edtMesorregiaoUFRegNome_Visible = -1;
         edtMesorregiaoUFSigla_Visible = -1;
         edtMesorregiaoNome_Visible = -1;
         edtMesorregiaoID_Visible = -1;
         subGrid_Sortable = 0;
         bttBtnsubscriptions_Visible = 1;
         Grid_empowerer_Hascolumnsselector = Convert.ToBoolean( -1);
         Grid_empowerer_Hastitlesettings = Convert.ToBoolean( -1);
         Ddo_gridcolumnsselector_Titlecontrolidtoreplace = "";
         Ddo_gridcolumnsselector_Dropdownoptionstype = "GridColumnsSelector";
         Ddo_gridcolumnsselector_Cls = "ColumnsSelector hidden-xs";
         Ddo_gridcolumnsselector_Tooltip = "WWP_EditColumnsTooltip";
         Ddo_gridcolumnsselector_Caption = "Selecionar colunas";
         Ddo_gridcolumnsselector_Icon = "fas fa-cog";
         Ddo_gridcolumnsselector_Icontype = "FontIcon";
         Ddo_grid_Format = "9.0|||";
         Ddo_grid_Datalistproc = "core.mesorregiaoWWGetFilterData";
         Ddo_grid_Datalisttype = "|Dynamic|Dynamic|Dynamic";
         Ddo_grid_Includedatalist = "|T|T|T";
         Ddo_grid_Filterisrange = "T|||";
         Ddo_grid_Filtertype = "Numeric|Character|Character|Character";
         Ddo_grid_Includefilter = "T";
         Ddo_grid_Fixable = "T";
         Ddo_grid_Includesortasc = "T";
         Ddo_grid_Columnssortvalues = "2|1|3|4";
         Ddo_grid_Columnids = "0:MesorregiaoID|1:MesorregiaoNome|2:MesorregiaoUFSigla|3:MesorregiaoUFRegNome";
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
         Form.Caption = " Mesorregiões";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMesorregiaoID_Visible',ctrl:'MESORREGIAOID',prop:'Visible'},{av:'edtMesorregiaoNome_Visible',ctrl:'MESORREGIAONOME',prop:'Visible'},{av:'edtMesorregiaoUFSigla_Visible',ctrl:'MESORREGIAOUFSIGLA',prop:'Visible'},{av:'edtMesorregiaoUFRegNome_Visible',ctrl:'MESORREGIAOUFREGNOME',prop:'Visible'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE","{handler:'E124E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Gridpaginationbar_Selectedpage',ctrl:'GRIDPAGINATIONBAR',prop:'SelectedPage'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEPAGE",",oparms:[]}");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE","{handler:'E134E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Gridpaginationbar_Rowsperpageselectedvalue',ctrl:'GRIDPAGINATIONBAR',prop:'RowsPerPageSelectedValue'}]");
         setEventMetadata("GRIDPAGINATIONBAR.CHANGEROWSPERPAGE",",oparms:[{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'}]}");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED","{handler:'E164E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Ddo_grid_Activeeventkey',ctrl:'DDO_GRID',prop:'ActiveEventKey'},{av:'Ddo_grid_Selectedvalue_get',ctrl:'DDO_GRID',prop:'SelectedValue_get'},{av:'Ddo_grid_Selectedcolumn',ctrl:'DDO_GRID',prop:'SelectedColumn'},{av:'Ddo_grid_Filteredtext_get',ctrl:'DDO_GRID',prop:'FilteredText_get'},{av:'Ddo_grid_Filteredtextto_get',ctrl:'DDO_GRID',prop:'FilteredTextTo_get'}]");
         setEventMetadata("DDO_GRID.ONOPTIONCLICKED",",oparms:[{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E204E2',iparms:[{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'A13MesorregiaoID',fld:'MESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'A15MesorregiaoUFID',fld:'MESORREGIAOUFID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("GRID.LOAD",",oparms:[{av:'edtMesorregiaoNome_Link',ctrl:'MESORREGIAONOME',prop:'Link'},{av:'edtMesorregiaoUFSigla_Link',ctrl:'MESORREGIAOUFSIGLA',prop:'Link'}]}");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED","{handler:'E174E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Ddo_gridcolumnsselector_Columnsselectorvalues',ctrl:'DDO_GRIDCOLUMNSSELECTOR',prop:'ColumnsSelectorValues'}]");
         setEventMetadata("DDO_GRIDCOLUMNSSELECTOR.ONCOLUMNSCHANGED",",oparms:[{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'edtMesorregiaoID_Visible',ctrl:'MESORREGIAOID',prop:'Visible'},{av:'edtMesorregiaoNome_Visible',ctrl:'MESORREGIAONOME',prop:'Visible'},{av:'edtMesorregiaoUFSigla_Visible',ctrl:'MESORREGIAOUFSIGLA',prop:'Visible'},{av:'edtMesorregiaoUFRegNome_Visible',ctrl:'MESORREGIAOUFREGNOME',prop:'Visible'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]}");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED","{handler:'E114E2',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Ddo_managefilters_Activeeventkey',ctrl:'DDO_MANAGEFILTERS',prop:'ActiveEventKey'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''}]");
         setEventMetadata("DDO_MANAGEFILTERS.ONOPTIONCLICKED",",oparms:[{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'edtMesorregiaoID_Visible',ctrl:'MESORREGIAOID',prop:'Visible'},{av:'edtMesorregiaoNome_Visible',ctrl:'MESORREGIAONOME',prop:'Visible'},{av:'edtMesorregiaoUFSigla_Visible',ctrl:'MESORREGIAOUFSIGLA',prop:'Visible'},{av:'edtMesorregiaoUFRegNome_Visible',ctrl:'MESORREGIAOUFREGNOME',prop:'Visible'},{av:'AV56GridCurrentPage',fld:'vGRIDCURRENTPAGE',pic:'ZZZZZZZZZ9'},{av:'AV57GridPageCount',fld:'vGRIDPAGECOUNT',pic:'ZZZZZZZZZ9'},{av:'AV58GridAppliedFilters',fld:'vGRIDAPPLIEDFILTERS',pic:''},{ctrl:'BTNSUBSCRIPTIONS',prop:'Visible'},{av:'AV41ManageFiltersData',fld:'vMANAGEFILTERSDATA',pic:''}]}");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED","{handler:'E144E2',iparms:[{av:'Ddo_agexport_Activeeventkey',ctrl:'DDO_AGEXPORT',prop:'ActiveEventKey'},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("DDO_AGEXPORT.ONOPTIONCLICKED",",oparms:[{av:'AV11GridState',fld:'vGRIDSTATE',pic:''},{av:'AV14OrderedBy',fld:'vORDEREDBY',pic:'ZZZ9'},{av:'AV15OrderedDsc',fld:'vORDEREDDSC',pic:''},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'AV17FilterFullText',fld:'vFILTERFULLTEXT',pic:''},{av:'AV43ManageFiltersExecutionStep',fld:'vMANAGEFILTERSEXECUTIONSTEP',pic:'9'},{av:'AV38ColumnsSelector',fld:'vCOLUMNSSELECTOR',pic:''},{av:'AV63Pgmname',fld:'vPGMNAME',pic:'',hsh:true},{av:'AV46TFMesorregiaoID',fld:'vTFMESORREGIAOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV47TFMesorregiaoID_To',fld:'vTFMESORREGIAOID_TO',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV44TFMesorregiaoNome',fld:'vTFMESORREGIAONOME',pic:''},{av:'AV45TFMesorregiaoNome_Sel',fld:'vTFMESORREGIAONOME_SEL',pic:''},{av:'AV48TFMesorregiaoUFSigla',fld:'vTFMESORREGIAOUFSIGLA',pic:'@!'},{av:'AV49TFMesorregiaoUFSigla_Sel',fld:'vTFMESORREGIAOUFSIGLA_SEL',pic:'@!'},{av:'AV50TFMesorregiaoUFRegNome',fld:'vTFMESORREGIAOUFREGNOME',pic:''},{av:'AV51TFMesorregiaoUFRegNome_Sel',fld:'vTFMESORREGIAOUFREGNOME_SEL',pic:''},{av:'AV62IsAuthorized_MesorregiaoNome',fld:'vISAUTHORIZED_MESORREGIAONOME',pic:'',hsh:true},{av:'AV59IsAuthorized_MesorregiaoUFSigla',fld:'vISAUTHORIZED_MESORREGIAOUFSIGLA',pic:'',hsh:true},{av:'Ddo_grid_Sortedstatus',ctrl:'DDO_GRID',prop:'SortedStatus'},{av:'Ddo_grid_Selectedvalue_set',ctrl:'DDO_GRID',prop:'SelectedValue_set'},{av:'Ddo_grid_Filteredtext_set',ctrl:'DDO_GRID',prop:'FilteredText_set'},{av:'Ddo_grid_Filteredtextto_set',ctrl:'DDO_GRID',prop:'FilteredTextTo_set'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E154E2',iparms:[]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("NULL","{handler:'Valid_Mesorregiaoufregnome',iparms:[]");
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
         Ddo_agexport_Activeeventkey = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV17FilterFullText = "";
         AV38ColumnsSelector = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         AV63Pgmname = "";
         AV44TFMesorregiaoNome = "";
         AV45TFMesorregiaoNome_Sel = "";
         AV48TFMesorregiaoUFSigla = "";
         AV49TFMesorregiaoUFSigla_Sel = "";
         AV50TFMesorregiaoUFRegNome = "";
         AV51TFMesorregiaoUFRegNome_Sel = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV41ManageFiltersData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV58GridAppliedFilters = "";
         AV60AGExportData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV52DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV11GridState = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState(context);
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
         bttBtnagexport_Jsonclick = "";
         bttBtneditcolumns_Jsonclick = "";
         bttBtnsubscriptions_Jsonclick = "";
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
         A14MesorregiaoNome = "";
         A16MesorregiaoUFSigla = "";
         A21MesorregiaoUFRegNome = "";
         scmdbuf = "";
         lV64Core_mesorregiaowwds_1_filterfulltext = "";
         lV67Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         AV64Core_mesorregiaowwds_1_filterfulltext = "";
         AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel = "";
         AV67Core_mesorregiaowwds_4_tfmesorregiaonome = "";
         AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel = "";
         AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla = "";
         AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel = "";
         AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome = "";
         H004E2_A15MesorregiaoUFID = new int[1] ;
         H004E2_A21MesorregiaoUFRegNome = new string[] {""} ;
         H004E2_n21MesorregiaoUFRegNome = new bool[] {false} ;
         H004E2_A16MesorregiaoUFSigla = new string[] {""} ;
         H004E2_A14MesorregiaoNome = new string[] {""} ;
         H004E2_A13MesorregiaoID = new int[1] ;
         H004E3_AGRID_nRecordCount = new long[1] ;
         AV8HTTPRequest = new GxHttpRequest( context);
         AV61AGExportDataItem = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item(context);
         AV53GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV54GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV40Session = context.GetSession();
         AV36ColumnsSelectorXML = "";
         GXEncryptionTmp = "";
         GridRow = new GXWebRow();
         AV42ManageFiltersXml = "";
         AV37UserCustomValue = "";
         AV39ColumnsSelectorAux = new GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector(context);
         GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item>( context, "Item", "");
         AV12GridStateFilterValue = new GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue(context);
         GXt_char6 = "";
         GXt_char5 = "";
         GXt_char3 = "";
         AV9TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV34ExcelFilename = "";
         AV35ErrorMessage = "";
         ucDdo_managefilters = new GXUserControl();
         Ddo_managefilters_Caption = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGrid_Linesclass = "";
         ROClassString = "";
         GridColumn = new GXWebColumn();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.mesorregiaoww__default(),
            new Object[][] {
                new Object[] {
               H004E2_A15MesorregiaoUFID, H004E2_A21MesorregiaoUFRegNome, H004E2_n21MesorregiaoUFRegNome, H004E2_A16MesorregiaoUFSigla, H004E2_A14MesorregiaoNome, H004E2_A13MesorregiaoID
               }
               , new Object[] {
               H004E3_AGRID_nRecordCount
               }
            }
         );
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         AV63Pgmname = "core.mesorregiaoWW";
         /* GeneXus formulas. */
         AV63Pgmname = "core.mesorregiaoWW";
      }

      private short GRID_nEOF ;
      private short nGotPars ;
      private short GxWebError ;
      private short AV43ManageFiltersExecutionStep ;
      private short AV14OrderedBy ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGrid_Backcolorstyle ;
      private short subGrid_Sortable ;
      private short nGXWrapped ;
      private short subGrid_Backstyle ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int subGrid_Rows ;
      private int Gridpaginationbar_Rowsperpageselectedvalue ;
      private int nRC_GXsfl_41 ;
      private int nGXsfl_41_idx=1 ;
      private int AV46TFMesorregiaoID ;
      private int AV47TFMesorregiaoID_To ;
      private int A15MesorregiaoUFID ;
      private int Gridpaginationbar_Pagestoshow ;
      private int bttBtnsubscriptions_Visible ;
      private int A13MesorregiaoID ;
      private int subGrid_Islastpage ;
      private int GXPagingFrom2 ;
      private int GXPagingTo2 ;
      private int AV65Core_mesorregiaowwds_2_tfmesorregiaoid ;
      private int AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to ;
      private int edtMesorregiaoID_Visible ;
      private int edtMesorregiaoNome_Visible ;
      private int edtMesorregiaoUFSigla_Visible ;
      private int edtMesorregiaoUFRegNome_Visible ;
      private int AV55PageToGo ;
      private int AV73GXV1 ;
      private int edtavFilterfulltext_Enabled ;
      private int idxLst ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRID_nFirstRecordOnPage ;
      private long AV56GridCurrentPage ;
      private long AV57GridPageCount ;
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
      private string Ddo_agexport_Activeeventkey ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string AV63Pgmname ;
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
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string TempTags ;
      private string ClassString ;
      private string StyleString ;
      private string bttBtnagexport_Internalname ;
      private string bttBtnagexport_Jsonclick ;
      private string bttBtneditcolumns_Internalname ;
      private string bttBtneditcolumns_Jsonclick ;
      private string bttBtnsubscriptions_Internalname ;
      private string bttBtnsubscriptions_Jsonclick ;
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
      private string edtMesorregiaoID_Internalname ;
      private string edtMesorregiaoNome_Internalname ;
      private string edtMesorregiaoUFSigla_Internalname ;
      private string edtMesorregiaoUFRegNome_Internalname ;
      private string edtavFilterfulltext_Internalname ;
      private string scmdbuf ;
      private string edtMesorregiaoNome_Link ;
      private string GXEncryptionTmp ;
      private string edtMesorregiaoUFSigla_Link ;
      private string GXt_char6 ;
      private string GXt_char5 ;
      private string GXt_char3 ;
      private string tblTablerightheader_Internalname ;
      private string Ddo_managefilters_Caption ;
      private string Ddo_managefilters_Internalname ;
      private string tblTablefilters_Internalname ;
      private string edtavFilterfulltext_Jsonclick ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string ROClassString ;
      private string edtMesorregiaoID_Jsonclick ;
      private string edtMesorregiaoNome_Jsonclick ;
      private string edtMesorregiaoUFSigla_Jsonclick ;
      private string edtMesorregiaoUFRegNome_Jsonclick ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV15OrderedDsc ;
      private bool AV62IsAuthorized_MesorregiaoNome ;
      private bool AV59IsAuthorized_MesorregiaoUFSigla ;
      private bool Gridpaginationbar_Showfirst ;
      private bool Gridpaginationbar_Showprevious ;
      private bool Gridpaginationbar_Shownext ;
      private bool Gridpaginationbar_Showlast ;
      private bool Gridpaginationbar_Rowsperpageselector ;
      private bool Grid_empowerer_Hastitlesettings ;
      private bool Grid_empowerer_Hascolumnsselector ;
      private bool wbLoad ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool n21MesorregiaoUFRegNome ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool GXt_boolean1 ;
      private bool gx_refresh_fired ;
      private bool bDynCreated_Wwpaux_wc ;
      private string AV36ColumnsSelectorXML ;
      private string AV42ManageFiltersXml ;
      private string AV37UserCustomValue ;
      private string AV17FilterFullText ;
      private string AV44TFMesorregiaoNome ;
      private string AV45TFMesorregiaoNome_Sel ;
      private string AV48TFMesorregiaoUFSigla ;
      private string AV49TFMesorregiaoUFSigla_Sel ;
      private string AV50TFMesorregiaoUFRegNome ;
      private string AV51TFMesorregiaoUFRegNome_Sel ;
      private string AV58GridAppliedFilters ;
      private string A14MesorregiaoNome ;
      private string A16MesorregiaoUFSigla ;
      private string A21MesorregiaoUFRegNome ;
      private string lV64Core_mesorregiaowwds_1_filterfulltext ;
      private string lV67Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string AV64Core_mesorregiaowwds_1_filterfulltext ;
      private string AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel ;
      private string AV67Core_mesorregiaowwds_4_tfmesorregiaonome ;
      private string AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ;
      private string AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ;
      private string AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ;
      private string AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ;
      private string AV34ExcelFilename ;
      private string AV35ErrorMessage ;
      private IGxSession AV40Session ;
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
      private GXUserControl ucDdo_managefilters ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] H004E2_A15MesorregiaoUFID ;
      private string[] H004E2_A21MesorregiaoUFRegNome ;
      private bool[] H004E2_n21MesorregiaoUFRegNome ;
      private string[] H004E2_A16MesorregiaoUFSigla ;
      private string[] H004E2_A14MesorregiaoNome ;
      private int[] H004E2_A13MesorregiaoID ;
      private long[] H004E3_AGRID_nRecordCount ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GxHttpRequest AV8HTTPRequest ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV41ManageFiltersData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> AV60AGExportData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item> GXt_objcol_SdtDVB_SDTDropDownOptionsData_Item4 ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV54GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV9TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState AV11GridState ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPGridState_FilterValue AV12GridStateFilterValue ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV38ColumnsSelector ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPColumnsSelector AV39ColumnsSelectorAux ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsData_Item AV61AGExportDataItem ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV52DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons2 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV53GAMSession ;
   }

   public class mesorregiaoww__default : DataStoreHelperBase, IDataStoreHelper
   {
      protected Object[] conditional_H004E2( IGxContext context ,
                                             string AV64Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV65Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV67Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int7 = new short[15];
         Object[] GXv_Object8 = new Object[2];
         string sSelectString;
         string sFromString;
         string sOrderString;
         sSelectString = " MesorregiaoUFID, MesorregiaoUFRegNome, MesorregiaoUFSigla, MesorregiaoNome, MesorregiaoID";
         sFromString = " FROM tbibge_mesorregiao";
         sOrderString = "";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int7[0] = 1;
            GXv_int7[1] = 1;
            GXv_int7[2] = 1;
            GXv_int7[3] = 1;
         }
         if ( ! (0==AV65Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV65Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int7[4] = 1;
         }
         if ( ! (0==AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int7[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV67Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int7[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int7[7] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int7[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int7[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int7[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int7[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
         }
         if ( ( AV14OrderedBy == 1 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY MesorregiaoNome, MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 1 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY MesorregiaoNome DESC, MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 2 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY MesorregiaoID DESC";
         }
         else if ( ( AV14OrderedBy == 3 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY MesorregiaoUFSigla, MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 3 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY MesorregiaoUFSigla DESC, MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ! AV15OrderedDsc )
         {
            sOrderString += " ORDER BY MesorregiaoUFRegNome, MesorregiaoID";
         }
         else if ( ( AV14OrderedBy == 4 ) && ( AV15OrderedDsc ) )
         {
            sOrderString += " ORDER BY MesorregiaoUFRegNome DESC, MesorregiaoID";
         }
         else if ( true )
         {
            sOrderString += " ORDER BY MesorregiaoID";
         }
         scmdbuf = "SELECT " + sSelectString + sFromString + sWhereString + sOrderString + "" + " OFFSET " + ":GXPagingFrom2" + " LIMIT CASE WHEN " + ":GXPagingTo2" + " > 0 THEN " + ":GXPagingTo2" + " ELSE 1e9 END";
         GXv_Object8[0] = scmdbuf;
         GXv_Object8[1] = GXv_int7;
         return GXv_Object8 ;
      }

      protected Object[] conditional_H004E3( IGxContext context ,
                                             string AV64Core_mesorregiaowwds_1_filterfulltext ,
                                             int AV65Core_mesorregiaowwds_2_tfmesorregiaoid ,
                                             int AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to ,
                                             string AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel ,
                                             string AV67Core_mesorregiaowwds_4_tfmesorregiaonome ,
                                             string AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel ,
                                             string AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla ,
                                             string AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel ,
                                             string AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome ,
                                             int A13MesorregiaoID ,
                                             string A14MesorregiaoNome ,
                                             string A16MesorregiaoUFSigla ,
                                             string A21MesorregiaoUFRegNome ,
                                             short AV14OrderedBy ,
                                             bool AV15OrderedDsc )
      {
         System.Text.StringBuilder sWhereString = new System.Text.StringBuilder();
         string scmdbuf;
         short[] GXv_int9 = new short[12];
         Object[] GXv_Object10 = new Object[2];
         scmdbuf = "SELECT COUNT(*) FROM tbibge_mesorregiao";
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV64Core_mesorregiaowwds_1_filterfulltext)) )
         {
            AddWhere(sWhereString, "(( SUBSTR(TO_CHAR(MesorregiaoID,'999999999'), 2) like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoNome like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFSigla like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext) or ( MesorregiaoUFRegNome like '%' || :lV64Core_mesorregiaowwds_1_filterfulltext))");
         }
         else
         {
            GXv_int9[0] = 1;
            GXv_int9[1] = 1;
            GXv_int9[2] = 1;
            GXv_int9[3] = 1;
         }
         if ( ! (0==AV65Core_mesorregiaowwds_2_tfmesorregiaoid) )
         {
            AddWhere(sWhereString, "(MesorregiaoID >= :AV65Core_mesorregiaowwds_2_tfmesorregiaoid)");
         }
         else
         {
            GXv_int9[4] = 1;
         }
         if ( ! (0==AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to) )
         {
            AddWhere(sWhereString, "(MesorregiaoID <= :AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to)");
         }
         else
         {
            GXv_int9[5] = 1;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV67Core_mesorregiaowwds_4_tfmesorregiaonome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome like :lV67Core_mesorregiaowwds_4_tfmesorregiaonome)");
         }
         else
         {
            GXv_int9[6] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel)) && ! ( StringUtil.StrCmp(AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoNome = ( :AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel))");
         }
         else
         {
            GXv_int9[7] = 1;
         }
         if ( StringUtil.StrCmp(AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoNome))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla like :lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla)");
         }
         else
         {
            GXv_int9[8] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel)) && ! ( StringUtil.StrCmp(AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFSigla = ( :AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel))");
         }
         else
         {
            GXv_int9[9] = 1;
         }
         if ( StringUtil.StrCmp(AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFSigla))=0))");
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome)) ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome like :lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome)");
         }
         else
         {
            GXv_int9[10] = 1;
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel)) && ! ( StringUtil.StrCmp(AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 ) )
         {
            AddWhere(sWhereString, "(MesorregiaoUFRegNome = ( :AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel))");
         }
         else
         {
            GXv_int9[11] = 1;
         }
         if ( StringUtil.StrCmp(AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel, "<#Empty#>") == 0 )
         {
            AddWhere(sWhereString, "((char_length(trim(trailing ' ' from MesorregiaoUFRegNome))=0))");
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
                     return conditional_H004E2(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
               case 1 :
                     return conditional_H004E3(context, (string)dynConstraints[0] , (int)dynConstraints[1] , (int)dynConstraints[2] , (string)dynConstraints[3] , (string)dynConstraints[4] , (string)dynConstraints[5] , (string)dynConstraints[6] , (string)dynConstraints[7] , (string)dynConstraints[8] , (int)dynConstraints[9] , (string)dynConstraints[10] , (string)dynConstraints[11] , (string)dynConstraints[12] , (short)dynConstraints[13] , (bool)dynConstraints[14] );
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
          Object[] prmH004E2;
          prmH004E2 = new Object[] {
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV67Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0) ,
          new ParDef("GXPagingFrom2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0) ,
          new ParDef("GXPagingTo2",GXType.Int32,9,0)
          };
          Object[] prmH004E3;
          prmH004E3 = new Object[] {
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("lV64Core_mesorregiaowwds_1_filterfulltext",GXType.VarChar,100,0) ,
          new ParDef("AV65Core_mesorregiaowwds_2_tfmesorregiaoid",GXType.Int32,9,0) ,
          new ParDef("AV66Core_mesorregiaowwds_3_tfmesorregiaoid_to",GXType.Int32,9,0) ,
          new ParDef("lV67Core_mesorregiaowwds_4_tfmesorregiaonome",GXType.VarChar,80,0) ,
          new ParDef("AV68Core_mesorregiaowwds_5_tfmesorregiaonome_sel",GXType.VarChar,80,0) ,
          new ParDef("lV69Core_mesorregiaowwds_6_tfmesorregiaoufsigla",GXType.VarChar,2,0) ,
          new ParDef("AV70Core_mesorregiaowwds_7_tfmesorregiaoufsigla_sel",GXType.VarChar,2,0) ,
          new ParDef("lV71Core_mesorregiaowwds_8_tfmesorregiaoufregnome",GXType.VarChar,50,0) ,
          new ParDef("AV72Core_mesorregiaowwds_9_tfmesorregiaoufregnome_sel",GXType.VarChar,50,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004E2", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E2,11, GxCacheFrequency.OFF ,true,false )
             ,new CursorDef("H004E3", "scmdbuf",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004E3,1, GxCacheFrequency.OFF ,true,false )
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
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getVarchar(4);
                ((int[]) buf[5])[0] = rslt.getInt(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                return;
       }
    }

 }

}
