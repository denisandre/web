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
   public class gamrecoverpasswordstep1 : GXDataArea
   {
      public gamrecoverpasswordstep1( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamrecoverpasswordstep1( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_IDP_State )
      {
         this.AV7IDP_State = aP0_IDP_State;
         executePrivate();
         aP0_IDP_State=this.AV7IDP_State;
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
            gxfirstwebparm = GetFirstPar( "IDP_State");
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
               gxfirstwebparm = GetFirstPar( "IDP_State");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "IDP_State");
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
            MasterPageObj = (GXMasterPage) ClassLoader.GetInstance("wwpbaseobjects.workwithplusmasterpageempty", "GeneXus.Programs.wwpbaseobjects.workwithplusmasterpageempty", new Object[] {context});
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
         PA0K2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START0K2( ) ;
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
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         context.WriteHtmlText( Form.Headerrawhtml) ;
         context.CloseHtmlHeader();
         if ( context.isSpaRequest( ) )
         {
            disableOutput();
         }
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
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
         GXEncryptionTmp = "gamrecoverpasswordstep1.aspx"+UrlEncode(StringUtil.RTrim(AV7IDP_State));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamrecoverpasswordstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV10UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10UserAuthTypeName, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV10UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10UserAuthTypeName, "")), context));
         GxWebStd.gx_hidden_field( context, "vIDP_STATE", StringUtil.RTrim( AV7IDP_State));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Width", StringUtil.RTrim( Dvpanel_tablelogin_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autowidth", StringUtil.BoolToStr( Dvpanel_tablelogin_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autoheight", StringUtil.BoolToStr( Dvpanel_tablelogin_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Cls", StringUtil.RTrim( Dvpanel_tablelogin_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Title", StringUtil.RTrim( Dvpanel_tablelogin_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Collapsible", StringUtil.BoolToStr( Dvpanel_tablelogin_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Collapsed", StringUtil.BoolToStr( Dvpanel_tablelogin_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tablelogin_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Iconposition", StringUtil.RTrim( Dvpanel_tablelogin_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLELOGIN_Autoscroll", StringUtil.BoolToStr( Dvpanel_tablelogin_Autoscroll));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Enablefloatinglabels", StringUtil.BoolToStr( Wwputilites_Enablefloatinglabels));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnresizing", StringUtil.BoolToStr( Wwputilites_Allowcolumnresizing));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnreordering", StringUtil.BoolToStr( Wwputilites_Allowcolumnreordering));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Allowcolumnsrestore", StringUtil.BoolToStr( Wwputilites_Allowcolumnsrestore));
         GxWebStd.gx_hidden_field( context, "WWPUTILITES_Comboloadtype", StringUtil.RTrim( Wwputilites_Comboloadtype));
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
            WE0K2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT0K2( ) ;
      }

      public override bool HasEnterEvent( )
      {
         return true ;
      }

      public override GXWebForm GetForm( )
      {
         return Form ;
      }

      public override string GetSelfLink( )
      {
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "gamrecoverpasswordstep1.aspx"+UrlEncode(StringUtil.RTrim(AV7IDP_State));
         return formatLink("gamrecoverpasswordstep1.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMRecoverPasswordStep1" ;
      }

      public override string GetPgmdesc( )
      {
         return "Recover Password" ;
      }

      protected void WB0K0( )
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
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", divLayoutmaintable_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginLogin", "Center", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Static images/pictures */
            ClassString = "Image" + " " + ((StringUtil.StrCmp(imgHeaderoriginal_gximage, "")==0) ? "GX_Image_LogoLogin_Class" : "GX_Image_"+imgHeaderoriginal_gximage+"_Class");
            StyleString = "";
            sImgUrl = (string)(context.GetImagePath( "e9edf59f-db45-4e16-b6a6-2c2b6611a4a3", "", context.GetTheme( )));
            GxWebStd.gx_bitmap( context, imgHeaderoriginal_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, 1, "", "", 0, 0, 0, "px", 0, "px", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", " "+"data-gx-image"+" ", "", "", 1, false, false, context.GetImageSrcSet( sImgUrl), "HLP_GAMRecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "Center", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tablelogin.SetProperty("Width", Dvpanel_tablelogin_Width);
            ucDvpanel_tablelogin.SetProperty("AutoWidth", Dvpanel_tablelogin_Autowidth);
            ucDvpanel_tablelogin.SetProperty("AutoHeight", Dvpanel_tablelogin_Autoheight);
            ucDvpanel_tablelogin.SetProperty("Cls", Dvpanel_tablelogin_Cls);
            ucDvpanel_tablelogin.SetProperty("Title", Dvpanel_tablelogin_Title);
            ucDvpanel_tablelogin.SetProperty("Collapsible", Dvpanel_tablelogin_Collapsible);
            ucDvpanel_tablelogin.SetProperty("Collapsed", Dvpanel_tablelogin_Collapsed);
            ucDvpanel_tablelogin.SetProperty("ShowCollapseIcon", Dvpanel_tablelogin_Showcollapseicon);
            ucDvpanel_tablelogin.SetProperty("IconPosition", Dvpanel_tablelogin_Iconposition);
            ucDvpanel_tablelogin.SetProperty("AutoScroll", Dvpanel_tablelogin_Autoscroll);
            ucDvpanel_tablelogin.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tablelogin_Internalname, "DVPANEL_TABLELOGINContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLELOGINContainer"+"TableLogin"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTablelogin_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "Center", "top", "", "", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblSignin_Internalname, "Recuperar senha", "", "", lblSignin_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlockTitleLogin", 0, "", 1, 1, 0, 0, "HLP_GAMRecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginTop", "start", "top", "", "", "div");
            wb_table1_23_0K2( true) ;
         }
         else
         {
            wb_table1_23_0K2( false) ;
         }
         return  ;
      }

      protected void wb_table1_23_0K2e( bool wbgen )
      {
         if ( wbgen )
         {
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "Center", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucWwputilites.SetProperty("EnableFloatingLabels", Wwputilites_Enablefloatinglabels);
            ucWwputilites.SetProperty("AllowColumnResizing", Wwputilites_Allowcolumnresizing);
            ucWwputilites.SetProperty("AllowColumnReordering", Wwputilites_Allowcolumnreordering);
            ucWwputilites.SetProperty("AllowColumnsRestore", Wwputilites_Allowcolumnsrestore);
            ucWwputilites.SetProperty("ComboLoadType", Wwputilites_Comboloadtype);
            ucWwputilites.Render(context, "wwp.workwithplusutilities_fal", Wwputilites_Internalname, "WWPUTILITESContainer");
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

      protected void START0K2( )
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
            Form.Meta.addItem("description", "Recover Password", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP0K0( ) ;
      }

      protected void WS0K2( )
      {
         START0K2( ) ;
         EVT0K2( ) ;
      }

      protected void EVT0K2( )
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
                              E110K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E120K2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "BACKTOLOGIN.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E130K2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E140K2 ();
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

      protected void WE0K2( )
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

      protected void PA0K2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamrecoverpasswordstep1.aspx")), "gamrecoverpasswordstep1.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamrecoverpasswordstep1.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "IDP_State");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV7IDP_State = gxfirstwebparm;
                     AssignAttri("", false, "AV7IDP_State", AV7IDP_State);
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
               GX_FocusControl = edtavUsername_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
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
         RF0K2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF0K2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E140K2 ();
            WB0K0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes0K2( )
      {
         GxWebStd.gx_hidden_field( context, "vUSERAUTHTYPENAME", StringUtil.RTrim( AV10UserAuthTypeName));
         GxWebStd.gx_hidden_field( context, "gxhash_vUSERAUTHTYPENAME", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV10UserAuthTypeName, "")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP0K0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110K2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Dvpanel_tablelogin_Width = cgiGet( "DVPANEL_TABLELOGIN_Width");
            Dvpanel_tablelogin_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autowidth"));
            Dvpanel_tablelogin_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autoheight"));
            Dvpanel_tablelogin_Cls = cgiGet( "DVPANEL_TABLELOGIN_Cls");
            Dvpanel_tablelogin_Title = cgiGet( "DVPANEL_TABLELOGIN_Title");
            Dvpanel_tablelogin_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Collapsible"));
            Dvpanel_tablelogin_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Collapsed"));
            Dvpanel_tablelogin_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Showcollapseicon"));
            Dvpanel_tablelogin_Iconposition = cgiGet( "DVPANEL_TABLELOGIN_Iconposition");
            Dvpanel_tablelogin_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLELOGIN_Autoscroll"));
            Wwputilites_Enablefloatinglabels = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Enablefloatinglabels"));
            Wwputilites_Allowcolumnresizing = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnresizing"));
            Wwputilites_Allowcolumnreordering = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnreordering"));
            Wwputilites_Allowcolumnsrestore = StringUtil.StrToBool( cgiGet( "WWPUTILITES_Allowcolumnsrestore"));
            Wwputilites_Comboloadtype = cgiGet( "WWPUTILITES_Comboloadtype");
            /* Read variables values. */
            AV11UserName = cgiGet( edtavUsername_Internalname);
            AssignAttri("", false, "AV11UserName", AV11UserName);
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
         E110K2 ();
         if (returnInSub) return;
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
         Form.Backcolor = GXUtil.RGB( 238, 238, 238);
         AssignProp("", false, "FORM", "Backcolor", StringUtil.LTrimStr( (decimal)(Form.Backcolor), 9, 0), true);
         divLayoutmaintable_Class = "MainContainer";
         AssignProp("", false, divLayoutmaintable_Internalname, "Class", divLayoutmaintable_Class, true);
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E120K2 ();
         if (returnInSub) return;
      }

      protected void E120K2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getuserbylogin(AV10UserAuthTypeName, AV11UserName, out  AV6Errors);
         if ( AV6Errors.Count == 0 )
         {
            AV5Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context).get();
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "gamrecoverpasswordstep2.aspx"+UrlEncode(StringUtil.RTrim(AV7IDP_State)) + "," + UrlEncode(StringUtil.RTrim(""));
            AV8LinkURL = StringUtil.Trim( AV5Application.gxTpr_Environment.gxTpr_Url) + formatLink("gamrecoverpasswordstep2.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey);
            AV8LinkURL += "%1";
            AV9User.sendemailtorecoverpassword( AV5Application,  AV8LinkURL, out  AV6Errors);
            if ( AV6Errors.Count == 0 )
            {
               edtavUsername_Enabled = 0;
               AssignProp("", false, edtavUsername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavUsername_Enabled), 5, 0), true);
               GX_msglist.addItem("Um email foi enviado com instruções para alterar sua senha!");
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYMESSAGES' */
               S112 ();
               if (returnInSub) return;
            }
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYMESSAGES' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
      }

      protected void E130K2( )
      {
         /* Backtologin_Click Routine */
         returnInSub = false;
         if ( new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).isremoteauthentication(AV7IDP_State) )
         {
            if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
            {
               gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
            }
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            GXEncryptionTmp = "gamremotelogin.aspx"+UrlEncode(StringUtil.RTrim(AV7IDP_State));
            CallWebObject(formatLink("gamremotelogin.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey));
            context.wjLocDisableFrm = 1;
         }
         else
         {
            CallWebObject(formatLink("login.aspx") );
            context.wjLocDisableFrm = 1;
         }
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'DISPLAYMESSAGES' Routine */
         returnInSub = false;
         AV19GXV1 = 1;
         while ( AV19GXV1 <= AV6Errors.Count )
         {
            AV15Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV6Errors.Item(AV19GXV1));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV15Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV15Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV19GXV1 = (int)(AV19GXV1+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E140K2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      protected void wb_table1_23_0K2( bool wbgen )
      {
         if ( wbgen )
         {
            /* Table start */
            sStyleString = "";
            GxWebStd.gx_table_start( context, tblUnnamedtable1_Internalname, tblUnnamedtable1_Internalname, "", "Table", 0, "", "", 1, 2, sStyleString, "", "", 0);
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='DataContentCellFL DataContentCellLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group gx-default-form-group", "start", "top", ""+" data-gx-for=\""+edtavUsername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavUsername_Internalname, "Email", "gx-form-item AttributeFLLabel", 1, true, "width: 25%;");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 75, "%", 0, "px", "gx-form-item gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavUsername_Internalname, AV11UserName, StringUtil.RTrim( context.localUtil.Format( AV11UserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavUsername_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavUsername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "GeneXusSecurityCommon\\GAMUserIdentification", "start", true, "", "HLP_GAMRecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            context.WriteHtmlText( "<tr>") ;
            context.WriteHtmlText( "<td class='CellPaddingLogin'>") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divActions_Internalname, 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", " "+"data-gx-flex"+" ", "flex-direction:column;justify-content:flex-end;", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "", "start", "top", "", "align-self:center;", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "CellMarginTop", "start", "top", "", "flex-grow:1;align-self:center;", "div");
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblBacktologin_Internalname, "Voltar para o Login", "", "", lblBacktologin_Jsonclick, "'"+""+"'"+",false,"+"'"+"EBACKTOLOGIN.CLICK."+"'", "", "DataDescriptionLogin", 5, "", 1, 1, 0, 0, "HLP_GAMRecoverPasswordStep1.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</td>") ;
            context.WriteHtmlText( "</tr>") ;
            /* End of table */
            context.WriteHtmlText( "</table>") ;
            wb_table1_23_0K2e( true) ;
         }
         else
         {
            wb_table1_23_0K2e( false) ;
         }
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV7IDP_State = (string)getParm(obj,0);
         AssignAttri("", false, "AV7IDP_State", AV7IDP_State);
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
         PA0K2( ) ;
         WS0K2( ) ;
         WE0K2( ) ;
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
         AddStyleSheetFile("DVelop/Bootstrap/Shared/fontawesome_vlatest/css/all.min.css", "");
         AddStyleSheetFile("DVelop/Bootstrap/Shared/DVelopBootstrap.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828173535", true, true);
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
         context.AddJavascriptSource("gamrecoverpasswordstep1.js", "?2023828173538", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Mask/jquery.mask.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/BootstrapSelect.js", "", false, true);
         context.AddJavascriptSource("DVelop/WorkWithPlusUtilities/WorkWithPlusUtilitiesRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         imgHeaderoriginal_Internalname = "HEADERORIGINAL";
         lblSignin_Internalname = "SIGNIN";
         edtavUsername_Internalname = "vUSERNAME";
         bttBtnenter_Internalname = "BTNENTER";
         lblBacktologin_Internalname = "BACKTOLOGIN";
         divActions_Internalname = "ACTIONS";
         tblUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         divTablelogin_Internalname = "TABLELOGIN";
         Dvpanel_tablelogin_Internalname = "DVPANEL_TABLELOGIN";
         divTablecontent_Internalname = "TABLECONTENT";
         Wwputilites_Internalname = "WWPUTILITES";
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
         edtavUsername_Jsonclick = "";
         edtavUsername_Enabled = 1;
         divLayoutmaintable_Class = "Table";
         Wwputilites_Comboloadtype = "InfiniteScrolling";
         Wwputilites_Allowcolumnsrestore = Convert.ToBoolean( -1);
         Wwputilites_Allowcolumnreordering = Convert.ToBoolean( -1);
         Wwputilites_Allowcolumnresizing = Convert.ToBoolean( -1);
         Wwputilites_Enablefloatinglabels = Convert.ToBoolean( -1);
         Dvpanel_tablelogin_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Iconposition = "Right";
         Dvpanel_tablelogin_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Title = "";
         Dvpanel_tablelogin_Cls = "PanelNoHeader CellMax400";
         Dvpanel_tablelogin_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tablelogin_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tablelogin_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Recover Password";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV10UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E120K2',iparms:[{av:'AV10UserAuthTypeName',fld:'vUSERAUTHTYPENAME',pic:'',hsh:true},{av:'AV11UserName',fld:'vUSERNAME',pic:''},{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'edtavUsername_Enabled',ctrl:'vUSERNAME',prop:'Enabled'}]}");
         setEventMetadata("BACKTOLOGIN.CLICK","{handler:'E130K2',iparms:[{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''}]");
         setEventMetadata("BACKTOLOGIN.CLICK",",oparms:[{av:'AV7IDP_State',fld:'vIDP_STATE',pic:''}]}");
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
         wcpOAV7IDP_State = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV10UserAuthTypeName = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         imgHeaderoriginal_gximage = "";
         StyleString = "";
         sImgUrl = "";
         ucDvpanel_tablelogin = new GXUserControl();
         lblSignin_Jsonclick = "";
         ucWwputilites = new GXUserControl();
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV11UserName = "";
         AV9User = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV6Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV5Application = new GeneXus.Programs.genexussecurity.SdtGAMApplication(context);
         AV8LinkURL = "";
         AV15Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         sStyleString = "";
         TempTags = "";
         bttBtnenter_Jsonclick = "";
         lblBacktologin_Jsonclick = "";
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short gxcookieaux ;
      private short nGXWrapped ;
      private int edtavUsername_Enabled ;
      private int AV19GXV1 ;
      private int idxLst ;
      private string AV7IDP_State ;
      private string wcpOAV7IDP_State ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string AV10UserAuthTypeName ;
      private string Dvpanel_tablelogin_Width ;
      private string Dvpanel_tablelogin_Cls ;
      private string Dvpanel_tablelogin_Title ;
      private string Dvpanel_tablelogin_Iconposition ;
      private string Wwputilites_Comboloadtype ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divLayoutmaintable_Class ;
      private string divTablemain_Internalname ;
      private string divTablecontent_Internalname ;
      private string ClassString ;
      private string imgHeaderoriginal_gximage ;
      private string StyleString ;
      private string sImgUrl ;
      private string imgHeaderoriginal_Internalname ;
      private string Dvpanel_tablelogin_Internalname ;
      private string divTablelogin_Internalname ;
      private string lblSignin_Internalname ;
      private string lblSignin_Jsonclick ;
      private string Wwputilites_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string edtavUsername_Internalname ;
      private string sStyleString ;
      private string tblUnnamedtable1_Internalname ;
      private string TempTags ;
      private string edtavUsername_Jsonclick ;
      private string divActions_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string lblBacktologin_Internalname ;
      private string lblBacktologin_Jsonclick ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Dvpanel_tablelogin_Autowidth ;
      private bool Dvpanel_tablelogin_Autoheight ;
      private bool Dvpanel_tablelogin_Collapsible ;
      private bool Dvpanel_tablelogin_Collapsed ;
      private bool Dvpanel_tablelogin_Showcollapseicon ;
      private bool Dvpanel_tablelogin_Autoscroll ;
      private bool Wwputilites_Enablefloatinglabels ;
      private bool Wwputilites_Allowcolumnresizing ;
      private bool Wwputilites_Allowcolumnreordering ;
      private bool Wwputilites_Allowcolumnsrestore ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private string AV11UserName ;
      private string AV8LinkURL ;
      private GXUserControl ucDvpanel_tablelogin ;
      private GXUserControl ucWwputilites ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_IDP_State ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV6Errors ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV15Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV9User ;
      private GeneXus.Programs.genexussecurity.SdtGAMApplication AV5Application ;
   }

}
