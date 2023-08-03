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
namespace GeneXus.Programs.wwpbaseobjects.subscriptions {
   public class wwp_subscription : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_3") == 0 )
         {
            A65WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_3( A65WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A62WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A62WWPEntityId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_4") == 0 )
         {
            A49WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_4( A49WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "WWP_Subscription", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_subscription( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_subscription( IGxContext context )
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
         chkWWPSubscriptionSubscribed = new GXCheckbox();
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
            return "wwpsubscription_Execute" ;
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
         A69WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A69WWPSubscriptionSubscribed));
         AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "WWP_Subscription", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A67WWPSubscriptionId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPSubscriptionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A67WWPSubscriptionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A67WWPSubscriptionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionId_Internalname, "Notification Definition Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A65WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationDefinitionDescr_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationDefinitionDescr_Internalname, "Notification Definition Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationDefinitionDescr_Internalname, A71WWPNotificationDefinitionDescr, "", "", 0, 1, edtWWPNotificationDefinitionDescr_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityName_Internalname, "Entity Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A63WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A63WWPEntityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "User Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A49WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A49WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "User Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A50WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A50WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordId_Internalname, "Record Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordId_Internalname, A68WWPSubscriptionEntityRecordId, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPSubscriptionEntityRecordId_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2000", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionEntityRecordDes_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionEntityRecordDes_Internalname, "Record Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPSubscriptionEntityRecordDes_Internalname, A70WWPSubscriptionEntityRecordDes, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPSubscriptionEntityRecordDes_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPSubscriptionRoleId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPSubscriptionRoleId_Internalname, "Role Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPSubscriptionRoleId_Internalname, StringUtil.RTrim( A61WWPSubscriptionRoleId), StringUtil.RTrim( context.localUtil.Format( A61WWPSubscriptionRoleId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPSubscriptionRoleId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPSubscriptionRoleId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPSubscriptionSubscribed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPSubscriptionSubscribed_Internalname, "Subscribed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPSubscriptionSubscribed_Internalname, StringUtil.BoolToStr( A69WWPSubscriptionSubscribed), "", "Subscribed", 1, chkWWPSubscriptionSubscribed.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Subscriptions\\WWP_Subscription.htm");
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
            Z67WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z67WWPSubscriptionId"), ",", "."), 18, MidpointRounding.ToEven));
            Z68WWPSubscriptionEntityRecordId = cgiGet( "Z68WWPSubscriptionEntityRecordId");
            Z70WWPSubscriptionEntityRecordDes = cgiGet( "Z70WWPSubscriptionEntityRecordDes");
            Z61WWPSubscriptionRoleId = cgiGet( "Z61WWPSubscriptionRoleId");
            n61WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A61WWPSubscriptionRoleId)) ? true : false);
            Z69WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( "Z69WWPSubscriptionSubscribed"));
            Z65WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z65WWPNotificationDefinitionId"), ",", "."), 18, MidpointRounding.ToEven));
            Z49WWPUserExtendedId = cgiGet( "Z49WWPUserExtendedId");
            n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A62WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "WWPENTITYID"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPSUBSCRIPTIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPSubscriptionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A67WWPSubscriptionId = 0;
               AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
            }
            else
            {
               A67WWPSubscriptionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPSubscriptionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPNOTIFICATIONDEFINITIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A65WWPNotificationDefinitionId = 0;
               AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            }
            else
            {
               A65WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPNotificationDefinitionId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            }
            A71WWPNotificationDefinitionDescr = cgiGet( edtWWPNotificationDefinitionDescr_Internalname);
            AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
            A63WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            A49WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
            A50WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A68WWPSubscriptionEntityRecordId = cgiGet( edtWWPSubscriptionEntityRecordId_Internalname);
            AssignAttri("", false, "A68WWPSubscriptionEntityRecordId", A68WWPSubscriptionEntityRecordId);
            A70WWPSubscriptionEntityRecordDes = cgiGet( edtWWPSubscriptionEntityRecordDes_Internalname);
            AssignAttri("", false, "A70WWPSubscriptionEntityRecordDes", A70WWPSubscriptionEntityRecordDes);
            A61WWPSubscriptionRoleId = cgiGet( edtWWPSubscriptionRoleId_Internalname);
            n61WWPSubscriptionRoleId = false;
            AssignAttri("", false, "A61WWPSubscriptionRoleId", A61WWPSubscriptionRoleId);
            n61WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A61WWPSubscriptionRoleId)) ? true : false);
            A69WWPSubscriptionSubscribed = StringUtil.StrToBool( cgiGet( chkWWPSubscriptionSubscribed_Internalname));
            AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
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
               A67WWPSubscriptionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPSubscriptionId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
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
               InitAll088( ) ;
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
         DisableAttributes088( ) ;
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

      protected void ResetCaption080( )
      {
      }

      protected void ZM088( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z68WWPSubscriptionEntityRecordId = T00083_A68WWPSubscriptionEntityRecordId[0];
               Z70WWPSubscriptionEntityRecordDes = T00083_A70WWPSubscriptionEntityRecordDes[0];
               Z61WWPSubscriptionRoleId = T00083_A61WWPSubscriptionRoleId[0];
               Z69WWPSubscriptionSubscribed = T00083_A69WWPSubscriptionSubscribed[0];
               Z65WWPNotificationDefinitionId = T00083_A65WWPNotificationDefinitionId[0];
               Z49WWPUserExtendedId = T00083_A49WWPUserExtendedId[0];
            }
            else
            {
               Z68WWPSubscriptionEntityRecordId = A68WWPSubscriptionEntityRecordId;
               Z70WWPSubscriptionEntityRecordDes = A70WWPSubscriptionEntityRecordDes;
               Z61WWPSubscriptionRoleId = A61WWPSubscriptionRoleId;
               Z69WWPSubscriptionSubscribed = A69WWPSubscriptionSubscribed;
               Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
               Z49WWPUserExtendedId = A49WWPUserExtendedId;
            }
         }
         if ( GX_JID == -2 )
         {
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
            Z68WWPSubscriptionEntityRecordId = A68WWPSubscriptionEntityRecordId;
            Z70WWPSubscriptionEntityRecordDes = A70WWPSubscriptionEntityRecordDes;
            Z61WWPSubscriptionRoleId = A61WWPSubscriptionRoleId;
            Z69WWPSubscriptionSubscribed = A69WWPSubscriptionSubscribed;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z62WWPEntityId = A62WWPEntityId;
            Z71WWPNotificationDefinitionDescr = A71WWPNotificationDefinitionDescr;
            Z63WWPEntityName = A63WWPEntityName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
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
      }

      protected void Load088( )
      {
         /* Using cursor T00087 */
         pr_default.execute(5, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound8 = 1;
            A62WWPEntityId = T00087_A62WWPEntityId[0];
            A71WWPNotificationDefinitionDescr = T00087_A71WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
            A63WWPEntityName = T00087_A63WWPEntityName[0];
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            A50WWPUserExtendedFullName = T00087_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A68WWPSubscriptionEntityRecordId = T00087_A68WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A68WWPSubscriptionEntityRecordId", A68WWPSubscriptionEntityRecordId);
            A70WWPSubscriptionEntityRecordDes = T00087_A70WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A70WWPSubscriptionEntityRecordDes", A70WWPSubscriptionEntityRecordDes);
            A61WWPSubscriptionRoleId = T00087_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = T00087_n61WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A61WWPSubscriptionRoleId", A61WWPSubscriptionRoleId);
            A69WWPSubscriptionSubscribed = T00087_A69WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
            A65WWPNotificationDefinitionId = T00087_A65WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            A49WWPUserExtendedId = T00087_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T00087_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            ZM088( -2) ;
         }
         pr_default.close(5);
         OnLoadActions088( ) ;
      }

      protected void OnLoadActions088( )
      {
      }

      protected void CheckExtendedTable088( )
      {
         nIsDirty_8 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T00084 */
         pr_default.execute(2, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A62WWPEntityId = T00084_A62WWPEntityId[0];
         A71WWPNotificationDefinitionDescr = T00084_A71WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
         pr_default.close(2);
         /* Using cursor T00086 */
         pr_default.execute(4, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = T00086_A63WWPEntityName[0];
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         pr_default.close(4);
         /* Using cursor T00085 */
         pr_default.execute(3, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A50WWPUserExtendedFullName = T00085_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors088( )
      {
         pr_default.close(2);
         pr_default.close(4);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_3( long A65WWPNotificationDefinitionId )
      {
         /* Using cursor T00088 */
         pr_default.execute(6, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A62WWPEntityId = T00088_A62WWPEntityId[0];
         A71WWPNotificationDefinitionDescr = T00088_A71WWPNotificationDefinitionDescr[0];
         AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ".", "")))+"\""+","+"\""+GXUtil.EncodeJSConstant( A71WWPNotificationDefinitionDescr)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( long A62WWPEntityId )
      {
         /* Using cursor T00089 */
         pr_default.execute(7, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = T00089_A63WWPEntityName[0];
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A63WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_4( string A49WWPUserExtendedId )
      {
         /* Using cursor T000810 */
         pr_default.execute(8, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A50WWPUserExtendedFullName = T000810_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A50WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey088( )
      {
         /* Using cursor T000811 */
         pr_default.execute(9, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound8 = 1;
         }
         else
         {
            RcdFound8 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00083 */
         pr_default.execute(1, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM088( 2) ;
            RcdFound8 = 1;
            A67WWPSubscriptionId = T00083_A67WWPSubscriptionId[0];
            AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
            A68WWPSubscriptionEntityRecordId = T00083_A68WWPSubscriptionEntityRecordId[0];
            AssignAttri("", false, "A68WWPSubscriptionEntityRecordId", A68WWPSubscriptionEntityRecordId);
            A70WWPSubscriptionEntityRecordDes = T00083_A70WWPSubscriptionEntityRecordDes[0];
            AssignAttri("", false, "A70WWPSubscriptionEntityRecordDes", A70WWPSubscriptionEntityRecordDes);
            A61WWPSubscriptionRoleId = T00083_A61WWPSubscriptionRoleId[0];
            n61WWPSubscriptionRoleId = T00083_n61WWPSubscriptionRoleId[0];
            AssignAttri("", false, "A61WWPSubscriptionRoleId", A61WWPSubscriptionRoleId);
            A69WWPSubscriptionSubscribed = T00083_A69WWPSubscriptionSubscribed[0];
            AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
            A65WWPNotificationDefinitionId = T00083_A65WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            A49WWPUserExtendedId = T00083_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T00083_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            Z67WWPSubscriptionId = A67WWPSubscriptionId;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load088( ) ;
            if ( AnyError == 1 )
            {
               RcdFound8 = 0;
               InitializeNonKey088( ) ;
            }
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound8 = 0;
            InitializeNonKey088( ) ;
            sMode8 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode8;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey088( ) ;
         if ( RcdFound8 == 0 )
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
         RcdFound8 = 0;
         /* Using cursor T000812 */
         pr_default.execute(10, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000812_A67WWPSubscriptionId[0] < A67WWPSubscriptionId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000812_A67WWPSubscriptionId[0] > A67WWPSubscriptionId ) ) )
            {
               A67WWPSubscriptionId = T000812_A67WWPSubscriptionId[0];
               AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound8 = 0;
         /* Using cursor T000813 */
         pr_default.execute(11, new Object[] {A67WWPSubscriptionId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000813_A67WWPSubscriptionId[0] > A67WWPSubscriptionId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000813_A67WWPSubscriptionId[0] < A67WWPSubscriptionId ) ) )
            {
               A67WWPSubscriptionId = T000813_A67WWPSubscriptionId[0];
               AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
               RcdFound8 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey088( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert088( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound8 == 1 )
            {
               if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
               {
                  A67WWPSubscriptionId = Z67WWPSubscriptionId;
                  AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPSUBSCRIPTIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update088( ) ;
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPSubscriptionId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert088( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPSUBSCRIPTIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPSubscriptionId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert088( ) ;
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
         if ( A67WWPSubscriptionId != Z67WWPSubscriptionId )
         {
            A67WWPSubscriptionId = Z67WWPSubscriptionId;
            AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPSUBSCRIPTIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPSubscriptionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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
         ScanStart088( ) ;
         if ( RcdFound8 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound8 != 0 )
            {
               ScanNext088( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd088( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency088( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00082 */
            pr_default.execute(0, new Object[] {A67WWPSubscriptionId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z68WWPSubscriptionEntityRecordId, T00082_A68WWPSubscriptionEntityRecordId[0]) != 0 ) || ( StringUtil.StrCmp(Z70WWPSubscriptionEntityRecordDes, T00082_A70WWPSubscriptionEntityRecordDes[0]) != 0 ) || ( StringUtil.StrCmp(Z61WWPSubscriptionRoleId, T00082_A61WWPSubscriptionRoleId[0]) != 0 ) || ( Z69WWPSubscriptionSubscribed != T00082_A69WWPSubscriptionSubscribed[0] ) || ( Z65WWPNotificationDefinitionId != T00082_A65WWPNotificationDefinitionId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( StringUtil.StrCmp(Z49WWPUserExtendedId, T00082_A49WWPUserExtendedId[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z68WWPSubscriptionEntityRecordId, T00082_A68WWPSubscriptionEntityRecordId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordId");
                  GXUtil.WriteLogRaw("Old: ",Z68WWPSubscriptionEntityRecordId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A68WWPSubscriptionEntityRecordId[0]);
               }
               if ( StringUtil.StrCmp(Z70WWPSubscriptionEntityRecordDes, T00082_A70WWPSubscriptionEntityRecordDes[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionEntityRecordDes");
                  GXUtil.WriteLogRaw("Old: ",Z70WWPSubscriptionEntityRecordDes);
                  GXUtil.WriteLogRaw("Current: ",T00082_A70WWPSubscriptionEntityRecordDes[0]);
               }
               if ( StringUtil.StrCmp(Z61WWPSubscriptionRoleId, T00082_A61WWPSubscriptionRoleId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionRoleId");
                  GXUtil.WriteLogRaw("Old: ",Z61WWPSubscriptionRoleId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A61WWPSubscriptionRoleId[0]);
               }
               if ( Z69WWPSubscriptionSubscribed != T00082_A69WWPSubscriptionSubscribed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPSubscriptionSubscribed");
                  GXUtil.WriteLogRaw("Old: ",Z69WWPSubscriptionSubscribed);
                  GXUtil.WriteLogRaw("Current: ",T00082_A69WWPSubscriptionSubscribed[0]);
               }
               if ( Z65WWPNotificationDefinitionId != T00082_A65WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z65WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A65WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z49WWPUserExtendedId, T00082_A49WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.subscriptions.wwp_subscription:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T00082_A49WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Subscription"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert088( )
      {
         if ( ! IsAuthorized("wwpsubscription_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM088( 0) ;
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000814 */
                     pr_default.execute(12, new Object[] {A68WWPSubscriptionEntityRecordId, A70WWPSubscriptionEntityRecordDes, n61WWPSubscriptionRoleId, A61WWPSubscriptionRoleId, A69WWPSubscriptionSubscribed, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000815 */
                     pr_default.execute(13);
                     A67WWPSubscriptionId = T000815_A67WWPSubscriptionId[0];
                     AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption080( ) ;
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
               Load088( ) ;
            }
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void Update088( )
      {
         if ( ! IsAuthorized("wwpsubscription_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable088( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm088( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate088( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000816 */
                     pr_default.execute(14, new Object[] {A68WWPSubscriptionEntityRecordId, A70WWPSubscriptionEntityRecordDes, n61WWPSubscriptionRoleId, A61WWPSubscriptionRoleId, A69WWPSubscriptionSubscribed, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId, A67WWPSubscriptionId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Subscription"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate088( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption080( ) ;
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
            EndLevel088( ) ;
         }
         CloseExtendedTableCursors088( ) ;
      }

      protected void DeferredUpdate088( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpsubscription_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate088( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency088( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls088( ) ;
            AfterConfirm088( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete088( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000817 */
                  pr_default.execute(15, new Object[] {A67WWPSubscriptionId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Subscription");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound8 == 0 )
                        {
                           InitAll088( ) ;
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
                        ResetCaption080( ) ;
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
         sMode8 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel088( ) ;
         Gx_mode = sMode8;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls088( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000818 */
            pr_default.execute(16, new Object[] {A65WWPNotificationDefinitionId});
            A62WWPEntityId = T000818_A62WWPEntityId[0];
            A71WWPNotificationDefinitionDescr = T000818_A71WWPNotificationDefinitionDescr[0];
            AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
            pr_default.close(16);
            /* Using cursor T000819 */
            pr_default.execute(17, new Object[] {A62WWPEntityId});
            A63WWPEntityName = T000819_A63WWPEntityName[0];
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            pr_default.close(17);
            /* Using cursor T000820 */
            pr_default.execute(18, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            A50WWPUserExtendedFullName = T000820_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            pr_default.close(18);
         }
      }

      protected void EndLevel088( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete088( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues080( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.subscriptions.wwp_subscription",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart088( )
      {
         /* Using cursor T000821 */
         pr_default.execute(19);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound8 = 1;
            A67WWPSubscriptionId = T000821_A67WWPSubscriptionId[0];
            AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext088( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound8 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound8 = 1;
            A67WWPSubscriptionId = T000821_A67WWPSubscriptionId[0];
            AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
         }
      }

      protected void ScanEnd088( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm088( )
      {
         /* After Confirm Rules */
         if ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) )
         {
            A49WWPUserExtendedId = "";
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            n49WWPUserExtendedId = true;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         }
      }

      protected void BeforeInsert088( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate088( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete088( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete088( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate088( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes088( )
      {
         edtWWPSubscriptionId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionDescr_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionDescr_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordId_Enabled), 5, 0), true);
         edtWWPSubscriptionEntityRecordDes_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionEntityRecordDes_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionEntityRecordDes_Enabled), 5, 0), true);
         edtWWPSubscriptionRoleId_Enabled = 0;
         AssignProp("", false, edtWWPSubscriptionRoleId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPSubscriptionRoleId_Enabled), 5, 0), true);
         chkWWPSubscriptionSubscribed.Enabled = 0;
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPSubscriptionSubscribed.Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes088( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues080( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z67WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z67WWPSubscriptionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z68WWPSubscriptionEntityRecordId", Z68WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z70WWPSubscriptionEntityRecordDes", Z70WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z61WWPSubscriptionRoleId", StringUtil.RTrim( Z61WWPSubscriptionRoleId));
         GxWebStd.gx_boolean_hidden_field( context, "Z69WWPSubscriptionSubscribed", Z69WWPSubscriptionSubscribed);
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPENTITYID", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.subscriptions.wwp_subscription.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Subscriptions.WWP_Subscription" ;
      }

      public override string GetPgmdesc( )
      {
         return "WWP_Subscription" ;
      }

      protected void InitializeNonKey088( )
      {
         A62WWPEntityId = 0;
         AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
         A65WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
         A71WWPNotificationDefinitionDescr = "";
         AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
         A63WWPEntityName = "";
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
         A50WWPUserExtendedFullName = "";
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A68WWPSubscriptionEntityRecordId = "";
         AssignAttri("", false, "A68WWPSubscriptionEntityRecordId", A68WWPSubscriptionEntityRecordId);
         A70WWPSubscriptionEntityRecordDes = "";
         AssignAttri("", false, "A70WWPSubscriptionEntityRecordDes", A70WWPSubscriptionEntityRecordDes);
         A61WWPSubscriptionRoleId = "";
         n61WWPSubscriptionRoleId = false;
         AssignAttri("", false, "A61WWPSubscriptionRoleId", A61WWPSubscriptionRoleId);
         n61WWPSubscriptionRoleId = (String.IsNullOrEmpty(StringUtil.RTrim( A61WWPSubscriptionRoleId)) ? true : false);
         A69WWPSubscriptionSubscribed = false;
         AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
         Z68WWPSubscriptionEntityRecordId = "";
         Z70WWPSubscriptionEntityRecordDes = "";
         Z61WWPSubscriptionRoleId = "";
         Z69WWPSubscriptionSubscribed = false;
         Z65WWPNotificationDefinitionId = 0;
         Z49WWPUserExtendedId = "";
      }

      protected void InitAll088( )
      {
         A67WWPSubscriptionId = 0;
         AssignAttri("", false, "A67WWPSubscriptionId", StringUtil.LTrimStr( (decimal)(A67WWPSubscriptionId), 10, 0));
         InitializeNonKey088( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828115086", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/subscriptions/wwp_subscription.js", "?2023828115087", false, true);
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
         edtWWPSubscriptionId_Internalname = "WWPSUBSCRIPTIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionDescr_Internalname = "WWPNOTIFICATIONDEFINITIONDESCR";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPSubscriptionEntityRecordId_Internalname = "WWPSUBSCRIPTIONENTITYRECORDID";
         edtWWPSubscriptionEntityRecordDes_Internalname = "WWPSUBSCRIPTIONENTITYRECORDDES";
         edtWWPSubscriptionRoleId_Internalname = "WWPSUBSCRIPTIONROLEID";
         chkWWPSubscriptionSubscribed_Internalname = "WWPSUBSCRIPTIONSUBSCRIBED";
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
         Form.Caption = "WWP_Subscription";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         chkWWPSubscriptionSubscribed.Enabled = 1;
         edtWWPSubscriptionRoleId_Jsonclick = "";
         edtWWPSubscriptionRoleId_Enabled = 1;
         edtWWPSubscriptionEntityRecordDes_Enabled = 1;
         edtWWPSubscriptionEntityRecordId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPNotificationDefinitionDescr_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPSubscriptionId_Jsonclick = "";
         edtWWPSubscriptionId_Enabled = 1;
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
         chkWWPSubscriptionSubscribed.Name = "WWPSUBSCRIPTIONSUBSCRIBED";
         chkWWPSubscriptionSubscribed.WebTags = "";
         chkWWPSubscriptionSubscribed.Caption = "";
         AssignProp("", false, chkWWPSubscriptionSubscribed_Internalname, "TitleCaption", chkWWPSubscriptionSubscribed.Caption, true);
         chkWWPSubscriptionSubscribed.CheckedValue = "false";
         A69WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A69WWPSubscriptionSubscribed));
         AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
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

      public void Valid_Wwpsubscriptionid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A69WWPSubscriptionSubscribed = StringUtil.StrToBool( StringUtil.BoolToStr( A69WWPSubscriptionSubscribed));
         /*  Sending validation outputs */
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A49WWPUserExtendedId", StringUtil.RTrim( A49WWPUserExtendedId));
         AssignAttri("", false, "A68WWPSubscriptionEntityRecordId", A68WWPSubscriptionEntityRecordId);
         AssignAttri("", false, "A70WWPSubscriptionEntityRecordDes", A70WWPSubscriptionEntityRecordDes);
         AssignAttri("", false, "A61WWPSubscriptionRoleId", StringUtil.RTrim( A61WWPSubscriptionRoleId));
         AssignAttri("", false, "A69WWPSubscriptionSubscribed", A69WWPSubscriptionSubscribed);
         AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z67WWPSubscriptionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z67WWPSubscriptionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z68WWPSubscriptionEntityRecordId", Z68WWPSubscriptionEntityRecordId);
         GxWebStd.gx_hidden_field( context, "Z70WWPSubscriptionEntityRecordDes", Z70WWPSubscriptionEntityRecordDes);
         GxWebStd.gx_hidden_field( context, "Z61WWPSubscriptionRoleId", StringUtil.RTrim( Z61WWPSubscriptionRoleId));
         GxWebStd.gx_hidden_field( context, "Z69WWPSubscriptionSubscribed", StringUtil.BoolToStr( Z69WWPSubscriptionSubscribed));
         GxWebStd.gx_hidden_field( context, "Z62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z71WWPNotificationDefinitionDescr", Z71WWPNotificationDefinitionDescr);
         GxWebStd.gx_hidden_field( context, "Z63WWPEntityName", Z63WWPEntityName);
         GxWebStd.gx_hidden_field( context, "Z50WWPUserExtendedFullName", Z50WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000818 */
         pr_default.execute(16, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A62WWPEntityId = T000818_A62WWPEntityId[0];
         A71WWPNotificationDefinitionDescr = T000818_A71WWPNotificationDefinitionDescr[0];
         pr_default.close(16);
         /* Using cursor T000819 */
         pr_default.execute(17, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
         }
         A63WWPEntityName = T000819_A63WWPEntityName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A71WWPNotificationDefinitionDescr", A71WWPNotificationDefinitionDescr);
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n49WWPUserExtendedId = false;
         /* Using cursor T000820 */
         pr_default.execute(18, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(18) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A50WWPUserExtendedFullName = T000820_A50WWPUserExtendedFullName[0];
         pr_default.close(18);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID","{handler:'Valid_Wwpsubscriptionid',iparms:[{av:'A67WWPSubscriptionId',fld:'WWPSUBSCRIPTIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPSUBSCRIPTIONID",",oparms:[{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A68WWPSubscriptionEntityRecordId',fld:'WWPSUBSCRIPTIONENTITYRECORDID',pic:''},{av:'A70WWPSubscriptionEntityRecordDes',fld:'WWPSUBSCRIPTIONENTITYRECORDDES',pic:''},{av:'A61WWPSubscriptionRoleId',fld:'WWPSUBSCRIPTIONROLEID',pic:''},{av:'A62WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A71WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:''},{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z67WWPSubscriptionId'},{av:'Z65WWPNotificationDefinitionId'},{av:'Z49WWPUserExtendedId'},{av:'Z68WWPSubscriptionEntityRecordId'},{av:'Z70WWPSubscriptionEntityRecordDes'},{av:'Z61WWPSubscriptionRoleId'},{av:'Z69WWPSubscriptionSubscribed'},{av:'Z62WWPEntityId'},{av:'Z71WWPNotificationDefinitionDescr'},{av:'Z63WWPEntityName'},{av:'Z50WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A62WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A71WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:''},{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A62WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A71WWPNotificationDefinitionDescr',fld:'WWPNOTIFICATIONDEFINITIONDESCR',pic:''},{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A69WWPSubscriptionSubscribed',fld:'WWPSUBSCRIPTIONSUBSCRIBED',pic:''}]}");
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
         pr_default.close(16);
         pr_default.close(18);
         pr_default.close(17);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z68WWPSubscriptionEntityRecordId = "";
         Z70WWPSubscriptionEntityRecordDes = "";
         Z61WWPSubscriptionRoleId = "";
         Z49WWPUserExtendedId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         A49WWPUserExtendedId = "";
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
         A71WWPNotificationDefinitionDescr = "";
         A63WWPEntityName = "";
         A50WWPUserExtendedFullName = "";
         A68WWPSubscriptionEntityRecordId = "";
         A70WWPSubscriptionEntityRecordDes = "";
         A61WWPSubscriptionRoleId = "";
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
         Z71WWPNotificationDefinitionDescr = "";
         Z63WWPEntityName = "";
         Z50WWPUserExtendedFullName = "";
         T00087_A62WWPEntityId = new long[1] ;
         T00087_A67WWPSubscriptionId = new long[1] ;
         T00087_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         T00087_A63WWPEntityName = new string[] {""} ;
         T00087_A50WWPUserExtendedFullName = new string[] {""} ;
         T00087_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00087_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00087_A61WWPSubscriptionRoleId = new string[] {""} ;
         T00087_n61WWPSubscriptionRoleId = new bool[] {false} ;
         T00087_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         T00087_A65WWPNotificationDefinitionId = new long[1] ;
         T00087_A49WWPUserExtendedId = new string[] {""} ;
         T00087_n49WWPUserExtendedId = new bool[] {false} ;
         T00084_A62WWPEntityId = new long[1] ;
         T00084_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         T00086_A63WWPEntityName = new string[] {""} ;
         T00085_A50WWPUserExtendedFullName = new string[] {""} ;
         T00088_A62WWPEntityId = new long[1] ;
         T00088_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         T00089_A63WWPEntityName = new string[] {""} ;
         T000810_A50WWPUserExtendedFullName = new string[] {""} ;
         T000811_A67WWPSubscriptionId = new long[1] ;
         T00083_A67WWPSubscriptionId = new long[1] ;
         T00083_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00083_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00083_A61WWPSubscriptionRoleId = new string[] {""} ;
         T00083_n61WWPSubscriptionRoleId = new bool[] {false} ;
         T00083_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         T00083_A65WWPNotificationDefinitionId = new long[1] ;
         T00083_A49WWPUserExtendedId = new string[] {""} ;
         T00083_n49WWPUserExtendedId = new bool[] {false} ;
         sMode8 = "";
         T000812_A67WWPSubscriptionId = new long[1] ;
         T000813_A67WWPSubscriptionId = new long[1] ;
         T00082_A67WWPSubscriptionId = new long[1] ;
         T00082_A68WWPSubscriptionEntityRecordId = new string[] {""} ;
         T00082_A70WWPSubscriptionEntityRecordDes = new string[] {""} ;
         T00082_A61WWPSubscriptionRoleId = new string[] {""} ;
         T00082_n61WWPSubscriptionRoleId = new bool[] {false} ;
         T00082_A69WWPSubscriptionSubscribed = new bool[] {false} ;
         T00082_A65WWPNotificationDefinitionId = new long[1] ;
         T00082_A49WWPUserExtendedId = new string[] {""} ;
         T00082_n49WWPUserExtendedId = new bool[] {false} ;
         T000815_A67WWPSubscriptionId = new long[1] ;
         T000818_A62WWPEntityId = new long[1] ;
         T000818_A71WWPNotificationDefinitionDescr = new string[] {""} ;
         T000819_A63WWPEntityName = new string[] {""} ;
         T000820_A50WWPUserExtendedFullName = new string[] {""} ;
         T000821_A67WWPSubscriptionId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ49WWPUserExtendedId = "";
         ZZ68WWPSubscriptionEntityRecordId = "";
         ZZ70WWPSubscriptionEntityRecordDes = "";
         ZZ61WWPSubscriptionRoleId = "";
         ZZ71WWPNotificationDefinitionDescr = "";
         ZZ63WWPEntityName = "";
         ZZ50WWPUserExtendedFullName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.subscriptions.wwp_subscription__default(),
            new Object[][] {
                new Object[] {
               T00082_A67WWPSubscriptionId, T00082_A68WWPSubscriptionEntityRecordId, T00082_A70WWPSubscriptionEntityRecordDes, T00082_A61WWPSubscriptionRoleId, T00082_n61WWPSubscriptionRoleId, T00082_A69WWPSubscriptionSubscribed, T00082_A65WWPNotificationDefinitionId, T00082_A49WWPUserExtendedId, T00082_n49WWPUserExtendedId
               }
               , new Object[] {
               T00083_A67WWPSubscriptionId, T00083_A68WWPSubscriptionEntityRecordId, T00083_A70WWPSubscriptionEntityRecordDes, T00083_A61WWPSubscriptionRoleId, T00083_n61WWPSubscriptionRoleId, T00083_A69WWPSubscriptionSubscribed, T00083_A65WWPNotificationDefinitionId, T00083_A49WWPUserExtendedId, T00083_n49WWPUserExtendedId
               }
               , new Object[] {
               T00084_A62WWPEntityId, T00084_A71WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00085_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T00086_A63WWPEntityName
               }
               , new Object[] {
               T00087_A62WWPEntityId, T00087_A67WWPSubscriptionId, T00087_A71WWPNotificationDefinitionDescr, T00087_A63WWPEntityName, T00087_A50WWPUserExtendedFullName, T00087_A68WWPSubscriptionEntityRecordId, T00087_A70WWPSubscriptionEntityRecordDes, T00087_A61WWPSubscriptionRoleId, T00087_n61WWPSubscriptionRoleId, T00087_A69WWPSubscriptionSubscribed,
               T00087_A65WWPNotificationDefinitionId, T00087_A49WWPUserExtendedId, T00087_n49WWPUserExtendedId
               }
               , new Object[] {
               T00088_A62WWPEntityId, T00088_A71WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T00089_A63WWPEntityName
               }
               , new Object[] {
               T000810_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T000811_A67WWPSubscriptionId
               }
               , new Object[] {
               T000812_A67WWPSubscriptionId
               }
               , new Object[] {
               T000813_A67WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               T000815_A67WWPSubscriptionId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000818_A62WWPEntityId, T000818_A71WWPNotificationDefinitionDescr
               }
               , new Object[] {
               T000819_A63WWPEntityName
               }
               , new Object[] {
               T000820_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T000821_A67WWPSubscriptionId
               }
            }
         );
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short GX_JID ;
      private short RcdFound8 ;
      private short nIsDirty_8 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPSubscriptionId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionDescr_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPSubscriptionEntityRecordId_Enabled ;
      private int edtWWPSubscriptionEntityRecordDes_Enabled ;
      private int edtWWPSubscriptionRoleId_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z67WWPSubscriptionId ;
      private long Z65WWPNotificationDefinitionId ;
      private long A65WWPNotificationDefinitionId ;
      private long A62WWPEntityId ;
      private long A67WWPSubscriptionId ;
      private long Z62WWPEntityId ;
      private long ZZ67WWPSubscriptionId ;
      private long ZZ65WWPNotificationDefinitionId ;
      private long ZZ62WWPEntityId ;
      private string sPrefix ;
      private string Z61WWPSubscriptionRoleId ;
      private string Z49WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A49WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPSubscriptionId_Internalname ;
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
      private string edtWWPSubscriptionId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionDescr_Internalname ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPSubscriptionEntityRecordId_Internalname ;
      private string edtWWPSubscriptionEntityRecordDes_Internalname ;
      private string edtWWPSubscriptionRoleId_Internalname ;
      private string A61WWPSubscriptionRoleId ;
      private string edtWWPSubscriptionRoleId_Jsonclick ;
      private string chkWWPSubscriptionSubscribed_Internalname ;
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
      private string sMode8 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ49WWPUserExtendedId ;
      private string ZZ61WWPSubscriptionRoleId ;
      private bool Z69WWPSubscriptionSubscribed ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n49WWPUserExtendedId ;
      private bool wbErr ;
      private bool A69WWPSubscriptionSubscribed ;
      private bool n61WWPSubscriptionRoleId ;
      private bool Gx_longc ;
      private bool ZZ69WWPSubscriptionSubscribed ;
      private string Z68WWPSubscriptionEntityRecordId ;
      private string Z70WWPSubscriptionEntityRecordDes ;
      private string A71WWPNotificationDefinitionDescr ;
      private string A63WWPEntityName ;
      private string A50WWPUserExtendedFullName ;
      private string A68WWPSubscriptionEntityRecordId ;
      private string A70WWPSubscriptionEntityRecordDes ;
      private string Z71WWPNotificationDefinitionDescr ;
      private string Z63WWPEntityName ;
      private string Z50WWPUserExtendedFullName ;
      private string ZZ68WWPSubscriptionEntityRecordId ;
      private string ZZ70WWPSubscriptionEntityRecordDes ;
      private string ZZ71WWPNotificationDefinitionDescr ;
      private string ZZ63WWPEntityName ;
      private string ZZ50WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPSubscriptionSubscribed ;
      private IDataStoreProvider pr_default ;
      private long[] T00087_A62WWPEntityId ;
      private long[] T00087_A67WWPSubscriptionId ;
      private string[] T00087_A71WWPNotificationDefinitionDescr ;
      private string[] T00087_A63WWPEntityName ;
      private string[] T00087_A50WWPUserExtendedFullName ;
      private string[] T00087_A68WWPSubscriptionEntityRecordId ;
      private string[] T00087_A70WWPSubscriptionEntityRecordDes ;
      private string[] T00087_A61WWPSubscriptionRoleId ;
      private bool[] T00087_n61WWPSubscriptionRoleId ;
      private bool[] T00087_A69WWPSubscriptionSubscribed ;
      private long[] T00087_A65WWPNotificationDefinitionId ;
      private string[] T00087_A49WWPUserExtendedId ;
      private bool[] T00087_n49WWPUserExtendedId ;
      private long[] T00084_A62WWPEntityId ;
      private string[] T00084_A71WWPNotificationDefinitionDescr ;
      private string[] T00086_A63WWPEntityName ;
      private string[] T00085_A50WWPUserExtendedFullName ;
      private long[] T00088_A62WWPEntityId ;
      private string[] T00088_A71WWPNotificationDefinitionDescr ;
      private string[] T00089_A63WWPEntityName ;
      private string[] T000810_A50WWPUserExtendedFullName ;
      private long[] T000811_A67WWPSubscriptionId ;
      private long[] T00083_A67WWPSubscriptionId ;
      private string[] T00083_A68WWPSubscriptionEntityRecordId ;
      private string[] T00083_A70WWPSubscriptionEntityRecordDes ;
      private string[] T00083_A61WWPSubscriptionRoleId ;
      private bool[] T00083_n61WWPSubscriptionRoleId ;
      private bool[] T00083_A69WWPSubscriptionSubscribed ;
      private long[] T00083_A65WWPNotificationDefinitionId ;
      private string[] T00083_A49WWPUserExtendedId ;
      private bool[] T00083_n49WWPUserExtendedId ;
      private long[] T000812_A67WWPSubscriptionId ;
      private long[] T000813_A67WWPSubscriptionId ;
      private long[] T00082_A67WWPSubscriptionId ;
      private string[] T00082_A68WWPSubscriptionEntityRecordId ;
      private string[] T00082_A70WWPSubscriptionEntityRecordDes ;
      private string[] T00082_A61WWPSubscriptionRoleId ;
      private bool[] T00082_n61WWPSubscriptionRoleId ;
      private bool[] T00082_A69WWPSubscriptionSubscribed ;
      private long[] T00082_A65WWPNotificationDefinitionId ;
      private string[] T00082_A49WWPUserExtendedId ;
      private bool[] T00082_n49WWPUserExtendedId ;
      private long[] T000815_A67WWPSubscriptionId ;
      private long[] T000818_A62WWPEntityId ;
      private string[] T000818_A71WWPNotificationDefinitionDescr ;
      private string[] T000819_A63WWPEntityName ;
      private string[] T000820_A50WWPUserExtendedFullName ;
      private long[] T000821_A67WWPSubscriptionId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_subscription__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_subscription__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[11])
       ,new UpdateCursor(def[12])
       ,new ForEachCursor(def[13])
       ,new UpdateCursor(def[14])
       ,new UpdateCursor(def[15])
       ,new ForEachCursor(def[16])
       ,new ForEachCursor(def[17])
       ,new ForEachCursor(def[18])
       ,new ForEachCursor(def[19])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT00087;
        prmT00087 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00084;
        prmT00084 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00086;
        prmT00086 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT00085;
        prmT00085 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00088;
        prmT00088 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT00089;
        prmT00089 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000810;
        prmT000810 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000811;
        prmT000811 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00083;
        prmT00083 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000812;
        prmT000812 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000813;
        prmT000813 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT00082;
        prmT00082 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000814;
        prmT000814 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000815;
        prmT000815 = new Object[] {
        };
        Object[] prmT000816;
        prmT000816 = new Object[] {
        new ParDef("WWPSubscriptionEntityRecordId",GXType.VarChar,2000,0) ,
        new ParDef("WWPSubscriptionEntityRecordDes",GXType.VarChar,200,0) ,
        new ParDef("WWPSubscriptionRoleId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionSubscribed",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000817;
        prmT000817 = new Object[] {
        new ParDef("WWPSubscriptionId",GXType.Int64,10,0)
        };
        Object[] prmT000821;
        prmT000821 = new Object[] {
        };
        Object[] prmT000818;
        prmT000818 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000819;
        prmT000819 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000820;
        prmT000820 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T00082", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId  FOR UPDATE OF WWP_Subscription NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00082,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00083", "SELECT WWPSubscriptionId, WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00083,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00084", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00084,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00085", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00085,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00086", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00086,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00087", "SELECT T2.WWPEntityId, TM1.WWPSubscriptionId, T2.WWPNotificationDefinitionDescr, T3.WWPEntityName, T4.WWPUserExtendedFullName, TM1.WWPSubscriptionEntityRecordId, TM1.WWPSubscriptionEntityRecordDes, TM1.WWPSubscriptionRoleId, TM1.WWPSubscriptionSubscribed, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM (((WWP_Subscription TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = T2.WWPEntityId) LEFT JOIN WWP_UserExtended T4 ON T4.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPSubscriptionId = :WWPSubscriptionId ORDER BY TM1.WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00087,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00088", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00088,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00089", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00089,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000810", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000810,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000811", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPSubscriptionId = :WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000811,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000812", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId > :WWPSubscriptionId) ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000812,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000813", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE ( WWPSubscriptionId < :WWPSubscriptionId) ORDER BY WWPSubscriptionId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000813,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000814", "SAVEPOINT gxupdate;INSERT INTO WWP_Subscription(WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId, WWPSubscriptionSubscribed, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPSubscriptionEntityRecordId, :WWPSubscriptionEntityRecordDes, :WWPSubscriptionRoleId, :WWPSubscriptionSubscribed, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000814)
           ,new CursorDef("T000815", "SELECT currval('WWPSubscriptionId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000815,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000816", "SAVEPOINT gxupdate;UPDATE WWP_Subscription SET WWPSubscriptionEntityRecordId=:WWPSubscriptionEntityRecordId, WWPSubscriptionEntityRecordDes=:WWPSubscriptionEntityRecordDes, WWPSubscriptionRoleId=:WWPSubscriptionRoleId, WWPSubscriptionSubscribed=:WWPSubscriptionSubscribed, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000816)
           ,new CursorDef("T000817", "SAVEPOINT gxupdate;DELETE FROM WWP_Subscription  WHERE WWPSubscriptionId = :WWPSubscriptionId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000817)
           ,new CursorDef("T000818", "SELECT WWPEntityId, WWPNotificationDefinitionDescr FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000818,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000819", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000819,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000820", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000820,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000821", "SELECT WWPSubscriptionId FROM WWP_Subscription ORDER BY WWPSubscriptionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000821,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getString(4, 40);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((bool[]) buf[5])[0] = rslt.getBool(5);
              ((long[]) buf[6])[0] = rslt.getLong(6);
              ((string[]) buf[7])[0] = rslt.getString(7, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((long[]) buf[1])[0] = rslt.getLong(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((bool[]) buf[9])[0] = rslt.getBool(9);
              ((long[]) buf[10])[0] = rslt.getLong(10);
              ((string[]) buf[11])[0] = rslt.getString(11, 40);
              ((bool[]) buf[12])[0] = rslt.wasNull(11);
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 8 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
