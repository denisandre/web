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
   public class assinaturacontratofluxo : GXDataArea
   {
      public assinaturacontratofluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public assinaturacontratofluxo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_DocOrigem ,
                           string aP1_DocOrigemID )
      {
         this.AV14DocOrigem = aP0_DocOrigem;
         this.AV15DocOrigemID = aP1_DocOrigemID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbavAssconfluxoentregagarantia_nefconfirmado = new GXCombobox();
         cmbavAssconfluxocomporgarantia_nefconfirmado = new GXCombobox();
         cmbavAssconfluxoverexicontabancaria_nefconfirmado = new GXCombobox();
         cmbavAssconfluxocontratarproduto_nefconfirmado = new GXCombobox();
         cmbavAssconfluxoconfeccontrato_nefconfirmado = new GXCombobox();
         cmbavAssconfluxoregenvcontcliente_nefconfirmado = new GXCombobox();
         cmbavAssconfluxoregrescontcliente_nefconfirmado = new GXCombobox();
         cmbavAssconfluxorecolherassinatura_nefconfirmado = new GXCombobox();
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
         PA5S2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START5S2( ) ;
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
         GXEncryptionTmp = "assinaturacontratofluxo.aspx"+UrlEncode(StringUtil.RTrim(AV14DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV15DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("assinaturacontratofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15DocOrigemID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxoentregagarantia", AV8assConFluxoEntregaGarantia);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxoentregagarantia", AV8assConFluxoEntregaGarantia);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxocomporgarantia", AV5assConFluxoComporGarantia);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxocomporgarantia", AV5assConFluxoComporGarantia);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxoverexicontabancaria", AV12assConFluxoVerExiContaBancaria);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxoverexicontabancaria", AV12assConFluxoVerExiContaBancaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxocontratarproduto", AV7assConFluxoContratarProduto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxocontratarproduto", AV7assConFluxoContratarProduto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxoconfeccontrato", AV6assConFluxoConfecContrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxoconfeccontrato", AV6assConFluxoConfecContrato);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxoregenvcontcliente", AV10assConFluxoRegEnvContCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxoregenvcontcliente", AV10assConFluxoRegEnvContCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxoregrescontcliente", AV11assConFluxoRegResContCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxoregrescontcliente", AV11assConFluxoRegResContCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "Assconfluxorecolherassinatura", AV9assConFluxoRecolherAssinatura);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("Assconfluxorecolherassinatura", AV9assConFluxoRecolherAssinatura);
         }
         GxWebStd.gx_boolean_hidden_field( context, "vCHECKREQUIREDFIELDSRESULT", AV13CheckRequiredFieldsResult);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vMESSAGES", AV19Messages);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vMESSAGES", AV19Messages);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOENTREGAGARANTIA", AV8assConFluxoEntregaGarantia);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOENTREGAGARANTIA", AV8assConFluxoEntregaGarantia);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOCOMPORGARANTIA", AV5assConFluxoComporGarantia);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOCOMPORGARANTIA", AV5assConFluxoComporGarantia);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOVEREXICONTABANCARIA", AV12assConFluxoVerExiContaBancaria);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOVEREXICONTABANCARIA", AV12assConFluxoVerExiContaBancaria);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOCONTRATARPRODUTO", AV7assConFluxoContratarProduto);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOCONTRATARPRODUTO", AV7assConFluxoContratarProduto);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOCONFECCONTRATO", AV6assConFluxoConfecContrato);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOCONFECCONTRATO", AV6assConFluxoConfecContrato);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOREGENVCONTCLIENTE", AV10assConFluxoRegEnvContCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOREGENVCONTCLIENTE", AV10assConFluxoRegEnvContCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXOREGRESCONTCLIENTE", AV11assConFluxoRegResContCliente);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXOREGRESCONTCLIENTE", AV11assConFluxoRegResContCliente);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vASSCONFLUXORECOLHERASSINATURA", AV9assConFluxoRecolherAssinatura);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vASSCONFLUXORECOLHERASSINATURA", AV9assConFluxoRecolherAssinatura);
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
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Width", StringUtil.RTrim( Dvpanel_pnlconfentregagarantia_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Cls", StringUtil.RTrim( Dvpanel_pnlconfentregagarantia_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Title", StringUtil.RTrim( Dvpanel_pnlconfentregagarantia_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Iconposition", StringUtil.RTrim( Dvpanel_pnlconfentregagarantia_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFENTREGAGARANTIA_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlconfentregagarantia_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Width", StringUtil.RTrim( Dvpanel_pnlconfcomporgarantia_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Cls", StringUtil.RTrim( Dvpanel_pnlconfcomporgarantia_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Title", StringUtil.RTrim( Dvpanel_pnlconfcomporgarantia_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Iconposition", StringUtil.RTrim( Dvpanel_pnlconfcomporgarantia_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFCOMPORGARANTIA_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlconfcomporgarantia_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Width", StringUtil.RTrim( Dvpanel_pnlverexicontabancaria_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Cls", StringUtil.RTrim( Dvpanel_pnlverexicontabancaria_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Title", StringUtil.RTrim( Dvpanel_pnlverexicontabancaria_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Iconposition", StringUtil.RTrim( Dvpanel_pnlverexicontabancaria_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLVEREXICONTABANCARIA_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlverexicontabancaria_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Width", StringUtil.RTrim( Dvpanel_pnlcontratarproduto_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Cls", StringUtil.RTrim( Dvpanel_pnlcontratarproduto_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Title", StringUtil.RTrim( Dvpanel_pnlcontratarproduto_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Iconposition", StringUtil.RTrim( Dvpanel_pnlcontratarproduto_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONTRATARPRODUTO_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlcontratarproduto_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Width", StringUtil.RTrim( Dvpanel_pnlconfeccontrato_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Cls", StringUtil.RTrim( Dvpanel_pnlconfeccontrato_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Title", StringUtil.RTrim( Dvpanel_pnlconfeccontrato_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Iconposition", StringUtil.RTrim( Dvpanel_pnlconfeccontrato_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLCONFECCONTRATO_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlconfeccontrato_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Width", StringUtil.RTrim( Dvpanel_pnlregenvcontcliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Cls", StringUtil.RTrim( Dvpanel_pnlregenvcontcliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Title", StringUtil.RTrim( Dvpanel_pnlregenvcontcliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_pnlregenvcontcliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGENVCONTCLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlregenvcontcliente_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Width", StringUtil.RTrim( Dvpanel_pnlregrescontcliente_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Cls", StringUtil.RTrim( Dvpanel_pnlregrescontcliente_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Title", StringUtil.RTrim( Dvpanel_pnlregrescontcliente_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Iconposition", StringUtil.RTrim( Dvpanel_pnlregrescontcliente_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLREGRESCONTCLIENTE_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlregrescontcliente_Autoscroll));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Width", StringUtil.RTrim( Dvpanel_pnlrecolherassinaturas_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Autowidth", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Autoheight", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Cls", StringUtil.RTrim( Dvpanel_pnlrecolherassinaturas_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Title", StringUtil.RTrim( Dvpanel_pnlrecolherassinaturas_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Collapsible", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Collapsed", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Iconposition", StringUtil.RTrim( Dvpanel_pnlrecolherassinaturas_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_PNLRECOLHERASSINATURAS_Autoscroll", StringUtil.BoolToStr( Dvpanel_pnlrecolherassinaturas_Autoscroll));
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
            WE5S2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT5S2( ) ;
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
         GXEncryptionTmp = "assinaturacontratofluxo.aspx"+UrlEncode(StringUtil.RTrim(AV14DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV15DocOrigemID));
         return formatLink("assinaturacontratofluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "AssinaturaContratoFluxo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Assinatura do Contrato" ;
      }

      protected void WB5S0( )
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
            GxWebStd.gx_div_start( context, divTblconfentregagarantia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlconfentregagarantia.SetProperty("Width", Dvpanel_pnlconfentregagarantia_Width);
            ucDvpanel_pnlconfentregagarantia.SetProperty("AutoWidth", Dvpanel_pnlconfentregagarantia_Autowidth);
            ucDvpanel_pnlconfentregagarantia.SetProperty("AutoHeight", Dvpanel_pnlconfentregagarantia_Autoheight);
            ucDvpanel_pnlconfentregagarantia.SetProperty("Cls", Dvpanel_pnlconfentregagarantia_Cls);
            ucDvpanel_pnlconfentregagarantia.SetProperty("Title", Dvpanel_pnlconfentregagarantia_Title);
            ucDvpanel_pnlconfentregagarantia.SetProperty("Collapsible", Dvpanel_pnlconfentregagarantia_Collapsible);
            ucDvpanel_pnlconfentregagarantia.SetProperty("Collapsed", Dvpanel_pnlconfentregagarantia_Collapsed);
            ucDvpanel_pnlconfentregagarantia.SetProperty("ShowCollapseIcon", Dvpanel_pnlconfentregagarantia_Showcollapseicon);
            ucDvpanel_pnlconfentregagarantia.SetProperty("IconPosition", Dvpanel_pnlconfentregagarantia_Iconposition);
            ucDvpanel_pnlconfentregagarantia.SetProperty("AutoScroll", Dvpanel_pnlconfentregagarantia_Autoscroll);
            ucDvpanel_pnlconfentregagarantia.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlconfentregagarantia_Internalname, "DVPANEL_PNLCONFENTREGAGARANTIAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLCONFENTREGAGARANTIAContainer"+"pnlConfEntregaGarantia"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlconfentregagarantia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname, "Entrega da Garantia Realizada?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxoentregagarantia_nefconfirmado, cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname, StringUtil.BoolToStr( AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado), 1, cmbavAssconfluxoentregagarantia_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxoentregagarantia_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,29);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxoentregagarantia_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxoentregagarantia_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblconfcomporgarantia_Internalname, divTblconfcomporgarantia_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlconfcomporgarantia.SetProperty("Width", Dvpanel_pnlconfcomporgarantia_Width);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("AutoWidth", Dvpanel_pnlconfcomporgarantia_Autowidth);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("AutoHeight", Dvpanel_pnlconfcomporgarantia_Autoheight);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("Cls", Dvpanel_pnlconfcomporgarantia_Cls);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("Title", Dvpanel_pnlconfcomporgarantia_Title);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("Collapsible", Dvpanel_pnlconfcomporgarantia_Collapsible);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("Collapsed", Dvpanel_pnlconfcomporgarantia_Collapsed);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("ShowCollapseIcon", Dvpanel_pnlconfcomporgarantia_Showcollapseicon);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("IconPosition", Dvpanel_pnlconfcomporgarantia_Iconposition);
            ucDvpanel_pnlconfcomporgarantia.SetProperty("AutoScroll", Dvpanel_pnlconfcomporgarantia_Autoscroll);
            ucDvpanel_pnlconfcomporgarantia.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlconfcomporgarantia_Internalname, "DVPANEL_PNLCONFCOMPORGARANTIAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLCONFCOMPORGARANTIAContainer"+"pnlConfComporGarantia"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlconfcomporgarantia_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname, "Composição da Garantia Realizada?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxocomporgarantia_nefconfirmado, cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname, StringUtil.BoolToStr( AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado), 1, cmbavAssconfluxocomporgarantia_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxocomporgarantia_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,41);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxocomporgarantia_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxocomporgarantia_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblverexicontabancaria_Internalname, divTblverexicontabancaria_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlverexicontabancaria.SetProperty("Width", Dvpanel_pnlverexicontabancaria_Width);
            ucDvpanel_pnlverexicontabancaria.SetProperty("AutoWidth", Dvpanel_pnlverexicontabancaria_Autowidth);
            ucDvpanel_pnlverexicontabancaria.SetProperty("AutoHeight", Dvpanel_pnlverexicontabancaria_Autoheight);
            ucDvpanel_pnlverexicontabancaria.SetProperty("Cls", Dvpanel_pnlverexicontabancaria_Cls);
            ucDvpanel_pnlverexicontabancaria.SetProperty("Title", Dvpanel_pnlverexicontabancaria_Title);
            ucDvpanel_pnlverexicontabancaria.SetProperty("Collapsible", Dvpanel_pnlverexicontabancaria_Collapsible);
            ucDvpanel_pnlverexicontabancaria.SetProperty("Collapsed", Dvpanel_pnlverexicontabancaria_Collapsed);
            ucDvpanel_pnlverexicontabancaria.SetProperty("ShowCollapseIcon", Dvpanel_pnlverexicontabancaria_Showcollapseicon);
            ucDvpanel_pnlverexicontabancaria.SetProperty("IconPosition", Dvpanel_pnlverexicontabancaria_Iconposition);
            ucDvpanel_pnlverexicontabancaria.SetProperty("AutoScroll", Dvpanel_pnlverexicontabancaria_Autoscroll);
            ucDvpanel_pnlverexicontabancaria.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlverexicontabancaria_Internalname, "DVPANEL_PNLVEREXICONTABANCARIAContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLVEREXICONTABANCARIAContainer"+"pnlVerExiContaBancaria"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlverexicontabancaria_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname, "Conta Bancária Ativa?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxoverexicontabancaria_nefconfirmado, cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname, StringUtil.BoolToStr( AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado), 1, cmbavAssconfluxoverexicontabancaria_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxoverexicontabancaria_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxoverexicontabancaria_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxoverexicontabancaria_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblcontratarproduto_Internalname, divTblcontratarproduto_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlcontratarproduto.SetProperty("Width", Dvpanel_pnlcontratarproduto_Width);
            ucDvpanel_pnlcontratarproduto.SetProperty("AutoWidth", Dvpanel_pnlcontratarproduto_Autowidth);
            ucDvpanel_pnlcontratarproduto.SetProperty("AutoHeight", Dvpanel_pnlcontratarproduto_Autoheight);
            ucDvpanel_pnlcontratarproduto.SetProperty("Cls", Dvpanel_pnlcontratarproduto_Cls);
            ucDvpanel_pnlcontratarproduto.SetProperty("Title", Dvpanel_pnlcontratarproduto_Title);
            ucDvpanel_pnlcontratarproduto.SetProperty("Collapsible", Dvpanel_pnlcontratarproduto_Collapsible);
            ucDvpanel_pnlcontratarproduto.SetProperty("Collapsed", Dvpanel_pnlcontratarproduto_Collapsed);
            ucDvpanel_pnlcontratarproduto.SetProperty("ShowCollapseIcon", Dvpanel_pnlcontratarproduto_Showcollapseicon);
            ucDvpanel_pnlcontratarproduto.SetProperty("IconPosition", Dvpanel_pnlcontratarproduto_Iconposition);
            ucDvpanel_pnlcontratarproduto.SetProperty("AutoScroll", Dvpanel_pnlcontratarproduto_Autoscroll);
            ucDvpanel_pnlcontratarproduto.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlcontratarproduto_Internalname, "DVPANEL_PNLCONTRATARPRODUTOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLCONTRATARPRODUTOContainer"+"pnlContratarProduto"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlcontratarproduto_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname, "Produto Contratado?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxocontratarproduto_nefconfirmado, cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname, StringUtil.BoolToStr( AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado), 1, cmbavAssconfluxocontratarproduto_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxocontratarproduto_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,66);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxocontratarproduto_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxocontratarproduto_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblconfeccontrato_Internalname, divTblconfeccontrato_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlconfeccontrato.SetProperty("Width", Dvpanel_pnlconfeccontrato_Width);
            ucDvpanel_pnlconfeccontrato.SetProperty("AutoWidth", Dvpanel_pnlconfeccontrato_Autowidth);
            ucDvpanel_pnlconfeccontrato.SetProperty("AutoHeight", Dvpanel_pnlconfeccontrato_Autoheight);
            ucDvpanel_pnlconfeccontrato.SetProperty("Cls", Dvpanel_pnlconfeccontrato_Cls);
            ucDvpanel_pnlconfeccontrato.SetProperty("Title", Dvpanel_pnlconfeccontrato_Title);
            ucDvpanel_pnlconfeccontrato.SetProperty("Collapsible", Dvpanel_pnlconfeccontrato_Collapsible);
            ucDvpanel_pnlconfeccontrato.SetProperty("Collapsed", Dvpanel_pnlconfeccontrato_Collapsed);
            ucDvpanel_pnlconfeccontrato.SetProperty("ShowCollapseIcon", Dvpanel_pnlconfeccontrato_Showcollapseicon);
            ucDvpanel_pnlconfeccontrato.SetProperty("IconPosition", Dvpanel_pnlconfeccontrato_Iconposition);
            ucDvpanel_pnlconfeccontrato.SetProperty("AutoScroll", Dvpanel_pnlconfeccontrato_Autoscroll);
            ucDvpanel_pnlconfeccontrato.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlconfeccontrato_Internalname, "DVPANEL_PNLCONFECCONTRATOContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLCONFECCONTRATOContainer"+"pnlConfecContrato"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlconfeccontrato_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname, "Contrato Confeccionado?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxoconfeccontrato_nefconfirmado, cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname, StringUtil.BoolToStr( AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado), 1, cmbavAssconfluxoconfeccontrato_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxoconfeccontrato_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxoconfeccontrato_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxoconfeccontrato_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblregenvcontcliente_Internalname, divTblregenvcontcliente_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlregenvcontcliente.SetProperty("Width", Dvpanel_pnlregenvcontcliente_Width);
            ucDvpanel_pnlregenvcontcliente.SetProperty("AutoWidth", Dvpanel_pnlregenvcontcliente_Autowidth);
            ucDvpanel_pnlregenvcontcliente.SetProperty("AutoHeight", Dvpanel_pnlregenvcontcliente_Autoheight);
            ucDvpanel_pnlregenvcontcliente.SetProperty("Cls", Dvpanel_pnlregenvcontcliente_Cls);
            ucDvpanel_pnlregenvcontcliente.SetProperty("Title", Dvpanel_pnlregenvcontcliente_Title);
            ucDvpanel_pnlregenvcontcliente.SetProperty("Collapsible", Dvpanel_pnlregenvcontcliente_Collapsible);
            ucDvpanel_pnlregenvcontcliente.SetProperty("Collapsed", Dvpanel_pnlregenvcontcliente_Collapsed);
            ucDvpanel_pnlregenvcontcliente.SetProperty("ShowCollapseIcon", Dvpanel_pnlregenvcontcliente_Showcollapseicon);
            ucDvpanel_pnlregenvcontcliente.SetProperty("IconPosition", Dvpanel_pnlregenvcontcliente_Iconposition);
            ucDvpanel_pnlregenvcontcliente.SetProperty("AutoScroll", Dvpanel_pnlregenvcontcliente_Autoscroll);
            ucDvpanel_pnlregenvcontcliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlregenvcontcliente_Internalname, "DVPANEL_PNLREGENVCONTCLIENTEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLREGENVCONTCLIENTEContainer"+"pnlRegEnvContCliente"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlregenvcontcliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname, "Registrar Envio do Contrato ao Cliente?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxoregenvcontcliente_nefconfirmado, cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname, StringUtil.BoolToStr( AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado), 1, cmbavAssconfluxoregenvcontcliente_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxoregenvcontcliente_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,91);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxoregenvcontcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxoregenvcontcliente_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblregrescontcliente_Internalname, divTblregrescontcliente_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlregrescontcliente.SetProperty("Width", Dvpanel_pnlregrescontcliente_Width);
            ucDvpanel_pnlregrescontcliente.SetProperty("AutoWidth", Dvpanel_pnlregrescontcliente_Autowidth);
            ucDvpanel_pnlregrescontcliente.SetProperty("AutoHeight", Dvpanel_pnlregrescontcliente_Autoheight);
            ucDvpanel_pnlregrescontcliente.SetProperty("Cls", Dvpanel_pnlregrescontcliente_Cls);
            ucDvpanel_pnlregrescontcliente.SetProperty("Title", Dvpanel_pnlregrescontcliente_Title);
            ucDvpanel_pnlregrescontcliente.SetProperty("Collapsible", Dvpanel_pnlregrescontcliente_Collapsible);
            ucDvpanel_pnlregrescontcliente.SetProperty("Collapsed", Dvpanel_pnlregrescontcliente_Collapsed);
            ucDvpanel_pnlregrescontcliente.SetProperty("ShowCollapseIcon", Dvpanel_pnlregrescontcliente_Showcollapseicon);
            ucDvpanel_pnlregrescontcliente.SetProperty("IconPosition", Dvpanel_pnlregrescontcliente_Iconposition);
            ucDvpanel_pnlregrescontcliente.SetProperty("AutoScroll", Dvpanel_pnlregrescontcliente_Autoscroll);
            ucDvpanel_pnlregrescontcliente.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlregrescontcliente_Internalname, "DVPANEL_PNLREGRESCONTCLIENTEContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLREGRESCONTCLIENTEContainer"+"pnlRegResContCliente"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlregrescontcliente_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname, "Registrar Resposta de Aceite do Contrato pelo Cliente?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxoregrescontcliente_nefconfirmado, cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname, StringUtil.BoolToStr( AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado), 1, cmbavAssconfluxoregrescontcliente_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxoregrescontcliente_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxoregrescontcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxoregrescontcliente_nefconfirmado.ToJavascriptSource()), true);
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
            GxWebStd.gx_div_start( context, divTblrecolherassinaturas_Internalname, divTblrecolherassinaturas_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucDvpanel_pnlrecolherassinaturas.SetProperty("Width", Dvpanel_pnlrecolherassinaturas_Width);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("AutoWidth", Dvpanel_pnlrecolherassinaturas_Autowidth);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("AutoHeight", Dvpanel_pnlrecolherassinaturas_Autoheight);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("Cls", Dvpanel_pnlrecolherassinaturas_Cls);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("Title", Dvpanel_pnlrecolherassinaturas_Title);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("Collapsible", Dvpanel_pnlrecolherassinaturas_Collapsible);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("Collapsed", Dvpanel_pnlrecolherassinaturas_Collapsed);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("ShowCollapseIcon", Dvpanel_pnlrecolherassinaturas_Showcollapseicon);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("IconPosition", Dvpanel_pnlrecolherassinaturas_Iconposition);
            ucDvpanel_pnlrecolherassinaturas.SetProperty("AutoScroll", Dvpanel_pnlrecolherassinaturas_Autoscroll);
            ucDvpanel_pnlrecolherassinaturas.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_pnlrecolherassinaturas_Internalname, "DVPANEL_PNLRECOLHERASSINATURASContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_PNLRECOLHERASSINATURASContainer"+"pnlRecolherAssinaturas"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divPnlrecolherassinaturas_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname, "Assinaturas Recolhidas?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavAssconfluxorecolherassinatura_nefconfirmado, cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname, StringUtil.BoolToStr( AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado), 1, cmbavAssconfluxorecolherassinatura_nefconfirmado_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "boolean", "", 1, cmbavAssconfluxorecolherassinatura_nefconfirmado.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,116);\"", "", true, 0, "HLP_AssinaturaContratoFluxo.htm");
            cmbavAssconfluxorecolherassinatura_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname, "Values", (string)(cmbavAssconfluxorecolherassinatura_nefconfirmado.ToJavascriptSource()), true);
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 127,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Voltar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaContratoFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 129,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", "Salvar", bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_AssinaturaContratoFluxo.htm");
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
            GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV14DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV14DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, 0, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaContratoFluxo.htm");
            /* Single line edit */
            GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV15DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV15DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, 0, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_AssinaturaContratoFluxo.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START5S2( )
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
            Form.Meta.addItem("description", "Assinatura do Contrato", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP5S0( ) ;
      }

      protected void WS5S2( )
      {
         START5S2( ) ;
         EVT5S2( ) ;
      }

      protected void EVT5S2( )
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
                              E115S2 ();
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
                                    E125S2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E135S2 ();
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

      protected void WE5S2( )
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

      protected void PA5S2( )
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "assinaturacontratofluxo.aspx")), "assinaturacontratofluxo.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "assinaturacontratofluxo.aspx")))) ;
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
                     AV14DocOrigem = gxfirstwebparm;
                     AssignAttri("", false, "AV14DocOrigem", AV14DocOrigem);
                     GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14DocOrigem, "")), context));
                     if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
                     {
                        AV15DocOrigemID = GetPar( "DocOrigemID");
                        AssignAttri("", false, "AV15DocOrigemID", AV15DocOrigemID);
                        GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15DocOrigemID, "")), context));
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
               GX_FocusControl = cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname;
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
         if ( cmbavAssconfluxoentregagarantia_nefconfirmado.ItemCount > 0 )
         {
            AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoentregagarantia_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxoentregagarantia_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname, "Values", cmbavAssconfluxoentregagarantia_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxocomporgarantia_nefconfirmado.ItemCount > 0 )
         {
            AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxocomporgarantia_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxocomporgarantia_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname, "Values", cmbavAssconfluxocomporgarantia_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxoverexicontabancaria_nefconfirmado.ItemCount > 0 )
         {
            AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoverexicontabancaria_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxoverexicontabancaria_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname, "Values", cmbavAssconfluxoverexicontabancaria_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxocontratarproduto_nefconfirmado.ItemCount > 0 )
         {
            AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxocontratarproduto_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxocontratarproduto_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname, "Values", cmbavAssconfluxocontratarproduto_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxoconfeccontrato_nefconfirmado.ItemCount > 0 )
         {
            AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoconfeccontrato_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxoconfeccontrato_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname, "Values", cmbavAssconfluxoconfeccontrato_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxoregenvcontcliente_nefconfirmado.ItemCount > 0 )
         {
            AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoregenvcontcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxoregenvcontcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname, "Values", cmbavAssconfluxoregenvcontcliente_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxoregrescontcliente_nefconfirmado.ItemCount > 0 )
         {
            AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoregrescontcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxoregrescontcliente_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname, "Values", cmbavAssconfluxoregrescontcliente_nefconfirmado.ToJavascriptSource(), true);
         }
         if ( cmbavAssconfluxorecolherassinatura_nefconfirmado.ItemCount > 0 )
         {
            AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxorecolherassinatura_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado)));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavAssconfluxorecolherassinatura_nefconfirmado.CurrentValue = StringUtil.BoolToStr( AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado);
            AssignProp("", false, cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname, "Values", cmbavAssconfluxorecolherassinatura_nefconfirmado.ToJavascriptSource(), true);
         }
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF5S2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF5S2( )
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
            E135S2 ();
            WB5S0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes5S2( )
      {
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP5S0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E115S2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOENTREGAGARANTIA"), AV8assConFluxoEntregaGarantia);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOCOMPORGARANTIA"), AV5assConFluxoComporGarantia);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOVEREXICONTABANCARIA"), AV12assConFluxoVerExiContaBancaria);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOCONTRATARPRODUTO"), AV7assConFluxoContratarProduto);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOCONFECCONTRATO"), AV6assConFluxoConfecContrato);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOREGENVCONTCLIENTE"), AV10assConFluxoRegEnvContCliente);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXOREGRESCONTCLIENTE"), AV11assConFluxoRegResContCliente);
            ajax_req_read_hidden_sdt(cgiGet( "vASSCONFLUXORECOLHERASSINATURA"), AV9assConFluxoRecolherAssinatura);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxoentregagarantia"), AV8assConFluxoEntregaGarantia);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxocomporgarantia"), AV5assConFluxoComporGarantia);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxoverexicontabancaria"), AV12assConFluxoVerExiContaBancaria);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxocontratarproduto"), AV7assConFluxoContratarProduto);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxoconfeccontrato"), AV6assConFluxoConfecContrato);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxoregenvcontcliente"), AV10assConFluxoRegEnvContCliente);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxoregrescontcliente"), AV11assConFluxoRegResContCliente);
            ajax_req_read_hidden_sdt(cgiGet( "Assconfluxorecolherassinatura"), AV9assConFluxoRecolherAssinatura);
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
            Dvpanel_pnlconfentregagarantia_Width = cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Width");
            Dvpanel_pnlconfentregagarantia_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Autowidth"));
            Dvpanel_pnlconfentregagarantia_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Autoheight"));
            Dvpanel_pnlconfentregagarantia_Cls = cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Cls");
            Dvpanel_pnlconfentregagarantia_Title = cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Title");
            Dvpanel_pnlconfentregagarantia_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Collapsible"));
            Dvpanel_pnlconfentregagarantia_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Collapsed"));
            Dvpanel_pnlconfentregagarantia_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Showcollapseicon"));
            Dvpanel_pnlconfentregagarantia_Iconposition = cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Iconposition");
            Dvpanel_pnlconfentregagarantia_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFENTREGAGARANTIA_Autoscroll"));
            Dvpanel_pnlconfcomporgarantia_Width = cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Width");
            Dvpanel_pnlconfcomporgarantia_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Autowidth"));
            Dvpanel_pnlconfcomporgarantia_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Autoheight"));
            Dvpanel_pnlconfcomporgarantia_Cls = cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Cls");
            Dvpanel_pnlconfcomporgarantia_Title = cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Title");
            Dvpanel_pnlconfcomporgarantia_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Collapsible"));
            Dvpanel_pnlconfcomporgarantia_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Collapsed"));
            Dvpanel_pnlconfcomporgarantia_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Showcollapseicon"));
            Dvpanel_pnlconfcomporgarantia_Iconposition = cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Iconposition");
            Dvpanel_pnlconfcomporgarantia_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFCOMPORGARANTIA_Autoscroll"));
            Dvpanel_pnlverexicontabancaria_Width = cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Width");
            Dvpanel_pnlverexicontabancaria_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Autowidth"));
            Dvpanel_pnlverexicontabancaria_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Autoheight"));
            Dvpanel_pnlverexicontabancaria_Cls = cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Cls");
            Dvpanel_pnlverexicontabancaria_Title = cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Title");
            Dvpanel_pnlverexicontabancaria_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Collapsible"));
            Dvpanel_pnlverexicontabancaria_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Collapsed"));
            Dvpanel_pnlverexicontabancaria_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Showcollapseicon"));
            Dvpanel_pnlverexicontabancaria_Iconposition = cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Iconposition");
            Dvpanel_pnlverexicontabancaria_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLVEREXICONTABANCARIA_Autoscroll"));
            Dvpanel_pnlcontratarproduto_Width = cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Width");
            Dvpanel_pnlcontratarproduto_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Autowidth"));
            Dvpanel_pnlcontratarproduto_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Autoheight"));
            Dvpanel_pnlcontratarproduto_Cls = cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Cls");
            Dvpanel_pnlcontratarproduto_Title = cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Title");
            Dvpanel_pnlcontratarproduto_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Collapsible"));
            Dvpanel_pnlcontratarproduto_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Collapsed"));
            Dvpanel_pnlcontratarproduto_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Showcollapseicon"));
            Dvpanel_pnlcontratarproduto_Iconposition = cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Iconposition");
            Dvpanel_pnlcontratarproduto_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONTRATARPRODUTO_Autoscroll"));
            Dvpanel_pnlconfeccontrato_Width = cgiGet( "DVPANEL_PNLCONFECCONTRATO_Width");
            Dvpanel_pnlconfeccontrato_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Autowidth"));
            Dvpanel_pnlconfeccontrato_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Autoheight"));
            Dvpanel_pnlconfeccontrato_Cls = cgiGet( "DVPANEL_PNLCONFECCONTRATO_Cls");
            Dvpanel_pnlconfeccontrato_Title = cgiGet( "DVPANEL_PNLCONFECCONTRATO_Title");
            Dvpanel_pnlconfeccontrato_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Collapsible"));
            Dvpanel_pnlconfeccontrato_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Collapsed"));
            Dvpanel_pnlconfeccontrato_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Showcollapseicon"));
            Dvpanel_pnlconfeccontrato_Iconposition = cgiGet( "DVPANEL_PNLCONFECCONTRATO_Iconposition");
            Dvpanel_pnlconfeccontrato_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLCONFECCONTRATO_Autoscroll"));
            Dvpanel_pnlregenvcontcliente_Width = cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Width");
            Dvpanel_pnlregenvcontcliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Autowidth"));
            Dvpanel_pnlregenvcontcliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Autoheight"));
            Dvpanel_pnlregenvcontcliente_Cls = cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Cls");
            Dvpanel_pnlregenvcontcliente_Title = cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Title");
            Dvpanel_pnlregenvcontcliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Collapsible"));
            Dvpanel_pnlregenvcontcliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Collapsed"));
            Dvpanel_pnlregenvcontcliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Showcollapseicon"));
            Dvpanel_pnlregenvcontcliente_Iconposition = cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Iconposition");
            Dvpanel_pnlregenvcontcliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGENVCONTCLIENTE_Autoscroll"));
            Dvpanel_pnlregrescontcliente_Width = cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Width");
            Dvpanel_pnlregrescontcliente_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Autowidth"));
            Dvpanel_pnlregrescontcliente_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Autoheight"));
            Dvpanel_pnlregrescontcliente_Cls = cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Cls");
            Dvpanel_pnlregrescontcliente_Title = cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Title");
            Dvpanel_pnlregrescontcliente_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Collapsible"));
            Dvpanel_pnlregrescontcliente_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Collapsed"));
            Dvpanel_pnlregrescontcliente_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Showcollapseicon"));
            Dvpanel_pnlregrescontcliente_Iconposition = cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Iconposition");
            Dvpanel_pnlregrescontcliente_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLREGRESCONTCLIENTE_Autoscroll"));
            Dvpanel_pnlrecolherassinaturas_Width = cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Width");
            Dvpanel_pnlrecolherassinaturas_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Autowidth"));
            Dvpanel_pnlrecolherassinaturas_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Autoheight"));
            Dvpanel_pnlrecolherassinaturas_Cls = cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Cls");
            Dvpanel_pnlrecolherassinaturas_Title = cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Title");
            Dvpanel_pnlrecolherassinaturas_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Collapsible"));
            Dvpanel_pnlrecolherassinaturas_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Collapsed"));
            Dvpanel_pnlrecolherassinaturas_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Showcollapseicon"));
            Dvpanel_pnlrecolherassinaturas_Iconposition = cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Iconposition");
            Dvpanel_pnlrecolherassinaturas_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_PNLRECOLHERASSINATURAS_Autoscroll"));
            /* Read variables values. */
            cmbavAssconfluxoentregagarantia_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname);
            AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname));
            cmbavAssconfluxocomporgarantia_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname);
            AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname));
            cmbavAssconfluxoverexicontabancaria_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname);
            AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname));
            cmbavAssconfluxocontratarproduto_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname);
            AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname));
            cmbavAssconfluxoconfeccontrato_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname);
            AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname));
            cmbavAssconfluxoregenvcontcliente_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname);
            AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname));
            cmbavAssconfluxoregrescontcliente_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname);
            AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname));
            cmbavAssconfluxorecolherassinatura_nefconfirmado.CurrentValue = cgiGet( cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname);
            AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado = StringUtil.StrToBool( cgiGet( cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname));
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
         E115S2 ();
         if (returnInSub) return;
      }

      protected void E115S2( )
      {
         /* Start Routine */
         returnInSub = false;
         AV20NegId = StringUtil.StrToGuid( StringUtil.Trim( AV15DocOrigemID));
         AssignAttri("", false, "AV20NegId", AV20NegId.ToString());
         GXt_SdtSDTNegocioPJFluxo1 = AV8assConFluxoEntregaGarantia;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONENTREGAGARANTIA", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV8assConFluxoEntregaGarantia = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV5assConFluxoComporGarantia;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONCOMPORGARANTIA", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV5assConFluxoComporGarantia = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV12assConFluxoVerExiContaBancaria;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONVERIFICACONTAATIVA", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV12assConFluxoVerExiContaBancaria = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV7assConFluxoContratarProduto;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONCONTRATARPRODUTO", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV7assConFluxoContratarProduto = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV6assConFluxoConfecContrato;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONCONFECCONTRATO", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV6assConFluxoConfecContrato = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV10assConFluxoRegEnvContCliente;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONREGENVCONTCLIENTE", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV10assConFluxoRegEnvContCliente = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV11assConFluxoRegResContCliente;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONREGRESCONTCLIENTE", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV11assConFluxoRegResContCliente = GXt_SdtSDTNegocioPJFluxo1;
         GXt_SdtSDTNegocioPJFluxo1 = AV9assConFluxoRecolherAssinatura;
         new GeneXus.Programs.core.prcnegociopjfluxoobterdadosindividual(context ).execute(  AV20NegId,  "ASSCONRECOLHERASSINATURA", out  GXt_SdtSDTNegocioPJFluxo1) ;
         AV9assConFluxoRecolherAssinatura = GXt_SdtSDTNegocioPJFluxo1;
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
            WebComp_Wcnegociopjgeneral.componentprepare(new Object[] {(string)"W0014",(string)"",StringUtil.StrToGuid( StringUtil.Trim( AV15DocOrigemID))});
            WebComp_Wcnegociopjgeneral.componentbind(new Object[] {(string)""+""+"vDOCORIGEMID"+""+""});
         }
      }

      protected void S112( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( ( StringUtil.StrCmp(AV14DocOrigem, "NEGOCIOPJ") == 0 ) ) )
         {
            divDvpanel_tableoportunidade_cell_Class = "Invisible";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         else
         {
            divDvpanel_tableoportunidade_cell_Class = "col-xs-12 CellMarginBottom20";
            AssignProp("", false, divDvpanel_tableoportunidade_cell_Internalname, "Class", divDvpanel_tableoportunidade_cell_Class, true);
         }
         divTblconfcomporgarantia_Visible = ((AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblconfcomporgarantia_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblconfcomporgarantia_Visible), 5, 0), true);
         divTblverexicontabancaria_Visible = ((AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblverexicontabancaria_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblverexicontabancaria_Visible), 5, 0), true);
         divTblcontratarproduto_Visible = ((AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblcontratarproduto_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblcontratarproduto_Visible), 5, 0), true);
         divTblconfeccontrato_Visible = ((AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblconfeccontrato_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblconfeccontrato_Visible), 5, 0), true);
         divTblregenvcontcliente_Visible = ((AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregenvcontcliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregenvcontcliente_Visible), 5, 0), true);
         divTblregrescontcliente_Visible = ((AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblregrescontcliente_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblregrescontcliente_Visible), 5, 0), true);
         divTblrecolherassinaturas_Visible = ((AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado) ? 1 : 0);
         AssignProp("", false, divTblrecolherassinaturas_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTblrecolherassinaturas_Visible), 5, 0), true);
         if ( StringUtil.StrCmp(AV14DocOrigem, "NEGOCIOPJ") == 0 )
         {
            /* Using cursor H005S2 */
            pr_default.execute(0, new Object[] {AV20NegId});
            while ( (pr_default.getStatus(0) != 101) )
            {
               A345NegID = H005S2_A345NegID[0];
               A362NegAssunto = H005S2_A362NegAssunto[0];
               A356NegCodigo = H005S2_A356NegCodigo[0];
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
         E125S2 ();
         if (returnInSub) return;
      }

      protected void E125S2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV20NegId = StringUtil.StrToGuid( StringUtil.Trim( AV15DocOrigemID));
         AssignAttri("", false, "AV20NegId", AV20NegId.ToString());
         AV8assConFluxoEntregaGarantia.gxTpr_Negid = AV20NegId;
         AV8assConFluxoEntregaGarantia.gxTpr_Nefchave = "ASSCONENTREGAGARANTIA";
         /* Execute user subroutine: 'CHECKREQUIREDFIELDS' */
         S122 ();
         if (returnInSub) return;
         if ( AV13CheckRequiredFieldsResult )
         {
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV8assConFluxoEntregaGarantia,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV5assConFluxoComporGarantia.gxTpr_Negid = AV20NegId;
            AV5assConFluxoComporGarantia.gxTpr_Nefchave = "ASSCONCOMPORGARANTIA";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV5assConFluxoComporGarantia,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV12assConFluxoVerExiContaBancaria.gxTpr_Negid = AV20NegId;
            AV12assConFluxoVerExiContaBancaria.gxTpr_Nefchave = "ASSCONVERIFICACONTAATIVA";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV12assConFluxoVerExiContaBancaria,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV7assConFluxoContratarProduto.gxTpr_Negid = AV20NegId;
            AV7assConFluxoContratarProduto.gxTpr_Nefchave = "ASSCONCONTRATARPRODUTO";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV7assConFluxoContratarProduto,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV6assConFluxoConfecContrato.gxTpr_Negid = AV20NegId;
            AV6assConFluxoConfecContrato.gxTpr_Nefchave = "ASSCONCONFECCONTRATO";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV6assConFluxoConfecContrato,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV10assConFluxoRegEnvContCliente.gxTpr_Negid = AV20NegId;
            AV10assConFluxoRegEnvContCliente.gxTpr_Nefchave = "ASSCONREGENVCONTCLIENTE";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV10assConFluxoRegEnvContCliente,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV11assConFluxoRegResContCliente.gxTpr_Negid = AV20NegId;
            AV11assConFluxoRegResContCliente.gxTpr_Nefchave = "ASSCONREGRESCONTCLIENTE";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV11assConFluxoRegResContCliente,  true, out  AV19Messages) ;
         }
         if ( ( ( AV19Messages.Count == 0 ) || ( ( AV19Messages.Count == 1 ) && ( StringUtil.StrCmp(((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(1)).gxTpr_Id, "OK") == 0 ) ) ) && AV13CheckRequiredFieldsResult )
         {
            AV9assConFluxoRecolherAssinatura.gxTpr_Negid = AV20NegId;
            AV9assConFluxoRecolherAssinatura.gxTpr_Nefchave = "ASSCONRECOLHERASSINATURA";
            new GeneXus.Programs.core.prcnegociopjfluxomanterdados(context ).execute(  AV9assConFluxoRecolherAssinatura,  true, out  AV19Messages) ;
         }
         AV16HasError = false;
         AV31GXV9 = 1;
         while ( AV31GXV9 <= AV19Messages.Count )
         {
            AV18Message = ((GeneXus.Utils.SdtMessages_Message)AV19Messages.Item(AV31GXV9));
            if ( AV18Message.gxTpr_Type == 1 )
            {
               AV16HasError = true;
               GX_msglist.addItem(AV18Message.gxTpr_Description);
               if (true) break;
            }
            AV31GXV9 = (int)(AV31GXV9+1);
         }
         if ( ! AV16HasError && AV13CheckRequiredFieldsResult )
         {
            context.setWebReturnParms(new Object[] {});
            context.setWebReturnParmsMetadata(new Object[] {});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV8assConFluxoEntregaGarantia", AV8assConFluxoEntregaGarantia);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV19Messages", AV19Messages);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV5assConFluxoComporGarantia", AV5assConFluxoComporGarantia);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV12assConFluxoVerExiContaBancaria", AV12assConFluxoVerExiContaBancaria);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV7assConFluxoContratarProduto", AV7assConFluxoContratarProduto);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV6assConFluxoConfecContrato", AV6assConFluxoConfecContrato);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV10assConFluxoRegEnvContCliente", AV10assConFluxoRegEnvContCliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV11assConFluxoRegResContCliente", AV11assConFluxoRegResContCliente);
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV9assConFluxoRecolherAssinatura", AV9assConFluxoRecolherAssinatura);
      }

      protected void S122( )
      {
         /* 'CHECKREQUIREDFIELDS' Routine */
         returnInSub = false;
         AV13CheckRequiredFieldsResult = true;
         AssignAttri("", false, "AV13CheckRequiredFieldsResult", AV13CheckRequiredFieldsResult);
      }

      protected void nextLoad( )
      {
      }

      protected void E135S2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         AV14DocOrigem = (string)getParm(obj,0);
         AssignAttri("", false, "AV14DocOrigem", AV14DocOrigem);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV14DocOrigem, "")), context));
         AV15DocOrigemID = (string)getParm(obj,1);
         AssignAttri("", false, "AV15DocOrigemID", AV15DocOrigemID);
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV15DocOrigemID, "")), context));
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
         PA5S2( ) ;
         WS5S2( ) ;
         WE5S2( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?20238214183937", true, true);
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
         context.AddJavascriptSource("assinaturacontratofluxo.js", "?20238214183937", false, true);
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
         cmbavAssconfluxoentregagarantia_nefconfirmado.Name = "ASSCONFLUXOENTREGAGARANTIA_NEFCONFIRMADO";
         cmbavAssconfluxoentregagarantia_nefconfirmado.WebTags = "";
         cmbavAssconfluxoentregagarantia_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxoentregagarantia_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxoentregagarantia_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxoentregagarantia_nefconfirmado.ItemCount > 0 )
         {
            AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoentregagarantia_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV8assConFluxoEntregaGarantia.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxocomporgarantia_nefconfirmado.Name = "ASSCONFLUXOCOMPORGARANTIA_NEFCONFIRMADO";
         cmbavAssconfluxocomporgarantia_nefconfirmado.WebTags = "";
         cmbavAssconfluxocomporgarantia_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxocomporgarantia_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxocomporgarantia_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxocomporgarantia_nefconfirmado.ItemCount > 0 )
         {
            AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxocomporgarantia_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV5assConFluxoComporGarantia.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.Name = "ASSCONFLUXOVEREXICONTABANCARIA_NEFCONFIRMADO";
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.WebTags = "";
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxoverexicontabancaria_nefconfirmado.ItemCount > 0 )
         {
            AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoverexicontabancaria_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV12assConFluxoVerExiContaBancaria.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxocontratarproduto_nefconfirmado.Name = "ASSCONFLUXOCONTRATARPRODUTO_NEFCONFIRMADO";
         cmbavAssconfluxocontratarproduto_nefconfirmado.WebTags = "";
         cmbavAssconfluxocontratarproduto_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxocontratarproduto_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxocontratarproduto_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxocontratarproduto_nefconfirmado.ItemCount > 0 )
         {
            AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxocontratarproduto_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV7assConFluxoContratarProduto.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxoconfeccontrato_nefconfirmado.Name = "ASSCONFLUXOCONFECCONTRATO_NEFCONFIRMADO";
         cmbavAssconfluxoconfeccontrato_nefconfirmado.WebTags = "";
         cmbavAssconfluxoconfeccontrato_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxoconfeccontrato_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxoconfeccontrato_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxoconfeccontrato_nefconfirmado.ItemCount > 0 )
         {
            AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoconfeccontrato_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV6assConFluxoConfecContrato.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.Name = "ASSCONFLUXOREGENVCONTCLIENTE_NEFCONFIRMADO";
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.WebTags = "";
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxoregenvcontcliente_nefconfirmado.ItemCount > 0 )
         {
            AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoregenvcontcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV10assConFluxoRegEnvContCliente.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxoregrescontcliente_nefconfirmado.Name = "ASSCONFLUXOREGRESCONTCLIENTE_NEFCONFIRMADO";
         cmbavAssconfluxoregrescontcliente_nefconfirmado.WebTags = "";
         cmbavAssconfluxoregrescontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxoregrescontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxoregrescontcliente_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxoregrescontcliente_nefconfirmado.ItemCount > 0 )
         {
            AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxoregrescontcliente_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV11assConFluxoRegResContCliente.gxTpr_Nefconfirmado)));
         }
         cmbavAssconfluxorecolherassinatura_nefconfirmado.Name = "ASSCONFLUXORECOLHERASSINATURA_NEFCONFIRMADO";
         cmbavAssconfluxorecolherassinatura_nefconfirmado.WebTags = "";
         cmbavAssconfluxorecolherassinatura_nefconfirmado.addItem(StringUtil.BoolToStr( false), "(Nenhum)", 0);
         cmbavAssconfluxorecolherassinatura_nefconfirmado.addItem(StringUtil.BoolToStr( true), "Sim", 0);
         cmbavAssconfluxorecolherassinatura_nefconfirmado.addItem(StringUtil.BoolToStr( false), "Não", 0);
         if ( cmbavAssconfluxorecolherassinatura_nefconfirmado.ItemCount > 0 )
         {
            AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado = StringUtil.StrToBool( cmbavAssconfluxorecolherassinatura_nefconfirmado.getValidValue(StringUtil.BoolToStr( AV9assConFluxoRecolherAssinatura.gxTpr_Nefconfirmado)));
         }
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         divTableoportunidade_Internalname = "TABLEOPORTUNIDADE";
         Dvpanel_tableoportunidade_Internalname = "DVPANEL_TABLEOPORTUNIDADE";
         divDvpanel_tableoportunidade_cell_Internalname = "DVPANEL_TABLEOPORTUNIDADE_CELL";
         cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname = "ASSCONFLUXOENTREGAGARANTIA_NEFCONFIRMADO";
         divPnlconfentregagarantia_Internalname = "PNLCONFENTREGAGARANTIA";
         Dvpanel_pnlconfentregagarantia_Internalname = "DVPANEL_PNLCONFENTREGAGARANTIA";
         divTblconfentregagarantia_Internalname = "TBLCONFENTREGAGARANTIA";
         cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname = "ASSCONFLUXOCOMPORGARANTIA_NEFCONFIRMADO";
         divPnlconfcomporgarantia_Internalname = "PNLCONFCOMPORGARANTIA";
         Dvpanel_pnlconfcomporgarantia_Internalname = "DVPANEL_PNLCONFCOMPORGARANTIA";
         divTblconfcomporgarantia_Internalname = "TBLCONFCOMPORGARANTIA";
         cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname = "ASSCONFLUXOVEREXICONTABANCARIA_NEFCONFIRMADO";
         divPnlverexicontabancaria_Internalname = "PNLVEREXICONTABANCARIA";
         Dvpanel_pnlverexicontabancaria_Internalname = "DVPANEL_PNLVEREXICONTABANCARIA";
         divTblverexicontabancaria_Internalname = "TBLVEREXICONTABANCARIA";
         cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname = "ASSCONFLUXOCONTRATARPRODUTO_NEFCONFIRMADO";
         divPnlcontratarproduto_Internalname = "PNLCONTRATARPRODUTO";
         Dvpanel_pnlcontratarproduto_Internalname = "DVPANEL_PNLCONTRATARPRODUTO";
         divTblcontratarproduto_Internalname = "TBLCONTRATARPRODUTO";
         cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname = "ASSCONFLUXOCONFECCONTRATO_NEFCONFIRMADO";
         divPnlconfeccontrato_Internalname = "PNLCONFECCONTRATO";
         Dvpanel_pnlconfeccontrato_Internalname = "DVPANEL_PNLCONFECCONTRATO";
         divTblconfeccontrato_Internalname = "TBLCONFECCONTRATO";
         cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname = "ASSCONFLUXOREGENVCONTCLIENTE_NEFCONFIRMADO";
         divPnlregenvcontcliente_Internalname = "PNLREGENVCONTCLIENTE";
         Dvpanel_pnlregenvcontcliente_Internalname = "DVPANEL_PNLREGENVCONTCLIENTE";
         divTblregenvcontcliente_Internalname = "TBLREGENVCONTCLIENTE";
         cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname = "ASSCONFLUXOREGRESCONTCLIENTE_NEFCONFIRMADO";
         divPnlregrescontcliente_Internalname = "PNLREGRESCONTCLIENTE";
         Dvpanel_pnlregrescontcliente_Internalname = "DVPANEL_PNLREGRESCONTCLIENTE";
         divTblregrescontcliente_Internalname = "TBLREGRESCONTCLIENTE";
         cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname = "ASSCONFLUXORECOLHERASSINATURA_NEFCONFIRMADO";
         divPnlrecolherassinaturas_Internalname = "PNLRECOLHERASSINATURAS";
         Dvpanel_pnlrecolherassinaturas_Internalname = "DVPANEL_PNLRECOLHERASSINATURAS";
         divTblrecolherassinaturas_Internalname = "TBLRECOLHERASSINATURAS";
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
         cmbavAssconfluxorecolherassinatura_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxorecolherassinatura_nefconfirmado.Enabled = 1;
         divTblrecolherassinaturas_Visible = 1;
         cmbavAssconfluxoregrescontcliente_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxoregrescontcliente_nefconfirmado.Enabled = 1;
         divTblregrescontcliente_Visible = 1;
         cmbavAssconfluxoregenvcontcliente_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxoregenvcontcliente_nefconfirmado.Enabled = 1;
         divTblregenvcontcliente_Visible = 1;
         cmbavAssconfluxoconfeccontrato_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxoconfeccontrato_nefconfirmado.Enabled = 1;
         divTblconfeccontrato_Visible = 1;
         cmbavAssconfluxocontratarproduto_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxocontratarproduto_nefconfirmado.Enabled = 1;
         divTblcontratarproduto_Visible = 1;
         cmbavAssconfluxoverexicontabancaria_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxoverexicontabancaria_nefconfirmado.Enabled = 1;
         divTblverexicontabancaria_Visible = 1;
         cmbavAssconfluxocomporgarantia_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxocomporgarantia_nefconfirmado.Enabled = 1;
         divTblconfcomporgarantia_Visible = 1;
         cmbavAssconfluxoentregagarantia_nefconfirmado_Jsonclick = "";
         cmbavAssconfluxoentregagarantia_nefconfirmado.Enabled = 1;
         divDvpanel_tableoportunidade_cell_Class = "col-xs-12";
         Dvpanel_pnlrecolherassinaturas_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlrecolherassinaturas_Iconposition = "Right";
         Dvpanel_pnlrecolherassinaturas_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlrecolherassinaturas_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlrecolherassinaturas_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlrecolherassinaturas_Title = "";
         Dvpanel_pnlrecolherassinaturas_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlrecolherassinaturas_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlrecolherassinaturas_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlrecolherassinaturas_Width = "100%";
         Dvpanel_pnlregrescontcliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlregrescontcliente_Iconposition = "Right";
         Dvpanel_pnlregrescontcliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlregrescontcliente_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlregrescontcliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlregrescontcliente_Title = "";
         Dvpanel_pnlregrescontcliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlregrescontcliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlregrescontcliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlregrescontcliente_Width = "100%";
         Dvpanel_pnlregenvcontcliente_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlregenvcontcliente_Iconposition = "Right";
         Dvpanel_pnlregenvcontcliente_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlregenvcontcliente_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlregenvcontcliente_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlregenvcontcliente_Title = "";
         Dvpanel_pnlregenvcontcliente_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlregenvcontcliente_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlregenvcontcliente_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlregenvcontcliente_Width = "100%";
         Dvpanel_pnlconfeccontrato_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlconfeccontrato_Iconposition = "Right";
         Dvpanel_pnlconfeccontrato_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlconfeccontrato_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlconfeccontrato_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlconfeccontrato_Title = "";
         Dvpanel_pnlconfeccontrato_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlconfeccontrato_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlconfeccontrato_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlconfeccontrato_Width = "100%";
         Dvpanel_pnlcontratarproduto_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlcontratarproduto_Iconposition = "Right";
         Dvpanel_pnlcontratarproduto_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlcontratarproduto_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlcontratarproduto_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlcontratarproduto_Title = "";
         Dvpanel_pnlcontratarproduto_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlcontratarproduto_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlcontratarproduto_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlcontratarproduto_Width = "100%";
         Dvpanel_pnlverexicontabancaria_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlverexicontabancaria_Iconposition = "Right";
         Dvpanel_pnlverexicontabancaria_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlverexicontabancaria_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlverexicontabancaria_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlverexicontabancaria_Title = "";
         Dvpanel_pnlverexicontabancaria_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlverexicontabancaria_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlverexicontabancaria_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlverexicontabancaria_Width = "100%";
         Dvpanel_pnlconfcomporgarantia_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlconfcomporgarantia_Iconposition = "Right";
         Dvpanel_pnlconfcomporgarantia_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlconfcomporgarantia_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlconfcomporgarantia_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlconfcomporgarantia_Title = "";
         Dvpanel_pnlconfcomporgarantia_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlconfcomporgarantia_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlconfcomporgarantia_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlconfcomporgarantia_Width = "100%";
         Dvpanel_pnlconfentregagarantia_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_pnlconfentregagarantia_Iconposition = "Right";
         Dvpanel_pnlconfentregagarantia_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_pnlconfentregagarantia_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_pnlconfentregagarantia_Collapsible = Convert.ToBoolean( -1);
         Dvpanel_pnlconfentregagarantia_Title = "";
         Dvpanel_pnlconfentregagarantia_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_pnlconfentregagarantia_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_pnlconfentregagarantia_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_pnlconfentregagarantia_Width = "100%";
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
         Form.Caption = "Assinatura do Contrato";
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
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV14DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV15DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E125S2',iparms:[{av:'AV15DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV8assConFluxoEntregaGarantia',fld:'vASSCONFLUXOENTREGAGARANTIA',pic:''},{av:'AV13CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''},{av:'AV19Messages',fld:'vMESSAGES',pic:''},{av:'AV5assConFluxoComporGarantia',fld:'vASSCONFLUXOCOMPORGARANTIA',pic:''},{av:'AV12assConFluxoVerExiContaBancaria',fld:'vASSCONFLUXOVEREXICONTABANCARIA',pic:''},{av:'AV7assConFluxoContratarProduto',fld:'vASSCONFLUXOCONTRATARPRODUTO',pic:''},{av:'AV6assConFluxoConfecContrato',fld:'vASSCONFLUXOCONFECCONTRATO',pic:''},{av:'AV10assConFluxoRegEnvContCliente',fld:'vASSCONFLUXOREGENVCONTCLIENTE',pic:''},{av:'AV11assConFluxoRegResContCliente',fld:'vASSCONFLUXOREGRESCONTCLIENTE',pic:''},{av:'AV9assConFluxoRecolherAssinatura',fld:'vASSCONFLUXORECOLHERASSINATURA',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV20NegId',fld:'vNEGID',pic:''},{av:'AV8assConFluxoEntregaGarantia',fld:'vASSCONFLUXOENTREGAGARANTIA',pic:''},{av:'AV19Messages',fld:'vMESSAGES',pic:''},{av:'AV5assConFluxoComporGarantia',fld:'vASSCONFLUXOCOMPORGARANTIA',pic:''},{av:'AV12assConFluxoVerExiContaBancaria',fld:'vASSCONFLUXOVEREXICONTABANCARIA',pic:''},{av:'AV7assConFluxoContratarProduto',fld:'vASSCONFLUXOCONTRATARPRODUTO',pic:''},{av:'AV6assConFluxoConfecContrato',fld:'vASSCONFLUXOCONFECCONTRATO',pic:''},{av:'AV10assConFluxoRegEnvContCliente',fld:'vASSCONFLUXOREGENVCONTCLIENTE',pic:''},{av:'AV11assConFluxoRegResContCliente',fld:'vASSCONFLUXOREGRESCONTCLIENTE',pic:''},{av:'AV9assConFluxoRecolherAssinatura',fld:'vASSCONFLUXORECOLHERASSINATURA',pic:''},{av:'AV13CheckRequiredFieldsResult',fld:'vCHECKREQUIREDFIELDSRESULT',pic:''}]}");
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
         wcpOAV14DocOrigem = "";
         wcpOAV15DocOrigemID = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         AV8assConFluxoEntregaGarantia = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV5assConFluxoComporGarantia = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV12assConFluxoVerExiContaBancaria = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV7assConFluxoContratarProduto = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV6assConFluxoConfecContrato = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV10assConFluxoRegEnvContCliente = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV11assConFluxoRegResContCliente = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV9assConFluxoRecolherAssinatura = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         AV19Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ucDvpanel_tableoportunidade = new GXUserControl();
         WebComp_Wcnegociopjgeneral_Component = "";
         OldWcnegociopjgeneral = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_pnlconfentregagarantia = new GXUserControl();
         TempTags = "";
         ucDvpanel_pnlconfcomporgarantia = new GXUserControl();
         ucDvpanel_pnlverexicontabancaria = new GXUserControl();
         ucDvpanel_pnlcontratarproduto = new GXUserControl();
         ucDvpanel_pnlconfeccontrato = new GXUserControl();
         ucDvpanel_pnlregenvcontcliente = new GXUserControl();
         ucDvpanel_pnlregrescontcliente = new GXUserControl();
         ucDvpanel_pnlrecolherassinaturas = new GXUserControl();
         bttBtncancel_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV20NegId = Guid.Empty;
         GXt_SdtSDTNegocioPJFluxo1 = new GeneXus.Programs.core.SdtSDTNegocioPJFluxo(context);
         scmdbuf = "";
         H005S2_A345NegID = new Guid[] {Guid.Empty} ;
         H005S2_A362NegAssunto = new string[] {""} ;
         H005S2_A356NegCodigo = new long[1] ;
         A345NegID = Guid.Empty;
         A362NegAssunto = "";
         AV18Message = new GeneXus.Utils.SdtMessages_Message(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.assinaturacontratofluxo__default(),
            new Object[][] {
                new Object[] {
               H005S2_A345NegID, H005S2_A362NegAssunto, H005S2_A356NegCodigo
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
      private int divTblconfcomporgarantia_Visible ;
      private int divTblverexicontabancaria_Visible ;
      private int divTblcontratarproduto_Visible ;
      private int divTblconfeccontrato_Visible ;
      private int divTblregenvcontcliente_Visible ;
      private int divTblregrescontcliente_Visible ;
      private int divTblrecolherassinaturas_Visible ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigemid_Visible ;
      private int AV31GXV9 ;
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
      private string Dvpanel_pnlconfentregagarantia_Width ;
      private string Dvpanel_pnlconfentregagarantia_Cls ;
      private string Dvpanel_pnlconfentregagarantia_Title ;
      private string Dvpanel_pnlconfentregagarantia_Iconposition ;
      private string Dvpanel_pnlconfcomporgarantia_Width ;
      private string Dvpanel_pnlconfcomporgarantia_Cls ;
      private string Dvpanel_pnlconfcomporgarantia_Title ;
      private string Dvpanel_pnlconfcomporgarantia_Iconposition ;
      private string Dvpanel_pnlverexicontabancaria_Width ;
      private string Dvpanel_pnlverexicontabancaria_Cls ;
      private string Dvpanel_pnlverexicontabancaria_Title ;
      private string Dvpanel_pnlverexicontabancaria_Iconposition ;
      private string Dvpanel_pnlcontratarproduto_Width ;
      private string Dvpanel_pnlcontratarproduto_Cls ;
      private string Dvpanel_pnlcontratarproduto_Title ;
      private string Dvpanel_pnlcontratarproduto_Iconposition ;
      private string Dvpanel_pnlconfeccontrato_Width ;
      private string Dvpanel_pnlconfeccontrato_Cls ;
      private string Dvpanel_pnlconfeccontrato_Title ;
      private string Dvpanel_pnlconfeccontrato_Iconposition ;
      private string Dvpanel_pnlregenvcontcliente_Width ;
      private string Dvpanel_pnlregenvcontcliente_Cls ;
      private string Dvpanel_pnlregenvcontcliente_Title ;
      private string Dvpanel_pnlregenvcontcliente_Iconposition ;
      private string Dvpanel_pnlregrescontcliente_Width ;
      private string Dvpanel_pnlregrescontcliente_Cls ;
      private string Dvpanel_pnlregrescontcliente_Title ;
      private string Dvpanel_pnlregrescontcliente_Iconposition ;
      private string Dvpanel_pnlrecolherassinaturas_Width ;
      private string Dvpanel_pnlrecolherassinaturas_Cls ;
      private string Dvpanel_pnlrecolherassinaturas_Title ;
      private string Dvpanel_pnlrecolherassinaturas_Iconposition ;
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
      private string divTblconfentregagarantia_Internalname ;
      private string Dvpanel_pnlconfentregagarantia_Internalname ;
      private string divPnlconfentregagarantia_Internalname ;
      private string cmbavAssconfluxoentregagarantia_nefconfirmado_Internalname ;
      private string TempTags ;
      private string cmbavAssconfluxoentregagarantia_nefconfirmado_Jsonclick ;
      private string divTblconfcomporgarantia_Internalname ;
      private string Dvpanel_pnlconfcomporgarantia_Internalname ;
      private string divPnlconfcomporgarantia_Internalname ;
      private string cmbavAssconfluxocomporgarantia_nefconfirmado_Internalname ;
      private string cmbavAssconfluxocomporgarantia_nefconfirmado_Jsonclick ;
      private string divTblverexicontabancaria_Internalname ;
      private string Dvpanel_pnlverexicontabancaria_Internalname ;
      private string divPnlverexicontabancaria_Internalname ;
      private string cmbavAssconfluxoverexicontabancaria_nefconfirmado_Internalname ;
      private string cmbavAssconfluxoverexicontabancaria_nefconfirmado_Jsonclick ;
      private string divTblcontratarproduto_Internalname ;
      private string Dvpanel_pnlcontratarproduto_Internalname ;
      private string divPnlcontratarproduto_Internalname ;
      private string cmbavAssconfluxocontratarproduto_nefconfirmado_Internalname ;
      private string cmbavAssconfluxocontratarproduto_nefconfirmado_Jsonclick ;
      private string divTblconfeccontrato_Internalname ;
      private string Dvpanel_pnlconfeccontrato_Internalname ;
      private string divPnlconfeccontrato_Internalname ;
      private string cmbavAssconfluxoconfeccontrato_nefconfirmado_Internalname ;
      private string cmbavAssconfluxoconfeccontrato_nefconfirmado_Jsonclick ;
      private string divTblregenvcontcliente_Internalname ;
      private string Dvpanel_pnlregenvcontcliente_Internalname ;
      private string divPnlregenvcontcliente_Internalname ;
      private string cmbavAssconfluxoregenvcontcliente_nefconfirmado_Internalname ;
      private string cmbavAssconfluxoregenvcontcliente_nefconfirmado_Jsonclick ;
      private string divTblregrescontcliente_Internalname ;
      private string Dvpanel_pnlregrescontcliente_Internalname ;
      private string divPnlregrescontcliente_Internalname ;
      private string cmbavAssconfluxoregrescontcliente_nefconfirmado_Internalname ;
      private string cmbavAssconfluxoregrescontcliente_nefconfirmado_Jsonclick ;
      private string divTblrecolherassinaturas_Internalname ;
      private string Dvpanel_pnlrecolherassinaturas_Internalname ;
      private string divPnlrecolherassinaturas_Internalname ;
      private string cmbavAssconfluxorecolherassinatura_nefconfirmado_Internalname ;
      private string cmbavAssconfluxorecolherassinatura_nefconfirmado_Jsonclick ;
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
      private bool AV13CheckRequiredFieldsResult ;
      private bool Dvpanel_tableoportunidade_Autowidth ;
      private bool Dvpanel_tableoportunidade_Autoheight ;
      private bool Dvpanel_tableoportunidade_Collapsible ;
      private bool Dvpanel_tableoportunidade_Collapsed ;
      private bool Dvpanel_tableoportunidade_Showcollapseicon ;
      private bool Dvpanel_tableoportunidade_Autoscroll ;
      private bool Dvpanel_pnlconfentregagarantia_Autowidth ;
      private bool Dvpanel_pnlconfentregagarantia_Autoheight ;
      private bool Dvpanel_pnlconfentregagarantia_Collapsible ;
      private bool Dvpanel_pnlconfentregagarantia_Collapsed ;
      private bool Dvpanel_pnlconfentregagarantia_Showcollapseicon ;
      private bool Dvpanel_pnlconfentregagarantia_Autoscroll ;
      private bool Dvpanel_pnlconfcomporgarantia_Autowidth ;
      private bool Dvpanel_pnlconfcomporgarantia_Autoheight ;
      private bool Dvpanel_pnlconfcomporgarantia_Collapsible ;
      private bool Dvpanel_pnlconfcomporgarantia_Collapsed ;
      private bool Dvpanel_pnlconfcomporgarantia_Showcollapseicon ;
      private bool Dvpanel_pnlconfcomporgarantia_Autoscroll ;
      private bool Dvpanel_pnlverexicontabancaria_Autowidth ;
      private bool Dvpanel_pnlverexicontabancaria_Autoheight ;
      private bool Dvpanel_pnlverexicontabancaria_Collapsible ;
      private bool Dvpanel_pnlverexicontabancaria_Collapsed ;
      private bool Dvpanel_pnlverexicontabancaria_Showcollapseicon ;
      private bool Dvpanel_pnlverexicontabancaria_Autoscroll ;
      private bool Dvpanel_pnlcontratarproduto_Autowidth ;
      private bool Dvpanel_pnlcontratarproduto_Autoheight ;
      private bool Dvpanel_pnlcontratarproduto_Collapsible ;
      private bool Dvpanel_pnlcontratarproduto_Collapsed ;
      private bool Dvpanel_pnlcontratarproduto_Showcollapseicon ;
      private bool Dvpanel_pnlcontratarproduto_Autoscroll ;
      private bool Dvpanel_pnlconfeccontrato_Autowidth ;
      private bool Dvpanel_pnlconfeccontrato_Autoheight ;
      private bool Dvpanel_pnlconfeccontrato_Collapsible ;
      private bool Dvpanel_pnlconfeccontrato_Collapsed ;
      private bool Dvpanel_pnlconfeccontrato_Showcollapseicon ;
      private bool Dvpanel_pnlconfeccontrato_Autoscroll ;
      private bool Dvpanel_pnlregenvcontcliente_Autowidth ;
      private bool Dvpanel_pnlregenvcontcliente_Autoheight ;
      private bool Dvpanel_pnlregenvcontcliente_Collapsible ;
      private bool Dvpanel_pnlregenvcontcliente_Collapsed ;
      private bool Dvpanel_pnlregenvcontcliente_Showcollapseicon ;
      private bool Dvpanel_pnlregenvcontcliente_Autoscroll ;
      private bool Dvpanel_pnlregrescontcliente_Autowidth ;
      private bool Dvpanel_pnlregrescontcliente_Autoheight ;
      private bool Dvpanel_pnlregrescontcliente_Collapsible ;
      private bool Dvpanel_pnlregrescontcliente_Collapsed ;
      private bool Dvpanel_pnlregrescontcliente_Showcollapseicon ;
      private bool Dvpanel_pnlregrescontcliente_Autoscroll ;
      private bool Dvpanel_pnlrecolherassinaturas_Autowidth ;
      private bool Dvpanel_pnlrecolherassinaturas_Autoheight ;
      private bool Dvpanel_pnlrecolherassinaturas_Collapsible ;
      private bool Dvpanel_pnlrecolherassinaturas_Collapsed ;
      private bool Dvpanel_pnlrecolherassinaturas_Showcollapseicon ;
      private bool Dvpanel_pnlrecolherassinaturas_Autoscroll ;
      private bool wbLoad ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool bDynCreated_Wcnegociopjgeneral ;
      private bool AV16HasError ;
      private string AV14DocOrigem ;
      private string AV15DocOrigemID ;
      private string wcpOAV14DocOrigem ;
      private string wcpOAV15DocOrigemID ;
      private string A362NegAssunto ;
      private Guid AV20NegId ;
      private Guid A345NegID ;
      private GXWebComponent WebComp_Wcnegociopjgeneral ;
      private GXUserControl ucDvpanel_tableoportunidade ;
      private GXUserControl ucDvpanel_pnlconfentregagarantia ;
      private GXUserControl ucDvpanel_pnlconfcomporgarantia ;
      private GXUserControl ucDvpanel_pnlverexicontabancaria ;
      private GXUserControl ucDvpanel_pnlcontratarproduto ;
      private GXUserControl ucDvpanel_pnlconfeccontrato ;
      private GXUserControl ucDvpanel_pnlregenvcontcliente ;
      private GXUserControl ucDvpanel_pnlregrescontcliente ;
      private GXUserControl ucDvpanel_pnlrecolherassinaturas ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbavAssconfluxoentregagarantia_nefconfirmado ;
      private GXCombobox cmbavAssconfluxocomporgarantia_nefconfirmado ;
      private GXCombobox cmbavAssconfluxoverexicontabancaria_nefconfirmado ;
      private GXCombobox cmbavAssconfluxocontratarproduto_nefconfirmado ;
      private GXCombobox cmbavAssconfluxoconfeccontrato_nefconfirmado ;
      private GXCombobox cmbavAssconfluxoregenvcontcliente_nefconfirmado ;
      private GXCombobox cmbavAssconfluxoregrescontcliente_nefconfirmado ;
      private GXCombobox cmbavAssconfluxorecolherassinatura_nefconfirmado ;
      private IDataStoreProvider pr_default ;
      private Guid[] H005S2_A345NegID ;
      private string[] H005S2_A362NegAssunto ;
      private long[] H005S2_A356NegCodigo ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV19Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV8assConFluxoEntregaGarantia ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV5assConFluxoComporGarantia ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV12assConFluxoVerExiContaBancaria ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV7assConFluxoContratarProduto ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV6assConFluxoConfecContrato ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV10assConFluxoRegEnvContCliente ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV11assConFluxoRegResContCliente ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo AV9assConFluxoRecolherAssinatura ;
      private GeneXus.Programs.core.SdtSDTNegocioPJFluxo GXt_SdtSDTNegocioPJFluxo1 ;
      private GeneXus.Utils.SdtMessages_Message AV18Message ;
   }

   public class assinaturacontratofluxo__default : DataStoreHelperBase, IDataStoreHelper
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
          Object[] prmH005S2;
          prmH005S2 = new Object[] {
          new ParDef("AV20NegId",GXType.UniqueIdentifier,36,0)
          };
          def= new CursorDef[] {
              new CursorDef("H005S2", "SELECT NegID, NegAssunto, NegCodigo FROM tb_negociopj WHERE NegID = :AV20NegId ORDER BY NegID ",false, GxErrorMask.GX_NOMASK | GxErrorMask.GX_MASKLOOPLOCK, false, this,prmH005S2,1, GxCacheFrequency.OFF ,false,true )
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
