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
   public class tabeladepreco : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_37") == 0 )
         {
            A220PrdID = StringUtil.StrToGuid( GetPar( "PrdID"));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_37( A220PrdID) ;
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridlevel_produto") == 0 )
         {
            gxnrGridlevel_produto_newrow_invoke( ) ;
            return  ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.tabeladepreco.aspx")), "core.tabeladepreco.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.tabeladepreco.aspx")))) ;
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
                  AV7TppID = StringUtil.StrToGuid( GetPar( "TppID"));
                  AssignAttri("", false, "AV7TppID", AV7TppID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vTPPID", GetSecureSignedToken( "", AV7TppID, context));
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
            Form.Meta.addItem("description", "Tabela de Preço do Produto ou Serviço", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtTppCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridlevel_produto_newrow_invoke( )
      {
         nRC_GXsfl_33 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_33"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_33_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_33_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_33_idx = GetPar( "sGXsfl_33_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridlevel_produto_newrow( ) ;
         /* End function gxnrGridlevel_produto_newrow_invoke */
      }

      public tabeladepreco( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public tabeladepreco( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_TppID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7TppID = aP1_TppID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkPrdAtivo = new GXCheckbox();
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
            return "tabeladepreco_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTppCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTppCodigo_Internalname, "Código", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppCodigo_Internalname, A236TppCodigo, StringUtil.RTrim( context.localUtil.Format( A236TppCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTppCodigo_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\TabelaDePrecoCodigo", "start", true, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtTppNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtTppNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppNome_Internalname, A237TppNome, StringUtil.RTrim( context.localUtil.Format( A237TppNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtTppNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\TabelaDePreco.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 CellMarginTop", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTableleaflevel_produto_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 SectionGrid GridNoBorderCell", "start", "top", "", "", "div");
         gxdraw_Gridlevel_produto( ) ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\TabelaDePreco.htm");
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
         /* User Defined Control */
         ucCombo_prdid.SetProperty("Caption", Combo_prdid_Caption);
         ucCombo_prdid.SetProperty("Cls", Combo_prdid_Cls);
         ucCombo_prdid.SetProperty("IsGridItem", Combo_prdid_Isgriditem);
         ucCombo_prdid.SetProperty("DropDownOptionsTitleSettingsIcons", AV14DDO_TitleSettingsIcons);
         ucCombo_prdid.SetProperty("DropDownOptionsData", AV13PrdID_Data);
         ucCombo_prdid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_prdid_Internalname, "COMBO_PRDIDContainer");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppID_Internalname, A235TppID.ToString(), A235TppID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppID_Visible, edtTppID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\TabelaDePreco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppInsData_Internalname, context.localUtil.Format(A238TppInsData, "99/99/99"), context.localUtil.Format( A238TppInsData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsData_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsData_Visible, edtTppInsData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsData_Visible==0)||(edtTppInsData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppInsHora_Internalname, context.localUtil.TToC( A239TppInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A239TppInsHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsHora_Visible, edtTppInsHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsHora_Visible==0)||(edtTppInsHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppInsDataHora_Internalname, context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A240TppInsDataHora, "99/99/9999 99:99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',8,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsDataHora_Visible, edtTppInsDataHora_Enabled, 0, "text", "", 19, "chr", 1, "row", 19, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundo", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppInsDataHora_Visible==0)||(edtTppInsDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppInsUsuID_Internalname, StringUtil.RTrim( A241TppInsUsuID), StringUtil.RTrim( context.localUtil.Format( A241TppInsUsuID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppInsUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppInsUsuID_Visible, edtTppInsUsuID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\TabelaDePreco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppUpdData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppUpdData_Internalname, context.localUtil.Format(A242TppUpdData, "99/99/99"), context.localUtil.Format( A242TppUpdData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdData_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdData_Visible, edtTppUpdData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppUpdData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdData_Visible==0)||(edtTppUpdData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppUpdHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppUpdHora_Internalname, context.localUtil.TToC( A243TppUpdHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A243TppUpdHora, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdHora_Visible, edtTppUpdHora_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppUpdHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdHora_Visible==0)||(edtTppUpdHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtTppUpdDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtTppUpdDataHora_Internalname, context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A244TppUpdDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdDataHora_Visible, edtTppUpdDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_bitmap( context, edtTppUpdDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtTppUpdDataHora_Visible==0)||(edtTppUpdDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\TabelaDePreco.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppUpdUsuID_Internalname, StringUtil.RTrim( A245TppUpdUsuID), StringUtil.RTrim( context.localUtil.Format( A245TppUpdUsuID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppUpdUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtTppUpdUsuID_Visible, edtTppUpdUsuID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\TabelaDePreco.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtTppAtivo_Internalname, StringUtil.BoolToStr( A246TppAtivo), StringUtil.BoolToStr( A246TppAtivo), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtTppAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtTppAtivo_Visible, edtTppAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\TabelaDePreco.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridlevel_produto( )
      {
         /*  Grid Control  */
         StartGridControl33( ) ;
         nGXsfl_33_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount30 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_30 = 1;
               ScanStart0T30( ) ;
               while ( RcdFound30 != 0 )
               {
                  init_level_properties30( ) ;
                  getByPrimaryKey0T30( ) ;
                  AddRow0T30( ) ;
                  ScanNext0T30( ) ;
               }
               ScanEnd0T30( ) ;
               nBlankRcdCount30 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            B602TppDel = A602TppDel;
            AssignAttri("", false, "A602TppDel", A602TppDel);
            standaloneNotModal0T30( ) ;
            standaloneModal0T30( ) ;
            sMode30 = Gx_mode;
            while ( nGXsfl_33_idx < nRC_GXsfl_33 )
            {
               bGXsfl_33_Refreshing = true;
               ReadRow0T30( ) ;
               edtPrdID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDID_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtPrdCodigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDCODIGO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPrdCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdCodigo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtPrdNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDNOME_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPrdNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdNome_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtPrdTipoID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDTIPOID_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               chkPrdAtivo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDATIVO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, chkPrdAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPrdAtivo.Enabled), 5, 0), !bGXsfl_33_Refreshing);
               edtTpp1Preco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TPP1PRECO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtTpp1Preco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTpp1Preco_Enabled), 5, 0), !bGXsfl_33_Refreshing);
               if ( ( nRcdExists_30 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0T30( ) ;
               }
               SendRow0T30( ) ;
               bGXsfl_33_Refreshing = false;
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A602TppDel = B602TppDel;
            AssignAttri("", false, "A602TppDel", A602TppDel);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount30 = 5;
            nRcdExists_30 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0T30( ) ;
               while ( RcdFound30 != 0 )
               {
                  sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_3330( ) ;
                  init_level_properties30( ) ;
                  standaloneNotModal0T30( ) ;
                  getByPrimaryKey0T30( ) ;
                  standaloneModal0T30( ) ;
                  AddRow0T30( ) ;
                  ScanNext0T30( ) ;
               }
               ScanEnd0T30( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         if ( ! IsDsp( ) && ! IsDlt( ) )
         {
            sMode30 = Gx_mode;
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx+1), 4, 0), 4, "0");
            SubsflControlProps_3330( ) ;
            InitAll0T30( ) ;
            init_level_properties30( ) ;
            B602TppDel = A602TppDel;
            AssignAttri("", false, "A602TppDel", A602TppDel);
            nRcdExists_30 = 0;
            nIsMod_30 = 0;
            nRcdDeleted_30 = 0;
            nBlankRcdCount30 = (short)(nBlankRcdUsr30+nBlankRcdCount30);
            fRowAdded = 0;
            while ( nBlankRcdCount30 > 0 )
            {
               standaloneNotModal0T30( ) ;
               standaloneModal0T30( ) ;
               AddRow0T30( ) ;
               if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
               {
                  fRowAdded = 1;
                  GX_FocusControl = edtPrdID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               nBlankRcdCount30 = (short)(nBlankRcdCount30-1);
            }
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
            A602TppDel = B602TppDel;
            AssignAttri("", false, "A602TppDel", A602TppDel);
         }
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridlevel_produtoContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridlevel_produto", Gridlevel_produtoContainer, subGridlevel_produto_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_produtoContainerData", Gridlevel_produtoContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridlevel_produtoContainerData"+"V", Gridlevel_produtoContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridlevel_produtoContainerData"+"V"+"\" value='"+Gridlevel_produtoContainer.GridValuesHidden()+"'/>") ;
         }
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
         E110T2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV14DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPRDID_DATA"), AV13PrdID_Data);
               /* Read saved values. */
               Z235TppID = StringUtil.StrToGuid( cgiGet( "Z235TppID"));
               Z240TppInsDataHora = context.localUtil.CToT( cgiGet( "Z240TppInsDataHora"), 0);
               Z238TppInsData = context.localUtil.CToD( cgiGet( "Z238TppInsData"), 0);
               Z239TppInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z239TppInsHora"), 0));
               Z241TppInsUsuID = cgiGet( "Z241TppInsUsuID");
               n241TppInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A241TppInsUsuID)) ? true : false);
               Z433TppInsUsuNome = cgiGet( "Z433TppInsUsuNome");
               n433TppInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A433TppInsUsuNome)) ? true : false);
               Z603TppDelDataHora = context.localUtil.CToT( cgiGet( "Z603TppDelDataHora"), 0);
               n603TppDelDataHora = ((DateTime.MinValue==A603TppDelDataHora) ? true : false);
               Z604TppDelData = context.localUtil.CToT( cgiGet( "Z604TppDelData"), 0);
               n604TppDelData = ((DateTime.MinValue==A604TppDelData) ? true : false);
               Z605TppDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z605TppDelHora"), 0));
               n605TppDelHora = ((DateTime.MinValue==A605TppDelHora) ? true : false);
               Z606TppDelUsuId = cgiGet( "Z606TppDelUsuId");
               n606TppDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A606TppDelUsuId)) ? true : false);
               Z607TppDelUsuNome = cgiGet( "Z607TppDelUsuNome");
               n607TppDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A607TppDelUsuNome)) ? true : false);
               Z236TppCodigo = cgiGet( "Z236TppCodigo");
               Z237TppNome = cgiGet( "Z237TppNome");
               Z242TppUpdData = context.localUtil.CToD( cgiGet( "Z242TppUpdData"), 0);
               n242TppUpdData = ((DateTime.MinValue==A242TppUpdData) ? true : false);
               Z243TppUpdHora = context.localUtil.CToT( cgiGet( "Z243TppUpdHora"), 0);
               n243TppUpdHora = ((DateTime.MinValue==A243TppUpdHora) ? true : false);
               Z244TppUpdDataHora = context.localUtil.CToT( cgiGet( "Z244TppUpdDataHora"), 0);
               n244TppUpdDataHora = ((DateTime.MinValue==A244TppUpdDataHora) ? true : false);
               Z245TppUpdUsuID = cgiGet( "Z245TppUpdUsuID");
               n245TppUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A245TppUpdUsuID)) ? true : false);
               Z434TppUpdUsuNome = cgiGet( "Z434TppUpdUsuNome");
               n434TppUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A434TppUpdUsuNome)) ? true : false);
               Z246TppAtivo = StringUtil.StrToBool( cgiGet( "Z246TppAtivo"));
               n246TppAtivo = ((false==A246TppAtivo) ? true : false);
               Z602TppDel = StringUtil.StrToBool( cgiGet( "Z602TppDel"));
               A433TppInsUsuNome = cgiGet( "Z433TppInsUsuNome");
               n433TppInsUsuNome = false;
               n433TppInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A433TppInsUsuNome)) ? true : false);
               A603TppDelDataHora = context.localUtil.CToT( cgiGet( "Z603TppDelDataHora"), 0);
               n603TppDelDataHora = false;
               n603TppDelDataHora = ((DateTime.MinValue==A603TppDelDataHora) ? true : false);
               A604TppDelData = context.localUtil.CToT( cgiGet( "Z604TppDelData"), 0);
               n604TppDelData = false;
               n604TppDelData = ((DateTime.MinValue==A604TppDelData) ? true : false);
               A605TppDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z605TppDelHora"), 0));
               n605TppDelHora = false;
               n605TppDelHora = ((DateTime.MinValue==A605TppDelHora) ? true : false);
               A606TppDelUsuId = cgiGet( "Z606TppDelUsuId");
               n606TppDelUsuId = false;
               n606TppDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A606TppDelUsuId)) ? true : false);
               A607TppDelUsuNome = cgiGet( "Z607TppDelUsuNome");
               n607TppDelUsuNome = false;
               n607TppDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A607TppDelUsuNome)) ? true : false);
               A434TppUpdUsuNome = cgiGet( "Z434TppUpdUsuNome");
               n434TppUpdUsuNome = false;
               n434TppUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A434TppUpdUsuNome)) ? true : false);
               A602TppDel = StringUtil.StrToBool( cgiGet( "Z602TppDel"));
               O602TppDel = StringUtil.StrToBool( cgiGet( "O602TppDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               nRC_GXsfl_33 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_33"), ",", "."), 18, MidpointRounding.ToEven));
               AV7TppID = StringUtil.StrToGuid( cgiGet( "vTPPID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A433TppInsUsuNome = cgiGet( "TPPINSUSUNOME");
               n433TppInsUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A433TppInsUsuNome)) ? true : false);
               A602TppDel = StringUtil.StrToBool( cgiGet( "TPPDEL"));
               A603TppDelDataHora = context.localUtil.CToT( cgiGet( "TPPDELDATAHORA"), 0);
               n603TppDelDataHora = ((DateTime.MinValue==A603TppDelDataHora) ? true : false);
               A604TppDelData = context.localUtil.CToT( cgiGet( "TPPDELDATA"), 0);
               n604TppDelData = ((DateTime.MinValue==A604TppDelData) ? true : false);
               A605TppDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "TPPDELHORA"), 0));
               n605TppDelHora = ((DateTime.MinValue==A605TppDelHora) ? true : false);
               A606TppDelUsuId = cgiGet( "TPPDELUSUID");
               n606TppDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A606TppDelUsuId)) ? true : false);
               A607TppDelUsuNome = cgiGet( "TPPDELUSUNOME");
               n607TppDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A607TppDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV16AuditingObject);
               A434TppUpdUsuNome = cgiGet( "TPPUPDUSUNOME");
               n434TppUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A434TppUpdUsuNome)) ? true : false);
               AV17Pgmname = cgiGet( "vPGMNAME");
               A608Tpp1Del = StringUtil.StrToBool( cgiGet( "TPP1DEL"));
               A609Tpp1DelDataHora = context.localUtil.CToT( cgiGet( "TPP1DELDATAHORA"), 0);
               n609Tpp1DelDataHora = false;
               n609Tpp1DelDataHora = ((DateTime.MinValue==A609Tpp1DelDataHora) ? true : false);
               A610Tpp1DelData = context.localUtil.CToT( cgiGet( "TPP1DELDATA"), 0);
               n610Tpp1DelData = false;
               n610Tpp1DelData = ((DateTime.MinValue==A610Tpp1DelData) ? true : false);
               A611Tpp1DelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "TPP1DELHORA"), 0));
               n611Tpp1DelHora = false;
               n611Tpp1DelHora = ((DateTime.MinValue==A611Tpp1DelHora) ? true : false);
               A612Tpp1DelUsuId = cgiGet( "TPP1DELUSUID");
               n612Tpp1DelUsuId = false;
               n612Tpp1DelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A612Tpp1DelUsuId)) ? true : false);
               A613Tpp1DelUsuNome = cgiGet( "TPP1DELUSUNOME");
               n613Tpp1DelUsuNome = false;
               n613Tpp1DelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A613Tpp1DelUsuNome)) ? true : false);
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
               Combo_prdid_Objectcall = cgiGet( "COMBO_PRDID_Objectcall");
               Combo_prdid_Class = cgiGet( "COMBO_PRDID_Class");
               Combo_prdid_Icontype = cgiGet( "COMBO_PRDID_Icontype");
               Combo_prdid_Icon = cgiGet( "COMBO_PRDID_Icon");
               Combo_prdid_Caption = cgiGet( "COMBO_PRDID_Caption");
               Combo_prdid_Tooltip = cgiGet( "COMBO_PRDID_Tooltip");
               Combo_prdid_Cls = cgiGet( "COMBO_PRDID_Cls");
               Combo_prdid_Selectedvalue_set = cgiGet( "COMBO_PRDID_Selectedvalue_set");
               Combo_prdid_Selectedvalue_get = cgiGet( "COMBO_PRDID_Selectedvalue_get");
               Combo_prdid_Selectedtext_set = cgiGet( "COMBO_PRDID_Selectedtext_set");
               Combo_prdid_Selectedtext_get = cgiGet( "COMBO_PRDID_Selectedtext_get");
               Combo_prdid_Gamoauthtoken = cgiGet( "COMBO_PRDID_Gamoauthtoken");
               Combo_prdid_Ddointernalname = cgiGet( "COMBO_PRDID_Ddointernalname");
               Combo_prdid_Titlecontrolalign = cgiGet( "COMBO_PRDID_Titlecontrolalign");
               Combo_prdid_Dropdownoptionstype = cgiGet( "COMBO_PRDID_Dropdownoptionstype");
               Combo_prdid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Enabled"));
               Combo_prdid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Visible"));
               Combo_prdid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRDID_Titlecontrolidtoreplace");
               Combo_prdid_Datalisttype = cgiGet( "COMBO_PRDID_Datalisttype");
               Combo_prdid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Allowmultipleselection"));
               Combo_prdid_Datalistfixedvalues = cgiGet( "COMBO_PRDID_Datalistfixedvalues");
               Combo_prdid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Isgriditem"));
               Combo_prdid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Hasdescription"));
               Combo_prdid_Datalistproc = cgiGet( "COMBO_PRDID_Datalistproc");
               Combo_prdid_Datalistprocparametersprefix = cgiGet( "COMBO_PRDID_Datalistprocparametersprefix");
               Combo_prdid_Remoteservicesparameters = cgiGet( "COMBO_PRDID_Remoteservicesparameters");
               Combo_prdid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRDID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_prdid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Includeonlyselectedoption"));
               Combo_prdid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Includeselectalloption"));
               Combo_prdid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Emptyitem"));
               Combo_prdid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRDID_Includeaddnewoption"));
               Combo_prdid_Htmltemplate = cgiGet( "COMBO_PRDID_Htmltemplate");
               Combo_prdid_Multiplevaluestype = cgiGet( "COMBO_PRDID_Multiplevaluestype");
               Combo_prdid_Loadingdata = cgiGet( "COMBO_PRDID_Loadingdata");
               Combo_prdid_Noresultsfound = cgiGet( "COMBO_PRDID_Noresultsfound");
               Combo_prdid_Emptyitemtext = cgiGet( "COMBO_PRDID_Emptyitemtext");
               Combo_prdid_Onlyselectedvalues = cgiGet( "COMBO_PRDID_Onlyselectedvalues");
               Combo_prdid_Selectalltext = cgiGet( "COMBO_PRDID_Selectalltext");
               Combo_prdid_Multiplevaluesseparator = cgiGet( "COMBO_PRDID_Multiplevaluesseparator");
               Combo_prdid_Addnewoptiontext = cgiGet( "COMBO_PRDID_Addnewoptiontext");
               Combo_prdid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRDID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               /* Read variables values. */
               A236TppCodigo = cgiGet( edtTppCodigo_Internalname);
               AssignAttri("", false, "A236TppCodigo", A236TppCodigo);
               A237TppNome = StringUtil.Upper( cgiGet( edtTppNome_Internalname));
               AssignAttri("", false, "A237TppNome", A237TppNome);
               if ( StringUtil.StrCmp(cgiGet( edtTppID_Internalname), "") == 0 )
               {
                  A235TppID = Guid.Empty;
                  AssignAttri("", false, "A235TppID", A235TppID.ToString());
               }
               else
               {
                  try
                  {
                     A235TppID = StringUtil.StrToGuid( cgiGet( edtTppID_Internalname));
                     AssignAttri("", false, "A235TppID", A235TppID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "TPPID");
                     AnyError = 1;
                     GX_FocusControl = edtTppID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( context.localUtil.VCDate( cgiGet( edtTppInsData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Incluído em"}), 1, "TPPINSDATA");
                  AnyError = 1;
                  GX_FocusControl = edtTppInsData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A238TppInsData = DateTime.MinValue;
                  AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
               }
               else
               {
                  A238TppInsData = context.localUtil.CToD( cgiGet( edtTppInsData_Internalname), 2);
                  AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtTppInsHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Incluído em"}), 1, "TPPINSHORA");
                  AnyError = 1;
                  GX_FocusControl = edtTppInsHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A239TppInsHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A239TppInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtTppInsHora_Internalname)));
                  AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtTppInsDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Incluído em"}), 1, "TPPINSDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtTppInsDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A240TppInsDataHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
               }
               else
               {
                  A240TppInsDataHora = context.localUtil.CToT( cgiGet( edtTppInsDataHora_Internalname));
                  AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
               }
               A241TppInsUsuID = cgiGet( edtTppInsUsuID_Internalname);
               n241TppInsUsuID = false;
               AssignAttri("", false, "A241TppInsUsuID", A241TppInsUsuID);
               n241TppInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A241TppInsUsuID)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtTppUpdData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Alterado em"}), 1, "TPPUPDDATA");
                  AnyError = 1;
                  GX_FocusControl = edtTppUpdData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A242TppUpdData = DateTime.MinValue;
                  n242TppUpdData = false;
                  AssignAttri("", false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
               }
               else
               {
                  A242TppUpdData = context.localUtil.CToD( cgiGet( edtTppUpdData_Internalname), 2);
                  n242TppUpdData = false;
                  AssignAttri("", false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
               }
               n242TppUpdData = ((DateTime.MinValue==A242TppUpdData) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtTppUpdHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Alterado em"}), 1, "TPPUPDHORA");
                  AnyError = 1;
                  GX_FocusControl = edtTppUpdHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A243TppUpdHora = (DateTime)(DateTime.MinValue);
                  n243TppUpdHora = false;
                  AssignAttri("", false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A243TppUpdHora = context.localUtil.CToT( cgiGet( edtTppUpdHora_Internalname));
                  n243TppUpdHora = false;
                  AssignAttri("", false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
               }
               n243TppUpdHora = ((DateTime.MinValue==A243TppUpdHora) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtTppUpdDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Alterado em"}), 1, "TPPUPDDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtTppUpdDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
                  n244TppUpdDataHora = false;
                  AssignAttri("", false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A244TppUpdDataHora = context.localUtil.CToT( cgiGet( edtTppUpdDataHora_Internalname));
                  n244TppUpdDataHora = false;
                  AssignAttri("", false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               n244TppUpdDataHora = ((DateTime.MinValue==A244TppUpdDataHora) ? true : false);
               A245TppUpdUsuID = cgiGet( edtTppUpdUsuID_Internalname);
               n245TppUpdUsuID = false;
               AssignAttri("", false, "A245TppUpdUsuID", A245TppUpdUsuID);
               n245TppUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A245TppUpdUsuID)) ? true : false);
               A246TppAtivo = StringUtil.StrToBool( cgiGet( edtTppAtivo_Internalname));
               n246TppAtivo = false;
               AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
               n246TppAtivo = ((false==A246TppAtivo) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"TabelaDePreco");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV17Pgmname, "")));
               forbiddenHiddens.Add("TppUpdUsuNome", StringUtil.RTrim( context.localUtil.Format( A434TppUpdUsuNome, "@!")));
               forbiddenHiddens.Add("TppDel", StringUtil.BoolToStr( A602TppDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A235TppID != Z235TppID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\tabeladepreco:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
                  GxWebError = 1;
                  context.HttpContext.Response.StatusCode = 403;
                  context.WriteHtmlText( "<title>403 Forbidden</title>") ;
                  context.WriteHtmlText( "<h1>403 Forbidden</h1>") ;
                  context.WriteHtmlText( "<p /><hr />") ;
                  GXUtil.WriteLog("send_http_error_code " + 403.ToString());
                  AnyError = 1;
                  return  ;
               }
               /* Check if conditions changed and reset current page numbers */
               standaloneNotModal( ) ;
            }
            else
            {
               standaloneNotModal( ) ;
               if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
               {
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  A235TppID = StringUtil.StrToGuid( GetPar( "TppID"));
                  AssignAttri("", false, "A235TppID", A235TppID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7TppID) )
                  {
                     A235TppID = AV7TppID;
                     AssignAttri("", false, "A235TppID", A235TppID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A235TppID) && ( Gx_BScreen == 0 ) )
                     {
                        A235TppID = Guid.NewGuid( );
                        AssignAttri("", false, "A235TppID", A235TppID.ToString());
                     }
                  }
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode29 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7TppID) )
                     {
                        A235TppID = AV7TppID;
                        AssignAttri("", false, "A235TppID", A235TppID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A235TppID) && ( Gx_BScreen == 0 ) )
                        {
                           A235TppID = Guid.NewGuid( );
                           AssignAttri("", false, "A235TppID", A235TppID.ToString());
                        }
                     }
                     Gx_mode = sMode29;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound29 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0T0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "TPPID");
                        AnyError = 1;
                        GX_FocusControl = edtTppID_Internalname;
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
                           E110T2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120T2 ();
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
            E120T2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0T29( ) ;
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
            DisableAttributes0T29( ) ;
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

      protected void CONFIRM_0T0( )
      {
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0T29( ) ;
            }
            else
            {
               CheckExtendedTable0T29( ) ;
               CloseExtendedTableCursors0T29( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            /* Save parent mode. */
            sMode29 = Gx_mode;
            CONFIRM_0T30( ) ;
            if ( AnyError == 0 )
            {
               /* Restore parent mode. */
               Gx_mode = sMode29;
               AssignAttri("", false, "Gx_mode", Gx_mode);
               IsConfirmed = 1;
               AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
            }
            /* Restore parent mode. */
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
      }

      protected void CONFIRM_0T30( )
      {
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow0T30( ) ;
            if ( ( nRcdExists_30 != 0 ) || ( nIsMod_30 != 0 ) )
            {
               GetKey0T30( ) ;
               if ( ( nRcdExists_30 == 0 ) && ( nRcdDeleted_30 == 0 ) )
               {
                  if ( RcdFound30 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0T30( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0T30( ) ;
                        CloseExtendedTableCursors0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "PRDID_" + sGXsfl_33_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtPrdID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound30 != 0 )
                  {
                     if ( nRcdDeleted_30 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0T30( ) ;
                        Load0T30( ) ;
                        BeforeValidate0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0T30( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_30 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0T30( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0T30( ) ;
                              CloseExtendedTableCursors0T30( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_30 == 0 )
                     {
                        GXCCtl = "PRDID_" + sGXsfl_33_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPrdID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPrdID_Internalname, A220PrdID.ToString()) ;
            ChangePostValue( edtPrdCodigo_Internalname, A221PrdCodigo) ;
            ChangePostValue( edtPrdNome_Internalname, A222PrdNome) ;
            ChangePostValue( edtPrdTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 11, 0, ",", ""))) ;
            ChangePostValue( chkPrdAtivo_Internalname, StringUtil.BoolToStr( A231PrdAtivo)) ;
            ChangePostValue( edtTpp1Preco_Internalname, StringUtil.LTrim( StringUtil.NToC( A247Tpp1Preco, 23, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z220PrdID_"+sGXsfl_33_idx, Z220PrdID.ToString()) ;
            ChangePostValue( "ZT_"+"Z609Tpp1DelDataHora_"+sGXsfl_33_idx, context.localUtil.TToC( Z609Tpp1DelDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z610Tpp1DelData_"+sGXsfl_33_idx, context.localUtil.TToC( Z610Tpp1DelData, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z611Tpp1DelHora_"+sGXsfl_33_idx, context.localUtil.TToC( Z611Tpp1DelHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z612Tpp1DelUsuId_"+sGXsfl_33_idx, StringUtil.RTrim( Z612Tpp1DelUsuId)) ;
            ChangePostValue( "ZT_"+"Z613Tpp1DelUsuNome_"+sGXsfl_33_idx, Z613Tpp1DelUsuNome) ;
            ChangePostValue( "ZT_"+"Z247Tpp1Preco_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( Z247Tpp1Preco, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z608Tpp1Del_"+sGXsfl_33_idx, StringUtil.BoolToStr( Z608Tpp1Del)) ;
            ChangePostValue( "T608Tpp1Del_"+sGXsfl_33_idx, StringUtil.BoolToStr( O608Tpp1Del)) ;
            ChangePostValue( "nRcdDeleted_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_30), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_30), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_30), 4, 0, ",", ""))) ;
            if ( nIsMod_30 != 0 )
            {
               ChangePostValue( "PRDID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDCODIGO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdCodigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDNOME_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDTIPOID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdTipoID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDATIVO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPrdAtivo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TPP1PRECO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTpp1Preco_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0T0( )
      {
      }

      protected void E110T2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("TPPID");
         AV12WebSession.Remove("TPPCODIGO");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV14DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV14DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         GXt_char2 = "";
         new GeneXus.Programs.wwpbaseobjects.wwp_getstyleddvcombo(context ).execute(  "Title and subtitle", out  GXt_char2) ;
         Combo_prdid_Htmltemplate = GXt_char2;
         ucCombo_prdid.SendProperty(context, "", false, Combo_prdid_Internalname, "HTMLTemplate", Combo_prdid_Htmltemplate);
         Combo_prdid_Titlecontrolidtoreplace = edtPrdID_Internalname;
         ucCombo_prdid.SendProperty(context, "", false, Combo_prdid_Internalname, "TitleControlIdToReplace", Combo_prdid_Titlecontrolidtoreplace);
         /* Execute user subroutine: 'LOADCOMBOPRDID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtTppID_Visible = 0;
         AssignProp("", false, edtTppID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppID_Visible), 5, 0), true);
         edtTppInsData_Visible = 0;
         AssignProp("", false, edtTppInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsData_Visible), 5, 0), true);
         edtTppInsHora_Visible = 0;
         AssignProp("", false, edtTppInsHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsHora_Visible), 5, 0), true);
         edtTppInsDataHora_Visible = 0;
         AssignProp("", false, edtTppInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsDataHora_Visible), 5, 0), true);
         edtTppInsUsuID_Visible = 0;
         AssignProp("", false, edtTppInsUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppInsUsuID_Visible), 5, 0), true);
         edtTppUpdData_Visible = 0;
         AssignProp("", false, edtTppUpdData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdData_Visible), 5, 0), true);
         edtTppUpdHora_Visible = 0;
         AssignProp("", false, edtTppUpdHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdHora_Visible), 5, 0), true);
         edtTppUpdDataHora_Visible = 0;
         AssignProp("", false, edtTppUpdDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdDataHora_Visible), 5, 0), true);
         edtTppUpdUsuID_Visible = 0;
         AssignProp("", false, edtTppUpdUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppUpdUsuID_Visible), 5, 0), true);
         edtTppAtivo_Visible = 0;
         AssignProp("", false, edtTppAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtTppAtivo_Visible), 5, 0), true);
      }

      protected void E120T2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV16AuditingObject,  AV17Pgmname) ;
         AV12WebSession.Set("TPPID", StringUtil.Trim( A235TppID.ToString()));
         AV12WebSession.Set("TPPCODIGO", A236TppCodigo);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.tabeladeprecoww.aspx") );
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

      protected void S112( )
      {
         /* 'LOADCOMBOPRDID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item3 = AV13PrdID_Data;
         new GeneXus.Programs.core.tabeladeprecoloaddvcombo(context ).execute(  "PrdID",  Gx_mode,  AV7TppID, out  AV15ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item3) ;
         AV13PrdID_Data = GXt_objcol_SdtDVB_SDTComboData_Item3;
      }

      protected void ZM0T29( short GX_JID )
      {
         if ( ( GX_JID == 34 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z240TppInsDataHora = T000T6_A240TppInsDataHora[0];
               Z238TppInsData = T000T6_A238TppInsData[0];
               Z239TppInsHora = T000T6_A239TppInsHora[0];
               Z241TppInsUsuID = T000T6_A241TppInsUsuID[0];
               Z433TppInsUsuNome = T000T6_A433TppInsUsuNome[0];
               Z603TppDelDataHora = T000T6_A603TppDelDataHora[0];
               Z604TppDelData = T000T6_A604TppDelData[0];
               Z605TppDelHora = T000T6_A605TppDelHora[0];
               Z606TppDelUsuId = T000T6_A606TppDelUsuId[0];
               Z607TppDelUsuNome = T000T6_A607TppDelUsuNome[0];
               Z236TppCodigo = T000T6_A236TppCodigo[0];
               Z237TppNome = T000T6_A237TppNome[0];
               Z242TppUpdData = T000T6_A242TppUpdData[0];
               Z243TppUpdHora = T000T6_A243TppUpdHora[0];
               Z244TppUpdDataHora = T000T6_A244TppUpdDataHora[0];
               Z245TppUpdUsuID = T000T6_A245TppUpdUsuID[0];
               Z434TppUpdUsuNome = T000T6_A434TppUpdUsuNome[0];
               Z246TppAtivo = T000T6_A246TppAtivo[0];
               Z602TppDel = T000T6_A602TppDel[0];
            }
            else
            {
               Z240TppInsDataHora = A240TppInsDataHora;
               Z238TppInsData = A238TppInsData;
               Z239TppInsHora = A239TppInsHora;
               Z241TppInsUsuID = A241TppInsUsuID;
               Z433TppInsUsuNome = A433TppInsUsuNome;
               Z603TppDelDataHora = A603TppDelDataHora;
               Z604TppDelData = A604TppDelData;
               Z605TppDelHora = A605TppDelHora;
               Z606TppDelUsuId = A606TppDelUsuId;
               Z607TppDelUsuNome = A607TppDelUsuNome;
               Z236TppCodigo = A236TppCodigo;
               Z237TppNome = A237TppNome;
               Z242TppUpdData = A242TppUpdData;
               Z243TppUpdHora = A243TppUpdHora;
               Z244TppUpdDataHora = A244TppUpdDataHora;
               Z245TppUpdUsuID = A245TppUpdUsuID;
               Z434TppUpdUsuNome = A434TppUpdUsuNome;
               Z246TppAtivo = A246TppAtivo;
               Z602TppDel = A602TppDel;
            }
         }
         if ( GX_JID == -34 )
         {
            Z235TppID = A235TppID;
            Z240TppInsDataHora = A240TppInsDataHora;
            Z238TppInsData = A238TppInsData;
            Z239TppInsHora = A239TppInsHora;
            Z241TppInsUsuID = A241TppInsUsuID;
            Z433TppInsUsuNome = A433TppInsUsuNome;
            Z603TppDelDataHora = A603TppDelDataHora;
            Z604TppDelData = A604TppDelData;
            Z605TppDelHora = A605TppDelHora;
            Z606TppDelUsuId = A606TppDelUsuId;
            Z607TppDelUsuNome = A607TppDelUsuNome;
            Z236TppCodigo = A236TppCodigo;
            Z237TppNome = A237TppNome;
            Z242TppUpdData = A242TppUpdData;
            Z243TppUpdHora = A243TppUpdHora;
            Z244TppUpdDataHora = A244TppUpdDataHora;
            Z245TppUpdUsuID = A245TppUpdUsuID;
            Z434TppUpdUsuNome = A434TppUpdUsuNome;
            Z246TppAtivo = A246TppAtivo;
            Z602TppDel = A602TppDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV17Pgmname = "core.TabelaDePreco";
         AssignAttri("", false, "AV17Pgmname", AV17Pgmname);
         if ( ! (Guid.Empty==AV7TppID) )
         {
            edtTppID_Enabled = 0;
            AssignProp("", false, edtTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppID_Enabled), 5, 0), true);
         }
         else
         {
            edtTppID_Enabled = 1;
            AssignProp("", false, edtTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7TppID) )
         {
            edtTppID_Enabled = 0;
            AssignProp("", false, edtTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppID_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7TppID) )
         {
            A235TppID = AV7TppID;
            AssignAttri("", false, "A235TppID", A235TppID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A235TppID) && ( Gx_BScreen == 0 ) )
            {
               A235TppID = Guid.NewGuid( );
               AssignAttri("", false, "A235TppID", A235TppID.ToString());
            }
         }
         if ( IsIns( )  && (false==A246TppAtivo) && ( Gx_BScreen == 0 ) )
         {
            A246TppAtivo = true;
            n246TppAtivo = false;
            AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0T29( )
      {
         /* Using cursor T000T7 */
         pr_default.execute(5, new Object[] {A235TppID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound29 = 1;
            A240TppInsDataHora = T000T7_A240TppInsDataHora[0];
            AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
            A238TppInsData = T000T7_A238TppInsData[0];
            AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
            A239TppInsHora = T000T7_A239TppInsHora[0];
            AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
            A241TppInsUsuID = T000T7_A241TppInsUsuID[0];
            n241TppInsUsuID = T000T7_n241TppInsUsuID[0];
            AssignAttri("", false, "A241TppInsUsuID", A241TppInsUsuID);
            A433TppInsUsuNome = T000T7_A433TppInsUsuNome[0];
            n433TppInsUsuNome = T000T7_n433TppInsUsuNome[0];
            A603TppDelDataHora = T000T7_A603TppDelDataHora[0];
            n603TppDelDataHora = T000T7_n603TppDelDataHora[0];
            A604TppDelData = T000T7_A604TppDelData[0];
            n604TppDelData = T000T7_n604TppDelData[0];
            A605TppDelHora = T000T7_A605TppDelHora[0];
            n605TppDelHora = T000T7_n605TppDelHora[0];
            A606TppDelUsuId = T000T7_A606TppDelUsuId[0];
            n606TppDelUsuId = T000T7_n606TppDelUsuId[0];
            A607TppDelUsuNome = T000T7_A607TppDelUsuNome[0];
            n607TppDelUsuNome = T000T7_n607TppDelUsuNome[0];
            A236TppCodigo = T000T7_A236TppCodigo[0];
            AssignAttri("", false, "A236TppCodigo", A236TppCodigo);
            A237TppNome = T000T7_A237TppNome[0];
            AssignAttri("", false, "A237TppNome", A237TppNome);
            A242TppUpdData = T000T7_A242TppUpdData[0];
            n242TppUpdData = T000T7_n242TppUpdData[0];
            AssignAttri("", false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
            A243TppUpdHora = T000T7_A243TppUpdHora[0];
            n243TppUpdHora = T000T7_n243TppUpdHora[0];
            AssignAttri("", false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
            A244TppUpdDataHora = T000T7_A244TppUpdDataHora[0];
            n244TppUpdDataHora = T000T7_n244TppUpdDataHora[0];
            AssignAttri("", false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A245TppUpdUsuID = T000T7_A245TppUpdUsuID[0];
            n245TppUpdUsuID = T000T7_n245TppUpdUsuID[0];
            AssignAttri("", false, "A245TppUpdUsuID", A245TppUpdUsuID);
            A434TppUpdUsuNome = T000T7_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = T000T7_n434TppUpdUsuNome[0];
            A246TppAtivo = T000T7_A246TppAtivo[0];
            n246TppAtivo = T000T7_n246TppAtivo[0];
            AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
            A602TppDel = T000T7_A602TppDel[0];
            ZM0T29( -34) ;
         }
         pr_default.close(5);
         OnLoadActions0T29( ) ;
      }

      protected void OnLoadActions0T29( )
      {
      }

      protected void CheckExtendedTable0T29( )
      {
         nIsDirty_29 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000T8 */
         pr_default.execute(6, new Object[] {A236TppCodigo, A235TppID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "TPPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTppCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(6);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A236TppCodigo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Código", "", "", "", "", "", "", "", ""), 1, "TPPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTppCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A237TppNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "TPPNOME");
            AnyError = 1;
            GX_FocusControl = edtTppNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0T29( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0T29( )
      {
         /* Using cursor T000T9 */
         pr_default.execute(7, new Object[] {A235TppID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound29 = 1;
         }
         else
         {
            RcdFound29 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000T6 */
         pr_default.execute(4, new Object[] {A235TppID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            ZM0T29( 34) ;
            RcdFound29 = 1;
            A235TppID = T000T6_A235TppID[0];
            AssignAttri("", false, "A235TppID", A235TppID.ToString());
            A240TppInsDataHora = T000T6_A240TppInsDataHora[0];
            AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
            A238TppInsData = T000T6_A238TppInsData[0];
            AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
            A239TppInsHora = T000T6_A239TppInsHora[0];
            AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
            A241TppInsUsuID = T000T6_A241TppInsUsuID[0];
            n241TppInsUsuID = T000T6_n241TppInsUsuID[0];
            AssignAttri("", false, "A241TppInsUsuID", A241TppInsUsuID);
            A433TppInsUsuNome = T000T6_A433TppInsUsuNome[0];
            n433TppInsUsuNome = T000T6_n433TppInsUsuNome[0];
            A603TppDelDataHora = T000T6_A603TppDelDataHora[0];
            n603TppDelDataHora = T000T6_n603TppDelDataHora[0];
            A604TppDelData = T000T6_A604TppDelData[0];
            n604TppDelData = T000T6_n604TppDelData[0];
            A605TppDelHora = T000T6_A605TppDelHora[0];
            n605TppDelHora = T000T6_n605TppDelHora[0];
            A606TppDelUsuId = T000T6_A606TppDelUsuId[0];
            n606TppDelUsuId = T000T6_n606TppDelUsuId[0];
            A607TppDelUsuNome = T000T6_A607TppDelUsuNome[0];
            n607TppDelUsuNome = T000T6_n607TppDelUsuNome[0];
            A236TppCodigo = T000T6_A236TppCodigo[0];
            AssignAttri("", false, "A236TppCodigo", A236TppCodigo);
            A237TppNome = T000T6_A237TppNome[0];
            AssignAttri("", false, "A237TppNome", A237TppNome);
            A242TppUpdData = T000T6_A242TppUpdData[0];
            n242TppUpdData = T000T6_n242TppUpdData[0];
            AssignAttri("", false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
            A243TppUpdHora = T000T6_A243TppUpdHora[0];
            n243TppUpdHora = T000T6_n243TppUpdHora[0];
            AssignAttri("", false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
            A244TppUpdDataHora = T000T6_A244TppUpdDataHora[0];
            n244TppUpdDataHora = T000T6_n244TppUpdDataHora[0];
            AssignAttri("", false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A245TppUpdUsuID = T000T6_A245TppUpdUsuID[0];
            n245TppUpdUsuID = T000T6_n245TppUpdUsuID[0];
            AssignAttri("", false, "A245TppUpdUsuID", A245TppUpdUsuID);
            A434TppUpdUsuNome = T000T6_A434TppUpdUsuNome[0];
            n434TppUpdUsuNome = T000T6_n434TppUpdUsuNome[0];
            A246TppAtivo = T000T6_A246TppAtivo[0];
            n246TppAtivo = T000T6_n246TppAtivo[0];
            AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
            A602TppDel = T000T6_A602TppDel[0];
            O602TppDel = A602TppDel;
            AssignAttri("", false, "A602TppDel", A602TppDel);
            Z235TppID = A235TppID;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0T29( ) ;
            if ( AnyError == 1 )
            {
               RcdFound29 = 0;
               InitializeNonKey0T29( ) ;
            }
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound29 = 0;
            InitializeNonKey0T29( ) ;
            sMode29 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode29;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(4);
      }

      protected void getEqualNoModal( )
      {
         GetKey0T29( ) ;
         if ( RcdFound29 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound29 = 0;
         /* Using cursor T000T10 */
         pr_default.execute(8, new Object[] {A235TppID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000T10_A235TppID[0], A235TppID, 0) < 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000T10_A235TppID[0], A235TppID, 0) > 0 ) ) )
            {
               A235TppID = T000T10_A235TppID[0];
               AssignAttri("", false, "A235TppID", A235TppID.ToString());
               RcdFound29 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound29 = 0;
         /* Using cursor T000T11 */
         pr_default.execute(9, new Object[] {A235TppID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000T11_A235TppID[0], A235TppID, 0) > 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000T11_A235TppID[0], A235TppID, 0) < 0 ) ) )
            {
               A235TppID = T000T11_A235TppID[0];
               AssignAttri("", false, "A235TppID", A235TppID.ToString());
               RcdFound29 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0T29( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtTppCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0T29( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound29 == 1 )
            {
               if ( A235TppID != Z235TppID )
               {
                  A235TppID = Z235TppID;
                  AssignAttri("", false, "A235TppID", A235TppID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "TPPID");
                  AnyError = 1;
                  GX_FocusControl = edtTppID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtTppCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0T29( ) ;
                  GX_FocusControl = edtTppCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A235TppID != Z235TppID )
               {
                  /* Insert record */
                  GX_FocusControl = edtTppCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0T29( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "TPPID");
                     AnyError = 1;
                     GX_FocusControl = edtTppID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtTppCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0T29( ) ;
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
         if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
         {
            if ( AnyError == 0 )
            {
               context.nUserReturn = 1;
            }
         }
      }

      protected void btn_delete( )
      {
         if ( A235TppID != Z235TppID )
         {
            A235TppID = Z235TppID;
            AssignAttri("", false, "A235TppID", A235TppID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "TPPID");
            AnyError = 1;
            GX_FocusControl = edtTppID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtTppCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0T29( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T5 */
            pr_default.execute(3, new Object[] {A235TppID});
            if ( (pr_default.getStatus(3) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(3) == 101) || ( Z240TppInsDataHora != T000T5_A240TppInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z238TppInsData ) != DateTimeUtil.ResetTime ( T000T5_A238TppInsData[0] ) ) || ( Z239TppInsHora != T000T5_A239TppInsHora[0] ) || ( StringUtil.StrCmp(Z241TppInsUsuID, T000T5_A241TppInsUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z433TppInsUsuNome, T000T5_A433TppInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z603TppDelDataHora != T000T5_A603TppDelDataHora[0] ) || ( Z604TppDelData != T000T5_A604TppDelData[0] ) || ( Z605TppDelHora != T000T5_A605TppDelHora[0] ) || ( StringUtil.StrCmp(Z606TppDelUsuId, T000T5_A606TppDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z607TppDelUsuNome, T000T5_A607TppDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z236TppCodigo, T000T5_A236TppCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z237TppNome, T000T5_A237TppNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z242TppUpdData ) != DateTimeUtil.ResetTime ( T000T5_A242TppUpdData[0] ) ) || ( Z243TppUpdHora != T000T5_A243TppUpdHora[0] ) || ( Z244TppUpdDataHora != T000T5_A244TppUpdDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z245TppUpdUsuID, T000T5_A245TppUpdUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z434TppUpdUsuNome, T000T5_A434TppUpdUsuNome[0]) != 0 ) || ( Z246TppAtivo != T000T5_A246TppAtivo[0] ) || ( Z602TppDel != T000T5_A602TppDel[0] ) )
            {
               if ( Z240TppInsDataHora != T000T5_A240TppInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z240TppInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A240TppInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z238TppInsData ) != DateTimeUtil.ResetTime ( T000T5_A238TppInsData[0] ) )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppInsData");
                  GXUtil.WriteLogRaw("Old: ",Z238TppInsData);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A238TppInsData[0]);
               }
               if ( Z239TppInsHora != T000T5_A239TppInsHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z239TppInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A239TppInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z241TppInsUsuID, T000T5_A241TppInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z241TppInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A241TppInsUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z433TppInsUsuNome, T000T5_A433TppInsUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppInsUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z433TppInsUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A433TppInsUsuNome[0]);
               }
               if ( Z603TppDelDataHora != T000T5_A603TppDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z603TppDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A603TppDelDataHora[0]);
               }
               if ( Z604TppDelData != T000T5_A604TppDelData[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDelData");
                  GXUtil.WriteLogRaw("Old: ",Z604TppDelData);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A604TppDelData[0]);
               }
               if ( Z605TppDelHora != T000T5_A605TppDelHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z605TppDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A605TppDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z606TppDelUsuId, T000T5_A606TppDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z606TppDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A606TppDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z607TppDelUsuNome, T000T5_A607TppDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z607TppDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A607TppDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z236TppCodigo, T000T5_A236TppCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z236TppCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A236TppCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z237TppNome, T000T5_A237TppNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppNome");
                  GXUtil.WriteLogRaw("Old: ",Z237TppNome);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A237TppNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z242TppUpdData ) != DateTimeUtil.ResetTime ( T000T5_A242TppUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z242TppUpdData);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A242TppUpdData[0]);
               }
               if ( Z243TppUpdHora != T000T5_A243TppUpdHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z243TppUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A243TppUpdHora[0]);
               }
               if ( Z244TppUpdDataHora != T000T5_A244TppUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z244TppUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A244TppUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z245TppUpdUsuID, T000T5_A245TppUpdUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppUpdUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z245TppUpdUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A245TppUpdUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z434TppUpdUsuNome, T000T5_A434TppUpdUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppUpdUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z434TppUpdUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A434TppUpdUsuNome[0]);
               }
               if ( Z246TppAtivo != T000T5_A246TppAtivo[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z246TppAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A246TppAtivo[0]);
               }
               if ( Z602TppDel != T000T5_A602TppDel[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"TppDel");
                  GXUtil.WriteLogRaw("Old: ",Z602TppDel);
                  GXUtil.WriteLogRaw("Current: ",T000T5_A602TppDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_tabeladepreco"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T29( )
      {
         if ( ! IsAuthorized("tabeladepreco_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T29( 0) ;
            CheckOptimisticConcurrency0T29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T12 */
                     pr_default.execute(10, new Object[] {A235TppID, A240TppInsDataHora, A238TppInsData, A239TppInsHora, n241TppInsUsuID, A241TppInsUsuID, n433TppInsUsuNome, A433TppInsUsuNome, n603TppDelDataHora, A603TppDelDataHora, n604TppDelData, A604TppDelData, n605TppDelHora, A605TppDelHora, n606TppDelUsuId, A606TppDelUsuId, n607TppDelUsuNome, A607TppDelUsuNome, A236TppCodigo, A237TppNome, n242TppUpdData, A242TppUpdData, n243TppUpdHora, A243TppUpdHora, n244TppUpdDataHora, A244TppUpdDataHora, n245TppUpdUsuID, A245TppUpdUsuID, n434TppUpdUsuNome, A434TppUpdUsuNome, n246TppAtivo, A246TppAtivo, A602TppDel});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
                     if ( (pr_default.getStatus(10) == 1) )
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
                           ProcessLevel0T29( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
                              }
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
            else
            {
               Load0T29( ) ;
            }
            EndLevel0T29( ) ;
         }
         CloseExtendedTableCursors0T29( ) ;
      }

      protected void Update0T29( )
      {
         if ( ! IsAuthorized("tabeladepreco_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T29( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T29( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0T29( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T13 */
                     pr_default.execute(11, new Object[] {A240TppInsDataHora, A238TppInsData, A239TppInsHora, n241TppInsUsuID, A241TppInsUsuID, n433TppInsUsuNome, A433TppInsUsuNome, n603TppDelDataHora, A603TppDelDataHora, n604TppDelData, A604TppDelData, n605TppDelHora, A605TppDelHora, n606TppDelUsuId, A606TppDelUsuId, n607TppDelUsuNome, A607TppDelUsuNome, A236TppCodigo, A237TppNome, n242TppUpdData, A242TppUpdData, n243TppUpdHora, A243TppUpdHora, n244TppUpdDataHora, A244TppUpdDataHora, n245TppUpdUsuID, A245TppUpdUsuID, n434TppUpdUsuNome, A434TppUpdUsuNome, n246TppAtivo, A246TppAtivo, A602TppDel, A235TppID});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
                     if ( (pr_default.getStatus(11) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0T29( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0T29( ) ;
                           if ( AnyError == 0 )
                           {
                              if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
                              {
                                 if ( AnyError == 0 )
                                 {
                                    context.nUserReturn = 1;
                                 }
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
            EndLevel0T29( ) ;
         }
         CloseExtendedTableCursors0T29( ) ;
      }

      protected void DeferredUpdate0T29( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("tabeladepreco_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T29( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T29( ) ;
            AfterConfirm0T29( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T29( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0T30( ) ;
                  while ( RcdFound30 != 0 )
                  {
                     getByPrimaryKey0T30( ) ;
                     Delete0T30( ) ;
                     ScanNext0T30( ) ;
                  }
                  ScanEnd0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T14 */
                     pr_default.execute(12, new Object[] {A235TppID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           if ( IsIns( ) || IsUpd( ) || IsDlt( ) )
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
         }
         sMode29 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0T29( ) ;
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T29( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000T15 */
            pr_default.execute(13, new Object[] {A235TppID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000T16 */
            pr_default.execute(14, new Object[] {A235TppID});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"+" ("+"Produto da Tabela de Preço"+")"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0T30( )
      {
         nGXsfl_33_idx = 0;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            ReadRow0T30( ) ;
            if ( ( nRcdExists_30 != 0 ) || ( nIsMod_30 != 0 ) )
            {
               standaloneNotModal0T30( ) ;
               GetKey0T30( ) ;
               if ( ( nRcdExists_30 == 0 ) && ( nRcdDeleted_30 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0T30( ) ;
               }
               else
               {
                  if ( RcdFound30 != 0 )
                  {
                     if ( ( nRcdDeleted_30 != 0 ) && ( nRcdExists_30 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0T30( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_30 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0T30( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_30 == 0 )
                     {
                        GXCCtl = "PRDID_" + sGXsfl_33_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtPrdID_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtPrdID_Internalname, A220PrdID.ToString()) ;
            ChangePostValue( edtPrdCodigo_Internalname, A221PrdCodigo) ;
            ChangePostValue( edtPrdNome_Internalname, A222PrdNome) ;
            ChangePostValue( edtPrdTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 11, 0, ",", ""))) ;
            ChangePostValue( chkPrdAtivo_Internalname, StringUtil.BoolToStr( A231PrdAtivo)) ;
            ChangePostValue( edtTpp1Preco_Internalname, StringUtil.LTrim( StringUtil.NToC( A247Tpp1Preco, 23, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z220PrdID_"+sGXsfl_33_idx, Z220PrdID.ToString()) ;
            ChangePostValue( "ZT_"+"Z609Tpp1DelDataHora_"+sGXsfl_33_idx, context.localUtil.TToC( Z609Tpp1DelDataHora, 10, 12, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z610Tpp1DelData_"+sGXsfl_33_idx, context.localUtil.TToC( Z610Tpp1DelData, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z611Tpp1DelHora_"+sGXsfl_33_idx, context.localUtil.TToC( Z611Tpp1DelHora, 10, 8, 0, 0, "/", ":", " ")) ;
            ChangePostValue( "ZT_"+"Z612Tpp1DelUsuId_"+sGXsfl_33_idx, StringUtil.RTrim( Z612Tpp1DelUsuId)) ;
            ChangePostValue( "ZT_"+"Z613Tpp1DelUsuNome_"+sGXsfl_33_idx, Z613Tpp1DelUsuNome) ;
            ChangePostValue( "ZT_"+"Z247Tpp1Preco_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( Z247Tpp1Preco, 16, 2, ",", ""))) ;
            ChangePostValue( "ZT_"+"Z608Tpp1Del_"+sGXsfl_33_idx, StringUtil.BoolToStr( Z608Tpp1Del)) ;
            ChangePostValue( "T608Tpp1Del_"+sGXsfl_33_idx, StringUtil.BoolToStr( O608Tpp1Del)) ;
            ChangePostValue( "nRcdDeleted_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_30), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_30), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_30_"+sGXsfl_33_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_30), 4, 0, ",", ""))) ;
            if ( nIsMod_30 != 0 )
            {
               ChangePostValue( "PRDID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDCODIGO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdCodigo_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDNOME_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdNome_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDTIPOID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdTipoID_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "PRDATIVO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPrdAtivo.Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "TPP1PRECO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTpp1Preco_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0T30( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_30 = 0;
         nIsMod_30 = 0;
         nRcdDeleted_30 = 0;
      }

      protected void ProcessLevel0T29( )
      {
         /* Save parent mode. */
         sMode29 = Gx_mode;
         ProcessNestedLevel0T30( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode29;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0T29( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(3);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0T29( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.tabeladepreco",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0T0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.tabeladepreco",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T29( )
      {
         /* Scan By routine */
         /* Using cursor T000T17 */
         pr_default.execute(15);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound29 = 1;
            A235TppID = T000T17_A235TppID[0];
            AssignAttri("", false, "A235TppID", A235TppID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T29( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound29 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound29 = 1;
            A235TppID = T000T17_A235TppID[0];
            AssignAttri("", false, "A235TppID", A235TppID.ToString());
         }
      }

      protected void ScanEnd0T29( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0T29( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T29( )
      {
         /* Before Insert Rules */
         A240TppInsDataHora = DateTimeUtil.Now( context);
         AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
         A241TppInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n241TppInsUsuID = false;
         AssignAttri("", false, "A241TppInsUsuID", A241TppInsUsuID);
         A433TppInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n433TppInsUsuNome = false;
         AssignAttri("", false, "A433TppInsUsuNome", A433TppInsUsuNome);
         A238TppInsData = DateTimeUtil.ResetTime( A240TppInsDataHora);
         AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
         A239TppInsHora = DateTimeUtil.ResetDate(A240TppInsDataHora);
         AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate0T29( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A603TppDelDataHora = DateTimeUtil.NowMS( context);
            n603TppDelDataHora = false;
            AssignAttri("", false, "A603TppDelDataHora", context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A606TppDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n606TppDelUsuId = false;
            AssignAttri("", false, "A606TppDelUsuId", A606TppDelUsuId);
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A607TppDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n607TppDelUsuNome = false;
            AssignAttri("", false, "A607TppDelUsuNome", A607TppDelUsuNome);
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A604TppDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A603TppDelDataHora) ) ;
            n604TppDelData = false;
            AssignAttri("", false, "A604TppDelData", context.localUtil.TToC( A604TppDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A602TppDel && ( O602TppDel != A602TppDel ) )
         {
            A605TppDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A603TppDelDataHora));
            n605TppDelHora = false;
            AssignAttri("", false, "A605TppDelHora", context.localUtil.TToC( A605TppDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0T29( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
      }

      protected void BeforeComplete0T29( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0T29( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T29( )
      {
         edtTppCodigo_Enabled = 0;
         AssignProp("", false, edtTppCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppCodigo_Enabled), 5, 0), true);
         edtTppNome_Enabled = 0;
         AssignProp("", false, edtTppNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppNome_Enabled), 5, 0), true);
         edtTppID_Enabled = 0;
         AssignProp("", false, edtTppID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppID_Enabled), 5, 0), true);
         edtTppInsData_Enabled = 0;
         AssignProp("", false, edtTppInsData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppInsData_Enabled), 5, 0), true);
         edtTppInsHora_Enabled = 0;
         AssignProp("", false, edtTppInsHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppInsHora_Enabled), 5, 0), true);
         edtTppInsDataHora_Enabled = 0;
         AssignProp("", false, edtTppInsDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppInsDataHora_Enabled), 5, 0), true);
         edtTppInsUsuID_Enabled = 0;
         AssignProp("", false, edtTppInsUsuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppInsUsuID_Enabled), 5, 0), true);
         edtTppUpdData_Enabled = 0;
         AssignProp("", false, edtTppUpdData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppUpdData_Enabled), 5, 0), true);
         edtTppUpdHora_Enabled = 0;
         AssignProp("", false, edtTppUpdHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppUpdHora_Enabled), 5, 0), true);
         edtTppUpdDataHora_Enabled = 0;
         AssignProp("", false, edtTppUpdDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppUpdDataHora_Enabled), 5, 0), true);
         edtTppUpdUsuID_Enabled = 0;
         AssignProp("", false, edtTppUpdUsuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppUpdUsuID_Enabled), 5, 0), true);
         edtTppAtivo_Enabled = 0;
         AssignProp("", false, edtTppAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTppAtivo_Enabled), 5, 0), true);
      }

      protected void ZM0T30( short GX_JID )
      {
         if ( ( GX_JID == 36 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z609Tpp1DelDataHora = T000T3_A609Tpp1DelDataHora[0];
               Z610Tpp1DelData = T000T3_A610Tpp1DelData[0];
               Z611Tpp1DelHora = T000T3_A611Tpp1DelHora[0];
               Z612Tpp1DelUsuId = T000T3_A612Tpp1DelUsuId[0];
               Z613Tpp1DelUsuNome = T000T3_A613Tpp1DelUsuNome[0];
               Z247Tpp1Preco = T000T3_A247Tpp1Preco[0];
               Z608Tpp1Del = T000T3_A608Tpp1Del[0];
            }
            else
            {
               Z609Tpp1DelDataHora = A609Tpp1DelDataHora;
               Z610Tpp1DelData = A610Tpp1DelData;
               Z611Tpp1DelHora = A611Tpp1DelHora;
               Z612Tpp1DelUsuId = A612Tpp1DelUsuId;
               Z613Tpp1DelUsuNome = A613Tpp1DelUsuNome;
               Z247Tpp1Preco = A247Tpp1Preco;
               Z608Tpp1Del = A608Tpp1Del;
            }
         }
         if ( GX_JID == -36 )
         {
            Z235TppID = A235TppID;
            Z609Tpp1DelDataHora = A609Tpp1DelDataHora;
            Z610Tpp1DelData = A610Tpp1DelData;
            Z611Tpp1DelHora = A611Tpp1DelHora;
            Z612Tpp1DelUsuId = A612Tpp1DelUsuId;
            Z613Tpp1DelUsuNome = A613Tpp1DelUsuNome;
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z232PrdTipoID = A232PrdTipoID;
            Z247Tpp1Preco = A247Tpp1Preco;
            Z608Tpp1Del = A608Tpp1Del;
            Z220PrdID = A220PrdID;
            Z231PrdAtivo = A231PrdAtivo;
         }
      }

      protected void standaloneNotModal0T30( )
      {
         edtPrdCodigo_Enabled = 0;
         AssignProp("", false, edtPrdCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdCodigo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdTipoID_Enabled = 0;
         AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         chkPrdAtivo.Enabled = 0;
         AssignProp("", false, chkPrdAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPrdAtivo.Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void standaloneModal0T30( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtPrdID_Enabled = 0;
            AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         }
         else
         {
            edtPrdID_Enabled = 1;
            AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         }
      }

      protected void Load0T30( )
      {
         /* Using cursor T000T18 */
         pr_default.execute(16, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound30 = 1;
            A609Tpp1DelDataHora = T000T18_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = T000T18_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = T000T18_A610Tpp1DelData[0];
            n610Tpp1DelData = T000T18_n610Tpp1DelData[0];
            A611Tpp1DelHora = T000T18_A611Tpp1DelHora[0];
            n611Tpp1DelHora = T000T18_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = T000T18_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = T000T18_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = T000T18_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = T000T18_n613Tpp1DelUsuNome[0];
            A221PrdCodigo = T000T18_A221PrdCodigo[0];
            A222PrdNome = T000T18_A222PrdNome[0];
            A232PrdTipoID = T000T18_A232PrdTipoID[0];
            A231PrdAtivo = T000T18_A231PrdAtivo[0];
            A247Tpp1Preco = T000T18_A247Tpp1Preco[0];
            A608Tpp1Del = T000T18_A608Tpp1Del[0];
            ZM0T30( -36) ;
         }
         pr_default.close(16);
         OnLoadActions0T30( ) ;
      }

      protected void OnLoadActions0T30( )
      {
      }

      protected void CheckExtendedTable0T30( )
      {
         nIsDirty_30 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0T30( ) ;
         /* Using cursor T000T4 */
         pr_default.execute(2, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GXCCtl = "PRDID_" + sGXsfl_33_idx;
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221PrdCodigo = T000T4_A221PrdCodigo[0];
         A222PrdNome = T000T4_A222PrdNome[0];
         A232PrdTipoID = T000T4_A232PrdTipoID[0];
         A231PrdAtivo = T000T4_A231PrdAtivo[0];
         pr_default.close(2);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A222PrdNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "");
            AnyError = 1;
         }
         if ( (Guid.Empty==A220PrdID) )
         {
            GXCCtl = "PRDID_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( (Convert.ToDecimal(0)==A247Tpp1Preco) )
         {
            GXCCtl = "TPP1PRECO_" + sGXsfl_33_idx;
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Preço", "", "", "", "", "", "", "", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTpp1Preco_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0T30( )
      {
         pr_default.close(2);
      }

      protected void enableDisable0T30( )
      {
      }

      protected void gxLoad_37( Guid A220PrdID )
      {
         /* Using cursor T000T19 */
         pr_default.execute(17, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GXCCtl = "PRDID_" + sGXsfl_33_idx;
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A221PrdCodigo = T000T19_A221PrdCodigo[0];
         A222PrdNome = T000T19_A222PrdNome[0];
         A232PrdTipoID = T000T19_A232PrdTipoID[0];
         A231PrdAtivo = T000T19_A231PrdAtivo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A221PrdCodigo)+"\""+","+"\""+GXUtil.EncodeJSConstant( A222PrdNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 9, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A231PrdAtivo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(17) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(17);
      }

      protected void GetKey0T30( )
      {
         /* Using cursor T000T20 */
         pr_default.execute(18, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound30 = 1;
         }
         else
         {
            RcdFound30 = 0;
         }
         pr_default.close(18);
      }

      protected void getByPrimaryKey0T30( )
      {
         /* Using cursor T000T3 */
         pr_default.execute(1, new Object[] {A235TppID, A220PrdID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0T30( 36) ;
            RcdFound30 = 1;
            InitializeNonKey0T30( ) ;
            A609Tpp1DelDataHora = T000T3_A609Tpp1DelDataHora[0];
            n609Tpp1DelDataHora = T000T3_n609Tpp1DelDataHora[0];
            A610Tpp1DelData = T000T3_A610Tpp1DelData[0];
            n610Tpp1DelData = T000T3_n610Tpp1DelData[0];
            A611Tpp1DelHora = T000T3_A611Tpp1DelHora[0];
            n611Tpp1DelHora = T000T3_n611Tpp1DelHora[0];
            A612Tpp1DelUsuId = T000T3_A612Tpp1DelUsuId[0];
            n612Tpp1DelUsuId = T000T3_n612Tpp1DelUsuId[0];
            A613Tpp1DelUsuNome = T000T3_A613Tpp1DelUsuNome[0];
            n613Tpp1DelUsuNome = T000T3_n613Tpp1DelUsuNome[0];
            A247Tpp1Preco = T000T3_A247Tpp1Preco[0];
            A608Tpp1Del = T000T3_A608Tpp1Del[0];
            A220PrdID = T000T3_A220PrdID[0];
            O608Tpp1Del = A608Tpp1Del;
            AssignAttri("", false, "A608Tpp1Del", A608Tpp1Del);
            Z235TppID = A235TppID;
            Z220PrdID = A220PrdID;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0T30( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound30 = 0;
            InitializeNonKey0T30( ) ;
            sMode30 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0T30( ) ;
            Gx_mode = sMode30;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0T30( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0T30( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000T2 */
            pr_default.execute(0, new Object[] {A235TppID, A220PrdID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco_produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z609Tpp1DelDataHora != T000T2_A609Tpp1DelDataHora[0] ) || ( Z610Tpp1DelData != T000T2_A610Tpp1DelData[0] ) || ( Z611Tpp1DelHora != T000T2_A611Tpp1DelHora[0] ) || ( StringUtil.StrCmp(Z612Tpp1DelUsuId, T000T2_A612Tpp1DelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z613Tpp1DelUsuNome, T000T2_A613Tpp1DelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z247Tpp1Preco != T000T2_A247Tpp1Preco[0] ) || ( Z608Tpp1Del != T000T2_A608Tpp1Del[0] ) )
            {
               if ( Z609Tpp1DelDataHora != T000T2_A609Tpp1DelDataHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1DelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z609Tpp1DelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A609Tpp1DelDataHora[0]);
               }
               if ( Z610Tpp1DelData != T000T2_A610Tpp1DelData[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1DelData");
                  GXUtil.WriteLogRaw("Old: ",Z610Tpp1DelData);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A610Tpp1DelData[0]);
               }
               if ( Z611Tpp1DelHora != T000T2_A611Tpp1DelHora[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1DelHora");
                  GXUtil.WriteLogRaw("Old: ",Z611Tpp1DelHora);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A611Tpp1DelHora[0]);
               }
               if ( StringUtil.StrCmp(Z612Tpp1DelUsuId, T000T2_A612Tpp1DelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1DelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z612Tpp1DelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A612Tpp1DelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z613Tpp1DelUsuNome, T000T2_A613Tpp1DelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1DelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z613Tpp1DelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A613Tpp1DelUsuNome[0]);
               }
               if ( Z247Tpp1Preco != T000T2_A247Tpp1Preco[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1Preco");
                  GXUtil.WriteLogRaw("Old: ",Z247Tpp1Preco);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A247Tpp1Preco[0]);
               }
               if ( Z608Tpp1Del != T000T2_A608Tpp1Del[0] )
               {
                  GXUtil.WriteLog("core.tabeladepreco:[seudo value changed for attri]"+"Tpp1Del");
                  GXUtil.WriteLogRaw("Old: ",Z608Tpp1Del);
                  GXUtil.WriteLogRaw("Current: ",T000T2_A608Tpp1Del[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_tabeladepreco_produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0T30( )
      {
         if ( ! IsAuthorized("tabeladepreco_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0T30( 0) ;
            CheckOptimisticConcurrency0T30( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0T30( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000T21 */
                     pr_default.execute(19, new Object[] {A221PrdCodigo, A222PrdNome, A232PrdTipoID, A235TppID, n609Tpp1DelDataHora, A609Tpp1DelDataHora, n610Tpp1DelData, A610Tpp1DelData, n611Tpp1DelHora, A611Tpp1DelHora, n612Tpp1DelUsuId, A612Tpp1DelUsuId, n613Tpp1DelUsuNome, A613Tpp1DelUsuNome, A247Tpp1Preco, A608Tpp1Del, A220PrdID});
                     pr_default.close(19);
                     pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
                     if ( (pr_default.getStatus(19) == 1) )
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
               Load0T30( ) ;
            }
            EndLevel0T30( ) ;
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void Update0T30( )
      {
         if ( ! IsAuthorized("tabeladepreco_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0T30( ) ;
         }
         if ( ( nIsMod_30 != 0 ) || ( nIsDirty_30 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0T30( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0T30( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0T30( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000T22 */
                        pr_default.execute(20, new Object[] {A221PrdCodigo, A222PrdNome, A232PrdTipoID, n609Tpp1DelDataHora, A609Tpp1DelDataHora, n610Tpp1DelData, A610Tpp1DelData, n611Tpp1DelHora, A611Tpp1DelHora, n612Tpp1DelUsuId, A612Tpp1DelUsuId, n613Tpp1DelUsuNome, A613Tpp1DelUsuNome, A247Tpp1Preco, A608Tpp1Del, A235TppID, A220PrdID});
                        pr_default.close(20);
                        pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
                        if ( (pr_default.getStatus(20) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_tabeladepreco_produto"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0T30( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0T30( ) ;
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
               EndLevel0T30( ) ;
            }
         }
         CloseExtendedTableCursors0T30( ) ;
      }

      protected void DeferredUpdate0T30( )
      {
      }

      protected void Delete0T30( )
      {
         if ( ! IsAuthorized("tabeladepreco_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0T30( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0T30( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0T30( ) ;
            AfterConfirm0T30( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0T30( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000T23 */
                  pr_default.execute(21, new Object[] {A235TppID, A220PrdID});
                  pr_default.close(21);
                  pr_default.SmartCacheProvider.SetUpdated("tb_tabeladepreco_produto");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode30 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0T30( ) ;
         Gx_mode = sMode30;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0T30( )
      {
         standaloneModal0T30( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000T24 */
            pr_default.execute(22, new Object[] {A220PrdID});
            A221PrdCodigo = T000T24_A221PrdCodigo[0];
            A222PrdNome = T000T24_A222PrdNome[0];
            A232PrdTipoID = T000T24_A232PrdTipoID[0];
            A231PrdAtivo = T000T24_A231PrdAtivo[0];
            pr_default.close(22);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000T25 */
            pr_default.execute(23, new Object[] {A235TppID, A220PrdID});
            if ( (pr_default.getStatus(23) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Item da Oportunidade"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(23);
         }
      }

      protected void EndLevel0T30( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0T30( )
      {
         /* Scan By routine */
         /* Using cursor T000T26 */
         pr_default.execute(24, new Object[] {A235TppID});
         RcdFound30 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound30 = 1;
            A220PrdID = T000T26_A220PrdID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0T30( )
      {
         /* Scan next routine */
         pr_default.readNext(24);
         RcdFound30 = 0;
         if ( (pr_default.getStatus(24) != 101) )
         {
            RcdFound30 = 1;
            A220PrdID = T000T26_A220PrdID[0];
         }
      }

      protected void ScanEnd0T30( )
      {
         pr_default.close(24);
      }

      protected void AfterConfirm0T30( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0T30( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0T30( )
      {
         /* Before Update Rules */
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A609Tpp1DelDataHora = DateTimeUtil.NowMS( context);
            n609Tpp1DelDataHora = false;
            AssignAttri("", false, "A609Tpp1DelDataHora", context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A612Tpp1DelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n612Tpp1DelUsuId = false;
            AssignAttri("", false, "A612Tpp1DelUsuId", A612Tpp1DelUsuId);
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A613Tpp1DelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n613Tpp1DelUsuNome = false;
            AssignAttri("", false, "A613Tpp1DelUsuNome", A613Tpp1DelUsuNome);
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A610Tpp1DelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A609Tpp1DelDataHora) ) ;
            n610Tpp1DelData = false;
            AssignAttri("", false, "A610Tpp1DelData", context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A608Tpp1Del && ( O608Tpp1Del != A608Tpp1Del ) )
         {
            A611Tpp1DelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A609Tpp1DelDataHora));
            n611Tpp1DelHora = false;
            AssignAttri("", false, "A611Tpp1DelHora", context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0T30( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0T30( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0T30( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0T30( )
      {
         edtPrdID_Enabled = 0;
         AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdCodigo_Enabled = 0;
         AssignProp("", false, edtPrdCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdCodigo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdNome_Enabled = 0;
         AssignProp("", false, edtPrdNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdNome_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdTipoID_Enabled = 0;
         AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         chkPrdAtivo.Enabled = 0;
         AssignProp("", false, chkPrdAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPrdAtivo.Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtTpp1Preco_Enabled = 0;
         AssignProp("", false, edtTpp1Preco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtTpp1Preco_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void send_integrity_lvl_hashes0T30( )
      {
      }

      protected void send_integrity_lvl_hashes0T29( )
      {
      }

      protected void SubsflControlProps_3330( )
      {
         edtPrdID_Internalname = "PRDID_"+sGXsfl_33_idx;
         edtPrdCodigo_Internalname = "PRDCODIGO_"+sGXsfl_33_idx;
         edtPrdNome_Internalname = "PRDNOME_"+sGXsfl_33_idx;
         edtPrdTipoID_Internalname = "PRDTIPOID_"+sGXsfl_33_idx;
         chkPrdAtivo_Internalname = "PRDATIVO_"+sGXsfl_33_idx;
         edtTpp1Preco_Internalname = "TPP1PRECO_"+sGXsfl_33_idx;
      }

      protected void SubsflControlProps_fel_3330( )
      {
         edtPrdID_Internalname = "PRDID_"+sGXsfl_33_fel_idx;
         edtPrdCodigo_Internalname = "PRDCODIGO_"+sGXsfl_33_fel_idx;
         edtPrdNome_Internalname = "PRDNOME_"+sGXsfl_33_fel_idx;
         edtPrdTipoID_Internalname = "PRDTIPOID_"+sGXsfl_33_fel_idx;
         chkPrdAtivo_Internalname = "PRDATIVO_"+sGXsfl_33_fel_idx;
         edtTpp1Preco_Internalname = "TPP1PRECO_"+sGXsfl_33_fel_idx;
      }

      protected void AddRow0T30( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3330( ) ;
         SendRow0T30( ) ;
      }

      protected void SendRow0T30( )
      {
         Gridlevel_produtoRow = GXWebRow.GetNew(context);
         if ( subGridlevel_produto_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridlevel_produto_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridlevel_produto_Class, "") != 0 )
            {
               subGridlevel_produto_Linesclass = subGridlevel_produto_Class+"Odd";
            }
         }
         else if ( subGridlevel_produto_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridlevel_produto_Backstyle = 0;
            subGridlevel_produto_Backcolor = subGridlevel_produto_Allbackcolor;
            if ( StringUtil.StrCmp(subGridlevel_produto_Class, "") != 0 )
            {
               subGridlevel_produto_Linesclass = subGridlevel_produto_Class+"Uniform";
            }
         }
         else if ( subGridlevel_produto_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridlevel_produto_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridlevel_produto_Class, "") != 0 )
            {
               subGridlevel_produto_Linesclass = subGridlevel_produto_Class+"Odd";
            }
            subGridlevel_produto_Backcolor = (int)(0x0);
         }
         else if ( subGridlevel_produto_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridlevel_produto_Backstyle = 1;
            if ( ((int)((nGXsfl_33_idx) % (2))) == 0 )
            {
               subGridlevel_produto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_produto_Class, "") != 0 )
               {
                  subGridlevel_produto_Linesclass = subGridlevel_produto_Class+"Even";
               }
            }
            else
            {
               subGridlevel_produto_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridlevel_produto_Class, "") != 0 )
               {
                  subGridlevel_produto_Linesclass = subGridlevel_produto_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_30_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 34,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPrdID_Internalname,A220PrdID.ToString(),A220PrdID.ToString(),TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPrdID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtPrdID_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)36,(short)0,(short)0,(short)33,(short)0,(short)0,(short)0,(bool)true,(string)"",(string)"",(bool)false,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPrdCodigo_Internalname,(string)A221PrdCodigo,(string)"",(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPrdCodigo_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn hidden-sm hidden-md hidden-lg",(string)"",(short)0,(int)edtPrdCodigo_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)30,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\ProdutoCodigo",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPrdNome_Internalname,(string)A222PrdNome,StringUtil.RTrim( context.localUtil.Format( A222PrdNome, "@!")),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPrdNome_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn hidden-xs",(string)"",(short)-1,(int)edtPrdNome_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)80,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)-1,(bool)true,(string)"core\\Nome",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         ROClassString = "Attribute";
         Gridlevel_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtPrdTipoID_Internalname,StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 11, 0, ",", "")),StringUtil.LTrim( ((edtPrdTipoID_Enabled!=0) ? context.localUtil.Format( (decimal)(A232PrdTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A232PrdTipoID), "ZZZ,ZZZ,ZZ9"))),(string)"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtPrdTipoID_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)0,(int)edtPrdTipoID_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)11,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\ID_Autonum",(string)"end",(bool)false,(string)""});
         /* Subfile cell */
         /* Check box */
         ClassString = "Attribute";
         StyleString = "";
         GXCCtl = "PRDATIVO_" + sGXsfl_33_idx;
         chkPrdAtivo.Name = GXCCtl;
         chkPrdAtivo.WebTags = "";
         chkPrdAtivo.Caption = "";
         AssignProp("", false, chkPrdAtivo_Internalname, "TitleCaption", chkPrdAtivo.Caption, !bGXsfl_33_Refreshing);
         chkPrdAtivo.CheckedValue = "false";
         A231PrdAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A231PrdAtivo));
         Gridlevel_produtoRow.AddColumnProperties("checkbox", 1, isAjaxCallMode( ), new Object[] {(string)chkPrdAtivo_Internalname,StringUtil.BoolToStr( A231PrdAtivo),(string)"",(string)"",(short)0,chkPrdAtivo.Enabled,(string)"true",(string)"",(string)StyleString,(string)ClassString,(string)"TrnColumn",(string)"",(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_30_" + sGXsfl_33_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 39,'',false,'" + sGXsfl_33_idx + "',33)\"";
         ROClassString = "Attribute";
         Gridlevel_produtoRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtTpp1Preco_Internalname,StringUtil.LTrim( StringUtil.NToC( A247Tpp1Preco, 23, 2, ",", "")),StringUtil.LTrim( ((edtTpp1Preco_Enabled!=0) ? context.localUtil.Format( A247Tpp1Preco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99") : context.localUtil.Format( A247Tpp1Preco, "R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99"))),TempTags+" onchange=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_decimal( this, '.',',','2');"+";gx.evt.onblur(this,39);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtTpp1Preco_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"TrnColumn",(string)"",(short)-1,(int)edtTpp1Preco_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)23,(short)0,(short)0,(short)33,(short)0,(short)-1,(short)0,(bool)true,(string)"core\\Monetario",(string)"end",(bool)false,(string)""});
         ajax_sending_grid_row(Gridlevel_produtoRow);
         send_integrity_lvl_hashes0T30( ) ;
         GXCCtl = "Z220PrdID_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z220PrdID.ToString());
         GXCCtl = "Z609Tpp1DelDataHora_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z609Tpp1DelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "Z610Tpp1DelData_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z610Tpp1DelData, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z611Tpp1DelHora_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( Z611Tpp1DelHora, 10, 8, 0, 0, "/", ":", " "));
         GXCCtl = "Z612Tpp1DelUsuId_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Z612Tpp1DelUsuId));
         GXCCtl = "Z613Tpp1DelUsuNome_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z613Tpp1DelUsuNome);
         GXCCtl = "Z247Tpp1Preco_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( Z247Tpp1Preco, 16, 2, ",", "")));
         GXCCtl = "Z608Tpp1Del_" + sGXsfl_33_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, Z608Tpp1Del);
         GXCCtl = "O608Tpp1Del_" + sGXsfl_33_idx;
         GxWebStd.gx_boolean_hidden_field( context, GXCCtl, O608Tpp1Del);
         GXCCtl = "TPP1DELDATAHORA_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GXCCtl = "nRcdDeleted_30_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_30), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_30_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_30), 4, 0, ",", "")));
         GXCCtl = "nIsMod_30_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_30), 4, 0, ",", "")));
         GXCCtl = "vAUDITINGOBJECT_" + sGXsfl_33_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV16AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV16AuditingObject);
         }
         GXCCtl = "vPGMNAME_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( AV17Pgmname));
         GXCCtl = "vMODE_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.RTrim( Gx_mode));
         GXCCtl = "vTRNCONTEXT_" + sGXsfl_33_idx;
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, GXCCtl, AV11TrnContext);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt(GXCCtl, AV11TrnContext);
         }
         GXCCtl = "vTPPID_" + sGXsfl_33_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, AV7TppID.ToString());
         GxWebStd.gx_hidden_field( context, "PRDID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRDCODIGO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdCodigo_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRDNOME_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdNome_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRDTIPOID_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdTipoID_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "PRDATIVO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPrdAtivo.Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "TPP1PRECO_"+sGXsfl_33_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTpp1Preco_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridlevel_produtoContainer.AddRow(Gridlevel_produtoRow);
      }

      protected void ReadRow0T30( )
      {
         nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3330( ) ;
         edtPrdID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDID_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtPrdCodigo_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDCODIGO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtPrdNome_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDNOME_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtPrdTipoID_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDTIPOID_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         chkPrdAtivo.Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "PRDATIVO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtTpp1Preco_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "TPP1PRECO_"+sGXsfl_33_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         if ( StringUtil.StrCmp(cgiGet( edtPrdID_Internalname), "") == 0 )
         {
            A220PrdID = Guid.Empty;
         }
         else
         {
            try
            {
               A220PrdID = StringUtil.StrToGuid( cgiGet( edtPrdID_Internalname));
            }
            catch ( Exception  )
            {
               GXCCtl = "PRDID_" + sGXsfl_33_idx;
               GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, GXCCtl);
               AnyError = 1;
               GX_FocusControl = edtPrdID_Internalname;
               wbErr = true;
            }
         }
         A221PrdCodigo = cgiGet( edtPrdCodigo_Internalname);
         A222PrdNome = StringUtil.Upper( cgiGet( edtPrdNome_Internalname));
         A232PrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPrdTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
         A231PrdAtivo = StringUtil.StrToBool( cgiGet( chkPrdAtivo_Internalname));
         if ( ( ( context.localUtil.CToN( cgiGet( edtTpp1Preco_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtTpp1Preco_Internalname), ",", ".") > 9999999999999.99m ) ) )
         {
            GXCCtl = "TPP1PRECO_" + sGXsfl_33_idx;
            GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, GXCCtl);
            AnyError = 1;
            GX_FocusControl = edtTpp1Preco_Internalname;
            wbErr = true;
            A247Tpp1Preco = 0;
         }
         else
         {
            A247Tpp1Preco = context.localUtil.CToN( cgiGet( edtTpp1Preco_Internalname), ",", ".");
         }
         GXCCtl = "Z220PrdID_" + sGXsfl_33_idx;
         Z220PrdID = StringUtil.StrToGuid( cgiGet( GXCCtl));
         GXCCtl = "Z609Tpp1DelDataHora_" + sGXsfl_33_idx;
         Z609Tpp1DelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n609Tpp1DelDataHora = ((DateTime.MinValue==A609Tpp1DelDataHora) ? true : false);
         GXCCtl = "Z610Tpp1DelData_" + sGXsfl_33_idx;
         Z610Tpp1DelData = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n610Tpp1DelData = ((DateTime.MinValue==A610Tpp1DelData) ? true : false);
         GXCCtl = "Z611Tpp1DelHora_" + sGXsfl_33_idx;
         Z611Tpp1DelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         n611Tpp1DelHora = ((DateTime.MinValue==A611Tpp1DelHora) ? true : false);
         GXCCtl = "Z612Tpp1DelUsuId_" + sGXsfl_33_idx;
         Z612Tpp1DelUsuId = cgiGet( GXCCtl);
         n612Tpp1DelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A612Tpp1DelUsuId)) ? true : false);
         GXCCtl = "Z613Tpp1DelUsuNome_" + sGXsfl_33_idx;
         Z613Tpp1DelUsuNome = cgiGet( GXCCtl);
         n613Tpp1DelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A613Tpp1DelUsuNome)) ? true : false);
         GXCCtl = "Z247Tpp1Preco_" + sGXsfl_33_idx;
         Z247Tpp1Preco = context.localUtil.CToN( cgiGet( GXCCtl), ",", ".");
         GXCCtl = "Z608Tpp1Del_" + sGXsfl_33_idx;
         Z608Tpp1Del = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "Z609Tpp1DelDataHora_" + sGXsfl_33_idx;
         A609Tpp1DelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n609Tpp1DelDataHora = false;
         n609Tpp1DelDataHora = ((DateTime.MinValue==A609Tpp1DelDataHora) ? true : false);
         GXCCtl = "Z610Tpp1DelData_" + sGXsfl_33_idx;
         A610Tpp1DelData = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n610Tpp1DelData = false;
         n610Tpp1DelData = ((DateTime.MinValue==A610Tpp1DelData) ? true : false);
         GXCCtl = "Z611Tpp1DelHora_" + sGXsfl_33_idx;
         A611Tpp1DelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( GXCCtl), 0));
         n611Tpp1DelHora = false;
         n611Tpp1DelHora = ((DateTime.MinValue==A611Tpp1DelHora) ? true : false);
         GXCCtl = "Z612Tpp1DelUsuId_" + sGXsfl_33_idx;
         A612Tpp1DelUsuId = cgiGet( GXCCtl);
         n612Tpp1DelUsuId = false;
         n612Tpp1DelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A612Tpp1DelUsuId)) ? true : false);
         GXCCtl = "Z613Tpp1DelUsuNome_" + sGXsfl_33_idx;
         A613Tpp1DelUsuNome = cgiGet( GXCCtl);
         n613Tpp1DelUsuNome = false;
         n613Tpp1DelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A613Tpp1DelUsuNome)) ? true : false);
         GXCCtl = "Z608Tpp1Del_" + sGXsfl_33_idx;
         A608Tpp1Del = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "O608Tpp1Del_" + sGXsfl_33_idx;
         O608Tpp1Del = StringUtil.StrToBool( cgiGet( GXCCtl));
         GXCCtl = "TPP1DELDATAHORA_" + sGXsfl_33_idx;
         A609Tpp1DelDataHora = context.localUtil.CToT( cgiGet( GXCCtl), 0);
         n609Tpp1DelDataHora = ((DateTime.MinValue==A609Tpp1DelDataHora) ? true : false);
         GXCCtl = "nRcdDeleted_30_" + sGXsfl_33_idx;
         nRcdDeleted_30 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_30_" + sGXsfl_33_idx;
         nRcdExists_30 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_30_" + sGXsfl_33_idx;
         nIsMod_30 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defchkPrdAtivo_Enabled = chkPrdAtivo.Enabled;
         defedtPrdTipoID_Enabled = edtPrdTipoID_Enabled;
         defedtPrdCodigo_Enabled = edtPrdCodigo_Enabled;
         defedtPrdID_Enabled = edtPrdID_Enabled;
      }

      protected void ConfirmValues0T0( )
      {
         nGXsfl_33_idx = 0;
         sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
         SubsflControlProps_3330( ) ;
         while ( nGXsfl_33_idx < nRC_GXsfl_33 )
         {
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3330( ) ;
            ChangePostValue( "Z220PrdID_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z220PrdID_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z220PrdID_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z609Tpp1DelDataHora_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z609Tpp1DelDataHora_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z609Tpp1DelDataHora_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z610Tpp1DelData_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z610Tpp1DelData_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z610Tpp1DelData_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z611Tpp1DelHora_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z611Tpp1DelHora_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z611Tpp1DelHora_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z612Tpp1DelUsuId_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z612Tpp1DelUsuId_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z612Tpp1DelUsuId_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z613Tpp1DelUsuNome_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z613Tpp1DelUsuNome_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z613Tpp1DelUsuNome_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z247Tpp1Preco_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z247Tpp1Preco_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z247Tpp1Preco_"+sGXsfl_33_idx) ;
            ChangePostValue( "Z608Tpp1Del_"+sGXsfl_33_idx, cgiGet( "ZT_"+"Z608Tpp1Del_"+sGXsfl_33_idx)) ;
            DeletePostValue( "ZT_"+"Z608Tpp1Del_"+sGXsfl_33_idx) ;
         }
         ChangePostValue( "O608Tpp1Del", cgiGet( "T608Tpp1Del")) ;
         DeletePostValue( "T608Tpp1Del") ;
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
         context.AddJavascriptSource("calendar.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-setup.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("calendar-pt.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
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
         GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7TppID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"TabelaDePreco");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV17Pgmname, "")));
         forbiddenHiddens.Add("TppUpdUsuNome", StringUtil.RTrim( context.localUtil.Format( A434TppUpdUsuNome, "@!")));
         forbiddenHiddens.Add("TppDel", StringUtil.BoolToStr( A602TppDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\tabeladepreco:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z235TppID", Z235TppID.ToString());
         GxWebStd.gx_hidden_field( context, "Z240TppInsDataHora", context.localUtil.TToC( Z240TppInsDataHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z238TppInsData", context.localUtil.DToC( Z238TppInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z239TppInsHora", context.localUtil.TToC( Z239TppInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z241TppInsUsuID", StringUtil.RTrim( Z241TppInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z433TppInsUsuNome", Z433TppInsUsuNome);
         GxWebStd.gx_hidden_field( context, "Z603TppDelDataHora", context.localUtil.TToC( Z603TppDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z604TppDelData", context.localUtil.TToC( Z604TppDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z605TppDelHora", context.localUtil.TToC( Z605TppDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z606TppDelUsuId", StringUtil.RTrim( Z606TppDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z607TppDelUsuNome", Z607TppDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z236TppCodigo", Z236TppCodigo);
         GxWebStd.gx_hidden_field( context, "Z237TppNome", Z237TppNome);
         GxWebStd.gx_hidden_field( context, "Z242TppUpdData", context.localUtil.DToC( Z242TppUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z243TppUpdHora", context.localUtil.TToC( Z243TppUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z244TppUpdDataHora", context.localUtil.TToC( Z244TppUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z245TppUpdUsuID", StringUtil.RTrim( Z245TppUpdUsuID));
         GxWebStd.gx_hidden_field( context, "Z434TppUpdUsuNome", Z434TppUpdUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z246TppAtivo", Z246TppAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z602TppDel", Z602TppDel);
         GxWebStd.gx_boolean_hidden_field( context, "O602TppDel", O602TppDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_33", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_33_idx), 8, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV14DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRDID_DATA", AV13PrdID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRDID_DATA", AV13PrdID_Data);
         }
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
         GxWebStd.gx_hidden_field( context, "vTPPID", AV7TppID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vTPPID", GetSecureSignedToken( "", AV7TppID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "TPPINSUSUNOME", A433TppInsUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "TPPDEL", A602TppDel);
         GxWebStd.gx_hidden_field( context, "TPPDELDATAHORA", context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPPDELDATA", context.localUtil.TToC( A604TppDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPPDELHORA", context.localUtil.TToC( A605TppDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPPDELUSUID", StringUtil.RTrim( A606TppDelUsuId));
         GxWebStd.gx_hidden_field( context, "TPPDELUSUNOME", A607TppDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV16AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV16AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "TPPUPDUSUNOME", A434TppUpdUsuNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV17Pgmname));
         GxWebStd.gx_boolean_hidden_field( context, "TPP1DEL", A608Tpp1Del);
         GxWebStd.gx_hidden_field( context, "TPP1DELDATAHORA", context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPP1DELDATA", context.localUtil.TToC( A610Tpp1DelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPP1DELHORA", context.localUtil.TToC( A611Tpp1DelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "TPP1DELUSUID", StringUtil.RTrim( A612Tpp1DelUsuId));
         GxWebStd.gx_hidden_field( context, "TPP1DELUSUNOME", A613Tpp1DelUsuNome);
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
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Objectcall", StringUtil.RTrim( Combo_prdid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Cls", StringUtil.RTrim( Combo_prdid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Enabled", StringUtil.BoolToStr( Combo_prdid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Titlecontrolidtoreplace", StringUtil.RTrim( Combo_prdid_Titlecontrolidtoreplace));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Isgriditem", StringUtil.BoolToStr( Combo_prdid_Isgriditem));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDID_Htmltemplate", StringUtil.RTrim( Combo_prdid_Htmltemplate));
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
         GXEncryptionTmp = "core.tabeladepreco.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7TppID.ToString());
         return formatLink("core.tabeladepreco.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.TabelaDePreco" ;
      }

      public override string GetPgmdesc( )
      {
         return "Tabela de Preço do Produto ou Serviço" ;
      }

      protected void InitializeNonKey0T29( )
      {
         AV16AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A240TppInsDataHora", context.localUtil.TToC( A240TppInsDataHora, 10, 8, 0, 3, "/", ":", " "));
         A238TppInsData = DateTime.MinValue;
         AssignAttri("", false, "A238TppInsData", context.localUtil.Format(A238TppInsData, "99/99/99"));
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A239TppInsHora", context.localUtil.TToC( A239TppInsHora, 0, 5, 0, 3, "/", ":", " "));
         A241TppInsUsuID = "";
         n241TppInsUsuID = false;
         AssignAttri("", false, "A241TppInsUsuID", A241TppInsUsuID);
         n241TppInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A241TppInsUsuID)) ? true : false);
         A433TppInsUsuNome = "";
         n433TppInsUsuNome = false;
         AssignAttri("", false, "A433TppInsUsuNome", A433TppInsUsuNome);
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         n603TppDelDataHora = false;
         AssignAttri("", false, "A603TppDelDataHora", context.localUtil.TToC( A603TppDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A604TppDelData = (DateTime)(DateTime.MinValue);
         n604TppDelData = false;
         AssignAttri("", false, "A604TppDelData", context.localUtil.TToC( A604TppDelData, 10, 5, 0, 3, "/", ":", " "));
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         n605TppDelHora = false;
         AssignAttri("", false, "A605TppDelHora", context.localUtil.TToC( A605TppDelHora, 0, 5, 0, 3, "/", ":", " "));
         A606TppDelUsuId = "";
         n606TppDelUsuId = false;
         AssignAttri("", false, "A606TppDelUsuId", A606TppDelUsuId);
         A607TppDelUsuNome = "";
         n607TppDelUsuNome = false;
         AssignAttri("", false, "A607TppDelUsuNome", A607TppDelUsuNome);
         A236TppCodigo = "";
         AssignAttri("", false, "A236TppCodigo", A236TppCodigo);
         A237TppNome = "";
         AssignAttri("", false, "A237TppNome", A237TppNome);
         A242TppUpdData = DateTime.MinValue;
         n242TppUpdData = false;
         AssignAttri("", false, "A242TppUpdData", context.localUtil.Format(A242TppUpdData, "99/99/99"));
         n242TppUpdData = ((DateTime.MinValue==A242TppUpdData) ? true : false);
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         n243TppUpdHora = false;
         AssignAttri("", false, "A243TppUpdHora", context.localUtil.TToC( A243TppUpdHora, 10, 5, 0, 3, "/", ":", " "));
         n243TppUpdHora = ((DateTime.MinValue==A243TppUpdHora) ? true : false);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         n244TppUpdDataHora = false;
         AssignAttri("", false, "A244TppUpdDataHora", context.localUtil.TToC( A244TppUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         n244TppUpdDataHora = ((DateTime.MinValue==A244TppUpdDataHora) ? true : false);
         A245TppUpdUsuID = "";
         n245TppUpdUsuID = false;
         AssignAttri("", false, "A245TppUpdUsuID", A245TppUpdUsuID);
         n245TppUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A245TppUpdUsuID)) ? true : false);
         A434TppUpdUsuNome = "";
         n434TppUpdUsuNome = false;
         AssignAttri("", false, "A434TppUpdUsuNome", A434TppUpdUsuNome);
         A602TppDel = false;
         AssignAttri("", false, "A602TppDel", A602TppDel);
         A246TppAtivo = true;
         n246TppAtivo = false;
         AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
         O602TppDel = A602TppDel;
         AssignAttri("", false, "A602TppDel", A602TppDel);
         Z240TppInsDataHora = (DateTime)(DateTime.MinValue);
         Z238TppInsData = DateTime.MinValue;
         Z239TppInsHora = (DateTime)(DateTime.MinValue);
         Z241TppInsUsuID = "";
         Z433TppInsUsuNome = "";
         Z603TppDelDataHora = (DateTime)(DateTime.MinValue);
         Z604TppDelData = (DateTime)(DateTime.MinValue);
         Z605TppDelHora = (DateTime)(DateTime.MinValue);
         Z606TppDelUsuId = "";
         Z607TppDelUsuNome = "";
         Z236TppCodigo = "";
         Z237TppNome = "";
         Z242TppUpdData = DateTime.MinValue;
         Z243TppUpdHora = (DateTime)(DateTime.MinValue);
         Z244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         Z245TppUpdUsuID = "";
         Z434TppUpdUsuNome = "";
         Z246TppAtivo = false;
         Z602TppDel = false;
      }

      protected void InitAll0T29( )
      {
         A235TppID = Guid.NewGuid( );
         AssignAttri("", false, "A235TppID", A235TppID.ToString());
         InitializeNonKey0T29( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A246TppAtivo = i246TppAtivo;
         n246TppAtivo = false;
         AssignAttri("", false, "A246TppAtivo", A246TppAtivo);
      }

      protected void InitializeNonKey0T30( )
      {
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         n609Tpp1DelDataHora = false;
         AssignAttri("", false, "A609Tpp1DelDataHora", context.localUtil.TToC( A609Tpp1DelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         n610Tpp1DelData = false;
         AssignAttri("", false, "A610Tpp1DelData", context.localUtil.TToC( A610Tpp1DelData, 10, 5, 0, 3, "/", ":", " "));
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         n611Tpp1DelHora = false;
         AssignAttri("", false, "A611Tpp1DelHora", context.localUtil.TToC( A611Tpp1DelHora, 0, 5, 0, 3, "/", ":", " "));
         A612Tpp1DelUsuId = "";
         n612Tpp1DelUsuId = false;
         AssignAttri("", false, "A612Tpp1DelUsuId", A612Tpp1DelUsuId);
         A613Tpp1DelUsuNome = "";
         n613Tpp1DelUsuNome = false;
         AssignAttri("", false, "A613Tpp1DelUsuNome", A613Tpp1DelUsuNome);
         A221PrdCodigo = "";
         A222PrdNome = "";
         A232PrdTipoID = 0;
         A231PrdAtivo = false;
         A247Tpp1Preco = 0;
         A608Tpp1Del = false;
         AssignAttri("", false, "A608Tpp1Del", A608Tpp1Del);
         O608Tpp1Del = A608Tpp1Del;
         AssignAttri("", false, "A608Tpp1Del", A608Tpp1Del);
         Z609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         Z610Tpp1DelData = (DateTime)(DateTime.MinValue);
         Z611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         Z612Tpp1DelUsuId = "";
         Z613Tpp1DelUsuNome = "";
         Z247Tpp1Preco = 0;
         Z608Tpp1Del = false;
      }

      protected void InitAll0T30( )
      {
         A220PrdID = Guid.Empty;
         InitializeNonKey0T30( ) ;
      }

      protected void StandaloneModalInsert0T30( )
      {
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("calendar-system.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382814544", true, true);
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
         context.AddJavascriptSource("gxdec.js", "?"+context.GetBuildNumber( 211160), false, true);
         context.AddJavascriptSource("core/tabeladepreco.js", "?202382814547", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties30( )
      {
         chkPrdAtivo.Enabled = defchkPrdAtivo_Enabled;
         AssignProp("", false, chkPrdAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkPrdAtivo.Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdTipoID_Enabled = defedtPrdTipoID_Enabled;
         AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdCodigo_Enabled = defedtPrdCodigo_Enabled;
         AssignProp("", false, edtPrdCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdCodigo_Enabled), 5, 0), !bGXsfl_33_Refreshing);
         edtPrdID_Enabled = defedtPrdID_Enabled;
         AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), !bGXsfl_33_Refreshing);
      }

      protected void StartGridControl33( )
      {
         Gridlevel_produtoContainer.AddObjectProperty("GridName", "Gridlevel_produto");
         Gridlevel_produtoContainer.AddObjectProperty("Header", subGridlevel_produto_Header);
         Gridlevel_produtoContainer.AddObjectProperty("Class", "WorkWith");
         Gridlevel_produtoContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Backcolorstyle), 1, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("CmpContext", "");
         Gridlevel_produtoContainer.AddObjectProperty("InMasterPage", "false");
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A220PrdID.ToString()));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdID_Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A221PrdCodigo));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdCodigo_Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A222PrdNome));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdNome_Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 11, 0, ".", ""))));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtPrdTipoID_Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.BoolToStr( A231PrdAtivo)));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(chkPrdAtivo.Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridlevel_produtoColumn.AddObjectProperty("Value", GXUtil.ValueEncode( StringUtil.LTrim( StringUtil.NToC( A247Tpp1Preco, 23, 2, ".", ""))));
         Gridlevel_produtoColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtTpp1Preco_Enabled), 5, 0, ".", "")));
         Gridlevel_produtoContainer.AddColumnProperties(Gridlevel_produtoColumn);
         Gridlevel_produtoContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Selectedindex), 4, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Allowselection), 1, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Selectioncolor), 9, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Allowhovering), 1, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Hoveringcolor), 9, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Allowcollapsing), 1, 0, ".", "")));
         Gridlevel_produtoContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridlevel_produto_Collapsed), 1, 0, ".", "")));
      }

      protected void init_default_properties( )
      {
         edtTppCodigo_Internalname = "TPPCODIGO";
         edtTppNome_Internalname = "TPPNOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         edtPrdID_Internalname = "PRDID";
         edtPrdCodigo_Internalname = "PRDCODIGO";
         edtPrdNome_Internalname = "PRDNOME";
         edtPrdTipoID_Internalname = "PRDTIPOID";
         chkPrdAtivo_Internalname = "PRDATIVO";
         edtTpp1Preco_Internalname = "TPP1PRECO";
         divTableleaflevel_produto_Internalname = "TABLELEAFLEVEL_PRODUTO";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         Combo_prdid_Internalname = "COMBO_PRDID";
         edtTppID_Internalname = "TPPID";
         edtTppInsData_Internalname = "TPPINSDATA";
         edtTppInsHora_Internalname = "TPPINSHORA";
         edtTppInsDataHora_Internalname = "TPPINSDATAHORA";
         edtTppInsUsuID_Internalname = "TPPINSUSUID";
         edtTppUpdData_Internalname = "TPPUPDDATA";
         edtTppUpdHora_Internalname = "TPPUPDHORA";
         edtTppUpdDataHora_Internalname = "TPPUPDDATAHORA";
         edtTppUpdUsuID_Internalname = "TPPUPDUSUID";
         edtTppAtivo_Internalname = "TPPATIVO";
         divHtml_bottomauxiliarcontrols_Internalname = "HTML_BOTTOMAUXILIARCONTROLS";
         divLayoutmaintable_Internalname = "LAYOUTMAINTABLE";
         Form.Internalname = "FORM";
         subGridlevel_produto_Internalname = "GRIDLEVEL_PRODUTO";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridlevel_produto_Allowcollapsing = 0;
         subGridlevel_produto_Allowselection = 0;
         subGridlevel_produto_Header = "";
         Combo_prdid_Enabled = Convert.ToBoolean( -1);
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Tabela de Preço do Produto ou Serviço";
         edtTpp1Preco_Jsonclick = "";
         chkPrdAtivo.Caption = "";
         edtPrdTipoID_Jsonclick = "";
         edtPrdNome_Jsonclick = "";
         edtPrdCodigo_Jsonclick = "";
         edtPrdID_Jsonclick = "";
         subGridlevel_produto_Class = "WorkWith";
         subGridlevel_produto_Backcolorstyle = 0;
         Combo_prdid_Titlecontrolidtoreplace = "";
         Combo_prdid_Htmltemplate = "";
         edtTpp1Preco_Enabled = 1;
         chkPrdAtivo.Enabled = 0;
         edtPrdTipoID_Enabled = 0;
         edtPrdNome_Enabled = 0;
         edtPrdCodigo_Enabled = 0;
         edtPrdID_Enabled = 1;
         edtTppAtivo_Jsonclick = "";
         edtTppAtivo_Enabled = 1;
         edtTppAtivo_Visible = 1;
         edtTppUpdUsuID_Jsonclick = "";
         edtTppUpdUsuID_Enabled = 1;
         edtTppUpdUsuID_Visible = 1;
         edtTppUpdDataHora_Jsonclick = "";
         edtTppUpdDataHora_Enabled = 1;
         edtTppUpdDataHora_Visible = 1;
         edtTppUpdHora_Jsonclick = "";
         edtTppUpdHora_Enabled = 1;
         edtTppUpdHora_Visible = 1;
         edtTppUpdData_Jsonclick = "";
         edtTppUpdData_Enabled = 1;
         edtTppUpdData_Visible = 1;
         edtTppInsUsuID_Jsonclick = "";
         edtTppInsUsuID_Enabled = 1;
         edtTppInsUsuID_Visible = 1;
         edtTppInsDataHora_Jsonclick = "";
         edtTppInsDataHora_Enabled = 1;
         edtTppInsDataHora_Visible = 1;
         edtTppInsHora_Jsonclick = "";
         edtTppInsHora_Enabled = 1;
         edtTppInsHora_Visible = 1;
         edtTppInsData_Jsonclick = "";
         edtTppInsData_Enabled = 1;
         edtTppInsData_Visible = 1;
         edtTppID_Jsonclick = "";
         edtTppID_Enabled = 1;
         edtTppID_Visible = 1;
         Combo_prdid_Isgriditem = Convert.ToBoolean( -1);
         Combo_prdid_Cls = "ExtendedCombo ExtendedComboTitleAndSubtitle";
         Combo_prdid_Caption = "";
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtTppNome_Jsonclick = "";
         edtTppNome_Enabled = 1;
         edtTppCodigo_Jsonclick = "";
         edtTppCodigo_Enabled = 1;
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

      protected void XC_18_0T29( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ,
                                 Guid A235TppID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV16AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_19_0T29( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ,
                                 Guid A235TppID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "Y", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV16AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_20_0T29( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ,
                                 Guid A235TppID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV16AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_21_0T29( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ,
                                 Guid A235TppID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudittabeladepreco(context ).execute(  "N", ref  AV16AuditingObject,  A235TppID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV16AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void gxnrGridlevel_produto_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_3330( ) ;
         while ( nGXsfl_33_idx <= nRC_GXsfl_33 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0T30( ) ;
            standaloneModal0T30( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0T30( ) ;
            nGXsfl_33_idx = (int)(nGXsfl_33_idx+1);
            sGXsfl_33_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_33_idx), 4, 0), 4, "0");
            SubsflControlProps_3330( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridlevel_produtoContainer)) ;
         /* End function gxnrGridlevel_produto_newrow */
      }

      protected void init_web_controls( )
      {
         GXCCtl = "PRDATIVO_" + sGXsfl_33_idx;
         chkPrdAtivo.Name = GXCCtl;
         chkPrdAtivo.WebTags = "";
         chkPrdAtivo.Caption = "";
         AssignProp("", false, chkPrdAtivo_Internalname, "TitleCaption", chkPrdAtivo.Caption, !bGXsfl_33_Refreshing);
         chkPrdAtivo.CheckedValue = "false";
         A231PrdAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A231PrdAtivo));
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

      public void Valid_Tppcodigo( )
      {
         /* Using cursor T000T27 */
         pr_default.execute(25, new Object[] {A236TppCodigo, A235TppID});
         if ( (pr_default.getStatus(25) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "TPPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTppCodigo_Internalname;
         }
         pr_default.close(25);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A236TppCodigo)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Código", "", "", "", "", "", "", "", ""), 1, "TPPCODIGO");
            AnyError = 1;
            GX_FocusControl = edtTppCodigo_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prdid( )
      {
         /* Using cursor T000T24 */
         pr_default.execute(22, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(22) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "PRDID");
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
         }
         A221PrdCodigo = T000T24_A221PrdCodigo[0];
         A222PrdNome = T000T24_A222PrdNome[0];
         A232PrdTipoID = T000T24_A232PrdTipoID[0];
         A231PrdAtivo = T000T24_A231PrdAtivo[0];
         pr_default.close(22);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A222PrdNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição", "", "", "", "", "", "", "", ""), 1, "PRDID");
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
         }
         if ( (Guid.Empty==A220PrdID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "ID", "", "", "", "", "", "", "", ""), 1, "PRDID");
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
         }
         dynload_actions( ) ;
         A231PrdAtivo = StringUtil.StrToBool( StringUtil.BoolToStr( A231PrdAtivo));
         /*  Sending validation outputs */
         AssignAttri("", false, "A221PrdCodigo", A221PrdCodigo);
         AssignAttri("", false, "A222PrdNome", A222PrdNome);
         AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 9, 0, ".", "")));
         AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7TppID',fld:'vTPPID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7TppID',fld:'vTPPID',pic:'',hsh:true},{av:'AV17Pgmname',fld:'vPGMNAME',pic:''},{av:'A434TppUpdUsuNome',fld:'TPPUPDUSUNOME',pic:'@!'},{av:'A602TppDel',fld:'TPPDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120T2',iparms:[{av:'AV16AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV17Pgmname',fld:'vPGMNAME',pic:''},{av:'A235TppID',fld:'TPPID',pic:''},{av:'A236TppCodigo',fld:'TPPCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_TPPCODIGO","{handler:'Valid_Tppcodigo',iparms:[{av:'A236TppCodigo',fld:'TPPCODIGO',pic:''},{av:'A235TppID',fld:'TPPID',pic:''}]");
         setEventMetadata("VALID_TPPCODIGO",",oparms:[]}");
         setEventMetadata("VALID_TPPNOME","{handler:'Valid_Tppnome',iparms:[]");
         setEventMetadata("VALID_TPPNOME",",oparms:[]}");
         setEventMetadata("VALID_TPPID","{handler:'Valid_Tppid',iparms:[]");
         setEventMetadata("VALID_TPPID",",oparms:[]}");
         setEventMetadata("VALID_TPPINSDATAHORA","{handler:'Valid_Tppinsdatahora',iparms:[]");
         setEventMetadata("VALID_TPPINSDATAHORA",",oparms:[]}");
         setEventMetadata("VALID_PRDID","{handler:'Valid_Prdid',iparms:[{av:'A220PrdID',fld:'PRDID',pic:''},{av:'A222PrdNome',fld:'PRDNOME',pic:'@!'},{av:'A221PrdCodigo',fld:'PRDCODIGO',pic:''},{av:'A232PrdTipoID',fld:'PRDTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A231PrdAtivo',fld:'PRDATIVO',pic:''}]");
         setEventMetadata("VALID_PRDID",",oparms:[{av:'A221PrdCodigo',fld:'PRDCODIGO',pic:''},{av:'A222PrdNome',fld:'PRDNOME',pic:'@!'},{av:'A232PrdTipoID',fld:'PRDTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A231PrdAtivo',fld:'PRDATIVO',pic:''}]}");
         setEventMetadata("VALID_PRDNOME","{handler:'Valid_Prdnome',iparms:[]");
         setEventMetadata("VALID_PRDNOME",",oparms:[]}");
         setEventMetadata("VALID_TPP1PRECO","{handler:'Valid_Tpp1preco',iparms:[]");
         setEventMetadata("VALID_TPP1PRECO",",oparms:[]}");
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
         pr_default.close(22);
         pr_default.close(4);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7TppID = Guid.Empty;
         Z235TppID = Guid.Empty;
         Z240TppInsDataHora = (DateTime)(DateTime.MinValue);
         Z238TppInsData = DateTime.MinValue;
         Z239TppInsHora = (DateTime)(DateTime.MinValue);
         Z241TppInsUsuID = "";
         Z433TppInsUsuNome = "";
         Z603TppDelDataHora = (DateTime)(DateTime.MinValue);
         Z604TppDelData = (DateTime)(DateTime.MinValue);
         Z605TppDelHora = (DateTime)(DateTime.MinValue);
         Z606TppDelUsuId = "";
         Z607TppDelUsuNome = "";
         Z236TppCodigo = "";
         Z237TppNome = "";
         Z242TppUpdData = DateTime.MinValue;
         Z243TppUpdHora = (DateTime)(DateTime.MinValue);
         Z244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         Z245TppUpdUsuID = "";
         Z434TppUpdUsuNome = "";
         Z220PrdID = Guid.Empty;
         Z609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         Z610Tpp1DelData = (DateTime)(DateTime.MinValue);
         Z611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         Z612Tpp1DelUsuId = "";
         Z613Tpp1DelUsuNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A220PrdID = Guid.Empty;
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
         A236TppCodigo = "";
         A237TppNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         ucCombo_prdid = new GXUserControl();
         AV14DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV13PrdID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         A235TppID = Guid.Empty;
         A238TppInsData = DateTime.MinValue;
         A239TppInsHora = (DateTime)(DateTime.MinValue);
         A240TppInsDataHora = (DateTime)(DateTime.MinValue);
         A241TppInsUsuID = "";
         A242TppUpdData = DateTime.MinValue;
         A243TppUpdHora = (DateTime)(DateTime.MinValue);
         A244TppUpdDataHora = (DateTime)(DateTime.MinValue);
         A245TppUpdUsuID = "";
         Gridlevel_produtoContainer = new GXWebGrid( context);
         sMode30 = "";
         sStyleString = "";
         A433TppInsUsuNome = "";
         A603TppDelDataHora = (DateTime)(DateTime.MinValue);
         A604TppDelData = (DateTime)(DateTime.MinValue);
         A605TppDelHora = (DateTime)(DateTime.MinValue);
         A606TppDelUsuId = "";
         A607TppDelUsuNome = "";
         A434TppUpdUsuNome = "";
         AV16AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV17Pgmname = "";
         A609Tpp1DelDataHora = (DateTime)(DateTime.MinValue);
         A610Tpp1DelData = (DateTime)(DateTime.MinValue);
         A611Tpp1DelHora = (DateTime)(DateTime.MinValue);
         A612Tpp1DelUsuId = "";
         A613Tpp1DelUsuNome = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         Combo_prdid_Objectcall = "";
         Combo_prdid_Class = "";
         Combo_prdid_Icontype = "";
         Combo_prdid_Icon = "";
         Combo_prdid_Tooltip = "";
         Combo_prdid_Selectedvalue_set = "";
         Combo_prdid_Selectedvalue_get = "";
         Combo_prdid_Selectedtext_set = "";
         Combo_prdid_Selectedtext_get = "";
         Combo_prdid_Gamoauthtoken = "";
         Combo_prdid_Ddointernalname = "";
         Combo_prdid_Titlecontrolalign = "";
         Combo_prdid_Dropdownoptionstype = "";
         Combo_prdid_Datalisttype = "";
         Combo_prdid_Datalistfixedvalues = "";
         Combo_prdid_Datalistproc = "";
         Combo_prdid_Datalistprocparametersprefix = "";
         Combo_prdid_Remoteservicesparameters = "";
         Combo_prdid_Multiplevaluestype = "";
         Combo_prdid_Loadingdata = "";
         Combo_prdid_Noresultsfound = "";
         Combo_prdid_Emptyitemtext = "";
         Combo_prdid_Onlyselectedvalues = "";
         Combo_prdid_Selectalltext = "";
         Combo_prdid_Multiplevaluesseparator = "";
         Combo_prdid_Addnewoptiontext = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode29 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A221PrdCodigo = "";
         A222PrdNome = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         GXt_char2 = "";
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         GXt_objcol_SdtDVB_SDTComboData_Item3 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV15ComboSelectedValue = "";
         T000T7_A235TppID = new Guid[] {Guid.Empty} ;
         T000T7_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         T000T7_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_A241TppInsUsuID = new string[] {""} ;
         T000T7_n241TppInsUsuID = new bool[] {false} ;
         T000T7_A433TppInsUsuNome = new string[] {""} ;
         T000T7_n433TppInsUsuNome = new bool[] {false} ;
         T000T7_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_n603TppDelDataHora = new bool[] {false} ;
         T000T7_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         T000T7_n604TppDelData = new bool[] {false} ;
         T000T7_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_n605TppDelHora = new bool[] {false} ;
         T000T7_A606TppDelUsuId = new string[] {""} ;
         T000T7_n606TppDelUsuId = new bool[] {false} ;
         T000T7_A607TppDelUsuNome = new string[] {""} ;
         T000T7_n607TppDelUsuNome = new bool[] {false} ;
         T000T7_A236TppCodigo = new string[] {""} ;
         T000T7_A237TppNome = new string[] {""} ;
         T000T7_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         T000T7_n242TppUpdData = new bool[] {false} ;
         T000T7_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_n243TppUpdHora = new bool[] {false} ;
         T000T7_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T7_n244TppUpdDataHora = new bool[] {false} ;
         T000T7_A245TppUpdUsuID = new string[] {""} ;
         T000T7_n245TppUpdUsuID = new bool[] {false} ;
         T000T7_A434TppUpdUsuNome = new string[] {""} ;
         T000T7_n434TppUpdUsuNome = new bool[] {false} ;
         T000T7_A246TppAtivo = new bool[] {false} ;
         T000T7_n246TppAtivo = new bool[] {false} ;
         T000T7_A602TppDel = new bool[] {false} ;
         T000T8_A236TppCodigo = new string[] {""} ;
         T000T9_A235TppID = new Guid[] {Guid.Empty} ;
         T000T6_A235TppID = new Guid[] {Guid.Empty} ;
         T000T6_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         T000T6_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_A241TppInsUsuID = new string[] {""} ;
         T000T6_n241TppInsUsuID = new bool[] {false} ;
         T000T6_A433TppInsUsuNome = new string[] {""} ;
         T000T6_n433TppInsUsuNome = new bool[] {false} ;
         T000T6_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_n603TppDelDataHora = new bool[] {false} ;
         T000T6_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         T000T6_n604TppDelData = new bool[] {false} ;
         T000T6_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_n605TppDelHora = new bool[] {false} ;
         T000T6_A606TppDelUsuId = new string[] {""} ;
         T000T6_n606TppDelUsuId = new bool[] {false} ;
         T000T6_A607TppDelUsuNome = new string[] {""} ;
         T000T6_n607TppDelUsuNome = new bool[] {false} ;
         T000T6_A236TppCodigo = new string[] {""} ;
         T000T6_A237TppNome = new string[] {""} ;
         T000T6_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         T000T6_n242TppUpdData = new bool[] {false} ;
         T000T6_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_n243TppUpdHora = new bool[] {false} ;
         T000T6_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T6_n244TppUpdDataHora = new bool[] {false} ;
         T000T6_A245TppUpdUsuID = new string[] {""} ;
         T000T6_n245TppUpdUsuID = new bool[] {false} ;
         T000T6_A434TppUpdUsuNome = new string[] {""} ;
         T000T6_n434TppUpdUsuNome = new bool[] {false} ;
         T000T6_A246TppAtivo = new bool[] {false} ;
         T000T6_n246TppAtivo = new bool[] {false} ;
         T000T6_A602TppDel = new bool[] {false} ;
         T000T10_A235TppID = new Guid[] {Guid.Empty} ;
         T000T11_A235TppID = new Guid[] {Guid.Empty} ;
         T000T5_A235TppID = new Guid[] {Guid.Empty} ;
         T000T5_A240TppInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_A238TppInsData = new DateTime[] {DateTime.MinValue} ;
         T000T5_A239TppInsHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_A241TppInsUsuID = new string[] {""} ;
         T000T5_n241TppInsUsuID = new bool[] {false} ;
         T000T5_A433TppInsUsuNome = new string[] {""} ;
         T000T5_n433TppInsUsuNome = new bool[] {false} ;
         T000T5_A603TppDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_n603TppDelDataHora = new bool[] {false} ;
         T000T5_A604TppDelData = new DateTime[] {DateTime.MinValue} ;
         T000T5_n604TppDelData = new bool[] {false} ;
         T000T5_A605TppDelHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_n605TppDelHora = new bool[] {false} ;
         T000T5_A606TppDelUsuId = new string[] {""} ;
         T000T5_n606TppDelUsuId = new bool[] {false} ;
         T000T5_A607TppDelUsuNome = new string[] {""} ;
         T000T5_n607TppDelUsuNome = new bool[] {false} ;
         T000T5_A236TppCodigo = new string[] {""} ;
         T000T5_A237TppNome = new string[] {""} ;
         T000T5_A242TppUpdData = new DateTime[] {DateTime.MinValue} ;
         T000T5_n242TppUpdData = new bool[] {false} ;
         T000T5_A243TppUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_n243TppUpdHora = new bool[] {false} ;
         T000T5_A244TppUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T5_n244TppUpdDataHora = new bool[] {false} ;
         T000T5_A245TppUpdUsuID = new string[] {""} ;
         T000T5_n245TppUpdUsuID = new bool[] {false} ;
         T000T5_A434TppUpdUsuNome = new string[] {""} ;
         T000T5_n434TppUpdUsuNome = new bool[] {false} ;
         T000T5_A246TppAtivo = new bool[] {false} ;
         T000T5_n246TppAtivo = new bool[] {false} ;
         T000T5_A602TppDel = new bool[] {false} ;
         T000T15_A345NegID = new Guid[] {Guid.Empty} ;
         T000T15_A435NgpItem = new int[1] ;
         T000T16_A345NegID = new Guid[] {Guid.Empty} ;
         T000T16_A435NgpItem = new int[1] ;
         T000T17_A235TppID = new Guid[] {Guid.Empty} ;
         Z221PrdCodigo = "";
         Z222PrdNome = "";
         T000T18_A235TppID = new Guid[] {Guid.Empty} ;
         T000T18_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T18_n609Tpp1DelDataHora = new bool[] {false} ;
         T000T18_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         T000T18_n610Tpp1DelData = new bool[] {false} ;
         T000T18_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         T000T18_n611Tpp1DelHora = new bool[] {false} ;
         T000T18_A612Tpp1DelUsuId = new string[] {""} ;
         T000T18_n612Tpp1DelUsuId = new bool[] {false} ;
         T000T18_A613Tpp1DelUsuNome = new string[] {""} ;
         T000T18_n613Tpp1DelUsuNome = new bool[] {false} ;
         T000T18_A221PrdCodigo = new string[] {""} ;
         T000T18_A222PrdNome = new string[] {""} ;
         T000T18_A232PrdTipoID = new int[1] ;
         T000T18_A231PrdAtivo = new bool[] {false} ;
         T000T18_A247Tpp1Preco = new decimal[1] ;
         T000T18_A608Tpp1Del = new bool[] {false} ;
         T000T18_A220PrdID = new Guid[] {Guid.Empty} ;
         T000T4_A221PrdCodigo = new string[] {""} ;
         T000T4_A222PrdNome = new string[] {""} ;
         T000T4_A232PrdTipoID = new int[1] ;
         T000T4_A231PrdAtivo = new bool[] {false} ;
         T000T19_A221PrdCodigo = new string[] {""} ;
         T000T19_A222PrdNome = new string[] {""} ;
         T000T19_A232PrdTipoID = new int[1] ;
         T000T19_A231PrdAtivo = new bool[] {false} ;
         T000T20_A235TppID = new Guid[] {Guid.Empty} ;
         T000T20_A220PrdID = new Guid[] {Guid.Empty} ;
         T000T3_A235TppID = new Guid[] {Guid.Empty} ;
         T000T3_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T3_n609Tpp1DelDataHora = new bool[] {false} ;
         T000T3_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         T000T3_n610Tpp1DelData = new bool[] {false} ;
         T000T3_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         T000T3_n611Tpp1DelHora = new bool[] {false} ;
         T000T3_A612Tpp1DelUsuId = new string[] {""} ;
         T000T3_n612Tpp1DelUsuId = new bool[] {false} ;
         T000T3_A613Tpp1DelUsuNome = new string[] {""} ;
         T000T3_n613Tpp1DelUsuNome = new bool[] {false} ;
         T000T3_A247Tpp1Preco = new decimal[1] ;
         T000T3_A608Tpp1Del = new bool[] {false} ;
         T000T3_A220PrdID = new Guid[] {Guid.Empty} ;
         T000T3_A221PrdCodigo = new string[] {""} ;
         T000T3_A222PrdNome = new string[] {""} ;
         T000T3_A232PrdTipoID = new int[1] ;
         T000T2_A235TppID = new Guid[] {Guid.Empty} ;
         T000T2_A609Tpp1DelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000T2_n609Tpp1DelDataHora = new bool[] {false} ;
         T000T2_A610Tpp1DelData = new DateTime[] {DateTime.MinValue} ;
         T000T2_n610Tpp1DelData = new bool[] {false} ;
         T000T2_A611Tpp1DelHora = new DateTime[] {DateTime.MinValue} ;
         T000T2_n611Tpp1DelHora = new bool[] {false} ;
         T000T2_A612Tpp1DelUsuId = new string[] {""} ;
         T000T2_n612Tpp1DelUsuId = new bool[] {false} ;
         T000T2_A613Tpp1DelUsuNome = new string[] {""} ;
         T000T2_n613Tpp1DelUsuNome = new bool[] {false} ;
         T000T2_A247Tpp1Preco = new decimal[1] ;
         T000T2_A608Tpp1Del = new bool[] {false} ;
         T000T2_A220PrdID = new Guid[] {Guid.Empty} ;
         T000T2_A221PrdCodigo = new string[] {""} ;
         T000T2_A222PrdNome = new string[] {""} ;
         T000T2_A232PrdTipoID = new int[1] ;
         T000T24_A221PrdCodigo = new string[] {""} ;
         T000T24_A222PrdNome = new string[] {""} ;
         T000T24_A232PrdTipoID = new int[1] ;
         T000T24_A231PrdAtivo = new bool[] {false} ;
         T000T25_A345NegID = new Guid[] {Guid.Empty} ;
         T000T25_A435NgpItem = new int[1] ;
         T000T26_A235TppID = new Guid[] {Guid.Empty} ;
         T000T26_A220PrdID = new Guid[] {Guid.Empty} ;
         Gridlevel_produtoRow = new GXWebRow();
         subGridlevel_produto_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         Gridlevel_produtoColumn = new GXWebColumn();
         T000T27_A236TppCodigo = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladepreco__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.tabeladepreco__default(),
            new Object[][] {
                new Object[] {
               T000T2_A235TppID, T000T2_A609Tpp1DelDataHora, T000T2_n609Tpp1DelDataHora, T000T2_A610Tpp1DelData, T000T2_n610Tpp1DelData, T000T2_A611Tpp1DelHora, T000T2_n611Tpp1DelHora, T000T2_A612Tpp1DelUsuId, T000T2_n612Tpp1DelUsuId, T000T2_A613Tpp1DelUsuNome,
               T000T2_n613Tpp1DelUsuNome, T000T2_A247Tpp1Preco, T000T2_A608Tpp1Del, T000T2_A220PrdID, T000T2_A221PrdCodigo, T000T2_A222PrdNome, T000T2_A232PrdTipoID
               }
               , new Object[] {
               T000T3_A235TppID, T000T3_A609Tpp1DelDataHora, T000T3_n609Tpp1DelDataHora, T000T3_A610Tpp1DelData, T000T3_n610Tpp1DelData, T000T3_A611Tpp1DelHora, T000T3_n611Tpp1DelHora, T000T3_A612Tpp1DelUsuId, T000T3_n612Tpp1DelUsuId, T000T3_A613Tpp1DelUsuNome,
               T000T3_n613Tpp1DelUsuNome, T000T3_A247Tpp1Preco, T000T3_A608Tpp1Del, T000T3_A220PrdID, T000T3_A221PrdCodigo, T000T3_A222PrdNome, T000T3_A232PrdTipoID
               }
               , new Object[] {
               T000T4_A221PrdCodigo, T000T4_A222PrdNome, T000T4_A232PrdTipoID, T000T4_A231PrdAtivo
               }
               , new Object[] {
               T000T5_A235TppID, T000T5_A240TppInsDataHora, T000T5_A238TppInsData, T000T5_A239TppInsHora, T000T5_A241TppInsUsuID, T000T5_n241TppInsUsuID, T000T5_A433TppInsUsuNome, T000T5_n433TppInsUsuNome, T000T5_A603TppDelDataHora, T000T5_n603TppDelDataHora,
               T000T5_A604TppDelData, T000T5_n604TppDelData, T000T5_A605TppDelHora, T000T5_n605TppDelHora, T000T5_A606TppDelUsuId, T000T5_n606TppDelUsuId, T000T5_A607TppDelUsuNome, T000T5_n607TppDelUsuNome, T000T5_A236TppCodigo, T000T5_A237TppNome,
               T000T5_A242TppUpdData, T000T5_n242TppUpdData, T000T5_A243TppUpdHora, T000T5_n243TppUpdHora, T000T5_A244TppUpdDataHora, T000T5_n244TppUpdDataHora, T000T5_A245TppUpdUsuID, T000T5_n245TppUpdUsuID, T000T5_A434TppUpdUsuNome, T000T5_n434TppUpdUsuNome,
               T000T5_A246TppAtivo, T000T5_n246TppAtivo, T000T5_A602TppDel
               }
               , new Object[] {
               T000T6_A235TppID, T000T6_A240TppInsDataHora, T000T6_A238TppInsData, T000T6_A239TppInsHora, T000T6_A241TppInsUsuID, T000T6_n241TppInsUsuID, T000T6_A433TppInsUsuNome, T000T6_n433TppInsUsuNome, T000T6_A603TppDelDataHora, T000T6_n603TppDelDataHora,
               T000T6_A604TppDelData, T000T6_n604TppDelData, T000T6_A605TppDelHora, T000T6_n605TppDelHora, T000T6_A606TppDelUsuId, T000T6_n606TppDelUsuId, T000T6_A607TppDelUsuNome, T000T6_n607TppDelUsuNome, T000T6_A236TppCodigo, T000T6_A237TppNome,
               T000T6_A242TppUpdData, T000T6_n242TppUpdData, T000T6_A243TppUpdHora, T000T6_n243TppUpdHora, T000T6_A244TppUpdDataHora, T000T6_n244TppUpdDataHora, T000T6_A245TppUpdUsuID, T000T6_n245TppUpdUsuID, T000T6_A434TppUpdUsuNome, T000T6_n434TppUpdUsuNome,
               T000T6_A246TppAtivo, T000T6_n246TppAtivo, T000T6_A602TppDel
               }
               , new Object[] {
               T000T7_A235TppID, T000T7_A240TppInsDataHora, T000T7_A238TppInsData, T000T7_A239TppInsHora, T000T7_A241TppInsUsuID, T000T7_n241TppInsUsuID, T000T7_A433TppInsUsuNome, T000T7_n433TppInsUsuNome, T000T7_A603TppDelDataHora, T000T7_n603TppDelDataHora,
               T000T7_A604TppDelData, T000T7_n604TppDelData, T000T7_A605TppDelHora, T000T7_n605TppDelHora, T000T7_A606TppDelUsuId, T000T7_n606TppDelUsuId, T000T7_A607TppDelUsuNome, T000T7_n607TppDelUsuNome, T000T7_A236TppCodigo, T000T7_A237TppNome,
               T000T7_A242TppUpdData, T000T7_n242TppUpdData, T000T7_A243TppUpdHora, T000T7_n243TppUpdHora, T000T7_A244TppUpdDataHora, T000T7_n244TppUpdDataHora, T000T7_A245TppUpdUsuID, T000T7_n245TppUpdUsuID, T000T7_A434TppUpdUsuNome, T000T7_n434TppUpdUsuNome,
               T000T7_A246TppAtivo, T000T7_n246TppAtivo, T000T7_A602TppDel
               }
               , new Object[] {
               T000T8_A236TppCodigo
               }
               , new Object[] {
               T000T9_A235TppID
               }
               , new Object[] {
               T000T10_A235TppID
               }
               , new Object[] {
               T000T11_A235TppID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T15_A345NegID, T000T15_A435NgpItem
               }
               , new Object[] {
               T000T16_A345NegID, T000T16_A435NgpItem
               }
               , new Object[] {
               T000T17_A235TppID
               }
               , new Object[] {
               T000T18_A235TppID, T000T18_A609Tpp1DelDataHora, T000T18_n609Tpp1DelDataHora, T000T18_A610Tpp1DelData, T000T18_n610Tpp1DelData, T000T18_A611Tpp1DelHora, T000T18_n611Tpp1DelHora, T000T18_A612Tpp1DelUsuId, T000T18_n612Tpp1DelUsuId, T000T18_A613Tpp1DelUsuNome,
               T000T18_n613Tpp1DelUsuNome, T000T18_A221PrdCodigo, T000T18_A222PrdNome, T000T18_A232PrdTipoID, T000T18_A231PrdAtivo, T000T18_A247Tpp1Preco, T000T18_A608Tpp1Del, T000T18_A220PrdID
               }
               , new Object[] {
               T000T19_A221PrdCodigo, T000T19_A222PrdNome, T000T19_A232PrdTipoID, T000T19_A231PrdAtivo
               }
               , new Object[] {
               T000T20_A235TppID, T000T20_A220PrdID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000T24_A221PrdCodigo, T000T24_A222PrdNome, T000T24_A232PrdTipoID, T000T24_A231PrdAtivo
               }
               , new Object[] {
               T000T25_A345NegID, T000T25_A435NgpItem
               }
               , new Object[] {
               T000T26_A235TppID, T000T26_A220PrdID
               }
               , new Object[] {
               T000T27_A236TppCodigo
               }
            }
         );
         Z246TppAtivo = true;
         n246TppAtivo = false;
         A246TppAtivo = true;
         n246TppAtivo = false;
         i246TppAtivo = true;
         n246TppAtivo = false;
         Z235TppID = Guid.NewGuid( );
         A235TppID = Guid.NewGuid( );
         AV17Pgmname = "core.TabelaDePreco";
      }

      private short nRcdDeleted_30 ;
      private short nRcdExists_30 ;
      private short nIsMod_30 ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short nBlankRcdCount30 ;
      private short RcdFound30 ;
      private short nBlankRcdUsr30 ;
      private short Gx_BScreen ;
      private short RcdFound29 ;
      private short GX_JID ;
      private short nIsDirty_29 ;
      private short nIsDirty_30 ;
      private short subGridlevel_produto_Backcolorstyle ;
      private short subGridlevel_produto_Backstyle ;
      private short gxajaxcallmode ;
      private short subGridlevel_produto_Allowselection ;
      private short subGridlevel_produto_Allowhovering ;
      private short subGridlevel_produto_Allowcollapsing ;
      private short subGridlevel_produto_Collapsed ;
      private int nRC_GXsfl_33 ;
      private int nGXsfl_33_idx=1 ;
      private int trnEnded ;
      private int edtTppCodigo_Enabled ;
      private int edtTppNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtTppID_Visible ;
      private int edtTppID_Enabled ;
      private int edtTppInsData_Visible ;
      private int edtTppInsData_Enabled ;
      private int edtTppInsHora_Visible ;
      private int edtTppInsHora_Enabled ;
      private int edtTppInsDataHora_Visible ;
      private int edtTppInsDataHora_Enabled ;
      private int edtTppInsUsuID_Visible ;
      private int edtTppInsUsuID_Enabled ;
      private int edtTppUpdData_Visible ;
      private int edtTppUpdData_Enabled ;
      private int edtTppUpdHora_Visible ;
      private int edtTppUpdHora_Enabled ;
      private int edtTppUpdDataHora_Visible ;
      private int edtTppUpdDataHora_Enabled ;
      private int edtTppUpdUsuID_Visible ;
      private int edtTppUpdUsuID_Enabled ;
      private int edtTppAtivo_Visible ;
      private int edtTppAtivo_Enabled ;
      private int edtPrdID_Enabled ;
      private int edtPrdCodigo_Enabled ;
      private int edtPrdNome_Enabled ;
      private int edtPrdTipoID_Enabled ;
      private int edtTpp1Preco_Enabled ;
      private int fRowAdded ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int Combo_prdid_Datalistupdateminimumcharacters ;
      private int Combo_prdid_Gxcontroltype ;
      private int A232PrdTipoID ;
      private int Z232PrdTipoID ;
      private int subGridlevel_produto_Backcolor ;
      private int subGridlevel_produto_Allbackcolor ;
      private int defchkPrdAtivo_Enabled ;
      private int defedtPrdTipoID_Enabled ;
      private int defedtPrdCodigo_Enabled ;
      private int defedtPrdID_Enabled ;
      private int idxLst ;
      private int subGridlevel_produto_Selectedindex ;
      private int subGridlevel_produto_Selectioncolor ;
      private int subGridlevel_produto_Hoveringcolor ;
      private long GRIDLEVEL_PRODUTO_nFirstRecordOnPage ;
      private decimal Z247Tpp1Preco ;
      private decimal A247Tpp1Preco ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z241TppInsUsuID ;
      private string Z606TppDelUsuId ;
      private string Z245TppUpdUsuID ;
      private string Z612Tpp1DelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtTppCodigo_Internalname ;
      private string sGXsfl_33_idx="0001" ;
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
      private string edtTppCodigo_Jsonclick ;
      private string edtTppNome_Internalname ;
      private string edtTppNome_Jsonclick ;
      private string divTableleaflevel_produto_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string Combo_prdid_Caption ;
      private string Combo_prdid_Cls ;
      private string Combo_prdid_Internalname ;
      private string edtTppID_Internalname ;
      private string edtTppID_Jsonclick ;
      private string edtTppInsData_Internalname ;
      private string edtTppInsData_Jsonclick ;
      private string edtTppInsHora_Internalname ;
      private string edtTppInsHora_Jsonclick ;
      private string edtTppInsDataHora_Internalname ;
      private string edtTppInsDataHora_Jsonclick ;
      private string edtTppInsUsuID_Internalname ;
      private string A241TppInsUsuID ;
      private string edtTppInsUsuID_Jsonclick ;
      private string edtTppUpdData_Internalname ;
      private string edtTppUpdData_Jsonclick ;
      private string edtTppUpdHora_Internalname ;
      private string edtTppUpdHora_Jsonclick ;
      private string edtTppUpdDataHora_Internalname ;
      private string edtTppUpdDataHora_Jsonclick ;
      private string edtTppUpdUsuID_Internalname ;
      private string A245TppUpdUsuID ;
      private string edtTppUpdUsuID_Jsonclick ;
      private string edtTppAtivo_Internalname ;
      private string edtTppAtivo_Jsonclick ;
      private string sMode30 ;
      private string edtPrdID_Internalname ;
      private string edtPrdCodigo_Internalname ;
      private string edtPrdNome_Internalname ;
      private string edtPrdTipoID_Internalname ;
      private string chkPrdAtivo_Internalname ;
      private string edtTpp1Preco_Internalname ;
      private string sStyleString ;
      private string subGridlevel_produto_Internalname ;
      private string A606TppDelUsuId ;
      private string AV17Pgmname ;
      private string A612Tpp1DelUsuId ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string Combo_prdid_Objectcall ;
      private string Combo_prdid_Class ;
      private string Combo_prdid_Icontype ;
      private string Combo_prdid_Icon ;
      private string Combo_prdid_Tooltip ;
      private string Combo_prdid_Selectedvalue_set ;
      private string Combo_prdid_Selectedvalue_get ;
      private string Combo_prdid_Selectedtext_set ;
      private string Combo_prdid_Selectedtext_get ;
      private string Combo_prdid_Gamoauthtoken ;
      private string Combo_prdid_Ddointernalname ;
      private string Combo_prdid_Titlecontrolalign ;
      private string Combo_prdid_Dropdownoptionstype ;
      private string Combo_prdid_Titlecontrolidtoreplace ;
      private string Combo_prdid_Datalisttype ;
      private string Combo_prdid_Datalistfixedvalues ;
      private string Combo_prdid_Datalistproc ;
      private string Combo_prdid_Datalistprocparametersprefix ;
      private string Combo_prdid_Remoteservicesparameters ;
      private string Combo_prdid_Htmltemplate ;
      private string Combo_prdid_Multiplevaluestype ;
      private string Combo_prdid_Loadingdata ;
      private string Combo_prdid_Noresultsfound ;
      private string Combo_prdid_Emptyitemtext ;
      private string Combo_prdid_Onlyselectedvalues ;
      private string Combo_prdid_Selectalltext ;
      private string Combo_prdid_Multiplevaluesseparator ;
      private string Combo_prdid_Addnewoptiontext ;
      private string hsh ;
      private string sMode29 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string GXt_char2 ;
      private string sGXsfl_33_fel_idx="0001" ;
      private string subGridlevel_produto_Class ;
      private string subGridlevel_produto_Linesclass ;
      private string ROClassString ;
      private string edtPrdID_Jsonclick ;
      private string edtPrdCodigo_Jsonclick ;
      private string edtPrdNome_Jsonclick ;
      private string edtPrdTipoID_Jsonclick ;
      private string edtTpp1Preco_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private string subGridlevel_produto_Header ;
      private DateTime Z240TppInsDataHora ;
      private DateTime Z239TppInsHora ;
      private DateTime Z603TppDelDataHora ;
      private DateTime Z604TppDelData ;
      private DateTime Z605TppDelHora ;
      private DateTime Z243TppUpdHora ;
      private DateTime Z244TppUpdDataHora ;
      private DateTime Z609Tpp1DelDataHora ;
      private DateTime Z610Tpp1DelData ;
      private DateTime Z611Tpp1DelHora ;
      private DateTime A239TppInsHora ;
      private DateTime A240TppInsDataHora ;
      private DateTime A243TppUpdHora ;
      private DateTime A244TppUpdDataHora ;
      private DateTime A603TppDelDataHora ;
      private DateTime A604TppDelData ;
      private DateTime A605TppDelHora ;
      private DateTime A609Tpp1DelDataHora ;
      private DateTime A610Tpp1DelData ;
      private DateTime A611Tpp1DelHora ;
      private DateTime Z238TppInsData ;
      private DateTime Z242TppUpdData ;
      private DateTime A238TppInsData ;
      private DateTime A242TppUpdData ;
      private bool Z246TppAtivo ;
      private bool Z602TppDel ;
      private bool O602TppDel ;
      private bool Z608Tpp1Del ;
      private bool O608Tpp1Del ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_prdid_Isgriditem ;
      private bool A246TppAtivo ;
      private bool B602TppDel ;
      private bool A602TppDel ;
      private bool bGXsfl_33_Refreshing=false ;
      private bool n241TppInsUsuID ;
      private bool n433TppInsUsuNome ;
      private bool n603TppDelDataHora ;
      private bool n604TppDelData ;
      private bool n605TppDelHora ;
      private bool n606TppDelUsuId ;
      private bool n607TppDelUsuNome ;
      private bool n242TppUpdData ;
      private bool n243TppUpdHora ;
      private bool n244TppUpdDataHora ;
      private bool n245TppUpdUsuID ;
      private bool n434TppUpdUsuNome ;
      private bool n246TppAtivo ;
      private bool A608Tpp1Del ;
      private bool n609Tpp1DelDataHora ;
      private bool n610Tpp1DelData ;
      private bool n611Tpp1DelHora ;
      private bool n612Tpp1DelUsuId ;
      private bool n613Tpp1DelUsuNome ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool Combo_prdid_Enabled ;
      private bool Combo_prdid_Visible ;
      private bool Combo_prdid_Allowmultipleselection ;
      private bool Combo_prdid_Hasdescription ;
      private bool Combo_prdid_Includeonlyselectedoption ;
      private bool Combo_prdid_Includeselectalloption ;
      private bool Combo_prdid_Emptyitem ;
      private bool Combo_prdid_Includeaddnewoption ;
      private bool A231PrdAtivo ;
      private bool T608Tpp1Del ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool Z231PrdAtivo ;
      private bool i246TppAtivo ;
      private string Z433TppInsUsuNome ;
      private string Z607TppDelUsuNome ;
      private string Z236TppCodigo ;
      private string Z237TppNome ;
      private string Z434TppUpdUsuNome ;
      private string Z613Tpp1DelUsuNome ;
      private string A236TppCodigo ;
      private string A237TppNome ;
      private string A433TppInsUsuNome ;
      private string A607TppDelUsuNome ;
      private string A434TppUpdUsuNome ;
      private string A613Tpp1DelUsuNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string AV15ComboSelectedValue ;
      private string Z221PrdCodigo ;
      private string Z222PrdNome ;
      private Guid wcpOAV7TppID ;
      private Guid Z235TppID ;
      private Guid Z220PrdID ;
      private Guid A220PrdID ;
      private Guid AV7TppID ;
      private Guid A235TppID ;
      private GXProperties forbiddenHiddens ;
      private GXWebGrid Gridlevel_produtoContainer ;
      private GXWebRow Gridlevel_produtoRow ;
      private GXWebColumn Gridlevel_produtoColumn ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_prdid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkPrdAtivo ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000T7_A235TppID ;
      private DateTime[] T000T7_A240TppInsDataHora ;
      private DateTime[] T000T7_A238TppInsData ;
      private DateTime[] T000T7_A239TppInsHora ;
      private string[] T000T7_A241TppInsUsuID ;
      private bool[] T000T7_n241TppInsUsuID ;
      private string[] T000T7_A433TppInsUsuNome ;
      private bool[] T000T7_n433TppInsUsuNome ;
      private DateTime[] T000T7_A603TppDelDataHora ;
      private bool[] T000T7_n603TppDelDataHora ;
      private DateTime[] T000T7_A604TppDelData ;
      private bool[] T000T7_n604TppDelData ;
      private DateTime[] T000T7_A605TppDelHora ;
      private bool[] T000T7_n605TppDelHora ;
      private string[] T000T7_A606TppDelUsuId ;
      private bool[] T000T7_n606TppDelUsuId ;
      private string[] T000T7_A607TppDelUsuNome ;
      private bool[] T000T7_n607TppDelUsuNome ;
      private string[] T000T7_A236TppCodigo ;
      private string[] T000T7_A237TppNome ;
      private DateTime[] T000T7_A242TppUpdData ;
      private bool[] T000T7_n242TppUpdData ;
      private DateTime[] T000T7_A243TppUpdHora ;
      private bool[] T000T7_n243TppUpdHora ;
      private DateTime[] T000T7_A244TppUpdDataHora ;
      private bool[] T000T7_n244TppUpdDataHora ;
      private string[] T000T7_A245TppUpdUsuID ;
      private bool[] T000T7_n245TppUpdUsuID ;
      private string[] T000T7_A434TppUpdUsuNome ;
      private bool[] T000T7_n434TppUpdUsuNome ;
      private bool[] T000T7_A246TppAtivo ;
      private bool[] T000T7_n246TppAtivo ;
      private bool[] T000T7_A602TppDel ;
      private string[] T000T8_A236TppCodigo ;
      private Guid[] T000T9_A235TppID ;
      private Guid[] T000T6_A235TppID ;
      private DateTime[] T000T6_A240TppInsDataHora ;
      private DateTime[] T000T6_A238TppInsData ;
      private DateTime[] T000T6_A239TppInsHora ;
      private string[] T000T6_A241TppInsUsuID ;
      private bool[] T000T6_n241TppInsUsuID ;
      private string[] T000T6_A433TppInsUsuNome ;
      private bool[] T000T6_n433TppInsUsuNome ;
      private DateTime[] T000T6_A603TppDelDataHora ;
      private bool[] T000T6_n603TppDelDataHora ;
      private DateTime[] T000T6_A604TppDelData ;
      private bool[] T000T6_n604TppDelData ;
      private DateTime[] T000T6_A605TppDelHora ;
      private bool[] T000T6_n605TppDelHora ;
      private string[] T000T6_A606TppDelUsuId ;
      private bool[] T000T6_n606TppDelUsuId ;
      private string[] T000T6_A607TppDelUsuNome ;
      private bool[] T000T6_n607TppDelUsuNome ;
      private string[] T000T6_A236TppCodigo ;
      private string[] T000T6_A237TppNome ;
      private DateTime[] T000T6_A242TppUpdData ;
      private bool[] T000T6_n242TppUpdData ;
      private DateTime[] T000T6_A243TppUpdHora ;
      private bool[] T000T6_n243TppUpdHora ;
      private DateTime[] T000T6_A244TppUpdDataHora ;
      private bool[] T000T6_n244TppUpdDataHora ;
      private string[] T000T6_A245TppUpdUsuID ;
      private bool[] T000T6_n245TppUpdUsuID ;
      private string[] T000T6_A434TppUpdUsuNome ;
      private bool[] T000T6_n434TppUpdUsuNome ;
      private bool[] T000T6_A246TppAtivo ;
      private bool[] T000T6_n246TppAtivo ;
      private bool[] T000T6_A602TppDel ;
      private Guid[] T000T10_A235TppID ;
      private Guid[] T000T11_A235TppID ;
      private Guid[] T000T5_A235TppID ;
      private DateTime[] T000T5_A240TppInsDataHora ;
      private DateTime[] T000T5_A238TppInsData ;
      private DateTime[] T000T5_A239TppInsHora ;
      private string[] T000T5_A241TppInsUsuID ;
      private bool[] T000T5_n241TppInsUsuID ;
      private string[] T000T5_A433TppInsUsuNome ;
      private bool[] T000T5_n433TppInsUsuNome ;
      private DateTime[] T000T5_A603TppDelDataHora ;
      private bool[] T000T5_n603TppDelDataHora ;
      private DateTime[] T000T5_A604TppDelData ;
      private bool[] T000T5_n604TppDelData ;
      private DateTime[] T000T5_A605TppDelHora ;
      private bool[] T000T5_n605TppDelHora ;
      private string[] T000T5_A606TppDelUsuId ;
      private bool[] T000T5_n606TppDelUsuId ;
      private string[] T000T5_A607TppDelUsuNome ;
      private bool[] T000T5_n607TppDelUsuNome ;
      private string[] T000T5_A236TppCodigo ;
      private string[] T000T5_A237TppNome ;
      private DateTime[] T000T5_A242TppUpdData ;
      private bool[] T000T5_n242TppUpdData ;
      private DateTime[] T000T5_A243TppUpdHora ;
      private bool[] T000T5_n243TppUpdHora ;
      private DateTime[] T000T5_A244TppUpdDataHora ;
      private bool[] T000T5_n244TppUpdDataHora ;
      private string[] T000T5_A245TppUpdUsuID ;
      private bool[] T000T5_n245TppUpdUsuID ;
      private string[] T000T5_A434TppUpdUsuNome ;
      private bool[] T000T5_n434TppUpdUsuNome ;
      private bool[] T000T5_A246TppAtivo ;
      private bool[] T000T5_n246TppAtivo ;
      private bool[] T000T5_A602TppDel ;
      private Guid[] T000T15_A345NegID ;
      private int[] T000T15_A435NgpItem ;
      private Guid[] T000T16_A345NegID ;
      private int[] T000T16_A435NgpItem ;
      private Guid[] T000T17_A235TppID ;
      private Guid[] T000T18_A235TppID ;
      private DateTime[] T000T18_A609Tpp1DelDataHora ;
      private bool[] T000T18_n609Tpp1DelDataHora ;
      private DateTime[] T000T18_A610Tpp1DelData ;
      private bool[] T000T18_n610Tpp1DelData ;
      private DateTime[] T000T18_A611Tpp1DelHora ;
      private bool[] T000T18_n611Tpp1DelHora ;
      private string[] T000T18_A612Tpp1DelUsuId ;
      private bool[] T000T18_n612Tpp1DelUsuId ;
      private string[] T000T18_A613Tpp1DelUsuNome ;
      private bool[] T000T18_n613Tpp1DelUsuNome ;
      private string[] T000T18_A221PrdCodigo ;
      private string[] T000T18_A222PrdNome ;
      private int[] T000T18_A232PrdTipoID ;
      private bool[] T000T18_A231PrdAtivo ;
      private decimal[] T000T18_A247Tpp1Preco ;
      private bool[] T000T18_A608Tpp1Del ;
      private Guid[] T000T18_A220PrdID ;
      private string[] T000T4_A221PrdCodigo ;
      private string[] T000T4_A222PrdNome ;
      private int[] T000T4_A232PrdTipoID ;
      private bool[] T000T4_A231PrdAtivo ;
      private string[] T000T19_A221PrdCodigo ;
      private string[] T000T19_A222PrdNome ;
      private int[] T000T19_A232PrdTipoID ;
      private bool[] T000T19_A231PrdAtivo ;
      private Guid[] T000T20_A235TppID ;
      private Guid[] T000T20_A220PrdID ;
      private Guid[] T000T3_A235TppID ;
      private DateTime[] T000T3_A609Tpp1DelDataHora ;
      private bool[] T000T3_n609Tpp1DelDataHora ;
      private DateTime[] T000T3_A610Tpp1DelData ;
      private bool[] T000T3_n610Tpp1DelData ;
      private DateTime[] T000T3_A611Tpp1DelHora ;
      private bool[] T000T3_n611Tpp1DelHora ;
      private string[] T000T3_A612Tpp1DelUsuId ;
      private bool[] T000T3_n612Tpp1DelUsuId ;
      private string[] T000T3_A613Tpp1DelUsuNome ;
      private bool[] T000T3_n613Tpp1DelUsuNome ;
      private decimal[] T000T3_A247Tpp1Preco ;
      private bool[] T000T3_A608Tpp1Del ;
      private Guid[] T000T3_A220PrdID ;
      private string[] T000T3_A221PrdCodigo ;
      private string[] T000T3_A222PrdNome ;
      private int[] T000T3_A232PrdTipoID ;
      private Guid[] T000T2_A235TppID ;
      private DateTime[] T000T2_A609Tpp1DelDataHora ;
      private bool[] T000T2_n609Tpp1DelDataHora ;
      private DateTime[] T000T2_A610Tpp1DelData ;
      private bool[] T000T2_n610Tpp1DelData ;
      private DateTime[] T000T2_A611Tpp1DelHora ;
      private bool[] T000T2_n611Tpp1DelHora ;
      private string[] T000T2_A612Tpp1DelUsuId ;
      private bool[] T000T2_n612Tpp1DelUsuId ;
      private string[] T000T2_A613Tpp1DelUsuNome ;
      private bool[] T000T2_n613Tpp1DelUsuNome ;
      private decimal[] T000T2_A247Tpp1Preco ;
      private bool[] T000T2_A608Tpp1Del ;
      private Guid[] T000T2_A220PrdID ;
      private string[] T000T2_A221PrdCodigo ;
      private string[] T000T2_A222PrdNome ;
      private int[] T000T2_A232PrdTipoID ;
      private string[] T000T24_A221PrdCodigo ;
      private string[] T000T24_A222PrdNome ;
      private int[] T000T24_A232PrdTipoID ;
      private bool[] T000T24_A231PrdAtivo ;
      private Guid[] T000T25_A345NegID ;
      private int[] T000T25_A435NgpItem ;
      private Guid[] T000T26_A235TppID ;
      private Guid[] T000T26_A220PrdID ;
      private string[] T000T27_A236TppCodigo ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV13PrdID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item3 ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV14DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV16AuditingObject ;
   }

   public class tabeladepreco__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class tabeladepreco__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[7])
       ,new ForEachCursor(def[8])
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new UpdateCursor(def[21])
       ,new ForEachCursor(def[22])
       ,new ForEachCursor(def[23])
       ,new ForEachCursor(def[24])
       ,new ForEachCursor(def[25])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000T7;
        prmT000T7 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T8;
        prmT000T8 = new Object[] {
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T9;
        prmT000T9 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T6;
        prmT000T6 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T10;
        prmT000T10 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T11;
        prmT000T11 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T5;
        prmT000T5 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T12;
        prmT000T12 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("TppInsDataHora",GXType.DateTime,10,8) ,
        new ParDef("TppInsData",GXType.Date,8,0) ,
        new ParDef("TppInsHora",GXType.DateTime,0,5) ,
        new ParDef("TppInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("TppDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppNome",GXType.VarChar,80,0) ,
        new ParDef("TppUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("TppUpdHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("TppDel",GXType.Boolean,4,0)
        };
        Object[] prmT000T13;
        prmT000T13 = new Object[] {
        new ParDef("TppInsDataHora",GXType.DateTime,10,8) ,
        new ParDef("TppInsData",GXType.Date,8,0) ,
        new ParDef("TppInsHora",GXType.DateTime,0,5) ,
        new ParDef("TppInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppInsUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("TppDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppNome",GXType.VarChar,80,0) ,
        new ParDef("TppUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("TppUpdHora",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("TppUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("TppUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("TppUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("TppAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("TppDel",GXType.Boolean,4,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T14;
        prmT000T14 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T15;
        prmT000T15 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T16;
        prmT000T16 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T17;
        prmT000T17 = new Object[] {
        };
        Object[] prmT000T18;
        prmT000T18 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T4;
        prmT000T4 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T19;
        prmT000T19 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T20;
        prmT000T20 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T3;
        prmT000T3 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T2;
        prmT000T2 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T21;
        prmT000T21 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("Tpp1DelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("Tpp1DelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("Tpp1DelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("Tpp1DelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("Tpp1DelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("Tpp1Preco",GXType.Number,16,2) ,
        new ParDef("Tpp1Del",GXType.Boolean,4,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T22;
        prmT000T22 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("Tpp1DelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("Tpp1DelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("Tpp1DelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("Tpp1DelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("Tpp1DelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("Tpp1Preco",GXType.Number,16,2) ,
        new ParDef("Tpp1Del",GXType.Boolean,4,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T23;
        prmT000T23 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T25;
        prmT000T25 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T26;
        prmT000T26 = new Object[] {
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T27;
        prmT000T27 = new Object[] {
        new ParDef("TppCodigo",GXType.VarChar,20,0) ,
        new ParDef("TppID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000T24;
        prmT000T24 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000T2", "SELECT TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID, PrdCodigo, PrdNome, PrdTipoID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID  FOR UPDATE OF tb_tabeladepreco_produto NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T3", "SELECT TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID, PrdCodigo, PrdNome, PrdTipoID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T4", "SELECT PrdCodigo, PrdNome, PrdTipoID, PrdAtivo FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T5", "SELECT TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel FROM tb_tabeladepreco WHERE TppID = :TppID  FOR UPDATE OF tb_tabeladepreco NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000T5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T6", "SELECT TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel FROM tb_tabeladepreco WHERE TppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T7", "SELECT TM1.TppID, TM1.TppInsDataHora, TM1.TppInsData, TM1.TppInsHora, TM1.TppInsUsuID, TM1.TppInsUsuNome, TM1.TppDelDataHora, TM1.TppDelData, TM1.TppDelHora, TM1.TppDelUsuId, TM1.TppDelUsuNome, TM1.TppCodigo, TM1.TppNome, TM1.TppUpdData, TM1.TppUpdHora, TM1.TppUpdDataHora, TM1.TppUpdUsuID, TM1.TppUpdUsuNome, TM1.TppAtivo, TM1.TppDel FROM tb_tabeladepreco TM1 WHERE TM1.TppID = :TppID ORDER BY TM1.TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T8", "SELECT TppCodigo FROM tb_tabeladepreco WHERE (TppCodigo = :TppCodigo) AND (Not ( TppID = :TppID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T9", "SELECT TppID FROM tb_tabeladepreco WHERE TppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T10", "SELECT TppID FROM tb_tabeladepreco WHERE ( TppID > :TppID) ORDER BY TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T11", "SELECT TppID FROM tb_tabeladepreco WHERE ( TppID < :TppID) ORDER BY TppID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T12", "SAVEPOINT gxupdate;INSERT INTO tb_tabeladepreco(TppID, TppInsDataHora, TppInsData, TppInsHora, TppInsUsuID, TppInsUsuNome, TppDelDataHora, TppDelData, TppDelHora, TppDelUsuId, TppDelUsuNome, TppCodigo, TppNome, TppUpdData, TppUpdHora, TppUpdDataHora, TppUpdUsuID, TppUpdUsuNome, TppAtivo, TppDel) VALUES(:TppID, :TppInsDataHora, :TppInsData, :TppInsHora, :TppInsUsuID, :TppInsUsuNome, :TppDelDataHora, :TppDelData, :TppDelHora, :TppDelUsuId, :TppDelUsuNome, :TppCodigo, :TppNome, :TppUpdData, :TppUpdHora, :TppUpdDataHora, :TppUpdUsuID, :TppUpdUsuNome, :TppAtivo, :TppDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T12)
           ,new CursorDef("T000T13", "SAVEPOINT gxupdate;UPDATE tb_tabeladepreco SET TppInsDataHora=:TppInsDataHora, TppInsData=:TppInsData, TppInsHora=:TppInsHora, TppInsUsuID=:TppInsUsuID, TppInsUsuNome=:TppInsUsuNome, TppDelDataHora=:TppDelDataHora, TppDelData=:TppDelData, TppDelHora=:TppDelHora, TppDelUsuId=:TppDelUsuId, TppDelUsuNome=:TppDelUsuNome, TppCodigo=:TppCodigo, TppNome=:TppNome, TppUpdData=:TppUpdData, TppUpdHora=:TppUpdHora, TppUpdDataHora=:TppUpdDataHora, TppUpdUsuID=:TppUpdUsuID, TppUpdUsuNome=:TppUpdUsuNome, TppAtivo=:TppAtivo, TppDel=:TppDel  WHERE TppID = :TppID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T13)
           ,new CursorDef("T000T14", "SAVEPOINT gxupdate;DELETE FROM tb_tabeladepreco  WHERE TppID = :TppID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T14)
           ,new CursorDef("T000T15", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T16", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T16,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T17", "SELECT TppID FROM tb_tabeladepreco ORDER BY TppID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T18", "SELECT T1.TppID, T1.Tpp1DelDataHora, T1.Tpp1DelData, T1.Tpp1DelHora, T1.Tpp1DelUsuId, T1.Tpp1DelUsuNome, T1.PrdCodigo, T1.PrdNome, T1.PrdTipoID, T2.PrdAtivo, T1.Tpp1Preco, T1.Tpp1Del, T1.PrdID FROM (tb_tabeladepreco_produto T1 INNER JOIN tb_produto T2 ON T2.PrdID = T1.PrdID) WHERE T1.TppID = :TppID and T1.PrdID = :PrdID ORDER BY T1.TppID, T1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T18,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T19", "SELECT PrdCodigo, PrdNome, PrdTipoID, PrdAtivo FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T20", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE TppID = :TppID AND PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T20,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T21", "SAVEPOINT gxupdate;INSERT INTO tb_tabeladepreco_produto(PrdCodigo, PrdNome, PrdTipoID, TppID, Tpp1DelDataHora, Tpp1DelData, Tpp1DelHora, Tpp1DelUsuId, Tpp1DelUsuNome, Tpp1Preco, Tpp1Del, PrdID) VALUES(:PrdCodigo, :PrdNome, :PrdTipoID, :TppID, :Tpp1DelDataHora, :Tpp1DelData, :Tpp1DelHora, :Tpp1DelUsuId, :Tpp1DelUsuNome, :Tpp1Preco, :Tpp1Del, :PrdID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000T21)
           ,new CursorDef("T000T22", "SAVEPOINT gxupdate;UPDATE tb_tabeladepreco_produto SET PrdCodigo=:PrdCodigo, PrdNome=:PrdNome, PrdTipoID=:PrdTipoID, Tpp1DelDataHora=:Tpp1DelDataHora, Tpp1DelData=:Tpp1DelData, Tpp1DelHora=:Tpp1DelHora, Tpp1DelUsuId=:Tpp1DelUsuId, Tpp1DelUsuNome=:Tpp1DelUsuNome, Tpp1Preco=:Tpp1Preco, Tpp1Del=:Tpp1Del  WHERE TppID = :TppID AND PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T22)
           ,new CursorDef("T000T23", "SAVEPOINT gxupdate;DELETE FROM tb_tabeladepreco_produto  WHERE TppID = :TppID AND PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000T23)
           ,new CursorDef("T000T24", "SELECT PrdCodigo, PrdNome, PrdTipoID, PrdAtivo FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T24,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T25", "SELECT NegID, NgpItem FROM tb_negociopj_item WHERE NgpTppID = :TppID AND NgpTppPrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T25,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000T26", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE TppID = :TppID ORDER BY TppID, PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T26,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000T27", "SELECT TppCodigo FROM tb_tabeladepreco WHERE (TppCodigo = :TppCodigo) AND (Not ( TppID = :TppID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000T27,1, GxCacheFrequency.OFF ,true,false )
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
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.getBool(8);
              ((Guid[]) buf[13])[0] = rslt.getGuid(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((int[]) buf[16])[0] = rslt.getInt(12);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
              ((decimal[]) buf[11])[0] = rslt.getDecimal(7);
              ((bool[]) buf[12])[0] = rslt.getBool(8);
              ((Guid[]) buf[13])[0] = rslt.getGuid(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((string[]) buf[15])[0] = rslt.getVarchar(11);
              ((int[]) buf[16])[0] = rslt.getInt(12);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 3 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getString(10, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((string[]) buf[16])[0] = rslt.getVarchar(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((string[]) buf[18])[0] = rslt.getVarchar(12);
              ((string[]) buf[19])[0] = rslt.getVarchar(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDate(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[24])[0] = rslt.getGXDateTime(16, true);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getString(17, 40);
              ((bool[]) buf[27])[0] = rslt.wasNull(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((bool[]) buf[31])[0] = rslt.wasNull(19);
              ((bool[]) buf[32])[0] = rslt.getBool(20);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
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
              ((int[]) buf[13])[0] = rslt.getInt(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              ((decimal[]) buf[15])[0] = rslt.getDecimal(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((Guid[]) buf[17])[0] = rslt.getGuid(13);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 22 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((int[]) buf[2])[0] = rslt.getInt(3);
              ((bool[]) buf[3])[0] = rslt.getBool(4);
              return;
           case 23 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 24 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 25 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
