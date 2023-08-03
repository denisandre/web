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
   public class negociopjfluxo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_25") == 0 )
         {
            A345NegID = StringUtil.StrToGuid( GetPar( "NegID"));
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_25( A345NegID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.negociopjfluxo.aspx")), "core.negociopjfluxo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.negociopjfluxo.aspx")))) ;
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
                  AV7NegID = StringUtil.StrToGuid( GetPar( "NegID"));
                  AssignAttri("", false, "AV7NegID", AV7NegID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV7NegID, context));
                  AV8NefChave = GetPar( "NefChave");
                  AssignAttri("", false, "AV8NefChave", AV8NefChave);
                  GxWebStd.gx_hidden_field( context, "gxhash_vNEFCHAVE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8NefChave, "")), context));
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
            Form.Meta.addItem("description", "Fluxo do Negócio", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public negociopjfluxo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public negociopjfluxo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_NegID ,
                           string aP2_NefChave )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7NegID = aP1_NegID;
         this.AV8NefChave = aP2_NefChave;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbNefChave = new GXCombobox();
         chkNefConfirmado = new GXCheckbox();
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
            return "negociopjfluxo_Execute" ;
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
         if ( cmbNefChave.ItemCount > 0 )
         {
            A626NefChave = cmbNefChave.getValidValue(A626NefChave);
            AssignAttri("", false, "A626NefChave", A626NefChave);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNefChave.CurrentValue = StringUtil.RTrim( A626NefChave);
            AssignProp("", false, cmbNefChave_Internalname, "Values", cmbNefChave.ToJavascriptSource(), true);
         }
         A627NefConfirmado = StringUtil.StrToBool( StringUtil.BoolToStr( A627NefConfirmado));
         AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplittednegid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblocknegid_Internalname, "Oportunidade de Negócio", "", "", lblTextblocknegid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_negid.SetProperty("Caption", Combo_negid_Caption);
         ucCombo_negid.SetProperty("Cls", Combo_negid_Cls);
         ucCombo_negid.SetProperty("DataListProc", Combo_negid_Datalistproc);
         ucCombo_negid.SetProperty("DataListProcParametersPrefix", Combo_negid_Datalistprocparametersprefix);
         ucCombo_negid.SetProperty("EmptyItem", Combo_negid_Emptyitem);
         ucCombo_negid.SetProperty("DropDownOptionsTitleSettingsIcons", AV16DDO_TitleSettingsIcons);
         ucCombo_negid.SetProperty("DropDownOptionsData", AV15NegID_Data);
         ucCombo_negid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_negid_Internalname, "COMBO_NEGIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNegID_Internalname, "ID", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 28,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNegID_Internalname, A345NegID.ToString(), A345NegID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,28);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNegID_Jsonclick, 0, "Attribute", "", "", "", "", edtNegID_Visible, edtNegID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbNefChave_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbNefChave_Internalname, "do Fluxo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbNefChave, cmbNefChave_Internalname, StringUtil.RTrim( A626NefChave), 1, cmbNefChave_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "svchar", "", 1, cmbNefChave.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "", true, 0, "HLP_core\\NegocioPJFluxo.htm");
         cmbNefChave.CurrentValue = StringUtil.RTrim( A626NefChave);
         AssignProp("", false, cmbNefChave_Internalname, "Values", (string)(cmbNefChave.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkNefConfirmado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkNefConfirmado_Internalname, "Confirmado?", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 38,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkNefConfirmado_Internalname, StringUtil.BoolToStr( A627NefConfirmado), "", "Confirmado?", 1, chkNefConfirmado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(38, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,38);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefTexto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefTexto_Internalname, "Texto", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtNefTexto_Internalname, A628NefTexto, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", 0, 1, edtNefTexto_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "250", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefInsDataHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefInsDataHora_Internalname, "Incluído em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefInsDataHora_Internalname, context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A629NefInsDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefInsDataHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefInsDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefInsDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefInsData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefInsData_Internalname, "Incluído em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 53,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefInsData_Internalname, context.localUtil.TToC( A630NefInsData, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A630NefInsData, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,53);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefInsData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefInsData_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefInsData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefInsHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefInsHora_Internalname, "Incluído às", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 58,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefInsHora_Internalname, context.localUtil.TToC( A631NefInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A631NefInsHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,58);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefInsHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefInsHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefInsHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefInsUsuId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefInsUsuId_Internalname, "Incluído por", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 63,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNefInsUsuId_Internalname, StringUtil.RTrim( A632NefInsUsuId), StringUtil.RTrim( context.localUtil.Format( A632NefInsUsuId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,63);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefInsUsuId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefInsUsuId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefInsUsuNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefInsUsuNome_Internalname, "Incluído por", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNefInsUsuNome_Internalname, A633NefInsUsuNome, StringUtil.RTrim( context.localUtil.Format( A633NefInsUsuNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,68);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefInsUsuNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefInsUsuNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefUpdDataHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefUpdDataHora_Internalname, "Alterado em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefUpdDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefUpdDataHora_Internalname, context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A634NefUpdDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefUpdDataHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefUpdDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefUpdDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefUpdDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefUpdData_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefUpdData_Internalname, "Alterado em", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefUpdData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefUpdData_Internalname, context.localUtil.TToC( A635NefUpdData, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A635NefUpdData, "99/99/9999 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefUpdData_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefUpdData_Enabled, 0, "text", "", 16, "chr", 1, "row", 16, 0, 0, 0, 0, -1, 0, true, "core\\DataHora", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefUpdData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefUpdData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefUpdHora_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefUpdHora_Internalname, "Alterado às", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtNefUpdHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtNefUpdHora_Internalname, context.localUtil.TToC( A636NefUpdHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A636NefUpdHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefUpdHora_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefUpdHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_bitmap( context, edtNefUpdHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtNefUpdHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\NegocioPJFluxo.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefUpdUsuId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefUpdUsuId_Internalname, "Alterado por", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNefUpdUsuId_Internalname, StringUtil.RTrim( A637NefUpdUsuId), StringUtil.RTrim( context.localUtil.Format( A637NefUpdUsuId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefUpdUsuId_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefUpdUsuId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefUpdUsuNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefUpdUsuNome_Internalname, "Alterado por", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNefUpdUsuNome_Internalname, A638NefUpdUsuNome, StringUtil.RTrim( context.localUtil.Format( A638NefUpdUsuNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefUpdUsuNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefUpdUsuNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtNefValor_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtNefValor_Internalname, "Valor", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtNefValor_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A639NefValor), 3, 0, ",", "")), StringUtil.LTrim( ((edtNefValor_Enabled!=0) ? context.localUtil.Format( (decimal)(A639NefValor), "ZZ9") : context.localUtil.Format( (decimal)(A639NefValor), "ZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtNefValor_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtNefValor_Enabled, 0, "text", "1", 3, "chr", 1, "row", 3, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\NegocioPJFluxo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJFluxo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 105,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\NegocioPJFluxo.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_negid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombonegid_Internalname, AV20ComboNegID.ToString(), AV20ComboNegID.ToString(), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombonegid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombonegid_Visible, edtavCombonegid_Enabled, 0, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\NegocioPJFluxo.htm");
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
         E11192 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDDO_TITLESETTINGSICONS"), AV16DDO_TitleSettingsIcons);
               ajax_req_read_hidden_sdt(cgiGet( "vNEGID_DATA"), AV15NegID_Data);
               /* Read saved values. */
               Z345NegID = StringUtil.StrToGuid( cgiGet( "Z345NegID"));
               Z626NefChave = cgiGet( "Z626NefChave");
               Z629NefInsDataHora = context.localUtil.CToT( cgiGet( "Z629NefInsDataHora"), 0);
               Z630NefInsData = context.localUtil.CToT( cgiGet( "Z630NefInsData"), 0);
               Z631NefInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z631NefInsHora"), 0));
               Z632NefInsUsuId = cgiGet( "Z632NefInsUsuId");
               Z633NefInsUsuNome = cgiGet( "Z633NefInsUsuNome");
               Z634NefUpdDataHora = context.localUtil.CToT( cgiGet( "Z634NefUpdDataHora"), 0);
               n634NefUpdDataHora = ((DateTime.MinValue==A634NefUpdDataHora) ? true : false);
               Z635NefUpdData = context.localUtil.CToT( cgiGet( "Z635NefUpdData"), 0);
               n635NefUpdData = ((DateTime.MinValue==A635NefUpdData) ? true : false);
               Z636NefUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z636NefUpdHora"), 0));
               n636NefUpdHora = ((DateTime.MinValue==A636NefUpdHora) ? true : false);
               Z637NefUpdUsuId = cgiGet( "Z637NefUpdUsuId");
               n637NefUpdUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A637NefUpdUsuId)) ? true : false);
               Z638NefUpdUsuNome = cgiGet( "Z638NefUpdUsuNome");
               n638NefUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A638NefUpdUsuNome)) ? true : false);
               Z627NefConfirmado = StringUtil.StrToBool( cgiGet( "Z627NefConfirmado"));
               Z628NefTexto = cgiGet( "Z628NefTexto");
               n628NefTexto = (String.IsNullOrEmpty(StringUtil.RTrim( A628NefTexto)) ? true : false);
               Z639NefValor = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z639NefValor"), ",", "."), 18, MidpointRounding.ToEven));
               n639NefValor = ((0==A639NefValor) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7NegID = StringUtil.StrToGuid( cgiGet( "vNEGID"));
               AV8NefChave = cgiGet( "vNEFCHAVE");
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV12AuditingObject);
               AV23Pgmname = cgiGet( "vPGMNAME");
               Combo_negid_Objectcall = cgiGet( "COMBO_NEGID_Objectcall");
               Combo_negid_Class = cgiGet( "COMBO_NEGID_Class");
               Combo_negid_Icontype = cgiGet( "COMBO_NEGID_Icontype");
               Combo_negid_Icon = cgiGet( "COMBO_NEGID_Icon");
               Combo_negid_Caption = cgiGet( "COMBO_NEGID_Caption");
               Combo_negid_Tooltip = cgiGet( "COMBO_NEGID_Tooltip");
               Combo_negid_Cls = cgiGet( "COMBO_NEGID_Cls");
               Combo_negid_Selectedvalue_set = cgiGet( "COMBO_NEGID_Selectedvalue_set");
               Combo_negid_Selectedvalue_get = cgiGet( "COMBO_NEGID_Selectedvalue_get");
               Combo_negid_Selectedtext_set = cgiGet( "COMBO_NEGID_Selectedtext_set");
               Combo_negid_Selectedtext_get = cgiGet( "COMBO_NEGID_Selectedtext_get");
               Combo_negid_Gamoauthtoken = cgiGet( "COMBO_NEGID_Gamoauthtoken");
               Combo_negid_Ddointernalname = cgiGet( "COMBO_NEGID_Ddointernalname");
               Combo_negid_Titlecontrolalign = cgiGet( "COMBO_NEGID_Titlecontrolalign");
               Combo_negid_Dropdownoptionstype = cgiGet( "COMBO_NEGID_Dropdownoptionstype");
               Combo_negid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Enabled"));
               Combo_negid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Visible"));
               Combo_negid_Titlecontrolidtoreplace = cgiGet( "COMBO_NEGID_Titlecontrolidtoreplace");
               Combo_negid_Datalisttype = cgiGet( "COMBO_NEGID_Datalisttype");
               Combo_negid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Allowmultipleselection"));
               Combo_negid_Datalistfixedvalues = cgiGet( "COMBO_NEGID_Datalistfixedvalues");
               Combo_negid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Isgriditem"));
               Combo_negid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Hasdescription"));
               Combo_negid_Datalistproc = cgiGet( "COMBO_NEGID_Datalistproc");
               Combo_negid_Datalistprocparametersprefix = cgiGet( "COMBO_NEGID_Datalistprocparametersprefix");
               Combo_negid_Remoteservicesparameters = cgiGet( "COMBO_NEGID_Remoteservicesparameters");
               Combo_negid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_negid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Includeonlyselectedoption"));
               Combo_negid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Includeselectalloption"));
               Combo_negid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Emptyitem"));
               Combo_negid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_NEGID_Includeaddnewoption"));
               Combo_negid_Htmltemplate = cgiGet( "COMBO_NEGID_Htmltemplate");
               Combo_negid_Multiplevaluestype = cgiGet( "COMBO_NEGID_Multiplevaluestype");
               Combo_negid_Loadingdata = cgiGet( "COMBO_NEGID_Loadingdata");
               Combo_negid_Noresultsfound = cgiGet( "COMBO_NEGID_Noresultsfound");
               Combo_negid_Emptyitemtext = cgiGet( "COMBO_NEGID_Emptyitemtext");
               Combo_negid_Onlyselectedvalues = cgiGet( "COMBO_NEGID_Onlyselectedvalues");
               Combo_negid_Selectalltext = cgiGet( "COMBO_NEGID_Selectalltext");
               Combo_negid_Multiplevaluesseparator = cgiGet( "COMBO_NEGID_Multiplevaluesseparator");
               Combo_negid_Addnewoptiontext = cgiGet( "COMBO_NEGID_Addnewoptiontext");
               Combo_negid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_NEGID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               if ( StringUtil.StrCmp(cgiGet( edtNegID_Internalname), "") == 0 )
               {
                  A345NegID = Guid.Empty;
                  AssignAttri("", false, "A345NegID", A345NegID.ToString());
               }
               else
               {
                  try
                  {
                     A345NegID = StringUtil.StrToGuid( cgiGet( edtNegID_Internalname));
                     AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "NEGID");
                     AnyError = 1;
                     GX_FocusControl = edtNegID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               cmbNefChave.CurrentValue = cgiGet( cmbNefChave_Internalname);
               A626NefChave = cgiGet( cmbNefChave_Internalname);
               AssignAttri("", false, "A626NefChave", A626NefChave);
               A627NefConfirmado = StringUtil.StrToBool( cgiGet( chkNefConfirmado_Internalname));
               AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
               A628NefTexto = cgiGet( edtNefTexto_Internalname);
               n628NefTexto = false;
               AssignAttri("", false, "A628NefTexto", A628NefTexto);
               n628NefTexto = (String.IsNullOrEmpty(StringUtil.RTrim( A628NefTexto)) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtNefInsDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Incluído em"}), 1, "NEFINSDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtNefInsDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A629NefInsDataHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A629NefInsDataHora = context.localUtil.CToT( cgiGet( edtNefInsDataHora_Internalname));
                  AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtNefInsData_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Incluído em"}), 1, "NEFINSDATA");
                  AnyError = 1;
                  GX_FocusControl = edtNefInsData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A630NefInsData = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A630NefInsData = context.localUtil.CToT( cgiGet( edtNefInsData_Internalname));
                  AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDate( cgiGet( edtNefInsHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Incluído às"}), 1, "NEFINSHORA");
                  AnyError = 1;
                  GX_FocusControl = edtNefInsHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A631NefInsHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A631NefInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtNefInsHora_Internalname)));
                  AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               A632NefInsUsuId = cgiGet( edtNefInsUsuId_Internalname);
               AssignAttri("", false, "A632NefInsUsuId", A632NefInsUsuId);
               A633NefInsUsuNome = StringUtil.Upper( cgiGet( edtNefInsUsuNome_Internalname));
               AssignAttri("", false, "A633NefInsUsuNome", A633NefInsUsuNome);
               if ( context.localUtil.VCDateTime( cgiGet( edtNefUpdDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Alterado em"}), 1, "NEFUPDDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtNefUpdDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
                  n634NefUpdDataHora = false;
                  AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A634NefUpdDataHora = context.localUtil.CToT( cgiGet( edtNefUpdDataHora_Internalname));
                  n634NefUpdDataHora = false;
                  AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               n634NefUpdDataHora = ((DateTime.MinValue==A634NefUpdDataHora) ? true : false);
               if ( context.localUtil.VCDateTime( cgiGet( edtNefUpdData_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Alterado em"}), 1, "NEFUPDDATA");
                  AnyError = 1;
                  GX_FocusControl = edtNefUpdData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A635NefUpdData = (DateTime)(DateTime.MinValue);
                  n635NefUpdData = false;
                  AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A635NefUpdData = context.localUtil.CToT( cgiGet( edtNefUpdData_Internalname));
                  n635NefUpdData = false;
                  AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
               }
               n635NefUpdData = ((DateTime.MinValue==A635NefUpdData) ? true : false);
               if ( context.localUtil.VCDate( cgiGet( edtNefUpdHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Alterado às"}), 1, "NEFUPDHORA");
                  AnyError = 1;
                  GX_FocusControl = edtNefUpdHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A636NefUpdHora = (DateTime)(DateTime.MinValue);
                  n636NefUpdHora = false;
                  AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A636NefUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtNefUpdHora_Internalname)));
                  n636NefUpdHora = false;
                  AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
               }
               n636NefUpdHora = ((DateTime.MinValue==A636NefUpdHora) ? true : false);
               A637NefUpdUsuId = cgiGet( edtNefUpdUsuId_Internalname);
               n637NefUpdUsuId = false;
               AssignAttri("", false, "A637NefUpdUsuId", A637NefUpdUsuId);
               n637NefUpdUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A637NefUpdUsuId)) ? true : false);
               A638NefUpdUsuNome = StringUtil.Upper( cgiGet( edtNefUpdUsuNome_Internalname));
               n638NefUpdUsuNome = false;
               AssignAttri("", false, "A638NefUpdUsuNome", A638NefUpdUsuNome);
               n638NefUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A638NefUpdUsuNome)) ? true : false);
               if ( ( ( context.localUtil.CToN( cgiGet( edtNefValor_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtNefValor_Internalname), ",", ".") > Convert.ToDecimal( 999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "NEFVALOR");
                  AnyError = 1;
                  GX_FocusControl = edtNefValor_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A639NefValor = 0;
                  n639NefValor = false;
                  AssignAttri("", false, "A639NefValor", StringUtil.LTrimStr( (decimal)(A639NefValor), 3, 0));
               }
               else
               {
                  A639NefValor = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtNefValor_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  n639NefValor = false;
                  AssignAttri("", false, "A639NefValor", StringUtil.LTrimStr( (decimal)(A639NefValor), 3, 0));
               }
               n639NefValor = ((0==A639NefValor) ? true : false);
               AV20ComboNegID = StringUtil.StrToGuid( cgiGet( edtavCombonegid_Internalname));
               AssignAttri("", false, "AV20ComboNegID", AV20ComboNegID.ToString());
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"NegocioPJFluxo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV23Pgmname, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\negociopjfluxo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A345NegID = StringUtil.StrToGuid( GetPar( "NegID"));
                  AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  A626NefChave = GetPar( "NefChave");
                  AssignAttri("", false, "A626NefChave", A626NefChave);
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
                     sMode44 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode44;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound44 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_190( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "NEGID");
                        AnyError = 1;
                        GX_FocusControl = edtNegID_Internalname;
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
                        if ( StringUtil.StrCmp(sEvt, "COMBO_NEGID.ONOPTIONCLICKED") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E12192 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E11192 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E13192 ();
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
            E13192 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1944( ) ;
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
            DisableAttributes1944( ) ;
         }
         AssignProp("", false, edtavCombonegid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegid_Enabled), 5, 0), true);
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

      protected void CONFIRM_190( )
      {
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1944( ) ;
            }
            else
            {
               CheckExtendedTable1944( ) ;
               CloseExtendedTableCursors1944( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption190( )
      {
      }

      protected void E11192( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV9WWPContext) ;
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = AV16DDO_TitleSettingsIcons;
         new GeneXus.Programs.wwpbaseobjects.getwwptitlesettingsicons(context ).execute( out  GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1) ;
         AV16DDO_TitleSettingsIcons = GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1;
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context).get(out  AV22GAMErrors);
         Combo_negid_Gamoauthtoken = AV21GAMSession.gxTpr_Token;
         ucCombo_negid.SendProperty(context, "", false, Combo_negid_Internalname, "GAMOAuthToken", Combo_negid_Gamoauthtoken);
         edtNegID_Visible = 0;
         AssignProp("", false, edtNegID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtNegID_Visible), 5, 0), true);
         AV20ComboNegID = Guid.Empty;
         AssignAttri("", false, "AV20ComboNegID", AV20ComboNegID.ToString());
         edtavCombonegid_Visible = 0;
         AssignProp("", false, edtavCombonegid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombonegid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBONEGID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV13TrnContext.FromXml(AV14WebSession.Get("TrnContext"), null, "", "");
      }

      protected void E13192( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV12AuditingObject,  AV23Pgmname) ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void E12192( )
      {
         /* Combo_negid_Onoptionclicked Routine */
         returnInSub = false;
         AV20ComboNegID = StringUtil.StrToGuid( Combo_negid_Selectedvalue_get);
         AssignAttri("", false, "AV20ComboNegID", AV20ComboNegID.ToString());
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'LOADCOMBONEGID' Routine */
         returnInSub = false;
         GXt_char2 = AV19Combo_DataJson;
         new GeneXus.Programs.core.negociopjfluxoloaddvcombo(context ).execute(  "NegID",  Gx_mode,  false,  AV7NegID,  AV8NefChave,  "", out  AV17ComboSelectedValue, out  AV18ComboSelectedText, out  GXt_char2) ;
         AV19Combo_DataJson = GXt_char2;
         Combo_negid_Selectedvalue_set = AV17ComboSelectedValue;
         ucCombo_negid.SendProperty(context, "", false, Combo_negid_Internalname, "SelectedValue_set", Combo_negid_Selectedvalue_set);
         Combo_negid_Selectedtext_set = AV18ComboSelectedText;
         ucCombo_negid.SendProperty(context, "", false, Combo_negid_Internalname, "SelectedText_set", Combo_negid_Selectedtext_set);
         AV20ComboNegID = StringUtil.StrToGuid( AV17ComboSelectedValue);
         AssignAttri("", false, "AV20ComboNegID", AV20ComboNegID.ToString());
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) || ! (Guid.Empty==AV7NegID) )
         {
            Combo_negid_Enabled = false;
            ucCombo_negid.SendProperty(context, "", false, Combo_negid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_negid_Enabled));
         }
      }

      protected void ZM1944( short GX_JID )
      {
         if ( ( GX_JID == 24 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z629NefInsDataHora = T00193_A629NefInsDataHora[0];
               Z630NefInsData = T00193_A630NefInsData[0];
               Z631NefInsHora = T00193_A631NefInsHora[0];
               Z632NefInsUsuId = T00193_A632NefInsUsuId[0];
               Z633NefInsUsuNome = T00193_A633NefInsUsuNome[0];
               Z634NefUpdDataHora = T00193_A634NefUpdDataHora[0];
               Z635NefUpdData = T00193_A635NefUpdData[0];
               Z636NefUpdHora = T00193_A636NefUpdHora[0];
               Z637NefUpdUsuId = T00193_A637NefUpdUsuId[0];
               Z638NefUpdUsuNome = T00193_A638NefUpdUsuNome[0];
               Z627NefConfirmado = T00193_A627NefConfirmado[0];
               Z628NefTexto = T00193_A628NefTexto[0];
               Z639NefValor = T00193_A639NefValor[0];
            }
            else
            {
               Z629NefInsDataHora = A629NefInsDataHora;
               Z630NefInsData = A630NefInsData;
               Z631NefInsHora = A631NefInsHora;
               Z632NefInsUsuId = A632NefInsUsuId;
               Z633NefInsUsuNome = A633NefInsUsuNome;
               Z634NefUpdDataHora = A634NefUpdDataHora;
               Z635NefUpdData = A635NefUpdData;
               Z636NefUpdHora = A636NefUpdHora;
               Z637NefUpdUsuId = A637NefUpdUsuId;
               Z638NefUpdUsuNome = A638NefUpdUsuNome;
               Z627NefConfirmado = A627NefConfirmado;
               Z628NefTexto = A628NefTexto;
               Z639NefValor = A639NefValor;
            }
         }
         if ( GX_JID == -24 )
         {
            Z626NefChave = A626NefChave;
            Z629NefInsDataHora = A629NefInsDataHora;
            Z630NefInsData = A630NefInsData;
            Z631NefInsHora = A631NefInsHora;
            Z632NefInsUsuId = A632NefInsUsuId;
            Z633NefInsUsuNome = A633NefInsUsuNome;
            Z634NefUpdDataHora = A634NefUpdDataHora;
            Z635NefUpdData = A635NefUpdData;
            Z636NefUpdHora = A636NefUpdHora;
            Z637NefUpdUsuId = A637NefUpdUsuId;
            Z638NefUpdUsuNome = A638NefUpdUsuNome;
            Z627NefConfirmado = A627NefConfirmado;
            Z628NefTexto = A628NefTexto;
            Z639NefValor = A639NefValor;
            Z345NegID = A345NegID;
         }
      }

      protected void standaloneNotModal( )
      {
         AV23Pgmname = "core.NegocioPJFluxo";
         AssignAttri("", false, "AV23Pgmname", AV23Pgmname);
         if ( ! (Guid.Empty==AV7NegID) )
         {
            edtNegID_Enabled = 0;
            AssignProp("", false, edtNegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegID_Enabled), 5, 0), true);
         }
         else
         {
            edtNegID_Enabled = 1;
            AssignProp("", false, edtNegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7NegID) )
         {
            edtNegID_Enabled = 0;
            AssignProp("", false, edtNegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegID_Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NefChave)) )
         {
            A626NefChave = AV8NefChave;
            AssignAttri("", false, "A626NefChave", A626NefChave);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NefChave)) )
         {
            cmbNefChave.Enabled = 0;
            AssignProp("", false, cmbNefChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNefChave.Enabled), 5, 0), true);
         }
         else
         {
            cmbNefChave.Enabled = 1;
            AssignProp("", false, cmbNefChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNefChave.Enabled), 5, 0), true);
         }
         if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV8NefChave)) )
         {
            cmbNefChave.Enabled = 0;
            AssignProp("", false, cmbNefChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNefChave.Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7NegID) )
         {
            A345NegID = AV7NegID;
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
         }
         else
         {
            A345NegID = AV20ComboNegID;
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
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
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load1944( )
      {
         /* Using cursor T00195 */
         pr_default.execute(3, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound44 = 1;
            A629NefInsDataHora = T00195_A629NefInsDataHora[0];
            AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A630NefInsData = T00195_A630NefInsData[0];
            AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
            A631NefInsHora = T00195_A631NefInsHora[0];
            AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
            A632NefInsUsuId = T00195_A632NefInsUsuId[0];
            AssignAttri("", false, "A632NefInsUsuId", A632NefInsUsuId);
            A633NefInsUsuNome = T00195_A633NefInsUsuNome[0];
            AssignAttri("", false, "A633NefInsUsuNome", A633NefInsUsuNome);
            A634NefUpdDataHora = T00195_A634NefUpdDataHora[0];
            n634NefUpdDataHora = T00195_n634NefUpdDataHora[0];
            AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A635NefUpdData = T00195_A635NefUpdData[0];
            n635NefUpdData = T00195_n635NefUpdData[0];
            AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
            A636NefUpdHora = T00195_A636NefUpdHora[0];
            n636NefUpdHora = T00195_n636NefUpdHora[0];
            AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
            A637NefUpdUsuId = T00195_A637NefUpdUsuId[0];
            n637NefUpdUsuId = T00195_n637NefUpdUsuId[0];
            AssignAttri("", false, "A637NefUpdUsuId", A637NefUpdUsuId);
            A638NefUpdUsuNome = T00195_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = T00195_n638NefUpdUsuNome[0];
            AssignAttri("", false, "A638NefUpdUsuNome", A638NefUpdUsuNome);
            A627NefConfirmado = T00195_A627NefConfirmado[0];
            AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
            A628NefTexto = T00195_A628NefTexto[0];
            n628NefTexto = T00195_n628NefTexto[0];
            AssignAttri("", false, "A628NefTexto", A628NefTexto);
            A639NefValor = T00195_A639NefValor[0];
            n639NefValor = T00195_n639NefValor[0];
            AssignAttri("", false, "A639NefValor", StringUtil.LTrimStr( (decimal)(A639NefValor), 3, 0));
            ZM1944( -24) ;
         }
         pr_default.close(3);
         OnLoadActions1944( ) ;
      }

      protected void OnLoadActions1944( )
      {
      }

      protected void CheckExtendedTable1944( )
      {
         nIsDirty_44 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00194 */
         pr_default.execute(2, new Object[] {A345NegID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
            AnyError = 1;
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(2);
         if ( ! ( ( StringUtil.StrCmp(A626NefChave, "DOCANALISE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCREGISTRARENVIOCAF") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCREGISTRARRETORNOCAF") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "DOCANALISECREDITO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPCONFECCIONAR") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPREGENVIOCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "PROPREGRESPCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONENTREGAGARANTIA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCOMPORGARANTIA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONVERIFICACONTAATIVA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCONTRATARPRODUTO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONCONFECCONTRATO") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONREGENVCONTCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONREGRESCONTCLIENTE") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ASSCONRECOLHERASSINATURA") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ENCREALIZADOONBOARD") == 0 ) || ( StringUtil.StrCmp(A626NefChave, "ENCPESQUISAAVALIACAO") == 0 ) ) )
         {
            GX_msglist.addItem("Campo Chave do Fluxo fora do intervalo", "OutOfRange", 1, "NEFCHAVE");
            AnyError = 1;
            GX_FocusControl = cmbNefChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1944( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_25( Guid A345NegID )
      {
         /* Using cursor T00196 */
         pr_default.execute(4, new Object[] {A345NegID});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
            AnyError = 1;
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey1944( )
      {
         /* Using cursor T00197 */
         pr_default.execute(5, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound44 = 1;
         }
         else
         {
            RcdFound44 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00193 */
         pr_default.execute(1, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1944( 24) ;
            RcdFound44 = 1;
            A626NefChave = T00193_A626NefChave[0];
            AssignAttri("", false, "A626NefChave", A626NefChave);
            A629NefInsDataHora = T00193_A629NefInsDataHora[0];
            AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A630NefInsData = T00193_A630NefInsData[0];
            AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
            A631NefInsHora = T00193_A631NefInsHora[0];
            AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
            A632NefInsUsuId = T00193_A632NefInsUsuId[0];
            AssignAttri("", false, "A632NefInsUsuId", A632NefInsUsuId);
            A633NefInsUsuNome = T00193_A633NefInsUsuNome[0];
            AssignAttri("", false, "A633NefInsUsuNome", A633NefInsUsuNome);
            A634NefUpdDataHora = T00193_A634NefUpdDataHora[0];
            n634NefUpdDataHora = T00193_n634NefUpdDataHora[0];
            AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
            A635NefUpdData = T00193_A635NefUpdData[0];
            n635NefUpdData = T00193_n635NefUpdData[0];
            AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
            A636NefUpdHora = T00193_A636NefUpdHora[0];
            n636NefUpdHora = T00193_n636NefUpdHora[0];
            AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
            A637NefUpdUsuId = T00193_A637NefUpdUsuId[0];
            n637NefUpdUsuId = T00193_n637NefUpdUsuId[0];
            AssignAttri("", false, "A637NefUpdUsuId", A637NefUpdUsuId);
            A638NefUpdUsuNome = T00193_A638NefUpdUsuNome[0];
            n638NefUpdUsuNome = T00193_n638NefUpdUsuNome[0];
            AssignAttri("", false, "A638NefUpdUsuNome", A638NefUpdUsuNome);
            A627NefConfirmado = T00193_A627NefConfirmado[0];
            AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
            A628NefTexto = T00193_A628NefTexto[0];
            n628NefTexto = T00193_n628NefTexto[0];
            AssignAttri("", false, "A628NefTexto", A628NefTexto);
            A639NefValor = T00193_A639NefValor[0];
            n639NefValor = T00193_n639NefValor[0];
            AssignAttri("", false, "A639NefValor", StringUtil.LTrimStr( (decimal)(A639NefValor), 3, 0));
            A345NegID = T00193_A345NegID[0];
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            Z345NegID = A345NegID;
            Z626NefChave = A626NefChave;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1944( ) ;
            if ( AnyError == 1 )
            {
               RcdFound44 = 0;
               InitializeNonKey1944( ) ;
            }
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound44 = 0;
            InitializeNonKey1944( ) ;
            sMode44 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode44;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1944( ) ;
         if ( RcdFound44 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound44 = 0;
         /* Using cursor T00198 */
         pr_default.execute(6, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00198_A345NegID[0], A345NegID, 0) < 0 ) || ( T00198_A345NegID[0] == A345NegID ) && ( StringUtil.StrCmp(T00198_A626NefChave[0], A626NefChave) < 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00198_A345NegID[0], A345NegID, 0) > 0 ) || ( T00198_A345NegID[0] == A345NegID ) && ( StringUtil.StrCmp(T00198_A626NefChave[0], A626NefChave) > 0 ) ) )
            {
               A345NegID = T00198_A345NegID[0];
               AssignAttri("", false, "A345NegID", A345NegID.ToString());
               A626NefChave = T00198_A626NefChave[0];
               AssignAttri("", false, "A626NefChave", A626NefChave);
               RcdFound44 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound44 = 0;
         /* Using cursor T00199 */
         pr_default.execute(7, new Object[] {A345NegID, A626NefChave});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00199_A345NegID[0], A345NegID, 0) > 0 ) || ( T00199_A345NegID[0] == A345NegID ) && ( StringUtil.StrCmp(T00199_A626NefChave[0], A626NefChave) > 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00199_A345NegID[0], A345NegID, 0) < 0 ) || ( T00199_A345NegID[0] == A345NegID ) && ( StringUtil.StrCmp(T00199_A626NefChave[0], A626NefChave) < 0 ) ) )
            {
               A345NegID = T00199_A345NegID[0];
               AssignAttri("", false, "A345NegID", A345NegID.ToString());
               A626NefChave = T00199_A626NefChave[0];
               AssignAttri("", false, "A626NefChave", A626NefChave);
               RcdFound44 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1944( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1944( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound44 == 1 )
            {
               if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
               {
                  A345NegID = Z345NegID;
                  AssignAttri("", false, "A345NegID", A345NegID.ToString());
                  A626NefChave = Z626NefChave;
                  AssignAttri("", false, "A626NefChave", A626NefChave);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "NEGID");
                  AnyError = 1;
                  GX_FocusControl = edtNegID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtNegID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1944( ) ;
                  GX_FocusControl = edtNegID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtNegID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1944( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "NEGID");
                     AnyError = 1;
                     GX_FocusControl = edtNegID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtNegID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1944( ) ;
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
         if ( ( A345NegID != Z345NegID ) || ( StringUtil.StrCmp(A626NefChave, Z626NefChave) != 0 ) )
         {
            A345NegID = Z345NegID;
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            A626NefChave = Z626NefChave;
            AssignAttri("", false, "A626NefChave", A626NefChave);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "NEGID");
            AnyError = 1;
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtNegID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1944( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00192 */
            pr_default.execute(0, new Object[] {A345NegID, A626NefChave});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fluxo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z629NefInsDataHora != T00192_A629NefInsDataHora[0] ) || ( Z630NefInsData != T00192_A630NefInsData[0] ) || ( Z631NefInsHora != T00192_A631NefInsHora[0] ) || ( StringUtil.StrCmp(Z632NefInsUsuId, T00192_A632NefInsUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z633NefInsUsuNome, T00192_A633NefInsUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z634NefUpdDataHora != T00192_A634NefUpdDataHora[0] ) || ( Z635NefUpdData != T00192_A635NefUpdData[0] ) || ( Z636NefUpdHora != T00192_A636NefUpdHora[0] ) || ( StringUtil.StrCmp(Z637NefUpdUsuId, T00192_A637NefUpdUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z638NefUpdUsuNome, T00192_A638NefUpdUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z627NefConfirmado != T00192_A627NefConfirmado[0] ) || ( StringUtil.StrCmp(Z628NefTexto, T00192_A628NefTexto[0]) != 0 ) || ( Z639NefValor != T00192_A639NefValor[0] ) )
            {
               if ( Z629NefInsDataHora != T00192_A629NefInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z629NefInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00192_A629NefInsDataHora[0]);
               }
               if ( Z630NefInsData != T00192_A630NefInsData[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefInsData");
                  GXUtil.WriteLogRaw("Old: ",Z630NefInsData);
                  GXUtil.WriteLogRaw("Current: ",T00192_A630NefInsData[0]);
               }
               if ( Z631NefInsHora != T00192_A631NefInsHora[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z631NefInsHora);
                  GXUtil.WriteLogRaw("Current: ",T00192_A631NefInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z632NefInsUsuId, T00192_A632NefInsUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefInsUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z632NefInsUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00192_A632NefInsUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z633NefInsUsuNome, T00192_A633NefInsUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefInsUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z633NefInsUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00192_A633NefInsUsuNome[0]);
               }
               if ( Z634NefUpdDataHora != T00192_A634NefUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z634NefUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00192_A634NefUpdDataHora[0]);
               }
               if ( Z635NefUpdData != T00192_A635NefUpdData[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z635NefUpdData);
                  GXUtil.WriteLogRaw("Current: ",T00192_A635NefUpdData[0]);
               }
               if ( Z636NefUpdHora != T00192_A636NefUpdHora[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z636NefUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T00192_A636NefUpdHora[0]);
               }
               if ( StringUtil.StrCmp(Z637NefUpdUsuId, T00192_A637NefUpdUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefUpdUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z637NefUpdUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00192_A637NefUpdUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z638NefUpdUsuNome, T00192_A638NefUpdUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefUpdUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z638NefUpdUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00192_A638NefUpdUsuNome[0]);
               }
               if ( Z627NefConfirmado != T00192_A627NefConfirmado[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefConfirmado");
                  GXUtil.WriteLogRaw("Old: ",Z627NefConfirmado);
                  GXUtil.WriteLogRaw("Current: ",T00192_A627NefConfirmado[0]);
               }
               if ( StringUtil.StrCmp(Z628NefTexto, T00192_A628NefTexto[0]) != 0 )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefTexto");
                  GXUtil.WriteLogRaw("Old: ",Z628NefTexto);
                  GXUtil.WriteLogRaw("Current: ",T00192_A628NefTexto[0]);
               }
               if ( Z639NefValor != T00192_A639NefValor[0] )
               {
                  GXUtil.WriteLog("core.negociopjfluxo:[seudo value changed for attri]"+"NefValor");
                  GXUtil.WriteLogRaw("Old: ",Z639NefValor);
                  GXUtil.WriteLogRaw("Current: ",T00192_A639NefValor[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_negociopj_fluxo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1944( )
      {
         if ( ! IsAuthorized("negociopjfluxo_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1944( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1944( 0) ;
            CheckOptimisticConcurrency1944( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1944( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1944( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001910 */
                     pr_default.execute(8, new Object[] {A626NefChave, A629NefInsDataHora, A630NefInsData, A631NefInsHora, A632NefInsUsuId, A633NefInsUsuNome, n634NefUpdDataHora, A634NefUpdDataHora, n635NefUpdData, A635NefUpdData, n636NefUpdHora, A636NefUpdHora, n637NefUpdUsuId, A637NefUpdUsuId, n638NefUpdUsuNome, A638NefUpdUsuNome, A627NefConfirmado, n628NefTexto, A628NefTexto, n639NefValor, A639NefValor, A345NegID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
                     if ( (pr_default.getStatus(8) == 1) )
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
                           ResetCaption190( ) ;
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
               Load1944( ) ;
            }
            EndLevel1944( ) ;
         }
         CloseExtendedTableCursors1944( ) ;
      }

      protected void Update1944( )
      {
         if ( ! IsAuthorized("negociopjfluxo_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1944( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1944( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1944( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1944( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001911 */
                     pr_default.execute(9, new Object[] {A629NefInsDataHora, A630NefInsData, A631NefInsHora, A632NefInsUsuId, A633NefInsUsuNome, n634NefUpdDataHora, A634NefUpdDataHora, n635NefUpdData, A635NefUpdData, n636NefUpdHora, A636NefUpdHora, n637NefUpdUsuId, A637NefUpdUsuId, n638NefUpdUsuNome, A638NefUpdUsuNome, A627NefConfirmado, n628NefTexto, A628NefTexto, n639NefValor, A639NefValor, A345NegID, A626NefChave});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
                     if ( (pr_default.getStatus(9) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_negociopj_fluxo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1944( ) ;
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
            EndLevel1944( ) ;
         }
         CloseExtendedTableCursors1944( ) ;
      }

      protected void DeferredUpdate1944( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("negociopjfluxo_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1944( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1944( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1944( ) ;
            AfterConfirm1944( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1944( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001912 */
                  pr_default.execute(10, new Object[] {A345NegID, A626NefChave});
                  pr_default.close(10);
                  pr_default.SmartCacheProvider.SetUpdated("tb_negociopj_fluxo");
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
         sMode44 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1944( ) ;
         Gx_mode = sMode44;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1944( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel1944( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1944( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.negociopjfluxo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues190( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.negociopjfluxo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1944( )
      {
         /* Scan By routine */
         /* Using cursor T001913 */
         pr_default.execute(11);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
            A345NegID = T001913_A345NegID[0];
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            A626NefChave = T001913_A626NefChave[0];
            AssignAttri("", false, "A626NefChave", A626NefChave);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1944( )
      {
         /* Scan next routine */
         pr_default.readNext(11);
         RcdFound44 = 0;
         if ( (pr_default.getStatus(11) != 101) )
         {
            RcdFound44 = 1;
            A345NegID = T001913_A345NegID[0];
            AssignAttri("", false, "A345NegID", A345NegID.ToString());
            A626NefChave = T001913_A626NefChave[0];
            AssignAttri("", false, "A626NefChave", A626NefChave);
         }
      }

      protected void ScanEnd1944( )
      {
         pr_default.close(11);
      }

      protected void AfterConfirm1944( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1944( )
      {
         /* Before Insert Rules */
         A629NefInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A632NefInsUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         AssignAttri("", false, "A632NefInsUsuId", A632NefInsUsuId);
         A633NefInsUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         AssignAttri("", false, "A633NefInsUsuNome", A633NefInsUsuNome);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A626NefChave)) || T00193_n626NefChave[0] )
         {
            GX_msglist.addItem("Não identificado a Chave do Fluxo do Negócio!", 1, "NEFCHAVE");
            AnyError = 1;
            GX_FocusControl = cmbNefChave_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A630NefInsData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A629NefInsDataHora) ) ;
         AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
         A631NefInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A629NefInsDataHora));
         AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate1944( )
      {
         /* Before Update Rules */
         A634NefUpdDataHora = DateTimeUtil.NowMS( context);
         n634NefUpdDataHora = false;
         AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A637NefUpdUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n637NefUpdUsuId = false;
         AssignAttri("", false, "A637NefUpdUsuId", A637NefUpdUsuId);
         A638NefUpdUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
         n638NefUpdUsuNome = false;
         AssignAttri("", false, "A638NefUpdUsuNome", A638NefUpdUsuNome);
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         A635NefUpdData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A634NefUpdDataHora) ) ;
         n635NefUpdData = false;
         AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
         A636NefUpdHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A634NefUpdDataHora));
         n636NefUpdHora = false;
         AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeDelete1944( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
      }

      protected void BeforeComplete1944( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1944( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1944( )
      {
         edtNegID_Enabled = 0;
         AssignProp("", false, edtNegID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNegID_Enabled), 5, 0), true);
         cmbNefChave.Enabled = 0;
         AssignProp("", false, cmbNefChave_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbNefChave.Enabled), 5, 0), true);
         chkNefConfirmado.Enabled = 0;
         AssignProp("", false, chkNefConfirmado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkNefConfirmado.Enabled), 5, 0), true);
         edtNefTexto_Enabled = 0;
         AssignProp("", false, edtNefTexto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefTexto_Enabled), 5, 0), true);
         edtNefInsDataHora_Enabled = 0;
         AssignProp("", false, edtNefInsDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefInsDataHora_Enabled), 5, 0), true);
         edtNefInsData_Enabled = 0;
         AssignProp("", false, edtNefInsData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefInsData_Enabled), 5, 0), true);
         edtNefInsHora_Enabled = 0;
         AssignProp("", false, edtNefInsHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefInsHora_Enabled), 5, 0), true);
         edtNefInsUsuId_Enabled = 0;
         AssignProp("", false, edtNefInsUsuId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefInsUsuId_Enabled), 5, 0), true);
         edtNefInsUsuNome_Enabled = 0;
         AssignProp("", false, edtNefInsUsuNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefInsUsuNome_Enabled), 5, 0), true);
         edtNefUpdDataHora_Enabled = 0;
         AssignProp("", false, edtNefUpdDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefUpdDataHora_Enabled), 5, 0), true);
         edtNefUpdData_Enabled = 0;
         AssignProp("", false, edtNefUpdData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefUpdData_Enabled), 5, 0), true);
         edtNefUpdHora_Enabled = 0;
         AssignProp("", false, edtNefUpdHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefUpdHora_Enabled), 5, 0), true);
         edtNefUpdUsuId_Enabled = 0;
         AssignProp("", false, edtNefUpdUsuId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefUpdUsuId_Enabled), 5, 0), true);
         edtNefUpdUsuNome_Enabled = 0;
         AssignProp("", false, edtNefUpdUsuNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefUpdUsuNome_Enabled), 5, 0), true);
         edtNefValor_Enabled = 0;
         AssignProp("", false, edtNefValor_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtNefValor_Enabled), 5, 0), true);
         edtavCombonegid_Enabled = 0;
         AssignProp("", false, edtavCombonegid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombonegid_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1944( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues190( )
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
         GXEncryptionTmp = "core.negociopjfluxo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8NefChave));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.negociopjfluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"NegocioPJFluxo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV23Pgmname, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\negociopjfluxo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z345NegID", Z345NegID.ToString());
         GxWebStd.gx_hidden_field( context, "Z626NefChave", Z626NefChave);
         GxWebStd.gx_hidden_field( context, "Z629NefInsDataHora", context.localUtil.TToC( Z629NefInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z630NefInsData", context.localUtil.TToC( Z630NefInsData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z631NefInsHora", context.localUtil.TToC( Z631NefInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z632NefInsUsuId", StringUtil.RTrim( Z632NefInsUsuId));
         GxWebStd.gx_hidden_field( context, "Z633NefInsUsuNome", Z633NefInsUsuNome);
         GxWebStd.gx_hidden_field( context, "Z634NefUpdDataHora", context.localUtil.TToC( Z634NefUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z635NefUpdData", context.localUtil.TToC( Z635NefUpdData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z636NefUpdHora", context.localUtil.TToC( Z636NefUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z637NefUpdUsuId", StringUtil.RTrim( Z637NefUpdUsuId));
         GxWebStd.gx_hidden_field( context, "Z638NefUpdUsuNome", Z638NefUpdUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z627NefConfirmado", Z627NefConfirmado);
         GxWebStd.gx_hidden_field( context, "Z628NefTexto", Z628NefTexto);
         GxWebStd.gx_hidden_field( context, "Z639NefValor", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z639NefValor), 3, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
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
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vNEGID_DATA", AV15NegID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vNEGID_DATA", AV15NegID_Data);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vNEGID", AV7NegID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vNEGID", GetSecureSignedToken( "", AV7NegID, context));
         GxWebStd.gx_hidden_field( context, "vNEFCHAVE", AV8NefChave);
         GxWebStd.gx_hidden_field( context, "gxhash_vNEFCHAVE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV8NefChave, "")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV12AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV12AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV23Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Objectcall", StringUtil.RTrim( Combo_negid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Cls", StringUtil.RTrim( Combo_negid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Selectedvalue_set", StringUtil.RTrim( Combo_negid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Selectedtext_set", StringUtil.RTrim( Combo_negid_Selectedtext_set));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Gamoauthtoken", StringUtil.RTrim( Combo_negid_Gamoauthtoken));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Enabled", StringUtil.BoolToStr( Combo_negid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Datalistproc", StringUtil.RTrim( Combo_negid_Datalistproc));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Datalistprocparametersprefix", StringUtil.RTrim( Combo_negid_Datalistprocparametersprefix));
         GxWebStd.gx_hidden_field( context, "COMBO_NEGID_Emptyitem", StringUtil.BoolToStr( Combo_negid_Emptyitem));
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
         GXEncryptionTmp = "core.negociopjfluxo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7NegID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV8NefChave));
         return formatLink("core.negociopjfluxo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.NegocioPJFluxo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Fluxo do Negócio" ;
      }

      protected void InitializeNonKey1944( )
      {
         AV12AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A629NefInsDataHora", context.localUtil.TToC( A629NefInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A630NefInsData = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A630NefInsData", context.localUtil.TToC( A630NefInsData, 10, 5, 0, 3, "/", ":", " "));
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A631NefInsHora", context.localUtil.TToC( A631NefInsHora, 0, 5, 0, 3, "/", ":", " "));
         A632NefInsUsuId = "";
         AssignAttri("", false, "A632NefInsUsuId", A632NefInsUsuId);
         A633NefInsUsuNome = "";
         AssignAttri("", false, "A633NefInsUsuNome", A633NefInsUsuNome);
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         n634NefUpdDataHora = false;
         AssignAttri("", false, "A634NefUpdDataHora", context.localUtil.TToC( A634NefUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         n634NefUpdDataHora = ((DateTime.MinValue==A634NefUpdDataHora) ? true : false);
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         n635NefUpdData = false;
         AssignAttri("", false, "A635NefUpdData", context.localUtil.TToC( A635NefUpdData, 10, 5, 0, 3, "/", ":", " "));
         n635NefUpdData = ((DateTime.MinValue==A635NefUpdData) ? true : false);
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         n636NefUpdHora = false;
         AssignAttri("", false, "A636NefUpdHora", context.localUtil.TToC( A636NefUpdHora, 0, 5, 0, 3, "/", ":", " "));
         n636NefUpdHora = ((DateTime.MinValue==A636NefUpdHora) ? true : false);
         A637NefUpdUsuId = "";
         n637NefUpdUsuId = false;
         AssignAttri("", false, "A637NefUpdUsuId", A637NefUpdUsuId);
         n637NefUpdUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A637NefUpdUsuId)) ? true : false);
         A638NefUpdUsuNome = "";
         n638NefUpdUsuNome = false;
         AssignAttri("", false, "A638NefUpdUsuNome", A638NefUpdUsuNome);
         n638NefUpdUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A638NefUpdUsuNome)) ? true : false);
         A627NefConfirmado = false;
         AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
         A628NefTexto = "";
         n628NefTexto = false;
         AssignAttri("", false, "A628NefTexto", A628NefTexto);
         n628NefTexto = (String.IsNullOrEmpty(StringUtil.RTrim( A628NefTexto)) ? true : false);
         A639NefValor = 0;
         n639NefValor = false;
         AssignAttri("", false, "A639NefValor", StringUtil.LTrimStr( (decimal)(A639NefValor), 3, 0));
         n639NefValor = ((0==A639NefValor) ? true : false);
         Z629NefInsDataHora = (DateTime)(DateTime.MinValue);
         Z630NefInsData = (DateTime)(DateTime.MinValue);
         Z631NefInsHora = (DateTime)(DateTime.MinValue);
         Z632NefInsUsuId = "";
         Z633NefInsUsuNome = "";
         Z634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         Z635NefUpdData = (DateTime)(DateTime.MinValue);
         Z636NefUpdHora = (DateTime)(DateTime.MinValue);
         Z637NefUpdUsuId = "";
         Z638NefUpdUsuNome = "";
         Z627NefConfirmado = false;
         Z628NefTexto = "";
         Z639NefValor = 0;
      }

      protected void InitAll1944( )
      {
         A345NegID = Guid.Empty;
         AssignAttri("", false, "A345NegID", A345NegID.ToString());
         A626NefChave = "";
         AssignAttri("", false, "A626NefChave", A626NefChave);
         InitializeNonKey1944( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023821394188", true, true);
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
         context.AddJavascriptSource("core/negociopjfluxo.js", "?2023821394189", false, true);
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
         lblTextblocknegid_Internalname = "TEXTBLOCKNEGID";
         Combo_negid_Internalname = "COMBO_NEGID";
         edtNegID_Internalname = "NEGID";
         divTablesplittednegid_Internalname = "TABLESPLITTEDNEGID";
         cmbNefChave_Internalname = "NEFCHAVE";
         chkNefConfirmado_Internalname = "NEFCONFIRMADO";
         edtNefTexto_Internalname = "NEFTEXTO";
         edtNefInsDataHora_Internalname = "NEFINSDATAHORA";
         edtNefInsData_Internalname = "NEFINSDATA";
         edtNefInsHora_Internalname = "NEFINSHORA";
         edtNefInsUsuId_Internalname = "NEFINSUSUID";
         edtNefInsUsuNome_Internalname = "NEFINSUSUNOME";
         edtNefUpdDataHora_Internalname = "NEFUPDDATAHORA";
         edtNefUpdData_Internalname = "NEFUPDDATA";
         edtNefUpdHora_Internalname = "NEFUPDHORA";
         edtNefUpdUsuId_Internalname = "NEFUPDUSUID";
         edtNefUpdUsuNome_Internalname = "NEFUPDUSUNOME";
         edtNefValor_Internalname = "NEFVALOR";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombonegid_Internalname = "vCOMBONEGID";
         divSectionattribute_negid_Internalname = "SECTIONATTRIBUTE_NEGID";
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
         Form.Caption = "Fluxo do Negócio";
         edtavCombonegid_Jsonclick = "";
         edtavCombonegid_Enabled = 0;
         edtavCombonegid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtNefValor_Jsonclick = "";
         edtNefValor_Enabled = 1;
         edtNefUpdUsuNome_Jsonclick = "";
         edtNefUpdUsuNome_Enabled = 1;
         edtNefUpdUsuId_Jsonclick = "";
         edtNefUpdUsuId_Enabled = 1;
         edtNefUpdHora_Jsonclick = "";
         edtNefUpdHora_Enabled = 1;
         edtNefUpdData_Jsonclick = "";
         edtNefUpdData_Enabled = 1;
         edtNefUpdDataHora_Jsonclick = "";
         edtNefUpdDataHora_Enabled = 1;
         edtNefInsUsuNome_Jsonclick = "";
         edtNefInsUsuNome_Enabled = 1;
         edtNefInsUsuId_Jsonclick = "";
         edtNefInsUsuId_Enabled = 1;
         edtNefInsHora_Jsonclick = "";
         edtNefInsHora_Enabled = 1;
         edtNefInsData_Jsonclick = "";
         edtNefInsData_Enabled = 1;
         edtNefInsDataHora_Jsonclick = "";
         edtNefInsDataHora_Enabled = 1;
         edtNefTexto_Enabled = 1;
         chkNefConfirmado.Enabled = 1;
         cmbNefChave_Jsonclick = "";
         cmbNefChave.Enabled = 1;
         edtNegID_Jsonclick = "";
         edtNegID_Enabled = 1;
         edtNegID_Visible = 1;
         Combo_negid_Emptyitem = Convert.ToBoolean( 0);
         Combo_negid_Datalistprocparametersprefix = " \"ComboName\": \"NegID\", \"TrnMode\": \"INS\", \"IsDynamicCall\": true, \"NegID\": \"00000000-0000-0000-0000-000000000000\", \"NefChave\": \"\"";
         Combo_negid_Datalistproc = "core.NegocioPJFluxoLoadDVCombo";
         Combo_negid_Cls = "ExtendedCombo AttributeFL";
         Combo_negid_Caption = "";
         Combo_negid_Enabled = Convert.ToBoolean( -1);
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

      protected void XC_19_1944( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ,
                                 Guid A345NegID ,
                                 string A626NefChave ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV12AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_20_1944( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ,
                                 Guid A345NegID ,
                                 string A626NefChave ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "Y", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV12AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_21_1944( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ,
                                 Guid A345NegID ,
                                 string A626NefChave )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV12AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_22_1944( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ,
                                 Guid A345NegID ,
                                 string A626NefChave )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditnegociopjfluxo(context ).execute(  "N", ref  AV12AuditingObject,  A345NegID,  A626NefChave,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV12AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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
         cmbNefChave.Name = "NEFCHAVE";
         cmbNefChave.WebTags = "";
         cmbNefChave.addItem("DOCANALISE", "Análise da Documentação", 0);
         cmbNefChave.addItem("DOCREGISTRARENVIOCAF", "Regisrtrar Envio ao CAF", 0);
         cmbNefChave.addItem("DOCREGISTRARRETORNOCAF", "Registrar Retorno do CAF", 0);
         cmbNefChave.addItem("DOCANALISECREDITO", "Análise de Crédito", 0);
         cmbNefChave.addItem("PROPCONFECCIONAR", "Proposta Comercial Confeccionada", 0);
         cmbNefChave.addItem("PROPREGENVIOCLIENTE", "Registrar Envio da Proposta ao Cliente", 0);
         cmbNefChave.addItem("PROPREGRESPCLIENTE", "Registrar Resposta da Proposta pelo Cliente", 0);
         cmbNefChave.addItem("ASSCONENTREGAGARANTIA", "Entrega da Garantia", 0);
         cmbNefChave.addItem("ASSCONCOMPORGARANTIA", "Compor a Garantia", 0);
         cmbNefChave.addItem("ASSCONVERIFICACONTAATIVA", "Verifica existência de conta bancária ativa", 0);
         cmbNefChave.addItem("ASSCONCONTRATARPRODUTO", "Contratar Produto", 0);
         cmbNefChave.addItem("ASSCONCONFECCONTRATO", "Confeccionar Contrato", 0);
         cmbNefChave.addItem("ASSCONREGENVCONTCLIENTE", "Registrar Envio do Contrato ao Cliente", 0);
         cmbNefChave.addItem("ASSCONREGRESCONTCLIENTE", "Registrar Resposta do Contrato do Cliente", 0);
         cmbNefChave.addItem("ASSCONRECOLHERASSINATURA", "Recolher Assinaturas", 0);
         cmbNefChave.addItem("ENCREALIZADOONBOARD", "Realizado OnBoard?", 0);
         cmbNefChave.addItem("ENCPESQUISAAVALIACAO", "Pesquisa de Avaliação Realizada?", 0);
         if ( cmbNefChave.ItemCount > 0 )
         {
            A626NefChave = cmbNefChave.getValidValue(A626NefChave);
            AssignAttri("", false, "A626NefChave", A626NefChave);
         }
         chkNefConfirmado.Name = "NEFCONFIRMADO";
         chkNefConfirmado.WebTags = "";
         chkNefConfirmado.Caption = "";
         AssignProp("", false, chkNefConfirmado_Internalname, "TitleCaption", chkNefConfirmado.Caption, true);
         chkNefConfirmado.CheckedValue = "false";
         A627NefConfirmado = StringUtil.StrToBool( StringUtil.BoolToStr( A627NefConfirmado));
         AssignAttri("", false, "A627NefConfirmado", A627NefConfirmado);
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

      public void Valid_Negid( )
      {
         /* Using cursor T001914 */
         pr_default.execute(12, new Object[] {A345NegID});
         if ( (pr_default.getStatus(12) == 101) )
         {
            GX_msglist.addItem("Não existe 'Oportunidade de Negócio'.", "ForeignKeyNotFound", 1, "NEGID");
            AnyError = 1;
            GX_FocusControl = edtNegID_Internalname;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         if ( cmbNefChave.ItemCount > 0 )
         {
            A626NefChave = cmbNefChave.getValidValue(A626NefChave);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbNefChave.CurrentValue = StringUtil.RTrim( A626NefChave);
         }
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7NegID',fld:'vNEGID',pic:'',hsh:true},{av:'AV8NefChave',fld:'vNEFCHAVE',pic:'',hsh:true},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7NegID',fld:'vNEGID',pic:'',hsh:true},{av:'AV8NefChave',fld:'vNEFCHAVE',pic:'',hsh:true},{av:'AV23Pgmname',fld:'vPGMNAME',pic:''},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E13192',iparms:[{av:'AV12AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV23Pgmname',fld:'vPGMNAME',pic:''},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("COMBO_NEGID.ONOPTIONCLICKED","{handler:'E12192',iparms:[{av:'Combo_negid_Selectedvalue_get',ctrl:'COMBO_NEGID',prop:'SelectedValue_get'},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("COMBO_NEGID.ONOPTIONCLICKED",",oparms:[{av:'AV20ComboNegID',fld:'vCOMBONEGID',pic:''},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("VALID_NEGID","{handler:'Valid_Negid',iparms:[{av:'A345NegID',fld:'NEGID',pic:''},{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("VALID_NEGID",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("VALID_NEFCHAVE","{handler:'Valid_Nefchave',iparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("VALID_NEFCHAVE",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("VALID_NEFINSDATAHORA","{handler:'Valid_Nefinsdatahora',iparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("VALID_NEFINSDATAHORA",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("VALID_NEFUPDDATAHORA","{handler:'Valid_Nefupddatahora',iparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("VALID_NEFUPDDATAHORA",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
         setEventMetadata("VALIDV_COMBONEGID","{handler:'Validv_Combonegid',iparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]");
         setEventMetadata("VALIDV_COMBONEGID",",oparms:[{av:'A627NefConfirmado',fld:'NEFCONFIRMADO',pic:''}]}");
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
         wcpOAV7NegID = Guid.Empty;
         wcpOAV8NefChave = "";
         Z345NegID = Guid.Empty;
         Z626NefChave = "";
         Z629NefInsDataHora = (DateTime)(DateTime.MinValue);
         Z630NefInsData = (DateTime)(DateTime.MinValue);
         Z631NefInsHora = (DateTime)(DateTime.MinValue);
         Z632NefInsUsuId = "";
         Z633NefInsUsuNome = "";
         Z634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         Z635NefUpdData = (DateTime)(DateTime.MinValue);
         Z636NefUpdHora = (DateTime)(DateTime.MinValue);
         Z637NefUpdUsuId = "";
         Z638NefUpdUsuNome = "";
         Z628NefTexto = "";
         Combo_negid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A345NegID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         A626NefChave = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         lblTextblocknegid_Jsonclick = "";
         ucCombo_negid = new GXUserControl();
         AV16DDO_TitleSettingsIcons = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV15NegID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         TempTags = "";
         A628NefTexto = "";
         A629NefInsDataHora = (DateTime)(DateTime.MinValue);
         A630NefInsData = (DateTime)(DateTime.MinValue);
         A631NefInsHora = (DateTime)(DateTime.MinValue);
         A632NefInsUsuId = "";
         A633NefInsUsuNome = "";
         A634NefUpdDataHora = (DateTime)(DateTime.MinValue);
         A635NefUpdData = (DateTime)(DateTime.MinValue);
         A636NefUpdHora = (DateTime)(DateTime.MinValue);
         A637NefUpdUsuId = "";
         A638NefUpdUsuNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         AV20ComboNegID = Guid.Empty;
         AV12AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV23Pgmname = "";
         Combo_negid_Objectcall = "";
         Combo_negid_Class = "";
         Combo_negid_Icontype = "";
         Combo_negid_Icon = "";
         Combo_negid_Tooltip = "";
         Combo_negid_Selectedvalue_set = "";
         Combo_negid_Selectedtext_set = "";
         Combo_negid_Selectedtext_get = "";
         Combo_negid_Gamoauthtoken = "";
         Combo_negid_Ddointernalname = "";
         Combo_negid_Titlecontrolalign = "";
         Combo_negid_Dropdownoptionstype = "";
         Combo_negid_Titlecontrolidtoreplace = "";
         Combo_negid_Datalisttype = "";
         Combo_negid_Datalistfixedvalues = "";
         Combo_negid_Remoteservicesparameters = "";
         Combo_negid_Htmltemplate = "";
         Combo_negid_Multiplevaluestype = "";
         Combo_negid_Loadingdata = "";
         Combo_negid_Noresultsfound = "";
         Combo_negid_Emptyitemtext = "";
         Combo_negid_Onlyselectedvalues = "";
         Combo_negid_Selectalltext = "";
         Combo_negid_Multiplevaluesseparator = "";
         Combo_negid_Addnewoptiontext = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode44 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV9WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 = new GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons(context);
         AV21GAMSession = new GeneXus.Programs.genexussecurity.SdtGAMSession(context);
         AV22GAMErrors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV13TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV14WebSession = context.GetSession();
         AV19Combo_DataJson = "";
         GXt_char2 = "";
         AV17ComboSelectedValue = "";
         AV18ComboSelectedText = "";
         T00195_A626NefChave = new string[] {""} ;
         T00195_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00195_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         T00195_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         T00195_A632NefInsUsuId = new string[] {""} ;
         T00195_A633NefInsUsuNome = new string[] {""} ;
         T00195_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00195_n634NefUpdDataHora = new bool[] {false} ;
         T00195_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         T00195_n635NefUpdData = new bool[] {false} ;
         T00195_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00195_n636NefUpdHora = new bool[] {false} ;
         T00195_A637NefUpdUsuId = new string[] {""} ;
         T00195_n637NefUpdUsuId = new bool[] {false} ;
         T00195_A638NefUpdUsuNome = new string[] {""} ;
         T00195_n638NefUpdUsuNome = new bool[] {false} ;
         T00195_A627NefConfirmado = new bool[] {false} ;
         T00195_A628NefTexto = new string[] {""} ;
         T00195_n628NefTexto = new bool[] {false} ;
         T00195_A639NefValor = new short[1] ;
         T00195_n639NefValor = new bool[] {false} ;
         T00195_A345NegID = new Guid[] {Guid.Empty} ;
         T00194_A345NegID = new Guid[] {Guid.Empty} ;
         T00196_A345NegID = new Guid[] {Guid.Empty} ;
         T00197_A345NegID = new Guid[] {Guid.Empty} ;
         T00197_A626NefChave = new string[] {""} ;
         T00193_A626NefChave = new string[] {""} ;
         T00193_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00193_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         T00193_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         T00193_A632NefInsUsuId = new string[] {""} ;
         T00193_A633NefInsUsuNome = new string[] {""} ;
         T00193_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00193_n634NefUpdDataHora = new bool[] {false} ;
         T00193_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         T00193_n635NefUpdData = new bool[] {false} ;
         T00193_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00193_n636NefUpdHora = new bool[] {false} ;
         T00193_A637NefUpdUsuId = new string[] {""} ;
         T00193_n637NefUpdUsuId = new bool[] {false} ;
         T00193_A638NefUpdUsuNome = new string[] {""} ;
         T00193_n638NefUpdUsuNome = new bool[] {false} ;
         T00193_A627NefConfirmado = new bool[] {false} ;
         T00193_A628NefTexto = new string[] {""} ;
         T00193_n628NefTexto = new bool[] {false} ;
         T00193_A639NefValor = new short[1] ;
         T00193_n639NefValor = new bool[] {false} ;
         T00193_A345NegID = new Guid[] {Guid.Empty} ;
         T00198_A345NegID = new Guid[] {Guid.Empty} ;
         T00198_A626NefChave = new string[] {""} ;
         T00199_A345NegID = new Guid[] {Guid.Empty} ;
         T00199_A626NefChave = new string[] {""} ;
         T00192_A626NefChave = new string[] {""} ;
         T00192_A629NefInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00192_A630NefInsData = new DateTime[] {DateTime.MinValue} ;
         T00192_A631NefInsHora = new DateTime[] {DateTime.MinValue} ;
         T00192_A632NefInsUsuId = new string[] {""} ;
         T00192_A633NefInsUsuNome = new string[] {""} ;
         T00192_A634NefUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00192_n634NefUpdDataHora = new bool[] {false} ;
         T00192_A635NefUpdData = new DateTime[] {DateTime.MinValue} ;
         T00192_n635NefUpdData = new bool[] {false} ;
         T00192_A636NefUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00192_n636NefUpdHora = new bool[] {false} ;
         T00192_A637NefUpdUsuId = new string[] {""} ;
         T00192_n637NefUpdUsuId = new bool[] {false} ;
         T00192_A638NefUpdUsuNome = new string[] {""} ;
         T00192_n638NefUpdUsuNome = new bool[] {false} ;
         T00192_A627NefConfirmado = new bool[] {false} ;
         T00192_A628NefTexto = new string[] {""} ;
         T00192_n628NefTexto = new bool[] {false} ;
         T00192_A639NefValor = new short[1] ;
         T00192_n639NefValor = new bool[] {false} ;
         T00192_A345NegID = new Guid[] {Guid.Empty} ;
         T001913_A345NegID = new Guid[] {Guid.Empty} ;
         T001913_A626NefChave = new string[] {""} ;
         T00193_n626NefChave = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001914_A345NegID = new Guid[] {Guid.Empty} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjfluxo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.negociopjfluxo__default(),
            new Object[][] {
                new Object[] {
               T00192_A626NefChave, T00192_A629NefInsDataHora, T00192_A630NefInsData, T00192_A631NefInsHora, T00192_A632NefInsUsuId, T00192_A633NefInsUsuNome, T00192_A634NefUpdDataHora, T00192_n634NefUpdDataHora, T00192_A635NefUpdData, T00192_n635NefUpdData,
               T00192_A636NefUpdHora, T00192_n636NefUpdHora, T00192_A637NefUpdUsuId, T00192_n637NefUpdUsuId, T00192_A638NefUpdUsuNome, T00192_n638NefUpdUsuNome, T00192_A627NefConfirmado, T00192_A628NefTexto, T00192_n628NefTexto, T00192_A639NefValor,
               T00192_n639NefValor, T00192_A345NegID
               }
               , new Object[] {
               T00193_A626NefChave, T00193_A629NefInsDataHora, T00193_A630NefInsData, T00193_A631NefInsHora, T00193_A632NefInsUsuId, T00193_A633NefInsUsuNome, T00193_A634NefUpdDataHora, T00193_n634NefUpdDataHora, T00193_A635NefUpdData, T00193_n635NefUpdData,
               T00193_A636NefUpdHora, T00193_n636NefUpdHora, T00193_A637NefUpdUsuId, T00193_n637NefUpdUsuId, T00193_A638NefUpdUsuNome, T00193_n638NefUpdUsuNome, T00193_A627NefConfirmado, T00193_A628NefTexto, T00193_n628NefTexto, T00193_A639NefValor,
               T00193_n639NefValor, T00193_A345NegID
               }
               , new Object[] {
               T00194_A345NegID
               }
               , new Object[] {
               T00195_A626NefChave, T00195_A629NefInsDataHora, T00195_A630NefInsData, T00195_A631NefInsHora, T00195_A632NefInsUsuId, T00195_A633NefInsUsuNome, T00195_A634NefUpdDataHora, T00195_n634NefUpdDataHora, T00195_A635NefUpdData, T00195_n635NefUpdData,
               T00195_A636NefUpdHora, T00195_n636NefUpdHora, T00195_A637NefUpdUsuId, T00195_n637NefUpdUsuId, T00195_A638NefUpdUsuNome, T00195_n638NefUpdUsuNome, T00195_A627NefConfirmado, T00195_A628NefTexto, T00195_n628NefTexto, T00195_A639NefValor,
               T00195_n639NefValor, T00195_A345NegID
               }
               , new Object[] {
               T00196_A345NegID
               }
               , new Object[] {
               T00197_A345NegID, T00197_A626NefChave
               }
               , new Object[] {
               T00198_A345NegID, T00198_A626NefChave
               }
               , new Object[] {
               T00199_A345NegID, T00199_A626NefChave
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001913_A345NegID, T001913_A626NefChave
               }
               , new Object[] {
               T001914_A345NegID
               }
            }
         );
         AV23Pgmname = "core.NegocioPJFluxo";
      }

      private short Z639NefValor ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A639NefValor ;
      private short RcdFound44 ;
      private short GX_JID ;
      private short Gx_BScreen ;
      private short nIsDirty_44 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int edtNegID_Visible ;
      private int edtNegID_Enabled ;
      private int edtNefTexto_Enabled ;
      private int edtNefInsDataHora_Enabled ;
      private int edtNefInsData_Enabled ;
      private int edtNefInsHora_Enabled ;
      private int edtNefInsUsuId_Enabled ;
      private int edtNefInsUsuNome_Enabled ;
      private int edtNefUpdDataHora_Enabled ;
      private int edtNefUpdData_Enabled ;
      private int edtNefUpdHora_Enabled ;
      private int edtNefUpdUsuId_Enabled ;
      private int edtNefUpdUsuNome_Enabled ;
      private int edtNefValor_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtavCombonegid_Visible ;
      private int edtavCombonegid_Enabled ;
      private int Combo_negid_Datalistupdateminimumcharacters ;
      private int Combo_negid_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z632NefInsUsuId ;
      private string Z637NefUpdUsuId ;
      private string Combo_negid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtNegID_Internalname ;
      private string cmbNefChave_Internalname ;
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
      private string divTablesplittednegid_Internalname ;
      private string lblTextblocknegid_Internalname ;
      private string lblTextblocknegid_Jsonclick ;
      private string Combo_negid_Caption ;
      private string Combo_negid_Cls ;
      private string Combo_negid_Datalistproc ;
      private string Combo_negid_Datalistprocparametersprefix ;
      private string Combo_negid_Internalname ;
      private string TempTags ;
      private string edtNegID_Jsonclick ;
      private string cmbNefChave_Jsonclick ;
      private string chkNefConfirmado_Internalname ;
      private string edtNefTexto_Internalname ;
      private string edtNefInsDataHora_Internalname ;
      private string edtNefInsDataHora_Jsonclick ;
      private string edtNefInsData_Internalname ;
      private string edtNefInsData_Jsonclick ;
      private string edtNefInsHora_Internalname ;
      private string edtNefInsHora_Jsonclick ;
      private string edtNefInsUsuId_Internalname ;
      private string A632NefInsUsuId ;
      private string edtNefInsUsuId_Jsonclick ;
      private string edtNefInsUsuNome_Internalname ;
      private string edtNefInsUsuNome_Jsonclick ;
      private string edtNefUpdDataHora_Internalname ;
      private string edtNefUpdDataHora_Jsonclick ;
      private string edtNefUpdData_Internalname ;
      private string edtNefUpdData_Jsonclick ;
      private string edtNefUpdHora_Internalname ;
      private string edtNefUpdHora_Jsonclick ;
      private string edtNefUpdUsuId_Internalname ;
      private string A637NefUpdUsuId ;
      private string edtNefUpdUsuId_Jsonclick ;
      private string edtNefUpdUsuNome_Internalname ;
      private string edtNefUpdUsuNome_Jsonclick ;
      private string edtNefValor_Internalname ;
      private string edtNefValor_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_negid_Internalname ;
      private string edtavCombonegid_Internalname ;
      private string edtavCombonegid_Jsonclick ;
      private string AV23Pgmname ;
      private string Combo_negid_Objectcall ;
      private string Combo_negid_Class ;
      private string Combo_negid_Icontype ;
      private string Combo_negid_Icon ;
      private string Combo_negid_Tooltip ;
      private string Combo_negid_Selectedvalue_set ;
      private string Combo_negid_Selectedtext_set ;
      private string Combo_negid_Selectedtext_get ;
      private string Combo_negid_Gamoauthtoken ;
      private string Combo_negid_Ddointernalname ;
      private string Combo_negid_Titlecontrolalign ;
      private string Combo_negid_Dropdownoptionstype ;
      private string Combo_negid_Titlecontrolidtoreplace ;
      private string Combo_negid_Datalisttype ;
      private string Combo_negid_Datalistfixedvalues ;
      private string Combo_negid_Remoteservicesparameters ;
      private string Combo_negid_Htmltemplate ;
      private string Combo_negid_Multiplevaluestype ;
      private string Combo_negid_Loadingdata ;
      private string Combo_negid_Noresultsfound ;
      private string Combo_negid_Emptyitemtext ;
      private string Combo_negid_Onlyselectedvalues ;
      private string Combo_negid_Selectalltext ;
      private string Combo_negid_Multiplevaluesseparator ;
      private string Combo_negid_Addnewoptiontext ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode44 ;
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
      private DateTime Z629NefInsDataHora ;
      private DateTime Z630NefInsData ;
      private DateTime Z631NefInsHora ;
      private DateTime Z634NefUpdDataHora ;
      private DateTime Z635NefUpdData ;
      private DateTime Z636NefUpdHora ;
      private DateTime A629NefInsDataHora ;
      private DateTime A630NefInsData ;
      private DateTime A631NefInsHora ;
      private DateTime A634NefUpdDataHora ;
      private DateTime A635NefUpdData ;
      private DateTime A636NefUpdHora ;
      private bool Z627NefConfirmado ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A627NefConfirmado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Combo_negid_Emptyitem ;
      private bool n634NefUpdDataHora ;
      private bool n635NefUpdData ;
      private bool n636NefUpdHora ;
      private bool n637NefUpdUsuId ;
      private bool n638NefUpdUsuNome ;
      private bool n628NefTexto ;
      private bool n639NefValor ;
      private bool Combo_negid_Enabled ;
      private bool Combo_negid_Visible ;
      private bool Combo_negid_Allowmultipleselection ;
      private bool Combo_negid_Isgriditem ;
      private bool Combo_negid_Hasdescription ;
      private bool Combo_negid_Includeonlyselectedoption ;
      private bool Combo_negid_Includeselectalloption ;
      private bool Combo_negid_Includeaddnewoption ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private string AV19Combo_DataJson ;
      private string wcpOAV8NefChave ;
      private string Z626NefChave ;
      private string Z633NefInsUsuNome ;
      private string Z638NefUpdUsuNome ;
      private string Z628NefTexto ;
      private string AV8NefChave ;
      private string A626NefChave ;
      private string A628NefTexto ;
      private string A633NefInsUsuNome ;
      private string A638NefUpdUsuNome ;
      private string AV17ComboSelectedValue ;
      private string AV18ComboSelectedText ;
      private Guid wcpOAV7NegID ;
      private Guid Z345NegID ;
      private Guid A345NegID ;
      private Guid AV7NegID ;
      private Guid AV20ComboNegID ;
      private IGxSession AV14WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_negid ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbNefChave ;
      private GXCheckbox chkNefConfirmado ;
      private IDataStoreProvider pr_default ;
      private string[] T00195_A626NefChave ;
      private DateTime[] T00195_A629NefInsDataHora ;
      private DateTime[] T00195_A630NefInsData ;
      private DateTime[] T00195_A631NefInsHora ;
      private string[] T00195_A632NefInsUsuId ;
      private string[] T00195_A633NefInsUsuNome ;
      private DateTime[] T00195_A634NefUpdDataHora ;
      private bool[] T00195_n634NefUpdDataHora ;
      private DateTime[] T00195_A635NefUpdData ;
      private bool[] T00195_n635NefUpdData ;
      private DateTime[] T00195_A636NefUpdHora ;
      private bool[] T00195_n636NefUpdHora ;
      private string[] T00195_A637NefUpdUsuId ;
      private bool[] T00195_n637NefUpdUsuId ;
      private string[] T00195_A638NefUpdUsuNome ;
      private bool[] T00195_n638NefUpdUsuNome ;
      private bool[] T00195_A627NefConfirmado ;
      private string[] T00195_A628NefTexto ;
      private bool[] T00195_n628NefTexto ;
      private short[] T00195_A639NefValor ;
      private bool[] T00195_n639NefValor ;
      private Guid[] T00195_A345NegID ;
      private Guid[] T00194_A345NegID ;
      private Guid[] T00196_A345NegID ;
      private Guid[] T00197_A345NegID ;
      private string[] T00197_A626NefChave ;
      private string[] T00193_A626NefChave ;
      private DateTime[] T00193_A629NefInsDataHora ;
      private DateTime[] T00193_A630NefInsData ;
      private DateTime[] T00193_A631NefInsHora ;
      private string[] T00193_A632NefInsUsuId ;
      private string[] T00193_A633NefInsUsuNome ;
      private DateTime[] T00193_A634NefUpdDataHora ;
      private bool[] T00193_n634NefUpdDataHora ;
      private DateTime[] T00193_A635NefUpdData ;
      private bool[] T00193_n635NefUpdData ;
      private DateTime[] T00193_A636NefUpdHora ;
      private bool[] T00193_n636NefUpdHora ;
      private string[] T00193_A637NefUpdUsuId ;
      private bool[] T00193_n637NefUpdUsuId ;
      private string[] T00193_A638NefUpdUsuNome ;
      private bool[] T00193_n638NefUpdUsuNome ;
      private bool[] T00193_A627NefConfirmado ;
      private string[] T00193_A628NefTexto ;
      private bool[] T00193_n628NefTexto ;
      private short[] T00193_A639NefValor ;
      private bool[] T00193_n639NefValor ;
      private Guid[] T00193_A345NegID ;
      private Guid[] T00198_A345NegID ;
      private string[] T00198_A626NefChave ;
      private Guid[] T00199_A345NegID ;
      private string[] T00199_A626NefChave ;
      private string[] T00192_A626NefChave ;
      private DateTime[] T00192_A629NefInsDataHora ;
      private DateTime[] T00192_A630NefInsData ;
      private DateTime[] T00192_A631NefInsHora ;
      private string[] T00192_A632NefInsUsuId ;
      private string[] T00192_A633NefInsUsuNome ;
      private DateTime[] T00192_A634NefUpdDataHora ;
      private bool[] T00192_n634NefUpdDataHora ;
      private DateTime[] T00192_A635NefUpdData ;
      private bool[] T00192_n635NefUpdData ;
      private DateTime[] T00192_A636NefUpdHora ;
      private bool[] T00192_n636NefUpdHora ;
      private string[] T00192_A637NefUpdUsuId ;
      private bool[] T00192_n637NefUpdUsuId ;
      private string[] T00192_A638NefUpdUsuNome ;
      private bool[] T00192_n638NefUpdUsuNome ;
      private bool[] T00192_A627NefConfirmado ;
      private string[] T00192_A628NefTexto ;
      private bool[] T00192_n628NefTexto ;
      private short[] T00192_A639NefValor ;
      private bool[] T00192_n639NefValor ;
      private Guid[] T00192_A345NegID ;
      private Guid[] T001913_A345NegID ;
      private string[] T001913_A626NefChave ;
      private bool[] T00193_n626NefChave ;
      private Guid[] T001914_A345NegID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV15NegID_Data ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV22GAMErrors ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV9WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV12AuditingObject ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV13TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons AV16DDO_TitleSettingsIcons ;
      private GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTDropDownOptionsTitleSettingsIcons GXt_SdtDVB_SDTDropDownOptionsTitleSettingsIcons1 ;
      private GeneXus.Programs.genexussecurity.SdtGAMSession AV21GAMSession ;
   }

   public class negociopjfluxo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class negociopjfluxo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[8])
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
        Object[] prmT00195;
        prmT00195 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT00194;
        prmT00194 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00196;
        prmT00196 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00197;
        prmT00197 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT00193;
        prmT00193 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT00198;
        prmT00198 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT00199;
        prmT00199 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT00192;
        prmT00192 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT001910;
        prmT001910 = new Object[] {
        new ParDef("NefChave",GXType.VarChar,100,0) ,
        new ParDef("NefInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NefInsData",GXType.DateTime,10,5) ,
        new ParDef("NefInsHora",GXType.DateTime,0,5) ,
        new ParDef("NefInsUsuId",GXType.Char,40,0) ,
        new ParDef("NefInsUsuNome",GXType.VarChar,80,0) ,
        new ParDef("NefUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NefUpdData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NefUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NefUpdUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NefUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NefConfirmado",GXType.Boolean,4,0) ,
        new ParDef("NefTexto",GXType.VarChar,250,0){Nullable=true} ,
        new ParDef("NefValor",GXType.Int16,3,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001911;
        prmT001911 = new Object[] {
        new ParDef("NefInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("NefInsData",GXType.DateTime,10,5) ,
        new ParDef("NefInsHora",GXType.DateTime,0,5) ,
        new ParDef("NefInsUsuId",GXType.Char,40,0) ,
        new ParDef("NefInsUsuNome",GXType.VarChar,80,0) ,
        new ParDef("NefUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("NefUpdData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("NefUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("NefUpdUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("NefUpdUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("NefConfirmado",GXType.Boolean,4,0) ,
        new ParDef("NefTexto",GXType.VarChar,250,0){Nullable=true} ,
        new ParDef("NefValor",GXType.Int16,3,0){Nullable=true} ,
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT001912;
        prmT001912 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("NefChave",GXType.VarChar,100,0)
        };
        Object[] prmT001913;
        prmT001913 = new Object[] {
        };
        Object[] prmT001914;
        prmT001914 = new Object[] {
        new ParDef("NegID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00192", "SELECT NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave  FOR UPDATE OF tb_negociopj_fluxo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00192,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00193", "SELECT NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT00193,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00194", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00194,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00195", "SELECT TM1.NefChave, TM1.NefInsDataHora, TM1.NefInsData, TM1.NefInsHora, TM1.NefInsUsuId, TM1.NefInsUsuNome, TM1.NefUpdDataHora, TM1.NefUpdData, TM1.NefUpdHora, TM1.NefUpdUsuId, TM1.NefUpdUsuNome, TM1.NefConfirmado, TM1.NefTexto, TM1.NefValor, TM1.NegID FROM tb_negociopj_fluxo TM1 WHERE TM1.NegID = :NegID and TM1.NefChave = ( :NefChave) ORDER BY TM1.NegID, TM1.NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT00195,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00196", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00196,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00197", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE NegID = :NegID AND NefChave = :NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT00197,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00198", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE ( NegID > :NegID or NegID = :NegID and NefChave > ( :NefChave)) ORDER BY NegID, NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT00198,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00199", "SELECT NegID, NefChave FROM tb_negociopj_fluxo WHERE ( NegID < :NegID or NegID = :NegID and NefChave < ( :NefChave)) ORDER BY NegID DESC, NefChave DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00199,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001910", "SAVEPOINT gxupdate;INSERT INTO tb_negociopj_fluxo(NefChave, NefInsDataHora, NefInsData, NefInsHora, NefInsUsuId, NefInsUsuNome, NefUpdDataHora, NefUpdData, NefUpdHora, NefUpdUsuId, NefUpdUsuNome, NefConfirmado, NefTexto, NefValor, NegID) VALUES(:NefChave, :NefInsDataHora, :NefInsData, :NefInsHora, :NefInsUsuId, :NefInsUsuNome, :NefUpdDataHora, :NefUpdData, :NefUpdHora, :NefUpdUsuId, :NefUpdUsuNome, :NefConfirmado, :NefTexto, :NefValor, :NegID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001910)
           ,new CursorDef("T001911", "SAVEPOINT gxupdate;UPDATE tb_negociopj_fluxo SET NefInsDataHora=:NefInsDataHora, NefInsData=:NefInsData, NefInsHora=:NefInsHora, NefInsUsuId=:NefInsUsuId, NefInsUsuNome=:NefInsUsuNome, NefUpdDataHora=:NefUpdDataHora, NefUpdData=:NefUpdData, NefUpdHora=:NefUpdHora, NefUpdUsuId=:NefUpdUsuId, NefUpdUsuNome=:NefUpdUsuNome, NefConfirmado=:NefConfirmado, NefTexto=:NefTexto, NefValor=:NefValor  WHERE NegID = :NegID AND NefChave = :NefChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001911)
           ,new CursorDef("T001912", "SAVEPOINT gxupdate;DELETE FROM tb_negociopj_fluxo  WHERE NegID = :NegID AND NefChave = :NefChave;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001912)
           ,new CursorDef("T001913", "SELECT NegID, NefChave FROM tb_negociopj_fluxo ORDER BY NegID, NefChave ",true, GxErrorMask.GX_NOMASK, false, this,prmT001913,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001914", "SELECT NegID FROM tb_negociopj WHERE NegID = :NegID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001914,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((string[]) buf[12])[0] = rslt.getString(10, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getVarchar(11);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((bool[]) buf[16])[0] = rslt.getBool(12);
              ((string[]) buf[17])[0] = rslt.getVarchar(13);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((short[]) buf[19])[0] = rslt.getShort(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((Guid[]) buf[21])[0] = rslt.getGuid(15);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
