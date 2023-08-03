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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_visualizenotification : GXDataArea
   {
      public wwp_visualizenotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_visualizenotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref long aP0_WWPNotificationId )
      {
         this.AV7WWPNotificationId = aP0_WWPNotificationId;
         executePrivate();
         aP0_WWPNotificationId=this.AV7WWPNotificationId;
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
            gxfirstwebparm = GetFirstPar( "WWPNotificationId");
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
               gxfirstwebparm = GetFirstPar( "WWPNotificationId");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "WWPNotificationId");
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
            return "wwpvisualizenotification_Execute" ;
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
         PA2E2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START2E2( ) ;
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
         GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationId,10,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vWWPNOTIFICATIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7WWPNotificationId), 10, 0, ",", "")));
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
            WE2E2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT2E2( ) ;
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
         GXEncryptionTmp = "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx"+UrlEncode(StringUtil.LTrimStr(AV7WWPNotificationId,10,0));
         return formatLink("wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_VisualizeNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "Visualize one notification" ;
      }

      protected void WB2E0( )
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
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, divTablemain_Width, "px", 0, "px", "TableMain", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablefscard_Internalname, 1, 0, "px", 0, "px", "NotificationCardTable", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellPaddingTop5", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblNotificationitemicon_Internalname, "<i class='fas fa-pencil-alt NotificationFontIconSuccess'></i>", "", "", lblNotificationitemicon_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 2, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable2_Internalname, 1, 0, "px", 0, "px", "Flex", "start", "top", " "+"data-gx-flex"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, "Notification Title", "gx-form-item SimpleCardAttributeTitleLabel", 0, true, "width: 25%;");
            /* Multiple line edit */
            ClassString = "SimpleCardAttributeTitle";
            StyleString = "";
            ClassString = "SimpleCardAttributeTitle";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A119WWPNotificationTitle, "", "", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginLeft CellPaddingTop5", "start", "top", "", "flex-grow:1;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Notification Created Date", "gx-form-item NotificationItemDatetimeLabel", 0, true, "width: 25%;");
            /* Single line edit */
            context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
            GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A66WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "NotificationItemDatetime", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
            GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
            context.WriteHtmlTextNl( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginLeft", "start", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblMarkasread_Internalname, lblMarkasread_Caption, "", "", lblMarkasread_Jsonclick, "'"+""+"'"+",false,"+"'"+"E\\'DOMARKASREAD\\'."+"'", "", "TextBlock", 5, lblMarkasread_Tooltiptext, 1, 1, 0, 1, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, "Notification Short Description", "col-sm-3 CardNotificationAttributeDescriptionLabel", 0, true, "");
            /* Multiple line edit */
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            ClassString = "CardNotificationAttributeDescription";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A120WWPNotificationShortDescriptio, "", "", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_VisualizeNotification.htm");
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
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START2E2( )
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
            Form.Meta.addItem("description", "Visualize one notification", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP2E0( ) ;
      }

      protected void WS2E2( )
      {
         START2E2( ) ;
         EVT2E2( ) ;
      }

      protected void EVT2E2( )
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
                              E112E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "'DOMARKASREAD'") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: 'DoMarkAsRead' */
                              E122E2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E132E2 ();
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
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE2E2( )
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

      protected void PA2E2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx")), "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wwpbaseobjects.notifications.common.wwp_visualizenotification.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "WWPNotificationId");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7WWPNotificationId = (long)(Math.Round(NumberUtil.Val( gxfirstwebparm, "."), 18, MidpointRounding.ToEven));
                     AssignAttri("", false, "AV7WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV7WWPNotificationId), 10, 0));
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
         RF2E2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF2E2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Using cursor H002E2 */
            pr_default.execute(0, new Object[] {AV7WWPNotificationId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A64WWPNotificationId = H002E2_A64WWPNotificationId[0];
               A124WWPNotificationIsRead = H002E2_A124WWPNotificationIsRead[0];
               A120WWPNotificationShortDescriptio = H002E2_A120WWPNotificationShortDescriptio[0];
               AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
               A66WWPNotificationCreated = H002E2_A66WWPNotificationCreated[0];
               AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
               A119WWPNotificationTitle = H002E2_A119WWPNotificationTitle[0];
               AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
               /* Execute user event: Load */
               E132E2 ();
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
            WB2E0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes2E2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP2E0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E112E2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            /* Read variables values. */
            A119WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
            A66WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A120WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
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
         E112E2 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
      }

      protected void E112E2( )
      {
         /* Start Routine */
         returnInSub = false;
         divTablemain_Width = 700;
         AssignProp("", false, divTablemain_Internalname, "Width", StringUtil.LTrimStr( (decimal)(divTablemain_Width), 9, 0), true);
         /* Using cursor H002E3 */
         pr_default.execute(1, new Object[] {AV7WWPNotificationId});
         while ( (pr_default.getStatus(1) != 101) )
         {
            A64WWPNotificationId = H002E3_A64WWPNotificationId[0];
            A49WWPUserExtendedId = H002E3_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = H002E3_n49WWPUserExtendedId[0];
            A121WWPNotificationLink = H002E3_A121WWPNotificationLink[0];
            A102WWPNotificationMetadata = H002E3_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = H002E3_n102WWPNotificationMetadata[0];
            if ( StringUtil.StrCmp(A49WWPUserExtendedId, new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context).executeUdp( )) != 0 )
            {
               CallWebObject(formatLink("gamnotauthorized.aspx") );
               context.wjLocDisableFrm = 1;
            }
            new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadbyid( ref  A64WWPNotificationId) ;
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A121WWPNotificationLink)) )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( A102WWPNotificationMetadata)) )
               {
                  AV9WWPNotificationMetadataSDT.FromJSonString(A102WWPNotificationMetadata, null);
                  AV8WebSession.Set(AV9WWPNotificationMetadataSDT.gxTpr_Sessionkey, AV9WWPNotificationMetadataSDT.gxTpr_Sessionvalue);
               }
               CallWebObject(formatLink(A121WWPNotificationLink) );
               context.wjLocDisableFrm = 0;
            }
            /* Exiting from a For First loop. */
            if (true) break;
         }
         pr_default.close(1);
      }

      protected void E122E2( )
      {
         /* 'DoMarkAsRead' Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_changenotificationstatus(context ).gxep_setnotificationreadunreadbyid( ref  AV7WWPNotificationId) ;
         context.DoAjaxRefresh();
      }

      protected void nextLoad( )
      {
      }

      protected void E132E2( )
      {
         /* Load Routine */
         returnInSub = false;
         if ( A124WWPNotificationIsRead )
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope DiscussionsSendIcon\"></i>";
            AssignProp("", false, lblMarkasread_Internalname, "Caption", lblMarkasread_Caption, true);
            lblMarkasread_Tooltiptext = "Mark as unread";
            AssignProp("", false, lblMarkasread_Internalname, "Tooltiptext", lblMarkasread_Tooltiptext, true);
         }
         else
         {
            lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
            AssignProp("", false, lblMarkasread_Internalname, "Caption", lblMarkasread_Caption, true);
            lblMarkasread_Tooltiptext = "Mark as read";
            AssignProp("", false, lblMarkasread_Internalname, "Tooltiptext", lblMarkasread_Tooltiptext, true);
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7WWPNotificationId = Convert.ToInt64(getParm(obj,0));
         AssignAttri("", false, "AV7WWPNotificationId", StringUtil.LTrimStr( (decimal)(AV7WWPNotificationId), 10, 0));
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
         PA2E2( ) ;
         WS2E2( ) ;
         WE2E2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828205767", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_visualizenotification.js", "?2023828205767", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblNotificationitemicon_Internalname = "NOTIFICATIONITEMICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblMarkasread_Internalname = "MARKASREAD";
         divUnnamedtable2_Internalname = "UNNAMEDTABLE2";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         divTablecontent_Internalname = "TABLECONTENT";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablefscard_Internalname = "TABLEFSCARD";
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
         edtWWPNotificationShortDescriptio_Enabled = 0;
         lblMarkasread_Tooltiptext = "";
         lblMarkasread_Caption = "<i class=\"fas fa-envelope-open DiscussionsSendIcon\"></i>";
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationTitle_Enabled = 0;
         divTablemain_Width = 0;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Visualize one notification";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV7WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("'DOMARKASREAD'","{handler:'E122E2',iparms:[{av:'AV7WWPNotificationId',fld:'vWWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("'DOMARKASREAD'",",oparms:[]}");
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
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         lblNotificationitemicon_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         A119WWPNotificationTitle = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblMarkasread_Jsonclick = "";
         A120WWPNotificationShortDescriptio = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         scmdbuf = "";
         H002E2_A64WWPNotificationId = new long[1] ;
         H002E2_A124WWPNotificationIsRead = new bool[] {false} ;
         H002E2_A120WWPNotificationShortDescriptio = new string[] {""} ;
         H002E2_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         H002E2_A119WWPNotificationTitle = new string[] {""} ;
         H002E3_A64WWPNotificationId = new long[1] ;
         H002E3_A49WWPUserExtendedId = new string[] {""} ;
         H002E3_n49WWPUserExtendedId = new bool[] {false} ;
         H002E3_A121WWPNotificationLink = new string[] {""} ;
         H002E3_A102WWPNotificationMetadata = new string[] {""} ;
         H002E3_n102WWPNotificationMetadata = new bool[] {false} ;
         A49WWPUserExtendedId = "";
         A121WWPNotificationLink = "";
         A102WWPNotificationMetadata = "";
         AV9WWPNotificationMetadataSDT = new GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata(context);
         AV8WebSession = context.GetSession();
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_visualizenotification__default(),
            new Object[][] {
                new Object[] {
               H002E2_A64WWPNotificationId, H002E2_A124WWPNotificationIsRead, H002E2_A120WWPNotificationShortDescriptio, H002E2_A66WWPNotificationCreated, H002E2_A119WWPNotificationTitle
               }
               , new Object[] {
               H002E3_A64WWPNotificationId, H002E3_A49WWPUserExtendedId, H002E3_n49WWPUserExtendedId, H002E3_A121WWPNotificationLink, H002E3_A102WWPNotificationMetadata, H002E3_n102WWPNotificationMetadata
               }
            }
         );
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
      private short nDonePA ;
      private short nGXWrapped ;
      private int divTablemain_Width ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int idxLst ;
      private long AV7WWPNotificationId ;
      private long wcpOAV7WWPNotificationId ;
      private long A64WWPNotificationId ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divTablefscard_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string lblNotificationitemicon_Internalname ;
      private string lblNotificationitemicon_Jsonclick ;
      private string divTablecontent_Internalname ;
      private string divUnnamedtable2_Internalname ;
      private string edtWWPNotificationTitle_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string lblMarkasread_Internalname ;
      private string lblMarkasread_Caption ;
      private string lblMarkasread_Jsonclick ;
      private string lblMarkasread_Tooltiptext ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private string A49WWPUserExtendedId ;
      private DateTime A66WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool A124WWPNotificationIsRead ;
      private bool returnInSub ;
      private bool n49WWPUserExtendedId ;
      private bool n102WWPNotificationMetadata ;
      private string A102WWPNotificationMetadata ;
      private string A119WWPNotificationTitle ;
      private string A120WWPNotificationShortDescriptio ;
      private string A121WWPNotificationLink ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private long aP0_WWPNotificationId ;
      private IDataStoreProvider pr_default ;
      private long[] H002E2_A64WWPNotificationId ;
      private bool[] H002E2_A124WWPNotificationIsRead ;
      private string[] H002E2_A120WWPNotificationShortDescriptio ;
      private DateTime[] H002E2_A66WWPNotificationCreated ;
      private string[] H002E2_A119WWPNotificationTitle ;
      private long[] H002E3_A64WWPNotificationId ;
      private string[] H002E3_A49WWPUserExtendedId ;
      private bool[] H002E3_n49WWPUserExtendedId ;
      private string[] H002E3_A121WWPNotificationLink ;
      private string[] H002E3_A102WWPNotificationMetadata ;
      private bool[] H002E3_n102WWPNotificationMetadata ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IGxSession AV8WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.notifications.common.SdtWWP_SDTNotificationMetadata AV9WWPNotificationMetadataSDT ;
   }

   public class wwp_visualizenotification__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH002E2;
          prmH002E2 = new Object[] {
          new ParDef("AV7WWPNotificationId",GXType.Int64,10,0)
          };
          Object[] prmH002E3;
          prmH002E3 = new Object[] {
          new ParDef("AV7WWPNotificationId",GXType.Int64,10,0)
          };
          def= new CursorDef[] {
              new CursorDef("H002E2", "SELECT WWPNotificationId, WWPNotificationIsRead, WWPNotificationShortDescriptio, WWPNotificationCreated, WWPNotificationTitle FROM WWP_Notification WHERE WWPNotificationId = :AV7WWPNotificationId ORDER BY WWPNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E2,1, GxCacheFrequency.OFF ,false,true )
             ,new CursorDef("H002E3", "SELECT WWPNotificationId, WWPUserExtendedId, WWPNotificationLink, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :AV7WWPNotificationId ORDER BY WWPNotificationId ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH002E3,1, GxCacheFrequency.OFF ,true,true )
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
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((bool[]) buf[1])[0] = rslt.getBool(2);
                ((string[]) buf[2])[0] = rslt.getVarchar(3);
                ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
                ((string[]) buf[4])[0] = rslt.getVarchar(5);
                return;
             case 1 :
                ((long[]) buf[0])[0] = rslt.getLong(1);
                ((string[]) buf[1])[0] = rslt.getString(2, 40);
                ((bool[]) buf[2])[0] = rslt.wasNull(2);
                ((string[]) buf[3])[0] = rslt.getVarchar(3);
                ((string[]) buf[4])[0] = rslt.getLongVarchar(4);
                ((bool[]) buf[5])[0] = rslt.wasNull(4);
                return;
       }
    }

 }

}
