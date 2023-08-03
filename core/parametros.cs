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
   public class parametros : GXDataArea
   {
      protected void INITENV( )
      {
         if ( GxWebError != 0 )
         {
            return  ;
         }
      }

      protected void INITTRN( )
      {
         initialize_properties( ) ;
         entryPointCalled = false;
         gxfirstwebparm = GetFirstPar( "Mode");
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
            gxfirstwebparm = GetFirstPar( "Mode");
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetFirstPar( "Mode");
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.parametros.aspx")), "core.parametros.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.parametros.aspx")))) ;
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
            entryPointCalled = false;
            gxfirstwebparm = GetFirstPar( "Mode");
            toggleJsOutput = isJsOutputEnabled( );
            if ( context.isSpaRequest( ) )
            {
               disableJsOutput();
            }
            if ( ! entryPointCalled && ! ( isAjaxCallMode( ) || isFullAjaxMode( ) ) )
            {
               Gx_mode = gxfirstwebparm;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") != 0 )
               {
                  AV7ParametroChave = GetPar( "ParametroChave");
                  AssignAttri("", false, "AV7ParametroChave", AV7ParametroChave);
                  GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROCHAVE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ParametroChave, "")), context));
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
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_4-173650", 0) ;
            }
            Form.Meta.addItem("description", "Parâmetros", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtParametroChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public parametros( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public parametros( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           string aP1_ParametroChave )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7ParametroChave = aP1_ParametroChave;
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
            return "parametros_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITENV( ) ;
         INITTRN( ) ;
         if ( ( GxWebError == 0 ) && ! isAjaxCallMode( ) )
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

      protected void fix_multi_value_controls( )
      {
      }

      protected void Draw( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! GxWebStd.gx_redirect( context) )
         {
            disable_std_buttons( ) ;
            enableDisable( ) ;
            set_caption( ) ;
            /* Form start */
            DrawControls( ) ;
            fix_multi_value_controls( ) ;
         }
         /* Execute Exit event if defined. */
      }

      protected void DrawControls( )
      {
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablemain_Internalname, 1, 0, "px", 0, "px", "TableMainTransaction", "start", "top", "", "", "div");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "CellMarginTop10", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucDvpanel_tableattributes.SetProperty("Width", Dvpanel_tableattributes_Width);
         ucDvpanel_tableattributes.SetProperty("AutoWidth", Dvpanel_tableattributes_Autowidth);
         ucDvpanel_tableattributes.SetProperty("AutoHeight", Dvpanel_tableattributes_Autoheight);
         ucDvpanel_tableattributes.SetProperty("Cls", Dvpanel_tableattributes_Cls);
         ucDvpanel_tableattributes.SetProperty("Title", Dvpanel_tableattributes_Title);
         ucDvpanel_tableattributes.SetProperty("Collapsible", Dvpanel_tableattributes_Collapsible);
         ucDvpanel_tableattributes.SetProperty("Collapsed", Dvpanel_tableattributes_Collapsed);
         ucDvpanel_tableattributes.SetProperty("ShowCollapseIcon", Dvpanel_tableattributes_Showcollapseicon);
         ucDvpanel_tableattributes.SetProperty("IconPosition", Dvpanel_tableattributes_Iconposition);
         ucDvpanel_tableattributes.SetProperty("AutoScroll", Dvpanel_tableattributes_Autoscroll);
         ucDvpanel_tableattributes.Render(context, "dvelop.gxbootstrap.panel_al", Dvpanel_tableattributes_Internalname, "DVPANEL_TABLEATTRIBUTESContainer");
         context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"DVPANEL_TABLEATTRIBUTESContainer"+"TableAttributes"+"\" style=\"display:none;\">") ;
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroChave_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroChave_Internalname, "Chave", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtParametroChave_Internalname, A342ParametroChave, StringUtil.RTrim( context.localUtil.Format( A342ParametroChave, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtParametroChave_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtParametroChave_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroDescricao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroDescricao_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametroDescricao_Internalname, A344ParametroDescricao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,27);\"", 0, 1, edtParametroDescricao_Enabled, 0, 80, "chr", 7, "row", 0, StyleString, ClassString, "", "", "500", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtParametroValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtParametroValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtParametroValor_Internalname, A343ParametroValor, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtParametroValor_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\Parametros.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group CellMarginTop10", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Parametros.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Parametros.htm");
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

      protected void UserMain( )
      {
         standaloneStartup( ) ;
      }

      protected void UserMainFullajax( )
      {
         INITENV( ) ;
         INITTRN( ) ;
         UserMain( ) ;
         Draw( ) ;
         SendCloseFormHiddens( ) ;
      }

      protected void standaloneStartup( )
      {
         standaloneStartupServer( ) ;
         disable_std_buttons( ) ;
         enableDisable( ) ;
         Process( ) ;
      }

      protected void standaloneStartupServer( )
      {
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110X2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z342ParametroChave = cgiGet( "Z342ParametroChave");
               Z519ParametroDelDataHora = context.localUtil.CToT( cgiGet( "Z519ParametroDelDataHora"), 0);
               n519ParametroDelDataHora = ((DateTime.MinValue==A519ParametroDelDataHora) ? true : false);
               Z520ParametroDelData = context.localUtil.CToT( cgiGet( "Z520ParametroDelData"), 0);
               n520ParametroDelData = ((DateTime.MinValue==A520ParametroDelData) ? true : false);
               Z521ParametroDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z521ParametroDelHora"), 0));
               n521ParametroDelHora = ((DateTime.MinValue==A521ParametroDelHora) ? true : false);
               Z522ParametroDelUsuId = cgiGet( "Z522ParametroDelUsuId");
               n522ParametroDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A522ParametroDelUsuId)) ? true : false);
               Z523ParametroDelUsuNome = cgiGet( "Z523ParametroDelUsuNome");
               n523ParametroDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A523ParametroDelUsuNome)) ? true : false);
               Z344ParametroDescricao = cgiGet( "Z344ParametroDescricao");
               n344ParametroDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A344ParametroDescricao)) ? true : false);
               Z343ParametroValor = cgiGet( "Z343ParametroValor");
               n343ParametroValor = (String.IsNullOrEmpty(StringUtil.RTrim( A343ParametroValor)) ? true : false);
               Z518ParametroDel = StringUtil.StrToBool( cgiGet( "Z518ParametroDel"));
               A519ParametroDelDataHora = context.localUtil.CToT( cgiGet( "Z519ParametroDelDataHora"), 0);
               n519ParametroDelDataHora = false;
               n519ParametroDelDataHora = ((DateTime.MinValue==A519ParametroDelDataHora) ? true : false);
               A520ParametroDelData = context.localUtil.CToT( cgiGet( "Z520ParametroDelData"), 0);
               n520ParametroDelData = false;
               n520ParametroDelData = ((DateTime.MinValue==A520ParametroDelData) ? true : false);
               A521ParametroDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z521ParametroDelHora"), 0));
               n521ParametroDelHora = false;
               n521ParametroDelHora = ((DateTime.MinValue==A521ParametroDelHora) ? true : false);
               A522ParametroDelUsuId = cgiGet( "Z522ParametroDelUsuId");
               n522ParametroDelUsuId = false;
               n522ParametroDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A522ParametroDelUsuId)) ? true : false);
               A523ParametroDelUsuNome = cgiGet( "Z523ParametroDelUsuNome");
               n523ParametroDelUsuNome = false;
               n523ParametroDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A523ParametroDelUsuNome)) ? true : false);
               A518ParametroDel = StringUtil.StrToBool( cgiGet( "Z518ParametroDel"));
               O518ParametroDel = StringUtil.StrToBool( cgiGet( "O518ParametroDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7ParametroChave = cgiGet( "vPARAMETROCHAVE");
               A518ParametroDel = StringUtil.StrToBool( cgiGet( "PARAMETRODEL"));
               A519ParametroDelDataHora = context.localUtil.CToT( cgiGet( "PARAMETRODELDATAHORA"), 0);
               n519ParametroDelDataHora = ((DateTime.MinValue==A519ParametroDelDataHora) ? true : false);
               A520ParametroDelData = context.localUtil.CToT( cgiGet( "PARAMETRODELDATA"), 0);
               n520ParametroDelData = ((DateTime.MinValue==A520ParametroDelData) ? true : false);
               A521ParametroDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "PARAMETRODELHORA"), 0));
               n521ParametroDelHora = ((DateTime.MinValue==A521ParametroDelHora) ? true : false);
               A522ParametroDelUsuId = cgiGet( "PARAMETRODELUSUID");
               n522ParametroDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A522ParametroDelUsuId)) ? true : false);
               A523ParametroDelUsuNome = cgiGet( "PARAMETRODELUSUNOME");
               n523ParametroDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A523ParametroDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV13AuditingObject);
               AV14Pgmname = cgiGet( "vPGMNAME");
               Dvpanel_tableattributes_Objectcall = cgiGet( "DVPANEL_TABLEATTRIBUTES_Objectcall");
               Dvpanel_tableattributes_Class = cgiGet( "DVPANEL_TABLEATTRIBUTES_Class");
               Dvpanel_tableattributes_Enabled = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Enabled"));
               Dvpanel_tableattributes_Width = cgiGet( "DVPANEL_TABLEATTRIBUTES_Width");
               Dvpanel_tableattributes_Height = cgiGet( "DVPANEL_TABLEATTRIBUTES_Height");
               Dvpanel_tableattributes_Autowidth = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autowidth"));
               Dvpanel_tableattributes_Autoheight = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoheight"));
               Dvpanel_tableattributes_Cls = cgiGet( "DVPANEL_TABLEATTRIBUTES_Cls");
               Dvpanel_tableattributes_Showheader = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showheader"));
               Dvpanel_tableattributes_Title = cgiGet( "DVPANEL_TABLEATTRIBUTES_Title");
               Dvpanel_tableattributes_Collapsible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsible"));
               Dvpanel_tableattributes_Collapsed = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Collapsed"));
               Dvpanel_tableattributes_Showcollapseicon = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Showcollapseicon"));
               Dvpanel_tableattributes_Iconposition = cgiGet( "DVPANEL_TABLEATTRIBUTES_Iconposition");
               Dvpanel_tableattributes_Autoscroll = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Autoscroll"));
               Dvpanel_tableattributes_Visible = StringUtil.StrToBool( cgiGet( "DVPANEL_TABLEATTRIBUTES_Visible"));
               Dvpanel_tableattributes_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "DVPANEL_TABLEATTRIBUTES_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A342ParametroChave = cgiGet( edtParametroChave_Internalname);
               AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
               A344ParametroDescricao = cgiGet( edtParametroDescricao_Internalname);
               n344ParametroDescricao = false;
               AssignAttri("", false, "A344ParametroDescricao", A344ParametroDescricao);
               n344ParametroDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A344ParametroDescricao)) ? true : false);
               A343ParametroValor = cgiGet( edtParametroValor_Internalname);
               n343ParametroValor = false;
               AssignAttri("", false, "A343ParametroValor", A343ParametroValor);
               n343ParametroValor = (String.IsNullOrEmpty(StringUtil.RTrim( A343ParametroValor)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("ParametroDel", StringUtil.BoolToStr( A518ParametroDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\parametros:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A342ParametroChave = GetPar( "ParametroChave");
                  AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
                  getEqualNoModal( ) ;
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode36 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode36;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound36 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0X0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PARAMETROCHAVE");
                        AnyError = 1;
                        GX_FocusControl = edtParametroChave_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
      }

      protected void Process( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read Transaction buttons. */
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
                        if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120X2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           if ( ! IsDsp( ) )
                           {
                              btn_enter( ) ;
                           }
                           /* No code required for Cancel button. It is implemented as the Reset button. */
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

      protected void AfterTrn( )
      {
         if ( trnEnded == 1 )
         {
            if ( ! String.IsNullOrEmpty(StringUtil.RTrim( endTrnMsgTxt)) )
            {
               GX_msglist.addItem(endTrnMsgTxt, endTrnMsgCod, 0, "", true);
            }
            /* Execute user event: After Trn */
            E120X2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0X36( ) ;
               standaloneNotModal( ) ;
               standaloneModal( ) ;
            }
         }
         endTrnMsgTxt = "";
      }

      public override string ToString( )
      {
         return "" ;
      }

      public GxContentInfo GetContentInfo( )
      {
         return (GxContentInfo)(null) ;
      }

      protected void disable_std_buttons( )
      {
         if ( IsDsp( ) || IsDlt( ) )
         {
            if ( IsDsp( ) )
            {
               bttBtntrn_enter_Visible = 0;
               AssignProp("", false, bttBtntrn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Visible), 5, 0), true);
            }
            DisableAttributes0X36( ) ;
         }
      }

      protected void set_caption( )
      {
         if ( ( IsConfirmed == 1 ) && ( AnyError == 0 ) )
         {
            if ( IsDlt( ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_confdelete", ""), 0, "", true);
            }
            else
            {
               GX_msglist.addItem(context.GetMessage( "GXM_mustconfirm", ""), 0, "", true);
            }
         }
      }

      protected void CONFIRM_0X0( )
      {
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0X36( ) ;
            }
            else
            {
               CheckExtendedTable0X36( ) ;
               CloseExtendedTableCursors0X36( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0X0( )
      {
      }

      protected void E110X2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E120X2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.parametrosww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0X36( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z519ParametroDelDataHora = T000X3_A519ParametroDelDataHora[0];
               Z520ParametroDelData = T000X3_A520ParametroDelData[0];
               Z521ParametroDelHora = T000X3_A521ParametroDelHora[0];
               Z522ParametroDelUsuId = T000X3_A522ParametroDelUsuId[0];
               Z523ParametroDelUsuNome = T000X3_A523ParametroDelUsuNome[0];
               Z344ParametroDescricao = T000X3_A344ParametroDescricao[0];
               Z343ParametroValor = T000X3_A343ParametroValor[0];
               Z518ParametroDel = T000X3_A518ParametroDel[0];
            }
            else
            {
               Z519ParametroDelDataHora = A519ParametroDelDataHora;
               Z520ParametroDelData = A520ParametroDelData;
               Z521ParametroDelHora = A521ParametroDelHora;
               Z522ParametroDelUsuId = A522ParametroDelUsuId;
               Z523ParametroDelUsuNome = A523ParametroDelUsuNome;
               Z344ParametroDescricao = A344ParametroDescricao;
               Z343ParametroValor = A343ParametroValor;
               Z518ParametroDel = A518ParametroDel;
            }
         }
         if ( GX_JID == -13 )
         {
            Z342ParametroChave = A342ParametroChave;
            Z519ParametroDelDataHora = A519ParametroDelDataHora;
            Z520ParametroDelData = A520ParametroDelData;
            Z521ParametroDelHora = A521ParametroDelHora;
            Z522ParametroDelUsuId = A522ParametroDelUsuId;
            Z523ParametroDelUsuNome = A523ParametroDelUsuNome;
            Z344ParametroDescricao = A344ParametroDescricao;
            Z343ParametroValor = A343ParametroValor;
            Z518ParametroDel = A518ParametroDel;
         }
      }

      protected void standaloneNotModal( )
      {
         AV14Pgmname = "core.Parametros";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroChave)) )
         {
            A342ParametroChave = AV7ParametroChave;
            AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroChave)) )
         {
            edtParametroChave_Enabled = 0;
            AssignProp("", false, edtParametroChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroChave_Enabled), 5, 0), true);
         }
         else
         {
            edtParametroChave_Enabled = 1;
            AssignProp("", false, edtParametroChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroChave_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV7ParametroChave)) )
         {
            edtParametroChave_Enabled = 0;
            AssignProp("", false, edtParametroChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroChave_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtntrn_enter_Enabled = 0;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtntrn_enter_Enabled = 1;
            AssignProp("", false, bttBtntrn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtntrn_enter_Enabled), 5, 0), true);
         }
      }

      protected void Load0X36( )
      {
         /* Using cursor T000X4 */
         pr_default.execute(2, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound36 = 1;
            A519ParametroDelDataHora = T000X4_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = T000X4_n519ParametroDelDataHora[0];
            A520ParametroDelData = T000X4_A520ParametroDelData[0];
            n520ParametroDelData = T000X4_n520ParametroDelData[0];
            A521ParametroDelHora = T000X4_A521ParametroDelHora[0];
            n521ParametroDelHora = T000X4_n521ParametroDelHora[0];
            A522ParametroDelUsuId = T000X4_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = T000X4_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = T000X4_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = T000X4_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = T000X4_A344ParametroDescricao[0];
            n344ParametroDescricao = T000X4_n344ParametroDescricao[0];
            AssignAttri("", false, "A344ParametroDescricao", A344ParametroDescricao);
            A343ParametroValor = T000X4_A343ParametroValor[0];
            n343ParametroValor = T000X4_n343ParametroValor[0];
            AssignAttri("", false, "A343ParametroValor", A343ParametroValor);
            A518ParametroDel = T000X4_A518ParametroDel[0];
            ZM0X36( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0X36( ) ;
      }

      protected void OnLoadActions0X36( )
      {
      }

      protected void CheckExtendedTable0X36( )
      {
         nIsDirty_36 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0X36( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0X36( )
      {
         /* Using cursor T000X5 */
         pr_default.execute(3, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound36 = 1;
         }
         else
         {
            RcdFound36 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000X3 */
         pr_default.execute(1, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0X36( 13) ;
            RcdFound36 = 1;
            A342ParametroChave = T000X3_A342ParametroChave[0];
            AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
            A519ParametroDelDataHora = T000X3_A519ParametroDelDataHora[0];
            n519ParametroDelDataHora = T000X3_n519ParametroDelDataHora[0];
            A520ParametroDelData = T000X3_A520ParametroDelData[0];
            n520ParametroDelData = T000X3_n520ParametroDelData[0];
            A521ParametroDelHora = T000X3_A521ParametroDelHora[0];
            n521ParametroDelHora = T000X3_n521ParametroDelHora[0];
            A522ParametroDelUsuId = T000X3_A522ParametroDelUsuId[0];
            n522ParametroDelUsuId = T000X3_n522ParametroDelUsuId[0];
            A523ParametroDelUsuNome = T000X3_A523ParametroDelUsuNome[0];
            n523ParametroDelUsuNome = T000X3_n523ParametroDelUsuNome[0];
            A344ParametroDescricao = T000X3_A344ParametroDescricao[0];
            n344ParametroDescricao = T000X3_n344ParametroDescricao[0];
            AssignAttri("", false, "A344ParametroDescricao", A344ParametroDescricao);
            A343ParametroValor = T000X3_A343ParametroValor[0];
            n343ParametroValor = T000X3_n343ParametroValor[0];
            AssignAttri("", false, "A343ParametroValor", A343ParametroValor);
            A518ParametroDel = T000X3_A518ParametroDel[0];
            O518ParametroDel = A518ParametroDel;
            AssignAttri("", false, "A518ParametroDel", A518ParametroDel);
            Z342ParametroChave = A342ParametroChave;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0X36( ) ;
            if ( AnyError == 1 )
            {
               RcdFound36 = 0;
               InitializeNonKey0X36( ) ;
            }
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound36 = 0;
            InitializeNonKey0X36( ) ;
            sMode36 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode36;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0X36( ) ;
         if ( RcdFound36 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound36 = 0;
         /* Using cursor T000X6 */
         pr_default.execute(4, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000X6_A342ParametroChave[0], A342ParametroChave) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000X6_A342ParametroChave[0], A342ParametroChave) > 0 ) ) )
            {
               A342ParametroChave = T000X6_A342ParametroChave[0];
               AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
               RcdFound36 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound36 = 0;
         /* Using cursor T000X7 */
         pr_default.execute(5, new Object[] {A342ParametroChave});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000X7_A342ParametroChave[0], A342ParametroChave) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000X7_A342ParametroChave[0], A342ParametroChave) < 0 ) ) )
            {
               A342ParametroChave = T000X7_A342ParametroChave[0];
               AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
               RcdFound36 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0X36( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtParametroChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0X36( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound36 == 1 )
            {
               if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
               {
                  A342ParametroChave = Z342ParametroChave;
                  AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PARAMETROCHAVE");
                  AnyError = 1;
                  GX_FocusControl = edtParametroChave_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtParametroChave_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0X36( ) ;
                  GX_FocusControl = edtParametroChave_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
               {
                  /* Insert record */
                  GX_FocusControl = edtParametroChave_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0X36( ) ;
                  if ( AnyError == 1 )
                  {
                     GX_FocusControl = "";
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PARAMETROCHAVE");
                     AnyError = 1;
                     GX_FocusControl = edtParametroChave_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtParametroChave_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0X36( ) ;
                     if ( AnyError == 1 )
                     {
                        GX_FocusControl = "";
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
         }
         AfterTrn( ) ;
         if ( IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( StringUtil.StrCmp(A342ParametroChave, Z342ParametroChave) != 0 )
         {
            A342ParametroChave = Z342ParametroChave;
            AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PARAMETROCHAVE");
            AnyError = 1;
            GX_FocusControl = edtParametroChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtParametroChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0X36( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000X2 */
            pr_default.execute(0, new Object[] {A342ParametroChave});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_parametro"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z519ParametroDelDataHora != T000X2_A519ParametroDelDataHora[0] ) || ( Z520ParametroDelData != T000X2_A520ParametroDelData[0] ) || ( Z521ParametroDelHora != T000X2_A521ParametroDelHora[0] ) || ( StringUtil.StrCmp(Z522ParametroDelUsuId, T000X2_A522ParametroDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z523ParametroDelUsuNome, T000X2_A523ParametroDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z344ParametroDescricao, T000X2_A344ParametroDescricao[0]) != 0 ) || ( StringUtil.StrCmp(Z343ParametroValor, T000X2_A343ParametroValor[0]) != 0 ) || ( Z518ParametroDel != T000X2_A518ParametroDel[0] ) )
            {
               if ( Z519ParametroDelDataHora != T000X2_A519ParametroDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z519ParametroDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A519ParametroDelDataHora[0]);
               }
               if ( Z520ParametroDelData != T000X2_A520ParametroDelData[0] )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDelData");
                  GXUtil.WriteLogRaw("Old: ",Z520ParametroDelData);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A520ParametroDelData[0]);
               }
               if ( Z521ParametroDelHora != T000X2_A521ParametroDelHora[0] )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z521ParametroDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A521ParametroDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z522ParametroDelUsuId, T000X2_A522ParametroDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z522ParametroDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A522ParametroDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z523ParametroDelUsuNome, T000X2_A523ParametroDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z523ParametroDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A523ParametroDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z344ParametroDescricao, T000X2_A344ParametroDescricao[0]) != 0 )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDescricao");
                  GXUtil.WriteLogRaw("Old: ",Z344ParametroDescricao);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A344ParametroDescricao[0]);
               }
               if ( StringUtil.StrCmp(Z343ParametroValor, T000X2_A343ParametroValor[0]) != 0 )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroValor");
                  GXUtil.WriteLogRaw("Old: ",Z343ParametroValor);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A343ParametroValor[0]);
               }
               if ( Z518ParametroDel != T000X2_A518ParametroDel[0] )
               {
                  GXUtil.WriteLog("core.parametros:[seudo value changed for attri]"+"ParametroDel");
                  GXUtil.WriteLogRaw("Old: ",Z518ParametroDel);
                  GXUtil.WriteLogRaw("Current: ",T000X2_A518ParametroDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_parametro"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0X36( )
      {
         if ( ! IsAuthorized("parametros_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0X36( 0) ;
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X8 */
                     pr_default.execute(6, new Object[] {A342ParametroChave, n519ParametroDelDataHora, A519ParametroDelDataHora, n520ParametroDelData, A520ParametroDelData, n521ParametroDelHora, A521ParametroDelHora, n522ParametroDelUsuId, A522ParametroDelUsuId, n523ParametroDelUsuNome, A523ParametroDelUsuNome, n344ParametroDescricao, A344ParametroDescricao, n343ParametroValor, A343ParametroValor, A518ParametroDel});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
                     if ( (pr_default.getStatus(6) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0X0( ) ;
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
            else
            {
               Load0X36( ) ;
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void Update0X36( )
      {
         if ( ! IsAuthorized("parametros_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0X36( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0X36( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000X9 */
                     pr_default.execute(7, new Object[] {n519ParametroDelDataHora, A519ParametroDelDataHora, n520ParametroDelData, A520ParametroDelData, n521ParametroDelHora, A521ParametroDelHora, n522ParametroDelUsuId, A522ParametroDelUsuId, n523ParametroDelUsuNome, A523ParametroDelUsuNome, n344ParametroDescricao, A344ParametroDescricao, n343ParametroValor, A343ParametroValor, A518ParametroDel, A342ParametroChave});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_parametro"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0X36( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsUpd( ) || IsDlt( ) )
                           {
                              if ( AnyError == 0 )
                              {
                                 context.nUserReturn = 1;
                              }
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                        AnyError = 1;
                     }
                  }
               }
            }
            EndLevel0X36( ) ;
         }
         CloseExtendedTableCursors0X36( ) ;
      }

      protected void DeferredUpdate0X36( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("parametros_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0X36( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0X36( ) ;
            AfterConfirm0X36( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0X36( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000X10 */
                  pr_default.execute(8, new Object[] {A342ParametroChave});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("tb_parametro");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        if ( IsUpd( ) || IsDlt( ) )
                        {
                           if ( AnyError == 0 )
                           {
                              context.nUserReturn = 1;
                           }
                        }
                     }
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode36 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0X36( ) ;
         Gx_mode = sMode36;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0X36( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0X36( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0X36( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.parametros",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0X0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.parametros",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0X36( )
      {
         /* Scan By routine */
         /* Using cursor T000X11 */
         pr_default.execute(9);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound36 = 1;
            A342ParametroChave = T000X11_A342ParametroChave[0];
            AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0X36( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound36 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound36 = 1;
            A342ParametroChave = T000X11_A342ParametroChave[0];
            AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
         }
      }

      protected void ScanEnd0X36( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0X36( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0X36( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0X36( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A519ParametroDelDataHora = DateTimeUtil.NowMS( context);
            n519ParametroDelDataHora = false;
            AssignAttri("", false, "A519ParametroDelDataHora", context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A522ParametroDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n522ParametroDelUsuId = false;
            AssignAttri("", false, "A522ParametroDelUsuId", A522ParametroDelUsuId);
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A523ParametroDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n523ParametroDelUsuNome = false;
            AssignAttri("", false, "A523ParametroDelUsuNome", A523ParametroDelUsuNome);
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A520ParametroDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A519ParametroDelDataHora) ) ;
            n520ParametroDelData = false;
            AssignAttri("", false, "A520ParametroDelData", context.localUtil.TToC( A520ParametroDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A518ParametroDel && ( O518ParametroDel != A518ParametroDel ) )
         {
            A521ParametroDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A519ParametroDelDataHora));
            n521ParametroDelHora = false;
            AssignAttri("", false, "A521ParametroDelHora", context.localUtil.TToC( A521ParametroDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0X36( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
      }

      protected void BeforeComplete0X36( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0X36( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0X36( )
      {
         edtParametroChave_Enabled = 0;
         AssignProp("", false, edtParametroChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroChave_Enabled), 5, 0), true);
         edtParametroDescricao_Enabled = 0;
         AssignProp("", false, edtParametroDescricao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroDescricao_Enabled), 5, 0), true);
         edtParametroValor_Enabled = 0;
         AssignProp("", false, edtParametroValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtParametroValor_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0X36( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0X0( )
      {
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
         MasterPageObj.master_styles();
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
         FormProcess = " data-HasEnter=\"true\" data-Skiponenter=\"false\"";
         context.WriteHtmlText( "<body ") ;
         if ( StringUtil.StrCmp(context.GetLanguageProperty( "rtl"), "true") == 0 )
         {
            context.WriteHtmlText( " dir=\"rtl\" ") ;
         }
         bodyStyle = "" + "background-color:" + context.BuildHTMLColor( Form.Backcolor) + ";color:" + context.BuildHTMLColor( Form.Textcolor) + ";";
         bodyStyle += "-moz-opacity:0;opacity:0;";
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "core.parametros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ParametroChave));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Parametros");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("ParametroDel", StringUtil.BoolToStr( A518ParametroDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\parametros:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z342ParametroChave", Z342ParametroChave);
         GxWebStd.gx_hidden_field( context, "Z519ParametroDelDataHora", context.localUtil.TToC( Z519ParametroDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z520ParametroDelData", context.localUtil.TToC( Z520ParametroDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z521ParametroDelHora", context.localUtil.TToC( Z521ParametroDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z522ParametroDelUsuId", StringUtil.RTrim( Z522ParametroDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z523ParametroDelUsuNome", Z523ParametroDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z344ParametroDescricao", Z344ParametroDescricao);
         GxWebStd.gx_hidden_field( context, "Z343ParametroValor", Z343ParametroValor);
         GxWebStd.gx_boolean_hidden_field( context, "Z518ParametroDel", Z518ParametroDel);
         GxWebStd.gx_boolean_hidden_field( context, "O518ParametroDel", O518ParametroDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vTRNCONTEXT", AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vTRNCONTEXT", AV11TrnContext);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vTRNCONTEXT", GetSecureSignedToken( "", AV11TrnContext, context));
         GxWebStd.gx_hidden_field( context, "vPARAMETROCHAVE", AV7ParametroChave);
         GxWebStd.gx_hidden_field( context, "gxhash_vPARAMETROCHAVE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV7ParametroChave, "")), context));
         GxWebStd.gx_boolean_hidden_field( context, "PARAMETRODEL", A518ParametroDel);
         GxWebStd.gx_hidden_field( context, "PARAMETRODELDATAHORA", context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PARAMETRODELDATA", context.localUtil.TToC( A520ParametroDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PARAMETRODELHORA", context.localUtil.TToC( A521ParametroDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PARAMETRODELUSUID", StringUtil.RTrim( A522ParametroDelUsuId));
         GxWebStd.gx_hidden_field( context, "PARAMETRODELUSUNOME", A523ParametroDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV13AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV13AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV14Pgmname));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Objectcall", StringUtil.RTrim( Dvpanel_tableattributes_Objectcall));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Enabled", StringUtil.BoolToStr( Dvpanel_tableattributes_Enabled));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Width", StringUtil.RTrim( Dvpanel_tableattributes_Width));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autowidth", StringUtil.BoolToStr( Dvpanel_tableattributes_Autowidth));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoheight", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoheight));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Cls", StringUtil.RTrim( Dvpanel_tableattributes_Cls));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Title", StringUtil.RTrim( Dvpanel_tableattributes_Title));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsible", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsible));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Collapsed", StringUtil.BoolToStr( Dvpanel_tableattributes_Collapsed));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Showcollapseicon", StringUtil.BoolToStr( Dvpanel_tableattributes_Showcollapseicon));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Iconposition", StringUtil.RTrim( Dvpanel_tableattributes_Iconposition));
         GxWebStd.gx_hidden_field( context, "DVPANEL_TABLEATTRIBUTES_Autoscroll", StringUtil.BoolToStr( Dvpanel_tableattributes_Autoscroll));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken(sPrefix);
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

      public override short ExecuteStartEvent( )
      {
         standaloneStartup( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         return gxajaxcallmode ;
      }

      public override void RenderHtmlContent( )
      {
         context.WriteHtmlText( "<div") ;
         GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
         context.WriteHtmlText( ">") ;
         Draw( ) ;
         context.WriteHtmlText( "</div>") ;
      }

      public override void DispatchEvents( )
      {
         Process( ) ;
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
         GXEncryptionTmp = "core.parametros.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.RTrim(AV7ParametroChave));
         return formatLink("core.parametros.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Parametros" ;
      }

      public override string GetPgmdesc( )
      {
         return "Parâmetros" ;
      }

      protected void InitializeNonKey0X36( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         n519ParametroDelDataHora = false;
         AssignAttri("", false, "A519ParametroDelDataHora", context.localUtil.TToC( A519ParametroDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         n520ParametroDelData = false;
         AssignAttri("", false, "A520ParametroDelData", context.localUtil.TToC( A520ParametroDelData, 10, 5, 0, 3, "/", ":", " "));
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         n521ParametroDelHora = false;
         AssignAttri("", false, "A521ParametroDelHora", context.localUtil.TToC( A521ParametroDelHora, 0, 5, 0, 3, "/", ":", " "));
         A522ParametroDelUsuId = "";
         n522ParametroDelUsuId = false;
         AssignAttri("", false, "A522ParametroDelUsuId", A522ParametroDelUsuId);
         A523ParametroDelUsuNome = "";
         n523ParametroDelUsuNome = false;
         AssignAttri("", false, "A523ParametroDelUsuNome", A523ParametroDelUsuNome);
         A344ParametroDescricao = "";
         n344ParametroDescricao = false;
         AssignAttri("", false, "A344ParametroDescricao", A344ParametroDescricao);
         n344ParametroDescricao = (String.IsNullOrEmpty(StringUtil.RTrim( A344ParametroDescricao)) ? true : false);
         A343ParametroValor = "";
         n343ParametroValor = false;
         AssignAttri("", false, "A343ParametroValor", A343ParametroValor);
         n343ParametroValor = (String.IsNullOrEmpty(StringUtil.RTrim( A343ParametroValor)) ? true : false);
         A518ParametroDel = false;
         AssignAttri("", false, "A518ParametroDel", A518ParametroDel);
         O518ParametroDel = A518ParametroDel;
         AssignAttri("", false, "A518ParametroDel", A518ParametroDel);
         Z519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         Z520ParametroDelData = (DateTime)(DateTime.MinValue);
         Z521ParametroDelHora = (DateTime)(DateTime.MinValue);
         Z522ParametroDelUsuId = "";
         Z523ParametroDelUsuNome = "";
         Z344ParametroDescricao = "";
         Z343ParametroValor = "";
         Z518ParametroDel = false;
      }

      protected void InitAll0X36( )
      {
         A342ParametroChave = "";
         AssignAttri("", false, "A342ParametroChave", A342ParametroChave);
         InitializeNonKey0X36( ) ;
      }

      protected void StandaloneModalInsert( )
      {
      }

      protected void define_styles( )
      {
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828135288", true, true);
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
         context.AddJavascriptSource("core/parametros.js", "?2023828135290", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtParametroChave_Internalname = "PARAMETROCHAVE";
         edtParametroDescricao_Internalname = "PARAMETRODESCRICAO";
         edtParametroValor_Internalname = "PARAMETROVALOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Parâmetros";
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtParametroValor_Enabled = 1;
         edtParametroDescricao_Enabled = 1;
         edtParametroChave_Jsonclick = "";
         edtParametroChave_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Informações Gerais";
         Dvpanel_tableattributes_Cls = "PanelCard_IconAndTitle Panel_BaseColor";
         Dvpanel_tableattributes_Autoheight = Convert.ToBoolean( -1);
         Dvpanel_tableattributes_Autowidth = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Width = "100%";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void XC_9_0X36( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                string A342ParametroChave ,
                                string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV13AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_10_0X36( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 string A342ParametroChave ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditparametros(context ).execute(  "Y", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV13AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_11_0X36( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 string A342ParametroChave )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV13AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_12_0X36( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 string A342ParametroChave )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditparametros(context ).execute(  "N", ref  AV13AuditingObject,  A342ParametroChave,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV13AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void init_web_controls( )
      {
         /* End function init_web_controls */
      }

      protected bool IsIns( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "INS")==0) ? true : false) ;
      }

      protected bool IsDlt( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DLT")==0) ? true : false) ;
      }

      protected bool IsUpd( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "UPD")==0) ? true : false) ;
      }

      protected bool IsDsp( )
      {
         return ((StringUtil.StrCmp(Gx_mode, "DSP")==0) ? true : false) ;
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7ParametroChave',fld:'vPARAMETROCHAVE',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7ParametroChave',fld:'vPARAMETROCHAVE',pic:'',hsh:true},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A518ParametroDel',fld:'PARAMETRODEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120X2',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PARAMETROCHAVE","{handler:'Valid_Parametrochave',iparms:[]");
         setEventMetadata("VALID_PARAMETROCHAVE",",oparms:[]}");
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
         pr_default.close(1);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7ParametroChave = "";
         Z342ParametroChave = "";
         Z519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         Z520ParametroDelData = (DateTime)(DateTime.MinValue);
         Z521ParametroDelHora = (DateTime)(DateTime.MinValue);
         Z522ParametroDelUsuId = "";
         Z523ParametroDelUsuNome = "";
         Z344ParametroDescricao = "";
         Z343ParametroValor = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         TempTags = "";
         A342ParametroChave = "";
         A344ParametroDescricao = "";
         A343ParametroValor = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A519ParametroDelDataHora = (DateTime)(DateTime.MinValue);
         A520ParametroDelData = (DateTime)(DateTime.MinValue);
         A521ParametroDelHora = (DateTime)(DateTime.MinValue);
         A522ParametroDelUsuId = "";
         A523ParametroDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode36 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000X4_A342ParametroChave = new string[] {""} ;
         T000X4_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000X4_n519ParametroDelDataHora = new bool[] {false} ;
         T000X4_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         T000X4_n520ParametroDelData = new bool[] {false} ;
         T000X4_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         T000X4_n521ParametroDelHora = new bool[] {false} ;
         T000X4_A522ParametroDelUsuId = new string[] {""} ;
         T000X4_n522ParametroDelUsuId = new bool[] {false} ;
         T000X4_A523ParametroDelUsuNome = new string[] {""} ;
         T000X4_n523ParametroDelUsuNome = new bool[] {false} ;
         T000X4_A344ParametroDescricao = new string[] {""} ;
         T000X4_n344ParametroDescricao = new bool[] {false} ;
         T000X4_A343ParametroValor = new string[] {""} ;
         T000X4_n343ParametroValor = new bool[] {false} ;
         T000X4_A518ParametroDel = new bool[] {false} ;
         T000X5_A342ParametroChave = new string[] {""} ;
         T000X3_A342ParametroChave = new string[] {""} ;
         T000X3_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000X3_n519ParametroDelDataHora = new bool[] {false} ;
         T000X3_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         T000X3_n520ParametroDelData = new bool[] {false} ;
         T000X3_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         T000X3_n521ParametroDelHora = new bool[] {false} ;
         T000X3_A522ParametroDelUsuId = new string[] {""} ;
         T000X3_n522ParametroDelUsuId = new bool[] {false} ;
         T000X3_A523ParametroDelUsuNome = new string[] {""} ;
         T000X3_n523ParametroDelUsuNome = new bool[] {false} ;
         T000X3_A344ParametroDescricao = new string[] {""} ;
         T000X3_n344ParametroDescricao = new bool[] {false} ;
         T000X3_A343ParametroValor = new string[] {""} ;
         T000X3_n343ParametroValor = new bool[] {false} ;
         T000X3_A518ParametroDel = new bool[] {false} ;
         T000X6_A342ParametroChave = new string[] {""} ;
         T000X7_A342ParametroChave = new string[] {""} ;
         T000X2_A342ParametroChave = new string[] {""} ;
         T000X2_A519ParametroDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000X2_n519ParametroDelDataHora = new bool[] {false} ;
         T000X2_A520ParametroDelData = new DateTime[] {DateTime.MinValue} ;
         T000X2_n520ParametroDelData = new bool[] {false} ;
         T000X2_A521ParametroDelHora = new DateTime[] {DateTime.MinValue} ;
         T000X2_n521ParametroDelHora = new bool[] {false} ;
         T000X2_A522ParametroDelUsuId = new string[] {""} ;
         T000X2_n522ParametroDelUsuId = new bool[] {false} ;
         T000X2_A523ParametroDelUsuNome = new string[] {""} ;
         T000X2_n523ParametroDelUsuNome = new bool[] {false} ;
         T000X2_A344ParametroDescricao = new string[] {""} ;
         T000X2_n344ParametroDescricao = new bool[] {false} ;
         T000X2_A343ParametroValor = new string[] {""} ;
         T000X2_n343ParametroValor = new bool[] {false} ;
         T000X2_A518ParametroDel = new bool[] {false} ;
         T000X11_A342ParametroChave = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.parametros__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.parametros__default(),
            new Object[][] {
                new Object[] {
               T000X2_A342ParametroChave, T000X2_A519ParametroDelDataHora, T000X2_n519ParametroDelDataHora, T000X2_A520ParametroDelData, T000X2_n520ParametroDelData, T000X2_A521ParametroDelHora, T000X2_n521ParametroDelHora, T000X2_A522ParametroDelUsuId, T000X2_n522ParametroDelUsuId, T000X2_A523ParametroDelUsuNome,
               T000X2_n523ParametroDelUsuNome, T000X2_A344ParametroDescricao, T000X2_n344ParametroDescricao, T000X2_A343ParametroValor, T000X2_n343ParametroValor, T000X2_A518ParametroDel
               }
               , new Object[] {
               T000X3_A342ParametroChave, T000X3_A519ParametroDelDataHora, T000X3_n519ParametroDelDataHora, T000X3_A520ParametroDelData, T000X3_n520ParametroDelData, T000X3_A521ParametroDelHora, T000X3_n521ParametroDelHora, T000X3_A522ParametroDelUsuId, T000X3_n522ParametroDelUsuId, T000X3_A523ParametroDelUsuNome,
               T000X3_n523ParametroDelUsuNome, T000X3_A344ParametroDescricao, T000X3_n344ParametroDescricao, T000X3_A343ParametroValor, T000X3_n343ParametroValor, T000X3_A518ParametroDel
               }
               , new Object[] {
               T000X4_A342ParametroChave, T000X4_A519ParametroDelDataHora, T000X4_n519ParametroDelDataHora, T000X4_A520ParametroDelData, T000X4_n520ParametroDelData, T000X4_A521ParametroDelHora, T000X4_n521ParametroDelHora, T000X4_A522ParametroDelUsuId, T000X4_n522ParametroDelUsuId, T000X4_A523ParametroDelUsuNome,
               T000X4_n523ParametroDelUsuNome, T000X4_A344ParametroDescricao, T000X4_n344ParametroDescricao, T000X4_A343ParametroValor, T000X4_n343ParametroValor, T000X4_A518ParametroDel
               }
               , new Object[] {
               T000X5_A342ParametroChave
               }
               , new Object[] {
               T000X6_A342ParametroChave
               }
               , new Object[] {
               T000X7_A342ParametroChave
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000X11_A342ParametroChave
               }
            }
         );
         AV14Pgmname = "core.Parametros";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound36 ;
      private short GX_JID ;
      private short nIsDirty_36 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtParametroChave_Enabled ;
      private int edtParametroDescricao_Enabled ;
      private int edtParametroValor_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z522ParametroDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtParametroChave_Internalname ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Dvpanel_tableattributes_Width ;
      private string Dvpanel_tableattributes_Cls ;
      private string Dvpanel_tableattributes_Title ;
      private string Dvpanel_tableattributes_Iconposition ;
      private string Dvpanel_tableattributes_Internalname ;
      private string divTableattributes_Internalname ;
      private string TempTags ;
      private string edtParametroChave_Jsonclick ;
      private string edtParametroDescricao_Internalname ;
      private string edtParametroValor_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string A522ParametroDelUsuId ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode36 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z519ParametroDelDataHora ;
      private DateTime Z520ParametroDelData ;
      private DateTime Z521ParametroDelHora ;
      private DateTime A519ParametroDelDataHora ;
      private DateTime A520ParametroDelData ;
      private DateTime A521ParametroDelHora ;
      private bool Z518ParametroDel ;
      private bool O518ParametroDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n519ParametroDelDataHora ;
      private bool n520ParametroDelData ;
      private bool n521ParametroDelHora ;
      private bool n522ParametroDelUsuId ;
      private bool n523ParametroDelUsuNome ;
      private bool n344ParametroDescricao ;
      private bool n343ParametroValor ;
      private bool A518ParametroDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string wcpOAV7ParametroChave ;
      private string Z342ParametroChave ;
      private string Z523ParametroDelUsuNome ;
      private string Z344ParametroDescricao ;
      private string Z343ParametroValor ;
      private string AV7ParametroChave ;
      private string A342ParametroChave ;
      private string A344ParametroDescricao ;
      private string A343ParametroValor ;
      private string A523ParametroDelUsuNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000X4_A342ParametroChave ;
      private DateTime[] T000X4_A519ParametroDelDataHora ;
      private bool[] T000X4_n519ParametroDelDataHora ;
      private DateTime[] T000X4_A520ParametroDelData ;
      private bool[] T000X4_n520ParametroDelData ;
      private DateTime[] T000X4_A521ParametroDelHora ;
      private bool[] T000X4_n521ParametroDelHora ;
      private string[] T000X4_A522ParametroDelUsuId ;
      private bool[] T000X4_n522ParametroDelUsuId ;
      private string[] T000X4_A523ParametroDelUsuNome ;
      private bool[] T000X4_n523ParametroDelUsuNome ;
      private string[] T000X4_A344ParametroDescricao ;
      private bool[] T000X4_n344ParametroDescricao ;
      private string[] T000X4_A343ParametroValor ;
      private bool[] T000X4_n343ParametroValor ;
      private bool[] T000X4_A518ParametroDel ;
      private string[] T000X5_A342ParametroChave ;
      private string[] T000X3_A342ParametroChave ;
      private DateTime[] T000X3_A519ParametroDelDataHora ;
      private bool[] T000X3_n519ParametroDelDataHora ;
      private DateTime[] T000X3_A520ParametroDelData ;
      private bool[] T000X3_n520ParametroDelData ;
      private DateTime[] T000X3_A521ParametroDelHora ;
      private bool[] T000X3_n521ParametroDelHora ;
      private string[] T000X3_A522ParametroDelUsuId ;
      private bool[] T000X3_n522ParametroDelUsuId ;
      private string[] T000X3_A523ParametroDelUsuNome ;
      private bool[] T000X3_n523ParametroDelUsuNome ;
      private string[] T000X3_A344ParametroDescricao ;
      private bool[] T000X3_n344ParametroDescricao ;
      private string[] T000X3_A343ParametroValor ;
      private bool[] T000X3_n343ParametroValor ;
      private bool[] T000X3_A518ParametroDel ;
      private string[] T000X6_A342ParametroChave ;
      private string[] T000X7_A342ParametroChave ;
      private string[] T000X2_A342ParametroChave ;
      private DateTime[] T000X2_A519ParametroDelDataHora ;
      private bool[] T000X2_n519ParametroDelDataHora ;
      private DateTime[] T000X2_A520ParametroDelData ;
      private bool[] T000X2_n520ParametroDelData ;
      private DateTime[] T000X2_A521ParametroDelHora ;
      private bool[] T000X2_n521ParametroDelHora ;
      private string[] T000X2_A522ParametroDelUsuId ;
      private bool[] T000X2_n522ParametroDelUsuId ;
      private string[] T000X2_A523ParametroDelUsuNome ;
      private bool[] T000X2_n523ParametroDelUsuNome ;
      private string[] T000X2_A344ParametroDescricao ;
      private bool[] T000X2_n344ParametroDescricao ;
      private string[] T000X2_A343ParametroValor ;
      private bool[] T000X2_n343ParametroValor ;
      private bool[] T000X2_A518ParametroDel ;
      private string[] T000X11_A342ParametroChave ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class parametros__gam : DataStoreHelperBase, IDataStoreHelper
   {
      public ICursor[] getCursors( )
      {
         cursorDefinitions();
         return new Cursor[] {
       };
    }

    private static CursorDef[] def;
    private void cursorDefinitions( )
    {
       if ( def == null )
       {
          def= new CursorDef[] {
          };
       }
    }

    public void getResults( int cursor ,
                            IFieldGetter rslt ,
                            Object[] buf )
    {
    }

    public override string getDataStoreName( )
    {
       return "GAM";
    }

 }

 public class parametros__default : DataStoreHelperBase, IDataStoreHelper
 {
    public ICursor[] getCursors( )
    {
       cursorDefinitions();
       return new Cursor[] {
        new ForEachCursor(def[0])
       ,new ForEachCursor(def[1])
       ,new ForEachCursor(def[2])
       ,new ForEachCursor(def[3])
       ,new ForEachCursor(def[4])
       ,new ForEachCursor(def[5])
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000X4;
        prmT000X4 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X5;
        prmT000X5 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X3;
        prmT000X3 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X6;
        prmT000X6 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X7;
        prmT000X7 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X2;
        prmT000X2 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X8;
        prmT000X8 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0) ,
        new ParDef("ParametroDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("ParametroDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("ParametroDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("ParametroDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("ParametroDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true} ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroDel",GXType.Boolean,4,0)
        };
        Object[] prmT000X9;
        prmT000X9 = new Object[] {
        new ParDef("ParametroDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("ParametroDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("ParametroDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("ParametroDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("ParametroDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("ParametroDescricao",GXType.VarChar,500,0){Nullable=true} ,
        new ParDef("ParametroValor",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("ParametroDel",GXType.Boolean,4,0) ,
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X10;
        prmT000X10 = new Object[] {
        new ParDef("ParametroChave",GXType.VarChar,100,0)
        };
        Object[] prmT000X11;
        prmT000X11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000X2", "SELECT ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel FROM tb_parametro WHERE ParametroChave = :ParametroChave  FOR UPDATE OF tb_parametro NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000X2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X3", "SELECT ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel FROM tb_parametro WHERE ParametroChave = :ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X4", "SELECT TM1.ParametroChave, TM1.ParametroDelDataHora, TM1.ParametroDelData, TM1.ParametroDelHora, TM1.ParametroDelUsuId, TM1.ParametroDelUsuNome, TM1.ParametroDescricao, TM1.ParametroValor, TM1.ParametroDel FROM tb_parametro TM1 WHERE TM1.ParametroChave = ( :ParametroChave) ORDER BY TM1.ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X5", "SELECT ParametroChave FROM tb_parametro WHERE ParametroChave = :ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000X6", "SELECT ParametroChave FROM tb_parametro WHERE ( ParametroChave > ( :ParametroChave)) ORDER BY ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X7", "SELECT ParametroChave FROM tb_parametro WHERE ( ParametroChave < ( :ParametroChave)) ORDER BY ParametroChave DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000X8", "SAVEPOINT gxupdate;INSERT INTO tb_parametro(ParametroChave, ParametroDelDataHora, ParametroDelData, ParametroDelHora, ParametroDelUsuId, ParametroDelUsuNome, ParametroDescricao, ParametroValor, ParametroDel) VALUES(:ParametroChave, :ParametroDelDataHora, :ParametroDelData, :ParametroDelHora, :ParametroDelUsuId, :ParametroDelUsuNome, :ParametroDescricao, :ParametroValor, :ParametroDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000X8)
           ,new CursorDef("T000X9", "SAVEPOINT gxupdate;UPDATE tb_parametro SET ParametroDelDataHora=:ParametroDelDataHora, ParametroDelData=:ParametroDelData, ParametroDelHora=:ParametroDelHora, ParametroDelUsuId=:ParametroDelUsuId, ParametroDelUsuNome=:ParametroDelUsuNome, ParametroDescricao=:ParametroDescricao, ParametroValor=:ParametroValor, ParametroDel=:ParametroDel  WHERE ParametroChave = :ParametroChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X9)
           ,new CursorDef("T000X10", "SAVEPOINT gxupdate;DELETE FROM tb_parametro  WHERE ParametroChave = :ParametroChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000X10)
           ,new CursorDef("T000X11", "SELECT ParametroChave FROM tb_parametro ORDER BY ParametroChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT000X11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(4);
              ((bool[]) buf[6])[0] = rslt.wasNull(4);
              ((string[]) buf[7])[0] = rslt.getString(5, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(5);
              ((string[]) buf[9])[0] = rslt.getVarchar(6);
              ((bool[]) buf[10])[0] = rslt.wasNull(6);
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((bool[]) buf[12])[0] = rslt.wasNull(7);
              ((string[]) buf[13])[0] = rslt.getVarchar(8);
              ((bool[]) buf[14])[0] = rslt.wasNull(8);
              ((bool[]) buf[15])[0] = rslt.getBool(9);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
