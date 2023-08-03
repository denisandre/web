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
namespace GeneXus.Programs.wwpbaseobjects.notifications.web {
   public class wwp_webnotification : GXDataArea
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
         gxfirstwebparm = GetNextPar( );
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A64WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
            n64WWPNotificationId = false;
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A64WWPNotificationId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A65WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A65WWPNotificationDefinitionId) ;
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
            gxfirstwebparm = GetNextPar( );
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxfullajaxEvt") == 0 )
         {
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxfirstwebparm = GetNextPar( );
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
         if ( String.IsNullOrEmpty(StringUtil.RTrim( context.GetCookie( "GX_SESSION_ID"))) )
         {
            gxcookieaux = context.SetCookie( "GX_SESSION_ID", Encrypt64( Crypto.GetEncryptionKey( ), Crypto.GetServerKey( )), "", (DateTime)(DateTime.MinValue), "", (short)(context.GetHttpSecure( )));
         }
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
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
            Form.Meta.addItem("description", "WWP_Web Notification", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_webnotification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_webnotification( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( )
      {
         executePrivate();
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         cmbWWPWebNotificationStatus = new GXCombobox();
         chkWWPWebNotificationReceived = new GXCheckbox();
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
            return "webnotification_Execute" ;
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
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A96WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0));
            AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         }
         A99WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A99WWPWebNotificationReceived));
         n99WWPWebNotificationReceived = false;
         AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
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
         GxWebStd.gx_div_start( context, divMaintable_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divTitlecontainer_Internalname, 1, 0, "px", 0, "px", "title-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Web Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         ClassString = "ErrorViewer";
         StyleString = "";
         GxWebStd.gx_msg_list( context, "", context.GX_msglist.DisplayMode, StyleString, ClassString, "", "false");
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
         GxWebStd.gx_div_start( context, divFormcontainer_Internalname, 1, 0, "px", 0, "px", "form-container", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divToolbarcell_Internalname, 1, 0, "px", 0, "px", "col-xs-12 col-sm-9 col-sm-offset-3 form__toolbar-cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group ActionGroup", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "btn-group", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 21,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-first";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell-advanced", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A89WWPWebNotificationId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPWebNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A89WWPWebNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A89WWPWebNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationTitle_Internalname, "Notification Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationTitle_Internalname, A84WWPWebNotificationTitle, StringUtil.RTrim( context.localUtil.Format( A84WWPWebNotificationTitle, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationTitle_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationTitle_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Notification Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Notification Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A66WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationMetadata_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "WWPNotification Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A102WWPNotificationMetadata, "", "", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionName_Internalname, "Notification Definition Internal Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A101WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A101WWPNotificationDefinitionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationText_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationText_Internalname, "Notification Text", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationText_Internalname, A85WWPWebNotificationText, StringUtil.RTrim( context.localUtil.Format( A85WWPWebNotificationText, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationText_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationText_Enabled, 0, "text", "", 80, "chr", 1, "row", 120, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationIcon_Internalname, "Notification Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationIcon_Internalname, A86WWPWebNotificationIcon, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPWebNotificationIcon_Enabled, 0, 80, "chr", 4, "row", 0, StyleString, ClassString, "", "", "255", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationClientId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationClientId_Internalname, "Client Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationClientId_Internalname, A95WWPWebNotificationClientId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPWebNotificationClientId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPWebNotificationStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPWebNotificationStatus_Internalname, "Notification Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPWebNotificationStatus, cmbWWPWebNotificationStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0)), 1, cmbWWPWebNotificationStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPWebNotificationStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "", true, 0, "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", (string)(cmbWWPWebNotificationStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationCreated_Internalname, "Notification Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationCreated_Internalname, context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A87WWPWebNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationScheduled_Internalname, "Notification Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationScheduled_Internalname, context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A100WWPWebNotificationScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationProcessed_Internalname, "Notification Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationProcessed_Internalname, context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A97WWPWebNotificationProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,94);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationRead_Internalname, "Notification Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPWebNotificationRead_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPWebNotificationRead_Internalname, context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A88WWPWebNotificationRead, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPWebNotificationRead_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPWebNotificationRead_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_bitmap( context, edtWWPWebNotificationRead_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPWebNotificationRead_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPWebNotificationDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPWebNotificationDetail_Internalname, "Notification Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 104,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPWebNotificationDetail_Internalname, A98WWPWebNotificationDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,104);\"", 0, 1, edtWWPWebNotificationDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPWebNotificationReceived_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPWebNotificationReceived_Internalname, "Notification Received", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 109,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPWebNotificationReceived_Internalname, StringUtil.BoolToStr( A99WWPWebNotificationReceived), "", "Notification Received", 1, chkWWPWebNotificationReceived.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(109, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,109);\"");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__actions--fixed", "end", "Middle", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-action-group", "start", "top", " "+"data-gx-actiongroup-type=\"toolbar\""+" ", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 114,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 116,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 118,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Web\\WWP_WebNotification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
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
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Z89WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z89WWPWebNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            Z84WWPWebNotificationTitle = cgiGet( "Z84WWPWebNotificationTitle");
            Z85WWPWebNotificationText = cgiGet( "Z85WWPWebNotificationText");
            Z86WWPWebNotificationIcon = cgiGet( "Z86WWPWebNotificationIcon");
            Z96WWPWebNotificationStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z96WWPWebNotificationStatus"), ",", "."), 18, MidpointRounding.ToEven));
            Z87WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( "Z87WWPWebNotificationCreated"), 0);
            Z100WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( "Z100WWPWebNotificationScheduled"), 0);
            Z97WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( "Z97WWPWebNotificationProcessed"), 0);
            Z88WWPWebNotificationRead = context.localUtil.CToT( cgiGet( "Z88WWPWebNotificationRead"), 0);
            n88WWPWebNotificationRead = ((DateTime.MinValue==A88WWPWebNotificationRead) ? true : false);
            Z99WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( "Z99WWPWebNotificationReceived"));
            n99WWPWebNotificationReceived = ((false==A99WWPWebNotificationReceived) ? true : false);
            Z64WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z64WWPNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            A65WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPNOTIFICATIONDEFINITIONID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPWEBNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A89WWPWebNotificationId = 0;
               AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
            }
            else
            {
               A89WWPWebNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPWebNotificationId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
            }
            A84WWPWebNotificationTitle = cgiGet( edtWWPWebNotificationTitle_Internalname);
            AssignAttri("", false, "A84WWPWebNotificationTitle", A84WWPWebNotificationTitle);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A64WWPNotificationId = 0;
               n64WWPNotificationId = false;
               AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            }
            else
            {
               A64WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n64WWPNotificationId = false;
               AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            }
            n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
            A66WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A102WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n102WWPNotificationMetadata = false;
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            A101WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            A85WWPWebNotificationText = cgiGet( edtWWPWebNotificationText_Internalname);
            AssignAttri("", false, "A85WWPWebNotificationText", A85WWPWebNotificationText);
            A86WWPWebNotificationIcon = cgiGet( edtWWPWebNotificationIcon_Internalname);
            AssignAttri("", false, "A86WWPWebNotificationIcon", A86WWPWebNotificationIcon);
            A95WWPWebNotificationClientId = cgiGet( edtWWPWebNotificationClientId_Internalname);
            AssignAttri("", false, "A95WWPWebNotificationClientId", A95WWPWebNotificationClientId);
            cmbWWPWebNotificationStatus.CurrentValue = cgiGet( cmbWWPWebNotificationStatus_Internalname);
            A96WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPWebNotificationStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Created"}), 1, "WWPWEBNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A87WWPWebNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPWebNotificationCreated_Internalname));
               AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Scheduled"}), 1, "WWPWEBNOTIFICATIONSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A100WWPWebNotificationScheduled = context.localUtil.CToT( cgiGet( edtWWPWebNotificationScheduled_Internalname));
               AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Processed"}), 1, "WWPWEBNOTIFICATIONPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A97WWPWebNotificationProcessed = context.localUtil.CToT( cgiGet( edtWWPWebNotificationProcessed_Internalname));
               AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPWebNotificationRead_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Web Notification Read"}), 1, "WWPWEBNOTIFICATIONREAD");
               AnyError = 1;
               GX_FocusControl = edtWWPWebNotificationRead_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
               n88WWPWebNotificationRead = false;
               AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A88WWPWebNotificationRead = context.localUtil.CToT( cgiGet( edtWWPWebNotificationRead_Internalname));
               n88WWPWebNotificationRead = false;
               AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            }
            n88WWPWebNotificationRead = ((DateTime.MinValue==A88WWPWebNotificationRead) ? true : false);
            A98WWPWebNotificationDetail = cgiGet( edtWWPWebNotificationDetail_Internalname);
            n98WWPWebNotificationDetail = false;
            AssignAttri("", false, "A98WWPWebNotificationDetail", A98WWPWebNotificationDetail);
            n98WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A98WWPWebNotificationDetail)) ? true : false);
            A99WWPWebNotificationReceived = StringUtil.StrToBool( cgiGet( chkWWPWebNotificationReceived_Internalname));
            n99WWPWebNotificationReceived = false;
            AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
            n99WWPWebNotificationReceived = ((false==A99WWPWebNotificationReceived) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A89WWPWebNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPWebNotificationId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
               getEqualNoModal( ) ;
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               disable_std_buttons_dsp( ) ;
               standaloneModal( ) ;
            }
            else
            {
               Gx_mode = "INS";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               standaloneModal( ) ;
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
                        if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_enter( ) ;
                           /* No code required for Cancel button. It is implemented as the Reset button. */
                        }
                        else if ( StringUtil.StrCmp(sEvt, "FIRST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_first( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "PREVIOUS") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_previous( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "NEXT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_next( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LAST") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_last( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "SELECT") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_select( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "DELETE") == 0 )
                        {
                           context.wbHandled = 1;
                           btn_delete( ) ;
                        }
                        else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                        {
                           context.wbHandled = 1;
                           AfterKeyLoadScreen( ) ;
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
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0A10( ) ;
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
         if ( IsIns( ) )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
      }

      protected void disable_std_buttons_dsp( )
      {
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         bttBtn_first_Visible = 0;
         AssignProp("", false, bttBtn_first_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_first_Visible), 5, 0), true);
         bttBtn_previous_Visible = 0;
         AssignProp("", false, bttBtn_previous_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_previous_Visible), 5, 0), true);
         bttBtn_next_Visible = 0;
         AssignProp("", false, bttBtn_next_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_next_Visible), 5, 0), true);
         bttBtn_last_Visible = 0;
         AssignProp("", false, bttBtn_last_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_last_Visible), 5, 0), true);
         bttBtn_select_Visible = 0;
         AssignProp("", false, bttBtn_select_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_select_Visible), 5, 0), true);
         bttBtn_delete_Visible = 0;
         AssignProp("", false, bttBtn_delete_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Visible), 5, 0), true);
         if ( IsDsp( ) )
         {
            bttBtn_enter_Visible = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Visible), 5, 0), true);
         }
         DisableAttributes0A10( ) ;
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

      protected void ResetCaption0A0( )
      {
      }

      protected void ZM0A10( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z84WWPWebNotificationTitle = T000A3_A84WWPWebNotificationTitle[0];
               Z85WWPWebNotificationText = T000A3_A85WWPWebNotificationText[0];
               Z86WWPWebNotificationIcon = T000A3_A86WWPWebNotificationIcon[0];
               Z96WWPWebNotificationStatus = T000A3_A96WWPWebNotificationStatus[0];
               Z87WWPWebNotificationCreated = T000A3_A87WWPWebNotificationCreated[0];
               Z100WWPWebNotificationScheduled = T000A3_A100WWPWebNotificationScheduled[0];
               Z97WWPWebNotificationProcessed = T000A3_A97WWPWebNotificationProcessed[0];
               Z88WWPWebNotificationRead = T000A3_A88WWPWebNotificationRead[0];
               Z99WWPWebNotificationReceived = T000A3_A99WWPWebNotificationReceived[0];
               Z64WWPNotificationId = T000A3_A64WWPNotificationId[0];
            }
            else
            {
               Z84WWPWebNotificationTitle = A84WWPWebNotificationTitle;
               Z85WWPWebNotificationText = A85WWPWebNotificationText;
               Z86WWPWebNotificationIcon = A86WWPWebNotificationIcon;
               Z96WWPWebNotificationStatus = A96WWPWebNotificationStatus;
               Z87WWPWebNotificationCreated = A87WWPWebNotificationCreated;
               Z100WWPWebNotificationScheduled = A100WWPWebNotificationScheduled;
               Z97WWPWebNotificationProcessed = A97WWPWebNotificationProcessed;
               Z88WWPWebNotificationRead = A88WWPWebNotificationRead;
               Z99WWPWebNotificationReceived = A99WWPWebNotificationReceived;
               Z64WWPNotificationId = A64WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
            Z84WWPWebNotificationTitle = A84WWPWebNotificationTitle;
            Z85WWPWebNotificationText = A85WWPWebNotificationText;
            Z86WWPWebNotificationIcon = A86WWPWebNotificationIcon;
            Z95WWPWebNotificationClientId = A95WWPWebNotificationClientId;
            Z96WWPWebNotificationStatus = A96WWPWebNotificationStatus;
            Z87WWPWebNotificationCreated = A87WWPWebNotificationCreated;
            Z100WWPWebNotificationScheduled = A100WWPWebNotificationScheduled;
            Z97WWPWebNotificationProcessed = A97WWPWebNotificationProcessed;
            Z88WWPWebNotificationRead = A88WWPWebNotificationRead;
            Z98WWPWebNotificationDetail = A98WWPWebNotificationDetail;
            Z99WWPWebNotificationReceived = A99WWPWebNotificationReceived;
            Z64WWPNotificationId = A64WWPNotificationId;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
            Z102WWPNotificationMetadata = A102WWPNotificationMetadata;
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A96WWPWebNotificationStatus) && ( Gx_BScreen == 0 ) )
         {
            A96WWPWebNotificationStatus = 1;
            AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A87WWPWebNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A100WWPWebNotificationScheduled) && ( Gx_BScreen == 0 ) )
         {
            A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            bttBtn_delete_Enabled = 0;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_delete_Enabled = 1;
            AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         }
         if ( StringUtil.StrCmp(Gx_mode, "DSP") == 0 )
         {
            bttBtn_enter_Enabled = 0;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         else
         {
            bttBtn_enter_Enabled = 1;
            AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         }
         if ( ( StringUtil.StrCmp(Gx_mode, "INS") == 0 ) && ( Gx_BScreen == 0 ) )
         {
         }
      }

      protected void Load0A10( )
      {
         /* Using cursor T000A6 */
         pr_default.execute(4, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound10 = 1;
            A65WWPNotificationDefinitionId = T000A6_A65WWPNotificationDefinitionId[0];
            A84WWPWebNotificationTitle = T000A6_A84WWPWebNotificationTitle[0];
            AssignAttri("", false, "A84WWPWebNotificationTitle", A84WWPWebNotificationTitle);
            A66WWPNotificationCreated = T000A6_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A102WWPNotificationMetadata = T000A6_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = T000A6_n102WWPNotificationMetadata[0];
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            A101WWPNotificationDefinitionName = T000A6_A101WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            A85WWPWebNotificationText = T000A6_A85WWPWebNotificationText[0];
            AssignAttri("", false, "A85WWPWebNotificationText", A85WWPWebNotificationText);
            A86WWPWebNotificationIcon = T000A6_A86WWPWebNotificationIcon[0];
            AssignAttri("", false, "A86WWPWebNotificationIcon", A86WWPWebNotificationIcon);
            A95WWPWebNotificationClientId = T000A6_A95WWPWebNotificationClientId[0];
            AssignAttri("", false, "A95WWPWebNotificationClientId", A95WWPWebNotificationClientId);
            A96WWPWebNotificationStatus = T000A6_A96WWPWebNotificationStatus[0];
            AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
            A87WWPWebNotificationCreated = T000A6_A87WWPWebNotificationCreated[0];
            AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A100WWPWebNotificationScheduled = T000A6_A100WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            A97WWPWebNotificationProcessed = T000A6_A97WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            A88WWPWebNotificationRead = T000A6_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = T000A6_n88WWPWebNotificationRead[0];
            AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            A98WWPWebNotificationDetail = T000A6_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = T000A6_n98WWPWebNotificationDetail[0];
            AssignAttri("", false, "A98WWPWebNotificationDetail", A98WWPWebNotificationDetail);
            A99WWPWebNotificationReceived = T000A6_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = T000A6_n99WWPWebNotificationReceived[0];
            AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
            A64WWPNotificationId = T000A6_A64WWPNotificationId[0];
            n64WWPNotificationId = T000A6_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            ZM0A10( -5) ;
         }
         pr_default.close(4);
         OnLoadActions0A10( ) ;
      }

      protected void OnLoadActions0A10( )
      {
      }

      protected void CheckExtendedTable0A10( )
      {
         nIsDirty_10 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000A4 */
         pr_default.execute(2, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A65WWPNotificationDefinitionId = T000A4_A65WWPNotificationDefinitionId[0];
         A66WWPNotificationCreated = T000A4_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A102WWPNotificationMetadata = T000A4_A102WWPNotificationMetadata[0];
         n102WWPNotificationMetadata = T000A4_n102WWPNotificationMetadata[0];
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         pr_default.close(2);
         /* Using cursor T000A5 */
         pr_default.execute(3, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( (0==A65WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A101WWPNotificationDefinitionName = T000A5_A101WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         pr_default.close(3);
         if ( ! ( ( A96WWPWebNotificationStatus == 1 ) || ( A96WWPWebNotificationStatus == 2 ) || ( A96WWPWebNotificationStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Web Notification Status fora do intervalo", "OutOfRange", 1, "WWPWEBNOTIFICATIONSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPWebNotificationStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors0A10( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A64WWPNotificationId )
      {
         /* Using cursor T000A7 */
         pr_default.execute(5, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A65WWPNotificationDefinitionId = T000A7_A65WWPNotificationDefinitionId[0];
         A66WWPNotificationCreated = T000A7_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A102WWPNotificationMetadata = T000A7_A102WWPNotificationMetadata[0];
         n102WWPNotificationMetadata = T000A7_n102WWPNotificationMetadata[0];
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\""+","+"\""+GXUtil.EncodeJSConstant( A102WWPNotificationMetadata)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_7( long A65WWPNotificationDefinitionId )
      {
         /* Using cursor T000A8 */
         pr_default.execute(6, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A65WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A101WWPNotificationDefinitionName = T000A8_A101WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A101WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0A10( )
      {
         /* Using cursor T000A9 */
         pr_default.execute(7, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound10 = 1;
         }
         else
         {
            RcdFound10 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000A3 */
         pr_default.execute(1, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0A10( 5) ;
            RcdFound10 = 1;
            A89WWPWebNotificationId = T000A3_A89WWPWebNotificationId[0];
            AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
            A84WWPWebNotificationTitle = T000A3_A84WWPWebNotificationTitle[0];
            AssignAttri("", false, "A84WWPWebNotificationTitle", A84WWPWebNotificationTitle);
            A85WWPWebNotificationText = T000A3_A85WWPWebNotificationText[0];
            AssignAttri("", false, "A85WWPWebNotificationText", A85WWPWebNotificationText);
            A86WWPWebNotificationIcon = T000A3_A86WWPWebNotificationIcon[0];
            AssignAttri("", false, "A86WWPWebNotificationIcon", A86WWPWebNotificationIcon);
            A95WWPWebNotificationClientId = T000A3_A95WWPWebNotificationClientId[0];
            AssignAttri("", false, "A95WWPWebNotificationClientId", A95WWPWebNotificationClientId);
            A96WWPWebNotificationStatus = T000A3_A96WWPWebNotificationStatus[0];
            AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
            A87WWPWebNotificationCreated = T000A3_A87WWPWebNotificationCreated[0];
            AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A100WWPWebNotificationScheduled = T000A3_A100WWPWebNotificationScheduled[0];
            AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
            A97WWPWebNotificationProcessed = T000A3_A97WWPWebNotificationProcessed[0];
            AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
            A88WWPWebNotificationRead = T000A3_A88WWPWebNotificationRead[0];
            n88WWPWebNotificationRead = T000A3_n88WWPWebNotificationRead[0];
            AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
            A98WWPWebNotificationDetail = T000A3_A98WWPWebNotificationDetail[0];
            n98WWPWebNotificationDetail = T000A3_n98WWPWebNotificationDetail[0];
            AssignAttri("", false, "A98WWPWebNotificationDetail", A98WWPWebNotificationDetail);
            A99WWPWebNotificationReceived = T000A3_A99WWPWebNotificationReceived[0];
            n99WWPWebNotificationReceived = T000A3_n99WWPWebNotificationReceived[0];
            AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
            A64WWPNotificationId = T000A3_A64WWPNotificationId[0];
            n64WWPNotificationId = T000A3_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            Z89WWPWebNotificationId = A89WWPWebNotificationId;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0A10( ) ;
            if ( AnyError == 1 )
            {
               RcdFound10 = 0;
               InitializeNonKey0A10( ) ;
            }
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound10 = 0;
            InitializeNonKey0A10( ) ;
            sMode10 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode10;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            Gx_mode = "INS";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         getByPrimaryKey( ) ;
      }

      protected void move_next( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A10 */
         pr_default.execute(8, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A89WWPWebNotificationId[0] < A89WWPWebNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000A10_A89WWPWebNotificationId[0] > A89WWPWebNotificationId ) ) )
            {
               A89WWPWebNotificationId = T000A10_A89WWPWebNotificationId[0];
               AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound10 = 0;
         /* Using cursor T000A11 */
         pr_default.execute(9, new Object[] {A89WWPWebNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000A11_A89WWPWebNotificationId[0] > A89WWPWebNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000A11_A89WWPWebNotificationId[0] < A89WWPWebNotificationId ) ) )
            {
               A89WWPWebNotificationId = T000A11_A89WWPWebNotificationId[0];
               AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
               RcdFound10 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0A10( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0A10( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound10 == 1 )
            {
               if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
               {
                  A89WWPWebNotificationId = Z89WWPWebNotificationId;
                  AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0A10( ) ;
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPWebNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0A10( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPWEBNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPWebNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0A10( ) ;
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
      }

      protected void btn_delete( )
      {
         if ( A89WWPWebNotificationId != Z89WWPWebNotificationId )
         {
            A89WWPWebNotificationId = Z89WWPWebNotificationId;
            AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         if ( AnyError != 0 )
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            getByPrimaryKey( ) ;
         }
         CloseOpenCursors();
      }

      protected void btn_get( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPWEBNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPWebNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_previous( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_previous( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_next( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         move_next( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_last( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0A10( ) ;
         if ( RcdFound10 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound10 != 0 )
            {
               ScanNext0A10( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0A10( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0A10( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000A2 */
            pr_default.execute(0, new Object[] {A89WWPWebNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z84WWPWebNotificationTitle, T000A2_A84WWPWebNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z85WWPWebNotificationText, T000A2_A85WWPWebNotificationText[0]) != 0 ) || ( StringUtil.StrCmp(Z86WWPWebNotificationIcon, T000A2_A86WWPWebNotificationIcon[0]) != 0 ) || ( Z96WWPWebNotificationStatus != T000A2_A96WWPWebNotificationStatus[0] ) || ( Z87WWPWebNotificationCreated != T000A2_A87WWPWebNotificationCreated[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z100WWPWebNotificationScheduled != T000A2_A100WWPWebNotificationScheduled[0] ) || ( Z97WWPWebNotificationProcessed != T000A2_A97WWPWebNotificationProcessed[0] ) || ( Z88WWPWebNotificationRead != T000A2_A88WWPWebNotificationRead[0] ) || ( Z99WWPWebNotificationReceived != T000A2_A99WWPWebNotificationReceived[0] ) || ( Z64WWPNotificationId != T000A2_A64WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z84WWPWebNotificationTitle, T000A2_A84WWPWebNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z84WWPWebNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A84WWPWebNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z85WWPWebNotificationText, T000A2_A85WWPWebNotificationText[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationText");
                  GXUtil.WriteLogRaw("Old: ",Z85WWPWebNotificationText);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A85WWPWebNotificationText[0]);
               }
               if ( StringUtil.StrCmp(Z86WWPWebNotificationIcon, T000A2_A86WWPWebNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z86WWPWebNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A86WWPWebNotificationIcon[0]);
               }
               if ( Z96WWPWebNotificationStatus != T000A2_A96WWPWebNotificationStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationStatus");
                  GXUtil.WriteLogRaw("Old: ",Z96WWPWebNotificationStatus);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A96WWPWebNotificationStatus[0]);
               }
               if ( Z87WWPWebNotificationCreated != T000A2_A87WWPWebNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z87WWPWebNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A87WWPWebNotificationCreated[0]);
               }
               if ( Z100WWPWebNotificationScheduled != T000A2_A100WWPWebNotificationScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z100WWPWebNotificationScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A100WWPWebNotificationScheduled[0]);
               }
               if ( Z97WWPWebNotificationProcessed != T000A2_A97WWPWebNotificationProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z97WWPWebNotificationProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A97WWPWebNotificationProcessed[0]);
               }
               if ( Z88WWPWebNotificationRead != T000A2_A88WWPWebNotificationRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationRead");
                  GXUtil.WriteLogRaw("Old: ",Z88WWPWebNotificationRead);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A88WWPWebNotificationRead[0]);
               }
               if ( Z99WWPWebNotificationReceived != T000A2_A99WWPWebNotificationReceived[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPWebNotificationReceived");
                  GXUtil.WriteLogRaw("Old: ",Z99WWPWebNotificationReceived);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A99WWPWebNotificationReceived[0]);
               }
               if ( Z64WWPNotificationId != T000A2_A64WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.web.wwp_webnotification:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z64WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000A2_A64WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_WebNotification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0A10( )
      {
         if ( ! IsAuthorized("webnotification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0A10( 0) ;
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A12 */
                     pr_default.execute(10, new Object[] {A84WWPWebNotificationTitle, A85WWPWebNotificationText, A86WWPWebNotificationIcon, A95WWPWebNotificationClientId, A96WWPWebNotificationStatus, A87WWPWebNotificationCreated, A100WWPWebNotificationScheduled, A97WWPWebNotificationProcessed, n88WWPWebNotificationRead, A88WWPWebNotificationRead, n98WWPWebNotificationDetail, A98WWPWebNotificationDetail, n99WWPWebNotificationReceived, A99WWPWebNotificationReceived, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000A13 */
                     pr_default.execute(11);
                     A89WWPWebNotificationId = T000A13_A89WWPWebNotificationId[0];
                     AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0A0( ) ;
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
               Load0A10( ) ;
            }
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void Update0A10( )
      {
         if ( ! IsAuthorized("webnotification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0A10( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0A10( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000A14 */
                     pr_default.execute(12, new Object[] {A84WWPWebNotificationTitle, A85WWPWebNotificationText, A86WWPWebNotificationIcon, A95WWPWebNotificationClientId, A96WWPWebNotificationStatus, A87WWPWebNotificationCreated, A100WWPWebNotificationScheduled, A97WWPWebNotificationProcessed, n88WWPWebNotificationRead, A88WWPWebNotificationRead, n98WWPWebNotificationDetail, A98WWPWebNotificationDetail, n99WWPWebNotificationReceived, A99WWPWebNotificationReceived, n64WWPNotificationId, A64WWPNotificationId, A89WWPWebNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_WebNotification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0A10( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0A0( ) ;
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
            EndLevel0A10( ) ;
         }
         CloseExtendedTableCursors0A10( ) ;
      }

      protected void DeferredUpdate0A10( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("webnotification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0A10( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0A10( ) ;
            AfterConfirm0A10( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0A10( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000A15 */
                  pr_default.execute(13, new Object[] {A89WWPWebNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_WebNotification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound10 == 0 )
                        {
                           InitAll0A10( ) ;
                           Gx_mode = "INS";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        else
                        {
                           getByPrimaryKey( ) ;
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                        }
                        endTrnMsgTxt = context.GetMessage( "GXM_sucdeleted", "");
                        endTrnMsgCod = "SuccessfullyDeleted";
                        ResetCaption0A0( ) ;
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
         sMode10 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0A10( ) ;
         Gx_mode = sMode10;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0A10( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000A16 */
            pr_default.execute(14, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A65WWPNotificationDefinitionId = T000A16_A65WWPNotificationDefinitionId[0];
            A66WWPNotificationCreated = T000A16_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A102WWPNotificationMetadata = T000A16_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = T000A16_n102WWPNotificationMetadata[0];
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            pr_default.close(14);
            /* Using cursor T000A17 */
            pr_default.execute(15, new Object[] {A65WWPNotificationDefinitionId});
            A101WWPNotificationDefinitionName = T000A17_A101WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            pr_default.close(15);
         }
      }

      protected void EndLevel0A10( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0A10( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0A0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.web.wwp_webnotification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0A10( )
      {
         /* Using cursor T000A18 */
         pr_default.execute(16);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound10 = 1;
            A89WWPWebNotificationId = T000A18_A89WWPWebNotificationId[0];
            AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0A10( )
      {
         /* Scan next routine */
         pr_default.readNext(16);
         RcdFound10 = 0;
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound10 = 1;
            A89WWPWebNotificationId = T000A18_A89WWPWebNotificationId[0];
            AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0A10( )
      {
         pr_default.close(16);
      }

      protected void AfterConfirm0A10( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0A10( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0A10( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0A10( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0A10( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0A10( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0A10( )
      {
         edtWWPWebNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationId_Enabled), 5, 0), true);
         edtWWPWebNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPWebNotificationText_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationText_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationText_Enabled), 5, 0), true);
         edtWWPWebNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationIcon_Enabled), 5, 0), true);
         edtWWPWebNotificationClientId_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationClientId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationClientId_Enabled), 5, 0), true);
         cmbWWPWebNotificationStatus.Enabled = 0;
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPWebNotificationStatus.Enabled), 5, 0), true);
         edtWWPWebNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationCreated_Enabled), 5, 0), true);
         edtWWPWebNotificationScheduled_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationScheduled_Enabled), 5, 0), true);
         edtWWPWebNotificationProcessed_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationProcessed_Enabled), 5, 0), true);
         edtWWPWebNotificationRead_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationRead_Enabled), 5, 0), true);
         edtWWPWebNotificationDetail_Enabled = 0;
         AssignProp("", false, edtWWPWebNotificationDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPWebNotificationDetail_Enabled), 5, 0), true);
         chkWWPWebNotificationReceived.Enabled = 0;
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPWebNotificationReceived.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0A10( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0A0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx") +"\">") ;
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
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "Z89WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z89WWPWebNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z84WWPWebNotificationTitle", Z84WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z85WWPWebNotificationText", Z85WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z86WWPWebNotificationIcon", Z86WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z96WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z96WWPWebNotificationStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z87WWPWebNotificationCreated", context.localUtil.TToC( Z87WWPWebNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z100WWPWebNotificationScheduled", context.localUtil.TToC( Z100WWPWebNotificationScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z97WWPWebNotificationProcessed", context.localUtil.TToC( Z97WWPWebNotificationProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z88WWPWebNotificationRead", context.localUtil.TToC( Z88WWPWebNotificationRead, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_boolean_hidden_field( context, "Z99WWPWebNotificationReceived", Z99WWPWebNotificationReceived);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPNOTIFICATIONDEFINITIONID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.notifications.web.wwp_webnotification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Web.WWP_WebNotification" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Web Notification" ;
      }

      protected void InitializeNonKey0A10( )
      {
         A65WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
         A84WWPWebNotificationTitle = "";
         AssignAttri("", false, "A84WWPWebNotificationTitle", A84WWPWebNotificationTitle);
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A102WWPNotificationMetadata = "";
         n102WWPNotificationMetadata = false;
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         A101WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         A85WWPWebNotificationText = "";
         AssignAttri("", false, "A85WWPWebNotificationText", A85WWPWebNotificationText);
         A86WWPWebNotificationIcon = "";
         AssignAttri("", false, "A86WWPWebNotificationIcon", A86WWPWebNotificationIcon);
         A95WWPWebNotificationClientId = "";
         AssignAttri("", false, "A95WWPWebNotificationClientId", A95WWPWebNotificationClientId);
         A97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         A88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         n88WWPWebNotificationRead = false;
         AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         n88WWPWebNotificationRead = ((DateTime.MinValue==A88WWPWebNotificationRead) ? true : false);
         A98WWPWebNotificationDetail = "";
         n98WWPWebNotificationDetail = false;
         AssignAttri("", false, "A98WWPWebNotificationDetail", A98WWPWebNotificationDetail);
         n98WWPWebNotificationDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A98WWPWebNotificationDetail)) ? true : false);
         A99WWPWebNotificationReceived = false;
         n99WWPWebNotificationReceived = false;
         AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
         n99WWPWebNotificationReceived = ((false==A99WWPWebNotificationReceived) ? true : false);
         A96WWPWebNotificationStatus = 1;
         AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z84WWPWebNotificationTitle = "";
         Z85WWPWebNotificationText = "";
         Z86WWPWebNotificationIcon = "";
         Z96WWPWebNotificationStatus = 0;
         Z87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         Z99WWPWebNotificationReceived = false;
         Z64WWPNotificationId = 0;
      }

      protected void InitAll0A10( )
      {
         A89WWPWebNotificationId = 0;
         AssignAttri("", false, "A89WWPWebNotificationId", StringUtil.LTrimStr( (decimal)(A89WWPWebNotificationId), 10, 0));
         InitializeNonKey0A10( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A96WWPWebNotificationStatus = i96WWPWebNotificationStatus;
         AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         A87WWPWebNotificationCreated = i87WWPWebNotificationCreated;
         AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A100WWPWebNotificationScheduled = i100WWPWebNotificationScheduled;
         AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828121299", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/web/wwp_webnotification.js", "?2023828121299", false, true);
         /* End function include_jscripts */
      }

      protected void init_default_properties( )
      {
         lblTitle_Internalname = "TITLE";
         divTitlecontainer_Internalname = "TITLECONTAINER";
         bttBtn_first_Internalname = "BTN_FIRST";
         bttBtn_previous_Internalname = "BTN_PREVIOUS";
         bttBtn_next_Internalname = "BTN_NEXT";
         bttBtn_last_Internalname = "BTN_LAST";
         bttBtn_select_Internalname = "BTN_SELECT";
         divToolbarcell_Internalname = "TOOLBARCELL";
         edtWWPWebNotificationId_Internalname = "WWPWEBNOTIFICATIONID";
         edtWWPWebNotificationTitle_Internalname = "WWPWEBNOTIFICATIONTITLE";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPWebNotificationText_Internalname = "WWPWEBNOTIFICATIONTEXT";
         edtWWPWebNotificationIcon_Internalname = "WWPWEBNOTIFICATIONICON";
         edtWWPWebNotificationClientId_Internalname = "WWPWEBNOTIFICATIONCLIENTID";
         cmbWWPWebNotificationStatus_Internalname = "WWPWEBNOTIFICATIONSTATUS";
         edtWWPWebNotificationCreated_Internalname = "WWPWEBNOTIFICATIONCREATED";
         edtWWPWebNotificationScheduled_Internalname = "WWPWEBNOTIFICATIONSCHEDULED";
         edtWWPWebNotificationProcessed_Internalname = "WWPWEBNOTIFICATIONPROCESSED";
         edtWWPWebNotificationRead_Internalname = "WWPWEBNOTIFICATIONREAD";
         edtWWPWebNotificationDetail_Internalname = "WWPWEBNOTIFICATIONDETAIL";
         chkWWPWebNotificationReceived_Internalname = "WWPWEBNOTIFICATIONRECEIVED";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
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
         Form.Caption = "WWP_Web Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPWebNotificationReceived.Enabled = 1;
         edtWWPWebNotificationDetail_Enabled = 1;
         edtWWPWebNotificationRead_Jsonclick = "";
         edtWWPWebNotificationRead_Enabled = 1;
         edtWWPWebNotificationProcessed_Jsonclick = "";
         edtWWPWebNotificationProcessed_Enabled = 1;
         edtWWPWebNotificationScheduled_Jsonclick = "";
         edtWWPWebNotificationScheduled_Enabled = 1;
         edtWWPWebNotificationCreated_Jsonclick = "";
         edtWWPWebNotificationCreated_Enabled = 1;
         cmbWWPWebNotificationStatus_Jsonclick = "";
         cmbWWPWebNotificationStatus.Enabled = 1;
         edtWWPWebNotificationClientId_Enabled = 1;
         edtWWPWebNotificationIcon_Enabled = 1;
         edtWWPWebNotificationText_Jsonclick = "";
         edtWWPWebNotificationText_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationMetadata_Enabled = 0;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPWebNotificationTitle_Jsonclick = "";
         edtWWPWebNotificationTitle_Enabled = 1;
         edtWWPWebNotificationId_Jsonclick = "";
         edtWWPWebNotificationId_Enabled = 1;
         bttBtn_select_Visible = 1;
         bttBtn_last_Visible = 1;
         bttBtn_next_Visible = 1;
         bttBtn_previous_Visible = 1;
         bttBtn_first_Visible = 1;
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

      protected void init_web_controls( )
      {
         cmbWWPWebNotificationStatus.Name = "WWPWEBNOTIFICATIONSTATUS";
         cmbWWPWebNotificationStatus.WebTags = "";
         cmbWWPWebNotificationStatus.addItem("1", "Pending", 0);
         cmbWWPWebNotificationStatus.addItem("2", "Sent", 0);
         cmbWWPWebNotificationStatus.addItem("3", "Error", 0);
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A96WWPWebNotificationStatus) )
            {
               A96WWPWebNotificationStatus = 1;
               AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0));
            }
         }
         chkWWPWebNotificationReceived.Name = "WWPWEBNOTIFICATIONRECEIVED";
         chkWWPWebNotificationReceived.WebTags = "";
         chkWWPWebNotificationReceived.Caption = "";
         AssignProp("", false, chkWWPWebNotificationReceived_Internalname, "TitleCaption", chkWWPWebNotificationReceived.Caption, true);
         chkWWPWebNotificationReceived.CheckedValue = "false";
         A99WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A99WWPWebNotificationReceived));
         n99WWPWebNotificationReceived = false;
         AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPWebNotificationTitle_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
         /* End function AfterKeyLoadScreen */
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

      public void Valid_Wwpwebnotificationid( )
      {
         A96WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPWebNotificationStatus.ItemCount > 0 )
         {
            A96WWPWebNotificationStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPWebNotificationStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A96WWPWebNotificationStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         }
         A99WWPWebNotificationReceived = StringUtil.StrToBool( StringUtil.BoolToStr( A99WWPWebNotificationReceived));
         n99WWPWebNotificationReceived = false;
         /*  Sending validation outputs */
         AssignAttri("", false, "A84WWPWebNotificationTitle", A84WWPWebNotificationTitle);
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A85WWPWebNotificationText", A85WWPWebNotificationText);
         AssignAttri("", false, "A86WWPWebNotificationIcon", A86WWPWebNotificationIcon);
         AssignAttri("", false, "A95WWPWebNotificationClientId", A95WWPWebNotificationClientId);
         AssignAttri("", false, "A96WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A96WWPWebNotificationStatus), 4, 0, ".", "")));
         cmbWWPWebNotificationStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A96WWPWebNotificationStatus), 4, 0));
         AssignProp("", false, cmbWWPWebNotificationStatus_Internalname, "Values", cmbWWPWebNotificationStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A87WWPWebNotificationCreated", context.localUtil.TToC( A87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A100WWPWebNotificationScheduled", context.localUtil.TToC( A100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A97WWPWebNotificationProcessed", context.localUtil.TToC( A97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A88WWPWebNotificationRead", context.localUtil.TToC( A88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A98WWPWebNotificationDetail", A98WWPWebNotificationDetail);
         AssignAttri("", false, "A99WWPWebNotificationReceived", A99WWPWebNotificationReceived);
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z89WWPWebNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z89WWPWebNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z84WWPWebNotificationTitle", Z84WWPWebNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z85WWPWebNotificationText", Z85WWPWebNotificationText);
         GxWebStd.gx_hidden_field( context, "Z86WWPWebNotificationIcon", Z86WWPWebNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z95WWPWebNotificationClientId", Z95WWPWebNotificationClientId);
         GxWebStd.gx_hidden_field( context, "Z96WWPWebNotificationStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z96WWPWebNotificationStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z87WWPWebNotificationCreated", context.localUtil.TToC( Z87WWPWebNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z100WWPWebNotificationScheduled", context.localUtil.TToC( Z100WWPWebNotificationScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z97WWPWebNotificationProcessed", context.localUtil.TToC( Z97WWPWebNotificationProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z88WWPWebNotificationRead", context.localUtil.TToC( Z88WWPWebNotificationRead, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z98WWPWebNotificationDetail", Z98WWPWebNotificationDetail);
         GxWebStd.gx_hidden_field( context, "Z99WWPWebNotificationReceived", StringUtil.BoolToStr( Z99WWPWebNotificationReceived));
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationCreated", context.localUtil.TToC( Z66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z102WWPNotificationMetadata", Z102WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z101WWPNotificationDefinitionName", Z101WWPNotificationDefinitionName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n64WWPNotificationId = false;
         n102WWPNotificationMetadata = false;
         /* Using cursor T000A16 */
         pr_default.execute(14, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A65WWPNotificationDefinitionId = T000A16_A65WWPNotificationDefinitionId[0];
         A66WWPNotificationCreated = T000A16_A66WWPNotificationCreated[0];
         A102WWPNotificationMetadata = T000A16_A102WWPNotificationMetadata[0];
         n102WWPNotificationMetadata = T000A16_n102WWPNotificationMetadata[0];
         pr_default.close(14);
         /* Using cursor T000A17 */
         pr_default.execute(15, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( (0==A65WWPNotificationDefinitionId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
            }
         }
         A101WWPNotificationDefinitionName = T000A17_A101WWPNotificationDefinitionName[0];
         pr_default.close(15);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID","{handler:'Valid_Wwpwebnotificationid',iparms:[{av:'A89WWPWebNotificationId',fld:'WWPWEBNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPWebNotificationStatus'},{av:'A96WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A87WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A100WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONID",",oparms:[{av:'A84WWPWebNotificationTitle',fld:'WWPWEBNOTIFICATIONTITLE',pic:''},{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A85WWPWebNotificationText',fld:'WWPWEBNOTIFICATIONTEXT',pic:''},{av:'A86WWPWebNotificationIcon',fld:'WWPWEBNOTIFICATIONICON',pic:''},{av:'A95WWPWebNotificationClientId',fld:'WWPWEBNOTIFICATIONCLIENTID',pic:''},{av:'cmbWWPWebNotificationStatus'},{av:'A96WWPWebNotificationStatus',fld:'WWPWEBNOTIFICATIONSTATUS',pic:'ZZZ9'},{av:'A87WWPWebNotificationCreated',fld:'WWPWEBNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A100WWPWebNotificationScheduled',fld:'WWPWEBNOTIFICATIONSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A97WWPWebNotificationProcessed',fld:'WWPWEBNOTIFICATIONPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A88WWPWebNotificationRead',fld:'WWPWEBNOTIFICATIONREAD',pic:'99/99/9999 99:99:99.999'},{av:'A98WWPWebNotificationDetail',fld:'WWPWEBNOTIFICATIONDETAIL',pic:''},{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A102WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z89WWPWebNotificationId'},{av:'Z84WWPWebNotificationTitle'},{av:'Z64WWPNotificationId'},{av:'Z85WWPWebNotificationText'},{av:'Z86WWPWebNotificationIcon'},{av:'Z95WWPWebNotificationClientId'},{av:'Z96WWPWebNotificationStatus'},{av:'Z87WWPWebNotificationCreated'},{av:'Z100WWPWebNotificationScheduled'},{av:'Z97WWPWebNotificationProcessed'},{av:'Z88WWPWebNotificationRead'},{av:'Z98WWPWebNotificationDetail'},{av:'Z99WWPWebNotificationReceived'},{av:'Z65WWPNotificationDefinitionId'},{av:'Z66WWPNotificationCreated'},{av:'Z102WWPNotificationMetadata'},{av:'Z101WWPNotificationDefinitionName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A102WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A102WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS","{handler:'Valid_Wwpwebnotificationstatus',iparms:[{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]");
         setEventMetadata("VALID_WWPWEBNOTIFICATIONSTATUS",",oparms:[{av:'A99WWPWebNotificationReceived',fld:'WWPWEBNOTIFICATIONRECEIVED',pic:''}]}");
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

      public override void initialize( )
      {
         sPrefix = "";
         Z84WWPWebNotificationTitle = "";
         Z85WWPWebNotificationText = "";
         Z86WWPWebNotificationIcon = "";
         Z87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         Z100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         Z97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         Z88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A84WWPWebNotificationTitle = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A102WWPNotificationMetadata = "";
         A101WWPNotificationDefinitionName = "";
         A85WWPWebNotificationText = "";
         A86WWPWebNotificationIcon = "";
         A95WWPWebNotificationClientId = "";
         A87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         A100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         A97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         A88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         A98WWPWebNotificationDetail = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gx_mode = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z95WWPWebNotificationClientId = "";
         Z98WWPWebNotificationDetail = "";
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z102WWPNotificationMetadata = "";
         Z101WWPNotificationDefinitionName = "";
         T000A6_A65WWPNotificationDefinitionId = new long[1] ;
         T000A6_A89WWPWebNotificationId = new long[1] ;
         T000A6_A84WWPWebNotificationTitle = new string[] {""} ;
         T000A6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A6_A102WWPNotificationMetadata = new string[] {""} ;
         T000A6_n102WWPNotificationMetadata = new bool[] {false} ;
         T000A6_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000A6_A85WWPWebNotificationText = new string[] {""} ;
         T000A6_A86WWPWebNotificationIcon = new string[] {""} ;
         T000A6_A95WWPWebNotificationClientId = new string[] {""} ;
         T000A6_A96WWPWebNotificationStatus = new short[1] ;
         T000A6_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A6_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A6_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A6_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000A6_n88WWPWebNotificationRead = new bool[] {false} ;
         T000A6_A98WWPWebNotificationDetail = new string[] {""} ;
         T000A6_n98WWPWebNotificationDetail = new bool[] {false} ;
         T000A6_A99WWPWebNotificationReceived = new bool[] {false} ;
         T000A6_n99WWPWebNotificationReceived = new bool[] {false} ;
         T000A6_A64WWPNotificationId = new long[1] ;
         T000A6_n64WWPNotificationId = new bool[] {false} ;
         T000A4_A65WWPNotificationDefinitionId = new long[1] ;
         T000A4_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A4_A102WWPNotificationMetadata = new string[] {""} ;
         T000A4_n102WWPNotificationMetadata = new bool[] {false} ;
         T000A5_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000A7_A65WWPNotificationDefinitionId = new long[1] ;
         T000A7_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A7_A102WWPNotificationMetadata = new string[] {""} ;
         T000A7_n102WWPNotificationMetadata = new bool[] {false} ;
         T000A8_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000A9_A89WWPWebNotificationId = new long[1] ;
         T000A3_A89WWPWebNotificationId = new long[1] ;
         T000A3_A84WWPWebNotificationTitle = new string[] {""} ;
         T000A3_A85WWPWebNotificationText = new string[] {""} ;
         T000A3_A86WWPWebNotificationIcon = new string[] {""} ;
         T000A3_A95WWPWebNotificationClientId = new string[] {""} ;
         T000A3_A96WWPWebNotificationStatus = new short[1] ;
         T000A3_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A3_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A3_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A3_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000A3_n88WWPWebNotificationRead = new bool[] {false} ;
         T000A3_A98WWPWebNotificationDetail = new string[] {""} ;
         T000A3_n98WWPWebNotificationDetail = new bool[] {false} ;
         T000A3_A99WWPWebNotificationReceived = new bool[] {false} ;
         T000A3_n99WWPWebNotificationReceived = new bool[] {false} ;
         T000A3_A64WWPNotificationId = new long[1] ;
         T000A3_n64WWPNotificationId = new bool[] {false} ;
         sMode10 = "";
         T000A10_A89WWPWebNotificationId = new long[1] ;
         T000A11_A89WWPWebNotificationId = new long[1] ;
         T000A2_A89WWPWebNotificationId = new long[1] ;
         T000A2_A84WWPWebNotificationTitle = new string[] {""} ;
         T000A2_A85WWPWebNotificationText = new string[] {""} ;
         T000A2_A86WWPWebNotificationIcon = new string[] {""} ;
         T000A2_A95WWPWebNotificationClientId = new string[] {""} ;
         T000A2_A96WWPWebNotificationStatus = new short[1] ;
         T000A2_A87WWPWebNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A2_A100WWPWebNotificationScheduled = new DateTime[] {DateTime.MinValue} ;
         T000A2_A97WWPWebNotificationProcessed = new DateTime[] {DateTime.MinValue} ;
         T000A2_A88WWPWebNotificationRead = new DateTime[] {DateTime.MinValue} ;
         T000A2_n88WWPWebNotificationRead = new bool[] {false} ;
         T000A2_A98WWPWebNotificationDetail = new string[] {""} ;
         T000A2_n98WWPWebNotificationDetail = new bool[] {false} ;
         T000A2_A99WWPWebNotificationReceived = new bool[] {false} ;
         T000A2_n99WWPWebNotificationReceived = new bool[] {false} ;
         T000A2_A64WWPNotificationId = new long[1] ;
         T000A2_n64WWPNotificationId = new bool[] {false} ;
         T000A13_A89WWPWebNotificationId = new long[1] ;
         T000A16_A65WWPNotificationDefinitionId = new long[1] ;
         T000A16_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000A16_A102WWPNotificationMetadata = new string[] {""} ;
         T000A16_n102WWPNotificationMetadata = new bool[] {false} ;
         T000A17_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000A18_A89WWPWebNotificationId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         i100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ84WWPWebNotificationTitle = "";
         ZZ85WWPWebNotificationText = "";
         ZZ86WWPWebNotificationIcon = "";
         ZZ95WWPWebNotificationClientId = "";
         ZZ87WWPWebNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ100WWPWebNotificationScheduled = (DateTime)(DateTime.MinValue);
         ZZ97WWPWebNotificationProcessed = (DateTime)(DateTime.MinValue);
         ZZ88WWPWebNotificationRead = (DateTime)(DateTime.MinValue);
         ZZ98WWPWebNotificationDetail = "";
         ZZ66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ102WWPNotificationMetadata = "";
         ZZ101WWPNotificationDefinitionName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.web.wwp_webnotification__default(),
            new Object[][] {
                new Object[] {
               T000A2_A89WWPWebNotificationId, T000A2_A84WWPWebNotificationTitle, T000A2_A85WWPWebNotificationText, T000A2_A86WWPWebNotificationIcon, T000A2_A95WWPWebNotificationClientId, T000A2_A96WWPWebNotificationStatus, T000A2_A87WWPWebNotificationCreated, T000A2_A100WWPWebNotificationScheduled, T000A2_A97WWPWebNotificationProcessed, T000A2_A88WWPWebNotificationRead,
               T000A2_n88WWPWebNotificationRead, T000A2_A98WWPWebNotificationDetail, T000A2_n98WWPWebNotificationDetail, T000A2_A99WWPWebNotificationReceived, T000A2_n99WWPWebNotificationReceived, T000A2_A64WWPNotificationId, T000A2_n64WWPNotificationId
               }
               , new Object[] {
               T000A3_A89WWPWebNotificationId, T000A3_A84WWPWebNotificationTitle, T000A3_A85WWPWebNotificationText, T000A3_A86WWPWebNotificationIcon, T000A3_A95WWPWebNotificationClientId, T000A3_A96WWPWebNotificationStatus, T000A3_A87WWPWebNotificationCreated, T000A3_A100WWPWebNotificationScheduled, T000A3_A97WWPWebNotificationProcessed, T000A3_A88WWPWebNotificationRead,
               T000A3_n88WWPWebNotificationRead, T000A3_A98WWPWebNotificationDetail, T000A3_n98WWPWebNotificationDetail, T000A3_A99WWPWebNotificationReceived, T000A3_n99WWPWebNotificationReceived, T000A3_A64WWPNotificationId, T000A3_n64WWPNotificationId
               }
               , new Object[] {
               T000A4_A65WWPNotificationDefinitionId, T000A4_A66WWPNotificationCreated, T000A4_A102WWPNotificationMetadata, T000A4_n102WWPNotificationMetadata
               }
               , new Object[] {
               T000A5_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000A6_A65WWPNotificationDefinitionId, T000A6_A89WWPWebNotificationId, T000A6_A84WWPWebNotificationTitle, T000A6_A66WWPNotificationCreated, T000A6_A102WWPNotificationMetadata, T000A6_n102WWPNotificationMetadata, T000A6_A101WWPNotificationDefinitionName, T000A6_A85WWPWebNotificationText, T000A6_A86WWPWebNotificationIcon, T000A6_A95WWPWebNotificationClientId,
               T000A6_A96WWPWebNotificationStatus, T000A6_A87WWPWebNotificationCreated, T000A6_A100WWPWebNotificationScheduled, T000A6_A97WWPWebNotificationProcessed, T000A6_A88WWPWebNotificationRead, T000A6_n88WWPWebNotificationRead, T000A6_A98WWPWebNotificationDetail, T000A6_n98WWPWebNotificationDetail, T000A6_A99WWPWebNotificationReceived, T000A6_n99WWPWebNotificationReceived,
               T000A6_A64WWPNotificationId, T000A6_n64WWPNotificationId
               }
               , new Object[] {
               T000A7_A65WWPNotificationDefinitionId, T000A7_A66WWPNotificationCreated, T000A7_A102WWPNotificationMetadata, T000A7_n102WWPNotificationMetadata
               }
               , new Object[] {
               T000A8_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000A9_A89WWPWebNotificationId
               }
               , new Object[] {
               T000A10_A89WWPWebNotificationId
               }
               , new Object[] {
               T000A11_A89WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000A13_A89WWPWebNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000A16_A65WWPNotificationDefinitionId, T000A16_A66WWPNotificationCreated, T000A16_A102WWPNotificationMetadata, T000A16_n102WWPNotificationMetadata
               }
               , new Object[] {
               T000A17_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000A18_A89WWPWebNotificationId
               }
            }
         );
         Z100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i100WWPWebNotificationScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i87WWPWebNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z96WWPWebNotificationStatus = 1;
         A96WWPWebNotificationStatus = 1;
         i96WWPWebNotificationStatus = 1;
      }

      private short Z96WWPWebNotificationStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A96WWPWebNotificationStatus ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound10 ;
      private short nIsDirty_10 ;
      private short gxajaxcallmode ;
      private short i96WWPWebNotificationStatus ;
      private short ZZ96WWPWebNotificationStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPWebNotificationId_Enabled ;
      private int edtWWPWebNotificationTitle_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPWebNotificationText_Enabled ;
      private int edtWWPWebNotificationIcon_Enabled ;
      private int edtWWPWebNotificationClientId_Enabled ;
      private int edtWWPWebNotificationCreated_Enabled ;
      private int edtWWPWebNotificationScheduled_Enabled ;
      private int edtWWPWebNotificationProcessed_Enabled ;
      private int edtWWPWebNotificationRead_Enabled ;
      private int edtWWPWebNotificationDetail_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z89WWPWebNotificationId ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private long A65WWPNotificationDefinitionId ;
      private long A89WWPWebNotificationId ;
      private long Z65WWPNotificationDefinitionId ;
      private long ZZ89WWPWebNotificationId ;
      private long ZZ64WWPNotificationId ;
      private long ZZ65WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPWebNotificationId_Internalname ;
      private string cmbWWPWebNotificationStatus_Internalname ;
      private string divMaintable_Internalname ;
      private string divTitlecontainer_Internalname ;
      private string lblTitle_Internalname ;
      private string lblTitle_Jsonclick ;
      private string ClassString ;
      private string StyleString ;
      private string divFormcontainer_Internalname ;
      private string divToolbarcell_Internalname ;
      private string TempTags ;
      private string bttBtn_first_Internalname ;
      private string bttBtn_first_Jsonclick ;
      private string bttBtn_previous_Internalname ;
      private string bttBtn_previous_Jsonclick ;
      private string bttBtn_next_Internalname ;
      private string bttBtn_next_Jsonclick ;
      private string bttBtn_last_Internalname ;
      private string bttBtn_last_Jsonclick ;
      private string bttBtn_select_Internalname ;
      private string bttBtn_select_Jsonclick ;
      private string edtWWPWebNotificationId_Jsonclick ;
      private string edtWWPWebNotificationTitle_Internalname ;
      private string edtWWPWebNotificationTitle_Jsonclick ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPWebNotificationText_Internalname ;
      private string edtWWPWebNotificationText_Jsonclick ;
      private string edtWWPWebNotificationIcon_Internalname ;
      private string edtWWPWebNotificationClientId_Internalname ;
      private string cmbWWPWebNotificationStatus_Jsonclick ;
      private string edtWWPWebNotificationCreated_Internalname ;
      private string edtWWPWebNotificationCreated_Jsonclick ;
      private string edtWWPWebNotificationScheduled_Internalname ;
      private string edtWWPWebNotificationScheduled_Jsonclick ;
      private string edtWWPWebNotificationProcessed_Internalname ;
      private string edtWWPWebNotificationProcessed_Jsonclick ;
      private string edtWWPWebNotificationRead_Internalname ;
      private string edtWWPWebNotificationRead_Jsonclick ;
      private string edtWWPWebNotificationDetail_Internalname ;
      private string chkWWPWebNotificationReceived_Internalname ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string Gx_mode ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode10 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z87WWPWebNotificationCreated ;
      private DateTime Z100WWPWebNotificationScheduled ;
      private DateTime Z97WWPWebNotificationProcessed ;
      private DateTime Z88WWPWebNotificationRead ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime A87WWPWebNotificationCreated ;
      private DateTime A100WWPWebNotificationScheduled ;
      private DateTime A97WWPWebNotificationProcessed ;
      private DateTime A88WWPWebNotificationRead ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime i87WWPWebNotificationCreated ;
      private DateTime i100WWPWebNotificationScheduled ;
      private DateTime ZZ87WWPWebNotificationCreated ;
      private DateTime ZZ100WWPWebNotificationScheduled ;
      private DateTime ZZ97WWPWebNotificationProcessed ;
      private DateTime ZZ88WWPWebNotificationRead ;
      private DateTime ZZ66WWPNotificationCreated ;
      private bool Z99WWPWebNotificationReceived ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n64WWPNotificationId ;
      private bool wbErr ;
      private bool A99WWPWebNotificationReceived ;
      private bool n99WWPWebNotificationReceived ;
      private bool n88WWPWebNotificationRead ;
      private bool n102WWPNotificationMetadata ;
      private bool n98WWPWebNotificationDetail ;
      private bool Gx_longc ;
      private bool ZZ99WWPWebNotificationReceived ;
      private string A102WWPNotificationMetadata ;
      private string A95WWPWebNotificationClientId ;
      private string A98WWPWebNotificationDetail ;
      private string Z95WWPWebNotificationClientId ;
      private string Z98WWPWebNotificationDetail ;
      private string Z102WWPNotificationMetadata ;
      private string ZZ95WWPWebNotificationClientId ;
      private string ZZ98WWPWebNotificationDetail ;
      private string ZZ102WWPNotificationMetadata ;
      private string Z84WWPWebNotificationTitle ;
      private string Z85WWPWebNotificationText ;
      private string Z86WWPWebNotificationIcon ;
      private string A84WWPWebNotificationTitle ;
      private string A101WWPNotificationDefinitionName ;
      private string A85WWPWebNotificationText ;
      private string A86WWPWebNotificationIcon ;
      private string Z101WWPNotificationDefinitionName ;
      private string ZZ84WWPWebNotificationTitle ;
      private string ZZ85WWPWebNotificationText ;
      private string ZZ86WWPWebNotificationIcon ;
      private string ZZ101WWPNotificationDefinitionName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPWebNotificationStatus ;
      private GXCheckbox chkWWPWebNotificationReceived ;
      private IDataStoreProvider pr_default ;
      private long[] T000A6_A65WWPNotificationDefinitionId ;
      private long[] T000A6_A89WWPWebNotificationId ;
      private string[] T000A6_A84WWPWebNotificationTitle ;
      private DateTime[] T000A6_A66WWPNotificationCreated ;
      private string[] T000A6_A102WWPNotificationMetadata ;
      private bool[] T000A6_n102WWPNotificationMetadata ;
      private string[] T000A6_A101WWPNotificationDefinitionName ;
      private string[] T000A6_A85WWPWebNotificationText ;
      private string[] T000A6_A86WWPWebNotificationIcon ;
      private string[] T000A6_A95WWPWebNotificationClientId ;
      private short[] T000A6_A96WWPWebNotificationStatus ;
      private DateTime[] T000A6_A87WWPWebNotificationCreated ;
      private DateTime[] T000A6_A100WWPWebNotificationScheduled ;
      private DateTime[] T000A6_A97WWPWebNotificationProcessed ;
      private DateTime[] T000A6_A88WWPWebNotificationRead ;
      private bool[] T000A6_n88WWPWebNotificationRead ;
      private string[] T000A6_A98WWPWebNotificationDetail ;
      private bool[] T000A6_n98WWPWebNotificationDetail ;
      private bool[] T000A6_A99WWPWebNotificationReceived ;
      private bool[] T000A6_n99WWPWebNotificationReceived ;
      private long[] T000A6_A64WWPNotificationId ;
      private bool[] T000A6_n64WWPNotificationId ;
      private long[] T000A4_A65WWPNotificationDefinitionId ;
      private DateTime[] T000A4_A66WWPNotificationCreated ;
      private string[] T000A4_A102WWPNotificationMetadata ;
      private bool[] T000A4_n102WWPNotificationMetadata ;
      private string[] T000A5_A101WWPNotificationDefinitionName ;
      private long[] T000A7_A65WWPNotificationDefinitionId ;
      private DateTime[] T000A7_A66WWPNotificationCreated ;
      private string[] T000A7_A102WWPNotificationMetadata ;
      private bool[] T000A7_n102WWPNotificationMetadata ;
      private string[] T000A8_A101WWPNotificationDefinitionName ;
      private long[] T000A9_A89WWPWebNotificationId ;
      private long[] T000A3_A89WWPWebNotificationId ;
      private string[] T000A3_A84WWPWebNotificationTitle ;
      private string[] T000A3_A85WWPWebNotificationText ;
      private string[] T000A3_A86WWPWebNotificationIcon ;
      private string[] T000A3_A95WWPWebNotificationClientId ;
      private short[] T000A3_A96WWPWebNotificationStatus ;
      private DateTime[] T000A3_A87WWPWebNotificationCreated ;
      private DateTime[] T000A3_A100WWPWebNotificationScheduled ;
      private DateTime[] T000A3_A97WWPWebNotificationProcessed ;
      private DateTime[] T000A3_A88WWPWebNotificationRead ;
      private bool[] T000A3_n88WWPWebNotificationRead ;
      private string[] T000A3_A98WWPWebNotificationDetail ;
      private bool[] T000A3_n98WWPWebNotificationDetail ;
      private bool[] T000A3_A99WWPWebNotificationReceived ;
      private bool[] T000A3_n99WWPWebNotificationReceived ;
      private long[] T000A3_A64WWPNotificationId ;
      private bool[] T000A3_n64WWPNotificationId ;
      private long[] T000A10_A89WWPWebNotificationId ;
      private long[] T000A11_A89WWPWebNotificationId ;
      private long[] T000A2_A89WWPWebNotificationId ;
      private string[] T000A2_A84WWPWebNotificationTitle ;
      private string[] T000A2_A85WWPWebNotificationText ;
      private string[] T000A2_A86WWPWebNotificationIcon ;
      private string[] T000A2_A95WWPWebNotificationClientId ;
      private short[] T000A2_A96WWPWebNotificationStatus ;
      private DateTime[] T000A2_A87WWPWebNotificationCreated ;
      private DateTime[] T000A2_A100WWPWebNotificationScheduled ;
      private DateTime[] T000A2_A97WWPWebNotificationProcessed ;
      private DateTime[] T000A2_A88WWPWebNotificationRead ;
      private bool[] T000A2_n88WWPWebNotificationRead ;
      private string[] T000A2_A98WWPWebNotificationDetail ;
      private bool[] T000A2_n98WWPWebNotificationDetail ;
      private bool[] T000A2_A99WWPWebNotificationReceived ;
      private bool[] T000A2_n99WWPWebNotificationReceived ;
      private long[] T000A2_A64WWPNotificationId ;
      private bool[] T000A2_n64WWPNotificationId ;
      private long[] T000A13_A89WWPWebNotificationId ;
      private long[] T000A16_A65WWPNotificationDefinitionId ;
      private DateTime[] T000A16_A66WWPNotificationCreated ;
      private string[] T000A16_A102WWPNotificationMetadata ;
      private bool[] T000A16_n102WWPNotificationMetadata ;
      private string[] T000A17_A101WWPNotificationDefinitionName ;
      private long[] T000A18_A89WWPWebNotificationId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_webnotification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_webnotification__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new UpdateCursor(def[13])
       ,new ForEachCursor(def[14])
       ,new ForEachCursor(def[15])
       ,new ForEachCursor(def[16])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000A6;
        prmT000A6 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A4;
        prmT000A4 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000A5;
        prmT000A5 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000A7;
        prmT000A7 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000A8;
        prmT000A8 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000A9;
        prmT000A9 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A3;
        prmT000A3 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A10;
        prmT000A10 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A11;
        prmT000A11 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A2;
        prmT000A2 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A12;
        prmT000A12 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000A13;
        prmT000A13 = new Object[] {
        };
        Object[] prmT000A14;
        prmT000A14 = new Object[] {
        new ParDef("WWPWebNotificationTitle",GXType.VarChar,40,0) ,
        new ParDef("WWPWebNotificationText",GXType.VarChar,120,0) ,
        new ParDef("WWPWebNotificationIcon",GXType.VarChar,255,0) ,
        new ParDef("WWPWebNotificationClientId",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPWebNotificationStatus",GXType.Int16,4,0) ,
        new ParDef("WWPWebNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationProcessed",GXType.DateTime2,10,12) ,
        new ParDef("WWPWebNotificationRead",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPWebNotificationDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPWebNotificationReceived",GXType.Boolean,4,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A15;
        prmT000A15 = new Object[] {
        new ParDef("WWPWebNotificationId",GXType.Int64,10,0)
        };
        Object[] prmT000A18;
        prmT000A18 = new Object[] {
        };
        Object[] prmT000A16;
        prmT000A16 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000A17;
        prmT000A17 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000A2", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId  FOR UPDATE OF WWP_WebNotification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000A2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A3", "SELECT WWPWebNotificationId, WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A4", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A5", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A6", "SELECT T2.WWPNotificationDefinitionId, TM1.WWPWebNotificationId, TM1.WWPWebNotificationTitle, T2.WWPNotificationCreated, T2.WWPNotificationMetadata, T3.WWPNotificationDefinitionName, TM1.WWPWebNotificationText, TM1.WWPWebNotificationIcon, TM1.WWPWebNotificationClientId, TM1.WWPWebNotificationStatus, TM1.WWPWebNotificationCreated, TM1.WWPWebNotificationScheduled, TM1.WWPWebNotificationProcessed, TM1.WWPWebNotificationRead, TM1.WWPWebNotificationDetail, TM1.WWPWebNotificationReceived, TM1.WWPNotificationId FROM ((WWP_WebNotification TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) LEFT JOIN WWP_NotificationDefinition T3 ON T3.WWPNotificationDefinitionId = T2.WWPNotificationDefinitionId) WHERE TM1.WWPWebNotificationId = :WWPWebNotificationId ORDER BY TM1.WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A7", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A8", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A9", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPWebNotificationId = :WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A10", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId > :WWPWebNotificationId) ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A11", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE ( WWPWebNotificationId < :WWPWebNotificationId) ORDER BY WWPWebNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000A12", "SAVEPOINT gxupdate;INSERT INTO WWP_WebNotification(WWPWebNotificationTitle, WWPWebNotificationText, WWPWebNotificationIcon, WWPWebNotificationClientId, WWPWebNotificationStatus, WWPWebNotificationCreated, WWPWebNotificationScheduled, WWPWebNotificationProcessed, WWPWebNotificationRead, WWPWebNotificationDetail, WWPWebNotificationReceived, WWPNotificationId) VALUES(:WWPWebNotificationTitle, :WWPWebNotificationText, :WWPWebNotificationIcon, :WWPWebNotificationClientId, :WWPWebNotificationStatus, :WWPWebNotificationCreated, :WWPWebNotificationScheduled, :WWPWebNotificationProcessed, :WWPWebNotificationRead, :WWPWebNotificationDetail, :WWPWebNotificationReceived, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000A12)
           ,new CursorDef("T000A13", "SELECT currval('WWPWebNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A14", "SAVEPOINT gxupdate;UPDATE WWP_WebNotification SET WWPWebNotificationTitle=:WWPWebNotificationTitle, WWPWebNotificationText=:WWPWebNotificationText, WWPWebNotificationIcon=:WWPWebNotificationIcon, WWPWebNotificationClientId=:WWPWebNotificationClientId, WWPWebNotificationStatus=:WWPWebNotificationStatus, WWPWebNotificationCreated=:WWPWebNotificationCreated, WWPWebNotificationScheduled=:WWPWebNotificationScheduled, WWPWebNotificationProcessed=:WWPWebNotificationProcessed, WWPWebNotificationRead=:WWPWebNotificationRead, WWPWebNotificationDetail=:WWPWebNotificationDetail, WWPWebNotificationReceived=:WWPWebNotificationReceived, WWPNotificationId=:WWPNotificationId  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A14)
           ,new CursorDef("T000A15", "SAVEPOINT gxupdate;DELETE FROM WWP_WebNotification  WHERE WWPWebNotificationId = :WWPWebNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000A15)
           ,new CursorDef("T000A16", "SELECT WWPNotificationDefinitionId, WWPNotificationCreated, WWPNotificationMetadata FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A17", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000A18", "SELECT WWPWebNotificationId FROM WWP_WebNotification ORDER BY WWPWebNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000A18,100, GxCacheFrequency.OFF ,true,false )
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
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((short[]) buf[5])[0] = rslt.getShort(6);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((DateTime[]) buf[8])[0] = rslt.getGXDateTime(9, true);
              ((DateTime[]) buf[9])[0] = rslt.getGXDateTime(10, true);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getLongVarchar(11);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              ((bool[]) buf[13])[0] = rslt.getBool(12);
              ((bool[]) buf[14])[0] = rslt.wasNull(12);
              ((long[]) buf[15])[0] = rslt.getLong(13);
              ((bool[]) buf[16])[0] = rslt.wasNull(13);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((DateTime[]) buf[3])[0] = rslt.getGXDateTime(4, true);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[5])[0] = rslt.wasNull(5);
              ((string[]) buf[6])[0] = rslt.getVarchar(6);
              ((string[]) buf[7])[0] = rslt.getVarchar(7);
              ((string[]) buf[8])[0] = rslt.getVarchar(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((short[]) buf[10])[0] = rslt.getShort(10);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(12, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(13, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(14, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(14);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(15);
              ((bool[]) buf[17])[0] = rslt.wasNull(15);
              ((bool[]) buf[18])[0] = rslt.getBool(16);
              ((bool[]) buf[19])[0] = rslt.wasNull(16);
              ((long[]) buf[20])[0] = rslt.getLong(17);
              ((bool[]) buf[21])[0] = rslt.wasNull(17);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 6 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 8 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((bool[]) buf[3])[0] = rslt.wasNull(3);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
