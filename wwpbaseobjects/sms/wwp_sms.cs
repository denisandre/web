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
namespace GeneXus.Programs.wwpbaseobjects.sms {
   public class wwp_sms : GXDataArea
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
            Form.Meta.addItem("description", "WWP_SMS", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_sms( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_sms( IGxContext context )
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
         cmbWWPSMSStatus = new GXCombobox();
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
            return "sms_Execute" ;
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
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A76WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0));
            AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_SMS", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSMSId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A75WWPSMSId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPSMSId_Enabled!=0) ? context.localUtil.Format( (decimal)(A75WWPSMSId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A75WWPSMSId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSMessage_Internalname, A79WWPSMSMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", 0, 1, edtWWPSMSMessage_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSSenderNumber_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSSenderNumber_Internalname, "Sender Number", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSSenderNumber_Internalname, A80WWPSMSSenderNumber, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 0, 1, edtWWPSMSSenderNumber_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSRecipientNumbers_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSRecipientNumbers_Internalname, "Recipient Numbers", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSRecipientNumbers_Internalname, A81WWPSMSRecipientNumbers, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPSMSRecipientNumbers_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPSMSStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPSMSStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPSMSStatus, cmbWWPSMSStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0)), 1, cmbWWPSMSStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPSMSStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "", true, 0, "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", (string)(cmbWWPSMSStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSCreated_Internalname, context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A82WWPSMSCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSScheduled_Internalname, context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A83WWPSMSScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPSMSProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPSMSProcessed_Internalname, context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A77WWPSMSProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSMSProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSMSProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPSMSProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPSMSProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSMSDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSMSDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSMSDetail_Internalname, A78WWPSMSDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", 0, 1, edtWWPSMSDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A66WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         context.WriteHtmlTextNl( "</div>") ;
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 91,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\SMS\\WWP_SMS.htm");
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
            Z75WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z75WWPSMSId"), ",", "."), 18, MidpointRounding.ToEven));
            Z76WWPSMSStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z76WWPSMSStatus"), ",", "."), 18, MidpointRounding.ToEven));
            Z82WWPSMSCreated = context.localUtil.CToT( cgiGet( "Z82WWPSMSCreated"), 0);
            Z83WWPSMSScheduled = context.localUtil.CToT( cgiGet( "Z83WWPSMSScheduled"), 0);
            Z77WWPSMSProcessed = context.localUtil.CToT( cgiGet( "Z77WWPSMSProcessed"), 0);
            n77WWPSMSProcessed = ((DateTime.MinValue==A77WWPSMSProcessed) ? true : false);
            Z64WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z64WWPNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSMSID");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A75WWPSMSId = 0;
               AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
            }
            else
            {
               A75WWPSMSId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSMSId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
            }
            A79WWPSMSMessage = cgiGet( edtWWPSMSMessage_Internalname);
            AssignAttri("", false, "A79WWPSMSMessage", A79WWPSMSMessage);
            A80WWPSMSSenderNumber = cgiGet( edtWWPSMSSenderNumber_Internalname);
            AssignAttri("", false, "A80WWPSMSSenderNumber", A80WWPSMSSenderNumber);
            A81WWPSMSRecipientNumbers = cgiGet( edtWWPSMSRecipientNumbers_Internalname);
            AssignAttri("", false, "A81WWPSMSRecipientNumbers", A81WWPSMSRecipientNumbers);
            cmbWWPSMSStatus.CurrentValue = cgiGet( cmbWWPSMSStatus_Internalname);
            A76WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPSMSStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Created"}), 1, "WWPSMSCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A82WWPSMSCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A82WWPSMSCreated = context.localUtil.CToT( cgiGet( edtWWPSMSCreated_Internalname));
               AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Scheduled"}), 1, "WWPSMSSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A83WWPSMSScheduled = context.localUtil.CToT( cgiGet( edtWWPSMSScheduled_Internalname));
               AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPSMSProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"SMS Processed"}), 1, "WWPSMSPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPSMSProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
               n77WWPSMSProcessed = false;
               AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A77WWPSMSProcessed = context.localUtil.CToT( cgiGet( edtWWPSMSProcessed_Internalname));
               n77WWPSMSProcessed = false;
               AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            n77WWPSMSProcessed = ((DateTime.MinValue==A77WWPSMSProcessed) ? true : false);
            A78WWPSMSDetail = cgiGet( edtWWPSMSDetail_Internalname);
            n78WWPSMSDetail = false;
            AssignAttri("", false, "A78WWPSMSDetail", A78WWPSMSDetail);
            n78WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A78WWPSMSDetail)) ? true : false);
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
               A75WWPSMSId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSMSId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
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
               InitAll099( ) ;
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
         DisableAttributes099( ) ;
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

      protected void ResetCaption090( )
      {
      }

      protected void ZM099( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z76WWPSMSStatus = T00093_A76WWPSMSStatus[0];
               Z82WWPSMSCreated = T00093_A82WWPSMSCreated[0];
               Z83WWPSMSScheduled = T00093_A83WWPSMSScheduled[0];
               Z77WWPSMSProcessed = T00093_A77WWPSMSProcessed[0];
               Z64WWPNotificationId = T00093_A64WWPNotificationId[0];
            }
            else
            {
               Z76WWPSMSStatus = A76WWPSMSStatus;
               Z82WWPSMSCreated = A82WWPSMSCreated;
               Z83WWPSMSScheduled = A83WWPSMSScheduled;
               Z77WWPSMSProcessed = A77WWPSMSProcessed;
               Z64WWPNotificationId = A64WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z75WWPSMSId = A75WWPSMSId;
            Z79WWPSMSMessage = A79WWPSMSMessage;
            Z80WWPSMSSenderNumber = A80WWPSMSSenderNumber;
            Z81WWPSMSRecipientNumbers = A81WWPSMSRecipientNumbers;
            Z76WWPSMSStatus = A76WWPSMSStatus;
            Z82WWPSMSCreated = A82WWPSMSCreated;
            Z83WWPSMSScheduled = A83WWPSMSScheduled;
            Z77WWPSMSProcessed = A77WWPSMSProcessed;
            Z78WWPSMSDetail = A78WWPSMSDetail;
            Z64WWPNotificationId = A64WWPNotificationId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (0==A76WWPSMSStatus) && ( Gx_BScreen == 0 ) )
         {
            A76WWPSMSStatus = 1;
            AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A82WWPSMSCreated) && ( Gx_BScreen == 0 ) )
         {
            A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A83WWPSMSScheduled) && ( Gx_BScreen == 0 ) )
         {
            A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load099( )
      {
         /* Using cursor T00095 */
         pr_default.execute(3, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound9 = 1;
            A79WWPSMSMessage = T00095_A79WWPSMSMessage[0];
            AssignAttri("", false, "A79WWPSMSMessage", A79WWPSMSMessage);
            A80WWPSMSSenderNumber = T00095_A80WWPSMSSenderNumber[0];
            AssignAttri("", false, "A80WWPSMSSenderNumber", A80WWPSMSSenderNumber);
            A81WWPSMSRecipientNumbers = T00095_A81WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A81WWPSMSRecipientNumbers", A81WWPSMSRecipientNumbers);
            A76WWPSMSStatus = T00095_A76WWPSMSStatus[0];
            AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
            A82WWPSMSCreated = T00095_A82WWPSMSCreated[0];
            AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            A83WWPSMSScheduled = T00095_A83WWPSMSScheduled[0];
            AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            A77WWPSMSProcessed = T00095_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = T00095_n77WWPSMSProcessed[0];
            AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            A78WWPSMSDetail = T00095_A78WWPSMSDetail[0];
            n78WWPSMSDetail = T00095_n78WWPSMSDetail[0];
            AssignAttri("", false, "A78WWPSMSDetail", A78WWPSMSDetail);
            A66WWPNotificationCreated = T00095_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A64WWPNotificationId = T00095_A64WWPNotificationId[0];
            n64WWPNotificationId = T00095_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            ZM099( -5) ;
         }
         pr_default.close(3);
         OnLoadActions099( ) ;
      }

      protected void OnLoadActions099( )
      {
      }

      protected void CheckExtendedTable099( )
      {
         nIsDirty_9 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A76WWPSMSStatus == 1 ) || ( A76WWPSMSStatus == 2 ) || ( A76WWPSMSStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo SMS Status fora do intervalo", "OutOfRange", 1, "WWPSMSSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPSMSStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T00094 */
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
         A66WWPNotificationCreated = T00094_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         pr_default.close(2);
      }

      protected void CloseExtendedTableCursors099( )
      {
         pr_default.close(2);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A64WWPNotificationId )
      {
         /* Using cursor T00096 */
         pr_default.execute(4, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A66WWPNotificationCreated = T00096_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(4) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(4);
      }

      protected void GetKey099( )
      {
         /* Using cursor T00097 */
         pr_default.execute(5, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound9 = 1;
         }
         else
         {
            RcdFound9 = 0;
         }
         pr_default.close(5);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00093 */
         pr_default.execute(1, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM099( 5) ;
            RcdFound9 = 1;
            A75WWPSMSId = T00093_A75WWPSMSId[0];
            AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
            A79WWPSMSMessage = T00093_A79WWPSMSMessage[0];
            AssignAttri("", false, "A79WWPSMSMessage", A79WWPSMSMessage);
            A80WWPSMSSenderNumber = T00093_A80WWPSMSSenderNumber[0];
            AssignAttri("", false, "A80WWPSMSSenderNumber", A80WWPSMSSenderNumber);
            A81WWPSMSRecipientNumbers = T00093_A81WWPSMSRecipientNumbers[0];
            AssignAttri("", false, "A81WWPSMSRecipientNumbers", A81WWPSMSRecipientNumbers);
            A76WWPSMSStatus = T00093_A76WWPSMSStatus[0];
            AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
            A82WWPSMSCreated = T00093_A82WWPSMSCreated[0];
            AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
            A83WWPSMSScheduled = T00093_A83WWPSMSScheduled[0];
            AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
            A77WWPSMSProcessed = T00093_A77WWPSMSProcessed[0];
            n77WWPSMSProcessed = T00093_n77WWPSMSProcessed[0];
            AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
            A78WWPSMSDetail = T00093_A78WWPSMSDetail[0];
            n78WWPSMSDetail = T00093_n78WWPSMSDetail[0];
            AssignAttri("", false, "A78WWPSMSDetail", A78WWPSMSDetail);
            A64WWPNotificationId = T00093_A64WWPNotificationId[0];
            n64WWPNotificationId = T00093_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            Z75WWPSMSId = A75WWPSMSId;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load099( ) ;
            if ( AnyError == 1 )
            {
               RcdFound9 = 0;
               InitializeNonKey099( ) ;
            }
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound9 = 0;
            InitializeNonKey099( ) ;
            sMode9 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode9;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey099( ) ;
         if ( RcdFound9 == 0 )
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
         RcdFound9 = 0;
         /* Using cursor T00098 */
         pr_default.execute(6, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(6) != 101) )
         {
            while ( (pr_default.getStatus(6) != 101) && ( ( T00098_A75WWPSMSId[0] < A75WWPSMSId ) ) )
            {
               pr_default.readNext(6);
            }
            if ( (pr_default.getStatus(6) != 101) && ( ( T00098_A75WWPSMSId[0] > A75WWPSMSId ) ) )
            {
               A75WWPSMSId = T00098_A75WWPSMSId[0];
               AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(6);
      }

      protected void move_previous( )
      {
         RcdFound9 = 0;
         /* Using cursor T00099 */
         pr_default.execute(7, new Object[] {A75WWPSMSId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            while ( (pr_default.getStatus(7) != 101) && ( ( T00099_A75WWPSMSId[0] > A75WWPSMSId ) ) )
            {
               pr_default.readNext(7);
            }
            if ( (pr_default.getStatus(7) != 101) && ( ( T00099_A75WWPSMSId[0] < A75WWPSMSId ) ) )
            {
               A75WWPSMSId = T00099_A75WWPSMSId[0];
               AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
               RcdFound9 = 1;
            }
         }
         pr_default.close(7);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey099( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert099( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound9 == 1 )
            {
               if ( A75WWPSMSId != Z75WWPSMSId )
               {
                  A75WWPSMSId = Z75WWPSMSId;
                  AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSMSID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update099( ) ;
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A75WWPSMSId != Z75WWPSMSId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSMSId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert099( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSMSID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSMSId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert099( ) ;
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
         if ( A75WWPSMSId != Z75WWPSMSId )
         {
            A75WWPSMSId = Z75WWPSMSId;
            AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSMSId_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSMSID");
            AnyError = 1;
            GX_FocusControl = edtWWPSMSId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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
         ScanStart099( ) ;
         if ( RcdFound9 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound9 != 0 )
            {
               ScanNext099( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPSMSMessage_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd099( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency099( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00092 */
            pr_default.execute(0, new Object[] {A75WWPSMSId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( Z76WWPSMSStatus != T00092_A76WWPSMSStatus[0] ) || ( Z82WWPSMSCreated != T00092_A82WWPSMSCreated[0] ) || ( Z83WWPSMSScheduled != T00092_A83WWPSMSScheduled[0] ) || ( Z77WWPSMSProcessed != T00092_A77WWPSMSProcessed[0] ) || ( Z64WWPNotificationId != T00092_A64WWPNotificationId[0] ) )
            {
               if ( Z76WWPSMSStatus != T00092_A76WWPSMSStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSStatus");
                  GXUtil.WriteLogRaw("Old: ",Z76WWPSMSStatus);
                  GXUtil.WriteLogRaw("Current: ",T00092_A76WWPSMSStatus[0]);
               }
               if ( Z82WWPSMSCreated != T00092_A82WWPSMSCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSCreated");
                  GXUtil.WriteLogRaw("Old: ",Z82WWPSMSCreated);
                  GXUtil.WriteLogRaw("Current: ",T00092_A82WWPSMSCreated[0]);
               }
               if ( Z83WWPSMSScheduled != T00092_A83WWPSMSScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z83WWPSMSScheduled);
                  GXUtil.WriteLogRaw("Current: ",T00092_A83WWPSMSScheduled[0]);
               }
               if ( Z77WWPSMSProcessed != T00092_A77WWPSMSProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPSMSProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z77WWPSMSProcessed);
                  GXUtil.WriteLogRaw("Current: ",T00092_A77WWPSMSProcessed[0]);
               }
               if ( Z64WWPNotificationId != T00092_A64WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.sms.wwp_sms:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z64WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T00092_A64WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_SMS"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert099( )
      {
         if ( ! IsAuthorized("sms_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM099( 0) ;
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000910 */
                     pr_default.execute(8, new Object[] {A79WWPSMSMessage, A80WWPSMSSenderNumber, A81WWPSMSRecipientNumbers, A76WWPSMSStatus, A82WWPSMSCreated, A83WWPSMSScheduled, n77WWPSMSProcessed, A77WWPSMSProcessed, n78WWPSMSDetail, A78WWPSMSDetail, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(8);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000911 */
                     pr_default.execute(9);
                     A75WWPSMSId = T000911_A75WWPSMSId[0];
                     AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
                     pr_default.close(9);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption090( ) ;
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
               Load099( ) ;
            }
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void Update099( )
      {
         if ( ! IsAuthorized("sms_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable099( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm099( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate099( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000912 */
                     pr_default.execute(10, new Object[] {A79WWPSMSMessage, A80WWPSMSSenderNumber, A81WWPSMSRecipientNumbers, A76WWPSMSStatus, A82WWPSMSCreated, A83WWPSMSScheduled, n77WWPSMSProcessed, A77WWPSMSProcessed, n78WWPSMSDetail, A78WWPSMSDetail, n64WWPNotificationId, A64WWPNotificationId, A75WWPSMSId});
                     pr_default.close(10);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                     if ( (pr_default.getStatus(10) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_SMS"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate099( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption090( ) ;
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
            EndLevel099( ) ;
         }
         CloseExtendedTableCursors099( ) ;
      }

      protected void DeferredUpdate099( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("sms_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate099( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency099( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls099( ) ;
            AfterConfirm099( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete099( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000913 */
                  pr_default.execute(11, new Object[] {A75WWPSMSId});
                  pr_default.close(11);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_SMS");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound9 == 0 )
                        {
                           InitAll099( ) ;
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
                        ResetCaption090( ) ;
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
         sMode9 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel099( ) ;
         Gx_mode = sMode9;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls099( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000914 */
            pr_default.execute(12, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A66WWPNotificationCreated = T000914_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            pr_default.close(12);
         }
      }

      protected void EndLevel099( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete099( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues090( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.sms.wwp_sms",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart099( )
      {
         /* Using cursor T000915 */
         pr_default.execute(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A75WWPSMSId = T000915_A75WWPSMSId[0];
            AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext099( )
      {
         /* Scan next routine */
         pr_default.readNext(13);
         RcdFound9 = 0;
         if ( (pr_default.getStatus(13) != 101) )
         {
            RcdFound9 = 1;
            A75WWPSMSId = T000915_A75WWPSMSId[0];
            AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
         }
      }

      protected void ScanEnd099( )
      {
         pr_default.close(13);
      }

      protected void AfterConfirm099( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert099( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate099( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete099( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete099( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate099( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes099( )
      {
         edtWWPSMSId_Enabled = 0;
         AssignProp("", false, edtWWPSMSId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSId_Enabled), 5, 0), true);
         edtWWPSMSMessage_Enabled = 0;
         AssignProp("", false, edtWWPSMSMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSMessage_Enabled), 5, 0), true);
         edtWWPSMSSenderNumber_Enabled = 0;
         AssignProp("", false, edtWWPSMSSenderNumber_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSSenderNumber_Enabled), 5, 0), true);
         edtWWPSMSRecipientNumbers_Enabled = 0;
         AssignProp("", false, edtWWPSMSRecipientNumbers_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSRecipientNumbers_Enabled), 5, 0), true);
         cmbWWPSMSStatus.Enabled = 0;
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPSMSStatus.Enabled), 5, 0), true);
         edtWWPSMSCreated_Enabled = 0;
         AssignProp("", false, edtWWPSMSCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSCreated_Enabled), 5, 0), true);
         edtWWPSMSScheduled_Enabled = 0;
         AssignProp("", false, edtWWPSMSScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSScheduled_Enabled), 5, 0), true);
         edtWWPSMSProcessed_Enabled = 0;
         AssignProp("", false, edtWWPSMSProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSProcessed_Enabled), 5, 0), true);
         edtWWPSMSDetail_Enabled = 0;
         AssignProp("", false, edtWWPSMSDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSMSDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes099( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues090( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.sms.wwp_sms.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z75WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75WWPSMSId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z76WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76WWPSMSStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z82WWPSMSCreated", context.localUtil.TToC( Z82WWPSMSCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z83WWPSMSScheduled", context.localUtil.TToC( Z83WWPSMSScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z77WWPSMSProcessed", context.localUtil.TToC( Z77WWPSMSProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "vGXBSCREEN", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gx_BScreen), 1, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.sms.wwp_sms.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.SMS.WWP_SMS" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_SMS" ;
      }

      protected void InitializeNonKey099( )
      {
         A79WWPSMSMessage = "";
         AssignAttri("", false, "A79WWPSMSMessage", A79WWPSMSMessage);
         A80WWPSMSSenderNumber = "";
         AssignAttri("", false, "A80WWPSMSSenderNumber", A80WWPSMSSenderNumber);
         A81WWPSMSRecipientNumbers = "";
         AssignAttri("", false, "A81WWPSMSRecipientNumbers", A81WWPSMSRecipientNumbers);
         A77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         n77WWPSMSProcessed = false;
         AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         n77WWPSMSProcessed = ((DateTime.MinValue==A77WWPSMSProcessed) ? true : false);
         A78WWPSMSDetail = "";
         n78WWPSMSDetail = false;
         AssignAttri("", false, "A78WWPSMSDetail", A78WWPSMSDetail);
         n78WWPSMSDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A78WWPSMSDetail)) ? true : false);
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A76WWPSMSStatus = 1;
         AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
         A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z76WWPSMSStatus = 0;
         Z82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         Z64WWPNotificationId = 0;
      }

      protected void InitAll099( )
      {
         A75WWPSMSId = 0;
         AssignAttri("", false, "A75WWPSMSId", StringUtil.LTrimStr( (decimal)(A75WWPSMSId), 10, 0));
         InitializeNonKey099( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A76WWPSMSStatus = i76WWPSMSStatus;
         AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
         A82WWPSMSCreated = i82WWPSMSCreated;
         AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         A83WWPSMSScheduled = i83WWPSMSScheduled;
         AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382812964", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/sms/wwp_sms.js", "?202382812964", false, true);
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
         edtWWPSMSId_Internalname = "WWPSMSID";
         edtWWPSMSMessage_Internalname = "WWPSMSMESSAGE";
         edtWWPSMSSenderNumber_Internalname = "WWPSMSSENDERNUMBER";
         edtWWPSMSRecipientNumbers_Internalname = "WWPSMSRECIPIENTNUMBERS";
         cmbWWPSMSStatus_Internalname = "WWPSMSSTATUS";
         edtWWPSMSCreated_Internalname = "WWPSMSCREATED";
         edtWWPSMSScheduled_Internalname = "WWPSMSSCHEDULED";
         edtWWPSMSProcessed_Internalname = "WWPSMSPROCESSED";
         edtWWPSMSDetail_Internalname = "WWPSMSDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
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
         Form.Caption = "WWP_SMS";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPSMSDetail_Enabled = 1;
         edtWWPSMSProcessed_Jsonclick = "";
         edtWWPSMSProcessed_Enabled = 1;
         edtWWPSMSScheduled_Jsonclick = "";
         edtWWPSMSScheduled_Enabled = 1;
         edtWWPSMSCreated_Jsonclick = "";
         edtWWPSMSCreated_Enabled = 1;
         cmbWWPSMSStatus_Jsonclick = "";
         cmbWWPSMSStatus.Enabled = 1;
         edtWWPSMSRecipientNumbers_Enabled = 1;
         edtWWPSMSSenderNumber_Enabled = 1;
         edtWWPSMSMessage_Enabled = 1;
         edtWWPSMSId_Jsonclick = "";
         edtWWPSMSId_Enabled = 1;
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
         cmbWWPSMSStatus.Name = "WWPSMSSTATUS";
         cmbWWPSMSStatus.WebTags = "";
         cmbWWPSMSStatus.addItem("1", "Pending", 0);
         cmbWWPSMSStatus.addItem("2", "Sent", 0);
         cmbWWPSMSStatus.addItem("3", "Error", 0);
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A76WWPSMSStatus) )
            {
               A76WWPSMSStatus = 1;
               AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPSMSMessage_Internalname;
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

      public void Valid_Wwpsmsid( )
      {
         A76WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPSMSStatus.ItemCount > 0 )
         {
            A76WWPSMSStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPSMSStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPSMSStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A76WWPSMSStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A79WWPSMSMessage", A79WWPSMSMessage);
         AssignAttri("", false, "A80WWPSMSSenderNumber", A80WWPSMSSenderNumber);
         AssignAttri("", false, "A81WWPSMSRecipientNumbers", A81WWPSMSRecipientNumbers);
         AssignAttri("", false, "A76WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A76WWPSMSStatus), 4, 0, ".", "")));
         cmbWWPSMSStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A76WWPSMSStatus), 4, 0));
         AssignProp("", false, cmbWWPSMSStatus_Internalname, "Values", cmbWWPSMSStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A82WWPSMSCreated", context.localUtil.TToC( A82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A83WWPSMSScheduled", context.localUtil.TToC( A83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A77WWPSMSProcessed", context.localUtil.TToC( A77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A78WWPSMSDetail", A78WWPSMSDetail);
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z75WWPSMSId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z75WWPSMSId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z79WWPSMSMessage", Z79WWPSMSMessage);
         GxWebStd.gx_hidden_field( context, "Z80WWPSMSSenderNumber", Z80WWPSMSSenderNumber);
         GxWebStd.gx_hidden_field( context, "Z81WWPSMSRecipientNumbers", Z81WWPSMSRecipientNumbers);
         GxWebStd.gx_hidden_field( context, "Z76WWPSMSStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z76WWPSMSStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z82WWPSMSCreated", context.localUtil.TToC( Z82WWPSMSCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z83WWPSMSScheduled", context.localUtil.TToC( Z83WWPSMSScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z77WWPSMSProcessed", context.localUtil.TToC( Z77WWPSMSProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z78WWPSMSDetail", Z78WWPSMSDetail);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationCreated", context.localUtil.TToC( Z66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n64WWPNotificationId = false;
         /* Using cursor T000914 */
         pr_default.execute(12, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(12) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
            }
         }
         A66WWPNotificationCreated = T000914_A66WWPNotificationCreated[0];
         pr_default.close(12);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true}]");
         setEventMetadata("ENTER",",oparms:[]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("VALID_WWPSMSID","{handler:'Valid_Wwpsmsid',iparms:[{av:'A75WWPSMSId',fld:'WWPSMSID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPSMSStatus'},{av:'A76WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A82WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A83WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPSMSID",",oparms:[{av:'A79WWPSMSMessage',fld:'WWPSMSMESSAGE',pic:''},{av:'A80WWPSMSSenderNumber',fld:'WWPSMSSENDERNUMBER',pic:''},{av:'A81WWPSMSRecipientNumbers',fld:'WWPSMSRECIPIENTNUMBERS',pic:''},{av:'cmbWWPSMSStatus'},{av:'A76WWPSMSStatus',fld:'WWPSMSSTATUS',pic:'ZZZ9'},{av:'A82WWPSMSCreated',fld:'WWPSMSCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A83WWPSMSScheduled',fld:'WWPSMSSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A77WWPSMSProcessed',fld:'WWPSMSPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A78WWPSMSDetail',fld:'WWPSMSDETAIL',pic:''},{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z75WWPSMSId'},{av:'Z79WWPSMSMessage'},{av:'Z80WWPSMSSenderNumber'},{av:'Z81WWPSMSRecipientNumbers'},{av:'Z76WWPSMSStatus'},{av:'Z82WWPSMSCreated'},{av:'Z83WWPSMSScheduled'},{av:'Z77WWPSMSProcessed'},{av:'Z78WWPSMSDetail'},{av:'Z64WWPNotificationId'},{av:'Z66WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPSMSSTATUS","{handler:'Valid_Wwpsmsstatus',iparms:[]");
         setEventMetadata("VALID_WWPSMSSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]}");
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
         Z82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         Z83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         Z77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
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
         A79WWPSMSMessage = "";
         A80WWPSMSSenderNumber = "";
         A81WWPSMSRecipientNumbers = "";
         A82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         A83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         A77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         A78WWPSMSDetail = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
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
         Z79WWPSMSMessage = "";
         Z80WWPSMSSenderNumber = "";
         Z81WWPSMSRecipientNumbers = "";
         Z78WWPSMSDetail = "";
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T00095_A75WWPSMSId = new long[1] ;
         T00095_A79WWPSMSMessage = new string[] {""} ;
         T00095_A80WWPSMSSenderNumber = new string[] {""} ;
         T00095_A81WWPSMSRecipientNumbers = new string[] {""} ;
         T00095_A76WWPSMSStatus = new short[1] ;
         T00095_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00095_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00095_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00095_n77WWPSMSProcessed = new bool[] {false} ;
         T00095_A78WWPSMSDetail = new string[] {""} ;
         T00095_n78WWPSMSDetail = new bool[] {false} ;
         T00095_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00095_A64WWPNotificationId = new long[1] ;
         T00095_n64WWPNotificationId = new bool[] {false} ;
         T00094_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00096_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T00097_A75WWPSMSId = new long[1] ;
         T00093_A75WWPSMSId = new long[1] ;
         T00093_A79WWPSMSMessage = new string[] {""} ;
         T00093_A80WWPSMSSenderNumber = new string[] {""} ;
         T00093_A81WWPSMSRecipientNumbers = new string[] {""} ;
         T00093_A76WWPSMSStatus = new short[1] ;
         T00093_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00093_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00093_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00093_n77WWPSMSProcessed = new bool[] {false} ;
         T00093_A78WWPSMSDetail = new string[] {""} ;
         T00093_n78WWPSMSDetail = new bool[] {false} ;
         T00093_A64WWPNotificationId = new long[1] ;
         T00093_n64WWPNotificationId = new bool[] {false} ;
         sMode9 = "";
         T00098_A75WWPSMSId = new long[1] ;
         T00099_A75WWPSMSId = new long[1] ;
         T00092_A75WWPSMSId = new long[1] ;
         T00092_A79WWPSMSMessage = new string[] {""} ;
         T00092_A80WWPSMSSenderNumber = new string[] {""} ;
         T00092_A81WWPSMSRecipientNumbers = new string[] {""} ;
         T00092_A76WWPSMSStatus = new short[1] ;
         T00092_A82WWPSMSCreated = new DateTime[] {DateTime.MinValue} ;
         T00092_A83WWPSMSScheduled = new DateTime[] {DateTime.MinValue} ;
         T00092_A77WWPSMSProcessed = new DateTime[] {DateTime.MinValue} ;
         T00092_n77WWPSMSProcessed = new bool[] {false} ;
         T00092_A78WWPSMSDetail = new string[] {""} ;
         T00092_n78WWPSMSDetail = new bool[] {false} ;
         T00092_A64WWPNotificationId = new long[1] ;
         T00092_n64WWPNotificationId = new bool[] {false} ;
         T000911_A75WWPSMSId = new long[1] ;
         T000914_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000915_A75WWPSMSId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         i83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ79WWPSMSMessage = "";
         ZZ80WWPSMSSenderNumber = "";
         ZZ81WWPSMSRecipientNumbers = "";
         ZZ82WWPSMSCreated = (DateTime)(DateTime.MinValue);
         ZZ83WWPSMSScheduled = (DateTime)(DateTime.MinValue);
         ZZ77WWPSMSProcessed = (DateTime)(DateTime.MinValue);
         ZZ78WWPSMSDetail = "";
         ZZ66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.sms.wwp_sms__default(),
            new Object[][] {
                new Object[] {
               T00092_A75WWPSMSId, T00092_A79WWPSMSMessage, T00092_A80WWPSMSSenderNumber, T00092_A81WWPSMSRecipientNumbers, T00092_A76WWPSMSStatus, T00092_A82WWPSMSCreated, T00092_A83WWPSMSScheduled, T00092_A77WWPSMSProcessed, T00092_n77WWPSMSProcessed, T00092_A78WWPSMSDetail,
               T00092_n78WWPSMSDetail, T00092_A64WWPNotificationId, T00092_n64WWPNotificationId
               }
               , new Object[] {
               T00093_A75WWPSMSId, T00093_A79WWPSMSMessage, T00093_A80WWPSMSSenderNumber, T00093_A81WWPSMSRecipientNumbers, T00093_A76WWPSMSStatus, T00093_A82WWPSMSCreated, T00093_A83WWPSMSScheduled, T00093_A77WWPSMSProcessed, T00093_n77WWPSMSProcessed, T00093_A78WWPSMSDetail,
               T00093_n78WWPSMSDetail, T00093_A64WWPNotificationId, T00093_n64WWPNotificationId
               }
               , new Object[] {
               T00094_A66WWPNotificationCreated
               }
               , new Object[] {
               T00095_A75WWPSMSId, T00095_A79WWPSMSMessage, T00095_A80WWPSMSSenderNumber, T00095_A81WWPSMSRecipientNumbers, T00095_A76WWPSMSStatus, T00095_A82WWPSMSCreated, T00095_A83WWPSMSScheduled, T00095_A77WWPSMSProcessed, T00095_n77WWPSMSProcessed, T00095_A78WWPSMSDetail,
               T00095_n78WWPSMSDetail, T00095_A66WWPNotificationCreated, T00095_A64WWPNotificationId, T00095_n64WWPNotificationId
               }
               , new Object[] {
               T00096_A66WWPNotificationCreated
               }
               , new Object[] {
               T00097_A75WWPSMSId
               }
               , new Object[] {
               T00098_A75WWPSMSId
               }
               , new Object[] {
               T00099_A75WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               T000911_A75WWPSMSId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000914_A66WWPNotificationCreated
               }
               , new Object[] {
               T000915_A75WWPSMSId
               }
            }
         );
         Z83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i83WWPSMSScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i82WWPSMSCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z76WWPSMSStatus = 1;
         A76WWPSMSStatus = 1;
         i76WWPSMSStatus = 1;
      }

      private short Z76WWPSMSStatus ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A76WWPSMSStatus ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound9 ;
      private short nIsDirty_9 ;
      private short gxajaxcallmode ;
      private short i76WWPSMSStatus ;
      private short ZZ76WWPSMSStatus ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSMSId_Enabled ;
      private int edtWWPSMSMessage_Enabled ;
      private int edtWWPSMSSenderNumber_Enabled ;
      private int edtWWPSMSRecipientNumbers_Enabled ;
      private int edtWWPSMSCreated_Enabled ;
      private int edtWWPSMSScheduled_Enabled ;
      private int edtWWPSMSProcessed_Enabled ;
      private int edtWWPSMSDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z75WWPSMSId ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private long A75WWPSMSId ;
      private long ZZ75WWPSMSId ;
      private long ZZ64WWPNotificationId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSMSId_Internalname ;
      private string cmbWWPSMSStatus_Internalname ;
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
      private string edtWWPSMSId_Jsonclick ;
      private string edtWWPSMSMessage_Internalname ;
      private string edtWWPSMSSenderNumber_Internalname ;
      private string edtWWPSMSRecipientNumbers_Internalname ;
      private string cmbWWPSMSStatus_Jsonclick ;
      private string edtWWPSMSCreated_Internalname ;
      private string edtWWPSMSCreated_Jsonclick ;
      private string edtWWPSMSScheduled_Internalname ;
      private string edtWWPSMSScheduled_Jsonclick ;
      private string edtWWPSMSProcessed_Internalname ;
      private string edtWWPSMSProcessed_Jsonclick ;
      private string edtWWPSMSDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
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
      private string sMode9 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private DateTime Z82WWPSMSCreated ;
      private DateTime Z83WWPSMSScheduled ;
      private DateTime Z77WWPSMSProcessed ;
      private DateTime A82WWPSMSCreated ;
      private DateTime A83WWPSMSScheduled ;
      private DateTime A77WWPSMSProcessed ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime i82WWPSMSCreated ;
      private DateTime i83WWPSMSScheduled ;
      private DateTime ZZ82WWPSMSCreated ;
      private DateTime ZZ83WWPSMSScheduled ;
      private DateTime ZZ77WWPSMSProcessed ;
      private DateTime ZZ66WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n64WWPNotificationId ;
      private bool wbErr ;
      private bool n77WWPSMSProcessed ;
      private bool n78WWPSMSDetail ;
      private string A79WWPSMSMessage ;
      private string A80WWPSMSSenderNumber ;
      private string A81WWPSMSRecipientNumbers ;
      private string A78WWPSMSDetail ;
      private string Z79WWPSMSMessage ;
      private string Z80WWPSMSSenderNumber ;
      private string Z81WWPSMSRecipientNumbers ;
      private string Z78WWPSMSDetail ;
      private string ZZ79WWPSMSMessage ;
      private string ZZ80WWPSMSSenderNumber ;
      private string ZZ81WWPSMSRecipientNumbers ;
      private string ZZ78WWPSMSDetail ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPSMSStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T00095_A75WWPSMSId ;
      private string[] T00095_A79WWPSMSMessage ;
      private string[] T00095_A80WWPSMSSenderNumber ;
      private string[] T00095_A81WWPSMSRecipientNumbers ;
      private short[] T00095_A76WWPSMSStatus ;
      private DateTime[] T00095_A82WWPSMSCreated ;
      private DateTime[] T00095_A83WWPSMSScheduled ;
      private DateTime[] T00095_A77WWPSMSProcessed ;
      private bool[] T00095_n77WWPSMSProcessed ;
      private string[] T00095_A78WWPSMSDetail ;
      private bool[] T00095_n78WWPSMSDetail ;
      private DateTime[] T00095_A66WWPNotificationCreated ;
      private long[] T00095_A64WWPNotificationId ;
      private bool[] T00095_n64WWPNotificationId ;
      private DateTime[] T00094_A66WWPNotificationCreated ;
      private DateTime[] T00096_A66WWPNotificationCreated ;
      private long[] T00097_A75WWPSMSId ;
      private long[] T00093_A75WWPSMSId ;
      private string[] T00093_A79WWPSMSMessage ;
      private string[] T00093_A80WWPSMSSenderNumber ;
      private string[] T00093_A81WWPSMSRecipientNumbers ;
      private short[] T00093_A76WWPSMSStatus ;
      private DateTime[] T00093_A82WWPSMSCreated ;
      private DateTime[] T00093_A83WWPSMSScheduled ;
      private DateTime[] T00093_A77WWPSMSProcessed ;
      private bool[] T00093_n77WWPSMSProcessed ;
      private string[] T00093_A78WWPSMSDetail ;
      private bool[] T00093_n78WWPSMSDetail ;
      private long[] T00093_A64WWPNotificationId ;
      private bool[] T00093_n64WWPNotificationId ;
      private long[] T00098_A75WWPSMSId ;
      private long[] T00099_A75WWPSMSId ;
      private long[] T00092_A75WWPSMSId ;
      private string[] T00092_A79WWPSMSMessage ;
      private string[] T00092_A80WWPSMSSenderNumber ;
      private string[] T00092_A81WWPSMSRecipientNumbers ;
      private short[] T00092_A76WWPSMSStatus ;
      private DateTime[] T00092_A82WWPSMSCreated ;
      private DateTime[] T00092_A83WWPSMSScheduled ;
      private DateTime[] T00092_A77WWPSMSProcessed ;
      private bool[] T00092_n77WWPSMSProcessed ;
      private string[] T00092_A78WWPSMSDetail ;
      private bool[] T00092_n78WWPSMSDetail ;
      private long[] T00092_A64WWPNotificationId ;
      private bool[] T00092_n64WWPNotificationId ;
      private long[] T000911_A75WWPSMSId ;
      private DateTime[] T000914_A66WWPNotificationCreated ;
      private long[] T000915_A75WWPSMSId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_sms__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_sms__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[9])
       ,new UpdateCursor(def[10])
       ,new UpdateCursor(def[11])
       ,new ForEachCursor(def[12])
       ,new ForEachCursor(def[13])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00095;
        prmT00095 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00094;
        prmT00094 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00096;
        prmT00096 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT00097;
        prmT00097 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00093;
        prmT00093 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00098;
        prmT00098 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00099;
        prmT00099 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT00092;
        prmT00092 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000910;
        prmT000910 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000911;
        prmT000911 = new Object[] {
        };
        Object[] prmT000912;
        prmT000912 = new Object[] {
        new ParDef("WWPSMSMessage",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSSenderNumber",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSRecipientNumbers",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPSMSStatus",GXType.Int16,4,0) ,
        new ParDef("WWPSMSCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPSMSProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPSMSDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000913;
        prmT000913 = new Object[] {
        new ParDef("WWPSMSId",GXType.Int64,10,0)
        };
        Object[] prmT000915;
        prmT000915 = new Object[] {
        };
        Object[] prmT000914;
        prmT000914 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00092", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId  FOR UPDATE OF WWP_SMS NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00092,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00093", "SELECT WWPSMSId, WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00093,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00094", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00094,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00095", "SELECT TM1.WWPSMSId, TM1.WWPSMSMessage, TM1.WWPSMSSenderNumber, TM1.WWPSMSRecipientNumbers, TM1.WWPSMSStatus, TM1.WWPSMSCreated, TM1.WWPSMSScheduled, TM1.WWPSMSProcessed, TM1.WWPSMSDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_SMS TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPSMSId = :WWPSMSId ORDER BY TM1.WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00095,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00096", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00096,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00097", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPSMSId = :WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00097,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00098", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId > :WWPSMSId) ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00098,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00099", "SELECT WWPSMSId FROM WWP_SMS WHERE ( WWPSMSId < :WWPSMSId) ORDER BY WWPSMSId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00099,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000910", "SAVEPOINT gxupdate;INSERT INTO WWP_SMS(WWPSMSMessage, WWPSMSSenderNumber, WWPSMSRecipientNumbers, WWPSMSStatus, WWPSMSCreated, WWPSMSScheduled, WWPSMSProcessed, WWPSMSDetail, WWPNotificationId) VALUES(:WWPSMSMessage, :WWPSMSSenderNumber, :WWPSMSRecipientNumbers, :WWPSMSStatus, :WWPSMSCreated, :WWPSMSScheduled, :WWPSMSProcessed, :WWPSMSDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000910)
           ,new CursorDef("T000911", "SELECT currval('WWPSMSId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000911,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000912", "SAVEPOINT gxupdate;UPDATE WWP_SMS SET WWPSMSMessage=:WWPSMSMessage, WWPSMSSenderNumber=:WWPSMSSenderNumber, WWPSMSRecipientNumbers=:WWPSMSRecipientNumbers, WWPSMSStatus=:WWPSMSStatus, WWPSMSCreated=:WWPSMSCreated, WWPSMSScheduled=:WWPSMSScheduled, WWPSMSProcessed=:WWPSMSProcessed, WWPSMSDetail=:WWPSMSDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000912)
           ,new CursorDef("T000913", "SAVEPOINT gxupdate;DELETE FROM WWP_SMS  WHERE WWPSMSId = :WWPSMSId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000913)
           ,new CursorDef("T000914", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000914,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000915", "SELECT WWPSMSId FROM WWP_SMS ORDER BY WWPSMSId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000915,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((long[]) buf[11])[0] = rslt.getLong(10);
              ((bool[]) buf[12])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getLongVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((short[]) buf[4])[0] = rslt.getShort(5);
              ((DateTime[]) buf[5])[0] = rslt.getGXDateTime(6, true);
              ((DateTime[]) buf[6])[0] = rslt.getGXDateTime(7, true);
              ((DateTime[]) buf[7])[0] = rslt.getGXDateTime(8, true);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(9);
              ((bool[]) buf[10])[0] = rslt.wasNull(9);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(10, true);
              ((long[]) buf[12])[0] = rslt.getLong(11);
              ((bool[]) buf[13])[0] = rslt.wasNull(11);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
