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
   public class wpencerramentofluxo : GXDataArea
   {
      public wpencerramentofluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wpencerramentofluxo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID )
      {
         this.AV6DocOrigem = aP0_DocOrigem;
         this.AV7DocOrigemID = aP1_DocOrigemID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavEncrealizadoonboard_nefconfirmado = new GXCombobox();
         cmbavEncpesquisaavaliacao_nefconfirmado = new GXCombobox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "DocOrigem");
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
               gxfirstwebparm = GetFirstPar( "DocOrigem");
            }
            else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
            {
               if ( ! IsValidAjaxCall( true) )
               {
                  GxWebError = 1;
                  return  ;
               }
               gxfirstwebparm = GetFirstPar( "DocOrigem");
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
            return "wpencerramentofluxo_Execute" ;
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
         PA5T2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5T2( ) ;
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         GXEncryptionTmp = "wpencerramentofluxo.aspx"+UrlEncode(StringUtil.RTrim(AV6DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV7DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wpencerramentofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7DocOrigemID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Encrealizadoonboard", AV9encRealizadoOnboard);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Encrealizadoonboard", AV9encRealizadoOnboard);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Encpesquisaavaliacao", AV8encPesquisaAvaliacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Encpesquisaavaliacao", AV8encPesquisaAvaliacao);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV5CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV13Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV13Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENCREALIZADOONBOARD", AV9encRealizadoOnboard);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENCREALIZADOONBOARD", AV9encRealizadoOnboard);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vENCPESQUISAAVALIACAO", AV8encPesquisaAvaliacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vENCPESQUISAAVALIACAO", AV8encPesquisaAvaliacao);
         }
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Width", StringUtil.RTrim( Dvpanel_tableoportunidade_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autowidth", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autoheight", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Cls", StringUtil.RTrim( Dvpanel_tableoportunidade_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Title", StringUtil.RTrim( Dvpanel_tableoportunidade_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Collapsible", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Collapsed", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Iconposition", StringUtil.RTrim( Dvpanel_tableoportunidade_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEOPORTUNIDADE_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableoportunidade_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Width", StringUtil.RTrim( Dvpanel_pnlencrealizadoonboard_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Cls", StringUtil.RTrim( Dvpanel_pnlencrealizadoonboard_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Title", StringUtil.RTrim( Dvpanel_pnlencrealizadoonboard_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Iconposition", StringUtil.RTrim( Dvpanel_pnlencrealizadoonboard_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCREALIZADOONBOARD_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlencrealizadoonboard_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Width", StringUtil.RTrim( Dvpanel_pnlencpesquisaavaliacao_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Cls", StringUtil.RTrim( Dvpanel_pnlencpesquisaavaliacao_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Title", StringUtil.RTrim( Dvpanel_pnlencpesquisaavaliacao_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Iconposition", StringUtil.RTrim( Dvpanel_pnlencpesquisaavaliacao_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLENCPESQUISAAVALIACAO_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlencpesquisaavaliacao_Autoscroll));
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
         if ( ! ( WebComp_Wcnegociopjgeneral == null ) )
         {
            WebComp_Wcnegociopjgeneral.componentjscripts();
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
            WE5T2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5T2( ) ;
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
         GXEncryptionTmp = "wpencerramentofluxo.aspx"+UrlEncode(StringUtil.RTrim(AV6DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV7DocOrigemID));
         return formatLink("wpencerramentofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "wpEncerramentoFluxo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Encerramento" ;
      }

      protected void WB5T0( )
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
            GxWebStd.gx_div_start( context, divDvpanel_tableoportunidade_cell_Internalname, 1, 0, "px", 0, "px", divDvpanel_tableoportunidade_cell_Class, "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_tableoportunidade.SetProperty("Width", Dvpanel_tableoportunidade_Width);
            ucDvpanel_tableoportunidade.SetProperty("AutoWidth", Dvpanel_tableoportunidade_Autowidth);
            ucDvpanel_tableoportunidade.SetProperty("AutoHeight", Dvpanel_tableoportunidade_Autoheight);
            ucDvpanel_tableoportunidade.SetProperty("Cls", Dvpanel_tableoportunidade_Cls);
            ucDvpanel_tableoportunidade.SetProperty("Title", Dvpanel_tableoportunidade_Title);
            ucDvpanel_tableoportunidade.SetProperty("Collapsible", Dvpanel_tableoportunidade_Collapsible);
            ucDvpanel_tableoportunidade.SetProperty("Collapsed", Dvpanel_tableoportunidade_Collapsed);
            ucDvpanel_tableoportunidade.SetProperty("ShowCollapseIcon", Dvpanel_tableoportunidade_Showcollapseicon);
            ucDvpanel_tableoportunidade.SetProperty("IconPosition", Dvpanel_tableoportunidade_Iconposition);
            ucDvpanel_tableoportunidade.SetProperty("AutoScroll", Dvpanel_tableoportunidade_Autoscroll);
            ucDvpanel_tableoportunidade.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableoportunidade_Internalname, "DVPANEL_TABLEOPORTUNIDADEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEOPORTUNIDADEContainer"+"TableOportunidade"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableoportunidade_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            if ( ! isFullAjaxMode( ) )
            {
               /* WebComponent */
               GxWebStd.gx_hidden_field( context, "W0014"+"", StringUtil.RTrim( WebComp_Wcnegociopjgeneral_Component));
               context.WriteHtmlText( "<div") ;
               GxWebStd.ClassAttribute( context, "gxwebcomponent");
               context.WriteHtmlText( " id=\""+"gxHTMLWrpW0014"+""+"\""+"") ;
               context.WriteHtmlText( ">") ;
               if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
               {
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnegociopjgeneral), StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component)) != 0 )
                  {
                     context.httpAjaxContext.ajax_rspStartCmp("gxHTMLWrpW0014"+"");
                  }
                  WebComp_Wcnegociopjgeneral.componentdraw();
                  if ( StringUtil.StrCmp(StringUtil.Lower( OldWcnegociopjgeneral), StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component)) != 0 )
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginBottom20", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblencrealizadoonboard_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlencrealizadoonboard.SetProperty("Width", Dvpanel_pnlencrealizadoonboard_Width);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("AutoWidth", Dvpanel_pnlencrealizadoonboard_Autowidth);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("AutoHeight", Dvpanel_pnlencrealizadoonboard_Autoheight);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("Cls", Dvpanel_pnlencrealizadoonboard_Cls);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("Title", Dvpanel_pnlencrealizadoonboard_Title);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("Collapsible", Dvpanel_pnlencrealizadoonboard_Collapsible);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("Collapsed", Dvpanel_pnlencrealizadoonboard_Collapsed);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("ShowCollapseIcon", Dvpanel_pnlencrealizadoonboard_Showcollapseicon);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("IconPosition", Dvpanel_pnlencrealizadoonboard_Iconposition);
            ucDvpanel_pnlencrealizadoonboard.SetProperty("AutoScroll", Dvpanel_pnlencrealizadoonboard_Autoscroll);
            ucDvpanel_pnlencrealizadoonboard.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlencrealizadoonboard_Internalname, "DVPANEL_PNLENCREALIZADOONBOARDContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLENCREALIZADOONBOARDContainer"+"pnlEncRealizadoOnboard"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlencrealizadoonboard_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEncrealizadoonboard_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEncrealizadoonboard_nefconfirmado_Internalname, "Realizado OnBoard?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEncrealizadoonboard_nefconfirmado, cmbavEncrealizadoonboard_nefconfirmado_Internalname, StringUtil.BoolToStr( AV9encRealizadoOnboard.gxTpr_Nefconfirmado), 1, cmbavEncrealizadoonboard_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavEncrealizadoonboard_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_wpEncerramentoFluxo.htm");
            cmbavEncrealizadoonboard_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9encRealizadoOnboard.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavEncrealizadoonboard_nefconfirmado_Internalname, "Values", (string)(cmbavEncrealizadoonboard_nefconfirmado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginBottom20", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblencpesquisaavaliacao_Internalname, divTblencpesquisaavaliacao_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("Width", Dvpanel_pnlencpesquisaavaliacao_Width);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("AutoWidth", Dvpanel_pnlencpesquisaavaliacao_Autowidth);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("AutoHeight", Dvpanel_pnlencpesquisaavaliacao_Autoheight);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("Cls", Dvpanel_pnlencpesquisaavaliacao_Cls);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("Title", Dvpanel_pnlencpesquisaavaliacao_Title);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("Collapsible", Dvpanel_pnlencpesquisaavaliacao_Collapsible);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("Collapsed", Dvpanel_pnlencpesquisaavaliacao_Collapsed);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("ShowCollapseIcon", Dvpanel_pnlencpesquisaavaliacao_Showcollapseicon);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("IconPosition", Dvpanel_pnlencpesquisaavaliacao_Iconposition);
            ucDvpanel_pnlencpesquisaavaliacao.SetProperty("AutoScroll", Dvpanel_pnlencpesquisaavaliacao_Autoscroll);
            ucDvpanel_pnlencpesquisaavaliacao.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlencpesquisaavaliacao_Internalname, "DVPANEL_PNLENCPESQUISAAVALIACAOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLENCPESQUISAAVALIACAOContainer"+"pnlEncPesquisaAvaliacao"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlencpesquisaavaliacao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavEncpesquisaavaliacao_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavEncpesquisaavaliacao_nefconfirmado_Internalname, "Pesquisa de Avaliação Realizada?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavEncpesquisaavaliacao_nefconfirmado, cmbavEncpesquisaavaliacao_nefconfirmado_Internalname, StringUtil.BoolToStr( AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado), 1, cmbavEncpesquisaavaliacao_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavEncpesquisaavaliacao_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_wpEncerramentoFluxo.htm");
            cmbavEncpesquisaavaliacao_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavEncpesquisaavaliacao_nefconfirmado_Internalname, "Values", (string)(cmbavEncpesquisaavaliacao_nefconfirmado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpEncerramentoFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_wpEncerramentoFluxo.htm");
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
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divHtml_bottomauxiliarcontrols_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV6DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV6DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, 0, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_wpEncerramentoFluxo.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV7DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV7DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_wpEncerramentoFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5T2( )
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
            Form.Meta.addItem("description", "Encerramento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5T0( ) ;
      }

      protected void WS5T2( )
      {
         START5T2( ) ;
         EVT5T2( ) ;
      }

      protected void EVT5T2( )
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
                              E115T2 ();
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
                                    E125T2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135T2 ();
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
                        if ( nCmpId == 14 )
                        {
                           OldWcnegociopjgeneral = cgiGet( "W0014");
                           if ( ( StringUtil.Len( OldWcnegociopjgeneral) == 0 ) || ( StringUtil.StrCmp(OldWcnegociopjgeneral, WebComp_Wcnegociopjgeneral_Component) != 0 ) )
                           {
                              WebComp_Wcnegociopjgeneral = getWebComponent(GetType(), "GeneXus.Programs", OldWcnegociopjgeneral, new Object[] {context} );
                              WebComp_Wcnegociopjgeneral.ComponentInit();
                              WebComp_Wcnegociopjgeneral.Name = "OldWcnegociopjgeneral";
                              WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
                           }
                           if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
                           {
                              WebComp_Wcnegociopjgeneral.componentprocess("W0014", "", sEvt);
                           }
                           WebComp_Wcnegociopjgeneral_Component = OldWcnegociopjgeneral;
                        }
                     }
                     context.wbHandled = 1;
                  }
               }
            }
         }
      }

      protected void WE5T2( )
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

      protected void PA5T2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "wpencerramentofluxo.aspx")), "wpencerramentofluxo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "wpencerramentofluxo.aspx")))) ;
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
                  gxfirstwebparm = GetFirstPar( "DocOrigem");
                  toggleJsOutput = isJsOutputEnabled( );
                  if ( context.isSpaRequest( ) )
                  {
                     disableJsOutput();
                  }
                  if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
                  {
                     AV6DocOrigem = gxfirstwebparm;
                     AssignAttri("", false, "AV6DocOrigem", AV6DocOrigem);
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigem, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV7DocOrigemID = GetPar( "DocOrigemID");
                        AssignAttri("", false, "AV7DocOrigemID", AV7DocOrigemID);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7DocOrigemID, "")), context));
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
               GX_FocusControl = cmbavEncrealizadoonboard_nefconfirmado_Internalname;
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
         if ( cmbavEncrealizadoonboard_nefconfirmado.ItemCount > 0 )
         {
            AV9encRealizadoOnboard.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavEncrealizadoonboard_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9encRealizadoOnboard.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEncrealizadoonboard_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9encRealizadoOnboard.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavEncrealizadoonboard_nefconfirmado_Internalname, "Values", cmbavEncrealizadoonboard_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavEncpesquisaavaliacao_nefconfirmado.ItemCount > 0 )
         {
            AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavEncpesquisaavaliacao_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavEncpesquisaavaliacao_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavEncpesquisaavaliacao_nefconfirmado_Internalname, "Values", cmbavEncpesquisaavaliacao_nefconfirmado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5T2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5T2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            if ( 1 != 0 )
            {
               if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
               {
                  WebComp_Wcnegociopjgeneral.componentstart();
               }
            }
         }
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E135T2 ();
            WB5T0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5T2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5T0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115T2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vENCREALIZADOONBOARD"), AV9encRealizadoOnboard);
            ajax_req_read_hidden_sdt(cgiGet( "vENCPESQUISAAVALIACAO"), AV8encPesquisaAvaliacao);
            ajax_req_read_hidden_sdt(cgiGet( "Encrealizadoonboard"), AV9encRealizadoOnboard);
            ajax_req_read_hidden_sdt(cgiGet( "Encpesquisaavaliacao"), AV8encPesquisaAvaliacao);
            /* Read saved values. */
            Dvpanel_tableoportunidade_Width = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Width");
            Dvpanel_tableoportunidade_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autowidth"));
            Dvpanel_tableoportunidade_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autoheight"));
            Dvpanel_tableoportunidade_Cls = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Cls");
            Dvpanel_tableoportunidade_Title = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Title");
            Dvpanel_tableoportunidade_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Collapsible"));
            Dvpanel_tableoportunidade_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Collapsed"));
            Dvpanel_tableoportunidade_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Showcollapseicon"));
            Dvpanel_tableoportunidade_Iconposition = cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Iconposition");
            Dvpanel_tableoportunidade_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEOPORTUNIDADE_Autoscroll"));
            Dvpanel_pnlencrealizadoonboard_Width = cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Width");
            Dvpanel_pnlencrealizadoonboard_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Autowidth"));
            Dvpanel_pnlencrealizadoonboard_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Autoheight"));
            Dvpanel_pnlencrealizadoonboard_Cls = cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Cls");
            Dvpanel_pnlencrealizadoonboard_Title = cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Title");
            Dvpanel_pnlencrealizadoonboard_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Collapsible"));
            Dvpanel_pnlencrealizadoonboard_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Collapsed"));
            Dvpanel_pnlencrealizadoonboard_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Showcollapseicon"));
            Dvpanel_pnlencrealizadoonboard_Iconposition = cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Iconposition");
            Dvpanel_pnlencrealizadoonboard_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCREALIZADOONBOARD_Autoscroll"));
            Dvpanel_pnlencpesquisaavaliacao_Width = cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Width");
            Dvpanel_pnlencpesquisaavaliacao_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Autowidth"));
            Dvpanel_pnlencpesquisaavaliacao_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Autoheight"));
            Dvpanel_pnlencpesquisaavaliacao_Cls = cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Cls");
            Dvpanel_pnlencpesquisaavaliacao_Title = cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Title");
            Dvpanel_pnlencpesquisaavaliacao_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Collapsible"));
            Dvpanel_pnlencpesquisaavaliacao_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Collapsed"));
            Dvpanel_pnlencpesquisaavaliacao_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Showcollapseicon"));
            Dvpanel_pnlencpesquisaavaliacao_Iconposition = cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Iconposition");
            Dvpanel_pnlencpesquisaavaliacao_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLENCPESQUISAAVALIACAO_Autoscroll"));
            /* Read variables values. */
            cmbavEncrealizadoonboard_nefconfirmado.CurrentValue = cgiGet( cmbavEncrealizadoonboard_nefconfirmado_Internalname);
            AV9encRealizadoOnboard.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavEncrealizadoonboard_nefconfirmado_Internalname));
            cmbavEncpesquisaavaliacao_nefconfirmado.CurrentValue = cgiGet( cmbavEncpesquisaavaliacao_nefconfirmado_Internalname);
            AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavEncpesquisaavaliacao_nefconfirmado_Internalname));
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
         E115T2 ();
         if (returnInSub) return;
      }

      protected void E115T2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV14NegId = StringUtil.StrToGuid( StringUtil.Trim( AV7DocOrigemID));
         AssignAttri("", false, "AV14NegId", AV14NegId.ToString());
         GXt_SdtSDTNegocioPJFluxo1 = AV9encRealizadoOnboard;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV14NegId,  "ENCREALIZADOONBOARD", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV9encRealizadoOnboard = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV8encPesquisaAvaliacao;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV14NegId,  "ENCPESQUISAAVALIACAO", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV8encPesquisaAvaliacao = GXt_SdtSDTNegocioPJFluxo1;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S112 ();
         if (returnInSub) return;
         edtavDocorigem_Visible = 0;
         AssignProp("", false, edtavDocorigem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigem_Visible), 5, 0), true);
         edtavDocorigemid_Visible = 0;
         AssignProp("", false, edtavDocorigemid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigemid_Visible), 5, 0), true);
         /* Object Property */
         if ( true )
         {
            bDynCreated_Wcnegociopjgeneral = true;
         }
         if ( StringUtil.StrCmp(StringUtil.Lower( WebComp_Wcnegociopjgeneral_Component), StringUtil.Lower( "core.NegocioPJVerDetalhes")) != 0 )
         {
            WebComp_Wcnegociopjgeneral = getWebComponent(GetType(), "GeneXus.Programs", "core.negociopjverdetalhes", new Object[] {context} );
            WebComp_Wcnegociopjgeneral.ComponentInit();
            WebComp_Wcnegociopjgeneral.Name = "core.NegocioPJVerDetalhes";
            WebComp_Wcnegociopjgeneral_Component = "core.NegocioPJVerDetalhes";
         }
         if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
         {
            WebComp_Wcnegociopjgeneral.setjustcreated();
            WebComp_Wcnegociopjgeneral.componentprepare(new Object[] {(string)"W0014",(string)"",StringUtil.StrToGuid( StringUtil.Trim( AV7DocOrigemID))});
            WebComp_Wcnegociopjgeneral.componentbind(new Object[] {(string)""+""+"vDOCORIGEMID"+""+""});
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV6DocOrigem, "NEGOCIOPJ") == 0 ) ) )
         {
            divDvpanel_tableoportunidade_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         else
         {
            divDvpanel_tableoportunidade_cell_Class = "col-xs-12 CellMarginBottom20";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         divTblencpesquisaavaliacao_Visible = ((AV9encRealizadoOnboard.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblencpesquisaavaliacao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblencpesquisaavaliacao_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV6DocOrigem, "NEGOCIOPJ") == 0 )
         {
            /* Using cursor H005T2 */
            pr_default.execute(0, new Object[] {AV14NegId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A345NegID = H005T2_A345NegID[0];
               A362NegAssunto = H005T2_A362NegAssunto[0];
               A356NegCodigo = H005T2_A356NegCodigo[0];
               Dvpanel_tableoportunidade_Title = StringUtil.StringReplace( StringUtil.StringReplace( Dvpanel_tableoportunidade_Title, "[!NEGCODIGO!]", StringUtil.Trim( StringUtil.Str( (decimal)(A356NegCodigo), 12, 0))), "[!NEGASSUNTO!]", StringUtil.Trim( A362NegAssunto));
               ucDvpanel_tableoportunidade.SendProperty(context, "", false, Dvpanel_tableoportunidade_Internalname, "Title", Dvpanel_tableoportunidade_Title);
               /* Exiting from a For First loop. */
               if (true) break;
            }
            pr_default.close(0);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E125T2 ();
         if (returnInSub) return;
      }

      protected void E125T2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV14NegId = StringUtil.StrToGuid( StringUtil.Trim( AV7DocOrigemID));
         AssignAttri("", false, "AV14NegId", AV14NegId.ToString());
         AV9encRealizadoOnboard.gxTpr_Negid = AV14NegId;
         AV9encRealizadoOnboard.gxTpr_Nefchave = "ENCREALIZADOONBOARD";
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult )
         {
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV9encRealizadoOnboard,  true, out  AV13Messages) ;
         }
         if ( ( ( AV13Messages.Count == 0 ) || ( ( AV13Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV13Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV5CheckRequiredFieldsResult )
         {
            AV8encPesquisaAvaliacao.gxTpr_Negid = AV14NegId;
            AV8encPesquisaAvaliacao.gxTpr_Nefchave = "ENCPESQUISAAVALIACAO";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV8encPesquisaAvaliacao,  true, out  AV13Messages) ;
         }
         AV10HasError = false;
         AV19GXV3 = 1;
         while ( AV19GXV3 <= AV13Messages.Count )
         {
            AV12Message = ((GeneXus.Utils.SdtMessages_Message)AV13Messages.Item(AV19GXV3));
            if ( AV12Message.gxTpr_Type == 1 )
            {
               AV10HasError = true;
               GX_msglist.addItem(AV12Message.gxTpr_Description);
               if (true) break;
            }
            AV19GXV3 = (int)(AV19GXV3+1);
         }
         if ( ! AV10HasError && AV5CheckRequiredFieldsResult )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9encRealizadoOnboard", AV9encRealizadoOnboard);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13Messages", AV13Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8encPesquisaAvaliacao", AV8encPesquisaAvaliacao);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV5CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV5CheckRequiredFieldsResult", AV5CheckRequiredFieldsResult);
      }

      protected void nextLoad( )
      {
      }

      protected void E135T2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV6DocOrigem = (string)getParm(obj,0);
         AssignAttri("", false, "AV6DocOrigem", AV6DocOrigem);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigem, "")), context));
         AV7DocOrigemID = (string)getParm(obj,1);
         AssignAttri("", false, "AV7DocOrigemID", AV7DocOrigemID);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7DocOrigemID, "")), context));
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
         PA5T2( ) ;
         WS5T2( ) ;
         WE5T2( ) ;
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
         if ( ! ( WebComp_Wcnegociopjgeneral == null ) )
         {
            if ( StringUtil.Len( WebComp_Wcnegociopjgeneral_Component) != 0 )
            {
               WebComp_Wcnegociopjgeneral.componentthemes();
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20238214284817", true, true);
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
         context.AddJavascriptSource("wpencerramentofluxo.js", "?20238214284817", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         cmbavEncrealizadoonboard_nefconfirmado.Name = "ENCREALIZADOONBOARD_NEFCONFIRMADO";
         cmbavEncrealizadoonboard_nefconfirmado.WebTags = "";
         cmbavEncrealizadoonboard_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavEncrealizadoonboard_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavEncrealizadoonboard_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavEncrealizadoonboard_nefconfirmado.ItemCount > 0 )
         {
            AV9encRealizadoOnboard.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavEncrealizadoonboard_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9encRealizadoOnboard.gxTpr_Nefconfirmado)));
         }
         cmbavEncpesquisaavaliacao_nefconfirmado.Name = "ENCPESQUISAAVALIACAO_NEFCONFIRMADO";
         cmbavEncpesquisaavaliacao_nefconfirmado.WebTags = "";
         cmbavEncpesquisaavaliacao_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavEncpesquisaavaliacao_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavEncpesquisaavaliacao_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavEncpesquisaavaliacao_nefconfirmado.ItemCount > 0 )
         {
            AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavEncpesquisaavaliacao_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV8encPesquisaAvaliacao.gxTpr_Nefconfirmado)));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         divDvpanel_tableoportunidade_cell_Internalname = "DVPANEL_TABLEOPORTUNIDADE_CELL";
         cmbavEncrealizadoonboard_nefconfirmado_Internalname = "ENCREALIZADOONBOARD_NEFCONFIRMADO";
         divPnlencrealizadoonboard_Internalname = "PNLENCREALIZADOONBOARD";
         Dvpanel_pnlencrealizadoonboard_Internalname = "DVPANEL_PNLENCREALIZADOONBOARD";
         divTblencrealizadoonboard_Internalname = "TBLENCREALIZADOONBOARD";
         cmbavEncpesquisaavaliacao_nefconfirmado_Internalname = "ENCPESQUISAAVALIACAO_NEFCONFIRMADO";
         divPnlencpesquisaavaliacao_Internalname = "PNLENCPESQUISAAVALIACAO";
         Dvpanel_pnlencpesquisaavaliacao_Internalname = "DVPANEL_PNLENCPESQUISAAVALIACAO";
         divTblencpesquisaavaliacao_Internalname = "TBLENCPESQUISAAVALIACAO";
         bttBtncancel_Internalname = "BTNCANCEL";
         bttBtnenter_Internalname = "BTNENTER";
         divTableactions_Internalname = "TABLEACTIONS";
         divTableheadercontent_Internalname = "TABLEHEADERCONTENT";
         divTableheader_Internalname = "TABLEHEADER";
         divTablemain_Internalname = "TABLEMAIN";
         edtavDocorigem_Internalname = "vDOCORIGEM";
         edtavDocorigemid_Internalname = "vDOCORIGEMID";
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
         edtavDocorigemid_Jsonclick = "";
         edtavDocorigemid_Visible = 1;
         edtavDocorigem_Jsonclick = "";
         edtavDocorigem_Visible = 1;
         cmbavEncpesquisaavaliacao_nefconfirmado_Jsonclick = "";
         cmbavEncpesquisaavaliacao_nefconfirmado.Enabled = 1;
         divTblencpesquisaavaliacao_Visible = 1;
         cmbavEncrealizadoonboard_nefconfirmado_Jsonclick = "";
         cmbavEncrealizadoonboard_nefconfirmado.Enabled = 1;
         divDvpanel_tableoportunidade_cell_Class = "col-xs-12";
         Dvpanel_pnlencpesquisaavaliacao_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlencpesquisaavaliacao_Iconposition = "Right";
         Dvpanel_pnlencpesquisaavaliacao_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlencpesquisaavaliacao_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlencpesquisaavaliacao_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlencpesquisaavaliacao_Title = "";
         Dvpanel_pnlencpesquisaavaliacao_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlencpesquisaavaliacao_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlencpesquisaavaliacao_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlencpesquisaavaliacao_Width = "100%";
         Dvpanel_pnlencrealizadoonboard_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlencrealizadoonboard_Iconposition = "Right";
         Dvpanel_pnlencrealizadoonboard_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlencrealizadoonboard_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlencrealizadoonboard_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlencrealizadoonboard_Title = "";
         Dvpanel_pnlencrealizadoonboard_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlencrealizadoonboard_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlencrealizadoonboard_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlencrealizadoonboard_Width = "100%";
         Dvpanel_tableoportunidade_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Iconposition = "Right";
         Dvpanel_tableoportunidade_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Collapsed = Convert.ToBoolean( 1);
         Dvpanel_tableoportunidade_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Title = "Negociação [!NEGCODIGO!]: [!NEGASSUNTO!]";
         Dvpanel_tableoportunidade_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableoportunidade_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableoportunidade_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableoportunidade_Width = "100%";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Encerramento";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV6DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV7DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E125T2',iparms:[{av:'AV7DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV9encRealizadoOnboard',fld:'vENCREALIZADOONBOARD',pic:''},{av:'AV5CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV13Messages',fld:'vMESSAGES',pic:''},{av:'AV8encPesquisaAvaliacao',fld:'vENCPESQUISAAVALIACAO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV14NegId',fld:'vNEGID',pic:''},{av:'AV9encRealizadoOnboard',fld:'vENCREALIZADOONBOARD',pic:''},{av:'AV13Messages',fld:'vMESSAGES',pic:''},{av:'AV8encPesquisaAvaliacao',fld:'vENCPESQUISAAVALIACAO',pic:''},{av:'AV5CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
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
         wcpOAV6DocOrigem = "";
         wcpOAV7DocOrigemID = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9encRealizadoOnboard = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV8encPesquisaAvaliacao = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV13Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_pnlencrealizadoonboard = new GXUserControl();
         TempTags = "";
         ucDvpanel_pnlencpesquisaavaliacao = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV14NegId = Guid.Empty;
         GXt_SdtSDTNegocioPJFluxo1 = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         scmdbuf = "";
         H005T2_A345NegID = new Guid[] {Guid.Empty} ;
         H005T2_A362NegAssunto = new string[] {""} ;
         H005T2_A356NegCodigo = new long[1] ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         AV12Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wpencerramentofluxo__default(),
            new Object[][] {
                new Object[] {
               H005T2_A345NegID, H005T2_A362NegAssunto, H005T2_A356NegCodigo
               }
            }
         );
         WebComp_Wcnegociopjgeneral = new GeneXus.Http.GXNullWebComponent();
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
      private short nGXWrapped ;
      private int divTblencpesquisaavaliacao_Visible ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigemid_Visible ;
      private int AV19GXV3 ;
      private int idxLst ;
      private long A356NegCodigo ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Dvpanel_tableoportunidade_Width ;
      private string Dvpanel_tableoportunidade_Cls ;
      private string Dvpanel_tableoportunidade_Title ;
      private string Dvpanel_tableoportunidade_Iconposition ;
      private string Dvpanel_pnlencrealizadoonboard_Width ;
      private string Dvpanel_pnlencrealizadoonboard_Cls ;
      private string Dvpanel_pnlencrealizadoonboard_Title ;
      private string Dvpanel_pnlencrealizadoonboard_Iconposition ;
      private string Dvpanel_pnlencpesquisaavaliacao_Width ;
      private string Dvpanel_pnlencpesquisaavaliacao_Cls ;
      private string Dvpanel_pnlencpesquisaavaliacao_Title ;
      private string Dvpanel_pnlencpesquisaavaliacao_Iconposition ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string divDvpanel_tableoportunidade_cell_Internalname ;
      private string divDvpanel_tableoportunidade_cell_Class ;
      private string Dvpanel_tableoportunidade_Internalname ;
      private string divTableoportunidade_Internalname ;
      private string WebComp_Wcnegociopjgeneral_Component ;
      private string OldWcnegociopjgeneral ;
      private string ClassString ;
      private string StyleString ;
      private string divTblencrealizadoonboard_Internalname ;
      private string Dvpanel_pnlencrealizadoonboard_Internalname ;
      private string divPnlencrealizadoonboard_Internalname ;
      private string cmbavEncrealizadoonboard_nefconfirmado_Internalname ;
      private string TempTags ;
      private string cmbavEncrealizadoonboard_nefconfirmado_Jsonclick ;
      private string divTblencpesquisaavaliacao_Internalname ;
      private string Dvpanel_pnlencpesquisaavaliacao_Internalname ;
      private string divPnlencpesquisaavaliacao_Internalname ;
      private string cmbavEncpesquisaavaliacao_nefconfirmado_Internalname ;
      private string cmbavEncpesquisaavaliacao_nefconfirmado_Jsonclick ;
      private string divTableheader_Internalname ;
      private string divTableheadercontent_Internalname ;
      private string divTableactions_Internalname ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtavDocorigem_Internalname ;
      private string edtavDocorigem_Jsonclick ;
      private string edtavDocorigemid_Internalname ;
      private string edtavDocorigemid_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private string scmdbuf ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool Dvpanel_tableoportunidade_Autowidth ;
      private bool Dvpanel_tableoportunidade_Autoheight ;
      private bool Dvpanel_tableoportunidade_Collapsible ;
      private bool Dvpanel_tableoportunidade_Collapsed ;
      private bool Dvpanel_tableoportunidade_Showcollapseicon ;
      private bool Dvpanel_tableoportunidade_Autoscroll ;
      private bool Dvpanel_pnlencrealizadoonboard_Autowidth ;
      private bool Dvpanel_pnlencrealizadoonboard_Autoheight ;
      private bool Dvpanel_pnlencrealizadoonboard_Collapsible ;
      private bool Dvpanel_pnlencrealizadoonboard_Collapsed ;
      private bool Dvpanel_pnlencrealizadoonboard_Showcollapseicon ;
      private bool Dvpanel_pnlencrealizadoonboard_Autoscroll ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Autowidth ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Autoheight ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Collapsible ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Collapsed ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Showcollapseicon ;
      private bool Dvpanel_pnlencpesquisaavaliacao_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool AV10HasError ;
      private string AV6DocOrigem ;
      private string AV7DocOrigemID ;
      private string wcpOAV6DocOrigem ;
      private string wcpOAV7DocOrigemID ;
      private string A362NegAssunto ;
      private Guid AV14NegId ;
      private Guid A345NegID ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
      private GXUserControl ucDvpanel_tableoportunidade ;
      private GXUserControl ucDvpanel_pnlencrealizadoonboard ;
      private GXUserControl ucDvpanel_pnlencpesquisaavaliacao ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavEncrealizadoonboard_nefconfirmado ;
      private GXCombobox cmbavEncpesquisaavaliacao_nefconfirmado ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005T2_A345NegID ;
      private string[] H005T2_A362NegAssunto ;
      private long[] H005T2_A356NegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV13Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV9encRealizadoOnboard ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV8encPesquisaAvaliacao ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo GXt_SdtSDTNegocioPJFluxo1 ;
      private GeneXus.Utils.SdtMessages_Message AV12Message ;
   }

   public class wpencerramentofluxo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005T2;
          prmH005T2 = new Object[] {
          new ParDef("AV14NegId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005T2", "SELECT NegID, NegAssunto, NegCodigo FROM tb_negociopj WHERE NegID = :AV14NegId ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005T2,1, GxCacheFrequency.OFF ,false,true )
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
                ((long[]) buf[2])[0] = rslt.getLong(3);
                return;
       }
    }

 }

}
