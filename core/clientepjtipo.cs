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
   public class clientepjtipo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.clientepjtipo.aspx")), "core.clientepjtipo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.clientepjtipo.aspx")))) ;
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
                  AV13PjtID = (int)(Math.Round(NumberUtil.Val( GetPar( "PjtID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13PjtID", StringUtil.LTrimStr( (decimal)(AV13PjtID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPJTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PjtID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo de Cliente PJ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPjtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public clientepjtipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public clientepjtipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PjtID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13PjtID = aP1_PjtID;
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
            return "clientepjtipo_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPjtSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPjtSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPjtSigla_Internalname, A156PjtSigla, StringUtil.RTrim( context.localUtil.Format( A156PjtSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPjtSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPjtSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ClientePJTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPjtNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPjtNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPjtNome_Internalname, A157PjtNome, StringUtil.RTrim( context.localUtil.Format( A157PjtNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPjtNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPjtNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ClientePJTipo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ClientePJTipo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPjtID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A155PjtID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A155PjtID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPjtID_Jsonclick, 0, "Attribute", "", "", "", "", edtPjtID_Visible, edtPjtID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID", "end", false, "", "HLP_core\\ClientePJTipo.htm");
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
         E110N2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z155PjtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z155PjtID"), ",", "."), 18, MidpointRounding.ToEven));
               Z531PjtDelDataHora = context.localUtil.CToT( cgiGet( "Z531PjtDelDataHora"), 0);
               n531PjtDelDataHora = ((DateTime.MinValue==A531PjtDelDataHora) ? true : false);
               Z532PjtDelData = context.localUtil.CToT( cgiGet( "Z532PjtDelData"), 0);
               n532PjtDelData = ((DateTime.MinValue==A532PjtDelData) ? true : false);
               Z533PjtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z533PjtDelHora"), 0));
               n533PjtDelHora = ((DateTime.MinValue==A533PjtDelHora) ? true : false);
               Z534PjtDelUsuId = cgiGet( "Z534PjtDelUsuId");
               n534PjtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A534PjtDelUsuId)) ? true : false);
               Z535PjtDelUsuNome = cgiGet( "Z535PjtDelUsuNome");
               n535PjtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A535PjtDelUsuNome)) ? true : false);
               Z156PjtSigla = cgiGet( "Z156PjtSigla");
               Z157PjtNome = cgiGet( "Z157PjtNome");
               Z217PjtAtivo = StringUtil.StrToBool( cgiGet( "Z217PjtAtivo"));
               Z530PjtDel = StringUtil.StrToBool( cgiGet( "Z530PjtDel"));
               A531PjtDelDataHora = context.localUtil.CToT( cgiGet( "Z531PjtDelDataHora"), 0);
               n531PjtDelDataHora = false;
               n531PjtDelDataHora = ((DateTime.MinValue==A531PjtDelDataHora) ? true : false);
               A532PjtDelData = context.localUtil.CToT( cgiGet( "Z532PjtDelData"), 0);
               n532PjtDelData = false;
               n532PjtDelData = ((DateTime.MinValue==A532PjtDelData) ? true : false);
               A533PjtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z533PjtDelHora"), 0));
               n533PjtDelHora = false;
               n533PjtDelHora = ((DateTime.MinValue==A533PjtDelHora) ? true : false);
               A534PjtDelUsuId = cgiGet( "Z534PjtDelUsuId");
               n534PjtDelUsuId = false;
               n534PjtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A534PjtDelUsuId)) ? true : false);
               A535PjtDelUsuNome = cgiGet( "Z535PjtDelUsuNome");
               n535PjtDelUsuNome = false;
               n535PjtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A535PjtDelUsuNome)) ? true : false);
               A217PjtAtivo = StringUtil.StrToBool( cgiGet( "Z217PjtAtivo"));
               A530PjtDel = StringUtil.StrToBool( cgiGet( "Z530PjtDel"));
               O530PjtDel = StringUtil.StrToBool( cgiGet( "O530PjtDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV13PjtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPJTID"), ",", "."), 18, MidpointRounding.ToEven));
               A530PjtDel = StringUtil.StrToBool( cgiGet( "PJTDEL"));
               A531PjtDelDataHora = context.localUtil.CToT( cgiGet( "PJTDELDATAHORA"), 0);
               n531PjtDelDataHora = ((DateTime.MinValue==A531PjtDelDataHora) ? true : false);
               A532PjtDelData = context.localUtil.CToT( cgiGet( "PJTDELDATA"), 0);
               n532PjtDelData = ((DateTime.MinValue==A532PjtDelData) ? true : false);
               A533PjtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "PJTDELHORA"), 0));
               n533PjtDelHora = ((DateTime.MinValue==A533PjtDelHora) ? true : false);
               A534PjtDelUsuId = cgiGet( "PJTDELUSUID");
               n534PjtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A534PjtDelUsuId)) ? true : false);
               A535PjtDelUsuNome = cgiGet( "PJTDELUSUNOME");
               n535PjtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A535PjtDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A217PjtAtivo = StringUtil.StrToBool( cgiGet( "PJTATIVO"));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV14AuditingObject);
               AV15Pgmname = cgiGet( "vPGMNAME");
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
               A156PjtSigla = cgiGet( edtPjtSigla_Internalname);
               AssignAttri("", false, "A156PjtSigla", A156PjtSigla);
               A157PjtNome = StringUtil.Upper( cgiGet( edtPjtNome_Internalname));
               AssignAttri("", false, "A157PjtNome", A157PjtNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPjtID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPjtID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PJTID");
                  AnyError = 1;
                  GX_FocusControl = edtPjtID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A155PjtID = 0;
                  AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
               }
               else
               {
                  A155PjtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPjtID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJTipo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
               forbiddenHiddens.Add("PjtAtivo", StringUtil.BoolToStr( A217PjtAtivo));
               forbiddenHiddens.Add("PjtDel", StringUtil.BoolToStr( A530PjtDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A155PjtID != Z155PjtID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\clientepjtipo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A155PjtID = (int)(Math.Round(NumberUtil.Val( GetPar( "PjtID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
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
                     sMode23 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode23;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound23 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0N0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PJTID");
                        AnyError = 1;
                        GX_FocusControl = edtPjtID_Internalname;
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
                           E110N2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120N2 ();
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
            E120N2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0N23( ) ;
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
            DisableAttributes0N23( ) ;
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

      protected void CONFIRM_0N0( )
      {
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0N23( ) ;
            }
            else
            {
               CheckExtendedTable0N23( ) ;
               CloseExtendedTableCursors0N23( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0N0( )
      {
      }

      protected void E110N2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("PJTID");
         AV12WebSession.Remove("PJTNOME");
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtPjtID_Visible = 0;
         AssignProp("", false, edtPjtID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPjtID_Visible), 5, 0), true);
      }

      protected void E120N2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
         AV12WebSession.Set("PJTID", StringUtil.Trim( StringUtil.Str( (decimal)(A155PjtID), 9, 0)));
         AV12WebSession.Set("PJTNOME", A157PjtNome);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.clientepjtipoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
      }

      protected void ZM0N23( short GX_JID )
      {
         if ( ( GX_JID == 17 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z531PjtDelDataHora = T000N3_A531PjtDelDataHora[0];
               Z532PjtDelData = T000N3_A532PjtDelData[0];
               Z533PjtDelHora = T000N3_A533PjtDelHora[0];
               Z534PjtDelUsuId = T000N3_A534PjtDelUsuId[0];
               Z535PjtDelUsuNome = T000N3_A535PjtDelUsuNome[0];
               Z156PjtSigla = T000N3_A156PjtSigla[0];
               Z157PjtNome = T000N3_A157PjtNome[0];
               Z217PjtAtivo = T000N3_A217PjtAtivo[0];
               Z530PjtDel = T000N3_A530PjtDel[0];
            }
            else
            {
               Z531PjtDelDataHora = A531PjtDelDataHora;
               Z532PjtDelData = A532PjtDelData;
               Z533PjtDelHora = A533PjtDelHora;
               Z534PjtDelUsuId = A534PjtDelUsuId;
               Z535PjtDelUsuNome = A535PjtDelUsuNome;
               Z156PjtSigla = A156PjtSigla;
               Z157PjtNome = A157PjtNome;
               Z217PjtAtivo = A217PjtAtivo;
               Z530PjtDel = A530PjtDel;
            }
         }
         if ( GX_JID == -17 )
         {
            Z155PjtID = A155PjtID;
            Z531PjtDelDataHora = A531PjtDelDataHora;
            Z532PjtDelData = A532PjtDelData;
            Z533PjtDelHora = A533PjtDelHora;
            Z534PjtDelUsuId = A534PjtDelUsuId;
            Z535PjtDelUsuNome = A535PjtDelUsuNome;
            Z156PjtSigla = A156PjtSigla;
            Z157PjtNome = A157PjtNome;
            Z217PjtAtivo = A217PjtAtivo;
            Z530PjtDel = A530PjtDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV15Pgmname = "core.ClientePJTipo";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         if ( ! (0==AV13PjtID) )
         {
            A155PjtID = AV13PjtID;
            AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
         }
         if ( ! (0==AV13PjtID) )
         {
            edtPjtID_Enabled = 0;
            AssignProp("", false, edtPjtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtID_Enabled), 5, 0), true);
         }
         else
         {
            edtPjtID_Enabled = 1;
            AssignProp("", false, edtPjtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV13PjtID) )
         {
            edtPjtID_Enabled = 0;
            AssignProp("", false, edtPjtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtID_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A217PjtAtivo) && ( Gx_BScreen == 0 ) )
         {
            A217PjtAtivo = true;
            AssignAttri("", false, "A217PjtAtivo", A217PjtAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0N23( )
      {
         /* Using cursor T000N4 */
         pr_default.execute(2, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound23 = 1;
            A531PjtDelDataHora = T000N4_A531PjtDelDataHora[0];
            n531PjtDelDataHora = T000N4_n531PjtDelDataHora[0];
            A532PjtDelData = T000N4_A532PjtDelData[0];
            n532PjtDelData = T000N4_n532PjtDelData[0];
            A533PjtDelHora = T000N4_A533PjtDelHora[0];
            n533PjtDelHora = T000N4_n533PjtDelHora[0];
            A534PjtDelUsuId = T000N4_A534PjtDelUsuId[0];
            n534PjtDelUsuId = T000N4_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = T000N4_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = T000N4_n535PjtDelUsuNome[0];
            A156PjtSigla = T000N4_A156PjtSigla[0];
            AssignAttri("", false, "A156PjtSigla", A156PjtSigla);
            A157PjtNome = T000N4_A157PjtNome[0];
            AssignAttri("", false, "A157PjtNome", A157PjtNome);
            A217PjtAtivo = T000N4_A217PjtAtivo[0];
            A530PjtDel = T000N4_A530PjtDel[0];
            ZM0N23( -17) ;
         }
         pr_default.close(2);
         OnLoadActions0N23( ) ;
      }

      protected void OnLoadActions0N23( )
      {
      }

      protected void CheckExtendedTable0N23( )
      {
         nIsDirty_23 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000N5 */
         pr_default.execute(3, new Object[] {A156PjtSigla, A155PjtID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "PJTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtPjtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( (0==A155PjtID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID", "", "", "", "", "", "", "", ""), 1, "PJTID");
            AnyError = 1;
            GX_FocusControl = edtPjtID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A156PjtSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "PJTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtPjtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A157PjtNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "PJTNOME");
            AnyError = 1;
            GX_FocusControl = edtPjtNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0N23( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0N23( )
      {
         /* Using cursor T000N6 */
         pr_default.execute(4, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound23 = 1;
         }
         else
         {
            RcdFound23 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000N3 */
         pr_default.execute(1, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0N23( 17) ;
            RcdFound23 = 1;
            A155PjtID = T000N3_A155PjtID[0];
            AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
            A531PjtDelDataHora = T000N3_A531PjtDelDataHora[0];
            n531PjtDelDataHora = T000N3_n531PjtDelDataHora[0];
            A532PjtDelData = T000N3_A532PjtDelData[0];
            n532PjtDelData = T000N3_n532PjtDelData[0];
            A533PjtDelHora = T000N3_A533PjtDelHora[0];
            n533PjtDelHora = T000N3_n533PjtDelHora[0];
            A534PjtDelUsuId = T000N3_A534PjtDelUsuId[0];
            n534PjtDelUsuId = T000N3_n534PjtDelUsuId[0];
            A535PjtDelUsuNome = T000N3_A535PjtDelUsuNome[0];
            n535PjtDelUsuNome = T000N3_n535PjtDelUsuNome[0];
            A156PjtSigla = T000N3_A156PjtSigla[0];
            AssignAttri("", false, "A156PjtSigla", A156PjtSigla);
            A157PjtNome = T000N3_A157PjtNome[0];
            AssignAttri("", false, "A157PjtNome", A157PjtNome);
            A217PjtAtivo = T000N3_A217PjtAtivo[0];
            A530PjtDel = T000N3_A530PjtDel[0];
            O530PjtDel = A530PjtDel;
            AssignAttri("", false, "A530PjtDel", A530PjtDel);
            Z155PjtID = A155PjtID;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0N23( ) ;
            if ( AnyError == 1 )
            {
               RcdFound23 = 0;
               InitializeNonKey0N23( ) ;
            }
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound23 = 0;
            InitializeNonKey0N23( ) ;
            sMode23 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode23;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0N23( ) ;
         if ( RcdFound23 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound23 = 0;
         /* Using cursor T000N7 */
         pr_default.execute(5, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000N7_A155PjtID[0] < A155PjtID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000N7_A155PjtID[0] > A155PjtID ) ) )
            {
               A155PjtID = T000N7_A155PjtID[0];
               AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound23 = 0;
         /* Using cursor T000N8 */
         pr_default.execute(6, new Object[] {A155PjtID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A155PjtID[0] > A155PjtID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000N8_A155PjtID[0] < A155PjtID ) ) )
            {
               A155PjtID = T000N8_A155PjtID[0];
               AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
               RcdFound23 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0N23( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPjtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0N23( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound23 == 1 )
            {
               if ( A155PjtID != Z155PjtID )
               {
                  A155PjtID = Z155PjtID;
                  AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PJTID");
                  AnyError = 1;
                  GX_FocusControl = edtPjtID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPjtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0N23( ) ;
                  GX_FocusControl = edtPjtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A155PjtID != Z155PjtID )
               {
                  /* Insert record */
                  GX_FocusControl = edtPjtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0N23( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PJTID");
                     AnyError = 1;
                     GX_FocusControl = edtPjtID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPjtSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0N23( ) ;
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
         if ( A155PjtID != Z155PjtID )
         {
            A155PjtID = Z155PjtID;
            AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PJTID");
            AnyError = 1;
            GX_FocusControl = edtPjtID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPjtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0N23( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000N2 */
            pr_default.execute(0, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepjtipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z531PjtDelDataHora != T000N2_A531PjtDelDataHora[0] ) || ( Z532PjtDelData != T000N2_A532PjtDelData[0] ) || ( Z533PjtDelHora != T000N2_A533PjtDelHora[0] ) || ( StringUtil.StrCmp(Z534PjtDelUsuId, T000N2_A534PjtDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z535PjtDelUsuNome, T000N2_A535PjtDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z156PjtSigla, T000N2_A156PjtSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z157PjtNome, T000N2_A157PjtNome[0]) != 0 ) || ( Z217PjtAtivo != T000N2_A217PjtAtivo[0] ) || ( Z530PjtDel != T000N2_A530PjtDel[0] ) )
            {
               if ( Z531PjtDelDataHora != T000N2_A531PjtDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z531PjtDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A531PjtDelDataHora[0]);
               }
               if ( Z532PjtDelData != T000N2_A532PjtDelData[0] )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDelData");
                  GXUtil.WriteLogRaw("Old: ",Z532PjtDelData);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A532PjtDelData[0]);
               }
               if ( Z533PjtDelHora != T000N2_A533PjtDelHora[0] )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z533PjtDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A533PjtDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z534PjtDelUsuId, T000N2_A534PjtDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z534PjtDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A534PjtDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z535PjtDelUsuNome, T000N2_A535PjtDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z535PjtDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A535PjtDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z156PjtSigla, T000N2_A156PjtSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtSigla");
                  GXUtil.WriteLogRaw("Old: ",Z156PjtSigla);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A156PjtSigla[0]);
               }
               if ( StringUtil.StrCmp(Z157PjtNome, T000N2_A157PjtNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtNome");
                  GXUtil.WriteLogRaw("Old: ",Z157PjtNome);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A157PjtNome[0]);
               }
               if ( Z217PjtAtivo != T000N2_A217PjtAtivo[0] )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z217PjtAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A217PjtAtivo[0]);
               }
               if ( Z530PjtDel != T000N2_A530PjtDel[0] )
               {
                  GXUtil.WriteLog("core.clientepjtipo:[seudo value changed for attri]"+"PjtDel");
                  GXUtil.WriteLogRaw("Old: ",Z530PjtDel);
                  GXUtil.WriteLogRaw("Current: ",T000N2_A530PjtDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_clientepjtipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0N23( )
      {
         if ( ! IsAuthorized("clientepjtipo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0N23( 0) ;
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N9 */
                     pr_default.execute(7, new Object[] {A155PjtID, n531PjtDelDataHora, A531PjtDelDataHora, n532PjtDelData, A532PjtDelData, n533PjtDelHora, A533PjtDelHora, n534PjtDelUsuId, A534PjtDelUsuId, n535PjtDelUsuNome, A535PjtDelUsuNome, A156PjtSigla, A157PjtNome, A217PjtAtivo, A530PjtDel});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
                     if ( (pr_default.getStatus(7) == 1) )
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
                           ResetCaption0N0( ) ;
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
               Load0N23( ) ;
            }
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void Update0N23( )
      {
         if ( ! IsAuthorized("clientepjtipo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0N23( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0N23( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000N10 */
                     pr_default.execute(8, new Object[] {n531PjtDelDataHora, A531PjtDelDataHora, n532PjtDelData, A532PjtDelData, n533PjtDelHora, A533PjtDelHora, n534PjtDelUsuId, A534PjtDelUsuId, n535PjtDelUsuNome, A535PjtDelUsuNome, A156PjtSigla, A157PjtNome, A217PjtAtivo, A530PjtDel, A155PjtID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_clientepjtipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0N23( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_clientepjtipoupdateredundancy(context ).execute( ref  A155PjtID) ;
                        AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
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
            EndLevel0N23( ) ;
         }
         CloseExtendedTableCursors0N23( ) ;
      }

      protected void DeferredUpdate0N23( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("clientepjtipo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0N23( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0N23( ) ;
            AfterConfirm0N23( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0N23( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000N11 */
                  pr_default.execute(9, new Object[] {A155PjtID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("tb_clientepjtipo");
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
         sMode23 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0N23( ) ;
         Gx_mode = sMode23;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0N23( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000N12 */
            pr_default.execute(10, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000N13 */
            pr_default.execute(11, new Object[] {A155PjtID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0N23( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0N23( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.clientepjtipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0N0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.clientepjtipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0N23( )
      {
         /* Scan By routine */
         /* Using cursor T000N14 */
         pr_default.execute(12);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound23 = 1;
            A155PjtID = T000N14_A155PjtID[0];
            AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0N23( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound23 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound23 = 1;
            A155PjtID = T000N14_A155PjtID[0];
            AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
         }
      }

      protected void ScanEnd0N23( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0N23( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0N23( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0N23( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A531PjtDelDataHora = DateTimeUtil.NowMS( context);
            n531PjtDelDataHora = false;
            AssignAttri("", false, "A531PjtDelDataHora", context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A534PjtDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n534PjtDelUsuId = false;
            AssignAttri("", false, "A534PjtDelUsuId", A534PjtDelUsuId);
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A535PjtDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n535PjtDelUsuNome = false;
            AssignAttri("", false, "A535PjtDelUsuNome", A535PjtDelUsuNome);
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A532PjtDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A531PjtDelDataHora) ) ;
            n532PjtDelData = false;
            AssignAttri("", false, "A532PjtDelData", context.localUtil.TToC( A532PjtDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A530PjtDel && ( O530PjtDel != A530PjtDel ) )
         {
            A533PjtDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A531PjtDelDataHora));
            n533PjtDelHora = false;
            AssignAttri("", false, "A533PjtDelHora", context.localUtil.TToC( A533PjtDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0N23( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
      }

      protected void BeforeComplete0N23( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0N23( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0N23( )
      {
         edtPjtSigla_Enabled = 0;
         AssignProp("", false, edtPjtSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtSigla_Enabled), 5, 0), true);
         edtPjtNome_Enabled = 0;
         AssignProp("", false, edtPjtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtNome_Enabled), 5, 0), true);
         edtPjtID_Enabled = 0;
         AssignProp("", false, edtPjtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPjtID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0N23( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0N0( )
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
         GXEncryptionTmp = "core.clientepjtipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13PjtID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.clientepjtipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ClientePJTipo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
         forbiddenHiddens.Add("PjtAtivo", StringUtil.BoolToStr( A217PjtAtivo));
         forbiddenHiddens.Add("PjtDel", StringUtil.BoolToStr( A530PjtDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\clientepjtipo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z155PjtID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z155PjtID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z531PjtDelDataHora", context.localUtil.TToC( Z531PjtDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z532PjtDelData", context.localUtil.TToC( Z532PjtDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z533PjtDelHora", context.localUtil.TToC( Z533PjtDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z534PjtDelUsuId", StringUtil.RTrim( Z534PjtDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z535PjtDelUsuNome", Z535PjtDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z156PjtSigla", Z156PjtSigla);
         GxWebStd.gx_hidden_field( context, "Z157PjtNome", Z157PjtNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z217PjtAtivo", Z217PjtAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z530PjtDel", Z530PjtDel);
         GxWebStd.gx_boolean_hidden_field( context, "O530PjtDel", O530PjtDel);
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
         GxWebStd.gx_hidden_field( context, "vPJTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13PjtID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPJTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13PjtID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "PJTDEL", A530PjtDel);
         GxWebStd.gx_hidden_field( context, "PJTDELDATAHORA", context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PJTDELDATA", context.localUtil.TToC( A532PjtDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PJTDELHORA", context.localUtil.TToC( A533PjtDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PJTDELUSUID", StringUtil.RTrim( A534PjtDelUsuId));
         GxWebStd.gx_hidden_field( context, "PJTDELUSUNOME", A535PjtDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "PJTATIVO", A217PjtAtivo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV14AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV14AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV15Pgmname));
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
         GXEncryptionTmp = "core.clientepjtipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13PjtID,9,0));
         return formatLink("core.clientepjtipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ClientePJTipo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Cliente PJ" ;
      }

      protected void InitializeNonKey0N23( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         n531PjtDelDataHora = false;
         AssignAttri("", false, "A531PjtDelDataHora", context.localUtil.TToC( A531PjtDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A532PjtDelData = (DateTime)(DateTime.MinValue);
         n532PjtDelData = false;
         AssignAttri("", false, "A532PjtDelData", context.localUtil.TToC( A532PjtDelData, 10, 5, 0, 3, "/", ":", " "));
         A533PjtDelHora = (DateTime)(DateTime.MinValue);
         n533PjtDelHora = false;
         AssignAttri("", false, "A533PjtDelHora", context.localUtil.TToC( A533PjtDelHora, 0, 5, 0, 3, "/", ":", " "));
         A534PjtDelUsuId = "";
         n534PjtDelUsuId = false;
         AssignAttri("", false, "A534PjtDelUsuId", A534PjtDelUsuId);
         A535PjtDelUsuNome = "";
         n535PjtDelUsuNome = false;
         AssignAttri("", false, "A535PjtDelUsuNome", A535PjtDelUsuNome);
         A156PjtSigla = "";
         AssignAttri("", false, "A156PjtSigla", A156PjtSigla);
         A157PjtNome = "";
         AssignAttri("", false, "A157PjtNome", A157PjtNome);
         A530PjtDel = false;
         AssignAttri("", false, "A530PjtDel", A530PjtDel);
         A217PjtAtivo = true;
         AssignAttri("", false, "A217PjtAtivo", A217PjtAtivo);
         O530PjtDel = A530PjtDel;
         AssignAttri("", false, "A530PjtDel", A530PjtDel);
         Z531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         Z532PjtDelData = (DateTime)(DateTime.MinValue);
         Z533PjtDelHora = (DateTime)(DateTime.MinValue);
         Z534PjtDelUsuId = "";
         Z535PjtDelUsuNome = "";
         Z156PjtSigla = "";
         Z157PjtNome = "";
         Z217PjtAtivo = false;
         Z530PjtDel = false;
      }

      protected void InitAll0N23( )
      {
         A155PjtID = 0;
         AssignAttri("", false, "A155PjtID", StringUtil.LTrimStr( (decimal)(A155PjtID), 9, 0));
         InitializeNonKey0N23( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A217PjtAtivo = i217PjtAtivo;
         AssignAttri("", false, "A217PjtAtivo", A217PjtAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382813097", true, true);
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
         context.AddJavascriptSource("core/clientepjtipo.js", "?202382813099", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPjtSigla_Internalname = "PJTSIGLA";
         edtPjtNome_Internalname = "PJTNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtPjtID_Internalname = "PJTID";
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
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tipo de Cliente PJ";
         edtPjtID_Jsonclick = "";
         edtPjtID_Enabled = 1;
         edtPjtID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPjtNome_Jsonclick = "";
         edtPjtNome_Enabled = 1;
         edtPjtSigla_Jsonclick = "";
         edtPjtSigla_Enabled = 1;
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

      protected void XC_13_0N23( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A155PjtID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV14AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_14_0N23( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A155PjtID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "Y", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV14AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_15_0N23( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A155PjtID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV14AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_16_0N23( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A155PjtID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditclientepjtipo(context ).execute(  "N", ref  AV14AuditingObject,  A155PjtID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV14AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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

      public void Valid_Pjtsigla( )
      {
         /* Using cursor T000N15 */
         pr_default.execute(13, new Object[] {A156PjtSigla, A155PjtID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "PJTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtPjtSigla_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A156PjtSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "PJTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtPjtSigla_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13PjtID',fld:'vPJTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13PjtID',fld:'vPJTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A217PjtAtivo',fld:'PJTATIVO',pic:''},{av:'A530PjtDel',fld:'PJTDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120N2',iparms:[{av:'AV14AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A155PjtID',fld:'PJTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A157PjtNome',fld:'PJTNOME',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PJTSIGLA","{handler:'Valid_Pjtsigla',iparms:[{av:'A156PjtSigla',fld:'PJTSIGLA',pic:''},{av:'A155PjtID',fld:'PJTID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_PJTSIGLA",",oparms:[]}");
         setEventMetadata("VALID_PJTNOME","{handler:'Valid_Pjtnome',iparms:[]");
         setEventMetadata("VALID_PJTNOME",",oparms:[]}");
         setEventMetadata("VALID_PJTID","{handler:'Valid_Pjtid',iparms:[]");
         setEventMetadata("VALID_PJTID",",oparms:[]}");
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
         Z531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         Z532PjtDelData = (DateTime)(DateTime.MinValue);
         Z533PjtDelHora = (DateTime)(DateTime.MinValue);
         Z534PjtDelUsuId = "";
         Z535PjtDelUsuNome = "";
         Z156PjtSigla = "";
         Z157PjtNome = "";
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
         A156PjtSigla = "";
         A157PjtNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A531PjtDelDataHora = (DateTime)(DateTime.MinValue);
         A532PjtDelData = (DateTime)(DateTime.MinValue);
         A533PjtDelHora = (DateTime)(DateTime.MinValue);
         A534PjtDelUsuId = "";
         A535PjtDelUsuNome = "";
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode23 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         T000N4_A155PjtID = new int[1] ;
         T000N4_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N4_n531PjtDelDataHora = new bool[] {false} ;
         T000N4_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         T000N4_n532PjtDelData = new bool[] {false} ;
         T000N4_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000N4_n533PjtDelHora = new bool[] {false} ;
         T000N4_A534PjtDelUsuId = new string[] {""} ;
         T000N4_n534PjtDelUsuId = new bool[] {false} ;
         T000N4_A535PjtDelUsuNome = new string[] {""} ;
         T000N4_n535PjtDelUsuNome = new bool[] {false} ;
         T000N4_A156PjtSigla = new string[] {""} ;
         T000N4_A157PjtNome = new string[] {""} ;
         T000N4_A217PjtAtivo = new bool[] {false} ;
         T000N4_A530PjtDel = new bool[] {false} ;
         T000N5_A156PjtSigla = new string[] {""} ;
         T000N6_A155PjtID = new int[1] ;
         T000N3_A155PjtID = new int[1] ;
         T000N3_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N3_n531PjtDelDataHora = new bool[] {false} ;
         T000N3_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         T000N3_n532PjtDelData = new bool[] {false} ;
         T000N3_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000N3_n533PjtDelHora = new bool[] {false} ;
         T000N3_A534PjtDelUsuId = new string[] {""} ;
         T000N3_n534PjtDelUsuId = new bool[] {false} ;
         T000N3_A535PjtDelUsuNome = new string[] {""} ;
         T000N3_n535PjtDelUsuNome = new bool[] {false} ;
         T000N3_A156PjtSigla = new string[] {""} ;
         T000N3_A157PjtNome = new string[] {""} ;
         T000N3_A217PjtAtivo = new bool[] {false} ;
         T000N3_A530PjtDel = new bool[] {false} ;
         T000N7_A155PjtID = new int[1] ;
         T000N8_A155PjtID = new int[1] ;
         T000N2_A155PjtID = new int[1] ;
         T000N2_A531PjtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000N2_n531PjtDelDataHora = new bool[] {false} ;
         T000N2_A532PjtDelData = new DateTime[] {DateTime.MinValue} ;
         T000N2_n532PjtDelData = new bool[] {false} ;
         T000N2_A533PjtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000N2_n533PjtDelHora = new bool[] {false} ;
         T000N2_A534PjtDelUsuId = new string[] {""} ;
         T000N2_n534PjtDelUsuId = new bool[] {false} ;
         T000N2_A535PjtDelUsuNome = new string[] {""} ;
         T000N2_n535PjtDelUsuNome = new bool[] {false} ;
         T000N2_A156PjtSigla = new string[] {""} ;
         T000N2_A157PjtNome = new string[] {""} ;
         T000N2_A217PjtAtivo = new bool[] {false} ;
         T000N2_A530PjtDel = new bool[] {false} ;
         T000N12_A158CliID = new Guid[] {Guid.Empty} ;
         T000N12_A166CpjID = new Guid[] {Guid.Empty} ;
         T000N13_A158CliID = new Guid[] {Guid.Empty} ;
         T000N13_A166CpjID = new Guid[] {Guid.Empty} ;
         T000N13_A269CpjConSeq = new short[1] ;
         T000N14_A155PjtID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000N15_A156PjtSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.clientepjtipo__default(),
            new Object[][] {
                new Object[] {
               T000N2_A155PjtID, T000N2_A531PjtDelDataHora, T000N2_n531PjtDelDataHora, T000N2_A532PjtDelData, T000N2_n532PjtDelData, T000N2_A533PjtDelHora, T000N2_n533PjtDelHora, T000N2_A534PjtDelUsuId, T000N2_n534PjtDelUsuId, T000N2_A535PjtDelUsuNome,
               T000N2_n535PjtDelUsuNome, T000N2_A156PjtSigla, T000N2_A157PjtNome, T000N2_A217PjtAtivo, T000N2_A530PjtDel
               }
               , new Object[] {
               T000N3_A155PjtID, T000N3_A531PjtDelDataHora, T000N3_n531PjtDelDataHora, T000N3_A532PjtDelData, T000N3_n532PjtDelData, T000N3_A533PjtDelHora, T000N3_n533PjtDelHora, T000N3_A534PjtDelUsuId, T000N3_n534PjtDelUsuId, T000N3_A535PjtDelUsuNome,
               T000N3_n535PjtDelUsuNome, T000N3_A156PjtSigla, T000N3_A157PjtNome, T000N3_A217PjtAtivo, T000N3_A530PjtDel
               }
               , new Object[] {
               T000N4_A155PjtID, T000N4_A531PjtDelDataHora, T000N4_n531PjtDelDataHora, T000N4_A532PjtDelData, T000N4_n532PjtDelData, T000N4_A533PjtDelHora, T000N4_n533PjtDelHora, T000N4_A534PjtDelUsuId, T000N4_n534PjtDelUsuId, T000N4_A535PjtDelUsuNome,
               T000N4_n535PjtDelUsuNome, T000N4_A156PjtSigla, T000N4_A157PjtNome, T000N4_A217PjtAtivo, T000N4_A530PjtDel
               }
               , new Object[] {
               T000N5_A156PjtSigla
               }
               , new Object[] {
               T000N6_A155PjtID
               }
               , new Object[] {
               T000N7_A155PjtID
               }
               , new Object[] {
               T000N8_A155PjtID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000N12_A158CliID, T000N12_A166CpjID
               }
               , new Object[] {
               T000N13_A158CliID, T000N13_A166CpjID, T000N13_A269CpjConSeq
               }
               , new Object[] {
               T000N14_A155PjtID
               }
               , new Object[] {
               T000N15_A156PjtSigla
               }
            }
         );
         Z217PjtAtivo = true;
         A217PjtAtivo = true;
         i217PjtAtivo = true;
         AV15Pgmname = "core.ClientePJTipo";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound23 ;
      private short GX_JID ;
      private short nIsDirty_23 ;
      private short gxajaxcallmode ;
      private int wcpOAV13PjtID ;
      private int Z155PjtID ;
      private int AV13PjtID ;
      private int trnEnded ;
      private int edtPjtSigla_Enabled ;
      private int edtPjtNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A155PjtID ;
      private int edtPjtID_Visible ;
      private int edtPjtID_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z534PjtDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPjtSigla_Internalname ;
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
      private string edtPjtSigla_Jsonclick ;
      private string edtPjtNome_Internalname ;
      private string edtPjtNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPjtID_Internalname ;
      private string edtPjtID_Jsonclick ;
      private string A534PjtDelUsuId ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode23 ;
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
      private DateTime Z531PjtDelDataHora ;
      private DateTime Z532PjtDelData ;
      private DateTime Z533PjtDelHora ;
      private DateTime A531PjtDelDataHora ;
      private DateTime A532PjtDelData ;
      private DateTime A533PjtDelHora ;
      private bool Z217PjtAtivo ;
      private bool Z530PjtDel ;
      private bool O530PjtDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n531PjtDelDataHora ;
      private bool n532PjtDelData ;
      private bool n533PjtDelHora ;
      private bool n534PjtDelUsuId ;
      private bool n535PjtDelUsuNome ;
      private bool A217PjtAtivo ;
      private bool A530PjtDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i217PjtAtivo ;
      private string Z535PjtDelUsuNome ;
      private string Z156PjtSigla ;
      private string Z157PjtNome ;
      private string A156PjtSigla ;
      private string A157PjtNome ;
      private string A535PjtDelUsuNome ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000N4_A155PjtID ;
      private DateTime[] T000N4_A531PjtDelDataHora ;
      private bool[] T000N4_n531PjtDelDataHora ;
      private DateTime[] T000N4_A532PjtDelData ;
      private bool[] T000N4_n532PjtDelData ;
      private DateTime[] T000N4_A533PjtDelHora ;
      private bool[] T000N4_n533PjtDelHora ;
      private string[] T000N4_A534PjtDelUsuId ;
      private bool[] T000N4_n534PjtDelUsuId ;
      private string[] T000N4_A535PjtDelUsuNome ;
      private bool[] T000N4_n535PjtDelUsuNome ;
      private string[] T000N4_A156PjtSigla ;
      private string[] T000N4_A157PjtNome ;
      private bool[] T000N4_A217PjtAtivo ;
      private bool[] T000N4_A530PjtDel ;
      private string[] T000N5_A156PjtSigla ;
      private int[] T000N6_A155PjtID ;
      private int[] T000N3_A155PjtID ;
      private DateTime[] T000N3_A531PjtDelDataHora ;
      private bool[] T000N3_n531PjtDelDataHora ;
      private DateTime[] T000N3_A532PjtDelData ;
      private bool[] T000N3_n532PjtDelData ;
      private DateTime[] T000N3_A533PjtDelHora ;
      private bool[] T000N3_n533PjtDelHora ;
      private string[] T000N3_A534PjtDelUsuId ;
      private bool[] T000N3_n534PjtDelUsuId ;
      private string[] T000N3_A535PjtDelUsuNome ;
      private bool[] T000N3_n535PjtDelUsuNome ;
      private string[] T000N3_A156PjtSigla ;
      private string[] T000N3_A157PjtNome ;
      private bool[] T000N3_A217PjtAtivo ;
      private bool[] T000N3_A530PjtDel ;
      private int[] T000N7_A155PjtID ;
      private int[] T000N8_A155PjtID ;
      private int[] T000N2_A155PjtID ;
      private DateTime[] T000N2_A531PjtDelDataHora ;
      private bool[] T000N2_n531PjtDelDataHora ;
      private DateTime[] T000N2_A532PjtDelData ;
      private bool[] T000N2_n532PjtDelData ;
      private DateTime[] T000N2_A533PjtDelHora ;
      private bool[] T000N2_n533PjtDelHora ;
      private string[] T000N2_A534PjtDelUsuId ;
      private bool[] T000N2_n534PjtDelUsuId ;
      private string[] T000N2_A535PjtDelUsuNome ;
      private bool[] T000N2_n535PjtDelUsuNome ;
      private string[] T000N2_A156PjtSigla ;
      private string[] T000N2_A157PjtNome ;
      private bool[] T000N2_A217PjtAtivo ;
      private bool[] T000N2_A530PjtDel ;
      private Guid[] T000N12_A158CliID ;
      private Guid[] T000N12_A166CpjID ;
      private Guid[] T000N13_A158CliID ;
      private Guid[] T000N13_A166CpjID ;
      private short[] T000N13_A269CpjConSeq ;
      private int[] T000N14_A155PjtID ;
      private string[] T000N15_A156PjtSigla ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class clientepjtipo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class clientepjtipo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000N4;
        prmT000N4 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N5;
        prmT000N5 = new Object[] {
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N6;
        prmT000N6 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N3;
        prmT000N3 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N7;
        prmT000N7 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N8;
        prmT000N8 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N2;
        prmT000N2 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N9;
        prmT000N9 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0) ,
        new ParDef("PjtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PjtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PjtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PjtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PjtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtNome",GXType.VarChar,80,0) ,
        new ParDef("PjtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PjtDel",GXType.Boolean,4,0)
        };
        Object[] prmT000N10;
        prmT000N10 = new Object[] {
        new ParDef("PjtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PjtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PjtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PjtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PjtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtNome",GXType.VarChar,80,0) ,
        new ParDef("PjtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PjtDel",GXType.Boolean,4,0) ,
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N11;
        prmT000N11 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N12;
        prmT000N12 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N13;
        prmT000N13 = new Object[] {
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        Object[] prmT000N14;
        prmT000N14 = new Object[] {
        };
        Object[] prmT000N15;
        prmT000N15 = new Object[] {
        new ParDef("PjtSigla",GXType.VarChar,20,0) ,
        new ParDef("PjtID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000N2", "SELECT PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel FROM tb_clientepjtipo WHERE PjtID = :PjtID  FOR UPDATE OF tb_clientepjtipo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000N2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N3", "SELECT PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel FROM tb_clientepjtipo WHERE PjtID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N4", "SELECT TM1.PjtID, TM1.PjtDelDataHora, TM1.PjtDelData, TM1.PjtDelHora, TM1.PjtDelUsuId, TM1.PjtDelUsuNome, TM1.PjtSigla, TM1.PjtNome, TM1.PjtAtivo, TM1.PjtDel FROM tb_clientepjtipo TM1 WHERE TM1.PjtID = :PjtID ORDER BY TM1.PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N5", "SELECT PjtSigla FROM tb_clientepjtipo WHERE (PjtSigla = :PjtSigla) AND (Not ( PjtID = :PjtID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N6", "SELECT PjtID FROM tb_clientepjtipo WHERE PjtID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N7", "SELECT PjtID FROM tb_clientepjtipo WHERE ( PjtID > :PjtID) ORDER BY PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N8", "SELECT PjtID FROM tb_clientepjtipo WHERE ( PjtID < :PjtID) ORDER BY PjtID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N9", "SAVEPOINT gxupdate;INSERT INTO tb_clientepjtipo(PjtID, PjtDelDataHora, PjtDelData, PjtDelHora, PjtDelUsuId, PjtDelUsuNome, PjtSigla, PjtNome, PjtAtivo, PjtDel) VALUES(:PjtID, :PjtDelDataHora, :PjtDelData, :PjtDelHora, :PjtDelUsuId, :PjtDelUsuNome, :PjtSigla, :PjtNome, :PjtAtivo, :PjtDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000N9)
           ,new CursorDef("T000N10", "SAVEPOINT gxupdate;UPDATE tb_clientepjtipo SET PjtDelDataHora=:PjtDelDataHora, PjtDelData=:PjtDelData, PjtDelHora=:PjtDelHora, PjtDelUsuId=:PjtDelUsuId, PjtDelUsuNome=:PjtDelUsuNome, PjtSigla=:PjtSigla, PjtNome=:PjtNome, PjtAtivo=:PjtAtivo, PjtDel=:PjtDel  WHERE PjtID = :PjtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N10)
           ,new CursorDef("T000N11", "SAVEPOINT gxupdate;DELETE FROM tb_clientepjtipo  WHERE PjtID = :PjtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000N11)
           ,new CursorDef("T000N12", "SELECT CliID, CpjID FROM tb_clientepj WHERE CpjTipoId = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N13", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CpjConTipoID = :PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000N14", "SELECT PjtID FROM tb_clientepjtipo ORDER BY PjtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000N15", "SELECT PjtSigla FROM tb_clientepjtipo WHERE (PjtSigla = :PjtSigla) AND (Not ( PjtID = :PjtID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000N15,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 1 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 2 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
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
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 6 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              return;
           case 12 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
