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
namespace GeneXus.Programs.wwpbaseobjects.notifications.common {
   public class wwp_notification : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A65WWPNotificationDefinitionId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationDefinitionId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A65WWPNotificationDefinitionId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
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
            gxLoad_6( A49WWPUserExtendedId) ;
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
            Form.Meta.addItem("description", "Notification", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_notification( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_notification( IGxContext context )
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
         chkWWPNotificationIsRead = new GXCheckbox();
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
            return "wwp_notification_Execute" ;
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
         A124WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A124WWPNotificationIsRead));
         AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Notification", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationDefinitionId_Enabled!=0) ? context.localUtil.Format( (decimal)(A65WWPNotificationDefinitionId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A65WWPNotificationDefinitionId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationDefinitionName_Internalname, A101WWPNotificationDefinitionName, StringUtil.RTrim( context.localUtil.Format( A101WWPNotificationDefinitionName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationDefinitionName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationDefinitionName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationCreated_Internalname, "Created Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPNotificationCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A66WWPNotificationCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationIcon_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationIcon_Internalname, "Icon", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationIcon_Internalname, A118WWPNotificationIcon, StringUtil.RTrim( context.localUtil.Format( A118WWPNotificationIcon, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationIcon_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationIcon_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationTitle_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationTitle_Internalname, "Title", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationTitle_Internalname, A119WWPNotificationTitle, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPNotificationTitle_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationShortDescriptio_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationShortDescriptio_Internalname, "Short Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationShortDescriptio_Internalname, A120WWPNotificationShortDescriptio, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPNotificationShortDescriptio_Enabled, 0, 80, "chr", 3, "row", 0, StyleString, ClassString, "", "", "200", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPNotificationLink_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPNotificationLink_Internalname, "Link", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationLink_Internalname, A121WWPNotificationLink, StringUtil.RTrim( context.localUtil.Format( A121WWPNotificationLink, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", A121WWPNotificationLink, "_blank", "", "", edtWWPNotificationLink_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationLink_Enabled, 0, "url", "", 80, "chr", 1, "row", 1000, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Url", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPNotificationIsRead_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPNotificationIsRead_Internalname, "Is Read", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPNotificationIsRead_Internalname, StringUtil.BoolToStr( A124WWPNotificationIsRead), "", "Is Read", 1, chkWWPNotificationIsRead.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A49WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A49WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A50WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A50WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         GxWebStd.gx_label_element( context, edtWWPNotificationMetadata_Internalname, "Metadata", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPNotificationMetadata_Internalname, A102WWPNotificationMetadata, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,89);\"", 0, 1, edtWWPNotificationMetadata_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Notifications\\Common\\WWP_Notification.htm");
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
            Z64WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z64WWPNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            Z66WWPNotificationCreated = context.localUtil.CToT( cgiGet( "Z66WWPNotificationCreated"), 0);
            Z118WWPNotificationIcon = cgiGet( "Z118WWPNotificationIcon");
            Z119WWPNotificationTitle = cgiGet( "Z119WWPNotificationTitle");
            Z120WWPNotificationShortDescriptio = cgiGet( "Z120WWPNotificationShortDescriptio");
            Z121WWPNotificationLink = cgiGet( "Z121WWPNotificationLink");
            Z124WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( "Z124WWPNotificationIsRead"));
            Z65WWPNotificationDefinitionId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z65WWPNotificationDefinitionId"), ",", "."), 18, MidpointRounding.ToEven));
            Z49WWPUserExtendedId = cgiGet( "Z49WWPUserExtendedId");
            n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
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
            A101WWPNotificationDefinitionName = cgiGet( edtWWPNotificationDefinitionName_Internalname);
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPNotificationCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Notification Created Date"}), 1, "WWPNOTIFICATIONCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A66WWPNotificationCreated = context.localUtil.CToT( cgiGet( edtWWPNotificationCreated_Internalname));
               AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            A118WWPNotificationIcon = cgiGet( edtWWPNotificationIcon_Internalname);
            AssignAttri("", false, "A118WWPNotificationIcon", A118WWPNotificationIcon);
            A119WWPNotificationTitle = cgiGet( edtWWPNotificationTitle_Internalname);
            AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
            A120WWPNotificationShortDescriptio = cgiGet( edtWWPNotificationShortDescriptio_Internalname);
            AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
            A121WWPNotificationLink = cgiGet( edtWWPNotificationLink_Internalname);
            AssignAttri("", false, "A121WWPNotificationLink", A121WWPNotificationLink);
            A124WWPNotificationIsRead = StringUtil.StrToBool( cgiGet( chkWWPNotificationIsRead_Internalname));
            AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
            A49WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
            A50WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A102WWPNotificationMetadata = cgiGet( edtWWPNotificationMetadata_Internalname);
            n102WWPNotificationMetadata = false;
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            n102WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A102WWPNotificationMetadata)) ? true : false);
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
               A64WWPNotificationId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPNotificationId"), "."), 18, MidpointRounding.ToEven));
               n64WWPNotificationId = false;
               AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
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
               InitAll0D13( ) ;
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
         DisableAttributes0D13( ) ;
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

      protected void ResetCaption0D0( )
      {
      }

      protected void ZM0D13( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z66WWPNotificationCreated = T000D3_A66WWPNotificationCreated[0];
               Z118WWPNotificationIcon = T000D3_A118WWPNotificationIcon[0];
               Z119WWPNotificationTitle = T000D3_A119WWPNotificationTitle[0];
               Z120WWPNotificationShortDescriptio = T000D3_A120WWPNotificationShortDescriptio[0];
               Z121WWPNotificationLink = T000D3_A121WWPNotificationLink[0];
               Z124WWPNotificationIsRead = T000D3_A124WWPNotificationIsRead[0];
               Z65WWPNotificationDefinitionId = T000D3_A65WWPNotificationDefinitionId[0];
               Z49WWPUserExtendedId = T000D3_A49WWPUserExtendedId[0];
            }
            else
            {
               Z66WWPNotificationCreated = A66WWPNotificationCreated;
               Z118WWPNotificationIcon = A118WWPNotificationIcon;
               Z119WWPNotificationTitle = A119WWPNotificationTitle;
               Z120WWPNotificationShortDescriptio = A120WWPNotificationShortDescriptio;
               Z121WWPNotificationLink = A121WWPNotificationLink;
               Z124WWPNotificationIsRead = A124WWPNotificationIsRead;
               Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
               Z49WWPUserExtendedId = A49WWPUserExtendedId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z64WWPNotificationId = A64WWPNotificationId;
            Z66WWPNotificationCreated = A66WWPNotificationCreated;
            Z118WWPNotificationIcon = A118WWPNotificationIcon;
            Z119WWPNotificationTitle = A119WWPNotificationTitle;
            Z120WWPNotificationShortDescriptio = A120WWPNotificationShortDescriptio;
            Z121WWPNotificationLink = A121WWPNotificationLink;
            Z124WWPNotificationIsRead = A124WWPNotificationIsRead;
            Z102WWPNotificationMetadata = A102WWPNotificationMetadata;
            Z65WWPNotificationDefinitionId = A65WWPNotificationDefinitionId;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z101WWPNotificationDefinitionName = A101WWPNotificationDefinitionName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
         }
      }

      protected void standaloneNotModal( )
      {
         Gx_BScreen = 0;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
      }

      protected void standaloneModal( )
      {
         if ( IsIns( )  && (DateTime.MinValue==A66WWPNotificationCreated) && ( Gx_BScreen == 0 ) )
         {
            A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
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
      }

      protected void Load0D13( )
      {
         /* Using cursor T000D6 */
         pr_default.execute(4, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            RcdFound13 = 1;
            A101WWPNotificationDefinitionName = T000D6_A101WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            A66WWPNotificationCreated = T000D6_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A118WWPNotificationIcon = T000D6_A118WWPNotificationIcon[0];
            AssignAttri("", false, "A118WWPNotificationIcon", A118WWPNotificationIcon);
            A119WWPNotificationTitle = T000D6_A119WWPNotificationTitle[0];
            AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
            A120WWPNotificationShortDescriptio = T000D6_A120WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
            A121WWPNotificationLink = T000D6_A121WWPNotificationLink[0];
            AssignAttri("", false, "A121WWPNotificationLink", A121WWPNotificationLink);
            A124WWPNotificationIsRead = T000D6_A124WWPNotificationIsRead[0];
            AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
            A50WWPUserExtendedFullName = T000D6_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A102WWPNotificationMetadata = T000D6_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = T000D6_n102WWPNotificationMetadata[0];
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            A65WWPNotificationDefinitionId = T000D6_A65WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            A49WWPUserExtendedId = T000D6_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T000D6_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            ZM0D13( -4) ;
         }
         pr_default.close(4);
         OnLoadActions0D13( ) ;
      }

      protected void OnLoadActions0D13( )
      {
      }

      protected void CheckExtendedTable0D13( )
      {
         nIsDirty_13 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         /* Using cursor T000D4 */
         pr_default.execute(2, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101WWPNotificationDefinitionName = T000D4_A101WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         pr_default.close(2);
         if ( ! ( GxRegex.IsMatch(A121WWPNotificationLink,"^((?:[a-zA-Z]+:(//)?)?((?:(?:[a-zA-Z]([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*)(?:\\.(?:([a-zA-Z0-9$\\-_@&+!*\"'(),]|%[0-9a-fA-F]{2})*))*)|(?:(\\d{1,3}\\.){3}\\d{1,3}))(?::\\d+)?(?:/([a-zA-Z0-9$\\-_@.&+!*\"'(),=;: ]|%[0-9a-fA-F]{2})+)*/?(?:[#?](?:[a-zA-Z0-9$\\-_@.&+!*\"'(),=;: /]|%[0-9a-fA-F]{2})*)?)?\\s*$") ) )
         {
            GX_msglist.addItem("O valor de Notification Link não coincide com o padrão especificado", "OutOfRange", 1, "WWPNOTIFICATIONLINK");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationLink_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000D5 */
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
         A50WWPUserExtendedFullName = T000D5_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0D13( )
      {
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_5( long A65WWPNotificationDefinitionId )
      {
         /* Using cursor T000D7 */
         pr_default.execute(5, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(5) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A101WWPNotificationDefinitionName = T000D7_A101WWPNotificationDefinitionName[0];
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A101WWPNotificationDefinitionName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(5) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(5);
      }

      protected void gxLoad_6( string A49WWPUserExtendedId )
      {
         /* Using cursor T000D8 */
         pr_default.execute(6, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A50WWPUserExtendedFullName = T000D8_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A50WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0D13( )
      {
         /* Using cursor T000D9 */
         pr_default.execute(7, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound13 = 1;
         }
         else
         {
            RcdFound13 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000D3 */
         pr_default.execute(1, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0D13( 4) ;
            RcdFound13 = 1;
            A64WWPNotificationId = T000D3_A64WWPNotificationId[0];
            n64WWPNotificationId = T000D3_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            A66WWPNotificationCreated = T000D3_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A118WWPNotificationIcon = T000D3_A118WWPNotificationIcon[0];
            AssignAttri("", false, "A118WWPNotificationIcon", A118WWPNotificationIcon);
            A119WWPNotificationTitle = T000D3_A119WWPNotificationTitle[0];
            AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
            A120WWPNotificationShortDescriptio = T000D3_A120WWPNotificationShortDescriptio[0];
            AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
            A121WWPNotificationLink = T000D3_A121WWPNotificationLink[0];
            AssignAttri("", false, "A121WWPNotificationLink", A121WWPNotificationLink);
            A124WWPNotificationIsRead = T000D3_A124WWPNotificationIsRead[0];
            AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
            A102WWPNotificationMetadata = T000D3_A102WWPNotificationMetadata[0];
            n102WWPNotificationMetadata = T000D3_n102WWPNotificationMetadata[0];
            AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
            A65WWPNotificationDefinitionId = T000D3_A65WWPNotificationDefinitionId[0];
            AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
            A49WWPUserExtendedId = T000D3_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T000D3_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            Z64WWPNotificationId = A64WWPNotificationId;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0D13( ) ;
            if ( AnyError == 1 )
            {
               RcdFound13 = 0;
               InitializeNonKey0D13( ) ;
            }
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound13 = 0;
            InitializeNonKey0D13( ) ;
            sMode13 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode13;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0D13( ) ;
         if ( RcdFound13 == 0 )
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
         RcdFound13 = 0;
         /* Using cursor T000D10 */
         pr_default.execute(8, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A64WWPNotificationId[0] < A64WWPNotificationId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000D10_A64WWPNotificationId[0] > A64WWPNotificationId ) ) )
            {
               A64WWPNotificationId = T000D10_A64WWPNotificationId[0];
               n64WWPNotificationId = T000D10_n64WWPNotificationId[0];
               AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound13 = 0;
         /* Using cursor T000D11 */
         pr_default.execute(9, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000D11_A64WWPNotificationId[0] > A64WWPNotificationId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000D11_A64WWPNotificationId[0] < A64WWPNotificationId ) ) )
            {
               A64WWPNotificationId = T000D11_A64WWPNotificationId[0];
               n64WWPNotificationId = T000D11_n64WWPNotificationId[0];
               AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
               RcdFound13 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0D13( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0D13( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound13 == 1 )
            {
               if ( A64WWPNotificationId != Z64WWPNotificationId )
               {
                  A64WWPNotificationId = Z64WWPNotificationId;
                  n64WWPNotificationId = false;
                  AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPNOTIFICATIONID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0D13( ) ;
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A64WWPNotificationId != Z64WWPNotificationId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPNotificationId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0D13( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPNOTIFICATIONID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPNotificationId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0D13( ) ;
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
         if ( A64WWPNotificationId != Z64WWPNotificationId )
         {
            A64WWPNotificationId = Z64WWPNotificationId;
            n64WWPNotificationId = false;
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPNOTIFICATIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationId_Internalname;
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
         ScanStart0D13( ) ;
         if ( RcdFound13 == 0 )
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
         ScanEnd0D13( ) ;
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
         if ( RcdFound13 == 0 )
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
         if ( RcdFound13 == 0 )
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
         ScanStart0D13( ) ;
         if ( RcdFound13 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound13 != 0 )
            {
               ScanNext0D13( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0D13( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0D13( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000D2 */
            pr_default.execute(0, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z66WWPNotificationCreated != T000D2_A66WWPNotificationCreated[0] ) || ( StringUtil.StrCmp(Z118WWPNotificationIcon, T000D2_A118WWPNotificationIcon[0]) != 0 ) || ( StringUtil.StrCmp(Z119WWPNotificationTitle, T000D2_A119WWPNotificationTitle[0]) != 0 ) || ( StringUtil.StrCmp(Z120WWPNotificationShortDescriptio, T000D2_A120WWPNotificationShortDescriptio[0]) != 0 ) || ( StringUtil.StrCmp(Z121WWPNotificationLink, T000D2_A121WWPNotificationLink[0]) != 0 ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z124WWPNotificationIsRead != T000D2_A124WWPNotificationIsRead[0] ) || ( Z65WWPNotificationDefinitionId != T000D2_A65WWPNotificationDefinitionId[0] ) || ( StringUtil.StrCmp(Z49WWPUserExtendedId, T000D2_A49WWPUserExtendedId[0]) != 0 ) )
            {
               if ( Z66WWPNotificationCreated != T000D2_A66WWPNotificationCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationCreated");
                  GXUtil.WriteLogRaw("Old: ",Z66WWPNotificationCreated);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A66WWPNotificationCreated[0]);
               }
               if ( StringUtil.StrCmp(Z118WWPNotificationIcon, T000D2_A118WWPNotificationIcon[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIcon");
                  GXUtil.WriteLogRaw("Old: ",Z118WWPNotificationIcon);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A118WWPNotificationIcon[0]);
               }
               if ( StringUtil.StrCmp(Z119WWPNotificationTitle, T000D2_A119WWPNotificationTitle[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationTitle");
                  GXUtil.WriteLogRaw("Old: ",Z119WWPNotificationTitle);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A119WWPNotificationTitle[0]);
               }
               if ( StringUtil.StrCmp(Z120WWPNotificationShortDescriptio, T000D2_A120WWPNotificationShortDescriptio[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationShortDescriptio");
                  GXUtil.WriteLogRaw("Old: ",Z120WWPNotificationShortDescriptio);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A120WWPNotificationShortDescriptio[0]);
               }
               if ( StringUtil.StrCmp(Z121WWPNotificationLink, T000D2_A121WWPNotificationLink[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationLink");
                  GXUtil.WriteLogRaw("Old: ",Z121WWPNotificationLink);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A121WWPNotificationLink[0]);
               }
               if ( Z124WWPNotificationIsRead != T000D2_A124WWPNotificationIsRead[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationIsRead");
                  GXUtil.WriteLogRaw("Old: ",Z124WWPNotificationIsRead);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A124WWPNotificationIsRead[0]);
               }
               if ( Z65WWPNotificationDefinitionId != T000D2_A65WWPNotificationDefinitionId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPNotificationDefinitionId");
                  GXUtil.WriteLogRaw("Old: ",Z65WWPNotificationDefinitionId);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A65WWPNotificationDefinitionId[0]);
               }
               if ( StringUtil.StrCmp(Z49WWPUserExtendedId, T000D2_A49WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.notifications.common.wwp_notification:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000D2_A49WWPUserExtendedId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Notification"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0D13( )
      {
         if ( ! IsAuthorized("wwp_notification_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0D13( 0) ;
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D12 */
                     pr_default.execute(10, new Object[] {A66WWPNotificationCreated, A118WWPNotificationIcon, A119WWPNotificationTitle, A120WWPNotificationShortDescriptio, A121WWPNotificationLink, A124WWPNotificationIsRead, n102WWPNotificationMetadata, A102WWPNotificationMetadata, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000D13 */
                     pr_default.execute(11);
                     A64WWPNotificationId = T000D13_A64WWPNotificationId[0];
                     n64WWPNotificationId = T000D13_n64WWPNotificationId[0];
                     AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0D0( ) ;
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
               Load0D13( ) ;
            }
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void Update0D13( )
      {
         if ( ! IsAuthorized("wwp_notification_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0D13( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0D13( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000D14 */
                     pr_default.execute(12, new Object[] {A66WWPNotificationCreated, A118WWPNotificationIcon, A119WWPNotificationTitle, A120WWPNotificationShortDescriptio, A121WWPNotificationLink, A124WWPNotificationIsRead, n102WWPNotificationMetadata, A102WWPNotificationMetadata, A65WWPNotificationDefinitionId, n49WWPUserExtendedId, A49WWPUserExtendedId, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Notification"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0D13( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0D0( ) ;
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
            EndLevel0D13( ) ;
         }
         CloseExtendedTableCursors0D13( ) ;
      }

      protected void DeferredUpdate0D13( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwp_notification_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0D13( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0D13( ) ;
            AfterConfirm0D13( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0D13( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000D15 */
                  pr_default.execute(13, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
                  pr_default.close(13);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_Notification");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound13 == 0 )
                        {
                           InitAll0D13( ) ;
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
                        ResetCaption0D0( ) ;
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
         sMode13 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0D13( ) ;
         Gx_mode = sMode13;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0D13( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000D16 */
            pr_default.execute(14, new Object[] {A65WWPNotificationDefinitionId});
            A101WWPNotificationDefinitionName = T000D16_A101WWPNotificationDefinitionName[0];
            AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
            pr_default.close(14);
            /* Using cursor T000D17 */
            pr_default.execute(15, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            A50WWPUserExtendedFullName = T000D17_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            pr_default.close(15);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000D18 */
            pr_default.execute(16, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(16) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Mail"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(16);
            /* Using cursor T000D19 */
            pr_default.execute(17, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(17) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebNotification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(17);
            /* Using cursor T000D20 */
            pr_default.execute(18, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_SMS"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
         }
      }

      protected void EndLevel0D13( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0D13( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0D0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.notifications.common.wwp_notification",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0D13( )
      {
         /* Using cursor T000D21 */
         pr_default.execute(19);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound13 = 1;
            A64WWPNotificationId = T000D21_A64WWPNotificationId[0];
            n64WWPNotificationId = T000D21_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0D13( )
      {
         /* Scan next routine */
         pr_default.readNext(19);
         RcdFound13 = 0;
         if ( (pr_default.getStatus(19) != 101) )
         {
            RcdFound13 = 1;
            A64WWPNotificationId = T000D21_A64WWPNotificationId[0];
            n64WWPNotificationId = T000D21_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         }
      }

      protected void ScanEnd0D13( )
      {
         pr_default.close(19);
      }

      protected void AfterConfirm0D13( )
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

      protected void BeforeInsert0D13( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0D13( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0D13( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0D13( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0D13( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0D13( )
      {
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionId_Enabled), 5, 0), true);
         edtWWPNotificationDefinitionName_Enabled = 0;
         AssignProp("", false, edtWWPNotificationDefinitionName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationDefinitionName_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
         edtWWPNotificationIcon_Enabled = 0;
         AssignProp("", false, edtWWPNotificationIcon_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationIcon_Enabled), 5, 0), true);
         edtWWPNotificationTitle_Enabled = 0;
         AssignProp("", false, edtWWPNotificationTitle_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationTitle_Enabled), 5, 0), true);
         edtWWPNotificationShortDescriptio_Enabled = 0;
         AssignProp("", false, edtWWPNotificationShortDescriptio_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationShortDescriptio_Enabled), 5, 0), true);
         edtWWPNotificationLink_Enabled = 0;
         AssignProp("", false, edtWWPNotificationLink_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationLink_Enabled), 5, 0), true);
         chkWWPNotificationIsRead.Enabled = 0;
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPNotificationIsRead.Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPNotificationMetadata_Enabled = 0;
         AssignProp("", false, edtWWPNotificationMetadata_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationMetadata_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0D13( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0D0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationCreated", context.localUtil.TToC( Z66WWPNotificationCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z118WWPNotificationIcon", Z118WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z119WWPNotificationTitle", Z119WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z120WWPNotificationShortDescriptio", Z120WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z121WWPNotificationLink", Z121WWPNotificationLink);
         GxWebStd.gx_boolean_hidden_field( context, "Z124WWPNotificationIsRead", Z124WWPNotificationIsRead);
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65WWPNotificationDefinitionId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
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
         return formatLink("wwpbaseobjects.notifications.common.wwp_notification.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Notifications.Common.WWP_Notification" ;
      }

      public override string GetPgmdesc( )
      {
         return "Notification" ;
      }

      protected void InitializeNonKey0D13( )
      {
         A65WWPNotificationDefinitionId = 0;
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrimStr( (decimal)(A65WWPNotificationDefinitionId), 10, 0));
         A101WWPNotificationDefinitionName = "";
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         A118WWPNotificationIcon = "";
         AssignAttri("", false, "A118WWPNotificationIcon", A118WWPNotificationIcon);
         A119WWPNotificationTitle = "";
         AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
         A120WWPNotificationShortDescriptio = "";
         AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
         A121WWPNotificationLink = "";
         AssignAttri("", false, "A121WWPNotificationLink", A121WWPNotificationLink);
         A124WWPNotificationIsRead = false;
         AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         n49WWPUserExtendedId = (String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ? true : false);
         A50WWPUserExtendedFullName = "";
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A102WWPNotificationMetadata = "";
         n102WWPNotificationMetadata = false;
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         n102WWPNotificationMetadata = (String.IsNullOrEmpty(StringUtil.RTrim( A102WWPNotificationMetadata)) ? true : false);
         A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z118WWPNotificationIcon = "";
         Z119WWPNotificationTitle = "";
         Z120WWPNotificationShortDescriptio = "";
         Z121WWPNotificationLink = "";
         Z124WWPNotificationIsRead = false;
         Z65WWPNotificationDefinitionId = 0;
         Z49WWPUserExtendedId = "";
      }

      protected void InitAll0D13( )
      {
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         InitializeNonKey0D13( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A66WWPNotificationCreated = i66WWPNotificationCreated;
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828123028", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/notifications/common/wwp_notification.js", "?2023828123028", false, true);
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
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationDefinitionId_Internalname = "WWPNOTIFICATIONDEFINITIONID";
         edtWWPNotificationDefinitionName_Internalname = "WWPNOTIFICATIONDEFINITIONNAME";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         edtWWPNotificationIcon_Internalname = "WWPNOTIFICATIONICON";
         edtWWPNotificationTitle_Internalname = "WWPNOTIFICATIONTITLE";
         edtWWPNotificationShortDescriptio_Internalname = "WWPNOTIFICATIONSHORTDESCRIPTIO";
         edtWWPNotificationLink_Internalname = "WWPNOTIFICATIONLINK";
         chkWWPNotificationIsRead_Internalname = "WWPNOTIFICATIONISREAD";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPNotificationMetadata_Internalname = "WWPNOTIFICATIONMETADATA";
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
         Form.Caption = "Notification";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationMetadata_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         chkWWPNotificationIsRead.Enabled = 1;
         edtWWPNotificationLink_Jsonclick = "";
         edtWWPNotificationLink_Enabled = 1;
         edtWWPNotificationShortDescriptio_Enabled = 1;
         edtWWPNotificationTitle_Enabled = 1;
         edtWWPNotificationIcon_Jsonclick = "";
         edtWWPNotificationIcon_Enabled = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 1;
         edtWWPNotificationDefinitionName_Jsonclick = "";
         edtWWPNotificationDefinitionName_Enabled = 0;
         edtWWPNotificationDefinitionId_Jsonclick = "";
         edtWWPNotificationDefinitionId_Enabled = 1;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
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
         chkWWPNotificationIsRead.Name = "WWPNOTIFICATIONISREAD";
         chkWWPNotificationIsRead.WebTags = "";
         chkWWPNotificationIsRead.Caption = "";
         AssignProp("", false, chkWWPNotificationIsRead_Internalname, "TitleCaption", chkWWPNotificationIsRead.Caption, true);
         chkWWPNotificationIsRead.CheckedValue = "false";
         A124WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A124WWPNotificationIsRead));
         AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
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

      public void Valid_Wwpnotificationid( )
      {
         n64WWPNotificationId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A124WWPNotificationIsRead = StringUtil.StrToBool( StringUtil.BoolToStr( A124WWPNotificationIsRead));
         /*  Sending validation outputs */
         AssignAttri("", false, "A65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A65WWPNotificationDefinitionId), 10, 0, ".", "")));
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A118WWPNotificationIcon", A118WWPNotificationIcon);
         AssignAttri("", false, "A119WWPNotificationTitle", A119WWPNotificationTitle);
         AssignAttri("", false, "A120WWPNotificationShortDescriptio", A120WWPNotificationShortDescriptio);
         AssignAttri("", false, "A121WWPNotificationLink", A121WWPNotificationLink);
         AssignAttri("", false, "A124WWPNotificationIsRead", A124WWPNotificationIsRead);
         AssignAttri("", false, "A49WWPUserExtendedId", StringUtil.RTrim( A49WWPUserExtendedId));
         AssignAttri("", false, "A102WWPNotificationMetadata", A102WWPNotificationMetadata);
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z65WWPNotificationDefinitionId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z65WWPNotificationDefinitionId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationCreated", context.localUtil.TToC( Z66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z118WWPNotificationIcon", Z118WWPNotificationIcon);
         GxWebStd.gx_hidden_field( context, "Z119WWPNotificationTitle", Z119WWPNotificationTitle);
         GxWebStd.gx_hidden_field( context, "Z120WWPNotificationShortDescriptio", Z120WWPNotificationShortDescriptio);
         GxWebStd.gx_hidden_field( context, "Z121WWPNotificationLink", Z121WWPNotificationLink);
         GxWebStd.gx_hidden_field( context, "Z124WWPNotificationIsRead", StringUtil.BoolToStr( Z124WWPNotificationIsRead));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z102WWPNotificationMetadata", Z102WWPNotificationMetadata);
         GxWebStd.gx_hidden_field( context, "Z101WWPNotificationDefinitionName", Z101WWPNotificationDefinitionName);
         GxWebStd.gx_hidden_field( context, "Z50WWPUserExtendedFullName", Z50WWPUserExtendedFullName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationdefinitionid( )
      {
         /* Using cursor T000D16 */
         pr_default.execute(14, new Object[] {A65WWPNotificationDefinitionId});
         if ( (pr_default.getStatus(14) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_NotificationDefinition'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONDEFINITIONID");
            AnyError = 1;
            GX_FocusControl = edtWWPNotificationDefinitionId_Internalname;
         }
         A101WWPNotificationDefinitionName = T000D16_A101WWPNotificationDefinitionName[0];
         pr_default.close(14);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A101WWPNotificationDefinitionName", A101WWPNotificationDefinitionName);
      }

      public void Valid_Wwpuserextendedid( )
      {
         n49WWPUserExtendedId = false;
         /* Using cursor T000D17 */
         pr_default.execute(15, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(15) == 101) )
         {
            if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( A49WWPUserExtendedId)) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedId_Internalname;
            }
         }
         A50WWPUserExtendedFullName = T000D17_A50WWPUserExtendedFullName[0];
         pr_default.close(15);
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A118WWPNotificationIcon',fld:'WWPNOTIFICATIONICON',pic:''},{av:'A119WWPNotificationTitle',fld:'WWPNOTIFICATIONTITLE',pic:''},{av:'A120WWPNotificationShortDescriptio',fld:'WWPNOTIFICATIONSHORTDESCRIPTIO',pic:''},{av:'A121WWPNotificationLink',fld:'WWPNOTIFICATIONLINK',pic:''},{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A102WWPNotificationMetadata',fld:'WWPNOTIFICATIONMETADATA',pic:''},{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z64WWPNotificationId'},{av:'Z65WWPNotificationDefinitionId'},{av:'Z66WWPNotificationCreated'},{av:'Z118WWPNotificationIcon'},{av:'Z119WWPNotificationTitle'},{av:'Z120WWPNotificationShortDescriptio'},{av:'Z121WWPNotificationLink'},{av:'Z124WWPNotificationIsRead'},{av:'Z49WWPUserExtendedId'},{av:'Z102WWPNotificationMetadata'},{av:'Z101WWPNotificationDefinitionName'},{av:'Z50WWPUserExtendedFullName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID","{handler:'Valid_Wwpnotificationdefinitionid',iparms:[{av:'A65WWPNotificationDefinitionId',fld:'WWPNOTIFICATIONDEFINITIONID',pic:'ZZZZZZZZZ9'},{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONDEFINITIONID",",oparms:[{av:'A101WWPNotificationDefinitionName',fld:'WWPNOTIFICATIONDEFINITIONNAME',pic:''},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK","{handler:'Valid_Wwpnotificationlink',iparms:[{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPNOTIFICATIONLINK",",oparms:[{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A124WWPNotificationIsRead',fld:'WWPNOTIFICATIONISREAD',pic:''}]}");
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
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         Z118WWPNotificationIcon = "";
         Z119WWPNotificationTitle = "";
         Z120WWPNotificationShortDescriptio = "";
         Z121WWPNotificationLink = "";
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
         A101WWPNotificationDefinitionName = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         A118WWPNotificationIcon = "";
         A119WWPNotificationTitle = "";
         A120WWPNotificationShortDescriptio = "";
         A121WWPNotificationLink = "";
         A50WWPUserExtendedFullName = "";
         A102WWPNotificationMetadata = "";
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
         Z102WWPNotificationMetadata = "";
         Z101WWPNotificationDefinitionName = "";
         Z50WWPUserExtendedFullName = "";
         T000D6_A64WWPNotificationId = new long[1] ;
         T000D6_n64WWPNotificationId = new bool[] {false} ;
         T000D6_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000D6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000D6_A118WWPNotificationIcon = new string[] {""} ;
         T000D6_A119WWPNotificationTitle = new string[] {""} ;
         T000D6_A120WWPNotificationShortDescriptio = new string[] {""} ;
         T000D6_A121WWPNotificationLink = new string[] {""} ;
         T000D6_A124WWPNotificationIsRead = new bool[] {false} ;
         T000D6_A50WWPUserExtendedFullName = new string[] {""} ;
         T000D6_A102WWPNotificationMetadata = new string[] {""} ;
         T000D6_n102WWPNotificationMetadata = new bool[] {false} ;
         T000D6_A65WWPNotificationDefinitionId = new long[1] ;
         T000D6_A49WWPUserExtendedId = new string[] {""} ;
         T000D6_n49WWPUserExtendedId = new bool[] {false} ;
         T000D4_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000D5_A50WWPUserExtendedFullName = new string[] {""} ;
         T000D7_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000D8_A50WWPUserExtendedFullName = new string[] {""} ;
         T000D9_A64WWPNotificationId = new long[1] ;
         T000D9_n64WWPNotificationId = new bool[] {false} ;
         T000D3_A64WWPNotificationId = new long[1] ;
         T000D3_n64WWPNotificationId = new bool[] {false} ;
         T000D3_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000D3_A118WWPNotificationIcon = new string[] {""} ;
         T000D3_A119WWPNotificationTitle = new string[] {""} ;
         T000D3_A120WWPNotificationShortDescriptio = new string[] {""} ;
         T000D3_A121WWPNotificationLink = new string[] {""} ;
         T000D3_A124WWPNotificationIsRead = new bool[] {false} ;
         T000D3_A102WWPNotificationMetadata = new string[] {""} ;
         T000D3_n102WWPNotificationMetadata = new bool[] {false} ;
         T000D3_A65WWPNotificationDefinitionId = new long[1] ;
         T000D3_A49WWPUserExtendedId = new string[] {""} ;
         T000D3_n49WWPUserExtendedId = new bool[] {false} ;
         sMode13 = "";
         T000D10_A64WWPNotificationId = new long[1] ;
         T000D10_n64WWPNotificationId = new bool[] {false} ;
         T000D11_A64WWPNotificationId = new long[1] ;
         T000D11_n64WWPNotificationId = new bool[] {false} ;
         T000D2_A64WWPNotificationId = new long[1] ;
         T000D2_n64WWPNotificationId = new bool[] {false} ;
         T000D2_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000D2_A118WWPNotificationIcon = new string[] {""} ;
         T000D2_A119WWPNotificationTitle = new string[] {""} ;
         T000D2_A120WWPNotificationShortDescriptio = new string[] {""} ;
         T000D2_A121WWPNotificationLink = new string[] {""} ;
         T000D2_A124WWPNotificationIsRead = new bool[] {false} ;
         T000D2_A102WWPNotificationMetadata = new string[] {""} ;
         T000D2_n102WWPNotificationMetadata = new bool[] {false} ;
         T000D2_A65WWPNotificationDefinitionId = new long[1] ;
         T000D2_A49WWPUserExtendedId = new string[] {""} ;
         T000D2_n49WWPUserExtendedId = new bool[] {false} ;
         T000D13_A64WWPNotificationId = new long[1] ;
         T000D13_n64WWPNotificationId = new bool[] {false} ;
         T000D16_A101WWPNotificationDefinitionName = new string[] {""} ;
         T000D17_A50WWPUserExtendedFullName = new string[] {""} ;
         T000D18_A122WWPMailId = new long[1] ;
         T000D19_A89WWPWebNotificationId = new long[1] ;
         T000D20_A75WWPSMSId = new long[1] ;
         T000D21_A64WWPNotificationId = new long[1] ;
         T000D21_n64WWPNotificationId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         ZZ118WWPNotificationIcon = "";
         ZZ119WWPNotificationTitle = "";
         ZZ120WWPNotificationShortDescriptio = "";
         ZZ121WWPNotificationLink = "";
         ZZ49WWPUserExtendedId = "";
         ZZ102WWPNotificationMetadata = "";
         ZZ101WWPNotificationDefinitionName = "";
         ZZ50WWPUserExtendedFullName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.notifications.common.wwp_notification__default(),
            new Object[][] {
                new Object[] {
               T000D2_A64WWPNotificationId, T000D2_A66WWPNotificationCreated, T000D2_A118WWPNotificationIcon, T000D2_A119WWPNotificationTitle, T000D2_A120WWPNotificationShortDescriptio, T000D2_A121WWPNotificationLink, T000D2_A124WWPNotificationIsRead, T000D2_A102WWPNotificationMetadata, T000D2_n102WWPNotificationMetadata, T000D2_A65WWPNotificationDefinitionId,
               T000D2_A49WWPUserExtendedId, T000D2_n49WWPUserExtendedId
               }
               , new Object[] {
               T000D3_A64WWPNotificationId, T000D3_A66WWPNotificationCreated, T000D3_A118WWPNotificationIcon, T000D3_A119WWPNotificationTitle, T000D3_A120WWPNotificationShortDescriptio, T000D3_A121WWPNotificationLink, T000D3_A124WWPNotificationIsRead, T000D3_A102WWPNotificationMetadata, T000D3_n102WWPNotificationMetadata, T000D3_A65WWPNotificationDefinitionId,
               T000D3_A49WWPUserExtendedId, T000D3_n49WWPUserExtendedId
               }
               , new Object[] {
               T000D4_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000D5_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T000D6_A64WWPNotificationId, T000D6_A101WWPNotificationDefinitionName, T000D6_A66WWPNotificationCreated, T000D6_A118WWPNotificationIcon, T000D6_A119WWPNotificationTitle, T000D6_A120WWPNotificationShortDescriptio, T000D6_A121WWPNotificationLink, T000D6_A124WWPNotificationIsRead, T000D6_A50WWPUserExtendedFullName, T000D6_A102WWPNotificationMetadata,
               T000D6_n102WWPNotificationMetadata, T000D6_A65WWPNotificationDefinitionId, T000D6_A49WWPUserExtendedId, T000D6_n49WWPUserExtendedId
               }
               , new Object[] {
               T000D7_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000D8_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T000D9_A64WWPNotificationId
               }
               , new Object[] {
               T000D10_A64WWPNotificationId
               }
               , new Object[] {
               T000D11_A64WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               T000D13_A64WWPNotificationId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000D16_A101WWPNotificationDefinitionName
               }
               , new Object[] {
               T000D17_A50WWPUserExtendedFullName
               }
               , new Object[] {
               T000D18_A122WWPMailId
               }
               , new Object[] {
               T000D19_A89WWPWebNotificationId
               }
               , new Object[] {
               T000D20_A75WWPSMSId
               }
               , new Object[] {
               T000D21_A64WWPNotificationId
               }
            }
         );
         Z66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i66WWPNotificationCreated = DateTimeUtil.ServerNowMs( context, pr_default);
      }

      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound13 ;
      private short nIsDirty_13 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationDefinitionId_Enabled ;
      private int edtWWPNotificationDefinitionName_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int edtWWPNotificationIcon_Enabled ;
      private int edtWWPNotificationTitle_Enabled ;
      private int edtWWPNotificationShortDescriptio_Enabled ;
      private int edtWWPNotificationLink_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPNotificationMetadata_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z64WWPNotificationId ;
      private long Z65WWPNotificationDefinitionId ;
      private long A65WWPNotificationDefinitionId ;
      private long A64WWPNotificationId ;
      private long ZZ64WWPNotificationId ;
      private long ZZ65WWPNotificationDefinitionId ;
      private string sPrefix ;
      private string Z49WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string A49WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPNotificationId_Internalname ;
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
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationDefinitionId_Internalname ;
      private string edtWWPNotificationDefinitionId_Jsonclick ;
      private string edtWWPNotificationDefinitionName_Internalname ;
      private string edtWWPNotificationDefinitionName_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string edtWWPNotificationIcon_Internalname ;
      private string edtWWPNotificationIcon_Jsonclick ;
      private string edtWWPNotificationTitle_Internalname ;
      private string edtWWPNotificationShortDescriptio_Internalname ;
      private string edtWWPNotificationLink_Internalname ;
      private string edtWWPNotificationLink_Jsonclick ;
      private string chkWWPNotificationIsRead_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPNotificationMetadata_Internalname ;
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
      private string sMode13 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string ZZ49WWPUserExtendedId ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime i66WWPNotificationCreated ;
      private DateTime ZZ66WWPNotificationCreated ;
      private bool Z124WWPNotificationIsRead ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n49WWPUserExtendedId ;
      private bool wbErr ;
      private bool A124WWPNotificationIsRead ;
      private bool n64WWPNotificationId ;
      private bool n102WWPNotificationMetadata ;
      private bool Gx_longc ;
      private bool ZZ124WWPNotificationIsRead ;
      private string A102WWPNotificationMetadata ;
      private string Z102WWPNotificationMetadata ;
      private string ZZ102WWPNotificationMetadata ;
      private string Z118WWPNotificationIcon ;
      private string Z119WWPNotificationTitle ;
      private string Z120WWPNotificationShortDescriptio ;
      private string Z121WWPNotificationLink ;
      private string A101WWPNotificationDefinitionName ;
      private string A118WWPNotificationIcon ;
      private string A119WWPNotificationTitle ;
      private string A120WWPNotificationShortDescriptio ;
      private string A121WWPNotificationLink ;
      private string A50WWPUserExtendedFullName ;
      private string Z101WWPNotificationDefinitionName ;
      private string Z50WWPUserExtendedFullName ;
      private string ZZ118WWPNotificationIcon ;
      private string ZZ119WWPNotificationTitle ;
      private string ZZ120WWPNotificationShortDescriptio ;
      private string ZZ121WWPNotificationLink ;
      private string ZZ101WWPNotificationDefinitionName ;
      private string ZZ50WWPUserExtendedFullName ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPNotificationIsRead ;
      private IDataStoreProvider pr_default ;
      private long[] T000D6_A64WWPNotificationId ;
      private bool[] T000D6_n64WWPNotificationId ;
      private string[] T000D6_A101WWPNotificationDefinitionName ;
      private DateTime[] T000D6_A66WWPNotificationCreated ;
      private string[] T000D6_A118WWPNotificationIcon ;
      private string[] T000D6_A119WWPNotificationTitle ;
      private string[] T000D6_A120WWPNotificationShortDescriptio ;
      private string[] T000D6_A121WWPNotificationLink ;
      private bool[] T000D6_A124WWPNotificationIsRead ;
      private string[] T000D6_A50WWPUserExtendedFullName ;
      private string[] T000D6_A102WWPNotificationMetadata ;
      private bool[] T000D6_n102WWPNotificationMetadata ;
      private long[] T000D6_A65WWPNotificationDefinitionId ;
      private string[] T000D6_A49WWPUserExtendedId ;
      private bool[] T000D6_n49WWPUserExtendedId ;
      private string[] T000D4_A101WWPNotificationDefinitionName ;
      private string[] T000D5_A50WWPUserExtendedFullName ;
      private string[] T000D7_A101WWPNotificationDefinitionName ;
      private string[] T000D8_A50WWPUserExtendedFullName ;
      private long[] T000D9_A64WWPNotificationId ;
      private bool[] T000D9_n64WWPNotificationId ;
      private long[] T000D3_A64WWPNotificationId ;
      private bool[] T000D3_n64WWPNotificationId ;
      private DateTime[] T000D3_A66WWPNotificationCreated ;
      private string[] T000D3_A118WWPNotificationIcon ;
      private string[] T000D3_A119WWPNotificationTitle ;
      private string[] T000D3_A120WWPNotificationShortDescriptio ;
      private string[] T000D3_A121WWPNotificationLink ;
      private bool[] T000D3_A124WWPNotificationIsRead ;
      private string[] T000D3_A102WWPNotificationMetadata ;
      private bool[] T000D3_n102WWPNotificationMetadata ;
      private long[] T000D3_A65WWPNotificationDefinitionId ;
      private string[] T000D3_A49WWPUserExtendedId ;
      private bool[] T000D3_n49WWPUserExtendedId ;
      private long[] T000D10_A64WWPNotificationId ;
      private bool[] T000D10_n64WWPNotificationId ;
      private long[] T000D11_A64WWPNotificationId ;
      private bool[] T000D11_n64WWPNotificationId ;
      private long[] T000D2_A64WWPNotificationId ;
      private bool[] T000D2_n64WWPNotificationId ;
      private DateTime[] T000D2_A66WWPNotificationCreated ;
      private string[] T000D2_A118WWPNotificationIcon ;
      private string[] T000D2_A119WWPNotificationTitle ;
      private string[] T000D2_A120WWPNotificationShortDescriptio ;
      private string[] T000D2_A121WWPNotificationLink ;
      private bool[] T000D2_A124WWPNotificationIsRead ;
      private string[] T000D2_A102WWPNotificationMetadata ;
      private bool[] T000D2_n102WWPNotificationMetadata ;
      private long[] T000D2_A65WWPNotificationDefinitionId ;
      private string[] T000D2_A49WWPUserExtendedId ;
      private bool[] T000D2_n49WWPUserExtendedId ;
      private long[] T000D13_A64WWPNotificationId ;
      private bool[] T000D13_n64WWPNotificationId ;
      private string[] T000D16_A101WWPNotificationDefinitionName ;
      private string[] T000D17_A50WWPUserExtendedFullName ;
      private long[] T000D18_A122WWPMailId ;
      private long[] T000D19_A89WWPWebNotificationId ;
      private long[] T000D20_A75WWPSMSId ;
      private long[] T000D21_A64WWPNotificationId ;
      private bool[] T000D21_n64WWPNotificationId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_notification__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_notification__default : DataStoreHelperBase, IDataStoreHelper
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
        Object[] prmT000D6;
        prmT000D6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D4;
        prmT000D4 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000D5;
        prmT000D5 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000D7;
        prmT000D7 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000D8;
        prmT000D8 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000D9;
        prmT000D9 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D3;
        prmT000D3 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D10;
        prmT000D10 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D11;
        prmT000D11 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D2;
        prmT000D2 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D12;
        prmT000D12 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000D13;
        prmT000D13 = new Object[] {
        };
        Object[] prmT000D14;
        prmT000D14 = new Object[] {
        new ParDef("WWPNotificationCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPNotificationIcon",GXType.VarChar,100,0) ,
        new ParDef("WWPNotificationTitle",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationShortDescriptio",GXType.VarChar,200,0) ,
        new ParDef("WWPNotificationLink",GXType.VarChar,1000,0) ,
        new ParDef("WWPNotificationIsRead",GXType.Boolean,4,0) ,
        new ParDef("WWPNotificationMetadata",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D15;
        prmT000D15 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D18;
        prmT000D18 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D19;
        prmT000D19 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D20;
        prmT000D20 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000D21;
        prmT000D21 = new Object[] {
        };
        Object[] prmT000D16;
        prmT000D16 = new Object[] {
        new ParDef("WWPNotificationDefinitionId",GXType.Int64,10,0)
        };
        Object[] prmT000D17;
        prmT000D17 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000D2", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId  FOR UPDATE OF WWP_Notification NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000D2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D3", "SELECT WWPNotificationId, WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D4", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D5", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D6", "SELECT TM1.WWPNotificationId, T2.WWPNotificationDefinitionName, TM1.WWPNotificationCreated, TM1.WWPNotificationIcon, TM1.WWPNotificationTitle, TM1.WWPNotificationShortDescriptio, TM1.WWPNotificationLink, TM1.WWPNotificationIsRead, T3.WWPUserExtendedFullName, TM1.WWPNotificationMetadata, TM1.WWPNotificationDefinitionId, TM1.WWPUserExtendedId FROM ((WWP_Notification TM1 INNER JOIN WWP_NotificationDefinition T2 ON T2.WWPNotificationDefinitionId = TM1.WWPNotificationDefinitionId) LEFT JOIN WWP_UserExtended T3 ON T3.WWPUserExtendedId = TM1.WWPUserExtendedId) WHERE TM1.WWPNotificationId = :WWPNotificationId ORDER BY TM1.WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D6,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D7", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D7,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D8", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D9", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D10", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId > :WWPNotificationId) ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D11", "SELECT WWPNotificationId FROM WWP_Notification WHERE ( WWPNotificationId < :WWPNotificationId) ORDER BY WWPNotificationId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D12", "SAVEPOINT gxupdate;INSERT INTO WWP_Notification(WWPNotificationCreated, WWPNotificationIcon, WWPNotificationTitle, WWPNotificationShortDescriptio, WWPNotificationLink, WWPNotificationIsRead, WWPNotificationMetadata, WWPNotificationDefinitionId, WWPUserExtendedId) VALUES(:WWPNotificationCreated, :WWPNotificationIcon, :WWPNotificationTitle, :WWPNotificationShortDescriptio, :WWPNotificationLink, :WWPNotificationIsRead, :WWPNotificationMetadata, :WWPNotificationDefinitionId, :WWPUserExtendedId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000D12)
           ,new CursorDef("T000D13", "SELECT currval('WWPNotificationId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D14", "SAVEPOINT gxupdate;UPDATE WWP_Notification SET WWPNotificationCreated=:WWPNotificationCreated, WWPNotificationIcon=:WWPNotificationIcon, WWPNotificationTitle=:WWPNotificationTitle, WWPNotificationShortDescriptio=:WWPNotificationShortDescriptio, WWPNotificationLink=:WWPNotificationLink, WWPNotificationIsRead=:WWPNotificationIsRead, WWPNotificationMetadata=:WWPNotificationMetadata, WWPNotificationDefinitionId=:WWPNotificationDefinitionId, WWPUserExtendedId=:WWPUserExtendedId  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D14)
           ,new CursorDef("T000D15", "SAVEPOINT gxupdate;DELETE FROM WWP_Notification  WHERE WWPNotificationId = :WWPNotificationId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000D15)
           ,new CursorDef("T000D16", "SELECT WWPNotificationDefinitionName FROM WWP_NotificationDefinition WHERE WWPNotificationDefinitionId = :WWPNotificationDefinitionId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D17", "SELECT WWPUserExtendedFullName FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D17,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000D18", "SELECT WWPMailId FROM WWP_Mail WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D18,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D19", "SELECT WWPWebNotificationId FROM WWP_WebNotification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D19,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D20", "SELECT WWPSMSId FROM WWP_SMS WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000D21", "SELECT WWPNotificationId FROM WWP_Notification ORDER BY WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000D21,100, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2, true);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(8);
              ((bool[]) buf[8])[0] = rslt.wasNull(8);
              ((long[]) buf[9])[0] = rslt.getLong(9);
              ((string[]) buf[10])[0] = rslt.getString(10, 40);
              ((bool[]) buf[11])[0] = rslt.wasNull(10);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((DateTime[]) buf[2])[0] = rslt.getGXDateTime(3, true);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((string[]) buf[8])[0] = rslt.getVarchar(9);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((long[]) buf[11])[0] = rslt.getLong(11);
              ((string[]) buf[12])[0] = rslt.getString(12, 40);
              ((bool[]) buf[13])[0] = rslt.wasNull(12);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
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
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
