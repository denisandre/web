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
   public class produto : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_22") == 0 )
         {
            A232PrdTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "PrdTipoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_22( A232PrdTipoID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.produto.aspx")), "core.produto.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.produto.aspx")))) ;
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
                  AV7PrdID = StringUtil.StrToGuid( GetPar( "PrdID"));
                  AssignAttri("", false, "AV7PrdID", AV7PrdID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vPRDID", GetSecureSignedToken( "", AV7PrdID, context));
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
            Form.Meta.addItem("description", "Produto ou Serviço", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtPrdCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public produto( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public produto( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_PrdID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7PrdID = aP1_PrdID;
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
            return "produto_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrdCodigo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrdCodigo_Internalname, "Código", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdCodigo_Internalname, A221PrdCodigo, StringUtil.RTrim( context.localUtil.Format( A221PrdCodigo, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdCodigo_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrdCodigo_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "core\\ProdutoCodigo", "start", true, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtPrdNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrdNome_Internalname, "Descrição", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdNome_Internalname, A222PrdNome, StringUtil.RTrim( context.localUtil.Format( A222PrdNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtPrdNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittedprdtipoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockprdtipoid_Internalname, "Tipo do Produto ou Serviço", "", "", lblTextblockprdtipoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_prdtipoid.SetProperty("Caption", Combo_prdtipoid_Caption);
         ucCombo_prdtipoid.SetProperty("Cls", Combo_prdtipoid_Cls);
         ucCombo_prdtipoid.SetProperty("DataListProc", Combo_prdtipoid_Datalistproc);
         ucCombo_prdtipoid.SetProperty("DataListProcParametersPrefix", Combo_prdtipoid_Datalistprocparametersprefix);
         ucCombo_prdtipoid.SetProperty("EmptyItem", Combo_prdtipoid_Emptyitem);
         ucCombo_prdtipoid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_prdtipoid.SetProperty("DropDownOptionsData", AV15PrdTipoID_Data);
         ucCombo_prdtipoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_prdtipoid_Internalname, "COMBO_PRDTIPOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtPrdTipoID_Internalname, "Tipo do Produto ou Serviço", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A232PrdTipoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,38);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdTipoID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdTipoID_Visible, edtPrdTipoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Produto.htm");
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
         /* Div Control */
         GxWebStd.gx_div_start( context, divSectionattribute_prdtipoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavComboprdtipoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV20ComboPrdTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavComboprdtipoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV20ComboPrdTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV20ComboPrdTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavComboprdtipoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavComboprdtipoid_Visible, edtavComboprdtipoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdID_Internalname, A220PrdID.ToString(), A220PrdID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,51);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdID_Visible, edtPrdID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Produto.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 52,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdInsData_Internalname, context.localUtil.Format(A223PrdInsData, "99/99/99"), context.localUtil.Format( A223PrdInsData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,52);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsData_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsData_Visible, edtPrdInsData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsData_Visible==0)||(edtPrdInsData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdInsHora_Internalname, context.localUtil.TToC( A224PrdInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A224PrdInsHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsHora_Visible, edtPrdInsHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsHora_Visible==0)||(edtPrdInsHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdInsDataHora_Internalname, context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A225PrdInsDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsDataHora_Visible, edtPrdInsDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdInsDataHora_Visible==0)||(edtPrdInsDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdInsUsuID_Internalname, StringUtil.RTrim( A226PrdInsUsuID), StringUtil.RTrim( context.localUtil.Format( A226PrdInsUsuID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,55);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdInsUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdInsUsuID_Visible, edtPrdInsUsuID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\Produto.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 56,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdUpdData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdUpdData_Internalname, context.localUtil.Format(A227PrdUpdData, "99/99/99"), context.localUtil.Format( A227PrdUpdData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,56);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdData_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdData_Visible, edtPrdUpdData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdUpdData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdData_Visible==0)||(edtPrdUpdData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 57,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdUpdHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdUpdHora_Internalname, context.localUtil.TToC( A228PrdUpdHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A228PrdUpdHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,57);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdHora_Visible, edtPrdUpdHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdUpdHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdHora_Visible==0)||(edtPrdUpdHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtPrdUpdDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtPrdUpdDataHora_Internalname, context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A229PrdUpdDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdDataHora_Visible, edtPrdUpdDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\Produto.htm");
         GxWebStd.gx_bitmap( context, edtPrdUpdDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtPrdUpdDataHora_Visible==0)||(edtPrdUpdDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Produto.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdUpdUsuID_Internalname, StringUtil.RTrim( A230PrdUpdUsuID), StringUtil.RTrim( context.localUtil.Format( A230PrdUpdUsuID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdUpdUsuID_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdUpdUsuID_Visible, edtPrdUpdUsuID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\Produto.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtPrdAtivo_Internalname, StringUtil.BoolToStr( A231PrdAtivo), StringUtil.BoolToStr( A231PrdAtivo), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,60);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdAtivo_Visible, edtPrdAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\Produto.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtPrdTipoSigla_Internalname, A233PrdTipoSigla, StringUtil.RTrim( context.localUtil.Format( A233PrdTipoSigla, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtPrdTipoSigla_Jsonclick, 0, "Attribute", "", "", "", "", edtPrdTipoSigla_Visible, edtPrdTipoSigla_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "core\\Sigla", "start", true, "", "HLP_core\\Produto.htm");
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
         E110S2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vPRDTIPOID_DATA"), AV15PrdTipoID_Data);
               /* Read saved values. */
               Z220PrdID = StringUtil.StrToGuid( cgiGet( "Z220PrdID"));
               Z621PrdDelDataHora = context.localUtil.CToT( cgiGet( "Z621PrdDelDataHora"), 0);
               n621PrdDelDataHora = ((DateTime.MinValue==A621PrdDelDataHora) ? true : false);
               Z622PrdDelData = context.localUtil.CToT( cgiGet( "Z622PrdDelData"), 0);
               n622PrdDelData = ((DateTime.MinValue==A622PrdDelData) ? true : false);
               Z623PrdDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z623PrdDelHora"), 0));
               n623PrdDelHora = ((DateTime.MinValue==A623PrdDelHora) ? true : false);
               Z624PrdDelUsuId = cgiGet( "Z624PrdDelUsuId");
               n624PrdDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A624PrdDelUsuId)) ? true : false);
               Z625PrdDelUsuNome = cgiGet( "Z625PrdDelUsuNome");
               n625PrdDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A625PrdDelUsuNome)) ? true : false);
               Z221PrdCodigo = cgiGet( "Z221PrdCodigo");
               Z222PrdNome = cgiGet( "Z222PrdNome");
               Z223PrdInsData = context.localUtil.CToD( cgiGet( "Z223PrdInsData"), 0);
               Z224PrdInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z224PrdInsHora"), 0));
               Z225PrdInsDataHora = context.localUtil.CToT( cgiGet( "Z225PrdInsDataHora"), 0);
               Z226PrdInsUsuID = cgiGet( "Z226PrdInsUsuID");
               n226PrdInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A226PrdInsUsuID)) ? true : false);
               Z227PrdUpdData = context.localUtil.CToD( cgiGet( "Z227PrdUpdData"), 0);
               n227PrdUpdData = ((DateTime.MinValue==A227PrdUpdData) ? true : false);
               Z228PrdUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z228PrdUpdHora"), 0));
               n228PrdUpdHora = ((DateTime.MinValue==A228PrdUpdHora) ? true : false);
               Z229PrdUpdDataHora = context.localUtil.CToT( cgiGet( "Z229PrdUpdDataHora"), 0);
               n229PrdUpdDataHora = ((DateTime.MinValue==A229PrdUpdDataHora) ? true : false);
               Z230PrdUpdUsuID = cgiGet( "Z230PrdUpdUsuID");
               n230PrdUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A230PrdUpdUsuID)) ? true : false);
               Z231PrdAtivo = StringUtil.StrToBool( cgiGet( "Z231PrdAtivo"));
               Z620PrdDel = StringUtil.StrToBool( cgiGet( "Z620PrdDel"));
               Z232PrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z232PrdTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               A621PrdDelDataHora = context.localUtil.CToT( cgiGet( "Z621PrdDelDataHora"), 0);
               n621PrdDelDataHora = false;
               n621PrdDelDataHora = ((DateTime.MinValue==A621PrdDelDataHora) ? true : false);
               A622PrdDelData = context.localUtil.CToT( cgiGet( "Z622PrdDelData"), 0);
               n622PrdDelData = false;
               n622PrdDelData = ((DateTime.MinValue==A622PrdDelData) ? true : false);
               A623PrdDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z623PrdDelHora"), 0));
               n623PrdDelHora = false;
               n623PrdDelHora = ((DateTime.MinValue==A623PrdDelHora) ? true : false);
               A624PrdDelUsuId = cgiGet( "Z624PrdDelUsuId");
               n624PrdDelUsuId = false;
               n624PrdDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A624PrdDelUsuId)) ? true : false);
               A625PrdDelUsuNome = cgiGet( "Z625PrdDelUsuNome");
               n625PrdDelUsuNome = false;
               n625PrdDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A625PrdDelUsuNome)) ? true : false);
               A620PrdDel = StringUtil.StrToBool( cgiGet( "Z620PrdDel"));
               O620PrdDel = StringUtil.StrToBool( cgiGet( "O620PrdDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N232PrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N232PrdTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7PrdID = StringUtil.StrToGuid( cgiGet( "vPRDID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               AV13Insert_PrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_PRDTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               A620PrdDel = StringUtil.StrToBool( cgiGet( "PRDDEL"));
               A621PrdDelDataHora = context.localUtil.CToT( cgiGet( "PRDDELDATAHORA"), 0);
               n621PrdDelDataHora = ((DateTime.MinValue==A621PrdDelDataHora) ? true : false);
               A622PrdDelData = context.localUtil.CToT( cgiGet( "PRDDELDATA"), 0);
               n622PrdDelData = ((DateTime.MinValue==A622PrdDelData) ? true : false);
               A623PrdDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "PRDDELHORA"), 0));
               n623PrdDelHora = ((DateTime.MinValue==A623PrdDelHora) ? true : false);
               A624PrdDelUsuId = cgiGet( "PRDDELUSUID");
               n624PrdDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A624PrdDelUsuId)) ? true : false);
               A625PrdDelUsuNome = cgiGet( "PRDDELUSUNOME");
               n625PrdDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A625PrdDelUsuNome)) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV24AuditingObject);
               A234PrdTipoNome = cgiGet( "PRDTIPONOME");
               AV25Pgmname = cgiGet( "vPGMNAME");
               Combo_prdtipoid_Objectcall = cgiGet( "COMBO_PRDTIPOID_Objectcall");
               Combo_prdtipoid_Class = cgiGet( "COMBO_PRDTIPOID_Class");
               Combo_prdtipoid_Icontype = cgiGet( "COMBO_PRDTIPOID_Icontype");
               Combo_prdtipoid_Icon = cgiGet( "COMBO_PRDTIPOID_Icon");
               Combo_prdtipoid_Caption = cgiGet( "COMBO_PRDTIPOID_Caption");
               Combo_prdtipoid_Tooltip = cgiGet( "COMBO_PRDTIPOID_Tooltip");
               Combo_prdtipoid_Cls = cgiGet( "COMBO_PRDTIPOID_Cls");
               Combo_prdtipoid_Selectedvalue_set = cgiGet( "COMBO_PRDTIPOID_Selectedvalue_set");
               Combo_prdtipoid_Selectedvalue_get = cgiGet( "COMBO_PRDTIPOID_Selectedvalue_get");
               Combo_prdtipoid_Selectedtext_set = cgiGet( "COMBO_PRDTIPOID_Selectedtext_set");
               Combo_prdtipoid_Selectedtext_get = cgiGet( "COMBO_PRDTIPOID_Selectedtext_get");
               Combo_prdtipoid_Gamoauthtoken = cgiGet( "COMBO_PRDTIPOID_Gamoauthtoken");
               Combo_prdtipoid_Ddointernalname = cgiGet( "COMBO_PRDTIPOID_Ddointernalname");
               Combo_prdtipoid_Titlecontrolalign = cgiGet( "COMBO_PRDTIPOID_Titlecontrolalign");
               Combo_prdtipoid_Dropdownoptionstype = cgiGet( "COMBO_PRDTIPOID_Dropdownoptionstype");
               Combo_prdtipoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Enabled"));
               Combo_prdtipoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Visible"));
               Combo_prdtipoid_Titlecontrolidtoreplace = cgiGet( "COMBO_PRDTIPOID_Titlecontrolidtoreplace");
               Combo_prdtipoid_Datalisttype = cgiGet( "COMBO_PRDTIPOID_Datalisttype");
               Combo_prdtipoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Allowmultipleselection"));
               Combo_prdtipoid_Datalistfixedvalues = cgiGet( "COMBO_PRDTIPOID_Datalistfixedvalues");
               Combo_prdtipoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Isgriditem"));
               Combo_prdtipoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Hasdescription"));
               Combo_prdtipoid_Datalistproc = cgiGet( "COMBO_PRDTIPOID_Datalistproc");
               Combo_prdtipoid_Datalistprocparametersprefix = cgiGet( "COMBO_PRDTIPOID_Datalistprocparametersprefix");
               Combo_prdtipoid_Remoteservicesparameters = cgiGet( "COMBO_PRDTIPOID_Remoteservicesparameters");
               Combo_prdtipoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRDTIPOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_prdtipoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Includeonlyselectedoption"));
               Combo_prdtipoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Includeselectalloption"));
               Combo_prdtipoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Emptyitem"));
               Combo_prdtipoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_PRDTIPOID_Includeaddnewoption"));
               Combo_prdtipoid_Htmltemplate = cgiGet( "COMBO_PRDTIPOID_Htmltemplate");
               Combo_prdtipoid_Multiplevaluestype = cgiGet( "COMBO_PRDTIPOID_Multiplevaluestype");
               Combo_prdtipoid_Loadingdata = cgiGet( "COMBO_PRDTIPOID_Loadingdata");
               Combo_prdtipoid_Noresultsfound = cgiGet( "COMBO_PRDTIPOID_Noresultsfound");
               Combo_prdtipoid_Emptyitemtext = cgiGet( "COMBO_PRDTIPOID_Emptyitemtext");
               Combo_prdtipoid_Onlyselectedvalues = cgiGet( "COMBO_PRDTIPOID_Onlyselectedvalues");
               Combo_prdtipoid_Selectalltext = cgiGet( "COMBO_PRDTIPOID_Selectalltext");
               Combo_prdtipoid_Multiplevaluesseparator = cgiGet( "COMBO_PRDTIPOID_Multiplevaluesseparator");
               Combo_prdtipoid_Addnewoptiontext = cgiGet( "COMBO_PRDTIPOID_Addnewoptiontext");
               Combo_prdtipoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_PRDTIPOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A221PrdCodigo = cgiGet( edtPrdCodigo_Internalname);
               AssignAttri("", false, "A221PrdCodigo", A221PrdCodigo);
               A222PrdNome = StringUtil.Upper( cgiGet( edtPrdNome_Internalname));
               AssignAttri("", false, "A222PrdNome", A222PrdNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtPrdTipoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtPrdTipoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "PRDTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtPrdTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A232PrdTipoID = 0;
                  AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
               }
               else
               {
                  A232PrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtPrdTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
               }
               AV20ComboPrdTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavComboprdtipoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV20ComboPrdTipoID", StringUtil.LTrimStr( (decimal)(AV20ComboPrdTipoID), 9, 0));
               if ( StringUtil.StrCmp(cgiGet( edtPrdID_Internalname), "") == 0 )
               {
                  A220PrdID = Guid.Empty;
                  AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
               }
               else
               {
                  try
                  {
                     A220PrdID = StringUtil.StrToGuid( cgiGet( edtPrdID_Internalname));
                     AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "PRDID");
                     AnyError = 1;
                     GX_FocusControl = edtPrdID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( context.localUtil.VCDate( cgiGet( edtPrdInsData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data de Inclusão"}), 1, "PRDINSDATA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdInsData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A223PrdInsData = DateTime.MinValue;
                  AssignAttri("", false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
               }
               else
               {
                  A223PrdInsData = context.localUtil.CToD( cgiGet( edtPrdInsData_Internalname), 2);
                  AssignAttri("", false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtPrdInsHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora de Inclusão"}), 1, "PRDINSHORA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdInsHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A224PrdInsHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A224PrdInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtPrdInsHora_Internalname)));
                  AssignAttri("", false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtPrdInsDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data/Hora de Inclusão"}), 1, "PRDINSDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdInsDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A225PrdInsDataHora = context.localUtil.CToT( cgiGet( edtPrdInsDataHora_Internalname));
                  AssignAttri("", false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               A226PrdInsUsuID = cgiGet( edtPrdInsUsuID_Internalname);
               n226PrdInsUsuID = false;
               AssignAttri("", false, "A226PrdInsUsuID", A226PrdInsUsuID);
               n226PrdInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A226PrdInsUsuID)) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtPrdUpdData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Data da Última Alteração"}), 1, "PRDUPDDATA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdUpdData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A227PrdUpdData = DateTime.MinValue;
                  n227PrdUpdData = false;
                  AssignAttri("", false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
               }
               else
               {
                  A227PrdUpdData = context.localUtil.CToD( cgiGet( edtPrdUpdData_Internalname), 2);
                  n227PrdUpdData = false;
                  AssignAttri("", false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
               }
               n227PrdUpdData = ((DateTime.MinValue==A227PrdUpdData) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtPrdUpdHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora da Última Alteração"}), 1, "PRDUPDHORA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdUpdHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A228PrdUpdHora = (DateTime)(DateTime.MinValue);
                  n228PrdUpdHora = false;
                  AssignAttri("", false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A228PrdUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtPrdUpdHora_Internalname)));
                  n228PrdUpdHora = false;
                  AssignAttri("", false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
               }
               n228PrdUpdHora = ((DateTime.MinValue==A228PrdUpdHora) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtPrdUpdDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Data/Hora da Útlima Alteração"}), 1, "PRDUPDDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtPrdUpdDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
                  n229PrdUpdDataHora = false;
                  AssignAttri("", false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A229PrdUpdDataHora = context.localUtil.CToT( cgiGet( edtPrdUpdDataHora_Internalname));
                  n229PrdUpdDataHora = false;
                  AssignAttri("", false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               n229PrdUpdDataHora = ((DateTime.MinValue==A229PrdUpdDataHora) ? true : false);
               A230PrdUpdUsuID = cgiGet( edtPrdUpdUsuID_Internalname);
               n230PrdUpdUsuID = false;
               AssignAttri("", false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
               n230PrdUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A230PrdUpdUsuID)) ? true : false);
               A231PrdAtivo = StringUtil.StrToBool( cgiGet( edtPrdAtivo_Internalname));
               AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
               A233PrdTipoSigla = cgiGet( edtPrdTipoSigla_Internalname);
               AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Produto");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")));
               forbiddenHiddens.Add("PrdDel", StringUtil.BoolToStr( A620PrdDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A220PrdID != Z220PrdID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\produto:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A220PrdID = StringUtil.StrToGuid( GetPar( "PrdID"));
                  AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7PrdID) )
                  {
                     A220PrdID = AV7PrdID;
                     AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A220PrdID) && ( Gx_BScreen == 0 ) )
                     {
                        A220PrdID = Guid.NewGuid( );
                        AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
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
                     sMode28 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7PrdID) )
                     {
                        A220PrdID = AV7PrdID;
                        AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A220PrdID) && ( Gx_BScreen == 0 ) )
                        {
                           A220PrdID = Guid.NewGuid( );
                           AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                        }
                     }
                     Gx_mode = sMode28;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound28 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0S0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "PRDID");
                        AnyError = 1;
                        GX_FocusControl = edtPrdID_Internalname;
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
                           E110S2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120S2 ();
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
            E120S2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0S28( ) ;
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
            DisableAttributes0S28( ) ;
         }
         AssignProp("", false, edtavComboprdtipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprdtipoid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0S0( )
      {
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0S28( ) ;
            }
            else
            {
               CheckExtendedTable0S28( ) ;
               CloseExtendedTableCursors0S28( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0S0( )
      {
      }

      protected void E110S2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("PRDID");
         AV12WebSession.Remove("PRDCODIGO");
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV23GAMErrors);
         Combo_prdtipoid_Gamoauthtoken = AV22GAMSession.gxTpr_Token;
         ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "GAMOAuthToken", Combo_prdtipoid_Gamoauthtoken);
         edtPrdTipoID_Visible = 0;
         AssignProp("", false, edtPrdTipoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Visible), 5, 0), true);
         AV20ComboPrdTipoID = 0;
         AssignAttri("", false, "AV20ComboPrdTipoID", StringUtil.LTrimStr( (decimal)(AV20ComboPrdTipoID), 9, 0));
         edtavComboprdtipoid_Visible = 0;
         AssignProp("", false, edtavComboprdtipoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavComboprdtipoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBOPRDTIPOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV25Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV26GXV1 = 1;
            AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            while ( AV26GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV14TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV26GXV1));
               if ( StringUtil.StrCmp(AV14TrnContextAtt.gxTpr_Attributename, "PrdTipoID") == 0 )
               {
                  AV13Insert_PrdTipoID = (int)(Math.Round(NumberUtil.Val( AV14TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV13Insert_PrdTipoID", StringUtil.LTrimStr( (decimal)(AV13Insert_PrdTipoID), 9, 0));
                  if ( ! (0==AV13Insert_PrdTipoID) )
                  {
                     AV20ComboPrdTipoID = AV13Insert_PrdTipoID;
                     AssignAttri("", false, "AV20ComboPrdTipoID", StringUtil.LTrimStr( (decimal)(AV20ComboPrdTipoID), 9, 0));
                     Combo_prdtipoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV20ComboPrdTipoID), 9, 0));
                     ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "SelectedValue_set", Combo_prdtipoid_Selectedvalue_set);
                     GXt_char2 = AV19Combo_DataJson;
                     new GeneXus.Programs.core.produtoloaddvcombo(context ).execute(  "PrdTipoID",  "GET",  false,  AV7PrdID,  AV14TrnContextAtt.gxTpr_Attributevalue, out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
                     AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
                     AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
                     AV19Combo_DataJson = GXt_char2;
                     AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
                     Combo_prdtipoid_Selectedtext_set = AV18ComboSelectedText;
                     ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "SelectedText_set", Combo_prdtipoid_Selectedtext_set);
                     Combo_prdtipoid_Enabled = false;
                     ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prdtipoid_Enabled));
                  }
               }
               AV26GXV1 = (int)(AV26GXV1+1);
               AssignAttri("", false, "AV26GXV1", StringUtil.LTrimStr( (decimal)(AV26GXV1), 8, 0));
            }
         }
         edtPrdID_Visible = 0;
         AssignProp("", false, edtPrdID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdID_Visible), 5, 0), true);
         edtPrdInsData_Visible = 0;
         AssignProp("", false, edtPrdInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsData_Visible), 5, 0), true);
         edtPrdInsHora_Visible = 0;
         AssignProp("", false, edtPrdInsHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsHora_Visible), 5, 0), true);
         edtPrdInsDataHora_Visible = 0;
         AssignProp("", false, edtPrdInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsDataHora_Visible), 5, 0), true);
         edtPrdInsUsuID_Visible = 0;
         AssignProp("", false, edtPrdInsUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdInsUsuID_Visible), 5, 0), true);
         edtPrdUpdData_Visible = 0;
         AssignProp("", false, edtPrdUpdData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdData_Visible), 5, 0), true);
         edtPrdUpdHora_Visible = 0;
         AssignProp("", false, edtPrdUpdHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdHora_Visible), 5, 0), true);
         edtPrdUpdDataHora_Visible = 0;
         AssignProp("", false, edtPrdUpdDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdDataHora_Visible), 5, 0), true);
         edtPrdUpdUsuID_Visible = 0;
         AssignProp("", false, edtPrdUpdUsuID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdUpdUsuID_Visible), 5, 0), true);
         edtPrdAtivo_Visible = 0;
         AssignProp("", false, edtPrdAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdAtivo_Visible), 5, 0), true);
         edtPrdTipoSigla_Visible = 0;
         AssignProp("", false, edtPrdTipoSigla_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtPrdTipoSigla_Visible), 5, 0), true);
      }

      protected void E120S2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV24AuditingObject,  AV25Pgmname) ;
         AV12WebSession.Set("PRDID", StringUtil.Trim( A220PrdID.ToString()));
         AV12WebSession.Set("PRDCODIGO", A221PrdCodigo);
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.produtoww.aspx") );
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
         /* 'LOADCOMBOPRDTIPOID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.produtoloaddvcombo(context ).execute(  "PrdTipoID",  Gx_mode,  false,  AV7PrdID,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AssignAttri("", false, "AV17ComboSelectedValue", AV17ComboSelectedValue);
         AssignAttri("", false, "AV18ComboSelectedText", AV18ComboSelectedText);
         AV19Combo_DataJson = GXt_char2;
         AssignAttri("", false, "AV19Combo_DataJson", AV19Combo_DataJson);
         Combo_prdtipoid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "SelectedValue_set", Combo_prdtipoid_Selectedvalue_set);
         Combo_prdtipoid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "SelectedText_set", Combo_prdtipoid_Selectedtext_set);
         AV20ComboPrdTipoID = (int)(Math.Round(NumberUtil.Val( AV17ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV20ComboPrdTipoID", StringUtil.LTrimStr( (decimal)(AV20ComboPrdTipoID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_prdtipoid_Enabled = false;
            ucCombo_prdtipoid.SendProperty(context, "", false, Combo_prdtipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_prdtipoid_Enabled));
         }
      }

      protected void ZM0S28( short GX_JID )
      {
         if ( ( GX_JID == 20 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z621PrdDelDataHora = T000S3_A621PrdDelDataHora[0];
               Z622PrdDelData = T000S3_A622PrdDelData[0];
               Z623PrdDelHora = T000S3_A623PrdDelHora[0];
               Z624PrdDelUsuId = T000S3_A624PrdDelUsuId[0];
               Z625PrdDelUsuNome = T000S3_A625PrdDelUsuNome[0];
               Z221PrdCodigo = T000S3_A221PrdCodigo[0];
               Z222PrdNome = T000S3_A222PrdNome[0];
               Z223PrdInsData = T000S3_A223PrdInsData[0];
               Z224PrdInsHora = T000S3_A224PrdInsHora[0];
               Z225PrdInsDataHora = T000S3_A225PrdInsDataHora[0];
               Z226PrdInsUsuID = T000S3_A226PrdInsUsuID[0];
               Z227PrdUpdData = T000S3_A227PrdUpdData[0];
               Z228PrdUpdHora = T000S3_A228PrdUpdHora[0];
               Z229PrdUpdDataHora = T000S3_A229PrdUpdDataHora[0];
               Z230PrdUpdUsuID = T000S3_A230PrdUpdUsuID[0];
               Z231PrdAtivo = T000S3_A231PrdAtivo[0];
               Z620PrdDel = T000S3_A620PrdDel[0];
               Z232PrdTipoID = T000S3_A232PrdTipoID[0];
            }
            else
            {
               Z621PrdDelDataHora = A621PrdDelDataHora;
               Z622PrdDelData = A622PrdDelData;
               Z623PrdDelHora = A623PrdDelHora;
               Z624PrdDelUsuId = A624PrdDelUsuId;
               Z625PrdDelUsuNome = A625PrdDelUsuNome;
               Z221PrdCodigo = A221PrdCodigo;
               Z222PrdNome = A222PrdNome;
               Z223PrdInsData = A223PrdInsData;
               Z224PrdInsHora = A224PrdInsHora;
               Z225PrdInsDataHora = A225PrdInsDataHora;
               Z226PrdInsUsuID = A226PrdInsUsuID;
               Z227PrdUpdData = A227PrdUpdData;
               Z228PrdUpdHora = A228PrdUpdHora;
               Z229PrdUpdDataHora = A229PrdUpdDataHora;
               Z230PrdUpdUsuID = A230PrdUpdUsuID;
               Z231PrdAtivo = A231PrdAtivo;
               Z620PrdDel = A620PrdDel;
               Z232PrdTipoID = A232PrdTipoID;
            }
         }
         if ( GX_JID == -20 )
         {
            Z220PrdID = A220PrdID;
            Z621PrdDelDataHora = A621PrdDelDataHora;
            Z622PrdDelData = A622PrdDelData;
            Z623PrdDelHora = A623PrdDelHora;
            Z624PrdDelUsuId = A624PrdDelUsuId;
            Z625PrdDelUsuNome = A625PrdDelUsuNome;
            Z221PrdCodigo = A221PrdCodigo;
            Z222PrdNome = A222PrdNome;
            Z223PrdInsData = A223PrdInsData;
            Z224PrdInsHora = A224PrdInsHora;
            Z225PrdInsDataHora = A225PrdInsDataHora;
            Z226PrdInsUsuID = A226PrdInsUsuID;
            Z227PrdUpdData = A227PrdUpdData;
            Z228PrdUpdHora = A228PrdUpdHora;
            Z229PrdUpdDataHora = A229PrdUpdDataHora;
            Z230PrdUpdUsuID = A230PrdUpdUsuID;
            Z231PrdAtivo = A231PrdAtivo;
            Z620PrdDel = A620PrdDel;
            Z232PrdTipoID = A232PrdTipoID;
            Z233PrdTipoSigla = A233PrdTipoSigla;
            Z234PrdTipoNome = A234PrdTipoNome;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV25Pgmname = "core.Produto";
         AssignAttri("", false, "AV25Pgmname", AV25Pgmname);
         if ( ! (Guid.Empty==AV7PrdID) )
         {
            edtPrdID_Enabled = 0;
            AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), true);
         }
         else
         {
            edtPrdID_Enabled = 1;
            AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7PrdID) )
         {
            edtPrdID_Enabled = 0;
            AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_PrdTipoID) )
         {
            edtPrdTipoID_Enabled = 0;
            AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), true);
         }
         else
         {
            edtPrdTipoID_Enabled = 1;
            AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV13Insert_PrdTipoID) )
         {
            A232PrdTipoID = AV13Insert_PrdTipoID;
            AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
         }
         else
         {
            A232PrdTipoID = AV20ComboPrdTipoID;
            AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
         }
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
         if ( ! (Guid.Empty==AV7PrdID) )
         {
            A220PrdID = AV7PrdID;
            AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A220PrdID) && ( Gx_BScreen == 0 ) )
            {
               A220PrdID = Guid.NewGuid( );
               AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
            }
         }
         if ( IsIns( )  && (false==A231PrdAtivo) && ( Gx_BScreen == 0 ) )
         {
            A231PrdAtivo = true;
            AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000S4 */
            pr_default.execute(2, new Object[] {A232PrdTipoID});
            A233PrdTipoSigla = T000S4_A233PrdTipoSigla[0];
            AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
            A234PrdTipoNome = T000S4_A234PrdTipoNome[0];
            pr_default.close(2);
         }
      }

      protected void Load0S28( )
      {
         /* Using cursor T000S5 */
         pr_default.execute(3, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound28 = 1;
            A621PrdDelDataHora = T000S5_A621PrdDelDataHora[0];
            n621PrdDelDataHora = T000S5_n621PrdDelDataHora[0];
            A622PrdDelData = T000S5_A622PrdDelData[0];
            n622PrdDelData = T000S5_n622PrdDelData[0];
            A623PrdDelHora = T000S5_A623PrdDelHora[0];
            n623PrdDelHora = T000S5_n623PrdDelHora[0];
            A624PrdDelUsuId = T000S5_A624PrdDelUsuId[0];
            n624PrdDelUsuId = T000S5_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = T000S5_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = T000S5_n625PrdDelUsuNome[0];
            A221PrdCodigo = T000S5_A221PrdCodigo[0];
            AssignAttri("", false, "A221PrdCodigo", A221PrdCodigo);
            A222PrdNome = T000S5_A222PrdNome[0];
            AssignAttri("", false, "A222PrdNome", A222PrdNome);
            A223PrdInsData = T000S5_A223PrdInsData[0];
            AssignAttri("", false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
            A224PrdInsHora = T000S5_A224PrdInsHora[0];
            AssignAttri("", false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
            A225PrdInsDataHora = T000S5_A225PrdInsDataHora[0];
            AssignAttri("", false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A226PrdInsUsuID = T000S5_A226PrdInsUsuID[0];
            n226PrdInsUsuID = T000S5_n226PrdInsUsuID[0];
            AssignAttri("", false, "A226PrdInsUsuID", A226PrdInsUsuID);
            A227PrdUpdData = T000S5_A227PrdUpdData[0];
            n227PrdUpdData = T000S5_n227PrdUpdData[0];
            AssignAttri("", false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
            A228PrdUpdHora = T000S5_A228PrdUpdHora[0];
            n228PrdUpdHora = T000S5_n228PrdUpdHora[0];
            AssignAttri("", false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
            A229PrdUpdDataHora = T000S5_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = T000S5_n229PrdUpdDataHora[0];
            AssignAttri("", false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A230PrdUpdUsuID = T000S5_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = T000S5_n230PrdUpdUsuID[0];
            AssignAttri("", false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
            A231PrdAtivo = T000S5_A231PrdAtivo[0];
            AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
            A233PrdTipoSigla = T000S5_A233PrdTipoSigla[0];
            AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
            A234PrdTipoNome = T000S5_A234PrdTipoNome[0];
            A620PrdDel = T000S5_A620PrdDel[0];
            A232PrdTipoID = T000S5_A232PrdTipoID[0];
            AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
            ZM0S28( -20) ;
         }
         pr_default.close(3);
         OnLoadActions0S28( ) ;
      }

      protected void OnLoadActions0S28( )
      {
      }

      protected void CheckExtendedTable0S28( )
      {
         nIsDirty_28 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000S6 */
         pr_default.execute(4, new Object[] {A221PrdCodigo, A220PrdID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "PRDCODIGO");
            AnyError = 1;
            GX_FocusControl = edtPrdCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         /* Using cursor T000S4 */
         pr_default.execute(2, new Object[] {A232PrdTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Produto -> Produto'.", "ForeignKeyNotFound", 1, "PRDTIPOID");
            AnyError = 1;
            GX_FocusControl = edtPrdTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A233PrdTipoSigla = T000S4_A233PrdTipoSigla[0];
         AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
         A234PrdTipoNome = T000S4_A234PrdTipoNome[0];
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors0S28( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_22( int A232PrdTipoID )
      {
         /* Using cursor T000S7 */
         pr_default.execute(5, new Object[] {A232PrdTipoID});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Produto -> Produto'.", "ForeignKeyNotFound", 1, "PRDTIPOID");
            AnyError = 1;
            GX_FocusControl = edtPrdTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A233PrdTipoSigla = T000S7_A233PrdTipoSigla[0];
         AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
         A234PrdTipoNome = T000S7_A234PrdTipoNome[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A233PrdTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A234PrdTipoNome)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey0S28( )
      {
         /* Using cursor T000S8 */
         pr_default.execute(6, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound28 = 1;
         }
         else
         {
            RcdFound28 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000S3 */
         pr_default.execute(1, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0S28( 20) ;
            RcdFound28 = 1;
            A220PrdID = T000S3_A220PrdID[0];
            AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
            A621PrdDelDataHora = T000S3_A621PrdDelDataHora[0];
            n621PrdDelDataHora = T000S3_n621PrdDelDataHora[0];
            A622PrdDelData = T000S3_A622PrdDelData[0];
            n622PrdDelData = T000S3_n622PrdDelData[0];
            A623PrdDelHora = T000S3_A623PrdDelHora[0];
            n623PrdDelHora = T000S3_n623PrdDelHora[0];
            A624PrdDelUsuId = T000S3_A624PrdDelUsuId[0];
            n624PrdDelUsuId = T000S3_n624PrdDelUsuId[0];
            A625PrdDelUsuNome = T000S3_A625PrdDelUsuNome[0];
            n625PrdDelUsuNome = T000S3_n625PrdDelUsuNome[0];
            A221PrdCodigo = T000S3_A221PrdCodigo[0];
            AssignAttri("", false, "A221PrdCodigo", A221PrdCodigo);
            A222PrdNome = T000S3_A222PrdNome[0];
            AssignAttri("", false, "A222PrdNome", A222PrdNome);
            A223PrdInsData = T000S3_A223PrdInsData[0];
            AssignAttri("", false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
            A224PrdInsHora = T000S3_A224PrdInsHora[0];
            AssignAttri("", false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
            A225PrdInsDataHora = T000S3_A225PrdInsDataHora[0];
            AssignAttri("", false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A226PrdInsUsuID = T000S3_A226PrdInsUsuID[0];
            n226PrdInsUsuID = T000S3_n226PrdInsUsuID[0];
            AssignAttri("", false, "A226PrdInsUsuID", A226PrdInsUsuID);
            A227PrdUpdData = T000S3_A227PrdUpdData[0];
            n227PrdUpdData = T000S3_n227PrdUpdData[0];
            AssignAttri("", false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
            A228PrdUpdHora = T000S3_A228PrdUpdHora[0];
            n228PrdUpdHora = T000S3_n228PrdUpdHora[0];
            AssignAttri("", false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
            A229PrdUpdDataHora = T000S3_A229PrdUpdDataHora[0];
            n229PrdUpdDataHora = T000S3_n229PrdUpdDataHora[0];
            AssignAttri("", false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A230PrdUpdUsuID = T000S3_A230PrdUpdUsuID[0];
            n230PrdUpdUsuID = T000S3_n230PrdUpdUsuID[0];
            AssignAttri("", false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
            A231PrdAtivo = T000S3_A231PrdAtivo[0];
            AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
            A620PrdDel = T000S3_A620PrdDel[0];
            A232PrdTipoID = T000S3_A232PrdTipoID[0];
            AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
            O620PrdDel = A620PrdDel;
            AssignAttri("", false, "A620PrdDel", A620PrdDel);
            Z220PrdID = A220PrdID;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0S28( ) ;
            if ( AnyError == 1 )
            {
               RcdFound28 = 0;
               InitializeNonKey0S28( ) ;
            }
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound28 = 0;
            InitializeNonKey0S28( ) ;
            sMode28 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode28;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0S28( ) ;
         if ( RcdFound28 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound28 = 0;
         /* Using cursor T000S9 */
         pr_default.execute(7, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000S9_A220PrdID[0], A220PrdID, 0) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T000S9_A220PrdID[0], A220PrdID, 0) > 0 ) ) )
            {
               A220PrdID = T000S9_A220PrdID[0];
               AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
               RcdFound28 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound28 = 0;
         /* Using cursor T000S10 */
         pr_default.execute(8, new Object[] {A220PrdID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000S10_A220PrdID[0], A220PrdID, 0) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T000S10_A220PrdID[0], A220PrdID, 0) < 0 ) ) )
            {
               A220PrdID = T000S10_A220PrdID[0];
               AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
               RcdFound28 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0S28( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtPrdCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0S28( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound28 == 1 )
            {
               if ( A220PrdID != Z220PrdID )
               {
                  A220PrdID = Z220PrdID;
                  AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "PRDID");
                  AnyError = 1;
                  GX_FocusControl = edtPrdID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtPrdCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0S28( ) ;
                  GX_FocusControl = edtPrdCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A220PrdID != Z220PrdID )
               {
                  /* Insert record */
                  GX_FocusControl = edtPrdCodigo_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0S28( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "PRDID");
                     AnyError = 1;
                     GX_FocusControl = edtPrdID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtPrdCodigo_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0S28( ) ;
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
         if ( A220PrdID != Z220PrdID )
         {
            A220PrdID = Z220PrdID;
            AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "PRDID");
            AnyError = 1;
            GX_FocusControl = edtPrdID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtPrdCodigo_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0S28( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000S2 */
            pr_default.execute(0, new Object[] {A220PrdID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produto"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z621PrdDelDataHora != T000S2_A621PrdDelDataHora[0] ) || ( Z622PrdDelData != T000S2_A622PrdDelData[0] ) || ( Z623PrdDelHora != T000S2_A623PrdDelHora[0] ) || ( StringUtil.StrCmp(Z624PrdDelUsuId, T000S2_A624PrdDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z625PrdDelUsuNome, T000S2_A625PrdDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z221PrdCodigo, T000S2_A221PrdCodigo[0]) != 0 ) || ( StringUtil.StrCmp(Z222PrdNome, T000S2_A222PrdNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z223PrdInsData ) != DateTimeUtil.ResetTime ( T000S2_A223PrdInsData[0] ) ) || ( Z224PrdInsHora != T000S2_A224PrdInsHora[0] ) || ( Z225PrdInsDataHora != T000S2_A225PrdInsDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z226PrdInsUsuID, T000S2_A226PrdInsUsuID[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z227PrdUpdData ) != DateTimeUtil.ResetTime ( T000S2_A227PrdUpdData[0] ) ) || ( Z228PrdUpdHora != T000S2_A228PrdUpdHora[0] ) || ( Z229PrdUpdDataHora != T000S2_A229PrdUpdDataHora[0] ) || ( StringUtil.StrCmp(Z230PrdUpdUsuID, T000S2_A230PrdUpdUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z231PrdAtivo != T000S2_A231PrdAtivo[0] ) || ( Z620PrdDel != T000S2_A620PrdDel[0] ) || ( Z232PrdTipoID != T000S2_A232PrdTipoID[0] ) )
            {
               if ( Z621PrdDelDataHora != T000S2_A621PrdDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z621PrdDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A621PrdDelDataHora[0]);
               }
               if ( Z622PrdDelData != T000S2_A622PrdDelData[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDelData");
                  GXUtil.WriteLogRaw("Old: ",Z622PrdDelData);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A622PrdDelData[0]);
               }
               if ( Z623PrdDelHora != T000S2_A623PrdDelHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z623PrdDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A623PrdDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z624PrdDelUsuId, T000S2_A624PrdDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z624PrdDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A624PrdDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z625PrdDelUsuNome, T000S2_A625PrdDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z625PrdDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A625PrdDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z221PrdCodigo, T000S2_A221PrdCodigo[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdCodigo");
                  GXUtil.WriteLogRaw("Old: ",Z221PrdCodigo);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A221PrdCodigo[0]);
               }
               if ( StringUtil.StrCmp(Z222PrdNome, T000S2_A222PrdNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdNome");
                  GXUtil.WriteLogRaw("Old: ",Z222PrdNome);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A222PrdNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z223PrdInsData ) != DateTimeUtil.ResetTime ( T000S2_A223PrdInsData[0] ) )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdInsData");
                  GXUtil.WriteLogRaw("Old: ",Z223PrdInsData);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A223PrdInsData[0]);
               }
               if ( Z224PrdInsHora != T000S2_A224PrdInsHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z224PrdInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A224PrdInsHora[0]);
               }
               if ( Z225PrdInsDataHora != T000S2_A225PrdInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z225PrdInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A225PrdInsDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z226PrdInsUsuID, T000S2_A226PrdInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z226PrdInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A226PrdInsUsuID[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z227PrdUpdData ) != DateTimeUtil.ResetTime ( T000S2_A227PrdUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z227PrdUpdData);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A227PrdUpdData[0]);
               }
               if ( Z228PrdUpdHora != T000S2_A228PrdUpdHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z228PrdUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A228PrdUpdHora[0]);
               }
               if ( Z229PrdUpdDataHora != T000S2_A229PrdUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z229PrdUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A229PrdUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z230PrdUpdUsuID, T000S2_A230PrdUpdUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdUpdUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z230PrdUpdUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A230PrdUpdUsuID[0]);
               }
               if ( Z231PrdAtivo != T000S2_A231PrdAtivo[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z231PrdAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A231PrdAtivo[0]);
               }
               if ( Z620PrdDel != T000S2_A620PrdDel[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdDel");
                  GXUtil.WriteLogRaw("Old: ",Z620PrdDel);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A620PrdDel[0]);
               }
               if ( Z232PrdTipoID != T000S2_A232PrdTipoID[0] )
               {
                  GXUtil.WriteLog("core.produto:[seudo value changed for attri]"+"PrdTipoID");
                  GXUtil.WriteLogRaw("Old: ",Z232PrdTipoID);
                  GXUtil.WriteLogRaw("Current: ",T000S2_A232PrdTipoID[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_produto"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0S28( )
      {
         if ( ! IsAuthorized("produto_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0S28( 0) ;
            CheckOptimisticConcurrency0S28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0S28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S11 */
                     pr_default.execute(9, new Object[] {A220PrdID, n621PrdDelDataHora, A621PrdDelDataHora, n622PrdDelData, A622PrdDelData, n623PrdDelHora, A623PrdDelHora, n624PrdDelUsuId, A624PrdDelUsuId, n625PrdDelUsuNome, A625PrdDelUsuNome, A221PrdCodigo, A222PrdNome, A223PrdInsData, A224PrdInsHora, A225PrdInsDataHora, n226PrdInsUsuID, A226PrdInsUsuID, n227PrdUpdData, A227PrdUpdData, n228PrdUpdHora, A228PrdUpdHora, n229PrdUpdDataHora, A229PrdUpdDataHora, n230PrdUpdUsuID, A230PrdUpdUsuID, A231PrdAtivo, A620PrdDel, A232PrdTipoID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produto");
                     if ( (pr_default.getStatus(9) == 1) )
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
            else
            {
               Load0S28( ) ;
            }
            EndLevel0S28( ) ;
         }
         CloseExtendedTableCursors0S28( ) ;
      }

      protected void Update0S28( )
      {
         if ( ! IsAuthorized("produto_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S28( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0S28( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0S28( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000S12 */
                     pr_default.execute(10, new Object[] {n621PrdDelDataHora, A621PrdDelDataHora, n622PrdDelData, A622PrdDelData, n623PrdDelHora, A623PrdDelHora, n624PrdDelUsuId, A624PrdDelUsuId, n625PrdDelUsuNome, A625PrdDelUsuNome, A221PrdCodigo, A222PrdNome, A223PrdInsData, A224PrdInsHora, A225PrdInsDataHora, n226PrdInsUsuID, A226PrdInsUsuID, n227PrdUpdData, A227PrdUpdData, n228PrdUpdHora, A228PrdUpdHora, n229PrdUpdDataHora, A229PrdUpdDataHora, n230PrdUpdUsuID, A230PrdUpdUsuID, A231PrdAtivo, A620PrdDel, A232PrdTipoID, A220PrdID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_produto");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_produto"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0S28( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_produtoupdateredundancy(context ).execute( ref  A220PrdID) ;
                        AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
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
            EndLevel0S28( ) ;
         }
         CloseExtendedTableCursors0S28( ) ;
      }

      protected void DeferredUpdate0S28( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("produto_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0S28( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0S28( ) ;
            AfterConfirm0S28( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0S28( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000S13 */
                  pr_default.execute(11, new Object[] {A220PrdID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("tb_produto");
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
         sMode28 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0S28( ) ;
         Gx_mode = sMode28;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0S28( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000S14 */
            pr_default.execute(12, new Object[] {A232PrdTipoID});
            A233PrdTipoSigla = T000S14_A233PrdTipoSigla[0];
            AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
            A234PrdTipoNome = T000S14_A234PrdTipoNome[0];
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000S15 */
            pr_default.execute(13, new Object[] {A220PrdID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel0S28( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0S28( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.produto",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0S0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.produto",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0S28( )
      {
         /* Scan By routine */
         /* Using cursor T000S16 */
         pr_default.execute(14);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound28 = 1;
            A220PrdID = T000S16_A220PrdID[0];
            AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0S28( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound28 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound28 = 1;
            A220PrdID = T000S16_A220PrdID[0];
            AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
         }
      }

      protected void ScanEnd0S28( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm0S28( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0S28( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0S28( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A621PrdDelDataHora = DateTimeUtil.NowMS( context);
            n621PrdDelDataHora = false;
            AssignAttri("", false, "A621PrdDelDataHora", context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A624PrdDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n624PrdDelUsuId = false;
            AssignAttri("", false, "A624PrdDelUsuId", A624PrdDelUsuId);
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A625PrdDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n625PrdDelUsuNome = false;
            AssignAttri("", false, "A625PrdDelUsuNome", A625PrdDelUsuNome);
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A622PrdDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A621PrdDelDataHora) ) ;
            n622PrdDelData = false;
            AssignAttri("", false, "A622PrdDelData", context.localUtil.TToC( A622PrdDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A620PrdDel && ( O620PrdDel != A620PrdDel ) )
         {
            A623PrdDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A621PrdDelDataHora));
            n623PrdDelHora = false;
            AssignAttri("", false, "A623PrdDelHora", context.localUtil.TToC( A623PrdDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0S28( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
      }

      protected void BeforeComplete0S28( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0S28( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0S28( )
      {
         edtPrdCodigo_Enabled = 0;
         AssignProp("", false, edtPrdCodigo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdCodigo_Enabled), 5, 0), true);
         edtPrdNome_Enabled = 0;
         AssignProp("", false, edtPrdNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdNome_Enabled), 5, 0), true);
         edtPrdTipoID_Enabled = 0;
         AssignProp("", false, edtPrdTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoID_Enabled), 5, 0), true);
         edtavComboprdtipoid_Enabled = 0;
         AssignProp("", false, edtavComboprdtipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavComboprdtipoid_Enabled), 5, 0), true);
         edtPrdID_Enabled = 0;
         AssignProp("", false, edtPrdID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdID_Enabled), 5, 0), true);
         edtPrdInsData_Enabled = 0;
         AssignProp("", false, edtPrdInsData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdInsData_Enabled), 5, 0), true);
         edtPrdInsHora_Enabled = 0;
         AssignProp("", false, edtPrdInsHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdInsHora_Enabled), 5, 0), true);
         edtPrdInsDataHora_Enabled = 0;
         AssignProp("", false, edtPrdInsDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdInsDataHora_Enabled), 5, 0), true);
         edtPrdInsUsuID_Enabled = 0;
         AssignProp("", false, edtPrdInsUsuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdInsUsuID_Enabled), 5, 0), true);
         edtPrdUpdData_Enabled = 0;
         AssignProp("", false, edtPrdUpdData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdUpdData_Enabled), 5, 0), true);
         edtPrdUpdHora_Enabled = 0;
         AssignProp("", false, edtPrdUpdHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdUpdHora_Enabled), 5, 0), true);
         edtPrdUpdDataHora_Enabled = 0;
         AssignProp("", false, edtPrdUpdDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdUpdDataHora_Enabled), 5, 0), true);
         edtPrdUpdUsuID_Enabled = 0;
         AssignProp("", false, edtPrdUpdUsuID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdUpdUsuID_Enabled), 5, 0), true);
         edtPrdAtivo_Enabled = 0;
         AssignProp("", false, edtPrdAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdAtivo_Enabled), 5, 0), true);
         edtPrdTipoSigla_Enabled = 0;
         AssignProp("", false, edtPrdTipoSigla_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtPrdTipoSigla_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0S28( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0S0( )
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
         GXEncryptionTmp = "core.produto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7PrdID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.produto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Produto");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV25Pgmname, "")));
         forbiddenHiddens.Add("PrdDel", StringUtil.BoolToStr( A620PrdDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\produto:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z220PrdID", Z220PrdID.ToString());
         GxWebStd.gx_hidden_field( context, "Z621PrdDelDataHora", context.localUtil.TToC( Z621PrdDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z622PrdDelData", context.localUtil.TToC( Z622PrdDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z623PrdDelHora", context.localUtil.TToC( Z623PrdDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z624PrdDelUsuId", StringUtil.RTrim( Z624PrdDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z625PrdDelUsuNome", Z625PrdDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z221PrdCodigo", Z221PrdCodigo);
         GxWebStd.gx_hidden_field( context, "Z222PrdNome", Z222PrdNome);
         GxWebStd.gx_hidden_field( context, "Z223PrdInsData", context.localUtil.DToC( Z223PrdInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z224PrdInsHora", context.localUtil.TToC( Z224PrdInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z225PrdInsDataHora", context.localUtil.TToC( Z225PrdInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z226PrdInsUsuID", StringUtil.RTrim( Z226PrdInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z227PrdUpdData", context.localUtil.DToC( Z227PrdUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z228PrdUpdHora", context.localUtil.TToC( Z228PrdUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z229PrdUpdDataHora", context.localUtil.TToC( Z229PrdUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z230PrdUpdUsuID", StringUtil.RTrim( Z230PrdUpdUsuID));
         GxWebStd.gx_boolean_hidden_field( context, "Z231PrdAtivo", Z231PrdAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z620PrdDel", Z620PrdDel);
         GxWebStd.gx_hidden_field( context, "Z232PrdTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z232PrdTipoID), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "O620PrdDel", O620PrdDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N232PrdTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A232PrdTipoID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDDO_TITLESETTINGSICONS", AV16DDO_TitleSettingsIcons);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vPRDTIPOID_DATA", AV15PrdTipoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vPRDTIPOID_DATA", AV15PrdTipoID_Data);
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
         GxWebStd.gx_hidden_field( context, "vPRDID", AV7PrdID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vPRDID", GetSecureSignedToken( "", AV7PrdID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vINSERT_PRDTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV13Insert_PrdTipoID), 9, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "PRDDEL", A620PrdDel);
         GxWebStd.gx_hidden_field( context, "PRDDELDATAHORA", context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRDDELDATA", context.localUtil.TToC( A622PrdDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRDDELHORA", context.localUtil.TToC( A623PrdDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "PRDDELUSUID", StringUtil.RTrim( A624PrdDelUsuId));
         GxWebStd.gx_hidden_field( context, "PRDDELUSUNOME", A625PrdDelUsuNome);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV24AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV24AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "PRDTIPONOME", A234PrdTipoNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV25Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Objectcall", StringUtil.RTrim( Combo_prdtipoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Cls", StringUtil.RTrim( Combo_prdtipoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Selectedvalue_set", StringUtil.RTrim( Combo_prdtipoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Selectedtext_set", StringUtil.RTrim( Combo_prdtipoid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Gamoauthtoken", StringUtil.RTrim( Combo_prdtipoid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Enabled", StringUtil.BoolToStr( Combo_prdtipoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Datalistproc", StringUtil.RTrim( Combo_prdtipoid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_prdtipoid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_PRDTIPOID_Emptyitem", StringUtil.BoolToStr( Combo_prdtipoid_Emptyitem));
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
         GXEncryptionTmp = "core.produto.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7PrdID.ToString());
         return formatLink("core.produto.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Produto" ;
      }

      public override string GetPgmdesc( )
      {
         return "Produto ou Serviço" ;
      }

      protected void InitializeNonKey0S28( )
      {
         A232PrdTipoID = 0;
         AssignAttri("", false, "A232PrdTipoID", StringUtil.LTrimStr( (decimal)(A232PrdTipoID), 9, 0));
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         n621PrdDelDataHora = false;
         AssignAttri("", false, "A621PrdDelDataHora", context.localUtil.TToC( A621PrdDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         n622PrdDelData = false;
         AssignAttri("", false, "A622PrdDelData", context.localUtil.TToC( A622PrdDelData, 10, 5, 0, 3, "/", ":", " "));
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         n623PrdDelHora = false;
         AssignAttri("", false, "A623PrdDelHora", context.localUtil.TToC( A623PrdDelHora, 0, 5, 0, 3, "/", ":", " "));
         A624PrdDelUsuId = "";
         n624PrdDelUsuId = false;
         AssignAttri("", false, "A624PrdDelUsuId", A624PrdDelUsuId);
         A625PrdDelUsuNome = "";
         n625PrdDelUsuNome = false;
         AssignAttri("", false, "A625PrdDelUsuNome", A625PrdDelUsuNome);
         A221PrdCodigo = "";
         AssignAttri("", false, "A221PrdCodigo", A221PrdCodigo);
         A222PrdNome = "";
         AssignAttri("", false, "A222PrdNome", A222PrdNome);
         A223PrdInsData = DateTime.MinValue;
         AssignAttri("", false, "A223PrdInsData", context.localUtil.Format(A223PrdInsData, "99/99/99"));
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A224PrdInsHora", context.localUtil.TToC( A224PrdInsHora, 0, 5, 0, 3, "/", ":", " "));
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A225PrdInsDataHora", context.localUtil.TToC( A225PrdInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A226PrdInsUsuID = "";
         n226PrdInsUsuID = false;
         AssignAttri("", false, "A226PrdInsUsuID", A226PrdInsUsuID);
         n226PrdInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A226PrdInsUsuID)) ? true : false);
         A227PrdUpdData = DateTime.MinValue;
         n227PrdUpdData = false;
         AssignAttri("", false, "A227PrdUpdData", context.localUtil.Format(A227PrdUpdData, "99/99/99"));
         n227PrdUpdData = ((DateTime.MinValue==A227PrdUpdData) ? true : false);
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         n228PrdUpdHora = false;
         AssignAttri("", false, "A228PrdUpdHora", context.localUtil.TToC( A228PrdUpdHora, 0, 5, 0, 3, "/", ":", " "));
         n228PrdUpdHora = ((DateTime.MinValue==A228PrdUpdHora) ? true : false);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         n229PrdUpdDataHora = false;
         AssignAttri("", false, "A229PrdUpdDataHora", context.localUtil.TToC( A229PrdUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         n229PrdUpdDataHora = ((DateTime.MinValue==A229PrdUpdDataHora) ? true : false);
         A230PrdUpdUsuID = "";
         n230PrdUpdUsuID = false;
         AssignAttri("", false, "A230PrdUpdUsuID", A230PrdUpdUsuID);
         n230PrdUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A230PrdUpdUsuID)) ? true : false);
         A233PrdTipoSigla = "";
         AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
         A234PrdTipoNome = "";
         AssignAttri("", false, "A234PrdTipoNome", A234PrdTipoNome);
         A620PrdDel = false;
         AssignAttri("", false, "A620PrdDel", A620PrdDel);
         A231PrdAtivo = true;
         AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
         O620PrdDel = A620PrdDel;
         AssignAttri("", false, "A620PrdDel", A620PrdDel);
         Z621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         Z622PrdDelData = (DateTime)(DateTime.MinValue);
         Z623PrdDelHora = (DateTime)(DateTime.MinValue);
         Z624PrdDelUsuId = "";
         Z625PrdDelUsuNome = "";
         Z221PrdCodigo = "";
         Z222PrdNome = "";
         Z223PrdInsData = DateTime.MinValue;
         Z224PrdInsHora = (DateTime)(DateTime.MinValue);
         Z225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         Z226PrdInsUsuID = "";
         Z227PrdUpdData = DateTime.MinValue;
         Z228PrdUpdHora = (DateTime)(DateTime.MinValue);
         Z229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         Z230PrdUpdUsuID = "";
         Z231PrdAtivo = false;
         Z620PrdDel = false;
         Z232PrdTipoID = 0;
      }

      protected void InitAll0S28( )
      {
         A220PrdID = Guid.NewGuid( );
         AssignAttri("", false, "A220PrdID", A220PrdID.ToString());
         InitializeNonKey0S28( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A231PrdAtivo = i231PrdAtivo;
         AssignAttri("", false, "A231PrdAtivo", A231PrdAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828135290", true, true);
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
         context.AddJavascriptSource("core/produto.js", "?2023828135292", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtPrdCodigo_Internalname = "PRDCODIGO";
         edtPrdNome_Internalname = "PRDNOME";
         lblTextblockprdtipoid_Internalname = "TEXTBLOCKPRDTIPOID";
         Combo_prdtipoid_Internalname = "COMBO_PRDTIPOID";
         edtPrdTipoID_Internalname = "PRDTIPOID";
         divTablesplittedprdtipoid_Internalname = "TABLESPLITTEDPRDTIPOID";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavComboprdtipoid_Internalname = "vCOMBOPRDTIPOID";
         divSectionattribute_prdtipoid_Internalname = "SECTIONATTRIBUTE_PRDTIPOID";
         edtPrdID_Internalname = "PRDID";
         edtPrdInsData_Internalname = "PRDINSDATA";
         edtPrdInsHora_Internalname = "PRDINSHORA";
         edtPrdInsDataHora_Internalname = "PRDINSDATAHORA";
         edtPrdInsUsuID_Internalname = "PRDINSUSUID";
         edtPrdUpdData_Internalname = "PRDUPDDATA";
         edtPrdUpdHora_Internalname = "PRDUPDHORA";
         edtPrdUpdDataHora_Internalname = "PRDUPDDATAHORA";
         edtPrdUpdUsuID_Internalname = "PRDUPDUSUID";
         edtPrdAtivo_Internalname = "PRDATIVO";
         edtPrdTipoSigla_Internalname = "PRDTIPOSIGLA";
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
         Form.Caption = "Produto ou Serviço";
         edtPrdTipoSigla_Jsonclick = "";
         edtPrdTipoSigla_Enabled = 0;
         edtPrdTipoSigla_Visible = 1;
         edtPrdAtivo_Jsonclick = "";
         edtPrdAtivo_Enabled = 1;
         edtPrdAtivo_Visible = 1;
         edtPrdUpdUsuID_Jsonclick = "";
         edtPrdUpdUsuID_Enabled = 1;
         edtPrdUpdUsuID_Visible = 1;
         edtPrdUpdDataHora_Jsonclick = "";
         edtPrdUpdDataHora_Enabled = 1;
         edtPrdUpdDataHora_Visible = 1;
         edtPrdUpdHora_Jsonclick = "";
         edtPrdUpdHora_Enabled = 1;
         edtPrdUpdHora_Visible = 1;
         edtPrdUpdData_Jsonclick = "";
         edtPrdUpdData_Enabled = 1;
         edtPrdUpdData_Visible = 1;
         edtPrdInsUsuID_Jsonclick = "";
         edtPrdInsUsuID_Enabled = 1;
         edtPrdInsUsuID_Visible = 1;
         edtPrdInsDataHora_Jsonclick = "";
         edtPrdInsDataHora_Enabled = 1;
         edtPrdInsDataHora_Visible = 1;
         edtPrdInsHora_Jsonclick = "";
         edtPrdInsHora_Enabled = 1;
         edtPrdInsHora_Visible = 1;
         edtPrdInsData_Jsonclick = "";
         edtPrdInsData_Enabled = 1;
         edtPrdInsData_Visible = 1;
         edtPrdID_Jsonclick = "";
         edtPrdID_Enabled = 1;
         edtPrdID_Visible = 1;
         edtavComboprdtipoid_Jsonclick = "";
         edtavComboprdtipoid_Enabled = 0;
         edtavComboprdtipoid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtPrdTipoID_Jsonclick = "";
         edtPrdTipoID_Enabled = 1;
         edtPrdTipoID_Visible = 1;
         Combo_prdtipoid_Emptyitem = Convert.ToBoolean( 0);
         Combo_prdtipoid_Datalistprocparametersprefix = " \"ComboName\": \"PrdTipoID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"PrdID\": \"00000000-0000-0000-0000-000000000000\"";
         Combo_prdtipoid_Datalistproc = "core.ProdutoLoadDVCombo";
         Combo_prdtipoid_Cls = "ExtendedCombo AttributeFL";
         Combo_prdtipoid_Caption = "";
         Combo_prdtipoid_Enabled = Convert.ToBoolean( -1);
         edtPrdNome_Jsonclick = "";
         edtPrdNome_Enabled = 1;
         edtPrdCodigo_Jsonclick = "";
         edtPrdCodigo_Enabled = 1;
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

      protected void XC_16_0S28( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ,
                                 Guid A220PrdID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV24AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_17_0S28( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ,
                                 Guid A220PrdID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditproduto(context ).execute(  "Y", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV24AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_18_0S28( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ,
                                 Guid A220PrdID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV24AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_19_0S28( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ,
                                 Guid A220PrdID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditproduto(context ).execute(  "N", ref  AV24AuditingObject,  A220PrdID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV24AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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

      public void Valid_Prdcodigo( )
      {
         /* Using cursor T000S17 */
         pr_default.execute(15, new Object[] {A221PrdCodigo, A220PrdID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Código"}), 1, "PRDCODIGO");
            AnyError = 1;
            GX_FocusControl = edtPrdCodigo_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Prdtipoid( )
      {
         /* Using cursor T000S14 */
         pr_default.execute(12, new Object[] {A232PrdTipoID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Tipo Produto -> Produto'.", "ForeignKeyNotFound", 1, "PRDTIPOID");
            AnyError = 1;
            GX_FocusControl = edtPrdTipoID_Internalname;
         }
         A233PrdTipoSigla = T000S14_A233PrdTipoSigla[0];
         A234PrdTipoNome = T000S14_A234PrdTipoNome[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A233PrdTipoSigla", A233PrdTipoSigla);
         AssignAttri("", false, "A234PrdTipoNome", A234PrdTipoNome);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7PrdID',fld:'vPRDID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7PrdID',fld:'vPRDID',pic:'',hsh:true},{av:'AV25Pgmname',fld:'vPGMNAME',pic:''},{av:'A620PrdDel',fld:'PRDDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120S2',iparms:[{av:'AV24AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV25Pgmname',fld:'vPGMNAME',pic:''},{av:'A220PrdID',fld:'PRDID',pic:''},{av:'A221PrdCodigo',fld:'PRDCODIGO',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_PRDCODIGO","{handler:'Valid_Prdcodigo',iparms:[{av:'A221PrdCodigo',fld:'PRDCODIGO',pic:''},{av:'A220PrdID',fld:'PRDID',pic:''}]");
         setEventMetadata("VALID_PRDCODIGO",",oparms:[]}");
         setEventMetadata("VALID_PRDTIPOID","{handler:'Valid_Prdtipoid',iparms:[{av:'A232PrdTipoID',fld:'PRDTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A233PrdTipoSigla',fld:'PRDTIPOSIGLA',pic:''},{av:'A234PrdTipoNome',fld:'PRDTIPONOME',pic:'@!'}]");
         setEventMetadata("VALID_PRDTIPOID",",oparms:[{av:'A233PrdTipoSigla',fld:'PRDTIPOSIGLA',pic:''},{av:'A234PrdTipoNome',fld:'PRDTIPONOME',pic:'@!'}]}");
         setEventMetadata("VALIDV_COMBOPRDTIPOID","{handler:'Validv_Comboprdtipoid',iparms:[]");
         setEventMetadata("VALIDV_COMBOPRDTIPOID",",oparms:[]}");
         setEventMetadata("VALID_PRDID","{handler:'Valid_Prdid',iparms:[]");
         setEventMetadata("VALID_PRDID",",oparms:[]}");
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
         pr_default.close(12);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7PrdID = Guid.Empty;
         Z220PrdID = Guid.Empty;
         Z621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         Z622PrdDelData = (DateTime)(DateTime.MinValue);
         Z623PrdDelHora = (DateTime)(DateTime.MinValue);
         Z624PrdDelUsuId = "";
         Z625PrdDelUsuNome = "";
         Z221PrdCodigo = "";
         Z222PrdNome = "";
         Z223PrdInsData = DateTime.MinValue;
         Z224PrdInsHora = (DateTime)(DateTime.MinValue);
         Z225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         Z226PrdInsUsuID = "";
         Z227PrdUpdData = DateTime.MinValue;
         Z228PrdUpdHora = (DateTime)(DateTime.MinValue);
         Z229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         Z230PrdUpdUsuID = "";
         Combo_prdtipoid_Selectedvalue_get = "";
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
         A221PrdCodigo = "";
         A222PrdNome = "";
         lblTextblockprdtipoid_Jsonclick = "";
         ucCombo_prdtipoid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15PrdTipoID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A220PrdID = Guid.Empty;
         A223PrdInsData = DateTime.MinValue;
         A224PrdInsHora = (DateTime)(DateTime.MinValue);
         A225PrdInsDataHora = (DateTime)(DateTime.MinValue);
         A226PrdInsUsuID = "";
         A227PrdUpdData = DateTime.MinValue;
         A228PrdUpdHora = (DateTime)(DateTime.MinValue);
         A229PrdUpdDataHora = (DateTime)(DateTime.MinValue);
         A230PrdUpdUsuID = "";
         A233PrdTipoSigla = "";
         A621PrdDelDataHora = (DateTime)(DateTime.MinValue);
         A622PrdDelData = (DateTime)(DateTime.MinValue);
         A623PrdDelHora = (DateTime)(DateTime.MinValue);
         A624PrdDelUsuId = "";
         A625PrdDelUsuNome = "";
         AV24AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A234PrdTipoNome = "";
         AV25Pgmname = "";
         Combo_prdtipoid_Objectcall = "";
         Combo_prdtipoid_Class = "";
         Combo_prdtipoid_Icontype = "";
         Combo_prdtipoid_Icon = "";
         Combo_prdtipoid_Tooltip = "";
         Combo_prdtipoid_Selectedvalue_set = "";
         Combo_prdtipoid_Selectedtext_set = "";
         Combo_prdtipoid_Selectedtext_get = "";
         Combo_prdtipoid_Gamoauthtoken = "";
         Combo_prdtipoid_Ddointernalname = "";
         Combo_prdtipoid_Titlecontrolalign = "";
         Combo_prdtipoid_Dropdownoptionstype = "";
         Combo_prdtipoid_Titlecontrolidtoreplace = "";
         Combo_prdtipoid_Datalisttype = "";
         Combo_prdtipoid_Datalistfixedvalues = "";
         Combo_prdtipoid_Remoteservicesparameters = "";
         Combo_prdtipoid_Htmltemplate = "";
         Combo_prdtipoid_Multiplevaluestype = "";
         Combo_prdtipoid_Loadingdata = "";
         Combo_prdtipoid_Noresultsfound = "";
         Combo_prdtipoid_Emptyitemtext = "";
         Combo_prdtipoid_Onlyselectedvalues = "";
         Combo_prdtipoid_Selectalltext = "";
         Combo_prdtipoid_Multiplevaluesseparator = "";
         Combo_prdtipoid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode28 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV22GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV23GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV19Combo_DataJson = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         GXt_char2 = "";
         Z233PrdTipoSigla = "";
         Z234PrdTipoNome = "";
         T000S4_A233PrdTipoSigla = new string[] {""} ;
         T000S4_A234PrdTipoNome = new string[] {""} ;
         T000S5_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S5_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_n621PrdDelDataHora = new bool[] {false} ;
         T000S5_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         T000S5_n622PrdDelData = new bool[] {false} ;
         T000S5_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_n623PrdDelHora = new bool[] {false} ;
         T000S5_A624PrdDelUsuId = new string[] {""} ;
         T000S5_n624PrdDelUsuId = new bool[] {false} ;
         T000S5_A625PrdDelUsuNome = new string[] {""} ;
         T000S5_n625PrdDelUsuNome = new bool[] {false} ;
         T000S5_A221PrdCodigo = new string[] {""} ;
         T000S5_A222PrdNome = new string[] {""} ;
         T000S5_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         T000S5_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_A226PrdInsUsuID = new string[] {""} ;
         T000S5_n226PrdInsUsuID = new bool[] {false} ;
         T000S5_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         T000S5_n227PrdUpdData = new bool[] {false} ;
         T000S5_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_n228PrdUpdHora = new bool[] {false} ;
         T000S5_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S5_n229PrdUpdDataHora = new bool[] {false} ;
         T000S5_A230PrdUpdUsuID = new string[] {""} ;
         T000S5_n230PrdUpdUsuID = new bool[] {false} ;
         T000S5_A231PrdAtivo = new bool[] {false} ;
         T000S5_A233PrdTipoSigla = new string[] {""} ;
         T000S5_A234PrdTipoNome = new string[] {""} ;
         T000S5_A620PrdDel = new bool[] {false} ;
         T000S5_A232PrdTipoID = new int[1] ;
         T000S6_A221PrdCodigo = new string[] {""} ;
         T000S7_A233PrdTipoSigla = new string[] {""} ;
         T000S7_A234PrdTipoNome = new string[] {""} ;
         T000S8_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S3_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S3_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_n621PrdDelDataHora = new bool[] {false} ;
         T000S3_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         T000S3_n622PrdDelData = new bool[] {false} ;
         T000S3_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_n623PrdDelHora = new bool[] {false} ;
         T000S3_A624PrdDelUsuId = new string[] {""} ;
         T000S3_n624PrdDelUsuId = new bool[] {false} ;
         T000S3_A625PrdDelUsuNome = new string[] {""} ;
         T000S3_n625PrdDelUsuNome = new bool[] {false} ;
         T000S3_A221PrdCodigo = new string[] {""} ;
         T000S3_A222PrdNome = new string[] {""} ;
         T000S3_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         T000S3_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_A226PrdInsUsuID = new string[] {""} ;
         T000S3_n226PrdInsUsuID = new bool[] {false} ;
         T000S3_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         T000S3_n227PrdUpdData = new bool[] {false} ;
         T000S3_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_n228PrdUpdHora = new bool[] {false} ;
         T000S3_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S3_n229PrdUpdDataHora = new bool[] {false} ;
         T000S3_A230PrdUpdUsuID = new string[] {""} ;
         T000S3_n230PrdUpdUsuID = new bool[] {false} ;
         T000S3_A231PrdAtivo = new bool[] {false} ;
         T000S3_A620PrdDel = new bool[] {false} ;
         T000S3_A232PrdTipoID = new int[1] ;
         T000S9_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S10_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S2_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S2_A621PrdDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_n621PrdDelDataHora = new bool[] {false} ;
         T000S2_A622PrdDelData = new DateTime[] {DateTime.MinValue} ;
         T000S2_n622PrdDelData = new bool[] {false} ;
         T000S2_A623PrdDelHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_n623PrdDelHora = new bool[] {false} ;
         T000S2_A624PrdDelUsuId = new string[] {""} ;
         T000S2_n624PrdDelUsuId = new bool[] {false} ;
         T000S2_A625PrdDelUsuNome = new string[] {""} ;
         T000S2_n625PrdDelUsuNome = new bool[] {false} ;
         T000S2_A221PrdCodigo = new string[] {""} ;
         T000S2_A222PrdNome = new string[] {""} ;
         T000S2_A223PrdInsData = new DateTime[] {DateTime.MinValue} ;
         T000S2_A224PrdInsHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_A225PrdInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_A226PrdInsUsuID = new string[] {""} ;
         T000S2_n226PrdInsUsuID = new bool[] {false} ;
         T000S2_A227PrdUpdData = new DateTime[] {DateTime.MinValue} ;
         T000S2_n227PrdUpdData = new bool[] {false} ;
         T000S2_A228PrdUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_n228PrdUpdHora = new bool[] {false} ;
         T000S2_A229PrdUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000S2_n229PrdUpdDataHora = new bool[] {false} ;
         T000S2_A230PrdUpdUsuID = new string[] {""} ;
         T000S2_n230PrdUpdUsuID = new bool[] {false} ;
         T000S2_A231PrdAtivo = new bool[] {false} ;
         T000S2_A620PrdDel = new bool[] {false} ;
         T000S2_A232PrdTipoID = new int[1] ;
         T000S14_A233PrdTipoSigla = new string[] {""} ;
         T000S14_A234PrdTipoNome = new string[] {""} ;
         T000S15_A235TppID = new Guid[] {Guid.Empty} ;
         T000S15_A220PrdID = new Guid[] {Guid.Empty} ;
         T000S16_A220PrdID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000S17_A221PrdCodigo = new string[] {""} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.produto__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.produto__default(),
            new Object[][] {
                new Object[] {
               T000S2_A220PrdID, T000S2_A621PrdDelDataHora, T000S2_n621PrdDelDataHora, T000S2_A622PrdDelData, T000S2_n622PrdDelData, T000S2_A623PrdDelHora, T000S2_n623PrdDelHora, T000S2_A624PrdDelUsuId, T000S2_n624PrdDelUsuId, T000S2_A625PrdDelUsuNome,
               T000S2_n625PrdDelUsuNome, T000S2_A221PrdCodigo, T000S2_A222PrdNome, T000S2_A223PrdInsData, T000S2_A224PrdInsHora, T000S2_A225PrdInsDataHora, T000S2_A226PrdInsUsuID, T000S2_n226PrdInsUsuID, T000S2_A227PrdUpdData, T000S2_n227PrdUpdData,
               T000S2_A228PrdUpdHora, T000S2_n228PrdUpdHora, T000S2_A229PrdUpdDataHora, T000S2_n229PrdUpdDataHora, T000S2_A230PrdUpdUsuID, T000S2_n230PrdUpdUsuID, T000S2_A231PrdAtivo, T000S2_A620PrdDel, T000S2_A232PrdTipoID
               }
               , new Object[] {
               T000S3_A220PrdID, T000S3_A621PrdDelDataHora, T000S3_n621PrdDelDataHora, T000S3_A622PrdDelData, T000S3_n622PrdDelData, T000S3_A623PrdDelHora, T000S3_n623PrdDelHora, T000S3_A624PrdDelUsuId, T000S3_n624PrdDelUsuId, T000S3_A625PrdDelUsuNome,
               T000S3_n625PrdDelUsuNome, T000S3_A221PrdCodigo, T000S3_A222PrdNome, T000S3_A223PrdInsData, T000S3_A224PrdInsHora, T000S3_A225PrdInsDataHora, T000S3_A226PrdInsUsuID, T000S3_n226PrdInsUsuID, T000S3_A227PrdUpdData, T000S3_n227PrdUpdData,
               T000S3_A228PrdUpdHora, T000S3_n228PrdUpdHora, T000S3_A229PrdUpdDataHora, T000S3_n229PrdUpdDataHora, T000S3_A230PrdUpdUsuID, T000S3_n230PrdUpdUsuID, T000S3_A231PrdAtivo, T000S3_A620PrdDel, T000S3_A232PrdTipoID
               }
               , new Object[] {
               T000S4_A233PrdTipoSigla, T000S4_A234PrdTipoNome
               }
               , new Object[] {
               T000S5_A220PrdID, T000S5_A621PrdDelDataHora, T000S5_n621PrdDelDataHora, T000S5_A622PrdDelData, T000S5_n622PrdDelData, T000S5_A623PrdDelHora, T000S5_n623PrdDelHora, T000S5_A624PrdDelUsuId, T000S5_n624PrdDelUsuId, T000S5_A625PrdDelUsuNome,
               T000S5_n625PrdDelUsuNome, T000S5_A221PrdCodigo, T000S5_A222PrdNome, T000S5_A223PrdInsData, T000S5_A224PrdInsHora, T000S5_A225PrdInsDataHora, T000S5_A226PrdInsUsuID, T000S5_n226PrdInsUsuID, T000S5_A227PrdUpdData, T000S5_n227PrdUpdData,
               T000S5_A228PrdUpdHora, T000S5_n228PrdUpdHora, T000S5_A229PrdUpdDataHora, T000S5_n229PrdUpdDataHora, T000S5_A230PrdUpdUsuID, T000S5_n230PrdUpdUsuID, T000S5_A231PrdAtivo, T000S5_A233PrdTipoSigla, T000S5_A234PrdTipoNome, T000S5_A620PrdDel,
               T000S5_A232PrdTipoID
               }
               , new Object[] {
               T000S6_A221PrdCodigo
               }
               , new Object[] {
               T000S7_A233PrdTipoSigla, T000S7_A234PrdTipoNome
               }
               , new Object[] {
               T000S8_A220PrdID
               }
               , new Object[] {
               T000S9_A220PrdID
               }
               , new Object[] {
               T000S10_A220PrdID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000S14_A233PrdTipoSigla, T000S14_A234PrdTipoNome
               }
               , new Object[] {
               T000S15_A235TppID, T000S15_A220PrdID
               }
               , new Object[] {
               T000S16_A220PrdID
               }
               , new Object[] {
               T000S17_A221PrdCodigo
               }
            }
         );
         Z231PrdAtivo = true;
         A231PrdAtivo = true;
         i231PrdAtivo = true;
         Z220PrdID = Guid.NewGuid( );
         A220PrdID = Guid.NewGuid( );
         AV25Pgmname = "core.Produto";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound28 ;
      private short GX_JID ;
      private short nIsDirty_28 ;
      private short gxajaxcallmode ;
      private int Z232PrdTipoID ;
      private int N232PrdTipoID ;
      private int A232PrdTipoID ;
      private int trnEnded ;
      private int edtPrdCodigo_Enabled ;
      private int edtPrdNome_Enabled ;
      private int edtPrdTipoID_Visible ;
      private int edtPrdTipoID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV20ComboPrdTipoID ;
      private int edtavComboprdtipoid_Enabled ;
      private int edtavComboprdtipoid_Visible ;
      private int edtPrdID_Visible ;
      private int edtPrdID_Enabled ;
      private int edtPrdInsData_Visible ;
      private int edtPrdInsData_Enabled ;
      private int edtPrdInsHora_Visible ;
      private int edtPrdInsHora_Enabled ;
      private int edtPrdInsDataHora_Visible ;
      private int edtPrdInsDataHora_Enabled ;
      private int edtPrdInsUsuID_Visible ;
      private int edtPrdInsUsuID_Enabled ;
      private int edtPrdUpdData_Visible ;
      private int edtPrdUpdData_Enabled ;
      private int edtPrdUpdHora_Visible ;
      private int edtPrdUpdHora_Enabled ;
      private int edtPrdUpdDataHora_Visible ;
      private int edtPrdUpdDataHora_Enabled ;
      private int edtPrdUpdUsuID_Visible ;
      private int edtPrdUpdUsuID_Enabled ;
      private int edtPrdAtivo_Visible ;
      private int edtPrdAtivo_Enabled ;
      private int edtPrdTipoSigla_Visible ;
      private int edtPrdTipoSigla_Enabled ;
      private int AV13Insert_PrdTipoID ;
      private int Combo_prdtipoid_Datalistupdateminimumcharacters ;
      private int Combo_prdtipoid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV26GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z624PrdDelUsuId ;
      private string Z226PrdInsUsuID ;
      private string Z230PrdUpdUsuID ;
      private string Combo_prdtipoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtPrdCodigo_Internalname ;
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
      private string edtPrdCodigo_Jsonclick ;
      private string edtPrdNome_Internalname ;
      private string edtPrdNome_Jsonclick ;
      private string divTablesplittedprdtipoid_Internalname ;
      private string lblTextblockprdtipoid_Internalname ;
      private string lblTextblockprdtipoid_Jsonclick ;
      private string Combo_prdtipoid_Caption ;
      private string Combo_prdtipoid_Cls ;
      private string Combo_prdtipoid_Datalistproc ;
      private string Combo_prdtipoid_Datalistprocparametersprefix ;
      private string Combo_prdtipoid_Internalname ;
      private string edtPrdTipoID_Internalname ;
      private string edtPrdTipoID_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_prdtipoid_Internalname ;
      private string edtavComboprdtipoid_Internalname ;
      private string edtavComboprdtipoid_Jsonclick ;
      private string edtPrdID_Internalname ;
      private string edtPrdID_Jsonclick ;
      private string edtPrdInsData_Internalname ;
      private string edtPrdInsData_Jsonclick ;
      private string edtPrdInsHora_Internalname ;
      private string edtPrdInsHora_Jsonclick ;
      private string edtPrdInsDataHora_Internalname ;
      private string edtPrdInsDataHora_Jsonclick ;
      private string edtPrdInsUsuID_Internalname ;
      private string A226PrdInsUsuID ;
      private string edtPrdInsUsuID_Jsonclick ;
      private string edtPrdUpdData_Internalname ;
      private string edtPrdUpdData_Jsonclick ;
      private string edtPrdUpdHora_Internalname ;
      private string edtPrdUpdHora_Jsonclick ;
      private string edtPrdUpdDataHora_Internalname ;
      private string edtPrdUpdDataHora_Jsonclick ;
      private string edtPrdUpdUsuID_Internalname ;
      private string A230PrdUpdUsuID ;
      private string edtPrdUpdUsuID_Jsonclick ;
      private string edtPrdAtivo_Internalname ;
      private string edtPrdAtivo_Jsonclick ;
      private string edtPrdTipoSigla_Internalname ;
      private string edtPrdTipoSigla_Jsonclick ;
      private string A624PrdDelUsuId ;
      private string AV25Pgmname ;
      private string Combo_prdtipoid_Objectcall ;
      private string Combo_prdtipoid_Class ;
      private string Combo_prdtipoid_Icontype ;
      private string Combo_prdtipoid_Icon ;
      private string Combo_prdtipoid_Tooltip ;
      private string Combo_prdtipoid_Selectedvalue_set ;
      private string Combo_prdtipoid_Selectedtext_set ;
      private string Combo_prdtipoid_Selectedtext_get ;
      private string Combo_prdtipoid_Gamoauthtoken ;
      private string Combo_prdtipoid_Ddointernalname ;
      private string Combo_prdtipoid_Titlecontrolalign ;
      private string Combo_prdtipoid_Dropdownoptionstype ;
      private string Combo_prdtipoid_Titlecontrolidtoreplace ;
      private string Combo_prdtipoid_Datalisttype ;
      private string Combo_prdtipoid_Datalistfixedvalues ;
      private string Combo_prdtipoid_Remoteservicesparameters ;
      private string Combo_prdtipoid_Htmltemplate ;
      private string Combo_prdtipoid_Multiplevaluestype ;
      private string Combo_prdtipoid_Loadingdata ;
      private string Combo_prdtipoid_Noresultsfound ;
      private string Combo_prdtipoid_Emptyitemtext ;
      private string Combo_prdtipoid_Onlyselectedvalues ;
      private string Combo_prdtipoid_Selectalltext ;
      private string Combo_prdtipoid_Multiplevaluesseparator ;
      private string Combo_prdtipoid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode28 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXt_char2 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z621PrdDelDataHora ;
      private DateTime Z622PrdDelData ;
      private DateTime Z623PrdDelHora ;
      private DateTime Z224PrdInsHora ;
      private DateTime Z225PrdInsDataHora ;
      private DateTime Z228PrdUpdHora ;
      private DateTime Z229PrdUpdDataHora ;
      private DateTime A224PrdInsHora ;
      private DateTime A225PrdInsDataHora ;
      private DateTime A228PrdUpdHora ;
      private DateTime A229PrdUpdDataHora ;
      private DateTime A621PrdDelDataHora ;
      private DateTime A622PrdDelData ;
      private DateTime A623PrdDelHora ;
      private DateTime Z223PrdInsData ;
      private DateTime Z227PrdUpdData ;
      private DateTime A223PrdInsData ;
      private DateTime A227PrdUpdData ;
      private bool Z231PrdAtivo ;
      private bool Z620PrdDel ;
      private bool O620PrdDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_prdtipoid_Emptyitem ;
      private bool A231PrdAtivo ;
      private bool n621PrdDelDataHora ;
      private bool n622PrdDelData ;
      private bool n623PrdDelHora ;
      private bool n624PrdDelUsuId ;
      private bool n625PrdDelUsuNome ;
      private bool n226PrdInsUsuID ;
      private bool n227PrdUpdData ;
      private bool n228PrdUpdHora ;
      private bool n229PrdUpdDataHora ;
      private bool n230PrdUpdUsuID ;
      private bool A620PrdDel ;
      private bool Combo_prdtipoid_Enabled ;
      private bool Combo_prdtipoid_Visible ;
      private bool Combo_prdtipoid_Allowmultipleselection ;
      private bool Combo_prdtipoid_Isgriditem ;
      private bool Combo_prdtipoid_Hasdescription ;
      private bool Combo_prdtipoid_Includeonlyselectedoption ;
      private bool Combo_prdtipoid_Includeselectalloption ;
      private bool Combo_prdtipoid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i231PrdAtivo ;
      private string AV19Combo_DataJson ;
      private string Z625PrdDelUsuNome ;
      private string Z221PrdCodigo ;
      private string Z222PrdNome ;
      private string A221PrdCodigo ;
      private string A222PrdNome ;
      private string A233PrdTipoSigla ;
      private string A625PrdDelUsuNome ;
      private string A234PrdTipoNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private string Z233PrdTipoSigla ;
      private string Z234PrdTipoNome ;
      private Guid wcpOAV7PrdID ;
      private Guid Z220PrdID ;
      private Guid AV7PrdID ;
      private Guid A220PrdID ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_prdtipoid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000S4_A233PrdTipoSigla ;
      private string[] T000S4_A234PrdTipoNome ;
      private Guid[] T000S5_A220PrdID ;
      private DateTime[] T000S5_A621PrdDelDataHora ;
      private bool[] T000S5_n621PrdDelDataHora ;
      private DateTime[] T000S5_A622PrdDelData ;
      private bool[] T000S5_n622PrdDelData ;
      private DateTime[] T000S5_A623PrdDelHora ;
      private bool[] T000S5_n623PrdDelHora ;
      private string[] T000S5_A624PrdDelUsuId ;
      private bool[] T000S5_n624PrdDelUsuId ;
      private string[] T000S5_A625PrdDelUsuNome ;
      private bool[] T000S5_n625PrdDelUsuNome ;
      private string[] T000S5_A221PrdCodigo ;
      private string[] T000S5_A222PrdNome ;
      private DateTime[] T000S5_A223PrdInsData ;
      private DateTime[] T000S5_A224PrdInsHora ;
      private DateTime[] T000S5_A225PrdInsDataHora ;
      private string[] T000S5_A226PrdInsUsuID ;
      private bool[] T000S5_n226PrdInsUsuID ;
      private DateTime[] T000S5_A227PrdUpdData ;
      private bool[] T000S5_n227PrdUpdData ;
      private DateTime[] T000S5_A228PrdUpdHora ;
      private bool[] T000S5_n228PrdUpdHora ;
      private DateTime[] T000S5_A229PrdUpdDataHora ;
      private bool[] T000S5_n229PrdUpdDataHora ;
      private string[] T000S5_A230PrdUpdUsuID ;
      private bool[] T000S5_n230PrdUpdUsuID ;
      private bool[] T000S5_A231PrdAtivo ;
      private string[] T000S5_A233PrdTipoSigla ;
      private string[] T000S5_A234PrdTipoNome ;
      private bool[] T000S5_A620PrdDel ;
      private int[] T000S5_A232PrdTipoID ;
      private string[] T000S6_A221PrdCodigo ;
      private string[] T000S7_A233PrdTipoSigla ;
      private string[] T000S7_A234PrdTipoNome ;
      private Guid[] T000S8_A220PrdID ;
      private Guid[] T000S3_A220PrdID ;
      private DateTime[] T000S3_A621PrdDelDataHora ;
      private bool[] T000S3_n621PrdDelDataHora ;
      private DateTime[] T000S3_A622PrdDelData ;
      private bool[] T000S3_n622PrdDelData ;
      private DateTime[] T000S3_A623PrdDelHora ;
      private bool[] T000S3_n623PrdDelHora ;
      private string[] T000S3_A624PrdDelUsuId ;
      private bool[] T000S3_n624PrdDelUsuId ;
      private string[] T000S3_A625PrdDelUsuNome ;
      private bool[] T000S3_n625PrdDelUsuNome ;
      private string[] T000S3_A221PrdCodigo ;
      private string[] T000S3_A222PrdNome ;
      private DateTime[] T000S3_A223PrdInsData ;
      private DateTime[] T000S3_A224PrdInsHora ;
      private DateTime[] T000S3_A225PrdInsDataHora ;
      private string[] T000S3_A226PrdInsUsuID ;
      private bool[] T000S3_n226PrdInsUsuID ;
      private DateTime[] T000S3_A227PrdUpdData ;
      private bool[] T000S3_n227PrdUpdData ;
      private DateTime[] T000S3_A228PrdUpdHora ;
      private bool[] T000S3_n228PrdUpdHora ;
      private DateTime[] T000S3_A229PrdUpdDataHora ;
      private bool[] T000S3_n229PrdUpdDataHora ;
      private string[] T000S3_A230PrdUpdUsuID ;
      private bool[] T000S3_n230PrdUpdUsuID ;
      private bool[] T000S3_A231PrdAtivo ;
      private bool[] T000S3_A620PrdDel ;
      private int[] T000S3_A232PrdTipoID ;
      private Guid[] T000S9_A220PrdID ;
      private Guid[] T000S10_A220PrdID ;
      private Guid[] T000S2_A220PrdID ;
      private DateTime[] T000S2_A621PrdDelDataHora ;
      private bool[] T000S2_n621PrdDelDataHora ;
      private DateTime[] T000S2_A622PrdDelData ;
      private bool[] T000S2_n622PrdDelData ;
      private DateTime[] T000S2_A623PrdDelHora ;
      private bool[] T000S2_n623PrdDelHora ;
      private string[] T000S2_A624PrdDelUsuId ;
      private bool[] T000S2_n624PrdDelUsuId ;
      private string[] T000S2_A625PrdDelUsuNome ;
      private bool[] T000S2_n625PrdDelUsuNome ;
      private string[] T000S2_A221PrdCodigo ;
      private string[] T000S2_A222PrdNome ;
      private DateTime[] T000S2_A223PrdInsData ;
      private DateTime[] T000S2_A224PrdInsHora ;
      private DateTime[] T000S2_A225PrdInsDataHora ;
      private string[] T000S2_A226PrdInsUsuID ;
      private bool[] T000S2_n226PrdInsUsuID ;
      private DateTime[] T000S2_A227PrdUpdData ;
      private bool[] T000S2_n227PrdUpdData ;
      private DateTime[] T000S2_A228PrdUpdHora ;
      private bool[] T000S2_n228PrdUpdHora ;
      private DateTime[] T000S2_A229PrdUpdDataHora ;
      private bool[] T000S2_n229PrdUpdDataHora ;
      private string[] T000S2_A230PrdUpdUsuID ;
      private bool[] T000S2_n230PrdUpdUsuID ;
      private bool[] T000S2_A231PrdAtivo ;
      private bool[] T000S2_A620PrdDel ;
      private int[] T000S2_A232PrdTipoID ;
      private string[] T000S14_A233PrdTipoSigla ;
      private string[] T000S14_A234PrdTipoNome ;
      private Guid[] T000S15_A235TppID ;
      private Guid[] T000S15_A220PrdID ;
      private Guid[] T000S16_A220PrdID ;
      private string[] T000S17_A221PrdCodigo ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15PrdTipoID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV14TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV22GAMSession ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV24AuditingObject ;
   }

   public class produto__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class produto__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000S5;
        prmT000S5 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S6;
        prmT000S6 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S4;
        prmT000S4 = new Object[] {
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000S7;
        prmT000S7 = new Object[] {
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000S8;
        prmT000S8 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S3;
        prmT000S3 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S9;
        prmT000S9 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S10;
        prmT000S10 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S2;
        prmT000S2 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S11;
        prmT000S11 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("PrdDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrdDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdInsData",GXType.Date,8,0) ,
        new ParDef("PrdInsHora",GXType.DateTime,0,5) ,
        new ParDef("PrdInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("PrdInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("PrdUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrdDel",GXType.Boolean,4,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000S12;
        prmT000S12 = new Object[] {
        new ParDef("PrdDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("PrdDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdNome",GXType.VarChar,80,0) ,
        new ParDef("PrdInsData",GXType.Date,8,0) ,
        new ParDef("PrdInsHora",GXType.DateTime,0,5) ,
        new ParDef("PrdInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("PrdInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("PrdUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("PrdUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("PrdUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("PrdAtivo",GXType.Boolean,4,0) ,
        new ParDef("PrdDel",GXType.Boolean,4,0) ,
        new ParDef("PrdTipoID",GXType.Int32,9,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S13;
        prmT000S13 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S15;
        prmT000S15 = new Object[] {
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S16;
        prmT000S16 = new Object[] {
        };
        Object[] prmT000S17;
        prmT000S17 = new Object[] {
        new ParDef("PrdCodigo",GXType.VarChar,30,0) ,
        new ParDef("PrdID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000S14;
        prmT000S14 = new Object[] {
        new ParDef("PrdTipoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000S2", "SELECT PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID FROM tb_produto WHERE PrdID = :PrdID  FOR UPDATE OF tb_produto NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000S2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S3", "SELECT PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S4", "SELECT PrtSigla AS PrdTipoSigla, PrtNome AS PrdTipoNome FROM tb_produtotipo WHERE PrtID = :PrdTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S5", "SELECT TM1.PrdID, TM1.PrdDelDataHora, TM1.PrdDelData, TM1.PrdDelHora, TM1.PrdDelUsuId, TM1.PrdDelUsuNome, TM1.PrdCodigo, TM1.PrdNome, TM1.PrdInsData, TM1.PrdInsHora, TM1.PrdInsDataHora, TM1.PrdInsUsuID, TM1.PrdUpdData, TM1.PrdUpdHora, TM1.PrdUpdDataHora, TM1.PrdUpdUsuID, TM1.PrdAtivo, T2.PrtSigla AS PrdTipoSigla, T2.PrtNome AS PrdTipoNome, TM1.PrdDel, TM1.PrdTipoID AS PrdTipoID FROM (tb_produto TM1 INNER JOIN tb_produtotipo T2 ON T2.PrtID = TM1.PrdTipoID) WHERE TM1.PrdID = :PrdID ORDER BY TM1.PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S5,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S6", "SELECT PrdCodigo FROM tb_produto WHERE (PrdCodigo = :PrdCodigo) AND (Not ( PrdID = :PrdID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S7", "SELECT PrtSigla AS PrdTipoSigla, PrtNome AS PrdTipoNome FROM tb_produtotipo WHERE PrtID = :PrdTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S8", "SELECT PrdID FROM tb_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S9", "SELECT PrdID FROM tb_produto WHERE ( PrdID > :PrdID) ORDER BY PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S9,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S10", "SELECT PrdID FROM tb_produto WHERE ( PrdID < :PrdID) ORDER BY PrdID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S11", "SAVEPOINT gxupdate;INSERT INTO tb_produto(PrdID, PrdDelDataHora, PrdDelData, PrdDelHora, PrdDelUsuId, PrdDelUsuNome, PrdCodigo, PrdNome, PrdInsData, PrdInsHora, PrdInsDataHora, PrdInsUsuID, PrdUpdData, PrdUpdHora, PrdUpdDataHora, PrdUpdUsuID, PrdAtivo, PrdDel, PrdTipoID) VALUES(:PrdID, :PrdDelDataHora, :PrdDelData, :PrdDelHora, :PrdDelUsuId, :PrdDelUsuNome, :PrdCodigo, :PrdNome, :PrdInsData, :PrdInsHora, :PrdInsDataHora, :PrdInsUsuID, :PrdUpdData, :PrdUpdHora, :PrdUpdDataHora, :PrdUpdUsuID, :PrdAtivo, :PrdDel, :PrdTipoID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000S11)
           ,new CursorDef("T000S12", "SAVEPOINT gxupdate;UPDATE tb_produto SET PrdDelDataHora=:PrdDelDataHora, PrdDelData=:PrdDelData, PrdDelHora=:PrdDelHora, PrdDelUsuId=:PrdDelUsuId, PrdDelUsuNome=:PrdDelUsuNome, PrdCodigo=:PrdCodigo, PrdNome=:PrdNome, PrdInsData=:PrdInsData, PrdInsHora=:PrdInsHora, PrdInsDataHora=:PrdInsDataHora, PrdInsUsuID=:PrdInsUsuID, PrdUpdData=:PrdUpdData, PrdUpdHora=:PrdUpdHora, PrdUpdDataHora=:PrdUpdDataHora, PrdUpdUsuID=:PrdUpdUsuID, PrdAtivo=:PrdAtivo, PrdDel=:PrdDel, PrdTipoID=:PrdTipoID  WHERE PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S12)
           ,new CursorDef("T000S13", "SAVEPOINT gxupdate;DELETE FROM tb_produto  WHERE PrdID = :PrdID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000S13)
           ,new CursorDef("T000S14", "SELECT PrtSigla AS PrdTipoSigla, PrtNome AS PrdTipoNome FROM tb_produtotipo WHERE PrtID = :PrdTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S14,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S15", "SELECT TppID, PrdID FROM tb_tabeladepreco_produto WHERE PrdID = :PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S15,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000S16", "SELECT PrdID FROM tb_produto ORDER BY PrdID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S16,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000S17", "SELECT PrdCodigo FROM tb_produto WHERE (PrdCodigo = :PrdCodigo) AND (Not ( PrdID = :PrdID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000S17,1, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((bool[]) buf[27])[0] = rslt.getBool(18);
              ((int[]) buf[28])[0] = rslt.getInt(19);
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
              ((string[]) buf[11])[0] = rslt.getVarchar(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((bool[]) buf[27])[0] = rslt.getBool(18);
              ((int[]) buf[28])[0] = rslt.getInt(19);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
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
              ((DateTime[]) buf[13])[0] = rslt.getGXDate(9);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(10);
              ((DateTime[]) buf[15])[0] = rslt.getGXDateTime(11, true);
              ((string[]) buf[16])[0] = rslt.getString(12, 40);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDate(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[22])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getString(16, 40);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((bool[]) buf[26])[0] = rslt.getBool(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((int[]) buf[30])[0] = rslt.getInt(21);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 12 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
