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
   public class documentacaoaprovadafluxo : GXDataArea
   {
      public documentacaoaprovadafluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentacaoaprovadafluxo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID )
      {
         this.AV5DocOrigem = aP0_DocOrigem;
         this.AV6DocOrigemID = aP1_DocOrigemID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavDocfluxoanalisedocumentacao_nefconfirmado = new GXCombobox();
         cmbavDocfluxocafregistrarenvio_nefconfirmado = new GXCombobox();
         cmbavDocfluxocafregistrarretorno_nefconfirmado = new GXCombobox();
         cmbavDocfluxoanalisecredito_nefconfirmado = new GXCombobox();
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
            return "documentacaoaprovadafluxo_Execute" ;
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
         PA5Q2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5Q2( ) ;
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
         GXEncryptionTmp = "core.documentacaoaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim(AV5DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV6DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documentacaoaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigemID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Docfluxoanalisedocumentacao", AV9docFluxoAnaliseDocumentacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Docfluxoanalisedocumentacao", AV9docFluxoAnaliseDocumentacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Docfluxocafregistrarenvio", AV10docFluxoCAFRegistrarEnvio);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Docfluxocafregistrarenvio", AV10docFluxoCAFRegistrarEnvio);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Docfluxocafregistrarretorno", AV11docFluxoCAFRegistrarRetorno);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Docfluxocafregistrarretorno", AV11docFluxoCAFRegistrarRetorno);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Docfluxoanalisecredito", AV17docFluxoAnaliseCredito);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Docfluxoanalisecredito", AV17docFluxoAnaliseCredito);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV16CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV12Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV12Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCFLUXOANALISEDOCUMENTACAO", AV9docFluxoAnaliseDocumentacao);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCFLUXOANALISEDOCUMENTACAO", AV9docFluxoAnaliseDocumentacao);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCFLUXOCAFREGISTRARENVIO", AV10docFluxoCAFRegistrarEnvio);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCFLUXOCAFREGISTRARENVIO", AV10docFluxoCAFRegistrarEnvio);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCFLUXOCAFREGISTRARRETORNO", AV11docFluxoCAFRegistrarRetorno);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCFLUXOCAFREGISTRARRETORNO", AV11docFluxoCAFRegistrarRetorno);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCFLUXOANALISECREDITO", AV17docFluxoAnaliseCredito);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCFLUXOANALISECREDITO", AV17docFluxoAnaliseCredito);
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Width", StringUtil.RTrim( Dvpanel_pnlanadocumentacao_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Cls", StringUtil.RTrim( Dvpanel_pnlanadocumentacao_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Title", StringUtil.RTrim( Dvpanel_pnlanadocumentacao_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Iconposition", StringUtil.RTrim( Dvpanel_pnlanadocumentacao_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANADOCUMENTACAO_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlanadocumentacao_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Width", StringUtil.RTrim( Dvpanel_unnamedtable1_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autowidth", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoheight", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Cls", StringUtil.RTrim( Dvpanel_unnamedtable1_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Title", StringUtil.RTrim( Dvpanel_unnamedtable1_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsible", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Collapsed", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Iconposition", StringUtil.RTrim( Dvpanel_unnamedtable1_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_UNNAMEDTABLE1_Autoscroll", StringUtil.BoolToStr( Dvpanel_unnamedtable1_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Width", StringUtil.RTrim( Dvpanel_pnlregistrarretornocaf_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Cls", StringUtil.RTrim( Dvpanel_pnlregistrarretornocaf_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Title", StringUtil.RTrim( Dvpanel_pnlregistrarretornocaf_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Iconposition", StringUtil.RTrim( Dvpanel_pnlregistrarretornocaf_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGISTRARRETORNOCAF_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlregistrarretornocaf_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Width", StringUtil.RTrim( Dvpanel_pnlanacredito_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Cls", StringUtil.RTrim( Dvpanel_pnlanacredito_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Title", StringUtil.RTrim( Dvpanel_pnlanacredito_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Iconposition", StringUtil.RTrim( Dvpanel_pnlanacredito_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLANACREDITO_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlanacredito_Autoscroll));
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
            WE5Q2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5Q2( ) ;
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
         GXEncryptionTmp = "core.documentacaoaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim(AV5DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV6DocOrigemID));
         return formatLink("core.documentacaoaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.DocumentacaoAprovadaFluxo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aprovação da Documentação" ;
      }

      protected void WB5Q0( )
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
            GxWebStd.gx_div_start( context, divTblanadocumentacao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlanadocumentacao.SetProperty("Width", Dvpanel_pnlanadocumentacao_Width);
            ucDvpanel_pnlanadocumentacao.SetProperty("AutoWidth", Dvpanel_pnlanadocumentacao_Autowidth);
            ucDvpanel_pnlanadocumentacao.SetProperty("AutoHeight", Dvpanel_pnlanadocumentacao_Autoheight);
            ucDvpanel_pnlanadocumentacao.SetProperty("Cls", Dvpanel_pnlanadocumentacao_Cls);
            ucDvpanel_pnlanadocumentacao.SetProperty("Title", Dvpanel_pnlanadocumentacao_Title);
            ucDvpanel_pnlanadocumentacao.SetProperty("Collapsible", Dvpanel_pnlanadocumentacao_Collapsible);
            ucDvpanel_pnlanadocumentacao.SetProperty("Collapsed", Dvpanel_pnlanadocumentacao_Collapsed);
            ucDvpanel_pnlanadocumentacao.SetProperty("ShowCollapseIcon", Dvpanel_pnlanadocumentacao_Showcollapseicon);
            ucDvpanel_pnlanadocumentacao.SetProperty("IconPosition", Dvpanel_pnlanadocumentacao_Iconposition);
            ucDvpanel_pnlanadocumentacao.SetProperty("AutoScroll", Dvpanel_pnlanadocumentacao_Autoscroll);
            ucDvpanel_pnlanadocumentacao.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlanadocumentacao_Internalname, "DVPANEL_PNLANADOCUMENTACAOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLANADOCUMENTACAOContainer"+"pnlAnaDocumentacao"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlanadocumentacao_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname, "Análise da Documentação Aprovada?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocfluxoanalisedocumentacao_nefconfirmado, cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname, StringUtil.BoolToStr( AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado), 1, cmbavDocfluxoanalisedocumentacao_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocfluxoanalisedocumentacao_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            cmbavDocfluxoanalisedocumentacao_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname, "Values", (string)(cmbavDocfluxoanalisedocumentacao_nefconfirmado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDocfluxoanalisedocumentacao_neftexto_cell_Internalname, 1, 0, "px", 0, "px", divDocfluxoanalisedocumentacao_neftexto_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavDocfluxoanalisedocumentacao_neftexto_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDocfluxoanalisedocumentacao_neftexto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocfluxoanalisedocumentacao_neftexto_Internalname, "Motivo Reprovação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Multiple line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_html_textarea( context, edtavDocfluxoanalisedocumentacao_neftexto_Internalname, AV9docFluxoAnaliseDocumentacao.gxTpr_Neftexto, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", 0, edtavDocfluxoanalisedocumentacao_neftexto_Visible, edtavDocfluxoanalisedocumentacao_neftexto_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\DocumentacaoAprovadaFluxo.htm");
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
            GxWebStd.gx_div_start( context, divTblregistrarenviocaf_Internalname, divTblregistrarenviocaf_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_unnamedtable1.SetProperty("Width", Dvpanel_unnamedtable1_Width);
            ucDvpanel_unnamedtable1.SetProperty("AutoWidth", Dvpanel_unnamedtable1_Autowidth);
            ucDvpanel_unnamedtable1.SetProperty("AutoHeight", Dvpanel_unnamedtable1_Autoheight);
            ucDvpanel_unnamedtable1.SetProperty("Cls", Dvpanel_unnamedtable1_Cls);
            ucDvpanel_unnamedtable1.SetProperty("Title", Dvpanel_unnamedtable1_Title);
            ucDvpanel_unnamedtable1.SetProperty("Collapsible", Dvpanel_unnamedtable1_Collapsible);
            ucDvpanel_unnamedtable1.SetProperty("Collapsed", Dvpanel_unnamedtable1_Collapsed);
            ucDvpanel_unnamedtable1.SetProperty("ShowCollapseIcon", Dvpanel_unnamedtable1_Showcollapseicon);
            ucDvpanel_unnamedtable1.SetProperty("IconPosition", Dvpanel_unnamedtable1_Iconposition);
            ucDvpanel_unnamedtable1.SetProperty("AutoScroll", Dvpanel_unnamedtable1_Autoscroll);
            ucDvpanel_unnamedtable1.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_unnamedtable1_Internalname, "DVPANEL_UNNAMEDTABLE1Container");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_UNNAMEDTABLE1Container"+"UnnamedTable1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname, "Registrar Envio do CAF?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocfluxocafregistrarenvio_nefconfirmado, cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname, StringUtil.BoolToStr( AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado), 1, cmbavDocfluxocafregistrarenvio_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocfluxocafregistrarenvio_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,46);\"", "", true, 0, "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            cmbavDocfluxocafregistrarenvio_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname, "Values", (string)(cmbavDocfluxocafregistrarenvio_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 CellMarginBottom20", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblregistrarretornocaf_Internalname, divTblregistrarretornocaf_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlregistrarretornocaf.SetProperty("Width", Dvpanel_pnlregistrarretornocaf_Width);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("AutoWidth", Dvpanel_pnlregistrarretornocaf_Autowidth);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("AutoHeight", Dvpanel_pnlregistrarretornocaf_Autoheight);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("Cls", Dvpanel_pnlregistrarretornocaf_Cls);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("Title", Dvpanel_pnlregistrarretornocaf_Title);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("Collapsible", Dvpanel_pnlregistrarretornocaf_Collapsible);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("Collapsed", Dvpanel_pnlregistrarretornocaf_Collapsed);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("ShowCollapseIcon", Dvpanel_pnlregistrarretornocaf_Showcollapseicon);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("IconPosition", Dvpanel_pnlregistrarretornocaf_Iconposition);
            ucDvpanel_pnlregistrarretornocaf.SetProperty("AutoScroll", Dvpanel_pnlregistrarretornocaf_Autoscroll);
            ucDvpanel_pnlregistrarretornocaf.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlregistrarretornocaf_Internalname, "DVPANEL_PNLREGISTRARRETORNOCAFContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLREGISTRARRETORNOCAFContainer"+"pnlRegistrarRetornoCAF"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlregistrarretornocaf_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname, "Registrar Retorno do CAF?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocfluxocafregistrarretorno_nefconfirmado, cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname, StringUtil.BoolToStr( AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado), 1, cmbavDocfluxocafregistrarretorno_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocfluxocafregistrarretorno_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "", true, 0, "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            cmbavDocfluxocafregistrarretorno_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname, "Values", (string)(cmbavDocfluxocafregistrarretorno_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblanacredito_Internalname, divTblanacredito_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlanacredito.SetProperty("Width", Dvpanel_pnlanacredito_Width);
            ucDvpanel_pnlanacredito.SetProperty("AutoWidth", Dvpanel_pnlanacredito_Autowidth);
            ucDvpanel_pnlanacredito.SetProperty("AutoHeight", Dvpanel_pnlanacredito_Autoheight);
            ucDvpanel_pnlanacredito.SetProperty("Cls", Dvpanel_pnlanacredito_Cls);
            ucDvpanel_pnlanacredito.SetProperty("Title", Dvpanel_pnlanacredito_Title);
            ucDvpanel_pnlanacredito.SetProperty("Collapsible", Dvpanel_pnlanacredito_Collapsible);
            ucDvpanel_pnlanacredito.SetProperty("Collapsed", Dvpanel_pnlanacredito_Collapsed);
            ucDvpanel_pnlanacredito.SetProperty("ShowCollapseIcon", Dvpanel_pnlanacredito_Showcollapseicon);
            ucDvpanel_pnlanacredito.SetProperty("IconPosition", Dvpanel_pnlanacredito_Iconposition);
            ucDvpanel_pnlanacredito.SetProperty("AutoScroll", Dvpanel_pnlanacredito_Autoscroll);
            ucDvpanel_pnlanacredito.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlanacredito_Internalname, "DVPANEL_PNLANACREDITOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLANACREDITOContainer"+"pnlAnaCredito"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlanacredito_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavDocfluxoanalisecredito_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavDocfluxoanalisecredito_nefconfirmado_Internalname, "Análise de Crédito Aprovado?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 71,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavDocfluxoanalisecredito_nefconfirmado, cmbavDocfluxoanalisecredito_nefconfirmado_Internalname, StringUtil.BoolToStr( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado), 1, cmbavDocfluxoanalisecredito_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavDocfluxoanalisecredito_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,71);\"", "", true, 0, "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            cmbavDocfluxoanalisecredito_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxoanalisecredito_nefconfirmado_Internalname, "Values", (string)(cmbavDocfluxoanalisecredito_nefconfirmado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divDocfluxoanalisecredito_nefvalor_cell_Internalname, 1, 0, "px", 0, "px", divDocfluxoanalisecredito_nefvalor_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDocfluxoanalisecredito_nefvalor_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDocfluxoanalisecredito_nefvalor_Internalname, "Valor do Score Próprio", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 76,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDocfluxoanalisecredito_nefvalor_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV17docFluxoAnaliseCredito.gxTpr_Nefvalor), 3, 0, ",", "")), StringUtil.LTrim( ((edtavDocfluxoanalisecredito_nefvalor_Enabled!=0) ? context.localUtil.Format( (decimal)(AV17docFluxoAnaliseCredito.gxTpr_Nefvalor), "ZZ9") : context.localUtil.Format( (decimal)(AV17docFluxoAnaliseCredito.gxTpr_Nefvalor), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,76);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocfluxoanalisecredito_nefvalor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDocfluxoanalisecredito_nefvalor_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\DocumentacaoAprovadaFluxo.htm");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 87,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentacaoAprovadaFluxo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV5DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV5DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, 0, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV6DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV6DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentacaoAprovadaFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5Q2( )
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
            Form.Meta.addItem("description", "Aprovação da Documentação", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5Q0( ) ;
      }

      protected void WS5Q2( )
      {
         START5Q2( ) ;
         EVT5Q2( ) ;
      }

      protected void EVT5Q2( )
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
                              E115Q2 ();
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
                                    E125Q2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135Q2 ();
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

      protected void WE5Q2( )
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

      protected void PA5Q2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documentacaoaprovadafluxo.aspx")), "core.documentacaoaprovadafluxo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documentacaoaprovadafluxo.aspx")))) ;
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
                     AV5DocOrigem = gxfirstwebparm;
                     AssignAttri("", false, "AV5DocOrigem", AV5DocOrigem);
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5DocOrigem, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV6DocOrigemID = GetPar( "DocOrigemID");
                        AssignAttri("", false, "AV6DocOrigemID", AV6DocOrigemID);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigemID, "")), context));
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
               GX_FocusControl = cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname;
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
         if ( cmbavDocfluxoanalisedocumentacao_nefconfirmado.ItemCount > 0 )
         {
            AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxoanalisedocumentacao_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocfluxoanalisedocumentacao_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname, "Values", cmbavDocfluxoanalisedocumentacao_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavDocfluxocafregistrarenvio_nefconfirmado.ItemCount > 0 )
         {
            AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxocafregistrarenvio_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocfluxocafregistrarenvio_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname, "Values", cmbavDocfluxocafregistrarenvio_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavDocfluxocafregistrarretorno_nefconfirmado.ItemCount > 0 )
         {
            AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxocafregistrarretorno_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocfluxocafregistrarretorno_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname, "Values", cmbavDocfluxocafregistrarretorno_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavDocfluxoanalisecredito_nefconfirmado.ItemCount > 0 )
         {
            AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxoanalisecredito_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavDocfluxoanalisecredito_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavDocfluxoanalisecredito_nefconfirmado_Internalname, "Values", cmbavDocfluxoanalisecredito_nefconfirmado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5Q2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5Q2( )
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
            E135Q2 ();
            WB5Q0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5Q2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5Q0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115Q2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vDOCFLUXOANALISEDOCUMENTACAO"), AV9docFluxoAnaliseDocumentacao);
            ajax_req_read_hidden_sdt(cgiGet( "vDOCFLUXOCAFREGISTRARENVIO"), AV10docFluxoCAFRegistrarEnvio);
            ajax_req_read_hidden_sdt(cgiGet( "vDOCFLUXOCAFREGISTRARRETORNO"), AV11docFluxoCAFRegistrarRetorno);
            ajax_req_read_hidden_sdt(cgiGet( "vDOCFLUXOANALISECREDITO"), AV17docFluxoAnaliseCredito);
            ajax_req_read_hidden_sdt(cgiGet( "Docfluxoanalisedocumentacao"), AV9docFluxoAnaliseDocumentacao);
            ajax_req_read_hidden_sdt(cgiGet( "Docfluxocafregistrarenvio"), AV10docFluxoCAFRegistrarEnvio);
            ajax_req_read_hidden_sdt(cgiGet( "Docfluxocafregistrarretorno"), AV11docFluxoCAFRegistrarRetorno);
            ajax_req_read_hidden_sdt(cgiGet( "Docfluxoanalisecredito"), AV17docFluxoAnaliseCredito);
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
            Dvpanel_pnlanadocumentacao_Width = cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Width");
            Dvpanel_pnlanadocumentacao_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Autowidth"));
            Dvpanel_pnlanadocumentacao_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Autoheight"));
            Dvpanel_pnlanadocumentacao_Cls = cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Cls");
            Dvpanel_pnlanadocumentacao_Title = cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Title");
            Dvpanel_pnlanadocumentacao_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Collapsible"));
            Dvpanel_pnlanadocumentacao_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Collapsed"));
            Dvpanel_pnlanadocumentacao_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Showcollapseicon"));
            Dvpanel_pnlanadocumentacao_Iconposition = cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Iconposition");
            Dvpanel_pnlanadocumentacao_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANADOCUMENTACAO_Autoscroll"));
            Dvpanel_unnamedtable1_Width = cgiGet( "DVPANEL_UNNAMEDTABLE1_Width");
            Dvpanel_unnamedtable1_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autowidth"));
            Dvpanel_unnamedtable1_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoheight"));
            Dvpanel_unnamedtable1_Cls = cgiGet( "DVPANEL_UNNAMEDTABLE1_Cls");
            Dvpanel_unnamedtable1_Title = cgiGet( "DVPANEL_UNNAMEDTABLE1_Title");
            Dvpanel_unnamedtable1_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsible"));
            Dvpanel_unnamedtable1_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Collapsed"));
            Dvpanel_unnamedtable1_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Showcollapseicon"));
            Dvpanel_unnamedtable1_Iconposition = cgiGet( "DVPANEL_UNNAMEDTABLE1_Iconposition");
            Dvpanel_unnamedtable1_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_UNNAMEDTABLE1_Autoscroll"));
            Dvpanel_pnlregistrarretornocaf_Width = cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Width");
            Dvpanel_pnlregistrarretornocaf_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Autowidth"));
            Dvpanel_pnlregistrarretornocaf_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Autoheight"));
            Dvpanel_pnlregistrarretornocaf_Cls = cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Cls");
            Dvpanel_pnlregistrarretornocaf_Title = cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Title");
            Dvpanel_pnlregistrarretornocaf_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Collapsible"));
            Dvpanel_pnlregistrarretornocaf_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Collapsed"));
            Dvpanel_pnlregistrarretornocaf_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Showcollapseicon"));
            Dvpanel_pnlregistrarretornocaf_Iconposition = cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Iconposition");
            Dvpanel_pnlregistrarretornocaf_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGISTRARRETORNOCAF_Autoscroll"));
            Dvpanel_pnlanacredito_Width = cgiGet( "DVPANEL_PNLANACREDITO_Width");
            Dvpanel_pnlanacredito_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Autowidth"));
            Dvpanel_pnlanacredito_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Autoheight"));
            Dvpanel_pnlanacredito_Cls = cgiGet( "DVPANEL_PNLANACREDITO_Cls");
            Dvpanel_pnlanacredito_Title = cgiGet( "DVPANEL_PNLANACREDITO_Title");
            Dvpanel_pnlanacredito_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Collapsible"));
            Dvpanel_pnlanacredito_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Collapsed"));
            Dvpanel_pnlanacredito_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Showcollapseicon"));
            Dvpanel_pnlanacredito_Iconposition = cgiGet( "DVPANEL_PNLANACREDITO_Iconposition");
            Dvpanel_pnlanacredito_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLANACREDITO_Autoscroll"));
            /* Read variables values. */
            cmbavDocfluxoanalisedocumentacao_nefconfirmado.CurrentValue = cgiGet( cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname);
            AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname));
            AV9docFluxoAnaliseDocumentacao.gxTpr_Neftexto = cgiGet( edtavDocfluxoanalisedocumentacao_neftexto_Internalname);
            cmbavDocfluxocafregistrarenvio_nefconfirmado.CurrentValue = cgiGet( cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname);
            AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname));
            cmbavDocfluxocafregistrarretorno_nefconfirmado.CurrentValue = cgiGet( cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname);
            AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname));
            cmbavDocfluxoanalisecredito_nefconfirmado.CurrentValue = cgiGet( cmbavDocfluxoanalisecredito_nefconfirmado_Internalname);
            AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavDocfluxoanalisecredito_nefconfirmado_Internalname));
            if ( ( ( context.localUtil.CToN( cgiGet( edtavDocfluxoanalisecredito_nefvalor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavDocfluxoanalisecredito_nefvalor_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCFLUXOANALISECREDITO_NEFVALOR");
               GX_FocusControl = edtavDocfluxoanalisecredito_nefvalor_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV17docFluxoAnaliseCredito.gxTpr_Nefvalor = 0;
            }
            else
            {
               AV17docFluxoAnaliseCredito.gxTpr_Nefvalor = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtavDocfluxoanalisecredito_nefvalor_Internalname), ",", "."), 18, MidpointRounding.ToEven));
            }
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
         E115Q2 ();
         if (returnInSub) return;
      }

      protected void E115Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV15NegId = StringUtil.StrToGuid( StringUtil.Trim( AV6DocOrigemID));
         AssignAttri("", false, "AV15NegId", AV15NegId.ToString());
         GXt_SdtSDTNegocioPJFluxo1 = AV9docFluxoAnaliseDocumentacao;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV15NegId,  "DOCANALISE", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV9docFluxoAnaliseDocumentacao = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV10docFluxoCAFRegistrarEnvio;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV15NegId,  "DOCREGISTRARENVIOCAF", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV10docFluxoCAFRegistrarEnvio = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV11docFluxoCAFRegistrarRetorno;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV15NegId,  "DOCREGISTRARRETORNOCAF", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV11docFluxoCAFRegistrarRetorno = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV17docFluxoAnaliseCredito;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV15NegId,  "DOCANALISECREDITO", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV17docFluxoAnaliseCredito = GXt_SdtSDTNegocioPJFluxo1;
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
            WebComp_Wcnegociopjgeneral.componentprepare(new Object[] {(string)"W0014",(string)"",StringUtil.StrToGuid( StringUtil.Trim( AV6DocOrigemID))});
            WebComp_Wcnegociopjgeneral.componentbind(new Object[] {(string)""+""+"vDOCORIGEMID"+""+""});
         }
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV16CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         if ( ( ! AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado ) && String.IsNullOrEmpty(StringUtil.RTrim( AV9docFluxoAnaliseDocumentacao.gxTpr_Neftexto)) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Informe o Motivo da Não Aprovação da Análise da Documentação!",  "error",  edtavDocfluxoanalisedocumentacao_neftexto_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         }
         if ( ( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado ) && (0==AV17docFluxoAnaliseCredito.gxTpr_Nefvalor) )
         {
            GX_msglist.addItem(new GeneXus.Programs.wwpbaseobjects.dvmessagegetbasicnotificationmsg(context).executeUdp(  "",  "Informe o Valor do Score Próprio!",  "error",  edtavDocfluxoanalisecredito_nefvalor_Internalname,  "true",  ""));
            AV16CheckRequiredFieldsResult = false;
            AssignAttri("", false, "AV16CheckRequiredFieldsResult", AV16CheckRequiredFieldsResult);
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado )
         {
            divDocfluxoanalisecredito_nefvalor_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divDocfluxoanalisecredito_nefvalor_cell_Internalname, "Class", divDocfluxoanalisecredito_nefvalor_cell_Class, true);
         }
         else
         {
            divDocfluxoanalisecredito_nefvalor_cell_Class = "col-xs-12";
            AssignProp("", false, divDocfluxoanalisecredito_nefvalor_cell_Internalname, "Class", divDocfluxoanalisecredito_nefvalor_cell_Class, true);
         }
         if ( ! ( ! AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado ) )
         {
            edtavDocfluxoanalisedocumentacao_neftexto_Visible = 0;
            AssignProp("", false, edtavDocfluxoanalisedocumentacao_neftexto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocfluxoanalisedocumentacao_neftexto_Visible), 5, 0), true);
            divDocfluxoanalisedocumentacao_neftexto_cell_Class = "Invisible";
            AssignProp("", false, divDocfluxoanalisedocumentacao_neftexto_cell_Internalname, "Class", divDocfluxoanalisedocumentacao_neftexto_cell_Class, true);
         }
         else
         {
            edtavDocfluxoanalisedocumentacao_neftexto_Visible = 1;
            AssignProp("", false, edtavDocfluxoanalisedocumentacao_neftexto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocfluxoanalisedocumentacao_neftexto_Visible), 5, 0), true);
            divDocfluxoanalisedocumentacao_neftexto_cell_Class = "col-xs-12 DataContentCellFL RequiredDataContentCellFL";
            AssignProp("", false, divDocfluxoanalisedocumentacao_neftexto_cell_Internalname, "Class", divDocfluxoanalisedocumentacao_neftexto_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(AV5DocOrigem, "NEGOCIOPJ") == 0 ) ) )
         {
            divDvpanel_tableoportunidade_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         else
         {
            divDvpanel_tableoportunidade_cell_Class = "col-xs-12 CellMarginBottom20";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         divTblregistrarenviocaf_Visible = ((AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregistrarenviocaf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregistrarenviocaf_Visible), 5, 0), true);
         divTblregistrarretornocaf_Visible = ((AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregistrarretornocaf_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregistrarretornocaf_Visible), 5, 0), true);
         divTblanacredito_Visible = ((AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblanacredito_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblanacredito_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV5DocOrigem, "NEGOCIOPJ") == 0 )
         {
            /* Using cursor H005Q2 */
            pr_default.execute(0, new Object[] {AV15NegId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A345NegID = H005Q2_A345NegID[0];
               A362NegAssunto = H005Q2_A362NegAssunto[0];
               A356NegCodigo = H005Q2_A356NegCodigo[0];
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
         E125Q2 ();
         if (returnInSub) return;
      }

      protected void E125Q2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV15NegId = StringUtil.StrToGuid( StringUtil.Trim( AV6DocOrigemID));
         AssignAttri("", false, "AV15NegId", AV15NegId.ToString());
         AV9docFluxoAnaliseDocumentacao.gxTpr_Negid = AV15NegId;
         AV9docFluxoAnaliseDocumentacao.gxTpr_Nefchave = "DOCANALISE";
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV16CheckRequiredFieldsResult )
         {
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV9docFluxoAnaliseDocumentacao,  true, out  AV12Messages) ;
         }
         if ( ( ( AV12Messages.Count == 0 ) || ( ( AV12Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV12Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV16CheckRequiredFieldsResult )
         {
            AV10docFluxoCAFRegistrarEnvio.gxTpr_Negid = AV15NegId;
            AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefchave = "DOCREGISTRARENVIOCAF";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV10docFluxoCAFRegistrarEnvio,  true, out  AV12Messages) ;
         }
         if ( ( ( AV12Messages.Count == 0 ) || ( ( AV12Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV12Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV16CheckRequiredFieldsResult )
         {
            AV11docFluxoCAFRegistrarRetorno.gxTpr_Negid = AV15NegId;
            AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefchave = "DOCREGISTRARRETORNOCAF";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV11docFluxoCAFRegistrarRetorno,  true, out  AV12Messages) ;
         }
         if ( ( ( AV12Messages.Count == 0 ) || ( ( AV12Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV12Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV16CheckRequiredFieldsResult )
         {
            AV17docFluxoAnaliseCredito.gxTpr_Negid = AV15NegId;
            AV17docFluxoAnaliseCredito.gxTpr_Nefchave = "DOCANALISECREDITO";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV17docFluxoAnaliseCredito,  true, out  AV12Messages) ;
         }
         AV14HasError = false;
         AV25GXV7 = 1;
         while ( AV25GXV7 <= AV12Messages.Count )
         {
            AV13Message = ((GeneXus.Utils.SdtMessages_Message)AV12Messages.Item(AV25GXV7));
            if ( AV13Message.gxTpr_Type == 1 )
            {
               AV14HasError = true;
               GX_msglist.addItem(AV13Message.gxTpr_Description);
               if (true) break;
            }
            AV25GXV7 = (int)(AV25GXV7+1);
         }
         if ( ! AV14HasError && AV16CheckRequiredFieldsResult )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9docFluxoAnaliseDocumentacao", AV9docFluxoAnaliseDocumentacao);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12Messages", AV12Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10docFluxoCAFRegistrarEnvio", AV10docFluxoCAFRegistrarEnvio);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11docFluxoCAFRegistrarRetorno", AV11docFluxoCAFRegistrarRetorno);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV17docFluxoAnaliseCredito", AV17docFluxoAnaliseCredito);
      }

      protected void nextLoad( )
      {
      }

      protected void E135Q2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV5DocOrigem = (string)getParm(obj,0);
         AssignAttri("", false, "AV5DocOrigem", AV5DocOrigem);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV5DocOrigem, "")), context));
         AV6DocOrigemID = (string)getParm(obj,1);
         AssignAttri("", false, "AV6DocOrigemID", AV6DocOrigemID);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV6DocOrigemID, "")), context));
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
         PA5Q2( ) ;
         WS5Q2( ) ;
         WE5Q2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20238214285072", true, true);
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
         context.AddJavascriptSource("core/documentacaoaprovadafluxo.js", "?20238214285072", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
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
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.Name = "DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO";
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.WebTags = "";
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocfluxoanalisedocumentacao_nefconfirmado.ItemCount > 0 )
         {
            AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxoanalisedocumentacao_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9docFluxoAnaliseDocumentacao.gxTpr_Nefconfirmado)));
         }
         cmbavDocfluxocafregistrarenvio_nefconfirmado.Name = "DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO";
         cmbavDocfluxocafregistrarenvio_nefconfirmado.WebTags = "";
         cmbavDocfluxocafregistrarenvio_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavDocfluxocafregistrarenvio_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocfluxocafregistrarenvio_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocfluxocafregistrarenvio_nefconfirmado.ItemCount > 0 )
         {
            AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxocafregistrarenvio_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV10docFluxoCAFRegistrarEnvio.gxTpr_Nefconfirmado)));
         }
         cmbavDocfluxocafregistrarretorno_nefconfirmado.Name = "DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO";
         cmbavDocfluxocafregistrarretorno_nefconfirmado.WebTags = "";
         cmbavDocfluxocafregistrarretorno_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavDocfluxocafregistrarretorno_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocfluxocafregistrarretorno_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocfluxocafregistrarretorno_nefconfirmado.ItemCount > 0 )
         {
            AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxocafregistrarretorno_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV11docFluxoCAFRegistrarRetorno.gxTpr_Nefconfirmado)));
         }
         cmbavDocfluxoanalisecredito_nefconfirmado.Name = "DOCFLUXOANALISECREDITO_NEFCONFIRMADO";
         cmbavDocfluxoanalisecredito_nefconfirmado.WebTags = "";
         cmbavDocfluxoanalisecredito_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavDocfluxoanalisecredito_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavDocfluxoanalisecredito_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavDocfluxoanalisecredito_nefconfirmado.ItemCount > 0 )
         {
            AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavDocfluxoanalisecredito_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV17docFluxoAnaliseCredito.gxTpr_Nefconfirmado)));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         divDvpanel_tableoportunidade_cell_Internalname = "DVPANEL_TABLEOPORTUNIDADE_CELL";
         cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname = "DOCFLUXOANALISEDOCUMENTACAO_NEFCONFIRMADO";
         edtavDocfluxoanalisedocumentacao_neftexto_Internalname = "DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO";
         divDocfluxoanalisedocumentacao_neftexto_cell_Internalname = "DOCFLUXOANALISEDOCUMENTACAO_NEFTEXTO_CELL";
         divPnlanadocumentacao_Internalname = "PNLANADOCUMENTACAO";
         Dvpanel_pnlanadocumentacao_Internalname = "DVPANEL_PNLANADOCUMENTACAO";
         divTblanadocumentacao_Internalname = "TBLANADOCUMENTACAO";
         cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname = "DOCFLUXOCAFREGISTRARENVIO_NEFCONFIRMADO";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Dvpanel_unnamedtable1_Internalname = "DVPANEL_UNNAMEDTABLE1";
         divTblregistrarenviocaf_Internalname = "TBLREGISTRARENVIOCAF";
         cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname = "DOCFLUXOCAFREGISTRARRETORNO_NEFCONFIRMADO";
         divPnlregistrarretornocaf_Internalname = "PNLREGISTRARRETORNOCAF";
         Dvpanel_pnlregistrarretornocaf_Internalname = "DVPANEL_PNLREGISTRARRETORNOCAF";
         divTblregistrarretornocaf_Internalname = "TBLREGISTRARRETORNOCAF";
         cmbavDocfluxoanalisecredito_nefconfirmado_Internalname = "DOCFLUXOANALISECREDITO_NEFCONFIRMADO";
         edtavDocfluxoanalisecredito_nefvalor_Internalname = "DOCFLUXOANALISECREDITO_NEFVALOR";
         divDocfluxoanalisecredito_nefvalor_cell_Internalname = "DOCFLUXOANALISECREDITO_NEFVALOR_CELL";
         divPnlanacredito_Internalname = "PNLANACREDITO";
         Dvpanel_pnlanacredito_Internalname = "DVPANEL_PNLANACREDITO";
         divTblanacredito_Internalname = "TBLANACREDITO";
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
         edtavDocfluxoanalisecredito_nefvalor_Jsonclick = "";
         edtavDocfluxoanalisecredito_nefvalor_Enabled = 1;
         divDocfluxoanalisecredito_nefvalor_cell_Class = "col-xs-12";
         cmbavDocfluxoanalisecredito_nefconfirmado_Jsonclick = "";
         cmbavDocfluxoanalisecredito_nefconfirmado.Enabled = 1;
         divTblanacredito_Visible = 1;
         cmbavDocfluxocafregistrarretorno_nefconfirmado_Jsonclick = "";
         cmbavDocfluxocafregistrarretorno_nefconfirmado.Enabled = 1;
         divTblregistrarretornocaf_Visible = 1;
         cmbavDocfluxocafregistrarenvio_nefconfirmado_Jsonclick = "";
         cmbavDocfluxocafregistrarenvio_nefconfirmado.Enabled = 1;
         divTblregistrarenviocaf_Visible = 1;
         edtavDocfluxoanalisedocumentacao_neftexto_Enabled = 1;
         edtavDocfluxoanalisedocumentacao_neftexto_Visible = 1;
         divDocfluxoanalisedocumentacao_neftexto_cell_Class = "col-xs-12";
         cmbavDocfluxoanalisedocumentacao_nefconfirmado_Jsonclick = "";
         cmbavDocfluxoanalisedocumentacao_nefconfirmado.Enabled = 1;
         divDvpanel_tableoportunidade_cell_Class = "col-xs-12";
         Dvpanel_pnlanacredito_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlanacredito_Iconposition = "Right";
         Dvpanel_pnlanacredito_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlanacredito_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlanacredito_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlanacredito_Title = "";
         Dvpanel_pnlanacredito_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlanacredito_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlanacredito_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlanacredito_Width = "100%";
         Dvpanel_pnlregistrarretornocaf_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlregistrarretornocaf_Iconposition = "Right";
         Dvpanel_pnlregistrarretornocaf_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlregistrarretornocaf_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlregistrarretornocaf_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlregistrarretornocaf_Title = "";
         Dvpanel_pnlregistrarretornocaf_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlregistrarretornocaf_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlregistrarretornocaf_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlregistrarretornocaf_Width = "100%";
         Dvpanel_unnamedtable1_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Iconposition = "Right";
         Dvpanel_unnamedtable1_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Title = "";
         Dvpanel_unnamedtable1_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_unnamedtable1_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_unnamedtable1_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_unnamedtable1_Width = "100%";
         Dvpanel_pnlanadocumentacao_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlanadocumentacao_Iconposition = "Right";
         Dvpanel_pnlanadocumentacao_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlanadocumentacao_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlanadocumentacao_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlanadocumentacao_Title = "";
         Dvpanel_pnlanadocumentacao_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlanadocumentacao_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlanadocumentacao_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlanadocumentacao_Width = "100%";
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
         Form.Caption = "Aprovação da Documentação";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV5DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV6DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E125Q2',iparms:[{av:'AV6DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV9docFluxoAnaliseDocumentacao',fld:'vDOCFLUXOANALISEDOCUMENTACAO',pic:''},{av:'AV16CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV12Messages',fld:'vMESSAGES',pic:''},{av:'AV10docFluxoCAFRegistrarEnvio',fld:'vDOCFLUXOCAFREGISTRARENVIO',pic:''},{av:'AV11docFluxoCAFRegistrarRetorno',fld:'vDOCFLUXOCAFREGISTRARRETORNO',pic:''},{av:'AV17docFluxoAnaliseCredito',fld:'vDOCFLUXOANALISECREDITO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV15NegId',fld:'vNEGID',pic:''},{av:'AV9docFluxoAnaliseDocumentacao',fld:'vDOCFLUXOANALISEDOCUMENTACAO',pic:''},{av:'AV12Messages',fld:'vMESSAGES',pic:''},{av:'AV10docFluxoCAFRegistrarEnvio',fld:'vDOCFLUXOCAFREGISTRARENVIO',pic:''},{av:'AV11docFluxoCAFRegistrarRetorno',fld:'vDOCFLUXOCAFREGISTRARRETORNO',pic:''},{av:'AV17docFluxoAnaliseCredito',fld:'vDOCFLUXOANALISECREDITO',pic:''},{av:'AV16CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
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
         wcpOAV5DocOrigem = "";
         wcpOAV6DocOrigemID = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV9docFluxoAnaliseDocumentacao = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV10docFluxoCAFRegistrarEnvio = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV11docFluxoCAFRegistrarRetorno = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV17docFluxoAnaliseCredito = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV12Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_pnlanadocumentacao = new GXUserControl();
         TempTags = "";
         ucDvpanel_unnamedtable1 = new GXUserControl();
         ucDvpanel_pnlregistrarretornocaf = new GXUserControl();
         ucDvpanel_pnlanacredito = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV15NegId = Guid.Empty;
         GXt_SdtSDTNegocioPJFluxo1 = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         scmdbuf = "";
         H005Q2_A345NegID = new Guid[] {Guid.Empty} ;
         H005Q2_A362NegAssunto = new string[] {""} ;
         H005Q2_A356NegCodigo = new long[1] ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         AV13Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentacaoaprovadafluxo__default(),
            new Object[][] {
                new Object[] {
               H005Q2_A345NegID, H005Q2_A362NegAssunto, H005Q2_A356NegCodigo
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
      private int edtavDocfluxoanalisedocumentacao_neftexto_Visible ;
      private int edtavDocfluxoanalisedocumentacao_neftexto_Enabled ;
      private int divTblregistrarenviocaf_Visible ;
      private int divTblregistrarretornocaf_Visible ;
      private int divTblanacredito_Visible ;
      private int edtavDocfluxoanalisecredito_nefvalor_Enabled ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigemid_Visible ;
      private int AV25GXV7 ;
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
      private string Dvpanel_pnlanadocumentacao_Width ;
      private string Dvpanel_pnlanadocumentacao_Cls ;
      private string Dvpanel_pnlanadocumentacao_Title ;
      private string Dvpanel_pnlanadocumentacao_Iconposition ;
      private string Dvpanel_unnamedtable1_Width ;
      private string Dvpanel_unnamedtable1_Cls ;
      private string Dvpanel_unnamedtable1_Title ;
      private string Dvpanel_unnamedtable1_Iconposition ;
      private string Dvpanel_pnlregistrarretornocaf_Width ;
      private string Dvpanel_pnlregistrarretornocaf_Cls ;
      private string Dvpanel_pnlregistrarretornocaf_Title ;
      private string Dvpanel_pnlregistrarretornocaf_Iconposition ;
      private string Dvpanel_pnlanacredito_Width ;
      private string Dvpanel_pnlanacredito_Cls ;
      private string Dvpanel_pnlanacredito_Title ;
      private string Dvpanel_pnlanacredito_Iconposition ;
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
      private string divTblanadocumentacao_Internalname ;
      private string Dvpanel_pnlanadocumentacao_Internalname ;
      private string divPnlanadocumentacao_Internalname ;
      private string cmbavDocfluxoanalisedocumentacao_nefconfirmado_Internalname ;
      private string TempTags ;
      private string cmbavDocfluxoanalisedocumentacao_nefconfirmado_Jsonclick ;
      private string divDocfluxoanalisedocumentacao_neftexto_cell_Internalname ;
      private string divDocfluxoanalisedocumentacao_neftexto_cell_Class ;
      private string edtavDocfluxoanalisedocumentacao_neftexto_Internalname ;
      private string divTblregistrarenviocaf_Internalname ;
      private string Dvpanel_unnamedtable1_Internalname ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavDocfluxocafregistrarenvio_nefconfirmado_Internalname ;
      private string cmbavDocfluxocafregistrarenvio_nefconfirmado_Jsonclick ;
      private string divTblregistrarretornocaf_Internalname ;
      private string Dvpanel_pnlregistrarretornocaf_Internalname ;
      private string divPnlregistrarretornocaf_Internalname ;
      private string cmbavDocfluxocafregistrarretorno_nefconfirmado_Internalname ;
      private string cmbavDocfluxocafregistrarretorno_nefconfirmado_Jsonclick ;
      private string divTblanacredito_Internalname ;
      private string Dvpanel_pnlanacredito_Internalname ;
      private string divPnlanacredito_Internalname ;
      private string cmbavDocfluxoanalisecredito_nefconfirmado_Internalname ;
      private string cmbavDocfluxoanalisecredito_nefconfirmado_Jsonclick ;
      private string divDocfluxoanalisecredito_nefvalor_cell_Internalname ;
      private string divDocfluxoanalisecredito_nefvalor_cell_Class ;
      private string edtavDocfluxoanalisecredito_nefvalor_Internalname ;
      private string edtavDocfluxoanalisecredito_nefvalor_Jsonclick ;
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
      private bool AV16CheckRequiredFieldsResult ;
      private bool Dvpanel_tableoportunidade_Autowidth ;
      private bool Dvpanel_tableoportunidade_Autoheight ;
      private bool Dvpanel_tableoportunidade_Collapsible ;
      private bool Dvpanel_tableoportunidade_Collapsed ;
      private bool Dvpanel_tableoportunidade_Showcollapseicon ;
      private bool Dvpanel_tableoportunidade_Autoscroll ;
      private bool Dvpanel_pnlanadocumentacao_Autowidth ;
      private bool Dvpanel_pnlanadocumentacao_Autoheight ;
      private bool Dvpanel_pnlanadocumentacao_Collapsible ;
      private bool Dvpanel_pnlanadocumentacao_Collapsed ;
      private bool Dvpanel_pnlanadocumentacao_Showcollapseicon ;
      private bool Dvpanel_pnlanadocumentacao_Autoscroll ;
      private bool Dvpanel_unnamedtable1_Autowidth ;
      private bool Dvpanel_unnamedtable1_Autoheight ;
      private bool Dvpanel_unnamedtable1_Collapsible ;
      private bool Dvpanel_unnamedtable1_Collapsed ;
      private bool Dvpanel_unnamedtable1_Showcollapseicon ;
      private bool Dvpanel_unnamedtable1_Autoscroll ;
      private bool Dvpanel_pnlregistrarretornocaf_Autowidth ;
      private bool Dvpanel_pnlregistrarretornocaf_Autoheight ;
      private bool Dvpanel_pnlregistrarretornocaf_Collapsible ;
      private bool Dvpanel_pnlregistrarretornocaf_Collapsed ;
      private bool Dvpanel_pnlregistrarretornocaf_Showcollapseicon ;
      private bool Dvpanel_pnlregistrarretornocaf_Autoscroll ;
      private bool Dvpanel_pnlanacredito_Autowidth ;
      private bool Dvpanel_pnlanacredito_Autoheight ;
      private bool Dvpanel_pnlanacredito_Collapsible ;
      private bool Dvpanel_pnlanacredito_Collapsed ;
      private bool Dvpanel_pnlanacredito_Showcollapseicon ;
      private bool Dvpanel_pnlanacredito_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool AV14HasError ;
      private string AV5DocOrigem ;
      private string AV6DocOrigemID ;
      private string wcpOAV5DocOrigem ;
      private string wcpOAV6DocOrigemID ;
      private string A362NegAssunto ;
      private Guid AV15NegId ;
      private Guid A345NegID ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
      private GXUserControl ucDvpanel_tableoportunidade ;
      private GXUserControl ucDvpanel_pnlanadocumentacao ;
      private GXUserControl ucDvpanel_unnamedtable1 ;
      private GXUserControl ucDvpanel_pnlregistrarretornocaf ;
      private GXUserControl ucDvpanel_pnlanacredito ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavDocfluxoanalisedocumentacao_nefconfirmado ;
      private GXCombobox cmbavDocfluxocafregistrarenvio_nefconfirmado ;
      private GXCombobox cmbavDocfluxocafregistrarretorno_nefconfirmado ;
      private GXCombobox cmbavDocfluxoanalisecredito_nefconfirmado ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005Q2_A345NegID ;
      private string[] H005Q2_A362NegAssunto ;
      private long[] H005Q2_A356NegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV12Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV9docFluxoAnaliseDocumentacao ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV10docFluxoCAFRegistrarEnvio ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV11docFluxoCAFRegistrarRetorno ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV17docFluxoAnaliseCredito ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo GXt_SdtSDTNegocioPJFluxo1 ;
      private GeneXus.Utils.SdtMessages_Message AV13Message ;
   }

   public class documentacaoaprovadafluxo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005Q2;
          prmH005Q2 = new Object[] {
          new ParDef("AV15NegId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005Q2", "SELECT NegID, NegAssunto, NegCodigo FROM tb_negociopj WHERE NegID = :AV15NegId ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005Q2,1, GxCacheFrequency.OFF ,false,true )
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
