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
   public class documentoarquivo : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_27") == 0 )
         {
            A289DocID = StringUtil.StrToGuid( GetPar( "DocID"));
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_27( A289DocID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.documentoarquivo.aspx")), "core.documentoarquivo.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.documentoarquivo.aspx")))) ;
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
                  AV24DocArqSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "DocArqSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "AV24DocArqSeq", StringUtil.LTrimStr( (decimal)(AV24DocArqSeq), 4, 0));
                  GxWebStd.gx_hidden_field( context, "gxhash_vDOCARQSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24DocArqSeq), "ZZZ9"), context));
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
            Form.Meta.addItem("description", "Arquivo do Documento", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtDocArqObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public documentoarquivo( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public documentoarquivo( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_DocID ,
                           short aP2_DocArqSeq )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7DocID = aP1_DocID;
         this.AV24DocArqSeq = aP2_DocArqSeq;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocArqConteudoNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocArqConteudoNome_Internalname, "Nome do Arquivo", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocArqConteudoNome_Internalname, A322DocArqConteudoNome, "", "", 0, 1, edtDocArqConteudoNome_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\DocumentoArquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocArqConteudoExtensao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocArqConteudoExtensao_Internalname, "Extensão", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtDocArqConteudoExtensao_Internalname, A323DocArqConteudoExtensao, StringUtil.RTrim( context.localUtil.Format( A323DocArqConteudoExtensao, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocArqConteudoExtensao_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtDocArqConteudoExtensao_Enabled, 0, "text", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_core\\DocumentoArquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtDocArqObservacao_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtDocArqObservacao_Internalname, "Observações", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 32,'',false,'',0)\"";
         ClassString = "AttributeFL";
         StyleString = "";
         ClassString = "AttributeFL";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtDocArqObservacao_Internalname, A324DocArqObservacao, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,32);\"", 0, 1, edtDocArqObservacao_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_core\\DocumentoArquivo.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoArquivo.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\DocumentoArquivo.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 43,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocID_Internalname, A289DocID.ToString(), A289DocID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,43);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocID_Jsonclick, 0, "Attribute", "", "", "", "", edtDocID_Visible, edtDocID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\DocumentoArquivo.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtDocArqSeq_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ",", "")), StringUtil.LTrim( context.localUtil.Format( (decimal)(A307DocArqSeq), "ZZZ9")), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtDocArqSeq_Jsonclick, 0, "Attribute", "", "", "", "", edtDocArqSeq_Visible, edtDocArqSeq_Enabled, 1, "text", "1", 4, "chr", 1, "row", 4, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\DocumentoArquivo.htm");
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
         E11172 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z289DocID = StringUtil.StrToGuid( cgiGet( "Z289DocID"));
               Z307DocArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z307DocArqSeq"), ",", "."), 18, MidpointRounding.ToEven));
               Z310DocArqInsDataHora = context.localUtil.CToT( cgiGet( "Z310DocArqInsDataHora"), 0);
               Z308DocArqInsData = context.localUtil.CToD( cgiGet( "Z308DocArqInsData"), 0);
               Z309DocArqInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z309DocArqInsHora"), 0));
               Z311DocArqInsUsuID = cgiGet( "Z311DocArqInsUsuID");
               n311DocArqInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A311DocArqInsUsuID)) ? true : false);
               Z319DocArqDelDataHora = context.localUtil.CToT( cgiGet( "Z319DocArqDelDataHora"), 0);
               n319DocArqDelDataHora = ((DateTime.MinValue==A319DocArqDelDataHora) ? true : false);
               Z317DocArqDelData = context.localUtil.CToT( cgiGet( "Z317DocArqDelData"), 0);
               n317DocArqDelData = ((DateTime.MinValue==A317DocArqDelData) ? true : false);
               Z511DocArqDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z511DocArqDelHora"), 0));
               n511DocArqDelHora = ((DateTime.MinValue==A511DocArqDelHora) ? true : false);
               Z320DocArqDelUsuID = cgiGet( "Z320DocArqDelUsuID");
               n320DocArqDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A320DocArqDelUsuID)) ? true : false);
               Z509DocArqDelUsuNome = cgiGet( "Z509DocArqDelUsuNome");
               n509DocArqDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A509DocArqDelUsuNome)) ? true : false);
               Z312DocArqUpdData = context.localUtil.CToD( cgiGet( "Z312DocArqUpdData"), 0);
               n312DocArqUpdData = ((DateTime.MinValue==A312DocArqUpdData) ? true : false);
               Z313DocArqUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z313DocArqUpdHora"), 0));
               n313DocArqUpdHora = ((DateTime.MinValue==A313DocArqUpdHora) ? true : false);
               Z314DocArqUpdDataHora = context.localUtil.CToT( cgiGet( "Z314DocArqUpdDataHora"), 0);
               n314DocArqUpdDataHora = ((DateTime.MinValue==A314DocArqUpdDataHora) ? true : false);
               Z315DocArqUsuID = cgiGet( "Z315DocArqUsuID");
               n315DocArqUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A315DocArqUsuID)) ? true : false);
               Z316DocArqDel = StringUtil.StrToBool( cgiGet( "Z316DocArqDel"));
               Z324DocArqObservacao = cgiGet( "Z324DocArqObservacao");
               n324DocArqObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A324DocArqObservacao)) ? true : false);
               Z644DocArqArmExterno = StringUtil.StrToBool( cgiGet( "Z644DocArqArmExterno"));
               Z645DocArqArmExternoPath = cgiGet( "Z645DocArqArmExternoPath");
               n645DocArqArmExternoPath = (String.IsNullOrEmpty(StringUtil.RTrim( A645DocArqArmExternoPath)) ? true : false);
               Z325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z325DocVersao"), ",", "."), 18, MidpointRounding.ToEven));
               Z326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "Z326DocVersaoIDPai"));
               A310DocArqInsDataHora = context.localUtil.CToT( cgiGet( "Z310DocArqInsDataHora"), 0);
               A308DocArqInsData = context.localUtil.CToD( cgiGet( "Z308DocArqInsData"), 0);
               A309DocArqInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z309DocArqInsHora"), 0));
               A311DocArqInsUsuID = cgiGet( "Z311DocArqInsUsuID");
               n311DocArqInsUsuID = false;
               n311DocArqInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A311DocArqInsUsuID)) ? true : false);
               A319DocArqDelDataHora = context.localUtil.CToT( cgiGet( "Z319DocArqDelDataHora"), 0);
               n319DocArqDelDataHora = false;
               n319DocArqDelDataHora = ((DateTime.MinValue==A319DocArqDelDataHora) ? true : false);
               A317DocArqDelData = context.localUtil.CToT( cgiGet( "Z317DocArqDelData"), 0);
               n317DocArqDelData = false;
               n317DocArqDelData = ((DateTime.MinValue==A317DocArqDelData) ? true : false);
               A511DocArqDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z511DocArqDelHora"), 0));
               n511DocArqDelHora = false;
               n511DocArqDelHora = ((DateTime.MinValue==A511DocArqDelHora) ? true : false);
               A320DocArqDelUsuID = cgiGet( "Z320DocArqDelUsuID");
               n320DocArqDelUsuID = false;
               n320DocArqDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A320DocArqDelUsuID)) ? true : false);
               A509DocArqDelUsuNome = cgiGet( "Z509DocArqDelUsuNome");
               n509DocArqDelUsuNome = false;
               n509DocArqDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A509DocArqDelUsuNome)) ? true : false);
               A312DocArqUpdData = context.localUtil.CToD( cgiGet( "Z312DocArqUpdData"), 0);
               n312DocArqUpdData = false;
               n312DocArqUpdData = ((DateTime.MinValue==A312DocArqUpdData) ? true : false);
               A313DocArqUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z313DocArqUpdHora"), 0));
               n313DocArqUpdHora = false;
               n313DocArqUpdHora = ((DateTime.MinValue==A313DocArqUpdHora) ? true : false);
               A314DocArqUpdDataHora = context.localUtil.CToT( cgiGet( "Z314DocArqUpdDataHora"), 0);
               n314DocArqUpdDataHora = false;
               n314DocArqUpdDataHora = ((DateTime.MinValue==A314DocArqUpdDataHora) ? true : false);
               A315DocArqUsuID = cgiGet( "Z315DocArqUsuID");
               n315DocArqUsuID = false;
               n315DocArqUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A315DocArqUsuID)) ? true : false);
               A316DocArqDel = StringUtil.StrToBool( cgiGet( "Z316DocArqDel"));
               A644DocArqArmExterno = StringUtil.StrToBool( cgiGet( "Z644DocArqArmExterno"));
               A645DocArqArmExternoPath = cgiGet( "Z645DocArqArmExternoPath");
               n645DocArqArmExternoPath = false;
               n645DocArqArmExternoPath = (String.IsNullOrEmpty(StringUtil.RTrim( A645DocArqArmExternoPath)) ? true : false);
               A325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z325DocVersao"), ",", "."), 18, MidpointRounding.ToEven));
               A326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "Z326DocVersaoIDPai"));
               n326DocVersaoIDPai = false;
               O316DocArqDel = StringUtil.StrToBool( cgiGet( "O316DocArqDel"));
               O306DocUltArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "O306DocUltArqSeq"), ",", "."), 18, MidpointRounding.ToEven));
               n306DocUltArqSeq = ((0==A306DocUltArqSeq) ? true : false);
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7DocID = StringUtil.StrToGuid( cgiGet( "vDOCID"));
               AV24DocArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vDOCARQSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               A306DocUltArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( "DOCULTARQSEQ"), ",", "."), 18, MidpointRounding.ToEven));
               n306DocUltArqSeq = ((0==A306DocUltArqSeq) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               A310DocArqInsDataHora = context.localUtil.CToT( cgiGet( "DOCARQINSDATAHORA"), 0);
               A308DocArqInsData = context.localUtil.CToD( cgiGet( "DOCARQINSDATA"), 0);
               A309DocArqInsHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCARQINSHORA"), 0));
               A311DocArqInsUsuID = cgiGet( "DOCARQINSUSUID");
               n311DocArqInsUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A311DocArqInsUsuID)) ? true : false);
               A316DocArqDel = StringUtil.StrToBool( cgiGet( "DOCARQDEL"));
               A319DocArqDelDataHora = context.localUtil.CToT( cgiGet( "DOCARQDELDATAHORA"), 0);
               n319DocArqDelDataHora = ((DateTime.MinValue==A319DocArqDelDataHora) ? true : false);
               A317DocArqDelData = context.localUtil.CToT( cgiGet( "DOCARQDELDATA"), 0);
               n317DocArqDelData = ((DateTime.MinValue==A317DocArqDelData) ? true : false);
               A511DocArqDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCARQDELHORA"), 0));
               n511DocArqDelHora = ((DateTime.MinValue==A511DocArqDelHora) ? true : false);
               A320DocArqDelUsuID = cgiGet( "DOCARQDELUSUID");
               n320DocArqDelUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A320DocArqDelUsuID)) ? true : false);
               A509DocArqDelUsuNome = cgiGet( "DOCARQDELUSUNOME");
               n509DocArqDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A509DocArqDelUsuNome)) ? true : false);
               A644DocArqArmExterno = StringUtil.StrToBool( cgiGet( "DOCARQARMEXTERNO"));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV25AuditingObject);
               A312DocArqUpdData = context.localUtil.CToD( cgiGet( "DOCARQUPDDATA"), 0);
               n312DocArqUpdData = ((DateTime.MinValue==A312DocArqUpdData) ? true : false);
               A313DocArqUpdHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "DOCARQUPDHORA"), 0));
               n313DocArqUpdHora = ((DateTime.MinValue==A313DocArqUpdHora) ? true : false);
               A314DocArqUpdDataHora = context.localUtil.CToT( cgiGet( "DOCARQUPDDATAHORA"), 0);
               n314DocArqUpdDataHora = ((DateTime.MinValue==A314DocArqUpdDataHora) ? true : false);
               A315DocArqUsuID = cgiGet( "DOCARQUSUID");
               n315DocArqUsuID = (String.IsNullOrEmpty(StringUtil.RTrim( A315DocArqUsuID)) ? true : false);
               A321DocArqConteudo = cgiGet( "DOCARQCONTEUDO");
               n321DocArqConteudo = false;
               n321DocArqConteudo = (String.IsNullOrEmpty(StringUtil.RTrim( A321DocArqConteudo)) ? true : false);
               A645DocArqArmExternoPath = cgiGet( "DOCARQARMEXTERNOPATH");
               n645DocArqArmExternoPath = (String.IsNullOrEmpty(StringUtil.RTrim( A645DocArqArmExternoPath)) ? true : false);
               A325DocVersao = (short)(Math.Round(context.localUtil.CToN( cgiGet( "DOCVERSAO"), ",", "."), 18, MidpointRounding.ToEven));
               A326DocVersaoIDPai = StringUtil.StrToGuid( cgiGet( "DOCVERSAOIDPAI"));
               AV27Pgmname = cgiGet( "vPGMNAME");
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
               A324DocArqObservacao = cgiGet( edtDocArqObservacao_Internalname);
               n324DocArqObservacao = false;
               AssignAttri("", false, "A324DocArqObservacao", A324DocArqObservacao);
               n324DocArqObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A324DocArqObservacao)) ? true : false);
               if ( StringUtil.StrCmp(cgiGet( edtDocID_Internalname), "") == 0 )
               {
                  A289DocID = Guid.Empty;
                  AssignAttri("", false, "A289DocID", A289DocID.ToString());
               }
               else
               {
                  try
                  {
                     A289DocID = StringUtil.StrToGuid( cgiGet( edtDocID_Internalname));
                     AssignAttri("", false, "A289DocID", A289DocID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "DOCID");
                     AnyError = 1;
                     GX_FocusControl = edtDocID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtDocArqSeq_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtDocArqSeq_Internalname), ",", ".") > Convert.ToDecimal( 9999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "DOCARQSEQ");
                  AnyError = 1;
                  GX_FocusControl = edtDocArqSeq_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A307DocArqSeq = 0;
                  AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
               }
               else
               {
                  A307DocArqSeq = (short)(Math.Round(context.localUtil.CToN( cgiGet( edtDocArqSeq_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
               }
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"DocumentoArquivo");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")));
               forbiddenHiddens.Add("DocArqUpdData", context.localUtil.Format(A312DocArqUpdData, "99/99/99"));
               forbiddenHiddens.Add("DocArqUpdHora", context.localUtil.Format( A313DocArqUpdHora, "99:99"));
               forbiddenHiddens.Add("DocArqUpdDataHora", context.localUtil.Format( A314DocArqUpdDataHora, "99/99/9999 99:99:99.999"));
               forbiddenHiddens.Add("DocArqUsuID", StringUtil.RTrim( context.localUtil.Format( A315DocArqUsuID, "")));
               forbiddenHiddens.Add("DocArqDel", StringUtil.BoolToStr( A316DocArqDel));
               forbiddenHiddens.Add("DocArqArmExterno", StringUtil.BoolToStr( A644DocArqArmExterno));
               forbiddenHiddens.Add("DocArqArmExternoPath", StringUtil.RTrim( context.localUtil.Format( A645DocArqArmExternoPath, "")));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\documentoarquivo:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A307DocArqSeq = (short)(Math.Round(NumberUtil.Val( GetPar( "DocArqSeq"), "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
                  getEqualNoModal( ) ;
                  if ( ! (0==AV24DocArqSeq) )
                  {
                     A307DocArqSeq = AV24DocArqSeq;
                     AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
                  }
                  else
                  {
                     if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                     {
                        A307DocArqSeq = A306DocUltArqSeq;
                        AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
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
                     sMode34 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     if ( ! (0==AV24DocArqSeq) )
                     {
                        A307DocArqSeq = AV24DocArqSeq;
                        AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
                     }
                     else
                     {
                        if ( IsIns( )  && ( Gx_BScreen == 1 ) )
                        {
                           A307DocArqSeq = A306DocUltArqSeq;
                           AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
                        }
                     }
                     Gx_mode = sMode34;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound34 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_170( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "DOCID");
                        AnyError = 1;
                        GX_FocusControl = edtDocID_Internalname;
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
                           E11172 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12172 ();
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
            E12172 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1734( ) ;
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
            DisableAttributes1734( ) ;
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

      protected void CONFIRM_170( )
      {
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1734( ) ;
            }
            else
            {
               CheckExtendedTable1734( ) ;
               CloseExtendedTableCursors1734( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption170( )
      {
      }

      protected void E11172( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtDocID_Visible = 0;
         AssignProp("", false, edtDocID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocID_Visible), 5, 0), true);
         edtDocArqSeq_Visible = 0;
         AssignProp("", false, edtDocArqSeq_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtDocArqSeq_Visible), 5, 0), true);
      }

      protected void E12172( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV25AuditingObject,  AV27Pgmname) ;
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1734( short GX_JID )
      {
         if ( ( GX_JID == 26 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z310DocArqInsDataHora = T00173_A310DocArqInsDataHora[0];
               Z308DocArqInsData = T00173_A308DocArqInsData[0];
               Z309DocArqInsHora = T00173_A309DocArqInsHora[0];
               Z311DocArqInsUsuID = T00173_A311DocArqInsUsuID[0];
               Z319DocArqDelDataHora = T00173_A319DocArqDelDataHora[0];
               Z317DocArqDelData = T00173_A317DocArqDelData[0];
               Z511DocArqDelHora = T00173_A511DocArqDelHora[0];
               Z320DocArqDelUsuID = T00173_A320DocArqDelUsuID[0];
               Z509DocArqDelUsuNome = T00173_A509DocArqDelUsuNome[0];
               Z312DocArqUpdData = T00173_A312DocArqUpdData[0];
               Z313DocArqUpdHora = T00173_A313DocArqUpdHora[0];
               Z314DocArqUpdDataHora = T00173_A314DocArqUpdDataHora[0];
               Z315DocArqUsuID = T00173_A315DocArqUsuID[0];
               Z316DocArqDel = T00173_A316DocArqDel[0];
               Z324DocArqObservacao = T00173_A324DocArqObservacao[0];
               Z644DocArqArmExterno = T00173_A644DocArqArmExterno[0];
               Z645DocArqArmExternoPath = T00173_A645DocArqArmExternoPath[0];
            }
            else
            {
               Z310DocArqInsDataHora = A310DocArqInsDataHora;
               Z308DocArqInsData = A308DocArqInsData;
               Z309DocArqInsHora = A309DocArqInsHora;
               Z311DocArqInsUsuID = A311DocArqInsUsuID;
               Z319DocArqDelDataHora = A319DocArqDelDataHora;
               Z317DocArqDelData = A317DocArqDelData;
               Z511DocArqDelHora = A511DocArqDelHora;
               Z320DocArqDelUsuID = A320DocArqDelUsuID;
               Z509DocArqDelUsuNome = A509DocArqDelUsuNome;
               Z312DocArqUpdData = A312DocArqUpdData;
               Z313DocArqUpdHora = A313DocArqUpdHora;
               Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
               Z315DocArqUsuID = A315DocArqUsuID;
               Z316DocArqDel = A316DocArqDel;
               Z324DocArqObservacao = A324DocArqObservacao;
               Z644DocArqArmExterno = A644DocArqArmExterno;
               Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
            }
         }
         if ( ( GX_JID == 27 ) || ( GX_JID == 0 ) )
         {
            Z325DocVersao = T00175_A325DocVersao[0];
            Z326DocVersaoIDPai = T00175_A326DocVersaoIDPai[0];
         }
         if ( GX_JID == -26 )
         {
            Z307DocArqSeq = A307DocArqSeq;
            Z310DocArqInsDataHora = A310DocArqInsDataHora;
            Z308DocArqInsData = A308DocArqInsData;
            Z309DocArqInsHora = A309DocArqInsHora;
            Z311DocArqInsUsuID = A311DocArqInsUsuID;
            Z319DocArqDelDataHora = A319DocArqDelDataHora;
            Z317DocArqDelData = A317DocArqDelData;
            Z511DocArqDelHora = A511DocArqDelHora;
            Z320DocArqDelUsuID = A320DocArqDelUsuID;
            Z509DocArqDelUsuNome = A509DocArqDelUsuNome;
            Z312DocArqUpdData = A312DocArqUpdData;
            Z313DocArqUpdHora = A313DocArqUpdHora;
            Z314DocArqUpdDataHora = A314DocArqUpdDataHora;
            Z315DocArqUsuID = A315DocArqUsuID;
            Z316DocArqDel = A316DocArqDel;
            Z321DocArqConteudo = A321DocArqConteudo;
            Z324DocArqObservacao = A324DocArqObservacao;
            Z644DocArqArmExterno = A644DocArqArmExterno;
            Z645DocArqArmExternoPath = A645DocArqArmExternoPath;
            Z323DocArqConteudoExtensao = A323DocArqConteudoExtensao;
            Z322DocArqConteudoNome = A322DocArqConteudoNome;
            Z289DocID = A289DocID;
            Z306DocUltArqSeq = A306DocUltArqSeq;
            Z325DocVersao = A325DocVersao;
            Z326DocVersaoIDPai = A326DocVersaoIDPai;
         }
      }

      protected void standaloneNotModal( )
      {
         edtDocArqConteudoNome_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoNome_Enabled), 5, 0), true);
         edtDocArqConteudoExtensao_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoExtensao_Enabled), 5, 0), true);
         AV27Pgmname = "core.DocumentoArquivo";
         AssignAttri("", false, "AV27Pgmname", AV27Pgmname);
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         edtDocArqConteudoNome_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoNome_Enabled), 5, 0), true);
         edtDocArqConteudoExtensao_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoExtensao_Enabled), 5, 0), true);
         if ( ! (Guid.Empty==AV7DocID) )
         {
            A289DocID = AV7DocID;
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
         }
         if ( ! (Guid.Empty==AV7DocID) )
         {
            edtDocID_Enabled = 0;
            AssignProp("", false, edtDocID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocID_Enabled), 5, 0), true);
         }
         else
         {
            edtDocID_Enabled = 1;
            AssignProp("", false, edtDocID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7DocID) )
         {
            edtDocID_Enabled = 0;
            AssignProp("", false, edtDocID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocID_Enabled), 5, 0), true);
         }
         if ( ! (0==AV24DocArqSeq) )
         {
            edtDocArqSeq_Enabled = 0;
            AssignProp("", false, edtDocArqSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqSeq_Enabled), 5, 0), true);
         }
         else
         {
            edtDocArqSeq_Enabled = 1;
            AssignProp("", false, edtDocArqSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqSeq_Enabled), 5, 0), true);
         }
         if ( ! (0==AV24DocArqSeq) )
         {
            edtDocArqSeq_Enabled = 0;
            AssignProp("", false, edtDocArqSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqSeq_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A644DocArqArmExterno) && ( Gx_BScreen == 0 ) )
         {
            A644DocArqArmExterno = false;
            AssignAttri("", false, "A644DocArqArmExterno", A644DocArqArmExterno);
         }
         if ( IsIns( )  && (false==A316DocArqDel) && ( Gx_BScreen == 0 ) )
         {
            A316DocArqDel = false;
            AssignAttri("", false, "A316DocArqDel", A316DocArqDel);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00175 */
            pr_default.execute(3, new Object[] {A289DocID});
            ZM1734( 27) ;
            A306DocUltArqSeq = T00175_A306DocUltArqSeq[0];
            n306DocUltArqSeq = T00175_n306DocUltArqSeq[0];
            A325DocVersao = T00175_A325DocVersao[0];
            A326DocVersaoIDPai = T00175_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = T00175_n326DocVersaoIDPai[0];
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
            AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
            pr_default.close(3);
         }
      }

      protected void Load1734( )
      {
         /* Using cursor T00176 */
         pr_default.execute(4, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound34 = 1;
            A306DocUltArqSeq = T00176_A306DocUltArqSeq[0];
            n306DocUltArqSeq = T00176_n306DocUltArqSeq[0];
            A310DocArqInsDataHora = T00176_A310DocArqInsDataHora[0];
            A308DocArqInsData = T00176_A308DocArqInsData[0];
            A309DocArqInsHora = T00176_A309DocArqInsHora[0];
            A311DocArqInsUsuID = T00176_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = T00176_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = T00176_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = T00176_n319DocArqDelDataHora[0];
            A317DocArqDelData = T00176_A317DocArqDelData[0];
            n317DocArqDelData = T00176_n317DocArqDelData[0];
            A511DocArqDelHora = T00176_A511DocArqDelHora[0];
            n511DocArqDelHora = T00176_n511DocArqDelHora[0];
            A320DocArqDelUsuID = T00176_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = T00176_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = T00176_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = T00176_n509DocArqDelUsuNome[0];
            A325DocVersao = T00176_A325DocVersao[0];
            A312DocArqUpdData = T00176_A312DocArqUpdData[0];
            n312DocArqUpdData = T00176_n312DocArqUpdData[0];
            A313DocArqUpdHora = T00176_A313DocArqUpdHora[0];
            n313DocArqUpdHora = T00176_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = T00176_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = T00176_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = T00176_A315DocArqUsuID[0];
            n315DocArqUsuID = T00176_n315DocArqUsuID[0];
            A316DocArqDel = T00176_A316DocArqDel[0];
            A324DocArqObservacao = T00176_A324DocArqObservacao[0];
            n324DocArqObservacao = T00176_n324DocArqObservacao[0];
            AssignAttri("", false, "A324DocArqObservacao", A324DocArqObservacao);
            A644DocArqArmExterno = T00176_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = T00176_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = T00176_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = T00176_A323DocArqConteudoExtensao[0];
            AssignAttri("", false, "A323DocArqConteudoExtensao", A323DocArqConteudoExtensao);
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = T00176_A322DocArqConteudoNome[0];
            AssignAttri("", false, "A322DocArqConteudoNome", A322DocArqConteudoNome);
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A326DocVersaoIDPai = T00176_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = T00176_n326DocVersaoIDPai[0];
            A321DocArqConteudo = T00176_A321DocArqConteudo[0];
            n321DocArqConteudo = T00176_n321DocArqConteudo[0];
            ZM1734( -26) ;
         }
         pr_default.close(4);
         OnLoadActions1734( ) ;
      }

      protected void OnLoadActions1734( )
      {
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         if ( IsIns( )  )
         {
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
            AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         }
         if ( ! (0==AV24DocArqSeq) )
         {
            A307DocArqSeq = AV24DocArqSeq;
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               A307DocArqSeq = A306DocUltArqSeq;
               AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
            }
         }
      }

      protected void CheckExtendedTable1734( )
      {
         nIsDirty_34 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {A289DocID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
            AnyError = 1;
            GX_FocusControl = edtDocID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A306DocUltArqSeq = T00175_A306DocUltArqSeq[0];
         n306DocUltArqSeq = T00175_n306DocUltArqSeq[0];
         A325DocVersao = T00175_A325DocVersao[0];
         A326DocVersaoIDPai = T00175_A326DocVersaoIDPai[0];
         n326DocVersaoIDPai = T00175_n326DocVersaoIDPai[0];
         nIsDirty_34 = 1;
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         pr_default.close(3);
         if ( IsIns( )  )
         {
            nIsDirty_34 = 1;
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
            AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         }
         if ( ! (0==AV24DocArqSeq) )
         {
            nIsDirty_34 = 1;
            A307DocArqSeq = AV24DocArqSeq;
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
         }
         else
         {
            if ( IsIns( )  && ( Gx_BScreen == 1 ) )
            {
               nIsDirty_34 = 1;
               A307DocArqSeq = A306DocUltArqSeq;
               AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
            }
         }
      }

      protected void CloseExtendedTableCursors1734( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_27( Guid A289DocID )
      {
         /* Using cursor T00175 */
         pr_default.execute(3, new Object[] {A289DocID});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
            AnyError = 1;
            GX_FocusControl = edtDocID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A306DocUltArqSeq = T00175_A306DocUltArqSeq[0];
         n306DocUltArqSeq = T00175_n306DocUltArqSeq[0];
         A325DocVersao = T00175_A325DocVersao[0];
         A326DocVersaoIDPai = T00175_A326DocVersaoIDPai[0];
         n326DocVersaoIDPai = T00175_n326DocVersaoIDPai[0];
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A306DocUltArqSeq), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A326DocVersaoIDPai.ToString())+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(3) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(3);
      }

      protected void GetKey1734( )
      {
         /* Using cursor T00177 */
         pr_default.execute(5, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound34 = 1;
         }
         else
         {
            RcdFound34 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00173 */
         pr_default.execute(1, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1734( 26) ;
            RcdFound34 = 1;
            A307DocArqSeq = T00173_A307DocArqSeq[0];
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
            A310DocArqInsDataHora = T00173_A310DocArqInsDataHora[0];
            A308DocArqInsData = T00173_A308DocArqInsData[0];
            A309DocArqInsHora = T00173_A309DocArqInsHora[0];
            A311DocArqInsUsuID = T00173_A311DocArqInsUsuID[0];
            n311DocArqInsUsuID = T00173_n311DocArqInsUsuID[0];
            A319DocArqDelDataHora = T00173_A319DocArqDelDataHora[0];
            n319DocArqDelDataHora = T00173_n319DocArqDelDataHora[0];
            A317DocArqDelData = T00173_A317DocArqDelData[0];
            n317DocArqDelData = T00173_n317DocArqDelData[0];
            A511DocArqDelHora = T00173_A511DocArqDelHora[0];
            n511DocArqDelHora = T00173_n511DocArqDelHora[0];
            A320DocArqDelUsuID = T00173_A320DocArqDelUsuID[0];
            n320DocArqDelUsuID = T00173_n320DocArqDelUsuID[0];
            A509DocArqDelUsuNome = T00173_A509DocArqDelUsuNome[0];
            n509DocArqDelUsuNome = T00173_n509DocArqDelUsuNome[0];
            A312DocArqUpdData = T00173_A312DocArqUpdData[0];
            n312DocArqUpdData = T00173_n312DocArqUpdData[0];
            A313DocArqUpdHora = T00173_A313DocArqUpdHora[0];
            n313DocArqUpdHora = T00173_n313DocArqUpdHora[0];
            A314DocArqUpdDataHora = T00173_A314DocArqUpdDataHora[0];
            n314DocArqUpdDataHora = T00173_n314DocArqUpdDataHora[0];
            A315DocArqUsuID = T00173_A315DocArqUsuID[0];
            n315DocArqUsuID = T00173_n315DocArqUsuID[0];
            A316DocArqDel = T00173_A316DocArqDel[0];
            A324DocArqObservacao = T00173_A324DocArqObservacao[0];
            n324DocArqObservacao = T00173_n324DocArqObservacao[0];
            AssignAttri("", false, "A324DocArqObservacao", A324DocArqObservacao);
            A644DocArqArmExterno = T00173_A644DocArqArmExterno[0];
            A645DocArqArmExternoPath = T00173_A645DocArqArmExternoPath[0];
            n645DocArqArmExternoPath = T00173_n645DocArqArmExternoPath[0];
            A323DocArqConteudoExtensao = T00173_A323DocArqConteudoExtensao[0];
            AssignAttri("", false, "A323DocArqConteudoExtensao", A323DocArqConteudoExtensao);
            A321DocArqConteudo_Filetype = A323DocArqConteudoExtensao;
            A322DocArqConteudoNome = T00173_A322DocArqConteudoNome[0];
            AssignAttri("", false, "A322DocArqConteudoNome", A322DocArqConteudoNome);
            A321DocArqConteudo_Filename = A322DocArqConteudoNome;
            A289DocID = T00173_A289DocID[0];
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            A321DocArqConteudo = T00173_A321DocArqConteudo[0];
            n321DocArqConteudo = T00173_n321DocArqConteudo[0];
            O316DocArqDel = A316DocArqDel;
            AssignAttri("", false, "A316DocArqDel", A316DocArqDel);
            Z289DocID = A289DocID;
            Z307DocArqSeq = A307DocArqSeq;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1734( ) ;
            if ( AnyError == 1 )
            {
               RcdFound34 = 0;
               InitializeNonKey1734( ) ;
            }
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound34 = 0;
            InitializeNonKey1734( ) ;
            sMode34 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode34;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1734( ) ;
         if ( RcdFound34 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound34 = 0;
         /* Using cursor T00178 */
         pr_default.execute(6, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00178_A289DocID[0], A289DocID, 0) < 0 ) || ( T00178_A289DocID[0] == A289DocID ) && ( T00178_A307DocArqSeq[0] < A307DocArqSeq ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( GuidUtil.Compare(T00178_A289DocID[0], A289DocID, 0) > 0 ) || ( T00178_A289DocID[0] == A289DocID ) && ( T00178_A307DocArqSeq[0] > A307DocArqSeq ) ) )
            {
               A289DocID = T00178_A289DocID[0];
               AssignAttri("", false, "A289DocID", A289DocID.ToString());
               A307DocArqSeq = T00178_A307DocArqSeq[0];
               AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound34 = 0;
         /* Using cursor T00179 */
         pr_default.execute(7, new Object[] {A289DocID, A307DocArqSeq});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00179_A289DocID[0], A289DocID, 0) > 0 ) || ( T00179_A289DocID[0] == A289DocID ) && ( T00179_A307DocArqSeq[0] > A307DocArqSeq ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T00179_A289DocID[0], A289DocID, 0) < 0 ) || ( T00179_A289DocID[0] == A289DocID ) && ( T00179_A307DocArqSeq[0] < A307DocArqSeq ) ) )
            {
               A289DocID = T00179_A289DocID[0];
               AssignAttri("", false, "A289DocID", A289DocID.ToString());
               A307DocArqSeq = T00179_A307DocArqSeq[0];
               AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
               RcdFound34 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1734( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtDocArqObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1734( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound34 == 1 )
            {
               if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
               {
                  A289DocID = Z289DocID;
                  AssignAttri("", false, "A289DocID", A289DocID.ToString());
                  A307DocArqSeq = Z307DocArqSeq;
                  AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "DOCID");
                  AnyError = 1;
                  GX_FocusControl = edtDocID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtDocArqObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1734( ) ;
                  GX_FocusControl = edtDocArqObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
               {
                  /* Insert record */
                  GX_FocusControl = edtDocArqObservacao_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1734( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "DOCID");
                     AnyError = 1;
                     GX_FocusControl = edtDocID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtDocArqObservacao_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1734( ) ;
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
         if ( ( A289DocID != Z289DocID ) || ( A307DocArqSeq != Z307DocArqSeq ) )
         {
            A289DocID = Z289DocID;
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            A307DocArqSeq = Z307DocArqSeq;
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "DOCID");
            AnyError = 1;
            GX_FocusControl = edtDocID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtDocArqObservacao_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1734( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00172 */
            pr_default.execute(0, new Object[] {A289DocID, A307DocArqSeq});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z310DocArqInsDataHora != T00172_A310DocArqInsDataHora[0] ) || ( DateTimeUtil.ResetTime ( Z308DocArqInsData ) != DateTimeUtil.ResetTime ( T00172_A308DocArqInsData[0] ) ) || ( Z309DocArqInsHora != T00172_A309DocArqInsHora[0] ) || ( StringUtil.StrCmp(Z311DocArqInsUsuID, T00172_A311DocArqInsUsuID[0]) != 0 ) || ( Z319DocArqDelDataHora != T00172_A319DocArqDelDataHora[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z317DocArqDelData != T00172_A317DocArqDelData[0] ) || ( Z511DocArqDelHora != T00172_A511DocArqDelHora[0] ) || ( StringUtil.StrCmp(Z320DocArqDelUsuID, T00172_A320DocArqDelUsuID[0]) != 0 ) || ( StringUtil.StrCmp(Z509DocArqDelUsuNome, T00172_A509DocArqDelUsuNome[0]) != 0 ) || ( DateTimeUtil.ResetTime ( Z312DocArqUpdData ) != DateTimeUtil.ResetTime ( T00172_A312DocArqUpdData[0] ) ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z313DocArqUpdHora != T00172_A313DocArqUpdHora[0] ) || ( Z314DocArqUpdDataHora != T00172_A314DocArqUpdDataHora[0] ) || ( StringUtil.StrCmp(Z315DocArqUsuID, T00172_A315DocArqUsuID[0]) != 0 ) || ( Z316DocArqDel != T00172_A316DocArqDel[0] ) || ( StringUtil.StrCmp(Z324DocArqObservacao, T00172_A324DocArqObservacao[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z644DocArqArmExterno != T00172_A644DocArqArmExterno[0] ) || ( StringUtil.StrCmp(Z645DocArqArmExternoPath, T00172_A645DocArqArmExternoPath[0]) != 0 ) )
            {
               if ( Z310DocArqInsDataHora != T00172_A310DocArqInsDataHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqInsDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z310DocArqInsDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A310DocArqInsDataHora[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z308DocArqInsData ) != DateTimeUtil.ResetTime ( T00172_A308DocArqInsData[0] ) )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqInsData");
                  GXUtil.WriteLogRaw("Old: ",Z308DocArqInsData);
                  GXUtil.WriteLogRaw("Current: ",T00172_A308DocArqInsData[0]);
               }
               if ( Z309DocArqInsHora != T00172_A309DocArqInsHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqInsHora");
                  GXUtil.WriteLogRaw("Old: ",Z309DocArqInsHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A309DocArqInsHora[0]);
               }
               if ( StringUtil.StrCmp(Z311DocArqInsUsuID, T00172_A311DocArqInsUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqInsUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z311DocArqInsUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00172_A311DocArqInsUsuID[0]);
               }
               if ( Z319DocArqDelDataHora != T00172_A319DocArqDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z319DocArqDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A319DocArqDelDataHora[0]);
               }
               if ( Z317DocArqDelData != T00172_A317DocArqDelData[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDelData");
                  GXUtil.WriteLogRaw("Old: ",Z317DocArqDelData);
                  GXUtil.WriteLogRaw("Current: ",T00172_A317DocArqDelData[0]);
               }
               if ( Z511DocArqDelHora != T00172_A511DocArqDelHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z511DocArqDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A511DocArqDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z320DocArqDelUsuID, T00172_A320DocArqDelUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDelUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z320DocArqDelUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00172_A320DocArqDelUsuID[0]);
               }
               if ( StringUtil.StrCmp(Z509DocArqDelUsuNome, T00172_A509DocArqDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z509DocArqDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00172_A509DocArqDelUsuNome[0]);
               }
               if ( DateTimeUtil.ResetTime ( Z312DocArqUpdData ) != DateTimeUtil.ResetTime ( T00172_A312DocArqUpdData[0] ) )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqUpdData");
                  GXUtil.WriteLogRaw("Old: ",Z312DocArqUpdData);
                  GXUtil.WriteLogRaw("Current: ",T00172_A312DocArqUpdData[0]);
               }
               if ( Z313DocArqUpdHora != T00172_A313DocArqUpdHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqUpdHora");
                  GXUtil.WriteLogRaw("Old: ",Z313DocArqUpdHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A313DocArqUpdHora[0]);
               }
               if ( Z314DocArqUpdDataHora != T00172_A314DocArqUpdDataHora[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqUpdDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z314DocArqUpdDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00172_A314DocArqUpdDataHora[0]);
               }
               if ( StringUtil.StrCmp(Z315DocArqUsuID, T00172_A315DocArqUsuID[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqUsuID");
                  GXUtil.WriteLogRaw("Old: ",Z315DocArqUsuID);
                  GXUtil.WriteLogRaw("Current: ",T00172_A315DocArqUsuID[0]);
               }
               if ( Z316DocArqDel != T00172_A316DocArqDel[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqDel");
                  GXUtil.WriteLogRaw("Old: ",Z316DocArqDel);
                  GXUtil.WriteLogRaw("Current: ",T00172_A316DocArqDel[0]);
               }
               if ( StringUtil.StrCmp(Z324DocArqObservacao, T00172_A324DocArqObservacao[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqObservacao");
                  GXUtil.WriteLogRaw("Old: ",Z324DocArqObservacao);
                  GXUtil.WriteLogRaw("Current: ",T00172_A324DocArqObservacao[0]);
               }
               if ( Z644DocArqArmExterno != T00172_A644DocArqArmExterno[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqArmExterno");
                  GXUtil.WriteLogRaw("Old: ",Z644DocArqArmExterno);
                  GXUtil.WriteLogRaw("Current: ",T00172_A644DocArqArmExterno[0]);
               }
               if ( StringUtil.StrCmp(Z645DocArqArmExternoPath, T00172_A645DocArqArmExternoPath[0]) != 0 )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocArqArmExternoPath");
                  GXUtil.WriteLogRaw("Old: ",Z645DocArqArmExternoPath);
                  GXUtil.WriteLogRaw("Current: ",T00172_A645DocArqArmExternoPath[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento_arquivo"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
         /* Using cursor T001710 */
         pr_default.execute(8, new Object[] {A289DocID});
         if ( (pr_default.getStatus(8) == 103) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento"}), "RecordIsLocked", 1, "");
            AnyError = 1;
            return  ;
         }
         if ( ! IsIns( ) )
         {
            if ( false || ( Z325DocVersao != T001710_A325DocVersao[0] ) || ( Z326DocVersaoIDPai != T001710_A326DocVersaoIDPai[0] ) )
            {
               if ( Z325DocVersao != T001710_A325DocVersao[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocVersao");
                  GXUtil.WriteLogRaw("Old: ",Z325DocVersao);
                  GXUtil.WriteLogRaw("Current: ",T001710_A325DocVersao[0]);
               }
               if ( Z326DocVersaoIDPai != T001710_A326DocVersaoIDPai[0] )
               {
                  GXUtil.WriteLog("core.documentoarquivo:[seudo value changed for attri]"+"DocVersaoIDPai");
                  GXUtil.WriteLogRaw("Old: ",Z326DocVersaoIDPai);
                  GXUtil.WriteLogRaw("Current: ",T001710_A326DocVersaoIDPai[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_documento"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1734( )
      {
         if ( ! IsAuthorized("documento_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1734( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1734( 0) ;
            CheckOptimisticConcurrency1734( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1734( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1734( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001711 */
                     A323DocArqConteudoExtensao = A321DocArqConteudo_Filetype;
                     AssignAttri("", false, "A323DocArqConteudoExtensao", A323DocArqConteudoExtensao);
                     A322DocArqConteudoNome = A321DocArqConteudo_Filename;
                     AssignAttri("", false, "A322DocArqConteudoNome", A322DocArqConteudoNome);
                     pr_default.execute(9, new Object[] {A307DocArqSeq, A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n319DocArqDelDataHora, A319DocArqDelDataHora, n317DocArqDelData, A317DocArqDelData, n511DocArqDelHora, A511DocArqDelHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n509DocArqDelUsuNome, A509DocArqDelUsuNome, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, A316DocArqDel, n321DocArqConteudo, A321DocArqConteudo, n324DocArqObservacao, A324DocArqObservacao, A644DocArqArmExterno, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome, A289DocID});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(9) == 1) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, "");
                        AnyError = 1;
                     }
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11734( ) ;
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption170( ) ;
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
               Load1734( ) ;
            }
            EndLevel1734( ) ;
         }
         CloseExtendedTableCursors1734( ) ;
      }

      protected void Update1734( )
      {
         if ( ! IsAuthorized("documento_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1734( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1734( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1734( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1734( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001712 */
                     A323DocArqConteudoExtensao = A321DocArqConteudo_Filetype;
                     AssignAttri("", false, "A323DocArqConteudoExtensao", A323DocArqConteudoExtensao);
                     A322DocArqConteudoNome = A321DocArqConteudo_Filename;
                     AssignAttri("", false, "A322DocArqConteudoNome", A322DocArqConteudoNome);
                     pr_default.execute(10, new Object[] {A310DocArqInsDataHora, A308DocArqInsData, A309DocArqInsHora, n311DocArqInsUsuID, A311DocArqInsUsuID, n319DocArqDelDataHora, A319DocArqDelDataHora, n317DocArqDelData, A317DocArqDelData, n511DocArqDelHora, A511DocArqDelHora, n320DocArqDelUsuID, A320DocArqDelUsuID, n509DocArqDelUsuNome, A509DocArqDelUsuNome, n312DocArqUpdData, A312DocArqUpdData, n313DocArqUpdHora, A313DocArqUpdHora, n314DocArqUpdDataHora, A314DocArqUpdDataHora, n315DocArqUsuID, A315DocArqUsuID, A316DocArqDel, n324DocArqObservacao, A324DocArqObservacao, A644DocArqArmExterno, n645DocArqArmExternoPath, A645DocArqArmExternoPath, A323DocArqConteudoExtensao, A322DocArqConteudoNome, A289DocID, A307DocArqSeq});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_documento_arquivo"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1734( ) ;
                     if ( AnyError == 0 )
                     {
                        UpdateTablesN11734( ) ;
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
            EndLevel1734( ) ;
         }
         CloseExtendedTableCursors1734( ) ;
      }

      protected void DeferredUpdate1734( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T001713 */
            pr_default.execute(11, new Object[] {n321DocArqConteudo, A321DocArqConteudo, A289DocID, A307DocArqSeq});
            pr_default.close(11);
            pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("documento_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1734( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1734( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1734( ) ;
            AfterConfirm1734( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1734( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001714 */
                  pr_default.execute(12, new Object[] {A289DocID, A307DocArqSeq});
                  pr_default.close(12);
                  pr_default.SmartCacheProvider.SetUpdated("tb_documento_arquivo");
                  if ( AnyError == 0 )
                  {
                     UpdateTablesN11734( ) ;
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
         sMode34 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1734( ) ;
         Gx_mode = sMode34;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1734( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001715 */
            pr_default.execute(13, new Object[] {A289DocID});
            Z325DocVersao = T001715_A325DocVersao[0];
            Z326DocVersaoIDPai = T001715_A326DocVersaoIDPai[0];
            A306DocUltArqSeq = T001715_A306DocUltArqSeq[0];
            n306DocUltArqSeq = T001715_n306DocUltArqSeq[0];
            A325DocVersao = T001715_A325DocVersao[0];
            A326DocVersaoIDPai = T001715_A326DocVersaoIDPai[0];
            n326DocVersaoIDPai = T001715_n326DocVersaoIDPai[0];
            O306DocUltArqSeq = A306DocUltArqSeq;
            n306DocUltArqSeq = false;
            AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
            pr_default.close(13);
            if ( IsIns( )  )
            {
               A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
               n306DocUltArqSeq = false;
               AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
            }
         }
      }

      protected void UpdateTablesN11734( )
      {
         /* Using cursor T001716 */
         pr_default.execute(14, new Object[] {n306DocUltArqSeq, A306DocUltArqSeq, A289DocID});
         pr_default.close(14);
         pr_default.SmartCacheProvider.SetUpdated("tb_documento");
      }

      protected void EndLevel1734( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         pr_default.close(8);
         if ( AnyError == 0 )
         {
            BeforeComplete1734( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.documentoarquivo",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues170( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.documentoarquivo",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1734( )
      {
         /* Scan By routine */
         /* Using cursor T001717 */
         pr_default.execute(15);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound34 = 1;
            A289DocID = T001717_A289DocID[0];
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            A307DocArqSeq = T001717_A307DocArqSeq[0];
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1734( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound34 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound34 = 1;
            A289DocID = T001717_A289DocID[0];
            AssignAttri("", false, "A289DocID", A289DocID.ToString());
            A307DocArqSeq = T001717_A307DocArqSeq[0];
            AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
         }
      }

      protected void ScanEnd1734( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm1734( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1734( )
      {
         /* Before Insert Rules */
         A310DocArqInsDataHora = DateTimeUtil.NowMS( context);
         AssignAttri("", false, "A310DocArqInsDataHora", context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A311DocArqInsUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
         n311DocArqInsUsuID = false;
         AssignAttri("", false, "A311DocArqInsUsuID", A311DocArqInsUsuID);
         A308DocArqInsData = DateTimeUtil.ResetTime( A310DocArqInsDataHora);
         AssignAttri("", false, "A308DocArqInsData", context.localUtil.Format(A308DocArqInsData, "99/99/99"));
         A309DocArqInsHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A310DocArqInsDataHora));
         AssignAttri("", false, "A309DocArqInsHora", context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " "));
      }

      protected void BeforeUpdate1734( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A319DocArqDelDataHora = DateTimeUtil.NowMS( context);
            n319DocArqDelDataHora = false;
            AssignAttri("", false, "A319DocArqDelDataHora", context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A320DocArqDelUsuID = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n320DocArqDelUsuID = false;
            AssignAttri("", false, "A320DocArqDelUsuID", A320DocArqDelUsuID);
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A509DocArqDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n509DocArqDelUsuNome = false;
            AssignAttri("", false, "A509DocArqDelUsuNome", A509DocArqDelUsuNome);
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A317DocArqDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A319DocArqDelDataHora) ) ;
            n317DocArqDelData = false;
            AssignAttri("", false, "A317DocArqDelData", context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A316DocArqDel && ( O316DocArqDel != A316DocArqDel ) )
         {
            A511DocArqDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A319DocArqDelDataHora));
            n511DocArqDelHora = false;
            AssignAttri("", false, "A511DocArqDelHora", context.localUtil.TToC( A511DocArqDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1734( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
      }

      protected void BeforeComplete1734( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1734( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1734( )
      {
         edtDocArqConteudoNome_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoNome_Enabled), 5, 0), true);
         edtDocArqConteudoExtensao_Enabled = 0;
         AssignProp("", false, edtDocArqConteudoExtensao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqConteudoExtensao_Enabled), 5, 0), true);
         edtDocArqObservacao_Enabled = 0;
         AssignProp("", false, edtDocArqObservacao_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqObservacao_Enabled), 5, 0), true);
         edtDocID_Enabled = 0;
         AssignProp("", false, edtDocID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocID_Enabled), 5, 0), true);
         edtDocArqSeq_Enabled = 0;
         AssignProp("", false, edtDocArqSeq_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtDocArqSeq_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1734( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues170( )
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
         GXEncryptionTmp = "core.documentoarquivo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DocID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV24DocArqSeq,4,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.documentoarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"DocumentoArquivo");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV27Pgmname, "")));
         forbiddenHiddens.Add("DocArqUpdData", context.localUtil.Format(A312DocArqUpdData, "99/99/99"));
         forbiddenHiddens.Add("DocArqUpdHora", context.localUtil.Format( A313DocArqUpdHora, "99:99"));
         forbiddenHiddens.Add("DocArqUpdDataHora", context.localUtil.Format( A314DocArqUpdDataHora, "99/99/9999 99:99:99.999"));
         forbiddenHiddens.Add("DocArqUsuID", StringUtil.RTrim( context.localUtil.Format( A315DocArqUsuID, "")));
         forbiddenHiddens.Add("DocArqDel", StringUtil.BoolToStr( A316DocArqDel));
         forbiddenHiddens.Add("DocArqArmExterno", StringUtil.BoolToStr( A644DocArqArmExterno));
         forbiddenHiddens.Add("DocArqArmExternoPath", StringUtil.RTrim( context.localUtil.Format( A645DocArqArmExternoPath, "")));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\documentoarquivo:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z289DocID", Z289DocID.ToString());
         GxWebStd.gx_hidden_field( context, "Z307DocArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z307DocArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z310DocArqInsDataHora", context.localUtil.TToC( Z310DocArqInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z308DocArqInsData", context.localUtil.DToC( Z308DocArqInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z309DocArqInsHora", context.localUtil.TToC( Z309DocArqInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z311DocArqInsUsuID", StringUtil.RTrim( Z311DocArqInsUsuID));
         GxWebStd.gx_hidden_field( context, "Z319DocArqDelDataHora", context.localUtil.TToC( Z319DocArqDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z317DocArqDelData", context.localUtil.TToC( Z317DocArqDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z511DocArqDelHora", context.localUtil.TToC( Z511DocArqDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z320DocArqDelUsuID", StringUtil.RTrim( Z320DocArqDelUsuID));
         GxWebStd.gx_hidden_field( context, "Z509DocArqDelUsuNome", Z509DocArqDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z312DocArqUpdData", context.localUtil.DToC( Z312DocArqUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "Z313DocArqUpdHora", context.localUtil.TToC( Z313DocArqUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z314DocArqUpdDataHora", context.localUtil.TToC( Z314DocArqUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z315DocArqUsuID", StringUtil.RTrim( Z315DocArqUsuID));
         GxWebStd.gx_boolean_hidden_field( context, "Z316DocArqDel", Z316DocArqDel);
         GxWebStd.gx_hidden_field( context, "Z324DocArqObservacao", Z324DocArqObservacao);
         GxWebStd.gx_boolean_hidden_field( context, "Z644DocArqArmExterno", Z644DocArqArmExterno);
         GxWebStd.gx_hidden_field( context, "Z645DocArqArmExternoPath", Z645DocArqArmExternoPath);
         GxWebStd.gx_hidden_field( context, "Z325DocVersao", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z325DocVersao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z326DocVersaoIDPai", Z326DocVersaoIDPai.ToString());
         GxWebStd.gx_boolean_hidden_field( context, "O316DocArqDel", O316DocArqDel);
         GxWebStd.gx_hidden_field( context, "O306DocUltArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O306DocUltArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_Mode", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "vDOCID", AV7DocID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCID", GetSecureSignedToken( "", AV7DocID, context));
         GxWebStd.gx_hidden_field( context, "vDOCARQSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV24DocArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vDOCARQSEQ", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV24DocArqSeq), "ZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "DOCULTARQSEQ", StringUtil.LTrim( StringUtil.NToC( (decimal)(A306DocUltArqSeq), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCARQINSDATAHORA", context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQINSDATA", context.localUtil.DToC( A308DocArqInsData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "DOCARQINSHORA", context.localUtil.TToC( A309DocArqInsHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQINSUSUID", StringUtil.RTrim( A311DocArqInsUsuID));
         GxWebStd.gx_boolean_hidden_field( context, "DOCARQDEL", A316DocArqDel);
         GxWebStd.gx_hidden_field( context, "DOCARQDELDATAHORA", context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQDELDATA", context.localUtil.TToC( A317DocArqDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQDELHORA", context.localUtil.TToC( A511DocArqDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQDELUSUID", StringUtil.RTrim( A320DocArqDelUsuID));
         GxWebStd.gx_hidden_field( context, "DOCARQDELUSUNOME", A509DocArqDelUsuNome);
         GxWebStd.gx_boolean_hidden_field( context, "DOCARQARMEXTERNO", A644DocArqArmExterno);
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV25AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV25AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "DOCARQUPDDATA", context.localUtil.DToC( A312DocArqUpdData, 0, "/"));
         GxWebStd.gx_hidden_field( context, "DOCARQUPDHORA", context.localUtil.TToC( A313DocArqUpdHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQUPDDATAHORA", context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "DOCARQUSUID", StringUtil.RTrim( A315DocArqUsuID));
         GxWebStd.gx_hidden_field( context, "DOCARQCONTEUDO", A321DocArqConteudo);
         GxWebStd.gx_hidden_field( context, "DOCARQARMEXTERNOPATH", A645DocArqArmExternoPath);
         GxWebStd.gx_hidden_field( context, "DOCVERSAO", StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "DOCVERSAOIDPAI", A326DocVersaoIDPai.ToString());
         GxWebStd.gx_hidden_field( context, "vPGMNAME", StringUtil.RTrim( AV27Pgmname));
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
         GXEncryptionTmp = "core.documentoarquivo.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7DocID.ToString()) + "," + UrlEncode(StringUtil.LTrimStr(AV24DocArqSeq,4,0));
         return formatLink("core.documentoarquivo.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.DocumentoArquivo" ;
      }

      public override string GetPgmdesc( )
      {
         return "Arquivo do Documento" ;
      }

      protected void InitializeNonKey1734( )
      {
         AV25AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A306DocUltArqSeq = 0;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A310DocArqInsDataHora", context.localUtil.TToC( A310DocArqInsDataHora, 10, 12, 0, 3, "/", ":", " "));
         A308DocArqInsData = DateTime.MinValue;
         AssignAttri("", false, "A308DocArqInsData", context.localUtil.Format(A308DocArqInsData, "99/99/99"));
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A309DocArqInsHora", context.localUtil.TToC( A309DocArqInsHora, 0, 5, 0, 3, "/", ":", " "));
         A311DocArqInsUsuID = "";
         n311DocArqInsUsuID = false;
         AssignAttri("", false, "A311DocArqInsUsuID", A311DocArqInsUsuID);
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         n319DocArqDelDataHora = false;
         AssignAttri("", false, "A319DocArqDelDataHora", context.localUtil.TToC( A319DocArqDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         n317DocArqDelData = false;
         AssignAttri("", false, "A317DocArqDelData", context.localUtil.TToC( A317DocArqDelData, 10, 5, 0, 3, "/", ":", " "));
         A511DocArqDelHora = (DateTime)(DateTime.MinValue);
         n511DocArqDelHora = false;
         AssignAttri("", false, "A511DocArqDelHora", context.localUtil.TToC( A511DocArqDelHora, 0, 5, 0, 3, "/", ":", " "));
         A320DocArqDelUsuID = "";
         n320DocArqDelUsuID = false;
         AssignAttri("", false, "A320DocArqDelUsuID", A320DocArqDelUsuID);
         A509DocArqDelUsuNome = "";
         n509DocArqDelUsuNome = false;
         AssignAttri("", false, "A509DocArqDelUsuNome", A509DocArqDelUsuNome);
         A325DocVersao = 0;
         AssignAttri("", false, "A325DocVersao", StringUtil.LTrimStr( (decimal)(A325DocVersao), 4, 0));
         A326DocVersaoIDPai = Guid.Empty;
         n326DocVersaoIDPai = false;
         AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         A312DocArqUpdData = DateTime.MinValue;
         n312DocArqUpdData = false;
         AssignAttri("", false, "A312DocArqUpdData", context.localUtil.Format(A312DocArqUpdData, "99/99/99"));
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         n313DocArqUpdHora = false;
         AssignAttri("", false, "A313DocArqUpdHora", context.localUtil.TToC( A313DocArqUpdHora, 0, 5, 0, 3, "/", ":", " "));
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         n314DocArqUpdDataHora = false;
         AssignAttri("", false, "A314DocArqUpdDataHora", context.localUtil.TToC( A314DocArqUpdDataHora, 10, 12, 0, 3, "/", ":", " "));
         A315DocArqUsuID = "";
         n315DocArqUsuID = false;
         AssignAttri("", false, "A315DocArqUsuID", A315DocArqUsuID);
         A321DocArqConteudo = "";
         n321DocArqConteudo = false;
         AssignAttri("", false, "A321DocArqConteudo", A321DocArqConteudo);
         A324DocArqObservacao = "";
         n324DocArqObservacao = false;
         AssignAttri("", false, "A324DocArqObservacao", A324DocArqObservacao);
         n324DocArqObservacao = (String.IsNullOrEmpty(StringUtil.RTrim( A324DocArqObservacao)) ? true : false);
         A645DocArqArmExternoPath = "";
         n645DocArqArmExternoPath = false;
         AssignAttri("", false, "A645DocArqArmExternoPath", A645DocArqArmExternoPath);
         A323DocArqConteudoExtensao = "";
         AssignAttri("", false, "A323DocArqConteudoExtensao", A323DocArqConteudoExtensao);
         A322DocArqConteudoNome = "";
         AssignAttri("", false, "A322DocArqConteudoNome", A322DocArqConteudoNome);
         A316DocArqDel = false;
         AssignAttri("", false, "A316DocArqDel", A316DocArqDel);
         A644DocArqArmExterno = false;
         AssignAttri("", false, "A644DocArqArmExterno", A644DocArqArmExterno);
         O316DocArqDel = A316DocArqDel;
         AssignAttri("", false, "A316DocArqDel", A316DocArqDel);
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrimStr( (decimal)(A306DocUltArqSeq), 4, 0));
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z511DocArqDelHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         Z509DocArqDelUsuNome = "";
         Z312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         Z316DocArqDel = false;
         Z324DocArqObservacao = "";
         Z644DocArqArmExterno = false;
         Z645DocArqArmExternoPath = "";
         Z325DocVersao = 0;
         Z326DocVersaoIDPai = Guid.Empty;
      }

      protected void InitAll1734( )
      {
         A289DocID = Guid.Empty;
         AssignAttri("", false, "A289DocID", A289DocID.ToString());
         A307DocArqSeq = 0;
         AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrimStr( (decimal)(A307DocArqSeq), 4, 0));
         InitializeNonKey1734( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A644DocArqArmExterno = i644DocArqArmExterno;
         AssignAttri("", false, "A644DocArqArmExterno", A644DocArqArmExterno);
         A316DocArqDel = i316DocArqDel;
         AssignAttri("", false, "A316DocArqDel", A316DocArqDel);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382816128", true, true);
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
         context.AddJavascriptSource("core/documentoarquivo.js", "?202382816131", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtDocArqConteudoNome_Internalname = "DOCARQCONTEUDONOME";
         edtDocArqConteudoExtensao_Internalname = "DOCARQCONTEUDOEXTENSAO";
         edtDocArqObservacao_Internalname = "DOCARQOBSERVACAO";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtDocID_Internalname = "DOCID";
         edtDocArqSeq_Internalname = "DOCARQSEQ";
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
         Form.Caption = "Arquivo do Documento";
         edtDocArqSeq_Jsonclick = "";
         edtDocArqSeq_Enabled = 1;
         edtDocArqSeq_Visible = 1;
         edtDocID_Jsonclick = "";
         edtDocID_Enabled = 1;
         edtDocID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtDocArqObservacao_Enabled = 1;
         edtDocArqConteudoExtensao_Jsonclick = "";
         edtDocArqConteudoExtensao_Enabled = 0;
         edtDocArqConteudoNome_Enabled = 0;
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

      protected void XC_22_1734( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ,
                                 Guid A289DocID ,
                                 short A307DocArqSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV25AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_23_1734( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ,
                                 Guid A289DocID ,
                                 short A307DocArqSeq ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "Y", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV25AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_24_1734( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ,
                                 Guid A289DocID ,
                                 short A307DocArqSeq )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV25AuditingObject.ToXml(false, true, "", "")))+"\"") ;
         AddString( "]") ;
         if ( true )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
      }

      protected void XC_25_1734( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ,
                                 Guid A289DocID ,
                                 short A307DocArqSeq )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadauditdocumentoarquivo(context ).execute(  "N", ref  AV25AuditingObject,  A289DocID,  A307DocArqSeq,  Gx_mode) ;
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.EncodeString( AV25AuditingObject.ToXml(false, true, "", "")))+"\"") ;
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

      public void Valid_Docid( )
      {
         n306DocUltArqSeq = false;
         n326DocVersaoIDPai = false;
         /* Using cursor T001715 */
         pr_default.execute(13, new Object[] {A289DocID});
         Z325DocVersao = T001715_A325DocVersao[0];
         Z326DocVersaoIDPai = T001715_A326DocVersaoIDPai[0];
         if ( (pr_default.getStatus(13) == 101) )
         {
            GX_msglist.addItem("Não existe ''.", "ForeignKeyNotFound", 1, "DOCID");
            AnyError = 1;
            GX_FocusControl = edtDocID_Internalname;
         }
         A306DocUltArqSeq = T001715_A306DocUltArqSeq[0];
         n306DocUltArqSeq = T001715_n306DocUltArqSeq[0];
         A325DocVersao = T001715_A325DocVersao[0];
         A326DocVersaoIDPai = T001715_A326DocVersaoIDPai[0];
         n326DocVersaoIDPai = T001715_n326DocVersaoIDPai[0];
         O306DocUltArqSeq = A306DocUltArqSeq;
         n306DocUltArqSeq = false;
         pr_default.close(13);
         if ( IsIns( )  )
         {
            A306DocUltArqSeq = (short)(O306DocUltArqSeq+1);
            n306DocUltArqSeq = false;
         }
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "O306DocUltArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(O306DocUltArqSeq), 4, 0, ",", "")));
         AssignAttri("", false, "A306DocUltArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A306DocUltArqSeq), 4, 0, ".", "")));
         AssignAttri("", false, "A325DocVersao", StringUtil.LTrim( StringUtil.NToC( (decimal)(A325DocVersao), 4, 0, ".", "")));
         AssignAttri("", false, "A326DocVersaoIDPai", A326DocVersaoIDPai.ToString());
         AssignAttri("", false, "A307DocArqSeq", StringUtil.LTrim( StringUtil.NToC( (decimal)(A307DocArqSeq), 4, 0, ".", "")));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV24DocArqSeq',fld:'vDOCARQSEQ',pic:'ZZZ9',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7DocID',fld:'vDOCID',pic:'',hsh:true},{av:'AV24DocArqSeq',fld:'vDOCARQSEQ',pic:'ZZZ9',hsh:true},{av:'AV27Pgmname',fld:'vPGMNAME',pic:''},{av:'A312DocArqUpdData',fld:'DOCARQUPDDATA',pic:''},{av:'A313DocArqUpdHora',fld:'DOCARQUPDHORA',pic:'99:99'},{av:'A314DocArqUpdDataHora',fld:'DOCARQUPDDATAHORA',pic:'99/99/9999 99:99:99.999'},{av:'A315DocArqUsuID',fld:'DOCARQUSUID',pic:''},{av:'A316DocArqDel',fld:'DOCARQDEL',pic:''},{av:'A644DocArqArmExterno',fld:'DOCARQARMEXTERNO',pic:''},{av:'A645DocArqArmExternoPath',fld:'DOCARQARMEXTERNOPATH',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12172',iparms:[{av:'AV25AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV27Pgmname',fld:'vPGMNAME',pic:''}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_DOCID","{handler:'Valid_Docid',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'O306DocUltArqSeq'},{av:'A289DocID',fld:'DOCID',pic:''},{av:'A306DocUltArqSeq',fld:'DOCULTARQSEQ',pic:'ZZZ9'},{av:'AV24DocArqSeq',fld:'vDOCARQSEQ',pic:'ZZZ9',hsh:true},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'A325DocVersao',fld:'DOCVERSAO',pic:'ZZZ9'},{av:'A326DocVersaoIDPai',fld:'DOCVERSAOIDPAI',pic:''},{av:'A307DocArqSeq',fld:'DOCARQSEQ',pic:'ZZZ9'}]");
         setEventMetadata("VALID_DOCID",",oparms:[{av:'O306DocUltArqSeq'},{av:'A306DocUltArqSeq',fld:'DOCULTARQSEQ',pic:'ZZZ9'},{av:'A325DocVersao',fld:'DOCVERSAO',pic:'ZZZ9'},{av:'A326DocVersaoIDPai',fld:'DOCVERSAOIDPAI',pic:''},{av:'A307DocArqSeq',fld:'DOCARQSEQ',pic:'ZZZ9'}]}");
         setEventMetadata("VALID_DOCARQSEQ","{handler:'Valid_Docarqseq',iparms:[]");
         setEventMetadata("VALID_DOCARQSEQ",",oparms:[]}");
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
         pr_default.close(13);
      }

      public override void initialize( )
      {
         sPrefix = "";
         wcpOGx_mode = "";
         wcpOAV7DocID = Guid.Empty;
         Z289DocID = Guid.Empty;
         Z310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         Z308DocArqInsData = DateTime.MinValue;
         Z309DocArqInsHora = (DateTime)(DateTime.MinValue);
         Z311DocArqInsUsuID = "";
         Z319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         Z317DocArqDelData = (DateTime)(DateTime.MinValue);
         Z511DocArqDelHora = (DateTime)(DateTime.MinValue);
         Z320DocArqDelUsuID = "";
         Z509DocArqDelUsuNome = "";
         Z312DocArqUpdData = DateTime.MinValue;
         Z313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         Z314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         Z315DocArqUsuID = "";
         Z324DocArqObservacao = "";
         Z645DocArqArmExternoPath = "";
         Z326DocVersaoIDPai = Guid.Empty;
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A289DocID = Guid.Empty;
         GXKey = "";
         GXDecQS = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         ClassString = "";
         StyleString = "";
         ucDvpanel_tableattributes = new GXUserControl();
         A322DocArqConteudoNome = "";
         A323DocArqConteudoExtensao = "";
         TempTags = "";
         A324DocArqObservacao = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A311DocArqInsUsuID = "";
         A319DocArqDelDataHora = (DateTime)(DateTime.MinValue);
         A317DocArqDelData = (DateTime)(DateTime.MinValue);
         A511DocArqDelHora = (DateTime)(DateTime.MinValue);
         A320DocArqDelUsuID = "";
         A509DocArqDelUsuNome = "";
         A312DocArqUpdData = DateTime.MinValue;
         A313DocArqUpdHora = (DateTime)(DateTime.MinValue);
         A314DocArqUpdDataHora = (DateTime)(DateTime.MinValue);
         A315DocArqUsuID = "";
         A645DocArqArmExternoPath = "";
         A310DocArqInsDataHora = (DateTime)(DateTime.MinValue);
         A308DocArqInsData = DateTime.MinValue;
         A309DocArqInsHora = (DateTime)(DateTime.MinValue);
         A326DocVersaoIDPai = Guid.Empty;
         AV25AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A321DocArqConteudo = "";
         AV27Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode34 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         Z321DocArqConteudo = "";
         Z323DocArqConteudoExtensao = "";
         Z322DocArqConteudoNome = "";
         T00175_A306DocUltArqSeq = new short[1] ;
         T00175_n306DocUltArqSeq = new bool[] {false} ;
         T00175_A325DocVersao = new short[1] ;
         T00175_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T00175_n326DocVersaoIDPai = new bool[] {false} ;
         T00176_A307DocArqSeq = new short[1] ;
         T00176_A306DocUltArqSeq = new short[1] ;
         T00176_n306DocUltArqSeq = new bool[] {false} ;
         T00176_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00176_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         T00176_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         T00176_A311DocArqInsUsuID = new string[] {""} ;
         T00176_n311DocArqInsUsuID = new bool[] {false} ;
         T00176_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00176_n319DocArqDelDataHora = new bool[] {false} ;
         T00176_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         T00176_n317DocArqDelData = new bool[] {false} ;
         T00176_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         T00176_n511DocArqDelHora = new bool[] {false} ;
         T00176_A320DocArqDelUsuID = new string[] {""} ;
         T00176_n320DocArqDelUsuID = new bool[] {false} ;
         T00176_A509DocArqDelUsuNome = new string[] {""} ;
         T00176_n509DocArqDelUsuNome = new bool[] {false} ;
         T00176_A325DocVersao = new short[1] ;
         T00176_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         T00176_n312DocArqUpdData = new bool[] {false} ;
         T00176_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00176_n313DocArqUpdHora = new bool[] {false} ;
         T00176_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00176_n314DocArqUpdDataHora = new bool[] {false} ;
         T00176_A315DocArqUsuID = new string[] {""} ;
         T00176_n315DocArqUsuID = new bool[] {false} ;
         T00176_A316DocArqDel = new bool[] {false} ;
         T00176_A324DocArqObservacao = new string[] {""} ;
         T00176_n324DocArqObservacao = new bool[] {false} ;
         T00176_A644DocArqArmExterno = new bool[] {false} ;
         T00176_A645DocArqArmExternoPath = new string[] {""} ;
         T00176_n645DocArqArmExternoPath = new bool[] {false} ;
         T00176_A323DocArqConteudoExtensao = new string[] {""} ;
         T00176_A322DocArqConteudoNome = new string[] {""} ;
         T00176_A289DocID = new Guid[] {Guid.Empty} ;
         T00176_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T00176_n326DocVersaoIDPai = new bool[] {false} ;
         T00176_A321DocArqConteudo = new string[] {""} ;
         T00176_n321DocArqConteudo = new bool[] {false} ;
         A321DocArqConteudo_Filetype = "";
         A321DocArqConteudo_Filename = "";
         T00177_A289DocID = new Guid[] {Guid.Empty} ;
         T00177_A307DocArqSeq = new short[1] ;
         T00173_A307DocArqSeq = new short[1] ;
         T00173_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00173_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         T00173_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         T00173_A311DocArqInsUsuID = new string[] {""} ;
         T00173_n311DocArqInsUsuID = new bool[] {false} ;
         T00173_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00173_n319DocArqDelDataHora = new bool[] {false} ;
         T00173_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         T00173_n317DocArqDelData = new bool[] {false} ;
         T00173_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         T00173_n511DocArqDelHora = new bool[] {false} ;
         T00173_A320DocArqDelUsuID = new string[] {""} ;
         T00173_n320DocArqDelUsuID = new bool[] {false} ;
         T00173_A509DocArqDelUsuNome = new string[] {""} ;
         T00173_n509DocArqDelUsuNome = new bool[] {false} ;
         T00173_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         T00173_n312DocArqUpdData = new bool[] {false} ;
         T00173_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00173_n313DocArqUpdHora = new bool[] {false} ;
         T00173_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00173_n314DocArqUpdDataHora = new bool[] {false} ;
         T00173_A315DocArqUsuID = new string[] {""} ;
         T00173_n315DocArqUsuID = new bool[] {false} ;
         T00173_A316DocArqDel = new bool[] {false} ;
         T00173_A324DocArqObservacao = new string[] {""} ;
         T00173_n324DocArqObservacao = new bool[] {false} ;
         T00173_A644DocArqArmExterno = new bool[] {false} ;
         T00173_A645DocArqArmExternoPath = new string[] {""} ;
         T00173_n645DocArqArmExternoPath = new bool[] {false} ;
         T00173_A323DocArqConteudoExtensao = new string[] {""} ;
         T00173_A322DocArqConteudoNome = new string[] {""} ;
         T00173_A289DocID = new Guid[] {Guid.Empty} ;
         T00173_A321DocArqConteudo = new string[] {""} ;
         T00173_n321DocArqConteudo = new bool[] {false} ;
         T00178_A289DocID = new Guid[] {Guid.Empty} ;
         T00178_A307DocArqSeq = new short[1] ;
         T00179_A289DocID = new Guid[] {Guid.Empty} ;
         T00179_A307DocArqSeq = new short[1] ;
         T00172_A307DocArqSeq = new short[1] ;
         T00172_A310DocArqInsDataHora = new DateTime[] {DateTime.MinValue} ;
         T00172_A308DocArqInsData = new DateTime[] {DateTime.MinValue} ;
         T00172_A309DocArqInsHora = new DateTime[] {DateTime.MinValue} ;
         T00172_A311DocArqInsUsuID = new string[] {""} ;
         T00172_n311DocArqInsUsuID = new bool[] {false} ;
         T00172_A319DocArqDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00172_n319DocArqDelDataHora = new bool[] {false} ;
         T00172_A317DocArqDelData = new DateTime[] {DateTime.MinValue} ;
         T00172_n317DocArqDelData = new bool[] {false} ;
         T00172_A511DocArqDelHora = new DateTime[] {DateTime.MinValue} ;
         T00172_n511DocArqDelHora = new bool[] {false} ;
         T00172_A320DocArqDelUsuID = new string[] {""} ;
         T00172_n320DocArqDelUsuID = new bool[] {false} ;
         T00172_A509DocArqDelUsuNome = new string[] {""} ;
         T00172_n509DocArqDelUsuNome = new bool[] {false} ;
         T00172_A312DocArqUpdData = new DateTime[] {DateTime.MinValue} ;
         T00172_n312DocArqUpdData = new bool[] {false} ;
         T00172_A313DocArqUpdHora = new DateTime[] {DateTime.MinValue} ;
         T00172_n313DocArqUpdHora = new bool[] {false} ;
         T00172_A314DocArqUpdDataHora = new DateTime[] {DateTime.MinValue} ;
         T00172_n314DocArqUpdDataHora = new bool[] {false} ;
         T00172_A315DocArqUsuID = new string[] {""} ;
         T00172_n315DocArqUsuID = new bool[] {false} ;
         T00172_A316DocArqDel = new bool[] {false} ;
         T00172_A324DocArqObservacao = new string[] {""} ;
         T00172_n324DocArqObservacao = new bool[] {false} ;
         T00172_A644DocArqArmExterno = new bool[] {false} ;
         T00172_A645DocArqArmExternoPath = new string[] {""} ;
         T00172_n645DocArqArmExternoPath = new bool[] {false} ;
         T00172_A323DocArqConteudoExtensao = new string[] {""} ;
         T00172_A322DocArqConteudoNome = new string[] {""} ;
         T00172_A289DocID = new Guid[] {Guid.Empty} ;
         T00172_A321DocArqConteudo = new string[] {""} ;
         T00172_n321DocArqConteudo = new bool[] {false} ;
         T001710_A306DocUltArqSeq = new short[1] ;
         T001710_n306DocUltArqSeq = new bool[] {false} ;
         T001710_A325DocVersao = new short[1] ;
         T001710_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T001710_n326DocVersaoIDPai = new bool[] {false} ;
         T001715_A306DocUltArqSeq = new short[1] ;
         T001715_n306DocUltArqSeq = new bool[] {false} ;
         T001715_A325DocVersao = new short[1] ;
         T001715_A326DocVersaoIDPai = new Guid[] {Guid.Empty} ;
         T001715_n326DocVersaoIDPai = new bool[] {false} ;
         T001717_A289DocID = new Guid[] {Guid.Empty} ;
         T001717_A307DocArqSeq = new short[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivo__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.documentoarquivo__default(),
            new Object[][] {
                new Object[] {
               T00172_A307DocArqSeq, T00172_A310DocArqInsDataHora, T00172_A308DocArqInsData, T00172_A309DocArqInsHora, T00172_A311DocArqInsUsuID, T00172_n311DocArqInsUsuID, T00172_A319DocArqDelDataHora, T00172_n319DocArqDelDataHora, T00172_A317DocArqDelData, T00172_n317DocArqDelData,
               T00172_A511DocArqDelHora, T00172_n511DocArqDelHora, T00172_A320DocArqDelUsuID, T00172_n320DocArqDelUsuID, T00172_A509DocArqDelUsuNome, T00172_n509DocArqDelUsuNome, T00172_A312DocArqUpdData, T00172_n312DocArqUpdData, T00172_A313DocArqUpdHora, T00172_n313DocArqUpdHora,
               T00172_A314DocArqUpdDataHora, T00172_n314DocArqUpdDataHora, T00172_A315DocArqUsuID, T00172_n315DocArqUsuID, T00172_A316DocArqDel, T00172_A324DocArqObservacao, T00172_n324DocArqObservacao, T00172_A644DocArqArmExterno, T00172_A645DocArqArmExternoPath, T00172_n645DocArqArmExternoPath,
               T00172_A323DocArqConteudoExtensao, T00172_A322DocArqConteudoNome, T00172_A289DocID, T00172_A321DocArqConteudo, T00172_n321DocArqConteudo
               }
               , new Object[] {
               T00173_A307DocArqSeq, T00173_A310DocArqInsDataHora, T00173_A308DocArqInsData, T00173_A309DocArqInsHora, T00173_A311DocArqInsUsuID, T00173_n311DocArqInsUsuID, T00173_A319DocArqDelDataHora, T00173_n319DocArqDelDataHora, T00173_A317DocArqDelData, T00173_n317DocArqDelData,
               T00173_A511DocArqDelHora, T00173_n511DocArqDelHora, T00173_A320DocArqDelUsuID, T00173_n320DocArqDelUsuID, T00173_A509DocArqDelUsuNome, T00173_n509DocArqDelUsuNome, T00173_A312DocArqUpdData, T00173_n312DocArqUpdData, T00173_A313DocArqUpdHora, T00173_n313DocArqUpdHora,
               T00173_A314DocArqUpdDataHora, T00173_n314DocArqUpdDataHora, T00173_A315DocArqUsuID, T00173_n315DocArqUsuID, T00173_A316DocArqDel, T00173_A324DocArqObservacao, T00173_n324DocArqObservacao, T00173_A644DocArqArmExterno, T00173_A645DocArqArmExternoPath, T00173_n645DocArqArmExternoPath,
               T00173_A323DocArqConteudoExtensao, T00173_A322DocArqConteudoNome, T00173_A289DocID, T00173_A321DocArqConteudo, T00173_n321DocArqConteudo
               }
               , new Object[] {
               T00174_A306DocUltArqSeq, T00174_n306DocUltArqSeq, T00174_A325DocVersao, T00174_A326DocVersaoIDPai, T00174_n326DocVersaoIDPai
               }
               , new Object[] {
               T00175_A306DocUltArqSeq, T00175_n306DocUltArqSeq, T00175_A325DocVersao, T00175_A326DocVersaoIDPai, T00175_n326DocVersaoIDPai
               }
               , new Object[] {
               T00176_A307DocArqSeq, T00176_A306DocUltArqSeq, T00176_n306DocUltArqSeq, T00176_A310DocArqInsDataHora, T00176_A308DocArqInsData, T00176_A309DocArqInsHora, T00176_A311DocArqInsUsuID, T00176_n311DocArqInsUsuID, T00176_A319DocArqDelDataHora, T00176_n319DocArqDelDataHora,
               T00176_A317DocArqDelData, T00176_n317DocArqDelData, T00176_A511DocArqDelHora, T00176_n511DocArqDelHora, T00176_A320DocArqDelUsuID, T00176_n320DocArqDelUsuID, T00176_A509DocArqDelUsuNome, T00176_n509DocArqDelUsuNome, T00176_A325DocVersao, T00176_A312DocArqUpdData,
               T00176_n312DocArqUpdData, T00176_A313DocArqUpdHora, T00176_n313DocArqUpdHora, T00176_A314DocArqUpdDataHora, T00176_n314DocArqUpdDataHora, T00176_A315DocArqUsuID, T00176_n315DocArqUsuID, T00176_A316DocArqDel, T00176_A324DocArqObservacao, T00176_n324DocArqObservacao,
               T00176_A644DocArqArmExterno, T00176_A645DocArqArmExternoPath, T00176_n645DocArqArmExternoPath, T00176_A323DocArqConteudoExtensao, T00176_A322DocArqConteudoNome, T00176_A289DocID, T00176_A326DocVersaoIDPai, T00176_n326DocVersaoIDPai, T00176_A321DocArqConteudo, T00176_n321DocArqConteudo
               }
               , new Object[] {
               T00177_A289DocID, T00177_A307DocArqSeq
               }
               , new Object[] {
               T00178_A289DocID, T00178_A307DocArqSeq
               }
               , new Object[] {
               T00179_A289DocID, T00179_A307DocArqSeq
               }
               , new Object[] {
               T001710_A306DocUltArqSeq, T001710_n306DocUltArqSeq, T001710_A325DocVersao, T001710_A326DocVersaoIDPai, T001710_n326DocVersaoIDPai
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001715_A306DocUltArqSeq, T001715_n306DocUltArqSeq, T001715_A325DocVersao, T001715_A326DocVersaoIDPai, T001715_n326DocVersaoIDPai
               }
               , new Object[] {
               }
               , new Object[] {
               T001717_A289DocID, T001717_A307DocArqSeq
               }
            }
         );
         Z644DocArqArmExterno = false;
         A644DocArqArmExterno = false;
         i644DocArqArmExterno = false;
         Z316DocArqDel = false;
         O316DocArqDel = false;
         A316DocArqDel = false;
         i316DocArqDel = false;
         AV27Pgmname = "core.DocumentoArquivo";
      }

      private short wcpOAV24DocArqSeq ;
      private short Z307DocArqSeq ;
      private short Z325DocVersao ;
      private short O306DocUltArqSeq ;
      private short GxWebError ;
      private short AV24DocArqSeq ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A307DocArqSeq ;
      private short A325DocVersao ;
      private short A306DocUltArqSeq ;
      private short Gx_BScreen ;
      private short RcdFound34 ;
      private short GX_JID ;
      private short Z306DocUltArqSeq ;
      private short nIsDirty_34 ;
      private short gxajaxcallmode ;
      private short ZO306DocUltArqSeq ;
      private int trnEnded ;
      private int edtDocArqConteudoNome_Enabled ;
      private int edtDocArqConteudoExtensao_Enabled ;
      private int edtDocArqObservacao_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtDocID_Visible ;
      private int edtDocID_Enabled ;
      private int edtDocArqSeq_Visible ;
      private int edtDocArqSeq_Enabled ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z311DocArqInsUsuID ;
      private string Z320DocArqDelUsuID ;
      private string Z315DocArqUsuID ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtDocArqObservacao_Internalname ;
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
      private string edtDocArqConteudoNome_Internalname ;
      private string edtDocArqConteudoExtensao_Internalname ;
      private string edtDocArqConteudoExtensao_Jsonclick ;
      private string TempTags ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtDocID_Internalname ;
      private string edtDocID_Jsonclick ;
      private string edtDocArqSeq_Internalname ;
      private string edtDocArqSeq_Jsonclick ;
      private string A311DocArqInsUsuID ;
      private string A320DocArqDelUsuID ;
      private string A315DocArqUsuID ;
      private string AV27Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode34 ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string A321DocArqConteudo_Filetype ;
      private string A321DocArqConteudo_Filename ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXEncryptionTmp ;
      private DateTime Z310DocArqInsDataHora ;
      private DateTime Z309DocArqInsHora ;
      private DateTime Z319DocArqDelDataHora ;
      private DateTime Z317DocArqDelData ;
      private DateTime Z511DocArqDelHora ;
      private DateTime Z313DocArqUpdHora ;
      private DateTime Z314DocArqUpdDataHora ;
      private DateTime A319DocArqDelDataHora ;
      private DateTime A317DocArqDelData ;
      private DateTime A511DocArqDelHora ;
      private DateTime A313DocArqUpdHora ;
      private DateTime A314DocArqUpdDataHora ;
      private DateTime A310DocArqInsDataHora ;
      private DateTime A309DocArqInsHora ;
      private DateTime Z308DocArqInsData ;
      private DateTime Z312DocArqUpdData ;
      private DateTime A312DocArqUpdData ;
      private DateTime A308DocArqInsData ;
      private bool Z316DocArqDel ;
      private bool Z644DocArqArmExterno ;
      private bool O316DocArqDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool n311DocArqInsUsuID ;
      private bool n319DocArqDelDataHora ;
      private bool n317DocArqDelData ;
      private bool n511DocArqDelHora ;
      private bool n320DocArqDelUsuID ;
      private bool n509DocArqDelUsuNome ;
      private bool n312DocArqUpdData ;
      private bool n313DocArqUpdHora ;
      private bool n314DocArqUpdDataHora ;
      private bool n315DocArqUsuID ;
      private bool n324DocArqObservacao ;
      private bool n645DocArqArmExternoPath ;
      private bool A316DocArqDel ;
      private bool A644DocArqArmExterno ;
      private bool n326DocVersaoIDPai ;
      private bool n306DocUltArqSeq ;
      private bool n321DocArqConteudo ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i644DocArqArmExterno ;
      private bool i316DocArqDel ;
      private string Z509DocArqDelUsuNome ;
      private string Z324DocArqObservacao ;
      private string Z645DocArqArmExternoPath ;
      private string A322DocArqConteudoNome ;
      private string A323DocArqConteudoExtensao ;
      private string A324DocArqObservacao ;
      private string A509DocArqDelUsuNome ;
      private string A645DocArqArmExternoPath ;
      private string Z323DocArqConteudoExtensao ;
      private string Z322DocArqConteudoNome ;
      private Guid wcpOAV7DocID ;
      private Guid Z289DocID ;
      private Guid Z326DocVersaoIDPai ;
      private Guid A289DocID ;
      private Guid AV7DocID ;
      private Guid A326DocVersaoIDPai ;
      private string A321DocArqConteudo ;
      private string Z321DocArqConteudo ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private short[] T00175_A306DocUltArqSeq ;
      private bool[] T00175_n306DocUltArqSeq ;
      private short[] T00175_A325DocVersao ;
      private Guid[] T00175_A326DocVersaoIDPai ;
      private bool[] T00175_n326DocVersaoIDPai ;
      private short[] T00176_A307DocArqSeq ;
      private short[] T00176_A306DocUltArqSeq ;
      private bool[] T00176_n306DocUltArqSeq ;
      private DateTime[] T00176_A310DocArqInsDataHora ;
      private DateTime[] T00176_A308DocArqInsData ;
      private DateTime[] T00176_A309DocArqInsHora ;
      private string[] T00176_A311DocArqInsUsuID ;
      private bool[] T00176_n311DocArqInsUsuID ;
      private DateTime[] T00176_A319DocArqDelDataHora ;
      private bool[] T00176_n319DocArqDelDataHora ;
      private DateTime[] T00176_A317DocArqDelData ;
      private bool[] T00176_n317DocArqDelData ;
      private DateTime[] T00176_A511DocArqDelHora ;
      private bool[] T00176_n511DocArqDelHora ;
      private string[] T00176_A320DocArqDelUsuID ;
      private bool[] T00176_n320DocArqDelUsuID ;
      private string[] T00176_A509DocArqDelUsuNome ;
      private bool[] T00176_n509DocArqDelUsuNome ;
      private short[] T00176_A325DocVersao ;
      private DateTime[] T00176_A312DocArqUpdData ;
      private bool[] T00176_n312DocArqUpdData ;
      private DateTime[] T00176_A313DocArqUpdHora ;
      private bool[] T00176_n313DocArqUpdHora ;
      private DateTime[] T00176_A314DocArqUpdDataHora ;
      private bool[] T00176_n314DocArqUpdDataHora ;
      private string[] T00176_A315DocArqUsuID ;
      private bool[] T00176_n315DocArqUsuID ;
      private bool[] T00176_A316DocArqDel ;
      private string[] T00176_A324DocArqObservacao ;
      private bool[] T00176_n324DocArqObservacao ;
      private bool[] T00176_A644DocArqArmExterno ;
      private string[] T00176_A645DocArqArmExternoPath ;
      private bool[] T00176_n645DocArqArmExternoPath ;
      private string[] T00176_A323DocArqConteudoExtensao ;
      private string[] T00176_A322DocArqConteudoNome ;
      private Guid[] T00176_A289DocID ;
      private Guid[] T00176_A326DocVersaoIDPai ;
      private bool[] T00176_n326DocVersaoIDPai ;
      private string[] T00176_A321DocArqConteudo ;
      private bool[] T00176_n321DocArqConteudo ;
      private Guid[] T00177_A289DocID ;
      private short[] T00177_A307DocArqSeq ;
      private short[] T00173_A307DocArqSeq ;
      private DateTime[] T00173_A310DocArqInsDataHora ;
      private DateTime[] T00173_A308DocArqInsData ;
      private DateTime[] T00173_A309DocArqInsHora ;
      private string[] T00173_A311DocArqInsUsuID ;
      private bool[] T00173_n311DocArqInsUsuID ;
      private DateTime[] T00173_A319DocArqDelDataHora ;
      private bool[] T00173_n319DocArqDelDataHora ;
      private DateTime[] T00173_A317DocArqDelData ;
      private bool[] T00173_n317DocArqDelData ;
      private DateTime[] T00173_A511DocArqDelHora ;
      private bool[] T00173_n511DocArqDelHora ;
      private string[] T00173_A320DocArqDelUsuID ;
      private bool[] T00173_n320DocArqDelUsuID ;
      private string[] T00173_A509DocArqDelUsuNome ;
      private bool[] T00173_n509DocArqDelUsuNome ;
      private DateTime[] T00173_A312DocArqUpdData ;
      private bool[] T00173_n312DocArqUpdData ;
      private DateTime[] T00173_A313DocArqUpdHora ;
      private bool[] T00173_n313DocArqUpdHora ;
      private DateTime[] T00173_A314DocArqUpdDataHora ;
      private bool[] T00173_n314DocArqUpdDataHora ;
      private string[] T00173_A315DocArqUsuID ;
      private bool[] T00173_n315DocArqUsuID ;
      private bool[] T00173_A316DocArqDel ;
      private string[] T00173_A324DocArqObservacao ;
      private bool[] T00173_n324DocArqObservacao ;
      private bool[] T00173_A644DocArqArmExterno ;
      private string[] T00173_A645DocArqArmExternoPath ;
      private bool[] T00173_n645DocArqArmExternoPath ;
      private string[] T00173_A323DocArqConteudoExtensao ;
      private string[] T00173_A322DocArqConteudoNome ;
      private Guid[] T00173_A289DocID ;
      private string[] T00173_A321DocArqConteudo ;
      private bool[] T00173_n321DocArqConteudo ;
      private Guid[] T00178_A289DocID ;
      private short[] T00178_A307DocArqSeq ;
      private Guid[] T00179_A289DocID ;
      private short[] T00179_A307DocArqSeq ;
      private short[] T00172_A307DocArqSeq ;
      private DateTime[] T00172_A310DocArqInsDataHora ;
      private DateTime[] T00172_A308DocArqInsData ;
      private DateTime[] T00172_A309DocArqInsHora ;
      private string[] T00172_A311DocArqInsUsuID ;
      private bool[] T00172_n311DocArqInsUsuID ;
      private DateTime[] T00172_A319DocArqDelDataHora ;
      private bool[] T00172_n319DocArqDelDataHora ;
      private DateTime[] T00172_A317DocArqDelData ;
      private bool[] T00172_n317DocArqDelData ;
      private DateTime[] T00172_A511DocArqDelHora ;
      private bool[] T00172_n511DocArqDelHora ;
      private string[] T00172_A320DocArqDelUsuID ;
      private bool[] T00172_n320DocArqDelUsuID ;
      private string[] T00172_A509DocArqDelUsuNome ;
      private bool[] T00172_n509DocArqDelUsuNome ;
      private DateTime[] T00172_A312DocArqUpdData ;
      private bool[] T00172_n312DocArqUpdData ;
      private DateTime[] T00172_A313DocArqUpdHora ;
      private bool[] T00172_n313DocArqUpdHora ;
      private DateTime[] T00172_A314DocArqUpdDataHora ;
      private bool[] T00172_n314DocArqUpdDataHora ;
      private string[] T00172_A315DocArqUsuID ;
      private bool[] T00172_n315DocArqUsuID ;
      private bool[] T00172_A316DocArqDel ;
      private string[] T00172_A324DocArqObservacao ;
      private bool[] T00172_n324DocArqObservacao ;
      private bool[] T00172_A644DocArqArmExterno ;
      private string[] T00172_A645DocArqArmExternoPath ;
      private bool[] T00172_n645DocArqArmExternoPath ;
      private string[] T00172_A323DocArqConteudoExtensao ;
      private string[] T00172_A322DocArqConteudoNome ;
      private Guid[] T00172_A289DocID ;
      private string[] T00172_A321DocArqConteudo ;
      private bool[] T00172_n321DocArqConteudo ;
      private short[] T001710_A306DocUltArqSeq ;
      private bool[] T001710_n306DocUltArqSeq ;
      private short[] T001710_A325DocVersao ;
      private Guid[] T001710_A326DocVersaoIDPai ;
      private bool[] T001710_n326DocVersaoIDPai ;
      private short[] T001715_A306DocUltArqSeq ;
      private bool[] T001715_n306DocUltArqSeq ;
      private short[] T001715_A325DocVersao ;
      private Guid[] T001715_A326DocVersaoIDPai ;
      private bool[] T001715_n326DocVersaoIDPai ;
      private Guid[] T001717_A289DocID ;
      private short[] T001717_A307DocArqSeq ;
      private IDataStoreProvider pr_gam ;
      private short[] T00174_A306DocUltArqSeq ;
      private short[] T00174_A325DocVersao ;
      private Guid[] T00174_A326DocVersaoIDPai ;
      private bool[] T00174_n306DocUltArqSeq ;
      private bool[] T00174_n326DocVersaoIDPai ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV25AuditingObject ;
   }

   public class documentoarquivo__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class documentoarquivo__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new ForEachCursor(def[15])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00174;
        prmT00174 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00176;
        prmT00176 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT00175;
        prmT00175 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00177;
        prmT00177 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT00173;
        prmT00173 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT00178;
        prmT00178 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT00179;
        prmT00179 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT00172;
        prmT00172 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT001710;
        prmT001710 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001711;
        prmT001711 = new Object[] {
        new ParDef("DocArqSeq",GXType.Int16,4,0) ,
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001712;
        prmT001712 = new Object[] {
        new ParDef("DocArqInsDataHora",GXType.DateTime2,10,12) ,
        new ParDef("DocArqInsData",GXType.Date,8,0) ,
        new ParDef("DocArqInsHora",GXType.DateTime,0,5) ,
        new ParDef("DocArqInsUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("DocArqDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqDelUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("DocArqUpdData",GXType.Date,8,0){Nullable=true} ,
        new ParDef("DocArqUpdHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("DocArqUpdDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("DocArqUsuID",GXType.Char,40,0){Nullable=true} ,
        new ParDef("DocArqDel",GXType.Boolean,4,0) ,
        new ParDef("DocArqObservacao",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqArmExterno",GXType.Boolean,4,0) ,
        new ParDef("DocArqArmExternoPath",GXType.VarChar,2000,0){Nullable=true} ,
        new ParDef("DocArqConteudoExtensao",GXType.VarChar,20,0) ,
        new ParDef("DocArqConteudoNome",GXType.VarChar,2000,0) ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT001713;
        prmT001713 = new Object[] {
        new ParDef("DocArqConteudo",GXType.Byte,1024,0){Nullable=true,InDB=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT001714;
        prmT001714 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("DocArqSeq",GXType.Int16,4,0)
        };
        Object[] prmT001716;
        prmT001716 = new Object[] {
        new ParDef("DocUltArqSeq",GXType.Int16,4,0){Nullable=true} ,
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001717;
        prmT001717 = new Object[] {
        };
        Object[] prmT001715;
        prmT001715 = new Object[] {
        new ParDef("DocID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00172", "SELECT DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq  FOR UPDATE OF tb_documento_arquivo NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00172,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00173", "SELECT DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID, DocArqConteudo FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00173,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00174", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00174,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00175", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00175,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00176", "SELECT TM1.DocArqSeq, T2.DocUltArqSeq, TM1.DocArqInsDataHora, TM1.DocArqInsData, TM1.DocArqInsHora, TM1.DocArqInsUsuID, TM1.DocArqDelDataHora, TM1.DocArqDelData, TM1.DocArqDelHora, TM1.DocArqDelUsuID, TM1.DocArqDelUsuNome, T2.DocVersao, TM1.DocArqUpdData, TM1.DocArqUpdHora, TM1.DocArqUpdDataHora, TM1.DocArqUsuID, TM1.DocArqDel, TM1.DocArqObservacao, TM1.DocArqArmExterno, TM1.DocArqArmExternoPath, TM1.DocArqConteudoExtensao, TM1.DocArqConteudoNome, TM1.DocID, T2.DocVersaoIDPai, TM1.DocArqConteudo FROM (tb_documento_arquivo TM1 INNER JOIN tb_documento T2 ON T2.DocID = TM1.DocID) WHERE TM1.DocID = :DocID and TM1.DocArqSeq = :DocArqSeq ORDER BY TM1.DocID, TM1.DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00176,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00177", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00177,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00178", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE ( DocID > :DocID or DocID = :DocID and DocArqSeq > :DocArqSeq) ORDER BY DocID, DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT00178,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00179", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo WHERE ( DocID < :DocID or DocID = :DocID and DocArqSeq < :DocArqSeq) ORDER BY DocID DESC, DocArqSeq DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00179,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001710", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID  FOR UPDATE OF tb_documento NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT001710,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001711", "SAVEPOINT gxupdate;INSERT INTO tb_documento_arquivo(DocArqSeq, DocArqInsDataHora, DocArqInsData, DocArqInsHora, DocArqInsUsuID, DocArqDelDataHora, DocArqDelData, DocArqDelHora, DocArqDelUsuID, DocArqDelUsuNome, DocArqUpdData, DocArqUpdHora, DocArqUpdDataHora, DocArqUsuID, DocArqDel, DocArqConteudo, DocArqObservacao, DocArqArmExterno, DocArqArmExternoPath, DocArqConteudoExtensao, DocArqConteudoNome, DocID) VALUES(:DocArqSeq, :DocArqInsDataHora, :DocArqInsData, :DocArqInsHora, :DocArqInsUsuID, :DocArqDelDataHora, :DocArqDelData, :DocArqDelHora, :DocArqDelUsuID, :DocArqDelUsuNome, :DocArqUpdData, :DocArqUpdHora, :DocArqUpdDataHora, :DocArqUsuID, :DocArqDel, :DocArqConteudo, :DocArqObservacao, :DocArqArmExterno, :DocArqArmExternoPath, :DocArqConteudoExtensao, :DocArqConteudoNome, :DocID);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001711)
           ,new CursorDef("T001712", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqInsDataHora=:DocArqInsDataHora, DocArqInsData=:DocArqInsData, DocArqInsHora=:DocArqInsHora, DocArqInsUsuID=:DocArqInsUsuID, DocArqDelDataHora=:DocArqDelDataHora, DocArqDelData=:DocArqDelData, DocArqDelHora=:DocArqDelHora, DocArqDelUsuID=:DocArqDelUsuID, DocArqDelUsuNome=:DocArqDelUsuNome, DocArqUpdData=:DocArqUpdData, DocArqUpdHora=:DocArqUpdHora, DocArqUpdDataHora=:DocArqUpdDataHora, DocArqUsuID=:DocArqUsuID, DocArqDel=:DocArqDel, DocArqObservacao=:DocArqObservacao, DocArqArmExterno=:DocArqArmExterno, DocArqArmExternoPath=:DocArqArmExternoPath, DocArqConteudoExtensao=:DocArqConteudoExtensao, DocArqConteudoNome=:DocArqConteudoNome  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001712)
           ,new CursorDef("T001713", "SAVEPOINT gxupdate;UPDATE tb_documento_arquivo SET DocArqConteudo=:DocArqConteudo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001713)
           ,new CursorDef("T001714", "SAVEPOINT gxupdate;DELETE FROM tb_documento_arquivo  WHERE DocID = :DocID AND DocArqSeq = :DocArqSeq;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001714)
           ,new CursorDef("T001715", "SELECT DocUltArqSeq, DocVersao, DocVersaoIDPai FROM tb_documento WHERE DocID = :DocID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001715,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001716", "SAVEPOINT gxupdate;UPDATE tb_documento SET DocUltArqSeq=:DocUltArqSeq  WHERE DocID = :DocID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001716)
           ,new CursorDef("T001717", "SELECT DocID, DocArqSeq FROM tb_documento_arquivo ORDER BY DocID, DocArqSeq ",true, GxErrorMask.GX_NOMASK, false, this,prmT001717,100, GxCacheFrequency.OFF ,true,false )
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
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13, true);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getString(14, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((bool[]) buf[24])[0] = rslt.getBool(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((string[]) buf[30])[0] = rslt.getVarchar(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((Guid[]) buf[32])[0] = rslt.getGuid(21);
              ((string[]) buf[33])[0] = rslt.getBLOBFile(22, rslt.getVarchar(19), rslt.getVarchar(20));
              ((bool[]) buf[34])[0] = rslt.wasNull(22);
              return;
           case 1 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((DateTime[]) buf[2])[0] = rslt.getGXDate(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(6, true);
              ((bool[]) buf[7])[0] = rslt.wasNull(6);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(7);
              ((bool[]) buf[9])[0] = rslt.wasNull(7);
              ((DateTime[]) buf[10])[0] = rslt.getGXDateTime(8);
              ((bool[]) buf[11])[0] = rslt.wasNull(8);
              ((string[]) buf[12])[0] = rslt.getString(9, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(9);
              ((string[]) buf[14])[0] = rslt.getVarchar(10);
              ((bool[]) buf[15])[0] = rslt.wasNull(10);
              ((DateTime[]) buf[16])[0] = rslt.getGXDate(11);
              ((bool[]) buf[17])[0] = rslt.wasNull(11);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[19])[0] = rslt.wasNull(12);
              ((DateTime[]) buf[20])[0] = rslt.getGXDateTime(13, true);
              ((bool[]) buf[21])[0] = rslt.wasNull(13);
              ((string[]) buf[22])[0] = rslt.getString(14, 40);
              ((bool[]) buf[23])[0] = rslt.wasNull(14);
              ((bool[]) buf[24])[0] = rslt.getBool(15);
              ((string[]) buf[25])[0] = rslt.getVarchar(16);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((string[]) buf[30])[0] = rslt.getVarchar(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((Guid[]) buf[32])[0] = rslt.getGuid(21);
              ((string[]) buf[33])[0] = rslt.getBLOBFile(22, rslt.getVarchar(19), rslt.getVarchar(20));
              ((bool[]) buf[34])[0] = rslt.wasNull(22);
              return;
           case 2 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 4 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              ((bool[]) buf[2])[0] = rslt.wasNull(2);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(3, true);
              ((DateTime[]) buf[4])[0] = rslt.getGXDate(4);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(5);
              ((string[]) buf[6])[0] = rslt.getString(6, 40);
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
              ((short[]) buf[18])[0] = rslt.getShort(12);
              ((DateTime[]) buf[19])[0] = rslt.getGXDate(13);
              ((bool[]) buf[20])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[21])[0] = rslt.getGXDateTime(14);
              ((bool[]) buf[22])[0] = rslt.wasNull(14);
              ((DateTime[]) buf[23])[0] = rslt.getGXDateTime(15, true);
              ((bool[]) buf[24])[0] = rslt.wasNull(15);
              ((string[]) buf[25])[0] = rslt.getString(16, 40);
              ((bool[]) buf[26])[0] = rslt.wasNull(16);
              ((bool[]) buf[27])[0] = rslt.getBool(17);
              ((string[]) buf[28])[0] = rslt.getVarchar(18);
              ((bool[]) buf[29])[0] = rslt.wasNull(18);
              ((bool[]) buf[30])[0] = rslt.getBool(19);
              ((string[]) buf[31])[0] = rslt.getVarchar(20);
              ((bool[]) buf[32])[0] = rslt.wasNull(20);
              ((string[]) buf[33])[0] = rslt.getVarchar(21);
              ((string[]) buf[34])[0] = rslt.getVarchar(22);
              ((Guid[]) buf[35])[0] = rslt.getGuid(23);
              ((Guid[]) buf[36])[0] = rslt.getGuid(24);
              ((bool[]) buf[37])[0] = rslt.wasNull(24);
              ((string[]) buf[38])[0] = rslt.getBLOBFile(25, rslt.getVarchar(21), rslt.getVarchar(22));
              ((bool[]) buf[39])[0] = rslt.wasNull(25);
              return;
           case 5 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 6 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 7 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
           case 8 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 13 :
              ((short[]) buf[0])[0] = rslt.getShort(1);
              ((bool[]) buf[1])[0] = rslt.wasNull(1);
              ((short[]) buf[2])[0] = rslt.getShort(2);
              ((Guid[]) buf[3])[0] = rslt.getGuid(3);
              ((bool[]) buf[4])[0] = rslt.wasNull(3);
              return;
           case 15 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((short[]) buf[1])[0] = rslt.getShort(2);
              return;
     }
  }

}

}
