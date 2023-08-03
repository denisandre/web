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
namespace GeneXus.Programs {
   public class gamrepositoryentry : GXDataArea
   {
      public gamrepositoryentry( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
         IsMain = true;
         context.SetDefaultTheme("WorkWithPlusDS", true);
      }

      public gamrepositoryentry( IGxContext context )
      {
         this.context = context;
         IsMain = false;
         dsGAM = context.GetDataStore("GAM");
         dsDefault = context.GetDataStore("Default");
      }

      public void execute( ref string aP0_Gx_mode ,
                           ref int aP1_Id )
      {
         this.Gx_mode = aP0_Gx_mode;
         this.AV30Id = aP1_Id;
         executePrivate();
         aP0_Gx_mode=this.Gx_mode;
         aP1_Id=this.AV30Id;
      }

      void executePrivate( )
      {
         isStatic = false;
         webExecute();
      }

      protected override void createObjects( )
      {
         chkavUsecurrentrepositorasmasterauthentication = new GXCheckbox();
         cmbavGeneratesessionstatistics = new GXCombobox();
         chkavAllowoauthaccess = new GXCheckbox();
         chkavCanregisterusers = new GXCheckbox();
         chkavGiveanonymoussession = new GXCheckbox();
         chkavIsgamadminaccessrepository = new GXCheckbox();
         chkavCreategamapplication = new GXCheckbox();
         cmbavCopyfromrepositoryid = new GXCombobox();
         chkavCopyroles = new GXCheckbox();
         chkavCopysecuritypolicies = new GXCheckbox();
         chkavCopyapplication = new GXCheckbox();
         chkavCopyapplicationrolepermissions = new GXCheckbox();
         chkavUpdateconnectionfile = new GXCheckbox();
      }

      protected void INITWEB( )
      {
         initialize_properties( ) ;
         if ( nGotPars == 0 )
         {
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
         }
         if ( ! context.IsLocalStorageSupported( ) )
         {
            context.PushCurrentUrl();
         }
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
            return "gamrepositoryentry_Execute" ;
         }

      }

      public override void webExecute( )
      {
         if ( initialized == 0 )
         {
            createObjects();
            initialize();
         }
         INITWEB( ) ;
         if ( ! isAjaxCallMode( ) )
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

      public override short ExecuteStartEvent( )
      {
         PA1O2( ) ;
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            START1O2( ) ;
         }
         return gxajaxcallmode ;
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
         if ( nGXWrapped != 1 )
         {
            MasterPageObj.master_styles();
         }
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
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
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
         if ( nGXWrapped == 0 )
         {
            bodyStyle += "-moz-opacity:0;opacity:0;";
         }
         if ( ! ( String.IsNullOrEmpty(StringUtil.RTrim( Form.Background)) ) )
         {
            bodyStyle += " background-image:url(" + context.convertURL( Form.Background) + ")";
         }
         context.WriteHtmlText( " "+"class=\"form-horizontal Form\""+" "+ "style='"+bodyStyle+"'") ;
         context.WriteHtmlText( FormProcess+">") ;
         context.skipLines(1);
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         GXEncryptionTmp = "gamrepositoryentry.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV30Id,9,0));
         context.WriteHtmlTextNl( "<form id=\"MAINFORM\" autocomplete=\"off\" name=\"MAINFORM\" method=\"post\" tabindex=-1  class=\"form-horizontal Form\" data-gx-class=\"form-horizontal Form\" novalidate action=\""+formatLink("gamrepositoryentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey)+"\">") ;
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
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
      }

      protected void SendCloseFormHiddens( )
      {
         /* Send hidden variables. */
         /* Send saved values. */
         send_integrity_footer_hashes( ) ;
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Pagecount", StringUtil.LTrim( StringUtil.NToC( (decimal)(Gxuitabspanel_tabs_Pagecount), 9, 0, ".", "")));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Class", StringUtil.RTrim( Gxuitabspanel_tabs_Class));
         GxWebStd.gx_hidden_field( context, "GXUITABSPANEL_TABS_Historymanagement", StringUtil.BoolToStr( Gxuitabspanel_tabs_Historymanagement));
      }

