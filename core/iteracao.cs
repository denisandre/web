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
   public class iteracao : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_18") == 0 )
         {
            A381IteID = StringUtil.StrToGuid( GetPar( "IteID"));
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_18( A381IteID) ;
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
            if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "core.iteracao.aspx")), "core.iteracao.aspx") == 0 ) )
            {
               SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "core.iteracao.aspx")))) ;
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
                  AV7IteID = StringUtil.StrToGuid( GetPar( "IteID"));
                  AssignAttri("", false, "AV7IteID", AV7IteID.ToString());
                  GxWebStd.gx_hidden_field( context, "gxhash_vITEID", GetSecureSignedToken( "", AV7IteID, context));
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
            Form.Meta.addItem("description", "Itera��o", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtIteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public iteracao( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public iteracao( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( string aP0_Gx_mode ,
                           Guid aP1_IteID )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV7IteID = aP1_IteID;
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
            return "iteracao_Execute" ;
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtIteNome_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtIteNome_Internalname, "Descri��o", "col-sm-3 AttributeFLLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 22,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIteNome_Internalname, A383IteNome, StringUtil.RTrim( context.localUtil.Format( A383IteNome, "@!")), TempTags+" onchange=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"this.value=this.value.toUpperCase();"+";gx.evt.onblur(this,22);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIteNome_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtIteNome_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "core\\Nome", "start", true, "", "HLP_core\\Iteracao.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "ButtonMaterial";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_enter_Internalname, "", "Confirmar", bttBtntrn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtntrn_enter_Visible, bttBtntrn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Iteracao.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "ButtonMaterialDefault";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtntrn_cancel_Internalname, "", "Fechar", bttBtntrn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtntrn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_core\\Iteracao.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 33,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIteID_Internalname, A381IteID.ToString(), A381IteID.ToString(), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,33);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIteID_Jsonclick, 0, "Attribute", "", "", "", "", edtIteID_Visible, edtIteID_Enabled, 1, "text", "", 36, "chr", 1, "row", 36, 0, 0, 0, 0, 0, 0, true, "", "", false, "", "HLP_core\\Iteracao.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIteOrdem_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A382IteOrdem), 8, 0, ",", "")), StringUtil.LTrim( ((edtIteOrdem_Enabled!=0) ? context.localUtil.Format( (decimal)(A382IteOrdem), "ZZZZZZZ9") : context.localUtil.Format( (decimal)(A382IteOrdem), "ZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIteOrdem_Jsonclick, 0, "Attribute", "", "", "", "", edtIteOrdem_Visible, edtIteOrdem_Enabled, 0, "text", "1", 8, "chr", 1, "row", 8, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_core\\Iteracao.htm");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtIteAtivo_Internalname, StringUtil.BoolToStr( A384IteAtivo), StringUtil.BoolToStr( A384IteAtivo), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtIteAtivo_Jsonclick, 0, "Attribute", "", "", "", "", edtIteAtivo_Visible, edtIteAtivo_Enabled, 0, "text", "", 4, "chr", 1, "row", 4, 0, 0, 0, 0, 0, 0, true, "core\\Ativo", "end", false, "", "HLP_core\\Iteracao.htm");
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
         E11122 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z381IteID = StringUtil.StrToGuid( cgiGet( "Z381IteID"));
               Z591IteDelDataHora = context.localUtil.CToT( cgiGet( "Z591IteDelDataHora"), 0);
               n591IteDelDataHora = ((DateTime.MinValue==A591IteDelDataHora) ? true : false);
               Z592IteDelData = context.localUtil.CToT( cgiGet( "Z592IteDelData"), 0);
               n592IteDelData = ((DateTime.MinValue==A592IteDelData) ? true : false);
               Z593IteDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z593IteDelHora"), 0));
               n593IteDelHora = ((DateTime.MinValue==A593IteDelHora) ? true : false);
               Z594IteDelUsuId = cgiGet( "Z594IteDelUsuId");
               n594IteDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A594IteDelUsuId)) ? true : false);
               Z595IteDelUsuNome = cgiGet( "Z595IteDelUsuNome");
               n595IteDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A595IteDelUsuNome)) ? true : false);
               Z382IteOrdem = (int)(Math.Round(context.localUtil.CToN( cgiGet( "Z382IteOrdem"), ",", "."), 18, MidpointRounding.ToEven));
               Z383IteNome = cgiGet( "Z383IteNome");
               Z384IteAtivo = StringUtil.StrToBool( cgiGet( "Z384IteAtivo"));
               Z590IteDel = StringUtil.StrToBool( cgiGet( "Z590IteDel"));
               A591IteDelDataHora = context.localUtil.CToT( cgiGet( "Z591IteDelDataHora"), 0);
               n591IteDelDataHora = false;
               n591IteDelDataHora = ((DateTime.MinValue==A591IteDelDataHora) ? true : false);
               A592IteDelData = context.localUtil.CToT( cgiGet( "Z592IteDelData"), 0);
               n592IteDelData = false;
               n592IteDelData = ((DateTime.MinValue==A592IteDelData) ? true : false);
               A593IteDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "Z593IteDelHora"), 0));
               n593IteDelHora = false;
               n593IteDelHora = ((DateTime.MinValue==A593IteDelHora) ? true : false);
               A594IteDelUsuId = cgiGet( "Z594IteDelUsuId");
               n594IteDelUsuId = false;
               n594IteDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A594IteDelUsuId)) ? true : false);
               A595IteDelUsuNome = cgiGet( "Z595IteDelUsuNome");
               n595IteDelUsuNome = false;
               n595IteDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A595IteDelUsuNome)) ? true : false);
               A590IteDel = StringUtil.StrToBool( cgiGet( "Z590IteDel"));
               O590IteDel = StringUtil.StrToBool( cgiGet( "O590IteDel"));
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               AV7IteID = StringUtil.StrToGuid( cgiGet( "vITEID"));
               A590IteDel = StringUtil.StrToBool( cgiGet( "ITEDEL"));
               A591IteDelDataHora = context.localUtil.CToT( cgiGet( "ITEDELDATAHORA"), 0);
               n591IteDelDataHora = ((DateTime.MinValue==A591IteDelDataHora) ? true : false);
               A592IteDelData = context.localUtil.CToT( cgiGet( "ITEDELDATA"), 0);
               n592IteDelData = ((DateTime.MinValue==A592IteDelData) ? true : false);
               A593IteDelHora = DateTimeUtil.ResetDate(context.localUtil.CToT( cgiGet( "ITEDELHORA"), 0));
               n593IteDelHora = ((DateTime.MinValue==A593IteDelHora) ? true : false);
               A594IteDelUsuId = cgiGet( "ITEDELUSUID");
               n594IteDelUsuId = (String.IsNullOrEmpty(StringUtil.RTrim( A594IteDelUsuId)) ? true : false);
               A595IteDelUsuNome = cgiGet( "ITEDELUSUNOME");
               n595IteDelUsuNome = (String.IsNullOrEmpty(StringUtil.RTrim( A595IteDelUsuNome)) ? true : false);
               Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
               ajax_req_read_hidden_sdt(cgiGet( "vAUDITINGOBJECT"), AV13AuditingObject);
               A431IteTotalOportunidades = context.localUtil.CToN( cgiGet( "ITETOTALOPORTUNIDADES"), ",", ".");
               A432IteQtdeOportunidades = (int)(Math.Round(context.localUtil.CToN( cgiGet( "ITEQTDEOPORTUNIDADES"), ",", "."), 18, MidpointRounding.ToEven));
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
               A383IteNome = StringUtil.Upper( cgiGet( edtIteNome_Internalname));
               AssignAttri("", false, "A383IteNome", A383IteNome);
               if ( StringUtil.StrCmp(cgiGet( edtIteID_Internalname), "") == 0 )
               {
                  A381IteID = Guid.Empty;
                  AssignAttri("", false, "A381IteID", A381IteID.ToString());
               }
               else
               {
                  try
                  {
                     A381IteID = StringUtil.StrToGuid( cgiGet( edtIteID_Internalname));
                     AssignAttri("", false, "A381IteID", A381IteID.ToString());
                  }
                  catch ( Exception  )
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_invalidguid", ""), 1, "ITEID");
                     AnyError = 1;
                     GX_FocusControl = edtIteID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     wbErr = true;
                  }
               }
               if ( ( ( context.localUtil.CToN( cgiGet( edtIteOrdem_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtIteOrdem_Internalname), ",", ".") > Convert.ToDecimal( 99999999 )) ) )
               {
                  GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "ITEORDEM");
                  AnyError = 1;
                  GX_FocusControl = edtIteOrdem_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  wbErr = true;
                  A382IteOrdem = 0;
                  AssignAttri("", false, "A382IteOrdem", StringUtil.LTrimStr( (decimal)(A382IteOrdem), 8, 0));
               }
               else
               {
                  A382IteOrdem = (int)(Math.Round(context.localUtil.CToN( cgiGet( edtIteOrdem_Internalname), ",", "."), 18, MidpointRounding.ToEven));
                  AssignAttri("", false, "A382IteOrdem", StringUtil.LTrimStr( (decimal)(A382IteOrdem), 8, 0));
               }
               A384IteAtivo = StringUtil.StrToBool( cgiGet( edtIteAtivo_Internalname));
               AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
               /* Read subfile selected row values. */
               /* Read hidden variables. */
               GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
               forbiddenHiddens = new GXProperties();
               forbiddenHiddens.Add("hshsalt", "hsh"+"Iteracao");
               forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
               forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
               forbiddenHiddens.Add("IteDel", StringUtil.BoolToStr( A590IteDel));
               hsh = cgiGet( "hsh");
               if ( ( ! ( ( A381IteID != Z381IteID ) ) || ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) ) && ! GXUtil.CheckEncryptedHash( forbiddenHiddens.ToString(), hsh, GXKey) )
               {
                  GXUtil.WriteLogError("core\\iteracao:[ SecurityCheckFailed (403 Forbidden) value for]"+forbiddenHiddens.ToJSonString());
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
                  A381IteID = StringUtil.StrToGuid( GetPar( "IteID"));
                  AssignAttri("", false, "A381IteID", A381IteID.ToString());
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
                     sMode38 = Gx_mode;
                     Gx_mode = "UPD";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     Gx_mode = sMode38;
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                  }
                  standaloneModal( ) ;
                  if ( ! IsIns( ) )
                  {
                     getByPrimaryKey( ) ;
                     if ( RcdFound38 == 1 )
                     {
                        if ( IsDlt( ) )
                        {
                           /* Confirm record */
                           CONFIRM_120( ) ;
                           if ( AnyError == 0 )
                           {
                              GX_FocusControl = bttBtntrn_enter_Internalname;
                              AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                           }
                        }
                     }
                     else
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_noinsert", ""), 1, "ITEID");
                        AnyError = 1;
                        GX_FocusControl = edtIteID_Internalname;
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
                           E11122 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E12122 ();
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
            E12122 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll1238( ) ;
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
            DisableAttributes1238( ) ;
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

      protected void CONFIRM_120( )
      {
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            if ( IsDlt( ) )
            {
               OnDeleteControls1238( ) ;
            }
            else
            {
               CheckExtendedTable1238( ) ;
               CloseExtendedTableCursors1238( ) ;
            }
         }
         if ( AnyError == 0 )
         {
            IsConfirmed = 1;
            AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         }
      }

      protected void ResetCaption120( )
      {
      }

      protected void E11122( )
      {
         /* Start Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.loadwwpcontext(context ).execute( out  AV8WWPContext) ;
         AV11TrnContext.FromXml(AV12WebSession.Get("TrnContext"), null, "", "");
         edtIteID_Visible = 0;
         AssignProp("", false, edtIteID_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteID_Visible), 5, 0), true);
         edtIteOrdem_Visible = 0;
         AssignProp("", false, edtIteOrdem_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteOrdem_Visible), 5, 0), true);
         edtIteAtivo_Visible = 0;
         AssignProp("", false, edtIteAtivo_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtIteAtivo_Visible), 5, 0), true);
      }

      protected void E12122( )
      {
         /* After Trn Routine */
         returnInSub = false;
         new GeneXus.Programs.wwpbaseobjects.audittransaction(context ).execute(  AV13AuditingObject,  AV14Pgmname) ;
         if ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) && ! AV11TrnContext.gxTpr_Callerondelete )
         {
            CallWebObject(formatLink("core.iteracaoww.aspx") );
            context.wjLocDisableFrm = 1;
         }
         context.setWebReturnParms(new Object[] {});
         context.setWebReturnParmsMetadata(new Object[] {});
         context.wjLocDisableFrm = 1;
         context.nUserReturn = 1;
         returnInSub = true;
         if (true) return;
      }

      protected void ZM1238( short GX_JID )
      {
         if ( ( GX_JID == 16 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z591IteDelDataHora = T00123_A591IteDelDataHora[0];
               Z592IteDelData = T00123_A592IteDelData[0];
               Z593IteDelHora = T00123_A593IteDelHora[0];
               Z594IteDelUsuId = T00123_A594IteDelUsuId[0];
               Z595IteDelUsuNome = T00123_A595IteDelUsuNome[0];
               Z382IteOrdem = T00123_A382IteOrdem[0];
               Z383IteNome = T00123_A383IteNome[0];
               Z384IteAtivo = T00123_A384IteAtivo[0];
               Z590IteDel = T00123_A590IteDel[0];
            }
            else
            {
               Z591IteDelDataHora = A591IteDelDataHora;
               Z592IteDelData = A592IteDelData;
               Z593IteDelHora = A593IteDelHora;
               Z594IteDelUsuId = A594IteDelUsuId;
               Z595IteDelUsuNome = A595IteDelUsuNome;
               Z382IteOrdem = A382IteOrdem;
               Z383IteNome = A383IteNome;
               Z384IteAtivo = A384IteAtivo;
               Z590IteDel = A590IteDel;
            }
         }
         if ( GX_JID == -16 )
         {
            Z381IteID = A381IteID;
            Z591IteDelDataHora = A591IteDelDataHora;
            Z592IteDelData = A592IteDelData;
            Z593IteDelHora = A593IteDelHora;
            Z594IteDelUsuId = A594IteDelUsuId;
            Z595IteDelUsuNome = A595IteDelUsuNome;
            Z382IteOrdem = A382IteOrdem;
            Z383IteNome = A383IteNome;
            Z384IteAtivo = A384IteAtivo;
            Z590IteDel = A590IteDel;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         AV14Pgmname = "core.Iteracao";
         AssignAttri("", false, "AV14Pgmname", AV14Pgmname);
         if ( ! (Guid.Empty==AV7IteID) )
         {
            A381IteID = AV7IteID;
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
         }
         if ( ! (Guid.Empty==AV7IteID) )
         {
            edtIteID_Enabled = 0;
            AssignProp("", false, edtIteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteID_Enabled), 5, 0), true);
         }
         else
         {
            edtIteID_Enabled = 1;
            AssignProp("", false, edtIteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteID_Enabled), 5, 0), true);
         }
         if ( ! (Guid.Empty==AV7IteID) )
         {
            edtIteID_Enabled = 0;
            AssignProp("", false, edtIteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteID_Enabled), 5, 0), true);
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
         if ( IsIns( )  && (false==A384IteAtivo) && ( Gx_BScreen == 0 ) )
         {
            A384IteAtivo = true;
            AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
            /* Using cursor T00125 */
            pr_default.execute(2, new Object[] {A381IteID});
            if ( (pr_default.getStatus(2) != 101) )
            {
               A431IteTotalOportunidades = T00125_A431IteTotalOportunidades[0];
               A432IteQtdeOportunidades = T00125_A432IteQtdeOportunidades[0];
            }
            else
            {
               A431IteTotalOportunidades = 0;
               AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
               A432IteQtdeOportunidades = 0;
               AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
            }
            pr_default.close(2);
         }
      }

      protected void Load1238( )
      {
         /* Using cursor T00126 */
         pr_default.execute(3, new Object[] {A381IteID});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound38 = 1;
            A591IteDelDataHora = T00126_A591IteDelDataHora[0];
            n591IteDelDataHora = T00126_n591IteDelDataHora[0];
            A592IteDelData = T00126_A592IteDelData[0];
            n592IteDelData = T00126_n592IteDelData[0];
            A593IteDelHora = T00126_A593IteDelHora[0];
            n593IteDelHora = T00126_n593IteDelHora[0];
            A594IteDelUsuId = T00126_A594IteDelUsuId[0];
            n594IteDelUsuId = T00126_n594IteDelUsuId[0];
            A595IteDelUsuNome = T00126_A595IteDelUsuNome[0];
            n595IteDelUsuNome = T00126_n595IteDelUsuNome[0];
            A382IteOrdem = T00126_A382IteOrdem[0];
            AssignAttri("", false, "A382IteOrdem", StringUtil.LTrimStr( (decimal)(A382IteOrdem), 8, 0));
            A383IteNome = T00126_A383IteNome[0];
            AssignAttri("", false, "A383IteNome", A383IteNome);
            A384IteAtivo = T00126_A384IteAtivo[0];
            AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
            A590IteDel = T00126_A590IteDel[0];
            ZM1238( -16) ;
         }
         pr_default.close(3);
         OnLoadActions1238( ) ;
      }

      protected void OnLoadActions1238( )
      {
         /* Using cursor T00125 */
         pr_default.execute(2, new Object[] {A381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A431IteTotalOportunidades = T00125_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = T00125_A432IteQtdeOportunidades[0];
         }
         else
         {
            A431IteTotalOportunidades = 0;
            AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
            A432IteQtdeOportunidades = 0;
            AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
         }
         pr_default.close(2);
      }

      protected void CheckExtendedTable1238( )
      {
         nIsDirty_38 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T00125 */
         pr_default.execute(2, new Object[] {A381IteID});
         if ( (pr_default.getStatus(2) != 101) )
         {
            A431IteTotalOportunidades = T00125_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = T00125_A432IteQtdeOportunidades[0];
         }
         else
         {
            nIsDirty_38 = 1;
            A431IteTotalOportunidades = 0;
            AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
            nIsDirty_38 = 1;
            A432IteQtdeOportunidades = 0;
            AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
         }
         pr_default.close(2);
         /* Using cursor T00127 */
         pr_default.execute(4, new Object[] {A382IteOrdem, A381IteID});
         if ( (pr_default.getStatus(4) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Ordem"}), 1, "ITEORDEM");
            AnyError = 1;
            GX_FocusControl = edtIteOrdem_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         pr_default.close(4);
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A383IteNome)) )
         {
            GX_msglist.addItem(StringUtil.Format( "%1 � obrigat�rio.", "Descri��o da Itera��o", "", "", "", "", "", "", "", ""), 1, "ITENOME");
            AnyError = 1;
            GX_FocusControl = edtIteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors1238( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_18( Guid A381IteID )
      {
         /* Using cursor T00129 */
         pr_default.execute(5, new Object[] {A381IteID});
         if ( (pr_default.getStatus(5) != 101) )
         {
            A431IteTotalOportunidades = T00129_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = T00129_A432IteQtdeOportunidades[0];
         }
         else
         {
            A431IteTotalOportunidades = 0;
            AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
            A432IteQtdeOportunidades = 0;
            AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 16, 2, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ".", "")))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void GetKey1238( )
      {
         /* Using cursor T001210 */
         pr_default.execute(6, new Object[] {A381IteID});
         if ( (pr_default.getStatus(6) != 101) )
         {
            RcdFound38 = 1;
         }
         else
         {
            RcdFound38 = 0;
         }
         pr_default.close(6);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00123 */
         pr_default.execute(1, new Object[] {A381IteID});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM1238( 16) ;
            RcdFound38 = 1;
            A381IteID = T00123_A381IteID[0];
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
            A591IteDelDataHora = T00123_A591IteDelDataHora[0];
            n591IteDelDataHora = T00123_n591IteDelDataHora[0];
            A592IteDelData = T00123_A592IteDelData[0];
            n592IteDelData = T00123_n592IteDelData[0];
            A593IteDelHora = T00123_A593IteDelHora[0];
            n593IteDelHora = T00123_n593IteDelHora[0];
            A594IteDelUsuId = T00123_A594IteDelUsuId[0];
            n594IteDelUsuId = T00123_n594IteDelUsuId[0];
            A595IteDelUsuNome = T00123_A595IteDelUsuNome[0];
            n595IteDelUsuNome = T00123_n595IteDelUsuNome[0];
            A382IteOrdem = T00123_A382IteOrdem[0];
            AssignAttri("", false, "A382IteOrdem", StringUtil.LTrimStr( (decimal)(A382IteOrdem), 8, 0));
            A383IteNome = T00123_A383IteNome[0];
            AssignAttri("", false, "A383IteNome", A383IteNome);
            A384IteAtivo = T00123_A384IteAtivo[0];
            AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
            A590IteDel = T00123_A590IteDel[0];
            O590IteDel = A590IteDel;
            AssignAttri("", false, "A590IteDel", A590IteDel);
            Z381IteID = A381IteID;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            Load1238( ) ;
            if ( AnyError == 1 )
            {
               RcdFound38 = 0;
               InitializeNonKey1238( ) ;
            }
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound38 = 0;
            InitializeNonKey1238( ) ;
            sMode38 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode38;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey1238( ) ;
         if ( RcdFound38 == 0 )
         {
         }
         else
         {
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound38 = 0;
         /* Using cursor T001211 */
         pr_default.execute(7, new Object[] {A381IteID});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001211_A381IteID[0], A381IteID, 0) < 0 ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( GuidUtil.Compare(T001211_A381IteID[0], A381IteID, 0) > 0 ) ) )
            {
               A381IteID = T001211_A381IteID[0];
               AssignAttri("", false, "A381IteID", A381IteID.ToString());
               RcdFound38 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void move_previous( )
      {
         RcdFound38 = 0;
         /* Using cursor T001212 */
         pr_default.execute(8, new Object[] {A381IteID});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001212_A381IteID[0], A381IteID, 0) > 0 ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( GuidUtil.Compare(T001212_A381IteID[0], A381IteID, 0) < 0 ) ) )
            {
               A381IteID = T001212_A381IteID[0];
               AssignAttri("", false, "A381IteID", A381IteID.ToString());
               RcdFound38 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey1238( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtIteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert1238( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound38 == 1 )
            {
               if ( A381IteID != Z381IteID )
               {
                  A381IteID = Z381IteID;
                  AssignAttri("", false, "A381IteID", A381IteID.ToString());
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "ITEID");
                  AnyError = 1;
                  GX_FocusControl = edtIteID_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtIteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  /* Update record */
                  Update1238( ) ;
                  GX_FocusControl = edtIteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A381IteID != Z381IteID )
               {
                  /* Insert record */
                  GX_FocusControl = edtIteNome_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert1238( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "ITEID");
                     AnyError = 1;
                     GX_FocusControl = edtIteID_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     /* Insert record */
                     GX_FocusControl = edtIteNome_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert1238( ) ;
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
         if ( A381IteID != Z381IteID )
         {
            A381IteID = Z381IteID;
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "ITEID");
            AnyError = 1;
            GX_FocusControl = edtIteID_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtIteNome_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
         }
      }

      protected void CheckOptimisticConcurrency1238( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00122 */
            pr_default.execute(0, new Object[] {A381IteID});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_Iteracao"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z591IteDelDataHora != T00122_A591IteDelDataHora[0] ) || ( Z592IteDelData != T00122_A592IteDelData[0] ) || ( Z593IteDelHora != T00122_A593IteDelHora[0] ) || ( StringUtil.StrCmp(Z594IteDelUsuId, T00122_A594IteDelUsuId[0]) != 0 ) || ( StringUtil.StrCmp(Z595IteDelUsuNome, T00122_A595IteDelUsuNome[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z382IteOrdem != T00122_A382IteOrdem[0] ) || ( StringUtil.StrCmp(Z383IteNome, T00122_A383IteNome[0]) != 0 ) || ( Z384IteAtivo != T00122_A384IteAtivo[0] ) || ( Z590IteDel != T00122_A590IteDel[0] ) )
            {
               if ( Z591IteDelDataHora != T00122_A591IteDelDataHora[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDelDataHora");
                  GXUtil.WriteLogRaw("Old: ",Z591IteDelDataHora);
                  GXUtil.WriteLogRaw("Current: ",T00122_A591IteDelDataHora[0]);
               }
               if ( Z592IteDelData != T00122_A592IteDelData[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDelData");
                  GXUtil.WriteLogRaw("Old: ",Z592IteDelData);
                  GXUtil.WriteLogRaw("Current: ",T00122_A592IteDelData[0]);
               }
               if ( Z593IteDelHora != T00122_A593IteDelHora[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDelHora");
                  GXUtil.WriteLogRaw("Old: ",Z593IteDelHora);
                  GXUtil.WriteLogRaw("Current: ",T00122_A593IteDelHora[0]);
               }
               if ( StringUtil.StrCmp(Z594IteDelUsuId, T00122_A594IteDelUsuId[0]) != 0 )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDelUsuId");
                  GXUtil.WriteLogRaw("Old: ",Z594IteDelUsuId);
                  GXUtil.WriteLogRaw("Current: ",T00122_A594IteDelUsuId[0]);
               }
               if ( StringUtil.StrCmp(Z595IteDelUsuNome, T00122_A595IteDelUsuNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDelUsuNome");
                  GXUtil.WriteLogRaw("Old: ",Z595IteDelUsuNome);
                  GXUtil.WriteLogRaw("Current: ",T00122_A595IteDelUsuNome[0]);
               }
               if ( Z382IteOrdem != T00122_A382IteOrdem[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteOrdem");
                  GXUtil.WriteLogRaw("Old: ",Z382IteOrdem);
                  GXUtil.WriteLogRaw("Current: ",T00122_A382IteOrdem[0]);
               }
               if ( StringUtil.StrCmp(Z383IteNome, T00122_A383IteNome[0]) != 0 )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteNome");
                  GXUtil.WriteLogRaw("Old: ",Z383IteNome);
                  GXUtil.WriteLogRaw("Current: ",T00122_A383IteNome[0]);
               }
               if ( Z384IteAtivo != T00122_A384IteAtivo[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteAtivo");
                  GXUtil.WriteLogRaw("Old: ",Z384IteAtivo);
                  GXUtil.WriteLogRaw("Current: ",T00122_A384IteAtivo[0]);
               }
               if ( Z590IteDel != T00122_A590IteDel[0] )
               {
                  GXUtil.WriteLog("core.iteracao:[seudo value changed for attri]"+"IteDel");
                  GXUtil.WriteLogRaw("Old: ",Z590IteDel);
                  GXUtil.WriteLogRaw("Current: ",T00122_A590IteDel[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"tb_Iteracao"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert1238( )
      {
         if ( ! IsAuthorized("iteracao_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1238( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM1238( 0) ;
            CheckOptimisticConcurrency1238( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1238( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert1238( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001213 */
                     pr_default.execute(9, new Object[] {A381IteID, n591IteDelDataHora, A591IteDelDataHora, n592IteDelData, A592IteDelData, n593IteDelHora, A593IteDelHora, n594IteDelUsuId, A594IteDelUsuId, n595IteDelUsuNome, A595IteDelUsuNome, A382IteOrdem, A383IteNome, A384IteAtivo, A590IteDel});
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
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
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption120( ) ;
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
               Load1238( ) ;
            }
            EndLevel1238( ) ;
         }
         CloseExtendedTableCursors1238( ) ;
      }

      protected void Update1238( )
      {
         if ( ! IsAuthorized("iteracao_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable1238( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1238( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm1238( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate1238( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T001214 */
                     pr_default.execute(10, new Object[] {n591IteDelDataHora, A591IteDelDataHora, n592IteDelData, A592IteDelData, n593IteDelHora, A593IteDelHora, n594IteDelUsuId, A594IteDelUsuId, n595IteDelUsuNome, A595IteDelUsuNome, A382IteOrdem, A383IteNome, A384IteAtivo, A590IteDel, A381IteID});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"tb_Iteracao"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate1238( ) ;
                     if ( AnyError == 0 )
                     {
                        /* API remote call */
                        new tb_iteracaoupdateredundancy(context ).execute( ref  A381IteID) ;
                        AssignAttri("", false, "A381IteID", A381IteID.ToString());
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
            EndLevel1238( ) ;
         }
         CloseExtendedTableCursors1238( ) ;
      }

      protected void DeferredUpdate1238( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("iteracao_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate1238( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency1238( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls1238( ) ;
            AfterConfirm1238( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete1238( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T001215 */
                  pr_default.execute(11, new Object[] {A381IteID});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("tb_Iteracao");
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
         sMode38 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel1238( ) ;
         Gx_mode = sMode38;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls1238( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T001217 */
            pr_default.execute(12, new Object[] {A381IteID});
            if ( (pr_default.getStatus(12) != 101) )
            {
               A431IteTotalOportunidades = T001217_A431IteTotalOportunidades[0];
               A432IteQtdeOportunidades = T001217_A432IteQtdeOportunidades[0];
            }
            else
            {
               A431IteTotalOportunidades = 0;
               AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
               A432IteQtdeOportunidades = 0;
               AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
            }
            pr_default.close(12);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T001218 */
            pr_default.execute(13, new Object[] {A381IteID});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {""}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
         }
      }

      protected void EndLevel1238( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete1238( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("core.iteracao",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues120( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("core.iteracao",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart1238( )
      {
         /* Scan By routine */
         /* Using cursor T001219 */
         pr_default.execute(14);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound38 = 1;
            A381IteID = T001219_A381IteID[0];
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext1238( )
      {
         /* Scan next routine */
         pr_default.readNext(14);
         RcdFound38 = 0;
         if ( (pr_default.getStatus(14) != 101) )
         {
            RcdFound38 = 1;
            A381IteID = T001219_A381IteID[0];
            AssignAttri("", false, "A381IteID", A381IteID.ToString());
         }
      }

      protected void ScanEnd1238( )
      {
         pr_default.close(14);
      }

      protected void AfterConfirm1238( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert1238( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate1238( )
      {
         /* Before Update Rules */
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A591IteDelDataHora = DateTimeUtil.NowMS( context);
            n591IteDelDataHora = false;
            AssignAttri("", false, "A591IteDelDataHora", context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A594IteDelUsuId = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getid();
            n594IteDelUsuId = false;
            AssignAttri("", false, "A594IteDelUsuId", A594IteDelUsuId);
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A595IteDelUsuNome = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).getname();
            n595IteDelUsuNome = false;
            AssignAttri("", false, "A595IteDelUsuNome", A595IteDelUsuNome);
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A592IteDelData = DateTimeUtil.ResetTime( DateTimeUtil.ResetTime( A591IteDelDataHora) ) ;
            n592IteDelData = false;
            AssignAttri("", false, "A592IteDelData", context.localUtil.TToC( A592IteDelData, 10, 5, 0, 3, "/", ":", " "));
         }
         if ( A590IteDel && ( O590IteDel != A590IteDel ) )
         {
            A593IteDelHora = DateTimeUtil.ResetDate( DateTimeUtil.ResetMilliseconds(A591IteDelDataHora));
            n593IteDelHora = false;
            AssignAttri("", false, "A593IteDelHora", context.localUtil.TToC( A593IteDelHora, 0, 5, 0, 3, "/", ":", " "));
         }
      }

      protected void BeforeDelete1238( )
      {
         /* Before Delete Rules */
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
      }

      protected void BeforeComplete1238( )
      {
         /* Before Complete Rules */
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         }
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
         }
      }

      protected void BeforeValidate1238( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes1238( )
      {
         edtIteNome_Enabled = 0;
         AssignProp("", false, edtIteNome_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteNome_Enabled), 5, 0), true);
         edtIteID_Enabled = 0;
         AssignProp("", false, edtIteID_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteID_Enabled), 5, 0), true);
         edtIteOrdem_Enabled = 0;
         AssignProp("", false, edtIteOrdem_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteOrdem_Enabled), 5, 0), true);
         edtIteAtivo_Enabled = 0;
         AssignProp("", false, edtIteAtivo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtIteAtivo_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes1238( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues120( )
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
         GXEncryptionTmp = "core.iteracao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7IteID.ToString());
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("core.iteracao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         forbiddenHiddens.Add("hshsalt", "hsh"+"Iteracao");
         forbiddenHiddens.Add("Gx_mode", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")));
         forbiddenHiddens.Add("Pgmname", StringUtil.RTrim( context.localUtil.Format( AV14Pgmname, "")));
         forbiddenHiddens.Add("IteDel", StringUtil.BoolToStr( A590IteDel));
         GxWebStd.gx_hidden_field( context, "hsh", GetEncryptedHash( forbiddenHiddens.ToString(), GXKey));
         GXUtil.WriteLogInfo("core\\iteracao:[ SendSecurityCheck value for]"+forbiddenHiddens.ToJSonString());
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z381IteID", Z381IteID.ToString());
         GxWebStd.gx_hidden_field( context, "Z591IteDelDataHora", context.localUtil.TToC( Z591IteDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z592IteDelData", context.localUtil.TToC( Z592IteDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z593IteDelHora", context.localUtil.TToC( Z593IteDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z594IteDelUsuId", StringUtil.RTrim( Z594IteDelUsuId));
         GxWebStd.gx_hidden_field( context, "Z595IteDelUsuNome", Z595IteDelUsuNome);
         GxWebStd.gx_hidden_field( context, "Z382IteOrdem", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z382IteOrdem), 8, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z383IteNome", Z383IteNome);
         GxWebStd.gx_boolean_hidden_field( context, "Z384IteAtivo", Z384IteAtivo);
         GxWebStd.gx_boolean_hidden_field( context, "Z590IteDel", Z590IteDel);
         GxWebStd.gx_boolean_hidden_field( context, "O590IteDel", O590IteDel);
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
         GxWebStd.gx_hidden_field( context, "vITEID", AV7IteID.ToString());
         GxWebStd.gx_hidden_field( context, "gxhash_vITEID", GetSecureSignedToken( "", AV7IteID, context));
         GxWebStd.gx_boolean_hidden_field( context, "ITEDEL", A590IteDel);
         GxWebStd.gx_hidden_field( context, "ITEDELDATAHORA", context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "ITEDELDATA", context.localUtil.TToC( A592IteDelData, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "ITEDELHORA", context.localUtil.TToC( A593IteDelHora, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "ITEDELUSUID", StringUtil.RTrim( A594IteDelUsuId));
         GxWebStd.gx_hidden_field( context, "ITEDELUSUNOME", A595IteDelUsuNome);
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         if ( context.isAjaxRequest( ) )
         {
            context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "vAUDITINGOBJECT", AV13AuditingObject);
         }
         else
         {
            context.httpAjaxContext.ajax_rsp_assign_hidden_sdt("vAUDITINGOBJECT", AV13AuditingObject);
         }
         GxWebStd.gx_hidden_field( context, "ITETOTALOPORTUNIDADES", StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 16, 2, ",", "")));
         GxWebStd.gx_hidden_field( context, "ITEQTDEOPORTUNIDADES", StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ",", "")));
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
         GXEncryptionTmp = "core.iteracao.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(AV7IteID.ToString());
         return formatLink("core.iteracao.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "core.Iteracao" ;
      }

      public override string GetPgmdesc( )
      {
         return "Itera��o" ;
      }

      protected void InitializeNonKey1238( )
      {
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         A591IteDelDataHora = (DateTime)(DateTime.MinValue);
         n591IteDelDataHora = false;
         AssignAttri("", false, "A591IteDelDataHora", context.localUtil.TToC( A591IteDelDataHora, 10, 12, 0, 3, "/", ":", " "));
         A592IteDelData = (DateTime)(DateTime.MinValue);
         n592IteDelData = false;
         AssignAttri("", false, "A592IteDelData", context.localUtil.TToC( A592IteDelData, 10, 5, 0, 3, "/", ":", " "));
         A593IteDelHora = (DateTime)(DateTime.MinValue);
         n593IteDelHora = false;
         AssignAttri("", false, "A593IteDelHora", context.localUtil.TToC( A593IteDelHora, 0, 5, 0, 3, "/", ":", " "));
         A594IteDelUsuId = "";
         n594IteDelUsuId = false;
         AssignAttri("", false, "A594IteDelUsuId", A594IteDelUsuId);
         A595IteDelUsuNome = "";
         n595IteDelUsuNome = false;
         AssignAttri("", false, "A595IteDelUsuNome", A595IteDelUsuNome);
         A431IteTotalOportunidades = 0;
         AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrimStr( A431IteTotalOportunidades, 16, 2));
         A432IteQtdeOportunidades = 0;
         AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrimStr( (decimal)(A432IteQtdeOportunidades), 8, 0));
         A382IteOrdem = 0;
         AssignAttri("", false, "A382IteOrdem", StringUtil.LTrimStr( (decimal)(A382IteOrdem), 8, 0));
         A383IteNome = "";
         AssignAttri("", false, "A383IteNome", A383IteNome);
         A590IteDel = false;
         AssignAttri("", false, "A590IteDel", A590IteDel);
         A384IteAtivo = true;
         AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
         O590IteDel = A590IteDel;
         AssignAttri("", false, "A590IteDel", A590IteDel);
         Z591IteDelDataHora = (DateTime)(DateTime.MinValue);
         Z592IteDelData = (DateTime)(DateTime.MinValue);
         Z593IteDelHora = (DateTime)(DateTime.MinValue);
         Z594IteDelUsuId = "";
         Z595IteDelUsuNome = "";
         Z382IteOrdem = 0;
         Z383IteNome = "";
         Z384IteAtivo = false;
         Z590IteDel = false;
      }

      protected void InitAll1238( )
      {
         A381IteID = Guid.Empty;
         AssignAttri("", false, "A381IteID", A381IteID.ToString());
         InitializeNonKey1238( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A384IteAtivo = i384IteAtivo;
         AssignAttri("", false, "A384IteAtivo", A384IteAtivo);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828145353", true, true);
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
         context.AddJavascriptSource("core/iteracao.js", "?2023828145354", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Shared/DVelopBootstrap.js", "", false, true);
         context.AddJavascriptSource("DVelop/Shared/WorkWithPlusCommon.js", "", false, true);
         context.AddJavascriptSource("DVelop/Bootstrap/Panel/BootstrapPanelRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         edtIteNome_Internalname = "ITENOME";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         Dvpanel_tableattributes_Internalname = "DVPANEL_TABLEATTRIBUTES";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtntrn_enter_Internalname = "BTNTRN_ENTER";
         bttBtntrn_cancel_Internalname = "BTNTRN_CANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         edtIteID_Internalname = "ITEID";
         edtIteOrdem_Internalname = "ITEORDEM";
         edtIteAtivo_Internalname = "ITEATIVO";
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
         Form.Caption = "Itera��o";
         edtIteAtivo_Jsonclick = "";
         edtIteAtivo_Enabled = 1;
         edtIteAtivo_Visible = 1;
         edtIteOrdem_Jsonclick = "";
         edtIteOrdem_Enabled = 1;
         edtIteOrdem_Visible = 1;
         edtIteID_Jsonclick = "";
         edtIteID_Enabled = 1;
         edtIteID_Visible = 1;
         bttBtntrn_cancel_Visible = 1;
         bttBtntrn_enter_Enabled = 1;
         bttBtntrn_enter_Visible = 1;
         edtIteNome_Jsonclick = "";
         edtIteNome_Enabled = 1;
         Dvpanel_tableattributes_Autoscroll = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Iconposition = "Right";
         Dvpanel_tableattributes_Showcollapseicon = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsed = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Collapsible = Convert.ToBoolean( 0);
         Dvpanel_tableattributes_Title = "Itera��o";
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

      protected void XC_12_1238( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 Guid A381IteID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
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

      protected void XC_13_1238( GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 Guid A381IteID ,
                                 string Gx_mode )
      {
         new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "Y", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
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

      protected void XC_14_1238( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 Guid A381IteID )
      {
         if ( IsIns( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
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

      protected void XC_15_1238( string Gx_mode ,
                                 GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ,
                                 Guid A381IteID )
      {
         if ( IsUpd( )  )
         {
            new GeneXus.Programs.core.loadaudititeracao(context ).execute(  "N", ref  AV13AuditingObject,  A381IteID,  Gx_mode) ;
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

      public void Valid_Iteid( )
      {
         /* Using cursor T001217 */
         pr_default.execute(12, new Object[] {A381IteID});
         if ( (pr_default.getStatus(12) != 101) )
         {
            A431IteTotalOportunidades = T001217_A431IteTotalOportunidades[0];
            A432IteQtdeOportunidades = T001217_A432IteQtdeOportunidades[0];
         }
         else
         {
            A431IteTotalOportunidades = 0;
            A432IteQtdeOportunidades = 0;
         }
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A431IteTotalOportunidades", StringUtil.LTrim( StringUtil.NToC( A431IteTotalOportunidades, 16, 2, ".", "")));
         AssignAttri("", false, "A432IteQtdeOportunidades", StringUtil.LTrim( StringUtil.NToC( (decimal)(A432IteQtdeOportunidades), 8, 0, ".", "")));
      }

      public void Valid_Iteordem( )
      {
         /* Using cursor T001220 */
         pr_default.execute(15, new Object[] {A382IteOrdem, A381IteID});
         if ( (pr_default.getStatus(15) != 101) )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_1004", new   object[]  {"Ordem"}), 1, "ITEORDEM");
            AnyError = 1;
            GX_FocusControl = edtIteOrdem_Internalname;
         }
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7IteID',fld:'vITEID',pic:'',hsh:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true},{av:'AV7IteID',fld:'vITEID',pic:'',hsh:true},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'A590IteDel',fld:'ITEDEL',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("AFTER TRN","{handler:'E12122',iparms:[{av:'AV13AuditingObject',fld:'vAUDITINGOBJECT',pic:''},{av:'AV14Pgmname',fld:'vPGMNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV11TrnContext',fld:'vTRNCONTEXT',pic:'',hsh:true}]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_ITENOME","{handler:'Valid_Itenome',iparms:[]");
         setEventMetadata("VALID_ITENOME",",oparms:[]}");
         setEventMetadata("VALID_ITEID","{handler:'Valid_Iteid',iparms:[{av:'A381IteID',fld:'ITEID',pic:''},{av:'A431IteTotalOportunidades',fld:'ITETOTALOPORTUNIDADES',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'A432IteQtdeOportunidades',fld:'ITEQTDEOPORTUNIDADES',pic:'ZZZZZZZ9'}]");
         setEventMetadata("VALID_ITEID",",oparms:[{av:'A431IteTotalOportunidades',fld:'ITETOTALOPORTUNIDADES',pic:'R$ Z,ZZZ,ZZZ,ZZZ,ZZ9.99'},{av:'A432IteQtdeOportunidades',fld:'ITEQTDEOPORTUNIDADES',pic:'ZZZZZZZ9'}]}");
         setEventMetadata("VALID_ITEORDEM","{handler:'Valid_Iteordem',iparms:[{av:'A382IteOrdem',fld:'ITEORDEM',pic:'ZZZZZZZ9'},{av:'A381IteID',fld:'ITEID',pic:''}]");
         setEventMetadata("VALID_ITEORDEM",",oparms:[]}");
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
         wcpOAV7IteID = Guid.Empty;
         Z381IteID = Guid.Empty;
         Z591IteDelDataHora = (DateTime)(DateTime.MinValue);
         Z592IteDelData = (DateTime)(DateTime.MinValue);
         Z593IteDelHora = (DateTime)(DateTime.MinValue);
         Z594IteDelUsuId = "";
         Z595IteDelUsuNome = "";
         Z383IteNome = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A381IteID = Guid.Empty;
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
         A383IteNome = "";
         bttBtntrn_enter_Jsonclick = "";
         bttBtntrn_cancel_Jsonclick = "";
         A591IteDelDataHora = (DateTime)(DateTime.MinValue);
         A592IteDelData = (DateTime)(DateTime.MinValue);
         A593IteDelHora = (DateTime)(DateTime.MinValue);
         A594IteDelUsuId = "";
         A595IteDelUsuNome = "";
         AV13AuditingObject = new GeneXus.Programs.wwpbaseobjects.SdtAuditingObject(context);
         AV14Pgmname = "";
         Dvpanel_tableattributes_Objectcall = "";
         Dvpanel_tableattributes_Class = "";
         Dvpanel_tableattributes_Height = "";
         forbiddenHiddens = new GXProperties();
         hsh = "";
         sMode38 = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         AV8WWPContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPContext(context);
         AV11TrnContext = new GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext(context);
         AV12WebSession = context.GetSession();
         T00125_A431IteTotalOportunidades = new decimal[1] ;
         T00125_A432IteQtdeOportunidades = new int[1] ;
         T00126_A381IteID = new Guid[] {Guid.Empty} ;
         T00126_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00126_n591IteDelDataHora = new bool[] {false} ;
         T00126_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         T00126_n592IteDelData = new bool[] {false} ;
         T00126_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         T00126_n593IteDelHora = new bool[] {false} ;
         T00126_A594IteDelUsuId = new string[] {""} ;
         T00126_n594IteDelUsuId = new bool[] {false} ;
         T00126_A595IteDelUsuNome = new string[] {""} ;
         T00126_n595IteDelUsuNome = new bool[] {false} ;
         T00126_A382IteOrdem = new int[1] ;
         T00126_A383IteNome = new string[] {""} ;
         T00126_A384IteAtivo = new bool[] {false} ;
         T00126_A590IteDel = new bool[] {false} ;
         T00127_A382IteOrdem = new int[1] ;
         T00129_A431IteTotalOportunidades = new decimal[1] ;
         T00129_A432IteQtdeOportunidades = new int[1] ;
         T001210_A381IteID = new Guid[] {Guid.Empty} ;
         T00123_A381IteID = new Guid[] {Guid.Empty} ;
         T00123_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00123_n591IteDelDataHora = new bool[] {false} ;
         T00123_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         T00123_n592IteDelData = new bool[] {false} ;
         T00123_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         T00123_n593IteDelHora = new bool[] {false} ;
         T00123_A594IteDelUsuId = new string[] {""} ;
         T00123_n594IteDelUsuId = new bool[] {false} ;
         T00123_A595IteDelUsuNome = new string[] {""} ;
         T00123_n595IteDelUsuNome = new bool[] {false} ;
         T00123_A382IteOrdem = new int[1] ;
         T00123_A383IteNome = new string[] {""} ;
         T00123_A384IteAtivo = new bool[] {false} ;
         T00123_A590IteDel = new bool[] {false} ;
         T001211_A381IteID = new Guid[] {Guid.Empty} ;
         T001212_A381IteID = new Guid[] {Guid.Empty} ;
         T00122_A381IteID = new Guid[] {Guid.Empty} ;
         T00122_A591IteDelDataHora = new DateTime[] {DateTime.MinValue} ;
         T00122_n591IteDelDataHora = new bool[] {false} ;
         T00122_A592IteDelData = new DateTime[] {DateTime.MinValue} ;
         T00122_n592IteDelData = new bool[] {false} ;
         T00122_A593IteDelHora = new DateTime[] {DateTime.MinValue} ;
         T00122_n593IteDelHora = new bool[] {false} ;
         T00122_A594IteDelUsuId = new string[] {""} ;
         T00122_n594IteDelUsuId = new bool[] {false} ;
         T00122_A595IteDelUsuNome = new string[] {""} ;
         T00122_n595IteDelUsuNome = new bool[] {false} ;
         T00122_A382IteOrdem = new int[1] ;
         T00122_A383IteNome = new string[] {""} ;
         T00122_A384IteAtivo = new bool[] {false} ;
         T00122_A590IteDel = new bool[] {false} ;
         T001217_A431IteTotalOportunidades = new decimal[1] ;
         T001217_A432IteQtdeOportunidades = new int[1] ;
         T001218_A345NegID = new Guid[] {Guid.Empty} ;
         T001218_A387NgfSeq = new int[1] ;
         T001219_A381IteID = new Guid[] {Guid.Empty} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXEncryptionTmp = "";
         T001220_A382IteOrdem = new int[1] ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.core.iteracao__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.core.iteracao__default(),
            new Object[][] {
                new Object[] {
               T00122_A381IteID, T00122_A591IteDelDataHora, T00122_n591IteDelDataHora, T00122_A592IteDelData, T00122_n592IteDelData, T00122_A593IteDelHora, T00122_n593IteDelHora, T00122_A594IteDelUsuId, T00122_n594IteDelUsuId, T00122_A595IteDelUsuNome,
               T00122_n595IteDelUsuNome, T00122_A382IteOrdem, T00122_A383IteNome, T00122_A384IteAtivo, T00122_A590IteDel
               }
               , new Object[] {
               T00123_A381IteID, T00123_A591IteDelDataHora, T00123_n591IteDelDataHora, T00123_A592IteDelData, T00123_n592IteDelData, T00123_A593IteDelHora, T00123_n593IteDelHora, T00123_A594IteDelUsuId, T00123_n594IteDelUsuId, T00123_A595IteDelUsuNome,
               T00123_n595IteDelUsuNome, T00123_A382IteOrdem, T00123_A383IteNome, T00123_A384IteAtivo, T00123_A590IteDel
               }
               , new Object[] {
               T00125_A431IteTotalOportunidades, T00125_A432IteQtdeOportunidades
               }
               , new Object[] {
               T00126_A381IteID, T00126_A591IteDelDataHora, T00126_n591IteDelDataHora, T00126_A592IteDelData, T00126_n592IteDelData, T00126_A593IteDelHora, T00126_n593IteDelHora, T00126_A594IteDelUsuId, T00126_n594IteDelUsuId, T00126_A595IteDelUsuNome,
               T00126_n595IteDelUsuNome, T00126_A382IteOrdem, T00126_A383IteNome, T00126_A384IteAtivo, T00126_A590IteDel
               }
               , new Object[] {
               T00127_A382IteOrdem
               }
               , new Object[] {
               T00129_A431IteTotalOportunidades, T00129_A432IteQtdeOportunidades
               }
               , new Object[] {
               T001210_A381IteID
               }
               , new Object[] {
               T001211_A381IteID
               }
               , new Object[] {
               T001212_A381IteID
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T001217_A431IteTotalOportunidades, T001217_A432IteQtdeOportunidades
               }
               , new Object[] {
               T001218_A345NegID, T001218_A387NgfSeq
               }
               , new Object[] {
               T001219_A381IteID
               }
               , new Object[] {
               T001220_A382IteOrdem
               }
            }
         );
         Z384IteAtivo = true;
         A384IteAtivo = true;
         i384IteAtivo = true;
         AV14Pgmname = "core.Iteracao";
      }

      private short GxWebError ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short RcdFound38 ;
      private short GX_JID ;
      private short nIsDirty_38 ;
      private short gxajaxcallmode ;
      private int Z382IteOrdem ;
      private int trnEnded ;
      private int edtIteNome_Enabled ;
      private int bttBtntrn_enter_Visible ;
      private int bttBtntrn_enter_Enabled ;
      private int bttBtntrn_cancel_Visible ;
      private int edtIteID_Visible ;
      private int edtIteID_Enabled ;
      private int A382IteOrdem ;
      private int edtIteOrdem_Enabled ;
      private int edtIteOrdem_Visible ;
      private int edtIteAtivo_Visible ;
      private int edtIteAtivo_Enabled ;
      private int A432IteQtdeOportunidades ;
      private int Dvpanel_tableattributes_Gxcontroltype ;
      private int idxLst ;
      private int Z432IteQtdeOportunidades ;
      private decimal A431IteTotalOportunidades ;
      private decimal Z431IteTotalOportunidades ;
      private string sPrefix ;
      private string wcpOGx_mode ;
      private string Z594IteDelUsuId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string GXDecQS ;
      private string Gx_mode ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtIteNome_Internalname ;
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
      private string edtIteNome_Jsonclick ;
      private string bttBtntrn_enter_Internalname ;
      private string bttBtntrn_enter_Jsonclick ;
      private string bttBtntrn_cancel_Internalname ;
      private string bttBtntrn_cancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string edtIteID_Internalname ;
      private string edtIteID_Jsonclick ;
      private string edtIteOrdem_Internalname ;
      private string edtIteOrdem_Jsonclick ;
      private string edtIteAtivo_Internalname ;
      private string edtIteAtivo_Jsonclick ;
      private string A594IteDelUsuId ;
      private string AV14Pgmname ;
      private string Dvpanel_tableattributes_Objectcall ;
      private string Dvpanel_tableattributes_Class ;
      private string Dvpanel_tableattributes_Height ;
      private string hsh ;
      private string sMode38 ;
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
      private DateTime Z591IteDelDataHora ;
      private DateTime Z592IteDelData ;
      private DateTime Z593IteDelHora ;
      private DateTime A591IteDelDataHora ;
      private DateTime A592IteDelData ;
      private DateTime A593IteDelHora ;
      private bool Z384IteAtivo ;
      private bool Z590IteDel ;
      private bool O590IteDel ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool Dvpanel_tableattributes_Autowidth ;
      private bool Dvpanel_tableattributes_Autoheight ;
      private bool Dvpanel_tableattributes_Collapsible ;
      private bool Dvpanel_tableattributes_Collapsed ;
      private bool Dvpanel_tableattributes_Showcollapseicon ;
      private bool Dvpanel_tableattributes_Autoscroll ;
      private bool A384IteAtivo ;
      private bool n591IteDelDataHora ;
      private bool n592IteDelData ;
      private bool n593IteDelHora ;
      private bool n594IteDelUsuId ;
      private bool n595IteDelUsuNome ;
      private bool A590IteDel ;
      private bool Dvpanel_tableattributes_Enabled ;
      private bool Dvpanel_tableattributes_Showheader ;
      private bool Dvpanel_tableattributes_Visible ;
      private bool returnInSub ;
      private bool Gx_longc ;
      private bool i384IteAtivo ;
      private string Z595IteDelUsuNome ;
      private string Z383IteNome ;
      private string A383IteNome ;
      private string A595IteDelUsuNome ;
      private Guid wcpOAV7IteID ;
      private Guid Z381IteID ;
      private Guid A381IteID ;
      private Guid AV7IteID ;
      private IGxSession AV12WebSession ;
      private GXProperties forbiddenHiddens ;
      private GXUserControl ucDvpanel_tableattributes ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private decimal[] T00125_A431IteTotalOportunidades ;
      private int[] T00125_A432IteQtdeOportunidades ;
      private Guid[] T00126_A381IteID ;
      private DateTime[] T00126_A591IteDelDataHora ;
      private bool[] T00126_n591IteDelDataHora ;
      private DateTime[] T00126_A592IteDelData ;
      private bool[] T00126_n592IteDelData ;
      private DateTime[] T00126_A593IteDelHora ;
      private bool[] T00126_n593IteDelHora ;
      private string[] T00126_A594IteDelUsuId ;
      private bool[] T00126_n594IteDelUsuId ;
      private string[] T00126_A595IteDelUsuNome ;
      private bool[] T00126_n595IteDelUsuNome ;
      private int[] T00126_A382IteOrdem ;
      private string[] T00126_A383IteNome ;
      private bool[] T00126_A384IteAtivo ;
      private bool[] T00126_A590IteDel ;
      private int[] T00127_A382IteOrdem ;
      private decimal[] T00129_A431IteTotalOportunidades ;
      private int[] T00129_A432IteQtdeOportunidades ;
      private Guid[] T001210_A381IteID ;
      private Guid[] T00123_A381IteID ;
      private DateTime[] T00123_A591IteDelDataHora ;
      private bool[] T00123_n591IteDelDataHora ;
      private DateTime[] T00123_A592IteDelData ;
      private bool[] T00123_n592IteDelData ;
      private DateTime[] T00123_A593IteDelHora ;
      private bool[] T00123_n593IteDelHora ;
      private string[] T00123_A594IteDelUsuId ;
      private bool[] T00123_n594IteDelUsuId ;
      private string[] T00123_A595IteDelUsuNome ;
      private bool[] T00123_n595IteDelUsuNome ;
      private int[] T00123_A382IteOrdem ;
      private string[] T00123_A383IteNome ;
      private bool[] T00123_A384IteAtivo ;
      private bool[] T00123_A590IteDel ;
      private Guid[] T001211_A381IteID ;
      private Guid[] T001212_A381IteID ;
      private Guid[] T00122_A381IteID ;
      private DateTime[] T00122_A591IteDelDataHora ;
      private bool[] T00122_n591IteDelDataHora ;
      private DateTime[] T00122_A592IteDelData ;
      private bool[] T00122_n592IteDelData ;
      private DateTime[] T00122_A593IteDelHora ;
      private bool[] T00122_n593IteDelHora ;
      private string[] T00122_A594IteDelUsuId ;
      private bool[] T00122_n594IteDelUsuId ;
      private string[] T00122_A595IteDelUsuNome ;
      private bool[] T00122_n595IteDelUsuNome ;
      private int[] T00122_A382IteOrdem ;
      private string[] T00122_A383IteNome ;
      private bool[] T00122_A384IteAtivo ;
      private bool[] T00122_A590IteDel ;
      private decimal[] T001217_A431IteTotalOportunidades ;
      private int[] T001217_A432IteQtdeOportunidades ;
      private Guid[] T001218_A345NegID ;
      private int[] T001218_A387NgfSeq ;
      private Guid[] T001219_A381IteID ;
      private int[] T001220_A382IteOrdem ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPContext AV8WWPContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtWWPTransactionContext AV11TrnContext ;
      private GeneXus.Programs.wwpbaseobjects.SdtAuditingObject AV13AuditingObject ;
   }

   public class iteracao__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class iteracao__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT00126;
        prmT00126 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00125;
        prmT00125 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00127;
        prmT00127 = new Object[] {
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00129;
        prmT00129 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001210;
        prmT001210 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00123;
        prmT00123 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001211;
        prmT001211 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001212;
        prmT001212 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT00122;
        prmT00122 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001213;
        prmT001213 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0) ,
        new ParDef("IteDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("IteDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("IteDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("IteDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("IteDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteNome",GXType.VarChar,80,0) ,
        new ParDef("IteAtivo",GXType.Boolean,4,0) ,
        new ParDef("IteDel",GXType.Boolean,4,0)
        };
        Object[] prmT001214;
        prmT001214 = new Object[] {
        new ParDef("IteDelDataHora",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("IteDelData",GXType.DateTime,10,5){Nullable=true} ,
        new ParDef("IteDelHora",GXType.DateTime,0,5){Nullable=true} ,
        new ParDef("IteDelUsuId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("IteDelUsuNome",GXType.VarChar,80,0){Nullable=true} ,
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteNome",GXType.VarChar,80,0) ,
        new ParDef("IteAtivo",GXType.Boolean,4,0) ,
        new ParDef("IteDel",GXType.Boolean,4,0) ,
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001215;
        prmT001215 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001218;
        prmT001218 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001219;
        prmT001219 = new Object[] {
        };
        Object[] prmT001217;
        prmT001217 = new Object[] {
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        Object[] prmT001220;
        prmT001220 = new Object[] {
        new ParDef("IteOrdem",GXType.Int32,8,0) ,
        new ParDef("IteID",GXType.UniqueIdentifier,36,0)
        };
        def= new CursorDef[] {
            new CursorDef("T00122", "SELECT IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel FROM tb_Iteracao WHERE IteID = :IteID  FOR UPDATE OF tb_Iteracao NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00122,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00123", "SELECT IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel FROM tb_Iteracao WHERE IteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00123,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00125", "SELECT COALESCE( T1.IteTotalOportunidades, 0) AS IteTotalOportunidades, COALESCE( T1.IteQtdeOportunidades, 0) AS IteQtdeOportunidades FROM (SELECT SUM(NegValorAtualizado) AS IteTotalOportunidades, COUNT(*) AS IteQtdeOportunidades FROM tb_negociopj WHERE NegUltIteID = :IteID ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00125,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00126", "SELECT TM1.IteID, TM1.IteDelDataHora, TM1.IteDelData, TM1.IteDelHora, TM1.IteDelUsuId, TM1.IteDelUsuNome, TM1.IteOrdem, TM1.IteNome, TM1.IteAtivo, TM1.IteDel FROM tb_Iteracao TM1 WHERE TM1.IteID = :IteID ORDER BY TM1.IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT00126,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00127", "SELECT IteOrdem FROM tb_Iteracao WHERE (IteOrdem = :IteOrdem) AND (Not ( IteID = :IteID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT00127,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00129", "SELECT COALESCE( T1.IteTotalOportunidades, 0) AS IteTotalOportunidades, COALESCE( T1.IteQtdeOportunidades, 0) AS IteQtdeOportunidades FROM (SELECT SUM(NegValorAtualizado) AS IteTotalOportunidades, COUNT(*) AS IteQtdeOportunidades FROM tb_negociopj WHERE NegUltIteID = :IteID ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT00129,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001210", "SELECT IteID FROM tb_Iteracao WHERE IteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001210,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001211", "SELECT IteID FROM tb_Iteracao WHERE ( IteID > :IteID) ORDER BY IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001211,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001212", "SELECT IteID FROM tb_Iteracao WHERE ( IteID < :IteID) ORDER BY IteID DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT001212,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001213", "SAVEPOINT gxupdate;INSERT INTO tb_Iteracao(IteID, IteDelDataHora, IteDelData, IteDelHora, IteDelUsuId, IteDelUsuNome, IteOrdem, IteNome, IteAtivo, IteDel) VALUES(:IteID, :IteDelDataHora, :IteDelData, :IteDelHora, :IteDelUsuId, :IteDelUsuNome, :IteOrdem, :IteNome, :IteAtivo, :IteDel);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT001213)
           ,new CursorDef("T001214", "SAVEPOINT gxupdate;UPDATE tb_Iteracao SET IteDelDataHora=:IteDelDataHora, IteDelData=:IteDelData, IteDelHora=:IteDelHora, IteDelUsuId=:IteDelUsuId, IteDelUsuNome=:IteDelUsuNome, IteOrdem=:IteOrdem, IteNome=:IteNome, IteAtivo=:IteAtivo, IteDel=:IteDel  WHERE IteID = :IteID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001214)
           ,new CursorDef("T001215", "SAVEPOINT gxupdate;DELETE FROM tb_Iteracao  WHERE IteID = :IteID;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT001215)
           ,new CursorDef("T001217", "SELECT COALESCE( T1.IteTotalOportunidades, 0) AS IteTotalOportunidades, COALESCE( T1.IteQtdeOportunidades, 0) AS IteQtdeOportunidades FROM (SELECT SUM(NegValorAtualizado) AS IteTotalOportunidades, COUNT(*) AS IteQtdeOportunidades FROM tb_negociopj WHERE NegUltIteID = :IteID ) T1 ",true, GxErrorMask.GX_NOMASK, false, this,prmT001217,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001218", "SELECT NegID, NgfSeq FROM tb_negociopj_fase WHERE NgfIteID = :IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001218,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T001219", "SELECT IteID FROM tb_Iteracao ORDER BY IteID ",true, GxErrorMask.GX_NOMASK, false, this,prmT001219,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T001220", "SELECT IteOrdem FROM tb_Iteracao WHERE (IteOrdem = :IteOrdem) AND (Not ( IteID = :IteID)) ",true, GxErrorMask.GX_NOMASK, false, this,prmT001220,1, GxCacheFrequency.OFF ,true,false )
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 2 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((int[]) buf[11])[0] = rslt.getInt(7);
              ((string[]) buf[12])[0] = rslt.getVarchar(8);
              ((bool[]) buf[13])[0] = rslt.getBool(9);
              ((bool[]) buf[14])[0] = rslt.getBool(10);
              return;
           case 4 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
           case 5 :
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
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
              ((decimal[]) buf[0])[0] = rslt.getDecimal(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 13 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              ((int[]) buf[1])[0] = rslt.getInt(2);
              return;
           case 14 :
              ((Guid[]) buf[0])[0] = rslt.getGuid(1);
              return;
           case 15 :
              ((int[]) buf[0])[0] = rslt.getInt(1);
              return;
     }
  }

}

}
