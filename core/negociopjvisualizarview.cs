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
   public class negociopjvisualizarview : GXDataArea
   {
      public negociopjvisualizarview( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjvisualizarview( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( Guid aP0_NegID ,
                           string aP1_TabCode )
      {
         this.AV10NegID = aP0_NegID;
         this.AV8TabCode = aP1_TabCode;
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
            gxfirstwebparm = GetFirstPar( "NegID");
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
               gxfirstwebparm = GetFirstPar( "NegID");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "NegID");
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
            return "negociopjvisualizarview_Execute" ;
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
         PA5B2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5B2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "core.negociopjvisualizarview.aspx"+UrlEncode(AV10NegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.negociopjvisualizarview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vNEGID", AV10NegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV10NegID, context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vNEGID", AV10NegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV10NegID, context));
         GxWebStd.gx_hidden_field( context, "vTABCODE", StringUtil.RTrim( AV8TabCode));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Width", StringUtil.RTrim( Panel_verdetalhes_Width));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Autowidth", StringUtil.BoolToStr( Panel_verdetalhes_Autowidth));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Autoheight", StringUtil.BoolToStr( Panel_verdetalhes_Autoheight));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Cls", StringUtil.RTrim( Panel_verdetalhes_Cls));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Title", StringUtil.RTrim( Panel_verdetalhes_Title));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Collapsible", StringUtil.BoolToStr( Panel_verdetalhes_Collapsible));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Collapsed", StringUtil.BoolToStr( Panel_verdetalhes_Collapsed));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Showcollapseicon", StringUtil.BoolToStr( Panel_verdetalhes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Iconposition", StringUtil.RTrim( Panel_verdetalhes_Iconposition));
         GxWebStd.gx_hidden_field( context, "PANEL_VERDETALHES_Autoscroll", StringUtil.BoolToStr( Panel_verdetalhes_Autoscroll));
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
         if ( ! ( WebComp_Webcomponent_verdetalhes == null ) )
         {
            WebComp_Webcomponent_verdetalhes.componentjscripts();
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
            WE5B2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5B2( ) ;
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
         GXEncryptionTmp = "core.negociopjvisualizarview.aspx"+UrlEncode(AV10NegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8TabCode));
         return formatLink("core.negociopjvisualizarview.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.NegocioPJVisualizarView" ;
      }

      public override string GetPgmdesc( )
      {
         return "Negocio PJVisualizar View" ;
      }

      protected void WB5B0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMain TableViewExpanded", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellViewTabsPosition ViewGridNoBorderCell", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableexpandedview_Internalname, 1, 0, "px", 0, "px", "Table100x100", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecmp_verdetalhes_Internalname, 1, 0, "px", 0, "px", "Table100x100", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucPanel_verdetalhes.SetProperty("Width", Panel_verdetalhes_Width);
            ucPanel_verdetalhes.SetProperty("AutoWidth", Panel_verdetalhes_Autowidth);
            ucPanel_verdetalhes.SetProperty("AutoHeight", Panel_verdetalhes_Autoheight);
            ucPanel_verdetalhes.SetProperty("Cls", Panel_verdetalhes_Cls);
            ucPanel_verdetalhes.SetProperty("Title", Panel_verdetalhes_Title);
            ucPanel_verdetalhes.SetProperty("Collapsible", Panel_verdetalhes_Collapsible);
            ucPanel_verdetalhes.SetProperty("Collapsed", Panel_verdetalhes_Collapsed);
            ucPanel_verdetalhes.SetProperty("ShowCollapseIcon", Panel_verdetalhes_Showcollapseicon);
            ucPanel_verdetalhes.SetProperty("IconPosition", Panel_verdetalhes_Iconposition);
            ucPanel_verdetalhes.SetProperty("AutoScroll", Panel_verdetalhes_Autoscroll);
            ucPanel_verdetalhes.Render(context, "dvelop.gxbootstrap.panel_al", Panel_verdetalhes_Internalname, "PANEL_VERDETALHESContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"PANEL_VERDETALHESContainer"+"TablePanel_VerDetalhes"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablepanel_verdetalhes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0020"+"", StringUtil.RTrim( WebComp_Webcomponent_verdetalhes_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0020"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Webcomponent_verdetalhes_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_verdetalhes), StringUtil.Lower( WebComp_Webcomponent_verdetalhes_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0020"+"");
                  }
                  WebComp_Webcomponent_verdetalhes.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWebcomponent_verdetalhes), StringUtil.Lower( WebComp_Webcomponent_verdetalhes_Component)) != 0 )
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5B2( )
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
            Form.Meta.addItem("description", "Negocio PJVisualizar View", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5B0( ) ;
      }

      protected void WS5B2( )
      {
         START5B2( ) ;
         EVT5B2( ) ;
      }

      protected void EVT5B2( )
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
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E115B2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E125B2 ();
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
                        if ( nCmpId == 20 )
                        {
                           OldWebcomponent_verdetalhes = cgiGet( "W0020");
                           if ( ( StringUtil.Len( OldWebcomponent_verdetalhes) == 0 ) || ( StringUtil.StrCmp(OldWebcomponent_verdetalhes, WebComp_Webcomponent_verdetalhes_Component) != 0 ) )
                           {
                              WebComp_Webcomponent_verdetalhes = getWebComponent(GetType(), "GeneXus.Programs", OldWebcomponent_verdetalhes, new Object[] {context} );
                              WebComp_Webcomponent_verdetalhes.ComponentInit();
                              WebComp_Webcomponent_verdetalhes.Name = "OldWebcomponent_verdetalhes";
                              WebComp_Webcomponent_verdetalhes_Component = OldWebcomponent_verdetalhes;
                           }
                           if ( StringUtil.Len( WebComp_Webcomponent_verdetalhes_Component) != 0 )
                           {
                              WebComp_Webcomponent_verdetalhes.componentprocess("W0020", "", sEvt);
                           }
                           WebComp_Webcomponent_verdetalhes_Component = OldWebcomponent_verdetalhes;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5B2( )
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

      protected void PA5B2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.negociopjvisualizarview.aspx")), "core.negociopjvisualizarview.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.negociopjvisualizarview.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "NegID");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV10NegID = StringUtil.StrToGuid( gxfirstwebparm);
                     AssignAttri("", false, "AV10NegID", AV10NegID.ToString());
                     GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV10NegID, context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV8TabCode = GetPar( "TabCode");
                        AssignAttri("", false, "AV8TabCode", AV8TabCode);
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
         RF5B2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5B2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Webcomponent_verdetalhes_Component) != 0 )
               {
                  WebComp_Webcomponent_verdetalhes.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E125B2 ();
            WB5B0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5B2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5B0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115B2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Panel_verdetalhes_Width = cgiGet( "PANEL_VERDETALHES_Width");
            Panel_verdetalhes_Autowidth = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Autowidth"));
            Panel_verdetalhes_Autoheight = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Autoheight"));
            Panel_verdetalhes_Cls = cgiGet( "PANEL_VERDETALHES_Cls");
            Panel_verdetalhes_Title = cgiGet( "PANEL_VERDETALHES_Title");
            Panel_verdetalhes_Collapsible = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Collapsible"));
            Panel_verdetalhes_Collapsed = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Collapsed"));
            Panel_verdetalhes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Showcollapseicon"));
            Panel_verdetalhes_Iconposition = cgiGet( "PANEL_VERDETALHES_Iconposition");
            Panel_verdetalhes_Autoscroll = StringUtil.StrToBool( cgiGet( "PANEL_VERDETALHES_Autoscroll"));
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
         E115B2 ();
         if (returnInSub) return;
      }

      protected void E115B2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV6WWPContext) ;
         AV14GXLvl8 = 0;
         /* Using cursor H005B2 */
         pr_default.execute(0, new Object[] {AV10NegID});
         while ( (pr_default.getStatus(0) != 101) )
         {
            A345NegID = H005B2_A345NegID[0];
            A362NegAssunto = H005B2_A362NegAssunto[0];
            AV14GXLvl8 = 1;
            Form.Caption = A362NegAssunto;
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = true;
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(0);
         if ( AV14GXLvl8 == 0 )
         {
            Form.Caption = "Registro não encontrado";
            AssignProp("", false, "FORM", "Caption", Form.Caption, true);
            AV9Exists = false;
         }
         if ( AV9Exists )
         {
            /* Execute user subroutine: 'LOADTABS' */
            S112 ();
            if (returnInSub) return;
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E125B2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void S112( )
      {
         /* 'LOADTABS' Routine */
         returnInSub = false;
         /* Object Property */
         if ( true )
         {
            bDynCreated_Webcomponent_verdetalhes = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Webcomponent_verdetalhes_Component), StringUtil.Lower( "core.NegocioPJVerDetalhes")) != 0 )
         {
            WebComp_Webcomponent_verdetalhes = getWebComponent(GetType(), "GeneXus.Programs", "core.negociopjverdetalhes", new Object[] {context} );
            WebComp_Webcomponent_verdetalhes.ComponentInit();
            WebComp_Webcomponent_verdetalhes.Name = "core.NegocioPJVerDetalhes";
            WebComp_Webcomponent_verdetalhes_Component = "core.NegocioPJVerDetalhes";
         }
         if ( StringUtil.Len( WebComp_Webcomponent_verdetalhes_Component) != 0 )
         {
            WebComp_Webcomponent_verdetalhes.setjustcreated();
            WebComp_Webcomponent_verdetalhes.componentprepare(new Object[] {(string)"W0020",(string)"",(Guid)AV10NegID});
            WebComp_Webcomponent_verdetalhes.componentbind(new Object[] {(string)""});
         }
         if ( isFullAjaxMode( ) || isAjaxCallMode( ) && bDynCreated_Webcomponent_verdetalhes )
         {
            context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0020"+"");
            WebComp_Webcomponent_verdetalhes.componentdraw();
            context.httpAjaxContext.ajax_rspEndCmp();
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV10NegID = (Guid)getParm(obj,0);
         AssignAttri("", false, "AV10NegID", AV10NegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV10NegID, context));
         AV8TabCode = (string)getParm(obj,1);
         AssignAttri("", false, "AV8TabCode", AV8TabCode);
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
         PA5B2( ) ;
         WS5B2( ) ;
         WE5B2( ) ;
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
         if ( ! ( WebComp_Webcomponent_verdetalhes == null ) )
         {
            if ( StringUtil.Len( WebComp_Webcomponent_verdetalhes_Component) != 0 )
            {
               WebComp_Webcomponent_verdetalhes.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828225342", true, true);
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
         context.AddJavascriptSource("core/negociopjvisualizarview.js", "?2023828225342", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTablepanel_verdetalhes_Internalname = "TABLEPANEL_VERDETALHES";
         Panel_verdetalhes_Internalname = "PANEL_VERDETALHES";
         divTablecmp_verdetalhes_Internalname = "TABLECMP_VERDETALHES";
         divTableexpandedview_Internalname = "TABLEEXPANDEDVIEW";
         divTablemain_Internalname = "TABLEMAIN";
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
         Panel_verdetalhes_Autoscroll = Convert.ToBoolean( 0);
         Panel_verdetalhes_Iconposition = "Right";
         Panel_verdetalhes_Showcollapseicon = Convert.ToBoolean( 0);
         Panel_verdetalhes_Collapsed = Convert.ToBoolean( 0);
         Panel_verdetalhes_Collapsible = Convert.ToBoolean( -1);
         Panel_verdetalhes_Title = "Ver Detalhes";
         Panel_verdetalhes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Panel_verdetalhes_Autoheight = Convert.ToBoolean( -1);
         Panel_verdetalhes_Autowidth = Convert.ToBoolean( 0);
         Panel_verdetalhes_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Negocio PJVisualizar View";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10NegID',fld:'vNEGID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
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
         wcpOAV10NegID = Guid.Empty;
         wcpOAV8TabCode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucPanel_verdetalhes = new GXUserControl();
         WebComp_Webcomponent_verdetalhes_Component = "";
         OldWebcomponent_verdetalhes = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV6WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         scmdbuf = "";
         H005B2_A345NegID = new Guid[] {Guid.Empty} ;
         H005B2_A362NegAssunto = new string[] {""} ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjvisualizarview__default(),
            new Object[][] {
                new Object[] {
               H005B2_A345NegID, H005B2_A362NegAssunto
               }
            }
         );
         WebComp_Webcomponent_verdetalhes = new GeneXus.Http.GXNullWebComponent();
         /* GeneXus formulas. */
      }

      private short nRcdExists_3 ;
      private short nIsMod_3 ;
      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nCmpId ;
      private short nDonePA ;
      private short AV14GXLvl8 ;
      private short nGXWrapped ;
      private int idxLst ;
      private string AV8TabCode ;
      private string wcpOAV8TabCode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Panel_verdetalhes_Width ;
      private string Panel_verdetalhes_Cls ;
      private string Panel_verdetalhes_Title ;
      private string Panel_verdetalhes_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTableexpandedview_Internalname ;
      private string divTablecmp_verdetalhes_Internalname ;
      private string Panel_verdetalhes_Internalname ;
      private string divTablepanel_verdetalhes_Internalname ;
      private string WebComp_Webcomponent_verdetalhes_Component ;
      private string OldWebcomponent_verdetalhes ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Panel_verdetalhes_Autowidth ;
      private bool Panel_verdetalhes_Autoheight ;
      private bool Panel_verdetalhes_Collapsible ;
      private bool Panel_verdetalhes_Collapsed ;
      private bool Panel_verdetalhes_Showcollapseicon ;
      private bool Panel_verdetalhes_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV9Exists ;
      private bool bDynCreated_Webcomponent_verdetalhes ;
      private string A362NegAssunto ;
      private Guid AV10NegID ;
      private Guid wcpOAV10NegID ;
      private Guid A345NegID ;
      private GXWebComponent WebComp_Webcomponent_verdetalhes ;
      private GXUserControl ucPanel_verdetalhes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005B2_A345NegID ;
      private string[] H005B2_A362NegAssunto ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV6WWPContext ;
   }

   public class negociopjvisualizarview__default : DataStoreHelperBase, IDataStoreHelper
   {
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
          Object[] prmH005B2;
          prmH005B2 = new Object[] {
          new ParDef("AV10NegID",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005B2", "SELECT NegID, NegAssunto FROM tb_negociopj WHERE NegID = :AV10NegID ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005B2,1, GxCacheFrequency.OFF ,false,true )
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
                ((Guid[]) buf[0])[0] = rslt.getGuid(1);
                ((string[]) buf[1])[0] = rslt.getVarchar(2);
                return;
       }
    }

 }

}
