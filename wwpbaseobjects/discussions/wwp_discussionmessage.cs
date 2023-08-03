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
namespace GeneXus.Programs.wwpbaseobjects.discussions {
   public class wwp_discussionmessage : GXDataArea
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
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxAggSel2"+"_"+"WWPUSEREXTENDEDID") == 0 )
         {
            Gx_mode = GetPar( "Mode");
            AssignAttri("", false, "Gx_mode", Gx_mode);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            GX2ASAWWPUSEREXTENDEDID0G17( Gx_mode) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_7") == 0 )
         {
            A136WWPDiscussionMessageThreadId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageThreadId"), "."), 18, MidpointRounding.ToEven));
            n136WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_7( A136WWPDiscussionMessageThreadId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_5") == 0 )
         {
            A49WWPUserExtendedId = GetPar( "WWPUserExtendedId");
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_5( A49WWPUserExtendedId) ;
            return  ;
         }
         else if ( StringUtil.StrCmp(gxfirstwebparm, "gxajaxExecAct_"+"gxLoad_6") == 0 )
         {
            A62WWPEntityId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPEntityId"), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            setAjaxCallMode();
            if ( ! IsValidAjaxCall( true) )
            {
               GxWebError = 1;
               return  ;
            }
            gxLoad_6( A62WWPEntityId) ;
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
            Form.Meta.addItem("description", "Discussion Message", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         if ( ! context.isAjaxRequest( ) )
         {
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         wbErr = false;
         context.SetDefaultTheme("WorkWithPlusDS", true);
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
      }

      public wwp_discussionmessage( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public wwp_discussionmessage( IGxContext context )
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
            return "wwpdiscussionmessage_Execute" ;
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
         GxWebStd.gx_label_ctrl( context, lblTitle_Internalname, "Discussion Message", "", "", lblTitle_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "heading-01", 0, "", 1, 1, 0, 0, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_first_Internalname, "", "", bttBtn_first_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_first_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EFIRST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 23,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-prev";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_previous_Internalname, "", "", bttBtn_previous_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_previous_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"EPREVIOUS."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-next";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_next_Internalname, "", "", bttBtn_next_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_next_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ENEXT."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 27,'',false,'',0)\"";
         ClassString = "Button button-auxiliary ico__arrow-last";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_last_Internalname, "", "", bttBtn_last_Jsonclick, 5, "", "", StyleString, ClassString, bttBtn_last_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ELAST."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 29,'',false,'',0)\"";
         ClassString = "Button button-secondary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_select_Internalname, "", "Selecionar", bttBtn_select_Jsonclick, 5, "Selecionar", "", StyleString, ClassString, bttBtn_select_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ESELECT."+"'", TempTags, "", 2, "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageId_Internalname, "Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 34,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A137WWPDiscussionMessageId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPDiscussionMessageId_Enabled!=0) ? context.localUtil.Format( (decimal)(A137WWPDiscussionMessageId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A137WWPDiscussionMessageId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,34);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageDate_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageDate_Internalname, "Date", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 39,'',false,'',0)\"";
         context.WriteHtmlText( "<div id=\""+edtWWPDiscussionMessageDate_Internalname+"_dp_container\" class=\"dp_container\" style=\"white-space:nowrap;display:inline;\">") ;
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageDate_Internalname, context.localUtil.TToC( A140WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "), context.localUtil.Format( A140WWPDiscussionMessageDate, "99/99/99 99:99"), TempTags+" onchange=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.date.valid_date(this, 8,'DMY',5,24,'por',false,0);"+";gx.evt.onblur(this,39);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageDate_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageDate_Enabled, 0, "text", "", 14, "chr", 1, "row", 14, 0, 0, 0, 0, -1, 0, true, "", "end", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_bitmap( context, edtWWPDiscussionMessageDate_Internalname+"_dp_trigger", context.GetImagePath( "61b9b5d3-dff6-4d59-9b00-da61bc2cbe93", "", context.GetTheme( )), "", "", "", "", ((1==0)||(edtWWPDiscussionMessageDate_Enabled==0) ? 0 : 1), 0, "Date selector", "Date selector", 0, 1, 0, "", 0, "", 0, 0, 0, "", "", "cursor: pointer;", "", "", "", "", "", "", "", "", 1, false, false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageThreadId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageThreadId_Internalname, "Thread Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 44,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageThreadId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPDiscussionMessageThreadId_Enabled!=0) ? context.localUtil.Format( (decimal)(A136WWPDiscussionMessageThreadId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A136WWPDiscussionMessageThreadId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,44);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageThreadId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageThreadId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageMessage_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageMessage_Internalname, "Message", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Multiple line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 49,'',false,'',0)\"";
         ClassString = "Attribute";
         StyleString = "";
         ClassString = "Attribute";
         StyleString = "";
         GxWebStd.gx_html_textarea( context, edtWWPDiscussionMessageMessage_Internalname, A141WWPDiscussionMessageMessage, "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,49);\"", 0, 1, edtWWPDiscussionMessageMessage_Enabled, 0, 80, "chr", 5, "row", 0, StyleString, ClassString, "", "", "400", -1, 0, "", "", -1, true, "", "'"+""+"'"+",false,"+"'"+""+"'", 0, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedId_Internalname, StringUtil.RTrim( A49WWPUserExtendedId), StringUtil.RTrim( context.localUtil.Format( A49WWPUserExtendedId, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,54);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedId_Enabled, 0, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_GAMGUID", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_label_element( context, "", "User Photo", "col-sm-3 ImageAttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Static Bitmap Variable */
         ClassString = "ImageAttribute";
         StyleString = "";
         A52WWPUserExtendedPhoto_IsBlob = (bool)((String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto))&&String.IsNullOrEmpty(StringUtil.RTrim( A40000WWPUserExtendedPhoto_GXI)))||!String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)));
         sImgUrl = (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         GxWebStd.gx_bitmap( context, imgWWPUserExtendedPhoto_Internalname, sImgUrl, "", "", "", context.GetTheme( ), 1, imgWWPUserExtendedPhoto_Enabled, "", "", 0, -1, 0, "", 0, "", 0, 0, 0, "", "", StyleString, ClassString, "", "", "", "", "", "", "", 0, A52WWPUserExtendedPhoto_IsBlob, true, context.GetImageSrcSet( sImgUrl), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPUserExtendedFullName_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPUserExtendedFullName_Internalname, "User Full Name", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         GxWebStd.gx_single_line_edit( context, edtWWPUserExtendedFullName_Internalname, A50WWPUserExtendedFullName, StringUtil.RTrim( context.localUtil.Format( A50WWPUserExtendedFullName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPUserExtendedFullName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPUserExtendedFullName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPEntityId_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPEntityId_Internalname, "Entity Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 69,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPEntityId_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ",", "")), StringUtil.LTrim( ((edtWWPEntityId_Enabled!=0) ? context.localUtil.Format( (decimal)(A62WWPEntityId), "ZZZZZZZZZ9") : context.localUtil.Format( (decimal)(A62WWPEntityId), "ZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,69);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityId_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityId_Enabled, 0, "text", "1", 10, "chr", 1, "row", 10, 0, 0, 0, 0, -1, 0, true, "WWPBaseObjects\\WWP_Id", "end", false, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_single_line_edit( context, edtWWPEntityName_Internalname, A63WWPEntityName, StringUtil.RTrim( context.localUtil.Format( A63WWPEntityName, "")), "", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPEntityName_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPEntityName_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "WWPBaseObjects\\WWP_Description", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 form__cell", "start", "top", "", "", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtWWPDiscussionMessageEntityReco_Internalname+"\"", "", "div");
         /* Attribute/Variable Label */
         GxWebStd.gx_label_element( context, edtWWPDiscussionMessageEntityReco_Internalname, "Record Id", "col-sm-3 AttributeLabel", 1, true, "");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
         /* Single line edit */
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 79,'',false,'',0)\"";
         GxWebStd.gx_single_line_edit( context, edtWWPDiscussionMessageEntityReco_Internalname, A142WWPDiscussionMessageEntityReco, StringUtil.RTrim( context.localUtil.Format( A142WWPDiscussionMessageEntityReco, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,79);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtWWPDiscussionMessageEntityReco_Jsonclick, 0, "Attribute", "", "", "", "", 1, edtWWPDiscussionMessageEntityReco_Enabled, 0, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
         GxWebStd.gx_button_ctrl( context, bttBtn_enter_Internalname, "", "Confirmar", bttBtn_enter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, bttBtn_enter_Visible, bttBtn_enter_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 86,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_cancel_Internalname, "", "Fechar", bttBtn_cancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, bttBtn_cancel_Visible, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
         GxWebStd.gx_div_end( context, "start", "top", "div");
         /* Div Control */
         GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
         TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
         ClassString = "Button button-tertiary";
         StyleString = "";
         GxWebStd.gx_button_ctrl( context, bttBtn_delete_Internalname, "", "Excluir", bttBtn_delete_Jsonclick, 5, "Excluir", "", StyleString, ClassString, bttBtn_delete_Visible, bttBtn_delete_Enabled, "standard", "'"+""+"'"+",false,"+"'"+"EDELETE."+"'", TempTags, "", context.GetButtonType( ), "HLP_WWPBaseObjects\\Discussions\\WWP_DiscussionMessage.htm");
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
            Z137WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z137WWPDiscussionMessageId"), ",", "."), 18, MidpointRounding.ToEven));
            Z140WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( "Z140WWPDiscussionMessageDate"), 0);
            Z141WWPDiscussionMessageMessage = cgiGet( "Z141WWPDiscussionMessageMessage");
            Z142WWPDiscussionMessageEntityReco = cgiGet( "Z142WWPDiscussionMessageEntityReco");
            Z49WWPUserExtendedId = cgiGet( "Z49WWPUserExtendedId");
            Z62WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z62WWPEntityId"), ",", "."), 18, MidpointRounding.ToEven));
            Z136WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( "Z136WWPDiscussionMessageThreadId"), ",", "."), 18, MidpointRounding.ToEven));
            n136WWPDiscussionMessageThreadId = ((0==A136WWPDiscussionMessageThreadId) ? true : false);
            IsConfirmed = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsConfirmed"), ",", "."), 18, MidpointRounding.ToEven));
            IsModified = (short)(Math.Round(context.localUtil.CToN( cgiGet( "IsModified"), ",", "."), 18, MidpointRounding.ToEven));
            Gx_mode = cgiGet( "Mode");
            A40000WWPUserExtendedPhoto_GXI = cgiGet( "WWPUSEREXTENDEDPHOTO_GXI");
            /* Read variables values. */
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGEID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A137WWPDiscussionMessageId = 0;
               AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
            }
            else
            {
               A137WWPDiscussionMessageId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
            }
            if ( context.localUtil.VCDateTime( cgiGet( edtWWPDiscussionMessageDate_Internalname), 2, 0) == 0 )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_baddatetime", new   object[]  {"Message Date"}), 1, "WWPDISCUSSIONMESSAGEDATE");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
               AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            }
            else
            {
               A140WWPDiscussionMessageDate = context.localUtil.CToT( cgiGet( edtWWPDiscussionMessageDate_Internalname));
               AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            }
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A136WWPDiscussionMessageThreadId = 0;
               n136WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            }
            else
            {
               A136WWPDiscussionMessageThreadId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPDiscussionMessageThreadId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               n136WWPDiscussionMessageThreadId = false;
               AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            }
            n136WWPDiscussionMessageThreadId = ((0==A136WWPDiscussionMessageThreadId) ? true : false);
            A141WWPDiscussionMessageMessage = cgiGet( edtWWPDiscussionMessageMessage_Internalname);
            AssignAttri("", false, "A141WWPDiscussionMessageMessage", A141WWPDiscussionMessageMessage);
            A49WWPUserExtendedId = cgiGet( edtWWPUserExtendedId_Internalname);
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            A52WWPUserExtendedPhoto = cgiGet( imgWWPUserExtendedPhoto_Internalname);
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            A50WWPUserExtendedFullName = cgiGet( edtWWPUserExtendedFullName_Internalname);
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            if ( ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", ".") > Convert.ToDecimal( 9999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "WWPENTITYID");
               AnyError = 1;
               GX_FocusControl = edtWWPEntityId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               A62WWPEntityId = 0;
               AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            }
            else
            {
               A62WWPEntityId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtWWPEntityId_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            }
            A63WWPEntityName = cgiGet( edtWWPEntityName_Internalname);
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            A142WWPDiscussionMessageEntityReco = cgiGet( edtWWPDiscussionMessageEntityReco_Internalname);
            AssignAttri("", false, "A142WWPDiscussionMessageEntityReco", A142WWPDiscussionMessageEntityReco);
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
               A137WWPDiscussionMessageId = (long)(Math.Round(NumberUtil.Val( GetPar( "WWPDiscussionMessageId"), "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
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
               InitAll0G17( ) ;
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
         DisableAttributes0G17( ) ;
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

      protected void ResetCaption0G0( )
      {
      }

      protected void ZM0G17( short GX_JID )
      {
         if ( ( GX_JID == 4 ) || ( GX_JID == 0 ) )
         {
            if ( ! IsIns( ) )
            {
               Z140WWPDiscussionMessageDate = T000G3_A140WWPDiscussionMessageDate[0];
               Z141WWPDiscussionMessageMessage = T000G3_A141WWPDiscussionMessageMessage[0];
               Z142WWPDiscussionMessageEntityReco = T000G3_A142WWPDiscussionMessageEntityReco[0];
               Z49WWPUserExtendedId = T000G3_A49WWPUserExtendedId[0];
               Z62WWPEntityId = T000G3_A62WWPEntityId[0];
               Z136WWPDiscussionMessageThreadId = T000G3_A136WWPDiscussionMessageThreadId[0];
            }
            else
            {
               Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
               Z141WWPDiscussionMessageMessage = A141WWPDiscussionMessageMessage;
               Z142WWPDiscussionMessageEntityReco = A142WWPDiscussionMessageEntityReco;
               Z49WWPUserExtendedId = A49WWPUserExtendedId;
               Z62WWPEntityId = A62WWPEntityId;
               Z136WWPDiscussionMessageThreadId = A136WWPDiscussionMessageThreadId;
            }
         }
         if ( GX_JID == -4 )
         {
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            Z140WWPDiscussionMessageDate = A140WWPDiscussionMessageDate;
            Z141WWPDiscussionMessageMessage = A141WWPDiscussionMessageMessage;
            Z142WWPDiscussionMessageEntityReco = A142WWPDiscussionMessageEntityReco;
            Z49WWPUserExtendedId = A49WWPUserExtendedId;
            Z62WWPEntityId = A62WWPEntityId;
            Z136WWPDiscussionMessageThreadId = A136WWPDiscussionMessageThreadId;
            Z52WWPUserExtendedPhoto = A52WWPUserExtendedPhoto;
            Z40000WWPUserExtendedPhoto_GXI = A40000WWPUserExtendedPhoto_GXI;
            Z50WWPUserExtendedFullName = A50WWPUserExtendedFullName;
            Z63WWPEntityName = A63WWPEntityName;
         }
      }

      protected void standaloneNotModal( )
      {
      }

      protected void standaloneModal( )
      {
         A140WWPDiscussionMessageDate = DateTimeUtil.Now( context);
         AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         GXt_char1 = A49WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A49WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
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
            /* Using cursor T000G4 */
            pr_default.execute(2, new Object[] {A49WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000G4_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            A50WWPUserExtendedFullName = T000G4_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A52WWPUserExtendedPhoto = T000G4_A52WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            pr_default.close(2);
         }
      }

      protected void Load0G17( )
      {
         /* Using cursor T000G7 */
         pr_default.execute(5, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(5) != 101) )
         {
            RcdFound17 = 1;
            A140WWPDiscussionMessageDate = T000G7_A140WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            A141WWPDiscussionMessageMessage = T000G7_A141WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A141WWPDiscussionMessageMessage", A141WWPDiscussionMessageMessage);
            A40000WWPUserExtendedPhoto_GXI = T000G7_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            A50WWPUserExtendedFullName = T000G7_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A63WWPEntityName = T000G7_A63WWPEntityName[0];
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            A142WWPDiscussionMessageEntityReco = T000G7_A142WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A142WWPDiscussionMessageEntityReco", A142WWPDiscussionMessageEntityReco);
            A49WWPUserExtendedId = T000G7_A49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            A62WWPEntityId = T000G7_A62WWPEntityId[0];
            AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            A136WWPDiscussionMessageThreadId = T000G7_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = T000G7_n136WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            A52WWPUserExtendedPhoto = T000G7_A52WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            ZM0G17( -4) ;
         }
         pr_default.close(5);
         OnLoadActions0G17( ) ;
      }

      protected void OnLoadActions0G17( )
      {
      }

      protected void CheckExtendedTable0G17( )
      {
         nIsDirty_17 = 0;
         Gx_BScreen = 1;
         standaloneModal( ) ;
         /* Using cursor T000G6 */
         pr_default.execute(4, new Object[] {n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(4) == 101) )
         {
            if ( ! ( (0==A136WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         pr_default.close(4);
         /* Using cursor T000G4 */
         pr_default.execute(2, new Object[] {A49WWPUserExtendedId});
         if ( (pr_default.getStatus(2) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000G4_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A50WWPUserExtendedFullName = T000G4_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A52WWPUserExtendedPhoto = T000G4_A52WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         pr_default.close(2);
         /* Using cursor T000G5 */
         pr_default.execute(3, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(3) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A63WWPEntityName = T000G5_A63WWPEntityName[0];
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         pr_default.close(3);
      }

      protected void CloseExtendedTableCursors0G17( )
      {
         pr_default.close(4);
         pr_default.close(2);
         pr_default.close(3);
      }

      protected void enableDisable( )
      {
      }

      protected void gxLoad_7( long A136WWPDiscussionMessageThreadId )
      {
         /* Using cursor T000G8 */
         pr_default.execute(6, new Object[] {n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(6) == 101) )
         {
            if ( ! ( (0==A136WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(6) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(6);
      }

      protected void gxLoad_5( string A49WWPUserExtendedId )
      {
         /* Using cursor T000G9 */
         pr_default.execute(7, new Object[] {A49WWPUserExtendedId});
         if ( (pr_default.getStatus(7) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A40000WWPUserExtendedPhoto_GXI = T000G9_A40000WWPUserExtendedPhoto_GXI[0];
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A50WWPUserExtendedFullName = T000G9_A50WWPUserExtendedFullName[0];
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A52WWPUserExtendedPhoto = T000G9_A52WWPUserExtendedPhoto[0];
         AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A52WWPUserExtendedPhoto)+"\""+","+"\""+GXUtil.EncodeJSConstant( A40000WWPUserExtendedPhoto_GXI)+"\""+","+"\""+GXUtil.EncodeJSConstant( A50WWPUserExtendedFullName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(7) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(7);
      }

      protected void gxLoad_6( long A62WWPEntityId )
      {
         /* Using cursor T000G10 */
         pr_default.execute(8, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(8) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         A63WWPEntityName = T000G10_A63WWPEntityName[0];
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( A63WWPEntityName)+"\"") ;
         AddString( "]") ;
         if ( (pr_default.getStatus(8) == 101) )
         {
            AddString( ",") ;
            AddString( "101") ;
         }
         AddString( "]") ;
         pr_default.close(8);
      }

      protected void GetKey0G17( )
      {
         /* Using cursor T000G11 */
         pr_default.execute(9, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(9) != 101) )
         {
            RcdFound17 = 1;
         }
         else
         {
            RcdFound17 = 0;
         }
         pr_default.close(9);
      }

      protected void getByPrimaryKey( )
      {
         /* Using cursor T000G3 */
         pr_default.execute(1, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(1) != 101) )
         {
            ZM0G17( 4) ;
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = T000G3_A137WWPDiscussionMessageId[0];
            AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
            A140WWPDiscussionMessageDate = T000G3_A140WWPDiscussionMessageDate[0];
            AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
            A141WWPDiscussionMessageMessage = T000G3_A141WWPDiscussionMessageMessage[0];
            AssignAttri("", false, "A141WWPDiscussionMessageMessage", A141WWPDiscussionMessageMessage);
            A142WWPDiscussionMessageEntityReco = T000G3_A142WWPDiscussionMessageEntityReco[0];
            AssignAttri("", false, "A142WWPDiscussionMessageEntityReco", A142WWPDiscussionMessageEntityReco);
            A49WWPUserExtendedId = T000G3_A49WWPUserExtendedId[0];
            AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
            A62WWPEntityId = T000G3_A62WWPEntityId[0];
            AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
            A136WWPDiscussionMessageThreadId = T000G3_A136WWPDiscussionMessageThreadId[0];
            n136WWPDiscussionMessageThreadId = T000G3_n136WWPDiscussionMessageThreadId[0];
            AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            Z137WWPDiscussionMessageId = A137WWPDiscussionMessageId;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Load0G17( ) ;
            if ( AnyError == 1 )
            {
               RcdFound17 = 0;
               InitializeNonKey0G17( ) ;
            }
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         else
         {
            RcdFound17 = 0;
            InitializeNonKey0G17( ) ;
            sMode17 = Gx_mode;
            Gx_mode = "DSP";
            AssignAttri("", false, "Gx_mode", Gx_mode);
            standaloneModal( ) ;
            Gx_mode = sMode17;
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         pr_default.close(1);
      }

      protected void getEqualNoModal( )
      {
         GetKey0G17( ) ;
         if ( RcdFound17 == 0 )
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
         RcdFound17 = 0;
         /* Using cursor T000G12 */
         pr_default.execute(10, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(10) != 101) )
         {
            while ( (pr_default.getStatus(10) != 101) && ( ( T000G12_A137WWPDiscussionMessageId[0] < A137WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(10);
            }
            if ( (pr_default.getStatus(10) != 101) && ( ( T000G12_A137WWPDiscussionMessageId[0] > A137WWPDiscussionMessageId ) ) )
            {
               A137WWPDiscussionMessageId = T000G12_A137WWPDiscussionMessageId[0];
               AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(10);
      }

      protected void move_previous( )
      {
         RcdFound17 = 0;
         /* Using cursor T000G13 */
         pr_default.execute(11, new Object[] {A137WWPDiscussionMessageId});
         if ( (pr_default.getStatus(11) != 101) )
         {
            while ( (pr_default.getStatus(11) != 101) && ( ( T000G13_A137WWPDiscussionMessageId[0] > A137WWPDiscussionMessageId ) ) )
            {
               pr_default.readNext(11);
            }
            if ( (pr_default.getStatus(11) != 101) && ( ( T000G13_A137WWPDiscussionMessageId[0] < A137WWPDiscussionMessageId ) ) )
            {
               A137WWPDiscussionMessageId = T000G13_A137WWPDiscussionMessageId[0];
               AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
               RcdFound17 = 1;
            }
         }
         pr_default.close(11);
      }

      protected void btn_enter( )
      {
         nKeyPressed = 1;
         GetKey0G17( ) ;
         if ( IsIns( ) )
         {
            /* Insert record */
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            Insert0G17( ) ;
            if ( AnyError == 1 )
            {
               GX_FocusControl = "";
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
         }
         else
         {
            if ( RcdFound17 == 1 )
            {
               if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
               {
                  A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
                  AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
                  GX_msglist.addItem(context.GetMessage( "GXM_getbeforeupd", ""), "CandidateKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
                  AnyError = 1;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else if ( IsDlt( ) )
               {
                  delete( ) ;
                  AfterTrn( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
               else
               {
                  Gx_mode = "UPD";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Update record */
                  Update0G17( ) ;
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               }
            }
            else
            {
               if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
               {
                  Gx_mode = "INS";
                  AssignAttri("", false, "Gx_mode", Gx_mode);
                  /* Insert record */
                  GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                  AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  Insert0G17( ) ;
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
                     GX_msglist.addItem(context.GetMessage( "GXM_recdeleted", ""), 1, "WWPDISCUSSIONMESSAGEID");
                     AnyError = 1;
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                  }
                  else
                  {
                     Gx_mode = "INS";
                     AssignAttri("", false, "Gx_mode", Gx_mode);
                     /* Insert record */
                     GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
                     AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
                     Insert0G17( ) ;
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
         if ( A137WWPDiscussionMessageId != Z137WWPDiscussionMessageId )
         {
            A137WWPDiscussionMessageId = Z137WWPDiscussionMessageId;
            AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
            GX_msglist.addItem(context.GetMessage( "GXM_getbeforedlt", ""), 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         else
         {
            delete( ) ;
            AfterTrn( ) ;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_keynfound", ""), "PrimaryKeyNotFound", 1, "WWPDISCUSSIONMESSAGEID");
            AnyError = 1;
            GX_FocusControl = edtWWPDiscussionMessageId_Internalname;
            AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_first( )
      {
         nKeyPressed = 2;
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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
         ScanStart0G17( ) ;
         if ( RcdFound17 == 0 )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_norectobrow", ""), 0, "", true);
         }
         else
         {
            while ( RcdFound17 != 0 )
            {
               ScanNext0G17( ) ;
            }
            Gx_mode = "UPD";
            AssignAttri("", false, "Gx_mode", Gx_mode);
         }
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
         AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
         ScanEnd0G17( ) ;
         getByPrimaryKey( ) ;
         standaloneNotModal( ) ;
         standaloneModal( ) ;
      }

      protected void btn_select( )
      {
         getEqualNoModal( ) ;
      }

      protected void CheckOptimisticConcurrency0G17( )
      {
         if ( ! IsIns( ) )
         {
            /* Using cursor T000G2 */
            pr_default.execute(0, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(0) == 103) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
               AnyError = 1;
               return  ;
            }
            Gx_longc = false;
            if ( (pr_default.getStatus(0) == 101) || ( Z140WWPDiscussionMessageDate != T000G2_A140WWPDiscussionMessageDate[0] ) || ( StringUtil.StrCmp(Z141WWPDiscussionMessageMessage, T000G2_A141WWPDiscussionMessageMessage[0]) != 0 ) || ( StringUtil.StrCmp(Z142WWPDiscussionMessageEntityReco, T000G2_A142WWPDiscussionMessageEntityReco[0]) != 0 ) || ( StringUtil.StrCmp(Z49WWPUserExtendedId, T000G2_A49WWPUserExtendedId[0]) != 0 ) || ( Z62WWPEntityId != T000G2_A62WWPEntityId[0] ) )
            {
               Gx_longc = true;
            }
            if ( Gx_longc || ( Z136WWPDiscussionMessageThreadId != T000G2_A136WWPDiscussionMessageThreadId[0] ) )
            {
               if ( Z140WWPDiscussionMessageDate != T000G2_A140WWPDiscussionMessageDate[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageDate");
                  GXUtil.WriteLogRaw("Old: ",Z140WWPDiscussionMessageDate);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A140WWPDiscussionMessageDate[0]);
               }
               if ( StringUtil.StrCmp(Z141WWPDiscussionMessageMessage, T000G2_A141WWPDiscussionMessageMessage[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageMessage");
                  GXUtil.WriteLogRaw("Old: ",Z141WWPDiscussionMessageMessage);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A141WWPDiscussionMessageMessage[0]);
               }
               if ( StringUtil.StrCmp(Z142WWPDiscussionMessageEntityReco, T000G2_A142WWPDiscussionMessageEntityReco[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageEntityReco");
                  GXUtil.WriteLogRaw("Old: ",Z142WWPDiscussionMessageEntityReco);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A142WWPDiscussionMessageEntityReco[0]);
               }
               if ( StringUtil.StrCmp(Z49WWPUserExtendedId, T000G2_A49WWPUserExtendedId[0]) != 0 )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPUserExtendedId");
                  GXUtil.WriteLogRaw("Old: ",Z49WWPUserExtendedId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A49WWPUserExtendedId[0]);
               }
               if ( Z62WWPEntityId != T000G2_A62WWPEntityId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPEntityId");
                  GXUtil.WriteLogRaw("Old: ",Z62WWPEntityId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A62WWPEntityId[0]);
               }
               if ( Z136WWPDiscussionMessageThreadId != T000G2_A136WWPDiscussionMessageThreadId[0] )
               {
                  GXUtil.WriteLog("wwpbaseobjects.discussions.wwp_discussionmessage:[seudo value changed for attri]"+"WWPDiscussionMessageThreadId");
                  GXUtil.WriteLogRaw("Old: ",Z136WWPDiscussionMessageThreadId);
                  GXUtil.WriteLogRaw("Current: ",T000G2_A136WWPDiscussionMessageThreadId[0]);
               }
               GX_msglist.addItem(context.GetMessage( "GXM_waschg", new   object[]  {"WWP_DiscussionMessage"}), "RecordWasChanged", 1, "");
               AnyError = 1;
               return  ;
            }
         }
      }

      protected void Insert0G17( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Insert") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            ZM0G17( 0) ;
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeInsert0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G14 */
                     pr_default.execute(12, new Object[] {A140WWPDiscussionMessageDate, A141WWPDiscussionMessageMessage, A142WWPDiscussionMessageEntityReco, A49WWPUserExtendedId, A62WWPEntityId, n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
                     pr_default.close(12);
                     /* Retrieving last key number assigned */
                     /* Using cursor T000G15 */
                     pr_default.execute(13);
                     A137WWPDiscussionMessageId = T000G15_A137WWPDiscussionMessageId[0];
                     AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
                     pr_default.close(13);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( AnyError == 0 )
                     {
                        /* Start of After( Insert) rules */
                        /* End of After( Insert) rules */
                        if ( AnyError == 0 )
                        {
                           /* Save values for previous() function. */
                           endTrnMsgTxt = context.GetMessage( "GXM_sucadded", "");
                           endTrnMsgCod = "SuccessfullyAdded";
                           ResetCaption0G0( ) ;
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
               Load0G17( ) ;
            }
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void Update0G17( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Update") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckExtendedTable0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
            if ( AnyError == 0 )
            {
               AfterConfirm0G17( ) ;
               if ( AnyError == 0 )
               {
                  BeforeUpdate0G17( ) ;
                  if ( AnyError == 0 )
                  {
                     /* Using cursor T000G16 */
                     pr_default.execute(14, new Object[] {A140WWPDiscussionMessageDate, A141WWPDiscussionMessageMessage, A142WWPDiscussionMessageEntityReco, A49WWPUserExtendedId, A62WWPEntityId, n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId, A137WWPDiscussionMessageId});
                     pr_default.close(14);
                     pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                     if ( (pr_default.getStatus(14) == 103) )
                     {
                        GX_msglist.addItem(context.GetMessage( "GXM_lock", new   object[]  {"WWP_DiscussionMessage"}), "RecordIsLocked", 1, "");
                        AnyError = 1;
                     }
                     DeferredUpdate0G17( ) ;
                     if ( AnyError == 0 )
                     {
                        /* Start of After( update) rules */
                        /* End of After( update) rules */
                        if ( AnyError == 0 )
                        {
                           getByPrimaryKey( ) ;
                           endTrnMsgTxt = context.GetMessage( "GXM_sucupdated", "");
                           endTrnMsgCod = "SuccessfullyUpdated";
                           ResetCaption0G0( ) ;
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
            EndLevel0G17( ) ;
         }
         CloseExtendedTableCursors0G17( ) ;
      }

      protected void DeferredUpdate0G17( )
      {
      }

      protected void delete( )
      {
         if ( ! IsAuthorized("wwpdiscussionmessage_Delete") )
         {
            GX_msglist.addItem(context.GetMessage( "GXM_notauthorized", ""), 1, "");
            AnyError = 1;
            return  ;
         }
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         BeforeValidate0G17( ) ;
         if ( AnyError == 0 )
         {
            CheckOptimisticConcurrency0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            OnDeleteControls0G17( ) ;
            AfterConfirm0G17( ) ;
            if ( AnyError == 0 )
            {
               BeforeDelete0G17( ) ;
               if ( AnyError == 0 )
               {
                  /* No cascading delete specified. */
                  /* Using cursor T000G17 */
                  pr_default.execute(15, new Object[] {A137WWPDiscussionMessageId});
                  pr_default.close(15);
                  pr_default.SmartCacheProvider.SetUpdated("WWP_DiscussionMessage");
                  if ( AnyError == 0 )
                  {
                     /* Start of After( delete) rules */
                     /* End of After( delete) rules */
                     if ( AnyError == 0 )
                     {
                        move_next( ) ;
                        if ( RcdFound17 == 0 )
                        {
                           InitAll0G17( ) ;
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
                        ResetCaption0G0( ) ;
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
         sMode17 = Gx_mode;
         Gx_mode = "DLT";
         AssignAttri("", false, "Gx_mode", Gx_mode);
         EndLevel0G17( ) ;
         Gx_mode = sMode17;
         AssignAttri("", false, "Gx_mode", Gx_mode);
      }

      protected void OnDeleteControls0G17( )
      {
         standaloneModal( ) ;
         if ( AnyError == 0 )
         {
            /* Delete mode formulas */
            /* Using cursor T000G18 */
            pr_default.execute(16, new Object[] {A49WWPUserExtendedId});
            A40000WWPUserExtendedPhoto_GXI = T000G18_A40000WWPUserExtendedPhoto_GXI[0];
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            A50WWPUserExtendedFullName = T000G18_A50WWPUserExtendedFullName[0];
            AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
            A52WWPUserExtendedPhoto = T000G18_A52WWPUserExtendedPhoto[0];
            AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
            AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
            pr_default.close(16);
            /* Using cursor T000G19 */
            pr_default.execute(17, new Object[] {A62WWPEntityId});
            A63WWPEntityName = T000G19_A63WWPEntityName[0];
            AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
            pr_default.close(17);
         }
         if ( AnyError == 0 )
         {
            /* Using cursor T000G20 */
            pr_default.execute(18, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(18) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessage"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(18);
            /* Using cursor T000G21 */
            pr_default.execute(19, new Object[] {A137WWPDiscussionMessageId});
            if ( (pr_default.getStatus(19) != 101) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_del", new   object[]  {"WWP_DiscussionMessageMention"}), "CannotDeleteReferencedRecord", 1, "");
               AnyError = 1;
            }
            pr_default.close(19);
         }
      }

      protected void EndLevel0G17( )
      {
         if ( ! IsIns( ) )
         {
            pr_default.close(0);
         }
         if ( AnyError == 0 )
         {
            BeforeComplete0G17( ) ;
         }
         if ( AnyError == 0 )
         {
            context.CommitDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
            if ( AnyError == 0 )
            {
               ConfirmValues0G0( ) ;
            }
            /* After transaction rules */
            /* Execute 'After Trn' event if defined. */
            trnEnded = 1;
         }
         else
         {
            context.RollbackDataStores("wwpbaseobjects.discussions.wwp_discussionmessage",pr_default);
         }
         IsModified = 0;
         if ( AnyError != 0 )
         {
            context.wjLoc = "";
            context.nUserReturn = 0;
         }
      }

      public void ScanStart0G17( )
      {
         /* Using cursor T000G22 */
         pr_default.execute(20);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = T000G22_A137WWPDiscussionMessageId[0];
            AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
         }
         /* Load Subordinate Levels */
      }

      protected void ScanNext0G17( )
      {
         /* Scan next routine */
         pr_default.readNext(20);
         RcdFound17 = 0;
         if ( (pr_default.getStatus(20) != 101) )
         {
            RcdFound17 = 1;
            A137WWPDiscussionMessageId = T000G22_A137WWPDiscussionMessageId[0];
            AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
         }
      }

      protected void ScanEnd0G17( )
      {
         pr_default.close(20);
      }

      protected void AfterConfirm0G17( )
      {
         /* After Confirm Rules */
      }

      protected void BeforeInsert0G17( )
      {
         /* Before Insert Rules */
         if ( (0==A136WWPDiscussionMessageThreadId) )
         {
            A136WWPDiscussionMessageThreadId = 0;
            n136WWPDiscussionMessageThreadId = false;
            AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
            n136WWPDiscussionMessageThreadId = true;
            AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
         }
      }

      protected void BeforeUpdate0G17( )
      {
         /* Before Update Rules */
      }

      protected void BeforeDelete0G17( )
      {
         /* Before Delete Rules */
      }

      protected void BeforeComplete0G17( )
      {
         /* Before Complete Rules */
      }

      protected void BeforeValidate0G17( )
      {
         /* Before Validate Rules */
      }

      protected void DisableAttributes0G17( )
      {
         edtWWPDiscussionMessageId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageDate_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageDate_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageDate_Enabled), 5, 0), true);
         edtWWPDiscussionMessageThreadId_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageThreadId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageThreadId_Enabled), 5, 0), true);
         edtWWPDiscussionMessageMessage_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageMessage_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageMessage_Enabled), 5, 0), true);
         edtWWPUserExtendedId_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedId_Enabled), 5, 0), true);
         imgWWPUserExtendedPhoto_Enabled = 0;
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(imgWWPUserExtendedPhoto_Enabled), 5, 0), true);
         edtWWPUserExtendedFullName_Enabled = 0;
         AssignProp("", false, edtWWPUserExtendedFullName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPUserExtendedFullName_Enabled), 5, 0), true);
         edtWWPEntityId_Enabled = 0;
         AssignProp("", false, edtWWPEntityId_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityId_Enabled), 5, 0), true);
         edtWWPEntityName_Enabled = 0;
         AssignProp("", false, edtWWPEntityName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPEntityName_Enabled), 5, 0), true);
         edtWWPDiscussionMessageEntityReco_Enabled = 0;
         AssignProp("", false, edtWWPDiscussionMessageEntityReco_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtWWPDiscussionMessageEntityReco_Enabled), 5, 0), true);
      }

      protected void send_integrity_lvl_hashes0G17( )
      {
      }

      protected void assign_properties_default( )
      {
      }

      protected void ConfirmValues0G0( )
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
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx") +"\">") ;
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
         GxWebStd.gx_hidden_field( context, "Z137WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137WWPDiscussionMessageId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z140WWPDiscussionMessageDate", context.localUtil.TToC( Z140WWPDiscussionMessageDate, 10, 8, 0, 0, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z141WWPDiscussionMessageMessage", Z141WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z142WWPDiscussionMessageEntityReco", Z142WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62WWPEntityId), 10, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "Z136WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136WWPDiscussionMessageThreadId), 10, 0, ",", "")));
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
         return formatLink("wwpbaseobjects.discussions.wwp_discussionmessage.aspx")  ;
      }

      public override string GetPgmname( )
      {
         return "WWPBaseObjects.Discussions.WWP_DiscussionMessage" ;
      }

      public override string GetPgmdesc( )
      {
         return "Discussion Message" ;
      }

      protected void InitializeNonKey0G17( )
      {
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         A49WWPUserExtendedId = "";
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         A136WWPDiscussionMessageThreadId = 0;
         n136WWPDiscussionMessageThreadId = false;
         AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrimStr( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0));
         n136WWPDiscussionMessageThreadId = ((0==A136WWPDiscussionMessageThreadId) ? true : false);
         A141WWPDiscussionMessageMessage = "";
         AssignAttri("", false, "A141WWPDiscussionMessageMessage", A141WWPDiscussionMessageMessage);
         A52WWPUserExtendedPhoto = "";
         AssignAttri("", false, "A52WWPUserExtendedPhoto", A52WWPUserExtendedPhoto);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A40000WWPUserExtendedPhoto_GXI = "";
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "Bitmap", (String.IsNullOrEmpty(StringUtil.RTrim( A52WWPUserExtendedPhoto)) ? A40000WWPUserExtendedPhoto_GXI : context.convertURL( context.PathToRelativeUrl( A52WWPUserExtendedPhoto))), true);
         AssignProp("", false, imgWWPUserExtendedPhoto_Internalname, "SrcSet", context.GetImageSrcSet( A52WWPUserExtendedPhoto), true);
         A50WWPUserExtendedFullName = "";
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         A62WWPEntityId = 0;
         AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrimStr( (decimal)(A62WWPEntityId), 10, 0));
         A63WWPEntityName = "";
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         A142WWPDiscussionMessageEntityReco = "";
         AssignAttri("", false, "A142WWPDiscussionMessageEntityReco", A142WWPDiscussionMessageEntityReco);
         Z140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z141WWPDiscussionMessageMessage = "";
         Z142WWPDiscussionMessageEntityReco = "";
         Z49WWPUserExtendedId = "";
         Z62WWPEntityId = 0;
         Z136WWPDiscussionMessageThreadId = 0;
      }

      protected void InitAll0G17( )
      {
         A137WWPDiscussionMessageId = 0;
         AssignAttri("", false, "A137WWPDiscussionMessageId", StringUtil.LTrimStr( (decimal)(A137WWPDiscussionMessageId), 10, 0));
         InitializeNonKey0G17( ) ;
      }

      protected void StandaloneModalInsert( )
      {
         A140WWPDiscussionMessageDate = i140WWPDiscussionMessageDate;
         AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 8, 5, 0, 3, "/", ":", " "));
         A49WWPUserExtendedId = i49WWPUserExtendedId;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?2023828122536", true, true);
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
         context.AddJavascriptSource("wwpbaseobjects/discussions/wwp_discussionmessage.js", "?2023828122536", false, true);
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
         edtWWPDiscussionMessageId_Internalname = "WWPDISCUSSIONMESSAGEID";
         edtWWPDiscussionMessageDate_Internalname = "WWPDISCUSSIONMESSAGEDATE";
         edtWWPDiscussionMessageThreadId_Internalname = "WWPDISCUSSIONMESSAGETHREADID";
         edtWWPDiscussionMessageMessage_Internalname = "WWPDISCUSSIONMESSAGEMESSAGE";
         edtWWPUserExtendedId_Internalname = "WWPUSEREXTENDEDID";
         imgWWPUserExtendedPhoto_Internalname = "WWPUSEREXTENDEDPHOTO";
         edtWWPUserExtendedFullName_Internalname = "WWPUSEREXTENDEDFULLNAME";
         edtWWPEntityId_Internalname = "WWPENTITYID";
         edtWWPEntityName_Internalname = "WWPENTITYNAME";
         edtWWPDiscussionMessageEntityReco_Internalname = "WWPDISCUSSIONMESSAGEENTITYRECO";
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
         Form.Caption = "Discussion Message";
         bttBtn_delete_Enabled = 1;
         bttBtn_delete_Visible = 1;
         bttBtn_cancel_Visible = 1;
         bttBtn_enter_Enabled = 1;
         bttBtn_enter_Visible = 1;
         edtWWPDiscussionMessageEntityReco_Jsonclick = "";
         edtWWPDiscussionMessageEntityReco_Enabled = 1;
         edtWWPEntityName_Jsonclick = "";
         edtWWPEntityName_Enabled = 0;
         edtWWPEntityId_Jsonclick = "";
         edtWWPEntityId_Enabled = 1;
         edtWWPUserExtendedFullName_Jsonclick = "";
         edtWWPUserExtendedFullName_Enabled = 0;
         imgWWPUserExtendedPhoto_Enabled = 0;
         edtWWPUserExtendedId_Jsonclick = "";
         edtWWPUserExtendedId_Enabled = 1;
         edtWWPDiscussionMessageMessage_Enabled = 1;
         edtWWPDiscussionMessageThreadId_Jsonclick = "";
         edtWWPDiscussionMessageThreadId_Enabled = 1;
         edtWWPDiscussionMessageDate_Jsonclick = "";
         edtWWPDiscussionMessageDate_Enabled = 1;
         edtWWPDiscussionMessageId_Jsonclick = "";
         edtWWPDiscussionMessageId_Enabled = 1;
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

      protected void GX2ASAWWPUSEREXTENDEDID0G17( string Gx_mode )
      {
         GXt_char1 = A49WWPUserExtendedId;
         new GeneXus.Programs.wwpbaseobjects.wwp_getloggeduserid(context ).execute( out  GXt_char1) ;
         A49WWPUserExtendedId = GXt_char1;
         AssignAttri("", false, "A49WWPUserExtendedId", A49WWPUserExtendedId);
         GxWebStd.set_html_headers( context, 0, "", "");
         AddString( "[[") ;
         AddString( "\""+GXUtil.EncodeJSConstant( StringUtil.RTrim( A49WWPUserExtendedId))+"\"") ;
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

      protected void AfterKeyLoadScreen( )
      {
         IsConfirmed = 0;
         AssignAttri("", false, "IsConfirmed", StringUtil.LTrimStr( (decimal)(IsConfirmed), 4, 0));
         getEqualNoModal( ) ;
         GX_FocusControl = edtWWPDiscussionMessageDate_Internalname;
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

      public void Valid_Wwpdiscussionmessageid( )
      {
         context.wbHandled = 1;
         AfterKeyLoadScreen( ) ;
         Draw( ) ;
         send_integrity_footer_hashes( ) ;
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A140WWPDiscussionMessageDate", context.localUtil.TToC( A140WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         AssignAttri("", false, "A49WWPUserExtendedId", StringUtil.RTrim( A49WWPUserExtendedId));
         AssignAttri("", false, "A136WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A136WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         AssignAttri("", false, "A141WWPDiscussionMessageMessage", A141WWPDiscussionMessageMessage);
         AssignAttri("", false, "A62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(A62WWPEntityId), 10, 0, ".", "")));
         AssignAttri("", false, "A142WWPDiscussionMessageEntityReco", A142WWPDiscussionMessageEntityReco);
         AssignAttri("", false, "A52WWPUserExtendedPhoto", context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
         AssignAttri("", false, "Gx_mode", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "Z137WWPDiscussionMessageId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z137WWPDiscussionMessageId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z140WWPDiscussionMessageDate", context.localUtil.TToC( Z140WWPDiscussionMessageDate, 10, 8, 0, 3, "/", ":", " "));
         GxWebStd.gx_hidden_field( context, "Z49WWPUserExtendedId", StringUtil.RTrim( Z49WWPUserExtendedId));
         GxWebStd.gx_hidden_field( context, "Z136WWPDiscussionMessageThreadId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z136WWPDiscussionMessageThreadId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z141WWPDiscussionMessageMessage", Z141WWPDiscussionMessageMessage);
         GxWebStd.gx_hidden_field( context, "Z62WWPEntityId", StringUtil.LTrim( StringUtil.NToC( (decimal)(Z62WWPEntityId), 10, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "Z142WWPDiscussionMessageEntityReco", Z142WWPDiscussionMessageEntityReco);
         GxWebStd.gx_hidden_field( context, "Z52WWPUserExtendedPhoto", context.PathToRelativeUrl( Z52WWPUserExtendedPhoto));
         GxWebStd.gx_hidden_field( context, "Z40000WWPUserExtendedPhoto_GXI", Z40000WWPUserExtendedPhoto_GXI);
         GxWebStd.gx_hidden_field( context, "Z50WWPUserExtendedFullName", Z50WWPUserExtendedFullName);
         GxWebStd.gx_hidden_field( context, "Z63WWPEntityName", Z63WWPEntityName);
         AssignProp("", false, bttBtn_delete_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_delete_Enabled), 5, 0), true);
         AssignProp("", false, bttBtn_enter_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(bttBtn_enter_Enabled), 5, 0), true);
         SendCloseFormHiddens( ) ;
      }

      public void Valid_Wwpdiscussionmessagethreadid( )
      {
         n136WWPDiscussionMessageThreadId = false;
         /* Using cursor T000G23 */
         pr_default.execute(21, new Object[] {n136WWPDiscussionMessageThreadId, A136WWPDiscussionMessageThreadId});
         if ( (pr_default.getStatus(21) == 101) )
         {
            if ( ! ( (0==A136WWPDiscussionMessageThreadId) ) )
            {
               GX_msglist.addItem("Não existe 'Discussion Message Thread'.", "ForeignKeyNotFound", 1, "WWPDISCUSSIONMESSAGETHREADID");
               AnyError = 1;
               GX_FocusControl = edtWWPDiscussionMessageThreadId_Internalname;
            }
         }
         pr_default.close(21);
         dynload_actions( ) ;
         /*  Sending validation outputs */
      }

      public void Valid_Wwpuserextendedid( )
      {
         /* Using cursor T000G18 */
         pr_default.execute(16, new Object[] {A49WWPUserExtendedId});
         if ( (pr_default.getStatus(16) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_UserExtended'.", "ForeignKeyNotFound", 1, "WWPUSEREXTENDEDID");
            AnyError = 1;
            GX_FocusControl = edtWWPUserExtendedId_Internalname;
         }
         A40000WWPUserExtendedPhoto_GXI = T000G18_A40000WWPUserExtendedPhoto_GXI[0];
         A50WWPUserExtendedFullName = T000G18_A50WWPUserExtendedFullName[0];
         A52WWPUserExtendedPhoto = T000G18_A52WWPUserExtendedPhoto[0];
         pr_default.close(16);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A52WWPUserExtendedPhoto", context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         GXCCtlgxBlob = "WWPUSEREXTENDEDPHOTO" + "_gxBlob";
         AssignAttri("", false, "GXCCtlgxBlob", GXCCtlgxBlob);
         GxWebStd.gx_hidden_field( context, GXCCtlgxBlob, context.PathToRelativeUrl( A52WWPUserExtendedPhoto));
         AssignAttri("", false, "A40000WWPUserExtendedPhoto_GXI", A40000WWPUserExtendedPhoto_GXI);
         AssignAttri("", false, "A50WWPUserExtendedFullName", A50WWPUserExtendedFullName);
      }

      public void Valid_Wwpentityid( )
      {
         /* Using cursor T000G19 */
         pr_default.execute(17, new Object[] {A62WWPEntityId});
         if ( (pr_default.getStatus(17) == 101) )
         {
            GX_msglist.addItem("Não existe 'WWP_Entity'.", "ForeignKeyNotFound", 1, "WWPENTITYID");
            AnyError = 1;
            GX_FocusControl = edtWWPEntityId_Internalname;
         }
         A63WWPEntityName = T000G19_A63WWPEntityName[0];
         pr_default.close(17);
         dynload_actions( ) ;
         /*  Sending validation outputs */
         AssignAttri("", false, "A63WWPEntityName", A63WWPEntityName);
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
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID","{handler:'Valid_Wwpdiscussionmessageid',iparms:[{av:'A137WWPDiscussionMessageId',fld:'WWPDISCUSSIONMESSAGEID',pic:'ZZZZZZZZZ9'},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'A140WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGEID",",oparms:[{av:'A140WWPDiscussionMessageDate',fld:'WWPDISCUSSIONMESSAGEDATE',pic:'99/99/99 99:99'},{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A136WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'},{av:'A141WWPDiscussionMessageMessage',fld:'WWPDISCUSSIONMESSAGEMESSAGE',pic:''},{av:'A62WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A142WWPDiscussionMessageEntityReco',fld:'WWPDISCUSSIONMESSAGEENTITYRECO',pic:''},{av:'A52WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''},{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!'},{av:'Z137WWPDiscussionMessageId'},{av:'Z140WWPDiscussionMessageDate'},{av:'Z49WWPUserExtendedId'},{av:'Z136WWPDiscussionMessageThreadId'},{av:'Z141WWPDiscussionMessageMessage'},{av:'Z62WWPEntityId'},{av:'Z142WWPDiscussionMessageEntityReco'},{av:'Z52WWPUserExtendedPhoto'},{av:'Z40000WWPUserExtendedPhoto_GXI'},{av:'Z50WWPUserExtendedFullName'},{av:'Z63WWPEntityName'},{ctrl:'BTN_DELETE',prop:'Enabled'},{ctrl:'BTN_ENTER',prop:'Enabled'}]}");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID","{handler:'Valid_Wwpdiscussionmessagethreadid',iparms:[{av:'A136WWPDiscussionMessageThreadId',fld:'WWPDISCUSSIONMESSAGETHREADID',pic:'ZZZZZZZZZ9'}]");
         setEventMetadata("VALID_WWPDISCUSSIONMESSAGETHREADID",",oparms:[]}");
         setEventMetadata("VALID_WWPUSEREXTENDEDID","{handler:'Valid_Wwpuserextendedid',iparms:[{av:'A49WWPUserExtendedId',fld:'WWPUSEREXTENDEDID',pic:''},{av:'A52WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}]");
         setEventMetadata("VALID_WWPUSEREXTENDEDID",",oparms:[{av:'A52WWPUserExtendedPhoto',fld:'WWPUSEREXTENDEDPHOTO',pic:''},{av:'A40000WWPUserExtendedPhoto_GXI',fld:'WWPUSEREXTENDEDPHOTO_GXI',pic:''},{av:'A50WWPUserExtendedFullName',fld:'WWPUSEREXTENDEDFULLNAME',pic:''}]}");
         setEventMetadata("VALID_WWPENTITYID","{handler:'Valid_Wwpentityid',iparms:[{av:'A62WWPEntityId',fld:'WWPENTITYID',pic:'ZZZZZZZZZ9'},{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''}]");
         setEventMetadata("VALID_WWPENTITYID",",oparms:[{av:'A63WWPEntityName',fld:'WWPENTITYNAME',pic:''}]}");
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
         pr_default.close(17);
         pr_default.close(21);
      }

      public override void initialize( )
      {
         sPrefix = "";
         Z140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         Z141WWPDiscussionMessageMessage = "";
         Z142WWPDiscussionMessageEntityReco = "";
         Z49WWPUserExtendedId = "";
         scmdbuf = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         Gx_mode = "";
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
         A140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         A141WWPDiscussionMessageMessage = "";
         A52WWPUserExtendedPhoto = "";
         A40000WWPUserExtendedPhoto_GXI = "";
         sImgUrl = "";
         A50WWPUserExtendedFullName = "";
         A63WWPEntityName = "";
         A142WWPDiscussionMessageEntityReco = "";
         bttBtn_enter_Jsonclick = "";
         bttBtn_cancel_Jsonclick = "";
         bttBtn_delete_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         endTrnMsgTxt = "";
         endTrnMsgCod = "";
         Z52WWPUserExtendedPhoto = "";
         Z40000WWPUserExtendedPhoto_GXI = "";
         Z50WWPUserExtendedFullName = "";
         Z63WWPEntityName = "";
         T000G4_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G4_A50WWPUserExtendedFullName = new string[] {""} ;
         T000G4_A52WWPUserExtendedPhoto = new string[] {""} ;
         T000G7_A137WWPDiscussionMessageId = new long[1] ;
         T000G7_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000G7_A141WWPDiscussionMessageMessage = new string[] {""} ;
         T000G7_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G7_A50WWPUserExtendedFullName = new string[] {""} ;
         T000G7_A63WWPEntityName = new string[] {""} ;
         T000G7_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000G7_A49WWPUserExtendedId = new string[] {""} ;
         T000G7_A62WWPEntityId = new long[1] ;
         T000G7_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G7_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000G7_A52WWPUserExtendedPhoto = new string[] {""} ;
         T000G6_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G6_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000G5_A63WWPEntityName = new string[] {""} ;
         T000G8_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G8_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000G9_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G9_A50WWPUserExtendedFullName = new string[] {""} ;
         T000G9_A52WWPUserExtendedPhoto = new string[] {""} ;
         T000G10_A63WWPEntityName = new string[] {""} ;
         T000G11_A137WWPDiscussionMessageId = new long[1] ;
         T000G3_A137WWPDiscussionMessageId = new long[1] ;
         T000G3_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000G3_A141WWPDiscussionMessageMessage = new string[] {""} ;
         T000G3_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000G3_A49WWPUserExtendedId = new string[] {""} ;
         T000G3_A62WWPEntityId = new long[1] ;
         T000G3_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G3_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         sMode17 = "";
         T000G12_A137WWPDiscussionMessageId = new long[1] ;
         T000G13_A137WWPDiscussionMessageId = new long[1] ;
         T000G2_A137WWPDiscussionMessageId = new long[1] ;
         T000G2_A140WWPDiscussionMessageDate = new DateTime[] {DateTime.MinValue} ;
         T000G2_A141WWPDiscussionMessageMessage = new string[] {""} ;
         T000G2_A142WWPDiscussionMessageEntityReco = new string[] {""} ;
         T000G2_A49WWPUserExtendedId = new string[] {""} ;
         T000G2_A62WWPEntityId = new long[1] ;
         T000G2_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G2_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000G15_A137WWPDiscussionMessageId = new long[1] ;
         T000G18_A40000WWPUserExtendedPhoto_GXI = new string[] {""} ;
         T000G18_A50WWPUserExtendedFullName = new string[] {""} ;
         T000G18_A52WWPUserExtendedPhoto = new string[] {""} ;
         T000G19_A63WWPEntityName = new string[] {""} ;
         T000G20_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G20_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         T000G21_A137WWPDiscussionMessageId = new long[1] ;
         T000G21_A138WWPDiscussionMentionUserId = new string[] {""} ;
         T000G22_A137WWPDiscussionMessageId = new long[1] ;
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXCCtlgxBlob = "";
         i140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         i49WWPUserExtendedId = "";
         GXt_char1 = "";
         ZZ140WWPDiscussionMessageDate = (DateTime)(DateTime.MinValue);
         ZZ49WWPUserExtendedId = "";
         ZZ141WWPDiscussionMessageMessage = "";
         ZZ142WWPDiscussionMessageEntityReco = "";
         ZZ52WWPUserExtendedPhoto = "";
         ZZ40000WWPUserExtendedPhoto_GXI = "";
         ZZ50WWPUserExtendedFullName = "";
         ZZ63WWPEntityName = "";
         T000G23_A136WWPDiscussionMessageThreadId = new long[1] ;
         T000G23_n136WWPDiscussionMessageThreadId = new bool[] {false} ;
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.wwpbaseobjects.discussions.wwp_discussionmessage__default(),
            new Object[][] {
                new Object[] {
               T000G2_A137WWPDiscussionMessageId, T000G2_A140WWPDiscussionMessageDate, T000G2_A141WWPDiscussionMessageMessage, T000G2_A142WWPDiscussionMessageEntityReco, T000G2_A49WWPUserExtendedId, T000G2_A62WWPEntityId, T000G2_A136WWPDiscussionMessageThreadId, T000G2_n136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000G3_A137WWPDiscussionMessageId, T000G3_A140WWPDiscussionMessageDate, T000G3_A141WWPDiscussionMessageMessage, T000G3_A142WWPDiscussionMessageEntityReco, T000G3_A49WWPUserExtendedId, T000G3_A62WWPEntityId, T000G3_A136WWPDiscussionMessageThreadId, T000G3_n136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000G4_A40000WWPUserExtendedPhoto_GXI, T000G4_A50WWPUserExtendedFullName, T000G4_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G5_A63WWPEntityName
               }
               , new Object[] {
               T000G6_A136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000G7_A137WWPDiscussionMessageId, T000G7_A140WWPDiscussionMessageDate, T000G7_A141WWPDiscussionMessageMessage, T000G7_A40000WWPUserExtendedPhoto_GXI, T000G7_A50WWPUserExtendedFullName, T000G7_A63WWPEntityName, T000G7_A142WWPDiscussionMessageEntityReco, T000G7_A49WWPUserExtendedId, T000G7_A62WWPEntityId, T000G7_A136WWPDiscussionMessageThreadId,
               T000G7_n136WWPDiscussionMessageThreadId, T000G7_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G8_A136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000G9_A40000WWPUserExtendedPhoto_GXI, T000G9_A50WWPUserExtendedFullName, T000G9_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G10_A63WWPEntityName
               }
               , new Object[] {
               T000G11_A137WWPDiscussionMessageId
               }
               , new Object[] {
               T000G12_A137WWPDiscussionMessageId
               }
               , new Object[] {
               T000G13_A137WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               T000G15_A137WWPDiscussionMessageId
               }
               , new Object[] {
               }
               , new Object[] {
               }
               , new Object[] {
               T000G18_A40000WWPUserExtendedPhoto_GXI, T000G18_A50WWPUserExtendedFullName, T000G18_A52WWPUserExtendedPhoto
               }
               , new Object[] {
               T000G19_A63WWPEntityName
               }
               , new Object[] {
               T000G20_A136WWPDiscussionMessageThreadId
               }
               , new Object[] {
               T000G21_A137WWPDiscussionMessageId, T000G21_A138WWPDiscussionMentionUserId
               }
               , new Object[] {
               T000G22_A137WWPDiscussionMessageId
               }
               , new Object[] {
               T000G23_A136WWPDiscussionMessageThreadId
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
      private short Gx_BScreen ;
      private short RcdFound17 ;
      private short nIsDirty_17 ;
      private short gxajaxcallmode ;
      private int trnEnded ;
      private int bttBtn_first_Visible ;
      private int bttBtn_previous_Visible ;
      private int bttBtn_next_Visible ;
      private int bttBtn_last_Visible ;
      private int bttBtn_select_Visible ;
      private int edtWWPDiscussionMessageId_Enabled ;
      private int edtWWPDiscussionMessageDate_Enabled ;
      private int edtWWPDiscussionMessageThreadId_Enabled ;
      private int edtWWPDiscussionMessageMessage_Enabled ;
      private int edtWWPUserExtendedId_Enabled ;
      private int imgWWPUserExtendedPhoto_Enabled ;
      private int edtWWPUserExtendedFullName_Enabled ;
      private int edtWWPEntityId_Enabled ;
      private int edtWWPEntityName_Enabled ;
      private int edtWWPDiscussionMessageEntityReco_Enabled ;
      private int bttBtn_enter_Visible ;
      private int bttBtn_enter_Enabled ;
      private int bttBtn_cancel_Visible ;
      private int bttBtn_delete_Visible ;
      private int bttBtn_delete_Enabled ;
      private int idxLst ;
      private long Z137WWPDiscussionMessageId ;
      private long Z62WWPEntityId ;
      private long Z136WWPDiscussionMessageThreadId ;
      private long A136WWPDiscussionMessageThreadId ;
      private long A62WWPEntityId ;
      private long A137WWPDiscussionMessageId ;
      private long ZZ137WWPDiscussionMessageId ;
      private long ZZ136WWPDiscussionMessageThreadId ;
      private long ZZ62WWPEntityId ;
      private string sPrefix ;
      private string Z49WWPUserExtendedId ;
      private string scmdbuf ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string Gx_mode ;
      private string A49WWPUserExtendedId ;
      private string GXKey ;
      private string PreviousTooltip ;
      private string PreviousCaption ;
      private string GX_FocusControl ;
      private string edtWWPDiscussionMessageId_Internalname ;
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
      private string edtWWPDiscussionMessageId_Jsonclick ;
      private string edtWWPDiscussionMessageDate_Internalname ;
      private string edtWWPDiscussionMessageDate_Jsonclick ;
      private string edtWWPDiscussionMessageThreadId_Internalname ;
      private string edtWWPDiscussionMessageThreadId_Jsonclick ;
      private string edtWWPDiscussionMessageMessage_Internalname ;
      private string edtWWPUserExtendedId_Internalname ;
      private string edtWWPUserExtendedId_Jsonclick ;
      private string imgWWPUserExtendedPhoto_Internalname ;
      private string sImgUrl ;
      private string edtWWPUserExtendedFullName_Internalname ;
      private string edtWWPUserExtendedFullName_Jsonclick ;
      private string edtWWPEntityId_Internalname ;
      private string edtWWPEntityId_Jsonclick ;
      private string edtWWPEntityName_Internalname ;
      private string edtWWPEntityName_Jsonclick ;
      private string edtWWPDiscussionMessageEntityReco_Internalname ;
      private string edtWWPDiscussionMessageEntityReco_Jsonclick ;
      private string bttBtn_enter_Internalname ;
      private string bttBtn_enter_Jsonclick ;
      private string bttBtn_cancel_Internalname ;
      private string bttBtn_cancel_Jsonclick ;
      private string bttBtn_delete_Internalname ;
      private string bttBtn_delete_Jsonclick ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string endTrnMsgTxt ;
      private string endTrnMsgCod ;
      private string sMode17 ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXCCtlgxBlob ;
      private string i49WWPUserExtendedId ;
      private string GXt_char1 ;
      private string ZZ49WWPUserExtendedId ;
      private DateTime Z140WWPDiscussionMessageDate ;
      private DateTime A140WWPDiscussionMessageDate ;
      private DateTime i140WWPDiscussionMessageDate ;
      private DateTime ZZ140WWPDiscussionMessageDate ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool n136WWPDiscussionMessageThreadId ;
      private bool wbErr ;
      private bool A52WWPUserExtendedPhoto_IsBlob ;
      private bool Gx_longc ;
      private string Z141WWPDiscussionMessageMessage ;
      private string Z142WWPDiscussionMessageEntityReco ;
      private string A141WWPDiscussionMessageMessage ;
      private string A40000WWPUserExtendedPhoto_GXI ;
      private string A50WWPUserExtendedFullName ;
      private string A63WWPEntityName ;
      private string A142WWPDiscussionMessageEntityReco ;
      private string Z40000WWPUserExtendedPhoto_GXI ;
      private string Z50WWPUserExtendedFullName ;
      private string Z63WWPEntityName ;
      private string ZZ141WWPDiscussionMessageMessage ;
      private string ZZ142WWPDiscussionMessageEntityReco ;
      private string ZZ40000WWPUserExtendedPhoto_GXI ;
      private string ZZ50WWPUserExtendedFullName ;
      private string ZZ63WWPEntityName ;
      private string A52WWPUserExtendedPhoto ;
      private string Z52WWPUserExtendedPhoto ;
      private string ZZ52WWPUserExtendedPhoto ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private IDataStoreProvider pr_default ;
      private string[] T000G4_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G4_A50WWPUserExtendedFullName ;
      private string[] T000G4_A52WWPUserExtendedPhoto ;
      private long[] T000G7_A137WWPDiscussionMessageId ;
      private DateTime[] T000G7_A140WWPDiscussionMessageDate ;
      private string[] T000G7_A141WWPDiscussionMessageMessage ;
      private string[] T000G7_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G7_A50WWPUserExtendedFullName ;
      private string[] T000G7_A63WWPEntityName ;
      private string[] T000G7_A142WWPDiscussionMessageEntityReco ;
      private string[] T000G7_A49WWPUserExtendedId ;
      private long[] T000G7_A62WWPEntityId ;
      private long[] T000G7_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G7_n136WWPDiscussionMessageThreadId ;
      private string[] T000G7_A52WWPUserExtendedPhoto ;
      private long[] T000G6_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G6_n136WWPDiscussionMessageThreadId ;
      private string[] T000G5_A63WWPEntityName ;
      private long[] T000G8_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G8_n136WWPDiscussionMessageThreadId ;
      private string[] T000G9_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G9_A50WWPUserExtendedFullName ;
      private string[] T000G9_A52WWPUserExtendedPhoto ;
      private string[] T000G10_A63WWPEntityName ;
      private long[] T000G11_A137WWPDiscussionMessageId ;
      private long[] T000G3_A137WWPDiscussionMessageId ;
      private DateTime[] T000G3_A140WWPDiscussionMessageDate ;
      private string[] T000G3_A141WWPDiscussionMessageMessage ;
      private string[] T000G3_A142WWPDiscussionMessageEntityReco ;
      private string[] T000G3_A49WWPUserExtendedId ;
      private long[] T000G3_A62WWPEntityId ;
      private long[] T000G3_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G3_n136WWPDiscussionMessageThreadId ;
      private long[] T000G12_A137WWPDiscussionMessageId ;
      private long[] T000G13_A137WWPDiscussionMessageId ;
      private long[] T000G2_A137WWPDiscussionMessageId ;
      private DateTime[] T000G2_A140WWPDiscussionMessageDate ;
      private string[] T000G2_A141WWPDiscussionMessageMessage ;
      private string[] T000G2_A142WWPDiscussionMessageEntityReco ;
      private string[] T000G2_A49WWPUserExtendedId ;
      private long[] T000G2_A62WWPEntityId ;
      private long[] T000G2_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G2_n136WWPDiscussionMessageThreadId ;
      private long[] T000G15_A137WWPDiscussionMessageId ;
      private string[] T000G18_A40000WWPUserExtendedPhoto_GXI ;
      private string[] T000G18_A50WWPUserExtendedFullName ;
      private string[] T000G18_A52WWPUserExtendedPhoto ;
      private string[] T000G19_A63WWPEntityName ;
      private long[] T000G20_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G20_n136WWPDiscussionMessageThreadId ;
      private long[] T000G21_A137WWPDiscussionMessageId ;
      private string[] T000G21_A138WWPDiscussionMentionUserId ;
      private long[] T000G22_A137WWPDiscussionMessageId ;
      private long[] T000G23_A136WWPDiscussionMessageThreadId ;
      private bool[] T000G23_n136WWPDiscussionMessageThreadId ;
      private IDataStoreProvider pr_gam ;
      private GXWebForm Form ;
   }

   public class wwp_discussionmessage__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class wwp_discussionmessage__default : DataStoreHelperBase, IDataStoreHelper
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
       ,new ForEachCursor(def[20])
       ,new ForEachCursor(def[21])
     };
  }

  private static CursorDef[] def;
  private void cursorDefinitions( )
  {
     if ( def == null )
     {
        Object[] prmT000G7;
        prmT000G7 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G6;
        prmT000G6 = new Object[] {
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000G4;
        prmT000G4 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmT000G5;
        prmT000G5 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000G8;
        prmT000G8 = new Object[] {
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000G9;
        prmT000G9 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmT000G10;
        prmT000G10 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        Object[] prmT000G11;
        prmT000G11 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G3;
        prmT000G3 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G12;
        prmT000G12 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G13;
        prmT000G13 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G2;
        prmT000G2 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G14;
        prmT000G14 = new Object[] {
        new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
        new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000G15;
        prmT000G15 = new Object[] {
        };
        Object[] prmT000G16;
        prmT000G16 = new Object[] {
        new ParDef("WWPDiscussionMessageDate",GXType.DateTime,8,5) ,
        new ParDef("WWPDiscussionMessageMessage",GXType.VarChar,400,0) ,
        new ParDef("WWPDiscussionMessageEntityReco",GXType.VarChar,100,0) ,
        new ParDef("WWPUserExtendedId",GXType.Char,40,0) ,
        new ParDef("WWPEntityId",GXType.Int64,10,0) ,
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true} ,
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G17;
        prmT000G17 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G20;
        prmT000G20 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G21;
        prmT000G21 = new Object[] {
        new ParDef("WWPDiscussionMessageId",GXType.Int64,10,0)
        };
        Object[] prmT000G22;
        prmT000G22 = new Object[] {
        };
        Object[] prmT000G23;
        prmT000G23 = new Object[] {
        new ParDef("WWPDiscussionMessageThreadId",GXType.Int64,10,0){Nullable=true}
        };
        Object[] prmT000G18;
        prmT000G18 = new Object[] {
        new ParDef("WWPUserExtendedId",GXType.Char,40,0)
        };
        Object[] prmT000G19;
        prmT000G19 = new Object[] {
        new ParDef("WWPEntityId",GXType.Int64,10,0)
        };
        def= new CursorDef[] {
            new CursorDef("T000G2", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId  FOR UPDATE OF WWP_DiscussionMessage NOWAIT",true, GxErrorMask.GX_NOMASK, false, this,prmT000G2,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G3", "SELECT WWPDiscussionMessageId, WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G3,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G4", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G4,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G5", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G5,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G6", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G6,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G7", "SELECT TM1.WWPDiscussionMessageId, TM1.WWPDiscussionMessageDate, TM1.WWPDiscussionMessageMessage, T2.WWPUserExtendedPhoto_GXI, T2.WWPUserExtendedFullName, T3.WWPEntityName, TM1.WWPDiscussionMessageEntityReco, TM1.WWPUserExtendedId, TM1.WWPEntityId, TM1.WWPDiscussionMessageThreadId AS WWPDiscussionMessageThreadId, T2.WWPUserExtendedPhoto FROM ((WWP_DiscussionMessage TM1 INNER JOIN WWP_UserExtended T2 ON T2.WWPUserExtendedId = TM1.WWPUserExtendedId) INNER JOIN WWP_Entity T3 ON T3.WWPEntityId = TM1.WWPEntityId) WHERE TM1.WWPDiscussionMessageId = :WWPDiscussionMessageId ORDER BY TM1.WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G7,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G8", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G8,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G9", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G9,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G10", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G10,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G11", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G11,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G12", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE ( WWPDiscussionMessageId > :WWPDiscussionMessageId) ORDER BY WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G12,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G13", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage WHERE ( WWPDiscussionMessageId < :WWPDiscussionMessageId) ORDER BY WWPDiscussionMessageId DESC ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G13,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G14", "SAVEPOINT gxupdate;INSERT INTO WWP_DiscussionMessage(WWPDiscussionMessageDate, WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco, WWPUserExtendedId, WWPEntityId, WWPDiscussionMessageThreadId) VALUES(:WWPDiscussionMessageDate, :WWPDiscussionMessageMessage, :WWPDiscussionMessageEntityReco, :WWPUserExtendedId, :WWPEntityId, :WWPDiscussionMessageThreadId);RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G14)
           ,new CursorDef("T000G15", "SELECT currval('WWPDiscussionMessageId') ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G15,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G16", "SAVEPOINT gxupdate;UPDATE WWP_DiscussionMessage SET WWPDiscussionMessageDate=:WWPDiscussionMessageDate, WWPDiscussionMessageMessage=:WWPDiscussionMessageMessage, WWPDiscussionMessageEntityReco=:WWPDiscussionMessageEntityReco, WWPUserExtendedId=:WWPUserExtendedId, WWPEntityId=:WWPEntityId, WWPDiscussionMessageThreadId=:WWPDiscussionMessageThreadId  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G16)
           ,new CursorDef("T000G17", "SAVEPOINT gxupdate;DELETE FROM WWP_DiscussionMessage  WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId;RELEASE SAVEPOINT gxupdate", GxErrorMask.GX_ROLLBACKSAVEPOINT | GxErrorMask.GX_NOMASK,prmT000G17)
           ,new CursorDef("T000G18", "SELECT WWPUserExtendedPhoto_GXI, WWPUserExtendedFullName, WWPUserExtendedPhoto FROM WWP_UserExtended WHERE WWPUserExtendedId = :WWPUserExtendedId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G18,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G19", "SELECT WWPEntityName FROM WWP_Entity WHERE WWPEntityId = :WWPEntityId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G19,1, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G20", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageThreadId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G20,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G21", "SELECT WWPDiscussionMessageId, WWPDiscussionMentionUserId FROM WWP_DiscussionMessageMention WHERE WWPDiscussionMessageId = :WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G21,1, GxCacheFrequency.OFF ,true,true )
           ,new CursorDef("T000G22", "SELECT WWPDiscussionMessageId FROM WWP_DiscussionMessage ORDER BY WWPDiscussionMessageId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G22,100, GxCacheFrequency.OFF ,true,false )
           ,new CursorDef("T000G23", "SELECT WWPDiscussionMessageId AS WWPDiscussionMessageThreadId FROM WWP_DiscussionMessage WHERE WWPDiscussionMessageId = :WWPDiscussionMessageThreadId ",true, GxErrorMask.GX_NOMASK, false, this,prmT000G23,1, GxCacheFrequency.OFF ,true,false )
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
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 1 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getVarchar(4);
              ((string[]) buf[4])[0] = rslt.getString(5, 40);
              ((long[]) buf[5])[0] = rslt.getLong(6);
              ((long[]) buf[6])[0] = rslt.getLong(7);
              ((bool[]) buf[7])[0] = rslt.wasNull(7);
              return;
           case 2 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 3 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 4 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 5 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((DateTime[]) buf[1])[0] = rslt.getGXDateTime(2);
              ((string[]) buf[2])[0] = rslt.getVarchar(3);
              ((string[]) buf[3])[0] = rslt.getMultimediaUri(4);
              ((string[]) buf[4])[0] = rslt.getVarchar(5);
              ((string[]) buf[5])[0] = rslt.getVarchar(6);
              ((string[]) buf[6])[0] = rslt.getVarchar(7);
              ((string[]) buf[7])[0] = rslt.getString(8, 40);
              ((long[]) buf[8])[0] = rslt.getLong(9);
              ((long[]) buf[9])[0] = rslt.getLong(10);
              ((bool[]) buf[10])[0] = rslt.wasNull(10);
              ((string[]) buf[11])[0] = rslt.getMultimediaFile(11, rslt.getVarchar(4));
              return;
           case 6 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 7 :
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
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
              ((string[]) buf[0])[0] = rslt.getMultimediaUri(1);
              ((string[]) buf[1])[0] = rslt.getVarchar(2);
              ((string[]) buf[2])[0] = rslt.getMultimediaFile(3, rslt.getVarchar(1));
              return;
           case 17 :
              ((string[]) buf[0])[0] = rslt.getVarchar(1);
              return;
           case 18 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 19 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              ((string[]) buf[1])[0] = rslt.getString(2, 40);
              return;
           case 20 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
           case 21 :
              ((long[]) buf[0])[0] = rslt.getLong(1);
              return;
     }
  }

}

}
