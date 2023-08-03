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
   public class genero : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.genero.aspx")), "core.genero.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.genero.aspx")))) ;
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
                  AV13GenID = (int)(Math.Round(NumberUtil.Val( GetPar( "GenID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13GenID", StringUtil.LTrimStr( (decimal)(AV13GenID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vGENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13GenID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Genero da Pessoa", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtGenSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public genero( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public genero( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_GenID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV13GenID = aP1_GenID;
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
            return "genero_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGenSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGenSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGenSigla_Internalname, A153GenSigla, StringUtil.RTrim( context.localUtil.Format( A153GenSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGenSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtGenSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\Genero.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtGenNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtGenNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtGenNome_Internalname, A154GenNome, StringUtil.RTrim( context.localUtil.Format( A154GenNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGenNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtGenNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Genero.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Genero.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Genero.htm");
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
         GxWebStd.gx_single_line_edit( context, edtGenID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A152GenID), 11, 0, ",", "")), StringUtil.LTrim( ((edtGenID_Enabled!=0) ? context.localUtil.Format( (decimal)(A152GenID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A152GenID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtGenID_Jsonclick, 0, "Attribute", "", "", "", "", edtGenID_Visible, edtGenID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\Genero.htm");
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
         E110M2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z152GenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z152GenID"), ",", "."), 18, MidpointRounding.ToEven));
               Z537GenDelDataHora = context.localUtil.CToT( cgiGet( "Z537GenDelDataHora"), 0);
               n537GenDelDataHora = ((DateTime.MinValue==A537GenDelDataHora) ? true : false);
               Z538GenDelData = context.localUtil.CToT( cgiGet( "Z538GenDelData"), 0);
               n538GenDelData = ((DateTime.MinValue==A538GenDelData) ? true : false);
               Z539GenDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z539GenDelHora"), 0));
               n539GenDelHora = ((DateTime.MinValue==A539GenDelHora) ? true : false);
               Z540GenDelUsuId = cgiGet( "Z540GenDelUsuId");
               n540GenDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A540GenDelUsuId)) ? true : false);
               Z541GenDelUsuNome = cgiGet( "Z541GenDelUsuNome");
               n541GenDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A541GenDelUsuNome)) ? true : false);
               Z153GenSigla = cgiGet( "Z153GenSigla");
               Z154GenNome = cgiGet( "Z154GenNome");
               Z215GenAtivo = StringUtil.StrToBool( cgiGet( "Z215GenAtivo"));
               Z536GenDel = StringUtil.StrToBool( cgiGet( "Z536GenDel"));
               A537GenDelDataHora = context.localUtil.CToT( cgiGet( "Z537GenDelDataHora"), 0);
               n537GenDelDataHora = false;
               n537GenDelDataHora = ((DateTime.MinValue==A537GenDelDataHora) ? true : false);
               A538GenDelData = context.localUtil.CToT( cgiGet( "Z538GenDelData"), 0);
               n538GenDelData = false;
               n538GenDelData = ((DateTime.MinValue==A538GenDelData) ? true : false);
               A539GenDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z539GenDelHora"), 0));
               n539GenDelHora = false;
               n539GenDelHora = ((DateTime.MinValue==A539GenDelHora) ? true : false);
               A540GenDelUsuId = cgiGet( "Z540GenDelUsuId");
               n540GenDelUsuId = false;
               n540GenDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A540GenDelUsuId)) ? true : false);
               A541GenDelUsuNome = cgiGet( "Z541GenDelUsuNome");
               n541GenDelUsuNome = false;
               n541GenDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A541GenDelUsuNome)) ? true : false);
               A215GenAtivo = StringUtil.StrToBool( cgiGet( "Z215GenAtivo"));
               A536GenDel = StringUtil.StrToBool( cgiGet( "Z536GenDel"));
               O536GenDel = StringUtil.StrToBool( cgiGet( "O536GenDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV13GenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vGENID"), ",", "."), 18, MidpointRounding.ToEven));
               A536GenDel = StringUtil.StrToBool( cgiGet( "GENDEL"));
               A537GenDelDataHora = context.localUtil.CToT( cgiGet( "GENDELDATAHORA"), 0);
               n537GenDelDataHora = ((DateTime.MinValue==A537GenDelDataHora) ? true : false);
               A538GenDelData = context.localUtil.CToT( cgiGet( "GENDELDATA"), 0);
               n538GenDelData = ((DateTime.MinValue==A538GenDelData) ? true : false);
               A539GenDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "GENDELHORA"), 0));
               n539GenDelHora = ((DateTime.MinValue==A539GenDelHora) ? true : false);
               A540GenDelUsuId = cgiGet( "GENDELUSUID");
               n540GenDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A540GenDelUsuId)) ? true : false);
               A541GenDelUsuNome = cgiGet( "GENDELUSUNOME");
               n541GenDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A541GenDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A215GenAtivo = StringUtil.StrToBool( cgiGet( "GENATIVO"));
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
               A153GenSigla = cgiGet( edtGenSigla_Internalname);
               AssignAttri("", false, "A153GenSigla", A153GenSigla);
               A154GenNome = StringUtil.Upper( cgiGet( edtGenNome_Internalname));
               AssignAttri("", false, "A154GenNome", A154GenNome);
               A152GenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtGenID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Genero");
               A152GenID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtGenID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
               forbiddenHiddens.Add("GenID", context.localUtil.Format( (decimal)(A152GenID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
               forbiddenHiddens.Add("GenAtivo", StringUtil.BoolToStr( A215GenAtivo));
               forbiddenHiddens.Add("GenDel", StringUtil.BoolToStr( A536GenDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A152GenID != Z152GenID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\genero:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A152GenID = (int)(Math.Round(NumberUtil.Val( GetPar( "GenID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
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
                     sMode22 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode22;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound22 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0M0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "GENID");
                        AnyError = 1;
                        GX_FocusControl = edtGenID_Internalname;
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
                           E110M2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120M2 ();
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
            E120M2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0M22( ) ;
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
            DisableAttributes0M22( ) ;
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

      protected void CONFIRM_0M0( )
      {
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0M22( ) ;
            }
            else
            {
               CheckExtendedTable0M22( ) ;
               CloseExtendedTableCursors0M22( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0M0( )
      {
      }

      protected void E110M2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("GENID");
         AV12WebSession.Remove("GENSIGLA");
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtGenID_Visible = 0;
         AssignProp("", false, edtGenID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtGenID_Visible), 5, 0), true);
      }

      protected void E120M2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV14AuditingObject,  AV15Pgmname) ;
         AV12WebSession.Set("GENID", StringUtil.Trim( StringUtil.Str( (decimal)(A152GenID), 9, 0)));
         AV12WebSession.Set("GENSIGLA", A153GenSigla);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.generoww.aspx") );
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

      protected void ZM0M22( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z537GenDelDataHora = T000M3_A537GenDelDataHora[0];
               Z538GenDelData = T000M3_A538GenDelData[0];
               Z539GenDelHora = T000M3_A539GenDelHora[0];
               Z540GenDelUsuId = T000M3_A540GenDelUsuId[0];
               Z541GenDelUsuNome = T000M3_A541GenDelUsuNome[0];
               Z153GenSigla = T000M3_A153GenSigla[0];
               Z154GenNome = T000M3_A154GenNome[0];
               Z215GenAtivo = T000M3_A215GenAtivo[0];
               Z536GenDel = T000M3_A536GenDel[0];
            }
            else
            {
               Z537GenDelDataHora = A537GenDelDataHora;
               Z538GenDelData = A538GenDelData;
               Z539GenDelHora = A539GenDelHora;
               Z540GenDelUsuId = A540GenDelUsuId;
               Z541GenDelUsuNome = A541GenDelUsuNome;
               Z153GenSigla = A153GenSigla;
               Z154GenNome = A154GenNome;
               Z215GenAtivo = A215GenAtivo;
               Z536GenDel = A536GenDel;
            }
         }
         if ( GX_JID == -15 )
         {
            Z152GenID = A152GenID;
            Z537GenDelDataHora = A537GenDelDataHora;
            Z538GenDelData = A538GenDelData;
            Z539GenDelHora = A539GenDelHora;
            Z540GenDelUsuId = A540GenDelUsuId;
            Z541GenDelUsuNome = A541GenDelUsuNome;
            Z153GenSigla = A153GenSigla;
            Z154GenNome = A154GenNome;
            Z215GenAtivo = A215GenAtivo;
            Z536GenDel = A536GenDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtGenID_Enabled = 0;
         AssignProp("", false, edtGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGenID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV15Pgmname = "core.Genero";
         AssignAttri("", false, "AV15Pgmname", AV15Pgmname);
         edtGenID_Enabled = 0;
         AssignProp("", false, edtGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGenID_Enabled), 5, 0), true);
         if ( ! (0==AV13GenID) )
         {
            A152GenID = AV13GenID;
            AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
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
         if ( IsIns( )  && (false==A215GenAtivo) && ( Gx_BScreen == 0 ) )
         {
            A215GenAtivo = true;
            AssignAttri("", false, "A215GenAtivo", A215GenAtivo);
         }
      }

      protected void Load0M22( )
      {
         /* Using cursor T000M4 */
         pr_default.execute(2, new Object[] {A152GenID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound22 = 1;
            A537GenDelDataHora = T000M4_A537GenDelDataHora[0];
            n537GenDelDataHora = T000M4_n537GenDelDataHora[0];
            A538GenDelData = T000M4_A538GenDelData[0];
            n538GenDelData = T000M4_n538GenDelData[0];
            A539GenDelHora = T000M4_A539GenDelHora[0];
            n539GenDelHora = T000M4_n539GenDelHora[0];
            A540GenDelUsuId = T000M4_A540GenDelUsuId[0];
            n540GenDelUsuId = T000M4_n540GenDelUsuId[0];
            A541GenDelUsuNome = T000M4_A541GenDelUsuNome[0];
            n541GenDelUsuNome = T000M4_n541GenDelUsuNome[0];
            A153GenSigla = T000M4_A153GenSigla[0];
            AssignAttri("", false, "A153GenSigla", A153GenSigla);
            A154GenNome = T000M4_A154GenNome[0];
            AssignAttri("", false, "A154GenNome", A154GenNome);
            A215GenAtivo = T000M4_A215GenAtivo[0];
            A536GenDel = T000M4_A536GenDel[0];
            ZM0M22( -15) ;
         }
         pr_default.close(2);
         OnLoadActions0M22( ) ;
      }

      protected void OnLoadActions0M22( )
      {
      }

      protected void CheckExtendedTable0M22( )
      {
         nIsDirty_22 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000M5 */
         pr_default.execute(3, new Object[] {A153GenSigla, A152GenID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "GENSIGLA");
            AnyError = 1;
            GX_FocusControl = edtGenSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A153GenSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "GENSIGLA");
            AnyError = 1;
            GX_FocusControl = edtGenSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A154GenNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "GENNOME");
            AnyError = 1;
            GX_FocusControl = edtGenNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0M22( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0M22( )
      {
         /* Using cursor T000M6 */
         pr_default.execute(4, new Object[] {A152GenID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound22 = 1;
         }
         else
         {
            RcdFound22 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000M3 */
         pr_default.execute(1, new Object[] {A152GenID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0M22( 15) ;
            RcdFound22 = 1;
            A152GenID = T000M3_A152GenID[0];
            AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
            A537GenDelDataHora = T000M3_A537GenDelDataHora[0];
            n537GenDelDataHora = T000M3_n537GenDelDataHora[0];
            A538GenDelData = T000M3_A538GenDelData[0];
            n538GenDelData = T000M3_n538GenDelData[0];
            A539GenDelHora = T000M3_A539GenDelHora[0];
            n539GenDelHora = T000M3_n539GenDelHora[0];
            A540GenDelUsuId = T000M3_A540GenDelUsuId[0];
            n540GenDelUsuId = T000M3_n540GenDelUsuId[0];
            A541GenDelUsuNome = T000M3_A541GenDelUsuNome[0];
            n541GenDelUsuNome = T000M3_n541GenDelUsuNome[0];
            A153GenSigla = T000M3_A153GenSigla[0];
            AssignAttri("", false, "A153GenSigla", A153GenSigla);
            A154GenNome = T000M3_A154GenNome[0];
            AssignAttri("", false, "A154GenNome", A154GenNome);
            A215GenAtivo = T000M3_A215GenAtivo[0];
            A536GenDel = T000M3_A536GenDel[0];
            O536GenDel = A536GenDel;
            AssignAttri("", false, "A536GenDel", A536GenDel);
            Z152GenID = A152GenID;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0M22( ) ;
            if ( AnyError == 1 )
            {
               RcdFound22 = 0;
               InitializeNonKey0M22( ) ;
            }
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound22 = 0;
            InitializeNonKey0M22( ) ;
            sMode22 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode22;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0M22( ) ;
         if ( RcdFound22 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound22 = 0;
         /* Using cursor T000M7 */
         pr_default.execute(5, new Object[] {A152GenID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A152GenID[0] < A152GenID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000M7_A152GenID[0] > A152GenID ) ) )
            {
               A152GenID = T000M7_A152GenID[0];
               AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound22 = 0;
         /* Using cursor T000M8 */
         pr_default.execute(6, new Object[] {A152GenID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000M8_A152GenID[0] > A152GenID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000M8_A152GenID[0] < A152GenID ) ) )
            {
               A152GenID = T000M8_A152GenID[0];
               AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
               RcdFound22 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0M22( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtGenSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0M22( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound22 == 1 )
            {
               if ( A152GenID != Z152GenID )
               {
                  A152GenID = Z152GenID;
                  AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "GENID");
                  AnyError = 1;
                  GX_FocusControl = edtGenID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtGenSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0M22( ) ;
                  GX_FocusControl = edtGenSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A152GenID != Z152GenID )
               {
                  /* Insert record */
                  GX_FocusControl = edtGenSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0M22( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "GENID");
                     AnyError = 1;
                     GX_FocusControl = edtGenID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtGenSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0M22( ) ;
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
         if ( A152GenID != Z152GenID )
         {
            A152GenID = Z152GenID;
            AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "GENID");
            AnyError = 1;
            GX_FocusControl = edtGenID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtGenSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0M22( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000M2 */
            pr_default.execute(0, new Object[] {A152GenID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_genero"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z537GenDelDataHora != T000M2_A537GenDelDataHora[0] ) || ( Z538GenDelData != T000M2_A538GenDelData[0] ) || ( Z539GenDelHora != T000M2_A539GenDelHora[0] ) || ( StringUtil.StrCmp(Z540GenDelUsuId, T000M2_A540GenDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z541GenDelUsuNome, T000M2_A541GenDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z153GenSigla, T000M2_A153GenSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z154GenNome, T000M2_A154GenNome[0]) != 0 ) || ( Z215GenAtivo != T000M2_A215GenAtivo[0] ) || ( Z536GenDel != T000M2_A536GenDel[0] ) )
            {
               if ( Z537GenDelDataHora != T000M2_A537GenDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z537GenDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A537GenDelDataHora[0]);
               }
               if ( Z538GenDelData != T000M2_A538GenDelData[0] )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDelData");
                  GXUtil.WriteLogRaw("Old: ",Z538GenDelData);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A538GenDelData[0]);
               }
               if ( Z539GenDelHora != T000M2_A539GenDelHora[0] )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z539GenDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A539GenDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z540GenDelUsuId, T000M2_A540GenDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z540GenDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A540GenDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z541GenDelUsuNome, T000M2_A541GenDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z541GenDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A541GenDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z153GenSigla, T000M2_A153GenSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenSigla");
                  GXUtil.WriteLogRaw("Old: ",Z153GenSigla);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A153GenSigla[0]);
               }
               if ( StringUtil.StrCmp(Z154GenNome, T000M2_A154GenNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenNome");
                  GXUtil.WriteLogRaw("Old: ",Z154GenNome);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A154GenNome[0]);
               }
               if ( Z215GenAtivo != T000M2_A215GenAtivo[0] )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z215GenAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A215GenAtivo[0]);
               }
               if ( Z536GenDel != T000M2_A536GenDel[0] )
               {
                  GXUtil.WriteLog("core.genero:[seudo value changed for attri]"+"GenDel");
                  GXUtil.WriteLogRaw("Old: ",Z536GenDel);
                  GXUtil.WriteLogRaw("Current: ",T000M2_A536GenDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_genero"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0M22( )
      {
         if ( ! IsAuthorized("genero_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0M22( 0) ;
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M9 */
                     pr_default.execute(7, new Object[] {n537GenDelDataHora, A537GenDelDataHora, n538GenDelData, A538GenDelData, n539GenDelHora, A539GenDelHora, n540GenDelUsuId, A540GenDelUsuId, n541GenDelUsuNome, A541GenDelUsuNome, A153GenSigla, A154GenNome, A215GenAtivo, A536GenDel});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000M10 */
                     pr_default.execute(8);
                     A152GenID = T000M10_A152GenID[0];
                     AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_genero");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0M0( ) ;
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
               Load0M22( ) ;
            }
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void Update0M22( )
      {
         if ( ! IsAuthorized("genero_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0M22( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0M22( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000M11 */
                     pr_default.execute(9, new Object[] {n537GenDelDataHora, A537GenDelDataHora, n538GenDelData, A538GenDelData, n539GenDelHora, A539GenDelHora, n540GenDelUsuId, A540GenDelUsuId, n541GenDelUsuNome, A541GenDelUsuNome, A153GenSigla, A154GenNome, A215GenAtivo, A536GenDel, A152GenID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_genero");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_genero"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0M22( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_generoupdateredundancy(context ).execute( ref  A152GenID) ;
                        AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
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
            EndLevel0M22( ) ;
         }
         CloseExtendedTableCursors0M22( ) ;
      }

      protected void DeferredUpdate0M22( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("genero_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0M22( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0M22( ) ;
            AfterConfirm0M22( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0M22( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000M12 */
                  pr_default.execute(10, new Object[] {A152GenID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_genero");
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
         sMode22 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0M22( ) ;
         Gx_mode = sMode22;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0M22( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000M13 */
            pr_default.execute(11, new Object[] {A152GenID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0M22( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0M22( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.genero",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0M0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.genero",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0M22( )
      {
         /* Scan By routine */
         /* Using cursor T000M14 */
         pr_default.execute(12);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound22 = 1;
            A152GenID = T000M14_A152GenID[0];
            AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0M22( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound22 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound22 = 1;
            A152GenID = T000M14_A152GenID[0];
            AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
         }
      }

      protected void ScanEnd0M22( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0M22( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0M22( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0M22( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A537GenDelDataHora = DateTimeUtil.NowMS( context);
            n537GenDelDataHora = false;
            AssignAttri("", false, "A537GenDelDataHora", context.localUtil.TToC( A537GenDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A540GenDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n540GenDelUsuId = false;
            AssignAttri("", false, "A540GenDelUsuId", A540GenDelUsuId);
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A541GenDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n541GenDelUsuNome = false;
            AssignAttri("", false, "A541GenDelUsuNome", A541GenDelUsuNome);
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A538GenDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A537GenDelDataHora) ) ;
            n538GenDelData = false;
            AssignAttri("", false, "A538GenDelData", context.localUtil.TToC( A538GenDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A536GenDel && ( O536GenDel != A536GenDel ) )
         {
            A539GenDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A537GenDelDataHora));
            n539GenDelHora = false;
            AssignAttri("", false, "A539GenDelHora", context.localUtil.TToC( A539GenDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0M22( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
      }

      protected void BeforeComplete0M22( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0M22( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0M22( )
      {
         edtGenSigla_Enabled = 0;
         AssignProp("", false, edtGenSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGenSigla_Enabled), 5, 0), true);
         edtGenNome_Enabled = 0;
         AssignProp("", false, edtGenNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGenNome_Enabled), 5, 0), true);
         edtGenID_Enabled = 0;
         AssignProp("", false, edtGenID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtGenID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0M22( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0M0( )
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
         GXEncryptionTmp = "core.genero.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13GenID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.genero.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Genero");
         forbiddenHiddens.Add("GenID", context.localUtil.Format( (decimal)(A152GenID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV15Pgmname, "")));
         forbiddenHiddens.Add("GenAtivo", StringUtil.BoolToStr( A215GenAtivo));
         forbiddenHiddens.Add("GenDel", StringUtil.BoolToStr( A536GenDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\genero:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z152GenID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z152GenID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z537GenDelDataHora", context.localUtil.TToC( Z537GenDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z538GenDelData", context.localUtil.TToC( Z538GenDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z539GenDelHora", context.localUtil.TToC( Z539GenDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z540GenDelUsuId", StringUtil.RTrim( Z540GenDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z541GenDelUsuNome", Z541GenDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z153GenSigla", Z153GenSigla);
         GxWebStd.gx_hidden_field( context, "Z154GenNome", Z154GenNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z215GenAtivo", Z215GenAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z536GenDel", Z536GenDel);
         GxWebStd.gx_boolean_hidden_field( context, "O536GenDel", O536GenDel);
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
         GxWebStd.gx_hidden_field( context, "vGENID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13GenID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vGENID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV13GenID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "GENDEL", A536GenDel);
         GxWebStd.gx_hidden_field( context, "GENDELDATAHORA", context.localUtil.TToC( A537GenDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GENDELDATA", context.localUtil.TToC( A538GenDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GENDELHORA", context.localUtil.TToC( A539GenDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "GENDELUSUID", StringUtil.RTrim( A540GenDelUsuId));
         GxWebStd.gx_hidden_field( context, "GENDELUSUNOME", A541GenDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "GENATIVO", A215GenAtivo);
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
         GXEncryptionTmp = "core.genero.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV13GenID,9,0));
         return formatLink("core.genero.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Genero" ;
      }

      public override string GetPgmdesc( )
      {
         return "Genero da Pessoa" ;
      }

      protected void InitializeNonKey0M22( )
      {
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A537GenDelDataHora = (DateTime)(DateTime.MinValue);
         n537GenDelDataHora = false;
         AssignAttri("", false, "A537GenDelDataHora", context.localUtil.TToC( A537GenDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A538GenDelData = (DateTime)(DateTime.MinValue);
         n538GenDelData = false;
         AssignAttri("", false, "A538GenDelData", context.localUtil.TToC( A538GenDelData, 10, 5, 0, 3, "/", ":", " "));
         A539GenDelHora = (DateTime)(DateTime.MinValue);
         n539GenDelHora = false;
         AssignAttri("", false, "A539GenDelHora", context.localUtil.TToC( A539GenDelHora, 0, 5, 0, 3, "/", ":", " "));
         A540GenDelUsuId = "";
         n540GenDelUsuId = false;
         AssignAttri("", false, "A540GenDelUsuId", A540GenDelUsuId);
         A541GenDelUsuNome = "";
         n541GenDelUsuNome = false;
         AssignAttri("", false, "A541GenDelUsuNome", A541GenDelUsuNome);
         A153GenSigla = "";
         AssignAttri("", false, "A153GenSigla", A153GenSigla);
         A154GenNome = "";
         AssignAttri("", false, "A154GenNome", A154GenNome);
         A536GenDel = false;
         AssignAttri("", false, "A536GenDel", A536GenDel);
         A215GenAtivo = true;
         AssignAttri("", false, "A215GenAtivo", A215GenAtivo);
         O536GenDel = A536GenDel;
         AssignAttri("", false, "A536GenDel", A536GenDel);
         Z537GenDelDataHora = (DateTime)(DateTime.MinValue);
         Z538GenDelData = (DateTime)(DateTime.MinValue);
         Z539GenDelHora = (DateTime)(DateTime.MinValue);
         Z540GenDelUsuId = "";
         Z541GenDelUsuNome = "";
         Z153GenSigla = "";
         Z154GenNome = "";
         Z215GenAtivo = false;
         Z536GenDel = false;
      }

      protected void InitAll0M22( )
      {
         A152GenID = 0;
         AssignAttri("", false, "A152GenID", StringUtil.LTrimStr( (decimal)(A152GenID), 9, 0));
         InitializeNonKey0M22( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A215GenAtivo = i215GenAtivo;
         AssignAttri("", false, "A215GenAtivo", A215GenAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382813252", true, true);
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
         context.AddJavascriptSource("core/genero.js", "?202382813254", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtGenSigla_Internalname = "GENSIGLA";
         edtGenNome_Internalname = "GENNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtGenID_Internalname = "GENID";
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
         Form.Caption = "Genero da Pessoa";
         edtGenID_Jsonclick = "";
         edtGenID_Enabled = 0;
         edtGenID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtGenNome_Jsonclick = "";
         edtGenNome_Enabled = 1;
         edtGenSigla_Jsonclick = "";
         edtGenSigla_Enabled = 1;
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

      protected void XC_11_0M22( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A152GenID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
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

      protected void XC_12_0M22( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A152GenID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditgenero(context ).execute(  "Y", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
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

      protected void XC_13_0M22( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A152GenID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
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

      protected void XC_14_0M22( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ,
                                 int A152GenID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditgenero(context ).execute(  "N", ref  AV14AuditingObject,  A152GenID,  Gx_mode) ;
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

      public void Valid_Gensigla( )
      {
         /* Using cursor T000M15 */
         pr_default.execute(13, new Object[] {A153GenSigla, A152GenID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "GENSIGLA");
            AnyError = 1;
            GX_FocusControl = edtGenSigla_Internalname;
         }
         pr_default.close(13);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A153GenSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "GENSIGLA");
            AnyError = 1;
            GX_FocusControl = edtGenSigla_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV13GenID',fld:'vGENID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV13GenID',fld:'vGENID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A152GenID',fld:'GENID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A215GenAtivo',fld:'GENATIVO',pic:''},{av:'A536GenDel',fld:'GENDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120M2',iparms:[{av:'AV14AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV15Pgmname',fld:'vPGMNAME',pic:''},{av:'A152GenID',fld:'GENID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A153GenSigla',fld:'GENSIGLA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_GENSIGLA","{handler:'Valid_Gensigla',iparms:[{av:'A153GenSigla',fld:'GENSIGLA',pic:''},{av:'A152GenID',fld:'GENID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_GENSIGLA",",oparms:[]}");
         setEventMetadata("VALID_GENNOME","{handler:'Valid_Gennome',iparms:[]");
         setEventMetadata("VALID_GENNOME",",oparms:[]}");
         setEventMetadata("VALID_GENID","{handler:'Valid_Genid',iparms:[]");
         setEventMetadata("VALID_GENID",",oparms:[]}");
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
         Z537GenDelDataHora = (DateTime)(DateTime.MinValue);
         Z538GenDelData = (DateTime)(DateTime.MinValue);
         Z539GenDelHora = (DateTime)(DateTime.MinValue);
         Z540GenDelUsuId = "";
         Z541GenDelUsuNome = "";
         Z153GenSigla = "";
         Z154GenNome = "";
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
         A153GenSigla = "";
         A154GenNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A537GenDelDataHora = (DateTime)(DateTime.MinValue);
         A538GenDelData = (DateTime)(DateTime.MinValue);
         A539GenDelHora = (DateTime)(DateTime.MinValue);
         A540GenDelUsuId = "";
         A541GenDelUsuNome = "";
         AV14AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV15Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode22 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         T000M4_A152GenID = new int[1] ;
         T000M4_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000M4_n537GenDelDataHora = new bool[] {false} ;
         T000M4_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         T000M4_n538GenDelData = new bool[] {false} ;
         T000M4_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         T000M4_n539GenDelHora = new bool[] {false} ;
         T000M4_A540GenDelUsuId = new string[] {""} ;
         T000M4_n540GenDelUsuId = new bool[] {false} ;
         T000M4_A541GenDelUsuNome = new string[] {""} ;
         T000M4_n541GenDelUsuNome = new bool[] {false} ;
         T000M4_A153GenSigla = new string[] {""} ;
         T000M4_A154GenNome = new string[] {""} ;
         T000M4_A215GenAtivo = new bool[] {false} ;
         T000M4_A536GenDel = new bool[] {false} ;
         T000M5_A153GenSigla = new string[] {""} ;
         T000M6_A152GenID = new int[1] ;
         T000M3_A152GenID = new int[1] ;
         T000M3_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000M3_n537GenDelDataHora = new bool[] {false} ;
         T000M3_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         T000M3_n538GenDelData = new bool[] {false} ;
         T000M3_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         T000M3_n539GenDelHora = new bool[] {false} ;
         T000M3_A540GenDelUsuId = new string[] {""} ;
         T000M3_n540GenDelUsuId = new bool[] {false} ;
         T000M3_A541GenDelUsuNome = new string[] {""} ;
         T000M3_n541GenDelUsuNome = new bool[] {false} ;
         T000M3_A153GenSigla = new string[] {""} ;
         T000M3_A154GenNome = new string[] {""} ;
         T000M3_A215GenAtivo = new bool[] {false} ;
         T000M3_A536GenDel = new bool[] {false} ;
         T000M7_A152GenID = new int[1] ;
         T000M8_A152GenID = new int[1] ;
         T000M2_A152GenID = new int[1] ;
         T000M2_A537GenDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000M2_n537GenDelDataHora = new bool[] {false} ;
         T000M2_A538GenDelData = new DateTime[] {DateTime.MinValue} ;
         T000M2_n538GenDelData = new bool[] {false} ;
         T000M2_A539GenDelHora = new DateTime[] {DateTime.MinValue} ;
         T000M2_n539GenDelHora = new bool[] {false} ;
         T000M2_A540GenDelUsuId = new string[] {""} ;
         T000M2_n540GenDelUsuId = new bool[] {false} ;
         T000M2_A541GenDelUsuNome = new string[] {""} ;
         T000M2_n541GenDelUsuNome = new bool[] {false} ;
         T000M2_A153GenSigla = new string[] {""} ;
         T000M2_A154GenNome = new string[] {""} ;
         T000M2_A215GenAtivo = new bool[] {false} ;
         T000M2_A536GenDel = new bool[] {false} ;
         T000M10_A152GenID = new int[1] ;
         T000M13_A158CliID = new Guid[] {Guid.Empty} ;
         T000M13_A166CpjID = new Guid[] {Guid.Empty} ;
         T000M13_A269CpjConSeq = new short[1] ;
         T000M14_A152GenID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000M15_A153GenSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.genero__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.genero__default(),
            new Object[][] {
                new Object[] {
               T000M2_A152GenID, T000M2_A537GenDelDataHora, T000M2_n537GenDelDataHora, T000M2_A538GenDelData, T000M2_n538GenDelData, T000M2_A539GenDelHora, T000M2_n539GenDelHora, T000M2_A540GenDelUsuId, T000M2_n540GenDelUsuId, T000M2_A541GenDelUsuNome,
               T000M2_n541GenDelUsuNome, T000M2_A153GenSigla, T000M2_A154GenNome, T000M2_A215GenAtivo, T000M2_A536GenDel
               }
               , new Object[] {
               T000M3_A152GenID, T000M3_A537GenDelDataHora, T000M3_n537GenDelDataHora, T000M3_A538GenDelData, T000M3_n538GenDelData, T000M3_A539GenDelHora, T000M3_n539GenDelHora, T000M3_A540GenDelUsuId, T000M3_n540GenDelUsuId, T000M3_A541GenDelUsuNome,
               T000M3_n541GenDelUsuNome, T000M3_A153GenSigla, T000M3_A154GenNome, T000M3_A215GenAtivo, T000M3_A536GenDel
               }
               , new Object[] {
               T000M4_A152GenID, T000M4_A537GenDelDataHora, T000M4_n537GenDelDataHora, T000M4_A538GenDelData, T000M4_n538GenDelData, T000M4_A539GenDelHora, T000M4_n539GenDelHora, T000M4_A540GenDelUsuId, T000M4_n540GenDelUsuId, T000M4_A541GenDelUsuNome,
               T000M4_n541GenDelUsuNome, T000M4_A153GenSigla, T000M4_A154GenNome, T000M4_A215GenAtivo, T000M4_A536GenDel
               }
               , new Object[] {
               T000M5_A153GenSigla
               }
               , new Object[] {
               T000M6_A152GenID
               }
               , new Object[] {
               T000M7_A152GenID
               }
               , new Object[] {
               T000M8_A152GenID
               }
               , new Object[] {
               }
               , new Object[] {
               T000M10_A152GenID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000M13_A158CliID, T000M13_A166CpjID, T000M13_A269CpjConSeq
               }
               , new Object[] {
               T000M14_A152GenID
               }
               , new Object[] {
               T000M15_A153GenSigla
               }
            }
         );
         Z215GenAtivo = true;
         A215GenAtivo = true;
         i215GenAtivo = true;
         AV15Pgmname = "core.Genero";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound22 ;
      private short GX_JID ;
      private short nIsDirty_22 ;
      private short gxajaxcallmode ;
      private int wcpOAV13GenID ;
      private int Z152GenID ;
      private int AV13GenID ;
      private int trnEnded ;
      private int edtGenSigla_Enabled ;
      private int edtGenNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A152GenID ;
      private int edtGenID_Enabled ;
      private int edtGenID_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z540GenDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtGenSigla_Internalname ;
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
      private string edtGenSigla_Jsonclick ;
      private string edtGenNome_Internalname ;
      private string edtGenNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtGenID_Internalname ;
      private string edtGenID_Jsonclick ;
      private string A540GenDelUsuId ;
      private string AV15Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode22 ;
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
      private DateTime Z537GenDelDataHora ;
      private DateTime Z538GenDelData ;
      private DateTime Z539GenDelHora ;
      private DateTime A537GenDelDataHora ;
      private DateTime A538GenDelData ;
      private DateTime A539GenDelHora ;
      private bool Z215GenAtivo ;
      private bool Z536GenDel ;
      private bool O536GenDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n537GenDelDataHora ;
      private bool n538GenDelData ;
      private bool n539GenDelHora ;
      private bool n540GenDelUsuId ;
      private bool n541GenDelUsuNome ;
      private bool A215GenAtivo ;
      private bool A536GenDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i215GenAtivo ;
      private string Z541GenDelUsuNome ;
      private string Z153GenSigla ;
      private string Z154GenNome ;
      private string A153GenSigla ;
      private string A154GenNome ;
      private string A541GenDelUsuNome ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000M4_A152GenID ;
      private DateTime[] T000M4_A537GenDelDataHora ;
      private bool[] T000M4_n537GenDelDataHora ;
      private DateTime[] T000M4_A538GenDelData ;
      private bool[] T000M4_n538GenDelData ;
      private DateTime[] T000M4_A539GenDelHora ;
      private bool[] T000M4_n539GenDelHora ;
      private string[] T000M4_A540GenDelUsuId ;
      private bool[] T000M4_n540GenDelUsuId ;
      private string[] T000M4_A541GenDelUsuNome ;
      private bool[] T000M4_n541GenDelUsuNome ;
      private string[] T000M4_A153GenSigla ;
      private string[] T000M4_A154GenNome ;
      private bool[] T000M4_A215GenAtivo ;
      private bool[] T000M4_A536GenDel ;
      private string[] T000M5_A153GenSigla ;
      private int[] T000M6_A152GenID ;
      private int[] T000M3_A152GenID ;
      private DateTime[] T000M3_A537GenDelDataHora ;
      private bool[] T000M3_n537GenDelDataHora ;
      private DateTime[] T000M3_A538GenDelData ;
      private bool[] T000M3_n538GenDelData ;
      private DateTime[] T000M3_A539GenDelHora ;
      private bool[] T000M3_n539GenDelHora ;
      private string[] T000M3_A540GenDelUsuId ;
      private bool[] T000M3_n540GenDelUsuId ;
      private string[] T000M3_A541GenDelUsuNome ;
      private bool[] T000M3_n541GenDelUsuNome ;
      private string[] T000M3_A153GenSigla ;
      private string[] T000M3_A154GenNome ;
      private bool[] T000M3_A215GenAtivo ;
      private bool[] T000M3_A536GenDel ;
      private int[] T000M7_A152GenID ;
      private int[] T000M8_A152GenID ;
      private int[] T000M2_A152GenID ;
      private DateTime[] T000M2_A537GenDelDataHora ;
      private bool[] T000M2_n537GenDelDataHora ;
      private DateTime[] T000M2_A538GenDelData ;
      private bool[] T000M2_n538GenDelData ;
      private DateTime[] T000M2_A539GenDelHora ;
      private bool[] T000M2_n539GenDelHora ;
      private string[] T000M2_A540GenDelUsuId ;
      private bool[] T000M2_n540GenDelUsuId ;
      private string[] T000M2_A541GenDelUsuNome ;
      private bool[] T000M2_n541GenDelUsuNome ;
      private string[] T000M2_A153GenSigla ;
      private string[] T000M2_A154GenNome ;
      private bool[] T000M2_A215GenAtivo ;
      private bool[] T000M2_A536GenDel ;
      private int[] T000M10_A152GenID ;
      private Guid[] T000M13_A158CliID ;
      private Guid[] T000M13_A166CpjID ;
      private short[] T000M13_A269CpjConSeq ;
      private int[] T000M14_A152GenID ;
      private string[] T000M15_A153GenSigla ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV14AuditingObject ;
   }

   public class genero__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class genero__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000M4;
        prmT000M4 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M5;
        prmT000M5 = new Object[] {
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M6;
        prmT000M6 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M3;
        prmT000M3 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M7;
        prmT000M7 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M8;
        prmT000M8 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M2;
        prmT000M2 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M9;
        prmT000M9 = new Object[] {
        new ParDef("GenDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("GenDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("GenDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("GenDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("GenDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenNome",GXType.VarChar,80,0) ,
        new ParDef("GenAtivo",GXType.Boolean,4,0) ,
        new ParDef("GenDel",GXType.Boolean,4,0)
        };
        Object[] prmT000M10;
        prmT000M10 = new Object[] {
        };
        Object[] prmT000M11;
        prmT000M11 = new Object[] {
        new ParDef("GenDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("GenDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("GenDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("GenDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("GenDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenNome",GXType.VarChar,80,0) ,
        new ParDef("GenAtivo",GXType.Boolean,4,0) ,
        new ParDef("GenDel",GXType.Boolean,4,0) ,
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M12;
        prmT000M12 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M13;
        prmT000M13 = new Object[] {
        new ParDef("GenID",GXType.Int32,9,0)
        };
        Object[] prmT000M14;
        prmT000M14 = new Object[] {
        };
        Object[] prmT000M15;
        prmT000M15 = new Object[] {
        new ParDef("GenSigla",GXType.VarChar,20,0) ,
        new ParDef("GenID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000M2", "SELECT GenID, GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel FROM tb_genero WHERE GenID = :GenID  FOR UPDATE OF tb_genero NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000M2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M3", "SELECT GenID, GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel FROM tb_genero WHERE GenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M4", "SELECT TM1.GenID, TM1.GenDelDataHora, TM1.GenDelData, TM1.GenDelHora, TM1.GenDelUsuId, TM1.GenDelUsuNome, TM1.GenSigla, TM1.GenNome, TM1.GenAtivo, TM1.GenDel FROM tb_genero TM1 WHERE TM1.GenID = :GenID ORDER BY TM1.GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M5", "SELECT GenSigla FROM tb_genero WHERE (GenSigla = :GenSigla) AND (Not ( GenID = :GenID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M6", "SELECT GenID FROM tb_genero WHERE GenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M7", "SELECT GenID FROM tb_genero WHERE ( GenID > :GenID) ORDER BY GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M8", "SELECT GenID FROM tb_genero WHERE ( GenID < :GenID) ORDER BY GenID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M9", "SAVEPOINT gxupdate;INSERT INTO tb_genero(GenDelDataHora, GenDelData, GenDelHora, GenDelUsuId, GenDelUsuNome, GenSigla, GenNome, GenAtivo, GenDel) VALUES(:GenDelDataHora, :GenDelData, :GenDelHora, :GenDelUsuId, :GenDelUsuNome, :GenSigla, :GenNome, :GenAtivo, :GenDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000M9)
           ,new CursorDef("T000M10", "SELECT currval('GenID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M11", "SAVEPOINT gxupdate;UPDATE tb_genero SET GenDelDataHora=:GenDelDataHora, GenDelData=:GenDelData, GenDelHora=:GenDelHora, GenDelUsuId=:GenDelUsuId, GenDelUsuNome=:GenDelUsuNome, GenSigla=:GenSigla, GenNome=:GenNome, GenAtivo=:GenAtivo, GenDel=:GenDel  WHERE GenID = :GenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M11)
           ,new CursorDef("T000M12", "SAVEPOINT gxupdate;DELETE FROM tb_genero  WHERE GenID = :GenID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000M12)
           ,new CursorDef("T000M13", "SELECT CliID, CpjID, CpjConSeq FROM tb_clientepj_contato WHERE CpjConGenID = :GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000M14", "SELECT GenID FROM tb_genero ORDER BY GenID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000M15", "SELECT GenSigla FROM tb_genero WHERE (GenSigla = :GenSigla) AND (Not ( GenID = :GenID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000M15,1, GxCacheFrequency.OFF ,true,false )
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
