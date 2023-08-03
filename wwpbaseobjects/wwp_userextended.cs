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
namespace GeneXus.Programs.wwpbaseobjects {
   public class wwp_userextended : GXDataArea
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
            Form.Meta.addItem("description", "Extended User from GAMUser", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_userextended( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_userextended( IGxContext context )
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
         chkWWPUserExtendedSMSNotif = new GXCheckbox();
         chkWWPUserExtendedMobileNotif = new GXCheckbox();
         chkWWPUserExtendedDesktopNotif = new GXCheckbox();
         chkWWPUserExtendedDeleted = new GXCheckbox();
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
            return "wwpuserextended_Execute" ;
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
         A54WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A54WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
         A55WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A55WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
         A56WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A56WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
         A59WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A59WWPUserExtendedDeleted));
         AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Extended User from GAMUser", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A49WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A49WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+imgWWPUserExtendedPhoto_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, "", "Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         ClassString = "ImageAttribute";
         StyleString = "";
         A52WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,39);\"", "", "", "", 0, A52WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "URL", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A52WWPUserExtendedPhoto)), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "IsBlob", StringUtil.BoolToStr( A52WWPUserExtendedPhoto_IsBlob), true);
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedName_Internalname, "Extended Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedName_Internalname, A58WWPUserExtendedName, StringUtil.RTrim( context.localUtil.Format( A58WWPUserExtendedName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A50WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A50WWPUserExtendedFullName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedPhone_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedPhone_Internalname, "Phone", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         if ( context.isSmartDevice( ) )
         {
            gxphoneLink = "tel:" + StringUtil.RTrim( A57WWPUserExtendedPhone);
         }
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 54,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedPhone_Internalname, StringUtil.RTrim( A57WWPUserExtendedPhone), StringUtil.RTrim( context.localUtil.Format( A57WWPUserExtendedPhone, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", gxphoneLink, "", "", "", edtWWPUserExtendedPhone_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedPhone_Enabled, 0, "tel", "", 20, "chr", 1, "row", 20, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Phone", "start", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmail_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmail_Internalname, "Email", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 59,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmail_Internalname, A51WWPUserExtendedEmail, StringUtil.RTrim( context.localUtil.Format( A51WWPUserExtendedEmail, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,59);\"", "'"+""+"'"+",false,"+"'"+""+"'", "mailto:"+A51WWPUserExtendedEmail, "", "", "", edtWWPUserExtendedEmail_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmail_Enabled, 0, "email", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXus\\Email", "start", true, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedEmaiNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedEmaiNotif_Internalname, "Email Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 64,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedEmaiNotif_Internalname, StringUtil.BoolToStr( A53WWPUserExtendedEmaiNotif), StringUtil.BoolToStr( A53WWPUserExtendedEmaiNotif), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,64);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedEmaiNotif_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedEmaiNotif_Enabled, 0, "text", "", 100, "chr", 1, "row", 100, 0, 0, 0, 0, 0, 0, true, "", "end", false, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedSMSNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedSMSNotif_Internalname, "SMS Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedSMSNotif_Internalname, StringUtil.BoolToStr( A54WWPUserExtendedSMSNotif), "", "SMS Notifications", 1, chkWWPUserExtendedSMSNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(69, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,69);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedMobileNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedMobileNotif_Internalname, "Mobile Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 74,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedMobileNotif_Internalname, StringUtil.BoolToStr( A55WWPUserExtendedMobileNotif), "", "Mobile Notifications", 1, chkWWPUserExtendedMobileNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(74, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,74);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDesktopNotif_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDesktopNotif_Internalname, "Destkop Notifications", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDesktopNotif_Internalname, StringUtil.BoolToStr( A56WWPUserExtendedDesktopNotif), "", "Destkop Notifications", 1, chkWWPUserExtendedDesktopNotif.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(79, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,79);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkWWPUserExtendedDeleted_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, chkWWPUserExtendedDeleted_Internalname, "Extended Deleted", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Check box */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 84,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_checkbox_ctrl( context, chkWWPUserExtendedDeleted_Internalname, StringUtil.BoolToStr( A59WWPUserExtendedDeleted), "", "Extended Deleted", 1, chkWWPUserExtendedDeleted.Enabled, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(84, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,84);\"");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedDeletedIn_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedDeletedIn_Internalname, "Deleted In", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 89,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPUserExtendedDeletedIn_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedDeletedIn_Internalname, context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A60WWPUserExtendedDeletedIn, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,89);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedDeletedIn_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedDeletedIn_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_bitmap( context, edtWWPUserExtendedDeletedIn_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPUserExtendedDeletedIn_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 94,'',false,'',0)\"";
         ClassString = "Button button-primary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 96,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\WWP_UserExtended.htm");
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
            Z49WWPUserExtendedId = cgiGet( "Z49WWPUserExtendedId");
            Z58WWPUserExtendedName = cgiGet( "Z58WWPUserExtendedName");
            Z50WWPUserExtendedFullName = cgiGet( "Z50WWPUserExtendedFullName");
            Z57WWPUserExtendedPhone = cgiGet( "Z57WWPUserExtendedPhone");
            Z51WWPUserExtendedEmail = cgiGet( "Z51WWPUserExtendedEmail");
            Z53WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( "Z53WWPUserExtendedEmaiNotif"));
            Z54WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( "Z54WWPUserExtendedSMSNotif"));
            Z55WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( "Z55WWPUserExtendedMobileNotif"));
            Z56WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( "Z56WWPUserExtendedDesktopNotif"));
            Z59WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( "Z59WWPUserExtendedDeleted"));
            Z60WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( "Z60WWPUserExtendedDeletedIn"), 0);
            n60WWPUserExtendedDeletedIn = ((DateTime.MinValue==A60WWPUserExtendedDeletedIn) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            A49WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            A52WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            A58WWPUserExtendedName = cgiGet( edtWWPUserExtendedName_Internalname);
            AssignAttri("", false, "A58WWPUserExtendedName", A58WWPUserExtendedName);
            A50WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A57WWPUserExtendedPhone = cgiGet( edtWWPUserExtendedPhone_Internalname);
            AssignAttri("", false, "A57WWPUserExtendedPhone", A57WWPUserExtendedPhone);
            A51WWPUserExtendedEmail = cgiGet( edtWWPUserExtendedEmail_Internalname);
            AssignAttri("", false, "A51WWPUserExtendedEmail", A51WWPUserExtendedEmail);
            A53WWPUserExtendedEmaiNotif = StringUtil.StrToBool( cgiGet( edtWWPUserExtendedEmaiNotif_Internalname));
            AssignAttri("", false, "A53WWPUserExtendedEmaiNotif", A53WWPUserExtendedEmaiNotif);
            A54WWPUserExtendedSMSNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedSMSNotif_Internalname));
            AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
            A55WWPUserExtendedMobileNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedMobileNotif_Internalname));
            AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
            A56WWPUserExtendedDesktopNotif = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDesktopNotif_Internalname));
            AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
            A59WWPUserExtendedDeleted = StringUtil.StrToBool( cgiGet( chkWWPUserExtendedDeleted_Internalname));
            AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPUserExtendedDeletedIn_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"WWPUser Extended Deleted In"}), 1, "WWPUSEREXTENDEDDELETEDIN");
               AnyError = 1;
               GX_FocusControl = edtWWPUserExtendedDeletedIn_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
               n60WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A60WWPUserExtendedDeletedIn = context.localUtil.CToT( cgiGet( edtWWPUserExtendedDeletedIn_Internalname));
               n60WWPUserExtendedDeletedIn = false;
               AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 8, 5, 0, 3, "/", ":", " "));
            }
            n60WWPUserExtendedDeletedIn = ((DateTime.MinValue==A60WWPUserExtendedDeletedIn) ? true : false);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            getMultimediaValue(imgWWPUserExtendedPhoto_Internalname, ref  A52WWPUserExtendedPhoto, ref  A40000WWPUserExtendedPhoto_GXI);
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
               A49WWPUserExtendedId = GetPar( "WWPUserExtendedId");
               n49WWPUserExtendedId = false;
               AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
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
               InitAll066( ) ;
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
         DisableAttributes066( ) ;
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

      protected void ResetCaption060( )
      {
      }

      protected void ZM066( short GX_JID )
      {
         if ( ( GX_JID == 2 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z58WWPUserExtendedName = T00063_A58WWPUserExtendedName[0];
               Z50WWPUserExtendedFullName = T00063_A50WWPUserExtendedFullName[0];
               Z57WWPUserExtendedPhone = T00063_A57WWPUserExtendedPhone[0];
               Z51WWPUserExtendedEmail = T00063_A51WWPUserExtendedEmail[0];
               Z53WWPUserExtendedEmaiNotif = T00063_A53WWPUserExtendedEmaiNotif[0];
               Z54WWPUserExtendedSMSNotif = T00063_A54WWPUserExtendedSMSNotif[0];
               Z55WWPUserExtendedMobileNotif = T00063_A55WWPUserExtendedMobileNotif[0];
               Z56WWPUserExtendedDesktopNotif = T00063_A56WWPUserExtendedDesktopNotif[0];
               Z59WWPUserExtendedDeleted = T00063_A59WWPUserExtendedDeleted[0];
               Z60WWPUserExtendedDeletedIn = T00063_A60WWPUserExtendedDeletedIn[0];
            }
            else
            {
               Z58WWPUserExtendedName = A58WWPUserExtendedName;
               Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
               Z57WWPUserExtendedPhone = A57WWPUserExtendedPhone;
               Z51WWPUserExtendedEmail = A51WWPUserExtendedEmail;
               Z53WWPUserExtendedEmaiNotif = A53WWPUserExtendedEmaiNotif;
               Z54WWPUserExtendedSMSNotif = A54WWPUserExtendedSMSNotif;
               Z55WWPUserExtendedMobileNotif = A55WWPUserExtendedMobileNotif;
               Z56WWPUserExtendedDesktopNotif = A56WWPUserExtendedDesktopNotif;
               Z59WWPUserExtendedDeleted = A59WWPUserExtendedDeleted;
               Z60WWPUserExtendedDeletedIn = A60WWPUserExtendedDeletedIn;
            }
         }
         if ( GX_JID == -2 )
         {
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z52WWPUserExtendedPhoto = A52WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z58WWPUserExtendedName = A58WWPUserExtendedName;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
            Z57WWPUserExtendedPhone = A57WWPUserExtendedPhone;
            Z51WWPUserExtendedEmail = A51WWPUserExtendedEmail;
            Z53WWPUserExtendedEmaiNotif = A53WWPUserExtendedEmaiNotif;
            Z54WWPUserExtendedSMSNotif = A54WWPUserExtendedSMSNotif;
            Z55WWPUserExtendedMobileNotif = A55WWPUserExtendedMobileNotif;
            Z56WWPUserExtendedDesktopNotif = A56WWPUserExtendedDesktopNotif;
            Z59WWPUserExtendedDeleted = A59WWPUserExtendedDeleted;
            Z60WWPUserExtendedDeletedIn = A60WWPUserExtendedDeletedIn;
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

      protected void Load066( )
      {
         /* Using cursor T00064 */
         pr_default.execute(2, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(2) != 101) )
         {
            RcdFound6 = 1;
            A40000WWPUserExtendedPhoto_GXI = T00064_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            A58WWPUserExtendedName = T00064_A58WWPUserExtendedName[0];
            AssignAttri("", false, "A58WWPUserExtendedName", A58WWPUserExtendedName);
            A50WWPUserExtendedFullName = T00064_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A57WWPUserExtendedPhone = T00064_A57WWPUserExtendedPhone[0];
            AssignAttri("", false, "A57WWPUserExtendedPhone", A57WWPUserExtendedPhone);
            A51WWPUserExtendedEmail = T00064_A51WWPUserExtendedEmail[0];
            AssignAttri("", false, "A51WWPUserExtendedEmail", A51WWPUserExtendedEmail);
            A53WWPUserExtendedEmaiNotif = T00064_A53WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A53WWPUserExtendedEmaiNotif", A53WWPUserExtendedEmaiNotif);
            A54WWPUserExtendedSMSNotif = T00064_A54WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
            A55WWPUserExtendedMobileNotif = T00064_A55WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
            A56WWPUserExtendedDesktopNotif = T00064_A56WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
            A59WWPUserExtendedDeleted = T00064_A59WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
            A60WWPUserExtendedDeletedIn = T00064_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = T00064_n60WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 8, 5, 0, 3, "/", ":", " "));
            A52WWPUserExtendedPhoto = T00064_A52WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            ZM066( -2) ;
         }
         pr_default.close(2);
         OnLoadActions066( ) ;
      }

      protected void OnLoadActions066( )
      {
      }

      protected void CheckExtendedTable066( )
      {
         nIsDirty_6 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         if ( ! ( GxRegex.IsMatch(A51WWPUserExtendedEmail,"^((\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*)|(\\s*))$") ) )
         {
            GX_msglist.addItem("O valor de User Email não coincide com o padrão especificado", "OutOfRange", 1, "WWPUSEREXTENDEDEMAIL");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedEmail_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
      }

      protected void CloseExtendedTableCursors066( )
      {
      }

      protected void enableDisable( )
      {
      }

      protected void GetKey066( )
      {
         /* Using cursor T00065 */
         pr_default.execute(3, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(3) != 101) )
         {
            RcdFound6 = 1;
         }
         else
         {
            RcdFound6 = 0;
         }
         pr_default.close(3);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T00063 */
         pr_default.execute(1, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM066( 2) ;
            RcdFound6 = 1;
            A49WWPUserExtendedId = T00063_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T00063_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            A40000WWPUserExtendedPhoto_GXI = T00063_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            A58WWPUserExtendedName = T00063_A58WWPUserExtendedName[0];
            AssignAttri("", false, "A58WWPUserExtendedName", A58WWPUserExtendedName);
            A50WWPUserExtendedFullName = T00063_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A57WWPUserExtendedPhone = T00063_A57WWPUserExtendedPhone[0];
            AssignAttri("", false, "A57WWPUserExtendedPhone", A57WWPUserExtendedPhone);
            A51WWPUserExtendedEmail = T00063_A51WWPUserExtendedEmail[0];
            AssignAttri("", false, "A51WWPUserExtendedEmail", A51WWPUserExtendedEmail);
            A53WWPUserExtendedEmaiNotif = T00063_A53WWPUserExtendedEmaiNotif[0];
            AssignAttri("", false, "A53WWPUserExtendedEmaiNotif", A53WWPUserExtendedEmaiNotif);
            A54WWPUserExtendedSMSNotif = T00063_A54WWPUserExtendedSMSNotif[0];
            AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
            A55WWPUserExtendedMobileNotif = T00063_A55WWPUserExtendedMobileNotif[0];
            AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
            A56WWPUserExtendedDesktopNotif = T00063_A56WWPUserExtendedDesktopNotif[0];
            AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
            A59WWPUserExtendedDeleted = T00063_A59WWPUserExtendedDeleted[0];
            AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
            A60WWPUserExtendedDeletedIn = T00063_A60WWPUserExtendedDeletedIn[0];
            n60WWPUserExtendedDeletedIn = T00063_n60WWPUserExtendedDeletedIn[0];
            AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 8, 5, 0, 3, "/", ":", " "));
            A52WWPUserExtendedPhoto = T00063_A52WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load066( ) ;
            if ( AnyError == 1 )
            {
               RcdFound6 = 0;
               InitializeNonKey066( ) ;
            }
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound6 = 0;
            InitializeNonKey066( ) ;
            sMode6 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode6;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey066( ) ;
         if ( RcdFound6 == 0 )
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
         RcdFound6 = 0;
         /* Using cursor T00066 */
         pr_default.execute(4, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(4) != 101) )
         {
            while ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00066_A49WWPUserExtendedId[0], A49WWPUserExtendedId) < 0 ) ) )
            {
               pr_default.readNext(4);
            }
            if ( (pr_default.getStatus(4) != 101) && ( ( StringUtil.StrCmp(T00066_A49WWPUserExtendedId[0], A49WWPUserExtendedId) > 0 ) ) )
            {
               A49WWPUserExtendedId = T00066_A49WWPUserExtendedId[0];
               n49WWPUserExtendedId = T00066_n49WWPUserExtendedId[0];
               AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
               RcdFound6 = 1;
            }
         }
         pr_default.close(4);
      }

      protected void move_previous( )
      {
         RcdFound6 = 0;
         /* Using cursor T00067 */
         pr_default.execute(5, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            while ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00067_A49WWPUserExtendedId[0], A49WWPUserExtendedId) > 0 ) ) )
            {
               pr_default.readNext(5);
            }
            if ( (pr_default.getStatus(5) != 101) && ( ( StringUtil.StrCmp(T00067_A49WWPUserExtendedId[0], A49WWPUserExtendedId) < 0 ) ) )
            {
               A49WWPUserExtendedId = T00067_A49WWPUserExtendedId[0];
               n49WWPUserExtendedId = T00067_n49WWPUserExtendedId[0];
               AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
               RcdFound6 = 1;
            }
         }
         pr_default.close(5);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey066( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert066( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound6 == 1 )
            {
               if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
               {
                  A49WWPUserExtendedId = Z49WWPUserExtendedId;
                  n49WWPUserExtendedId = false;
                  AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPUSEREXTENDEDID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update066( ) ;
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPUserExtendedId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert066( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPUSEREXTENDEDID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPUserExtendedId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert066( ) ;
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
         if ( StringUtil.StrCmp(A49WWPUserExtendedId, Z49WWPUserExtendedId) != 0 )
         {
            A49WWPUserExtendedId = Z49WWPUserExtendedId;
            n49WWPUserExtendedId = false;
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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
         ScanStart066( ) ;
         if ( RcdFound6 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound6 != 0 )
            {
               ScanNext066( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd066( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency066( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T00062 */
            pr_default.execute(0, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( StringUtil.StrCmp(Z58WWPUserExtendedName, T00062_A58WWPUserExtendedName[0]) != 0 ) || ( StringUtil.StrCmp(Z50WWPUserExtendedFullName, T00062_A50WWPUserExtendedFullName[0]) != 0 ) || ( StringUtil.StrCmp(Z57WWPUserExtendedPhone, T00062_A57WWPUserExtendedPhone[0]) != 0 ) || ( StringUtil.StrCmp(Z51WWPUserExtendedEmail, T00062_A51WWPUserExtendedEmail[0]) != 0 ) || ( Z53WWPUserExtendedEmaiNotif != T00062_A53WWPUserExtendedEmaiNotif[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z54WWPUserExtendedSMSNotif != T00062_A54WWPUserExtendedSMSNotif[0] ) || ( Z55WWPUserExtendedMobileNotif != T00062_A55WWPUserExtendedMobileNotif[0] ) || ( Z56WWPUserExtendedDesktopNotif != T00062_A56WWPUserExtendedDesktopNotif[0] ) || ( Z59WWPUserExtendedDeleted != T00062_A59WWPUserExtendedDeleted[0] ) || ( Z60WWPUserExtendedDeletedIn != T00062_A60WWPUserExtendedDeletedIn[0] ) )
            {
               if ( StringUtil.StrCmp(Z58WWPUserExtendedName, T00062_A58WWPUserExtendedName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedName");
                  GXUtil.WriteLogRaw("Old: ",Z58WWPUserExtendedName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A58WWPUserExtendedName[0]);
               }
               if ( StringUtil.StrCmp(Z50WWPUserExtendedFullName, T00062_A50WWPUserExtendedFullName[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedFullName");
                  GXUtil.WriteLogRaw("Old: ",Z50WWPUserExtendedFullName);
                  GXUtil.WriteLogRaw("Current: ",T00062_A50WWPUserExtendedFullName[0]);
               }
               if ( StringUtil.StrCmp(Z57WWPUserExtendedPhone, T00062_A57WWPUserExtendedPhone[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedPhone");
                  GXUtil.WriteLogRaw("Old: ",Z57WWPUserExtendedPhone);
                  GXUtil.WriteLogRaw("Current: ",T00062_A57WWPUserExtendedPhone[0]);
               }
               if ( StringUtil.StrCmp(Z51WWPUserExtendedEmail, T00062_A51WWPUserExtendedEmail[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmail");
                  GXUtil.WriteLogRaw("Old: ",Z51WWPUserExtendedEmail);
                  GXUtil.WriteLogRaw("Current: ",T00062_A51WWPUserExtendedEmail[0]);
               }
               if ( Z53WWPUserExtendedEmaiNotif != T00062_A53WWPUserExtendedEmaiNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedEmaiNotif");
                  GXUtil.WriteLogRaw("Old: ",Z53WWPUserExtendedEmaiNotif);
                  GXUtil.WriteLogRaw("Current: ",T00062_A53WWPUserExtendedEmaiNotif[0]);
               }
               if ( Z54WWPUserExtendedSMSNotif != T00062_A54WWPUserExtendedSMSNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedSMSNotif");
                  GXUtil.WriteLogRaw("Old: ",Z54WWPUserExtendedSMSNotif);
                  GXUtil.WriteLogRaw("Current: ",T00062_A54WWPUserExtendedSMSNotif[0]);
               }
               if ( Z55WWPUserExtendedMobileNotif != T00062_A55WWPUserExtendedMobileNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedMobileNotif");
                  GXUtil.WriteLogRaw("Old: ",Z55WWPUserExtendedMobileNotif);
                  GXUtil.WriteLogRaw("Current: ",T00062_A55WWPUserExtendedMobileNotif[0]);
               }
               if ( Z56WWPUserExtendedDesktopNotif != T00062_A56WWPUserExtendedDesktopNotif[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDesktopNotif");
                  GXUtil.WriteLogRaw("Old: ",Z56WWPUserExtendedDesktopNotif);
                  GXUtil.WriteLogRaw("Current: ",T00062_A56WWPUserExtendedDesktopNotif[0]);
               }
               if ( Z59WWPUserExtendedDeleted != T00062_A59WWPUserExtendedDeleted[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeleted");
                  GXUtil.WriteLogRaw("Old: ",Z59WWPUserExtendedDeleted);
                  GXUtil.WriteLogRaw("Current: ",T00062_A59WWPUserExtendedDeleted[0]);
               }
               if ( Z60WWPUserExtendedDeletedIn != T00062_A60WWPUserExtendedDeletedIn[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.wwp_userextended:[seudo value changed for attri]"+"WWPUserExtendedDeletedIn");
                  GXUtil.WriteLogRaw("Old: ",Z60WWPUserExtendedDeletedIn);
                  GXUtil.WriteLogRaw("Current: ",T00062_A60WWPUserExtendedDeletedIn[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_UserExtended"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert066( )
      {
         if ( ! IsAuthorized("wwpuserextended_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM066( 0) ;
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00068 */
                     pr_default.execute(6, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId, A52WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, A58WWPUserExtendedName, A50WWPUserExtendedFullName, A57WWPUserExtendedPhone, A51WWPUserExtendedEmail, A53WWPUserExtendedEmaiNotif, A54WWPUserExtendedSMSNotif, A55WWPUserExtendedMobileNotif, A56WWPUserExtendedDesktopNotif, A59WWPUserExtendedDeleted, n60WWPUserExtendedDeletedIn, A60WWPUserExtendedDeletedIn});
                     pr_default.close(6);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
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
                           ResetCaption060( ) ;
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
               Load066( ) ;
            }
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void Update066( )
      {
         if ( ! IsAuthorized("wwpuserextended_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable066( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm066( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate066( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T00069 */
                     pr_default.execute(7, new Object[] {A58WWPUserExtendedName, A50WWPUserExtendedFullName, A57WWPUserExtendedPhone, A51WWPUserExtendedEmail, A53WWPUserExtendedEmaiNotif, A54WWPUserExtendedSMSNotif, A55WWPUserExtendedMobileNotif, A56WWPUserExtendedDesktopNotif, A59WWPUserExtendedDeleted, n60WWPUserExtendedDeletedIn, A60WWPUserExtendedDeletedIn, n49WWPUserExtendedId, A49WWPUserExtendedId});
                     pr_default.close(7);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                     if ( (pr_default.getStatus(7) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_UserExtended"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate066( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption060( ) ;
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
            EndLevel066( ) ;
         }
         CloseExtendedTableCursors066( ) ;
      }

      protected void DeferredUpdate066( )
      {
         if ( AnyError == 0 )
         {
            /* Using cursor T000610 */
            pr_default.execute(8, new Object[] {A52WWPUserExtendedPhoto, A40000WWPUserExtendedPhoto_GXI, n49WWPUserExtendedId, A49WWPUserExtendedId});
            pr_default.close(8);
            pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
         }
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpuserextended_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate066( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency066( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls066( ) ;
            AfterConfirm066( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete066( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000611 */
                  pr_default.execute(9, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
                  pr_default.close(9);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_UserExtended");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound6 == 0 )
                        {
                           InitAll066( ) ;
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
                        ResetCaption060( ) ;
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
         sMode6 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel066( ) ;
         Gx_mode = sMode6;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls066( )
      {
         standaloneModal( ) ;
         /* No delete mode formulas found. */
         if ( AnyError == 0 )
         {
            /* Using cursor T000612 */
            pr_default.execute(10, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(10) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessageMention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(10);
            /* Using cursor T000613 */
            pr_default.execute(11, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(11) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessage"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(11);
            /* Using cursor T000614 */
            pr_default.execute(12, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(12) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Notification"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(12);
            /* Using cursor T000615 */
            pr_default.execute(13, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(13) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_WebClient"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(13);
            /* Using cursor T000616 */
            pr_default.execute(14, new Object[] {n49WWPUserExtendedId, A49WWPUserExtendedId});
            if ( (pr_default.getStatus(14) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_Subscription"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(14);
         }
      }

      protected void EndLevel066( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete066( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.wwp_userextended",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues060( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.wwp_userextended",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart066( )
      {
         /* Using cursor T000617 */
         pr_default.execute(15);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound6 = 1;
            A49WWPUserExtendedId = T000617_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T000617_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext066( )
      {
         /* Scan next routine */
         pr_default.readNext(15);
         RcdFound6 = 0;
         if ( (pr_default.getStatus(15) != 101) )
         {
            RcdFound6 = 1;
            A49WWPUserExtendedId = T000617_A49WWPUserExtendedId[0];
            n49WWPUserExtendedId = T000617_n49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         }
      }

      protected void ScanEnd066( )
      {
         pr_default.close(15);
      }

      protected void AfterConfirm066( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert066( )
      {
         /* Before Insert Rules */
      }

      protected void BeforeUpdate066( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete066( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete066( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate066( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes066( )
      {
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedName_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPUserExtendedPhone_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedPhone_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedPhone_Enabled), 5, 0), true);
         edtWWPUserExtendedEmail_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmail_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmail_Enabled), 5, 0), true);
         edtWWPUserExtendedEmaiNotif_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedEmaiNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedEmaiNotif_Enabled), 5, 0), true);
         chkWWPUserExtendedSMSNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedSMSNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedMobileNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedMobileNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDesktopNotif.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDesktopNotif.Enabled), 5, 0), true);
         chkWWPUserExtendedDeleted.Enabled = 0;
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(chkWWPUserExtendedDeleted.Enabled), 5, 0), true);
         edtWWPUserExtendedDeletedIn_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedDeletedIn_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedDeletedIn_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes066( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues060( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.wwp_userextended.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z58WWPUserExtendedName", Z58WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z50WWPUserExtendedFullName", Z50WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z57WWPUserExtendedPhone", StringUtil.RTrim( Z57WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z51WWPUserExtendedEmail", Z51WWPUserExtendedEmail);
         GxWebStd.gx_boolean_hidden_field( context, "Z53WWPUserExtendedEmaiNotif", Z53WWPUserExtendedEmaiNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z54WWPUserExtendedSMSNotif", Z54WWPUserExtendedSMSNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z55WWPUserExtendedMobileNotif", Z55WWPUserExtendedMobileNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z56WWPUserExtendedDesktopNotif", Z56WWPUserExtendedDesktopNotif);
         GxWebStd.gx_boolean_hidden_field( context, "Z59WWPUserExtendedDeleted", Z59WWPUserExtendedDeleted);
         GxWebStd.gx_hidden_field( context, "Z60WWPUserExtendedDeletedIn", context.localUtil.TToC( Z60WWPUserExtendedDeletedIn, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "IsConfirmed", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsConfirmed), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "IsModified", StringUtil.LTrim( StringUtil.NToC( (decimal)(IsModified), 4, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "WWPUSEREXTENDEDPHOTO_GXI", A40000WWPUserExtendedPhoto_GXI);
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, A52WWPUserExtendedPhoto);
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
         return formatLink("wwpbaseobjects.wwp_userextended.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.WWP_UserExtended" ;
      }

      public override string GetPgmdesc( )
      {
         return "Extended User from GAMUser" ;
      }

      protected void InitializeNonKey066( )
      {
         A52WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A58WWPUserExtendedName = "";
         AssignAttri("", false, "A58WWPUserExtendedName", A58WWPUserExtendedName);
         A50WWPUserExtendedFullName = "";
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A57WWPUserExtendedPhone = "";
         AssignAttri("", false, "A57WWPUserExtendedPhone", A57WWPUserExtendedPhone);
         A51WWPUserExtendedEmail = "";
         AssignAttri("", false, "A51WWPUserExtendedEmail", A51WWPUserExtendedEmail);
         A53WWPUserExtendedEmaiNotif = false;
         AssignAttri("", false, "A53WWPUserExtendedEmaiNotif", A53WWPUserExtendedEmaiNotif);
         A54WWPUserExtendedSMSNotif = false;
         AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
         A55WWPUserExtendedMobileNotif = false;
         AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
         A56WWPUserExtendedDesktopNotif = false;
         AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
         A59WWPUserExtendedDeleted = false;
         AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
         A60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         n60WWPUserExtendedDeletedIn = false;
         AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 8, 5, 0, 3, "/", ":", " "));
         n60WWPUserExtendedDeletedIn = ((DateTime.MinValue==A60WWPUserExtendedDeletedIn) ? true : false);
         Z58WWPUserExtendedName = "";
         Z50WWPUserExtendedFullName = "";
         Z57WWPUserExtendedPhone = "";
         Z51WWPUserExtendedEmail = "";
         Z53WWPUserExtendedEmaiNotif = false;
         Z54WWPUserExtendedSMSNotif = false;
         Z55WWPUserExtendedMobileNotif = false;
         Z56WWPUserExtendedDesktopNotif = false;
         Z59WWPUserExtendedDeleted = false;
         Z60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
      }

      protected void InitAll066( )
      {
         A49WWPUserExtendedId = "";
         n49WWPUserExtendedId = false;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         InitializeNonKey066( ) ;
      }

      protected void StandaloneModalInsert( )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382811460", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/wwp_userextended.js", "?202382811460", false, true);
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
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedName_Internalname = "WWPUSEREXTENDEDNAME";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPUserExtendedPhone_Internalname = "WWPUSEREXTENDEDPHONE";
         edtWWPUserExtendedEmail_Internalname = "WWPUSEREXTENDEDEMAIL";
         edtWWPUserExtendedEmaiNotif_Internalname = "WWPUSEREXTENDEDEMAINOTIF";
         chkWWPUserExtendedSMSNotif_Internalname = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedMobileNotif_Internalname = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedDesktopNotif_Internalname = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDeleted_Internalname = "WWPUSEREXTENDEDDELETED";
         edtWWPUserExtendedDeletedIn_Internalname = "WWPUSEREXTENDEDDELETEDIN";
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
         Form.Caption = "Extended User from GAMUser";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPUserExtendedDeletedIn_Jsonclick = "";
         edtWWPUserExtendedDeletedIn_Enabled = 1;
         chkWWPUserExtendedDeleted.Enabled = 1;
         chkWWPUserExtendedDesktopNotif.Enabled = 1;
         chkWWPUserExtendedMobileNotif.Enabled = 1;
         chkWWPUserExtendedSMSNotif.Enabled = 1;
         edtWWPUserExtendedEmaiNotif_Jsonclick = "";
         edtWWPUserExtendedEmaiNotif_Enabled = 1;
         edtWWPUserExtendedEmail_Jsonclick = "";
         edtWWPUserExtendedEmail_Enabled = 1;
         edtWWPUserExtendedPhone_Jsonclick = "";
         edtWWPUserExtendedPhone_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 1;
         edtWWPUserExtendedName_Jsonclick = "";
         edtWWPUserExtendedName_Enabled = 1;
         imgWWPUserExtendedPhoto_Enabled = 1;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
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
         chkWWPUserExtendedSMSNotif.Name = "WWPUSEREXTENDEDSMSNOTIF";
         chkWWPUserExtendedSMSNotif.WebTags = "";
         chkWWPUserExtendedSMSNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedSMSNotif_Internalname, "TitleCaption", chkWWPUserExtendedSMSNotif.Caption, true);
         chkWWPUserExtendedSMSNotif.CheckedValue = "false";
         A54WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A54WWPUserExtendedSMSNotif));
         AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
         chkWWPUserExtendedMobileNotif.Name = "WWPUSEREXTENDEDMOBILENOTIF";
         chkWWPUserExtendedMobileNotif.WebTags = "";
         chkWWPUserExtendedMobileNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedMobileNotif_Internalname, "TitleCaption", chkWWPUserExtendedMobileNotif.Caption, true);
         chkWWPUserExtendedMobileNotif.CheckedValue = "false";
         A55WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A55WWPUserExtendedMobileNotif));
         AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
         chkWWPUserExtendedDesktopNotif.Name = "WWPUSEREXTENDEDDESKTOPNOTIF";
         chkWWPUserExtendedDesktopNotif.WebTags = "";
         chkWWPUserExtendedDesktopNotif.Caption = "";
         AssignProp("", false, chkWWPUserExtendedDesktopNotif_Internalname, "TitleCaption", chkWWPUserExtendedDesktopNotif.Caption, true);
         chkWWPUserExtendedDesktopNotif.CheckedValue = "false";
         A56WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A56WWPUserExtendedDesktopNotif));
         AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
         chkWWPUserExtendedDeleted.Name = "WWPUSEREXTENDEDDELETED";
         chkWWPUserExtendedDeleted.WebTags = "";
         chkWWPUserExtendedDeleted.Caption = "";
         AssignProp("", false, chkWWPUserExtendedDeleted_Internalname, "TitleCaption", chkWWPUserExtendedDeleted.Caption, true);
         chkWWPUserExtendedDeleted.CheckedValue = "false";
         A59WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A59WWPUserExtendedDeleted));
         AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
         /* End function init_web_controls */
      }

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = imgWWPUserExtendedPhoto_Internalname;
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

      public void Valid_Wwpuserextendedid( )
      {
         n49WWPUserExtendedId = false;
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         A54WWPUserExtendedSMSNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A54WWPUserExtendedSMSNotif));
         A55WWPUserExtendedMobileNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A55WWPUserExtendedMobileNotif));
         A56WWPUserExtendedDesktopNotif = StringUtil.StrToBool( StringUtil.BoolToStr( A56WWPUserExtendedDesktopNotif));
         A59WWPUserExtendedDeleted = StringUtil.StrToBool( StringUtil.BoolToStr( A59WWPUserExtendedDeleted));
         /*  Sending validation outputs */
         AssignAttri("", false, "A52WWPUserExtendedPhoto", context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A58WWPUserExtendedName", A58WWPUserExtendedName);
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         AssignAttri("", false, "A57WWPUserExtendedPhone", StringUtil.RTrim( A57WWPUserExtendedPhone));
         AssignAttri("", false, "A51WWPUserExtendedEmail", A51WWPUserExtendedEmail);
         AssignAttri("", false, "A53WWPUserExtendedEmaiNotif", A53WWPUserExtendedEmaiNotif);
         AssignAttri("", false, "A54WWPUserExtendedSMSNotif", A54WWPUserExtendedSMSNotif);
         AssignAttri("", false, "A55WWPUserExtendedMobileNotif", A55WWPUserExtendedMobileNotif);
         AssignAttri("", false, "A56WWPUserExtendedDesktopNotif", A56WWPUserExtendedDesktopNotif);
         AssignAttri("", false, "A59WWPUserExtendedDeleted", A59WWPUserExtendedDeleted);
         AssignAttri("", false, "A60WWPUserExtendedDeletedIn", context.localUtil.TToC( A60WWPUserExtendedDeletedIn, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z52WWPUserExtendedPhoto", context.PathToRelativeUrl( Z52WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z58WWPUserExtendedName", Z58WWPUserExtendedName);
         GxWebStd.gx_hidden_field( context, "Z50WWPUserExtendedFullName", Z50WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z57WWPUserExtendedPhone", StringUtil.RTrim( Z57WWPUserExtendedPhone));
         GxWebStd.gx_hidden_field( context, "Z51WWPUserExtendedEmail", Z51WWPUserExtendedEmail);
         GxWebStd.gx_hidden_field( context, "Z53WWPUserExtendedEmaiNotif", StringUtil.BoolToStr( Z53WWPUserExtendedEmaiNotif));
         GxWebStd.gx_hidden_field( context, "Z54WWPUserExtendedSMSNotif", StringUtil.BoolToStr( Z54WWPUserExtendedSMSNotif));
         GxWebStd.gx_hidden_field( context, "Z55WWPUserExtendedMobileNotif", StringUtil.BoolToStr( Z55WWPUserExtendedMobileNotif));
         GxWebStd.gx_hidden_field( context, "Z56WWPUserExtendedDesktopNotif", StringUtil.BoolToStr( Z56WWPUserExtendedDesktopNotif));
         GxWebStd.gx_hidden_field( context, "Z59WWPUserExtendedDeleted", StringUtil.BoolToStr( Z59WWPUserExtendedDeleted));
         GxWebStd.gx_hidden_field( context, "Z60WWPUserExtendedDeletedIn", context.localUtil.TToC( Z60WWPUserExtendedDeletedIn, 10, 8, 0, 3, "/", ":", " "));
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
         setEventMetadata("ENTER","{handler:'UserMainFullajax',iparms:[{postForm:true},{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]}");
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]");
         setEventMetadata("REFRESH",",oparms:[{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A52WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A58WWPUserExtendedName',fld:'WWPUSEREXTENDEDNAME',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A57WWPUserExtendedPhone',fld:'WWPUSEREXTENDEDPHONE',pic:''},{av:'A51WWPUserExtendedEmail',fld:'WWPUSEREXTENDEDEMAIL',pic:''},{av:'A53WWPUserExtendedEmaiNotif',fld:'WWPUSEREXTENDEDEMAINOTIF',pic:''},{av:'A60WWPUserExtendedDeletedIn',fld:'WWPUSEREXTENDEDDELETEDIN',pic:'99/99/99 99:99'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z49WWPUserExtendedId'},{av:'Z52WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z58WWPUserExtendedName'},{av:'Z50WWPUserExtendedFullName'},{av:'Z57WWPUserExtendedPhone'},{av:'Z51WWPUserExtendedEmail'},{av:'Z53WWPUserExtendedEmaiNotif'},{av:'Z54WWPUserExtendedSMSNotif'},{av:'Z55WWPUserExtendedMobileNotif'},{av:'Z56WWPUserExtendedDesktopNotif'},{av:'Z59WWPUserExtendedDeleted'},{av:'Z60WWPUserExtendedDeletedIn'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'},{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL","{handler:'Valid_Wwpuserextendedemail',iparms:[{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDEMAIL",",oparms:[{av:'A54WWPUserExtendedSMSNotif',fld:'WWPUSEREXTENDEDSMSNOTIF',pic:''},{av:'A55WWPUserExtendedMobileNotif',fld:'WWPUSEREXTENDEDMOBILENOTIF',pic:''},{av:'A56WWPUserExtendedDesktopNotif',fld:'WWPUSEREXTENDEDDESKTOPNOTIF',pic:''},{av:'A59WWPUserExtendedDeleted',fld:'WWPUSEREXTENDEDDELETED',pic:''}]}");
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
         Z49WWPUserExtendedId = "";
         Z58WWPUserExtendedName = "";
         Z50WWPUserExtendedFullName = "";
         Z57WWPUserExtendedPhone = "";
         Z51WWPUserExtendedEmail = "";
         Z60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         A49WWPUserExtendedId = "";
         A52WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A58WWPUserExtendedName = "";
         A50WWPUserExtendedFullName = "";
         gxphoneLink = "";
         A57WWPUserExtendedPhone = "";
         A51WWPUserExtendedEmail = "";
         A60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
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
         Z52WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         T00064_A49WWPUserExtendedId = new string[] {""} ;
         T00064_n49WWPUserExtendedId = new bool[] {false} ;
         T00064_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00064_A58WWPUserExtendedName = new string[] {""} ;
         T00064_A50WWPUserExtendedFullName = new string[] {""} ;
         T00064_A57WWPUserExtendedPhone = new string[] {""} ;
         T00064_A51WWPUserExtendedEmail = new string[] {""} ;
         T00064_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00064_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00064_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00064_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00064_A59WWPUserExtendedDeleted = new bool[] {false} ;
         T00064_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00064_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00064_A52WWPUserExtendedPhoto = new string[] {""} ;
         T00065_A49WWPUserExtendedId = new string[] {""} ;
         T00065_n49WWPUserExtendedId = new bool[] {false} ;
         T00063_A49WWPUserExtendedId = new string[] {""} ;
         T00063_n49WWPUserExtendedId = new bool[] {false} ;
         T00063_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00063_A58WWPUserExtendedName = new string[] {""} ;
         T00063_A50WWPUserExtendedFullName = new string[] {""} ;
         T00063_A57WWPUserExtendedPhone = new string[] {""} ;
         T00063_A51WWPUserExtendedEmail = new string[] {""} ;
         T00063_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00063_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00063_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00063_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00063_A59WWPUserExtendedDeleted = new bool[] {false} ;
         T00063_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00063_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00063_A52WWPUserExtendedPhoto = new string[] {""} ;
         sMode6 = "";
         T00066_A49WWPUserExtendedId = new string[] {""} ;
         T00066_n49WWPUserExtendedId = new bool[] {false} ;
         T00067_A49WWPUserExtendedId = new string[] {""} ;
         T00067_n49WWPUserExtendedId = new bool[] {false} ;
         T00062_A49WWPUserExtendedId = new string[] {""} ;
         T00062_n49WWPUserExtendedId = new bool[] {false} ;
         T00062_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T00062_A58WWPUserExtendedName = new string[] {""} ;
         T00062_A50WWPUserExtendedFullName = new string[] {""} ;
         T00062_A57WWPUserExtendedPhone = new string[] {""} ;
         T00062_A51WWPUserExtendedEmail = new string[] {""} ;
         T00062_A53WWPUserExtendedEmaiNotif = new bool[] {false} ;
         T00062_A54WWPUserExtendedSMSNotif = new bool[] {false} ;
         T00062_A55WWPUserExtendedMobileNotif = new bool[] {false} ;
         T00062_A56WWPUserExtendedDesktopNotif = new bool[] {false} ;
         T00062_A59WWPUserExtendedDeleted = new bool[] {false} ;
         T00062_A60WWPUserExtendedDeletedIn = new DateTime[] {DateTime.MinValue} ;
         T00062_n60WWPUserExtendedDeletedIn = new bool[] {false} ;
         T00062_A52WWPUserExtendedPhoto = new string[] {""} ;
         T000612_A137WWPDiscussionMessageId = new long[1] ;
         T000612_A138WWPDiscussionMentionUserId = new string[] {""} ;
         T000613_A137WWPDiscussionMessageId = new long[1] ;
         T000614_A64WWPNotificationId = new long[1] ;
         T000615_A90WWPWebClientId = new string[] {""} ;
         T000616_A67WWPSubscriptionId = new long[1] ;
         T000617_A49WWPUserExtendedId = new string[] {""} ;
         T000617_n49WWPUserExtendedId = new bool[] {false} ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         ZZ49WWPUserExtendedId = "";
         ZZ52WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ58WWPUserExtendedName = "";
         ZZ50WWPUserExtendedFullName = "";
         ZZ57WWPUserExtendedPhone = "";
         ZZ51WWPUserExtendedEmail = "";
         ZZ60WWPUserExtendedDeletedIn = (DateTime)(DateTime.MinValue);
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.wwp_userextended__default(),
            new Object[][] {
                new Object[] {
               T00062_A49WWPUserExtendedId, T00062_A40000WWPUserExtendedPhoto_GXI, T00062_A58WWPUserExtendedName, T00062_A50WWPUserExtendedFullName, T00062_A57WWPUserExtendedPhone, T00062_A51WWPUserExtendedEmail, T00062_A53WWPUserExtendedEmaiNotif, T00062_A54WWPUserExtendedSMSNotif, T00062_A55WWPUserExtendedMobileNotif, T00062_A56WWPUserExtendedDesktopNotif,
               T00062_A59WWPUserExtendedDeleted, T00062_A60WWPUserExtendedDeletedIn, T00062_n60WWPUserExtendedDeletedIn, T00062_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T00063_A49WWPUserExtendedId, T00063_A40000WWPUserExtendedPhoto_GXI, T00063_A58WWPUserExtendedName, T00063_A50WWPUserExtendedFullName, T00063_A57WWPUserExtendedPhone, T00063_A51WWPUserExtendedEmail, T00063_A53WWPUserExtendedEmaiNotif, T00063_A54WWPUserExtendedSMSNotif, T00063_A55WWPUserExtendedMobileNotif, T00063_A56WWPUserExtendedDesktopNotif,
               T00063_A59WWPUserExtendedDeleted, T00063_A60WWPUserExtendedDeletedIn, T00063_n60WWPUserExtendedDeletedIn, T00063_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T00064_A49WWPUserExtendedId, T00064_A40000WWPUserExtendedPhoto_GXI, T00064_A58WWPUserExtendedName, T00064_A50WWPUserExtendedFullName, T00064_A57WWPUserExtendedPhone, T00064_A51WWPUserExtendedEmail, T00064_A53WWPUserExtendedEmaiNotif, T00064_A54WWPUserExtendedSMSNotif, T00064_A55WWPUserExtendedMobileNotif, T00064_A56WWPUserExtendedDesktopNotif,
               T00064_A59WWPUserExtendedDeleted, T00064_A60WWPUserExtendedDeletedIn, T00064_n60WWPUserExtendedDeletedIn, T00064_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T00065_A49WWPUserExtendedId
               }
               , new Object[] {
               T00066_A49WWPUserExtendedId
               }
               , new Object[] {
               T00067_A49WWPUserExtendedId
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
               T000612_A137WWPDiscussionMessageId, T000612_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000613_A137WWPDiscussionMessageId
               }
               , new Object[] {
               T000614_A64WWPNotificationId
               }
               , new Object[] {
               T000615_A90WWPWebClientId
               }
               , new Object[] {
               T000616_A67WWPSubscriptionId
               }
               , new Object[] {
               T000617_A49WWPUserExtendedId
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
      private short RcdFound6 ;
      private short nIsDirty_6 ;
      private short Gx_BScreen ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedName_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPUserExtendedPhone_Enabled ;
      private int edtWWPUserExtendedEmail_Enabled ;
      private int edtWWPUserExtendedEmaiNotif_Enabled ;
      private int edtWWPUserExtendedDeletedIn_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private string sPrefix ;
      private string Z49WWPUserExtendedId ;
      private string Z57WWPUserExtendedPhone ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPUserExtendedId_Internalname ;
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
      private string A49WWPUserExtendedId ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedName_Internalname ;
      private string edtWWPUserExtendedName_Jsonclick ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPUserExtendedPhone_Internalname ;
      private string gxphoneLink ;
      private string A57WWPUserExtendedPhone ;
      private string edtWWPUserExtendedPhone_Jsonclick ;
      private string edtWWPUserExtendedEmail_Internalname ;
      private string edtWWPUserExtendedEmail_Jsonclick ;
      private string edtWWPUserExtendedEmaiNotif_Internalname ;
      private string edtWWPUserExtendedEmaiNotif_Jsonclick ;
      private string chkWWPUserExtendedSMSNotif_Internalname ;
      private string chkWWPUserExtendedMobileNotif_Internalname ;
      private string chkWWPUserExtendedDesktopNotif_Internalname ;
      private string chkWWPUserExtendedDeleted_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Internalname ;
      private string edtWWPUserExtendedDeletedIn_Jsonclick ;
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
      private string sMode6 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string ZZ49WWPUserExtendedId ;
      private string ZZ57WWPUserExtendedPhone ;
      private DateTime Z60WWPUserExtendedDeletedIn ;
      private DateTime A60WWPUserExtendedDeletedIn ;
      private DateTime ZZ60WWPUserExtendedDeletedIn ;
      private bool Z53WWPUserExtendedEmaiNotif ;
      private bool Z54WWPUserExtendedSMSNotif ;
      private bool Z55WWPUserExtendedMobileNotif ;
      private bool Z56WWPUserExtendedDesktopNotif ;
      private bool Z59WWPUserExtendedDeleted ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool wbErr ;
      private bool A54WWPUserExtendedSMSNotif ;
      private bool A55WWPUserExtendedMobileNotif ;
      private bool A56WWPUserExtendedDesktopNotif ;
      private bool A59WWPUserExtendedDeleted ;
      private bool A52WWPUserExtendedPhoto_IsBlob ;
      private bool A53WWPUserExtendedEmaiNotif ;
      private bool n60WWPUserExtendedDeletedIn ;
      private bool n49WWPUserExtendedId ;
      private bool Gx_longc ;
      private bool ZZ53WWPUserExtendedEmaiNotif ;
      private bool ZZ54WWPUserExtendedSMSNotif ;
      private bool ZZ55WWPUserExtendedMobileNotif ;
      private bool ZZ56WWPUserExtendedDesktopNotif ;
      private bool ZZ59WWPUserExtendedDeleted ;
      private string Z58WWPUserExtendedName ;
      private string Z50WWPUserExtendedFullName ;
      private string Z51WWPUserExtendedEmail ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A58WWPUserExtendedName ;
      private string A50WWPUserExtendedFullName ;
      private string A51WWPUserExtendedEmail ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ58WWPUserExtendedName ;
      private string ZZ50WWPUserExtendedFullName ;
      private string ZZ51WWPUserExtendedEmail ;
      private string A52WWPUserExtendedPhoto ;
      private string Z52WWPUserExtendedPhoto ;
      private string ZZ52WWPUserExtendedPhoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private GXCheckbox chkWWPUserExtendedSMSNotif ;
      private GXCheckbox chkWWPUserExtendedMobileNotif ;
      private GXCheckbox chkWWPUserExtendedDesktopNotif ;
      private GXCheckbox chkWWPUserExtendedDeleted ;
      private IDataStoreProvider pr_default ;
      private string[] T00064_A49WWPUserExtendedId ;
      private bool[] T00064_n49WWPUserExtendedId ;
      private string[] T00064_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00064_A58WWPUserExtendedName ;
      private string[] T00064_A50WWPUserExtendedFullName ;
      private string[] T00064_A57WWPUserExtendedPhone ;
      private string[] T00064_A51WWPUserExtendedEmail ;
      private bool[] T00064_A53WWPUserExtendedEmaiNotif ;
      private bool[] T00064_A54WWPUserExtendedSMSNotif ;
      private bool[] T00064_A55WWPUserExtendedMobileNotif ;
      private bool[] T00064_A56WWPUserExtendedDesktopNotif ;
      private bool[] T00064_A59WWPUserExtendedDeleted ;
      private DateTime[] T00064_A60WWPUserExtendedDeletedIn ;
      private bool[] T00064_n60WWPUserExtendedDeletedIn ;
      private string[] T00064_A52WWPUserExtendedPhoto ;
      private string[] T00065_A49WWPUserExtendedId ;
      private bool[] T00065_n49WWPUserExtendedId ;
      private string[] T00063_A49WWPUserExtendedId ;
      private bool[] T00063_n49WWPUserExtendedId ;
      private string[] T00063_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00063_A58WWPUserExtendedName ;
      private string[] T00063_A50WWPUserExtendedFullName ;
      private string[] T00063_A57WWPUserExtendedPhone ;
      private string[] T00063_A51WWPUserExtendedEmail ;
      private bool[] T00063_A53WWPUserExtendedEmaiNotif ;
      private bool[] T00063_A54WWPUserExtendedSMSNotif ;
      private bool[] T00063_A55WWPUserExtendedMobileNotif ;
      private bool[] T00063_A56WWPUserExtendedDesktopNotif ;
      private bool[] T00063_A59WWPUserExtendedDeleted ;
      private DateTime[] T00063_A60WWPUserExtendedDeletedIn ;
      private bool[] T00063_n60WWPUserExtendedDeletedIn ;
      private string[] T00063_A52WWPUserExtendedPhoto ;
      private string[] T00066_A49WWPUserExtendedId ;
      private bool[] T00066_n49WWPUserExtendedId ;
      private string[] T00067_A49WWPUserExtendedId ;
      private bool[] T00067_n49WWPUserExtendedId ;
      private string[] T00062_A49WWPUserExtendedId ;
      private bool[] T00062_n49WWPUserExtendedId ;
      private string[] T00062_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T00062_A58WWPUserExtendedName ;
      private string[] T00062_A50WWPUserExtendedFullName ;
      private string[] T00062_A57WWPUserExtendedPhone ;
      private string[] T00062_A51WWPUserExtendedEmail ;
      private bool[] T00062_A53WWPUserExtendedEmaiNotif ;
      private bool[] T00062_A54WWPUserExtendedSMSNotif ;
      private bool[] T00062_A55WWPUserExtendedMobileNotif ;
      private bool[] T00062_A56WWPUserExtendedDesktopNotif ;
      private bool[] T00062_A59WWPUserExtendedDeleted ;
      private DateTime[] T00062_A60WWPUserExtendedDeletedIn ;
      private bool[] T00062_n60WWPUserExtendedDeletedIn ;
      private string[] T00062_A52WWPUserExtendedPhoto ;
      private long[] T000612_A137WWPDiscussionMessageId ;
      private string[] T000612_A138WWPDiscussionMentionUserId ;
      private long[] T000613_A137WWPDiscussionMessageId ;
      private long[] T000614_A64WWPNotificationId ;
      private string[] T000615_A90WWPWebClientId ;
      private long[] T000616_A67WWPSubscriptionId ;
      private string[] T000617_A49WWPUserExtendedId ;
      private bool[] T000617_n49WWPUserExtendedId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_userextended__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_userextended__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new UpdateCursor(def[9])
       ,new ForEachCursor(def[10])
       ,new ForEachCursor(def[11])
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
        Object[] prmT00064;
        prmT00064 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00065;
        prmT00065 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00063;
        prmT00063 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00066;
        prmT00066 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00067;
        prmT00067 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00062;
        prmT00062 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT00068;
        prmT00068 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true} ,
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=1, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true}
        };
        Object[] prmT00069;
        prmT00069 = new Object[] {
        new ParDef("WWPUserExtendedName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedFullName",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedPhone",GXType.Char,20,0) ,
        new ParDef("WWPUserExtendedEmail",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedEmaiNotif",GXType.Boolean,100,0) ,
        new ParDef("WWPUserExtendedSMSNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedMobileNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDesktopNotif",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeleted",GXType.Boolean,4,0) ,
        new ParDef("WWPUserExtendedDeletedIn",GXType.DateTime,8,5){Nullable=true} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000610;
        prmT000610 = new Object[] {
        new ParDef("WWPUserExtendedPhoto",GXType.Byte,1024,0){InDB=false} ,
        new ParDef("WWPUserExtendedPhoto_GXI",GXType.VarChar,2048,0){AddAtt=true, ImgIdx=0, Tbl="WWP_UserExtended", Fld="WWPUserExtendedPhoto"} ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000611;
        prmT000611 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000612;
        prmT000612 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000613;
        prmT000613 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000614;
        prmT000614 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000615;
        prmT000615 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000616;
        prmT000616 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0){Nullable=true}
        };
        Object[] prmT000617;
        prmT000617 = new Object[] {
        };
        def= new CursorDef[] {
            new CursorDef("T00062", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId  FOR UPDATE OF WWP_UserExtended NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT00062,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00063", "SELECT WWPUserExtendedId, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00063,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00064", "SELECT TM1.WWPUserExtendedId, TM1.WWPUserExtendedPhoto_GXI, TM1.WWPUserExtendedName, TM1.WWPUserExtendedFullName, TM1.WWPUserExtendedPhone, TM1.WWPUserExtendedEmail, TM1.WWPUserExtendedEmaiNotif, TM1.WWPUserExtendedSMSNotif, TM1.WWPUserExtendedMobileNotif, TM1.WWPUserExtendedDesktopNotif, TM1.WWPUserExtendedDeleted, TM1.WWPUserExtendedDeletedIn, TM1.WWPUserExtendedPhoto FROM WWP_UserExtended TM1 WHERE TM1.WWPUserExtendedId = ( :WWPUserExtendedId) ORDER BY TM1.WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00064,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00065", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00065,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T00066", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId > ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT00066,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00067", "SELECT WWPUserExtendedId FROM WWP_UserExtended WHERE ( WWPUserExtendedId < ( :WWPUserExtendedId)) ORDER BY WWPUserExtendedId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT00067,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T00068", "SAVEPOINT gxupdate;INSERT INTO WWP_UserExtended(WWPUserExtendedId, WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI, WWPUserExtendedName, WWPUserExtendedFullName, WWPUserExtendedPhone, WWPUserExtendedEmail, WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted, WWPUserExtendedDeletedIn) VALUES(:WWPUserExtendedId, :WWPUserExtendedPhoto, :WWPUserExtendedPhoto_GXI, :WWPUserExtendedName, :WWPUserExtendedFullName, :WWPUserExtendedPhone, :WWPUserExtendedEmail, :WWPUserExtendedEmaiNotif, :WWPUserExtendedSMSNotif, :WWPUserExtendedMobileNotif, :WWPUserExtendedDesktopNotif, :WWPUserExtendedDeleted, :WWPUserExtendedDeletedIn);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT,prmT00068)
           ,new CursorDef("T00069", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedName=:WWPUserExtendedName, WWPUserExtendedFullName=:WWPUserExtendedFullName, WWPUserExtendedPhone=:WWPUserExtendedPhone, WWPUserExtendedEmail=:WWPUserExtendedEmail, WWPUserExtendedEmaiNotif=:WWPUserExtendedEmaiNotif, WWPUserExtendedSMSNotif=:WWPUserExtendedSMSNotif, WWPUserExtendedMobileNotif=:WWPUserExtendedMobileNotif, WWPUserExtendedDesktopNotif=:WWPUserExtendedDesktopNotif, WWPUserExtendedDeleted=:WWPUserExtendedDeleted, WWPUserExtendedDeletedIn=:WWPUserExtendedDeletedIn  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT00069)
           ,new CursorDef("T000610", "SAVEPOINT gxupdate;UPDATE WWP_UserExtended SET WWPUserExtendedPhoto=:WWPUserExtendedPhoto, WWPUserExtendedPhoto_GXI=:WWPUserExtendedPhoto_GXI  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000610)
           ,new CursorDef("T000611", "SAVEPOINT gxupdate;DELETE FROM WWP_UserExtended  WHERE WWPUserExtendedId = :WWPUserExtendedId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000611)
           ,new CursorDef("T000612", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMentionUserId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000612,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000613", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000613,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000614", "SELECT WWPNotificationId FROM WWP_Notification WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000614,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000615", "SELECT WWPWebClientId FROM WWP_WebClient WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000615,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000616", "SELECT WWPSubscriptionId FROM WWP_Subscription WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000616,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000617", "SELECT WWPUserExtendedId FROM WWP_UserExtended ORDER BY WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000617,100, GxCacheFrequency.OFF ,true,false )
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
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 1 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              ((string[]) buf[1])[0] = rslt.getMultimediaUri(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 20);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((bool[]) buf[6])[0] = rslt.getBool(7);
              ((bool[]) buf[7])[0] = rslt.getBool(8);
              ((bool[]) buf[8])[0] = rslt.getBool(9);
              ((bool[]) buf[9])[0] = rslt.getBool(10);
              ((bool[]) buf[10])[0] = rslt.getBool(11);
              ((DateTime[]) buf[11])[0] = rslt.getGXDateTime(12);
              ((bool[]) buf[12])[0] = rslt.wasNull(12);
              ((string[]) buf[13])[0] = rslt.getMultimediaFile(13, rslt.getVarchar(2));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 4 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 5 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
           case 10 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 11 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 12 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 13 :
              ((string[]) buf[0])[0] = rslt.getString(1, 100);
              return;
           case 14 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 15 :
              ((string[]) buf[0])[0] = rslt.getString(1, 40);
              return;
     }
  }

}

}
