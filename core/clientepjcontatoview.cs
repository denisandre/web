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
namespace GeneXus.Programs.core {
   public class clientepjcontatoview : GXDataArea
   {
      public clientepjcontatoview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjcontatoview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_CliID ,
                           Guid aP1_CpjID ,
                           short aP2_CpjConSeq ,
                           string aP3_TabCode )
      {
         this.AV10CliID = aP0_CliID;
         this.AV11CpjID = aP1_CpjID;
         this.AV12CpjConSeq = aP2_CpjConSeq;
         this.AV8TabCode = aP3_TabCode;
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
            gxfirstwebparm = GetFirstPar( "CliID");
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
               gxfirstwebparm = GetFirstPar( "CliID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "CliID");
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
            return "clientepjcontatoview_Execute" ;
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
         PA4R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START4R2( ) ;
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         GXEncryptionTmp = "core.clientepjcontatoview.aspx"+UrlEncode(AV10CliID.ToString()) + "," + UrlEncode(AV11CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV12CpjConSeq,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjcontatoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         GxWebStd.gx_hidden_field( context, "vCLIID", AV10CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV10CliID, context));
         GxWebStd.gx_hidden_field( context, "vCPJID", AV11CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV11CpjID, context));
         GxWebStd.gx_hidden_field( context, "vCPJCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12CpjConSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "CLIID", A158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "CPJID", A166CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "CPJCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A269CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "vLOADALLTABS", AV13LoadAllTabs);
         GxWebStd.gx_hidden_field( context, "vSELECTEDTABCODE", StringUtil.RTrim( AV14SelectedTabCode));
         GxWebStd.gx_hidden_field( context, "vCLIID", AV10CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV10CliID, context));
         GxWebStd.gx_hidden_field( context, "vCPJID", AV11CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV11CpjID, context));
         GxWebStd.gx_hidden_field( context, "vCPJCONSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV12CpjConSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12CpjConSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icontype", StringUtil.RTrim( Ddc_subscriptions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Icon", StringUtil.RTrim( Ddc_subscriptions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Tooltip", StringUtil.RTrim( Ddc_subscriptions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Cls", StringUtil.RTrim( Ddc_subscriptions_Cls));
         GxWebStd.gx_hidden_field( context, "DDC_SUBSCRIPTIONS_Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icontype", StringUtil.RTrim( Ddc_discussions_Icontype));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Icon", StringUtil.RTrim( Ddc_discussions_Icon));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Tooltip", StringUtil.RTrim( Ddc_discussions_Tooltip));
         GxWebStd.gx_hidden_field( context, "DDC_DISCUSSIONS_Cls", StringUtil.RTrim( Ddc_discussions_Cls));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TABS_Class", StringUtil.RTrim( Tabs_Class));
         GxWebStd.gx_hidden_field( context, "TABS_Historymanagement", StringUtil.BoolToStr( Tabs_Historymanagement));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
         GxWebStd.gx_hidden_field( context, "TABS_Activepagecontrolname", StringUtil.RTrim( Tabs_Activepagecontrolname));
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
         if ( ! ( WebComp_Generalwc == null ) )
         {
            WebComp_Generalwc.componentjscripts();
         }
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
            WE4R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT4R2( ) ;
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
         GXEncryptionTmp = "core.clientepjcontatoview.aspx"+UrlEncode(AV10CliID.ToString()) + "," + UrlEncode(AV11CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV12CpjConSeq,4,0)) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("core.clientepjcontatoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJContatoView" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente PJContato View" ;
      }

      protected void WB4R0( )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellWWLink", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableviewrightitems_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblWorkwithlink_Internalname, "Ir a Contato", lblWorkwithlink_Link, "", lblWorkwithlink_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockLink", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoView.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_subscriptions.SetProperty("IconType", Ddc_subscriptions_Icontype);
            ucDdc_subscriptions.SetProperty("Icon", Ddc_subscriptions_Icon);
            ucDdc_subscriptions.SetProperty("Caption", Ddc_subscriptions_Caption);
            ucDdc_subscriptions.SetProperty("Tooltip", Ddc_subscriptions_Tooltip);
            ucDdc_subscriptions.SetProperty("Cls", Ddc_subscriptions_Cls);
            ucDdc_subscriptions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_subscriptions_Internalname, "DDC_SUBSCRIPTIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "ViewCellRightItem", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDdc_discussions.SetProperty("IconType", Ddc_discussions_Icontype);
            ucDdc_discussions.SetProperty("Icon", Ddc_discussions_Icon);
            ucDdc_discussions.SetProperty("Caption", Ddc_discussions_Caption);
            ucDdc_discussions.SetProperty("Tooltip", Ddc_discussions_Tooltip);
            ucDdc_discussions.SetProperty("Cls", Ddc_discussions_Cls);
            ucDdc_discussions.Render(context, "dvelop.gxbootstrap.ddcomponent", Ddc_discussions_Internalname, "DDC_DISCUSSIONSContainer");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition TabsWithRightActions", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtableviewcontainer_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTab", "start", "top", "", "", "div");
            /* User Defined Control */
            ucTabs.SetProperty("PageCount", Tabs_Pagecount);
            ucTabs.SetProperty("Class", Tabs_Class);
            ucTabs.SetProperty("HistoryManagement", Tabs_Historymanagement);
            ucTabs.Render(context, "tab", Tabs_Internalname, "TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Detalhes", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_core\\ClientePJContatoView.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtablegeneral_Internalname, 1, 0, "px", 0, "px", "TableViewTab", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0029"+"", StringUtil.RTrim( WebComp_Generalwc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0029"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
                  }
                  WebComp_Generalwc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldGeneralwc), StringUtil.Lower( WebComp_Generalwc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
                  }
               }
               context.WriteHtmlText( "</div>") ;
            }
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
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
            /* Div Control */
            GxWebStd.gx_div_start( context, divDiv_wwpauxwc_Internalname, 1, 0, "px", 0, "px", "Invisible", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0034"+"", StringUtil.RTrim( WebComp_Wwpaux_wc_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0034"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
                  }
                  WebComp_Wwpaux_wc.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWwpaux_wc), StringUtil.Lower( WebComp_Wwpaux_wc_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspEndCmp();
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
         wbLoad = true;
      }

      protected void START4R2( )
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
            Form.Meta.addItem("description", "Cliente PJContato View", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP4R0( ) ;
      }

      protected void WS4R2( )
      {
         START4R2( ) ;
         EVT4R2( ) ;
      }

      protected void EVT4R2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "DDC_SUBSCRIPTIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E114R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "DDC_DISCUSSIONS.ONLOADCOMPONENT") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E124R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "TABS.TABCHANGED") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E134R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E144R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "REFRESH") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Refresh */
                              E154R2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E164R2 ();
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
                              dynload_actions( ) ;
                           }
                        }
                        else
                        {
                        }
                     }
                     else if ( StringUtil.StrCmp(sEvtType, "W") == 0 )
                     {
                        sEvtType = StringUtil.Left( sEvt, 4);
                        sEvt = StringUtil.Right( sEvt, (short)(StringUtil.Len( sEvt)-4));
                        nCmpId = (short)(Math.Round(NumberUtil.Val( sEvtType, "."), 18, MidpointRounding.ToEven));
                        if ( nCmpId == 29 )
                        {
                           OldGeneralwc = cgiGet( "W0029");
                           if ( ( StringUtil.Len( OldGeneralwc) == 0 ) || ( StringUtil.StrCmp(OldGeneralwc, WebComp_Generalwc_Component) != 0 ) )
                           {
                              WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", OldGeneralwc, new Object[] {context} );
                              WebComp_Generalwc.ComponentInit();
                              WebComp_Generalwc.Name = "OldGeneralwc";
                              WebComp_Generalwc_Component = OldGeneralwc;
                           }
                           if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
                           {
                              WebComp_Generalwc.componentprocess("W0029", "", sEvt);
                           }
                           WebComp_Generalwc_Component = OldGeneralwc;
                        }
                        else if ( nCmpId == 34 )
                        {
                           OldWwpaux_wc = cgiGet( "W0034");
                           if ( ( StringUtil.Len( OldWwpaux_wc) == 0 ) || ( StringUtil.StrCmp(OldWwpaux_wc, WebComp_Wwpaux_wc_Component) != 0 ) )
                           {
                              WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", OldWwpaux_wc, new Object[] {context} );
                              WebComp_Wwpaux_wc.ComponentInit();
                              WebComp_Wwpaux_wc.Name = "OldWwpaux_wc";
                              WebComp_Wwpaux_wc_Component = OldWwpaux_wc;
                           }
                           if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
                           {
                              WebComp_Wwpaux_wc.componentprocess("W0034", "", sEvt);
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

      protected void WE4R2( )
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

      protected void PA4R2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjcontatoview.aspx")), "core.clientepjcontatoview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjcontatoview.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "CliID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10CliID = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV10CliID", AV10CliID.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV10CliID, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV11CpjID = StringUtil.StrToGuid( GetPar( "CpjID"));
                        AssignAttri("", false, "AV11CpjID", AV11CpjID.ToString());
                        GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV11CpjID, context));
                        AV12CpjConSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "CpjConSeq"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV12CpjConSeq", StringUtil.LTrimStr( (decimal)(AV12CpjConSeq), 4, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12CpjConSeq), "ZZZ9"), context));
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
                        GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
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
         RF4R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF4R2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         /* Execute user event: Refresh */
         E154R2 ();
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
               {
                  WebComp_Generalwc.componentstart();
               }
            }
         }
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
            /* Using cursor H004R2 */
            pr_default.execute(0, new Object[] {AV10CliID, AV11CpjID, AV12CpjConSeq});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A269CpjConSeq = H004R2_A269CpjConSeq[0];
               A166CpjID = H004R2_A166CpjID[0];
               A158CliID = H004R2_A158CliID[0];
               /* Execute user event: Load */
               E164R2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB4R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes4R2( )
      {
         GxWebStd.gx_hidden_field( context, "vRECORDDESCRIPTION", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP4R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E144R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Ddc_subscriptions_Icontype = cgiGet( "DDC_SUBSCRIPTIONS_Icontype");
            Ddc_subscriptions_Icon = cgiGet( "DDC_SUBSCRIPTIONS_Icon");
            Ddc_subscriptions_Tooltip = cgiGet( "DDC_SUBSCRIPTIONS_Tooltip");
            Ddc_subscriptions_Cls = cgiGet( "DDC_SUBSCRIPTIONS_Cls");
            Ddc_subscriptions_Visible = StringUtil.StrToBool( cgiGet( "DDC_SUBSCRIPTIONS_Visible"));
            Ddc_discussions_Icontype = cgiGet( "DDC_DISCUSSIONS_Icontype");
            Ddc_discussions_Icon = cgiGet( "DDC_DISCUSSIONS_Icon");
            Ddc_discussions_Tooltip = cgiGet( "DDC_DISCUSSIONS_Tooltip");
            Ddc_discussions_Cls = cgiGet( "DDC_DISCUSSIONS_Cls");
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            Tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TABS_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Tabs_Class = cgiGet( "TABS_Class");
            Tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "TABS_Historymanagement"));
            Tabs_Activepagecontrolname = cgiGet( "TABS_Activepagecontrolname");
            /* Read variables values. */
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E144R2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E144R2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         lblWorkwithlink_Link = formatLink("core.clientepjcontatoww.aspx") ;
         AssignProp("", false, lblWorkwithlink_Internalname, "Link", lblWorkwithlink_Link, true);
         AV18GXLvl9 = 0;
         /* Using cursor H004R3 */
         pr_default.execute(1, new Object[] {AV10CliID, AV11CpjID, AV12CpjConSeq});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A269CpjConSeq = H004R3_A269CpjConSeq[0];
            A166CpjID = H004R3_A166CpjID[0];
            A158CliID = H004R3_A158CliID[0];
            A275CpjConNome = H004R3_A275CpjConNome[0];
            AV18GXLvl9 = 1;
            Form.Caption = A275CpjConNome;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
         if ( AV18GXLvl9 == 0 )
         {
            Form.Caption = "Registro n�o encontrado";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            AV14SelectedTabCode = AV8TabCode;
            AssignAttri("", false, "AV14SelectedTabCode", AV14SelectedTabCode);
            Tabs_Activepagecontrolname = AV14SelectedTabCode;
            ucTabs.SendProperty(context, "", false, Tabs_Internalname, "ActivePageControlName", Tabs_Activepagecontrolname);
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if ( returnInSub )
            {
               returnInSub = true;
               if (true) return;
            }
         }
         AV16RecordDescription = Form.Caption;
         AssignAttri("", false, "AV16RecordDescription", AV16RecordDescription);
         GxWebStd.gx_hidden_field( context, "gxhash_vRECORDDESCRIPTION", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV16RecordDescription, "")), context));
         if ( StringUtil.StrCmp(AV17Session.Get("DiscussionThreadIdToOpen"), "") != 0 )
         {
            this.executeUsercontrolMethod("", false, "DDC_DISCUSSIONSContainer", "Open", "", new Object[] {});
         }
      }

      protected void E154R2( )
      {
         /* Refresh Routine */
         returnInSub = false;
         if ( ! new GeneXus.Programs.wwpbaseobjects.discussions.wwp_hasdiscussionmessages(context).executeUdp(  "ClientePJContato",  StringUtil.Trim( A158CliID.ToString())+";"+StringUtil.Trim( A166CpjID.ToString())+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0))) )
         {
            Ddc_discussions_Icon = "far fa-comment";
            ucDdc_discussions.SendProperty(context, "", false, Ddc_discussions_Internalname, "Icon", Ddc_discussions_Icon);
         }
         if ( new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_hassubscriptionstodisplay(context).executeUdp(  "ClientePJContato",  2) )
         {
            Ddc_subscriptions_Visible = true;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         else
         {
            Ddc_subscriptions_Visible = false;
            ucDdc_subscriptions.SendProperty(context, "", false, Ddc_subscriptions_Internalname, "Visible", StringUtil.BoolToStr( Ddc_subscriptions_Visible));
         }
         /*  Sending Event outputs  */
      }

      protected void nextLoad( )
      {
      }

      protected void E164R2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void E114R2( )
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
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0034",(string)"",(string)"ClientePJContato",(short)2,StringUtil.Trim( A158CliID.ToString())+";"+StringUtil.Trim( A166CpjID.ToString())+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0)),(string)AV16RecordDescription});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)"",(string)""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E124R2( )
      {
         /* Ddc_discussions_Onloadcomponent Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wwpaux_wc = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wwpaux_wc_Component), StringUtil.Lower( "WWPBaseObjects.Discussions.WWP_DiscussionsWC")) != 0 )
         {
            WebComp_Wwpaux_wc = getWebComponent(GetType(), "GeneXus.Programs", "wwpbaseobjects.discussions.wwp_discussionswc", new Object[] {context} );
            WebComp_Wwpaux_wc.ComponentInit();
            WebComp_Wwpaux_wc.Name = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
            WebComp_Wwpaux_wc_Component = "WWPBaseObjects.Discussions.WWP_DiscussionsWC";
         }
         if ( StringUtil.Len( WebComp_Wwpaux_wc_Component) != 0 )
         {
            WebComp_Wwpaux_wc.setjustcreated();
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "core.clientepjcontatoview.aspx"+UrlEncode(A158CliID.ToString()) + "," + UrlEncode(A166CpjID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(A269CpjConSeq,4,0)) + "," + UrlEncode(StringUtil.RTrim(""));
            WebComp_Wwpaux_wc.componentprepare(new Object[] {(string)"W0034",(string)"",(string)"ClientePJContato",StringUtil.Trim( A158CliID.ToString())+";"+StringUtil.Trim( A166CpjID.ToString())+";"+StringUtil.Trim( StringUtil.Str( (decimal)(A269CpjConSeq), 4, 0)),(string)AV16RecordDescription,formatLink("core.clientepjcontatoview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)});
            WebComp_Wwpaux_wc.componentbind(new Object[] {(string)"",(string)""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+""+"",(string)"",(string)""+""+"",(string)"",(string)""+"",(string)"",(string)"",(string)"",(string)""+""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Wwpaux_wc )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0034"+"");
            WebComp_Wwpaux_wc.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
         /*  Sending Event outputs  */
      }

      protected void E134R2( )
      {
         /* Tabs_Tabchanged Routine */
         returnInSub = false;
         AV14SelectedTabCode = Tabs_Activepagecontrolname;
         AssignAttri("", false, "AV14SelectedTabCode", AV14SelectedTabCode);
         AV13LoadAllTabs = false;
         AssignAttri("", false, "AV13LoadAllTabs", AV13LoadAllTabs);
         /* Execute user subroutine: 'LOADTABS' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         if ( AV13LoadAllTabs || ( StringUtil.StrCmp(AV14SelectedTabCode, "") == 0 ) || ( StringUtil.StrCmp(AV14SelectedTabCode, "General") == 0 ) )
         {
            /* Object Property */
            if ( true )
            {
               bDynCreated_Generalwc = true;
            }
            if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Generalwc_Component), StringUtil.Lower( "core.ClientePJContatoGeneral")) != 0 )
            {
               WebComp_Generalwc = getWebComponent(GetType(), "GeneXus.Programs", "core.clientepjcontatogeneral", new Object[] {context} );
               WebComp_Generalwc.ComponentInit();
               WebComp_Generalwc.Name = "core.ClientePJContatoGeneral";
               WebComp_Generalwc_Component = "core.ClientePJContatoGeneral";
            }
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.setjustcreated();
               WebComp_Generalwc.componentprepare(new Object[] {(string)"W0029",(string)"",(Guid)AV10CliID,(Guid)AV11CpjID,(short)AV12CpjConSeq});
               WebComp_Generalwc.componentbind(new Object[] {(string)"",(string)"",(string)""});
            }
            if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Generalwc )
            {
               context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0029"+"");
               WebComp_Generalwc.componentdraw();
               context.httpAjaxContext.ajax_rspEndCmp();
            }
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10CliID = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV10CliID", AV10CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV10CliID, context));
         AV11CpjID = (Guid)getParm(obj,1);
         AssignAttri("", false, "AV11CpjID", AV11CpjID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJID", GetSecureSignedToken( "", AV11CpjID, context));
         AV12CpjConSeq = Convert.ToInt16(getParm(obj,2));
         AssignAttri("", false, "AV12CpjConSeq", StringUtil.LTrimStr( (decimal)(AV12CpjConSeq), 4, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vCPJCONSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV12CpjConSeq), "ZZZ9"), context));
         AV8TabCode = (string)getParm(obj,3);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
         GxWebStd.gx_hidden_field( context, "gxhash_vTABCODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8TabCode, "")), context));
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
         PA4R2( ) ;
         WS4R2( ) ;
         WE4R2( ) ;
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
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         if ( ! ( WebComp_Generalwc == null ) )
         {
            if ( StringUtil.Len( WebComp_Generalwc_Component) != 0 )
            {
               WebComp_Generalwc.componentthemes();
            }
         }
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828223743", true, true);
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
         context.AddJavascriptSource("core/clientepjcontatoview.js", "?2023828223743", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblWorkwithlink_Internalname = "WORKWITHLINK";
         Ddc_subscriptions_Internalname = "DDC_SUBSCRIPTIONS";
         Ddc_discussions_Internalname = "DDC_DISCUSSIONS";
         divTableviewrightitems_Internalname = "TABLEVIEWRIGHTITEMS";
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         divUnnamedtablegeneral_Internalname = "UNNAMEDTABLEGENERAL";
         Tabs_Internalname = "TABS";
         divUnnamedtableviewcontainer_Internalname = "UNNAMEDTABLEVIEWCONTAINER";
         divTablemain_Internalname = "TABLEMAIN";
         divDiv_wwpauxwc_Internalname = "DIV_WWPAUXWC";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         Ddc_discussions_Caption = "";
         Ddc_subscriptions_Caption = "";
         lblWorkwithlink_Link = "";
         Tabs_Historymanagement = Convert.ToBoolean( -1);
         Tabs_Class = "ViewTab Tab";
         Tabs_Pagecount = 1;
         Ddc_discussions_Cls = "DropDownComponent";
         Ddc_discussions_Tooltip = "WWP_Discussions_Tooltip";
         Ddc_discussions_Icon = "far fa-comment-dots";
         Ddc_discussions_Icontype = "FontIcon";
         Ddc_subscriptions_Visible = Convert.ToBoolean( -1);
         Ddc_subscriptions_Cls = "DropDownComponent";
         Ddc_subscriptions_Tooltip = "WWP_Subscriptions_Tooltip";
         Ddc_subscriptions_Icon = "fas fa-rss";
         Ddc_subscriptions_Icontype = "FontIcon";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Cliente PJContato View";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'},{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true},{av:'AV10CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV11CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV12CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true},{av:'AV8TabCode',fld:'vTABCODE',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[{av:'Ddc_discussions_Icon',ctrl:'DDC_DISCUSSIONS',prop:'Icon'},{av:'Ddc_subscriptions_Visible',ctrl:'DDC_SUBSCRIPTIONS',prop:'Visible'}]}");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT","{handler:'E114R2',iparms:[{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'},{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true}]");
         setEventMetadata("DDC_SUBSCRIPTIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT","{handler:'E124R2',iparms:[{av:'AV16RecordDescription',fld:'vRECORDDESCRIPTION',pic:'',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A166CpjID',fld:'CPJID',pic:''},{av:'A269CpjConSeq',fld:'CPJCONSEQ',pic:'ZZZ9'}]");
         setEventMetadata("DDC_DISCUSSIONS.ONLOADCOMPONENT",",oparms:[{ctrl:'WWPAUX_WC'}]}");
         setEventMetadata("TABS.TABCHANGED","{handler:'E134R2',iparms:[{av:'Tabs_Activepagecontrolname',ctrl:'TABS',prop:'ActivePageControlName'},{av:'AV13LoadAllTabs',fld:'vLOADALLTABS',pic:''},{av:'AV14SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV10CliID',fld:'vCLIID',pic:'',hsh:true},{av:'AV11CpjID',fld:'vCPJID',pic:'',hsh:true},{av:'AV12CpjConSeq',fld:'vCPJCONSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("TABS.TABCHANGED",",oparms:[{av:'AV14SelectedTabCode',fld:'vSELECTEDTABCODE',pic:''},{av:'AV13LoadAllTabs',fld:'vLOADALLTABS',pic:''},{ctrl:'GENERALWC'}]}");
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
         wcpOAV10CliID = Guid.Empty;
         wcpOAV11CpjID = Guid.Empty;
         wcpOAV8TabCode = "";
         Tabs_Activepagecontrolname = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV16RecordDescription = "";
         A158CliID = Guid.Empty;
         A166CpjID = Guid.Empty;
         AV14SelectedTabCode = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblWorkwithlink_Jsonclick = "";
         ucDdc_subscriptions = new GXUserControl();
         ucDdc_discussions = new GXUserControl();
         ucTabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         WebComp_Generalwc_Component = "";
         OldGeneralwc = "";
         WebComp_Wwpaux_wc_Component = "";
         OldWwpaux_wc = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H004R2_A269CpjConSeq = new short[1] ;
         H004R2_A166CpjID = new Guid[] {Guid.Empty} ;
         H004R2_A158CliID = new Guid[] {Guid.Empty} ;
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         H004R3_A269CpjConSeq = new short[1] ;
         H004R3_A166CpjID = new Guid[] {Guid.Empty} ;
         H004R3_A158CliID = new Guid[] {Guid.Empty} ;
         H004R3_A275CpjConNome = new string[] {""} ;
         A275CpjConNome = "";
         AV17Session = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjcontatoview__default(),
            new Object[][] {
                new Object[] {
               H004R2_A269CpjConSeq, H004R2_A166CpjID, H004R2_A158CliID
               }
               , new Object[] {
               H004R3_A269CpjConSeq, H004R3_A166CpjID, H004R3_A158CliID, H004R3_A275CpjConNome
               }
            }
         );
         WebComp_Generalwc = new GeneXus.Http.GXNullWebComponent();
         WebComp_Wwpaux_wc = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short AV12CpjConSeq ;
      private short wcpOAV12CpjConSeq ;
      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short A269CpjConSeq ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV18GXLvl9 ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int Tabs_Pagecount ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string Tabs_Activepagecontrolname ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV14SelectedTabCode ;
      private string Ddc_subscriptions_Icontype ;
      private string Ddc_subscriptions_Icon ;
      private string Ddc_subscriptions_Tooltip ;
      private string Ddc_subscriptions_Cls ;
      private string Ddc_discussions_Icontype ;
      private string Ddc_discussions_Icon ;
      private string Ddc_discussions_Tooltip ;
      private string Ddc_discussions_Cls ;
      private string Tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableviewrightitems_Internalname ;
      private string lblWorkwithlink_Internalname ;
      private string lblWorkwithlink_Link ;
      private string lblWorkwithlink_Jsonclick ;
      private string Ddc_subscriptions_Caption ;
      private string Ddc_subscriptions_Internalname ;
      private string Ddc_discussions_Caption ;
      private string Ddc_discussions_Internalname ;
      private string divUnnamedtableviewcontainer_Internalname ;
      private string Tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divUnnamedtablegeneral_Internalname ;
      private string WebComp_Generalwc_Component ;
      private string OldGeneralwc ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divDiv_wwpauxwc_Internalname ;
      private string WebComp_Wwpaux_wc_Component ;
      private string OldWwpaux_wc ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV13LoadAllTabs ;
      private bool Ddc_subscriptions_Visible ;
      private bool Tabs_Historymanagement ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool bDynCreated_Wwpaux_wc ;
      private bool bDynCreated_Generalwc ;
      private string AV16RecordDescription ;
      private string A275CpjConNome ;
      private Guid AV10CliID ;
      private Guid AV11CpjID ;
      private Guid wcpOAV10CliID ;
      private Guid wcpOAV11CpjID ;
      private Guid A158CliID ;
      private Guid A166CpjID ;
      private IGxSession AV17Session ;
      private GXWebComponent WebComp_Generalwc ;
      private GXWebComponent WebComp_Wwpaux_wc ;
      private GXUserControl ucDdc_subscriptions ;
      private GXUserControl ucDdc_discussions ;
      private GXUserControl ucTabs ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] H004R2_A269CpjConSeq ;
      private Guid[] H004R2_A166CpjID ;
      private Guid[] H004R2_A158CliID ;
      private short[] H004R3_A269CpjConSeq ;
      private Guid[] H004R3_A166CpjID ;
      private Guid[] H004R3_A158CliID ;
      private string[] H004R3_A275CpjConNome ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class clientepjcontatoview__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH004R2;
          prmH004R2 = new Object[] {
          new ParDef("AV10CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12CpjConSeq",GXType.Int16,4,0)
          };
          Object[] prmH004R3;
          prmH004R3 = new Object[] {
          new ParDef("AV10CliID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV11CpjID",GXType.UniqueIdentifier,36,0) ,
          new ParDef("AV12CpjConSeq",GXType.Int16,4,0)
          };
          def= new CursorDef[] {
              new CursorDef("H004R2", "SELECT CpjConSeq, CpjID, CliID FROM tb_clientepj_contato WHERE CliID = :AV10CliID and CpjID = :AV11CpjID and CpjConSeq = :AV12CpjConSeq ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R2,1, GxCacheFrequency.OFF ,true,true )
             ,new CursorDef("H004R3", "SELECT CpjConSeq, CpjID, CliID, CpjConNome FROM tb_clientepj_contato WHERE (CliID = :AV10CliID and CpjID = :AV11CpjID and CpjConSeq = :AV12CpjConSeq) AND (CliID = :AV10CliID and CpjID = :AV11CpjID and CpjConSeq = :AV12CpjConSeq) ORDER BY CliID, CpjID, CpjConSeq ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH004R3,1, GxCacheFrequency.OFF ,false,true )
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
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                return;
             case 1 :
                ((short[]) buf[0])[0] = rslt.getShort(1);
                ((Guid[]) buf[1])[0] = rslt.getGuid(2);
                ((Guid[]) buf[2])[0] = rslt.getGuid(3);
                ((string[]) buf[3])[0] = rslt.getVarchar(4);
                return;
       }
    }

 }

}
