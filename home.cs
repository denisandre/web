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
using System.Xml.Serialization;
using System.Runtime.Serialization;
namespace GeneXus.Programs {
   public class home : GXDataArea
   {
      public home( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public home( IGxContext context )
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
         cmbavHomesampledata__productstatus = new GXCombobox();
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
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridnotitles") == 0 )
            {
               gxnrGridnotitles_newrow_invoke( ) ;
               return  ;
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxGridRefresh_"+"Gridnotitles") == 0 )
            {
               gxgrGridnotitles_refresh_invoke( ) ;
               return  ;
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

      protected void gxnrGridnotitles_newrow_invoke( )
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
         gxnrGridnotitles_newrow( ) ;
         /* End function gxnrGridnotitles_newrow_invoke */
      }

      protected void gxgrGridnotitles_refresh_invoke( )
      {
         subGridnotitles_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridnotitles_Rows"), "."), 18, MidpointRounding.ToEven));
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTNotificationsData);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeSampleData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         AddString( context.getJSONResponse( )) ;
         /* End function gxgrGridnotitles_refresh_invoke */
      }

      protected void gxnrGrid_newrow_invoke( )
      {
         nRC_GXsfl_62 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_62"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_62_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_62_idx = GetPar( "sGXsfl_62_idx");
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
         subGridnotitles_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGridnotitles_Rows"), "."), 18, MidpointRounding.ToEven));
         subGrid_Rows = (int)(Math.Round(NumberUtil.Val( GetPar( "subGrid_Rows"), "."), 18, MidpointRounding.ToEven));
         ajax_req_read_hidden_sdt(GetNextPar( ), AV5HomeSampleData);
         ajax_req_read_hidden_sdt(GetNextPar( ), AV7SDTNotificationsData);
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
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
            return "home_Execute" ;
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
         PA0S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0S2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
         context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = ((nGXWrapped==0) ? " data-HasEnter=\"false\" data-Skiponenter=\"false\"" : "");
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("home.aspx") +"\">") ;
            GxWebStd.gx_hidden_field( context, "_EventName", "");
            GxWebStd.gx_hidden_field( context, "_EventGridId", "");
            GxWebStd.gx_hidden_field( context, "_EventRowId", "");
            context.WriteHtmlText( "<div style=\"height:0;overflow:hidden\"><input type=\"submit\" title=\"submit\"  disabled></div>") ;
            AssignProp("", false, "FORM", "Class", "form-horizontal Form", true);
         }
         toggleJsOutput = isJsOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
      }

