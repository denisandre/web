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
   public class centrodecusto : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.centrodecusto.aspx")), "core.centrodecusto.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.centrodecusto.aspx")))) ;
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
                  AV7CcuID = (int)(Math.Round(NumberUtil.Val( GetPar( "CcuID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7CcuID", StringUtil.LTrimStr( (decimal)(AV7CcuID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vCCUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CcuID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Centro De Custo", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCcuSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public centrodecusto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public centrodecusto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_CcuID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CcuID = aP1_CcuID;
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
            return "centrodecusto_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCcuSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCcuSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCcuSigla_Internalname, A209CcuSigla, StringUtil.RTrim( context.localUtil.Format( A209CcuSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCcuSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCcuSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\CentroDeCusto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCcuNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCcuNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCcuNome_Internalname, A210CcuNome, StringUtil.RTrim( context.localUtil.Format( A210CcuNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCcuNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCcuNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\CentroDeCusto.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\CentroDeCusto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\CentroDeCusto.htm");
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
         GxWebStd.gx_single_line_edit( context, edtCcuID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A208CcuID), 11, 0, ",", "")), StringUtil.LTrim( ((edtCcuID_Enabled!=0) ? context.localUtil.Format( (decimal)(A208CcuID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A208CcuID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCcuID_Jsonclick, 0, "Attribute", "", "", "", "", edtCcuID_Visible, edtCcuID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\CentroDeCusto.htm");
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
         E110Q2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z208CcuID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z208CcuID"), ",", "."), 18, MidpointRounding.ToEven));
               Z513CcuDelDataHora = context.localUtil.CToT( cgiGet( "Z513CcuDelDataHora"), 0);
               n513CcuDelDataHora = ((DateTime.MinValue==A513CcuDelDataHora) ? true : false);
               Z514CcuDelData = context.localUtil.CToT( cgiGet( "Z514CcuDelData"), 0);
               n514CcuDelData = ((DateTime.MinValue==A514CcuDelData) ? true : false);
               Z515CcuDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z515CcuDelHora"), 0));
               n515CcuDelHora = ((DateTime.MinValue==A515CcuDelHora) ? true : false);
               Z516CcuDelUsuId = cgiGet( "Z516CcuDelUsuId");
               n516CcuDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A516CcuDelUsuId)) ? true : false);
               Z517CcuDelUsuNome = cgiGet( "Z517CcuDelUsuNome");
               n517CcuDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A517CcuDelUsuNome)) ? true : false);
               Z209CcuSigla = cgiGet( "Z209CcuSigla");
               Z210CcuNome = cgiGet( "Z210CcuNome");
               Z218CcuAtivo = StringUtil.StrToBool( cgiGet( "Z218CcuAtivo"));
               Z512CcuDel = StringUtil.StrToBool( cgiGet( "Z512CcuDel"));
               A513CcuDelDataHora = context.localUtil.CToT( cgiGet( "Z513CcuDelDataHora"), 0);
               n513CcuDelDataHora = false;
               n513CcuDelDataHora = ((DateTime.MinValue==A513CcuDelDataHora) ? true : false);
               A514CcuDelData = context.localUtil.CToT( cgiGet( "Z514CcuDelData"), 0);
               n514CcuDelData = false;
               n514CcuDelData = ((DateTime.MinValue==A514CcuDelData) ? true : false);
               A515CcuDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z515CcuDelHora"), 0));
               n515CcuDelHora = false;
               n515CcuDelHora = ((DateTime.MinValue==A515CcuDelHora) ? true : false);
               A516CcuDelUsuId = cgiGet( "Z516CcuDelUsuId");
               n516CcuDelUsuId = false;
               n516CcuDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A516CcuDelUsuId)) ? true : false);
               A517CcuDelUsuNome = cgiGet( "Z517CcuDelUsuNome");
               n517CcuDelUsuNome = false;
               n517CcuDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A517CcuDelUsuNome)) ? true : false);
               A218CcuAtivo = StringUtil.StrToBool( cgiGet( "Z218CcuAtivo"));
               A512CcuDel = StringUtil.StrToBool( cgiGet( "Z512CcuDel"));
               O512CcuDel = StringUtil.StrToBool( cgiGet( "O512CcuDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CcuID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vCCUID"), ",", "."), 18, MidpointRounding.ToEven));
               A512CcuDel = StringUtil.StrToBool( cgiGet( "CCUDEL"));
               A513CcuDelDataHora = context.localUtil.CToT( cgiGet( "CCUDELDATAHORA"), 0);
               n513CcuDelDataHora = ((DateTime.MinValue==A513CcuDelDataHora) ? true : false);
               A514CcuDelData = context.localUtil.CToT( cgiGet( "CCUDELDATA"), 0);
               n514CcuDelData = ((DateTime.MinValue==A514CcuDelData) ? true : false);
               A515CcuDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CCUDELHORA"), 0));
               n515CcuDelHora = ((DateTime.MinValue==A515CcuDelHora) ? true : false);
               A516CcuDelUsuId = cgiGet( "CCUDELUSUID");
               n516CcuDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A516CcuDelUsuId)) ? true : false);
               A517CcuDelUsuNome = cgiGet( "CCUDELUSUNOME");
               n517CcuDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A517CcuDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A218CcuAtivo = StringUtil.StrToBool( cgiGet( "CCUATIVO"));
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
               A209CcuSigla = cgiGet( edtCcuSigla_Internalname);
               AssignAttri("", false, "A209CcuSigla", A209CcuSigla);
               A210CcuNome = StringUtil.Upper( cgiGet( edtCcuNome_Internalname));
               AssignAttri("", false, "A210CcuNome", A210CcuNome);
               A208CcuID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCcuID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"CentroDeCusto");
               A208CcuID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtCcuID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
               forbiddenHiddens.Add("CcuID", context.localUtil.Format( (decimal)(A208CcuID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("CcuAtivo", StringUtil.BoolToStr( A218CcuAtivo));
               forbiddenHiddens.Add("CcuDel", StringUtil.BoolToStr( A512CcuDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A208CcuID != Z208CcuID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\centrodecusto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A208CcuID = (int)(Math.Round(NumberUtil.Val( GetPar( "CcuID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
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
                     sMode26 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode26;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound26 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0Q0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CCUID");
                        AnyError = 1;
                        GX_FocusControl = edtCcuID_Internalname;
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
                           E110Q2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120Q2 ();
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
            E120Q2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0Q26( ) ;
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
            DisableAttributes0Q26( ) ;
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

      protected void CONFIRM_0Q0( )
      {
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0Q26( ) ;
            }
            else
            {
               CheckExtendedTable0Q26( ) ;
               CloseExtendedTableCursors0Q26( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0Q0( )
      {
      }

      protected void E110Q2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtCcuID_Visible = 0;
         AssignProp("", false, edtCcuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCcuID_Visible), 5, 0), true);
      }

      protected void E120Q2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.centrodecustoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM0Q26( short GX_JID )
      {
         if ( ( GX_JID == 15 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z513CcuDelDataHora = T000Q3_A513CcuDelDataHora[0];
               Z514CcuDelData = T000Q3_A514CcuDelData[0];
               Z515CcuDelHora = T000Q3_A515CcuDelHora[0];
               Z516CcuDelUsuId = T000Q3_A516CcuDelUsuId[0];
               Z517CcuDelUsuNome = T000Q3_A517CcuDelUsuNome[0];
               Z209CcuSigla = T000Q3_A209CcuSigla[0];
               Z210CcuNome = T000Q3_A210CcuNome[0];
               Z218CcuAtivo = T000Q3_A218CcuAtivo[0];
               Z512CcuDel = T000Q3_A512CcuDel[0];
            }
            else
            {
               Z513CcuDelDataHora = A513CcuDelDataHora;
               Z514CcuDelData = A514CcuDelData;
               Z515CcuDelHora = A515CcuDelHora;
               Z516CcuDelUsuId = A516CcuDelUsuId;
               Z517CcuDelUsuNome = A517CcuDelUsuNome;
               Z209CcuSigla = A209CcuSigla;
               Z210CcuNome = A210CcuNome;
               Z218CcuAtivo = A218CcuAtivo;
               Z512CcuDel = A512CcuDel;
            }
         }
         if ( GX_JID == -15 )
         {
            Z208CcuID = A208CcuID;
            Z513CcuDelDataHora = A513CcuDelDataHora;
            Z514CcuDelData = A514CcuDelData;
            Z515CcuDelHora = A515CcuDelHora;
            Z516CcuDelUsuId = A516CcuDelUsuId;
            Z517CcuDelUsuNome = A517CcuDelUsuNome;
            Z209CcuSigla = A209CcuSigla;
            Z210CcuNome = A210CcuNome;
            Z218CcuAtivo = A218CcuAtivo;
            Z512CcuDel = A512CcuDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCcuID_Enabled = 0;
         AssignProp("", false, edtCcuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCcuID_Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV14Pgmname = "core.CentroDeCusto";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         edtCcuID_Enabled = 0;
         AssignProp("", false, edtCcuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCcuID_Enabled), 5, 0), true);
         if ( ! (0==AV7CcuID) )
         {
            A208CcuID = AV7CcuID;
            AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
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
         if ( IsIns( )  && (false==A218CcuAtivo) && ( Gx_BScreen == 0 ) )
         {
            A218CcuAtivo = true;
            AssignAttri("", false, "A218CcuAtivo", A218CcuAtivo);
         }
      }

      protected void Load0Q26( )
      {
         /* Using cursor T000Q4 */
         pr_default.execute(2, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound26 = 1;
            A513CcuDelDataHora = T000Q4_A513CcuDelDataHora[0];
            n513CcuDelDataHora = T000Q4_n513CcuDelDataHora[0];
            A514CcuDelData = T000Q4_A514CcuDelData[0];
            n514CcuDelData = T000Q4_n514CcuDelData[0];
            A515CcuDelHora = T000Q4_A515CcuDelHora[0];
            n515CcuDelHora = T000Q4_n515CcuDelHora[0];
            A516CcuDelUsuId = T000Q4_A516CcuDelUsuId[0];
            n516CcuDelUsuId = T000Q4_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = T000Q4_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = T000Q4_n517CcuDelUsuNome[0];
            A209CcuSigla = T000Q4_A209CcuSigla[0];
            AssignAttri("", false, "A209CcuSigla", A209CcuSigla);
            A210CcuNome = T000Q4_A210CcuNome[0];
            AssignAttri("", false, "A210CcuNome", A210CcuNome);
            A218CcuAtivo = T000Q4_A218CcuAtivo[0];
            A512CcuDel = T000Q4_A512CcuDel[0];
            ZM0Q26( -15) ;
         }
         pr_default.close(2);
         OnLoadActions0Q26( ) ;
      }

      protected void OnLoadActions0Q26( )
      {
      }

      protected void CheckExtendedTable0Q26( )
      {
         nIsDirty_26 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000Q5 */
         pr_default.execute(3, new Object[] {A209CcuSigla, A208CcuID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "CCUSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCcuSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A209CcuSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "CCUSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCcuSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A210CcuNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "CCUNOME");
            AnyError = 1;
            GX_FocusControl = edtCcuNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0Q26( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0Q26( )
      {
         /* Using cursor T000Q6 */
         pr_default.execute(4, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound26 = 1;
         }
         else
         {
            RcdFound26 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000Q3 */
         pr_default.execute(1, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0Q26( 15) ;
            RcdFound26 = 1;
            A208CcuID = T000Q3_A208CcuID[0];
            AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
            A513CcuDelDataHora = T000Q3_A513CcuDelDataHora[0];
            n513CcuDelDataHora = T000Q3_n513CcuDelDataHora[0];
            A514CcuDelData = T000Q3_A514CcuDelData[0];
            n514CcuDelData = T000Q3_n514CcuDelData[0];
            A515CcuDelHora = T000Q3_A515CcuDelHora[0];
            n515CcuDelHora = T000Q3_n515CcuDelHora[0];
            A516CcuDelUsuId = T000Q3_A516CcuDelUsuId[0];
            n516CcuDelUsuId = T000Q3_n516CcuDelUsuId[0];
            A517CcuDelUsuNome = T000Q3_A517CcuDelUsuNome[0];
            n517CcuDelUsuNome = T000Q3_n517CcuDelUsuNome[0];
            A209CcuSigla = T000Q3_A209CcuSigla[0];
            AssignAttri("", false, "A209CcuSigla", A209CcuSigla);
            A210CcuNome = T000Q3_A210CcuNome[0];
            AssignAttri("", false, "A210CcuNome", A210CcuNome);
            A218CcuAtivo = T000Q3_A218CcuAtivo[0];
            A512CcuDel = T000Q3_A512CcuDel[0];
            O512CcuDel = A512CcuDel;
            AssignAttri("", false, "A512CcuDel", A512CcuDel);
            Z208CcuID = A208CcuID;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0Q26( ) ;
            if ( AnyError == 1 )
            {
               RcdFound26 = 0;
               InitializeNonKey0Q26( ) ;
            }
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound26 = 0;
            InitializeNonKey0Q26( ) ;
            sMode26 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode26;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0Q26( ) ;
         if ( RcdFound26 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound26 = 0;
         /* Using cursor T000Q7 */
         pr_default.execute(5, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T000Q7_A208CcuID[0] < A208CcuID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T000Q7_A208CcuID[0] > A208CcuID ) ) )
            {
               A208CcuID = T000Q7_A208CcuID[0];
               AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound26 = 0;
         /* Using cursor T000Q8 */
         pr_default.execute(6, new Object[] {A208CcuID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T000Q8_A208CcuID[0] > A208CcuID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T000Q8_A208CcuID[0] < A208CcuID ) ) )
            {
               A208CcuID = T000Q8_A208CcuID[0];
               AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
               RcdFound26 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0Q26( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCcuSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0Q26( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound26 == 1 )
            {
               if ( A208CcuID != Z208CcuID )
               {
                  A208CcuID = Z208CcuID;
                  AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CCUID");
                  AnyError = 1;
                  GX_FocusControl = edtCcuID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCcuSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0Q26( ) ;
                  GX_FocusControl = edtCcuSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A208CcuID != Z208CcuID )
               {
                  /* Insert record */
                  GX_FocusControl = edtCcuSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0Q26( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CCUID");
                     AnyError = 1;
                     GX_FocusControl = edtCcuID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCcuSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0Q26( ) ;
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
         if ( A208CcuID != Z208CcuID )
         {
            A208CcuID = Z208CcuID;
            AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CCUID");
            AnyError = 1;
            GX_FocusControl = edtCcuID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCcuSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0Q26( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000Q2 */
            pr_default.execute(0, new Object[] {A208CcuID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_centrodecusto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z513CcuDelDataHora != T000Q2_A513CcuDelDataHora[0] ) || ( Z514CcuDelData != T000Q2_A514CcuDelData[0] ) || ( Z515CcuDelHora != T000Q2_A515CcuDelHora[0] ) || ( StringUtil.StrCmp(Z516CcuDelUsuId, T000Q2_A516CcuDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z517CcuDelUsuNome, T000Q2_A517CcuDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z209CcuSigla, T000Q2_A209CcuSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z210CcuNome, T000Q2_A210CcuNome[0]) != 0 ) || ( Z218CcuAtivo != T000Q2_A218CcuAtivo[0] ) || ( Z512CcuDel != T000Q2_A512CcuDel[0] ) )
            {
               if ( Z513CcuDelDataHora != T000Q2_A513CcuDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z513CcuDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A513CcuDelDataHora[0]);
               }
               if ( Z514CcuDelData != T000Q2_A514CcuDelData[0] )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDelData");
                  GXUtil.WriteLogRaw("Old: ",Z514CcuDelData);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A514CcuDelData[0]);
               }
               if ( Z515CcuDelHora != T000Q2_A515CcuDelHora[0] )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z515CcuDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A515CcuDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z516CcuDelUsuId, T000Q2_A516CcuDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z516CcuDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A516CcuDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z517CcuDelUsuNome, T000Q2_A517CcuDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z517CcuDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A517CcuDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z209CcuSigla, T000Q2_A209CcuSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuSigla");
                  GXUtil.WriteLogRaw("Old: ",Z209CcuSigla);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A209CcuSigla[0]);
               }
               if ( StringUtil.StrCmp(Z210CcuNome, T000Q2_A210CcuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuNome");
                  GXUtil.WriteLogRaw("Old: ",Z210CcuNome);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A210CcuNome[0]);
               }
               if ( Z218CcuAtivo != T000Q2_A218CcuAtivo[0] )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z218CcuAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A218CcuAtivo[0]);
               }
               if ( Z512CcuDel != T000Q2_A512CcuDel[0] )
               {
                  GXUtil.WriteLog("core.centrodecusto:[seudo value changed for attri]"+"CcuDel");
                  GXUtil.WriteLogRaw("Old: ",Z512CcuDel);
                  GXUtil.WriteLogRaw("Current: ",T000Q2_A512CcuDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_centrodecusto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0Q26( )
      {
         if ( ! IsAuthorized("centrodecusto_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0Q26( 0) ;
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q9 */
                     pr_default.execute(7, new Object[] {n513CcuDelDataHora, A513CcuDelDataHora, n514CcuDelData, A514CcuDelData, n515CcuDelHora, A515CcuDelHora, n516CcuDelUsuId, A516CcuDelUsuId, n517CcuDelUsuNome, A517CcuDelUsuNome, A209CcuSigla, A210CcuNome, A218CcuAtivo, A512CcuDel});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000Q10 */
                     pr_default.execute(8);
                     A208CcuID = T000Q10_A208CcuID[0];
                     AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0Q0( ) ;
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
               Load0Q26( ) ;
            }
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void Update0Q26( )
      {
         if ( ! IsAuthorized("centrodecusto_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0Q26( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0Q26( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000Q11 */
                     pr_default.execute(9, new Object[] {n513CcuDelDataHora, A513CcuDelDataHora, n514CcuDelData, A514CcuDelData, n515CcuDelHora, A515CcuDelHora, n516CcuDelUsuId, A516CcuDelUsuId, n517CcuDelUsuNome, A517CcuDelUsuNome, A209CcuSigla, A210CcuNome, A218CcuAtivo, A512CcuDel, A208CcuID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_centrodecusto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0Q26( ) ;
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
            EndLevel0Q26( ) ;
         }
         CloseExtendedTableCursors0Q26( ) ;
      }

      protected void DeferredUpdate0Q26( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("centrodecusto_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0Q26( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0Q26( ) ;
            AfterConfirm0Q26( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0Q26( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000Q12 */
                  pr_default.execute(10, new Object[] {A208CcuID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_centrodecusto");
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
         sMode26 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0Q26( ) ;
         Gx_mode = sMode26;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0Q26( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0Q26( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0Q26( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.centrodecusto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0Q0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.centrodecusto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0Q26( )
      {
         /* Scan By routine */
         /* Using cursor T000Q13 */
         pr_default.execute(11);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound26 = 1;
            A208CcuID = T000Q13_A208CcuID[0];
            AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0Q26( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound26 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound26 = 1;
            A208CcuID = T000Q13_A208CcuID[0];
            AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
         }
      }

      protected void ScanEnd0Q26( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm0Q26( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0Q26( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0Q26( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A513CcuDelDataHora = DateTimeUtil.NowMS( context);
            n513CcuDelDataHora = false;
            AssignAttri("", false, "A513CcuDelDataHora", context.localUtil.TToC( A513CcuDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A516CcuDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n516CcuDelUsuId = false;
            AssignAttri("", false, "A516CcuDelUsuId", A516CcuDelUsuId);
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A517CcuDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n517CcuDelUsuNome = false;
            AssignAttri("", false, "A517CcuDelUsuNome", A517CcuDelUsuNome);
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A514CcuDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A513CcuDelDataHora) ) ;
            n514CcuDelData = false;
            AssignAttri("", false, "A514CcuDelData", context.localUtil.TToC( A514CcuDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A512CcuDel && ( O512CcuDel != A512CcuDel ) )
         {
            A515CcuDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A513CcuDelDataHora));
            n515CcuDelHora = false;
            AssignAttri("", false, "A515CcuDelHora", context.localUtil.TToC( A515CcuDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0Q26( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
      }

      protected void BeforeComplete0Q26( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0Q26( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0Q26( )
      {
         edtCcuSigla_Enabled = 0;
         AssignProp("", false, edtCcuSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCcuSigla_Enabled), 5, 0), true);
         edtCcuNome_Enabled = 0;
         AssignProp("", false, edtCcuNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCcuNome_Enabled), 5, 0), true);
         edtCcuID_Enabled = 0;
         AssignProp("", false, edtCcuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCcuID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0Q26( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0Q0( )
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
         GXEncryptionTmp = "core.centrodecusto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CcuID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.centrodecusto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"CentroDeCusto");
         forbiddenHiddens.Add("CcuID", context.localUtil.Format( (decimal)(A208CcuID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("CcuAtivo", StringUtil.BoolToStr( A218CcuAtivo));
         forbiddenHiddens.Add("CcuDel", StringUtil.BoolToStr( A512CcuDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\centrodecusto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z208CcuID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z208CcuID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z513CcuDelDataHora", context.localUtil.TToC( Z513CcuDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z514CcuDelData", context.localUtil.TToC( Z514CcuDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z515CcuDelHora", context.localUtil.TToC( Z515CcuDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z516CcuDelUsuId", StringUtil.RTrim( Z516CcuDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z517CcuDelUsuNome", Z517CcuDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z209CcuSigla", Z209CcuSigla);
         GxWebStd.gx_hidden_field( context, "Z210CcuNome", Z210CcuNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z218CcuAtivo", Z218CcuAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z512CcuDel", Z512CcuDel);
         GxWebStd.gx_boolean_hidden_field( context, "O512CcuDel", O512CcuDel);
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
         GxWebStd.gx_hidden_field( context, "vCCUID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7CcuID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vCCUID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7CcuID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "CCUDEL", A512CcuDel);
         GxWebStd.gx_hidden_field( context, "CCUDELDATAHORA", context.localUtil.TToC( A513CcuDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CCUDELDATA", context.localUtil.TToC( A514CcuDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CCUDELHORA", context.localUtil.TToC( A515CcuDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CCUDELUSUID", StringUtil.RTrim( A516CcuDelUsuId));
         GxWebStd.gx_hidden_field( context, "CCUDELUSUNOME", A517CcuDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CCUATIVO", A218CcuAtivo);
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
         GXEncryptionTmp = "core.centrodecusto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7CcuID,9,0));
         return formatLink("core.centrodecusto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.CentroDeCusto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Centro De Custo" ;
      }

      protected void InitializeNonKey0Q26( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         n513CcuDelDataHora = false;
         AssignAttri("", false, "A513CcuDelDataHora", context.localUtil.TToC( A513CcuDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A514CcuDelData = (DateTime)(DateTime.MinValue);
         n514CcuDelData = false;
         AssignAttri("", false, "A514CcuDelData", context.localUtil.TToC( A514CcuDelData, 10, 5, 0, 3, "/", ":", " "));
         A515CcuDelHora = (DateTime)(DateTime.MinValue);
         n515CcuDelHora = false;
         AssignAttri("", false, "A515CcuDelHora", context.localUtil.TToC( A515CcuDelHora, 0, 5, 0, 3, "/", ":", " "));
         A516CcuDelUsuId = "";
         n516CcuDelUsuId = false;
         AssignAttri("", false, "A516CcuDelUsuId", A516CcuDelUsuId);
         A517CcuDelUsuNome = "";
         n517CcuDelUsuNome = false;
         AssignAttri("", false, "A517CcuDelUsuNome", A517CcuDelUsuNome);
         A209CcuSigla = "";
         AssignAttri("", false, "A209CcuSigla", A209CcuSigla);
         A210CcuNome = "";
         AssignAttri("", false, "A210CcuNome", A210CcuNome);
         A512CcuDel = false;
         AssignAttri("", false, "A512CcuDel", A512CcuDel);
         A218CcuAtivo = true;
         AssignAttri("", false, "A218CcuAtivo", A218CcuAtivo);
         O512CcuDel = A512CcuDel;
         AssignAttri("", false, "A512CcuDel", A512CcuDel);
         Z513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         Z514CcuDelData = (DateTime)(DateTime.MinValue);
         Z515CcuDelHora = (DateTime)(DateTime.MinValue);
         Z516CcuDelUsuId = "";
         Z517CcuDelUsuNome = "";
         Z209CcuSigla = "";
         Z210CcuNome = "";
         Z218CcuAtivo = false;
         Z512CcuDel = false;
      }

      protected void InitAll0Q26( )
      {
         A208CcuID = 0;
         AssignAttri("", false, "A208CcuID", StringUtil.LTrimStr( (decimal)(A208CcuID), 9, 0));
         InitializeNonKey0Q26( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A218CcuAtivo = i218CcuAtivo;
         AssignAttri("", false, "A218CcuAtivo", A218CcuAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382813799", true, true);
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
         context.AddJavascriptSource("core/centrodecusto.js", "?20238281380", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCcuSigla_Internalname = "CCUSIGLA";
         edtCcuNome_Internalname = "CCUNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtCcuID_Internalname = "CCUID";
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
         Form.Caption = "Centro De Custo";
         edtCcuID_Jsonclick = "";
         edtCcuID_Enabled = 0;
         edtCcuID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtCcuNome_Jsonclick = "";
         edtCcuNome_Enabled = 1;
         edtCcuSigla_Jsonclick = "";
         edtCcuSigla_Enabled = 1;
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

      protected void XC_11_0Q26( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A208CcuID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
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

      protected void XC_12_0Q26( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A208CcuID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "Y", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
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

      protected void XC_13_0Q26( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A208CcuID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
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

      protected void XC_14_0Q26( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A208CcuID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcentrodecusto(context ).execute(  "N", ref  AV13AuditingObject,  A208CcuID,  Gx_mode) ;
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

      public void Valid_Ccusigla( )
      {
         /* Using cursor T000Q14 */
         pr_default.execute(12, new Object[] {A209CcuSigla, A208CcuID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "CCUSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCcuSigla_Internalname;
         }
         pr_default.close(12);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A209CcuSigla)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Sigla", "", "", "", "", "", "", "", ""), 1, "CCUSIGLA");
            AnyError = 1;
            GX_FocusControl = edtCcuSigla_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CcuID',fld:'vCCUID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CcuID',fld:'vCCUID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A208CcuID',fld:'CCUID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A218CcuAtivo',fld:'CCUATIVO',pic:''},{av:'A512CcuDel',fld:'CCUDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120Q2',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CCUSIGLA","{handler:'Valid_Ccusigla',iparms:[{av:'A209CcuSigla',fld:'CCUSIGLA',pic:''},{av:'A208CcuID',fld:'CCUID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_CCUSIGLA",",oparms:[]}");
         setEventMetadata("VALID_CCUNOME","{handler:'Valid_Ccunome',iparms:[]");
         setEventMetadata("VALID_CCUNOME",",oparms:[]}");
         setEventMetadata("VALID_CCUID","{handler:'Valid_Ccuid',iparms:[]");
         setEventMetadata("VALID_CCUID",",oparms:[]}");
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
         Z513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         Z514CcuDelData = (DateTime)(DateTime.MinValue);
         Z515CcuDelHora = (DateTime)(DateTime.MinValue);
         Z516CcuDelUsuId = "";
         Z517CcuDelUsuNome = "";
         Z209CcuSigla = "";
         Z210CcuNome = "";
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
         A209CcuSigla = "";
         A210CcuNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A513CcuDelDataHora = (DateTime)(DateTime.MinValue);
         A514CcuDelData = (DateTime)(DateTime.MinValue);
         A515CcuDelHora = (DateTime)(DateTime.MinValue);
         A516CcuDelUsuId = "";
         A517CcuDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode26 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T000Q4_A208CcuID = new int[1] ;
         T000Q4_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Q4_n513CcuDelDataHora = new bool[] {false} ;
         T000Q4_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         T000Q4_n514CcuDelData = new bool[] {false} ;
         T000Q4_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Q4_n515CcuDelHora = new bool[] {false} ;
         T000Q4_A516CcuDelUsuId = new string[] {""} ;
         T000Q4_n516CcuDelUsuId = new bool[] {false} ;
         T000Q4_A517CcuDelUsuNome = new string[] {""} ;
         T000Q4_n517CcuDelUsuNome = new bool[] {false} ;
         T000Q4_A209CcuSigla = new string[] {""} ;
         T000Q4_A210CcuNome = new string[] {""} ;
         T000Q4_A218CcuAtivo = new bool[] {false} ;
         T000Q4_A512CcuDel = new bool[] {false} ;
         T000Q5_A209CcuSigla = new string[] {""} ;
         T000Q6_A208CcuID = new int[1] ;
         T000Q3_A208CcuID = new int[1] ;
         T000Q3_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Q3_n513CcuDelDataHora = new bool[] {false} ;
         T000Q3_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         T000Q3_n514CcuDelData = new bool[] {false} ;
         T000Q3_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Q3_n515CcuDelHora = new bool[] {false} ;
         T000Q3_A516CcuDelUsuId = new string[] {""} ;
         T000Q3_n516CcuDelUsuId = new bool[] {false} ;
         T000Q3_A517CcuDelUsuNome = new string[] {""} ;
         T000Q3_n517CcuDelUsuNome = new bool[] {false} ;
         T000Q3_A209CcuSigla = new string[] {""} ;
         T000Q3_A210CcuNome = new string[] {""} ;
         T000Q3_A218CcuAtivo = new bool[] {false} ;
         T000Q3_A512CcuDel = new bool[] {false} ;
         T000Q7_A208CcuID = new int[1] ;
         T000Q8_A208CcuID = new int[1] ;
         T000Q2_A208CcuID = new int[1] ;
         T000Q2_A513CcuDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000Q2_n513CcuDelDataHora = new bool[] {false} ;
         T000Q2_A514CcuDelData = new DateTime[] {DateTime.MinValue} ;
         T000Q2_n514CcuDelData = new bool[] {false} ;
         T000Q2_A515CcuDelHora = new DateTime[] {DateTime.MinValue} ;
         T000Q2_n515CcuDelHora = new bool[] {false} ;
         T000Q2_A516CcuDelUsuId = new string[] {""} ;
         T000Q2_n516CcuDelUsuId = new bool[] {false} ;
         T000Q2_A517CcuDelUsuNome = new string[] {""} ;
         T000Q2_n517CcuDelUsuNome = new bool[] {false} ;
         T000Q2_A209CcuSigla = new string[] {""} ;
         T000Q2_A210CcuNome = new string[] {""} ;
         T000Q2_A218CcuAtivo = new bool[] {false} ;
         T000Q2_A512CcuDel = new bool[] {false} ;
         T000Q10_A208CcuID = new int[1] ;
         T000Q13_A208CcuID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000Q14_A209CcuSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecusto__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.centrodecusto__default(),
            new Object[][] {
                new Object[] {
               T000Q2_A208CcuID, T000Q2_A513CcuDelDataHora, T000Q2_n513CcuDelDataHora, T000Q2_A514CcuDelData, T000Q2_n514CcuDelData, T000Q2_A515CcuDelHora, T000Q2_n515CcuDelHora, T000Q2_A516CcuDelUsuId, T000Q2_n516CcuDelUsuId, T000Q2_A517CcuDelUsuNome,
               T000Q2_n517CcuDelUsuNome, T000Q2_A209CcuSigla, T000Q2_A210CcuNome, T000Q2_A218CcuAtivo, T000Q2_A512CcuDel
               }
               , new Object[] {
               T000Q3_A208CcuID, T000Q3_A513CcuDelDataHora, T000Q3_n513CcuDelDataHora, T000Q3_A514CcuDelData, T000Q3_n514CcuDelData, T000Q3_A515CcuDelHora, T000Q3_n515CcuDelHora, T000Q3_A516CcuDelUsuId, T000Q3_n516CcuDelUsuId, T000Q3_A517CcuDelUsuNome,
               T000Q3_n517CcuDelUsuNome, T000Q3_A209CcuSigla, T000Q3_A210CcuNome, T000Q3_A218CcuAtivo, T000Q3_A512CcuDel
               }
               , new Object[] {
               T000Q4_A208CcuID, T000Q4_A513CcuDelDataHora, T000Q4_n513CcuDelDataHora, T000Q4_A514CcuDelData, T000Q4_n514CcuDelData, T000Q4_A515CcuDelHora, T000Q4_n515CcuDelHora, T000Q4_A516CcuDelUsuId, T000Q4_n516CcuDelUsuId, T000Q4_A517CcuDelUsuNome,
               T000Q4_n517CcuDelUsuNome, T000Q4_A209CcuSigla, T000Q4_A210CcuNome, T000Q4_A218CcuAtivo, T000Q4_A512CcuDel
               }
               , new Object[] {
               T000Q5_A209CcuSigla
               }
               , new Object[] {
               T000Q6_A208CcuID
               }
               , new Object[] {
               T000Q7_A208CcuID
               }
               , new Object[] {
               T000Q8_A208CcuID
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q10_A208CcuID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000Q13_A208CcuID
               }
               , new Object[] {
               T000Q14_A209CcuSigla
               }
            }
         );
         Z218CcuAtivo = true;
         A218CcuAtivo = true;
         i218CcuAtivo = true;
         AV14Pgmname = "core.CentroDeCusto";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound26 ;
      private short GX_JID ;
      private short nIsDirty_26 ;
      private short gxajaxcallmode ;
      private int wcpOAV7CcuID ;
      private int Z208CcuID ;
      private int AV7CcuID ;
      private int trnEnded ;
      private int edtCcuSigla_Enabled ;
      private int edtCcuNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A208CcuID ;
      private int edtCcuID_Enabled ;
      private int edtCcuID_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z516CcuDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCcuSigla_Internalname ;
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
      private string edtCcuSigla_Jsonclick ;
      private string edtCcuNome_Internalname ;
      private string edtCcuNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtCcuID_Internalname ;
      private string edtCcuID_Jsonclick ;
      private string A516CcuDelUsuId ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode26 ;
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
      private DateTime Z513CcuDelDataHora ;
      private DateTime Z514CcuDelData ;
      private DateTime Z515CcuDelHora ;
      private DateTime A513CcuDelDataHora ;
      private DateTime A514CcuDelData ;
      private DateTime A515CcuDelHora ;
      private bool Z218CcuAtivo ;
      private bool Z512CcuDel ;
      private bool O512CcuDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n513CcuDelDataHora ;
      private bool n514CcuDelData ;
      private bool n515CcuDelHora ;
      private bool n516CcuDelUsuId ;
      private bool n517CcuDelUsuNome ;
      private bool A218CcuAtivo ;
      private bool A512CcuDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i218CcuAtivo ;
      private string Z517CcuDelUsuNome ;
      private string Z209CcuSigla ;
      private string Z210CcuNome ;
      private string A209CcuSigla ;
      private string A210CcuNome ;
      private string A517CcuDelUsuNome ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T000Q4_A208CcuID ;
      private DateTime[] T000Q4_A513CcuDelDataHora ;
      private bool[] T000Q4_n513CcuDelDataHora ;
      private DateTime[] T000Q4_A514CcuDelData ;
      private bool[] T000Q4_n514CcuDelData ;
      private DateTime[] T000Q4_A515CcuDelHora ;
      private bool[] T000Q4_n515CcuDelHora ;
      private string[] T000Q4_A516CcuDelUsuId ;
      private bool[] T000Q4_n516CcuDelUsuId ;
      private string[] T000Q4_A517CcuDelUsuNome ;
      private bool[] T000Q4_n517CcuDelUsuNome ;
      private string[] T000Q4_A209CcuSigla ;
      private string[] T000Q4_A210CcuNome ;
      private bool[] T000Q4_A218CcuAtivo ;
      private bool[] T000Q4_A512CcuDel ;
      private string[] T000Q5_A209CcuSigla ;
      private int[] T000Q6_A208CcuID ;
      private int[] T000Q3_A208CcuID ;
      private DateTime[] T000Q3_A513CcuDelDataHora ;
      private bool[] T000Q3_n513CcuDelDataHora ;
      private DateTime[] T000Q3_A514CcuDelData ;
      private bool[] T000Q3_n514CcuDelData ;
      private DateTime[] T000Q3_A515CcuDelHora ;
      private bool[] T000Q3_n515CcuDelHora ;
      private string[] T000Q3_A516CcuDelUsuId ;
      private bool[] T000Q3_n516CcuDelUsuId ;
      private string[] T000Q3_A517CcuDelUsuNome ;
      private bool[] T000Q3_n517CcuDelUsuNome ;
      private string[] T000Q3_A209CcuSigla ;
      private string[] T000Q3_A210CcuNome ;
      private bool[] T000Q3_A218CcuAtivo ;
      private bool[] T000Q3_A512CcuDel ;
      private int[] T000Q7_A208CcuID ;
      private int[] T000Q8_A208CcuID ;
      private int[] T000Q2_A208CcuID ;
      private DateTime[] T000Q2_A513CcuDelDataHora ;
      private bool[] T000Q2_n513CcuDelDataHora ;
      private DateTime[] T000Q2_A514CcuDelData ;
      private bool[] T000Q2_n514CcuDelData ;
      private DateTime[] T000Q2_A515CcuDelHora ;
      private bool[] T000Q2_n515CcuDelHora ;
      private string[] T000Q2_A516CcuDelUsuId ;
      private bool[] T000Q2_n516CcuDelUsuId ;
      private string[] T000Q2_A517CcuDelUsuNome ;
      private bool[] T000Q2_n517CcuDelUsuNome ;
      private string[] T000Q2_A209CcuSigla ;
      private string[] T000Q2_A210CcuNome ;
      private bool[] T000Q2_A218CcuAtivo ;
      private bool[] T000Q2_A512CcuDel ;
      private int[] T000Q10_A208CcuID ;
      private int[] T000Q13_A208CcuID ;
      private string[] T000Q14_A209CcuSigla ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class centrodecusto__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class centrodecusto__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000Q4;
        prmT000Q4 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q5;
        prmT000Q5 = new Object[] {
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q6;
        prmT000Q6 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q3;
        prmT000Q3 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q7;
        prmT000Q7 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q8;
        prmT000Q8 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q2;
        prmT000Q2 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q9;
        prmT000Q9 = new Object[] {
        new ParDef("CcuDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CcuDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CcuDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CcuDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CcuDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuNome",GXType.VarChar,80,0) ,
        new ParDef("CcuAtivo",GXType.Boolean,4,0) ,
        new ParDef("CcuDel",GXType.Boolean,4,0)
        };
        Object[] prmT000Q10;
        prmT000Q10 = new Object[] {
        };
        Object[] prmT000Q11;
        prmT000Q11 = new Object[] {
        new ParDef("CcuDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CcuDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CcuDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CcuDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CcuDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuNome",GXType.VarChar,80,0) ,
        new ParDef("CcuAtivo",GXType.Boolean,4,0) ,
        new ParDef("CcuDel",GXType.Boolean,4,0) ,
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q12;
        prmT000Q12 = new Object[] {
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        Object[] prmT000Q13;
        prmT000Q13 = new Object[] {
        };
        Object[] prmT000Q14;
        prmT000Q14 = new Object[] {
        new ParDef("CcuSigla",GXType.VarChar,20,0) ,
        new ParDef("CcuID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000Q2", "SELECT CcuID, CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel FROM tb_centrodecusto WHERE CcuID = :CcuID  FOR UPDATE OF tb_centrodecusto NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q3", "SELECT CcuID, CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel FROM tb_centrodecusto WHERE CcuID = :CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q4", "SELECT TM1.CcuID, TM1.CcuDelDataHora, TM1.CcuDelData, TM1.CcuDelHora, TM1.CcuDelUsuId, TM1.CcuDelUsuNome, TM1.CcuSigla, TM1.CcuNome, TM1.CcuAtivo, TM1.CcuDel FROM tb_centrodecusto TM1 WHERE TM1.CcuID = :CcuID ORDER BY TM1.CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q5", "SELECT CcuSigla FROM tb_centrodecusto WHERE (CcuSigla = :CcuSigla) AND (Not ( CcuID = :CcuID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q6", "SELECT CcuID FROM tb_centrodecusto WHERE CcuID = :CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q7", "SELECT CcuID FROM tb_centrodecusto WHERE ( CcuID > :CcuID) ORDER BY CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q8", "SELECT CcuID FROM tb_centrodecusto WHERE ( CcuID < :CcuID) ORDER BY CcuID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000Q9", "SAVEPOINT gxupdate;INSERT INTO tb_centrodecusto(CcuDelDataHora, CcuDelData, CcuDelHora, CcuDelUsuId, CcuDelUsuNome, CcuSigla, CcuNome, CcuAtivo, CcuDel) VALUES(:CcuDelDataHora, :CcuDelData, :CcuDelHora, :CcuDelUsuId, :CcuDelUsuNome, :CcuSigla, :CcuNome, :CcuAtivo, :CcuDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000Q9)
           ,new CursorDef("T000Q10", "SELECT currval('CcuID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q11", "SAVEPOINT gxupdate;UPDATE tb_centrodecusto SET CcuDelDataHora=:CcuDelDataHora, CcuDelData=:CcuDelData, CcuDelHora=:CcuDelHora, CcuDelUsuId=:CcuDelUsuId, CcuDelUsuNome=:CcuDelUsuNome, CcuSigla=:CcuSigla, CcuNome=:CcuNome, CcuAtivo=:CcuAtivo, CcuDel=:CcuDel  WHERE CcuID = :CcuID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Q11)
           ,new CursorDef("T000Q12", "SAVEPOINT gxupdate;DELETE FROM tb_centrodecusto  WHERE CcuID = :CcuID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000Q12)
           ,new CursorDef("T000Q13", "SELECT CcuID FROM tb_centrodecusto ORDER BY CcuID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q13,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000Q14", "SELECT CcuSigla FROM tb_centrodecusto WHERE (CcuSigla = :CcuSigla) AND (Not ( CcuID = :CcuID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000Q14,1, GxCacheFrequency.OFF ,true,false )
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
