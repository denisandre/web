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
   public class contatotipo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.contatotipo.aspx")), "core.contatotipo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.contatotipo.aspx")))) ;
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
                  AV13CotID = (int)(Math.Round(NumberUtil.Val( GetPar( "CotID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13CotID", StringUtil.LTrimStr( (decimal)(AV13CotID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCOTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13CotID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo de Contato", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCotSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public contatotipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public contatotipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CotID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13CotID = aP1_CotID;
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
            return "contatotipo_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCotSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotSigla_Internalname, A150CotSigla, StringUtil.RTrim( context.localUtil.Format( A150CotSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCotSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\ContatoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCotNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCotNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCotNome_Internalname, A151CotNome, StringUtil.RTrim( context.localUtil.Format( A151CotNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCotNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\ContatoTipo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ContatoTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\ContatoTipo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCotID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A149CotID), 11, 0, ",", "")), StringUtil.LTrim( ((edtCotID_Enabled!=0) ? context.localUtil.Format( (decimal)(A149CotID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A149CotID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCotID_Jsonclick, 0, "Attribute", "", "", "", "", edtCotID_Visible, edtCotID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\ContatoTipo.htm");
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
         E110L2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z149CotID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z149CotID"), ",", "."), 18, MidpointRounding.ToEven));
               Z567CotDelDataHora = context.localUtil.CToT( cgiGet( "Z567CotDelDataHora"), 0);
               n567CotDelDataHora = ((DateTime.MinValue==A567CotDelDataHora) ? true : false);
               Z568CotDelData = context.localUtil.CToT( cgiGet( "Z568CotDelData"), 0);
               n568CotDelData = ((DateTime.MinValue==A568CotDelData) ? true : false);
               Z569CotDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z569CotDelHora"), 0));
               n569CotDelHora = ((DateTime.MinValue==A569CotDelHora) ? true : false);
               Z570CotDelUsuId = cgiGet( "Z570CotDelUsuId");
               n570CotDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A570CotDelUsuId)) ? true : false);
               Z571CotDelUsuNome = cgiGet( "Z571CotDelUsuNome");
               n571CotDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A571CotDelUsuNome)) ? true : false);
               Z150CotSigla = cgiGet( "Z150CotSigla");
               Z151CotNome = cgiGet( "Z151CotNome");
               Z216CotAtivo = StringUtil.StrToBool( cgiGet( "Z216CotAtivo"));
               Z566CotDel = StringUtil.StrToBool( cgiGet( "Z566CotDel"));
               A567CotDelDataHora = context.localUtil.CToT( cgiGet( "Z567CotDelDataHora"), 0);
               n567CotDelDataHora = false;
               n567CotDelDataHora = ((DateTime.MinValue==A567CotDelDataHora) ? true : false);
               A568CotDelData = context.localUtil.CToT( cgiGet( "Z568CotDelData"), 0);
               n568CotDelData = false;
               n568CotDelData = ((DateTime.MinValue==A568CotDelData) ? true : false);
               A569CotDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z569CotDelHora"), 0));
               n569CotDelHora = false;
               n569CotDelHora = ((DateTime.MinValue==A569CotDelHora) ? true : false);
               A570CotDelUsuId = cgiGet( "Z570CotDelUsuId");
               n570CotDelUsuId = false;
               n570CotDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A570CotDelUsuId)) ? true : false);
               A571CotDelUsuNome = cgiGet( "Z571CotDelUsuNome");
               n571CotDelUsuNome = false;
               n571CotDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A571CotDelUsuNome)) ? true : false);
               A216CotAtivo = StringUtil.StrToBool( cgiGet( "Z216CotAtivo"));
               A566CotDel = StringUtil.StrToBool( cgiGet( "Z566CotDel"));
               O566CotDel = StringUtil.StrToBool( cgiGet( "O566CotDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV13CotID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCOTID"), ",", "."), 18, MidpointRounding.ToEven));
               A566CotDel = StringUtil.StrToBool( cgiGet( "COTDEL"));
               A567CotDelDataHora = context.localUtil.CToT( cgiGet( "COTDELDATAHORA"), 0);
               n567CotDelDataHora = ((DateTime.MinValue==A567CotDelDataHora) ? true : false);
               A568CotDelData = context.localUtil.CToT( cgiGet( "COTDELDATA"), 0);
               n568CotDelData = ((DateTime.MinValue==A568CotDelData) ? true : false);
               A569CotDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "COTDELHORA"), 0));
               n569CotDelHora = ((DateTime.MinValue==A569CotDelHora) ? true : false);
               A570CotDelUsuId = cgiGet( "COTDELUSUID");
               n570CotDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A570CotDelUsuId)) ? true : false);
               A571CotDelUsuNome = cgiGet( "COTDELUSUNOME");
               n571CotDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A571CotDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A216CotAtivo = StringUtil.StrToBool( cgiGet( "COTATIVO"));
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
               A150CotSigla = cgiGet( edtCotSigla_Internalname);
               AssignAttri("", false, "A150CotSigla", A150CotSigla);
               A151CotNome = StringUtil.Upper( cgiGet( edtCotNome_Internalname));
               AssignAttri("", false, "A151CotNome", A151CotNome);
               A149CotID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCotID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"ContatoTipo");
               A149CotID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCotID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
               forbiddenHiddens.Add("CotID", context.localUtil.Format( (decimal)(A149CotID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
               forbiddenHiddens.Add("CotAtivo", StringUtil.BoolToStr( A216CotAtivo));
               forbiddenHiddens.Add("CotDel", StringUtil.BoolToStr( A566CotDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A149CotID != Z149CotID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\contatotipo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A149CotID = (int)(Math.Round(NumberUtil.Val( GetPar( "CotID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
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
                     sMode21 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode21;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound21 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0L0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "COTID");
                        AnyError = 1;
                        GX_FocusControl = edtCotID_Internalname;
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
                           E110L2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120L2 ();
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
            E120L2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0L21( ) ;
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
            DisableAttributes0L21( ) ;
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

      protected void CONFIRM_0L0( )
      {
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0L21( ) ;
            }
            else
            {
               CheckExtendedTable0L21( ) ;
               CloseExtendedTableCursors0L21( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0L0( )
      {
      }

      protected void E110L2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("COTID");
         AV12WebSession.Remove("COTNOME");
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtCotID_Visible = 0;
         AssignProp("", false, edtCotID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCotID_Visible), 5, 0), true);
      }

      protected void E120L2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
         AV12WebSession.Set("COTID", StringUtil.Trim( StringUtil.Str( (decimal)(A149CotID), 9, 0)));
         AV12WebSession.Set("COTNOME", A151CotNome);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.contatotipoww.aspx") );
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

      protected void ZM0L21( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z567CotDelDataHora = T000L3_A567CotDelDataHora[0];
               Z568CotDelData = T000L3_A568CotDelData[0];
               Z569CotDelHora = T000L3_A569CotDelHora[0];
               Z570CotDelUsuId = T000L3_A570CotDelUsuId[0];
               Z571CotDelUsuNome = T000L3_A571CotDelUsuNome[0];
               Z150CotSigla = T000L3_A150CotSigla[0];
               Z151CotNome = T000L3_A151CotNome[0];
               Z216CotAtivo = T000L3_A216CotAtivo[0];
               Z566CotDel = T000L3_A566CotDel[0];
            }
            else
            {
               Z567CotDelDataHora = A567CotDelDataHora;
               Z568CotDelData = A568CotDelData;
               Z569CotDelHora = A569CotDelHora;
               Z570CotDelUsuId = A570CotDelUsuId;
               Z571CotDelUsuNome = A571CotDelUsuNome;
               Z150CotSigla = A150CotSigla;
               Z151CotNome = A151CotNome;
               Z216CotAtivo = A216CotAtivo;
               Z566CotDel = A566CotDel;
            }
         }
         if ( GX_JID == -15 )
         {
            Z149CotID = A149CotID;
            Z567CotDelDataHora = A567CotDelDataHora;
            Z568CotDelData = A568CotDelData;
            Z569CotDelHora = A569CotDelHora;
            Z570CotDelUsuId = A570CotDelUsuId;
            Z571CotDelUsuNome = A571CotDelUsuNome;
            Z150CotSigla = A150CotSigla;
            Z151CotNome = A151CotNome;
            Z216CotAtivo = A216CotAtivo;
            Z566CotDel = A566CotDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCotID_Enabled = 0;
         AssignProp("", false, edtCotID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV15Pgmname = "core.ContatoTipo";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         edtCotID_Enabled = 0;
         AssignProp("", false, edtCotID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotID_Enabled), 5, 0), true);
         if ( ! (0==AV13CotID) )
         {
            A149CotID = AV13CotID;
            AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
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
         if ( IsIns( )  && (false==A216CotAtivo) && ( Gx_BScreen == 0 ) )
         {
            A216CotAtivo = true;
            AssignAttri("", false, "A216CotAtivo", A216CotAtivo);
         }
      }

      protected void Load0L21( )
      {
         /* Using cursor T000L4 */
         pr_default.execute(2, new Object[] {A149CotID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound21 = 1;
            A567CotDelDataHora = T000L4_A567CotDelDataHora[0];
            n567CotDelDataHora = T000L4_n567CotDelDataHora[0];
            A568CotDelData = T000L4_A568CotDelData[0];
            n568CotDelData = T000L4_n568CotDelData[0];
            A569CotDelHora = T000L4_A569CotDelHora[0];
            n569CotDelHora = T000L4_n569CotDelHora[0];
            A570CotDelUsuId = T000L4_A570CotDelUsuId[0];
            n570CotDelUsuId = T000L4_n570CotDelUsuId[0];
            A571CotDelUsuNome = T000L4_A571CotDelUsuNome[0];
            n571CotDelUsuNome = T000L4_n571CotDelUsuNome[0];
            A150CotSigla = T000L4_A150CotSigla[0];
            AssignAttri("", false, "A150CotSigla", A150CotSigla);
            A151CotNome = T000L4_A151CotNome[0];
            AssignAttri("", false, "A151CotNome", A151CotNome);
            A216CotAtivo = T000L4_A216CotAtivo[0];
            A566CotDel = T000L4_A566CotDel[0];
            ZM0L21( -15) ;
         }
         pr_default.close(2);
         OnLoadActions0L21( ) ;
      }

      protected void OnLoadActions0L21( )
      {
      }

      protected void CheckExtendedTable0L21( )
      {
         nIsDirty_21 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000L5 */
         pr_default.execute(3, new Object[] {A150CotSigla, A149CotID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "COTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCotSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A150CotSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "COTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCotSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A151CotNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "COTNOME");
            AnyError = 1;
            GX_FocusControl = edtCotNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0L21( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0L21( )
      {
         /* Using cursor T000L6 */
         pr_default.execute(4, new Object[] {A149CotID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound21 = 1;
         }
         else
         {
            RcdFound21 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000L3 */
         pr_default.execute(1, new Object[] {A149CotID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0L21( 15) ;
            RcdFound21 = 1;
            A149CotID = T000L3_A149CotID[0];
            AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
            A567CotDelDataHora = T000L3_A567CotDelDataHora[0];
            n567CotDelDataHora = T000L3_n567CotDelDataHora[0];
            A568CotDelData = T000L3_A568CotDelData[0];
            n568CotDelData = T000L3_n568CotDelData[0];
            A569CotDelHora = T000L3_A569CotDelHora[0];
            n569CotDelHora = T000L3_n569CotDelHora[0];
            A570CotDelUsuId = T000L3_A570CotDelUsuId[0];
            n570CotDelUsuId = T000L3_n570CotDelUsuId[0];
            A571CotDelUsuNome = T000L3_A571CotDelUsuNome[0];
            n571CotDelUsuNome = T000L3_n571CotDelUsuNome[0];
            A150CotSigla = T000L3_A150CotSigla[0];
            AssignAttri("", false, "A150CotSigla", A150CotSigla);
            A151CotNome = T000L3_A151CotNome[0];
            AssignAttri("", false, "A151CotNome", A151CotNome);
            A216CotAtivo = T000L3_A216CotAtivo[0];
            A566CotDel = T000L3_A566CotDel[0];
            O566CotDel = A566CotDel;
            AssignAttri("", false, "A566CotDel", A566CotDel);
            Z149CotID = A149CotID;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0L21( ) ;
            if ( AnyError == 1 )
            {
               RcdFound21 = 0;
               InitializeNonKey0L21( ) ;
            }
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound21 = 0;
            InitializeNonKey0L21( ) ;
            sMode21 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode21;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0L21( ) ;
         if ( RcdFound21 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound21 = 0;
         /* Using cursor T000L7 */
         pr_default.execute(5, new Object[] {A149CotID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A149CotID[0] < A149CotID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000L7_A149CotID[0] > A149CotID ) ) )
            {
               A149CotID = T000L7_A149CotID[0];
               AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound21 = 0;
         /* Using cursor T000L8 */
         pr_default.execute(6, new Object[] {A149CotID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000L8_A149CotID[0] > A149CotID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000L8_A149CotID[0] < A149CotID ) ) )
            {
               A149CotID = T000L8_A149CotID[0];
               AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
               RcdFound21 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0L21( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCotSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0L21( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound21 == 1 )
            {
               if ( A149CotID != Z149CotID )
               {
                  A149CotID = Z149CotID;
                  AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "COTID");
                  AnyError = 1;
                  GX_FocusControl = edtCotID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCotSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0L21( ) ;
                  GX_FocusControl = edtCotSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A149CotID != Z149CotID )
               {
                  /* Insert record */
                  GX_FocusControl = edtCotSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0L21( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "COTID");
                     AnyError = 1;
                     GX_FocusControl = edtCotID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCotSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0L21( ) ;
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
         if ( A149CotID != Z149CotID )
         {
            A149CotID = Z149CotID;
            AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "COTID");
            AnyError = 1;
            GX_FocusControl = edtCotID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCotSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0L21( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000L2 */
            pr_default.execute(0, new Object[] {A149CotID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_contatotipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z567CotDelDataHora != T000L2_A567CotDelDataHora[0] ) || ( Z568CotDelData != T000L2_A568CotDelData[0] ) || ( Z569CotDelHora != T000L2_A569CotDelHora[0] ) || ( StringUtil.StrCmp(Z570CotDelUsuId, T000L2_A570CotDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z571CotDelUsuNome, T000L2_A571CotDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z150CotSigla, T000L2_A150CotSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z151CotNome, T000L2_A151CotNome[0]) != 0 ) || ( Z216CotAtivo != T000L2_A216CotAtivo[0] ) || ( Z566CotDel != T000L2_A566CotDel[0] ) )
            {
               if ( Z567CotDelDataHora != T000L2_A567CotDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z567CotDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A567CotDelDataHora[0]);
               }
               if ( Z568CotDelData != T000L2_A568CotDelData[0] )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDelData");
                  GXUtil.WriteLogRaw("Old: ",Z568CotDelData);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A568CotDelData[0]);
               }
               if ( Z569CotDelHora != T000L2_A569CotDelHora[0] )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z569CotDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A569CotDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z570CotDelUsuId, T000L2_A570CotDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z570CotDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A570CotDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z571CotDelUsuNome, T000L2_A571CotDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z571CotDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A571CotDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z150CotSigla, T000L2_A150CotSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotSigla");
                  GXUtil.WriteLogRaw("Old: ",Z150CotSigla);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A150CotSigla[0]);
               }
               if ( StringUtil.StrCmp(Z151CotNome, T000L2_A151CotNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotNome");
                  GXUtil.WriteLogRaw("Old: ",Z151CotNome);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A151CotNome[0]);
               }
               if ( Z216CotAtivo != T000L2_A216CotAtivo[0] )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z216CotAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A216CotAtivo[0]);
               }
               if ( Z566CotDel != T000L2_A566CotDel[0] )
               {
                  GXUtil.WriteLog("core.contatotipo:[seudo value changed for attri]"+"CotDel");
                  GXUtil.WriteLogRaw("Old: ",Z566CotDel);
                  GXUtil.WriteLogRaw("Current: ",T000L2_A566CotDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_contatotipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0L21( )
      {
         if ( ! IsAuthorized("contatotipo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0L21( 0) ;
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L9 */
                     pr_default.execute(7, new Object[] {n567CotDelDataHora, A567CotDelDataHora, n568CotDelData, A568CotDelData, n569CotDelHora, A569CotDelHora, n570CotDelUsuId, A570CotDelUsuId, n571CotDelUsuNome, A571CotDelUsuNome, A150CotSigla, A151CotNome, A216CotAtivo, A566CotDel});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000L10 */
                     pr_default.execute(8);
                     A149CotID = T000L10_A149CotID[0];
                     AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0L0( ) ;
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
               Load0L21( ) ;
            }
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void Update0L21( )
      {
         if ( ! IsAuthorized("contatotipo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0L21( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0L21( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000L11 */
                     pr_default.execute(9, new Object[] {n567CotDelDataHora, A567CotDelDataHora, n568CotDelData, A568CotDelData, n569CotDelHora, A569CotDelHora, n570CotDelUsuId, A570CotDelUsuId, n571CotDelUsuNome, A571CotDelUsuNome, A150CotSigla, A151CotNome, A216CotAtivo, A566CotDel, A149CotID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_contatotipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0L21( ) ;
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
            EndLevel0L21( ) ;
         }
         CloseExtendedTableCursors0L21( ) ;
      }

      protected void DeferredUpdate0L21( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("contatotipo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0L21( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0L21( ) ;
            AfterConfirm0L21( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0L21( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000L12 */
                  pr_default.execute(10, new Object[] {A149CotID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_contatotipo");
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
         sMode21 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0L21( ) ;
         Gx_mode = sMode21;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0L21( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0L21( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0L21( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.contatotipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0L0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.contatotipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0L21( )
      {
         /* Scan By routine */
         /* Using cursor T000L13 */
         pr_default.execute(11);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound21 = 1;
            A149CotID = T000L13_A149CotID[0];
            AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0L21( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound21 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound21 = 1;
            A149CotID = T000L13_A149CotID[0];
            AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
         }
      }

      protected void ScanEnd0L21( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0L21( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0L21( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0L21( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A567CotDelDataHora = DateTimeUtil.NowMS( context);
            n567CotDelDataHora = false;
            AssignAttri("", false, "A567CotDelDataHora", context.localUtil.TToC( A567CotDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A570CotDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n570CotDelUsuId = false;
            AssignAttri("", false, "A570CotDelUsuId", A570CotDelUsuId);
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A571CotDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n571CotDelUsuNome = false;
            AssignAttri("", false, "A571CotDelUsuNome", A571CotDelUsuNome);
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A568CotDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A567CotDelDataHora) ) ;
            n568CotDelData = false;
            AssignAttri("", false, "A568CotDelData", context.localUtil.TToC( A568CotDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A566CotDel && ( O566CotDel != A566CotDel ) )
         {
            A569CotDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A567CotDelDataHora));
            n569CotDelHora = false;
            AssignAttri("", false, "A569CotDelHora", context.localUtil.TToC( A569CotDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0L21( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
      }

      protected void BeforeComplete0L21( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0L21( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0L21( )
      {
         edtCotSigla_Enabled = 0;
         AssignProp("", false, edtCotSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotSigla_Enabled), 5, 0), true);
         edtCotNome_Enabled = 0;
         AssignProp("", false, edtCotNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotNome_Enabled), 5, 0), true);
         edtCotID_Enabled = 0;
         AssignProp("", false, edtCotID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCotID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0L21( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0L0( )
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
         GXEncryptionTmp = "core.contatotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13CotID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.contatotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"ContatoTipo");
         forbiddenHiddens.Add("CotID", context.localUtil.Format( (decimal)(A149CotID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
         forbiddenHiddens.Add("CotAtivo", StringUtil.BoolToStr( A216CotAtivo));
         forbiddenHiddens.Add("CotDel", StringUtil.BoolToStr( A566CotDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\contatotipo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z149CotID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z149CotID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z567CotDelDataHora", context.localUtil.TToC( Z567CotDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z568CotDelData", context.localUtil.TToC( Z568CotDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z569CotDelHora", context.localUtil.TToC( Z569CotDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z570CotDelUsuId", StringUtil.RTrim( Z570CotDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z571CotDelUsuNome", Z571CotDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z150CotSigla", Z150CotSigla);
         GxWebStd.gx_hidden_field( context, "Z151CotNome", Z151CotNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z216CotAtivo", Z216CotAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z566CotDel", Z566CotDel);
         GxWebStd.gx_boolean_hidden_field( context, "O566CotDel", O566CotDel);
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
         GxWebStd.gx_hidden_field( context, "vCOTID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13CotID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCOTID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13CotID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "COTDEL", A566CotDel);
         GxWebStd.gx_hidden_field( context, "COTDELDATAHORA", context.localUtil.TToC( A567CotDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "COTDELDATA", context.localUtil.TToC( A568CotDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "COTDELHORA", context.localUtil.TToC( A569CotDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "COTDELUSUID", StringUtil.RTrim( A570CotDelUsuId));
         GxWebStd.gx_hidden_field( context, "COTDELUSUNOME", A571CotDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "COTATIVO", A216CotAtivo);
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
         GXEncryptionTmp = "core.contatotipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13CotID,9,0));
         return formatLink("core.contatotipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.ContatoTipo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Contato" ;
      }

      protected void InitializeNonKey0L21( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A567CotDelDataHora = (DateTime)(DateTime.MinValue);
         n567CotDelDataHora = false;
         AssignAttri("", false, "A567CotDelDataHora", context.localUtil.TToC( A567CotDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A568CotDelData = (DateTime)(DateTime.MinValue);
         n568CotDelData = false;
         AssignAttri("", false, "A568CotDelData", context.localUtil.TToC( A568CotDelData, 10, 5, 0, 3, "/", ":", " "));
         A569CotDelHora = (DateTime)(DateTime.MinValue);
         n569CotDelHora = false;
         AssignAttri("", false, "A569CotDelHora", context.localUtil.TToC( A569CotDelHora, 0, 5, 0, 3, "/", ":", " "));
         A570CotDelUsuId = "";
         n570CotDelUsuId = false;
         AssignAttri("", false, "A570CotDelUsuId", A570CotDelUsuId);
         A571CotDelUsuNome = "";
         n571CotDelUsuNome = false;
         AssignAttri("", false, "A571CotDelUsuNome", A571CotDelUsuNome);
         A150CotSigla = "";
         AssignAttri("", false, "A150CotSigla", A150CotSigla);
         A151CotNome = "";
         AssignAttri("", false, "A151CotNome", A151CotNome);
         A566CotDel = false;
         AssignAttri("", false, "A566CotDel", A566CotDel);
         A216CotAtivo = true;
         AssignAttri("", false, "A216CotAtivo", A216CotAtivo);
         O566CotDel = A566CotDel;
         AssignAttri("", false, "A566CotDel", A566CotDel);
         Z567CotDelDataHora = (DateTime)(DateTime.MinValue);
         Z568CotDelData = (DateTime)(DateTime.MinValue);
         Z569CotDelHora = (DateTime)(DateTime.MinValue);
         Z570CotDelUsuId = "";
         Z571CotDelUsuNome = "";
         Z150CotSigla = "";
         Z151CotNome = "";
         Z216CotAtivo = false;
         Z566CotDel = false;
      }

      protected void InitAll0L21( )
      {
         A149CotID = 0;
         AssignAttri("", false, "A149CotID", StringUtil.LTrimStr( (decimal)(A149CotID), 9, 0));
         InitializeNonKey0L21( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A216CotAtivo = i216CotAtivo;
         AssignAttri("", false, "A216CotAtivo", A216CotAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828124430", true, true);
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
         context.AddJavascriptSource("core/contatotipo.js", "?2023828124432", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCotSigla_Internalname = "COTSIGLA";
         edtCotNome_Internalname = "COTNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtCotID_Internalname = "COTID";
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
         Form.Caption = "Tipo de Contato";
         edtCotID_Jsonclick = "";
         edtCotID_Enabled = 0;
         edtCotID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCotNome_Jsonclick = "";
         edtCotNome_Enabled = 1;
         edtCotSigla_Jsonclick = "";
         edtCotSigla_Enabled = 1;
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

      protected void XC_11_0L21( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A149CotID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
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

      protected void XC_12_0L21( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A149CotID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "Y", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
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

      protected void XC_13_0L21( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A149CotID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
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

      protected void XC_14_0L21( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A149CotID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcontatotipo(context ).execute(  "N", ref  AV14AuditingObject,  A149CotID,  Gx_mode) ;
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

      public void Valid_Cotsigla( )
      {
         /* Using cursor T000L14 */
         pr_default.execute(12, new Object[] {A150CotSigla, A149CotID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "COTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCotSigla_Internalname;
         }
         pr_default.close(12);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A150CotSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "COTSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCotSigla_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13CotID',fld:'vCOTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13CotID',fld:'vCOTID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A149CotID',fld:'COTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A216CotAtivo',fld:'COTATIVO',pic:''},{av:'A566CotDel',fld:'COTDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120L2',iparms:[{av:'AV14AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A149CotID',fld:'COTID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A151CotNome',fld:'COTNOME',pic:'@!'},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_COTSIGLA","{handler:'Valid_Cotsigla',iparms:[{av:'A150CotSigla',fld:'COTSIGLA',pic:''},{av:'A149CotID',fld:'COTID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_COTSIGLA",",oparms:[]}");
         setEventMetadata("VALID_COTNOME","{handler:'Valid_Cotnome',iparms:[]");
         setEventMetadata("VALID_COTNOME",",oparms:[]}");
         setEventMetadata("VALID_COTID","{handler:'Valid_Cotid',iparms:[]");
         setEventMetadata("VALID_COTID",",oparms:[]}");
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
         Z567CotDelDataHora = (DateTime)(DateTime.MinValue);
         Z568CotDelData = (DateTime)(DateTime.MinValue);
         Z569CotDelHora = (DateTime)(DateTime.MinValue);
         Z570CotDelUsuId = "";
         Z571CotDelUsuNome = "";
         Z150CotSigla = "";
         Z151CotNome = "";
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
         A150CotSigla = "";
         A151CotNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A567CotDelDataHora = (DateTime)(DateTime.MinValue);
         A568CotDelData = (DateTime)(DateTime.MinValue);
         A569CotDelHora = (DateTime)(DateTime.MinValue);
         A570CotDelUsuId = "";
         A571CotDelUsuNome = "";
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode21 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         T000L4_A149CotID = new int[1] ;
         T000L4_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000L4_n567CotDelDataHora = new bool[] {false} ;
         T000L4_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         T000L4_n568CotDelData = new bool[] {false} ;
         T000L4_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         T000L4_n569CotDelHora = new bool[] {false} ;
         T000L4_A570CotDelUsuId = new string[] {""} ;
         T000L4_n570CotDelUsuId = new bool[] {false} ;
         T000L4_A571CotDelUsuNome = new string[] {""} ;
         T000L4_n571CotDelUsuNome = new bool[] {false} ;
         T000L4_A150CotSigla = new string[] {""} ;
         T000L4_A151CotNome = new string[] {""} ;
         T000L4_A216CotAtivo = new bool[] {false} ;
         T000L4_A566CotDel = new bool[] {false} ;
         T000L5_A150CotSigla = new string[] {""} ;
         T000L6_A149CotID = new int[1] ;
         T000L3_A149CotID = new int[1] ;
         T000L3_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000L3_n567CotDelDataHora = new bool[] {false} ;
         T000L3_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         T000L3_n568CotDelData = new bool[] {false} ;
         T000L3_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         T000L3_n569CotDelHora = new bool[] {false} ;
         T000L3_A570CotDelUsuId = new string[] {""} ;
         T000L3_n570CotDelUsuId = new bool[] {false} ;
         T000L3_A571CotDelUsuNome = new string[] {""} ;
         T000L3_n571CotDelUsuNome = new bool[] {false} ;
         T000L3_A150CotSigla = new string[] {""} ;
         T000L3_A151CotNome = new string[] {""} ;
         T000L3_A216CotAtivo = new bool[] {false} ;
         T000L3_A566CotDel = new bool[] {false} ;
         T000L7_A149CotID = new int[1] ;
         T000L8_A149CotID = new int[1] ;
         T000L2_A149CotID = new int[1] ;
         T000L2_A567CotDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000L2_n567CotDelDataHora = new bool[] {false} ;
         T000L2_A568CotDelData = new DateTime[] {DateTime.MinValue} ;
         T000L2_n568CotDelData = new bool[] {false} ;
         T000L2_A569CotDelHora = new DateTime[] {DateTime.MinValue} ;
         T000L2_n569CotDelHora = new bool[] {false} ;
         T000L2_A570CotDelUsuId = new string[] {""} ;
         T000L2_n570CotDelUsuId = new bool[] {false} ;
         T000L2_A571CotDelUsuNome = new string[] {""} ;
         T000L2_n571CotDelUsuNome = new bool[] {false} ;
         T000L2_A150CotSigla = new string[] {""} ;
         T000L2_A151CotNome = new string[] {""} ;
         T000L2_A216CotAtivo = new bool[] {false} ;
         T000L2_A566CotDel = new bool[] {false} ;
         T000L10_A149CotID = new int[1] ;
         T000L13_A149CotID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000L14_A150CotSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.contatotipo__default(),
            new Object[][] {
                new Object[] {
               T000L2_A149CotID, T000L2_A567CotDelDataHora, T000L2_n567CotDelDataHora, T000L2_A568CotDelData, T000L2_n568CotDelData, T000L2_A569CotDelHora, T000L2_n569CotDelHora, T000L2_A570CotDelUsuId, T000L2_n570CotDelUsuId, T000L2_A571CotDelUsuNome,
               T000L2_n571CotDelUsuNome, T000L2_A150CotSigla, T000L2_A151CotNome, T000L2_A216CotAtivo, T000L2_A566CotDel
               }
               , new Object[] {
               T000L3_A149CotID, T000L3_A567CotDelDataHora, T000L3_n567CotDelDataHora, T000L3_A568CotDelData, T000L3_n568CotDelData, T000L3_A569CotDelHora, T000L3_n569CotDelHora, T000L3_A570CotDelUsuId, T000L3_n570CotDelUsuId, T000L3_A571CotDelUsuNome,
               T000L3_n571CotDelUsuNome, T000L3_A150CotSigla, T000L3_A151CotNome, T000L3_A216CotAtivo, T000L3_A566CotDel
               }
               , new Object[] {
               T000L4_A149CotID, T000L4_A567CotDelDataHora, T000L4_n567CotDelDataHora, T000L4_A568CotDelData, T000L4_n568CotDelData, T000L4_A569CotDelHora, T000L4_n569CotDelHora, T000L4_A570CotDelUsuId, T000L4_n570CotDelUsuId, T000L4_A571CotDelUsuNome,
               T000L4_n571CotDelUsuNome, T000L4_A150CotSigla, T000L4_A151CotNome, T000L4_A216CotAtivo, T000L4_A566CotDel
               }
               , new Object[] {
               T000L5_A150CotSigla
               }
               , new Object[] {
               T000L6_A149CotID
               }
               , new Object[] {
               T000L7_A149CotID
               }
               , new Object[] {
               T000L8_A149CotID
               }
               , new Object[] {
               }
               , new Object[] {
               T000L10_A149CotID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000L13_A149CotID
               }
               , new Object[] {
               T000L14_A150CotSigla
               }
            }
         );
         Z216CotAtivo = true;
         A216CotAtivo = true;
         i216CotAtivo = true;
         AV15Pgmname = "core.ContatoTipo";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound21 ;
      private short GX_JID ;
      private short nIsDirty_21 ;
      private short gxajaxcallmode ;
      private int wcpOAV13CotID ;
      private int Z149CotID ;
      private int AV13CotID ;
      private int trnEnded ;
      private int edtCotSigla_Enabled ;
      private int edtCotNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A149CotID ;
      private int edtCotID_Enabled ;
      private int edtCotID_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z570CotDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCotSigla_Internalname ;
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
      private string edtCotSigla_Jsonclick ;
      private string edtCotNome_Internalname ;
      private string edtCotNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCotID_Internalname ;
      private string edtCotID_Jsonclick ;
      private string A570CotDelUsuId ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode21 ;
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
      private DateTime Z567CotDelDataHora ;
      private DateTime Z568CotDelData ;
      private DateTime Z569CotDelHora ;
      private DateTime A567CotDelDataHora ;
      private DateTime A568CotDelData ;
      private DateTime A569CotDelHora ;
      private bool Z216CotAtivo ;
      private bool Z566CotDel ;
      private bool O566CotDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n567CotDelDataHora ;
      private bool n568CotDelData ;
      private bool n569CotDelHora ;
      private bool n570CotDelUsuId ;
      private bool n571CotDelUsuNome ;
      private bool A216CotAtivo ;
      private bool A566CotDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i216CotAtivo ;
      private string Z571CotDelUsuNome ;
      private string Z150CotSigla ;
      private string Z151CotNome ;
      private string A150CotSigla ;
      private string A151CotNome ;
      private string A571CotDelUsuNome ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000L4_A149CotID ;
      private DateTime[] T000L4_A567CotDelDataHora ;
      private bool[] T000L4_n567CotDelDataHora ;
      private DateTime[] T000L4_A568CotDelData ;
      private bool[] T000L4_n568CotDelData ;
      private DateTime[] T000L4_A569CotDelHora ;
      private bool[] T000L4_n569CotDelHora ;
      private string[] T000L4_A570CotDelUsuId ;
      private bool[] T000L4_n570CotDelUsuId ;
      private string[] T000L4_A571CotDelUsuNome ;
      private bool[] T000L4_n571CotDelUsuNome ;
      private string[] T000L4_A150CotSigla ;
      private string[] T000L4_A151CotNome ;
      private bool[] T000L4_A216CotAtivo ;
      private bool[] T000L4_A566CotDel ;
      private string[] T000L5_A150CotSigla ;
      private int[] T000L6_A149CotID ;
      private int[] T000L3_A149CotID ;
      private DateTime[] T000L3_A567CotDelDataHora ;
      private bool[] T000L3_n567CotDelDataHora ;
      private DateTime[] T000L3_A568CotDelData ;
      private bool[] T000L3_n568CotDelData ;
      private DateTime[] T000L3_A569CotDelHora ;
      private bool[] T000L3_n569CotDelHora ;
      private string[] T000L3_A570CotDelUsuId ;
      private bool[] T000L3_n570CotDelUsuId ;
      private string[] T000L3_A571CotDelUsuNome ;
      private bool[] T000L3_n571CotDelUsuNome ;
      private string[] T000L3_A150CotSigla ;
      private string[] T000L3_A151CotNome ;
      private bool[] T000L3_A216CotAtivo ;
      private bool[] T000L3_A566CotDel ;
      private int[] T000L7_A149CotID ;
      private int[] T000L8_A149CotID ;
      private int[] T000L2_A149CotID ;
      private DateTime[] T000L2_A567CotDelDataHora ;
      private bool[] T000L2_n567CotDelDataHora ;
      private DateTime[] T000L2_A568CotDelData ;
      private bool[] T000L2_n568CotDelData ;
      private DateTime[] T000L2_A569CotDelHora ;
      private bool[] T000L2_n569CotDelHora ;
      private string[] T000L2_A570CotDelUsuId ;
      private bool[] T000L2_n570CotDelUsuId ;
      private string[] T000L2_A571CotDelUsuNome ;
      private bool[] T000L2_n571CotDelUsuNome ;
      private string[] T000L2_A150CotSigla ;
      private string[] T000L2_A151CotNome ;
      private bool[] T000L2_A216CotAtivo ;
      private bool[] T000L2_A566CotDel ;
      private int[] T000L10_A149CotID ;
      private int[] T000L13_A149CotID ;
      private string[] T000L14_A150CotSigla ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class contatotipo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class contatotipo__default : DataStoreHelperBase, IDataStoreHelper
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
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000L4;
        prmT000L4 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L5;
        prmT000L5 = new Object[] {
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L6;
        prmT000L6 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L3;
        prmT000L3 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L7;
        prmT000L7 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L8;
        prmT000L8 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L2;
        prmT000L2 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L9;
        prmT000L9 = new Object[] {
        new ParDef("CotDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CotDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CotDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CotDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CotDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotNome",GXType.VarChar,80,0) ,
        new ParDef("CotAtivo",GXType.Boolean,4,0) ,
        new ParDef("CotDel",GXType.Boolean,4,0)
        };
        Object[] prmT000L10;
        prmT000L10 = new Object[] {
        };
        Object[] prmT000L11;
        prmT000L11 = new Object[] {
        new ParDef("CotDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CotDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CotDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CotDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CotDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotNome",GXType.VarChar,80,0) ,
        new ParDef("CotAtivo",GXType.Boolean,4,0) ,
        new ParDef("CotDel",GXType.Boolean,4,0) ,
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L12;
        prmT000L12 = new Object[] {
        new ParDef("CotID",GXType.Int32,9,0)
        };
        Object[] prmT000L13;
        prmT000L13 = new Object[] {
        };
        Object[] prmT000L14;
        prmT000L14 = new Object[] {
        new ParDef("CotSigla",GXType.VarChar,20,0) ,
        new ParDef("CotID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000L2", "SELECT CotID, CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel FROM tb_contatotipo WHERE CotID = :CotID  FOR UPDATE OF tb_contatotipo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000L2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L3", "SELECT CotID, CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel FROM tb_contatotipo WHERE CotID = :CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L4", "SELECT TM1.CotID, TM1.CotDelDataHora, TM1.CotDelData, TM1.CotDelHora, TM1.CotDelUsuId, TM1.CotDelUsuNome, TM1.CotSigla, TM1.CotNome, TM1.CotAtivo, TM1.CotDel FROM tb_contatotipo TM1 WHERE TM1.CotID = :CotID ORDER BY TM1.CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L5", "SELECT CotSigla FROM tb_contatotipo WHERE (CotSigla = :CotSigla) AND (Not ( CotID = :CotID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L6", "SELECT CotID FROM tb_contatotipo WHERE CotID = :CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L7", "SELECT CotID FROM tb_contatotipo WHERE ( CotID > :CotID) ORDER BY CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L8", "SELECT CotID FROM tb_contatotipo WHERE ( CotID < :CotID) ORDER BY CotID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000L9", "SAVEPOINT gxupdate;INSERT INTO tb_contatotipo(CotDelDataHora, CotDelData, CotDelHora, CotDelUsuId, CotDelUsuNome, CotSigla, CotNome, CotAtivo, CotDel) VALUES(:CotDelDataHora, :CotDelData, :CotDelHora, :CotDelUsuId, :CotDelUsuNome, :CotSigla, :CotNome, :CotAtivo, :CotDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000L9)
           ,new CursorDef("T000L10", "SELECT currval('CotID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L11", "SAVEPOINT gxupdate;UPDATE tb_contatotipo SET CotDelDataHora=:CotDelDataHora, CotDelData=:CotDelData, CotDelHora=:CotDelHora, CotDelUsuId=:CotDelUsuId, CotDelUsuNome=:CotDelUsuNome, CotSigla=:CotSigla, CotNome=:CotNome, CotAtivo=:CotAtivo, CotDel=:CotDel  WHERE CotID = :CotID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L11)
           ,new CursorDef("T000L12", "SAVEPOINT gxupdate;DELETE FROM tb_contatotipo  WHERE CotID = :CotID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000L12)
           ,new CursorDef("T000L13", "SELECT CotID FROM tb_contatotipo ORDER BY CotID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000L14", "SELECT CotSigla FROM tb_contatotipo WHERE (CotSigla = :CotSigla) AND (Not ( CotID = :CotID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000L14,1, GxCacheFrequency.OFF ,true,false )
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
           case 8 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 11 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