      protected void send_integrity_footer_hashes( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Sdtnotificationsdata", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Sdtnotificationsdata", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Homesampledata", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Homesampledata", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_Homesampledata", GetSecureSignedToken( "", AV5HomeSampleData, context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_41", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_41), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_62", StringUtil.LTrim( StringUtil.NToC( (decimal)(nRC_GXsfl_62), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vELEMENTS", AV20Elements);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vELEMENTS", AV20Elements);
         }
         GxWebStd.gx_hidden_field( context, "vPARAMETERS", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21Parameters), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMCLICKDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV22ItemClickData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMDOUBLECLICKDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV23ItemDoubleClickData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vDRAGANDDROPDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DragAndDropData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vFILTERCHANGEDDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV25FilterChangedData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMEXPANDDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV26ItemExpandData), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vITEMCOLLAPSEDATA", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV27ItemCollapseData), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Circlecaptiontype", StringUtil.RTrim( Progress1_progress_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Caption", StringUtil.RTrim( Progress1_progress_Caption));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Subtitle", StringUtil.RTrim( Progress1_progress_Subtitle));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Cls", StringUtil.RTrim( Progress1_progress_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress1_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS1_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress1_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Circlecaptiontype", StringUtil.RTrim( Progress2_progress_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Caption", StringUtil.RTrim( Progress2_progress_Caption));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Subtitle", StringUtil.RTrim( Progress2_progress_Subtitle));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Cls", StringUtil.RTrim( Progress2_progress_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress2_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS2_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress2_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Circlecaptiontype", StringUtil.RTrim( Progress3_progress_Circlecaptiontype));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Caption", StringUtil.RTrim( Progress3_progress_Caption));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Subtitle", StringUtil.RTrim( Progress3_progress_Subtitle));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Cls", StringUtil.RTrim( Progress3_progress_Cls));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Percentage", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress3_progress_Percentage), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PROGRESS3_PROGRESS_Circlewidth", StringUtil.LTrim( StringUtil.NToC( (decimal)(Progress3_progress_Circlewidth), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Class", StringUtil.RTrim( Utchartcolumnline_Class));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Height", StringUtil.RTrim( Utchartcolumnline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Type", StringUtil.RTrim( Utchartcolumnline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Charttype", StringUtil.RTrim( Utchartcolumnline_Charttype));
         GxWebStd.gx_hidden_field( context, "UTCHARTCOLUMNLINE_Plotseries", StringUtil.RTrim( Utchartcolumnline_Plotseries));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Width", StringUtil.RTrim( Dvpanel_tablecards_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablecards_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablecards_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Cls", StringUtil.RTrim( Dvpanel_tablecards_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Title", StringUtil.RTrim( Dvpanel_tablecards_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablecards_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablecards_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Iconposition", StringUtil.RTrim( Dvpanel_tablecards_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECARDS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablecards_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Width", StringUtil.RTrim( Dvpanel_tablenotifications_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autowidth", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoheight", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Cls", StringUtil.RTrim( Dvpanel_tablenotifications_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Title", StringUtil.RTrim( Dvpanel_tablenotifications_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsible", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Collapsed", StringUtil.BoolToStr( Dvpanel_tablenotifications_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablenotifications_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Iconposition", StringUtil.RTrim( Dvpanel_tablenotifications_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLENOTIFICATIONS_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablenotifications_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Type", StringUtil.RTrim( Utchartsmootharea_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHAREA_Charttype", StringUtil.RTrim( Utchartsmootharea_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Width", StringUtil.RTrim( Dvpanel_tablechart1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Cls", StringUtil.RTrim( Dvpanel_tablechart1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Title", StringUtil.RTrim( Dvpanel_tablechart1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Iconposition", StringUtil.RTrim( Dvpanel_tablechart1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART1_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Height", StringUtil.RTrim( Utchartsmoothline_Height));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Type", StringUtil.RTrim( Utchartsmoothline_Type));
         GxWebStd.gx_hidden_field( context, "UTCHARTSMOOTHLINE_Charttype", StringUtil.RTrim( Utchartsmoothline_Charttype));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Width", StringUtil.RTrim( Dvpanel_tablechart4_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autowidth", StringUtil.BoolToStr( Dvpanel_tablechart4_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoheight", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Cls", StringUtil.RTrim( Dvpanel_tablechart4_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Title", StringUtil.RTrim( Dvpanel_tablechart4_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsible", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Collapsed", StringUtil.BoolToStr( Dvpanel_tablechart4_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablechart4_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Iconposition", StringUtil.RTrim( Dvpanel_tablechart4_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLECHART4_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablechart4_Autoscroll));
         GxWebStd.gx_hidden_field( context, "GRID_EMPOWERER_Gridinternalname", StringUtil.RTrim( Grid_empowerer_Gridinternalname));
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_EMPOWERER_Gridinternalname", StringUtil.RTrim( Gridnotitles_empowerer_Gridinternalname));
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
         if ( nGXWrapped != 1 )
         {
            context.WriteHtmlTextNl( "</form>") ;
         }
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
            WE0S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0S2( ) ;
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
         return formatLink("home.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "Home" ;
      }

      public override string GetPgmdesc( )
      {
         return "Inicio" ;
      }

      protected void WB0S0( )
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
            GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, "", "", "", "false");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 HomeTopPanel", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablecards.SetProperty("Width", Dvpanel_tablecards_Width);
            ucDvpanel_tablecards.SetProperty("AutoWidth", Dvpanel_tablecards_Autowidth);
            ucDvpanel_tablecards.SetProperty("AutoHeight", Dvpanel_tablecards_Autoheight);
            ucDvpanel_tablecards.SetProperty("Cls", Dvpanel_tablecards_Cls);
            ucDvpanel_tablecards.SetProperty("Title", Dvpanel_tablecards_Title);
            ucDvpanel_tablecards.SetProperty("Collapsible", Dvpanel_tablecards_Collapsible);
            ucDvpanel_tablecards.SetProperty("Collapsed", Dvpanel_tablecards_Collapsed);
            ucDvpanel_tablecards.SetProperty("ShowCollapseIcon", Dvpanel_tablecards_Showcollapseicon);
            ucDvpanel_tablecards.SetProperty("IconPosition", Dvpanel_tablecards_Iconposition);
            ucDvpanel_tablecards.SetProperty("AutoScroll", Dvpanel_tablecards_Autoscroll);
            ucDvpanel_tablecards.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablecards_Internalname, "DVPANEL_TABLECARDSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECARDSContainer"+"TableCards"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecards_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop30", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableprogresscards_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "flex-wrap:wrap;align-content:space-between;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table1_15_0S2( true) ;
         }
         else
         {
            wb_table1_15_0S2( false) ;
         }
         return  ;
      }

      protected void wb_table1_15_0S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table2_20_0S2( true) ;
         }
         else
         {
            wb_table2_20_0S2( false) ;
         }
         return  ;
      }

      protected void wb_table2_20_0S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            wb_table3_25_0S2( true) ;
         }
         else
         {
            wb_table3_25_0S2( false) ;
         }
         return  ;
      }

      protected void wb_table3_25_0S2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "hidden-xs CellChartNoLines", "start", "top", "", "flex-grow:1;", "div");
            /* User Defined Control */
            ucUtchartcolumnline.SetProperty("Elements", AV20Elements);
            ucUtchartcolumnline.SetProperty("Parameters", AV21Parameters);
            ucUtchartcolumnline.SetProperty("Class", Utchartcolumnline_Class);
            ucUtchartcolumnline.SetProperty("Height", Utchartcolumnline_Height);
            ucUtchartcolumnline.SetProperty("Type", Utchartcolumnline_Type);
            ucUtchartcolumnline.SetProperty("Title", Utchartcolumnline_Title);
            ucUtchartcolumnline.SetProperty("ChartType", Utchartcolumnline_Charttype);
            ucUtchartcolumnline.SetProperty("PlotSeries", Utchartcolumnline_Plotseries);
            ucUtchartcolumnline.SetProperty("ItemClickData", AV22ItemClickData);
            ucUtchartcolumnline.SetProperty("ItemDoubleClickData", AV23ItemDoubleClickData);
            ucUtchartcolumnline.SetProperty("DragAndDropData", AV24DragAndDropData);
            ucUtchartcolumnline.SetProperty("FilterChangedData", AV25FilterChangedData);
            ucUtchartcolumnline.SetProperty("ItemExpandData", AV26ItemExpandData);
            ucUtchartcolumnline.SetProperty("ItemCollapseData", AV27ItemCollapseData);
            ucUtchartcolumnline.Render(context, "queryviewer", Utchartcolumnline_Internalname, "UTCHARTCOLUMNLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-5 col-lg-4 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablenotifications.SetProperty("Width", Dvpanel_tablenotifications_Width);
            ucDvpanel_tablenotifications.SetProperty("AutoWidth", Dvpanel_tablenotifications_Autowidth);
            ucDvpanel_tablenotifications.SetProperty("AutoHeight", Dvpanel_tablenotifications_Autoheight);
            ucDvpanel_tablenotifications.SetProperty("Cls", Dvpanel_tablenotifications_Cls);
            ucDvpanel_tablenotifications.SetProperty("Title", Dvpanel_tablenotifications_Title);
            ucDvpanel_tablenotifications.SetProperty("Collapsible", Dvpanel_tablenotifications_Collapsible);
            ucDvpanel_tablenotifications.SetProperty("Collapsed", Dvpanel_tablenotifications_Collapsed);
            ucDvpanel_tablenotifications.SetProperty("ShowCollapseIcon", Dvpanel_tablenotifications_Showcollapseicon);
            ucDvpanel_tablenotifications.SetProperty("IconPosition", Dvpanel_tablenotifications_Iconposition);
            ucDvpanel_tablenotifications.SetProperty("AutoScroll", Dvpanel_tablenotifications_Autoscroll);
            ucDvpanel_tablenotifications.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablenotifications_Internalname, "DVPANEL_TABLENOTIFICATIONSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLENOTIFICATIONSContainer"+"TableNotifications"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablenotifications_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 NotificationSubtitleCell", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationssubtitle_Internalname, lblNotificationssubtitle_Caption, "", "", lblNotificationssubtitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockDashboardDescriptionCard", 0, "", 1, 1, 0, 0, "HLP_Home.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 GridNoBorderNoHeader CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridnotitlesContainer.SetWrapped(nGXWrapped);
            StartGridControl41( ) ;
         }
         if ( wbEnd == 41 )
         {
            wbEnd = 0;
            nRC_GXsfl_41 = (int)(nGXsfl_41_idx-1);
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridnotitlesContainer.AddObjectProperty("GRIDNOTITLES_nEOF", GRIDNOTITLES_nEOF);
               GridnotitlesContainer.AddObjectProperty("GRIDNOTITLES_nFirstRecordOnPage", GRIDNOTITLES_nFirstRecordOnPage);
               AV32GXV1 = nGXsfl_41_idx;
               sStyleString = "";
               context.WriteHtmlText( "<div id=\""+"GridnotitlesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
               context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridnotitles", GridnotitlesContainer, subGridnotitles_Internalname);
               if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridnotitlesContainerData", GridnotitlesContainer.ToJavascriptSource());
               }
               if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
               {
                  GxWebStd.gx_hidden_field( context, "GridnotitlesContainerData"+"V", GridnotitlesContainer.GridValuesHidden());
               }
               else
               {
                  context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridnotitlesContainerData"+"V"+"\" value='"+GridnotitlesContainer.GridValuesHidden()+"'/>") ;
               }
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-7 col-lg-8 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart1.SetProperty("Width", Dvpanel_tablechart1_Width);
            ucDvpanel_tablechart1.SetProperty("AutoWidth", Dvpanel_tablechart1_Autowidth);
            ucDvpanel_tablechart1.SetProperty("AutoHeight", Dvpanel_tablechart1_Autoheight);
            ucDvpanel_tablechart1.SetProperty("Cls", Dvpanel_tablechart1_Cls);
            ucDvpanel_tablechart1.SetProperty("Title", Dvpanel_tablechart1_Title);
            ucDvpanel_tablechart1.SetProperty("Collapsible", Dvpanel_tablechart1_Collapsible);
            ucDvpanel_tablechart1.SetProperty("Collapsed", Dvpanel_tablechart1_Collapsed);
            ucDvpanel_tablechart1.SetProperty("ShowCollapseIcon", Dvpanel_tablechart1_Showcollapseicon);
            ucDvpanel_tablechart1.SetProperty("IconPosition", Dvpanel_tablechart1_Iconposition);
            ucDvpanel_tablechart1.SetProperty("AutoScroll", Dvpanel_tablechart1_Autoscroll);
            ucDvpanel_tablechart1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart1_Internalname, "DVPANEL_TABLECHART1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART1Container"+"TableChart1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart1_Internalname, 1, 0, "px", divTablechart1_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmootharea.SetProperty("Elements", AV20Elements);
            ucUtchartsmootharea.SetProperty("Parameters", AV21Parameters);
            ucUtchartsmootharea.SetProperty("Type", Utchartsmootharea_Type);
            ucUtchartsmootharea.SetProperty("Title", Utchartsmootharea_Title);
            ucUtchartsmootharea.SetProperty("ChartType", Utchartsmootharea_Charttype);
            ucUtchartsmootharea.SetProperty("ItemClickData", AV22ItemClickData);
            ucUtchartsmootharea.SetProperty("ItemDoubleClickData", AV23ItemDoubleClickData);
            ucUtchartsmootharea.SetProperty("DragAndDropData", AV24DragAndDropData);
            ucUtchartsmootharea.SetProperty("FilterChangedData", AV25FilterChangedData);
            ucUtchartsmootharea.SetProperty("ItemExpandData", AV26ItemExpandData);
            ucUtchartsmootharea.SetProperty("ItemCollapseData", AV27ItemCollapseData);
            ucUtchartsmootharea.Render(context, "queryviewer", Utchartsmootharea_Internalname, "UTCHARTSMOOTHAREAContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 col-lg-8 CellMarginTop", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablechart4.SetProperty("Width", Dvpanel_tablechart4_Width);
            ucDvpanel_tablechart4.SetProperty("AutoWidth", Dvpanel_tablechart4_Autowidth);
            ucDvpanel_tablechart4.SetProperty("AutoHeight", Dvpanel_tablechart4_Autoheight);
            ucDvpanel_tablechart4.SetProperty("Cls", Dvpanel_tablechart4_Cls);
            ucDvpanel_tablechart4.SetProperty("Title", Dvpanel_tablechart4_Title);
            ucDvpanel_tablechart4.SetProperty("Collapsible", Dvpanel_tablechart4_Collapsible);
            ucDvpanel_tablechart4.SetProperty("Collapsed", Dvpanel_tablechart4_Collapsed);
            ucDvpanel_tablechart4.SetProperty("ShowCollapseIcon", Dvpanel_tablechart4_Showcollapseicon);
            ucDvpanel_tablechart4.SetProperty("IconPosition", Dvpanel_tablechart4_Iconposition);
            ucDvpanel_tablechart4.SetProperty("AutoScroll", Dvpanel_tablechart4_Autoscroll);
            ucDvpanel_tablechart4.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablechart4_Internalname, "DVPANEL_TABLECHART4Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLECHART4Container"+"TableChart4"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablechart4_Internalname, 1, 0, "px", divTablechart4_Height, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucUtchartsmoothline.SetProperty("Elements", AV20Elements);
            ucUtchartsmoothline.SetProperty("Parameters", AV21Parameters);
            ucUtchartsmoothline.SetProperty("Height", Utchartsmoothline_Height);
            ucUtchartsmoothline.SetProperty("Type", Utchartsmoothline_Type);
            ucUtchartsmoothline.SetProperty("Title", Utchartsmoothline_Title);
            ucUtchartsmoothline.SetProperty("ChartType", Utchartsmoothline_Charttype);
            ucUtchartsmoothline.SetProperty("ItemClickData", AV22ItemClickData);
            ucUtchartsmoothline.SetProperty("ItemDoubleClickData", AV23ItemDoubleClickData);
            ucUtchartsmoothline.SetProperty("DragAndDropData", AV24DragAndDropData);
            ucUtchartsmoothline.SetProperty("FilterChangedData", AV25FilterChangedData);
            ucUtchartsmoothline.SetProperty("ItemExpandData", AV26ItemExpandData);
            ucUtchartsmoothline.SetProperty("ItemCollapseData", AV27ItemCollapseData);
            ucUtchartsmoothline.Render(context, "queryviewer", Utchartsmoothline_Internalname, "UTCHARTSMOOTHLINEContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-md-6 col-lg-4 SectionGrid GridNoBorderCell CellMarginTop HasGridEmpowerer", "start", "top", "", "", "div");
            /*  Grid Control  */
            GridContainer.SetWrapped(nGXWrapped);
            StartGridControl62( ) ;
         }
         if ( wbEnd == 62 )
         {
            wbEnd = 0;
            nRC_GXsfl_62 = (int)(nGXsfl_62_idx-1);
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "</table>") ;
               context.WriteHtmlText( "</div>") ;
            }
            else
            {
               GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
               GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
               AV36GXV5 = nGXsfl_62_idx;
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
            ucGrid_empowerer.Render(context, "wwp.gridempowerer", Grid_empowerer_Internalname, "GRID_EMPOWERERContainer");
            /* User Defined Control */
            ucGridnotitles_empowerer.Render(context, "wwp.gridempowerer", Gridnotitles_empowerer_Internalname, "GRIDNOTITLES_EMPOWERERContainer");
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
               if ( GridnotitlesContainer.GetWrapped() == 1 )
               {
                  context.WriteHtmlText( "</table>") ;
                  context.WriteHtmlText( "</div>") ;
               }
               else
               {
                  GridnotitlesContainer.AddObjectProperty("GRIDNOTITLES_nEOF", GRIDNOTITLES_nEOF);
                  GridnotitlesContainer.AddObjectProperty("GRIDNOTITLES_nFirstRecordOnPage", GRIDNOTITLES_nFirstRecordOnPage);
                  AV32GXV1 = nGXsfl_41_idx;
                  sStyleString = "";
                  context.WriteHtmlText( "<div id=\""+"GridnotitlesContainer"+"Div\" "+sStyleString+">"+"</div>") ;
                  context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridnotitles", GridnotitlesContainer, subGridnotitles_Internalname);
                  if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridnotitlesContainerData", GridnotitlesContainer.ToJavascriptSource());
                  }
                  if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
                  {
                     GxWebStd.gx_hidden_field( context, "GridnotitlesContainerData"+"V", GridnotitlesContainer.GridValuesHidden());
                  }
                  else
                  {
                     context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"GridnotitlesContainerData"+"V"+"\" value='"+GridnotitlesContainer.GridValuesHidden()+"'/>") ;
                  }
               }
            }
         }
         if ( wbEnd == 62 )
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
                  GridContainer.AddObjectProperty("GRID_nEOF", GRID_nEOF);
                  GridContainer.AddObjectProperty("GRID_nFirstRecordOnPage", GRID_nFirstRecordOnPage);
                  AV36GXV5 = nGXsfl_62_idx;
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

      protected void START0S2( )
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
            Form.Meta.addItem("description", "Inicio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0S0( ) ;
      }

      protected void WS0S2( )
      {
         START0S2( ) ;
         EVT0S2( ) ;
      }

      protected void EVT0S2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDNOTITLESPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDNOTITLESPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgridnotitles_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgridnotitles_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgridnotitles_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgridnotitles_lastpage( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "GRIDPAGING") == 0 )
                           {
                              context.wbHandled = 1;
                              sEvt = cgiGet( "GRIDPAGING");
                              if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                              {
                                 subgrid_firstpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "PREV") == 0 )
                              {
                                 subgrid_previouspage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                              {
                                 subgrid_nextpage( ) ;
                              }
                              else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                              {
                                 subgrid_lastpage( ) ;
                              }
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                           sEvtType = StringUtil.Right( sEvt, 4);
                           sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
                           if ( ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "START") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 7), "REFRESH") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 17), "GRIDNOTITLES.LOAD") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 5), "ENTER") == 0 ) || ( StringUtil.StrCmp(StringUtil.Left( sEvt, 6), "CANCEL") == 0 ) )
                           {
                              nGXsfl_41_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
                              SubsflControlProps_412( ) ;
                              AV32GXV1 = (int)(nGXsfl_41_idx+GRIDNOTITLES_nFirstRecordOnPage);
                              if ( ( AV7SDTNotificationsData.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
                              {
                                 AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1));
                                 AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
                                 AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Start */
                                    E110S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    /* Execute user event: Refresh */
                                    E120S2 ();
                                 }
                                 else if ( StringUtil.StrCmp(sEvt, "GRIDNOTITLES.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E130S2 ();
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
                           else if ( StringUtil.StrCmp(StringUtil.Left( sEvt, 9), "GRID.LOAD") == 0 )
                           {
                              nGXsfl_62_idx = (int)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                              sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
                              SubsflControlProps_623( ) ;
                              AV36GXV5 = (int)(nGXsfl_62_idx+GRID_nFirstRecordOnPage);
                              if ( ( AV5HomeSampleData.Count >= AV36GXV5 ) && ( AV36GXV5 > 0 ) )
                              {
                                 AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5));
                              }
                              sEvtType = StringUtil.Right( sEvt, 1);
                              if ( StringUtil.StrCmp(sEvtType, ".") == 0 )
                              {
                                 sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-1));
                                 if ( StringUtil.StrCmp(sEvt, "GRID.LOAD") == 0 )
                                 {
                                    context.wbHandled = 1;
                                    dynload_actions( ) ;
                                    E140S3 ();
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

      protected void WE0S2( )
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

      protected void PA0S2( )
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void gxnrGridnotitles_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_412( ) ;
         while ( nGXsfl_41_idx <= nRC_GXsfl_41 )
         {
            sendrow_412( ) ;
            nGXsfl_41_idx = ((subGridnotitles_Islastpage==1)&&(nGXsfl_41_idx+1>subGridnotitles_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridnotitlesContainer)) ;
         /* End function gxnrGridnotitles_newrow */
      }

      protected void gxnrGrid_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         SubsflControlProps_623( ) ;
         while ( nGXsfl_62_idx <= nRC_GXsfl_62 )
         {
            sendrow_623( ) ;
            nGXsfl_62_idx = ((subGrid_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_623( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( GridContainer)) ;
         /* End function gxnrGrid_newrow */
      }

      protected void gxgrGridnotitles_refresh( int subGridnotitles_Rows ,
                                               int subGrid_Rows ,
                                               GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV7SDTNotificationsData ,
                                               GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRIDNOTITLES_nCurrentRecord = 0;
         RF0S2( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         send_integrity_footer_hashes( ) ;
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         /* End function gxgrGridnotitles_refresh */
      }

      protected void gxgrGrid_refresh( int subGridnotitles_Rows ,
                                       int subGrid_Rows ,
                                       GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ,
                                       GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV7SDTNotificationsData )
      {
         initialize_formulas( ) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         GRID_nCurrentRecord = 0;
         RF0S3( ) ;
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
         RF0S2( ) ;
         RF0S3( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
         AV40Pgmname = "Home";
         edtavNotificationicon_Enabled = 0;
         AssignProp("", false, edtavNotificationicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationicon_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavHomesampledata__productname_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavHomesampledata__productprice_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         cmbavHomesampledata__productstatus.Enabled = 0;
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0), !bGXsfl_62_Refreshing);
      }

      protected void RF0S2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridnotitlesContainer.ClearRows();
         }
         wbStart = 41;
         /* Execute user event: Refresh */
         E120S2 ();
         nGXsfl_41_idx = 1;
         sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
         SubsflControlProps_412( ) ;
         bGXsfl_41_Refreshing = true;
         GridnotitlesContainer.AddObjectProperty("GridName", "Gridnotitles");
         GridnotitlesContainer.AddObjectProperty("CmpContext", "");
         GridnotitlesContainer.AddObjectProperty("InMasterPage", "false");
         GridnotitlesContainer.AddObjectProperty("Class", "WorkWith");
         GridnotitlesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridnotitlesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridnotitlesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Backcolorstyle), 1, 0, ".", "")));
         GridnotitlesContainer.PageSize = subGridnotitles_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_412( ) ;
            E130S2 ();
            if ( ( subGridnotitles_Islastpage == 0 ) && ( GRIDNOTITLES_nCurrentRecord > 0 ) && ( GRIDNOTITLES_nGridOutOfScope == 0 ) && ( nGXsfl_41_idx == 1 ) )
            {
               GRIDNOTITLES_nCurrentRecord = 0;
               GRIDNOTITLES_nGridOutOfScope = 1;
               subgridnotitles_firstpage( ) ;
               E130S2 ();
            }
            wbEnd = 41;
            WB0S0( ) ;
         }
         bGXsfl_41_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0S2( )
      {
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vHOMESAMPLEDATA", AV5HomeSampleData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vHOMESAMPLEDATA", GetSecureSignedToken( "", AV5HomeSampleData, context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTNOTIFICATIONSDATA", AV7SDTNotificationsData);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTNOTIFICATIONSDATA", GetSecureSignedToken( "", AV7SDTNotificationsData, context));
      }

      protected void RF0S3( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( isAjaxCallMode( ) )
         {
            GridContainer.ClearRows();
         }
         wbStart = 62;
         /* Execute user event: Refresh */
         E120S2 ();
         nGXsfl_62_idx = 1;
         sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
         SubsflControlProps_623( ) ;
         bGXsfl_62_Refreshing = true;
         GridContainer.AddObjectProperty("GridName", "Grid");
         GridContainer.AddObjectProperty("CmpContext", "");
         GridContainer.AddObjectProperty("InMasterPage", "false");
         GridContainer.AddObjectProperty("Class", "WorkWith");
         GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
         GridContainer.PageSize = subGrid_fnc_Recordsperpage( );
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            SubsflControlProps_623( ) ;
            E140S3 ();
            if ( ( subGrid_Islastpage == 0 ) && ( GRID_nCurrentRecord > 0 ) && ( GRID_nGridOutOfScope == 0 ) && ( nGXsfl_62_idx == 1 ) )
            {
               GRID_nCurrentRecord = 0;
               GRID_nGridOutOfScope = 1;
               subgrid_firstpage( ) ;
               E140S3 ();
            }
            wbEnd = 62;
            WB0S0( ) ;
         }
         bGXsfl_62_Refreshing = true;
      }

      protected void send_integrity_lvl_hashes0S3( )
      {
      }

      protected int subGridnotitles_fnc_Pagecount( )
      {
         GRIDNOTITLES_nRecordCount = subGridnotitles_fnc_Recordcount( );
         if ( ((int)((GRIDNOTITLES_nRecordCount) % (subGridnotitles_fnc_Recordsperpage( )))) == 0 )
         {
            return (int)(NumberUtil.Int( (long)(Math.Round(GRIDNOTITLES_nRecordCount/ (decimal)(subGridnotitles_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))) ;
         }
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDNOTITLES_nRecordCount/ (decimal)(subGridnotitles_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected int subGridnotitles_fnc_Recordcount( )
      {
         return AV7SDTNotificationsData.Count ;
      }

      protected int subGridnotitles_fnc_Recordsperpage( )
      {
         if ( subGridnotitles_Rows > 0 )
         {
            return subGridnotitles_Rows*1 ;
         }
         else
         {
            return (int)(-1) ;
         }
      }

      protected int subGridnotitles_fnc_Currentpage( )
      {
         return (int)(NumberUtil.Int( (long)(Math.Round(GRIDNOTITLES_nFirstRecordOnPage/ (decimal)(subGridnotitles_fnc_Recordsperpage( )), 18, MidpointRounding.ToEven)))+1) ;
      }

      protected short subgridnotitles_firstpage( )
      {
         GRIDNOTITLES_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnotitles_nextpage( )
      {
         GRIDNOTITLES_nRecordCount = subGridnotitles_fnc_Recordcount( );
         if ( ( GRIDNOTITLES_nRecordCount >= subGridnotitles_fnc_Recordsperpage( ) ) && ( GRIDNOTITLES_nEOF == 0 ) )
         {
            GRIDNOTITLES_nFirstRecordOnPage = (long)(GRIDNOTITLES_nFirstRecordOnPage+subGridnotitles_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ".", "")));
         GridnotitlesContainer.AddObjectProperty("GRIDNOTITLES_nFirstRecordOnPage", GRIDNOTITLES_nFirstRecordOnPage);
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (short)(((GRIDNOTITLES_nEOF==0) ? 0 : 2)) ;
      }

      protected short subgridnotitles_previouspage( )
      {
         if ( GRIDNOTITLES_nFirstRecordOnPage >= subGridnotitles_fnc_Recordsperpage( ) )
         {
            GRIDNOTITLES_nFirstRecordOnPage = (long)(GRIDNOTITLES_nFirstRecordOnPage-subGridnotitles_fnc_Recordsperpage( ));
         }
         else
         {
            return 2 ;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgridnotitles_lastpage( )
      {
         GRIDNOTITLES_nRecordCount = subGridnotitles_fnc_Recordcount( );
         if ( GRIDNOTITLES_nRecordCount > subGridnotitles_fnc_Recordsperpage( ) )
         {
            if ( ((int)((GRIDNOTITLES_nRecordCount) % (subGridnotitles_fnc_Recordsperpage( )))) == 0 )
            {
               GRIDNOTITLES_nFirstRecordOnPage = (long)(GRIDNOTITLES_nRecordCount-subGridnotitles_fnc_Recordsperpage( ));
            }
            else
            {
               GRIDNOTITLES_nFirstRecordOnPage = (long)(GRIDNOTITLES_nRecordCount-((int)((GRIDNOTITLES_nRecordCount) % (subGridnotitles_fnc_Recordsperpage( )))));
            }
         }
         else
         {
            GRIDNOTITLES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected int subgridnotitles_gotopage( int nPageNo )
      {
         if ( nPageNo > 0 )
         {
            GRIDNOTITLES_nFirstRecordOnPage = (long)(subGridnotitles_fnc_Recordsperpage( )*(nPageNo-1));
         }
         else
         {
            GRIDNOTITLES_nFirstRecordOnPage = 0;
         }
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGridnotitles_refresh( subGridnotitles_Rows, subGrid_Rows, AV7SDTNotificationsData, AV5HomeSampleData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
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
         return AV5HomeSampleData.Count ;
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
         GRID_nFirstRecordOnPage = 0;
         GxWebStd.gx_hidden_field( context, "GRID_nFirstRecordOnPage", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nFirstRecordOnPage), 15, 0, ".", "")));
         if ( isFullAjaxMode( ) )
         {
            gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_nextpage( )
      {
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
            gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
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
            gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return 0 ;
      }

      protected short subgrid_lastpage( )
      {
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
            gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
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
            gxgrGrid_refresh( subGridnotitles_Rows, subGrid_Rows, AV5HomeSampleData, AV7SDTNotificationsData) ;
         }
         send_integrity_footer_hashes( ) ;
         return (int)(0) ;
      }

      protected void before_start_formulas( )
      {
         AV40Pgmname = "Home";
         edtavNotificationicon_Enabled = 0;
         AssignProp("", false, edtavNotificationicon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNotificationicon_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationiconclass_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationtitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         AssignProp("", false, edtavSdtnotificationsdata__notificationdatetime_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0), !bGXsfl_41_Refreshing);
         edtavHomesampledata__productname_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productname_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         edtavHomesampledata__productprice_Enabled = 0;
         AssignProp("", false, edtavHomesampledata__productprice_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0), !bGXsfl_62_Refreshing);
         cmbavHomesampledata__productstatus.Enabled = 0;
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0), !bGXsfl_62_Refreshing);
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "Sdtnotificationsdata"), AV7SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "Homesampledata"), AV5HomeSampleData);
            ajax_req_read_hidden_sdt(cgiGet( "vELEMENTS"), AV20Elements);
            ajax_req_read_hidden_sdt(cgiGet( "vSDTNOTIFICATIONSDATA"), AV7SDTNotificationsData);
            ajax_req_read_hidden_sdt(cgiGet( "vHOMESAMPLEDATA"), AV5HomeSampleData);
            /* Read saved values. */
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ",", "."), 18, MidpointRounding.ToEven));
            AV21Parameters = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vPARAMETERS"), ",", "."), 18, MidpointRounding.ToEven));
            AV22ItemClickData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMCLICKDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV23ItemDoubleClickData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMDOUBLECLICKDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV24DragAndDropData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vDRAGANDDROPDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV25FilterChangedData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vFILTERCHANGEDDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV26ItemExpandData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMEXPANDDATA"), ",", "."), 18, MidpointRounding.ToEven));
            AV27ItemCollapseData = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vITEMCOLLAPSEDATA"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDNOTITLES_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDNOTITLES_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nFirstRecordOnPage = (long)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nFirstRecordOnPage"), ",", "."), 18, MidpointRounding.ToEven));
            GRIDNOTITLES_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDNOTITLES_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            GRID_nEOF = (short)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_nEOF"), ",", "."), 18, MidpointRounding.ToEven));
            subGridnotitles_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRIDNOTITLES_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Rows), 6, 0, ".", "")));
            subGrid_Rows = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GRID_Rows"), ",", "."), 18, MidpointRounding.ToEven));
            GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
            Progress1_progress_Circlecaptiontype = cgiGet( "PROGRESS1_PROGRESS_Circlecaptiontype");
            Progress1_progress_Caption = cgiGet( "PROGRESS1_PROGRESS_Caption");
            Progress1_progress_Subtitle = cgiGet( "PROGRESS1_PROGRESS_Subtitle");
            Progress1_progress_Cls = cgiGet( "PROGRESS1_PROGRESS_Cls");
            Progress1_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS1_PROGRESS_Percentage"), ",", "."), 18, MidpointRounding.ToEven));
            Progress1_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS1_PROGRESS_Circlewidth"), ",", "."), 18, MidpointRounding.ToEven));
            Progress2_progress_Circlecaptiontype = cgiGet( "PROGRESS2_PROGRESS_Circlecaptiontype");
            Progress2_progress_Caption = cgiGet( "PROGRESS2_PROGRESS_Caption");
            Progress2_progress_Subtitle = cgiGet( "PROGRESS2_PROGRESS_Subtitle");
            Progress2_progress_Cls = cgiGet( "PROGRESS2_PROGRESS_Cls");
            Progress2_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS2_PROGRESS_Percentage"), ",", "."), 18, MidpointRounding.ToEven));
            Progress2_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS2_PROGRESS_Circlewidth"), ",", "."), 18, MidpointRounding.ToEven));
            Progress3_progress_Circlecaptiontype = cgiGet( "PROGRESS3_PROGRESS_Circlecaptiontype");
            Progress3_progress_Caption = cgiGet( "PROGRESS3_PROGRESS_Caption");
            Progress3_progress_Subtitle = cgiGet( "PROGRESS3_PROGRESS_Subtitle");
            Progress3_progress_Cls = cgiGet( "PROGRESS3_PROGRESS_Cls");
            Progress3_progress_Percentage = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS3_PROGRESS_Percentage"), ",", "."), 18, MidpointRounding.ToEven));
            Progress3_progress_Circlewidth = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PROGRESS3_PROGRESS_Circlewidth"), ",", "."), 18, MidpointRounding.ToEven));
            Utchartcolumnline_Class = cgiGet( "UTCHARTCOLUMNLINE_Class");
            Utchartcolumnline_Height = cgiGet( "UTCHARTCOLUMNLINE_Height");
            Utchartcolumnline_Type = cgiGet( "UTCHARTCOLUMNLINE_Type");
            Utchartcolumnline_Charttype = cgiGet( "UTCHARTCOLUMNLINE_Charttype");
            Utchartcolumnline_Plotseries = cgiGet( "UTCHARTCOLUMNLINE_Plotseries");
            Dvpanel_tablecards_Width = cgiGet( "DVPANEL_TABLECARDS_Width");
            Dvpanel_tablecards_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autowidth"));
            Dvpanel_tablecards_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoheight"));
            Dvpanel_tablecards_Cls = cgiGet( "DVPANEL_TABLECARDS_Cls");
            Dvpanel_tablecards_Title = cgiGet( "DVPANEL_TABLECARDS_Title");
            Dvpanel_tablecards_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsible"));
            Dvpanel_tablecards_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Collapsed"));
            Dvpanel_tablecards_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Showcollapseicon"));
            Dvpanel_tablecards_Iconposition = cgiGet( "DVPANEL_TABLECARDS_Iconposition");
            Dvpanel_tablecards_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECARDS_Autoscroll"));
            Dvpanel_tablenotifications_Width = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Width");
            Dvpanel_tablenotifications_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autowidth"));
            Dvpanel_tablenotifications_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoheight"));
            Dvpanel_tablenotifications_Cls = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Cls");
            Dvpanel_tablenotifications_Title = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Title");
            Dvpanel_tablenotifications_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsible"));
            Dvpanel_tablenotifications_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Collapsed"));
            Dvpanel_tablenotifications_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Showcollapseicon"));
            Dvpanel_tablenotifications_Iconposition = cgiGet( "DVPANEL_TABLENOTIFICATIONS_Iconposition");
            Dvpanel_tablenotifications_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLENOTIFICATIONS_Autoscroll"));
            Utchartsmootharea_Type = cgiGet( "UTCHARTSMOOTHAREA_Type");
            Utchartsmootharea_Charttype = cgiGet( "UTCHARTSMOOTHAREA_Charttype");
            Dvpanel_tablechart1_Width = cgiGet( "DVPANEL_TABLECHART1_Width");
            Dvpanel_tablechart1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autowidth"));
            Dvpanel_tablechart1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoheight"));
            Dvpanel_tablechart1_Cls = cgiGet( "DVPANEL_TABLECHART1_Cls");
            Dvpanel_tablechart1_Title = cgiGet( "DVPANEL_TABLECHART1_Title");
            Dvpanel_tablechart1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsible"));
            Dvpanel_tablechart1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Collapsed"));
            Dvpanel_tablechart1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Showcollapseicon"));
            Dvpanel_tablechart1_Iconposition = cgiGet( "DVPANEL_TABLECHART1_Iconposition");
            Dvpanel_tablechart1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART1_Autoscroll"));
            Utchartsmoothline_Height = cgiGet( "UTCHARTSMOOTHLINE_Height");
            Utchartsmoothline_Type = cgiGet( "UTCHARTSMOOTHLINE_Type");
            Utchartsmoothline_Charttype = cgiGet( "UTCHARTSMOOTHLINE_Charttype");
            Dvpanel_tablechart4_Width = cgiGet( "DVPANEL_TABLECHART4_Width");
            Dvpanel_tablechart4_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autowidth"));
            Dvpanel_tablechart4_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoheight"));
            Dvpanel_tablechart4_Cls = cgiGet( "DVPANEL_TABLECHART4_Cls");
            Dvpanel_tablechart4_Title = cgiGet( "DVPANEL_TABLECHART4_Title");
            Dvpanel_tablechart4_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsible"));
            Dvpanel_tablechart4_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Collapsed"));
            Dvpanel_tablechart4_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Showcollapseicon"));
            Dvpanel_tablechart4_Iconposition = cgiGet( "DVPANEL_TABLECHART4_Iconposition");
            Dvpanel_tablechart4_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLECHART4_Autoscroll"));
            Grid_empowerer_Gridinternalname = cgiGet( "GRID_EMPOWERER_Gridinternalname");
            Gridnotitles_empowerer_Gridinternalname = cgiGet( "GRIDNOTITLES_EMPOWERER_Gridinternalname");
            nRC_GXsfl_41 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_41"), ",", "."), 18, MidpointRounding.ToEven));
            nGXsfl_41_fel_idx = 0;
            while ( nGXsfl_41_fel_idx < nRC_GXsfl_41 )
            {
               nGXsfl_41_fel_idx = ((subGridnotitles_Islastpage==1)&&(nGXsfl_41_fel_idx+1>subGridnotitles_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_fel_idx+1);
               sGXsfl_41_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_412( ) ;
               AV32GXV1 = (int)(nGXsfl_41_fel_idx+GRIDNOTITLES_nFirstRecordOnPage);
               if ( ( AV7SDTNotificationsData.Count >= AV32GXV1 ) && ( AV32GXV1 > 0 ) )
               {
                  AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1));
                  AV6NotificationIcon = cgiGet( edtavNotificationicon_Internalname);
               }
            }
            if ( nGXsfl_41_fel_idx == 0 )
            {
               nGXsfl_41_idx = 1;
               sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
               SubsflControlProps_412( ) ;
            }
            nGXsfl_41_fel_idx = 1;
            nRC_GXsfl_62 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_62"), ",", "."), 18, MidpointRounding.ToEven));
            nGXsfl_62_fel_idx = 0;
            while ( nGXsfl_62_fel_idx < nRC_GXsfl_62 )
            {
               nGXsfl_62_fel_idx = ((subGrid_Islastpage==1)&&(nGXsfl_62_fel_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_fel_idx+1);
               sGXsfl_62_fel_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_fel_idx), 4, 0), 4, "0");
               SubsflControlProps_fel_623( ) ;
               AV36GXV5 = (int)(nGXsfl_62_fel_idx+GRID_nFirstRecordOnPage);
               if ( ( AV5HomeSampleData.Count >= AV36GXV5 ) && ( AV36GXV5 > 0 ) )
               {
                  AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5));
               }
            }
            if ( nGXsfl_62_fel_idx == 0 )
            {
               nGXsfl_62_idx = 1;
               sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
               SubsflControlProps_623( ) ;
            }
            nGXsfl_62_fel_idx = 1;
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            /* Check if conditions changed and reset current page numbers */
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
         E110S2 ();
         if (returnInSub) return;
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new prcdebugtofile(context ).execute(  AV40Pgmname,  "Event Start - início") ;
         AV8Card1_Value = 352;
         AV9Card2_Value = 7552;
         AV10Card3_Value = 825;
         AV11Card4_Value = 2540;
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = AV5HomeSampleData;
         new GeneXus.Programs.wwpbaseobjects.gethomesampledata(context ).execute( out  GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1) ;
         AV5HomeSampleData = GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1;
         gx_BV62 = true;
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "ProductStatus";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem2 = AV7SDTNotificationsData;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_getnotificationsforuser(context ).execute( out  GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem2) ;
         AV7SDTNotificationsData = GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem2;
         gx_BV41 = true;
         if ( AV7SDTNotificationsData.Count == 0 )
         {
            lblNotificationssubtitle_Caption = "Não têm novas notificações";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else if ( AV7SDTNotificationsData.Count == 1 )
         {
            lblNotificationssubtitle_Caption = "Você tem 1 nova notificação";
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         else
         {
            lblNotificationssubtitle_Caption = StringUtil.Format( "Você têm %1 novas notificações", StringUtil.Trim( StringUtil.Str( (decimal)(AV7SDTNotificationsData.Count), 9, 0)), "", "", "", "", "", "", "", "");
            AssignProp("", false, lblNotificationssubtitle_Internalname, "Caption", lblNotificationssubtitle_Caption, true);
         }
         AV15Progress1_PercentageValue = 30;
         AV14Progress1_Value = 3154;
         AV17Progress2_PercentageValue = 78;
         AV16Progress2_Value = 1546;
         AV19Progress3_PercentageValue = 47;
         AV18Progress3_Value = 912;
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV13Axis.gxTpr_Name = "Check";
         AV13Axis.gxTpr_Visible = "No";
         AV12Axes.Add(AV13Axis, 0);
         divTablechart4_Height = 418;
         AssignProp("", false, divTablechart4_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart4_Height), 9, 0), true);
         divTablechart1_Height = 410;
         AssignProp("", false, divTablechart1_Internalname, "Height", StringUtil.LTrimStr( (decimal)(divTablechart1_Height), 9, 0), true);
         Grid_empowerer_Gridinternalname = subGrid_Internalname;
         ucGrid_empowerer.SendProperty(context, "", false, Grid_empowerer_Internalname, "GridInternalName", Grid_empowerer_Gridinternalname);
         subGrid_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRID_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Rows), 6, 0, ".", "")));
         Gridnotitles_empowerer_Gridinternalname = subGridnotitles_Internalname;
         ucGridnotitles_empowerer.SendProperty(context, "", false, Gridnotitles_empowerer_Internalname, "GridInternalName", Gridnotitles_empowerer_Gridinternalname);
         subGridnotitles_Rows = 0;
         GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_Rows", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Rows), 6, 0, ".", "")));
         Progress1_progress_Percentage = AV15Progress1_PercentageValue;
         ucProgress1_progress.SendProperty(context, "", false, Progress1_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Progress1_progress_Percentage), 9, 0));
         Progress1_progress_Caption = context.localUtil.Format( (decimal)(AV14Progress1_Value), "ZZ,ZZZ,ZZ9");
         ucProgress1_progress.SendProperty(context, "", false, Progress1_progress_Internalname, "Caption", Progress1_progress_Caption);
         Progress2_progress_Percentage = AV17Progress2_PercentageValue;
         ucProgress2_progress.SendProperty(context, "", false, Progress2_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Progress2_progress_Percentage), 9, 0));
         Progress2_progress_Caption = context.localUtil.Format( (decimal)(AV16Progress2_Value), "ZZ,ZZZ,ZZ9");
         ucProgress2_progress.SendProperty(context, "", false, Progress2_progress_Internalname, "Caption", Progress2_progress_Caption);
         Progress3_progress_Percentage = AV19Progress3_PercentageValue;
         ucProgress3_progress.SendProperty(context, "", false, Progress3_progress_Internalname, "Percentage", StringUtil.LTrimStr( (decimal)(Progress3_progress_Percentage), 9, 0));
         Progress3_progress_Caption = context.localUtil.Format( (decimal)(AV18Progress3_Value), "ZZ,ZZZ,ZZ9");
         ucProgress3_progress.SendProperty(context, "", false, Progress3_progress_Internalname, "Caption", Progress3_progress_Caption);
      }

      protected void E120S2( )
      {
         if ( gx_refresh_fired )
         {
            return  ;
         }
         gx_refresh_fired = true;
         /* Refresh Routine */
         returnInSub = false;
         cmbavHomesampledata__productstatus_Columnheaderclass = "WWColumn";
         AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Columnheaderclass", cmbavHomesampledata__productstatus_Columnheaderclass, !bGXsfl_62_Refreshing);
         /*  Sending Event outputs  */
      }

      private void E130S2( )
      {
         /* Gridnotitles_Load Routine */
         returnInSub = false;
         AV32GXV1 = 1;
         while ( AV32GXV1 <= AV7SDTNotificationsData.Count )
         {
            AV7SDTNotificationsData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1));
            edtavNotificationicon_Format = 2;
            AV6NotificationIcon = StringUtil.Format( "<i class=\"%1 %2\"></i>", ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)(AV7SDTNotificationsData.CurrentItem)).gxTpr_Notificationiconclass, "NotificationFontIconGrid", "", "", "", "", "", "", "");
            AssignAttri("", false, edtavNotificationicon_Internalname, AV6NotificationIcon);
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 41;
            }
            if ( ( subGridnotitles_Islastpage == 1 ) || ( subGridnotitles_Rows == 0 ) || ( ( GRIDNOTITLES_nCurrentRecord >= GRIDNOTITLES_nFirstRecordOnPage ) && ( GRIDNOTITLES_nCurrentRecord < GRIDNOTITLES_nFirstRecordOnPage + subGridnotitles_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_412( ) ;
            }
            GRIDNOTITLES_nEOF = (short)(((GRIDNOTITLES_nCurrentRecord<GRIDNOTITLES_nFirstRecordOnPage+subGridnotitles_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRIDNOTITLES_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRIDNOTITLES_nEOF), 1, 0, ".", "")));
            GRIDNOTITLES_nCurrentRecord = (long)(GRIDNOTITLES_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_41_Refreshing )
            {
               DoAjaxLoad(41, GridnotitlesRow);
            }
            AV32GXV1 = (int)(AV32GXV1+1);
         }
         /*  Sending Event outputs  */
      }

      private void E140S3( )
      {
         /* Grid_Load Routine */
         returnInSub = false;
         AV36GXV5 = 1;
         while ( AV36GXV5 <= AV5HomeSampleData.Count )
         {
            AV5HomeSampleData.CurrentItem = ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5));
            if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 1 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagSuccess WWColumnTagSuccessSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 2 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagDanger WWColumnTagDangerSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 4 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagInfoLight WWColumnTagInfoLightSingleCell";
            }
            else if ( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)(AV5HomeSampleData.CurrentItem)).gxTpr_Productstatus == 3 )
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn WWColumnTag WWColumnTagWarning WWColumnTagWarningSingleCell";
            }
            else
            {
               cmbavHomesampledata__productstatus_Columnclass = "WWColumn";
            }
            /* Load Method */
            if ( wbStart != -1 )
            {
               wbStart = 62;
            }
            if ( ( subGrid_Islastpage == 1 ) || ( subGrid_Rows == 0 ) || ( ( GRID_nCurrentRecord >= GRID_nFirstRecordOnPage ) && ( GRID_nCurrentRecord < GRID_nFirstRecordOnPage + subGrid_fnc_Recordsperpage( ) ) ) )
            {
               sendrow_623( ) ;
            }
            GRID_nEOF = (short)(((GRID_nCurrentRecord<GRID_nFirstRecordOnPage+subGrid_fnc_Recordsperpage( )) ? 1 : 0));
            GxWebStd.gx_hidden_field( context, "GRID_nEOF", StringUtil.LTrim( StringUtil.NToC( (decimal)(GRID_nEOF), 1, 0, ".", "")));
            GRID_nCurrentRecord = (long)(GRID_nCurrentRecord+1);
            if ( isFullAjaxMode( ) && ! bGXsfl_62_Refreshing )
            {
               DoAjaxLoad(62, GridRow);
            }
            AV36GXV5 = (int)(AV36GXV5+1);
         }
         /*  Sending Event outputs  */
      }

      protected void wb_table3_25_0S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblProgress3_tablemain_Internalname, tblProgress3_tablemain_Internalname, "", "TableProgressCards", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucProgress3_progress.SetProperty("CircleCaptionType", Progress3_progress_Circlecaptiontype);
            ucProgress3_progress.SetProperty("Caption", Progress3_progress_Caption);
            ucProgress3_progress.SetProperty("Subtitle", Progress3_progress_Subtitle);
            ucProgress3_progress.SetProperty("Cls", Progress3_progress_Cls);
            ucProgress3_progress.SetProperty("Percentage", Progress3_progress_Percentage);
            ucProgress3_progress.SetProperty("CircleWidth", Progress3_progress_Circlewidth);
            ucProgress3_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progress3_progress_Internalname, "PROGRESS3_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table3_25_0S2e( true) ;
         }
         else
         {
            wb_table3_25_0S2e( false) ;
         }
      }

      protected void wb_table2_20_0S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblProgress2_tablemain_Internalname, tblProgress2_tablemain_Internalname, "", "TableProgressCards", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucProgress2_progress.SetProperty("CircleCaptionType", Progress2_progress_Circlecaptiontype);
            ucProgress2_progress.SetProperty("Caption", Progress2_progress_Caption);
            ucProgress2_progress.SetProperty("Subtitle", Progress2_progress_Subtitle);
            ucProgress2_progress.SetProperty("Cls", Progress2_progress_Cls);
            ucProgress2_progress.SetProperty("Percentage", Progress2_progress_Percentage);
            ucProgress2_progress.SetProperty("CircleWidth", Progress2_progress_Circlewidth);
            ucProgress2_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progress2_progress_Internalname, "PROGRESS2_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table2_20_0S2e( true) ;
         }
         else
         {
            wb_table2_20_0S2e( false) ;
         }
      }

      protected void wb_table1_15_0S2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblProgress1_tablemain_Internalname, tblProgress1_tablemain_Internalname, "", "TableProgressCards", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td>") ;
            /* User Defined Control */
            ucProgress1_progress.SetProperty("CircleCaptionType", Progress1_progress_Circlecaptiontype);
            ucProgress1_progress.SetProperty("Caption", Progress1_progress_Caption);
            ucProgress1_progress.SetProperty("Subtitle", Progress1_progress_Subtitle);
            ucProgress1_progress.SetProperty("Cls", Progress1_progress_Cls);
            ucProgress1_progress.SetProperty("Percentage", Progress1_progress_Percentage);
            ucProgress1_progress.SetProperty("CircleWidth", Progress1_progress_Circlewidth);
            ucProgress1_progress.Render(context, "dvelop.gxbootstrap.dvprogressindicator", Progress1_progress_Internalname, "PROGRESS1_PROGRESSContainer");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_15_0S2e( true) ;
         }
         else
         {
            wb_table1_15_0S2e( false) ;
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
         PA0S2( ) ;
         WS0S2( ) ;
         WE0S2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828183091", true, true);
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
         if ( nGXWrapped != 1 )
         {
            context.AddJavascriptSource("messages.por.js", "?"+GetCacheInvalidationToken( ), false, true);
            context.AddJavascriptSource("home.js", "?2023828183091", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/DVProgressIndicator/DVProgressIndicatorRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerCommon.js", "", false, true);
            context.AddJavascriptSource("QueryViewer/QueryViewerRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
            context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
            context.AddJavascriptSource("DVelop/GridEmpowerer/GridEmpowererRender.js", "", false, true);
         }
         /* End function include_jscripts */
      }

      protected void SubsflControlProps_412( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_41_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_41_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_41_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_41_idx;
      }

      protected void SubsflControlProps_fel_412( )
      {
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON_"+sGXsfl_41_fel_idx;
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS_"+sGXsfl_41_fel_idx;
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE_"+sGXsfl_41_fel_idx;
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME_"+sGXsfl_41_fel_idx;
      }

      protected void sendrow_412( )
      {
         SubsflControlProps_412( ) ;
         WB0S0( ) ;
         if ( ( subGridnotitles_Rows * 1 == 0 ) || ( nGXsfl_41_idx <= subGridnotitles_fnc_Recordsperpage( ) * 1 ) )
         {
            GridnotitlesRow = GXWebRow.GetNew(context,GridnotitlesContainer);
            if ( subGridnotitles_Backcolorstyle == 0 )
            {
               /* None style subfile background logic. */
               subGridnotitles_Backstyle = 0;
               if ( StringUtil.StrCmp(subGridnotitles_Class, "") != 0 )
               {
                  subGridnotitles_Linesclass = subGridnotitles_Class+"Odd";
               }
            }
            else if ( subGridnotitles_Backcolorstyle == 1 )
            {
               /* Uniform style subfile background logic. */
               subGridnotitles_Backstyle = 0;
               subGridnotitles_Backcolor = subGridnotitles_Allbackcolor;
               if ( StringUtil.StrCmp(subGridnotitles_Class, "") != 0 )
               {
                  subGridnotitles_Linesclass = subGridnotitles_Class+"Uniform";
               }
            }
            else if ( subGridnotitles_Backcolorstyle == 2 )
            {
               /* Header style subfile background logic. */
               subGridnotitles_Backstyle = 1;
               if ( StringUtil.StrCmp(subGridnotitles_Class, "") != 0 )
               {
                  subGridnotitles_Linesclass = subGridnotitles_Class+"Odd";
               }
               subGridnotitles_Backcolor = (int)(0x0);
            }
            else if ( subGridnotitles_Backcolorstyle == 3 )
            {
               /* Report style subfile background logic. */
               subGridnotitles_Backstyle = 1;
               if ( ((int)((nGXsfl_41_idx) % (2))) == 0 )
               {
                  subGridnotitles_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnotitles_Class, "") != 0 )
                  {
                     subGridnotitles_Linesclass = subGridnotitles_Class+"Even";
                  }
               }
               else
               {
                  subGridnotitles_Backcolor = (int)(0x0);
                  if ( StringUtil.StrCmp(subGridnotitles_Class, "") != 0 )
                  {
                     subGridnotitles_Linesclass = subGridnotitles_Class+"Odd";
                  }
               }
            }
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<tr ") ;
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_41_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotitlesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavNotificationicon_Internalname,(string)AV6NotificationIcon,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavNotificationicon_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavNotificationicon_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)edtavNotificationicon_Format,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+"display:none;"+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotitlesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationiconclass_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1)).gxTpr_Notificationiconclass,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationiconclass_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)0,(int)edtavSdtnotificationsdata__notificationiconclass_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridnotitlesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationtitle_Internalname,((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1)).gxTpr_Notificationtitle,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationtitle_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationtitle_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)200,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridnotitlesContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "AttributeSecondary";
            GridnotitlesRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavSdtnotificationsdata__notificationdatetime_Internalname,context.localUtil.TToC( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1)).gxTpr_Notificationdatetime, 10, 8, 0, 3, "/", ":", " "),context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem)AV7SDTNotificationsData.Item(AV32GXV1)).gxTpr_Notificationdatetime, "99/99/99 99:99"),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavSdtnotificationsdata__notificationdatetime_Jsonclick,(short)0,(string)"AttributeSecondary",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavSdtnotificationsdata__notificationdatetime_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)14,(short)0,(short)0,(short)41,(short)0,(short)-1,(short)0,(bool)true,(string)"",(string)"end",(bool)false,(string)""});
            send_integrity_lvl_hashes0S2( ) ;
            GridnotitlesContainer.AddRow(GridnotitlesRow);
            nGXsfl_41_idx = ((subGridnotitles_Islastpage==1)&&(nGXsfl_41_idx+1>subGridnotitles_fnc_Recordsperpage( )) ? 1 : nGXsfl_41_idx+1);
            sGXsfl_41_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_41_idx), 4, 0), 4, "0");
            SubsflControlProps_412( ) ;
         }
         /* End function sendrow_412 */
      }

      protected void SubsflControlProps_623( )
      {
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME_"+sGXsfl_62_idx;
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE_"+sGXsfl_62_idx;
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS_"+sGXsfl_62_idx;
      }

      protected void SubsflControlProps_fel_623( )
      {
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME_"+sGXsfl_62_fel_idx;
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE_"+sGXsfl_62_fel_idx;
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS_"+sGXsfl_62_fel_idx;
      }

      protected void sendrow_623( )
      {
         SubsflControlProps_623( ) ;
         WB0S0( ) ;
         if ( ( subGrid_Rows * 1 == 0 ) || ( nGXsfl_62_idx <= subGrid_fnc_Recordsperpage( ) * 1 ) )
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
               if ( ((int)((nGXsfl_62_idx) % (2))) == 0 )
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
               context.WriteHtmlText( " class=\""+"WorkWith"+"\" style=\""+""+"\"") ;
               context.WriteHtmlText( " gxrow=\""+sGXsfl_62_idx+"\">") ;
            }
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"start"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomesampledata__productname_Internalname,((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productname,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomesampledata__productname_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavHomesampledata__productname_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)-1,(bool)false,(string)"",(string)"start",(bool)true,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            /* Single line edit */
            ROClassString = "Attribute";
            GridRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtavHomesampledata__productprice_Internalname,StringUtil.LTrim( StringUtil.NToC( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productprice, 11, 1, ",", "")),StringUtil.LTrim( ((edtavHomesampledata__productprice_Enabled!=0) ? context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productprice, "$ ZZZ,ZZ9.9") : context.localUtil.Format( ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productprice, "$ ZZZ,ZZ9.9"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtavHomesampledata__productprice_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"WWColumn",(string)"",(short)-1,(int)edtavHomesampledata__productprice_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)62,(short)0,(short)-1,(short)0,(bool)false,(string)"",(string)"end",(bool)false,(string)""});
            /* Subfile cell */
            if ( GridContainer.GetWrapped() == 1 )
            {
               context.WriteHtmlText( "<td valign=\"middle\" align=\""+"end"+"\""+" style=\""+""+"\">") ;
            }
            if ( ( cmbavHomesampledata__productstatus.ItemCount == 0 ) && isAjaxCallMode( ) )
            {
               GXCCtl = "HOMESAMPLEDATA__PRODUCTSTATUS_" + sGXsfl_62_idx;
               cmbavHomesampledata__productstatus.Name = GXCCtl;
               cmbavHomesampledata__productstatus.WebTags = "";
               cmbavHomesampledata__productstatus.addItem("1", "Available", 0);
               cmbavHomesampledata__productstatus.addItem("2", "Missing", 0);
               cmbavHomesampledata__productstatus.addItem("3", "Comming Soon", 0);
               cmbavHomesampledata__productstatus.addItem("4", "Ordered", 0);
               if ( cmbavHomesampledata__productstatus.ItemCount > 0 )
               {
                  if ( ( AV36GXV5 > 0 ) && ( AV5HomeSampleData.Count >= AV36GXV5 ) && (0==((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus) )
                  {
                     ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus = (short)(Math.Round(NumberUtil.Val( cmbavHomesampledata__productstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus), 1, 0))), "."), 18, MidpointRounding.ToEven));
                  }
               }
            }
            /* ComboBox */
            GridRow.AddColumnProperties("combobox", 2, isAjaxCallMode( ), new Object[] {(GXCombobox)cmbavHomesampledata__productstatus,(string)cmbavHomesampledata__productstatus_Internalname,StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus), 1, 0)),(short)1,(string)cmbavHomesampledata__productstatus_Jsonclick,(short)0,(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"int",(string)"",(short)-1,cmbavHomesampledata__productstatus.Enabled,(short)0,(short)0,(short)0,(string)"px",(short)0,(string)"px",(string)"",(string)"Attribute",(string)cmbavHomesampledata__productstatus_Columnclass,(string)cmbavHomesampledata__productstatus_Columnheaderclass,(string)"",(string)"",(bool)false,(short)0});
            cmbavHomesampledata__productstatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus), 1, 0));
            AssignProp("", false, cmbavHomesampledata__productstatus_Internalname, "Values", (string)(cmbavHomesampledata__productstatus.ToJavascriptSource()), !bGXsfl_62_Refreshing);
            send_integrity_lvl_hashes0S3( ) ;
            GridContainer.AddRow(GridRow);
            nGXsfl_62_idx = ((subGrid_Islastpage==1)&&(nGXsfl_62_idx+1>subGrid_fnc_Recordsperpage( )) ? 1 : nGXsfl_62_idx+1);
            sGXsfl_62_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_62_idx), 4, 0), 4, "0");
            SubsflControlProps_623( ) ;
         }
         /* End function sendrow_623 */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "HOMESAMPLEDATA__PRODUCTSTATUS_" + sGXsfl_62_idx;
         cmbavHomesampledata__productstatus.Name = GXCCtl;
         cmbavHomesampledata__productstatus.WebTags = "";
         cmbavHomesampledata__productstatus.addItem("1", "Available", 0);
         cmbavHomesampledata__productstatus.addItem("2", "Missing", 0);
         cmbavHomesampledata__productstatus.addItem("3", "Comming Soon", 0);
         cmbavHomesampledata__productstatus.addItem("4", "Ordered", 0);
         if ( cmbavHomesampledata__productstatus.ItemCount > 0 )
         {
            if ( ( AV36GXV5 > 0 ) && ( AV5HomeSampleData.Count >= AV36GXV5 ) && (0==((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus) )
            {
               ((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus = (short)(Math.Round(NumberUtil.Val( cmbavHomesampledata__productstatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(((GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem)AV5HomeSampleData.Item(AV36GXV5)).gxTpr_Productstatus), 1, 0))), "."), 18, MidpointRounding.ToEven));
            }
         }
         /* End function init_web_controls */
      }

      protected void StartGridControl41( )
      {
         if ( GridnotitlesContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridnotitlesContainer"+"DivS\" data-gxgridid=\"41\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGridnotitles_Internalname, subGridnotitles_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
            /* Subfile titles */
            context.WriteHtmlText( "<tr") ;
            context.WriteHtmlTextNl( ">") ;
            if ( subGridnotitles_Backcolorstyle == 0 )
            {
               subGridnotitles_Titlebackstyle = 0;
               if ( StringUtil.Len( subGridnotitles_Class) > 0 )
               {
                  subGridnotitles_Linesclass = subGridnotitles_Class+"Title";
               }
            }
            else
            {
               subGridnotitles_Titlebackstyle = 1;
               if ( subGridnotitles_Backcolorstyle == 1 )
               {
                  subGridnotitles_Titlebackcolor = subGridnotitles_Allbackcolor;
                  if ( StringUtil.Len( subGridnotitles_Class) > 0 )
                  {
                     subGridnotitles_Linesclass = subGridnotitles_Class+"UniformTitle";
                  }
               }
               else
               {
                  if ( StringUtil.Len( subGridnotitles_Class) > 0 )
                  {
                     subGridnotitles_Linesclass = subGridnotitles_Class+"Title";
                  }
               }
            }
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+"display:none;"+""+"\" "+">") ;
            context.SendWebValue( "Notification Icon Class") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Title") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"AttributeSecondary"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Notification Datetime") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridnotitlesContainer.AddObjectProperty("GridName", "Gridnotitles");
         }
         else
         {
            GridnotitlesContainer.AddObjectProperty("GridName", "Gridnotitles");
            GridnotitlesContainer.AddObjectProperty("Header", subGridnotitles_Header);
            GridnotitlesContainer.AddObjectProperty("Class", "WorkWith");
            GridnotitlesContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Backcolorstyle), 1, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("CmpContext", "");
            GridnotitlesContainer.AddObjectProperty("InMasterPage", "false");
            GridnotitlesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotitlesColumn.AddObjectProperty("Value", GXUtil.ValueEncode( AV6NotificationIcon));
            GridnotitlesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Enabled), 5, 0, ".", "")));
            GridnotitlesColumn.AddObjectProperty("Format", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavNotificationicon_Format), 4, 0, ".", "")));
            GridnotitlesContainer.AddColumnProperties(GridnotitlesColumn);
            GridnotitlesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotitlesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationiconclass_Enabled), 5, 0, ".", "")));
            GridnotitlesContainer.AddColumnProperties(GridnotitlesColumn);
            GridnotitlesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotitlesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationtitle_Enabled), 5, 0, ".", "")));
            GridnotitlesContainer.AddColumnProperties(GridnotitlesColumn);
            GridnotitlesColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridnotitlesColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavSdtnotificationsdata__notificationdatetime_Enabled), 5, 0, ".", "")));
            GridnotitlesContainer.AddColumnProperties(GridnotitlesColumn);
            GridnotitlesContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Selectedindex), 4, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Allowselection), 1, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Selectioncolor), 9, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Allowhovering), 1, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Hoveringcolor), 9, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Allowcollapsing), 1, 0, ".", "")));
            GridnotitlesContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridnotitles_Collapsed), 1, 0, ".", "")));
         }
      }

      protected void StartGridControl62( )
      {
         if ( GridContainer.GetWrapped() == 1 )
         {
            context.WriteHtmlText( "<div id=\""+"GridContainer"+"DivS\" data-gxgridid=\"62\">") ;
            sStyleString = "";
            GxWebStd.gx_table_start( context, subGrid_Internalname, subGrid_Internalname, "", "WorkWith", 0, "", "", 1, 2, sStyleString, "", "", 0);
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
            context.WriteHtmlText( "<th align=\""+"start"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Name") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Price") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlText( "<th align=\""+"end"+"\" "+" nowrap=\"nowrap\" "+" class=\""+"Attribute"+"\" "+" style=\""+""+""+"\" "+">") ;
            context.SendWebValue( "Status") ;
            context.WriteHtmlTextNl( "</th>") ;
            context.WriteHtmlTextNl( "</tr>") ;
            GridContainer.AddObjectProperty("GridName", "Grid");
         }
         else
         {
            GridContainer.AddObjectProperty("GridName", "Grid");
            GridContainer.AddObjectProperty("Header", subGrid_Header);
            GridContainer.AddObjectProperty("Class", "WorkWith");
            GridContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
            GridContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGrid_Backcolorstyle), 1, 0, ".", "")));
            GridContainer.AddObjectProperty("CmpContext", "");
            GridContainer.AddObjectProperty("InMasterPage", "false");
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomesampledata__productname_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtavHomesampledata__productprice_Enabled), 5, 0, ".", "")));
            GridContainer.AddColumnProperties(GridColumn);
            GridColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
            GridColumn.AddObjectProperty("Columnclass", StringUtil.RTrim( cmbavHomesampledata__productstatus_Columnclass));
            GridColumn.AddObjectProperty("Columnheaderclass", StringUtil.RTrim( cmbavHomesampledata__productstatus_Columnheaderclass));
            GridColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(cmbavHomesampledata__productstatus.Enabled), 5, 0, ".", "")));
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
         Progress1_progress_Internalname = "PROGRESS1_PROGRESS";
         tblProgress1_tablemain_Internalname = "PROGRESS1_TABLEMAIN";
         Progress2_progress_Internalname = "PROGRESS2_PROGRESS";
         tblProgress2_tablemain_Internalname = "PROGRESS2_TABLEMAIN";
         Progress3_progress_Internalname = "PROGRESS3_PROGRESS";
         tblProgress3_tablemain_Internalname = "PROGRESS3_TABLEMAIN";
         divTableprogresscards_Internalname = "TABLEPROGRESSCARDS";
         Utchartcolumnline_Internalname = "UTCHARTCOLUMNLINE";
         divTablecards_Internalname = "TABLECARDS";
         Dvpanel_tablecards_Internalname = "DVPANEL_TABLECARDS";
         lblNotificationssubtitle_Internalname = "NOTIFICATIONSSUBTITLE";
         edtavNotificationicon_Internalname = "vNOTIFICATIONICON";
         edtavSdtnotificationsdata__notificationiconclass_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONICONCLASS";
         edtavSdtnotificationsdata__notificationtitle_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONTITLE";
         edtavSdtnotificationsdata__notificationdatetime_Internalname = "SDTNOTIFICATIONSDATA__NOTIFICATIONDATETIME";
         divTablenotifications_Internalname = "TABLENOTIFICATIONS";
         Dvpanel_tablenotifications_Internalname = "DVPANEL_TABLENOTIFICATIONS";
         Utchartsmootharea_Internalname = "UTCHARTSMOOTHAREA";
         divTablechart1_Internalname = "TABLECHART1";
         Dvpanel_tablechart1_Internalname = "DVPANEL_TABLECHART1";
         Utchartsmoothline_Internalname = "UTCHARTSMOOTHLINE";
         divTablechart4_Internalname = "TABLECHART4";
         Dvpanel_tablechart4_Internalname = "DVPANEL_TABLECHART4";
         edtavHomesampledata__productname_Internalname = "HOMESAMPLEDATA__PRODUCTNAME";
         edtavHomesampledata__productprice_Internalname = "HOMESAMPLEDATA__PRODUCTPRICE";
         cmbavHomesampledata__productstatus_Internalname = "HOMESAMPLEDATA__PRODUCTSTATUS";
         divTablemain_Internalname = "TABLEMAIN";
         Grid_empowerer_Internalname = "GRID_EMPOWERER";
         Gridnotitles_empowerer_Internalname = "GRIDNOTITLES_EMPOWERER";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridnotitles_Internalname = "GRIDNOTITLES";
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
         subGridnotitles_Allowcollapsing = 0;
         subGridnotitles_Allowselection = 0;
         subGridnotitles_Header = "";
         cmbavHomesampledata__productstatus_Jsonclick = "";
         cmbavHomesampledata__productstatus.Enabled = 0;
         cmbavHomesampledata__productstatus_Columnheaderclass = "";
         cmbavHomesampledata__productstatus_Columnclass = "WWColumn";
         edtavHomesampledata__productprice_Jsonclick = "";
         edtavHomesampledata__productprice_Enabled = 0;
         edtavHomesampledata__productname_Jsonclick = "";
         edtavHomesampledata__productname_Enabled = 0;
         subGrid_Class = "WorkWith";
         subGrid_Backcolorstyle = 0;
         edtavSdtnotificationsdata__notificationdatetime_Jsonclick = "";
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Jsonclick = "";
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Jsonclick = "";
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavNotificationicon_Jsonclick = "";
         edtavNotificationicon_Enabled = 0;
         edtavNotificationicon_Format = 1;
         subGridnotitles_Class = "WorkWith";
         subGridnotitles_Backcolorstyle = 0;
         cmbavHomesampledata__productstatus.Enabled = -1;
         edtavHomesampledata__productprice_Enabled = -1;
         edtavHomesampledata__productname_Enabled = -1;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = -1;
         edtavSdtnotificationsdata__notificationtitle_Enabled = -1;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = -1;
         Utchartsmoothline_Title = "";
         divTablechart4_Height = 0;
         Utchartsmootharea_Title = "";
         divTablechart1_Height = 0;
         lblNotificationssubtitle_Caption = "Você têm %1 novas notificações";
         Utchartcolumnline_Title = "";
         Dvpanel_tablechart4_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Iconposition = "Right";
         Dvpanel_tablechart4_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Title = "Task Board";
         Dvpanel_tablechart4_Cls = "PanelCard_GrayTitle";
         Dvpanel_tablechart4_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart4_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart4_Width = "100%";
         Utchartsmoothline_Charttype = "SmoothLine";
         Utchartsmoothline_Type = "Chart";
         Utchartsmoothline_Height = "450px";
         Dvpanel_tablechart1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Iconposition = "Right";
         Dvpanel_tablechart1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Title = "Sales Table";
         Dvpanel_tablechart1_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tablechart1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablechart1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablechart1_Width = "100%";
         Utchartsmootharea_Charttype = "StackedArea";
         Utchartsmootharea_Type = "Chart";
         Dvpanel_tablenotifications_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Iconposition = "Right";
         Dvpanel_tablenotifications_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Title = "Notificações";
         Dvpanel_tablenotifications_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tablenotifications_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablenotifications_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablenotifications_Width = "100%";
         Dvpanel_tablecards_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Iconposition = "Right";
         Dvpanel_tablecards_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Title = "";
         Dvpanel_tablecards_Cls = "PanelNoHeader";
         Dvpanel_tablecards_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablecards_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablecards_Width = "100%";
         Utchartcolumnline_Plotseries = "";
         Utchartcolumnline_Charttype = "ColumnLine";
         Utchartcolumnline_Type = "Chart";
         Utchartcolumnline_Height = "248px";
         Utchartcolumnline_Class = "QueryViewerBar QueryViewer";
         Progress3_progress_Circlewidth = 180;
         Progress3_progress_Percentage = 20;
         Progress3_progress_Cls = "ProgressBigCircle ProgressBigCircleBaseColor";
         Progress3_progress_Subtitle = "Active Customers";
         Progress3_progress_Caption = "3,154";
         Progress3_progress_Circlecaptiontype = "CaptionAndSubtitle";
         Progress2_progress_Circlewidth = 180;
         Progress2_progress_Percentage = 20;
         Progress2_progress_Cls = "ProgressBigCircle ProgressBigCircleBaseColor";
         Progress2_progress_Subtitle = "New Issues";
         Progress2_progress_Caption = "3,154";
         Progress2_progress_Circlecaptiontype = "CaptionAndSubtitle";
         Progress1_progress_Circlewidth = 180;
         Progress1_progress_Percentage = 20;
         Progress1_progress_Cls = "ProgressBigCircle ProgressBigCircleBaseColor";
         Progress1_progress_Subtitle = "Applications";
         Progress1_progress_Caption = "3,154";
         Progress1_progress_Circlecaptiontype = "CaptionAndSubtitle";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Inicio";
         subGrid_Rows = 0;
         subGridnotitles_Rows = 0;
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'GRIDNOTITLES_nEOF'},{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("REFRESH",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID.LOAD","{handler:'E140S3',iparms:[{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("GRID.LOAD",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnclass'}]}");
         setEventMetadata("GRIDNOTITLES.LOAD","{handler:'E130S2',iparms:[{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41}]");
         setEventMetadata("GRIDNOTITLES.LOAD",",oparms:[{av:'edtavNotificationicon_Format',ctrl:'vNOTIFICATIONICON',prop:'Format'},{av:'AV6NotificationIcon',fld:'vNOTIFICATIONICON',pic:''}]}");
         setEventMetadata("GRIDNOTITLES_FIRSTPAGE","{handler:'subgridnotitles_firstpage',iparms:[{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'GRIDNOTITLES_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("GRIDNOTITLES_FIRSTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTITLES_PREVPAGE","{handler:'subgridnotitles_previouspage',iparms:[{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'GRIDNOTITLES_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("GRIDNOTITLES_PREVPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTITLES_NEXTPAGE","{handler:'subgridnotitles_nextpage',iparms:[{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'GRIDNOTITLES_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("GRIDNOTITLES_NEXTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRIDNOTITLES_LASTPAGE","{handler:'subgridnotitles_lastpage',iparms:[{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'GRIDNOTITLES_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'GRID_nFirstRecordOnPage'},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62}]");
         setEventMetadata("GRIDNOTITLES_LASTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_FIRSTPAGE","{handler:'subgrid_firstpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41}]");
         setEventMetadata("GRID_FIRSTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_PREVPAGE","{handler:'subgrid_previouspage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41}]");
         setEventMetadata("GRID_PREVPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_NEXTPAGE","{handler:'subgrid_nextpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41}]");
         setEventMetadata("GRID_NEXTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("GRID_LASTPAGE","{handler:'subgrid_lastpage',iparms:[{av:'GRID_nFirstRecordOnPage'},{av:'GRID_nEOF'},{av:'subGridnotitles_Rows',ctrl:'GRIDNOTITLES',prop:'Rows'},{av:'subGrid_Rows',ctrl:'GRID',prop:'Rows'},{av:'AV5HomeSampleData',fld:'vHOMESAMPLEDATA',grid:62,pic:'',hsh:true},{av:'nGXsfl_62_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:62},{av:'nRC_GXsfl_62',ctrl:'GRID',prop:'GridRC',grid:62},{av:'AV7SDTNotificationsData',fld:'vSDTNOTIFICATIONSDATA',grid:41,pic:'',hsh:true},{av:'nGXsfl_41_idx', ctrl: 'GRID', prop:'GridCurrRow', grid:41},{av:'GRIDNOTITLES_nFirstRecordOnPage'},{av:'nRC_GXsfl_41',ctrl:'GRIDNOTITLES',prop:'GridRC',grid:41}]");
         setEventMetadata("GRID_LASTPAGE",",oparms:[{ctrl:'HOMESAMPLEDATA__PRODUCTSTATUS',prop:'Columnheaderclass'}]}");
         setEventMetadata("NULL","{handler:'Validv_Gxv4',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
         setEventMetadata("VALIDV_GXV8","{handler:'Validv_Gxv8',iparms:[]");
         setEventMetadata("VALIDV_GXV8",",oparms:[]}");
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
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         AV7SDTNotificationsData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "agl_tresorygroup");
         AV5HomeSampleData = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "agl_tresorygroup");
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         AV20Elements = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         Grid_empowerer_Gridinternalname = "";
         Gridnotitles_empowerer_Gridinternalname = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tablecards = new GXUserControl();
         ucUtchartcolumnline = new GXUserControl();
         ucDvpanel_tablenotifications = new GXUserControl();
         lblNotificationssubtitle_Jsonclick = "";
         GridnotitlesContainer = new GXWebGrid( context);
         sStyleString = "";
         ucDvpanel_tablechart1 = new GXUserControl();
         ucUtchartsmootharea = new GXUserControl();
         ucDvpanel_tablechart4 = new GXUserControl();
         ucUtchartsmoothline = new GXUserControl();
         GridContainer = new GXWebGrid( context);
         ucGrid_empowerer = new GXUserControl();
         ucGridnotitles_empowerer = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         AV6NotificationIcon = "";
         AV40Pgmname = "";
         GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem>( context, "HomeSampleDataItem", "agl_tresorygroup");
         AV13Axis = new GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element(context);
         AV12Axes = new GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element>( context, "Element", "GeneXus.Reporting");
         GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem2 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem>( context, "WWP_SDTNotificationsDataItem", "agl_tresorygroup");
         ucProgress1_progress = new GXUserControl();
         ucProgress2_progress = new GXUserControl();
         ucProgress3_progress = new GXUserControl();
         GridnotitlesRow = new GXWebRow();
         GridRow = new GXWebRow();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         subGridnotitles_Linesclass = "";
         ROClassString = "";
         subGrid_Linesclass = "";
         GXCCtl = "";
         GridnotitlesColumn = new GXWebColumn();
         GridColumn = new GXWebColumn();
         AV40Pgmname = "Home";
         /* GeneXus formulas. */
         AV40Pgmname = "Home";
         edtavNotificationicon_Enabled = 0;
         edtavSdtnotificationsdata__notificationiconclass_Enabled = 0;
         edtavSdtnotificationsdata__notificationtitle_Enabled = 0;
         edtavSdtnotificationsdata__notificationdatetime_Enabled = 0;
         edtavHomesampledata__productname_Enabled = 0;
         edtavHomesampledata__productprice_Enabled = 0;
         cmbavHomesampledata__productstatus.Enabled = 0;
      }

      private short GRIDNOTITLES_nEOF ;
      private short GRID_nEOF ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short nGXWrapped ;
      private short AV21Parameters ;
      private short AV22ItemClickData ;
      private short AV23ItemDoubleClickData ;
      private short AV24DragAndDropData ;
      private short AV25FilterChangedData ;
      private short AV26ItemExpandData ;
      private short AV27ItemCollapseData ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short subGridnotitles_Backcolorstyle ;
      private short subGrid_Backcolorstyle ;
      private short AV8Card1_Value ;
      private short AV11Card4_Value ;
      private short AV15Progress1_PercentageValue ;
      private short AV17Progress2_PercentageValue ;
      private short AV19Progress3_PercentageValue ;
      private short edtavNotificationicon_Format ;
      private short subGridnotitles_Backstyle ;
      private short subGrid_Backstyle ;
      private short subGridnotitles_Titlebackstyle ;
      private short subGridnotitles_Allowselection ;
      private short subGridnotitles_Allowhovering ;
      private short subGridnotitles_Allowcollapsing ;
      private short subGridnotitles_Collapsed ;
      private short subGrid_Titlebackstyle ;
      private short subGrid_Allowselection ;
      private short subGrid_Allowhovering ;
      private short subGrid_Allowcollapsing ;
      private short subGrid_Collapsed ;
      private int nRC_GXsfl_41 ;
      private int nRC_GXsfl_62 ;
      private int subGridnotitles_Rows ;
      private int subGrid_Rows ;
      private int nGXsfl_41_idx=1 ;
      private int nGXsfl_62_idx=1 ;
      private int Progress1_progress_Percentage ;
      private int Progress1_progress_Circlewidth ;
      private int Progress2_progress_Percentage ;
      private int Progress2_progress_Circlewidth ;
      private int Progress3_progress_Percentage ;
      private int Progress3_progress_Circlewidth ;
      private int AV32GXV1 ;
      private int divTablechart1_Height ;
      private int divTablechart4_Height ;
      private int AV36GXV5 ;
      private int subGridnotitles_Islastpage ;
      private int subGrid_Islastpage ;
      private int edtavNotificationicon_Enabled ;
      private int edtavSdtnotificationsdata__notificationiconclass_Enabled ;
      private int edtavSdtnotificationsdata__notificationtitle_Enabled ;
      private int edtavSdtnotificationsdata__notificationdatetime_Enabled ;
      private int edtavHomesampledata__productname_Enabled ;
      private int edtavHomesampledata__productprice_Enabled ;
      private int GRIDNOTITLES_nGridOutOfScope ;
      private int GRID_nGridOutOfScope ;
      private int nGXsfl_41_fel_idx=1 ;
      private int nGXsfl_62_fel_idx=1 ;
      private int AV9Card2_Value ;
      private int AV10Card3_Value ;
      private int AV14Progress1_Value ;
      private int AV16Progress2_Value ;
      private int AV18Progress3_Value ;
      private int idxLst ;
      private int subGridnotitles_Backcolor ;
      private int subGridnotitles_Allbackcolor ;
      private int subGrid_Backcolor ;
      private int subGrid_Allbackcolor ;
      private int subGridnotitles_Titlebackcolor ;
      private int subGridnotitles_Selectedindex ;
      private int subGridnotitles_Selectioncolor ;
      private int subGridnotitles_Hoveringcolor ;
      private int subGrid_Titlebackcolor ;
      private int subGrid_Selectedindex ;
      private int subGrid_Selectioncolor ;
      private int subGrid_Hoveringcolor ;
      private long GRIDNOTITLES_nFirstRecordOnPage ;
      private long GRID_nFirstRecordOnPage ;
      private long GRIDNOTITLES_nCurrentRecord ;
      private long GRID_nCurrentRecord ;
      private long GRIDNOTITLES_nRecordCount ;
      private long GRID_nRecordCount ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sGXsfl_41_idx="0001" ;
      private string sGXsfl_62_idx="0001" ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string Progress1_progress_Circlecaptiontype ;
      private string Progress1_progress_Caption ;
      private string Progress1_progress_Subtitle ;
      private string Progress1_progress_Cls ;
      private string Progress2_progress_Circlecaptiontype ;
      private string Progress2_progress_Caption ;
      private string Progress2_progress_Subtitle ;
      private string Progress2_progress_Cls ;
      private string Progress3_progress_Circlecaptiontype ;
      private string Progress3_progress_Caption ;
      private string Progress3_progress_Subtitle ;
      private string Progress3_progress_Cls ;
      private string Utchartcolumnline_Class ;
      private string Utchartcolumnline_Height ;
      private string Utchartcolumnline_Type ;
      private string Utchartcolumnline_Charttype ;
      private string Utchartcolumnline_Plotseries ;
      private string Dvpanel_tablecards_Width ;
      private string Dvpanel_tablecards_Cls ;
      private string Dvpanel_tablecards_Title ;
      private string Dvpanel_tablecards_Iconposition ;
      private string Dvpanel_tablenotifications_Width ;
      private string Dvpanel_tablenotifications_Cls ;
      private string Dvpanel_tablenotifications_Title ;
      private string Dvpanel_tablenotifications_Iconposition ;
      private string Utchartsmootharea_Type ;
      private string Utchartsmootharea_Charttype ;
      private string Dvpanel_tablechart1_Width ;
      private string Dvpanel_tablechart1_Cls ;
      private string Dvpanel_tablechart1_Title ;
      private string Dvpanel_tablechart1_Iconposition ;
      private string Utchartsmoothline_Height ;
      private string Utchartsmoothline_Type ;
      private string Utchartsmoothline_Charttype ;
      private string Dvpanel_tablechart4_Width ;
      private string Dvpanel_tablechart4_Cls ;
      private string Dvpanel_tablechart4_Title ;
      private string Dvpanel_tablechart4_Iconposition ;
      private string Grid_empowerer_Gridinternalname ;
      private string Gridnotitles_empowerer_Gridinternalname ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string Dvpanel_tablecards_Internalname ;
      private string divTablecards_Internalname ;
      private string divTableprogresscards_Internalname ;
      private string Utchartcolumnline_Title ;
      private string Utchartcolumnline_Internalname ;
      private string Dvpanel_tablenotifications_Internalname ;
      private string divTablenotifications_Internalname ;
      private string lblNotificationssubtitle_Internalname ;
      private string lblNotificationssubtitle_Caption ;
      private string lblNotificationssubtitle_Jsonclick ;
      private string sStyleString ;
      private string subGridnotitles_Internalname ;
      private string Dvpanel_tablechart1_Internalname ;
      private string divTablechart1_Internalname ;
      private string Utchartsmootharea_Title ;
      private string Utchartsmootharea_Internalname ;
      private string Dvpanel_tablechart4_Internalname ;
      private string divTablechart4_Internalname ;
      private string Utchartsmoothline_Title ;
      private string Utchartsmoothline_Internalname ;
      private string subGrid_Internalname ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Grid_empowerer_Internalname ;
      private string Gridnotitles_empowerer_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string edtavNotificationicon_Internalname ;
      private string AV40Pgmname ;
      private string edtavSdtnotificationsdata__notificationiconclass_Internalname ;
      private string edtavSdtnotificationsdata__notificationtitle_Internalname ;
      private string edtavSdtnotificationsdata__notificationdatetime_Internalname ;
      private string edtavHomesampledata__productname_Internalname ;
      private string edtavHomesampledata__productprice_Internalname ;
      private string cmbavHomesampledata__productstatus_Internalname ;
      private string sGXsfl_41_fel_idx="0001" ;
      private string sGXsfl_62_fel_idx="0001" ;
      private string Progress1_progress_Internalname ;
      private string Progress2_progress_Internalname ;
      private string Progress3_progress_Internalname ;
      private string cmbavHomesampledata__productstatus_Columnheaderclass ;
      private string cmbavHomesampledata__productstatus_Columnclass ;
      private string tblProgress3_tablemain_Internalname ;
      private string tblProgress2_tablemain_Internalname ;
      private string tblProgress1_tablemain_Internalname ;
      private string subGridnotitles_Class ;
      private string subGridnotitles_Linesclass ;
      private string ROClassString ;
      private string edtavNotificationicon_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationiconclass_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationtitle_Jsonclick ;
      private string edtavSdtnotificationsdata__notificationdatetime_Jsonclick ;
      private string subGrid_Class ;
      private string subGrid_Linesclass ;
      private string edtavHomesampledata__productname_Jsonclick ;
      private string edtavHomesampledata__productprice_Jsonclick ;
      private string GXCCtl ;
      private string cmbavHomesampledata__productstatus_Jsonclick ;
      private string subGridnotitles_Header ;
      private string subGrid_Header ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablecards_Autowidth ;
      private bool Dvpanel_tablecards_Autoheight ;
      private bool Dvpanel_tablecards_Collapsible ;
      private bool Dvpanel_tablecards_Collapsed ;
      private bool Dvpanel_tablecards_Showcollapseicon ;
      private bool Dvpanel_tablecards_Autoscroll ;
      private bool Dvpanel_tablenotifications_Autowidth ;
      private bool Dvpanel_tablenotifications_Autoheight ;
      private bool Dvpanel_tablenotifications_Collapsible ;
      private bool Dvpanel_tablenotifications_Collapsed ;
      private bool Dvpanel_tablenotifications_Showcollapseicon ;
      private bool Dvpanel_tablenotifications_Autoscroll ;
      private bool Dvpanel_tablechart1_Autowidth ;
      private bool Dvpanel_tablechart1_Autoheight ;
      private bool Dvpanel_tablechart1_Collapsible ;
      private bool Dvpanel_tablechart1_Collapsed ;
      private bool Dvpanel_tablechart1_Showcollapseicon ;
      private bool Dvpanel_tablechart1_Autoscroll ;
      private bool Dvpanel_tablechart4_Autowidth ;
      private bool Dvpanel_tablechart4_Autoheight ;
      private bool Dvpanel_tablechart4_Collapsible ;
      private bool Dvpanel_tablechart4_Collapsed ;
      private bool Dvpanel_tablechart4_Showcollapseicon ;
      private bool Dvpanel_tablechart4_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool bGXsfl_41_Refreshing=false ;
      private bool bGXsfl_62_Refreshing=false ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool gx_BV62 ;
      private bool gx_BV41 ;
      private bool gx_refresh_fired ;
      private string AV6NotificationIcon ;
      private GXWebGrid GridnotitlesContainer ;
      private GXWebGrid GridContainer ;
      private GXWebRow GridnotitlesRow ;
      private GXWebRow GridRow ;
      private GXWebColumn GridnotitlesColumn ;
      private GXWebColumn GridColumn ;
      private GXUserControl ucDvpanel_tablecards ;
      private GXUserControl ucUtchartcolumnline ;
      private GXUserControl ucDvpanel_tablenotifications ;
      private GXUserControl ucDvpanel_tablechart1 ;
      private GXUserControl ucUtchartsmootharea ;
      private GXUserControl ucDvpanel_tablechart4 ;
      private GXUserControl ucUtchartsmoothline ;
      private GXUserControl ucGrid_empowerer ;
      private GXUserControl ucGridnotitles_empowerer ;
      private GXUserControl ucProgress1_progress ;
      private GXUserControl ucProgress2_progress ;
      private GXUserControl ucProgress3_progress ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavHomesampledata__productstatus ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> AV5HomeSampleData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtHomeSampleData_HomeSampleDataItem> GXt_objcol_SdtHomeSampleData_HomeSampleDataItem1 ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> AV7SDTNotificationsData ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem> GXt_objcol_SdtWWP_SDTNotificationsData_WWP_SDTNotificationsDataItem2 ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV20Elements ;
      private GXBaseCollection<GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element> AV12Axes ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexusreporting.SdtQueryViewerElements_Element AV13Axis ;
   }

}
