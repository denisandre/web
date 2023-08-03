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
namespace GeneXus.Programs.wwpbaseobjects.mail {
   public class wwp_mail : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxNewRow_"+"Gridwwp_mail_attachments") == 0 )
         {
            gxnrGridwwp_mail_attachments_newrow_invoke( ) ;
            return  ;
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
            Form.Meta.addItem("description", "Mail", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      protected void gxnrGridwwp_mail_attachments_newrow_invoke( )
      {
         nRC_GXsfl_113 = (int)(Math.Round(NumberUtil.Val( GetPar( "nRC_GXsfl_113"), "."), 18, MidpointRounding.ToEven));
         nGXsfl_113_idx = (int)(Math.Round(NumberUtil.Val( GetPar( "nGXsfl_113_idx"), "."), 18, MidpointRounding.ToEven));
         sGXsfl_113_idx = GetPar( "sGXsfl_113_idx");
         Gx_mode = GetPar( "Mode");
         setAjaxCallMode();
         if ( ! IsValidAjaxCall( true) )
         {
            GxWebError = 1;
            return  ;
         }
         gxnrGridwwp_mail_attachments_newrow( ) ;
         /* End function gxnrGridwwp_mail_attachments_newrow_invoke */
      }

      public wwp_mail( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mail( IGxContext context )
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
         cmbWWPMailStatus = new GXCombobox();
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
            return "wwpmail_Execute" ;
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
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A123WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0));
            AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Mail", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A122WWPMailId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPMailId_Enabled!=0) ? context.localUtil.Format( (decimal)(A122WWPMailId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A122WWPMailId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSubject_Internalname, "Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailSubject_Internalname, A111WWPMailSubject, StringUtil.RTrim( context.localUtil.Format( A111WWPMailSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBody_Internalname, "Body", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBody_Internalname, A103WWPMailBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", 1, 1, edtWWPMailBody_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTo_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTo_Internalname, "To", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTo_Internalname, A112WWPMailTo, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPMailTo_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCC_Internalname, "CC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailCC_Internalname, A125WWPMailCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPMailCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailBCC_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailBCC_Internalname, "BCC", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailBCC_Internalname, A126WWPMailBCC, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPMailBCC_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderAddress_Internalname, "Sender Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderAddress_Internalname, A113WWPMailSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", 0, 1, edtWWPMailSenderAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailSenderName_Internalname, "Sender Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailSenderName_Internalname, A114WWPMailSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,69);\"", 0, 1, edtWWPMailSenderName_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbWWPMailStatus_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, cmbWWPMailStatus_Internalname, "Status", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         /* ComboBox */
         GxWebStd.gx_combobox_ctrl1( context, cmbWWPMailStatus, cmbWWPMailStatus_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0)), 1, cmbWWPMailStatus_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbWWPMailStatus.Enabled, 1, 0, 0, "em", 0, "", "", "Attribute", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,74);\"", "", true, 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", (string)(cmbWWPMailStatus.ToJavascriptSource()), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailCreated_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailCreated_Internalname, "Created", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailCreated_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailCreated_Internalname, context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A133WWPMailCreated, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailScheduled_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailScheduled_Internalname, "Scheduled", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailScheduled_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailScheduled_Internalname, context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A134WWPMailScheduled, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,84);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailScheduled_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailScheduled_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailScheduled_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailScheduled_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailProcessed_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailProcessed_Internalname, "Processed", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPMailProcessed_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPMailProcessed_Internalname, context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A128WWPMailProcessed, "99/99/9999 99:99:99.999"), TempTags+" onchange=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 10,'DMY',12,24,'por',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailProcessed_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailProcessed_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPMailProcessed_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPMailProcessed_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailDetail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailDetail_Internalname, "Detail", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailDetail_Internalname, A129WWPMailDetail, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,94);\"", 0, 1, edtWWPMailDetail_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 99,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPNotificationId_Enabled!=0) ? context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A64WWPNotificationId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,99);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPNotificationCreated_Internalname, context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "), context.localUtil.Format( A66WWPNotificationCreated, "99/99/9999 99:99:99.999"), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPNotificationCreated_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPNotificationCreated_Enabled, 0, "text", "", 24, "chr", 1, "row", 24, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_DateTimeMillis", "end", false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_bitmap( context, edtWWPNotificationCreated_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPNotificationCreated_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         context.WriteHtmlTextNl( "</div>") ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, divAttachmentstable_Internalname, 1, 0, "px", 0, "px", "form__table-level", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Text block */
         GxWebStd.gx_label_ctrl( context, lblTitleattachments_Internalname, "Attachments", "", "", lblTitleattachments_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-04", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
         gxdraw_Gridwwp_mail_attachments( ) ;
         GxWebStd.gx_div_end( context, "start", "top", "div");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 120,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 122,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 124,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_Mail.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "end", "Middle", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
      }

      protected void gxdraw_Gridwwp_mail_attachments( )
      {
         /*  Grid Control  */
         StartGridControl113( ) ;
         nGXsfl_113_idx = 0;
         if ( ( nKeyPressed == 1 ) && ( AnyError == 0 ) )
         {
            /* Enter key processing. */
            nBlankRcdCount16 = 5;
            if ( ! IsIns( ) )
            {
               /* Display confirmed (stored) records */
               nRcdExists_16 = 1;
               ScanStart0F16( ) ;
               while ( RcdFound16 != 0 )
               {
                  init_level_properties16( ) ;
                  getByPrimaryKey0F16( ) ;
                  AddRow0F16( ) ;
                  ScanNext0F16( ) ;
               }
               ScanEnd0F16( ) ;
               nBlankRcdCount16 = 5;
            }
         }
         else if ( ( nKeyPressed == 3 ) || ( nKeyPressed == 4 ) || ( ( nKeyPressed == 1 ) && ( AnyError != 0 ) ) )
         {
            /* Button check  or addlines. */
            standaloneNotModal0F16( ) ;
            standaloneModal0F16( ) ;
            sMode16 = Gx_mode;
            while ( nGXsfl_113_idx < nRC_GXsfl_113 )
            {
               bGXsfl_113_Refreshing = true;
               ReadRow0F16( ) ;
               edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
               AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
               if ( ( nRcdExists_16 == 0 ) && ! IsIns( ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  standaloneModal0F16( ) ;
               }
               SendRow0F16( ) ;
               bGXsfl_113_Refreshing = false;
            }
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            /* Get or get-alike key processing. */
            nBlankRcdCount16 = 5;
            nRcdExists_16 = 1;
            if ( ! IsIns( ) )
            {
               ScanStart0F16( ) ;
               while ( RcdFound16 != 0 )
               {
                  sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
                  SubsflControlProps_11316( ) ;
                  init_level_properties16( ) ;
                  standaloneNotModal0F16( ) ;
                  getByPrimaryKey0F16( ) ;
                  standaloneModal0F16( ) ;
                  AddRow0F16( ) ;
                  ScanNext0F16( ) ;
               }
               ScanEnd0F16( ) ;
            }
         }
         /* Initialize fields for 'new' records and send them. */
         sMode16 = Gx_mode;
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx+1), 4, 0), 4, "0");
         SubsflControlProps_11316( ) ;
         InitAll0F16( ) ;
         init_level_properties16( ) ;
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         nRcdDeleted_16 = 0;
         nBlankRcdCount16 = (short)(nBlankRcdUsr16+nBlankRcdCount16);
         fRowAdded = 0;
         while ( nBlankRcdCount16 > 0 )
         {
            standaloneNotModal0F16( ) ;
            standaloneModal0F16( ) ;
            AddRow0F16( ) ;
            if ( ( nKeyPressed == 4 ) && ( fRowAdded == 0 ) )
            {
               fRowAdded = 1;
               GX_FocusControl = edtWWPMailAttachmentName_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nBlankRcdCount16 = (short)(nBlankRcdCount16-1);
         }
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         sStyleString = "";
         context.WriteHtmlText( "<div id=\""+"Gridwwp_mail_attachmentsContainer"+"Div\" "+sStyleString+">"+"</div>") ;
         context.httpAjaxContext.ajax_rsp_assign_grid("_"+"Gridwwp_mail_attachments", Gridwwp_mail_attachmentsContainer, subGridwwp_mail_attachments_Internalname);
         if ( ! context.isAjaxRequest( ) && ! context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData", Gridwwp_mail_attachmentsContainer.ToJavascriptSource());
         }
         if ( context.isAjaxRequest( ) || context.isSpaRequest( ) )
         {
            GxWebStd.gx_hidden_field( context, "Gridwwp_mail_attachmentsContainerData"+"V", Gridwwp_mail_attachmentsContainer.GridValuesHidden());
         }
         else
         {
            context.WriteHtmlText( "<input type=\"hidden\" "+"name=\""+"Gridwwp_mail_attachmentsContainerData"+"V"+"\" value='"+Gridwwp_mail_attachmentsContainer.GridValuesHidden()+"'/>") ;
         }
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
            Z122WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z122WWPMailId"), ",", "."), 18, MidpointRounding.ToEven));
            Z111WWPMailSubject = cgiGet( "Z111WWPMailSubject");
            Z123WWPMailStatus = (short)(Math.Round(context.localUtil.CToN( cgiGet( "Z123WWPMailStatus"), ",", "."), 18, MidpointRounding.ToEven));
            Z133WWPMailCreated = context.localUtil.CToT( cgiGet( "Z133WWPMailCreated"), 0);
            Z134WWPMailScheduled = context.localUtil.CToT( cgiGet( "Z134WWPMailScheduled"), 0);
            Z128WWPMailProcessed = context.localUtil.CToT( cgiGet( "Z128WWPMailProcessed"), 0);
            n128WWPMailProcessed = ((DateTime.MinValue==A128WWPMailProcessed) ? true : false);
            Z64WWPNotificationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z64WWPNotificationId"), ",", "."), 18, MidpointRounding.ToEven));
            n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            nRC_GXsfl_113 = (int)(Math.Round(context.localUtil.CToN( cgiGet( "nRC_GXsfl_113"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_BScreen = (short)(Math.Round(context.localUtil.CToN( cgiGet( "vGXBSCREEN"), ",", "."), 18, MidpointRounding.ToEven));
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPMAILID");
               AnyError = 1;
               GX_FocusControl = edtWWPMailId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A122WWPMailId = 0;
               AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
            }
            else
            {
               A122WWPMailId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPMailId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
            }
            A111WWPMailSubject = cgiGet( edtWWPMailSubject_Internalname);
            AssignAttri("", false, "A111WWPMailSubject", A111WWPMailSubject);
            A103WWPMailBody = cgiGet( edtWWPMailBody_Internalname);
            AssignAttri("", false, "A103WWPMailBody", A103WWPMailBody);
            A112WWPMailTo = cgiGet( edtWWPMailTo_Internalname);
            n112WWPMailTo = false;
            AssignAttri("", false, "A112WWPMailTo", A112WWPMailTo);
            n112WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPMailTo)) ? true : false);
            A125WWPMailCC = cgiGet( edtWWPMailCC_Internalname);
            n125WWPMailCC = false;
            AssignAttri("", false, "A125WWPMailCC", A125WWPMailCC);
            n125WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A125WWPMailCC)) ? true : false);
            A126WWPMailBCC = cgiGet( edtWWPMailBCC_Internalname);
            n126WWPMailBCC = false;
            AssignAttri("", false, "A126WWPMailBCC", A126WWPMailBCC);
            n126WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A126WWPMailBCC)) ? true : false);
            A113WWPMailSenderAddress = cgiGet( edtWWPMailSenderAddress_Internalname);
            AssignAttri("", false, "A113WWPMailSenderAddress", A113WWPMailSenderAddress);
            A114WWPMailSenderName = cgiGet( edtWWPMailSenderName_Internalname);
            AssignAttri("", false, "A114WWPMailSenderName", A114WWPMailSenderName);
            cmbWWPMailStatus.Name = cmbWWPMailStatus_Internalname;
            cmbWWPMailStatus.CurrentValue = cgiGet( cmbWWPMailStatus_Internalname);
            A123WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cgiGet( cmbWWPMailStatus_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailCreated_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Created"}), 1, "WWPMAILCREATED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailCreated_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A133WWPMailCreated = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A133WWPMailCreated = context.localUtil.CToT( cgiGet( edtWWPMailCreated_Internalname));
               AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailScheduled_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Scheduled"}), 1, "WWPMAILSCHEDULED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailScheduled_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A134WWPMailScheduled = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A134WWPMailScheduled = context.localUtil.CToT( cgiGet( edtWWPMailScheduled_Internalname));
               AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPMailProcessed_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Mail Processed"}), 1, "WWPMAILPROCESSED");
               AnyError = 1;
               GX_FocusControl = edtWWPMailProcessed_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A128WWPMailProcessed = (DateTime)(DateTime.MinValue);
               n128WWPMailProcessed = false;
               AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            else
            {
               A128WWPMailProcessed = context.localUtil.CToT( cgiGet( edtWWPMailProcessed_Internalname));
               n128WWPMailProcessed = false;
               AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            }
            n128WWPMailProcessed = ((DateTime.MinValue==A128WWPMailProcessed) ? true : false);
            A129WWPMailDetail = cgiGet( edtWWPMailDetail_Internalname);
            n129WWPMailDetail = false;
            AssignAttri("", false, "A129WWPMailDetail", A129WWPMailDetail);
            n129WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A129WWPMailDetail)) ? true : false);
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
            /* Check if conditions changed and reset current page numbers */
            standaloneNotModal( ) ;
         }
         else
         {
            standaloneNotModal( ) ;
            if ( StringUtil.StrCmp(gxfirstwebparm, "viewer") == 0 )
            {
               Gx_mode = "DSP";
               AssignAttri("", false, "Gx_mode", Gx_mode);
               A122WWPMailId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPMailId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
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
                        sEvtType = StringUtil.Right( sEvt, 4);
                        sEvt = StringUtil.Left( sEvt, (short)(StringUtil.Len( sEvt)-4));
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
               InitAll0F15( ) ;
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
         DisableAttributes0F15( ) ;
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

      protected void CONFIRM_0F16( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0F16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               GetKey0F16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  if ( RcdFound16 == 0 )
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     BeforeValidate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        CheckExtendedTable0F16( ) ;
                        CloseExtendedTableCursors0F16( ) ;
                        if ( AnyError == 0 )
                        {
                           IsConfirmed = 1;
                           AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                        }
                     }
                  }
                  else
                  {
                     GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                     GX_msglist.addItem(context.GetMessage( "GXM_noupdate", ""), "DuplicatePrimaryKey", 1, GXCCtl);
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( nRcdDeleted_16 != 0 )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        getByPrimaryKey0F16( ) ;
                        Load0F16( ) ;
                        BeforeValidate0F16( ) ;
                        if ( AnyError == 0 )
                        {
                           OnDeleteControls0F16( ) ;
                        }
                     }
                     else
                     {
                        if ( nIsMod_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           BeforeValidate0F16( ) ;
                           if ( AnyError == 0 )
                           {
                              CheckExtendedTable0F16( ) ;
                              CloseExtendedTableCursors0F16( ) ;
                              if ( AnyError == 0 )
                              {
                                 IsConfirmed = 1;
                                 AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
                              }
                           }
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A135WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A127WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z135WWPMailAttachmentName_"+sGXsfl_113_idx, Z135WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
      }

      protected void ResetCaption0F0( )
      {
      }

      protected void ZM0F15( short GX_JID )
      {
         if ( ( GX_JID == 5 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z111WWPMailSubject = T000F5_A111WWPMailSubject[0];
               Z123WWPMailStatus = T000F5_A123WWPMailStatus[0];
               Z133WWPMailCreated = T000F5_A133WWPMailCreated[0];
               Z134WWPMailScheduled = T000F5_A134WWPMailScheduled[0];
               Z128WWPMailProcessed = T000F5_A128WWPMailProcessed[0];
               Z64WWPNotificationId = T000F5_A64WWPNotificationId[0];
            }
            else
            {
               Z111WWPMailSubject = A111WWPMailSubject;
               Z123WWPMailStatus = A123WWPMailStatus;
               Z133WWPMailCreated = A133WWPMailCreated;
               Z134WWPMailScheduled = A134WWPMailScheduled;
               Z128WWPMailProcessed = A128WWPMailProcessed;
               Z64WWPNotificationId = A64WWPNotificationId;
            }
         }
         if ( GX_JID == -5 )
         {
            Z122WWPMailId = A122WWPMailId;
            Z111WWPMailSubject = A111WWPMailSubject;
            Z103WWPMailBody = A103WWPMailBody;
            Z112WWPMailTo = A112WWPMailTo;
            Z125WWPMailCC = A125WWPMailCC;
            Z126WWPMailBCC = A126WWPMailBCC;
            Z113WWPMailSenderAddress = A113WWPMailSenderAddress;
            Z114WWPMailSenderName = A114WWPMailSenderName;
            Z123WWPMailStatus = A123WWPMailStatus;
            Z133WWPMailCreated = A133WWPMailCreated;
            Z134WWPMailScheduled = A134WWPMailScheduled;
            Z128WWPMailProcessed = A128WWPMailProcessed;
            Z129WWPMailDetail = A129WWPMailDetail;
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
         if ( IsIns( )  && (0==A123WWPMailStatus) && ( Gx_BScreen == 0 ) )
         {
            A123WWPMailStatus = 1;
            AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
         }
         if ( IsIns( )  && (DateTime.MinValue==A133WWPMailCreated) && ( Gx_BScreen == 0 ) )
         {
            A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         }
         if ( IsIns( )  && (DateTime.MinValue==A134WWPMailScheduled) && ( Gx_BScreen == 0 ) )
         {
            A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
            AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
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

      protected void Load0F15( )
      {
         /* Using cursor T000F7 */
         pr_default.execute(5, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound15 = 1;
            A111WWPMailSubject = T000F7_A111WWPMailSubject[0];
            AssignAttri("", false, "A111WWPMailSubject", A111WWPMailSubject);
            A103WWPMailBody = T000F7_A103WWPMailBody[0];
            AssignAttri("", false, "A103WWPMailBody", A103WWPMailBody);
            A112WWPMailTo = T000F7_A112WWPMailTo[0];
            n112WWPMailTo = T000F7_n112WWPMailTo[0];
            AssignAttri("", false, "A112WWPMailTo", A112WWPMailTo);
            A125WWPMailCC = T000F7_A125WWPMailCC[0];
            n125WWPMailCC = T000F7_n125WWPMailCC[0];
            AssignAttri("", false, "A125WWPMailCC", A125WWPMailCC);
            A126WWPMailBCC = T000F7_A126WWPMailBCC[0];
            n126WWPMailBCC = T000F7_n126WWPMailBCC[0];
            AssignAttri("", false, "A126WWPMailBCC", A126WWPMailBCC);
            A113WWPMailSenderAddress = T000F7_A113WWPMailSenderAddress[0];
            AssignAttri("", false, "A113WWPMailSenderAddress", A113WWPMailSenderAddress);
            A114WWPMailSenderName = T000F7_A114WWPMailSenderName[0];
            AssignAttri("", false, "A114WWPMailSenderName", A114WWPMailSenderName);
            A123WWPMailStatus = T000F7_A123WWPMailStatus[0];
            AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
            A133WWPMailCreated = T000F7_A133WWPMailCreated[0];
            AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            A134WWPMailScheduled = T000F7_A134WWPMailScheduled[0];
            AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            A128WWPMailProcessed = T000F7_A128WWPMailProcessed[0];
            n128WWPMailProcessed = T000F7_n128WWPMailProcessed[0];
            AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            A129WWPMailDetail = T000F7_A129WWPMailDetail[0];
            n129WWPMailDetail = T000F7_n129WWPMailDetail[0];
            AssignAttri("", false, "A129WWPMailDetail", A129WWPMailDetail);
            A66WWPNotificationCreated = T000F7_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            A64WWPNotificationId = T000F7_A64WWPNotificationId[0];
            n64WWPNotificationId = T000F7_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            ZM0F15( -5) ;
         }
         pr_default.close(5);
         OnLoadActions0F15( ) ;
      }

      protected void OnLoadActions0F15( )
      {
      }

      protected void CheckExtendedTable0F15( )
      {
         nIsDirty_15 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal( ) ;
         if ( ! ( ( A123WWPMailStatus == 1 ) || ( A123WWPMailStatus == 2 ) || ( A123WWPMailStatus == 3 ) ) )
         {
            GX_msglist.addItem("Campo Mail Status fora do intervalo", "OutOfRange", 1, "WWPMAILSTATUS");
            AnyError = 1;
            GX_FocusControl = cmbWWPMailStatus_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         /* Using cursor T000F6 */
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
         A66WWPNotificationCreated = T000F6_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         pr_default.close(4);
      }

      protected void CloseExtendedTableCursors0F15( )
      {
         pr_default.close(4);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_6( long A64WWPNotificationId )
      {
         /* Using cursor T000F8 */
         pr_default.execute(6, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A64WWPNotificationId) ) )
            {
               GX_msglist.addItem("Não existe 'WWP_Notification'.", "ForeignKeyNotFound", 1, "WWPNOTIFICATIONID");
               AnyError = 1;
               GX_FocusControl = edtWWPNotificationId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         A66WWPNotificationCreated = T000F8_A66WWPNotificationCreated[0];
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "))+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void GetKey0F15( )
      {
         /* Using cursor T000F9 */
         pr_default.execute(7, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(7) != 101) )
         {
            RcdFound15 = 1;
         }
         else
         {
            RcdFound15 = 0;
         }
         pr_default.close(7);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000F5 */
         pr_default.execute(3, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            ZM0F15( 5) ;
            RcdFound15 = 1;
            A122WWPMailId = T000F5_A122WWPMailId[0];
            AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
            A111WWPMailSubject = T000F5_A111WWPMailSubject[0];
            AssignAttri("", false, "A111WWPMailSubject", A111WWPMailSubject);
            A103WWPMailBody = T000F5_A103WWPMailBody[0];
            AssignAttri("", false, "A103WWPMailBody", A103WWPMailBody);
            A112WWPMailTo = T000F5_A112WWPMailTo[0];
            n112WWPMailTo = T000F5_n112WWPMailTo[0];
            AssignAttri("", false, "A112WWPMailTo", A112WWPMailTo);
            A125WWPMailCC = T000F5_A125WWPMailCC[0];
            n125WWPMailCC = T000F5_n125WWPMailCC[0];
            AssignAttri("", false, "A125WWPMailCC", A125WWPMailCC);
            A126WWPMailBCC = T000F5_A126WWPMailBCC[0];
            n126WWPMailBCC = T000F5_n126WWPMailBCC[0];
            AssignAttri("", false, "A126WWPMailBCC", A126WWPMailBCC);
            A113WWPMailSenderAddress = T000F5_A113WWPMailSenderAddress[0];
            AssignAttri("", false, "A113WWPMailSenderAddress", A113WWPMailSenderAddress);
            A114WWPMailSenderName = T000F5_A114WWPMailSenderName[0];
            AssignAttri("", false, "A114WWPMailSenderName", A114WWPMailSenderName);
            A123WWPMailStatus = T000F5_A123WWPMailStatus[0];
            AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
            A133WWPMailCreated = T000F5_A133WWPMailCreated[0];
            AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
            A134WWPMailScheduled = T000F5_A134WWPMailScheduled[0];
            AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
            A128WWPMailProcessed = T000F5_A128WWPMailProcessed[0];
            n128WWPMailProcessed = T000F5_n128WWPMailProcessed[0];
            AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
            A129WWPMailDetail = T000F5_A129WWPMailDetail[0];
            n129WWPMailDetail = T000F5_n129WWPMailDetail[0];
            AssignAttri("", false, "A129WWPMailDetail", A129WWPMailDetail);
            A64WWPNotificationId = T000F5_A64WWPNotificationId[0];
            n64WWPNotificationId = T000F5_n64WWPNotificationId[0];
            AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
            Z122WWPMailId = A122WWPMailId;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0F15( ) ;
            if ( AnyError == 1 )
            {
               RcdFound15 = 0;
               InitializeNonKey0F15( ) ;
            }
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound15 = 0;
            InitializeNonKey0F15( ) ;
            sMode15 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode15;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(3);
      }

      protected void getEqualNoModal( )
      {
         GetKey0F15( ) ;
         if ( RcdFound15 == 0 )
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
         RcdFound15 = 0;
         /* Using cursor T000F10 */
         pr_default.execute(8, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(8) != 101) )
         {
            while ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A122WWPMailId[0] < A122WWPMailId ) ) )
            {
               pr_default.readNext(8);
            }
            if ( (pr_default.getStatus(8) != 101) && ( ( T000F10_A122WWPMailId[0] > A122WWPMailId ) ) )
            {
               A122WWPMailId = T000F10_A122WWPMailId[0];
               AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(8);
      }

      protected void move_previous( )
      {
         RcdFound15 = 0;
         /* Using cursor T000F11 */
         pr_default.execute(9, new Object[] {A122WWPMailId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            while ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A122WWPMailId[0] > A122WWPMailId ) ) )
            {
               pr_default.readNext(9);
            }
            if ( (pr_default.getStatus(9) != 101) && ( ( T000F11_A122WWPMailId[0] < A122WWPMailId ) ) )
            {
               A122WWPMailId = T000F11_A122WWPMailId[0];
               AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
               RcdFound15 = 1;
            }
         }
         pr_default.close(9);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0F15( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0F15( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound15 == 1 )
            {
               if ( A122WWPMailId != Z122WWPMailId )
               {
                  A122WWPMailId = Z122WWPMailId;
                  AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0F15( ) ;
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A122WWPMailId != Z122WWPMailId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0F15( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0F15( ) ;
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
         if ( A122WWPMailId != Z122WWPMailId )
         {
            A122WWPMailId = Z122WWPMailId;
            AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailId_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILID");
            AnyError = 1;
            GX_FocusControl = edtWWPMailId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F15( ) ;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
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
         ScanStart0F15( ) ;
         if ( RcdFound15 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound15 != 0 )
            {
               ScanNext0F15( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailSubject_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0F15( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0F15( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F4 */
            pr_default.execute(2, new Object[] {A122WWPMailId});
            if ( (pr_default.getStatus(2) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(2) == 101) || ( StringUtil.StrCmp(Z111WWPMailSubject, T000F4_A111WWPMailSubject[0]) != 0 ) || ( Z123WWPMailStatus != T000F4_A123WWPMailStatus[0] ) || ( Z133WWPMailCreated != T000F4_A133WWPMailCreated[0] ) || ( Z134WWPMailScheduled != T000F4_A134WWPMailScheduled[0] ) || ( Z128WWPMailProcessed != T000F4_A128WWPMailProcessed[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z64WWPNotificationId != T000F4_A64WWPNotificationId[0] ) )
            {
               if ( StringUtil.StrCmp(Z111WWPMailSubject, T000F4_A111WWPMailSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailSubject");
                  GXUtil.WriteLogRaw("Old: ",Z111WWPMailSubject);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A111WWPMailSubject[0]);
               }
               if ( Z123WWPMailStatus != T000F4_A123WWPMailStatus[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailStatus");
                  GXUtil.WriteLogRaw("Old: ",Z123WWPMailStatus);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A123WWPMailStatus[0]);
               }
               if ( Z133WWPMailCreated != T000F4_A133WWPMailCreated[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailCreated");
                  GXUtil.WriteLogRaw("Old: ",Z133WWPMailCreated);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A133WWPMailCreated[0]);
               }
               if ( Z134WWPMailScheduled != T000F4_A134WWPMailScheduled[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailScheduled");
                  GXUtil.WriteLogRaw("Old: ",Z134WWPMailScheduled);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A134WWPMailScheduled[0]);
               }
               if ( Z128WWPMailProcessed != T000F4_A128WWPMailProcessed[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPMailProcessed");
                  GXUtil.WriteLogRaw("Old: ",Z128WWPMailProcessed);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A128WWPMailProcessed[0]);
               }
               if ( Z64WWPNotificationId != T000F4_A64WWPNotificationId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mail:[seudo value changed for attri]"+"WWPNotificationId");
                  GXUtil.WriteLogRaw("Old: ",Z64WWPNotificationId);
                  GXUtil.WriteLogRaw("Current: ",T000F4_A64WWPNotificationId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_Mail"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F15( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F15( 0) ;
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F12 */
                     pr_default.execute(10, new Object[] {A111WWPMailSubject, A103WWPMailBody, n112WWPMailTo, A112WWPMailTo, n125WWPMailCC, A125WWPMailCC, n126WWPMailBCC, A126WWPMailBCC, A113WWPMailSenderAddress, A114WWPMailSenderName, A123WWPMailStatus, A133WWPMailCreated, A134WWPMailScheduled, n128WWPMailProcessed, A128WWPMailProcessed, n129WWPMailDetail, A129WWPMailDetail, n64WWPNotificationId, A64WWPNotificationId});
                     pr_default.close(10);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000F13 */
                     pr_default.execute(11);
                     A122WWPMailId = T000F13_A122WWPMailId[0];
                     AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
                     pr_default.close(11);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F15( ) ;
                           if ( AnyError == 0 )
                           {
                              /* Save values for previous() function. */
                              endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                              endTrnMsgCod = "SuccessfullyAdded";
                              ResetCaption0F0( ) ;
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
               Load0F15( ) ;
            }
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void Update0F15( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F15( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0F15( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F14 */
                     pr_default.execute(12, new Object[] {A111WWPMailSubject, A103WWPMailBody, n112WWPMailTo, A112WWPMailTo, n125WWPMailCC, A125WWPMailCC, n126WWPMailBCC, A126WWPMailBCC, A113WWPMailSenderAddress, A114WWPMailSenderName, A123WWPMailStatus, A133WWPMailCreated, A134WWPMailScheduled, n128WWPMailProcessed, A128WWPMailProcessed, n129WWPMailDetail, A129WWPMailDetail, n64WWPNotificationId, A64WWPNotificationId, A122WWPMailId});
                     pr_default.close(12);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( (pr_default.getStatus(12) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_Mail"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0F15( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           ProcessLevel0F15( ) ;
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey( ) ;
                              endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                              endTrnMsgCod = "SuccessfullyUpdated";
                              ResetCaption0F0( ) ;
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
            EndLevel0F15( ) ;
         }
         CloseExtendedTableCursors0F15( ) ;
      }

      protected void DeferredUpdate0F15( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F15( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F15( ) ;
            AfterConfirm0F15( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F15( ) ;
               if ( AnyError == 0 )
               {
                  ScanStart0F16( ) ;
                  while ( RcdFound16 != 0 )
                  {
                     getByPrimaryKey0F16( ) ;
                     Delete0F16( ) ;
                     ScanNext0F16( ) ;
                  }
                  ScanEnd0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F15 */
                     pr_default.execute(13, new Object[] {A122WWPMailId});
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_Mail");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( delete) rules */
                        /* End of After( delete) rules */
                        if ( AnyError == 0 )
                        {
                           move_next( ) ;
                           if ( RcdFound15 == 0 )
                           {
                              InitAll0F15( ) ;
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
                           ResetCaption0F0( ) ;
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
         }
         sMode15 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F15( ) ;
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F15( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000F16 */
            pr_default.execute(14, new Object[] {n64WWPNotificationId, A64WWPNotificationId});
            A66WWPNotificationCreated = T000F16_A66WWPNotificationCreated[0];
            AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
            pr_default.close(14);
         }
      }

      protected void ProcessNestedLevel0F16( )
      {
         nGXsfl_113_idx = 0;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            ReadRow0F16( ) ;
            if ( ( nRcdExists_16 != 0 ) || ( nIsMod_16 != 0 ) )
            {
               standaloneNotModal0F16( ) ;
               GetKey0F16( ) ;
               if ( ( nRcdExists_16 == 0 ) && ( nRcdDeleted_16 == 0 ) )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  Insert0F16( ) ;
               }
               else
               {
                  if ( RcdFound16 != 0 )
                  {
                     if ( ( nRcdDeleted_16 != 0 ) && ( nRcdExists_16 != 0 ) )
                     {
                        Gx_mode = "DLT";
                        AssignAttri("", false, "Gx_mode", Gx_mode);
                        Delete0F16( ) ;
                     }
                     else
                     {
                        if ( nRcdExists_16 != 0 )
                        {
                           Gx_mode = "UPD";
                           AssignAttri("", false, "Gx_mode", Gx_mode);
                           Update0F16( ) ;
                        }
                     }
                  }
                  else
                  {
                     if ( nRcdDeleted_16 == 0 )
                     {
                        GXCCtl = "WWPMAILATTACHMENTNAME_" + sGXsfl_113_idx;
                        GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, GXCCtl);
                        AnyError = 1;
                        GX_FocusControl = edtWWPMailAttachmentName_Internalname;
                        AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     }
                  }
               }
            }
            ChangePostValue( edtWWPMailAttachmentName_Internalname, A135WWPMailAttachmentName) ;
            ChangePostValue( edtWWPMailAttachmentFile_Internalname, A127WWPMailAttachmentFile) ;
            ChangePostValue( "ZT_"+"Z135WWPMailAttachmentName_"+sGXsfl_113_idx, Z135WWPMailAttachmentName) ;
            ChangePostValue( "nRcdDeleted_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nRcdExists_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", ""))) ;
            ChangePostValue( "nIsMod_16_"+sGXsfl_113_idx, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", ""))) ;
            if ( nIsMod_16 != 0 )
            {
               ChangePostValue( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", ""))) ;
               ChangePostValue( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", ""))) ;
            }
         }
         /* Start of After( level) rules */
         /* End of After( level) rules */
         InitAll0F16( ) ;
         if ( AnyError != 0 )
         {
         }
         nRcdExists_16 = 0;
         nIsMod_16 = 0;
         nRcdDeleted_16 = 0;
      }

      protected void ProcessLevel0F15( )
      {
         /* Save parent mode. */
         sMode15 = Gx_mode;
         ProcessNestedLevel0F16( ) ;
         if ( AnyError != 0 )
         {
         }
         /* Restore parent mode. */
         Gx_mode = sMode15;
         AssignAttri("", false, "Gx_mode", Gx_mode);
         /* ' Update level parameters */
      }

      protected void EndLevel0F15( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(2);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0F15( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0F0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mail",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F15( )
      {
         /* Using cursor T000F17 */
         pr_default.execute(15);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound15 = 1;
            A122WWPMailId = T000F17_A122WWPMailId[0];
            AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F15( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound15 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound15 = 1;
            A122WWPMailId = T000F17_A122WWPMailId[0];
            AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
         }
      }

      protected void ScanEnd0F15( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm0F15( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F15( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F15( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F15( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F15( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F15( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F15( )
      {
         edtWWPMailId_Enabled = 0;
         AssignProp("", false, edtWWPMailId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailId_Enabled), 5, 0), true);
         edtWWPMailSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSubject_Enabled), 5, 0), true);
         edtWWPMailBody_Enabled = 0;
         AssignProp("", false, edtWWPMailBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBody_Enabled), 5, 0), true);
         edtWWPMailTo_Enabled = 0;
         AssignProp("", false, edtWWPMailTo_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTo_Enabled), 5, 0), true);
         edtWWPMailCC_Enabled = 0;
         AssignProp("", false, edtWWPMailCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCC_Enabled), 5, 0), true);
         edtWWPMailBCC_Enabled = 0;
         AssignProp("", false, edtWWPMailBCC_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailBCC_Enabled), 5, 0), true);
         edtWWPMailSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderAddress_Enabled), 5, 0), true);
         edtWWPMailSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailSenderName_Enabled), 5, 0), true);
         cmbWWPMailStatus.Enabled = 0;
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbWWPMailStatus.Enabled), 5, 0), true);
         edtWWPMailCreated_Enabled = 0;
         AssignProp("", false, edtWWPMailCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailCreated_Enabled), 5, 0), true);
         edtWWPMailScheduled_Enabled = 0;
         AssignProp("", false, edtWWPMailScheduled_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailScheduled_Enabled), 5, 0), true);
         edtWWPMailProcessed_Enabled = 0;
         AssignProp("", false, edtWWPMailProcessed_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailProcessed_Enabled), 5, 0), true);
         edtWWPMailDetail_Enabled = 0;
         AssignProp("", false, edtWWPMailDetail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailDetail_Enabled), 5, 0), true);
         edtWWPNotificationId_Enabled = 0;
         AssignProp("", false, edtWWPNotificationId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationId_Enabled), 5, 0), true);
         edtWWPNotificationCreated_Enabled = 0;
         AssignProp("", false, edtWWPNotificationCreated_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPNotificationCreated_Enabled), 5, 0), true);
      }

      protected void ZM0F16( short GX_JID )
      {
         if ( ( GX_JID == 7 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
            }
            else
            {
            }
         }
         if ( GX_JID == -7 )
         {
            Z122WWPMailId = A122WWPMailId;
            Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
            Z127WWPMailAttachmentFile = A127WWPMailAttachmentFile;
         }
      }

      protected void standaloneNotModal0F16( )
      {
      }

      protected void standaloneModal0F16( )
      {
         if ( StringUtil.StrCmp(Gx_mode, "INS") != 0 )
         {
            edtWWPMailAttachmentName_Enabled = 0;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
         else
         {
            edtWWPMailAttachmentName_Enabled = 1;
            AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         }
      }

      protected void Load0F16( )
      {
         /* Using cursor T000F18 */
         pr_default.execute(16, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(16) != 101) )
         {
            RcdFound16 = 1;
            A127WWPMailAttachmentFile = T000F18_A127WWPMailAttachmentFile[0];
            ZM0F16( -7) ;
         }
         pr_default.close(16);
         OnLoadActions0F16( ) ;
      }

      protected void OnLoadActions0F16( )
      {
      }

      protected void CheckExtendedTable0F16( )
      {
         nIsDirty_16 = 0;
         Gx_BScreen = 1;
         AssignAttri("", false, "Gx_BScreen", StringUtil.Str( (decimal)(Gx_BScreen), 1, 0));
         standaloneModal0F16( ) ;
      }

      protected void CloseExtendedTableCursors0F16( )
      {
      }

      protected void enableDisable0F16( )
      {
      }

      protected void GetKey0F16( )
      {
         /* Using cursor T000F19 */
         pr_default.execute(17, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(17) != 101) )
         {
            RcdFound16 = 1;
         }
         else
         {
            RcdFound16 = 0;
         }
         pr_default.close(17);
      }

      protected void getByPrimaryKey0F16( )
      {
         /* Using cursor T000F3 */
         pr_default.execute(1, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0F16( 7) ;
            RcdFound16 = 1;
            InitializeNonKey0F16( ) ;
            A135WWPMailAttachmentName = T000F3_A135WWPMailAttachmentName[0];
            A127WWPMailAttachmentFile = T000F3_A127WWPMailAttachmentFile[0];
            Z122WWPMailId = A122WWPMailId;
            Z135WWPMailAttachmentName = A135WWPMailAttachmentName;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0F16( ) ;
            Load0F16( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound16 = 0;
            InitializeNonKey0F16( ) ;
            sMode16 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal0F16( ) ;
            Gx_mode = sMode16;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         if ( IsDsp( ) || IsDlt( ) )
         {
            DisableAttributes0F16( ) ;
         }
         pr_default.close(1);
      }

      protected void CheckOptimisticConcurrency0F16( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000F2 */
            pr_default.execute(0, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailAttachments"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0F16( )
      {
         if ( ! IsAuthorized("wwpmail_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0F16( 0) ;
            CheckOptimisticConcurrency0F16( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0F16( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000F20 */
                     pr_default.execute(18, new Object[] {A122WWPMailId, A135WWPMailAttachmentName, A127WWPMailAttachmentFile});
                     pr_default.close(18);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                     if ( (pr_default.getStatus(18) == 1) )
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
               Load0F16( ) ;
            }
            EndLevel0F16( ) ;
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void Update0F16( )
      {
         if ( ! IsAuthorized("wwpmail_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0F16( ) ;
         }
         if ( ( nIsMod_16 != 0 ) || ( nIsDirty_16 != 0 ) )
         {
            if ( AnyError == 0 )
            {
               CheckOptimisticConcurrency0F16( ) ;
               if ( AnyError == 0 )
               {
                  AfterConfirm0F16( ) ;
                  if ( AnyError == 0 )
                  {
                     BeforeUpdate0F16( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Using cursor T000F21 */
                        pr_default.execute(19, new Object[] {A127WWPMailAttachmentFile, A122WWPMailId, A135WWPMailAttachmentName});
                        pr_default.close(19);
                        pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                        if ( (pr_default.getStatus(19) == 103) )
                        {
                           GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailAttachments"}), "RecordIsLocked", 1, "");
                           AnyError = 1;
                        }
                        DeferredUpdate0F16( ) ;
                        if ( AnyError == 0 )
                        {
                           /* Start of After( update) rules */
                           /* End of After( update) rules */
                           if ( AnyError == 0 )
                           {
                              getByPrimaryKey0F16( ) ;
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
               EndLevel0F16( ) ;
            }
         }
         CloseExtendedTableCursors0F16( ) ;
      }

      protected void DeferredUpdate0F16( )
      {
      }

      protected void Delete0F16( )
      {
         if ( ! IsAuthorized("wwpmail_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0F16( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0F16( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0F16( ) ;
            AfterConfirm0F16( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0F16( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000F22 */
                  pr_default.execute(20, new Object[] {A122WWPMailId, A135WWPMailAttachmentName});
                  pr_default.close(20);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailAttachments");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                  }
                  else
                  {
                     GX_msglist.addItem(context.GetMessage( "GXM_unexp", ""), 1, "");
                     AnyError = 1;
                  }
               }
            }
         }
         sMode16 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0F16( ) ;
         Gx_mode = sMode16;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0F16( )
      {
         standaloneModal0F16( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0F16( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0F16( )
      {
         /* Scan By routine */
         /* Using cursor T000F23 */
         pr_default.execute(21, new Object[] {A122WWPMailId});
         RcdFound16 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound16 = 1;
            A135WWPMailAttachmentName = T000F23_A135WWPMailAttachmentName[0];
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0F16( )
      {
         /* Scan next routine */
         pr_default.readNext(21);
         RcdFound16 = 0;
         if ( (pr_default.getStatus(21) != 101) )
         {
            RcdFound16 = 1;
            A135WWPMailAttachmentName = T000F23_A135WWPMailAttachmentName[0];
         }
      }

      protected void ScanEnd0F16( )
      {
         pr_default.close(21);
      }

      protected void AfterConfirm0F16( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0F16( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0F16( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0F16( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0F16( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0F16( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0F16( )
      {
         edtWWPMailAttachmentName_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
         edtWWPMailAttachmentFile_Enabled = 0;
         AssignProp("", false, edtWWPMailAttachmentFile_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void send_integrity_lvl_hashes0F16( )
      {
      }

      protected void send_integrity_lvl_hashes0F15( )
      {
      }

      protected void SubsflControlProps_11316( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx;
      }

      protected void SubsflControlProps_fel_11316( )
      {
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME_"+sGXsfl_113_fel_idx;
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE_"+sGXsfl_113_fel_idx;
      }

      protected void AddRow0F16( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11316( ) ;
         SendRow0F16( ) ;
      }

      protected void SendRow0F16( )
      {
         Gridwwp_mail_attachmentsRow = GXWebRow.GetNew(context);
         if ( subGridwwp_mail_attachments_Backcolorstyle == 0 )
         {
            /* None style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 1 )
         {
            /* Uniform style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 0;
            subGridwwp_mail_attachments_Backcolor = subGridwwp_mail_attachments_Allbackcolor;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Uniform";
            }
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 2 )
         {
            /* Header style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
            {
               subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
            }
            subGridwwp_mail_attachments_Backcolor = (int)(0x0);
         }
         else if ( subGridwwp_mail_attachments_Backcolorstyle == 3 )
         {
            /* Report style subfile background logic. */
            subGridwwp_mail_attachments_Backstyle = 1;
            if ( ((int)((nGXsfl_113_idx) % (2))) == 0 )
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Even";
               }
            }
            else
            {
               subGridwwp_mail_attachments_Backcolor = (int)(0x0);
               if ( StringUtil.StrCmp(subGridwwp_mail_attachments_Class, "") != 0 )
               {
                  subGridwwp_mail_attachments_Linesclass = subGridwwp_mail_attachments_Class+"Odd";
               }
            }
         }
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 114,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentName_Internalname,(string)A135WWPMailAttachmentName,(string)"",TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,114);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentName_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentName_Enabled,(short)1,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(short)40,(short)0,(short)0,(short)113,(short)0,(short)-1,(short)-1,(bool)true,(string)"",(string)"start",(bool)true,(string)""});
         /* Subfile cell */
         /* Single line edit */
         TempTags = " data-gxoch1=\"gx.fn.setControlValue('nIsMod_16_" + sGXsfl_113_idx + "',1);\"  onfocus=\"gx.evt.onfocus(this, 115,'',false,'" + sGXsfl_113_idx + "',113)\"";
         ROClassString = "Attribute";
         Gridwwp_mail_attachmentsRow.AddColumnProperties("edit", 1, isAjaxCallMode( ), new Object[] {(string)edtWWPMailAttachmentFile_Internalname,(string)A127WWPMailAttachmentFile,(string)A127WWPMailAttachmentFile,TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,115);\"",(string)"'"+""+"'"+",false,"+"'"+""+"'",(string)"",(string)"",(string)"",(string)"",(string)edtWWPMailAttachmentFile_Jsonclick,(short)0,(string)"Attribute",(string)"",(string)ROClassString,(string)"",(string)"",(short)-1,(int)edtWWPMailAttachmentFile_Enabled,(short)0,(string)"text",(string)"",(short)0,(string)"px",(short)17,(string)"px",(int)2097152,(short)0,(short)0,(short)113,(short)0,(short)0,(short)-1,(bool)true,(string)"",(string)"start",(bool)false,(string)""});
         ajax_sending_grid_row(Gridwwp_mail_attachmentsRow);
         send_integrity_lvl_hashes0F16( ) ;
         GXCCtl = "Z135WWPMailAttachmentName_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, Z135WWPMailAttachmentName);
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdDeleted_16), 4, 0, ",", "")));
         GXCCtl = "nRcdExists_16_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nRcdExists_16), 4, 0, ",", "")));
         GXCCtl = "nIsMod_16_" + sGXsfl_113_idx;
         GxWebStd.gx_hidden_field( context, GXCCtl, StringUtil.LTrim( StringUtil.NToC( (decimal)(nIsMod_16), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         ajax_sending_grid_row(null);
         Gridwwp_mail_attachmentsContainer.AddRow(Gridwwp_mail_attachmentsRow);
      }

      protected void ReadRow0F16( )
      {
         nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11316( ) ;
         edtWWPMailAttachmentName_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTNAME_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         edtWWPMailAttachmentFile_Enabled = (int)(Math.Round(context.localUtil.CToN( cgiGet( "WWPMAILATTACHMENTFILE_"+sGXsfl_113_idx+"Enabled"), ",", "."), 18, MidpointRounding.ToEven));
         A135WWPMailAttachmentName = cgiGet( edtWWPMailAttachmentName_Internalname);
         A127WWPMailAttachmentFile = cgiGet( edtWWPMailAttachmentFile_Internalname);
         GXCCtl = "Z135WWPMailAttachmentName_" + sGXsfl_113_idx;
         Z135WWPMailAttachmentName = cgiGet( GXCCtl);
         GXCCtl = "nRcdDeleted_16_" + sGXsfl_113_idx;
         nRcdDeleted_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nRcdExists_16_" + sGXsfl_113_idx;
         nRcdExists_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
         GXCCtl = "nIsMod_16_" + sGXsfl_113_idx;
         nIsMod_16 = (short)(Math.Round(context.localUtil.CToN( cgiGet( GXCCtl), ",", "."), 18, MidpointRounding.ToEven));
      }

      protected void assign_properties_default( )
      {
         defedtWWPMailAttachmentName_Enabled = edtWWPMailAttachmentName_Enabled;
      }

      protected void ConfirmValues0F0( )
      {
         nGXsfl_113_idx = 0;
         sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
         SubsflControlProps_11316( ) ;
         while ( nGXsfl_113_idx < nRC_GXsfl_113 )
         {
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11316( ) ;
            ChangePostValue( "Z135WWPMailAttachmentName_"+sGXsfl_113_idx, cgiGet( "ZT_"+"Z135WWPMailAttachmentName_"+sGXsfl_113_idx)) ;
            DeletePostValue( "ZT_"+"Z135WWPMailAttachmentName_"+sGXsfl_113_idx) ;
         }
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mail.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z122WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122WWPMailId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z111WWPMailSubject", Z111WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z123WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z123WWPMailStatus), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z133WWPMailCreated", context.localUtil.TToC( Z133WWPMailCreated, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z134WWPMailScheduled", context.localUtil.TToC( Z134WWPMailScheduled, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z128WWPMailProcessed", context.localUtil.TToC( Z128WWPMailProcessed, 10, 12, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "nRC_GXsfl_113", StringUtil.LTrim( StringUtil.NToC( (decimal)(nGXsfl_113_idx), 8, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.mail.wwp_mail.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_Mail" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mail" ;
      }

      protected void InitializeNonKey0F15( )
      {
         A111WWPMailSubject = "";
         AssignAttri("", false, "A111WWPMailSubject", A111WWPMailSubject);
         A103WWPMailBody = "";
         AssignAttri("", false, "A103WWPMailBody", A103WWPMailBody);
         A112WWPMailTo = "";
         n112WWPMailTo = false;
         AssignAttri("", false, "A112WWPMailTo", A112WWPMailTo);
         n112WWPMailTo = (String.IsNullOrEmpty(StringUtil.RTrim( A112WWPMailTo)) ? true : false);
         A125WWPMailCC = "";
         n125WWPMailCC = false;
         AssignAttri("", false, "A125WWPMailCC", A125WWPMailCC);
         n125WWPMailCC = (String.IsNullOrEmpty(StringUtil.RTrim( A125WWPMailCC)) ? true : false);
         A126WWPMailBCC = "";
         n126WWPMailBCC = false;
         AssignAttri("", false, "A126WWPMailBCC", A126WWPMailBCC);
         n126WWPMailBCC = (String.IsNullOrEmpty(StringUtil.RTrim( A126WWPMailBCC)) ? true : false);
         A113WWPMailSenderAddress = "";
         AssignAttri("", false, "A113WWPMailSenderAddress", A113WWPMailSenderAddress);
         A114WWPMailSenderName = "";
         AssignAttri("", false, "A114WWPMailSenderName", A114WWPMailSenderName);
         A128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         n128WWPMailProcessed = false;
         AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         n128WWPMailProcessed = ((DateTime.MinValue==A128WWPMailProcessed) ? true : false);
         A129WWPMailDetail = "";
         n129WWPMailDetail = false;
         AssignAttri("", false, "A129WWPMailDetail", A129WWPMailDetail);
         n129WWPMailDetail = (String.IsNullOrEmpty(StringUtil.RTrim( A129WWPMailDetail)) ? true : false);
         A64WWPNotificationId = 0;
         n64WWPNotificationId = false;
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrimStr( (decimal)(A64WWPNotificationId), 10, 0));
         n64WWPNotificationId = ((0==A64WWPNotificationId) ? true : false);
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         A123WWPMailStatus = 1;
         AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
         A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         Z111WWPMailSubject = "";
         Z123WWPMailStatus = 0;
         Z133WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z64WWPNotificationId = 0;
      }

      protected void InitAll0F15( )
      {
         A122WWPMailId = 0;
         AssignAttri("", false, "A122WWPMailId", StringUtil.LTrimStr( (decimal)(A122WWPMailId), 10, 0));
         InitializeNonKey0F15( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A123WWPMailStatus = i123WWPMailStatus;
         AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
         A133WWPMailCreated = i133WWPMailCreated;
         AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         A134WWPMailScheduled = i134WWPMailScheduled;
         AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
      }

      protected void InitializeNonKey0F16( )
      {
         A127WWPMailAttachmentFile = "";
      }

      protected void InitAll0F16( )
      {
         A135WWPMailAttachmentName = "";
         InitializeNonKey0F16( ) ;
      }

      protected void StandaloneModalInsert0F16( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828121721", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mail.js", "?2023828121721", false, true);
         /* End function include_jscripts */
      }

      protected void init_level_properties16( )
      {
         edtWWPMailAttachmentName_Enabled = defedtWWPMailAttachmentName_Enabled;
         AssignProp("", false, edtWWPMailAttachmentName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0), !bGXsfl_113_Refreshing);
      }

      protected void StartGridControl113( )
      {
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("GridName", "Gridwwp_mail_attachments");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Header", subGridwwp_mail_attachments_Header);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Class", "Grid");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellpadding", StringUtil.LTrim( StringUtil.NToC( (decimal)(1), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Cellspacing", StringUtil.LTrim( StringUtil.NToC( (decimal)(2), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Backcolorstyle", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Backcolorstyle), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("CmpContext", "");
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("InMasterPage", "false");
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A135WWPMailAttachmentName));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentName_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsColumn = GXWebColumn.GetNew(isAjaxCallMode( ));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Value", GXUtil.ValueEncode( A127WWPMailAttachmentFile));
         Gridwwp_mail_attachmentsColumn.AddObjectProperty("Enabled", StringUtil.LTrim( StringUtil.NToC( (decimal)(edtWWPMailAttachmentFile_Enabled), 5, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddColumnProperties(Gridwwp_mail_attachmentsColumn);
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectedindex", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectedindex), 4, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowselection", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowselection), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Selectioncolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Selectioncolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowhover", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowhovering), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Hovercolor", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Hoveringcolor), 9, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Allowcollapsing", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Allowcollapsing), 1, 0, ".", "")));
         Gridwwp_mail_attachmentsContainer.AddObjectProperty("Collapsed", StringUtil.LTrim( StringUtil.NToC( (decimal)(subGridwwp_mail_attachments_Collapsed), 1, 0, ".", "")));
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
         edtWWPMailId_Internalname = "WWPMAILID";
         edtWWPMailSubject_Internalname = "WWPMAILSUBJECT";
         edtWWPMailBody_Internalname = "WWPMAILBODY";
         edtWWPMailTo_Internalname = "WWPMAILTO";
         edtWWPMailCC_Internalname = "WWPMAILCC";
         edtWWPMailBCC_Internalname = "WWPMAILBCC";
         edtWWPMailSenderAddress_Internalname = "WWPMAILSENDERADDRESS";
         edtWWPMailSenderName_Internalname = "WWPMAILSENDERNAME";
         cmbWWPMailStatus_Internalname = "WWPMAILSTATUS";
         edtWWPMailCreated_Internalname = "WWPMAILCREATED";
         edtWWPMailScheduled_Internalname = "WWPMAILSCHEDULED";
         edtWWPMailProcessed_Internalname = "WWPMAILPROCESSED";
         edtWWPMailDetail_Internalname = "WWPMAILDETAIL";
         edtWWPNotificationId_Internalname = "WWPNOTIFICATIONID";
         edtWWPNotificationCreated_Internalname = "WWPNOTIFICATIONCREATED";
         lblTitleattachments_Internalname = "TITLEATTACHMENTS";
         edtWWPMailAttachmentName_Internalname = "WWPMAILATTACHMENTNAME";
         edtWWPMailAttachmentFile_Internalname = "WWPMAILATTACHMENTFILE";
         divAttachmentstable_Internalname = "ATTACHMENTSTABLE";
         divFormcontainer_Internalname = "FORMCONTAINER";
         bttBtn_enter_Internalname = "BTN_ENTER";
         bttBtn_cancel_Internalname = "BTN_CANCEL";
         bttBtn_delete_Internalname = "BTN_DELETE";
         divMaintable_Internalname = "MAINTABLE";
         Form.Internalname = "FORM";
         subGridwwp_mail_attachments_Internalname = "GRIDWWP_MAIL_ATTACHMENTS";
      }

      public override void initialize_properties( )
      {
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( context.isSpaRequest( ) )
         {
            disableJsOutput();
         }
         init_default_properties( ) ;
         subGridwwp_mail_attachments_Allowcollapsing = 0;
         subGridwwp_mail_attachments_Allowselection = 0;
         subGridwwp_mail_attachments_Header = "";
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Mail";
         edtWWPMailAttachmentFile_Jsonclick = "";
         edtWWPMailAttachmentName_Jsonclick = "";
         subGridwwp_mail_attachments_Class = "Grid";
         subGridwwp_mail_attachments_Backcolorstyle = 0;
         edtWWPMailAttachmentFile_Enabled = 1;
         edtWWPMailAttachmentName_Enabled = 1;
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPNotificationCreated_Jsonclick = "";
         edtWWPNotificationCreated_Enabled = 0;
         edtWWPNotificationId_Jsonclick = "";
         edtWWPNotificationId_Enabled = 1;
         edtWWPMailDetail_Enabled = 1;
         edtWWPMailProcessed_Jsonclick = "";
         edtWWPMailProcessed_Enabled = 1;
         edtWWPMailScheduled_Jsonclick = "";
         edtWWPMailScheduled_Enabled = 1;
         edtWWPMailCreated_Jsonclick = "";
         edtWWPMailCreated_Enabled = 1;
         cmbWWPMailStatus_Jsonclick = "";
         cmbWWPMailStatus.Enabled = 1;
         edtWWPMailSenderName_Enabled = 1;
         edtWWPMailSenderAddress_Enabled = 1;
         edtWWPMailBCC_Enabled = 1;
         edtWWPMailCC_Enabled = 1;
         edtWWPMailTo_Enabled = 1;
         edtWWPMailBody_Enabled = 1;
         edtWWPMailSubject_Jsonclick = "";
         edtWWPMailSubject_Enabled = 1;
         edtWWPMailId_Jsonclick = "";
         edtWWPMailId_Enabled = 1;
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

      protected void gxnrGridwwp_mail_attachments_newrow( )
      {
         GxWebStd.set_html_headers( context, 0, "", "");
         Gx_mode = "INS";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         SubsflControlProps_11316( ) ;
         while ( nGXsfl_113_idx <= nRC_GXsfl_113 )
         {
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            standaloneNotModal0F16( ) ;
            standaloneModal0F16( ) ;
            init_web_controls( ) ;
            dynload_actions( ) ;
            SendRow0F16( ) ;
            nGXsfl_113_idx = (int)(nGXsfl_113_idx+1);
            sGXsfl_113_idx = StringUtil.PadL( StringUtil.LTrimStr( (decimal)(nGXsfl_113_idx), 4, 0), 4, "0");
            SubsflControlProps_11316( ) ;
         }
         AddString( context.httpAjaxContext.getJSONContainerResponse( Gridwwp_mail_attachmentsContainer)) ;
         /* End function gxnrGridwwp_mail_attachments_newrow */
      }

      protected void init_web_controls( )
      {
         cmbWWPMailStatus.Name = "WWPMAILSTATUS";
         cmbWWPMailStatus.WebTags = "";
         cmbWWPMailStatus.addItem("1", "Pending", 0);
         cmbWWPMailStatus.addItem("2", "Sent", 0);
         cmbWWPMailStatus.addItem("3", "Error", 0);
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            if ( IsIns( ) && (0==A123WWPMailStatus) )
            {
               A123WWPMailStatus = 1;
               AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0));
            }
         }
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailSubject_Internalname;
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

      public void Valid_Wwpmailid( )
      {
         A123WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.CurrentValue, "."), 18, MidpointRounding.ToEven));
         cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0);
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         if ( cmbWWPMailStatus.ItemCount > 0 )
         {
            A123WWPMailStatus = (short)(Math.Round(NumberUtil.Val( cmbWWPMailStatus.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0))), "."), 18, MidpointRounding.ToEven));
            cmbWWPMailStatus.CurrentValue = StringUtil.LTrimStr( (decimal)(A123WWPMailStatus), 4, 0);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0));
         }
         /*  Sending validation outputs */
         AssignAttri("", false, "A111WWPMailSubject", A111WWPMailSubject);
         AssignAttri("", false, "A103WWPMailBody", A103WWPMailBody);
         AssignAttri("", false, "A112WWPMailTo", A112WWPMailTo);
         AssignAttri("", false, "A125WWPMailCC", A125WWPMailCC);
         AssignAttri("", false, "A126WWPMailBCC", A126WWPMailBCC);
         AssignAttri("", false, "A113WWPMailSenderAddress", A113WWPMailSenderAddress);
         AssignAttri("", false, "A114WWPMailSenderName", A114WWPMailSenderName);
         AssignAttri("", false, "A123WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(A123WWPMailStatus), 4, 0, ".", "")));
         cmbWWPMailStatus.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(A123WWPMailStatus), 4, 0));
         AssignProp("", false, cmbWWPMailStatus_Internalname, "Values", cmbWWPMailStatus.ToJavascriptSource(), true);
         AssignAttri("", false, "A133WWPMailCreated", context.localUtil.TToC( A133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A134WWPMailScheduled", context.localUtil.TToC( A134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A128WWPMailProcessed", context.localUtil.TToC( A128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A129WWPMailDetail", A129WWPMailDetail);
         AssignAttri("", false, "A64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A64WWPNotificationId), 10, 0, ".", "")));
         AssignAttri("", false, "A66WWPNotificationCreated", context.localUtil.TToC( A66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z122WWPMailId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z122WWPMailId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z111WWPMailSubject", Z111WWPMailSubject);
         GxWebStd.gx_hidden_field( context, "Z103WWPMailBody", Z103WWPMailBody);
         GxWebStd.gx_hidden_field( context, "Z112WWPMailTo", Z112WWPMailTo);
         GxWebStd.gx_hidden_field( context, "Z125WWPMailCC", Z125WWPMailCC);
         GxWebStd.gx_hidden_field( context, "Z126WWPMailBCC", Z126WWPMailBCC);
         GxWebStd.gx_hidden_field( context, "Z113WWPMailSenderAddress", Z113WWPMailSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z114WWPMailSenderName", Z114WWPMailSenderName);
         GxWebStd.gx_hidden_field( context, "Z123WWPMailStatus", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z123WWPMailStatus), 4, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z133WWPMailCreated", context.localUtil.TToC( Z133WWPMailCreated, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z134WWPMailScheduled", context.localUtil.TToC( Z134WWPMailScheduled, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z128WWPMailProcessed", context.localUtil.TToC( Z128WWPMailProcessed, 10, 12, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z129WWPMailDetail", Z129WWPMailDetail);
         GxWebStd.gx_hidden_field( context, "Z64WWPNotificationId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z64WWPNotificationId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z66WWPNotificationCreated", context.localUtil.TToC( Z66WWPNotificationCreated, 10, 12, 0, 3, "/", ":", " "));
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpnotificationid( )
      {
         n64WWPNotificationId = false;
         /* Using cursor T000F16 */
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
         A66WWPNotificationCreated = T000F16_A66WWPNotificationCreated[0];
         pr_default.close(14);
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
         setEventMetadata("VALID_WWPMAILID","{handler:'Valid_Wwpmailid',iparms:[{av:'A122WWPMailId',fld:'WWPMAILID',pic:'ZZZZZZZZZ9'},{av:'Gx_BScreen',fld:'vGXBSCREEN',pic:'9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'cmbWWPMailStatus'},{av:'A123WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A133WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A134WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPMAILID",",oparms:[{av:'A111WWPMailSubject',fld:'WWPMAILSUBJECT',pic:''},{av:'A103WWPMailBody',fld:'WWPMAILBODY',pic:''},{av:'A112WWPMailTo',fld:'WWPMAILTO',pic:''},{av:'A125WWPMailCC',fld:'WWPMAILCC',pic:''},{av:'A126WWPMailBCC',fld:'WWPMAILBCC',pic:''},{av:'A113WWPMailSenderAddress',fld:'WWPMAILSENDERADDRESS',pic:''},{av:'A114WWPMailSenderName',fld:'WWPMAILSENDERNAME',pic:''},{av:'cmbWWPMailStatus'},{av:'A123WWPMailStatus',fld:'WWPMAILSTATUS',pic:'ZZZ9'},{av:'A133WWPMailCreated',fld:'WWPMAILCREATED',pic:'99/99/9999 99:99:99.999'},{av:'A134WWPMailScheduled',fld:'WWPMAILSCHEDULED',pic:'99/99/9999 99:99:99.999'},{av:'A128WWPMailProcessed',fld:'WWPMAILPROCESSED',pic:'99/99/9999 99:99:99.999'},{av:'A129WWPMailDetail',fld:'WWPMAILDETAIL',pic:''},{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z122WWPMailId'},{av:'Z111WWPMailSubject'},{av:'Z103WWPMailBody'},{av:'Z112WWPMailTo'},{av:'Z125WWPMailCC'},{av:'Z126WWPMailBCC'},{av:'Z113WWPMailSenderAddress'},{av:'Z114WWPMailSenderName'},{av:'Z123WWPMailStatus'},{av:'Z133WWPMailCreated'},{av:'Z134WWPMailScheduled'},{av:'Z128WWPMailProcessed'},{av:'Z129WWPMailDetail'},{av:'Z64WWPNotificationId'},{av:'Z66WWPNotificationCreated'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPMAILSTATUS","{handler:'Valid_Wwpmailstatus',iparms:[]");
         setEventMetadata("VALID_WWPMAILSTATUS",",oparms:[]}");
         setEventMetadata("VALID_WWPNOTIFICATIONID","{handler:'Valid_Wwpnotificationid',iparms:[{av:'A64WWPNotificationId',fld:'WWPNOTIFICATIONID',pic:'ZZZZZZZZZ9'},{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]");
         setEventMetadata("VALID_WWPNOTIFICATIONID",",oparms:[{av:'A66WWPNotificationCreated',fld:'WWPNOTIFICATIONCREATED',pic:'99/99/9999 99:99:99.999'}]}");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME","{handler:'Valid_Wwpmailattachmentname',iparms:[]");
         setEventMetadata("VALID_WWPMAILATTACHMENTNAME",",oparms:[]}");
         setEventMetadata("NULL","{handler:'Valid_Wwpmailattachmentfile',iparms:[]");
         setEventMetadata("NULL",",oparms:[]}");
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
         pr_default.close(3);
         pr_default.close(14);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z111WWPMailSubject = "";
         Z133WWPMailCreated = (DateTime)(DateTime.MinValue);
         Z134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Z128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         Z135WWPMailAttachmentName = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         GXKey = "";
         PreviousTooltip = "";
         PreviousCaption = "";
         Form = new GXWebForm();
         GX_FocusControl = "";
         Gx_mode = "";
         lblTitle_Jsonclick = "";
         ClassString = "";
         StyleString = "";
         TempTags = "";
         bttBtn_first_Jsonclick = "";
         bttBtn_previous_Jsonclick = "";
         bttBtn_next_Jsonclick = "";
         bttBtn_last_Jsonclick = "";
         bttBtn_select_Jsonclick = "";
         A111WWPMailSubject = "";
         A103WWPMailBody = "";
         A112WWPMailTo = "";
         A125WWPMailCC = "";
         A126WWPMailBCC = "";
         A113WWPMailSenderAddress = "";
         A114WWPMailSenderName = "";
         A133WWPMailCreated = (DateTime)(DateTime.MinValue);
         A134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         A128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         A129WWPMailDetail = "";
         A66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         lblTitleattachments_Jsonclick = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         Gridwwp_mail_attachmentsContainer = new GXWebGrid( context);
         sMode16 = "";
         sStyleString = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         GXCCtl = "";
         A135WWPMailAttachmentName = "";
         A127WWPMailAttachmentFile = "";
         Z103WWPMailBody = "";
         Z112WWPMailTo = "";
         Z125WWPMailCC = "";
         Z126WWPMailBCC = "";
         Z113WWPMailSenderAddress = "";
         Z114WWPMailSenderName = "";
         Z129WWPMailDetail = "";
         Z66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         T000F7_A122WWPMailId = new long[1] ;
         T000F7_A111WWPMailSubject = new string[] {""} ;
         T000F7_A103WWPMailBody = new string[] {""} ;
         T000F7_A112WWPMailTo = new string[] {""} ;
         T000F7_n112WWPMailTo = new bool[] {false} ;
         T000F7_A125WWPMailCC = new string[] {""} ;
         T000F7_n125WWPMailCC = new bool[] {false} ;
         T000F7_A126WWPMailBCC = new string[] {""} ;
         T000F7_n126WWPMailBCC = new bool[] {false} ;
         T000F7_A113WWPMailSenderAddress = new string[] {""} ;
         T000F7_A114WWPMailSenderName = new string[] {""} ;
         T000F7_A123WWPMailStatus = new short[1] ;
         T000F7_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000F7_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000F7_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000F7_n128WWPMailProcessed = new bool[] {false} ;
         T000F7_A129WWPMailDetail = new string[] {""} ;
         T000F7_n129WWPMailDetail = new bool[] {false} ;
         T000F7_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000F7_A64WWPNotificationId = new long[1] ;
         T000F7_n64WWPNotificationId = new bool[] {false} ;
         T000F6_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000F8_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000F9_A122WWPMailId = new long[1] ;
         T000F5_A122WWPMailId = new long[1] ;
         T000F5_A111WWPMailSubject = new string[] {""} ;
         T000F5_A103WWPMailBody = new string[] {""} ;
         T000F5_A112WWPMailTo = new string[] {""} ;
         T000F5_n112WWPMailTo = new bool[] {false} ;
         T000F5_A125WWPMailCC = new string[] {""} ;
         T000F5_n125WWPMailCC = new bool[] {false} ;
         T000F5_A126WWPMailBCC = new string[] {""} ;
         T000F5_n126WWPMailBCC = new bool[] {false} ;
         T000F5_A113WWPMailSenderAddress = new string[] {""} ;
         T000F5_A114WWPMailSenderName = new string[] {""} ;
         T000F5_A123WWPMailStatus = new short[1] ;
         T000F5_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000F5_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000F5_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000F5_n128WWPMailProcessed = new bool[] {false} ;
         T000F5_A129WWPMailDetail = new string[] {""} ;
         T000F5_n129WWPMailDetail = new bool[] {false} ;
         T000F5_A64WWPNotificationId = new long[1] ;
         T000F5_n64WWPNotificationId = new bool[] {false} ;
         sMode15 = "";
         T000F10_A122WWPMailId = new long[1] ;
         T000F11_A122WWPMailId = new long[1] ;
         T000F4_A122WWPMailId = new long[1] ;
         T000F4_A111WWPMailSubject = new string[] {""} ;
         T000F4_A103WWPMailBody = new string[] {""} ;
         T000F4_A112WWPMailTo = new string[] {""} ;
         T000F4_n112WWPMailTo = new bool[] {false} ;
         T000F4_A125WWPMailCC = new string[] {""} ;
         T000F4_n125WWPMailCC = new bool[] {false} ;
         T000F4_A126WWPMailBCC = new string[] {""} ;
         T000F4_n126WWPMailBCC = new bool[] {false} ;
         T000F4_A113WWPMailSenderAddress = new string[] {""} ;
         T000F4_A114WWPMailSenderName = new string[] {""} ;
         T000F4_A123WWPMailStatus = new short[1] ;
         T000F4_A133WWPMailCreated = new DateTime[] {DateTime.MinValue} ;
         T000F4_A134WWPMailScheduled = new DateTime[] {DateTime.MinValue} ;
         T000F4_A128WWPMailProcessed = new DateTime[] {DateTime.MinValue} ;
         T000F4_n128WWPMailProcessed = new bool[] {false} ;
         T000F4_A129WWPMailDetail = new string[] {""} ;
         T000F4_n129WWPMailDetail = new bool[] {false} ;
         T000F4_A64WWPNotificationId = new long[1] ;
         T000F4_n64WWPNotificationId = new bool[] {false} ;
         T000F13_A122WWPMailId = new long[1] ;
         T000F16_A66WWPNotificationCreated = new DateTime[] {DateTime.MinValue} ;
         T000F17_A122WWPMailId = new long[1] ;
         Z127WWPMailAttachmentFile = "";
         T000F18_A122WWPMailId = new long[1] ;
         T000F18_A135WWPMailAttachmentName = new string[] {""} ;
         T000F18_A127WWPMailAttachmentFile = new string[] {""} ;
         T000F19_A122WWPMailId = new long[1] ;
         T000F19_A135WWPMailAttachmentName = new string[] {""} ;
         T000F3_A122WWPMailId = new long[1] ;
         T000F3_A135WWPMailAttachmentName = new string[] {""} ;
         T000F3_A127WWPMailAttachmentFile = new string[] {""} ;
         T000F2_A122WWPMailId = new long[1] ;
         T000F2_A135WWPMailAttachmentName = new string[] {""} ;
         T000F2_A127WWPMailAttachmentFile = new string[] {""} ;
         T000F23_A122WWPMailId = new long[1] ;
         T000F23_A135WWPMailAttachmentName = new string[] {""} ;
         Gridwwp_mail_attachmentsRow = new GXWebRow();
         subGridwwp_mail_attachments_Linesclass = "";
         ROClassString = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         i133WWPMailCreated = (DateTime)(DateTime.MinValue);
         i134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         Gridwwp_mail_attachmentsColumn = new GXWebColumn();
         ZZ111WWPMailSubject = "";
         ZZ103WWPMailBody = "";
         ZZ112WWPMailTo = "";
         ZZ125WWPMailCC = "";
         ZZ126WWPMailBCC = "";
         ZZ113WWPMailSenderAddress = "";
         ZZ114WWPMailSenderName = "";
         ZZ133WWPMailCreated = (DateTime)(DateTime.MinValue);
         ZZ134WWPMailScheduled = (DateTime)(DateTime.MinValue);
         ZZ128WWPMailProcessed = (DateTime)(DateTime.MinValue);
         ZZ129WWPMailDetail = "";
         ZZ66WWPNotificationCreated = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mail__default(),
            new Object[][] {
                new Object[] {
               T000F2_A122WWPMailId, T000F2_A135WWPMailAttachmentName, T000F2_A127WWPMailAttachmentFile
               }
               , new Object[] {
               T000F3_A122WWPMailId, T000F3_A135WWPMailAttachmentName, T000F3_A127WWPMailAttachmentFile
               }
               , new Object[] {
               T000F4_A122WWPMailId, T000F4_A111WWPMailSubject, T000F4_A103WWPMailBody, T000F4_A112WWPMailTo, T000F4_n112WWPMailTo, T000F4_A125WWPMailCC, T000F4_n125WWPMailCC, T000F4_A126WWPMailBCC, T000F4_n126WWPMailBCC, T000F4_A113WWPMailSenderAddress,
               T000F4_A114WWPMailSenderName, T000F4_A123WWPMailStatus, T000F4_A133WWPMailCreated, T000F4_A134WWPMailScheduled, T000F4_A128WWPMailProcessed, T000F4_n128WWPMailProcessed, T000F4_A129WWPMailDetail, T000F4_n129WWPMailDetail, T000F4_A64WWPNotificationId, T000F4_n64WWPNotificationId
               }
               , new Object[] {
               T000F5_A122WWPMailId, T000F5_A111WWPMailSubject, T000F5_A103WWPMailBody, T000F5_A112WWPMailTo, T000F5_n112WWPMailTo, T000F5_A125WWPMailCC, T000F5_n125WWPMailCC, T000F5_A126WWPMailBCC, T000F5_n126WWPMailBCC, T000F5_A113WWPMailSenderAddress,
               T000F5_A114WWPMailSenderName, T000F5_A123WWPMailStatus, T000F5_A133WWPMailCreated, T000F5_A134WWPMailScheduled, T000F5_A128WWPMailProcessed, T000F5_n128WWPMailProcessed, T000F5_A129WWPMailDetail, T000F5_n129WWPMailDetail, T000F5_A64WWPNotificationId, T000F5_n64WWPNotificationId
               }
               , new Object[] {
               T000F6_A66WWPNotificationCreated
               }
               , new Object[] {
               T000F7_A122WWPMailId, T000F7_A111WWPMailSubject, T000F7_A103WWPMailBody, T000F7_A112WWPMailTo, T000F7_n112WWPMailTo, T000F7_A125WWPMailCC, T000F7_n125WWPMailCC, T000F7_A126WWPMailBCC, T000F7_n126WWPMailBCC, T000F7_A113WWPMailSenderAddress,
               T000F7_A114WWPMailSenderName, T000F7_A123WWPMailStatus, T000F7_A133WWPMailCreated, T000F7_A134WWPMailScheduled, T000F7_A128WWPMailProcessed, T000F7_n128WWPMailProcessed, T000F7_A129WWPMailDetail, T000F7_n129WWPMailDetail, T000F7_A66WWPNotificationCreated, T000F7_A64WWPNotificationId,
               T000F7_n64WWPNotificationId
               }
               , new Object[] {
               T000F8_A66WWPNotificationCreated
               }
               , new Object[] {
               T000F9_A122WWPMailId
               }
               , new Object[] {
               T000F10_A122WWPMailId
               }
               , new Object[] {
               T000F11_A122WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               T000F13_A122WWPMailId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F16_A66WWPNotificationCreated
               }
               , new Object[] {
               T000F17_A122WWPMailId
               }
               , new Object[] {
               T000F18_A122WWPMailId, T000F18_A135WWPMailAttachmentName, T000F18_A127WWPMailAttachmentFile
               }
               , new Object[] {
               T000F19_A122WWPMailId, T000F19_A135WWPMailAttachmentName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000F23_A122WWPMailId, T000F23_A135WWPMailAttachmentName
               }
            }
         );
         Z134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         A134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         i134WWPMailScheduled = DateTimeUtil.ServerNowMs( context, pr_default);
         Z133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         A133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         i133WWPMailCreated = DateTimeUtil.ServerNowMs( context, pr_default);
         Z123WWPMailStatus = 1;
         A123WWPMailStatus = 1;
         i123WWPMailStatus = 1;
      }

      private short Z123WWPMailStatus ;
      private short nRcdDeleted_16 ;
      private short nRcdExists_16 ;
      private short nIsMod_16 ;
      private short GxWebError ;
      private short gxcookieaux ;
      private short IsConfirmed ;
      private short IsModified ;
      private short AnyError ;
      private short nKeyPressed ;
      private short initialized ;
      private short A123WWPMailStatus ;
      private short nBlankRcdCount16 ;
      private short RcdFound16 ;
      private short nBlankRcdUsr16 ;
      private short Gx_BScreen ;
      private short GX_JID ;
      private short RcdFound15 ;
      private short nIsDirty_15 ;
      private short nIsDirty_16 ;
      private short subGridwwp_mail_attachments_Backcolorstyle ;
      private short subGridwwp_mail_attachments_Backstyle ;
      private short gxajaxcallmode ;
      private short i123WWPMailStatus ;
      private short subGridwwp_mail_attachments_Allowselection ;
      private short subGridwwp_mail_attachments_Allowhovering ;
      private short subGridwwp_mail_attachments_Allowcollapsing ;
      private short subGridwwp_mail_attachments_Collapsed ;
      private short ZZ123WWPMailStatus ;
      private int nRC_GXsfl_113 ;
      private int nGXsfl_113_idx=1 ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailId_Enabled ;
      private int edtWWPMailSubject_Enabled ;
      private int edtWWPMailBody_Enabled ;
      private int edtWWPMailTo_Enabled ;
      private int edtWWPMailCC_Enabled ;
      private int edtWWPMailBCC_Enabled ;
      private int edtWWPMailSenderAddress_Enabled ;
      private int edtWWPMailSenderName_Enabled ;
      private int edtWWPMailCreated_Enabled ;
      private int edtWWPMailScheduled_Enabled ;
      private int edtWWPMailProcessed_Enabled ;
      private int edtWWPMailDetail_Enabled ;
      private int edtWWPNotificationId_Enabled ;
      private int edtWWPNotificationCreated_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int edtWWPMailAttachmentName_Enabled ;
      private int edtWWPMailAttachmentFile_Enabled ;
      private int fRowAdded ;
      private int subGridwwp_mail_attachments_Backcolor ;
      private int subGridwwp_mail_attachments_Allbackcolor ;
      private int defedtWWPMailAttachmentName_Enabled ;
      private int idxLst ;
      private int subGridwwp_mail_attachments_Selectedindex ;
      private int subGridwwp_mail_attachments_Selectioncolor ;
      private int subGridwwp_mail_attachments_Hoveringcolor ;
      private long Z122WWPMailId ;
      private long Z64WWPNotificationId ;
      private long A64WWPNotificationId ;
      private long A122WWPMailId ;
      private long GRIDWWP_MAIL_ATTACHMENTS_nFirstRecordOnPage ;
      private long ZZ122WWPMailId ;
      private long ZZ64WWPNotificationId ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailId_Internalname ;
      private string sGXsfl_113_idx="0001" ;
      private string Gx_mode ;
      private string cmbWWPMailStatus_Internalname ;
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
      private string edtWWPMailId_Jsonclick ;
      private string edtWWPMailSubject_Internalname ;
      private string edtWWPMailSubject_Jsonclick ;
      private string edtWWPMailBody_Internalname ;
      private string edtWWPMailTo_Internalname ;
      private string edtWWPMailCC_Internalname ;
      private string edtWWPMailBCC_Internalname ;
      private string edtWWPMailSenderAddress_Internalname ;
      private string edtWWPMailSenderName_Internalname ;
      private string cmbWWPMailStatus_Jsonclick ;
      private string edtWWPMailCreated_Internalname ;
      private string edtWWPMailCreated_Jsonclick ;
      private string edtWWPMailScheduled_Internalname ;
      private string edtWWPMailScheduled_Jsonclick ;
      private string edtWWPMailProcessed_Internalname ;
      private string edtWWPMailProcessed_Jsonclick ;
      private string edtWWPMailDetail_Internalname ;
      private string edtWWPNotificationId_Internalname ;
      private string edtWWPNotificationId_Jsonclick ;
      private string edtWWPNotificationCreated_Internalname ;
      private string edtWWPNotificationCreated_Jsonclick ;
      private string divAttachmentstable_Internalname ;
      private string lblTitleattachments_Internalname ;
      private string lblTitleattachments_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sMode16 ;
      private string edtWWPMailAttachmentName_Internalname ;
      private string edtWWPMailAttachmentFile_Internalname ;
      private string sStyleString ;
      private string subGridwwp_mail_attachments_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string GXCCtl ;
      private string sMode15 ;
      private string sGXsfl_113_fel_idx="0001" ;
      private string subGridwwp_mail_attachments_Class ;
      private string subGridwwp_mail_attachments_Linesclass ;
      private string ROClassString ;
      private string edtWWPMailAttachmentName_Jsonclick ;
      private string edtWWPMailAttachmentFile_Jsonclick ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string subGridwwp_mail_attachments_Header ;
      private DateTime Z133WWPMailCreated ;
      private DateTime Z134WWPMailScheduled ;
      private DateTime Z128WWPMailProcessed ;
      private DateTime A133WWPMailCreated ;
      private DateTime A134WWPMailScheduled ;
      private DateTime A128WWPMailProcessed ;
      private DateTime A66WWPNotificationCreated ;
      private DateTime Z66WWPNotificationCreated ;
      private DateTime i133WWPMailCreated ;
      private DateTime i134WWPMailScheduled ;
      private DateTime ZZ133WWPMailCreated ;
      private DateTime ZZ134WWPMailScheduled ;
      private DateTime ZZ128WWPMailProcessed ;
      private DateTime ZZ66WWPNotificationCreated ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n64WWPNotificationId ;
      private bool wbErr ;
      private bool bGXsfl_113_Refreshing=false ;
      private bool n128WWPMailProcessed ;
      private bool n112WWPMailTo ;
      private bool n125WWPMailCC ;
      private bool n126WWPMailBCC ;
      private bool n129WWPMailDetail ;
      private bool Gx_longc ;
      private string A103WWPMailBody ;
      private string A112WWPMailTo ;
      private string A125WWPMailCC ;
      private string A126WWPMailBCC ;
      private string A113WWPMailSenderAddress ;
      private string A114WWPMailSenderName ;
      private string A129WWPMailDetail ;
      private string A127WWPMailAttachmentFile ;
      private string Z103WWPMailBody ;
      private string Z112WWPMailTo ;
      private string Z125WWPMailCC ;
      private string Z126WWPMailBCC ;
      private string Z113WWPMailSenderAddress ;
      private string Z114WWPMailSenderName ;
      private string Z129WWPMailDetail ;
      private string Z127WWPMailAttachmentFile ;
      private string ZZ103WWPMailBody ;
      private string ZZ112WWPMailTo ;
      private string ZZ125WWPMailCC ;
      private string ZZ126WWPMailBCC ;
      private string ZZ113WWPMailSenderAddress ;
      private string ZZ114WWPMailSenderName ;
      private string ZZ129WWPMailDetail ;
      private string Z111WWPMailSubject ;
      private string Z135WWPMailAttachmentName ;
      private string A111WWPMailSubject ;
      private string A135WWPMailAttachmentName ;
      private string ZZ111WWPMailSubject ;
      private GXWebGrid Gridwwp_mail_attachmentsContainer ;
      private GXWebRow Gridwwp_mail_attachmentsRow ;
      private GXWebColumn Gridwwp_mail_attachmentsColumn ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCombobox cmbWWPMailStatus ;
      private IDataStoreProvider pr_default ;
      private long[] T000F7_A122WWPMailId ;
      private string[] T000F7_A111WWPMailSubject ;
      private string[] T000F7_A103WWPMailBody ;
      private string[] T000F7_A112WWPMailTo ;
      private bool[] T000F7_n112WWPMailTo ;
      private string[] T000F7_A125WWPMailCC ;
      private bool[] T000F7_n125WWPMailCC ;
      private string[] T000F7_A126WWPMailBCC ;
      private bool[] T000F7_n126WWPMailBCC ;
      private string[] T000F7_A113WWPMailSenderAddress ;
      private string[] T000F7_A114WWPMailSenderName ;
      private short[] T000F7_A123WWPMailStatus ;
      private DateTime[] T000F7_A133WWPMailCreated ;
      private DateTime[] T000F7_A134WWPMailScheduled ;
      private DateTime[] T000F7_A128WWPMailProcessed ;
      private bool[] T000F7_n128WWPMailProcessed ;
      private string[] T000F7_A129WWPMailDetail ;
      private bool[] T000F7_n129WWPMailDetail ;
      private DateTime[] T000F7_A66WWPNotificationCreated ;
      private long[] T000F7_A64WWPNotificationId ;
      private bool[] T000F7_n64WWPNotificationId ;
      private DateTime[] T000F6_A66WWPNotificationCreated ;
      private DateTime[] T000F8_A66WWPNotificationCreated ;
      private long[] T000F9_A122WWPMailId ;
      private long[] T000F5_A122WWPMailId ;
      private string[] T000F5_A111WWPMailSubject ;
      private string[] T000F5_A103WWPMailBody ;
      private string[] T000F5_A112WWPMailTo ;
      private bool[] T000F5_n112WWPMailTo ;
      private string[] T000F5_A125WWPMailCC ;
      private bool[] T000F5_n125WWPMailCC ;
      private string[] T000F5_A126WWPMailBCC ;
      private bool[] T000F5_n126WWPMailBCC ;
      private string[] T000F5_A113WWPMailSenderAddress ;
      private string[] T000F5_A114WWPMailSenderName ;
      private short[] T000F5_A123WWPMailStatus ;
      private DateTime[] T000F5_A133WWPMailCreated ;
      private DateTime[] T000F5_A134WWPMailScheduled ;
      private DateTime[] T000F5_A128WWPMailProcessed ;
      private bool[] T000F5_n128WWPMailProcessed ;
      private string[] T000F5_A129WWPMailDetail ;
      private bool[] T000F5_n129WWPMailDetail ;
      private long[] T000F5_A64WWPNotificationId ;
      private bool[] T000F5_n64WWPNotificationId ;
      private long[] T000F10_A122WWPMailId ;
      private long[] T000F11_A122WWPMailId ;
      private long[] T000F4_A122WWPMailId ;
      private string[] T000F4_A111WWPMailSubject ;
      private string[] T000F4_A103WWPMailBody ;
      private string[] T000F4_A112WWPMailTo ;
      private bool[] T000F4_n112WWPMailTo ;
      private string[] T000F4_A125WWPMailCC ;
      private bool[] T000F4_n125WWPMailCC ;
      private string[] T000F4_A126WWPMailBCC ;
      private bool[] T000F4_n126WWPMailBCC ;
      private string[] T000F4_A113WWPMailSenderAddress ;
      private string[] T000F4_A114WWPMailSenderName ;
      private short[] T000F4_A123WWPMailStatus ;
      private DateTime[] T000F4_A133WWPMailCreated ;
      private DateTime[] T000F4_A134WWPMailScheduled ;
      private DateTime[] T000F4_A128WWPMailProcessed ;
      private bool[] T000F4_n128WWPMailProcessed ;
      private string[] T000F4_A129WWPMailDetail ;
      private bool[] T000F4_n129WWPMailDetail ;
      private long[] T000F4_A64WWPNotificationId ;
      private bool[] T000F4_n64WWPNotificationId ;
      private long[] T000F13_A122WWPMailId ;
      private DateTime[] T000F16_A66WWPNotificationCreated ;
      private long[] T000F17_A122WWPMailId ;
      private long[] T000F18_A122WWPMailId ;
      private string[] T000F18_A135WWPMailAttachmentName ;
      private string[] T000F18_A127WWPMailAttachmentFile ;
      private long[] T000F19_A122WWPMailId ;
      private string[] T000F19_A135WWPMailAttachmentName ;
      private long[] T000F3_A122WWPMailId ;
      private string[] T000F3_A135WWPMailAttachmentName ;
      private string[] T000F3_A127WWPMailAttachmentFile ;
      private long[] T000F2_A122WWPMailId ;
      private string[] T000F2_A135WWPMailAttachmentName ;
      private string[] T000F2_A127WWPMailAttachmentFile ;
      private long[] T000F23_A122WWPMailId ;
      private string[] T000F23_A135WWPMailAttachmentName ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_mail__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mail__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[18])
       ,new UpdateCursor(def[19])
       ,new UpdateCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000F7;
        prmT000F7 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F6;
        prmT000F6 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000F8;
        prmT000F8 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000F9;
        prmT000F9 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F5;
        prmT000F5 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F10;
        prmT000F10 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F11;
        prmT000F11 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F4;
        prmT000F4 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F12;
        prmT000F12 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000F13;
        prmT000F13 = new Object[] {
        };
        Object[] prmT000F14;
        prmT000F14 = new Object[] {
        new ParDef("WWPMailSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTo",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailBCC",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPMailSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailStatus",GXType.Int16,4,0) ,
        new ParDef("WWPMailCreated",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailScheduled",GXType.DateTime2,10,12) ,
        new ParDef("WWPMailProcessed",GXType.DateTime2,10,12){Nullable=true} ,
        new ParDef("WWPMailDetail",GXType.LongVarChar,2097152,0){Nullable=true} ,
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F15;
        prmT000F15 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F17;
        prmT000F17 = new Object[] {
        };
        Object[] prmT000F18;
        prmT000F18 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F19;
        prmT000F19 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F3;
        prmT000F3 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F2;
        prmT000F2 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F20;
        prmT000F20 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0)
        };
        Object[] prmT000F21;
        prmT000F21 = new Object[] {
        new ParDef("WWPMailAttachmentFile",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F22;
        prmT000F22 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0) ,
        new ParDef("WWPMailAttachmentName",GXType.VarChar,40,0)
        };
        Object[] prmT000F23;
        prmT000F23 = new Object[] {
        new ParDef("WWPMailId",GXType.Int64,10,0)
        };
        Object[] prmT000F16;
        prmT000F16 = new Object[] {
        new ParDef("WWPNotificationId",GXType.Int64,10,0){Nullable=true}
        };
        def= new CursorDef[] {
            new CursorDef("T000F2", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName  FOR UPDATE OF WWP_MailAttachments NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F3", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F4", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId  FOR UPDATE OF WWP_Mail NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000F4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F5", "SELECT WWPMailId, WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F6", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F7", "SELECT TM1.WWPMailId, TM1.WWPMailSubject, TM1.WWPMailBody, TM1.WWPMailTo, TM1.WWPMailCC, TM1.WWPMailBCC, TM1.WWPMailSenderAddress, TM1.WWPMailSenderName, TM1.WWPMailStatus, TM1.WWPMailCreated, TM1.WWPMailScheduled, TM1.WWPMailProcessed, TM1.WWPMailDetail, T2.WWPNotificationCreated, TM1.WWPNotificationId FROM (WWP_Mail TM1 LEFT JOIN WWP_Notification T2 ON T2.WWPNotificationId = TM1.WWPNotificationId) WHERE TM1.WWPMailId = :WWPMailId ORDER BY TM1.WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F8", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F9", "SELECT WWPMailId FROM WWP_Mail WHERE WWPMailId = :WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F10", "SELECT WWPMailId FROM WWP_Mail WHERE ( WWPMailId > :WWPMailId) ORDER BY WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F10,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F11", "SELECT WWPMailId FROM WWP_Mail WHERE ( WWPMailId < :WWPMailId) ORDER BY WWPMailId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F11,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000F12", "SAVEPOINT gxupdate;INSERT INTO WWP_Mail(WWPMailSubject, WWPMailBody, WWPMailTo, WWPMailCC, WWPMailBCC, WWPMailSenderAddress, WWPMailSenderName, WWPMailStatus, WWPMailCreated, WWPMailScheduled, WWPMailProcessed, WWPMailDetail, WWPNotificationId) VALUES(:WWPMailSubject, :WWPMailBody, :WWPMailTo, :WWPMailCC, :WWPMailBCC, :WWPMailSenderAddress, :WWPMailSenderName, :WWPMailStatus, :WWPMailCreated, :WWPMailScheduled, :WWPMailProcessed, :WWPMailDetail, :WWPNotificationId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F12)
           ,new CursorDef("T000F13", "SELECT currval('WWPMailId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F13,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F14", "SAVEPOINT gxupdate;UPDATE WWP_Mail SET WWPMailSubject=:WWPMailSubject, WWPMailBody=:WWPMailBody, WWPMailTo=:WWPMailTo, WWPMailCC=:WWPMailCC, WWPMailBCC=:WWPMailBCC, WWPMailSenderAddress=:WWPMailSenderAddress, WWPMailSenderName=:WWPMailSenderName, WWPMailStatus=:WWPMailStatus, WWPMailCreated=:WWPMailCreated, WWPMailScheduled=:WWPMailScheduled, WWPMailProcessed=:WWPMailProcessed, WWPMailDetail=:WWPMailDetail, WWPNotificationId=:WWPNotificationId  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F14)
           ,new CursorDef("T000F15", "SAVEPOINT gxupdate;DELETE FROM WWP_Mail  WHERE WWPMailId = :WWPMailId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F15)
           ,new CursorDef("T000F16", "SELECT WWPNotificationCreated FROM WWP_Notification WHERE WWPNotificationId = :WWPNotificationId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F16,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F17", "SELECT WWPMailId FROM WWP_Mail ORDER BY WWPMailId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F17,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F18", "SELECT WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId and WWPMailAttachmentName = ( :WWPMailAttachmentName) ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F18,11, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F19", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000F20", "SAVEPOINT gxupdate;INSERT INTO WWP_MailAttachments(WWPMailId, WWPMailAttachmentName, WWPMailAttachmentFile) VALUES(:WWPMailId, :WWPMailAttachmentName, :WWPMailAttachmentFile);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000F20)
           ,new CursorDef("T000F21", "SAVEPOINT gxupdate;UPDATE WWP_MailAttachments SET WWPMailAttachmentFile=:WWPMailAttachmentFile  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F21)
           ,new CursorDef("T000F22", "SAVEPOINT gxupdate;DELETE FROM WWP_MailAttachments  WHERE WWPMailId = :WWPMailId AND WWPMailAttachmentName = :WWPMailAttachmentName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000F22)
           ,new CursorDef("T000F23", "SELECT WWPMailId, WWPMailAttachmentName FROM WWP_MailAttachments WHERE WWPMailId = :WWPMailId ORDER BY WWPMailId, WWPMailAttachmentName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000F23,11, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 2 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 3 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((long[]) buf[18])[0] = rslt.getLong(14);
              ((bool[]) buf[19])[0] = rslt.wasNull(14);
              return;
           case 4 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((bool[]) buf[4])[0] = rslt.wasNull(4);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(5);
              ((bool[]) buf[6])[0] = rslt.wasNull(5);
              ((string[]) buf[7])[0] = rslt.getLongVarchar(6);
              ((bool[]) buf[8])[0] = rslt.wasNull(6);
              ((string[]) buf[9])[0] = rslt.getLongVarchar(7);
              ((string[]) buf[10])[0] = rslt.getLongVarchar(8);
              ((short[]) buf[11])[0] = rslt.getShort(9);
              ((DateTime[]) buf[12])[0] = rslt.getGXDateTime(10, true);
              ((DateTime[]) buf[13])[0] = rslt.getGXDateTime(11, true);
              ((DateTime[]) buf[14])[0] = rslt.getGXDateTime(12, true);
              ((bool[]) buf[15])[0] = rslt.wasNull(12);
              ((string[]) buf[16])[0] = rslt.getLongVarchar(13);
              ((bool[]) buf[17])[0] = rslt.wasNull(13);
              ((DateTime[]) buf[18])[0] = rslt.getGXDateTime(14, true);
              ((long[]) buf[19])[0] = rslt.getLong(15);
              ((bool[]) buf[20])[0] = rslt.wasNull(15);
              return;
           case 6 :
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
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
              ((DateTime[]) buf[0])[0] = rslt.getGXDateTime(1, true);
              return;
           case 15 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 16 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getLongVarchar(3);
              return;
           case 17 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              return;
     }
  }

}

}
