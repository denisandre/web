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
   public class documento : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_45") == 0 )
         {
            A146DocTipoID = (int)(Math.Round(NumberUtil.Val( GetPar( "DocTipoID"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_45( A146DocTipoID) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_46") == 0 )
         {
            A326DocVersaoIDPai = StringUtil.StrToGuid( GetPar( "DocVersaoIDPai"));
            n326DocVersaoIDPai = false;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_46( A326DocVersaoIDPai) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documento.aspx")), "core.documento.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documento.aspx")))) ;
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
                  AV7DocID = StringUtil.StrToGuid( GetPar( "DocID"));
                  AssignAttri("", false, "AV7DocID", AV7DocID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV7DocID, context));
                  AV29DocOrigem = GetPar( "DocOrigem");
                  AssignAttri("", false, "AV29DocOrigem", AV29DocOrigem);
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29DocOrigem, "")), context));
                  AV30DocOrigemID = GetPar( "DocOrigemID");
                  AssignAttri("", false, "AV30DocOrigemID", AV30DocOrigemID);
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30DocOrigemID, "")), context));
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
            Form.Meta.addItem("description", "Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documento( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documento( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_DocID ,
                           string aP2_DocOrigem ,
                           string aP3_DocOrigemID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocID = aP1_DocID;
         this.AV29DocOrigem = aP2_DocOrigem;
         this.AV30DocOrigemID = aP3_DocOrigemID;
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkDocContrato = new GXCheckbox();
         chkDocAssinado = new GXCheckbox();
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
            return "documento_Execute" ;
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
         A480DocContrato = StringUtil.StrToBool( StringUtil.BoolToStr( A480DocContrato));
         AssignAttri("", false, "A480DocContrato", A480DocContrato);
         A481DocAssinado = StringUtil.StrToBool( StringUtil.BoolToStr( A481DocAssinado));
         AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocNome_Internalname, "Descrição do Documento", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocNome_Internalname, A305DocNome, StringUtil.RTrim( context.localUtil.Format( A305DocNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocNome_Enabled, 1, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Documento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL RequiredDataContentCellFL ExtendedComboCell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTablesplitteddoctipoid_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-3 MergeLabelCell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTextblockdoctipoid_Internalname, "Tipo", "", "", lblTextblockdoctipoid_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "Label", 0, "", 1, 1, 0, 0, "HLP_core\\Documento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-9", "start", "top", "", "", "div");
         /* User Defined Control */
         ucCombo_doctipoid.SetProperty("Caption", Combo_doctipoid_Caption);
         ucCombo_doctipoid.SetProperty("Cls", Combo_doctipoid_Cls);
         ucCombo_doctipoid.SetProperty("EmptyItemText", Combo_doctipoid_Emptyitemtext);
         ucCombo_doctipoid.SetProperty("DropDownOptionsData", AV16DocTipoID_Data);
         ucCombo_doctipoid.Render(context, "dvelop.gxbootstrap.ddoextendedcombo", Combo_doctipoid_Internalname, "COMBO_DOCTIPOIDContainer");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 Invisible", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", " gx-attribute", "start", "top", "", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocTipoID_Internalname, "Tipo do Documento", "col-sm-3 AttributeLabel", 0, true, "");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocTipoID_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 11, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A146DocTipoID), "ZZZ,ZZZ,ZZ9")), TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,32);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocTipoID_Jsonclick, 0, "Attribute", "", "", "", "", edtDocTipoID_Visible, edtDocTipoID_Enabled, 1, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "core\\ID_Autonum", "end", false, "", "HLP_core\\Documento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkDocContrato_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkDocContrato_Internalname, "É um contrato", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 37,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocContrato_Internalname, StringUtil.BoolToStr( A480DocContrato), "", "É um contrato", 1, chkDocContrato.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(37, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,37);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 col-sm-6 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkDocAssinado_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkDocAssinado_Internalname, "Assinado", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 41,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkDocAssinado_Internalname, StringUtil.BoolToStr( A481DocAssinado), "", "Assinado", 1, chkDocAssinado.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(41, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,41);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* User Defined Control */
         ucUcfileupload.SetProperty("AutoUpload", Ucfileupload_Autoupload);
         ucUcfileupload.SetProperty("HideAdditionalButtons", Ucfileupload_Hideadditionalbuttons);
         ucUcfileupload.SetProperty("TooltipText", Ucfileupload_Tooltiptext);
         ucUcfileupload.SetProperty("UploadedFiles", AV24UploadedFiles);
         ucUcfileupload.SetProperty("FailedFiles", AV25FailedFiles);
         ucUcfileupload.Render(context, "fileupload", Ucfileupload_Internalname, "UCFILEUPLOADContainer");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Documento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 51,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Documento.htm");
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
         GxWebStd.gx_div_start( context, divSectionattribute_doctipoid_Internalname, 1, 0, "px", 0, "px", "Section", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavCombodoctipoid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV21ComboDocTipoID), 11, 0, ",", "")), StringUtil.LTrim( ((edtavCombodoctipoid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV21ComboDocTipoID), "ZZZ,ZZZ,ZZ9") : context.localUtil.Format( (decimal)(AV21ComboDocTipoID), "ZZZ,ZZZ,ZZ9"))), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCombodoctipoid_Jsonclick, 0, "Attribute", "", "", "", "", edtavCombodoctipoid_Visible, edtavCombodoctipoid_Enabled, 0, "text", "", 11, "chr", 1, "row", 11, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Documento.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavDocorigem_Internalname, AV29DocOrigem, StringUtil.RTrim( context.localUtil.Format( AV29DocOrigem, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigem_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigem_Visible, edtavDocorigem_Enabled, 0, "text", "", 30, "chr", 1, "row", 30, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Documento.htm");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtavDocorigemid_Internalname, AV30DocOrigemID, StringUtil.RTrim( context.localUtil.Format( AV30DocOrigemID, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDocorigemid_Jsonclick, 0, "Attribute", "", "", "", "", edtavDocorigemid_Visible, edtavDocorigemid_Enabled, 0, "text", "", 50, "chr", 1, "row", 50, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\Documento.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocVersao_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ",", "")), StringUtil.LTrim( ((edtDocVersao_Enabled!=0) ? context.localUtil.Format( (decimal)(A325DocVersao), "ZZZ9") : context.localUtil.Format( (decimal)(A325DocVersao), "ZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocVersao_Jsonclick, 0, "Attribute", "", "", "", "", edtDocVersao_Visible, edtDocVersao_Enabled, 0, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "core\\Versao", "end", false, "", "HLP_core\\Documento.htm");
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
         E110U2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               ajax_req_read_hidden_sdt(cgiGet( "vDOCTIPOID_DATA"), AV16DocTipoID_Data);
               ajax_req_read_hidden_sdt(cgiGet( "vUPLOADEDFILES"), AV24UploadedFiles);
               ajax_req_read_hidden_sdt(cgiGet( "vFAILEDFILES"), AV25FailedFiles);
               /* Read saved values. */
               Z289DocID = StringUtil.StrToGuid( cgiGet( "Z289DocID"));
               Z305DocNome = cgiGet( "Z305DocNome");
               Z325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z325DocVersao"), ",", "."), 18, MidpointRounding.ToEven));
               Z294DocInsDataHora = context.localUtil.CToT( cgiGet( "Z294DocInsDataHora"), 0);
               Z292DocInsData = context.localUtil.CToD( cgiGet( "Z292DocInsData"), 0);
               Z293DocInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z293DocInsHora"), 0));
               Z295DocInsUsuID = cgiGet( "Z295DocInsUsuID");
               n295DocInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A295DocInsUsuID)) ? true : false);
               Z298DocUpdDataHora = context.localUtil.CToT( cgiGet( "Z298DocUpdDataHora"), 0);
               n298DocUpdDataHora = ((DateTime.MinValue==A298DocUpdDataHora) ? true : false);
               Z296DocUpdData = context.localUtil.CToD( cgiGet( "Z296DocUpdData"), 0);
               n296DocUpdData = ((DateTime.MinValue==A296DocUpdData) ? true : false);
               Z297DocUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z297DocUpdHora"), 0));
               n297DocUpdHora = ((DateTime.MinValue==A297DocUpdHora) ? true : false);
               Z299DocUpdUsuID = cgiGet( "Z299DocUpdUsuID");
               n299DocUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A299DocUpdUsuID)) ? true : false);
               Z303DocDelDataHora = context.localUtil.CToT( cgiGet( "Z303DocDelDataHora"), 0);
               n303DocDelDataHora = ((DateTime.MinValue==A303DocDelDataHora) ? true : false);
               Z301DocDelData = context.localUtil.CToT( cgiGet( "Z301DocDelData"), 0);
               n301DocDelData = ((DateTime.MinValue==A301DocDelData) ? true : false);
               Z302DocDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z302DocDelHora"), 0));
               n302DocDelHora = ((DateTime.MinValue==A302DocDelHora) ? true : false);
               Z304DocDelUsuID = cgiGet( "Z304DocDelUsuID");
               n304DocDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A304DocDelUsuID)) ? true : false);
               Z510DocDelUsuNome = cgiGet( "Z510DocDelUsuNome");
               n510DocDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A510DocDelUsuNome)) ? true : false);
               Z290DocOrigem = cgiGet( "Z290DocOrigem");
               Z291DocOrigemID = cgiGet( "Z291DocOrigemID");
               Z300DocDel = StringUtil.StrToBool( cgiGet( "Z300DocDel"));
               Z306DocUltArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z306DocUltArqSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n306DocUltArqSeq = ((0==A306DocUltArqSeq) ? true : false);
               Z480DocContrato = StringUtil.StrToBool( cgiGet( "Z480DocContrato"));
               Z481DocAssinado = StringUtil.StrToBool( cgiGet( "Z481DocAssinado"));
               Z640DocAtivo = StringUtil.StrToBool( cgiGet( "Z640DocAtivo"));
               n640DocAtivo = ((false==A640DocAtivo) ? true : false);
               Z146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z146DocTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               Z326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "Z326DocVersaoIDPai"));
               n326DocVersaoIDPai = ((Guid.Empty==A326DocVersaoIDPai) ? true : false);
               A294DocInsDataHora = context.localUtil.CToT( cgiGet( "Z294DocInsDataHora"), 0);
               A292DocInsData = context.localUtil.CToD( cgiGet( "Z292DocInsData"), 0);
               A293DocInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z293DocInsHora"), 0));
               A295DocInsUsuID = cgiGet( "Z295DocInsUsuID");
               n295DocInsUsuID = false;
               n295DocInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A295DocInsUsuID)) ? true : false);
               A298DocUpdDataHora = context.localUtil.CToT( cgiGet( "Z298DocUpdDataHora"), 0);
               n298DocUpdDataHora = false;
               n298DocUpdDataHora = ((DateTime.MinValue==A298DocUpdDataHora) ? true : false);
               A296DocUpdData = context.localUtil.CToD( cgiGet( "Z296DocUpdData"), 0);
               n296DocUpdData = false;
               n296DocUpdData = ((DateTime.MinValue==A296DocUpdData) ? true : false);
               A297DocUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z297DocUpdHora"), 0));
               n297DocUpdHora = false;
               n297DocUpdHora = ((DateTime.MinValue==A297DocUpdHora) ? true : false);
               A299DocUpdUsuID = cgiGet( "Z299DocUpdUsuID");
               n299DocUpdUsuID = false;
               n299DocUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A299DocUpdUsuID)) ? true : false);
               A303DocDelDataHora = context.localUtil.CToT( cgiGet( "Z303DocDelDataHora"), 0);
               n303DocDelDataHora = false;
               n303DocDelDataHora = ((DateTime.MinValue==A303DocDelDataHora) ? true : false);
               A301DocDelData = context.localUtil.CToT( cgiGet( "Z301DocDelData"), 0);
               n301DocDelData = false;
               n301DocDelData = ((DateTime.MinValue==A301DocDelData) ? true : false);
               A302DocDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z302DocDelHora"), 0));
               n302DocDelHora = false;
               n302DocDelHora = ((DateTime.MinValue==A302DocDelHora) ? true : false);
               A304DocDelUsuID = cgiGet( "Z304DocDelUsuID");
               n304DocDelUsuID = false;
               n304DocDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A304DocDelUsuID)) ? true : false);
               A510DocDelUsuNome = cgiGet( "Z510DocDelUsuNome");
               n510DocDelUsuNome = false;
               n510DocDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A510DocDelUsuNome)) ? true : false);
               A290DocOrigem = cgiGet( "Z290DocOrigem");
               A291DocOrigemID = cgiGet( "Z291DocOrigemID");
               A300DocDel = StringUtil.StrToBool( cgiGet( "Z300DocDel"));
               A306DocUltArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z306DocUltArqSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n306DocUltArqSeq = false;
               n306DocUltArqSeq = ((0==A306DocUltArqSeq) ? true : false);
               A640DocAtivo = StringUtil.StrToBool( cgiGet( "Z640DocAtivo"));
               n640DocAtivo = false;
               n640DocAtivo = ((false==A640DocAtivo) ? true : false);
               A326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "Z326DocVersaoIDPai"));
               n326DocVersaoIDPai = false;
               n326DocVersaoIDPai = ((Guid.Empty==A326DocVersaoIDPai) ? true : false);
               O300DocDel = StringUtil.StrToBool( cgiGet( "O300DocDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               N326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "N326DocVersaoIDPai"));
               n326DocVersaoIDPai = ((Guid.Empty==A326DocVersaoIDPai) ? true : false);
               N146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "N146DocTipoID"), ",", "."), 18, MidpointRounding.ToEven));
               AV7DocID = StringUtil.StrToGuid( cgiGet( "vDOCID"));
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A289DocID = StringUtil.StrToGuid( cgiGet( "DOCID"));
               AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "vINSERT_DOCVERSAOIDPAI"));
               A326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "DOCVERSAOIDPAI"));
               n326DocVersaoIDPai = ((Guid.Empty==A326DocVersaoIDPai) ? true : false);
               AV14Insert_DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( "vINSERT_DOCTIPOID"), ",", "."), 18, MidpointRounding.ToEven));
               A294DocInsDataHora = context.localUtil.CToT( cgiGet( "DOCINSDATAHORA"), 0);
               A292DocInsData = context.localUtil.CToD( cgiGet( "DOCINSDATA"), 0);
               A293DocInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCINSHORA"), 0));
               A295DocInsUsuID = cgiGet( "DOCINSUSUID");
               n295DocInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A295DocInsUsuID)) ? true : false);
               A298DocUpdDataHora = context.localUtil.CToT( cgiGet( "DOCUPDDATAHORA"), 0);
               n298DocUpdDataHora = ((DateTime.MinValue==A298DocUpdDataHora) ? true : false);
               A296DocUpdData = context.localUtil.CToD( cgiGet( "DOCUPDDATA"), 0);
               n296DocUpdData = ((DateTime.MinValue==A296DocUpdData) ? true : false);
               A297DocUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCUPDHORA"), 0));
               n297DocUpdHora = ((DateTime.MinValue==A297DocUpdHora) ? true : false);
               A299DocUpdUsuID = cgiGet( "DOCUPDUSUID");
               n299DocUpdUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A299DocUpdUsuID)) ? true : false);
               A300DocDel = StringUtil.StrToBool( cgiGet( "DOCDEL"));
               A303DocDelDataHora = context.localUtil.CToT( cgiGet( "DOCDELDATAHORA"), 0);
               n303DocDelDataHora = ((DateTime.MinValue==A303DocDelDataHora) ? true : false);
               A301DocDelData = context.localUtil.CToT( cgiGet( "DOCDELDATA"), 0);
               n301DocDelData = ((DateTime.MinValue==A301DocDelData) ? true : false);
               A302DocDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCDELHORA"), 0));
               n302DocDelHora = ((DateTime.MinValue==A302DocDelHora) ? true : false);
               A304DocDelUsuID = cgiGet( "DOCDELUSUID");
               n304DocDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A304DocDelUsuID)) ? true : false);
               A510DocDelUsuNome = cgiGet( "DOCDELUSUNOME");
               n510DocDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A510DocDelUsuNome)) ? true : false);
               A290DocOrigem = cgiGet( "DOCORIGEM");
               A291DocOrigemID = cgiGet( "DOCORIGEMID");
               A640DocAtivo = StringUtil.StrToBool( cgiGet( "DOCATIVO"));
               n640DocAtivo = ((false==A640DocAtivo) ? true : false);
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV31AuditingObject);
               ajax_req_read_hidden_sdt(cgiGet( "vSDTRETORNO"), AV33sdtRetorno);
               A306DocUltArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "DOCULTARQSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               n306DocUltArqSeq = ((0==A306DocUltArqSeq) ? true : false);
               A147DocTipoSigla = cgiGet( "DOCTIPOSIGLA");
               A148DocTipoNome = cgiGet( "DOCTIPONOME");
               A219DocTipoAtivo = StringUtil.StrToBool( cgiGet( "DOCTIPOATIVO"));
               A327DocVersaoNomePai = cgiGet( "DOCVERSAONOMEPAI");
               AV36Pgmname = cgiGet( "vPGMNAME");
               Combo_doctipoid_Objectcall = cgiGet( "COMBO_DOCTIPOID_Objectcall");
               Combo_doctipoid_Class = cgiGet( "COMBO_DOCTIPOID_Class");
               Combo_doctipoid_Icontype = cgiGet( "COMBO_DOCTIPOID_Icontype");
               Combo_doctipoid_Icon = cgiGet( "COMBO_DOCTIPOID_Icon");
               Combo_doctipoid_Caption = cgiGet( "COMBO_DOCTIPOID_Caption");
               Combo_doctipoid_Tooltip = cgiGet( "COMBO_DOCTIPOID_Tooltip");
               Combo_doctipoid_Cls = cgiGet( "COMBO_DOCTIPOID_Cls");
               Combo_doctipoid_Selectedvalue_set = cgiGet( "COMBO_DOCTIPOID_Selectedvalue_set");
               Combo_doctipoid_Selectedvalue_get = cgiGet( "COMBO_DOCTIPOID_Selectedvalue_get");
               Combo_doctipoid_Selectedtext_set = cgiGet( "COMBO_DOCTIPOID_Selectedtext_set");
               Combo_doctipoid_Selectedtext_get = cgiGet( "COMBO_DOCTIPOID_Selectedtext_get");
               Combo_doctipoid_Gamoauthtoken = cgiGet( "COMBO_DOCTIPOID_Gamoauthtoken");
               Combo_doctipoid_Ddointernalname = cgiGet( "COMBO_DOCTIPOID_Ddointernalname");
               Combo_doctipoid_Titlecontrolalign = cgiGet( "COMBO_DOCTIPOID_Titlecontrolalign");
               Combo_doctipoid_Dropdownoptionstype = cgiGet( "COMBO_DOCTIPOID_Dropdownoptionstype");
               Combo_doctipoid_Enabled = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Enabled"));
               Combo_doctipoid_Visible = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Visible"));
               Combo_doctipoid_Titlecontrolidtoreplace = cgiGet( "COMBO_DOCTIPOID_Titlecontrolidtoreplace");
               Combo_doctipoid_Datalisttype = cgiGet( "COMBO_DOCTIPOID_Datalisttype");
               Combo_doctipoid_Allowmultipleselection = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Allowmultipleselection"));
               Combo_doctipoid_Datalistfixedvalues = cgiGet( "COMBO_DOCTIPOID_Datalistfixedvalues");
               Combo_doctipoid_Isgriditem = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Isgriditem"));
               Combo_doctipoid_Hasdescription = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Hasdescription"));
               Combo_doctipoid_Datalistproc = cgiGet( "COMBO_DOCTIPOID_Datalistproc");
               Combo_doctipoid_Datalistprocparametersprefix = cgiGet( "COMBO_DOCTIPOID_Datalistprocparametersprefix");
               Combo_doctipoid_Remoteservicesparameters = cgiGet( "COMBO_DOCTIPOID_Remoteservicesparameters");
               Combo_doctipoid_Datalistupdateminimumcharacters = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_DOCTIPOID_Datalistupdateminimumcharacters"), ",", "."), 18, MidpointRounding.ToEven));
               Combo_doctipoid_Includeonlyselectedoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Includeonlyselectedoption"));
               Combo_doctipoid_Includeselectalloption = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Includeselectalloption"));
               Combo_doctipoid_Emptyitem = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Emptyitem"));
               Combo_doctipoid_Includeaddnewoption = StringUtil.StrToBool( cgiGet( "COMBO_DOCTIPOID_Includeaddnewoption"));
               Combo_doctipoid_Htmltemplate = cgiGet( "COMBO_DOCTIPOID_Htmltemplate");
               Combo_doctipoid_Multiplevaluestype = cgiGet( "COMBO_DOCTIPOID_Multiplevaluestype");
               Combo_doctipoid_Loadingdata = cgiGet( "COMBO_DOCTIPOID_Loadingdata");
               Combo_doctipoid_Noresultsfound = cgiGet( "COMBO_DOCTIPOID_Noresultsfound");
               Combo_doctipoid_Emptyitemtext = cgiGet( "COMBO_DOCTIPOID_Emptyitemtext");
               Combo_doctipoid_Onlyselectedvalues = cgiGet( "COMBO_DOCTIPOID_Onlyselectedvalues");
               Combo_doctipoid_Selectalltext = cgiGet( "COMBO_DOCTIPOID_Selectalltext");
               Combo_doctipoid_Multiplevaluesseparator = cgiGet( "COMBO_DOCTIPOID_Multiplevaluesseparator");
               Combo_doctipoid_Addnewoptiontext = cgiGet( "COMBO_DOCTIPOID_Addnewoptiontext");
               Combo_doctipoid_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "COMBO_DOCTIPOID_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
               Ucfileupload_Objectcall = cgiGet( "UCFILEUPLOAD_Objectcall");
               Ucfileupload_Enabled = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Enabled"));
               Ucfileupload_Class = cgiGet( "UCFILEUPLOAD_Class");
               Ucfileupload_Autoupload = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Autoupload"));
               Ucfileupload_Hideadditionalbuttons = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Hideadditionalbuttons"));
               Ucfileupload_Tooltiptext = cgiGet( "UCFILEUPLOAD_Tooltiptext");
               Ucfileupload_Enableuploadedfilecanceling = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Enableuploadedfilecanceling"));
               Ucfileupload_Disableimageresize = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Disableimageresize"));
               Ucfileupload_Maxfilesize = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCFILEUPLOAD_Maxfilesize"), ",", "."), 18, MidpointRounding.ToEven));
               Ucfileupload_Maxnumberoffiles = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCFILEUPLOAD_Maxnumberoffiles"), ",", "."), 18, MidpointRounding.ToEven));
               Ucfileupload_Autodisableaddingfiles = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Autodisableaddingfiles"));
               Ucfileupload_Acceptedfiletypes = cgiGet( "UCFILEUPLOAD_Acceptedfiletypes");
               Ucfileupload_Customfiletypes = cgiGet( "UCFILEUPLOAD_Customfiletypes");
               Ucfileupload_Visible = StringUtil.StrToBool( cgiGet( "UCFILEUPLOAD_Visible"));
               Ucfileupload_Gxcontroltype = (int)(Math.Round(context.localUtil.CToN( cgiGet( "UCFILEUPLOAD_Gxcontroltype"), ",", "."), 18, MidpointRounding.ToEven));
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
               A305DocNome = StringUtil.Upper( cgiGet( edtDocNome_Internalname));
               AssignAttri("", false, "A305DocNome", A305DocNome);
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", ".") > Convert.ToDecimal( 999999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCTIPOID");
                  AnyError = 1;
                  GX_FocusControl = edtDocTipoID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A146DocTipoID = 0;
                  AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               }
               else
               {
                  A146DocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtDocTipoID_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
               }
               A480DocContrato = StringUtil.StrToBool( cgiGet( chkDocContrato_Internalname));
               AssignAttri("", false, "A480DocContrato", A480DocContrato);
               A481DocAssinado = StringUtil.StrToBool( cgiGet( chkDocAssinado_Internalname));
               AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
               AV21ComboDocTipoID = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtavCombodoctipoid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV21ComboDocTipoID", StringUtil.LTrimStr( (decimal)(AV21ComboDocTipoID), 9, 0));
               AV29DocOrigem = cgiGet( edtavDocorigem_Internalname);
               AssignAttri("", false, "AV29DocOrigem", AV29DocOrigem);
               GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29DocOrigem, "")), context));
               AV30DocOrigemID = cgiGet( edtavDocorigemid_Internalname);
               AssignAttri("", false, "AV30DocOrigemID", AV30DocOrigemID);
               GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30DocOrigemID, "")), context));
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocVersao_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocVersao_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCVERSAO");
                  AnyError = 1;
                  GX_FocusControl = edtDocVersao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A325DocVersao = 0;
                  AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
               }
               else
               {
                  A325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocVersao_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Documento");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("DocOrigem", StringUtil.RTrim( context.localUtil.Format( A290DocOrigem, "")));
               forbiddenHiddens.Add("DocOrigemID", StringUtil.RTrim( context.localUtil.Format( A291DocOrigemID, "")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV36Pgmname, "")));
               forbiddenHiddens.Add("DocDel", StringUtil.BoolToStr( A300DocDel));
               forbiddenHiddens.Add("DocUltArqSeq", context.localUtil.Format( (decimal)(A306DocUltArqSeq), "ZZZ9"));
               forbiddenHiddens.Add("DocAtivo", StringUtil.BoolToStr( A640DocAtivo));
               hsh = cgiGet( "hsh");
               if ( ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\documento:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A289DocID = StringUtil.StrToGuid( GetPar( "DocID"));
                  AssignAttri("", false, "A289DocID", A289DocID.ToString());
                  getEqualNoModal( ) ;
                  if ( ! (Guid.Empty==AV7DocID) )
                  {
                     A289DocID = AV7DocID;
                     AssignAttri("", false, "A289DocID", A289DocID.ToString());
                  }
                  else
                  {
                     if ( IsIns( )  && (Guid.Empty==A289DocID) && ( Gx_BScreen == 0 ) )
                     {
                        A289DocID = Guid.NewGuid( );
                        AssignAttri("", false, "A289DocID", A289DocID.ToString());
                     }
                  }
                  /* N/A Action t   33 */
                  /* Using cursor T000U5 */
                  pr_default.execute(3, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
                  pr_default.close(3);
                  Gx_mode = "DSP";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  disable_std_buttons( ) ;
                  standaloneModal( ) ;
               }
               else
               {
                  if ( IsDsp( ) )
                  {
                     sMode33 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (Guid.Empty==AV7DocID) )
                     {
                        A289DocID = AV7DocID;
                        AssignAttri("", false, "A289DocID", A289DocID.ToString());
                     }
                     else
                     {
                        if ( IsIns( )  && (Guid.Empty==A289DocID) && ( Gx_BScreen == 0 ) )
                        {
                           A289DocID = Guid.NewGuid( );
                           AssignAttri("", false, "A289DocID", A289DocID.ToString());
                        }
                     }
                     /* N/A Action t   33 */
                     /* Using cursor T000U5 */
                     pr_default.execute(3, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
                     pr_default.close(3);
                     Gx_mode = sMode33;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound33 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_0U0( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "");
                        AnyError = 1;
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
                        if ( StringUtil.StrCmp(sEvt, "UCFILEUPLOAD.UPLOADCOMPLETE") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           E120U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: Start */
                           E110U2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E130U2 ();
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
            E130U2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0U33( ) ;
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
            DisableAttributes0U33( ) ;
         }
         AssignProp("", false, edtavCombodoctipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodoctipoid_Enabled), 5, 0), true);
         AssignProp("", false, edtavDocorigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocorigem_Enabled), 5, 0), true);
         AssignProp("", false, edtavDocorigemid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocorigemid_Enabled), 5, 0), true);
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

      protected void CONFIRM_0U0( )
      {
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls0U33( ) ;
            }
            else
            {
               CheckExtendedTable0U33( ) ;
               CloseExtendedTableCursors0U33( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption0U0( )
      {
      }

      protected void E110U2( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         edtDocTipoID_Visible = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Visible), 5, 0), true);
         AV21ComboDocTipoID = 0;
         AssignAttri("", false, "AV21ComboDocTipoID", StringUtil.LTrimStr( (decimal)(AV21ComboDocTipoID), 9, 0));
         edtavCombodoctipoid_Visible = 0;
         AssignProp("", false, edtavCombodoctipoid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCombodoctipoid_Visible), 5, 0), true);
         /* Execute user subroutine: 'LOADCOMBODOCTIPOID' */
         S112 ();
         if ( returnInSub )
         {
            returnInSub = true;
            if (true) return;
         }
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         if ( ( StringUtil.StrCmp(AV11TrnContext.gxTpr_Transactionname, AV36Pgmname) == 0 ) && ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) )
         {
            AV37GXV1 = 1;
            AssignAttri("", false, "AV37GXV1", StringUtil.LTrimStr( (decimal)(AV37GXV1), 8, 0));
            while ( AV37GXV1 <= AV11TrnContext.gxTpr_Attributes.Count )
            {
               AV15TrnContextAtt = ((GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute)AV11TrnContext.gxTpr_Attributes.Item(AV37GXV1));
               if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocVersaoIDPai") == 0 )
               {
                  AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( AV15TrnContextAtt.gxTpr_Attributevalue);
                  AssignAttri("", false, "AV13Insert_DocVersaoIDPai", AV13Insert_DocVersaoIDPai.ToString());
               }
               else if ( StringUtil.StrCmp(AV15TrnContextAtt.gxTpr_Attributename, "DocTipoID") == 0 )
               {
                  AV14Insert_DocTipoID = (int)(Math.Round(NumberUtil.Val( AV15TrnContextAtt.gxTpr_Attributevalue, "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV14Insert_DocTipoID", StringUtil.LTrimStr( (decimal)(AV14Insert_DocTipoID), 9, 0));
                  if ( ! (0==AV14Insert_DocTipoID) )
                  {
                     AV21ComboDocTipoID = AV14Insert_DocTipoID;
                     AssignAttri("", false, "AV21ComboDocTipoID", StringUtil.LTrimStr( (decimal)(AV21ComboDocTipoID), 9, 0));
                     Combo_doctipoid_Selectedvalue_set = StringUtil.Trim( StringUtil.Str( (decimal)(AV21ComboDocTipoID), 9, 0));
                     ucCombo_doctipoid.SendProperty(context, "", false, Combo_doctipoid_Internalname, "SelectedValue_set", Combo_doctipoid_Selectedvalue_set);
                     Combo_doctipoid_Enabled = false;
                     ucCombo_doctipoid.SendProperty(context, "", false, Combo_doctipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_doctipoid_Enabled));
                  }
               }
               AV37GXV1 = (int)(AV37GXV1+1);
               AssignAttri("", false, "AV37GXV1", StringUtil.LTrimStr( (decimal)(AV37GXV1), 8, 0));
            }
         }
         edtavDocorigem_Visible = 0;
         AssignProp("", false, edtavDocorigem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigem_Visible), 5, 0), true);
         edtavDocorigemid_Visible = 0;
         AssignProp("", false, edtavDocorigemid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavDocorigemid_Visible), 5, 0), true);
         edtDocVersao_Visible = 0;
         AssignProp("", false, edtDocVersao_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocVersao_Visible), 5, 0), true);
         if ( ! (Guid.Empty==AV13Insert_DocVersaoIDPai) )
         {
            AV13Insert_DocVersaoIDPai = StringUtil.StrToGuid( new GeneXus.Programs.core.prcdocumentoverificaridversaoprincipal(context).executeUdp(  AV13Insert_DocVersaoIDPai.ToString()));
            AssignAttri("", false, "AV13Insert_DocVersaoIDPai", AV13Insert_DocVersaoIDPai.ToString());
         }
         AV34webSessionParm = "sdtDocumento_" + StringUtil.Trim( AV29DocOrigem) + "_" + StringUtil.Trim( AV30DocOrigemID);
         AssignAttri("", false, "AV34webSessionParm", AV34webSessionParm);
         AV32sdtDocumento.FromJSonString(AV12WebSession.Get(AV34webSessionParm), null);
      }

      protected void E130U2( )
      {
         /* After Trn Routine */
         returnInSub = false;
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "UPD") == 0 ) )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               if ( ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) )
               {
                  AV32sdtDocumento.gxTpr_Docativo = false;
                  new GeneXus.Programs.core.prcdocumentomanterdados(context ).execute(  AV32sdtDocumento,  true, out  AV27Messages) ;
               }
            }
            AV34webSessionParm = "uploadedFiles_" + StringUtil.Trim( AV29DocOrigem) + "_" + StringUtil.Trim( AV30DocOrigemID);
            AssignAttri("", false, "AV34webSessionParm", AV34webSessionParm);
            AV12WebSession.Remove(AV34webSessionParm);
            AV34webSessionParm = "sdtDocumento_" + StringUtil.Trim( AV29DocOrigem) + "_" + StringUtil.Trim( AV30DocOrigemID);
            AssignAttri("", false, "AV34webSessionParm", AV34webSessionParm);
            AV12WebSession.Remove(AV34webSessionParm);
         }
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV31AuditingObject,  AV36Pgmname) ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV32sdtDocumento", AV32sdtDocumento);
      }

      protected void S112( )
      {
         /* 'LOADCOMBODOCTIPOID' Routine */
         returnInSub = false;
         GXt_objcol_SdtDVB_SDTComboData_Item1 = AV16DocTipoID_Data;
         new GeneXus.Programs.core.documentoloaddvcombo(context ).execute(  "DocTipoID",  Gx_mode,  AV7DocID, out  AV18ComboSelectedValue, out  GXt_objcol_SdtDVB_SDTComboData_Item1) ;
         AV16DocTipoID_Data = GXt_objcol_SdtDVB_SDTComboData_Item1;
         Combo_doctipoid_Selectedvalue_set = AV18ComboSelectedValue;
         ucCombo_doctipoid.SendProperty(context, "", false, Combo_doctipoid_Internalname, "SelectedValue_set", Combo_doctipoid_Selectedvalue_set);
         AV21ComboDocTipoID = (int)(Math.Round(NumberUtil.Val( AV18ComboSelectedValue, "."), 18, MidpointRounding.ToEven));
         AssignAttri("", false, "AV21ComboDocTipoID", StringUtil.LTrimStr( (decimal)(AV21ComboDocTipoID), 9, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 ) || ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) )
         {
            Combo_doctipoid_Enabled = false;
            ucCombo_doctipoid.SendProperty(context, "", false, Combo_doctipoid_Internalname, "Enabled", StringUtil.BoolToStr( Combo_doctipoid_Enabled));
         }
      }

      protected void E120U2( )
      {
         /* Ucfileupload_Uploadcomplete Routine */
         returnInSub = false;
         AV34webSessionParm = "uploadedFiles_" + StringUtil.Trim( AV29DocOrigem) + "_" + StringUtil.Trim( AV30DocOrigemID);
         AssignAttri("", false, "AV34webSessionParm", AV34webSessionParm);
         AV12WebSession.Set(AV34webSessionParm, AV24UploadedFiles.ToJSonString(false));
         /*  Sending Event outputs  */
      }

      protected void ZM0U33( short GX_JID )
      {
         if ( ( GX_JID == 43 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z305DocNome = T000U3_A305DocNome[0];
               Z325DocVersao = T000U3_A325DocVersao[0];
               Z294DocInsDataHora = T000U3_A294DocInsDataHora[0];
               Z292DocInsData = T000U3_A292DocInsData[0];
               Z293DocInsHora = T000U3_A293DocInsHora[0];
               Z295DocInsUsuID = T000U3_A295DocInsUsuID[0];
               Z298DocUpdDataHora = T000U3_A298DocUpdDataHora[0];
               Z296DocUpdData = T000U3_A296DocUpdData[0];
               Z297DocUpdHora = T000U3_A297DocUpdHora[0];
               Z299DocUpdUsuID = T000U3_A299DocUpdUsuID[0];
               Z303DocDelDataHora = T000U3_A303DocDelDataHora[0];
               Z301DocDelData = T000U3_A301DocDelData[0];
               Z302DocDelHora = T000U3_A302DocDelHora[0];
               Z304DocDelUsuID = T000U3_A304DocDelUsuID[0];
               Z510DocDelUsuNome = T000U3_A510DocDelUsuNome[0];
               Z290DocOrigem = T000U3_A290DocOrigem[0];
               Z291DocOrigemID = T000U3_A291DocOrigemID[0];
               Z300DocDel = T000U3_A300DocDel[0];
               Z306DocUltArqSeq = T000U3_A306DocUltArqSeq[0];
               Z480DocContrato = T000U3_A480DocContrato[0];
               Z481DocAssinado = T000U3_A481DocAssinado[0];
               Z640DocAtivo = T000U3_A640DocAtivo[0];
               Z146DocTipoID = T000U3_A146DocTipoID[0];
               Z326DocVersaoIDPai = T000U3_A326DocVersaoIDPai[0];
            }
            else
            {
               Z305DocNome = A305DocNome;
               Z325DocVersao = A325DocVersao;
               Z294DocInsDataHora = A294DocInsDataHora;
               Z292DocInsData = A292DocInsData;
               Z293DocInsHora = A293DocInsHora;
               Z295DocInsUsuID = A295DocInsUsuID;
               Z298DocUpdDataHora = A298DocUpdDataHora;
               Z296DocUpdData = A296DocUpdData;
               Z297DocUpdHora = A297DocUpdHora;
               Z299DocUpdUsuID = A299DocUpdUsuID;
               Z303DocDelDataHora = A303DocDelDataHora;
               Z301DocDelData = A301DocDelData;
               Z302DocDelHora = A302DocDelHora;
               Z304DocDelUsuID = A304DocDelUsuID;
               Z510DocDelUsuNome = A510DocDelUsuNome;
               Z290DocOrigem = A290DocOrigem;
               Z291DocOrigemID = A291DocOrigemID;
               Z300DocDel = A300DocDel;
               Z306DocUltArqSeq = A306DocUltArqSeq;
               Z480DocContrato = A480DocContrato;
               Z481DocAssinado = A481DocAssinado;
               Z640DocAtivo = A640DocAtivo;
               Z146DocTipoID = A146DocTipoID;
               Z326DocVersaoIDPai = A326DocVersaoIDPai;
            }
         }
         if ( GX_JID == -43 )
         {
            Z289DocID = A289DocID;
            Z305DocNome = A305DocNome;
            Z325DocVersao = A325DocVersao;
            Z294DocInsDataHora = A294DocInsDataHora;
            Z292DocInsData = A292DocInsData;
            Z293DocInsHora = A293DocInsHora;
            Z295DocInsUsuID = A295DocInsUsuID;
            Z298DocUpdDataHora = A298DocUpdDataHora;
            Z296DocUpdData = A296DocUpdData;
            Z297DocUpdHora = A297DocUpdHora;
            Z299DocUpdUsuID = A299DocUpdUsuID;
            Z303DocDelDataHora = A303DocDelDataHora;
            Z301DocDelData = A301DocDelData;
            Z302DocDelHora = A302DocDelHora;
            Z304DocDelUsuID = A304DocDelUsuID;
            Z510DocDelUsuNome = A510DocDelUsuNome;
            Z290DocOrigem = A290DocOrigem;
            Z291DocOrigemID = A291DocOrigemID;
            Z300DocDel = A300DocDel;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z480DocContrato = A480DocContrato;
            Z481DocAssinado = A481DocAssinado;
            Z640DocAtivo = A640DocAtivo;
            Z146DocTipoID = A146DocTipoID;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
            Z327DocVersaoNomePai = A327DocVersaoNomePai;
            Z147DocTipoSigla = A147DocTipoSigla;
            Z148DocTipoNome = A148DocTipoNome;
            Z219DocTipoAtivo = A219DocTipoAtivo;
         }
      }

      protected void standaloneNotModal( )
      {
         AV36Pgmname = "core.Documento";
         AssignAttri("", false, "AV36Pgmname", AV36Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DocTipoID) )
         {
            edtDocTipoID_Enabled = 0;
            AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
         }
         else
         {
            edtDocTipoID_Enabled = 1;
            AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            edtDocNome_Enabled = 0;
            AssignProp("", false, edtDocNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNome_Enabled), 5, 0), true);
         }
         else
         {
            edtDocNome_Enabled = 1;
            AssignProp("", false, edtDocNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNome_Enabled), 5, 0), true);
         }
      }

      protected void standaloneModal( )
      {
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            A305DocNome = AV32sdtDocumento.gxTpr_Docnome;
            AssignAttri("", false, "A305DocNome", A305DocNome);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            A325DocVersao = (short)(AV32sdtDocumento.gxTpr_Docversao+1);
            AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (Guid.Empty==AV13Insert_DocVersaoIDPai) )
         {
            A326DocVersaoIDPai = AV13Insert_DocVersaoIDPai;
            n326DocVersaoIDPai = false;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! (0==AV14Insert_DocTipoID) )
         {
            A146DocTipoID = AV14Insert_DocTipoID;
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         }
         else
         {
            A146DocTipoID = AV21ComboDocTipoID;
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A291DocOrigemID = AV30DocOrigemID;
            AssignAttri("", false, "A291DocOrigemID", A291DocOrigemID);
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            A290DocOrigem = AV29DocOrigem;
            AssignAttri("", false, "A290DocOrigem", A290DocOrigem);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ! String.IsNullOrEmpty(StringUtil.RTrim( AV32sdtDocumento.gxTpr_Docnome)) && ! (Guid.Empty==AV32sdtDocumento.gxTpr_Docid) )
         {
            edtDocNome_Enabled = 0;
            AssignProp("", false, edtDocNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNome_Enabled), 5, 0), true);
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
         if ( ! (Guid.Empty==AV7DocID) )
         {
            A289DocID = AV7DocID;
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
         }
         else
         {
            if ( IsIns( )  && (Guid.Empty==A289DocID) && ( Gx_BScreen == 0 ) )
            {
               A289DocID = Guid.NewGuid( );
               AssignAttri("", false, "A289DocID", A289DocID.ToString());
            }
         }
         if ( IsIns( )  && (false==A481DocAssinado) && ( Gx_BScreen == 0 ) )
         {
            A481DocAssinado = false;
            AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
         }
         if ( IsIns( )  && (false==A480DocContrato) && ( Gx_BScreen == 0 ) )
         {
            A480DocContrato = false;
            AssignAttri("", false, "A480DocContrato", A480DocContrato);
         }
         if ( IsIns( )  && (false==A640DocAtivo) && ( Gx_BScreen == 0 ) )
         {
            A640DocAtivo = true;
            n640DocAtivo = false;
            AssignAttri("", false, "A640DocAtivo", A640DocAtivo);
         }
         if ( IsIns( )  && (false==A300DocDel) && ( Gx_BScreen == 0 ) )
         {
            A300DocDel = false;
            AssignAttri("", false, "A300DocDel", A300DocDel);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T000U5 */
            pr_default.execute(3, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
            A327DocVersaoNomePai = T000U5_A327DocVersaoNomePai[0];
            pr_default.close(3);
            /* Using cursor T000U4 */
            pr_default.execute(2, new Object[] {A146DocTipoID});
            A147DocTipoSigla = T000U4_A147DocTipoSigla[0];
            A148DocTipoNome = T000U4_A148DocTipoNome[0];
            A219DocTipoAtivo = T000U4_A219DocTipoAtivo[0];
            pr_default.close(2);
         }
      }

      protected void Load0U33( )
      {
         /* Using cursor T000U6 */
         pr_default.execute(4, new Object[] {A289DocID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound33 = 1;
            A305DocNome = T000U6_A305DocNome[0];
            AssignAttri("", false, "A305DocNome", A305DocNome);
            A325DocVersao = T000U6_A325DocVersao[0];
            AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
            A294DocInsDataHora = T000U6_A294DocInsDataHora[0];
            A292DocInsData = T000U6_A292DocInsData[0];
            A293DocInsHora = T000U6_A293DocInsHora[0];
            A295DocInsUsuID = T000U6_A295DocInsUsuID[0];
            n295DocInsUsuID = T000U6_n295DocInsUsuID[0];
            A298DocUpdDataHora = T000U6_A298DocUpdDataHora[0];
            n298DocUpdDataHora = T000U6_n298DocUpdDataHora[0];
            A296DocUpdData = T000U6_A296DocUpdData[0];
            n296DocUpdData = T000U6_n296DocUpdData[0];
            A297DocUpdHora = T000U6_A297DocUpdHora[0];
            n297DocUpdHora = T000U6_n297DocUpdHora[0];
            A299DocUpdUsuID = T000U6_A299DocUpdUsuID[0];
            n299DocUpdUsuID = T000U6_n299DocUpdUsuID[0];
            A303DocDelDataHora = T000U6_A303DocDelDataHora[0];
            n303DocDelDataHora = T000U6_n303DocDelDataHora[0];
            A301DocDelData = T000U6_A301DocDelData[0];
            n301DocDelData = T000U6_n301DocDelData[0];
            A302DocDelHora = T000U6_A302DocDelHora[0];
            n302DocDelHora = T000U6_n302DocDelHora[0];
            A304DocDelUsuID = T000U6_A304DocDelUsuID[0];
            n304DocDelUsuID = T000U6_n304DocDelUsuID[0];
            A510DocDelUsuNome = T000U6_A510DocDelUsuNome[0];
            n510DocDelUsuNome = T000U6_n510DocDelUsuNome[0];
            A290DocOrigem = T000U6_A290DocOrigem[0];
            A291DocOrigemID = T000U6_A291DocOrigemID[0];
            A327DocVersaoNomePai = T000U6_A327DocVersaoNomePai[0];
            A300DocDel = T000U6_A300DocDel[0];
            A147DocTipoSigla = T000U6_A147DocTipoSigla[0];
            A148DocTipoNome = T000U6_A148DocTipoNome[0];
            A219DocTipoAtivo = T000U6_A219DocTipoAtivo[0];
            A306DocUltArqSeq = T000U6_A306DocUltArqSeq[0];
            n306DocUltArqSeq = T000U6_n306DocUltArqSeq[0];
            A480DocContrato = T000U6_A480DocContrato[0];
            AssignAttri("", false, "A480DocContrato", A480DocContrato);
            A481DocAssinado = T000U6_A481DocAssinado[0];
            AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
            A640DocAtivo = T000U6_A640DocAtivo[0];
            n640DocAtivo = T000U6_n640DocAtivo[0];
            A146DocTipoID = T000U6_A146DocTipoID[0];
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
            A326DocVersaoIDPai = T000U6_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = T000U6_n326DocVersaoIDPai[0];
            ZM0U33( -43) ;
         }
         pr_default.close(4);
         OnLoadActions0U33( ) ;
      }

      protected void OnLoadActions0U33( )
      {
      }

      protected void CheckExtendedTable0U33( )
      {
         nIsDirty_33 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A305DocNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Descrição do Documento", "", "", "", "", "", "", "", ""), 1, "DOCNOME");
            AnyError = 1;
            GX_FocusControl = edtDocNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000U4 */
         pr_default.execute(2, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147DocTipoSigla = T000U4_A147DocTipoSigla[0];
         A148DocTipoNome = T000U4_A148DocTipoNome[0];
         A219DocTipoAtivo = T000U4_A219DocTipoAtivo[0];
         pr_default.close(2);
         if ( (0==A146DocTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Documento", "", "", "", "", "", "", "", ""), 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000U5 */
         pr_default.execute(3, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (Guid.Empty==A326DocVersaoIDPai) ) )
            {
               GX_msglist.addItem("Não existe 'Documento -> Documento Pai'.", "ForeignKeyNotFound", 1, "DOCVERSAOIDPAI");
               AnyError = 1;
            }
         }
         A327DocVersaoNomePai = T000U5_A327DocVersaoNomePai[0];
         pr_default.close(3);
         /* Using cursor T000U7 */
         pr_default.execute(5, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai, A325DocVersao, A289DocID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Documento Original"+","+"Versão"}), 1, "DOCVERSAO");
            AnyError = 1;
            GX_FocusControl = edtDocVersao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(5);
      }

      protected void CloseExtendedTableCursors0U33( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_45( int A146DocTipoID )
      {
         /* Using cursor T000U8 */
         pr_default.execute(6, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A147DocTipoSigla = T000U8_A147DocTipoSigla[0];
         A148DocTipoNome = T000U8_A148DocTipoNome[0];
         A219DocTipoAtivo = T000U8_A219DocTipoAtivo[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A147DocTipoSigla)+"\""+","+"\""+GXUtil.EncodeJSConstant( A148DocTipoNome)+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.BoolToStr( A219DocTipoAtivo))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_46( Guid A326DocVersaoIDPai )
      {
         /* Using cursor T000U9 */
         pr_default.execute(7, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
         if ( (pr_default.getStatus(7) == 101) )
         {
            if ( ! ( (Guid.Empty==A326DocVersaoIDPai) ) )
            {
               GX_msglist.addItem("Não existe 'Documento -> Documento Pai'.", "ForeignKeyNotFound", 1, "DOCVERSAOIDPAI");
               AnyError = 1;
            }
         }
         A327DocVersaoNomePai = T000U9_A327DocVersaoNomePai[0];
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A327DocVersaoNomePai)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void GetKey0U33( )
      {
         /* Using cursor T000U10 */
         pr_default.execute(8, new Object[] {A289DocID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            RcdFound33 = 1;
         }
         else
         {
            RcdFound33 = 0;
         }
         pr_default.close(8);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000U3 */
         pr_default.execute(1, new Object[] {A289DocID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0U33( 43) ;
            RcdFound33 = 1;
            A289DocID = T000U3_A289DocID[0];
            A305DocNome = T000U3_A305DocNome[0];
            AssignAttri("", false, "A305DocNome", A305DocNome);
            A325DocVersao = T000U3_A325DocVersao[0];
            AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
            A294DocInsDataHora = T000U3_A294DocInsDataHora[0];
            A292DocInsData = T000U3_A292DocInsData[0];
            A293DocInsHora = T000U3_A293DocInsHora[0];
            A295DocInsUsuID = T000U3_A295DocInsUsuID[0];
            n295DocInsUsuID = T000U3_n295DocInsUsuID[0];
            A298DocUpdDataHora = T000U3_A298DocUpdDataHora[0];
            n298DocUpdDataHora = T000U3_n298DocUpdDataHora[0];
            A296DocUpdData = T000U3_A296DocUpdData[0];
            n296DocUpdData = T000U3_n296DocUpdData[0];
            A297DocUpdHora = T000U3_A297DocUpdHora[0];
            n297DocUpdHora = T000U3_n297DocUpdHora[0];
            A299DocUpdUsuID = T000U3_A299DocUpdUsuID[0];
            n299DocUpdUsuID = T000U3_n299DocUpdUsuID[0];
            A303DocDelDataHora = T000U3_A303DocDelDataHora[0];
            n303DocDelDataHora = T000U3_n303DocDelDataHora[0];
            A301DocDelData = T000U3_A301DocDelData[0];
            n301DocDelData = T000U3_n301DocDelData[0];
            A302DocDelHora = T000U3_A302DocDelHora[0];
            n302DocDelHora = T000U3_n302DocDelHora[0];
            A304DocDelUsuID = T000U3_A304DocDelUsuID[0];
            n304DocDelUsuID = T000U3_n304DocDelUsuID[0];
            A510DocDelUsuNome = T000U3_A510DocDelUsuNome[0];
            n510DocDelUsuNome = T000U3_n510DocDelUsuNome[0];
            A290DocOrigem = T000U3_A290DocOrigem[0];
            A291DocOrigemID = T000U3_A291DocOrigemID[0];
            A300DocDel = T000U3_A300DocDel[0];
            A306DocUltArqSeq = T000U3_A306DocUltArqSeq[0];
            n306DocUltArqSeq = T000U3_n306DocUltArqSeq[0];
            A480DocContrato = T000U3_A480DocContrato[0];
            AssignAttri("", false, "A480DocContrato", A480DocContrato);
            A481DocAssinado = T000U3_A481DocAssinado[0];
            AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
            A640DocAtivo = T000U3_A640DocAtivo[0];
            n640DocAtivo = T000U3_n640DocAtivo[0];
            A146DocTipoID = T000U3_A146DocTipoID[0];
            AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
            A326DocVersaoIDPai = T000U3_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = T000U3_n326DocVersaoIDPai[0];
            O300DocDel = A300DocDel;
            AssignAttri("", false, "A300DocDel", A300DocDel);
            Z289DocID = A289DocID;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load0U33( ) ;
            if ( AnyError == 1 )
            {
               RcdFound33 = 0;
               InitializeNonKey0U33( ) ;
            }
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound33 = 0;
            InitializeNonKey0U33( ) ;
            sMode33 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode33;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0U33( ) ;
         if ( RcdFound33 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound33 = 0;
         /* Using cursor T000U11 */
         pr_default.execute(9, new Object[] {A289DocID});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000U11_A289DocID[0], A289DocID, 0) < 0 ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( GuidUtil.Compare(T000U11_A289DocID[0], A289DocID, 0) > 0 ) ) )
            {
               A289DocID = T000U11_A289DocID[0];
               RcdFound33 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void move_previous( )
      {
         RcdFound33 = 0;
         /* Using cursor T000U12 */
         pr_default.execute(10, new Object[] {A289DocID});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000U12_A289DocID[0], A289DocID, 0) > 0 ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( GuidUtil.Compare(T000U12_A289DocID[0], A289DocID, 0) < 0 ) ) )
            {
               A289DocID = T000U12_A289DocID[0];
               RcdFound33 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0U33( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0U33( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound33 == 1 )
            {
               if ( A289DocID != Z289DocID )
               {
                  A289DocID = Z289DocID;
                  AssignAttri("", false, "A289DocID", A289DocID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "");
                  AnyError = 1;
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update0U33( ) ;
                  GX_FocusControl = edtDocNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A289DocID != Z289DocID )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0U33( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "");
                     AnyError = 1;
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0U33( ) ;
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
         if ( A289DocID != Z289DocID )
         {
            A289DocID = Z289DocID;
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "");
            AnyError = 1;
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency0U33( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000U2 */
            pr_default.execute(0, new Object[] {A289DocID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z305DocNome, T000U2_A305DocNome[0]) != 0 ) || ( Z325DocVersao != T000U2_A325DocVersao[0] ) || ( Z294DocInsDataHora != T000U2_A294DocInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z292DocInsData ) != DateTimeUtil.ResetTime ( T000U2_A292DocInsData[0] ) ) || ( Z293DocInsHora != T000U2_A293DocInsHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z295DocInsUsuID, T000U2_A295DocInsUsuID[0]) != 0 ) || ( Z298DocUpdDataHora != T000U2_A298DocUpdDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z296DocUpdData ) != DateTimeUtil.ResetTime ( T000U2_A296DocUpdData[0] ) ) || ( Z297DocUpdHora != T000U2_A297DocUpdHora[0] ) || ( StringUtil.StrCmp(Z299DocUpdUsuID, T000U2_A299DocUpdUsuID[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z303DocDelDataHora != T000U2_A303DocDelDataHora[0] ) || ( Z301DocDelData != T000U2_A301DocDelData[0] ) || ( Z302DocDelHora != T000U2_A302DocDelHora[0] ) || ( StringUtil.StrCmp(Z304DocDelUsuID, T000U2_A304DocDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z510DocDelUsuNome, T000U2_A510DocDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z290DocOrigem, T000U2_A290DocOrigem[0]) != 0 ) || ( StringUtil.StrCmp(Z291DocOrigemID, T000U2_A291DocOrigemID[0]) != 0 ) || ( Z300DocDel != T000U2_A300DocDel[0] ) || ( Z306DocUltArqSeq != T000U2_A306DocUltArqSeq[0] ) || ( Z480DocContrato != T000U2_A480DocContrato[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z481DocAssinado != T000U2_A481DocAssinado[0] ) || ( Z640DocAtivo != T000U2_A640DocAtivo[0] ) || ( Z146DocTipoID != T000U2_A146DocTipoID[0] ) || ( Z326DocVersaoIDPai != T000U2_A326DocVersaoIDPai[0] ) )
            {
               if ( StringUtil.StrCmp(Z305DocNome, T000U2_A305DocNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocNome");
                  GXUtil.WriteLogRaw("Old: ",Z305DocNome);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A305DocNome[0]);
               }
               if ( Z325DocVersao != T000U2_A325DocVersao[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocVersao");
                  GXUtil.WriteLogRaw("Old: ",Z325DocVersao);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A325DocVersao[0]);
               }
               if ( Z294DocInsDataHora != T000U2_A294DocInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z294DocInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A294DocInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z292DocInsData ) != DateTimeUtil.ResetTime ( T000U2_A292DocInsData[0] ) )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocInsData");
                  GXUtil.WriteLogRaw("Old: ",Z292DocInsData);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A292DocInsData[0]);
               }
               if ( Z293DocInsHora != T000U2_A293DocInsHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z293DocInsHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A293DocInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z295DocInsUsuID, T000U2_A295DocInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z295DocInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A295DocInsUsuID[0]);
               }
               if ( Z298DocUpdDataHora != T000U2_A298DocUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z298DocUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A298DocUpdDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z296DocUpdData ) != DateTimeUtil.ResetTime ( T000U2_A296DocUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z296DocUpdData);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A296DocUpdData[0]);
               }
               if ( Z297DocUpdHora != T000U2_A297DocUpdHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z297DocUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A297DocUpdHora[0]);
               }
               if ( StringUtil.StrCmp(Z299DocUpdUsuID, T000U2_A299DocUpdUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocUpdUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z299DocUpdUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A299DocUpdUsuID[0]);
               }
               if ( Z303DocDelDataHora != T000U2_A303DocDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z303DocDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A303DocDelDataHora[0]);
               }
               if ( Z301DocDelData != T000U2_A301DocDelData[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDelData");
                  GXUtil.WriteLogRaw("Old: ",Z301DocDelData);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A301DocDelData[0]);
               }
               if ( Z302DocDelHora != T000U2_A302DocDelHora[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z302DocDelHora);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A302DocDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z304DocDelUsuID, T000U2_A304DocDelUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDelUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z304DocDelUsuID);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A304DocDelUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z510DocDelUsuNome, T000U2_A510DocDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z510DocDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A510DocDelUsuNome[0]);
               }
               if ( StringUtil.StrCmp(Z290DocOrigem, T000U2_A290DocOrigem[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocOrigem");
                  GXUtil.WriteLogRaw("Old: ",Z290DocOrigem);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A290DocOrigem[0]);
               }
               if ( StringUtil.StrCmp(Z291DocOrigemID, T000U2_A291DocOrigemID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocOrigemID");
                  GXUtil.WriteLogRaw("Old: ",Z291DocOrigemID);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A291DocOrigemID[0]);
               }
               if ( Z300DocDel != T000U2_A300DocDel[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocDel");
                  GXUtil.WriteLogRaw("Old: ",Z300DocDel);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A300DocDel[0]);
               }
               if ( Z306DocUltArqSeq != T000U2_A306DocUltArqSeq[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocUltArqSeq");
                  GXUtil.WriteLogRaw("Old: ",Z306DocUltArqSeq);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A306DocUltArqSeq[0]);
               }
               if ( Z480DocContrato != T000U2_A480DocContrato[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocContrato");
                  GXUtil.WriteLogRaw("Old: ",Z480DocContrato);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A480DocContrato[0]);
               }
               if ( Z481DocAssinado != T000U2_A481DocAssinado[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocAssinado");
                  GXUtil.WriteLogRaw("Old: ",Z481DocAssinado);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A481DocAssinado[0]);
               }
               if ( Z640DocAtivo != T000U2_A640DocAtivo[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z640DocAtivo);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A640DocAtivo[0]);
               }
               if ( Z146DocTipoID != T000U2_A146DocTipoID[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocTipoID");
                  GXUtil.WriteLogRaw("Old: ",Z146DocTipoID);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A146DocTipoID[0]);
               }
               if ( Z326DocVersaoIDPai != T000U2_A326DocVersaoIDPai[0] )
               {
                  GXUtil.WriteLog("core.documento:[seudo value changed for attri]"+"DocVersaoIDPai");
                  GXUtil.WriteLogRaw("Old: ",Z326DocVersaoIDPai);
                  GXUtil.WriteLogRaw("Current: ",T000U2_A326DocVersaoIDPai[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0U33( )
      {
         if ( ! IsAuthorized("documento_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0U33( 0) ;
            CheckOptimisticConcurrency0U33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0U33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U13 */
                     pr_default.execute(11, new Object[] {A289DocID, A305DocNome, A325DocVersao, A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, n298DocUpdDataHora, A298DocUpdDataHora, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n299DocUpdUsuID, A299DocUpdUsuID, n303DocDelDataHora, A303DocDelDataHora, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n304DocDelUsuID, A304DocDelUsuID, n510DocDelUsuNome, A510DocDelUsuNome, A290DocOrigem, A291DocOrigemID, A300DocDel, n306DocUltArqSeq, A306DocUltArqSeq, A480DocContrato, A481DocAssinado, n640DocAtivo, A640DocAtivo, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai});
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(11) == 1) )
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
               Load0U33( ) ;
            }
            EndLevel0U33( ) ;
         }
         CloseExtendedTableCursors0U33( ) ;
      }

      protected void Update0U33( )
      {
         if ( ! IsAuthorized("documento_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U33( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0U33( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0U33( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000U14 */
                     pr_default.execute(12, new Object[] {A305DocNome, A325DocVersao, A294DocInsDataHora, A292DocInsData, A293DocInsHora, n295DocInsUsuID, A295DocInsUsuID, n298DocUpdDataHora, A298DocUpdDataHora, n296DocUpdData, A296DocUpdData, n297DocUpdHora, A297DocUpdHora, n299DocUpdUsuID, A299DocUpdUsuID, n303DocDelDataHora, A303DocDelDataHora, n301DocDelData, A301DocDelData, n302DocDelHora, A302DocDelHora, n304DocDelUsuID, A304DocDelUsuID, n510DocDelUsuNome, A510DocDelUsuNome, A290DocOrigem, A291DocOrigemID, A300DocDel, n306DocUltArqSeq, A306DocUltArqSeq, A480DocContrato, A481DocAssinado, n640DocAtivo, A640DocAtivo, A146DocTipoID, n326DocVersaoIDPai, A326DocVersaoIDPai, A289DocID});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0U33( ) ;
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
            EndLevel0U33( ) ;
         }
         CloseExtendedTableCursors0U33( ) ;
      }

      protected void DeferredUpdate0U33( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("documento_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0U33( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0U33( ) ;
            AfterConfirm0U33( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0U33( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000U15 */
                  pr_default.execute(13, new Object[] {A289DocID});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documento");
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
         sMode33 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0U33( ) ;
         Gx_mode = sMode33;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0U33( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000U16 */
            pr_default.execute(14, new Object[] {A146DocTipoID});
            A147DocTipoSigla = T000U16_A147DocTipoSigla[0];
            A148DocTipoNome = T000U16_A148DocTipoNome[0];
            A219DocTipoAtivo = T000U16_A219DocTipoAtivo[0];
            pr_default.close(14);
            /* Using cursor T000U17 */
            pr_default.execute(15, new Object[] {n326DocVersaoIDPai, A326DocVersaoIDPai});
            A327DocVersaoNomePai = T000U17_A327DocVersaoNomePai[0];
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000U18 */
            pr_default.execute(16, new Object[] {A289DocID});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000U19 */
            pr_default.execute(17, new Object[] {A289DocID});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
         }
      }

      protected void EndLevel0U33( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0U33( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.documento",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0U0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.documento",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0U33( )
      {
         /* Scan By routine */
         /* Using cursor T000U20 */
         pr_default.execute(18);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = T000U20_A289DocID[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0U33( )
      {
         /* Scan next routine */
         pr_default.readNext(18);
         RcdFound33 = 0;
         if ( (pr_default.getStatus(18) != 101) )
         {
            RcdFound33 = 1;
            A289DocID = T000U20_A289DocID[0];
         }
      }

      protected void ScanEnd0U33( )
      {
         pr_default.close(18);
      }

      protected void AfterConfirm0U33( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0U33( )
      {
         /* Before Insert Rules */
         A294DocInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A294DocInsDataHora", context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A295DocInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n295DocInsUsuID = false;
         AssignAttri("", false, "A295DocInsUsuID", A295DocInsUsuID);
         A292DocInsData = DateTimeUtil.ResetTime( A294DocInsDataHora);
         AssignAttri("", false, "A292DocInsData", context.localUtil.Format(A292DocInsData, "99/99/99"));
         A293DocInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A294DocInsDataHora));
         AssignAttri("", false, "A293DocInsHora", context.localUtil.TToC( A293DocInsHora, 0, 5, 0, 3, "/", ":", " "));
         if ( (Guid.Empty==A326DocVersaoIDPai) || T000U3_n326DocVersaoIDPai[0] )
         {
            A325DocVersao = 1;
            AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
         }
         if ( A325DocVersao == 1 )
         {
            A326DocVersaoIDPai = Guid.Empty;
            n326DocVersaoIDPai = false;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
            n326DocVersaoIDPai = true;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         }
      }

      protected void BeforeUpdate0U33( )
      {
         /* Before Update Rules */
         A298DocUpdDataHora = DateTimeUtil.NowMS( context);
         n298DocUpdDataHora = false;
         AssignAttri("", false, "A298DocUpdDataHora", context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A299DocUpdUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n299DocUpdUsuID = false;
         AssignAttri("", false, "A299DocUpdUsuID", A299DocUpdUsuID);
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         if ( A325DocVersao == 1 )
         {
            A326DocVersaoIDPai = Guid.Empty;
            n326DocVersaoIDPai = false;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
            n326DocVersaoIDPai = true;
            AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A303DocDelDataHora = DateTimeUtil.NowMS( context);
            n303DocDelDataHora = false;
            AssignAttri("", false, "A303DocDelDataHora", context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A304DocDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n304DocDelUsuID = false;
            AssignAttri("", false, "A304DocDelUsuID", A304DocDelUsuID);
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A510DocDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n510DocDelUsuNome = false;
            AssignAttri("", false, "A510DocDelUsuNome", A510DocDelUsuNome);
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A301DocDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A303DocDelDataHora) ) ;
            n301DocDelData = false;
            AssignAttri("", false, "A301DocDelData", context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A300DocDel && ( O300DocDel != A300DocDel ) )
         {
            A302DocDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A303DocDelDataHora));
            n302DocDelHora = false;
            AssignAttri("", false, "A302DocDelHora", context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
         A296DocUpdData = DateTimeUtil.ResetTime( A298DocUpdDataHora);
         n296DocUpdData = false;
         AssignAttri("", false, "A296DocUpdData", context.localUtil.Format(A296DocUpdData, "99/99/99"));
         A297DocUpdHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A298DocUpdDataHora));
         n297DocUpdHora = false;
         AssignAttri("", false, "A297DocUpdHora", context.localUtil.TToC( A297DocUpdHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeDelete0U33( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
      }

      protected void BeforeComplete0U33( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  || IsUpd( )  )
         {
            new GeneXus.Programs.core.prcdocumentovalidar(context ).execute(  A289DocID,  AV29DocOrigem,  AV30DocOrigemID,  true, out  AV33sdtRetorno) ;
         }
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
         if ( ! AV33sdtRetorno.gxTpr_Success && ( IsIns( )  || IsUpd( )  ) )
         {
            GX_msglist.addItem(AV33sdtRetorno.gxTpr_Message, 1, "");
            AnyError = 1;
         }
      }

      protected void BeforeValidate0U33( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0U33( )
      {
         edtDocNome_Enabled = 0;
         AssignProp("", false, edtDocNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocNome_Enabled), 5, 0), true);
         edtDocTipoID_Enabled = 0;
         AssignProp("", false, edtDocTipoID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocTipoID_Enabled), 5, 0), true);
         chkDocContrato.Enabled = 0;
         AssignProp("", false, chkDocContrato_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocContrato.Enabled), 5, 0), true);
         chkDocAssinado.Enabled = 0;
         AssignProp("", false, chkDocAssinado_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkDocAssinado.Enabled), 5, 0), true);
         edtavCombodoctipoid_Enabled = 0;
         AssignProp("", false, edtavCombodoctipoid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavCombodoctipoid_Enabled), 5, 0), true);
         edtavDocorigem_Enabled = 0;
         AssignProp("", false, edtavDocorigem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocorigem_Enabled), 5, 0), true);
         edtavDocorigemid_Enabled = 0;
         AssignProp("", false, edtavDocorigemid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDocorigemid_Enabled), 5, 0), true);
         edtDocVersao_Enabled = 0;
         AssignProp("", false, edtDocVersao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocVersao_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0U33( )
      {
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30DocOrigemID, "")), context));
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0U0( )
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
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
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
         GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DocID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV29DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV30DocOrigemID));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEM", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV29DocOrigem, "")), context));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCORIGEMID", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( AV30DocOrigemID, "")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         forbiddenHiddens = new GXProperties();
         forbiddenHiddens.Add("hshsalt", "hsh"+"Documento");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("DocOrigem", StringUtil.RTrim( context.localUtil.Format( A290DocOrigem, "")));
         forbiddenHiddens.Add("DocOrigemID", StringUtil.RTrim( context.localUtil.Format( A291DocOrigemID, "")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV36Pgmname, "")));
         forbiddenHiddens.Add("DocDel", StringUtil.BoolToStr( A300DocDel));
         forbiddenHiddens.Add("DocUltArqSeq", context.localUtil.Format( (decimal)(A306DocUltArqSeq), "ZZZ9"));
         forbiddenHiddens.Add("DocAtivo", StringUtil.BoolToStr( A640DocAtivo));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\documento:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z289DocID", Z289DocID.ToString());
         GxWebStd.gx_hidden_field( context, "Z305DocNome", Z305DocNome);
         GxWebStd.gx_hidden_field( context, "Z325DocVersao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z325DocVersao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z294DocInsDataHora", context.localUtil.TToC( Z294DocInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z292DocInsData", context.localUtil.DToC( Z292DocInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z293DocInsHora", context.localUtil.TToC( Z293DocInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z295DocInsUsuID", StringUtil.RTrim( Z295DocInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z298DocUpdDataHora", context.localUtil.TToC( Z298DocUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z296DocUpdData", context.localUtil.DToC( Z296DocUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z297DocUpdHora", context.localUtil.TToC( Z297DocUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z299DocUpdUsuID", StringUtil.RTrim( Z299DocUpdUsuID));
         GxWebStd.gx_hidden_field( context, "Z303DocDelDataHora", context.localUtil.TToC( Z303DocDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z301DocDelData", context.localUtil.TToC( Z301DocDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z302DocDelHora", context.localUtil.TToC( Z302DocDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z304DocDelUsuID", StringUtil.RTrim( Z304DocDelUsuID));
         GxWebStd.gx_hidden_field( context, "Z510DocDelUsuNome", Z510DocDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z290DocOrigem", Z290DocOrigem);
         GxWebStd.gx_hidden_field( context, "Z291DocOrigemID", Z291DocOrigemID);
         GxWebStd.gx_boolean_hidden_field( context, "Z300DocDel", Z300DocDel);
         GxWebStd.gx_hidden_field( context, "Z306DocUltArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z306DocUltArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_boolean_hidden_field( context, "Z480DocContrato", Z480DocContrato);
         GxWebStd.gx_boolean_hidden_field( context, "Z481DocAssinado", Z481DocAssinado);
         GxWebStd.gx_boolean_hidden_field( context, "Z640DocAtivo", Z640DocAtivo);
         GxWebStd.gx_hidden_field( context, "Z146DocTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z146DocTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z326DocVersaoIDPai", Z326DocVersaoIDPai.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "O300DocDel", O300DocDel);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "N326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         GxWebStd.gx_hidden_field( context, "N146DocTipoID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A146DocTipoID), 9, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vDOCTIPOID_DATA", AV16DocTipoID_Data);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vDOCTIPOID_DATA", AV16DocTipoID_Data);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vUPLOADEDFILES", AV24UploadedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vUPLOADEDFILES", AV24UploadedFiles);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vFAILEDFILES", AV25FailedFiles);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vFAILEDFILES", AV25FailedFiles);
         }
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTDOCUMENTO", AV32sdtDocumento);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTDOCUMENTO", AV32sdtDocumento);
         }
         GxWebStd.gx_hidden_field( context, "gxhash_vSDTDOCUMENTO", GetSecureSignedToken( "", AV32sdtDocumento, context));
         GxWebStd.gx_hidden_field( context, "vDOCID", AV7DocID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV7DocID, context));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCID", A289DocID.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCVERSAOIDPAI", AV13Insert_DocVersaoIDPai.ToString());
         GxWebStd.gx_hidden_field( context, "DOCVERSAOIDPAI", A326DocVersaoIDPai.ToString());
         GxWebStd.gx_hidden_field( context, "vINSERT_DOCTIPOID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV14Insert_DocTipoID), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCINSDATAHORA", context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCINSDATA", context.localUtil.DToC( A292DocInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "DOCINSHORA", context.localUtil.TToC( A293DocInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCINSUSUID", StringUtil.RTrim( A295DocInsUsuID));
         GxWebStd.gx_hidden_field( context, "DOCUPDDATAHORA", context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCUPDDATA", context.localUtil.DToC( A296DocUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "DOCUPDHORA", context.localUtil.TToC( A297DocUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCUPDUSUID", StringUtil.RTrim( A299DocUpdUsuID));
         GxWebStd.gx_boolean_hidden_field( context, "DOCDEL", A300DocDel);
         GxWebStd.gx_hidden_field( context, "DOCDELDATAHORA", context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCDELDATA", context.localUtil.TToC( A301DocDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCDELHORA", context.localUtil.TToC( A302DocDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCDELUSUID", StringUtil.RTrim( A304DocDelUsuID));
         GxWebStd.gx_hidden_field( context, "DOCDELUSUNOME", A510DocDelUsuNome);
         GxWebStd.gx_hidden_field( context, "DOCORIGEM", A290DocOrigem);
         GxWebStd.gx_hidden_field( context, "DOCORIGEMID", A291DocOrigemID);
         GxWebStd.gx_boolean_hidden_field( context, "DOCATIVO", A640DocAtivo);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV31AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV31AuditingObject);
         }
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vSDTRETORNO", AV33sdtRetorno);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vSDTRETORNO", AV33sdtRetorno);
         }
         GxWebStd.gx_hidden_field( context, "DOCULTARQSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A306DocUltArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCTIPOSIGLA", A147DocTipoSigla);
         GxWebStd.gx_hidden_field( context, "DOCTIPONOME", A148DocTipoNome);
         GxWebStd.gx_boolean_hidden_field( context, "DOCTIPOATIVO", A219DocTipoAtivo);
         GxWebStd.gx_hidden_field( context, "DOCVERSAONOMEPAI", A327DocVersaoNomePai);
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV36Pgmname));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCTIPOID_Objectcall", StringUtil.RTrim( Combo_doctipoid_Objectcall));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCTIPOID_Cls", StringUtil.RTrim( Combo_doctipoid_Cls));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCTIPOID_Selectedvalue_set", StringUtil.RTrim( Combo_doctipoid_Selectedvalue_set));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCTIPOID_Enabled", StringUtil.BoolToStr( Combo_doctipoid_Enabled));
         GxWebStd.gx_hidden_field( context, "COMBO_DOCTIPOID_Emptyitemtext", StringUtil.RTrim( Combo_doctipoid_Emptyitemtext));
         GxWebStd.gx_hidden_field( context, "UCFILEUPLOAD_Objectcall", StringUtil.RTrim( Ucfileupload_Objectcall));
         GxWebStd.gx_hidden_field( context, "UCFILEUPLOAD_Enabled", StringUtil.BoolToStr( Ucfileupload_Enabled));
         GxWebStd.gx_hidden_field( context, "UCFILEUPLOAD_Autoupload", StringUtil.BoolToStr( Ucfileupload_Autoupload));
         GxWebStd.gx_hidden_field( context, "UCFILEUPLOAD_Hideadditionalbuttons", StringUtil.BoolToStr( Ucfileupload_Hideadditionalbuttons));
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
         GXEncryptionTmp = "core.documento.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DocID.ToString()) + "," + UrlEncode(StringUtil.RTrim(AV29DocOrigem)) + "," + UrlEncode(StringUtil.RTrim(AV30DocOrigemID));
         return formatLink("core.documento.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Documento" ;
      }

      public override string GetPgmdesc( )
      {
         return "Documento" ;
      }

      protected void InitializeNonKey0U33( )
      {
         A326DocVersaoIDPai = Guid.Empty;
         n326DocVersaoIDPai = false;
         AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         A146DocTipoID = 0;
         AssignAttri("", false, "A146DocTipoID", StringUtil.LTrimStr( (decimal)(A146DocTipoID), 9, 0));
         AV31AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A305DocNome = "";
         AssignAttri("", false, "A305DocNome", A305DocNome);
         A325DocVersao = 0;
         AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A294DocInsDataHora", context.localUtil.TToC( A294DocInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A292DocInsData = DateTime.MinValue;
         AssignAttri("", false, "A292DocInsData", context.localUtil.Format(A292DocInsData, "99/99/99"));
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A293DocInsHora", context.localUtil.TToC( A293DocInsHora, 0, 5, 0, 3, "/", ":", " "));
         A295DocInsUsuID = "";
         n295DocInsUsuID = false;
         AssignAttri("", false, "A295DocInsUsuID", A295DocInsUsuID);
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         n298DocUpdDataHora = false;
         AssignAttri("", false, "A298DocUpdDataHora", context.localUtil.TToC( A298DocUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A296DocUpdData = DateTime.MinValue;
         n296DocUpdData = false;
         AssignAttri("", false, "A296DocUpdData", context.localUtil.Format(A296DocUpdData, "99/99/99"));
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         n297DocUpdHora = false;
         AssignAttri("", false, "A297DocUpdHora", context.localUtil.TToC( A297DocUpdHora, 0, 5, 0, 3, "/", ":", " "));
         A299DocUpdUsuID = "";
         n299DocUpdUsuID = false;
         AssignAttri("", false, "A299DocUpdUsuID", A299DocUpdUsuID);
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         n303DocDelDataHora = false;
         AssignAttri("", false, "A303DocDelDataHora", context.localUtil.TToC( A303DocDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A301DocDelData = (DateTime)(DateTime.MinValue);
         n301DocDelData = false;
         AssignAttri("", false, "A301DocDelData", context.localUtil.TToC( A301DocDelData, 10, 5, 0, 3, "/", ":", " "));
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         n302DocDelHora = false;
         AssignAttri("", false, "A302DocDelHora", context.localUtil.TToC( A302DocDelHora, 0, 5, 0, 3, "/", ":", " "));
         A304DocDelUsuID = "";
         n304DocDelUsuID = false;
         AssignAttri("", false, "A304DocDelUsuID", A304DocDelUsuID);
         A510DocDelUsuNome = "";
         n510DocDelUsuNome = false;
         AssignAttri("", false, "A510DocDelUsuNome", A510DocDelUsuNome);
         A290DocOrigem = "";
         AssignAttri("", false, "A290DocOrigem", A290DocOrigem);
         A291DocOrigemID = "";
         AssignAttri("", false, "A291DocOrigemID", A291DocOrigemID);
         AV33sdtRetorno = new GeneXus.Programs.core.SdtsdtRetorno(context);
         A327DocVersaoNomePai = "";
         AssignAttri("", false, "A327DocVersaoNomePai", A327DocVersaoNomePai);
         A147DocTipoSigla = "";
         AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
         A148DocTipoNome = "";
         AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
         A219DocTipoAtivo = false;
         AssignAttri("", false, "A219DocTipoAtivo", A219DocTipoAtivo);
         A306DocUltArqSeq = 0;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         A300DocDel = false;
         AssignAttri("", false, "A300DocDel", A300DocDel);
         A480DocContrato = false;
         AssignAttri("", false, "A480DocContrato", A480DocContrato);
         A481DocAssinado = false;
         AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
         A640DocAtivo = true;
         n640DocAtivo = false;
         AssignAttri("", false, "A640DocAtivo", A640DocAtivo);
         O300DocDel = A300DocDel;
         AssignAttri("", false, "A300DocDel", A300DocDel);
         Z305DocNome = "";
         Z325DocVersao = 0;
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         Z510DocDelUsuNome = "";
         Z290DocOrigem = "";
         Z291DocOrigemID = "";
         Z300DocDel = false;
         Z306DocUltArqSeq = 0;
         Z480DocContrato = false;
         Z481DocAssinado = false;
         Z640DocAtivo = false;
         Z146DocTipoID = 0;
         Z326DocVersaoIDPai = Guid.Empty;
      }

      protected void InitAll0U33( )
      {
         A289DocID = Guid.NewGuid( );
         AssignAttri("", false, "A289DocID", A289DocID.ToString());
         InitializeNonKey0U33( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A481DocAssinado = i481DocAssinado;
         AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
         A480DocContrato = i480DocContrato;
         AssignAttri("", false, "A480DocContrato", A480DocContrato);
         A640DocAtivo = i640DocAtivo;
         n640DocAtivo = false;
         AssignAttri("", false, "A640DocAtivo", A640DocAtivo);
         A300DocDel = i300DocDel;
         AssignAttri("", false, "A300DocDel", A300DocDel);
      }

      protected void define_styles( )
      {
         AddStyleSheetFile("FileUpload/fileupload.min.css", "");
         AddThemeStyleSheetFile("", context.GetTheme( )+".css", "?"+GetCacheInvalidationToken( ));
         bool outputEnabled = isOutputEnabled( );
         if ( context.isSpaRequest( ) )
         {
            enableOutput();
         }
         idxLst = 1;
         while ( idxLst <= Form.Jscriptsrc.Count )
         {
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828141446", true, true);
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
         context.AddJavascriptSource("core/documento.js", "?2023828141449", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/DropDownOptions/BootstrapDropDownOptionsRender.js", "", false, true);
         context.AddJavascriptSource("FileUpload/fileupload.min.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocNome_Internalname = "DOCNOME";
         lblTextblockdoctipoid_Internalname = "TEXTBLOCKDOCTIPOID";
         Combo_doctipoid_Internalname = "COMBO_DOCTIPOID";
         edtDocTipoID_Internalname = "DOCTIPOID";
         divTablesplitteddoctipoid_Internalname = "TABLESPLITTEDDOCTIPOID";
         chkDocContrato_Internalname = "DOCCONTRATO";
         chkDocAssinado_Internalname = "DOCASSINADO";
         Ucfileupload_Internalname = "UCFILEUPLOAD";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtavCombodoctipoid_Internalname = "vCOMBODOCTIPOID";
         divSectionattribute_doctipoid_Internalname = "SECTIONATTRIBUTE_DOCTIPOID";
         edtavDocorigem_Internalname = "vDOCORIGEM";
         edtavDocorigemid_Internalname = "vDOCORIGEMID";
         edtDocVersao_Internalname = "DOCVERSAO";
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
         Form.Caption = "Documento";
         edtDocVersao_Jsonclick = "";
         edtDocVersao_Enabled = 1;
         edtDocVersao_Visible = 1;
         edtavDocorigemid_Jsonclick = "";
         edtavDocorigemid_Enabled = 0;
         edtavDocorigemid_Visible = 1;
         edtavDocorigem_Jsonclick = "";
         edtavDocorigem_Enabled = 0;
         edtavDocorigem_Visible = 1;
         edtavCombodoctipoid_Jsonclick = "";
         edtavCombodoctipoid_Enabled = 0;
         edtavCombodoctipoid_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         Ucfileupload_Tooltiptext = "";
         Ucfileupload_Hideadditionalbuttons = Convert.ToBoolean( -1);
         Ucfileupload_Autoupload = Convert.ToBoolean( -1);
         chkDocAssinado.Enabled = 1;
         chkDocContrato.Enabled = 1;
         edtDocTipoID_Jsonclick = "";
         edtDocTipoID_Enabled = 1;
         edtDocTipoID_Visible = 1;
         Combo_doctipoid_Emptyitemtext = "";
         Combo_doctipoid_Cls = "ExtendedCombo AttributeFL";
         Combo_doctipoid_Enabled = Convert.ToBoolean( -1);
         edtDocNome_Jsonclick = "";
         edtDocNome_Enabled = 1;
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

      protected void XC_36_0U33( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ,
                                 Guid A289DocID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV31AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_37_0U33( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ,
                                 Guid A289DocID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "Y", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV31AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_38_0U33( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ,
                                 Guid A289DocID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV31AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_39_0U33( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ,
                                 Guid A289DocID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumento(context ).execute(  "N", ref  AV31AuditingObject,  A289DocID,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV31AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_41_0U33( string Gx_mode ,
                                 Guid A289DocID ,
                                 string AV29DocOrigem ,
                                 string AV30DocOrigemID )
      {
         if ( IsIns( )  || IsUpd( )  )
         {
            new GeneXus.Programs.core.prcdocumentovalidar(context ).execute(  A289DocID,  AV29DocOrigem,  AV30DocOrigemID,  true, out  AV33sdtRetorno) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV33sdtRetorno.ToXml(false, true, "", "")))+"\"") ;
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
         chkDocContrato.Name = "DOCCONTRATO";
         chkDocContrato.WebTags = "";
         chkDocContrato.Caption = "";
         AssignProp("", false, chkDocContrato_Internalname, "TitleCaption", chkDocContrato.Caption, true);
         chkDocContrato.CheckedValue = "false";
         if ( IsIns( ) && (false==A480DocContrato) )
         {
            A480DocContrato = false;
            AssignAttri("", false, "A480DocContrato", A480DocContrato);
         }
         chkDocAssinado.Name = "DOCASSINADO";
         chkDocAssinado.WebTags = "";
         chkDocAssinado.Caption = "";
         AssignProp("", false, chkDocAssinado_Internalname, "TitleCaption", chkDocAssinado.Caption, true);
         chkDocAssinado.CheckedValue = "false";
         if ( IsIns( ) && (false==A481DocAssinado) )
         {
            A481DocAssinado = false;
            AssignAttri("", false, "A481DocAssinado", A481DocAssinado);
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

      public void Valid_Doctipoid( )
      {
         /* Using cursor T000U16 */
         pr_default.execute(14, new Object[] {A146DocTipoID});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
         }
         A147DocTipoSigla = T000U16_A147DocTipoSigla[0];
         A148DocTipoNome = T000U16_A148DocTipoNome[0];
         A219DocTipoAtivo = T000U16_A219DocTipoAtivo[0];
         pr_default.close(14);
         if ( (0==A146DocTipoID) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 é obrigatório.", "Tipo do Documento", "", "", "", "", "", "", "", ""), 1, "DOCTIPOID");
            AnyError = 1;
            GX_FocusControl = edtDocTipoID_Internalname;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A147DocTipoSigla", A147DocTipoSigla);
         AssignAttri("", false, "A148DocTipoNome", A148DocTipoNome);
         AssignAttri("", false, "A219DocTipoAtivo", A219DocTipoAtivo);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV29DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV30DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV32sdtDocumento',fld:'vSDTDOCUMENTO',pic:'',hsh:true},{av:'AV7DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV29DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV30DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'A290DocOrigem',fld:'DOCORIGEM',pic:''},{av:'A291DocOrigemID',fld:'DOCORIGEMID',pic:''},{av:'AV36Pgmname',fld:'vPGMNAME',pic:''},{av:'A300DocDel',fld:'DOCDEL',pic:''},{av:'A306DocUltArqSeq',fld:'DOCULTARQSEQ',pic:'ZZZ9'},{av:'A640DocAtivo',fld:'DOCATIVO',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("AFTER TRN","{handler:'E130U2',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV32sdtDocumento',fld:'vSDTDOCUMENTO',pic:'',hsh:true},{av:'AV29DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV30DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV31AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV36Pgmname',fld:'vPGMNAME',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[{av:'AV32sdtDocumento',fld:'vSDTDOCUMENTO',pic:'',hsh:true},{av:'AV34webSessionParm',fld:'vWEBSESSIONPARM',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("UCFILEUPLOAD.UPLOADCOMPLETE","{handler:'E120U2',iparms:[{av:'AV29DocOrigem',fld:'vDOCORIGEM',pic:'',hsh:true},{av:'AV30DocOrigemID',fld:'vDOCORIGEMID',pic:'',hsh:true},{av:'AV24UploadedFiles',fld:'vUPLOADEDFILES',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("UCFILEUPLOAD.UPLOADCOMPLETE",",oparms:[{av:'AV34webSessionParm',fld:'vWEBSESSIONPARM',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALID_DOCNOME","{handler:'Valid_Docnome',iparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALID_DOCNOME",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALID_DOCTIPOID","{handler:'Valid_Doctipoid',iparms:[{av:'A146DocTipoID',fld:'DOCTIPOID',pic:'ZZZ,ZZZ,ZZ9'},{av:'A147DocTipoSigla',fld:'DOCTIPOSIGLA',pic:''},{av:'A148DocTipoNome',fld:'DOCTIPONOME',pic:'@!'},{av:'A219DocTipoAtivo',fld:'DOCTIPOATIVO',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALID_DOCTIPOID",",oparms:[{av:'A147DocTipoSigla',fld:'DOCTIPOSIGLA',pic:''},{av:'A148DocTipoNome',fld:'DOCTIPONOME',pic:'@!'},{av:'A219DocTipoAtivo',fld:'DOCTIPOATIVO',pic:''},{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALIDV_COMBODOCTIPOID","{handler:'Validv_Combodoctipoid',iparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALIDV_COMBODOCTIPOID",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALIDV_DOCORIGEM","{handler:'Validv_Docorigem',iparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALIDV_DOCORIGEM",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALIDV_DOCORIGEMID","{handler:'Validv_Docorigemid',iparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALIDV_DOCORIGEMID",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
         setEventMetadata("VALID_DOCVERSAO","{handler:'Valid_Docversao',iparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]");
         setEventMetadata("VALID_DOCVERSAO",",oparms:[{av:'A480DocContrato',fld:'DOCCONTRATO',pic:''},{av:'A481DocAssinado',fld:'DOCASSINADO',pic:''}]}");
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
         pr_default.close(14);
         pr_default.close(15);
      }

      public override bool UploadEnabled( )
      {
         return true ;
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7DocID = Guid.Empty;
         wcpOAV29DocOrigem = "";
         wcpOAV30DocOrigemID = "";
         Z289DocID = Guid.Empty;
         Z305DocNome = "";
         Z294DocInsDataHora = (DateTime)(DateTime.MinValue);
         Z292DocInsData = DateTime.MinValue;
         Z293DocInsHora = (DateTime)(DateTime.MinValue);
         Z295DocInsUsuID = "";
         Z298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         Z296DocUpdData = DateTime.MinValue;
         Z297DocUpdHora = (DateTime)(DateTime.MinValue);
         Z299DocUpdUsuID = "";
         Z303DocDelDataHora = (DateTime)(DateTime.MinValue);
         Z301DocDelData = (DateTime)(DateTime.MinValue);
         Z302DocDelHora = (DateTime)(DateTime.MinValue);
         Z304DocDelUsuID = "";
         Z510DocDelUsuNome = "";
         Z290DocOrigem = "";
         Z291DocOrigemID = "";
         Z326DocVersaoIDPai = Guid.Empty;
         N326DocVersaoIDPai = Guid.Empty;
         Combo_doctipoid_Selectedvalue_get = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A326DocVersaoIDPai = Guid.Empty;
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
         A305DocNome = "";
         lblTextblockdoctipoid_Jsonclick = "";
         ucCombo_doctipoid = new GXUserControl();
         Combo_doctipoid_Caption = "";
         AV16DocTipoID_Data = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         ucUcfileupload = new GXUserControl();
         AV24UploadedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "agl_tresorygroup");
         AV25FailedFiles = new GXBaseCollection<SdtFileUploadData>( context, "FileUploadData", "agl_tresorygroup");
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A295DocInsUsuID = "";
         A298DocUpdDataHora = (DateTime)(DateTime.MinValue);
         A296DocUpdData = DateTime.MinValue;
         A297DocUpdHora = (DateTime)(DateTime.MinValue);
         A299DocUpdUsuID = "";
         A303DocDelDataHora = (DateTime)(DateTime.MinValue);
         A301DocDelData = (DateTime)(DateTime.MinValue);
         A302DocDelHora = (DateTime)(DateTime.MinValue);
         A304DocDelUsuID = "";
         A510DocDelUsuNome = "";
         A294DocInsDataHora = (DateTime)(DateTime.MinValue);
         A292DocInsData = DateTime.MinValue;
         A293DocInsHora = (DateTime)(DateTime.MinValue);
         A290DocOrigem = "";
         A291DocOrigemID = "";
         A289DocID = Guid.Empty;
         AV13Insert_DocVersaoIDPai = Guid.Empty;
         AV31AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV33sdtRetorno = new GeneXus.Programs.core.SdtsdtRetorno(context);
         A147DocTipoSigla = "";
         A148DocTipoNome = "";
         A327DocVersaoNomePai = "";
         AV36Pgmname = "";
         Combo_doctipoid_Objectcall = "";
         Combo_doctipoid_Class = "";
         Combo_doctipoid_Icontype = "";
         Combo_doctipoid_Icon = "";
         Combo_doctipoid_Tooltip = "";
         Combo_doctipoid_Selectedvalue_set = "";
         Combo_doctipoid_Selectedtext_set = "";
         Combo_doctipoid_Selectedtext_get = "";
         Combo_doctipoid_Gamoauthtoken = "";
         Combo_doctipoid_Ddointernalname = "";
         Combo_doctipoid_Titlecontrolalign = "";
         Combo_doctipoid_Dropdownoptionstype = "";
         Combo_doctipoid_Titlecontrolidtoreplace = "";
         Combo_doctipoid_Datalisttype = "";
         Combo_doctipoid_Datalistfixedvalues = "";
         Combo_doctipoid_Datalistproc = "";
         Combo_doctipoid_Datalistprocparametersprefix = "";
         Combo_doctipoid_Remoteservicesparameters = "";
         Combo_doctipoid_Htmltemplate = "";
         Combo_doctipoid_Multiplevaluestype = "";
         Combo_doctipoid_Loadingdata = "";
         Combo_doctipoid_Noresultsfound = "";
         Combo_doctipoid_Onlyselectedvalues = "";
         Combo_doctipoid_Selectalltext = "";
         Combo_doctipoid_Multiplevaluesseparator = "";
         Combo_doctipoid_Addnewoptiontext = "";
         Ucfileupload_Objectcall = "";
         Ucfileupload_Class = "";
         Ucfileupload_Acceptedfiletypes = "";
         Ucfileupload_Customfiletypes = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         T000U5_A327DocVersaoNomePai = new string[] {""} ;
         sMode33 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         AV15TrnContextAtt = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute(context);
         AV34webSessionParm = "";
         AV32sdtDocumento = new GeneXus.Programs.core.SdtsdtDocumento(context);
         AV27Messages = new GXBaseCollection<GeneXus.Utils.SdtMessages_Message>( context, "Message", "GeneXus");
         GXt_objcol_SdtDVB_SDTComboData_Item1 = new GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item>( context, "Item", "");
         AV18ComboSelectedValue = "";
         Z327DocVersaoNomePai = "";
         Z147DocTipoSigla = "";
         Z148DocTipoNome = "";
         T000U4_A147DocTipoSigla = new string[] {""} ;
         T000U4_A148DocTipoNome = new string[] {""} ;
         T000U4_A219DocTipoAtivo = new bool[] {false} ;
         T000U6_A289DocID = new Guid[] {Guid.Empty} ;
         T000U6_A305DocNome = new string[] {""} ;
         T000U6_A325DocVersao = new short[1] ;
         T000U6_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         T000U6_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_A295DocInsUsuID = new string[] {""} ;
         T000U6_n295DocInsUsuID = new bool[] {false} ;
         T000U6_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_n298DocUpdDataHora = new bool[] {false} ;
         T000U6_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         T000U6_n296DocUpdData = new bool[] {false} ;
         T000U6_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_n297DocUpdHora = new bool[] {false} ;
         T000U6_A299DocUpdUsuID = new string[] {""} ;
         T000U6_n299DocUpdUsuID = new bool[] {false} ;
         T000U6_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_n303DocDelDataHora = new bool[] {false} ;
         T000U6_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         T000U6_n301DocDelData = new bool[] {false} ;
         T000U6_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         T000U6_n302DocDelHora = new bool[] {false} ;
         T000U6_A304DocDelUsuID = new string[] {""} ;
         T000U6_n304DocDelUsuID = new bool[] {false} ;
         T000U6_A510DocDelUsuNome = new string[] {""} ;
         T000U6_n510DocDelUsuNome = new bool[] {false} ;
         T000U6_A290DocOrigem = new string[] {""} ;
         T000U6_A291DocOrigemID = new string[] {""} ;
         T000U6_A327DocVersaoNomePai = new string[] {""} ;
         T000U6_A300DocDel = new bool[] {false} ;
         T000U6_A147DocTipoSigla = new string[] {""} ;
         T000U6_A148DocTipoNome = new string[] {""} ;
         T000U6_A219DocTipoAtivo = new bool[] {false} ;
         T000U6_A306DocUltArqSeq = new short[1] ;
         T000U6_n306DocUltArqSeq = new bool[] {false} ;
         T000U6_A480DocContrato = new bool[] {false} ;
         T000U6_A481DocAssinado = new bool[] {false} ;
         T000U6_A640DocAtivo = new bool[] {false} ;
         T000U6_n640DocAtivo = new bool[] {false} ;
         T000U6_A146DocTipoID = new int[1] ;
         T000U6_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T000U6_n326DocVersaoIDPai = new bool[] {false} ;
         T000U7_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T000U7_n326DocVersaoIDPai = new bool[] {false} ;
         T000U8_A147DocTipoSigla = new string[] {""} ;
         T000U8_A148DocTipoNome = new string[] {""} ;
         T000U8_A219DocTipoAtivo = new bool[] {false} ;
         T000U9_A327DocVersaoNomePai = new string[] {""} ;
         T000U10_A289DocID = new Guid[] {Guid.Empty} ;
         T000U3_A289DocID = new Guid[] {Guid.Empty} ;
         T000U3_A305DocNome = new string[] {""} ;
         T000U3_A325DocVersao = new short[1] ;
         T000U3_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         T000U3_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_A295DocInsUsuID = new string[] {""} ;
         T000U3_n295DocInsUsuID = new bool[] {false} ;
         T000U3_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_n298DocUpdDataHora = new bool[] {false} ;
         T000U3_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         T000U3_n296DocUpdData = new bool[] {false} ;
         T000U3_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_n297DocUpdHora = new bool[] {false} ;
         T000U3_A299DocUpdUsuID = new string[] {""} ;
         T000U3_n299DocUpdUsuID = new bool[] {false} ;
         T000U3_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_n303DocDelDataHora = new bool[] {false} ;
         T000U3_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         T000U3_n301DocDelData = new bool[] {false} ;
         T000U3_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         T000U3_n302DocDelHora = new bool[] {false} ;
         T000U3_A304DocDelUsuID = new string[] {""} ;
         T000U3_n304DocDelUsuID = new bool[] {false} ;
         T000U3_A510DocDelUsuNome = new string[] {""} ;
         T000U3_n510DocDelUsuNome = new bool[] {false} ;
         T000U3_A290DocOrigem = new string[] {""} ;
         T000U3_A291DocOrigemID = new string[] {""} ;
         T000U3_A300DocDel = new bool[] {false} ;
         T000U3_A306DocUltArqSeq = new short[1] ;
         T000U3_n306DocUltArqSeq = new bool[] {false} ;
         T000U3_A480DocContrato = new bool[] {false} ;
         T000U3_A481DocAssinado = new bool[] {false} ;
         T000U3_A640DocAtivo = new bool[] {false} ;
         T000U3_n640DocAtivo = new bool[] {false} ;
         T000U3_A146DocTipoID = new int[1] ;
         T000U3_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T000U3_n326DocVersaoIDPai = new bool[] {false} ;
         T000U11_A289DocID = new Guid[] {Guid.Empty} ;
         T000U12_A289DocID = new Guid[] {Guid.Empty} ;
         T000U2_A289DocID = new Guid[] {Guid.Empty} ;
         T000U2_A305DocNome = new string[] {""} ;
         T000U2_A325DocVersao = new short[1] ;
         T000U2_A294DocInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_A292DocInsData = new DateTime[] {DateTime.MinValue} ;
         T000U2_A293DocInsHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_A295DocInsUsuID = new string[] {""} ;
         T000U2_n295DocInsUsuID = new bool[] {false} ;
         T000U2_A298DocUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_n298DocUpdDataHora = new bool[] {false} ;
         T000U2_A296DocUpdData = new DateTime[] {DateTime.MinValue} ;
         T000U2_n296DocUpdData = new bool[] {false} ;
         T000U2_A297DocUpdHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_n297DocUpdHora = new bool[] {false} ;
         T000U2_A299DocUpdUsuID = new string[] {""} ;
         T000U2_n299DocUpdUsuID = new bool[] {false} ;
         T000U2_A303DocDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_n303DocDelDataHora = new bool[] {false} ;
         T000U2_A301DocDelData = new DateTime[] {DateTime.MinValue} ;
         T000U2_n301DocDelData = new bool[] {false} ;
         T000U2_A302DocDelHora = new DateTime[] {DateTime.MinValue} ;
         T000U2_n302DocDelHora = new bool[] {false} ;
         T000U2_A304DocDelUsuID = new string[] {""} ;
         T000U2_n304DocDelUsuID = new bool[] {false} ;
         T000U2_A510DocDelUsuNome = new string[] {""} ;
         T000U2_n510DocDelUsuNome = new bool[] {false} ;
         T000U2_A290DocOrigem = new string[] {""} ;
         T000U2_A291DocOrigemID = new string[] {""} ;
         T000U2_A300DocDel = new bool[] {false} ;
         T000U2_A306DocUltArqSeq = new short[1] ;
         T000U2_n306DocUltArqSeq = new bool[] {false} ;
         T000U2_A480DocContrato = new bool[] {false} ;
         T000U2_A481DocAssinado = new bool[] {false} ;
         T000U2_A640DocAtivo = new bool[] {false} ;
         T000U2_n640DocAtivo = new bool[] {false} ;
         T000U2_A146DocTipoID = new int[1] ;
         T000U2_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T000U2_n326DocVersaoIDPai = new bool[] {false} ;
         T000U16_A147DocTipoSigla = new string[] {""} ;
         T000U16_A148DocTipoNome = new string[] {""} ;
         T000U16_A219DocTipoAtivo = new bool[] {false} ;
         T000U17_A327DocVersaoNomePai = new string[] {""} ;
         T000U18_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T000U18_n326DocVersaoIDPai = new bool[] {false} ;
         T000U19_A289DocID = new Guid[] {Guid.Empty} ;
         T000U19_A307DocArqSeq = new short[1] ;
         T000U20_A289DocID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documento__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documento__default(),
            new Object[][] {
                new Object[] {
               T000U2_A289DocID, T000U2_A305DocNome, T000U2_A325DocVersao, T000U2_A294DocInsDataHora, T000U2_A292DocInsData, T000U2_A293DocInsHora, T000U2_A295DocInsUsuID, T000U2_n295DocInsUsuID, T000U2_A298DocUpdDataHora, T000U2_n298DocUpdDataHora,
               T000U2_A296DocUpdData, T000U2_n296DocUpdData, T000U2_A297DocUpdHora, T000U2_n297DocUpdHora, T000U2_A299DocUpdUsuID, T000U2_n299DocUpdUsuID, T000U2_A303DocDelDataHora, T000U2_n303DocDelDataHora, T000U2_A301DocDelData, T000U2_n301DocDelData,
               T000U2_A302DocDelHora, T000U2_n302DocDelHora, T000U2_A304DocDelUsuID, T000U2_n304DocDelUsuID, T000U2_A510DocDelUsuNome, T000U2_n510DocDelUsuNome, T000U2_A290DocOrigem, T000U2_A291DocOrigemID, T000U2_A300DocDel, T000U2_A306DocUltArqSeq,
               T000U2_n306DocUltArqSeq, T000U2_A480DocContrato, T000U2_A481DocAssinado, T000U2_A640DocAtivo, T000U2_n640DocAtivo, T000U2_A146DocTipoID, T000U2_A326DocVersaoIDPai, T000U2_n326DocVersaoIDPai
               }
               , new Object[] {
               T000U3_A289DocID, T000U3_A305DocNome, T000U3_A325DocVersao, T000U3_A294DocInsDataHora, T000U3_A292DocInsData, T000U3_A293DocInsHora, T000U3_A295DocInsUsuID, T000U3_n295DocInsUsuID, T000U3_A298DocUpdDataHora, T000U3_n298DocUpdDataHora,
               T000U3_A296DocUpdData, T000U3_n296DocUpdData, T000U3_A297DocUpdHora, T000U3_n297DocUpdHora, T000U3_A299DocUpdUsuID, T000U3_n299DocUpdUsuID, T000U3_A303DocDelDataHora, T000U3_n303DocDelDataHora, T000U3_A301DocDelData, T000U3_n301DocDelData,
               T000U3_A302DocDelHora, T000U3_n302DocDelHora, T000U3_A304DocDelUsuID, T000U3_n304DocDelUsuID, T000U3_A510DocDelUsuNome, T000U3_n510DocDelUsuNome, T000U3_A290DocOrigem, T000U3_A291DocOrigemID, T000U3_A300DocDel, T000U3_A306DocUltArqSeq,
               T000U3_n306DocUltArqSeq, T000U3_A480DocContrato, T000U3_A481DocAssinado, T000U3_A640DocAtivo, T000U3_n640DocAtivo, T000U3_A146DocTipoID, T000U3_A326DocVersaoIDPai, T000U3_n326DocVersaoIDPai
               }
               , new Object[] {
               T000U4_A147DocTipoSigla, T000U4_A148DocTipoNome, T000U4_A219DocTipoAtivo
               }
               , new Object[] {
               T000U5_A327DocVersaoNomePai
               }
               , new Object[] {
               T000U6_A289DocID, T000U6_A305DocNome, T000U6_A325DocVersao, T000U6_A294DocInsDataHora, T000U6_A292DocInsData, T000U6_A293DocInsHora, T000U6_A295DocInsUsuID, T000U6_n295DocInsUsuID, T000U6_A298DocUpdDataHora, T000U6_n298DocUpdDataHora,
               T000U6_A296DocUpdData, T000U6_n296DocUpdData, T000U6_A297DocUpdHora, T000U6_n297DocUpdHora, T000U6_A299DocUpdUsuID, T000U6_n299DocUpdUsuID, T000U6_A303DocDelDataHora, T000U6_n303DocDelDataHora, T000U6_A301DocDelData, T000U6_n301DocDelData,
               T000U6_A302DocDelHora, T000U6_n302DocDelHora, T000U6_A304DocDelUsuID, T000U6_n304DocDelUsuID, T000U6_A510DocDelUsuNome, T000U6_n510DocDelUsuNome, T000U6_A290DocOrigem, T000U6_A291DocOrigemID, T000U6_A327DocVersaoNomePai, T000U6_A300DocDel,
               T000U6_A147DocTipoSigla, T000U6_A148DocTipoNome, T000U6_A219DocTipoAtivo, T000U6_A306DocUltArqSeq, T000U6_n306DocUltArqSeq, T000U6_A480DocContrato, T000U6_A481DocAssinado, T000U6_A640DocAtivo, T000U6_n640DocAtivo, T000U6_A146DocTipoID,
               T000U6_A326DocVersaoIDPai, T000U6_n326DocVersaoIDPai
               }
               , new Object[] {
               T000U7_A326DocVersaoIDPai, T000U7_n326DocVersaoIDPai
               }
               , new Object[] {
               T000U8_A147DocTipoSigla, T000U8_A148DocTipoNome, T000U8_A219DocTipoAtivo
               }
               , new Object[] {
               T000U9_A327DocVersaoNomePai
               }
               , new Object[] {
               T000U10_A289DocID
               }
               , new Object[] {
               T000U11_A289DocID
               }
               , new Object[] {
               T000U12_A289DocID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000U16_A147DocTipoSigla, T000U16_A148DocTipoNome, T000U16_A219DocTipoAtivo
               }
               , new Object[] {
               T000U17_A327DocVersaoNomePai
               }
               , new Object[] {
               T000U18_A326DocVersaoIDPai
               }
               , new Object[] {
               T000U19_A289DocID, T000U19_A307DocArqSeq
               }
               , new Object[] {
               T000U20_A289DocID
               }
            }
         );
         Z481DocAssinado = false;
         A481DocAssinado = false;
         i481DocAssinado = false;
         Z480DocContrato = false;
         A480DocContrato = false;
         i480DocContrato = false;
         Z289DocID = Guid.NewGuid( );
         A289DocID = Guid.NewGuid( );
         AV36Pgmname = "core.Documento";
         Z300DocDel = false;
         O300DocDel = false;
         A300DocDel = false;
         i300DocDel = false;
         Z640DocAtivo = true;
         n640DocAtivo = false;
         A640DocAtivo = true;
         n640DocAtivo = false;
         i640DocAtivo = true;
         n640DocAtivo = false;
      }

      private short Z325DocVersao ;
      private short Z306DocUltArqSeq ;
      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private short Gx_BScreen ;
      private short RcdFound33 ;
      private short GX_JID ;
      private short nIsDirty_33 ;
      private short gxajaxcallmode ;
      private int Z146DocTipoID ;
      private int N146DocTipoID ;
      private int A146DocTipoID ;
      private int trnEnded ;
      private int edtDocNome_Enabled ;
      private int edtDocTipoID_Visible ;
      private int edtDocTipoID_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int AV21ComboDocTipoID ;
      private int edtavCombodoctipoid_Enabled ;
      private int edtavCombodoctipoid_Visible ;
      private int edtavDocorigem_Visible ;
      private int edtavDocorigem_Enabled ;
      private int edtavDocorigemid_Visible ;
      private int edtavDocorigemid_Enabled ;
      private int edtDocVersao_Enabled ;
      private int edtDocVersao_Visible ;
      private int AV14Insert_DocTipoID ;
      private int Combo_doctipoid_Datalistupdateminimumcharacters ;
      private int Combo_doctipoid_Gxcontroltype ;
      private int Ucfileupload_Maxfilesize ;
      private int Ucfileupload_Maxnumberoffiles ;
      private int Ucfileupload_Gxcontroltype ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int AV37GXV1 ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z295DocInsUsuID ;
      private string Z299DocUpdUsuID ;
      private string Z304DocDelUsuID ;
      private string Combo_doctipoid_Selectedvalue_get ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDocNome_Internalname ;
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
      private string edtDocNome_Jsonclick ;
      private string divTablesplitteddoctipoid_Internalname ;
      private string lblTextblockdoctipoid_Internalname ;
      private string lblTextblockdoctipoid_Jsonclick ;
      private string Combo_doctipoid_Caption ;
      private string Combo_doctipoid_Cls ;
      private string Combo_doctipoid_Emptyitemtext ;
      private string Combo_doctipoid_Internalname ;
      private string edtDocTipoID_Internalname ;
      private string edtDocTipoID_Jsonclick ;
      private string chkDocContrato_Internalname ;
      private string chkDocAssinado_Internalname ;
      private string Ucfileupload_Tooltiptext ;
      private string Ucfileupload_Internalname ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string divSectionattribute_doctipoid_Internalname ;
      private string edtavCombodoctipoid_Internalname ;
      private string edtavCombodoctipoid_Jsonclick ;
      private string edtavDocorigem_Internalname ;
      private string edtavDocorigem_Jsonclick ;
      private string edtavDocorigemid_Internalname ;
      private string edtavDocorigemid_Jsonclick ;
      private string edtDocVersao_Internalname ;
      private string edtDocVersao_Jsonclick ;
      private string A295DocInsUsuID ;
      private string A299DocUpdUsuID ;
      private string A304DocDelUsuID ;
      private string AV36Pgmname ;
      private string Combo_doctipoid_Objectcall ;
      private string Combo_doctipoid_Class ;
      private string Combo_doctipoid_Icontype ;
      private string Combo_doctipoid_Icon ;
      private string Combo_doctipoid_Tooltip ;
      private string Combo_doctipoid_Selectedvalue_set ;
      private string Combo_doctipoid_Selectedtext_set ;
      private string Combo_doctipoid_Selectedtext_get ;
      private string Combo_doctipoid_Gamoauthtoken ;
      private string Combo_doctipoid_Ddointernalname ;
      private string Combo_doctipoid_Titlecontrolalign ;
      private string Combo_doctipoid_Dropdownoptionstype ;
      private string Combo_doctipoid_Titlecontrolidtoreplace ;
      private string Combo_doctipoid_Datalisttype ;
      private string Combo_doctipoid_Datalistfixedvalues ;
      private string Combo_doctipoid_Datalistproc ;
      private string Combo_doctipoid_Datalistprocparametersprefix ;
      private string Combo_doctipoid_Remoteservicesparameters ;
      private string Combo_doctipoid_Htmltemplate ;
      private string Combo_doctipoid_Multiplevaluestype ;
      private string Combo_doctipoid_Loadingdata ;
      private string Combo_doctipoid_Noresultsfound ;
      private string Combo_doctipoid_Onlyselectedvalues ;
      private string Combo_doctipoid_Selectalltext ;
      private string Combo_doctipoid_Multiplevaluesseparator ;
      private string Combo_doctipoid_Addnewoptiontext ;
      private string Ucfileupload_Objectcall ;
      private string Ucfileupload_Class ;
      private string Ucfileupload_Acceptedfiletypes ;
      private string Ucfileupload_Customfiletypes ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode33 ;
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
      private DateTime Z294DocInsDataHora ;
      private DateTime Z293DocInsHora ;
      private DateTime Z298DocUpdDataHora ;
      private DateTime Z297DocUpdHora ;
      private DateTime Z303DocDelDataHora ;
      private DateTime Z301DocDelData ;
      private DateTime Z302DocDelHora ;
      private DateTime A298DocUpdDataHora ;
      private DateTime A297DocUpdHora ;
      private DateTime A303DocDelDataHora ;
      private DateTime A301DocDelData ;
      private DateTime A302DocDelHora ;
      private DateTime A294DocInsDataHora ;
      private DateTime A293DocInsHora ;
      private DateTime Z292DocInsData ;
      private DateTime Z296DocUpdData ;
      private DateTime A296DocUpdData ;
      private DateTime A292DocInsData ;
      private bool Z300DocDel ;
      private bool Z480DocContrato ;
      private bool Z481DocAssinado ;
      private bool Z640DocAtivo ;
      private bool O300DocDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n326DocVersaoIDPai ;
      private bool wbErr ;
      private bool A480DocContrato ;
      private bool A481DocAssinado ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool Ucfileupload_Autoupload ;
      private bool Ucfileupload_Hideadditionalbuttons ;
      private bool n295DocInsUsuID ;
      private bool n298DocUpdDataHora ;
      private bool n296DocUpdData ;
      private bool n297DocUpdHora ;
      private bool n299DocUpdUsuID ;
      private bool n303DocDelDataHora ;
      private bool n301DocDelData ;
      private bool n302DocDelHora ;
      private bool n304DocDelUsuID ;
      private bool n510DocDelUsuNome ;
      private bool n306DocUltArqSeq ;
      private bool n640DocAtivo ;
      private bool A640DocAtivo ;
      private bool A300DocDel ;
      private bool A219DocTipoAtivo ;
      private bool Combo_doctipoid_Enabled ;
      private bool Combo_doctipoid_Visible ;
      private bool Combo_doctipoid_Allowmultipleselection ;
      private bool Combo_doctipoid_Isgriditem ;
      private bool Combo_doctipoid_Hasdescription ;
      private bool Combo_doctipoid_Includeonlyselectedoption ;
      private bool Combo_doctipoid_Includeselectalloption ;
      private bool Combo_doctipoid_Emptyitem ;
      private bool Combo_doctipoid_Includeaddnewoption ;
      private bool Ucfileupload_Enabled ;
      private bool Ucfileupload_Enableuploadedfilecanceling ;
      private bool Ucfileupload_Disableimageresize ;
      private bool Ucfileupload_Autodisableaddingfiles ;
      private bool Ucfileupload_Visible ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Z219DocTipoAtivo ;
      private bool Gx_longc ;
      private bool i481DocAssinado ;
      private bool i480DocContrato ;
      private bool i640DocAtivo ;
      private bool i300DocDel ;
      private string wcpOAV29DocOrigem ;
      private string wcpOAV30DocOrigemID ;
      private string Z305DocNome ;
      private string Z510DocDelUsuNome ;
      private string Z290DocOrigem ;
      private string Z291DocOrigemID ;
      private string AV29DocOrigem ;
      private string AV30DocOrigemID ;
      private string A305DocNome ;
      private string A510DocDelUsuNome ;
      private string A290DocOrigem ;
      private string A291DocOrigemID ;
      private string A147DocTipoSigla ;
      private string A148DocTipoNome ;
      private string A327DocVersaoNomePai ;
      private string AV34webSessionParm ;
      private string AV18ComboSelectedValue ;
      private string Z327DocVersaoNomePai ;
      private string Z147DocTipoSigla ;
      private string Z148DocTipoNome ;
      private Guid wcpOAV7DocID ;
      private Guid Z289DocID ;
      private Guid Z326DocVersaoIDPai ;
      private Guid N326DocVersaoIDPai ;
      private Guid A326DocVersaoIDPai ;
      private Guid AV7DocID ;
      private Guid A289DocID ;
      private Guid AV13Insert_DocVersaoIDPai ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private GXUserControl ucCombo_doctipoid ;
      private GXUserControl ucUcfileupload ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkDocContrato ;
      private GXCheckbox chkDocAssinado ;
      private IDataStoreProvider pr_default ;
      private string[] T000U5_A327DocVersaoNomePai ;
      private string[] T000U4_A147DocTipoSigla ;
      private string[] T000U4_A148DocTipoNome ;
      private bool[] T000U4_A219DocTipoAtivo ;
      private Guid[] T000U6_A289DocID ;
      private string[] T000U6_A305DocNome ;
      private short[] T000U6_A325DocVersao ;
      private DateTime[] T000U6_A294DocInsDataHora ;
      private DateTime[] T000U6_A292DocInsData ;
      private DateTime[] T000U6_A293DocInsHora ;
      private string[] T000U6_A295DocInsUsuID ;
      private bool[] T000U6_n295DocInsUsuID ;
      private DateTime[] T000U6_A298DocUpdDataHora ;
      private bool[] T000U6_n298DocUpdDataHora ;
      private DateTime[] T000U6_A296DocUpdData ;
      private bool[] T000U6_n296DocUpdData ;
      private DateTime[] T000U6_A297DocUpdHora ;
      private bool[] T000U6_n297DocUpdHora ;
      private string[] T000U6_A299DocUpdUsuID ;
      private bool[] T000U6_n299DocUpdUsuID ;
      private DateTime[] T000U6_A303DocDelDataHora ;
      private bool[] T000U6_n303DocDelDataHora ;
      private DateTime[] T000U6_A301DocDelData ;
      private bool[] T000U6_n301DocDelData ;
      private DateTime[] T000U6_A302DocDelHora ;
      private bool[] T000U6_n302DocDelHora ;
      private string[] T000U6_A304DocDelUsuID ;
      private bool[] T000U6_n304DocDelUsuID ;
      private string[] T000U6_A510DocDelUsuNome ;
      private bool[] T000U6_n510DocDelUsuNome ;
      private string[] T000U6_A290DocOrigem ;
      private string[] T000U6_A291DocOrigemID ;
      private string[] T000U6_A327DocVersaoNomePai ;
      private bool[] T000U6_A300DocDel ;
      private string[] T000U6_A147DocTipoSigla ;
      private string[] T000U6_A148DocTipoNome ;
      private bool[] T000U6_A219DocTipoAtivo ;
      private short[] T000U6_A306DocUltArqSeq ;
      private bool[] T000U6_n306DocUltArqSeq ;
      private bool[] T000U6_A480DocContrato ;
      private bool[] T000U6_A481DocAssinado ;
      private bool[] T000U6_A640DocAtivo ;
      private bool[] T000U6_n640DocAtivo ;
      private int[] T000U6_A146DocTipoID ;
      private Guid[] T000U6_A326DocVersaoIDPai ;
      private bool[] T000U6_n326DocVersaoIDPai ;
      private Guid[] T000U7_A326DocVersaoIDPai ;
      private bool[] T000U7_n326DocVersaoIDPai ;
      private string[] T000U8_A147DocTipoSigla ;
      private string[] T000U8_A148DocTipoNome ;
      private bool[] T000U8_A219DocTipoAtivo ;
      private string[] T000U9_A327DocVersaoNomePai ;
      private Guid[] T000U10_A289DocID ;
      private Guid[] T000U3_A289DocID ;
      private string[] T000U3_A305DocNome ;
      private short[] T000U3_A325DocVersao ;
      private DateTime[] T000U3_A294DocInsDataHora ;
      private DateTime[] T000U3_A292DocInsData ;
      private DateTime[] T000U3_A293DocInsHora ;
      private string[] T000U3_A295DocInsUsuID ;
      private bool[] T000U3_n295DocInsUsuID ;
      private DateTime[] T000U3_A298DocUpdDataHora ;
      private bool[] T000U3_n298DocUpdDataHora ;
      private DateTime[] T000U3_A296DocUpdData ;
      private bool[] T000U3_n296DocUpdData ;
      private DateTime[] T000U3_A297DocUpdHora ;
      private bool[] T000U3_n297DocUpdHora ;
      private string[] T000U3_A299DocUpdUsuID ;
      private bool[] T000U3_n299DocUpdUsuID ;
      private DateTime[] T000U3_A303DocDelDataHora ;
      private bool[] T000U3_n303DocDelDataHora ;
      private DateTime[] T000U3_A301DocDelData ;
      private bool[] T000U3_n301DocDelData ;
      private DateTime[] T000U3_A302DocDelHora ;
      private bool[] T000U3_n302DocDelHora ;
      private string[] T000U3_A304DocDelUsuID ;
      private bool[] T000U3_n304DocDelUsuID ;
      private string[] T000U3_A510DocDelUsuNome ;
      private bool[] T000U3_n510DocDelUsuNome ;
      private string[] T000U3_A290DocOrigem ;
      private string[] T000U3_A291DocOrigemID ;
      private bool[] T000U3_A300DocDel ;
      private short[] T000U3_A306DocUltArqSeq ;
      private bool[] T000U3_n306DocUltArqSeq ;
      private bool[] T000U3_A480DocContrato ;
      private bool[] T000U3_A481DocAssinado ;
      private bool[] T000U3_A640DocAtivo ;
      private bool[] T000U3_n640DocAtivo ;
      private int[] T000U3_A146DocTipoID ;
      private Guid[] T000U3_A326DocVersaoIDPai ;
      private bool[] T000U3_n326DocVersaoIDPai ;
      private Guid[] T000U11_A289DocID ;
      private Guid[] T000U12_A289DocID ;
      private Guid[] T000U2_A289DocID ;
      private string[] T000U2_A305DocNome ;
      private short[] T000U2_A325DocVersao ;
      private DateTime[] T000U2_A294DocInsDataHora ;
      private DateTime[] T000U2_A292DocInsData ;
      private DateTime[] T000U2_A293DocInsHora ;
      private string[] T000U2_A295DocInsUsuID ;
      private bool[] T000U2_n295DocInsUsuID ;
      private DateTime[] T000U2_A298DocUpdDataHora ;
      private bool[] T000U2_n298DocUpdDataHora ;
      private DateTime[] T000U2_A296DocUpdData ;
      private bool[] T000U2_n296DocUpdData ;
      private DateTime[] T000U2_A297DocUpdHora ;
      private bool[] T000U2_n297DocUpdHora ;
      private string[] T000U2_A299DocUpdUsuID ;
      private bool[] T000U2_n299DocUpdUsuID ;
      private DateTime[] T000U2_A303DocDelDataHora ;
      private bool[] T000U2_n303DocDelDataHora ;
      private DateTime[] T000U2_A301DocDelData ;
      private bool[] T000U2_n301DocDelData ;
      private DateTime[] T000U2_A302DocDelHora ;
      private bool[] T000U2_n302DocDelHora ;
      private string[] T000U2_A304DocDelUsuID ;
      private bool[] T000U2_n304DocDelUsuID ;
      private string[] T000U2_A510DocDelUsuNome ;
      private bool[] T000U2_n510DocDelUsuNome ;
      private string[] T000U2_A290DocOrigem ;
      private string[] T000U2_A291DocOrigemID ;
      private bool[] T000U2_A300DocDel ;
      private short[] T000U2_A306DocUltArqSeq ;
      private bool[] T000U2_n306DocUltArqSeq ;
      private bool[] T000U2_A480DocContrato ;
      private bool[] T000U2_A481DocAssinado ;
      private bool[] T000U2_A640DocAtivo ;
      private bool[] T000U2_n640DocAtivo ;
      private int[] T000U2_A146DocTipoID ;
      private Guid[] T000U2_A326DocVersaoIDPai ;
      private bool[] T000U2_n326DocVersaoIDPai ;
      private string[] T000U16_A147DocTipoSigla ;
      private string[] T000U16_A148DocTipoNome ;
      private bool[] T000U16_A219DocTipoAtivo ;
      private string[] T000U17_A327DocVersaoNomePai ;
      private Guid[] T000U18_A326DocVersaoIDPai ;
      private bool[] T000U18_n326DocVersaoIDPai ;
      private Guid[] T000U19_A289DocID ;
      private short[] T000U19_A307DocArqSeq ;
      private Guid[] T000U20_A289DocID ;
      private IDataStoreProvider pr_gam ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> AV16DocTipoID_Data ;
      private GXBaseCollection<GeneXus.Programs.wwpbaseobjects.SdtDVB_SDTComboData_Item> GXt_objcol_SdtDVB_SDTComboData_Item1 ;
      private GXBaseCollection<SdtFileUploadData> AV24UploadedFiles ;
      private GXBaseCollection<SdtFileUploadData> AV25FailedFiles ;
      private GXBaseCollection<GeneXus.Utils.SdtMessages_Message> AV27Messages ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV31AuditingObject ;
      private GeneXus.Programs.core.SdtsdtDocumento AV32sdtDocumento ;
      private GeneXus.Programs.core.SdtsdtRetorno AV33sdtRetorno ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext_Attribute AV15TrnContextAtt ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
   }

   public class documento__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documento__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000U6;
        prmT000U6 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U4;
        prmT000U4 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000U5;
        prmT000U5 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000U7;
        prmT000U7 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U8;
        prmT000U8 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        Object[] prmT000U9;
        prmT000U9 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000U10;
        prmT000U10 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U3;
        prmT000U3 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U11;
        prmT000U11 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U12;
        prmT000U12 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U2;
        prmT000U2 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U13;
        prmT000U13 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000U14;
        prmT000U14 = new Object[] {
        new ParDef("DocNome",GXType.VarChar,80,0) ,
        new ParDef("DocVersao",GXType.Int16,4,0) ,
        new ParDef("DocInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocInsData",GXType.Date,8,0) ,
        new ParDef("DocInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocUpdUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocOrigem",GXType.VarChar,30,0) ,
        new ParDef("DocOrigemID",GXType.VarChar,50,0) ,
        new ParDef("DocDel",GXType.Boolean,4,0) ,
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocContrato",GXType.Boolean,4,0) ,
        new ParDef("DocAssinado",GXType.Boolean,4,0) ,
        new ParDef("DocAtivo",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("DocTipoID",GXType.Int32,9,0) ,
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U15;
        prmT000U15 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U17;
        prmT000U17 = new Object[] {
        new ParDef("DocVersaoIDPai",GXType.UniqueIdentifier,36,0){Nullable=true}
        };
        Object[] prmT000U18;
        prmT000U18 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U19;
        prmT000U19 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT000U20;
        prmT000U20 = new Object[] {
        };
        Object[] prmT000U16;
        prmT000U16 = new Object[] {
        new ParDef("DocTipoID",GXType.Int32,9,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000U2", "SELECT DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000U2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U3", "SELECT DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U4", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U5", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U6", "SELECT TM1.DocID, TM1.DocNome, TM1.DocVersao, TM1.DocInsDataHora, TM1.DocInsData, TM1.DocInsHora, TM1.DocInsUsuID, TM1.DocUpdDataHora, TM1.DocUpdData, TM1.DocUpdHora, TM1.DocUpdUsuID, TM1.DocDelDataHora, TM1.DocDelData, TM1.DocDelHora, TM1.DocDelUsuID, TM1.DocDelUsuNome, TM1.DocOrigem, TM1.DocOrigemID, T2.DocNome AS DocVersaoNomePai, TM1.DocDel, T3.DocTipoSigla, T3.DocTipoNome, T3.DocTipoAtivo, TM1.DocUltArqSeq, TM1.DocContrato, TM1.DocAssinado, TM1.DocAtivo, TM1.DocTipoID, TM1.DocVersaoIDPai AS DocVersaoIDPai FROM ((tb_documento TM1 LEFT JOIN tb_documento T2 ON T2.DocID = TM1.DocVersaoIDPai) INNER JOIN tb_documentotipo T3 ON T3.DocTipoID = TM1.DocTipoID) WHERE TM1.DocID = :DocID ORDER BY TM1.DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U7", "SELECT DocVersaoIDPai FROM tb_documento WHERE (DocVersaoIDPai = :DocVersaoIDPai AND DocVersao = :DocVersao) AND (Not ( DocID = :DocID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U8", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U9", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U10", "SELECT DocID FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U11", "SELECT DocID FROM tb_documento WHERE ( DocID > :DocID) ORDER BY DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U12", "SELECT DocID FROM tb_documento WHERE ( DocID < :DocID) ORDER BY DocID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U13", "SAVEPOINT gxupdate;INSERT INTO tb_documento(DocID, DocNome, DocVersao, DocInsDataHora, DocInsData, DocInsHora, DocInsUsuID, DocUpdDataHora, DocUpdData, DocUpdHora, DocUpdUsuID, DocDelDataHora, DocDelData, DocDelHora, DocDelUsuID, DocDelUsuNome, DocOrigem, DocOrigemID, DocDel, DocUltArqSeq, DocContrato, DocAssinado, DocAtivo, DocTipoID, DocVersaoIDPai) VALUES(:DocID, :DocNome, :DocVersao, :DocInsDataHora, :DocInsData, :DocInsHora, :DocInsUsuID, :DocUpdDataHora, :DocUpdData, :DocUpdHora, :DocUpdUsuID, :DocDelDataHora, :DocDelData, :DocDelHora, :DocDelUsuID, :DocDelUsuNome, :DocOrigem, :DocOrigemID, :DocDel, :DocUltArqSeq, :DocContrato, :DocAssinado, :DocAtivo, :DocTipoID, :DocVersaoIDPai);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000U13)
           ,new CursorDef("T000U14", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocNome=:DocNome, DocVersao=:DocVersao, DocInsDataHora=:DocInsDataHora, DocInsData=:DocInsData, DocInsHora=:DocInsHora, DocInsUsuID=:DocInsUsuID, DocUpdDataHora=:DocUpdDataHora, DocUpdData=:DocUpdData, DocUpdHora=:DocUpdHora, DocUpdUsuID=:DocUpdUsuID, DocDelDataHora=:DocDelDataHora, DocDelData=:DocDelData, DocDelHora=:DocDelHora, DocDelUsuID=:DocDelUsuID, DocDelUsuNome=:DocDelUsuNome, DocOrigem=:DocOrigem, DocOrigemID=:DocOrigemID, DocDel=:DocDel, DocUltArqSeq=:DocUltArqSeq, DocContrato=:DocContrato, DocAssinado=:DocAssinado, DocAtivo=:DocAtivo, DocTipoID=:DocTipoID, DocVersaoIDPai=:DocVersaoIDPai  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U14)
           ,new CursorDef("T000U15", "SAVEPOINT gxupdate;DELETE FROM tb_documento  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000U15)
           ,new CursorDef("T000U16", "SELECT DocTipoSigla, DocTipoNome, DocTipoAtivo FROM tb_documentotipo WHERE DocTipoID = :DocTipoID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U17", "SELECT DocNome AS DocVersaoNomePai FROM tb_documento WHERE DocID = :DocVersaoIDPai ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000U18", "SELECT DocID AS DocVersaoIDPai FROM tb_documento WHERE DocVersaoIDPai = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U19", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000U20", "SELECT DocID FROM tb_documento ORDER BY DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT000U20,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((bool[]) buf[28])[0] = rslt.getBool(19);
              ((short[]) buf[29])[0] = rslt.getShort(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((bool[]) buf[33])[0] = rslt.getBool(23);
              ((bool[]) buf[34])[0] = rslt.wasNull(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((Guid[]) buf[36])[0] = rslt.getGuid(25);
              ((bool[]) buf[37])[0] = rslt.wasNull(25);
              return;
           case 1 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((bool[]) buf[28])[0] = rslt.getBool(19);
              ((short[]) buf[29])[0] = rslt.getShort(20);
              ((bool[]) buf[30])[0] = rslt.wasNull(20);
              ((bool[]) buf[31])[0] = rslt.getBool(21);
              ((bool[]) buf[32])[0] = rslt.getBool(22);
              ((bool[]) buf[33])[0] = rslt.getBool(23);
              ((bool[]) buf[34])[0] = rslt.wasNull(23);
              ((int[]) buf[35])[0] = rslt.getInt(24);
              ((Guid[]) buf[36])[0] = rslt.getGuid(25);
              ((bool[]) buf[37])[0] = rslt.wasNull(25);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((short[]) buf[2])[0] = rslt.getShort(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6);
              ((string[]) buf[6])[0] = rslt.getString(7, 40);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[9])[0] = rslt.wasNull(8);
              ((DateTime[]) buf[10])[0] = rslt.getGXDate(9);
              ((bool[]) buf[11])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10);
              ((bool[]) buf[13])[0] = rslt.wasNull(10);
              ((string[]) buf[14])[0] = rslt.getString(11, 40);
              ((bool[]) buf[15])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[16])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[17])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(13);
              ((bool[]) buf[19])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[21])[0] = rslt.wasNull(14);
              ((string[]) buf[22])[0] = rslt.getString(15, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(15);
              ((string[]) buf[24])[0] = rslt.getVarchar(16);
              ((bool[]) buf[25])[0] = rslt.wasNull(16);
              ((string[]) buf[26])[0] = rslt.getVarchar(17);
              ((string[]) buf[27])[0] = rslt.getVarchar(18);
              ((string[]) buf[28])[0] = rslt.getVarchar(19);
              ((bool[]) buf[29])[0] = rslt.getBool(20);
              ((string[]) buf[30])[0] = rslt.getVarchar(21);
              ((string[]) buf[31])[0] = rslt.getVarchar(22);
              ((bool[]) buf[32])[0] = rslt.getBool(23);
              ((short[]) buf[33])[0] = rslt.getShort(24);
              ((bool[]) buf[34])[0] = rslt.wasNull(24);
              ((bool[]) buf[35])[0] = rslt.getBool(25);
              ((bool[]) buf[36])[0] = rslt.getBool(26);
              ((bool[]) buf[37])[0] = rslt.getBool(27);
              ((bool[]) buf[38])[0] = rslt.wasNull(27);
              ((int[]) buf[39])[0] = rslt.getInt(28);
              ((Guid[]) buf[40])[0] = rslt.getGuid(29);
              ((bool[]) buf[41])[0] = rslt.wasNull(29);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 9 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 10 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 14 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((bool[]) buf[2])[0] = rslt.getBool(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 17 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 18 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
     }
  }

}

}
