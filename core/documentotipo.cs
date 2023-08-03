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
   public class documentotipo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documentotipo.aspx")), "core.documentotipo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documentotipo.aspx")))) ;
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
                  AV7DocTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "DocTipoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7DocTipoID", StringUtil.LTrimStr( (decimal)(AV7DocTipoID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocTipoID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo de Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocTipoSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documentotipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentotipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_DocTipoID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocTipoID = aP1_DocTipoID;
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
            return "documentotipo_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocTipoSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocTipoSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTipoSigla_Internalname, A147DocTipoSigla, StringUtil.RTrim( context.localUtil.Format( A147DocTipoSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTipoSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocTipoSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\DocumentoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocTipoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocTipoNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTipoNome_Internalname, A148DocTipoNome, StringUtil.RTrim( context.localUtil.Format( A148DocTipoNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTipoNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocTipoNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\DocumentoTipo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoTipo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtDocTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtDocTipoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTipoID_Jsonclick, 0, "Attribute", "", "", "", "", edtDocTipoID_Visible, edtDocTipoID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\DocumentoTipo.htm");
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
         E110K2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z146DocTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z504DocTipoDelDataHora = context.localUtil.CToT( cgiGet( "Z504DocTipoDelDataHora"), 0);
               n504DocTipoDelDataHora = ((DateTime.MinValue==A504DocTipoDelDataHora) ? true : false);
               Z505DocTipoDelData = context.localUtil.CToD( cgiGet( "Z505DocTipoDelData"), 0);
               n505DocTipoDelData = ((DateTime.MinValue==A505DocTipoDelData) ? true : false);
               Z506DocTipoDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z506DocTipoDelHora"), 0));
               n506DocTipoDelHora = ((DateTime.MinValue==A506DocTipoDelHora) ? true : false);
               Z507DocTipoDelUsuID = cgiGet( "Z507DocTipoDelUsuID");
               n507DocTipoDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A507DocTipoDelUsuID)) ? true : false);
               Z508DocTipoDelUsuNome = cgiGet( "Z508DocTipoDelUsuNome");
               n508DocTipoDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A508DocTipoDelUsuNome)) ? true : false);
               Z147DocTipoSigla = cgiGet( "Z147DocTipoSigla");
               Z148DocTipoNome = cgiGet( "Z148DocTipoNome");
               Z219DocTipoAtivo = StringUtil.StrToBool( cgiGet( "Z219DocTipoAtivo"));
               Z503DocTipoDel = StringUtil.StrToBool( cgiGet( "Z503DocTipoDel"));
               A504DocTipoDelDataHora = context.localUtil.CToT( cgiGet( "Z504DocTipoDelDataHora"), 0);
               n504DocTipoDelDataHora = false;
               n504DocTipoDelDataHora = ((DateTime.MinValue==A504DocTipoDelDataHora) ? true : false);
               A505DocTipoDelData = context.localUtil.CToD( cgiGet( "Z505DocTipoDelData"), 0);
               n505DocTipoDelData = false;
               n505DocTipoDelData = ((DateTime.MinValue==A505DocTipoDelData) ? true : false);
               A506DocTipoDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z506DocTipoDelHora"), 0));
               n506DocTipoDelHora = false;
               n506DocTipoDelHora = ((DateTime.MinValue==A506DocTipoDelHora) ? true : false);
               A507DocTipoDelUsuID = cgiGet( "Z507DocTipoDelUsuID");
               n507DocTipoDelUsuID = false;
               n507DocTipoDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A507DocTipoDelUsuID)) ? true : false);
               A508DocTipoDelUsuNome = cgiGet( "Z508DocTipoDelUsuNome");
               n508DocTipoDelUsuNome = false;
               n508DocTipoDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A508DocTipoDelUsuNome)) ? true : false);
               A219DocTipoAtivo = StringUtil.StrToBool( cgiGet( "Z219DocTipoAtivo"));
               A503DocTipoDel = StringUtil.StrToBool( cgiGet( "Z503DocTipoDel"));
               O503DocTipoDel = StringUtil.StrToBool( cgiGet( "O503DocTipoDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vDOCTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               A503DocTipoDel = StringUtil.StrToBool( cgiGet( "DOCTIPODEL"));
               A504DocTipoDelDataHora = context.localUtil.CToT( cgiGet( "DOCTIPODELDATAHORA"), 0);
               n504DocTipoDelDataHora = ((DateTime.MinValue==A504DocTipoDelDataHora) ? true : false);
               A505DocTipoDelData = context.localUtil.CToD( cgiGet( "DOCTIPODELDATA"), 0);
               n505DocTipoDelData = ((DateTime.MinValue==A505DocTipoDelData) ? true : false);
               A506DocTipoDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCTIPODELHORA"), 0));
               n506DocTipoDelHora = ((DateTime.MinValue==A506DocTipoDelHora) ? true : false);
               A507DocTipoDelUsuID = cgiGet( "DOCTIPODELUSUID");
               n507DocTipoDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A507DocTipoDelUsuID)) ? true : false);
               A508DocTipoDelUsuNome = cgiGet( "DOCTIPODELUSUNOME");
               n508DocTipoDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A508DocTipoDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A219DocTipoAtivo = StringUtil.StrToBool( cgiGet( "DOCTIPOATIVO"));
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
               A147DocTipoSigla = cgiGet( edtDocTipoSigla_Internalname);
               AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
               A148DocTipoNome = StringUtil.Upper( cgiGet( edtDocTipoNome_Internalname));
               AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
               A146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"DocumentoTipo");
               A146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               forbiddenHiddens.Add("DocTipoID", context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("DocTipoAtivo", StringUtil.BoolToStr( A219DocTipoAtivo));
               forbiddenHiddens.Add("DocTipoDel", StringUtil.BoolToStr( A503DocTipoDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A146DocTipoID != Z146DocTipoID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\documentotipo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A146DocTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "DocTipoID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
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
                     sMode20 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode20;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound20 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0K0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCTIPOID");
                        AnyError = 1;
                        GX_FocusControl = edtDocTipoID_Internalname;
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
                           E110K2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120K2 ();
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
            E120K2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0K20( ) ;
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
            DisableAttributes0K20( ) ;
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

      protected void CONFIRM_0K0( )
      {
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0K20( ) ;
            }
            else
            {
               CheckExtendedTable0K20( ) ;
               CloseExtendedTableCursors0K20( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0K0( )
      {
      }

      protected void E110K2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtDocTipoID_Visible = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Visible), 5, 0), true);
      }

      protected void E120K2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.documentotipoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0K20( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z504DocTipoDelDataHora = T000K3_A504DocTipoDelDataHora[0];
               Z505DocTipoDelData = T000K3_A505DocTipoDelData[0];
               Z506DocTipoDelHora = T000K3_A506DocTipoDelHora[0];
               Z507DocTipoDelUsuID = T000K3_A507DocTipoDelUsuID[0];
               Z508DocTipoDelUsuNome = T000K3_A508DocTipoDelUsuNome[0];
               Z147DocTipoSigla = T000K3_A147DocTipoSigla[0];
               Z148DocTipoNome = T000K3_A148DocTipoNome[0];
               Z219DocTipoAtivo = T000K3_A219DocTipoAtivo[0];
               Z503DocTipoDel = T000K3_A503DocTipoDel[0];
            }
            else
            {
               Z504DocTipoDelDataHora = A504DocTipoDelDataHora;
               Z505DocTipoDelData = A505DocTipoDelData;
               Z506DocTipoDelHora = A506DocTipoDelHora;
               Z507DocTipoDelUsuID = A507DocTipoDelUsuID;
               Z508DocTipoDelUsuNome = A508DocTipoDelUsuNome;
               Z147DocTipoSigla = A147DocTipoSigla;
               Z148DocTipoNome = A148DocTipoNome;
               Z219DocTipoAtivo = A219DocTipoAtivo;
               Z503DocTipoDel = A503DocTipoDel;
            }
         }
         if ( GX_JID == -15 )
         {
            Z146DocTipoID = A146DocTipoID;
            Z504DocTipoDelDataHora = A504DocTipoDelDataHora;
            Z505DocTipoDelData = A505DocTipoDelData;
            Z506DocTipoDelHora = A506DocTipoDelHora;
            Z507DocTipoDelUsuID = A507DocTipoDelUsuID;
            Z508DocTipoDelUsuNome = A508DocTipoDelUsuNome;
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
            Z503DocTipoDel = A503DocTipoDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocTipoID_Enabled = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV14Pgmname = "core.DocumentoTipo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         edtDocTipoID_Enabled = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
         if ( ! (0==AV7DocTipoID) )
         {
            A146DocTipoID = AV7DocTipoID;
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
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
         if ( IsIns( )  && (false==A219DocTipoAtivo) && ( Gx_BScreen == 0 ) )
         {
            A219DocTipoAtivo = true;
            AssignAttri("", false, "A219DocTipoAtivo", A219DocTipoAtivo);
         }
      }

      protected void Load0K20( )
      {
         /* Using cursor T000K4 */
         pr_default.execute(2, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound20 = 1;
            A504DocTipoDelDataHora = T000K4_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = T000K4_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = T000K4_A505DocTipoDelData[0];
            n505DocTipoDelData = T000K4_n505DocTipoDelData[0];
            A506DocTipoDelHora = T000K4_A506DocTipoDelHora[0];
            n506DocTipoDelHora = T000K4_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = T000K4_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = T000K4_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = T000K4_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = T000K4_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = T000K4_A147DocTipoSigla[0];
            AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
            A148DocTipoNome = T000K4_A148DocTipoNome[0];
            AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
            A219DocTipoAtivo = T000K4_A219DocTipoAtivo[0];
            A503DocTipoDel = T000K4_A503DocTipoDel[0];
            ZM0K20( -15) ;
         }
         pr_default.close(2);
         OnLoadActions0K20( ) ;
      }

      protected void OnLoadActions0K20( )
      {
      }

      protected void CheckExtendedTable0K20( )
      {
         nIsDirty_20 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000K5 */
         pr_default.execute(3, new Object[] {A147DocTipoSigla, A146DocTipoID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "DOCTIPOSIGLA");
            AnyError = 1;
            GX_FocusControl = edtDocTipoSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A147DocTipoSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "DOCTIPOSIGLA");
            AnyError = 1;
            GX_FocusControl = edtDocTipoSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A148DocTipoNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "DOCTIPONOME");
            AnyError = 1;
            GX_FocusControl = edtDocTipoNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0K20( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0K20( )
      {
         /* Using cursor T000K6 */
         pr_default.execute(4, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound20 = 1;
         }
         else
         {
            RcdFound20 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000K3 */
         pr_default.execute(1, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0K20( 15) ;
            RcdFound20 = 1;
            A146DocTipoID = T000K3_A146DocTipoID[0];
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
            A504DocTipoDelDataHora = T000K3_A504DocTipoDelDataHora[0];
            n504DocTipoDelDataHora = T000K3_n504DocTipoDelDataHora[0];
            A505DocTipoDelData = T000K3_A505DocTipoDelData[0];
            n505DocTipoDelData = T000K3_n505DocTipoDelData[0];
            A506DocTipoDelHora = T000K3_A506DocTipoDelHora[0];
            n506DocTipoDelHora = T000K3_n506DocTipoDelHora[0];
            A507DocTipoDelUsuID = T000K3_A507DocTipoDelUsuID[0];
            n507DocTipoDelUsuID = T000K3_n507DocTipoDelUsuID[0];
            A508DocTipoDelUsuNome = T000K3_A508DocTipoDelUsuNome[0];
            n508DocTipoDelUsuNome = T000K3_n508DocTipoDelUsuNome[0];
            A147DocTipoSigla = T000K3_A147DocTipoSigla[0];
            AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
            A148DocTipoNome = T000K3_A148DocTipoNome[0];
            AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
            A219DocTipoAtivo = T000K3_A219DocTipoAtivo[0];
            A503DocTipoDel = T000K3_A503DocTipoDel[0];
            O503DocTipoDel = A503DocTipoDel;
            AssignAttri("", false, "A503DocTipoDel", A503DocTipoDel);
            Z146DocTipoID = A146DocTipoID;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0K20( ) ;
            if ( AnyError == 1 )
            {
               RcdFound20 = 0;
               InitializeNonKey0K20( ) ;
            }
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound20 = 0;
            InitializeNonKey0K20( ) ;
            sMode20 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode20;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0K20( ) ;
         if ( RcdFound20 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound20 = 0;
         /* Using cursor T000K7 */
         pr_default.execute(5, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000K7_A146DocTipoID[0] < A146DocTipoID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000K7_A146DocTipoID[0] > A146DocTipoID ) ) )
            {
               A146DocTipoID = T000K7_A146DocTipoID[0];
               AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound20 = 0;
         /* Using cursor T000K8 */
         pr_default.execute(6, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000K8_A146DocTipoID[0] > A146DocTipoID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000K8_A146DocTipoID[0] < A146DocTipoID ) ) )
            {
               A146DocTipoID = T000K8_A146DocTipoID[0];
               AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               RcdFound20 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0K20( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocTipoSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0K20( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound20 == 1 )
            {
               if ( A146DocTipoID != Z146DocTipoID )
               {
                  A146DocTipoID = Z146DocTipoID;
                  AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocTipoSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0K20( ) ;
                  GX_FocusControl = edtDocTipoSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A146DocTipoID != Z146DocTipoID )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocTipoSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0K20( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCTIPOID");
                     AnyError = 1;
                     GX_FocusControl = edtDocTipoID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocTipoSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0K20( ) ;
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
         if ( A146DocTipoID != Z146DocTipoID )
         {
            A146DocTipoID = Z146DocTipoID;
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocTipoSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0K20( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000K2 */
            pr_default.execute(0, new Object[] {A146DocTipoID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documentotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z504DocTipoDelDataHora != T000K2_A504DocTipoDelDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z505DocTipoDelData ) != DateTimeUtil.ResetTime ( T000K2_A505DocTipoDelData[0] ) ) || ( Z506DocTipoDelHora != T000K2_A506DocTipoDelHora[0] ) || ( StringUtil.StrCmp(Z507DocTipoDelUsuID, T000K2_A507DocTipoDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z508DocTipoDelUsuNome, T000K2_A508DocTipoDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z147DocTipoSigla, T000K2_A147DocTipoSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z148DocTipoNome, T000K2_A148DocTipoNome[0]) != 0 ) || ( Z219DocTipoAtivo != T000K2_A219DocTipoAtivo[0] ) || ( Z503DocTipoDel != T000K2_A503DocTipoDel[0] ) )
            {
               if ( Z504DocTipoDelDataHora != T000K2_A504DocTipoDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z504DocTipoDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A504DocTipoDelDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z505DocTipoDelData ) != DateTimeUtil.ResetTime ( T000K2_A505DocTipoDelData[0] ) )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDelData");
                  GXUtil.WriteLogRaw("Old: ",Z505DocTipoDelData);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A505DocTipoDelData[0]);
               }
               if ( Z506DocTipoDelHora != T000K2_A506DocTipoDelHora[0] )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z506DocTipoDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A506DocTipoDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z507DocTipoDelUsuID, T000K2_A507DocTipoDelUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDelUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z507DocTipoDelUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A507DocTipoDelUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z508DocTipoDelUsuNome, T000K2_A508DocTipoDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z508DocTipoDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A508DocTipoDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z147DocTipoSigla, T000K2_A147DocTipoSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoSigla");
                  GXUtil.WriteLogRaw("Old: ",Z147DocTipoSigla);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A147DocTipoSigla[0]);
               }
               if ( StringUtil.StrCmp(Z148DocTipoNome, T000K2_A148DocTipoNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoNome");
                  GXUtil.WriteLogRaw("Old: ",Z148DocTipoNome);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A148DocTipoNome[0]);
               }
               if ( Z219DocTipoAtivo != T000K2_A219DocTipoAtivo[0] )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z219DocTipoAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A219DocTipoAtivo[0]);
               }
               if ( Z503DocTipoDel != T000K2_A503DocTipoDel[0] )
               {
                  GXUtil.WriteLog("core.documentotipo:[seudo value changed for attri]"+"DocTipoDel");
                  GXUtil.WriteLogRaw("Old: ",Z503DocTipoDel);
                  GXUtil.WriteLogRaw("Current: ",T000K2_A503DocTipoDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documentotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0K20( )
      {
         if ( ! IsAuthorized("documentotipo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0K20( 0) ;
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K9 */
                     pr_default.execute(7, new Object[] {n504DocTipoDelDataHora, A504DocTipoDelDataHora, n505DocTipoDelData, A505DocTipoDelData, n506DocTipoDelHora, A506DocTipoDelHora, n507DocTipoDelUsuID, A507DocTipoDelUsuID, n508DocTipoDelUsuNome, A508DocTipoDelUsuNome, A147DocTipoSigla, A148DocTipoNome, A219DocTipoAtivo, A503DocTipoDel});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000K10 */
                     pr_default.execute(8);
                     A146DocTipoID = T000K10_A146DocTipoID[0];
                     AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0K0( ) ;
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
               Load0K20( ) ;
            }
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void Update0K20( )
      {
         if ( ! IsAuthorized("documentotipo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0K20( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0K20( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000K11 */
                     pr_default.execute(9, new Object[] {n504DocTipoDelDataHora, A504DocTipoDelDataHora, n505DocTipoDelData, A505DocTipoDelData, n506DocTipoDelHora, A506DocTipoDelHora, n507DocTipoDelUsuID, A507DocTipoDelUsuID, n508DocTipoDelUsuNome, A508DocTipoDelUsuNome, A147DocTipoSigla, A148DocTipoNome, A219DocTipoAtivo, A503DocTipoDel, A146DocTipoID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documentotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0K20( ) ;
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
            EndLevel0K20( ) ;
         }
         CloseExtendedTableCursors0K20( ) ;
      }

      protected void DeferredUpdate0K20( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("documentotipo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0K20( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0K20( ) ;
            AfterConfirm0K20( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0K20( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000K12 */
                  pr_default.execute(10, new Object[] {A146DocTipoID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documentotipo");
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
         sMode20 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0K20( ) ;
         Gx_mode = sMode20;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0K20( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000K13 */
            pr_default.execute(11, new Object[] {A146DocTipoID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0K20( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0K20( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.documentotipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0K0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.documentotipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0K20( )
      {
         /* Scan By routine */
         /* Using cursor T000K14 */
         pr_default.execute(12);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound20 = 1;
            A146DocTipoID = T000K14_A146DocTipoID[0];
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0K20( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound20 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound20 = 1;
            A146DocTipoID = T000K14_A146DocTipoID[0];
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         }
      }

      protected void ScanEnd0K20( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0K20( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0K20( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0K20( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A504DocTipoDelDataHora = DateTimeUtil.Now( context);
            n504DocTipoDelDataHora = false;
            AssignAttri("", false, "A504DocTipoDelDataHora", context.localUtil.TToC( A504DocTipoDelDataHora, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A507DocTipoDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n507DocTipoDelUsuID = false;
            AssignAttri("", false, "A507DocTipoDelUsuID", A507DocTipoDelUsuID);
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A508DocTipoDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n508DocTipoDelUsuNome = false;
            AssignAttri("", false, "A508DocTipoDelUsuNome", A508DocTipoDelUsuNome);
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A505DocTipoDelData = DateTimeUtil.ResetTime( A504DocTipoDelDataHora);
            n505DocTipoDelData = false;
            AssignAttri("", false, "A505DocTipoDelData", context.localUtil.Format(A505DocTipoDelData, "99/99/99"));
         }
         if ( A503DocTipoDel && ( O503DocTipoDel != A503DocTipoDel ) )
         {
            A506DocTipoDelHora = DateTimeUtil.ResetDate(A504DocTipoDelDataHora);
            n506DocTipoDelHora = false;
            AssignAttri("", false, "A506DocTipoDelHora", context.localUtil.TToC( A506DocTipoDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0K20( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
      }

      protected void BeforeComplete0K20( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0K20( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0K20( )
      {
         edtDocTipoSigla_Enabled = 0;
         AssignProp("", false, edtDocTipoSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoSigla_Enabled), 5, 0), true);
         edtDocTipoNome_Enabled = 0;
         AssignProp("", false, edtDocTipoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoNome_Enabled), 5, 0), true);
         edtDocTipoID_Enabled = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0K20( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0K0( )
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
         GXEncryptionTmp = "core.documentotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocTipoID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documentotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"DocumentoTipo");
         forbiddenHiddens.Add("DocTipoID", context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("DocTipoAtivo", StringUtil.BoolToStr( A219DocTipoAtivo));
         forbiddenHiddens.Add("DocTipoDel", StringUtil.BoolToStr( A503DocTipoDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\documentotipo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z146DocTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z146DocTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z504DocTipoDelDataHora", context.localUtil.TToC( Z504DocTipoDelDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z505DocTipoDelData", context.localUtil.DToC( Z505DocTipoDelData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z506DocTipoDelHora", context.localUtil.TToC( Z506DocTipoDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z507DocTipoDelUsuID", StringUtil.RTrim( Z507DocTipoDelUsuID));
         GxWebStd.gx_hidden_field( context, "Z508DocTipoDelUsuNome", Z508DocTipoDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z147DocTipoSigla", Z147DocTipoSigla);
         GxWebStd.gx_hidden_field( context, "Z148DocTipoNome", Z148DocTipoNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z219DocTipoAtivo", Z219DocTipoAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z503DocTipoDel", Z503DocTipoDel);
         GxWebStd.gx_boolean_hidden_field( context, "O503DocTipoDel", O503DocTipoDel);
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
         GxWebStd.gx_hidden_field( context, "vDOCTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7DocTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCTIPOID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7DocTipoID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "DOCTIPODEL", A503DocTipoDel);
         GxWebStd.gx_hidden_field( context, "DOCTIPODELDATAHORA", context.localUtil.TToC( A504DocTipoDelDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCTIPODELDATA", context.localUtil.DToC( A505DocTipoDelData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "DOCTIPODELHORA", context.localUtil.TToC( A506DocTipoDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCTIPODELUSUID", StringUtil.RTrim( A507DocTipoDelUsuID));
         GxWebStd.gx_hidden_field( context, "DOCTIPODELUSUNOME", A508DocTipoDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "DOCTIPOATIVO", A219DocTipoAtivo);
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
         GXEncryptionTmp = "core.documentotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7DocTipoID,9,0));
         return formatLink("core.documentotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.DocumentoTipo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Documento" ;
      }

      protected void InitializeNonKey0K20( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         n504DocTipoDelDataHora = false;
         AssignAttri("", false, "A504DocTipoDelDataHora", context.localUtil.TToC( A504DocTipoDelDataHora, 10, 5, 0, 3, "/", ":", " "));
         A505DocTipoDelData = DateTime.MinValue;
         n505DocTipoDelData = false;
         AssignAttri("", false, "A505DocTipoDelData", context.localUtil.Format(A505DocTipoDelData, "99/99/99"));
         A506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         n506DocTipoDelHora = false;
         AssignAttri("", false, "A506DocTipoDelHora", context.localUtil.TToC( A506DocTipoDelHora, 0, 5, 0, 3, "/", ":", " "));
         A507DocTipoDelUsuID = "";
         n507DocTipoDelUsuID = false;
         AssignAttri("", false, "A507DocTipoDelUsuID", A507DocTipoDelUsuID);
         A508DocTipoDelUsuNome = "";
         n508DocTipoDelUsuNome = false;
         AssignAttri("", false, "A508DocTipoDelUsuNome", A508DocTipoDelUsuNome);
         A147DocTipoSigla = "";
         AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
         A148DocTipoNome = "";
         AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
         A503DocTipoDel = false;
         AssignAttri("", false, "A503DocTipoDel", A503DocTipoDel);
         A219DocTipoAtivo = true;
         AssignAttri("", false, "A219DocTipoAtivo", A219DocTipoAtivo);
         O503DocTipoDel = A503DocTipoDel;
         AssignAttri("", false, "A503DocTipoDel", A503DocTipoDel);
         Z504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         Z505DocTipoDelData = DateTime.MinValue;
         Z506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         Z507DocTipoDelUsuID = "";
         Z508DocTipoDelUsuNome = "";
         Z147DocTipoSigla = "";
         Z148DocTipoNome = "";
         Z219DocTipoAtivo = false;
         Z503DocTipoDel = false;
      }

      protected void InitAll0K20( )
      {
         A146DocTipoID = 0;
         AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         InitializeNonKey0K20( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A219DocTipoAtivo = i219DocTipoAtivo;
         AssignAttri("", false, "A219DocTipoAtivo", A219DocTipoAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828123432", true, true);
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
         context.AddJavascriptSource("core/documentotipo.js", "?2023828123434", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocTipoSigla_Internalname = "DOCTIPOSIGLA";
         edtDocTipoNome_Internalname = "DOCTIPONOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtDocTipoID_Internalname = "DOCTIPOID";
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
         Form.Caption = "Tipo de Documento";
         edtDocTipoID_Jsonclick = "";
         edtDocTipoID_Enabled = 0;
         edtDocTipoID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocTipoNome_Jsonclick = "";
         edtDocTipoNome_Enabled = 1;
         edtDocTipoSigla_Jsonclick = "";
         edtDocTipoSigla_Enabled = 1;
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

      protected void XC_11_0K20( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A146DocTipoID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
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

      protected void XC_12_0K20( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A146DocTipoID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
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

      protected void XC_13_0K20( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A146DocTipoID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
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

      protected void XC_14_0K20( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A146DocTipoID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentotipo(context ).execute(  "N", ref  AV13AuditingObject,  A146DocTipoID,  Gx_mode) ;
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

      public void Valid_Doctiposigla( )
      {
         /* Using cursor T000K15 */
         pr_default.execute(13, new Object[] {A147DocTipoSigla, A146DocTipoID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "DOCTIPOSIGLA");
            AnyError = 1;
            GX_FocusControl = edtDocTipoSigla_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A147DocTipoSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "DOCTIPOSIGLA");
            AnyError = 1;
            GX_FocusControl = edtDocTipoSigla_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7DocTipoID',fld:'vDOCTIPOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7DocTipoID',fld:'vDOCTIPOID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A146DocTipoID',fld:'DOCTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A219DocTipoAtivo',fld:'DOCTIPOATIVO',pic:''},{av:'A503DocTipoDel',fld:'DOCTIPODEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120K2',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_DOCTIPOSIGLA","{handler:'Valid_Doctiposigla',iparms:[{av:'A147DocTipoSigla',fld:'DOCTIPOSIGLA',pic:''},{av:'A146DocTipoID',fld:'DOCTIPOID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_DOCTIPOSIGLA",",oparms:[]}");
         setEventMetadata("VALID_DOCTIPONOME","{handler:'Valid_Doctiponome',iparms:[]");
         setEventMetadata("VALID_DOCTIPONOME",",oparms:[]}");
         setEventMetadata("VALID_DOCTIPOID","{handler:'Valid_Doctipoid',iparms:[]");
         setEventMetadata("VALID_DOCTIPOID",",oparms:[]}");
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
         Z504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         Z505DocTipoDelData = DateTime.MinValue;
         Z506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         Z507DocTipoDelUsuID = "";
         Z508DocTipoDelUsuNome = "";
         Z147DocTipoSigla = "";
         Z148DocTipoNome = "";
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
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A504DocTipoDelDataHora = (DateTime)(DateTime.MinValue);
         A505DocTipoDelData = DateTime.MinValue;
         A506DocTipoDelHora = (DateTime)(DateTime.MinValue);
         A507DocTipoDelUsuID = "";
         A508DocTipoDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode20 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000K4_A146DocTipoID = new int[1] ;
         T000K4_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000K4_n504DocTipoDelDataHora = new bool[] {false} ;
         T000K4_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         T000K4_n505DocTipoDelData = new bool[] {false} ;
         T000K4_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         T000K4_n506DocTipoDelHora = new bool[] {false} ;
         T000K4_A507DocTipoDelUsuID = new string[] {""} ;
         T000K4_n507DocTipoDelUsuID = new bool[] {false} ;
         T000K4_A508DocTipoDelUsuNome = new string[] {""} ;
         T000K4_n508DocTipoDelUsuNome = new bool[] {false} ;
         T000K4_A147DocTipoSigla = new string[] {""} ;
         T000K4_A148DocTipoNome = new string[] {""} ;
         T000K4_A219DocTipoAtivo = new bool[] {false} ;
         T000K4_A503DocTipoDel = new bool[] {false} ;
         T000K5_A147DocTipoSigla = new string[] {""} ;
         T000K6_A146DocTipoID = new int[1] ;
         T000K3_A146DocTipoID = new int[1] ;
         T000K3_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000K3_n504DocTipoDelDataHora = new bool[] {false} ;
         T000K3_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         T000K3_n505DocTipoDelData = new bool[] {false} ;
         T000K3_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         T000K3_n506DocTipoDelHora = new bool[] {false} ;
         T000K3_A507DocTipoDelUsuID = new string[] {""} ;
         T000K3_n507DocTipoDelUsuID = new bool[] {false} ;
         T000K3_A508DocTipoDelUsuNome = new string[] {""} ;
         T000K3_n508DocTipoDelUsuNome = new bool[] {false} ;
         T000K3_A147DocTipoSigla = new string[] {""} ;
         T000K3_A148DocTipoNome = new string[] {""} ;
         T000K3_A219DocTipoAtivo = new bool[] {false} ;
         T000K3_A503DocTipoDel = new bool[] {false} ;
         T000K7_A146DocTipoID = new int[1] ;
         T000K8_A146DocTipoID = new int[1] ;
         T000K2_A146DocTipoID = new int[1] ;
         T000K2_A504DocTipoDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000K2_n504DocTipoDelDataHora = new bool[] {false} ;
         T000K2_A505DocTipoDelData = new DateTime[] {DateTime.MinValue} ;
         T000K2_n505DocTipoDelData = new bool[] {false} ;
         T000K2_A506DocTipoDelHora = new DateTime[] {DateTime.MinValue} ;
         T000K2_n506DocTipoDelHora = new bool[] {false} ;
         T000K2_A507DocTipoDelUsuID = new string[] {""} ;
         T000K2_n507DocTipoDelUsuID = new bool[] {false} ;
         T000K2_A508DocTipoDelUsuNome = new string[] {""} ;
         T000K2_n508DocTipoDelUsuNome = new bool[] {false} ;
         T000K2_A147DocTipoSigla = new string[] {""} ;
         T000K2_A148DocTipoNome = new string[] {""} ;
         T000K2_A219DocTipoAtivo = new bool[] {false} ;
         T000K2_A503DocTipoDel = new bool[] {false} ;
         T000K10_A146DocTipoID = new int[1] ;
         T000K13_A289DocID = new Guid[] {Guid.Empty} ;
         T000K14_A146DocTipoID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000K15_A147DocTipoSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentotipo__default(),
            new Object[][] {
                new Object[] {
               T000K2_A146DocTipoID, T000K2_A504DocTipoDelDataHora, T000K2_n504DocTipoDelDataHora, T000K2_A505DocTipoDelData, T000K2_n505DocTipoDelData, T000K2_A506DocTipoDelHora, T000K2_n506DocTipoDelHora, T000K2_A507DocTipoDelUsuID, T000K2_n507DocTipoDelUsuID, T000K2_A508DocTipoDelUsuNome,
               T000K2_n508DocTipoDelUsuNome, T000K2_A147DocTipoSigla, T000K2_A148DocTipoNome, T000K2_A219DocTipoAtivo, T000K2_A503DocTipoDel
               }
               , new Object[] {
               T000K3_A146DocTipoID, T000K3_A504DocTipoDelDataHora, T000K3_n504DocTipoDelDataHora, T000K3_A505DocTipoDelData, T000K3_n505DocTipoDelData, T000K3_A506DocTipoDelHora, T000K3_n506DocTipoDelHora, T000K3_A507DocTipoDelUsuID, T000K3_n507DocTipoDelUsuID, T000K3_A508DocTipoDelUsuNome,
               T000K3_n508DocTipoDelUsuNome, T000K3_A147DocTipoSigla, T000K3_A148DocTipoNome, T000K3_A219DocTipoAtivo, T000K3_A503DocTipoDel
               }
               , new Object[] {
               T000K4_A146DocTipoID, T000K4_A504DocTipoDelDataHora, T000K4_n504DocTipoDelDataHora, T000K4_A505DocTipoDelData, T000K4_n505DocTipoDelData, T000K4_A506DocTipoDelHora, T000K4_n506DocTipoDelHora, T000K4_A507DocTipoDelUsuID, T000K4_n507DocTipoDelUsuID, T000K4_A508DocTipoDelUsuNome,
               T000K4_n508DocTipoDelUsuNome, T000K4_A147DocTipoSigla, T000K4_A148DocTipoNome, T000K4_A219DocTipoAtivo, T000K4_A503DocTipoDel
               }
               , new Object[] {
               T000K5_A147DocTipoSigla
               }
               , new Object[] {
               T000K6_A146DocTipoID
               }
               , new Object[] {
               T000K7_A146DocTipoID
               }
               , new Object[] {
               T000K8_A146DocTipoID
               }
               , new Object[] {
               }
               , new Object[] {
               T000K10_A146DocTipoID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000K13_A289DocID
               }
               , new Object[] {
               T000K14_A146DocTipoID
               }
               , new Object[] {
               T000K15_A147DocTipoSigla
               }
            }
         );
         Z219DocTipoAtivo = true;
         A219DocTipoAtivo = true;
         i219DocTipoAtivo = true;
         AV14Pgmname = "core.DocumentoTipo";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound20 ;
      private short GX_JID ;
      private short nIsDirty_20 ;
      private short gxajaxcallmode ;
      private int wcpOAV7DocTipoID ;
      private int Z146DocTipoID ;
      private int AV7DocTipoID ;
      private int trnEnded ;
      private int edtDocTipoSigla_Enabled ;
      private int edtDocTipoNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A146DocTipoID ;
      private int edtDocTipoID_Enabled ;
      private int edtDocTipoID_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z507DocTipoDelUsuID ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDocTipoSigla_Internalname ;
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
      private string edtDocTipoSigla_Jsonclick ;
      private string edtDocTipoNome_Internalname ;
      private string edtDocTipoNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocTipoID_Internalname ;
      private string edtDocTipoID_Jsonclick ;
      private string A507DocTipoDelUsuID ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode20 ;
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
      private DateTime Z504DocTipoDelDataHora ;
      private DateTime Z506DocTipoDelHora ;
      private DateTime A504DocTipoDelDataHora ;
      private DateTime A506DocTipoDelHora ;
      private DateTime Z505DocTipoDelData ;
      private DateTime A505DocTipoDelData ;
      private bool Z219DocTipoAtivo ;
      private bool Z503DocTipoDel ;
      private bool O503DocTipoDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n504DocTipoDelDataHora ;
      private bool n505DocTipoDelData ;
      private bool n506DocTipoDelHora ;
      private bool n507DocTipoDelUsuID ;
      private bool n508DocTipoDelUsuNome ;
      private bool A219DocTipoAtivo ;
      private bool A503DocTipoDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i219DocTipoAtivo ;
      private string Z508DocTipoDelUsuNome ;
      private string Z147DocTipoSigla ;
      private string Z148DocTipoNome ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private string A508DocTipoDelUsuNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000K4_A146DocTipoID ;
      private DateTime[] T000K4_A504DocTipoDelDataHora ;
      private bool[] T000K4_n504DocTipoDelDataHora ;
      private DateTime[] T000K4_A505DocTipoDelData ;
      private bool[] T000K4_n505DocTipoDelData ;
      private DateTime[] T000K4_A506DocTipoDelHora ;
      private bool[] T000K4_n506DocTipoDelHora ;
      private string[] T000K4_A507DocTipoDelUsuID ;
      private bool[] T000K4_n507DocTipoDelUsuID ;
      private string[] T000K4_A508DocTipoDelUsuNome ;
      private bool[] T000K4_n508DocTipoDelUsuNome ;
      private string[] T000K4_A147DocTipoSigla ;
      private string[] T000K4_A148DocTipoNome ;
      private bool[] T000K4_A219DocTipoAtivo ;
      private bool[] T000K4_A503DocTipoDel ;
      private string[] T000K5_A147DocTipoSigla ;
      private int[] T000K6_A146DocTipoID ;
      private int[] T000K3_A146DocTipoID ;
      private DateTime[] T000K3_A504DocTipoDelDataHora ;
      private bool[] T000K3_n504DocTipoDelDataHora ;
      private DateTime[] T000K3_A505DocTipoDelData ;
      private bool[] T000K3_n505DocTipoDelData ;
      private DateTime[] T000K3_A506DocTipoDelHora ;
      private bool[] T000K3_n506DocTipoDelHora ;
      private string[] T000K3_A507DocTipoDelUsuID ;
      private bool[] T000K3_n507DocTipoDelUsuID ;
      private string[] T000K3_A508DocTipoDelUsuNome ;
      private bool[] T000K3_n508DocTipoDelUsuNome ;
      private string[] T000K3_A147DocTipoSigla ;
      private string[] T000K3_A148DocTipoNome ;
      private bool[] T000K3_A219DocTipoAtivo ;
      private bool[] T000K3_A503DocTipoDel ;
      private int[] T000K7_A146DocTipoID ;
      private int[] T000K8_A146DocTipoID ;
      private int[] T000K2_A146DocTipoID ;
      private DateTime[] T000K2_A504DocTipoDelDataHora ;
      private bool[] T000K2_n504DocTipoDelDataHora ;
      private DateTime[] T000K2_A505DocTipoDelData ;
      private bool[] T000K2_n505DocTipoDelData ;
      private DateTime[] T000K2_A506DocTipoDelHora ;
      private bool[] T000K2_n506DocTipoDelHora ;
      private string[] T000K2_A507DocTipoDelUsuID ;
      private bool[] T000K2_n507DocTipoDelUsuID ;
      private string[] T000K2_A508DocTipoDelUsuNome ;
      private bool[] T000K2_n508DocTipoDelUsuNome ;
      private string[] T000K2_A147DocTipoSigla ;
      private string[] T000K2_A148DocTipoNome ;
      private bool[] T000K2_A219DocTipoAtivo ;
      private bool[] T000K2_A503DocTipoDel ;
      private int[] T000K10_A146DocTipoID ;
      private Guid[] T000K13_A289DocID ;
      private int[] T000K14_A146DocTipoID ;
      private string[] T000K15_A147DocTipoSigla ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class documentotipo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentotipo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
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
        Object[] prmT000K4;
        prmT000K4 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K5;
        prmT000K5 = new Object[] {
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K6;
        prmT000K6 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K3;
        prmT000K3 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K7;
        prmT000K7 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K8;
        prmT000K8 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K2;
        prmT000K2 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K9;
        prmT000K9 = new Object[] {
        new ParDef("DocTipoDelDataHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocTipoDelData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocTipoDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocTipoDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocTipoDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoNome",GXType.VarChar,80,0) ,
        new ParDef("DocTipoAtivo",GXType.Boolean,4,0) ,
        new ParDef("DocTipoDel",GXType.Boolean,4,0)
        };
        Object[] prmT000K10;
        prmT000K10 = new Object[] {
        };
        Object[] prmT000K11;
        prmT000K11 = new Object[] {
        new ParDef("DocTipoDelDataHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocTipoDelData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocTipoDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocTipoDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocTipoDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoNome",GXType.VarChar,80,0) ,
        new ParDef("DocTipoAtivo",GXType.Boolean,4,0) ,
        new ParDef("DocTipoDel",GXType.Boolean,4,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K12;
        prmT000K12 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K13;
        prmT000K13 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000K14;
        prmT000K14 = new Object[] {
        };
        Object[] prmT000K15;
        prmT000K15 = new Object[] {
        new ParDef("DocTipoSigla",GXType.VarChar,20,0) ,
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000K2", "SELECT DocTipoID, DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel FROM tb_documentotipo WHERE DocTipoID = :DocTipoID  FOR UPDATE OF tb_documentotipo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000K2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K3", "SELECT DocTipoID, DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K4", "SELECT TM1.DocTipoID, TM1.DocTipoDelDataHora, TM1.DocTipoDelData, TM1.DocTipoDelHora, TM1.DocTipoDelUsuID, TM1.DocTipoDelUsuNome, TM1.DocTipoSigla, TM1.DocTipoNome, TM1.DocTipoAtivo, TM1.DocTipoDel FROM tb_documentotipo TM1 WHERE TM1.DocTipoID = :DocTipoID ORDER BY TM1.DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K5", "SELECT DocTipoSigla FROM tb_documentotipo WHERE (DocTipoSigla = :DocTipoSigla) AND (Not ( DocTipoID = :DocTipoID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K6", "SELECT DocTipoID FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K7", "SELECT DocTipoID FROM tb_documentotipo WHERE ( DocTipoID > :DocTipoID) ORDER BY DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K8", "SELECT DocTipoID FROM tb_documentotipo WHERE ( DocTipoID < :DocTipoID) ORDER BY DocTipoID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K9", "SAVEPOINT gxupdate;INSERT INTO tb_documentotipo(DocTipoDelDataHora, DocTipoDelData, DocTipoDelHora, DocTipoDelUsuID, DocTipoDelUsuNome, DocTipoSigla, DocTipoNome, DocTipoAtivo, DocTipoDel) VALUES(:DocTipoDelDataHora, :DocTipoDelData, :DocTipoDelHora, :DocTipoDelUsuID, :DocTipoDelUsuNome, :DocTipoSigla, :DocTipoNome, :DocTipoAtivo, :DocTipoDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000K9)
           ,new CursorDef("T000K10", "SELECT currval('DocTipoID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K11", "SAVEPOINT gxupdate;UPDATE tb_documentotipo SET DocTipoDelDataHora=:DocTipoDelDataHora, DocTipoDelData=:DocTipoDelData, DocTipoDelHora=:DocTipoDelHora, DocTipoDelUsuID=:DocTipoDelUsuID, DocTipoDelUsuNome=:DocTipoDelUsuNome, DocTipoSigla=:DocTipoSigla, DocTipoNome=:DocTipoNome, DocTipoAtivo=:DocTipoAtivo, DocTipoDel=:DocTipoDel  WHERE DocTipoID = :DocTipoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000K11)
           ,new CursorDef("T000K12", "SAVEPOINT gxupdate;DELETE FROM tb_documentotipo  WHERE DocTipoID = :DocTipoID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000K12)
           ,new CursorDef("T000K13", "SELECT DocID FROM tb_documento WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000K14", "SELECT DocTipoID FROM tb_documentotipo ORDER BY DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000K15", "SELECT DocTipoSigla FROM tb_documentotipo WHERE (DocTipoSigla = :DocTipoSigla) AND (Not ( DocTipoID = :DocTipoID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000K15,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDate(3);
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
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
