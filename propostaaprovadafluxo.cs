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
   public class propostaaprovadafluxo : GXDataArea
   {
      public propostaaprovadafluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public propostaaprovadafluxo( IGxContext context )
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
         cmbavPropfluxoconfpropcomercial_nefconfirmado = new GXCombobox();
         cmbavPropfluxoregenvpropcliente_nefconfirmado = new GXCombobox();
         cmbavPropfluxoregrespropcliente_nefconfirmado = new GXCombobox();
         cmbavPropfluxoregrespropcliente_neftexto = new GXCombobox();
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
            return "propostaaprovadafluxo_Execute" ;
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
         PA5R2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5R2( ) ;
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
         GXEncryptionTmp = "propostaaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim(AV6DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV7DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("propostaaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Propfluxoconfpropcomercial", AV13propFluxoConfPropComercial);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Propfluxoconfpropcomercial", AV13propFluxoConfPropComercial);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Propfluxoregenvpropcliente", AV14propFluxoRegEnvPropCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Propfluxoregenvpropcliente", AV14propFluxoRegEnvPropCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Propfluxoregrespropcliente", AV15propFluxoRegResPropCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Propfluxoregrespropcliente", AV15propFluxoRegResPropCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV11Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV11Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPFLUXOCONFPROPCOMERCIAL", AV13propFluxoConfPropComercial);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPFLUXOCONFPROPCOMERCIAL", AV13propFluxoConfPropComercial);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPFLUXOREGENVPROPCLIENTE", AV14propFluxoRegEnvPropCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPFLUXOREGENVPROPCLIENTE", AV14propFluxoRegEnvPropCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPROPFLUXOREGRESPROPCLIENTE", AV15propFluxoRegResPropCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPROPFLUXOREGRESPROPCLIENTE", AV15propFluxoRegResPropCliente);
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Width", StringUtil.RTrim( Dvpanel_pnlconfpropcomercial_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Cls", StringUtil.RTrim( Dvpanel_pnlconfpropcomercial_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Title", StringUtil.RTrim( Dvpanel_pnlconfpropcomercial_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Iconposition", StringUtil.RTrim( Dvpanel_pnlconfpropcomercial_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFPROPCOMERCIAL_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlconfpropcomercial_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Width", StringUtil.RTrim( Dvpanel_pnlregenviopropcliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Cls", StringUtil.RTrim( Dvpanel_pnlregenviopropcliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Title", StringUtil.RTrim( Dvpanel_pnlregenviopropcliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_pnlregenviopropcliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVIOPROPCLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlregenviopropcliente_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Width", StringUtil.RTrim( Dvpanel_pnlregretpropcliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Cls", StringUtil.RTrim( Dvpanel_pnlregretpropcliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Title", StringUtil.RTrim( Dvpanel_pnlregretpropcliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_pnlregretpropcliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRETPROPCLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlregretpropcliente_Autoscroll));
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
            WE5R2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5R2( ) ;
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
         GXEncryptionTmp = "propostaaprovadafluxo.aspx"+UrlEncode(StringUtil.RTrim(AV6DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV7DocOrigemID));
         return formatLink("propostaaprovadafluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "PropostaAprovadaFluxo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Aprovação da Proposta" ;
      }

      protected void WB5R0( )
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
            GxWebStd.gx_div_start( context, divTblconfpropcomercial_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlconfpropcomercial.SetProperty("Width", Dvpanel_pnlconfpropcomercial_Width);
            ucDvpanel_pnlconfpropcomercial.SetProperty("AutoWidth", Dvpanel_pnlconfpropcomercial_Autowidth);
            ucDvpanel_pnlconfpropcomercial.SetProperty("AutoHeight", Dvpanel_pnlconfpropcomercial_Autoheight);
            ucDvpanel_pnlconfpropcomercial.SetProperty("Cls", Dvpanel_pnlconfpropcomercial_Cls);
            ucDvpanel_pnlconfpropcomercial.SetProperty("Title", Dvpanel_pnlconfpropcomercial_Title);
            ucDvpanel_pnlconfpropcomercial.SetProperty("Collapsible", Dvpanel_pnlconfpropcomercial_Collapsible);
            ucDvpanel_pnlconfpropcomercial.SetProperty("Collapsed", Dvpanel_pnlconfpropcomercial_Collapsed);
            ucDvpanel_pnlconfpropcomercial.SetProperty("ShowCollapseIcon", Dvpanel_pnlconfpropcomercial_Showcollapseicon);
            ucDvpanel_pnlconfpropcomercial.SetProperty("IconPosition", Dvpanel_pnlconfpropcomercial_Iconposition);
            ucDvpanel_pnlconfpropcomercial.SetProperty("AutoScroll", Dvpanel_pnlconfpropcomercial_Autoscroll);
            ucDvpanel_pnlconfpropcomercial.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlconfpropcomercial_Internalname, "DVPANEL_PNLCONFPROPCOMERCIALContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLCONFPROPCOMERCIALContainer"+"pnlConfPropComercial"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlconfpropcomercial_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname, "Proposta Comercial Confeccionada?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPropfluxoconfpropcomercial_nefconfirmado, cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname, StringUtil.BoolToStr( AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado), 1, cmbavPropfluxoconfpropcomercial_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavPropfluxoconfpropcomercial_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_PropostaAprovadaFluxo.htm");
            cmbavPropfluxoconfpropcomercial_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname, "Values", (string)(cmbavPropfluxoconfpropcomercial_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblregenviopropcliente_Internalname, divTblregenviopropcliente_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlregenviopropcliente.SetProperty("Width", Dvpanel_pnlregenviopropcliente_Width);
            ucDvpanel_pnlregenviopropcliente.SetProperty("AutoWidth", Dvpanel_pnlregenviopropcliente_Autowidth);
            ucDvpanel_pnlregenviopropcliente.SetProperty("AutoHeight", Dvpanel_pnlregenviopropcliente_Autoheight);
            ucDvpanel_pnlregenviopropcliente.SetProperty("Cls", Dvpanel_pnlregenviopropcliente_Cls);
            ucDvpanel_pnlregenviopropcliente.SetProperty("Title", Dvpanel_pnlregenviopropcliente_Title);
            ucDvpanel_pnlregenviopropcliente.SetProperty("Collapsible", Dvpanel_pnlregenviopropcliente_Collapsible);
            ucDvpanel_pnlregenviopropcliente.SetProperty("Collapsed", Dvpanel_pnlregenviopropcliente_Collapsed);
            ucDvpanel_pnlregenviopropcliente.SetProperty("ShowCollapseIcon", Dvpanel_pnlregenviopropcliente_Showcollapseicon);
            ucDvpanel_pnlregenviopropcliente.SetProperty("IconPosition", Dvpanel_pnlregenviopropcliente_Iconposition);
            ucDvpanel_pnlregenviopropcliente.SetProperty("AutoScroll", Dvpanel_pnlregenviopropcliente_Autoscroll);
            ucDvpanel_pnlregenviopropcliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlregenviopropcliente_Internalname, "DVPANEL_PNLREGENVIOPROPCLIENTEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLREGENVIOPROPCLIENTEContainer"+"pnlRegEnvioPropCliente"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlregenviopropcliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname, "Registrar Envio da Proposta ao Cliente?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPropfluxoregenvpropcliente_nefconfirmado, cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname, StringUtil.BoolToStr( AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado), 1, cmbavPropfluxoregenvpropcliente_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavPropfluxoregenvpropcliente_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_PropostaAprovadaFluxo.htm");
            cmbavPropfluxoregenvpropcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname, "Values", (string)(cmbavPropfluxoregenvpropcliente_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 CellMarginBottom20", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTblregretpropcliente_Internalname, divTblregretpropcliente_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlregretpropcliente.SetProperty("Width", Dvpanel_pnlregretpropcliente_Width);
            ucDvpanel_pnlregretpropcliente.SetProperty("AutoWidth", Dvpanel_pnlregretpropcliente_Autowidth);
            ucDvpanel_pnlregretpropcliente.SetProperty("AutoHeight", Dvpanel_pnlregretpropcliente_Autoheight);
            ucDvpanel_pnlregretpropcliente.SetProperty("Cls", Dvpanel_pnlregretpropcliente_Cls);
            ucDvpanel_pnlregretpropcliente.SetProperty("Title", Dvpanel_pnlregretpropcliente_Title);
            ucDvpanel_pnlregretpropcliente.SetProperty("Collapsible", Dvpanel_pnlregretpropcliente_Collapsible);
            ucDvpanel_pnlregretpropcliente.SetProperty("Collapsed", Dvpanel_pnlregretpropcliente_Collapsed);
            ucDvpanel_pnlregretpropcliente.SetProperty("ShowCollapseIcon", Dvpanel_pnlregretpropcliente_Showcollapseicon);
            ucDvpanel_pnlregretpropcliente.SetProperty("IconPosition", Dvpanel_pnlregretpropcliente_Iconposition);
            ucDvpanel_pnlregretpropcliente.SetProperty("AutoScroll", Dvpanel_pnlregretpropcliente_Autoscroll);
            ucDvpanel_pnlregretpropcliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlregretpropcliente_Internalname, "DVPANEL_PNLREGRETPROPCLIENTEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLREGRETPROPCLIENTEContainer"+"pnlRegRetPropCliente"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlregretpropcliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname, "Registrar Resposta da Proposta pelo Cliente?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPropfluxoregrespropcliente_nefconfirmado, cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname, StringUtil.BoolToStr( AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado), 1, cmbavPropfluxoregrespropcliente_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavPropfluxoregrespropcliente_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_PropostaAprovadaFluxo.htm");
            cmbavPropfluxoregrespropcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname, "Values", (string)(cmbavPropfluxoregrespropcliente_nefconfirmado.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divPropfluxoregrespropcliente_neftexto_cell_Internalname, 1, 0, "px", 0, "px", divPropfluxoregrespropcliente_neftexto_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", cmbavPropfluxoregrespropcliente_neftexto.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavPropfluxoregrespropcliente_neftexto_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavPropfluxoregrespropcliente_neftexto_Internalname, "Motivo Reprovação", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavPropfluxoregrespropcliente_neftexto, cmbavPropfluxoregrespropcliente_neftexto_Internalname, StringUtil.RTrim( AV15propFluxoRegResPropCliente.gxTpr_Neftexto), 1, cmbavPropfluxoregrespropcliente_neftexto_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", cmbavPropfluxoregrespropcliente_neftexto.Visible, cmbavPropfluxoregrespropcliente_neftexto.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,58);\"", "", true, 0, "HLP_PropostaAprovadaFluxo.htm");
            cmbavPropfluxoregrespropcliente_neftexto.CurrentValue = StringUtil.RTrim( AV15propFluxoRegResPropCliente.gxTpr_Neftexto);
            AssignProp("", false, cmbavPropfluxoregrespropcliente_neftexto_Internalname, "Values", (string)(cmbavPropfluxoregrespropcliente_neftexto.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaAprovadaFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 70,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Confirmar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_PropostaAprovadaFluxo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV6DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV6DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, 0, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaAprovadaFluxo.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV7DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV7DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_PropostaAprovadaFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5R2( )
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
            Form.Meta.addItem("description", "Aprovação da Proposta", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5R0( ) ;
      }

      protected void WS5R2( )
      {
         START5R2( ) ;
         EVT5R2( ) ;
      }

      protected void EVT5R2( )
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
                              E115R2 ();
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
                                    E125R2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135R2 ();
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

      protected void WE5R2( )
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

      protected void PA5R2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "propostaaprovadafluxo.aspx")), "propostaaprovadafluxo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "propostaaprovadafluxo.aspx")))) ;
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
               GX_FocusControl = cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname;
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
         if ( cmbavPropfluxoconfpropcomercial_nefconfirmado.ItemCount > 0 )
         {
            AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoconfpropcomercial_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPropfluxoconfpropcomercial_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname, "Values", cmbavPropfluxoconfpropcomercial_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavPropfluxoregenvpropcliente_nefconfirmado.ItemCount > 0 )
         {
            AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoregenvpropcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPropfluxoregenvpropcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname, "Values", cmbavPropfluxoregenvpropcliente_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavPropfluxoregrespropcliente_nefconfirmado.ItemCount > 0 )
         {
            AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoregrespropcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPropfluxoregrespropcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname, "Values", cmbavPropfluxoregrespropcliente_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavPropfluxoregrespropcliente_neftexto.ItemCount > 0 )
         {
            AV15propFluxoRegResPropCliente.gxTpr_Neftexto = cmbavPropfluxoregrespropcliente_neftexto.getValidValue(AV15propFluxoRegResPropCliente.gxTpr_Neftexto);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavPropfluxoregrespropcliente_neftexto.CurrentValue = StringUtil.RTrim( AV15propFluxoRegResPropCliente.gxTpr_Neftexto);
            AssignProp("", false, cmbavPropfluxoregrespropcliente_neftexto_Internalname, "Values", cmbavPropfluxoregrespropcliente_neftexto.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5R2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5R2( )
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
            E135R2 ();
            WB5R0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5R2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5R0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115R2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vPROPFLUXOCONFPROPCOMERCIAL"), AV13propFluxoConfPropComercial);
            ajax_req_read_hidden_sdt(cgiGet( "vPROPFLUXOREGENVPROPCLIENTE"), AV14propFluxoRegEnvPropCliente);
            ajax_req_read_hidden_sdt(cgiGet( "vPROPFLUXOREGRESPROPCLIENTE"), AV15propFluxoRegResPropCliente);
            ajax_req_read_hidden_sdt(cgiGet( "Propfluxoconfpropcomercial"), AV13propFluxoConfPropComercial);
            ajax_req_read_hidden_sdt(cgiGet( "Propfluxoregenvpropcliente"), AV14propFluxoRegEnvPropCliente);
            ajax_req_read_hidden_sdt(cgiGet( "Propfluxoregrespropcliente"), AV15propFluxoRegResPropCliente);
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
            Dvpanel_pnlconfpropcomercial_Width = cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Width");
            Dvpanel_pnlconfpropcomercial_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Autowidth"));
            Dvpanel_pnlconfpropcomercial_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Autoheight"));
            Dvpanel_pnlconfpropcomercial_Cls = cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Cls");
            Dvpanel_pnlconfpropcomercial_Title = cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Title");
            Dvpanel_pnlconfpropcomercial_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Collapsible"));
            Dvpanel_pnlconfpropcomercial_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Collapsed"));
            Dvpanel_pnlconfpropcomercial_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Showcollapseicon"));
            Dvpanel_pnlconfpropcomercial_Iconposition = cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Iconposition");
            Dvpanel_pnlconfpropcomercial_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFPROPCOMERCIAL_Autoscroll"));
            Dvpanel_pnlregenviopropcliente_Width = cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Width");
            Dvpanel_pnlregenviopropcliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Autowidth"));
            Dvpanel_pnlregenviopropcliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Autoheight"));
            Dvpanel_pnlregenviopropcliente_Cls = cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Cls");
            Dvpanel_pnlregenviopropcliente_Title = cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Title");
            Dvpanel_pnlregenviopropcliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Collapsible"));
            Dvpanel_pnlregenviopropcliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Collapsed"));
            Dvpanel_pnlregenviopropcliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Showcollapseicon"));
            Dvpanel_pnlregenviopropcliente_Iconposition = cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Iconposition");
            Dvpanel_pnlregenviopropcliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVIOPROPCLIENTE_Autoscroll"));
            Dvpanel_pnlregretpropcliente_Width = cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Width");
            Dvpanel_pnlregretpropcliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Autowidth"));
            Dvpanel_pnlregretpropcliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Autoheight"));
            Dvpanel_pnlregretpropcliente_Cls = cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Cls");
            Dvpanel_pnlregretpropcliente_Title = cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Title");
            Dvpanel_pnlregretpropcliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Collapsible"));
            Dvpanel_pnlregretpropcliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Collapsed"));
            Dvpanel_pnlregretpropcliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Showcollapseicon"));
            Dvpanel_pnlregretpropcliente_Iconposition = cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Iconposition");
            Dvpanel_pnlregretpropcliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRETPROPCLIENTE_Autoscroll"));
            /* Read variables values. */
            cmbavPropfluxoconfpropcomercial_nefconfirmado.CurrentValue = cgiGet( cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname);
            AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname));
            cmbavPropfluxoregenvpropcliente_nefconfirmado.CurrentValue = cgiGet( cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname);
            AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname));
            cmbavPropfluxoregrespropcliente_nefconfirmado.CurrentValue = cgiGet( cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname);
            AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname));
            cmbavPropfluxoregrespropcliente_neftexto.CurrentValue = cgiGet( cmbavPropfluxoregrespropcliente_neftexto_Internalname);
            AV15propFluxoRegResPropCliente.gxTpr_Neftexto = cgiGet( cmbavPropfluxoregrespropcliente_neftexto_Internalname);
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
         E115R2 ();
         if (returnInSub) return;
      }

      protected void E115R2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV12NegId = StringUtil.StrToGuid( StringUtil.Trim( AV7DocOrigemID));
         AssignAttri("", false, "AV12NegId", AV12NegId.ToString());
         GXt_SdtSDTNegocioPJFluxo1 = AV13propFluxoConfPropComercial;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV12NegId,  "PROPCONFECCIONAR", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV13propFluxoConfPropComercial = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV14propFluxoRegEnvPropCliente;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV12NegId,  "PROPREGENVIOCLIENTE", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV14propFluxoRegEnvPropCliente = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV15propFluxoRegResPropCliente;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV12NegId,  "PROPREGRESPCLIENTE", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV15propFluxoRegResPropCliente = GXt_SdtSDTNegocioPJFluxo1;
         /* Execute user subroutine: 'PROPFLUXOREGRESPROPCLIENTE_MONTARCOMBO' */
         S112 ();
         if (returnInSub) return;
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
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

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ! AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado ) )
         {
            cmbavPropfluxoregrespropcliente_neftexto.Visible = 0;
            AssignProp("", false, cmbavPropfluxoregrespropcliente_neftexto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavPropfluxoregrespropcliente_neftexto.Visible), 5, 0), true);
            divPropfluxoregrespropcliente_neftexto_cell_Class = "Invisible";
            AssignProp("", false, divPropfluxoregrespropcliente_neftexto_cell_Internalname, "Class", divPropfluxoregrespropcliente_neftexto_cell_Class, true);
         }
         else
         {
            cmbavPropfluxoregrespropcliente_neftexto.Visible = 1;
            AssignProp("", false, cmbavPropfluxoregrespropcliente_neftexto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavPropfluxoregrespropcliente_neftexto.Visible), 5, 0), true);
            divPropfluxoregrespropcliente_neftexto_cell_Class = "col-xs-12 col-sm-6";
            AssignProp("", false, divPropfluxoregrespropcliente_neftexto_cell_Internalname, "Class", divPropfluxoregrespropcliente_neftexto_cell_Class, true);
         }
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
         divTblregenviopropcliente_Visible = ((AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregenviopropcliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregenviopropcliente_Visible), 5, 0), true);
         divTblregretpropcliente_Visible = ((AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregretpropcliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregretpropcliente_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV6DocOrigem, "NEGOCIOPJ") == 0 )
         {
            /* Using cursor H005R2 */
            pr_default.execute(0, new Object[] {AV12NegId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A345NegID = H005R2_A345NegID[0];
               A362NegAssunto = H005R2_A362NegAssunto[0];
               A356NegCodigo = H005R2_A356NegCodigo[0];
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
         E125R2 ();
         if (returnInSub) return;
      }

      protected void E125R2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV12NegId = StringUtil.StrToGuid( StringUtil.Trim( AV7DocOrigemID));
         AssignAttri("", false, "AV12NegId", AV12NegId.ToString());
         AV13propFluxoConfPropComercial.gxTpr_Negid = AV12NegId;
         AV13propFluxoConfPropComercial.gxTpr_Nefchave = "PROPCONFECCIONAR";
         AV5CheckRequiredFieldsResult = true;
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S132 ();
         if (returnInSub) return;
         if ( AV5CheckRequiredFieldsResult )
         {
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV13propFluxoConfPropComercial,  true, out  AV11Messages) ;
         }
         if ( ( ( AV11Messages.Count == 0 ) || ( ( AV11Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV5CheckRequiredFieldsResult )
         {
            AV14propFluxoRegEnvPropCliente.gxTpr_Negid = AV12NegId;
            AV14propFluxoRegEnvPropCliente.gxTpr_Nefchave = "PROPREGENVIOCLIENTE";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV14propFluxoRegEnvPropCliente,  true, out  AV11Messages) ;
         }
         if ( ( ( AV11Messages.Count == 0 ) || ( ( AV11Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV5CheckRequiredFieldsResult )
         {
            AV15propFluxoRegResPropCliente.gxTpr_Negid = AV12NegId;
            AV15propFluxoRegResPropCliente.gxTpr_Nefchave = "PROPREGRESPCLIENTE";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV15propFluxoRegResPropCliente,  true, out  AV11Messages) ;
         }
         AV8HasError = false;
         AV22GXV5 = 1;
         while ( AV22GXV5 <= AV11Messages.Count )
         {
            AV10Message = ((GeneXus.Utils.SdtMessages_Message)AV11Messages.Item(AV22GXV5));
            if ( AV10Message.gxTpr_Type == 1 )
            {
               AV8HasError = true;
               GX_msglist.addItem(AV10Message.gxTpr_Description);
               if (true) break;
            }
            AV22GXV5 = (int)(AV22GXV5+1);
         }
         if ( ! AV8HasError && AV5CheckRequiredFieldsResult )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV13propFluxoConfPropComercial", AV13propFluxoConfPropComercial);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11Messages", AV11Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV14propFluxoRegEnvPropCliente", AV14propFluxoRegEnvPropCliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV15propFluxoRegResPropCliente", AV15propFluxoRegResPropCliente);
      }

      protected void S112( )
      {
         /* 'PROPFLUXOREGRESPROPCLIENTE_MONTARCOMBO' Routine */
         returnInSub = false;
         cmbavPropfluxoregrespropcliente_neftexto.removeAllItems();
         cmbavPropfluxoregrespropcliente_neftexto.addItem("", "(Nenhum)", 0);
         cmbavPropfluxoregrespropcliente_neftexto.addItem("ReprovadaCliente", gxdomainpropostarespostaclientereprovada.getDescription(context,"ReprovadaCliente"), 0);
         cmbavPropfluxoregrespropcliente_neftexto.addItem("ClienteSolicitouRenegociacao", gxdomainpropostarespostaclientereprovada.getDescription(context,"ClienteSolicitouRenegociacao"), 0);
      }

      protected void S132( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
      }

      protected void nextLoad( )
      {
      }

      protected void E135R2( )
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
         PA5R2( ) ;
         WS5R2( ) ;
         WE5R2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20238221201517", true, true);
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
         context.AddJavascriptSource("propostaaprovadafluxo.js", "?20238221201517", false, true);
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
         cmbavPropfluxoconfpropcomercial_nefconfirmado.Name = "PROPFLUXOCONFPROPCOMERCIAL_NEFCONFIRMADO";
         cmbavPropfluxoconfpropcomercial_nefconfirmado.WebTags = "";
         cmbavPropfluxoconfpropcomercial_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavPropfluxoconfpropcomercial_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavPropfluxoconfpropcomercial_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavPropfluxoconfpropcomercial_nefconfirmado.ItemCount > 0 )
         {
            AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoconfpropcomercial_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV13propFluxoConfPropComercial.gxTpr_Nefconfirmado)));
         }
         cmbavPropfluxoregenvpropcliente_nefconfirmado.Name = "PROPFLUXOREGENVPROPCLIENTE_NEFCONFIRMADO";
         cmbavPropfluxoregenvpropcliente_nefconfirmado.WebTags = "";
         cmbavPropfluxoregenvpropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavPropfluxoregenvpropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavPropfluxoregenvpropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavPropfluxoregenvpropcliente_nefconfirmado.ItemCount > 0 )
         {
            AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoregenvpropcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV14propFluxoRegEnvPropCliente.gxTpr_Nefconfirmado)));
         }
         cmbavPropfluxoregrespropcliente_nefconfirmado.Name = "PROPFLUXOREGRESPROPCLIENTE_NEFCONFIRMADO";
         cmbavPropfluxoregrespropcliente_nefconfirmado.WebTags = "";
         cmbavPropfluxoregrespropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavPropfluxoregrespropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavPropfluxoregrespropcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavPropfluxoregrespropcliente_nefconfirmado.ItemCount > 0 )
         {
            AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavPropfluxoregrespropcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV15propFluxoRegResPropCliente.gxTpr_Nefconfirmado)));
         }
         cmbavPropfluxoregrespropcliente_neftexto.Name = "PROPFLUXOREGRESPROPCLIENTE_NEFTEXTO";
         cmbavPropfluxoregrespropcliente_neftexto.WebTags = "";
         cmbavPropfluxoregrespropcliente_neftexto.addItem("Nenhum", "(Nenhum)", 0);
         if ( cmbavPropfluxoregrespropcliente_neftexto.ItemCount > 0 )
         {
            AV15propFluxoRegResPropCliente.gxTpr_Neftexto = cmbavPropfluxoregrespropcliente_neftexto.getValidValue(AV15propFluxoRegResPropCliente.gxTpr_Neftexto);
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         divDvpanel_tableoportunidade_cell_Internalname = "DVPANEL_TABLEOPORTUNIDADE_CELL";
         cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname = "PROPFLUXOCONFPROPCOMERCIAL_NEFCONFIRMADO";
         divPnlconfpropcomercial_Internalname = "PNLCONFPROPCOMERCIAL";
         Dvpanel_pnlconfpropcomercial_Internalname = "DVPANEL_PNLCONFPROPCOMERCIAL";
         divTblconfpropcomercial_Internalname = "TBLCONFPROPCOMERCIAL";
         cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname = "PROPFLUXOREGENVPROPCLIENTE_NEFCONFIRMADO";
         divPnlregenviopropcliente_Internalname = "PNLREGENVIOPROPCLIENTE";
         Dvpanel_pnlregenviopropcliente_Internalname = "DVPANEL_PNLREGENVIOPROPCLIENTE";
         divTblregenviopropcliente_Internalname = "TBLREGENVIOPROPCLIENTE";
         cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname = "PROPFLUXOREGRESPROPCLIENTE_NEFCONFIRMADO";
         cmbavPropfluxoregrespropcliente_neftexto_Internalname = "PROPFLUXOREGRESPROPCLIENTE_NEFTEXTO";
         divPropfluxoregrespropcliente_neftexto_cell_Internalname = "PROPFLUXOREGRESPROPCLIENTE_NEFTEXTO_CELL";
         divPnlregretpropcliente_Internalname = "PNLREGRETPROPCLIENTE";
         Dvpanel_pnlregretpropcliente_Internalname = "DVPANEL_PNLREGRETPROPCLIENTE";
         divTblregretpropcliente_Internalname = "TBLREGRETPROPCLIENTE";
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
         cmbavPropfluxoregrespropcliente_neftexto_Jsonclick = "";
         cmbavPropfluxoregrespropcliente_neftexto.Enabled = 1;
         cmbavPropfluxoregrespropcliente_neftexto.Visible = 1;
         divPropfluxoregrespropcliente_neftexto_cell_Class = "col-xs-12 col-sm-6";
         cmbavPropfluxoregrespropcliente_nefconfirmado_Jsonclick = "";
         cmbavPropfluxoregrespropcliente_nefconfirmado.Enabled = 1;
         divTblregretpropcliente_Visible = 1;
         cmbavPropfluxoregenvpropcliente_nefconfirmado_Jsonclick = "";
         cmbavPropfluxoregenvpropcliente_nefconfirmado.Enabled = 1;
         divTblregenviopropcliente_Visible = 1;
         cmbavPropfluxoconfpropcomercial_nefconfirmado_Jsonclick = "";
         cmbavPropfluxoconfpropcomercial_nefconfirmado.Enabled = 1;
         divDvpanel_tableoportunidade_cell_Class = "col-xs-12";
         Dvpanel_pnlregretpropcliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlregretpropcliente_Iconposition = "Right";
         Dvpanel_pnlregretpropcliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlregretpropcliente_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlregretpropcliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlregretpropcliente_Title = "";
         Dvpanel_pnlregretpropcliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlregretpropcliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlregretpropcliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlregretpropcliente_Width = "100%";
         Dvpanel_pnlregenviopropcliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlregenviopropcliente_Iconposition = "Right";
         Dvpanel_pnlregenviopropcliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlregenviopropcliente_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlregenviopropcliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlregenviopropcliente_Title = "";
         Dvpanel_pnlregenviopropcliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlregenviopropcliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlregenviopropcliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlregenviopropcliente_Width = "100%";
         Dvpanel_pnlconfpropcomercial_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlconfpropcomercial_Iconposition = "Right";
         Dvpanel_pnlconfpropcomercial_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlconfpropcomercial_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlconfpropcomercial_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlconfpropcomercial_Title = "";
         Dvpanel_pnlconfpropcomercial_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlconfpropcomercial_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlconfpropcomercial_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlconfpropcomercial_Width = "100%";
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
         Form.Caption = "Aprovação da Proposta";
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
         setEventMetadata("ENTER","{handler:'E125R2',iparms:[{av:'AV7DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV13propFluxoConfPropComercial',fld:'vPROPFLUXOCONFPROPCOMERCIAL',pic:''},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'AV14propFluxoRegEnvPropCliente',fld:'vPROPFLUXOREGENVPROPCLIENTE',pic:''},{av:'AV15propFluxoRegResPropCliente',fld:'vPROPFLUXOREGRESPROPCLIENTE',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV12NegId',fld:'vNEGID',pic:''},{av:'AV13propFluxoConfPropComercial',fld:'vPROPFLUXOCONFPROPCOMERCIAL',pic:''},{av:'AV11Messages',fld:'vMESSAGES',pic:''},{av:'AV14propFluxoRegEnvPropCliente',fld:'vPROPFLUXOREGENVPROPCLIENTE',pic:''},{av:'AV15propFluxoRegResPropCliente',fld:'vPROPFLUXOREGRESPROPCLIENTE',pic:''}]}");
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
         AV13propFluxoConfPropComercial = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV14propFluxoRegEnvPropCliente = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV15propFluxoRegResPropCliente = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV11Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_pnlconfpropcomercial = new GXUserControl();
         TempTags = "";
         ucDvpanel_pnlregenviopropcliente = new GXUserControl();
         ucDvpanel_pnlregretpropcliente = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV12NegId = Guid.Empty;
         GXt_SdtSDTNegocioPJFluxo1 = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         scmdbuf = "";
         H005R2_A345NegID = new Guid[] {Guid.Empty} ;
         H005R2_A362NegAssunto = new string[] {""} ;
         H005R2_A356NegCodigo = new long[1] ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         AV10Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.propostaaprovadafluxo__default(),
            new Object[][] {
                new Object[] {
               H005R2_A345NegID, H005R2_A362NegAssunto, H005R2_A356NegCodigo
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
      private int divTblregenviopropcliente_Visible ;
      private int divTblregretpropcliente_Visible ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigemid_Visible ;
      private int AV22GXV5 ;
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
      private string Dvpanel_pnlconfpropcomercial_Width ;
      private string Dvpanel_pnlconfpropcomercial_Cls ;
      private string Dvpanel_pnlconfpropcomercial_Title ;
      private string Dvpanel_pnlconfpropcomercial_Iconposition ;
      private string Dvpanel_pnlregenviopropcliente_Width ;
      private string Dvpanel_pnlregenviopropcliente_Cls ;
      private string Dvpanel_pnlregenviopropcliente_Title ;
      private string Dvpanel_pnlregenviopropcliente_Iconposition ;
      private string Dvpanel_pnlregretpropcliente_Width ;
      private string Dvpanel_pnlregretpropcliente_Cls ;
      private string Dvpanel_pnlregretpropcliente_Title ;
      private string Dvpanel_pnlregretpropcliente_Iconposition ;
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
      private string divTblconfpropcomercial_Internalname ;
      private string Dvpanel_pnlconfpropcomercial_Internalname ;
      private string divPnlconfpropcomercial_Internalname ;
      private string cmbavPropfluxoconfpropcomercial_nefconfirmado_Internalname ;
      private string TempTags ;
      private string cmbavPropfluxoconfpropcomercial_nefconfirmado_Jsonclick ;
      private string divTblregenviopropcliente_Internalname ;
      private string Dvpanel_pnlregenviopropcliente_Internalname ;
      private string divPnlregenviopropcliente_Internalname ;
      private string cmbavPropfluxoregenvpropcliente_nefconfirmado_Internalname ;
      private string cmbavPropfluxoregenvpropcliente_nefconfirmado_Jsonclick ;
      private string divTblregretpropcliente_Internalname ;
      private string Dvpanel_pnlregretpropcliente_Internalname ;
      private string divPnlregretpropcliente_Internalname ;
      private string cmbavPropfluxoregrespropcliente_nefconfirmado_Internalname ;
      private string cmbavPropfluxoregrespropcliente_nefconfirmado_Jsonclick ;
      private string divPropfluxoregrespropcliente_neftexto_cell_Internalname ;
      private string divPropfluxoregrespropcliente_neftexto_cell_Class ;
      private string cmbavPropfluxoregrespropcliente_neftexto_Internalname ;
      private string cmbavPropfluxoregrespropcliente_neftexto_Jsonclick ;
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
      private bool Dvpanel_tableoportunidade_Autowidth ;
      private bool Dvpanel_tableoportunidade_Autoheight ;
      private bool Dvpanel_tableoportunidade_Collapsible ;
      private bool Dvpanel_tableoportunidade_Collapsed ;
      private bool Dvpanel_tableoportunidade_Showcollapseicon ;
      private bool Dvpanel_tableoportunidade_Autoscroll ;
      private bool Dvpanel_pnlconfpropcomercial_Autowidth ;
      private bool Dvpanel_pnlconfpropcomercial_Autoheight ;
      private bool Dvpanel_pnlconfpropcomercial_Collapsible ;
      private bool Dvpanel_pnlconfpropcomercial_Collapsed ;
      private bool Dvpanel_pnlconfpropcomercial_Showcollapseicon ;
      private bool Dvpanel_pnlconfpropcomercial_Autoscroll ;
      private bool Dvpanel_pnlregenviopropcliente_Autowidth ;
      private bool Dvpanel_pnlregenviopropcliente_Autoheight ;
      private bool Dvpanel_pnlregenviopropcliente_Collapsible ;
      private bool Dvpanel_pnlregenviopropcliente_Collapsed ;
      private bool Dvpanel_pnlregenviopropcliente_Showcollapseicon ;
      private bool Dvpanel_pnlregenviopropcliente_Autoscroll ;
      private bool Dvpanel_pnlregretpropcliente_Autowidth ;
      private bool Dvpanel_pnlregretpropcliente_Autoheight ;
      private bool Dvpanel_pnlregretpropcliente_Collapsible ;
      private bool Dvpanel_pnlregretpropcliente_Collapsed ;
      private bool Dvpanel_pnlregretpropcliente_Showcollapseicon ;
      private bool Dvpanel_pnlregretpropcliente_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool AV5CheckRequiredFieldsResult ;
      private bool AV8HasError ;
      private string AV6DocOrigem ;
      private string AV7DocOrigemID ;
      private string wcpOAV6DocOrigem ;
      private string wcpOAV7DocOrigemID ;
      private string A362NegAssunto ;
      private Guid AV12NegId ;
      private Guid A345NegID ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
      private GXUserControl ucDvpanel_tableoportunidade ;
      private GXUserControl ucDvpanel_pnlconfpropcomercial ;
      private GXUserControl ucDvpanel_pnlregenviopropcliente ;
      private GXUserControl ucDvpanel_pnlregretpropcliente ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavPropfluxoconfpropcomercial_nefconfirmado ;
      private GXCombobox cmbavPropfluxoregenvpropcliente_nefconfirmado ;
      private GXCombobox cmbavPropfluxoregrespropcliente_nefconfirmado ;
      private GXCombobox cmbavPropfluxoregrespropcliente_neftexto ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005R2_A345NegID ;
      private string[] H005R2_A362NegAssunto ;
      private long[] H005R2_A356NegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV11Messages ;
      private GXWebForm Form ;
      private GeneXus.Utils.SdtMessages_Message AV10Message ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV13propFluxoConfPropComercial ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV14propFluxoRegEnvPropCliente ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV15propFluxoRegResPropCliente ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo GXt_SdtSDTNegocioPJFluxo1 ;
   }

   public class propostaaprovadafluxo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005R2;
          prmH005R2 = new Object[] {
          new ParDef("AV12NegId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005R2", "SELECT NegID, NegAssunto, NegCodigo FROM tb_negociopj WHERE NegID = :AV12NegId ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005R2,1, GxCacheFrequency.OFF ,false,true )
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
