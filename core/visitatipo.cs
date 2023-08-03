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
   public class visitatipo : GXDataArea
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.visitatipo.aspx")), "core.visitatipo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.visitatipo.aspx")))) ;
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
                  AV7VitID = (int)(Math.Round(NumberUtil.Val( GetPar( "VitID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV7VitID", StringUtil.LTrimStr( (decimal)(AV7VitID), 9, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vVITID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VitID), "ZZZ,ZZZ,ZZ9"), context));
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
            Form.Meta.addItem("description", "Tipo de Visita", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtVitSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public visitatipo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public visitatipo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           int aP1_VitID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7VitID = aP1_VitID;
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
            return "visitatipo_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVitSigla_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVitSigla_Internalname, "Sigla", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVitSigla_Internalname, A412VitSigla, StringUtil.RTrim( context.localUtil.Format( A412VitSigla, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVitSigla_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVitSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\VisitaTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtVitNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtVitNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtVitNome_Internalname, A413VitNome, StringUtil.RTrim( context.localUtil.Format( A413VitNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVitNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtVitNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\VisitaTipo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaTipo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\VisitaTipo.htm");
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
         GxWebStd.gx_single_line_edit( context, edtVitID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A411VitID), 11, 0, ",", "")), StringUtil.LTrim( ((edtVitID_Enabled!=0) ? context.localUtil.Format( (decimal)(A411VitID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A411VitID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtVitID_Jsonclick, 0, "Attribute", "", "", "", "", edtVitID_Visible, edtVitID_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\VisitaTipo.htm");
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
         E11152 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z411VitID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z411VitID"), ",", "."), 18, MidpointRounding.ToEven));
               Z597VitDelDataHora = context.localUtil.CToT( cgiGet( "Z597VitDelDataHora"), 0);
               n597VitDelDataHora = ((DateTime.MinValue==A597VitDelDataHora) ? true : false);
               Z598VitDelData = context.localUtil.CToT( cgiGet( "Z598VitDelData"), 0);
               n598VitDelData = ((DateTime.MinValue==A598VitDelData) ? true : false);
               Z599VitDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z599VitDelHora"), 0));
               n599VitDelHora = ((DateTime.MinValue==A599VitDelHora) ? true : false);
               Z600VitDelUsuId = cgiGet( "Z600VitDelUsuId");
               n600VitDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A600VitDelUsuId)) ? true : false);
               Z601VitDelUsuNome = cgiGet( "Z601VitDelUsuNome");
               n601VitDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A601VitDelUsuNome)) ? true : false);
               Z412VitSigla = cgiGet( "Z412VitSigla");
               Z413VitNome = cgiGet( "Z413VitNome");
               Z596VitDel = StringUtil.StrToBool( cgiGet( "Z596VitDel"));
               A597VitDelDataHora = context.localUtil.CToT( cgiGet( "Z597VitDelDataHora"), 0);
               n597VitDelDataHora = false;
               n597VitDelDataHora = ((DateTime.MinValue==A597VitDelDataHora) ? true : false);
               A598VitDelData = context.localUtil.CToT( cgiGet( "Z598VitDelData"), 0);
               n598VitDelData = false;
               n598VitDelData = ((DateTime.MinValue==A598VitDelData) ? true : false);
               A599VitDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z599VitDelHora"), 0));
               n599VitDelHora = false;
               n599VitDelHora = ((DateTime.MinValue==A599VitDelHora) ? true : false);
               A600VitDelUsuId = cgiGet( "Z600VitDelUsuId");
               n600VitDelUsuId = false;
               n600VitDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A600VitDelUsuId)) ? true : false);
               A601VitDelUsuNome = cgiGet( "Z601VitDelUsuNome");
               n601VitDelUsuNome = false;
               n601VitDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A601VitDelUsuNome)) ? true : false);
               A596VitDel = StringUtil.StrToBool( cgiGet( "Z596VitDel"));
               O596VitDel = StringUtil.StrToBool( cgiGet( "O596VitDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7VitID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vVITID"), ",", "."), 18, MidpointRounding.ToEven));
               A596VitDel = StringUtil.StrToBool( cgiGet( "VITDEL"));
               A597VitDelDataHora = context.localUtil.CToT( cgiGet( "VITDELDATAHORA"), 0);
               n597VitDelDataHora = ((DateTime.MinValue==A597VitDelDataHora) ? true : false);
               A598VitDelData = context.localUtil.CToT( cgiGet( "VITDELDATA"), 0);
               n598VitDelData = ((DateTime.MinValue==A598VitDelData) ? true : false);
               A599VitDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "VITDELHORA"), 0));
               n599VitDelHora = ((DateTime.MinValue==A599VitDelHora) ? true : false);
               A600VitDelUsuId = cgiGet( "VITDELUSUID");
               n600VitDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A600VitDelUsuId)) ? true : false);
               A601VitDelUsuNome = cgiGet( "VITDELUSUNOME");
               n601VitDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A601VitDelUsuNome)) ? true : false);
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
               A412VitSigla = cgiGet( edtVitSigla_Internalname);
               AssignAttri("", false, "A412VitSigla", A412VitSigla);
               A413VitNome = StringUtil.Upper( cgiGet( edtVitNome_Internalname));
               AssignAttri("", false, "A413VitNome", A413VitNome);
               A411VitID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVitID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"VisitaTipo");
               A411VitID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtVitID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
               forbiddenHiddens.Add("VitID", context.localUtil.Format( (decimal)(A411VitID), "ZZZ,ZZZ,ZZ9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("VitDel", StringUtil.BoolToStr( A596VitDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A411VitID != Z411VitID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\visitatipo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A411VitID = (int)(Math.Round(NumberUtil.Val( GetPar( "VitID"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
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
                     sMode41 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode41;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound41 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_150( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "VITID");
                        AnyError = 1;
                        GX_FocusControl = edtVitID_Internalname;
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
                           E11152 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12152 ();
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
            E12152 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1541( ) ;
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
            DisableAttributes1541( ) ;
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

      protected void CONFIRM_150( )
      {
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1541( ) ;
            }
            else
            {
               CheckExtendedTable1541( ) ;
               CloseExtendedTableCursors1541( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption150( )
      {
      }

      protected void E11152( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("VITID");
         AV12WebSession.Remove("VITSIGLA");
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtVitID_Visible = 0;
         AssignProp("", false, edtVitID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtVitID_Visible), 5, 0), true);
      }

      protected void E12152( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         AV12WebSession.Set("VITID", StringUtil.Trim( StringUtil.Str( (decimal)(A411VitID), 9, 0)));
         AV12WebSession.Set("VITSIGLA", A412VitSigla);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.visitatipoww.aspx") );
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

      protected void ZM1541( short GX_JID )
      {
         if ( ( GX_JID == 12 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z597VitDelDataHora = T00153_A597VitDelDataHora[0];
               Z598VitDelData = T00153_A598VitDelData[0];
               Z599VitDelHora = T00153_A599VitDelHora[0];
               Z600VitDelUsuId = T00153_A600VitDelUsuId[0];
               Z601VitDelUsuNome = T00153_A601VitDelUsuNome[0];
               Z412VitSigla = T00153_A412VitSigla[0];
               Z413VitNome = T00153_A413VitNome[0];
               Z596VitDel = T00153_A596VitDel[0];
            }
            else
            {
               Z597VitDelDataHora = A597VitDelDataHora;
               Z598VitDelData = A598VitDelData;
               Z599VitDelHora = A599VitDelHora;
               Z600VitDelUsuId = A600VitDelUsuId;
               Z601VitDelUsuNome = A601VitDelUsuNome;
               Z412VitSigla = A412VitSigla;
               Z413VitNome = A413VitNome;
               Z596VitDel = A596VitDel;
            }
         }
         if ( GX_JID == -12 )
         {
            Z411VitID = A411VitID;
            Z597VitDelDataHora = A597VitDelDataHora;
            Z598VitDelData = A598VitDelData;
            Z599VitDelHora = A599VitDelHora;
            Z600VitDelUsuId = A600VitDelUsuId;
            Z601VitDelUsuNome = A601VitDelUsuNome;
            Z412VitSigla = A412VitSigla;
            Z413VitNome = A413VitNome;
            Z596VitDel = A596VitDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtVitID_Enabled = 0;
         AssignProp("", false, edtVitID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVitID_Enabled), 5, 0), true);
         AV14Pgmname = "core.VisitaTipo";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         edtVitID_Enabled = 0;
         AssignProp("", false, edtVitID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVitID_Enabled), 5, 0), true);
         if ( ! (0==AV7VitID) )
         {
            A411VitID = AV7VitID;
            AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
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

      protected void Load1541( )
      {
         /* Using cursor T00154 */
         pr_default.execute(2, new Object[] {A411VitID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound41 = 1;
            A597VitDelDataHora = T00154_A597VitDelDataHora[0];
            n597VitDelDataHora = T00154_n597VitDelDataHora[0];
            A598VitDelData = T00154_A598VitDelData[0];
            n598VitDelData = T00154_n598VitDelData[0];
            A599VitDelHora = T00154_A599VitDelHora[0];
            n599VitDelHora = T00154_n599VitDelHora[0];
            A600VitDelUsuId = T00154_A600VitDelUsuId[0];
            n600VitDelUsuId = T00154_n600VitDelUsuId[0];
            A601VitDelUsuNome = T00154_A601VitDelUsuNome[0];
            n601VitDelUsuNome = T00154_n601VitDelUsuNome[0];
            A412VitSigla = T00154_A412VitSigla[0];
            AssignAttri("", false, "A412VitSigla", A412VitSigla);
            A413VitNome = T00154_A413VitNome[0];
            AssignAttri("", false, "A413VitNome", A413VitNome);
            A596VitDel = T00154_A596VitDel[0];
            ZM1541( -12) ;
         }
         pr_default.close(2);
         OnLoadActions1541( ) ;
      }

      protected void OnLoadActions1541( )
      {
      }

      protected void CheckExtendedTable1541( )
      {
         nIsDirty_41 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00155 */
         pr_default.execute(3, new Object[] {A412VitSigla, A411VitID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "VITSIGLA");
            AnyError = 1;
            GX_FocusControl = edtVitSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors1541( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey1541( )
      {
         /* Using cursor T00156 */
         pr_default.execute(4, new Object[] {A411VitID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound41 = 1;
         }
         else
         {
            RcdFound41 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00153 */
         pr_default.execute(1, new Object[] {A411VitID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1541( 12) ;
            RcdFound41 = 1;
            A411VitID = T00153_A411VitID[0];
            AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
            A597VitDelDataHora = T00153_A597VitDelDataHora[0];
            n597VitDelDataHora = T00153_n597VitDelDataHora[0];
            A598VitDelData = T00153_A598VitDelData[0];
            n598VitDelData = T00153_n598VitDelData[0];
            A599VitDelHora = T00153_A599VitDelHora[0];
            n599VitDelHora = T00153_n599VitDelHora[0];
            A600VitDelUsuId = T00153_A600VitDelUsuId[0];
            n600VitDelUsuId = T00153_n600VitDelUsuId[0];
            A601VitDelUsuNome = T00153_A601VitDelUsuNome[0];
            n601VitDelUsuNome = T00153_n601VitDelUsuNome[0];
            A412VitSigla = T00153_A412VitSigla[0];
            AssignAttri("", false, "A412VitSigla", A412VitSigla);
            A413VitNome = T00153_A413VitNome[0];
            AssignAttri("", false, "A413VitNome", A413VitNome);
            A596VitDel = T00153_A596VitDel[0];
            O596VitDel = A596VitDel;
            AssignAttri("", false, "A596VitDel", A596VitDel);
            Z411VitID = A411VitID;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1541( ) ;
            if ( AnyError == 1 )
            {
               RcdFound41 = 0;
               InitializeNonKey1541( ) ;
            }
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound41 = 0;
            InitializeNonKey1541( ) ;
            sMode41 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode41;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1541( ) ;
         if ( RcdFound41 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound41 = 0;
         /* Using cursor T00157 */
         pr_default.execute(5, new Object[] {A411VitID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( T00157_A411VitID[0] < A411VitID ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( T00157_A411VitID[0] > A411VitID ) ) )
            {
               A411VitID = T00157_A411VitID[0];
               AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound41 = 0;
         /* Using cursor T00158 */
         pr_default.execute(6, new Object[] {A411VitID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00158_A411VitID[0] > A411VitID ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00158_A411VitID[0] < A411VitID ) ) )
            {
               A411VitID = T00158_A411VitID[0];
               AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
               RcdFound41 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1541( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtVitSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1541( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound41 == 1 )
            {
               if ( A411VitID != Z411VitID )
               {
                  A411VitID = Z411VitID;
                  AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "VITID");
                  AnyError = 1;
                  GX_FocusControl = edtVitID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtVitSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1541( ) ;
                  GX_FocusControl = edtVitSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A411VitID != Z411VitID )
               {
                  /* Insert record */
                  GX_FocusControl = edtVitSigla_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1541( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "VITID");
                     AnyError = 1;
                     GX_FocusControl = edtVitID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtVitSigla_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1541( ) ;
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
         if ( A411VitID != Z411VitID )
         {
            A411VitID = Z411VitID;
            AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "VITID");
            AnyError = 1;
            GX_FocusControl = edtVitID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtVitSigla_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1541( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00152 */
            pr_default.execute(0, new Object[] {A411VitID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visitatipo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z597VitDelDataHora != T00152_A597VitDelDataHora[0] ) || ( Z598VitDelData != T00152_A598VitDelData[0] ) || ( Z599VitDelHora != T00152_A599VitDelHora[0] ) || ( StringUtil.StrCmp(Z600VitDelUsuId, T00152_A600VitDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z601VitDelUsuNome, T00152_A601VitDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z412VitSigla, T00152_A412VitSigla[0]) != 0 ) || ( StringUtil.StrCmp(Z413VitNome, T00152_A413VitNome[0]) != 0 ) || ( Z596VitDel != T00152_A596VitDel[0] ) )
            {
               if ( Z597VitDelDataHora != T00152_A597VitDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z597VitDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00152_A597VitDelDataHora[0]);
               }
               if ( Z598VitDelData != T00152_A598VitDelData[0] )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDelData");
                  GXUtil.WriteLogRaw("Old: ",Z598VitDelData);
                  GXUtil.WriteLogRaw("Current: ",T00152_A598VitDelData[0]);
               }
               if ( Z599VitDelHora != T00152_A599VitDelHora[0] )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z599VitDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00152_A599VitDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z600VitDelUsuId, T00152_A600VitDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z600VitDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00152_A600VitDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z601VitDelUsuNome, T00152_A601VitDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z601VitDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00152_A601VitDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z412VitSigla, T00152_A412VitSigla[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitSigla");
                  GXUtil.WriteLogRaw("Old: ",Z412VitSigla);
                  GXUtil.WriteLogRaw("Current: ",T00152_A412VitSigla[0]);
               }
               if ( StringUtil.StrCmp(Z413VitNome, T00152_A413VitNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitNome");
                  GXUtil.WriteLogRaw("Old: ",Z413VitNome);
                  GXUtil.WriteLogRaw("Current: ",T00152_A413VitNome[0]);
               }
               if ( Z596VitDel != T00152_A596VitDel[0] )
               {
                  GXUtil.WriteLog("core.visitatipo:[seudo value changed for attri]"+"VitDel");
                  GXUtil.WriteLogRaw("Old: ",Z596VitDel);
                  GXUtil.WriteLogRaw("Current: ",T00152_A596VitDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_visitatipo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1541( )
      {
         if ( ! IsAuthorized("visitatipo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1541( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1541( 0) ;
            CheckOptimisticConcurrency1541( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1541( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1541( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00159 */
                     pr_default.execute(7, new Object[] {n597VitDelDataHora, A597VitDelDataHora, n598VitDelData, A598VitDelData, n599VitDelHora, A599VitDelHora, n600VitDelUsuId, A600VitDelUsuId, n601VitDelUsuNome, A601VitDelUsuNome, A412VitSigla, A413VitNome, A596VitDel});
                     pr_default.close(7);
                     /* Retrieving last key number assigned */
                     /* Using cursor T001510 */
                     pr_default.execute(8);
                     A411VitID = T001510_A411VitID[0];
                     AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption150( ) ;
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
               Load1541( ) ;
            }
            EndLevel1541( ) ;
         }
         CloseExtendedTableCursors1541( ) ;
      }

      protected void Update1541( )
      {
         if ( ! IsAuthorized("visitatipo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1541( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1541( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1541( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1541( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001511 */
                     pr_default.execute(9, new Object[] {n597VitDelDataHora, A597VitDelDataHora, n598VitDelData, A598VitDelData, n599VitDelHora, A599VitDelHora, n600VitDelUsuId, A600VitDelUsuId, n601VitDelUsuNome, A601VitDelUsuNome, A412VitSigla, A413VitNome, A596VitDel, A411VitID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_visitatipo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1541( ) ;
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
            EndLevel1541( ) ;
         }
         CloseExtendedTableCursors1541( ) ;
      }

      protected void DeferredUpdate1541( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("visitatipo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1541( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1541( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1541( ) ;
            AfterConfirm1541( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1541( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001512 */
                  pr_default.execute(10, new Object[] {A411VitID});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_visitatipo");
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
         sMode41 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1541( ) ;
         Gx_mode = sMode41;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1541( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T001513 */
            pr_default.execute(11, new Object[] {A411VitID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel1541( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1541( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.visitatipo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues150( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.visitatipo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1541( )
      {
         /* Scan By routine */
         /* Using cursor T001514 */
         pr_default.execute(12);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound41 = 1;
            A411VitID = T001514_A411VitID[0];
            AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1541( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound41 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound41 = 1;
            A411VitID = T001514_A411VitID[0];
            AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
         }
      }

      protected void ScanEnd1541( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm1541( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1541( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1541( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A597VitDelDataHora = DateTimeUtil.NowMS( context);
            n597VitDelDataHora = false;
            AssignAttri("", false, "A597VitDelDataHora", context.localUtil.TToC( A597VitDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A600VitDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n600VitDelUsuId = false;
            AssignAttri("", false, "A600VitDelUsuId", A600VitDelUsuId);
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A601VitDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n601VitDelUsuNome = false;
            AssignAttri("", false, "A601VitDelUsuNome", A601VitDelUsuNome);
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A598VitDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A597VitDelDataHora) ) ;
            n598VitDelData = false;
            AssignAttri("", false, "A598VitDelData", context.localUtil.TToC( A598VitDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A596VitDel && ( O596VitDel != A596VitDel ) )
         {
            A599VitDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A597VitDelDataHora));
            n599VitDelHora = false;
            AssignAttri("", false, "A599VitDelHora", context.localUtil.TToC( A599VitDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1541( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
      }

      protected void BeforeComplete1541( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1541( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1541( )
      {
         edtVitSigla_Enabled = 0;
         AssignProp("", false, edtVitSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVitSigla_Enabled), 5, 0), true);
         edtVitNome_Enabled = 0;
         AssignProp("", false, edtVitNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVitNome_Enabled), 5, 0), true);
         edtVitID_Enabled = 0;
         AssignProp("", false, edtVitID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtVitID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1541( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues150( )
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
         GXEncryptionTmp = "core.visitatipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7VitID,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.visitatipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"VisitaTipo");
         forbiddenHiddens.Add("VitID", context.localUtil.Format( (decimal)(A411VitID), "ZZZ,ZZZ,ZZ9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("VitDel", StringUtil.BoolToStr( A596VitDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\visitatipo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z411VitID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z411VitID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z597VitDelDataHora", context.localUtil.TToC( Z597VitDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z598VitDelData", context.localUtil.TToC( Z598VitDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z599VitDelHora", context.localUtil.TToC( Z599VitDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z600VitDelUsuId", StringUtil.RTrim( Z600VitDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z601VitDelUsuNome", Z601VitDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z412VitSigla", Z412VitSigla);
         GxWebStd.gx_hidden_field( context, "Z413VitNome", Z413VitNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z596VitDel", Z596VitDel);
         GxWebStd.gx_boolean_hidden_field( context, "O596VitDel", O596VitDel);
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
         GxWebStd.gx_hidden_field( context, "vVITID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV7VitID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vVITID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV7VitID), "ZZZ,ZZZ,ZZ9"), context));
         GxWebStd.gx_boolean_hidden_field( context, "VITDEL", A596VitDel);
         GxWebStd.gx_hidden_field( context, "VITDELDATAHORA", context.localUtil.TToC( A597VitDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VITDELDATA", context.localUtil.TToC( A598VitDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VITDELHORA", context.localUtil.TToC( A599VitDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "VITDELUSUID", StringUtil.RTrim( A600VitDelUsuId));
         GxWebStd.gx_hidden_field( context, "VITDELUSUNOME", A601VitDelUsuNome);
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
         GXEncryptionTmp = "core.visitatipo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV7VitID,9,0));
         return formatLink("core.visitatipo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.VisitaTipo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tipo de Visita" ;
      }

      protected void InitializeNonKey1541( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A597VitDelDataHora = (DateTime)(DateTime.MinValue);
         n597VitDelDataHora = false;
         AssignAttri("", false, "A597VitDelDataHora", context.localUtil.TToC( A597VitDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A598VitDelData = (DateTime)(DateTime.MinValue);
         n598VitDelData = false;
         AssignAttri("", false, "A598VitDelData", context.localUtil.TToC( A598VitDelData, 10, 5, 0, 3, "/", ":", " "));
         A599VitDelHora = (DateTime)(DateTime.MinValue);
         n599VitDelHora = false;
         AssignAttri("", false, "A599VitDelHora", context.localUtil.TToC( A599VitDelHora, 0, 5, 0, 3, "/", ":", " "));
         A600VitDelUsuId = "";
         n600VitDelUsuId = false;
         AssignAttri("", false, "A600VitDelUsuId", A600VitDelUsuId);
         A601VitDelUsuNome = "";
         n601VitDelUsuNome = false;
         AssignAttri("", false, "A601VitDelUsuNome", A601VitDelUsuNome);
         A412VitSigla = "";
         AssignAttri("", false, "A412VitSigla", A412VitSigla);
         A413VitNome = "";
         AssignAttri("", false, "A413VitNome", A413VitNome);
         A596VitDel = false;
         AssignAttri("", false, "A596VitDel", A596VitDel);
         O596VitDel = A596VitDel;
         AssignAttri("", false, "A596VitDel", A596VitDel);
         Z597VitDelDataHora = (DateTime)(DateTime.MinValue);
         Z598VitDelData = (DateTime)(DateTime.MinValue);
         Z599VitDelHora = (DateTime)(DateTime.MinValue);
         Z600VitDelUsuId = "";
         Z601VitDelUsuNome = "";
         Z412VitSigla = "";
         Z413VitNome = "";
         Z596VitDel = false;
      }

      protected void InitAll1541( )
      {
         A411VitID = 0;
         AssignAttri("", false, "A411VitID", StringUtil.LTrimStr( (decimal)(A411VitID), 9, 0));
         InitializeNonKey1541( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382815134", true, true);
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
         context.AddJavascriptSource("core/visitatipo.js", "?202382815135", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtVitSigla_Internalname = "VITSIGLA";
         edtVitNome_Internalname = "VITNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtVitID_Internalname = "VITID";
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
         Form.Caption = "Tipo de Visita";
         edtVitID_Jsonclick = "";
         edtVitID_Enabled = 0;
         edtVitID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtVitNome_Jsonclick = "";
         edtVitNome_Enabled = 1;
         edtVitSigla_Jsonclick = "";
         edtVitSigla_Enabled = 1;
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

      protected void XC_8_1541( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                int A411VitID ,
                                string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
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

      protected void XC_9_1541( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                int A411VitID ,
                                string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "Y", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
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

      protected void XC_10_1541( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A411VitID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
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

      protected void XC_11_1541( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 int A411VitID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditvisitatipo(context ).execute(  "N", ref  AV13AuditingObject,  A411VitID,  Gx_mode) ;
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

      public void Valid_Vitsigla( )
      {
         /* Using cursor T001515 */
         pr_default.execute(13, new Object[] {A412VitSigla, A411VitID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Sigla"}), 1, "VITSIGLA");
            AnyError = 1;
            GX_FocusControl = edtVitSigla_Internalname;
         }
         pr_default.close(13);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7VitID',fld:'vVITID',pic:'ZZZ,ZZZ,ZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7VitID',fld:'vVITID',pic:'ZZZ,ZZZ,ZZ9',hsh:true},{av:'A411VitID',fld:'VITID',pic:'ZZZ,ZZZ,ZZ9'},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A596VitDel',fld:'VITDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12152',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A411VitID',fld:'VITID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A412VitSigla',fld:'VITSIGLA',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_VITSIGLA","{handler:'Valid_Vitsigla',iparms:[{av:'A412VitSigla',fld:'VITSIGLA',pic:''},{av:'A411VitID',fld:'VITID',pic:'ZZZ,ZZZ,ZZ9'}]");
         setEventMetadata("VALID_VITSIGLA",",oparms:[]}");
         setEventMetadata("VALID_VITID","{handler:'Valid_Vitid',iparms:[]");
         setEventMetadata("VALID_VITID",",oparms:[]}");
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
         Z597VitDelDataHora = (DateTime)(DateTime.MinValue);
         Z598VitDelData = (DateTime)(DateTime.MinValue);
         Z599VitDelHora = (DateTime)(DateTime.MinValue);
         Z600VitDelUsuId = "";
         Z601VitDelUsuNome = "";
         Z412VitSigla = "";
         Z413VitNome = "";
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
         A412VitSigla = "";
         A413VitNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A597VitDelDataHora = (DateTime)(DateTime.MinValue);
         A598VitDelData = (DateTime)(DateTime.MinValue);
         A599VitDelHora = (DateTime)(DateTime.MinValue);
         A600VitDelUsuId = "";
         A601VitDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode41 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         T00154_A411VitID = new int[1] ;
         T00154_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00154_n597VitDelDataHora = new bool[] {false} ;
         T00154_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         T00154_n598VitDelData = new bool[] {false} ;
         T00154_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         T00154_n599VitDelHora = new bool[] {false} ;
         T00154_A600VitDelUsuId = new string[] {""} ;
         T00154_n600VitDelUsuId = new bool[] {false} ;
         T00154_A601VitDelUsuNome = new string[] {""} ;
         T00154_n601VitDelUsuNome = new bool[] {false} ;
         T00154_A412VitSigla = new string[] {""} ;
         T00154_A413VitNome = new string[] {""} ;
         T00154_A596VitDel = new bool[] {false} ;
         T00155_A412VitSigla = new string[] {""} ;
         T00156_A411VitID = new int[1] ;
         T00153_A411VitID = new int[1] ;
         T00153_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00153_n597VitDelDataHora = new bool[] {false} ;
         T00153_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         T00153_n598VitDelData = new bool[] {false} ;
         T00153_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         T00153_n599VitDelHora = new bool[] {false} ;
         T00153_A600VitDelUsuId = new string[] {""} ;
         T00153_n600VitDelUsuId = new bool[] {false} ;
         T00153_A601VitDelUsuNome = new string[] {""} ;
         T00153_n601VitDelUsuNome = new bool[] {false} ;
         T00153_A412VitSigla = new string[] {""} ;
         T00153_A413VitNome = new string[] {""} ;
         T00153_A596VitDel = new bool[] {false} ;
         T00157_A411VitID = new int[1] ;
         T00158_A411VitID = new int[1] ;
         T00152_A411VitID = new int[1] ;
         T00152_A597VitDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00152_n597VitDelDataHora = new bool[] {false} ;
         T00152_A598VitDelData = new DateTime[] {DateTime.MinValue} ;
         T00152_n598VitDelData = new bool[] {false} ;
         T00152_A599VitDelHora = new DateTime[] {DateTime.MinValue} ;
         T00152_n599VitDelHora = new bool[] {false} ;
         T00152_A600VitDelUsuId = new string[] {""} ;
         T00152_n600VitDelUsuId = new bool[] {false} ;
         T00152_A601VitDelUsuNome = new string[] {""} ;
         T00152_n601VitDelUsuNome = new bool[] {false} ;
         T00152_A412VitSigla = new string[] {""} ;
         T00152_A413VitNome = new string[] {""} ;
         T00152_A596VitDel = new bool[] {false} ;
         T001510_A411VitID = new int[1] ;
         T001513_A398VisID = new Guid[] {Guid.Empty} ;
         T001514_A411VitID = new int[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001515_A412VitSigla = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.visitatipo__default(),
            new Object[][] {
                new Object[] {
               T00152_A411VitID, T00152_A597VitDelDataHora, T00152_n597VitDelDataHora, T00152_A598VitDelData, T00152_n598VitDelData, T00152_A599VitDelHora, T00152_n599VitDelHora, T00152_A600VitDelUsuId, T00152_n600VitDelUsuId, T00152_A601VitDelUsuNome,
               T00152_n601VitDelUsuNome, T00152_A412VitSigla, T00152_A413VitNome, T00152_A596VitDel
               }
               , new Object[] {
               T00153_A411VitID, T00153_A597VitDelDataHora, T00153_n597VitDelDataHora, T00153_A598VitDelData, T00153_n598VitDelData, T00153_A599VitDelHora, T00153_n599VitDelHora, T00153_A600VitDelUsuId, T00153_n600VitDelUsuId, T00153_A601VitDelUsuNome,
               T00153_n601VitDelUsuNome, T00153_A412VitSigla, T00153_A413VitNome, T00153_A596VitDel
               }
               , new Object[] {
               T00154_A411VitID, T00154_A597VitDelDataHora, T00154_n597VitDelDataHora, T00154_A598VitDelData, T00154_n598VitDelData, T00154_A599VitDelHora, T00154_n599VitDelHora, T00154_A600VitDelUsuId, T00154_n600VitDelUsuId, T00154_A601VitDelUsuNome,
               T00154_n601VitDelUsuNome, T00154_A412VitSigla, T00154_A413VitNome, T00154_A596VitDel
               }
               , new Object[] {
               T00155_A412VitSigla
               }
               , new Object[] {
               T00156_A411VitID
               }
               , new Object[] {
               T00157_A411VitID
               }
               , new Object[] {
               T00158_A411VitID
               }
               , new Object[] {
               }
               , new Object[] {
               T001510_A411VitID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001513_A398VisID
               }
               , new Object[] {
               T001514_A411VitID
               }
               , new Object[] {
               T001515_A412VitSigla
               }
            }
         );
         AV14Pgmname = "core.VisitaTipo";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short RcdFound41 ;
      private short GX_JID ;
      private short nIsDirty_41 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int wcpOAV7VitID ;
      private int Z411VitID ;
      private int AV7VitID ;
      private int trnEnded ;
      private int edtVitSigla_Enabled ;
      private int edtVitNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int A411VitID ;
      private int edtVitID_Enabled ;
      private int edtVitID_Visible ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z600VitDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtVitSigla_Internalname ;
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
      private string edtVitSigla_Jsonclick ;
      private string edtVitNome_Internalname ;
      private string edtVitNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtVitID_Internalname ;
      private string edtVitID_Jsonclick ;
      private string A600VitDelUsuId ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode41 ;
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
      private DateTime Z597VitDelDataHora ;
      private DateTime Z598VitDelData ;
      private DateTime Z599VitDelHora ;
      private DateTime A597VitDelDataHora ;
      private DateTime A598VitDelData ;
      private DateTime A599VitDelHora ;
      private bool Z596VitDel ;
      private bool O596VitDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n597VitDelDataHora ;
      private bool n598VitDelData ;
      private bool n599VitDelHora ;
      private bool n600VitDelUsuId ;
      private bool n601VitDelUsuNome ;
      private bool A596VitDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string Z601VitDelUsuNome ;
      private string Z412VitSigla ;
      private string Z413VitNome ;
      private string A412VitSigla ;
      private string A413VitNome ;
      private string A601VitDelUsuNome ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private int[] T00154_A411VitID ;
      private DateTime[] T00154_A597VitDelDataHora ;
      private bool[] T00154_n597VitDelDataHora ;
      private DateTime[] T00154_A598VitDelData ;
      private bool[] T00154_n598VitDelData ;
      private DateTime[] T00154_A599VitDelHora ;
      private bool[] T00154_n599VitDelHora ;
      private string[] T00154_A600VitDelUsuId ;
      private bool[] T00154_n600VitDelUsuId ;
      private string[] T00154_A601VitDelUsuNome ;
      private bool[] T00154_n601VitDelUsuNome ;
      private string[] T00154_A412VitSigla ;
      private string[] T00154_A413VitNome ;
      private bool[] T00154_A596VitDel ;
      private string[] T00155_A412VitSigla ;
      private int[] T00156_A411VitID ;
      private int[] T00153_A411VitID ;
      private DateTime[] T00153_A597VitDelDataHora ;
      private bool[] T00153_n597VitDelDataHora ;
      private DateTime[] T00153_A598VitDelData ;
      private bool[] T00153_n598VitDelData ;
      private DateTime[] T00153_A599VitDelHora ;
      private bool[] T00153_n599VitDelHora ;
      private string[] T00153_A600VitDelUsuId ;
      private bool[] T00153_n600VitDelUsuId ;
      private string[] T00153_A601VitDelUsuNome ;
      private bool[] T00153_n601VitDelUsuNome ;
      private string[] T00153_A412VitSigla ;
      private string[] T00153_A413VitNome ;
      private bool[] T00153_A596VitDel ;
      private int[] T00157_A411VitID ;
      private int[] T00158_A411VitID ;
      private int[] T00152_A411VitID ;
      private DateTime[] T00152_A597VitDelDataHora ;
      private bool[] T00152_n597VitDelDataHora ;
      private DateTime[] T00152_A598VitDelData ;
      private bool[] T00152_n598VitDelData ;
      private DateTime[] T00152_A599VitDelHora ;
      private bool[] T00152_n599VitDelHora ;
      private string[] T00152_A600VitDelUsuId ;
      private bool[] T00152_n600VitDelUsuId ;
      private string[] T00152_A601VitDelUsuNome ;
      private bool[] T00152_n601VitDelUsuNome ;
      private string[] T00152_A412VitSigla ;
      private string[] T00152_A413VitNome ;
      private bool[] T00152_A596VitDel ;
      private int[] T001510_A411VitID ;
      private Guid[] T001513_A398VisID ;
      private int[] T001514_A411VitID ;
      private string[] T001515_A412VitSigla ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class visitatipo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class visitatipo__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00154;
        prmT00154 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00155;
        prmT00155 = new Object[] {
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00156;
        prmT00156 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00153;
        prmT00153 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00157;
        prmT00157 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00158;
        prmT00158 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00152;
        prmT00152 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT00159;
        prmT00159 = new Object[] {
        new ParDef("VitDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VitDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VitDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VitDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VitDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitNome",GXType.VarChar,80,0) ,
        new ParDef("VitDel",GXType.Boolean,4,0)
        };
        Object[] prmT001510;
        prmT001510 = new Object[] {
        };
        Object[] prmT001511;
        prmT001511 = new Object[] {
        new ParDef("VitDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("VitDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("VitDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("VitDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("VitDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitNome",GXType.VarChar,80,0) ,
        new ParDef("VitDel",GXType.Boolean,4,0) ,
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT001512;
        prmT001512 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT001513;
        prmT001513 = new Object[] {
        new ParDef("VitID",GXType.Int32,9,0)
        };
        Object[] prmT001514;
        prmT001514 = new Object[] {
        };
        Object[] prmT001515;
        prmT001515 = new Object[] {
        new ParDef("VitSigla",GXType.VarChar,20,0) ,
        new ParDef("VitID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00152", "SELECT VitID, VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel FROM tb_visitatipo WHERE VitID = :VitID  FOR UPDATE OF tb_visitatipo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00152,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00153", "SELECT VitID, VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel FROM tb_visitatipo WHERE VitID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00153,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00154", "SELECT TM1.VitID, TM1.VitDelDataHora, TM1.VitDelData, TM1.VitDelHora, TM1.VitDelUsuId, TM1.VitDelUsuNome, TM1.VitSigla, TM1.VitNome, TM1.VitDel FROM tb_visitatipo TM1 WHERE TM1.VitID = :VitID ORDER BY TM1.VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00154,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00155", "SELECT VitSigla FROM tb_visitatipo WHERE (VitSigla = :VitSigla) AND (Not ( VitID = :VitID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00155,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00156", "SELECT VitID FROM tb_visitatipo WHERE VitID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00156,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00157", "SELECT VitID FROM tb_visitatipo WHERE ( VitID > :VitID) ORDER BY VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00157,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00158", "SELECT VitID FROM tb_visitatipo WHERE ( VitID < :VitID) ORDER BY VitID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00158,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00159", "SAVEPOINT gxupdate;INSERT INTO tb_visitatipo(VitDelDataHora, VitDelData, VitDelHora, VitDelUsuId, VitDelUsuNome, VitSigla, VitNome, VitDel) VALUES(:VitDelDataHora, :VitDelData, :VitDelHora, :VitDelUsuId, :VitDelUsuNome, :VitSigla, :VitNome, :VitDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00159)
           ,new CursorDef("T001510", "SELECT currval('VitID') ",true, GxErrorMask.GX_NOMASK, false, this,prmT001510,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001511", "SAVEPOINT gxupdate;UPDATE tb_visitatipo SET VitDelDataHora=:VitDelDataHora, VitDelData=:VitDelData, VitDelHora=:VitDelHora, VitDelUsuId=:VitDelUsuId, VitDelUsuNome=:VitDelUsuNome, VitSigla=:VitSigla, VitNome=:VitNome, VitDel=:VitDel  WHERE VitID = :VitID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001511)
           ,new CursorDef("T001512", "SAVEPOINT gxupdate;DELETE FROM tb_visitatipo  WHERE VitID = :VitID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001512)
           ,new CursorDef("T001513", "SELECT VisID FROM tb_visita WHERE VisTipoID = :VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001513,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001514", "SELECT VitID FROM tb_visitatipo ORDER BY VitID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001514,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001515", "SELECT VitSigla FROM tb_visitatipo WHERE (VitSigla = :VitSigla) AND (Not ( VitID = :VitID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001515,1, GxCacheFrequency.OFF ,true,false )
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