      public override void RenderHtmlCloseForm( )
      {
         SendCloseFormHiddens( ) ;
         GxWebStd.gx_hidden_field( context, "GX_FocusControl", GX_FocusControl);
         SendAjaxEncryptionKey();
         SendSecurityToken((string)(sPrefix));
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

      public override void RenderHtmlContent( )
      {
         gxajaxcallmode = (short)((isAjaxCallMode( ) ? 1 : 0));
         if ( ( gxajaxcallmode == 0 ) && ( GxWebError == 0 ) )
         {
            context.WriteHtmlText( "<div") ;
            GxWebStd.ClassAttribute( context, "gx-ct-body"+" "+(String.IsNullOrEmpty(StringUtil.RTrim( Form.Class)) ? "form-horizontal Form" : Form.Class)+"-fx");
            context.WriteHtmlText( ">") ;
            WE1O2( ) ;
            context.WriteHtmlText( "</div>") ;
         }
      }

      public override void DispatchEvents( )
      {
         EVT1O2( ) ;
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
         GXEncryptionTmp = "gamrepositoryentry.aspx"+UrlEncode(StringUtil.RTrim(Gx_mode)) + "," + UrlEncode(StringUtil.LTrimStr(AV30Id,9,0));
         return formatLink("gamrepositoryentry.aspx") + "?" + UriEncrypt64( GXEncryptionTmp+Crypto.CheckSum( GXEncryptionTmp, 6), GXKey) ;
      }

      public override string GetPgmname( )
      {
         return "GAMRepositoryEntry" ;
      }

      public override string GetPgmdesc( )
      {
         return "Repository " ;
      }

      protected void WB1O0( )
      {
         if ( context.isAjaxRequest( ) )
         {
            disableOutput();
         }
         if ( ! wbLoad )
         {
            if ( nGXWrapped == 1 )
            {
               RenderHtmlHeaders( ) ;
               RenderHtmlOpenForm( ) ;
            }
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", " "+"data-gx-base-lib=\"bootstrapv3\""+" "+"data-abstract-form"+" ", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divLayoutmaintable_Internalname, 1, 0, "px", 0, "px", "Table TableTransactionTemplate", "start", "top", "", "", "div");
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
            GxWebStd.gx_div_start( context, divTablecontent_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* User Defined Control */
            ucGxuitabspanel_tabs.SetProperty("PageCount", Gxuitabspanel_tabs_Pagecount);
            ucGxuitabspanel_tabs.SetProperty("Class", Gxuitabspanel_tabs_Class);
            ucGxuitabspanel_tabs.SetProperty("HistoryManagement", Gxuitabspanel_tabs_Historymanagement);
            ucGxuitabspanel_tabs.Render(context, "tab", Gxuitabspanel_tabs_Internalname, "GXUITABSPANEL_TABSContainer");
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title1"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblGeneral_title_Internalname, "Geral", "", "", lblGeneral_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRepositoryEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "General") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel1"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divTableattributes_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divGuid_cell_Internalname, 1, 0, "px", 0, "px", divGuid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavGuid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavGuid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavGuid_Internalname, "Guid", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 25,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavGuid_Internalname, StringUtil.RTrim( AV29GUID), StringUtil.RTrim( context.localUtil.Format( AV29GUID, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,25);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavGuid_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavGuid_Visible, edtavGuid_Enabled, 1, "text", "", 40, "chr", 1, "row", 40, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMGUID", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavName_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavName_Internalname, "Nome", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 30,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavName_Internalname, StringUtil.RTrim( AV33Name), StringUtil.RTrim( context.localUtil.Format( AV33Name, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,30);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavName_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavName_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionShort", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavDescription_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavDescription_Internalname, "Descri��o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 35,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavDescription_Internalname, StringUtil.RTrim( AV21Description), StringUtil.RTrim( context.localUtil.Format( AV21Description, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,35);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavDescription_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavDescription_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMDescriptionLong", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divUsecurrentrepositorasmasterauthentication_cell_Internalname, 1, 0, "px", 0, "px", divUsecurrentrepositorasmasterauthentication_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", chkavUsecurrentrepositorasmasterauthentication.Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavUsecurrentrepositorasmasterauthentication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavUsecurrentrepositorasmasterauthentication_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 40,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUsecurrentrepositorasmasterauthentication_Internalname, StringUtil.BoolToStr( AV42UseCurrentRepositorAsMasterAuthentication), "", " ", chkavUsecurrentrepositorasmasterauthentication.Visible, chkavUsecurrentrepositorasmasterauthentication.Enabled, "true", "Use o reposit�rio atual como o reposit�rio mestre de autentica��o", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,40);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divNamespace_cell_Internalname, 1, 0, "px", 0, "px", divNamespace_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavNamespace_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavNamespace_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavNamespace_Internalname, "Namespace", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 45,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavNamespace_Internalname, StringUtil.RTrim( AV34Namespace), StringUtil.RTrim( context.localUtil.Format( AV34Namespace, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,45);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavNamespace_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavNamespace_Visible, edtavNamespace_Enabled, 1, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMRepositoryNameSpace", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavGeneratesessionstatistics_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavGeneratesessionstatistics_Internalname, "Gerar estat�sticas da sess�o?", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 50,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavGeneratesessionstatistics, cmbavGeneratesessionstatistics_Internalname, StringUtil.RTrim( AV27GenerateSessionStatistics), 1, cmbavGeneratesessionstatistics_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "char", "", 1, cmbavGeneratesessionstatistics.Enabled, 1, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,50);\"", "", true, 0, "HLP_GAMRepositoryEntry.htm");
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV27GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", (string)(cmbavGeneratesessionstatistics.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavAllowoauthaccess_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 55,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavAllowoauthaccess_Internalname, StringUtil.BoolToStr( AV8AllowOauthAccess), "", "", 1, chkavAllowoauthaccess.Enabled, "true", "Permitir o acesso oauth", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(55, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,55);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCanregisterusers_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 60,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCanregisterusers_Internalname, StringUtil.BoolToStr( AV45CanRegisterUsers), "", "", 1, chkavCanregisterusers.Enabled, "true", "Voc� pode registrar usu�rios?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(60, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,60);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavGiveanonymoussession_Internalname+"\"", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 65,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavGiveanonymoussession_Internalname, StringUtil.BoolToStr( AV28GiveAnonymousSession), "", "", 1, chkavGiveanonymoussession.Enabled, "true", "Dar sess�o an�nima?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(65, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,65);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divTbluserssettings_Internalname, divTbluserssettings_Visible, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConnectionusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionusername_Internalname, "Nome do usu�rio da conex�o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 73,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionusername_Internalname, StringUtil.RTrim( AV12ConnectionUserName), StringUtil.RTrim( context.localUtil.Format( AV12ConnectionUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,73);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionusername_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConnectionusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConnectionuserpassword_Internalname, "Senha do usu�rio de conex�o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 78,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConnectionuserpassword_Internalname, StringUtil.RTrim( AV13ConnectionUserPassword), StringUtil.RTrim( context.localUtil.Format( AV13ConnectionUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,78);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConnectionuserpassword_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConnectionuserpassword_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConfconnectionuserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfconnectionuserpassword_Internalname, "Confirme a senha do usu�rio da conex�o", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 83,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfconnectionuserpassword_Internalname, StringUtil.RTrim( AV11ConfConnectionUserPassword), StringUtil.RTrim( context.localUtil.Format( AV11ConfConnectionUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,83);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfconnectionuserpassword_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavConfconnectionuserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAuthenticationmasterauthtypename_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAuthenticationmasterauthtypename_Internalname, "Nome do tipo de autentica��o no tenant atual", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 88,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAuthenticationmasterauthtypename_Internalname, StringUtil.RTrim( AV9AuthenticationMasterAuthTypeName), StringUtil.RTrim( context.localUtil.Format( AV9AuthenticationMasterAuthTypeName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,88);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAuthenticationmasterauthtypename_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAuthenticationmasterauthtypename_Enabled, 0, "text", "", 60, "chr", 1, "row", 60, 0, 0, 0, 0, -1, -1, true, "GeneXusSecurityCommon\\GAMAuthenticationTypeName", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAdministratorusername_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratorusername_Internalname, edtavAdministratorusername_Caption, "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 93,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratorusername_Internalname, StringUtil.RTrim( AV6AdministratorUserName), StringUtil.RTrim( context.localUtil.Format( AV6AdministratorUserName, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,93);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratorusername_Jsonclick, 0, "AttributeFL", "", "", "", "", 1, edtavAdministratorusername_Enabled, 1, "text", "", 80, "chr", 1, "row", 100, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMConnectionUser", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavAdministratoruserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAdministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratoruserpassword_Internalname, "Senha do usu�rio do administrador.", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 98,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratoruserpassword_Internalname, StringUtil.RTrim( AV7AdministratorUserPassword), StringUtil.RTrim( context.localUtil.Format( AV7AdministratorUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,98);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratoruserpassword_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavAdministratoruserpassword_Visible, edtavAdministratoruserpassword_Enabled, 1, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavConfadministratoruserpassword_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavConfadministratoruserpassword_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavConfadministratoruserpassword_Internalname, "Confirme a senha do usu�rio do administrador", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 103,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavConfadministratoruserpassword_Internalname, StringUtil.RTrim( AV10ConfAdministratorUserPassword), StringUtil.RTrim( context.localUtil.Format( AV10ConfAdministratorUserPassword, "")), TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,103);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavConfadministratoruserpassword_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavConfadministratoruserpassword_Visible, edtavConfadministratoruserpassword_Enabled, 0, "text", "", 80, "chr", 1, "row", 254, 0, 0, 0, 0, -1, -1, true, "", "start", true, "", "HLP_GAMRepositoryEntry.htm");
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
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavIsgamadminaccessrepository_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavIsgamadminaccessrepository_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 108,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavIsgamadminaccessrepository_Internalname, StringUtil.BoolToStr( AV31isGAMAdminAccessRepository), "", " ", 1, chkavIsgamadminaccessrepository.Enabled, "true", "O usu�rio atual � um administrador do novo reposit�rio?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(108, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,108);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCreategamapplication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCreategamapplication_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 113,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCreategamapplication_Internalname, StringUtil.BoolToStr( AV20CreateGAMApplication), "", " ", 1, chkavCreategamapplication.Enabled, "true", "Criar aplicativo de back-end do gam?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(113, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,113);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"title2"+"\" style=\"display:none;\">") ;
            /* Text block */
            GxWebStd.gx_label_ctrl( context, lblCopyrepdata_title_Internalname, "Copie os dados do reposit�rio", "", "", lblCopyrepdata_title_Jsonclick, "'"+""+"'"+",false,"+"'"+""+"'", "", "TextBlock", 0, "", 1, 1, 0, 0, "HLP_GAMRepositoryEntry.htm");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "Section", "start", "top", "", "display:none;", "div");
            context.WriteHtmlText( "CopyRepData") ;
            GxWebStd.gx_div_end( context, "start", "top", "div");
            context.WriteHtmlText( "</div>") ;
            context.WriteHtmlText( "<div class=\"gx_usercontrol_child\" id=\""+"GXUITABSPANEL_TABSContainer"+"panel2"+"\" style=\"display:none;\">") ;
            /* Div Control */
            GxWebStd.gx_div_start( context, divUnnamedtable1_Internalname, 1, 0, "px", 0, "px", "Table", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+cmbavCopyfromrepositoryid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, cmbavCopyfromrepositoryid_Internalname, "Copiar do ID do reposit�rio.", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 123,'',false,'',0)\"";
            /* ComboBox */
            GxWebStd.gx_combobox_ctrl1( context, cmbavCopyfromrepositoryid, cmbavCopyfromrepositoryid_Internalname, StringUtil.Trim( StringUtil.Str( (decimal)(AV17CopyFromRepositoryId), 9, 0)), 1, cmbavCopyfromrepositoryid_Jsonclick, 0, "'"+""+"'"+",false,"+"'"+""+"'", "int", "", 1, cmbavCopyfromrepositoryid.Enabled, 0, 0, 0, "em", 0, "", "", "AttributeFL", "", "", TempTags+" onchange=\""+""+";gx.evt.onchange(this, event)\" "+" onblur=\""+""+";gx.evt.onblur(this,123);\"", "", true, 0, "HLP_GAMRepositoryEntry.htm");
            cmbavCopyfromrepositoryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17CopyFromRepositoryId), 9, 0));
            AssignProp("", false, cmbavCopyfromrepositoryid_Internalname, "Values", (string)(cmbavCopyfromrepositoryid.ToJavascriptSource()), true);
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCopyroles_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyroles_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 128,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyroles_Internalname, StringUtil.BoolToStr( AV18CopyRoles), "", " ", 1, chkavCopyroles.Enabled, "true", "Copiar fun��es?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,128);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divAdministratorroleid_cell_Internalname, 1, 0, "px", 0, "px", divAdministratorroleid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavAdministratorroleid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavAdministratorroleid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavAdministratorroleid_Internalname, "ID do perfil do administrador", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 133,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavAdministratorroleid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV5AdministratorRoleId), 12, 0, ",", "")), StringUtil.LTrim( ((edtavAdministratorroleid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV5AdministratorRoleId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV5AdministratorRoleId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,133);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavAdministratorroleid_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavAdministratorroleid_Visible, edtavAdministratorroleid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCopysecuritypolicies_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopysecuritypolicies_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 138,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopysecuritypolicies_Internalname, StringUtil.BoolToStr( AV19CopySecurityPolicies), "", " ", 1, chkavCopysecuritypolicies.Enabled, "true", "Copiar pol�ticas de seguran�a?", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(138, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,138);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCopyapplication_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyapplication_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 143,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyapplication_Internalname, StringUtil.BoolToStr( AV14CopyApplication), "", " ", 1, chkavCopyapplication.Enabled, "true", "Copiar aplicativo? (Menus e permiss�es)", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,143);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, divCopyfromapplicationid_cell_Internalname, 1, 0, "px", 0, "px", divCopyfromapplicationid_cell_Class, "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", edtavCopyfromapplicationid_Visible, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+edtavCopyfromapplicationid_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, edtavCopyfromapplicationid_Internalname, "Copiar do ID do aplicativo.", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Single line edit */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 148,'',false,'',0)\"";
            GxWebStd.gx_single_line_edit( context, edtavCopyfromapplicationid_Internalname, StringUtil.LTrim( StringUtil.NToC( (decimal)(AV16CopyFromApplicationId), 12, 0, ",", "")), StringUtil.LTrim( ((edtavCopyfromapplicationid_Enabled!=0) ? context.localUtil.Format( (decimal)(AV16CopyFromApplicationId), "ZZZZZZZZZZZ9") : context.localUtil.Format( (decimal)(AV16CopyFromApplicationId), "ZZZZZZZZZZZ9"))), " dir=\"ltr\" inputmode=\"numeric\" pattern=\"[0-9]*\""+TempTags+" onchange=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onchange(this, event)\" "+" onblur=\""+"gx.num.valid_integer( this,'.');"+";gx.evt.onblur(this,148);\"", "'"+""+"'"+",false,"+"'"+""+"'", "", "", "", "", edtavCopyfromapplicationid_Jsonclick, 0, "AttributeFL", "", "", "", "", edtavCopyfromapplicationid_Visible, edtavCopyfromapplicationid_Enabled, 0, "text", "1", 12, "chr", 1, "row", 12, 0, 0, 0, 0, -1, 0, true, "GeneXusSecurityCommon\\GAMKeyNumLong", "end", false, "", "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "row", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-xs-12 DataContentCellFL", "start", "top", "", "", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "form-group gx-form-group", "start", "top", ""+" data-gx-for=\""+chkavCopyapplicationrolepermissions_Internalname+"\"", "", "div");
            /* Attribute/Variable Label */
            GxWebStd.gx_label_element( context, chkavCopyapplicationrolepermissions_Internalname, " ", "col-sm-3 AttributeFLLabel", 1, true, "");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "col-sm-9 gx-attribute", "start", "top", "", "", "div");
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 153,'',false,'',0)\"";
            ClassString = "AttributeFL";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavCopyapplicationrolepermissions_Internalname, StringUtil.BoolToStr( AV15CopyApplicationRolePermissions), "", " ", 1, chkavCopyapplicationrolepermissions.Enabled, "true", "Copiar as permiss�es de fun��es?", StyleString, ClassString, "", "", TempTags+" onblur=\""+""+";gx.evt.onblur(this,153);\"");
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
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 158,'',false,'',0)\"";
            ClassString = "ButtonMaterial";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtnenter_Internalname, "", bttBtnenter_Caption, bttBtnenter_Jsonclick, 5, "Confirmar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"EENTER."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryEntry.htm");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            /* Div Control */
            GxWebStd.gx_div_start( context, "", 1, 0, "px", 0, "px", "gx-button", "start", "top", "", "", "div");
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 160,'',false,'',0)\"";
            ClassString = "ButtonMaterialDefault";
            StyleString = "";
            GxWebStd.gx_button_ctrl( context, bttBtncancel_Internalname, "", "Fechar", bttBtncancel_Jsonclick, 1, "Fechar", "", StyleString, ClassString, 1, 1, "standard", "'"+""+"'"+",false,"+"'"+"ECANCEL."+"'", TempTags, "", context.GetButtonType( ), "HLP_GAMRepositoryEntry.htm");
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
            /* Check box */
            TempTags = "  onfocus=\"gx.evt.onfocus(this, 164,'',false,'',0)\"";
            ClassString = "Attribute";
            StyleString = "";
            GxWebStd.gx_checkbox_ctrl( context, chkavUpdateconnectionfile_Internalname, StringUtil.BoolToStr( AV41UpdateConnectionFile), "", "", chkavUpdateconnectionfile.Visible, 1, "true", "", StyleString, ClassString, "", "", TempTags+" onclick="+"\"gx.fn.checkboxClick(164, this, 'true', 'false',"+"''"+");"+"gx.evt.onchange(this, event);\""+" onblur=\""+""+";gx.evt.onblur(this,164);\"");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
            GxWebStd.gx_div_end( context, "start", "top", "div");
         }
         wbLoad = true;
      }

      protected void START1O2( )
      {
         wbLoad = false;
         wbEnd = 0;
         wbStart = 0;
         if ( ! context.isSpaRequest( ) )
         {
            if ( context.ExposeMetadata( ) )
            {
               Form.Meta.addItem("generator", "GeneXus .NET 18_0_4-173650", 0) ;
            }
            Form.Meta.addItem("description", "Repository ", 0) ;
         }
         context.wjLoc = "";
         context.nUserReturn = 0;
         context.wbHandled = 0;
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
         }
         wbErr = false;
         STRUP1O0( ) ;
      }

      protected void WS1O2( )
      {
         START1O2( ) ;
         EVT1O2( ) ;
      }

      protected void EVT1O2( )
      {
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) && ! wbErr )
            {
               /* Read Web Panel buttons. */
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
                           if ( StringUtil.StrCmp(sEvt, "RFR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                           }
                           else if ( StringUtil.StrCmp(sEvt, "START") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Start */
                              E111O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "ENTER") == 0 )
                           {
                              context.wbHandled = 1;
                              if ( ! wbErr )
                              {
                                 Rfr0gs = false;
                                 if ( ! Rfr0gs )
                                 {
                                    /* Execute user event: Enter */
                                    E121O2 ();
                                 }
                                 dynload_actions( ) ;
                              }
                           }
                           else if ( StringUtil.StrCmp(sEvt, "VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              E131O2 ();
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LOAD") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              /* Execute user event: Load */
                              E141O2 ();
                              /* No code required for Cancel button. It is implemented as the Reset button. */
                           }
                           else if ( StringUtil.StrCmp(sEvt, "LSCR") == 0 )
                           {
                              context.wbHandled = 1;
                              dynload_actions( ) ;
                              dynload_actions( ) ;
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
      }

      protected void WE1O2( )
      {
         if ( ! GxWebStd.gx_redirect( context) )
         {
            Rfr0gs = true;
            Refresh( ) ;
            if ( ! GxWebStd.gx_redirect( context) )
            {
               if ( nGXWrapped == 1 )
               {
                  RenderHtmlCloseForm( ) ;
               }
            }
         }
      }

      protected void PA1O2( )
      {
         if ( nDonePA == 0 )
         {
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
               if ( ( StringUtil.StrCmp(StringUtil.Right( GXDecQS, 6), Crypto.CheckSum( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), 6)) == 0 ) && ( StringUtil.StrCmp(StringUtil.Substring( GXDecQS, 1, StringUtil.Len( "gamrepositoryentry.aspx")), "gamrepositoryentry.aspx") == 0 ) )
               {
                  SetQueryString( StringUtil.Right( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)), (short)(StringUtil.Len( StringUtil.Left( GXDecQS, (short)(StringUtil.Len( GXDecQS)-6)))-StringUtil.Len( "gamrepositoryentry.aspx")))) ;
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
               if ( nGotPars == 0 )
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
                        AV30Id = (int)(Math.Round(NumberUtil.Val( GetPar( "Id"), "."), 18, MidpointRounding.ToEven));
                        AssignAttri("", false, "AV30Id", StringUtil.LTrimStr( (decimal)(AV30Id), 9, 0));
                        GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30Id), "ZZZZZZZZ9"), context));
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
            if ( ! context.isAjaxRequest( ) )
            {
               GX_FocusControl = edtavGuid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
            }
            nDonePA = 1;
         }
      }

      protected void dynload_actions( )
      {
         /* End function dynload_actions */
      }

      protected void send_integrity_hashes( )
      {
      }

      protected void clear_multi_value_controls( )
      {
         if ( context.isAjaxRequest( ) )
         {
            dynload_actions( ) ;
            before_start_formulas( ) ;
         }
      }

      protected void fix_multi_value_controls( )
      {
         AV42UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV42UseCurrentRepositorAsMasterAuthentication));
         AssignAttri("", false, "AV42UseCurrentRepositorAsMasterAuthentication", AV42UseCurrentRepositorAsMasterAuthentication);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV27GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV27GenerateSessionStatistics);
            AssignAttri("", false, "AV27GenerateSessionStatistics", AV27GenerateSessionStatistics);
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavGeneratesessionstatistics.CurrentValue = StringUtil.RTrim( AV27GenerateSessionStatistics);
            AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Values", cmbavGeneratesessionstatistics.ToJavascriptSource(), true);
         }
         AV8AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV8AllowOauthAccess));
         AssignAttri("", false, "AV8AllowOauthAccess", AV8AllowOauthAccess);
         AV45CanRegisterUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV45CanRegisterUsers));
         AssignAttri("", false, "AV45CanRegisterUsers", AV45CanRegisterUsers);
         AV28GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV28GiveAnonymousSession));
         AssignAttri("", false, "AV28GiveAnonymousSession", AV28GiveAnonymousSession);
         AV31isGAMAdminAccessRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV31isGAMAdminAccessRepository));
         AssignAttri("", false, "AV31isGAMAdminAccessRepository", AV31isGAMAdminAccessRepository);
         AV20CreateGAMApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV20CreateGAMApplication));
         AssignAttri("", false, "AV20CreateGAMApplication", AV20CreateGAMApplication);
         if ( cmbavCopyfromrepositoryid.ItemCount > 0 )
         {
            AV17CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cmbavCopyfromrepositoryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17CopyFromRepositoryId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV17CopyFromRepositoryId), 9, 0));
         }
         if ( context.isAjaxRequest( ) )
         {
            cmbavCopyfromrepositoryid.CurrentValue = StringUtil.Trim( StringUtil.Str( (decimal)(AV17CopyFromRepositoryId), 9, 0));
            AssignProp("", false, cmbavCopyfromrepositoryid_Internalname, "Values", cmbavCopyfromrepositoryid.ToJavascriptSource(), true);
         }
         AV18CopyRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV18CopyRoles));
         AssignAttri("", false, "AV18CopyRoles", AV18CopyRoles);
         AV19CopySecurityPolicies = StringUtil.StrToBool( StringUtil.BoolToStr( AV19CopySecurityPolicies));
         AssignAttri("", false, "AV19CopySecurityPolicies", AV19CopySecurityPolicies);
         AV14CopyApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV14CopyApplication));
         AssignAttri("", false, "AV14CopyApplication", AV14CopyApplication);
         AV15CopyApplicationRolePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV15CopyApplicationRolePermissions));
         AssignAttri("", false, "AV15CopyApplicationRolePermissions", AV15CopyApplicationRolePermissions);
         AV41UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV41UpdateConnectionFile));
         AssignAttri("", false, "AV41UpdateConnectionFile", AV41UpdateConnectionFile);
      }

      public void Refresh( )
      {
         send_integrity_hashes( ) ;
         RF1O2( ) ;
         if ( isFullAjaxMode( ) )
         {
            send_integrity_footer_hashes( ) ;
         }
      }

      protected void initialize_formulas( )
      {
         /* GeneXus formulas. */
      }

      protected void RF1O2( )
      {
         initialize_formulas( ) ;
         clear_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = true;
         fix_multi_value_controls( ) ;
         gxdyncontrolsrefreshing = false;
         if ( ! context.WillRedirect( ) && ( context.nUserReturn != 1 ) )
         {
            /* Execute user event: Load */
            E141O2 ();
            WB1O0( ) ;
         }
      }

      protected void send_integrity_lvl_hashes1O2( )
      {
         GxWebStd.gx_hidden_field( context, "vID", StringUtil.LTrim( StringUtil.NToC( (decimal)(AV30Id), 9, 0, ",", "")));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30Id), "ZZZZZZZZ9"), context));
         GxWebStd.gx_hidden_field( context, "vMODE", StringUtil.RTrim( Gx_mode));
         GxWebStd.gx_hidden_field( context, "gxhash_vMODE", GetSecureSignedToken( "", StringUtil.RTrim( context.localUtil.Format( Gx_mode, "@!")), context));
      }

      protected void before_start_formulas( )
      {
         fix_multi_value_controls( ) ;
      }

      protected void STRUP1O0( )
      {
         /* Before Start, stand alone formulas. */
         before_start_formulas( ) ;
         /* Execute Start event if defined. */
         context.wbGlbDoneStart = 0;
         /* Execute user event: Start */
         E111O2 ();
         context.wbGlbDoneStart = 1;
         /* After Start, stand alone formulas. */
         if ( StringUtil.StrCmp(context.GetRequestMethod( ), "POST") == 0 )
         {
            /* Read saved SDTs. */
            /* Read saved values. */
            Gx_mode = cgiGet( "vMODE");
            Gxuitabspanel_tabs_Pagecount = (int)(Math.Round(context.localUtil.CToN( cgiGet( "GXUITABSPANEL_TABS_Pagecount"), ",", "."), 18, MidpointRounding.ToEven));
            Gxuitabspanel_tabs_Class = cgiGet( "GXUITABSPANEL_TABS_Class");
            Gxuitabspanel_tabs_Historymanagement = StringUtil.StrToBool( cgiGet( "GXUITABSPANEL_TABS_Historymanagement"));
            /* Read variables values. */
            AV29GUID = cgiGet( edtavGuid_Internalname);
            AssignAttri("", false, "AV29GUID", AV29GUID);
            AV33Name = cgiGet( edtavName_Internalname);
            AssignAttri("", false, "AV33Name", AV33Name);
            AV21Description = cgiGet( edtavDescription_Internalname);
            AssignAttri("", false, "AV21Description", AV21Description);
            AV42UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( cgiGet( chkavUsecurrentrepositorasmasterauthentication_Internalname));
            AssignAttri("", false, "AV42UseCurrentRepositorAsMasterAuthentication", AV42UseCurrentRepositorAsMasterAuthentication);
            AV34Namespace = cgiGet( edtavNamespace_Internalname);
            AssignAttri("", false, "AV34Namespace", AV34Namespace);
            cmbavGeneratesessionstatistics.CurrentValue = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AV27GenerateSessionStatistics = cgiGet( cmbavGeneratesessionstatistics_Internalname);
            AssignAttri("", false, "AV27GenerateSessionStatistics", AV27GenerateSessionStatistics);
            AV8AllowOauthAccess = StringUtil.StrToBool( cgiGet( chkavAllowoauthaccess_Internalname));
            AssignAttri("", false, "AV8AllowOauthAccess", AV8AllowOauthAccess);
            AV45CanRegisterUsers = StringUtil.StrToBool( cgiGet( chkavCanregisterusers_Internalname));
            AssignAttri("", false, "AV45CanRegisterUsers", AV45CanRegisterUsers);
            AV28GiveAnonymousSession = StringUtil.StrToBool( cgiGet( chkavGiveanonymoussession_Internalname));
            AssignAttri("", false, "AV28GiveAnonymousSession", AV28GiveAnonymousSession);
            AV12ConnectionUserName = cgiGet( edtavConnectionusername_Internalname);
            AssignAttri("", false, "AV12ConnectionUserName", AV12ConnectionUserName);
            AV13ConnectionUserPassword = cgiGet( edtavConnectionuserpassword_Internalname);
            AssignAttri("", false, "AV13ConnectionUserPassword", AV13ConnectionUserPassword);
            AV11ConfConnectionUserPassword = cgiGet( edtavConfconnectionuserpassword_Internalname);
            AssignAttri("", false, "AV11ConfConnectionUserPassword", AV11ConfConnectionUserPassword);
            AV9AuthenticationMasterAuthTypeName = cgiGet( edtavAuthenticationmasterauthtypename_Internalname);
            AssignAttri("", false, "AV9AuthenticationMasterAuthTypeName", AV9AuthenticationMasterAuthTypeName);
            AV6AdministratorUserName = cgiGet( edtavAdministratorusername_Internalname);
            AssignAttri("", false, "AV6AdministratorUserName", AV6AdministratorUserName);
            AV7AdministratorUserPassword = cgiGet( edtavAdministratoruserpassword_Internalname);
            AssignAttri("", false, "AV7AdministratorUserPassword", AV7AdministratorUserPassword);
            AV10ConfAdministratorUserPassword = cgiGet( edtavConfadministratoruserpassword_Internalname);
            AssignAttri("", false, "AV10ConfAdministratorUserPassword", AV10ConfAdministratorUserPassword);
            AV31isGAMAdminAccessRepository = StringUtil.StrToBool( cgiGet( chkavIsgamadminaccessrepository_Internalname));
            AssignAttri("", false, "AV31isGAMAdminAccessRepository", AV31isGAMAdminAccessRepository);
            AV20CreateGAMApplication = StringUtil.StrToBool( cgiGet( chkavCreategamapplication_Internalname));
            AssignAttri("", false, "AV20CreateGAMApplication", AV20CreateGAMApplication);
            cmbavCopyfromrepositoryid.CurrentValue = cgiGet( cmbavCopyfromrepositoryid_Internalname);
            AV17CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cgiGet( cmbavCopyfromrepositoryid_Internalname), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV17CopyFromRepositoryId), 9, 0));
            AV18CopyRoles = StringUtil.StrToBool( cgiGet( chkavCopyroles_Internalname));
            AssignAttri("", false, "AV18CopyRoles", AV18CopyRoles);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vADMINISTRATORROLEID");
               GX_FocusControl = edtavAdministratorroleid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV5AdministratorRoleId = 0;
               AssignAttri("", false, "AV5AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV5AdministratorRoleId), 12, 0));
            }
            else
            {
               AV5AdministratorRoleId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavAdministratorroleid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV5AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV5AdministratorRoleId), 12, 0));
            }
            AV19CopySecurityPolicies = StringUtil.StrToBool( cgiGet( chkavCopysecuritypolicies_Internalname));
            AssignAttri("", false, "AV19CopySecurityPolicies", AV19CopySecurityPolicies);
            AV14CopyApplication = StringUtil.StrToBool( cgiGet( chkavCopyapplication_Internalname));
            AssignAttri("", false, "AV14CopyApplication", AV14CopyApplication);
            if ( ( ( context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ",", ".") < Convert.ToDecimal( 0 )) ) || ( ( context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ",", ".") > Convert.ToDecimal( 999999999999L )) ) )
            {
               GX_msglist.addItem(context.GetMessage( "GXM_badnum", ""), 1, "vCOPYFROMAPPLICATIONID");
               GX_FocusControl = edtavCopyfromapplicationid_Internalname;
               AssignAttri("", false, "GX_FocusControl", GX_FocusControl);
               wbErr = true;
               AV16CopyFromApplicationId = 0;
               AssignAttri("", false, "AV16CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV16CopyFromApplicationId), 12, 0));
            }
            else
            {
               AV16CopyFromApplicationId = (long)(Math.Round(context.localUtil.CToN( cgiGet( edtavCopyfromapplicationid_Internalname), ",", "."), 18, MidpointRounding.ToEven));
               AssignAttri("", false, "AV16CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV16CopyFromApplicationId), 12, 0));
            }
            AV15CopyApplicationRolePermissions = StringUtil.StrToBool( cgiGet( chkavCopyapplicationrolepermissions_Internalname));
            AssignAttri("", false, "AV15CopyApplicationRolePermissions", AV15CopyApplicationRolePermissions);
            AV41UpdateConnectionFile = StringUtil.StrToBool( cgiGet( chkavUpdateconnectionfile_Internalname));
            AssignAttri("", false, "AV41UpdateConnectionFile", AV41UpdateConnectionFile);
            /* Read subfile selected row values. */
            /* Read hidden variables. */
            GXKey = Decrypt64( context.GetCookie( "GX_SESSION_ID"), Crypto.GetServerKey( ));
         }
         else
         {
            dynload_actions( ) ;
         }
      }

      protected void GXStart( )
      {
         /* Execute user event: Start */
         E111O2 ();
         if (returnInSub) return;
      }

      protected void E111O2( )
      {
         /* Start Routine */
         returnInSub = false;
         if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
         {
            AV37Repository.load( AV30Id);
            if ( AV37Repository.success() )
            {
               AV29GUID = AV37Repository.gxTpr_Guid;
               AssignAttri("", false, "AV29GUID", AV29GUID);
               AV33Name = AV37Repository.gxTpr_Name;
               AssignAttri("", false, "AV33Name", AV33Name);
               AV34Namespace = AV37Repository.gxTpr_Namespace;
               AssignAttri("", false, "AV34Namespace", AV34Namespace);
               AV21Description = AV37Repository.gxTpr_Description;
               AssignAttri("", false, "AV21Description", AV21Description);
               AV27GenerateSessionStatistics = AV37Repository.gxTpr_Generatesessionstatistics;
               AssignAttri("", false, "AV27GenerateSessionStatistics", AV27GenerateSessionStatistics);
               edtavGuid_Enabled = 0;
               AssignProp("", false, edtavGuid_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavGuid_Enabled), 5, 0), true);
               edtavName_Enabled = 0;
               AssignProp("", false, edtavName_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavName_Enabled), 5, 0), true);
               edtavNamespace_Enabled = 0;
               AssignProp("", false, edtavNamespace_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavNamespace_Enabled), 5, 0), true);
               edtavDescription_Enabled = 0;
               AssignProp("", false, edtavDescription_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavDescription_Enabled), 5, 0), true);
               edtavAdministratorusername_Enabled = 0;
               AssignProp("", false, edtavAdministratorusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratorusername_Enabled), 5, 0), true);
               edtavAdministratoruserpassword_Enabled = 0;
               AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Enabled), 5, 0), true);
               cmbavGeneratesessionstatistics.Enabled = 0;
               AssignProp("", false, cmbavGeneratesessionstatistics_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(cmbavGeneratesessionstatistics.Enabled), 5, 0), true);
               edtavConnectionusername_Enabled = 0;
               AssignProp("", false, edtavConnectionusername_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionusername_Enabled), 5, 0), true);
               edtavConnectionuserpassword_Enabled = 0;
               AssignProp("", false, edtavConnectionuserpassword_Internalname, "Enabled", StringUtil.LTrimStr( (decimal)(edtavConnectionuserpassword_Enabled), 5, 0), true);
               divTbluserssettings_Visible = 0;
               AssignProp("", false, divTbluserssettings_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(divTbluserssettings_Visible), 5, 0), true);
               chkavUpdateconnectionfile.Visible = 0;
               AssignProp("", false, chkavUpdateconnectionfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUpdateconnectionfile.Visible), 5, 0), true);
               bttBtnenter_Caption = "Eliminar";
               AssignProp("", false, bttBtnenter_Internalname, "Caption", bttBtnenter_Caption, true);
            }
            else
            {
               AV23Errors = AV37Repository.geterrors();
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S112 ();
               if (returnInSub) return;
            }
         }
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            AV27GenerateSessionStatistics = "Minimum";
            AssignAttri("", false, "AV27GenerateSessionStatistics", AV27GenerateSessionStatistics);
            AV20CreateGAMApplication = true;
            AssignAttri("", false, "AV20CreateGAMApplication", AV20CreateGAMApplication);
            AV41UpdateConnectionFile = true;
            AssignAttri("", false, "AV41UpdateConnectionFile", AV41UpdateConnectionFile);
            AV36Repositories = new GeneXus.Programs.genexussecurity.SdtGAM(context).getallrepositories(AV39RepositoryFilter, out  AV23Errors);
            if ( AV23Errors.Count == 0 )
            {
               AV47GXV1 = 1;
               while ( AV47GXV1 <= AV36Repositories.Count )
               {
                  AV35Repo = ((GeneXus.Programs.genexussecurity.SdtGAMRepository)AV36Repositories.Item(AV47GXV1));
                  cmbavCopyfromrepositoryid.addItem("0", "(Sem c�pia)", 0);
                  cmbavCopyfromrepositoryid.addItem(StringUtil.Trim( StringUtil.Str( (decimal)(AV35Repo.gxTpr_Id), 9, 0)), StringUtil.Str( (decimal)(AV35Repo.gxTpr_Id), 9, 0)+" - "+StringUtil.Trim( AV35Repo.gxTpr_Name), 0);
                  AV47GXV1 = (int)(AV47GXV1+1);
               }
            }
            else
            {
               /* Execute user subroutine: 'DISPLAYERRORS' */
               S112 ();
               if (returnInSub) return;
            }
            AV17CopyFromRepositoryId = 2;
            AssignAttri("", false, "AV17CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV17CopyFromRepositoryId), 9, 0));
            AV18CopyRoles = true;
            AssignAttri("", false, "AV18CopyRoles", AV18CopyRoles);
            AV5AdministratorRoleId = 2;
            AssignAttri("", false, "AV5AdministratorRoleId", StringUtil.LTrimStr( (decimal)(AV5AdministratorRoleId), 12, 0));
            AV19CopySecurityPolicies = true;
            AssignAttri("", false, "AV19CopySecurityPolicies", AV19CopySecurityPolicies);
            AV14CopyApplication = true;
            AssignAttri("", false, "AV14CopyApplication", AV14CopyApplication);
            AV16CopyFromApplicationId = 2;
            AssignAttri("", false, "AV16CopyFromApplicationId", StringUtil.LTrimStr( (decimal)(AV16CopyFromApplicationId), 12, 0));
            AV15CopyApplicationRolePermissions = true;
            AssignAttri("", false, "AV15CopyApplicationRolePermissions", AV15CopyApplicationRolePermissions);
         }
         else
         {
            this.executeUsercontrolMethod("", false, "GXUITABSPANEL_TABSContainer", "HideTab", "", new Object[] {(short)2});
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         chkavUpdateconnectionfile.Visible = 0;
         AssignProp("", false, chkavUpdateconnectionfile_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUpdateconnectionfile.Visible), 5, 0), true);
      }

      protected void S122( )
      {
         /* 'ATTRIBUTESSECURITYCODE' Routine */
         returnInSub = false;
         if ( ! ( AV15CopyApplicationRolePermissions || AV18CopyRoles || ! AV14CopyApplication ) )
         {
            edtavAdministratorroleid_Visible = 0;
            AssignProp("", false, edtavAdministratorroleid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratorroleid_Visible), 5, 0), true);
            divAdministratorroleid_cell_Class = "Invisible";
            AssignProp("", false, divAdministratorroleid_cell_Internalname, "Class", divAdministratorroleid_cell_Class, true);
         }
         else
         {
            edtavAdministratorroleid_Visible = 1;
            AssignProp("", false, edtavAdministratorroleid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratorroleid_Visible), 5, 0), true);
            divAdministratorroleid_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divAdministratorroleid_cell_Internalname, "Class", divAdministratorroleid_cell_Class, true);
         }
         if ( ! ( AV15CopyApplicationRolePermissions || AV18CopyRoles || ! AV14CopyApplication ) )
         {
            edtavCopyfromapplicationid_Visible = 0;
            AssignProp("", false, edtavCopyfromapplicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCopyfromapplicationid_Visible), 5, 0), true);
            divCopyfromapplicationid_cell_Class = "Invisible";
            AssignProp("", false, divCopyfromapplicationid_cell_Internalname, "Class", divCopyfromapplicationid_cell_Class, true);
         }
         else
         {
            edtavCopyfromapplicationid_Visible = 1;
            AssignProp("", false, edtavCopyfromapplicationid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavCopyfromapplicationid_Visible), 5, 0), true);
            divCopyfromapplicationid_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divCopyfromapplicationid_cell_Internalname, "Class", divCopyfromapplicationid_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 ) ) )
         {
            edtavGuid_Visible = 0;
            AssignProp("", false, edtavGuid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGuid_Visible), 5, 0), true);
            divGuid_cell_Class = "Invisible";
            AssignProp("", false, divGuid_cell_Internalname, "Class", divGuid_cell_Class, true);
         }
         else
         {
            edtavGuid_Visible = 1;
            AssignProp("", false, edtavGuid_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavGuid_Visible), 5, 0), true);
            divGuid_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divGuid_cell_Internalname, "Class", divGuid_cell_Class, true);
         }
         if ( ! ( ( StringUtil.StrCmp(Gx_mode, "INS") != 0 ) && AV42UseCurrentRepositorAsMasterAuthentication ) )
         {
            chkavUsecurrentrepositorasmasterauthentication.Visible = 0;
            AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUsecurrentrepositorasmasterauthentication.Visible), 5, 0), true);
            divUsecurrentrepositorasmasterauthentication_cell_Class = "Invisible";
            AssignProp("", false, divUsecurrentrepositorasmasterauthentication_cell_Internalname, "Class", divUsecurrentrepositorasmasterauthentication_cell_Class, true);
         }
         else
         {
            chkavUsecurrentrepositorasmasterauthentication.Visible = 1;
            AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(chkavUsecurrentrepositorasmasterauthentication.Visible), 5, 0), true);
            divUsecurrentrepositorasmasterauthentication_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divUsecurrentrepositorasmasterauthentication_cell_Internalname, "Class", divUsecurrentrepositorasmasterauthentication_cell_Class, true);
         }
         if ( ! ( ! AV42UseCurrentRepositorAsMasterAuthentication ) )
         {
            edtavNamespace_Visible = 0;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            divNamespace_cell_Class = "Invisible";
            AssignProp("", false, divNamespace_cell_Internalname, "Class", divNamespace_cell_Class, true);
         }
         else
         {
            edtavNamespace_Visible = 1;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            divNamespace_cell_Class = "col-xs-12 DataContentCellFL";
            AssignProp("", false, divNamespace_cell_Internalname, "Class", divNamespace_cell_Class, true);
         }
      }

      public void GXEnter( )
      {
         /* Execute user event: Enter */
         E121O2 ();
         if (returnInSub) return;
      }

      protected void E121O2( )
      {
         /* Enter Routine */
         returnInSub = false;
         AV37Repository.load( AV30Id);
         AV32isOK = true;
         if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
         {
            if ( StringUtil.StrCmp(StringUtil.Trim( AV7AdministratorUserPassword), StringUtil.Trim( AV10ConfAdministratorUserPassword)) != 0 )
            {
               GX_msglist.addItem("A senha do administrador n�o coincide com a confirma��o");
               AV32isOK = false;
            }
            if ( StringUtil.StrCmp(StringUtil.Trim( AV13ConnectionUserPassword), StringUtil.Trim( AV11ConfConnectionUserPassword)) != 0 )
            {
               GX_msglist.addItem("A senha de conex�o n�o coincide com a confirma��o");
               AV32isOK = false;
            }
         }
         if ( AV32isOK )
         {
            if ( StringUtil.StrCmp(Gx_mode, "INS") == 0 )
            {
               AV29GUID = Guid.NewGuid( ).ToString();
               AssignAttri("", false, "AV29GUID", AV29GUID);
               AV38RepositoryCreate.gxTpr_Guid = AV29GUID;
               AV38RepositoryCreate.gxTpr_Name = AV33Name;
               AV38RepositoryCreate.gxTpr_Namespace = AV34Namespace;
               AV38RepositoryCreate.gxTpr_Description = AV21Description;
               AV38RepositoryCreate.gxTpr_Administratorusername = AV6AdministratorUserName;
               AV38RepositoryCreate.gxTpr_Administratoruserpassword = AV7AdministratorUserPassword;
               AV38RepositoryCreate.gxTpr_Allowoauthaccess = AV8AllowOauthAccess;
               AV38RepositoryCreate.gxTpr_Connectionusername = AV12ConnectionUserName;
               AV38RepositoryCreate.gxTpr_Connectionuserpassword = AV13ConnectionUserPassword;
               AV38RepositoryCreate.gxTpr_Generatesessionstatistics = AV27GenerateSessionStatistics;
               AV38RepositoryCreate.gxTpr_Giveanonymoussession = true;
               AV38RepositoryCreate.gxTpr_Allowoauthaccess = true;
               if ( AV42UseCurrentRepositorAsMasterAuthentication )
               {
                  AV25GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
                  AV38RepositoryCreate.gxTpr_Authenticationmasterrepositoryid = AV25GAMRepository.gxTpr_Id;
                  AV38RepositoryCreate.gxTpr_Authenticationmasterauthtypename = AV9AuthenticationMasterAuthTypeName;
               }
               AV38RepositoryCreate.gxTpr_Creategamapplication = AV20CreateGAMApplication;
               if ( ! (0==AV17CopyFromRepositoryId) )
               {
                  AV38RepositoryCreate.gxTpr_Copyfromrepositoryid = AV17CopyFromRepositoryId;
                  if ( AV18CopyRoles )
                  {
                     AV38RepositoryCreate.gxTpr_Copyroles = AV18CopyRoles;
                     AV38RepositoryCreate.gxTpr_Administratorroleid = AV5AdministratorRoleId;
                  }
                  AV38RepositoryCreate.gxTpr_Copysecuritypolicies = AV19CopySecurityPolicies;
               }
               if ( AV14CopyApplication && ! (0==AV16CopyFromApplicationId) )
               {
                  AV38RepositoryCreate.gxTpr_Copyapplication = AV14CopyApplication;
                  AV38RepositoryCreate.gxTpr_Copyfromapplicationid = AV16CopyFromApplicationId;
                  AV38RepositoryCreate.gxTpr_Copyapplicationrolepermissions = AV15CopyApplicationRolePermissions;
               }
               AV32isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).createrepository(AV38RepositoryCreate, AV41UpdateConnectionFile, out  AV23Errors);
               if ( AV32isOK )
               {
                  context.CommitDataStores("gamrepositoryentry",pr_default);
                  if ( AV31isGAMAdminAccessRepository )
                  {
                     AV40RepositoryNew = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).getbyguid(AV29GUID, out  AV23Errors);
                     AV26GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context).get();
                     AV32isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).repositoryuserenable(AV40RepositoryNew.gxTpr_Id, AV26GAMUser, AV5AdministratorRoleId, out  AV23Errors);
                     if ( AV32isOK )
                     {
                        context.CommitDataStores("gamrepositoryentry",pr_default);
                     }
                  }
               }
            }
            else if ( StringUtil.StrCmp(Gx_mode, "DLT") == 0 )
            {
               AV32isOK = new GeneXus.Programs.genexussecurity.SdtGAM(context).deleterepository(AV37Repository.gxTpr_Guid, out  AV23Errors);
               if ( AV32isOK )
               {
                  context.CommitDataStores("gamrepositoryentry",pr_default);
               }
            }
         }
         if ( AV32isOK )
         {
            context.setWebReturnParms(new Object[] {(string)Gx_mode,(int)AV30Id});
            context.setWebReturnParmsMetadata(new Object[] {"Gx_mode","AV30Id"});
            context.wjLocDisableFrm = 1;
            context.nUserReturn = 1;
            returnInSub = true;
            if (true) return;
         }
         else
         {
            /* Execute user subroutine: 'DISPLAYERRORS' */
            S112 ();
            if (returnInSub) return;
         }
         /*  Sending Event outputs  */
         context.httpAjaxContext.ajax_rsp_assign_sdt_attri("", false, "AV38RepositoryCreate", AV38RepositoryCreate);
      }

      protected void E131O2( )
      {
         /* Usecurrentrepositorasmasterauthentication_Click Routine */
         returnInSub = false;
         AV25GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context).get();
         AV34Namespace = AV25GAMRepository.gxTpr_Namespace;
         AssignAttri("", false, "AV34Namespace", AV34Namespace);
         if ( AV42UseCurrentRepositorAsMasterAuthentication )
         {
            edtavNamespace_Visible = 0;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            edtavAdministratorusername_Caption = "Nome de usu�rio do administrador (o usu�rio j� deve existir no tenant atual)";
            AssignProp("", false, edtavAdministratorusername_Internalname, "Caption", edtavAdministratorusername_Caption, true);
            AV7AdministratorUserPassword = "";
            AssignAttri("", false, "AV7AdministratorUserPassword", AV7AdministratorUserPassword);
            edtavAdministratoruserpassword_Visible = 0;
            AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Visible), 5, 0), true);
            AV10ConfAdministratorUserPassword = "";
            AssignAttri("", false, "AV10ConfAdministratorUserPassword", AV10ConfAdministratorUserPassword);
            edtavConfadministratoruserpassword_Visible = 0;
            AssignProp("", false, edtavConfadministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfadministratoruserpassword_Visible), 5, 0), true);
         }
         else
         {
            edtavNamespace_Visible = 1;
            AssignProp("", false, edtavNamespace_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavNamespace_Visible), 5, 0), true);
            edtavAdministratorusername_Caption = "Nome de usu�rio do administrador (apelido)";
            AssignProp("", false, edtavAdministratorusername_Internalname, "Caption", edtavAdministratorusername_Caption, true);
            edtavAdministratoruserpassword_Visible = 1;
            AssignProp("", false, edtavAdministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavAdministratoruserpassword_Visible), 5, 0), true);
            edtavConfadministratoruserpassword_Visible = 1;
            AssignProp("", false, edtavConfadministratoruserpassword_Internalname, "Visible", StringUtil.LTrimStr( (decimal)(edtavConfadministratoruserpassword_Visible), 5, 0), true);
         }
         /* Execute user subroutine: 'ATTRIBUTESSECURITYCODE' */
         S122 ();
         if (returnInSub) return;
         /*  Sending Event outputs  */
      }

      protected void S112( )
      {
         /* 'DISPLAYERRORS' Routine */
         returnInSub = false;
         AV48GXV2 = 1;
         while ( AV48GXV2 <= AV23Errors.Count )
         {
            AV22Error = ((GeneXus.Programs.genexussecurity.SdtGAMError)AV23Errors.Item(AV48GXV2));
            GX_msglist.addItem(StringUtil.Format( "%1 (GAM%2)", AV22Error.gxTpr_Message, StringUtil.LTrimStr( (decimal)(AV22Error.gxTpr_Code), 12, 0), "", "", "", "", "", "", ""));
            AV48GXV2 = (int)(AV48GXV2+1);
         }
      }

      protected void nextLoad( )
      {
      }

      protected void E141O2( )
      {
         /* Load Routine */
         returnInSub = false;
      }

      public override void setparameters( Object[] obj )
      {
         createObjects();
         initialize();
         Gx_mode = (string)getParm(obj,0);
         AssignAttri("", false, "Gx_mode", Gx_mode);
         AV30Id = Convert.ToInt32(getParm(obj,1));
         AssignAttri("", false, "AV30Id", StringUtil.LTrimStr( (decimal)(AV30Id), 9, 0));
         GxWebStd.gx_hidden_field( context, "gxhash_vID", GetSecureSignedToken( "", context.localUtil.Format( (decimal)(AV30Id), "ZZZZZZZZ9"), context));
      }

      public override string getresponse( string sGXDynURL )
      {
         initialize_properties( ) ;
         BackMsgLst = context.GX_msglist;
         context.GX_msglist = LclMsgLst;
         sDynURL = sGXDynURL;
         nGotPars = (short)(1);
         nGXWrapped = (short)(1);
         context.SetWrapped(true);
         PA1O2( ) ;
         WS1O2( ) ;
         WE1O2( ) ;
         this.cleanup();
         context.SetWrapped(false);
         context.GX_msglist = BackMsgLst;
         return "";
      }

      public void responsestatic( string sGXDynURL )
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
            context.AddJavascriptSource(StringUtil.RTrim( ((string)Form.Jscriptsrc.Item(idxLst))), "?202382820957", true, true);
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
         context.AddJavascriptSource("gamrepositoryentry.js", "?202382820961", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManager.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/json2005.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/rsh/rsh.js", "", false, true);
         context.AddJavascriptSource("shared/HistoryManager/HistoryManagerCreate.js", "", false, true);
         context.AddJavascriptSource("Tab/TabRender.js", "", false, true);
         /* End function include_jscripts */
      }

      protected void init_web_controls( )
      {
         chkavUsecurrentrepositorasmasterauthentication.Name = "vUSECURRENTREPOSITORASMASTERAUTHENTICATION";
         chkavUsecurrentrepositorasmasterauthentication.WebTags = "";
         chkavUsecurrentrepositorasmasterauthentication.Caption = "Use o reposit�rio atual como o reposit�rio mestre de autentica��o";
         AssignProp("", false, chkavUsecurrentrepositorasmasterauthentication_Internalname, "TitleCaption", chkavUsecurrentrepositorasmasterauthentication.Caption, true);
         chkavUsecurrentrepositorasmasterauthentication.CheckedValue = "false";
         AV42UseCurrentRepositorAsMasterAuthentication = StringUtil.StrToBool( StringUtil.BoolToStr( AV42UseCurrentRepositorAsMasterAuthentication));
         AssignAttri("", false, "AV42UseCurrentRepositorAsMasterAuthentication", AV42UseCurrentRepositorAsMasterAuthentication);
         cmbavGeneratesessionstatistics.Name = "vGENERATESESSIONSTATISTICS";
         cmbavGeneratesessionstatistics.WebTags = "";
         cmbavGeneratesessionstatistics.addItem("None", "None", 0);
         cmbavGeneratesessionstatistics.addItem("Minimum", "Minimum (Only authenticated users)", 0);
         cmbavGeneratesessionstatistics.addItem("Detail", "Detail (Authenticated and anonymous users)", 0);
         cmbavGeneratesessionstatistics.addItem("Full", "Full log (Authenticated and anonymous users)", 0);
         if ( cmbavGeneratesessionstatistics.ItemCount > 0 )
         {
            AV27GenerateSessionStatistics = cmbavGeneratesessionstatistics.getValidValue(AV27GenerateSessionStatistics);
            AssignAttri("", false, "AV27GenerateSessionStatistics", AV27GenerateSessionStatistics);
         }
         chkavAllowoauthaccess.Name = "vALLOWOAUTHACCESS";
         chkavAllowoauthaccess.WebTags = "";
         chkavAllowoauthaccess.Caption = "Permitir o acesso oauth";
         AssignProp("", false, chkavAllowoauthaccess_Internalname, "TitleCaption", chkavAllowoauthaccess.Caption, true);
         chkavAllowoauthaccess.CheckedValue = "false";
         AV8AllowOauthAccess = StringUtil.StrToBool( StringUtil.BoolToStr( AV8AllowOauthAccess));
         AssignAttri("", false, "AV8AllowOauthAccess", AV8AllowOauthAccess);
         chkavCanregisterusers.Name = "vCANREGISTERUSERS";
         chkavCanregisterusers.WebTags = "";
         chkavCanregisterusers.Caption = "Voc� pode registrar usu�rios?";
         AssignProp("", false, chkavCanregisterusers_Internalname, "TitleCaption", chkavCanregisterusers.Caption, true);
         chkavCanregisterusers.CheckedValue = "false";
         AV45CanRegisterUsers = StringUtil.StrToBool( StringUtil.BoolToStr( AV45CanRegisterUsers));
         AssignAttri("", false, "AV45CanRegisterUsers", AV45CanRegisterUsers);
         chkavGiveanonymoussession.Name = "vGIVEANONYMOUSSESSION";
         chkavGiveanonymoussession.WebTags = "";
         chkavGiveanonymoussession.Caption = "Dar sess�o an�nima?";
         AssignProp("", false, chkavGiveanonymoussession_Internalname, "TitleCaption", chkavGiveanonymoussession.Caption, true);
         chkavGiveanonymoussession.CheckedValue = "false";
         AV28GiveAnonymousSession = StringUtil.StrToBool( StringUtil.BoolToStr( AV28GiveAnonymousSession));
         AssignAttri("", false, "AV28GiveAnonymousSession", AV28GiveAnonymousSession);
         chkavIsgamadminaccessrepository.Name = "vISGAMADMINACCESSREPOSITORY";
         chkavIsgamadminaccessrepository.WebTags = "";
         chkavIsgamadminaccessrepository.Caption = "O usu�rio atual � um administrador do novo reposit�rio?";
         AssignProp("", false, chkavIsgamadminaccessrepository_Internalname, "TitleCaption", chkavIsgamadminaccessrepository.Caption, true);
         chkavIsgamadminaccessrepository.CheckedValue = "false";
         AV31isGAMAdminAccessRepository = StringUtil.StrToBool( StringUtil.BoolToStr( AV31isGAMAdminAccessRepository));
         AssignAttri("", false, "AV31isGAMAdminAccessRepository", AV31isGAMAdminAccessRepository);
         chkavCreategamapplication.Name = "vCREATEGAMAPPLICATION";
         chkavCreategamapplication.WebTags = "";
         chkavCreategamapplication.Caption = "Criar aplicativo de back-end do gam?";
         AssignProp("", false, chkavCreategamapplication_Internalname, "TitleCaption", chkavCreategamapplication.Caption, true);
         chkavCreategamapplication.CheckedValue = "false";
         AV20CreateGAMApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV20CreateGAMApplication));
         AssignAttri("", false, "AV20CreateGAMApplication", AV20CreateGAMApplication);
         cmbavCopyfromrepositoryid.Name = "vCOPYFROMREPOSITORYID";
         cmbavCopyfromrepositoryid.WebTags = "";
         if ( cmbavCopyfromrepositoryid.ItemCount > 0 )
         {
            AV17CopyFromRepositoryId = (int)(Math.Round(NumberUtil.Val( cmbavCopyfromrepositoryid.getValidValue(StringUtil.Trim( StringUtil.Str( (decimal)(AV17CopyFromRepositoryId), 9, 0))), "."), 18, MidpointRounding.ToEven));
            AssignAttri("", false, "AV17CopyFromRepositoryId", StringUtil.LTrimStr( (decimal)(AV17CopyFromRepositoryId), 9, 0));
         }
         chkavCopyroles.Name = "vCOPYROLES";
         chkavCopyroles.WebTags = "";
         chkavCopyroles.Caption = "Copiar fun��es?";
         AssignProp("", false, chkavCopyroles_Internalname, "TitleCaption", chkavCopyroles.Caption, true);
         chkavCopyroles.CheckedValue = "false";
         AV18CopyRoles = StringUtil.StrToBool( StringUtil.BoolToStr( AV18CopyRoles));
         AssignAttri("", false, "AV18CopyRoles", AV18CopyRoles);
         chkavCopysecuritypolicies.Name = "vCOPYSECURITYPOLICIES";
         chkavCopysecuritypolicies.WebTags = "";
         chkavCopysecuritypolicies.Caption = "Copiar pol�ticas de seguran�a?";
         AssignProp("", false, chkavCopysecuritypolicies_Internalname, "TitleCaption", chkavCopysecuritypolicies.Caption, true);
         chkavCopysecuritypolicies.CheckedValue = "false";
         AV19CopySecurityPolicies = StringUtil.StrToBool( StringUtil.BoolToStr( AV19CopySecurityPolicies));
         AssignAttri("", false, "AV19CopySecurityPolicies", AV19CopySecurityPolicies);
         chkavCopyapplication.Name = "vCOPYAPPLICATION";
         chkavCopyapplication.WebTags = "";
         chkavCopyapplication.Caption = "Copiar aplicativo? (Menus e permiss�es)";
         AssignProp("", false, chkavCopyapplication_Internalname, "TitleCaption", chkavCopyapplication.Caption, true);
         chkavCopyapplication.CheckedValue = "false";
         AV14CopyApplication = StringUtil.StrToBool( StringUtil.BoolToStr( AV14CopyApplication));
         AssignAttri("", false, "AV14CopyApplication", AV14CopyApplication);
         chkavCopyapplicationrolepermissions.Name = "vCOPYAPPLICATIONROLEPERMISSIONS";
         chkavCopyapplicationrolepermissions.WebTags = "";
         chkavCopyapplicationrolepermissions.Caption = "Copiar as permiss�es de fun��es?";
         AssignProp("", false, chkavCopyapplicationrolepermissions_Internalname, "TitleCaption", chkavCopyapplicationrolepermissions.Caption, true);
         chkavCopyapplicationrolepermissions.CheckedValue = "false";
         AV15CopyApplicationRolePermissions = StringUtil.StrToBool( StringUtil.BoolToStr( AV15CopyApplicationRolePermissions));
         AssignAttri("", false, "AV15CopyApplicationRolePermissions", AV15CopyApplicationRolePermissions);
         chkavUpdateconnectionfile.Name = "vUPDATECONNECTIONFILE";
         chkavUpdateconnectionfile.WebTags = "";
         chkavUpdateconnectionfile.Caption = "";
         AssignProp("", false, chkavUpdateconnectionfile_Internalname, "TitleCaption", chkavUpdateconnectionfile.Caption, true);
         chkavUpdateconnectionfile.CheckedValue = "false";
         AV41UpdateConnectionFile = StringUtil.StrToBool( StringUtil.BoolToStr( AV41UpdateConnectionFile));
         AssignAttri("", false, "AV41UpdateConnectionFile", AV41UpdateConnectionFile);
         /* End function init_web_controls */
      }

      protected void init_default_properties( )
      {
         lblGeneral_title_Internalname = "GENERAL_TITLE";
         edtavGuid_Internalname = "vGUID";
         divGuid_cell_Internalname = "GUID_CELL";
         edtavName_Internalname = "vNAME";
         edtavDescription_Internalname = "vDESCRIPTION";
         chkavUsecurrentrepositorasmasterauthentication_Internalname = "vUSECURRENTREPOSITORASMASTERAUTHENTICATION";
         divUsecurrentrepositorasmasterauthentication_cell_Internalname = "USECURRENTREPOSITORASMASTERAUTHENTICATION_CELL";
         edtavNamespace_Internalname = "vNAMESPACE";
         divNamespace_cell_Internalname = "NAMESPACE_CELL";
         cmbavGeneratesessionstatistics_Internalname = "vGENERATESESSIONSTATISTICS";
         chkavAllowoauthaccess_Internalname = "vALLOWOAUTHACCESS";
         chkavCanregisterusers_Internalname = "vCANREGISTERUSERS";
         chkavGiveanonymoussession_Internalname = "vGIVEANONYMOUSSESSION";
         edtavConnectionusername_Internalname = "vCONNECTIONUSERNAME";
         edtavConnectionuserpassword_Internalname = "vCONNECTIONUSERPASSWORD";
         edtavConfconnectionuserpassword_Internalname = "vCONFCONNECTIONUSERPASSWORD";
         edtavAuthenticationmasterauthtypename_Internalname = "vAUTHENTICATIONMASTERAUTHTYPENAME";
         edtavAdministratorusername_Internalname = "vADMINISTRATORUSERNAME";
         edtavAdministratoruserpassword_Internalname = "vADMINISTRATORUSERPASSWORD";
         edtavConfadministratoruserpassword_Internalname = "vCONFADMINISTRATORUSERPASSWORD";
         divTbluserssettings_Internalname = "TBLUSERSSETTINGS";
         chkavIsgamadminaccessrepository_Internalname = "vISGAMADMINACCESSREPOSITORY";
         chkavCreategamapplication_Internalname = "vCREATEGAMAPPLICATION";
         divTableattributes_Internalname = "TABLEATTRIBUTES";
         lblCopyrepdata_title_Internalname = "COPYREPDATA_TITLE";
         cmbavCopyfromrepositoryid_Internalname = "vCOPYFROMREPOSITORYID";
         chkavCopyroles_Internalname = "vCOPYROLES";
         edtavAdministratorroleid_Internalname = "vADMINISTRATORROLEID";
         divAdministratorroleid_cell_Internalname = "ADMINISTRATORROLEID_CELL";
         chkavCopysecuritypolicies_Internalname = "vCOPYSECURITYPOLICIES";
         chkavCopyapplication_Internalname = "vCOPYAPPLICATION";
         edtavCopyfromapplicationid_Internalname = "vCOPYFROMAPPLICATIONID";
         divCopyfromapplicationid_cell_Internalname = "COPYFROMAPPLICATIONID_CELL";
         chkavCopyapplicationrolepermissions_Internalname = "vCOPYAPPLICATIONROLEPERMISSIONS";
         divUnnamedtable1_Internalname = "UNNAMEDTABLE1";
         Gxuitabspanel_tabs_Internalname = "GXUITABSPANEL_TABS";
         divTablecontent_Internalname = "TABLECONTENT";
         bttBtnenter_Internalname = "BTNENTER";
         bttBtncancel_Internalname = "BTNCANCEL";
         divTablemain_Internalname = "TABLEMAIN";
         chkavUpdateconnectionfile_Internalname = "vUPDATECONNECTIONFILE";
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
         chkavUpdateconnectionfile.Caption = "";
         chkavCopyapplicationrolepermissions.Caption = " ";
         chkavCopyapplication.Caption = " ";
         chkavCopysecuritypolicies.Caption = " ";
         chkavCopyroles.Caption = " ";
         chkavCreategamapplication.Caption = " ";
         chkavIsgamadminaccessrepository.Caption = " ";
         chkavGiveanonymoussession.Caption = "";
         chkavCanregisterusers.Caption = "";
         chkavAllowoauthaccess.Caption = "";
         chkavUsecurrentrepositorasmasterauthentication.Caption = " ";
         chkavUpdateconnectionfile.Visible = 1;
         bttBtnenter_Caption = "Confirmar";
         chkavCopyapplicationrolepermissions.Enabled = 1;
         edtavCopyfromapplicationid_Jsonclick = "";
         edtavCopyfromapplicationid_Enabled = 1;
         edtavCopyfromapplicationid_Visible = 1;
         divCopyfromapplicationid_cell_Class = "col-xs-12";
         chkavCopyapplication.Enabled = 1;
         chkavCopysecuritypolicies.Enabled = 1;
         edtavAdministratorroleid_Jsonclick = "";
         edtavAdministratorroleid_Enabled = 1;
         edtavAdministratorroleid_Visible = 1;
         divAdministratorroleid_cell_Class = "col-xs-12";
         chkavCopyroles.Enabled = 1;
         cmbavCopyfromrepositoryid_Jsonclick = "";
         cmbavCopyfromrepositoryid.Enabled = 1;
         chkavCreategamapplication.Enabled = 1;
         chkavIsgamadminaccessrepository.Enabled = 1;
         edtavConfadministratoruserpassword_Jsonclick = "";
         edtavConfadministratoruserpassword_Enabled = 1;
         edtavConfadministratoruserpassword_Visible = 1;
         edtavAdministratoruserpassword_Jsonclick = "";
         edtavAdministratoruserpassword_Enabled = 1;
         edtavAdministratoruserpassword_Visible = 1;
         edtavAdministratorusername_Jsonclick = "";
         edtavAdministratorusername_Enabled = 1;
         edtavAdministratorusername_Caption = "Nome de usu�rio do administrador (apelido)";
         edtavAuthenticationmasterauthtypename_Jsonclick = "";
         edtavAuthenticationmasterauthtypename_Enabled = 1;
         edtavConfconnectionuserpassword_Jsonclick = "";
         edtavConfconnectionuserpassword_Enabled = 1;
         edtavConnectionuserpassword_Jsonclick = "";
         edtavConnectionuserpassword_Enabled = 1;
         edtavConnectionusername_Jsonclick = "";
         edtavConnectionusername_Enabled = 1;
         divTbluserssettings_Visible = 1;
         chkavGiveanonymoussession.Enabled = 1;
         chkavCanregisterusers.Enabled = 1;
         chkavAllowoauthaccess.Enabled = 1;
         cmbavGeneratesessionstatistics_Jsonclick = "";
         cmbavGeneratesessionstatistics.Enabled = 1;
         edtavNamespace_Jsonclick = "";
         edtavNamespace_Enabled = 1;
         edtavNamespace_Visible = 1;
         divNamespace_cell_Class = "col-xs-12";
         chkavUsecurrentrepositorasmasterauthentication.Enabled = 1;
         chkavUsecurrentrepositorasmasterauthentication.Visible = 1;
         divUsecurrentrepositorasmasterauthentication_cell_Class = "col-xs-12";
         edtavDescription_Jsonclick = "";
         edtavDescription_Enabled = 1;
         edtavName_Jsonclick = "";
         edtavName_Enabled = 1;
         edtavGuid_Jsonclick = "";
         edtavGuid_Enabled = 1;
         edtavGuid_Visible = 1;
         divGuid_cell_Class = "col-xs-12";
         Gxuitabspanel_tabs_Historymanagement = Convert.ToBoolean( 0);
         Gxuitabspanel_tabs_Class = "Tab";
         Gxuitabspanel_tabs_Pagecount = 2;
         Form.Headerrawhtml = "";
         Form.Background = "";
         Form.Textcolor = 0;
         Form.Backcolor = (int)(0xFFFFFF);
         Form.Caption = "Repository ";
         context.GX_msglist.DisplayMode = 1;
         if ( context.isSpaRequest( ) )
         {
            enableJsOutput();
         }
      }

      public override bool SupportAjaxEvent( )
      {
         return true ;
      }

      public override void InitializeDynEvents( )
      {
         setEventMetadata("REFRESH","{handler:'Refresh',iparms:[{av:'AV42UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''},{av:'AV8AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV45CanRegisterUsers',fld:'vCANREGISTERUSERS',pic:''},{av:'AV28GiveAnonymousSession',fld:'vGIVEANONYMOUSSESSION',pic:''},{av:'AV31isGAMAdminAccessRepository',fld:'vISGAMADMINACCESSREPOSITORY',pic:''},{av:'AV20CreateGAMApplication',fld:'vCREATEGAMAPPLICATION',pic:''},{av:'AV18CopyRoles',fld:'vCOPYROLES',pic:''},{av:'AV19CopySecurityPolicies',fld:'vCOPYSECURITYPOLICIES',pic:''},{av:'AV14CopyApplication',fld:'vCOPYAPPLICATION',pic:''},{av:'AV15CopyApplicationRolePermissions',fld:'vCOPYAPPLICATIONROLEPERMISSIONS',pic:''},{av:'AV41UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''},{av:'AV30Id',fld:'vID',pic:'ZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("REFRESH",",oparms:[]}");
         setEventMetadata("ENTER","{handler:'E121O2',iparms:[{av:'AV30Id',fld:'vID',pic:'ZZZZZZZZ9',hsh:true},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true},{av:'AV7AdministratorUserPassword',fld:'vADMINISTRATORUSERPASSWORD',pic:''},{av:'AV10ConfAdministratorUserPassword',fld:'vCONFADMINISTRATORUSERPASSWORD',pic:''},{av:'AV13ConnectionUserPassword',fld:'vCONNECTIONUSERPASSWORD',pic:''},{av:'AV11ConfConnectionUserPassword',fld:'vCONFCONNECTIONUSERPASSWORD',pic:''},{av:'AV33Name',fld:'vNAME',pic:''},{av:'AV34Namespace',fld:'vNAMESPACE',pic:''},{av:'AV21Description',fld:'vDESCRIPTION',pic:''},{av:'AV6AdministratorUserName',fld:'vADMINISTRATORUSERNAME',pic:''},{av:'AV8AllowOauthAccess',fld:'vALLOWOAUTHACCESS',pic:''},{av:'AV12ConnectionUserName',fld:'vCONNECTIONUSERNAME',pic:''},{av:'cmbavGeneratesessionstatistics'},{av:'AV27GenerateSessionStatistics',fld:'vGENERATESESSIONSTATISTICS',pic:''},{av:'AV42UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''},{av:'AV9AuthenticationMasterAuthTypeName',fld:'vAUTHENTICATIONMASTERAUTHTYPENAME',pic:''},{av:'AV20CreateGAMApplication',fld:'vCREATEGAMAPPLICATION',pic:''},{av:'cmbavCopyfromrepositoryid'},{av:'AV17CopyFromRepositoryId',fld:'vCOPYFROMREPOSITORYID',pic:'ZZZZZZZZ9'},{av:'AV18CopyRoles',fld:'vCOPYROLES',pic:''},{av:'AV5AdministratorRoleId',fld:'vADMINISTRATORROLEID',pic:'ZZZZZZZZZZZ9'},{av:'AV19CopySecurityPolicies',fld:'vCOPYSECURITYPOLICIES',pic:''},{av:'AV14CopyApplication',fld:'vCOPYAPPLICATION',pic:''},{av:'AV16CopyFromApplicationId',fld:'vCOPYFROMAPPLICATIONID',pic:'ZZZZZZZZZZZ9'},{av:'AV15CopyApplicationRolePermissions',fld:'vCOPYAPPLICATIONROLEPERMISSIONS',pic:''},{av:'AV41UpdateConnectionFile',fld:'vUPDATECONNECTIONFILE',pic:''},{av:'AV31isGAMAdminAccessRepository',fld:'vISGAMADMINACCESSREPOSITORY',pic:''}]");
         setEventMetadata("ENTER",",oparms:[{av:'AV29GUID',fld:'vGUID',pic:''}]}");
         setEventMetadata("VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK","{handler:'E131O2',iparms:[{av:'AV42UseCurrentRepositorAsMasterAuthentication',fld:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',pic:''},{av:'AV15CopyApplicationRolePermissions',fld:'vCOPYAPPLICATIONROLEPERMISSIONS',pic:''},{av:'AV18CopyRoles',fld:'vCOPYROLES',pic:''},{av:'AV14CopyApplication',fld:'vCOPYAPPLICATION',pic:''},{av:'Gx_mode',fld:'vMODE',pic:'@!',hsh:true}]");
         setEventMetadata("VUSECURRENTREPOSITORASMASTERAUTHENTICATION.CLICK",",oparms:[{av:'AV34Namespace',fld:'vNAMESPACE',pic:''},{av:'AV7AdministratorUserPassword',fld:'vADMINISTRATORUSERPASSWORD',pic:''},{av:'AV10ConfAdministratorUserPassword',fld:'vCONFADMINISTRATORUSERPASSWORD',pic:''},{av:'edtavNamespace_Visible',ctrl:'vNAMESPACE',prop:'Visible'},{av:'edtavAdministratorusername_Caption',ctrl:'vADMINISTRATORUSERNAME',prop:'Caption'},{av:'edtavAdministratoruserpassword_Visible',ctrl:'vADMINISTRATORUSERPASSWORD',prop:'Visible'},{av:'edtavConfadministratoruserpassword_Visible',ctrl:'vCONFADMINISTRATORUSERPASSWORD',prop:'Visible'},{av:'edtavAdministratorroleid_Visible',ctrl:'vADMINISTRATORROLEID',prop:'Visible'},{av:'divAdministratorroleid_cell_Class',ctrl:'ADMINISTRATORROLEID_CELL',prop:'Class'},{av:'edtavCopyfromapplicationid_Visible',ctrl:'vCOPYFROMAPPLICATIONID',prop:'Visible'},{av:'divCopyfromapplicationid_cell_Class',ctrl:'COPYFROMAPPLICATIONID_CELL',prop:'Class'},{av:'edtavGuid_Visible',ctrl:'vGUID',prop:'Visible'},{av:'divGuid_cell_Class',ctrl:'GUID_CELL',prop:'Class'},{av:'chkavUsecurrentrepositorasmasterauthentication.Visible',ctrl:'vUSECURRENTREPOSITORASMASTERAUTHENTICATION',prop:'Visible'},{av:'divUsecurrentrepositorasmasterauthentication_cell_Class',ctrl:'USECURRENTREPOSITORASMASTERAUTHENTICATION_CELL',prop:'Class'},{av:'divNamespace_cell_Class',ctrl:'NAMESPACE_CELL',prop:'Class'}]}");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS","{handler:'Validv_Generatesessionstatistics',iparms:[]");
         setEventMetadata("VALIDV_GENERATESESSIONSTATISTICS",",oparms:[]}");
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
      }

      public override void initialize( )
      {
         wcpOGx_mode = "";
         gxfirstwebparm = "";
         gxfirstwebparm_bkp = "";
         sDynURL = "";
         FormProcess = "";
         bodyStyle = "";
         GXKey = "";
         GXEncryptionTmp = "";
         GX_FocusControl = "";
         Form = new GXWebForm();
         sPrefix = "";
         ClassString = "";
         StyleString = "";
         ucGxuitabspanel_tabs = new GXUserControl();
         lblGeneral_title_Jsonclick = "";
         TempTags = "";
         AV29GUID = "";
         AV33Name = "";
         AV21Description = "";
         AV34Namespace = "";
         AV27GenerateSessionStatistics = "";
         AV12ConnectionUserName = "";
         AV13ConnectionUserPassword = "";
         AV11ConfConnectionUserPassword = "";
         AV9AuthenticationMasterAuthTypeName = "";
         AV6AdministratorUserName = "";
         AV7AdministratorUserPassword = "";
         AV10ConfAdministratorUserPassword = "";
         lblCopyrepdata_title_Jsonclick = "";
         bttBtnenter_Jsonclick = "";
         bttBtncancel_Jsonclick = "";
         sEvt = "";
         EvtGridId = "";
         EvtRowId = "";
         sEvtType = "";
         GXDecQS = "";
         AV37Repository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV23Errors = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError>( context, "GeneXus.Programs.genexussecurity.SdtGAMError", "GeneXus.Programs");
         AV36Repositories = new GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository>( context, "GeneXus.Programs.genexussecurity.SdtGAMRepository", "GeneXus.Programs");
         AV39RepositoryFilter = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter(context);
         AV35Repo = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV38RepositoryCreate = new GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate(context);
         AV25GAMRepository = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV40RepositoryNew = new GeneXus.Programs.genexussecurity.SdtGAMRepository(context);
         AV26GAMUser = new GeneXus.Programs.genexussecurity.SdtGAMUser(context);
         AV22Error = new GeneXus.Programs.genexussecurity.SdtGAMError(context);
         BackMsgLst = new msglist();
         LclMsgLst = new msglist();
         pr_gam = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryentry__gam(),
            new Object[][] {
            }
         );
         pr_default = new DataStoreProvider(context, new GeneXus.Programs.gamrepositoryentry__default(),
            new Object[][] {
            }
         );
         /* GeneXus formulas. */
      }

      private short nGotPars ;
      private short GxWebError ;
      private short initialized ;
      private short gxajaxcallmode ;
      private short wbEnd ;
      private short wbStart ;
      private short nDonePA ;
      private short nGXWrapped ;
      private int AV30Id ;
      private int wcpOAV30Id ;
      private int Gxuitabspanel_tabs_Pagecount ;
      private int edtavGuid_Visible ;
      private int edtavGuid_Enabled ;
      private int edtavName_Enabled ;
      private int edtavDescription_Enabled ;
      private int edtavNamespace_Visible ;
      private int edtavNamespace_Enabled ;
      private int divTbluserssettings_Visible ;
      private int edtavConnectionusername_Enabled ;
      private int edtavConnectionuserpassword_Enabled ;
      private int edtavConfconnectionuserpassword_Enabled ;
      private int edtavAuthenticationmasterauthtypename_Enabled ;
      private int edtavAdministratorusername_Enabled ;
      private int edtavAdministratoruserpassword_Visible ;
      private int edtavAdministratoruserpassword_Enabled ;
      private int edtavConfadministratoruserpassword_Visible ;
      private int edtavConfadministratoruserpassword_Enabled ;
      private int AV17CopyFromRepositoryId ;
      private int edtavAdministratorroleid_Visible ;
      private int edtavAdministratorroleid_Enabled ;
      private int edtavCopyfromapplicationid_Visible ;
      private int edtavCopyfromapplicationid_Enabled ;
      private int AV47GXV1 ;
      private int AV48GXV2 ;
      private int idxLst ;
      private long AV5AdministratorRoleId ;
      private long AV16CopyFromApplicationId ;
      private string Gx_mode ;
      private string wcpOGx_mode ;
      private string gxfirstwebparm ;
      private string gxfirstwebparm_bkp ;
      private string sDynURL ;
      private string FormProcess ;
      private string bodyStyle ;
      private string GXKey ;
      private string GXEncryptionTmp ;
      private string Gxuitabspanel_tabs_Class ;
      private string GX_FocusControl ;
      private string sPrefix ;
      private string divLayoutmaintable_Internalname ;
      private string divTablemain_Internalname ;
      private string ClassString ;
      private string StyleString ;
      private string divTablecontent_Internalname ;
      private string Gxuitabspanel_tabs_Internalname ;
      private string lblGeneral_title_Internalname ;
      private string lblGeneral_title_Jsonclick ;
      private string divTableattributes_Internalname ;
      private string divGuid_cell_Internalname ;
      private string divGuid_cell_Class ;
      private string edtavGuid_Internalname ;
      private string TempTags ;
      private string AV29GUID ;
      private string edtavGuid_Jsonclick ;
      private string edtavName_Internalname ;
      private string AV33Name ;
      private string edtavName_Jsonclick ;
      private string edtavDescription_Internalname ;
      private string AV21Description ;
      private string edtavDescription_Jsonclick ;
      private string divUsecurrentrepositorasmasterauthentication_cell_Internalname ;
      private string divUsecurrentrepositorasmasterauthentication_cell_Class ;
      private string chkavUsecurrentrepositorasmasterauthentication_Internalname ;
      private string divNamespace_cell_Internalname ;
      private string divNamespace_cell_Class ;
      private string edtavNamespace_Internalname ;
      private string AV34Namespace ;
      private string edtavNamespace_Jsonclick ;
      private string cmbavGeneratesessionstatistics_Internalname ;
      private string AV27GenerateSessionStatistics ;
      private string cmbavGeneratesessionstatistics_Jsonclick ;
      private string chkavAllowoauthaccess_Internalname ;
      private string chkavCanregisterusers_Internalname ;
      private string chkavGiveanonymoussession_Internalname ;
      private string divTbluserssettings_Internalname ;
      private string edtavConnectionusername_Internalname ;
      private string AV12ConnectionUserName ;
      private string edtavConnectionusername_Jsonclick ;
      private string edtavConnectionuserpassword_Internalname ;
      private string AV13ConnectionUserPassword ;
      private string edtavConnectionuserpassword_Jsonclick ;
      private string edtavConfconnectionuserpassword_Internalname ;
      private string AV11ConfConnectionUserPassword ;
      private string edtavConfconnectionuserpassword_Jsonclick ;
      private string edtavAuthenticationmasterauthtypename_Internalname ;
      private string AV9AuthenticationMasterAuthTypeName ;
      private string edtavAuthenticationmasterauthtypename_Jsonclick ;
      private string edtavAdministratorusername_Internalname ;
      private string edtavAdministratorusername_Caption ;
      private string AV6AdministratorUserName ;
      private string edtavAdministratorusername_Jsonclick ;
      private string edtavAdministratoruserpassword_Internalname ;
      private string AV7AdministratorUserPassword ;
      private string edtavAdministratoruserpassword_Jsonclick ;
      private string edtavConfadministratoruserpassword_Internalname ;
      private string AV10ConfAdministratorUserPassword ;
      private string edtavConfadministratoruserpassword_Jsonclick ;
      private string chkavIsgamadminaccessrepository_Internalname ;
      private string chkavCreategamapplication_Internalname ;
      private string lblCopyrepdata_title_Internalname ;
      private string lblCopyrepdata_title_Jsonclick ;
      private string divUnnamedtable1_Internalname ;
      private string cmbavCopyfromrepositoryid_Internalname ;
      private string cmbavCopyfromrepositoryid_Jsonclick ;
      private string chkavCopyroles_Internalname ;
      private string divAdministratorroleid_cell_Internalname ;
      private string divAdministratorroleid_cell_Class ;
      private string edtavAdministratorroleid_Internalname ;
      private string edtavAdministratorroleid_Jsonclick ;
      private string chkavCopysecuritypolicies_Internalname ;
      private string chkavCopyapplication_Internalname ;
      private string divCopyfromapplicationid_cell_Internalname ;
      private string divCopyfromapplicationid_cell_Class ;
      private string edtavCopyfromapplicationid_Internalname ;
      private string edtavCopyfromapplicationid_Jsonclick ;
      private string chkavCopyapplicationrolepermissions_Internalname ;
      private string bttBtnenter_Internalname ;
      private string bttBtnenter_Caption ;
      private string bttBtnenter_Jsonclick ;
      private string bttBtncancel_Internalname ;
      private string bttBtncancel_Jsonclick ;
      private string divHtml_bottomauxiliarcontrols_Internalname ;
      private string chkavUpdateconnectionfile_Internalname ;
      private string sEvt ;
      private string EvtGridId ;
      private string EvtRowId ;
      private string sEvtType ;
      private string GXDecQS ;
      private bool entryPointCalled ;
      private bool toggleJsOutput ;
      private bool Gxuitabspanel_tabs_Historymanagement ;
      private bool wbLoad ;
      private bool AV42UseCurrentRepositorAsMasterAuthentication ;
      private bool AV8AllowOauthAccess ;
      private bool AV45CanRegisterUsers ;
      private bool AV28GiveAnonymousSession ;
      private bool AV31isGAMAdminAccessRepository ;
      private bool AV20CreateGAMApplication ;
      private bool AV18CopyRoles ;
      private bool AV19CopySecurityPolicies ;
      private bool AV14CopyApplication ;
      private bool AV15CopyApplicationRolePermissions ;
      private bool AV41UpdateConnectionFile ;
      private bool Rfr0gs ;
      private bool wbErr ;
      private bool gxdyncontrolsrefreshing ;
      private bool returnInSub ;
      private bool AV32isOK ;
      private GXUserControl ucGxuitabspanel_tabs ;
      private IGxDataStore dsGAM ;
      private IGxDataStore dsDefault ;
      private string aP0_Gx_mode ;
      private int aP1_Id ;
      private GXCheckbox chkavUsecurrentrepositorasmasterauthentication ;
      private GXCombobox cmbavGeneratesessionstatistics ;
      private GXCheckbox chkavAllowoauthaccess ;
      private GXCheckbox chkavCanregisterusers ;
      private GXCheckbox chkavGiveanonymoussession ;
      private GXCheckbox chkavIsgamadminaccessrepository ;
      private GXCheckbox chkavCreategamapplication ;
      private GXCombobox cmbavCopyfromrepositoryid ;
      private GXCheckbox chkavCopyroles ;
      private GXCheckbox chkavCopysecuritypolicies ;
      private GXCheckbox chkavCopyapplication ;
      private GXCheckbox chkavCopyapplicationrolepermissions ;
      private GXCheckbox chkavUpdateconnectionfile ;
      private IDataStoreProvider pr_default ;
      private msglist BackMsgLst ;
      private msglist LclMsgLst ;
      private IDataStoreProvider pr_gam ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMError> AV23Errors ;
      private GXExternalCollection<GeneXus.Programs.genexussecurity.SdtGAMRepository> AV36Repositories ;
      private GXWebForm Form ;
      private GeneXus.Programs.genexussecurity.SdtGAMError AV22Error ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryCreate AV38RepositoryCreate ;
      private GeneXus.Programs.genexussecurity.SdtGAMUser AV26GAMUser ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV37Repository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV35Repo ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV25GAMRepository ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepository AV40RepositoryNew ;
      private GeneXus.Programs.genexussecurity.SdtGAMRepositoryFilter AV39RepositoryFilter ;
   }

   public class gamrepositoryentry__gam : DataStoreHelperBase, IDataStoreHelper
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

 public class gamrepositoryentry__default : DataStoreHelperBase, IDataStoreHelper
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

}

}
