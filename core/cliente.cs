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
   public class cliente : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel7"+"_"+"CLIMATRICULA") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX7ASACLIMATRICULA0O24( Gx_mode) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.cliente.aspx")), "core.cliente.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.cliente.aspx")))) ;
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
                  AV7CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "AV7CliID", AV7CliID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
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
            Form.Meta.addItem("description", "Cliente", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtCliNomeFamiliar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public cliente( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public cliente( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_CliID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7CliID = aP1_CliID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbCliTipo = new GXCombobox();
         cmbavClitipo = new GXCombobox();
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
            return "cliente_Execute" ;
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
         if ( cmbCliTipo.ItemCount > 0 )
         {
            A165CliTipo = (short)(Math.Round(NumberUtil.Val( cmbCliTipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A165CliTipo), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbCliTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
            AssignProp("", false, cmbCliTipo_Internalname, "Values", cmbCliTipo.ToJavascriptSource(), true);
         }
         if ( cmbavClitipo.ItemCount > 0 )
         {
            AV14CliTipo = (short)(Math.Round(NumberUtil.Val( cmbavClitipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14CliTipo), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavClitipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14CliTipo), 1, 0));
            AssignProp("", false, cmbavClitipo_Internalname, "Values", cmbavClitipo.ToJavascriptSource(), true);
         }
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliMatricula_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliMatricula_Internalname, "Matrícula", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtCliMatricula_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 15, 0, ",", "")), StringUtil.LTrim( ((edtCliMatricula_Enabled!=0) ? context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliMatricula_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliMatricula_Enabled, 0, "text", "", 15, "chr", 1, "row", 15, 0, 0, 0, 0, -1, 0, true, "core\\Matricula", "end", false, "", "HLP_core\\Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtCliNomeFamiliar_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtCliNomeFamiliar_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliNomeFamiliar_Internalname, A160CliNomeFamiliar, StringUtil.RTrim( context.localUtil.Format( A160CliNomeFamiliar, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,27);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliNomeFamiliar_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtCliNomeFamiliar_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbCliTipo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbCliTipo_Internalname, "Tipo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbCliTipo, cmbCliTipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A165CliTipo), 1, 0)), 1, cmbCliTipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbCliTipo.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", "", "", true, 0, "HLP_core\\Cliente.htm");
         cmbCliTipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
         AssignProp("", false, cmbCliTipo_Internalname, "Values", (string)(cmbCliTipo.ToJavascriptSource()), true);
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Cliente.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Cliente.htm");
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
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbavClitipo, cmbavClitipo_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV14CliTipo), 1, 0)), 1, cmbavClitipo_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", cmbavClitipo.Visible, cmbavClitipo.Enabled, 0, 0, 0, "em", 0, "", "", "Attribute", "", "", "", "", true, 0, "HLP_core\\Cliente.htm");
         cmbavClitipo.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV14CliTipo), 1, 0));
         AssignProp("", false, cmbavClitipo_Internalname, "Values", (string)(cmbavClitipo.ToJavascriptSource()), true);
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliID_Internalname, A158CliID.ToString(), A158CliID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliID_Jsonclick, 0, "Attribute", "", "", "", "", edtCliID_Visible, edtCliID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Cliente.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCliInsData_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCliInsData_Internalname, context.localUtil.Format(A161CliInsData, "99/99/99"), context.localUtil.Format( A161CliInsData, "99/99/99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',0,24,'por',false,0);"+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliInsData_Jsonclick, 0, "Attribute", "", "", "", "", edtCliInsData_Visible, edtCliInsData_Enabled, 0, "text", "", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "core\\Data", "end", false, "", "HLP_core\\Cliente.htm");
         GxWebStd.gx_bitmap( context, edtCliInsData_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCliInsData_Visible==0)||(edtCliInsData_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Cliente.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 46,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCliInsHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCliInsHora_Internalname, context.localUtil.TToC( A162CliInsHora, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A162CliInsHora, "99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 0,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,46);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliInsHora_Jsonclick, 0, "Attribute", "", "", "", "", edtCliInsHora_Visible, edtCliInsHora_Enabled, 0, "text", "", 5, "chr", 1, "row", 5, 0, 0, 0, 0, -1, 0, true, "core\\HoraMinuto", "end", false, "", "HLP_core\\Cliente.htm");
         GxWebStd.gx_bitmap( context, edtCliInsHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCliInsHora_Visible==0)||(edtCliInsHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Cliente.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 47,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtCliInsDataHora_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtCliInsDataHora_Internalname, context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A163CliInsDataHora, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,47);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliInsDataHora_Jsonclick, 0, "Attribute", "", "", "", "", edtCliInsDataHora_Visible, edtCliInsDataHora_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "core\\DataHoraSegundoMS", "end", false, "", "HLP_core\\Cliente.htm");
         GxWebStd.gx_bitmap( context, edtCliInsDataHora_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((edtCliInsDataHora_Visible==0)||(edtCliInsDataHora_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_core\\Cliente.htm");
         context.WriteHtmlTextNl( "</div>") ;
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 48,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtCliInsUserID_Internalname, StringUtil.RTrim( A164CliInsUserID), StringUtil.RTrim( context.localUtil.Format( A164CliInsUserID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,48);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtCliInsUserID_Jsonclick, 0, "Attribute", "", "", "", "", edtCliInsUserID_Visible, edtCliInsUserID_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_core\\Cliente.htm");
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
         E110O2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z158CliID = StringUtil.StrToGuid( cgiGet( "Z158CliID"));
               Z165CliTipo = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z165CliTipo"), ",", "."), 18, MidpointRounding.ToEven));
               Z159CliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z159CliMatricula"), ",", "."), 18, MidpointRounding.ToEven));
               Z163CliInsDataHora = context.localUtil.CToT( cgiGet( "Z163CliInsDataHora"), 0);
               Z161CliInsData = context.localUtil.CToD( cgiGet( "Z161CliInsData"), 0);
               Z162CliInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z162CliInsHora"), 0));
               Z525CliDelDataHora = context.localUtil.CToT( cgiGet( "Z525CliDelDataHora"), 0);
               n525CliDelDataHora = ((DateTime.MinValue==A525CliDelDataHora) ? true : false);
               Z526CliDelData = context.localUtil.CToT( cgiGet( "Z526CliDelData"), 0);
               n526CliDelData = ((DateTime.MinValue==A526CliDelData) ? true : false);
               Z527CliDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z527CliDelHora"), 0));
               n527CliDelHora = ((DateTime.MinValue==A527CliDelHora) ? true : false);
               Z528CliDelUsuId = cgiGet( "Z528CliDelUsuId");
               n528CliDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A528CliDelUsuId)) ? true : false);
               Z529CliDelUsuNome = cgiGet( "Z529CliDelUsuNome");
               n529CliDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A529CliDelUsuNome)) ? true : false);
               Z160CliNomeFamiliar = cgiGet( "Z160CliNomeFamiliar");
               Z164CliInsUserID = cgiGet( "Z164CliInsUserID");
               n164CliInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A164CliInsUserID)) ? true : false);
               Z393CliInsUserNome = cgiGet( "Z393CliInsUserNome");
               n393CliInsUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A393CliInsUserNome)) ? true : false);
               Z177CliiUpdData = context.localUtil.CToD( cgiGet( "Z177CliiUpdData"), 0);
               n177CliiUpdData = ((DateTime.MinValue==A177CliiUpdData) ? true : false);
               Z178CliUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z178CliUpdHora"), 0));
               n178CliUpdHora = ((DateTime.MinValue==A178CliUpdHora) ? true : false);
               Z179CliUpdDataHora = context.localUtil.CToT( cgiGet( "Z179CliUpdDataHora"), 0);
               n179CliUpdDataHora = ((DateTime.MinValue==A179CliUpdDataHora) ? true : false);
               Z180CliUpdUserID = cgiGet( "Z180CliUpdUserID");
               n180CliUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A180CliUpdUserID)) ? true : false);
               Z394CliUpdUserNome = cgiGet( "Z394CliUpdUserNome");
               n394CliUpdUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A394CliUpdUserNome)) ? true : false);
               Z196CliVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196CliVersao"), ",", "."), 18, MidpointRounding.ToEven));
               Z197CliAtivo = StringUtil.StrToBool( cgiGet( "Z197CliAtivo"));
               Z524CliDel = StringUtil.StrToBool( cgiGet( "Z524CliDel"));
               A525CliDelDataHora = context.localUtil.CToT( cgiGet( "Z525CliDelDataHora"), 0);
               n525CliDelDataHora = false;
               n525CliDelDataHora = ((DateTime.MinValue==A525CliDelDataHora) ? true : false);
               A526CliDelData = context.localUtil.CToT( cgiGet( "Z526CliDelData"), 0);
               n526CliDelData = false;
               n526CliDelData = ((DateTime.MinValue==A526CliDelData) ? true : false);
               A527CliDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z527CliDelHora"), 0));
               n527CliDelHora = false;
               n527CliDelHora = ((DateTime.MinValue==A527CliDelHora) ? true : false);
               A528CliDelUsuId = cgiGet( "Z528CliDelUsuId");
               n528CliDelUsuId = false;
               n528CliDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A528CliDelUsuId)) ? true : false);
               A529CliDelUsuNome = cgiGet( "Z529CliDelUsuNome");
               n529CliDelUsuNome = false;
               n529CliDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A529CliDelUsuNome)) ? true : false);
               A393CliInsUserNome = cgiGet( "Z393CliInsUserNome");
               n393CliInsUserNome = false;
               n393CliInsUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A393CliInsUserNome)) ? true : false);
               A177CliiUpdData = context.localUtil.CToD( cgiGet( "Z177CliiUpdData"), 0);
               n177CliiUpdData = false;
               n177CliiUpdData = ((DateTime.MinValue==A177CliiUpdData) ? true : false);
               A178CliUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z178CliUpdHora"), 0));
               n178CliUpdHora = false;
               n178CliUpdHora = ((DateTime.MinValue==A178CliUpdHora) ? true : false);
               A179CliUpdDataHora = context.localUtil.CToT( cgiGet( "Z179CliUpdDataHora"), 0);
               n179CliUpdDataHora = false;
               n179CliUpdDataHora = ((DateTime.MinValue==A179CliUpdDataHora) ? true : false);
               A180CliUpdUserID = cgiGet( "Z180CliUpdUserID");
               n180CliUpdUserID = false;
               n180CliUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A180CliUpdUserID)) ? true : false);
               A394CliUpdUserNome = cgiGet( "Z394CliUpdUserNome");
               n394CliUpdUserNome = false;
               n394CliUpdUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A394CliUpdUserNome)) ? true : false);
               A196CliVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z196CliVersao"), ",", "."), 18, MidpointRounding.ToEven));
               A197CliAtivo = StringUtil.StrToBool( cgiGet( "Z197CliAtivo"));
               A524CliDel = StringUtil.StrToBool( cgiGet( "Z524CliDel"));
               O524CliDel = StringUtil.StrToBool( cgiGet( "O524CliDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7CliID = StringUtil.StrToGuid( cgiGet( "vCLIID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A524CliDel = StringUtil.StrToBool( cgiGet( "CLIDEL"));
               A525CliDelDataHora = context.localUtil.CToT( cgiGet( "CLIDELDATAHORA"), 0);
               n525CliDelDataHora = ((DateTime.MinValue==A525CliDelDataHora) ? true : false);
               A526CliDelData = context.localUtil.CToT( cgiGet( "CLIDELDATA"), 0);
               n526CliDelData = ((DateTime.MinValue==A526CliDelData) ? true : false);
               A527CliDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CLIDELHORA"), 0));
               n527CliDelHora = ((DateTime.MinValue==A527CliDelHora) ? true : false);
               A528CliDelUsuId = cgiGet( "CLIDELUSUID");
               n528CliDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A528CliDelUsuId)) ? true : false);
               A529CliDelUsuNome = cgiGet( "CLIDELUSUNOME");
               n529CliDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A529CliDelUsuNome)) ? true : false);
               A197CliAtivo = StringUtil.StrToBool( cgiGet( "CLIATIVO"));
               A196CliVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "CLIVERSAO"), ",", "."), 18, MidpointRounding.ToEven));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV15AuditingObject);
               A393CliInsUserNome = cgiGet( "CLIINSUSERNOME");
               n393CliInsUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A393CliInsUserNome)) ? true : false);
               A177CliiUpdData = context.localUtil.CToD( cgiGet( "CLIIUPDDATA"), 0);
               n177CliiUpdData = ((DateTime.MinValue==A177CliiUpdData) ? true : false);
               A178CliUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "CLIUPDHORA"), 0));
               n178CliUpdHora = ((DateTime.MinValue==A178CliUpdHora) ? true : false);
               A179CliUpdDataHora = context.localUtil.CToT( cgiGet( "CLIUPDDATAHORA"), 0);
               n179CliUpdDataHora = ((DateTime.MinValue==A179CliUpdDataHora) ? true : false);
               A180CliUpdUserID = cgiGet( "CLIUPDUSERID");
               n180CliUpdUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A180CliUpdUserID)) ? true : false);
               A394CliUpdUserNome = cgiGet( "CLIUPDUSERNOME");
               n394CliUpdUserNome = (String.IsNullOrEmpty(StringUtil.RTrim( A394CliUpdUserNome)) ? true : false);
               AV16Pgmname = cgiGet( "vPGMNAME");
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
               A159CliMatricula = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtCliMatricula_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
               GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
               A160CliNomeFamiliar = StringUtil.Upper( cgiGet( edtCliNomeFamiliar_Internalname));
               AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
               cmbCliTipo.CurrentValue = cgiGet( cmbCliTipo_Internalname);
               A165CliTipo = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbCliTipo_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
               cmbavClitipo.CurrentValue = cgiGet( cmbavClitipo_Internalname);
               AV14CliTipo = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbavClitipo_Internalname), "."), 18, MidpointRounding.ToEven));
               if ( StringUtil.StrCmp(cgiGet( edtCliID_Internalname), "") == 0 )
               {
                  A158CliID = Guid.Empty;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
               }
               else
               {
                  try
                  {
                     A158CliID = StringUtil.StrToGuid( cgiGet( edtCliID_Internalname));
                     AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "CLIID");
                     AnyError = 1;
                     GX_FocusControl = edtCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( context.localUtil.VCDate( cgiGet( edtCliInsData_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_faildate", new   object[]  {"Incluído em"}), 1, "CLIINSDATA");
                  AnyError = 1;
                  GX_FocusControl = edtCliInsData_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A161CliInsData = DateTime.MinValue;
                  AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
               }
               else
               {
                  A161CliInsData = context.localUtil.CToD( cgiGet( edtCliInsData_Internalname), 2);
                  AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
               }
               if ( context.localUtil.VCDate( cgiGet( edtCliInsHora_Internalname), 2) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badtime", new   object[]  {"Hora"}), 1, "CLIINSHORA");
                  AnyError = 1;
                  GX_FocusControl = edtCliInsHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A162CliInsHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               else
               {
                  A162CliInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( edtCliInsHora_Internalname)));
                  AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
               }
               if ( context.localUtil.VCDateTime( cgiGet( edtCliInsDataHora_Internalname), 2, 0) == 0 )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Incluído em"}), 1, "CLIINSDATAHORA");
                  AnyError = 1;
                  GX_FocusControl = edtCliInsDataHora_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A163CliInsDataHora = (DateTime)(DateTime.MinValue);
                  AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               else
               {
                  A163CliInsDataHora = context.localUtil.CToT( cgiGet( edtCliInsDataHora_Internalname));
                  AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
               }
               A164CliInsUserID = cgiGet( edtCliInsUserID_Internalname);
               n164CliInsUserID = false;
               AssignAttri("", false, "A164CliInsUserID", A164CliInsUserID);
               n164CliInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A164CliInsUserID)) ? true : false);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
               A165CliTipo = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbCliTipo_Internalname), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
               forbiddenHiddens.Add("CliTipo", context.localUtil.Format( (decimal)(A165CliTipo), "9"));
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV16Pgmname, "")));
               forbiddenHiddens.Add("CliInsUserNome", StringUtil.RTrim( context.localUtil.Format( A393CliInsUserNome, "@!")));
               forbiddenHiddens.Add("CliiUpdData", context.localUtil.Format(A177CliiUpdData, "99/99/99"));
               forbiddenHiddens.Add("CliUpdHora", context.localUtil.Format( A178CliUpdHora, "99:99"));
               forbiddenHiddens.Add("CliUpdDataHora", context.localUtil.Format( A179CliUpdDataHora, "99/99/9999 99:99:99.999"));
               forbiddenHiddens.Add("CliUpdUserID", StringUtil.RTrim( context.localUtil.Format( A180CliUpdUserID, "")));
               forbiddenHiddens.Add("CliUpdUserNome", StringUtil.RTrim( context.localUtil.Format( A394CliUpdUserNome, "@!")));
               forbiddenHiddens.Add("CliVersao", context.localUtil.Format( (decimal)(A196CliVersao), "ZZZ9"));
               forbiddenHiddens.Add("CliAtivo", StringUtil.BoolToStr( A197CliAtivo));
               forbiddenHiddens.Add("CliDel", StringUtil.BoolToStr( A524CliDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A158CliID != Z158CliID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\cliente:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A158CliID = StringUtil.StrToGuid( GetPar( "CliID"));
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7CliID) )
                  {
                     A158CliID = AV7CliID;
                     AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A158CliID) && ( Gx_BScreen == 0 ) )
                     {
                        A158CliID = Guid.NewGuid( );
                        AssignAttri("", false, "A158CliID", A158CliID.ToString());
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
                     sMode24 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7CliID) )
                     {
                        A158CliID = AV7CliID;
                        AssignAttri("", false, "A158CliID", A158CliID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A158CliID) && ( Gx_BScreen == 0 ) )
                        {
                           A158CliID = Guid.NewGuid( );
                           AssignAttri("", false, "A158CliID", A158CliID.ToString());
                        }
                     }
                     Gx_mode = sMode24;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound24 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0O0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "CLIID");
                        AnyError = 1;
                        GX_FocusControl = edtCliID_Internalname;
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
                           E110O2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120O2 ();
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
            E120O2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0O24( ) ;
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
            DisableAttributes0O24( ) ;
         }
         AssignProp("", false, cmbavClitipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavClitipo.Enabled), 5, 0), true);
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

      protected void CONFIRM_0O0( )
      {
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0O24( ) ;
            }
            else
            {
               CheckExtendedTable0O24( ) ;
               CloseExtendedTableCursors0O24( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0O0( )
      {
      }

      protected void E110O2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV12WebSession.Remove("CLIID");
         AV12WebSession.Remove("CLIMATRICULA");
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         cmbavClitipo.Visible = 0;
         AssignProp("", false, cmbavClitipo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(cmbavClitipo.Visible), 5, 0), true);
         edtCliID_Visible = 0;
         AssignProp("", false, edtCliID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliID_Visible), 5, 0), true);
         edtCliInsData_Visible = 0;
         AssignProp("", false, edtCliInsData_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliInsData_Visible), 5, 0), true);
         edtCliInsHora_Visible = 0;
         AssignProp("", false, edtCliInsHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliInsHora_Visible), 5, 0), true);
         edtCliInsDataHora_Visible = 0;
         AssignProp("", false, edtCliInsDataHora_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliInsDataHora_Visible), 5, 0), true);
         edtCliInsUserID_Visible = 0;
         AssignProp("", false, edtCliInsUserID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtCliInsUserID_Visible), 5, 0), true);
      }

      protected void E120O2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV15AuditingObject,  AV16Pgmname) ;
         AV12WebSession.Set("CLIID", StringUtil.Trim( A158CliID.ToString()));
         AV12WebSession.Set("CLIMATRICULA", StringUtil.Trim( StringUtil.Str( (decimal)(A159CliMatricula), 12, 0)));
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.clienteww.aspx") );
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

      protected void ZM0O24( short GX_JID )
      {
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z165CliTipo = T000O3_A165CliTipo[0];
               Z159CliMatricula = T000O3_A159CliMatricula[0];
               Z163CliInsDataHora = T000O3_A163CliInsDataHora[0];
               Z161CliInsData = T000O3_A161CliInsData[0];
               Z162CliInsHora = T000O3_A162CliInsHora[0];
               Z525CliDelDataHora = T000O3_A525CliDelDataHora[0];
               Z526CliDelData = T000O3_A526CliDelData[0];
               Z527CliDelHora = T000O3_A527CliDelHora[0];
               Z528CliDelUsuId = T000O3_A528CliDelUsuId[0];
               Z529CliDelUsuNome = T000O3_A529CliDelUsuNome[0];
               Z160CliNomeFamiliar = T000O3_A160CliNomeFamiliar[0];
               Z164CliInsUserID = T000O3_A164CliInsUserID[0];
               Z393CliInsUserNome = T000O3_A393CliInsUserNome[0];
               Z177CliiUpdData = T000O3_A177CliiUpdData[0];
               Z178CliUpdHora = T000O3_A178CliUpdHora[0];
               Z179CliUpdDataHora = T000O3_A179CliUpdDataHora[0];
               Z180CliUpdUserID = T000O3_A180CliUpdUserID[0];
               Z394CliUpdUserNome = T000O3_A394CliUpdUserNome[0];
               Z196CliVersao = T000O3_A196CliVersao[0];
               Z197CliAtivo = T000O3_A197CliAtivo[0];
               Z524CliDel = T000O3_A524CliDel[0];
            }
            else
            {
               Z165CliTipo = A165CliTipo;
               Z159CliMatricula = A159CliMatricula;
               Z163CliInsDataHora = A163CliInsDataHora;
               Z161CliInsData = A161CliInsData;
               Z162CliInsHora = A162CliInsHora;
               Z525CliDelDataHora = A525CliDelDataHora;
               Z526CliDelData = A526CliDelData;
               Z527CliDelHora = A527CliDelHora;
               Z528CliDelUsuId = A528CliDelUsuId;
               Z529CliDelUsuNome = A529CliDelUsuNome;
               Z160CliNomeFamiliar = A160CliNomeFamiliar;
               Z164CliInsUserID = A164CliInsUserID;
               Z393CliInsUserNome = A393CliInsUserNome;
               Z177CliiUpdData = A177CliiUpdData;
               Z178CliUpdHora = A178CliUpdHora;
               Z179CliUpdDataHora = A179CliUpdDataHora;
               Z180CliUpdUserID = A180CliUpdUserID;
               Z394CliUpdUserNome = A394CliUpdUserNome;
               Z196CliVersao = A196CliVersao;
               Z197CliAtivo = A197CliAtivo;
               Z524CliDel = A524CliDel;
            }
         }
         if ( GX_JID == -26 )
         {
            Z158CliID = A158CliID;
            Z165CliTipo = A165CliTipo;
            Z159CliMatricula = A159CliMatricula;
            Z163CliInsDataHora = A163CliInsDataHora;
            Z161CliInsData = A161CliInsData;
            Z162CliInsHora = A162CliInsHora;
            Z525CliDelDataHora = A525CliDelDataHora;
            Z526CliDelData = A526CliDelData;
            Z527CliDelHora = A527CliDelHora;
            Z528CliDelUsuId = A528CliDelUsuId;
            Z529CliDelUsuNome = A529CliDelUsuNome;
            Z160CliNomeFamiliar = A160CliNomeFamiliar;
            Z164CliInsUserID = A164CliInsUserID;
            Z393CliInsUserNome = A393CliInsUserNome;
            Z177CliiUpdData = A177CliiUpdData;
            Z178CliUpdHora = A178CliUpdHora;
            Z179CliUpdDataHora = A179CliUpdDataHora;
            Z180CliUpdUserID = A180CliUpdUserID;
            Z394CliUpdUserNome = A394CliUpdUserNome;
            Z196CliVersao = A196CliVersao;
            Z197CliAtivo = A197CliAtivo;
            Z524CliDel = A524CliDel;
         }
      }

      protected void standaloneNotModal( )
      {
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         cmbCliTipo.Enabled = 0;
         AssignProp("", false, cmbCliTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCliTipo.Enabled), 5, 0), true);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV16Pgmname = "core.Cliente";
         AssignAttri("", false, "AV16Pgmname", AV16Pgmname);
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         cmbCliTipo.Enabled = 0;
         AssignProp("", false, cmbCliTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCliTipo.Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7CliID) )
         {
            edtCliID_Enabled = 0;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
         else
         {
            edtCliID_Enabled = 1;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7CliID) )
         {
            edtCliID_Enabled = 0;
            AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         A165CliTipo = 2;
         AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
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
         if ( ! (Guid.Empty==AV7CliID) )
         {
            A158CliID = AV7CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A158CliID) && ( Gx_BScreen == 0 ) )
            {
               A158CliID = Guid.NewGuid( );
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
            }
         }
         if ( IsIns( )  && (false==A197CliAtivo) && ( Gx_BScreen == 0 ) )
         {
            A197CliAtivo = true;
            AssignAttri("", false, "A197CliAtivo", A197CliAtivo);
         }
         if ( IsIns( )  && (0==A196CliVersao) && ( Gx_BScreen == 0 ) )
         {
            A196CliVersao = 1;
            AssignAttri("", false, "A196CliVersao", StringUtil.LTrimStr( (decimal)(A196CliVersao), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0O24( )
      {
         /* Using cursor T000O4 */
         pr_default.execute(2, new Object[] {A158CliID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound24 = 1;
            A165CliTipo = T000O4_A165CliTipo[0];
            AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
            A159CliMatricula = T000O4_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
            A163CliInsDataHora = T000O4_A163CliInsDataHora[0];
            AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A161CliInsData = T000O4_A161CliInsData[0];
            AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
            A162CliInsHora = T000O4_A162CliInsHora[0];
            AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
            A525CliDelDataHora = T000O4_A525CliDelDataHora[0];
            n525CliDelDataHora = T000O4_n525CliDelDataHora[0];
            A526CliDelData = T000O4_A526CliDelData[0];
            n526CliDelData = T000O4_n526CliDelData[0];
            A527CliDelHora = T000O4_A527CliDelHora[0];
            n527CliDelHora = T000O4_n527CliDelHora[0];
            A528CliDelUsuId = T000O4_A528CliDelUsuId[0];
            n528CliDelUsuId = T000O4_n528CliDelUsuId[0];
            A529CliDelUsuNome = T000O4_A529CliDelUsuNome[0];
            n529CliDelUsuNome = T000O4_n529CliDelUsuNome[0];
            A160CliNomeFamiliar = T000O4_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            A164CliInsUserID = T000O4_A164CliInsUserID[0];
            n164CliInsUserID = T000O4_n164CliInsUserID[0];
            AssignAttri("", false, "A164CliInsUserID", A164CliInsUserID);
            A393CliInsUserNome = T000O4_A393CliInsUserNome[0];
            n393CliInsUserNome = T000O4_n393CliInsUserNome[0];
            A177CliiUpdData = T000O4_A177CliiUpdData[0];
            n177CliiUpdData = T000O4_n177CliiUpdData[0];
            A178CliUpdHora = T000O4_A178CliUpdHora[0];
            n178CliUpdHora = T000O4_n178CliUpdHora[0];
            A179CliUpdDataHora = T000O4_A179CliUpdDataHora[0];
            n179CliUpdDataHora = T000O4_n179CliUpdDataHora[0];
            A180CliUpdUserID = T000O4_A180CliUpdUserID[0];
            n180CliUpdUserID = T000O4_n180CliUpdUserID[0];
            A394CliUpdUserNome = T000O4_A394CliUpdUserNome[0];
            n394CliUpdUserNome = T000O4_n394CliUpdUserNome[0];
            A196CliVersao = T000O4_A196CliVersao[0];
            A197CliAtivo = T000O4_A197CliAtivo[0];
            A524CliDel = T000O4_A524CliDel[0];
            ZM0O24( -26) ;
         }
         pr_default.close(2);
         OnLoadActions0O24( ) ;
      }

      protected void OnLoadActions0O24( )
      {
      }

      protected void CheckExtendedTable0O24( )
      {
         nIsDirty_24 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000O5 */
         pr_default.execute(3, new Object[] {A159CliMatricula, A158CliID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Matrícula"}), 1, "CLIMATRICULA");
            AnyError = 1;
            GX_FocusControl = edtCliMatricula_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(3);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A160CliNomeFamiliar)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Nome", "", "", "", "", "", "", "", ""), 1, "CLINOMEFAMILIAR");
            AnyError = 1;
            GX_FocusControl = edtCliNomeFamiliar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0O24( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0O24( )
      {
         /* Using cursor T000O6 */
         pr_default.execute(4, new Object[] {A158CliID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound24 = 1;
         }
         else
         {
            RcdFound24 = 0;
         }
         pr_default.close(4);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000O3 */
         pr_default.execute(1, new Object[] {A158CliID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0O24( 26) ;
            RcdFound24 = 1;
            A158CliID = T000O3_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            A165CliTipo = T000O3_A165CliTipo[0];
            AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
            A159CliMatricula = T000O3_A159CliMatricula[0];
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
            A163CliInsDataHora = T000O3_A163CliInsDataHora[0];
            AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
            A161CliInsData = T000O3_A161CliInsData[0];
            AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
            A162CliInsHora = T000O3_A162CliInsHora[0];
            AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
            A525CliDelDataHora = T000O3_A525CliDelDataHora[0];
            n525CliDelDataHora = T000O3_n525CliDelDataHora[0];
            A526CliDelData = T000O3_A526CliDelData[0];
            n526CliDelData = T000O3_n526CliDelData[0];
            A527CliDelHora = T000O3_A527CliDelHora[0];
            n527CliDelHora = T000O3_n527CliDelHora[0];
            A528CliDelUsuId = T000O3_A528CliDelUsuId[0];
            n528CliDelUsuId = T000O3_n528CliDelUsuId[0];
            A529CliDelUsuNome = T000O3_A529CliDelUsuNome[0];
            n529CliDelUsuNome = T000O3_n529CliDelUsuNome[0];
            A160CliNomeFamiliar = T000O3_A160CliNomeFamiliar[0];
            AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
            A164CliInsUserID = T000O3_A164CliInsUserID[0];
            n164CliInsUserID = T000O3_n164CliInsUserID[0];
            AssignAttri("", false, "A164CliInsUserID", A164CliInsUserID);
            A393CliInsUserNome = T000O3_A393CliInsUserNome[0];
            n393CliInsUserNome = T000O3_n393CliInsUserNome[0];
            A177CliiUpdData = T000O3_A177CliiUpdData[0];
            n177CliiUpdData = T000O3_n177CliiUpdData[0];
            A178CliUpdHora = T000O3_A178CliUpdHora[0];
            n178CliUpdHora = T000O3_n178CliUpdHora[0];
            A179CliUpdDataHora = T000O3_A179CliUpdDataHora[0];
            n179CliUpdDataHora = T000O3_n179CliUpdDataHora[0];
            A180CliUpdUserID = T000O3_A180CliUpdUserID[0];
            n180CliUpdUserID = T000O3_n180CliUpdUserID[0];
            A394CliUpdUserNome = T000O3_A394CliUpdUserNome[0];
            n394CliUpdUserNome = T000O3_n394CliUpdUserNome[0];
            A196CliVersao = T000O3_A196CliVersao[0];
            A197CliAtivo = T000O3_A197CliAtivo[0];
            A524CliDel = T000O3_A524CliDel[0];
            O524CliDel = A524CliDel;
            AssignAttri("", false, "A524CliDel", A524CliDel);
            Z158CliID = A158CliID;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0O24( ) ;
            if ( AnyError == 1 )
            {
               RcdFound24 = 0;
               InitializeNonKey0O24( ) ;
            }
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound24 = 0;
            InitializeNonKey0O24( ) ;
            sMode24 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode24;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0O24( ) ;
         if ( RcdFound24 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound24 = 0;
         /* Using cursor T000O7 */
         pr_default.execute(5, new Object[] {A158CliID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000O7_A158CliID[0], A158CliID, 0) < 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( GuidUtil.Compare(T000O7_A158CliID[0], A158CliID, 0) > 0 ) ) )
            {
               A158CliID = T000O7_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               RcdFound24 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void move_previous( )
      {
         RcdFound24 = 0;
         /* Using cursor T000O8 */
         pr_default.execute(6, new Object[] {A158CliID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000O8_A158CliID[0], A158CliID, 0) > 0 ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T000O8_A158CliID[0], A158CliID, 0) < 0 ) ) )
            {
               A158CliID = T000O8_A158CliID[0];
               AssignAttri("", false, "A158CliID", A158CliID.ToString());
               RcdFound24 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0O24( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtCliNomeFamiliar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0O24( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound24 == 1 )
            {
               if ( A158CliID != Z158CliID )
               {
                  A158CliID = Z158CliID;
                  AssignAttri("", false, "A158CliID", A158CliID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "CLIID");
                  AnyError = 1;
                  GX_FocusControl = edtCliID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtCliNomeFamiliar_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0O24( ) ;
                  GX_FocusControl = edtCliNomeFamiliar_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A158CliID != Z158CliID )
               {
                  /* Insert record */
                  GX_FocusControl = edtCliNomeFamiliar_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0O24( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "CLIID");
                     AnyError = 1;
                     GX_FocusControl = edtCliID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtCliNomeFamiliar_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0O24( ) ;
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
         if ( A158CliID != Z158CliID )
         {
            A158CliID = Z158CliID;
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "CLIID");
            AnyError = 1;
            GX_FocusControl = edtCliID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtCliNomeFamiliar_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0O24( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000O2 */
            pr_default.execute(0, new Object[] {A158CliID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_cliente"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z165CliTipo != T000O2_A165CliTipo[0] ) || ( Z159CliMatricula != T000O2_A159CliMatricula[0] ) || ( Z163CliInsDataHora != T000O2_A163CliInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z161CliInsData ) != DateTimeUtil.ResetTime ( T000O2_A161CliInsData[0] ) ) || ( Z162CliInsHora != T000O2_A162CliInsHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z525CliDelDataHora != T000O2_A525CliDelDataHora[0] ) || ( Z526CliDelData != T000O2_A526CliDelData[0] ) || ( Z527CliDelHora != T000O2_A527CliDelHora[0] ) || ( StringUtil.StrCmp(Z528CliDelUsuId, T000O2_A528CliDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z529CliDelUsuNome, T000O2_A529CliDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z160CliNomeFamiliar, T000O2_A160CliNomeFamiliar[0]) != 0 ) || ( StringUtil.StrCmp(Z164CliInsUserID, T000O2_A164CliInsUserID[0]) != 0 ) || ( StringUtil.StrCmp(Z393CliInsUserNome, T000O2_A393CliInsUserNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z177CliiUpdData ) != DateTimeUtil.ResetTime ( T000O2_A177CliiUpdData[0] ) ) || ( Z178CliUpdHora != T000O2_A178CliUpdHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z179CliUpdDataHora != T000O2_A179CliUpdDataHora[0] ) || ( StringUtil.StrCmp(Z180CliUpdUserID, T000O2_A180CliUpdUserID[0]) != 0 ) || ( StringUtil.StrCmp(Z394CliUpdUserNome, T000O2_A394CliUpdUserNome[0]) != 0 ) || ( Z196CliVersao != T000O2_A196CliVersao[0] ) || ( Z197CliAtivo != T000O2_A197CliAtivo[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z524CliDel != T000O2_A524CliDel[0] ) )
            {
               if ( Z165CliTipo != T000O2_A165CliTipo[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliTipo");
                  GXUtil.WriteLogRaw("Old: ",Z165CliTipo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A165CliTipo[0]);
               }
               if ( Z159CliMatricula != T000O2_A159CliMatricula[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliMatricula");
                  GXUtil.WriteLogRaw("Old: ",Z159CliMatricula);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A159CliMatricula[0]);
               }
               if ( Z163CliInsDataHora != T000O2_A163CliInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z163CliInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A163CliInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z161CliInsData ) != DateTimeUtil.ResetTime ( T000O2_A161CliInsData[0] ) )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliInsData");
                  GXUtil.WriteLogRaw("Old: ",Z161CliInsData);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A161CliInsData[0]);
               }
               if ( Z162CliInsHora != T000O2_A162CliInsHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z162CliInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A162CliInsHora[0]);
               }
               if ( Z525CliDelDataHora != T000O2_A525CliDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z525CliDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A525CliDelDataHora[0]);
               }
               if ( Z526CliDelData != T000O2_A526CliDelData[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDelData");
                  GXUtil.WriteLogRaw("Old: ",Z526CliDelData);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A526CliDelData[0]);
               }
               if ( Z527CliDelHora != T000O2_A527CliDelHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z527CliDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A527CliDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z528CliDelUsuId, T000O2_A528CliDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z528CliDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A528CliDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z529CliDelUsuNome, T000O2_A529CliDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z529CliDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A529CliDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z160CliNomeFamiliar, T000O2_A160CliNomeFamiliar[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliNomeFamiliar");
                  GXUtil.WriteLogRaw("Old: ",Z160CliNomeFamiliar);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A160CliNomeFamiliar[0]);
               }
               if ( StringUtil.StrCmp(Z164CliInsUserID, T000O2_A164CliInsUserID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliInsUserID");
                  GXUtil.WriteLogRaw("Old: ",Z164CliInsUserID);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A164CliInsUserID[0]);
               }
               if ( StringUtil.StrCmp(Z393CliInsUserNome, T000O2_A393CliInsUserNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliInsUserNome");
                  GXUtil.WriteLogRaw("Old: ",Z393CliInsUserNome);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A393CliInsUserNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z177CliiUpdData ) != DateTimeUtil.ResetTime ( T000O2_A177CliiUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliiUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z177CliiUpdData);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A177CliiUpdData[0]);
               }
               if ( Z178CliUpdHora != T000O2_A178CliUpdHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z178CliUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A178CliUpdHora[0]);
               }
               if ( Z179CliUpdDataHora != T000O2_A179CliUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z179CliUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A179CliUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z180CliUpdUserID, T000O2_A180CliUpdUserID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliUpdUserID");
                  GXUtil.WriteLogRaw("Old: ",Z180CliUpdUserID);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A180CliUpdUserID[0]);
               }
               if ( StringUtil.StrCmp(Z394CliUpdUserNome, T000O2_A394CliUpdUserNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliUpdUserNome");
                  GXUtil.WriteLogRaw("Old: ",Z394CliUpdUserNome);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A394CliUpdUserNome[0]);
               }
               if ( Z196CliVersao != T000O2_A196CliVersao[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliVersao");
                  GXUtil.WriteLogRaw("Old: ",Z196CliVersao);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A196CliVersao[0]);
               }
               if ( Z197CliAtivo != T000O2_A197CliAtivo[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z197CliAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A197CliAtivo[0]);
               }
               if ( Z524CliDel != T000O2_A524CliDel[0] )
               {
                  GXUtil.WriteLog("core.cliente:[seudo value changed for attri]"+"CliDel");
                  GXUtil.WriteLogRaw("Old: ",Z524CliDel);
                  GXUtil.WriteLogRaw("Current: ",T000O2_A524CliDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_cliente"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0O24( )
      {
         if ( ! IsAuthorized("cliente_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0O24( 0) ;
            CheckOptimisticConcurrency0O24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0O24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O9 */
                     pr_default.execute(7, new Object[] {A158CliID, A165CliTipo, A159CliMatricula, A163CliInsDataHora, A161CliInsData, A162CliInsHora, n525CliDelDataHora, A525CliDelDataHora, n526CliDelData, A526CliDelData, n527CliDelHora, A527CliDelHora, n528CliDelUsuId, A528CliDelUsuId, n529CliDelUsuNome, A529CliDelUsuNome, A160CliNomeFamiliar, n164CliInsUserID, A164CliInsUserID, n393CliInsUserNome, A393CliInsUserNome, n177CliiUpdData, A177CliiUpdData, n178CliUpdHora, A178CliUpdHora, n179CliUpdDataHora, A179CliUpdDataHora, n180CliUpdUserID, A180CliUpdUserID, n394CliUpdUserNome, A394CliUpdUserNome, A196CliVersao, A197CliAtivo, A524CliDel});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("tb_cliente");
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
               Load0O24( ) ;
            }
            EndLevel0O24( ) ;
         }
         CloseExtendedTableCursors0O24( ) ;
      }

      protected void Update0O24( )
      {
         if ( ! IsAuthorized("cliente_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O24( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0O24( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0O24( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000O10 */
                     pr_default.execute(8, new Object[] {A165CliTipo, A159CliMatricula, A163CliInsDataHora, A161CliInsData, A162CliInsHora, n525CliDelDataHora, A525CliDelDataHora, n526CliDelData, A526CliDelData, n527CliDelHora, A527CliDelHora, n528CliDelUsuId, A528CliDelUsuId, n529CliDelUsuNome, A529CliDelUsuNome, A160CliNomeFamiliar, n164CliInsUserID, A164CliInsUserID, n393CliInsUserNome, A393CliInsUserNome, n177CliiUpdData, A177CliiUpdData, n178CliUpdHora, A178CliUpdHora, n179CliUpdDataHora, A179CliUpdDataHora, n180CliUpdUserID, A180CliUpdUserID, n394CliUpdUserNome, A394CliUpdUserNome, A196CliVersao, A197CliAtivo, A524CliDel, A158CliID});
                     pr_default.close(8);
                     pr_default.SmartCacheProvider.SetUpdated("tb_cliente");
                     if ( (pr_default.getStatus(8) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_cliente"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0O24( ) ;
                     if ( AnyError == 0 )
                     {
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
            EndLevel0O24( ) ;
         }
         CloseExtendedTableCursors0O24( ) ;
      }

      protected void DeferredUpdate0O24( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("cliente_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0O24( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0O24( ) ;
            AfterConfirm0O24( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0O24( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000O11 */
                  pr_default.execute(9, new Object[] {A158CliID});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("tb_cliente");
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
         sMode24 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0O24( ) ;
         Gx_mode = sMode24;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0O24( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000O12 */
            pr_default.execute(10, new Object[] {A158CliID});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"Oportunidade de Negócio"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000O13 */
            pr_default.execute(11, new Object[] {A158CliID});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
         }
      }

      protected void EndLevel0O24( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0O24( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.cliente",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0O0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.cliente",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0O24( )
      {
         /* Scan By routine */
         /* Using cursor T000O14 */
         pr_default.execute(12);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound24 = 1;
            A158CliID = T000O14_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0O24( )
      {
         /* Scan next routine */
         pr_default.readNext(12);
         RcdFound24 = 0;
         if ( (pr_default.getStatus(12) != 101) )
         {
            RcdFound24 = 1;
            A158CliID = T000O14_A158CliID[0];
            AssignAttri("", false, "A158CliID", A158CliID.ToString());
         }
      }

      protected void ScanEnd0O24( )
      {
         pr_default.close(12);
      }

      protected void AfterConfirm0O24( )
      {
         /* After Confirm Rules */
         if ( IsIns( )  )
         {
            GXt_int1 = (int)(A159CliMatricula);
            new GeneXus.Programs.core.serializar(context ).execute(  "CliMatricula",  1, out  GXt_int1) ;
            A159CliMatricula = GXt_int1;
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
         }
      }

      protected void BeforeInsert0O24( )
      {
         /* Before Insert Rules */
         A163CliInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
         A164CliInsUserID = AV13GAMUser.gxTpr_Guid;
         n164CliInsUserID = false;
         AssignAttri("", false, "A164CliInsUserID", A164CliInsUserID);
         A161CliInsData = DateTimeUtil.ResetTime( A163CliInsDataHora);
         AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
         A162CliInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A163CliInsDataHora));
         AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate0O24( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditcliente(context ).execute(  "Y", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         if ( A524CliDel && ( O524CliDel != A524CliDel ) )
         {
            A525CliDelDataHora = DateTimeUtil.NowMS( context);
            n525CliDelDataHora = false;
            AssignAttri("", false, "A525CliDelDataHora", context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A524CliDel && ( O524CliDel != A524CliDel ) )
         {
            A528CliDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n528CliDelUsuId = false;
            AssignAttri("", false, "A528CliDelUsuId", A528CliDelUsuId);
         }
         if ( A524CliDel && ( O524CliDel != A524CliDel ) )
         {
            A529CliDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n529CliDelUsuNome = false;
            AssignAttri("", false, "A529CliDelUsuNome", A529CliDelUsuNome);
         }
         if ( A524CliDel && ( O524CliDel != A524CliDel ) )
         {
            A526CliDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A525CliDelDataHora) ) ;
            n526CliDelData = false;
            AssignAttri("", false, "A526CliDelData", context.localUtil.TToC( A526CliDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A524CliDel && ( O524CliDel != A524CliDel ) )
         {
            A527CliDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A525CliDelDataHora));
            n527CliDelHora = false;
            AssignAttri("", false, "A527CliDelHora", context.localUtil.TToC( A527CliDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete0O24( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditcliente(context ).execute(  "Y", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
      }

      protected void BeforeComplete0O24( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcliente(context ).execute(  "N", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcliente(context ).execute(  "N", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate0O24( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0O24( )
      {
         edtCliMatricula_Enabled = 0;
         AssignProp("", false, edtCliMatricula_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliMatricula_Enabled), 5, 0), true);
         edtCliNomeFamiliar_Enabled = 0;
         AssignProp("", false, edtCliNomeFamiliar_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliNomeFamiliar_Enabled), 5, 0), true);
         cmbCliTipo.Enabled = 0;
         AssignProp("", false, cmbCliTipo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbCliTipo.Enabled), 5, 0), true);
         edtCliID_Enabled = 0;
         AssignProp("", false, edtCliID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliID_Enabled), 5, 0), true);
         edtCliInsData_Enabled = 0;
         AssignProp("", false, edtCliInsData_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliInsData_Enabled), 5, 0), true);
         edtCliInsHora_Enabled = 0;
         AssignProp("", false, edtCliInsHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliInsHora_Enabled), 5, 0), true);
         edtCliInsDataHora_Enabled = 0;
         AssignProp("", false, edtCliInsDataHora_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliInsDataHora_Enabled), 5, 0), true);
         edtCliInsUserID_Enabled = 0;
         AssignProp("", false, edtCliInsUserID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtCliInsUserID_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0O24( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0O0( )
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
         GXEncryptionTmp = "core.cliente.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.cliente.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Cliente");
         forbiddenHiddens.Add("CliTipo", context.localUtil.Format( (decimal)(A165CliTipo), "9"));
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV16Pgmname, "")));
         forbiddenHiddens.Add("CliInsUserNome", StringUtil.RTrim( context.localUtil.Format( A393CliInsUserNome, "@!")));
         forbiddenHiddens.Add("CliiUpdData", context.localUtil.Format(A177CliiUpdData, "99/99/99"));
         forbiddenHiddens.Add("CliUpdHora", context.localUtil.Format( A178CliUpdHora, "99:99"));
         forbiddenHiddens.Add("CliUpdDataHora", context.localUtil.Format( A179CliUpdDataHora, "99/99/9999 99:99:99.999"));
         forbiddenHiddens.Add("CliUpdUserID", StringUtil.RTrim( context.localUtil.Format( A180CliUpdUserID, "")));
         forbiddenHiddens.Add("CliUpdUserNome", StringUtil.RTrim( context.localUtil.Format( A394CliUpdUserNome, "@!")));
         forbiddenHiddens.Add("CliVersao", context.localUtil.Format( (decimal)(A196CliVersao), "ZZZ9"));
         forbiddenHiddens.Add("CliAtivo", StringUtil.BoolToStr( A197CliAtivo));
         forbiddenHiddens.Add("CliDel", StringUtil.BoolToStr( A524CliDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\cliente:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z158CliID", Z158CliID.ToString());
         GxWebStd.gx_hidden_field( context, "Z165CliTipo", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z165CliTipo), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z159CliMatricula", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z159CliMatricula), 12, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z163CliInsDataHora", context.localUtil.TToC( Z163CliInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z161CliInsData", context.localUtil.DToC( Z161CliInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z162CliInsHora", context.localUtil.TToC( Z162CliInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z525CliDelDataHora", context.localUtil.TToC( Z525CliDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z526CliDelData", context.localUtil.TToC( Z526CliDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z527CliDelHora", context.localUtil.TToC( Z527CliDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z528CliDelUsuId", StringUtil.RTrim( Z528CliDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z529CliDelUsuNome", Z529CliDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z160CliNomeFamiliar", Z160CliNomeFamiliar);
         GxWebStd.gx_hidden_field( context, "Z164CliInsUserID", StringUtil.RTrim( Z164CliInsUserID));
         GxWebStd.gx_hidden_field( context, "Z393CliInsUserNome", Z393CliInsUserNome);
         GxWebStd.gx_hidden_field( context, "Z177CliiUpdData", context.localUtil.DToC( Z177CliiUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z178CliUpdHora", context.localUtil.TToC( Z178CliUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z179CliUpdDataHora", context.localUtil.TToC( Z179CliUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z180CliUpdUserID", StringUtil.RTrim( Z180CliUpdUserID));
         GxWebStd.gx_hidden_field( context, "Z394CliUpdUserNome", Z394CliUpdUserNome);
         GxWebStd.gx_hidden_field( context, "Z196CliVersao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z196CliVersao), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z197CliAtivo", Z197CliAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z524CliDel", Z524CliDel);
         GxWebStd.gx_boolean_hidden_field( context, "O524CliDel", O524CliDel);
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
         GxWebStd.gx_hidden_field( context, "vCLIID", AV7CliID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vCLIID", GetSecureSignedToken( "", AV7CliID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "CLIDEL", A524CliDel);
         GxWebStd.gx_hidden_field( context, "CLIDELDATAHORA", context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIDELDATA", context.localUtil.TToC( A526CliDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIDELHORA", context.localUtil.TToC( A527CliDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIDELUSUID", StringUtil.RTrim( A528CliDelUsuId));
         GxWebStd.gx_hidden_field( context, "CLIDELUSUNOME", A529CliDelUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "CLIATIVO", A197CliAtivo);
         GxWebStd.gx_hidden_field( context, "CLIVERSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A196CliVersao), 4, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV15AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV15AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "CLIINSUSERNOME", A393CliInsUserNome);
         GxWebStd.gx_hidden_field( context, "CLIIUPDDATA", context.localUtil.DToC( A177CliiUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "CLIUPDHORA", context.localUtil.TToC( A178CliUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIUPDDATAHORA", context.localUtil.TToC( A179CliUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "CLIUPDUSERID", StringUtil.RTrim( A180CliUpdUserID));
         GxWebStd.gx_hidden_field( context, "CLIUPDUSERNOME", A394CliUpdUserNome);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV16Pgmname));
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
         GXEncryptionTmp = "core.cliente.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7CliID.ToString());
         return formatLink("core.cliente.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Cliente" ;
      }

      public override string GetPgmdesc( )
      {
         return "Cliente" ;
      }

      protected void InitializeNonKey0O24( )
      {
         AV15AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A165CliTipo = 0;
         AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
         A159CliMatricula = 0;
         AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
         A163CliInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A163CliInsDataHora", context.localUtil.TToC( A163CliInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A161CliInsData = DateTime.MinValue;
         AssignAttri("", false, "A161CliInsData", context.localUtil.Format(A161CliInsData, "99/99/99"));
         A162CliInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A162CliInsHora", context.localUtil.TToC( A162CliInsHora, 0, 5, 0, 3, "/", ":", " "));
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         A525CliDelDataHora = (DateTime)(DateTime.MinValue);
         n525CliDelDataHora = false;
         AssignAttri("", false, "A525CliDelDataHora", context.localUtil.TToC( A525CliDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A526CliDelData = (DateTime)(DateTime.MinValue);
         n526CliDelData = false;
         AssignAttri("", false, "A526CliDelData", context.localUtil.TToC( A526CliDelData, 10, 5, 0, 3, "/", ":", " "));
         A527CliDelHora = (DateTime)(DateTime.MinValue);
         n527CliDelHora = false;
         AssignAttri("", false, "A527CliDelHora", context.localUtil.TToC( A527CliDelHora, 0, 5, 0, 3, "/", ":", " "));
         A528CliDelUsuId = "";
         n528CliDelUsuId = false;
         AssignAttri("", false, "A528CliDelUsuId", A528CliDelUsuId);
         A529CliDelUsuNome = "";
         n529CliDelUsuNome = false;
         AssignAttri("", false, "A529CliDelUsuNome", A529CliDelUsuNome);
         A160CliNomeFamiliar = "";
         AssignAttri("", false, "A160CliNomeFamiliar", A160CliNomeFamiliar);
         A164CliInsUserID = "";
         n164CliInsUserID = false;
         AssignAttri("", false, "A164CliInsUserID", A164CliInsUserID);
         n164CliInsUserID = (String.IsNullOrEmpty(StringUtil.RTrim( A164CliInsUserID)) ? true : false);
         A393CliInsUserNome = "";
         n393CliInsUserNome = false;
         AssignAttri("", false, "A393CliInsUserNome", A393CliInsUserNome);
         A177CliiUpdData = DateTime.MinValue;
         n177CliiUpdData = false;
         AssignAttri("", false, "A177CliiUpdData", context.localUtil.Format(A177CliiUpdData, "99/99/99"));
         A178CliUpdHora = (DateTime)(DateTime.MinValue);
         n178CliUpdHora = false;
         AssignAttri("", false, "A178CliUpdHora", context.localUtil.TToC( A178CliUpdHora, 0, 5, 0, 3, "/", ":", " "));
         A179CliUpdDataHora = (DateTime)(DateTime.MinValue);
         n179CliUpdDataHora = false;
         AssignAttri("", false, "A179CliUpdDataHora", context.localUtil.TToC( A179CliUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A180CliUpdUserID = "";
         n180CliUpdUserID = false;
         AssignAttri("", false, "A180CliUpdUserID", A180CliUpdUserID);
         A394CliUpdUserNome = "";
         n394CliUpdUserNome = false;
         AssignAttri("", false, "A394CliUpdUserNome", A394CliUpdUserNome);
         A524CliDel = false;
         AssignAttri("", false, "A524CliDel", A524CliDel);
         A196CliVersao = 1;
         AssignAttri("", false, "A196CliVersao", StringUtil.LTrimStr( (decimal)(A196CliVersao), 4, 0));
         A197CliAtivo = true;
         AssignAttri("", false, "A197CliAtivo", A197CliAtivo);
         O524CliDel = A524CliDel;
         AssignAttri("", false, "A524CliDel", A524CliDel);
         Z165CliTipo = 0;
         Z159CliMatricula = 0;
         Z163CliInsDataHora = (DateTime)(DateTime.MinValue);
         Z161CliInsData = DateTime.MinValue;
         Z162CliInsHora = (DateTime)(DateTime.MinValue);
         Z525CliDelDataHora = (DateTime)(DateTime.MinValue);
         Z526CliDelData = (DateTime)(DateTime.MinValue);
         Z527CliDelHora = (DateTime)(DateTime.MinValue);
         Z528CliDelUsuId = "";
         Z529CliDelUsuNome = "";
         Z160CliNomeFamiliar = "";
         Z164CliInsUserID = "";
         Z393CliInsUserNome = "";
         Z177CliiUpdData = DateTime.MinValue;
         Z178CliUpdHora = (DateTime)(DateTime.MinValue);
         Z179CliUpdDataHora = (DateTime)(DateTime.MinValue);
         Z180CliUpdUserID = "";
         Z394CliUpdUserNome = "";
         Z196CliVersao = 0;
         Z197CliAtivo = false;
         Z524CliDel = false;
      }

      protected void InitAll0O24( )
      {
         A158CliID = Guid.NewGuid( );
         AssignAttri("", false, "A158CliID", A158CliID.ToString());
         InitializeNonKey0O24( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A165CliTipo = i165CliTipo;
         AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
         A197CliAtivo = i197CliAtivo;
         AssignAttri("", false, "A197CliAtivo", A197CliAtivo);
         A196CliVersao = i196CliVersao;
         AssignAttri("", false, "A196CliVersao", StringUtil.LTrimStr( (decimal)(A196CliVersao), 4, 0));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382813287", true, true);
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
         context.AddJavascriptSource("core/cliente.js", "?202382813289", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtCliMatricula_Internalname = "CLIMATRICULA";
         edtCliNomeFamiliar_Internalname = "CLINOMEFAMILIAR";
         cmbCliTipo_Internalname = "CLITIPO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         cmbavClitipo_Internalname = "vCLITIPO";
         edtCliID_Internalname = "CLIID";
         edtCliInsData_Internalname = "CLIINSDATA";
         edtCliInsHora_Internalname = "CLIINSHORA";
         edtCliInsDataHora_Internalname = "CLIINSDATAHORA";
         edtCliInsUserID_Internalname = "CLIINSUSERID";
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
         Form.Caption = "Cliente";
         edtCliInsUserID_Jsonclick = "";
         edtCliInsUserID_Enabled = 1;
         edtCliInsUserID_Visible = 1;
         edtCliInsDataHora_Jsonclick = "";
         edtCliInsDataHora_Enabled = 1;
         edtCliInsDataHora_Visible = 1;
         edtCliInsHora_Jsonclick = "";
         edtCliInsHora_Enabled = 1;
         edtCliInsHora_Visible = 1;
         edtCliInsData_Jsonclick = "";
         edtCliInsData_Enabled = 1;
         edtCliInsData_Visible = 1;
         edtCliID_Jsonclick = "";
         edtCliID_Enabled = 1;
         edtCliID_Visible = 1;
         cmbavClitipo_Jsonclick = "";
         cmbavClitipo.Visible = 1;
         cmbavClitipo.Enabled = 0;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         cmbCliTipo_Jsonclick = "";
         cmbCliTipo.Enabled = 0;
         edtCliNomeFamiliar_Jsonclick = "";
         edtCliNomeFamiliar_Enabled = 1;
         edtCliMatricula_Jsonclick = "";
         edtCliMatricula_Enabled = 0;
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

      protected void GX7ASACLIMATRICULA0O24( string Gx_mode )
      {
         if ( IsIns( )  )
         {
            GXt_int1 = (int)(A159CliMatricula);
            new GeneXus.Programs.core.serializar(context ).execute(  "CliMatricula",  1, out  GXt_int1) ;
            A159CliMatricula = GXt_int1;
            AssignAttri("", false, "A159CliMatricula", StringUtil.LTrimStr( (decimal)(A159CliMatricula), 12, 0));
            GxWebStd.gx_hidden_field( context, "gxhash_CLIMATRICULA", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(A159CliMatricula), "ZZZ,ZZZ,ZZZ,ZZ9"), context));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A159CliMatricula), 12, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_22_0O24( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV15AuditingObject ,
                                 Guid A158CliID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcliente(context ).execute(  "Y", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV15AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_23_0O24( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV15AuditingObject ,
                                 Guid A158CliID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditcliente(context ).execute(  "Y", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV15AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_24_0O24( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV15AuditingObject ,
                                 Guid A158CliID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditcliente(context ).execute(  "N", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV15AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_25_0O24( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV15AuditingObject ,
                                 Guid A158CliID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditcliente(context ).execute(  "N", ref  AV15AuditingObject,  A158CliID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV15AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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
         cmbCliTipo.Name = "CLITIPO";
         cmbCliTipo.WebTags = "";
         cmbCliTipo.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(Nenhum)", 0);
         cmbCliTipo.addItem("1", "Pessoa Física", 0);
         cmbCliTipo.addItem("2", "Pessoa Jurídica", 0);
         if ( cmbCliTipo.ItemCount > 0 )
         {
            A165CliTipo = (short)(Math.Round(NumberUtil.Val( cmbCliTipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A165CliTipo), 1, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A165CliTipo", StringUtil.Str( (decimal)(A165CliTipo), 1, 0));
         }
         cmbavClitipo.Name = "vCLITIPO";
         cmbavClitipo.WebTags = "";
         cmbavClitipo.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(0), 1, 0)), "(Nenhum)", 0);
         cmbavClitipo.addItem("1", "Pessoa Física", 0);
         cmbavClitipo.addItem("2", "Pessoa Jurídica", 0);
         if ( cmbavClitipo.ItemCount > 0 )
         {
            AV14CliTipo = (short)(Math.Round(NumberUtil.Val( cmbavClitipo.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV14CliTipo), 1, 0))), "."), 18, MidpointRounding.ToEven));
         }
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

      public void Valid_Climatricula( )
      {
         /* Using cursor T000O15 */
         pr_default.execute(13, new Object[] {A159CliMatricula, A158CliID});
         if ( (pr_default.getStatus(13) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Matrícula"}), 1, "CLIMATRICULA");
            AnyError = 1;
            GX_FocusControl = edtCliMatricula_Internalname;
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7CliID',fld:'vCLIID',pic:'',hsh:true},{av:'cmbCliTipo'},{av:'A165CliTipo',fld:'CLITIPO',pic:'9'},{av:'AV16Pgmname',fld:'vPGMNAME',pic:''},{av:'A393CliInsUserNome',fld:'CLIINSUSERNOME',pic:'@!'},{av:'A177CliiUpdData',fld:'CLIIUPDDATA',pic:''},{av:'A178CliUpdHora',fld:'CLIUPDHORA',pic:'99:99'},{av:'A179CliUpdDataHora',fld:'CLIUPDDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'A180CliUpdUserID',fld:'CLIUPDUSERID',pic:''},{av:'A394CliUpdUserNome',fld:'CLIUPDUSERNOME',pic:'@!'},{av:'A196CliVersao',fld:'CLIVERSAO',pic:'ZZZ9'},{av:'A197CliAtivo',fld:'CLIATIVO',pic:''},{av:'A524CliDel',fld:'CLIDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E120O2',iparms:[{av:'AV15AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV16Pgmname',fld:'vPGMNAME',pic:''},{av:'A158CliID',fld:'CLIID',pic:''},{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_CLIMATRICULA","{handler:'Valid_Climatricula',iparms:[{av:'A159CliMatricula',fld:'CLIMATRICULA',pic:'ZZZ,ZZZ,ZZZ,ZZ9',hsh:true},{av:'A158CliID',fld:'CLIID',pic:''}]");
         setEventMetadata("VALID_CLIMATRICULA",",oparms:[]}");
         setEventMetadata("VALID_CLINOMEFAMILIAR","{handler:'Valid_Clinomefamiliar',iparms:[]");
         setEventMetadata("VALID_CLINOMEFAMILIAR",",oparms:[]}");
         setEventMetadata("VALID_CLIID","{handler:'Valid_Cliid',iparms:[]");
         setEventMetadata("VALID_CLIID",",oparms:[]}");
         setEventMetadata("VALID_CLIINSDATAHORA","{handler:'Valid_Cliinsdatahora',iparms:[]");
         setEventMetadata("VALID_CLIINSDATAHORA",",oparms:[]}");
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
         wcpOAV7CliID = Guid.Empty;
         Z158CliID = Guid.Empty;
         Z163CliInsDataHora = (DateTime)(DateTime.MinValue);
         Z161CliInsData = DateTime.MinValue;
         Z162CliInsHora = (DateTime)(DateTime.MinValue);
         Z525CliDelDataHora = (DateTime)(DateTime.MinValue);
         Z526CliDelData = (DateTime)(DateTime.MinValue);
         Z527CliDelHora = (DateTime)(DateTime.MinValue);
         Z528CliDelUsuId = "";
         Z529CliDelUsuNome = "";
         Z160CliNomeFamiliar = "";
         Z164CliInsUserID = "";
         Z393CliInsUserNome = "";
         Z177CliiUpdData = DateTime.MinValue;
         Z178CliUpdHora = (DateTime)(DateTime.MinValue);
         Z179CliUpdDataHora = (DateTime)(DateTime.MinValue);
         Z180CliUpdUserID = "";
         Z394CliUpdUserNome = "";
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
         A160CliNomeFamiliar = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A158CliID = Guid.Empty;
         A161CliInsData = DateTime.MinValue;
         A162CliInsHora = (DateTime)(DateTime.MinValue);
         A163CliInsDataHora = (DateTime)(DateTime.MinValue);
         A164CliInsUserID = "";
         A525CliDelDataHora = (DateTime)(DateTime.MinValue);
         A526CliDelData = (DateTime)(DateTime.MinValue);
         A527CliDelHora = (DateTime)(DateTime.MinValue);
         A528CliDelUsuId = "";
         A529CliDelUsuNome = "";
         A393CliInsUserNome = "";
         A177CliiUpdData = DateTime.MinValue;
         A178CliUpdHora = (DateTime)(DateTime.MinValue);
         A179CliUpdDataHora = (DateTime)(DateTime.MinValue);
         A180CliUpdUserID = "";
         A394CliUpdUserNome = "";
         AV15AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV16Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode24 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV12WebSession = context.GetSession();
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         T000O4_A158CliID = new Guid[] {Guid.Empty} ;
         T000O4_A165CliTipo = new short[1] ;
         T000O4_A159CliMatricula = new long[1] ;
         T000O4_A163CliInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         T000O4_A162CliInsHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_A525CliDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_n525CliDelDataHora = new bool[] {false} ;
         T000O4_A526CliDelData = new DateTime[] {DateTime.MinValue} ;
         T000O4_n526CliDelData = new bool[] {false} ;
         T000O4_A527CliDelHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_n527CliDelHora = new bool[] {false} ;
         T000O4_A528CliDelUsuId = new string[] {""} ;
         T000O4_n528CliDelUsuId = new bool[] {false} ;
         T000O4_A529CliDelUsuNome = new string[] {""} ;
         T000O4_n529CliDelUsuNome = new bool[] {false} ;
         T000O4_A160CliNomeFamiliar = new string[] {""} ;
         T000O4_A164CliInsUserID = new string[] {""} ;
         T000O4_n164CliInsUserID = new bool[] {false} ;
         T000O4_A393CliInsUserNome = new string[] {""} ;
         T000O4_n393CliInsUserNome = new bool[] {false} ;
         T000O4_A177CliiUpdData = new DateTime[] {DateTime.MinValue} ;
         T000O4_n177CliiUpdData = new bool[] {false} ;
         T000O4_A178CliUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_n178CliUpdHora = new bool[] {false} ;
         T000O4_A179CliUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O4_n179CliUpdDataHora = new bool[] {false} ;
         T000O4_A180CliUpdUserID = new string[] {""} ;
         T000O4_n180CliUpdUserID = new bool[] {false} ;
         T000O4_A394CliUpdUserNome = new string[] {""} ;
         T000O4_n394CliUpdUserNome = new bool[] {false} ;
         T000O4_A196CliVersao = new short[1] ;
         T000O4_A197CliAtivo = new bool[] {false} ;
         T000O4_A524CliDel = new bool[] {false} ;
         T000O5_A159CliMatricula = new long[1] ;
         T000O6_A158CliID = new Guid[] {Guid.Empty} ;
         T000O3_A158CliID = new Guid[] {Guid.Empty} ;
         T000O3_A165CliTipo = new short[1] ;
         T000O3_A159CliMatricula = new long[1] ;
         T000O3_A163CliInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         T000O3_A162CliInsHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_A525CliDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_n525CliDelDataHora = new bool[] {false} ;
         T000O3_A526CliDelData = new DateTime[] {DateTime.MinValue} ;
         T000O3_n526CliDelData = new bool[] {false} ;
         T000O3_A527CliDelHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_n527CliDelHora = new bool[] {false} ;
         T000O3_A528CliDelUsuId = new string[] {""} ;
         T000O3_n528CliDelUsuId = new bool[] {false} ;
         T000O3_A529CliDelUsuNome = new string[] {""} ;
         T000O3_n529CliDelUsuNome = new bool[] {false} ;
         T000O3_A160CliNomeFamiliar = new string[] {""} ;
         T000O3_A164CliInsUserID = new string[] {""} ;
         T000O3_n164CliInsUserID = new bool[] {false} ;
         T000O3_A393CliInsUserNome = new string[] {""} ;
         T000O3_n393CliInsUserNome = new bool[] {false} ;
         T000O3_A177CliiUpdData = new DateTime[] {DateTime.MinValue} ;
         T000O3_n177CliiUpdData = new bool[] {false} ;
         T000O3_A178CliUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_n178CliUpdHora = new bool[] {false} ;
         T000O3_A179CliUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O3_n179CliUpdDataHora = new bool[] {false} ;
         T000O3_A180CliUpdUserID = new string[] {""} ;
         T000O3_n180CliUpdUserID = new bool[] {false} ;
         T000O3_A394CliUpdUserNome = new string[] {""} ;
         T000O3_n394CliUpdUserNome = new bool[] {false} ;
         T000O3_A196CliVersao = new short[1] ;
         T000O3_A197CliAtivo = new bool[] {false} ;
         T000O3_A524CliDel = new bool[] {false} ;
         T000O7_A158CliID = new Guid[] {Guid.Empty} ;
         T000O8_A158CliID = new Guid[] {Guid.Empty} ;
         T000O2_A158CliID = new Guid[] {Guid.Empty} ;
         T000O2_A165CliTipo = new short[1] ;
         T000O2_A159CliMatricula = new long[1] ;
         T000O2_A163CliInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_A161CliInsData = new DateTime[] {DateTime.MinValue} ;
         T000O2_A162CliInsHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_A525CliDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_n525CliDelDataHora = new bool[] {false} ;
         T000O2_A526CliDelData = new DateTime[] {DateTime.MinValue} ;
         T000O2_n526CliDelData = new bool[] {false} ;
         T000O2_A527CliDelHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_n527CliDelHora = new bool[] {false} ;
         T000O2_A528CliDelUsuId = new string[] {""} ;
         T000O2_n528CliDelUsuId = new bool[] {false} ;
         T000O2_A529CliDelUsuNome = new string[] {""} ;
         T000O2_n529CliDelUsuNome = new bool[] {false} ;
         T000O2_A160CliNomeFamiliar = new string[] {""} ;
         T000O2_A164CliInsUserID = new string[] {""} ;
         T000O2_n164CliInsUserID = new bool[] {false} ;
         T000O2_A393CliInsUserNome = new string[] {""} ;
         T000O2_n393CliInsUserNome = new bool[] {false} ;
         T000O2_A177CliiUpdData = new DateTime[] {DateTime.MinValue} ;
         T000O2_n177CliiUpdData = new bool[] {false} ;
         T000O2_A178CliUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_n178CliUpdHora = new bool[] {false} ;
         T000O2_A179CliUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000O2_n179CliUpdDataHora = new bool[] {false} ;
         T000O2_A180CliUpdUserID = new string[] {""} ;
         T000O2_n180CliUpdUserID = new bool[] {false} ;
         T000O2_A394CliUpdUserNome = new string[] {""} ;
         T000O2_n394CliUpdUserNome = new bool[] {false} ;
         T000O2_A196CliVersao = new short[1] ;
         T000O2_A197CliAtivo = new bool[] {false} ;
         T000O2_A524CliDel = new bool[] {false} ;
         T000O12_A345NegID = new Guid[] {Guid.Empty} ;
         T000O13_A158CliID = new Guid[] {Guid.Empty} ;
         T000O13_A166CpjID = new Guid[] {Guid.Empty} ;
         T000O14_A158CliID = new Guid[] {Guid.Empty} ;
         AV13GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T000O15_A159CliMatricula = new long[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.cliente__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.cliente__default(),
            new Object[][] {
                new Object[] {
               T000O2_A158CliID, T000O2_A165CliTipo, T000O2_A159CliMatricula, T000O2_A163CliInsDataHora, T000O2_A161CliInsData, T000O2_A162CliInsHora, T000O2_A525CliDelDataHora, T000O2_n525CliDelDataHora, T000O2_A526CliDelData, T000O2_n526CliDelData,
               T000O2_A527CliDelHora, T000O2_n527CliDelHora, T000O2_A528CliDelUsuId, T000O2_n528CliDelUsuId, T000O2_A529CliDelUsuNome, T000O2_n529CliDelUsuNome, T000O2_A160CliNomeFamiliar, T000O2_A164CliInsUserID, T000O2_n164CliInsUserID, T000O2_A393CliInsUserNome,
               T000O2_n393CliInsUserNome, T000O2_A177CliiUpdData, T000O2_n177CliiUpdData, T000O2_A178CliUpdHora, T000O2_n178CliUpdHora, T000O2_A179CliUpdDataHora, T000O2_n179CliUpdDataHora, T000O2_A180CliUpdUserID, T000O2_n180CliUpdUserID, T000O2_A394CliUpdUserNome,
               T000O2_n394CliUpdUserNome, T000O2_A196CliVersao, T000O2_A197CliAtivo, T000O2_A524CliDel
               }
               , new Object[] {
               T000O3_A158CliID, T000O3_A165CliTipo, T000O3_A159CliMatricula, T000O3_A163CliInsDataHora, T000O3_A161CliInsData, T000O3_A162CliInsHora, T000O3_A525CliDelDataHora, T000O3_n525CliDelDataHora, T000O3_A526CliDelData, T000O3_n526CliDelData,
               T000O3_A527CliDelHora, T000O3_n527CliDelHora, T000O3_A528CliDelUsuId, T000O3_n528CliDelUsuId, T000O3_A529CliDelUsuNome, T000O3_n529CliDelUsuNome, T000O3_A160CliNomeFamiliar, T000O3_A164CliInsUserID, T000O3_n164CliInsUserID, T000O3_A393CliInsUserNome,
               T000O3_n393CliInsUserNome, T000O3_A177CliiUpdData, T000O3_n177CliiUpdData, T000O3_A178CliUpdHora, T000O3_n178CliUpdHora, T000O3_A179CliUpdDataHora, T000O3_n179CliUpdDataHora, T000O3_A180CliUpdUserID, T000O3_n180CliUpdUserID, T000O3_A394CliUpdUserNome,
               T000O3_n394CliUpdUserNome, T000O3_A196CliVersao, T000O3_A197CliAtivo, T000O3_A524CliDel
               }
               , new Object[] {
               T000O4_A158CliID, T000O4_A165CliTipo, T000O4_A159CliMatricula, T000O4_A163CliInsDataHora, T000O4_A161CliInsData, T000O4_A162CliInsHora, T000O4_A525CliDelDataHora, T000O4_n525CliDelDataHora, T000O4_A526CliDelData, T000O4_n526CliDelData,
               T000O4_A527CliDelHora, T000O4_n527CliDelHora, T000O4_A528CliDelUsuId, T000O4_n528CliDelUsuId, T000O4_A529CliDelUsuNome, T000O4_n529CliDelUsuNome, T000O4_A160CliNomeFamiliar, T000O4_A164CliInsUserID, T000O4_n164CliInsUserID, T000O4_A393CliInsUserNome,
               T000O4_n393CliInsUserNome, T000O4_A177CliiUpdData, T000O4_n177CliiUpdData, T000O4_A178CliUpdHora, T000O4_n178CliUpdHora, T000O4_A179CliUpdDataHora, T000O4_n179CliUpdDataHora, T000O4_A180CliUpdUserID, T000O4_n180CliUpdUserID, T000O4_A394CliUpdUserNome,
               T000O4_n394CliUpdUserNome, T000O4_A196CliVersao, T000O4_A197CliAtivo, T000O4_A524CliDel
               }
               , new Object[] {
               T000O5_A159CliMatricula
               }
               , new Object[] {
               T000O6_A158CliID
               }
               , new Object[] {
               T000O7_A158CliID
               }
               , new Object[] {
               T000O8_A158CliID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000O12_A345NegID
               }
               , new Object[] {
               T000O13_A158CliID, T000O13_A166CpjID
               }
               , new Object[] {
               T000O14_A158CliID
               }
               , new Object[] {
               T000O15_A159CliMatricula
               }
            }
         );
         Z197CliAtivo = true;
         A197CliAtivo = true;
         i197CliAtivo = true;
         Z196CliVersao = 1;
         A196CliVersao = 1;
         i196CliVersao = 1;
         Z158CliID = Guid.NewGuid( );
         A158CliID = Guid.NewGuid( );
         AV16Pgmname = "core.Cliente";
      }

      private short Z165CliTipo ;
      private short Z196CliVersao ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A165CliTipo ;
      private short AV14CliTipo ;
      private short A196CliVersao ;
      private short Gx_BScreen ;
      private short RcdFound24 ;
      private short GX_JID ;
      private short nIsDirty_24 ;
      private short gxajaxcallmode ;
      private short i165CliTipo ;
      private short i196CliVersao ;
      private int trnEnded ;
      private int edtCliMatricula_Enabled ;
      private int edtCliNomeFamiliar_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtCliID_Visible ;
      private int edtCliID_Enabled ;
      private int edtCliInsData_Visible ;
      private int edtCliInsData_Enabled ;
      private int edtCliInsHora_Visible ;
      private int edtCliInsHora_Enabled ;
      private int edtCliInsDataHora_Visible ;
      private int edtCliInsDataHora_Enabled ;
      private int edtCliInsUserID_Visible ;
      private int edtCliInsUserID_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int GXt_int1 ;
      private long Z159CliMatricula ;
      private long A159CliMatricula ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z528CliDelUsuId ;
      private string Z164CliInsUserID ;
      private string Z180CliUpdUserID ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string GXKey ;
      private string GXDecQS ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtCliNomeFamiliar_Internalname ;
      private string cmbCliTipo_Internalname ;
      private string cmbavClitipo_Internalname ;
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
      private string edtCliMatricula_Internalname ;
      private string edtCliMatricula_Jsonclick ;
      private string TempTags ;
      private string edtCliNomeFamiliar_Jsonclick ;
      private string cmbCliTipo_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string cmbavClitipo_Jsonclick ;
      private string edtCliID_Internalname ;
      private string edtCliID_Jsonclick ;
      private string edtCliInsData_Internalname ;
      private string edtCliInsData_Jsonclick ;
      private string edtCliInsHora_Internalname ;
      private string edtCliInsHora_Jsonclick ;
      private string edtCliInsDataHora_Internalname ;
      private string edtCliInsDataHora_Jsonclick ;
      private string edtCliInsUserID_Internalname ;
      private string A164CliInsUserID ;
      private string edtCliInsUserID_Jsonclick ;
      private string A528CliDelUsuId ;
      private string A180CliUpdUserID ;
      private string AV16Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode24 ;
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
      private DateTime Z163CliInsDataHora ;
      private DateTime Z162CliInsHora ;
      private DateTime Z525CliDelDataHora ;
      private DateTime Z526CliDelData ;
      private DateTime Z527CliDelHora ;
      private DateTime Z178CliUpdHora ;
      private DateTime Z179CliUpdDataHora ;
      private DateTime A162CliInsHora ;
      private DateTime A163CliInsDataHora ;
      private DateTime A525CliDelDataHora ;
      private DateTime A526CliDelData ;
      private DateTime A527CliDelHora ;
      private DateTime A178CliUpdHora ;
      private DateTime A179CliUpdDataHora ;
      private DateTime Z161CliInsData ;
      private DateTime Z177CliiUpdData ;
      private DateTime A161CliInsData ;
      private DateTime A177CliiUpdData ;
      private bool Z197CliAtivo ;
      private bool Z524CliDel ;
      private bool O524CliDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n525CliDelDataHora ;
      private bool n526CliDelData ;
      private bool n527CliDelHora ;
      private bool n528CliDelUsuId ;
      private bool n529CliDelUsuNome ;
      private bool n164CliInsUserID ;
      private bool n393CliInsUserNome ;
      private bool n177CliiUpdData ;
      private bool n178CliUpdHora ;
      private bool n179CliUpdDataHora ;
      private bool n180CliUpdUserID ;
      private bool n394CliUpdUserNome ;
      private bool A197CliAtivo ;
      private bool A524CliDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i197CliAtivo ;
      private string Z529CliDelUsuNome ;
      private string Z160CliNomeFamiliar ;
      private string Z393CliInsUserNome ;
      private string Z394CliUpdUserNome ;
      private string A160CliNomeFamiliar ;
      private string A529CliDelUsuNome ;
      private string A393CliInsUserNome ;
      private string A394CliUpdUserNome ;
      private Guid wcpOAV7CliID ;
      private Guid Z158CliID ;
      private Guid AV7CliID ;
      private Guid A158CliID ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbCliTipo ;
      private GXCombobox cmbavClitipo ;
      private IDataStoreProvider pr_default ;
      private Guid[] T000O4_A158CliID ;
      private short[] T000O4_A165CliTipo ;
      private long[] T000O4_A159CliMatricula ;
      private DateTime[] T000O4_A163CliInsDataHora ;
      private DateTime[] T000O4_A161CliInsData ;
      private DateTime[] T000O4_A162CliInsHora ;
      private DateTime[] T000O4_A525CliDelDataHora ;
      private bool[] T000O4_n525CliDelDataHora ;
      private DateTime[] T000O4_A526CliDelData ;
      private bool[] T000O4_n526CliDelData ;
      private DateTime[] T000O4_A527CliDelHora ;
      private bool[] T000O4_n527CliDelHora ;
      private string[] T000O4_A528CliDelUsuId ;
      private bool[] T000O4_n528CliDelUsuId ;
      private string[] T000O4_A529CliDelUsuNome ;
      private bool[] T000O4_n529CliDelUsuNome ;
      private string[] T000O4_A160CliNomeFamiliar ;
      private string[] T000O4_A164CliInsUserID ;
      private bool[] T000O4_n164CliInsUserID ;
      private string[] T000O4_A393CliInsUserNome ;
      private bool[] T000O4_n393CliInsUserNome ;
      private DateTime[] T000O4_A177CliiUpdData ;
      private bool[] T000O4_n177CliiUpdData ;
      private DateTime[] T000O4_A178CliUpdHora ;
      private bool[] T000O4_n178CliUpdHora ;
      private DateTime[] T000O4_A179CliUpdDataHora ;
      private bool[] T000O4_n179CliUpdDataHora ;
      private string[] T000O4_A180CliUpdUserID ;
      private bool[] T000O4_n180CliUpdUserID ;
      private string[] T000O4_A394CliUpdUserNome ;
      private bool[] T000O4_n394CliUpdUserNome ;
      private short[] T000O4_A196CliVersao ;
      private bool[] T000O4_A197CliAtivo ;
      private bool[] T000O4_A524CliDel ;
      private long[] T000O5_A159CliMatricula ;
      private Guid[] T000O6_A158CliID ;
      private Guid[] T000O3_A158CliID ;
      private short[] T000O3_A165CliTipo ;
      private long[] T000O3_A159CliMatricula ;
      private DateTime[] T000O3_A163CliInsDataHora ;
      private DateTime[] T000O3_A161CliInsData ;
      private DateTime[] T000O3_A162CliInsHora ;
      private DateTime[] T000O3_A525CliDelDataHora ;
      private bool[] T000O3_n525CliDelDataHora ;
      private DateTime[] T000O3_A526CliDelData ;
      private bool[] T000O3_n526CliDelData ;
      private DateTime[] T000O3_A527CliDelHora ;
      private bool[] T000O3_n527CliDelHora ;
      private string[] T000O3_A528CliDelUsuId ;
      private bool[] T000O3_n528CliDelUsuId ;
      private string[] T000O3_A529CliDelUsuNome ;
      private bool[] T000O3_n529CliDelUsuNome ;
      private string[] T000O3_A160CliNomeFamiliar ;
      private string[] T000O3_A164CliInsUserID ;
      private bool[] T000O3_n164CliInsUserID ;
      private string[] T000O3_A393CliInsUserNome ;
      private bool[] T000O3_n393CliInsUserNome ;
      private DateTime[] T000O3_A177CliiUpdData ;
      private bool[] T000O3_n177CliiUpdData ;
      private DateTime[] T000O3_A178CliUpdHora ;
      private bool[] T000O3_n178CliUpdHora ;
      private DateTime[] T000O3_A179CliUpdDataHora ;
      private bool[] T000O3_n179CliUpdDataHora ;
      private string[] T000O3_A180CliUpdUserID ;
      private bool[] T000O3_n180CliUpdUserID ;
      private string[] T000O3_A394CliUpdUserNome ;
      private bool[] T000O3_n394CliUpdUserNome ;
      private short[] T000O3_A196CliVersao ;
      private bool[] T000O3_A197CliAtivo ;
      private bool[] T000O3_A524CliDel ;
      private Guid[] T000O7_A158CliID ;
      private Guid[] T000O8_A158CliID ;
      private Guid[] T000O2_A158CliID ;
      private short[] T000O2_A165CliTipo ;
      private long[] T000O2_A159CliMatricula ;
      private DateTime[] T000O2_A163CliInsDataHora ;
      private DateTime[] T000O2_A161CliInsData ;
      private DateTime[] T000O2_A162CliInsHora ;
      private DateTime[] T000O2_A525CliDelDataHora ;
      private bool[] T000O2_n525CliDelDataHora ;
      private DateTime[] T000O2_A526CliDelData ;
      private bool[] T000O2_n526CliDelData ;
      private DateTime[] T000O2_A527CliDelHora ;
      private bool[] T000O2_n527CliDelHora ;
      private string[] T000O2_A528CliDelUsuId ;
      private bool[] T000O2_n528CliDelUsuId ;
      private string[] T000O2_A529CliDelUsuNome ;
      private bool[] T000O2_n529CliDelUsuNome ;
      private string[] T000O2_A160CliNomeFamiliar ;
      private string[] T000O2_A164CliInsUserID ;
      private bool[] T000O2_n164CliInsUserID ;
      private string[] T000O2_A393CliInsUserNome ;
      private bool[] T000O2_n393CliInsUserNome ;
      private DateTime[] T000O2_A177CliiUpdData ;
      private bool[] T000O2_n177CliiUpdData ;
      private DateTime[] T000O2_A178CliUpdHora ;
      private bool[] T000O2_n178CliUpdHora ;
      private DateTime[] T000O2_A179CliUpdDataHora ;
      private bool[] T000O2_n179CliUpdDataHora ;
      private string[] T000O2_A180CliUpdUserID ;
      private bool[] T000O2_n180CliUpdUserID ;
      private string[] T000O2_A394CliUpdUserNome ;
      private bool[] T000O2_n394CliUpdUserNome ;
      private short[] T000O2_A196CliVersao ;
      private bool[] T000O2_A197CliAtivo ;
      private bool[] T000O2_A524CliDel ;
      private Guid[] T000O12_A345NegID ;
      private Guid[] T000O13_A158CliID ;
      private Guid[] T000O13_A166CpjID ;
      private Guid[] T000O14_A158CliID ;
      private long[] T000O15_A159CliMatricula ;
      private IDataStoreProvider pr_gam ;
      private IGxSession AV12WebSession ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV13GAMUser ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV15AuditingObject ;
   }

   public class cliente__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class cliente__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000O4;
        prmT000O4 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O5;
        prmT000O5 = new Object[] {
        new ParDef("CliMatricula",GXType.Int64,12,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O6;
        prmT000O6 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O3;
        prmT000O3 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O7;
        prmT000O7 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O8;
        prmT000O8 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O2;
        prmT000O2 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O9;
        prmT000O9 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("CliTipo",GXType.Int16,1,0) ,
        new ParDef("CliMatricula",GXType.Int64,12,0) ,
        new ParDef("CliInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("CliInsData",GXType.Date,8,0) ,
        new ParDef("CliInsHora",GXType.DateTime,0,5) ,
        new ParDef("CliDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CliDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CliDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CliDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("CliInsUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliInsUserNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliiUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("CliUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CliUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CliUpdUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliUpdUserNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliVersao",GXType.Int16,4,0) ,
        new ParDef("CliAtivo",GXType.Boolean,4,0) ,
        new ParDef("CliDel",GXType.Boolean,4,0)
        };
        Object[] prmT000O10;
        prmT000O10 = new Object[] {
        new ParDef("CliTipo",GXType.Int16,1,0) ,
        new ParDef("CliMatricula",GXType.Int64,12,0) ,
        new ParDef("CliInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("CliInsData",GXType.Date,8,0) ,
        new ParDef("CliInsHora",GXType.DateTime,0,5) ,
        new ParDef("CliDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CliDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("CliDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CliDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliNomeFamiliar",GXType.VarChar,80,0) ,
        new ParDef("CliInsUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliInsUserNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliiUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("CliUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("CliUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("CliUpdUserID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("CliUpdUserNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("CliVersao",GXType.Int16,4,0) ,
        new ParDef("CliAtivo",GXType.Boolean,4,0) ,
        new ParDef("CliDel",GXType.Boolean,4,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O11;
        prmT000O11 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O12;
        prmT000O12 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O13;
        prmT000O13 = new Object[] {
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000O14;
        prmT000O14 = new Object[] {
        };
        Object[] prmT000O15;
        prmT000O15 = new Object[] {
        new ParDef("CliMatricula",GXType.Int64,12,0) ,
        new ParDef("CliID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000O2", "SELECT CliID, CliTipo, CliMatricula, CliInsDataHora, CliInsData, CliInsHora, CliDelDataHora, CliDelData, CliDelHora, CliDelUsuId, CliDelUsuNome, CliNomeFamiliar, CliInsUserID, CliInsUserNome, CliiUpdData, CliUpdHora, CliUpdDataHora, CliUpdUserID, CliUpdUserNome, CliVersao, CliAtivo, CliDel FROM tb_cliente WHERE CliID = :CliID  FOR UPDATE OF tb_cliente NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000O2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O3", "SELECT CliID, CliTipo, CliMatricula, CliInsDataHora, CliInsData, CliInsHora, CliDelDataHora, CliDelData, CliDelHora, CliDelUsuId, CliDelUsuNome, CliNomeFamiliar, CliInsUserID, CliInsUserNome, CliiUpdData, CliUpdHora, CliUpdDataHora, CliUpdUserID, CliUpdUserNome, CliVersao, CliAtivo, CliDel FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O4", "SELECT TM1.CliID, TM1.CliTipo, TM1.CliMatricula, TM1.CliInsDataHora, TM1.CliInsData, TM1.CliInsHora, TM1.CliDelDataHora, TM1.CliDelData, TM1.CliDelHora, TM1.CliDelUsuId, TM1.CliDelUsuNome, TM1.CliNomeFamiliar, TM1.CliInsUserID, TM1.CliInsUserNome, TM1.CliiUpdData, TM1.CliUpdHora, TM1.CliUpdDataHora, TM1.CliUpdUserID, TM1.CliUpdUserNome, TM1.CliVersao, TM1.CliAtivo, TM1.CliDel FROM tb_cliente TM1 WHERE TM1.CliID = :CliID ORDER BY TM1.CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O5", "SELECT CliMatricula FROM tb_cliente WHERE (CliMatricula = :CliMatricula) AND (Not ( CliID = :CliID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O6", "SELECT CliID FROM tb_cliente WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O7", "SELECT CliID FROM tb_cliente WHERE ( CliID > :CliID) ORDER BY CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O8", "SELECT CliID FROM tb_cliente WHERE ( CliID < :CliID) ORDER BY CliID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O8,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O9", "SAVEPOINT gxupdate;INSERT INTO tb_cliente(CliID, CliTipo, CliMatricula, CliInsDataHora, CliInsData, CliInsHora, CliDelDataHora, CliDelData, CliDelHora, CliDelUsuId, CliDelUsuNome, CliNomeFamiliar, CliInsUserID, CliInsUserNome, CliiUpdData, CliUpdHora, CliUpdDataHora, CliUpdUserID, CliUpdUserNome, CliVersao, CliAtivo, CliDel) VALUES(:CliID, :CliTipo, :CliMatricula, :CliInsDataHora, :CliInsData, :CliInsHora, :CliDelDataHora, :CliDelData, :CliDelHora, :CliDelUsuId, :CliDelUsuNome, :CliNomeFamiliar, :CliInsUserID, :CliInsUserNome, :CliiUpdData, :CliUpdHora, :CliUpdDataHora, :CliUpdUserID, :CliUpdUserNome, :CliVersao, :CliAtivo, :CliDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000O9)
           ,new CursorDef("T000O10", "SAVEPOINT gxupdate;UPDATE tb_cliente SET CliTipo=:CliTipo, CliMatricula=:CliMatricula, CliInsDataHora=:CliInsDataHora, CliInsData=:CliInsData, CliInsHora=:CliInsHora, CliDelDataHora=:CliDelDataHora, CliDelData=:CliDelData, CliDelHora=:CliDelHora, CliDelUsuId=:CliDelUsuId, CliDelUsuNome=:CliDelUsuNome, CliNomeFamiliar=:CliNomeFamiliar, CliInsUserID=:CliInsUserID, CliInsUserNome=:CliInsUserNome, CliiUpdData=:CliiUpdData, CliUpdHora=:CliUpdHora, CliUpdDataHora=:CliUpdDataHora, CliUpdUserID=:CliUpdUserID, CliUpdUserNome=:CliUpdUserNome, CliVersao=:CliVersao, CliAtivo=:CliAtivo, CliDel=:CliDel  WHERE CliID = :CliID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O10)
           ,new CursorDef("T000O11", "SAVEPOINT gxupdate;DELETE FROM tb_cliente  WHERE CliID = :CliID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000O11)
           ,new CursorDef("T000O12", "SELECT NegID FROM tb_negociopj WHERE NegCliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O13", "SELECT CliID, CpjID FROM tb_clientepj WHERE CliID = :CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000O14", "SELECT CliID FROM tb_cliente ORDER BY CliID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O14,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000O15", "SELECT CliMatricula FROM tb_cliente WHERE (CliMatricula = :CliMatricula) AND (Not ( CliID = :CliID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000O15,1, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
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
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getString(18, 40);
              ((bool[]) buf[28])[0] = rslt.wasNull(18);
              ((string[]) buf[29])[0] = rslt.getVarchar(19);
              ((bool[]) buf[30])[0] = rslt.wasNull(19);
              ((short[]) buf[31])[0] = rslt.getShort(20);
              ((bool[]) buf[32])[0] = rslt.getBool(21);
              ((bool[]) buf[33])[0] = rslt.getBool(22);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
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
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getString(18, 40);
              ((bool[]) buf[28])[0] = rslt.wasNull(18);
              ((string[]) buf[29])[0] = rslt.getVarchar(19);
              ((bool[]) buf[30])[0] = rslt.wasNull(19);
              ((short[]) buf[31])[0] = rslt.getShort(20);
              ((bool[]) buf[32])[0] = rslt.getBool(21);
              ((bool[]) buf[33])[0] = rslt.getBool(22);
              return;
           case 2 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((long[]) buf[2])[0] = rslt.getLong(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
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
              ((string[]) buf[16])[0] = rslt.getVarchar(12);
              ((string[]) buf[17])[0] = rslt.getString(13, 40);
              ((bool[]) buf[18])[0] = rslt.wasNull(13);
              ((string[]) buf[19])[0] = rslt.getVarchar(14);
              ((bool[]) buf[20])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[21])[0] = rslt.getGXDate(15);
              ((bool[]) buf[22])[0] = rslt.wasNull(15);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(16);
              ((bool[]) buf[24])[0] = rslt.wasNull(16);
              ((DateTime[]) buf[25])[0] = rslt.getGXDateTime(17, true);
              ((bool[]) buf[26])[0] = rslt.wasNull(17);
              ((string[]) buf[27])[0] = rslt.getString(18, 40);
              ((bool[]) buf[28])[0] = rslt.wasNull(18);
              ((string[]) buf[29])[0] = rslt.getVarchar(19);
              ((bool[]) buf[30])[0] = rslt.wasNull(19);
              ((short[]) buf[31])[0] = rslt.getShort(20);
              ((bool[]) buf[32])[0] = rslt.getBool(21);
              ((bool[]) buf[33])[0] = rslt.getBool(22);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 11 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((Guid[]) buf[1])[0] = rslt.getGuid(2);
              return;
           case 12 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
