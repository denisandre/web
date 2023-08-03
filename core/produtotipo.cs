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
   public class produtotipo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.produtotipo.aspx")), "core.produtotipo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.produtotipo.aspx")))) ;
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
                  AV7PrtID = (int)(Math.Round(NumberUtil.Val( GetPar( "PrtID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7PrtID", StringUtil.LTrimStr( (decimal)(AV7PrtID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PrtID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo de Produto", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPrtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public produtotipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produtotipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_PrtID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PrtID = aP1_PrtID;
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
            return "produtotipo_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrtSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrtSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrtSigla_Internalname, A212PrtSigla, StringUtil.RTrim( context.localUtil.Format( A212PrtSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrtSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrtSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ProdutoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrtNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrtNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrtNome_Internalname, A213PrtNome, StringUtil.RTrim( context.localUtil.Format( A213PrtNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrtNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrtNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ProdutoTipo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ProdutoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ProdutoTipo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtPrtID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A211PrtID), 11, 0, ",", "")), StringUtil.LTrim( ((edtPrtID_Enabled!=0) ? context.localUtil.Format( (decimal)(A211PrtID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A211PrtID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrtID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrtID_Visible, edtPrtID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\ProdutoTipo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrtAtivo_Internalname, StringUtil.BoolToStr( A214PrtAtivo), StringUtil.BoolToStr( A214PrtAtivo), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrtAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtPrtAtivo_Visible, edtPrtAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\ProdutoTipo.htm");
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
         E110R2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z211PrtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z211PrtID"), ",", "."), 18, MidpointRounding.ToEven));
               Z615PrtDelDataHora = context.localUtil.CToT( cgiGet( "Z615PrtDelDataHora"), 0);
               n615PrtDelDataHora = ((DateTime.MinValue==A615PrtDelDataHora) ? true : false);
               Z616PrtDelData = context.localUtil.CToT( cgiGet( "Z616PrtDelData"), 0);
               n616PrtDelData = ((DateTime.MinValue==A616PrtDelData) ? true : false);
               Z617PrtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z617PrtDelHora"), 0));
               n617PrtDelHora = ((DateTime.MinValue==A617PrtDelHora) ? true : false);
               Z618PrtDelUsuId = cgiGet( "Z618PrtDelUsuId");
               n618PrtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A618PrtDelUsuId)) ? true : false);
               Z619PrtDelUsuNome = cgiGet( "Z619PrtDelUsuNome");
               n619PrtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A619PrtDelUsuNome)) ? true : false);
               Z212PrtSigla = cgiGet( "Z212PrtSigla");
               Z213PrtNome = cgiGet( "Z213PrtNome");
               Z214PrtAtivo = StringUtil.StrToBool( cgiGet( "Z214PrtAtivo"));
               Z614PrtDel = StringUtil.StrToBool( cgiGet( "Z614PrtDel"));
               A615PrtDelDataHora = context.localUtil.CToT( cgiGet( "Z615PrtDelDataHora"), 0);
               n615PrtDelDataHora = false;
               n615PrtDelDataHora = ((DateTime.MinValue==A615PrtDelDataHora) ? true : false);
               A616PrtDelData = context.localUtil.CToT( cgiGet( "Z616PrtDelData"), 0);
               n616PrtDelData = false;
               n616PrtDelData = ((DateTime.MinValue==A616PrtDelData) ? true : false);
               A617PrtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z617PrtDelHora"), 0));
               n617PrtDelHora = false;
               n617PrtDelHora = ((DateTime.MinValue==A617PrtDelHora) ? true : false);
               A618PrtDelUsuId = cgiGet( "Z618PrtDelUsuId");
               n618PrtDelUsuId = false;
               n618PrtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A618PrtDelUsuId)) ? true : false);
               A619PrtDelUsuNome = cgiGet( "Z619PrtDelUsuNome");
               n619PrtDelUsuNome = false;
               n619PrtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A619PrtDelUsuNome)) ? true : false);
               A614PrtDel = StringUtil.StrToBool( cgiGet( "Z614PrtDel"));
               O614PrtDel = StringUtil.StrToBool( cgiGet( "O614PrtDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7PrtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vPRTID"), ",", "."), 18, MidpointRounding.ToEven));
               A614PrtDel = StringUtil.StrToBool( cgiGet( "PRTDEL"));
               A615PrtDelDataHora = context.localUtil.CToT( cgiGet( "PRTDELDATAHORA"), 0);
               n615PrtDelDataHora = ((DateTime.MinValue==A615PrtDelDataHora) ? true : false);
               A616PrtDelData = context.localUtil.CToT( cgiGet( "PRTDELDATA"), 0);
               n616PrtDelData = ((DateTime.MinValue==A616PrtDelData) ? true : false);
               A617PrtDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "PRTDELHORA"), 0));
               n617PrtDelHora = ((DateTime.MinValue==A617PrtDelHora) ? true : false);
               A618PrtDelUsuId = cgiGet( "PRTDELUSUID");
               n618PrtDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A618PrtDelUsuId)) ? true : false);
               A619PrtDelUsuNome = cgiGet( "PRTDELUSUNOME");
               n619PrtDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A619PrtDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
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
               A212PrtSigla = cgiGet( edtPrtSigla_Internalname);
               AssignAttri("", false, "A212PrtSigla", A212PrtSigla);
               A213PrtNome = StringUtil.Upper( cgiGet( edtPrtNome_Internalname));
               AssignAttri("", false, "A213PrtNome", A213PrtNome);
               A211PrtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPrtID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
               A214PrtAtivo = StringUtil.StrToBool( cgiGet( edtPrtAtivo_Internalname));
               AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ProdutoTipo");
               A211PrtID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPrtID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
               forbiddenHiddens.Add("PrtID", context.localUtil.Format( (decimal)(A211PrtID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("PrtDel", StringUtil.BoolToStr( A614PrtDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A211PrtID != Z211PrtID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\produtotipo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A211PrtID = (int)(Math.Round(NumberUtil.Val( GetPar( "PrtID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
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
                     sMode27 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode27;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound27 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0R0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRTID");
                        AnyError = 1;
                        GX_FocusControl = edtPrtID_Internalname;
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
                           E110R2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120R2 ();
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
            E120R2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0R27( ) ;
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
            DisableAttributes0R27( ) ;
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

      protected void CONFIRM_0R0( )
      {
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0R27( ) ;
            }
            else
            {
               CheckExtendedTable0R27( ) ;
               CloseExtendedTableCursors0R27( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0R0( )
      {
      }

      protected void E110R2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtPrtID_Visible = 0;
         AssignProp("", false, edtPrtID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrtID_Visible), 5, 0), true);
         edtPrtAtivo_Visible = 0;
         AssignProp("", false, edtPrtAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrtAtivo_Visible), 5, 0), true);
      }

      protected void E120R2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.produtotipoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0R27( short GX_JID )
      {
         if ( ( GX_JID == 13 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z615PrtDelDataHora = T000R3_A615PrtDelDataHora[0];
               Z616PrtDelData = T000R3_A616PrtDelData[0];
               Z617PrtDelHora = T000R3_A617PrtDelHora[0];
               Z618PrtDelUsuId = T000R3_A618PrtDelUsuId[0];
               Z619PrtDelUsuNome = T000R3_A619PrtDelUsuNome[0];
               Z212PrtSigla = T000R3_A212PrtSigla[0];
               Z213PrtNome = T000R3_A213PrtNome[0];
               Z214PrtAtivo = T000R3_A214PrtAtivo[0];
               Z614PrtDel = T000R3_A614PrtDel[0];
            }
            else
            {
               Z615PrtDelDataHora = A615PrtDelDataHora;
               Z616PrtDelData = A616PrtDelData;
               Z617PrtDelHora = A617PrtDelHora;
               Z618PrtDelUsuId = A618PrtDelUsuId;
               Z619PrtDelUsuNome = A619PrtDelUsuNome;
               Z212PrtSigla = A212PrtSigla;
               Z213PrtNome = A213PrtNome;
               Z214PrtAtivo = A214PrtAtivo;
               Z614PrtDel = A614PrtDel;
            }
         }
         if ( GX_JID == -13 )
         {
            Z211PrtID = A211PrtID;
            Z615PrtDelDataHora = A615PrtDelDataHora;
            Z616PrtDelData = A616PrtDelData;
            Z617PrtDelHora = A617PrtDelHora;
            Z618PrtDelUsuId = A618PrtDelUsuId;
            Z619PrtDelUsuNome = A619PrtDelUsuNome;
            Z212PrtSigla = A212PrtSigla;
            Z213PrtNome = A213PrtNome;
            Z214PrtAtivo = A214PrtAtivo;
            Z614PrtDel = A614PrtDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtPrtID_Enabled = 0;
         AssignProp("", false, edtPrtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV14Pgmname = "core.ProdutoTipo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         edtPrtID_Enabled = 0;
         AssignProp("", false, edtPrtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtID_Enabled), 5, 0), true);
         if ( ! (0==AV7PrtID) )
         {
            A211PrtID = AV7PrtID;
            AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
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
         if ( IsIns( )  && (false==A214PrtAtivo) && ( Gx_BScreen == 0 ) )
         {
            A214PrtAtivo = true;
            AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
         }
      }

      protected void Load0R27( )
      {
         /* Using cursor T000R4 */
         pr_default.execute(2, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound27 = 1;
            A615PrtDelDataHora = T000R4_A615PrtDelDataHora[0];
            n615PrtDelDataHora = T000R4_n615PrtDelDataHora[0];
            A616PrtDelData = T000R4_A616PrtDelData[0];
            n616PrtDelData = T000R4_n616PrtDelData[0];
            A617PrtDelHora = T000R4_A617PrtDelHora[0];
            n617PrtDelHora = T000R4_n617PrtDelHora[0];
            A618PrtDelUsuId = T000R4_A618PrtDelUsuId[0];
            n618PrtDelUsuId = T000R4_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = T000R4_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = T000R4_n619PrtDelUsuNome[0];
            A212PrtSigla = T000R4_A212PrtSigla[0];
            AssignAttri("", false, "A212PrtSigla", A212PrtSigla);
            A213PrtNome = T000R4_A213PrtNome[0];
            AssignAttri("", false, "A213PrtNome", A213PrtNome);
            A214PrtAtivo = T000R4_A214PrtAtivo[0];
            AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
            A614PrtDel = T000R4_A614PrtDel[0];
            ZM0R27( -13) ;
         }
         pr_default.close(2);
         OnLoadActions0R27( ) ;
      }

      protected void OnLoadActions0R27( )
      {
      }

      protected void CheckExtendedTable0R27( )
      {
         nIsDirty_27 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0R27( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0R27( )
      {
         /* Using cursor T000R5 */
         pr_default.execute(3, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound27 = 1;
         }
         else
         {
            RcdFound27 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000R3 */
         pr_default.execute(1, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0R27( 13) ;
            RcdFound27 = 1;
            A211PrtID = T000R3_A211PrtID[0];
            AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
            A615PrtDelDataHora = T000R3_A615PrtDelDataHora[0];
            n615PrtDelDataHora = T000R3_n615PrtDelDataHora[0];
            A616PrtDelData = T000R3_A616PrtDelData[0];
            n616PrtDelData = T000R3_n616PrtDelData[0];
            A617PrtDelHora = T000R3_A617PrtDelHora[0];
            n617PrtDelHora = T000R3_n617PrtDelHora[0];
            A618PrtDelUsuId = T000R3_A618PrtDelUsuId[0];
            n618PrtDelUsuId = T000R3_n618PrtDelUsuId[0];
            A619PrtDelUsuNome = T000R3_A619PrtDelUsuNome[0];
            n619PrtDelUsuNome = T000R3_n619PrtDelUsuNome[0];
            A212PrtSigla = T000R3_A212PrtSigla[0];
            AssignAttri("", false, "A212PrtSigla", A212PrtSigla);
            A213PrtNome = T000R3_A213PrtNome[0];
            AssignAttri("", false, "A213PrtNome", A213PrtNome);
            A214PrtAtivo = T000R3_A214PrtAtivo[0];
            AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
            A614PrtDel = T000R3_A614PrtDel[0];
            O614PrtDel = A614PrtDel;
            AssignAttri("", false, "A614PrtDel", A614PrtDel);
            Z211PrtID = A211PrtID;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0R27( ) ;
            if ( AnyError == 1 )
            {
               RcdFound27 = 0;
               InitializeNonKey0R27( ) ;
            }
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound27 = 0;
            InitializeNonKey0R27( ) ;
            sMode27 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode27;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0R27( ) ;
         if ( RcdFound27 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound27 = 0;
         /* Using cursor T000R6 */
         pr_default.execute(4, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A211PrtID[0] < A211PrtID ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( T000R6_A211PrtID[0] > A211PrtID ) ) )
            {
               A211PrtID = T000R6_A211PrtID[0];
               AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound27 = 0;
         /* Using cursor T000R7 */
         pr_default.execute(5, new Object[] {A211PrtID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A211PrtID[0] > A211PrtID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000R7_A211PrtID[0] < A211PrtID ) ) )
            {
               A211PrtID = T000R7_A211PrtID[0];
               AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
               RcdFound27 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0R27( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPrtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0R27( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound27 == 1 )
            {
               if ( A211PrtID != Z211PrtID )
               {
                  A211PrtID = Z211PrtID;
                  AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRTID");
                  AnyError = 1;
                  GX_FocusControl = edtPrtID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPrtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0R27( ) ;
                  GX_FocusControl = edtPrtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A211PrtID != Z211PrtID )
               {
                  /* Insert record */
                  GX_FocusControl = edtPrtSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0R27( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRTID");
                     AnyError = 1;
                     GX_FocusControl = edtPrtID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPrtSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0R27( ) ;
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
         if ( A211PrtID != Z211PrtID )
         {
            A211PrtID = Z211PrtID;
            AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRTID");
            AnyError = 1;
            GX_FocusControl = edtPrtID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPrtSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0R27( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000R2 */
            pr_default.execute(0, new Object[] {A211PrtID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produtotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z615PrtDelDataHora != T000R2_A615PrtDelDataHora[0] ) || ( Z616PrtDelData != T000R2_A616PrtDelData[0] ) || ( Z617PrtDelHora != T000R2_A617PrtDelHora[0] ) || ( StringUtil.StrCmp(Z618PrtDelUsuId, T000R2_A618PrtDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z619PrtDelUsuNome, T000R2_A619PrtDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z212PrtSigla, T000R2_A212PrtSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z213PrtNome, T000R2_A213PrtNome[0]) != 0 ) || ( Z214PrtAtivo != T000R2_A214PrtAtivo[0] ) || ( Z614PrtDel != T000R2_A614PrtDel[0] ) )
            {
               if ( Z615PrtDelDataHora != T000R2_A615PrtDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z615PrtDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A615PrtDelDataHora[0]);
               }
               if ( Z616PrtDelData != T000R2_A616PrtDelData[0] )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDelData");
                  GXUtil.WriteLogRaw("Old: ",Z616PrtDelData);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A616PrtDelData[0]);
               }
               if ( Z617PrtDelHora != T000R2_A617PrtDelHora[0] )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z617PrtDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A617PrtDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z618PrtDelUsuId, T000R2_A618PrtDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z618PrtDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A618PrtDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z619PrtDelUsuNome, T000R2_A619PrtDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z619PrtDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A619PrtDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z212PrtSigla, T000R2_A212PrtSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtSigla");
                  GXUtil.WriteLogRaw("Old: ",Z212PrtSigla);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A212PrtSigla[0]);
               }
               if ( StringUtil.StrCmp(Z213PrtNome, T000R2_A213PrtNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtNome");
                  GXUtil.WriteLogRaw("Old: ",Z213PrtNome);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A213PrtNome[0]);
               }
               if ( Z214PrtAtivo != T000R2_A214PrtAtivo[0] )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z214PrtAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A214PrtAtivo[0]);
               }
               if ( Z614PrtDel != T000R2_A614PrtDel[0] )
               {
                  GXUtil.WriteLog("core.produtotipo:[seudo value changed for attri]"+"PrtDel");
                  GXUtil.WriteLogRaw("Old: ",Z614PrtDel);
                  GXUtil.WriteLogRaw("Current: ",T000R2_A614PrtDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_produtotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0R27( )
      {
         if ( ! IsAuthorized("produtotipo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0R27( 0) ;
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R8 */
                     pr_default.execute(6, new Object[] {n615PrtDelDataHora, A615PrtDelDataHora, n616PrtDelData, A616PrtDelData, n617PrtDelHora, A617PrtDelHora, n618PrtDelUsuId, A618PrtDelUsuId, n619PrtDelUsuNome, A619PrtDelUsuNome, A212PrtSigla, A213PrtNome, A214PrtAtivo, A614PrtDel});
                     pr_default.close(6);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000R9 */
                     pr_default.execute(7);
                     A211PrtID = T000R9_A211PrtID[0];
                     AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0R0( ) ;
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
               Load0R27( ) ;
            }
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void Update0R27( )
      {
         if ( ! IsAuthorized("produtotipo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0R27( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0R27( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000R10 */
                     pr_default.execute(8, new Object[] {n615PrtDelDataHora, A615PrtDelDataHora, n616PrtDelData, A616PrtDelData, n617PrtDelHora, A617PrtDelHora, n618PrtDelUsuId, A618PrtDelUsuId, n619PrtDelUsuNome, A619PrtDelUsuNome, A212PrtSigla, A213PrtNome, A214PrtAtivo, A614PrtDel, A211PrtID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produtotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0R27( ) ;
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
            EndLevel0R27( ) ;
         }
         CloseExtendedTableCursors0R27( ) ;
      }

      protected void DeferredUpdate0R27( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("produtotipo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0R27( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0R27( ) ;
            AfterConfirm0R27( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0R27( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000R11 */
                  pr_default.execute(9, new Object[] {A211PrtID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("tb_produtotipo");
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
         sMode27 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0R27( ) ;
         Gx_mode = sMode27;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0R27( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000R12 */
            pr_default.execute(10, new Object[] {A211PrtID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
         }
      }

      protected void EndLevel0R27( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0R27( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.produtotipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0R0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.produtotipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0R27( )
      {
         /* Scan By routine */
         /* Using cursor T000R13 */
         pr_default.execute(11);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound27 = 1;
            A211PrtID = T000R13_A211PrtID[0];
            AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0R27( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound27 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound27 = 1;
            A211PrtID = T000R13_A211PrtID[0];
            AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
         }
      }

      protected void ScanEnd0R27( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0R27( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0R27( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0R27( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A615PrtDelDataHora = DateTimeUtil.NowMS( context);
            n615PrtDelDataHora = false;
            AssignAttri("", false, "A615PrtDelDataHora", context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A618PrtDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n618PrtDelUsuId = false;
            AssignAttri("", false, "A618PrtDelUsuId", A618PrtDelUsuId);
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A619PrtDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n619PrtDelUsuNome = false;
            AssignAttri("", false, "A619PrtDelUsuNome", A619PrtDelUsuNome);
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A616PrtDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A615PrtDelDataHora) ) ;
            n616PrtDelData = false;
            AssignAttri("", false, "A616PrtDelData", context.localUtil.TToC( A616PrtDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A614PrtDel && ( O614PrtDel != A614PrtDel ) )
         {
            A617PrtDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A615PrtDelDataHora));
            n617PrtDelHora = false;
            AssignAttri("", false, "A617PrtDelHora", context.localUtil.TToC( A617PrtDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0R27( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
      }

      protected void BeforeComplete0R27( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0R27( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0R27( )
      {
         edtPrtSigla_Enabled = 0;
         AssignProp("", false, edtPrtSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtSigla_Enabled), 5, 0), true);
         edtPrtNome_Enabled = 0;
         AssignProp("", false, edtPrtNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtNome_Enabled), 5, 0), true);
         edtPrtID_Enabled = 0;
         AssignProp("", false, edtPrtID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtID_Enabled), 5, 0), true);
         edtPrtAtivo_Enabled = 0;
         AssignProp("", false, edtPrtAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrtAtivo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0R27( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0R0( )
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
         GXEncryptionTmp = "core.produtotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PrtID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.produtotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ProdutoTipo");
         forbiddenHiddens.Add("PrtID", context.localUtil.Format( (decimal)(A211PrtID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("PrtDel", StringUtil.BoolToStr( A614PrtDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\produtotipo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z211PrtID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z211PrtID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z615PrtDelDataHora", context.localUtil.TToC( Z615PrtDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z616PrtDelData", context.localUtil.TToC( Z616PrtDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z617PrtDelHora", context.localUtil.TToC( Z617PrtDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z618PrtDelUsuId", StringUtil.RTrim( Z618PrtDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z619PrtDelUsuNome", Z619PrtDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z212PrtSigla", Z212PrtSigla);
         GxWebStd.gx_hidden_field( context, "Z213PrtNome", Z213PrtNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z214PrtAtivo", Z214PrtAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z614PrtDel", Z614PrtDel);
         GxWebStd.gx_boolean_hidden_field( context, "O614PrtDel", O614PrtDel);
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
         GxWebStd.gx_hidden_field( context, "vPRTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7PrtID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vPRTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7PrtID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "PRTDEL", A614PrtDel);
         GxWebStd.gx_hidden_field( context, "PRTDELDATAHORA", context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRTDELDATA", context.localUtil.TToC( A616PrtDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRTDELHORA", context.localUtil.TToC( A617PrtDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRTDELUSUID", StringUtil.RTrim( A618PrtDelUsuId));
         GxWebStd.gx_hidden_field( context, "PRTDELUSUNOME", A619PrtDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         GXEncryptionTmp = "core.produtotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7PrtID,9,0));
         return formatLink("core.produtotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ProdutoTipo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Produto" ;
      }

      protected void InitializeNonKey0R27( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         n615PrtDelDataHora = false;
         AssignAttri("", false, "A615PrtDelDataHora", context.localUtil.TToC( A615PrtDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         n616PrtDelData = false;
         AssignAttri("", false, "A616PrtDelData", context.localUtil.TToC( A616PrtDelData, 10, 5, 0, 3, "/", ":", " "));
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         n617PrtDelHora = false;
         AssignAttri("", false, "A617PrtDelHora", context.localUtil.TToC( A617PrtDelHora, 0, 5, 0, 3, "/", ":", " "));
         A618PrtDelUsuId = "";
         n618PrtDelUsuId = false;
         AssignAttri("", false, "A618PrtDelUsuId", A618PrtDelUsuId);
         A619PrtDelUsuNome = "";
         n619PrtDelUsuNome = false;
         AssignAttri("", false, "A619PrtDelUsuNome", A619PrtDelUsuNome);
         A212PrtSigla = "";
         AssignAttri("", false, "A212PrtSigla", A212PrtSigla);
         A213PrtNome = "";
         AssignAttri("", false, "A213PrtNome", A213PrtNome);
         A614PrtDel = false;
         AssignAttri("", false, "A614PrtDel", A614PrtDel);
         A214PrtAtivo = true;
         AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
         O614PrtDel = A614PrtDel;
         AssignAttri("", false, "A614PrtDel", A614PrtDel);
         Z615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         Z616PrtDelData = (DateTime)(DateTime.MinValue);
         Z617PrtDelHora = (DateTime)(DateTime.MinValue);
         Z618PrtDelUsuId = "";
         Z619PrtDelUsuNome = "";
         Z212PrtSigla = "";
         Z213PrtNome = "";
         Z214PrtAtivo = false;
         Z614PrtDel = false;
      }

      protected void InitAll0R27( )
      {
         A211PrtID = 0;
         AssignAttri("", false, "A211PrtID", StringUtil.LTrimStr( (decimal)(A211PrtID), 9, 0));
         InitializeNonKey0R27( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A214PrtAtivo = i214PrtAtivo;
         AssignAttri("", false, "A214PrtAtivo", A214PrtAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828131345", true, true);
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
         context.AddJavascriptSource("core/produtotipo.js", "?2023828131347", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPrtSigla_Internalname = "PRTSIGLA";
         edtPrtNome_Internalname = "PRTNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtPrtID_Internalname = "PRTID";
         edtPrtAtivo_Internalname = "PRTATIVO";
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
         Form.Caption = "Tipo de Produto";
         edtPrtAtivo_Jsonclick = "";
         edtPrtAtivo_Enabled = 1;
         edtPrtAtivo_Visible = 1;
         edtPrtID_Jsonclick = "";
         edtPrtID_Enabled = 0;
         edtPrtID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPrtNome_Jsonclick = "";
         edtPrtNome_Enabled = 1;
         edtPrtSigla_Jsonclick = "";
         edtPrtSigla_Enabled = 1;
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

      protected void XC_9_0R27( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                int A211PrtID ,
                                string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
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

      protected void XC_10_0R27( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A211PrtID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "Y", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
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

      protected void XC_11_0R27( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A211PrtID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
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

      protected void XC_12_0R27( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A211PrtID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditprodutotipo(context ).execute(  "N", ref  AV13AuditingObject,  A211PrtID,  Gx_mode) ;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PrtID',fld:'vPRTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PrtID',fld:'vPRTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A211PrtID',fld:'PRTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A614PrtDel',fld:'PRTDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120R2',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRTID","{handler:'Valid_Prtid',iparms:[]");
         setEventMetadata("VALID_PRTID",",oparms:[]}");
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
         Z615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         Z616PrtDelData = (DateTime)(DateTime.MinValue);
         Z617PrtDelHora = (DateTime)(DateTime.MinValue);
         Z618PrtDelUsuId = "";
         Z619PrtDelUsuNome = "";
         Z212PrtSigla = "";
         Z213PrtNome = "";
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
         A212PrtSigla = "";
         A213PrtNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A615PrtDelDataHora = (DateTime)(DateTime.MinValue);
         A616PrtDelData = (DateTime)(DateTime.MinValue);
         A617PrtDelHora = (DateTime)(DateTime.MinValue);
         A618PrtDelUsuId = "";
         A619PrtDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode27 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000R4_A211PrtID = new int[1] ;
         T000R4_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000R4_n615PrtDelDataHora = new bool[] {false} ;
         T000R4_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         T000R4_n616PrtDelData = new bool[] {false} ;
         T000R4_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000R4_n617PrtDelHora = new bool[] {false} ;
         T000R4_A618PrtDelUsuId = new string[] {""} ;
         T000R4_n618PrtDelUsuId = new bool[] {false} ;
         T000R4_A619PrtDelUsuNome = new string[] {""} ;
         T000R4_n619PrtDelUsuNome = new bool[] {false} ;
         T000R4_A212PrtSigla = new string[] {""} ;
         T000R4_A213PrtNome = new string[] {""} ;
         T000R4_A214PrtAtivo = new bool[] {false} ;
         T000R4_A614PrtDel = new bool[] {false} ;
         T000R5_A211PrtID = new int[1] ;
         T000R3_A211PrtID = new int[1] ;
         T000R3_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000R3_n615PrtDelDataHora = new bool[] {false} ;
         T000R3_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         T000R3_n616PrtDelData = new bool[] {false} ;
         T000R3_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000R3_n617PrtDelHora = new bool[] {false} ;
         T000R3_A618PrtDelUsuId = new string[] {""} ;
         T000R3_n618PrtDelUsuId = new bool[] {false} ;
         T000R3_A619PrtDelUsuNome = new string[] {""} ;
         T000R3_n619PrtDelUsuNome = new bool[] {false} ;
         T000R3_A212PrtSigla = new string[] {""} ;
         T000R3_A213PrtNome = new string[] {""} ;
         T000R3_A214PrtAtivo = new bool[] {false} ;
         T000R3_A614PrtDel = new bool[] {false} ;
         T000R6_A211PrtID = new int[1] ;
         T000R7_A211PrtID = new int[1] ;
         T000R2_A211PrtID = new int[1] ;
         T000R2_A615PrtDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000R2_n615PrtDelDataHora = new bool[] {false} ;
         T000R2_A616PrtDelData = new DateTime[] {DateTime.MinValue} ;
         T000R2_n616PrtDelData = new bool[] {false} ;
         T000R2_A617PrtDelHora = new DateTime[] {DateTime.MinValue} ;
         T000R2_n617PrtDelHora = new bool[] {false} ;
         T000R2_A618PrtDelUsuId = new string[] {""} ;
         T000R2_n618PrtDelUsuId = new bool[] {false} ;
         T000R2_A619PrtDelUsuNome = new string[] {""} ;
         T000R2_n619PrtDelUsuNome = new bool[] {false} ;
         T000R2_A212PrtSigla = new string[] {""} ;
         T000R2_A213PrtNome = new string[] {""} ;
         T000R2_A214PrtAtivo = new bool[] {false} ;
         T000R2_A614PrtDel = new bool[] {false} ;
         T000R9_A211PrtID = new int[1] ;
         T000R12_A220PrdID = new Guid[] {Guid.Empty} ;
         T000R13_A211PrtID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produtotipo__default(),
            new Object[][] {
                new Object[] {
               T000R2_A211PrtID, T000R2_A615PrtDelDataHora, T000R2_n615PrtDelDataHora, T000R2_A616PrtDelData, T000R2_n616PrtDelData, T000R2_A617PrtDelHora, T000R2_n617PrtDelHora, T000R2_A618PrtDelUsuId, T000R2_n618PrtDelUsuId, T000R2_A619PrtDelUsuNome,
               T000R2_n619PrtDelUsuNome, T000R2_A212PrtSigla, T000R2_A213PrtNome, T000R2_A214PrtAtivo, T000R2_A614PrtDel
               }
               , new Object[] {
               T000R3_A211PrtID, T000R3_A615PrtDelDataHora, T000R3_n615PrtDelDataHora, T000R3_A616PrtDelData, T000R3_n616PrtDelData, T000R3_A617PrtDelHora, T000R3_n617PrtDelHora, T000R3_A618PrtDelUsuId, T000R3_n618PrtDelUsuId, T000R3_A619PrtDelUsuNome,
               T000R3_n619PrtDelUsuNome, T000R3_A212PrtSigla, T000R3_A213PrtNome, T000R3_A214PrtAtivo, T000R3_A614PrtDel
               }
               , new Object[] {
               T000R4_A211PrtID, T000R4_A615PrtDelDataHora, T000R4_n615PrtDelDataHora, T000R4_A616PrtDelData, T000R4_n616PrtDelData, T000R4_A617PrtDelHora, T000R4_n617PrtDelHora, T000R4_A618PrtDelUsuId, T000R4_n618PrtDelUsuId, T000R4_A619PrtDelUsuNome,
               T000R4_n619PrtDelUsuNome, T000R4_A212PrtSigla, T000R4_A213PrtNome, T000R4_A214PrtAtivo, T000R4_A614PrtDel
               }
               , new Object[] {
               T000R5_A211PrtID
               }
               , new Object[] {
               T000R6_A211PrtID
               }
               , new Object[] {
               T000R7_A211PrtID
               }
               , new Object[] {
               }
               , new Object[] {
               T000R9_A211PrtID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000R12_A220PrdID
               }
               , new Object[] {
               T000R13_A211PrtID
               }
            }
         );
         Z214PrtAtivo = true;
         A214PrtAtivo = true;
         i214PrtAtivo = true;
         AV14Pgmname = "core.ProdutoTipo";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound27 ;
      private short GX_JID ;
      private short nIsDirty_27 ;
      private short gxajaxcallmode ;
      private int wcpOAV7PrtID ;
      private int Z211PrtID ;
      private int AV7PrtID ;
      private int trnEnded ;
      private int edtPrtSigla_Enabled ;
      private int edtPrtNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A211PrtID ;
      private int edtPrtID_Enabled ;
      private int edtPrtID_Visible ;
      private int edtPrtAtivo_Visible ;
      private int edtPrtAtivo_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z618PrtDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPrtSigla_Internalname ;
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
      private string edtPrtSigla_Jsonclick ;
      private string edtPrtNome_Internalname ;
      private string edtPrtNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtPrtID_Internalname ;
      private string edtPrtID_Jsonclick ;
      private string edtPrtAtivo_Internalname ;
      private string edtPrtAtivo_Jsonclick ;
      private string A618PrtDelUsuId ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode27 ;
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
      private DateTime Z615PrtDelDataHora ;
      private DateTime Z616PrtDelData ;
      private DateTime Z617PrtDelHora ;
      private DateTime A615PrtDelDataHora ;
      private DateTime A616PrtDelData ;
      private DateTime A617PrtDelHora ;
      private bool Z214PrtAtivo ;
      private bool Z614PrtDel ;
      private bool O614PrtDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A214PrtAtivo ;
      private bool n615PrtDelDataHora ;
      private bool n616PrtDelData ;
      private bool n617PrtDelHora ;
      private bool n618PrtDelUsuId ;
      private bool n619PrtDelUsuNome ;
      private bool A614PrtDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i214PrtAtivo ;
      private string Z619PrtDelUsuNome ;
      private string Z212PrtSigla ;
      private string Z213PrtNome ;
      private string A212PrtSigla ;
      private string A213PrtNome ;
      private string A619PrtDelUsuNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000R4_A211PrtID ;
      private DateTime[] T000R4_A615PrtDelDataHora ;
      private bool[] T000R4_n615PrtDelDataHora ;
      private DateTime[] T000R4_A616PrtDelData ;
      private bool[] T000R4_n616PrtDelData ;
      private DateTime[] T000R4_A617PrtDelHora ;
      private bool[] T000R4_n617PrtDelHora ;
      private string[] T000R4_A618PrtDelUsuId ;
      private bool[] T000R4_n618PrtDelUsuId ;
      private string[] T000R4_A619PrtDelUsuNome ;
      private bool[] T000R4_n619PrtDelUsuNome ;
      private string[] T000R4_A212PrtSigla ;
      private string[] T000R4_A213PrtNome ;
      private bool[] T000R4_A214PrtAtivo ;
      private bool[] T000R4_A614PrtDel ;
      private int[] T000R5_A211PrtID ;
      private int[] T000R3_A211PrtID ;
      private DateTime[] T000R3_A615PrtDelDataHora ;
      private bool[] T000R3_n615PrtDelDataHora ;
      private DateTime[] T000R3_A616PrtDelData ;
      private bool[] T000R3_n616PrtDelData ;
      private DateTime[] T000R3_A617PrtDelHora ;
      private bool[] T000R3_n617PrtDelHora ;
      private string[] T000R3_A618PrtDelUsuId ;
      private bool[] T000R3_n618PrtDelUsuId ;
      private string[] T000R3_A619PrtDelUsuNome ;
      private bool[] T000R3_n619PrtDelUsuNome ;
      private string[] T000R3_A212PrtSigla ;
      private string[] T000R3_A213PrtNome ;
      private bool[] T000R3_A214PrtAtivo ;
      private bool[] T000R3_A614PrtDel ;
      private int[] T000R6_A211PrtID ;
      private int[] T000R7_A211PrtID ;
      private int[] T000R2_A211PrtID ;
      private DateTime[] T000R2_A615PrtDelDataHora ;
      private bool[] T000R2_n615PrtDelDataHora ;
      private DateTime[] T000R2_A616PrtDelData ;
      private bool[] T000R2_n616PrtDelData ;
      private DateTime[] T000R2_A617PrtDelHora ;
      private bool[] T000R2_n617PrtDelHora ;
      private string[] T000R2_A618PrtDelUsuId ;
      private bool[] T000R2_n618PrtDelUsuId ;
      private string[] T000R2_A619PrtDelUsuNome ;
      private bool[] T000R2_n619PrtDelUsuNome ;
      private string[] T000R2_A212PrtSigla ;
      private string[] T000R2_A213PrtNome ;
      private bool[] T000R2_A214PrtAtivo ;
      private bool[] T000R2_A614PrtDel ;
      private int[] T000R9_A211PrtID ;
      private Guid[] T000R12_A220PrdID ;
      private int[] T000R13_A211PrtID ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class produtotipo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class produtotipo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000R4;
        prmT000R4 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R5;
        prmT000R5 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R3;
        prmT000R3 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R6;
        prmT000R6 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R7;
        prmT000R7 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R2;
        prmT000R2 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R8;
        prmT000R8 = new Object[] {
        new ParDef("PrtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrtSigla",GXType.VarChar,20,0) ,
        new ParDef("PrtNome",GXType.VarChar,80,0) ,
        new ParDef("PrtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrtDel",GXType.Boolean,4,0)
        };
        Object[] prmT000R9;
        prmT000R9 = new Object[] {
        };
        Object[] prmT000R10;
        prmT000R10 = new Object[] {
        new ParDef("PrtDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrtDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrtDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrtDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrtDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrtSigla",GXType.VarChar,20,0) ,
        new ParDef("PrtNome",GXType.VarChar,80,0) ,
        new ParDef("PrtAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrtDel",GXType.Boolean,4,0) ,
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R11;
        prmT000R11 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R12;
        prmT000R12 = new Object[] {
        new ParDef("PrtID",GXType.Int32,9,0)
        };
        Object[] prmT000R13;
        prmT000R13 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000R2", "SELECT PrtID, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel FROM tb_produtotipo WHERE PrtID = :PrtID  FOR UPDATE OF tb_produtotipo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000R2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R3", "SELECT PrtID, PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel FROM tb_produtotipo WHERE PrtID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R4", "SELECT TM1.PrtID, TM1.PrtDelDataHora, TM1.PrtDelData, TM1.PrtDelHora, TM1.PrtDelUsuId, TM1.PrtDelUsuNome, TM1.PrtSigla, TM1.PrtNome, TM1.PrtAtivo, TM1.PrtDel FROM tb_produtotipo TM1 WHERE TM1.PrtID = :PrtID ORDER BY TM1.PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R5", "SELECT PrtID FROM tb_produtotipo WHERE PrtID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R6", "SELECT PrtID FROM tb_produtotipo WHERE ( PrtID > :PrtID) ORDER BY PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R7", "SELECT PrtID FROM tb_produtotipo WHERE ( PrtID < :PrtID) ORDER BY PrtID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R8", "SAVEPOINT gxupdate;INSERT INTO tb_produtotipo(PrtDelDataHora, PrtDelData, PrtDelHora, PrtDelUsuId, PrtDelUsuNome, PrtSigla, PrtNome, PrtAtivo, PrtDel) VALUES(:PrtDelDataHora, :PrtDelData, :PrtDelHora, :PrtDelUsuId, :PrtDelUsuNome, :PrtSigla, :PrtNome, :PrtAtivo, :PrtDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000R8)
           ,new CursorDef("T000R9", "SELECT currval('PrtID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000R10", "SAVEPOINT gxupdate;UPDATE tb_produtotipo SET PrtDelDataHora=:PrtDelDataHora, PrtDelData=:PrtDelData, PrtDelHora=:PrtDelHora, PrtDelUsuId=:PrtDelUsuId, PrtDelUsuNome=:PrtDelUsuNome, PrtSigla=:PrtSigla, PrtNome=:PrtNome, PrtAtivo=:PrtAtivo, PrtDel=:PrtDel  WHERE PrtID = :PrtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R10)
           ,new CursorDef("T000R11", "SAVEPOINT gxupdate;DELETE FROM tb_produtotipo  WHERE PrtID = :PrtID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000R11)
           ,new CursorDef("T000R12", "SELECT PrdID FROM tb_produto WHERE PrdTipoID = :PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000R13", "SELECT PrtID FROM tb_produtotipo ORDER BY PrtID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000R13,100, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 7 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
