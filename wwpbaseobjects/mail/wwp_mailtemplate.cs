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
   public class wwp_mailtemplate : GXDataArea
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
            Form.Meta.addItem("description", "Mail Template", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_mailtemplate( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_mailtemplate( IGxContext context )
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
            return "wwpmailtemplate_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Mail Template", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateName_Internalname, "Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateName_Internalname, A130WWPMailTemplateName, StringUtil.RTrim( context.localUtil.Format( A130WWPMailTemplateName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateName_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateDescription_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateDescription_Internalname, "Description", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateDescription_Internalname, A131WWPMailTemplateDescription, StringUtil.RTrim( context.localUtil.Format( A131WWPMailTemplateDescription, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateDescription_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateDescription_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSubject_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSubject_Internalname, "Subject", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPMailTemplateSubject_Internalname, A132WWPMailTemplateSubject, StringUtil.RTrim( context.localUtil.Format( A132WWPMailTemplateSubject, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPMailTemplateSubject_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPMailTemplateSubject_Enabled, 0, "text", "", 80, "chr", 1, "row", 80, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateBody_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateBody_Internalname, "Body", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateBody_Internalname, A115WWPMailTemplateBody, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 1, 1, edtWWPMailTemplateBody_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "GeneXus\\Html", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderAddress_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderAddress_Internalname, "Sender Address", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderAddress_Internalname, A116WWPMailTemplateSenderAddress, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", 0, 1, edtWWPMailTemplateSenderAddress_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPMailTemplateSenderName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPMailTemplateSenderName_Internalname, "Sender Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPMailTemplateSenderName_Internalname, A117WWPMailTemplateSenderName, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", 0, 1, edtWWPMailTemplateSenderName_Enabled, 0, 80, "chr", 10, "row", 0, StyleString, ClassString, "", "", "2097152", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 66,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 68,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Mail\\WWP_MailTemplate.htm");
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
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E110E2 ();
         context.wbGlbDoneStart = 1;
         assign_properties_default( ) ;
         if ( AnyError == 0 )
         {
            if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
            {
               /* Read saved SDTs. */
               /* Read saved values. */
               Z130WWPMailTemplateName = cgiGet( "Z130WWPMailTemplateName");
               Z131WWPMailTemplateDescription = cgiGet( "Z131WWPMailTemplateDescription");
               Z132WWPMailTemplateSubject = cgiGet( "Z132WWPMailTemplateSubject");
               IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
               IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
               Gx_mode = cgiGet( "Mode");
               /* Read variables values. */
               A130WWPMailTemplateName = cgiGet( edtWWPMailTemplateName_Internalname);
               AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
               A131WWPMailTemplateDescription = cgiGet( edtWWPMailTemplateDescription_Internalname);
               AssignAttri("", false, "A131WWPMailTemplateDescription", A131WWPMailTemplateDescription);
               A132WWPMailTemplateSubject = cgiGet( edtWWPMailTemplateSubject_Internalname);
               AssignAttri("", false, "A132WWPMailTemplateSubject", A132WWPMailTemplateSubject);
               A115WWPMailTemplateBody = cgiGet( edtWWPMailTemplateBody_Internalname);
               AssignAttri("", false, "A115WWPMailTemplateBody", A115WWPMailTemplateBody);
               A116WWPMailTemplateSenderAddress = cgiGet( edtWWPMailTemplateSenderAddress_Internalname);
               AssignAttri("", false, "A116WWPMailTemplateSenderAddress", A116WWPMailTemplateSenderAddress);
               A117WWPMailTemplateSenderName = cgiGet( edtWWPMailTemplateSenderName_Internalname);
               AssignAttri("", false, "A117WWPMailTemplateSenderName", A117WWPMailTemplateSenderName);
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
                  A130WWPMailTemplateName = GetPar( "WWPMailTemplateName");
                  AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
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
                           E110E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "AFTER TRN") == 0 )
                        {
                           context.wbHandled = 1;
                           dynload_actions( ) ;
                           /* Execute user event: After Trn */
                           E120E2 ();
                        }
                        else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
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
            /* Execute user event: After Trn */
            E120E2 ();
            trnEnded = 0;
            standaloneNotModal( ) ;
            standaloneModal( ) ;
            if ( IsIns( )  )
            {
               /* Clear variables for new insertion. */
               InitAll0E14( ) ;
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
         DisableAttributes0E14( ) ;
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

      protected void ResetCaption0E0( )
      {
      }

      protected void E110E2( )
      {
         /* Start Routine */
         returnInSub = false;
      }

      protected void E120E2( )
      {
         /* After Trn Routine */
         returnInSub = false;
      }

      protected void ZM0E14( short GX_JID )
      {
         if ( ( GX_JID == 1 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z131WWPMailTemplateDescription = T000E3_A131WWPMailTemplateDescription[0];
               Z132WWPMailTemplateSubject = T000E3_A132WWPMailTemplateSubject[0];
            }
            else
            {
               Z131WWPMailTemplateDescription = A131WWPMailTemplateDescription;
               Z132WWPMailTemplateSubject = A132WWPMailTemplateSubject;
            }
         }
         if ( GX_JID == -1 )
         {
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
            Z131WWPMailTemplateDescription = A131WWPMailTemplateDescription;
            Z132WWPMailTemplateSubject = A132WWPMailTemplateSubject;
            Z115WWPMailTemplateBody = A115WWPMailTemplateBody;
            Z116WWPMailTemplateSenderAddress = A116WWPMailTemplateSenderAddress;
            Z117WWPMailTemplateSenderName = A117WWPMailTemplateSenderName;
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

      protected void Load0E14( )
      {
         /* Using cursor T000E4 */
         pr_default.execute(2, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound14 = 1;
            A131WWPMailTemplateDescription = T000E4_A131WWPMailTemplateDescription[0];
            AssignAttri("", false, "A131WWPMailTemplateDescription", A131WWPMailTemplateDescription);
            A132WWPMailTemplateSubject = T000E4_A132WWPMailTemplateSubject[0];
            AssignAttri("", false, "A132WWPMailTemplateSubject", A132WWPMailTemplateSubject);
            A115WWPMailTemplateBody = T000E4_A115WWPMailTemplateBody[0];
            AssignAttri("", false, "A115WWPMailTemplateBody", A115WWPMailTemplateBody);
            A116WWPMailTemplateSenderAddress = T000E4_A116WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A116WWPMailTemplateSenderAddress", A116WWPMailTemplateSenderAddress);
            A117WWPMailTemplateSenderName = T000E4_A117WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A117WWPMailTemplateSenderName", A117WWPMailTemplateSenderName);
            ZM0E14( -1) ;
         }
         pr_default.close(2);
         OnLoadActions0E14( ) ;
      }

      protected void OnLoadActions0E14( )
      {
      }

      protected void CheckExtendedTable0E14( )
      {
         nIsDirty_14 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
      }

      protected void CloseExtendedTableCursors0E14( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey0E14( )
      {
         /* Using cursor T000E5 */
         pr_default.execute(3, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound14 = 1;
         }
         else
         {
            RcdFound14 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000E3 */
         pr_default.execute(1, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0E14( 1) ;
            RcdFound14 = 1;
            A130WWPMailTemplateName = T000E3_A130WWPMailTemplateName[0];
            AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
            A131WWPMailTemplateDescription = T000E3_A131WWPMailTemplateDescription[0];
            AssignAttri("", false, "A131WWPMailTemplateDescription", A131WWPMailTemplateDescription);
            A132WWPMailTemplateSubject = T000E3_A132WWPMailTemplateSubject[0];
            AssignAttri("", false, "A132WWPMailTemplateSubject", A132WWPMailTemplateSubject);
            A115WWPMailTemplateBody = T000E3_A115WWPMailTemplateBody[0];
            AssignAttri("", false, "A115WWPMailTemplateBody", A115WWPMailTemplateBody);
            A116WWPMailTemplateSenderAddress = T000E3_A116WWPMailTemplateSenderAddress[0];
            AssignAttri("", false, "A116WWPMailTemplateSenderAddress", A116WWPMailTemplateSenderAddress);
            A117WWPMailTemplateSenderName = T000E3_A117WWPMailTemplateSenderName[0];
            AssignAttri("", false, "A117WWPMailTemplateSenderName", A117WWPMailTemplateSenderName);
            Z130WWPMailTemplateName = A130WWPMailTemplateName;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0E14( ) ;
            if ( AnyError == 1 )
            {
               RcdFound14 = 0;
               InitializeNonKey0E14( ) ;
            }
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound14 = 0;
            InitializeNonKey0E14( ) ;
            sMode14 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode14;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0E14( ) ;
         if ( RcdFound14 == 0 )
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
         RcdFound14 = 0;
         /* Using cursor T000E6 */
         pr_default.execute(4, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000E6_A130WWPMailTemplateName[0], A130WWPMailTemplateName) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T000E6_A130WWPMailTemplateName[0], A130WWPMailTemplateName) > 0 ) ) )
            {
               A130WWPMailTemplateName = T000E6_A130WWPMailTemplateName[0];
               AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
               RcdFound14 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound14 = 0;
         /* Using cursor T000E7 */
         pr_default.execute(5, new Object[] {A130WWPMailTemplateName});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000E7_A130WWPMailTemplateName[0], A130WWPMailTemplateName) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T000E7_A130WWPMailTemplateName[0], A130WWPMailTemplateName) < 0 ) ) )
            {
               A130WWPMailTemplateName = T000E7_A130WWPMailTemplateName[0];
               AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
               RcdFound14 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0E14( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0E14( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound14 == 1 )
            {
               if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
               {
                  A130WWPMailTemplateName = Z130WWPMailTemplateName;
                  AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPMAILTEMPLATENAME");
                  AnyError = 1;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0E14( ) ;
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPMailTemplateName_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0E14( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPMAILTEMPLATENAME");
                     AnyError = 1;
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPMailTemplateName_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0E14( ) ;
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
         if ( StringUtil.StrCmp(A130WWPMailTemplateName, Z130WWPMailTemplateName) != 0 )
         {
            A130WWPMailTemplateName = Z130WWPMailTemplateName;
            AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPMAILTEMPLATENAME");
            AnyError = 1;
            GX_FocusControl = edtWWPMailTemplateName_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E14( ) ;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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
         ScanStart0E14( ) ;
         if ( RcdFound14 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound14 != 0 )
            {
               ScanNext0E14( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0E14( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0E14( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000E2 */
            pr_default.execute(0, new Object[] {A130WWPMailTemplateName});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z131WWPMailTemplateDescription, T000E2_A131WWPMailTemplateDescription[0]) != 0 ) || ( StringUtil.StrCmp(Z132WWPMailTemplateSubject, T000E2_A132WWPMailTemplateSubject[0]) != 0 ) )
            {
               if ( StringUtil.StrCmp(Z131WWPMailTemplateDescription, T000E2_A131WWPMailTemplateDescription[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateDescription");
                  GXUtil.WriteLogRaw("Old: ",Z131WWPMailTemplateDescription);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A131WWPMailTemplateDescription[0]);
               }
               if ( StringUtil.StrCmp(Z132WWPMailTemplateSubject, T000E2_A132WWPMailTemplateSubject[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.mail.wwp_mailtemplate:[seudo value changed for attri]"+"WWPMailTemplateSubject");
                  GXUtil.WriteLogRaw("Old: ",Z132WWPMailTemplateSubject);
                  GXUtil.WriteLogRaw("Current: ",T000E2_A132WWPMailTemplateSubject[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_MailTemplate"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0E14( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0E14( 0) ;
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E8 */
                     pr_default.execute(6, new Object[] {A130WWPMailTemplateName, A131WWPMailTemplateDescription, A132WWPMailTemplateSubject, A115WWPMailTemplateBody, A116WWPMailTemplateSenderAddress, A117WWPMailTemplateSenderName});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(6) == 1) )
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
                           ResetCaption0E0( ) ;
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
               Load0E14( ) ;
            }
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void Update0E14( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0E14( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0E14( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000E9 */
                     pr_default.execute(7, new Object[] {A131WWPMailTemplateDescription, A132WWPMailTemplateSubject, A115WWPMailTemplateBody, A116WWPMailTemplateSenderAddress, A117WWPMailTemplateSenderName, A130WWPMailTemplateName});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_MailTemplate"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0E14( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0E0( ) ;
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
            EndLevel0E14( ) ;
         }
         CloseExtendedTableCursors0E14( ) ;
      }

      protected void DeferredUpdate0E14( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpmailtemplate_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0E14( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0E14( ) ;
            AfterConfirm0E14( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0E14( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000E10 */
                  pr_default.execute(8, new Object[] {A130WWPMailTemplateName});
                  pr_default.close(8);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_MailTemplate");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound14 == 0 )
                        {
                           InitAll0E14( ) ;
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
                        ResetCaption0E0( ) ;
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
         sMode14 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0E14( ) ;
         Gx_mode = sMode14;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0E14( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
      }

      protected void EndLevel0E14( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0E14( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0E0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.mail.wwp_mailtemplate",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0E14( )
      {
         /* Using cursor T000E11 */
         pr_default.execute(9);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A130WWPMailTemplateName = T000E11_A130WWPMailTemplateName[0];
            AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0E14( )
      {
         /* Scan next routine */
         pr_default.readNext(9);
         RcdFound14 = 0;
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound14 = 1;
            A130WWPMailTemplateName = T000E11_A130WWPMailTemplateName[0];
            AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
         }
      }

      protected void ScanEnd0E14( )
      {
         pr_default.close(9);
      }

      protected void AfterConfirm0E14( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0E14( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate0E14( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0E14( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0E14( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0E14( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0E14( )
      {
         edtWWPMailTemplateName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateName_Enabled), 5, 0), true);
         edtWWPMailTemplateDescription_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateDescription_Enabled), 5, 0), true);
         edtWWPMailTemplateSubject_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSubject_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSubject_Enabled), 5, 0), true);
         edtWWPMailTemplateBody_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateBody_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateBody_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderAddress_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderAddress_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderAddress_Enabled), 5, 0), true);
         edtWWPMailTemplateSenderName_Enabled = 0;
         AssignProp("", false, edtWWPMailTemplateSenderName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPMailTemplateSenderName_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0E14( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0E0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z130WWPMailTemplateName", Z130WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z131WWPMailTemplateDescription", Z131WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z132WWPMailTemplateSubject", Z132WWPMailTemplateSubject);
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
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
         return formatLink("wwpbaseobjects.mail.wwp_mailtemplate.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Mail.WWP_MailTemplate" ;
      }

      public override string GetPgmdesc( )
      {
         return "Mail Template" ;
      }

      protected void InitializeNonKey0E14( )
      {
         A131WWPMailTemplateDescription = "";
         AssignAttri("", false, "A131WWPMailTemplateDescription", A131WWPMailTemplateDescription);
         A132WWPMailTemplateSubject = "";
         AssignAttri("", false, "A132WWPMailTemplateSubject", A132WWPMailTemplateSubject);
         A115WWPMailTemplateBody = "";
         AssignAttri("", false, "A115WWPMailTemplateBody", A115WWPMailTemplateBody);
         A116WWPMailTemplateSenderAddress = "";
         AssignAttri("", false, "A116WWPMailTemplateSenderAddress", A116WWPMailTemplateSenderAddress);
         A117WWPMailTemplateSenderName = "";
         AssignAttri("", false, "A117WWPMailTemplateSenderName", A117WWPMailTemplateSenderName);
         Z131WWPMailTemplateDescription = "";
         Z132WWPMailTemplateSubject = "";
      }

      protected void InitAll0E14( )
      {
         A130WWPMailTemplateName = "";
         AssignAttri("", false, "A130WWPMailTemplateName", A130WWPMailTemplateName);
         InitializeNonKey0E14( ) ;
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382812672", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/mail/wwp_mailtemplate.js", "?202382812673", false, true);
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
         edtWWPMailTemplateName_Internalname = "WWPMAILTEMPLATENAME";
         edtWWPMailTemplateDescription_Internalname = "WWPMAILTEMPLATEDESCRIPTION";
         edtWWPMailTemplateSubject_Internalname = "WWPMAILTEMPLATESUBJECT";
         edtWWPMailTemplateBody_Internalname = "WWPMAILTEMPLATEBODY";
         edtWWPMailTemplateSenderAddress_Internalname = "WWPMAILTEMPLATESENDERADDRESS";
         edtWWPMailTemplateSenderName_Internalname = "WWPMAILTEMPLATESENDERNAME";
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
         Form.Caption = "Mail Template";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPMailTemplateSenderName_Enabled = 1;
         edtWWPMailTemplateSenderAddress_Enabled = 1;
         edtWWPMailTemplateBody_Enabled = 1;
         edtWWPMailTemplateSubject_Jsonclick = "";
         edtWWPMailTemplateSubject_Enabled = 1;
         edtWWPMailTemplateDescription_Jsonclick = "";
         edtWWPMailTemplateDescription_Enabled = 1;
         edtWWPMailTemplateName_Jsonclick = "";
         edtWWPMailTemplateName_Enabled = 1;
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
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPMailTemplateDescription_Internalname;
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

      public void Valid_Wwpmailtemplatename( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A131WWPMailTemplateDescription", A131WWPMailTemplateDescription);
         AssignAttri("", false, "A132WWPMailTemplateSubject", A132WWPMailTemplateSubject);
         AssignAttri("", false, "A115WWPMailTemplateBody", A115WWPMailTemplateBody);
         AssignAttri("", false, "A116WWPMailTemplateSenderAddress", A116WWPMailTemplateSenderAddress);
         AssignAttri("", false, "A117WWPMailTemplateSenderName", A117WWPMailTemplateSenderName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z130WWPMailTemplateName", Z130WWPMailTemplateName);
         GxWebStd.gx_hidden_field( context, "Z131WWPMailTemplateDescription", Z131WWPMailTemplateDescription);
         GxWebStd.gx_hidden_field( context, "Z132WWPMailTemplateSubject", Z132WWPMailTemplateSubject);
         GxWebStd.gx_hidden_field( context, "Z115WWPMailTemplateBody", Z115WWPMailTemplateBody);
         GxWebStd.gx_hidden_field( context, "Z116WWPMailTemplateSenderAddress", Z116WWPMailTemplateSenderAddress);
         GxWebStd.gx_hidden_field( context, "Z117WWPMailTemplateSenderName", Z117WWPMailTemplateSenderName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
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
         setEventMetadata("AFTER TRN","{handler:'E120E2',iparms:[]");
         setEventMetadata("AFTER TRN",",oparms:[]}");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME","{handler:'Valid_Wwpmailtemplatename',iparms:[{av:'A130WWPMailTemplateName',fld:'WWPMAILTEMPLATENAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'}]");
         setEventMetadata("VALID_WWPMAILTEMPLATENAME",",oparms:[{av:'A131WWPMailTemplateDescription',fld:'WWPMAILTEMPLATEDESCRIPTION',pic:''},{av:'A132WWPMailTemplateSubject',fld:'WWPMAILTEMPLATESUBJECT',pic:''},{av:'A115WWPMailTemplateBody',fld:'WWPMAILTEMPLATEBODY',pic:''},{av:'A116WWPMailTemplateSenderAddress',fld:'WWPMAILTEMPLATESENDERADDRESS',pic:''},{av:'A117WWPMailTemplateSenderName',fld:'WWPMAILTEMPLATESENDERNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z130WWPMailTemplateName'},{av:'Z131WWPMailTemplateDescription'},{av:'Z132WWPMailTemplateSubject'},{av:'Z115WWPMailTemplateBody'},{av:'Z116WWPMailTemplateSenderAddress'},{av:'Z117WWPMailTemplateSenderName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
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
         Z130WWPMailTemplateName = "";
         Z131WWPMailTemplateDescription = "";
         Z132WWPMailTemplateSubject = "";
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
         A130WWPMailTemplateName = "";
         A131WWPMailTemplateDescription = "";
         A132WWPMailTemplateSubject = "";
         A115WWPMailTemplateBody = "";
         A116WWPMailTemplateSenderAddress = "";
         A117WWPMailTemplateSenderName = "";
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
         Z115WWPMailTemplateBody = "";
         Z116WWPMailTemplateSenderAddress = "";
         Z117WWPMailTemplateSenderName = "";
         T000E4_A130WWPMailTemplateName = new string[] {""} ;
         T000E4_A131WWPMailTemplateDescription = new string[] {""} ;
         T000E4_A132WWPMailTemplateSubject = new string[] {""} ;
         T000E4_A115WWPMailTemplateBody = new string[] {""} ;
         T000E4_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         T000E4_A117WWPMailTemplateSenderName = new string[] {""} ;
         T000E5_A130WWPMailTemplateName = new string[] {""} ;
         T000E3_A130WWPMailTemplateName = new string[] {""} ;
         T000E3_A131WWPMailTemplateDescription = new string[] {""} ;
         T000E3_A132WWPMailTemplateSubject = new string[] {""} ;
         T000E3_A115WWPMailTemplateBody = new string[] {""} ;
         T000E3_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         T000E3_A117WWPMailTemplateSenderName = new string[] {""} ;
         sMode14 = "";
         T000E6_A130WWPMailTemplateName = new string[] {""} ;
         T000E7_A130WWPMailTemplateName = new string[] {""} ;
         T000E2_A130WWPMailTemplateName = new string[] {""} ;
         T000E2_A131WWPMailTemplateDescription = new string[] {""} ;
         T000E2_A132WWPMailTemplateSubject = new string[] {""} ;
         T000E2_A115WWPMailTemplateBody = new string[] {""} ;
         T000E2_A116WWPMailTemplateSenderAddress = new string[] {""} ;
         T000E2_A117WWPMailTemplateSenderName = new string[] {""} ;
         T000E11_A130WWPMailTemplateName = new string[] {""} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         ZZ130WWPMailTemplateName = "";
         ZZ131WWPMailTemplateDescription = "";
         ZZ132WWPMailTemplateSubject = "";
         ZZ115WWPMailTemplateBody = "";
         ZZ116WWPMailTemplateSenderAddress = "";
         ZZ117WWPMailTemplateSenderName = "";
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.mail.wwp_mailtemplate__default(),
            new Object[][] {
                new Object[] {
               T000E2_A130WWPMailTemplateName, T000E2_A131WWPMailTemplateDescription, T000E2_A132WWPMailTemplateSubject, T000E2_A115WWPMailTemplateBody, T000E2_A116WWPMailTemplateSenderAddress, T000E2_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               T000E3_A130WWPMailTemplateName, T000E3_A131WWPMailTemplateDescription, T000E3_A132WWPMailTemplateSubject, T000E3_A115WWPMailTemplateBody, T000E3_A116WWPMailTemplateSenderAddress, T000E3_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               T000E4_A130WWPMailTemplateName, T000E4_A131WWPMailTemplateDescription, T000E4_A132WWPMailTemplateSubject, T000E4_A115WWPMailTemplateBody, T000E4_A116WWPMailTemplateSenderAddress, T000E4_A117WWPMailTemplateSenderName
               }
               , new Object[] {
               T000E5_A130WWPMailTemplateName
               }
               , new Object[] {
               T000E6_A130WWPMailTemplateName
               }
               , new Object[] {
               T000E7_A130WWPMailTemplateName
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000E11_A130WWPMailTemplateName
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
      private short RcdFound14 ;
      private short nIsDirty_14 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPMailTemplateName_Enabled ;
      private int edtWWPMailTemplateDescription_Enabled ;
      private int edtWWPMailTemplateSubject_Enabled ;
      private int edtWWPMailTemplateBody_Enabled ;
      private int edtWWPMailTemplateSenderAddress_Enabled ;
      private int edtWWPMailTemplateSenderName_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPMailTemplateName_Internalname ;
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
      private string edtWWPMailTemplateName_Jsonclick ;
      private string edtWWPMailTemplateDescription_Internalname ;
      private string edtWWPMailTemplateDescription_Jsonclick ;
      private string edtWWPMailTemplateSubject_Internalname ;
      private string edtWWPMailTemplateSubject_Jsonclick ;
      private string edtWWPMailTemplateBody_Internalname ;
      private string edtWWPMailTemplateSenderAddress_Internalname ;
      private string edtWWPMailTemplateSenderName_Internalname ;
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
      private string sMode14 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool returnInSub ;
      private string A115WWPMailTemplateBody ;
      private string A116WWPMailTemplateSenderAddress ;
      private string A117WWPMailTemplateSenderName ;
      private string Z115WWPMailTemplateBody ;
      private string Z116WWPMailTemplateSenderAddress ;
      private string Z117WWPMailTemplateSenderName ;
      private string ZZ115WWPMailTemplateBody ;
      private string ZZ116WWPMailTemplateSenderAddress ;
      private string ZZ117WWPMailTemplateSenderName ;
      private string Z130WWPMailTemplateName ;
      private string Z131WWPMailTemplateDescription ;
      private string Z132WWPMailTemplateSubject ;
      private string A130WWPMailTemplateName ;
      private string A131WWPMailTemplateDescription ;
      private string A132WWPMailTemplateSubject ;
      private string ZZ130WWPMailTemplateName ;
      private string ZZ131WWPMailTemplateDescription ;
      private string ZZ132WWPMailTemplateSubject ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000E4_A130WWPMailTemplateName ;
      private string[] T000E4_A131WWPMailTemplateDescription ;
      private string[] T000E4_A132WWPMailTemplateSubject ;
      private string[] T000E4_A115WWPMailTemplateBody ;
      private string[] T000E4_A116WWPMailTemplateSenderAddress ;
      private string[] T000E4_A117WWPMailTemplateSenderName ;
      private string[] T000E5_A130WWPMailTemplateName ;
      private string[] T000E3_A130WWPMailTemplateName ;
      private string[] T000E3_A131WWPMailTemplateDescription ;
      private string[] T000E3_A132WWPMailTemplateSubject ;
      private string[] T000E3_A115WWPMailTemplateBody ;
      private string[] T000E3_A116WWPMailTemplateSenderAddress ;
      private string[] T000E3_A117WWPMailTemplateSenderName ;
      private string[] T000E6_A130WWPMailTemplateName ;
      private string[] T000E7_A130WWPMailTemplateName ;
      private string[] T000E2_A130WWPMailTemplateName ;
      private string[] T000E2_A131WWPMailTemplateDescription ;
      private string[] T000E2_A132WWPMailTemplateSubject ;
      private string[] T000E2_A115WWPMailTemplateBody ;
      private string[] T000E2_A116WWPMailTemplateSenderAddress ;
      private string[] T000E2_A117WWPMailTemplateSenderName ;
      private string[] T000E11_A130WWPMailTemplateName ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_mailtemplate__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_mailtemplate__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[6])
       ,new UpdateCursor(def[7])
       ,new UpdateCursor(def[8])
       ,new ForEachCursor(def[9])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000E4;
        prmT000E4 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E5;
        prmT000E5 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E3;
        prmT000E3 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E6;
        prmT000E6 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E7;
        prmT000E7 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E2;
        prmT000E2 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E8;
        prmT000E8 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0) ,
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0)
        };
        Object[] prmT000E9;
        prmT000E9 = new Object[] {
        new ParDef("WWPMailTemplateDescription",GXType.VarChar,100,0) ,
        new ParDef("WWPMailTemplateSubject",GXType.VarChar,80,0) ,
        new ParDef("WWPMailTemplateBody",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderAddress",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateSenderName",GXType.LongVarChar,2097152,0) ,
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E10;
        prmT000E10 = new Object[] {
        new ParDef("WWPMailTemplateName",GXType.VarChar,40,0)
        };
        Object[] prmT000E11;
        prmT000E11 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T000E2", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName  FOR UPDATE OF WWP_MailTemplate NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000E2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E3", "SELECT WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E4", "SELECT TM1.WWPMailTemplateName, TM1.WWPMailTemplateDescription, TM1.WWPMailTemplateSubject, TM1.WWPMailTemplateBody, TM1.WWPMailTemplateSenderAddress, TM1.WWPMailTemplateSenderName FROM WWP_MailTemplate TM1 WHERE TM1.WWPMailTemplateName = ( :WWPMailTemplateName) ORDER BY TM1.WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E4,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E5", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE WWPMailTemplateName = :WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000E6", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE ( WWPMailTemplateName > ( :WWPMailTemplateName)) ORDER BY WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E6,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E7", "SELECT WWPMailTemplateName FROM WWP_MailTemplate WHERE ( WWPMailTemplateName < ( :WWPMailTemplateName)) ORDER BY WWPMailTemplateName DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E7,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000E8", "SAVEPOINT gxupdate;INSERT INTO WWP_MailTemplate(WWPMailTemplateName, WWPMailTemplateDescription, WWPMailTemplateSubject, WWPMailTemplateBody, WWPMailTemplateSenderAddress, WWPMailTemplateSenderName) VALUES(:WWPMailTemplateName, :WWPMailTemplateDescription, :WWPMailTemplateSubject, :WWPMailTemplateBody, :WWPMailTemplateSenderAddress, :WWPMailTemplateSenderName);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT000E8)
           ,new CursorDef("T000E9", "SAVEPOINT gxupdate;UPDATE WWP_MailTemplate SET WWPMailTemplateDescription=:WWPMailTemplateDescription, WWPMailTemplateSubject=:WWPMailTemplateSubject, WWPMailTemplateBody=:WWPMailTemplateBody, WWPMailTemplateSenderAddress=:WWPMailTemplateSenderAddress, WWPMailTemplateSenderName=:WWPMailTemplateSenderName  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E9)
           ,new CursorDef("T000E10", "SAVEPOINT gxupdate;DELETE FROM WWP_MailTemplate  WHERE WWPMailTemplateName = :WWPMailTemplateName;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000E10)
           ,new CursorDef("T000E11", "SELECT WWPMailTemplateName FROM WWP_MailTemplate ORDER BY WWPMailTemplateName ",true, GxErrorMask.GX_NOMASK, false, this,prmT000E11,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getLongVarchar(4);
              ((string[]) buf[4])[0] = rslt.getLongVarchar(5);
              ((string[]) buf[5])[0] = rslt.getLongVarchar(6);
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 9 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
     }
  }

}

}
